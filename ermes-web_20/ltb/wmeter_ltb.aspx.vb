Public Class wmeter_ltb
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub wmeter_ltb_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_wmeter_ltb(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "setpoint"))
        End If
    End Sub
    Public Sub posiziona_wmeter_ltb(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
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
        save_wmeterltb_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_wmeterltb_new, ""))


        data_sp = main_function.get_split_str(riga_strumento.value20)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)


       

       



        java_script_ch1_pulse_variable.set_url_setpoint(Page, set_variable_javascript, 5)
        java_script_ch1_pulse1.call_function_javascript_onload(Page, function_java)


        Dim mode As String = Mid(data_sp(1), 1, 1)
  

        Select Case mode
            Case "0"
                imp_lit.Checked = True
            Case "1"
                lit_imp.Checked = True
            Case "2"
                mA.Checked = True

        End Select

        Dim resolution As String = Mid(data_sp(4), 1, 1)

        Select Case resolution
            Case "0"
                ZeromA.Checked = True
            Case "1"
                QuattromA.Checked = True

        End Select



        Dim valore As Single = Mid(data_sp(2), 1, 5)
        Dim maxflow As Single = Mid(data_sp(3), 1, 5)
        Dim timeout As Integer = Mid(data_sp(5), 1, 5)

        value_timeout.Text = Format(Val(timeout), "000")


        Dim temp_calc As Single = Val(valore) / 10
        value_wm.Text = Replace(temp_calc.ToString(), ",", ".")

        temp_calc = Val(maxflow) / 10
        value_resol.Text = Replace(temp_calc.ToString(), ",", ".")

      

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
   
    Private Function MakeSETString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0


        Dim app_mode As String
        Dim app_mA As String


        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)


        If imp_lit.Checked = True Then
            app_mode = 0
        End If

        If lit_imp.Checked = True Then
            app_mode = 1
        End If

        If mA.Checked = True Then
            app_mode = 2
        End If

        If ZeromA.Checked = True Then
            app_mA = 0
        End If

        If QuattromA.Checked = True Then
            app_mA = 1
        End If
  
        Dim valuewm_i As Single
        Dim valuewm_s As String
        valuewm_i = Val(value_wm.Text) * 10
        valuewm_s = Format(valuewm_i, "00000")

        Dim valueflow_i As Single
        Dim valueflow_s As String
        valueflow_i = Val(value_resol.Text) * 10
        valueflow_s = Format(valueflow_i, "00000")
        '---------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------
        Dim timeout_i As Single
        Dim timeout_s As String

        timeout_i = Val(value_timeout.Text)
        timeout_s = Format(timeout_i, "000")



        Risultato = app_mode + valuewm_s + valueflow_s + app_mA + timeout_s
        Return id_485_impianto + "wtmetw" + Risultato + "wtmetwend" & Chr(13)

    End Function
    Protected Sub save_wmeterltb_new_Click(sender As Object, e As EventArgs) Handles save_wmeterltb_new.Click
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

        Response.Redirect("~/ltb.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=2" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class