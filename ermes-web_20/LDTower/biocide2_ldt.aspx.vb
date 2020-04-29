Public Class biocide2_ldt
        Inherits lingua

        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""
        Private Shared canale As String = ""


    Private Sub biocide2_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_biocide2_ldtower(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_biocide2_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim version_str As String
        Dim config_value() As String
        Dim unit_value() As String
        Dim optio_value() As String
        Dim biocide_value() As String
        Dim biocide_d1_value() As String
        Dim biocide_d2_value() As String
        Dim biocide_d3_value() As String
        Dim biocide_d4_value() As String
        Dim biocide_d5_value() As String
        Dim biocide_d6_value() As String
        Dim biocide_d7_value() As String
        Dim personalizzazione_aquacare As Integer
        Dim full_scale_temp As Integer = 0

        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim international_unit As String = ""
        Dim measure_unit As String = ""

        ' abilito pulsante modifica
        save_biocide_ldtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;",
                    ClientScript.GetPostBackEventReference(save_biocide_ldtower_new, ""))


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        config_value = main_function.get_split_str(riga_strumento.value4)

        biocide_value = main_function.get_split_str(riga_strumento.value20)
        biocide_d1_value = main_function.get_split_str(riga_strumento.value21)
        biocide_d2_value = main_function.get_split_str(riga_strumento.value22)
        biocide_d3_value = main_function.get_split_str(riga_strumento.value23)
        biocide_d4_value = main_function.get_split_str(riga_strumento.value24)
        biocide_d5_value = main_function.get_split_str(riga_strumento.value30)
        biocide_d6_value = main_function.get_split_str(riga_strumento.value31)
        biocide_d7_value = main_function.get_split_str(riga_strumento.value32)

        optio_value = main_function.get_split_str(riga_strumento.value7)
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)
        main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , full_scale_temp)

        function_java = function_java + create_biocide2(optio_value(0), biocide_value(0), measure_unit, version_str, full_scale_temp)
        If international_unit = "IS" Then 'formato italiano
            function_java = function_java + "activate_time_picker_biocide(1);"
        Else
            function_java = function_java + "activate_time_picker_biocide(0);"
        End If
        function_java = function_java + create_biocide_day("1", biocide_d1_value, international_unit, biocide_day1_first, value_biocide_count_day1_first_hr, value_biocide_count_day1_first_min, value_biocide_time_day1_first_hr, _
                            value_biocide_time_day1_first_min, am_day1_first, pm_day1_first, enable_ampm_day1_first, biocide_day1_second, value_biocide_count_day1_second_hr, value_biocide_count_day1_second_min, value_biocide_time_day1_second_hr, value_biocide_time_day1_second_min, _
                            am_day1_second, pm_day1_second, enable_ampm_day1_second, biocide_day1_third, value_biocide_count_day1_third_hr, value_biocide_count_day1_third_min, value_biocide_time_day1_third_hr, value_biocide_time_day1_third_min, am_day1_third, pm_day1_third, enable_ampm_day1_third, _
                            biocide_day1_fourth, value_biocide_count_day1_fourth_hr, value_biocide_count_day1_fourth_min, value_biocide_time_day1_fourth_hr, value_biocide_time_day1_fourth_min, am_day1_fourth, pm_day1_fourth, enable_ampm_day1_fourth)

        function_java = function_java + create_biocide_day("2", biocide_d2_value, international_unit, biocide_day2_first, value_biocide_count_day2_first_hr, value_biocide_count_day2_first_min, value_biocide_time_day2_first_hr, _
                            value_biocide_time_day2_first_min, am_day2_first, pm_day2_first, enable_ampm_day2_first, biocide_day2_second, value_biocide_count_day2_second_hr, value_biocide_count_day2_second_min, value_biocide_time_day2_second_hr, value_biocide_time_day2_second_min, _
                            am_day2_second, pm_day2_second, enable_ampm_day2_second, biocide_day2_third, value_biocide_count_day2_third_hr, value_biocide_count_day2_third_min, value_biocide_time_day2_third_hr, value_biocide_time_day2_third_min, am_day2_third, pm_day2_third, _
                            enable_ampm_day2_third, biocide_day2_fourth, value_biocide_count_day2_fourth_hr, value_biocide_count_day2_fourth_min, value_biocide_time_day2_fourth_hr, value_biocide_time_day2_fourth_min, am_day2_fourth, pm_day2_fourth, enable_ampm_day2_fourth)

        function_java = function_java + create_biocide_day("3", biocide_d3_value, international_unit, biocide_day3_first, value_biocide_count_day3_first_hr, value_biocide_count_day3_first_min, value_biocide_time_day3_first_hr, _
                            value_biocide_time_day3_first_min, am_day3_first, pm_day3_first, enable_ampm_day3_first, biocide_day3_second, value_biocide_count_day3_second_hr, value_biocide_count_day3_second_min, value_biocide_time_day3_second_hr, value_biocide_time_day3_second_min, _
                            am_day3_second, pm_day3_second, enable_ampm_day3_second, biocide_day3_third, value_biocide_count_day3_third_hr, value_biocide_count_day3_third_min, value_biocide_time_day3_third_hr, value_biocide_time_day3_third_min, am_day3_third, pm_day3_third, enable_ampm_day3_third, _
                            biocide_day3_fourth, value_biocide_count_day3_fourth_hr, value_biocide_count_day3_fourth_min, value_biocide_time_day3_fourth_hr, value_biocide_time_day3_fourth_min, am_day3_fourth, pm_day3_fourth, enable_ampm_day3_fourth)

        function_java = function_java + create_biocide_day("4", biocide_d4_value, international_unit, biocide_day4_first, value_biocide_count_day4_first_hr, value_biocide_count_day4_first_min, value_biocide_time_day4_first_hr, _
                            value_biocide_time_day4_first_min, am_day4_first, pm_day4_first, enable_ampm_day4_first, biocide_day4_second, value_biocide_count_day4_second_hr, value_biocide_count_day4_second_min, value_biocide_time_day4_second_hr, value_biocide_time_day4_second_min, _
                            am_day4_second, pm_day4_second, enable_ampm_day4_second, biocide_day4_third, value_biocide_count_day4_third_hr, value_biocide_count_day4_third_min, value_biocide_time_day4_third_hr, value_biocide_time_day4_third_min, am_day4_third, pm_day4_third, enable_ampm_day4_third, _
                            biocide_day4_fourth, value_biocide_count_day4_fourth_hr, value_biocide_count_day4_fourth_min, value_biocide_time_day4_fourth_hr, value_biocide_time_day4_fourth_min, am_day4_fourth, pm_day4_fourth, enable_ampm_day4_fourth)

        function_java = function_java + create_biocide_day("5", biocide_d5_value, international_unit, biocide_day5_first, value_biocide_count_day5_first_hr, value_biocide_count_day5_first_min, value_biocide_time_day5_first_hr, _
                            value_biocide_time_day5_first_min, am_day5_first, pm_day5_first, enable_ampm_day5_first, biocide_day5_second, value_biocide_count_day5_second_hr, value_biocide_count_day5_second_min, value_biocide_time_day5_second_hr, value_biocide_time_day5_second_min, _
                            am_day5_second, pm_day5_second, enable_ampm_day5_second, biocide_day5_third, value_biocide_count_day5_third_hr, value_biocide_count_day5_third_min, value_biocide_time_day5_third_hr, value_biocide_time_day5_third_min, am_day5_third, pm_day5_third, enable_ampm_day5_third, _
                            biocide_day5_fourth, value_biocide_count_day5_fourth_hr, value_biocide_count_day5_fourth_min, value_biocide_time_day5_fourth_hr, value_biocide_time_day5_fourth_min, am_day5_fourth, pm_day5_fourth, enable_ampm_day5_fourth)

        function_java = function_java + create_biocide_day("6", biocide_d6_value, international_unit, biocide_day6_first, value_biocide_count_day6_first_hr, value_biocide_count_day6_first_min, value_biocide_time_day6_first_hr, _
                            value_biocide_time_day6_first_min, am_day6_first, pm_day6_first, enable_ampm_day6_first, biocide_day6_second, value_biocide_count_day6_second_hr, value_biocide_count_day6_second_min, value_biocide_time_day6_second_hr, value_biocide_time_day6_second_min, _
                            am_day6_second, pm_day6_second, enable_ampm_day6_second, biocide_day6_third, value_biocide_count_day6_third_hr, value_biocide_count_day6_third_min, value_biocide_time_day6_third_hr, value_biocide_time_day6_third_min, am_day6_third, pm_day6_third, enable_ampm_day6_third, _
                            biocide_day6_fourth, value_biocide_count_day6_fourth_hr, value_biocide_count_day6_fourth_min, value_biocide_time_day6_fourth_hr, value_biocide_time_day6_fourth_min, am_day6_fourth, pm_day6_fourth, enable_ampm_day6_fourth)

        function_java = function_java + create_biocide_day("7", biocide_d7_value, international_unit, biocide_day7_first, value_biocide_count_day7_first_hr, value_biocide_count_day7_first_min, value_biocide_time_day7_first_hr, _
                            value_biocide_time_day7_first_min, am_day7_first, pm_day7_first, enable_ampm_day7_first, biocide_day7_second, value_biocide_count_day7_second_hr, value_biocide_count_day7_second_min, value_biocide_time_day7_second_hr, value_biocide_time_day7_second_min, _
                            am_day7_second, pm_day7_second, enable_ampm_day7_second, biocide_day7_third, value_biocide_count_day7_third_hr, value_biocide_count_day7_third_min, value_biocide_time_day7_third_hr, value_biocide_time_day7_third_min, am_day7_third, pm_day7_third, enable_ampm_day7_third, _
                            biocide_day7_fourth, value_biocide_count_day7_fourth_hr, value_biocide_count_day7_fourth_min, value_biocide_time_day7_fourth_hr, value_biocide_time_day7_fourth_min, am_day7_fourth, pm_day7_fourth, enable_ampm_day7_fourth)



        java_script_function.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function create_biocide_day(ByVal number_week As String, ByVal biocide_day() As String, ByVal international_unit As String, ByVal check_first As CheckBox, ByVal time_first_count_hr As TextBox, ByVal time_first_count_min As TextBox, ByVal time_first_time_hr As TextBox, ByVal time_first_time_min As TextBox, _
                                        ByVal am_first As RadioButton, ByVal pm_first As RadioButton, ByVal enable_ampm_first As PlaceHolder, ByVal check_second As CheckBox, ByVal time_second_count_hr As TextBox, ByVal time_second_count_min As TextBox, ByVal time_second_time_hr As TextBox, ByVal time_second_time_min As TextBox, ByVal am_second As RadioButton, ByVal pm_second As RadioButton, _
                                        ByVal enable_ampm_second As PlaceHolder, ByVal check_third As CheckBox, ByVal time_third_count_hr As TextBox, ByVal time_third_count_min As TextBox, ByVal time_third_time_hr As TextBox, ByVal time_third_time_min As TextBox, ByVal am_third As RadioButton, ByVal pm_third As RadioButton, ByVal enable_ampm_third As PlaceHolder, _
                                        ByVal check_fourth As CheckBox, ByVal time_fourth_count_hr As TextBox, ByVal time_fourth_count_min As TextBox, ByVal time_fourth_time_hr As TextBox, ByVal time_fourth_time_min As TextBox, ByVal am_fourth As RadioButton, ByVal pm_fourth As RadioButton, ByVal enable_ampm_fourth As PlaceHolder) As String

        Dim function_java As String = ""
        'Dim java_script_variable As java_script = New java_script


        If Val(Mid(biocide_day(0), 3, 1)) Then
            check_first.Checked = True
            time_first_count_hr.Text = Format(Val(Mid(biocide_day(0), 5, 2)), "00")
            time_first_count_min.Text = Format(Val(Mid(biocide_day(0), 7, 2)), "00")
            time_first_time_hr.Text = Format(Val(Mid(biocide_day(0), 9, 2)), "00")
            time_first_time_min.Text = Format(Val(Mid(biocide_day(0), 11, 2)), "00")
        Else
            check_first.Checked = False
        End If


        If international_unit = "IS" Then 'formato italiano
            enable_ampm_first.Visible = False
        Else
            enable_ampm_first.Visible = True
            If Val(Mid(biocide_day(0), 13, 1)) Then
                am_first.Checked = True
            Else
                pm_first.Checked = True
            End If
        End If


        function_java = function_java + "manage_biocide_day" + number_week + "_first();"

        If Val(Mid(biocide_day(1), 3, 1)) Then
            check_second.Checked = True
            time_second_count_hr.Text = Format(Val(Mid(biocide_day(1), 5, 2)), "00")
            time_second_count_min.Text = Format(Val(Mid(biocide_day(1), 7, 2)), "00")
            time_second_time_hr.Text = Format(Val(Mid(biocide_day(1), 9, 2)), "00")
            time_second_time_min.Text = Format(Val(Mid(biocide_day(1), 11, 2)), "00")
        Else
            check_second.Checked = False
        End If

        If international_unit = "IS" Then 'formato italiano
            enable_ampm_second.Visible = False
        Else
            enable_ampm_second.Visible = True
            If Val(Mid(biocide_day(1), 13, 1)) Then
                am_second.Checked = True
            Else
                pm_second.Checked = True
            End If
        End If


        function_java = function_java + "manage_biocide_day" + number_week + "_second();"

        If Val(Mid(biocide_day(2), 3, 1)) Then
            check_third.Checked = True
            time_third_count_hr.Text = Format(Val(Mid(biocide_day(2), 5, 2)), "00")
            time_third_count_min.Text = Format(Val(Mid(biocide_day(2), 7, 2)), "00")
            time_third_time_hr.Text = Format(Val(Mid(biocide_day(2), 9, 2)), "00")
            time_third_time_min.Text = Format(Val(Mid(biocide_day(2), 11, 2)), "00")
        Else
            check_third.Checked = False
        End If

        If international_unit = "IS" Then 'formato italiano
            enable_ampm_third.Visible = False
        Else
            enable_ampm_third.Visible = True
            If Val(Mid(biocide_day(2), 13, 1)) Then
                am_third.Checked = True
            Else
                pm_third.Checked = True
            End If
        End If

        function_java = function_java + "manage_biocide_day" + number_week + "_third();"


        If Val(Mid(biocide_day(3), 3, 1)) Then
            check_fourth.Checked = True
            time_fourth_count_hr.Text = Format(Val(Mid(biocide_day(3), 5, 2)), "00")
            time_fourth_count_min.Text = Format(Val(Mid(biocide_day(3), 7, 2)), "00")
            time_fourth_time_hr.Text = Format(Val(Mid(biocide_day(3), 9, 2)), "00")
            time_fourth_time_min.Text = Format(Val(Mid(biocide_day(3), 11, 2)), "00")

        Else
            check_fourth.Checked = False
        End If

        If international_unit = "IS" Then 'formato italiano
            enable_ampm_fourth.Visible = False
        Else
            enable_ampm_fourth.Visible = True
            If Val(Mid(biocide_day(3), 13, 1)) Then
                am_fourth.Checked = True
            Else
                pm_fourth.Checked = True
            End If
        End If

        function_java = function_java + "manage_biocide_day" + number_week + "_fourth();"


        Return function_java

        'java_script_variable.call_function_javascript_onload(Page, function_java)
    End Function
    Private Function create_biocide2(ByVal option_value As String, ByVal biocide2_value As String, ByVal SelectedMeasureUnit As String, ByVal version_str As String, _
                                    ByVal full_scale_temp As Integer) As String
        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim java_script_variable As java_script = New java_script
        'Dim java_script_function As java_script = New java_script


        If SelectedMeasureUnit = "uS" Then
            Literal8.Text = "uS "
        Else
            Literal8.Text = "ppm "
        End If
        ' If InStr(version_str, "5.0.5") Then

        set_variable_javascript(0, 0) = "max_us"

            If full_scale_temp = 5000 Then
                set_variable_javascript(0, 1) = "5000"
                Literal8.Text = Literal8.Text + "0"
            Else
                set_variable_javascript(0, 1) = "500"
                'Literal8.Text = Literal8.Text + "0"
            End If
        'End If

        If Val(Mid(biocide2_value, 3, 1)) Then

            pre_bleed_time.Checked = True    'Time
            function_java = function_java + "pre_bleed_time_enable();"

        Else
            pre_bleed_us.Checked = True    'us
            function_java = function_java + "pre_bleed_us_enable();"
        End If

        value_pre_bleed_time_hr.Text = Format(Val(Mid(biocide2_value, 9, 2)), "00")       ' Time Hour
        value_pre_bleed_time_min.Text = Format(Val(Mid(biocide2_value, 11, 2)), "00")          ' Time Minute
        value_pre_bleed_us.Text = Format(Val(Mid(biocide2_value, 5, 4)), "0000")  ' uS Value

        value_pre_lockout_hr.Text = Format(Val(Mid(biocide2_value, 13, 2)), "00")          ' LockOut Hour
        value_pre_lockout_min.Text = Format(Val(Mid(biocide2_value, 15, 2)), "00")          ' LockOut Minute

        value_circulation_hr.Text = Format(Val(Mid(biocide2_value, 17, 2)), "00")          ' Circulation Hour
        value_circulation_min.Text = Format(Val(Mid(biocide2_value, 19, 2)), "00")         ' circulation Minute


        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)
        'java_script_function.call_function_javascript_onload(Page, function_java)
        Return function_java
    End Function
    Private Function MakeBiocide2() As String
        Dim Risultato As String
        Dim Time As Integer
        Dim Siemens As Integer

        If pre_bleed_time.Checked Then
            Time = 1
            Siemens = 0
        End If

        If pre_bleed_us.Checked Then
            Time = 0
            Siemens = 1
        End If
        Risultato = Format(Siemens, "0") + Format(Time, "0") + Format(Val(value_pre_bleed_us.Text), "0000") + Format(Val(value_pre_bleed_time_hr.Text), "00") + Format(Val(value_pre_bleed_time_min.Text), "00") + Format(Val(value_pre_lockout_hr.Text), "00") + Format(Val(value_pre_lockout_min.Text), "00") + Format(Val(value_circulation_hr.Text), "00") + Format(Val(value_circulation_min.Text), "00")
        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bioc1wMT" + Risultato + "bioc1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bioc2wMT" + Risultato + "bioc2wend" & Chr(13)
    End Function
    Private Function MakeBiocide2Day1String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day1_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day1_first.Checked Then
                AM = 1
                PM = 0
            Else
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day1_first_hr.Text), "00") + Format(Val(value_biocide_count_day1_first_min.Text), "00") + Format(Val(value_biocide_time_day1_first_hr.Text), "00") + Format(Val(value_biocide_time_day1_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"




        If biocide_day1_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day1_second.Checked Then
                AM = 1
                PM = 0
            Else
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day1_second_hr.Text), "00") + Format(Val(value_biocide_count_day1_second_min.Text), "00") + Format(Val(value_biocide_time_day1_second_hr.Text), "00") + Format(Val(value_biocide_time_day1_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day1_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day1_third.Checked Then
                AM = 1
                PM = 0
            Else
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day1_third_hr.Text), "00") + Format(Val(value_biocide_count_day1_third_min.Text), "00") + Format(Val(value_biocide_time_day1_third_hr.Text), "00") + Format(Val(value_biocide_time_day1_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"


        If biocide_day1_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day1_fourth.Checked Then
                AM = 1
                PM = 0
            Else
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If



        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day1_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day1_fourth_min.Text), "00") + Format(Val(value_biocide_time_day1_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day1_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w1w" + Risultato + "bi2w1wend" & Chr(13)

    End Function

    Private Function MakeBiocide2Day2String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day2_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day2_first.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day1_first.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day2_first_hr.Text), "00") + Format(Val(value_biocide_count_day2_first_min.Text), "00") + Format(Val(value_biocide_time_day2_first_hr.Text), "00") + Format(Val(value_biocide_time_day2_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day2_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day2_second.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day2_second.Checked Then
                AM = 0
                PM = 1
            End If

        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day2_second_hr.Text), "00") + Format(Val(value_biocide_count_day2_second_min.Text), "00") + Format(Val(value_biocide_time_day2_second_hr.Text), "00") + Format(Val(value_biocide_time_day2_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day2_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day2_third.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day2_third.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day2_third_hr.Text), "00") + Format(Val(value_biocide_count_day2_third_min.Text), "00") + Format(Val(value_biocide_time_day2_third_hr.Text), "00") + Format(Val(value_biocide_time_day2_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"


        If biocide_day2_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day2_fourth.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day2_fourth.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day2_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day2_fourth_min.Text), "00") + Format(Val(value_biocide_time_day2_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day2_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w2w" + Risultato + "bi2w2wend" & Chr(13)

    End Function
    Private Function MakeBiocide2Day3String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String



        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day3_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day3_first.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day3_first.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day3_first_hr.Text), "00") + Format(Val(value_biocide_count_day3_first_min.Text), "00") + Format(Val(value_biocide_time_day3_first_hr.Text), "00") + Format(Val(value_biocide_time_day3_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day3_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day3_second.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day3_second.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day3_second_hr.Text), "00") + Format(Val(value_biocide_count_day3_second_min.Text), "00") + Format(Val(value_biocide_time_day3_second_hr.Text), "00") + Format(Val(value_biocide_time_day3_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day3_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day3_third.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day3_third.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day3_third_hr.Text), "00") + Format(Val(value_biocide_count_day3_third_min.Text), "00") + Format(Val(value_biocide_time_day3_third_hr.Text), "00") + Format(Val(value_biocide_time_day3_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"


        If biocide_day3_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day3_fourth.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day3_fourth.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day3_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day3_fourth_min.Text), "00") + Format(Val(value_biocide_time_day3_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day3_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w3w" + Risultato + "bi2w3wend" & Chr(13)

    End Function

    Private Function MakeBiocide2Day4String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day4_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day4_first.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day4_first.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day4_first_hr.Text), "00") + Format(Val(value_biocide_count_day4_first_min.Text), "00") + Format(Val(value_biocide_time_day4_first_hr.Text), "00") + Format(Val(value_biocide_time_day4_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day4_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day4_second.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day4_second.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day4_second_hr.Text), "00") + Format(Val(value_biocide_count_day4_second_min.Text), "00") + Format(Val(value_biocide_time_day4_second_hr.Text), "00") + Format(Val(value_biocide_time_day4_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day4_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day4_third.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day4_third.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day4_third_hr.Text), "00") + Format(Val(value_biocide_count_day4_third_min.Text), "00") + Format(Val(value_biocide_time_day4_third_hr.Text), "00") + Format(Val(value_biocide_time_day4_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"


        If biocide_day4_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day4_fourth.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day4_fourth.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day4_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day4_fourth_min.Text), "00") + Format(Val(value_biocide_time_day4_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day4_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w4w" + Risultato + "bi2w4wend" & Chr(13)

    End Function


    Private Function MakeBiocide2Day5String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day5_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day5_first.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day5_first.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day5_first_hr.Text), "00") + Format(Val(value_biocide_count_day5_first_min.Text), "00") + Format(Val(value_biocide_time_day5_first_hr.Text), "00") + Format(Val(value_biocide_time_day5_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day5_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day5_second.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day5_second.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day5_second_hr.Text), "00") + Format(Val(value_biocide_count_day5_second_min.Text), "00") + Format(Val(value_biocide_time_day5_second_hr.Text), "00") + Format(Val(value_biocide_time_day5_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day5_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day5_third.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day5_third.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day5_third_hr.Text), "00") + Format(Val(value_biocide_count_day5_third_min.Text), "00") + Format(Val(value_biocide_time_day5_third_hr.Text), "00") + Format(Val(value_biocide_time_day5_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day5_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day5_fourth.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day5_fourth.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day5_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day5_fourth_min.Text), "00") + Format(Val(value_biocide_time_day5_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day5_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w5w" + Risultato + "bi2w5wend" & Chr(13)

    End Function



    Private Function MakeBiocide2Day6String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day6_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day6_first.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day6_first.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day6_first_hr.Text), "00") + Format(Val(value_biocide_count_day6_first_min.Text), "00") + Format(Val(value_biocide_time_day6_first_hr.Text), "00") + Format(Val(value_biocide_time_day6_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day6_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day6_second.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day6_second.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day6_second_hr.Text), "00") + Format(Val(value_biocide_count_day6_second_min.Text), "00") + Format(Val(value_biocide_time_day6_second_hr.Text), "00") + Format(Val(value_biocide_time_day6_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day6_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day6_third.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day6_third.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day6_third_hr.Text), "00") + Format(Val(value_biocide_count_day6_third_min.Text), "00") + Format(Val(value_biocide_time_day6_third_hr.Text), "00") + Format(Val(value_biocide_time_day6_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"


        If biocide_day6_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day6_fourth.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day6_fourth.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day6_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day6_fourth_min.Text), "00") + Format(Val(value_biocide_time_day6_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day6_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w6w" + Risultato + "bi2w6wend" & Chr(13)

    End Function



    Private Function MakeBiocide2Day7String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As Integer
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)


        If biocide_day7_first.Checked Then
            Enable = 1
            Disable = 0
            If am_day7_first.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day7_first.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day7_first_hr.Text), "00") + Format(Val(value_biocide_count_day7_first_min.Text), "00") + Format(Val(value_biocide_time_day7_first_hr.Text), "00") + Format(Val(value_biocide_time_day7_first_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day7_second.Checked Then
            Enable = 1
            Disable = 0
            If am_day7_second.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day7_second.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day7_second_hr.Text), "00") + Format(Val(value_biocide_count_day7_second_min.Text), "00") + Format(Val(value_biocide_time_day7_second_hr.Text), "00") + Format(Val(value_biocide_time_day7_second_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"



        If biocide_day7_third.Checked Then
            Enable = 1
            Disable = 0
            If am_day7_third.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day7_third.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day7_third_hr.Text), "00") + Format(Val(value_biocide_count_day7_third_min.Text), "00") + Format(Val(value_biocide_time_day7_third_hr.Text), "00") + Format(Val(value_biocide_time_day7_third_min.Text), "00") + Format(AM, "0") + Format(PM, "0") + "#"


        If biocide_day7_fourth.Checked Then
            Enable = 1
            Disable = 0
            If am_day7_fourth.Checked Then
                AM = 1
                PM = 0
            ElseIf pm_day7_fourth.Checked Then
                AM = 0
                PM = 1
            End If
        Else
            Enable = 0
            Disable = 1
            AM = 0
            PM = 0
        End If

        Risultato = Risultato + "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide_count_day7_fourth_hr.Text), "00") + Format(Val(value_biocide_count_day7_fourth_min.Text), "00") + Format(Val(value_biocide_time_day7_fourth_hr.Text), "00") + Format(Val(value_biocide_time_day7_fourth_min.Text), "00") + Format(AM, "0") + Format(PM, "0")



        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w7w" + Risultato + "bi2w7wend" & Chr(13)

    End Function



        Protected Sub save_biocide_ldtower_new_Click(sender As Object, e As EventArgs) Handles save_biocide_ldtower_new.Click
            Dim local_connection As Boolean
            Dim new_setpoint1 As String = ""
            Dim new_setpoint2 As String = ""
            Dim new_setpoint3 As String = ""
            Dim new_setpoint4 As String = ""
            Dim new_setpoint5 As String = ""
            Dim new_setpoint6 As String = ""
            Dim new_setpoint7 As String = ""
            Dim new_setpoint8 As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint1 = MakeBiocide2()
        new_setpoint2 = MakeBiocide2Day1String()
        new_setpoint3 = MakeBiocide2Day2String()
        new_setpoint4 = MakeBiocide2Day3String()
        new_setpoint5 = MakeBiocide2Day4String()
        new_setpoint6 = MakeBiocide2Day5String()
        new_setpoint7 = MakeBiocide2Day6String()
        new_setpoint8 = MakeBiocide2Day7String()
        If local_connection Then ' connessione OK
            write_setpoint_new.web_setpoint_change_biocide_ldtower(codice_impianto, id_485_impianto, new_setpoint1, new_setpoint2, new_setpoint3, new_setpoint4, new_setpoint5, new_setpoint6, new_setpoint7, new_setpoint8, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If

        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=2" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

        End Sub
    End Class

