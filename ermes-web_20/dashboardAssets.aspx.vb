Imports System.Xml
Imports System.IO

Public Class dashboardAssets
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub dashboardAssets_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
        Dim precedente_impianto As String = ""
        Dim htmlCentralina As String = ""
        Dim listCenturio As New List(Of String)
        Dim listData As New Dictionary(Of String, String)
        Dim listDataCode As New Dictionary(Of String, String)

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
        Dim comunicazioni As String = ""
        Dim block_yagel As Boolean = False
        Dim time_connessione_min As Long = 0
        Dim scriptCenturioReal As String = "var serialNumber='';var stringJson='';var stringGlobal='';var nomeLabel='';var stringDecimal='';var stringLabel=''; var resultPipe='';var resultConfigurationInput='';var stringJsonGlobalInputOutput ='';var traduzioneModificaGlobal ='';var traduzioneEliminaGlobal ='';var traduzioneVaiImpiantoGlobal ='';var nomeImpiantoDBGlobal =''; var hrefGlobal='';"

        tabella_strumento = Session("strumento")
        tabella_impianto = Master.tabella_impianto_container

        javaScriptLiteral.Text = "<script type=""text/javascript"">"

        comunicazioni = GetGlobalResourceObject("communication_g", "ultime")
        For Each dc1 In tabella_strumento
            If InStr(dc1.nome, "Y#o") Or dc1.tipo_strumento = "LD4" Then
                block_yagel = True
                ' comunicazioni = "<h4>Warning!! This account will be terminated Friday the 10th of April at 12:00 Italian time.</h4><p> Please contact your EMEC distributor for information.</p>"
                If dc1.codice = "268994" Or dc1.codice = "869534" Or
                    dc1.codice = "10000013" Or dc1.codice = "10000005" Or
                    dc1.codice = "0549263889" Or dc1.codice = "287758" Or dc1.codice = "646324" Or
                    Session("mid_super").ToString = "091eeeb4-7d61-4a04-a8fb-804652eb980f" Or
                    Session("mid_super").ToString = "c97c4283-7763-45ab-8ba1-35f2a2912d8b" Or
                    Session("mid_super").ToString = "63216ade-252d-4016-acc2-d100f19b8578" Or
                    Session("mid_super").ToString = "d03dfb93-095f-4f2a-b0ed-2b1c3059e2f1" Or
                    Session("mid_super").ToString = "564629ca-0d28-4f3e-808b-585424b93dd6" Or
                    Session("mid_super").ToString = "ab4d51a9-91ad-40a9-82f3-37cebd476e0d" Then

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
            prima_volta = True
            If dc.identificativo.Length < 17 Then
                For Each dc1 In tabella_strumento
                    Try
                        If dc1.codice = dc.identificativo Then
                            htmlCentralina = htmlCentralina + lettura_canali(contatore_strumenti, dc1, GetGlobalResourceObject("impianto_global", "gestisci_parametri"), GetGlobalResourceObject("impianto_global", "no_connected"), GetGlobalResourceObject("impianto_global", "last_update"), GetGlobalResourceObject("impianto_global", "no_flow"), GetGlobalResourceObject("impianto_global", "flow_ok"), check_alarm_general, check_connected, nome_impianto, time_connessione_min, dc.nome_impianto)
                        End If
                    Catch ex As Exception

                    End Try
                Next
            Else
                'verifica se è pompa o centurio
                Dim typeStrumento As Integer = 0
                For Each dc1 In tabella_impianto
                    If dc1.identificativo = dc.identificativo Then
                        typeStrumento = dc1.Expr2
                    End If
                Next
                If typeStrumento = 0 Then
                    Dim mainFunctionConfig As String = mainFunctionCenturio.getConfigCentrurio(dc.identificativo)
                    Dim tabella_centurio As ermes_web_20.centurioQuery.centurioConfigDataTable
                    Dim query As New query
                    'Dim querydb As New queryDB



                    'If mainFunctionConfig <> "null" Then ' null sta ad identificare non connesso altrimenti ho il codice
                    Dim pipeClient As New centurioRealTime
                    Dim hrefCenturio As String = ""
                    Dim resultPipe As String = ""
                    Dim resultConfigurationInput As String = ""
                    Dim sistemaUSA As String = ""
                    resultPipe = pipeClient.Main(dc.identificativo, "controller_type")

                    'MsgBox(resultPipe)
                    If resultPipe <> "null" And resultPipe <> "" Then

                        resultPipe = resultPipe
                        resultConfigurationInput = pipeClient.Main(dc.identificativo, "configurationFinal")
                        sistemaUSA = pipeClient.Main(dc.identificativo, "sistemaUSA")
                        If sistemaUSA = "true" Then
                            sistemaUSA = "1"
                        Else
                            sistemaUSA = "0"
                        End If
                        'tabella_centurio = query.getRuntimeSchema("OSIN01")

                    Else
                        'Dim strinxXML As String = query.getConfigGlobal(1)
                        Dim strinxXML As String = getConfigFromFile(dc.identificativo)
                        sistemaUSA = "0"
                        'resultPipe = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 2)
                        If (strinxXML <> "") Then
                            resultPipe = mainFunctionCenturio.getFileInfoXML(dc.identificativo, strinxXML, 2)
                            'resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 3)
                            resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(dc.identificativo, strinxXML, 3)
                            'MsgBox(resultPipe + " " + resultConfigurationInput)
                        Else
                            strinxXML = query.getConfigGlobal(1)
                            resultPipe = mainFunctionCenturio.getFileInfoXML(dc.identificativo, strinxXML, 2)
                            resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(dc.identificativo, strinxXML, 3)
                            'MsgBox(resultPipe + " XM " + resultConfigurationInput)
                        End If
                    End If

                    tabella_centurio = query.getRuntimeSchema(resultPipe)
                    If sistemaUSA = "" Then
                        sistemaUSA = "0"
                    End If
                    'tabella_centurio = query.getRuntimeSchemaLanguage(Session("selectedLanguage"), resultPipe)
                    If (resultConfigurationInput = "5|16|16|0|0|") Then ' caso cd ma ma
                        resultConfigurationInput = "5|16|161|0|0|"
                    End If
                    'intestazione = intestazione + "<a href=""mainCenturio.aspx?serial=" + dc.identificativo + "&codice=" + resultPipe + "&sistemaUSA=" + sistemaUSA + "&configuration=" + resultConfigurationInput + """ Class=""block"">"
                    hrefCenturio = "mainCenturio.aspx?serial=" + dc.identificativo + "&codice=" + resultPipe + "&sistemaUSA=" + sistemaUSA + "&configuration=" + resultConfigurationInput
                    listCenturio.Add("mainCenturio.aspx?serial=" + dc.identificativo + "&codice=" + resultPipe + "&sistemaUSA=" + sistemaUSA + "&configuration=" + resultConfigurationInput)
                    htmlCentralina = htmlCentralina + "<div  id=""" + dc.identificativo + "_main""" + "></div>"
                    'intestazione = intestazione + "</a>"

                    Dim oXMLDoc As XmlDocument = New XmlDocument
                    Dim oXMLDoc1 As XmlDocument = New XmlDocument
                    Dim stringJson As String = "{""variable"": "
                    Dim stringJsonGlobal As String = "{""variable"":"
                    Dim stringJsonGlobalInputOutput As String = "{""variable"":"
                    Dim stringJsonDecimal As String = "{""variable"":"
                    Dim stringJsonLabel As String = ""

                    For Each dc1 In tabella_centurio
                        oXMLDoc.LoadXml(dc1.configRuntime)
                        Dim LstNodes As XmlNodeList
                        Dim jsonVariableMain As String = ""
                        Dim stringJsonDecimalTemp As String = ""
                        LstNodes = oXMLDoc.GetElementsByTagName("areacanale")

                        jsonVariableMain = prepareJson(LstNodes, dc.identificativo, stringJsonDecimalTemp, resultConfigurationInput)
                        stringJson = stringJson + jsonVariableMain + "}"
                        stringJsonDecimal = stringJsonDecimal + stringJsonDecimalTemp + "}"

                        LstNodes = oXMLDoc.GetElementsByTagName("areaglobal")
                        jsonVariableMain = prepareJson(LstNodes, dc.identificativo, stringJsonDecimalTemp)
                        stringJsonGlobal = stringJsonGlobal + jsonVariableMain + "}"

                        LstNodes = oXMLDoc.GetElementsByTagName("areainout")
                        jsonVariableMain = prepareJsonAreaInOutAlarm(LstNodes, dc.identificativo, stringJsonDecimalTemp)
                        stringJsonGlobalInputOutput = stringJsonGlobalInputOutput + jsonVariableMain + "}"


                        'stringJsonDecimal = stringJsonDecimal + stringJsonDecimalTemp + "}"
                        Select Case Session("selectedLanguage")
                            Case "en"
                                oXMLDoc.LoadXml(dc1.configSetpoint_en)
                                If Not dc1.touch Then
                                    oXMLDoc1.LoadXml(dc1.label_en)
                                End If
                            Case "it"
                                oXMLDoc.LoadXml(dc1.configSetpoint_it)
                                If Not dc1.touch Then
                                    oXMLDoc1.LoadXml(dc1.label_it)
                                End If

                            Case Else
                                oXMLDoc.LoadXml(dc1.configSetpoint_en)
                                If Not dc1.touch Then
                                    oXMLDoc1.LoadXml(dc1.label_en)
                                End If

                        End Select

                        LstNodes = oXMLDoc.GetElementsByTagName("Istanza")
                        If dc1.touch Then
                            stringJsonLabel = stringJsonLabel + mainFunctionCenturio.preparaLabelJS(LstNodes, resultConfigurationInput)
                        Else
                            LstNodes = oXMLDoc1.GetElementsByTagName("label")
                            stringJsonLabel = stringJsonLabel + mainFunctionCenturio.preparaLabelJSNoTouch(LstNodes)
                        End If


                        javaScriptLiteral.Text = javaScriptLiteral.Text + "get_data('" + dc.identificativo + "','" + stringJson + "','" + stringJsonGlobal + "','" + dc1.nomeStrumento + "','" + stringJsonDecimal + "','" + stringJsonLabel + "','" + resultPipe + "','" + resultConfigurationInput + "','" + stringJsonGlobalInputOutput + "','" + sistemaUSA + "','" + GetGlobalResourceObject("main_master_global", "modifica") + "','" + GetGlobalResourceObject("main_master_global", "eliminaController") + "','Vai all\'impianto','" + dc.nome_impianto + "','" + hrefCenturio + "',true);"
                        scriptCenturioReal = scriptCenturioReal + "serialNumber = '" + dc.identificativo + "';" + "stringJson='" + stringJson + "';" + "stringGlobal='" + stringJsonGlobal + "';" + "stringLabel='" + stringJsonLabel + "';" + "nomeLabel='" + dc1.nomeStrumento + "';" + "resultPipe='" + resultPipe + "';" + "resultConfigurationInput='" + resultConfigurationInput + "';" + "stringJsonGlobalInputOutput='" + stringJsonGlobalInputOutput + "';" + "sistemaUSA='" + sistemaUSA + "';" +
                                "stringDecimal='" + stringJsonDecimal + "';traduzioneModificaGlobal='" + GetGlobalResourceObject("main_master_global", "modifica") + "';traduzioneEliminaGlobal='" + GetGlobalResourceObject("main_master_global", "eliminaController") + "';traduzioneVaiImpiantoGlobal='Vail all\'impianto';nomeImpiantoDBGlobal='" + dc.nome_impianto + "';hrefGlobal='" + hrefCenturio + "';" +
                                "get_data(serialNumber,stringJson,stringGlobal,nomeLabel,stringDecimal,stringLabel,resultPipe,resultConfigurationInput,stringJsonGlobalInputOutput,sistemaUSA,traduzioneModificaGlobal,traduzioneEliminaGlobal,traduzioneVaiImpiantoGlobal,nomeImpiantoDBGlobal,hrefGlobal,false);"
                    Next
                Else 'strumenti e pompe di nuova comunicazione
                    Select Case typeStrumento
                        Case 1 ' pompa prisma
                            htmlCentralina = htmlCentralina + "<div Class=""col-xl-3 col-sm-6 plant pompa"" id=""" + dc.identificativo + "_pump""" + ">"
                            htmlCentralina = htmlCentralina + "<script type = ""text/javascript"" >"
                            htmlCentralina = htmlCentralina + "var NarrayReadRealTime = [1];"
                            htmlCentralina = htmlCentralina + "var NserialNumber = """ + dc.identificativo + """;"
                            htmlCentralina = htmlCentralina + "var NplantName = """ + dc.nome_impianto + """;"
                            htmlCentralina = htmlCentralina + "var NreadSetpoint = true;"
                            htmlCentralina = htmlCentralina + "var NarrayReadSetpoint = [2];"
                            htmlCentralina = htmlCentralina + "var Nlanguage = '" + Session("selectedLanguage") + "';"

                            htmlCentralina = htmlCentralina + "var Pompa" + dc.identificativo + " = new OggettoPompa({serialNumber:NserialNumber, arrayReadRealTime:NarrayReadRealTime, arrayReadSetpoint:NarrayReadSetpoint,plantName:NplantName,readSetpoint:NreadSetpoint,languageSet:Nlanguage});"
                            htmlCentralina = htmlCentralina + "Pompa" + dc.identificativo + ".createConnection();"
                            htmlCentralina = htmlCentralina + "</script>"
                            'un primo caricamento di info per indicare le fasi di connessione
                            htmlCentralina = htmlCentralina + "<div Class=""card card-default card-mini "">"
                            htmlCentralina = htmlCentralina + "<div Class=""card-header red"" >"
                            htmlCentralina = htmlCentralina + "<h4>" + dc.identificativo + "</h4>"
                            If Session("super_user") Then
                                htmlCentralina = htmlCentralina + "<div class=""dropdown"">"
                                htmlCentralina = htmlCentralina + "<a class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
                                htmlCentralina = htmlCentralina + "<div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
                                htmlCentralina = htmlCentralina + "<a class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + dc.identificativo + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
                                htmlCentralina = htmlCentralina + "<a class=""dropdown-item delete_plant"" code=""" + dc.identificativo + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a></div></div>"
                            End If
                            htmlCentralina = htmlCentralina + "<div Class=""sub-title"">"
                            htmlCentralina = htmlCentralina + "<span class=""mr-1"">" + dc.nome_impianto + " </span><i  class=""mdi mdi-check-decagram""></i></div></div>"
                            htmlCentralina = htmlCentralina + "<div id ='statusConnection" + dc.identificativo + "' class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>Connecting ...<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div></div>"
                            htmlCentralina = htmlCentralina + "</div>"

                        Case 2
                    End Select
                End If


            End If
        Next
        listaStrumenti.Text = htmlCentralina
        If prima_volta = False Then 'impianti non caricati

        End If
        javaScriptLiteral.Text = javaScriptLiteral.Text + "setInterval(explode, 4000);function explode() {" + scriptCenturioReal + "};console.log('finito');"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "</script>"
        Session.Remove("centurioList")
        Session("centurioList") = listCenturio

    End Sub
    Public Function lettura_canali(ByVal numero_strumenti As Integer, ByVal riga As ermes_web_20.quey_db.strumentiRow,
                                    ByVal gestisci_parametri_traduzione As String,
                                    ByVal not_connected_traduzione As String, ByVal last_update_traduzione As String,
                                   ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                                   ByRef check_alarm_general As Boolean, ByRef check_connected As Boolean, ByVal nome_impanto As String, ByRef time_connessione_min As Long, ByVal nomeImpiantoDB As String) As String

        Dim intestazione As String = ""
        Dim href As String = ""
        'Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        'Dim tipo_strumento_label As String = ""
        Dim tipo_strumento As String = riga.tipo_strumento
        Dim time_connected As Long
        check_connected = main_function.check_is_connected(riga.data_aggiornamento, time_connected)
        time_connessione_min = time_connected
        If numero_strumenti > 0 Then
            numero_strumenti = numero_strumenti - 1
        End If
        Select Case tipo_strumento
            Case "max5" 'Replace(nome_impanto, " ", "£") 
                href = "max5.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_max5(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
            Case "LDtower"
                href = "ldtower.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_tower(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, tipo_strumento, nomeImpiantoDB, href)

            Case "Tower"
                href = "tower.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_tower(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, tipo_strumento, nomeImpiantoDB, href)
                'items_tower(riga, check_connected)
            Case "LD"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_ld(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
                'items_ld(riga, check_connected)
            Case "LDDT"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_lddt(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
                'items_ld(riga, check_connected)
            Case "LDD4"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_ld(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
                'items_ld(riga, check_connected)
            Case "LDMA"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=45&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_ld_ma(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
            Case "LDLG"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=58&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_ld_lg(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)

            Case "LDS"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_lds(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
                'items_lds(riga, check_connected)
            Case "LD4"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_ld4(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
            Case "WD"
                href = "wd.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_wd(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)

            Case "WH"
                href = "wd.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_wd(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
            Case "LTB"
                href = "ltb.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_ltb(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
            Case "LTA"
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
            Case "LTD"
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)

            Case "LTU"
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, nomeImpiantoDB, href)
        End Select
        Return intestazione

    End Function
    Public Function items_max5(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                               ByVal last_update_traduzione As String, ByVal time_connected As Long,
                               ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String _
                               , ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String

        Dim intestazione As String = ""
        Dim intestazioneTemp As String = ""
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
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If


        config_value = main_function.get_split_str(riga.value1)
        alarm_value = main_function.get_split_str(riga.value2)
        flow_value = main_function.get_split_str(riga.value3)
        option_value = main_function.get_split_str(riga.value4)
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"
            'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"

        Dim integer_item As Integer = 0
        integer_item = main_function.alarm_max5_flow(alarm_value(10)) 'flusso


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


                ' intestazione = intestazione + "<tr class=""selectable"">"

                valore_canale_temp = Val(Mid(alarm_value(i - 1), 3, 4)) / 1000

                If Not check_connected Or integer_item > 0 Then ' se non connesso scrivo zero o allarme di flusso
                    valore_canale_temp = 0
                    canale_allarme = False
                End If

                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">HClO<strong>" + valore_canale_temp.ToString + "</strong></div>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">HClO<strong>" + valore_canale_temp.ToString + "</strong></div>"
                End If

                valore_canale_temp = Val(Mid(alarm_value(i), 3, 4)) / fattore_divisione_temp ' cloro libero
                If Not check_connected Or integer_item > 0 Then ' se non connesso scrivo zero o allarme di flusso
                    valore_canale_temp = 0
                    canale_allarme = False
                End If

            End If
            If label_canale_temp <> "" Then


                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                End If


            End If
            If main_function.get_tipo_personalizzazione(riga.nome) = "seiCanali" And i = 3 Then
                label_canale_temp = "Clt"
                valore_canale_temp = Val(Mid(alarm_value(13), 3, 4)) / fattore_divisione_temp
                If Not check_connected Or integer_item > 0 Then ' se non connesso scrivo zero o allarme di flusso
                    valore_canale_temp = 0
                    canale_allarme = False
                End If
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                End If


                label_canale_temp = "ClCom"
                valore_canale_temp = Val(Mid(alarm_value(4), 3, 4)) / fattore_divisione_temp
                If Not check_connected Or integer_item > 0 Then ' se non connesso scrivo zero o allarme di flusso
                    valore_canale_temp = 0
                    canale_allarme = False
                End If
                If canale_allarme Then ' canale in allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                Else ' canale in non allarme
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                End If
                i = 5
            End If

        Next

        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim temperature_value1 As Single = 0
        Dim temperatureIntestazione As String = ""

        temperature_value = Val(main_function_config.get_temperature_info(flow_value(3), temperature_type))

        If Not check_connected Or integer_item > 0 Then ' se non connesso scrivo zero o allarme di flusso
            temperature_value = 0
            temperature_value1 = 0
        End If

        If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
            temperature_value = Val(main_function_config.get_temperature_infoDoppiaPiscina(flow_value(3), temperature_value1, temperature_type))
            temperatureIntestazione = "T1:"
        End If
        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If temperature_type = 0 Then 'temperatura in celsius
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + temperature_value.ToString + "</strong></div>"
        Else ' canale in non allarme
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + temperature_value.ToString + "</strong></div>"
        End If
        If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
            If temperature_type = 0 Then 'temperatura in celsius
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + temperature_value1.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + temperature_value1.ToString + "</strong></div>"
            End If
        End If
        'gggggggg
        'colore del pulsante vai allimpianto
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"
        ' end visualizzazione temperatura

        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")
        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or integer_item > 0 Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If (integer_item > 0) Then
                    Dim statoHtmlTesto As String = ""
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")

            End If
        End If
        Return intestazione
    End Function
    Public Function items_tower(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                       ByVal last_update_traduzione As String, ByVal time_connected As Long,
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                       ByRef check_alarm_general As Boolean, ByVal tipo_strumento As String, ByVal nomeImpiantoDB As String, ByVal href As String) As String
        Dim intestazione As String = ""
        Dim intestazioneTemp As String = ""
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
        Dim unit_value() As String
        Dim personalizzazione_aquacare As Integer = 0
        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + "-" + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If
        End If

        config_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        allrmr_value = main_function.get_split_str(riga.value3)
        unit_value = main_function.get_split_str(riga.value1)
        main_function_config.chek_tower_version(riga.nome, version_str, personalizzazione_aquacare)

        check_alarm_general = False

        configurazione_canali = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)

        numero_canali = configurazione_canali.Split("_").Length
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"

        For i = 1 To numero_canali 'Tower può essere uno, due o tre canali
            Select Case i
                Case 1 'controllo canale 1
                    If tipo_strumento = "LDtower" Then
                        main_function_config.get_tipo_strumento_ldtower(config_value(0), config_value(1), config_value(2), config_value(3), version_str, fattore_divisione_temp,
                                                                  , , scala_temp, , , label_canale_temp)

                    Else
                        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, fattore_divisione_temp,
                                                                  , , scala_temp, , , label_canale_temp)

                    End If
                    If scala_temp = 9999 Or scala_temp = 5000 Or scala_temp = 500 Then
                        valore_canale_temp = Val(Mid(valuer_value(0), 3, 4)) / fattore_divisione_temp
                    Else
                        valore_canale_temp = (Val(Mid(valuer_value(0), 3, 4)) * 10) / fattore_divisione_temp
                    End If
                    Dim valoreCanalestr As String = ""
                    If main_function.alarm_tower_bleed_timeout(allrmr_value) Or main_function.alarm_tower_high_conductivity(allrmr_value) _
                        Or main_function.alarm_tower_low_conductivity(allrmr_value) Or main_function.alarm_tower_level_prebiocide1(allrmr_value) _
                        Or main_function.alarm_tower_level_biocide1(allrmr_value) Or main_function.alarm_tower_level_prebiocide2(allrmr_value) _
                        Or main_function.alarm_tower_level_biocide2(allrmr_value) Or main_function.alarm_tower_level_inhibitor(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else ' canale in non allarme
                        canale_allarme = False
                    End If
                    If Not check_connected Or main_function.alarm_tower_flow(allrmr_value) Or main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then ' se non connesso scrivo zero o allarme di flusso
                        valore_canale_temp = 0
                        canale_allarme = False
                    End If

                    If valore_canale_temp > scala_temp Or valore_canale_temp < 0 Then
                        valoreCanalestr = "*****"
                    Else
                        valoreCanalestr = valore_canale_temp.ToString
                    End If

                Case 2 'controllo canale 2
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, ,
                                                                  fattore_divisione_temp, , scala_temp, , , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 11, 4)) / fattore_divisione_temp

                    If main_function.alarm_tower_level_ch2(allrmr_value) Or main_function.alarm_tower_ch2_low(allrmr_value) _
                        Or main_function.alarm_tower_ch2_high(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                    If Not check_connected Or main_function.alarm_tower_flow(allrmr_value) Or main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then ' se non connesso scrivo zero o allarme di flusso
                        valore_canale_temp = 0
                        canale_allarme = False
                    End If

                    Dim valoreCanalestr As String = ""
                    If valore_canale_temp > scala_temp Or valore_canale_temp < 0 Then
                        valoreCanalestr = "*****"
                    Else
                        valoreCanalestr = valore_canale_temp.ToString
                    End If
                    If canale_allarme Then
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valoreCanalestr + "</strong></div>"
                    Else
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">" + label_canale_temp + "<strong>" + valoreCanalestr + "</strong></div>"
                    End If

                Case 3 'controllo canale 3
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , ,
                                                                  fattore_divisione_temp, , , scala_temp, , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 15, 4)) / fattore_divisione_temp


                    If main_function.alarm_tower_level_ch3(allrmr_value) Or main_function.alarm_tower_ch3_low(allrmr_value) _
                        Or main_function.alarm_tower_ch3_high(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
                    If Not check_connected Or main_function.alarm_tower_flow(allrmr_value) Or main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then ' se non connesso scrivo zero o allarme di flusso
                        valore_canale_temp = 0
                        canale_allarme = False
                    End If

                    Dim valoreCanalestr As String = ""
                    If valore_canale_temp > scala_temp Or valore_canale_temp < 0 Then
                        valoreCanalestr = "*****"
                    Else
                        valoreCanalestr = valore_canale_temp.ToString
                    End If
                    If canale_allarme Then
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valoreCanalestr + "</strong></div>"
                    Else
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">" + label_canale_temp + "<strong>" + valoreCanalestr + "</strong></div>"
                    End If

            End Select
        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = valuer_value(0).IndexOf("value")
        Dim temperature_value As Single = 0
        temperature_value = (Val(Mid(valuer_value(0), 7, 4)))
        If Val(Mid(unit_value(0), 3, 1)) Then        'IS
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + (temperature_value / 10).ToString + "</strong></div>"
        End If
        If Val(Mid(unit_value(0), 4, 1)) Then        'US
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°F<strong>" + (temperature_value / 10).ToString + "</strong></div>"
        End If
        ' end visualizzazione temperatura
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"

        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_tower_flow(allrmr_value) Or main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                Dim statoHtmlTesto As String = ""
                If main_function.alarm_tower_flow(allrmr_value) Then
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                End If
                If main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Then
                    statoHtmlTesto = statoHtmlTesto + " WMB"
                End If
                If main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Then
                    statoHtmlTesto = statoHtmlTesto + " WMI"
                End If
                If main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then
                    statoHtmlTesto = statoHtmlTesto + " CF"
                End If

                If main_function.alarm_tower_flow(allrmr_value) Or main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione
    End Function
    Public Function items_ld(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                           ByVal last_update_traduzione As String, ByVal time_connected As Long,
                           ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                           ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean
        Dim intestazioneTemp As String = ""

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String


        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If


        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        If config_value.Length > 5 Then
            numero_canali = 4
        Else
            If Mid(config_value(3), 3, 3) <> "306" Then ' terzo canale esistente
                numero_canali = 3
            Else
                numero_canali = 2
            End If
        End If
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'ld può essere duo o tre canali
            'intestazione = intestazione + "<tr class=""selectable"">"
            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(calibrz_value(i), fattore_divisione_temp)

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
                    'canale_allarme = False 'non ci sono allarmi sul canale 3
                    If main_function.alarm_ld_minmax_3(allrmr_value) Then
                        canale_allarme = True
                    Else
                        canale_allarme = False

                    End If
                Case 4 'controllo allarmi canale 4
                    If main_function.alarm_ld_minmax_4(allrmr_value) Then
                        canale_allarme = True
                    Else
                        canale_allarme = False

                    End If

            End Select
            If i = 3 Then
                valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
            Else
                If i = 4 Then
                    valore_canale_temp = Val(Mid(valuer_value(6), 1, 4)) / fattore_divisione_temp
                Else
                    valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
                End If
            End If

            If Not check_connected Or main_function.alarm_ld_flusso(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If

            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If
        Next
        '        visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)


        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Then ' europeo
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + (temperature_value / 10).ToString + "</strong></div>"
        Else ' canale in non allarme
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + (temperature_value).ToString + "</strong></div>"
        End If
        ' end visualizzazione temperatura
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"

        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_ld_flusso(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_ld_flusso(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione

    End Function
    Public Function items_lddt(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                           ByVal last_update_traduzione As String, ByVal time_connected As Long,
                           ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                           ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
        Dim intestazione As String = ""
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim numero_canali As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim canale_allarme As Boolean
        Dim intestazioneTemp As String = ""

        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String


        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If


        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 2
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'ld può essere duo o tre canali
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
            If Not check_connected Or main_function.alarm_lddt_flusso(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If

            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If

        Next
        '        visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)


        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Then ' europeo
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + (temperature_value / 10).ToString + "</strong></div>"
        Else ' canale in non allarme
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + (temperature_value).ToString + "</strong></div>"
        End If
        ' end visualizzazione temperatura
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"

        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_lddt_flusso(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_ld_flusso(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione
    End Function

    Public Function items_ld_ma(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                       ByVal last_update_traduzione As String, ByVal time_connected As Long,
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                       ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        setpntr_value = main_function.get_split_str(riga.value7)

        check_alarm_general = False
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"

        For i = 1 To numero_canali 'ld può essere duo o tre canali
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
            If Not check_connected Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If
            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If

        Next
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"

        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                intestazione = intestazione.Replace("ffffffff", "")
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione
    End Function
    Public Function items_ld_lg(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                   ByVal last_update_traduzione As String, ByVal time_connected As Long,
                   ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                   ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        setpntr_value = main_function.get_split_str(riga.value7)

        check_alarm_general = False
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali * 2 'ld può essere duo o tre canali

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

            If Not check_connected Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If

            If canale_allarme Then ' canale in allarme
                If (i <= numero_canali) Then
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "L</strong></div>"
                Else
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "m3</strong></div>"
                End If
            Else ' canale in non allarme
                If (i <= numero_canali) Then
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "L</strong></div>"
                Else
                    intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "m3</strong></div>"
                End If
            End If
        Next
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"

        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                intestazione = intestazione.Replace("ffffffff", "")
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione
    End Function
    Public Function items_lds(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                       ByVal last_update_traduzione As String, ByVal time_connected As Long,
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                       ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 1
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'lds solo un canale

            'intestazione = intestazione + "<td class=""center"">"
            If calibrz_value(i).Length > 2 Then
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 3), fattore_divisione_temp)
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            End If

            'label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
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

            If Not check_connected Or main_function.alarm_lds_flusso(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If
            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If

        Next
        '        visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(2), 1, 3)))
        formato_data = Mid(valuer_value(3), 1, 1)


        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Then ' europeo
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + (temperature_value / 10).ToString + "</strong></div>"
        Else ' canale in non allarme
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + (temperature_value).ToString + "</strong></div>"
        End If
        ' end visualizzazione temperatura
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"
        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_lds_flusso(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_lds_flusso(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione

    End Function
    Public Function items_ld4(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                         ByVal last_update_traduzione As String, ByVal time_connected As Long,
                         ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                         ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim tipo_strumento_label As String = ""
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 5
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'ld può essere duo o tre canali

            '  intestazione = intestazione + "<td class=""center"">"
            If i < 5 Then
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Else
                label_canale_temp = "m3/h"
            End If

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
                Case 5 'controllo allarmi canale 4
                    If main_function.alarm_ld4_flowmeterLow(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                    Else
                        canale_allarme = False
                    End If
            End Select


            If i < 5 Then
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            Else
                Dim m3h_valore As Single = 0
                m3h_valore = Val(valuer_value(7)) / 100
                valore_canale_temp = (m3h_valore / 10).ToString
            End If

            If Not check_connected Or main_function.alarm_ld4_flusso(allrmr_value) Or main_function.alarm_ld4_stby(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If
            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If

        Next
        '        visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String

        intestazione = intestazione + "<tr class=""selectable"">"
        temperature_value = (Val(Mid(valuer_value(5), 1, 3)))
        formato_data = Mid(valuer_value(6), 1, 1)


        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Then ' europeo
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + (temperature_value / 10).ToString + "</strong></div>"
        Else ' canale in non allarme
            intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + (temperature_value).ToString + "</strong></div>"
        End If
        ' end visualizzazione temperatura
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"
        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_ld4_flusso(allrmr_value) Or main_function.alarm_ld4_stby(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_lds_flusso(allrmr_value) Or main_function.alarm_ld4_stby(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    If main_function.alarm_lds_flusso(allrmr_value) Then
                        main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                        If ore_flow = 0 Then
                            statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                        Else
                            statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                        End If
                    End If
                    If main_function.alarm_ld4_stby(allrmr_value) Then
                        statoHtmlTesto = statoHtmlTesto + " STBY "
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione

    End Function
    Public Function items_wd(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                       ByVal last_update_traduzione As String, ByVal time_connected As Long,
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                       ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 2
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'wd può essere due

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

            If Not check_connected Or main_function.alarm_wd_flusso(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If
            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If
        Next
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"
        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_lds_flusso(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_wd_flusso(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione
    End Function
    Public Function items_ltb(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                         ByVal last_update_traduzione As String, ByVal time_connected As Long,
                         ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                         ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim tipo_strumento_label As String = ""
        Dim intestazioneTemp As String = ""

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        ' Andrea Manetta 03-10-18  numero_canali = 2

        If Val(main_function.get_version(riga.nome)) < 125 Then
            numero_canali = 2
        End If

        If Val(main_function.get_version(riga.nome)) >= 125 Then
            numero_canali = 3
        End If
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'ld può essere duo o tre canali


            ' Andrea Manetta 03-10-18   label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)

            ' Andrea Manetta 03-10-18 
            If i = 3 And numero_canali = 3 Then
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(79, fattore_divisione_temp)  ' Andrea Manetta  03-10-18 
                If (Mid(valuer_value(8), 1, 1)) = 0 Then
                    label_canale_temp = " "
                End If
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp) ' Andrea Manetta  03-10-18 
                If (Mid(valuer_value(i + 4), 1, 1)) = 1 Then
                    label_canale_temp = " "
                End If
            End If
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
                Case 3 'controllo allarmi canale 2
                    'If main_function.alarm_ld4_livello_cl(allrmr_value) Or main_function.alarm_ld4_feedlimit_cl(allrmr_value) _
                    '    Or main_function.alarm_ld4_dosalarm_cl(allrmr_value) Or main_function.alarm_ld4_probefail_cl(allrmr_value) Then
                    '    check_alarm_general = True
                    '    canale_allarme = True
                    'Else
                    canale_allarme = False
                    'End If

            End Select

            ' Andrea Manetta 03-10-18  valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp


            ' Andrea Manetta 03-10-18 
            If i = 3 And numero_canali = 3 Then
                valore_canale_temp = Val(Mid(valuer_value(9), 1, 4)) / fattore_divisione_temp
            Else
                valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            End If


            If Not check_connected Or main_function.alarm_ltb_flow(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If
            If canale_allarme Then ' canale in allarme
                'intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                ' Andrea Manetta 03-10-18 intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
                ' Andrea Manetta 03-10-18 

                If i = 3 And numero_canali = 3 Then
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(79, fattore_divisione_temp)  ' Andrea Manetta  03-10-18 

                    If (Mid(valuer_value(8), 1, 1)) = 0 Then
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>  </strong></div>"
                    Else
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                    End If
                Else
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp) ' Andrea Manetta  03-10-18 
                    If (Mid(valuer_value(i + 4), 1, 1)) = 1 Then
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>  </strong></div>"
                    Else
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                    End If

                End If

            Else ' canale in non allarme
                'intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                ' Andrea Manetta 03-10-18   intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
                If i = 3 And numero_canali = 3 Then
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(79, fattore_divisione_temp)  ' Andrea Manetta  03-10-18 

                    If (Mid(valuer_value(8), 1, 1)) = 0 Then
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">" + label_canale_temp + "<strong>  </strong></div>"
                    Else
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                    End If
                Else
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp) ' Andrea Manetta  03-10-18 
                    If (Mid(valuer_value(i + 4), 1, 1)) = 1 Then
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">" + label_canale_temp + "<strong>  </strong></div>"
                    Else
                        intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
                    End If
                End If
            End If
        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String


        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)

        If formato_data = "0" Or formato_data = "3" Then ' europeo
            If (Mid(valuer_value(7), 1, 1)) = 1 Then
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong></strong></div>"
            Else
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action"">°C<strong>" + (temperature_value / 10).ToString + "</strong></div>"
            End If

        Else ' canale in non allarme
            If (Mid(valuer_value(7), 1, 1)) = 1 Then
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong></strong></div>"
            Else
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">°F<strong>" + (temperature_value).ToString + "</strong></div>"
            End If

        End If
        ' end visualizzazione temperatura
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"
        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_lds_flusso(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_ltb_flow(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione

    End Function
    Public Function items_lta(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                         ByVal last_update_traduzione As String, ByVal time_connected As Long,
                         ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                         ByRef check_alarm_general As Boolean, ByVal nomeImpiantoDB As String, ByVal href As String) As String
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
        Dim tipo_strumento_label As String = ""
        Dim intestazioneTemp As String = ""

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
            If tipo_strumento_label.Length > 18 Then
                tipo_strumento_label = Mid(tipo_strumento_label, 1, 18) + ".."
            End If

        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 2
        'filtri: pompa strumento impiantoacceso impiantospento allarme
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        intestazione = "<div Class=""col-xl-3 col-sm-6 plant strumento aaaaaaaa bbbbbbbb cccccccc""><div Class=""card card-default card-mini "">"
        'dddddddd da sostituire con colore 
        intestazione = intestazione + "<div Class=""card-header dddddddd"">"

        intestazione = intestazione + "<h4>" + id_strumento + " " + tipo_strumento_label + "</h4>"
        If Session("super_user") Then
            intestazione = intestazione + "<div Class=""dropdown"">"
            intestazione = intestazione + "<a Class=""dropdown-toggle icon-burger-mini"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""></a>"
            intestazione = intestazione + "<div Class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""dropdownMenuLink"">"
            intestazione = intestazione + "<a Class=""dropdown-item"" href=""" + ResolveUrl("~/") + "plant.aspx?codice=" + riga.codice + """>" + GetGlobalResourceObject("main_master_global", "modifica") + "</a>"
            intestazione = intestazione + "<a Class=""dropdown-item delete_plant"" code=""" + riga.codice + """ href=""#"">" + GetGlobalResourceObject("main_master_global", "eliminaController") + "</a>"
            intestazione = intestazione + "</div></div>"
        End If
        intestazione = intestazione + "<div Class=""sub-title"" >"

        'eeeeeeee da sostituitre  mdi-power-plug-off se disconnesso mdi-check-decagram se connesso
        intestazione = intestazione + "<span Class=""mr-1"">" + nomeImpiantoDB + " </span><i class=""mdi eeeeeeee""></i>"
        intestazione = intestazione + "</div></div>"

        'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
        '<div Class="list-group-item list-group-item-action"><i class="mdi mdi-power-plug-off"></i> Not connected<span class="badge badge-red badge-pill">	<i class="mdi mdi-arrow-down-bold white"></i></span></div>
        intestazione = intestazione + "ffffffff"

        intestazione = intestazione + "<div Class="" card-body""><div class="" list-group"">"
        For i = 1 To numero_canali 'ld può essere duo o tre canali

            '  intestazione = intestazione + "<td class=""center"">"
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
            Select Case i
                Case 1 'controllo allarmi canale 1
                    canale_allarme = False
                Case 2 'controllo allarmi canale 2
                    canale_allarme = False
            End Select

            valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            If Not check_connected Or main_function.alarm_lta_alflow(allrmr_value) Then ' se non connesso scrivo zero o allarme di flusso
                valore_canale_temp = 0
                canale_allarme = False
            End If
            If canale_allarme Then ' canale in allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action red"">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            Else ' canale in non allarme
                intestazione = intestazione + "<div Class=""list-group-item list-group-item-action "">" + label_canale_temp + "<strong>" + valore_canale_temp.ToString + "</strong></div>"
            End If
        Next
        intestazione = intestazione + "</div><a href=""" + href + """ class=""btn btn-block gggggggg"">Vai all'impianto</a>"
        intestazione = intestazione + "</div></div></div>"
        'filtri
        'aaaaaaaa da sostituire con impiantoacceso
        'bbbbbbbb da sostituire con impiantospento
        'cccccccc da sostituire con allarme
        If Not check_connected Then ' non connesso
            intestazione = intestazione.Replace("aaaaaaaa", "")
            intestazione = intestazione.Replace("bbbbbbbb", "impiantospento")
            intestazione = intestazione.Replace("cccccccc", "")
            'dddddddd da sostituire con colore 
            intestazione = intestazione.Replace("dddddddd", "red") ' se non connesso è rosso
            'eeeeeeee da sostituitre  mdi-alert-octagon se disconnesso mdi-check-decagram se connesso
            intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon") ' se non connesso è rosso
            'ffffffff da sostituire con eventuale stato di non connessione o allarme di flusso
            intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-power-plug-off""></i>" + not_connected_traduzione + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
            'gggggggg colore del pulsante vai allimpianto
            intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

        Else
            intestazione = intestazione.Replace("aaaaaaaa", "impiantoacceso")
            intestazione = intestazione.Replace("bbbbbbbb", "")
            If check_alarm_general Or main_function.alarm_lds_flusso(allrmr_value) Then
                intestazione = intestazione.Replace("cccccccc", "allarme")
                intestazione = intestazione.Replace("dddddddd", "red")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-alert-octagon")
                If main_function.alarm_lta_alflow(allrmr_value) Then
                    Dim statoHtmlTesto As String = ""
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
                    If ore_flow = 0 Then
                        statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If
                    intestazione = intestazione.Replace("ffffffff", "<div Class=""list-group-item list-group-item-action""><i class=""mdi mdi-stack-overflow""></i>" + statoHtmlTesto + "<span class=""badge badge-red badge-pill"">	<i class=""mdi mdi-arrow-down-bold white""></i></span></div>")
                Else
                    intestazione = intestazione.Replace("ffffffff", "")
                End If
                'gggggggg colore del pulsante vai allimpianto
                intestazione = intestazione.Replace("gggggggg", "btn-outline-danger")

            Else
                intestazione = intestazione.Replace("cccccccc", "")
                intestazione = intestazione.Replace("dddddddd", "green")
                intestazione = intestazione.Replace("eeeeeeee", "mdi-check-decagram")
                intestazione = intestazione.Replace("ffffffff", "")
                intestazione = intestazione.Replace("gggggggg", "btn-outline-primary")
            End If
        End If
        Return intestazione
    End Function
    Private Function getConfigFromFile(ByVal serialReference As String) As String
        If File.Exists("c:\centurio\" + serialReference + "_xml.txt") Then
            'Return XmlReader.Create(New StringReader(My.Computer.FileSystem.ReadAllText("c:\centurio\" + serialReference + "_xml.txt")))
            Return My.Computer.FileSystem.ReadAllText("c:\centurio\" + serialReference + "_xml.txt")
        End If
        Return ""
    End Function
    Private Function prepareJson(ByVal LstNodes As XmlNodeList, ByVal serialNumber As String, ByRef jsonVariableMainCanaleSonda As String, Optional ByVal filter As String = "") As String
        Dim jsonVariableMain As String = "["
        Dim virgolaJsonMain As String = ""
        Dim jsonVariableMainCanaleSondaTemp As String = "["
        Dim virgolaJsonMainCanaleSonda As String = ""
        Dim multiparameter As Boolean = False

        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList




            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                Dim LstNodesCanale As XmlNodeList

                If filter <> "" Then

                    Dim contiene As Boolean = False
                    Dim attributeDataConfig As XmlAttribute
                    attributeDataConfig = oXMLNodeSub.Attributes().ItemOf("channel")
                    If attributeDataConfig IsNot Nothing Then
                        Dim attributeDataConfigSplit() As String = attributeDataConfig.Value.Split("|")
                        Dim filterSplit() As String = filter.Split("|")
                        For Each v As String In attributeDataConfigSplit
                            If (v.IndexOf("-x") > 0) Or (v.IndexOf("-96") > 0) Then
                                v = v.Replace("x", "")
                                multiparameter = True
                                For Each v1 As String In filterSplit
                                    If v1.IndexOf("-23") < 0 Then ' controllo solo se non è presente il sensore di pressione differenziale
                                        If (v1.IndexOf(v) >= 0) Then
                                            If (v1.IndexOf("-96") >= 0) Then ' verifico se un laser
                                                If v1 = v Then
                                                    contiene = True
                                                    Exit For
                                                End If
                                            Else
                                                contiene = True
                                                Exit For
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                            If (filterSplit.ToList.IndexOf(v) >= 0 And multiparameter = False) Or v = "xx" Then
                                contiene = True
                            End If
                        Next
                        'foreach(QString v, nome){
                        '            If ((nomeFilter.indexOf(v) >= 0)||(v =="xx"))
                        '                contiene = True;
                        '        }
                        If Not contiene Then
                            GoTo nexLoopLabel
                        End If
                    End If
                End If
                LstNodesCanale = oXMLNodeSub.childNodes()
                Dim idProbe As String = ""
                Dim idGrandezza As String = ""
                Dim tipoCanale As String = ""
                Dim numeroSonda As String = ""
                Dim numeroSondaSTR As String = ""
                Dim jsonVariable As String = "["
                Dim virgolaJson As String = ""
                Dim pipeClient As New centurioRealTime
                Dim resultPipe As String = "pippo"
                'resultPipe = pipeClient.Main(split_codice(indiceCodice), "controller_type")

                For Each oXMLNodeCanale In LstNodesCanale
                    Dim attributeDataNodes As XmlAttribute
                    If (oXMLNodeCanale.name <> "#comment") Then
                        attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                        If (attributeDataNodes.Value = "probe") Then
                            idProbe = oXMLNodeCanale.InnerXml()
                        End If
                        If (attributeDataNodes.Value = "tipoCanale") Then ' se presente tipo canale vuol dire che non mi arriva la grandezza e unità di misura finite
                            tipoCanale = oXMLNodeCanale.InnerXml()
                            tipoCanale = pipeClient.Main(serialNumber, tipoCanale)
                            'tipoCanale = "5"
                        End If
                        If (attributeDataNodes.Value = "numeroSonda") Then ' se presente tipo canale vuol dire che non mi arriva la grandezza e unità di misura finite
                            numeroSondaSTR = oXMLNodeCanale.InnerXml()
                            numeroSonda = pipeClient.Main(serialNumber, numeroSondaSTR)
                            'numeroSonda = "24"
                        End If

                        If (attributeDataNodes.Value = "grandezza") Then
                            idGrandezza = oXMLNodeCanale.InnerXml()
                        End If
                        If (attributeDataNodes.Value = "alarm") Or (attributeDataNodes.Value = "livello") Then
                            Try
                                Dim labelGlobal As String = oXMLNodeCanale.Attributes().ItemOf("label").Value
                                jsonVariable = jsonVariable + virgolaJson + "{""variabile"":""" + oXMLNodeCanale.InnerXml() + """,""label"":""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + """}"
                            Catch ex As Exception
                                'jsonVariable = jsonVariable + virgolaJson + "{""variabile"":""" + oXMLNodeCanale.InnerXml() + """}"
                                jsonVariable = jsonVariable + virgolaJson + "{""variabile"":""" + oXMLNodeCanale.InnerXml() + """,""label"":""""}"
                            End Try
                            virgolaJson = ","
                        End If

                    End If
                Next
                jsonVariable = jsonVariable + "]"

                jsonVariableMain = jsonVariableMain + virgolaJsonMain + "{""chiaveG"":""" + idGrandezza + """,""chiaveP"":""" + idProbe + """, ""valore"":" + jsonVariable + "}"

                If ((tipoCanale <> "") And (numeroSonda <> "")) And ((tipoCanale <> "null") And (numeroSonda <> "null")) Then
                    Dim listDataSonda As Dictionary(Of String, String)
                    Try
                        listDataSonda = mainFunctionCenturio.getProbeList(tipoCanale, numeroSonda)
                        jsonVariableMainCanaleSondaTemp = jsonVariableMainCanaleSondaTemp + virgolaJsonMainCanaleSonda + "{""chiaveP"":""" + idProbe + """,""chiaveG"":""" + numeroSondaSTR + """,""grandezza"":""" + listDataSonda.Item("grandezza") + """, ""unitEu"":""" + listDataSonda.Item("unitEu") + """, ""unitUSA"":""" + listDataSonda.Item("unitUSA") + """, ""decimali"":""" + listDataSonda.Item("decimali") + """}"
                    Catch ex As Exception

                    End Try


                    virgolaJsonMainCanaleSonda = ","
                End If

                virgolaJsonMain = ","

                'intestazione = intestazione + "<div Class=""span2""> <span Class=""unita alarm"" id=""" + split_codice(indiceCodice) + "_" + idGrandezza + """ >mS</span>"
                'intestazione = intestazione + "<span Class=""misura alarm"" id=""" + split_codice(indiceCodice) + "_" + idProbe + """>0</span></div>"
nexLoopLabel:
            Next
            jsonVariableMain = jsonVariableMain + "]"
            jsonVariableMainCanaleSonda = jsonVariableMainCanaleSondaTemp + "]"

        Next
        Return jsonVariableMain
    End Function
    Private Function prepareJsonAreaInOutAlarm(ByVal LstNodes As XmlNodeList, ByVal serialNumber As String, ByRef jsonVariableMainCanaleSonda As String, Optional ByVal filter As String = "") As String
        Dim jsonVariable As String = "["
        Dim virgolaJson As String = ""
        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList
            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                Dim attributeDataConfig As XmlAttribute
                attributeDataConfig = oXMLNodeSub.Attributes().ItemOf("type")
                If attributeDataConfig IsNot Nothing Then
                    If attributeDataConfig.Value = "alarm" Then
                        jsonVariable = jsonVariable + virgolaJson + "{""variabile"":""" + oXMLNodeSub.InnerXml() + """,""label"":""" + oXMLNodeSub.Attributes().ItemOf("label").Value + """}"
                        virgolaJson = ","
                    End If
                End If
            Next
        Next
        jsonVariable = jsonVariable + "]"
        Return jsonVariable
    End Function

End Class