Public Class range_alarm_ld4
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub range_alarm_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_range_ld4(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "high_range_alarm"), GetGlobalResourceObject("ld_global", "low_range_alarm"), GetGlobalResourceObject("ld_global", "min_max_high"), GetGlobalResourceObject("ld_global", "min_max_low"), GetGlobalResourceObject("ld_global", "time"), "Mode")
        End If
    End Sub
    Public Sub posiziona_range_ld4(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal out_range_traduzione_low As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                       ByVal time_traduzione As String, ByVal mode_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim java_script_minmax1 As java_script = New java_script
        Dim java_script_minmax2 As java_script = New java_script
        Dim function_java As String = ""
        Dim set_variable_javascript(11, 1) As String

        Dim minmax_value() As String
        Dim calibrz_value() As String

        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim full_scale_temp As Single
        Dim etichetta_setpoint As String = ""
        Dim temp_calc As Single

        ' abilito pulsante modifica
        save_rangealarmld4_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_rangealarmld4_new, ""))


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        minmax_value = main_function.get_split_str(riga_strumento.value16)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)


        Dim mode_ch1_H As String
        Dim mode_ch1_L As String

        Dim mode_ch2_H As String
        Dim mode_ch2_L As String


        Dim mode_ch3_H As String
        Dim mode_ch3_L As String

        Dim mode_ch4_H As String
        Dim mode_ch4_L As String

        Dim value_ch1_H As String
        Dim value_ch1_L As String

        Dim value_ch2_H As String
        Dim value_ch2_L As String


        Dim value_ch3_H As String
        Dim value_ch3_L As String

        Dim value_ch4_H As String
        Dim value_ch4_L As String

        Dim dose_stop_ch1 As String
        Dim dose_stop_ch2 As String
        Dim dose_stop_ch3 As String
        Dim dose_stop_ch4 As String

        Dim time_ch1 As String
        Dim time_ch2 As String
        Dim time_ch3 As String
        Dim time_ch4 As String

        mode_ch1_H = Mid(minmax_value(1), 1, 1)
        mode_ch1_L = Mid(minmax_value(3), 1, 1)
        mode_ch2_H = Mid(minmax_value(7), 1, 1)
        mode_ch2_L = Mid(minmax_value(9), 1, 1)

        mode_ch3_H = Mid(minmax_value(13), 1, 1)
        mode_ch3_L = Mid(minmax_value(15), 1, 1)

        mode_ch4_H = Mid(minmax_value(19), 1, 1)
        mode_ch4_L = Mid(minmax_value(21), 1, 1)


        function_java = ""
        If mode_ch1_H = "0" Then ' dis
            function_java = function_java + "disable_ph_alarm_high();"
            'java_script_minmax1.call_function_javascript_onload(Page, "disable_ph_alarm_high()")
            ph_alarm_high_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_ph_alarm_high();"
            'java_script_minmax1.call_function_javascript_onload(Page, "enable_ph_alarm_high()")
            ph_alarm_high_enable.Checked = True 'enabled
            'RadioButton2.Checked = False 'disabled
        End If
        If mode_ch1_L = "0" Then 'dis
            function_java = function_java + "disable_ph_alarm_low();"
            'java_script_minmax2.call_function_javascript_onload(Page, "disable_ph_alarm_low()")
            ph_alarm_low_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_ph_alarm_low();"
            ' java_script_minmax2.call_function_javascript_onload(Page, "enable_ph_alarm_low()")
            ph_alarm_low_enable.Checked = True 'enabled
        End If

        If mode_ch1_H = "0" And mode_ch1_L = "0" Then ' tutti e due disabilitati
            function_java = function_java + "disable_ph_alarm_dose();"
            'java_script_minmax3.call_function_javascript_onload(Page, "disable_ph_alarm_dose()")
        Else
            function_java = function_java + "enable_ph_alarm_dose();"
            'java_script_minmax3.call_function_javascript_onload(Page, "enable_ph_alarm_dose()")
        End If

        If mode_ch2_H = "0" Then 'dis
            function_java = function_java + "disable_cl_alarm_high();"
            'java_script_minmax4.call_function_javascript_onload(Page, "disable_cl_alarm_high()")
            cl_alarm_high_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_cl_alarm_high();"
            'java_script_minmax4.call_function_javascript_onload(Page, "enable_cl_alarm_high()")
            cl_alarm_high_enable.Checked = True 'enabled
            'RadioButton2.Checked = False 'disabled
        End If
        If mode_ch2_L = "0" Then 'dis
            function_java = function_java + "disable_cl_alarm_low();"
            'java_script_minmax5.call_function_javascript_onload(Page, "disable_cl_alarm_low()")
            cl_alarm_low_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_cl_alarm_low();"
            'java_script_minmax5.call_function_javascript_onload(Page, "enable_cl_alarm_low()")
            cl_alarm_low_enable.Checked = True 'enabled
        End If

        If mode_ch2_H = "0" And mode_ch2_L = "0" Then ' tutti e due disabilitati
            function_java = function_java + "disable_cl_alarm_dose();"
            'java_script_minmax6.call_function_javascript_onload(Page, "disable_cl_alarm_dose()")
        Else
            function_java = function_java + "enable_cl_alarm_dose();"
            'java_script_minmax6.call_function_javascript_onload(Page, "enable_cl_alarm_dose()")
        End If



        If mode_ch3_H = "0" Then 'dis
            function_java = function_java + "disable_mV_alarm_high();"
            'java_script_minmax4.call_function_javascript_onload(Page, "disable_cl_alarm_high()")
            mV_alarm_high_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_mV_alarm_high();"
            'java_script_minmax4.call_function_javascript_onload(Page, "enable_cl_alarm_high()")
            mV_alarm_high_enable.Checked = True 'enabled
            'RadioButton2.Checked = False 'disabled
        End If
        If mode_ch3_L = "0" Then 'dis
            function_java = function_java + "disable_mV_alarm_low();"
            'java_script_minmax5.call_function_javascript_onload(Page, "disable_cl_alarm_low()")
            mV_alarm_low_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_mV_alarm_low();"
            'java_script_minmax5.call_function_javascript_onload(Page, "enable_cl_alarm_low()")
            mV_alarm_low_enable.Checked = True 'enabled
        End If

        If mode_ch3_H = "0" And mode_ch3_L = "0" Then ' tutti e due disabilitati
            function_java = function_java + "disable_mV_alarm_dose();"
            'java_script_minmax6.call_function_javascript_onload(Page, "disable_cl_alarm_dose()")
        Else
            function_java = function_java + "enable_mV_alarm_dose();"
            'java_script_minmax6.call_function_javascript_onload(Page, "enable_cl_alarm_dose()")
        End If



        If mode_ch4_H = "0" Then 'dis
            function_java = function_java + "disable_ntu_alarm_high();"
            'java_script_minmax4.call_function_javascript_onload(Page, "disable_cl_alarm_high()")
            ntu_alarm_high_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_ntu_alarm_high();"
            'java_script_minmax4.call_function_javascript_onload(Page, "enable_cl_alarm_high()")
            ntu_alarm_high_enable.Checked = True 'enabled
            'RadioButton2.Checked = False 'disabled
        End If
        If mode_ch4_L = "0" Then 'dis
            function_java = function_java + "disable_ntu_alarm_low();"
            'java_script_minmax5.call_function_javascript_onload(Page, "disable_cl_alarm_low()")
            ntu_alarm_low_disable.Checked = True 'disabled
        Else
            function_java = function_java + "enable_ntu_alarm_low();"
            'java_script_minmax5.call_function_javascript_onload(Page, "enable_cl_alarm_low()")
            ntu_alarm_low_enable.Checked = True 'enabled
        End If

        If mode_ch4_H = "0" And mode_ch4_L = "0" Then ' tutti e due disabilitati
            function_java = function_java + "disable_ntu_alarm_dose();"
            'java_script_minmax6.call_function_javascript_onload(Page, "disable_cl_alarm_dose()")
        Else
            function_java = function_java + "enable_ntu_alarm_dose();"
            'java_script_minmax6.call_function_javascript_onload(Page, "enable_cl_alarm_dose()")
        End If



        value_ch1_H = Mid(minmax_value(2), 1, 4)
        value_ch1_L = Mid(minmax_value(4), 1, 4)
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        tabld1_1.Text = label_canale_temp
        Label7.Text = out_range_traduzione + " " + label_canale_temp
        Literal5.Text = out_range_traduzione_low + " " + label_canale_temp
        temp_calc = Val(value_ch1_H) / fattore_divisione_temp 'on
        value_ph_alarm_high.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(value_ch1_L) / fattore_divisione_temp 'on
        value_ph_alarm_low.Text = Replace(temp_calc.ToString(), ",", ".")
        Literal4.Text = mim_max_h_traduzione + " - " + etichetta_setpoint
        Literal1.Text = mim_max_l_traduzione + " - " + etichetta_setpoint
        Literal9.Text = mode_traduzione
        set_variable_javascript(0, 0) = "max_ph_value"
        set_variable_javascript(0, 1) = full_scale_temp.ToString
        set_variable_javascript(1, 0) = "min_ph_value"
        set_variable_javascript(1, 1) = "0"
        set_variable_javascript(2, 0) = "max_fix_value_ph"
        set_variable_javascript(2, 1) = main_function.set_fullscale(full_scale_temp).ToString

        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        tabld1_2.Text = label_canale_temp
        value_ch2_H = Mid(minmax_value(8), 1, 4)
        value_ch2_L = Mid(minmax_value(10), 1, 4)
        Literal3.Text = out_range_traduzione + " " + label_canale_temp
        Literal6.Text = out_range_traduzione_low + " " + label_canale_temp
        temp_calc = Val(value_ch2_H) / fattore_divisione_temp 'on
        value_cl_alarm_high.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(value_ch2_L) / fattore_divisione_temp 'on
        value_cl_alarm_low.Text = Replace(temp_calc.ToString(), ",", ".")
        Literal7.Text = mim_max_h_traduzione + " - " + etichetta_setpoint
        Literal10.Text = mim_max_l_traduzione + " - " + etichetta_setpoint
        Literal8.Text = mode_traduzione

        set_variable_javascript(3, 0) = "max_cl_value"
        set_variable_javascript(3, 1) = full_scale_temp.ToString
        set_variable_javascript(4, 0) = "min_cl_value"
        set_variable_javascript(4, 1) = "0"
        set_variable_javascript(5, 0) = "max_fix_value_cl"
        set_variable_javascript(5, 1) = main_function.set_fullscale(full_scale_temp).ToString

        dose_stop_ch1 = Mid(minmax_value(5), 1, 1)
        dose_stop_ch2 = Mid(minmax_value(11), 1, 1)
        time_ch1 = Mid(minmax_value(6), 1, 2)
        time_ch2 = Mid(minmax_value(12), 1, 2)
        Literal2.Text = time_traduzione
        Literal13.Text = time_traduzione



        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(3), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        tabld1_3.Text = label_canale_temp
        value_ch3_H = Mid(minmax_value(14), 1, 4)
        value_ch3_L = Mid(minmax_value(16), 1, 4)
        Literal11.Text = out_range_traduzione + " " + label_canale_temp
        Literal16.Text = out_range_traduzione_low + " " + label_canale_temp
        temp_calc = Val(value_ch3_H) / fattore_divisione_temp 'on
        value_mV_alarm_high.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(value_ch3_L) / fattore_divisione_temp 'on
        value_mV_alarm_low.Text = Replace(temp_calc.ToString(), ",", ".")
        Literal15.Text = mim_max_h_traduzione + " - " + etichetta_setpoint
        Literal19.Text = mim_max_l_traduzione + " - " + etichetta_setpoint
        Literal20.Text = mode_traduzione

        set_variable_javascript(6, 0) = "max_mV_value"
        set_variable_javascript(6, 1) = full_scale_temp.ToString
        set_variable_javascript(7, 0) = "min_mV_value"
        set_variable_javascript(7, 1) = "0"
        set_variable_javascript(8, 0) = "max_fix_value_mV"
        set_variable_javascript(8, 1) = main_function.set_fullscale(full_scale_temp).ToString

        dose_stop_ch1 = Mid(minmax_value(5), 1, 1)
        dose_stop_ch2 = Mid(minmax_value(11), 1, 1)
        dose_stop_ch3 = Mid(minmax_value(17), 1, 1)
        dose_stop_ch4 = Mid(minmax_value(23), 1, 1)
        time_ch1 = Mid(minmax_value(6), 1, 2)
        time_ch2 = Mid(minmax_value(12), 1, 2)
        time_ch3 = Mid(minmax_value(18), 1, 2)
        time_ch4 = Mid(minmax_value(24), 1, 2)
        Literal2.Text = time_traduzione
        Literal13.Text = time_traduzione

        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(4), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        tabld1_4.Text = label_canale_temp
        value_ch4_H = Mid(minmax_value(20), 1, 4)
        value_ch4_L = Mid(minmax_value(22), 1, 4)
        Literal12.Text = out_range_traduzione + " " + label_canale_temp
        Literal21.Text = out_range_traduzione_low + " " + label_canale_temp
        temp_calc = Val(value_ch4_H) / fattore_divisione_temp 'on
        value_ntu_alarm_high.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(value_ch4_L) / fattore_divisione_temp 'on
        value_ntu_alarm_low.Text = Replace(temp_calc.ToString(), ",", ".")
        Literal18.Text = mim_max_h_traduzione + " - " + etichetta_setpoint
        Literal25.Text = mim_max_l_traduzione + " - " + etichetta_setpoint
        Literal26.Text = mode_traduzione

        set_variable_javascript(9, 0) = "max_ntu_value"
        set_variable_javascript(9, 1) = full_scale_temp.ToString
        set_variable_javascript(10, 0) = "min_ntu_value"
        set_variable_javascript(10, 1) = "0"
        set_variable_javascript(11, 0) = "max_fix_value_ntu"
        set_variable_javascript(11, 1) = "2"



        If dose_stop_ch1 = "0" Then ' dose
            'function_java = function_java + "disable_ph_alarm_dose();"
            'java_script_minmax6_1.call_function_javascript_onload(Page, "disable_ph_alarm_dose()")
            ph_alarm_mode_dose.Checked = True 'dose
        Else
            'function_java = function_java + "enable_ph_alarm_dose();"
            'java_script_minmax6_1.call_function_javascript_onload(Page, "enable_ph_alarm_dose()")
            ph_alarm_mode_stop.Checked = True 'stop
        End If

        If dose_stop_ch2 = "0" Then ' dose
            'function_java = function_java + "disable_cl_alarm_dose();"
            'java_script_minmax6_2.call_function_javascript_onload(Page, "disable_cl_alarm_dose()")
            cl_alarm_mode_dose.Checked = True 'dose

        Else
            'function_java = function_java + "enable_cl_alarm_dose();"
            'java_script_minmax6_2.call_function_javascript_onload(Page, "enable_cl_alarm_dose()")
            cl_alarm_mode_stop.Checked = True 'stop
        End If


        If dose_stop_ch3 = "0" Then ' dose
            'function_java = function_java + "disable_cl_alarm_dose();"
            'java_script_minmax6_2.call_function_javascript_onload(Page, "disable_cl_alarm_dose()")
            mV_alarm_mode_dose.Checked = True 'dose

        Else
            'function_java = function_java + "enable_cl_alarm_dose();"
            'java_script_minmax6_2.call_function_javascript_onload(Page, "enable_cl_alarm_dose()")
            mV_alarm_mode_stop.Checked = True 'stop
        End If


        If dose_stop_ch4 = "0" Then ' dose
            'function_java = function_java + "disable_cl_alarm_dose();"
            'java_script_minmax6_2.call_function_javascript_onload(Page, "disable_cl_alarm_dose()")
            ntu_alarm_mode_dose.Checked = True 'dose

        Else
            'function_java = function_java + "enable_cl_alarm_dose();"
            'java_script_minmax6_2.call_function_javascript_onload(Page, "enable_cl_alarm_dose()")
            ntu_alarm_mode_stop.Checked = True 'stop
        End If

        value_ph_alarm_stop.Text = Val(time_ch1).ToString
        value_cl_alarm_stop.Text = Val(time_ch2).ToString
        value_mV_alarm_stop.Text = Val(time_ch3).ToString
        value_ntu_alarm_stop.Text = Val(time_ch4).ToString

        java_script_minmax1.call_function_javascript_onload(Page, function_java)
        java_script_minmax2.set_url_setpoint(Page, set_variable_javascript, 11)

    End Sub
    Private Function MakeMinMaxString() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim calibrz_value() As String
        Dim full_scale_temp As Single

        Dim fattore_divisione_temp As Integer = 0

        Dim Risultato As String

        Dim app_mode_ch1_H As String
        Dim app_mode_ch1_L As String

        Dim app_mode_ch2_H As String
        Dim app_mode_ch2_L As String

        Dim app_mode_ch3_H As String
        Dim app_mode_ch3_L As String

        Dim app_mode_ch4_H As String
        Dim app_mode_ch4_L As String


        Dim app_value_ch1_H As String
        Dim app_value_ch1_L As String

        Dim app_value_ch2_H As String
        Dim app_value_ch2_L As String

        Dim app_value_ch3_H As String
        Dim app_value_ch3_L As String

        Dim app_value_ch4_H As String
        Dim app_value_ch4_L As String

        Dim app_dose_stop_ch1 As String
        Dim app_dose_stop_ch2 As String
        Dim app_dose_stop_ch3 As String
        Dim app_dose_stop_ch4 As String

        Dim app_time_ch1 As String
        Dim app_time_ch2 As String
        Dim app_time_ch3 As String
        Dim app_time_ch4 As String


        Dim fattore_ch1 As Integer
        Dim fattore_ch2 As Integer
        Dim fattore_ch3 As Integer
        Dim fattore_ch4 As Integer


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp)

        If ph_alarm_high_enable.Checked = True Then 'enable ch1 H
            app_mode_ch1_H = "1"
            app_value_ch1_H = Format(Val(value_ph_alarm_high.Text) * fattore_divisione_temp, "0000")

        End If
        If ph_alarm_high_disable.Checked = True Then 'disable ch1 H
            app_mode_ch1_H = "0"
            app_value_ch1_H = Format(full_scale_temp * fattore_divisione_temp, "0000")
        End If

        If ph_alarm_low_enable.Checked = True Then 'enable ch1 L
            app_mode_ch1_L = "1"
            app_value_ch1_L = Format(Val(value_ph_alarm_low.Text) * fattore_divisione_temp, "0000")
        End If
        If ph_alarm_low_disable.Checked = True Then 'disable ch1 L
            app_mode_ch1_L = "0"
            app_value_ch1_L = "0000"
        End If


        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp, full_scale_temp)


        If cl_alarm_high_enable.Checked = True Then 'enable ch2 H
            app_mode_ch2_H = "1"
            app_value_ch2_H = Format(Val(value_cl_alarm_high.Text) * fattore_divisione_temp, "0000")
        End If
        If cl_alarm_high_disable.Checked = True Then 'disable ch2 H
            app_mode_ch2_H = "0"
            'app_value_ch2_H = Format(Val(Main.Full_scale_ch2) * fattore_ch2, "0000")
            app_value_ch2_H = Format(full_scale_temp * fattore_divisione_temp, "0000")
        End If

        If cl_alarm_low_enable.Checked = True Then 'enable ch2 L
            app_mode_ch2_L = "1"
            app_value_ch2_L = Format(Val(value_cl_alarm_low.Text) * fattore_divisione_temp, "0000")
        End If
        If cl_alarm_low_disable.Checked = True Then 'disable ch2 L
            app_mode_ch2_L = "0"
            app_value_ch2_L = "0000"
        End If

        If ph_alarm_mode_dose.Checked = True Then
            app_dose_stop_ch1 = "0" 'dose
        Else
            app_dose_stop_ch1 = "1" 'stop
        End If

        If cl_alarm_mode_dose.Checked = True Then
            app_dose_stop_ch2 = "0" 'dose
        Else
            app_dose_stop_ch2 = "1" 'stop
        End If


        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(3), 1, 2), fattore_divisione_temp, full_scale_temp)


        If mV_alarm_high_enable.Checked = True Then 'enable ch2 H
            app_mode_ch3_H = "1"
            app_value_ch3_H = Format(Val(value_mV_alarm_high.Text) * fattore_divisione_temp, "0000")
        End If
        If mV_alarm_high_disable.Checked = True Then 'disable ch2 H
            app_mode_ch3_H = "0"
            'app_value_ch2_H = Format(Val(Main.Full_scale_ch2) * fattore_ch2, "0000")
            app_value_ch3_H = Format(full_scale_temp * fattore_divisione_temp, "0000")
        End If

        If mV_alarm_low_enable.Checked = True Then 'enable ch2 L
            app_mode_ch3_L = "1"
            app_value_ch3_L = Format(Val(value_mV_alarm_low.Text) * fattore_divisione_temp, "0000")
        End If
        If mV_alarm_low_disable.Checked = True Then 'disable ch2 L
            app_mode_ch3_L = "0"
            app_value_ch3_L = "0000"
        End If



        If mV_alarm_mode_dose.Checked = True Then
            app_dose_stop_ch3 = "0" 'dose
        Else
            app_dose_stop_ch3 = "1" 'stop
        End If



        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(4), 1, 2), fattore_divisione_temp, full_scale_temp)


        If ntu_alarm_high_enable.Checked = True Then 'enable ch2 H
            app_mode_ch4_H = "1"
            app_value_ch4_H = Format(Val(value_ntu_alarm_high.Text) * fattore_divisione_temp, "0000")
        End If
        If ntu_alarm_high_disable.Checked = True Then 'disable ch2 H
            app_mode_ch4_H = "0"
            'app_value_ch2_H = Format(Val(Main.Full_scale_ch2) * fattore_ch2, "0000")
            app_value_ch4_H = Format(full_scale_temp * fattore_divisione_temp, "0000")
        End If

        If ntu_alarm_low_enable.Checked = True Then 'enable ch2 L
            app_mode_ch4_L = "1"
            app_value_ch4_L = Format(Val(value_ntu_alarm_low.Text) * fattore_divisione_temp, "0000")
        End If
        If ntu_alarm_low_disable.Checked = True Then 'disable ch2 L
            app_mode_ch4_L = "0"
            app_value_ch4_L = "0000"
        End If



        If ntu_alarm_mode_dose.Checked = True Then
            app_dose_stop_ch4 = "0" 'dose
        Else
            app_dose_stop_ch4 = "1" 'stop
        End If



        app_time_ch1 = Format(Val(value_ph_alarm_stop.Text), "00")
        app_time_ch2 = Format(Val(value_cl_alarm_stop.Text), "00")
        app_time_ch3 = Format(Val(value_mV_alarm_stop.Text), "00")
        app_time_ch4 = Format(Val(value_ntu_alarm_stop.Text), "00")



        'Risultato = app_mode_ch1_H + app_value_ch1_H + app_mode_ch1_L + app_value_ch1_L + app_dose_stop_ch1 + app_time_ch1 + app_mode_ch2_H + app_value_ch2_H + app_mode_ch2_L + app_value_ch2_L + app_dose_stop_ch2 + app_time_ch2
        Risultato = app_mode_ch1_H + app_value_ch1_H + app_mode_ch1_L + app_value_ch1_L + app_dose_stop_ch1 + app_time_ch1 + app_mode_ch2_H + app_value_ch2_H + app_mode_ch2_L + app_value_ch2_L + app_dose_stop_ch2 + app_time_ch2 + app_mode_ch3_H + app_value_ch3_H + app_mode_ch3_L + app_value_ch3_L + app_dose_stop_ch3 + app_time_ch3 + app_mode_ch4_H + app_value_ch4_H + app_mode_ch4_L + app_value_ch4_L + app_dose_stop_ch4 + app_time_ch4


        Return id_485_impianto + "minmxw" + Risultato + "minmxwend" & Chr(13)

    End Function

    Protected Sub save_rangealarmld4_new_Click(sender As Object, e As EventArgs) Handles save_rangealarmld4_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeMinMaxString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=31" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class