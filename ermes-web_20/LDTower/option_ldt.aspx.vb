Public Class option_ldt
        Inherits lingua

        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""
        Private Shared canale As String = ""
        Private Sub _option1_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
            Dim result As String = ""
            result = Page.Request("result")
            If Not IsPostBack Or result = "1" Then
                nome_impianto = Page.Request("nome_impianto")
                nome_impianto = Replace(nome_impianto, "$", " ")
                codice_impianto = Page.Request("codice")
                id_485_impianto = Page.Request("id_485")
                statistica = Page.Request("statistica")
            posiziona_option_ldtower(nome_impianto, codice_impianto, id_485_impianto, canale)
            End If
        End Sub
    Public Sub posiziona_option_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim new_version As Boolean = False
        Dim MTower_Type As String = ""

        Dim java_script_variable As java_script = New java_script

        Dim set_variable_javascript(9, 1) As String

        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim version_str As String
        Dim config_value() As String

        Dim unit_value() As String
        Dim option_value() As String

        Dim full_scale_temp As Integer = 0
        Dim label_canale_temp As String = ""
        Dim etichettasetpoint As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim personalizzazione_aquacare As Integer


        ' abilito pulsante modifica
        save_option_ldtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_option_ldtower_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)
        option_value = main_function.get_split_str(riga_strumento.value7)
        new_version = main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        config_value = main_function.get_split_str(riga_strumento.value4)

        MTower_Type = main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str)

        If measure_unit = "uS" Then
            Literal12.Text = Literal12.Text + " uS "
            Literal13.Text = Literal13.Text + " uS "
        Else
            Literal12.Text = Literal12.Text + " ppm "
            Literal13.Text = Literal13.Text + " ppm "

        End If
        ' If InStr(version_str, "5.0.5") Then

        If full_scale_temp = 5000 Then
                Literal12.Text = Literal12.Text + "0"
                Literal13.Text = Literal13.Text + "0"
            End If
            set_variable_javascript(0, 0) = "max_ch1"
            set_variable_javascript(0, 1) = "500"
        'End If



        If international_unit = "IS" Then
            Literal10.Text = Literal10.Text + " °C"
            Literal11.Text = Literal11.Text + " °C"
            set_variable_javascript(1, 0) = "max_temperature"
            set_variable_javascript(1, 1) = "200"
        Else
            Literal10.Text = Literal10.Text + " °F"
            Literal11.Text = Literal11.Text + " °F"
            set_variable_javascript(1, 0) = "max_temperature"
            set_variable_javascript(1, 1) = "392"
        End If

        value_option_tau.Text = Format(Val(Mid(option_value(0), 3, 2)), "00")          'Tau
        value_option_coefficiente_temperatura.Text = Replace(((Val(Mid(option_value(0), 5, 2))) / 10).ToString, ",", ".")   'Coeff Temp
        value_option_startup_delay.Text = Format(Val(Mid(option_value(0), 7, 2)), "00")           'Startup Delay



        If Val(Mid(option_value(0), 9, 1)) Then
            value_option_flow.SelectedIndex = 0
        End If
        If Val(Mid(option_value(0), 10, 1)) Then
            value_option_flow.SelectedIndex = 1
        End If
        If Val(Mid(option_value(0), 11, 1)) Then
            value_option_flow.SelectedIndex = 2
        End If

        If Val(Mid(option_value(0), 12, 1)) Then
            value_ma_out.SelectedIndex = 0 '0/20
        End If
        If Val(Mid(option_value(0), 13, 1)) Then
            value_ma_out.SelectedIndex = 1 '4/20
        End If

        value_option_ch1_ma_h.Text = Format(Val(Mid(option_value(0), 14, 4)), "0000") ' Conductivity mA High
        value_option_ch1_ma_l.Text = Format(Val(Mid(option_value(0), 18, 4)), "0000") ' Conductivity mA Low

        value_option_temperature_ma_h.Text = Format(Val(Mid(option_value(0), 22, 3)), "000") ' Temperature mA High
        value_option_temperature_ma_l.Text = Format(Val(Mid(option_value(0), 25, 3)), "000") ' Temperature mA Low



        If Val(Mid(option_value(0), 28, 1)) Then
            option_alarm_out_no.Checked = True
        Else
            option_alarm_out_no.Checked = False
        End If

        If Val(Mid(option_value(0), 29, 1)) Then
            option_alarm_out_nc.Checked = True
        Else
            option_alarm_out_nc.Checked = False
        End If


        If Val(Mid(option_value(0), 30, 1)) Then
            value_option_inhib_wm.SelectedIndex = 0
        End If
        If Val(Mid(option_value(0), 31, 1)) Then
            value_option_inhib_wm.SelectedIndex = 1
        End If
        If Val(Mid(option_value(0), 32, 1)) Then
            value_option_inhib_wm.SelectedIndex = 2
        End If

        If Val(Mid(option_value(0), 33, 1)) Then
            option_enable_ma_out.Checked = True
        Else
            option_enable_ma_out.Checked = False
        End If

        If Val(Mid(option_value(0), 34, 1)) Then
            option_disable_ma_out.Checked = True
        Else
            option_disable_ma_out.Checked = False
        End If


        'If (MTower_Type = "Cdxxx") Then
        '    ch2_enable.Visible = False
        '    ch3_enable.Visible = False
        '    set_variable_javascript(2, 0) = "max_ch2"
        '    set_variable_javascript(2, 1) = "0"
        '    set_variable_javascript(3, 0) = "min_ch2"
        '    set_variable_javascript(3, 1) = "0"
        '    set_variable_javascript(4, 0) = "ch2_fix"
        '    set_variable_javascript(4, 1) = "0"
        '    set_variable_javascript(5, 0) = "max_ch3"
        '    set_variable_javascript(5, 1) = "0"
        '    set_variable_javascript(6, 0) = "min_ch3"
        '    set_variable_javascript(6, 1) = "0"
        '    set_variable_javascript(7, 0) = "ch3_fix"
        '    set_variable_javascript(7, 1) = "0"
        '    set_variable_javascript(8, 0) = "ch2_en"
        '    set_variable_javascript(8, 1) = "0"
        '    set_variable_javascript(9, 0) = "ch3_en"
        '    set_variable_javascript(9, 1) = "0"
        '    value_option_Number_week.Text = Format(Val(Mid(option_value(0), 28, 2)), "0") ' Number Week
        'End If
        'If (MTower_Type = "Cd_pH") Then
        '    ch2_enable.Visible = True
        '    ch3_enable.Visible = False
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
        '                                      , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(2, 0) = "max_ch2"
        '    set_variable_javascript(2, 1) = full_scale_temp.ToString
        '    set_variable_javascript(3, 0) = "min_ch2"
        '    set_variable_javascript(3, 1) = "0"
        '    set_variable_javascript(4, 0) = "ch2_fix"
        '    set_variable_javascript(4, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal14.Text = label_canale_temp + " " + Literal14.Text + " " + etichettasetpoint
        '    Literal15.Text = label_canale_temp + " " + Literal15.Text + " " + etichettasetpoint
        '    value_option_ch2_ma_h.Text = Replace((Val(Mid(option_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch2_ma_l.Text = Replace((Val(Mid(option_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low
        '    set_variable_javascript(5, 0) = "max_ch3"
        '    set_variable_javascript(5, 1) = "0"
        '    set_variable_javascript(6, 0) = "min_ch3"
        '    set_variable_javascript(6, 1) = "0"
        '    set_variable_javascript(7, 0) = "ch3_fix"
        '    set_variable_javascript(7, 1) = "0"
        '    set_variable_javascript(8, 0) = "ch2_en"
        '    set_variable_javascript(8, 1) = "1"
        '    set_variable_javascript(9, 0) = "ch3_en"
        '    set_variable_javascript(9, 1) = "0"
        '    value_option_Number_week.Text = Format(Val(Mid(option_value(0), 36, 2)), "0") ' Number Week
        'End If
        'If (MTower_Type = "Cd_rH") Then
        '    ch2_enable.Visible = True
        '    ch3_enable.Visible = False
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
        '                                      , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(2, 0) = "max_ch2"
        '    set_variable_javascript(2, 1) = full_scale_temp.ToString
        '    set_variable_javascript(3, 0) = "min_ch2"
        '    set_variable_javascript(3, 1) = "0"
        '    set_variable_javascript(4, 0) = "ch2_fix"
        '    set_variable_javascript(4, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal14.Text = label_canale_temp + " " + Literal14.Text + " " + etichettasetpoint
        '    Literal15.Text = label_canale_temp + " " + Literal15.Text + " " + etichettasetpoint
        '    value_option_ch2_ma_h.Text = Replace((Val(Mid(option_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch2_ma_l.Text = Replace((Val(Mid(option_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low
        '    set_variable_javascript(5, 0) = "max_ch3"
        '    set_variable_javascript(5, 1) = "0"
        '    set_variable_javascript(6, 0) = "min_ch3"
        '    set_variable_javascript(6, 1) = "0"
        '    set_variable_javascript(7, 0) = "ch3_fix"
        '    set_variable_javascript(7, 1) = "0"
        '    set_variable_javascript(8, 0) = "ch2_en"
        '    set_variable_javascript(8, 1) = "1"
        '    set_variable_javascript(9, 0) = "ch3_en"
        '    set_variable_javascript(9, 1) = "0"
        '    value_option_Number_week.Text = Format(Val(Mid(option_value(0), 36, 2)), "0") ' Number Week
        'End If
        'If (MTower_Type = "Cd_Cl") Then
        '    ch2_enable.Visible = True
        '    ch3_enable.Visible = False
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
        '                                      , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(2, 0) = "max_ch2"
        '    set_variable_javascript(2, 1) = full_scale_temp.ToString
        '    set_variable_javascript(3, 0) = "min_ch2"
        '    set_variable_javascript(3, 1) = "0"
        '    set_variable_javascript(4, 0) = "ch2_fix"
        '    set_variable_javascript(4, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal14.Text = label_canale_temp + " " + Literal14.Text + " " + etichettasetpoint
        '    Literal15.Text = label_canale_temp + " " + Literal15.Text + " " + etichettasetpoint
        '    value_option_ch2_ma_h.Text = Replace((Val(Mid(option_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch2_ma_l.Text = Replace((Val(Mid(option_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low
        '    set_variable_javascript(5, 0) = "max_ch3"
        '    set_variable_javascript(5, 1) = "0"
        '    set_variable_javascript(6, 0) = "min_ch3"
        '    set_variable_javascript(6, 1) = "0"
        '    set_variable_javascript(7, 0) = "ch3_fix"
        '    set_variable_javascript(7, 1) = "0"
        '    set_variable_javascript(8, 0) = "ch2_en"
        '    set_variable_javascript(8, 1) = "1"
        '    set_variable_javascript(9, 0) = "ch3_en"
        '    set_variable_javascript(9, 1) = "0"
        '    value_option_Number_week.Text = Format(Val(Mid(option_value(0), 36, 2)), "0") ' Number Week
        'End If
        'If (MTower_Type = "Cd_pH_Cl") Then
        '    ch2_enable.Visible = True
        '    ch3_enable.Visible = True
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
        '                                      , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(2, 0) = "max_ch2"
        '    set_variable_javascript(2, 1) = full_scale_temp.ToString
        '    set_variable_javascript(3, 0) = "min_ch2"
        '    set_variable_javascript(3, 1) = "0"
        '    set_variable_javascript(4, 0) = "ch2_fix"
        '    set_variable_javascript(4, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal14.Text = label_canale_temp + " " + Literal14.Text + " " + etichettasetpoint
        '    Literal15.Text = label_canale_temp + " " + Literal15.Text + " " + etichettasetpoint
        '    value_option_ch2_ma_h.Text = Replace((Val(Mid(option_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch2_ma_l.Text = Replace((Val(Mid(option_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low

        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , _
        '                                                  , fattore_divisione_temp, , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(5, 0) = "max_ch3"
        '    set_variable_javascript(5, 1) = full_scale_temp.ToString
        '    set_variable_javascript(6, 0) = "min_ch3"
        '    set_variable_javascript(6, 1) = "0"
        '    set_variable_javascript(7, 0) = "ch3_fix"
        '    set_variable_javascript(7, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal16.Text = label_canale_temp + " " + Literal16.Text + " " + etichettasetpoint
        '    Literal17.Text = label_canale_temp + " " + Literal17.Text + " " + etichettasetpoint
        '    value_option_ch3_ma_h.Text = Replace((Val(Mid(option_value(0), 36, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch3_ma_l.Text = Replace((Val(Mid(option_value(0), 40, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low
        '    set_variable_javascript(8, 0) = "ch2_en"
        '    set_variable_javascript(8, 1) = "1"
        '    set_variable_javascript(9, 0) = "ch3_en"
        '    set_variable_javascript(9, 1) = "1"
        '    value_option_Number_week.Text = Format(Val(Mid(option_value(0), 44, 2)), "0") ' Number Week
        'End If
        'If (MTower_Type = "Cd_pH_rH") Then
        '    ch2_enable.Visible = True
        '    ch3_enable.Visible = True
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
        '                                      , , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(2, 0) = "max_ch2"
        '    set_variable_javascript(2, 1) = full_scale_temp.ToString
        '    set_variable_javascript(3, 0) = "min_ch2"
        '    set_variable_javascript(3, 1) = "0"
        '    set_variable_javascript(4, 0) = "ch2_fix"
        '    set_variable_javascript(4, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal14.Text = label_canale_temp + " " + Literal14.Text + " " + etichettasetpoint
        '    Literal15.Text = label_canale_temp + " " + Literal15.Text + " " + etichettasetpoint
        '    value_option_ch2_ma_h.Text = Replace((Val(Mid(option_value(0), 28, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch2_ma_l.Text = Replace((Val(Mid(option_value(0), 32, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low

        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , _
        '                                                  , fattore_divisione_temp, , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        '    set_variable_javascript(5, 0) = "max_ch3"
        '    set_variable_javascript(5, 1) = full_scale_temp.ToString
        '    set_variable_javascript(6, 0) = "min_ch3"
        '    set_variable_javascript(6, 1) = "0"
        '    set_variable_javascript(7, 0) = "ch3_fix"
        '    set_variable_javascript(7, 1) = main_function.set_fullscale(full_scale_temp).ToString
        '    Literal16.Text = label_canale_temp + " " + Literal16.Text + " " + etichettasetpoint
        '    Literal17.Text = label_canale_temp + " " + Literal17.Text + " " + etichettasetpoint
        '    value_option_ch3_ma_h.Text = Replace((Val(Mid(option_value(0), 36, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA High
        '    value_option_ch3_ma_l.Text = Replace((Val(Mid(option_value(0), 40, 4)) / fattore_divisione_temp).ToString, ",", ".") '  mA Low
        '    set_variable_javascript(8, 0) = "ch2_en"
        '    set_variable_javascript(8, 1) = "1"
        '    set_variable_javascript(9, 0) = "ch3_en"
        '    set_variable_javascript(9, 1) = "1"
        '    value_option_Number_week.Text = Format(Val(Mid(option_value(0), 44, 2)), "0") ' Number Week
        'End If

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 9)

    End Sub
        Private Function MakeDataOption() As String

            Dim Risultato As String
            Dim Normal As Integer
            Dim Reverse As Integer
            Dim Disable As Integer
            Dim Normal_1 As Integer
            Dim Reverse_1 As Integer
            Dim Disable_1 As Integer
            Dim mA020 As Integer
            Dim mA420 As Integer
        Dim N_O_ As Integer
        Dim N_C_ As Integer
        Dim WM1 As Integer
        Dim WM2 As Integer
        Dim WM1_WM2 As Integer
        Dim Enable_mA As Integer
        Dim Disable_mA As Integer
            Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
            Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
            Dim config_value() As String
            Dim personalizzazione_aquacare As Integer
            Dim new_version As Boolean = False
            Dim MTower_Type As String = ""
            Dim version_str As String = ""
            Dim fattore_divisione_temp As Integer = 0

            tabella_strumento = (Session("strumento"))
            For Each dc1 In tabella_strumento
                If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                    riga_strumento = dc1
                End If
            Next
            config_value = main_function.get_split_str(riga_strumento.value4)
        new_version = main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        MTower_Type = main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str)

            Risultato = Format(Val(value_option_tau.Text), "00")                   ' Tau
            Risultato = Risultato + Format(Val(value_option_coefficiente_temperatura.Text) * 10, "00")  ' Coeff Temp
            Risultato = Risultato + Format(Val(value_option_startup_delay.Text), "00")       ' Startup Delay


            If value_option_flow.SelectedValue = "0" Then
                Normal = 1
            Else
                Normal = 0
            End If

            If value_option_flow.SelectedValue = "1" Then
                Reverse = 1
            Else
                Reverse = 0
            End If

            If value_option_flow.SelectedValue = "2" Then
                Disable = 1
            Else
                Disable = 0
            End If

            Risultato = Risultato + Format(Normal, "0") + Format(Reverse, "0") + Format(Disable, "0")

            If value_ma_out.SelectedValue = "0" Then
                mA020 = 1
            Else
                mA020 = 0
            End If

            If value_ma_out.SelectedValue = "1" Then
                mA420 = 1
            Else
                mA420 = 0
            End If

            Risultato = Risultato + Format(mA020, "0") + Format(mA420, "0")

            Risultato = Risultato + Format(Val(value_option_ch1_ma_h.Text), "0000")  ' Conductivity mA High
            Risultato = Risultato + Format(Val(value_option_ch1_ma_l.Text), "0000")  ' Conductivity mA Low

            Risultato = Risultato + Format(Val(value_option_temperature_ma_h.Text), "000")   ' Temperature mA High
            Risultato = Risultato + Format(Val(value_option_temperature_ma_l.Text), "000")   ' Temperature mA Low


        If option_alarm_out_no.Checked = True Then
            N_O_ = 1
        Else
            N_O_ = 0
        End If


        If option_alarm_out_nc.Checked = True Then
            N_C_ = 1
        Else
            N_C_ = 0
        End If

        Risultato = Risultato + Format(N_O_, "0") + Format(N_C_, "0")

        If value_option_inhib_wm.SelectedValue = "0" Then
            WM1 = 1
        Else
            WM1 = 0
        End If

        If value_option_inhib_wm.SelectedValue = "1" Then
            WM2 = 1
        Else
            WM2 = 0
        End If

        If value_option_inhib_wm.SelectedValue = "2" Then
            WM1_WM2 = 1
        Else
            WM1_WM2 = 0
        End If

        Risultato = Risultato + Format(WM1, "0") + Format(WM2, "0") + Format(WM1_WM2, "0")


        If option_enable_ma_out.Checked = True Then
            Enable_mA = 1
        Else
            Enable_mA = 0
        End If


        If option_disable_ma_out.Checked = True Then
            Disable_mA = 1
        Else
            Disable_mA = 0
        End If

        Risultato = Risultato + Format(Enable_mA, "0") + Format(Disable_mA, "0")

        'If (MTower_Type = "Cdxxx") Then
        '    'Risultato = Risultato + Format(Val(value_option_ch2_ma_h.Text), "0000")  ' ch2 mA High
        '    'Risultato = Risultato + Format(Val(value_option_ch2_ma_l.Text), "0000")  ' ch2 mA Low
        'End If
        'If (MTower_Type = "Cd_pH") Or (MTower_Type = "Cd_rH") Or (MTower_Type = "Cd_Cl") Then
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp)

        '    Risultato = Risultato + Format(Val(value_option_ch2_ma_h.Text) * fattore_divisione_temp, "0000")  ' ch2 mA High
        '    Risultato = Risultato + Format(Val(value_option_ch2_ma_l.Text) * fattore_divisione_temp, "0000")  ' ch2 mA Low

        'End If


        'If (MTower_Type = "Cd_pH_rH") Or (MTower_Type = "Cd_pH_Cl") Then
        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp)

        '    Risultato = Risultato + Format(Val(value_option_ch2_ma_h.Text) * fattore_divisione_temp, "0000")  ' ch2 mA High
        '    Risultato = Risultato + Format(Val(value_option_ch2_ma_l.Text) * fattore_divisione_temp, "0000")  ' ch2 mA Low

        '    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , _
        '                                      , fattore_divisione_temp)


        '    Risultato = Risultato + Format(Val(value_option_ch3_ma_h.Text) * fattore_divisione_temp, "0000")  ' ch3 mA High
        '    Risultato = Risultato + Format(Val(value_option_ch3_ma_l.Text) * fattore_divisione_temp, "0000")  ' ch3 mA Low

        'End If



        'Risultato = Risultato + Format(Val(value_option_Number_week.Text), "00")    ' Number Week

        'If new_version = True Then

        '    If value_option_alarm_out.SelectedValue = "0" Then           ' Alarm Output NO
        '        Risultato = Risultato + "1"
        '    Else
        '        Risultato = Risultato + "0"
        '    End If

        '    If value_option_alarm_out.SelectedValue = "1" Then           ' Alarm Output NC
        '        Risultato = Risultato + "1"
        '    Else
        '        Risultato = Risultato + "0"
        '    End If

        'End If


            'Try
            '    If Session("Aquacare") = 1 Then

            '        If ASPxComboBox6.Value = "Normal" Then
            '            Normal_1 = 1
            '        Else
            '            Normal_1 = 0
            '        End If

            '        If ASPxComboBox6.Value = "Reverse" Then
            '            Reverse_1 = 1
            '        Else
            '            Reverse_1 = 0
            '        End If

            '        If ASPxComboBox6.Value = "Disable" Then
            '            Disable_1 = 1
            '        Else
            '            Disable_1 = 0
            '        End If

            '        If ASPxComboBox9.Value = "N.O." Then
            '            NO_NC = 1
            '        Else
            '            NO_NC = 0
            '        End If

            '        Risultato = Risultato + Format(Normal_1, "0") + Format(Reverse_1, "0") + Format(Disable_1, "0") + Format(NO_NC, "0")

            '    End If

            'Catch ex As Exception

            'End Try

            Return id_485_impianto + "optiowMT" + Risultato + "optiowend" & Chr(13)



        End Function

    Protected Sub save_option_ldtower_new_Click(sender As Object, e As EventArgs) Handles save_option_ldtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeDataOption()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=5" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub

End Class

