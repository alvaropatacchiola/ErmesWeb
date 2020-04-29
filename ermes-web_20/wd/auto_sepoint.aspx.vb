Public Class auto_sepoint
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""


    Private Sub auto_setpoint_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_auto_setpoint_wd(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output", "Probe Failure Alarm")
        End If
    End Sub
    Public Sub posiziona_auto_setpoint_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                          ByVal setpoint_traduzione As String, ByVal probe_fail_alarm_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim autoset_value() As String
        Dim calibrz_value() As String

        Dim label_canale_temp As String = ""
        Dim full_scale_temp As Single

        Dim label_canale2_temp As String = ""
        Dim full_scale_temp2 As Single

        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0
        Dim etichetta_setpoint As String = ""
        Dim etichetta_setpoint2 As String = ""

        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(5, 1) As String

        Dim java_script_auto_setpoint As java_script = New java_script
        Dim function_java As String = ""



        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        autoset_value = main_function.get_split_str(riga_strumento.value20)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        'label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)
        label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)


        Dim valorepH As String
        Dim Mode As String
        Dim valoremV As String
        'Dim Current_Pass As String
        ' Dim Tau As String



        ' abilito pulsante modifica
        save_auto_setpoint_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                        ClientScript.GetPostBackEventReference(save_auto_setpoint_new, ""))



        ' valorepH = Mid(autoset_value(2), 1, 4)
        Mode = Mid(autoset_value(1), 1, 1)
        'valoremV = Mid(autoset_value(3), 1, 4)

        Dim temp_calc As Single = Val(Mid(autoset_value(2), 1, 4)) / fattore_divisione_temp 'on


        value_ph.Text = Replace(temp_calc.ToString(), ",", ".")


        value_mV.Text = Format(Val(Mid(autoset_value(3), 1, 4)), "0000")



        'value_ph_tau.Text = Val(Tau).ToString
        If Mode = 1 Then  ' pH+
            pHplus.Checked = True
        Else
            pHmeno.Checked = True
        End If


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

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 5)
        java_script_auto_setpoint.call_function_javascript_onload(Page, function_java)



    End Sub

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


    Private Function MakeAutoSetString() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim app As String

        Dim app_valueph_i As Integer
        Dim app_valueph As String
        Dim fattore_divisione_temp As Integer = 0


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)




        If phplus.Checked = True Then
            app = "1"
        Else
            app = "0"
        End If

        'main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
        main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1), fattore_divisione_temp)

        app_valueph_i = Val(value_ph.Text) * fattore_divisione_temp
        app_valueph = Format(app_valueph_i, "0000")


        Risultato = app + app_valueph + Format(Val(value_mV.Text), "0000")
        Return id_485_impianto + "autstw" + Risultato + "autstwend" & Chr(13)




    End Function

    Protected Sub save_auto_setpoint_new_Click(sender As Object, e As EventArgs) Handles save_auto_setpoint_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeAutoSetString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=19" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
    End Sub
End Class


'alvaro
