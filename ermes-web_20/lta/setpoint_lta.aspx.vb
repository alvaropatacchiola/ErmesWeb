Public Class setpoint_lta


    Inherits lingua



    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub setpoint_lta_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_setpoint_lta(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "setpoint"))
        End If
    End Sub
    Public Sub posiziona_setpoint_lta(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                              ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim java_script_ch1_pulse1 As java_script = New java_script
        Dim java_script_setpoint As java_script = New java_script

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
        save_setpointlta_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointlta_new, ""))

        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        data_sp = main_function.get_split_str(riga_strumento.value7)



        '    2°	1 			// Modalità
        '		if	((*get_data_mode()).Mode == 0)// proportional wm
        '		if	((*get_data_mode()).Mode == 1)// costante
        '		if	((*get_data_mode()).Mode == 2)// BATCH 
        '		if	((*get_data_mode()).Mode == 4)// PROP & READ 
        '		if	((*get_data_mode()).Mode == 5)// READING 

        '//-----	
        '//-----				
        '(*get_data_constant()).CAP1 ; 				3° // in costante
        '(*get_data_constant()).CAP2 ;				4° // in costante 
        '//-----
        '//-----
        '(*get_data_prop()).CAP 		 				5° // valore in  proportional wm 	// setpoint in  PROP & READ  	// 100% in READING
        '(*get_data_prop()).LIMIT					6° 									// Limit in  	PROP & READ		//   0% in READING
        '//----
        '//-----
        '(*get_data_analog()).OUT = 1;	7° // 0 -> 0/20mA 1->4/20mA  Uscite in corrente  						(valore editabile)

        '(*get_data_analog()).OUTA = 0;	8°// 0/4 mA a 0 g/h														(valore non editabile)
        '(*get_data_analog()).OUTB = 8;  9°// 20  mA a 8 g/h (massimo valore editabile in base alla produzione)	(valore editabile)


        '(*get_data_analog()).IN = 1;	10°// 0 -> 0/20mA 1->4/20mA per la lettura  	(valore editabile)

        '(*get_data_analog()).INA = 0;	11°	// 0/4 mA a questa lettura 					(valore editabile)
        '(*get_data_analog()).INB = 100;	12° // 20  mA a questa lettura		
        '                         label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        '                         label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)


        'tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "1"
        'tabld1_2.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "2"
        'tabld1_3.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay")

        'tabld1_4.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
        'tabld1_5.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "relay")

        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)




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


        Dim mode As String = Mid(data_sp(2), 1, 1)
        '   // Modalità
        'if	((*get_data_mode()).Mode == 0)// proportional wm
        'if	((*get_data_mode()).Mode == 1)// costante
        'if	((*get_data_mode()).Mode == 2)// BATCH 
        'if	((*get_data_mode()).Mode == 4)// PROP & READ 
        'if	((*get_data_mode()).Mode == 5)// READING 


        Select Case mode
            Case "0"
                Proportional.Checked = True
            Case "1"
                Constant.Checked = True
            Case "2"
                Batch.Checked = True
            Case "4"
                PropRead.Checked = True
            Case "5"
                Reading.Checked = True

        End Select
        Select riga_strumento.tipo_strumento
            Case "LTU"



                PropRead.Visible = False

                Reading.Visible = False

                Batch.Visible = False


                Batch_testo.Visible = False
                PropRead_testo.Visible = False

                Reading_testo.Visible = False
        End Select


                AnalogOut.Checked = True

                Dim const1 As String = Mid(data_sp(3), 1, 3)
                Dim const2 As String = Mid(data_sp(4), 1, 3)
                value_constant.Text = Format(Val(const1), "000")
                value_constant2.Text = Format(Val(const2), "000")
                '-------------------------------------------------------------------
                Dim prop_wm As String = Mid(data_sp(5), 1, 4)
                Dim temp_calc As Single = Val(prop_wm) / fattore_divisione_temp2
                value_ppm_proportional.Text = Replace(temp_calc.ToString(), ",", ".")

                '-------------------------------------------------------------------

                Dim propread_val1 As String = Mid(data_sp(5), 1, 4)
                Dim propread_val2 As String = Mid(data_sp(6), 1, 4)

                temp_calc = Val(propread_val1) / fattore_divisione_temp2
                value1_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

                temp_calc = Val(propread_val2) / fattore_divisione_temp2
                value2_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")


                '-------------------------------------------------------------------
                Dim read_val1 As String = Mid(data_sp(5), 1, 4)
                Dim read_val2 As String = Mid(data_sp(6), 1, 4)

                temp_calc = Val(read_val1) / fattore_divisione_temp2
                value1_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

                temp_calc = Val(read_val2) / fattore_divisione_temp2
                value2_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")


                '------------------------------------------------------------------
                Dim mode_ma_cap As String = Mid(data_sp(7), 1, 1)
                Dim mode_ma_read As String = Mid(data_sp(10), 1, 1)

                Select Case mode_ma_cap
                    Case "0"
                        Cap0_20_mA.Checked = True
                    Case "1"
                        Cap4_20_mA.Checked = True


                End Select

                Select Case mode_ma_read
                    Case "0"
                        Read0_20_mA.Checked = True
                    Case "1"
                        Read4_20_mA.Checked = True


                End Select

                Dim val_gh_cap_ma As String = Mid(data_sp(9), 1, 4)
                valore_cap_20mA.Text = Format(Val(val_gh_cap_ma), "0000")


                Dim val_ppm_read0_4_ma As String = Mid(data_sp(11), 1, 4)
                temp_calc = Val(val_ppm_read0_4_ma) / fattore_divisione_temp2
                valore_read_0_4mA.Text = Replace(temp_calc.ToString(), ",", ".")


                Dim val_ppm_read20_ma As String = Mid(data_sp(12), 1, 4)
                temp_calc = Val(val_ppm_read20_ma) / fattore_divisione_temp2
                valore_read_20mA.Text = Replace(temp_calc.ToString(), ",", ".")


                function_java = ""

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
    'Private Sub setting_label_setpoint(ByVal etichetta_setpoint As String, ByVal numero_canale As String, ByVal traduzione_pulse As String, ByVal traduzione_pulse_minute As String, ByVal traduzione_pulse_speed As String, ByVal literal1 As Literal, _
    '                                   ByVal Literal2 As Literal, ByVal Literal2_1 As Literal, ByVal Literal3 As Literal, ByVal Literal4 As Literal, ByVal Literal4_1 As Literal, _
    '                                   ByVal Literal5 As Literal, ByVal Literal6 As Literal, ByVal LiteralTipo As String, ByVal traduzione_on As String, ByVal traduzione_off As String)
    '    literal1.Text = LiteralTipo + " " + traduzione_pulse + " " + numero_canale
    '    Literal2.Text = etichetta_setpoint
    '    Literal2_1.Text = etichetta_setpoint + " " + traduzione_on
    '    Literal3.Text = traduzione_pulse_minute
    '    Literal4.Text = etichetta_setpoint
    '    Literal4_1.Text = etichetta_setpoint + " " + traduzione_off
    '    Literal5.Text = traduzione_pulse_minute
    '    Literal6.Text = traduzione_pulse_speed ' + "(min)"
    'End Sub
    'Private Sub setting_label_setpoint_relay(ByVal etichetta_setpoint As String, ByVal traduzione_relay As String, ByVal literal1 As Literal, _
    '                                   ByVal Literal2 As Literal, ByVal Literal2_1 As Literal, ByVal Literal3 As Literal, ByVal Literal3_1 As Literal, ByVal Literal4 As Literal, _
    '                                   ByVal Literal4_1 As Literal, ByVal Literal5 As Literal, ByVal Literal5_1 As Literal, ByVal LiteralTipo As String, _
    '                                   ByVal traduzione_on As String, ByVal traduzione_off As String, ByVal traduzione_sec As String)
    '    literal1.Text = LiteralTipo + " " + traduzione_relay
    '    Literal2.Text = etichetta_setpoint
    '    Literal2_1.Text = etichetta_setpoint + " " + traduzione_on
    '    Literal3.Text = "%"
    '    Literal3_1.Text = traduzione_sec
    '    Literal4.Text = etichetta_setpoint
    '    Literal4_1.Text = etichetta_setpoint + " " + traduzione_off
    '    Literal5.Text = "%"
    '    Literal5_1.Text = traduzione_sec

    'End Sub
    Private Function MakeSETString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0


        Dim app_mode As String


        Dim app_prod_i As Integer
        Dim app_prod_s As String

        app_prod_i = 8
        app_prod_s = Format(app_prod_i, "0000")

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        '   // Modalità
        'if	((*get_data_mode()).Mode == 0)// proportional wm
        'if	((*get_data_mode()).Mode == 1)// costante
        'if	((*get_data_mode()).Mode == 2)// BATCH 
        'if	((*get_data_mode()).Mode == 4)// PROP & READ 
        'if	((*get_data_mode()).Mode == 5)// READING 

        If Proportional.Checked = True Then
            app_mode = "0"
        End If

        If Constant.Checked = True Then
            app_mode = "1"
        End If

        If PropRead.Checked = True Then
            app_mode = "4"
        End If

        If Reading.Checked = True Then
            app_mode = "5"
        End If

        If Batch.Checked = True Then
            app_mode = "2"
        End If







        Dim fattore_ch1 As Integer
        Dim fattore_ch2 As Integer


        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2)


       

        Dim const_1_i As Integer
        Dim const_1_s As String
        Dim const_2_i As Integer
        Dim const_2_s As String




        const_1_i = Val(value_constant.Text)
        const_1_s = Format(const_1_i, "000")

        const_2_i = Val(value_constant2.Text)
        const_2_s = Format(const_2_i, "000")
        '-------------------------------------------------------------------
        Dim cap_prop_i As Integer
        Dim cap_prop_s As String
        Dim cap_propread_i As Integer
        Dim cap_propread_s As String
        Dim cap_read_i As Integer
        Dim cap_read_s As String

        Dim lim_prop_i As Integer
        Dim lim_prop_s As String
        Dim lim_propread_i As Integer
        Dim lim_propread_s As String
        Dim lim_read_i As Integer
        Dim lim_read_s As String



        cap_prop_i = Val(value_ppm_proportional.Text) * 100
        cap_prop_s = Format(cap_prop_i, "0000")
        lim_prop_i = 25
        lim_prop_s = Format(lim_prop_i, "0000")
        '-------------------------------------------------------------------

        cap_propread_i = Val(value1_mgl_propread.Text) * fattore_divisione_temp2
        cap_propread_s = Format(cap_propread_i, "0000")
        lim_propread_i = Val(value2_mgl_propread.Text) * fattore_divisione_temp2
        lim_propread_s = Format(lim_propread_i, "0000")

        '-----------------------------------------------------------------
        cap_read_i = Val(value1_mgl_reading.Text) * fattore_divisione_temp2
        cap_read_s = Format(cap_read_i, "0000")
        lim_read_i = Val(value2_mgl_reading.Text) * fattore_divisione_temp2
        lim_read_s = Format(lim_read_i, "0000")

        '-----------------------------------------------------------------

        Dim app_cap_mA As String
        Dim app_read_mA As String

        If Cap0_20_mA.Checked = True Then
            app_cap_mA = "0"
        End If

        If Cap4_20_mA.Checked = True Then
            app_cap_mA = "1"
        End If


        If Read0_20_mA.Checked = True Then
            app_read_mA = "0"
        End If

        If Read4_20_mA.Checked = True Then
            app_read_mA = "1"
        End If

        Dim app_valore_cap_04mA_i As Integer
        Dim app_valore_cap_04mA_s As String
        Dim app_valore_cap_20mA_i As Integer
        Dim app_valore_cap_20mA_s As String

        app_valore_cap_04mA_i = 0
        app_valore_cap_04mA_s = Format(app_valore_cap_04mA_i, "0000")

        app_valore_cap_20mA_i = Val(valore_cap_20mA.Text)
        app_valore_cap_20mA_s = Format(app_valore_cap_20mA_i, "0000")


        Dim app_valore_read_04mA_i As Integer
        Dim app_valore_read_04mA_s As String
        Dim app_valore_read_20mA_i As Integer
        Dim app_valore_read_20mA_s As String

        app_valore_read_04mA_i = Val(valore_read_0_4mA.Text) * fattore_divisione_temp2
        app_valore_read_04mA_s = Format(app_valore_read_04mA_i, "0000")

        app_valore_read_20mA_i = Val(valore_read_20mA.Text) * fattore_divisione_temp2
        app_valore_read_20mA_s = Format(app_valore_read_20mA_i, "0000")




        If Proportional.Checked = True Then
            Risultato = app_prod_s + app_mode + const_1_s + const_2_s + cap_prop_s + lim_prop_s + app_cap_mA + app_valore_cap_04mA_s + app_valore_cap_20mA_s + app_read_mA + app_valore_read_04mA_s + app_valore_read_20mA_s
        End If
         
        If Constant.Checked = True Then
            Risultato = app_prod_s + app_mode + const_1_s + const_2_s + cap_prop_s + lim_prop_s + app_cap_mA + app_valore_cap_04mA_s + app_valore_cap_20mA_s + app_read_mA + app_valore_read_04mA_s + app_valore_read_20mA_s
        End If

        If PropRead.Checked = True Then
            Risultato = app_prod_s + app_mode + const_1_s + const_2_s + cap_propread_s + lim_propread_s + app_cap_mA + app_valore_cap_04mA_s + app_valore_cap_20mA_s + app_read_mA + app_valore_read_04mA_s + app_valore_read_20mA_s
        End If

        If Reading.Checked = True Then
            Risultato = app_prod_s + app_mode + const_1_s + const_2_s + cap_read_s + lim_read_s + app_cap_mA + app_valore_cap_04mA_s + app_valore_cap_20mA_s + app_read_mA + app_valore_read_04mA_s + app_valore_read_20mA_s
        End If

        If Batch.Checked = True Then
            Risultato = app_prod_s + app_mode + const_1_s + const_2_s + cap_prop_s + lim_prop_s + app_cap_mA + app_valore_cap_04mA_s + app_valore_cap_20mA_s + app_read_mA + app_valore_read_04mA_s + app_valore_read_20mA_s
        End If





        Return id_485_impianto + "setpnw" + Risultato + "setpnwend" & Chr(13)

    End Function

    Protected Sub save_setpointlta_new_Click(sender As Object, e As EventArgs) Handles save_setpointlta_new.Click
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

        Response.Redirect("~/lta.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=1" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class