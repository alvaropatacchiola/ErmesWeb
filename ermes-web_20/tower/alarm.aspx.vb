Public Class alarm
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub alarm_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
       
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_alarm_tower(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_alarm_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim new_version As Boolean = False
        Dim MTower_Type As String = ""

        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim set_variable_javascript(7, 1) As String
        Dim function_java As String = ""

        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim version_str As String
        Dim config_value() As String

        Dim unit_value() As String
        Dim alarm_value() As String

        Dim full_scale_temp As Integer = 0
        Dim label_canale_temp As String = ""
        Dim etichettasetpoint As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim personalizzazione_aquacare As Integer

        ' abilito pulsante modifica
        save_alarmtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_alarmtower_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)
        alarm_value = main_function.get_split_str(riga_strumento.value26)
        new_version = main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        config_value = main_function.get_split_str(riga_strumento.value4)

        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)
        If measure_unit = "uS" Then
            Literal1.Text = " uS "
            Literal6.Text = " uS "
        Else
            Literal1.Text = " ppm "
            Literal6.Text = " ppm "

        End If
        If InStr(version_str, "3.0.0") Or InStr(version_str, "3.0.1") Then

            If full_scale_temp = 30000 Then
                Literal1.Text = Literal1.Text + "0"
                Literal6.Text = Literal6.Text + "0"
            End If
            set_variable_javascript(0, 0) = "max_ch1"
            set_variable_javascript(0, 1) = "3000"

        Else
            set_variable_javascript(0, 0) = "max_ch1"
            set_variable_javascript(0, 1) = "9999"
        End If

        If Val(Mid(alarm_value(0), 3, 1)) Then        'Track Low Conductivity
            ch1_low_track.Checked = True
            function_java = function_java + "enable_ch1_low();"
            value_ch1_low.Text = Format(Val(Mid(alarm_value(0), 6, 4)), "0000")   'Track Low Conductivity Value
            'track_check(ASPxSpinEdit128, ASPxSpinEdit129)
        End If

        If Val(Mid(alarm_value(0), 4, 1)) Then        'Absolute Low Conductivity
            ch1_low_absolute.Checked = True
            function_java = function_java + "enable_ch1_low();"
            value_ch1_low.Text = Format(Val(Mid(alarm_value(0), 10, 4)), "0000")   'Absolute Low Conductivity Value
            'absolute_check(ASPxSpinEdit129, ASPxSpinEdit128)
        End If

        If Val(Mid(alarm_value(0), 5, 1)) Then        'Off Low Conductivity
            ch1_low_off.Checked = True
            function_java = function_java + "disable_ch1_low();"
            'off_check(ASPxSpinEdit129, ASPxSpinEdit128)
        End If




        If Val(Mid(alarm_value(0), 14, 1)) Then        'Track High Conductivity
            ch1_high_track.Checked = True
            value_ch1_high.Text = Format(Val(Mid(alarm_value(0), 17, 4)), "0000")   'Track High Conductivity Value
            function_java = function_java + "enable_ch1_high();"
        End If

        If Val(Mid(alarm_value(0), 15, 1)) Then        'Absolute High Conductivity
            ch1_high_absolute.Checked = True
            value_ch1_high.Text = Format(Val(Mid(alarm_value(0), 21, 4)), "0000")   'Absolute High Conductivity Value
            function_java = function_java + "enable_ch1_high();"
        End If

        If Val(Mid(alarm_value(0), 16, 1)) Then        'Off High Conductivity
            ch1_high_off.Checked = True
            function_java = function_java + "disable_ch1_high();"
        End If
        If (MTower_Type = "Cdxxx") Then ' canale 
            If Val(Mid(alarm_value(0), 25, 1)) Then        'Chemical Level Yes
                chemical_levels_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 26, 1)) Then        'Chemical Level No
                chemical_levels_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 27, 1)) Then        'No Flow Yes
                no_flow_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 28, 1)) Then        'No Flow No
                no_flow_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 29, 1)) Then        'No Flow Out Alarm Enable 
                out_alarm_enable.Checked = True
            End If

            If Val(Mid(alarm_value(0), 30, 1)) Then        'No Flow Out Alarm Disable
                out_alarm_disable.Checked = True
            End If
        End If
        If (MTower_Type = "Cd_pH") Or (MTower_Type = "Cd_rH") Or (MTower_Type = "Cd_Cl") Then
            If Val(Mid(alarm_value(0), 47, 1)) Then        'Chemical Level Yes
                chemical_levels_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 48, 1)) Then        'Chemical Level No
                chemical_levels_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 49, 1)) Then        'No Flow Yes
                no_flow_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 50, 1)) Then        'No Flow No
                no_flow_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 51, 1)) Then        'No Flow Out Alarm Enable 
                out_alarm_enable.Checked = True
            End If

            If Val(Mid(alarm_value(0), 52, 1)) Then        'No Flow Out Alarm Disable
                out_alarm_disable.Checked = True
            End If

        End If
        If (MTower_Type = "Cd_pH_Cl") Or (MTower_Type = "Cd_trc_Cl") Or (MTower_Type = "Cd_trc_rH") Then
            If Val(Mid(alarm_value(0), 69, 1)) Then        'Chemical Level Yes
                chemical_levels_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 70, 1)) Then        'Chemical Level No
                chemical_levels_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 71, 1)) Then        'No Flow Yes
                no_flow_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 72, 1)) Then        'No Flow No
                no_flow_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 73, 1)) Then        'No Flow Out Alarm Enable 
                out_alarm_enable.Checked = True
            End If

            If Val(Mid(alarm_value(0), 74, 1)) Then        'No Flow Out Alarm Disable
                out_alarm_disable.Checked = True
            End If

        End If
        If new_version = True Then          ' per la versione uguale o superiore alla 3.0.4
            set_variable_javascript(7, 0) = "new_version"
            set_variable_javascript(7, 1) = "1"

            enable_no_nc_chemical_levels.Visible = True
            enable_water_meter_input.Visible = True
            enable_concentration_factor.Visible = True
            enable_water_meter_bleed.Visible = True
            If Val(Mid(alarm_value(0), 53, 1)) Then        'Chemical Levels NO
                chemical_levels_out_no.Checked = True
            End If

            If Val(Mid(alarm_value(0), 54, 1)) Then        'Chemical Levels NC
                chemical_levels_out_nc.Checked = True
            End If

            If Val(Mid(alarm_value(0), 55, 1)) Then        'WMI Stop
                water_meter_input_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 56, 1)) Then        'WMI No
                water_meter_input_no.Checked = True
            End If

            value_water_meter_input_hr.Text = Format(Val(Mid(alarm_value(0), 57, 2)), "00")  'WMI Minute
            value_water_meter_input_min.Text = Format(Val(Mid(alarm_value(0), 59, 2)), "00")  'WMI Second

            If Val(Mid(alarm_value(0), 61, 1)) Then        'WMB Stop
                water_meter_bleed_stop.Checked = True
            End If

            If Val(Mid(alarm_value(0), 62, 1)) Then        'WMB Stop
                water_meter_bleed_no.Checked = True
            End If

            value_water_meter_bleed_hr.Text = Format(Val(Mid(alarm_value(0), 63, 2)), "00")  'WMB Minute
            value_water_meter_bleed_min.Text = Format(Val(Mid(alarm_value(0), 65, 2)), "00")  'WMB Second

            If Val(Mid(alarm_value(0), 67, 1)) Then        'CF On
                concentration_factor_on.Checked = True
            End If

            If Val(Mid(alarm_value(0), 68, 1)) Then        'CF Off
                concentration_factor_off.Checked = True
            End If

            value_concentration_factor_ratio.Text = Replace((Val(Mid(alarm_value(0), 69, 2)) / 10).ToString, ",", ".") 'Ratio WMI/WMB
            value_concentration_factor_tolerance.Text = Format(Val(Mid(alarm_value(0), 71, 2)), "00")  'Tolerance
            value_concentration_factor_Delay.Text = Format(Val(Mid(alarm_value(0), 73, 2)), "00")  'Delay
        Else
            set_variable_javascript(7, 0) = "new_version"
            set_variable_javascript(7, 1) = "0"
            enable_no_nc_chemical_levels.Visible = False
            enable_water_meter_input.Visible = False
            enable_concentration_factor.Visible = False
            enable_water_meter_bleed.Visible = False

        End If
        If (MTower_Type = "Cdxxx") Then ' canale 
            ch2_enable.Visible = False
            ch3_enable.Visible = False
            set_variable_javascript(1, 0) = "max_ch2"
            set_variable_javascript(1, 1) = "0"
            set_variable_javascript(2, 0) = "min_ch2"
            set_variable_javascript(2, 1) = "0"
            set_variable_javascript(3, 0) = "ch2_fix"
            set_variable_javascript(3, 1) = "0"
            set_variable_javascript(4, 0) = "max_ch3"
            set_variable_javascript(4, 1) = "0"
            set_variable_javascript(5, 0) = "min_ch3"
            set_variable_javascript(5, 1) = "0"
            set_variable_javascript(6, 0) = "ch3_fix"
            set_variable_javascript(6, 1) = "0"
        End If
        If (MTower_Type = "Cd_pH") Or (MTower_Type = "Cd_rH") Or (MTower_Type = "Cd_Cl") Then
            ch2_enable.Visible = True
            ch3_enable.Visible = False

            main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
                                  , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
            set_variable_javascript(1, 0) = "max_ch2"
            set_variable_javascript(1, 1) = full_scale_temp.ToString
            set_variable_javascript(2, 0) = "min_ch2"
            set_variable_javascript(2, 1) = "0"
            set_variable_javascript(3, 0) = "ch2_fix"
            set_variable_javascript(3, 1) = "0"
            set_variable_javascript(4, 0) = "max_ch3"
            set_variable_javascript(4, 1) = "0"
            set_variable_javascript(5, 0) = "min_ch3"
            set_variable_javascript(5, 1) = "0"
            set_variable_javascript(6, 0) = "ch3_fix"
            set_variable_javascript(6, 1) = "0"

            Literal3.Text = Literal3.Text + " " + label_canale_temp
            Literal8.Text = etichettasetpoint
            Literal9.Text = Literal9.Text + " " + label_canale_temp
            Literal13.Text = etichettasetpoint

            If Val(Mid(alarm_value(0), 25, 1)) Then        'Track Low 
                ch2_low_track.Checked = True
                function_java = function_java + "enable_ch2_low();"
                value_ch2_low.Text = Replace((Val(Mid(alarm_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".")  'Track Low Conductivity Value
            End If

            If Val(Mid(alarm_value(0), 26, 1)) Then        'Absolute Low 
                ch2_low_absolute.Checked = True
                function_java = function_java + "enable_ch2_low();"
                value_ch2_low.Text = Replace((Val(Mid(alarm_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".")  'Absolute Low Conductivity Value
            End If

            If Val(Mid(alarm_value(0), 27, 1)) Then        'Off Low 
                ch2_low_off.Checked = True
                function_java = function_java + "disable_ch2_low();"
                'off_check(ASPxSpinEdit129, ASPxSpinEdit128)
            End If

            'ld.Alarm.NumericUpDown1.Value = Val(Mid(DataAlarm(0), 6, 4)) / 1000    'Track Low  Value
            'ld.Alarm.NumericUpDown2.Value = Val(Mid(DataAlarm(0), 10, 4)) / 1000   'Absolute Low  Value

            If Val(Mid(alarm_value(0), 36, 1)) Then        'Track High 
                ch2_high_track.Checked = True
                value_ch2_high.Text = Replace((Val(Mid(alarm_value(0), 39, 4)) / fattore_divisione_temp).ToString, ",", ".")  'Track High Conductivity Value
                function_java = function_java + "enable_ch2_high();"
            End If

            If Val(Mid(alarm_value(0), 37, 1)) Then        'Absolute High 
                ch2_high_absolute.Checked = True
                value_ch2_high.Text = Replace((Val(Mid(alarm_value(0), 43, 4)) / fattore_divisione_temp).ToString, ",", ".")  'Absolute High Conductivity Value
                function_java = function_java + "enable_ch2_high();"
            End If

            If Val(Mid(alarm_value(0), 38, 1)) Then        'Off High 
                ch2_high_off.Checked = True
                function_java = function_java + "disable_ch2_high();"
            End If

        End If
        If (MTower_Type = "Cd_pH_Cl") Or (MTower_Type = "Cd_trc_Cl") Or (MTower_Type = "Cd_trc_rH") Then
            ch2_enable.Visible = True
            ch3_enable.Visible = True
            main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
                                              , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
            set_variable_javascript(1, 0) = "max_ch2"
            set_variable_javascript(1, 1) = full_scale_temp.ToString
            set_variable_javascript(2, 0) = "min_ch2"
            set_variable_javascript(2, 1) = "0"
            set_variable_javascript(3, 0) = "ch2_fix"
            set_variable_javascript(3, 1) = main_function.set_fullscale(full_scale_temp).ToString
            Literal3.Text = Literal3.Text + " " + label_canale_temp
            Literal8.Text = etichettasetpoint
            Literal9.Text = Literal9.Text + " " + label_canale_temp
            Literal13.Text = etichettasetpoint

            If Val(Mid(alarm_value(0), 25, 1)) Then        'Track Low 
                ch2_low_track.Checked = True
                function_java = function_java + "enable_ch2_low();"
                value_ch2_low.Text = Replace((Val(Mid(alarm_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Track Low Conductivity Value
            End If

            If Val(Mid(alarm_value(0), 26, 1)) Then        'Absolute Low 
                ch2_low_absolute.Checked = True
                function_java = function_java + "enable_ch2_low();"
                value_ch2_low.Text = Replace((Val(Mid(alarm_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Absolute Low Conductivity Value
            End If

            If Val(Mid(alarm_value(0), 27, 1)) Then        'Off Low 
                ch2_low_off.Checked = True
                function_java = function_java + "disable_ch2_low();"
                'off_check(ASPxSpinEdit129, ASPxSpinEdit128)
            End If

            'ld.Alarm.NumericUpDown1.Value = Val(Mid(DataAlarm(0), 6, 4)) / 1000    'Track Low  Value
            'ld.Alarm.NumericUpDown2.Value = Val(Mid(DataAlarm(0), 10, 4)) / 1000   'Absolute Low  Value

            If Val(Mid(alarm_value(0), 36, 1)) Then        'Track High 
                ch2_high_track.Checked = True
                value_ch2_high.Text = Replace((Val(Mid(alarm_value(0), 39, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Track High Conductivity Value
                function_java = function_java + "enable_ch2_high();"
            End If

            If Val(Mid(alarm_value(0), 37, 1)) Then        'Absolute High 
                ch2_high_absolute.Checked = True
                value_ch2_high.Text = Replace((Val(Mid(alarm_value(0), 43, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Absolute High Conductivity Value
                function_java = function_java + "enable_ch2_high();"
            End If

            If Val(Mid(alarm_value(0), 38, 1)) Then        'Off High 
                ch2_high_off.Checked = True
                function_java = function_java + "disable_ch2_high();"
            End If

            main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, ,
                                                          , fattore_divisione_temp, , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
            set_variable_javascript(4, 0) = "max_ch3"
            set_variable_javascript(4, 1) = full_scale_temp.ToString
            set_variable_javascript(5, 0) = "min_ch3"
            set_variable_javascript(5, 1) = "0"
            set_variable_javascript(6, 0) = "ch3_fix"
            set_variable_javascript(6, 1) = main_function.set_fullscale(full_scale_temp).ToString
            Literal4.Text = Literal4.Text + " " + label_canale_temp
            Literal11.Text = etichettasetpoint
            Literal12.Text = Literal12.Text + " " + label_canale_temp
            Literal17.Text = etichettasetpoint
            If Val(Mid(alarm_value(0), 47, 1)) Then        'Track Low 
                ch3_low_track.Checked = True
                function_java = function_java + "enable_ch3_low();"
                value_ch3_low.Text = Replace((Val(Mid(alarm_value(0), 50, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Track Low Conductivity Value
            End If

            If Val(Mid(alarm_value(0), 48, 1)) Then        'Absolute Low 
                ch3_low_absolute.Checked = True
                function_java = function_java + "enable_ch3_low();"
                value_ch3_low.Text = Replace((Val(Mid(alarm_value(0), 54, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Absolute Low Conductivity Value
            End If

            If Val(Mid(alarm_value(0), 49, 1)) Then        'Off Low 
                ch3_low_off.Checked = True
                function_java = function_java + "disable_ch3_low();"
                'off_check(ASPxSpinEdit129, ASPxSpinEdit128)
            End If

            'ld.Alarm.NumericUpDown1.Value = Val(Mid(DataAlarm(0), 6, 4)) / 1000    'Track Low  Value
            'ld.Alarm.NumericUpDown2.Value = Val(Mid(DataAlarm(0), 10, 4)) / 1000   'Absolute Low  Value

            If Val(Mid(alarm_value(0), 58, 1)) Then        'Track High 
                ch3_high_track.Checked = True
                value_ch3_high.Text = Replace((Val(Mid(alarm_value(0), 61, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Track High Conductivity Value
                function_java = function_java + "enable_ch3_high();"
            End If

            If Val(Mid(alarm_value(0), 59, 1)) Then        'Absolute High 
                ch3_high_absolute.Checked = True
                value_ch3_high.Text = Replace((Val(Mid(alarm_value(0), 65, 4)) / fattore_divisione_temp).ToString, ",", ".")   'Absolute High Conductivity Value
                function_java = function_java + "enable_ch3_high();"
            End If

            If Val(Mid(alarm_value(0), 60, 1)) Then        'Off High 
                ch3_high_off.Checked = True
                function_java = function_java + "disable_ch3_high();"
            End If
        End If
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 7)
        java_script_function.call_function_javascript_onload(Page, function_java)
    End Sub

    Private Function MakeAlarmString() As String

        Dim Risultato As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim config_value() As String
        Dim version_str As String = ""
        Dim new_version As Boolean = False
        Dim MTower_Type As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim personalizzazione_aquacare As Integer
        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next



        new_version = main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        config_value = main_function.get_split_str(riga_strumento.value4)

        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)


        If ch1_low_track.Checked Then                'low conductivity track
            Risultato = "1"
        Else
            Risultato = "0"
        End If

        If ch1_low_absolute.Checked Then                'low conductivity absolute
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If ch1_low_off.Checked Then                'low conductivity off
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        Risultato = Risultato + Format(Val(value_ch1_low.Text), "0000") + Format(Val(value_ch1_low.Text), "0000")

        If ch1_high_track.Checked Then                'high conductivity track
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If ch1_high_absolute.Checked Then                'high conductivity absolute
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If ch1_high_off.Checked Then                'high conductivity off
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        Risultato = Risultato + Format(Val(value_ch1_high.Text), "0000") + Format(Val(value_ch1_high.Text), "0000")

        '--------------------------------------------------------------------------------------------------------------------------------------------------------
        If MTower_Type = "Cdxxx" Then
            If ch2_low_track.Checked Then                'low ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_low_absolute.Checked Then                'low ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_low_off.Checked Then                'low ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch2_low.Text), "0000") + Format(Val(value_ch2_low.Text), "0000")
            If ch2_high_track.Checked Then                'high ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_high_absolute.Checked Then                'high ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_high_off.Checked Then                'high ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch2_high.Text), "0000") + Format(Val(value_ch2_high.Text), "0000")
            If chemical_levels_stop.Checked Then            'Chemical levels stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If chemical_levels_no.Checked Then            'Chemical levels no
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If no_flow_stop.Checked Then           'No flow stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If no_flow_no.Checked Then            ' No flow no
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If out_alarm_enable.Checked Then           ' Out alarm enable
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If out_alarm_disable.Checked Then           ' out alarm disable
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If
        End If
        If MTower_Type = "Cd_pH" Or MTower_Type = "Cd_rH" Or MTower_Type = "Cd_Cl" Then
            main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp)

            If ch2_low_track.Checked Then                'low ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_low_absolute.Checked Then                'low ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_low_off.Checked Then                'low ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch2_low.Text) * fattore_divisione_temp, "0000") + Format(Val(value_ch2_low.Text) * fattore_divisione_temp, "0000")

            If ch2_high_track.Checked Then                'high ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_high_absolute.Checked Then                'high ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_high_off.Checked Then                'high ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch2_high.Text) * fattore_divisione_temp, "0000") + Format(Val(value_ch2_high.Text) * fattore_divisione_temp, "0000")

            If chemical_levels_stop.Checked Then            'Chemical levels stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If chemical_levels_no.Checked Then            'Chemical levels no
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If no_flow_stop.Checked Then           'No flow stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If no_flow_no.Checked Then            ' No flow no
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If out_alarm_enable.Checked Then           ' Out alarm enable
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If out_alarm_disable.Checked Then           ' out alarm disable
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------


        '--------------------------------------------------------------------------------------------------------------------------------------------------------
        If MTower_Type = "Cd_pH_Cl" Or MTower_Type = "Cd_pH_rH" Or MTower_Type = "Cd_trc_Cl" Or MTower_Type = "Cd_trc_rH" Then
            main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp)

            If ch2_low_track.Checked Then                'low ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_low_absolute.Checked Then                'low ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_low_off.Checked Then                'low ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch2_low.Text) * fattore_divisione_temp, "0000") + Format(Val(value_ch2_low.Text) * fattore_divisione_temp, "0000")

            If ch2_high_track.Checked Then                'high ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_high_absolute.Checked Then                'high ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch2_high_off.Checked Then                'high ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch2_high.Text) * fattore_divisione_temp, "0000") + Format(Val(value_ch2_high.Text) * fattore_divisione_temp, "0000")

            main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , fattore_divisione_temp)

            If ch3_low_track.Checked Then                'low ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch3_low_absolute.Checked Then                'low ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch3_low_off.Checked Then                'low ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_ch3_low.Text) * fattore_divisione_temp, "0000") + Format(Val(value_ch3_low.Text) * fattore_divisione_temp, "0000")

            If ch3_high_track.Checked Then                'high ch2 track
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch3_high_absolute.Checked Then                'high ch2 absolute
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If ch3_high_off.Checked Then                'high ch2 off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If
            Risultato = Risultato + Format(Val(value_ch3_high.Text) * fattore_divisione_temp, "0000") + Format(Val(value_ch3_high.Text) * fattore_divisione_temp, "0000")

            If chemical_levels_stop.Checked Then            'Chemical levels stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If chemical_levels_no.Checked Then            'Chemical levels no
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If no_flow_stop.Checked Then           'No flow stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If no_flow_no.Checked Then            ' No flow no
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If out_alarm_enable.Checked Then           ' Out alarm enable
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If out_alarm_disable.Checked Then           ' out alarm disable
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

        End If


        If new_version = True Then

            If chemical_levels_out_no.Checked Then           ' chemical levels NO
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If chemical_levels_out_nc.Checked Then           '  chemical levels NC
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If water_meter_input_stop.Checked Then           '  WMI Stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If water_meter_input_no.Checked Then           '  WMI No
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_water_meter_input_hr.Text), "00") + Format(Val(value_water_meter_input_min.Text), "00") ' WMI minute + second

            If water_meter_bleed_stop.Checked Then           '  WMB Stop
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If water_meter_bleed_no.Checked Then           '  WMB No
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_water_meter_bleed_hr.Text), "00") + Format(Val(value_water_meter_bleed_min.Text), "00") ' WMB minute + second


            If concentration_factor_on.Checked Then           '  CF On
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            If concentration_factor_off.Checked Then           '  CF Off
                Risultato = Risultato + "1"
            Else
                Risultato = Risultato + "0"
            End If

            Risultato = Risultato + Format(Val(value_concentration_factor_ratio.Text) * 10, "00")  ' Ratio WMI/WMB
            Risultato = Risultato + Format(Val(value_concentration_factor_tolerance.Text), "00")       ' Tolerance
            Risultato = Risultato + Format(Val(value_concentration_factor_Delay.Text), "00")       ' Delay

        End If

        Return id_485_impianto + "alarmwMT" + Risultato + "alarmwend" & Chr(13)

    End Function

    Protected Sub save_alarmtower_new_Click(sender As Object, e As EventArgs) Handles save_alarmtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeAlarmString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class