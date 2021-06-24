Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim header_script As String = ""

        Dim user As String = ""
        Dim password As String = ""


        user = Page.Request("user")
        password = Page.Request("pass")



        header_script = HttpContext.Current.Request.Url.Host


        Label2N.Visible = False
        Try
            Dim risultato As String = ""
            risultato = Page.Request("risultato_login")
            Session.Remove("username")
            Session.Remove("password")
            Session.Remove("login_ok")
            Session.Remove("super_user")
            Session.Remove("logo")
            Session.Remove("stile")
            Session.Remove("numeroRefresh")
            If risultato = "1" Then
                Label2N.Visible = True
            End If
        Catch ex As Exception

        End Try

        Session("personalizzazioneStefano") = ""
        header_script = header_script.Replace("www.", "")
        If InStr(header_script, ".ermes-server") <> 0 Then 'se personalizzazione redirect al vecchio ermes
            Response.Redirect("loginold.aspx")
        Else
            Session("logo") = "<img src='" + ResolveUrl("~/") + "image/logo_ermes.png' alt='logo'>"
            Session("stile") = "<link id='themer-stylesheet' href='" + ResolveUrl("~/") + "theme/personalizzazione/ermes.css' rel='stylesheet' type='text/css' />"
            'literal_stefano.Text = "<link href=""" + ResolveUrl("~/") + "theme/css/personalizzazione_stefano.css"" rel=""stylesheet"" type=""text/css""/>"
            Session("personalizzazioneStefano") = "<link href=""" + ResolveUrl("~/") + "theme/css/personalizzazione_stefano.css?v=1.5"" rel=""stylesheet"" type=""text/css""/>"
        End If
        ' nell'aggiungere una nuova lingua modificare la condizione IF della  procedura  InitializeCulture()
        If user IsNot Nothing And password IsNot Nothing Then
            Session("username") = user
            Session("password") = password
            Session("numeroRefresh") = 0
            Response.Redirect("dashboardNew.aspx")
        End If
        If Not IsPostBack Then
            If ((Not (Request.Cookies("UserName")) Is Nothing) _
                        AndAlso (Not (Request.Cookies("Password")) Is Nothing) _
                        AndAlso (Not (Request.Cookies("checked")) Is Nothing)) Then
                TextBox1N.Text = Request.Cookies("UserName").Value
                TextBox2N.Attributes("value") = Request.Cookies("Password").Value
                CheckBox1N.Checked = Request.Cookies("checked").Value
                'Session("username") = TextBox1.Text
                'Session("password") = TextBox2.Text
                'Response.Redirect("dashboard.aspx")
            End If
        End If

    End Sub


    Protected Overrides Sub InitializeCulture()

        Dim selectedLanguage As String

        Dim linguaggio_def() As String
        Dim linguaggio As String
        Dim canale As String = ""
        canale = Page.Request("lang")
        ' Session.Abandon()
        'Session.Clear()

        If canale Is Nothing Or canale = "" Then
            linguaggio = Request.UserLanguages(0)
            linguaggio_def = linguaggio.Split("-")
            Try
                If linguaggio_def.Length > 1 Then
                    selectedLanguage = linguaggio_def(0)
                Else
                    selectedLanguage = linguaggio_def(0)
                    If selectedLanguage <> "en" And selectedLanguage <> "it" And selectedLanguage <> "de" And selectedLanguage <> "fr" And selectedLanguage <> "pl" And selectedLanguage <> "es" Then
                        selectedLanguage = "en"
                    End If

                End If
            Catch ex As Exception
                selectedLanguage = "en"
            End Try
        Else
            selectedLanguage = canale
        End If
        If selectedLanguage <> "en" And selectedLanguage <> "it" And selectedLanguage <> "de" And selectedLanguage <> "fr" And selectedLanguage <> "pl" And selectedLanguage <> "es" Then
            selectedLanguage = "en"
        End If
        Session("selectedLanguage") = selectedLanguage
        UICulture = selectedLanguage
        Culture = selectedLanguage
        Thread.CurrentThread.CurrentCulture = _
            CultureInfo.CreateSpecificCulture(selectedLanguage)
        Thread.CurrentThread.CurrentUICulture = New  _
            CultureInfo(selectedLanguage)

        MyBase.InitializeCulture()
    End Sub

    Protected Sub Button1N_Click(sender As Object, e As EventArgs) Handles Button1N.Click
        Dim qr As String = ""
        Dim serial As String = ""
        qr = Page.Request("qr")
        serial = Page.Request("serial")

        If CheckBox1N.Checked Then
            Response.Cookies("UserName").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("Password").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("checked").Expires = DateTime.Now.AddDays(30)
        Else
            Response.Cookies("UserName").Expires = DateTime.Now.AddDays(-1)
            Response.Cookies("Password").Expires = DateTime.Now.AddDays(-1)
            Response.Cookies("checked").Expires = DateTime.Now.AddDays(-1)
        End If
        Response.Cookies("UserName").Value = TextBox1N.Text.Trim
        Response.Cookies("Password").Value = TextBox2N.Text.Trim
        Response.Cookies("checked").Value = CheckBox1N.Checked

        Session("username") = TextBox1N.Text
        Session("password") = TextBox2N.Text
        If qr IsNot Nothing And serial IsNot Nothing Then
            Response.Redirect("plant.aspx?serial=" + serial)
        Else
            Response.Redirect("dashboardAssets.aspx")
            'Response.Redirect("dashboardNew.aspx")
        End If
    End Sub


End Class