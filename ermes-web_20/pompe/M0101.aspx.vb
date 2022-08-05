Public Class M0101
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
        Dim weeklyString As String = ""

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
            plantName.Text = nomeImpiantoString
            javaScriptText = "<script type = ""text/javascript"" >"
            javaScriptText = javaScriptText + "var NserialNumber = """ + serial_impianto + """;"
            javaScriptText = javaScriptText + "var NarrayReadRealTime = [1];"
            javaScriptText = javaScriptText + "var NarrayReadSetpoint = [1, 2, 3, 4, 5, 6];"
            javaScriptText = javaScriptText + "var Nlanguage = '" + Session("selectedLanguage") + "';"
            javaScriptText = javaScriptText + "var NplantName = """ + nomeImpiantoString + """;"

            javaScriptText = javaScriptText + "var PompaOggetto = new OggettoPompa({serialNumber: NserialNumber, arrayReadRealTime: NarrayReadRealTime, arrayReadAll: NarrayReadSetpoint ,languageSet:Nlanguage,plantName:NplantName});"
            javaScriptText = javaScriptText + "PompaOggetto.createConnection();"
            javaScriptText = javaScriptText + "aggiungiSocket(PompaOggetto );"
            javaScriptText = javaScriptText + "</script>"
            javaScriptHeader.Text = javaScriptText


            Master.pageTitleValue = nomeImpiantoString
            Dim i As Integer
            Dim k As Integer
            For i = 1 To 24
                weeklyString = weeklyString + "<div Class=""form-group"" aria-haspopup=""True"">"
                weeklyString = weeklyString + "<div Class=""custom-control custom-checkbox d-inline-block mr-3 mb-3"">"
                weeklyString = weeklyString + "<input type = ""checkbox"" Class=""custom-control-input weeklyP"" indice =""" + i.ToString + """ id=""weeklyP" + i.ToString + """ onclick=""$(this).prop('checked') ? $('#weeklyP" + i.ToString + "Group').show() : $('#weeklyP" + i.ToString + "Group').hide()"">"
                weeklyString = weeklyString + "<Label Class=""custom-control-label"" for=""weeklyP" + i.ToString + """ data-translate=""weeklyP" + i.ToString + """></label>"
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "<div id = ""weeklyP" + i.ToString + "Group"" >"
                weeklyString = weeklyString + "<div class=""form-group"" aria-haspopup=""True"">"
                weeklyString = weeklyString + "<label for=""exampleFormControlPassword4"" data-translate=""weeklyStart""></label>"
                weeklyString = weeklyString + "<div class=""input-group mb-3"">"
                weeklyString = weeklyString + "<div class=""input-group-prepend"">"
                weeklyString = weeklyString + "<span class=""input-group-text mdi mdi-clock"" id=""basic-addon1""></span>"
                weeklyString = weeklyString + " </div>"
                weeklyString = weeklyString + "<input type=""text"" class=""form-control timeControll weeklyP"" indice =""" + i.ToString + """ id=""weeklyP" + i.ToString + "Start"" data-mask=""00:00"" labelMSG=""weekTimeInfo"" labelMSGError=""weekTimeAlarm"" placeholder=""00:00"">"
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "<div Class=""form-group"" aria-haspopup=""True"">"
                weeklyString = weeklyString + "<div Class=""custom-control custom-radio d-inline-block mr-3 mb-3"">"
                weeklyString = weeklyString + "<Label for=""exampleFormControlSelect15"" data-translate=""weeklyDurationOreSetpoint""></label>"
                weeklyString = weeklyString + "<Select Class=""form-control rounded-0 bg-light timeControllSelect weeklyP"" indice =""" + i.ToString + """ id=""weeklyP" + i.ToString + "OreSetpoint"">"
                For k = 0 To 24
                    weeklyString = weeklyString + "<option value = """ + k.ToString + """ > " + k.ToString + "</Option>"
                Next
                weeklyString = weeklyString + "</select>"
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "<div Class=""custom-control custom-radio d-inline-block mr-3 mb-3"">"
                weeklyString = weeklyString + "<Label for=""exampleFormControlSelect15"" data-translate=""weeklyDurationMinutiSetpoint""></label>"
                weeklyString = weeklyString + "<Select Class=""form-control rounded-0 bg-light timeControllSelect weeklyP"" indice =""" + i.ToString + """ id=""weeklyP" + i.ToString + "MinutiSetpoint"">"
                For k = 0 To 59
                    weeklyString = weeklyString + "<option value = """ + k.ToString + """ > " + k.ToString + "</Option>"
                Next

                weeklyString = weeklyString + "</select>"
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "<div Class=""form-group "">"
                weeklyString = weeklyString + "<Label for=""exampleFormControlPassword4"" data-translate=""constantSetpoint"" ></label>"
                weeklyString = weeklyString + "<Label for=""exampleFormControlPassword4""  id=""weeklyP" + i.ToString + "DosaggioUnit""></label>"
                weeklyString = weeklyString + "<input type = ""number"" Class=""form-control border-success numerico weeklyP"" indice =""" + i.ToString + """ id=""weeklyP" + i.ToString + "Dosaggio"" min =""0.000"" max =""99.000"" labelMSG=""constantDos"" labelMSGError=""constantDosAlarm"" Step=""0.001"" Decimal =""3"" maxlength=""6"" data-mask=""00.000"" placeholder="""">"
                weeklyString = weeklyString + "</div>"
                For k = 6 To 0 Step -1
                    weeklyString = weeklyString + "<div Class=""custom-control custom-checkbox d-inline-block mr-3 mb-3"">"
                    weeklyString = weeklyString + "<input type = ""checkbox"" Class=""custom-control-input weeklyP"" indice =""" + i.ToString + """ id=""weeklyP" + i.ToString + k.ToString + "D"" >"
                    weeklyString = weeklyString + "<Label Class=""custom-control-label"" for=""weeklyP" + i.ToString + k.ToString + "D"" data-translate=""weeklyP" + k.ToString + "D""></label>"
                    weeklyString = weeklyString + "</div>"

                Next
                weeklyString = weeklyString + "</div>"
                weeklyString = weeklyString + "</div>"


            Next
            weeklyLoadServer.Text = weeklyString

        End If
    End Sub


End Class