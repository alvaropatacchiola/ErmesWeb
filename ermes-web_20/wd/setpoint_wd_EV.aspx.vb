Public Class setpoint_wd_EV
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
            posiziona_setpoint_wd(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "setpoint"))
        End If
    End Sub
    Public Sub posiziona_setpoint_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
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
        save_setpointwd_EV_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointwd_EV_new, ""))


        data_sp = main_function.get_split_str(riga_strumento.value7)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        Dim ch1_pulse1_mode As String = Mid(data_sp(6), 1, 1) ' 0-> on/off 1-> prop 2-> OFF


        Dim ch2_pulse_mode As String = Mid(data_sp(12), 1, 1) ' 0-> on/off 1-> prop 2-> OFF
        Dim ch2_relay_mode As String = Mid(data_sp(17), 1, 1) ' 0-> prop PWM 
        function_java = ""
        Select Case ch1_pulse1_mode
            'Case "2" 'off
            '    function_java = function_java + "disable_channel_ph_pulse1();"
            '    'java_script_ch1_pulse1.call_function_javascript_onload(Page, "disable_channel_ph_pulse1()")
            '    off_ph_pulse1.Checked = True
            Case "0" 'on/off
                function_java = function_java + "enable_channel_ph_pulse1_on_off();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_on_off()")
                on_off_ph_pulse1.Checked = True
            Case "1" 'proportianal
                function_java = function_java + "enable_channel_ph_pulse1_proportional();"
                'java_script_ch1_pulse1.call_function_javascript_onload(Page, "enable_channel_ph_pulse1_proportional()")
                proportional_ph_pulse1.Checked = True
        End Select

        
        Select Case ch2_pulse_mode
            'Case "2" 'off
            '    function_java = function_java + "disable_channel_cl_pulse1();"
            '    'java_script_ch1_pulse3.call_function_javascript_onload(Page, "disable_channel_cl_pulse1()")
            '    off_cl_pulse1.Checked = True
            Case "0" 'on/off
                function_java = function_java + "enable_channel_cl_pulse1_on_off();"
                'java_script_ch1_pulse3.call_function_javascript_onload(Page, "enable_channel_cl_pulse1_on_off()")
                on_off_cl_pulse1.Checked = True
            Case "1" 'proportianal
                function_java = function_java + "enable_channel_cl_pulse1_proportional();"
                'java_script_ch1_pulse3.call_function_javascript_onload(Page, "enable_channel_cl_pulse1_proportional()")
                proportional_cl_pulse1.Checked = True
        End Select
       
        Select Case ch2_relay_mode
            'Case "3" 'off
            '    function_java = function_java + "disable_channel_cl_relay();"
            '    'java_script_ch1_pulse5.call_function_javascript_onload(Page, "disable_channel_cl_relay()")
            '    off_cl_relay.Checked = True
            Case "0" 'proportional pwm
                function_java = function_java + "enable_channel_cl_relay_proportionalpwm();"
                'java_script_ch1_pulse5.call_function_javascript_onload(Page, "enable_channel_cl_relay_proportionalpwm()")
                proportional_cl_relay.Checked = True
            Case "1" 'on/off
                function_java = function_java + "enable_channel_cl_relay_on_off();"
                'java_script_ch1_pulse5.call_function_javascript_onload(Page, "enable_channel_cl_relay_on_off()")
                on_off_cl_relay.Checked = True
                'Case "2" 'fixed
                '    function_java = function_java + "enable_channel_cl_relay_fixedpwm();"
                '    'java_script_ch1_pulse5.call_function_javascript_onload(Page, "enable_channel_cl_relay_fixedpwm()")
                '    fixed_cl_relay.Checked = True
        End Select

        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        'label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)
        label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)


        tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
        

        tabld1_4.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
        tabld1_5.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "relay")




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
        set_variable_javascript(5, 1) = set_fullscale(full_scale_temp2).ToString

        java_script_ch1_pulse_variable.set_url_setpoint(Page, set_variable_javascript, 5)
        java_script_ch1_pulse1.call_function_javascript_onload(Page, function_java)
        'setting_label_setpoint(etichetta_setpoint, "", GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("wd_global", "pulseminute"), GetLocalResourceObject("Literal18Resource1.Text"), Label7, Literal1, Literal6, Literal3, Literal2, Literal7, Literal4, Literal5, label_canale_temp)
        'setting_label_setpoint(etichetta_setpoint, "", GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("wd_global", "pulseminute"), GetLocalResourceObject("Literal18Resource1.Text"), Literal8, Literal12, Literal13, Literal14, Literal15, Literal16, Literal17, Literal18, label_canale_temp)
        'setting_label_setpoint(etichetta_setpoint2, "", GetGlobalResourceObject("ld_global", "pulse"), GetLocalResourceObject("Literal14Resource1.Text"), GetLocalResourceObject("Literal18Resource1.Text"), Literal10, Literal29, Literal30, Literal31, Literal32, Literal33, Literal34, Literal35, label_canale2_temp)

        'setting_label_setpoint_relay(etichetta_setpoint, GetGlobalResourceObject("ld_global", "relay"), Literal9, Literal21, Literal22, Literal23, Literal24, Literal25, Literal26, Literal27, Literal28, label_canale_temp)
        'setting_label_setpoint_relay(etichetta_setpoint2, GetGlobalResourceObject("ld_global", "relay"), Literal11, Literal38, Literal39, Literal40, Literal41, Literal42, Literal43, Literal44, Literal45, label_canale2_temp)


        setting_label_setpoint(etichetta_setpoint, " ", GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("wd_global", "pulseminute"), GetLocalResourceObject("Literal10Resource1.Text"), Label7, Literal4, Literal6, Literal7, Literal7, Literal8, Literal10, Literal10, label_canale_temp)
        setting_label_setpoint(etichetta_setpoint2, " ", GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("wd_global", "pulseminute"), GetLocalResourceObject("Literal10Resource1.Text"), Literal35, Literal39, Literal40, Literal42, Literal42, Literal43, Literal45, Literal45, label_canale2_temp)


        setting_label_setpoint_relay(etichetta_setpoint2, GetGlobalResourceObject("ld_global", "relay"), Literal46, Literal51, Literal52, Literal52, Literal53, Literal55, Literal56, Literal57, Literal52, label_canale2_temp)


        Dim temp_calc As Single = Val(Mid(data_sp(1), 1, 4)) / fattore_divisione_temp 'on
        value1_ph_pulse1_1.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(data_sp(2), 1, 4)) / fattore_divisione_temp 'on
        value1_ph_pulse1_2.Text = Replace(temp_calc.ToString(), ",", ".")

       
        temp_calc = Val(Mid(data_sp(7), 1, 4)) / fattore_divisione_temp2 'on
        value1_cl_pulse1_1.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(data_sp(8), 1, 4)) / fattore_divisione_temp2 'on
        value1_cl_pulse1_2.Text = Replace(temp_calc.ToString(), ",", ".")

        temp_calc = Val(Mid(data_sp(13), 1, 4)) / fattore_divisione_temp2 'on
        value1_cl_relay_1.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = Val(Mid(data_sp(14), 1, 4)) / fattore_divisione_temp2 'on
        value1_cl_relay_2.Text = Replace(temp_calc.ToString(), ",", ".")

        value2_ph_pulse1_1.Text = Format(Val(Mid(data_sp(3), 1, 3)), "000")
        value2_ph_pulse1_2.Text = Format(Val(Mid(data_sp(4), 1, 3)), "000")

       

        value2_cl_pulse1_1.Text = Format(Val(Mid(data_sp(9), 1, 3)), "000")
        value2_cl_pulse1_2.Text = Format(Val(Mid(data_sp(10), 1, 3)), "000")

        value2_cl_relay_1.Text = Format(Val(Mid(data_sp(15), 1, 3)), "000")
        value2_cl_relay_2.Text = Format(Val(Mid(data_sp(16), 1, 3)), "000")

        Dim ch1_pulse1_att As Integer = Val(Mid(data_sp(5), 1, 2))

        Dim ch2_pulse_att As Integer = Val(Mid(data_sp(11), 1, 2))


        If ch1_pulse1_att = 0 Then
            ch1_pulse1_att = 1
        End If



        If ch2_pulse_att = 0 Then
            ch2_pulse_att = 1
        End If


        value2_ph_pulse1_3.Text = Format(ch1_pulse1_att, "00")

        value2_cl_pulse1_3.Text = Format(ch2_pulse_att, "00")


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
                                      ByVal Literal5 As Literal, ByVal Literal6 As Literal, ByVal LiteralTipo As String)
        literal1.Text = LiteralTipo + " " + traduzione_pulse + " " + numero_canale
        Literal2.Text = etichetta_setpoint
        Literal2_1.Text = etichetta_setpoint + " ON"
        Literal3.Text = " %" 'traduzione_pulse_minute
        Literal4.Text = etichetta_setpoint
        Literal4_1.Text = etichetta_setpoint + " OFF"
        Literal5.Text = " %" 'traduzione_pulse_minute
        Literal6.Text = traduzione_pulse_speed
    End Sub
    Private Sub setting_label_setpoint_relay(ByVal etichetta_setpoint As String, ByVal traduzione_relay As String, ByVal literal1 As Literal, _
                                       ByVal Literal2 As Literal, ByVal Literal2_1 As Literal, ByVal Literal3 As Literal, ByVal Literal3_1 As Literal, ByVal Literal4 As Literal, _
                                           ByVal Literal4_1 As Literal, ByVal Literal5 As Literal, ByVal Literal5_1 As Literal, ByVal LiteralTipo As String)
        '    literal1.Text = etichetta_setpoint + " " + traduzione_relay
        '    Literal2.Text = etichetta_setpoint
        '    Literal2_1.Text = etichetta_setpoint + " ON"
        '    Literal3.Text = "%"
        '    Literal3_1.Text = "sec"
        '    Literal4.Text = etichetta_setpoint
        '    Literal4_1.Text = etichetta_setpoint + " OFF"
        '    Literal5.Text = "%"
        '    Literal5_1.Text = "sec"


        literal1.Text = LiteralTipo + " " + traduzione_relay
        Literal2.Text = etichetta_setpoint
        Literal2_1.Text = etichetta_setpoint + " ON"
        Literal3.Text = etichetta_setpoint + " ON"
        Literal3_1.Text = "%"

        Literal4.Text = etichetta_setpoint
        Literal4_1.Text = etichetta_setpoint + " OFF"
        Literal5.Text = "%"
        'Literal5_1.Text = " "



    End Sub
    
    Protected Sub save_setpointwd_new_Click(sender As Object, e As EventArgs) Handles save_setpointwd_EV_new.Click
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

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=14" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub




    Private Function MakeSETString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0


        Dim app_ch1_pulse1_mode As String


        Dim app_ch2_pulse_mode As String
        Dim app_ch2_relay_mode As String

        Dim app_ch1_pulse1_val1 As String
        Dim app_ch1_pulse1_val2 As String

       

        Dim app_ch2_pulse_val1 As String
        Dim app_ch2_pulse_val2 As String

        Dim app_ch2_relay_val1 As String
        Dim app_ch2_relay_val2 As String


        Dim app_ch1_pulse1_val1_i As Integer
        Dim app_ch1_pulse1_val2_i As Integer

     
        Dim app_ch2_pulse_val1_i As Integer
        Dim app_ch2_pulse_val2_i As Integer

        Dim app_ch2_relay_val1_i As Integer
        Dim app_ch2_relay_val2_i As Integer


        Dim app_ch1_pulse1_perc1 As String
        Dim app_ch1_pulse1_perc2 As String

     
        Dim app_ch2_pulse_perc1 As String
        Dim app_ch2_pulse_perc2 As String

        Dim app_ch2_relay_perc1 As String
        Dim app_ch2_relay_perc2 As String

        Dim app_ch1_pulse1_att As String

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

       

        If on_off_cl_pulse1.Checked = True Then 'on/off
            app_ch2_pulse_mode = "0"
        End If

        If proportional_cl_pulse1.Checked = True Then 'prop
            app_ch2_pulse_mode = "1"
        End If

       



       


        If on_off_cl_relay.Checked = True Then 'on/off
            app_ch2_relay_mode = "1"
        End If

        If proportional_cl_relay.Checked = True Then 'proportional pwm
            app_ch2_relay_mode = "0"
        End If

       


        If app_ch1_pulse1_mode <> "0" And Val(value2_ph_pulse1_3.Text) = 0 Then ' no on off
            value2_ph_pulse1_3.Text = "1"
        End If
       
        If app_ch2_pulse_mode <> "0" And Val(value2_cl_pulse1_3.Text) = 0 Then ' no on off
            value2_cl_pulse1_3.Text = "1"
        End If

        If app_ch1_pulse1_mode = "0" Then '  on off
            value2_ph_pulse1_1.Text = "100"
            value2_ph_pulse1_2.Text = "0"
        End If
      
        If app_ch2_pulse_mode = "0" Then '  on off
            value2_cl_pulse1_1.Text = "100"
            value2_cl_pulse1_2.Text = "0"
        End If
      
        If app_ch2_relay_mode = "1" Then '  on off
            value2_cl_relay_1.Text = "100"
            value2_cl_relay_2.Text = "0"
        End If




        Dim fattore_ch1 As Integer
        Dim fattore_ch2 As Integer


        'main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
        main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1), fattore_divisione_temp)
        'main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2)
        main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(2), fattore_divisione_temp2)



        app_ch1_pulse1_val1_i = Val(value1_ph_pulse1_1.Text) * fattore_divisione_temp
        app_ch1_pulse1_val2_i = Val(value1_ph_pulse1_2.Text) * fattore_divisione_temp

       


        app_ch2_pulse_val1_i = Val(value1_cl_pulse1_1.Text) * fattore_divisione_temp2
        app_ch2_pulse_val2_i = Val(value1_cl_pulse1_2.Text) * fattore_divisione_temp2

        app_ch2_relay_val1_i = Val(value1_cl_relay_1.Text) * fattore_divisione_temp2
        app_ch2_relay_val2_i = Val(value1_cl_relay_2.Text) * fattore_divisione_temp2


        app_ch1_pulse1_val1 = Format(app_ch1_pulse1_val1_i, "0000")
        app_ch1_pulse1_val2 = Format(app_ch1_pulse1_val2_i, "0000")

      


        app_ch2_pulse_val1 = Format(app_ch2_pulse_val1_i, "0000")
        app_ch2_pulse_val2 = Format(app_ch2_pulse_val2_i, "0000")

        app_ch2_relay_val1 = Format(app_ch2_relay_val1_i, "0000")
        app_ch2_relay_val2 = Format(app_ch2_relay_val2_i, "0000")


        app_ch1_pulse1_perc1 = Format(Val(value2_ph_pulse1_1.Text), "000")
        app_ch1_pulse1_perc2 = Format(Val(value2_ph_pulse1_2.Text), "000")
       
        app_ch2_pulse_perc1 = Format(Val(value2_cl_pulse1_1.Text), "000")
        app_ch2_pulse_perc2 = Format(Val(value2_cl_pulse1_2.Text), "000")
        app_ch2_relay_perc1 = Format(Val(value2_cl_relay_1.Text), "000")
        app_ch2_relay_perc2 = Format(Val(value2_cl_relay_2.Text), "000")


        app_ch1_pulse1_att = Format(Val(value2_ph_pulse1_3.Text), "00")

        app_ch2_pulse_att = Format(Val(value2_cl_pulse1_3.Text), "00")


        Risultato = app_ch1_pulse1_val1 + app_ch1_pulse1_val2 + app_ch1_pulse1_perc1 + app_ch1_pulse1_perc2 + app_ch1_pulse1_att + app_ch1_pulse1_mode + app_ch2_pulse_val1 + app_ch2_pulse_val2 + app_ch2_pulse_perc1 + app_ch2_pulse_perc2 + app_ch2_pulse_att + app_ch2_pulse_mode + app_ch2_relay_val1 + app_ch2_relay_val2 + app_ch2_relay_perc1 + app_ch2_relay_perc2 + app_ch2_relay_mode



        Return id_485_impianto + "setpnw" + Risultato + "setpnwend" & Chr(13)
    End Function


End Class