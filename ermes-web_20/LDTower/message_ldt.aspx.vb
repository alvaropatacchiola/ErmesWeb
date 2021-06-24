Public Class message_ldt
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub message_ldt_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")

            posiziona_messageld(nome_impianto, codice_impianto, id_485_impianto)

        End If
    End Sub
    Public Sub posiziona_messageld(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim message_value() As String

        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_message_newld.OnClientClick = String.Format("salva_dati(""{0}""); return false;",
                    ClientScript.GetPostBackEventReference(save_message_newld, ""))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next


        message_value = main_function.get_split_str(riga_strumento.value6)
        'messaggi sms
        If message_value.Length >= 4 Then
            value_sms1_id.Text = message_value(1).Replace("-", "")
            value_sms2_id.Text = message_value(2).Replace("-", "")
            value_sms3_id.Text = (message_value(3).Replace("-", "")).Split("stbiorend")(0)
        End If
        message_value = main_function.get_split_str(riga_strumento.value1)
        If message_value.Length >= 3 Then
            value_mail1_id.Text = message_value(1).Replace("-", "")
            value_mail2_id.Text = (message_value(2).Replace("-", "")).Split("unitsrend")(0)
        End If


    End Sub
    Private Function create_function_name(ByVal limit_char As Integer, ByVal start_string As String) As String
        Dim temp_string As String = ""
        Dim i As Integer = 0
        temp_string = start_string
        If temp_string.Length <= limit_char Then
            Dim lunghezza_aggiunta As Integer = limit_char - temp_string.Length
            For i = 1 To lunghezza_aggiunta
                temp_string = temp_string + "-"
            Next
        End If
        Return temp_string
    End Function
    Private Function MakeMessageSMS() As String
        Dim string_connect As String = ""
        Dim temp_string As String = ""

        string_connect = string_connect + create_function_name(28, value_sms1_id.Text)
        string_connect = string_connect + create_function_name(28, value_sms2_id.Text)
        string_connect = string_connect + create_function_name(28, value_sms3_id.Text)
        Return id_485_impianto + "sssmswMT" + string_connect + "sssmswend" & Chr(13)

    End Function
    Private Function MakeMessageMail() As String

        Dim string_connect As String = ""
        Dim temp_string As String = ""

        string_connect = string_connect + create_function_name(42, value_mail1_id.Text)
        string_connect = string_connect + create_function_name(42, value_mail2_id.Text)

        ' Return id_485_impianto + "2Dph" + string_connect + "end" & Chr(13)
        Return id_485_impianto + "emailwMT" + string_connect + "emailwend" & Chr(13)

    End Function

    Protected Sub save_message_newld_Click(sender As Object, e As EventArgs) Handles save_message_newld.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeMessageMail()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        Else
            new_setpoint = MakeMessageSMS()
            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        End If
        write_setpoint_new.client_close()

        'javascript_function.call_function_javascript_onload(Page, "result_setpoint_change();")
        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=14" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class