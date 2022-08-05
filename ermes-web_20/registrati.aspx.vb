Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization

Public Class signup
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'literal_stefano.Text = Session("personalizzazioneStefano")

        java_script_local.Text = "<script>"
        java_script_local.Text = java_script_local.Text + "var username='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "username") + "';"
        java_script_local.Text = java_script_local.Text + "var username_6='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "username_6") + "';"
        java_script_local.Text = java_script_local.Text + "var password='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "password") + "';"
        java_script_local.Text = java_script_local.Text + "var password_6='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "password_6") + "';"
        java_script_local.Text = java_script_local.Text + "var password_uguale='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "password_uguale") + "';"
        java_script_local.Text = java_script_local.Text + "var email='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "email") + "';"
        java_script_local.Text = java_script_local.Text + "var policy='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "policy") + "';"

        java_script_local.Text = java_script_local.Text + "</script>"
        Try
            'Literal1.Text = "<a href='login.aspx?lang=" + Session("selectedLanguage") + "'>" + GetGlobalResourceObject("signup_global", "sign_in") + "</a>"
        Catch ex As Exception
            'Literal1.Text = "<a href='login.aspx'>" + GetGlobalResourceObject("signup_global", "sign_in") + "</a>"
        End Try
        'literal_theme.Text = Session("stile")

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim companyStr As String
        Dim usernameStr As String
        Dim passwordStr As String
        Dim mailStr As String
        Dim result_user As Boolean = False
        Dim query As New query

        Dim isHuman As Boolean
        isHuman = ExampleCaptcha.Validate()
        If isHuman Then
            companyStr = company.Text
            usernameStr = username.Text
            passwordStr = password.Text
            mailStr = email.Text
            result_user = query.check_user(usernameStr, passwordStr) ' true utente ok
            If result_user Then ' utente ok registrabile
                result_user = query.insert_super_user(usernameStr, passwordStr, companyStr, mailStr)
                If result_user Then
                    main_function.send_mail(mailStr, GetLocalResourceObject("account_ready"), GetLocalResourceObject("Literal1Resource1.Text"), True, "Nuova Registrazione Ermes", "ip:" + getIpClient() + vbCrLf + "username:" + usernameStr + vbCrLf + "azienda:" + companyStr + vbCrLf + "mail:" + mailStr)
                    Response.Redirect("signed.aspx?result=1")
                Else ' errore
                    Response.Redirect("signed.aspx?result=2")
                End If
            Else ' errore
                Response.Redirect("signed.aspx?result=0")
            End If
        End If
    End Sub
    Public Function getIpClient() As String
        Dim IPAddress As String = ""
        'Dim Host As System.Net.IPHostEntry
        'Dim Hostname As String
        'Hostname = My.Computer.Name
        'Host = System.Net.Dns.GetHostEntry(Hostname)
        'For Each IP As System.Net.IPAddress In Host.AddressList
        '    If IP.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
        '        IPAddress = Convert.ToString(IP)
        '    End If
        'Next
        IPAddress = HttpContext.Current.Request.UserHostAddress()
        Return IPAddress
    End Function
End Class