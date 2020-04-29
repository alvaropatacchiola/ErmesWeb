Public Class setpoint_ltb


    Inherits lingua



    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub setpoint_ltb_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_setpoint_ltb(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "setpoint"))
        End If
    End Sub
    Public Sub posiziona_setpoint_ltb(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
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
        save_setpointltb_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointltb_new, ""))

        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        data_sp = main_function.get_split_str(riga_strumento.value7)

        If Val(main_function.get_version(riga_strumento.nome)) < 125 Then



            '           1 			// Modalità
            '			//-----	
            '			//-----				
            '			078			// Constant
            '           94:
            '			//-----
            '			//-----
            '			999			// Proportional (WM)
            '           112:
            '			//----
            '			//-----
            '			078			// Prop.(WM)+ Reading (Cl)
            '			12345		// IS
            '           157:
            '           100:
            '           980:
            '           80:
            '			//----------
            '			085			// Relè
            '           64958:
            '           757:
            '           99:
            '           482:
            '           98:
            '			//-----
            '			//-----
            '			0651			// reading  IS
            '           177:
            '           706:
            '           159:
            '			//----------
            '			0231		// reading  Relè
            '           23:
            '           596:

            '               79:


            '                (*get_data_mode()).Mode 
            '				0 : "Proportional (WM)"
            '				1 : "Constant"
            '				2 : "Prop.(WM)+ Reading"
            '				3 : "Reading"

            '				//---------------------------------------
            '				//---------------------------------------
            '				constant  AAA BBB    
            '				AAA  percentuale IS			(*get_data_constant()).CAPCL_IS
            '				BBB  percentuale relè		(*get_data_constant()).CAPCL_RL
            '				//---------------------------------------
            '				//---------------------------------------
            '				Proportional (WM)   AAA BBB 
            '				AAA  max 999 IS				(*get_data_prop()).PPM_IS_CL
            '				BBB  max 999 relè			(*get_data_prop()).PPM_RL_CL

            '				//---------------------------------------
            '				//---------------------------------------
            '				Prop.(WM)+ Reading (Cl)
            '				AAA  	percentuale IS		(*get_data_prop_read()).PERC_IS_CL
            '				BBBBB 	mc/h				(*get_data_prop_read()).MC_H_IS   MAX 65000
            '				CCCC    valore 1 			(*get_data_prop_read()).VALA_IS_CL   	
            '				DDD     perc 1				(*get_data_prop_read()).PMA_IS_CL
            '				EEEE    valore 2    		(*get_data_prop_read()).VALB_IS_CL	
            '				FFF     perc 2				(*get_data_prop_read()).PMB_IS_CL	
            '				//---------------------------------------
            '				GGG  	percentuale relè 	(*get_data_prop_read()).PERC_RL_CL
            '				HHHHH 	mc/h				(*get_data_prop_read()).MC_H_RL MAX 65000
            '				IIII    valore 1    		(*get_data_prop_read()).VALA_RL_CL	
            '				LLL     perc 1				(*get_data_prop_read()).PERCA_RL_CL
            '				MMMM    valore 2    		(*get_data_prop_read()).VALB_RL_CL	
            '				NNN     perc 2				(*get_data_prop_read()).PERCB_RL_CL
            '				//---------------------------------------
            '				//---------------------------------------
            '				reading  IS
            '				AAAA	valore 1      		(*get_data_read()).VALA_IS_CL
            '				BBB     P/m max 180			(*get_data_read()).PMA_IS_CL
            '				CCCC	valore 2			(*get_data_read()).VALB_IS_CL
            '				DDD		P/m max 180			(*get_data_read()).PMB_IS_CL
            '				//---------------------------------------
            '				EEEE	valore 1			(*get_data_read()).VALA_RL_CL
            '				FFF     Perc max 100		(*get_data_read()).PERCA_RL_CL
            '				GGGG	valore 2			(*get_data_read()).VALB_RL_CL
            '				HHH		Perc max 100		(*get_data_read()).PERCB_RL_CL

            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
            label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)


            'tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "1"
            'tabld1_2.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "2"
            'tabld1_3.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay")

            'tabld1_4.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
            'tabld1_5.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "relay")




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


            Dim mode As String = Mid(data_sp(1), 1, 1)
            '				0 : "Proportional (WM)"
            '				1 : "Constant"
            '				2 : "Prop.(WM)+ Reading"
            '				3 : "Reading"


            Select Case mode
                Case "0"
                    Proportional.Checked = True
                Case "1"
                    Constant.Checked = True
                Case "2"
                    PropRead.Checked = True
                Case "3"
                    Reading.Checked = True
                Case "4"
                    PropmA.Checked = True
            End Select



            Dim const_IS_cl As String = Mid(data_sp(2), 1, 3)
            Dim const_rele_cl As String = Mid(data_sp(3), 1, 3)
            value_constant.Text = Format(Val(const_IS_cl), "000")
            '-------------------------------------------------------------------
            Dim prop_IS_cl As String = Mid(data_sp(4), 1, 3)
            Dim prop_rele_cl As String = Mid(data_sp(5), 1, 3)


            Dim temp_calc As Single = Val(prop_IS_cl) / 100
            value_ppm_proportional.Text = Replace(temp_calc.ToString(), ",", ".")



            '-------------------------------------------------------------------
            Dim propread_perc_IS As String = Mid(data_sp(6), 1, 3)
            Dim propread_mch_IS As String = Mid(data_sp(7), 1, 5)
            Dim propread_val1_IS As String = Mid(data_sp(8), 1, 4)
            Dim propread_pm1_IS As String = Mid(data_sp(9), 1, 3)
            Dim propread_val2_IS As String = Mid(data_sp(10), 1, 4)
            Dim propread_pm2_IS As String = Mid(data_sp(11), 1, 3)


            temp_calc = Val(propread_val1_IS) / fattore_divisione_temp2
            value1_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(propread_val2_IS) / fattore_divisione_temp2
            value2_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            value1_pm_propread.Text = Format(Val(propread_pm1_IS), "000")

            value2_pm_propread.Text = Format(Val(propread_pm2_IS), "000")

            temp_calc = Val(propread_mch_IS) / 100
            value_mch_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            value_perc_propread.Text = Format(Val(propread_perc_IS), "000")

            '-------------------------------------------------------------------
            Dim propread_perc_rele As String = Mid(data_sp(12), 1, 3)
            Dim propread_mch_rele As String = Mid(data_sp(13), 1, 5)
            Dim propread_val1_rele As String = Mid(data_sp(14), 1, 4)
            Dim propread_pm1_rele As String = Mid(data_sp(15), 1, 3)
            Dim propread_val2_rele As String = Mid(data_sp(16), 1, 4)
            Dim propread_pm2_rele As String = Mid(data_sp(17), 1, 3)
            '-------------------------------------------------------------------
            Dim read_val1_IS As String = Mid(data_sp(18), 1, 4)
            Dim read_pm1_IS As String = Mid(data_sp(19), 1, 3)
            Dim read_val2_IS As String = Mid(data_sp(20), 1, 4)
            Dim read_pm2_IS As String = Mid(data_sp(21), 1, 3)

            temp_calc = Val(read_val1_IS) / fattore_divisione_temp2
            value1_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(read_val2_IS) / fattore_divisione_temp2
            value2_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

            value1_pm_reading.Text = Format(Val(read_pm1_IS), "000")

            value2_pm_reading.Text = Format(Val(read_pm2_IS), "000")


            '-------------------------------------------------------------------
            Dim read_val1_rele As String = Mid(data_sp(22), 1, 4)
            Dim read_pm1_rele As String = Mid(data_sp(23), 1, 3)
            Dim read_val2_rele As String = Mid(data_sp(24), 1, 4)
            Dim read_pm2_rele As String = Mid(data_sp(25), 1, 3)



            '-------------------------------------------------------------------

            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then




            Else
                Dim propmA_val1 As String = Mid(data_sp(26), 1, 4)
                Dim propmA_pm1 As String = Mid(data_sp(27), 1, 3)
                Dim propmA_val2 As String = Mid(data_sp(28), 1, 4)
                Dim propmA_pm2 As String = Mid(data_sp(29), 1, 3)


                temp_calc = Val(propmA_val1) / 100
                value1_mA_propmA.Text = Replace(temp_calc.ToString(), ",", ".")

                temp_calc = Val(propmA_val2) / 100
                value2_mA_propmA.Text = Replace(temp_calc.ToString(), ",", ".")

                value1_pm_propmA.Text = Format(Val(propmA_pm1), "000")

                value2_pm_propmA.Text = Format(Val(propmA_pm2), "000")




            End If






            function_java = ""




            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then

                enable_propmA.Visible = False
                enable_tab_propmA.Visible = False
                PropmA.Visible = False

                PropmA_testo.Visible = False


            Else
                enable_propmA.Visible = True

                enable_tab_propmA.Visible = True

                PropmA.Visible = True

                PropmA_testo.Visible = True


            End If


        End If


        If Val(main_function.get_version(riga_strumento.nome)) >= 125 And Val(main_function.get_version(riga_strumento.nome)) < 211 Then



            '           1 			// Modalità
            '			//-----	
            '			//-----				
            '			078			// Constant
            '           94:
            '			//-----
            '			//-----
            '			999			// Proportional (WM)
            '           112:
            '			//----
            '			//-----
            '			078			// Prop.(WM)+ Reading (Cl)
            '			12345		// IS
            '           157:
            '           100:
            '           980:
            '           80:
            '			//----------
            '			085			// Relè
            '           64958:
            '           757:
            '           99:
            '           482:
            '           98:
            '			//-----
            '			//-----
            '			0651			// reading  IS
            '           177:
            '           706:
            '           159:
            '			//----------
            '			0231		// reading  Relè
            '           23:
            '           596:

            '               79:


            '                (*get_data_mode()).Mode 
            '				0 : "Proportional (WM)"
            '				1 : "Constant"
            '				2 : "Prop.(WM)+ Reading"
            '				3 : "Reading"

            '				//---------------------------------------
            '				//---------------------------------------
            '				constant  AAA BBB    
            '				AAA  percentuale IS			(*get_data_constant()).CAPCL_IS
            '				BBB  percentuale relè		(*get_data_constant()).CAPCL_RL
            '				//---------------------------------------
            '				//---------------------------------------
            '				Proportional (WM)   AAA BBB 
            '				AAA  max 999 IS				(*get_data_prop()).PPM_IS_CL
            '				BBB  max 999 relè			(*get_data_prop()).PPM_RL_CL

            '				//---------------------------------------
            '				//---------------------------------------
            '				Prop.(WM)+ Reading (Cl)
            '				AAA  	percentuale IS		(*get_data_prop_read()).PERC_IS_CL
            '				BBBBB 	mc/h				(*get_data_prop_read()).MC_H_IS   MAX 65000
            '				CCCC    valore 1 			(*get_data_prop_read()).VALA_IS_CL   	
            '				DDD     perc 1				(*get_data_prop_read()).PMA_IS_CL
            '				EEEE    valore 2    		(*get_data_prop_read()).VALB_IS_CL	
            '				FFF     perc 2				(*get_data_prop_read()).PMB_IS_CL	
            '				//---------------------------------------
            '				GGG  	percentuale relè 	(*get_data_prop_read()).PERC_RL_CL
            '				HHHHH 	mc/h				(*get_data_prop_read()).MC_H_RL MAX 65000
            '				IIII    valore 1    		(*get_data_prop_read()).VALA_RL_CL	
            '				LLL     perc 1				(*get_data_prop_read()).PERCA_RL_CL
            '				MMMM    valore 2    		(*get_data_prop_read()).VALB_RL_CL	
            '				NNN     perc 2				(*get_data_prop_read()).PERCB_RL_CL
            '				//---------------------------------------
            '				//---------------------------------------
            '				reading  IS
            '				AAAA	valore 1      		(*get_data_read()).VALA_IS_CL
            '				BBB     P/m max 180			(*get_data_read()).PMA_IS_CL
            '				CCCC	valore 2			(*get_data_read()).VALB_IS_CL
            '				DDD		P/m max 180			(*get_data_read()).PMB_IS_CL
            '				//---------------------------------------
            '				EEEE	valore 1			(*get_data_read()).VALA_RL_CL
            '				FFF     Perc max 100		(*get_data_read()).PERCA_RL_CL
            '				GGGG	valore 2			(*get_data_read()).VALB_RL_CL
            '				HHH		Perc max 100		(*get_data_read()).PERCB_RL_CL

            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
            label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)


            'tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "1"
            'tabld1_2.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "2"
            'tabld1_3.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay")

            'tabld1_4.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
            'tabld1_5.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "relay")




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


            Dim mode As String = Mid(data_sp(1), 1, 1)
            '				0 : "Proportional (WM)"
            '				1 : "Constant"
            '				2 : "Prop.(WM)+ Reading"
            '				3 : "Reading"
            '4 : "prop ma"
            '5 : "ext is"
            Select Case mode
                Case "0"
                    Proportional.Checked = True
                Case "1"
                    Constant.Checked = True
                Case "2"
                    PropRead.Checked = True
                Case "3"
                    Reading.Checked = True
                Case "4"
                    PropmA.Checked = True
                Case "5"
                    ExtIS.Checked = True
            End Select



            Dim const_IS_cl As String = Mid(data_sp(2), 1, 3)
            '  Dim const_rele_cl As String = Mid(data_sp(3), 1, 3)
            value_constant.Text = Format(Val(const_IS_cl), "000")
            '-------------------------------------------------------------------
            Dim prop_IS_cl As String = Mid(data_sp(3), 1, 3)
            'Dim prop_rele_cl As String = Mid(data_sp(5), 1, 3)


            Dim temp_calc As Single = Val(prop_IS_cl) / 100
            value_ppm_proportional.Text = Replace(temp_calc.ToString(), ",", ".")



            '-------------------------------------------------------------------
            Dim propread_perc_IS As String = Mid(data_sp(4), 1, 3)
            Dim propread_mch_IS As String = Mid(data_sp(5), 1, 5)
            Dim propread_val1_IS As String = Mid(data_sp(6), 1, 4)
            Dim propread_pm1_IS As String = Mid(data_sp(7), 1, 3)
            Dim propread_val2_IS As String = Mid(data_sp(8), 1, 4)
            Dim propread_pm2_IS As String = Mid(data_sp(9), 1, 3)


            temp_calc = Val(propread_val1_IS) / fattore_divisione_temp2
            value1_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(propread_val2_IS) / fattore_divisione_temp2
            value2_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            value1_pm_propread.Text = Format(Val(propread_pm1_IS), "000")

            value2_pm_propread.Text = Format(Val(propread_pm2_IS), "000")

            temp_calc = Val(propread_mch_IS) / 100
            value_mch_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            value_perc_propread.Text = Format(Val(propread_perc_IS), "000")

            '-------------------------------------------------------------------
            'Dim propread_perc_rele As String = Mid(data_sp(12), 1, 3)
            'Dim propread_mch_rele As String = Mid(data_sp(13), 1, 5)
            'Dim propread_val1_rele As String = Mid(data_sp(14), 1, 4)
            'Dim propread_pm1_rele As String = Mid(data_sp(15), 1, 3)
            'Dim propread_val2_rele As String = Mid(data_sp(16), 1, 4)
            'Dim propread_pm2_rele As String = Mid(data_sp(17), 1, 3)
            '-------------------------------------------------------------------
            Dim read_val1_IS As String = Mid(data_sp(10), 1, 4)
            Dim read_pm1_IS As String = Mid(data_sp(11), 1, 3)
            Dim read_val2_IS As String = Mid(data_sp(12), 1, 4)
            Dim read_pm2_IS As String = Mid(data_sp(13), 1, 3)

            temp_calc = Val(read_val1_IS) / fattore_divisione_temp2
            value1_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(read_val2_IS) / fattore_divisione_temp2
            value2_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

            value1_pm_reading.Text = Format(Val(read_pm1_IS), "000")

            value2_pm_reading.Text = Format(Val(read_pm2_IS), "000")


            '-------------------------------------------------------------------
            'Dim read_val1_rele As String = Mid(data_sp(22), 1, 4)
            'Dim read_pm1_rele As String = Mid(data_sp(23), 1, 3)
            'Dim read_val2_rele As String = Mid(data_sp(24), 1, 4)
            'Dim read_pm2_rele As String = Mid(data_sp(25), 1, 3)



            '-------------------------------------------------------------------

            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then




            Else
                Dim propmA_val1 As String = Mid(data_sp(14), 1, 4)
                Dim propmA_pm1 As String = Mid(data_sp(15), 1, 3)
                Dim propmA_val2 As String = Mid(data_sp(16), 1, 4)
                Dim propmA_pm2 As String = Mid(data_sp(17), 1, 3)


                temp_calc = Val(propmA_val1) / 100
                value1_mA_propmA.Text = Replace(temp_calc.ToString(), ",", ".")

                temp_calc = Val(propmA_val2) / 100
                value2_mA_propmA.Text = Replace(temp_calc.ToString(), ",", ".")

                value1_pm_propmA.Text = Format(Val(propmA_pm1), "000")

                value2_pm_propmA.Text = Format(Val(propmA_pm2), "000")




            End If






            function_java = ""




            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then

                enable_propmA.Visible = False
                enable_tab_propmA.Visible = False
                PropmA.Visible = False

                PropmA_testo.Visible = False


            Else
                enable_propmA.Visible = True

                enable_tab_propmA.Visible = True

                PropmA.Visible = True

                PropmA_testo.Visible = True


            End If


        End If



        If Val(main_function.get_version(riga_strumento.nome)) < 211 Then
            Button_Yes_No.Visible = False
            enable_Timer.Visible = False
        End If



        If Val(main_function.get_version(riga_strumento.nome)) >= 211 Then

            enable_Timer.Visible = True


            '           1 			// Modalità
            '			//-----	
            '			//-----				
            '			078			// Constant
            '           94:
            '			//-----
            '			//-----
            '			999			// Proportional (WM)
            '           112:
            '			//----
            '			//-----
            '			078			// Prop.(WM)+ Reading (Cl)
            '			12345		// IS
            '           157:
            '           100:
            '           980:
            '           80:
            '			//----------
            '			085			// Relè
            '           64958:
            '           757:
            '           99:
            '           482:
            '           98:
            '			//-----
            '			//-----
            '			0651			// reading  IS
            '           177:
            '           706:
            '           159:
            '			//----------
            '			0231		// reading  Relè
            '           23:
            '           596:

            '               79:


            '                (*get_data_mode()).Mode 
            '				0 : "Proportional (WM)"
            '				1 : "Constant"
            '				2 : "Prop.(WM)+ Reading"
            '				3 : "Reading"

            '				//---------------------------------------
            '				//---------------------------------------
            '				constant  AAA BBB    
            '				AAA  percentuale IS			(*get_data_constant()).CAPCL_IS
            '				BBB  percentuale relè		(*get_data_constant()).CAPCL_RL
            '				//---------------------------------------
            '				//---------------------------------------
            '				Proportional (WM)   AAA BBB 
            '				AAA  max 999 IS				(*get_data_prop()).PPM_IS_CL
            '				BBB  max 999 relè			(*get_data_prop()).PPM_RL_CL

            '				//---------------------------------------
            '				//---------------------------------------
            '				Prop.(WM)+ Reading (Cl)
            '				AAA  	percentuale IS		(*get_data_prop_read()).PERC_IS_CL
            '				BBBBB 	mc/h				(*get_data_prop_read()).MC_H_IS   MAX 65000
            '				CCCC    valore 1 			(*get_data_prop_read()).VALA_IS_CL   	
            '				DDD     perc 1				(*get_data_prop_read()).PMA_IS_CL
            '				EEEE    valore 2    		(*get_data_prop_read()).VALB_IS_CL	
            '				FFF     perc 2				(*get_data_prop_read()).PMB_IS_CL	
            '				//---------------------------------------
            '				GGG  	percentuale relè 	(*get_data_prop_read()).PERC_RL_CL
            '				HHHHH 	mc/h				(*get_data_prop_read()).MC_H_RL MAX 65000
            '				IIII    valore 1    		(*get_data_prop_read()).VALA_RL_CL	
            '				LLL     perc 1				(*get_data_prop_read()).PERCA_RL_CL
            '				MMMM    valore 2    		(*get_data_prop_read()).VALB_RL_CL	
            '				NNN     perc 2				(*get_data_prop_read()).PERCB_RL_CL
            '				//---------------------------------------
            '				//---------------------------------------
            '				reading  IS
            '				AAAA	valore 1      		(*get_data_read()).VALA_IS_CL
            '				BBB     P/m max 180			(*get_data_read()).PMA_IS_CL
            '				CCCC	valore 2			(*get_data_read()).VALB_IS_CL
            '				DDD		P/m max 180			(*get_data_read()).PMB_IS_CL
            '				//---------------------------------------
            '				EEEE	valore 1			(*get_data_read()).VALA_RL_CL
            '				FFF     Perc max 100		(*get_data_read()).PERCA_RL_CL
            '				GGGG	valore 2			(*get_data_read()).VALB_RL_CL
            '				HHH		Perc max 100		(*get_data_read()).PERCB_RL_CL

            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
            label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)


            'tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "1"
            'tabld1_2.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "2"
            'tabld1_3.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay")

            'tabld1_4.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
            'tabld1_5.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "relay")


            function_java = function_java + "activate_time_picker(1);"


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


            Dim mode As String = Mid(data_sp(1), 1, 1)
            '				0 : "Proportional (WM)"
            '				1 : "Constant"
            '				2 : "Prop.(WM)+ Reading"
            '				3 : "Reading"
            '4 : "prop ma"
            '5 : "ext is"
            Select Case mode
                Case "0"
                    Proportional.Checked = True
                Case "1"
                    Constant.Checked = True
                Case "2"
                    PropRead.Checked = True
                Case "3"
                    Reading.Checked = True
                Case "4"
                    PropmA.Checked = True
                Case "5"
                    ExtIS.Checked = True
            End Select



            Dim const_IS_cl As String = Mid(data_sp(2), 1, 3)
            '  Dim const_rele_cl As String = Mid(data_sp(3), 1, 3)
            value_constant.Text = Format(Val(const_IS_cl), "000")
            '-------------------------------------------------------------------
            Dim prop_IS_cl As String = Mid(data_sp(3), 1, 3)
            'Dim prop_rele_cl As String = Mid(data_sp(5), 1, 3)


            Dim temp_calc As Single = Val(prop_IS_cl) / 100
            value_ppm_proportional.Text = Replace(temp_calc.ToString(), ",", ".")



            '-------------------------------------------------------------------
            Dim propread_perc_IS As String = Mid(data_sp(4), 1, 3)
            Dim propread_mch_IS As String = Mid(data_sp(5), 1, 5)
            Dim propread_val1_IS As String = Mid(data_sp(6), 1, 4)
            Dim propread_pm1_IS As String = Mid(data_sp(7), 1, 3)
            Dim propread_val2_IS As String = Mid(data_sp(8), 1, 4)
            Dim propread_pm2_IS As String = Mid(data_sp(9), 1, 3)


            temp_calc = Val(propread_val1_IS) / fattore_divisione_temp2
            value1_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(propread_val2_IS) / fattore_divisione_temp2
            value2_mgl_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            value1_pm_propread.Text = Format(Val(propread_pm1_IS), "000")

            value2_pm_propread.Text = Format(Val(propread_pm2_IS), "000")

            temp_calc = Val(propread_mch_IS) / 100
            value_mch_propread.Text = Replace(temp_calc.ToString(), ",", ".")

            value_perc_propread.Text = Format(Val(propread_perc_IS), "000")

            '-------------------------------------------------------------------
            'Dim propread_perc_rele As String = Mid(data_sp(12), 1, 3)
            'Dim propread_mch_rele As String = Mid(data_sp(13), 1, 5)
            'Dim propread_val1_rele As String = Mid(data_sp(14), 1, 4)
            'Dim propread_pm1_rele As String = Mid(data_sp(15), 1, 3)
            'Dim propread_val2_rele As String = Mid(data_sp(16), 1, 4)
            'Dim propread_pm2_rele As String = Mid(data_sp(17), 1, 3)
            '-------------------------------------------------------------------
            Dim read_val1_IS As String = Mid(data_sp(10), 1, 4)
            Dim read_pm1_IS As String = Mid(data_sp(11), 1, 3)
            Dim read_val2_IS As String = Mid(data_sp(12), 1, 4)
            Dim read_pm2_IS As String = Mid(data_sp(13), 1, 3)

            temp_calc = Val(read_val1_IS) / fattore_divisione_temp2
            value1_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

            temp_calc = Val(read_val2_IS) / fattore_divisione_temp2
            value2_mgl_reading.Text = Replace(temp_calc.ToString(), ",", ".")

            value1_pm_reading.Text = Format(Val(read_pm1_IS), "000")

            value2_pm_reading.Text = Format(Val(read_pm2_IS), "000")


            '-------------------------------------------------------------------
            'Dim read_val1_rele As String = Mid(data_sp(22), 1, 4)
            'Dim read_pm1_rele As String = Mid(data_sp(23), 1, 3)
            'Dim read_val2_rele As String = Mid(data_sp(24), 1, 4)
            'Dim read_pm2_rele As String = Mid(data_sp(25), 1, 3)



            '-------------------------------------------------------------------

            Dim timer_yes_no As String = Mid(data_sp(18), 1, 1)





            Select Case timer_yes_no
                Case "0"
                    ' Timer No
                    Timer_NO.Checked = True
                    Button_Yes_No.Visible = False
                Case "1"
                    ' Timer Yes
                    Timer_YES.Checked = True
                    Button_Yes_No.Visible = True

                    value_start_timer.Text = Mid(data_sp(19), 1, 2) + ":" + Mid(data_sp(20), 1, 2)
                    value_stop_timer.Text = Mid(data_sp(21), 1, 2) + ":" + Mid(data_sp(22), 1, 2)
            End Select





            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then




            Else
                Dim propmA_val1 As String = Mid(data_sp(14), 1, 4)
                Dim propmA_pm1 As String = Mid(data_sp(15), 1, 3)
                Dim propmA_val2 As String = Mid(data_sp(16), 1, 4)
                Dim propmA_pm2 As String = Mid(data_sp(17), 1, 3)


                temp_calc = Val(propmA_val1) / 100
                value1_mA_propmA.Text = Replace(temp_calc.ToString(), ",", ".")

                temp_calc = Val(propmA_val2) / 100
                value2_mA_propmA.Text = Replace(temp_calc.ToString(), ",", ".")

                value1_pm_propmA.Text = Format(Val(propmA_pm1), "000")

                value2_pm_propmA.Text = Format(Val(propmA_pm2), "000")




            End If






            function_java = ""




            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then

                enable_propmA.Visible = False
                enable_tab_propmA.Visible = False
                PropmA.Visible = False

                PropmA_testo.Visible = False


            Else
                enable_propmA.Visible = True

                enable_tab_propmA.Visible = True

                PropmA.Visible = True

                PropmA_testo.Visible = True


            End If


        End If


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



        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        If Val(main_function.get_version(riga_strumento.nome)) < 125 Then



            If Proportional.Checked = True Then
                app_mode = "0"
            End If

            If Constant.Checked = True Then
                app_mode = "1"
            End If

            If PropRead.Checked = True Then
                app_mode = "2"
            End If

            If Reading.Checked = True Then
                app_mode = "3"
            End If

            If PropmA.Checked = True Then
                app_mode = "4"
            End If







            Dim fattore_ch1 As Integer
            Dim fattore_ch2 As Integer


            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2)




            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------
            Dim const_IS_cl_i As Integer
            Dim const_IS_cl_s As String


            Dim const_rele_cl_s As String


            const_IS_cl_i = Val(value_constant.Text)
            const_IS_cl_s = Format(const_IS_cl_i, "000")

            const_rele_cl_s = Format(100, "000")
            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------


            Dim prop_IS_cl_i As Integer
            Dim prop_IS_cl_s As String


            Dim prop_rele_cl_s As String


            'prop_IS_cl_i = Val(value_ppm_proportional.Text) * fattore_divisione_temp2
            prop_IS_cl_i = Val(value_ppm_proportional.Text) * 100

            prop_IS_cl_s = Format(prop_IS_cl_i, "000")

            prop_rele_cl_s = Format(100, "000")
            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------

            Dim propread_perc_IS_i As Integer
            Dim propread_perc_IS_s As String

            Dim propread_perc_rele_s As String

            propread_perc_IS_i = Val(value_perc_propread.Text)
            propread_perc_IS_s = Format(propread_perc_IS_i, "000")
            propread_perc_rele_s = Format(100, "000")


            Dim propread_mch_IS_i As Integer
            Dim propread_mch_IS_s As String
            Dim propread_mch_rele_s As String

            propread_mch_IS_i = Val(value_mch_propread.Text) * 100
            propread_mch_IS_s = Format(propread_mch_IS_i, "00000")

            propread_mch_rele_s = Format(100, "00000")

            Dim propread_val1_IS_mgl_i As Integer
            Dim propread_val1_IS_mgl_s As String
            Dim propread_val2_IS_mgl_i As Integer
            Dim propread_val2_IS_mgl_s As String

            Dim propread_val1_IS_pm_i As Integer
            Dim propread_val1_IS_pm_s As String
            Dim propread_val2_IS_pm_i As Integer
            Dim propread_val2_IS_pm_s As String


            Dim propread_val1_rele_mgl_s As String
            Dim propread_val2_rele_mgl_s As String
            Dim propread_val1_rele_perc_s As String
            Dim propread_val2_rele_perc_s As String



            propread_val1_IS_mgl_i = Val(value1_mgl_propread.Text) * fattore_divisione_temp2
            propread_val1_IS_mgl_s = Format(propread_val1_IS_mgl_i, "0000")

            propread_val2_IS_mgl_i = Val(value2_mgl_propread.Text) * fattore_divisione_temp2
            propread_val2_IS_mgl_s = Format(propread_val2_IS_mgl_i, "0000")

            propread_val1_rele_mgl_s = Format(100, "0000")
            propread_val2_rele_mgl_s = Format(80, "0000")


            propread_val1_IS_pm_i = Val(value1_pm_propread.Text)
            propread_val1_IS_pm_s = Format(propread_val1_IS_pm_i, "000")

            propread_val2_IS_pm_i = Val(value2_pm_propread.Text)
            propread_val2_IS_pm_s = Format(propread_val2_IS_pm_i, "000")

            propread_val1_rele_perc_s = Format(100, "000")
            propread_val2_rele_perc_s = Format(0, "000")


            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------



            Dim read_val1_IS_mgl_i As Integer
            Dim read_val1_IS_mgl_s As String
            Dim read_val2_IS_mgl_i As Integer
            Dim read_val2_IS_mgl_s As String

            Dim read_val1_IS_pm_i As Integer
            Dim read_val1_IS_pm_s As String
            Dim read_val2_IS_pm_i As Integer
            Dim read_val2_IS_pm_s As String


            Dim read_val1_rele_mgl_s As String
            Dim read_val2_rele_mgl_s As String
            Dim read_val1_rele_perc_s As String
            Dim read_val2_rele_perc_s As String



            read_val1_IS_mgl_i = Val(value1_mgl_reading.Text) * fattore_divisione_temp2
            read_val1_IS_mgl_s = Format(read_val1_IS_mgl_i, "0000")

            read_val2_IS_mgl_i = Val(value2_mgl_reading.Text) * fattore_divisione_temp2
            read_val2_IS_mgl_s = Format(read_val2_IS_mgl_i, "0000")

            read_val1_rele_mgl_s = Format(100, "0000")
            read_val2_rele_mgl_s = Format(80, "0000")


            read_val1_IS_pm_i = Val(value1_pm_reading.Text)
            read_val1_IS_pm_s = Format(read_val1_IS_pm_i, "000")

            read_val2_IS_pm_i = Val(value2_pm_reading.Text)
            read_val2_IS_pm_s = Format(read_val2_IS_pm_i, "000")

            read_val1_rele_perc_s = Format(100, "000")
            read_val2_rele_perc_s = Format(0, "000")


            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------
            Dim value1_mA_propmA_s As String
            Dim value2_mA_propmA_s As String
            Dim value1_pm_propmA_s As String
            Dim value2_pm_propmA_s As String


            Dim value1_mA_propmA_i As Integer
            Dim value2_mA_propmA_i As Integer
            Dim value1_pm_propmA_i As Integer
            Dim value2_pm_propmA_i As Integer





            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then

                Risultato = app_mode + const_IS_cl_s + const_rele_cl_s + prop_IS_cl_s + prop_rele_cl_s + propread_perc_IS_s + propread_mch_IS_s + propread_val1_IS_mgl_s + propread_val1_IS_pm_s + propread_val2_IS_mgl_s + propread_val2_IS_pm_s + propread_perc_rele_s + propread_mch_rele_s + propread_val1_rele_mgl_s + propread_val1_rele_perc_s + propread_val2_rele_mgl_s + propread_val2_rele_perc_s + read_val1_IS_mgl_s + read_val1_IS_pm_s + read_val2_IS_mgl_s + read_val2_IS_pm_s + read_val1_rele_mgl_s + read_val1_rele_perc_s + read_val2_rele_mgl_s + read_val2_rele_perc_s


            Else


                value1_mA_propmA_i = Val(value1_mA_propmA.Text) * 100
                value1_mA_propmA_s = Format(value1_mA_propmA_i, "0000")

                value2_mA_propmA_i = Val(value2_mA_propmA.Text) * 100
                value2_mA_propmA_s = Format(value2_mA_propmA_i, "0000")

                value1_pm_propmA_i = Val(value1_pm_propmA.Text)
                value1_pm_propmA_s = Format(value1_pm_propmA_i, "000")

                value2_pm_propmA_i = Val(value2_pm_propmA.Text)
                value2_pm_propmA_s = Format(value2_pm_propmA_i, "000")


                Risultato = app_mode + const_IS_cl_s + const_rele_cl_s + prop_IS_cl_s + prop_rele_cl_s + propread_perc_IS_s + propread_mch_IS_s + propread_val1_IS_mgl_s + propread_val1_IS_pm_s + propread_val2_IS_mgl_s + propread_val2_IS_pm_s + propread_perc_rele_s + propread_mch_rele_s + propread_val1_rele_mgl_s + propread_val1_rele_perc_s + propread_val2_rele_mgl_s + propread_val2_rele_perc_s + read_val1_IS_mgl_s + read_val1_IS_pm_s + read_val2_IS_mgl_s + read_val2_IS_pm_s + read_val1_rele_mgl_s + read_val1_rele_perc_s + read_val2_rele_mgl_s + read_val2_rele_perc_s + value1_mA_propmA_s + value1_pm_propmA_s + value2_mA_propmA_s + value2_pm_propmA_s
            End If






            Return id_485_impianto + "setpnw" + Risultato + "setpnwend" & Chr(13)

        End If

        If Val(main_function.get_version(riga_strumento.nome)) >= 125 Then



            If Proportional.Checked = True Then
                app_mode = "0"
            End If

            If Constant.Checked = True Then
                app_mode = "1"
            End If

            If PropRead.Checked = True Then
                app_mode = "2"
            End If

            If Reading.Checked = True Then
                app_mode = "3"
            End If

            If PropmA.Checked = True Then
                app_mode = "4"
            End If

            If ExtIS.Checked = True Then
                app_mode = "5"
            End If





            Dim fattore_ch1 As Integer
            Dim fattore_ch2 As Integer


            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp)
            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2)




            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------
            Dim const_IS_cl_i As Integer
            Dim const_IS_cl_s As String


            Dim const_rele_cl_s As String


            const_IS_cl_i = Val(value_constant.Text)
            const_IS_cl_s = Format(const_IS_cl_i, "000")

            const_rele_cl_s = Format(100, "000")
            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------


            Dim prop_IS_cl_i As Integer
            Dim prop_IS_cl_s As String


            Dim prop_rele_cl_s As String


            'prop_IS_cl_i = Val(value_ppm_proportional.Text) * fattore_divisione_temp2
            prop_IS_cl_i = Val(value_ppm_proportional.Text) * 100

            prop_IS_cl_s = Format(prop_IS_cl_i, "000")

            prop_rele_cl_s = Format(100, "000")
            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------

            Dim propread_perc_IS_i As Integer
            Dim propread_perc_IS_s As String

            Dim propread_perc_rele_s As String

            propread_perc_IS_i = Val(value_perc_propread.Text)
            propread_perc_IS_s = Format(propread_perc_IS_i, "000")
            propread_perc_rele_s = Format(100, "000")


            Dim propread_mch_IS_i As Integer
            Dim propread_mch_IS_s As String
            Dim propread_mch_rele_s As String

            propread_mch_IS_i = Val(value_mch_propread.Text) * 100
            propread_mch_IS_s = Format(propread_mch_IS_i, "00000")

            propread_mch_rele_s = Format(100, "00000")

            Dim propread_val1_IS_mgl_i As Integer
            Dim propread_val1_IS_mgl_s As String
            Dim propread_val2_IS_mgl_i As Integer
            Dim propread_val2_IS_mgl_s As String

            Dim propread_val1_IS_pm_i As Integer
            Dim propread_val1_IS_pm_s As String
            Dim propread_val2_IS_pm_i As Integer
            Dim propread_val2_IS_pm_s As String


            Dim propread_val1_rele_mgl_s As String
            Dim propread_val2_rele_mgl_s As String
            Dim propread_val1_rele_perc_s As String
            Dim propread_val2_rele_perc_s As String



            propread_val1_IS_mgl_i = Val(value1_mgl_propread.Text) * fattore_divisione_temp2
            propread_val1_IS_mgl_s = Format(propread_val1_IS_mgl_i, "0000")

            propread_val2_IS_mgl_i = Val(value2_mgl_propread.Text) * fattore_divisione_temp2
            propread_val2_IS_mgl_s = Format(propread_val2_IS_mgl_i, "0000")

            propread_val1_rele_mgl_s = Format(100, "0000")
            propread_val2_rele_mgl_s = Format(80, "0000")


            propread_val1_IS_pm_i = Val(value1_pm_propread.Text)
            propread_val1_IS_pm_s = Format(propread_val1_IS_pm_i, "000")

            propread_val2_IS_pm_i = Val(value2_pm_propread.Text)
            propread_val2_IS_pm_s = Format(propread_val2_IS_pm_i, "000")

            propread_val1_rele_perc_s = Format(100, "000")
            propread_val2_rele_perc_s = Format(0, "000")


            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------



            Dim read_val1_IS_mgl_i As Integer
            Dim read_val1_IS_mgl_s As String
            Dim read_val2_IS_mgl_i As Integer
            Dim read_val2_IS_mgl_s As String

            Dim read_val1_IS_pm_i As Integer
            Dim read_val1_IS_pm_s As String
            Dim read_val2_IS_pm_i As Integer
            Dim read_val2_IS_pm_s As String


            Dim read_val1_rele_mgl_s As String
            Dim read_val2_rele_mgl_s As String
            Dim read_val1_rele_perc_s As String
            Dim read_val2_rele_perc_s As String



            read_val1_IS_mgl_i = Val(value1_mgl_reading.Text) * fattore_divisione_temp2
            read_val1_IS_mgl_s = Format(read_val1_IS_mgl_i, "0000")

            read_val2_IS_mgl_i = Val(value2_mgl_reading.Text) * fattore_divisione_temp2
            read_val2_IS_mgl_s = Format(read_val2_IS_mgl_i, "0000")

            read_val1_rele_mgl_s = Format(100, "0000")
            read_val2_rele_mgl_s = Format(80, "0000")


            read_val1_IS_pm_i = Val(value1_pm_reading.Text)
            read_val1_IS_pm_s = Format(read_val1_IS_pm_i, "000")

            read_val2_IS_pm_i = Val(value2_pm_reading.Text)
            read_val2_IS_pm_s = Format(read_val2_IS_pm_i, "000")

            read_val1_rele_perc_s = Format(100, "000")
            read_val2_rele_perc_s = Format(0, "000")


            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------
            Dim value1_mA_propmA_s As String
            Dim value2_mA_propmA_s As String
            Dim value1_pm_propmA_s As String
            Dim value2_pm_propmA_s As String


            Dim value1_mA_propmA_i As Integer
            Dim value2_mA_propmA_i As Integer
            Dim value1_pm_propmA_i As Integer
            Dim value2_pm_propmA_i As Integer





            If Val(main_function.get_version(riga_strumento.nome)) < 117 Then

                Risultato = app_mode + const_IS_cl_s + const_rele_cl_s + prop_IS_cl_s + prop_rele_cl_s + propread_perc_IS_s + propread_mch_IS_s + propread_val1_IS_mgl_s + propread_val1_IS_pm_s + propread_val2_IS_mgl_s + propread_val2_IS_pm_s + propread_perc_rele_s + propread_mch_rele_s + propread_val1_rele_mgl_s + propread_val1_rele_perc_s + propread_val2_rele_mgl_s + propread_val2_rele_perc_s + read_val1_IS_mgl_s + read_val1_IS_pm_s + read_val2_IS_mgl_s + read_val2_IS_pm_s + read_val1_rele_mgl_s + read_val1_rele_perc_s + read_val2_rele_mgl_s + read_val2_rele_perc_s


            Else


                value1_mA_propmA_i = Val(value1_mA_propmA.Text) * 100
                value1_mA_propmA_s = Format(value1_mA_propmA_i, "0000")

                value2_mA_propmA_i = Val(value2_mA_propmA.Text) * 100
                value2_mA_propmA_s = Format(value2_mA_propmA_i, "0000")

                value1_pm_propmA_i = Val(value1_pm_propmA.Text)
                value1_pm_propmA_s = Format(value1_pm_propmA_i, "000")

                value2_pm_propmA_i = Val(value2_pm_propmA.Text)
                value2_pm_propmA_s = Format(value2_pm_propmA_i, "000")

                If Val(main_function.get_version(riga_strumento.nome)) < 211 Then
                    Risultato = app_mode + const_IS_cl_s + prop_IS_cl_s + propread_perc_IS_s + propread_mch_IS_s + propread_val1_IS_mgl_s + propread_val1_IS_pm_s + propread_val2_IS_mgl_s + propread_val2_IS_pm_s + read_val1_IS_mgl_s + read_val1_IS_pm_s + read_val2_IS_mgl_s + read_val2_IS_pm_s + value1_mA_propmA_s + value1_pm_propmA_s + value2_mA_propmA_s + value2_pm_propmA_s
                End If








                If Val(main_function.get_version(riga_strumento.nome)) >= 211 Then

                    Dim timer_on_off As String

                    If Timer_NO.Checked = True Then
                        timer_on_off = "0"
                    End If

                    If Timer_YES.Checked = True Then
                        timer_on_off = "1"
                    End If


                    '   data_temp = Date.Parse(value_biocide1_week1_domenica_feed.Text)

                    'Dim data_prima_date As Date
                    'Dim data_seconda_date As Date
                    'data_prima_date = Date.Parse(value_start_timer.Text)
                    'data_seconda_date = Date.Parse(value_stop_timer.Text)

                    Dim ora_start_s As String = Mid(value_start_timer.Text, 1, 2)
                    Dim min_start_s As String = Mid(value_start_timer.Text, 4, 2)
                    Dim ora_stop_s As String = Mid(value_stop_timer.Text, 1, 2)
                    Dim min_stop_s As String = Mid(value_stop_timer.Text, 4, 2)

                    Risultato = app_mode + const_IS_cl_s + prop_IS_cl_s + propread_perc_IS_s + propread_mch_IS_s + propread_val1_IS_mgl_s + propread_val1_IS_pm_s + propread_val2_IS_mgl_s + propread_val2_IS_pm_s + read_val1_IS_mgl_s + read_val1_IS_pm_s + read_val2_IS_mgl_s + read_val2_IS_pm_s + value1_mA_propmA_s + value1_pm_propmA_s + value2_mA_propmA_s + value2_pm_propmA_s + timer_on_off + ora_start_s + min_start_s + ora_stop_s + min_stop_s

                End If

            End If






            Return id_485_impianto + "setpnw" + Risultato + "setpnwend" & Chr(13)

        End If


    End Function

    Protected Sub save_setpointltb_new_Click(sender As Object, e As EventArgs) Handles save_setpointltb_new.Click
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

        Response.Redirect("~/ltb.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=1" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class