Public Class allread_lta
    Inherits lingua

        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""
        Private Shared canale As String = ""


    Private Sub allread_lta_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_allread_lta(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "out_of_range_alarm"), GetGlobalResourceObject("ld_global", "min_max_high"), GetGlobalResourceObject("ld_global", "min_max_low"), GetGlobalResourceObject("ld_global", "time"))
        End If
    End Sub
    Public Sub posiziona_allread_lta(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                              ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                               ByVal time_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim allread_value() As String
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
        save_allreadlta_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_allreadlta_new, ""))



        allread_value = main_function.get_split_str(riga_strumento.value21)

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


        Dim temp_value As String
        Dim dioxide_value As String

        Dim temp_show As String
        Dim dioxide_show As String



        temp_value = Mid(allread_value(1), 1, 3)
        temp_show = Mid(allread_value(2), 1, 1)
        dioxide_value = Mid(allread_value(3), 1, 3)
        dioxide_show = Mid(allread_value(4), 1, 1)

        value_alarm_temp.Text = Val(temp_value).ToString



        Dim temp_calc As Single = Val(dioxide_value) / 100
        value_alarm_dioxide.Text = Replace(temp_calc.ToString(), ",", ".")


        If temp_show = "0" Then 'disable
            alarm_temp_hide.Checked = True 'dis

        End If
        If temp_show = "1" Then 'show
            alarm_temp_show.Checked = True 'rev

        End If
        If dioxide_show = "0" Then 'disable
            alarm_dioxide_hide.Checked = True 'dis

        End If
        If dioxide_show = "1" Then 'show
            alarm_dioxide_show.Checked = True 'rev

        End If







        'value_alarm_flow_time.Text = Val(time_flow).ToString
        java_script_flow.call_function_javascript_onload(Page, function_java)
    End Sub
        Private Function MakeFlowString() As String

            Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
            Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

            Dim Risultato As String

        Dim app_mode_temp As String
        Dim app_mode_dioxide As String

        Dim app_value_temp As String
        Dim app_value_dioxide As String
            Dim calibrz_value() As String
          



        If alarm_dioxide_show.Checked = True Then 'disable
            app_mode_dioxide = "1"
        End If
        If alarm_dioxide_hide.Checked = True Then 'direct
            app_mode_dioxide = "0"
        End If
        If alarm_temp_show.Checked = True Then 'reverse
            app_mode_temp = "1"
        End If
        If alarm_temp_hide.Checked = True Then 'reverse
            app_mode_temp = "0"
        End If

        app_value_temp = Format(Val(value_alarm_temp.Text), "000")
        app_value_dioxide = Format(Val(value_alarm_dioxide.Text) * 100, "000")





        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)












        Risultato = app_mode_temp + app_value_temp + app_mode_dioxide + app_value_dioxide







        Return id_485_impianto + "allenw" + Risultato + "allenwend" & Chr(13)

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


    Protected Sub save_allreadlta_new_Click(sender As Object, e As EventArgs) Handles save_allreadlta_new.Click
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

        Response.Redirect("~/lta.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=8" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
    End Class