Public Class addUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim azienda As String = ""
        Dim user As String = ""
        Dim password As String = ""
        Dim mail As String = ""
        Dim result_user As Boolean = False
        Dim query As New query
        Dim stringaResult As String = "{"

        azienda = Page.Request("azienda")
        user = Page.Request("user")
        password = Page.Request("pass")
        mail = Page.Request("mail")
        result_user = query.check_user(user, password) ' true utente ok
        If result_user Then ' utente ok registrabile
            result_user = query.insert_super_user(user, password, azienda, mail)
            If result_user Then
                Try
                    main_function.send_mail(mail, "Ermes-server Account", "<p>Thank you for registering on ERMES.</p><p>Your account is now active. Please remember to add a new plant   2 days or your account will be disabled.</p>	<p> </p>", True, "Nuova Registrazione Ermes", "username:" + user + vbCrLf + "azienda:" + azienda + vbCrLf + "mail:" + mail)
                Catch ex As Exception

                End Try
                stringaResult = stringaResult + """errore"":""ok""}"
            Else
                stringaResult = stringaResult + """errore"":""insertError""}"
            End If
        Else
            stringaResult = stringaResult + """errore"":""utenteDuplicato""}"
        End If
        stringaRisposta.Text = stringaResult
    End Sub


End Class