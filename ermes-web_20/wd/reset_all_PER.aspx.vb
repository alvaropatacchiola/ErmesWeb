Public Class reset_all_PER
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub flow_ld_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_reset_wd(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output", "Out Of Range Alarm", "Min/max High", "Min/max Low", "Time (min)")
        End If
    End Sub
    Public Sub posiziona_reset_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                       ByVal time_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim flow_value() As String
        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script

        ' abilito pulsante modifica
        save_reset_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_reset_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next


    



        alarm_reset_no.Checked = True 'dis

        java_script_flow.call_function_javascript_onload(Page, function_java)
    End Sub
    Private Function MakeFlowString() As String


       
        If alarm_reset.Checked = True Then 'disable
            Return id_485_impianto + "resalw" + "resalwend" & Chr(13)
        End If
       

    End Function

    Protected Sub save_reset_new_Click(sender As Object, e As EventArgs) Handles save_reset_new.Click
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

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=25" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class