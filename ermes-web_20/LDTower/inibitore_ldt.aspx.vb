Public Class inibitore_ldt
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub inibitore_ldt_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_inhibitor_ldtower(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output", "Out Of Range Alarm", "Min/max High", "Min/max Low", "Time (min)")
        End If
    End Sub
    Public Sub posiziona_inhibitor_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
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
        save_inibldt_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_inibldt_new, ""))


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        config_value = main_function.get_split_str(riga_strumento.value4)
        inhibitor_value = main_function.get_split_str(riga_strumento.value14)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , full_scale_temp)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)



        ''Andrea Sortino 04-05-18
        Label7.Text = GetLocalResourceObject("Label7Resource1.Text")



        If measure_unit = "uS" Then
            Literal12.Text = "ppm "
        Else
            Literal12.Text = "ppm "
        End If



        If full_scale_temp = 5000 Then
            Literal12.Text = Literal12.Text + "0"
        End If
        set_variable_javascript(0, 0) = "max_us"
        set_variable_javascript(0, 1) = "500"





        Select Case Mid(inhibitor_value(0), 1, 3)


            Case "MT3" 'Feed Water Meter
                WM_inhib.Checked = True
                value_min_inhib.Text = Format(Val(Mid(inhibitor_value(0), 4, 2)), "00") 'Time Hour
                value_sec_inhib.Text = Format(Val(Mid(inhibitor_value(0), 6, 2)), "00") 'Time Minute
                value_counter_inhib.Text = Format(Val(Mid(inhibitor_value(0), 8, 4)), "0000") 'Counter

                If (Val(Mid(inhibitor_value(0), 12, 1))) = 1 Then
                    mode_d_bleed_feed.Checked = True
                Else
                    mode_d_bleed_feed.Checked = False
                End If

                If (Val(Mid(inhibitor_value(0), 13, 1))) = 1 Then
                    mode_d_bleed_lock.Checked = True
                Else
                    mode_d_bleed_lock.Checked = False
                End If

                function_java = function_java + "enable_WM_inhib();"

            Case "MT4" 'Feed Water Meter ppm l/h, g/h
                WM_ppm_inhib.Checked = True
                enable_water_meter_ppm_l_h.Checked = True
                value_water_meter_ppm.Text = Format(Val(Mid(inhibitor_value(0), 4, 4)), "0000") 'Time Hour

                If international_unit = "IS" Then
                    value_water_meter_ppm_l_h.Text = Format(Val(Mid(inhibitor_value(0), 8, 3)), "000") 'litri/h
                    Literal16.Text = "l/h"
                End If

                If international_unit = "US" Then
                    value_water_meter_ppm_l_h.Text = Format(Val(Mid(inhibitor_value(0), 11, 3)), "000") 'galloni/h
                    Literal16.Text = "g/h"
                End If

                If (Val(Mid(inhibitor_value(0), 12, 1))) = 1 Then
                    mode_d_bleed_feed.Checked = True
                Else
                    mode_d_bleed_feed.Checked = False
                End If

                If (Val(Mid(inhibitor_value(0), 13, 1))) = 1 Then
                    mode_d_bleed_lock.Checked = True
                Else
                    mode_d_bleed_lock.Checked = False
                End If
                'Messo per evitare errore nel salvataggio dei dati
                value_water_meter_ppm_cc_st.Text = Replace(((Val(Mid(inhibitor_value(0), 8, 4))) / 100).ToString, ",", ".") 'cc/st


                function_java = function_java + "enable_WM_ppm_inhib();enable_WM_l_h()"

            Case "MT5" 'Feed Water Meter ppm cc.st
                WM_ppm_inhib.Checked = True
                enable_water_meter_ppm_cc_st.Checked = True
                value_water_meter_ppm.Text = Format(Val(Mid(inhibitor_value(0), 4, 4)), "0000") 'ppm
                value_water_meter_ppm_cc_st.Text = Replace(((Val(Mid(inhibitor_value(0), 8, 4))) / 100).ToString, ",", ".") 'cc/st
                'Messo per evitare errore nel salvataggio dei dati
                value_water_meter_ppm_l_h.Text = Format(Val(Mid(inhibitor_value(0), 8, 3)), "000") 'litri/h

                function_java = function_java + "enable_WM_ppm_inhib();enable_WM_cc_st();"


        End Select
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)
        java_script_function.call_function_javascript_onload(Page, function_java)
    End Sub
    Private Function MakeInhibitor() As String
        Dim risultato As String = ""
        Dim value_feed As String
        Dim value_lock As String

        If mode_d_bleed_feed.Checked Then
            value_feed = "1"
        Else
            value_feed = "0"
        End If

        If mode_d_bleed_lock.Checked Then
            value_lock = "1"
        Else
            value_lock = "0"
        End If

        If WM_inhib.Checked Then
            risultato = "MT3" + Format(Val(value_min_inhib.Text), "00") + Format(Val(value_sec_inhib.Text), "00") + Format(Val(value_counter_inhib.Text), "0000") + value_feed + value_lock
        End If

        If WM_ppm_inhib.Checked Then

            If enable_water_meter_ppm_l_h.Checked Then    'l/h , g/h
                risultato = "MT4" + Format(Val(value_water_meter_ppm.Text), "0000") + Format(Val(value_water_meter_ppm_l_h.Text), "000") + Format(Val(value_water_meter_ppm_l_h.Text), "000") + value_feed + value_lock
            End If

            If enable_water_meter_ppm_cc_st.Checked Then     'cc.st
                risultato = "MT5" + Format(Val(value_water_meter_ppm.Text), "0000") + Format(Val(value_water_meter_ppm_cc_st.Text) * 100, "0000") + value_feed + value_lock
            End If
        End If
        Return id_485_impianto + "inhibw" + risultato + "inhibwend" & Chr(13)


    End Function

    Protected Sub save_inibldt_new_Click(sender As Object, e As EventArgs) Handles save_inibldt_new.Click
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

        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=1" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub

End Class