Public Class signed
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim company As String
        Dim username As String
        Dim password As String
        Dim mail As String
        Dim result_user As Boolean = False
        Dim query As New query

        company = Request.Form("company")
        username = Request.Form("username")
        password = Request.Form("password")
        mail = Request.Form("email")
        result_user = query.check_user(username, password) ' true utente ok
        If result_user Then ' utente ok registrabile
            result_user = query.insert_super_user(username, password, company, mail)
            If result_user Then
                Literal1.Visible = True
                Literal3.Visible = True
                Literal2.Visible = False
                Literal4.Visible = False
                main_function.send_mail(mail, GetLocalResourceObject("account_ready"), GetLocalResourceObject("Literal1Resource1.Text"), True, "Nuova Registrazione Ermes", "username:" + username + vbCrLf + "azienda:" + company + vbCrLf + "mail:" + mail)
            Else ' errore
                Literal2.Visible = True
                Literal4.Visible = True
                Literal3.Visible = False
                Literal1.Visible = False
            End If
        Else ' errore
            Literal2.Visible = True
            Literal4.Visible = True
            Literal3.Visible = False
            Literal1.Visible = False

        End If

    End Sub

End Class