Public Class setpoint_diff
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Shared spma As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            spma = Page.Request("spma")
            posiziona_setpoint_diff(nome_impianto, codice_impianto, id_485_impianto, spma, GetGlobalResourceObject("ld_global", "setpoint"))
        End If
    End Sub
    Public Sub posiziona_setpoint_diff(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                  ByVal setpoint_traduzione As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim setpntr_value() As String
        Dim numero_canali As Integer = 0
        Dim config_value() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim i As Integer = 0
        ' abilito pulsante modifica
        save_setpointdiff_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointdiff_new, ""))

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        setpntr_value = main_function.get_split_str(riga_strumento.value7)
        config_value = main_function.get_split_str(riga_strumento.value1)
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
        message_channel.Text = main_function_config.get_name_differential(setpntr_value)
        value_name.Text = main_function_config.get_name_differential(setpntr_value)

        For i = 1 To numero_canali
            Dim ListItem = New ListItem("WM" + Format(i, "0"), Format(i, "0"))
            Dim ListItem1 = New ListItem("WM" + Format(i, "0"), Format(i, "0"))
            operation1.Items.Add(ListItem)

            operation2.Items.Add(ListItem1)
        Next
        operation1.SelectedValue = (main_function_config.get_operation1_differential(setpntr_value)).ToString

        operation.SelectedValue = (main_function_config.get_operation_differential(setpntr_value)).ToString
        operation2.SelectedValue = (main_function_config.get_operation2_differential(setpntr_value)).ToString

        value_enable.SelectedIndex = (main_function_config.get_enable_differential(setpntr_value))
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

    Private Function MakeSETString() As String
        Dim string_send As String = ""

        string_send = id_485_impianto + "setpnBw" + create_function_name(15, value_name.Text) + operation1.SelectedValue + operation2.SelectedValue + operation.SelectedValue + value_enable.SelectedValue + "setpnBwend"

    End Function
    Protected Sub save_setpointdiff_new_Click(sender As Object, e As EventArgs) Handles save_setpointdiff_new.Click
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
        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=69" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
        
    End Sub
End Class