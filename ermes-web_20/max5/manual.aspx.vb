Public Class manual
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            ' abilito pulsante modifica
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")

            save_manual_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                        ClientScript.GetPostBackEventReference(save_manual_new, ""))

        End If
    End Sub
    Private Function MakeManual() As String

        Dim string_connect As String = ""
        Dim manual_enabled As String = "0"

        If check_relay1_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_relay1_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_relay2_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_relay2_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_relay3_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_relay3_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_relay4_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_relay4_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_relay5_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_relay5_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_relay6_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_relay6_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If

        If check_pulse1_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_pulse1_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_pulse2_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_pulse2_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_pulse3_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_pulse3_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_pulse4_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_pulse4_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_pulse5_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_pulse5_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If
        If check_pulse6_id.Checked Then
            manual_enabled = "1"
            string_connect = string_connect + "1" + Format(Val(value_pulse6_id.Text), "00")
        Else
            string_connect = string_connect + "000"
        End If

        Return id_485_impianto + "2Gph" + string_connect + manual_enabled + "end" & Chr(13)

    End Function

    Protected Sub save_manual_new_Click(sender As Object, e As EventArgs) Handles save_manual_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeManual()

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
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=13&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class