Public Class setpoint_ch3
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub setpoint_ch3_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
      Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_setpoint_ch3_tower(nome_impianto, codice_impianto, id_485_impianto, canale, "Sepoint")
        End If
    End Sub
    Public Sub posiziona_setpoint_ch3_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable


        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim version_str As String

        Dim unit_value() As String
        Dim setpoint2_value() As String
        Dim config_value() As String

        Dim full_scale_temp As Integer = 0
        Dim fattore_divisione_temp As Integer = 0
        Dim label_canale_temp As String = ""
        Dim etichettasetpoint As String = ""

        Dim set_variable_javascript(2, 1) As String
        Dim function_java As String = ""
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim MTower_Type As String = ""
        Dim personalizzazione_aquacare As Integer
        ' abilito pulsante modifica
        save_setpointtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointtower_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        setpoint2_value = main_function.get_split_str(riga_strumento.value28)
        config_value = main_function.get_split_str(riga_strumento.value4)


        If Val(Mid(setpoint2_value(0), 3, 1)) Then        'D1 On/Off
            on_off_setpoint_ch2.Checked = True
            function_java = function_java + "enable_sepoint_on_off();"

        End If

        If Val(Mid(setpoint2_value(0), 4, 1)) Then        'D1 Pwm
            function_java = function_java + "enable_sepoint_pwm();"
            pwm_setpoint_ch2.Checked = True

        End If

        If Val(Mid(setpoint2_value(0), 5, 1)) Then        'D1 Disable
            function_java = function_java + "disable_sepoint_on_off();"
            disable_setpoint_ch2.Checked = True
        End If

        If Val(Mid(setpoint2_value(0), 6, 1)) Then        'P1 Enable
            function_java = function_java + "enable_sepoint_proportional();"
            enable_setpoint_p1_ch2.Checked = True

        End If

        If Val(Mid(setpoint2_value(0), 7, 1)) Then        'P1 Disable
            function_java = function_java + "disable_sepoint_proportional();"
            disable_setpoint_p1_ch2.Checked = True

        End If

        If Val(Mid(setpoint2_value(0), 8, 1)) Then        'Constant 
            work_constant.Checked = True
        End If

        If Val(Mid(setpoint2_value(0), 9, 1)) Then        'Timer Biocide 1 
            work_timer_biocide.Checked = True
        End If

        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , _
                                                      , fattore_divisione_temp, , , full_scale_temp, , , label_canale_temp, , etichettasetpoint)
        'If MTower_Type = "" Then

        'End If

        Dim value As Single = 0

        set_variable_javascript(0, 0) = "max_ch_value"
        set_variable_javascript(0, 1) = full_scale_temp.ToString
        set_variable_javascript(1, 0) = "min_ch_value"
        set_variable_javascript(1, 1) = "0"
        set_variable_javascript(2, 0) = "max_fix_value"
        set_variable_javascript(2, 1) = main_function.set_fullscale(full_scale_temp).ToString

        message_channel.Text = setpoint_traduzione + " Ch3 " + label_canale_temp
        Literal5.Text = etichettasetpoint
        Literal4.Text = Literal4.Text + etichettasetpoint
        Literal8.Text = etichettasetpoint
        Literal7.Text = Literal7.Text + etichettasetpoint
        Literal13.Text = etichettasetpoint
        Literal15.Text = etichettasetpoint
        If Val(Mid(setpoint2_value(0), 3, 1)) Then        'D1 On/Off
            value = Val(Mid(setpoint2_value(0), 10, 4)) / fattore_divisione_temp '  on/off stp_on
            value_setpoint_on.Text = Replace(value.ToString(), ",", ".")
            value = Val(Mid(setpoint2_value(0), 14, 4)) / fattore_divisione_temp '  on/off stp_off
            value_setpoint_off.Text = Replace(value.ToString(), ",", ".")
        End If
        If Val(Mid(setpoint2_value(0), 4, 1)) Then        'D1 Pwm
            value = Val(Mid(setpoint2_value(0), 18, 4)) / fattore_divisione_temp '  pwm stp_1st
            value_setpoint_on.Text = Replace(value.ToString(), ",", ".")

            value = Val(Mid(setpoint2_value(0), 22, 4)) / fattore_divisione_temp '  pwm stp_2nd
            value_setpoint_off.Text = Replace(value.ToString(), ",", ".")
        End If

        value_setpoint_on_percent.Text = Format(Val(Mid(setpoint2_value(0), 26, 3)), "000") '  pwm perc_1st
        value_setpoint_off_percent.Text = Format(Val(Mid(setpoint2_value(0), 29, 3)), "000") '  pwm perc_2nd

        value = Val(Mid(setpoint2_value(0), 32, 4)) / fattore_divisione_temp '  p1 stp_1st
        value_setpoint_p1_1.Text = Replace(value.ToString(), ",", ".")
        value = Val(Mid(setpoint2_value(0), 36, 4)) / fattore_divisione_temp '  p1 stp_2nd
        value_setpoint_p1_2.Text = Replace(value.ToString(), ",", ".")

        value_setpoint_p1_1_pm.Text = Format(Val(Mid(setpoint2_value(0), 40, 3)), "000") '  p1 perc_1st
        value_setpoint_p1_2_pm.Text = Format(Val(Mid(setpoint2_value(0), 43, 3)), "000")

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 2)
        java_script_function.call_function_javascript_onload(Page, function_java)
    End Sub
    Private Function MakeDataSetpoint() As String

        Dim Risultato As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim version_str As String

        Dim config_value() As String
        Dim fattore_divisione_temp As Integer = 0
        Dim personalizzazione_aquacare As Integer

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        config_value = main_function.get_split_str(riga_strumento.value4)
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)

        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , fattore_divisione_temp)

        If on_off_setpoint_ch2.Checked Then        'On/Off
            Risultato = "1"
        Else
            Risultato = "0"
        End If

        If pwm_setpoint_ch2.Checked Then        'Pwm
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If disable_setpoint_ch2.Checked Then        'Disable D1
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If enable_setpoint_p1_ch2.Checked Then        'Enable P1
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If


        If disable_setpoint_p1_ch2.Checked Then        'Disable P1
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If work_constant.Checked Then        'Constant
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        If work_timer_biocide.Checked Then        'Timer 
            Risultato = Risultato + "1"
        Else
            Risultato = Risultato + "0"
        End If

        Risultato = Risultato + Format(Val(value_setpoint_on.Text) * fattore_divisione_temp, "0000") + Format(Val(value_setpoint_off.Text) * fattore_divisione_temp, "0000")   'On/Off
        Risultato = Risultato + Format(Val(value_setpoint_on.Text) * fattore_divisione_temp, "0000") + Format(Val(value_setpoint_off.Text) * fattore_divisione_temp, "0000") + Format(Val(value_setpoint_on_percent.Text), "000") + Format(Val(value_setpoint_off_percent.Text), "000")   'Pwm
        Risultato = Risultato + Format(Val(value_setpoint_p1_1.Text) * fattore_divisione_temp, "0000") + Format(Val(value_setpoint_p1_2.Text) * fattore_divisione_temp, "0000") + Format(Val(value_setpoint_p1_1_pm.Text), "000") + Format(Val(value_setpoint_p1_2_pm.Text), "000")  'P1




        Return id_485_impianto + "setp3wMT" + Risultato + "setp3wend" & Chr(13)


    End Function
    Protected Sub save_setpointtower_new_Click(sender As Object, e As EventArgs) Handles save_setpointtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeDataSetpoint()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=6" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class