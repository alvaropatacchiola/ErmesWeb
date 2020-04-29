Public Class timer
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Shared versioneGlobal As Integer = 0

    Private Sub timer_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
      Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_timer(nome_impianto, codice_impianto, id_485_impianto, "Timer")

        End If

    End Sub
    Public Sub posiziona_timer(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                          ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tipo_personalizzazione As String = ""
        Dim timer_value() As String
        Dim timer_new_value() As String
        Dim option_value() As String
        Dim number_version As Integer = 0

        tabella_strumento = (Session("strumento"))

        ' abilito pulsante modifica
        save_timer_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_timer_new, ""))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        tipo_personalizzazione = main_function.get_tipo_personalizzazione(riga_strumento.nome)
        number_version = main_function.get_version_integer(riga_strumento.nome)
        versioneGlobal = number_version
        option_value = main_function.get_split_str(riga_strumento.value4)
        Dim temp_calc As Integer
        Select tipo_personalizzazione
            Case "yagel"
            Case Else

        End Select
        If number_version > 29 Then
            timer_new_value = main_function.get_split_str(riga_strumento.value17)
            set_timer(option_value(0), option_value(3), option_value(4), True)
            set_timer_new(option_value(0), timer_new_value(0), timer_new_value(1), timer_new_value(2), timer_new_value(3))
            set_name_timer(Mid(timer_new_value(4), 3, 10), Mid(timer_new_value(4), 13, 10), Mid(timer_new_value(4), 23, 10), Mid(timer_new_value(4), 33, 10), Mid(timer_new_value(4), 43, 10))
        Else
            set_timer(option_value(0), option_value(3), option_value(4), False)
        End If
    End Sub
    Public Sub set_name_timer(ByVal name1 As String, ByVal name2 As String, ByVal name3 As String, ByVal name4 As String, ByVal name5 As String)
        name1 = name1.Replace("-", "")
        value_timer1_name_id.Text = name1
        name2 = name2.Replace("-", "")
        value_timer2_name_id.Text = name2
        name3 = name3.Replace("-", "")
        value_timer3_name_id.Text = name3
        name4 = name4.Replace("-", "")
        value_timer4_name_id.Text = name4
        name5 = name5.Replace("-", "")
        value_timer5_name_id.Text = name5
    End Sub
    Public Function formatOreMin(ByVal valoreTime As Integer) As String
        Return Format(valoreTime, "00")
    End Function
    Public Sub enable_single_program(ByVal result_conn_data As String, stringa_on As String, ByVal stringa_off As String, ByVal check1 As CheckBox, ByVal time1 As TextBox, ByVal time2 As TextBox)
        Dim tipe_ora As String
        tipe_ora = Mid(result_conn_data, 10, 1)

        If (stringa_on = "0000") And stringa_off = "0000" Then
            check1.Checked = False
        Else
            check1.Checked = True
        End If
        Dim ora1 As Integer
        Dim minuti1 As Integer
        Dim ora2 As Integer
        Dim minuti2 As Integer
        Dim ore1 As String
        Dim minut1 As String
        Dim am_pm1 As String

        Dim ore2 As String
        Dim minut2 As String
        Dim am_pm2 As String

        ora1 = Val(Mid(stringa_on, 1, 2))
        minuti1 = Val(Mid(stringa_on, 3, 2))
        ora2 = Val(Mid(stringa_off, 1, 2))
        minuti2 = Val(Mid(stringa_off, 3, 2))

        If tipe_ora = "0" Then
            If ora1 > 12 Then
                ore1 = formatOreMin((ora1 - 12))
                minut1 = formatOreMin(minuti1)
                am_pm1 = " pm"
            End If
            If ora1 = 12 Then
                ore1 = formatOreMin(ora1)
                minut1 = formatOreMin(minuti1)
                am_pm1 = " pm"
            End If
            If ora1 < 12 Then 'formato europeo
                ore1 = formatOreMin(ora1)
                minut1 = formatOreMin(minuti1)
                am_pm1 = " am"

            End If
            If ora2 > 12 Then
                ore2 = formatOreMin(ora2 - 12)
                minut2 = formatOreMin(minuti2)
                am_pm2 = " pm"
            End If
            If ora2 = 12 Then
                ore2 = formatOreMin(ora2)
                minut2 = formatOreMin(minuti2)
                am_pm2 = " pm"
            End If
            If ora2 < 12 Then 'formato europeo
                ore2 = formatOreMin(ora2)
                minut2 = formatOreMin(minuti2)
                am_pm2 = " am"
            End If
        Else
            ore1 = formatOreMin(ora1)
            minut1 = formatOreMin(minuti1)
            am_pm1 = ""
            ore2 = formatOreMin(ora2)
            minut2 = formatOreMin(minuti2)
            am_pm2 = ""
        End If
        If am_pm1 = "" Then
            time1.Text = ore1 + ":" + minut1
        Else
            time1.Text = ore1 + ":" + minut1 + am_pm1
        End If
        If am_pm2 = "" Then
            time2.Text = ore2 + ":" + minut2
        Else
            time2.Text = ore2 + ":" + minut2 + am_pm1
        End If

    End Sub
    Public Sub set_timer_new(ByVal result_conn_data As String, ByVal timer_temp1 As String, ByVal timer_temp2 As String, ByVal timer_temp3 As String, ByVal timer_temp4 As String)
        enable_single_program(result_conn_data, Mid(timer_temp1, 3, 4), Mid(timer_temp1, 7, 4), time2_2, timer2_start_2, timer2_stop_2)
        enable_single_program(result_conn_data, Mid(timer_temp1, 11, 4), Mid(timer_temp1, 15, 4), time2_3, timer2_start_3, timer2_stop_3)
        enable_single_program(result_conn_data, Mid(timer_temp1, 19, 4), Mid(timer_temp1, 23, 4), time2_4, timer2_start_4, timer2_stop_4)
        enable_single_program(result_conn_data, Mid(timer_temp1, 27, 4), Mid(timer_temp1, 31, 4), time2_5, timer2_start_5, timer2_stop_5)

        enable_single_program(result_conn_data, Mid(timer_temp2, 3, 4), Mid(timer_temp2, 7, 4), time3_2, timer3_start_2, timer3_stop_2)
        enable_single_program(result_conn_data, Mid(timer_temp2, 11, 4), Mid(timer_temp2, 15, 4), time3_3, timer3_start_3, timer3_stop_3)
        enable_single_program(result_conn_data, Mid(timer_temp2, 19, 4), Mid(timer_temp2, 23, 4), time3_4, timer3_start_4, timer3_stop_4)
        enable_single_program(result_conn_data, Mid(timer_temp2, 27, 4), Mid(timer_temp2, 31, 4), time3_5, timer3_start_5, timer3_stop_5)

        enable_single_program(result_conn_data, Mid(timer_temp3, 3, 4), Mid(timer_temp3, 7, 4), time4_2, timer4_start_2, timer4_stop_2)
        enable_single_program(result_conn_data, Mid(timer_temp3, 11, 4), Mid(timer_temp3, 15, 4), time4_3, timer4_start_3, timer4_stop_3)
        enable_single_program(result_conn_data, Mid(timer_temp3, 19, 4), Mid(timer_temp3, 23, 4), time4_4, timer4_start_4, timer4_stop_4)
        enable_single_program(result_conn_data, Mid(timer_temp3, 27, 4), Mid(timer_temp3, 31, 4), time4_5, timer4_start_5, timer4_stop_5)

        enable_single_program(result_conn_data, Mid(timer_temp4, 3, 4), Mid(timer_temp4, 7, 4), time5_2, timer5_start_2, timer5_stop_2)
        enable_single_program(result_conn_data, Mid(timer_temp4, 11, 4), Mid(timer_temp4, 15, 4), time5_3, timer5_start_3, timer5_stop_3)
        enable_single_program(result_conn_data, Mid(timer_temp4, 19, 4), Mid(timer_temp4, 23, 4), time5_4, timer5_start_4, timer5_stop_4)
        enable_single_program(result_conn_data, Mid(timer_temp4, 27, 4), Mid(timer_temp4, 31, 4), time5_5, timer5_start_5, timer5_stop_5)


    End Sub
    Public Sub set_timer(ByVal result_conn_data As String, ByVal str_timer1_2 As String, ByVal str_timer3_4_5 As String, ByVal new_version As Boolean)
        Dim tipe_ora As String
        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(3, 1) As String

        tipe_ora = Mid(result_conn_data, 10, 1)
        If new_version = False Then
            Literal5.Visible = False
            value_timer1_name_id.Visible = False
            Literal20.Visible = False
            time2_2.Visible = False
            Literal21.Visible = False
            timer2_start_2.Visible = False
            Literal22.Visible = False
            timer2_stop_2.Visible = False
            Literal23.Visible = False
            time2_3.Visible = False
            Literal24.Visible = False
            timer2_start_3.Visible = False
            Literal25.Visible = False
            timer2_stop_3.Visible = False
            Literal26.Visible = False
            time2_4.Visible = False
            Literal27.Visible = False
            timer2_start_4.Visible = False
            Literal28.Visible = False
            timer2_stop_4.Visible = False
            Literal29.Visible = False
            time2_5.Visible = False
            Literal30.Visible = False
            timer2_stop_5.Visible = False
            Literal13.Visible = False
            value_timer2_name_id.Visible = False

            timer2_start_5.Visible = False
            Literal31.Visible = False

            Literal45.Visible = False
            time3_2.Visible = False
            Literal46.Visible = False
            timer3_start_2.Visible = False
            Literal47.Visible = False
            timer3_stop_2.Visible = False
            Literal48.Visible = False
            time3_3.Visible = False
            Literal49.Visible = False
            timer3_start_3.Visible = False
            Literal50.Visible = False
            timer3_stop_3.Visible = False
            Literal51.Visible = False
            time3_4.Visible = False
            Literal52.Visible = False
            timer3_start_4.Visible = False
            Literal53.Visible = False
            timer3_stop_4.Visible = False
            Literal54.Visible = False
            time3_5.Visible = False
            Literal55.Visible = False
            timer3_stop_5.Visible = False
            Literal59.Visible = False
            value_timer3_name_id.Visible = False

            timer3_start_5.Visible = False
            Literal56.Visible = False

            Literal71.Visible = False
            time4_2.Visible = False
            Literal72.Visible = False
            timer4_start_2.Visible = False
            Literal73.Visible = False
            timer4_stop_2.Visible = False
            Literal74.Visible = False
            time4_3.Visible = False
            Literal75.Visible = False
            timer4_start_3.Visible = False
            Literal76.Visible = False
            timer4_stop_3.Visible = False
            Literal77.Visible = False
            time4_4.Visible = False
            Literal78.Visible = False
            timer4_start_4.Visible = False
            Literal79.Visible = False
            timer4_stop_4.Visible = False
            Literal80.Visible = False
            time4_5.Visible = False
            Literal81.Visible = False
            timer4_stop_5.Visible = False

            timer4_start_5.Visible = False
            Literal82.Visible = False

            Literal85.Visible = False
            value_timer4_name_id.Visible = False

            Literal97.Visible = False
            time5_2.Visible = False
            Literal98.Visible = False
            timer5_start_2.Visible = False
            Literal99.Visible = False
            timer5_stop_2.Visible = False
            Literal100.Visible = False
            time5_3.Visible = False
            Literal101.Visible = False
            timer5_start_3.Visible = False
            Literal102.Visible = False
            timer5_stop_3.Visible = False
            Literal103.Visible = False
            time5_4.Visible = False
            Literal104.Visible = False
            timer5_start_4.Visible = False
            Literal106.Visible = False
            timer5_stop_4.Visible = False
            Literal107.Visible = False
            time5_5.Visible = False
            Literal107.Visible = False
            timer5_stop_5.Visible = False

            timer5_start_5.Visible = False
            Literal108.Visible = False

            Literal111.Visible = False
            value_timer5_name_id.Visible = False
        Else

        End If

        Select Mid(result_conn_data, 9, 1)
            Case "0"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """dd-mm-yy"""
            Case "1"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """mm-dd-yy"""
            Case "2"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """yy-mm-dd"""
        End Select
        If Mid(result_conn_data, 10, 1) = "0" Then ' formato am/pm
            set_variable_javascript(1, 0) = "formato_ora"
            set_variable_javascript(1, 1) = """hh:mm tt"""
            set_variable_javascript(2, 0) = "lunghezza_ora"
            set_variable_javascript(2, 1) = "8"
            set_variable_javascript(3, 0) = "lunghezza_data"
            set_variable_javascript(3, 1) = "19"
        Else 'formato 24h
            set_variable_javascript(1, 0) = "formato_ora"
            set_variable_javascript(1, 1) = """HH:mm"""
            set_variable_javascript(2, 0) = "lunghezza_ora"
            set_variable_javascript(2, 1) = "5"
            set_variable_javascript(3, 0) = "lunghezza_data"
            set_variable_javascript(3, 1) = "16"

        End If
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 3)

        Select Case Mid(str_timer1_2, 20, 1)
            Case "0" ' timer 1 disabled 
                disable_timer1.Checked = True
                java_script_variable.call_function_javascript_onload(Page, "disable_timer1_1();")
            Case "1"
                enable_timer1.Checked = True
                Dim anno As String = Mid(str_timer1_2, 25, 2)
                Dim mese As String = Mid(str_timer1_2, 23, 2)
                Dim giorno As String = Mid(str_timer1_2, 21, 2)
                Dim ore As String
                Dim minuti As String
                Dim am_pm As String
                Select Case Mid(result_conn_data, 9, 1)
                    Case "0" 'dd-mm-yy
                        timer_1_start.Text = giorno + "/" + mese + "/" + anno + " "
                    Case "1" 'mm-dd-yy
                        timer_1_start.Text = mese + "/" + giorno + "/" + anno + " "
                    Case "2" 'yy-mm-dd
                        timer_1_start.Text = anno + "/" + mese + "/" + giorno + " "
                End Select
                If Mid(result_conn_data, 10, 1) = "0" Then
                    If (Val(Mid(str_timer1_2, 31, 2))) > 12 Then
                        am_pm = " pm"
                        ore = Format(Val(Mid(str_timer1_2, 31, 2)) - 12, "00")
                        minuti = Format(Val(Mid(str_timer1_2, 33, 2)), "00")
                    End If
                    If (Val(Mid(str_timer1_2, 31, 2))) = 12 Then
                        am_pm = " pm"
                        ore = Format(Val(Mid(str_timer1_2, 31, 2)), "00")
                        minuti = Format(Val(Mid(str_timer1_2, 33, 2)), "00")

                    End If
                    If (Val(Mid(str_timer1_2, 31, 2))) < 12 Then 'formato europeo
                        am_pm = " am"
                        ore = Format(Val(Mid(str_timer1_2, 31, 2)), "00")
                        minuti = Format(Val(Mid(str_timer1_2, 33, 2)), "00")

                    End If
                Else
                    am_pm = ""
                    ore = Format(Val(Mid(str_timer1_2, 31, 2)), "00")
                    minuti = Format(Val(Mid(str_timer1_2, 33, 2)), "00")
                End If
                If am_pm = "" Then
                    timer_1_start.Text = timer_1_start.Text + ore + ":" + minuti
                Else
                    timer_1_start.Text = timer_1_start.Text + ore + ":" + minuti + am_pm
                End If
                value_timer1_gg_id.Text = Format((Mid(str_timer1_2, 35, 3)), "00")
                set_combo(timer1_relay_pulse, value_timer1_pulse_minute_id, (Val(Mid(str_timer1_2, 38, 2))), (Val(Mid(str_timer1_2, 40, 3))))
                java_script_variable.call_function_javascript_onload(Page, "enable_timer1_1();")
        End Select
        set_timer_2_3_4_5(Mid(str_timer1_2, 3, 1), (Val(Mid(str_timer1_2, 4, 2))), Mid(str_timer1_2, 6, 2), (Val(Mid(str_timer1_2, 8, 2))), Mid(str_timer1_2, 10, 2), (Val(Mid(str_timer1_2, 12, 3))), result_conn_data, disable_timer2, enable_timer2, timer2_start_1, timer2_stop_1, timer2_lunedi, timer2_martedi, timer2_mercoledi, timer2_giovedi, timer2_venerdi, timer2_sabato, timer2_domenica, time2_1)
        set_combo(timer2_relay_pulse, value_timer2_pulse_minute_id, (Val(Mid(str_timer1_2, 15, 2))), (Val(Mid(str_timer1_2, 17, 3))))

        set_timer_2_3_4_5(Mid(str_timer3_4_5, 3, 1), (Val(Mid(str_timer3_4_5, 4, 2))), Mid(str_timer3_4_5, 6, 2), (Val(Mid(str_timer3_4_5, 8, 2))), Mid(str_timer3_4_5, 10, 2), (Val(Mid(str_timer3_4_5, 12, 3))), result_conn_data, disable_timer3, enable_timer3, timer3_start_1, timer3_stop_1, timer3_lunedi, timer3_martedi, timer3_mercoledi, timer3_giovedi, timer3_venerdi, timer3_sabato, timer3_domenica, time3_1)
        set_combo(timer3_relay_pulse, value_timer3_pulse_minute_id, (Val(Mid(str_timer3_4_5, 15, 2))), (Val(Mid(str_timer3_4_5, 17, 3))))

        set_timer_2_3_4_5(Mid(str_timer3_4_5, 20, 1), (Val(Mid(str_timer3_4_5, 21, 2))), Mid(str_timer3_4_5, 23, 2), (Val(Mid(str_timer3_4_5, 25, 2))), Mid(str_timer3_4_5, 27, 2), (Val(Mid(str_timer3_4_5, 29, 3))), result_conn_data, disable_timer4, enable_timer4, timer4_start_1, timer4_stop_1, timer4_lunedi, timer4_martedi, timer4_mercoledi, timer4_giovedi, timer4_venerdi, timer4_sabato, timer4_domenica, time4_1)
        set_combo(timer4_relay_pulse, value_timer4_pulse_minute_id, (Val(Mid(str_timer3_4_5, 32, 2))), (Val(Mid(str_timer3_4_5, 34, 3))))

        set_timer_2_3_4_5(Mid(str_timer3_4_5, 37, 1), (Val(Mid(str_timer3_4_5, 38, 2))), Mid(str_timer3_4_5, 40, 2), (Val(Mid(str_timer3_4_5, 42, 2))), Mid(str_timer3_4_5, 44, 2), (Val(Mid(str_timer3_4_5, 46, 3))), result_conn_data, disable_timer5, enable_timer5, timer5_start_1, timer5_stop_1, timer5_lunedi, timer5_martedi, timer5_mercoledi, timer5_giovedi, timer5_venerdi, timer5_sabato, timer5_domenica, time5_1)
        set_combo(timer5_relay_pulse, value_timer5_pulse_minute_id, (Val(Mid(str_timer3_4_5, 49, 2))), (Val(Mid(str_timer3_4_5, 51, 3))))

    End Sub
    Private Sub set_timer_2_3_4_5(ByVal valore_1 As String, ByVal valore_2 As Integer, ByVal valore_3 As String, ByVal valore_4 As Integer, ByVal valore_5 As String, ByVal valore_6 As Integer, ByVal result_conn_data As String, ByVal radiob1 As RadioButton, ByVal radiob2 As RadioButton, ByVal text1 As TextBox, ByVal text2 As TextBox, ByVal check1 As CheckBox, ByVal check2 As CheckBox, ByVal check3 As CheckBox, ByVal check4 As CheckBox, ByVal check5 As CheckBox, ByVal check6 As CheckBox, ByVal check7 As CheckBox, ByVal time As CheckBox)

        'If valore_2 = 0 And Val(valore_3) = 0 And valore_4 = 0 And Val(valore_5) = 0 Then
        '    radiob1.Checked = True
        '    panel_1.Visible = False
        '    Exit Sub
        'End If
        Dim ore As String
        Dim minuti As String
        Dim am_pm As String

        time.Checked = True

        Select Case valore_1 'Mid(option_str_timer_new, 3, 1)
            Case "0"

                radiob1.Checked = True
            Case "1"

                radiob2.Checked = True
                If Mid(result_conn_data, 10, 1) = "0" Then
                    If valore_2 > 12 Then
                        ore = Format((valore_2 - 12), "00")
                        minuti = Format(Val(valore_3), "00")
                        am_pm = " pm"
                    End If
                    If valore_2 = 12 Then
                        ore = Format(valore_2, "00")
                        minuti = Format(Val(valore_3), "00")
                        am_pm = " pm"
                    End If
                    If valore_2 < 12 Then 'formato europeo
                        ore = Format(valore_2, "00")
                        minuti = Format(Val(valore_3), "00")
                        am_pm = " am"
                    End If
                Else

                    ore = Format(valore_2, "00")
                    minuti = Format(Val(valore_3), "00")
                    am_pm = ""
                End If
                If am_pm = "" Then
                    text1.Text = ore + ":" + minuti
                Else
                    text1.Text = ore + ":" + minuti + am_pm
                End If

                '(Val(Mid(option_str_timer_new, 8, 2)))
                'Mid(option_str_timer_new, 10, 2)
                If Mid(result_conn_data, 10, 1) = "0" Then
                    If valore_4 > 12 Then
                        ore = Format(valore_4 - 12, "00")
                        minuti = Format(Val(valore_5), "00")
                        am_pm = " pm"
                    End If
                    If valore_4 = 12 Then
                        ore = Format(valore_4, "00")
                        minuti = Format(Val(valore_5), "00")
                        am_pm = " pm"

                    End If
                    If valore_4 < 12 Then
                        ore = Format(valore_4, "00")
                        minuti = Format(Val(valore_5), "00")
                        am_pm = " am"
                    End If
                Else
                    ore = Format(valore_4, "00")
                    minuti = Format(Val(valore_5), "00")
                    am_pm = ""
                End If
                If am_pm = "" Then
                    text2.Text = ore + ":" + minuti
                Else
                    text2.Text = ore + ":" + minuti + am_pm
                End If

                '(Val(Mid(option_str_timer_new, 12, 3))
                If (valore_6 And 1) = 1 Then
                    check1.Checked = True
                End If
                If (valore_6 And 2) = 2 Then
                    check2.Checked = True
                End If
                If (valore_6 And 4) = 4 Then
                    check3.Checked = True
                End If
                If (valore_6 And 8) = 8 Then
                    check4.Checked = True
                End If
                If (valore_6 And 16) = 16 Then
                    check5.Checked = True
                End If
                If (valore_6 And 32) = 32 Then
                    check6.Checked = True
                End If
                If (valore_6 And 64) = 64 Then
                    check7.Checked = True
                End If
        End Select

    End Sub
    Public Sub set_combo(ByVal combo As DropDownList, ByVal numeric As TextBox, ByVal index As Integer, ByVal index1 As Integer)
        combo.SelectedIndex = index
        numeric.Text = index1.ToString
    End Sub
    Private Function function_decode_timer(ByVal time1 As TextBox, ByVal time2 As TextBox, ByVal checked As Boolean) As String
        Dim temp_data As String = ""
        Dim data As New Date
        If checked Then
            data = Date.Parse(time1.Text)
            temp_data = temp_data + data.ToString("HHmm")
            data = Date.Parse(time2.Text)
            temp_data = temp_data + data.ToString("HHmm")

        Else
            temp_data = "00000000"
        End If
        Return temp_data
    End Function
    Function get_combo(ByVal combo As DropDownList, ByVal numeric As TextBox) As String
        If combo.SelectedValue = "0" Then ' scelta X
            Return "00000"
        End If
        If Val(combo.SelectedValue) > 6 Then
            Return Format(Val(combo.SelectedValue) + 6, "00") + Format(Val(numeric.Text), "000")
        End If
        If Val(combo.SelectedValue) > 0 And Val(combo.SelectedValue) <= 6 Then
            Return Format(Val(combo.SelectedValue), "00") + "000"
        End If
        Return "00000"
    End Function

    Public Function get_timer_status(ByVal radio_disable As RadioButton, ByVal text_1 As TextBox, ByVal text_2 As TextBox, ByVal check_1 As CheckBox, ByVal check_2 As CheckBox, ByVal check_3 As CheckBox, ByVal check_4 As CheckBox, ByVal check_5 As CheckBox, ByVal check_6 As CheckBox, ByVal check_7 As CheckBox, ByVal combo_1 As DropDownList, ByVal numeric_1 As TextBox, ByVal checked As Boolean) As String
        Dim temp_timer As String = ""
        Dim day_week As Integer = 0
        If radio_disable.Checked Then
            temp_timer = "00000000000000000"
        Else
            temp_timer = temp_timer + "1"
            temp_timer = temp_timer + function_decode_timer(text_1, text_2, checked)

            If check_1.Checked Then
                day_week = day_week Or 1
            Else
                day_week = day_week And 126
            End If
            If check_2.Checked Then
                day_week = day_week Or 2
            Else
                day_week = day_week And 125
            End If
            If check_3.Checked Then
                day_week = day_week Or 4
            Else
                day_week = day_week And 123
            End If
            If check_4.Checked Then
                day_week = day_week Or 8
            Else
                day_week = day_week And 119
            End If
            If check_5.Checked Then
                day_week = day_week Or 16
            Else
                day_week = day_week And 111
            End If
            If check_6.Checked Then
                day_week = day_week Or 32
            Else
                day_week = day_week And 95
            End If
            If check_7.Checked Then
                day_week = day_week Or 64
            Else
                day_week = day_week And 63
            End If
            temp_timer = temp_timer & Format(day_week, "000")
            temp_timer = temp_timer & get_combo(combo_1, numeric_1)

        End If
        Return temp_timer
    End Function
    Public Function get_timer_new(ByVal indice As Integer) As String
        Dim Risultato As String
        Dim str_timer1_2_new As String = ""
        Dim str_timer3_4_5_new As String = ""
        str_timer1_2_new = "ph"
        str_timer1_2_new = str_timer1_2_new + get_timer_status(disable_timer2, timer2_start_1, timer2_stop_1, timer2_lunedi, timer2_martedi, timer2_mercoledi, timer2_giovedi, timer2_venerdi, timer2_sabato, timer2_domenica, timer2_relay_pulse, value_timer2_pulse_minute_id, True)

        If disable_timer1.Checked Then
            str_timer1_2_new = str_timer1_2_new & "00000000000000000000000"
        Else
            str_timer1_2_new = str_timer1_2_new & "1"
            Dim data As New Date
            data = Date.Parse(timer_1_start.Text)
            str_timer1_2_new = str_timer1_2_new + data.ToString("ddMMyy")
            data = Date.Parse(timer_1_start.Text)
            str_timer1_2_new = str_timer1_2_new + data.ToString("HHmm")
            data = Date.Parse(timer_1_stop.Text)
            str_timer1_2_new = str_timer1_2_new + data.ToString("HHmm")

            str_timer1_2_new = str_timer1_2_new & Format(Val(value_timer1_gg_id.Text), "000")
            str_timer1_2_new = str_timer1_2_new & get_combo(timer1_relay_pulse, value_timer1_pulse_minute_id)
            str_timer1_2_new = str_timer1_2_new & "end"
        End If
        str_timer3_4_5_new = "ph"
        str_timer3_4_5_new = str_timer3_4_5_new + get_timer_status(disable_timer3, timer3_start_1, timer3_stop_1, timer3_lunedi, timer3_martedi, timer3_mercoledi, timer3_giovedi, timer3_venerdi, timer3_sabato, timer3_domenica, timer3_relay_pulse, value_timer3_pulse_minute_id, True)
        str_timer3_4_5_new = str_timer3_4_5_new + get_timer_status(disable_timer4, timer4_start_1, timer4_stop_1, timer4_lunedi, timer4_martedi, timer4_mercoledi, timer4_giovedi, timer4_venerdi, timer4_sabato, timer4_domenica, timer4_relay_pulse, value_timer4_pulse_minute_id, True)
        str_timer3_4_5_new = str_timer3_4_5_new + get_timer_status(disable_timer5, timer5_start_1, timer5_stop_1, timer5_lunedi, timer5_martedi, timer5_mercoledi, timer5_giovedi, timer5_venerdi, timer5_sabato, timer5_domenica, timer5_relay_pulse, value_timer5_pulse_minute_id, True)
        str_timer3_4_5_new = str_timer3_4_5_new + "end"


        If indice < 2 Then ' timer 1 e 2
            Return id_485_impianto + "b4" + str_timer1_2_new + Chr(13)
        Else ' resto delle option
            Return id_485_impianto + "bk" + str_timer3_4_5_new + Chr(13)

        End If
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + Risultato + Chr(13))

        'Return stato_server


    End Function
    Private Function create_function_name(ByVal limit_char As Integer, ByVal start_string As String) As String
        Dim temp_string As String = ""
        Dim i As Integer = 0
        temp_string = start_string
        If temp_string.Length <= limit_char Then
            Dim lunghezza_aggiunta As Integer = limit_char - temp_string.Length
            For i = 1 To lunghezza_aggiunta
                temp_string = temp_string + "-"
            Next
        End If
        Return temp_string
    End Function
    Public Function get_timer_new_version(ByVal indice As Integer) As String
        Dim Risultato As String
        Dim str_timer1_2_new As String = ""
        Dim str_timer3_4_5_new As String = ""
        str_timer1_2_new = "ph"
        str_timer1_2_new = str_timer1_2_new + get_timer_status(disable_timer2, timer2_start_1, timer2_stop_1, timer2_lunedi, timer2_martedi, timer2_mercoledi, timer2_giovedi, timer2_venerdi, timer2_sabato, timer2_domenica, timer2_relay_pulse, value_timer2_pulse_minute_id, time2_1.Checked)

        If disable_timer1.Checked Then
            str_timer1_2_new = str_timer1_2_new & "00000000000000000000000"
        Else
            str_timer1_2_new = str_timer1_2_new & "1"
            Dim data As New Date
            data = Date.Parse(timer_1_start.Text)
            str_timer1_2_new = str_timer1_2_new + data.ToString("ddMMyy")
            data = Date.Parse(timer_1_start.Text)
            str_timer1_2_new = str_timer1_2_new + data.ToString("HHmm")
            data = Date.Parse(timer_1_stop.Text)
            str_timer1_2_new = str_timer1_2_new + data.ToString("HHmm")

            str_timer1_2_new = str_timer1_2_new & Format(Val(value_timer1_gg_id.Text), "000")
            str_timer1_2_new = str_timer1_2_new & get_combo(timer1_relay_pulse, value_timer1_pulse_minute_id)
            str_timer1_2_new = str_timer1_2_new & "end"
        End If


        If disable_timer2.Checked Then
            str_timer1_2_new = str_timer1_2_new + "00000000000000000000000000000000"
        Else

            str_timer1_2_new = str_timer1_2_new + function_decode_timer(timer2_start_2, timer2_stop_2, time2_2.Checked)
            str_timer1_2_new = str_timer1_2_new + function_decode_timer(timer2_start_3, timer2_stop_3, time2_3.Checked)
            str_timer1_2_new = str_timer1_2_new + function_decode_timer(timer2_start_4, timer2_stop_4, time2_4.Checked)
            str_timer1_2_new = str_timer1_2_new + function_decode_timer(timer2_start_5, timer2_stop_5, time2_5.Checked)

            str_timer1_2_new = str_timer1_2_new + create_function_name(10, value_timer1_name_id.Text)
            str_timer1_2_new = str_timer1_2_new + create_function_name(10, value_timer2_name_id.Text)
            str_timer1_2_new = str_timer1_2_new + create_function_name(10, value_timer3_name_id.Text)
            str_timer1_2_new = str_timer1_2_new + create_function_name(10, value_timer4_name_id.Text)
            str_timer1_2_new = str_timer1_2_new + create_function_name(10, value_timer5_name_id.Text)
        End If
        str_timer1_2_new = str_timer1_2_new + "end"

        str_timer3_4_5_new = "ph"
        str_timer3_4_5_new = str_timer3_4_5_new + get_timer_status(disable_timer3, timer3_start_1, timer3_stop_1, timer3_lunedi, timer3_martedi, timer3_mercoledi, timer3_giovedi, timer3_venerdi, timer3_sabato, timer3_domenica, timer3_relay_pulse, value_timer3_pulse_minute_id, time3_1.Checked)
        str_timer3_4_5_new = str_timer3_4_5_new + get_timer_status(disable_timer4, timer4_start_1, timer4_stop_1, timer4_lunedi, timer4_martedi, timer4_mercoledi, timer4_giovedi, timer4_venerdi, timer4_sabato, timer4_domenica, timer4_relay_pulse, value_timer4_pulse_minute_id, time4_1.Checked)
        str_timer3_4_5_new = str_timer3_4_5_new + get_timer_status(disable_timer5, timer5_start_1, timer5_stop_1, timer5_lunedi, timer5_martedi, timer5_mercoledi, timer5_giovedi, timer5_venerdi, timer5_sabato, timer5_domenica, timer5_relay_pulse, value_timer5_pulse_minute_id, time5_1.Checked)
        If disable_timer3.Checked Then
            str_timer3_4_5_new = str_timer3_4_5_new + "00000000000000000000000000000000"
        Else
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer3_start_2, timer3_stop_2, time3_2.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer3_start_3, timer3_stop_3, time3_3.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer3_start_4, timer3_stop_4, time3_4.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer3_start_5, timer3_stop_5, time3_4.Checked)
        End If
        If disable_timer4.Checked Then
            str_timer3_4_5_new = str_timer3_4_5_new + "00000000000000000000000000000000"
        Else
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer4_start_2, timer4_stop_2, time4_2.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer4_start_3, timer4_stop_3, time4_3.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer4_start_4, timer4_stop_4, time4_4.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer4_start_5, timer4_stop_5, time4_5.Checked)
        End If
        If disable_timer5.Checked Then
            str_timer3_4_5_new = str_timer3_4_5_new + "00000000000000000000000000000000"
        Else
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer5_start_2, timer5_stop_2, time5_2.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer5_start_3, timer5_stop_3, time5_3.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer5_start_4, timer5_stop_4, time5_4.Checked)
            str_timer3_4_5_new = str_timer3_4_5_new + function_decode_timer(timer5_start_5, timer5_stop_5, time5_5.Checked)

        End If
        str_timer3_4_5_new = str_timer3_4_5_new + "end"

        Dim stato_server As Boolean
        If indice < 2 Then ' timer 1 e 2
            Return id_485_impianto + "b4" + str_timer1_2_new + Chr(13)
        Else ' resto delle option
            Return id_485_impianto + "bk" + str_timer3_4_5_new + Chr(13)

        End If

    End Function
    Protected Sub save_timer_new_Click(sender As Object, e As EventArgs) Handles save_timer_new.Click
      
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        Dim new_setpoint As String = ""
        Dim number_version As Integer
        Dim config_value() As String
        Dim option_value() As String
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_combinato As Integer = 0
        Dim local_connection As Boolean

        Dim errore_primo_invio As Boolean = False
        Dim url_result As String = ""



        local_connection = write_setpoint_new.client_connect()

        If versioneGlobal > 29 Then
            new_setpoint = get_timer_new_version(0)
        Else
            new_setpoint = get_timer_new(0)
        End If

        If local_connection Then ' connessione OK
            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result, errore_primo_invio)
        Else ' server busy riprovare
            url_result = "result=3"
            errore_primo_invio = True
        End If

        If number_version > 29 Then
            new_setpoint = get_timer_new_version(2)
        Else
            new_setpoint = get_timer_new(2)
        End If


        If errore_primo_invio = False Then ' nel primo invio non c'è stato errore invio il secondo blocco
            If local_connection Then ' connessione OK
                write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result, errore_primo_invio)
            Else ' server busy riprovare
                url_result = "result=3"
            End If
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()


        'javascript_function.call_function_javascript_onload(Page, "result_setpoint_change();")
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)


    End Sub
End Class