Public Class ma_outputs
    Inherits lingua

    
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub ma_outputs_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
       Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_ma_lds(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "max_ma"), GetGlobalResourceObject("ld_global", "min_ma"), GetGlobalResourceObject("ld_global", "min_temperature"), GetGlobalResourceObject("ld_global", "max_temperature"))
        End If

    End Sub
    Public Sub posiziona_ma_lds(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                          ByVal setpoint_traduzione As String, ByVal traduzione_max_ma As String, ByVal traduzione_min_ma As String, ByVal traduzione_temperature_ma_min As String, _
                           ByVal traduzione_temperature_ma_max As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim set_variable_javascript(5, 1) As String
        Dim config_value() As String
        Dim maoutstr_value() As String
        Dim calibrz_value() As String
        Dim valuer_value() As String

        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim full_scale_temp As Single
        Dim etichetta_setpoint As String = ""
        Dim temp_calc As Single
        Dim formato_d As String

        Dim java_script_ma1 As java_script = New java_script
        ' abilito pulsante modifica
        save_maoutputlds_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_maoutputlds_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        maoutstr_value = main_function.get_split_str(riga_strumento.value14)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)

        formato_d = Mid(valuer_value(3), 1, 1)

        Dim mode_ch1 As String
        Dim mode_ch2 As String
        Dim mode_ch3 As String

        Dim mode_temp As String

        Dim Max_ch2 As String
        Dim min_ch2 As String


        Dim Max_temp As String
        Dim min_temp As String


        mode_ch2 = Mid(maoutstr_value(1), 1, 1)
        mode_temp = Mid(maoutstr_value(4), 1, 1)

       
        If mode_ch2 = "0" Then '0/20mA
            cl_0_20.Checked = True
        End If
        If mode_ch2 = "1" Then '4/20mA
            cl_4_20.Checked = True
        End If
        If mode_temp = "0" Then '0/20mA
            temperature_0_20.Checked = True
        End If
        If mode_temp = "1" Then '4/20mA
            temperature_4_20.Checked = True
        End If

        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        Max_ch2 = Mid(maoutstr_value(2), 1, 4)
        min_ch2 = Mid(maoutstr_value(3), 1, 4)
        temp_calc = Max_ch2 / fattore_divisione_temp 'on
        value_cl_ma_max.Text = Replace(temp_calc.ToString(), ",", ".")
        temp_calc = min_ch2 / fattore_divisione_temp 'on
        value_cl_ma_min.Text = Replace(temp_calc.ToString(), ",", ".")
        set_variable_javascript(0, 0) = "max_cl_value"
        set_variable_javascript(0, 1) = full_scale_temp.ToString
        set_variable_javascript(1, 0) = "min_cl_value"
        set_variable_javascript(1, 1) = "0"
        set_variable_javascript(2, 0) = "max_fix_value_cl"
        set_variable_javascript(2, 1) = set_fullscale(full_scale_temp).ToString
        Literal1.Text = label_canale_temp + " mA"
        Literal5.Text = traduzione_max_ma + " " + etichetta_setpoint
        Literal6.Text = traduzione_min_ma + " " + etichetta_setpoint
        'tabld1_2.Text = label_canale_temp
        tabld1_1.Text = label_canale_temp

        Max_temp = Mid(maoutstr_value(5), 1, 3)
        min_temp = Mid(maoutstr_value(6), 1, 3)
        If formato_d = "0" Then ' europeo
            temp_calc = Val(Max_temp) / 10 'on
            value_temperature_ma_max.Text = Replace(temp_calc.ToString(), ",", ".")
            temp_calc = Val(min_temp) / 10 'on
            value_temperature_ma_min.Text = Replace(temp_calc.ToString(), ",", ".")
            set_variable_javascript(3, 0) = "max_temperature_value"
            set_variable_javascript(3, 1) = "99.9"
            set_variable_javascript(4, 0) = "min_temperature_value"
            set_variable_javascript(4, 1) = "0"
            set_variable_javascript(5, 0) = "max_fix_value_temperature"
            set_variable_javascript(5, 1) = "1"
            Literal9.Text = traduzione_temperature_ma_max + "" + "°C"
            Literal10.Text = traduzione_temperature_ma_min + "" + "°C"
        End If
        If formato_d = "1" Then ' americano
            Dim app_int As Integer
            app_int = Val(Max_temp)
            If app_int > 210 Then
                value_temperature_ma_max.Text = "210"
            Else
                value_temperature_ma_max.Text = Val(Max_temp).ToString
            End If
            app_int = Val(min_temp)
            If app_int > 210 Then
                value_temperature_ma_min.Text = "210"
            Else
                app_int = Val(min_temp)
                If app_int > 32 Then
                    value_temperature_ma_min.Text = Val(min_temp).ToString
                Else
                    value_temperature_ma_min.Text = " 32"
                End If
            End If
            set_variable_javascript(3, 0) = "max_temperature_value"
            set_variable_javascript(3, 1) = "210"
            set_variable_javascript(4, 0) = "min_temperature_value"
            set_variable_javascript(4, 1) = "32"
            set_variable_javascript(5, 0) = "max_fix_value_temperature"
            set_variable_javascript(5, 1) = "0"
            Literal9.Text = traduzione_temperature_ma_max + "" + "°F"
            Literal10.Text = traduzione_temperature_ma_min + "" + "°F"
        End If
        java_script_ma1.set_url_setpoint(Page, set_variable_javascript, 5)
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
    Private Function MakeMAString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim config_value() As String
        Dim calibrz_value() As String
        Dim fattore_divisione_temp As Integer = 0
        Dim valuer_value() As String
        Dim formato_d As String

        Dim Risultato As String
        Dim app_mode_ch1 As String

        Dim app_mode_temp As String

        Dim app_max_ch1 As Integer
        Dim app_min_ch1 As Integer


        Dim app_max_temp As Integer
        Dim app_min_temp As Integer


        Dim app_max_ch1_s As String
        Dim app_min_ch1_s As String



        Dim app_max_temp_s As String
        Dim app_min_temp_s As String


     

        If cl_0_20.Checked = True Then '0/20 ch2
            app_mode_ch1 = "0"
        End If
        If cl_4_20.Checked = True Then '4/20 ch2
            app_mode_ch1 = "1"
        End If

        If temperature_0_20.Checked = True Then '0/20 temp
            app_mode_temp = "0"
        End If
        If temperature_4_20.Checked = True Then '4/20 temp
            app_mode_temp = "1"
        End If

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)

     

        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)

        app_max_ch1 = Val(value_cl_ma_max.Text) * fattore_divisione_temp
        app_min_ch1 = Val(value_cl_ma_min.Text) * fattore_divisione_temp
        app_max_ch1_s = Format(app_max_ch1, "0000")
        app_min_ch1_s = Format(app_min_ch1, "0000")


        formato_d = Mid(valuer_value(4), 1, 1)

        If Val(formato_d) = 1 Then ' americano
            app_max_temp = Val(value_temperature_ma_max.Text)
            app_min_temp = Val(value_temperature_ma_min.Text)
        End If

        If Val(formato_d) = 0 Then ' europeo
            app_max_temp = Val(value_temperature_ma_max.Text) * 10
            app_min_temp = Val(value_temperature_ma_min.Text) * 10
        End If

        app_max_temp_s = Format(app_max_temp, "000")
        app_min_temp_s = Format(app_min_temp, "000")

        Risultato = app_mode_ch1 + app_max_ch1_s + app_min_ch1_s + app_mode_temp + app_max_temp_s + app_min_temp_s

        Return id_485_impianto + "maoutw" + Risultato + "maoutwend" & Chr(13)

    End Function
    Protected Sub save_maoutputlds_new_Click(sender As Object, e As EventArgs) Handles save_maoutputlds_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeMAString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=2" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class