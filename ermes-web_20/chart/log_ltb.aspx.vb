Imports System.Globalization
Public Class log_ltb
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
        ch2_val.Checked = Convert.ToBoolean(split_input(1))
        temperature_val.Checked = Convert.ToBoolean(split_input(2))
        flow.Checked = Convert.ToBoolean(split_input(3))
        lev_hcl.Checked = Convert.ToBoolean(split_input(4))
        lev_naclo2.Checked = Convert.ToBoolean(split_input(5))
        lev_k6.Checked = Convert.ToBoolean(split_input(6))

        temp_max.Checked = Convert.ToBoolean(split_input(7))
        stop_l.Checked = Convert.ToBoolean(split_input(8))
        lev_errata.Checked = Convert.ToBoolean(split_input(9))

    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + ch1_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + temperature_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + lev_hcl.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + lev_naclo2.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + lev_k6.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + temp_max.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + stop_l.Checked.ToString + "z"


        Return stringa_risultato
    End Function

    Public Sub posiziona_log(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                             ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.ltb_logDataTable
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


        ch1_enable.Visible = False
        ch2_enable.Visible = False

        numero_canali = 2

        literal_script.Text = "<script>"

        For i = 1 To numero_canali
            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
            Select Case i
                Case 1
                    ch1_enable.Visible = main_function_config.get_enable_canale_lotusb(valuer_value(5))
                    If ch1_enable.Visible Then
                        literal_script.Text = literal_script.Text + "var label_ch1='" + label_canale_temp + "';"
                        ch1_val_label.Text = label_canale_temp
                    Else
                        literal_script.Text = literal_script.Text + "var label_ch1='';"
                    End If
                Case 2
                    ch2_enable.Visible = main_function_config.get_enable_canale_lotusb(valuer_value(6))
                    If ch2_enable.Visible Then
                        literal_script.Text = literal_script.Text + "var label_ch2='" + label_canale_temp + "';"
                        ch2_val_label.Text = label_canale_temp
                    Else
                        literal_script.Text = literal_script.Text + "var label_ch2='';"
                    End If
            End Select
        Next
        temperature_enable.Visible = main_function_config.get_enable_canale_lotusb(valuer_value(6))

        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        'table_log = query.get_log_ltb(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)

        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["


        'set_variable_javascript(2, 0) = "array_temperatura"
        'set_variable_javascript(2, 1) = "["
        'set_variable_javascript(3, 0) = "array_flusso"
        'set_variable_javascript(3, 1) = "["

        'set_variable_javascript(4, 0) = "array_lev_hcl"
        'set_variable_javascript(4, 1) = "["
        'set_variable_javascript(5, 0) = "array_lev_naclo2"
        'set_variable_javascript(5, 1) = "["

        'set_variable_javascript(6, 0) = "array_lev_k6"
        'set_variable_javascript(6, 1) = "["
        'set_variable_javascript(7, 0) = "array_temp_max"
        'set_variable_javascript(7, 1) = "["
        'set_variable_javascript(8, 0) = "array_stop"
        'set_variable_javascript(8, 1) = "["
        'set_variable_javascript(9, 0) = "array_lev_errata"
        'set_variable_javascript(9, 1) = "["




        'literal_script.Text = "<script>"

        'lunghezza_tabella = table_log.Count
        'Dim k As Integer
        ''For Each dc_log In table_log
        'For k = lunghezza_tabella - 1 To 0 Step -1
        '    Dim dc_log As ermes_web_20.quey_db.ltb_logRow
        '    dc_log = table_log.Item(k)

        '    If prima_volta Then
        '        data_prima = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")
        '    End If
        '    prima_volta = False
        '    data_seconda = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")

        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore1.ToString(), ",", ".") + "]"
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore2.ToString(), ",", ".") + "]"


        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.temperatura.ToString(), ",", ".") + "]"
        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.flusso) + "]"

        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.lev_hcl) + "]"
        '    set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.lev_naclo2) + "]"

        '    set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.lev_k6) + "]"
        '    set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.temp_max) + "]"

        '    set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log._stop) + "]"
        '    set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.lev_errata) + "]"

        '    index = index + 1
        '    If index < lunghezza_tabella Then
        '        Dim j As Integer
        '        For j = 0 To 9
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If

        'Next
        'If index >= lunghezza_tabella Then
        '    Dim j As Integer
        '    For j = 0 To 9
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

        literal_script.Text = literal_script.Text + "var flow_label='" + flow_label.Text + "';" + "var lev_hcl_label='" + lev_hcl_label.Text + "';" + "var lev_naclo2_label='" + lev_naclo2_label.Text + "';" + _
         "var lev_k6_label='" + lev_k6_label.Text + "';" + "var stop_label='" + stop_label.Text + "';" + "var lev_errata_label='" + lev_errata_label.Text + "';" + "var temp_max_label='" + temp_max_label.Text + "';" + "var temperature_val_label='" + temperature_val_label.Text + "';"




        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_log" + "';"
        literal_script.Text = literal_script.Text + "</script>"

        Dim stringa1 As String = data_from.ToString
        Dim stringa2 As String = data_to.ToString
        function_javascript = function_javascript + "get_data('" + codice_impianto + "'," + id_485_impianto + "," + temporaneo_id + ",'" + data_prima + "','" + data_seconda + "');"

        function_javascript = function_javascript + "manage_div();"
        'function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"




        java_script_function.call_function_javascript_onload(Page, function_javascript)


        'function_javascript = function_javascript + "manage_div();"
        'function_javascript = function_javascript + "upgrate_chart();"
        'function_javascript = function_javascript + "create_picker();"
        'java_script_variable.set_url_setpoint(Page, set_variable_javascript, 11)
        'java_script_function.call_function_javascript_onload(Page, function_javascript)
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
        Response.Redirect("~/ltb.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=6" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class