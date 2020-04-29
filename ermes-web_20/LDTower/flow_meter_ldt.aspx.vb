Public Class flow_meter_ldt
        Inherits lingua

        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""
        Private Shared canale As String = ""

        Private Sub flow_meter_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
            Dim result As String = ""
            result = Page.Request("result")
            If Not IsPostBack Or result = "1" Then
                nome_impianto = Page.Request("nome_impianto")
                nome_impianto = Replace(nome_impianto, "$", " ")
                codice_impianto = Page.Request("codice")
                id_485_impianto = Page.Request("id_485")
                statistica = Page.Request("statistica")
            posiziona_flow_ldtower(nome_impianto, codice_impianto, id_485_impianto, canale)
            End If
        End Sub
    Public Sub posiziona_flow_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable


        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim version_str As String
        Dim new_version As Boolean = False

        Dim flow_value() As String
        Dim unit_value() As String
        Dim full_scale_temp As Integer = 0


        Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim international_unit As String = ""
        Dim measure_unit As String = ""

        ' abilito pulsante modifica
        save_flow_ldtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_flow_ldtower_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        flow_value = main_function.get_split_str(riga_strumento.value25)

        new_version = main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)

        value_watermeter1.Text = ((Val(Mid(flow_value(0), 3, 4))) / 10).ToString
        value_watermeter2.Text = ((Val(Mid(flow_value(0), 11, 4))) / 10).ToString

        If international_unit = "IS" Then
            'WATERMETER 1
            enable_litri_wm1.Visible = True
            enable_galloni_wm1.Visible = False

            If Val(Mid(flow_value(0), 7, 1)) Then   'Pulse / Liter
                watermeter1_pulse_litre.Checked = True
            End If

            If Val(Mid(flow_value(0), 9, 1)) Then   'Liter / Pulse 
                watermeter1_litri_pulse.Checked = True
            End If

            'WATERMETER 2
            enable_litri_wm2.Visible = True
            enable_galloni_wm2.Visible = False

            If Val(Mid(flow_value(0), 15, 1)) Then   'Pulse / Liter
                watermeter2_pulse_litre.Checked = True
            End If

            If Val(Mid(flow_value(0), 17, 1)) Then   'Liter / Pulse 
                watermeter2_litri_pulse.Checked = True
            End If

        Else
            'WATERMETER 1
            enable_litri_wm1.Visible = False
            enable_galloni_wm1.Visible = True

            If Val(Mid(flow_value(0), 8, 1)) Then   'Pulse / Gallons
                watermeter1_pulse_galloni.Checked = True
            End If

            If Val(Mid(flow_value(0), 10, 1)) Then   'Gallons / Pulse 
                watermeter1_galloni_pulse.Checked = True
            End If

            'WATERMETER 2
            enable_litri_wm2.Visible = False
            enable_galloni_wm2.Visible = True

            If Val(Mid(flow_value(0), 15, 1)) Then   'Pulse / Liter
                watermeter2_pulse_litre.Checked = True
            End If

            If Val(Mid(flow_value(0), 17, 1)) Then   'Liter / Pulse 
                watermeter2_litri_pulse.Checked = True
            End If
        End If
        


    End Sub
    Private Function MakeFlowMeter() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim version_str As String
        Dim new_version As Boolean = False
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""

        Dim Risultato As String
        Dim Pulse_Liter As Integer
        Dim Pulse_Gallons As Integer
        Dim Liter_Pulse As Integer
        Dim Gallons_Pulse As Integer

        Dim Pulse_Liter_WM2 As Integer
        Dim Pulse_Gallons_WM2 As Integer
        Dim Liter_Pulse_WM2 As Integer
        Dim Gallons_Pulse_WM2 As Integer


        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        new_version = main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)


        If international_unit = "IS" Then

            If watermeter1_litri_pulse.Checked Then
                Liter_Pulse = 1
                Gallons_Pulse = 1
            Else
                Liter_Pulse = 0
                Gallons_Pulse = 0
            End If
            If watermeter1_pulse_litre.Checked Then
                Pulse_Liter = 1
                Pulse_Gallons = 1
            Else
                Pulse_Liter = 0
                Pulse_Gallons = 0
            End If


            If watermeter2_litri_pulse.Checked Then
                Liter_Pulse_WM2 = 1
                Gallons_Pulse_WM2 = 1
            Else
                Liter_Pulse_WM2 = 0
                Gallons_Pulse_WM2 = 0
            End If
            If watermeter2_pulse_litre.Checked Then
                Pulse_Liter_WM2 = 1
                Pulse_Gallons_WM2 = 1
            Else
                Pulse_Liter_WM2 = 0
                Pulse_Gallons_WM2 = 0
            End If

        Else

            If watermeter1_galloni_pulse.Checked Then
                Gallons_Pulse = 1
                Liter_Pulse = 1
            Else
                Gallons_Pulse = 0
                Liter_Pulse = 0
            End If

            If watermeter1_pulse_galloni.Checked Then
                Pulse_Gallons = 1
                Pulse_Liter = 1
            Else
                Pulse_Gallons = 0
                Pulse_Liter = 0
            End If

            If watermeter2_galloni_pulse.Checked Then
                Gallons_Pulse_WM2 = 1
                Liter_Pulse_WM2 = 1
            Else
                Gallons_Pulse_WM2 = 0
                Liter_Pulse_WM2 = 0
            End If

            If watermeter2_pulse_galloni.Checked Then
                Pulse_Gallons_WM2 = 1
                Pulse_Liter_WM2 = 1
            Else
                Pulse_Gallons_WM2 = 0
                Pulse_Liter_WM2 = 0
            End If

        End If
      
        Risultato = "MT" + Format(Val(value_watermeter1.Text) * 10, "0000") + Format(Pulse_Liter, "0") + Format(Pulse_Gallons, "0") + Format(Liter_Pulse, "0") + Format(Gallons_Pulse, "0") + Format(Val(value_watermeter2.Text) * 10, "0000") + Format(Pulse_Liter_WM2, "0") + Format(Pulse_Gallons_WM2, "0") + Format(Liter_Pulse_WM2, "0") + Format(Gallons_Pulse_WM2, "0")


        Return id_485_impianto + "flowmw" + Risultato + "flowmwend" & Chr(13)

    End Function

    Protected Sub save_flow_ldtower_new_Click(sender As Object, e As EventArgs) Handles save_flow_ldtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeFlowMeter()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=6" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub


End Class