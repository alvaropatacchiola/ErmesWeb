Public Class utilizzatoreDelete
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id_user As String = ""
        Dim query As New query
        Dim risultato_query As Boolean
        id_user = Page.Request("codice_generale")
        'Dim codice_user As Guid = New Guid(id_user)

        'risultato_query = query.delete_user(codice_user)
        'If risultato_query Then
        '    Master.create_master_page()
        '    Master.manage_sidebar_top()
        '    Response.Redirect("eliminautilizzatore.aspx?result=1&niente=0")
        'Else
        '    Response.Redirect("eliminautilizzatore.aspx?result=2&niente=0")
        'End If
    End Sub

End Class