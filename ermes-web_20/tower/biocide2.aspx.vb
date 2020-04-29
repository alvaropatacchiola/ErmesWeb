Public Class biocide2
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
            posiziona_biocide2_tower(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_biocide2_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable



        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim version_str As String
        Dim config_value() As String
        Dim unit_value() As String
        Dim optio_value() As String
        Dim biocide2_value() As String
        Dim biocide2_w1_value() As String
        Dim biocide2_w2_value() As String
        Dim biocide2_w3_value() As String
        Dim biocide2_w4_value() As String
        Dim personalizzazione_aquacare As Integer
        Dim full_scale_temp As Integer = 0

        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_biocide1tower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_biocide1tower_new, ""))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        config_value = main_function.get_split_str(riga_strumento.value4)

        biocide2_value = main_function.get_split_str(riga_strumento.value20)
        biocide2_w1_value = main_function.get_split_str(riga_strumento.value21)
        biocide2_w2_value = main_function.get_split_str(riga_strumento.value22)
        biocide2_w3_value = main_function.get_split_str(riga_strumento.value23)
        biocide2_w4_value = main_function.get_split_str(riga_strumento.value24)
        optio_value = main_function.get_split_str(riga_strumento.value7)
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , full_scale_temp)

        function_java = function_java + create_biocide1(optio_value(0), biocide2_value(0), measure_unit, version_str, full_scale_temp)
        If international_unit = "IS" Then 'formato italiano
            function_java = function_java + "activate_time_picker_biocide(1);"
        Else
            function_java = function_java + "activate_time_picker_biocide(0);"
        End If
        function_java = function_java + create_biocide_week("1", biocide2_w1_value, international_unit, biocide1_week1_lunedi, value_biocide1_week1_lunedi_hr, value_biocide1_week1_lunedi_min, value_biocide1_week1_lunedi_feed, _
                            biocide1_week1_martedi, value_biocide1_week1_martedi_hr, value_biocide1_week1_martedi_min, value_biocide1_week1_martedi_feed, _
                            biocide1_week1_mercoledi, value_biocide1_week1_mercoledi_hr, value_biocide1_week1_mercoledi_min, value_biocide1_week1_mercoledi_feed, _
                            biocide1_week1_giovedi, value_biocide1_week1_giovedi_hr, value_biocide1_week1_giovedi_min, value_biocide1_week1_giovedi_feed,
                            biocide1_week1_venerdi, value_biocide1_week1_venerdi_hr, value_biocide1_week1_venerdi_min, value_biocide1_week1_venerdi_feed, _
                            biocide1_week1_sabato, value_biocide1_week1_sabato_hr, value_biocide1_week1_sabato_min, value_biocide1_week1_sabato_feed, _
                             biocide1_week1_domenica, value_biocide1_week1_domenica_hr, value_biocide1_week1_domenica_min, value_biocide1_week1_domenica_feed)
        function_java = function_java + create_biocide_week("2", biocide2_w2_value, international_unit, biocide1_week2_lunedi, value_biocide1_week2_lunedi_hr, value_biocide1_week2_lunedi_min, value_biocide1_week2_lunedi_feed,
                            biocide1_week2_martedi, value_biocide1_week2_martedi_hr, value_biocide1_week2_martedi_min, value_biocide1_week2_martedi_feed,
                            biocide1_week2_mercoledi, value_biocide1_week2_mercoledi_hr, value_biocide1_week2_mercoledi_min, value_biocide1_week2_mercoledi_feed,
                            biocide1_week2_giovedi, value_biocide1_week2_giovedi_hr, value_biocide1_week2_giovedi_min, value_biocide1_week2_giovedi_feed,
                            biocide1_week2_venerdi, value_biocide1_week2_venerdi_hr, value_biocide1_week2_venerdi_min, value_biocide1_week2_venerdi_feed,
                            biocide1_week2_sabato, value_biocide1_week2_sabato_hr, value_biocide1_week2_sabato_min, value_biocide1_week2_sabato_feed,
                             biocide1_week2_domenica, value_biocide1_week2_domenica_hr, value_biocide1_week2_domenica_min, value_biocide1_week2_domenica_feed)
        function_java = function_java + create_biocide_week("3", biocide2_w3_value, international_unit, biocide1_week3_lunedi, value_biocide1_week3_lunedi_hr, value_biocide1_week3_lunedi_min, value_biocide1_week3_lunedi_feed, _
                            biocide1_week3_martedi, value_biocide1_week3_martedi_hr, value_biocide1_week3_martedi_min, value_biocide1_week3_martedi_feed, _
                            biocide1_week3_mercoledi, value_biocide1_week3_mercoledi_hr, value_biocide1_week3_mercoledi_min, value_biocide1_week3_mercoledi_feed, _
                            biocide1_week3_giovedi, value_biocide1_week3_giovedi_hr, value_biocide1_week3_giovedi_min, value_biocide1_week3_giovedi_feed,
                            biocide1_week3_venerdi, value_biocide1_week3_venerdi_hr, value_biocide1_week3_venerdi_min, value_biocide1_week3_venerdi_feed, _
                            biocide1_week3_sabato, value_biocide1_week3_sabato_hr, value_biocide1_week3_sabato_min, value_biocide1_week3_sabato_feed, _
                             biocide1_week3_domenica, value_biocide1_week3_domenica_hr, value_biocide1_week3_domenica_min, value_biocide1_week3_domenica_feed)
        function_java = function_java + create_biocide_week("4", biocide2_w4_value, international_unit, biocide1_week4_lunedi, value_biocide1_week4_lunedi_hr, value_biocide1_week4_lunedi_min, value_biocide1_week4_lunedi_feed, _
                            biocide1_week4_martedi, value_biocide1_week4_martedi_hr, value_biocide1_week4_martedi_min, value_biocide1_week4_martedi_feed, _
                            biocide1_week4_mercoledi, value_biocide1_week4_mercoledi_hr, value_biocide1_week4_mercoledi_min, value_biocide1_week4_mercoledi_feed, _
                            biocide1_week4_giovedi, value_biocide1_week4_giovedi_hr, value_biocide1_week4_giovedi_min, value_biocide1_week4_giovedi_feed,
                            biocide1_week4_venerdi, value_biocide1_week4_venerdi_hr, value_biocide1_week4_venerdi_min, value_biocide1_week4_venerdi_feed, _
                            biocide1_week4_sabato, value_biocide1_week4_sabato_hr, value_biocide1_week4_sabato_min, value_biocide1_week4_sabato_feed, _
                             biocide1_week4_domenica, value_biocide1_week4_domenica_hr, value_biocide1_week4_domenica_min, value_biocide1_week4_domenica_feed)

        java_script_function.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function create_biocide_week(ByVal number_week As String, ByVal biocide_week() As String, ByVal international_unit As String, ByVal check_lunedi As CheckBox, ByVal time_lunedi_hr As TextBox, ByVal time_lunedi_min As TextBox, ByVal time_lunedi_feed As TextBox, _
                                    ByVal check_martedi As CheckBox, ByVal time_martedi_hr As TextBox, ByVal time_martedi_min As TextBox, ByVal time_martedi_feed As TextBox, _
                                    ByVal check_mercoledi As CheckBox, ByVal time_mercoledi_hr As TextBox, ByVal time_mercoledi_min As TextBox, ByVal time_mercoledi_feed As TextBox, _
                                    ByVal check_giovedi As CheckBox, ByVal time_giovedi_hr As TextBox, ByVal time_giovedi_min As TextBox, ByVal time_giovedi_feed As TextBox, _
                                    ByVal check_venerdi As CheckBox, ByVal time_venerdi_hr As TextBox, ByVal time_venerdi_min As TextBox, ByVal time_venerdi_feed As TextBox, _
                                    ByVal check_sabato As CheckBox, ByVal time_sabato_hr As TextBox, ByVal time_sabato_min As TextBox, ByVal time_sabato_feed As TextBox, _
                                    ByVal check_domenica As CheckBox, ByVal time_domenica_hr As TextBox, ByVal time_domenica_min As TextBox, ByVal time_domenica_feed As TextBox) As String
        Dim function_java As String = ""
        'Dim java_script_variable As java_script = New java_script


        If Val(Mid(biocide_week(0), 3, 1)) Then
            check_lunedi.Checked = True
            time_lunedi_hr.Text = Format(Val(Mid(biocide_week(0), 5, 2)), "00")
            time_lunedi_min.Text = Format(Val(Mid(biocide_week(0), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_lunedi_feed.Text = Format(Val(Mid(biocide_week(0), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(0), 11, 2)), "00")
            Else
                time_lunedi_feed.Text = Format(Val(Mid(biocide_week(0), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(0), 11, 2)), "00")
                If Val(Mid(biocide_week(0), 13, 1)) Then

                    time_lunedi_feed.Text = time_lunedi_feed.Text + " am"
                Else
                    time_lunedi_feed.Text = time_lunedi_feed.Text + " pm"

                End If
            End If
        Else
            check_lunedi.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_lunedi();"

        If Val(Mid(biocide_week(1), 3, 1)) Then
            check_martedi.Checked = True
            time_martedi_hr.Text = Format(Val(Mid(biocide_week(1), 5, 2)), "00")
            time_martedi_min.Text = Format(Val(Mid(biocide_week(1), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_martedi_feed.Text = Format(Val(Mid(biocide_week(1), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(1), 11, 2)), "00")
            Else
                time_martedi_feed.Text = Format(Val(Mid(biocide_week(1), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(1), 11, 2)), "00")
                If Val(Mid(biocide_week(1), 13, 1)) Then

                    time_martedi_feed.Text = time_martedi_feed.Text + " am"
                Else
                    time_martedi_feed.Text = time_martedi_feed.Text + " pm"

                End If
            End If
        Else
            check_martedi.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_martedi();"

        If Val(Mid(biocide_week(2), 3, 1)) Then
            check_mercoledi.Checked = True
            time_mercoledi_hr.Text = Format(Val(Mid(biocide_week(2), 5, 2)), "00")
            time_mercoledi_min.Text = Format(Val(Mid(biocide_week(2), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_mercoledi_feed.Text = Format(Val(Mid(biocide_week(2), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(2), 11, 2)), "00")
            Else
                time_mercoledi_feed.Text = Format(Val(Mid(biocide_week(2), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(2), 11, 2)), "00")
                If Val(Mid(biocide_week(2), 13, 1)) Then

                    time_mercoledi_feed.Text = time_mercoledi_feed.Text + " am"
                Else
                    time_mercoledi_feed.Text = time_mercoledi_feed.Text + " pm"

                End If
            End If
        Else
            check_mercoledi.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_mercoledi();"

        If Val(Mid(biocide_week(3), 3, 1)) Then
            check_giovedi.Checked = True
            time_giovedi_hr.Text = Format(Val(Mid(biocide_week(3), 5, 2)), "00")
            time_giovedi_min.Text = Format(Val(Mid(biocide_week(3), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_giovedi_feed.Text = Format(Val(Mid(biocide_week(3), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(3), 11, 2)), "00")
            Else
                time_giovedi_feed.Text = Format(Val(Mid(biocide_week(3), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(3), 11, 2)), "00")
                If Val(Mid(biocide_week(3), 13, 1)) Then

                    time_giovedi_feed.Text = time_giovedi_feed.Text + " am"
                Else
                    time_giovedi_feed.Text = time_giovedi_feed.Text + " pm"

                End If
            End If
        Else
            check_giovedi.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_giovedi();"

        If Val(Mid(biocide_week(4), 3, 1)) Then
            check_venerdi.Checked = True
            time_venerdi_hr.Text = Format(Val(Mid(biocide_week(4), 5, 2)), "00")
            time_venerdi_min.Text = Format(Val(Mid(biocide_week(4), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_venerdi_feed.Text = Format(Val(Mid(biocide_week(4), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(4), 11, 2)), "00")
            Else
                time_venerdi_feed.Text = Format(Val(Mid(biocide_week(4), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(4), 11, 2)), "00")
                If Val(Mid(biocide_week(4), 13, 1)) Then

                    time_venerdi_feed.Text = time_venerdi_feed.Text + " am"
                Else
                    time_venerdi_feed.Text = time_venerdi_feed.Text + " pm"

                End If
            End If
        Else
            check_venerdi.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_venerdi();"

        If Val(Mid(biocide_week(5), 3, 1)) Then
            check_sabato.Checked = True
            time_sabato_hr.Text = Format(Val(Mid(biocide_week(5), 5, 2)), "00")
            time_sabato_min.Text = Format(Val(Mid(biocide_week(5), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_sabato_feed.Text = Format(Val(Mid(biocide_week(5), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(5), 11, 2)), "00")
            Else
                time_sabato_feed.Text = Format(Val(Mid(biocide_week(5), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(5), 11, 2)), "00")
                If Val(Mid(biocide_week(5), 13, 1)) Then

                    time_sabato_feed.Text = time_sabato_feed.Text + " am"
                Else
                    time_sabato_feed.Text = time_sabato_feed.Text + " pm"

                End If
            End If
        Else
            check_sabato.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_sabato();"

        If Val(Mid(biocide_week(6), 3, 1)) Then
            check_domenica.Checked = True
            time_domenica_hr.Text = Format(Val(Mid(biocide_week(6), 5, 2)), "00")
            time_domenica_min.Text = Format(Val(Mid(biocide_week(6), 7, 2)), "00")

            If international_unit = "IS" Then 'formato italiano
                time_domenica_feed.Text = Format(Val(Mid(biocide_week(6), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(6), 11, 2)), "00")
            Else
                time_domenica_feed.Text = Format(Val(Mid(biocide_week(6), 9, 2)), "00") + ":" + Format(Val(Mid(biocide_week(6), 11, 2)), "00")
                If Val(Mid(biocide_week(6), 13, 1)) Then

                    time_domenica_feed.Text = time_domenica_feed.Text + " am"
                Else
                    time_domenica_feed.Text = time_domenica_feed.Text + " pm"

                End If
            End If
        Else
            check_domenica.Checked = False
        End If
        function_java = function_java + "manage_biocide1_week" + number_week + "_domenica();"
        Return function_java
        'java_script_variable.call_function_javascript_onload(Page, function_java)
    End Function
    Private Function create_biocide1(ByVal option_value As String, ByVal biocide1_value As String, ByVal SelectedMeasureUnit As String, ByVal version_str As String, _
                                ByVal full_scale_temp As Integer) As String
        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim java_script_variable As java_script = New java_script
        'Dim java_script_function As java_script = New java_script

        'Select Case Val(Mid(option_value, 36, 2))

        '    Case 1
        week1_enable.Visible = True
        Literal67.Visible = False
        week2_enable.Visible = True
        Literal95.Visible = False
        week3_enable.Visible = True
        Literal103.Visible = False
        week4_enable.Visible = True
        Literal118.Visible = False

        '    Case 2
        '        week1_enable.Visible = True
        '        Literal67.Visible = False
        '        week2_enable.Visible = True
        '        Literal95.Visible = False
        '        week3_enable.Visible = False
        '        Literal103.Visible = True
        '        week4_enable.Visible = False
        '        Literal108.Visible = True

        '    Case 3
        '        week1_enable.Visible = True
        '        Literal67.Visible = False
        '        week2_enable.Visible = True
        '        Literal95.Visible = False
        '        week3_enable.Visible = True
        '        Literal103.Visible = False
        '        week4_enable.Visible = False
        '        Literal108.Visible = True

        '    Case 4
        '        week1_enable.Visible = True
        '        Literal67.Visible = False
        '        week2_enable.Visible = True
        '        Literal95.Visible = False
        '        week3_enable.Visible = True
        '        Literal103.Visible = False
        '        week4_enable.Visible = True
        '        Literal108.Visible = False
        '    Case Else
        '        week1_enable.Visible = False
        '        Literal67.Visible = True
        '        week2_enable.Visible = False
        '        Literal95.Visible = True
        '        week3_enable.Visible = False
        '        Literal103.Visible = True
        '        week4_enable.Visible = False
        '        Literal108.Visible = True

        'End Select
        If SelectedMeasureUnit = "uS" Then
            Literal8.Text = "uS "
        Else
            Literal8.Text = "ppm "
        End If
        If InStr(version_str, "3.0.0") Or InStr(version_str, "3.0.1") Then
            If full_scale_temp = 30000 Then
                Literal8.Text = Literal8.Text + "0"
            End If
            set_variable_javascript(0, 0) = "max_us"
            set_variable_javascript(0, 1) = "3000"

        Else
            set_variable_javascript(0, 0) = "max_us"
            set_variable_javascript(0, 1) = "999"
        End If

        If Val(Mid(biocide1_value, 4, 1)) Then

            pre_bleed_time.Checked = True    'Time
            function_java = function_java + "pre_bleed_time_enable();"

        Else
            pre_bleed_us.Checked = True    'us
            function_java = function_java + "pre_bleed_us_enable();"
        End If

        value_pre_bleed_time_hr.Text = Format(Val(Mid(biocide1_value, 9, 2)), "00")       ' Time Hour
        value_pre_bleed_time_min.Text = Format(Val(Mid(biocide1_value, 11, 2)), "00")          ' Time Minute
        value_pre_bleed_us.Text = Format(Val(Mid(biocide1_value, 5, 4)), "0000")  ' uS Value

        value_pre_biocide_hr.Text = Format(Val(Mid(biocide1_value, 13, 2)), "00")          ' Prebiocide Hour
        value_pre_biocide_min.Text = Format(Val(Mid(biocide1_value, 15, 2)), "00")         ' Prebiocide Minute

        value_pre_lockout_hr.Text = Format(Val(Mid(biocide1_value, 17, 2)), "00")          ' LockOut Hour
        value_pre_lockout_min.Text = Format(Val(Mid(biocide1_value, 19, 2)), "00")          ' LockOut Minute

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)
        'java_script_function.call_function_javascript_onload(Page, function_java)
        Return function_java
    End Function
    Private Function MakeBiocide1() As String
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
        Risultato = Format(Siemens, "0") + Format(Time, "0") + Format(Val(value_pre_bleed_us.Text), "0000") + Format(Val(value_pre_bleed_time_hr.Text), "00") + Format(Val(value_pre_bleed_time_min.Text), "00") + Format(Val(value_pre_biocide_hr.Text), "00") + Format(Val(value_pre_biocide_min.Text), "00") + Format(Val(value_pre_lockout_hr.Text), "00") + Format(Val(value_pre_lockout_min.Text), "00")
        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bioc1wMT" + Risultato + "bioc1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bioc2wMT" + Risultato + "bioc2wend" & Chr(13)
    End Function
    Private Function MakeBiocide1Week1String() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As String
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)


        If biocide1_week1_lunedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_lunedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_lunedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week1_lunedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week1_lunedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week1_martedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_martedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_martedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_martedi_hr.Text), "00") + Format(Val(value_biocide1_week1_martedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_martedi_hr.Text), "00") + Format(Val(value_biocide1_week1_martedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If




        If biocide1_week1_mercoledi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_mercoledi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_mercoledi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week1_mercoledi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week1_mercoledi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week1_giovedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_giovedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_giovedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week1_giovedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week1_giovedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week1_venerdi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_venerdi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_venerdi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week1_venerdi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week1_venerdi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        If biocide1_week1_sabato.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_sabato_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_sabato_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_sabato_hr.Text), "00") + Format(Val(value_biocide1_week1_sabato_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_sabato_hr.Text), "00") + Format(Val(value_biocide1_week1_sabato_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week1_domenica.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week1_domenica_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week1_domenica_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_domenica_hr.Text), "00") + Format(Val(value_biocide1_week1_domenica_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week1_domenica_hr.Text), "00") + Format(Val(value_biocide1_week1_domenica_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w1w" + Risultato + "bi1w1wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w1w" + Risultato + "bi2w1wend" & Chr(13)

    End Function

    Private Function MakeBiocide1Week2String() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As String
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)


        If biocide1_week2_lunedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_lunedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_lunedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week2_lunedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week2_lunedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week2_martedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_martedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_martedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_martedi_hr.Text), "00") + Format(Val(value_biocide1_week2_martedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_martedi_hr.Text), "00") + Format(Val(value_biocide1_week2_martedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If




        If biocide1_week2_mercoledi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_mercoledi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_mercoledi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week2_mercoledi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week2_mercoledi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week2_giovedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_giovedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_giovedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week2_giovedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week2_giovedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week2_venerdi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_venerdi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_venerdi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week2_venerdi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week2_venerdi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        If biocide1_week2_sabato.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_sabato_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_sabato_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_sabato_hr.Text), "00") + Format(Val(value_biocide1_week2_sabato_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_sabato_hr.Text), "00") + Format(Val(value_biocide1_week2_sabato_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week2_domenica.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week2_domenica_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week2_domenica_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_domenica_hr.Text), "00") + Format(Val(value_biocide1_week2_domenica_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week2_domenica_hr.Text), "00") + Format(Val(value_biocide1_week2_domenica_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If
        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w2w" + Risultato + "bi1w2wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w2w" + Risultato + "bi2w2wend" & Chr(13)

    End Function

    Private Function MakeBiocide1Week3String() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As String
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)


        If biocide1_week3_lunedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_lunedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_lunedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week3_lunedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week3_lunedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week3_martedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_martedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_martedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_martedi_hr.Text), "00") + Format(Val(value_biocide1_week3_martedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_martedi_hr.Text), "00") + Format(Val(value_biocide1_week3_martedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If




        If biocide1_week3_mercoledi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_mercoledi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_mercoledi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week3_mercoledi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week3_mercoledi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week3_giovedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_giovedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_giovedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week3_giovedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week3_giovedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week3_venerdi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_venerdi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_venerdi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week3_venerdi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week3_venerdi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        If biocide1_week3_sabato.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_sabato_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_sabato_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_sabato_hr.Text), "00") + Format(Val(value_biocide1_week3_sabato_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_sabato_hr.Text), "00") + Format(Val(value_biocide1_week3_sabato_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week3_domenica.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week3_domenica_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week3_domenica_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_domenica_hr.Text), "00") + Format(Val(value_biocide1_week3_domenica_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week3_domenica_hr.Text), "00") + Format(Val(value_biocide1_week3_domenica_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        'Dim stato_server As Boolean
        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w3w" + Risultato + "bi1w3wend" & Chr(13))
        'Return stato_server
        Return id_485_impianto + "bi2w3w" + Risultato + "bi2w3wend" & Chr(13)
    End Function

    Private Function MakeBiocide1Week4String() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""


        Dim Enable As Integer
        Dim Disable As Integer
        Dim AM As Integer
        Dim PM As String
        Dim Risultato As String
        Dim data_temp As Date


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)

        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)


        If biocide1_week4_lunedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_lunedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_lunedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week4_lunedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = "MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_lunedi_hr.Text), "00") + Format(Val(value_biocide1_week4_lunedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week4_martedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_martedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_martedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_martedi_hr.Text), "00") + Format(Val(value_biocide1_week4_martedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_martedi_hr.Text), "00") + Format(Val(value_biocide1_week4_martedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If




        If biocide1_week4_mercoledi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_mercoledi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_mercoledi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week4_mercoledi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_mercoledi_hr.Text), "00") + Format(Val(value_biocide1_week4_mercoledi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week4_giovedi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_giovedi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_giovedi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week4_giovedi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_giovedi_hr.Text), "00") + Format(Val(value_biocide1_week4_giovedi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week4_venerdi.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_venerdi_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_venerdi_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week4_venerdi_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_venerdi_hr.Text), "00") + Format(Val(value_biocide1_week4_venerdi_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        If biocide1_week4_sabato.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_sabato_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_sabato_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_sabato_hr.Text), "00") + Format(Val(value_biocide1_week4_sabato_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_sabato_hr.Text), "00") + Format(Val(value_biocide1_week4_sabato_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If


        If biocide1_week4_domenica.Checked Then
            Enable = 1
            Disable = 0
            data_temp = Date.Parse(value_biocide1_week4_domenica_feed.Text)
        Else
            Enable = 0
            Disable = 1
            data_temp = Date.Parse("00:00")
        End If

        If InStr(value_biocide1_week4_domenica_feed.Text, "am") <> 0 Then
            AM = 1
            PM = 0
        Else
            AM = 0
            PM = 1
        End If

        If international_unit = "IS" Then 'formato italiano
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_domenica_hr.Text), "00") + Format(Val(value_biocide1_week4_domenica_min.Text), "00") + data_temp.ToString("HH") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        Else
            Risultato = Risultato + "#MT" + Format(Enable, "0") + Format(Disable, "0") + Format(Val(value_biocide1_week4_domenica_hr.Text), "00") + Format(Val(value_biocide1_week4_domenica_min.Text), "00") + data_temp.ToString("hh") + data_temp.ToString("mm") + Format(AM, "0") + Format(PM, "0")
        End If

        'Dim service As ServiceReference1.Service1SoapClient = New ServiceReference1.Service1SoapClient
        'stato_server = service.write_set_point(codice_general, id_485, id_485 + "bi1w4w" + Risultato + "bi1w4wend" & Chr(13))
        Return id_485_impianto + "bi2w4w" + Risultato + "bi2w4wend" & Chr(13)
        'Return stato_server

    End Function

    Protected Sub save_biocide1tower_new_Click(sender As Object, e As EventArgs) Handles save_biocide1tower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint1 As String = ""
        Dim new_setpoint2 As String = ""
        Dim new_setpoint3 As String = ""
        Dim new_setpoint4 As String = ""
        Dim new_setpoint5 As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint1 = MakeBiocide1()
        new_setpoint2 = MakeBiocide1Week1String()
        new_setpoint3 = MakeBiocide1Week2String()
        new_setpoint4 = MakeBiocide1Week3String()
        new_setpoint5 = MakeBiocide1Week4String()
        If local_connection Then ' connessione OK
            write_setpoint_new.web_setpoint_change_biocide(codice_impianto, id_485_impianto, new_setpoint1, new_setpoint2, new_setpoint3, new_setpoint4, new_setpoint5, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=3" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class

