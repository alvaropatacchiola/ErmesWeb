Public Class Circulation
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub Circulation_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_Circulation_lds(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_Circulation_lds(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable


        Dim Circulation_value() As String


        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script
        ' abilito pulsante modifica
        save_Circulation_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_Circulation_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        Circulation_value = main_function.get_split_str(riga_strumento.value21)
       

        Dim enable As String
      


        enable = Mid(Circulation_value(1), 1, 1)
      

        If enable = "0" Then 'disable
            Circulation_disable.Checked = True
            function_java = function_java + "disable_Circulation();"
        End If

        If enable = "1" Then 'enable
            Circulation_enable.Checked = True
            function_java = function_java + "enable_Circulation();"
        End If
        java_script_flow.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function MakeCirculationString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable



        Dim Risultato As String
        Dim app_mode_Circulation As String



        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next


        If Circulation_enable.Checked = True Then 'enable
            app_mode_Circulation = "1"
        Else
            app_mode_Circulation = "0"
        End If






        Risultato = app_mode_Circulation

        Return id_485_impianto + "circow" + Risultato + "circowend" & Chr(13)

    End Function
    Protected Sub save_Circulation_new_Click(sender As Object, e As EventArgs) Handles save_Circulation_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeCirculationString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=38" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class