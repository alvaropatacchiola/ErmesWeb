Public Class aggiungiImpianto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sito As String = ""
        Dim impianto As String = ""
        Dim serial As String = ""
        Dim idsuper As String = ""
        Dim count_super As Integer = 0
        Dim result_query As Boolean = False
        Dim query As New query
        Dim table_super As ermes_web_20.quey_db.super_userDataTable
        Dim listResult As New Dictionary(Of String, List(Of String))
        Dim stringaResult As String = "{"
        Dim virgola As String = ""

        sito = Page.Request("sito")
        impianto = Page.Request("impianto")
        serial = Page.Request("serial")
        idsuper = Page.Request("idsuper")
        Dim codice_super As Guid = New Guid(idsuper)
        result_query = query.insert_impianto(codice_super, "00000000-0000-0000-0000-000000000000", "", sito + ">" + impianto, "",
                                               serial, "", Now, "", "", False)
        If result_query Then
            stringaResult = stringaResult + """errore"":""ok""}"
        Else
            stringaResult = stringaResult + """errore"":""invalidInsert""}"
        End If
        stringaRisposta.Text = stringaResult

    End Sub

End Class