Public Class calibration
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""

    Private Sub calibration_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
       
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")

            posiziona_calibration(nome_impianto, codice_impianto, id_485_impianto, "Calibration")

        End If
    End Sub
    Public Sub posiziona_calibration(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                              ByVal calibration_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim letture_value() As String
        Dim calibration_value() As String
        Dim config_value() As String
        Dim option_value() As String
        Dim fattore_divisione_temp As Integer
        Dim valore_canale_temp As Single = 0
        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(14, 1) As String

        Dim j As Integer
        Dim label_canale_temp As String = ""

        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_calibration_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_calibration_new, ""))


        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next


        letture_value = main_function.get_split_str(riga_strumento.value2)
        calibration_value = main_function.get_split_str(riga_strumento.value15)
        config_value = main_function.get_split_str(riga_strumento.value1)
        option_value = main_function.get_split_str(riga_strumento.value4)
        For j = 0 To 14
            set_variable_javascript(j, 0) = ""
            set_variable_javascript(j, 1) = ""
        Next

        For j = 1 To calibration_value.Length - 1
            label_canale_temp = main_function_config.get_tipo_strumento_max5(j, config_value(j - 1), option_value(0), fattore_divisione_temp)
            Dim valore_canale() As String = calibration_value(j - 1).Split(":")
            valore_canale_temp = Val(Mid(letture_value(j - 1), 3, 4)) / fattore_divisione_temp
            Dim temp_calc As Single
            Select Case j
                Case 1
                    ch1_probe_enale_l.Text = label_canale_temp
                    ch1_probe_mv_value.Text = valore_canale(1)
                    ch1_probe_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    ch1_new_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    set_variable_javascript(0, 0) = "max_ch1_value"
                    temp_calc = valore_canale_temp + 100 / fattore_divisione_temp
                    set_variable_javascript(0, 1) = temp_calc.ToString
                    If temp_calc < 0 Then
                        temp_calc = 0
                    End If
                    temp_calc = valore_canale_temp - 100 / fattore_divisione_temp
                    set_variable_javascript(0, 1) = set_variable_javascript(0, 1).Replace(",", ".")
                    set_variable_javascript(1, 0) = "min_ch1_value"
                    set_variable_javascript(1, 1) = temp_calc.ToString
                    set_variable_javascript(1, 1) = set_variable_javascript(1, 1).Replace(",", ".")
                    set_variable_javascript(2, 0) = "ch1_fix"
                    set_variable_javascript(2, 1) = check_fix(fattore_divisione_temp)
                Case 2
                    ch2_probe_enale_l.Text = label_canale_temp
                    ch2_probe_mv_value.Text = valore_canale(1)
                    ch2_probe_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    ch2_new_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    set_variable_javascript(3, 0) = "max_ch2_value"
                    temp_calc = valore_canale_temp + 100 / fattore_divisione_temp
                    set_variable_javascript(3, 1) = temp_calc.ToString
                    set_variable_javascript(3, 1) = set_variable_javascript(3, 1).Replace(",", ".")
                    set_variable_javascript(4, 0) = "min_ch2_value"
                    temp_calc = valore_canale_temp - 100 / fattore_divisione_temp
                    If temp_calc < 0 Then
                        temp_calc = 0
                    End If
                    set_variable_javascript(4, 1) = temp_calc.ToString
                    set_variable_javascript(4, 1) = set_variable_javascript(4, 1).Replace(",", ".")
                    set_variable_javascript(5, 0) = "ch2_fix"
                    set_variable_javascript(5, 1) = check_fix(fattore_divisione_temp)

                Case 3
                    ch3_probe_enale_l.Text = label_canale_temp
                    ch3_probe_mv_value.Text = valore_canale(1)
                    ch3_probe_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    ch3_new_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    set_variable_javascript(6, 0) = "max_ch3_value"
                    temp_calc = valore_canale_temp + 100 / fattore_divisione_temp
                    set_variable_javascript(6, 1) = temp_calc.ToString
                    set_variable_javascript(6, 1) = set_variable_javascript(6, 1).Replace(",", ".")
                    set_variable_javascript(7, 0) = "min_ch3_value"
                    temp_calc = valore_canale_temp - 100 / fattore_divisione_temp
                    If temp_calc < 0 Then
                        temp_calc = 0
                    End If
                    set_variable_javascript(7, 1) = temp_calc.ToString
                    set_variable_javascript(7, 1) = set_variable_javascript(7, 1).Replace(",", ".")
                    set_variable_javascript(8, 0) = "ch3_fix"
                    set_variable_javascript(8, 1) = check_fix(fattore_divisione_temp)

                Case 4
                    ch4_probe_enale_l.Text = label_canale_temp
                    ch4_probe_mv_value.Text = valore_canale(1)
                    ch4_probe_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    ch4_new_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    set_variable_javascript(9, 0) = "max_ch4_value"
                    temp_calc = valore_canale_temp + 100 / fattore_divisione_temp
                    set_variable_javascript(9, 1) = temp_calc.ToString
                    set_variable_javascript(9, 1) = set_variable_javascript(9, 1).Replace(",", ".")
                    set_variable_javascript(10, 0) = "min_ch4_value"
                    temp_calc = valore_canale_temp - 100 / fattore_divisione_temp
                    If temp_calc < 0 Then
                        temp_calc = 0
                    End If
                    set_variable_javascript(10, 1) = temp_calc.ToString
                    set_variable_javascript(10, 1) = set_variable_javascript(10, 1).Replace(",", ".")
                    set_variable_javascript(11, 0) = "ch4_fix"
                    set_variable_javascript(11, 1) = check_fix(fattore_divisione_temp)

                Case 5
                    ch5_probe_enale_l.Text = label_canale_temp
                    ch5_probe_mv_value.Text = valore_canale(1)
                    ch5_probe_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    ch5_new_value.Text = Replace(valore_canale_temp.ToString(), ",", ".")
                    set_variable_javascript(12, 0) = "max_ch5_value"
                    temp_calc = valore_canale_temp + 100 / fattore_divisione_temp
                    set_variable_javascript(12, 1) = temp_calc.ToString
                    set_variable_javascript(12, 1) = set_variable_javascript(12, 1).Replace(",", ".")
                    set_variable_javascript(13, 0) = "min_ch5_value"
                    temp_calc = valore_canale_temp - 100 / fattore_divisione_temp
                    If temp_calc < 0 Then
                        temp_calc = 0
                    End If
                    set_variable_javascript(13, 1) = temp_calc.ToString
                    set_variable_javascript(13, 1) = set_variable_javascript(13, 1).Replace(",", ".")
                    set_variable_javascript(14, 0) = "ch5_fix"
                    set_variable_javascript(14, 1) = check_fix(fattore_divisione_temp)

            End Select


        Next

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 14)
        java_script_variable.call_function_javascript_onload(Page, "enable_channel_calibrazione(" + (calibration_value.Length - 1).ToString + ");")

    End Sub
    Private Function check_fix(ByVal factor_divide As Integer) As Integer
        Select Case factor_divide
            Case 1
                Return 0
            Case 10
                Return 1
            Case 100
                Return 2
            Case 1000
                Return 3
        End Select
    End Function
    Private Function MakeCalibration() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim config_value() As String
        Dim option_value() As String
        Dim fattore_divisione_temp As Integer


        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        option_value = main_function.get_split_str(riga_strumento.value4)


        Dim stringa_finale As String = ""
        If (ch1_probe_enale.Checked) Then
            main_function_config.get_tipo_strumento_max5(1, config_value(0), option_value(0), fattore_divisione_temp)
            stringa_finale = "1"
            Dim current_value As Integer
            Dim setting_value As Integer
            current_value = Val(ch1_probe_value.Text) * fattore_divisione_temp
            setting_value = Val(ch1_new_value.Text) * fattore_divisione_temp

            If InStr(ch1_probe_enale_l.Text, "Cl") <> 0 Then
                stringa_finale = stringa_finale + Format(setting_value, "0000")
            Else
                If setting_value - current_value < 0 Then
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "000")
                Else
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "0000")
                End If
            End If
        Else
            stringa_finale = "00000"
        End If
        If (ch2_probe_enale.Checked) Then
            stringa_finale = stringa_finale + "1"
            Dim current_value As Integer
            Dim setting_value As Integer
            main_function_config.get_tipo_strumento_max5(2, config_value(1), option_value(0), fattore_divisione_temp)
            current_value = Val(ch2_probe_value.Text) * fattore_divisione_temp
            setting_value = Val(ch2_new_value.Text) * fattore_divisione_temp
            If InStr(ch2_probe_enale_l.Text, "Cl") <> 0 Then
                stringa_finale = stringa_finale + Format(setting_value, "0000")
            Else
                If setting_value - current_value < 0 Then
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "000")
                Else
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "0000")
                End If

            End If
        Else
            stringa_finale = stringa_finale + "00000"
        End If
        If (ch3_probe_enale.Checked) Then
            main_function_config.get_tipo_strumento_max5(3, config_value(2), option_value(0), fattore_divisione_temp)
            stringa_finale = stringa_finale + "1"
            Dim current_value As Integer
            Dim setting_value As Integer
            current_value = Val(ch3_probe_value.Text) * fattore_divisione_temp
            setting_value = Val(ch3_new_value.Text) * fattore_divisione_temp
            If InStr(ch3_probe_enale_l.Text, "Cl") <> 0 Then
                stringa_finale = stringa_finale + Format(setting_value, "0000")
            Else
                If setting_value - current_value < 0 Then
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "000")
                Else
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "0000")
                End If

            End If
        Else
            stringa_finale = stringa_finale + "00000"
        End If
        If (ch4_probe_enale.Checked) Then
            main_function_config.get_tipo_strumento_max5(4, config_value(3), option_value(0), fattore_divisione_temp)
            stringa_finale = stringa_finale + "1"
            Dim current_value As Integer
            Dim setting_value As Integer
            current_value = Val(ch4_probe_value.Text) * fattore_divisione_temp
            setting_value = Val(ch4_new_value.Text) * fattore_divisione_temp
            If InStr(ch4_probe_enale_l.Text, "Cl") <> 0 Then
                stringa_finale = stringa_finale + Format(setting_value, "0000")
            Else
                If setting_value - current_value < 0 Then
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "000")
                Else
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "0000")
                End If

            End If
        Else
            stringa_finale = stringa_finale + "00000"
        End If
        If (ch5_probe_enale.Checked) Then
            main_function_config.get_tipo_strumento_max5(5, config_value(4), option_value(0), fattore_divisione_temp)
            stringa_finale = stringa_finale + "1"
            Dim current_value As Integer
            Dim setting_value As Integer
            current_value = Val(ch5_probe_value.Text) * fattore_divisione_temp
            setting_value = Val(ch5_new_value.Text) * fattore_divisione_temp
            If InStr(ch5_probe_enale_l.Text, "Cl") <> 0 Then
                stringa_finale = stringa_finale + Format(setting_value, "0000")
            Else
                If setting_value - current_value < 0 Then
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "000")
                Else
                    stringa_finale = stringa_finale + Format(setting_value - current_value, "0000")
                End If

            End If
        Else
            stringa_finale = stringa_finale + "00000"
        End If
        Return id_485_impianto + "2Hph" + stringa_finale + "end" & Chr(13)
    End Function

    Protected Sub save_calibration_new_Click(sender As Object, e As EventArgs) Handles save_calibration_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeCalibration()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        'javascript_function.call_function_javascript_onload(Page, "result_setpoint_change();")
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=7&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class