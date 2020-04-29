Public Class main_ldma
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nome_impianto As String = ""
        Dim codice_impianto As String = ""
        Dim id_485_impianto As String = ""
        Dim statistica As String = ""
        If Not IsPostBack Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_ld_ma(nome_impianto, codice_impianto, id_485_impianto)
            'refresh_max5(nome_impianto, codice_impianto, id_485_impianto, "CODE", "Referente", statistica, "Statistiche", "Strumenti Attivi", "Allarmi", "SetPoint", "Temperature", "Log", "Log All")
        End If
    End Sub
    Public Sub posiziona_ld_ma(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim numero_canali As Integer = 0
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim intestazione As String = ""
        Dim contatore_canale As Integer = 0
        Dim valore_canale_temp As Single = 0
        Dim formato_d As String


        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim setpntr_value() As String
        Dim clockr_value() As String
        Dim servicr_value() As String

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        valuer_value = main_function.get_split_str(riga_strumento.value2)
        allrmr_value = main_function.get_split_str(riga_strumento.value3)
        clockr_value = main_function.get_split_str(riga_strumento.value13)
        setpntr_value = main_function.get_split_str(riga_strumento.value7)
        servicr_value = main_function.get_split_str(riga_strumento.value17)

        numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)

        For i = 1 To numero_canali 'ld può essere duo o tre canali
            'contatore_canale = contatore_canale + 1
            label_canale_temp = main_function_config.get_tipo_strumento_ld_ma(config_value, i, setpntr_value, fattore_divisione_temp)
            'If i = 3 And numero_canali = 3 Then
            '    valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
            'Else
            '    valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            'End If
            'intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), allrmr_value, _
            'riga_strumento.tipo_strumento, outputr_value, GetGlobalResourceObject("ld_global", "range_alarm"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "level"), GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("ld_global", "relay"))
            intestazione = intestazione + crea_canale(i, label_canale_temp)

        Next


        literal12_ma.Text = intestazione
        literal_script.Text = "<script>"
        literal_script.Text = literal_script.Text + "var numero_canali =" + Format(numero_canali, "0") + ";"
        literal_script.Text = literal_script.Text + "var name_t1 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_ldma") + " " + Replace((main_function_config.get_level_tot1(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var name_d1 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_giornaliero_ldma") + " " + Replace((main_function_config.get_level_day1(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var array_t1 =[" + Replace((main_function_config.get_level_tot1(valuer_value) / 10).ToString, ",", ".") + "];"
        literal_script.Text = literal_script.Text + "var array_d1 =[" + Replace((main_function_config.get_level_day1(valuer_value) / 10).ToString, ",", ".") + "];"

        literal_script.Text = literal_script.Text + "var name_t2 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_ldma") + " " + Replace((main_function_config.get_level_tot2(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var name_d2 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_giornaliero_ldma") + " " + Replace((main_function_config.get_level_day2(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var array_t2 =[" + Replace((main_function_config.get_level_tot2(valuer_value) / 10).ToString, ",", ".") + "];"
        literal_script.Text = literal_script.Text + "var array_d2 =[" + Replace((main_function_config.get_level_day2(valuer_value) / 10).ToString, ",", ".") + "];"

        literal_script.Text = literal_script.Text + "var name_t3 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_ldma") + " " + Replace((main_function_config.get_level_tot3(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var name_d3 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_giornaliero_ldma") + " " + Replace((main_function_config.get_level_day3(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var array_t3 =[" + Replace((main_function_config.get_level_tot3(valuer_value) / 10).ToString, ",", ".") + "];"
        literal_script.Text = literal_script.Text + "var array_d3 =[" + Replace((main_function_config.get_level_day3(valuer_value) / 10).ToString, ",", ".") + "];"

        literal_script.Text = literal_script.Text + "var name_t4 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_ldma") + " " + Replace((main_function_config.get_level_tot4(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var name_d4 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_giornaliero_ldma") + " " + Replace((main_function_config.get_level_day4(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var array_t4 =[" + Replace((main_function_config.get_level_tot4(valuer_value) / 10).ToString, ",", ".") + "];"
        literal_script.Text = literal_script.Text + "var array_d4 =[" + Replace((main_function_config.get_level_day4(valuer_value) / 10).ToString, ",", ".") + "];"

        literal_script.Text = literal_script.Text + "var name_t5 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_ldma") + " " + Replace((main_function_config.get_level_tot5(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var name_d5 ='" + GetGlobalResourceObject("ld_global", "totalizzatore_giornaliero_ldma") + " " + Replace((main_function_config.get_level_day5(valuer_value) / 10).ToString, ",", ".") + " L';"
        literal_script.Text = literal_script.Text + "var array_t5 =[" + Replace((main_function_config.get_level_tot5(valuer_value) / 10).ToString, ",", ".") + "];"
        literal_script.Text = literal_script.Text + "var array_d5 =[" + Replace((main_function_config.get_level_day5(valuer_value) / 10).ToString, ",", ".") + "];"

        literal_script.Text = literal_script.Text + "var traduzione_totalizer ='" + GetGlobalResourceObject("ld_global", "totalizzatore_ldma") + "';"
        literal_script.Text = literal_script.Text + "var traduzione_totalizer_giornaliero ='" + GetGlobalResourceObject("ld_global", "totalizzatore_giornaliero_ldma") + "';"
        literal_script.Text = literal_script.Text + "var traduzione_level ='" + GetGlobalResourceObject("ld_global", "livello_ldma") + "';"


        Select Case numero_canali
            Case 2
                literal_script.Text = literal_script.Text + "create_gauge1(" + Replace((main_function_config.get_4ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level1(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma1(servicr_value) / 10).ToString, ",", ".") + ",name_t1,name_d1,array_t1,array_d1);"
                literal_script.Text = literal_script.Text + "create_gauge2(" + Replace((main_function_config.get_4ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level2(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma2(servicr_value) / 10).ToString, ",", ".") + ",name_t2,name_d2,array_t2,array_d2);"

            Case 3
                literal_script.Text = literal_script.Text + "create_gauge1(" + Replace((main_function_config.get_4ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level1(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma1(servicr_value) / 10).ToString, ",", ".") + ",name_t1,name_d1,array_t1,array_d1);"
                literal_script.Text = literal_script.Text + "create_gauge2(" + Replace((main_function_config.get_4ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level2(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma2(servicr_value) / 10).ToString, ",", ".") + ",name_t2,name_d2,array_t2,array_d2);"
                literal_script.Text = literal_script.Text + "create_gauge3(" + Replace((main_function_config.get_4ma_level3(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level3(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level3(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level3(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma3(servicr_value) / 10).ToString, ",", ".") + ",name_t3,name_d3,array_t3,array_d3);"

            Case 4
                literal_script.Text = literal_script.Text + "create_gauge1(" + Replace((main_function_config.get_4ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level1(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma1(servicr_value) / 10).ToString, ",", ".") + ",name_t1,name_d1,array_t1,array_d1);"
                literal_script.Text = literal_script.Text + "create_gauge2(" + Replace((main_function_config.get_4ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level2(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma2(servicr_value) / 10).ToString, ",", ".") + ",name_t2,name_d2,array_t2,array_d2);"

                literal_script.Text = literal_script.Text + "create_gauge3(" + Replace((main_function_config.get_4ma_level3(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level3(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level3(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level3(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma3(servicr_value) / 10).ToString, ",", ".") + ",name_t3,name_d3,array_t3,array_d3);"
                literal_script.Text = literal_script.Text + "create_gauge4(" + Replace((main_function_config.get_4ma_level4(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level4(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level4(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level4(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma4(servicr_value) / 10).ToString, ",", ".") + ",name_t4,name_d4,array_t4,array_d4);"

            Case 5
                literal_script.Text = literal_script.Text + "create_gauge1(" + Replace((main_function_config.get_4ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level1(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level1(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma1(servicr_value) / 10).ToString, ",", ".") + ",name_t1,name_d1,array_t1,array_d1);"
                literal_script.Text = literal_script.Text + "create_gauge2(" + Replace((main_function_config.get_4ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level2(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level2(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma2(servicr_value) / 10).ToString, ",", ".") + ",name_t2,name_d2,array_t2,array_d2);"
                literal_script.Text = literal_script.Text + "create_gauge3(" + Replace((main_function_config.get_4ma_level3(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level3(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level3(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level3(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma3(servicr_value) / 10).ToString, ",", ".") + ",name_t3,name_d3,array_t3,array_d3);"
                literal_script.Text = literal_script.Text + "create_gauge4(" + Replace((main_function_config.get_4ma_level4(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level4(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level4(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level4(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma4(servicr_value) / 10).ToString, ",", ".") + ",name_t4,name_d4,array_t4,array_d4);"
                literal_script.Text = literal_script.Text + "create_gauge5(" + Replace((main_function_config.get_4ma_level5(setpntr_value) / 10).ToString, ",", ".") + "," _
                    + Replace((main_function_config.get_20ma_level5(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_soglia_level5(setpntr_value) / 10).ToString, ",", ".") + "," + Replace((main_function_config.get_level5(valuer_value) / 10).ToString, ",", ".") + ",0,20.0," + Replace((main_function_config.get_sevice_ma5(servicr_value) / 10).ToString, ",", ".") + ",name_t5,name_d5,array_t5,array_d5);"
        End Select

        literal_script.Text = literal_script.Text + "</script>"
        crea_header(clockr_value, GetGlobalResourceObject("max5_global", "temperature"), riga_strumento.tipo_strumento, GetGlobalResourceObject("ld_global", "flow"))
    End Sub
    Private Function crea_canale(ByVal numero_canale As Integer, ByVal label_canale As String) As String
        Dim intestazione As String = ""
        intestazione = intestazione + "<div class=""row-fluid"">"
        intestazione = intestazione + "<div class=""span12"">"
        intestazione = intestazione + "<div class=""widget"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<h3 class=""heading"">" + label_canale + " " + "</h3><div style=""float:right;position:relative;top:-2px;""><span data-toggle=""tooltip"" data-original-title=""Cambia nome al canale"" data-placement=""bottom""><a href="""" class=""btn-action glyphicons pencil btn-success""><i></i></a></span></div></div>"
        intestazione = intestazione + "<div class=""widget-body""  style=""height: 260px"">"
        intestazione = intestazione + "<div id=""container-speed" + Format(numero_canale, "0") + """ class=""widget-body"" style=""width: 300px; height: 250px; float: left"">"


        intestazione = intestazione + "</div>" 'chiusura widget-body
        intestazione = intestazione + "<div id=""container-rpm" + Format(numero_canale, "0") + """ class=""widget-body"" style=""width: 300px; height: 250px; float: left"">"


        intestazione = intestazione + "</div>" 'chiusura widget-body
        intestazione = intestazione + "<div id=""container-tot" + Format(numero_canale, "0") + """ class=""widget-body"" style=""width: 300px; height: 250px; float: left"">"


        intestazione = intestazione + "</div>" 'chiusura widget-body
        intestazione = intestazione + "</div>" 'chiusura widget-body

        intestazione = intestazione + "</div>" 'chiusura widget
        intestazione = intestazione + "</div>" 'chiusura span12


        intestazione = intestazione + "</div>" 'chiusura row-fluid
        Return intestazione

    End Function
    Private Function crea_header(ByVal clock_value() As String, ByVal temperatura_traduzione As String, _
                                  ByVal tipo_strumento As String, ByVal flow_traduzione As String) As String

        Dim formato_data As String = ""
        Dim formato_time As String = ""
        Dim tempor_hr As Integer = 0
        Dim tempor_am_pm As Integer = 0
        Dim ora As String = ""
        formato_data = Mid(clock_value(1), 1, 1)
        formato_time = Mid(clock_value(2), 1, 1)
        tempor_hr = Val(Mid(clock_value(6), 1, 2))
        If (formato_time = "1") Then

            If ((tempor_hr < 12) And (tempor_hr > 0)) Then

                tempor_hr = tempor_hr
                tempor_am_pm = 0

            Else

                If ((tempor_hr = 0) Or (tempor_hr = 12)) Then

                    If (tempor_hr = 0) Then
                        tempor_am_pm = 0
                    Else
                        tempor_am_pm = 1
                    End If
                    tempor_hr = 12
                End If
                If ((tempor_hr > 12)) Then

                    tempor_hr = tempor_hr - 12
                    tempor_am_pm = 1
                End If

            End If
        End If

        If (formato_time = "1") Then

            ora = Format(tempor_hr, "00")
            If (tempor_am_pm = 1) Then 'PM
                ora = ora + ":" + Format(Mid(clock_value(7), 1, 2), "00") + " PM"
            Else
                ora = ora + ":" + Format(Mid(clock_value(7), 1, 2), "00") + " AM"
            End If
        Else
            ora = Format(tempor_hr, "00")
            ora = ora + ":" + Format(Mid(clock_value(7), 1, 2), "00")
        End If

        Select Case formato_time
            Case "0" ' formato 24

            Case "1" ' formato 12

        End Select
        Select Case formato_data
            Case "0"
                literal3_ma.Text = "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + Mid(clock_value(3), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(4), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(5), 1, 2) + _
                    "</span> <span class=""label"">" + ora + "</span></li>"
            Case "1"
                literal3_ma.Text = "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + Mid(clock_value(4), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(3), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(5), 1, 2) + _
                    "</span> <span class=""label"">" + ora + "</span></li>"
            Case "2"
                literal3_ma.Text = "<li class=""glyphicons calendar""><i></i> <span class=""label"">" + Mid(clock_value(5), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(4), 1, 2) + "</span> <span class=""label"">" + Mid(clock_value(3), 1, 2) + _
                    "</span> <span class=""label"">" + ora + "</span></li>"
        End Select
        'end creazione data ora
        'creazione widget temperatura
       

        ' end creazione widget temperatura
      
        'end creazione elenco messaggi generali o allarmi generali

    End Function
End Class