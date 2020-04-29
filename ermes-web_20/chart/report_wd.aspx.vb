Imports System.Globalization

Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class report_wd
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub report_wd_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

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
            posiziona_report(nome_impianto, codice_impianto, id_485_impianto, init_date, last_date)

        End If
    End Sub
    Public Sub get_coockie(ByVal input As String)
        Dim split_input() As String = input.Split("z")
        ch1_val.Checked = Convert.ToBoolean(split_input(0))
        ch1_dos.Checked = Convert.ToBoolean(split_input(1))
        ch1_probe.Checked = Convert.ToBoolean(split_input(2))
        ch1_livello1.Checked = Convert.ToBoolean(split_input(3))
        ch2_val.Checked = Convert.ToBoolean(split_input(4))
        ch2_dos.Checked = Convert.ToBoolean(split_input(5))
        ch2_probe.Checked = Convert.ToBoolean(split_input(6))
        ch2_level1.Checked = Convert.ToBoolean(split_input(7))
        ch3_val.Checked = Convert.ToBoolean(split_input(8))
        flow_select.Checked = Convert.ToBoolean(split_input(9))
    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + ch1_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_dos.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_probe.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_dos.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_probe.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_level1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow_select.Checked.ToString + "z"
        Return stringa_risultato
    End Function
    Public Sub posiziona_report(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.wd_logDataTable
        Dim numero_canali As Integer = 0

        Dim config_value() As String
        Dim calibrz_value() As String
        Dim valuer_value() As String

        Dim formato_d As String
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer
        Dim lunghezza_tabella As Integer
        Dim function_javascript As String = ""
        Dim set_variable_javascript(10, 1) As String
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script
        Dim query As New query

        Dim fattore_divisione_combinato As Integer = 1
        Dim mA_enable As Boolean = False

        Dim prima_volta As Boolean = True
        Dim data_prima As String = ""
        Dim data_seconda As String = ""

        Dim number_version As Integer = 0
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

        config_value = main_function.get_split_str(riga_strumento.value1)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)

        formato_d = Mid(valuer_value(4), 1, 1)

        ch1_enable.Visible = True
        ch2_enable.Visible = True
        ch3_enable.Visible = False
        numero_canali = 2


        For i = 1 To numero_canali
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
            Select Case i
                Case 1
                    'set_variable_javascript(8 + i, 0) = "label_ch1"
                    'set_variable_javascript(8 + i, 1) = """" + label_canale_temp + """"
                    ch1_val_label.Text = label_canale_temp
                Case 2
                    'set_variable_javascript(8 + i, 0) = "label_ch2"
                    'set_variable_javascript(8 + i, 1) = """" + label_canale_temp + """"
                    ch2_val_label.Text = label_canale_temp
            End Select
        Next
        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        table_log = query.get_log_wd(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)

        report_head.Text = "<thead>"
        report_head.Text = report_head.Text + "<tr class=""gradeA""> "
        report_head.Text = report_head.Text + "<th>Data</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_val.ID + """>" + ch1_val_label.Text + "</th>"


        report_head.Text = report_head.Text + "<th class=""" + ch1_dos.ID + """>" + ch1_dos_label.Text + ch1_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_probe.ID + """>" + ch1_probe_label.Text + ch1_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_livello1.ID + """>" + ch1_livello1_label.Text + ch1_val_label.Text + "</th>"

        report_head.Text = report_head.Text + "<th class=""" + ch2_val.ID + """>" + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch2_dos.ID + """>" + ch2_dos_label.Text + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch2_probe.ID + """>" + ch2_probe_label.Text + ch2_val_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch2_level1.ID + """>" + ch2_level2_label.Text + ch2_val_label.Text + "</th>"

        report_head.Text = report_head.Text + "<th class=""" + flow_select.ID + """>" + label_flow_select.Text + "</th>"

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
            If formato_d = "0" Then ' europeo
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

            report_body.Text = report_body.Text + "<td class=""" + ch1_dos.ID + """>" + decode_on_off(dc.dos_alarm_ph.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_probe.ID + """>" + decode_on_off(dc.probe_fail_ph.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch1_livello1.ID + """>" + decode_on_off(dc.livello1.ToString) + "</td>"


            report_body.Text = report_body.Text + "<td class=""" + ch2_val.ID + """>" + dc.valore2.ToString + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch2_dos.ID + """>" + decode_on_off(dc.dos_alarm_cl.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch2_probe.ID + """>" + decode_on_off(dc.probe_fail_cl.ToString) + "</td>"
            report_body.Text = report_body.Text + "<td class=""" + ch2_level1.ID + """>" + decode_on_off(dc.livello2.ToString) + "</td>"


            report_body.Text = report_body.Text + "<td class=""" + flow_select.ID + """>" + decode_on_off(dc.flusso.ToString) + "</td>"

            report_body.Text = report_body.Text + "</td>"
            report_body.Text = report_body.Text + "</tr>"
        Next
        report_body.Text = report_body.Text + "<tbody>"
        literal_script.Text = "<script>"
        literal_script.Text = literal_script.Text + "var init_date='" + data_prima + "';"
        literal_script.Text = literal_script.Text + "var last_date='" + data_seconda + "';"
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_report" + "';"

        literal_script.Text = literal_script.Text + "</script>"


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
    Protected Function create_custom_export(ByVal local As String) As String
        If Not ch1_val.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch1_val.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch1_val.ID + """>.*?</td>", "")
        End If

        If Not ch1_dos.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch1_dos.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch1_dos.ID + """>.*?</td>", "")
        End If
        If Not ch1_probe.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch1_probe.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch1_probe.ID + """>.*?</td>", "")
        End If
        If Not ch1_livello1.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch1_livello1.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch1_livello1.ID + """>.*?</td>", "")
        End If

        If Not ch2_val.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch2_val.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch2_val.ID + """>.*?</td>", "")
        End If

        If Not ch2_dos.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch2_dos.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class =""" + ch2_dos.ID + """>.*?</td>", "")
        End If
        If Not ch2_probe.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch2_probe.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch2_probe.ID + """>.*?</td>", "")
        End If
        If Not ch2_level1.Checked Then
            local = Regex.Replace(local, "<th class=""" + ch2_level1.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch2_level1.ID + """>.*?</td>", "")
        End If


        If Not flow_select.Checked Then
            local = Regex.Replace(local, "<th class=""" + flow_select.ID + """>.*?</th>", "")
            local = Regex.Replace(local, "<td class=""" + ch2_level1.ID + """>.*?</td>", "")
        End If
        Return local
    End Function

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

    Protected Sub refresh_log_server_Click(sender As Object, e As EventArgs) Handles refresh_log_server.Click
        Dim init_date As String
        Dim last_date As String
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")
        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class