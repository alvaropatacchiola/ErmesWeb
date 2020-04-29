﻿Public Class WebForm3
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub probe_failure_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
      Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_failure_wd(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output", GetGlobalResourceObject("ld_global", "probe_failure"))
        End If
    End Sub
    Public Sub posiziona_failure_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal probe_fail_alarm_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim java_script_probefail As java_script = New java_script
        Dim label_canale_temp As String = ""

        Dim probefail_value() As String
        Dim calibrz_value() As String

        Dim function_java As String = ""
        ' abilito pulsante modifica
        save_probefailurewd_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_probefailurewd_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        probefail_value = main_function.get_split_str(riga_strumento.value10)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        Dim probe_modeph As String
        Dim probe_modecl As String
        Dim probe_timeph As String
        Dim probe_timecl As String
        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2))
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1))
        tabld1_1.Text = label_canale_temp
        Label7.Text = probe_fail_alarm_traduzione + " " + label_canale_temp
        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2))
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(2))
        tabld1_2.Text = label_canale_temp
        Literal2.Text = probe_fail_alarm_traduzione + " " + label_canale_temp

        probe_modeph = Mid(probefail_value(1), 1, 1)
        probe_timeph = Mid(probefail_value(2), 1, 3)
        probe_modecl = Mid(probefail_value(3), 1, 1)
        probe_timecl = Mid(probefail_value(4), 1, 3)

        value_ph_alarm_failure.Text = Val(probe_timeph).ToString
        value_cl_alarm_failure.Text = Val(probe_timecl).ToString

        If probe_timeph = "000" Then ' vuol dire OFF
            ph_alarm_failure_disable.Checked = True 'OFF
            function_java = function_java + "disable_ph_alarm_failure();"

        Else
            ph_alarm_failure_enable.Checked = True 'ON
            function_java = function_java + "enable_ph_alarm_failure();"
        End If
        If probe_modeph = "0" Then ' DOSE
            ph_alarm_failure_dose.Checked = True 'DOSE
        Else
            'RadioButton1.Checked = False 'DOSE
            ph_alarm_failure_stop.Checked = True 'STOP
        End If


        If probe_timecl = "000" Then ' vuol dire OFF" Then
            'RadioButton5.Checked = False 'ON
            cl_alarm_failure_disable.Checked = True 'OFF
            function_java = function_java + "disable_cl_alarm_failure();"
        Else
            cl_alarm_failure_enable.Checked = True 'ON
            'RadioButton6.Checked = False 'OFF
            function_java = function_java + "enable_cl_alarm_failure();"
        End If

        If probe_modecl = "0" Then ' DOSE
            cl_alarm_failure_dose.Checked = True 'DOSE
            'RadioButton9.Checked = False 'STOP
        Else
            'RadioButton10.Checked = False 'DOSE
            cl_alarm_failure_stop.Checked = True 'STOP
        End If
        java_script_probefail.call_function_javascript_onload(Page, function_java)
    End Sub
    Private Function MakeProbeString() As String


        Dim Risultato As String
        Dim app_time_ph As String
        Dim app_time_cl As String
        Dim app_mode_ph As String
        Dim app_mode_cl As String

        If ph_alarm_failure_disable.Checked = True Then 'off
            app_time_ph = "000"
        Else
            app_time_ph = Format(Val(value_ph_alarm_failure.Text), "000")
        End If
        If cl_alarm_failure_disable.Checked = True Then 'off
            app_time_cl = "000"
        Else
            app_time_cl = Format(Val(value_cl_alarm_failure.Text), "000")
        End If

        If ph_alarm_failure_dose.Checked = True Then 'dose
            app_mode_ph = "0"
        Else
            app_mode_ph = "1"
        End If

        If cl_alarm_failure_dose.Checked = True Then 'dose
            app_mode_cl = "0"
        Else
            app_mode_cl = "1"
        End If

        Risultato = app_mode_ph + app_time_ph + app_mode_cl + app_time_cl

        Return id_485_impianto + "allprw" + Risultato + "allprwend" & Chr(13)

    End Function
    Protected Sub save_probefailurewd_new_Click(sender As Object, e As EventArgs) Handles save_probefailurewd_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeProbeString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=1" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class