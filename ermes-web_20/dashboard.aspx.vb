Public Class dashboard
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Private Sub dashboard_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            refresh_dashboard()
            'Literal_script.Text = "<script>"
            'Literal_script.Text = Literal_script.Text + "$(function()"
            'Literal_script.Text = Literal_script.Text + "{"
            'Literal_script.Text = Literal_script.Text + "$('#content-notification').notyfy({"
            'Literal_script.Text = Literal_script.Text + "text:       '<h4>Welcome back Mr.Awesome!</h4><p>You have <strong>3,450</strong> unread messages. Click here to close the notification and see a dark color variation.</p>',"
            'Literal_script.Text = Literal_script.Text + "type:       'default',"
            'Literal_script.Text = Literal_script.Text + "layout:     'top',"
            ''Literal_script.Text = Literal_script.Text + "closeWith: ['click'],"
            'Literal_script.Text = Literal_script.Text + "closeWith: ['click']"

            ''Literal_script.Text = Literal_script.Text + "events: {"
            ''Literal_script.Text = Literal_script.Text + "hidden: function(){"
            ''Literal_script.Text = Literal_script.Text + "$('#content-notification').notyfy({"
            ''Literal_script.Text = Literal_script.Text + "text:       '<h4>Welcome back Mr.Awesome!</h4><p>You have <strong>3,450</strong> unread messages. Click here to close the notification and see a primary color variation.</p>',"
            ''Literal_script.Text = Literal_script.Text + "type:       'dark',"
            ''Literal_script.Text = Literal_script.Text + "layout:     'top',"
            ''Literal_script.Text = Literal_script.Text + "closeWith: ['click'],"
            ''Literal_script.Text = Literal_script.Text + "events: {"
            ''Literal_script.Text = Literal_script.Text + "hidden: function(){"
            ''Literal_script.Text = Literal_script.Text + "$('#content-notification').notyfy({"
            ''Literal_script.Text = Literal_script.Text + "type:       'primary',"
            ''Literal_script.Text = Literal_script.Text + "layout:     'top',"
            ''Literal_script.Text = Literal_script.Text + "closeWith: ['click']"
            ''Literal_script.Text = Literal_script.Text + "});"
            ''Literal_script.Text = Literal_script.Text + "}"
            ''Literal_script.Text = Literal_script.Text + "}"
            ''Literal_script.Text = Literal_script.Text + "});"
            ''Literal_script.Text = Literal_script.Text + "}"
            ''Literal_script.Text = Literal_script.Text + "}"
            'Literal_script.Text = Literal_script.Text + "});"
            'Literal_script.Text = Literal_script.Text + "});"
            'Literal_script.Text = Literal_script.Text + "</script>"

        End If

    End Sub

    Private Sub refresh_dashboard()
        Dim intestazione As String = ""
        Dim prima_volta As Boolean = True
        Dim percento_strumenti As Integer = 0
        Dim percento_allarmi As Integer = 0
        Dim comunicazioni As String = ""
        Dim precedente_impianto As String = ""
        Dim contatore_impianti As Integer = 0
        Dim contatore_strumenti As Integer = 0
        Dim contatore_strumenti_attivi As Integer = 0
        Dim contatore_strumenti_allarmi As Integer = 0
        Dim contatore_strumenti_allarmi_flusso As Integer = 0
        Dim personalizzazione_aquacare As Integer = 0
        Dim stato_connessione As Boolean = False
        Dim block_yagel As Boolean = False
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        tabella_strumento = Session("strumento")
        tabella_impianto = Master.tabella_impianto_container
        comunicazioni = GetGlobalResourceObject("communication_g", "ultime")
        For Each dc1 In tabella_strumento
            If InStr(dc1.nome, "Y#o") Or dc1.tipo_strumento = "LD4" Then
                block_yagel = True
                ' comunicazioni = "<h4>Warning!! This account will be terminated Friday the 10th of April at 12:00 Italian time.</h4><p> Please contact your EMEC distributor for information.</p>"
                If dc1.codice = "268994" Or dc1.codice = "869534" Or
                    dc1.codice = "10000013" Or dc1.codice = "10000005" Or
                    dc1.codice = "0549263889" Or dc1.codice = "287758" Or dc1.codice = "646324" Or
                    Session("mid_super").ToString = "091eeeb4-7d61-4a04-a8fb-804652eb980f" Or
                    Session("mid_super").ToString = "c97c4283-7763-45ab-8ba1-35f2a2912d8b" Then
                    block_yagel = False
                    Exit For
                End If
            End If
        Next
        If block_yagel Then
            Response.Redirect("block.aspx")
        End If

        For Each dc In tabella_impianto
            Dim split_impianto() As String = dc.nome_impianto.Split(">")
            If prima_volta Then
                precedente_impianto = split_impianto(0)
                prima_volta = False
            End If
            If precedente_impianto <> split_impianto(0) Then

                If contatore_strumenti > 0 Then
                    percento_strumenti = (100 * contatore_strumenti_attivi) / contatore_strumenti
                End If
                If contatore_strumenti_attivi > 0 Then
                    percento_allarmi = (100 * contatore_strumenti_allarmi) / contatore_strumenti_attivi
                End If
                contatore_impianti = contatore_impianti + 1
                intestazione = intestazione + crea_dashboard(precedente_impianto, Str(percento_strumenti), Str(contatore_strumenti_attivi), _
                                                             Str(percento_allarmi), Str(contatore_strumenti_allarmi), contatore_strumenti_allarmi_flusso, _
                                                             contatore_strumenti, contatore_impianti, False, stato_connessione)
                percento_strumenti = 0
                percento_allarmi = 0
                contatore_strumenti_attivi = 0
                contatore_strumenti = 0
                contatore_strumenti_allarmi = 0
                contatore_strumenti_allarmi_flusso = 0
                stato_connessione = False
            End If
            For Each dc1 In tabella_strumento
                Try

                    If dc1.codice = dc.identificativo Then
                        'Dim differenza_minuti As Long = 0
                        'differenza_minuti = DateDiff(DateInterval.Minute, dc1.data_aggiornamento, Now)
                        If main_function.check_is_connected(dc1.data_aggiornamento) Then ' se non fa aggiornamento per oltre una ora lo considero disconnesso
                            stato_connessione = True
                            contatore_strumenti_attivi = contatore_strumenti_attivi + 1
                            Select Case dc1.tipo_strumento
                                Case "max5" ' caso Max 5
                                    If main_function.check_max5_alarm(dc1.value2, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LD" ' caso LD doppio
                                    If main_function.check_ld_doppio_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LDDT" ' caso LD doppio
                                    If main_function.check_lddt_doppio_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LDMA" ' caso LD mA
                                    If main_function.check_ldma_alarm(dc1.value3) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LDLG" ' caso LD mA
                                    If main_function.check_ldma_alarm(dc1.value3) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If

                                Case "LDS" ' caso LDS singolo
                                    If main_function.check_lds_singolo_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LD4" ' caso LDS singolo
                                    If main_function.check_ld4_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "WD" ' caso WD
                                    If main_function.check_wd_alarm(dc1.value3, False, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "WH" ' caso WH
                                    If main_function.check_wd_alarm(dc1.value3, True, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If

                                Case "LTB" ' caso WH
                                    If main_function.check_ltb_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LTA" ' caso WH
                                    If main_function.check_lta_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LTD" ' caso WH
                                    If main_function.check_lta_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                                Case "LTU" ' caso WH
                                    If main_function.check_lta_alarm(dc1.value3, contatore_strumenti_allarmi_flusso) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If


                                Case "Tower" ' caso WD
                                    Dim config_value() As String
                                    Dim configurazione_canali As String = ""
                                    Dim version_str As String = ""
                                    main_function_config.chek_tower_version(dc1.nome, version_str, personalizzazione_aquacare)
                                    config_value = main_function.get_split_str(dc1.value4)
                                    configurazione_canali = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)
                                    If main_function.check_tower_alarm(dc1.value3, contatore_strumenti_allarmi_flusso, configurazione_canali) Then
                                        contatore_strumenti_allarmi = contatore_strumenti_allarmi + 1
                                    End If
                            End Select
                        Else
                        End If
                        contatore_strumenti = contatore_strumenti + 1
                    End If
                Catch ex As Exception
                    ' comunicazioni = comunicazioni + "<h4>Attenzione Problema Impianto</h4><p>Verificare installazione impianto " + split_impianto(0) + " - " + split_impianto(1) + "</p>"
                End Try

            Next
            precedente_impianto = split_impianto(0)
        Next
        If prima_volta = False Then ' devo elaborare l'ultima tabella del for
            impianti_yes.Visible = True
            impianti_no.Visible = False
            If contatore_strumenti > 0 Then
                percento_strumenti = (100 * contatore_strumenti_attivi) / contatore_strumenti
            End If
            If contatore_strumenti_attivi > 0 Then
                percento_allarmi = (100 * contatore_strumenti_allarmi) / contatore_strumenti_attivi
            End If
            contatore_impianti = contatore_impianti + 1
            intestazione = intestazione + crea_dashboard(precedente_impianto, Str(percento_strumenti), Str(contatore_strumenti_attivi), _
                                                         Str(percento_allarmi), Str(contatore_strumenti_allarmi), contatore_strumenti_allarmi_flusso, _
                                                         contatore_strumenti, contatore_impianti, True, stato_connessione)
            Literal1.Text = intestazione
        Else 'nessun impianto da aggiungere
            If Session("super_user") Then
                impianti_yes.Visible = False
                impianti_no.Visible = True
            Else
                impianti_yes.Visible = False
                impianti_no.Visible = False

            End If
        End If
        If comunicazioni = "" Then
            Literal_script.Text = ""
        Else
            Literal_script.Text = "<script>$(function(){$('#content-notification').notyfy({text:'"
            Literal_script.Text = Literal_script.Text + comunicazioni
            Literal_script.Text = Literal_script.Text + "',type:       'error',layout:     'top',closeWith: ['click']});});</script>"
        End If

        If comunicazioni <> "" Then

        End If
    End Sub
    Public Function crea_dashboard(ByVal intestazione_impianto As String, ByVal percento_strumenti As String, ByVal numero_strumenti_attivi As String, _
                                    ByVal percento_allarmi As String, ByVal allarmi_attivi As String, ByVal numero_flow As Integer, ByVal numero_strumenti As Integer, _
                                    numero_impianti As Integer, ByVal ultima_tabella As Boolean, ByVal stato_connessione As Boolean) As String
        Dim intestazione As String = ""
        Dim url_temp As String = ""
        If numero_impianti > 0 Then
            numero_impianti = numero_impianti - 1
        End If
        If numero_impianti Mod 3 = 0 Then
            intestazione = intestazione + "<div class=""row-fluid"">"
        End If

        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<div class=""widget widget-3"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<h4 class=""heading"">" + intestazione_impianto + "</h4>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class=""widget-body"">"
        intestazione = intestazione + "<div class=""innerAll"">"
        intestazione = intestazione + "<div class=""row-fluid"">"
        intestazione = intestazione + "<div class=""span6"">"
        intestazione = intestazione + "<a href=""impianto.aspx?nome_impianto=" + intestazione_impianto + """ class=""widget-stats widget-stats-2 widget-stats-easy-pie"">"
        intestazione = intestazione + "<div data-percent=""" + percento_strumenti + """ class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + percento_strumenti + "</span>%"
        intestazione = intestazione + "<canvas width=""50"" height=""50""></canvas>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<span class=""txt""> " + numero_strumenti_attivi + " " + GetGlobalResourceObject("dashboard_global", "Stumenti_attivi_su") + Str(numero_strumenti) + "</span>"
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "</a>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class=""span6"">"
        intestazione = intestazione + "<a href=""impianto.aspx?nome_impianto=" + intestazione_impianto + """ class=""widget-stats widget-stats-2 widget-stats-easy-pie"">"
        intestazione = intestazione + "<div data-percent=""" + percento_allarmi + """ class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + percento_allarmi + "</span>%"
        intestazione = intestazione + "<canvas width=""50"" height=""50""></canvas>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<span class=""txt""><span class=""count""> " + allarmi_attivi + " </span> " + GetGlobalResourceObject("dashboard_global", "Allarmi_Attivi") + "</span>"
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "</a>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        If stato_connessione Then
            If numero_flow > 0 Then
                intestazione = intestazione + "<div class=""flow_alarm_on"" >" + Str(numero_flow) + " " + GetGlobalResourceObject("dashboard_global", "flow_alarm") + "</div>"
            Else
                intestazione = intestazione + "<div class=""flow_alarm_off"" > " + GetGlobalResourceObject("dashboard_global", "no_flow_alarm") + " </div>"
            End If
        Else
            intestazione = intestazione + "<div class=""flow_alarm_off"" > " + GetGlobalResourceObject("dashboard_global", "no_connesso") + " </div>"
        End If
        'oppure
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class=""widget-footer align-right""> <a href=""impianto.aspx?nome_impianto=" + intestazione_impianto + """ class=""glyphicons list""><i></i> " + GetGlobalResourceObject("dashboard_global", "view") + "</a> </div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        If ultima_tabella Or numero_impianti + 1 Mod 3 = 0 Then
            intestazione = intestazione + "</div>"
        End If
        Return intestazione
    End Function

End Class