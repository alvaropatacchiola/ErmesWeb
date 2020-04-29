Public Class parameters
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub parameters_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_parameters_ld(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "probe_failure"))
        End If
    End Sub
    Public Sub posiziona_parameters_ld(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal probe_fail_alarm_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim parameters_value() As String
        Dim calibrz_value() As String


        ' abilito pulsante modifica
        save_parameters_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_parameters_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        parameters_value = main_function.get_split_str(riga_strumento.value8)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        Dim Delay As String
        Dim Mode As String
        Dim New_Pass As String
        'Dim Current_Pass As String
        Dim Tau As String

        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(1, 1) As String

        set_variable_javascript(0, 0) = "password_c"
        set_variable_javascript(0, 1) = """" + Mid(parameters_value(1), 1, 4) + """"
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)

        Delay = Mid(parameters_value(2), 1, 2)
        Mode = Mid(parameters_value(3), 1, 1)
        Tau = Mid(parameters_value(4), 1, 2)

        confirm_password.Text = Mid(parameters_value(1), 1, 4)
        new_password.Text = Mid(parameters_value(1), 1, 4)
        old_password.Text = Mid(parameters_value(1), 1, 4)

        value_ph_feeding_delay.Text = Val(Delay).ToString
        value_ph_tau.Text = Val(Tau).ToString
        If Mode = 1 Then
            no_priority.Checked = True
        Else
            ph_priority.Checked = True
        End If

        If Mid(calibrz_value(1), 1, 2) <> "23" Then ' se il ch1 è diverso da pH non c'è mai priorità
            enable_priority.Visible = False
        End If
        ' rel 2.3.3
        If Mid(calibrz_value(1), 1, 2) = "23" And Mid(calibrz_value(2), 1, 2) = "23" Then ' se LDPHPH non c'è mai priorità
            enable_priority.Visible = False
        End If

    End Sub
    Private Function MakeParamString() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim app As String

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        If Mid(calibrz_value(1), 1, 2) <> "23" Then ' se il ch1 è diverso da pH non c'è mai priorità
            no_priority.Checked = True

        End If
        ' rel 2.3.3
        If Mid(calibrz_value(1), 1, 2) And Mid(calibrz_value(2), 1, 2) = "23" Then ' se LDPHPH non c'è mai priorità
            no_priority.Checked = True
        End If


        If no_priority.Checked = True Then
            app = "1"
        Else
            app = "0"
        End If


        Risultato = new_password.Text + Format(Val(value_ph_feeding_delay.Text), "00") + app + Format(Val(value_ph_tau.Text), "00")
        Return id_485_impianto + "paramw" + Risultato + "paramwend" & Chr(13)




    End Function

    Protected Sub save_parameters_new_Click(sender As Object, e As EventArgs) Handles save_parameters_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeParamString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=7" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class