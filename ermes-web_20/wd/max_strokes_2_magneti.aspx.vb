Public Class max_strokes_2_magneti
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
   
    Private Sub max_strokes_2_magneti_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
          Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_max_2_magneti_wd(nome_impianto, codice_impianto, id_485_impianto, canale, "Max Strokes Settings")
        End If
    End Sub
    Public Sub posiziona_max_2_magneti_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal max_strokes_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim strokes_value() As String
        Dim calibrz_value() As String
        Dim label_canale_temp As String = ""
        Dim label_canale2_temp As String = ""

        Dim full_scale_temp As Single
        Dim full_scale_temp2 As Single
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0
        Dim etichetta_setpoint As String = ""
        Dim etichetta_setpoint2 As String = ""

        ' abilito pulsante modifica
        save_maxstrokes2magneti_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_maxstrokes2magneti_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)



        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(1), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)

        'label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
        label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)


        'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), "", "", , "")

        'label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), "", "", , "")


        tabld1_1.Text = label_canale_temp + " " + GetGlobalResourceObject("wd_global", "strokes")
        tabld1_4.Text = label_canale2_temp + " " + GetGlobalResourceObject("wd_global", "strokes")
        Literal1.Text = GetGlobalResourceObject("wd_global", "strokes") + " " + label_canale_temp
        Literal40.Text = GetGlobalResourceObject("wd_global", "strokes") + " " + label_canale2_temp


        strokes_value = main_function.get_split_str(riga_strumento.value14)
       


        Dim temp_calc As Single = Val(Mid(strokes_value(1), 1, 3))
        value1_ph_stk.Text = temp_calc.ToString
        temp_calc = Val(Mid(strokes_value(2), 1, 3))
        value1_cl_stk.Text = temp_calc.ToString




    End Sub




    Private Function MakeSETString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim calibrz_value() As String

        Dim Risultato As String
        Dim app_val_ph As String
        Dim app_val_cl As String


        



        app_val_ph = Format(Val(value1_ph_stk.Text), "000")
        app_val_cl = Format(Val(value1_cl_stk.Text), "000")




        
        Risultato = app_val_ph + app_val_cl
        


        Return id_485_impianto + "setskw" + Risultato + "setskwend" & Chr(13)

    End Function


    Protected Sub save_maxstrokes2magneti_new_Click(sender As Object, e As EventArgs) Handles save_maxstrokes2magneti_new.Click
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

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=11" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class