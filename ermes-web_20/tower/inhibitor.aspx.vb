Public Class inhibitor
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub inhibitor_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
         Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_inhibitor_tower(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output", "Out Of Range Alarm", "Min/max High", "Min/max Low", "Time (min)")
        End If
    End Sub
    Public Sub posiziona_inhibitor_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                       ByVal time_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable


        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim version_str As String
        Dim config_value() As String
        Dim unit_value() As String
        Dim inhibitor_value() As String
        Dim full_scale_temp As Integer = 0
        Dim personalizzazione_aquacare As Integer
        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        ' abilito pulsante modifica
        save_inhibitortower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_inhibitortower_new, ""))
        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        config_value = main_function.get_split_str(riga_strumento.value4)
        inhibitor_value = main_function.get_split_str(riga_strumento.value14)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , full_scale_temp)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)

        If measure_unit = "uS" Then
            Literal12.Text = "uS "
        Else
            Literal12.Text = "ppm "
        End If

        If InStr(version_str, "3.0.0") Or InStr(version_str, "3.0.1") Then

            If full_scale_temp = 30000 Then
                Literal12.Text = Literal12.Text + "0"
            End If
            set_variable_javascript(0, 0) = "max_us"
            set_variable_javascript(0, 1) = "3000"
        Else
            set_variable_javascript(0, 0) = "max_us"
            set_variable_javascript(0, 1) = "9999"

        End If



        Select Case Mid(inhibitor_value(0), 1, 3)

            Case "MT0" 'Feed and Bleed
                enable_feed_bleed.Checked = True
                function_java = function_java + "enable_bleed();"

            Case "MT1" 'Feed % Bleed
                enable_feed_bleed_percent.Checked = True
                value_feed_bleed_percent.Text = Format(Val(Mid(inhibitor_value(0), 4, 3)), "000")
                function_java = function_java + "enable_feed_bleed_percent();"


            Case "MT2" 'Feed % Time
                enable_feed_time_percent.Checked = True
                value_feed_time_percent_hr.Text = Format(Val(Mid(inhibitor_value(0), 4, 2)), "00") 'Cycle Time Hour
                value_feed_time_percent_min.Text = Format(Val(Mid(inhibitor_value(0), 6, 2)), "00") 'Cycle Time Minute
                value_feed_time_percent_percent.Text = Format(Val(Mid(inhibitor_value(0), 8, 3)), "000") 'Percentage
                function_java = function_java + "enable_feed_time_percent();"

            Case "MT3" 'Feed Water Meter
                enable_water_meter.Checked = True
                value_water_meter_hr.Text = Format(Val(Mid(inhibitor_value(0), 4, 2)), "00") 'Time Hour
                value_water_meter_min.Text = Format(Val(Mid(inhibitor_value(0), 6, 2)), "00") 'Time Minute
                value_water_meter_counter.Text = Format(Val(Mid(inhibitor_value(0), 8, 4)), "0000") 'Counter
                function_java = function_java + "enable_water_meter();"

            Case "MT4" 'Feed Water Meter ppm l/h, g/h
                enable_water_meter_ppm.Checked = True
                enable_water_meter_ppm_l_h.Checked = True
                value_water_meter_ppm_ppm.Text = Format(Val(Mid(inhibitor_value(0), 4, 4)), "0000") 'ppm
                main_function_config.get_tower_unit(unit_value, international_unit)

                If international_unit = "IS" Then
                    value_water_meter_ppm_l_h.Text = Format(Val(Mid(inhibitor_value(0), 8, 3)), "000") 'litri/h
                    Literal16.Text = "l/h"
                End If

                If international_unit = "US" Then
                    value_water_meter_ppm_l_h.Text = Format(Val(Mid(inhibitor_value(0), 11, 3)), "000") 'galloni/h
                    Literal16.Text = "g/h"
                End If
                value_water_meter_ppm_percent.Text = Format(Val(Mid(inhibitor_value(0), 14, 3)), "000")  'concentrazione
                function_java = function_java + "enable_water_meter_ppm();"

            Case "MT5" 'Feed Water Meter ppm cc.st
                enable_water_meter_ppm.Checked = True
                enable_water_meter_ppm_cc_st.Checked = True
                value_water_meter_ppm_ppm.Text = Format(Val(Mid(inhibitor_value(0), 4, 4)), "0000") 'ppm
                value_water_meter_ppm_cc_st.Text = Replace(((Val(Mid(inhibitor_value(0), 8, 4))) / 100).ToString, ",", ".") 'cc/st

                value_water_meter_ppm_percent.Text = Format(Val(Mid(inhibitor_value(0), 12, 3)), "000")  'concentrazione
                function_java = function_java + "enable_water_meter_ppm();"


        End Select
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)
        java_script_function.call_function_javascript_onload(Page, function_java)
    End Sub
    Private Function MakeInhibitor() As String
        Dim risultato As String = ""
        If enable_feed_bleed.Checked Then
            risultato = "MT0"
        End If

        If enable_feed_bleed_percent.Checked Then
            risultato = "MT1" + Format(Val(value_feed_bleed_percent.Text), "000")
        End If

        If enable_feed_time_percent.Checked Then
            risultato = "MT2" + Format(Val(value_feed_time_percent_hr.Text), "00") + Format(Val(value_feed_time_percent_min.Text), "00") + Format(Val(value_feed_time_percent_percent.Text), "000")
        End If

        If enable_water_meter.Checked Then
            risultato = "MT3" + Format(Val(value_water_meter_hr.Text), "00") + Format(Val(value_water_meter_min.Text), "00") + Format(Val(value_water_meter_counter.Text), "0000")
        End If

        If enable_water_meter_ppm.Checked Then

            If enable_water_meter_ppm_l_h.Checked Then    'l/h , g/h
                risultato = "MT4" + Format(Val(value_water_meter_ppm_ppm.Text), "0000") + Format(Val(value_water_meter_ppm_l_h.Text), "000") + Format(Val(value_water_meter_ppm_l_h.Text), "000") + Format(Val(value_water_meter_ppm_percent.Text), "000")
            End If

            If enable_water_meter_ppm_cc_st.Checked Then     'cc.st
                risultato = "MT5" + Format(Val(value_water_meter_ppm_ppm.Text), "0000") + Format(Val(value_water_meter_ppm_cc_st.Text) * 100, "0000") + Format(Val(value_water_meter_ppm_percent.Text), "000")
            End If
        End If
        Return id_485_impianto + "inhibw" + risultato + "inhibwend" & Chr(13)


    End Function

    Protected Sub save_inhibitortower_new_Click(sender As Object, e As EventArgs) Handles save_inhibitortower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeInhibitor()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=1" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class