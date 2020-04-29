Public Class lta

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

        result = Page.Request("result")



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
            refresh_lta(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("impianto_global", "codice"), GetGlobalResourceObject("impianto_global", "referente"), statistica, GetGlobalResourceObject("impianto_global", "statistica"), GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), "Log", "Log All",
                       GetGlobalResourceObject("ld_global", "setpoint"), GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "range_alarm"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "parameters"), GetGlobalResourceObject("ld_global", "international"), GetGlobalResourceObject("ld_global", "log_setup"),
                        GetGlobalResourceObject("ld_global", "manual"), GetGlobalResourceObject("ld_global", "message"), GetGlobalResourceObject("ld_global", "calibration"), GetGlobalResourceObject("ld_global", "Meter"), GetGlobalResourceObject("ld_global", "Flowall"), GetGlobalResourceObject("ld_global", "Self"), GetGlobalResourceObject("ld_global", "Circulation"), GetGlobalResourceObject("ld_global", "System"), GetGlobalResourceObject("ld_global", "Cicli"), GetGlobalResourceObject("ld_global", "AllRead"))
            refresh_link.NavigateUrl = "~/lta.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=0" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&&result=0&refresh=1"
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
    Private Sub refresh_lta(ByVal nome_impianto As String, ByVal codice_impianto As String, ByVal id_485_impianto As String, _
                         ByVal CODE_traduzione As String, ByVal referente_traduzione As String, ByVal statistica As String, _
                         ByVal statistica_traduzione As String, ByVal Strumenti_attivi_traduzione As String, ByVal allarmi_traduzione As String, ByVal log_traduzione As String, _
                         ByVal log_all_traduzione As String, ByVal SetPoint_traduzione As String, ByVal ma_output_traduzione As String, _
                         ByVal range_alarm_traduzione As String, ByVal flow_traduzione As String, ByVal probe_failure_traduzione As String, _
                         ByVal dosing_alarm_traduzione As String, ByVal parameters_traduzione As String, ByVal internationale_traduzione As String, _
        ByVal log_setup_traduzione As String, ByVal Manual_traduzione As String, ByVal Message_traduzione As String, ByVal Calibration_traduzione As String, _
                ByVal wmeter_traduzione As String, ByVal flowall_traduzione As String, ByVal Self_traduzione As String, ByVal Circulation_traduzione As String, ByVal System_traduzione As String, _
                ByVal Cicli_traduzione As String, ByVal allread_traduzione As String)
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
        Dim config_value() As String
        Dim calibrz_value() As String
        Dim indirizzo As String = ""
        Dim check_connected As Boolean = False
        Dim time_connected As Long

        Dim label_canale_temp As String = ""


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
        config_value = main_function.get_split_str(riga_strumento.value1)
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



        'HyperLink1.NavigateUrl = "~/impianto.aspx?nome_impianto=" + nome_impianto
        HyperLink1.NavigateUrl = "~/dashboardNew.aspx"

        Label17.Text = "<h3 class=""heading-mosaic"">" + id_485_impianto + " | " + main_function.get_tipo_strumento(riga_strumento.tipo_strumento) + " " + main_function.get_lebel_485(riga_strumento.nome) + "</h3>"
        'customizzazione link menu per ld e lds
        Select Case riga_strumento.tipo_strumento
            Case "LTA"

                numero_canali = 2


                Label16.Text = "<li><a id =""setpoint_lta"" href='#'>" + SetPoint_traduzione + "</a></li>"
                Label24.Text = "<li><a id =""wmeter_lta"" href='#'>" + wmeter_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""system_lta"" href=""#"">" + System_traduzione + "</a></li>"

                Literal1.Text = "<li><a id =""manual_lta"" href=""#"">" + Manual_traduzione + "</a></li>"
                Literal2.Text = "<li><a id =""message_lta"" href='#'>" + Message_traduzione + "</a></li>"

                'Literal3.Text = "<li><a id =""calibration_lta"" href='#'>" + Calibration_traduzione + "</a></li>"

                Label20.Text = "<li><a id =""logsetup_lta"" href=""#"">" + log_setup_traduzione + "</a></li>"

                'Label25.Text = "<li><a id =""cicli_lta"" href=""#"">" + Cicli_traduzione + "</a></li>"

                'enable_ld_log.Visible = True
                'enable_ld4_log.Visible = False

                If Val(main_function.get_version(riga_strumento.nome)) < 152 Then
                    Literal47.Text = "<li><a id =""flow_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                If (Val(main_function.get_version(riga_strumento.nome)) >= 152 And Val(main_function.get_version(riga_strumento.nome)) < 205) Or Val(main_function.get_version(riga_strumento.nome)) >= 205 Then
                    Literal47.Text = "<li><a id =""flow_minmax_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                If Val(main_function.get_version(riga_strumento.nome)) >= 200 And Val(main_function.get_version(riga_strumento.nome)) < 205 Then
                    Literal47.Text = "<li><a id =""flow_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                Literal57.Text = "<li><a id =""allread_lta"" href=""#"">" + allread_traduzione + "</a></li>"

            Case "LTU"

                numero_canali = 2


                Label16.Text = "<li><a id =""setpoint_lta"" href='#'>" + SetPoint_traduzione + "</a></li>"
                Label24.Text = "<li><a id =""wmeter_lta"" href='#'>" + wmeter_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""system_lta"" href=""#"">" + System_traduzione + "</a></li>"

                Literal1.Text = "<li><a id =""manual_lta"" href=""#"">" + Manual_traduzione + "</a></li>"
                Literal2.Text = "<li><a id =""message_lta"" href='#'>" + Message_traduzione + "</a></li>"

                'Literal3.Text = "<li><a id =""calibration_lta"" href='#'>" + Calibration_traduzione + "</a></li>"

                Label20.Text = "<li><a id =""logsetup_lta"" href=""#"">" + log_setup_traduzione + "</a></li>"

                If Val(main_function.get_version(riga_strumento.nome)) < 152 Then
                    Literal47.Text = "<li><a id =""flow_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                If (Val(main_function.get_version(riga_strumento.nome)) >= 152 And Val(main_function.get_version(riga_strumento.nome)) < 205) Or Val(main_function.get_version(riga_strumento.nome)) >= 205 Then
                    Literal47.Text = "<li><a id =""flow_minmax_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                If Val(main_function.get_version(riga_strumento.nome)) >= 200 And Val(main_function.get_version(riga_strumento.nome)) < 205 Then
                    Literal47.Text = "<li><a id =""flow_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If
                Literal57.Text = "<li><a id =""allread_lta"" href=""#"">" + allread_traduzione + "</a></li>"

            Case "LTD"

                numero_canali = 2


                Label16.Text = "<li><a id =""setpoint_lta"" href='#'>" + SetPoint_traduzione + "</a></li>"
                Label24.Text = "<li><a id =""wmeter_lta"" href='#'>" + wmeter_traduzione + "</a></li>"
                Label14.Text = "<li><a id =""system_lta"" href=""#"">" + System_traduzione + "</a></li>"

                Literal1.Text = "<li><a id =""manual_lta"" href=""#"">" + Manual_traduzione + "</a></li>"
                Literal2.Text = "<li><a id =""message_lta"" href='#'>" + Message_traduzione + "</a></li>"

                'Literal3.Text = "<li><a id =""calibration_lta"" href='#'>" + Calibration_traduzione + "</a></li>"

                Label20.Text = "<li><a id =""logsetup_lta"" href=""#"">" + log_setup_traduzione + "</a></li>"

                If Val(main_function.get_version(riga_strumento.nome)) < 152 Then
                    Literal47.Text = "<li><a id =""flow_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                If (Val(main_function.get_version(riga_strumento.nome)) >= 152 And Val(main_function.get_version(riga_strumento.nome)) < 205) Or Val(main_function.get_version(riga_strumento.nome)) >= 205 Then
                    Literal47.Text = "<li><a id =""flow_minmax_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If

                If Val(main_function.get_version(riga_strumento.nome)) >= 200 And Val(main_function.get_version(riga_strumento.nome)) < 205 Then
                    Literal47.Text = "<li><a id =""flow_lta"" href=""#"">" + flow_traduzione + "</a></li>"
                End If
                Literal57.Text = "<li><a id =""allread_lta"" href=""#"">" + allread_traduzione + "</a></li>"


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