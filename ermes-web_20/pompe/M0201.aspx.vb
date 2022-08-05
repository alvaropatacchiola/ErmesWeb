Public Class M0201
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim serial_impianto As String = ""
        Dim javaScriptText As String
        serial_impianto = Page.Request("serial")
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim nomeImpiantoString As String = " "
        Dim referenteImpiantoString As String = " "
        Dim numeroTelefonoString As String = " "
        Dim indirizzoMailString As String = " "
        Dim identificativoUser As String = ""
        Dim setpointUserModify As String = ""
        Dim riga_impianto As ermes_web_20.quey_db.impianto_newRow
        If Not IsPostBack Then

            tabella_impianto = Master.tabella_impianto_container
            Try
                For Each dc In tabella_impianto
                    If dc.identificativo = serial_impianto Then
                        riga_impianto = dc
                        nomeImpiantoString = Replace(riga_impianto.nome_impianto, ">", " : ")
                        Master.setTitle(nomeImpiantoString)

                        referenteImpiantoString = riga_impianto.referente
                        numeroTelefonoString = riga_impianto.telefono_referente
                        indirizzoMailString = riga_impianto.mail_referente
                        identificativoUser = riga_impianto.id_user
                        setpointUserModify = riga_impianto.modifica_setpoint_user1
                    End If
                Next
            Catch ex As Exception

            End Try
            'carico la lista sonde
            Dim listDataSonda As List(Of Dictionary(Of String, String))
            Dim jsonVariableMainCanaleSondaTemp As String = "{""variable"":["
            Dim virgolaJsonMainCanaleSonda As String = ""
            listDataSonda = mainFunctionCenturio.getProbeListAll()
            For Each elementList As Dictionary(Of String, String) In listDataSonda
                jsonVariableMainCanaleSondaTemp = jsonVariableMainCanaleSondaTemp + virgolaJsonMainCanaleSonda + "{""tipoCanale"":""" + elementList.Item("tipoCanale") + """, ""numeroSonda"":""" + elementList.Item("numeroSonda") + """, ""grandezza"":""" + elementList.Item("grandezza") + """, ""unitEu"":""" + elementList.Item("unitEu") + """, ""unitUSA"":""" + elementList.Item("unitUSA") + """,""minimo"":""" + elementList.Item("minimo") + """,""massimo"":""" + elementList.Item("massimo") + """, ""decimali"":""" + elementList.Item("decimali") + """}"
                virgolaJsonMainCanaleSonda = ","
            Next
            jsonVariableMainCanaleSondaTemp = jsonVariableMainCanaleSondaTemp + "]}"
            'end carico la lista sonde

            plantName.Text = nomeImpiantoString
            javaScriptText = "<script type = ""text/javascript"" >"
            javaScriptText = javaScriptText + "var NserialNumber = """ + serial_impianto + """;"
            javaScriptText = javaScriptText + "var NarrayReadRealTime = [1];"
            javaScriptText = javaScriptText + "var NarrayReadSetpoint = [1, 2, 3, 4];"
            javaScriptText = javaScriptText + "var Nlanguage = '" + Session("selectedLanguage") + "';"
            javaScriptText = javaScriptText + "var NplantName = """ + nomeImpiantoString + """;"

            javaScriptText = javaScriptText + "var PompaOggetto = new OggettoPompa({serialNumber: NserialNumber, arrayReadRealTime: NarrayReadRealTime, arrayReadAll: NarrayReadSetpoint ,languageSet:Nlanguage,plantName:NplantName});"
            javaScriptText = javaScriptText + "PompaOggetto.createConnection();"
            javaScriptText = javaScriptText + "aggiungiSocket(PompaOggetto );"

            'carico la lista sonde
            javaScriptText = javaScriptText + "jsonParseDecimalStr ='" + jsonVariableMainCanaleSondaTemp + "'; jsonParseListaSonde= JSON.parse(jsonParseDecimalStr);"


            javaScriptText = javaScriptText + "</script>"
            javaScriptHeader.Text = javaScriptText


            Master.pageTitleValue = nomeImpiantoString
        End If
    End Sub

End Class