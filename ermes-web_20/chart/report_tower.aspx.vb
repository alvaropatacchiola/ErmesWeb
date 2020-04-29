Imports System.Globalization
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class report_tower
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub report_tower_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim init_date As String = ""
        Dim last_date As String = ""
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")

        If Not IsPostBack Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            ' setting cookie
            Try
                If Request.Cookies(codice_impianto + "_" + id_485_impianto + "_report") Is Nothing Then
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_report").Expires = DateTime.Now.AddMonths(12)  ' il cookie dura 1 anno
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_report").Value = set_coockie()

                Else
                    get_coockie(Request.Cookies(codice_impianto + "_" + id_485_impianto + "_report").Value)
                End If
            Catch ex As Exception

            End Try
            posiziona_report(nome_impianto, codice_impianto, id_485_impianto, "SetPoint", init_date, last_date)
        End If
    End Sub
    Public Sub get_coockie(ByVal input As String)
        Dim split_input() As String = input.Split("z")
        ch1_val.Checked = Convert.ToBoolean(split_input(0))
        ch1_high.Checked = Convert.ToBoolean(split_input(1))
        ch1_low.Checked = Convert.ToBoolean(split_input(2))
        ch1_bleed.Checked = Convert.ToBoolean(split_input(3))
        ch1_livello_inhibitor.Checked = Convert.ToBoolean(split_input(4))
        ch1_livello_prebiocide1.Checked = Convert.ToBoolean(split_input(5))
        ch1_livello_prebiocide2.Checked = Convert.ToBoolean(split_input(6))
        ch1_livello_biocide1.Checked = Convert.ToBoolean(split_input(7))
        ch1_livello_biocide2.Checked = Convert.ToBoolean(split_input(8))

        ch2_val.Checked = Convert.ToBoolean(split_input(9))
        ch2_high.Checked = Convert.ToBoolean(split_input(10))
        ch2_low.Checked = Convert.ToBoolean(split_input(11))
        ch2_livello.Checked = Convert.ToBoolean(split_input(12))

        ch3_val.Checked = Convert.ToBoolean(split_input(13))
        ch3_high.Checked = Convert.ToBoolean(split_input(14))
        ch3_low.Checked = Convert.ToBoolean(split_input(15))
        ch3_livello.Checked = Convert.ToBoolean(split_input(16))

        temperature_select.Checked = Convert.ToBoolean(split_input(17))
        flow_select.Checked = Convert.ToBoolean(split_input(18))


    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + ch1_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_high.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_low.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_bleed.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello_inhibitor.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello_prebiocide1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello_prebiocide2.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello_biocide1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello_biocide2.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_high.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_low.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_livello.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch3_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_high.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_low.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_livello.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + temperature_select.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow_select.Checked.ToString
        Return stringa_risultato
    End Function
    Public Sub posiziona_report(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                             ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.log_towerDataTable
        Dim config_value() As String
        Dim version_str As String = ""
        Dim MTower_Type As String = ""
        Dim str_sonda2 As String = ""
        Dim str_sonda3 As String = ""
        Dim set_variable_javascript(21, 1) As String
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script
        Dim function_javascript As String = ""
        Dim query As New query

        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim prima_volta As Boolean = True
        Dim data_prima As String = ""
        Dim data_seconda As String = ""
        Dim personalizzazione_aquacare As Integer = 0

        Dim lunghezza_tabella As Integer

        Dim data_to As Date
        Dim data_from As Date
        If init_date Is Nothing Or last_date Is Nothing Then
            data_to = Now

            data_from = data_to.AddDays(-15)
            data_to = DateAdd(DateInterval.Day, 1, data_to)
        Else
            Dim culture As String = "it-IT"
            Dim data_from_temp As Date
            Dim data_to_temp As Date
            data_from_temp = Date.Parse(init_date, New CultureInfo(culture, False))
            data_to_temp = Date.Parse(last_date, New CultureInfo(culture, False))
            data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day)
            data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)
        End If

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        config_value = main_function.get_split_str(riga_strumento.value4)
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , , , , , str_sonda2, str_sonda3)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)

        Select Case MTower_Type
            Case "Cdxxx"
                ch1_enable.Visible = True
                ch2_enable.Visible = False
                ch3_enable.Visible = False
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + "" + """"
                ch2_val_label.Text = ""
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + "" + """"
                ch3_val_label.Text = ""

            Case "Cd_pH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + "" + """"
                ch3_val_label.Text = ""

            Case "Cd_rH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + "" + """"
                ch3_val_label.Text = ""
            Case "Cd_pH_rH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + str_sonda3 + """"
                ch3_val_label.Text = str_sonda3
            Case "Cd_pH_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + str_sonda3 + """"
                ch3_val_label.Text = str_sonda3
            Case "Cd_trc_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + str_sonda3 + """"
                ch3_val_label.Text = str_sonda3
            Case "Cd_trc_rH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + str_sonda3 + """"
                ch3_val_label.Text = str_sonda3

            Case "Cd_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                set_variable_javascript(19, 0) = "label_ch1"
                set_variable_javascript(19, 1) = """" + "Conductivity" + """"
                ch1_val_label.Text = "Conductivity"
                set_variable_javascript(20, 0) = "label_ch2"
                set_variable_javascript(20, 1) = """" + str_sonda2 + """"
                ch2_val_label.Text = str_sonda2
                set_variable_javascript(21, 0) = "label_ch3"
                set_variable_javascript(21, 1) = """" + "" + """"
                ch3_val_label.Text = ""

        End Select

        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        table_log = query.get_log_tower(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)

        report_head.Text = "<thead>"
        report_head.Text = report_head.Text + "<tr class=""gradeA""> "
        report_head.Text = report_head.Text + "<th>Data</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_val.ID + """>" + ch1_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_high.ID + """>" + ch1_high_label.Text + ch1_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_low.ID + """>" + ch1_low_label.Text + ch1_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_bleed.ID + """>" + ch1_bleed_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_livello_inhibitor.ID + """>" + ch1_livello_inhibitor_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_livello_prebiocide1.ID + """>" + ch1_livello_prebiocide1_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_livello_prebiocide2.ID + """>" + ch1_livello_prebiocide2_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_livello_biocide1.ID + """>" + ch1_livello_biocide1_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_livello_biocide2.ID + """>" + ch1_livello_biocide2_label.Text + "</th>"

        report_head.Text = report_head.Text + "<th class=""" + ch2_val.ID + """>" + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch2_high.ID + """>" + ch2_high_label.Text + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch2_low.ID + """>" + ch2_low_label.Text + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch2_livello.ID + """>" + ch2_livello_label.Text + ch2_val_label.Text + "</th>"

        report_head.Text = report_head.Text + "<th class=""" + ch3_val.ID + """>" + ch3_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch3_high.ID + """>" + ch3_high_label.Text + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch3_low.ID + """>" + ch3_low_label.Text + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch3_livello.ID + """>" + ch3_livello_label.Text + ch2_val_label.Text + "</th>"

        report_head.Text = report_head.Text + "<th class=""" + flow_select.ID + """>" + label_flow_select.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + temperature_select.ID + """>" + label_temperature_select.Text + "</th>"

        report_head.Text = report_head.Text + "</tr> "
        report_head.Text = report_head.Text + "</thead>"

        report_body.Text = "<tbody>"
        Dim data As Date
        Dim data_str As String = ""
        For Each dc In table_log
            If prima_volta Then
                data_prima = dc.data.ToString
            End If
            prima_volta = False
            data_seconda = dc.data.ToString
            report_body.Text = report_body.Text + "<tr class=""gradeX"">"
            report_body.Text = report_body.Text + "<td>"
            data = dc.data.ToString


            If international_unit = "IS" Then ' europeo

                data_str = data.ToString("dd/MM/yy HH:mm", CultureInfo.InvariantCulture)
                'data_str = data_str + " " + data.ToString("HH:mm")
            Else
                'data_str = data.ToString("dd/MM/yy")
                'If InStr(dc.data.ToString, "AM") <> 0 Then
                'data_str = data_str + " " + data.ToString("hh:mmt")
                data_str = data.ToString("MM/dd/yy hh:mm tt", CultureInfo.InvariantCulture)
                '
                'End If
            End If

            report_body.Text = report_body.Text + data_str

            report_body.Text = report_body.Text + "<td class=""" + ch1_val.ID + """>" + dc.valore1.ToString + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch2_val.ID + """>" + dc.valore2.ToString + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch3_val.ID + """>" + dc.valore3.ToString + "</td>"

            report_body.Text = report_body.Text + "<td class=""" + ch1_high.ID + """>" + decode_on_off(dc.cd_high.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_low.ID + """>" + decode_on_off(dc.cd_low.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_bleed.ID + """>" + decode_on_off(dc.bleed_timeout.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_livello_inhibitor.ID + """>" + decode_on_off(dc.level_inhibitor.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_livello_prebiocide1.ID + """>" + decode_on_off(dc.level_prebiocide1.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_livello_prebiocide2.ID + """>" + decode_on_off(dc.level_prebiocide2.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_livello_biocide1.ID + """>" + decode_on_off(dc.level_biocide1.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_livello_biocide2.ID + """>" + decode_on_off(dc.level_biocide2.ToString) + "</td>"

            report_body.Text = report_body.Text + "<td class=""" + ch2_high.ID + """>" + decode_on_off(dc.ch2_high.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch2_low.ID + """>" + decode_on_off(dc.ch2_low.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch2_livello.ID + """>" + decode_on_off(dc.ch2_level.ToString) + "</td>"

            report_body.Text = report_body.Text + "<td class=""" + ch3_high.ID + """>" + decode_on_off(dc.ch3_high.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch3_low.ID + """>" + decode_on_off(dc.ch3_low.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch3_livello.ID + """>" + decode_on_off(dc.ch3_level.ToString) + "</td>"


            report_body.Text = report_body.Text + "<td class=""" + flow_select.ID + """>" + decode_on_off(dc.flow.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + temperature_select.ID + """>" + decode_on_off(dc.temperatura.ToString) + "</td>"

            report_body.Text = report_body.Text + "</td>"
            report_body.Text = report_body.Text + "</tr>"
        Next
        Dim data_prima_date As Date
        Dim data_seconda_date As Date
        If data_prima <> "" And data_seconda <> "" Then
            data_prima_date = Date.Parse(data_prima)
            data_seconda_date = Date.Parse(data_seconda)
            data_prima = data_prima_date.ToString("dd/MM/yy")
            data_seconda = data_seconda_date.ToString("dd/MM/yy")
        End If

        literal_script.Text = "<script>"
        literal_script.Text = literal_script.Text + "var init_date='" + data_prima + "';"
        literal_script.Text = literal_script.Text + "var last_date='" + data_seconda + "';"
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_report" + "';"
        literal_script.Text = literal_script.Text + "</script>"
        report_body.Text = report_body.Text + "<tbody>"

        function_javascript = function_javascript + "manage_div();"
        function_javascript = function_javascript + "manage_report();"
        function_javascript = function_javascript + "create_picker();"


        java_script_function.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Private Function decode_on_off(ByVal input As String) As String
        If InStr(input, "1") <> 0 Then
            Return "On"
        Else
            Return "Off"
        End If
    End Function

    Protected Sub pdf_id_Click(sender As Object, e As EventArgs) Handles pdf_id.Click
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=" + codice_impianto + "_" + id_485_impianto + ".pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        pnlPerson.RenderControl(hw)
        'Regex.Replace(hw., "", "")

        Dim local As String = sw.ToString()

        local = create_custom_export(local)

        Dim sr As New StringReader(local)
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)

        Dim htmlparser As HTMLWorker = New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()

    End Sub

    Protected Sub excel_id_Click(sender As Object, e As EventArgs) Handles excel_id.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=" + codice_impianto + "_" + id_485_impianto + ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            pnlPerson.RenderControl(hw)
            Dim local As String = sw.ToString()
            local = create_custom_export(local)

            Response.Output.Write(local)
            Response.Flush()
            Response.End()
        End Using
        
    End Sub

    Protected Function create_custom_export(ByVal local As String) As String
        If Not ch1_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_val.ID + """>.*?</th>", "")
        End If

        If Not ch1_high.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_high.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_high.ID + """>.*?</th>", "")
        End If
        If Not ch1_low.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_low.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_low.ID + """>.*?</th>", "")
        End If
        If Not ch1_bleed.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_bleed.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_bleed.ID + """>.*?</th>", "")
        End If
        If Not ch1_livello_inhibitor.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_livello_inhibitor.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_livello_inhibitor.ID + """>.*?</th>", "")
        End If
        If Not ch1_livello_prebiocide1.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_livello_prebiocide1.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_livello_prebiocide1.ID + """>.*?</th>", "")
        End If
        If Not ch1_livello_prebiocide2.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_livello_prebiocide2.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_livello_prebiocide2.ID + """>.*?</th>", "")
        End If
        If Not ch1_livello_biocide1.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_livello_biocide1.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_livello_biocide1.ID + """>.*?</th>", "")
        End If
        If Not ch1_livello_biocide2.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_livello_biocide2.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_livello_biocide2.ID + """>.*?</th>", "")
        End If

        If Not ch2_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_val.ID + """>.*?</th>", "")
        End If

        If Not ch2_high.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_high.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_high.ID + """>.*?</th>", "")
        End If
        If Not ch2_low.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_low.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_low.ID + """>.*?</th>", "")
        End If
        If Not ch2_livello.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_livello.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_livello.ID + """>.*?</th>", "")
        End If

        If Not ch3_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_val.ID + """>.*?</th>", "")
        End If

        If Not ch3_high.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_high.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_high.ID + """>.*?</th>", "")
        End If
        If Not ch3_low.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_low.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_low.ID + """>.*?</th>", "")
        End If
        If Not ch3_livello.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_livello.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_livello.ID + """>.*?</th>", "")
        End If
        If Not flow_select.Checked Then
            local = Regex.Replace(local, "<td class=""" + flow_select.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + flow_select.ID + """>.*?</th>", "")
        End If
        If Not temperature_select.Checked Then
            local = Regex.Replace(local, "<td class=""" + temperature_select.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + temperature_select.ID + """>.*?</th>", "")
        End If
        Return local
    End Function

    Protected Sub refresh_log_server_Click(sender As Object, e As EventArgs) Handles refresh_log_server.Click
        Dim init_date As String
        Dim last_date As String
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")
        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=15" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class