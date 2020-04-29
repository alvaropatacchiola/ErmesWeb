
Imports System.IO
Imports System.Xml

Public Class mainFunctionCenturio
    Public Shared Function getConfigCentrurio(ByVal serialNumber) As String
        Dim pipeClient As New centurioRealTime
        Dim resultPipe As String = ""
        resultPipe = pipeClient.Main(serialNumber)
        If resultPipe <> "null" Then
            Dim pipeSplit() As String = resultPipe.Split("$")
            For Each pipeValue In pipeSplit
                If pipeValue.IndexOf(":") >= 0 Then
                    Dim pipeValueSplit() As String = pipeValue.Split(":")
                    If (pipeValueSplit(0).IndexOf("centurioIDR") >= 0) Then
                        Return pipeValueSplit(1)
                    End If
                    'centurioInputR
                    'centurioIDR
                End If
            Next
        Else
            Return "null"
        End If
        Return "null"
    End Function
    Public Shared Function getProbeListAll() As List(Of Dictionary(Of String, String))
        Dim tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable
        Dim query As New query
        Dim oXMLDoc As XmlDocument = New XmlDocument
        Dim listLogFinal As New List(Of Dictionary(Of String, String))
        tabella_probeList = query.getProbeType("probeList")
        For Each dc1 In tabella_probeList
            oXMLDoc.LoadXml(dc1.xmlFile_en)
            Dim LstNodes As XmlNodeList
            LstNodes = oXMLDoc.GetElementsByTagName("valore")

            For Each oXMLNode In LstNodes
                'attributeDataNodesCanale = oXMLNode.Attributes().ItemOf("tipoCanale")
                'attributeDataNodesSonda = oXMLNode.Attributes().ItemOf("numeroSonda")
                Dim listLogTemp As New Dictionary(Of String, String)
                Try
                    listLogTemp.Add("tipoCanale", oXMLNode.Attributes().ItemOf("tipoCanale").Value)
                    listLogTemp.Add("numeroSonda", oXMLNode.Attributes().ItemOf("numeroSonda").Value)
                    listLogTemp.Add("name", oXMLNode.Attributes().ItemOf("name").Value)
                    listLogTemp.Add("grandezza", oXMLNode.Attributes().ItemOf("grandezza").Value)
                    listLogTemp.Add("unitEu", oXMLNode.Attributes().ItemOf("unitEu").Value)
                    listLogTemp.Add("unitUSA", oXMLNode.Attributes().ItemOf("unitUSA").Value)
                    listLogTemp.Add("minimo", oXMLNode.Attributes().ItemOf("minimo").Value)
                    listLogTemp.Add("massimo", oXMLNode.Attributes().ItemOf("massimo").Value)
                    listLogTemp.Add("decimali", oXMLNode.Attributes().ItemOf("decimali").Value)
                    listLogTemp.Add("zeroCalib", oXMLNode.Attributes().ItemOf("zeroCalib").Value)
                    listLogTemp.Add("tipoSonda", oXMLNode.InnerXml())
                    Dim pippo As String = oXMLNode.Attributes().ItemOf("tipoCanale").Value
                    If (oXMLNode.Attributes().ItemOf("tipoCanale").Value = "16") Then
                        listLogTemp.Add("tipoCanale", "161")
                        listLogTemp.Add("numeroSonda", oXMLNode.Attributes().ItemOf("numeroSonda").Value)
                        listLogTemp.Add("name", oXMLNode.Attributes().ItemOf("name").Value)
                        listLogTemp.Add("grandezza", oXMLNode.Attributes().ItemOf("grandezza").Value)
                        listLogTemp.Add("unitEu", oXMLNode.Attributes().ItemOf("unitEu").Value)
                        listLogTemp.Add("unitUSA", oXMLNode.Attributes().ItemOf("unitUSA").Value)
                        listLogTemp.Add("minimo", oXMLNode.Attributes().ItemOf("minimo").Value)
                        listLogTemp.Add("massimo", oXMLNode.Attributes().ItemOf("massimo").Value)
                        listLogTemp.Add("decimali", oXMLNode.Attributes().ItemOf("decimali").Value)
                        listLogTemp.Add("zeroCalib", oXMLNode.Attributes().ItemOf("zeroCalib").Value)
                        listLogTemp.Add("tipoSonda", oXMLNode.InnerXml())

                    End If
                Catch ex As Exception

                End Try
                listLogFinal.Add(listLogTemp)
            Next

        Next
        Return listLogFinal

    End Function
    Public Shared Function getProbeList(ByVal numeroCanale As String, ByVal tipoSonda As String) As Dictionary(Of String, String)
        Dim tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable
        Dim query As New query
        Dim oXMLDoc As XmlDocument = New XmlDocument

        'tabella_probeList = query.getProbeList("probeList")
        tabella_probeList = query.getProbeType("probeList")
        For Each dc1 In tabella_probeList
            oXMLDoc.LoadXml(dc1.xmlFile_en)
            Dim LstNodes As XmlNodeList
            LstNodes = oXMLDoc.GetElementsByTagName("valore")
            For Each oXMLNode In LstNodes
                Dim attributeDataNodesCanale As XmlAttribute
                Dim attributeDataNodesSonda As XmlAttribute
                attributeDataNodesCanale = oXMLNode.Attributes().ItemOf("tipoCanale")
                attributeDataNodesSonda = oXMLNode.Attributes().ItemOf("numeroSonda")
                Dim listLogTemp As New Dictionary(Of String, String)

                If (attributeDataNodesCanale.Value = numeroCanale) And (attributeDataNodesSonda.Value = tipoSonda) Then
                    listLogTemp.Add("name", oXMLNode.Attributes().ItemOf("name").Value)
                    listLogTemp.Add("grandezza", oXMLNode.Attributes().ItemOf("grandezza").Value)
                    listLogTemp.Add("unitEu", oXMLNode.Attributes().ItemOf("unitEu").Value)
                    listLogTemp.Add("unitUSA", oXMLNode.Attributes().ItemOf("unitUSA").Value)
                    listLogTemp.Add("minimo", oXMLNode.Attributes().ItemOf("minimo").Value)
                    listLogTemp.Add("massimo", oXMLNode.Attributes().ItemOf("massimo").Value)
                    listLogTemp.Add("decimali", oXMLNode.Attributes().ItemOf("decimali").Value)
                    listLogTemp.Add("zeroCalib", oXMLNode.Attributes().ItemOf("zeroCalib").Value)
                    listLogTemp.Add("tipoSonda", oXMLNode.InnerXml())

                    Return listLogTemp
                End If
            Next
        Next
        Return Nothing
    End Function
    Public Shared Function getResultXml(ByVal nomeXml As String, ByVal language As String, ByVal tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable) As List(Of Dictionary(Of String, String))
        'Dim tabella_probeList As ermes_web_20.centurioQuery.xmlConfigDataTable
        Dim query As New query
        Dim oXMLDoc As XmlDocument = New XmlDocument
        Dim listLogTemp As New List(Of Dictionary(Of String, String))
        '
        ' tabella_probeList = query.getProbeList(nomeXml)
        For Each dc1 In tabella_probeList
            If dc1.label = nomeXml Then
                Select Case language
                    Case "en"
                        oXMLDoc.LoadXml(dc1.xmlFile_en)
                    Case "it"
                        oXMLDoc.LoadXml(dc1.xmlFile_it)
                    Case "de"
                        oXMLDoc.LoadXml(dc1.xmlFile_de)
                    Case "ru"
                        oXMLDoc.LoadXml(dc1.xmlFile_ru)
                    Case "es"
                        oXMLDoc.LoadXml(dc1.xmlFile_es)

                    Case Else
                        oXMLDoc.LoadXml(dc1.xmlFile_en)
                End Select


                Dim LstNodes As XmlNodeList
                LstNodes = oXMLDoc.GetElementsByTagName("valore")
                For Each oXMLNode In LstNodes
                    Dim logTemp As New Dictionary(Of String, String)
                    logTemp.Add("name", oXMLNode.Attributes().ItemOf("name").Value)
                    logTemp.Add("index", oXMLNode.Attributes().ItemOf("index").Value)
                    logTemp.Add("valore", oXMLNode.InnerXml())
                    listLogTemp.Add(logTemp)
                Next
                Exit For
            End If
        Next
        Return listLogTemp

    End Function
    Public Shared Function getFileInfoXML(ByVal serialNumber As String, ByVal strinxXML As String, ByVal idXML As Integer) As String
        'Dim xmlDocument As String = File.ReadAllText("C:\Users\alvaro.patacchiola\Documents\Visual Studio 2015\Projects\ermes-web_20\ermes-web_20\bin\setting.xml")
        'Dim xmlDocument As String = File.ReadAllText("C:\inetpub\wwwroot\ermes\bin\setting.xml")
        Dim oXMLDoc As XmlDocument = New XmlDocument
        oXMLDoc.LoadXml(strinxXML)
        Dim LstNodes As XmlNodeList
        LstNodes = oXMLDoc.GetElementsByTagName("serialnumber")
        For Each oXMLNode In LstNodes
            Dim attributeDataNodes As XmlAttribute
            attributeDataNodes = oXMLNode.Attributes().ItemOf("id")
            If (attributeDataNodes.Value = serialNumber) Then
                Dim LstNodesSub As XmlNodeList
                LstNodesSub = oXMLNode.childNodes()
                Return LstNodesSub.Item(idXML).InnerXml
                'LstNodesSub.Item()

            End If

        Next
        Return ""
    End Function
    Public Shared Function preparaLabelJSNoTouch(ByVal LstNodes As XmlNodeList) As String
        Dim stringJson As String = "{"
        Dim virgola As String = ""
        Dim LstNodesComponenti As XmlNodeList
        For Each oXMLNode In LstNodes
            LstNodesComponenti = oXMLNode.ChildNodes
            For Each oXMLNodeN In LstNodesComponenti
                Dim attributeDataNodes As XmlAttribute
                attributeDataNodes = oXMLNodeN.Attributes().ItemOf("id")
                If attributeDataNodes IsNot Nothing Then
                    stringJson = stringJson + virgola + """" + attributeDataNodes.Value + """:""" + oXMLNodeN.InnerXml() + """"
                    virgola = ","
                End If
            Next
        Next
        stringJson = stringJson + "}"
        Return stringJson

    End Function
    Public Shared Function preparaLabelJS(ByVal LstNodes As XmlNodeList, ByVal filter As String) As String
        Dim stringJson As String = "{"
        Dim virgola As String = ""
        For Each oXMLNode In LstNodes
            Try

                'Dim nomeLAttributeIstanza As String = oXMLNode.Attributes().ItemOf("nome").Value

                If filter <> "" Then

                    Dim contiene As Boolean = False
                    Dim attributeDataConfig As XmlAttribute
                    attributeDataConfig = oXMLNode.Attributes().ItemOf("channel")
                    If attributeDataConfig IsNot Nothing Then
                        Dim attributeDataConfigSplit() As String = attributeDataConfig.Value.Split("|")
                        Dim filterSplit() As String = filter.Split("|")
                        For Each v As String In attributeDataConfigSplit
                            If filterSplit.ToList.IndexOf(v) >= 0 Or v = "xx" Then
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

                Dim nomeAttributeIstanza As XmlAttribute = oXMLNode.Attributes().ItemOf("labels")
                If nomeAttributeIstanza IsNot Nothing Then
                    stringJson = stringJson + virgola + """" + nomeAttributeIstanza.Value + """:""" + oXMLNode.InnerXml() + """"
                    virgola = ","
                End If
                Dim LstNodesComponenti As XmlNodeList
                LstNodesComponenti = oXMLNode.childNodes()
                For Each oXMLNodeComponenti In LstNodesComponenti
                    If oXMLNodeComponenti.Attributes().Count > 0 Then
                        Dim nomeAttributeComponenti As XmlAttribute = oXMLNodeComponenti.Attributes().ItemOf("labels")
                        If nomeAttributeComponenti IsNot Nothing Then
                            stringJson = stringJson + virgola + """" + nomeAttributeComponenti.Value + """:""" + oXMLNodeComponenti.InnerXml() + """"
                            virgola = ","
                        End If
                        If oXMLNodeComponenti.Name = "Componenti" Then
                            Dim LstNodesValore As XmlNodeList
                            LstNodesValore = oXMLNodeComponenti.childNodes()
                            For Each oXMLNodeValore In LstNodesValore
                                If oXMLNodeValore.Name <> "#comment" Then
                                    If oXMLNodeValore.Attributes().Count > 0 Then
                                        Dim nomeAttributeValore As XmlAttribute = oXMLNodeValore.Attributes().ItemOf("labels")
                                        If nomeAttributeValore IsNot Nothing Then
                                            stringJson = stringJson + virgola + """" + nomeAttributeValore.Value + """:""" + oXMLNodeValore.InnerXml() + """"
                                            virgola = ","
                                        End If
                                        If oXMLNodeValore.Name = "ListaValore" Then
                                            Dim LstNodesSub As XmlNodeList
                                            LstNodesSub = oXMLNodeValore.childNodes()
                                            For Each oXMLNodeSub In LstNodesSub
                                                If oXMLNodeSub.Name <> "#comment" Then
                                                    If oXMLNodeSub.Attributes().Count > 0 Then
                                                        Dim nomeAttributeSub As XmlAttribute = oXMLNodeSub.Attributes().ItemOf("labels")
                                                        If nomeAttributeSub IsNot Nothing Then
                                                            stringJson = stringJson + virgola + """" + nomeAttributeSub.Value + """:""" + oXMLNodeSub.InnerXml() + """"
                                                            virgola = ","
                                                        End If
                                                        If oXMLNodeSub.Name = "ListaSub" Then
                                                            Dim LstNodesSub1 As XmlNodeList
                                                            LstNodesSub1 = oXMLNodeSub.childNodes()
                                                            For Each oXMLNodeSub1 In LstNodesSub1
                                                                If oXMLNodeSub1.Name <> "#comment" Then
                                                                    If oXMLNodeSub1.Attributes().Count > 0 Then
                                                                        Dim nomeAttributeSub1 As XmlAttribute = oXMLNodeSub1.Attributes().ItemOf("labels")
                                                                        If nomeAttributeSub1 IsNot Nothing Then
                                                                            stringJson = stringJson + virgola + """" + nomeAttributeSub1.Value + """:""" + oXMLNodeSub1.InnerXml() + """"
                                                                            virgola = ","
                                                                        End If
                                                                    End If
                                                                End If
                                                            Next
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            Catch ex As Exception

            End Try

nexLoopLabel:
        Next
        stringJson = stringJson + "}"
        Return stringJson
    End Function
End Class
