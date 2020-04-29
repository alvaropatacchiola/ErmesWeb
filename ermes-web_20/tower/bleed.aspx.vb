Public Class bleed
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Shared sendbleeddelay As Boolean = False
    Private Sub bleed_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
     Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_bleed_tower(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub

    Public Sub posiziona_bleed_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable


        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim version_str As String
        Dim new_version As Boolean = False
        Dim numero_canali As Integer = 0

        Dim unit_value() As String
        Dim config_value() As String
        Dim bleed_value() As String
        Dim full_scale_temp As Integer = 0
        Dim MTower_Type As String = ""

        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim personalizzazione_aquacare As Integer

        ' abilito pulsante modifica
        save_bleedtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_bleedtower_new, ""))
        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        unit_value = main_function.get_split_str(riga_strumento.value1)
        config_value = main_function.get_split_str(riga_strumento.value4)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)
        bleed_value = main_function.get_split_str(riga_strumento.value13)
        new_version = main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)
        numero_canali = MTower_Type.Split("_").Length

        If personalizzazione_aquacare = 1 Or numero_canali < 3 Then
            sendbleeddelay = True
        End If

        full_scale_temp = Session("scala_temp")
        If measure_unit = "uS" Then
            Literal4.Text = Literal4.Text + "uS "
            Literal1.Text = Literal1.Text + "uS "
        Else
            Literal4.Text = Literal4.Text + "ppm "
            Literal1.Text = Literal1.Text + "ppm "

        End If
        If InStr(version_str, "3.0.0") Or InStr(version_str, "3.0.1") Then

            If full_scale_temp = 30000 Then
                Literal4.Text = Literal4.Text + "0"
                Literal1.Text = Literal1.Text + "0"
                set_variable_javascript(0, 0) = "max_us"
                set_variable_javascript(0, 1) = "30000"
            Else
                set_variable_javascript(0, 0) = "max_us"
                set_variable_javascript(0, 1) = "3000"
            End If
        Else
            set_variable_javascript(0, 0) = "max_us"
            set_variable_javascript(0, 1) = "9999"

        End If
        If full_scale_temp = 30000 Then
            value_bleed_setpoint.Text = Format(Val(Mid(bleed_value(0), 3, 4)) * 10, "0000")
        Else
            value_bleed_setpoint.Text = Format(Val(Mid(bleed_value(0), 3, 4)), "0000")
        End If

        Dim Sign As Integer
        Dim DeadBandValue As Integer

        Sign = Val(Mid(bleed_value(0), 7, 1))
        DeadBandValue = Val(Mid(bleed_value(0), 8, 3))

        If Sign Then ' positivo
            value_bleed_deadband.Text = Format(Val(Mid(bleed_value(0), 8, 3)), "0000")
        Else ' negativo
            DeadBandValue = DeadBandValue * -1
            value_bleed_deadband.Text = Format(DeadBandValue, "0000")
        End If
        If full_scale_temp = 30000 Then
            value_bleed_deadband.Text = value_bleed_deadband.Text + "0"
        End If
        value_bleed_time_limit_hr.Text = Format(Val(Mid(bleed_value(0), 11, 2)), "00")
        value_bleed_time_limit_min.Text = Format(Val(Mid(bleed_value(0), 13, 2)), "00")

        aquacare.Visible = sendbleeddelay
        If aquacare.Visible Then
            value_bleed_delay_hr.Text = Format(Val(Mid(bleed_value(0), 15, 2)), "00")
            value_bleed_delay_min.Text = Format(Val(Mid(bleed_value(0), 17, 2)), "00")
        End If

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)

    End Sub
    Private Function MakeBleed() As String
        Dim risultato As String = ""
        Dim Sign As Integer
        Dim DeadBandValue As Integer
        Dim bleedValue As Integer
        Dim full_scale_temp As Integer = 0
        full_scale_temp = Session("scala_temp")

        If Val(value_bleed_deadband.Text) > 0 Then
            Sign = 1
            DeadBandValue = Val(value_bleed_deadband.Text)
        Else
            Sign = 0
            DeadBandValue = Val(value_bleed_deadband.Text) * -1
        End If
        bleedValue = Val(value_bleed_setpoint.Text)
        If full_scale_temp = 30000 Then
            DeadBandValue = DeadBandValue / 10
            bleedValue = bleedValue / 10
        End If
        'If Session("Aquacare") = 1 Then
        '    risultato = "MT" + Format(ASPxSpinEdit120.Value, "0000") + Format(Sign, "0") + Format(DeadBandValue, "000") + Format(ASPxSpinEdit123.Value, "00") + Format(ASPxSpinEdit124.Value, "00") + Format(ASPxSpinEdit125.Value, "00") + Format(ASPxSpinEdit126.Value, "00")
        'Else
        If aquacare.Visible Then
            risultato = "MT" + Format(bleedValue, "0000") + Format(Sign, "0") + Format(DeadBandValue, "000") + Format(Val(value_bleed_time_limit_hr.Text), "00") + Format(Val(value_bleed_time_limit_min.Text), "00") + Format(Val(value_bleed_delay_hr.Text), "00") + Format(Val(value_bleed_delay_min.Text), "00")
        Else
            risultato = "MT" + Format(bleedValue, "0000") + Format(Sign, "0") + Format(DeadBandValue, "000") + Format(Val(value_bleed_time_limit_hr.Text), "00") + Format(Val(value_bleed_time_limit_min.Text), "00")
        End If

        'End If

        Return id_485_impianto + "bleedw" + risultato + "bleedwend" & Chr(13)

    End Function

    Protected Sub save_bleedtower_new_Click(sender As Object, e As EventArgs) Handles save_bleedtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeBleed()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=4" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class