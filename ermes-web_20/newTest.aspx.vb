Imports System.IO

Public Class newTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        codice_dispositivo.Focus()

    End Sub

    Protected Sub save_aggiungi_utilizzatore_new_Click(sender As Object, e As EventArgs) Handles save_aggiungi_utilizzatore_new.Click

        Dim serialNumber As String = "00000000000000000"
        Dim mainFunctionConfig As String = mainFunctionCenturio.getConfigCentrurio(serialNumber) ' serial number default produzione
        Dim pipeClient As New centurioRealTime
        Dim resultPipe As String = ""
        Dim resultConfigurationInput As String = ""
        Dim query As New query

        resultPipe = pipeClient.Main(serialNumber, "controller_type")

        If resultPipe <> "null" And resultPipe <> "" Then

            resultPipe = resultPipe
            resultConfigurationInput = pipeClient.Main(serialNumber, "configurationFinal")
            'tabella_centurio = query.getRuntimeSchema("OSIN01")

        Else
            Dim strinxXML As String = query.getConfigGlobal(1)
            resultPipe = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 2)
            resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 3)
        End If

        Response.Redirect("mainCenturio.aspx?serial=" + serialNumber + "&codice=" + resultPipe + "&configuration=" + resultConfigurationInput + "&user=andrea&pass=andrea")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim serialNumber As String = ""
        If TextBox1.Text.Length = 17 Then
            serialNumber = TextBox1.Text
        Else
            serialNumber = Mid(codice_dispositivo.Text, codice_dispositivo.Text.IndexOf("=") + 2, codice_dispositivo.Text.IndexOf("_") - codice_dispositivo.Text.IndexOf("=") - 1)
        End If

        Dim mainFunctionConfig As String = mainFunctionCenturio.getConfigCentrurio(serialNumber) ' serial number default produzione
        Dim pipeClient As New centurioRealTime
        Dim resultPipe As String = ""
        Dim resultConfigurationInput As String = ""
        Dim query As New query

        resultPipe = pipeClient.Main(serialNumber, "controller_type")

        If resultPipe <> "null" And resultPipe <> "" Then

            resultPipe = resultPipe
            resultConfigurationInput = pipeClient.Main(serialNumber, "configurationFinal")
            'tabella_centurio = query.getRuntimeSchema("OSIN01")

        Else
            'Dim strinxXML As String = query.getConfigGlobal(1)
            Dim strinxXML As String = getConfigFromFile(serialNumber)
            resultPipe = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 2)
            'resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 3)
            resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 3)
            'resultPipe = mainFunctionCenturio.getFileInfoXML(resultPipe = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 2)
            'resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 3)

            'resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 3)
        End If

        Response.Redirect("mainCenturio.aspx?serial=" + serialNumber + "&codice=" + resultPipe + "&configuration=" + resultConfigurationInput + "&user=andrea&pass=andrea&sistemaUSA=0")

    End Sub

    Private Function getConfigFromFile(ByVal serialReference As String) As String
        If File.Exists("c:\centurio\" + serialReference + "_xml.txt") Then
            'Return XmlReader.Create(New StringReader(My.Computer.FileSystem.ReadAllText("c:\centurio\" + serialReference + "_xml.txt")))
            Return My.Computer.FileSystem.ReadAllText("c:\centurio\" + serialReference + "_xml.txt")
        End If
        Return ""
    End Function

End Class