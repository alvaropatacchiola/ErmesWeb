Public Class flow_lds
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub flow_lds_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
       Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_flow_lds(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "out_of_range_alarm"), GetGlobalResourceObject("ld_global", "min_max_high"), GetGlobalResourceObject("ld_global", "min_max_low"), GetGlobalResourceObject("ld_global", "time"))
        End If
    End Sub
    Public Sub posiziona_flow_lds(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                       ByVal time_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim flow_value() As String
        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script

        ' abilito pulsante modifica
        save_flowlds_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_flowlds_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        flow_value = main_function.get_split_str(riga_strumento.value11)

        Dim mode_flow As String
        Dim time_flow As String

        mode_flow = Mid(flow_value(1), 1, 1)
        time_flow = Mid(flow_value(2), 1, 2)


        If mode_flow = "0" Then 'disable
            alarm_flow_disable.Checked = True 'dis
            function_java = "disable_flow();"
        End If
        If mode_flow = "1" Then 'reverse
            alarm_flow_reverse.Checked = True 'rev
            function_java = "enable_flow();"
        End If
        If mode_flow = "2" Then 'direct
            alarm_flow_direct.Checked = True 'dir
            function_java = "enable_flow();"
        End If
        value_alarm_flow_time.Text = Val(time_flow).ToString
        java_script_flow.call_function_javascript_onload(Page, function_java)
    End Sub

    Private Function MakeFlowString() As String


        Dim Risultato As String
        Dim app_mode_flow As String
        Dim app_time_flow As String

        If alarm_flow_disable.Checked = True Then 'disable
            app_mode_flow = "0"
        End If
        If alarm_flow_direct.Checked = True Then 'direct
            app_mode_flow = "2"
        End If
        If alarm_flow_reverse.Checked = True Then 'reverse
            app_mode_flow = "1"
        End If


        'app_time_flow = Format(value_alarm_flow_time.Text, "00")
        app_time_flow = Format(Val(value_alarm_flow_time.Text), "00")

        Risultato = app_mode_flow + app_time_flow


        Return id_485_impianto + "flowsw" + Risultato + "flowswend" & Chr(13)

    End Function

    Protected Sub save_flowlds_new_Click(sender As Object, e As EventArgs) Handles save_flowlds_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeFlowString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=13" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class