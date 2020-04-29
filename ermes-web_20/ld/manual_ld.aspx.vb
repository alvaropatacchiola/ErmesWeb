Public Class manual_ld
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String = ""
        Dim calibrz_value() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim label_canale_temp As String = ""
        Dim full_scale_temp As Single

        Dim label_canale2_temp As String = ""
        Dim full_scale_temp2 As Single

        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0
        Dim etichetta_setpoint As String = ""
        Dim etichetta_setpoint2 As String = ""

        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            ' abilito pulsante modifica
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")

            save_manual_newld.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                        ClientScript.GetPostBackEventReference(save_manual_newld, ""))

            tabella_strumento = (Session("strumento"))

            For Each dc1 In tabella_strumento
                If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                    riga_strumento = dc1
                End If
            Next

            calibrz_value = main_function.get_split_str(riga_strumento.value4)
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, full_scale_temp, , etichetta_setpoint)
            label_canale2_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, full_scale_temp2, , etichetta_setpoint2)

 


            Literal3.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "1"
            Literal14.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "pulse") + "2"
            Label7.Text = label_canale_temp + " " + GetGlobalResourceObject("ld_global", "relay")

            Literal16.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "pulse")
            Literal10.Text = label_canale2_temp + " " + GetGlobalResourceObject("ld_global", "relay")



        End If
    End Sub
    Private Function MakeManual() As String

        Dim string_connect As String = ""
        Dim manual_enabled As String = "0"

        'If check_relay1_id.Checked Then
        '    manual_enabled = "1"
        '    string_connect = string_connect + "1" + Format(Val(value_relay1_id.Text), "00")
        'Else
        '    string_connect = string_connect + "000"
        'End If
        'If check_relay2_id.Checked Then
        '    manual_enabled = "1"
        '    string_connect = string_connect + "1" + Format(Val(value_relay2_id.Text), "00")
        'Else
        '    string_connect = string_connect + "000"
        'End If


        'If check_pulse1_id.Checked Then
        '    manual_enabled = "1"
        '    string_connect = string_connect + "1" + Format(Val(value_pulse1_id.Text), "00")
        'Else
        '    string_connect = string_connect + "000"
        'End If
        'If check_pulse2_id.Checked Then
        '    manual_enabled = "1"
        '    string_connect = string_connect + "1" + Format(Val(value_pulse2_id.Text), "00")
        'Else
        '    string_connect = string_connect + "000"
        'End If
        'If check_pulse3_id.Checked Then
        '    manual_enabled = "1"
        '    string_connect = string_connect + "1" + Format(Val(value_pulse3_id.Text), "00")
        'Else
        '    string_connect = string_connect + "000"
        'End If


        If check_relay1_id.Checked Then

            string_connect = "03" + Format(Val(value_relay1_id.Text), "00")
        
        End If
        If check_relay2_id.Checked Then

            string_connect = "06" + Format(Val(value_relay2_id.Text), "00")
       
        End If


        If check_pulse1_id.Checked Then

            string_connect = "02" + Format(Val(value_pulse1_id.Text), "00")
       
        End If
        If check_pulse2_id.Checked Then

            string_connect = "04" + Format(Val(value_pulse2_id.Text), "00")
        
        End If
        If check_pulse3_id.Checked Then

            string_connect = "05" + Format(Val(value_pulse3_id.Text), "00")
        
        End If
       

        ' Return id_485_impianto + "2Gph" + string_connect + manual_enabled + "end" & Chr(13)
        Return id_485_impianto + "manuaw" + string_connect + "manuawend" & Chr(13)

    End Function

    Protected Sub save_manual_newld_Click(sender As Object, e As EventArgs) Handles save_manual_newld.Click
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
        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=21" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class