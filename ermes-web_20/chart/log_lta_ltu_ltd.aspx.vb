Imports System.Globalization
Public Class log_lta_ltu_ltd
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
        Lev_Acid_L.Checked = Convert.ToBoolean(split_input(0))
        Flow_Acid_L.Checked = Convert.ToBoolean(split_input(1))
        Flow_Self_Water_L.Checked = Convert.ToBoolean(split_input(2))
        Lev_Water_L.Checked = Convert.ToBoolean(split_input(3))
        Flow_Chlorite_L.Checked = Convert.ToBoolean(split_input(4))
        Lev_Chlorite_L.Checked = Convert.ToBoolean(split_input(5))

        Overf.Checked = Convert.ToBoolean(split_input(6))
        Flow_Water_dil_L.Checked = Convert.ToBoolean(split_input(7))
        Level_SW.Checked = Convert.ToBoolean(split_input(8))

        BypassB.Checked = Convert.ToBoolean(split_input(9))
        TimeOut_L.Checked = Convert.ToBoolean(split_input(10))

        Service_F_L.Checked = Convert.ToBoolean(split_input(11))
        Lim_Dioxide.Checked = Convert.ToBoolean(split_input(12))
        Lev_Alflow.Checked = Convert.ToBoolean(split_input(13))

        flow1.Checked = Convert.ToBoolean(split_input(14))
        clo2.Checked = Convert.ToBoolean(split_input(15))
        naso.Checked = Convert.ToBoolean(split_input(16))
        temperature_lt.Checked = Convert.ToBoolean(split_input(17))


    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + Lev_Acid_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Flow_Acid_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Flow_Self_Water_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Lev_Water_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Flow_Chlorite_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Lev_Chlorite_L.Checked.ToString + "z"
        ' stringa_risultato = stringa_risultato + Sefl_Acid_L.Checked.ToString + "z"
        'stringa_risultato = stringa_risultato + Sefl_Chlorite_L.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + Overf.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Flow_Water_dil_L.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + Level_SW.Checked.ToString + "z"
        'stringa_risultato = stringa_risultato + Analog_L.Checked.ToString + "z"
        ' stringa_risultato = stringa_risultato + Tank_Empty_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + BypassB.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + TimeOut_L.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + Service_F_L.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Lim_Dioxide.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + Lev_Alflow.Checked.ToString + "z"


        stringa_risultato = stringa_risultato + flow1.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + clo2.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + naso.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + temperature_lt.Checked.ToString + "z"



        Return stringa_risultato
    End Function

    Public Sub posiziona_log(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                             ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.log_lta_ltu_ltdDataTable
        Dim numero_canali As Integer = 0

        Dim config_value() As String
        Dim calibrz_value() As String
        Dim valuer_value() As String

        Dim release_value() As String


        Dim formato_d As String

        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer
        Dim lunghezza_tabella As Integer
        Dim function_javascript As String = ""
        Dim set_variable_javascript(18, 1) As String
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
        release_value = main_function.get_split_str(riga_strumento.nome)

        number_version = Mid(release_value(3), 1, 3)

        formato_d = Mid(valuer_value(4), 1, 1)

        Select Case riga_strumento.tipo_strumento
            Case "LTA"
                ltd_ltu.Visible = False
                lta_ltu.Visible = True
            Case "LTU"
                ltd_ltu.Visible = True
                lta_ltu.Visible = True
            Case "LTD"
                ltd_ltu.Visible = True
                lta_ltu.Visible = False

        End Select

        'If number_version >= 149 And number_version < 205 Then
        If number_version >= 149 Then
            ltu_release.Visible = True
        Else
            ltu_release.Visible = False
        End If

        'If number_version >= 152 Or number_version >= 205 Then
        If number_version >= 201 Then
            ltu_release_nuovoHW.Visible = True
        Else
            ltu_release_nuovoHW.Visible = False
        End If



        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        table_log = query.get_log_lta_ltu_ltd(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)

        set_variable_javascript(0, 0) = "array_Flow_Acid_L"
        set_variable_javascript(0, 1) = "["
        set_variable_javascript(1, 0) = "array_Flow_Self_Water_L "
        set_variable_javascript(1, 1) = "["


        set_variable_javascript(2, 0) = "array_Flow_Chlorite_L"
        set_variable_javascript(2, 1) = "["
        set_variable_javascript(3, 0) = "array_Lev_Acid_L"
        set_variable_javascript(3, 1) = "["

        set_variable_javascript(4, 0) = "array_Lev_Chlorite_L"
        set_variable_javascript(4, 1) = "["
        set_variable_javascript(5, 0) = "array_Lev_Water_L"
        set_variable_javascript(5, 1) = "["

        'set_variable_javascript(6, 0) = "array_Sefl_Acid_L"
        'set_variable_javascript(6, 1) = "["
        'set_variable_javascript(7, 0) = "array_Sefl_Chlorite_L"
        'set_variable_javascript(7, 1) = "["
        set_variable_javascript(6, 0) = "array_TimeOut_L"
        set_variable_javascript(6, 1) = "["
        set_variable_javascript(7, 0) = "array_Flow_Water_dil_L"
        set_variable_javascript(7, 1) = "["

        set_variable_javascript(8, 0) = "array_Service_F_L"
        set_variable_javascript(8, 1) = "["
        'set_variable_javascript(11, 0) = "array_Analog_L"
        'set_variable_javascript(11, 1) = "["
        'set_variable_javascript(12, 0) = "array_Tank_Empty_L"
        'set_variable_javascript(12, 1) = "["
        set_variable_javascript(9, 0) = "array_Level_SW"
        set_variable_javascript(9, 1) = "["
        set_variable_javascript(10, 0) = "array_BypassB"
        set_variable_javascript(10, 1) = "["
        set_variable_javascript(11, 0) = "array_Lim_Dioxide"
        set_variable_javascript(11, 1) = "["
        set_variable_javascript(12, 0) = "array_Lev_Alflow"
        set_variable_javascript(12, 1) = "["
        set_variable_javascript(13, 0) = "array_Overf"
        set_variable_javascript(13, 1) = "["

        set_variable_javascript(14, 0) = "array_m3h"
        set_variable_javascript(14, 1) = "["

        set_variable_javascript(15, 0) = "array_lettura"
        set_variable_javascript(15, 1) = "["

        set_variable_javascript(16, 0) = "array_naso"
        set_variable_javascript(16, 1) = "["

        set_variable_javascript(17, 0) = "array_temp_lt"
        set_variable_javascript(17, 1) = "["


        set_variable_javascript(18, 0) = "array_minmax"
        set_variable_javascript(18, 1) = "["


        literal_script.Text = "<script>"

        lunghezza_tabella = table_log.Count
        Dim k As Integer
        'For Each dc_log In table_log
        For k = lunghezza_tabella - 1 To 0 Step -1
            Dim dc_log As ermes_web_20.quey_db.log_lta_ltu_ltdRow
            dc_log = table_log.Item(k)

            If prima_volta Then
                data_prima = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")
            End If
            prima_volta = False
            data_seconda = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")

            set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Flow_Acid_L) + "]"
            set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Flow_Self_Water_L) + "]"


            set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Flow_Chlorite_L) + "]"
            set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Lev_Acid_L) + "]"

            set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Lev_Chlorite_L) + "]"
            set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Lev_Water_L) + "]"

            'set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Sefl_Acid_L) + "]"
            'set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Sefl_Chlorite_L) + "]"

            set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.TimeOut_L) + "]"
            set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Flow_Water_dil_L) + "]"

            set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Service_F_L) + "]"
            'set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Analog_L) + "]"
            'set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Tank_Empty_L) + "]"
            set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Level_SW) + "]"
            set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.BypassB) + "]"
            set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Lim_Dioxide) + "]"
            set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Lev_Alflow) + "]"
            set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.Overf) + "]"

            set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.flow1.ToString(), ",", ".") + "]"
            set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.lettura.ToString(), ",", ".") + "]"
            set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.naso.ToString(), ",", ".") + "]"
            set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.temperatura.ToString(), ",", ".") + "]"
            '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore1.ToString(), ",", ".") + "]"
            '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore2.ToString(), ",", ".") + "]"
            set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.levSoglia) + "]"


            index = index + 1
            If index < lunghezza_tabella Then
                Dim j As Integer
                For j = 0 To 18
                    set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
                Next
            End If

        Next
        If index >= lunghezza_tabella Then
            Dim j As Integer
            For j = 0 To 18
                set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "]" + vbCrLf
            Next
        End If

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

        literal_script.Text = literal_script.Text + "var Flow_Acid_L_label='" + Flow_Acid_L_label.Text + "';" + "var Flow_Self_Water_L_label='" + Flow_Self_Water_L_label.Text + "';" + "var Flow_Chlorite_L_label='" + Flow_Chlorite_L_label.Text + "';" +
         "var Lev_Acid_L_label='" + Lev_Acid_L_label.Text + "';" + "var Lev_Chlorite_L_label='" + Lev_Chlorite_L_label.Text + "';" + "var Lev_Water_L_label='" + Lev_Water_L_label.Text + "';" + "var TimeOut_L_label='" + TimeOut_L_label.Text + "';" + "var Level_SW_label='" + Level_SW_label.Text + "';" +
        "var BypassB_label='" + BypassB_label.Text + "';" + "var Lim_Dioxide_label='" + Lim_Dioxide_label.Text + "';" + "var Lev_Alflow_label='" + Lev_Alflow_label.Text + "';" + "var Overf_label='" + Overf_label.Text + "';" _
         + "var Flow_Water_dil_L_label='" + Flow_Water_dil_L_label.Text + "';" + "var Service_F_L_label='" + Service_F_L_label.Text + "';" _
         + "var Level_SW_label_label='" + Level_SW_label.Text + "';" + "var BypassB_label='" + BypassB_label.Text + "';" + "var Lim_Dioxide_label='" + Lim_Dioxide_label.Text + "';" + "var Lev_Alflow_label='" + Lev_Alflow_label.Text + "';" + "var flow1_label='" + flow1_label.Text + "';" + "var clo2_label='" + clo2_label.Text + "';" _
         + "var naso_label='" + naso_label.Text + "';" + "var temperature_lt_label='" + temperature_lt_label.Text + "';" + "var MinMax_Label='" + MinMax_Label.Text + "';"


        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_log" + "';"

        literal_script.Text = literal_script.Text + "</script>"

        function_javascript = function_javascript + "manage_div();"
        function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 18)
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
        Response.Redirect("~/lta.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=9" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class