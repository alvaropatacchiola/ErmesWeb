Imports System.Xml
Public Class mainCenturio
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim serial_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim sistemaUSA As String = ""
        Dim ConfigurationInput As String = ""
        serial_impianto = Page.Request("serial")
        codice_impianto = Page.Request("codice")
        sistemaUSA = Page.Request("sistemaUSA")
        ConfigurationInput = Page.Request("Configuration")
        If Not IsPostBack Then
            createCenturio(serial_impianto, codice_impianto, ConfigurationInput, sistemaUSA)
        End If
    End Sub


    Public Sub createCenturio(ByVal serialNumber As String, ByVal codice_impianto As String, ByVal filter As String, ByVal sistemaUSA As String)
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim tabella_centurio As ermes_web_20.centurioQuery.centurioConfigDataTable
        Dim riga_impianto As ermes_web_20.quey_db.impianto_newRow

        Dim query As New query
        Dim oXMLDoc As XmlDocument = New XmlDocument
        Dim oXMLDoc1 As XmlDocument = New XmlDocument
        Dim nomeImpiantoString As String = " "
        Dim referenteImpiantoString As String = " "
        Dim numeroTelefonoString As String = " "
        Dim indirizzoMailString As String = " "
        Dim strumentoTouch As Integer = 1
        Dim LstNodesTimer As XmlNodeList
        Dim numeroTimer As Integer = 0
        Dim indice As Integer = 1
        Dim labelTimer As String = ""
        Dim timerVariable As String = ""
        Dim identificativoUser As String = ""
        Dim setpointUserModify As String = ""
        tabella_centurio = query.getRuntimeSchema(codice_impianto)
        tabella_impianto = Master.tabella_impianto_container

        javaScriptLiteral.Text = "<script type=""text/javascript"">"

        'impostazione delle informazioni di base su account
        Try
            For Each dc In tabella_impianto
                If dc.identificativo = serialNumber Then
                    riga_impianto = dc
                    nomeImpiantoString = Replace(riga_impianto.nome_impianto, ">", " : ")
                    referenteImpiantoString = riga_impianto.referente
                    numeroTelefonoString = riga_impianto.telefono_referente
                    indirizzoMailString = riga_impianto.mail_referente
                    identificativoUser = riga_impianto.id_user
                    setpointUserModify = riga_impianto.modifica_setpoint_user1
                End If
            Next
        Catch ex As Exception

        End Try
        If nomeImpiantoString = "" Then
            nomeImpiantoString = "&nbsp"
        End If
        If referenteImpiantoString = "" Then
            referenteImpiantoString = "&nbsp"
        End If
        If numeroTelefonoString = "" Then
            numeroTelefonoString = "&nbsp"
        End If
        If indirizzoMailString = "" Then
            indirizzoMailString = "&nbsp"
        End If


        nomeImpianto.Text = nomeImpiantoString
        referenteImpianto.Text = referenteImpiantoString
        numeroTelefono.Text = numeroTelefonoString
        indirizzoMail.Text = indirizzoMailString
        codiceSeriale.Text = serialNumber
        dashboard.Text = GetGlobalResourceObject("centurio_global", "dashboard")
        ' javaScriptLiteral.Text = javaScriptLiteral.Text + "strumentoTouch = false;"

        'importo la lista sonde

        Dim listDataSonda As List(Of Dictionary(Of String, String))
        Dim jsonVariableMainCanaleSondaTemp As String = "{""variable"":["
        Dim virgolaJsonMainCanaleSonda As String = ""
        listDataSonda = mainFunctionCenturio.getProbeListAll()

        For Each elementList As Dictionary(Of String, String) In listDataSonda
            jsonVariableMainCanaleSondaTemp = jsonVariableMainCanaleSondaTemp + virgolaJsonMainCanaleSonda + "{""tipoCanale"":""" + elementList.Item("tipoCanale") + """, ""numeroSonda"":""" + elementList.Item("numeroSonda") + """, ""grandezza"":""" + elementList.Item("grandezza") + """, ""unitEu"":""" + elementList.Item("unitEu") + """, ""unitUSA"":""" + elementList.Item("unitUSA") + """,""minimo"":""" + elementList.Item("minimo") + """,""massimo"":""" + elementList.Item("massimo") + """, ""decimali"":""" + elementList.Item("decimali") + """}"
            virgolaJsonMainCanaleSonda = ","
        Next
        'jsonVariableMainCanaleSondaTemp = jsonVariableMainCanaleSondaTemp + virgolaJsonMainCanaleSonda + "{""chiaveP"":""" + idProbe + """,""chiaveG"":""" + numeroSondaSTR + """,""grandezza"":""" + listDataSonda.Item("grandezza") + """, ""unitEu"":""" + listDataSonda.Item("unitEu") + """, ""unitUSA"":""" + listDataSonda.Item("unitUSA") + """, ""decimali"":""" + listDataSonda.Item("decimali") + """}"



        jsonVariableMainCanaleSondaTemp = jsonVariableMainCanaleSondaTemp + "]}"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "var jsonParseDecimalStr ='" + jsonVariableMainCanaleSondaTemp + "'; var jsonParseDecimal= JSON.parse(jsonParseDecimalStr);"

        For Each dc1 In tabella_centurio

            oXMLDoc.LoadXml(dc1.configRuntime)
            'oXMLDoc1.LoadXml(dc1.configSetpoint)
            Dim LstNodes As XmlNodeList
            Dim jsonVariableMain As String = ""
            Dim stringJsonDecimalTemp As String = ""
            Dim listaAllarmiGlobalLabel As List(Of String) = New List(Of String)
            Dim listaAllarmiGlobal As List(Of String) = New List(Of String)
            LstNodes = oXMLDoc.GetElementsByTagName("areaglobal")
            disegnaHeader(LstNodes, dc1.nomeStrumento)
            listaAllarmiGlobal = getAllarmiGlobal(LstNodes, listaAllarmiGlobalLabel)
            LstNodes = oXMLDoc.GetElementsByTagName("areainout")
            disegnaPreCanale(LstNodes)

            LstNodes = oXMLDoc.GetElementsByTagName("areacanale")
            strumentoTouch = disegnaCanale(LstNodes, oXMLDoc.GetElementsByTagName("Istanza"), listaAllarmiGlobal, listaAllarmiGlobalLabel, filter, sistemaUSA)
            If (HttpContext.Current.Request.Url.Host.IndexOf("aquaprox") >= 0) Or (HttpContext.Current.Request.Url.Host.IndexOf("localhost") >= 0) Then
                setNameStrumento.Text = "<li id='labelCenturioR_li'  class='active' style='padding:17px'>OPTIMUS C10</li>"
            Else
                If (HttpContext.Current.Request.Url.Host.IndexOf("henkel") >= 0) Then
                    setNameStrumento.Text = "<li id='labelCenturioR_li'  class='active' style='padding:17px'>Eco - Flex</li>"
                Else
                    setNameStrumento.Text = "<li id='labelCenturioR_li'  class='active' style='padding:17px'>" + dc1.nomeStrumento + "</li>"
                End If

            End If


            LstNodesTimer = oXMLDoc.GetElementsByTagName("areatimer")
            timerEnableModule.Visible = False
            If LstNodesTimer.Count > 0 Then

                numeroTimer = disegnaTimer(LstNodesTimer, labelTimer, timerVariable)
            End If

        Next

        'end impostazione delle informazioni di base su account
        listMenu.Text = ""
        tabMenu.Text = ""

        ' blocco footer impianto
        'footerText.Text = "<div id=""footerDiv1"" Class=""span2"" style=""background-color:white"">"
        'footerText.Text = footerText.Text + "<canvas class=""span2"" id = ""footerCanvas1"" width=""140"" height=""200"" style= ""width: 100%;max-width: 140px;"">"
        'footerText.Text = footerText.Text + "</canvas>"
        ''footerText.Text = footerText.Text + "</div>"

        ''footerText.Text = footerText.Text + "<div id=""footerDiv2"" class=""span2"" style=""background-color:white"">"
        'footerText.Text = footerText.Text + "<canvas class=""span2"" id = ""footerCanvas2"" width=""140"" height=""200"" style= ""width: 100%;max-width: 140px;"">"
        'footerText.Text = footerText.Text + "</canvas>"
        'footerText.Text = footerText.Text + "</div>"

        'end blocco footer impianto



        javaScriptLiteral.Text = javaScriptLiteral.Text + "get_data('" + serialNumber + "',true);"

        javaScriptLiteral.Text = javaScriptLiteral.Text + "serialNumberGlobal='" + serialNumber + "';" + "sistemaUSA='" + sistemaUSA + "';"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "var refreshIntervalId = setInterval(explode, 10000);function explode() {get_data(serialNumberGlobal,false);}"

        Dim labelTimerSplit() As String = labelTimer.Split(",")

        If (numeroTimer > 0) Then
            javaScriptLiteral.Text = javaScriptLiteral.Text + "timerStringID ='" + timerVariable + "';"
        End If
        For indice = 1 To numeroTimer
            Dim labelTempTimer As String = ""
            Try
                labelTempTimer = labelTimerSplit(indice - 1)
            Catch ex As Exception

            End Try
            javaScriptLiteral.Text = javaScriptLiteral.Text + "var footerCanvasNew" + indice.ToString + " = new footerCanvas('#footerCanvas" + indice.ToString + "','#footerCanvas" + indice.ToString + "','" + labelTempTimer + "');"
            javaScriptLiteral.Text = javaScriptLiteral.Text + "arrayOggettiFooter.push(footerCanvasNew" + indice.ToString + ");"
        Next
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "var footerCanvasNew1 = new footerCanvas('#footerCanvas1','#footerCanvas1');"
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "var footerCanvasNew2 = new footerCanvas('#footerCanvas2','#footerCanvas2');"





        For Each dc1 In tabella_centurio

            Select Case Session("selectedLanguage")
                Case "es"
                    oXMLDoc.LoadXml(dc1.configSetpoint_es)
                    If strumentoTouch <> 1 Then
                        oXMLDoc1.LoadXml(dc1.label_en)
                    End If

                Case "de"
                    oXMLDoc.LoadXml(dc1.configSetpoint_de)
                    If strumentoTouch <> 1 Then
                        oXMLDoc1.LoadXml(dc1.label_en)
                    End If

                Case "ru"
                    oXMLDoc.LoadXml(dc1.configSetpoint_ru)
                    If strumentoTouch <> 1 Then
                        oXMLDoc1.LoadXml(dc1.label_en)
                    End If
                Case "en"
                    oXMLDoc.LoadXml(dc1.configSetpoint_en)
                    If strumentoTouch <> 1 Then
                        oXMLDoc1.LoadXml(dc1.label_en)
                    End If

                Case "it"
                    oXMLDoc.LoadXml(dc1.configSetpoint_it)
                    If strumentoTouch <> 1 Then
                        oXMLDoc1.LoadXml(dc1.label_it)
                    End If

                Case Else
                    oXMLDoc.LoadXml(dc1.configSetpoint_en)
                    If strumentoTouch <> 1 Then
                        oXMLDoc1.LoadXml(dc1.label_en)
                    End If
            End Select
            Dim LstNodes As XmlNodeList
            LstNodes = oXMLDoc.GetElementsByTagName("Istanza")
            Dim tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable
            tabella_probeList = query.getProbeList("")

            listMenu.Text = listMenu.Text + prepareIstanza(tabella_probeList, LstNodes, filter, identificativoUser, setpointUserModify, sistemaUSA)
            javaScriptLiteral.Text = javaScriptLiteral.Text + "labelJson='"
            Try
                If strumentoTouch = 1 Then
                    javaScriptLiteral.Text = javaScriptLiteral.Text + mainFunctionCenturio.preparaLabelJS(LstNodes, filter)
                Else
                    LstNodes = oXMLDoc1.GetElementsByTagName("label")
                    javaScriptLiteral.Text = javaScriptLiteral.Text + mainFunctionCenturio.preparaLabelJSNoTouch(LstNodes)
                End If

            Catch ex As Exception

            End Try
            javaScriptLiteral.Text = javaScriptLiteral.Text + "';"
        Next


        For Each dc1 In tabella_centurio
            Try
                oXMLDoc.LoadXml(dc1.configLog)
                Dim LstNodes As XmlNodeList
                LstNodes = oXMLDoc.GetElementsByTagName("areacanale")
                tabMenuLog.Text = tabMenuLog.Text + disegnaLog(LstNodes, filter)
            Catch ex As Exception

            End Try
        Next



        javaScriptLiteral.Text = javaScriptLiteral.Text + "</script>"
        'tabella_impianto = Master.tabella_impianto_container

        'For Each dc In tabella_impianto
        '    If dc.identificativo = serialNumber Then


        '    End If
        'Next


    End Sub


    Private Function prepareIstanza(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNodes As XmlNodeList, ByVal filter As String, ByVal identificativoUser As String, ByVal modificaSetpoint As String, ByVal sistemaUSA As String) As String


        Dim stringaIstanza As String = ""
        Dim stringaIstanzaTemp As String = ""
        Dim asSubMenu As Boolean = True
        Dim multiparameter As Boolean = False
        Dim contatoreCanale As Integer = 0
        For Each oXMLNode In LstNodes
            stringaIstanzaTemp = ""
            Dim nomeAttributeIstanza As String = oXMLNode.Attributes().ItemOf("nome").Value
            Dim nomeAttributeIstanzaText As String = ""

            'oXMLNodeSub.item("modeComponenti").InnerText


            If filter <> "" Then

                Dim contiene As Boolean = False
                Dim attributeDataConfig As XmlAttribute
                attributeDataConfig = oXMLNode.Attributes().ItemOf("channel")
                If attributeDataConfig IsNot Nothing Then
                    Dim attributeDataConfigSplit() As String = attributeDataConfig.Value.Split("|")
                    Dim filterSplit() As String = filter.Split("|")
                    For Each v As String In attributeDataConfigSplit
                        If (v.IndexOf("-x") > 0) Or (v.IndexOf("-96") > 0) Or (v.IndexOf("-97") > 0) Then
                            v = v.Replace("x", "")
                            multiparameter = True
                            For Each v1 As String In filterSplit
                                If v1.IndexOf("-23") < 0 Then ' controllo solo se non è presente il sensore di pressione differenziale
                                    If (v1.IndexOf(v) >= 0) Then
                                        If (v1.IndexOf("-96") >= 0) Or (v1.IndexOf("-97") >= 0) Then ' verifico se un laser
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
                        If (filterSplit.ToList.IndexOf(v) >= 0) Or v = "xx" Then
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
                If contiene Then
                    contatoreCanale = contatoreCanale + 1
                End If
            End If

            Dim LstNodesCanale As XmlNodeList
            LstNodesCanale = oXMLNode.childNodes()

            For Each oXMLNodeSub In LstNodesCanale
                If oXMLNodeSub.Name = "stringaIstanza" Then
                    nomeAttributeIstanzaText = oXMLNode.item("stringaIstanza").InnerText
                End If
                If oXMLNodeSub.Name = "Componenti" Then
                    Dim nomeAttributeComponenti As String = oXMLNodeSub.Attributes().ItemOf("nome").Value
                    Dim nomeAttributeComponentiText As String = ""
                    Dim LstNodesListaValori As XmlNodeList
                    Dim nodeTemp As XmlNode = oXMLNodeSub.item("stringaComponenti")
                    If nodeTemp Is Nothing Then
                        asSubMenu = False

                        stringaIstanzaTemp = stringaIstanzaTemp + "<li Class=""dropdown""> <a href = ""#" + nomeAttributeIstanza + "_" + nomeAttributeComponenti + """ data-toggle=""tab"">" + oXMLNode.item("stringaIstanza").InnerText + "</a>"
                        stringaIstanzaTemp = stringaIstanzaTemp + "</li>"
                        LstNodesListaValori = oXMLNodeSub.childNodes()
                        tabMenu.Text = tabMenu.Text + prepareListaValori(tabella_probeList, LstNodesListaValori, "null", nomeAttributeIstanza + "_" + nomeAttributeComponenti, nomeAttributeIstanzaText + ">" + nomeAttributeComponentiText, sistemaUSA, contatoreCanale)

                    Else
                        asSubMenu = True
                        nomeAttributeComponentiText = oXMLNodeSub.item("stringaComponenti").InnerText
                        If nomeAttributeComponentiText.IndexOf("]") > 0 Then
                            stringaIstanzaTemp = stringaIstanzaTemp + "<li> <a href = ""#" + nomeAttributeIstanza + "_" + nomeAttributeComponenti + """ type =""menuSopra"" attributo =""" + oXMLNodeSub.item("stringaComponenti").InnerText + """ data-toggle=""tab"">" + oXMLNodeSub.item("stringaComponenti").InnerText + "</a>"
                        Else
                            stringaIstanzaTemp = stringaIstanzaTemp + "<li> <a href = ""#" + nomeAttributeIstanza + "_" + nomeAttributeComponenti + """ data-toggle=""tab"">" + oXMLNodeSub.item("stringaComponenti").InnerText + "</a>"
                        End If

                        stringaIstanzaTemp = stringaIstanzaTemp + "</li>"
                        LstNodesListaValori = oXMLNodeSub.childNodes()
                        tabMenu.Text = tabMenu.Text + prepareListaValori(tabella_probeList, LstNodesListaValori, oXMLNodeSub.item("modeComponenti").InnerText, nomeAttributeIstanza + "_" + nomeAttributeComponenti, nomeAttributeIstanzaText + ">" + nomeAttributeComponentiText, sistemaUSA, contatoreCanale)

                    End If


                    'LiteralHtml.Text = LiteralHtml.Text + ">" + oXMLNodeSub.item("stringaComponenti").InnerText


                End If
            Next

            If asSubMenu Then
                nomeAttributeIstanzaText = oXMLNode.item("stringaIstanza").InnerText
                If nomeAttributeIstanzaText.IndexOf("]") > 0 Then
                    stringaIstanza = stringaIstanza + "<li Class=""dropdown""><a  class=""dropdown-toggl"" type =""menuSopra"" attributo =""" + oXMLNode.item("stringaIstanza").InnerText + """ data-toggle=""dropdown"" href=""#"">" + oXMLNode.item("stringaIstanza").InnerText + "</a>"
                Else
                    stringaIstanza = stringaIstanza + "<li Class=""dropdown""><a  class=""dropdown-toggl"" data-toggle=""dropdown"" href=""#"">" + oXMLNode.item("stringaIstanza").InnerText + "</a>"
                End If

                If LstNodesCanale.Count > 0 Then
                    stringaIstanza = stringaIstanza + "<ul Class=""dropdown-menu"">"
                End If
                stringaIstanza = stringaIstanza + stringaIstanzaTemp
                If LstNodesCanale.Count > 0 Then
                    stringaIstanza = stringaIstanza + "</ul>"
                End If
                stringaIstanza = stringaIstanza + "</li>"
            Else
                stringaIstanza = stringaIstanza + stringaIstanzaTemp

            End If
nexLoopLabel:
        Next


        'tabMenu.Text = tabMenu.Text + "<div Class=""widget"" style=""margin-bottom:0px;"">"
        'tabMenu.Text = tabMenu.Text + "<div Class=""widget-head"" style=""background-color:#a4c408;"">"
        If Session("super_user") Then
            enableManualPulse.Visible = True
            enableManualRelay.Visible = True
            tabMenu.Text = tabMenu.Text + "<div class='btn-primary'>"
            tabMenu.Text = tabMenu.Text + "<b class='btn-primary btn-icon glyphicons ok'><button id=""modals-bootbox-confirm"" class=""btn btn-primary"" style=""margin-top:-3px;"">" + GetGlobalResourceObject("centurio_global", "saveAndLoad") + "</button><i></i></b></div>"
        Else
            Try
                If main_function.checkUserAdmin(identificativoUser, Session("mid_user").ToString, modificaSetpoint) Then
                    enableManualPulse.Visible = True
                    enableManualRelay.Visible = True
                    tabMenu.Text = tabMenu.Text + "<div class='btn-primary'>"
                    tabMenu.Text = tabMenu.Text + "<b class='btn-primary btn-icon glyphicons ok'><button id=""modals-bootbox-confirm"" class=""btn btn-primary"" style=""margin-top:-3px;"">" + GetGlobalResourceObject("centurio_global", "saveAndLoad") + "</button><i></i></b></div>"
                Else
                    enableManualPulse.Visible = False
                    enableManualRelay.Visible = False

                End If
            Catch ex As Exception

            End Try
        End If
        'tabMenu.Text = tabMenu.Text + "</div>"
        Return stringaIstanza
    End Function
    Private Function prepareListaValori(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNodes As XmlNodeList, ByVal modeComponenti As String, ByVal pathName As String, ByVal pathNameText As String, ByVal sistemaUSA As String, ByVal contatoreCanale As Integer) As String

        '     	<div id = "tab2" Class="tab-pane widget-body-regular">
        '	patacchiola finocchio
        '</div>

        'head
        ' <li Class="active"><a class="glyphicons chevron-right" href="#tab-1" data-toggle="tab"><i></i> Active tab</li>
        '<li> <a Class="glyphicons chevron-right" href="#tab-2" data-toggle="tab"><i></i> Other tab</a></li>

        'body

        Dim listaComponenti As String = ""
        Dim widgetHead As String = ""
        Dim widgetbody As String = ""
        Dim htmAfterTab As String = ""
        Dim ulTrueFalse As Boolean = False
        Dim indiceListaValore As Integer = 0
        Dim contatoreOggetti As Integer = 0
        Dim presenteModeComponenti As Boolean = False
        If InStr(modeComponenti, "null") <= 0 Then
            listaComponenti = listaComponenti + "<div  modecomponenti=""" + modeComponenti + """ id = """ + pathName + """ Class=""tab-pane widget-body-regular"""
        Else
            listaComponenti = listaComponenti + "<div  modecomponenti=""null"" id = """ + pathName + """ Class=""tab-pane widget-body-regular"""
        End If


        For Each oXMLNodeSub In LstNodes
            If oXMLNodeSub.Name = "modeComponenti" Then
                presenteModeComponenti = True
            End If
        Next
        If Not presenteModeComponenti Then
            listaComponenti = listaComponenti + "path=""" + pathName + "_null"">"
        End If

        For Each oXMLNodeSub In LstNodes
            If oXMLNodeSub.Name = "modeComponenti" Then
                If oXMLNodeSub.Attributes().count > 0 Then
                    listaComponenti = listaComponenti + "path=""" + pathName + "_" + oXMLNodeSub.Attributes().ItemOf("nome").Value + """>"
                Else
                    listaComponenti = listaComponenti + "path=""" + pathName + "_null"">"
                End If
            End If
            If oXMLNodeSub.Name = "ListaValore" Then

                If (oXMLNodeSub.Attributes().ItemOf("nome").Value <> "null") Then
                    'widgetHead = widgetHead + "<h3>" + pathNameText + "</h3>"
                    If Not ulTrueFalse Then
                        widgetHead = widgetHead + "<div Class=""widget widget-tabs"">"
                        widgetHead = widgetHead + "<h5 type = ""pathName"">" + pathNameText + "</h5>"
                        widgetHead = widgetHead + "<div Class=""widget-head""><ul>"

                        widgetbody = widgetbody + "<div Class=""widget-body"">"
                        widgetbody = widgetbody + "<div Class=""tab-content"">"

                        ulTrueFalse = True
                    End If
                    'widget head
                    Dim actionListavalore As String = ""
                    Dim ListaValoreDef As String = Replace(oXMLNodeSub.Attributes().ItemOf("nome").Value, "[", "-")
                    ListaValoreDef = Replace(ListaValoreDef, "]", "-") ' perche all'id gli rompe le scatole la parentesi [
                    'Dim ListaValoreDef As String = oXMLNodeSub.Attributes().ItemOf("nome").Value

                    widgetHead = widgetHead + preparaWidgetHead(tabella_probeList, oXMLNodeSub, modeComponenti, pathName + "_" + ListaValoreDef, pathName, indiceListaValore, widgetbody, htmAfterTab, contatoreOggetti, actionListavalore, sistemaUSA, contatoreCanale)
                    'widgetHead = widgetHead.Replace("xxxxxx", actionListavalore)
                    'widget body
                    indiceListaValore = indiceListaValore + 1
                Else
                    'condizione senza accordion
                    'listaComponenti = listaComponenti + "<h3>" + pathNameText + "</h3>"
                    listaComponenti = listaComponenti + "<div  Class=""widget widget-tabs"">"
                    listaComponenti = listaComponenti + "<h5>" + pathNameText + "</h5>"
                    Dim LstNodesCanale As XmlNodeList
                    LstNodesCanale = oXMLNodeSub.ChildNodes()
                    For Each oXMLNodeSubVal In LstNodesCanale

                        If oXMLNodeSubVal.Name = "ListaSub" Then
                            'listaComponenti = listaComponenti + costruisciOggetti(oXMLNodeSubVal, oXMLNodeSubVal.Attributes().ItemOf("nome").Value, pathName + "_" + oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName, modeComponenti)
                            'listaComponenti = listaComponenti + costruisciOggetti(oXMLNodeSubVal, "null", pathName + "_" + oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName, modeComponenti, contatoreOggetti.ToString)
                            listaComponenti = listaComponenti + costruisciOggetti(tabella_probeList, oXMLNodeSubVal, "null", oXMLNodeSub.Attributes().ItemOf("nome").Value + "_" + oXMLNodeSubVal.Attributes().ItemOf("nome").Value, pathName, modeComponenti, contatoreOggetti.ToString, sistemaUSA)
                            contatoreOggetti = contatoreOggetti + 1
                        End If
                        If oXMLNodeSubVal.Name = "actionListaValore" And oXMLNodeSubVal.InnerText <> "test_mail" Then ' comando azione Processo
                            listaComponenti = listaComponenti.Replace("xxxxxx", oXMLNodeSubVal.InnerText)
                        End If
                    Next
                    listaComponenti = listaComponenti + "</div>"
                End If
            End If


        Next

        If ulTrueFalse Then
            widgetHead = widgetHead + "</ul></div>"
            widgetbody = widgetbody + "</div></div>"
            listaComponenti = listaComponenti + htmAfterTab + widgetHead + widgetbody + "</div>"

        End If
        listaComponenti = listaComponenti + "</div>"

        Return listaComponenti
        'Dim listaComponenti As String = ""
        'Dim ulTrueFalse As Boolean = False
        'For Each oXMLNodeSub In LstNodes
        '    If oXMLNodeSub.Name = "ListaValore" Then
        '        If (oXMLNodeSub.Attributes().ItemOf("nome").Value <> "null") Then
        '            If Not ulTrueFalse Then
        '                listaComponenti = listaComponenti + "<ul Class=""dropdown-menu"">"
        '                ulTrueFalse = True
        '            End If
        '            listaComponenti = listaComponenti + "<li><a href=""#tab2"" data-toggle=""tab"">" + oXMLNodeSub.item("stringaListaValore").InnerText + "</a></li>"
        '        End If
        '    End If
        'Next
        'If ulTrueFalse Then
        '    listaComponenti = listaComponenti + "</ul>"
        'End If
        'Return listaComponenti
    End Function
    Public Function preparaWidgetHead(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNode As XmlNode, ByVal modeComponenti As String, ByVal pathName As String, ByVal masterPathName As String, ByVal indiceListaValore As Integer, ByRef widgetbody As String, ByRef htmlAfterTab As String, ByRef contatoreOggetti As Integer, ByRef actionValore As String, ByVal sistemaUSA As String, ByVal contatoreCanale As Integer) As String
        Dim modeComponentisplit() As String
        Dim modeComponentisplitValue() As String
        Dim htmlAfterTabText As String = ""
        Dim headText As String = ""
        Dim bodyText As String = ""
        Dim LstNodesCanale As XmlNodeList
        Dim LstNodesSub As XmlNodeList

        'If InStr(modeComponenti, "null") <= 0 Then 'OR|1,0,0,0,0
        '    modeComponentisplit = modeComponenti.Split("|")
        '    modeComponentisplitValue = modeComponentisplit(1).Split(",")
        '    Dim primoLista As Boolean = True
        '    Dim htmIntoTab As String = ""
        '    LstNodesCanale = LstNode.ChildNodes()
        '    For Each oXMLNodeSub In LstNodesCanale
        '        If oXMLNodeSub.Name = "ListaSub" Then
        '            If indiceListaValore = 0 Then
        '                htmIntoTab = htmIntoTab + costruisciOggetti(oXMLNodeSub, modeComponenti, oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName, masterPathName)
        '            Else
        '                htmIntoTab = htmIntoTab + costruisciOggetti(oXMLNodeSub, "null", oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName, masterPathName)
        '            End If

        '        End If
        '    Next
        '    If (modeComponentisplitValue(indiceListaValore)) = "1" Then
        '        headText = "<li id=""" + pathName + "_li""" + " Class=""active""><a Class=""glyphicons chevron-right"" href=""#" + pathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
        '        bodyText = "<div Class=""tab-pane active"" id=""" + pathName + """><p>" + htmIntoTab + "<p></div>"
        '    Else
        '        headText = "<li id=""" + pathName + "_li""" + "><a Class="" glyphicons chevron-right"" href=""#" + pathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
        '        bodyText = "<div Class=""tab-pane"" id=""" + pathName + """><p>" + htmIntoTab + "</p></div>"
        '    End If
        'Else
        Dim primoLista As Boolean = True
        Dim htmIntoTab As String = ""
        LstNodesCanale = LstNode.ChildNodes()
        For Each oXMLNodeSub In LstNodesCanale
            If oXMLNodeSub.Name = "ListaSub" Then
                htmIntoTab = htmIntoTab + costruisciOggetti(tabella_probeList, oXMLNodeSub, "null", oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName, masterPathName, contatoreOggetti.ToString, sistemaUSA)
                contatoreOggetti = contatoreOggetti + 1
            End If
            If oXMLNodeSub.Name = "actionListaValore" And oXMLNodeSub.InnerText <> "test_mail" And oXMLNodeSub.InnerText.ToString.IndexOf("calib") < 0 Then ' comando azione Processo
                actionValore = oXMLNodeSub.InnerText
            End If
            If (oXMLNodeSub.InnerText.ToString.IndexOf("calib") >= 0) Then
                If (pathName.IndexOf("-") > 0) Then ' per verificare se un punto va calibrato o meno
                    htmIntoTab = htmIntoTab + disegnaButtonCalib(LstNode, pathName, contatoreOggetti.ToString, oXMLNodeSub.InnerText.ToString, True, contatoreCanale)
                Else
                    htmIntoTab = htmIntoTab + disegnaButtonCalib(LstNode, pathName, contatoreOggetti.ToString, oXMLNodeSub.InnerText.ToString, False, contatoreCanale)
                End If

                contatoreOggetti = contatoreOggetti + 1
            End If

        Next
        If indiceListaValore = 0 Then
            headText = "<li id=""" + pathName + "_li""" + "Class=""active"" ><a Class=""glyphicons chevron-right"" indice =""" + indiceListaValore.ToString + """ master =""" + masterPathName + """ type=""setpoint"" href=""#" + pathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
            bodyText = "<div actionListaValore =""" + actionValore + """ actionListaValore =""xxxxxx"" Class=""tab-pane active"" id=""" + pathName + """><p>" + htmIntoTab + "<p></div>"
        Else
            headText = "<li id=""" + pathName + "_li""" + "><a Class="" glyphicons chevron-right"" href=""#" + pathName + """ type=""setpoint"" indice =""" + indiceListaValore.ToString + """ master =""" + masterPathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
            bodyText = "<div actionListaValore =""" + actionValore + """ Class=""tab-pane"" id=""" + pathName + """><p>" + htmIntoTab + "</p></div>"
        End If

        ' End If
        'If InStr(modeComponenti, "null") > 0 Then 'OR|1,0,0,0,0
        '    Dim primoLista As Boolean = True
        '    Dim htmIntoTab As String = ""
        '    LstNodesCanale = LstNode.ChildNodes()
        '    For Each oXMLNodeSub In LstNodesCanale
        '        If oXMLNodeSub.Name = "ListaSub" Then
        '            htmIntoTab = htmIntoTab + costruisciOggetti(oXMLNodeSub, modeComponenti, oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName)
        '        End If
        '    Next
        '    If indiceListaValore = 0 Then
        '        headText = "<li id=""" + pathName + "_li""" + "Class=""active""><a Class=""glyphicons chevron-right"" href=""#" + pathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
        '        bodyText = "<div Class=""tab-pane active"" id=""" + pathName + """><p>" + htmIntoTab + "<p></div>"
        '    Else
        '        headText = "<li id=""" + pathName + "_li""" + "><a Class="" glyphicons chevron-right"" href=""#" + pathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
        '        bodyText = "<div Class=""tab-pane"" id=""" + pathName + """><p>" + htmIntoTab + "</p></div>"
        '    End If
        'End If
        'If InStr(modeComponenti, "ALPHAall|") > 0 Then 'ALPHAall|1,0,0,0,0 disabilita tutto in base alla prima scelta
        '    Dim primoLista As Boolean = True
        '    Dim htmIntoTab As String = ""
        '    LstNodesCanale = LstNode.ChildNodes()
        '    For Each oXMLNodeSub In LstNodesCanale

        '        If oXMLNodeSub.Name = "ListaSub" Then
        '            'If indiceListaValore = 0 And primoLista Then
        '            '    htmlAfterTabText = htmlAfterTabText + costruisciOggetti(oXMLNodeSub, modeComponenti, oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName, modeComponenti)
        '            '    primoLista = False
        '            'Else
        '            '    htmIntoTab = htmIntoTab + costruisciOggetti(oXMLNodeSub, modeComponenti, oXMLNodeSub.Attributes().ItemOf("nome").Value, pathName)
        '            'End If
        '        End If
        '    Next
        '    headText = "<li id=""" + pathName + "_li""" + "><a Class="" glyphicons chevron-right"" href=""#" + pathName + """ data-toggle=""tab""><i></i>" + LstNode.Item("stringaListaValore").InnerText + "</a></li>"
        '    bodyText = "<div Class=""tab-pane"" id=""" + pathName + """><p>" + htmIntoTab + "</p></div>"
        'End If

        htmlAfterTab = htmlAfterTab + htmlAfterTabText
        widgetbody = widgetbody + bodyText
        Return headText
    End Function


    Public Function costruisciOggetti(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNode As XmlNode, ByVal modeComponenti As String, ByVal nomeOggetto As String, ByVal pathName As String, ByVal masterPathName As String, Optional ByVal idOggetto As String = "", Optional ByVal sistemaUSA As String = "0") As String
        Try
            Select Case LstNode.Item("widget").InnerText
                Case "value_picker_out"
                    Return disegnaValuePicker(tabella_probeList, LstNode, modeComponenti, pathName, masterPathName, idOggetto, nomeOggetto)
                Case "radio_button"
                    Return disegnaRadioButton(tabella_probeList, LstNode, modeComponenti, pathName, masterPathName, idOggetto, nomeOggetto, sistemaUSA)
                Case "value_picker"

                    Return disegnaValuePicker(tabella_probeList, LstNode, modeComponenti, pathName, masterPathName, idOggetto, nomeOggetto)
                Case "calendar"
                    Return disegnaCalendar(LstNode, pathName, idOggetto, nomeOggetto)
                Case "calendarS"
                    Return disegnaCalendar(LstNode, pathName, idOggetto, nomeOggetto)
                Case "text_input_multi"
                    Return disegnaTextInputMulti(LstNode, pathName, idOggetto, nomeOggetto)
                Case "text_read"
                    Return disegnaTextRead(LstNode, pathName, idOggetto, nomeOggetto)
                Case "text_input"
                    Return disegnaTextInput(LstNode, pathName, idOggetto, nomeOggetto, sistemaUSA)
                Case "timeDateR_picker"
                    Return disegnaTimePickerR(LstNode, pathName, idOggetto, nomeOggetto)
                Case "timeDate_picker"
                    Return disegnaTimePickerS(LstNode, pathName, idOggetto, nomeOggetto)


                Case "time_picker"
                    Return disegnaTimePicker(LstNode, pathName, idOggetto, nomeOggetto)
                Case "week_widget"
                    Return disegnaWeekWidget(tabella_probeList, LstNode, pathName, idOggetto, nomeOggetto)


            End Select
        Catch ex As Exception

        End Try

    End Function
    Public Function disegnaRadioButton(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNode As XmlNode, ByVal modeComponenti As String, ByVal pathName As String, ByVal masterPathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String, ByVal sistemaUSA As String)
        Dim stringResult As String = "<div  id =""" + pathName + "_" + nomeOggetto + "_div"">"
        Dim typeofList As String = ""
        Dim dictionaryList() As String
        Dim indiceLoop As Integer = 0
        Dim textListRadio As String = LstNode.Item("unit").InnerText
        Try
            stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
            stringResult = stringResult + "<div Class=""row-fluid"">"
            stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" action=""setpoint"" typeofList=""" + typeofList + """ data-original-title=""" + LstNode.Item("stringa").InnerText + """  path=""" + pathName + """  masterpath=""" + masterPathName + """  count=""" + idOggetto + """  attrib=""null"" id = """ + pathName + "_" + nomeOggetto + """ Class=""span3"">"
            If textListRadio.IndexOf("|") > 0 Then
                If sistemaUSA = "1" Then
                    textListRadio = (textListRadio.Split("|"))(1)
                Else
                    textListRadio = (textListRadio.Split("|"))(0)
                End If
            End If
            dictionaryList = textListRadio.Split(",")
            For Each dictionaryValue In dictionaryList
                stringResult = stringResult + "<Option value=""" + indiceLoop.ToString + """ >" + dictionaryValue + "</Option>"
                indiceLoop = indiceLoop + 1
            Next
        Catch ex As Exception
            Return ""
        End Try
        stringResult = stringResult + "</Select>"
        stringResult = stringResult + "<span id = ""misura"" attrMisura = """ + LstNode.Item("misura").InnerText + """ ></span>"
        stringResult = stringResult + "</div></div>"
        Return stringResult

    End Function
    Public Function disegnaValuePicker(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNode As XmlNode, ByVal modeComponenti As String, ByVal pathName As String, ByVal masterPathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        Dim stringResult As String = "<div  id =""" + pathName + "_" + nomeOggetto + "_div"">"
        Dim dictionaryList As List(Of Dictionary(Of String, String))
        'controllo se è relay or proportional or input
        'Dim typeofList As String = LstNode.Item("valore").InnerText
        Dim typeofList As String = ""
        Dim attributeDataNodes As XmlAttribute
        attributeDataNodes = LstNode.Item("valore").Attributes().ItemOf("input")
        If attributeDataNodes IsNot Nothing Then
            typeofList = "input"
        Else
            attributeDataNodes = LstNode.Item("valore").Attributes().ItemOf("opto")
            If attributeDataNodes IsNot Nothing Then
                typeofList = "opto"
            Else
                attributeDataNodes = LstNode.Item("valore").Attributes().ItemOf("relay")
                If attributeDataNodes IsNot Nothing Then
                    typeofList = "relay"
                End If
            End If
        End If
        '<span Class="btn btn-inverse" data-toggle="tooltip" data-original-title="Tooltip On Right" data-placement="right">Tooltip on Right</span>
        Try
            stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
            stringResult = stringResult + "<div Class=""row-fluid"">"
            'If (nomeOggetto.IndexOf("modework") >= 0) Then ' caso della scelta
            If (nomeOggetto.IndexOf("modeworkEnableDisable") >= 0) Then ' abilita e disabilita tutto
                stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" action=""setpoint"" typeofList=""" + typeofList + """ data-original-title=""" + LstNode.Item("stringa").InnerText + """  path=""" + pathName + """  masterpath=""" + masterPathName + """  count=""" + idOggetto + """  attrib=""null"" id = """ + pathName + "_" + nomeOggetto + """ Class=""span3"">"
            Else
                If (nomeOggetto.IndexOf("modework") >= 0) Then ' abilita e disabilita tutto
                    stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" action=""setpoint"" typeofList=""" + typeofList + """ data-original-title=""" + LstNode.Item("stringa").InnerText + """  path=""" + pathName + """  masterpath=""" + masterPathName + """  count=""" + idOggetto + """  attrib=""" + LstNode.Item("select").InnerText + """ id = """ + pathName + "_" + nomeOggetto + """ Class=""span3"">"
                Else
                    If (LstNode.Item("valore").InnerText.ToString = "noChange") Then
                        stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""ok"" action=""setpoint"" typeofList=""" + typeofList + """ data-original-title=""" + LstNode.Item("stringa").InnerText + """  path=""" + pathName + """  masterpath=""" + masterPathName + """  count=""" + idOggetto + """  attrib=""null"" id = """ + pathName + "_noChange"" Class=""span3"">"
                    Else
                        stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" action=""setpoint"" typeofList=""" + typeofList + """ data-original-title=""" + LstNode.Item("stringa").InnerText + """  path=""" + pathName + """  masterpath=""" + masterPathName + """  count=""" + idOggetto + """  attrib=""null"" id = """ + pathName + "_" + nomeOggetto + """ Class=""span3"">"

                    End If

                End If
            End If

        Catch ex As Exception
            Return ""
        End Try


        dictionaryList = mainFunctionCenturio.getResultXml(LstNode.Item("unit").InnerText, Session("selectedLanguage"), tabella_probeList)
        For Each dictionaryValue In dictionaryList
            stringResult = stringResult + "<Option value=""" + dictionaryValue.Item("index") + """ >" + dictionaryValue.Item("valore") + "</Option>"
        Next

        stringResult = stringResult + "</Select>"
        stringResult = stringResult + "<span id = ""misura"" attrMisura = """ + LstNode.Item("misura").InnerText + """ ></span>"
        stringResult = stringResult + "</div></div>"
        Return stringResult
    End Function
    Public Function disegnaTimePicker(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        Dim stringResult As String = "<div id =""" + pathName + "_" + nomeOggetto + "_div"">"
        Dim valoriTime() As String = LstNode.Item("valore").InnerText.Split(",")
        Dim minList() As String = LstNode.Item("minimo").InnerText.Split(",")
        Dim maxList() As String = LstNode.Item("massimo").InnerText.Split(",")
        Dim unitList() As String = LstNode.Item("unit").InnerText.Split(",")

        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "(" + unitList(0) + "," + unitList(1) + ")" + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" oreminuti = ""ore"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto + """ Class=""span2"">"
        For i = Val(minList(0)) To Val(maxList(0))
            stringResult = stringResult + "<Option value=""" + i.ToString + """ >" + i.ToString + "</Option>"
        Next

        stringResult = stringResult + "</Select>"
        stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" oreminuti = ""minuti"" action=""setpoint""  id = """ + pathName + "_" + nomeOggetto + "_1""  data-original-title=""" + LstNode.Item("stringa").InnerText + """ count=""" + idOggetto + """ Class=""span2"">"
        For i = Val(minList(1)) To Val(maxList(1))
            stringResult = stringResult + "<Option value=""" + i.ToString + """ >" + i.ToString + "</Option>"
        Next

        stringResult = stringResult + "</Select>"
        stringResult = stringResult + "<span id = ""misura""  attrMisura = """ + LstNode.Item("misura").InnerText + """> </span>"

        stringResult = stringResult + "</div></div>"
        Return stringResult
    End Function
    Function disegnaWeekWidget(ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable, ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"
        Dim weekProgram() As String = LstNode.Item("valore").InnerText.Split("|")
        Dim counteW As Integer = 0
        Dim i As Integer = 0
        Dim dictionaryList As List(Of Dictionary(Of String, String))
        dictionaryList = mainFunctionCenturio.getResultXml("week", Session("selectedLanguage"), tabella_probeList)


        stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no""  type = ""hidden""  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """  max  decimali  Error value="""" Class=""span3"">"

        For Each weekProgramSingle As String In weekProgram
            If weekProgramSingle.IndexOf("@") >= 0 Then
                stringResult = stringResult + "<div Class=""row-fluid"" id = """ + pathName + "_" + nomeOggetto + "_" + counteW.ToString() + """ dayofweek=""" + dictionaryList.Item(counteW).Item("valore") + """>"
                'stringResult = stringResult + "<a hred=""#"">ciao</a>"
                stringResult = stringResult + "<div Class=""span1  biocide_day"" id = """ + pathName + "_" + nomeOggetto + "_" + counteW.ToString() + "_x"">"
                stringResult = stringResult + dictionaryList.Item(counteW).Item("valore")
                stringResult = stringResult + "</div>"
                stringResult = stringResult + "</div>"
                counteW = counteW + 1
            Else
                If weekProgramSingle.Length > 0 Then
                    Dim weekProgramSplit() As String = weekProgramSingle.Split(",")
                    stringResult = stringResult + "<div Class=""row-fluid"">"
                    stringResult = stringResult + "<div Class=""span2"">"
                    stringResult = stringResult + "<h5>" + dictionaryList.Item(counteW).Item("valore") + "</h5>"
                    stringResult = stringResult + "</div>"
                    '------------------time
                    stringResult = stringResult + "<div Class=""span2"">"
                    stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"

                    stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no"" action=""setpoint""  type = ""text""  id = """ + pathName + "_" + nomeOggetto + "_time_" + counteW.ToString() + """  data-original-title=""" + LstNode.Item("stringa").InnerText + """ count=""" + idOggetto +
                """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """ mainId =""" + pathName + "_" + nomeOggetto + """  max=""null""  decimali=""null""  Error="""" value=""00:00"">"

                    'stringResult = stringResult + "<input type=""text"" id=""datepicker"" value="""" class=""hasDatepicker"">"

                    stringResult = stringResult + "</input>"
                    stringResult = stringResult + "</div>"
                    '------------------end time
                    '------------------feed time
                    stringResult = stringResult + "<div Class=""span2"">"
                    stringResult = stringResult + "<h5>Feed Time Hr</h5>"

                    stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  id = """ + pathName + "_" + nomeOggetto + "_feed_" + counteW.ToString() + """  min=""" + LstNode.Item("minimo").InnerText + """ mainId =""" + pathName + "_" + nomeOggetto + """ count=""" + idOggetto + """>"
                    For i = 0 To 23
                        stringResult = stringResult + "<Option value=""" + i.ToString + """ >" + i.ToString + "</Option>"
                    Next

                    stringResult = stringResult + "</Select>"
                    stringResult = stringResult + "</div>"
                    stringResult = stringResult + "<div Class=""span2"">"
                    stringResult = stringResult + "<h5>Feed Time Min</h5>"
                    stringResult = stringResult + "<Select manualRemote = ""no"" calib = ""no"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """   id = """ + pathName + "_" + nomeOggetto + "_1" + "_feed_" + counteW.ToString() + """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """ mainId =""" + pathName + "_" + nomeOggetto + """  count=""" + idOggetto + """>"
                    For i = 0 To 59
                        stringResult = stringResult + "<Option value=""" + i.ToString + """ >" + i.ToString + "</Option>"
                    Next

                    stringResult = stringResult + "</Select>"

                    stringResult = stringResult + "</input>"
                    stringResult = stringResult + "<span id = ""misura""  attrMisura = """ + LstNode.Item("misura").InnerText + """> </span>"
                    stringResult = stringResult + "</div>"
                    '------------------end feed time

                    javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_time_picker('" + pathName + "_" + nomeOggetto + "_time_" + counteW.ToString() + "');"
                    stringResult = stringResult + "</div>"
                    counteW = counteW + 1
                End If
            End If
        Next
        stringResult = stringResult + "</div>"
        Return stringResult
    End Function
    Public Function disegnaTimePickerR(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"


        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        stringResult = stringResult + "<input manualRemote = ""no""  calib = ""no"" action=""setpoint""  type = ""text"" data-original-title=""" + LstNode.Item("stringa").InnerText + """ id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""timeDataOraR"" minB=""timeDataOraR""  max=""null""  decimali=""null""  Error="""" value=""00:00"">"

        stringResult = stringResult + "</input>"
        stringResult = stringResult + "<span id = ""misura""  attrMisura = """ + LstNode.Item("misura").InnerText + """> </span>"
        stringResult = stringResult + "</div></div>"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_time_picker('" + pathName + "_" + nomeOggetto + "');"
        Return stringResult

    End Function
    Public Function disegnaTimePickerS(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"


        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no"" action=""setpoint""  type = ""text"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""timeDataOraS""  min=""timeDataOraS""  max=""null""  decimali=""null""  Error="""" value=""00:00"">"

        stringResult = stringResult + "</input>"
        stringResult = stringResult + "<span id = ""misura""  attrMisura = """ + LstNode.Item("misura").InnerText + """> </span>"
        stringResult = stringResult + "</div></div>"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_time_picker('" + pathName + "_" + nomeOggetto + "');"
        Return stringResult

    End Function

    Public Function disegnaTextInputMulti(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        '<input type = "text" placeholder="Text input" Class="span12">
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"
        Dim minimoSplit() As String = LstNode.Item("minimo").InnerText.Split("|")
        Dim massimoSplit() As String = LstNode.Item("massimo").InnerText.Split("|")
        Dim decimaliSplit() As String = LstNode.Item("numerodecimali").InnerText.Split("|")
        Dim errorSplit() As String = LstNode.Item("errorkeyboard").InnerText.Split("|")
        Dim misuraSplit() As String = LstNode.Item("misura").InnerText.Split("|")

        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no"" multi = ""ok"" action=""setpoint""   type = ""text"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""" + minimoSplit(0) + """  minB=""" + minimoSplit(0) + """  max=""" + massimoSplit(0) + """  maxB=""" + massimoSplit(0) + """  decimali=""" + decimaliSplit(0) + """  decimaliB=""" + decimaliSplit(0) + """  Error=""" + errorSplit(0) + """ value="""" Class=""span3"">"
        stringResult = stringResult + "<span id = ""misura_multi""  attrMisura = """ + misuraSplit(0) + """> </span>"

        stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no"" multi = ""ok"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  type = ""text""  id = """ + pathName + "_" + nomeOggetto + "_1""  count=""" + idOggetto +
            """  min=""" + minimoSplit(1) + """  minB=""" + minimoSplit(1) + """  max=""" + massimoSplit(1) + """  maxB=""" + massimoSplit(1) + """  decimali=""" + decimaliSplit(0) + """  decimaliB=""" + decimaliSplit(0) + """  Error=""" + errorSplit(1) + """ value="""" Class=""span3"">"

        stringResult = stringResult + "</input>"
        stringResult = stringResult + "<span id = ""misura_multi"" attrMisura = """ + misuraSplit(1) + """> </span>"

        stringResult = stringResult + "</div></div>"
        Return stringResult

    End Function
    Public Function disegnaTextRead(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        '<input type = "text" place             holder="Text input" Class="span12">
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"


        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        'stringResult = stringResult + "<input multi = ""no"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  type = ""text""  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
        '    """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """  max=""" + LstNode.Item("massimo").InnerText + """  maxB=""" + LstNode.Item("massimo").InnerText + """  decimali=""" + LstNode.Item("numerodecimali").InnerText + """  decimaliB=""" + LstNode.Item("numerodecimali").InnerText + """  Error=""" + LstNode.Item("errorkeyboard").InnerText + """ value="""" Class=""span3"">"


        'stringResult = stringResult + "</input>"
        stringResult = stringResult + "<label multi = ""no"" attribute=""" + LstNode.Item("valore").InnerText + """ action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  type = ""textRead""  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """  max=""" + LstNode.Item("massimo").InnerText + """  maxB=""" + LstNode.Item("massimo").InnerText + """  decimali=""" + LstNode.Item("numerodecimali").InnerText + """  decimaliB=""" + LstNode.Item("numerodecimali").InnerText + """  Error=""" + LstNode.Item("errorkeyboard").InnerText + """ value="""" class=""span1""></label>"

        stringResult = stringResult + "<span id = ""misura"" attrMisura = """ + LstNode.Item("misura").InnerText + """> </span>"
        stringResult = stringResult + "</div></div>"
        Return stringResult

    End Function
    Public Function disegnaButtonCalib(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String, ByVal checkPrimoPunto As Boolean, ByVal numeroCanale As Integer)
        '<input type = "text" place             holder="Text input" Class="span12">
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"

        stringResult = stringResult + "<div Class=""row-fluid"">"
        stringResult = stringResult + "<div id = """ + pathName + "_" + nomeOggetto + "_count"" style=""display:none"" >"
        stringResult = stringResult + "<script type = ""text/javascript"" charset=""utf-8"">"
        stringResult = stringResult + "varsCountDown[""" + pathName + "_" + nomeOggetto + "_countdown""] =  $(""#" + pathName + "_" + nomeOggetto + "_count"").countdown360({radius: 40,seconds: 40,fontColor: '#FFFFFF',autostart: false,onComplete: function () { $(""#" + pathName + "_" + nomeOggetto + "_count"" ).hide();incrementoCalibrazioneGlobal=0; }});</script>"
        stringResult = stringResult + "<label id = """ + pathName + "_" + nomeOggetto + "_label"" >Wait Calibration </label>"
        'countdown.start();
        stringResult = stringResult + "<h5 >Do Not close this page </h5>"


        stringResult = stringResult + "</div></div>"

        stringResult = stringResult + "<div Class=""row-fluid"">"
        'stringResult = stringResult + "<input multi = ""no"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  type = ""text""  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
        '    """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """  max=""" + LstNode.Item("massimo").InnerText + """  maxB=""" + LstNode.Item("massimo").InnerText + """  decimali=""" + LstNode.Item("numerodecimali").InnerText + """  decimaliB=""" + LstNode.Item("numerodecimali").InnerText + """  Error=""" + LstNode.Item("errorkeyboard").InnerText + """ value="""" Class=""span3"">"


        'stringResult = stringResult + "</input>"
        If (checkPrimoPunto) Then
            stringResult = stringResult + "<input primoPuntoCheck = ""yes"" calibPrimoPunto =""ch" + numeroCanale.ToString + "zeroCalibR"" manualRemote = ""no"" calib = ""ok"" typeAction =""remoteCalib"" type=""button"" id = """ + pathName + "_" + nomeOggetto + """ actionValue=""" + nomeOggetto + """ getValue=""" + pathName + "_noChange"" Class=""btn btn-primary"" value=""Start Calibration"">"
        Else
            stringResult = stringResult + "<input primoPuntoCheck = ""no"" manualRemote = ""no"" calib = ""ok"" typeAction =""remoteCalib"" type=""button"" id = """ + pathName + "_" + nomeOggetto + """ actionValue=""" + nomeOggetto + """ getValue=""" + pathName + "_noChange"" Class=""btn btn-primary"" value=""Start Calibration"">"
        End If


        stringResult = stringResult + "</div></div>"
        Return stringResult

    End Function
    Public Function disegnaTextInput(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String, ByVal sistemaUSA As String)
        '<input type = "text" placeholder="Text input" Class="span12">
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"


        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        If (LstNode.Item("valore").InnerText.ToString = "noChange") Then
            stringResult = stringResult + "<input manualRemote = ""no"" calib = ""ok"" multi = ""no"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  type = ""text""  id = """ + pathName + "_noChange""  count=""" + idOggetto +
            """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """  max=""" + LstNode.Item("massimo").InnerText + """  maxB=""" + LstNode.Item("massimo").InnerText + """  decimali=""" + LstNode.Item("numerodecimali").InnerText + """  decimaliB=""" + LstNode.Item("numerodecimali").InnerText + """  Error=""" + LstNode.Item("errorkeyboard").InnerText + """ value="""" Class=""span3"">"
        Else
            stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no"" multi = ""no"" action=""setpoint"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  type = ""text""  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""" + LstNode.Item("minimo").InnerText + """  minB=""" + LstNode.Item("minimo").InnerText + """  max=""" + LstNode.Item("massimo").InnerText + """  maxB=""" + LstNode.Item("massimo").InnerText + """  decimali=""" + LstNode.Item("numerodecimali").InnerText + """  decimaliB=""" + LstNode.Item("numerodecimali").InnerText + """  Error=""" + LstNode.Item("errorkeyboard").InnerText + """ value="""" Class=""span3"">"
        End If


        stringResult = stringResult + "</input>"
        Dim attributoMisura As String = LstNode.Item("misura").InnerText.ToString
        If sistemaUSA = "1" Then
            If attributoMisura.IndexOf("m3") >= 0 Then
                attributoMisura = attributoMisura.Replace("m3", "gal")
            End If
        End If
        stringResult = stringResult + "<span id = ""misura"" attrMisura = """ + attributoMisura + """> </span>"
        stringResult = stringResult + "</div></div>"
        Return stringResult

    End Function
    Public Function disegnaCalendar(ByVal LstNode As XmlNode, ByVal pathName As String, ByVal idOggetto As String, ByVal nomeOggetto As String)
        '<input type = "text" placeholder="Text input" Class="span12">
        Dim stringResult As String = "<div Class=""control-group"" id =""" + pathName + "_" + nomeOggetto + "_div"">"


        stringResult = stringResult + "<h5>" + LstNode.Item("stringa").InnerText + "</h5>"
        stringResult = stringResult + "<div Class=""row-fluid"">"
        stringResult = stringResult + "<input manualRemote = ""no"" calib = ""no"" action=""setpoint"" type = ""text"" data-original-title=""" + LstNode.Item("stringa").InnerText + """  id = """ + pathName + "_" + nomeOggetto + """  count=""" + idOggetto +
            """  min=""null""  max=""null""  decimali=""null""  Error="""" value="""">"

        'stringResult = stringResult + "<input type=""text"" id=""datepicker"" value="""" Class=""hasDatepicker"">"

        stringResult = stringResult + "</input>"
        stringResult = stringResult + "<span id = ""misura"" attrMisura = """ + LstNode.Item("misura").InnerText + """> </span>"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_date_picker('" + pathName + "_" + nomeOggetto + "');"
        stringResult = stringResult + "</div></div>"
        Return stringResult

    End Function


    Public Function preparaBody(ByVal idProbeLabel As String, ByVal idProbeTemperature As String, ByVal idProbeTemperatureSetting As String, ByVal numero_canale As Integer, ByVal listaAllarmi As List(Of String), ByVal listaAllarmiLabel As List(Of String), ByVal listaOutput As List(Of output), ByVal listaOutputLabel As List(Of String), ByVal listaLivello As List(Of String), ByVal listaLivelloLabel As List(Of String), ByVal listaAllarmiGlobal As List(Of String), ByVal listaAllarmiGlobalLabel As List(Of String), ByVal idProbeService As String) As String
        Dim intestazione As String = ""
        Dim indici As Integer = 0
        Dim indiceLabel As Integer = 0

        If numero_canale Mod 3 = 0 Then
            intestazione = intestazione + "<div Class=""row-fluid"">"
        End If

        intestazione = intestazione + "<div Class=""span4"">"
        intestazione = intestazione + "<div Class=""widget"">"
        intestazione = intestazione + "<div Class=""widget-head"" style=""background-color:white;"">"


        intestazione = intestazione + "<h3 type =""mainLabel"" class=""heading"" id = """ + idProbeLabel + "_mainLabel""></h3>"
        If (idProbeService <> "") Then
            intestazione = intestazione + "<h6 id = """ + idProbeService + "_mainLabel"" type =""mainLabel"" Class=""heading""></h6>"
        End If

        intestazione = intestazione + "<span style = ""float:right;color:black;""><img src=""image/temperature.png"" width=""10"" class=""temp""  type =""mainTemperature""  attribute=""" + idProbeTemperatureSetting + """  id = """ + idProbeTemperature + """></span></div>"

        For Each elemntAlarm In listaAllarmiGlobal
            intestazione = intestazione + "<div id = ""globalID" + elemntAlarm + """ Class=""widget-head"" style=""background-color:#c33;display:none"">"
            intestazione = intestazione + "<h4  id = ""global" + listaAllarmiGlobalLabel.Item(indiceLabel) + """ class=""center"">pH Canale</h4> </div>"
            indiceLabel = indiceLabel + 1
        Next
        intestazione = intestazione + "<div  id=""canale" + numero_canale.ToString + """ Class=""widget-body"">"
        intestazione = intestazione + "<canvas id = ""bodyCanvas" + numero_canale.ToString + """ Style = ""width: 100%;max-width: 509px;"" >"
        intestazione = intestazione + "</canvas>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "<div id = ""bodyCanvasSub" + numero_canale.ToString + """ style = ""border-top: 1px solid #e5e5e5;padding-top: 10px;"" >"
        intestazione = intestazione + "<div class=""row-fluid"">"

        intestazione = intestazione + "<div id = ""bodyCanvasSub" + numero_canale.ToString + "Alarm"" class=""span6"" style=""text-align:center"">"
        intestazione = intestazione + "Alarm"
        intestazione = intestazione + "<ul  class=""unstyled alarm"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"
        indici = 0
        For Each elemntAlarm In listaAllarmi
            intestazione = intestazione + "<li id=""" + elemntAlarm + """"
            Try
                intestazione = intestazione + " label=""" + listaAllarmiLabel.Item(indici) + """"
            Catch ex As Exception
                intestazione = intestazione + " label="""""
            End Try

            intestazione = intestazione + " type =""alarm"" class=""glyphicons circle_exclamation_mark""><i></i>Allarme 1</li>"

            indici = indici + 1
        Next
        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "<div id = ""bodyCanvasSub" + numero_canale.ToString + "Level"" class=""span6"" style=""text-align:center"">"
        intestazione = intestazione + "Livelli"
        intestazione = intestazione + "<ul  class=""unstyled level"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"
        indici = 0
        For Each elemntLivello In listaLivello
            intestazione = intestazione + "<li id=""" + elemntLivello + """"
            Try
                intestazione = intestazione + " label=""" + listaLivelloLabel.Item(indici) + """"
            Catch ex As Exception
                intestazione = intestazione + " label="""""
            End Try

            intestazione = intestazione + " type =""level"" class=""glyphicons chevron-right""><i></i>Livello1 1</li>"

            indici = indici + 1
        Next
        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "<div id = ""bodyCanvasSub" + numero_canale.ToString + "Out"" Class=""span6"" style=""text-align:center"">"
        intestazione = intestazione + "Uscite"
        intestazione = intestazione + "<ul  class=""unstyled output"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"
        indici = 0
        For Each elemntUscite In listaOutput


            intestazione = intestazione + "<li id=""" + elemntUscite.nomeString + """"
            Try
                intestazione = intestazione + " label=""" + listaOutputLabel.Item(indici) + """"
            Catch ex As Exception
                intestazione = intestazione + " label="""""
            End Try
            If (elemntUscite.typeValue) Then ' digital
                intestazione = intestazione + " type =""digital"" class=""glyphicons circle_arrow_right""><i></i>Out 1</li>"
            Else
                intestazione = intestazione + " type =""proportional"" class=""glyphicons circle_arrow_right""><i></i>Out 1</li>"
            End If



            indici = indici + 1
        Next
        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        If (numero_canale + 1) Mod 3 = 0 Then
            intestazione = intestazione + "</div>"
        End If

        Return intestazione
    End Function


    Public Function getAllarmiGlobal(ByVal LstNodes As XmlNodeList, ByRef listaAllarmiLabel As List(Of String)) As List(Of String)

        Dim listaAllarmi As List(Of String) = New List(Of String)
        'Dim listaAllarmiLabel As List(Of String) = New List(Of String)


        Dim numeroHeader As Integer = 0
        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList

            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                Dim LstNodesCanale As XmlNodeList
                LstNodesCanale = oXMLNodeSub.childNodes()
                Dim idTot As String = ""
                Dim idFlow As String = ""
                Dim idAlarm As String = ""
                Dim idLabelTot As String = ""
                If oXMLNodeSub.name = "watermeter" Then
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        If (oXMLNodeCanale.name <> "#comment") Then
                            attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                            If (attributeDataNodes.Value = "alarm") Then
                                listaAllarmi.Add(oXMLNodeCanale.InnerXml())
                                listaAllarmiLabel.Add(oXMLNodeCanale.Attributes().ItemOf("label").Value)
                            End If
                        End If
                    Next
                End If
                If oXMLNodeSub.name = "flow" Then
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        If (oXMLNodeCanale.name <> "#comment") Then
                            attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                            If (attributeDataNodes.Value = "alarm") Then
                                listaAllarmi.Add(oXMLNodeCanale.InnerXml())
                                listaAllarmiLabel.Add(oXMLNodeCanale.Attributes().ItemOf("label").Value)
                            End If
                        End If
                    Next
                End If
            Next
        Next
        Return listaAllarmi

    End Function
    Public Function disegnaHeader(ByVal LstNodes As XmlNodeList, ByVal nomeStrumento As String) As String
        Dim numeroHeader As Integer = 0
        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList

            NameStrumento1.Text = "<h3 id = 'labelCenturioR_h3' class='heading'>" + nomeStrumento + "</h3>"

            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                Dim LstNodesCanale As XmlNodeList
                LstNodesCanale = oXMLNodeSub.childNodes()
                Dim idTot As String = ""
                Dim idFlow As String = ""
                Dim idFlowAlert As String = ""
                Dim idFlowAlarm As String = ""
                Dim idAlarm As String = ""
                Dim idLabelTot As String = ""
                If oXMLNodeSub.name = "datetime" Then
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        If (oXMLNodeCanale.name <> "#comment") Then
                            attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                            If (attributeDataNodes.Value = "datetime") Then
                                DateTimeHeader.Text = "<h3 id = ""clockRealR""class=""heading""></h3>"
                            End If
                            If (attributeDataNodes.Value = "label") Then
                                NameStrumento1.Text = "<h3 id = 'labelCenturioR_h3' class='heading'>" + nomeStrumento + "</h3>"
                            End If
                        End If
                    Next
                End If
                If oXMLNodeSub.name = "watermeter" Then
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        If (oXMLNodeCanale.name <> "#comment") Then
                            attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                            If (attributeDataNodes.Value = "flowmeter") Then
                                idFlow = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "flowmeterAlert") Then
                                idFlowAlert = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "wmtot") Then
                                idTot = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "alarm") Then
                                idAlarm = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "labeltot") Then
                                idLabelTot = oXMLNodeCanale.InnerXml()
                            End If
                        End If
                    Next
                    ' blocco header impianto java script (canvas water meter)
                    javaScriptLiteral.Text = javaScriptLiteral.Text + "var canvasNew" + numeroHeader.ToString + "= new headerCanvas('#myCanvas" + numeroHeader.ToString + "','" + idTot + "','" + idFlow + "','" + idAlarm + "','" + idLabelTot + "','" + idFlowAlert + "','" + idFlowAlarm + "');"
                    javaScriptLiteral.Text = javaScriptLiteral.Text + "arrayOggettiHeader.push(canvasNew" + numeroHeader.ToString + ");"

                    ' blocco header impianto
                    'headText.Text = headText.Text + "<div  style=""background-color:white;height:100%"">"
                    If idFlow = "" Then
                        headText.Text = headText.Text + "<canvas class=""span2"" id = ""myCanvas" + numeroHeader.ToString + """ width=""200"" height=""100%"" style= ""width: 100%;max-width: 200px;"">"
                    Else
                        headText.Text = headText.Text + "<canvas class=""span2"" id = ""myCanvas" + numeroHeader.ToString + """ width=""200"" height=""150"" style= ""width: 100%;max-width: 200px;"">"
                    End If



                    headText.Text = headText.Text + "</canvas>"
                        'headText.Text = headText.Text + "</div>"
                        'end blocco header impianto

                    End If






                    ' end blocco header impianto java script
                    numeroHeader = numeroHeader + 1
            Next
        Next




    End Function
    Public Function disegnaLog(ByVal LstNodes As XmlNodeList, ByVal filter As String) As String
        Dim intestazione As String = ""
        Dim progressivo As Integer = 0
        Dim intestazioneTemp As String = ""
        Dim intestazioneHeader As String = ""
        Dim ldLodg As Boolean = False
        Dim multiparameter As Boolean = False
        intestazione = "<div class=""row-fluid""> <div Class=""span2""> <h5>" + "Log Type" + "</h5>"
        intestazione = intestazione + "<Select manualRemote = ""no"" calib = ""no"" id=""logTypeAlarmEvery"" data-original-title=""Log Type"" data-placement=""right"" >"
        intestazione = intestazione + "<Option value=""0"" >Scheduled</Option>"
        intestazione = intestazione + "<Option value=""1"" >Alarm</Option>"
        intestazione = intestazione + "</select></div>"

        intestazione = intestazione + "<div Class=""span2""><h5>" + "Merge" + "</h5> <Label Class=""checkbox"" ><span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" id=""mergeGraph"" Class=""checkbox"" min =""minlog""><span>Merge Channel</span></span> </label>"
        intestazione = intestazione + "</div>"

        intestazione = intestazione + "<div Class=""span2""><h5>" + "Setpoint" + "</h5> <Label Class=""checkbox"" ><span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" id=""setpointGraph"" Class=""checkbox"" min =""minlog""><span>Setpoints</span></span> </label>"
        intestazione = intestazione + "</div>"


        intestazione = intestazione + "</div>"
        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList
            Dim rootNode As Boolean = True
            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                If filter <> "" Then

                    Dim contiene As Boolean = False
                    Dim attributeDataConfig As XmlAttribute
                    attributeDataConfig = oXMLNodeSub.Attributes().ItemOf("channel")
                    If attributeDataConfig IsNot Nothing Then
                        Dim attributeDataConfigSplit() As String = attributeDataConfig.Value.Split("|")
                        Dim filterSplit() As String = filter.Split("|")
                        For Each v As String In attributeDataConfigSplit
                            multiparameter = False
                            If (v.IndexOf("-x") > 0) Then
                                v = v.Replace("x", "")
                                multiparameter = True
                                For Each v1 As String In filterSplit
                                    If v1.IndexOf("-23") < 0 Then ' controllo solo se non è presente il sensore di pressione differenziale
                                        If (v1.IndexOf(v) >= 0) Then
                                            If v1.IndexOf("96") >= 0 Then
                                                ldLodg = True
                                            Else
                                                contiene = True
                                                Exit For
                                            End If

                                        End If
                                    End If
                                Next
                            End If
                            If (filterSplit.ToList.IndexOf(v) >= 0 And multiparameter = False) Or v = "xx" Then
                                If v.IndexOf("96") >= 0 Then
                                    ldLodg = True
                                End If
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

                Dim LstNodesCanale As XmlNodeList
                LstNodesCanale = oXMLNodeSub.childNodes()


                If oXMLNodeSub.name = "canale" Then
                    intestazioneTemp = "<div Class=""row-fluid"">"
                    rootNode = True
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                        If (oXMLNodeCanale.name <> "#comment") Then

                            If (attributeDataNodes.Value = "probe") Then
                                'header
                                If rootNode Then
                                    If (oXMLNodeCanale.Attributes().ItemOf("labelh5") Is Nothing) Then
                                        intestazioneHeader = "<h5 id = """ + oXMLNodeCanale.InnerXml() + "_log" + """>" + "xxx" + "</h5>"
                                    Else
                                        intestazioneHeader = "<h5 id = """ + oXMLNodeCanale.Attributes().ItemOf("labelh5").Value + "_log" + """>" + "xxx" + "</h5>"
                                    End If

                                    rootNode = False
                                End If

                                intestazioneTemp = intestazioneTemp + "<div Class=""span3"">"
                                intestazioneTemp = intestazioneTemp + "<Label Class=""checkbox"" >"
                                If (progressivo = 0) Then
                                    If (oXMLNodeCanale.Attributes().ItemOf("setpointEN") Is Nothing) Then
                                        intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" minLog="""" maxLog="""" setpointen="""" setpointlabel="""" setpointmin="""" setpointmax=""""  graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min =""minlog"" Class=""checkbox""  value=""" + progressivo.ToString + """ checked=""checked"" ><span unit=""" + oXMLNodeCanale.InnerXml() + """  ldlog = """"  id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ></span></span>"
                                    Else
                                        intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox""  maxLog=""" + oXMLNodeCanale.Attributes().ItemOf("max").Value + """ minLog=""" + oXMLNodeCanale.Attributes().ItemOf("min").Value + """ setpointlabel=""" + oXMLNodeCanale.Attributes().ItemOf("setpointLABEL").Value + """ setpointen=""" + oXMLNodeCanale.Attributes().ItemOf("setpointEN").Value + """ setpointmin=""" + oXMLNodeCanale.Attributes().ItemOf("setpointMIN").Value + """ setpointmax=""" + oXMLNodeCanale.Attributes().ItemOf("setpointMAX").Value + """ graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min =""minlog"" Class=""checkbox""  value=""" + progressivo.ToString + """ checked=""checked"" ><span unit=""" + oXMLNodeCanale.InnerXml() + """  ldlog = """"  id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ></span></span>"

                                    End If
                                Else
                                    If (oXMLNodeCanale.Attributes().ItemOf("setpointEN") Is Nothing) Then
                                        intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" minLog="""" maxLog="""" setpointen="""" setpointlabel="""" setpointmin="""" setpointmax=""""  graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min =""minlog"" Class=""checkbox"" value=""" + progressivo.ToString + """  ><span unit=""" + oXMLNodeCanale.InnerXml() + """    ldlog = """"  id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ></span></span>"
                                    Else
                                        intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox""  maxLog=""" + oXMLNodeCanale.Attributes().ItemOf("max").Value + """ minLog=""" + oXMLNodeCanale.Attributes().ItemOf("min").Value + """ setpointlabel=""" + oXMLNodeCanale.Attributes().ItemOf("setpointLABEL").Value + """ setpointen=""" + oXMLNodeCanale.Attributes().ItemOf("setpointEN").Value + """ setpointmin=""" + oXMLNodeCanale.Attributes().ItemOf("setpointMIN").Value + """ setpointmax=""" + oXMLNodeCanale.Attributes().ItemOf("setpointMAX").Value + """  graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min =""minlog"" Class=""checkbox"" value=""" + progressivo.ToString + """  ><span unit=""" + oXMLNodeCanale.InnerXml() + """    ldlog = """"  id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ></span></span>"
                                    End If
                                End If

                                intestazioneTemp = intestazioneTemp + "</label>"
                                intestazioneTemp = intestazioneTemp + "</div>"
                                progressivo = progressivo + 1
                            End If
                            If (attributeDataNodes.Value = "temperature") Then
                                intestazioneTemp = intestazioneTemp + "<div Class=""span3"" id=""" + oXMLNodeCanale.Attributes().ItemOf("enable").Value + "_log_enable"">"
                                intestazioneTemp = intestazioneTemp + "<Label Class=""checkbox"" >"
                                intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" setpointen="""" setpointlabel="""" setpointmin="""" setpointmax="""" graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min ="" minlog"" Class=""checkbox"" value=""" + progressivo.ToString + """  ><span>Temperature</span></span>"
                                intestazioneTemp = intestazioneTemp + "</label>"
                                intestazioneTemp = intestazioneTemp + "</div>"
                                progressivo = progressivo + 1

                            End If
                            If (attributeDataNodes.Value = "alarm") Then
                                If (oXMLNodeCanale.Attributes().ItemOf("enable") Is Nothing) Then
                                    intestazioneTemp = intestazioneTemp + "<div Class=""span3"">"
                                Else
                                    intestazioneTemp = intestazioneTemp + "<div Class=""span3"" id=""" + oXMLNodeCanale.Attributes().ItemOf("enable").Value + "_log_enable"">"
                                End If

                                intestazioneTemp = intestazioneTemp + "<Label Class=""checkbox"" >"
                                intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox""  graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min ="" minlog""  Class=""checkbox"" value=""" + progressivo.ToString + """  ><span unit=""" + oXMLNodeCanale.InnerXml() + """    ldlog = """"  id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ></span></span>"
                                intestazioneTemp = intestazioneTemp + "</label>"
                                intestazioneTemp = intestazioneTemp + "</div>"
                                progressivo = progressivo + 1
                            End If
                            If (attributeDataNodes.Value = "digital") Then
                                intestazioneTemp = intestazioneTemp + "<div Class=""span3"">"
                                intestazioneTemp = intestazioneTemp + "<Label Class=""checkbox"" >"
                                intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox""  graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = """" min ="" minlog""  Class=""checkbox"" value=""" + progressivo.ToString + """  ><span unit=""" + oXMLNodeCanale.InnerXml() + """    ldlog = """"  id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ></span></span>"
                                intestazioneTemp = intestazioneTemp + "</label>"
                                intestazioneTemp = intestazioneTemp + "</div>"
                                progressivo = progressivo + 1
                            End If
                            If (attributeDataNodes.Value = "hide") Then ' campo nascosto
                                intestazioneTemp = intestazioneTemp + "<div Class=""span3"">"
                                intestazioneTemp = intestazioneTemp + "<input manualRemote = ""no"" calib = ""no"" type =""checkbox""  graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """  reference=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check""  ldlog = ""ldlog"" min =""minlog""  Class=""checkbox"" value=""" + progressivo.ToString + """ style=""display:none"" >"
                                intestazioneTemp = intestazioneTemp + "</div>"
                            End If

                        End If
                    Next
                    intestazione = intestazione + intestazioneHeader + intestazioneTemp + "</div>" 'chiusura row fluid
                End If

                If oXMLNodeSub.name = "global" Then
                    intestazioneTemp = "<div Class=""row-fluid"">"
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                        If (oXMLNodeCanale.name <> "#comment") Then

                            If (attributeDataNodes.Value = "probe") Then
                                'header
                                intestazioneHeader = "<h5>" + "Water Meters" + "</h5>"
                                intestazioneTemp = intestazioneTemp + "<div Class=""span3"">"
                                intestazioneTemp = intestazioneTemp + "<Label Class=""checkbox"" >"
                                If (progressivo = 0) Then
                                    intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" setpointen="""" setpointlabel="""" setpointmin="""" setpointmax="""" type=""checkbox"" graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check"" ldlog = """" min =""minlog"" Class=""checkbox""  value=""" + progressivo.ToString + """ checked=""checked"" ><span  unit=""" + oXMLNodeCanale.InnerXml() + """   id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ldlog = """" ></span></span>"
                                Else
                                    intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" setpointen="""" setpointlabel="""" setpointmin="""" setpointmax="""" type=""checkbox"" graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check"" ldlog = """" min =""minlog"" Class=""checkbox"" value=""" + progressivo.ToString + """  ><span unit=""" + oXMLNodeCanale.InnerXml() + """   id=""" + oXMLNodeCanale.Attributes().ItemOf("label").Value + "_log_label"" ldlog = """" ></span></span>"
                                End If

                                intestazioneTemp = intestazioneTemp + "</label>"
                                intestazioneTemp = intestazioneTemp + "</div>"
                                progressivo = progressivo + 1
                            End If
                        End If
                    Next
                    intestazione = intestazione + intestazioneHeader + intestazioneTemp + "</div>" 'chiusura row fluid
                End If
                If oXMLNodeSub.name = "flow" Then
                    intestazioneTemp = "<div Class=""row-fluid"">"
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                        If (oXMLNodeCanale.name <> "#comment") Then

                            If (attributeDataNodes.Value = "alarm") Then
                                'header
                                intestazioneHeader = "<h5>" + "Flow Alarm" + "</h5>"
                                intestazioneTemp = intestazioneTemp + "<div Class=""span3"">"
                                intestazioneTemp = intestazioneTemp + "<Label Class=""checkbox"" >"
                                If (progressivo = 0) Then
                                    intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check"" ldlog = """" min =""minlog"" Class=""checkbox""  value=""" + progressivo.ToString + """ checked=""checked"" ><span>Flow Alarm</span></span>"
                                Else
                                    intestazioneTemp = intestazioneTemp + "<span Class=""ricerca""><input manualRemote = ""no"" calib = ""no"" type=""checkbox"" graph=""" + oXMLNodeCanale.Attributes().ItemOf("graph").Value + """ id=""" + oXMLNodeCanale.InnerXml() + "_log_check"" ldlog = """" min =""minlog"" Class=""checkbox"" value=""" + progressivo.ToString + """  ><span >Flow Alarm</span></span>"
                                End If

                                intestazioneTemp = intestazioneTemp + "</label>"
                                intestazioneTemp = intestazioneTemp + "</div>"
                                progressivo = progressivo + 1
                            End If
                        End If
                    Next
                    intestazione = intestazione + intestazioneHeader + intestazioneTemp + "</div>" 'chiusura row fluid
                End If
nexLoopLabel:

                    Next
        Next

        If ldLodg Then
            intestazione = intestazione + "<div Class=""row-fluid""> <h5>" + "Report Tank" + "</h5>"
            intestazione = intestazione + "<div Class=""span3"">"
            intestazione = intestazione + "<input manualRemote = ""no"" calib = ""no"" type=""radio""  min =""minlog"" id=""radiodisableldlog"" name=""radioLaser"" checked  > "
            intestazione = intestazione + "<Label Class=""radio""> Disable </label><br>"

            intestazione = intestazione + "<input manualRemote = ""no"" calib = ""no"" type=""radio""  min =""minlog"" id=""radiodayldlog"" name=""radioLaser"" > "
            intestazione = intestazione + " <Label Class=""radio"">Daily </label><br>"
            intestazione = intestazione + "<input manualRemote = ""no"" calib = ""no"" type=""radio""  min =""minlog"" id=""radiomonthldlog"" name=""radioLaser""  > "
            intestazione = intestazione + " <Label Class=""radio"">Monthly </label><br>"
            intestazione = intestazione + "<input manualRemote = ""no"" calib = ""no"" type=""radio""  min =""minlog"" id=""radioyearldlog"" name=""radioLaser""  > "
            intestazione = intestazione + " <Label Class=""radio"">Yearly </label><br>"
            intestazione = intestazione + "</div>"
            intestazione = intestazione + "</div>"
        End If

        intestazione = intestazione + "<div Class=""row-fluid""> <h5>" + GetGlobalResourceObject("centurio_global", "range") + "</h5>"
        intestazione = intestazione + "<div Class=""span3"">"
        Dim data_prima_date As Date = Now
        intestazione = intestazione + "<h5>" + GetGlobalResourceObject("centurio_global", "from") + "</h5><input manualRemote = ""no"" calib = ""no"" data-placement=""right"" type = ""text"" value = """ + data_prima_date.ToString("dd-MM-yyyy") + """  id = ""logFrom"" min =""minlog""></input>"
        javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_date_picker('logFrom');"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div Class=""span3"">"
        'intestazione = intestazione + "<h5>" + "To" + "</h5><input data-placement=""right"" type = ""text""  id = ""logTo""></input>"
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_date_picker('logTo');"
        intestazione = intestazione + "<h5>" + GetGlobalResourceObject("centurio_global", "days") + "</h5>"



        intestazione = intestazione + "<Select manualRemote = ""no"" calib = ""no"" id=""logTypeDays"" data-original-title=""Log Type"" data-placement=""right""  min =""minlog"" Class=""span3"">"
        For i = 1 To 30
            If i <> 7 Then
                intestazione = intestazione + "<Option value=""" + i.ToString + """ >" + i.ToString + "</Option>"
            Else
                intestazione = intestazione + "<Option value=""" + i.ToString + """ selected>" + i.ToString + "</Option>"
            End If


        Next
        intestazione = intestazione + "</select>"

        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"

        'intestazione = intestazione + "<div class=""row-fluid""><div Class=""widget-head"" style=""background-color:#a4c408;""><button  id=""refreshLog"" class=""btn btn-primary"" style=""margin-top:-0px;"">Refresh Log</button></div></div>"
        intestazione = intestazione + "<div class=""row-fluid""><div class='btn-primary'><b class='btn-primary btn-icon glyphicons ok'><button  id=""refreshLog"" class=""btn btn-primary"" style=""margin-top:-0px;"">Refresh Log</button><i></i></b></div></div>"


        'report
        javaScriptLiteral.Text = javaScriptLiteral.Text + "activate_date_picker('reportFrom'); activate_date_picker('reportTo');"



        Return intestazione
    End Function
    Public Function disegnaPreCanale(ByVal LstNodes As XmlNodeList) As String
        Dim intestazioneBodySuper As String = ""

        Dim intestazioneBodySuperInput As String = ""
        Dim intestazioneBodySuperOut As String = ""
        Dim intestazioneBodySuperAlarm As String = ""
        Dim intestazioneBodySuperGeneric As String = ""
        Dim label As String = ""
        intestazioneBodySuper = intestazioneBodySuper + "<div Class=""row-fluid"">"

        intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "<div Class=""span6"" id = ""areainoutalarm"" style=""background-color:white;text-align:center;display:none"">Alarm"

        intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "<ul Class=""unstyled alarm"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"


        intestazioneBodySuperInput = intestazioneBodySuperInput + "<div Class=""span6"" id = ""areainoutinput"" style=""background-color:white;text-align:center;display:none"">Input"

        intestazioneBodySuperInput = intestazioneBodySuperInput + "<ul Class=""unstyled level"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"
        intestazioneBodySuperOut = intestazioneBodySuperOut + "<div Class=""span6"" id = ""areainoutoutput"" style=""background-color:white;text-align:center;display:none"">Output"

        intestazioneBodySuperOut = intestazioneBodySuperOut + "<ul Class=""unstyled output"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"

        intestazioneBodySuperGeneric = intestazioneBodySuperGeneric + "<div Class=""span6"" id = ""areainoutgeneric"" style=""background-color:white;text-align:center;display:none"">  "

        intestazioneBodySuperGeneric = intestazioneBodySuperGeneric + "<ul Class=""unstyled output"" style=""padding-left:20px;padding-top: 10px;padding-bottom: 10px;"">"

        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList

            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                Dim attributeDataNodes As XmlAttribute
                If (oXMLNodeSub.name <> "#comment") Then
                    attributeDataNodes = oXMLNodeSub.Attributes().ItemOf("type")
                    If (attributeDataNodes.Value = "input") Then
                        intestazioneBodySuperInput = intestazioneBodySuperInput + "<li id = ""areainoutinput" + oXMLNodeSub.InnerXml() + """ Class=""glyphicons glyphicons chevron-right"""

                        'glyphicons circle_arrow_right //output
                        'glyphicons chevron-right //input

                        'intestazioneBodySuper = intestazioneBodySuper + "<div id = ""areainout" + elemntAlarm + """ Class=""widget"" style=""display:none"">"
                        'intestazioneBodySuper = intestazioneBodySuper + "<div Class=""widget-head"" style=""background-color:white;""><h3 class=""heading"">Out</h3></div>"
                        'intestazioneBodySuper = intestazioneBodySuper + "<div  id = ""areainout" + elemntAlarm + """ Class=""widget-body"" style=""display:none"">asdasdasdasda</div>"
                        'intestazioneBodySuper = intestazioneBodySuper + "</div>"

                        'intestazione = intestazione + "<div id = ""global" + elemntAlarm + """ Class=""widget-head"" style=""background-color:#c33;display:none"">"
                        'intestazione = intestazione + "<h4  id = ""global" + listaAllarmiGlobalLabel.Item(indiceLabel) + """ class=""center"">pH Canale</h4> </div>"
                        label = oXMLNodeSub.Attributes().ItemOf("label").Value
                        intestazioneBodySuperInput = intestazioneBodySuperInput + "label=""areainoutinput" + label + """><i></i></li>"

                    End If
                    'If (attributeDataNodes.Value = "inputLabel") Then
                    '    label = (oXMLNodeSub.InnerXml())
                    '    intestazioneBodySuperInput = intestazioneBodySuperInput + "label=""areainoutinput" + label + """><i></i></li>"
                    'End If
                    If (attributeDataNodes.Value = "out") Then
                        If oXMLNodeSub.Attributes().ItemOf("enable") IsNot Nothing Then
                            intestazioneBodySuperOut = intestazioneBodySuperOut + "<li id = ""areainoutoutput" + oXMLNodeSub.InnerXml() + """ Class=""glyphicons circle_arrow_right"""
                            label = oXMLNodeSub.Attributes().ItemOf("label").Value
                            intestazioneBodySuperOut = intestazioneBodySuperOut + "label=""areainoutoutput" + label + """ enable=""" + oXMLNodeSub.Attributes().ItemOf("enable").ToString + """><i></i></li>"

                        Else
                            intestazioneBodySuperOut = intestazioneBodySuperOut + "<li id = ""areainoutoutput" + oXMLNodeSub.InnerXml() + """ Class=""glyphicons circle_arrow_right"""
                            label = oXMLNodeSub.Attributes().ItemOf("label").Value
                            intestazioneBodySuperOut = intestazioneBodySuperOut + "label=""areainoutoutput" + label + """ enable=""""><i></i></li>"
                        End If



                    End If
                        'If (attributeDataNodes.Value = "outLabel") Then
                        '    label = (oXMLNodeSub.InnerXml())

                        '    intestazioneBodySuperOut = intestazioneBodySuperOut + "label=""areainoutoutput" + label + """><i></i></li>"
                        'End If

                        If (attributeDataNodes.Value = "alarm") Then
                        intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "<li id = ""areainoutalarm" + oXMLNodeSub.InnerXml() + """ Class=""glyphicons circle_exclamation_mark"""
                        label = oXMLNodeSub.Attributes().ItemOf("label").Value
                        intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "label=""areainoutalarm" + label + """><i></i></li>"

                    End If
                    If (attributeDataNodes.Value = "generic") Then
                        intestazioneBodySuperGeneric = intestazioneBodySuperGeneric + "<li id = ""areainoutgeneric" + oXMLNodeSub.InnerXml() + """ Class=""glyphicons glyphicons chevron-right"""
                        label = oXMLNodeSub.Attributes().ItemOf("label").Value
                        intestazioneBodySuperGeneric = intestazioneBodySuperGeneric + "label=""areainoutgeneric" + label + """><i></i></li>"

                    End If

                    'If (attributeDataNodes.Value = "alarmLabel") Then
                    '    label = (oXMLNodeSub.InnerXml())
                    '    intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "label=""areainoutalarm" + label + """><i></i></li>"
                    'End If

                End If
            Next

        Next
        intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "</ul>"
        intestazioneBodySuperAlarm = intestazioneBodySuperAlarm + "</div>"
        intestazioneBodySuperInput = intestazioneBodySuperInput + "</ul>"
        intestazioneBodySuperInput = intestazioneBodySuperInput + "</div>"
        intestazioneBodySuperOut = intestazioneBodySuperOut + "</ul>"
        intestazioneBodySuperOut = intestazioneBodySuperOut + "</div>"
        intestazioneBodySuperGeneric = intestazioneBodySuperGeneric + "</ul>"
        intestazioneBodySuperGeneric = intestazioneBodySuperGeneric + "</div>"

        intestazioneBodySuper = intestazioneBodySuper + intestazioneBodySuperGeneric + intestazioneBodySuperAlarm + intestazioneBodySuperInput + intestazioneBodySuperOut + "</div>  "


        listBody.Text = intestazioneBodySuper


    End Function
    Public Function disegnaTimer(ByVal LstNodes As XmlNodeList, ByRef labeleSingleTimer As String, ByRef timerVariable As String) As Integer
        Dim numeroTimer As Integer = 0
        Dim i As Integer
        For Each oXMLNode In LstNodes
            Dim LstNodesSub As XmlNodeList
            LstNodesSub = oXMLNode.childNodes()
            For Each oXMLNodeSub In LstNodesSub
                Dim LstNodesCanale As XmlNodeList
                LstNodesCanale = oXMLNodeSub.childNodes()
                If oXMLNodeSub.name = "timer" Then
                    timerEnableModule.Visible = True
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                        If (attributeDataNodes.Value = "timer") Then
                            numeroTimer = Val(oXMLNodeCanale.Attributes().ItemOf("numberTimer").Value)
                            timerVariable = oXMLNodeCanale.InnerXml()
                        End If
                        If (attributeDataNodes.Value = "label") Then
                            labeleSingleTimer = labeleSingleTimer + oXMLNodeCanale.InnerXml() + ","
                        End If
                    Next
                    For i = 1 To numeroTimer
                        footerText.Text = footerText.Text + "<canvas class=""span2"" id = ""footerCanvas" + i.ToString + """ width=""140"" height=""200"" style= ""width: 100%;max-width: 140px;"">"
                        footerText.Text = footerText.Text + "</canvas>"
                    Next
                End If
            Next
        Next
        Return numeroTimer
    End Function

    Public Function disegnaCanale(ByVal LstNodes As XmlNodeList, ByVal LstNodesSp As XmlNodeList, ByVal listaAllarmiGlobal As List(Of String), ByVal listaAllarmiGlobalLabel As List(Of String), ByVal filter As String, ByVal sistemaUSA As String) As Integer
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "var bodyVarCanvas0= new CanvasNew('#bodyCanvas0' , '#canale0','PH',7.54,14,10,6,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);"
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "var bodyVarCanvas1= new CanvasNew('#bodyCanvas1' , '#canale1','PH',7.54,14,10,6,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);"
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "var bodyVarCanvas2= new CanvasNew('#bodyCanvas2' , '#canale2','PH',7.54,14,10,6,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);"
        'javaScriptLiteral.Text = javaScriptLiteral.Text + "var bodyVarCanvas3= new CanvasNew('#bodyCanvas3' , '#canale3','PH',7.54,14,10,6,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);"

        Dim intestazioneBody As String = ""
        Dim indiceCanale As Integer = 0
        Dim numeroHeader As Integer = 0
        Dim tipoCanale As String = ""
        Dim currentCanale As String = ""
        Dim numeroSonda As String = ""
        Dim strumentoTouch As Integer = 1
        Dim multiparameter As Boolean = False
        'blocco status general

        '<div Class="span6" style="text-align:center">
        '	                        Allarmi
        '		                        <ul Class="unstyled alarm" style="padding-left:20px;padding-top: 10px;padding-bottom: 10px;">
        '						                        <li Class="glyphicons circle_exclamation_mark"><i></i>Allarme 1</li>
        '						                        <li Class="glyphicons circle_exclamation_mark"><i></i>Allarme 2</li>
        '						                        <li Class="glyphicons circle_exclamation_mark"><i></i>Allarme 3</li>
        '		                        </ul>
        '	                        </div>
        '                            <div Class="span6" style="text-align:center">Uscite
        '					                        <ul Class="unstyled output" style="padding-left:20px;padding-top: 10px;padding-bottom: 10px;">
        '						                        <li Class="glyphicons circle_arrow_right"><i></i>Allarme 1</li>
        '						                        <li Class="glyphicons circle_arrow_right"><i></i>Allarme 2</li>
        '						                        <li Class="glyphicons circle_arrow_right"><i></i>Allarme 3</li>
        '		                        </ul>
        '                                                    </div>



        'blocco body impianto
        'filter = "5|11|0|1|0|"
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
                            If (v.IndexOf("-x") > 0) Or (v.IndexOf("-96") > 0) Or (v.IndexOf("-97") > 0) Then
                                v = v.Replace("x", "")
                                multiparameter = True
                                For Each v1 As String In filterSplit
                                    If v1.IndexOf("-23") < 0 Then ' controllo solo se non è presente il sensore di pressione differenziale
                                        If (v1.IndexOf(v) >= 0) Then
                                            If (v1.IndexOf("-96") >= 0) Or (v1.IndexOf("-97") >= 0) Then ' verifico se un laser
                                                If v1 = v Then
                                                    currentCanale = v1
                                                    contiene = True
                                                    Exit For
                                                End If
                                            Else
                                                currentCanale = v1
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
                        If Not contiene Then
                            GoTo nexLoopLabel
                        End If
                    End If
                End If

                LstNodesCanale = oXMLNodeSub.childNodes()
                Dim idProbe As String = ""
                Dim idProbeLabel As String = ""
                Dim idProbeTemperature As String = ""
                Dim idProbeTemperatureSetting As String = ""

                Dim idProbeService As String = ""

                Dim idGrandezza As String = ""
                Dim idMinimo As String = ""
                Dim idMassimo As String = ""
                Dim idDigital As String = "'1','2','3','4'"
                Dim digitalCounterVal As Integer = 1

                Dim idDigitalspEn As String = "'1','2','3','4'"
                Dim digitalCounter As Integer = 1
                Dim idDigitalsp1 As String = "'1','2','3','4'"
                Dim digitalsp1Counter As Integer = 1
                Dim idDigitalsp2 As String = "'1','2','3','4'"
                Dim digitalsp2Counter As Integer = 1

                Dim idPercentagesp1 As String = "'1','2','3','4'"
                Dim percentagesp1Counter As Integer = 1
                Dim idPercentagesp2 As String = "'1','2','3','4'"
                Dim percentagesp2Counter As Integer = 1

                Dim idDigitalLabel As String = "'1','2','3','4'"
                Dim digitalLabelCounter As Integer = 1

                Dim idAlarmEn As String = "'1','2'"
                Dim alarmEnCounter As Integer = 1
                Dim idAlarmVal As String = "'1','2'"
                Dim alarmValCounter As Integer = 1

                Dim idAlarmLabel As String = "'1','2'"
                Dim alarmLabelCounter As Integer = 1

                Dim listaAllarmi As List(Of String) = New List(Of String)
                Dim listaAllarmiLabel As List(Of String) = New List(Of String)
                Dim listaOutput As List(Of output) = New List(Of output)
                Dim listaOutputLabel As List(Of String) = New List(Of String)
                Dim listaLivello As List(Of String) = New List(Of String)
                Dim listaLivelloLabel As List(Of String) = New List(Of String)

                Dim indiceReset As Integer = 0

                If oXMLNodeSub.name = "canale" Then
                    For Each oXMLNodeCanale In LstNodesCanale
                        Dim attributeDataNodes As XmlAttribute
                        If (oXMLNodeCanale.name <> "#comment") Then
                            attributeDataNodes = oXMLNodeCanale.Attributes().ItemOf("type")
                            If (attributeDataNodes.Value = "alarm") Or (attributeDataNodes.Value = "alarmB") Then
                                listaAllarmi.Add("body_" + oXMLNodeCanale.InnerXml())
                            End If
                            If (attributeDataNodes.Value = "livello") Or (attributeDataNodes.Value = "livelloB") Then
                                listaLivello.Add("body_" + oXMLNodeCanale.InnerXml())
                            End If

                            If (attributeDataNodes.Value.IndexOf("alarm") >= 0) And (attributeDataNodes.Value.IndexOf("Label") >= 0) Then
                                listaAllarmiLabel.Add("" + oXMLNodeCanale.InnerXml())
                            End If
                            If (attributeDataNodes.Value.IndexOf("livello") >= 0) And (attributeDataNodes.Value.IndexOf("Label") >= 0) Then
                                listaLivelloLabel.Add("" + oXMLNodeCanale.InnerXml())
                            End If

                            If (attributeDataNodes.Value = "digital") Or (attributeDataNodes.Value = "digitalB") Then
                                Dim outputTemp As New output
                                outputTemp.nomeString = "body_" + oXMLNodeCanale.InnerXml()
                                outputTemp.typeValue = True '( true indica digital, false indica proportional)
                                listaOutput.Add(outputTemp)
                            End If
                            If (attributeDataNodes.Value.IndexOf("digital") >= 0) And (attributeDataNodes.Value.IndexOf("Label") >= 0) Then
                                listaOutputLabel.Add("" + oXMLNodeCanale.InnerXml())
                            End If

                            If (attributeDataNodes.Value = "proportional") Or (attributeDataNodes.Value = "proportionalB") Then
                                Dim outputTemp As New output
                                outputTemp.nomeString = "body_" + oXMLNodeCanale.InnerXml()
                                outputTemp.typeValue = False '( true indica digital, false indica proportional)
                                listaOutput.Add(outputTemp)

                            End If
                            If (attributeDataNodes.Value.IndexOf("proportional") >= 0) And (attributeDataNodes.Value.IndexOf("Label") >= 0) Then
                                listaOutputLabel.Add("" + oXMLNodeCanale.InnerXml())
                            End If

                            If (attributeDataNodes.Value = "probe") Then
                                idProbe = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "tipoCanale") Then 'per gli strumenti diversi dal centurio dobbiamo specificare il tipo Canale e numero Sona
                                tipoCanale = oXMLNodeCanale.InnerXml()
                                strumentoTouch = 0

                            End If
                            If (attributeDataNodes.Value = "numeroSonda") Then 'per gli strumenti diversi dal centurio dobbiamo specificare il tipo Canale e numero Sona
                                numeroSonda = oXMLNodeCanale.InnerXml()
                                strumentoTouch = 0
                            End If


                            If (attributeDataNodes.Value = "probelabel") Then
                                idProbeLabel = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "temperature") Then
                                idProbeTemperature = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "temperatureSetting") Then
                                idProbeTemperatureSetting = oXMLNodeCanale.InnerXml()
                            End If

                            If (attributeDataNodes.Value = "service") Then
                                idProbeService = oXMLNodeCanale.InnerXml()
                            End If



                            If (attributeDataNodes.Value = "grandezza") Then
                                idGrandezza = oXMLNodeCanale.InnerXml()
                            End If
                            If (attributeDataNodes.Value = "minimo") Then
                                idMinimo = oXMLNodeCanale.InnerXml()
                                If idMinimo.IndexOf("|") > 0 Then
                                    If currentCanale.IndexOf("-16") > 0 Then
                                        idMinimo = (idMinimo.Split("|"))(1)
                                    Else
                                        idMinimo = (idMinimo.Split("|"))(0)
                                    End If

                                End If
                            End If
                            If (attributeDataNodes.Value = "massimo") Then
                                idMassimo = oXMLNodeCanale.InnerXml()
                                If idMassimo.IndexOf("|") > 0 Then
                                    If currentCanale.IndexOf("-16") > 0 Then
                                        idMassimo = (idMassimo.Split("|"))(1)
                                    Else
                                        idMassimo = (idMassimo.Split("|"))(0)
                                    End If

                                End If
                            End If
                            If (attributeDataNodes.Value = "digitalB") Then ' B sta per indicare se deve essere presente in barra
                                idDigital = idDigital.Replace("'" + digitalCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                'idDigital = oXMLNodeCanale.InnerXml()
                                digitalCounterVal = digitalCounterVal + 1
                            End If
                            If (attributeDataNodes.Value = "proportionalB") Then ' B sta per indicare se deve essere presente in barra
                                idDigital = idDigital.Replace("'" + digitalCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                'idDigital = oXMLNodeCanale.InnerXml()
                                digitalCounterVal = digitalCounterVal + 1
                            End If

                            If (attributeDataNodes.Value = "digitalSetpointenableB") Then ' B sta per indicare se deve essere presente in barra
                                idDigitalspEn = idDigitalspEn.Replace("'" + digitalCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                digitalCounter = digitalCounter + 1
                            End If
                            If (attributeDataNodes.Value = "proportionalSetpointenableB") Then ' B sta per indicare se deve essere presente in barra
                                idDigitalspEn = idDigitalspEn.Replace("'" + digitalCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                digitalCounter = digitalCounter + 1
                            End If
                            If (attributeDataNodes.Value = "digitalSetpoint1") Then
                                idDigitalsp1 = idDigitalsp1.Replace("'" + digitalsp1Counter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                digitalsp1Counter = digitalsp1Counter + 1
                            End If
                            If (attributeDataNodes.Value = "percentageSetpoint1") Then
                                idPercentagesp1 = idPercentagesp1.Replace("'" + percentagesp1Counter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                percentagesp1Counter = percentagesp1Counter + 1
                            End If

                            If (attributeDataNodes.Value = "proportionalSetpoint1") Then
                                idDigitalsp1 = idDigitalsp1.Replace("'" + digitalsp1Counter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                digitalsp1Counter = digitalsp1Counter + 1
                            End If
                            If (attributeDataNodes.Value = "digitalSetpoint2") Then
                                idDigitalsp2 = idDigitalsp2.Replace("'" + digitalsp2Counter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                digitalsp2Counter = digitalsp2Counter + 1
                            End If
                            If (attributeDataNodes.Value = "percentageSetpoint2") Then
                                idPercentagesp2 = idPercentagesp2.Replace("'" + percentagesp2Counter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                percentagesp2Counter = percentagesp2Counter + 1
                            End If

                            If (attributeDataNodes.Value = "proportionalSetpoint2") Then
                                idDigitalsp2 = idDigitalsp2.Replace("'" + digitalsp2Counter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                digitalsp2Counter = digitalsp2Counter + 1
                            End If
                            If (attributeDataNodes.Value = "proportionalSetpointLabelB") Then ' B sta per indicare se deve essere presente in barra
                                'If (oXMLNodeCanale.InnerXml().IndexOf("[")) Then 'path da ricercare nell XML
                                'Else
                                idDigitalLabel = idDigitalLabel.Replace("'" + digitalLabelCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                'End If
                                digitalLabelCounter = digitalLabelCounter + 1
                            End If
                            If (attributeDataNodes.Value = "digitalSetpointLabelB") Then ' B sta per indicare se deve essere presente in barra
                                'If (oXMLNodeCanale.InnerXml().IndexOf("[")) Then 'path da ricercare nell XML
                                'Else
                                idDigitalLabel = idDigitalLabel.Replace("'" + digitalLabelCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                'End If
                                digitalLabelCounter = digitalLabelCounter + 1
                            End If

                            If (attributeDataNodes.Value = "alarmanableB") Then ' B sta per indicare se deve essere presente in barra
                                If (oXMLNodeCanale.InnerXml() <> "null") Then
                                    idAlarmEn = idAlarmEn.Replace("'" + alarmEnCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                End If
                                alarmEnCounter = alarmEnCounter + 1

                            End If
                            If (attributeDataNodes.Value = "alarmsetpointB") Then ' B sta per indicare se deve essere presente in barra
                                If (oXMLNodeCanale.InnerXml() <> "null") Then
                                    idAlarmVal = idAlarmVal.Replace("'" + alarmValCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                End If
                                alarmValCounter = alarmValCounter + 1

                            End If
                            If (attributeDataNodes.Value = "alarmLabelB") Then ' B sta per indicare se deve essere presente in barra
                                If (oXMLNodeCanale.InnerXml() <> "null") Then
                                    idAlarmLabel = idAlarmLabel.Replace("'" + alarmLabelCounter.ToString + "'", "'" + oXMLNodeCanale.InnerXml() + "'")
                                End If
                                alarmLabelCounter = alarmLabelCounter + 1

                            End If

                        End If

                    Next
                    For indiceReset = digitalCounterVal To 4
                        idDigital = idDigital.Replace("'" + indiceReset.ToString + "'", "''")
                    Next
                    For indiceReset = digitalCounter To 4
                        idDigitalspEn = idDigitalspEn.Replace("'" + indiceReset.ToString + "'", "''")
                    Next
                    For indiceReset = digitalsp1Counter To 4
                        idDigitalsp1 = idDigitalsp1.Replace("'" + indiceReset.ToString + "'", "''")
                    Next
                    For indiceReset = percentagesp1Counter To 4
                        idPercentagesp1 = idPercentagesp1.Replace("'" + indiceReset.ToString + "'", "''")
                    Next

                    For indiceReset = digitalsp2Counter To 4
                        idDigitalsp2 = idDigitalsp2.Replace("'" + indiceReset.ToString + "'", "''")
                    Next
                    For indiceReset = percentagesp2Counter To 4
                        idPercentagesp2 = idPercentagesp2.Replace("'" + indiceReset.ToString + "'", "''")
                    Next

                    For indiceReset = alarmEnCounter To 2
                        idAlarmEn = idAlarmEn.Replace("'" + indiceReset.ToString + "'", "''")
                    Next
                    For indiceReset = alarmValCounter To 2
                        idAlarmVal = idAlarmVal.Replace("'" + indiceReset.ToString + "'", "''")
                    Next
                    For indiceReset = alarmLabelCounter To 2
                        idAlarmLabel = idAlarmLabel.Replace("'" + indiceReset.ToString + "'", "''")
                    Next

                    intestazioneBody = intestazioneBody + preparaBody(idProbeLabel, idProbeTemperature, idProbeTemperatureSetting, indiceCanale, listaAllarmi, listaAllarmiLabel, listaOutput, listaOutputLabel, listaLivello, listaLivelloLabel, listaAllarmiGlobal, listaAllarmiGlobalLabel, idProbeService)
                    indiceCanale = indiceCanale + 1

                    ' blocco header impianto java script (canvas water meter)
                    javaScriptLiteral.Text = javaScriptLiteral.Text + "var bodyVarCanvas" + numeroHeader.ToString + "= new CanvasNew('#bodyCanvas" + numeroHeader.ToString + "','#canale" + numeroHeader.ToString + "','#bodyCanvasSub" + numeroHeader.ToString + "','" + idGrandezza + "','" + idProbe + "','" + idMassimo + "','" + idMinimo + "','0'," + idDigital + "," + idDigitalspEn + "," + idDigitalsp1 + "," + idDigitalsp2 + "," + idDigitalLabel + "," + idAlarmEn + "," + idAlarmVal + "," + idAlarmLabel + "," + strumentoTouch.ToString + ",'" + tipoCanale + "','" + numeroSonda + "'," + idPercentagesp1 + "," + idPercentagesp2 + ");"

                    javaScriptLiteral.Text = javaScriptLiteral.Text + "arrayOggettiCanale.push(bodyVarCanvas" + numeroHeader.ToString + ");"

                End If


                ' end blocco header impianto java script
                numeroHeader = numeroHeader + 1

nexLoopLabel:
            Next
        Next



        'blocco body impianto
        If indiceCanale Mod 3 <> 0 Then
            intestazioneBody = intestazioneBody + "</div>"
        End If






        listBody.Text = listBody.Text + intestazioneBody
        'end blocco body

        Return strumentoTouch


    End Function


End Class