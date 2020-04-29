


Public Class setpoint_ch
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub setpoint_ch_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            canale = Page.Request("canale")
            posiziona_setpoint(nome_impianto, codice_impianto, id_485_impianto, canale, "SetPoint")
        End If
    End Sub
    Public Sub posiziona_setpoint(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                                  ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim data_sp1() As String
        Dim data_sp2() As String
        Dim data_sp3() As String
        Dim data_sp4() As String
        Dim data_sp5() As String
        Dim name_sp1() As String
        Dim name_sp2() As String
        Dim name_sp3() As String
        Dim name_sp4() As String
        Dim name_sp5() As String
        Dim config_value() As String
        Dim option_value() As String
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer

        Dim full_scale_temp As Single
        Dim fattore_divisione_combinato As Integer = 1
        Dim mA_enable As Boolean = False

        Dim number_version As Integer = 0
        tabella_strumento = (Session("strumento"))

        ' abilito pulsante modifica
        save_setpoint_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpoint_new, ""))


        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        data_sp1 = main_function.get_split_str(riga_strumento.value5)
        data_sp2 = main_function.get_split_str(riga_strumento.value6)
        data_sp3 = main_function.get_split_str(riga_strumento.value7)
        data_sp4 = main_function.get_split_str(riga_strumento.value8)
        data_sp5 = main_function.get_split_str(riga_strumento.value9)

        config_value = main_function.get_split_str(riga_strumento.value1)
        option_value = main_function.get_split_str(riga_strumento.value4)

        number_version = main_function.get_version_integer(riga_strumento.nome)

        If number_version > 29 Then
            name_sp1 = main_function.get_split_str(riga_strumento.value10)
            name_sp2 = main_function.get_split_str(riga_strumento.value11)
            name_sp3 = main_function.get_split_str(riga_strumento.value12)
            name_sp4 = main_function.get_split_str(riga_strumento.value13)
            name_sp5 = main_function.get_split_str(riga_strumento.value14)
        End If

        mA_enable = main_function_config.get_ma_enable(config_value(0))

        Select Case canale
            Case "1" ' set point ch1
                label_canale_temp = main_function_config.get_tipo_strumento_max5(canale, config_value(0), option_value(0), fattore_divisione_temp, full_scale_temp, , , fattore_divisione_combinato)
                setpoint_channel.Text = setpoint_traduzione + " Ch1 " + label_canale_temp
                set_fullscale(full_scale_temp, mA_enable)
                set_setpoint(data_sp1(0), data_sp1(1), data_sp1(2), data_sp1(3), data_sp1(4), data_sp1(5), data_sp1(6), data_sp1(7), data_sp1(8), data_sp1(9), data_sp1(10), fattore_divisione_temp, number_version, name_sp1)
            Case "2" ' set point ch2
                label_canale_temp = main_function_config.get_tipo_strumento_max5(canale, config_value(1), option_value(0), fattore_divisione_temp, full_scale_temp, , , fattore_divisione_combinato)

                setpoint_channel.Text = setpoint_traduzione + " Ch2 " + label_canale_temp
                set_fullscale(full_scale_temp, mA_enable)
                set_setpoint(data_sp2(0), data_sp2(1), data_sp2(2), data_sp2(3), data_sp2(4), data_sp2(5), data_sp2(6), data_sp2(7), data_sp2(8), data_sp2(9), data_sp2(10), fattore_divisione_temp, number_version, name_sp2)
            Case "3" ' set point ch3
                label_canale_temp = main_function_config.get_tipo_strumento_max5(canale, config_value(2), option_value(0), fattore_divisione_temp, full_scale_temp, , , fattore_divisione_combinato)
                If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" Then
                    label_canale_temp = "HClO"
                    full_scale_temp = 5
                    fattore_divisione_temp = 1000
                End If
                setpoint_channel.Text = setpoint_traduzione + " Ch3 " + label_canale_temp
                set_fullscale(full_scale_temp, mA_enable)
                set_setpoint(data_sp3(0), data_sp3(1), data_sp3(2), data_sp3(3), data_sp3(4), data_sp3(5), data_sp3(6), data_sp3(7), data_sp3(8), data_sp3(9), data_sp3(10), fattore_divisione_temp, number_version, name_sp3)
            Case "4" ' set point ch4
                label_canale_temp = main_function_config.get_tipo_strumento_max5(canale, config_value(3), option_value(0), fattore_divisione_temp, full_scale_temp, , , fattore_divisione_combinato)
                If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" Then
                    label_canale_temp = "Cl2"
                    full_scale_temp = 20
                    fattore_divisione_temp = 100
                End If
                setpoint_channel.Text = setpoint_traduzione + " Ch4 " + label_canale_temp
                set_fullscale(full_scale_temp, mA_enable)
                set_setpoint(data_sp4(0), data_sp4(1), data_sp4(2), data_sp4(3), data_sp4(4), data_sp4(5), data_sp4(6), data_sp4(7), data_sp4(8), data_sp4(9), data_sp4(10), fattore_divisione_temp, number_version, name_sp4)
            Case "5" ' set point ch5
                label_canale_temp = main_function_config.get_tipo_strumento_max5(canale, config_value(4), option_value(0), fattore_divisione_temp, full_scale_temp, , , fattore_divisione_combinato)
                setpoint_channel.Text = setpoint_traduzione + " Ch5 " + label_canale_temp
                set_fullscale(full_scale_temp, mA_enable)
                set_setpoint(data_sp5(0), data_sp5(1), data_sp5(2), data_sp5(3), data_sp5(4), data_sp5(5), data_sp5(6), data_sp5(7), data_sp5(8), data_sp5(9), data_sp5(10), fattore_divisione_temp, number_version, name_sp5)
        End Select
    End Sub
    Public Sub set_setpoint(ByVal point_enable As String, ByVal point_d1a As String, ByVal point_d1b As String, ByVal point_p1a As String, ByVal point_p1b As String, ByVal point_ma1 As String, ByVal point_A1a As String, ByVal point_A1b As String, ByVal point_ad1 As String, ByVal point_ar1 As String, ByVal point_sms As String, ByVal scale_sp As Integer, ByVal version As Integer, ByVal name() As String)
        Dim j As Integer = 0
        Dim java_script_variable As java_script = New java_script
        Dim function_javascript As String = ""

        If version > 29 Then
            name(0) = name(0).Replace("ph", "")
            For j = 0 To name.Length - 1
                name(j) = name(j).Replace("-", "")
            Next
            setting_name(name)
        Else 'disattivare label e texbox per ver. minore 3.0.0
            id_aa_name_relay.Visible = False
            id_aa_name_relay_t.Visible = False
            id_aa_name_input.Visible = False
            id_aa_name_input_t.Visible = False

            id_ab_name_relay.Visible = False
            id_ab_name_relay_t.Visible = False
            id_ab_name_input.Visible = False
            id_ab_name_input_t.Visible = False

            id_pa_name_pulse.Visible = False
            id_pa_name_pulse_t.Visible = False
            id_pa_name_input.Visible = False
            id_pa_name_input_t.Visible = False

            id_pb_name_pulse.Visible = False
            id_pb_name_pulse_t.Visible = False
            id_pb_name_input.Visible = False
            id_pb_name_input_t.Visible = False

            id_ma_name_pulse.Visible = False
            id_ma_name_pulse_t.Visible = False
            id_ma_name_input.Visible = False
            id_ma_name_input_t.Visible = False

            value_aa1_name_l.Visible = False
            value_aa1_name.Visible = False
            stop_setpoint_aa1_l.Visible = False
            stop_setpoint_aa1.Visible = False

            value_ab1_name_l.Visible = False
            value_ab1_name.Visible = False
            stop_setpoint_ab1_l.Visible = False
            stop_setpoint_ab1.Visible = False

            value_ad_name_l.Visible = False
            value_ad_name.Visible = False
            stop_setpoint_ad_l.Visible = False
            stop_setpoint_ad.Visible = False

            value_ar_name_l.Visible = False
            value_ar_name.Visible = False
            stop_setpoint_ar_l.Visible = False
            stop_setpoint_ar.Visible = False

        End If
        If Mid(point_enable, 3, 1) <> "0" Then ' da
            enable_aa.Checked = True
            function_javascript = function_javascript + "enable_channel_aa();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_aa()")
            'enable_digital(ASPxPanel6, ASPxPanel4)
            Select Case Mid(point_d1a, 3, 1)
                Case "0" 'on/off
                    on_off_aa.Checked = True
                    'chiamato on/off java script
                    function_javascript = function_javascript + "enable_on_off_aa();"
                    'java_script_variable.call_function_javascript_onload(Page, "enable_on_off_aa()")
                    Dim temp_calc As Single = Val(Mid(point_d1a, 4, 4)) / scale_sp 'on
                    value_on_aa_id.Text = Replace(temp_calc.ToString(), ",", ".")
                    temp_calc = Val(Mid(point_d1a, 8, 4)) / scale_sp  'off
                    value_off_aa_id.Text = Replace(temp_calc.ToString(), ",", ".")

                    If Mid(point_d1a, 22, 1) = "0" Then
                        index_relay_aa.SelectedIndex = 0
                    Else
                        index_relay_aa.SelectedIndex = Val(Mid(point_d1a, 22, 1)) 'relay
                    End If

                    If Mid(point_d1a, 20, 1) = "0" Then
                        index_level_aa.SelectedIndex = 0

                    Else
                        index_level_aa.SelectedIndex = Val(Mid(point_d1a, 20, 1))  'level
                    End If
                    If Mid(point_d1a, 21, 1) = "1" Then
                        stop_input_aa.SelectedIndex = 0  'yes
                    Else
                        stop_input_aa.SelectedIndex = 1 'no
                    End If

                    set_sms_check(point_sms, Mid(point_sms, 3, 1), sms_check_aa)

                Case "1" 'pwm
                    pwm_aa.Checked = True
                    'chiamato on/off java script
                    function_javascript = function_javascript + "enable_pwm_aa();"
                    'java_script_variable.call_function_javascript_onload(Page, "enable_pwm_aa()")

                    Dim temp_calc As Single = Val(Mid(point_d1a, 4, 4)) / scale_sp 'on
                    value_on_aa_id.Text = Replace(temp_calc.ToString(), ",", ".")
                    temp_calc = Val(Mid(point_d1a, 8, 4)) / scale_sp  'off
                    value_off_aa_id.Text = Replace(temp_calc.ToString(), ",", ".")

                    temp_calc = Val(Mid(point_d1a, 12, 4)) 'pwm ON
                    value_perc1_aa_id.Text = Replace(temp_calc.ToString(), ",", ".")

                    temp_calc = Val(Mid(point_d1a, 16, 4))  'pwm off
                    value_perc2_aa_id.Text = Replace(temp_calc.ToString(), ",", ".")  'pwm off

                    If Mid(point_d1a, 22, 1) = "0" Then
                        index_relay_aa.SelectedIndex = 0
                    Else
                        index_relay_aa.SelectedIndex = Val(Mid(point_d1a, 22, 1)) 'relay
                    End If

                    If Mid(point_d1a, 20, 1) = "0" Then
                        index_level_aa.SelectedIndex = 0

                    Else
                        index_level_aa.SelectedIndex = Val(Mid(point_d1a, 20, 1))  'level
                    End If
                    If Mid(point_d1a, 21, 1) = "1" Then
                        stop_input_aa.SelectedIndex = 0  'yes
                    Else
                        stop_input_aa.SelectedIndex = 1 'no
                    End If

                    set_sms_check(point_sms, Mid(point_sms, 3, 1), sms_check_aa)
                Case "2" 'pid
                    pid_aa.Checked = True
                    'chiamato on/off java script
                    function_javascript = function_javascript + "enable_pid_aa();"
                    'java_script_variable.call_function_javascript_onload(Page, "enable_pid_aa()")

            End Select
        Else

            disable_aa.Checked = True
            function_javascript = function_javascript + "disable_channel_aa();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_aa()")
        End If
        If Mid(point_enable, 4, 1) <> "0" Then ' db_case
            on_off_ab.Checked = True
            function_javascript = function_javascript + "enable_channel_ab();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_ab()")
            Select Case Mid(point_d1b, 3, 1)
                Case "0" 'on/off
                    on_off_aa.Checked = True
                    'chiamato on/off java script
                    function_javascript = function_javascript + "enable_on_off_ab();"
                    'java_script_variable.call_function_javascript_onload(Page, "enable_on_off_ab()")
                    Dim temp_calc As Single = Val(Mid(point_d1b, 4, 4)) / scale_sp 'on
                    value_on_ab_id.Text = Replace(temp_calc.ToString(), ",", ".")
                    temp_calc = Val(Mid(point_d1b, 8, 4)) / scale_sp  'off
                    value_off_ab_id.Text = Replace(temp_calc.ToString(), ",", ".")

                    If Mid(point_d1b, 14, 1) = "0" Then
                        index_relay_ab.SelectedIndex = 0
                    Else
                        index_relay_ab.SelectedIndex = Val(Mid(point_d1b, 14, 1)) 'relay
                    End If
                    If Mid(point_d1b, 12, 1) = "0" Then
                        index_level_ab.SelectedIndex = 0
                    Else
                        index_level_ab.SelectedIndex = Val(Mid(point_d1b, 12, 1))  'level
                    End If
                    If Mid(point_d1b, 13, 1) = "1" Then
                        stop_input_ab.SelectedIndex = 0  'yes
                    Else
                        stop_input_ab.SelectedIndex = 1  'no
                    End If
                    set_sms_check(point_sms, Mid(point_sms, 4, 1), sms_check_aa)
                Case "1" 'pwm
                    pwm_ab.Checked = True
                    'chiamato on/off java script
                    function_javascript = function_javascript + "enable_pwm_ab();"
                    'java_script_variable.call_function_javascript_onload(Page, "enable_pwm_ab()")

                    Dim temp_calc As Single = Val(Mid(point_d1b, 4, 4)) / scale_sp 'on
                    value_on_ab_id.Text = Replace(temp_calc.ToString(), ",", ".")
                    temp_calc = Val(Mid(point_d1b, 8, 4)) / scale_sp  'off
                    value_off_ab_id.Text = Replace(temp_calc.ToString(), ",", ".")

                    temp_calc = Val(Mid(point_d1b, 12, 4)) 'pwm ON
                    value_perc1_ab_id.Text = Replace(temp_calc.ToString(), ",", ".")

                    temp_calc = Val(Mid(point_d1b, 16, 4))  'pwm off
                    value_perc2_ab_id.Text = Replace(temp_calc.ToString(), ",", ".")  'pwm off

                    If Mid(point_d1b, 22, 1) = "0" Then
                        index_relay_ab.SelectedIndex = 0
                    Else
                        index_relay_ab.SelectedIndex = Val(Mid(point_d1b, 22, 1)) 'relay
                    End If

                    If Mid(point_d1b, 20, 1) = "0" Then
                        index_level_ab.SelectedIndex = 0

                    Else
                        index_level_ab.SelectedIndex = Val(Mid(point_d1b, 20, 1))  'level
                    End If
                    If Mid(point_d1b, 21, 1) = "1" Then
                        stop_input_ab.SelectedIndex = 0  'yes
                    Else
                        stop_input_ab.SelectedIndex = 1 'no
                    End If

                    set_sms_check(point_sms, Mid(point_sms, 3, 1), sms_check_ab)
                Case "2" 'pid
                    pid_ab.Checked = True
                    'chiamato on/off java script
                    function_javascript = function_javascript + "enable_pid_ab();"
                    'java_script_variable.call_function_javascript_onload(Page, "enable_pid_ab()")
            End Select

        Else
            disable_ab.Checked = True
            function_javascript = function_javascript + "disable_channel_ab();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_ab()")

        End If

        If Mid(point_enable, 5, 1) <> "0" Then ' pa_case
            enable_pa.Checked = True
            'chiamato on/off java script
            function_javascript = function_javascript + "enable_channel_pa();"
            ' java_script_variable.call_function_javascript_onload(Page, "enable_channel_pa()")
            Dim temp_calc As Single = Val(Mid(point_p1a, 3, 4)) / scale_sp 'on
            value_on_pa_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_p1a, 7, 4)) / scale_sp 'off
            value_off_pa_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_p1a, 11, 3)) 'pm1
            value_perc1_pa_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_p1a, 14, 3)) 'pm2
            value_perc2_pa_id.Text = Replace(temp_calc.ToString(), ",", ".")

            If Mid(point_p1a, 19, 1) = "0" Then
                index_pulse_pa.SelectedIndex = 0
            Else
                index_pulse_pa.SelectedIndex = Val(Mid(point_p1a, 19, 1)) 'opto
            End If
            If Mid(point_p1a, 17, 1) = "0" Then
                index_level_pa.SelectedIndex = 0
            Else
                index_level_pa.SelectedIndex = Val(Mid(point_p1a, 17, 1))  'level
            End If
            If Mid(point_p1a, 18, 1) = "1" Then
                stop_input_pa.SelectedIndex = 0 'yes
            Else
                stop_input_pa.SelectedIndex = 1 'no
            End If
            set_sms_check(point_sms, Mid(point_sms, 5, 1), sms_check_pa)
        Else
            disable_pa.Checked = True
            function_javascript = function_javascript + "enable_on_off_ab();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_pa()")
        End If

        If Mid(point_enable, 6, 1) <> "0" Then 'pb_case
            enable_pb.Checked = True
            'chiamato on/off java script
            function_javascript = function_javascript + "enable_channel_pb();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_pb()")

            Dim temp_calc As Single = Val(Mid(point_p1b, 3, 4)) / scale_sp 'on
            value_on_pb_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_p1b, 7, 4)) / scale_sp 'off
            value_off_pb_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_p1b, 11, 3)) 'pm1
            value_perc1_pb_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_p1b, 14, 3)) 'pm2
            value_perc2_pb_id.Text = Replace(temp_calc.ToString(), ",", ".")
            If Mid(point_p1b, 19, 1) = "0" Then
                index_pulse_pb.SelectedIndex = 0
            Else
                index_pulse_pb.SelectedIndex = Val(Mid(point_p1b, 19, 1)) 'opto
            End If
            If Mid(point_p1b, 17, 1) = "0" Then
                index_level_pb.SelectedIndex = 0
            Else
                index_level_pb.SelectedIndex = Val(Mid(point_p1b, 17, 1))  'level
            End If
            If Mid(point_p1b, 18, 1) = "1" Then
                stop_input_pb.SelectedIndex = 0 'yes
            Else
                stop_input_pb.SelectedIndex = 1 ' no 
            End If
            set_sms_check(point_sms, Mid(point_sms, 6, 1), sms_check_pb)
        Else
            disable_pb.Checked = True
            function_javascript = function_javascript + "disable_channel_pb();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_pb()")
        End If

        If Mid(point_enable, 7, 1) <> "0" Then 'ma_case
            enable_ma.Checked = True
            'chiamato on/off java scriptù
            function_javascript = function_javascript + "enable_channel_ma();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_ma()")

            Dim temp_calc As Single = Val(Mid(point_ma1, 3, 4)) / scale_sp 'on
            value_on_ma_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_ma1, 7, 4)) / scale_sp 'off
            value_off_ma_id.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(Mid(point_ma1, 11, 3)) / 10 'ma1
            value_perc1_ma_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_ma1, 14, 3)) / 10 'ma2
            value_perc2_ma_id.Text = Replace(temp_calc.ToString(), ",", ".")

            If Mid(point_ma1, 19, 1) = "0" Then
                index_pulse_ma.SelectedIndex = 0
            Else
                index_pulse_ma.SelectedIndex = Val(Mid(point_ma1, 19, 1)) 'ma
            End If
            If Mid(point_ma1, 17, 1) = "0" Then
                index_level_ma.SelectedIndex = 0
            Else
                index_level_ma.SelectedIndex = Val(Mid(point_ma1, 17, 1))  'level
            End If
            If Mid(point_ma1, 18, 1) = "1" Then
                stop_input_ma.SelectedIndex = 0 'yes
            Else
                stop_input_ma.SelectedIndex = 1 ' no 
            End If
            set_sms_check(point_sms, Mid(point_sms, 6, 1), sms_check_ma)

        Else
            disable_ma.Checked = True
            function_javascript = function_javascript + "disable_channel_ma();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_ma()")
        End If


        If Mid(point_enable, 8, 1) <> "0" Then ' alarm A
            enable_aa1.Checked = True
            'chiamato on/off java script
            function_javascript = function_javascript + "enable_channel_aa1();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_aa1()")

            If Mid(point_A1a, 3, 1) = "1" Then ' alarm on - off 
                alarm_aa1.SelectedIndex = 0 'on
                'ASPxComboBox19.Text = "Rele On"
            Else
                alarm_aa1.SelectedIndex = 1 'off
                'ASPxComboBox19.Text = "Rele Off"
            End If
            Dim temp_calc As Single = Val(Mid(point_A1a, 5, 4)) / scale_sp 'on
            value_alarm_aa1_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_A1a, 9, 2))
            value_aa1_delay.Text = Replace(temp_calc.ToString(), ",", ".")

            If Mid(point_A1a, 4, 1) = "1" Then
                range_aa1.SelectedIndex = 0  '>
                'ASPxComboBox20.Value = ">"  '>
                'ASPxComboBox20.Text = ">"
            Else
                range_aa1.SelectedIndex = 1  '>
                'ASPxComboBox20.Value = "<" '<
                'ASPxComboBox20.Text = "<"
            End If

            If version > 29 Then ' versioni superiori alla 2.9.0
                If Mid(point_A1a, 11, 1) = "1" Then
                    stop_setpoint_aa1.Checked = True
                Else
                    stop_setpoint_aa1.Checked = False
                End If
            End If

            set_sms_check(point_sms, Mid(point_sms, 8, 1), sms_check_aa1)
        Else
            disable_aa1.Checked = True
            function_javascript = function_javascript + "disable_channel_aa1();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_aa1()")
        End If
        If Mid(point_enable, 9, 1) <> "0" Then ' alarm B
            enable_ab1.Checked = True
            'chiamato on/off java script
            function_javascript = function_javascript + "enable_channel_ab1();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_ab1()")

            If Mid(point_A1b, 3, 1) = "1" Then ' alarm on - off
                alarm_ab1.SelectedIndex = 0 'on
                'ASPxComboBox19.Text = "Rele On"
            Else
                alarm_ab1.SelectedIndex = 1 'off
                'ASPxComboBox19.Text = "Rele Off"
            End If
            Dim temp_calc As Single = Val(Mid(point_A1b, 5, 4)) / scale_sp 'on
            value_alarm_ab1_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_A1b, 9, 2))
            value_ab1_delay.Text = Replace(temp_calc.ToString(), ",", ".")

            If Mid(point_A1b, 4, 1) = "1" Then
                range_ab1.SelectedIndex = 0  '>
                'ASPxComboBox20.Value = ">"  '>
                'ASPxComboBox20.Text = ">"
            Else
                range_ab1.SelectedIndex = 1  '<
                'ASPxComboBox20.Value = "<" '<
                'ASPxComboBox20.Text = "<"
            End If

            If version > 29 Then ' versioni superiori alla 2.9.0
                If Mid(point_A1b, 11, 1) = "1" Then
                    stop_setpoint_ab1.Checked = True
                Else
                    stop_setpoint_ab1.Checked = False
                End If
            End If

            set_sms_check(point_sms, Mid(point_sms, 9, 1), sms_check_ab1)
        Else
            disable_ab1.Checked = True
            function_javascript = function_javascript + "disable_channel_ab1();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_ab1()")
        End If

        If Mid(point_enable, 10, 1) <> "0" Then ' ad
            enable_ad.Checked = True
            function_javascript = function_javascript + "enable_channel_ad();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_ad()")
            Dim temp_calc As Single = Val(Mid(point_ad1, 3, 1)) 'h
            value_alarm_ore_ad_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_ad1, 4, 2))
            value_alarm_min_ad_id.Text = Replace(temp_calc.ToString(), ",", ".")

            If version > 29 Then ' versioni superiori alla 2.9.0
                If Mid(point_ad1, 6, 1) = "1" Then
                    stop_setpoint_ad.Checked = True
                Else
                    stop_setpoint_ad.Checked = False
                End If
            End If


            set_sms_check(point_sms, Mid(point_sms, 10, 1), sms_check_ad)
        Else
            disable_ad.Checked = True
            function_javascript = function_javascript + "disable_channel_ad();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_ad()")
        End If

        If Mid(point_enable, 11, 1) <> "0" Then ' ar 
            enable_ar.Checked = True
            function_javascript = function_javascript + "enable_channel_ar();"
            'java_script_variable.call_function_javascript_onload(Page, "enable_channel_ar()")
            Dim temp_calc As Single = Val(Mid(point_ar1, 3, 1)) 'h
            value_alarm_ore_ar_id.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(Mid(point_ar1, 4, 2))
            value_alarm_min_ar_id.Text = Replace(temp_calc.ToString(), ",", ".")

            If version > 29 Then ' versioni superiori alla 2.9.0
                If Mid(point_ar1, 6, 1) = "1" Then
                    stop_setpoint_ar.Checked = True
                Else
                    stop_setpoint_ar.Checked = False
                End If
            End If

            set_sms_check(point_sms, Mid(point_sms, 11, 1), sms_check_ar)
        Else
            disable_ar.Checked = True
            function_javascript = function_javascript + "disable_channel_ar();"
            'java_script_variable.call_function_javascript_onload(Page, "disable_channel_ar()")
        End If
        java_script_variable.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Public Sub set_sms_check(ByVal stringa As String, ByVal stringa1 As String, ByVal sms As System.Web.UI.WebControls.CheckBox)
        If stringa <> "null" Then
            sms.Visible = True

            If stringa1 = "1" Then
                sms.Checked = True
            Else
                sms.Checked = False
            End If
        Else
            sms.Visible = False
        End If

    End Sub
    Public Sub setting_name(ByVal nomi() As String)
        If nomi(0).Length > 0 Then
            tab1.Text = nomi(0)
            id_aa_name_relay_t.Text = nomi(0)
        End If
        If nomi(1).Length > 0 Then
            id_aa_name_input_t.Text = nomi(1)
        End If
        If nomi(2).Length > 0 Then
            tab2.Text = nomi(2)
            id_ab_name_relay_t.Text = nomi(2)
        End If
        If nomi(3).Length > 0 Then
            id_ab_name_input_t.Text = nomi(3)
        End If

        If nomi(4).Length > 0 Then
            tab3.Text = nomi(4)
            id_pa_name_pulse_t.Text = nomi(4)
        End If
        If nomi(5).Length > 0 Then
            id_pa_name_input_t.Text = nomi(5)
        End If

        If nomi(6).Length > 0 Then
            tab4.Text = nomi(6)
            id_pb_name_pulse_t.Text = nomi(6)
        End If
        If nomi(7).Length > 0 Then
            id_pb_name_input_t.Text = nomi(7)
        End If

        If nomi(8).Length > 0 Then
            tab5.Text = nomi(8)
            id_ma_name_pulse_t.Text = nomi(8)
        End If
        If nomi(9).Length > 0 Then
            id_ma_name_input_t.Text = nomi(9)
        End If

        If nomi(10).Length > 0 Then
            tab6.Text = nomi(10)
            value_aa1_name.Text = nomi(10)
        End If
        If nomi(11).Length > 0 Then
            tab7.Text = nomi(11)
            value_ab1_name.Text = nomi(11)
        End If
        If nomi(12).Length > 0 Then
            tab8.Text = nomi(12)
            value_ad_name.Text = nomi(12)
        End If
        If nomi(13).Length > 0 Then
            tab9.Text = nomi(13)
            value_ad_name.Text = nomi(13)
        End If

    End Sub
    Public Sub set_fullscale(ByVal range As Single, ByVal ma_enable As Boolean)
        Dim java_script_variable As java_script = New java_script
        Dim mask_form As String = ""
        Dim mask_fix As Integer
        Dim set_variable_javascript(9, 1) As String

        If range >= 0 And range <= 9.9990000000000006 Then
            mask_form = "9.999"
            mask_fix = 3
        End If
        If range >= 10 And range <= 99.989999999999995 Then
            mask_form = "99.99"
            mask_fix = 2
        End If
        If range >= 100 And range <= 999.89999999999998 Then
            mask_form = "999.9"
            mask_fix = 1
        End If
        If range >= 1000 And range <= 9999 Then
            mask_form = "9999"
            mask_fix = 0
        End If
        set_variable_javascript(0, 0) = "max_ch_value"
        set_variable_javascript(0, 1) = range.ToString
        set_variable_javascript(1, 0) = "min_ch_value"
        set_variable_javascript(1, 1) = "0"

        set_variable_javascript(2, 0) = "max_fix_value"
        set_variable_javascript(2, 1) = mask_fix.ToString

        set_variable_javascript(3, 0) = "max_percent_value"
        set_variable_javascript(3, 1) = "100"
        set_variable_javascript(4, 0) = "min_percent_value"
        set_variable_javascript(4, 1) = "0"

        set_variable_javascript(5, 0) = "max_pulse_value"
        set_variable_javascript(5, 1) = "180"
        set_variable_javascript(6, 0) = "min_pulse_value"
        set_variable_javascript(6, 1) = "0"

        set_variable_javascript(7, 0) = "max_ma_value"
        set_variable_javascript(7, 1) = "20"
        set_variable_javascript(8, 0) = "min_ma_value"
        set_variable_javascript(8, 1) = "0"

        If (ma_enable) Then
            set_variable_javascript(9, 0) = "ma_enable"
            set_variable_javascript(9, 1) = "1"
        Else
            set_variable_javascript(9, 0) = "ma_enable"
            set_variable_javascript(9, 1) = "0"
        End If

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 9)

        'value_on_aa_id_MaskedEditExtender.Mask = mask_form
        'value_off_aa_id_MaskedEditExtender.Mask = mask_form
        'value_perc1_aa_id_MaskedEditExtender.Mask = "999"
        'value_perc2_aa_id_MaskedEditExtender.Mask = "999"
    End Sub
    Public Function get_setpoint_new(ByVal mult_val As Integer, ByVal canale As String, ByVal versione_global As Integer) As String
        Dim Risultato As String
        Dim set_point_enable_new As String = ""
        Dim set_point_d1a_new As String = ""
        Dim set_point_P1a_new As String = ""
        Dim set_point_P1b_new As String = ""
        Dim set_point_d1b_new As String = ""
        Dim set_point_mA1_new As String = ""
        Dim set_point_sms_new As String = ""
        Dim set_point_A1a_new As String = ""
        Dim set_point_A1b_new As String = ""
        Dim set_point_AD1_new As String = ""
        Dim set_point_AR1_new As String = ""
        If enable_aa.Checked Then
            set_point_enable_new = "ph1"
            'Da setting
            If on_off_aa.Checked Then
                set_point_d1a_new = "ph0" & Format(Val(value_on_aa_id.Text) * mult_val, "0000") & Format(Val(value_off_aa_id.Text) * mult_val, "0000")
                set_point_d1a_new = set_point_d1a_new & "00000000"
                set_point_d1a_new = set_point_d1a_new & Format(Val(index_level_aa.SelectedValue), "0")
                'If (index_relay_aa.Text = "X") Then
                '    set_point_d1a_new = set_point_d1a_new & "0"
                'Else
                '    set_point_d1a_new = set_point_d1a_new & Format(Val(ASPxComboBox5.Value), "0")
                'End If
                If stop_input_aa.SelectedValue = "0" Then
                    set_point_d1a_new = set_point_d1a_new & "1"
                Else
                    set_point_d1a_new = set_point_d1a_new & "0"
                End If

                set_point_d1a_new = set_point_d1a_new & Format(Val(index_relay_aa.SelectedValue), "0")

                'If (ASPxComboBox4.Text = "X") Then
                '    set_point_d1a_new = set_point_d1a_new & "0"
                'Else
                '    set_point_d1a_new = set_point_d1a_new & Format(Val(ASPxComboBox4.Value), "0")
                'End If
                set_point_sms_new = "ph" + get_sms_setting(sms_check_aa)

                If InStr(set_point_sms_new, "null") <> 0 Then
                    set_point_sms_new = "null"
                End If
                'set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & Mid(set_point_d1a(index_setpoint), 15, 11)

            End If
            If pwm_aa.Checked Then
                set_point_d1a_new = "ph1" & Format(Val(value_on_aa_id.Text) * mult_val, "0000") & Format(Val(value_off_aa_id.Text) * mult_val, "0000")
                set_point_d1a_new = set_point_d1a_new & Format(Val(value_perc1_aa_id.Text), "0000") & Format(Val(value_perc2_aa_id.Text), "0000")
                'If (ASPxComboBox5.Text = "X") Then
                '    set_point_d1a_new = set_point_d1a_new & "0"
                'Else
                '    set_point_d1a_new = set_point_d1a_new & Format(Val(ASPxComboBox5.Value), "0")
                'End If
                set_point_d1a_new = set_point_d1a_new & Format(Val(index_level_aa.SelectedValue), "0")
                If stop_input_aa.SelectedValue = "0" Then
                    set_point_d1a_new = set_point_d1a_new & "1"
                Else
                    set_point_d1a_new = set_point_d1a_new & "0"
                End If

                'If (ASPxComboBox4.Text = "X") Then
                '    set_point_d1a_new = set_point_d1a_new & "0"
                'Else
                '    set_point_d1a_new = set_point_d1a_new & Format(Val(ASPxComboBox4.Value), "0")
                'End If
                set_point_d1a_new = set_point_d1a_new & Format(Val(index_relay_aa.SelectedValue), "0")
                set_point_sms_new = "ph" + get_sms_setting(sms_check_aa)

                If InStr(set_point_sms_new, "null") <> 0 Then
                    set_point_sms_new = "null"
                End If

                'set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & Mid(set_point_d1a(index_setpoint), 15, 11)
            End If
            'If cboD1aMod.Text = "PID" Then
            '    set_point_d1a_new(index_setpoint) = "ph2" & Format(NumericUpDown187.Value * mult_val, "0000") & Format(NumericUpDown188.Value * mult_val, "0000")
            '    set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & Format((NumericUpDown12.Value * 100) + NumericUpDown13.Value, "0000") & Format((NumericUpDown14.Value * 100) + NumericUpDown15.Value, "0000")
            '    If (ComboBox13.Text = "X") Then
            '        set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & "0"
            '    Else
            '        set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & Format(Val(ComboBox13.Text), "0")
            '    End If
            '    If ComboBox4.Text = "Yes" Then
            '        set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & "1"
            '    Else
            '        set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & "0"
            '    End If
            '    If (ComboBox14.Text = "X") Then
            '        set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & "0"
            '    Else
            '        set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint) & Format(Val(ComboBox14.Text), "0")
            '    End If
            '    set_point_sms_new(index_setpoint) = "ph" + get_sms_setting(CheckBox3)
            '    If InStr(set_point_sms_new(index_setpoint), "null") <> 0 Then
            '        set_point_sms_new(index_setpoint) = "null"
            '    End If

            '    ' set_point_d1a_new(index_setpoint) = set_point_d1a_new(index_setpoint)
            'End If

        Else
            set_point_enable_new = "ph0"
            set_point_d1a_new = "ph00000000000000000000"
            set_point_sms_new = "ph" + get_sms_setting(sms_check_aa)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

            'end Da setting
            'Db setting
        End If
        If enable_ab.Checked Then
            set_point_enable_new = set_point_enable_new & "1"
            If on_off_ab.Checked Then
                set_point_d1b_new = "ph0" & Format(Val(value_on_ab_id.Text) * mult_val, "0000") & Format(Val(value_off_ab_id.Text) * mult_val, "0000")
                set_point_d1b_new = set_point_d1b_new & "00000000"
                set_point_d1b_new = set_point_d1b_new & Format(Val(index_level_ab.SelectedValue), "0")
                'If (index_relay_aa.Text = "X") Then
                '    set_point_d1a_new = set_point_d1a_new & "0"
                'Else
                '    set_point_d1a_new = set_point_d1a_new & Format(Val(ASPxComboBox5.Value), "0")
                'End If
                If stop_input_ab.SelectedValue = "0" Then
                    set_point_d1b_new = set_point_d1b_new & "1"
                Else
                    set_point_d1b_new = set_point_d1b_new & "0"
                End If

                set_point_d1b_new = set_point_d1b_new & Format(Val(index_relay_ab.SelectedValue), "0")

                'If (ASPxComboBox4.Text = "X") Then
                '    set_point_d1a_new = set_point_d1a_new & "0"
                'Else
                '    set_point_d1a_new = set_point_d1a_new & Format(Val(ASPxComboBox4.Value), "0")
                'End If
                set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ab)

                If InStr(set_point_sms_new, "null") <> 0 Then
                    set_point_sms_new = "null"
                End If

                'set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint)
            End If
            If pwm_ab.Checked Then
                set_point_d1b_new = "ph1" & Format(Val(value_on_ab_id.Text) * mult_val, "0000") & Format(Val(value_off_ab_id.Text) * mult_val, "0000")
                set_point_d1b_new = set_point_d1b_new & Format(Val(value_perc1_ab_id.Text), "0000") & Format(Val(value_perc2_ab_id.Text), "0000")
                'If (ASPxComboBox8.Text = "X") Then
                '    set_point_d1b_new = set_point_d1b_new & "0"
                'Else
                '    set_point_d1b_new = set_point_d1b_new & Format(Val(ASPxComboBox8.Value), "0")
                'End If
                set_point_d1b_new = set_point_d1b_new & Format(Val(index_level_ab.SelectedValue), "0")
                If stop_input_ab.SelectedValue = "0" Then
                    set_point_d1b_new = set_point_d1b_new & "1"
                Else
                    set_point_d1b_new = set_point_d1b_new & "0"
                End If

                'If (ASPxComboBox7.Text = "X") Then
                '    set_point_d1b_new = set_point_d1b_new & "0"
                'Else
                '    set_point_d1b_new = set_point_d1b_new & Format(Val(ASPxComboBox7.Value), "0")
                'End If
                set_point_d1b_new = set_point_d1b_new & Format(Val(index_relay_ab.SelectedValue), "0")
                'set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint)
                set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ab)
                If InStr(set_point_sms_new, "null") <> 0 Then
                    set_point_sms_new = "null"
                End If

            End If
            'If cboD1bMod.Text = "PID" Then
            '    set_point_d1b_new(index_setpoint) = "ph2" & Format(NumericUpDown193.Value * mult_val, "0000") & Format(NumericUpDown194.Value * mult_val, "0000")
            '    set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & Format((NumericUpDown27.Value * 100) + NumericUpDown25.Value, "0000") & Format((NumericUpDown23.Value * 100) + NumericUpDown22.Value, "0000")
            '    If (ComboBox23.Text = "X") Then
            '        set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & "0"
            '    Else
            '        set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & Format(Val(ComboBox23.Text), "0")
            '    End If
            '    If ComboBox22.Text = "Yes" Then
            '        set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & "1"
            '    Else
            '        set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & "0"
            '    End If
            '    If (ComboBox24.Text = "X") Then
            '        set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & "0"
            '    Else
            '        set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint) & Format(Val(ComboBox24.Text), "0")
            '    End If
            '    set_point_sms_new(index_setpoint) = set_point_sms_new(index_setpoint) + get_sms_setting(CheckBox6)
            '    If InStr(set_point_sms_new(index_setpoint), "null") <> 0 Then
            '        set_point_sms_new(index_setpoint) = "null"
            '    End If

            '    'set_point_d1b_new(index_setpoint) = set_point_d1b_new(index_setpoint)
            'End If
        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_d1b_new = "ph00000000000000000000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ab)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If


        End If
        If enable_pa.Checked Then
            set_point_enable_new = set_point_enable_new & "1"

            set_point_P1a_new = "ph" & Format(Val(value_on_pa_id.Text) * mult_val, "0000") & Format(Val(value_off_pa_id.Text) * mult_val, "0000")
            set_point_P1a_new = set_point_P1a_new & Format(Val(value_perc1_pa_id.Text), "000") & Format(Val(value_perc2_pa_id.Text), "000")
            set_point_P1a_new = set_point_P1a_new & Format(Val(index_level_pa.SelectedValue), "0")

            'If (ASPxComboBox11.Text = "X") Then
            '    set_point_P1a_new = set_point_P1a_new & "0"
            'Else
            '    set_point_P1a_new = set_point_P1a_new & Format(Val(ASPxComboBox11.Value), "0")
            'End If
            If stop_input_pa.SelectedValue = "0" Then
                set_point_P1a_new = set_point_P1a_new & "1"
            Else
                set_point_P1a_new = set_point_P1a_new & "0"
            End If
            'If (ASPxComboBox10.Text = "X") Then
            '    set_point_P1a_new = set_point_P1a_new & "0"
            'Else
            '    set_point_P1a_new = set_point_P1a_new & Format(Val(ASPxComboBox10.Value), "0")
            'End If
            set_point_P1a_new = set_point_P1a_new & Format(Val(index_pulse_pa.SelectedValue), "0")

            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_pa)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

            'set_point_P1a_new(index_setpoint) = set_point_P1a_new(index_setpoint)

        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_P1a_new = "ph00000000000000000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_pa)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        End If
        If enable_pb.Checked Then
            set_point_enable_new = set_point_enable_new & "1"

            set_point_P1b_new = "ph" & Format(Val(value_on_pb_id.Text) * mult_val, "0000") & Format(Val(value_off_pb_id.Text) * mult_val, "0000")
            set_point_P1b_new = set_point_P1b_new & Format(Val(value_perc1_pb_id.Text), "000") & Format(Val(value_perc2_pb_id.Text), "000")
            set_point_P1b_new = set_point_P1b_new & Format(Val(index_level_pb.SelectedValue), "0")
            'If (ASPxComboBox14.Text = "X") Then
            '    set_point_P1b_new = set_point_P1b_new & "0"
            'Else
            '    set_point_P1b_new = set_point_P1b_new & Format(Val(ASPxComboBox14.Value), "0")
            'End If
            If stop_input_pb.SelectedValue = "0" Then
                set_point_P1b_new = set_point_P1b_new & "1"
            Else
                set_point_P1b_new = set_point_P1b_new & "0"
            End If
            'If (ASPxComboBox13.Text = "X") Then
            '    set_point_P1b_new = set_point_P1b_new & "0"
            'Else
            '    set_point_P1b_new = set_point_P1b_new & Format(Val(ASPxComboBox13.Value), "0")
            'End If
            set_point_P1b_new = set_point_P1b_new & Format(Val(index_pulse_pb.SelectedValue), "0")
            'set_point_P1b_new(index_setpoint) = set_point_P1b_new(index_setpoint)
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_pb)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_P1b_new = "ph00000000000000000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_pb)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        End If

        If enable_ma.Checked Then
            set_point_enable_new = set_point_enable_new & "1"

            set_point_mA1_new = "ph" & Format(Val(value_on_ma_id.Text) * mult_val, "0000") & Format(Val(value_off_ma_id.Text) * mult_val, "0000")
            set_point_mA1_new = set_point_mA1_new & Format(Val(value_perc1_ma_id.Text) * 10, "000") & Format(Val(value_perc2_ma_id.Text) * 10, "000")
            set_point_mA1_new = set_point_mA1_new & Format(Val(index_level_ma.SelectedValue), "0")
            'If (ASPxComboBox17.Text = "X") Then
            '    set_point_mA1_new = set_point_mA1_new & "0"
            'Else
            '    set_point_mA1_new = set_point_mA1_new & Format(Val(ASPxComboBox17.Value), "0")
            'End If
            If stop_input_ma.SelectedValue = "0" Then
                set_point_mA1_new = set_point_mA1_new & "1"
            Else
                set_point_mA1_new = set_point_mA1_new & "0"
            End If
            'If (ASPxComboBox16.Text = "X") Then
            '    set_point_mA1_new = set_point_mA1_new & "0"
            'Else
            '    set_point_mA1_new = set_point_mA1_new & Format(Val(ASPxComboBox16.Value), "0")
            'End If
            set_point_mA1_new = set_point_mA1_new & Format(Val(index_pulse_ma.SelectedValue), "0")
            ' set_point_mA1_new(index_setpoint) = set_point_mA1_new(index_setpoint)
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ma)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_mA1_new = "ph00000000000000000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ma)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        End If
        If enable_aa1.Checked Then
            set_point_enable_new = set_point_enable_new & "1"
            set_point_A1a_new = "ph"
            If Val(alarm_aa1.SelectedValue) = 1 Then
                set_point_A1a_new = set_point_A1a_new & "1"
            Else
                set_point_A1a_new = set_point_A1a_new & "0"
            End If
            If Val(range_aa1.SelectedValue) = 0 Then ' >
                set_point_A1a_new = set_point_A1a_new & "1"
            Else
                set_point_A1a_new = set_point_A1a_new & "0"
            End If
            set_point_A1a_new = set_point_A1a_new & Format(Val(value_alarm_aa1_id.Text) * mult_val, "0000")
            set_point_A1a_new = set_point_A1a_new & Format(Val(value_aa1_delay.Text), "00")
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_aa1)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If


        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_A1a_new = "ph00000000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_aa1)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        End If
        If enable_ab1.Checked Then
            set_point_enable_new = set_point_enable_new & "1"
            set_point_A1b_new = "ph"
            If Val(alarm_ab1.SelectedValue) = 1 Then
                set_point_A1b_new = set_point_A1b_new & "1"
            Else
                set_point_A1b_new = set_point_A1b_new & "0"
            End If
            If Val(range_ab1.SelectedValue) = 0 Then ' >
                set_point_A1b_new = set_point_A1b_new & "1"
            Else
                set_point_A1b_new = set_point_A1b_new & "0"
            End If
            set_point_A1b_new = set_point_A1b_new & Format(Val(value_alarm_ab1_id.Text) * mult_val, "0000")
            set_point_A1b_new = set_point_A1b_new & Format(Val(value_ab1_delay.Text), "00")
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ab1)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If


        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_A1b_new = "ph00000000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ab1)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        End If
        If enable_ad.Checked Then
            set_point_enable_new = set_point_enable_new & "1"
            set_point_AD1_new = "ph"
            set_point_AD1_new = set_point_AD1_new & Format(Val(value_alarm_ore_ad_id.Text), "0")
            set_point_AD1_new = set_point_AD1_new & Format(Val(value_alarm_min_ad_id.Text), "00")
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ad)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If


        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_AD1_new = "ph000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ad)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        End If
        If enable_ar.Checked Then
            set_point_enable_new = set_point_enable_new & "1"
            set_point_AR1_new = "ph"
            set_point_AR1_new = set_point_AR1_new & Format(Val(value_alarm_ore_ar_id.Text), "0")
            set_point_AR1_new = set_point_AR1_new & Format(Val(value_alarm_min_ar_id.Text), "00")
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ar)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If

        Else
            set_point_enable_new = set_point_enable_new & "0"
            set_point_AR1_new = "ph000"
            set_point_sms_new = set_point_sms_new + get_sms_setting(sms_check_ar)
            If InStr(set_point_sms_new, "null") <> 0 Then
                set_point_sms_new = "null"
            End If
        End If
        If set_point_sms_new = "null" Then
            Risultato = canale & "A" & set_point_enable_new + Replace(set_point_d1a_new, "ph", "") + Replace(set_point_d1b_new, "ph", "") + Replace(set_point_P1a_new, "ph", "") + Replace(set_point_P1b_new, "ph", "") + Replace(set_point_mA1_new, "ph", "") + Replace(set_point_A1a_new, "ph", "") + Replace(set_point_A1b_new, "ph", "") + Replace(set_point_AD1_new, "ph", "") + Replace(set_point_AR1_new, "ph", "")
        Else
            Risultato = canale & "A" & set_point_enable_new + Replace(set_point_d1a_new, "ph", "") + Replace(set_point_d1b_new, "ph", "") + Replace(set_point_P1a_new, "ph", "") + Replace(set_point_P1b_new, "ph", "") + Replace(set_point_mA1_new, "ph", "") + Replace(set_point_A1a_new, "ph", "") + Replace(set_point_A1b_new, "ph", "") + Replace(set_point_AD1_new, "ph", "") + Replace(set_point_AR1_new, "ph", "") + Replace(set_point_sms_new, "ph", "")
        End If
        If versione_global > 29 Then
            If stop_setpoint_aa1.Checked Then
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If
            If stop_setpoint_ab1.Checked Then
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If
            If stop_setpoint_ad.Checked Then
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If
            If stop_setpoint_ar.Checked Then
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If
        End If
        Risultato = Risultato + "end"
        Return id_485_impianto + Risultato + Chr(13)

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
    Public Function get_setpoint_name(ByVal canale As String) As String
        Dim string_connect As String = ""
        Dim temp_string As String = ""
        string_connect = string_connect + create_function_name(10, id_aa_name_relay_t.Text)
        string_connect = string_connect + create_function_name(10, id_aa_name_input_t.Text)
        string_connect = string_connect + create_function_name(10, id_ab_name_relay_t.Text)
        string_connect = string_connect + create_function_name(10, id_ab_name_input_t.Text)
        string_connect = string_connect + create_function_name(10, id_pa_name_pulse_t.Text)
        string_connect = string_connect + create_function_name(10, id_pa_name_input_t.Text)
        string_connect = string_connect + create_function_name(10, id_pb_name_pulse_t.Text)
        string_connect = string_connect + create_function_name(10, id_pb_name_input_t.Text)
        string_connect = string_connect + create_function_name(10, id_ma_name_pulse_t.Text)
        string_connect = string_connect + create_function_name(10, id_ma_name_input_t.Text)
        string_connect = string_connect + create_function_name(10, value_aa1_name.Text)
        string_connect = string_connect + create_function_name(10, value_ab1_name.Text)
        string_connect = string_connect + create_function_name(10, value_ad_name.Text)
        string_connect = string_connect + create_function_name(10, value_ar_name.Text)
        string_connect = string_connect + "end"


        Return id_485_impianto + canale + "Bph" + string_connect + Chr(13)



    End Function
    Public Function get_sms_setting(ByVal checkbox_v As CheckBox) As String
        Dim return_sms As String
        return_sms = ""
        If checkbox_v.Visible Then
            If checkbox_v.Checked Then
                return_sms = "1"
            Else
                return_sms = "0"
            End If
        Else
            return_sms = "null"
        End If
        Return return_sms
    End Function

    Protected Sub save_setpoint_new_Click(sender As Object, e As EventArgs) Handles save_setpoint_new.Click
        'Dim javascript_function As java_script = New java_script
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
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

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        number_version = main_function.get_version_integer(riga_strumento.nome)

        local_connection = write_setpoint_new.client_connect()

        If number_version > 29 Then
            Select Case canale
                Case "1" ' set point ch1
                    new_setpoint = get_setpoint_name("6")
                Case "2" ' set point ch2
                    new_setpoint = get_setpoint_name("7")
                Case "3" ' set point ch3
                    new_setpoint = get_setpoint_name("8")
                Case "4" ' set point ch4
                    new_setpoint = get_setpoint_name("9")
                Case "5" ' set point ch5
                    new_setpoint = get_setpoint_name("A")
            End Select
            If local_connection Then ' connessione OK
                write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result, errore_primo_invio)
            Else ' server busy riprovare
                url_result = "result=3"
                errore_primo_invio = True
            End If

        End If

        config_value = main_function.get_split_str(riga_strumento.value1)
        option_value = main_function.get_split_str(riga_strumento.value4)

        Select Case canale
            Case "1" ' set point ch1
                main_function_config.get_tipo_strumento_max5(Val(canale), config_value(0), option_value(0), fattore_divisione_temp, , , , fattore_divisione_combinato)
                new_setpoint = get_setpoint_new(fattore_divisione_temp, "6", number_version)
            Case "2" ' set point ch2
                main_function_config.get_tipo_strumento_max5(Val(canale), config_value(1), option_value(0), fattore_divisione_temp, , , , fattore_divisione_combinato)
                new_setpoint = get_setpoint_new(fattore_divisione_temp, "7", number_version)
            Case "3" ' set point ch3
                main_function_config.get_tipo_strumento_max5(Val(canale), config_value(2), option_value(0), fattore_divisione_temp, , , , fattore_divisione_combinato)
                new_setpoint = get_setpoint_new(fattore_divisione_temp, "8", number_version)
            Case "4" ' set point ch4
                main_function_config.get_tipo_strumento_max5(Val(canale), config_value(3), option_value(0), fattore_divisione_temp, , , , fattore_divisione_combinato)
                new_setpoint = get_setpoint_new(fattore_divisione_temp, "9", number_version)
            Case "5" ' set point ch5
                main_function_config.get_tipo_strumento_max5(Val(canale), config_value(4), option_value(0), fattore_divisione_temp, , , , fattore_divisione_combinato)
                new_setpoint = get_setpoint_new(fattore_divisione_temp, "A", number_version)
        End Select
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
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=" + canale + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
        'Response.End()

    End Sub
End Class