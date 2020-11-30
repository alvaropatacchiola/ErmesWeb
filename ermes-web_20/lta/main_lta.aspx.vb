Public Class main_lta
    Inherits lingua



    Private Sub main_lta_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
            posiziona_lta(nome_impianto, codice_impianto, id_485_impianto)
            'refresh_max5(nome_impianto, codice_impianto, id_485_impianto, "CODE", "Referente", statistica, "Statistiche", "Strumenti Attivi", "Allarmi", "SetPoint", "Temperature", "Log", "Log All")
        End If
    End Sub
    Public Sub posiziona_lta(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim numero_canali As Integer = 0
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim intestazione As String = ""
        Dim contatore_canale As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim formato_d As String

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim outputr_value() As String
        Dim clockr_value() As String


        Dim cicli_value() As String  ' Andrea Manetta 25-10-19


        Dim number_version As Integer = 0 ' Andrea Manetta 25-10-19



        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)
        allrmr_value = main_function.get_split_str(riga_strumento.value3)
        ' outputr_value = main_function.get_split_str(riga_strumento.value5)
        clockr_value = main_function.get_split_str(riga_strumento.value6)

        number_version = Val(main_function.get_version(riga_strumento.nome))
        If (number_version >= 218) Then
            cicli_value = main_function.get_split_str(riga_strumento.value22)
        End If









        Select Case riga_strumento.tipo_strumento
            Case "LTA"


                numero_canali = 2

            Case "LTU"


                numero_canali = 2

            Case "LTD"


                numero_canali = 2


        End Select

        


        For i = 1 To numero_canali 'ld può essere duo o tre canali
            contatore_canale = contatore_canale + 1
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            If i = 2 Then
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / 100
            Else
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            End If
            'If Mid(valuer_value(i + 4), 1, 1) = "0" Then


            intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), allrmr_value, _
                                              riga_strumento.tipo_strumento, outputr_value, GetGlobalResourceObject("ld_global", "range_alarm"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "level"), GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("ld_global", "relay"))





            ' End If

        Next
        intestazione = intestazione + "</div>" 'chiusura row-fluid
        literal1.Text = intestazione

        Select Case riga_strumento.tipo_strumento
            Case "LTA"
                formato_d = Mid(valuer_value(4), 1, 1)
            Case "LTU"
                formato_d = Mid(valuer_value(4), 1, 1)
            Case "LTD"
                formato_d = Mid(valuer_value(4), 1, 1)


        End Select
        '                                                                                                                                                                                   7                                       8                                                   9                                                             10                                                             11                                                                     12
        crea_header(formato_d, clockr_value, valuer_value, GetGlobalResourceObject("max5_global", "temperature"), allrmr_value, riga_strumento.tipo_strumento, GetGlobalResourceObject("ld_global", "flow"), GetGlobalResourceObject("ld_global", "Level_acid"), GetGlobalResourceObject("ld_global", "Level_cloro"), GetGlobalResourceObject("ld_global", "Flow_Control_Acid"), GetGlobalResourceObject("ld_global", "Flow_Control_Water"), GetGlobalResourceObject("ld_global", "Flow_Control_Cloro"), GetGlobalResourceObject("ld_global", "Level_Water"), GetGlobalResourceObject("ld_global", "Contact_SEFL_Acid"), GetGlobalResourceObject("ld_global", "Contact_SEFL_Chlorite"), GetGlobalResourceObject("ld_global", "Timeout "), GetGlobalResourceObject("ld_global", "Batch_Tank_Empty"), GetGlobalResourceObject("ld_global", "Flow_Water_Dlution"), GetGlobalResourceObject("ld_global", "Service_And_Calibration_Required"), GetGlobalResourceObject("ld_global", "Analog_Input"), GetGlobalResourceObject("ld_global", "Reactor_Leakage"), GetGlobalResourceObject("ld_global", "Pre_Dilution_Water"), GetGlobalResourceObject("ld_global", "Overflow"), GetGlobalResourceObject("ld_global", "CLO2_limit"), Val(main_function.get_version(riga_strumento.nome)), cicli_value, GetGlobalResourceObject("ld_global", "waiting"), GetGlobalResourceObject("ld_global", "Flow_M"), GetGlobalResourceObject("ld_global", "Acido_"), GetGlobalResourceObject("ld_global", "Chlorite_"), GetGlobalResourceObject("ld_global", "WMeter"))
    End Sub


    Private Function crea_canale(ByVal numero_canale As Integer, ByVal Channel_traduzione As String, ByVal label_canale As String, _
                             ByVal value_canale As String, ByVal Allarmi_traduzione As String, ByVal Ingressi_traduzione As String, _
                             ByVal Uscite_traduzione As String, ByVal alarm_canale() As String, ByVal tipo_strumento As String, _
                             ByVal output_canale() As String, ByVal feed_limit_traduzione As String, ByVal dos_alarm_traduzione As String, _
                             ByVal probe_fail_traduzione As String, ByVal livello_traduzione As String, ByVal pulse_traduzione As String, ByVal rele_traduzione As String) As String
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

        intestazione = intestazione + "<th width=""33%"">" + "" + "</th>"
        intestazione = intestazione + "<th width=""34%"" class=""center"">" + "" + "</th>"
        intestazione = intestazione + "<th width=""33%"" class=""center"">" + "" + "</th>"

        'intestazione = intestazione + "<th width=""33%"">" + Allarmi_traduzione + "</th>"
        'intestazione = intestazione + "<th width=""34%"" class=""center"">" + Ingressi_traduzione + "</th>"
        'intestazione = intestazione + "<th width=""33%"" class=""center"">" + Uscite_traduzione + "</th>"
        intestazione = intestazione + "</tr>"
        intestazione = intestazione + "</thead>"
        intestazione = intestazione + "<tbody>"
        Select Case tipo_strumento
            Case "LTA"
                Select Case numero_canale
                    'Case 1 ' canale 1 
                    '    If main_function.alarm_ld_feedlimit_ph(alarm_canale) Then '' feed limit ph
                    '        prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    '        indice_prima_colonna = indice_prima_colonna + 1
                    '    Else
                    '        prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    '        indice_prima_colonna = indice_prima_colonna + 1
                    '    End If
                    '    If main_function.alarm_ld_dosalarm_ph(alarm_canale) Then '' dos alarm ph
                    '        prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    '        indice_prima_colonna = indice_prima_colonna + 1
                    '    Else
                    '        prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    '        indice_prima_colonna = indice_prima_colonna + 1
                    '    End If
                    '    If main_function.alarm_ld_probefail_ph(alarm_canale) Then '' probe fail ph
                    '        prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    '        indice_prima_colonna = indice_prima_colonna + 1
                    '    Else
                    '        prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    '        indice_prima_colonna = indice_prima_colonna + 1
                    '    End If

                    '    If main_function.alarm_ld_livello1_ph(alarm_canale) Then '' level 1 ph
                    '        seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    '        indice_seconda_colonna = indice_seconda_colonna + 1
                    '    Else
                    '        seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    '        indice_seconda_colonna = indice_seconda_colonna + 1
                    '    End If
                    '    If main_function.alarm_ld_livello2_ph(alarm_canale) Then '' level 2 ph
                    '        seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    '        indice_seconda_colonna = indice_seconda_colonna + 1
                    '    Else
                    '        seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    '        indice_seconda_colonna = indice_seconda_colonna + 1
                    '    End If

                    '    Select Case Mid(output_canale(1), 1, 1) 'ph pulse 1
                    '        Case "2" ' off
                    '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '            indice_terza_colonna = indice_terza_colonna + 1
                    '        Case "0" ' on/off
                    '            If Mid(output_canale(6), 1, 3) = "001" Then ' on 
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            Else
                    '                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                    '                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '                    indice_terza_colonna = indice_terza_colonna + 1
                    '                End If
                    '            End If
                    '        Case "1" ' proportional
                    '            If Mid(output_canale(6), 1, 3) = "000" Then ' off
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            Else
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            End If

                    '    End Select
                    '    Select Case Mid(output_canale(2), 1, 1) 'ph pulse 2
                    '        Case "2" ' off
                    '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '            indice_terza_colonna = indice_terza_colonna + 1
                    '        Case "0" ' on/off
                    '            If Mid(output_canale(7), 1, 3) = "001" Then ' on 
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            Else
                    '                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                    '                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '                    indice_terza_colonna = indice_terza_colonna + 1
                    '                End If
                    '            End If
                    '        Case "1" ' proportional
                    '            If Mid(output_canale(7), 1, 3) = "000" Then ' off
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            Else
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            End If

                    '    End Select
                    '    If Mid(output_canale(4), 1, 1) <> "3" Then ' ph releya
                    '        If Mid(output_canale(9), 1, 1) = "1" Then
                    '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                    '            indice_terza_colonna = indice_terza_colonna + 1
                    '        Else
                    '            If Mid(output_canale(9), 1, 1) = "2" Then
                    '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '                indice_terza_colonna = indice_terza_colonna + 1
                    '            End If
                    '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '            indice_terza_colonna = indice_terza_colonna + 1
                    '        End If

                    '    Else
                    '        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    '        indice_terza_colonna = indice_terza_colonna + 1
                    '    End If

                    Case 2 ' canale 2
                        'If main_function.alarm_ld_feedlimit_cl(alarm_canale) Then '' feed limit cl
                        '    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                        '    indice_prima_colonna = indice_prima_colonna + 1
                        'Else
                        '    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                        '    indice_prima_colonna = indice_prima_colonna + 1
                        'End If
                        'If main_function.alarm_ld_dosalarm_cl(alarm_canale) Then '' dos alarm cl
                        '    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                        '    indice_prima_colonna = indice_prima_colonna + 1
                        'Else
                        '    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                        '    indice_prima_colonna = indice_prima_colonna + 1
                        'End If
                        'If main_function.alarm_ld_probefail_cl(alarm_canale) Then '' probe fail cl
                        '    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                        '    indice_prima_colonna = indice_prima_colonna + 1
                        'Else
                        '    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                        '    indice_prima_colonna = indice_prima_colonna + 1
                        'End If
                        'If main_function.alarm_ld_livello1_cl(alarm_canale) Then '' level 2 ph
                        '    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                        '    indice_seconda_colonna = indice_seconda_colonna + 1
                        'Else
                        '    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + " 1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                        '    indice_seconda_colonna = indice_seconda_colonna + 1
                        'End If

                        'Select Case Mid(output_canale(3), 1, 1) 'cl pulse 1
                        '    Case "2" ' off
                        '        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '        indice_terza_colonna = indice_terza_colonna + 1
                        '    Case "0" ' on/off
                        '        If Mid(output_canale(8), 1, 3) = "001" Then ' on 
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        Else
                        '            If Mid(output_canale(8), 1, 3) = "000" Then ' off
                        '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '                indice_terza_colonna = indice_terza_colonna + 1
                        '            End If
                        '        End If
                        '    Case "1" ' proportional
                        '        If Mid(output_canale(8), 1, 3) = "000" Then ' off
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        Else
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        End If

                        'End Select

                        'If Mid(output_canale(5), 1, 1) <> "3" Then ' cl releya
                        '    If Mid(output_canale(10), 1, 1) = "1" Then
                        '        terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '        indice_terza_colonna = indice_terza_colonna + 1
                        '    Else
                        '        If Mid(output_canale(10), 1, 1) = "2" Then
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        End If
                        '        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '        indice_terza_colonna = indice_terza_colonna + 1
                        '    End If

                        'Else
                        '    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '    indice_terza_colonna = indice_terza_colonna + 1
                        'End If

                    Case 3 ' canale 3
                End Select


        End Select

        For i = 0 To 2
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
        If (numero_canale_temp + 1) Mod 3 = 0 Then
            intestazione = intestazione + "</div>" 'chiusura row-fluid
        End If
        Return intestazione

    End Function
    Private Function crea_header(ByVal formato_data As String, ByVal clock_value() As String, ByVal valuer_value() As String, ByVal temperatura_traduzione As String,
                                 ByVal alarm_value() As String, ByVal tipo_strumento As String, ByVal flow_traduzione As String, ByVal Level_acid_traduzione As String,
                                 ByVal Level_cloro_traduzione As String, ByVal Flow_Control_Acid_traduzione As String, ByVal Flow_Control_Water_traduzione As String,
                                 ByVal Flow_Control_Cloro_traduzione As String, ByVal Level_Water_traduzione As String, ByVal Contact_SEFL_Acid_traduzione As String,
                                 ByVal Contact_SEFL_Chlorite_traduzione As String, ByVal Timeout_traduzione As String, ByVal Batch_Tank_Empty_traduzione As String,
                                 ByVal Flow_Water_Dlution_traduzione As String, ByVal Service_And_Calibration_Required_traduzione As String, ByVal Analog_Input_traduzione As String,
                                 ByVal Reactor_Leakage_traduzione As String, ByVal Pre_Dilution_Water_traduzione As String, ByVal Overflow_traduzione As String, ByVal ClO2_traduzione As String, ByVal versione As Integer, ByVal cicli_value() As String, ByVal Waiting_traduzione As String,
                                 ByVal FLOW_M_traduzione As String, ByVal Acido_traduzione As String, ByVal Cloro_traduzione As String, ByVal WMeter_traduzione As String) As String




        Dim ora As String
        Dim app_am As Integer
        Dim intestazione As String = ""
        Dim temperature_value As Single = 0






        'creazione widget data ora
        ora = Mid(clock_value(4), 1, 2) + ":" + Mid(clock_value(5), 1, 2)
        If formato_data = "2" Then ' americano
            app_am = Val(Mid(clock_value(6), 1, 1))

            If app_am = 1 Then
                ora = ora + " am"
            Else
                app_am = Val(Mid(clock_value(7), 1, 1))
                If app_am = 1 Then
                    ora = ora + " pm"

                End If
            End If

        End If
        literal3.Text = "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + Mid(clock_value(1), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(2), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(3), 1, 2) +
            "</span> <span class=""label"">" + ora + "</span></li>"
        'end creazione data ora
        'creazione widget temperatura
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        If formato_data = "0" Then ' europeo
            Select Case tipo_strumento
                Case "LTA"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LTU"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LTD"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)

            End Select

            'intestazione = intestazione + "<div data-percent=""" + temperature_value.ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + temperature_value.ToString + "</span>°<canvas width=""50"" height=""50""></canvas></div>"
            'intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °C</span>"
        End If

        If formato_data = "3" Then ' italiano
            Select Case tipo_strumento
                Case "LTA"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LTU"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LTD"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)

            End Select

            'intestazione = intestazione + "<div data-percent=""" + temperature_value.ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + temperature_value.ToString + "</span>°<canvas width=""50"" height=""50""></canvas></div>"
            'intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °C</span>"
        End If

        If formato_data = "1" Then ' tedesco
            Select Case tipo_strumento
                Case "LTA"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LTU"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LTD"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)

            End Select

            'intestazione = intestazione + "<div data-percent=""" + temperature_value.ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + temperature_value.ToString + "</span>°<canvas width=""50"" height=""50""></canvas></div>"
            'intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °C</span>"

        End If

        If formato_data = "2" Then ' americano
            Select Case tipo_strumento
                Case "LTA"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
                Case "LTU"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
                Case "LTD"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)))


            End Select
            'intestazione = intestazione + "<div data-percent=""" + ((temperature_value - 32) / 1.8).ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + temperature_value.ToString + "</span>°<canvas width=""50"" height=""50""></canvas></div>"
            'intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °F</span>"
        End If
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "</a>"
        literal2.Text = intestazione

        ' end creazione widget temperatura



        ' creazione widget flusso instantaneo/totalizzatore
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
        'intestazione = intestazione + "<span>Flow Meter:</span>"

        intestazione = intestazione + "<span>" + FLOW_M_traduzione + "</span>"



        'ByVal FLOW_M_traduzione As String, ByVal Acido_traduzione As String, ByVal Cloro_traduzione As String) As String


        Dim m3h_valore As Single = 0
        'm3h_valore = Val(valuer_value(5)) * 10

        'intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> m3/h <br/>"
        intestazione = intestazione + "<span><strong>" + valuer_value(5) + "</strong></span> m3/h <br/>"
        intestazione = intestazione + "<span> </span>"
        'intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> [g/h] <br/>"

        Dim app_str As String
        app_str = Mid(valuer_value(6), 1, 1)

        If app_str = "1" Then 'costante 
            intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> [g/h] <br/>"
        End If
        'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"



        ' TEST MIO
        ' Andrea Manetta 25-10-19
        If (versione >= 218) Then
            ' creazione widget flusso instantaneo/totalizzatore
            '  intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
            '  intestazione = intestazione + "<div style=""margin-top: 10px;margin-left: 20px;"">"


            'intestazione = intestazione + "<span>Acid:</span>" + cicli_value(1) + "</strong></span> [ltr] <br/>"
            'intestazione = intestazione + "<span>Chlorite:</span>" + cicli_value(2) + "</strong></span> [ltr] <br/>"
            'intestazione = intestazione + "<span>Water Meter:</span>" + cicli_value(3) + "</strong></span> [cbm] <br/>"


            intestazione = intestazione + "<span>" + Acido_traduzione + "</span>" + cicli_value(1) + "</strong></span> [ltr] <br/>"
            intestazione = intestazione + "<span>" + Cloro_traduzione + "</span>" + cicli_value(2) + "</strong></span> [ltr] <br/>"
            intestazione = intestazione + "<span>" + WMeter_traduzione + "</span>" + cicli_value(3) + "</strong></span> [cbm] <br/>"


        End If



        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</a>"
        literal4.Text = intestazione




        '' creazione widget flusso instantaneo/totalizzatore
        'intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        'intestazione = intestazione + "<div style=""margin-top: +10px;margin-left: 20px;"">"
        'intestazione = intestazione + "<span>Flow Meter:</span>"
        'Dim m3h_valoreB As Single = 0
        ''m3h_valore = Val(valuer_value(5)) * 10

        ''intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> m3/h <br/>"
        'intestazione = intestazione + "<span><strong>" + valuer_value(5) + "</strong></span> m4/m <br/>"
        'intestazione = intestazione + "<span> </span>"
        ''intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> [g/h] <br/>"

        'Dim app_strB As String
        'app_strB = Mid(valuer_value(6), 1, 1)

        'If app_strB = "1" Then 'costante 
        '    intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> [g/l] <br/>"
        'End If
        ''intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        ''intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        'intestazione = intestazione + "</div>"
        'intestazione = intestazione + "</a>"
        'literal4.Text = intestazione



        ' number_version = Val(main_function.get_version(riga_strumento.nome)) ' Andrea Manetta 25-10-19


        ' creazione widget flusso instantaneo/totalizzatore
        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
        intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
        intestazione = intestazione + "<span>Flow Meter:</span>"

        'm3h_valore = Val(valuer_value(5)) * 10

        ''intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> m3/h <br/>"
        'intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> [g/h] <br/>"
        'intestazione = intestazione + "<span>[g/h]:</span>"
        '' intestazione = intestazione + "<span><strong>" + valuer_value(8) + "</strong></span> WMI <br/>"

        ''intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        ''intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        'intestazione = intestazione + "</div>"
        'intestazione = intestazione + "</a>"
        'literal4.Text = intestazione





        'm3h_valore = Val(valuer_value(5)) * 10

        ''intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> m3/h <br/>"
        'intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> [g/h] <br/>"
        'intestazione = intestazione + "<span>[g/h]:</span>"
        '' intestazione = intestazione + "<span><strong>" + valuer_value(8) + "</strong></span> WMI <br/>"

        ''intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        ''intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
        'intestazione = intestazione + "</div>"
        'intestazione = intestazione + "</a>"
        'literal4.Text = intestazione


        '  creazione elenco messaggi generali o allarmi generali




        '  creazione elenco messaggi generali o allarmi generali
        intestazione = "<tr style="""">"




        Select Case tipo_strumento
            Case "LTA"






                If main_function.alarm_lta_lev_acido(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Level_acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Level_acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_cloro(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Level_cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Level_cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If ((main_function.alarm_lta_sefl_water(alarm_value)) Or (main_function.alarm_lta_sefl_water2(alarm_value))) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_flow_acid(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"


                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_flow_cloro(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_switch(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Reactor_Leakage_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Reactor_Leakage_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_oveflow(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Overflow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Overflow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"



                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_dioxide(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + ClO2_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + ClO2_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_bypass(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Pre_Dilution_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Pre_Dilution_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_alflow(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If


                intestazione = intestazione + "</tr>"

                If (versione >= 152 And versione < 205) Or versione >= 205 Then

                    intestazione = intestazione + "<tr>"
                    If main_function.alarm_lta_soglia(alarm_value) Then
                        intestazione = intestazione + "<td width=""32%"">" + "Min/Max" + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                    Else
                        intestazione = intestazione + "<td width=""32%"">" + "Min/Max" + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                    End If
                    intestazione = intestazione + "</tr>"

                    intestazione = intestazione + "<tr>"
                    If main_function.alarm_lta_generico(alarm_value) Then
                        intestazione = intestazione + "<td width=""32%"">" + Waiting_traduzione + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                    Else
                        intestazione = intestazione + "<td width=""32%"">" + Waiting_traduzione + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                    End If
                    intestazione = intestazione + "</tr>"
                End If
            Case "LTU"



                If main_function.alarm_lta_lev_acido(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Level_acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Level_acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_cloro(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Level_cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Level_cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If ((main_function.alarm_lta_sefl_water(alarm_value)) Or (main_function.alarm_lta_sefl_water2(alarm_value))) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_flow_acid(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"


                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_flow_cloro(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_switch(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Reactor_Leakage_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Reactor_Leakage_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_oveflow(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Overflow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Overflow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"



                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_dioxide(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + ClO2_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + ClO2_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_bypass(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Pre_Dilution_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Pre_Dilution_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_alflow(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If


                intestazione = intestazione + "</tr>"


                If (versione >= 152 And versione < 205) Or versione >= 205 Then

                    intestazione = intestazione + "<tr>"
                    If main_function.alarm_lta_soglia(alarm_value) Then
                        intestazione = intestazione + "<td width=""32%"">" + "Min/Max" + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                    Else
                        intestazione = intestazione + "<td width=""32%"">" + "Min/Max" + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                    End If
                    intestazione = intestazione + "</tr>"

                    intestazione = intestazione + "<tr>"
                    If main_function.alarm_lta_generico(alarm_value) Then
                        intestazione = intestazione + "<td width=""32%"">" + Waiting_traduzione + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                    Else
                        intestazione = intestazione + "<td width=""32%"">" + Waiting_traduzione + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                    End If
                    intestazione = intestazione + "</tr>"
                End If



            Case "LTD"



                If main_function.alarm_lta_lev_acido(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Level_acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Level_acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_cloro(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Level_cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Level_cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If ((main_function.alarm_lta_sefl_water(alarm_value)) Or (main_function.alarm_lta_sefl_water2(alarm_value))) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_flow_acid(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Acid_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"


                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_flow_cloro(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Flow_Control_Cloro_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_switch(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Reactor_Leakage_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Reactor_Leakage_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_lev_oveflow(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Overflow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Overflow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                intestazione = intestazione + "</tr>"



                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_dioxide(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + ClO2_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + ClO2_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_bypass(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + Pre_Dilution_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + Pre_Dilution_Water_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If
                intestazione = intestazione + "</tr>"

                intestazione = intestazione + "<tr>"
                If main_function.alarm_lta_alflow(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                End If


                intestazione = intestazione + "</tr>"

                If (versione >= 152 And versione < 205) Or versione >= 205 Then

                    intestazione = intestazione + "<tr>"
                    If main_function.alarm_lta_soglia(alarm_value) Then
                        intestazione = intestazione + "<td width=""32%"">" + "Min/Max" + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                    Else
                        intestazione = intestazione + "<td width=""32%"">" + "Min/Max" + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                    End If
                    intestazione = intestazione + "</tr>"

                    intestazione = intestazione + "<tr>"
                    If main_function.alarm_lta_generico(alarm_value) Then
                        intestazione = intestazione + "<td width=""32%"">" + Waiting_traduzione + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                    Else
                        intestazione = intestazione + "<td width=""32%"">" + Waiting_traduzione + "</td>"
                        intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"

                    End If
                    intestazione = intestazione + "</tr>"
                End If
        End Select

        literal6.Text = intestazione
        'end creazione elenco messaggi generali o allarmi generali

    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class