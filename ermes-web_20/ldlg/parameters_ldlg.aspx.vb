Public Class parameters_ldlg
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then

            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_password(nome_impianto, codice_impianto, id_485_impianto, "Password")
        End If
    End Sub
    Public Sub posiziona_password(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim password_value() As String

        ' abilito pulsante modifica
        save_password_ldlg_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_password_ldlg_new, ""))


        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        password_value = main_function.get_split_str(riga_strumento.value8)
        set_password(password_value(1), password_value(2))

    End Sub
    Public Sub set_password(ByVal service As String, ByVal log As String)
        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(2, 1) As String
        Dim java_script_variable1 As java_script = New java_script
        Dim function_javascript As String = ""

        function_javascript = function_javascript + "set_password();"
        set_variable_javascript(0, 0) = "password_s"
        set_variable_javascript(0, 1) = """" + service + """"
        old_password_service.Text = service
        new_password_service.Text = service
        confirm_password_service.Text = service

        set_variable_javascript(1, 0) = "password_l"
        set_variable_javascript(1, 1) = """" + log + """"
        old_password_log.Text = log
        new_password_log.Text = log
        confirm_password_log.Text = log

        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 2)
        java_script_variable1.call_function_javascript_onload(Page, function_javascript)

        'ASPxTextBox6.Text = (Mid(date_str, 37, 4))
    End Sub
    Private Function MakePassword() As String
        Dim risultato As String
        risultato = id_485_impianto + "paramw" + Format(Val(new_password_service.Text), "0000") + Format(Val(new_password_log.Text), "0000") + "paramwend" & Chr(13)
        Return risultato

    End Function

    Protected Sub save_password_ldlg_new_Click(sender As Object, e As EventArgs) Handles save_password_ldlg_new.Click
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
        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=72" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)


    End Sub
End Class