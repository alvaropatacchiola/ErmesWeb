Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization

Partial Public Class main
    Inherits System.Web.UI.MasterPage
    'Private mtabella_impianto As New ermes_web_20.quey_db.impiantoDataTable
    'Private mid_super As New Guid
    Public ReadOnly Property tabella_impianto_container() As ermes_web_20.quey_db.impianto_newDataTable
        Get
            Return Session("tabella_impianto")
        End Get

    End Property
    Public ReadOnly Property id_super_container() As Guid
        Get
            Return Session("mid_super")
        End Get

    End Property
    Public Sub create_master_page()
        'gestione connsessione login
        Dim table_super As ermes_web_20.quey_db.super_userDataTable
        Dim count_super As Integer = 0
        Dim count_user As Integer = 0
        Dim query As New query

        Dim user As String = ""
        Dim password As String = ""

        user = Page.Request("user")
        password = Page.Request("pass")
        If user IsNot Nothing And password IsNot Nothing Then
            Session("username") = user
            Session("password") = password
        End If

        table_super = query.login_super_user(Session("username"), Session("password"))
        count_super = table_super.Count
        If count_super > 0 Then
            Session("login_ok") = True
            'Session("numeroRefresh") = 0
            Session("super_user") = True
            Session("strumento") = query.get_strumenti_super(Session("username"), Session("password"))
            Session("tabella_impianto") = query.get_impianto_super(Session("username"), Session("password"))
            For Each dc In table_super
                Session("mid_super") = dc.Id_super
                Exit For
            Next

            'manage_sidebar_left(Session("impianto"), tabella_strumento_container)
        Else
            Dim table_user As ermes_web_20.quey_db.userDataTable
            table_user = query.login_user(Session("username"), Session("password"))
            count_user = table_user.Count
            If count_user > 0 Then
                Session("login_ok") = True
                Session("super_user") = False
                'Session("numeroRefresh") = 0
                Session("strumento") = query.get_strumenti_user(Session("username"), Session("password"))
                Session("tabella_impianto") = query.get_impianto_user(Session("username"), Session("password"))
                'manage_sidebar_left(Session("impianto"), tabella_strumento_container)
                For Each dc In table_user
                    Session("mid_super") = dc.id_super
                    Session("mid_user") = dc.Id_user
                    Exit For
                Next

            Else
                'invalid login
                Response.Redirect("login.aspx?risultato_login=1")
            End If
        End If
        manage_sidebar_left(Session("strumento"), tabella_impianto_container)
        literal_theme.Text = Session("stile")


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim url_refresh As String = HttpContext.Current.Request.RawUrl
        'If InStr(url_refresh, "?") <> 0 Then
        '    url_refresh = Replace(url_refresh, "&refresh_auto=1", "")

        '    url_refresh = Replace(url_refresh, "refresh=1", "refresh=0")
        '    url_refresh = Replace(url_refresh, "result=1", "result=0")
        '    url_refresh = Replace(url_refresh, "result=2", "result=0")
        '    url_refresh = Replace(url_refresh, "result=3", "result=0")
        '    url_refresh = change_parameters(url_refresh, "pagina", "0")
        '    If InStr(url_refresh, "?refresh") <> 0 Then
        '        auto_refresh.Text = "<meta http-equiv='refresh' content='480;url=" + url_refresh + "'/>"
        '    Else
        '        auto_refresh.Text = "<meta http-equiv='refresh' content='480;url=" + url_refresh + "&refresh_auto=1'/>"
        '    End If

        'Else
        '    url_refresh = Replace(url_refresh, "?refresh_auto=1", "")
        '    url_refresh = Replace(url_refresh, "refresh=1", "refresh=0")
        '    url_refresh = Replace(url_refresh, "result=1", "result=0")
        '    url_refresh = Replace(url_refresh, "result=2", "result=0")
        '    url_refresh = Replace(url_refresh, "result=3", "result=0")
        '    url_refresh = change_parameters(url_refresh, "pagina", "0")
        '    auto_refresh.Text = "<meta http-equiv='refresh' content='480;url=" + url_refresh + "?refresh_auto=1'/>"
        'End If
        Dim refresh_auto As String = ""
        Dim user As String = ""
        Dim password As String = ""

        user = Page.Request("user")
        password = Page.Request("pass")
        If user IsNot Nothing And password IsNot Nothing Then
            Session("username") = user
            Session("password") = password
            Session("login_ok") = True
            Session("numeroRefresh") = 0
        End If
        refresh_auto = Page.Request("refresh_auto")

        If (Session("login_ok") = False) Then
            If Session("username") = "" And Session("password") = "" Then
                Response.Redirect("login.aspx")
            Else
                If Not IsPostBack Then
                    'gestione connsessione login
                    create_master_page()

                End If

            End If
        Else
            'If (refresh_auto = "1") Then
            create_master_page()
            'End If
            literal_theme.Text = Session("stile")
            manage_sidebar_left(Session("strumento"), tabella_impianto_container)
        End If
        manage_sidebar_top()
        '       footer_script.Text = "<div class='clearfix'></div>"
        '        footer_script.Text = footer_script.Text + "<div id='footer' class='hidden-print'>"
        '      footer_script.Text = footer_script.Text + "<div class='copy' style='text-align:right;'>powered by ERMES | ERMES is a software by <a href='http://www.emec.it' target='_blank'>EMEC S.r.l.</a> - Current version: v1.4 </div></div>"


    End Sub
    Public Sub manage_sidebar_top()
        Literal2.Text = "<div class=""navbar main hidden-print"">"
        Literal2.Text = Literal2.Text + "<a href="""" class=""appbrand"">"
        'Literal2.Text = Literal2.Text + "<img src=""image/logo_ermes.png"" alt=""logo"">"
        Literal2.Text = Literal2.Text + Session("logo")
        literal_stefano.Text = Session("personalizzazioneStefano")

        Literal2.Text = Literal2.Text + " </a>"
        Literal2.Text = Literal2.Text + "<button type=""button"" class=""btn btn-navbar"" style=""top:20px;"">"

        Literal2.Text = Literal2.Text + "<span class=""icon-bar""></span><span class=""icon-bar""></span><span class=""icon-bar""></span>"
        Literal2.Text = Literal2.Text + "</button>"




        Literal2.Text = Literal2.Text + "<ul class=""topnav pull-right"">"


        Literal2.Text = Literal2.Text + "<li class=""hidden-phone"" id=""lang_nav"">"

        Select Case Session("selectedLanguage")
            Case "en"
                Literal2.Text = Literal2.Text + "<a href=""#"" data-toggle=""dropdown""><img src=""theme/images/lang/en.png"" alt=""en""/></a>"
                Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-left"">"
                Literal2.Text = Literal2.Text + "<li class=""active""><a href=""#"" title=""English""><img src=""theme/images/lang/en.png"" alt=""English""> English</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=it"" title=""Italian""><img src=""theme/images/lang/it.png"" alt=""Italian""> Italian</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=de"" title=""Deutsch""><img src=""theme/images/lang/de.png"" alt=""Deutsch""> Deutsch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='French'><img src='theme/images/lang/fr.png' alt='French'> French</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Spanish</a></li>"

            Case "it"
                Literal2.Text = Literal2.Text + "<a href=""#"" data-toggle=""dropdown""><img src=""theme/images/lang/it.png"" alt=""it""/></a>"
                Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-left"">"
                Literal2.Text = Literal2.Text + "<li class=""active""><a href=""#"" title=""Italiano""><img src=""theme/images/lang/it.png"" alt=""Italiano""> Italiano</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=de"" title=""Tedesco""><img src=""theme/images/lang/de.png"" alt=""Tedesco""> Tedesco</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=en"" title=""Inglese""><img src=""theme/images/lang/en.png"" alt=""Inglese""> Inglese</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='Francese'><img src='theme/images/lang/fr.png' alt='Francese'> Francese</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Spagnolo</a></li>"

            Case "de"
                Literal2.Text = Literal2.Text + "<a href=""#"" data-toggle=""dropdown""><img src=""theme/images/lang/de.png"" alt=""de""/></a>"
                Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-left"">"
                Literal2.Text = Literal2.Text + "<li class=""active""><a href=""#"" title=""Deutsch""><img src=""theme/images/lang/de.png"" alt=""Deutsch""> Deutsch</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=it"" title=""Italienisch""><img src=""theme/images/lang/it.png"" alt=""Italienisch""> Italienisch</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=en"" title=""Englisch""><img src=""theme/images/lang/en.png"" alt=""Englisch""> Englisch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='Französisch'><img src='theme/images/lang/fr.png' alt='Französisch'> Französisch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Spanisch</a></li>"
            Case "fr"
                Literal2.Text = Literal2.Text + "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/fr.png' alt='fr' /></a>"
                Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-left"">"
                Literal2.Text = Literal2.Text + "<li class='active'><a href='login.aspx?lang=fr' title='Français'><img src='theme/images/lang/fr.png' alt='Français'> Français</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italien'><img src='theme/images/lang/it.png' alt='Italien'> Italien</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Anglais'><img src='theme/images/lang/en.png' alt='Anglais'> Anglais</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Allemand'><img src='theme/images/lang/de.png' alt='Allemand'> Allemand</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Espagnol</a></li>"

            Case "pl"
                Literal2.Text = Literal2.Text + "<a href=""#"" data-toggle=""dropdown""><img src=""theme/images/lang/pl.png"" alt=""pl""/></a>"
                Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-left"">"
                Literal2.Text = Literal2.Text + "<li class=""active""><a href=""#"" title=""Polish""><img src=""theme/images/lang/en.png"" alt=""Polish""> Polish</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=it"" title=""Italian""><img src=""theme/images/lang/it.png"" alt=""Italian""> Italian</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=de"" title=""Deutsch""><img src=""theme/images/lang/de.png"" alt=""Deutsch""> Deutsch</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='French'><img src='theme/images/lang/fr.png' alt='French'> French</a></li>"
                Literal2.Text = Literal2.Text + "<li><a href=""login.aspx?lang=en"" title=""English""><img src=""theme/images/lang/en.png"" alt=""English""> English</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=es' title='Spanish'><img src='theme/images/lang/ES.png' alt='Spanish'> Hiszpański</a></li>"
            Case "es"
                Literal2.Text = Literal2.Text + "<a href='#' data-toggle='dropdown'><img src='theme/images/lang/ES.png' alt='es' /></a>"
                Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-left"">"
                Literal2.Text = Literal2.Text + "<li class=""active""><a href=""#"" title=""Polish""><img src=""theme/images/lang/ES.png"" alt=""Polish""> español</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=pl' title='Polish'><img src='theme/images/lang/pl.png' alt='Polish'> Polaco</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=it' title='Italian'><img src='theme/images/lang/it.png' alt='Italian'> Italiano</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=de' title='Deutsch'><img src='theme/images/lang/de.png' alt='Deutsch'> Alemán</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=fr' title='French'><img src='theme/images/lang/fr.png' alt='French'> Francés</a></li>"
                Literal2.Text = Literal2.Text + "<li ><a href='login.aspx?lang=en' title='Inglese'><img src='theme/images/lang/en.png' alt='English'> Inglés</a></li>"

        End Select
        Literal2.Text = Literal2.Text + "</ul>"
        Literal2.Text = Literal2.Text + "</li>"


        Literal2.Text = Literal2.Text + "<li class=""hidden-phone"">"
        Literal2.Text = Literal2.Text + "<a href=""communication.aspx"" data-toggle=""collapse"" data-target=""#"" class=""glyphicons notes""><i></i><p class =""testo"">" + GetGlobalResourceObject("main_master_global", "communication") + "</p></a>"
        'Literal2.Text = Literal2.Text + "<ul class=""dropdown-menu pull-right"">"

        'Literal2.Text = Literal2.Text + "<li class=""dropdown submenu"">"


        'Literal2.Text = Literal2.Text + "<li><a href=""drag_usb_log.aspx"">Upload File</a></li>"
        'Literal2.Text = Literal2.Text + "<li><a href=""log_usb_list.aspx"">Latest Log</a></li>"

        ' Literal2.Text = Literal2.Text + "</ul>"
        Literal2.Text = Literal2.Text + "</li>"

        Literal2.Text = Literal2.Text + "<li class=""dropdown visible-abc"">"
        If Session("super_user") Then
            Literal2.Text = Literal2.Text + "<a href="""" data-toggle=""dropdown"" class=""glyphicons cogwheel""><i></i><p class =""testo"">" + GetGlobalResourceObject("main_master_global", "impianti") + "</p><span class=""caret""></span></a>"
            Literal2.Text = Literal2.Text + "<ul style=""width:100px"" class=""dropdown-menu pull-left"">"

            Literal2.Text = Literal2.Text + "<li class=""dropdown submenu"">"


            Literal2.Text = Literal2.Text + "<li><a href=""addimpianto.aspx"">" + GetGlobalResourceObject("main_master_global", "aggiungi") + "</a></li>"
            Literal2.Text = Literal2.Text + "<li><a href=""modifica_impianto.aspx"">" + GetGlobalResourceObject("main_master_global", "modifica") + "</a></li>"
            Literal2.Text = Literal2.Text + "<li><a href=""eliminaimpianto.aspx"">" + GetGlobalResourceObject("main_master_global", "elimina") + "</a></li>"
            Literal2.Text = Literal2.Text + "<li><a href=""eliminaController.aspx"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a></li>"

            Literal2.Text = Literal2.Text + "</ul>"
            Literal2.Text = Literal2.Text + "</li>"

            Literal2.Text = Literal2.Text + "<li class=""dropdown visible-abc"">"
            Literal2.Text = Literal2.Text + "<a href="""" data-toggle=""dropdown"" class=""glyphicons upload""><i></i> <p class =""testo"">" + GetGlobalResourceObject("main_master_global", "usbManager") + "</p><span class=""caret""></span></a>"
            Literal2.Text = Literal2.Text + "<ul style=""width:100px"" class=""dropdown-menu pull-left"">"

            Literal2.Text = Literal2.Text + "<li class=""dropdown submenu"">"


            Literal2.Text = Literal2.Text + "<li><a href=""drag_usb_log.aspx"">" + GetGlobalResourceObject("main_master_global", "uploadFile") + "</a></li>"
            Literal2.Text = Literal2.Text + "<li><a href=""log_usb_list.aspx"">" + GetGlobalResourceObject("main_master_global", "latestLog") + "</a></li>"
            'Literal2.Text = Literal2.Text + "<li><a href=""modifica_utilizzatore.aspx"">" + GetGlobalResourceObject("main_master_global", "modifica") + "</a></li>"
            'Literal2.Text = Literal2.Text + "<li><a href=""eliminautilizzatore.aspx"">" + GetGlobalResourceObject("main_master_global", "elimina") + "</a></li>"

            Literal2.Text = Literal2.Text + "</ul>"
            Literal2.Text = Literal2.Text + "</li>"


            Literal2.Text = Literal2.Text + "<li class=""dropdown visible-abc"">"
            Literal2.Text = Literal2.Text + "<a href="""" data-toggle=""dropdown"" class=""glyphicons user""><i></i><p class =""testo"">" + GetGlobalResourceObject("main_master_global", "utilizzatore") + "</p><span class=""caret""></span></a>"
            Literal2.Text = Literal2.Text + "<ul style=""width:100px"" class=""dropdown-menu pull-left"">"

            Literal2.Text = Literal2.Text + "<li class=""dropdown submenu"">"


            Literal2.Text = Literal2.Text + "<li><a href=""addutilizzatore.aspx"">" + GetGlobalResourceObject("main_master_global", "aggiungi") + "</a></li>"
            Literal2.Text = Literal2.Text + "<li><a href=""modifica_utilizzatore.aspx"">" + GetGlobalResourceObject("main_master_global", "modifica") + "</a></li>"
            Literal2.Text = Literal2.Text + "<li><a href=""eliminautilizzatore.aspx"">" + GetGlobalResourceObject("main_master_global", "elimina") + "</a></li>"

            Literal2.Text = Literal2.Text + "</ul>"
            Literal2.Text = Literal2.Text + "</li>"

        End If

        Literal2.Text = Literal2.Text + "<li class=""account"">"
        Literal2.Text = Literal2.Text + "<a data-toggle=""dropdown"" href="""" class=""glyphicons logout lock""><span class=""hidden-phone text"">" + Session("username") + "</span><i></i></a>"
        Literal2.Text = Literal2.Text + "<ul style=""width:100px"" class=""dropdown-menu pull-right"">"
        'Literal2.Text = Literal2.Text + "<li><a href="""" class=""glyphicons cogwheel"">" + GetGlobalResourceObject("main_master_global", "settings") + "<i></i></a></li>"

        'Literal2.Text = Literal2.Text + "<li><a href="""" class=""glyphicons camera"">My Photos<i></i></a></li>"

        Literal2.Text = Literal2.Text + "<li class=""highlight profile"">"
        Literal2.Text = Literal2.Text + "<span>"
        If Session("super_user") Then
            Literal2.Text = Literal2.Text + "<span class=""heading"">Profile <a href=""modifica_utente.aspx"" class=""pull-right"">" + GetGlobalResourceObject("main_master_global", "edit") + "</a></span>"
        End If
        Literal2.Text = Literal2.Text + "<span class=""img""></span>"
        Literal2.Text = Literal2.Text + " <span class=""details"">"
        Literal2.Text = Literal2.Text + "<a href="""">" + Session("username") + "</a>"

        Literal2.Text = Literal2.Text + "</span>"

        Literal2.Text = Literal2.Text + "<span class=""clearfix""></span>"
        Literal2.Text = Literal2.Text + "</span>"
        Literal2.Text = Literal2.Text + "</li>"
        Literal2.Text = Literal2.Text + "<li>"
        Literal2.Text = Literal2.Text + "<span>"
        Literal2.Text = Literal2.Text + "<a class=""btn btn-default btn-mini pull-right"" href=""session_destroy.aspx"">" + GetGlobalResourceObject("main_master_global", "signout") + "</a>"
        Literal2.Text = Literal2.Text + "</span>"
        Literal2.Text = Literal2.Text + "</li>"
        Literal2.Text = Literal2.Text + "</ul>"
        Literal2.Text = Literal2.Text + "</li>"


        Literal2.Text = Literal2.Text + "</ul>"


        Literal2.Text = Literal2.Text + "</div>"
    End Sub

    Public Sub manage_sidebar_left(ByVal tabella_strumento As ermes_web_20.quey_db.strumentiDataTable, ByVal tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable)
        Dim intestazione As String = ""
        Dim intestazione_1 As String = ""
        Dim href As String = ""
        Dim precedente_impianto As String = ""
        Dim first_time As Boolean = False
        Dim ultimo As Boolean = False
        Dim fine As String = ""
        Dim count_strumento As Integer = 0
        Dim count_strumento_disconnesso As Integer = 0
        Dim count_strumento_allarme As Integer = 0
        Dim count_impianto As Integer = 0
        Dim count_href As Integer = 0
        Dim listCenturio As New List(Of String)
        Dim indexListCenturio As Integer = 0
        listCenturio = Session("centurioList")
        If listCenturio IsNot Nothing Then
            indexListCenturio = listCenturio.Count
        End If

        intestazione = "<div id=""wrapper"">"
        intestazione = intestazione + "<div id=""menu"" class=""hidden-phone hidden-print"">"
        intestazione = intestazione + "<div class=""slim-scroll"" data-scroll-height=""800px"">"
        intestazione = intestazione + "<span class=""profile"">"
        'da modificare logo dashboard
        intestazione = intestazione + "<a class=""img"" href=""""><img src="""" alt="""" /></a>"
        intestazione = intestazione + "<span>"
        'da modificare logo dashboard
        intestazione = intestazione + "<strong>" + GetGlobalResourceObject("main_master_global", "welcome") + "</strong>"
        intestazione = intestazione + "<a href="""" class=""glyphicons right_arrow"">" + Session("username") + "<i></i></a>" +
                "</span></span>"
        intestazione = intestazione + "<ul id=""leftMenuCenturio"">" +
                "<li class=""glyphicons display active""><a href=""dashboardNew.aspx""><i></i><span>" + GetGlobalResourceObject("main_master_global", "dashboard") + "</span></a></li>"
        precedente_impianto = ""
        For Each dc In tabella_impianto.Rows
            Dim alarm_color As String = ""
            ultimo = False
            intestazione_1 = intestazione_1 + ""
            Dim stringa_temp_impianto_sup As String = ""
            Dim stringa_temp_subimpianto_inf As String = ""
            Dim split_impianto() As String = dc.nome_impianto.split(">")
            If precedente_impianto <> split_impianto(0) Then
                intestazione_1 = intestazione_1.Replace("xxxxzzzxxxm", "")
                If first_time Then
                    intestazione_1 = intestazione_1 + "</ul>"
                    If split_impianto.Length > 1 Then
                        intestazione_1 = intestazione_1 + "<span class =""count"">" + Str(count_impianto) + "</span>"
                    End If
                    intestazione_1 = intestazione_1 + "</li>"
                End If
                Dim stringa_temp_impianto As String = split_impianto(0)
                If stringa_temp_impianto.Length > 13 Then
                    stringa_temp_impianto = Mid(stringa_temp_impianto, 1, 13) + ".."
                End If
                stringa_temp_impianto_sup = stringa_temp_impianto
                intestazione_1 = intestazione_1 + "<li class=""hasSubmenu glyphicons cogwheels""> <a id=""" + stringa_temp_impianto + "_sup"" xxxxzzzxxxm data-toggle=""collapse"" href=""#menu_components_" + Format(count_href, "000") + """><i></i><span>" + stringa_temp_impianto + "</span></a>" +
                        "<ul class=""collapse"" id =""menu_components_" + Format(count_href, "000") + """ > "
                count_impianto = 0
                first_time = True
                precedente_impianto = split_impianto(0)
            End If
            ' Dim i As Integer = 0
            'For i = 0 To split_impianto.Length - 1
            If split_impianto.Length > 1 Then
                Dim stringa_temp_subimpianto As String = split_impianto(1)
                If stringa_temp_subimpianto.Length > 13 Then
                    stringa_temp_subimpianto = Mid(stringa_temp_subimpianto, 1, 13) + ".."
                End If
                stringa_temp_subimpianto_inf = stringa_temp_subimpianto
                intestazione_1 = intestazione_1 + "<li class=""hasSubmenu""> <a id=""" + stringa_temp_subimpianto + "_inf""  xxxxzzzxxx data-toggle=""collapse"" href=""" + "#menu_" + Format(count_href, "000") + """><span>" + stringa_temp_subimpianto + "</span></a>" +
                        "<ul class=""collapse""  id =""menu_" + Format(count_href, "000") + """ > "
            Else
                stringa_temp_subimpianto_inf = dc.identificativo
                intestazione_1 = intestazione_1 + "<li class=""hasSubmenu""> <a id=""" + dc.identificativo + "_inf""  xxxxzzzxxx data-toggle=""collapse"" href=""" + "#menu_" + Format(count_href, "000") + """><span>" + dc.identificativo + "</span></a>" +
                        "<ul class=""collapse"" id =""menu_" + Format(count_href, "000") + """ > "
            End If
            count_strumento = 0
            count_strumento_allarme = 0
            count_strumento_disconnesso = 0

            For Each dc1 In tabella_strumento
                Try
                    If dc1.codice = dc.identificativo Then
                        Dim label_485 As String = "-" + main_function.get_tipo_strumento(dc1.nome)
                        If label_485 = "-" Then
                            label_485 = ""
                        End If
                        If Not main_function.check_is_connected(dc1.data_aggiornamento) Then ' se non fa aggiornamento per oltre una ora lo considero disconnesso
                            count_strumento_disconnesso = count_strumento_disconnesso + 1
                        End If
                        Select Case dc1.tipo_strumento
                            Case "max5"
                                href = "max5.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_max5_alarm(dc1.value2) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "LD"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_ld_doppio_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                            Case "LDDT"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_lddt_doppio_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                            Case "LDMA"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=45&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_ldma_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "LDLG"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=58&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_ldma_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                            Case "LDS"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_lds_singolo_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "LD4"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_ld4_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "WD"
                                href = "wd.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_wd_alarm(dc1.value3, False) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "Tower"
                                href = "tower.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_tower_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "LDtower"
                                href = "ldtower.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_ldtower_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                            Case "WH"
                                href = "wd.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_wd_alarm(dc1.value3, True) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "LTB"
                                href = "ltb.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"

                                If main_function.check_ltb_alarm(dc1.value3, Val(main_function.get_version(dc1.nome))) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If
                            Case "LTA"
                                href = "lta.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_lta_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                            Case "LTU"
                                href = "lta.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_lta_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                            Case "LTD"
                                href = "lta.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + "$"
                                If main_function.check_lta_alarm(dc1.value3) Then
                                    count_strumento_allarme = count_strumento_allarme + 1
                                    alarm_color = "style=""color:red;"""
                                End If

                        End Select
                        If alarm_color <> "" Then
                            intestazione_1 = intestazione_1.Replace("xxxxzzzxxx", alarm_color)
                            intestazione_1 = intestazione_1.Replace("xxxxzzzxxx", alarm_color)
                            'Else
                            '    intestazione_1 = intestazione_1.Replace("xxxxzzzxxx", "")
                        End If
                        ' If dc.identificativo.Length < 17 Then
                        intestazione_1 = intestazione_1 + "<li  class=""""><a " + alarm_color + " href=""" + href + """><span>" + dc1.id_485 + "-" + main_function.get_tipo_strumento(dc1.tipo_strumento) + label_485 + "</span></a></li>"
                        'Else
                        '    intestazione_1 = intestazione_1 + "<li  class=""""><a " + alarm_color + " href=""" + href + """><span>" + dc.identificativo + "</span></a></li>"
                        'End If


                        alarm_color = ""
                        count_strumento = count_strumento + 1
                    End If

                Catch ex As Exception

                End Try

            Next
            If dc.identificativo.Length >= 17 Then
                'intestazione = intestazione + "<a href=""mainCenturio.aspx?serial=" + split_codice(indiceCodice) + "&codice=" + resultPipe + "&configuration=" + resultConfigurationInput + """ Class=""block"">"
                'http://www.ermes-server.com/mainCenturio.aspx?serial=18085480200000001&codice=MT03&configuration=5|1|2|11|13|
                If (listCenturio IsNot Nothing) Then
                    For Each hrefVal In listCenturio
                        If hrefVal.IndexOf(dc.identificativo) > 0 Then
                            href = hrefVal
                            Exit For
                        End If

                    Next
                    '    href = listCenturio.Item(indexListCenturio - 1)
                    'End If
                    'If indexListCenturio > 0 Then
                    '    indexListCenturio = indexListCenturio - 1
                    'End If
                End If
                intestazione_1 = intestazione_1 + "<li  class=""""><a sup=""" + stringa_temp_impianto_sup + """ inf=""" + stringa_temp_subimpianto_inf + """ id =""" + dc.identificativo + "_left"" " + alarm_color + " href=""" + href + """><span>" + dc.identificativo + "</span></a></li>"
                count_strumento = count_strumento + 1
            End If
            intestazione_1 = intestazione_1.Replace("xxxxzzzxxx", "")

            intestazione_1 = Replace(intestazione_1, "$", "&statistica=" + Str(count_strumento) + "," + Str(count_strumento_disconnesso) + "," + Str(count_strumento_allarme))
            intestazione_1 = intestazione_1 + "</ul>"
            intestazione_1 = intestazione_1 + "<span class=""count"">" + Str(count_strumento) + "</span>"
            'If i > 0 Then
            intestazione_1 = intestazione_1 + "</li>"
            ultimo = True
            'End If
            'Next
            count_impianto = count_impianto + 1
            count_href = count_href + 1
        Next
        If first_time Then
            intestazione_1 = intestazione_1 + "</ul>"
            If ultimo Then
                intestazione_1 = intestazione_1 + "<span class =""count"">" + Str(count_impianto) + "</span>"
            End If
            intestazione_1 = intestazione_1 + "</li>"
        Else ' non c'è nessun impianto
            If Session("super_user") Then
                intestazione_1 = "<li class=""hasSubmenu glyphicons circle_plus""><a data-toggle=""collapse"" href=""addimpianto.aspx?layout_type=fluid&amp;menu_position=menu-left&amp;style=style-dark""><i></i><span>" + GetGlobalResourceObject("main_master_global", "aggiungi_impianto") + "</span></a></li>"
            Else
                intestazione_1 = "<li class=""hasSubmenu glyphicons circle_plus""><a data-toggle=""collapse"" href=""#menu_components""><i></i><span>" + GetGlobalResourceObject("main_master_global", "nessun_impianto") + "</span></a></li>"
            End If

        End If



        fine = "</ul>"
        fine = fine + "<div class=""clearfix""></div>"
        fine = fine + "<div class=""separator bottom""></div>"
        fine = fine + "</div>"
        fine = fine + "</div>"
        intestazione_1 = intestazione_1.Replace("xxxxzzzxxx", "")
        Literal1.Text = intestazione + intestazione_1 + fine
        'Literal1.Text = Literal1.Text + ""
        'Literal1.Text = Literal1.Text + ""
        'Literal1.Text = Literal1.Text + ""

        Dim java_script_ch1_pulse_variable As java_script = New java_script
        Dim set_variable_javascript(26, 1) As String

        set_variable_javascript(0, 0) = "range"
        set_variable_javascript(0, 1) = "'" + GetGlobalResourceObject("javascript_global", "range") + "'"
        set_variable_javascript(1, 0) = "wrong_settings"
        set_variable_javascript(1, 1) = "'" + GetGlobalResourceObject("javascript_global", "wrong_settings") + "'"

        set_variable_javascript(2, 0) = "date_time_wrong"
        set_variable_javascript(2, 1) = "'" + GetGlobalResourceObject("javascript_global", "date_time_wrong") + "'"
        set_variable_javascript(3, 0) = "numeric_digit"
        set_variable_javascript(3, 1) = "'" + GetGlobalResourceObject("javascript_global", "numeric_digit") + "'"
        set_variable_javascript(4, 0) = "impianto_duplicato"
        set_variable_javascript(4, 1) = "'" + GetGlobalResourceObject("javascript_global", "impianto_duplicato") + "'"
        set_variable_javascript(5, 0) = "utilizzatore_duplicato"
        set_variable_javascript(5, 1) = "'" + GetGlobalResourceObject("javascript_global", "utilizzatore_duplicato") + "'"
        set_variable_javascript(6, 0) = "confirm_add"
        set_variable_javascript(6, 1) = "'" + GetGlobalResourceObject("javascript_global", "confirm_add") + "'"
        set_variable_javascript(7, 0) = "delete_plant"
        set_variable_javascript(7, 1) = "'" + GetGlobalResourceObject("javascript_global", "delete_plant") + "'"

        set_variable_javascript(8, 0) = "modify_plant"
        set_variable_javascript(8, 1) = "'" + GetGlobalResourceObject("javascript_global", "modify_plant") + "'"

        set_variable_javascript(9, 0) = "username"
        set_variable_javascript(9, 1) = "'" + GetGlobalResourceObject("javascript_global", "username") + "'"
        set_variable_javascript(10, 0) = "username_6"
        set_variable_javascript(10, 1) = "'" + GetGlobalResourceObject("javascript_global", "username_6") + "'"
        set_variable_javascript(11, 0) = "password"
        set_variable_javascript(11, 1) = "'" + GetGlobalResourceObject("javascript_global", "password") + "'"
        set_variable_javascript(12, 0) = "password_6"
        set_variable_javascript(12, 1) = "'" + GetGlobalResourceObject("javascript_global", "password_6") + "'"
        set_variable_javascript(13, 0) = "password_6_new"
        set_variable_javascript(13, 1) = "'" + GetGlobalResourceObject("javascript_global", "password_6_new") + "'"

        set_variable_javascript(14, 0) = "password_uguale"
        set_variable_javascript(14, 1) = "'" + GetGlobalResourceObject("javascript_global", "password_uguale") + "'"

        set_variable_javascript(15, 0) = "email"
        set_variable_javascript(15, 1) = "'" + GetGlobalResourceObject("javascript_global", "email") + "'"
        set_variable_javascript(16, 0) = "policy"
        set_variable_javascript(16, 1) = "'" + GetGlobalResourceObject("javascript_global", "policy") + "'"
        set_variable_javascript(17, 0) = "ok"
        set_variable_javascript(17, 1) = "'" + GetGlobalResourceObject("javascript_global", "ok") + "'"
        set_variable_javascript(18, 0) = "annulla_impianto"
        set_variable_javascript(18, 1) = "'" + GetGlobalResourceObject("javascript_global", "annulla_impianto") + "'"


        set_variable_javascript(19, 0) = "cancel"
        set_variable_javascript(19, 1) = "'" + GetGlobalResourceObject("javascript_global", "cancel") + "'"
        set_variable_javascript(20, 0) = "required"
        set_variable_javascript(20, 1) = "'" + GetGlobalResourceObject("javascript_global", "required") + "'"
        set_variable_javascript(21, 0) = "invalid_mail_format"
        set_variable_javascript(21, 1) = "'" + GetGlobalResourceObject("javascript_global", "invalid_mail_format") + "'"
        set_variable_javascript(22, 0) = "wrong_old_password"
        set_variable_javascript(22, 1) = "'" + GetGlobalResourceObject("javascript_global", "wrong_old_password") + "'"
        set_variable_javascript(23, 0) = "delete_user"
        set_variable_javascript(23, 1) = "'" + GetGlobalResourceObject("javascript_global", "delete_user") + "'"

        set_variable_javascript(24, 0) = "confirm_add_user"
        set_variable_javascript(24, 1) = "'" + GetGlobalResourceObject("javascript_global", "confirm_add_user") + "'"

        set_variable_javascript(25, 0) = "confirm_modify_user"
        set_variable_javascript(25, 1) = "'" + GetGlobalResourceObject("javascript_global", "confirm_modify_user") + "'"

        set_variable_javascript(26, 0) = "delete_controller"
        set_variable_javascript(26, 1) = "'" + GetGlobalResourceObject("javascript_global", "delete_controller") + "'"


        js_variable.Text = "<script>"
        js_variable.Text = js_variable.Text + "modify_plant_ok='" + GetGlobalResourceObject("javascript_global", "modify_plant_ok") + "';"
        js_variable.Text = js_variable.Text + "modify_plant_error='" + GetGlobalResourceObject("javascript_global", "modify_plant_error") + "';"
        js_variable.Text = js_variable.Text + "modify_account_ok='" + GetGlobalResourceObject("javascript_global", "modify_account_ok") + "';"
        js_variable.Text = js_variable.Text + "modify_account_error='" + GetGlobalResourceObject("javascript_global", "modify_account_error") + "';"
        js_variable.Text = js_variable.Text + "elimina_impianto_ok='" + GetGlobalResourceObject("javascript_global", "elimina_impianto_ok") + "';"
        js_variable.Text = js_variable.Text + "elimina_impianto_error='" + GetGlobalResourceObject("javascript_global", "elimina_impianto_error") + "';"
        js_variable.Text = js_variable.Text + "elimina_user_ok='" + GetGlobalResourceObject("javascript_global", "elimina_user_ok") + "';"
        js_variable.Text = js_variable.Text + "elimina_user_error='" + GetGlobalResourceObject("javascript_global", "elimina_user_error") + "';"

        js_variable.Text = js_variable.Text + "add_account_ok='" + GetGlobalResourceObject("javascript_global", "add_account_ok") + "';"
        js_variable.Text = js_variable.Text + "add_account_error='" + GetGlobalResourceObject("javascript_global", "add_account_error") + "';"
        js_variable.Text = js_variable.Text + "utilizzatore_duplicato='" + GetGlobalResourceObject("javascript_global", "utilizzatore_duplicato") + "';"

        js_variable.Text = js_variable.Text + "user_setpoint_disable='" + GetGlobalResourceObject("javascript_global", "user_setpoint_disable") + "';"

        js_variable.Text = js_variable.Text + "impianto_descrizione_place='" + GetGlobalResourceObject("javascript_global", "impianto_descrizione_place") + "';"



        js_variable.Text = js_variable.Text + "server_error='" + GetGlobalResourceObject("javascript_global", "server_error") + "';"
        js_variable.Text = js_variable.Text + "</script>"

        java_script_ch1_pulse_variable.set_url_setpoint(Page, set_variable_javascript, 26)
    End Sub
    'Public Function GetCurrentPageName() As String
    '    Dim sPath As String = Request.Url.AbsolutePath
    '    Dim oInfo As System.IO.FileInfo = New System.IO.FileInfo(sPath)
    '    Dim sRet As String = oInfo.Name
    '    Return sRet
    'End Function
    Public Function change_parameters(ByVal url_parameters As String, ByVal paramter_change As String, ByVal parameters_value As String) As String
        Dim split_string() As String = url_parameters.Split("&")
        Dim final_string As String = ""
        Dim i As Integer
        For Each item_array In split_string
            i = i + 1
            If InStr(item_array, paramter_change) <> 0 Then
                item_array = paramter_change + "=" + parameters_value
            End If
            If i = split_string.Length Then
                final_string = final_string + item_array
            Else
                final_string = final_string + item_array + "&"
            End If

        Next
        Return final_string
    End Function


End Class