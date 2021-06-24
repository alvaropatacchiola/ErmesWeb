Public Class main_ldtower
    Inherits lingua



    Private Sub main_ldtower_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
            posiziona_ldtower(nome_impianto, codice_impianto, id_485_impianto)
            'refresh_max5(nome_impianto, codice_impianto, id_485_impianto, "CODE", "Referente", statistica, "Statistiche", "Strumenti Attivi", "Allarmi", "SetPoint", "Temperature", "Log", "Log All")
        End If
    End Sub
    Public Sub posiziona_ldtower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim numero_canali As Integer = 0
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim intestazione As String = ""
        Dim contatore_canale As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim scala_temp As Integer = 0
        Dim measure_unit As String = ""
        Dim international_unit As String = ""
        Dim new_version As Boolean = False
        Dim LDTower_Type As String = ""
        Dim version_str As String = ""

        Dim unit_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim outputr_value() As String
        Dim tota1() As String
        Dim tota2() As String
        Dim clockr_value() As String
        Dim optio_value() As String
        Dim stbior_value() As String

        Dim personalizzazione_aquacare As Integer

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        unit_value = main_function.get_split_str(riga_strumento.value1)
        config_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)
        allrmr_value = main_function.get_split_str(riga_strumento.value3)
        outputr_value = main_function.get_split_str(riga_strumento.value10)
        clockr_value = main_function.get_split_str(riga_strumento.value5)
        tota1 = main_function.get_split_str(riga_strumento.value8)
        tota2 = main_function.get_split_str(riga_strumento.value9)
        optio_value = main_function.get_split_str(riga_strumento.value7)
        stbior_value = main_function.get_split_str(riga_strumento.value6)

        new_version = main_function_config.chek_ldtower_version(riga_strumento.nome, version_str)

        LDTower_Type = main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str)
        main_function_config.get_ldtower_unit(unit_value, international_unit, measure_unit)
        numero_canali = LDTower_Type.Split("_").Length


        For i = 1 To numero_canali 'LDTower può essere solo ad uno
            Select Case i
                Case 1 'controllo canale 1
                    main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str, fattore_divisione_temp,
                                                                  , , scala_temp, , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 3, 4)) / fattore_divisione_temp

                    'If scala_temp = 5000 Or scala_temp = 500 Then
                    '    valore_canale_temp = Val(Mid(valuer_value(0), 3, 4)) / fattore_divisione_temp
                    'Else
                    '    valore_canale_temp = (Val(Mid(valuer_value(0), 3, 4)) * 10) / fattore_divisione_temp
                    'End If
                    label_canale_temp = measure_unit
                    intestazione = intestazione + crea_canale_ldt(i, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), allrmr_value, _
                                                                       riga_strumento.tipo_strumento, outputr_value, GetGlobalResourceObject("tower_global", "bleed_timeout"), GetGlobalResourceObject("tower_global", "high_conductivity"), GetGlobalResourceObject("tower_global", "low_conductivity"), GetGlobalResourceObject("tower_global", "level_biocide"), GetGlobalResourceObject("tower_global", "level_inhibitor"), _
                                                                       GetGlobalResourceObject("tower_global", "inhibitordig"), GetGlobalResourceObject("tower_global", "inhibitorprop"), GetGlobalResourceObject("tower_global", "prebleed"), GetGlobalResourceObject("tower_global", "biocide"), GetGlobalResourceObject("tower_global", "lockout"), _
                                                                      GetGlobalResourceObject("ldtower_global", "startupdelay"), GetGlobalResourceObject("tower_global", "bleed"), GetGlobalResourceObject("ldtower_global", "alarm"), GetGlobalResourceObject("ldtower_global", "circulation"))


            End Select
        Next

        intestazione = intestazione + "</div>" 'chiusura row-fluid
        literal1.Text = intestazione
        crea_header(international_unit, clockr_value, tota1, tota2, GetGlobalResourceObject("ldtower_global", "water_meter_1"), GetGlobalResourceObject("ldtower_global", "water_meter_2"), stbior_value, LDTower_Type, GetGlobalResourceObject("tower_global", "status_biocide_day"), new_version, allrmr_value, GetGlobalResourceObject("ld_global", "flow"))
    End Sub
    Private Function crea_header(ByVal formato_data As String, ByVal clock_value() As String, ByVal tota1() As String, _
                             ByVal tota2() As String, ByVal water_meter_input_traduzione As String, ByVal water_meter_bleed_traduzione As String, _
                             ByVal biocide_stat() As String, ByVal tower_type As String, ByVal status_biocide_day_traduzione As String, ByVal new_version As Boolean, _
                             ByVal allrmr_value() As String, ByVal flow_traduzione As String) As String

        Dim ora As String
        Dim app_am As Integer
        Dim intestazione As String = ""
        Dim status_biocide As String = ""
        Dim day_biocide As String = ""
        'gestione data e ora
        If formato_data = "IS" Then
            ora = Mid(clock_value(0), 9, 2) + ":" + Mid(clock_value(0), 11, 2)
        Else

            If Val(Mid(clock_value(0), 13, 1)) Then
                ora = Mid(clock_value(0), 9, 2) + ":" + Mid(clock_value(0), 11, 2) + "  am"
            End If

            If Val(Mid(clock_value(0), 14, 1)) Then
                ora = Mid(clock_value(0), 9, 2) + ":" + Mid(clock_value(0), 11, 2) + "  pm"
            End If
        End If
        literal3.Text = "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + Mid(clock_value(0), 3, 2) + "</span> <span class=""label"">" + Mid(clock_value(0), 5, 2) + "</span> <span class=""label"">" + Mid(clock_value(0), 7, 2) + _
    "</span> <span class=""label"">" + ora + "</span></li>"
        ' gestione dei totalizzatori
        ' creazione widget flusso instantaneo/totalizzatore
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
        intestazione = intestazione + "<span>" + water_meter_input_traduzione + ":</span>"
        intestazione = intestazione + "<span><strong>" + Mid(tota1(0), 3, 10) + "</strong></span> L <br/>"
        intestazione = intestazione + "<span>" + water_meter_bleed_traduzione + ":</span>"
        intestazione = intestazione + "<span><strong>" + Mid(tota2(0), 3, 10) + "</strong></span> L <br/>"
        'intestazione = intestazione + "<span>" + water_meter_difference + ":</span>"
        'If Val(Mid(tota1(0), 3, 10)) >= Val(Mid(tota2(0), 3, 10)) Then
        '    intestazione = intestazione + "<span><strong>" + Str(Val(Mid(tota1(0), 3, 10)) - Val(Mid(tota2(0), 3, 10))) + "</strong></span> L <br/>"
        'Else
        '    If Val(Mid(tota2(0), 3, 10)) >= Val(Mid(tota1(0), 3, 10)) Then
        '        intestazione = intestazione + "<span><strong>" + Str(Val(Mid(tota2(0), 3, 10)) - Val(Mid(tota1(0), 3, 10))) + "</strong></span> L <br/>"
        '    End If
        'End If
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</a>"
        literal4.Text = intestazione
        ' end creazione widget flusso instantaneo/totalizzatore

        'status biocide week
        day_biocide = main_function.ldtower_week_day(biocide_stat, "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday")
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
        'intestazione = intestazione + "<span>" + status_biocide_week_traduzione + ":</span>"
        'intestazione = intestazione + "<span><strong>" + status_biocide + "</strong></span><br/>"
        intestazione = intestazione + "<span>" + status_biocide_day_traduzione + ":</span>"
        intestazione = intestazione + "<span><strong>" + day_biocide + "</strong></span><br/>"

        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</a>"
        literal2.Text = intestazione
        'end biocide week
        'coontrollo allarmi generali
        intestazione = "<tr style="""">"
        If main_function.alarm_ldtower_flow(allrmr_value) Then ' allarme di flusso
            intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
            intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
        Else
            intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
            intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
        End If
        intestazione = intestazione + "</tr>"

        literal6.Text = intestazione
        'end coontrollo allarmi generali
    End Function
    Private Function crea_canale_ldt(ByVal numero_canale As Integer, ByVal Channel_traduzione As String, ByVal label_canale As String, _
                                    ByVal value_canale As String, ByVal Allarmi_traduzione As String, ByVal Ingressi_traduzione As String, _
                                    ByVal Uscite_traduzione As String, ByVal alarm_canale() As String, ByVal tipo_strumento As String, _
                                    ByVal output_canale() As String, ByVal bleed_timeout_traduzione As String, ByVal high_conductivity_traduzione As String, _
                                    ByVal low_conductivity_traduzione As String, ByVal level_biocide_traduzione As String, ByVal level_inhibitor_traduzione As String, _
                                    ByVal inhibitor_dig_traduzione As String, ByVal inhibitor_prop_traduzione As String, ByVal pre_bleed_traduzione As String, _
                                    ByVal biocide_traduzione As String, ByVal LockOut_traduzione As String, ByVal startup_traduzione As String, _
                                    ByVal bleed_traduzione As String, ByVal alarm_traduzione As String, ByVal circulation_traduzione As String) As String
        Dim intestazione As String = ""
        Dim numero_canale_temp As Integer = numero_canale - 1
        Dim prima_colonna() As String = {"", "", "", "", "", "", "", "", "", "", "", "", ""}
        Dim indice_prima_colonna As Integer = 0
        Dim seconda_colonna() As String = {"", "", "", "", "", "", "", "", "", "", "", "", ""}
        Dim indice_seconda_colonna As Integer = 0
        Dim terza_colonna() As String = {"", "", "", "", "", "", "", "", "", "", "", "", ""}
        Dim indice_terza_colonna As Integer = 0

        If numero_canale_temp Mod 2 = 0 Then
            intestazione = intestazione + "<div class=""row-fluid"">"
        End If
        intestazione = intestazione + "<div class=""span6"">"
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
        Select Case numero_canale
            Case 1 ' canale 1 
                If main_function.alarm_ldtower_bleed_timeout(alarm_canale) Then
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + bleed_timeout_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                Else
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + bleed_timeout_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                End If
                If main_function.alarm_ldtower_high_conductivity(alarm_canale) Then
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + high_conductivity_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                Else
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + high_conductivity_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                End If
                If main_function.alarm_ldtower_low_conductivity(alarm_canale) Then
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + low_conductivity_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                Else
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + low_conductivity_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1

                End If

                'If main_function.alarm_tower_level_prebiocide1(alarm_canale) Then
                'seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_prebiocide_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                'indice_seconda_colonna = indice_seconda_colonna + 1
                'Else
                'seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_prebiocide_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                'indice_seconda_colonna = indice_seconda_colonna + 1
                'End If

                If main_function.alarm_ldtower_level_biocide1(alarm_canale) Then
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_biocide_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1
                Else
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_biocide_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1

                End If
                ' If main_function.alarm_tower_level_prebiocide2(alarm_canale) Then
                'seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_prebiocide_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                'indice_seconda_colonna = indice_seconda_colonna + 1
                'Else
                'seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_prebiocide_traduzione + " </span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                ' indice_seconda_colonna = indice_seconda_colonna + 1

                'End If
                If main_function.alarm_ldtower_level_biocide2(alarm_canale) Then
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_biocide_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1
                Else
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_biocide_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1

                End If
                If main_function.alarm_ldtower_level_inhibitor(alarm_canale) Then
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_inhibitor_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1
                Else
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + level_inhibitor_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1
                End If
                'output canale
                If (Val(Mid(output_canale(0), 3, 1))) Then  ' Inhibitor DIG
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + inhibitor_dig_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + inhibitor_dig_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If


                If (Val(Mid(output_canale(0), 4, 1))) Then  ' Inhibitor prop
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + inhibitor_prop_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + inhibitor_prop_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If


                If (Val(Mid(output_canale(0), 5, 1))) Then  ' PreBleed 1
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pre_bleed_traduzione + " 1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pre_bleed_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If


                If (Val(Mid(output_canale(0), 6, 1))) Then  ' Biocide 1
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + biocide_traduzione + " 1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + biocide_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 7, 1))) Then  ' LockOut 1
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + LockOut_traduzione + " 1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + LockOut_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 8, 1))) Then  ' PreBleed 2
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pre_bleed_traduzione + " 2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pre_bleed_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 9, 1))) Then  ' Biocide 2
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + biocide_traduzione + " 2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + biocide_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 10, 1))) Then  ' LockOut 2
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + LockOut_traduzione + " 2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i></span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + LockOut_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                'If (Val(Mid(output_canale(0), 13, 1))) Then  ' StartUp Delay
                '    GaugeContainer17.StateIndicators("delay").Image = "~/image/strumenti_grafica/ball_red.png"
                'Else
                '    GaugeContainer17.StateIndicators("delay").Image = "~/image/strumenti_grafica/ball_green.png"
                'End If

                If (Val(Mid(output_canale(0), 11, 1))) Then  ' Startup Delay
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + startup_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" title = ""ON""><i></i></span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + startup_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 12, 1))) Then  ' Bleed
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + bleed_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" title = ""ON""><i></i></span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + bleed_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 13, 1))) Then  ' Alarm
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + alarm_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" title = ""ON""><i></i></span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 14, 1))) Then  ' Circulation Pump 1
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + circulation_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" title = ""ON""><i></i></span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + circulation_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

                If (Val(Mid(output_canale(0), 15, 1))) Then  ' Circulation Pump 2
                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + circulation_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" title = ""ON""><i></i></span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + circulation_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/x.png"" alt=""OFF""> </span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If

        End Select

        For i = 0 To 12
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

        intestazione = intestazione + "</tbody>"
        intestazione = intestazione + "</table>" '
        intestazione = intestazione + "</div>" 'chiusura widget-body
        intestazione = intestazione + "</div>" 'chiusura widget
        intestazione = intestazione + "</div>" 'chiusura span4
        If (numero_canale_temp + 1) Mod 2 = 0 Then
            intestazione = intestazione + "</div>" 'chiusura row-fluid
        End If
        Return intestazione
    End Function
End Class