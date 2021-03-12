Imports System.Globalization
Public Class log_tower
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub log_tower_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
        wmi.Checked = Convert.ToBoolean(split_input(19))
        wmb.Checked = Convert.ToBoolean(split_input(20))


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
        stringa_risultato = stringa_risultato + flow_select.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + wmi.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + wmb.Checked.ToString

        Return stringa_risultato
    End Function
    Public Sub posiziona_log(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                              ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.log_towerDataTable
        Dim config_value() As String
        Dim version_str As String = ""
        Dim MTower_Type As String = ""
        Dim str_sonda2 As String = ""
        Dim str_sonda3 As String = ""

        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script
        Dim function_javascript As String = ""
        Dim query As New query
        Dim prima_volta As Boolean = True
        Dim data_prima As String = ""
        Dim data_seconda As String = ""
        Dim international_unit As String = ""
        Dim unit_value() As String
        Dim measure_unit As String = ""
        Dim personalizzazione_aquacare As Integer = 0
        Dim lunghezza_tabella As Integer

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
        config_value = main_function.get_split_str(riga_strumento.value4)
        main_function_config.chek_tower_version(riga_strumento.nome, version_str, personalizzazione_aquacare)
        MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , , , , , , , str_sonda2, str_sonda3)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)
        literal_script.Text = "<script>"

        Select Case MTower_Type
            Case "Cdxxx"
                ch1_enable.Visible = True
                ch2_enable.Visible = False
                ch3_enable.Visible = False
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = "Conductivity"

                literal_script.Text = literal_script.Text + "var label_ch2='" + "" + "';"
                ch2_val_label.Text = ""
                literal_script.Text = literal_script.Text + "var label_ch3='" + "" + "';"

                ch3_val_label.Text = ""

            Case "Cd_pH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = GetGlobalResourceObject("tower_global", "conductivity")
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + "" + "';"
                ch3_val_label.Text = ""

            Case "Cd_rH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"
                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + "" + "';"
                ch3_val_label.Text = ""
            Case "Cd_pH_rH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + str_sonda3 + "';"
                ch3_val_label.Text = str_sonda3

            Case "Cd_rH_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + str_sonda3 + "';"
                ch3_val_label.Text = str_sonda3

            Case "Cd_pH_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + str_sonda3 + "';"
                ch3_val_label.Text = str_sonda3
            Case "Cd_trc_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + str_sonda3 + "';"
                ch3_val_label.Text = str_sonda3
            Case "Cd_trc_rH"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = True
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"

                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + str_sonda3 + "';"
                ch3_val_label.Text = str_sonda3

            Case "Cd_Cl"
                ch1_enable.Visible = True
                ch2_enable.Visible = True
                ch3_enable.Visible = False
                literal_script.Text = literal_script.Text + "var label_ch1='" + GetGlobalResourceObject("tower_global", "conductivity") + "';"
                ch1_val_label.Text = "Conductivity"
                literal_script.Text = literal_script.Text + "var label_ch2='" + str_sonda2 + "';"
                ch2_val_label.Text = str_sonda2
                literal_script.Text = literal_script.Text + "var label_ch3='" + "" + "';"
                ch3_val_label.Text = ""

        End Select

        Dim temporaneo_id As String = ""
        Dim index As Integer = 0

        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        'table_log = query.get_log_tower(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)
        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["
        'set_variable_javascript(2, 0) = "array_ch3"
        'set_variable_javascript(2, 1) = "["

        'set_variable_javascript(3, 0) = "array_ch1_high"
        'set_variable_javascript(3, 1) = "["
        'set_variable_javascript(4, 0) = "array_ch1_low"
        'set_variable_javascript(4, 1) = "["

        'set_variable_javascript(5, 0) = "array_ch1_bleed"
        'set_variable_javascript(5, 1) = "["

        'set_variable_javascript(6, 0) = "array_ch1_inhibitor"
        'set_variable_javascript(6, 1) = "["

        'set_variable_javascript(7, 0) = "array_ch1_prebiocide1"
        'set_variable_javascript(7, 1) = "["
        'set_variable_javascript(8, 0) = "array_ch1_prebiocide2"
        'set_variable_javascript(8, 1) = "["

        'set_variable_javascript(9, 0) = "array_ch1_biocide1"
        'set_variable_javascript(9, 1) = "["
        'set_variable_javascript(10, 0) = "array_ch1_biocide2"
        'set_variable_javascript(10, 1) = "["
        'set_variable_javascript(11, 0) = "array_ch2_high"
        'set_variable_javascript(11, 1) = "["


        'set_variable_javascript(12, 0) = "array_ch2_low"
        'set_variable_javascript(12, 1) = "["
        'set_variable_javascript(13, 0) = "array_ch2_livello"
        'set_variable_javascript(13, 1) = "["

        'set_variable_javascript(14, 0) = "array_ch3_high"
        'set_variable_javascript(14, 1) = "["


        'set_variable_javascript(15, 0) = "array_ch3_low"
        'set_variable_javascript(15, 1) = "["
        'set_variable_javascript(16, 0) = "array_ch3_livello"
        'set_variable_javascript(16, 1) = "["

        'set_variable_javascript(17, 0) = "array_flow"
        'set_variable_javascript(17, 1) = "["
        'set_variable_javascript(18, 0) = "array_temperatura"
        'set_variable_javascript(18, 1) = "["
        'set_variable_javascript(19, 0) = "array_wmi"
        'set_variable_javascript(19, 1) = "["
        'set_variable_javascript(20, 0) = "array_wmb"
        'set_variable_javascript(20, 1) = "["

        'lunghezza_tabella = table_log.Count
        'If lunghezza_tabella > 800 Then
        '    lunghezza_tabella = 800
        'End If

        'Dim k As Integer
        ''For Each dc_log In table_log
        'For k = lunghezza_tabella - 1 To 0 Step -1
        '    Dim dc_log As ermes_web_20.quey_db.log_towerRow
        '    dc_log = table_log.Item(k)

        '    If prima_volta Then
        '        data_prima = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")
        '    End If
        '    prima_volta = False
        '    data_seconda = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")

        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + Replace(dc_log.valore1.ToString(), ",", ".") + "]"
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + Replace(dc_log.valore2.ToString(), ",", ".") + "]"
        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + Replace(dc_log.valore3.ToString(), ",", ".") + "]"

        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.cd_high.ToString + "]"
        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.cd_low.ToString + "]"
        '    set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.bleed_timeout.ToString + "]"
        '    set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.level_inhibitor.ToString + "]"

        '    set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.level_prebiocide1.ToString + "]"
        '    set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.level_prebiocide2.ToString + "]"

        '    set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.level_biocide1.ToString + "]"
        '    set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.level_biocide2.ToString + "]"
        '    set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.ch2_high.ToString + "]"
        '    set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.ch2_low.ToString + "]"
        '    set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.ch2_level.ToString + "]"

        '    set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.ch3_high.ToString + "]"
        '    set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.ch3_low.ToString + "]"
        '    set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.ch3_level.ToString + "]"

        '    set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + dc_log.flow.ToString + "]"

        '    set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + Replace(dc_log.temperatura.ToString(), ",", ".") + "]"

        '    set_variable_javascript(19, 1) = set_variable_javascript(19, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + Val(dc_log.tot_input).ToString + "]"
        '    set_variable_javascript(20, 1) = set_variable_javascript(20, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + Format(dc_log.data.Minute, "00") + ")," + Val(dc_log.tot_bleed).ToString + "]"
        '    index = index + 1
        '    If index < lunghezza_tabella Then
        '        Dim j As Integer
        '        For j = 0 To 20
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If

        'Next
        'If index >= lunghezza_tabella Then
        '    Dim j As Integer
        '    For j = 0 To 20
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


        literal_script.Text = literal_script.Text + "var international_unit='" + international_unit + "';"
        literal_script.Text = literal_script.Text + "var init_date='" + data_prima + "';"
        literal_script.Text = literal_script.Text + "var last_date='" + data_seconda + "';"
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + " " + nome_impianto + "';"
        literal_script.Text = literal_script.Text + "var data_label='" + GetGlobalResourceObject("tower_global", "data") + "';"
        literal_script.Text = literal_script.Text + "var on_label='" + GetGlobalResourceObject("ld_global", "val_ON") + "';"
        literal_script.Text = literal_script.Text + "var off_label='" + GetGlobalResourceObject("ld_global", "val_OFF") + "';"
        literal_script.Text = literal_script.Text + "var ch1_high_label='" + ch1_high_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch1_low_label='" + ch1_low_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_bleed_label='" + ch1_bleed_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_inhibitor_label='" + ch1_livello_inhibitor_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_prebiocide1_label='" + ch1_livello_prebiocide1_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_prebiocide2_label='" + ch1_livello_prebiocide2_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_biocide1_label='" + ch1_livello_biocide1_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch1_livello_biocide2_label='" + ch1_livello_biocide2_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_high_label='" + ch2_high_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_low_label='" + ch2_low_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_livello_label='" + ch2_livello_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch3_high_label='" + ch3_high_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch3_low_label='" + ch3_low_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch3_livello_label='" + ch3_livello_label.Text + "';"

        literal_script.Text = literal_script.Text + "var label_flow_select='" + label_flow_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_temperature_select='" + label_temperature_select.Text + "';"

        literal_script.Text = literal_script.Text + "var label_wmi_select='" + wmi_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_wmb_select='" + wmb_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_poweron_select='" + Power_On.Text + "';"

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

    Protected Sub refresh_log_server_Click(sender As Object, e As EventArgs) Handles refresh_log_server.Click
        Dim init_date As String
        Dim last_date As String
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")
        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=14" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class