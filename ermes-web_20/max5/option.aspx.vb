Public Class _option
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""

    Private Sub _option_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")


        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_option(nome_impianto, codice_impianto, id_485_impianto, "Option")

        End If
    End Sub

    Public Sub posiziona_option(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                              ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tipo_personalizzazione As String = ""
        Dim option_value() As String
        Dim java_script_variable As java_script = New java_script
        Dim java_script_variable1 As java_script = New java_script
        Dim function_javascript As String = ""
        Dim set_variable_javascript(2, 1) As String

        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_option_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_option_new, ""))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        tipo_personalizzazione = main_function.get_tipo_personalizzazione(riga_strumento.nome)
        option_value = main_function.get_split_str(riga_strumento.value4)
        Dim temp_calc As Single
        Select Case tipo_personalizzazione
            Case "yagel"
                litre_label.Text = "m3/h"
                Literal11.Visible = False
                Dropdownlist1.Visible = False
                Dim factor_divide_flow As Integer
                If Mid(option_value(1), Len(option_value(1)) - 2, 1) = "1" Then ' fattore divisione 100
                    factor_divide_flow = 100
                    set_variable_javascript(0, 0) = "my_fix_flowmeter"
                    set_variable_javascript(0, 1) = "2"
                    set_variable_javascript(1, 0) = "max_flowmeter"
                    set_variable_javascript(1, 1) = "999.99"

                Else
                    factor_divide_flow = 1000
                    set_variable_javascript(0, 0) = "my_fix_flowmeter"
                    set_variable_javascript(0, 1) = "3"
                    set_variable_javascript(1, 0) = "max_flowmeter"
                    set_variable_javascript(1, 1) = "99.999"

                End If
                temp_calc = Val(Mid(option_value(1), 6, 5)) / factor_divide_flow
                'value_flow_rate_id.Text = Replace(temp_calc.ToString(), ",", ".")
                If factor_divide_flow = 1000 Then
                    value_flow_rate_id.Text = Format(temp_calc, "00.000")
                Else
                    value_flow_rate_id.Text = Format(temp_calc, "000.00")
                End If
                temp_calc = Val(Mid(option_value(1), 11, 4)) / 10
                'value_flow_setpoint_id.Text = Replace(temp_calc.ToString(), ",", ".")
                value_flow_setpoint_id.Text = Format(temp_calc, "000.0")
                temp_calc = Val(Mid(option_value(1), 15, 4)) / 10
                'value_flow_ma_id.Text = Replace(temp_calc.ToString(), ",", ".")
                value_flow_ma_id.Text = Format(temp_calc, "000.0")

                If (Mid(option_value(1), 5, 1) = "1") Then
                    sms_low_flow.Checked = True
                Else
                    sms_low_flow.Checked = False
                End If
            Case Else
                set_variable_javascript(0, 0) = "my_fix_flowmeter"
                set_variable_javascript(0, 1) = 0
                set_variable_javascript(1, 0) = "max_flowmeter"
                set_variable_javascript(1, 1) = 999

                Literal5.Visible = False
                value_flow_setpoint_id.Visible = False
                Literal9.Visible = False
                value_flow_ma_id.Visible = False
                Literal43.Visible = False
                sms_low_flow.Visible = False
                temp_calc = Val(Mid(option_value(1), 5, 3))
                value_flow_rate_id.Text = Replace(temp_calc.ToString(), ",", ".")

        End Select

        temp_calc = Val(Mid(option_value(2), 3, 2)) 'tau
        value_tau_const_id.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(option_value(2), 5, 2)) 'delay
        value_delay_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
        Select Case Mid(option_value(2), 7, 1) ' flow setup
            Case "0"
                direct_id.Checked = True
            Case "1"
                inverse_id.Checked = True
            Case "2"
                disable_id.Checked = True
        End Select
        If Mid(option_value(5), 3, 1) = "1" Then ' sms flow
            Checkbox1.Checked = True
        Else
            Checkbox1.Checked = False
        End If

        Select Case Mid(option_value(2), 8, 1) 'alarme setup
            Case "0" 'continuous
                continuous_id.Checked = True
            Case "1" ' timed
                timed_id.Checked = True
                temp_calc = Val(Mid(option_value(2), 9, 2))
                value_timed_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 11, 2))
                value_timed_sec_id.Text = Replace(temp_calc.ToString(), ",", ".")
        End Select
        Select Case Mid(option_value(2), 13, 1) ' log setup
            Case "0"
                disable_log.Checked = True
                'java_script_variable.call_function_javascript_onload(Page, "disable_log_setup()")
                function_javascript = function_javascript + "disable_log_setup();"
            Case "1"
                enable_log.Checked = True
                'java_script_variable.call_function_javascript_onload(Page, "enable_log_setup()")
                function_javascript = function_javascript + "enable_log_setup();"
                temp_calc = Val(Mid(option_value(2), 14, 2))
                value_start_hr_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 16, 2))
                value_start_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 18, 2))
                value_every_hr_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 20, 2))
                value_every_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 22, 2))
                value_filter_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
        End Select

        Select Case Mid(option_value(2), 25, 1) ' probe clean
            Case "0"
                disable_clean.Checked = True
                ' java_script_variable.call_function_javascript_onload(Page, "disable_probe_clean()")
                function_javascript = function_javascript + "disable_probe_clean();"
            Case "1"
                enable_clean.Checked = True
                'java_script_variable.call_function_javascript_onload(Page, "enable_probe_clean()")
                function_javascript = function_javascript + "enable_probe_clean();"
                temp_calc = Val(Mid(option_value(2), 26, 2))
                value_cycle_hr_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 28, 2))
                value_cycle_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 30, 2))
                value_cleant_hr_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 32, 2))
                value_cleant_min_id.Text = Replace(temp_calc.ToString(), ",", ".")
                temp_calc = Val(Mid(option_value(2), 34, 2))
                value_restore_min_id.Text = Replace(temp_calc.ToString(), ",", ".")

                If (Mid(option_value(2), 36, 1) = "0") Then
                    clean_alarm.SelectedIndex = 0
                Else
                    clean_alarm.SelectedIndex = 1
                End If
        End Select

        Dropdownlist1.Items.Clear() ' inpulsi litro

        Select Case Mid(option_value(1), 3, 1)
            Case "0" ' litri
                enable_litri.Checked = True
                Dropdownlist1.Items.Clear()
                Dropdownlist1.Items.Add("pulse/litre")
                Dropdownlist1.Items.Add("litre/pulse")
                'Unit = "lit"
            Case "1"
                enable_galloni.Checked = True
                Dropdownlist1.Items.Clear()
                Dropdownlist1.Items.Add("pulse/gallons")
                Dropdownlist1.Items.Add("gallons/pulse")
                'Unit = "gal"
        End Select

        Select Case Mid(option_value(1), 4, 1) ' selezione corretta impulsi / litro
            Case "0"
                Dropdownlist1.SelectedIndex = 0
                If Mid(option_value(1), 3, 1) = "0" Then ' imp/litro
                    'yagel
                    Literal5.Text = "SetPoint Low Flow(m3/h)"
                    Literal9.Text = "20mA @ Flow(m3/h)"
                Else
                    'yagel
                    Literal5.Text = "SetPoint Low Flow(g/m)"
                    Literal9.Text = "20mA @ Flow(g/m)"
                End If
            Case "1"
                Dropdownlist1.SelectedIndex = 1
                If Mid(option_value(1), 3, 1) = "0" Then
                    'yagel
                    Literal5.Text = "SetPoint Low Flow(m3/h)"
                    Literal9.Text = "20mA @ Flow(m3/h)"
                Else
                    'yagel
                    Literal5.Text = "SetPoint Low Flow(g/m)"
                    Literal9.Text = "20mA @ Flow(g/m)"
                End If
        End Select

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 2)
        java_script_variable1.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Public Function get_option_new() As String
        Dim Risultato As String
        Dim day_week As Integer = 0
        Dim option_str_new As String = ""
        Dim result_conn_sms_new As String = ""


        option_str_new = "ph" + Format(Val(value_tau_const_id.Text), "00") & Format(Val(value_delay_min_id.Text), "00") 'tau e delay
        If direct_id.Checked Then
            option_str_new = option_str_new & "0"
        End If
        If inverse_id.Checked Then
            option_str_new = option_str_new & "1"
        End If
        If disable_id.Checked Then
            option_str_new = option_str_new & "2"
        End If
        If continuous_id.Checked Then
            option_str_new = option_str_new & "00000"
        Else
            option_str_new = option_str_new & "1" & Format(Val(value_timed_min_id.Text), "00") & Format(Val(value_timed_sec_id.Text), "00")
        End If
        If disable_log.Checked Then
            option_str_new = option_str_new & "000000000000"
        Else
            option_str_new = option_str_new & "1" & Format(Val(value_start_hr_id.Text), "00") & Format(Val(value_start_min_id.Text), "00") & Format(Val(value_every_hr_id.Text), "00") & Format(Val(value_every_min_id.Text), "00") & Format(Val(value_filter_min_id.Text), "00")
            'If cboPrintRS232.Text = "ON" Then
            '    option_str_new = option_str_new & "1"
            'Else
            option_str_new = option_str_new & "0"
            'End If
        End If
        If disable_clean.Checked Then
            option_str_new = option_str_new & "000000000000"
        Else
            option_str_new = option_str_new & "1" & Format(Val(value_cycle_hr_id.Text), "00") & Format(Val(value_cycle_min_id.Text), "00") & Format(Val(value_cleant_hr_id.Text), "00") & Format(Val(value_cleant_min_id.Text), "00") & Format(Val(value_restore_min_id.Text), "00")
            If clean_alarm.SelectedValue = "1" Then ' on
                option_str_new = option_str_new & "1"
            Else
                option_str_new = option_str_new & "0"
            End If
        End If
        If Checkbox1.Visible Then
            If Checkbox1.Checked Then
                result_conn_sms_new = "ph1"
            Else
                result_conn_sms_new = "ph0"
            End If
        Else
            result_conn_sms_new = "null"
        End If

        If result_conn_sms_new = "null" Then
            Risultato = id_485_impianto + "b1" + option_str_new + Chr(13)
        Else
            Risultato = id_485_impianto + "b1" + option_str_new + Replace(result_conn_sms_new, "ph", "") + Chr(13)
        End If

        Return Risultato

    End Function
    Public Function get_option_flow_new(ByVal yagel_version As Boolean) As String
        Dim option_str_flow_new As String = ""
        Dim Risultato As String
        option_str_flow_new = "ph"
        If enable_litri.Checked Then
            option_str_flow_new = option_str_flow_new & "0"
        Else
            option_str_flow_new = option_str_flow_new & "1"
        End If
        If Dropdownlist1.SelectedValue = "0" Then ' imp/litro
            option_str_flow_new = option_str_flow_new & "0"
        Else
            option_str_flow_new = option_str_flow_new & "1"
        End If
        If yagel_version Then 'yagel version
            If sms_low_flow.Checked Then 'sms
                option_str_flow_new = option_str_flow_new & "1"
            Else
                option_str_flow_new = option_str_flow_new & "0"
            End If

            option_str_flow_new = option_str_flow_new & Format(Val(value_flow_rate_id.Text) * 1000, "00000")
            option_str_flow_new = option_str_flow_new & Format(Val(value_flow_setpoint_id.Text) * 10, "0000")
            option_str_flow_new = option_str_flow_new & Format(Val(value_flow_ma_id.Text) * 10, "0000")
            option_str_flow_new = option_str_flow_new & "end"

        Else
            option_str_flow_new = option_str_flow_new & Format(Val(value_flow_rate_id.Text), "000")
            option_str_flow_new = option_str_flow_new & "end"
        End If
        Risultato = id_485_impianto + "b8" + option_str_flow_new + Chr(13)
        Return Risultato

    End Function

    Protected Sub save_option_new_Click(sender As Object, e As EventArgs) Handles save_option_new.Click
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        Dim tipo_personalizzazione As String = ""
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim url_result As String = ""
        Dim errore_primo_invio As Boolean = False
        Dim yagel_version As Boolean = False

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        tipo_personalizzazione = main_function.get_tipo_personalizzazione(riga_strumento.nome)
        Select Case tipo_personalizzazione
            Case "yagel"
                yagel_version = True
            Case Else
                yagel_version = False
        End Select

        local_connection = write_setpoint_new.client_connect()


        If local_connection Then ' connessione OK
            new_setpoint = get_option_new()
            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result, errore_primo_invio)
        Else ' server busy riprovare
            url_result = "result=3"
            errore_primo_invio = True
        End If

        If errore_primo_invio = False Then ' nel primo invio non c'è stato errore invio il secondo blocco
            If local_connection Then ' connessione OK
                new_setpoint = get_option_flow_new(yagel_version)
                write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result, errore_primo_invio)
            Else ' server busy riprovare
                url_result = "result=3"
            End If
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If

        write_setpoint_new.client_close()
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=8&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class