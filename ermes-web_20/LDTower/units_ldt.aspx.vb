Public Class units_ldt
        Inherits lingua

        Private Shared nome_impianto As String = ""
        Private Shared codice_impianto As String = ""
        Private Shared id_485_impianto As String = ""
        Private Shared statistica As String = ""
        Private Shared canale As String = ""


        Private Sub unit_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
            Dim result As String = ""
            result = Page.Request("result")
            If Not IsPostBack Or result = "1" Then
                nome_impianto = Page.Request("nome_impianto")
                nome_impianto = Replace(nome_impianto, "$", " ")
                codice_impianto = Page.Request("codice")
                id_485_impianto = Page.Request("id_485")
                statistica = Page.Request("statistica")
            posiziona_unit_ldtower(nome_impianto, codice_impianto, id_485_impianto, canale)
            End If
        End Sub
    Public Sub posiziona_unit_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim unit_value() As String

        ' abilito pulsante modifica
        save_unit_ldtower_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_unit_ldtower_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)
        If Val(Mid(unit_value(0), 3, 1)) Then        'IS
            unit_is.Checked = True
        End If

        If Val(Mid(unit_value(0), 4, 1)) Then        'US
            unit_us.Checked = True
        End If

        If Val(Mid(unit_value(0), 5, 1)) Then        'Siemens
            measure_unit_us.Checked = True
        End If

        If Val(Mid(unit_value(0), 6, 1)) Then        'ppm
            measure_unit_ppm.Checked = True
        End If
    End Sub
        Private Function makeDataUnits() As String
            Dim InternationalSystem As Integer
            Dim UsSystem As Integer
            Dim Siemens As Integer
            Dim Ppm As Integer

            If unit_is.Checked Then
                InternationalSystem = "1"
            Else
                InternationalSystem = "0"
            End If

            If unit_us.Checked Then
                UsSystem = "1"
            Else
                UsSystem = "0"
            End If

            If measure_unit_us.Checked Then
                Siemens = "1"
            Else
                Siemens = "0"
            End If

            If measure_unit_ppm.Checked Then
                Ppm = "1"
            Else
                Ppm = "0"
            End If

            Return id_485_impianto + "unitswMT" + Format(InternationalSystem, "0") + Format(UsSystem, "0") + Format(Siemens, "0") + Format(Ppm, "0") + "unitswend" & Chr(13)


        End Function

    Protected Sub save_unit_ldtower_new_Click(sender As Object, e As EventArgs) Handles save_unit_ldtower_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = makeDataUnits()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ldtower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=10" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
    End Class

