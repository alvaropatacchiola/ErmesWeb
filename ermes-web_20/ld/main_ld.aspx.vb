Public Class main_ld
    Inherits lingua

  

    Private Sub main_ld_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
            posiziona_ld_lds(nome_impianto, codice_impianto, id_485_impianto)
            'refresh_max5(nome_impianto, codice_impianto, id_485_impianto, "CODE", "Referente", statistica, "Statistiche", "Strumenti Attivi", "Allarmi", "SetPoint", "Temperature", "Log", "Log All")
        End If
    End Sub
    Public Sub posiziona_ld_lds(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
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

        Dim nome_strumento() As String
        Dim nome_strumentoB As String
        Dim numero_strumento As Integer = 0

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
        outputr_value = main_function.get_split_str(riga_strumento.value5)
        clockr_value = main_function.get_split_str(riga_strumento.value6)
        nome_strumento = main_function.get_split_str(riga_strumento.nome)

        Select Case riga_strumento.tipo_strumento
            Case "LD"
                If config_value.Length > 5 Then
                    numero_canali = 4
                Else
                    If Mid(config_value(3), 3, 3) <> "306" Then ' terzo canale esistente
                        numero_canali = 3
                    Else
                        numero_canali = 2
                    End If
                End If
                If InStr(nome_strumento(2), "LDDT") <> 0 Then
                    numero_canali = 2
                    numero_strumento = 1
                End If


            Case "LDS"
                numero_canali = 1

            Case "LD4"
                numero_canali = 4
            Case "LDDT"

                numero_canali = 2

        End Select
        Dim versione As Integer = Val(main_function.get_version(riga_strumento.nome))

        For i = 1 To numero_canali 'ld può essere duo o tre canali
            contatore_canale = contatore_canale + 1
            If calibrz_value(i).Length > 2 Then
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(i), fattore_divisione_temp)
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(i), fattore_divisione_temp)
            End If

            If i = 3 Then
                valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
            Else
                If i = 4 Then
                    valore_canale_temp = Val(Mid(valuer_value(6), 1, 4)) / fattore_divisione_temp
                Else
                    valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
                End If
            End If
            intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), allrmr_value,
                                                      riga_strumento.tipo_strumento, outputr_value, GetGlobalResourceObject("ld_global", "range_alarm"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "level"), GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("ld_global", "relay"),
                                                      riga_strumento.nome, versione)

        Next
        intestazione = intestazione + "</div>" 'chiusura row-fluid
        literal1.Text = intestazione

        Select riga_strumento.tipo_strumento
            Case "LD"
                formato_d = Mid(valuer_value(4), 1, 1)
            Case "LDDT"
                formato_d = Mid(valuer_value(4), 1, 1)

            Case "LDS"
                formato_d = Mid(valuer_value(3), 1, 1)
            Case "LD4"
                formato_d = Mid(valuer_value(6), 1, 1)

        End Select




        crea_header(formato_d, clockr_value, valuer_value, GetGlobalResourceObject("max5_global", "temperature"), allrmr_value, riga_strumento.tipo_strumento, GetGlobalResourceObject("ld_global", "flow"), versione, numero_strumento)
    End Sub
    Private Function crea_canale(ByVal numero_canale As Integer, ByVal Channel_traduzione As String, ByVal label_canale As String,
                             ByVal value_canale As String, ByVal Allarmi_traduzione As String, ByVal Ingressi_traduzione As String,
                             ByVal Uscite_traduzione As String, ByVal alarm_canale() As String, ByVal tipo_strumento As String,
                             ByVal output_canale() As String, ByVal feed_limit_traduzione As String, ByVal dos_alarm_traduzione As String,
                             ByVal probe_fail_traduzione As String, ByVal livello_traduzione As String, ByVal pulse_traduzione As String, ByVal rele_traduzione As String,
                                 ByVal nomeStrumento As String, ByVal versione As Integer) As String
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
        Select Case tipo_strumento
            Case "LD"
                Select Case numero_canale
                    Case 1 ' canale 1 
                        If main_function.alarm_ld_feedlimit_ph(alarm_canale) Then '' feed limit ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld_dosalarm_ph(alarm_canale) Then '' dos alarm ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld_probefail_ph(alarm_canale) Then '' probe fail ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If

                        If main_function.alarm_ld_livello1_ph(alarm_canale) Then '' level 1 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If
                        If main_function.alarm_ld_livello2_ph(alarm_canale) Then '' level 2 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If

                        Select Case Mid(output_canale(1), 1, 1) 'ph pulse 1
                            Case "2" ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Case "0" ' on/off
                                If Mid(output_canale(6), 1, 3) = "001" Then ' on 
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                        indice_terza_colonna = indice_terza_colonna + 1
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "3" ' proportional+wm
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "4" ' PID
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "5" ' LINE
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                        End Select
                        Select Case Mid(output_canale(2), 1, 1) 'ph pulse 2
                            Case "2" ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Case "0" ' on/off
                                If Mid(output_canale(7), 1, 3) = "001" Then ' on 
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                        indice_terza_colonna = indice_terza_colonna + 1
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "3" ' proportional+wm
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                            Case "4" ' PID
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                            Case "5" ' LINE
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If


                        End Select
                        If Mid(output_canale(4), 1, 1) <> "3" Then ' ph relay
                            If Mid(output_canale(9), 1, 1) = "1" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                If Mid(output_canale(9), 1, 1) = "2" Then
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If

                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                    Case 2 ' canale 2
                        If main_function.alarm_ld_feedlimit_cl(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld_dosalarm_cl(alarm_canale) Then '' dos alarm cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld_probefail_cl(alarm_canale) Then '' probe fail cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld_livello1_cl(alarm_canale) Then '' level 2 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If

                        Select Case Mid(output_canale(3), 1, 1) 'cl pulse 1
                            Case "2" ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Case "0" ' on/off
                                If Mid(output_canale(8), 1, 3) = "001" Then ' on 
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                        indice_terza_colonna = indice_terza_colonna + 1
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "3" ' proportional+wm
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "4" ' PID
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                            Case "5" ' LINE
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If


                        End Select

                        If Mid(output_canale(5), 1, 1) <> "3" Then ' cl releya
                            If Mid(output_canale(10), 1, 1) = "1" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                If Mid(output_canale(10), 1, 1) = "2" Then
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If

                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                    Case 3 ' canale 3
                        If main_function.alarm_ld_minmax_3(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If

                    Case 4 ' canale 4

                        If main_function.alarm_ld_minmax_4(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                End Select


            Case "LDDT"
                Select Case numero_canale
                    Case 1 ' canale 1 
                        If main_function.alarm_lddt_feedlimit_ph(alarm_canale) Then '' feed limit ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_lddt_dosalarm_ph(alarm_canale) Then '' dos alarm ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_lddt_probefail_ph(alarm_canale) Then '' probe fail ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If

                        If main_function.alarm_lddt_livello1_ph(alarm_canale) Then '' level 1 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If
                        If main_function.alarm_lddt_livello2_ph(alarm_canale) Then '' level 2 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If

                        Select Case Mid(output_canale(1), 1, 1) 'ph pulse 1
                            Case "2" ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Case "0" ' on/off
                                If Mid(output_canale(6), 1, 3) = "001" Then ' on 
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                        indice_terza_colonna = indice_terza_colonna + 1
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                        End Select
                        Select Case Mid(output_canale(2), 1, 1) 'ph pulse 2
                            Case "2" ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Case "0" ' on/off
                                If Mid(output_canale(7), 1, 3) = "001" Then ' on 
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                        indice_terza_colonna = indice_terza_colonna + 1
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                        End Select
                        If Mid(output_canale(4), 1, 1) <> "3" Then ' ph releya
                            If Mid(output_canale(9), 1, 1) = "1" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                If Mid(output_canale(9), 1, 1) = "2" Then
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If

                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                    Case 2 ' canale 2
                        If main_function.alarm_lddt_feedlimit_cl(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_lddt_dosalarm_cl(alarm_canale) Then '' dos alarm cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_lddt_probefail_cl(alarm_canale) Then '' probe fail cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_lddt_livello1_cl(alarm_canale) Then '' level 2 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If

                        Select Case Mid(output_canale(3), 1, 1) 'cl pulse 1
                            Case "2" ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Case "0" ' on/off
                                If Mid(output_canale(8), 1, 3) = "001" Then ' on 
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                        indice_terza_colonna = indice_terza_colonna + 1
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If

                        End Select

                        If Mid(output_canale(5), 1, 1) <> "3" Then ' cl releya
                            If Mid(output_canale(10), 1, 1) = "1" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                If Mid(output_canale(10), 1, 1) = "2" Then
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If

                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                    Case 3 ' canale 3
                End Select

            Case "LD4"
                Select Case numero_canale
                    Case 1 ' canale 1 
                        If main_function.alarm_ld4_feedlimit_ph(alarm_canale) Then '' feed limit ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld4_dosalarm_ph(alarm_canale) Then '' dos alarm ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld4_probefail_ph(alarm_canale) Then '' probe fail ph
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If

                        If main_function.alarm_ld4_livello_ph(alarm_canale) Then '' level 1 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If
                        'If main_function.alarm_ld_livello2_ph(alarm_canale) Then '' level 2 ph
                        '    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                        '    indice_seconda_colonna = indice_seconda_colonna + 1
                        'Else
                        '    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + " 2</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                        '    indice_seconda_colonna = indice_seconda_colonna + 1
                        'End If

                        'Select Case Mid(output_canale(1), 1, 1) 'ph pulse 1
                        '    Case "2" ' off
                        '        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '        indice_terza_colonna = indice_terza_colonna + 1
                        '    Case "0" ' on/off
                        '        If Mid(output_canale(6), 1, 3) = "001" Then ' on 
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        Else
                        '            If Mid(output_canale(6), 1, 3) = "000" Then ' off
                        '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '                indice_terza_colonna = indice_terza_colonna + 1
                        '            End If
                        '        End If
                        '    Case "1" ' proportional
                        '        If Mid(output_canale(6), 1, 3) = "000" Then ' off
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        Else
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        End If

                        'End Select
                        'Select Case Mid(output_canale(2), 1, 1) 'ph pulse 2
                        '    Case "2" ' off
                        '        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '        indice_terza_colonna = indice_terza_colonna + 1
                        '    Case "0" ' on/off
                        '        If Mid(output_canale(7), 1, 3) = "001" Then ' on 
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        Else
                        '            If Mid(output_canale(7), 1, 3) = "000" Then ' off
                        '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "2</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '                indice_terza_colonna = indice_terza_colonna + 1
                        '            End If
                        '        End If
                        '    Case "1" ' proportional
                        '        If Mid(output_canale(7), 1, 3) = "000" Then ' off
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        Else
                        '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                        '            indice_terza_colonna = indice_terza_colonna + 1
                        '        End If

                        'End Select
                        If Mid(output_canale(4), 1, 1) <> "3" Then ' ph releya
                            If Mid(output_canale(9), 1, 1) = "1" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                If Mid(output_canale(9), 1, 1) = "2" Then
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                            End If

                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                    Case 2 ' canale 2
                        If main_function.alarm_ld4_feedlimit_cl(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld4_dosalarm_cl(alarm_canale) Then '' dos alarm cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld4_probefail_cl(alarm_canale) Then '' probe fail cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If
                        If main_function.alarm_ld4_livello_cl(alarm_canale) Then '' level 2 ph
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        Else
                            seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_seconda_colonna = indice_seconda_colonna + 1
                        End If

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

                        If Mid(output_canale(5), 1, 1) <> "3" Then ' cl releya
                            If Mid(output_canale(10), 1, 1) = "1" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                If Mid(output_canale(10), 1, 1) = "2" Then
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                Else
                                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                    indice_terza_colonna = indice_terza_colonna + 1
                                End If
                            End If

                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                    Case 3 ' canale 3
                        If main_function.alarm_ld4_feedlimit_mV(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If

                    Case 4 ' canale 
                        If main_function.alarm_ld4_feedlimit_ntu(alarm_canale) Then '' feed limit cl
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        Else
                            prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                            indice_prima_colonna = indice_prima_colonna + 1
                        End If

                End Select

            Case "LDS" 'caso ld singolo
                If main_function.alarm_lds_feedlimit(alarm_canale) Then '' feed limit 
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                Else
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + feed_limit_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                End If
                If main_function.alarm_lds_dosalarm(alarm_canale) Then '' dos alarm 
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                Else
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + dos_alarm_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                End If
                If main_function.alarm_lds_probefail(alarm_canale) Then '' probe fail 
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                Else
                    prima_colonna(indice_prima_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + probe_fail_traduzione + "</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_prima_colonna = indice_prima_colonna + 1
                End If

                If main_function.alarm_lds_livello(alarm_canale) Then '' level 1 
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1
                Else
                    seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "1</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                    indice_seconda_colonna = indice_seconda_colonna + 1
                End If
                If Val(main_function.get_version(nomeStrumento)) >= 420 Then 'plus
                    If main_function.alarm_lds_level2(alarm_canale) Then '' level 1 
                        seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/allarme_on.png"" alt=""allarme_on""> </span></td>"
                        indice_seconda_colonna = indice_seconda_colonna + 1
                    Else
                        seconda_colonna(indice_seconda_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + livello_traduzione + "2</span><span style=""float:right;"" ><img src=""theme/images/allarme_off.png"" alt=""allarme_off""> </span></td>"
                        indice_seconda_colonna = indice_seconda_colonna + 1
                    End If


                End If
                Select Case Mid(output_canale(1), 1, 1) ' pulse 1
                    Case "2" ' off
                        terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                        indice_terza_colonna = indice_terza_colonna + 1
                    Case "0" ' on/off
                        If Mid(output_canale(5), 1, 3) = "001" Then ' on 
                            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        Else
                            If Mid(output_canale(5), 1, 3) = "000" Then ' off
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If
                        End If
                    Case "1" ' proportional
                        If Mid(output_canale(5), 1, 3) = "000" Then ' off
                            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        Else
                            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        End If

                End Select
                If Mid(output_canale(2), 1, 1) <> "3" Then ' ph releya
                    If versione < 419 Then
                        If Mid(output_canale(4), 1, 1) = "1" Then
                            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        Else
                            If Mid(output_canale(4), 1, 1) = "2" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If
                        End If

                    Else
                        If Mid(output_canale(6), 1, 1) = "1" Then
                            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                            indice_terza_colonna = indice_terza_colonna + 1
                        Else
                            If Mid(output_canale(6), 1, 1) = "2" Then
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            Else
                                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                                indice_terza_colonna = indice_terza_colonna + 1
                            End If
                        End If

                    End If

                Else
                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                    indice_terza_colonna = indice_terza_colonna + 1
                End If
                'If versione >= 419 Then
                '    Select Case Mid(output_canale(3), 1, 1) ' pulse 1
                '        Case "2" ' off
                '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                '            indice_terza_colonna = indice_terza_colonna + 1
                '        Case "0" ' on/off
                '            If Mid(output_canale(7), 1, 3) = "001" Then ' on 
                '                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                '                indice_terza_colonna = indice_terza_colonna + 1
                '            Else
                '                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                '                    terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                '                    indice_terza_colonna = indice_terza_colonna + 1
                '                End If
                '            End If
                '        Case "1" ' proportional
                '            If Mid(output_canale(5), 1, 3) = "000" Then ' off
                '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                '                indice_terza_colonna = indice_terza_colonna + 1
                '            Else
                '                terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + pulse_traduzione + "1</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                '                indice_terza_colonna = indice_terza_colonna + 1
                '            End If

                '    End Select
                '    If Mid(output_canale(4), 1, 1) <> "3" Then ' ph releya
                '        If Mid(output_canale(8), 1, 1) = "1" Then
                '            terza_colonna(indice_terza_colonna) = "<td width=""33%""  ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons circle_ok green"" ><i></i>" + "ON" + "</span></span></td>"
                '            indice_terza_colonna = indice_terza_colonna + 1
                '        Else
                '            If Mid(output_canale(8), 1, 1) = "2" Then
                '                terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                '                indice_terza_colonna = indice_terza_colonna + 1
                '            End If
                '            terza_colonna(indice_terza_colonna) = "<td width=""33%"" ><span style=""font-weight:bold;"">" + rele_traduzione + "</span><span style=""width:60px;float :right;""><span class="" btn-small btn-icon glyphicons remove gray"" ><i></i>" + "OFF" + "</span></span></td>"
                '            indice_terza_colonna = indice_terza_colonna + 1
                '        End If

                '    End If
                'End If
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
                                 ByVal alarm_value() As String, ByVal tipo_strumento As String, ByVal flow_traduzione As String, ByVal num_versione As Integer, ByVal nome_strumento As Integer) As String
        Dim ora As String
        Dim app_am As Integer
        Dim intestazione As String = ""
        Dim temperature_value As Single = 0


        'creazione widget data ora
        ora = Mid(clock_value(4), 1, 2) + ":" + Mid(clock_value(5), 1, 2)
        If formato_data = "1" Then ' americano
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
                Case "LD"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LDDT"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                Case "LDS"
                    temperature_value = (Val(Mid(valuer_value(2), 1, 3)) / 10)
                Case "LD4"
                    temperature_value = (Val(Mid(valuer_value(5), 1, 3)) / 10)
            End Select

            intestazione = intestazione + "<div data-percent=""" + temperature_value.ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + temperature_value.ToString + "</span>°<canvas width=""50"" height=""50""></canvas></div>"
            intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °C</span>"
        End If
        If formato_data = "1" Then ' americano
            Select Case tipo_strumento
                Case "LD"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
                Case "LDDT"
                    temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
                Case "LDS"
                    temperature_value = (Val(Mid(valuer_value(2), 1, 3)))
                Case "LD4"
                    temperature_value = (Val(Mid(valuer_value(5), 1, 3)))
            End Select
            intestazione = intestazione + "<div data-percent=""" + ((temperature_value - 32) / 1.8).ToString + """class=""easy-pie success easyPieChart"" style=""width: 50px; height: 50px; line-height: 50px;""><span class=""value"">" + temperature_value.ToString + "</span>°<canvas width=""50"" height=""50""></canvas></div>"
            intestazione = intestazione + "<span class=""txt"">" + temperatura_traduzione + " °F</span>"
        End If
        intestazione = intestazione + "<div class=""clearfix""></div>"
        intestazione = intestazione + "</a>"
        literal2.Text = intestazione

        ' end creazione widget temperatura
        Select Case tipo_strumento
            Case "LD4"

                ' creazione widget flusso instantaneo/totalizzatore
                intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
                intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
                intestazione = intestazione + "<span>Flow Meter:</span>"
                Dim m3h_valore As Single = 0
                m3h_valore = Val(valuer_value(7)) / 100



                If formato_data = "1" Then ' americano
                    intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> G/h <br/>"
                Else
                    intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> m3/h <br/>"

                End If
                intestazione = intestazione + "<span>Totalizer:</span>"
                intestazione = intestazione + "<span><strong>" + valuer_value(8) + "</strong></span> WMI <br/>"

                'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                intestazione = intestazione + "</div>"
                intestazione = intestazione + "</a>"
                literal4.Text = intestazione
                ' end creazione widget flusso instantaneo/totalizzatore
        End Select
        '  creazione elenco messaggi generali o allarmi generali

        Select Case tipo_strumento
            Case "LD"

                If nome_strumento = 1 Then

                    intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
                    intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
                    intestazione = intestazione + "<span>Flow Meter:</span>"
                    Dim m3h_valore As Single = 0
                    m3h_valore = Val(valuer_value(5)) / 100




                    'intestazione = intestazione + "<span><strong>" + valuer_value(6) + "</strong></span> m3/h <br/>"


                    If formato_data = "1" Then ' americano
                        intestazione = intestazione + "<span><strong>" + valuer_value(6).ToString + "</strong></span> G/h <br/>"
                    Else
                        intestazione = intestazione + "<span><strong>" + valuer_value(6).ToString + "</strong></span> m3/h <br/>"

                    End If

                    intestazione = intestazione + "<span>Totalizer:</span>"
                    intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> WMI <br/>"

                    'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                    'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                    intestazione = intestazione + "</div>"
                    intestazione = intestazione + "</a>"
                    literal4.Text = intestazione


                Else
                    If num_versione < 800 Then

                    Else
                        intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
                        intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
                        intestazione = intestazione + "<span>Flow Meter:</span>"
                        Dim m3h_valore As Single = 0
                        m3h_valore = Val(valuer_value(5)) / 100




                        'intestazione = intestazione + "<span><strong>" + valuer_value(6) + "</strong></span> m3/h <br/>"


                        If formato_data = "1" Then ' americano
                            intestazione = intestazione + "<span><strong>" + valuer_value(6).ToString + "</strong></span> G/h <br/>"
                        Else
                            intestazione = intestazione + "<span><strong>" + valuer_value(6).ToString + "</strong></span> m3/h <br/>"

                        End If

                        intestazione = intestazione + "<span>Totalizer:</span>"
                        intestazione = intestazione + "<span><strong>" + valuer_value(7) + "</strong></span> WMI <br/>"

                        'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                        'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                        intestazione = intestazione + "</div>"
                        intestazione = intestazione + "</a>"
                        literal4.Text = intestazione


                    End If
                End If
                intestazione = "<tr style="""">"
                If main_function.alarm_ld_flusso(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                literal6.Text = intestazione

            Case "LDDT"
                intestazione = "<tr style="""">"
                If main_function.alarm_ld_flusso(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If

                literal6.Text = intestazione





            Case "LDS"


                If num_versione < 430 Then

                Else
                    ' creazione widget flusso instantaneo/totalizzatore
                    intestazione = "<a href="""" class=""widget-stats widget-stats-2 widget-stats-easy-pie txt-single"">"
                    intestazione = intestazione + "<div style=""margin-top: -10px;margin-left: 20px;"">"
                    intestazione = intestazione + "<span>Flow Meter:</span>"
                    Dim m3h_valore As Single = 0
                    m3h_valore = Val(valuer_value(5)) / 100

                    'intestazione = intestazione + "<span><strong>" + (m3h_valore / 10).ToString + "</strong></span> m3/h <br/>"
                    intestazione = intestazione + "<span><strong>" + valuer_value(5) + "</strong></span> m3/h <br/>"
                    intestazione = intestazione + "<span>Totalizer:</span>"
                    intestazione = intestazione + "<span><strong>" + valuer_value(6) + "</strong></span> WMI <br/>"

                    'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                    'intestazione = intestazione + "<span class=""txt"">" + Flow_meter_traduzione + "</span>"
                    intestazione = intestazione + "</div>"
                    intestazione = intestazione + "</a>"
                    literal4.Text = intestazione
                End If
                intestazione = "<tr style="""">"
                If main_function.alarm_lds_flusso(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                literal6.Text = intestazione
            Case "LD4"
                intestazione = "<tr style="""">"
                If main_function.alarm_ld_flusso(alarm_value) Then
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_on.png"" alt=""allarme_on""></td>"
                Else
                    intestazione = intestazione + "<td width=""32%"">" + flow_traduzione + "</td>"
                    intestazione = intestazione + "<td width=""33%"" align=""center""><img src=""theme/images/allarme_off.png"" alt=""allarme_off""></td>"
                End If
                literal6.Text = intestazione
        End Select

        'end creazione elenco messaggi generali o allarmi generali

    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class