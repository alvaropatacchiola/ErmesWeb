Public Class log_setups
    Inherits lingua

    
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub log_setups_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
   Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_log_lds(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_log_lds(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim formato_d As String

        Dim log_value() As String
        Dim valuer_value() As String

        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script
        ' abilito pulsante modifica
        save_logsetupld_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_logsetupld_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        log_value = main_function.get_split_str(riga_strumento.value15)
        valuer_value = main_function.get_split_str(riga_strumento.value2)

        formato_d = Mid(valuer_value(3), 1, 1)

        Dim enable As String
        Dim time_h As String
        Dim time_m As String
        Dim time_am As String
        Dim time_pm As String
        Dim every_h As String
        Dim every_m As String


        enable = Mid(log_value(1), 1, 1)
        time_h = Mid(log_value(2), 1, 2)
        time_m = Mid(log_value(3), 1, 2)
        time_am = Mid(log_value(6), 1, 1)
        time_pm = Mid(log_value(7), 1, 1)
        every_h = Mid(log_value(4), 1, 2)
        every_m = Mid(log_value(5), 1, 2)


        value_log_time_24.Text = time_h + ":" + time_m
        If time_am = "1" And time_pm = "0" Then
            value_log_time_12.Text = time_h + ":" + time_m + " am"
        End If
        If time_am = "0" And time_pm = "1" Then
            value_log_time_12.Text = time_h + ":" + time_m + " pm"

        End If

        value_log_every_h.Text = every_h
        value_log_every_m.Text = every_m



        'If Main.Formato = 0 Then ' europeo
        If formato_d = "0" Then ' europeo
            function_java = function_java + "activate_time_picker_24();"
            log_24.Visible = True
            log_12.Visible = False
        End If

        'If Main.Formato = 1 Then ' americano
        If formato_d = "1" Then ' americano
            function_java = function_java + "activate_time_picker_12();"
            log_12.Visible = True
            log_24.Visible = False

        End If

        If enable = "0" Then 'disable
            log_disable.Checked = True
            function_java = function_java + "disable_log();"
        End If

        If enable = "1" Then 'enable
            log_enable.Checked = True
            function_java = function_java + "enable_log();"
        End If
        java_script_flow.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function MakeLogSetupString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim valuer_value() As String
        Dim formato_d As String

        Dim Risultato As String
        Dim app_mode_log As String
        Dim app_timeh_log As String
        Dim app_timem_log As String
        Dim app_everyh_log As String
        Dim app_everym_log As String
        Dim app_am_log As String
        Dim app_pm_log As String

        Dim date_time_temp As Date

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        valuer_value = main_function.get_split_str(riga_strumento.value2)

        formato_d = Mid(valuer_value(4), 1, 1)


        If log_enable.Checked = True Then 'enable
            app_mode_log = "1"
        Else
            app_mode_log = "0"
        End If

        'If Main.Formato = 0 Then ' europeo
        If Val(formato_d) = 0 Then ' europeo
            app_am_log = "1"
            app_pm_log = "0"
        End If


        'If Main.Formato = 1 Then ' americano
        If Val(formato_d) = 1 Then ' americano
            If InStr(value_log_time_12.Text, "pm") Then 'pm
                app_am_log = "0"
                app_pm_log = "1"
            End If
            If InStr(value_log_time_12.Text, "am") Then 'am
                app_am_log = "1"
                app_pm_log = "0"
            End If
            date_time_temp = Date.Parse(value_log_time_12.Text)
            app_timeh_log = date_time_temp.ToString("hh")
            app_timem_log = date_time_temp.ToString("mm")
        Else
            date_time_temp = Date.Parse(value_log_time_24.Text)
            app_timeh_log = date_time_temp.ToString("HH")
            app_timem_log = date_time_temp.ToString("mm")
        End If

        app_everyh_log = Format(Val(value_log_every_h.Text), "00")
        app_everym_log = Format(Val(value_log_every_m.Text), "00")

        Risultato = app_mode_log + app_timeh_log + app_timem_log + app_everyh_log + app_everym_log + app_am_log + app_pm_log

        Return id_485_impianto + "logstw" + Risultato + "logstwend" & Chr(13)

    End Function
    Protected Sub save_logsetupld_new_Click(sender As Object, e As EventArgs) Handles save_logsetupld_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeLogSetupString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class