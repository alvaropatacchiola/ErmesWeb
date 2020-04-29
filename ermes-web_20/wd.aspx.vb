Public Class wd
    Inherits lingua


    Private Sub wd_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = ""
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
            ' WH refresh_wd(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("impianto_global", "codice"), GetGlobalResourceObject("impianto_global", "referente"), statistica, GetGlobalResourceObject("impianto_global", "statistica"), GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), "Log", "Log All", GetGlobalResourceObject("ld_global", "setpoint"), GetGlobalResourceObject("wd_global", "maxstrokes"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "flow"), GetGlobalResourceObject("wd_global", "digital_input"), GetGlobalResourceObject("ld_global", "parameters"), GetGlobalResourceObject("ld_global", "international"), GetGlobalResourceObject("ld_global", "log_setup"), GetGlobalResourceObject("ld_global", "manual"), GetGlobalResourceObject("ld_global", "message"), GetGlobalResourceObject("ld_global", "calibration")) ' WH
            refresh_wd(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("impianto_global", "codice"), GetGlobalResourceObject("impianto_global", "referente"), statistica, GetGlobalResourceObject("impianto_global", "statistica"), GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), "Log", "Log All", GetGlobalResourceObject("ld_global", "setpoint"), GetGlobalResourceObject("wd_global", "maxstrokes"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "flow"), GetGlobalResourceObject("wd_global", "digital_input"), GetGlobalResourceObject("ld_global", "parameters"), GetGlobalResourceObject("ld_global", "international"), GetGlobalResourceObject("ld_global", "log_setup"), GetGlobalResourceObject("ld_global", "manual"), GetGlobalResourceObject("ld_global", "message"), GetGlobalResourceObject("ld_global", "calibration"), GetGlobalResourceObject("ld_global", "Autosetpoint"), GetGlobalResourceObject("ld_global", "Alert"), GetGlobalResourceObject("ld_global", "Assistenza"), GetGlobalResourceObject("ld_global", "Channels"), GetGlobalResourceObject("ld_global", "calibrationB"), GetGlobalResourceObject("ld_global", "setpointB"), GetGlobalResourceObject("ld_global", "flowB"), GetGlobalResourceObject("ld_global", "internationalB"), GetGlobalResourceObject("ld_global", "log_setupB"), GetGlobalResourceObject("ld_global", "parametersB"), GetGlobalResourceObject("ld_global", "ResetA")) ' WH
            refresh_link.NavigateUrl = "~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"

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
    'Private Sub refresh_wd(ByVal nome_impianto As String, ByVal codice_impianto As String, ByVal id_485_impianto As String, _
    '                ByVal CODE_traduzione As String, ByVal referente_traduzione As String, ByVal statistica As String, _
    '                ByVal statistica_traduzione As String, ByVal Strumenti_attivi_traduzione As String, ByVal allarmi_traduzione As String, ByVal log_traduzione As String, _
    '                ByVal log_all_traduzione As String, ByVal Setpoint_traduzione As String, ByVal MaxStrokes_traduzione As String, ByVal Probe_Failure_traduzione As String, _
    '                ByVal Dosing_Alarm_traduzione As String, ByVal Flow_Alarm_traduzione As String, ByVal Digital_Input_traduzione As String, ByVal parameters_traduzione As String, _
    '                   ByVal international_traduzione As String, ByVal log_setup_traduzione As String, ByVal Manual_traduzione As String, ByVal Message_traduzione As String, ByVal Calibration_traduzione As String, _
    ' ) ' WH

    ' WH
    Private Sub refresh_wd(ByVal nome_impianto As String, ByVal codice_impianto As String, ByVal id_485_impianto As String, _
                     ByVal CODE_traduzione As String, ByVal referente_traduzione As String, ByVal statistica As String, _
                     ByVal statistica_traduzione As String, ByVal Strumenti_attivi_traduzione As String, ByVal allarmi_traduzione As String, ByVal log_traduzione As String, _
                     ByVal log_all_traduzione As String, ByVal Setpoint_traduzione As String, ByVal MaxStrokes_traduzione As String, ByVal Probe_Failure_traduzione As String, _
                     ByVal Dosing_Alarm_traduzione As String, ByVal Flow_Alarm_traduzione As String, ByVal Digital_Input_traduzione As String, ByVal parameters_traduzione As String, _
                        ByVal international_traduzione As String, ByVal log_setup_traduzione As String, ByVal Manual_traduzione As String, ByVal Message_traduzione As String, ByVal Calibration_traduzione As String, _
                        ByVal Autosetpoint_traduzione As String, ByVal Alert_traduzione As String, ByVal Assistenza_traduzione As String, ByVal channels_traduzione As String, ByVal CalibrationB_traduzione As String, _
                        ByVal SetpointB_traduzione As String, ByVal Flow_AlarmB_traduzione As String, ByVal internationalB_traduzione As String, ByVal log_setupB_traduzione As String, ByVal parametersB_traduzione As String, _
                        ByVal ResetA_traduzione As String)


        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim riga_impianto As ermes_web_20.quey_db.impianto_newRow
        Dim statistica_impianto() As String = statistica.Split(",")
        Dim contatore_strumenti As Integer = 1
        Dim contatore_strumenti_disconnected As Integer = 0
        Dim contatore_strumenti_allarme As Integer = 0
        Dim numero_canali As Integer = 0
        Dim contatore_canali As Integer = 0
        Dim calibrz_value() As String

        Dim label_canale_temp As String = ""
        Dim indirizzo As String = ""

        Dim check_connected As Boolean = False
        Dim time_connected As Long


        Dim label_tipo_wd As String = "" 'Andrea Manetta
        Dim config_value() As String 'Andrea Manetta



        If statistica_impianto.Length > 0 Then
            'posizione 0 - contatore strumenti
            contatore_strumenti = Val(statistica_impianto(0))
        End If
        If statistica_impianto.Length > 1 Then
            'posizione 1 - contatore strumenti disconnessi
            contatore_strumenti_disconnected = Val(statistica_impianto(1))
        End If
        If statistica_impianto.Length > 2 Then
            'posizione 2 - contatore strumenti allarmi
            contatore_strumenti_allarme = Val(statistica_impianto(2))
        End If
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

        calibrz_value = main_function.get_split_str(riga_strumento.value4)

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
        Label13.Text = "<div class=""span4"">"
        Label13.Text = Label13.Text + "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        Label13.Text = Label13.Text + "<div data-percent=""" + Replace(((100 * (contatore_strumenti - contatore_strumenti_disconnected)) / contatore_strumenti).ToString, " ", "") + _
            """ class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;"">"
        Label13.Text = Label13.Text + "<span class=""value"">" + Replace((contatore_strumenti - contatore_strumenti_disconnected).ToString, " ", "") + "</span><canvas width=""50"" height=""50""></canvas><canvas width=""50"" height=""50""></canvas></div>"
        Label13.Text = Label13.Text + "<span class=""txt"">" + Strumenti_attivi_traduzione + "</span>"
        Label13.Text = Label13.Text + "<div class=""clearfix""></div>"
        Label13.Text = Label13.Text + "</a>"
        Label13.Text = Label13.Text + "</div>"
        Label13.Text = Label13.Text + "<div class=""span4"">"
        Label13.Text = Label13.Text + "<a href="""" class=""widget-stats margin-bottom-none"">"
        Label13.Text = Label13.Text + "<span class=""glyphicons remove""><i></i></span>"
        Label13.Text = Label13.Text + "<span class=""txt"">" + allarmi_traduzione + "</span>"
        Label13.Text = Label13.Text + "<div class=""clearfix""></div>"
        Label13.Text = Label13.Text + "<span class=""count label label-important"">" + (contatore_strumenti_allarme).ToString + "</span>"
        Label13.Text = Label13.Text + "</a>"
        Label13.Text = Label13.Text + "</div>"

        HyperLink1.NavigateUrl = "~/dashboardNew.aspx"

        Label17.Text = "<h3 class=""heading-mosaic"">" + id_485_impianto + " | " + main_function.get_tipo_strumento(riga_strumento.tipo_strumento) + " " + main_function.get_lebel_485(riga_strumento.nome) + "</h3>"
        'customizzazione link menu per wd 
        Label19.Text = SetpointB_traduzione
        Label21.Text = allarmi_traduzione
        Label33.Text = "<li class='active'><a id ='channels_id' href='#'>" + channels_traduzione + "</a></li>"
        Literal4.Text = "<li><a id ='Log_1' href='#'>" + GetGlobalResourceObject("ld_global", "Log") + "</a></li>"
        Literal5.Text = "<li><a id ='Log_2' href='#'>" + GetGlobalResourceObject("ld_global", "Log") + "</a></li>"





        numero_canali = 2

        'gestione set point
        'Andrea Manetta
        'main_function.get_split_str(riga_strumento.value4)

        config_value = main_function.get_split_str(riga_strumento.value1) 'Andrea Manetta   
        label_tipo_wd = main_function_config.get_tipo_strumento_wd(Mid(config_value(3), 3, 3)) 'Andrea Manetta 


        Select Case riga_strumento.tipo_strumento ' WH
            Case "WD" ' WH
                If Mid(config_value(3), 3, 3) = "306" Then ' 2 Magneti
                    Label29.Text = "<li><a id ='setpoint_wd_2_magneti' href='#'>" + Setpoint_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Text = "<li><a id ='max_strokes_2_magneti' href='#'>" + MaxStrokes_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Visible = True
                    Label26.Visible = False ' WH

                    Label30.Visible = False ' WH
                    Label31.Visible = False ' WH

                    Label77.Visible = False
                End If ' WH
                'log
                Literal4.Visible = True
                Literal5.Visible = False
                Label77.Visible = False


                If Mid(config_value(3), 3, 3) = "302" Then 'S
                    Label29.Text = "<li><a id ='setpoint_wd_S' href='#'>" + Setpoint_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Text = "<li><a id ='max_strokes_S' href='#'>" + MaxStrokes_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Visible = True
                    Label26.Visible = False ' WH

                    Label30.Visible = False ' WH
                    Label31.Visible = False ' WH
                    Label77.Visible = False

                End If

                If Mid(config_value(3), 3, 3) = "301" Then 'EV
                    Label29.Text = "<li><a id ='setpoint_wd_EV' href='#'>" + Setpoint_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Text = "<li><a id ='max_strokes_2_magneti' href='#'>" + MaxStrokes_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Visible = True
                    Label26.Visible = False ' WH

                    Label30.Visible = False ' WH
                    Label31.Visible = False ' WH
                    Label77.Visible = False

                End If

                If Mid(config_value(3), 3, 3) = "303" Then 'PER

                    If Val(main_function.get_version(riga_strumento.nome)) < 140 Then
                        Label29.Text = "<li><a id ='setpoint_wd_PER' href='#'>" + Setpoint_traduzione + "</a></li>" 'Andrea Manetta
                        Label77.Visible = False
                    End If
                    If Val(main_function.get_version(riga_strumento.nome)) >= 140 Then
                        Label29.Text = "<li><a id ='setpoint_wd_PER' href='#'>" + SetpointB_traduzione + "</a></li>" 'Andrea Manetta
                        Label77.Text = "<li><a id ='reset_all_PER' href='#'>" + ResetA_traduzione + "</a></li>" 'Andrea Manetta
                    End If
                    'Label24.Text = "<li><a id ='max_strokes_2_magneti' href='#'>" + MaxStrokes_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Visible = False
                    Label26.Visible = False ' WH

                    Label30.Visible = False ' WH
                    Label31.Visible = False ' WH

                End If


            Case "WH" ' WH

                If Mid(config_value(3), 3, 3) = "306" Then ' 2 Magneti' WH
                    Label29.Text = "<li><a id ='setpoint_wd_2_magneti' href='#'>" + Setpoint_traduzione + "</a></li>" 'Andrea Manetta' WH
                    Label26.Text = "<li><a id ='auto_setpoint' href='#'>" + Autosetpoint_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Visible = False ' WH
                    Label26.Visible = True ' WH

                    Label30.Text = "<li><a id ='alert' href='#'>" + Alert_traduzione + "</a></li>" 'Andrea Manetta
                    Label31.Text = "<li><a id ='assistenza' href='#'>" + Assistenza_traduzione + "</a></li>" 'Andrea Manetta

                    Label30.Visible = True ' WH
                    Label31.Visible = True ' WH

                    Label77.Visible = False
                End If ' WH

                If Mid(config_value(3), 3, 3) = "303" Then ' 2 Magneti' WH PER
                    Label29.Text = "<li><a id ='setpoint_wd_2_magneti' href='#'>" + Setpoint_traduzione + "</a></li>" 'Andrea Manetta' WH
                    Label26.Text = "<li><a id ='auto_setpoint' href='#'>" + Autosetpoint_traduzione + "</a></li>" 'Andrea Manetta
                    Label24.Visible = False ' WH
                    Label26.Visible = True ' WH

                    Label30.Text = "<li><a id ='alert' href='#'>" + Alert_traduzione + "</a></li>" 'Andrea Manetta
                    Label31.Text = "<li><a id ='assistenza' href='#'>" + Assistenza_traduzione + "</a></li>" 'Andrea Manetta

                    Label30.Visible = True ' WH
                    Label31.Visible = True ' WH

                    Label77.Visible = False
                End If ' WH
                'log
                Literal4.Visible = False

                Literal5.Visible = True
                Label77.Visible = False

        End Select ' WH




        If Val(main_function.get_version(riga_strumento.nome)) < 140 Then

            Literal1.Text = "<li><a id =""manual_wd"" href='#'>" + Manual_traduzione + "</a></li>"
            Literal2.Text = "<li><a id =""message_wd"" href='#'>" + Message_traduzione + "</a></li>"
            Literal3.Text = "<li><a id =""calibration_wd"" href='#'>" + Calibration_traduzione + "</a></li>"
            Literal1.Visible = False
            Literal2.Visible = False
            Literal3.Visible = False

            Label14.Text = "<li><a id ='Probe_Failure_wd' href='#'>" + Probe_Failure_traduzione + "</a></li>" 'Andrea Manetta 
            Label16.Text = "<li><a id ='Dosing_Alarm_wd' href='#'>" + Dosing_Alarm_traduzione + "</a></li>" 'Andrea Manetta
        Else

            Literal1.Text = "<li><a id =""manual_wd"" href='#'>" + Manual_traduzione + "</a></li>"
            Literal2.Text = "<li><a id =""message_wd"" href='#'>" + Message_traduzione + "</a></li>"


            Literal2.Visible = True
            Literal3.Visible = True



            If Val(main_function.get_version(riga_strumento.nome)) >= 140 And Mid(config_value(3), 3, 3) <> "303" And Mid(config_value(3), 3, 3) <> "306" Then
                Literal3.Text = "<li><a id =""calibration_wd"" href='#'>" + Calibration_traduzione + "</a></li>"
                Label14.Text = "<li><a id ='Probe_Failure_wd' href='#'>" + Probe_Failure_traduzione + "</a></li>" 'Andrea Manetta 
                Label16.Text = "<li><a id ='Dosing_Alarm_wd' href='#'>" + Dosing_Alarm_traduzione + "</a></li>" 'Andrea Manetta
                Literal1.Visible = True
            End If

            If Val(main_function.get_version(riga_strumento.nome)) >= 140 And (Mid(config_value(3), 3, 3) = "303" Or Mid(config_value(3), 3, 3) = "306") Then
                Literal3.Text = "<li><a id =""calibration_wd"" href='#'>" + CalibrationB_traduzione + "</a></li>"
                Label14.Text = "<li><a id ='Probe_Failure_wd_140' href='#'>" + Probe_Failure_traduzione + "</a></li>" 'Andrea Manetta 
                Label16.Text = "<li><a id ='Dosing_Alarm_wd_140' href='#'>" + Dosing_Alarm_traduzione + "</a></li>" 'Andrea Manetta
                Label77.Visible = True
                Literal1.Visible = False
            End If



        End If


        Label33.Text = "<li class='active'><a id ='channels_id' href='#'>" + channels_traduzione + "</a></li>"


        Label25.Text = "<li><a id ='Digital_inputs_wd' href='#'>" + Digital_Input_traduzione + "</a></li>" 'Andrea Manetta


        If Val(main_function.get_version(riga_strumento.nome)) < 140 Then
            Label27.Text = "<li><a id ='parameters_wd' href='#'>" + parameters_traduzione + "</a></li>" 'Andrea Manetta
            Label10.Text = "<li><a id ='Flow_Alarm_wd' href='#'>" + Flow_Alarm_traduzione + "</a></li>" 'Andrea Manetta
            Label20.Text = "<li><a id ='international_wd' href='#'>" + international_traduzione + "</a></li>" 'Andrea Manetta
            Label22.Text = "<li><a id ='log_setup_wd' href='#'>" + log_setup_traduzione + "</a></li>" 'Andrea Manetta
        End If

        If Val(main_function.get_version(riga_strumento.nome)) >= 140 And Mid(config_value(3), 3, 3) <> "303" And Mid(config_value(3), 3, 3) <> "306" Then
            Label27.Text = "<li><a id ='parameters_wd' href='#'>" + parameters_traduzione + "</a></li>" 'Andrea Manetta
            Label10.Text = "<li><a id ='Flow_Alarm_wd' href='#'>" + Flow_Alarm_traduzione + "</a></li>" 'Andrea Manetta
            Label20.Text = "<li><a id ='international_wd' href='#'>" + international_traduzione + "</a></li>" 'Andrea Manetta
            Label22.Text = "<li><a id ='log_setup_wd' href='#'>" + log_setup_traduzione + "</a></li>" 'Andrea Manetta
        End If

        If Val(main_function.get_version(riga_strumento.nome)) >= 140 And (Mid(config_value(3), 3, 3) = "303" Or Mid(config_value(3), 3, 3) = "306") Then
            Label27.Text = "<li><a id ='parameters_wd_140' href='#'>" + parametersB_traduzione + "</a></li>" 'Andrea Manetta
            Label10.Text = "<li><a id ='Flow_Alarm_wd' href='#'>" + Flow_AlarmB_traduzione + "</a></li>" 'Andrea Manetta
            Label20.Text = "<li><a id ='international_wd' href='#'>" + internationalB_traduzione + "</a></li>" 'Andrea Manetta
            Label22.Text = "<li><a id ='log_setup_wd' href='#'>" + log_setupB_traduzione + "</a></li>" 'Andrea Manetta
        End If



        'end

        'For i = 1 To numero_canali + 1
        '    If i <= numero_canali Then
        '        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))

        '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_traduzione + " Ch" + i.ToString + " " + label_canale_temp + "</a></li>"
        '    Else
        '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_all_traduzione + "</a></li>"
        '    End If
        'Next
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