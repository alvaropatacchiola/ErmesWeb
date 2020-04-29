Imports System.Globalization
Public Class log_wh
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Try
                If Request.Cookies(codice_impianto + "_" + id_485_impianto + "_log") Is Nothing Then
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Expires = DateTime.Now.AddMonths(12)  ' il cookie dura 1 anno
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Value = set_coockie()

                Else
                    get_coockie(Request.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Value)
                End If
            Catch ex As Exception

            End Try
            posiziona_log(nome_impianto, codice_impianto, id_485_impianto, "SetPoint", init_date, last_date)

        End If

    End Sub

    Public Sub get_coockie(ByVal input As String)
        Dim split_input() As String = input.Split("z")
        ch1_val.Checked = Convert.ToBoolean(split_input(0))
        ch1_dos.Checked = Convert.ToBoolean(split_input(1))
        ch1_probe.Checked = Convert.ToBoolean(split_input(2))
        ch1_livello1.Checked = Convert.ToBoolean(split_input(3))
        ch1_pulse1.Checked = Convert.ToBoolean(split_input(4))
        ch1_pulse2.Checked = Convert.ToBoolean(split_input(5))
        ch1_rele.Checked = Convert.ToBoolean(split_input(6))

        ch2_val.Checked = Convert.ToBoolean(split_input(7))
        ch2_dos.Checked = Convert.ToBoolean(split_input(8))
        ch2_probe.Checked = Convert.ToBoolean(split_input(9))
        ch2_level1.Checked = Convert.ToBoolean(split_input(10))
        ch2_pulse.Checked = Convert.ToBoolean(split_input(11))
        ch2_rele.Checked = Convert.ToBoolean(split_input(12))

        timer_manutenzione.Checked = Convert.ToBoolean(split_input(13))
        timer_pagamento.Checked = Convert.ToBoolean(split_input(14))
        timer_sonda_ch1.Checked = Convert.ToBoolean(split_input(15))
        timer_sonda_ch2.Checked = Convert.ToBoolean(split_input(16))
        timer_filtro.Checked = Convert.ToBoolean(split_input(17))


        ch3_val.Checked = Convert.ToBoolean(split_input(18))
        flow_select.Checked = Convert.ToBoolean(split_input(19))
        stby_select.Checked = Convert.ToBoolean(split_input(20))
    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + ch1_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_dos.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_probe.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_pulse1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_pulse2.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_rele.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_dos.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_probe.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_level1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_pulse.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_rele.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + timer_manutenzione.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + timer_pagamento.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + timer_sonda_ch1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + timer_sonda_ch2.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + timer_filtro.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch3_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow_select.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + stby_select.Checked.ToString + "z"

        Return stringa_risultato
    End Function
    Public Sub posiziona_log(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                                ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.wh_logDataTable
        Dim numero_canali As Integer = 0

        Dim config_value() As String
        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim formato_d As String

        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer
        Dim lunghezza_tabella As Integer
        Dim function_javascript As String = ""

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

            data_from = data_to.AddDays(-30)
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

        literal_script.Text = "<script>"

        For i = 1 To numero_canali
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
            Select Case i
                Case 1
                    literal_script.Text = literal_script.Text + "var label_ch1 = '" + label_canale_temp + "';"
                    ch1_val_label.Text = label_canale_temp
                Case 2
                    literal_script.Text = literal_script.Text + "var label_ch2 = '" + label_canale_temp + "';"
                    ch2_val_label.Text = label_canale_temp
            End Select
        Next
        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        'table_log = query.get_log_wh(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)

        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["


        'set_variable_javascript(2, 0) = "array_dos1"
        'set_variable_javascript(2, 1) = "["
        'set_variable_javascript(3, 0) = "array_dos2"
        'set_variable_javascript(3, 1) = "["

        'set_variable_javascript(4, 0) = "array_probe1"
        'set_variable_javascript(4, 1) = "["
        'set_variable_javascript(5, 0) = "array_probe2"
        'set_variable_javascript(5, 1) = "["

        'set_variable_javascript(6, 0) = "array_level1"
        'set_variable_javascript(6, 1) = "["
        'set_variable_javascript(7, 0) = "array_level2"
        'set_variable_javascript(7, 1) = "["


        'set_variable_javascript(8, 0) = "array_ch1_pulse1"
        'set_variable_javascript(8, 1) = "["
        'set_variable_javascript(9, 0) = "array_ch1_pulse2"
        'set_variable_javascript(9, 1) = "["
        'set_variable_javascript(10, 0) = "array_ch2_pulse"
        'set_variable_javascript(10, 1) = "["

        'set_variable_javascript(11, 0) = "array_ch1_rele1"
        'set_variable_javascript(11, 1) = "["
        'set_variable_javascript(12, 0) = "array_ch2_rele1"
        'set_variable_javascript(12, 1) = "["

        'set_variable_javascript(13, 0) = "array_timer_manutenzione"
        'set_variable_javascript(13, 1) = "["
        'set_variable_javascript(14, 0) = "array_timer_pagamento"
        'set_variable_javascript(14, 1) = "["
        'set_variable_javascript(15, 0) = "array_timer_sonda_ch1"
        'set_variable_javascript(15, 1) = "["
        'set_variable_javascript(16, 0) = "array_timer_sonda_ch2"
        'set_variable_javascript(16, 1) = "["
        'set_variable_javascript(17, 0) = "array_timer_filtro"
        'set_variable_javascript(17, 1) = "["

        'set_variable_javascript(18, 0) = "array_flow"
        'set_variable_javascript(18, 1) = "["
        'set_variable_javascript(19, 0) = "array_stby"
        'set_variable_javascript(19, 1) = "["



        'lunghezza_tabella = table_log.Count
        'If lunghezza_tabella > 800 Then
        '    lunghezza_tabella = 800
        'End If

        'Dim k As Integer = 0

        ''For Each dc_log In table_log
        'For k = lunghezza_tabella - 1 To 0 Step -1
        '    Dim dc_log As ermes_web_20.quey_db.wh_logRow
        '    dc_log = table_log.Item(k)
        '    If prima_volta Then
        '        data_prima = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")
        '    End If
        '    prima_volta = False
        '    data_seconda = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")

        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore1.ToString(), ",", ".") + "]"
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore2.ToString(), ",", ".") + "]"


        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.dos_alarm_ph) + "]"
        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.dos_alarm_cl) + "]"

        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.probe_fail_ph) + "]"
        '    set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.probe_fail_cl) + "]"

        '    set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.livello1) + "]"
        '    set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.livello2) + "]"

        '    set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.stato_pulse1_ch1.ToString + "]"
        '    set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.stato_pulse2_ch1.ToString + "]"
        '    set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.stato_pulse_ch2.ToString + "]"

        '    set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.stato_rele_ch1) + "]"
        '    set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.stato_rele_ch2) + "]"

        '    set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.timer_manutenzione) + "]"
        '    set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.timer_pagamento) + "]"
        '    set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.timer_sonda_ph) + "]"
        '    set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.timer_sonda_mv) + "]"
        '    set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.timer_filtro) + "]"


        '    set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.flusso) + "]"
        '    set_variable_javascript(19, 1) = set_variable_javascript(19, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.stby) + "]"

        '    index = index + 1
        '    If index < lunghezza_tabella Then
        '        Dim j As Integer
        '        For j = 0 To 19
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If

        'Next
        'If index >= lunghezza_tabella Then
        '    Dim j As Integer
        '    For j = 0 To 19
        '        set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "]" + vbCrLf
        '    Next
        'End If

        Dim data_prima_date As Date
        Dim data_seconda_date As Date
        If data_prima <> "" And data_seconda <> "" Then
            data_prima_date = Date.ParseExact(data_prima, "dd/MM/yy", CultureInfo.InvariantCulture)
            data_seconda_date = Date.ParseExact(data_seconda, "dd/MM/yy", CultureInfo.InvariantCulture)
            data_prima = Format(data_prima_date.Day, "00") + "/" + Format(data_prima_date.Month, "00") + "/" + Format(data_prima_date.Year, "00")
            data_seconda = Format(data_seconda_date.Day, "00") + "/" + Format(data_seconda_date.Month, "00") + "/" + Format(data_seconda_date.Year, "00")
        Else
            data_prima_date = Date.Parse(data_from)
            data_seconda_date = Date.Parse(data_to)
            data_prima = Format(data_prima_date.Day, "00") + "/" + Format(data_prima_date.Month, "00") + "/" + Format(data_prima_date.Year, "00")
            data_seconda = Format(data_seconda_date.Day, "00") + "/" + Format(data_seconda_date.Month, "00") + "/" + Format(data_seconda_date.Year, "00")
        End If
        literal_script.Text = literal_script.Text + "var formato_data='" + formato_d + "';"
        literal_script.Text = literal_script.Text + "var init_date='" + data_prima + "';"
        literal_script.Text = literal_script.Text + "var last_date='" + data_seconda + "';"
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + " " + nome_impianto + "';"

        literal_script.Text = literal_script.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + " " + nome_impianto + "';"

        literal_script.Text = literal_script.Text + "var ch1_dos_label='" + ch1_dos_label.Text + "';" + "var ch1_probe_label='" + ch1_probe_label.Text + "';" + "var ch1_livello1_label='" + ch1_livello1_label.Text + "';" + _
         "var ch1_pulse1_label='" + ch1_pulse1_label.Text + "';" + "var ch1_pulse2_label='" + ch1_pulse2_label.Text + "';" + "var ch1_rele_label='" + ch1_rele_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch2_dos_label='" + ch2_dos_label.Text + "';" + "var ch2_probe_label='" + ch2_probe_label.Text + "';" + "var ch2_level2_label='" + ch2_level2_label.Text + "';" + _
        "var ch2_pulse_label='" + ch2_pulse_label.Text + "';" + "var ch2_rele_label='" + ch2_rele_label.Text + "';"

        literal_script.Text = literal_script.Text + "var timer_sonda_ch1_label='" + timer_sonda_ch1_label.Text + "';" + "var timer_sonda_ch2_label='" + timer_sonda_ch2_label.Text + "';" + "var timer_pagamento_label='" + timer_pagamento_label.Text + "';" + _
        "var timer_manutenzione_label='" + timer_manutenzione_label.Text + "';" + "var timer_filtro_label='" + timer_filtro_label.Text + "';"

        literal_script.Text = literal_script.Text + "var label_flow_select='" + label_flow_select.Text + "';" + "var label_stby_select='" + label_stby_select.Text + "';"



        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_log" + "';"
        literal_script.Text = literal_script.Text + "</script>"


        Dim stringa1 As String = data_from.ToString
        Dim stringa2 As String = data_to.ToString
        function_javascript = function_javascript + "get_data('" + codice_impianto + "'," + id_485_impianto + "," + temporaneo_id + ",'" + data_prima + "','" + data_seconda + "');"

        function_javascript = function_javascript + "manage_div();"
        'function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"

        java_script_function.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Public Function get_status_boolean(ByVal valore_bool As Boolean) As String
        If valore_bool Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Protected Sub refresh_log_server_Click(sender As Object, e As EventArgs) Handles refresh_log_server.Click
        Dim init_date As String
        Dim last_date As String
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")
        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class