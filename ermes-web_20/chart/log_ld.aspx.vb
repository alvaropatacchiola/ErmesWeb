Imports System.Globalization
Public Class log_ld
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub log_ld_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
       
        Dim init_date As String = ""
        Dim last_date As String = ""
        ' System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert(""Hello this is an Alert"")</SCRIPT>")
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
                If Request.Cookies(codice_impianto + "_" + id_485_impianto + "_log") Is Nothing Then
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Expires = DateTime.Now.AddMonths(12) ' il cookie dura 1 anno
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
        ch1_feed.Checked = Convert.ToBoolean(split_input(1))
        ch1_dos.Checked = Convert.ToBoolean(split_input(2))
        ch1_probe.Checked = Convert.ToBoolean(split_input(3))
        ch1_livello1.Checked = Convert.ToBoolean(split_input(4))
        ch1_livello2.Checked = Convert.ToBoolean(split_input(5))
        ch2_val.Checked = Convert.ToBoolean(split_input(6))
        ch2_feed.Checked = Convert.ToBoolean(split_input(7))
        ch2_dos.Checked = Convert.ToBoolean(split_input(8))
        ch2_probe.Checked = Convert.ToBoolean(split_input(9))
        ch2_level1.Checked = Convert.ToBoolean(split_input(10))
        ch3_val.Checked = Convert.ToBoolean(split_input(11))
        flow_select.Checked = Convert.ToBoolean(split_input(12))
        temperature_select.Checked = Convert.ToBoolean(split_input(13))
    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + ch1_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_feed.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_dos.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_probe.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_livello2.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_feed.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_dos.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_probe.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_level1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow_select.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + temperature_select.Checked.ToString
        Return stringa_risultato
    End Function
    Public Sub posiziona_log(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                                  ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.ld_logDataTable = New ermes_web_20.quey_db.ld_logDataTable
        Dim numero_canali As Integer = 0
        Dim query As New query
        Dim formato_d As String

        Dim config_value() As String
        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer
        Dim lunghezza_tabella As Integer
        Dim function_javascript As String = ""

        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

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
        'System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert(""Hello this is an Alert"")</SCRIPT>")



        config_value = main_function.get_split_str(riga_strumento.value1)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)
        number_version = Val(main_function.get_version(riga_strumento.nome))

        formato_d = Mid(valuer_value(4), 1, 1)

        ch1_enable.Visible = False
        ch2_enable.Visible = False
        ch3_enable.Visible = False
        literal_script.Text = "<script>"

        Select Case riga_strumento.tipo_strumento
            Case "LD"
                ch1_val.Checked = True
                ' ch2_val.Checked = False
                'stby_enable.Visible = False
                'flow_meter_enable.Visible = False

                If Mid(config_value(3), 3, 3) <> "306" Then ' terzo canale esistente
                    ch1_enable.Visible = True
                    ch2_enable.Visible = True
                    ch3_enable.Visible = True
                    numero_canali = 3
                Else
                    ch1_enable.Visible = True
                    ch2_enable.Visible = True
                    ch3_enable.Visible = False
                    numero_canali = 2
                End If
                Dim versione As Integer = Val(main_function.get_version(riga_strumento.nome))
                If versione < 800 Then
                    stby_enable.Visible = False
                    flow_meter_enable.Visible = False
                End If

                For i = 1 To numero_canali
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
                    Select Case i
                        Case 1
                            literal_script.Text = literal_script.Text + "var label_ch1='" + label_canale_temp + "';"

                            ch1_val_label.Text = label_canale_temp
                        Case 2
                            literal_script.Text = literal_script.Text + "var label_ch2='" + label_canale_temp + "';"
                            ch2_val_label.Text = label_canale_temp
                        Case 3
                            literal_script.Text = literal_script.Text + "var label_ch3='" + label_canale_temp + "';"
                            ch3_val_label.Text = label_canale_temp
                    End Select
                Next

            Case "LDS"
                numero_canali = 1
                ch1_enable.Visible = False
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                ch1_val.Checked = False
                ch2_val.Checked = True
                Dim versione As Integer = Val(main_function.get_version(riga_strumento.nome))
                If versione < 430 Then
                    stby_enable.Visible = False
                    flow_meter_enable.Visible = False
                End If
                For i = 1 To numero_canali
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2))
                    literal_script.Text = literal_script.Text + "var label_ch2='" + label_canale_temp + "';"

                    ch2_val_label.Text = label_canale_temp
                Next
        End Select

        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        'table_log = query.get_log_ld(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)

        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["
        'set_variable_javascript(2, 0) = "array_ch3"
        'set_variable_javascript(2, 1) = "["

        'set_variable_javascript(3, 0) = "array_feed1"
        'set_variable_javascript(3, 1) = "["
        'set_variable_javascript(4, 0) = "array_feed2"
        'set_variable_javascript(4, 1) = "["

        'set_variable_javascript(5, 0) = "array_dos1"
        'set_variable_javascript(5, 1) = "["
        'set_variable_javascript(6, 0) = "array_dos2"
        'set_variable_javascript(6, 1) = "["

        'set_variable_javascript(7, 0) = "array_probe1"
        'set_variable_javascript(7, 1) = "["
        'set_variable_javascript(8, 0) = "array_probe2"
        'set_variable_javascript(8, 1) = "["

        'set_variable_javascript(9, 0) = "array_level1"
        'set_variable_javascript(9, 1) = "["
        'set_variable_javascript(10, 0) = "array_level2"
        'set_variable_javascript(10, 1) = "["
        'set_variable_javascript(11, 0) = "array_level3"
        'set_variable_javascript(11, 1) = "["


        'set_variable_javascript(12, 0) = "array_flow"
        'set_variable_javascript(12, 1) = "["
        'set_variable_javascript(13, 0) = "array_temperatura"
        'set_variable_javascript(13, 1) = "["
        'set_variable_javascript(14, 0) = "array_stby"
        'set_variable_javascript(14, 1) = "["
        'set_variable_javascript(15, 0) = "array_m3h"
        'set_variable_javascript(15, 1) = "["
        'set_variable_javascript(16, 0) = "array_totalizer"
        'set_variable_javascript(16, 1) = "["



        'lunghezza_tabella = table_log.Count
        ''System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert(""" + lunghezza_tabella.ToString + """)</SCRIPT>")
        'If lunghezza_tabella > 800 Then
        '    lunghezza_tabella = 800
        'End If
        'Dim k As Integer
        ''For Each dc_log In table_log
        'For k = lunghezza_tabella - 1 To 0 Step -1
        '    Dim dc_log As ermes_web_20.quey_db.ld_logRow
        '    dc_log = table_log.Item(k)

        '    If prima_volta Then
        '        data_prima = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")
        '    End If
        '    prima_volta = False
        '    data_seconda = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")

        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore1.ToString(), ",", ".") + "]"
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore2.ToString(), ",", ".") + "]"
        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore3.ToString(), ",", ".") + "]"

        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.feed_limit_ph.ToString + "]"
        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.feed_limit_cl.ToString + "]"
        '    set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.dos_alarm_ph.ToString + "]"
        '    set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.dos_alarm_cl.ToString + "]"

        '    set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.probe_fail_ph.ToString + "]"
        '    set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.probe_fail_cl.ToString + "]"

        '    set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.livello1.ToString + "]"
        '    set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.livello2.ToString + "]"
        '    set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.livello3.ToString + "]"

        '    set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.flusso.ToString + "]"

        '    set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.temperatura.ToString(), ",", ".") + "]"

        '    set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.stby) + "]"
        '    set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.m3h.ToString(), ",", ".") + "]"
        '    set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.totalizer.ToString(), ",", ".") + "]"

        '    index = index + 1
        '    If index < lunghezza_tabella Then
        '        Dim j As Integer
        '        For j = 0 To 16
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If

        'Next
        'If index >= lunghezza_tabella Then
        '    Dim j As Integer
        '    For j = 0 To 16
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
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + " " + nome_impianto + "';"

        literal_script.Text = literal_script.Text + "var ch1_feed_label='" + ch1_feed_label.Text + "';" + "var ch1_dos_label='" + ch1_dos_label.Text + "';" + "var ch1_probe_label='" + ch1_probe_label.Text + "';" + "var ch1_livello1_label='" + ch1_livello1_label.Text + "';" + "var ch1_livello2_label='" + ch1_livello2_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_feed_label='" + ch2_feed_label.Text + "';" + "var ch2_dos_label='" + ch2_dos_label.Text + "';" + "var ch2_probe_label='" + ch2_probe_label.Text + "';" + "var ch2_level2_label='" + ch2_level2_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_flow_select='" + label_flow_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_temperature_select='" + label_temperature_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_stby='" + stby_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_m3h='" + m3h_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_totalizer='" + totalizer_label.Text + " (WMI)';"
        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_log" + "';"

        literal_script.Text = literal_script.Text + "</script>"

        If number_version >= 420 Then
            ch1_relay_enable.Visible = True
            ch2_relay_enable.Visible = True
        Else
            ch1_relay_enable.Visible = False
            ch2_relay_enable.Visible = False
        End If
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
        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=19" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class