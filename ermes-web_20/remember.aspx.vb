Public Class remember
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            literal_stefano.Text = Session("personalizzazioneStefano")
            java_script_local.Text = "<script>"
            java_script_local.Text = java_script_local.Text + "var invalid_mail_format='"
            java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "invalid_mail_format") + "';"
            java_script_local.Text = java_script_local.Text + "</script>"
            literal_theme.Text = Session("stile")
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tabella As ermes_web_20.quey_db.super_userDataTable
        Dim result As Integer
        Dim query As New query

        tabella = query.get_mail_super(email_val.Text)
        result = tabella.Count
        If result > 0 Then
            For Each dc In tabella
                main_function.send_mail(email_val.Text, "ermes-server.com", "user:" + dc.utente + vbCrLf + "password:" + dc.password + vbCrLf, False)
                Exit For
            Next
            Literal6.Visible = False
            Literal5.Visible = True
        Else
            Literal5.Visible = False
            Literal6.Visible = True
        End If
    End Sub
End Class