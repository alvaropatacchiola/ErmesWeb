Public Class max5
    Inherits lingua
    Private Sub max5_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = ""
        Dim result As String = ""
        Dim user As String = ""
        Dim password As String = ""
        user = Page.Request("user")
        password = Page.Request("pass")

        result = Page.Request("result")

        If result = "1" Or (user IsNot Nothing And password IsNot Nothing) Then ' modifica setpoint avvenuta lettura dei parametri dal database
            Master.create_master_page()
            Master.manage_sidebar_top()
        End If
        If Not IsPostBack Or result = "1" Then
            Dim java_script_variable As java_script = New java_script
            nome_impianto = Page.Request("nome_impianto")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")

            'registro in locale la variablie java script che contiene il codice a 6 cifre e id_485
        End If






    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = ""
        Dim refresh As String = ""
        refresh = Page.Request("refresh")

        If Not refresh Is Nothing Then
            If refresh = "1" Then
                Session("numeroRefresh") = Session("numeroRefresh") + 1
                If (Session("numeroRefresh") > 5) Then
                    Response.Redirect("session_destroy.aspx")
                End If
                codice_impianto = Page.Request("codice")
                    id_485_impianto = Page.Request("id_485")
                    If read_real_time(codice_impianto, id_485_impianto) Then
                        Master.create_master_page()
                        Master.manage_sidebar_top()
                    End If
                End If
            Else
            refresh = "0"
        End If
        If (Not IsPostBack And refresh = "0") Or (refresh = "1") Then
            nome_impianto = Page.Request("nome_impianto")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            refresh_max5(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("impianto_global", "codice"), GetGlobalResourceObject("impianto_global", "referente"), statistica, GetGlobalResourceObject("impianto_global", "statistica"), GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "setpoint"), GetGlobalResourceObject("max5_global", "temperature"), "Log", "Log All")
            refresh_link.NavigateUrl = "~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&result=0&refresh=1"
        End If
        'set_url("max5/main_max5.aspx?nome_impianto=" + nome_impianto + "&codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&statistica=" + statistica)
        'set_url("max5/setpoint_ch.aspx?nome_impianto=" + nome_impianto + "&codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&statistica=" + statistica)

    End Sub
    Private Function read_real_time(ByVal codice As String, ByVal id_485 As String) As Boolean
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        Dim local_connection As Boolean
        local_connection = write_setpoint_new.client_connect()
        If local_connection Then ' connessione OK
            If write_setpoint_new.web_real_time(codice, id_485) Then
                Return True
            Else
                Return False
            End If
        End If
        Return False
    End Function
    Private Sub set_url(ByVal url_string As String)
        Dim uri As Uri
        uri = New Uri(main_function.main_path() + url_string)
        Dim webRequest As System.Net.WebRequest
        Dim streamReader As System.IO.StreamReader
        webRequest = System.Net.HttpWebRequest.Create(uri)
        webRequest.Proxy = System.Net.WebProxy.GetDefaultProxy()
        webRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials
        streamReader = New System.IO.StreamReader(webRequest.GetResponse().GetResponseStream())
        Dim content As String = streamReader.ReadToEnd()


    End Sub
    Private Sub refresh_max5(ByVal nome_impianto As String, ByVal codice_impianto As String, ByVal id_485_impianto As String, _
                             ByVal CODE_traduzione As String, ByVal referente_traduzione As String, ByVal statistica As String, _
                             ByVal statistica_traduzione As String, ByVal Strumenti_attivi_traduzione As String, ByVal allarmi_traduzione As String, ByVal setpoint_traduzione As String, _
                             ByVal temperature_traduzione As String, ByVal log_traduzione As String, ByVal log_all_traduzione As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim riga_impianto As ermes_web_20.quey_db.impianto_newRow
        'Dim statistica_impianto() As String = statistica.Split(",")
        Dim contatore_strumenti As Integer = 1
        Dim contatore_strumenti_disconnected As Integer = 0
        Dim contatore_strumenti_allarme As Integer = 0
        Dim check_connected As Boolean = False
        Dim time_connected As Long

        Dim contatore_canali As Integer = 0
        Dim config_value() As String
        Dim option_value() As String
        Dim label_canale_temp As String = ""
        Dim indirizzo As String = ""

        'If statistica_impianto.Length > 0 Then
        '    'posizione 0 - contatore strumenti
        '    contatore_strumenti = Val(statistica_impianto(0))
        'End If
        'If statistica_impianto.Length > 1 Then
        '    'posizione 1 - contatore strumenti disconnessi
        '    contatore_strumenti_disconnected = Val(statistica_impianto(1))
        'End If
        'If statistica_impianto.Length > 2 Then
        '    'posizione 2 - contatore strumenti allarmi
        '    contatore_strumenti_allarme = Val(statistica_impianto(2))
        'End If
        tabella_impianto = Master.tabella_impianto_container

        tabella_strumento = Session("strumento")
        literal_script.Text = "<script>"
        For Each dc In tabella_impianto
            If dc.identificativo = codice_impianto Then
                riga_impianto = dc
                indirizzo = (dc.indirizzo).ToString
                If Session("super_user") Then
                    literal_script.Text = literal_script.Text + "var enable_send_setpoint=true;"
                Else
                    If main_function.checkUserAdmin(dc.id_user, Session("mid_user").ToString, dc.modifica_setpoint_user1) Then
                        literal_script.Text = literal_script.Text + "var enable_send_setpoint=true;"
                    Else
                        literal_script.Text = literal_script.Text + "var enable_send_setpoint=false;"
                    End If

                End If

            End If
        Next
        literal_script.Text = literal_script.Text + "</script>"
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        check_connected = main_function.check_is_connected(riga_strumento.data_aggiornamento, time_connected)
        Label6.Text = "<h4>" + Replace(riga_impianto.nome_impianto, ">", " : ") + "</h4>"
        Page.Title = Replace(riga_impianto.nome_impianto, ">", " : ")
        Label2.Text = "<h5><span>" + CODE_traduzione + ":</span><strong>" + riga_impianto.identificativo + "</strong></h5>"
        Label1.Text = riga_impianto.descrizione_impianato
        Label7.Text = referente_traduzione
        If riga_impianto.referente = "" Then
            Label3.Text = "&nbsp"
        Else
            Label3.Text = riga_impianto.referente
        End If
        If riga_impianto.telefono_referente = "" Then
            Label4.Text = "&nbsp"
        Else
            Label4.Text = riga_impianto.telefono_referente
        End If
        If riga_impianto.mail_referente = "" Then
            Label5.Text = "&nbsp"
        Else
            Label5.Text = riga_impianto.mail_referente
        End If
        Label11.Text = statistica_traduzione
        'Label12.Text = "<i></i> <span class=""label"">" + Format(riga_strumento.data_aggiornamento.Day, "00") + _
        '    "</span> <span class=""label"">" + Format(riga_strumento.data_aggiornamento.Month, "00") + "</span> <span class=""label"">" + _
        '    riga_strumento.data_aggiornamento.Year.ToString + "</span> <span class=""label"">" + _
        '    Format(riga_strumento.data_aggiornamento.Hour, "00") + ":" + Format(riga_strumento.data_aggiornamento.Minute, "00") + "</span>"
        If check_connected Then
            refresh_link.Visible = True
            Label12.Text = "<i></i> <span class=""label"">" + time_connected.ToString +
            " min</span>"
        Else
            refresh_link.Visible = False
            Label12.Text = "<i></i> <span class=""label"">" + GetGlobalResourceObject("impianto_global", "no_connected") + _
            "</span>"
        End If

        'Label13.Text = "<div class=""span4"">"
        'Label13.Text = Label13.Text + "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        'Label13.Text = Label13.Text + "<div data-percent=""" + Replace(((100 * (contatore_strumenti - contatore_strumenti_disconnected)) / contatore_strumenti).ToString, " ", "") + _
        '    """ class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;"">"
        'Label13.Text = Label13.Text + "<span class=""value"">" + Replace((contatore_strumenti - contatore_strumenti_disconnected).ToString, " ", "") + "</span><canvas width=""50"" height=""50""></canvas><canvas width=""50"" height=""50""></canvas></div>"
        'Label13.Text = Label13.Text + "<span class=""txt"">" + Strumenti_attivi_traduzione + "</span>"
        'Label13.Text = Label13.Text + "<div class=""clearfix""></div>"
        'Label13.Text = Label13.Text + "</a>"
        'Label13.Text = Label13.Text + "</div>"
        'Label13.Text = Label13.Text + "<div class=""span4"">"
        'Label13.Text = Label13.Text + "<a href="""" class=""widget-stats margin-bottom-none"">"
        'Label13.Text = Label13.Text + "<span class=""glyphicons remove""><i></i></span>"
        'Label13.Text = Label13.Text + "<span class=""txt"">" + allarmi_traduzione + "</span>"
        'Label13.Text = Label13.Text + "<div class=""clearfix""></div>"
        'Label13.Text = Label13.Text + "<span class=""count label label-important"">" + (contatore_strumenti_allarme).ToString + "</span>"
        'Label13.Text = Label13.Text + "</a>"
        'Label13.Text = Label13.Text + "</div>"

        'HyperLink1.NavigateUrl = "~/impianto.aspx?nome_impianto=" + nome_impianto
        HyperLink1.NavigateUrl = "~/dashboardAssets.aspx"

        Label17.Text = "<h3 class=""heading-mosaic"">" + id_485_impianto + " | MAX5 " + main_function.get_lebel_485(riga_strumento.nome) + "</h3>"

        If main_function.get_version_integer(riga_strumento.nome) <= 29 Then
            Literal1.Visible = False ' setpoint service
            Literal2.Visible = False ' setpoint service
            literal30.Visible = False ' setpoint service
            literal31.Visible = False ' setpoint service
            Literal3.Visible = False ' setpoint service
            literal16.Visible = False ' setpoint calibrazione
            'PlaceHolder12.Visible = False ' setpoint temperatura
            literal26.Visible = False 'setpoint message rs 485
            literal27.Visible = False 'setpoint message rs 485
        Else
            Literal1.Visible = True ' setpoint service
            Literal2.Visible = True ' setpoint service
            literal30.Visible = True ' setpoint service
            literal31.Visible = True ' setpoint service
            Literal3.Visible = True ' setpoint service

            literal16.Visible = True ' setpoint calibrazione
            'PlaceHolder12.Visible = True ' setpoint temperatura
            literal26.Visible = True 'setpoint message rs 485
            literal27.Visible = True 'setpoint message rs 485
        End If
        literal14.Text = ""
        'Label15.Text = ""
        'setpoint_1.Visible = False
        'setpoint_2.Visible = False
        'setpoint_3.Visible = False
        'setpoint_4.Visible = False
        'setpoint_5.Visible = False
        'setpoint_t.Visible = False
        config_value = main_function.get_split_str(riga_strumento.value1)
        option_value = main_function.get_split_str(riga_strumento.value4)
        For i = 1 To 5
            'If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "yagel" And i = 5 Then ' personalizzazione yagel
            '    label_canale_temp = main_function_config.get_tipo_strumento_max5("phY", option_value(0))
            'Else
            label_canale_temp = main_function_config.get_tipo_strumento_max5(i, config_value(i - 1), option_value(0))
            'End If
            If label_canale_temp <> "" Then
                contatore_canali = contatore_canali + 1
                'Select Case i
                '    Case 1
                '        setpoint_1.Visible = True
                '        setpoint_1.Text = setpoint_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp
                '    Case 2
                '        setpoint_2.Visible = True
                '        setpoint_2.Text = setpoint_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp
                '    Case 3
                '        setpoint_3.Visible = True
                '        setpoint_3.Text = setpoint_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp
                '    Case 4
                '        setpoint_4.Visible = True
                '        setpoint_4.Text = setpoint_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp
                '    Case 5
                '        setpoint_5.Visible = True
                '        setpoint_5.Text = setpoint_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp
                'End Select
                If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" Then
                    If i = 3 Then
                        label_canale_temp = "HClO"
                    End If
                    If i = 4 Then
                        label_canale_temp = "Cl2"
                    End If
                End If
                literal14.Text = literal14.Text + "<li><a id =""SetPoint_" + Format(contatore_canali, "0") + """ href='#'>" + setpoint_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp + "</a></li>"
                ' Label15.Text = Label15.Text + "<li><a id =""Log_" + Format(contatore_canali, "0") + """ href='#'>" + log_traduzione + " Ch" + Format(contatore_canali, "0") + " " + label_canale_temp + "</a></li>"
            End If
        Next
        ' Label15.Text = Label15.Text + "<li><a id =""Log_" + Format(contatore_canali + 1, "0") + """ href='#'>" + log_all_traduzione + "</a></li>"
        If main_function.get_version_integer(riga_strumento.nome) <= 29 Then
        Else
            'setpoint_t.Visible = True
            'setpoint_t.Text = setpoint_traduzione + " " + temperature_traduzione
            Dim numero_temperature As String = ""
            If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "doppiaPiscina" Then
                numero_temperature = "1"
            End If
            literal14.Text = literal14.Text + "<li><a id =""SetPoint_temp"" href='#'>" + setpoint_traduzione + " " + temperature_traduzione + " " + numero_temperature + "</a></li>"
            If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "doppiaPiscina" Then
                literal14.Text = literal14.Text + "<li><a id =""SetPoint_temp1"" href='#'>" + setpoint_traduzione + " " + temperature_traduzione + " 2" + "</a></li>"
            End If
        End If
        'java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)



        'mappa
        literal_map.Text = ""
        literal_map.Text = literal_map.Text + "<h4>" + nome_impianto + "</h4>"
        literal_map.Text = literal_map.Text + "<p>" + Replace(get_indirizzo(indirizzo), ",", " ") + "</p>"
        literal_map.Text = literal_map.Text + " <div id =""pippo"" class=""map_canvas"" style=""height:400px;width:100%;"">"

        'intestazione = intestazione + " <div class=""map_canvas"" id=""google-map-geocoding"" style=""height: 400px""></div>"

        'intestazione = intestazione + " <div id =""map-canvas""  style=""height:400px;margin: 0px;padding: 0px;"">"
        'intestazione = intestazione + " <div id =""map-canvas""  style=""height:400px;"">"
        'gestione mappa



        literal_map.Text = literal_map.Text + "</div>"

        crea_indirizzo_mappa(indirizzo)
    End Sub
    Private Sub crea_indirizzo_mappa(ByVal indirizzo As String)
        indirizzo_script.Text = "<script>"
        indirizzo_script.Text = indirizzo_script.Text + "var indirizzo = '" + get_indirizzo(indirizzo) + "';"
        indirizzo_script.Text = indirizzo_script.Text + "</script>"
    End Sub
    Private Function get_indirizzo(ByVal indirizzo As String) As String
        Dim indirizzo_temp_str As String = ""
        If indirizzo = "" Or InStr(indirizzo, "empty") <> 0 Then
            Return ""
        Else
            If (InStr(indirizzo, "-") <> 0) Then
                Dim indirizzo_temp() As String = indirizzo.Split("-")
                indirizzo_temp_str = ""
                For i = 1 To indirizzo_temp.Length - 1
                    indirizzo_temp_str = indirizzo_temp_str + indirizzo_temp(i) + ","
                Next

                Return indirizzo_temp_str
            Else
                Return ""

            End If
        End If
        Return ""
    End Function

    

  
   
End Class