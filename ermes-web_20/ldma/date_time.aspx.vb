Imports System.Globalization
Public Class date_time
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String = ""
        result = Page.Request("result")

        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_clock(nome_impianto, codice_impianto, id_485_impianto, "Timer")
        End If

    End Sub
    Public Sub posiziona_clock(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                          ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim clockr_value() As String
        Dim giorno As String
        Dim mese As String
        Dim anno As String
        Dim minuti As String
        Dim am_pm As String

        Dim formato_time As String = ""
        Dim tempor_hr As Integer = 0
        Dim tempor_am_pm As Integer = 0
        Dim ora_12 As String = ""
        Dim ora_24 As String = ""

        Dim ore_js As String
        Dim minuti_js As String
        Dim am_pm_js As String

        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(8, 1) As String

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        clockr_value = main_function.get_split_str(riga_strumento.value13)


        giorno = clockr_value(3)
        mese = clockr_value(4)
        anno = Format(Val(clockr_value(5)) + 2000, "0000")

        ' abilito pulsante modifica
        save_clock_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_clock_new, ""))


        Select Case clockr_value(1)
            Case "00"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """dd-mm-yy"""
                date_format_ggmmaa_enable.Checked = True
            Case "01"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """mm-dd-yy"""
                date_format_mmggaa_enable.Checked = True
            Case "02"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """yy-mm-dd"""
                date_format_aammgg_enable.Checked = True
        End Select

        clock_12_ggmmaa.Text = giorno + "-" + mese + "-" + anno
        clock_24_ggmmaa.Text = giorno + "-" + mese + "-" + anno
        clock_12_mmggaa.Text = mese + "-" + giorno + "-" + anno
        clock_24_mmggaa.Text = mese + "-" + giorno + "-" + anno
        clock_12_aammgg.Text = anno + "-" + mese + "-" + giorno
        clock_24_aammgg.Text = anno + "-" + mese + "-" + giorno


        set_variable_javascript(4, 0) = "data_ddmmyy"
        set_variable_javascript(4, 1) = """" + giorno + "-" + mese + "-" + anno + """"
        set_variable_javascript(5, 0) = "data_mmddyy"
        set_variable_javascript(5, 1) = """" + mese + "-" + giorno + "-" + anno + """"
        set_variable_javascript(6, 0) = "data_yymmdd"
        set_variable_javascript(6, 1) = """" + anno + "-" + mese + "-" + giorno + """"

        formato_time = clockr_value(2)
        tempor_hr = Val(Mid(clockr_value(6), 1, 2))

        'If (formato_time = "01") Then

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
        ' End If

        'If (formato_time = "01") Then

        ora_12 = Format(tempor_hr, "00")
        If (tempor_am_pm = 1) Then 'PM
            ora_12 = ora_12 + ":" + clockr_value(7) + " pm"
        Else
            ora_12 = ora_12 + ":" + clockr_value(7) + " am"
        End If
        'Else
        ora_24 = clockr_value(6)
        ora_24 = ora_24 + ":" + clockr_value(7)
        'End If

        'per javascript
        'If Val(Mid(date_str, 11, 2)) > 12 Then
        '    ore_js = Format((Val(Mid(date_str, 11, 2)) - 12), "00")
        '    minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
        '    am_pm_js = " pm"
        'End If
        'If Val(Mid(date_str, 11, 2)) = 12 Then
        '    ore_js = Format(Val(Mid(date_str, 11, 2)), "00")
        '    minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
        '    am_pm_js = " pm"
        'End If
        'If Val(Mid(date_str, 11, 2)) < 12 Then 'formato europeo
        '    ore_js = Format(Val(Mid(date_str, 11, 2)), "00")
        '    minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
        '    am_pm_js = " am"
        'End If
        set_variable_javascript(7, 0) = "ore_12h"
        set_variable_javascript(7, 1) = """" + " " + ora_12 + """"

        clock_12_ggmmaa.Text = clock_12_ggmmaa.Text + " " + ora_12
        clock_12_mmggaa.Text = clock_12_mmggaa.Text + " " + ora_12
        clock_12_aammgg.Text = clock_12_aammgg.Text + " " + ora_12

        'ore_js = Format(Val(Mid(date_str, 11, 2)), "00")
        'minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
        set_variable_javascript(8, 0) = "ore_24h"
        set_variable_javascript(8, 1) = """" + " " + ora_24 + """"

        clock_24_ggmmaa.Text = clock_24_ggmmaa.Text + " " + ora_24
        clock_24_mmggaa.Text = clock_24_mmggaa.Text + " " + ora_24
        clock_24_aammgg.Text = clock_24_aammgg.Text + " " + ora_24
        'end per java script


        If (formato_time = "01") Then 'formato 12
            time_format_12_enable.Checked = True
            set_variable_javascript(1, 0) = "formato_ora"
            set_variable_javascript(1, 1) = """hh:mm tt"""
            set_variable_javascript(2, 0) = "lunghezza_ora"
            set_variable_javascript(2, 1) = "8"
            set_variable_javascript(3, 0) = "lunghezza_data"
            set_variable_javascript(3, 1) = "19"

        Else
            time_format_24_enable.Checked = True
            set_variable_javascript(1, 0) = "formato_ora"
            set_variable_javascript(1, 1) = """HH:mm"""
            set_variable_javascript(2, 0) = "lunghezza_ora"
            set_variable_javascript(2, 1) = "5"
            set_variable_javascript(3, 0) = "lunghezza_data"
            set_variable_javascript(3, 1) = "16"


        End If
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 8)
        java_script_variable.call_function_javascript_onload(Page, "activate_time_picker();")

    End Sub
    Private Function MakeClock() As String

        Dim string_connect As String = ""
        'Dim data() As String
        'Dim time1() As String
        'Dim time() As String
        'Dim ore As String
        'Dim minuti As String
        Dim data As Date
        Dim temp_data As String = ""
        Dim temp_time As String = ""
        ' data = ASPxDateEdit3.Date

        'string_connect = Format(data.Day, "00") & Format(data.Month, "00") & Format(data.Year, "00")

        If date_format_ggmmaa_enable.Checked Then 'dd-mm-yy
            string_connect = "0"
            If time_format_12_enable.Checked Then '12h
                string_connect = string_connect + "1"

                data = Date.ParseExact(clock_12_ggmmaa.Text, "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMMyy")
                temp_time = data.ToString("HHmm")
                'data = clock_12_ggmmaa.Text.Split("-")
            Else
                string_connect = string_connect + "0"

                'data = Date.Parse(clock_24_ggmmaa.Text)
                data = Date.ParseExact(clock_24_ggmmaa.Text, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMMyy")
                temp_time = data.ToString("HHmm")
                'data = clock_24_ggmmaa.Text.Split("-")
            End If


            string_connect = string_connect + temp_data + temp_time + "0"
        End If
        If date_format_mmggaa_enable.Checked Then 'mm-dd-yy
            string_connect = "1"
            If time_format_12_enable.Checked Then '12h
                string_connect = string_connect + "1"
                'data = Date.Parse(clock_12_mmggaa.Text)
                data = Date.ParseExact(clock_12_mmggaa.Text, "MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMMyy")
                temp_time = data.ToString("HHmm")
            Else
                string_connect = string_connect + "0"
                'data = Date.Parse(clock_12_mmggaa.Text)
                data = Date.ParseExact(clock_24_mmggaa.Text, "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMMyy")
                temp_time = data.ToString("HHmm")
            End If
            string_connect = string_connect + temp_data + temp_time + "0"
        End If
        If date_format_aammgg_enable.Checked Then 'yy-mm-dd
            string_connect = "2"
            If time_format_12_enable.Checked Then '12h
                string_connect = string_connect + "1"
                'data = Date.Parse(clock_12_aammgg.Text)
                data = Date.ParseExact(clock_12_aammgg.Text, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMMyy")
                temp_time = data.ToString("HHmm")
            Else
                'data = Date.Parse(clock_12_aammgg.Text)
                string_connect = string_connect + "0"
                data = Date.ParseExact(clock_24_aammgg.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMMyy")
                temp_time = data.ToString("HHmm")
            End If
            string_connect = string_connect + temp_data + temp_time + "0"
        End If
        'time1 = data(2).Split(" ")
        'time = time1(1).Split(":")

        Return id_485_impianto + "clockw" + string_connect + "clockwend" & Chr(13)

    End Function

    Protected Sub save_clock_new_Click(sender As Object, e As EventArgs) Handles save_clock_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeClock()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        'javascript_function.call_function_javascript_onload(Page, "result_setpoint_change();")
        Response.Redirect("~/ld.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=52" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)


    End Sub
End Class