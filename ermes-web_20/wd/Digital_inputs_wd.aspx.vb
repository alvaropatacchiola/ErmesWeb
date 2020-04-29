Public Class WebForm6
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub Digital_wd_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
      Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_digital_wd(nome_impianto, codice_impianto, id_485_impianto, canale, "Digital Inputs")
        End If
    End Sub
    Public Sub posiziona_digital_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                              ByVal Digital_traduzione As String)
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
        Dim etichetta_digital As String = ""
        Dim etichetta_digital2 As String = ""
        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_Digital_Input_wd_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_Digital_Input_wd_new, ""))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        data_sp = main_function.get_split_str(riga_strumento.value16)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)





        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2))
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1))
        Label7.Text = GetGlobalResourceObject("ld_global", "level") + " " + label_canale_temp
        tabld1_1.Text = Label7.Text

        'label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2))
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(2))

        Literal11.Text = GetGlobalResourceObject("ld_global", "level") + " " + label_canale2_temp
        tabld1_2.Text = Literal11.Text


        Dim level1_mode As String = Mid(data_sp(2), 1, 1) ' 0-> NO 1-> NC
        Dim level2_mode As String = Mid(data_sp(3), 1, 1) ' 0-> NO 1-> NC
        Dim stdby_mode As String = Mid(data_sp(1), 1, 1) ' 0-> NO 1-> NC
       
        function_java = ""
        Select Case level1_mode

            Case "0" 'N.O.
                
                NO_ph.Checked = True
            Case "1" 'N.C.
               
                NC_ph.Checked = True
        End Select

        Select Case level2_mode

            Case "0" 'N.O.

                NO_cl.Checked = True
            Case "1" 'N.C.
                
                NC_cl.Checked = True
        End Select
       
        Select Case stdby_mode

            Case "0" 'N.O.
                
                NO_STBY.Checked = True
            Case "1" 'N.C.
                
                NC_STBY.Checked = True

        End Select
        

        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_digital)
        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_digital2)
        

        setting_label_digital(label_canale_temp, " ", GetGlobalResourceObject("ld_global", "level"), "N.O.", "N.C.", Label7, literal1, literal2)
        setting_label_digital(label_canale2_temp, " ", GetGlobalResourceObject("ld_global", "level"), "N.O.", "N.C.", Literal11, literal12, literal13)
        setting_label_digital(" ", " ", GetGlobalResourceObject("ld_global", "standby"), "N.O.", "N.C.", Literal22, literal23, literal24)
     



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
    Private Sub setting_label_digital(ByVal etichetta_digital As String, ByVal numero_canale As String, ByVal traduzione_digital As String, ByVal traduzione_NO As String, ByVal traduzione_NC As String, ByVal literal1 As Literal, _
                                       ByVal Literal2 As Literal, ByVal Literal3 As Literal)

        literal1.Text = traduzione_digital + "  " + etichetta_digital
        Literal2.Text = traduzione_NO + "  "

        Literal3.Text = traduzione_NC + "  "

    End Sub
  
    Private Function MakeDigString() As String


        Dim Risultato As String
        Dim app_val_STBY As String
        Dim app_val_LEVPH As String
        Dim app_val_LEVCL As String

        If NO_STBY.Checked = True Then 'NO
            app_val_STBY = "0"
        Else
            app_val_STBY = "1"
        End If


        If NO_ph.Checked = True Then 'NO
            app_val_LEVPH = "0"

        Else
            app_val_LEVPH = "1"
        End If


        If NO_cl.Checked = True Then 'NO
            app_val_LEVCL = "0"
        Else
            app_val_LEVCL = "1"
        End If

        Risultato = app_val_STBY + app_val_LEVPH + app_val_LEVCL

        Return id_485_impianto + "diginw" + Risultato + "diginwend" & Chr(13)
    End Function

    Protected Sub save_Digital_Input_wd_new_Click(sender As Object, e As EventArgs) Handles save_Digital_Input_wd_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeDigString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=4" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class