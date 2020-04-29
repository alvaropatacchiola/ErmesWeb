Public Class setpoint_ldma
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Shared spma As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String = ""
        result = page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = page.Request("codice")
            id_485_impianto = page.Request("id_485")
            statistica = Page.Request("statistica")
            spma = Page.Request("spma")
            posiziona_setpoint_ldma(nome_impianto, codice_impianto, id_485_impianto, spma, GetGlobalResourceObject("ld_global", "setpoint"))
        End If

    End Sub

    Public Sub posiziona_setpoint_ldma(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                          ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim setpntr_value() As String
        ' abilito pulsante modifica
        save_setpointldma_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointldma_new, ""))

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        setpntr_value = main_function.get_split_str(riga_strumento.value7)


        Select Case canale
            Case "1"
                message_channel.Text = main_function_config.get_name_level1(setpntr_value)
                value_level_name.Text = main_function_config.get_name_level1(setpntr_value)
                value_level_4ma.Text = Replace((main_function_config.get_4ma_level1(setpntr_value) / 10).ToString, ",", ".")
                value_level_20ma.Text = Replace((main_function_config.get_20ma_level1(setpntr_value) / 10).ToString, ",", ".")
                value_level_alarm.Text = Replace((main_function_config.get_soglia_level1(setpntr_value) / 10).ToString, ",", ".")
                If main_function_config.get_msg_level1(setpntr_value) Then
                    value_level_msg.SelectedIndex = 1
                Else
                    value_level_msg.SelectedIndex = 0
                End If
            Case "2"
                message_channel.Text = main_function_config.get_name_level2(setpntr_value)
                value_level_name.Text = main_function_config.get_name_level2(setpntr_value)
                value_level_4ma.Text = Replace((main_function_config.get_4ma_level2(setpntr_value) / 10).ToString, ",", ".")
                value_level_20ma.Text = Replace((main_function_config.get_20ma_level2(setpntr_value) / 10).ToString, ",", ".")
                value_level_alarm.Text = Replace((main_function_config.get_soglia_level2(setpntr_value) / 10).ToString, ",", ".")
                If main_function_config.get_msg_level2(setpntr_value) Then
                    value_level_msg.SelectedIndex = 1
                Else
                    value_level_msg.SelectedIndex = 0
                End If

            Case "3"
                message_channel.Text = main_function_config.get_name_level3(setpntr_value)
                value_level_name.Text = main_function_config.get_name_level3(setpntr_value)
                value_level_4ma.Text = Replace((main_function_config.get_4ma_level3(setpntr_value) / 10).ToString, ",", ".")
                value_level_20ma.Text = Replace((main_function_config.get_20ma_level3(setpntr_value) / 10).ToString, ",", ".")
                value_level_alarm.Text = Replace((main_function_config.get_soglia_level3(setpntr_value) / 10).ToString, ",", ".")
                If main_function_config.get_msg_level3(setpntr_value) Then
                    value_level_msg.SelectedIndex = 1
                Else
                    value_level_msg.SelectedIndex = 0
                End If

            Case "4"
                message_channel.Text = main_function_config.get_name_level4(setpntr_value)
                value_level_name.Text = main_function_config.get_name_level4(setpntr_value)
                value_level_4ma.Text = Replace((main_function_config.get_4ma_level4(setpntr_value) / 10).ToString, ",", ".")
                value_level_20ma.Text = Replace((main_function_config.get_20ma_level4(setpntr_value) / 10).ToString, ",", ".")
                value_level_alarm.Text = Replace((main_function_config.get_soglia_level4(setpntr_value) / 10).ToString, ",", ".")
                If main_function_config.get_msg_level4(setpntr_value) Then
                    value_level_msg.SelectedIndex = 1
                Else
                    value_level_msg.SelectedIndex = 0
                End If

            Case "5"
                message_channel.Text = main_function_config.get_name_level5(setpntr_value)
                value_level_name.Text = main_function_config.get_name_level5(setpntr_value)
                value_level_4ma.Text = Replace((main_function_config.get_4ma_level5(setpntr_value) / 10).ToString, ",", ".")
                value_level_20ma.Text = Replace((main_function_config.get_20ma_level5(setpntr_value) / 10).ToString, ",", ".")
                value_level_alarm.Text = Replace((main_function_config.get_soglia_level5(setpntr_value) / 10).ToString, ",", ".")
                If main_function_config.get_msg_level5(setpntr_value) Then
                    value_level_msg.SelectedIndex = 1
                Else
                    value_level_msg.SelectedIndex = 0
                End If

        End Select

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

        Select Case spma
            Case "1"
                string_send = id_485_impianto + "setpn1w" + create_function_name(15, value_level_name.Text) + Format(Val(value_level_4ma.Text) * 10, "0000") + Format(Val(value_level_20ma.Text) * 10, "0000") + Format(Val(value_level_alarm.Text) * 10, "0000") + value_level_msg.SelectedValue + "setpn1wend"
            Case "2"
                string_send = id_485_impianto + "setpn2w" + create_function_name(15, value_level_name.Text) + Format(Val(value_level_4ma.Text) * 10, "0000") + Format(Val(value_level_20ma.Text) * 10, "0000") + Format(Val(value_level_alarm.Text) * 10, "0000") + value_level_msg.SelectedValue + "setpn2wend"
            Case "3"
                string_send = id_485_impianto + "setpn3w" + create_function_name(15, value_level_name.Text) + Format(Val(value_level_4ma.Text) * 10, "0000") + Format(Val(value_level_20ma.Text) * 10, "0000") + Format(Val(value_level_alarm.Text) * 10, "0000") + value_level_msg.SelectedValue + "setpn3wend"
            Case "4"
                string_send = id_485_impianto + "setpn4w" + create_function_name(15, value_level_name.Text) + Format(Val(value_level_4ma.Text) * 10, "0000") + Format(Val(value_level_20ma.Text) * 10, "0000") + Format(Val(value_level_alarm.Text) * 10, "0000") + value_level_msg.SelectedValue + "setpn4wend"
            Case "5"
                string_send = id_485_impianto + "setpn5w" + create_function_name(15, value_level_name.Text) + Format(Val(value_level_4ma.Text) * 10, "0000") + Format(Val(value_level_20ma.Text) * 10, "0000") + Format(Val(value_level_alarm.Text) * 10, "0000") + value_level_msg.SelectedValue + "setpn5wend"
        End Select
        Return string_send
    End Function

    Protected Sub save_setpointldma_new_Click(sender As Object, e As EventArgs) Handles save_setpointldma_new.Click
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
        Select Case spma
            Case "1"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=46" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "2"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=47" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "3"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=48" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "4"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=49" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "5"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=50" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
        End Select

    End Sub
End Class