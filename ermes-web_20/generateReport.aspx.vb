Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf

Public Class generateReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dateFrom As String = ""
        Dim dateTo As String = ""
        Dim type As String = ""
        Dim listDataF As String = ""
        Dim serial As String = ""
        Dim queryText As String = "data"
        Dim listLog As New List(Of String)
        Dim colonne As Integer = 0
        Dim label As New List(Of String)
        'Dim ConfigurationInput As String = ""
        dateFrom = Page.Request("dateFrom")
        dateTo = Page.Request("dateTo")

        type = Page.Request("type")
        listDataF = Page.Request("listDataF")
        serial = Page.Request("serial")
        Dim queryDB As New queryDB
        Dim splitValue() As String = listDataF.Split(";")
        label.Add("DATE TIME")

        For Each value As String In splitValue
            If value.IndexOf("|") > 0 Then
                Dim valueTemp() As String = value.Split("|")
                queryText = queryText + "," + valueTemp(0)
                label.Add(valueTemp(1))

                colonne = colonne + 1
            End If
        Next

        queryDB.connectToDb(False)
        'queryDB.connectToDb(True)

        queryDB.selectQueryMainReport("select DISTINCT  " + queryText + " from M" + serial + " where  (data BETWEEN '" + dateFrom + "'  AND '" + dateTo + "') order by data DESC", listLog)
        queryDB.disConnectToDb()
        If type = "1" Then
            generaPDF(colonne, listLog, label, serial)
        End If
        If type = "2" Then
            generaEXCEL(colonne, listLog, label, serial)
        End If

        If type = "3" Then
            generaCSV(colonne, listLog, label, serial)
        End If

    End Sub
    Protected Sub generaPDF(ByVal colonne As Integer, ByVal listLog As List(Of String), ByVal label As List(Of String), ByVal serialNumber As String)
        Dim Documento As New Document(PageSize.A4, 100, 100, 25, 25)
        Dim output = New MemoryStream()
        Dim Scrittura As PdfWriter = PdfWriter.GetInstance(Documento, output)
        Documento.Open()
        'Dim logo = iTextSharp.text.Image.GetInstance(Server.MapPath("Img/logs.png"))
        'logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT
        'Documento.Add(logo)
        Documento.Add(Chunk.NEWLINE)
        Documento.Add(Chunk.NEWLINE)
        Dim titleFont = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD)
        Dim ParTitolo As New Paragraph(serialNumber, titleFont)
        ParTitolo.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        ParTitolo.SpacingAfter = 10
        Documento.Add(ParTitolo)
        'Dim ParTesto As New Paragraph("Testo")
        'Documento.Add(ParTesto)

        Dim Table = New PdfPTable(colonne + 1)
        Table.WidthPercentage = 100

        Table.HorizontalAlignment = 0
        'Table.SpacingBefore = 20.0F
        'Table.SpacingAfter = 30.0F
        For Each element As String In label
            Table.AddCell(element)
        Next
        For Each element As String In listLog
            Dim labelSplit() As String = element.Split(",")
            For Each elementCel As String In labelSplit
                Table.AddCell(elementCel)
            Next

        Next

        'For Each chiave In listLog.Keys
        '    Table.AddCell("15/02/2020")
        'Next
        'Table.AddCell("15/02/2020")
        'Table.AddCell("125.6")
        'Table.AddCell("236.8")

        Documento.Add(Table)

        Documento.Close()
        Me.Response.BufferOutput = True
        Me.Response.Clear()
        Me.Response.ClearHeaders()
        Me.Response.ContentType = "application/octet-stream"
        Me.Response.AddHeader("Content-Disposition", "attachment; filename=" + serialNumber + ".pdf")
        Me.Response.BinaryWrite(output.GetBuffer())
        Me.Response.Flush()
        Me.Response.End()
    End Sub

    Protected Sub generaCSV(ByVal colonne As Integer, ByVal listLog As List(Of String), ByVal label As List(Of String), ByVal serialNumber As String)
        Dim header As String = ""
        Dim virgola As String = ""
        For Each element As String In label
            header = header + virgola + element
            virgola = ","
        Next
        Dim body As New StringBuilder
        body.AppendLine(header)

        For Each element As String In listLog
            Dim labelSplit() As String = element.Split(",")
            body.AppendLine(String.Join(",", labelSplit))
        Next
        Dim context As HttpContext = HttpContext.Current

        context.Response.Write(body.ToString())
        context.Response.ContentType = "text/csv"
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + serialNumber + ".csv")
        context.Response.End()

    End Sub
    Protected Sub generaEXCEL(ByVal colonne As Integer, ByVal listLog As List(Of String), ByVal label As List(Of String), ByVal serialNumber As String)
        Dim header As New StringBuilder
        header.AppendLine("<table>")
        header.AppendLine("<tr>")
        For Each element As String In label
            header.AppendLine("<th>" + element + "</th>")
        Next

        header.AppendLine("</tr>")

        For Each element As String In listLog
            Dim labelSplit() As String = element.Split(",")
            header.AppendLine("<tr>")
            For Each elementSub In labelSplit
                header.AppendLine("<td>" + elementSub + "</td>")
            Next
            header.AppendLine("</tr>")
        Next

        header.AppendLine("</table>")

        Dim context As HttpContext = HttpContext.Current

        context.Response.Write(header.ToString)
        context.Response.ContentType = "application/vnd.ms-excel"
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + serialNumber + ".xls")

        context.Response.End()
    End Sub

End Class