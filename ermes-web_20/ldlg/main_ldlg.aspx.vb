Public Class main_ldlg
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
            posiziona_ld_lg(nome_impianto, codice_impianto, id_485_impianto)
            'refresh_max5(nome_impianto, codice_impianto, id_485_impianto, "CODE", "Referente", statistica, "Statistiche", "Strumenti Attivi", "Allarmi", "SetPoint", "Temperature", "Log", "Log All")
        End If
    End Sub
    Public Sub posiziona_ld_lg(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String)
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim numero_canali As Integer = 0
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim intestazione As String = "<div class=""row-fluid"">"
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

        For i = 1 To numero_canali * 2 'ld può essere duo o tre canali
            'contatore_canale = contatore_canale + 1
            '  label_canale_temp = main_function_config.get_tipo_strumento_ld_ma(config_value, i, setpntr_value, fattore_divisione_temp)
            If (i <= numero_canali) Then
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lg(config_value, i, setpntr_value, fattore_divisione_temp)
            Else
                label_canale_temp = main_function_config.get_tipo_strumento_ld_lg(config_value, i + (5 - numero_canali), setpntr_value, fattore_divisione_temp)
            End If

            'If i = 3 And numero_canali = 3 Then
            '    valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
            'Else
            '    valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
            'End If
            'intestazione = intestazione + crea_canale(contatore_canale, GetGlobalResourceObject("max5_global", "canale"), label_canale_temp, valore_canale_temp.ToString, GetGlobalResourceObject("impianto_global", "allarmi"), GetGlobalResourceObject("ld_global", "ingressi"), GetGlobalResourceObject("ld_global", "uscite"), allrmr_value, _
            'riga_strumento.tipo_strumento, outputr_value, GetGlobalResourceObject("ld_global", "range_alarm"), GetGlobalResourceObject("ld_global", "dosing_alarm"), GetGlobalResourceObject("ld_global", "probe_failure"), GetGlobalResourceObject("ld_global", "level"), GetGlobalResourceObject("ld_global", "pulse"), GetGlobalResourceObject("ld_global", "relay"))
            intestazione = intestazione + crea_canale(i, label_canale_temp, numero_canali, valuer_value)
            If i Mod 3 = 0 Then
                intestazione = intestazione + "</div>" 'chiusura row-fluid
                If i < numero_canali * 2 Then
                    intestazione = intestazione + "<div class=""row-fluid"">" 'chiusura row-fluid
                End If

            End If
        Next
        intestazione = intestazione + "<div class=""row-fluid"">" 'chiusura row-fluid
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<div class=""widget"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<h3 class=""heading"">" + "Differential" + " " + "</h3><div style=""float:right;position:relative;top:-2px;""><span data-toggle=""tooltip"" data-original-title=""Cambia nome al canale"" data-placement=""bottom""><a href="""" class=""btn-action glyphicons pencil btn-success""><i></i></a></span></div></div>"
        intestazione = intestazione + "<div class=""widget-body""  >"
        intestazione = intestazione + " <div class=""canale"">" + Str(main_function_config.get_differential(servicr_value) / 10) + "  " + "m3" + "</div>"
        intestazione = intestazione + "</div>" 'chiusura widget-body

        intestazione = intestazione + "</div>" 'chiusura widget
        intestazione = intestazione + "</div>" 'chiusura span12
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<div class=""widget"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<h3 class=""heading"">" + "Delta Percent" + " " + "</h3><div style=""float:right;position:relative;top:-2px;""><span data-toggle=""tooltip"" data-original-title=""Cambia nome al canale"" data-placement=""bottom""><a href="""" class=""btn-action glyphicons pencil btn-success""><i></i></a></span></div></div>"
        intestazione = intestazione + "<div class=""widget-body""  >"
        intestazione = intestazione + " <div class=""canale"">" + Str(main_function_config.get_percent(servicr_value) / 10) + "  " + "%" + "</div>"
        intestazione = intestazione + "</div>" 'chiusura widget-body

        intestazione = intestazione + "</div>" 'chiusura widget
        intestazione = intestazione + "</div>" 'chiusura span12

        intestazione = intestazione + "</div>" 'chiusura row-fluid
        'intestazione = intestazione + "</div>" 'chiusura row-fluid
        literal12_ma.Text = intestazione


        crea_header(clockr_value, GetGlobalResourceObject("max5_global", "temperature"), riga_strumento.tipo_strumento, GetGlobalResourceObject("ld_global", "flow"))

    End Sub
    Private Function crea_canale(ByVal numero_canale As Integer, ByVal label_canale As String, ByVal numero_canali As Integer, ByVal valuer_value() As String) As String
        Dim intestazione As String = ""
        'intestazione = intestazione + "<div class=""row-fluid"">"
        intestazione = intestazione + "<div class=""span4"">"
        intestazione = intestazione + "<div class=""widget"">"
        intestazione = intestazione + "<div class=""widget-head"">"
        intestazione = intestazione + "<h3 class=""heading"">" + label_canale + " " + "</h3><div style=""float:right;position:relative;top:-2px;""><span data-toggle=""tooltip"" data-original-title=""Cambia nome al canale"" data-placement=""bottom""><a href="""" class=""btn-action glyphicons pencil btn-success""><i></i></a></span></div></div>"
        intestazione = intestazione + "<div class=""widget-body""  >"
        If numero_canale <= numero_canali Then
            Select Case numero_canale
                Case 1
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_pump1(valuer_value) / 10) + "  " + "L" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_pump1(valuer_value) / 10) + "  " + "L" + "</div>"
                Case 2
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_pump2(valuer_value) / 10) + "  " + "L" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_pump2(valuer_value) / 10) + "  " + "L" + "</div>"
                Case 3
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_pump3(valuer_value) / 10) + "  " + "L" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_pump3(valuer_value) / 10) + "  " + "L" + "</div>"
                Case 4
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_pump4(valuer_value) / 10) + "  " + "L" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_pump4(valuer_value) / 10) + "  " + "L" + "</div>"
                Case 5
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_pump5(valuer_value) / 10) + "  " + "L" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_pump5(valuer_value) / 10) + "  " + "L" + "</div>"

            End Select
        Else
            Dim indice_temp As Integer = (numero_canale + (5 - numero_canali))
            Select Case indice_temp
                Case 6
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_wm1(valuer_value) / 10) + "  " + "m3" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_wm1(valuer_value) / 10) + "  " + "m3" + "</div>"
                Case 7
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_wm2(valuer_value) / 10) + "  " + "m3" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_wm2(valuer_value) / 10) + "  " + "m3" + "</div>"
                Case 8
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_wm3(valuer_value) / 10) + "  " + "m3" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_wm3(valuer_value) / 10) + "  " + "m3" + "</div>"
                Case 9
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_wm4(valuer_value) / 10) + "  " + "m3" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_wm4(valuer_value) / 10) + "  " + "m3" + "</div>"
                Case 10
                    intestazione = intestazione + " <div class=""canale"">Current: " + Str(main_function_config.get_wm5(valuer_value) / 10) + "  " + "m3" + "</div>"
                    intestazione = intestazione + " <div class=""canale"">Totalizer: " + Str(main_function_config.get_tot_wm5(valuer_value) / 10) + "  " + "m3" + "</div>"
            End Select
        End If


        'intestazione = intestazione + "<div id=""container-rpm" + Format(numero_canale, "0") + """ class=""widget-body"" style=""width: 300px; height: 250px; float: left"">"


        'intestazione = intestazione + "</div>" 'chiusura widget-body
        'intestazione = intestazione + "<div id=""container-tot" + Format(numero_canale, "0") + """ class=""widget-body"" style=""width: 300px; height: 250px; float: left"">"


        'intestazione = intestazione + "</div>" 'chiusura widget-body
        intestazione = intestazione + "</div>" 'chiusura widget-body

        intestazione = intestazione + "</div>" 'chiusura widget
        intestazione = intestazione + "</div>" 'chiusura span12


        ' intestazione = intestazione + "</div>" 'chiusura row-fluid
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