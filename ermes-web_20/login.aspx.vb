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


        Label2.Visible = False
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
                Label2.Visible = True
            End If
        Catch ex As Exception

        End Try

        Session("personalizzazioneStefano") = ""
        If InStr(header_script, "emecfrance") <> 0 Then 'personalizzazione  emecfrance ermes
            bodyContent.Text = "<body class=""login"" >"
            Session("logo") = "<img src='image/logo_placeholder.png' alt='logo'>"
            Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/emecfrance.css' rel='stylesheet' type='text/css' />"
        Else
            If InStr(header_script, "yagel") <> 0 Then 'personalizzazione  emecfrance ermes
                bodyContent.Text = "<body class=""login"" >"
                Session("logo") = "<img src='image/yagel.png' alt='logo'>"
                Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/yagel.css' rel='stylesheet' type='text/css' />"
            Else
                If InStr(header_script, "diversey") <> 0 Then 'personalizzazione  emecfrance ermes
                    bodyContent.Text = "<body class=""login"" >"
                    'If InStr(header_script, "local") <> 0 Then 'personalizzazione  emecfrance ermes
                    Session("logo") = "<img src='image/sealedAir.png' alt='logo'>"
                    Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/sealedAir.css' rel='stylesheet' type='text/css' />"

                Else
                    If InStr(header_script, "aloes") <> 0 Then 'personalizzazione  
                        bodyContent.Text = "<body class=""login"" >"
                        Session("logo") = "<img src='image/aloes_logo.png' alt='logo'>"
                        Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/aloes.css' rel='stylesheet' type='text/css' />"
                    Else
                        If InStr(header_script, "certidos") <> 0 Then 'personalizzazione  
                            bodyContent.Text = "<body class=""login"" >"
                            Session("logo") = "<img src='image/certidos.png' alt='logo'>"
                            Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/certidos.css' rel='stylesheet' type='text/css' />"

                        Else
                            If InStr(header_script, "astral") <> 0 Then 'personalizzazione  
                                bodyContent.Text = "<body class=""login"" >"
                                Session("logo") = "<img src='image/astralpool.png' alt='logo'>"
                                Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/astral.css' rel='stylesheet' type='text/css' />"
                            Else
                                If InStr(header_script, "kurita") <> 0 Then 'personalizzazione 
                                    bodyContent.Text = "<body class=""login"" >"
                                    Session("logo") = "<img src='image/kurita.png' alt='logo'>"
                                    Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/kurita.css' rel='stylesheet' type='text/css' />"
                                Else
                                    If InStr(header_script, "clearwater") <> 0 Then 'personalizzazione 
                                        Session("logo") = "<img src='image/logo_cleanwater.png' alt='logo'>"
                                        Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/cleanwater.css' rel='stylesheet' type='text/css' />"
                                        bodyContent.Text = "<body class=""login"" style=""background-image: url('image/background.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: center;"">"
                                    Else
                                        If InStr(header_script, "zep") <> 0 Then 'personalizzazione 
                                            bodyContent.Text = "<body class=""login"" >"
                                            Session("logo") = "<img src='image/logo_zep.png' alt='logo'>"
                                            Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/zep.css' rel='stylesheet' type='text/css' />"


                                        Else
                                            If InStr(header_script, "proquimia") <> 0 Then 'personalizzazione 
                                                bodyContent.Text = "<body class=""login"" >"
                                                Session("logo") = "<img src='image/proguard.png' alt='logo'>"
                                                Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/proquimia.css' rel='stylesheet' type='text/css' />"

                                            Else
                                                If InStr(header_script, "aquaprox") <> 0 Then 'personalizzazione 
                                                    Session("logo") = "<img src='image/aquaprox.png' alt='logo'>"
                                                    Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/aquaprox.css' rel='stylesheet' type='text/css' />"
                                                Else
                                                    If InStr(header_script, "realtime") <> 0 Then 'personalizzazione 
                                                        Session("logo") = "<img src='image/realtime.jpg' alt='logo'>"
                                                        Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/realtime.css' rel='stylesheet' type='text/css' />"

                                                    Else
                                                        If InStr(header_script, "henkel") <> 0 Then 'personalizzazione 
                                                            Session("logo") = "<img src='image/henkel.png' alt='logo'>"
                                                            Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/henkel.css' rel='stylesheet' type='text/css' />"
                                                        Else
                                                            If InStr(header_script, "hydro-x") <> 0 Then 'personalizzazione 
                                                                Session("logo") = "<img src='image/hydrox.png' alt='logo'>"
                                                                Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/hydrox.css' rel='stylesheet' type='text/css' />"

                                                            Else
                                                                If InStr(header_script, "hydrotech") <> 0 Then 'personalizzazione 
                                                                    Session("logo") = "<img src='image/hydrotech.png' alt='logo'>"
                                                                    Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/hydrotech.css' rel='stylesheet' type='text/css' />"

                                                                Else
                                                                    Session("logo") = "<img src='image/logo_ermes.png' alt='logo'>"
                                                                    Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/ermes.css' rel='stylesheet' type='text/css' />"
                                                                    literal_stefano.Text = "<link href=""theme/css/personalizzazione_stefano.css"" rel=""stylesheet"" type=""text/css""/>"
                                                                    Session("personalizzazioneStefano") = "<link href=""theme/css/personalizzazione_stefano.css"" rel=""stylesheet"" type=""text/css""/>"


                                                                End If
                                                            End If
                                                        End If
                                                        'Session("logo") = "<img src='image/logo_ermes.png' alt='logo'>"
                                                        'Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/ermes.css' rel='stylesheet' type='text/css' />"
                                                    End If

                                                End If
                                                'bodyContent.Text = "<body class=""login"" >"
                                                'Session("logo") = "<img src='image/logo_ermes.png' alt='logo'>"
                                                'Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/ermes.css' rel='stylesheet' type='text/css' />"
                                            End If
                                        End If
                                        'bodyContent.Text = "<body class=""login"" >"

                                        'bodyContent.Text = "<body class=""login"" style=""background-image: url('image/background.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: center;"">"
                                        'Session("logo") = "<img src='image/logo_cleanwater.png' alt='logo'>"
                                        'Session("stile") = "<link id='themer-stylesheet' href='theme/personalizzazione/cleanwater.css' rel='stylesheet' type='text/css' />"
                                    End If
                                End If
                            End If
                        End If
                        End If


                End If

            End If
        End If
        literal_theme.Text = Session("stile")
        literal_logo.Text = Session("logo")

        Select Case Session("selectedLanguage")
            Case "en"
                Literal3.Text = "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/en.png' alt='en' /></a>"
                Literal2.Text = "<li class='active'><a href='login.aspx?lang=en' title='English'><img src='theme/images/lang/en.png' alt='English'> English</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italian'><img src='theme/images/lang/it.png' alt='Italian'> Italian</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Deutsch'><img src='theme/images/lang/de.png' alt='Deutsch'> Deutsch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='French'><img src='theme/images/lang/fr.png' alt='French'> French</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Spanish</a></li>"
            Case "it"
                Literal3.Text = "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/it.png' alt='it' /></a>"
                Literal2.Text = "<li class='active'><a href='login.aspx?lang=it' title='Italiano'><img src='theme/images/lang/it.png' alt='Italiano'> Italiano</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Tedesco'><img src='theme/images/lang/de.png' alt='Tedesco'> Tedesco</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Inglese'><img src='theme/images/lang/en.png' alt='Inglese'> Inglese</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='Francese'><img src='theme/images/lang/fr.png' alt='Francese'> Francese</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Spagnolo</a></li>"
            Case "de"
                Literal3.Text = "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/de.png' alt='de' /></a>"
                Literal2.Text = "<li class='active'><a href='login.aspx?lang=de' title='English'><img src='theme/images/lang/de.png' alt='English'> Deutsch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italienisch'><img src='theme/images/lang/it.png' alt='Italienisch'> Italienisch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Englisch'><img src='theme/images/lang/en.png' alt='Englisch'> Englisch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='Französisch'><img src='theme/images/lang/fr.png' alt='Französisch'> Französisch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Spanisch</a></li>"
            Case "fr"
                Literal3.Text = "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/fr.png' alt='fr' /></a>"
                Literal2.Text = "<li class='active'><a href='login.aspx?lang=fr' title='Français'><img src='theme/images/lang/fr.png' alt='Français'> Français</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italien'><img src='theme/images/lang/it.png' alt='Italien'> Italien</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Anglais'><img src='theme/images/lang/en.png' alt='Anglais'> Anglais</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Allemand'><img src='theme/images/lang/de.png' alt='Allemand'> Allemand</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Espagnol</a></li>"
            Case "pl"
                Literal3.Text = "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/pl.png' alt='pl' /></a>"
                Literal2.Text = "<li class='active'><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italian'><img src='theme/images/lang/it.png' alt='Italian'> Italian</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Deutsch'><img src='theme/images/lang/de.png' alt='Deutsch'> Deutsch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='French'><img src='theme/images/lang/fr.png' alt='French'> French</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Inglese'><img src='theme/images/lang/en.png' alt='English'> English</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Hiszpański</a></li>"
            Case "es"
                Literal3.Text = "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/ES.png' alt='ES' /></a>"
                Literal2.Text = "<li class='active'><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polaco</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italian'><img src='theme/images/lang/it.png' alt='Italian'> Italiano</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Deutsch'><img src='theme/images/lang/de.png' alt='Deutsch'> Alemán</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='French'><img src='theme/images/lang/fr.png' alt='French'> Francés</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Inglese'><img src='theme/images/lang/en.png' alt='English'> Inglés</a></li>"


        End Select
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
                TextBox1.Text = Request.Cookies("UserName").Value
                TextBox2.Attributes("value") = Request.Cookies("Password").Value
                CheckBox1.Checked = Request.Cookies("checked").Value
                'Session("username") = TextBox1.Text
                'Session("password") = TextBox2.Text
                'Response.Redirect("dashboard.aspx")
            End If
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim qr As String = ""
        Dim serial As String = ""
        qr = Page.Request("qr")
        serial = Page.Request("serial")

        If CheckBox1.Checked Then
            Response.Cookies("UserName").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("Password").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("checked").Expires = DateTime.Now.AddDays(30)
        Else
            Response.Cookies("UserName").Expires = DateTime.Now.AddDays(-1)
            Response.Cookies("Password").Expires = DateTime.Now.AddDays(-1)
            Response.Cookies("checked").Expires = DateTime.Now.AddDays(-1)
        End If
        Response.Cookies("UserName").Value = TextBox1.Text.Trim
        Response.Cookies("Password").Value = TextBox2.Text.Trim
        Response.Cookies("checked").Value = CheckBox1.Checked

        Session("username") = TextBox1.Text
        Session("password") = TextBox2.Text
        If qr IsNot Nothing And serial IsNot Nothing Then
            Response.Redirect("addimpianto.aspx?serial=" + serial)
        Else
            Response.Redirect("dashboardNew.aspx")
        End If


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("signup.aspx")
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

End Class