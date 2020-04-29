Public Class Self_clean
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub Self_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_Self_lds(nome_impianto, codice_impianto, id_485_impianto, canale)
        End If
    End Sub
    Public Sub posiziona_Self_lds(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim formato_d As String

        Dim Self_value() As String
        Dim valuer_value() As String

        Dim function_java As String = ""
        Dim java_script_flow As java_script = New java_script
        ' abilito pulsante modifica
        save_Self_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_Self_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        Self_value = main_function.get_split_str(riga_strumento.value20)
        
       
        Dim cycle As String
        Dim clean As String
        Dim restore As String
        Dim on_alarm As String

   

        cycle = Mid(Self_value(1), 1, 2)
        clean = Mid(Self_value(2), 1, 3)
        restore = Mid(Self_value(3), 1, 3)
        on_alarm = Mid(Self_value(4), 1, 1)
      

        value_clean.Text = clean
        value_restore.Text = restore


        If on_alarm = "0" Then 'yes on alarm
            CleanAlarmYes.Checked = True
            function_java = function_java + "yes_on_alarm();"
        End If

        If on_alarm = "1" Then 'no on alarm
            CleanAlarmNo.Checked = True
            function_java = function_java + "no_on_alarm();"
        End If




        If cycle = "00" Then 'disable
            Self0h.Checked = True
            function_java = function_java + "enable_Self0h();"
        End If

        If cycle = "01" Then '2 ore
            Self2h.Checked = True
            function_java = function_java + "enable_Self2h();"
        End If

        If cycle = "02" Then '6 ore
            Self6h.Checked = True
            function_java = function_java + "enable_Self6h();"
        End If

        If cycle = "03" Then '12 ore
            Self12h.Checked = True
            function_java = function_java + "enable_Self12h();"
        End If

        If cycle = "04" Then '1giorni
            Self1D.Checked = True
            function_java = function_java + "enable_Self1D();"
        End If

        If cycle = "05" Then '2giorni
            Self2D.Checked = True
            function_java = function_java + "enable_Self2D();"
        End If

        If cycle = "06" Then '3giorni
            Self3D.Checked = True
            function_java = function_java + "enable_Self3D();"
        End If

        If cycle = "07" Then '4giorni
            Self4D.Checked = True
            function_java = function_java + "enable_Self4D();"
        End If

        If cycle = "08" Then '5giorni
            Self5D.Checked = True
            function_java = function_java + "enable_Self5D();"
        End If

        If cycle = "09" Then '6giorni
            Self6D.Checked = True
            function_java = function_java + "enable_Self6D();"
        End If

        If cycle = "10" Then '7 giorni
            Self7D.Checked = True
            function_java = function_java + "enable_Self7D();"
        End If

        If cycle = "11" Then '8 giorni
            Self8D.Checked = True
            function_java = function_java + "enable_Self8D();"
        End If

        If cycle = "12" Then '9 giorni
            Self9D.Checked = True
            function_java = function_java + "enable_Self9D();"
        End If

        If cycle = "13" Then '10 giorni
            Self10D.Checked = True
            function_java = function_java + "enable_Self10D();"
        End If



        java_script_flow.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function MakeSelfString() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable


        Dim Risultato As String
        Dim app_mode_cycle As String
        Dim app_time_clean As String
        Dim app_time_restore As String
        Dim app_on_alarm As String



        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next



        If Self0h.Checked = True Then '
            app_mode_cycle = "00"
        End If

        If Self2h.Checked = True Then '
            app_mode_cycle = "01"
        End If

        If Self6h.Checked = True Then '
            app_mode_cycle = "02"
        End If

        If Self12h.Checked = True Then '
            app_mode_cycle = "03"
        End If

        If Self1D.Checked = True Then '
            app_mode_cycle = "04"
        End If

        If Self2D.Checked = True Then '
            app_mode_cycle = "05"
        End If

        If Self3D.Checked = True Then '
            app_mode_cycle = "06"
        End If

        If Self4D.Checked = True Then '
            app_mode_cycle = "07"
        End If

        If Self5D.Checked = True Then '
            app_mode_cycle = "08"
        End If

        If Self6D.Checked = True Then '
            app_mode_cycle = "09"
        End If

        If Self7D.Checked = True Then '
            app_mode_cycle = "10"
        End If

        If Self8D.Checked = True Then '
            app_mode_cycle = "11"
        End If

        If Self9D.Checked = True Then '
            app_mode_cycle = "12"
        End If

        If Self10D.Checked = True Then '
            app_mode_cycle = "13"
        End If




        app_time_clean = Format(Val(value_clean.Text), "000")
        app_time_restore = Format(Val(value_restore.Text), "000")


        If CleanAlarmYes.Checked = True Then '
            app_on_alarm = "0"
        End If


        If CleanAlarmNo.Checked = True Then '
            app_on_alarm = "1"
        End If


        Risultato = app_mode_cycle + app_time_clean + app_time_restore + app_on_alarm

        Return id_485_impianto + "selfcw" + Risultato + "selfcwend" & Chr(13)

    End Function
    Protected Sub save_Self_new_Click(sender As Object, e As EventArgs) Handles save_Self_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeSelfString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=28" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class