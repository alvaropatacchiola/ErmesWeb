Imports System.Globalization
Imports System.IO
Imports System.Web

Public Class ldma_logmetod
    Inherits System.Web.UI.Page
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_ldma(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.log_ldmaDataTable = New ermes_web_20.quey_db.log_ldmaDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        table_log = query.get_log_ldma(parametri(0), parametri(1), temporaneo_id)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            array.Add(data_str)
            array.Add(Replace(dc.livello1.ToString, ",", "."))
            array.Add(Replace(dc.livello2.ToString, ",", "."))
            array.Add(Replace(dc.livello3.ToString, ",", "."))
            array.Add(Replace(dc.livello4.ToString, ",", "."))
            array.Add(Replace(dc.livello5.ToString, ",", "."))
            'contatore += 1
            'If contatore > 2 Then
            '    Exit For
            'End If
        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_ldlg(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.log_ldlgDataTable = New ermes_web_20.quey_db.log_ldlgDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(0) = parametri(0).Replace("""", "")
        parametri(1) = parametri(1).Replace("""", "")
        table_log = query.get_log_ldlg(parametri(0), parametri(1), temporaneo_id)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            array.Add(data_str)
            array.Add(Replace(dc.counter1.ToString, ",", "."))
            array.Add(Replace(dc.counter2.ToString, ",", "."))
            array.Add(Replace(dc.counter3.ToString, ",", "."))
            array.Add(Replace(dc.counter4.ToString, ",", "."))
            array.Add(Replace(dc.counter5.ToString, ",", "."))
            array.Add(Replace(dc.counter1_1.ToString, ",", "."))
            array.Add(Replace(dc.counter2_1.ToString, ",", "."))
            array.Add(Replace(dc.counter3_1.ToString, ",", "."))
            array.Add(Replace(dc.counter4_1.ToString, ",", "."))
            array.Add(Replace(dc.counter5_1.ToString, ",", "."))
            array.Add(Replace(dc.counter1_2.ToString, ",", "."))
            array.Add(Replace(dc.counter2_2.ToString, ",", "."))

            'contatore += 1
            'If contatore > 2 Then
            '    Exit For
            'End If
        Next
        Return array
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class