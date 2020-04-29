﻿Public Class calibration_ldt
        Inherits lingua
        ' prova archiviazione 18-02-14    
        'pippo


        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""

        Private Sub calibration_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

            Dim result As String = ""
            result = Page.Request("result")

            If Not IsPostBack Or result = "1" Then
                nome_impianto = Page.Request("nome_impianto")
                nome_impianto = Replace(nome_impianto, "$", " ")
                codice_impianto = Page.Request("codice")
                id_485_impianto = Page.Request("id_485")
                statistica = Page.Request("statistica")

                'posiziona_calibrationld(nome_impianto, codice_impianto, id_485_impianto, GetLocalResourceObject("calibration_channelResource1.Text"), GetLocalResourceObject("Literal4Resource1.Text"), GetLocalResourceObject("Literal1Resource1.Text"), GetLocalResourceObject("Literal2Resource1.Text"), GetLocalResourceObject("Literal8Resource1.Text"))
            posiziona_calibration_ldtower(nome_impianto, codice_impianto, id_485_impianto, GetGlobalResourceObject("ld_global", "val_calibration"), GetGlobalResourceObject("ld_global", "val_canale"), GetGlobalResourceObject("ld_global", "val_mvprobe"), GetGlobalResourceObject("ld_global", "val_valueprobe"), GetGlobalResourceObject("ld_global", "val_valuenew"))

            End If
            'ciao
        End Sub
    Public Sub posiziona_calibration_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                                  ByVal calibration_traduzione As String, ByVal canale_traduzione As String, ByVal probemv_traduzione As String, ByVal probevalue_traduzione As String, ByVal new_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim letture_value() As String
        Dim calibration_value() As String
        Dim config_value() As String
        Dim option_value() As String
        Dim fattore_divisione_temp As Integer
        Dim valore_canale_temp As Single = 0
        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(14, 1) As String

        Dim j As Integer
        Dim new_version As Boolean = False
        Dim version_str As String
        Dim label_canale_temp As String = ""
        Dim label_canale2_temp As String = ""
        Dim full_scale_temp As Single
        Dim full_scale_temp2 As Single
        Dim calibrz_value() As String
        Dim etichetta_setpoint As String = ""
        Dim etichetta_setpoint2 As String = ""
        Dim personalizzazione_aquacare As Integer

        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_calibration_ldtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;",
             ClientScript.GetPostBackEventReference(save_calibration_ldtower_new, ""))


        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibration_channel.Text = calibration_traduzione

        Label7.Text = canale_traduzione
        
        Literal1.Text = probemv_traduzione

        Literal2.Text = probevalue_traduzione

        Literal3.Text = new_traduzione
        


        letture_value = main_function.get_split_str(riga_strumento.value2)
        calibration_value = main_function.get_split_str(riga_strumento.value34)         '------------- DA CAMBIARE IL VALORE DI VALUE17!!!!!! -----------------------

        new_version = main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        calibrz_value = main_function.get_split_str(riga_strumento.value33)


        'main_function_config.get_tipo_strumento_ldtower(calibrz_value(0), calibrz_value(1), calibrz_value(2), calibrz_value(3), version_str)



        set_variable_javascript(0, 0) = "max_ch1_value"
        set_variable_javascript(0, 1) = full_scale_temp.ToString
        set_variable_javascript(1, 0) = "min_ch1_value"
        set_variable_javascript(1, 1) = "0"
        set_variable_javascript(4, 0) = "max_fix_value1"
        set_variable_javascript(4, 1) = set_fullscale(full_scale_temp).ToString
        set_variable_javascript(5, 0) = "max_fix_value2"
        set_variable_javascript(5, 1) = set_fullscale(full_scale_temp2).ToString

        fattore_divisione_temp = 1      'impostato ad 1 di default

        calibration_value(0) = calibration_value(0).Replace("MT", "")

        probe_mv_value.Text = calibration_value(0).Replace("servirend", "")


        Dim temp_calc As Single = Val(Mid(letture_value(0), 3, 4)) / fattore_divisione_temp 'on     DA RIVEDERE!!!!!!
        probe_value.Text = Replace(temp_calc.ToString(), ",", ".")
        new_value.Text = probe_value.Text
        temp_calc = Val(Mid(letture_value(0), 1, 4)) + (fattore_divisione_temp / 10) / fattore_divisione_temp
        set_variable_javascript(0, 1) = temp_calc.ToString
        If temp_calc < 0 Then
            temp_calc = 0
        End If
        temp_calc = Val(Mid(letture_value(0), 1, 4)) - (fattore_divisione_temp / 10) / fattore_divisione_temp


        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 14)
        java_script_variable.call_function_javascript_onload(Page, "enable_channel_calibrazione(" + (calibration_value.Length - 1).ToString + ");")

    End Sub
        Private Function check_fix(ByVal factor_divide As Integer) As Integer
            Select Case factor_divide
                Case 1
                    Return 0
                Case 10
                    Return 1
                Case 100
                    Return 2
                Case 1000
                    Return 3
            End Select
        End Function

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

        Private Function MakeCalibration() As String
            Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
            Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
            Dim config_value() As String
            Dim option_value() As String
            Dim fattore_divisione_temp As Integer
            Dim fattore_divisione_temp2 As Integer
            Dim calibrz_value() As String
            Dim full_scale_temp As Single
            Dim full_scale_temp2 As Single
            Dim label_canale_temp As String = ""
            Dim label_canale2_temp As String = ""
            Dim letture_value() As String
            Dim calibration_value() As String

            tabella_strumento = (Session("strumento"))

            For Each dc1 In tabella_strumento
                If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                    riga_strumento = dc1
                End If
            Next


            config_value = main_function.get_split_str(riga_strumento.value1)
            option_value = main_function.get_split_str(riga_strumento.value4)

            letture_value = main_function.get_split_str(riga_strumento.value2)
        calibration_value = main_function.get_split_str(riga_strumento.value34)     'DA CAMBIARE IL VALORE DI VALUE17!!!!!
        calibrz_value = main_function.get_split_str(riga_strumento.value33)

        fattore_divisione_temp = 1
        Dim stringa_finale As String = ""

            Dim current_value As Integer
            Dim setting_value As Integer
        current_value = Val(probe_value.Text) * fattore_divisione_temp
        setting_value = Val(new_value.Text) * fattore_divisione_temp
            stringa_finale = stringa_finale + Format(setting_value, "0000")



        Return id_485_impianto + "calcdwMT" + stringa_finale + "calcdwend" & Chr(13)

        End Function

    Protected Sub save_calibration_ldtower_new_Click(sender As Object, e As EventArgs) Handles save_calibration_ldtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeCalibration()

        If local_connection Then ' connessione OK
            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        'javascript_function.call_function_javascript_onload(Page, "result_setpoint_change();")
        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=13&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub

    End Class