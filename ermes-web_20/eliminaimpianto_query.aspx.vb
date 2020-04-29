Public Class eliminaimpianto_query
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codice_impianto As String = ""
        Dim risultato_query As Boolean
        Dim query As New query

        codice_impianto = Page.Request("codice_generale")
        If (codice_impianto = "128718") Or (codice_impianto = "912601") Then
            risultato_query = True
        Else
            risultato_query = query.delete_impianto(codice_impianto)
        End If

        If risultato_query Then
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("eliminaimpianto.aspx?result=1&niente=0")
        Else
            Response.Redirect("eliminaimpianto.aspx?result=2&niente=0")
        End If
    End Sub

End Class