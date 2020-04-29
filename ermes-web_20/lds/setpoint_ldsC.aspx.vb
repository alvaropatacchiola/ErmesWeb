Public Class setpoint_ldsC

    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub setpoint_ld_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_setpoint_ldsC(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "setpoint"))


            save_setpointldsC_new.Text = GetGlobalResourceObject("ld_global", "salva_carica_dati")
        End If
    End Sub
    Public Sub posiziona_setpoint_ldsC(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                              ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim java_script_ch1_pulse1 As java_script = New java_script
        Dim function_java As String = ""

        Dim java_script_ch1_pulse_variable As java_script = New java_script
        Dim set_variable_javascript(5, 1) As String

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
        save_setpointldsC_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointldsC_new, ""))


        data_sp = main_function.get_split_str(riga_strumento.value7)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        Dim ch_pulse1_mode As String = Mid(data_sp(6), 1, 1) ' 0-> on/off 1-> prop 2-> OFF
        Dim ch_relay1_mode As String = Mid(data_sp(11), 1, 1) ' 0-> prop PWM  1-> on/off 2-> Fixed PWM 3-> OFF
        Dim ch_pulse2_mode As String = Mid(data_sp(17), 1, 1) ' 0-> on/off 1-> prop 2-> OFF
        Dim ch_relay2_mode As String = Mid(data_sp(22), 1, 1) '  0-> prop PWM  1-> on/off 2-> Fixed PWM 3-> OFF

        function_java = ""
        Select Case ch_pulse1_mode
            Case "2" 'off
                function_java = function_java + "disable_channel_ph_pulse1();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "disable_channel_ph_pulse1()")
                off_ph_pulse1.Checked = True
            Case "0" 'on/off
                function_java = function_java + "enable_channel_ph_pulse1_on_off();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_on_off()")
                on_off_ph_pulse1.Checked = True
            Case "1" 'proportianal
                function_java = function_java + "enable_channel_ph_pulse1_proportional();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                proportional_ph_pulse1.Checked = True

            Case "3" 'proportianal + wm
                function_java = function_java + "enable_channel_ph_pulse1_prop_wm();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                Prop_WM_ph_pulse1.Checked = True

            Case "4" 'pid
                function_java = function_java + "enable_channel_ph_pulse1_pid();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                PID_ph_pulse1.Checked = True
        End Select


        Select Case ch_pulse2_mode
            Case "2" 'off
                function_java = function_java + "disable_channel_cl_pulse1();"
                'java_script_ch1_pulse3.call_function_javascript_onload(Page, "disable_channel_cl_pulse1()")
                off_cl_pulse1.Checked = True
            Case "0" 'on/off
                function_java = function_java + "enable_channel_cl_pulse1_on_off();"
                'java_script_ch1_pulse3.call_function_javascript_onload(Page, "enable_channel_cl_pulse1_on_off()")
                on_off_cl_pulse1.Checked = True
            Case "1" 'proportianal
                function_java = function_java + "enable_channel_cl_pulse1_proportional();"
                'java_script_ch1_pulse3.call_function_javascript_onload(Page, "enable_channel_cl_pulse1_proportional()")
                proportional_cl_pulse1.Checked = True

            Case "3" 'proportianal + wm
                function_java = function_java + "enable_channel_cl_pulse1_prop_wm();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                Prop_WM_cl_pulse1.Checked = True

            Case "4" 'pid
                function_java = function_java + "enable_channel_cl_pulse1_pid();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                PID_cl_pulse1.Checked = True
        End Select
        Select Case ch_relay1_mode
            Case "3" 'off
                function_java = function_java + "disable_channel_ph_relay();"
                'java_script_ch1_pulse4.call_function_javascript_onload(Page, "disable_channel_ph_relay()")
                off_ph_relay.Checked = True
            Case "0" 'proportional pwm
                function_java = function_java + "enable_channel_ph_relay_proportionalpwm();"
                'java_script_ch1_pulse4.call_function_javascript_onload(Page, "enable_channel_ph_relay_proportionalpwm()")
                proportional_ph_relay.Checked = True
            Case "1" 'on/off
                function_java = function_java + "enable_channel_ph_relay_on_off();"
                'java_script_ch1_pulse4.call_function_javascript_onload(Page, "enable_channel_ph_relay_on_off()")
                on_off_ph_relay.Checked = True
            Case "2" 'fixedf
                function_java = function_java + "enable_channel_ph_relay_fixedpwm();"
                'java_script_ch1_pulse4.call_function_javascript_onload(Page, "enable_channel_ph_relay_fixedpwm()")
                fixed_ph_relay.Checked = True

            Case "4" 'proportianal + wm
                function_java = function_java + "enable_channel_ph_relay_prop_wm();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                Prop_WM_ph_relay.Checked = True

            Case "5" 'pid
                function_java = function_java + "enable_channel_ph_relay_pid();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                PID_ph_relay.Checked = True
        End Select
        Select Case ch_relay2_mode
            Case "3" 'off
                function_java = function_java + "disable_channel_cl_relay();"
                'java_script_ch1_pulse5.call_function_javascript_onload(Page, "disable_channel_cl_relay()")
                off_cl_relay.Checked = True
            Case "0" 'proportional pwm
                function_java = function_java + "enable_channel_cl_relay_proportionalpwm();"
                'java_script_ch1_pulse5.call_function_javascript_onload(Page, "enable_channel_cl_relay_proportionalpwm()")
                proportional_cl_relay.Checked = True
            Case "1" 'on/off
                function_java = function_java + "enable_channel_cl_relay_on_off();"
                'java_script_ch1_pulse5.call_function_javascript_onload(Page, "enable_channel_cl_relay_on_off()")
                on_off_cl_relay.Checked = True
            Case "2" 'fixed
                function_java = function_java + "enable_channel_cl_relay_fixedpwm();"
                'java_script_ch1_pulse5.call_function_javascript_onload(Page, "enable_channel_cl_relay_fixedpwm()")
                fixed_cl_relay.Checked = True

            Case "4" 'proportianal + wm
                function_java = function_java + "enable_channel_cl_relay_prop_wm();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                Prop_WM_cl_relay.Checked = True

            Case "5" 'pid
                function_java = function_java + "enable_channel_cl_relay_pid();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                PID_cl_relay.Checked = True
        End Select

        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)


        tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse")

        tabld1_3.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay")

        tabld1_4.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "2"
        tabld1_5.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay") + "2"




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
        set_variable_javascript(5, 1) = set_fullscale(full_scale_temp).ToString

        java_script_ch1_pulse_variable.set_url_setpoint(Page, set_variable_javascript, 5)
        java_script_ch1_pulse1.call_function_javascript_onload(Page, function_java)
        setting_label_setpoint(etichetta_setpoint, " ", GetGlobalResourceObject("ld_global", "pulse"), GetLocalResourceObject("Literal34Resource1.Text"), GetLocalResourceObject("Literal35Resource1.Text"), Label7, Literal4, Literal6, Literal5, Literal7, Literal8, Literal9, Literal10, label_canale_temp, GetGlobalResourceObject("ld_global", "val_ON"), GetGlobalResourceObject("ld_global", "val_OFF"))
        'setting_label_setpoint(etichetta_setpoint, "2", GetGlobalResourceObject("ld_global", "pulse"), GetLocalResourceObject("Literal14Resource1.Text"), GetLocalResourceObject("Literal18Resource1.Text"), Literal8, Literal12, Literal13, Literal14, Literal15, Literal16, Literal17, Literal18, label_canale_temp)
        setting_label_setpoint(etichetta_setpoint, "2", GetGlobalResourceObject("ld_global", "pulse"), GetLocalResourceObject("Literal34Resource1.Text"), GetLocalResourceObject("Literal35Resource1.Text"), Literal35, Literal39, Literal40, Literal41, Literal42, Literal43, Literal44, Literal45, label_canale_temp, GetGlobalResourceObject("ld_global", "val_ON"), GetGlobalResourceObject("ld_global", "val_OFF"))

        setting_label_setpoint_relay(etichetta_setpoint, GetGlobalResourceObject("ld_global", "relay"), Literal22, Literal27, Literal28, Literal29, Literal30, Literal31, Literal32, Literal33, Literal34, label_canale_temp, GetGlobalResourceObject("ld_global", "val_ON"), GetGlobalResourceObject("ld_global", "val_OFF"), GetGlobalResourceObject("ld_global", "val_sec"))
        setting_label_setpoint_relay(etichetta_setpoint, GetGlobalResourceObject("ld_global", "relay"), Literal46, Literal51, Literal52, Literal53, Literal54, Literal55, Literal56, Literal57, Literal58, label_canale_temp, GetGlobalResourceObject("ld_global", "val_ON"), GetGlobalResourceObject("ld_global", "val_OFF"), GetGlobalResourceObject("ld_global", "val_sec"))

        Dim temp_calc As Single = Val(Mid(data_sp(1), 1, 4)) / fattore_divisione_temp 'on
        value1_ph_pulse1_1.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_ph_pulse_range.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(data_sp(2), 1, 4)) / fattore_divisione_temp 'on
        value1_ph_pulse1_2.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_ph_pulse_setpoint.Text = Replace(temp_calc.ToString(), ",", ".")

        'temp_calc = Val(Mid(data_sp(12), 1, 4)) / fattore_divisione_temp 'on
        'value1_ph_pulse2_1.Text = Replace(temp_calc.ToString(), ",", ".")
        'temp_calc = Val(Mid(data_sp(13), 1, 4)) / fattore_divisione_temp 'on
        'value1_ph_pulse2_2.Text = Replace(temp_calc.ToString(), ",", ".")

        temp_calc = Val(Mid(data_sp(7), 1, 4)) / fattore_divisione_temp 'on
        value1_ph_relay_1.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_ph_relay_range.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(data_sp(8), 1, 4)) / fattore_divisione_temp 'on
        value1_ph_relay_2.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_ph_relay_setpoint.Text = Replace(temp_calc.ToString(), ",", ".")

        temp_calc = Val(Mid(data_sp(12), 1, 4)) / fattore_divisione_temp 'on
        value1_cl_pulse1_1.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_cl_pulse_range.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(data_sp(13), 1, 4)) / fattore_divisione_temp 'on
        value1_cl_pulse1_2.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_cl_pulse_setpoint.Text = Replace(temp_calc.ToString(), ",", ".")

        temp_calc = Val(Mid(data_sp(18), 1, 4)) / fattore_divisione_temp 'on
        value1_cl_relay_1.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_cl_relay_range.Text = Replace(temp_calc.ToString(), ",", ".")

        temp_calc = Val(Mid(data_sp(19), 1, 4)) / fattore_divisione_temp 'on
        value1_cl_relay_2.Text = Replace(temp_calc.ToString(), ",", ".")
        value2_cl_relay_setpoint.Text = Replace(temp_calc.ToString(), ",", ".")

        value2_ph_pulse1_1.Text = Format(Val(Mid(data_sp(3), 1, 3)), "000")
        value2_ph_pulse1_2.Text = Format(Val(Mid(data_sp(4), 1, 3)), "000")

        'value2_ph_pulse2_1.Text = Format(Val(Mid(data_sp(14), 1, 3)), "000")
        'value2_ph_pulse2_2.Text = Format(Val(Mid(data_sp(15), 1, 3)), "000")

        value2_ph_relay_1.Text = Format(Val(Mid(data_sp(9), 1, 3)), "000")
        value2_ph_relay_2.Text = Format(Val(Mid(data_sp(10), 1, 3)), "000")

        value2_cl_pulse1_1.Text = Format(Val(Mid(data_sp(14), 1, 3)), "000")
        value2_cl_pulse1_2.Text = Format(Val(Mid(data_sp(15), 1, 3)), "000")

        value2_cl_relay_1.Text = Format(Val(Mid(data_sp(20), 1, 3)), "000")
        value2_cl_relay_2.Text = Format(Val(Mid(data_sp(21), 1, 3)), "000")

        Dim ch1_pulse1_att As Integer = Val(Mid(data_sp(5), 1, 5))
        'Dim ch1_pulse2_att As Integer = Val(Mid(data_sp(16), 1, 2))
        Dim ch2_pulse_att As Integer = Val(Mid(data_sp(16), 1, 5))


        'If ch1_pulse1_att = 0 Then
        '    ch1_pulse1_att = 1
        'End If

        

        'If ch2_pulse_att = 0 Then
        '    ch2_pulse_att = 1
        'End If


        value2_ph_pulse1_3.Text = Format(ch1_pulse1_att, "00000")


        temp_calc = ch1_pulse1_att / 100
        value2_ph_pulse_mch.Text = Replace(temp_calc.ToString(), ",", ".")
        'value2_ph_pulse_mch.Text = Format(temp_calc, "00000")

        'value2_ph_pulse2_3.Text = Format(ch1_pulse2_att, "00")
        value2_cl_pulse1_3.Text = Format(ch2_pulse_att, "00000")


        temp_calc = ch2_pulse_att / 100
        value2_cl_pulse_mch.Text = Replace(temp_calc.ToString(), ",", ".")
        'value2_cl_pulse_mch.Text = Format(temp_calc, "00000")



        Dim ch2_pulse_perc3 As Integer
        Dim ch2_pulse_perc4 As Integer
        Dim ch2_pulse2_perc3 As Integer
        Dim ch2_pulse2_perc4 As Integer

        Dim ch2_ev_perc3 As Integer
        Dim ch2_ev_perc4 As Integer
        Dim ch2_ev2_perc3 As Integer
        Dim ch2_ev2_perc4 As Integer

        Dim ch2_ev_mch As Integer
        Dim ch2_ev2_mch As Integer

       

        ch2_pulse_perc4 = Val(Mid(data_sp(24), 1, 3))
        ch2_pulse_perc3 = Val(Mid(data_sp(23), 1, 3))

        ch2_ev_perc3 = Val(Mid(data_sp(26), 1, 3))
        ch2_ev_perc4 = Val(Mid(data_sp(27), 1, 3))

        ch2_pulse2_perc3 = Val(Mid(data_sp(28), 1, 3))
        ch2_pulse2_perc4 = Val(Mid(data_sp(29), 1, 3))

        ch2_ev2_perc3 = Val(Mid(data_sp(31), 1, 3))
        ch2_ev2_perc4 = Val(Mid(data_sp(32), 1, 3))

        ch2_ev_mch = Val(Mid(data_sp(25), 1, 5))
        ch2_ev2_mch = Val(Mid(data_sp(30), 1, 5))


        value2_ph_pulse_perc4.Text = Format(ch2_pulse_perc4, "000")
        value2_ph_pulse_perc3.Text = Format(ch2_pulse_perc3, "000")

        value2_cl_pulse_perc4.Text = Format(ch2_pulse2_perc4, "000")
        value2_cl_pulse_perc3.Text = Format(ch2_pulse2_perc3, "000")


        value2_ph_relay_perc4.Text = Format(ch2_ev_perc4, "000")
        value2_ph_relay_perc3.Text = Format(ch2_ev_perc3, "000")

        value2_cl_relay_perc4.Text = Format(ch2_ev2_perc4, "000")
        value2_cl_relay_perc3.Text = Format(ch2_ev2_perc3, "000")


        temp_calc = ch2_ev_mch / 100
        value2_ph_relay_mch.Text = Replace(temp_calc.ToString(), ",", ".")
        'value2_ph_relay_mch.Text = Format(temp_calc, "00000")


        temp_calc = ch2_ev2_mch / 100
        value2_cl_relay_mch.Text = Replace(temp_calc.ToString(), ",", ".")
        'value2_cl_relay_mch.Text = Format(temp_calc, "00000")


        '      23  (*get_data_setcl()).perc3   // quella più grande  -
        '24  (*get_data_setcl()).perc4   // quella più piccola   - 

        '25  (*get_data_setev2()).m3h-
        '26  (*get_data_setev2()).perc_3   // quella più grande   -
        '27  (*get_data_setev2()).perc_4   // quella più piccola  -


        '28  (*get_data_setclB()).perc3   // quella più grande  - 
        '29  (*get_data_setclB()).perc4   // quella più piccola - 

        '30  (*get_data_setev2B()).m3h-
        '31  (get_data_setev2B()).perc_3   // quella più grande -
        '32  (*get_data_setev2B()).perc_4   // quella più piccola -



        Dim pid_mode As Integer
        Dim pid_int As Integer
        Dim pid_der As Integer

        Dim pert_mode As Integer
        Dim pert_perc As Integer
        Dim pert_mch As Integer


        Dim wm_mode As Integer
        Dim wm_timeout As Integer
        Dim wm_mch As Integer


        '33	(*get_data_pid ()).Mode_cl   // 0 - 1 +
        '34	(*get_data_pid ()).Tempo_Int
        '35	(*get_data_pid ()).Tempo_Der

        '36	(*get_data_per()).Input_mode// 0 Dis  1 add  2 molt
        '37	(*get_data_per()).Percentuale
        '38	(*get_data_per()).M3H

        '39	(*get_save_meter()).Mode
        '40	(*get_save_meter()).Numero
        '41	(*get_save_meter()).TIMEOUT

        pid_mode = Mid(data_sp(33), 1, 1) '  // 0 - 1 +

        pid_int = Mid(data_sp(34), 1, 5)
        pid_der = Mid(data_sp(35), 1, 4)
        value_time_int.Text = Format(pid_int, "00000")
        value_time_der.Text = Format(pid_der, "0000")

        pert_mode = Mid(data_sp(36), 1, 1) '  // 0 Dis  1 add  2 molt
        pert_perc = Val(Mid(data_sp(37), 1, 3))
        value_perc.Text = Format(pert_perc, "000")

        pert_mch = Val(Mid(data_sp(38), 1, 5))
        temp_calc = pert_mch / 100

        value_mch.Text = Replace(temp_calc.ToString(), ",", ".")
        ' value_mch.Text = Format(temp_calc, "00000")

        '// 0 L/P 1 P/L 2 0/20 3 4/20
        wm_mode = Mid(data_sp(39), 1, 1)
        wm_timeout = Mid(data_sp(41), 1, 3)
        value_timeout.Text = Format(wm_timeout, "000")

        wm_mch = Mid(data_sp(40), 1, 5)
        temp_calc = wm_mch / 100
        value_wm.Text = Replace(temp_calc.ToString(), ",", ".")
        ' value_wm.Text = Format(temp_calc, "00000")

        Select Case pid_mode
            Case "1" 'off
                CL_P.Checked = True
            Case "0" 'on/off
                CL_M.Checked = True
           
        End Select

        Select Case pert_mode
            Case "1" 'Additive
                Additive.Checked = True
            Case "0" 'Disable
                Disable.Checked = True
            Case "2" 'Multiplicative
                Multiplicative.Checked = True
        End Select

        Select Case wm_mode
            Case "1" 'ModeP_L
                ModeP_L.Checked = True
            Case "0" 'ModeL_P
                ModeL_P.Checked = True
            Case "2" 'Mode0_20
                Mode0_20.Checked = True
            Case "3" 'Mode4_20
                Mode4_20.Checked = True
        End Select

        


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

    Private Sub setting_label_setpoint(ByVal etichetta_setpoint As String, ByVal numero_canale As String, ByVal traduzione_pulse As String, ByVal traduzione_pulse_minute As String, ByVal traduzione_pulse_speed As String, ByVal literal1 As Literal, _
                                       ByVal Literal2 As Literal, ByVal Literal2_1 As Literal, ByVal Literal3 As Literal, ByVal Literal4 As Literal, ByVal Literal4_1 As Literal, _
                                       ByVal Literal5 As Literal, ByVal Literal6 As Literal, ByVal LiteralTipo As String, ByVal traduzione_on As String, ByVal traduzione_off As String)
        literal1.Text = LiteralTipo + " " + traduzione_pulse + " " + numero_canale
        Literal2.Text = etichetta_setpoint
        Literal2_1.Text = etichetta_setpoint + " " + traduzione_on
        Literal3.Text = traduzione_pulse_minute
        Literal4.Text = etichetta_setpoint
        Literal4_1.Text = etichetta_setpoint + " " + traduzione_off
        Literal5.Text = traduzione_pulse_minute
        Literal6.Text = traduzione_pulse_speed ' + "(min)"
    End Sub
    Private Sub setting_label_setpoint_relay(ByVal etichetta_setpoint As String, ByVal traduzione_relay As String, ByVal literal1 As Literal, _
                                       ByVal Literal2 As Literal, ByVal Literal2_1 As Literal, ByVal Literal3 As Literal, ByVal Literal3_1 As Literal, ByVal Literal4 As Literal, _
                                       ByVal Literal4_1 As Literal, ByVal Literal5 As Literal, ByVal Literal5_1 As Literal, ByVal LiteralTipo As String, _
                                       ByVal traduzione_on As String, ByVal traduzione_off As String, ByVal traduzione_sec As String)
        literal1.Text = LiteralTipo + " " + traduzione_relay
        Literal2.Text = etichetta_setpoint
        Literal2_1.Text = etichetta_setpoint + " " + traduzione_on
        Literal3.Text = "%"
        Literal3_1.Text = traduzione_sec
        Literal4.Text = etichetta_setpoint
        Literal4_1.Text = etichetta_setpoint + " " + traduzione_off
        Literal5.Text = "%"
        Literal5_1.Text = traduzione_sec

    End Sub
    Private Function MakeSETString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0


        Dim app_ch1_pulse1_mode As String
        'Dim app_ch1_pulse2_mode As String
        Dim app_ch1_relay_mode As String
        Dim app_ch2_pulse_mode As String
        Dim app_ch2_relay_mode As String

        Dim app_ch1_pulse1_val1 As String
        Dim app_ch1_pulse1_val2 As String

        'Dim app_ch1_pulse2_val1 As String
        'Dim app_ch1_pulse2_val2 As String

        Dim app_ch1_relay_val1 As String
        Dim app_ch1_relay_val2 As String

        Dim app_ch2_pulse_val1 As String
        Dim app_ch2_pulse_val2 As String

        Dim app_ch2_relay_val1 As String
        Dim app_ch2_relay_val2 As String


        Dim app_ch1_pulse1_val1_i As Integer
        Dim app_ch1_pulse1_val2_i As Integer

        'Dim app_ch1_pulse2_val1_i As Integer
        'Dim app_ch1_pulse2_val2_i As Integer

        Dim app_ch1_relay_val1_i As Integer
        Dim app_ch1_relay_val2_i As Integer

        Dim app_ch2_pulse_val1_i As Integer
        Dim app_ch2_pulse_val2_i As Integer

        Dim app_ch2_relay_val1_i As Integer
        Dim app_ch2_relay_val2_i As Integer


        Dim app_ch1_pulse1_perc1 As String
        Dim app_ch1_pulse1_perc2 As String

        'Dim app_ch1_pulse2_perc1 As String
        'Dim app_ch1_pulse2_perc2 As String

        Dim app_ch1_relay_perc1 As String
        Dim app_ch1_relay_perc2 As String

        Dim app_ch2_pulse_perc1 As String
        Dim app_ch2_pulse_perc2 As String

        Dim app_ch2_relay_perc1 As String
        Dim app_ch2_relay_perc2 As String

        Dim app_ch1_pulse1_att As String
        'Dim app_ch1_pulse2_att As String
        Dim app_ch2_pulse_att As String


        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        If on_off_ph_pulse1.Checked = True Then 'on/off
            app_ch1_pulse1_mode = "0"
        End If

        If proportional_ph_pulse1.Checked = True Then 'prop
            app_ch1_pulse1_mode = "1"
        End If

        If off_ph_pulse1.Checked = True Then 'off
            app_ch1_pulse1_mode = "2"
        End If

        If Prop_WM_ph_pulse1.Checked = True Then 'off
            app_ch1_pulse1_mode = "3"
        End If

        If PID_ph_pulse1.Checked = True Then 'off
            app_ch1_pulse1_mode = "4"
        End If

        'If on_off_ph_pulse2.Checked = True Then 'on/off
        '    app_ch1_pulse2_mode = "0"
        'End If

        'If proportional_ph_pulse2.Checked = True Then 'prop
        '    app_ch1_pulse2_mode = "1"
        'End If

        'If off_ph_pulse2.Checked = True Then 'off
        '    app_ch1_pulse2_mode = "2"
        'End If

        If on_off_cl_pulse1.Checked = True Then 'on/off
            app_ch2_pulse_mode = "0"
        End If

        If proportional_cl_pulse1.Checked = True Then 'prop
            app_ch2_pulse_mode = "1"
        End If

        If off_cl_pulse1.Checked = True Then 'off
            app_ch2_pulse_mode = "2"
        End If
        If Prop_WM_cl_pulse1.Checked = True Then 'off
            app_ch2_pulse_mode = "3"
        End If

        If PID_cl_pulse1.Checked = True Then 'off
            app_ch2_pulse_mode = "4"
        End If



        If on_off_ph_relay.Checked = True Then 'on/off
            app_ch1_relay_mode = "1"
        End If

        If proportional_ph_relay.Checked = True Then 'proportional pwm
            app_ch1_relay_mode = "0"
        End If

        If fixed_ph_relay.Checked = True Then 'fixed pwm
            app_ch1_relay_mode = "2"
        End If

        If off_ph_relay.Checked = True Then 'off
            app_ch1_relay_mode = "3"
        End If


        If Prop_WM_ph_relay.Checked = True Then 'off
            app_ch1_relay_mode = "4"
        End If

        If PID_ph_relay.Checked = True Then 'off
            app_ch1_relay_mode = "5"
        End If




        If on_off_cl_relay.Checked = True Then 'on/off
            app_ch2_relay_mode = "1"
        End If

        If proportional_cl_relay.Checked = True Then 'proportional pwm
            app_ch2_relay_mode = "0"
        End If

        If fixed_cl_relay.Checked = True Then 'fixed pwm
            app_ch2_relay_mode = "2"
        End If

        If off_cl_relay.Checked = True Then 'off
            app_ch2_relay_mode = "3"
        End If


        If Prop_WM_cl_relay.Checked = True Then 'off
            app_ch2_relay_mode = "4"
        End If

        If PID_cl_relay.Checked = True Then 'off
            app_ch2_relay_mode = "5"
        End If



        If app_ch1_pulse1_mode <> "0" And Val(value2_ph_pulse1_3.Text) = 0 Then ' no on off
            value2_ph_pulse1_3.Text = "1"
        End If
        'If app_ch1_pulse2_mode <> "0" And Val(value2_ph_pulse2_3.Text) = 0 Then ' no on off
        '    value2_ph_pulse2_3.Text = "1"
        'End If
        If app_ch2_pulse_mode <> "0" And Val(value2_cl_pulse1_3.Text) = 0 Then ' no on off
            value2_cl_pulse1_3.Text = "1"
        End If

        If app_ch1_pulse1_mode = "0" Then '  on off
            value2_ph_pulse1_1.Text = "100"
            value2_ph_pulse1_2.Text = "0"
        End If

        If app_ch1_pulse1_mode = "4" Then '  PID
            value2_ph_pulse1_1.Text = "100"
            value2_ph_pulse1_2.Text = "0"
        End If

        'If app_ch1_pulse2_mode = "0" Then '  on off
        '    value2_ph_pulse2_1.Text = "100"
        '    value2_ph_pulse2_2.Text = "0"
        'End If
        If app_ch2_pulse_mode = "0" Then '  on off
            value2_cl_pulse1_1.Text = "100"
            value2_cl_pulse1_2.Text = "0"
        End If
        If app_ch2_pulse_mode = "4" Then '  PID
            value2_cl_pulse1_1.Text = "100"
            value2_cl_pulse1_2.Text = "0"
        End If


        If app_ch1_relay_mode = "1" Then '  on off
            value2_ph_relay_1.Text = "100"
            value2_ph_relay_2.Text = "0"
        End If
        If app_ch2_relay_mode = "1" Then '  on off
            value2_cl_relay_1.Text = "100"
            value2_cl_relay_2.Text = "0"
        End If

        If app_ch1_relay_mode = "5" Then '  PID
            value2_ph_relay_1.Text = "100"
            value2_ph_relay_2.Text = "0"
        End If
        If app_ch2_relay_mode = "5" Then '  PID
            value2_cl_relay_1.Text = "100"
            value2_cl_relay_2.Text = "0"
        End If




        Dim fattore_ch1 As Integer
        Dim fattore_ch2 As Integer


        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2)



        app_ch1_pulse1_val1_i = Val(value1_ph_pulse1_1.Text) * fattore_divisione_temp
        app_ch1_pulse1_val2_i = Val(value1_ph_pulse1_2.Text) * fattore_divisione_temp

        'app_ch1_pulse2_val1_i = Val(value1_ph_pulse2_1.Text) * fattore_divisione_temp
        'app_ch1_pulse2_val2_i = Val(value1_ph_pulse2_2.Text) * fattore_divisione_temp

        app_ch1_relay_val1_i = Val(value1_ph_relay_1.Text) * fattore_divisione_temp
        app_ch1_relay_val2_i = Val(value1_ph_relay_2.Text) * fattore_divisione_temp


        app_ch2_pulse_val1_i = Val(value1_cl_pulse1_1.Text) * fattore_divisione_temp
        app_ch2_pulse_val2_i = Val(value1_cl_pulse1_2.Text) * fattore_divisione_temp

        app_ch2_relay_val1_i = Val(value1_cl_relay_1.Text) * fattore_divisione_temp
        app_ch2_relay_val2_i = Val(value1_cl_relay_2.Text) * fattore_divisione_temp


        app_ch1_pulse1_val1 = Format(app_ch1_pulse1_val1_i, "0000")
        app_ch1_pulse1_val2 = Format(app_ch1_pulse1_val2_i, "0000")

        'app_ch1_pulse2_val1 = Format(app_ch1_pulse2_val1_i, "0000")
        'app_ch1_pulse2_val2 = Format(app_ch1_pulse2_val2_i, "0000")

        app_ch1_relay_val1 = Format(app_ch1_relay_val1_i, "0000")
        app_ch1_relay_val2 = Format(app_ch1_relay_val2_i, "0000")


        app_ch2_pulse_val1 = Format(app_ch2_pulse_val1_i, "0000")
        app_ch2_pulse_val2 = Format(app_ch2_pulse_val2_i, "0000")

        app_ch2_relay_val1 = Format(app_ch2_relay_val1_i, "0000")
        app_ch2_relay_val2 = Format(app_ch2_relay_val2_i, "0000")


        app_ch1_pulse1_perc1 = Format(Val(value2_ph_pulse1_1.Text), "000")
        app_ch1_pulse1_perc2 = Format(Val(value2_ph_pulse1_2.Text), "000")
        'app_ch1_pulse2_perc1 = Format(Val(value2_ph_pulse2_1.Text), "000")
        'app_ch1_pulse2_perc2 = Format(Val(value2_ph_pulse2_2.Text), "000")
        app_ch1_relay_perc1 = Format(Val(value2_ph_relay_1.Text), "000")
        app_ch1_relay_perc2 = Format(Val(value2_ph_relay_2.Text), "000")
        app_ch2_pulse_perc1 = Format(Val(value2_cl_pulse1_1.Text), "000")
        app_ch2_pulse_perc2 = Format(Val(value2_cl_pulse1_2.Text), "000")
        app_ch2_relay_perc1 = Format(Val(value2_cl_relay_1.Text), "000")
        app_ch2_relay_perc2 = Format(Val(value2_cl_relay_2.Text), "000")

        If app_ch1_pulse1_mode <> "3" Then  ' no prop+wm
            app_ch1_pulse1_att = Format(Val(value2_ph_pulse1_3.Text), "00000")
        End If

        If app_ch2_pulse_mode <> "3" Then ' no prop+wm
            app_ch2_pulse_att = Format(Val(value2_cl_pulse1_3.Text), "00000")
        End If
        'app_ch1_pulse2_att = Format(Val(value2_ph_pulse2_3.Text), "00")
        If app_ch1_pulse1_mode = "3" Then  '  prop+wm

            Dim app_ch1_pulse1_att_i As Integer

            app_ch1_pulse1_att_i = Val(value2_ph_pulse_mch.Text) * 100
            app_ch1_pulse1_att = Format(app_ch1_pulse1_att_i, "00000")
        End If

        If app_ch2_pulse_mode = "3" Then '  prop+wm

            Dim app_ch2_pulse_att_i As Integer

            app_ch2_pulse_att_i = Val(value2_cl_pulse_mch.Text) * 100


            app_ch2_pulse_att = Format(app_ch2_pulse_att_i, "00000")
        End If


        app_ch2_pulse_perc1 = Format(Val(value2_cl_pulse1_1.Text), "000")
        app_ch2_pulse_perc1 = Format(Val(value2_cl_pulse1_1.Text), "000")

        '      //------------------------------------
        '      23  (*get_data_setcl()).perc3   // quella più grande
        '24  (*get_data_setcl()).perc4   // quella più piccola

        '25  (*get_data_setev2()).m3h
        '26  (*get_data_setev2()).perc_3   // quella più grande
        '27  (*get_data_setev2()).perc_4   // quella più piccola


        '28  (*get_data_setclB()).perc3   // quella più grande
        '29  (*get_data_setclB()).perc4   // quella più piccola

        '30  (*get_data_setev2B()).m3h
        '31  (get_data_setev2B()).perc_3   // quella più grande
        '32  (*get_data_setev2B()).perc_4   // quella più piccola

        '      //------------------------------------


        '1	(*get_data_setcl()).cl_1,
        '2 	(*get_data_setcl()).cl_2,
        '3 	(*get_data_setcl()).perc_cl1,
        '4 	(*get_data_setcl()).perc_cl2,
        If app_ch1_pulse1_mode = "4" Then '   PID
            app_ch1_pulse1_val1_i = Val(value2_ph_pulse_range.Text) * fattore_divisione_temp
            app_ch1_pulse1_val2_i = Val(value2_ph_pulse_setpoint.Text) * fattore_divisione_temp

            app_ch1_pulse1_val1 = Format(app_ch1_pulse1_val1_i, "0000")
            app_ch1_pulse1_val2 = Format(app_ch1_pulse1_val2_i, "0000")


            app_ch1_pulse1_perc1 = Format(100, "000")
            app_ch1_pulse1_perc2 = Format(0, "000")

        End If


        If app_ch2_pulse_mode = "4" Then '   PID
            app_ch2_pulse_val1_i = Val(value2_cl_pulse_range.Text) * fattore_divisione_temp
            app_ch2_pulse_val2_i = Val(value2_cl_pulse_setpoint.Text) * fattore_divisione_temp

            app_ch2_pulse_val1 = Format(app_ch2_pulse_val1_i, "0000")
            app_ch2_pulse_val2 = Format(app_ch2_pulse_val2_i, "0000")


            app_ch2_pulse_perc1 = Format(100, "000")
            app_ch2_pulse_perc2 = Format(0, "000")

        End If



        If app_ch1_relay_mode = "5" Then '   PID
            app_ch1_relay_val1_i = Val(value2_ph_relay_setpoint.Text) * fattore_divisione_temp
            app_ch1_relay_val2_i = Val(value2_ph_relay_range.Text) * fattore_divisione_temp

            app_ch1_relay_val1 = Format(app_ch1_relay_val1_i, "0000")
            app_ch1_relay_val2 = Format(app_ch1_relay_val2_i, "0000")


            app_ch1_relay_perc1 = Format(100, "000")
            app_ch1_relay_perc2 = Format(0, "000")

        End If

        If app_ch2_relay_mode = "5" Then '   PID
            app_ch2_relay_val1_i = Val(value2_cl_relay_setpoint.Text) * fattore_divisione_temp
            app_ch2_relay_val2_i = Val(value2_cl_relay_range.Text) * fattore_divisione_temp

            app_ch2_relay_val1 = Format(app_ch2_relay_val1_i, "0000")
            app_ch2_relay_val2 = Format(app_ch2_relay_val2_i, "0000")


            app_ch2_relay_perc1 = Format(100, "000")
            app_ch2_relay_perc2 = Format(0, "000")

        End If
        

       



        Dim app_value2_ph_pulse_perc4 As String
        Dim app_value2_ph_pulse_perc3 As String

        app_value2_ph_pulse_perc4 = Format(Val(value2_ph_pulse_perc4.Text), "000")
        app_value2_ph_pulse_perc3 = Format(Val(value2_ph_pulse_perc3.Text), "000")

        Dim app_value2_cl_pulse_perc4 As String
        Dim app_value2_cl_pulse_perc3 As String

        app_value2_cl_pulse_perc4 = Format(Val(value2_cl_pulse_perc4.Text), "000")
        app_value2_cl_pulse_perc3 = Format(Val(value2_cl_pulse_perc3.Text), "000")

        Dim app_value2_ph_relay_perc4 As String
        Dim app_value2_ph_relay_perc3 As String

        Dim app_value2_cl_relay_perc4 As String
        Dim app_value2_cl_relay_perc3 As String

        app_value2_ph_relay_perc4 = Format(Val(value2_ph_relay_perc4.Text), "000")
        app_value2_ph_relay_perc3 = Format(Val(value2_ph_relay_perc3.Text), "000")


        app_value2_cl_relay_perc4 = Format(Val(value2_cl_relay_perc4.Text), "000")
        app_value2_cl_relay_perc3 = Format(Val(value2_cl_relay_perc3.Text), "000")


        Dim app_value2_ph_relay_mch_i As Integer
        Dim app_value2_cl_relay_mch_i As Integer

        Dim app_value2_ph_relay_mch_s As String
        Dim app_value2_cl_relay_mch_s As String


        app_value2_ph_relay_mch_i = Val(value2_ph_relay_mch.Text) * 100
        app_value2_ph_relay_mch_s = Format(app_value2_ph_relay_mch_i, "00000")


        app_value2_cl_relay_mch_i = Val(value2_cl_relay_mch.Text) * 100
        app_value2_cl_relay_mch_s = Format(app_value2_cl_relay_mch_i, "00000")


        '33	(*get_data_pid ()).Mode_cl   // 0 - 1 +
        '34	(*get_data_pid ()).Tempo_Int
        '35	(*get_data_pid ()).Tempo_Der




        Dim app_value_time_int As String
        Dim app_value_time_der As String
        Dim app_pid_mode As String


        If CL_P.Checked = True Then
            app_pid_mode = "1"
        End If

        If CL_M.Checked = True Then
            app_pid_mode = "0"
        End If
        app_value_time_int = Format(Val(value_time_int.Text), "00000")
        app_value_time_der = Format(Val(value_time_der.Text), "0000")

        Dim app_mch_pert_i As Integer
        Dim app_mch_pert As String
        Dim app_perc_pert As String
        Dim app_pert_mode As String

        '36	(*get_data_per()).Input_mode// 0 Dis  1 add  2 molt
        '37	(*get_data_per()).Percentuale
        '38	(*get_data_per()).M3H




        If Additive.Checked = True Then
            app_pert_mode = "1"
        End If

        If Disable.Checked = True Then
            app_pert_mode = "0"
        End If
        If Multiplicative.Checked = True Then
            app_pert_mode = "2"
        End If

        app_perc_pert = Format(Val(value_perc.Text), "000")

        app_mch_pert_i = Val(value_mch.Text) * 100
        app_mch_pert = Format(app_mch_pert_i, "00000")


        '39	(*get_save_meter()).Mode  // 0 L/P 1 P/L 2 0/20 3 4/20
        '40	(*get_save_meter()).Numero
        '41	(*get_save_meter()).TIMEOUT


        Dim app_mch_wm_i As Integer
        Dim app_mch_wm As String
        Dim app_wm_time As String
        Dim app_wm_mode As String


        app_wm_time = Format(Val(value_timeout.Text), "000")


        If ModeP_L.Checked = True Then
            app_wm_mode = "1"
        End If
        If ModeL_P.Checked = True Then
            app_wm_mode = "0"
        End If
        If Mode0_20.Checked = True Then
            app_wm_mode = "2"
        End If
        If Mode4_20.Checked = True Then
            app_wm_mode = "3"
        End If

        app_mch_wm_i = Val(value_wm.Text) * 100
        app_mch_wm = Format(app_mch_wm_i, "00000")













        ' Risultato = app_ch1_pulse1_val1 + app_ch1_pulse1_val2 + app_ch1_pulse1_perc1 + app_ch1_pulse1_perc2 + app_ch1_pulse1_att + app_ch1_pulse1_mode + app_ch1_relay_val1 + app_ch1_relay_val2 + app_ch1_relay_perc1 + app_ch1_relay_perc2 + app_ch1_relay_mode + app_ch1_pulse2_val1 + app_ch1_pulse2_val2 + app_ch1_pulse2_perc1 + app_ch1_pulse2_perc2 + app_ch1_pulse2_att + app_ch1_pulse2_mode + app_ch2_pulse_val1 + app_ch2_pulse_val2 + app_ch2_pulse_perc1 + app_ch2_pulse_perc2 + app_ch2_pulse_att + app_ch2_pulse_mode + app_ch2_relay_val1 + app_ch2_relay_val2 + app_ch2_relay_perc1 + app_ch2_relay_perc2 + app_ch2_relay_mode
        Risultato = app_ch1_pulse1_val1 + app_ch1_pulse1_val2 + app_ch1_pulse1_perc1 + app_ch1_pulse1_perc2 + app_ch1_pulse1_att + app_ch1_pulse1_mode + app_ch1_relay_val1 + app_ch1_relay_val2 + app_ch1_relay_perc1 + app_ch1_relay_perc2 + app_ch1_relay_mode + app_ch2_pulse_val1 + app_ch2_pulse_val2 + app_ch2_pulse_perc1 + app_ch2_pulse_perc2 + app_ch2_pulse_att + app_ch2_pulse_mode + app_ch2_relay_val1 + app_ch2_relay_val2 + app_ch2_relay_perc1 + app_ch2_relay_perc2 + app_ch2_relay_mode + app_value2_ph_pulse_perc3 + app_value2_ph_pulse_perc4 + app_value2_ph_relay_mch_s + app_value2_ph_relay_perc3 + app_value2_ph_relay_perc4 + app_value2_cl_pulse_perc3 + app_value2_cl_pulse_perc4 + app_value2_cl_relay_mch_s + app_value2_cl_relay_perc3 + app_value2_cl_relay_perc4 + app_pid_mode + app_value_time_int + app_value_time_der + app_pert_mode + app_perc_pert + app_mch_pert + app_wm_mode + app_mch_wm + app_wm_time

        Return id_485_impianto + "setpnw" + Risultato + "setpnwend" & Chr(13)
    End Function
    Protected Sub save_setpointldsC_new_Click(sender As Object, e As EventArgs) Handles save_setpointldsC_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeSETString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=55" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class