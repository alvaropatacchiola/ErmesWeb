Public Class rs485
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
   
    Private Sub rs485_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")

            posiziona_485(nome_impianto, codice_impianto, id_485_impianto)

        End If
    End Sub
    Public Sub posiziona_485(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim label_str As String = ""

        tabella_strumento = (Session("strumento"))
        ' abilito pulsante modifica
        save_rs485_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_rs485_new, ""))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next


        label_str = main_function.get_lebel_485(riga_strumento.nome)
        Literal1.Text = id_485_impianto
        label_485.Text = label_str

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

    Private Function MakeName() As String

        Dim string_connect As String = ""
        Dim temp_string As String = ""

        string_connect = string_connect + create_function_name(16, label_485.Text)
        Return id_485_impianto + "2Iph" + string_connect + "end" & Chr(13)
    End Function

    Protected Sub save_rs485_new_Click(sender As Object, e As EventArgs) Handles save_rs485_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeName()

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
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=15&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class