Public Class main_max5
    Inherits lingua

   
    Private Sub main_max5_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = ""
        If Not IsPostBack Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_max5(nome_impianto, codice_impianto, id_485_impianto)
            'refresh_max5(nome_impianto, codice_impianto, id_485_impianto, "CODE", "Referente", statistica, "Statistiche", "Strumenti Attivi", "Allarmi", "SetPoint", "Temperature", "Log", "Log All")
        End If
    End Sub
    Public Sub posiziona_max5(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim intestazione As String = ""
        Dim config_value() As String
        Dim alarm_value() As String
        Dim flow_value() As String
        Dim option_value() As String

        Dim name_sp1() As String
        Dim name_sp2() As String
        Dim name_sp3() As String
        Dim name_sp4() As String
        Dim name_sp5() As String

        Dim label_canale_temp As String = ""
        Dim contatore_canale As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim fattore_divisione_temp As Integer
        Dim fattore_divisione_combinato As Integer = 1
        Dim number_version As Integer = 0
        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        alarm_value = main_function.get_split_str(riga_strumento.value2)
        flow_value = main_function.get_split_str(riga_strumento.value3)
        option_value = main_function.get_split_str(riga_strumento.value4)
        number_version = main_function.get_version_integer(riga_strumento.nome)
        If number_version > 29 Then
            name_sp1 = main_function.get_split_str(riga_strumento.value10)
            name_sp2 = main_function.get_split_str(riga_strumento.value11)
            name_sp3 = main_function.get_split_str(riga_strumento.value12)
            name_sp4 = main_function.get_split_str(riga_strumento.value13)
            name_sp5 = main_function.get_split_str(riga_strumento.value14)
        End If
        For i = 1 To 5
            If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "yagel" And i = 5 Then ' personalizzazione yagel
                label_canale_temp = main_function_config.get_tipo_strumento_max5(i, "phY", option_value(1), fattore_divisione_temp, , valore_canale_temp, flow_value(2))
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_max5(i, config_value(i - 1), option_value(1), fattore_divisione_temp, , , , fattore_divisione_combinato)
                If label_canale_temp <> "" Then
                    valore_canale_temp = Val(Mid(alarm_value(i - 1), 3, 4)) / fattore_divisione_temp
                End If
                If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" And i = 3 Then
                    label_canale_temp = "HClO"
                    valore_canale_temp = Val(Mid(alarm_value(i - 1), 3, 4)) / 1000
                End If
                If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" And i = 4 Then
                    label_canale_temp = "Cl2"
                End If
            End If
            If label_canale_temp <> "" Then
                contatore_canale = contatore_canale + 1
                Select Case i
                    Case 1
                        intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), alarm_value(i - 1), alarm_value(i + 4), _
                                    number_version, name_sp1)
                    Case 2
                        intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), alarm_value(i - 1), alarm_value(i + 4), _
                                    number_version, name_sp2)
                    Case 3
                        intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), alarm_value(i - 1), alarm_value(i + 4), _
                                    number_version, name_sp3)
                    Case 4
                        intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), alarm_value(i - 1), alarm_value(i + 4), _
                                    number_version, name_sp4)
                    Case 5
                        intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), alarm_value(i - 1), alarm_value(i + 4), _
                                    number_version, name_sp5)
                End Select
            End If
        Next
        intestazione = intestazione + "</div>" 'chiusura row-fluid
        literal1.Text = intestazione
        crea_header(flow_value, GetGlobalResourceObject("max5_global", "temperature"), option_value, main_function.get_tipo_personalizzazione(riga_strumento.nome), GetGlobalResourceObject("max5_global", "flow_meter"), GetGlobalResourceObject("max5_global", "totalizer"), alarm_value, number_version,
                    GetGlobalResourceObject("ld_global", "flow"), GetGlobalResourceObject("max5_global", "stby"), GetGlobalResourceObject("max5_global", "probe_clean"), GetGlobalResourceObject("max5_global", "restore_time"), GetGlobalResourceObject("max5_global", "manual"))
        crea_status_timer(flow_value)
    End Sub
    'gestione header per temperatura, flusso , allarme no flow e allarmi generali
    Private Function crea_header(ByVal str_input() As String, ByVal temperatura_traduzione As String, ByVal option_str() As String, _
                                 ByVal tipo_personalizzazione As String, ByVal Flow_meter_traduzione As String, ByVal Totalizer_traduzione As String, ByVal alarm_value_general() As String, ByVal number_version As Integer, _
                                 ByVal flow_traduzione As String, ByVal stby_traduzione As String, ByVal clean_traduzione As String, _
                                 ByVal restore_traduzione As String, ByVal manual_traduzione As String) As String
        Dim intestazione As String = ""
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim temperature_value1 As Single = 0
        Dim flow_ma_value As Single = 0
        Dim temperatureIntestazione As String = ""
        Dim date_time() As String = main_function_config.get_time_info(str_input(3)).Split("|")
        'creazione widget data ora
        '<li class="glyphicons calendar"><i></i> <span class="label">10</span> <span class="label">July</span> <span class="label">1986</span></li>
        If date_time.Length > 3 Then
            literal3.Text = "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + date_time(0) + "</span> <span class=""label"">" + date_time(1) + "</span> <span class=""label"">" + date_time(2) + "</span> <span class=""label"">" + date_time(3) + "</span></li>"
        End If
        'end creazione data ora
        'creazione widget temperatura
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        temperature_value = Val(main_function_config.get_temperature_info(str_input(3), temperature_type))
        If tipo_personalizzazione = "doppiaPiscina" Then
            temperature_value = Val(main_function_config.get_temperature_infoDoppiaPiscina(str_input(3), temperature_value1, temperature_type))
            temperatureIntestazione = "T1:"
        End If
        If temperature_type = 0 Then 'temperatura in celsius
            intestazione = intestazione + "<div data-percent=""" + temperature_value.ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 25px; line-height: 50px;""><span class=""value"">" + temperatureIntestazione + temperature_value.ToString + "</span><canvas width=""50"" height=""25""></canvas></div>"
            If tipo_personalizzazione = "doppiaPiscina" Then
                intestazione = intestazione + "<div data-percent=""" + temperature_value1.ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 25px; line-height: 50px;""><span class=""value"">T2:" + temperature_value1.ToString + "</span><canvas width=""50"" height=""25""></canvas></div>"
            End If
            intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °C</span>"
        Else
            intestazione = intestazione + "<div data-percent=""" + ((temperature_value - 32) / 1.8).ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 25px; line-height: 25px;""><span class=""value"">" + temperatureIntestazione + temperature_value.ToString + "</span>°<canvas width=""50"" height=""25""></canvas></div>"
            If tipo_personalizzazione = "doppiaPiscina" Then
                intestazione = intestazione + "<div data-percent=""" + ((temperature_value1 - 32) / 1.8).ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 25px; line-height: 25px;""><span class=""value"">T2:" + temperature_value1.ToString + "</span>°<canvas width=""50"" height=""25""></canvas></div>"
            End If
            intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °F</span>"
        End If
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "</a>"
        literal2.Text = intestazione
        ' end creazione widget temperatura
        ' creazione widget flusso instantaneo/totalizzatore
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
        intestazione = intestazione + "<span>" + Flow_meter_traduzione + "</span>"
        Select Case main_function_config.get_flow_unit(option_str(2))
            Case "0" 'm3/h
                If tipo_personalizzazione = "yagel" Then
                    intestazione = intestazione + "<span>" + Totalizer_traduzione + "</span>"
                    intestazione = intestazione + "<span><strong>" + Mid(str_input(2), 3, 9) + "</strong></span> L <br/>"
                Else
                    intestazione = intestazione + "<span><strong>" + Mid(str_input(2), 13, 5) + "</strong></span> l/h <br/>"
                    intestazione = intestazione + "<span>" + Totalizer_traduzione + "</span>"
                    intestazione = intestazione + "<span><strong>" + Mid(str_input(2), 3, 9) + "</strong></span> L <br/>"

                End If

            Case "1" 'G/m
                If tipo_personalizzazione = "yagel" Then
                    intestazione = intestazione + "<span>" + Totalizer_traduzione + "</span>"
                    intestazione = intestazione + "<span><strong>" + Mid(str_input(2), 3, 9) + "</strong></span> L <br/>"
                Else
                    intestazione = intestazione + "<span><strong>" + Mid(str_input(2), 13, 5) + "</strong></span> G/m <br/>"
                    intestazione = intestazione + "<span>" + Totalizer_traduzione + "</span>"
                    intestazione = intestazione + "<span><strong>" + Mid(str_input(2), 3, 9) + "</strong></span> G <br/>"
                End If
        End Select
        'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</a>"
        literal4.Text = intestazione
        ' end creazione widget flusso instantaneo/totalizzatore
        ' creazione widget flusso mA per yagel
        If tipo_personalizzazione = "yagel" Then
            literal5.Visible = True
            flow_ma_value = Val(Mid(str_input(2), 19, 3)) / 10
            intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
            intestazione = intestazione + "<div data-percent=""" + ((flow_ma_value * 100) / 20).ToString + """ class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + flow_ma_value.ToString + "</span><canvas width=""50"" height=""50""></canvas></div>"
            intestazione = intestazione + "<span class=""txt"">mA Flow</span>"
            intestazione = intestazione + "<div class=""clearfix""></div>"
            intestazione = intestazione + "</a>"
            literal5.Text = intestazione
        Else
            literal5.Visible = False
        End If
        ' end creazione widget flusso mA per yagel
        '  creazione elenco messaggi generali o allarmi generali

        intestazione = "<tr style="""">"
        Dim integer_item As Integer = 0
        Dim numeroTemperature As String = ""
        If tipo_personalizzazione = "doppiaPiscina" Then
            numeroTemperature = "1"
        End If
        integer_item = main_function.alarm_max5_flow(alarm_value_general(10)) 'flusso
        If integer_item > 0 Then
            intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + numeroTemperature + " " + integer_item.ToString + "min</td>"
            intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
        Else
            intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + numeroTemperature + "</td>"
            intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
        End If
        intestazione = intestazione + "</tr>"

        If tipo_personalizzazione = "doppiaPiscina" Then

            intestazione = intestazione + "<tr>"
            integer_item = main_function.alarm_max5_flow2(alarm_value_general(14)) 'flow 2
            If integer_item > 0 Then
                intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "2 " + integer_item.ToString + "min</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
            Else
                intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "2</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
            End If
            intestazione = intestazione + "</tr>"
        End If
        integer_item = main_function.alarm_max5_stby(alarm_value_general(10)) 'stby
        intestazione = intestazione + "<tr>"
        If integer_item > 0 Then
            If integer_item > 0 Then
                intestazione = intestazione + "<td width=""32%"">" + stby_traduzione + " " + integer_item.ToString + "min</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
            Else
                intestazione = intestazione + "<td width=""32%"">" + stby_traduzione + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
            End If
        End If
        intestazione = intestazione + "</tr>"
        integer_item = main_function.alarm_max5_probe_clean(alarm_value_general(10)) 'probe clean

        If integer_item > 0 Then
            intestazione = intestazione + "<tr>"
            If integer_item = 1 Then ' clean time
                intestazione = intestazione + "<td width=""32%"">" + clean_traduzione + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
            End If
            If integer_item > 1 Then ' restore time
                intestazione = intestazione + "<td width=""32%"">" + restore_traduzione + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_off""></td>"
            End If
            intestazione = intestazione + "</tr>"
        End If

        If number_version > 29 Then ' controlli per temperature alarm e manual
            intestazione = intestazione + "<tr>"
            If main_function.alarm_max5_temperature(alarm_value_general(12)) Then ' alarm temperature
                intestazione = intestazione + "<td width=""32%"">" + temperatura_traduzione + " " + numeroTemperature + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
            Else
                intestazione = intestazione + "<td width=""32%"">" + temperatura_traduzione + " " + numeroTemperature + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
            End If
            intestazione = intestazione + "</tr>"
            If tipo_personalizzazione = "doppiaPiscina" Then
                intestazione = intestazione + "<tr>"
                If main_function.alarm_max5_temperature(alarm_value_general(13)) Then ' alarm temperature
                    intestazione = intestazione + "<td width=""32%"">" + temperatura_traduzione + " 2</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + temperatura_traduzione + " 2</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"
            End If
            If tipo_personalizzazione = "seiCanali" Then
                intestazione = intestazione + "<tr>"
                Dim label_canale_temp As String = "Clt"
                Dim valore_canale_temp As Single = Val(Mid(alarm_value_general(13), 3, 4)) / 100

                intestazione = intestazione + "<td width=""32%"">" + label_canale_temp + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center"">" + valore_canale_temp.ToString + "</td>"

                intestazione = intestazione + "</tr>"
            End If
            intestazione = intestazione + "<tr>"
            If main_function.alarm_max5_manual(alarm_value_general(11)) Then ' alarm manual
                intestazione = intestazione + "<td width=""32%"">" + manual_traduzione + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
            Else
                intestazione = intestazione + "<td width=""32%"">" + manual_traduzione + "</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
            End If
            intestazione = intestazione + "</tr>"

        End If
        If tipo_personalizzazione = "yagel" Then ' gestione allarme flow meter low
            If main_function.alarm_max5_yagel_flowmeterlow(str_input(2)) Then
                intestazione = intestazione + "<tr>"
                intestazione = intestazione + "<td width=""32%"">Flow Meter Low</td>"
                intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                intestazione = intestazione + "</tr>"
            End If
        End If
        literal6.Text = intestazione
        'end creazione elenco messaggi generali o allarmi generali
    End Function
    'gestione timer status 
    Private Function crea_status_timer(ByVal str_input() As String) As String
        Dim intestazione As String = ""
        Dim timer_array() As String
        timer_array = main_function.timer_max5_1(str_input(0)).Split("|")
        If timer_array.Length > 4 Then
            intestazione = crea_codice_timer(timer_array, 1, "Timer")
        End If
        timer1.Text = intestazione
        timer_array = main_function.timer_max5_2(str_input(0)).Split("|")
        If timer_array.Length > 4 Then
            intestazione = crea_codice_timer(timer_array, 2, "Timer")
        End If
        timer2.Text = intestazione
        timer_array = main_function.timer_max5_3(str_input(1)).Split("|")
        If timer_array.Length > 4 Then
            intestazione = crea_codice_timer(timer_array, 3, "Timer")
        End If
        timer3.Text = intestazione
        timer_array = main_function.timer_max5_4(str_input(1)).Split("|")
        If timer_array.Length > 4 Then
            intestazione = crea_codice_timer(timer_array, 4, "Timer")
        End If
        timer4.Text = intestazione
        timer_array = main_function.timer_max5_5(str_input(1)).Split("|")
        If timer_array.Length > 4 Then
            intestazione = crea_codice_timer(timer_array, 5, "Timer")
        End If
        timer5.Text = intestazione
        'timer abilitato codice 







        'timer disabilitato codice 

    End Function
    Public Function crea_codice_timer(ByVal str_input() As String, ByVal numero_timer As Integer, ByVal timer_traduzione As String) As String
        Dim intestazione As String = ""
        Dim calcolo_minuti As Integer
        Dim ore As String
        Dim minuti As String
        Dim out As Integer
        Dim pulse As Integer
        intestazione = "<a class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        If (str_input(0) = "1") Then ' timer attivo
            calcolo_minuti = (Val((str_input(3))) * 60) + Val((str_input(4)))
            out = Val((str_input(1)))
            pulse = Val((str_input(2)))
            If calcolo_minuti <= 60 Then ' visualizzo solo minuti
                ore = ""
                minuti = Format((Val((str_input(4)))), "00") + " m"
            Else
                ore = Format((Val((str_input(3)))), "00") + " : "
                minuti = Format((Val((str_input(4)))), "00")
            End If
            intestazione = intestazione + "<div data-percent=""" + ((100 * calcolo_minuti) / 1440).ToString + """ class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + ore + minuti + "</span>"
            intestazione = intestazione + "<canvas width=""50"" height=""50""></canvas><canvas width=""50"" height=""50""></canvas></div>"
            If out > 6 Then 'uscita impulsiva
                intestazione = intestazione + "<span class=""txt"">" + timer_traduzione + " " + numero_timer.ToString + " - P" + (out - 6).ToString + " " + pulse.ToString + " Pm</span>"
            Else 'uscita digitale on/off
                intestazione = intestazione + "<span class=""txt"">" + timer_traduzione + " " + numero_timer.ToString + " - D" + (out).ToString + " ON</span>"
            End If
            intestazione = intestazione + "<div class=""clearfix""></div>"
            intestazione = intestazione + "</a>"
        Else 'timer inattivo
            intestazione = intestazione + "<div data-percent=""0"" class=""easy-pie danger easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">0</span>"
            intestazione = intestazione + "<canvas width=""50"" height=""50""></canvas><canvas width=""50"" height=""50""></canvas></div>"
            intestazione = intestazione + "<span class=""txt"">" + timer_traduzione + " " + numero_timer.ToString + " OFF</span>"
            intestazione = intestazione + "<div class=""clearfix""></div>"
            intestazione = intestazione + "</a>"
        End If
        Return intestazione
    End Function
    Private Function crea_canale(ByVal numero_canale As Integer, ByVal Channel_traduzione As String, ByVal label_canale As String, _
                                 ByVal value_canale As String, ByVal Allarmi_traduzione As String, ByVal Ingressi_traduzione As String, _
                                 ByVal Uscite_traduzione As String, ByVal info_canale As String, ByVal livello_canale As String, ByVal number_version As Integer, _
                                 ByVal nome_setpoint() As String) As String
        Dim intestazione As String = ""
        Dim numero_canale_temp As Integer = numero_canale - 1
        Dim prima_colonna() As String = {"", "", "", "", ""}
        Dim indice_prima_colonna As Integer = 0
        Dim seconda_colonna() As String = {"", "", "", "", ""}
        Dim indice_seconda_colonna As Integer = 0
        Dim terza_colonna() As String = {"", "", "", "", ""}
        Dim indice_terza_colonna As Integer = 0

        If numero_canale_temp Mod 3 = 0 Then
            intestazione = intestazione + "<div class=""row-fluid"">"
        End If
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<div class=""widget"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<h3 class=""heading"">" + Channel_traduzione + " " + numero_canale.ToString + "</h3><div style=""float:right;position:relative;top:-2px;""><span data-toggle=""tooltip"" data-original-title=""Cambia nome al canale"" data-placement=""bottom""><a href="""" class=""btn-action glyphicons pencil btn-success""><i></i></a></span></div></div>"
        intestazione = intestazione + "<div class=""widget-body"">"
        intestazione = intestazione + " <div class=""canale"">" + label_canale + "  " + value_canale + "</div>"
        intestazione = intestazione + "<table class=""table table-bordered table-condensed table-striped  table-vertical-center"">"
        intestazione = intestazione + "<thead>"
        intestazione = intestazione + "<tr>"
        intestazione = intestazione + "<th width=""33%"">" + Allarmi_traduzione + "</th>"
        intestazione = intestazione + "<th width=""34%"" class=""center"">" + Ingressi_traduzione + "</th>"
        intestazione = intestazione + "<th width=""33%"" class=""center"">" + Uscite_traduzione + "</th>"
        intestazione = intestazione + "</tr>"
        intestazione = intestazione + "</thead>"
        intestazione = intestazione + "<tbody>"
        'riga relavita agli ingressi uscite allarmi
        'For i = 1 To 5 ' massimo ci possono essere 5 righe
        ' allarmi di soglia Aa
        If number_version > 29 Then
            nome_setpoint(0) = nome_setpoint(0).Replace("ph", "")
            For j = 0 To nome_setpoint.Length - 1
                nome_setpoint(j) = nome_setpoint(j).Replace("-", "")
            Next
        End If
        'colonna relativa agli allarmi
        If main_function.alarm_max5_aa_str(livello_canale) = "1" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_aa_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_aa_str(livello_canale) = "0" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_aa_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_ab_str(livello_canale) = "1" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_ab_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_ab_str(livello_canale) = "0" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_ab_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_ad_str(livello_canale) = "1" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_ad_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_ad_str(livello_canale) = "0" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_ad_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_ar_str(livello_canale) = "1" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_ar_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If
        If main_function.alarm_max5_ar_str(livello_canale) = "0" Then
            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_ar_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_prima_colonna = indice_prima_colonna + 1
        End If

        'colonna relativa agli ingressi
        ' livello1
        If main_function.alarm_max5_levda_str(livello_canale) = "1" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levda_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levda_str(livello_canale) = "0" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levda_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levdb_str(livello_canale) = "1" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levdb_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levdb_str(livello_canale) = "0" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levdb_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levpa_str(livello_canale) = "1" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levpa_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levpa_str(livello_canale) = "0" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levpa_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levpb_str(livello_canale) = "1" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levpb_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levpb_str(livello_canale) = "0" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levpb_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levma_str(livello_canale) = "1" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levma_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If
        If main_function.alarm_max5_levma_str(livello_canale) = "0" Then
            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.alarm_max5_levma_name(nome_setpoint) + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
            indice_seconda_colonna = indice_seconda_colonna + 1
        End If

        'colonna relativa alle uscite
        ' uscite da -pa

        If main_function.out_max5_da_channel(info_canale) > 0 Then
            If main_function.out_max5_da_str(info_canale) = "1" Then 'uscita ON
                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.out_max5_da_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
            If main_function.out_max5_da_str(info_canale) = "0" Then 'uscita OFF
                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + main_function.out_max5_da_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
        End If
        If main_function.out_max5_db_channel(info_canale) > 0 Then
            If main_function.out_max5_db_str(info_canale) = "1" Then 'uscita ON
                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.out_max5_db_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
            If main_function.out_max5_db_str(info_canale) = "0" Then 'uscita OFF
                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + main_function.out_max5_db_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
        End If
        If main_function.out_max5_pa_channel(info_canale) > 0 Then
            If main_function.out_max5_pa_str(info_canale) > 0 Then 'uscita ON
                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.out_max5_pa_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + main_function.out_max5_pa_str(info_canale).ToString + " Pm" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            Else 'uscita OFF
                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + main_function.out_max5_pa_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
        End If
        If main_function.out_max5_pb_channel(info_canale) > 0 Then
            If main_function.out_max5_pb_str(info_canale) > 0 Then 'uscita ON
                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.out_max5_pb_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + main_function.out_max5_pb_str(info_canale).ToString + " Pm" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            Else 'uscita OFF
                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + main_function.out_max5_pb_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
        End If
        If main_function.out_max5_ma_channel(info_canale) > 0 Then
            If main_function.out_max5_ma_str(info_canale) > 0 Then 'uscita ON
                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + main_function.out_max5_ma_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + main_function.out_max5_ma_str(info_canale).ToString + " mA" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            Else 'uscita OFF
                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + main_function.out_max5_ma_name(nome_setpoint) + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                indice_terza_colonna = indice_terza_colonna + 1
            End If
        End If


        For i = 0 To 4
            If prima_colonna(i) <> "" Or seconda_colonna(i) <> "" Or terza_colonna(i) <> "" Then
                intestazione = intestazione + "<tr  style="""">"
                If prima_colonna(i) <> "" Then
                    intestazione = intestazione + prima_colonna(i)
                Else
                    intestazione = intestazione + "<td></td>"
                End If
                If seconda_colonna(i) <> "" Then
                    intestazione = intestazione + seconda_colonna(i)
                Else
                    intestazione = intestazione + "<td></td>"
                End If
                If terza_colonna(i) <> "" Then
                    intestazione = intestazione + terza_colonna(i)
                Else
                    intestazione = intestazione + "<td></td>"
                End If
                intestazione = intestazione + "</tr>"
            End If
        Next

        'intestazione = intestazione + "<tr>"
        'If main_function.alarm_max5_ab_str(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Aa + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_ab_str(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Aa + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' livello2
        'If main_function.alarm_max5_levdb(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level1 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_levdb(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level2 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' uscita Db
        'If main_function.out_max5_db_channel(info_canale) > 0 Then
        '    If main_function.out_max5_db_str(info_canale) = "1" Then 'uscita ON
        '       intestazione = intestazione+"<td width=""33%""  ><span style=""font-weight:bold;"">"+Pulse+"</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>"+ON+"</span></span></td>"
        '    End If
        '    If main_function.out_max5_db_str(info_canale) = "0" Then 'uscita OFF
        '        intestazione = intestazione + "<td width=""33%"" ><span style=""font-weight:bold;"">" + Pulse + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + OFF + "</span></span></td>"
        '    End If
        'End If
        'intestazione = intestazione + "</tr>"


        'intestazione = intestazione + "<tr>"
        'If main_function.alarm_max5_ad_str(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Aa + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_ad_str(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Aa + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' livello3
        'If main_function.alarm_max5_levpa(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level1 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_levpa(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level2 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' uscita Pa
        'If main_function.out_max5_pa_channel(info_canale) > 0 Then
        '    If main_function.out_max5_pa_str(info_canale) > 0 Then 'uscita ON
        '       intestazione = intestazione+"<td width=""33%""  ><span style=""font-weight:bold;"">"+Pulse+"</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>"+ON+"</span></span></td>"
        '    End If
        '    If main_function.out_max5_pa_str(info_canale) = 0 Then 'uscita OFF
        '        intestazione = intestazione + "<td width=""33%"" ><span style=""font-weight:bold;"">" + Pulse + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + OFF + "</span></span></td>"
        '    End If
        'End If

        ''riga relavita agli ingressi uscite allarmi
        'intestazione = intestazione + "</tr>"

        'intestazione = intestazione + "<tr>"
        'If main_function.alarm_max5_ar_str(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Aa + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_ar_str(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Aa + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' livello4
        'If main_function.alarm_max5_levpb(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level1 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_levpb(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level2 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' uscita Pb
        'If main_function.out_max5_pb_channel(info_canale) > 0 Then
        '    If main_function.out_max5_pb_str(info_canale) > 0 Then 'uscita ON
        '       intestazione = intestazione+"<td width=""33%""  ><span style=""font-weight:bold;"">"+Pulse+"</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>"+ON+"</span></span></td>"
        '    End If
        '    If main_function.out_max5_pb_str(info_canale) = 0 Then 'uscita OFF
        '        intestazione = intestazione + "<td width=""33%"" ><span style=""font-weight:bold;"">" + Pulse + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + OFF + "</span></span></td>"
        '    End If
        'End If

        ''riga relavita agli ingressi uscite allarmi
        'intestazione = intestazione + "</tr>"

        'intestazione = intestazione + "<tr>"

        '' livello5
        'If main_function.alarm_max5_levma(livello_canale) = "1" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level1 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
        'End If
        'If main_function.alarm_max5_levma(livello_canale) = "0" Then
        '    intestazione = intestazione + "<td width=""33%""  ><span style=""font-weight:bold;"">" + Level2 + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
        'End If
        '' uscita ma
        'If main_function.out_max5_ma_channel(info_canale) > 0 Then
        '    If main_function.out_max5_ma_str(info_canale) > 0 Then 'uscita ON
        '       intestazione = intestazione+"<td width=""33%""  ><span style=""font-weight:bold;"">"+Pulse+"</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>"+ON+"</span></span></td>"
        '    End If
        '    If main_function.out_max5_ma_str(info_canale) = 0 Then 'uscita OFF
        '        intestazione = intestazione + "<td width=""33%"" ><span style=""font-weight:bold;"">" + Pulse + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + OFF + "</span></span></td>"
        '    End If
        'End If

        'riga relavita agli ingressi uscite allarmi
        'intestazione = intestazione + "</tr>"

        intestazione = intestazione + "</tbody>"
        intestazione = intestazione + "</table>" '
        intestazione = intestazione + "</div>" 'chiusura widget-body
        intestazione = intestazione + "</div>" 'chiusura widget
        intestazione = intestazione + "</div>" 'chiusura span4
        If (numero_canale_temp + 1) Mod 3 = 0 Then
            intestazione = intestazione + "</div>" 'chiusura row-fluid
        End If
        Return intestazione
    End Function
End Class