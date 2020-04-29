Public Class passcode
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""


  

    Private Sub passcode_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then

            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_passcode(nome_impianto, codice_impianto, id_485_impianto, "Password")
        End If
    End Sub
    Public Sub posiziona_passcode(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                 ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim password_value() As String

        save_password_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                   ClientScript.GetPostBackEventReference(save_password_new, ""))

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        password_value = main_function.get_split_str(riga_strumento.value11)
        set_password(password_value(0))

    End Sub

    Public Sub set_password(ByVal date_str As String)
        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(1, 1) As String

        set_variable_javascript(0, 0) = "password_c"
        set_variable_javascript(0, 1) = """" + Mid(date_str, 3, 4) + """"
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)
        'ASPxTextBox6.Text = (Mid(date_str, 37, 4))
    End Sub
    Private Function MakePassword() As String
        Return id_485_impianto + "passcwMT" + new_password.Text + "passcwend" & Chr(13)

    End Function
    Protected Sub save_password_new_Click(sender As Object, e As EventArgs) Handles save_password_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakePassword()

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
        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=11&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class