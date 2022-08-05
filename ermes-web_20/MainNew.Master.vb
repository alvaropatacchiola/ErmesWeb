Partial Public Class MainNew
    Inherits System.Web.UI.MasterPage
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
    Public Property pageTitleValue() As String
        Get
            Return pageTitleText.Text
        End Get
        Set(value As String)
            pageTitleText.Text = value
        End Set
    End Property
    Public Shared ReadOnly lingue() As String = {"gb", "it", "de", "fr", "pl", "es"}
    Public Shared ReadOnly lingueEsteso() As String = {"English", "Italiano", "Deutsch", "Français", "Polish", "Español"}
    Public Sub setTitle(ByVal titleString As String)
        pagetitle.Text = titleString
    End Sub
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
        'get logo e colori
        table_super = query.login_super_user_Personalizzazione(Session("mid_super"))
        scriptColor.Text = "<script>"
        For Each dc In table_super
            logoAssents.Text = "<img src=""" + ResolveUrl("~/") + "assets/img/" + dc.logo + """ alt=""Mono"">"
            scriptColor.Text = scriptColor.Text + "$("".left-sidebar"").css({backgroundColor:""" + dc.colorSide + """});"
            scriptColor.Text = scriptColor.Text + "$(""body"").css({backgroundColor:""" + dc.colorBody + """});"

            'scriptColor.Text = scriptColor.Text + "$(""a"").css({color:""" + dc.colorPrimary + """});"
            scriptColor.Text = scriptColor.Text + "$("".btn-primary"").css({backgroundColor:""" + dc.colorPrimary + """});"
            scriptColor.Text = scriptColor.Text + "$("".sidebar-footer-content"").css({backgroundColor:""" + dc.colorPrimary + """});"
            scriptColor.Text = scriptColor.Text + "$("".btn-primary"").css({borderColor:""" + dc.colorPrimary + """});"

            scriptColor.Text = scriptColor.Text + "$("".sidebar .sidebar-inner > li > a"").css({color: """ + dc.colorLink + """});"

            brandName.Text = Replace(dc.aziendaPersonalizzazione, " ", "")
            Exit For
        Next

        scriptColor.Text = scriptColor.Text + "</script>"
        manage_sidebar_left(Session("strumento"), tabella_impianto_container)
        'literal_theme.Text = Session("stile") per la personalizzazione del tema da rivedere


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
            'literal_theme.Text = Session("stile") per la personalizzazione del tema da rivedere
            manage_sidebar_left(Session("strumento"), tabella_impianto_container)
        End If
        manage_sidebar_top()
    End Sub
    Public Sub manage_sidebar_top()
        'creazione menu comunicazioni
        Dim comunicazioni_arrayG() As String

        Dim comunicazioniHTML As String = ""

        comunicazioni_arrayG = GetGlobalResourceObject("communication_g", "ultimeNew").Split("&")

        If comunicazioni_arrayG.Length > 0 Then
            comunicazioniAlert.Text = "<span Class=""badge badge-xs rounded-circle"">" + comunicazioni_arrayG.Length.ToString + "</span>"
        End If



        For Each elementComunicazione In comunicazioni_arrayG
            Dim comunicazioni_array() As String = elementComunicazione.Split("|")
            comunicazioniHTML = comunicazioniHTML + "<div Class=""media media-sm p-4 mb-0"">"
            comunicazioniHTML = comunicazioniHTML + "<div Class=""media-body"">"
            comunicazioniHTML = comunicazioniHTML + "<a href=""communicationAssets.aspx"">"
            comunicazioniHTML = comunicazioniHTML + "<span Class=""title mb-0"">" + comunicazioni_array(1) + "</span>"
            comunicazioniHTML = comunicazioniHTML + "<span Class=""discribe"">" + comunicazioni_array(2) + "</span>"
            comunicazioniHTML = comunicazioniHTML + "<span Class=""time""><time>" + comunicazioni_array(0) + "</time>...</span>"
            comunicazioniHTML = comunicazioniHTML + "</a></div></div>"
        Next
        listCommunication.Text = comunicazioniHTML

        'account settings
        usernameValue.Text = Session("username")
        If Session("super_user") Then ' getione della possibilità di modificare le impostazionia ccount
            accountSettings.Text = "<li><a Class=""dropdown-link-item"" href=""" + ResolveUrl("~/") + "settings.aspx"" > <i Class=""mdi mdi-account-outline""></i><span Class=""nav-text"">" + GetGlobalResourceObject("main_master_global", "edit") + "</span></a></li>"
        End If
        sessionDestroy.Text = "<a Class=""dropdown-link-item"" href=""" + ResolveUrl("~/") + "session_destroy.aspx""> <i class=""mdi mdi-logout""></i>" + GetGlobalResourceObject("main_master_global", "signout") + "</a>"

        'utilizzatore
        comunicazioniHTML = ""
        comunicazioniHTML = comunicazioniHTML + "<h2>" + GetGlobalResourceObject("main_master_global", "utilizzatore") + "</h2>"
        comunicazioniHTML = comunicazioniHTML + "<a href = """ + ResolveUrl("~/") + "utilizzatore.aspx?new=1"" Class=""btn btn-primary btn-pill px-4"">" + GetGlobalResourceObject("main_master_global", "aggiungi") + "</a>"
        utilizzatoreAggiungi.Text = comunicazioniHTML

        comunicazioniHTML = "<div class=""card-body"">"
        'If Not IsPostBack Then
        Dim table_user As ermes_web_20.quey_db.userDataTable = New ermes_web_20.quey_db.userDataTable
            Dim query As New query
            table_user = query.get_user_to_super(id_super_container)
            For Each dc In table_user
                Dim lista_impianti_user As ermes_web_20.quey_db.impianto_newDataTable = New ermes_web_20.quey_db.impianto_newDataTable
                lista_impianti_user = query.get_lista_impianti_user(dc.Id_user.ToString)
                If (dc.nome.Length > 10) Then
                    comunicazioniHTML = comunicazioniHTML + " <div Class=""media media-sm""><div Class=""media-body""><a href=""" + ResolveUrl("~/") + "utilizzatore.aspx?username=" + dc.username + "&password=" + dc.password + "&utilizzatore=" + dc.nome + "&codice=" + dc.Id_user.ToString + """ > <span class=""title"">" + Mid(dc.nome, 1, 8) + "..</span>"
                Else
                    comunicazioniHTML = comunicazioniHTML + " <div Class=""media media-sm""><div Class=""media-body""><a href=""" + ResolveUrl("~/") + "utilizzatore.aspx?username=" + dc.username + "&password=" + dc.password + "&utilizzatore=" + dc.nome + "&codice=" + dc.Id_user.ToString + """ > <span class=""title"">" + dc.nome + "</span>"
                End If

                'comunicazioniHTML = comunicazioniHTML + "<a href = ""user-profile.html"" > " '' da modificare
                comunicazioniHTML = comunicazioniHTML + "<span>" + GetGlobalResourceObject("main_master_global", "utilizzatore") + "</span>"
                For Each dc2 In lista_impianti_user
                    '<span> Administrator</span>
                Next
                comunicazioniHTML = comunicazioniHTML + "</a></div>"
                comunicazioniHTML = comunicazioniHTML + "<div Class=""media-close""><button type=""button"" code=""" + dc.Id_user.ToString + """ class=""mb-1 btn btn-danger delete_utilizzatore"">"
                comunicazioniHTML = comunicazioniHTML + "<i Class="" mdi mdi-trash-can mr-1""></i>"
                'comunicazioniHTML = comunicazioniHTML + "</button></div> </div>"
                comunicazioniHTML = comunicazioniHTML + "</button></div><div class=""media-close""><a href=""" + ResolveUrl("~/") + "utilizzatore.aspx?username=" + dc.username + "&password=" + dc.password + "&utilizzatore=" + dc.nome + "&codice=" + dc.Id_user.ToString + """><button type=""button"" class=""mb-1 btn btn-warning""><i class="" mdi mdi-settings mr-1""></i></button></a></div> </div>"
            Next
            comunicazioniHTML = comunicazioniHTML + "</div>"
            utilizzatoreList.Text = comunicazioniHTML
            'impianti
            comunicazioniHTML = "<h2>" + GetGlobalResourceObject("main_master_global", "impianti") + "</h2>"
            comunicazioniHTML = comunicazioniHTML + "<a href = """ + ResolveUrl("~/") + "plant.aspx?new=1"" Class=""btn btn-primary btn-pill px-4"">" + GetGlobalResourceObject("main_master_global", "aggiungi") + "</a>"
            impiantoAggiungi.Text = comunicazioniHTML

            comunicazioniHTML = "<div class=""card-body"">"
            Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
            tabella_impianto = tabella_impianto_container

            For Each dc In tabella_impianto
                Dim split_impianto() As String = dc.nome_impianto.Split(">")
                Dim stringaFinale As String = ""
                comunicazioniHTML = comunicazioniHTML + " <div Class=""media media-sm""><div Class=""media-body""><a href = """ + ResolveUrl("~/") + "plant.aspx?codice=" + dc.identificativo + """ > <span class=""title"">" + dc.identificativo + "</span>"

                If (split_impianto(0).Length > 10) Then
                    stringaFinale = stringaFinale + Mid(split_impianto(0), 1, 8) + ".."
                Else
                    stringaFinale = stringaFinale + split_impianto(0)
                End If
                stringaFinale = stringaFinale + " - "
                If (split_impianto(1).Length > 10) Then
                    stringaFinale = stringaFinale + Mid(split_impianto(1), 1, 8) + ".."
                Else
                    stringaFinale = stringaFinale + split_impianto(1)
                End If

                comunicazioniHTML = comunicazioniHTML + "<span>" + stringaFinale + "</span>"

                comunicazioniHTML = comunicazioniHTML + "</a></div>"
                comunicazioniHTML = comunicazioniHTML + "<div Class=""media-close""><button type=""button"" code=""" + dc.identificativo + """ class=""mb-1 btn btn-danger delete_plant"">"
                comunicazioniHTML = comunicazioniHTML + "<i Class="" mdi mdi-trash-can mr-1""></i>"
                comunicazioniHTML = comunicazioniHTML + "</button></div><div class=""media-close""><a href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + dc.identificativo + """><button type=""button"" class=""mb-1 btn btn-warning""><i class="" mdi mdi-settings mr-1""></i></button></a></div> </div>"
            Next
            comunicazioniHTML = comunicazioniHTML + "</div>"
            impiantoList.Text = comunicazioniHTML

            'lingua list
            comunicazioniHTML = "<div class=""card-body"">"
            Dim indiceLingua As Integer = 0
            For Each elementlingua In lingue
                comunicazioniHTML = comunicazioniHTML + "<div class=""media language-sm"">"
                comunicazioniHTML = comunicazioniHTML + "<div Class=""language-sm-wrapper"">"
                comunicazioniHTML = comunicazioniHTML + "<a href = ""user-profile.html"" >"
                comunicazioniHTML = comunicazioniHTML + "<i Class=""flag-icon flag-icon-" + elementlingua + " h1"" title=""" + elementlingua + """ id=""" + elementlingua + """></i>"
                comunicazioniHTML = comunicazioniHTML + "</a></div>"
                comunicazioniHTML = comunicazioniHTML + "<div Class="" language-body"">"
                If elementlingua = "gb" Then
                    comunicazioniHTML = comunicazioniHTML + "<a href=""" + ResolveUrl("~/") + "language.aspx?lang=en"">"
                Else
                    comunicazioniHTML = comunicazioniHTML + "<a href=""" + ResolveUrl("~/") + "language.aspx?lang=" + elementlingua + """>"
                End If

                comunicazioniHTML = comunicazioniHTML + "<span class="" title"">" + lingueEsteso(indiceLingua) + "</span>"
                comunicazioniHTML = comunicazioniHTML + "</a></div>"
                comunicazioniHTML = comunicazioniHTML + "</div>"
                indiceLingua = indiceLingua + 1
            Next
            comunicazioniHTML = comunicazioniHTML + "</div>"
            languageList.Text = comunicazioniHTML

            If Session("super_user") Then
                enableModificaImpianti.Visible = True
                enableModificaUtilizzatore.Visible = True
                enableModificaTema.Visible = True
            Else
                enableModificaImpianti.Visible = False
                enableModificaUtilizzatore.Visible = False
                enableModificaTema.Visible = False
            End If

        'End If
    End Sub
    Public Sub manage_sidebar_left(ByVal tabella_strumento As ermes_web_20.quey_db.strumentiDataTable, ByVal tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable)
        Dim intestazione As String = ""
        Dim intestazione_1 As String = ""
        Dim listCenturio As New List(Of String)
        Dim indexListCenturio As Integer = 0

        Dim precedente_impianto As String = ""
        Dim first_time As Boolean = False
        Dim count_href As Integer = 0
        Dim count_hrefSUB As Integer = 0
        Dim href As String = ""

        listCenturio = Session("centurioList")

        'traduzioni
        mainDashboard.Text = GetGlobalResourceObject("main_master_global", "dashboard")
        mainPlants.Text = GetGlobalResourceObject("main_master_global", "impianti")
        mainDocumentation.Text = GetGlobalResourceObject("main_master_global", "documentation")
        gettingDashboard.Text = GetGlobalResourceObject("main_master_global", "gettingDashboard")
        dashboardComm.Text = GetGlobalResourceObject("main_master_global", "communication")


        If listCenturio IsNot Nothing Then
            indexListCenturio = listCenturio.Count
        End If
        For Each dc In tabella_impianto.Rows
            Dim split_impianto() As String = dc.nome_impianto.split(">")
            If precedente_impianto <> split_impianto(0) Then
                If first_time Then
                    intestazione = intestazione + "</ul>"
                End If
                count_href = count_href + 1
                intestazione = intestazione + "<li  Class=""has-Sub"" >"
                intestazione = intestazione + "<a Class=""sidenav-item-link"" href=""javascript:void(0)"" data-toggle=""collapse"" data-target=""#plant" + count_href.ToString + """ aria-expanded=""false"" aria-controls=""plant" + count_href.ToString + """>"
                intestazione = intestazione + "<i Class=""mdi mdi-network""></i>"
                intestazione = intestazione + "<span Class=""nav-text"">" + split_impianto(0) + "</span> <b class=""caret""></b>"
                intestazione = intestazione + "</a>"
                intestazione = intestazione + "<ul  Class=""collapse ""  id=""plant" + count_href.ToString + """ data-parent=""#plant" + count_href.ToString + "_" + count_hrefSUB.ToString + """ >"
                'End If
                first_time = True
                precedente_impianto = split_impianto(0)

                count_hrefSUB = 0
            End If
            intestazione = intestazione + "<div Class=""sub-menu"">"
            intestazione = intestazione + "<li  Class=""has-sub"" >"
            Dim stringa_temp_subimpianto As String = ""
            If split_impianto.Length > 1 Then
                stringa_temp_subimpianto = split_impianto(1)
            Else
                stringa_temp_subimpianto = dc.identificativo
            End If
            intestazione = intestazione + "<a Class=""sidenav-item-link"" href=""javascript:void(0)"" data-toggle=""collapse"" data-target=""#plant" + count_href.ToString + "_" + count_hrefSUB.ToString + """  aria-expanded=""false"" aria-controls=""plant" + count_href.ToString + "_" + (count_hrefSUB + 1).ToString + """><span Class=""nav-text"">" + stringa_temp_subimpianto + " </span> <b class=""caret""></b></a>"
            intestazione = intestazione + "<ul  Class=""collapse""  id=""plant" + count_href.ToString + "_" + count_hrefSUB.ToString + """>"
            intestazione = intestazione + "<div Class=""sub-menu"">"
            For Each dc1 In tabella_strumento
                Try
                    If dc1.codice = dc.identificativo Then
                        Dim label_485 As String = "-" + main_function.get_tipo_strumento(dc1.nome)
                        If label_485 = "-" Then
                            label_485 = ""
                        End If
                        Select Case dc1.tipo_strumento
                            Case "max5"
                                href = "max5.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LD"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LDDT"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LDMA"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=45&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LDLG"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=58&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LDS"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LD4"
                                href = "ld.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "WD"
                                href = "wd.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "Tower"
                                href = "tower.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LDtower"
                                href = "ldtower.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "WH"
                                href = "wd.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LTB"
                                href = "ltb.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LTA"
                                href = "lta.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LTU"
                                href = "lta.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                            Case "LTD"
                                href = "lta.aspx?codice=" + dc1.codice + "&id_485=" + dc1.id_485 + "&pagina=0&result=0&nome_impianto=" + split_impianto(0) + ""
                        End Select
                        intestazione = intestazione + "<li ><a href=""" + href + """>" + dc1.id_485 + " - " + main_function.get_tipo_strumento(dc1.tipo_strumento) + label_485 + "</a></li>"
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
                If dc.Expr2 = 0 Then ' centurio
                    intestazione = intestazione + "<li ><a id =""" + dc.identificativo + "_left"" href=""" + href + """>" + dc.identificativo + "</a></li>"
                End If
                If dc.Expr2 = 1 Then ' pompe
                    intestazione = intestazione + "<li ><a id =""" + dc.identificativo + "_pumpLeft"" href=""#"">" + dc.identificativo + "</a></li>"
                End If



            End If

            intestazione = intestazione + "</div>"
            intestazione = intestazione + "</ul>"
            intestazione = intestazione + "</li>"

            intestazione = intestazione + "</div>"
            'intestazione = intestazione + "</ul>"




            count_hrefSUB = count_hrefSUB + 1
        Next
        If first_time Then
            intestazione = intestazione + "</ul>"
        End If


        menuLeftScript.Text = intestazione


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
        java_script_ch1_pulse_variable.set_url_setpoint(Page, set_variable_javascript, 26)

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

        '  				  <!-- POMPE 1-->
        '        <li  Class="has-sub" >
        '              <a Class="sidenav-item-link" href="javascript:void(0)" data-toggle="collapse" data-target="#plant01"
        '                aria-expanded="false" aria-controls="plant01">


        '                <i Class="mdi mdi-network"></i>
        '<span Class="nav-text">5400<span class="little">ml/h</span></span></span> <b class="caret"></b>
        '              </a>

        '              <ul  Class="collapse "  id="plant01"
        '                data-parent="#plant01_1">
        '                <div Class="sub-menu">

        '                  <li  Class="has-sub" >
        '                    <a Class="sidenav-item-link" href="javascript:void(0)" data-toggle="collapse" data-target="#plant01_1"
        '                      aria-expanded="false" aria-controls="plant01_2">
        '                      <span Class="nav-text">Prisma 1 </span> <b class="caret"></b>
        '                    </a>
        '                    <ul  Class="collapse"  id="plant01_1">
        '                      <div Class="sub-menu">

        '                        <li>
        '                                          <a href = "plant.html" > 1 prova</a>
        '                        </li>

        '                        <li>
        '                                          <a href = "plant.html" > 2 prova</a>
        '                        </li>

        '                        <li>
        '                                          <a href = "plant.html" > 3 prova</a>
        '                        </li>

        '                      </div>
        '                    </ul>
        '                  </li>







        '                </div>
        '              </ul>
        '            </li>
    End Sub

    Protected Sub eliminaImpianto_Click(sender As Object, e As EventArgs) Handles eliminaImpianto.Click
        Dim codice_impianto As String = ""
        'btn.CommandArgument
        codice_impianto = Request.Form(eliminaImpianto.UniqueID)
        Dim risultato_query As Boolean
        Dim query As New query

        If (codice_impianto = "128718") Or (codice_impianto = "912601") Then
            risultato_query = True
        Else
            risultato_query = query.delete_impianto(codice_impianto)
        End If

        If risultato_query Then
            create_master_page()
            manage_sidebar_top()
            'Response.Redirect("eliminaimpianto.aspx?result=1&niente=0")
        Else
            'Response.Redirect("eliminaimpianto.aspx?result=2&niente=0")
        End If

    End Sub

    Protected Sub eliminaUtilizzatore_Click(sender As Object, e As EventArgs) Handles eliminaUtilizzatore.Click
        Dim codice_impianto As String = ""
        'btn.CommandArgument
        codice_impianto = Request.Form(eliminaUtilizzatore.UniqueID)
        Dim risultato_query As Boolean
        Dim query As New query
        Dim codice_user As Guid = New Guid(codice_impianto)

        risultato_query = query.delete_user(codice_user)
        If risultato_query Then
            create_master_page()
            manage_sidebar_top()
            '    Response.Redirect("eliminautilizzatore.aspx?result=1&niente=0")
        Else
            '    Response.Redirect("eliminautilizzatore.aspx?result=2&niente=0")
        End If

    End Sub
End Class