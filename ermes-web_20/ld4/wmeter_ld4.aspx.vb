Public Class w_meter_ld4
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub parameters_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_meter_ld4(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "Meter"), GetGlobalResourceObject("ld_global", "probe_failure"))
        End If
    End Sub
    Public Sub posiziona_meter_ld4(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal probe_fail_alarm_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim meter_value() As String
        Dim calibrz_value() As String
       
        ' abilito pulsante modifica
        save_meter_new_ld4.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_meter_new_ld4, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        meter_value = main_function.get_split_str(riga_strumento.value20)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        Dim Value As String
        Dim ValueA As String
        Dim Mode As String
        Dim Reset As String
        Dim temp_calc As Single

        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
      

        Value = Mid(meter_value(2), 1, 5)

        temp_calc = Val(Value) / 100
        value_meter.Text = Replace(temp_calc.ToString(), ",", ".")


        Mode = Mid(meter_value(3), 1, 1)
        'Reset = Mid(meter_value(3), 1, 1)


        ValueA = Mid(meter_value(4), 1, 5)

        temp_calc = Val(ValueA) / 10
        m3h.Text = Replace(temp_calc.ToString(), ",", ".")



        checkreset.Checked = False
        function_java = function_java + "disable_reset();"
        
        If Mode = 1 Then
            pulse.Checked = True
            function_java = function_java + "enable_pulse();"

        Else
            litri.Checked = True
            function_java = function_java + "enable_litri();"
            litri.Checked = True 'disabled

        End If

     

    End Sub
    Private Function MakeParamString() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim app As String
        Dim app2 As String
        Dim app3 As String
        Dim app4 As String

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

       


        If litri.Checked = True Then
            app = "0"
        Else
            app = "1"
        End If

        If checkreset.Checked = True Then
            app2 = "1"
        Else
            app2 = "0"
        End If


        app3 = Format(Val(value_meter.Text) * 100, "00000")
        app4 = Format(Val(m3h.Text) * 10, "00000")

     


        Risultato = app3 + app + app2 + app4
        Return id_485_impianto + "wmwtew" + Risultato + "wmwtewend" & Chr(13)




    End Function

    Protected Sub save_meter_new_ld4_Click(sender As Object, e As EventArgs) Handles save_meter_new_ld4.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeParamString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=30" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class