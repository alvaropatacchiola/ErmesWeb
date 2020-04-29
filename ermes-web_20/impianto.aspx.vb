Public Class impianto
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nome_impianto As String = ""
        If Not IsPostBack Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "£", " ")
            refresh_impianto(nome_impianto)
        End If
    End Sub
    Private Sub refresh_impianto(ByVal nome_impianto As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim intestazione As String = ""
        Dim intestazione_impianto As String = ""
        Dim intestazione_strumento As String = ""
        Dim contatore_strumenti As Integer = 0
        Dim contatore_strumenti_allarme As Integer = 0
        Dim contatore_strumenti_disconnected As Integer = 0
        Dim contatore_impianti As Integer = 0
        Dim primo_strumento As Boolean = True
        Dim check_alarm_general As Boolean
        Dim check_connected As Boolean
        Dim prima_volta As Boolean
        Dim data_aggiornamento As Date
        Dim indirizzo As String = ""
        Dim time_connessione_min As Long = 0
        tabella_strumento = Session("strumento")
        tabella_impianto = Master.tabella_impianto_container

        intestazione = "<div class=""innerLR"">"
        intestazione = intestazione + "<div class=""tabsbar"" style=""height: inherit;"">"
        intestazione = intestazione + "<ul>"
        intestazione_impianto = "<div class=""tab-content"">"
        For Each dc In tabella_impianto
            Dim split_impianto() As String = dc.nome_impianto.Split(">")



            contatore_strumenti = 0
            contatore_strumenti_allarme = 0
            contatore_strumenti_disconnected = 0
            intestazione_strumento = ""
            prima_volta = True
            If (split_impianto(0) = nome_impianto) Then


                For Each dc1 In tabella_strumento
                    Try

                        If dc1.codice = dc.identificativo Then
                            indirizzo = (dc.indirizzo).ToString
                            If prima_volta Then
                                data_aggiornamento = dc1.data_aggiornamento
                                prima_volta = False
                            End If
                            contatore_strumenti = contatore_strumenti + 1
                            intestazione_strumento = Replace(intestazione_strumento, "<$$$$$$$$$$>", "</div>")
                            intestazione_strumento = intestazione_strumento + lettura_canali(contatore_strumenti, dc1, GetGlobalResourceObject("impianto_global", "gestisci_parametri"), GetGlobalResourceObject("impianto_global", "no_connected"), GetGlobalResourceObject("impianto_global", "last_update"), GetGlobalResourceObject("impianto_global", "no_flow"), GetGlobalResourceObject("impianto_global", "flow_ok"), check_alarm_general, check_connected, nome_impianto, time_connessione_min)
                            If check_alarm_general Then
                                contatore_strumenti_allarme = contatore_strumenti_allarme + 1
                            End If
                            If check_connected = False Then  ' contatore strumenti disconnessi
                                contatore_strumenti_disconnected = contatore_strumenti_disconnected + 1
                            End If

                        End If
                    Catch ex As Exception
                        If contatore_strumenti > 0 Then
                            contatore_strumenti = contatore_strumenti - 1
                        End If

                    End Try
                Next
                If contatore_strumenti Mod 3 = 0 Then
                    intestazione_strumento = Replace(intestazione_strumento, "<$$$$$$$$$$>", "")
                End If
                'aggiungo nella url le statistiche dell'impianto
                intestazione_strumento = Replace(intestazione_strumento, "$", "&statistica=" + (contatore_strumenti).ToString + "," + (contatore_strumenti_disconnected).ToString + "," + (contatore_strumenti_allarme).ToString)
                intestazione_strumento = intestazione_strumento + "</div>"
                If primo_strumento Then
                    intestazione_impianto = intestazione_impianto + "<div class=""tab-pane active"" id=""tab1-" + Format(contatore_impianti, "000") + """>"
                Else
                    intestazione_impianto = intestazione_impianto + "<div class=""tab-pane"" id=""tab1-" + Format(contatore_impianti, "000") + """>"
                End If
                intestazione_impianto = intestazione_impianto + widget_body_impianto(GetGlobalResourceObject("impianto_global", "dati_impianto"), GetGlobalResourceObject("impianto_global", "mappa"), Replace(dc.nome_impianto, ">", " : "), GetGlobalResourceObject("impianto_global", "codice"), dc.identificativo, dc.descrizione_impianato.ToString,
                                                             GetGlobalResourceObject("impianto_global", "referente"), dc.referente.ToString, dc.telefono_referente.ToString, dc.mail_referente.ToString, GetGlobalResourceObject("impianto_global", "statistica"), Format(data_aggiornamento.Day, "00"),
                                                             Format(data_aggiornamento.Month, "00"), data_aggiornamento.Year.ToString, ((100 * (contatore_strumenti - contatore_strumenti_disconnected)) / contatore_strumenti).ToString,
                                                             (contatore_strumenti - contatore_strumenti_disconnected).ToString + GetGlobalResourceObject("impianto_global", "strumenti_attivi"), GetGlobalResourceObject("impianto_global", "allarmi"), (contatore_strumenti_allarme).ToString,
                                                             (contatore_strumenti).ToString, indirizzo, check_connected, time_connessione_min, GetGlobalResourceObject("impianto_global", "no_connected"))


                intestazione_impianto = intestazione_impianto + intestazione_strumento
                intestazione_impianto = intestazione_impianto + "</div>"
                If primo_strumento Then
                    If split_impianto.Length > 1 Then
                        intestazione = intestazione + "<li class=""active""><a href=""#tab1-" + Format(contatore_impianti, "000") + """ data-toggle=""tab"">" + split_impianto(1) + "<strong>(" + (contatore_strumenti).ToString + ")</strong></a></li>"
                    Else
                        intestazione = intestazione + "<li class=""active""><a href=""#tab1-" + Format(contatore_impianti, "000") + """ data-toggle=""tab"">" + dc.identificativo + "<strong>(" + (contatore_strumenti).ToString + ")</strong></a></li>"
                    End If
                    primo_strumento = False
                Else
                    If split_impianto.Length > 1 Then
                        intestazione = intestazione + "<li><a href=""#tab1-" + Format(contatore_impianti, "000") + """ data-toggle=""tab"">" + split_impianto(1) + "<strong>(" + (contatore_strumenti).ToString + ")</strong></a></li>"
                    Else
                        intestazione = intestazione + "<li><a href=""#tab1-" + Format(contatore_impianti, "000") + """ data-toggle=""tab"">" + dc.identificativo + "<strong>(" + (contatore_strumenti).ToString + ")</strong></a></li>"
                    End If
                End If
                contatore_impianti = contatore_impianti + 1
            End If
        Next
        crea_indirizzo_mappa(indirizzo)
        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "</div>"
        intestazione_impianto = intestazione_impianto + "</div>"
        intestazione_impianto = intestazione_impianto + "</div>"
        Label1.Text = intestazione
        Label3.Text = intestazione_impianto
    End Sub
    Private Function get_indirizzo(ByVal indirizzo As String) As String
        Dim indirizzo_temp_str As String = ""
        If indirizzo = "" Or InStr(indirizzo, "empty") <> 0 Then
            Return ""
        Else
            If (InStr(indirizzo, "-") <> 0) Then
                Dim indirizzo_temp() As String = indirizzo.Split("-")
                indirizzo_temp_str = ""
                For i = 1 To indirizzo_temp.Length - 1
                    indirizzo_temp_str = indirizzo_temp_str + indirizzo_temp(i) + ","
                Next

                Return indirizzo_temp_str
            Else
                Return ""

            End If
        End If
        Return ""
    End Function
    Private Sub crea_indirizzo_mappa(ByVal indirizzo As String)
        Dim java_script_map As java_script = New java_script
        Dim set_variable_javascript(2, 1) As String
        'java_script_flow.call_function_javascript_onload(Page, "crea_mappa();")
        set_variable_javascript(0, 0) = "indirizzo"
        set_variable_javascript(0, 1) = "'" + get_indirizzo(indirizzo) + "'"
        java_script_map.set_url_setpoint(Page, set_variable_javascript, 2)
    End Sub
    Private Function widget_body_impianto(ByVal dati_impianto_traduzione As String, ByVal mappa_traduzione As String, ByVal nome_impianto As String,
                                          ByVal CODE_traduzione As String, ByVal code_impianto As String, ByVal descrizione_impianto As String,
                                          ByVal Referente_traduzione As String, ByVal nome_referente As String, ByVal telefono_referente As String,
                                          ByVal email_referente As String, ByVal Statistiche_traduzione As String, ByVal giorno As String,
                                          ByVal mese As String, ByVal anno As String, ByVal percentuale As String, ByVal Strumenti_traduzione As String,
                                          ByVal alarmi_traduzione As String, ByVal numero_allarmi As String, ByVal numero_strumenti As String, ByVal indirizzo_impianto As String,
                                          ByVal check_connected As Boolean, ByVal time_connessione_min As Long, ByVal non_connesso_traduzione As String) As String
        Dim intestazione As String = ""
        If nome_referente = "" Then
            nome_referente = "&nbsp"
        End If
        If telefono_referente = "" Then
            telefono_referente = "&nbsp"
        End If
        If email_referente = "" Then
            email_referente = "&nbsp"
        End If

        intestazione = intestazione + "<div class=""widget widget-tabs widget-quick hidden-print"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<ul>"
        intestazione = intestazione + "<li class=""active""><a href=""#quickIndexTab"" data-toggle=""tab"" class=""glyphicons cogwheels""><i></i>" + dati_impianto_traduzione + "</a></li>"
        intestazione = intestazione + "<li><a href=""#quickPhotosTab"" data-toggle=""tab"" class=""glyphicons google_maps""'><i></i>" + mappa_traduzione + "</a></li>"
        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "<div class=""widget-body"">"
        intestazione = intestazione + "<div class=""tab-content"">"

        intestazione = intestazione + "<div class=""tab-pane active"" id=""quickIndexTab"">"
        intestazione = intestazione + "<div class=""row-fluid"">"
        intestazione = intestazione + "<div class=""span8"">"
        intestazione = intestazione + "<h4>" + nome_impianto + "</h4>"
        intestazione = intestazione + "<h5><span>" + CODE_traduzione + ":</span><strong>" + code_impianto + " </strong></h5>"
        intestazione = intestazione + "<p>" + descrizione_impianto + "</p>"
        intestazione = intestazione + "<h5>" + Referente_traduzione + "</h5>"
        intestazione = intestazione + "<ul class=""unstyled icons"">"
        intestazione = intestazione + "<li class=""glyphicons user""><i></i>" + nome_referente + "</li>"
        intestazione = intestazione + "<li class=""glyphicons phone""><i></i>" + telefono_referente + "</li>"
        intestazione = intestazione + "<li class=""glyphicons e-mail""><i></i>" + email_referente + "</li>"
        intestazione = intestazione + " </ul>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<h5>" + Statistiche_traduzione + "</h5>"
        intestazione = intestazione + "<div class=""separator bottom""></div>"
        intestazione = intestazione + "<ul class=""unstyled icons"">"
        If check_connected Then
            intestazione = intestazione + "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + time_connessione_min.ToString + " min</li>"
        Else
            intestazione = intestazione + "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + non_connesso_traduzione + "</li>"

        End If
        'intestazione = intestazione + "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + giorno + "</span> <span class=""label"">" + mese + "</span> <span class=""label"">" + anno + "</span></li>"
        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        intestazione = intestazione + "<div data-percent=""" + percentuale + """ class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + numero_strumenti + "</span><canvas width=""50"" height=""50""></canvas><canvas width=""50"" height=""50""></canvas></div>"
        intestazione = intestazione + "<span class=""txt"">" + Strumenti_traduzione + " </span>"
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "</a>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<a href="""" class=""widget-stats margin-bottom-none"">"
        intestazione = intestazione + "<span class=""glyphicons remove""><i></i></span>"
        intestazione = intestazione + "<span class=""txt"">" + alarmi_traduzione + "</span>"
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "<span class=""count label label-important"">" + numero_allarmi + "</span>"
        intestazione = intestazione + "</a>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "<div class=""tab-pane"" id=""quickPhotosTab"">"
        'intestazione = intestazione + "<div  id=""quickPhotosTab"">"
        intestazione = intestazione + "<h4>" + nome_impianto + "</h4>"
        intestazione = intestazione + "<p>" + Replace(get_indirizzo(indirizzo_impianto), ",", " ") + "</p>"
        intestazione = intestazione + " <div id =""pippo"" class=""map_canvas"" style=""height:400px;width:100%;"">"

        'intestazione = intestazione + " <div class=""map_canvas"" id=""google-map-geocoding"" style=""height: 400px""></div>"

        'intestazione = intestazione + " <div id =""map-canvas""  style=""height:400px;margin: 0px;padding: 0px;"">"
        'intestazione = intestazione + " <div id =""map-canvas""  style=""height:400px;"">"
        'gestione mappa



        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"


        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"

        Return intestazione
    End Function

    Public Function lettura_canali(ByVal numero_strumenti As Integer, ByVal riga As ermes_web_20.quey_db.strumentiRow, _
                                    ByVal gestisci_parametri_traduzione As String, _
                                    ByVal not_connected_traduzione As String, ByVal last_update_traduzione As String, _
                                   ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                                   ByRef check_alarm_general As Boolean, ByRef check_connected As Boolean, ByVal nome_impanto As String, ByRef time_connessione_min As Long) As String
        Dim intestazione As String = ""
        Dim href As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        Dim tipo_strumento As String = riga.tipo_strumento
        Dim time_connected As Long
        check_connected = main_function.check_is_connected(riga.data_aggiornamento, time_connected)
        time_connessione_min = time_connected
        If numero_strumenti > 0 Then
            numero_strumenti = numero_strumenti - 1
        End If
        If numero_strumenti Mod 3 = 0 Then
            intestazione = intestazione + "<div class=""row-fluid"">"
        End If

        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<div class=""widget"">"
        intestazione = intestazione + "<div class=""""><span style=""text-align:right;color:#000;width:100%;position:absolute;right:10px;"">" + id_strumento + " </span><h3 class=""heading-arrow"">" + tipo_strumento_label + "</h3><span></span></div>"
        intestazione = intestazione + "<div class=""widget-body"">"
        intestazione = intestazione + "<table class=""table table-bordered table-condensed table-striped table-primary table-vertical-center checkboxs"">"
        intestazione = intestazione + "<tbody>"
        'gestione items
        Select Case tipo_strumento
            Case "max5" 'Replace(nome_impanto, " ", "£") 
                intestazione = intestazione + items_max5(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "max5.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
            Case "LDtower"
                intestazione = intestazione + items_tower(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ldtower.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_tower(riga, check_connected)
            Case "Tower"
                intestazione = intestazione + items_tower(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "tower.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_tower(riga, check_connected)
            Case "LD"
                intestazione = intestazione + items_ld(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_ld(riga, check_connected)
            Case "LDDT"
                intestazione = intestazione + items_lddt(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_ld(riga, check_connected)
            Case "LDD4"
                intestazione = intestazione + items_ld(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_ld(riga, check_connected)
            Case "LDMA"
                intestazione = intestazione + items_ld_ma(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=45&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
            Case "LDLG"
                intestazione = intestazione + items_ld_lg(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=58&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto

            Case "LDS"
                intestazione = intestazione + items_lds(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_lds(riga, check_connected)
            Case "LD4"
                intestazione = intestazione + items_ld4(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_lds(riga, check_connected)
            Case "WD"
                intestazione = intestazione + items_wd(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "wd.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_wd(riga, check_connected)
            Case "WH"
                intestazione = intestazione + items_wd(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "wd.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_wd(riga, check_connected)
            Case "LTB"
                intestazione = intestazione + items_ltb(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "ltb.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_lds(riga, check_connected)
            Case "LTA"
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_lds(riga, check_connected)
            Case "LTD"
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_lds(riga, check_connected)
            Case "LTU"
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                'items_lds(riga, check_connected)

        End Select
        'end gestione items

        intestazione = intestazione + "</tbody>"
        intestazione = intestazione + "</table>"

        intestazione = intestazione + "<br>"
        intestazione = intestazione + "<span class=""btn btn-block btn-default""><a href=""" + href + """>" + gestisci_parametri_traduzione + "</a></span>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        If (numero_strumenti + 1) Mod 3 = 0 Then

            intestazione = intestazione + "<$$$$$$$$$$>"


        End If
        Return intestazione
    End Function
    Public Function items_tower(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                   ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                   ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                   ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim scala_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim configurazione_canali As String = ""
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean
        Dim version_str As String = ""
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim personalizzazione_aquacare As Integer = 0
        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        config_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        allrmr_value = main_function.get_split_str(riga.value3)
        main_function_config.chek_tower_version(riga.nome, version_str, personalizzazione_aquacare)

        check_alarm_general = False

        configurazione_canali = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)

        numero_canali = configurazione_canali.Split("_").Length

        For i = 1 To numero_canali 'Tower può essere uno, due o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            'intestazione = intestazione + "<td class=""center"">"

            Select Case i
                Case 1 'controllo canale 1
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, fattore_divisione_temp, _
                                                                  , , scala_temp, , , label_canale_temp)
                    If scala_temp = 3000 Then
                        valore_canale_temp = Val(Mid(valuer_value(0), 3, 4)) / fattore_divisione_temp
                    Else
                        valore_canale_temp = (Val(Mid(valuer_value(0), 3, 4)) * 10) / fattore_divisione_temp
                    End If

                    If main_function.alarm_tower_bleed_timeout(allrmr_value) Or main_function.alarm_tower_high_conductivity(allrmr_value) _
                        Or main_function.alarm_tower_low_conductivity(allrmr_value) Or main_function.alarm_tower_level_prebiocide1(allrmr_value) _
                        Or main_function.alarm_tower_level_biocide1(allrmr_value) Or main_function.alarm_tower_level_prebiocide2(allrmr_value) _
                        Or main_function.alarm_tower_level_biocide2(allrmr_value) Or main_function.alarm_tower_level_inhibitor(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 'controllo canale 2
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , _
                                                                  fattore_divisione_temp, , , , , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 11, 4)) / fattore_divisione_temp

                    If main_function.alarm_tower_level_ch2(allrmr_value) Or main_function.alarm_tower_ch2_low(allrmr_value) _
                        Or main_function.alarm_tower_ch2_high(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 3 'controllo canale 3
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , _
                                                                  fattore_divisione_temp, , , , , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 15, 4)) / fattore_divisione_temp

                    If main_function.alarm_tower_level_ch3(allrmr_value) Or main_function.alarm_tower_ch3_low(allrmr_value) _
                        Or main_function.alarm_tower_ch3_high(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If

            End Select


            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_tower_flow(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        If main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Then
            check_alarm_general = True
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">WMB</h4></td>"
        End If
        If main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Then
            check_alarm_general = True
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">WMI</h4></td>"
        End If
        If main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then
            check_alarm_general = True
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">CF</h4></td>"
        End If

        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function
    Public Function items_wd(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                       ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                       ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 2

        For i = 1 To numero_canali 'wd può essere due
            intestazione = intestazione + "<tr class=""selectable"">"
            ' intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    If main_function.alarm_wd_livello1_ph(allrmr_value) Or main_function.alarm_wd_dosalarm_ph(allrmr_value) _
                        Or main_function.alarm_wd_probefail_ph(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 'controllo allarmi canale 2
                    If main_function.alarm_wd_livello1_cl(allrmr_value) Or main_function.alarm_wd_dosalarm_cl(allrmr_value) _
                        Or main_function.alarm_wd_probefail_ph(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If

            End Select
            valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp

            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_wd_flusso(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function
    Public Function items_lds(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                       ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                       ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 1

        For i = 1 To numero_canali 'lds solo un canale
            intestazione = intestazione + "<tr class=""selectable"">"
            'intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    If main_function.alarm_lds_livello(allrmr_value) Or main_function.alarm_lds_feedlimit(allrmr_value) _
                        Or main_function.alarm_lds_dosalarm(allrmr_value) Or main_function.alarm_lds_probefail(allrmr_value) _
                         Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
            End Select
            valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp

            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(2), 1, 3)))
        formato_data = Mid(valuer_value(3), 1, 1)

        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + (temperature_value / 10).ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_lds_flusso(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function
    Public Function items_ld(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                           ByVal last_update_traduzione As String, ByVal time_connected As Long,
                           ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                           ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False

        If Mid(config_value(3), 3, 3) <> "306" Then ' terzo canale esistente
            numero_canali = 3
        Else
            numero_canali = 2
        End If


        For i = 1 To numero_canali 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    If main_function.alarm_ld_livello1_ph(allrmr_value) Or main_function.alarm_ld_livello2_ph(allrmr_value) _
                        Or main_function.alarm_ld_feedlimit_ph(allrmr_value) Or main_function.alarm_ld_dosalarm_ph(allrmr_value) _
                        Or main_function.alarm_ld_probefail_ph(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 'controllo allarmi canale 2
                    If main_function.alarm_ld_livello1_cl(allrmr_value) Or main_function.alarm_ld_feedlimit_cl(allrmr_value) _
                        Or main_function.alarm_ld_dosalarm_cl(allrmr_value) Or main_function.alarm_ld_probefail_cl(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 3 'controllo allarmi canale 3
                    canale_allarme = False 'non ci sono allarmi sul canale 3
            End Select
            If i = 3 Then
                valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
            Else
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            End If
            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)

        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + (temperature_value / 10).ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_ld_flusso(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function


    Public Function items_lddt(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                           ByVal last_update_traduzione As String, ByVal time_connected As Long,
                           ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                           ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 2



        For i = 1 To numero_canali 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    If main_function.alarm_ld_livello1_ph(allrmr_value) Or main_function.alarm_ld_livello2_ph(allrmr_value) _
                        Or main_function.alarm_ld_feedlimit_ph(allrmr_value) Or main_function.alarm_ld_dosalarm_ph(allrmr_value) _
                        Or main_function.alarm_ld_probefail_ph(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 'controllo allarmi canale 2
                    If main_function.alarm_ld_livello1_cl(allrmr_value) Or main_function.alarm_ld_feedlimit_cl(allrmr_value) _
                        Or main_function.alarm_ld_dosalarm_cl(allrmr_value) Or main_function.alarm_ld_probefail_cl(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 3 'controllo allarmi canale 3
                    canale_allarme = False 'non ci sono allarmi sul canale 3
            End Select
            If i = 3 Then
                valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
            Else
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            End If
            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)

        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + (temperature_value / 10).ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_ld_flusso(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function
    Public Function items_ld_ma(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                       ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                       ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean


        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim setpntr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0

        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        setpntr_value = main_function.get_split_str(riga.value7)

        check_alarm_general = False
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)

        For i = 1 To numero_canali 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_ma(config_value, i, setpntr_value, fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    If main_function.alarm_ld_ma_livello1(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 'controllo allarmi canale 2
                    If main_function.alarm_ld_ma_livello2(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 3 'controllo allarmi canale 3
                    If main_function.alarm_ld_ma_livello3(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 4 'controllo allarmi canale 4
                    If main_function.alarm_ld_ma_livello4(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 5 'controllo allarmi canale 5
                    If main_function.alarm_ld_ma_livello5(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If

            End Select
            valore_canale_temp = Val(Mid(valuer_value(i), 1, 5)) / fattore_divisione_temp

            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "L</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "L</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "L</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
  
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        ' valore canale ok

        Return intestazione

    End Function
    Public Function items_ld_lg(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                   ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                   ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                   ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim label_canale_temp1 As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim valore_canale_temp1 As Single = 0
        Dim canale_allarme As Boolean


        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim setpntr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0

        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        setpntr_value = main_function.get_split_str(riga.value7)

        check_alarm_general = False
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)

        For i = 1 To numero_canali * 2 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            If (i <= numero_canali) Then
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lg(config_value, i, setpntr_value, fattore_divisione_temp)
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lg(config_value, i + (5 - numero_canali), setpntr_value, fattore_divisione_temp)
            End If

            ' label_canale_temp1 = main_function_config.get_tipo_strumento_ld_ma(config_value, i + 5, setpntr_value, fattore_divisione_temp)
            Select Case i
                Case 1 And 6 'controllo allarmi canale 1
                    If main_function.alarm_ld_ma_livello1(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 And 7 'controllo allarmi canale 2
                    If main_function.alarm_ld_ma_livello2(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 3 And 8 'controllo allarmi canale 3
                    If main_function.alarm_ld_ma_livello3(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 4 And 9 'controllo allarmi canale 4
                    If main_function.alarm_ld_ma_livello4(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 5 And 10 'controllo allarmi canale 5
                    If main_function.alarm_ld_ma_livello5(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If

            End Select
            If (i <= numero_canali) Then
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 5)) / fattore_divisione_temp
            Else
                valore_canale_temp = Val(Mid(valuer_value(i + (5 - numero_canali)), 1, 5)) / fattore_divisione_temp
            End If
            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    If (i <= numero_canali) Then
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "L</h4></td>"
                    Else
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "m3</h4></td>"
                    End If

                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    If (i <= numero_canali) Then
                        intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "L</h4></td>"
                    Else
                        intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "m3</h4></td>"
                    End If

                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                If (i <= numero_canali) Then
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "L</h4></td>"
                Else
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "m3</h4></td>"
                End If

            End If
            intestazione = intestazione + "</tr>"

        Next

        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        ' valore canale ok

        Return intestazione

    End Function
    Public Function items_ltb(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                         ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                         ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                         ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 2


        For i = 1 To numero_canali 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    'If main_function.alarm_ld4_livello_ph(allrmr_value) _
                    '    Or main_function.alarm_ld4_feedlimit_ph(allrmr_value) Or main_function.alarm_ld4_dosalarm_ph(allrmr_value) _
                    '    Or main_function.alarm_ld4_probefail_ph(allrmr_value) Then
                    '    check_alarm_general = True
                    '    canale_allarme = True
                    'Else
                    canale_allarme = False
                    'End If
                Case 2 'controllo allarmi canale 2
                    'If main_function.alarm_ld4_livello_cl(allrmr_value) Or main_function.alarm_ld4_feedlimit_cl(allrmr_value) _
                    '    Or main_function.alarm_ld4_dosalarm_cl(allrmr_value) Or main_function.alarm_ld4_probefail_cl(allrmr_value) Then
                    '    check_alarm_general = True
                    '    canale_allarme = True
                    'Else
                    canale_allarme = False
                    'End If


            End Select

            valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp

            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)

        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If formato_data = "0" Or formato_data = "3" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + (temperature_value / 10).ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If formato_data = "0" Or formato_data = "3" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_ltb_flow(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function



    Public Function items_lta(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                         ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                         ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                         ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 2


        For i = 1 To numero_canali 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    'If main_function.alarm_ld4_livello_ph(allrmr_value) _
                    '    Or main_function.alarm_ld4_feedlimit_ph(allrmr_value) Or main_function.alarm_ld4_dosalarm_ph(allrmr_value) _
                    '    Or main_function.alarm_ld4_probefail_ph(allrmr_value) Then
                    '    check_alarm_general = True
                    '    canale_allarme = True
                    'Else
                    canale_allarme = False
                    'End If
                Case 2 'controllo allarmi canale 2
                    'If main_function.alarm_ld4_livello_cl(allrmr_value) Or main_function.alarm_ld4_feedlimit_cl(allrmr_value) _
                    '    Or main_function.alarm_ld4_dosalarm_cl(allrmr_value) Or main_function.alarm_ld4_probefail_cl(allrmr_value) Then
                    '    check_alarm_general = True
                    '    canale_allarme = True
                    'Else
                    canale_allarme = False
                    'End If


            End Select

            valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp

            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)

        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If formato_data = "0" Or formato_data = "3" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + (temperature_value / 10).ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If formato_data = "0" Or formato_data = "3" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_ltb_flow(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function



    Public Function items_ld4(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                         ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                         ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String, _
                         ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 4


        For i = 1 To numero_canali 'ld può essere duo o tre canali
            intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    If main_function.alarm_ld4_livello_ph(allrmr_value) _
                        Or main_function.alarm_ld4_feedlimit_ph(allrmr_value) Or main_function.alarm_ld4_dosalarm_ph(allrmr_value) _
                        Or main_function.alarm_ld4_probefail_ph(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 2 'controllo allarmi canale 2
                    If main_function.alarm_ld4_livello_cl(allrmr_value) Or main_function.alarm_ld4_feedlimit_cl(allrmr_value) _
                        Or main_function.alarm_ld4_dosalarm_cl(allrmr_value) Or main_function.alarm_ld4_probefail_cl(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                Case 3 'controllo allarmi canale 3
                    If main_function.alarm_ld4_feedlimit_mV(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If

                Case 4 'controllo allarmi canale 4
                    If main_function.alarm_ld4_feedlimit_ntu(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If

            End Select

            valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp

            If check_connected Then
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                End If
            Else ' strumento non connesso
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
            End If
            intestazione = intestazione + "</tr>"

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(5), 1, 3)))
        formato_data = Mid(valuer_value(6), 1, 1)

        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + (temperature_value / 10).ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If formato_data = "0" Then ' europeo
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperature_value.ToString + " °F" + "</h4></td>"
            End If

        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura
        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        If main_function.alarm_ld4_flusso(allrmr_value) Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function
    Public Function items_max5(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean, _
                               ByVal last_update_traduzione As String, ByVal time_connected As Long, _
                               ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String _
                               , ByRef check_alarm_general As Boolean) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_combinato As Integer = 1
        Dim valore_canale_temp As Single = 0
        Dim scala_temp As Integer = 0
        Dim canale_allarme As Boolean
        Dim config_value() As String
        Dim alarm_value() As String
        Dim flow_value() As String
        Dim option_value() As String
        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        Dim check_alarm As Integer = 0
        check_alarm_general = False
        config_value = main_function.get_split_str(riga.value1)
        alarm_value = main_function.get_split_str(riga.value2)
        flow_value = main_function.get_split_str(riga.value3)
        option_value = main_function.get_split_str(riga.value4)
        For i = 1 To 5
            'gestione personalizzazione yagel
            If main_function.get_tipo_personalizzazione(riga.nome) = "yagel" And i = 5 Then ' personalizzazione yagel
                label_canale_temp = main_function_config.get_tipo_strumento_max5(i, "phY", option_value(1), fattore_divisione_temp, scala_temp, valore_canale_temp, flow_value(2))
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_max5(i, config_value(i - 1), option_value(0), fattore_divisione_temp, scala_temp, , , fattore_divisione_combinato)
                valore_canale_temp = Val(Mid(alarm_value(i - 1), 3, 4)) / fattore_divisione_temp
            End If
            If main_function.alarm_max5_aa(alarm_value(i + 4)) Or main_function.alarm_max5_ab(alarm_value(i + 4)) Or main_function.alarm_max5_ad(alarm_value(i + 4)) _
                Or main_function.alarm_max5_ar(alarm_value(i + 4)) Or main_function.alarm_max5_levda(alarm_value(i + 4)) Or main_function.alarm_max5_levdb(alarm_value(i + 4)) _
                Or main_function.alarm_max5_levma(alarm_value(i + 4)) Or main_function.alarm_max5_levpa(alarm_value(i + 4)) Or main_function.alarm_max5_levpb(alarm_value(i + 4)) Then
                check_alarm_general = True
                canale_allarme = True
            Else
                canale_allarme = False
            End If
            If main_function.get_tipo_personalizzazione(riga.nome) = "seiCanali" And i = 3 Then
                intestazione = intestazione + "<tr class=""selectable"">"
                valore_canale_temp = Val(Mid(alarm_value(i - 1), 3, 4)) / 1000
                If check_connected Then
                    If canale_allarme Then ' canale in allarme
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">HClO</h4></td>"
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                    Else ' canale in non allarme
                        intestazione = intestazione + "<td class=""center""><h4>HClO</h4></td>"
                        intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                    End If
                Else ' strumento non connesso
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">HClO</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
                End If
                valore_canale_temp = Val(Mid(alarm_value(i), 3, 4)) / fattore_divisione_temp ' cloro libero

                intestazione = intestazione + "</tr>"
            End If
            If label_canale_temp <> "" Then
                intestazione = intestazione + "<tr class=""selectable"">"

                If check_connected Then
                    If canale_allarme Then ' canale in allarme
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                    Else ' canale in non allarme
                        intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                        intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                    End If
                Else ' strumento non connesso
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
                End If
                intestazione = intestazione + "</tr>"


            End If
            If main_function.get_tipo_personalizzazione(riga.nome) = "seiCanali" And i = 3 Then
                intestazione = intestazione + "<tr class=""selectable"">"
                label_canale_temp = "Clt"
                valore_canale_temp = Val(Mid(alarm_value(13), 3, 4)) / fattore_divisione_temp
                If check_connected Then
                    If canale_allarme Then ' canale in allarme
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                    Else ' canale in non allarme
                        intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                        intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                    End If
                Else ' strumento non connesso
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr class=""selectable"">"
                label_canale_temp = "ClCom"
                valore_canale_temp = Val(Mid(alarm_value(4), 3, 4)) / fattore_divisione_temp
                If check_connected Then
                    If canale_allarme Then ' canale in allarme
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + label_canale_temp + "</h4></td>"
                        intestazione = intestazione + "<td style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + valore_canale_temp.ToString + "</h4></td>"
                    Else ' canale in non allarme
                        intestazione = intestazione + "<td class=""center""><h4>" + label_canale_temp + "</h4></td>"
                        intestazione = intestazione + "<td class=""center""><h4>" + valore_canale_temp.ToString + "</h4></td>"
                    End If
                Else ' strumento non connesso
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + label_canale_temp + "</h4></td>"
                    intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + valore_canale_temp.ToString + "</h4></td>"
                End If
                intestazione = intestazione + "</tr>"
                i = 5
            End If

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim temperature_value1 As Single = 0
        Dim temperatureIntestazione As String = ""

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = Val(main_function_config.get_temperature_info(flow_value(3), temperature_type))

        If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
            temperature_value = Val(main_function_config.get_temperature_infoDoppiaPiscina(flow_value(3), temperature_value1, temperature_type))
            temperatureIntestazione = "T1:"
        End If
        If check_connected Then
            'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
            If temperature_type = 0 Then 'temperatura in celsius
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperatureIntestazione + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>" + temperatureIntestazione + temperature_value.ToString + " °F" + "</h4></td>"
            End If
            If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
                intestazione = intestazione + "</tr>"
                If temperature_type = 0 Then 'temperatura in celsius
                    intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>T2:" + temperature_value1.ToString + " °C" + "</h4></td>"
                Else
                    intestazione = intestazione + "<td colspan=""2"" class=""center""><h4>T2:" + temperature_value1.ToString + " °F" + "</h4></td>"
                End If
            End If
        Else ' strumento non connesso
            'intestazione = intestazione + "<td class=""center""><h4 style=""color:#cccccc"">" + "  " + "</h4></td>"
            If temperature_type = 0 Then 'temperatura in celsius
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperatureIntestazione + temperature_value.ToString + " °C" + "</h4></td>"
            Else
                intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">" + temperatureIntestazione + temperature_value.ToString + " °F" + "</h4></td>"
            End If
            If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
                intestazione = intestazione + "</tr>"
                If temperature_type = 0 Then 'temperatura in celsius
                    intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">T2:" + temperature_value1.ToString + " °C" + "</h4></td>"
                Else
                    intestazione = intestazione + "<td colspan=""2"" class=""center""><h4 style=""color:#cccccc"">T2:" + temperature_value1.ToString + " °F" + "</h4></td>"
                End If
            End If
        End If
        intestazione = intestazione + "</tr>"
        ' end visualizzazione temperatura

        If check_connected Then ' se true vuol dire che è connesso
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        Else
            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        End If
        Dim integer_item As Integer = 0
        integer_item = main_function.alarm_max5_flow(alarm_value(10)) 'flusso
        If integer_item > 0 Then
            check_alarm_general = True
            main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
            If ore_flow = 0 Then
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
            Else
                intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
            End If
        Else

            intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        End If
        ' valore canale ok
        '<tr class="selectable">
        '    <td class="center"><h4>pH</h4></td>
        '<td class="center"><h4>07.16</h4></td>
        '</tr>
        ''end valore canale ok
        ''valore canale allarme
        '<tr class="selectable">
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">pH</h4></td>
        '    <td style="border-color: #e04545; background-color: #e04545; text-align:center; 	"><h4 style="color:white;">07.16</h4></td>
        '</tr>  
        ''end valore canale ok
        ''valore canale disconnesso
        '<tr class="selectable">
        '    <td class="center"><h4 style="color:#cccccc">pH</h4></td>
        '<td class="center"><h4 style="color:#cccccc">07.16</h4></td>
        '</tr>
        'end valore canale disconnesso
        Return intestazione

    End Function

    Private Sub impianto_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Dim java_script_flow As java_script = New java_script

        'java_script_flow.call_function_javascript_onload(Page, "crea_mappa();")

    End Sub
End Class