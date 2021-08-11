Imports System.Xml
Imports System.IO

Public Class dashboardNew
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub dashboardNew_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
        Dim intestazione As String = ""
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
        Dim scriptCenturioReal As String = "var serialNumber='';var stringJson='';var stringGlobal='';var nomeLabel='';var stringDecimal='';var stringLabel=''; var resultPipe='';var resultConfigurationInput='';var stringJsonGlobalInputOutput ='';"

        Dim time_connessione_min As Long = 0
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
            If listData.ContainsKey(split_impianto(0)) = True Then
                listData(split_impianto(0)) = listData.Item(split_impianto(0)) + split_impianto(1) + ">"
                listDataCode(split_impianto(0)) = listDataCode.Item(split_impianto(0)) + dc.identificativo + ">"
            Else
                listData.Add(split_impianto(0), split_impianto(1) + ">")
                listDataCode.Add(split_impianto(0), dc.identificativo + ">")
            End If
        Next

        For Each chiave In listData
            '
            prima_volta = True

            intestazione = intestazione + "<div class=""row-fluid"">"
            intestazione = intestazione + "<div class=""span12"">"

            intestazione = intestazione + "<div class=""heading-buttons"" style=""  background-color: #575655; height: 50px;"">"
            intestazione = intestazione + "<h3 style=""color:#ffffff;padding-bottom:40px;"">" + chiave.Key + "</h3></div>"
            intestazione = intestazione + "<div class=""separator bottom""></div>"
            intestazione = intestazione + "<div class=""innerLR"">"


            Dim split_impianto() As String = chiave.Value.Split(">")
            Dim split_codice() As String = listDataCode.Item(chiave.Key).Split(">")
            Dim indiceCodice As Integer = 0
            Dim calcoloRiga As Integer = 0
            For Each subImpinato In split_impianto
                If subImpinato <> "" Then
                    ' start impianto
                    If calcoloRiga >= 2 And calcoloRiga Mod 2 = 0 Then
                        intestazione = intestazione + "</div>" ' end row-fluid"" style=""background:#575655;height:50px;
                    End If
                    If calcoloRiga Mod 2 = 0 Then
                        intestazione = intestazione + "<div Class=""row-fluid"" >"
                    End If
                    If split_impianto.Length = 2 Then
                        intestazione = intestazione + "<div class=""span12"">"
                    Else
                        intestazione = intestazione + "<div class=""span6"">"
                    End If

                    intestazione = intestazione + "<div class=""widget"">"
                    intestazione = intestazione + "<div class=""navbar main "" style=""height:46px""><div class=""impianto"">" + subImpinato + "</div></div>"

                    ' start gruppo strumento impianto
                    'intestazione = intestazione + " < div Class=""row-fluid regular-gray"">"
                    If split_codice(indiceCodice).Length < 17 Then


                        For Each dc1 In tabella_strumento
                            ' start  strumento impianto
                            'intestazione = intestazione + "<div Class=""span2"" style=""padding:10px;"">"
                            Try
                                If dc1.codice = split_codice(indiceCodice) Then
                                    intestazione = intestazione + lettura_canali(contatore_strumenti, dc1, GetGlobalResourceObject("impianto_global", "gestisci_parametri"), GetGlobalResourceObject("impianto_global", "no_connected"), GetGlobalResourceObject("impianto_global", "last_update"), GetGlobalResourceObject("impianto_global", "no_flow"), GetGlobalResourceObject("impianto_global", "flow_ok"), check_alarm_general, check_connected, nome_impianto, time_connessione_min)
                                End If
                            Catch ex As Exception

                            End Try
                            'intestazione = intestazione + "</div>" ' end span2 ;
                            ' end   strumento impianto
                        Next
                    Else
                        'verifica se è pompa o centurio
                        Dim typeStrumento As Integer = 0
                        For Each dc In tabella_impianto
                            If dc.identificativo = split_codice(indiceCodice) Then
                                typeStrumento = dc.Expr2
                            End If
                        Next
                        If typeStrumento = 0 Then
                            Dim mainFunctionConfig As String = mainFunctionCenturio.getConfigCentrurio(split_codice(indiceCodice))
                            Dim tabella_centurio As ermes_web_20.centurioQuery.centurioConfigDataTable
                            Dim query As New query
                            'Dim querydb As New queryDB



                            'If mainFunctionConfig <> "null" Then ' null sta ad identificare non connesso altrimenti ho il codice
                            Dim pipeClient As New centurioRealTime
                            Dim resultPipe As String = ""
                            Dim resultConfigurationInput As String = ""
                            Dim sistemaUSA As String = ""
                            resultPipe = pipeClient.Main(split_codice(indiceCodice), "controller_type")

                            'MsgBox(resultPipe)
                            If resultPipe <> "null" And resultPipe <> "" Then

                                resultPipe = resultPipe
                                resultConfigurationInput = pipeClient.Main(split_codice(indiceCodice), "configurationFinal")
                                sistemaUSA = pipeClient.Main(split_codice(indiceCodice), "sistemaUSA")
                                If sistemaUSA = "true" Then
                                    sistemaUSA = "1"
                                Else
                                    sistemaUSA = "0"
                                End If
                                'tabella_centurio = query.getRuntimeSchema("OSIN01")

                            Else
                                'Dim strinxXML As String = query.getConfigGlobal(1)
                                Dim strinxXML As String = getConfigFromFile(split_codice(indiceCodice))
                                sistemaUSA = "0"
                                'resultPipe = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 2)
                                If (strinxXML <> "") Then
                                    resultPipe = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 2)
                                    'resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 3)
                                    resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 3)
                                    'MsgBox(resultPipe + " " + resultConfigurationInput)
                                Else
                                    strinxXML = query.getConfigGlobal(1)
                                    resultPipe = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 2)
                                    resultConfigurationInput = mainFunctionCenturio.getFileInfoXML(split_codice(indiceCodice), strinxXML, 3)
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
                            intestazione = intestazione + "<a href=""mainCenturio.aspx?serial=" + split_codice(indiceCodice) + "&codice=" + resultPipe + "&sistemaUSA=" + sistemaUSA + "&configuration=" + resultConfigurationInput + """ Class=""block"">"

                            listCenturio.Add("mainCenturio.aspx?serial=" + split_codice(indiceCodice) + "&codice=" + resultPipe + "&sistemaUSA=" + sistemaUSA + "&configuration=" + resultConfigurationInput)


                            intestazione = intestazione + "<div class=""row-fluid"" id=""" + split_codice(indiceCodice) + "_main""" + "></div>"

                            intestazione = intestazione + "</a>"

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

                                jsonVariableMain = prepareJson(LstNodes, split_codice(indiceCodice), stringJsonDecimalTemp, resultConfigurationInput)
                                stringJson = stringJson + jsonVariableMain + "}"
                                stringJsonDecimal = stringJsonDecimal + stringJsonDecimalTemp + "}"

                                LstNodes = oXMLDoc.GetElementsByTagName("areaglobal")
                                jsonVariableMain = prepareJson(LstNodes, split_codice(indiceCodice), stringJsonDecimalTemp)
                                stringJsonGlobal = stringJsonGlobal + jsonVariableMain + "}"

                                LstNodes = oXMLDoc.GetElementsByTagName("areainout")
                                jsonVariableMain = prepareJsonAreaInOutAlarm(LstNodes, split_codice(indiceCodice), stringJsonDecimalTemp)
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


                                javaScriptLiteral.Text = javaScriptLiteral.Text + "get_data('" + split_codice(indiceCodice) + "','" + stringJson + "','" + stringJsonGlobal + "','" + dc1.nomeStrumento + "','" + stringJsonDecimal + "','" + stringJsonLabel + "','" + resultPipe + "','" + resultConfigurationInput + "','" + stringJsonGlobalInputOutput + "','" + sistemaUSA + "');"
                                scriptCenturioReal = scriptCenturioReal + "serialNumber = '" + split_codice(indiceCodice) + "';" + "stringJson='" + stringJson + "';" + "stringGlobal='" + stringJsonGlobal + "';" + "stringLabel='" + stringJsonLabel + "';" + "nomeLabel='" + dc1.nomeStrumento + "';" + "resultPipe='" + resultPipe + "';" + "resultConfigurationInput='" + resultConfigurationInput + "';" + "stringJsonGlobalInputOutput='" + stringJsonGlobalInputOutput + "';" + "sistemaUSA='" + sistemaUSA + "';" +
                                        "stringDecimal='" + stringJsonDecimal + "';get_data(serialNumber,stringJson,stringGlobal,nomeLabel,stringDecimal,stringLabel,resultPipe,resultConfigurationInput,stringJsonGlobalInputOutput,sistemaUSA);"
                            Next
                        Else 'strumenti e pompe di nuova comunicazione
                            Select Case typeStrumento
                                Case 1 ' pompa prisma
                                    intestazione = intestazione + "<div class=""row-fluid"" id=""" + split_codice(indiceCodice) + "_pump"" >"
                                    'intestazione = intestazione + "<script type = ""text/javascript"" src=""pompe/pumpsCommunication.js?v=1.8""></script>"
                                    intestazione = intestazione + "<h1 id =""messageStart" + split_codice(indiceCodice) + """></h1>"
                                    intestazione = intestazione + "<script type = ""text/javascript"" >"
                                    intestazione = intestazione + "var NarrayReadRealTime = [1];"
                                    intestazione = intestazione + "var NserialNumber = """ + split_codice(indiceCodice) + """;"
                                    intestazione = intestazione + "var NarrayReadSetpoint = [2, 3, 4, 5, 6];console.log(""carico i dati"");"
                                    intestazione = intestazione + "var Pompa" + split_codice(indiceCodice) + " = new OggettoPompa({serialNumber:NserialNumber, arrayReadRealTime:NarrayReadRealTime, arrayReadSetpoint:NarrayReadSetpoint});"
                                    intestazione = intestazione + "Pompa" + split_codice(indiceCodice) + ".createConnection();"
                                    'intestazione = intestazione + "setTimeout(Pompa" + split_codice(indiceCodice) + ".createConnection,20000);"

                                    intestazione = intestazione + "</script>"
                                    intestazione = intestazione + "</div>"

                                Case 2
                            End Select


                        End If





                        ' intestazione = intestazione + "</a>"


                        'End If

                        'intestazione = intestazione + "</div>"
                        'intestazione = intestazione + "</div>"

                        'intestazione = intestazione + "</div>" ' end row-fluid regular-gray

                    End If

                        intestazione = Replace(intestazione, "$", "&statistica=" + (contatore_strumenti).ToString + "," + (contatore_strumenti_disconnected).ToString + "," + (contatore_strumenti_allarme).ToString)

                    'intestazione = intestazione + "</div>" ' end row-fluid regular-gray ;
                    ' end  gruppo strumento impianto

                    intestazione = intestazione + "</div>" ' end widget ;
                    intestazione = intestazione + "</div>" ' end span6 ;
                    'fine impianto
                    calcoloRiga = calcoloRiga + 1

                End If
                indiceCodice = indiceCodice + 1
            Next

            intestazione = intestazione + "</div>" ' end row-fluid"" style=""background:#575655;height:50px;
            intestazione = intestazione + "</div>" ' end innerLR;
            intestazione = intestazione + "</div>" ' end row-fluid;

            'stringaResult = stringaResult + chiave.Key + ":" + chiave.Value + "$"
        Next

        Label1.Text = intestazione

        If comunicazioni = "" Then
            Literal_script.Text = ""
        Else
            Literal_script.Text = "<script>$(function(){$('#content-notification').notyfy({text:'"
            Literal_script.Text = Literal_script.Text + comunicazioni
            Literal_script.Text = Literal_script.Text + "',type:       'error',layout:     'top',closeWith: ['click']});});</script>"
        End If
        If prima_volta = False Then
            If Session("super_user") Then
                impianti_yes.Visible = False
                impianti_no.Visible = True
            Else
                impianti_yes.Visible = False
                impianti_no.Visible = False

            End If

        End If
        javaScriptLiteral.Text = javaScriptLiteral.Text + "setInterval(explode, 4000);function explode() {" + scriptCenturioReal + "};"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "</script>"
        Session.Remove("centurioList")
        Session("centurioList") = listCenturio

    End Sub
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

    Public Function lettura_canali(ByVal numero_strumenti As Integer, ByVal riga As ermes_web_20.quey_db.strumentiRow,
                                    ByVal gestisci_parametri_traduzione As String,
                                    ByVal not_connected_traduzione As String, ByVal last_update_traduzione As String,
                                   ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                                   ByRef check_alarm_general As Boolean, ByRef check_connected As Boolean, ByVal nome_impanto As String, ByRef time_connessione_min As Long) As String
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
        'If numero_strumenti Mod 3 = 0 Then
        '    intestazione = intestazione + "<div class=""row-fluid"">"
        'End If


        'intestazione = intestazione + "<div class=""span4"">"
        'intestazione = intestazione + "<div class=""widget"">"
        'intestazione = intestazione + "<div class=""""><span style=""text-align:right;color:#000;width:100%;position:absolute;right:10px;"">" + id_strumento + " </span><h3 class=""heading-arrow"">" + tipo_strumento_label + "</h3><span></span></div>"
        'intestazione = intestazione + "<div class=""widget-body"">"
        'intestazione = intestazione + "<table class=""table table-bordered table-condensed table-striped table-primary table-vertical-center checkboxs"">"
        'intestazione = intestazione + "<tbody>"
        'gestione items
        Select Case tipo_strumento
            Case "max5" 'Replace(nome_impanto, " ", "£") 


                href = "max5.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"

                intestazione = intestazione + items_max5(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
            Case "LDtower"
                href = "ldtower.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_tower(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, tipo_strumento)
                intestazione = intestazione + "</a>"

            Case "Tower"
                href = "tower.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_tower(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general, tipo_strumento)
                intestazione = intestazione + "</a>"
                'items_tower(riga, check_connected)
            Case "LD"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_ld(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
                'items_ld(riga, check_connected)
            Case "LDDT"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_lddt(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
                'items_ld(riga, check_connected)
            Case "LDD4"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_ld(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
                'items_ld(riga, check_connected)
            Case "LDMA"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=45&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_ld_ma(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
            Case "LDLG"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=58&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_ld_lg(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"

            Case "LDS"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_lds(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
                'items_lds(riga, check_connected)
            Case "LD4"
                href = "ld.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_ld4(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
            Case "WD"
                href = "wd.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_wd(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"

            Case "WH"
                href = "wd.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_wd(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"

            Case "LTB"
                href = "ltb.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_ltb(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
            Case "LTA"
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"

            Case "LTD"
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"

            Case "LTU"
                href = "lta.aspx?codice=" + riga.codice + "&id_485=" + riga.id_485 + "&pagina=0&result=0&nome_impianto=" + nome_impanto + "$" 'il $ sara rimpiazzato (replace)  con i dati statistici dell'impianto
                intestazione = intestazione + "<a href=""" + href + """ Class=""block"">"
                intestazione = intestazione + items_lta(riga, check_connected, last_update_traduzione, time_connected, not_connected_traduzione, noflow_traduzione, flow_ok_traduzione, check_alarm_general)
                intestazione = intestazione + "</a>"
        End Select
        'end gestione items

        'intestazione = intestazione + "</tbody>"
        'intestazione = intestazione + "</table>"

        'intestazione = intestazione + "<br>"
        'intestazione = intestazione + "<span class=""btn btn-block btn-default""><a href=""" + href + """>" + gestisci_parametri_traduzione + "</a></span>"
        'intestazione = intestazione + "</div>"
        'intestazione = intestazione + "</div>"
        'intestazione = intestazione + "</div>"
        'If (numero_strumenti + 1) Mod 3 = 0 Then

        '    intestazione = intestazione + "<$$$$$$$$$$>"


        'End If
        Return intestazione
    End Function


    Public Function items_tower(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                       ByVal last_update_traduzione As String, ByVal time_connected As Long,
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
                       ByRef check_alarm_general As Boolean, ByVal tipo_strumento As String) As String
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
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        config_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        allrmr_value = main_function.get_split_str(riga.value3)
        unit_value = main_function.get_split_str(riga.value1)
        main_function_config.chek_tower_version(riga.nome, version_str, personalizzazione_aquacare)

        check_alarm_general = False

        configurazione_canali = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)

        numero_canali = configurazione_canali.Split("_").Length

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


        For i = 1 To numero_canali 'Tower può essere uno, due o tre canali

            'intestazione = intestazione + "<td class=""center"">"

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
                    If valore_canale_temp > scala_temp Or valore_canale_temp < 0 Then
                        valoreCanalestr = "*****"
                    Else
                        valoreCanalestr = valore_canale_temp.ToString
                    End If
                    If main_function.alarm_tower_bleed_timeout(allrmr_value) Or main_function.alarm_tower_high_conductivity(allrmr_value) _
                        Or main_function.alarm_tower_low_conductivity(allrmr_value) Or main_function.alarm_tower_level_prebiocide1(allrmr_value) _
                        Or main_function.alarm_tower_level_biocide1(allrmr_value) Or main_function.alarm_tower_level_prebiocide2(allrmr_value) _
                        Or main_function.alarm_tower_level_biocide2(allrmr_value) Or main_function.alarm_tower_level_inhibitor(allrmr_value) Then
                        check_alarm_general = True
                        canale_allarme = True
                        intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                        intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valoreCanalestr + "</span></div>"
                    Else
                        intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                        intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valoreCanalestr + "</span></div>"

                        canale_allarme = False
                    End If

                Case 2 'controllo canale 2
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, ,
                                                                  fattore_divisione_temp, , scala_temp, , , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 11, 4)) / fattore_divisione_temp
                    Dim valoreCanalestr As String = ""
                    If valore_canale_temp > scala_temp Or valore_canale_temp < 0 Then
                        valoreCanalestr = "*****"
                    Else
                        valoreCanalestr = valore_canale_temp.ToString
                    End If

                    If main_function.alarm_tower_level_ch2(allrmr_value) Or main_function.alarm_tower_ch2_low(allrmr_value) _
                        Or main_function.alarm_tower_ch2_high(allrmr_value) Then
                        check_alarm_general = True
                        intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                        intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valoreCanalestr + "</span></div>"
                        canale_allarme = True
                    Else
                        intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                        intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valoreCanalestr + "</span></div>"
                        canale_allarme = False
                    End If
                Case 3 'controllo canale 3
                    main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , ,
                                                                  fattore_divisione_temp, , , scala_temp, , , label_canale_temp)
                    valore_canale_temp = Val(Mid(valuer_value(0), 15, 4)) / fattore_divisione_temp
                    Dim valoreCanalestr As String = ""
                    If valore_canale_temp > scala_temp Or valore_canale_temp < 0 Then
                        valoreCanalestr = "*****"
                    Else
                        valoreCanalestr = valore_canale_temp.ToString
                    End If


                    If main_function.alarm_tower_level_ch3(allrmr_value) Or main_function.alarm_tower_ch3_low(allrmr_value) _
                        Or main_function.alarm_tower_ch3_high(allrmr_value) Then
                        check_alarm_general = True
                        intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                        intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valoreCanalestr + "</span></div>"

                        canale_allarme = True
                    Else
                        intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                        intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valoreCanalestr + "</span></div>"

                        canale_allarme = False
                    End If
            End Select




        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = valuer_value(0).IndexOf("value")
        Dim temperature_value As Single = 0



        temperature_value = (Val(Mid(valuer_value(0), 7, 4)))


        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If Val(Mid(unit_value(0), 3, 1)) Then        'IS
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
        End If
        If Val(Mid(unit_value(0), 4, 1)) Then        'US
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
        End If
        intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value / 10).ToString + "</span></div>"


        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        ' end visualizzazione temperatura



        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False


        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else
            Dim integer_item As Integer = 0

            If main_function.alarm_tower_flow(allrmr_value) Or main_function.alarm_tower_wmb(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_wmi(allrmr_value, configurazione_canali, True) Or main_function.alarm_tower_cf(allrmr_value, configurazione_canali, True) Then
                checkAlarm = True
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
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"

            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

        End If


        'If check_connected Then ' se true vuol dire che è connesso
        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        'Else
        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        'End If


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
    Public Function items_wd(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 2
        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


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

            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
            End If

        Next
        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        ' end visualizzazione temperatura
        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_wd_flusso(allrmr_value) Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

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
    Public Function items_lds(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False
        numero_canali = 1

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"

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


            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
            End If


        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String


        temperature_value = (Val(Mid(valuer_value(2), 1, 3)))
        formato_data = Mid(valuer_value(3), 1, 1)

        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Then ' europeo
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value / 10).ToString + "</span></div>"
        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value).ToString + "</span></div>"
        End If


        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        ' end visualizzazione temperatura
        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_lds_flusso(allrmr_value) Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

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
    Public Function items_ld_lg(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                   ByVal last_update_traduzione As String, ByVal time_connected As Long,
                   ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        setpntr_value = main_function.get_split_str(riga.value7)

        check_alarm_general = False
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


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



            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                If (i <= numero_canali) Then
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "L</span></div>"
                Else
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "m3</span></div>"
                End If

            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                If (i <= numero_canali) Then
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "L</span></div>"
                Else
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "m3</span></div>"
                End If

            End If


        Next
        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"


        Else


            intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
            intestazione = intestazione + "<div Class=""row-fluid"">"
            If check_alarm_general Then
                intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
            Else
                intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
            End If
            intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

            intestazione = intestazione + "</div>"
            intestazione = intestazione + intestazioneTemp
            intestazione = intestazione + "</div>" ' end row-fluid regular-gray


        End If
        ' valore canale ok

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

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


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
            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
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
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value / 10).ToString + "</span></div>"
        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value).ToString + "</span></div>"

        End If


        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"




        ' end visualizzazione temperatura
        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_ld_flusso(allrmr_value) Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

        End If




        'If check_connected Then ' se true vuol dire che è connesso
        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        'Else
        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        'End If
        'If main_function.alarm_ld_flusso(allrmr_value) Then
        '    check_alarm_general = True
        '    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
        '    If ore_flow = 0 Then
        '        intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
        '    Else
        '        intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
        '    End If
        'Else

        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        'End If
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
        Dim intestazioneTemp As String = ""

        Dim ore_flow As Integer = 0
        Dim minuti_flow As Integer = 0
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If


        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 2

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"



        For i = 1 To numero_canali 'ld può essere duo o tre canali

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


            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
            End If

        Next

        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String


        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)


        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"

        If formato_data = "0" Then ' europeo
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value / 10).ToString + "</span></div>"
        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + (temperature_value).ToString + "</span></div>"
        End If



        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_lddt_flusso(allrmr_value) Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

        End If

        ' end visualizzazione temperatura
        'If check_connected Then ' se true vuol dire che è connesso
        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + last_update_traduzione + " " + Str(time_connected) + "</td></tr>"
        'Else
        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + not_connected_traduzione + "</td></tr>"
        'End If
        'If main_function.alarm_ld_flusso(allrmr_value) Then
        '    check_alarm_general = True
        '    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)
        '    If ore_flow = 0 Then
        '        intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(minuti_flow) + " min" + "</h4></td>"
        '    Else
        '        intestazione = intestazione + "<tr><td colspan=""2"" class=""center"" style=""border-color: #e04545; background-color: #e04545; text-align:center; 	""><h4 style=""color:white;"">" + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min" + "</h4></td>"
        '    End If
        'Else

        '    intestazione = intestazione + "<tr><td colspan=""2"" class=""center"">" + flow_ok_traduzione + "</td></tr>"
        'End If
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
    Public Function items_ld_ma(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                       ByVal last_update_traduzione As String, ByVal time_connected As Long,
                       ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String,
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
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        Dim tipo_strumento_label As String = ""
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        setpntr_value = main_function.get_split_str(riga.value7)

        check_alarm_general = False
        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


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

            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"

            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
            End If

        Next
        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"


        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"


        Else


            intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
            intestazione = intestazione + "<div Class=""row-fluid"">"
            If check_alarm_general Then
                intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
            Else
                intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
            End If
            intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

            intestazione = intestazione + "</div>"
            intestazione = intestazione + intestazioneTemp
            intestazione = intestazione + "</div>" ' end row-fluid regular-gray


        End If
        ' valore canale ok

        Return intestazione

    End Function

    Public Function items_ltb(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
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
        Dim tipo_strumento_label As String = ""
        Dim intestazioneTemp As String = ""

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
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



        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"

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



            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                ' Andrea Manetta 03-10-18 intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
                ' Andrea Manetta 03-10-18 

                If i = 3 And numero_canali = 3 Then
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(79, fattore_divisione_temp)  ' Andrea Manetta  03-10-18 

                    If (Mid(valuer_value(8), 1, 1)) = 0 Then
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + " " + "</span></div>"
                    Else
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
                    End If
                Else
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp) ' Andrea Manetta  03-10-18 

                    If (Mid(valuer_value(i + 4), 1, 1)) = 1 Then
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + " " + "</span></div>"
                    Else
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
                    End If

                End If

            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                ' Andrea Manetta 03-10-18   intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"


                If i = 3 And numero_canali = 3 Then
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(79, fattore_divisione_temp)  ' Andrea Manetta  03-10-18 

                    If (Mid(valuer_value(8), 1, 1)) = 0 Then
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + " " + "</span></div>"
                    Else
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
                    End If
                Else
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp) ' Andrea Manetta  03-10-18 

                    If (Mid(valuer_value(i + 4), 1, 1)) = 1 Then
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + " " + "</span></div>"
                    Else
                        intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
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
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">°C</span>"
            ' Andrea Manetta 03-10-18  intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + (temperature_value / 10).ToString + "</span></div>"

            ' Andrea Manetta 03-10-18 
            If (Mid(valuer_value(7), 1, 1)) = 1 Then
                intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + " " + "</span></div>"
            Else
                intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + (temperature_value / 10).ToString + "</span></div>"
            End If


        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + (temperature_value).ToString + "</span></div>"

            ' Andrea Manetta 03-10-18 
            If (Mid(valuer_value(7), 1, 1)) = 1 Then
                intestazioneTemp = " "
            End If

        End If

        ' end visualizzazione temperatura
        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        ' end visualizzazione temperatura
        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_ltb_flow(allrmr_value) Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

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



    Public Function items_lta(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
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
        Dim tipo_strumento_label As String = ""
        Dim intestazioneTemp As String = ""

        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 2
        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


        For i = 1 To numero_canali 'ld può essere duo o tre canali

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

            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
            End If

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String


        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
        formato_data = Mid(valuer_value(4), 1, 1)

        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Or formato_data = "1" Or formato_data = "3" Then ' europeo
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
            intestazioneTemp = intestazioneTemp + "<span class=""misura"">" + (temperature_value / 10).ToString + "</span></div>"


        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span class=""misura"">" + (temperature_value).ToString + "</span></div>"

        End If

        ' end visualizzazione temperatura
        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"


        ' end visualizzazione temperatura
        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_lta_alflow(allrmr_value) Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

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



    Public Function items_ld4(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
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
        Dim tipo_strumento_label As String = ""
        Dim intestazioneTemp As String = ""
        Dim id_strumento As String = main_function.get_str_id(riga.nome.ToString)
        If main_function.get_lebel_485(riga.nome.ToString) = "" Then
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento)
        Else
            tipo_strumento_label = main_function.get_tipo_strumento(riga.tipo_strumento) + " - " + main_function.get_lebel_485(riga.nome.ToString)
        End If

        calibrz_value = main_function.get_split_str(riga.value4)
        valuer_value = main_function.get_split_str(riga.value2)
        config_value = main_function.get_split_str(riga.value1)
        allrmr_value = main_function.get_split_str(riga.value3)
        check_alarm_general = False


        numero_canali = 5

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"


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



            If canale_allarme Then ' canale in allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
            Else ' canale in non allarme
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
            End If

        Next
        ' visualizzazione temperatura
        Dim temperature_type As Integer = 0
        Dim temperature_value As Single = 0
        Dim formato_data As String


        temperature_value = (Val(Mid(valuer_value(5), 1, 3)))
        formato_data = Mid(valuer_value(6), 1, 1)

        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If formato_data = "0" Then ' europeo
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
            intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + (temperature_value / 10).ToString + "</span></div>"
        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + (temperature_value).ToString + "</span></div>"

        End If
        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"


        ' end visualizzazione temperatura
        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span2"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else


            If main_function.alarm_ld4_flusso(allrmr_value) Or main_function.alarm_ld4_stby(allrmr_value) Then
                checkAlarm = True
                If main_function.alarm_ld4_flusso(allrmr_value) Then
                    main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                    If ore_flow = 0 Then
                        statoHtmlTesto = statoHtmlTesto + noflow_traduzione + " " + Str(minuti_flow) + " min"
                    Else
                        statoHtmlTesto = statoHtmlTesto + noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                    End If

                End If
                If main_function.alarm_ld4_stby(allrmr_value) Then
                    statoHtmlTesto = statoHtmlTesto + " STBY "
                End If

                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

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
    Public Function items_max5(ByVal riga As ermes_web_20.quey_db.strumentiRow, ByVal check_connected As Boolean,
                               ByVal last_update_traduzione As String, ByVal time_connected As Long,
                               ByVal not_connected_traduzione As String, ByVal noflow_traduzione As String, ByVal flow_ok_traduzione As String _
                               , ByRef check_alarm_general As Boolean) As String
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
        End If


        config_value = main_function.get_split_str(riga.value1)
        alarm_value = main_function.get_split_str(riga.value2)
        flow_value = main_function.get_split_str(riga.value3)
        option_value = main_function.get_split_str(riga.value4)

        intestazioneTemp = intestazioneTemp + "<div Class=""row-fluid"">"
        intestazioneTemp = intestazioneTemp + "<div Class=""span12"">"

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
                If canale_allarme Then ' canale in allarme

                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">HClO</span>"
                    intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
                Else ' canale in non allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">HClO</span>"
                    intestazioneTemp = intestazioneTemp + "<span class=""misura""" + valore_canale_temp.ToString + "</span></div>"
                End If

                valore_canale_temp = Val(Mid(alarm_value(i), 3, 4)) / fattore_divisione_temp ' cloro libero


            End If
            If label_canale_temp <> "" Then


                If canale_allarme Then ' canale in allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                    intestazioneTemp = intestazioneTemp + "<span class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
                Else ' canale in non allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                    intestazioneTemp = intestazioneTemp + "<span class=""misura "">" + valore_canale_temp.ToString + "</span></div>"
                End If


            End If
            If main_function.get_tipo_personalizzazione(riga.nome) = "seiCanali" And i = 3 Then
                label_canale_temp = "Clt"
                valore_canale_temp = Val(Mid(alarm_value(13), 3, 4)) / fattore_divisione_temp
                If canale_allarme Then ' canale in allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
                Else ' canale in non allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
                End If


                label_canale_temp = "ClCom"
                valore_canale_temp = Val(Mid(alarm_value(4), 3, 4)) / fattore_divisione_temp
                If canale_allarme Then ' canale in allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita alarm"">" + label_canale_temp + "</span>"
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura alarm"">" + valore_canale_temp.ToString + "</span></div>"
                Else ' canale in non allarme
                    intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">" + label_canale_temp + "</span>"
                    intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + valore_canale_temp.ToString + "</span></div>"
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

        If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
            temperature_value = Val(main_function_config.get_temperature_infoDoppiaPiscina(flow_value(3), temperature_value1, temperature_type))
            temperatureIntestazione = "T1:"
        End If
        'intestazione = intestazione + "<td class=""center""><h4>" + "  " + "</h4></td>"
        If temperature_type = 0 Then 'temperatura in celsius
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + temperatureIntestazione + temperature_value.ToString + "</span></div>"
        Else
            intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
            intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + temperatureIntestazione + temperature_value.ToString + "</span></div>"
        End If
        If main_function.get_tipo_personalizzazione(riga.nome) = "doppiaPiscina" Then
            If temperature_type = 0 Then 'temperatura in celsius
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°C</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + temperature_value1.ToString + "</span></div>"
            Else
                intestazioneTemp = intestazioneTemp + "<div class=""span2""> <span class=""unita"">°F</span>"
                intestazioneTemp = intestazioneTemp + "<span Class=""misura"">" + temperature_value1.ToString + "</span></div>"
            End If
        End If

        intestazioneTemp = intestazioneTemp + "</div>"
        intestazioneTemp = intestazioneTemp + "</div>"

        ' end visualizzazione temperatura





        Dim statoHtml As String = "regular-gray"
        Dim statoHtmlSpan As String = "span12 border"
        Dim statoHtmlTesto As String = ""
        Dim checkAlarm As Boolean = False

        If Not check_connected Then
            intestazione = intestazione + "<div class=""row-fluid notconnected"">"
            intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
            intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + not_connected_traduzione + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
            intestazione = intestazione + "</div>"

            checkAlarm = True
        Else
            Dim integer_item As Integer = 0
            integer_item = main_function.alarm_max5_flow(alarm_value(10)) 'flusso
            If integer_item > 0 Then
                checkAlarm = True
                main_function.calcola_ore_minuti(riga.time_no_flow, ore_flow, minuti_flow)

                If ore_flow = 0 Then
                    statoHtmlTesto = noflow_traduzione + " " + Str(minuti_flow) + " min"
                Else
                    statoHtmlTesto = noflow_traduzione + " " + Str(ore_flow) + " h" + " " + Str(minuti_flow) + " min"
                End If
                intestazione = intestazione + "<div class=""row-fluid noflow"">"
                intestazione = intestazione + "<div Class=""span8""><span class=""idnumero"">" + id_strumento + " </span><span Class=""strumento"">" + tipo_strumento_label + "</span></div>"
                intestazione = intestazione + "<div Class=""span4""><span class=""strumento"">" + statoHtmlTesto + "</span><span class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"
                intestazione = intestazione + "</div>"
            Else ' strumento non in allarme di flusso
                intestazione = intestazione + "<div class=""row-fluid regular-gray"">"
                intestazione = intestazione + "<div Class=""row-fluid"">"
                If check_alarm_general Then
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome alarm"">" + tipo_strumento_label + "</span>"
                Else
                    intestazione = intestazione + "<div Class=""span12 border""><span class=""idnumero"">" + id_strumento + " </span><span Class=""nome"">" + tipo_strumento_label + "</span>"
                End If
                intestazione = intestazione + "<span Class=""pull-right"" style=""margin-right: 10px;""><h4 class=""glyphicons single circle_arrow_right""><i></i></h4></span></div>"

                intestazione = intestazione + "</div>"
                intestazione = intestazione + intestazioneTemp
                intestazione = intestazione + "</div>" ' end row-fluid regular-gray
            End If

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

    Private Function getConfigFromFile(ByVal serialReference As String) As String
        If File.Exists("c:\centurio\" + serialReference + "_xml.txt") Then
            'Return XmlReader.Create(New StringReader(My.Computer.FileSystem.ReadAllText("c:\centurio\" + serialReference + "_xml.txt")))
            Return My.Computer.FileSystem.ReadAllText("c:\centurio\" + serialReference + "_xml.txt")
        End If
        Return ""
    End Function

End Class
