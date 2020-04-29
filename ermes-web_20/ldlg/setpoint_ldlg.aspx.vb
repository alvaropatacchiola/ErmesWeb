Public Class setpoint_ldlg
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
            posiziona_setpoint_ldlg(nome_impianto, codice_impianto, id_485_impianto, spma, GetGlobalResourceObject("ld_global", "setpoint"))
        End If
    End Sub
    Public Sub posiziona_setpoint_ldlg(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String)
        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(2, 1) As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim setpntr_value() As String
        Dim numero_canali As Integer = 0
        Dim config_value() As String

        ' abilito pulsante modifica
        save_setpointldlg_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_setpointldlg_new, ""))

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        setpntr_value = main_function.get_split_str(riga_strumento.value7)
        config_value = main_function.get_split_str(riga_strumento.value1)
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
        If canale <= numero_canali Then
            wm_enable.Visible = False
            message_channel.Text = main_function_config.get_name_pump(setpntr_value, canale)
            value_name.Text = main_function_config.get_name_pump(setpntr_value, canale)
            value_pulse.Text = Replace((main_function_config.get_value_pump(setpntr_value, canale) / 100).ToString, ",", ".")
            value_enable.SelectedIndex = main_function_config.get_enable_pump(setpntr_value, canale)
            value_pulse_litre.SelectedIndex = main_function_config.get_factor_pump(setpntr_value, canale)
            set_variable_javascript(0, 0) = "max_pulse"
            set_variable_javascript(0, 1) = "100"
            set_variable_javascript(1, 0) = "virgole"
            set_variable_javascript(1, 1) = "2"

        Else
            wm_enable.Visible = True
            Dim indice_temp As Integer = (canale + (5 - numero_canali))
            message_channel.Text = main_function_config.get_name_wm(setpntr_value, canale)
            value_name.Text = main_function_config.get_name_wm(setpntr_value, canale)
            value_pulse.Text = Replace((main_function_config.get_value_wm(setpntr_value, canale) / 10).ToString, ",", ".")
            value_enable.SelectedIndex = main_function_config.get_enable_wm(setpntr_value, canale)
            value_pulse_litre.SelectedIndex = main_function_config.get_factor_wm(setpntr_value, canale)
            set_variable_javascript(0, 0) = "max_pulse"
            set_variable_javascript(0, 1) = "1000"
            set_variable_javascript(1, 0) = "virgole"
            set_variable_javascript(1, 1) = "1"


        End If
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 2)

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
                string_send = id_485_impianto + "setpn1w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 100, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn1wend"
            Case "2"
                string_send = id_485_impianto + "setpn2w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 100, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn2wend"
            Case "3"
                string_send = id_485_impianto + "setpn3w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 100, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn3wend"
            Case "4"
                string_send = id_485_impianto + "setpn4w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 100, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn4wend"
            Case "5"
                string_send = id_485_impianto + "setpn5w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 100, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn5wend"
            Case "6"
                string_send = id_485_impianto + "setpn6w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 10, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn6wend"
            Case "7"
                string_send = id_485_impianto + "setpn7w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 10, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn7wend"
            Case "8"
                string_send = id_485_impianto + "setpn8w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 10, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn8wend"
            Case "9"
                string_send = id_485_impianto + "setpn9w" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 10, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpn9wend"
            Case "10"
                string_send = id_485_impianto + "setpnAw" + create_function_name(15, value_name.Text) + Format(Val(value_pulse.Text) * 10, "0000") + value_enable.SelectedValue + value_pulse_litre.SelectedValue + "setpnAwend"

        End Select
        Return string_send
    End Function
    Protected Sub save_setpointldlg_new_Click(sender As Object, e As EventArgs) Handles save_setpointldlg_new.Click
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
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=59" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "2"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=60" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "3"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=61" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "4"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=62" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "5"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=63" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "6"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=64" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "7"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=65" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "8"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=66" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "9"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=67" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)
            Case "10"
                Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=68" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

        End Select
    End Sub
End Class