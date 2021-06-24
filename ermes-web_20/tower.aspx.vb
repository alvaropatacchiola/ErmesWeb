Public Class tower
    Inherits lingua

    Private Sub tower_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = "" '
        Dim result As String = ""
        Dim refresh As String = ""
        Dim user As String = ""
        Dim password As String = ""
        user = Page.Request("user")
        password = Page.Request("pass")
        refresh = Page.Request("refresh")
        result = Page.Request("result")

        If result = "1" Or (user IsNot Nothing And password IsNot Nothing) Then ' modifica setpoint avvenuta lettura dei parametri dal database
            Master.create_master_page()
            Master.manage_sidebar_top()
        End If
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
            refresh_tower(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("impianto_global", "codice"), GetGlobalResourceObject("impianto_global", "referente"), statistica, GetGlobalResourceObject("impianto_global", "statistica"), GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "setpoint"), GetGlobalResourceObject("max5_global", "temperature"), "Log", "Log All")
            refresh_link.NavigateUrl = "~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&result=0&refresh=1"
        End If
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
    Private Sub tower_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = ""
        If Not IsPostBack Then
            Dim java_script_variable As java_script = New java_script
            nome_impianto = Page.Request("nome_impianto")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            'registro in locale la variablie java script che contiene il codice a 6 cifre e id_485
        End If

    End Sub
    Private Sub refresh_tower(ByVal nome_impianto As String, ByVal codice_impianto As String, ByVal id_485_impianto As String, _
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
        Dim personalizzazione_aquacare As Integer
        Dim tipo_versione As String = ""
        Dim new_version As Boolean = False
        Dim MTower_Type As String = ""
        Dim str_sonda2 As String = ""
        Dim str_sonda3 As String = ""
        Dim version_str As String = ""
        Dim contatore_canali As Integer = 0
        Dim config_value() As String
        Dim label_canale_temp As String = ""
        Dim indirizzo As String = ""
        Dim boiler As Boolean = False

        Dim check_connected As Boolean = False
        Dim time_connected As Long


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
        'controllo visualizzazione menu message
        If riga_strumento.value6.IndexOf("#") > 0 Then
            Literal2.Visible = True
        Else
            Literal2.Visible = False
        End If

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
        If check_connected Then
            Label12.Text = "<i></i> <span class=""label"">" + time_connected.ToString + _
            " min</span>"
        Else
            Label12.Text = "<i></i> <span class=""label"">" + GetGlobalResourceObject("impianto_global", "no_connected") + _
            "</span>"
        End If

        'Label12.Text = "<i></i> <span class=""label"">" + Format(riga_strumento.data_aggiornamento.Day, "00") + _
        '    "</span> <span class=""label"">" + Format(riga_strumento.data_aggiornamento.Month, "00") + "</span> <span class=""label"">" + _
        '    riga_strumento.data_aggiornamento.Year.ToString + "</span> <span class=""label"">" + _
        '    Format(riga_strumento.data_aggiornamento.Hour, "00") + ":" + Format(riga_strumento.data_aggiornamento.Minute, "00") + "</span>"
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

        Label17.Text = "<h3 class=""heading-mosaic"">" + id_485_impianto + " | TOWER " + main_function.get_lebel_485(riga_strumento.nome) + "</h3>"
        new_version = main_function_config.chek_tower_version(riga_strumento.nome, tipo_versione, personalizzazione_aquacare)
        config_value = main_function.get_split_str(riga_strumento.value4)
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare, boiler)
        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , , , , , str_sonda2, str_sonda3)

        If new_version Then ' nuova versione
            Label18.Visible = False
            Label20.Visible = False
        Else
            Label18.Visible = False
            Label20.Visible = False

        End If
        Label33.Text = ""
        Label34.Text = ""
        Select Case MTower_Type
            Case "Cdxxx"
                If boiler Then
                    Label32.Text = "<li><a id ='bleed_boiler_id' href='#'>Bleed</a></li>"
                End If
                'Label32
                Label33.Visible = False ' setpoint non visibili
                Label34.Visible = False ' setpoint non visibili
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"

            Case "Cd_pH"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = False ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 pH</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 pH </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"
            Case "Cd_rH"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = False ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 mV</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 mV </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"
            Case "Cd_pH_rH"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = True ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 pH</a></li>"
                Label34.Text = Label34.Text + "<li><a id =""setpoint3_id"" href='#'>" + setpoint_traduzione + " Ch3 mV</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 pH </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_3"" href='#'>" + log_traduzione + " Ch3 mV </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"

            Case "Cd_pH_Cl"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = True ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 pH</a></li>"
                Label34.Text = Label34.Text + "<li><a id =""setpoint3_id"" href='#'>" + setpoint_traduzione + " Ch3 " + str_sonda3 + "</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 pH </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_3"" href='#'>" + log_traduzione + " Ch3 " + str_sonda3 + " </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"

            Case "Cd_trc_Cl"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = True ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 TRC</a></li>"
                Label34.Text = Label34.Text + "<li><a id =""setpoint3_id"" href='#'>" + setpoint_traduzione + " Ch3 " + str_sonda3 + "</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 pH </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_3"" href='#'>" + log_traduzione + " Ch3 " + str_sonda3 + " </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"
            Case "Cd_trc_rH"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = True ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 TRC</a></li>"
                Label34.Text = Label34.Text + "<li><a id =""setpoint3_id"" href='#'>" + setpoint_traduzione + " Ch3 mV</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 pH </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_3"" href='#'>" + log_traduzione + " Ch3 " + str_sonda3 + " </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"
            Case "Cd_rH_Cl"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = True ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 mV</a></li>"
                Label34.Text = Label34.Text + "<li><a id =""setpoint3_id"" href='#'>" + setpoint_traduzione + " Ch3 " + str_sonda3 + "</a></li>"

            Case "Cd_Cl"
                Label33.Visible = True ' setpoint  visibili
                Label34.Visible = False ' setpoint terzo canale non visibile
                Label33.Text = Label33.Text + "<li><a id =""setpoint2_id"" href='#'>" + setpoint_traduzione + " Ch2 " + str_sonda2 + "</a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_1"" href='#'>" + log_traduzione + " Ch1 Conductivity </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_2"" href='#'>" + log_traduzione + " Ch2 " + str_sonda2 + " </a></li>"
                'Label15.Text = Label15.Text + "<li><a id =""Log_all"" href='#'>" + log_all_traduzione + "</a></li>"

        End Select
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