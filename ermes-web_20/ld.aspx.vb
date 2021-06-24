Public Class ld
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            refresh_ld(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("impianto_global", "codice"), GetGlobalResourceObject("impianto_global", "referente"), statistica, GetGlobalResourceObject("impianto_global", "statistica"), GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), "Log", "Log All", _
                       GetGlobalResourceObject("ld_global", "setpoint"), GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "range_alarm"), GetGlobalResourceObject("ld_global", "flow"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "parameters"), GetGlobalResourceObject("ld_global", "international"), GetGlobalResourceObject("ld_global", "log_setup"), _
                        GetGlobalResourceObject("ld_global", "manual"), GetGlobalResourceObject("ld_global", "message"), GetGlobalResourceObject("ld_global", "calibration"), GetGlobalResourceObject("ld_global", "Meter"), GetGlobalResourceObject("ld_global", "Flowall"), GetGlobalResourceObject("ld_global", "Self"), GetGlobalResourceObject("ld_global", "Circulation"))

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
    Private Sub refresh_ld(ByVal nome_impianto As String, ByVal codice_impianto As String, ByVal id_485_impianto As String, _
                         ByVal CODE_traduzione As String, ByVal referente_traduzione As String, ByVal statistica As String, _
                         ByVal statistica_traduzione As String, ByVal Strumenti_attivi_traduzione As String, ByVal allarmi_traduzione As String, ByVal log_traduzione As String, _
                         ByVal log_all_traduzione As String, ByVal SetPoint_traduzione As String, ByVal ma_output_traduzione As String, _
                         ByVal range_alarm_traduzione As String, ByVal flow_traduzione As String, ByVal probe_failure_traduzione As String, _
                         ByVal dosing_alarm_traduzione As String, ByVal parameters_traduzione As String, ByVal internationale_traduzione As String, _
        ByVal log_setup_traduzione As String, ByVal Manual_traduzione As String, ByVal Message_traduzione As String, ByVal Calibration_traduzione As String,
                ByVal wmeter_traduzione As String, ByVal flowall_traduzione As String, ByVal Self_traduzione As String, ByVal Circulation_traduzione As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim riga_impianto As ermes_web_20.quey_db.impianto_newRow
        ' Dim statistica_impianto() As String = statistica.Split(",")
        Dim contatore_strumenti As Integer = 1
        Dim contatore_strumenti_disconnected As Integer = 0
        Dim contatore_strumenti_allarme As Integer = 0
        Dim numero_canali As Integer = 0
        Dim contatore_canali As Integer = 0
        Dim config_value() As String
        Dim calibrz_value() As String
        Dim setpntr_value() As String
        Dim indirizzo As String = ""
        Dim time_connected As Long
        Dim check_connected As Boolean = False
        Dim label_canale_temp As String = ""
        Dim nome_strumento() As String
        Dim nome_strumentoB As String

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
                    'If dc.modifica_setpoint_user1 = True Then
                    'literal_script.Text = literal_script.Text + "var enable_send_setpoint=true;"
                    'Else
                    'literal_script.Text = literal_script.Text + "var enable_send_setpoint=false;"

                    'End If
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

        Select riga_strumento.tipo_strumento
            Case "LD"
                config_value = main_function.get_split_str(riga_strumento.value1)
                calibrz_value = main_function.get_split_str(riga_strumento.value4)
            Case "LDDT"
                config_value = main_function.get_split_str(riga_strumento.value1)
                calibrz_value = main_function.get_split_str(riga_strumento.value4)
            Case "LDS"
                config_value = main_function.get_split_str(riga_strumento.value1)
                calibrz_value = main_function.get_split_str(riga_strumento.value4)
            Case "LD4"
                config_value = main_function.get_split_str(riga_strumento.value1)
                calibrz_value = main_function.get_split_str(riga_strumento.value4)
            Case "LDMA"
                config_value = main_function.get_split_str(riga_strumento.value1)
                setpntr_value = main_function.get_split_str(riga_strumento.value7)
            Case "LDLG"
                config_value = main_function.get_split_str(riga_strumento.value1)
                setpntr_value = main_function.get_split_str(riga_strumento.value7)

        End Select
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

        Label17.Text = "<h3 class=""heading-mosaic"">" + id_485_impianto + " | " + main_function.get_tipo_strumento(riga_strumento.tipo_strumento) + " " + main_function.get_lebel_485(riga_strumento.nome) + "</h3>"
        'customizzazione link menu per ld e lds
        Select Case riga_strumento.tipo_strumento

        '    Case "LDDT"
        '        refresh_link.NavigateUrl = "~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"

        '        numero_canali = 2

        '        



        '        Literal1.Text = "<li><a id =""manual_ld"" href='#'>" + Manual_traduzione + "</a></li>"
        '            Literal2.Text = "<li><a id =""message_ld"" href='#'>" + Message_traduzione + "</a></li>"
        '            Literal3.Text = "<li><a id =""calibration_ldd"" href='#'>" + Calibration_traduzione + "</a></li>"
        '            Literal1.Visible = True
        '            Literal2.Visible = True
        '            Literal3.Visible = True
        '            Label22.Visible = False
        '            Label26.Visible = False


        '        Literal6.Visible = False

        '        Label16.Text = "<li><a id ='maoutput_ld' href='#'>" + ma_output_traduzione + "</a></li>"
        '        Label27.Text = "<li><a id =""rangealarm_ld"" href=""#"">" + range_alarm_traduzione + "</a></li>"
        '        Label28.Text = "<li><a id =""flow_ld"" href=""#"">" + flow_traduzione + "</a></li>"
        '        Label29.Text = "<li><a id =""probefailure_ld"" href='#'>" + probe_failure_traduzione + "</a></li>"
        '        Label30.Text = "<li><a id =""dosingalarm_ld"" href=""#"">" + dosing_alarm_traduzione + "</a></li>"
        '        Label24.Text = "<li><a id =""parameters_ld"" href=""#"">" + parameters_traduzione + "</a></li>"
        '        Label14.Text = "<li><a id =""international_ld"" href=""#"">" + internationale_traduzione + "</a></li>"
        '        Label20.Text = "<li><a id =""logsetup_ld"" href=""#"">" + log_setup_traduzione + "</a></li>"
        '        'Label15.Text = ""
        '        'For i = 1 To numero_canali + 1
        '        '    If i <= numero_canali Then
        '        '        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
        '        '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_traduzione + " Ch" + i.ToString + " " + label_canale_temp + "</a></li>"
        '        '    Else
        '        '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_all_traduzione + "</a></li>"
        '        '    End If
        '        'Next
        '        enable_ld_log.Visible = True
        '        enable_ld4_log.Visible = False
        '        enable_ldma_log.Visible = False
        '        enable_ldlg_log.Visible = False


            Case "LD"
                refresh_link.NavigateUrl = "~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"
                If Mid(config_value(3), 3, 3) <> "306" Then ' terzo canale esistente
                    numero_canali = 3
                Else
                    numero_canali = 2
                End If
                nome_strumento = main_function.get_split_str(riga_strumento.nome)
                If InStr(nome_strumento(2), "LDDT") <> 0 Then
                    Label18.Text = "<li><a id =""setpoint_lddt"" href='#'>" + SetPoint_traduzione + "</a></li>"
                Else
                    If Val(main_function.get_version(riga_strumento.nome)) < 800 Then
                        Label18.Text = "<li><a id =""setpoint_ld"" href='#'>" + SetPoint_traduzione + "</a></li>"
                    Else
                        Label18.Text = "<li><a id =""setpoint_lddp"" href='#'>" + SetPoint_traduzione + "</a></li>"
                    End If

                End If




                    If Val(main_function.get_version(riga_strumento.nome)) < 420 Then

                    Literal1.Text = "<li><a id =""manual_ld"" href='#'>" + Manual_traduzione + "</a></li>"
                    Literal2.Text = "<li><a id =""message_ld"" href='#'>" + Message_traduzione + "</a></li>"
                    Literal3.Text = "<li><a id =""calibration_ldd"" href='#'>" + Calibration_traduzione + "</a></li>"
                    Literal1.Visible = False
                    Literal2.Visible = False
                    Literal3.Visible = False
                    Label22.Visible = False
                    Label26.Visible = False
                Else
                    If Val(main_function.get_version(riga_strumento.nome)) < 800 Then
                        Literal1.Text = "<li><a id =""manual_ld"" href='#'>" + Manual_traduzione + "</a></li>"
                        Literal2.Text = "<li><a id =""message_ld"" href='#'>" + Message_traduzione + "</a></li>"
                        Literal3.Text = "<li><a id =""calibration_ldd"" href='#'>" + Calibration_traduzione + "</a></li>"
                        Literal1.Visible = True
                        Literal2.Visible = True
                        Literal3.Visible = True
                        Label22.Visible = False
                        Label26.Visible = False
                    Else
                        Literal1.Text = "<li><a id =""manual_ld"" href='#'>" + Manual_traduzione + "</a></li>"
                        Literal2.Text = "<li><a id =""message_ld"" href='#'>" + Message_traduzione + "</a></li>"
                        Literal3.Text = "<li><a id =""calibration_ldd"" href='#'>" + Calibration_traduzione + "</a></li>"
                        Literal1.Visible = True
                        Literal2.Visible = True
                        Literal3.Visible = True
                        Label22.Visible = False
                        Label26.Visible = False
                    End If
                End If

                Literal6.Visible = False

                Label16.Text = "<li><a id ='maoutput_ld' href='#'>" + ma_output_traduzione + "</a></li>"
                Label27.Text = "<li><a id =""rangealarm_ld"" href=""#"">" + range_alarm_traduzione + "</a></li>"
                Label28.Text = "<li><a id =""flow_ld"" href=""#"">" + flow_traduzione + "</a></li>"
                Label29.Text = "<li><a id =""probefailure_ld"" href='#'>" + probe_failure_traduzione + "</a></li>"
                Label30.Text = "<li><a id =""dosingalarm_ld"" href=""#"">" + dosing_alarm_traduzione + "</a></li>"
                Label24.Text = "<li><a id =""parameters_ld"" href=""#"">" + parameters_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""international_ld"" href=""#"">" + internationale_traduzione + "</a></li>"
                Label20.Text = "<li><a id =""logsetup_ld"" href=""#"">" + log_setup_traduzione + "</a></li>"
                'Label15.Text = ""
                'For i = 1 To numero_canali + 1
                '    If i <= numero_canali Then
                '        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
                '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_traduzione + " Ch" + i.ToString + " " + label_canale_temp + "</a></li>"
                '    Else
                '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_all_traduzione + "</a></li>"
                '    End If
                'Next
                enable_ld_log.Visible = True
                enable_ld4_log.Visible = False
                enable_ldma_log.Visible = False
                enable_ldlg_log.Visible = False
            Case "LDS"
                refresh_link.NavigateUrl = "~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"
                If Val(main_function.get_version(riga_strumento.nome)) < 420 Then
                    Label18.Text = "<li><a id =""setpoint_lds"" href='#'>" + SetPoint_traduzione + "</a></li>"
                    Literal1.Text = "<li><a id =""manual_ld"" href='#'>" + Manual_traduzione + "</a></li>"
                    Literal2.Text = "<li><a id =""message_ld"" href='#'>" + Message_traduzione + "</a></li>"
                    Literal3.Text = "<li><a id =""calibration_ldd"" href='#'>" + Calibration_traduzione + "</a></li>"
                    Label16.Text = "<li><a id ='maoutput_lds' href='#'>" + ma_output_traduzione + "</a></li>"
                    Literal1.Visible = False
                    Literal2.Visible = False
                    Literal3.Visible = False
                    Label22.Visible = False
                    Label26.Visible = False
                Else
                    If Val(main_function.get_version(riga_strumento.nome)) < 430 Then
                        Label18.Text = "<li><a id =""setpoint_ldsB"" href='#'>" + SetPoint_traduzione + "</a></li>"
                        Literal1.Text = "<li><a id =""manual_lds"" href='#'>" + Manual_traduzione + "</a></li>"
                        Literal2.Text = "<li><a id =""message_lds"" href='#'>" + Message_traduzione + "</a></li>"
                        Literal3.Text = "<li><a id =""calibration_lds"" href='#'>" + Calibration_traduzione + "</a></li>"

                        Label22.Text = "<li><a id =""Self_clean"" href='#'>" + Self_traduzione + "</a></li>"
                        Label26.Text = "<li><a id =""Circulation"" href='#'>" + Circulation_traduzione + "</a></li>"

                        Label16.Text = "<li><a id ='maoutput_lds' href='#'>" + ma_output_traduzione + "</a></li>"

                        Literal1.Visible = True
                        Literal2.Visible = True
                        Literal3.Visible = True
                        Label22.Visible = True
                        Label26.Visible = True

                    Else
                        Label18.Text = "<li><a id =""setpoint_ldsC"" href='#'>" + SetPoint_traduzione + "</a></li>"
                        Literal1.Text = "<li><a id =""manual_lds"" href='#'>" + Manual_traduzione + "</a></li>"
                        Literal2.Text = "<li><a id =""message_lds"" href='#'>" + Message_traduzione + "</a></li>"
                        Literal3.Text = "<li><a id =""calibration_lds"" href='#'>" + Calibration_traduzione + "</a></li>"

                        Label22.Text = "<li><a id =""Self_clean"" href='#'>" + Self_traduzione + "</a></li>"
                        Label26.Text = "<li><a id =""Circulation"" href='#'>" + Circulation_traduzione + "</a></li>"

                        Label16.Text = "<li><a id ='maoutput_ldsC' href='#'>" + ma_output_traduzione + "</a></li>"


                        Literal1.Visible = True
                        Literal2.Visible = True
                        Literal3.Visible = True
                        Label22.Visible = True
                        Label26.Visible = True
                    End If

                End If

                Literal6.Visible = False


                Label27.Text = "<li><a id =""rangealarm_lds"" href=""#"">" + range_alarm_traduzione + "</a></li>"
                Label28.Text = "<li><a id =""flow_lds"" href=""#"">" + flow_traduzione + "</a></li>"
                Label29.Text = "<li><a id =""probefailure_lds"" href='#'>" + probe_failure_traduzione + "</a></li>"
                Label30.Text = "<li><a id =""dosingalarm_lds"" href=""#"">" + dosing_alarm_traduzione + "</a></li>"
                Label24.Text = "<li><a id =""parameters_lds"" href=""#"">" + parameters_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""international_lds"" href=""#"">" + internationale_traduzione + "</a></li>"
                Label20.Text = "<li><a id =""logsetup_lds"" href=""#"">" + log_setup_traduzione + "</a></li>"
                'Label15.Text = ""
                'numero_canali = 1
                'For i = 1 To numero_canali + 1
                '    If i <= numero_canali Then
                '        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
                '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_traduzione + " Ch" + i.ToString + " " + label_canale_temp + "</a></li>"
                '    Else
                '        Label15.Text = Label15.Text + "<li><a id =""log_" + i.ToString + """ href=""#"">" + log_all_traduzione + "</a></li>"
                '    End If
                'Next
                enable_ld_log.Visible = True
                enable_ld4_log.Visible = False
                enable_ldma_log.Visible = False
                enable_ldlg_log.Visible = False
            Case "LD4"
                refresh_link.NavigateUrl = "~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"
                numero_canali = 4
                Label18.Text = "<li><a id =""setpoint_ld4"" href='#'>" + SetPoint_traduzione + "</a></li>"

                Literal1.Text = "<li><a id =""manual_ld4"" href='#'>" + Manual_traduzione + "</a></li>"
                Literal2.Text = "<li><a id =""message_ld4"" href='#'>" + Message_traduzione + "</a></li>"
                Literal3.Text = "<li><a id =""calibration_ld4"" href='#'>" + Calibration_traduzione + "</a></li>"
                Literal1.Visible = True
                Literal2.Visible = True
                Literal3.Visible = True

                'Literal6.Visible = True
                Literal6.Visible = False


                Label16.Text = "<li><a id ='wmeter_ld4' href='#'>" + wmeter_traduzione + "</a></li>"

                Label27.Text = "<li><a id =""rangealarm_ld4"" href=""#"">" + range_alarm_traduzione + "</a></li>"
                Label28.Text = "<li><a id =""flow_ld4"" href=""#"">" + flow_traduzione + "</a></li>"
                Label29.Text = "<li><a id =""probefailure_ld4"" href='#'>" + probe_failure_traduzione + "</a></li>"
                Label30.Text = "<li><a id =""dosingalarm_ld4"" href=""#"">" + dosing_alarm_traduzione + "</a></li>"
                Label24.Text = "<li><a id =""parameters_ld4"" href=""#"">" + parameters_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""international_ld4"" href=""#"">" + internationale_traduzione + "</a></li>"
                Label20.Text = "<li><a id =""logsetup_ld4"" href=""#"">" + log_setup_traduzione + "</a></li>"
                'Literal6.Text = "<li><a id =""flowall2_ld4"" href=""#"">" + flowall_traduzione + "</a></li>"
                enable_ld_log.Visible = False
                enable_ld4_log.Visible = True
                enable_ldma_log.Visible = False
                enable_ldlg_log.Visible = False
            Case "LDMA"
                refresh_link.NavigateUrl = "~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=45" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"
                numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
                Label33.Text = "<li class='active'><a id ='channels_id_ldma' href='#'>" + GetGlobalResourceObject("ld_global", "ld_ma_channel") + "</a></li>"
                Label18.Text = ""
                For i = 1 To numero_canali
                    Select Case i
                        Case 1
                            Label18.Text = Label18.Text + "<li><a id =""setpoint_ldma" + Format(i, "0") + """ href='#'>" + main_function_config.get_name_level1(setpntr_value) + "</a></li>"
                        Case 2
                            Label18.Text = Label18.Text + "<li><a id =""setpoint_ldma" + Format(i, "0") + """ href='#'>" + main_function_config.get_name_level2(setpntr_value) + "</a></li>"
                        Case 3
                            Label18.Text = Label18.Text + "<li><a id =""setpoint_ldma" + Format(i, "0") + """ href='#'>" + main_function_config.get_name_level3(setpntr_value) + "</a></li>"
                        Case 4
                            Label18.Text = Label18.Text + "<li><a id =""setpoint_ldma" + Format(i, "0") + """ href='#'>" + main_function_config.get_name_level4(setpntr_value) + "</a></li>"
                        Case 5
                            Label18.Text = Label18.Text + "<li><a id =""setpoint_ldma" + Format(i, "0") + """ href='#'>" + main_function_config.get_name_level5(setpntr_value) + "</a></li>"
                    End Select

                Next
                PlaceHolder1.Visible = False

                Label16.Visible = False

                Label22.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                Label28.Visible = False
                Label29.Visible = False
                Label30.Visible = False
                Literal6.Visible = False
                Label24.Text = "<li><a id =""parameters_ldma"" href=""#"">" + parameters_traduzione + "</a></li>"
                Literal2.Text = "<li><a id =""message_ldma"" href='#'>" + Message_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""clock_ldma"" href=""#"">" + GetGlobalResourceObject("ld_global", "ld_ma_date") + "</a></li>"
                Literal1.Visible = False
                Literal3.Visible = False
                Label20.Text = "<li><a id =""logsetup_ldma"" href=""#"">" + log_setup_traduzione + "</a></li>"
                enable_ld_log.Visible = False
                enable_ld4_log.Visible = False
                enable_ldma_log.Visible = True
                enable_ldlg_log.Visible = False
            Case "LDLG"
                refresh_link.NavigateUrl = "~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=58" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"
                numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
                Label33.Text = "<li class='active'><a id ='channels_id_ldlg' href='#'>" + GetGlobalResourceObject("ld_global", "ld_ma_channel") + "</a></li>"
                Label18.Text = ""
                For i = 1 To numero_canali * 2
                    If i <= numero_canali Then
                        Label18.Text = Label18.Text + "<li><a id =""setpoint_ldlg" + Format(i, "0") + """ href='#'>" + main_function_config.get_name_pump(setpntr_value, i) + "</a></li>"
                    Else
                        Label18.Text = Label18.Text + "<li><a id =""setpoint_ldlg" + Format(i + (5 - numero_canali), "0") + """ href='#'>" + main_function_config.get_name_wm(setpntr_value, i + (5 - numero_canali)) + "</a></li>"
                    End If


                Next
                Label18.Text = Label18.Text + "<li><a id =""setpoint_diff"" href='#'>" + main_function_config.get_name_differential(setpntr_value) + "</a></li>"
                PlaceHolder1.Visible = False

                Label16.Visible = False

                Label22.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                Label28.Visible = False
                Label29.Visible = False
                Label30.Visible = False
                Literal6.Visible = False
                Label24.Text = "<li><a id =""parameters_ldlg"" href=""#"">" + parameters_traduzione + "</a></li>"
                Literal2.Visible = False
                Label14.Text = "<li><a id =""clock_ldlg"" href=""#"">" + GetGlobalResourceObject("ld_global", "ld_ma_date") + "</a></li>"
                Literal1.Visible = False
                Literal3.Visible = False
                Label20.Text = "<li><a id =""logsetup_ldlg"" href=""#"">" + log_setup_traduzione + "</a></li>"
                enable_ld_log.Visible = False
                enable_ld4_log.Visible = False
                enable_ldma_log.Visible = False
                enable_ldlg_log.Visible = True
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