Public Class setpoint_temperature
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub setpoint_temperature_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            canale = Page.Request("canale")
            posiziona_temperature(nome_impianto, codice_impianto, id_485_impianto)

        End If

    End Sub
    Public Sub posiziona_temperature(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim setpoint_value() As String
        Dim set_variable_javascript(2, 1) As String
        Dim java_script_variable As java_script = New java_script
        Dim number_version As Integer = 0
        Dim number_version_complete As Integer = 0

        tabella_strumento = (Session("strumento"))

        ' abilito pulsante modifica
        save_temperature_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_temperature_new, ""))


        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        number_version = main_function.get_version_integer(riga_strumento.nome, number_version_complete)

        setpoint_value = main_function.get_split_str(riga_strumento.value5)
        Dim setpointTemperature As String
        If canale = "1" Then
            setpointTemperature = setpoint_value(11)
        Else
            setpointTemperature = setpoint_value(12)
        End If
        If number_version_complete > 301 Then
            Label12.Text = "ON"
            Literal1.Text = "OFF"
            Dim temperature_value1 As Double = Mid(setpointTemperature, 4, 3) / 10
            value_temperature_off_id.Text = Replace(temperature_value1.ToString(), ",", ".")
        End If
        Dim temperature_value As Double = Mid(setpointTemperature, 1, 3) / 10


        value_temperature_on_id.Text = Replace(temperature_value.ToString(), ",", ".")
        If Mid(setpointTemperature, 7, 1) = "0" Then
            index_relay_temperature.SelectedIndex = 0
        Else
            index_relay_temperature.SelectedIndex = Val(Mid(setpointTemperature, 7, 1)) 'relay
        End If
        set_variable_javascript(0, 0) = "max_ch_value"
        set_variable_javascript(0, 1) = "100"
        set_variable_javascript(1, 0) = "min_ch_value"
        set_variable_javascript(1, 1) = "0"
        set_variable_javascript(2, 0) = "max_fix_value"
        set_variable_javascript(2, 1) = "1"
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 2)

    End Sub
    Public Function get_setpoint_new() As String
        Dim Risultato As String = ""
        Dim uscita_relay As String = ""
        If (index_relay_temperature.SelectedValue = "0") Then
            uscita_relay = "0"
        Else
            uscita_relay = Format(Val(index_relay_temperature.SelectedValue), "0")
        End If
        If canale = "1" Then
            Risultato = id_485_impianto + "2Lph" + Format(Val(value_temperature_on_id.Text) * 10, "000") + Format(Val(value_temperature_off_id.Text) * 10, "000") + uscita_relay + "end"
        Else
            Risultato = id_485_impianto + "2Mph" + Format(Val(value_temperature_on_id.Text) * 10, "000") + Format(Val(value_temperature_off_id.Text) * 10, "000") + uscita_relay + "end"
        End If

        Return Risultato

    End Function

    Protected Sub save_temperature_new_Click(sender As Object, e As EventArgs) Handles save_temperature_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = get_setpoint_new()

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
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=6&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class