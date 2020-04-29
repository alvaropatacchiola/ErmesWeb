Public Class flow_lta
        Inherits lingua

        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""
        Private Shared canale As String = ""


    Private Sub flow_lta_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_flow_lta(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "out_of_range_alarm"), GetGlobalResourceObject("ld_global", "min_max_high"), GetGlobalResourceObject("ld_global", "min_max_low"), GetGlobalResourceObject("ld_global", "time"))
        End If
    End Sub
    Public Sub posiziona_flow_lta(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                          ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                           ByVal time_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim flow_value() As String
        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script

        Dim data_sp() As String
        Dim calibrz_value() As String

        Dim label_canale_temp As String = ""
        Dim full_scale_temp As Single

        Dim label_canale2_temp As String = ""
        Dim full_scale_temp2 As Single

        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0
        Dim etichetta_setpoint As String = ""
        Dim etichetta_setpoint2 As String = ""






        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next


        ' abilito pulsante modifica
        save_flowlta_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_flowlta_new, ""))



        flow_value = main_function.get_split_str(riga_strumento.value11)

        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        data_sp = main_function.get_split_str(riga_strumento.value7)


        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)

        Dim set_variable_javascript(5, 1) As String



        set_variable_javascript(0, 0) = "max_ch1_value"
        set_variable_javascript(0, 1) = full_scale_temp.ToString
        set_variable_javascript(1, 0) = "min_ch1_value"
        set_variable_javascript(1, 1) = "0"
        set_variable_javascript(2, 0) = "max_ch2_value"
        set_variable_javascript(2, 1) = full_scale_temp2.ToString
        set_variable_javascript(3, 0) = "min_ch2_value"
        set_variable_javascript(3, 1) = "0"
        set_variable_javascript(4, 0) = "max_fix_value1"
        set_variable_javascript(4, 1) = set_fullscale(full_scale_temp).ToString
        set_variable_javascript(5, 0) = "max_fix_value2"
        set_variable_javascript(5, 1) = set_fullscale(full_scale_temp2).ToString

        java_script_flow.set_url_setpoint(Page, set_variable_javascript, 5)


        Dim mode_flow As String
        Dim time_flow As String

        mode_flow = Mid(flow_value(1), 1, 1)
        time_flow = Mid(flow_value(2), 1, 2)


        If mode_flow = "0" Then 'disable
            alarm_flow_disable.Checked = True 'dis
            function_java = "disable_flow();"
        End If
        If mode_flow = "1" Then 'reverse
            alarm_flow_reverse.Checked = True 'rev
            function_java = "enable_flow();"
        End If
        If mode_flow = "2" Then 'direct
            alarm_flow_direct.Checked = True 'dir
            function_java = "enable_flow();"
        End If


        




        value_alarm_flow_time.Text = Val(time_flow).ToString
        java_script_flow.call_function_javascript_onload(Page, function_java)
    End Sub
        Private Function MakeFlowString() As String

            Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
            Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

            Dim Risultato As String
            Dim app_mode_flow As String
            Dim app_time_flow As String
            Dim calibrz_value() As String
            Dim fattore_divisione_temp As Integer = 0
            Dim fattore_divisione_temp2 As Integer = 0



            If alarm_flow_disable.Checked = True Then 'disable
                app_mode_flow = "0"
            End If
            If alarm_flow_direct.Checked = True Then 'direct
            app_mode_flow = "2"
            End If
            If alarm_flow_reverse.Checked = True Then 'reverse
            app_mode_flow = "1"
            End If


            app_time_flow = Format(Val(value_alarm_flow_time.Text), "00")


            tabella_strumento = (Session("strumento"))

            For Each dc1 In tabella_strumento
                If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                    riga_strumento = dc1
                End If
            Next

            calibrz_value = main_function.get_split_str(riga_strumento.value4)


            Dim fattore_ch1 As Integer
            Dim fattore_ch2 As Integer


            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2)

            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then

                Risultato = app_mode_flow + app_time_flow


            Else


                Dim app_mode_soglia As String
                Dim app_time_soglia As String
                Dim app_soglia_max As String
                Dim app_soglia_min As String

                Dim app_soglia_max_i As Integer
                Dim app_soglia_min_i As Integer



                Dim label_canale_temp As String = ""
                Dim full_scale_temp As Single

                Dim label_canale2_temp As String = ""
                Dim full_scale_temp2 As Single


                Dim etichetta_setpoint As String = ""
                Dim etichetta_setpoint2 As String = ""



                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
                label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)



               



            Risultato = app_mode_flow + app_time_flow



            End If



            Return id_485_impianto + "flowsw" + Risultato + "flowswend" & Chr(13)

        End Function


        Public Function set_fullscale(ByVal range As Single) As Integer
            If range >= 0 And range <= 9.9990000000000006 Then
                Return 3
            End If
            If range >= 10 And range <= 99.989999999999995 Then
                Return 2
            End If
            If range >= 100 And range <= 999.89999999999998 Then
                Return 1
            End If
            If range >= 1000 And range <= 9999 Then
                Return 0
            End If
        End Function


    Protected Sub save_flowlta_new_Click(sender As Object, e As EventArgs) Handles save_flowlta_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeFlowString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/lta.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=3" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
    End Class