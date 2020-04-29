Public Class cicli_ltb
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""


    Private Sub cicli_ltb_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_cicli_ltb(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "out_of_range_alarm"), GetGlobalResourceObject("ld_global", "min_max_high"), GetGlobalResourceObject("ld_global", "min_max_low"), GetGlobalResourceObject("ld_global", "time"))
        End If
    End Sub
    Public Sub posiziona_cicli_ltb(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal out_range_traduzione As String, ByVal mim_max_h_traduzione As String, ByVal mim_max_l_traduzione As String, _
                       ByVal time_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim cicli_value() As String
        Dim function_java As String = ""
        Dim java_script_cicli As java_script = New java_script

        Dim number_version As Integer = 0



        ' abilito pulsante modifica
        save_cicli_ltb_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_cicli_ltb_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next




        cicli_value = main_function.get_split_str(riga_strumento.value21)

        number_version = Val(main_function.get_version(riga_strumento.nome))


        Dim cicli_val1 As String = Mid(cicli_value(1), 1, 2)
        Dim cicli_val2 As String = Mid(cicli_value(2), 1, 4)
        Dim cicli_val3 As String = Mid(cicli_value(3), 1, 4)

        Dim cicli_val As Single
        Dim app As Single
        Dim app2 As Single
        Dim appp As Single
        Dim corr_hcl As Long

        Dim corr_nacl As Long

        cicli_val = Val(cicli_val1) * 100000000 + Val(cicli_val2) * 1000 + Val(cicli_val3)

        If number_version >= 210 Then
            Dim Grandezza_LOTUS As Integer = 0
            Grandezza_LOTUS = Mid(cicli_value(4), 1, 2)
            corr_hcl = Mid(cicli_value(5), 1, 2)
            corr_nacl = Mid(cicli_value(6), 1, 2)
            corr_hcl = corr_hcl * 1000
            corr_nacl = corr_nacl * 1000

            corr_hcl = corr_hcl / 333
            corr_nacl = corr_nacl / 333

            If Grandezza_LOTUS = 8 Then
                app = cicli_val * 50

                appp = corr_hcl * 0.185

                app = app + appp

                app2 = cicli_val * 50

                appp = corr_nacl * 0.185

                app2 = app2 + appp

                value_cc_HCl.Text = Format(app, "000000")
                value_cc_NaCl.Text = Format(app2, "000000")
            End If


            If Grandezza_LOTUS = 30 Then
                app = cicli_val * 187.5

                appp = corr_hcl * 1.11

                app = app + appp

                app2 = cicli_val * 187.5

                appp = corr_nacl * 1.11

                app2 = app2 + appp

                value_cc_HCl.Text = Format(app, "000000")
                value_cc_NaCl.Text = Format(app2, "000000")
            End If

            If Grandezza_LOTUS = 60 Then
                app = cicli_val * 375

                appp = corr_hcl * 1.11

                app = app + appp

                app2 = cicli_val * 375

                appp = corr_nacl * 1.11

                app2 = app2 + appp

                value_cc_HCl.Text = Format(app, "000000")
                value_cc_NaCl.Text = Format(app2, "000000")
            End If


            enable_cc_HCl.Visible = True
            enable_cc_NaCl.Visible = True
        Else
            enable_cc_HCl.Visible = False
            enable_cc_NaCl.Visible = False
        End If






        value_cicli.Text = Mid(cicli_value(1), 1, 2) + Mid(cicli_value(2), 1, 4) + Mid(cicli_value(3), 1, 4)
        java_script_cicli.call_function_javascript_onload(Page, function_java)

    End Sub
    Private Function MakeCicliString() As String



        Return id_485_impianto + "rescyw" + "0" + "rescywend" & Chr(13)

    End Function

    Protected Sub save_cicli_ltb_new_Click(sender As Object, e As EventArgs) Handles save_cicli_ltb_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeCicliString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ltb.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class