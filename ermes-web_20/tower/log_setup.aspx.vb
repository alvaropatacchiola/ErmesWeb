Public Class log_setup1
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

  

   

    Private Sub log_setup1_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_log_tower(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_log_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim log_value() As String

        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script


        ' abilito pulsante modifica
        save_logsetuptower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_logsetuptower_new, ""))


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)
        log_value = main_function.get_split_str(riga_strumento.value12)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)


        If international_unit = "US" Then
            function_java = function_java + "activate_time_picker_12();"
            log_12.Visible = True
            log_24.Visible = False
        Else
            function_java = function_java + "activate_time_picker_24();"
            log_24.Visible = True
            log_12.Visible = False
        End If

        If Val(Mid(log_value(0), 3, 1)) Then
            log_enable.Checked = True
            function_java = function_java + "enable_log();"
        Else
            log_disable.Checked = True
            function_java = function_java + "disable_log();"
        End If


        value_log_time_24.Text = Mid(log_value(0), 4, 2) + ":" + Mid(log_value(0), 6, 2)

        If Val(Mid(log_value(0), 8, 1)) Then
            value_log_time_12.Text = Mid(log_value(0), 4, 2) + ":" + Mid(log_value(0), 6, 2) + " am"
        Else
            value_log_time_12.Text = Mid(log_value(0), 4, 2) + ":" + Mid(log_value(0), 6, 2) + " pm"
        End If

        value_log_every_h.Text = Mid(log_value(0), 10, 2) ' Every Hour
        value_log_every_m.Text = Mid(log_value(0), 12, 2) ' Every Minute

        java_script_flow.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function MakeLog() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""

        Dim date_time_temp As Date

        Dim Enable As Integer
        Dim risultato As String = ""
        Dim AM As Integer
        Dim PM As String
        Dim app_timeh_log As String
        Dim app_timem_log As String

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)

        If (log_disable.Checked) Then
            Enable = 0
        Else
            Enable = 1
        End If
        If international_unit = "US" Then
            If InStr(value_log_time_12.Text, "am") Then 'am
                AM = 1
                PM = 0
            Else
                AM = 0
                PM = 1
            End If
            date_time_temp = Date.Parse(value_log_time_12.Text)
            app_timeh_log = date_time_temp.ToString("hh")
            app_timem_log = date_time_temp.ToString("mm")

        Else
            AM = 0
            PM = 1
            date_time_temp = Date.Parse(value_log_time_24.Text)
            app_timeh_log = date_time_temp.ToString("HH")
            app_timem_log = date_time_temp.ToString("mm")
        End If


        risultato = "MT" + Format(Enable, "0") + app_timeh_log + app_timem_log + Format(AM, "0") + Format(PM, "0") + Format(Val(value_log_every_h.Text), "00") + Format(Val(value_log_every_m.Text), "00")
        Return id_485_impianto + "logsew" + risultato + "logsewend" & Chr(13)

    End Function

    Protected Sub save_logsetuptower_new_Click(sender As Object, e As EventArgs) Handles save_logsetuptower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeLog()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=10" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class