Imports System.Globalization
Public Class clock
    Inherits lingua


    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""


    Private Sub clock_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
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
        Dim option_value() As String

        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        option_value = main_function.get_split_str(riga_strumento.value4)
        set_clock(option_value(0))

    End Sub

    Public Sub set_clock(ByVal date_str As String)
        Dim giorno As String
        Dim mese As String
        Dim anno As String
        Dim ore As String
        Dim minuti As String
        Dim am_pm As String

        Dim ore_js As String
        Dim minuti_js As String
        Dim am_pm_js As String

        Dim java_script_variable As java_script = New java_script
        Dim set_variable_javascript(8, 1) As String
        giorno = Mid(date_str, 3, 2)
        mese = Mid(date_str, 5, 2)
        anno = Format(Val(Mid(date_str, 7, 2)) + 2000, "0000")

        ' abilito pulsante modifica
        save_clock_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_clock_new, ""))


        Select Case Mid(date_str, 9, 1)
            Case "0"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """dd-mm-yy"""
                date_format_ggmmaa_enable.Checked = True
            Case "1"
                set_variable_javascript(0, 0) = "formato_data"
                set_variable_javascript(0, 1) = """mm-dd-yy"""
                date_format_mmggaa_enable.Checked = True
            Case "2"
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


        'per javascript
        If Val(Mid(date_str, 11, 2)) > 12 Then
            ore_js = Format((Val(Mid(date_str, 11, 2)) - 12), "00")
            minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
            am_pm_js = " pm"
        End If
        If Val(Mid(date_str, 11, 2)) = 12 Then
            ore_js = Format(Val(Mid(date_str, 11, 2)), "00")
            minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
            am_pm_js = " pm"
        End If
        If Val(Mid(date_str, 11, 2)) < 12 Then 'formato europeo
            ore_js = Format(Val(Mid(date_str, 11, 2)), "00")
            minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
            am_pm_js = " am"
        End If
        set_variable_javascript(7, 0) = "ore_12h"
        set_variable_javascript(7, 1) = """" + " " + ore_js + ":" + minuti_js + am_pm_js + """"

        clock_12_ggmmaa.Text = clock_12_ggmmaa.Text + " " + ore_js + ":" + minuti_js + am_pm_js
        clock_12_mmggaa.Text = clock_12_mmggaa.Text + " " + ore_js + ":" + minuti_js + am_pm_js
        clock_12_aammgg.Text = clock_12_aammgg.Text + " " + ore_js + ":" + minuti_js + am_pm_js
        ore_js = Format(Val(Mid(date_str, 11, 2)), "00")
        minuti_js = Format(Val(Mid(date_str, 13, 2)), "00")
        set_variable_javascript(8, 0) = "ore_24h"
        set_variable_javascript(8, 1) = """" + " " + ore_js + ":" + minuti_js + """"

        clock_24_ggmmaa.Text = clock_24_ggmmaa.Text + " " + ore_js + ":" + minuti_js
        clock_24_mmggaa.Text = clock_24_mmggaa.Text + " " + ore_js + ":" + minuti_js
        clock_24_aammgg.Text = clock_24_aammgg.Text + " " + ore_js + ":" + minuti_js
        'end per java script


        If Mid(date_str, 10, 1) = "0" Then 'formato 12
            time_format_12_enable.Checked = True
            set_variable_javascript(1, 0) = "formato_ora"
            set_variable_javascript(1, 1) = """hh:mm tt"""
            set_variable_javascript(2, 0) = "lunghezza_ora"
            set_variable_javascript(2, 1) = "8"
            set_variable_javascript(3, 0) = "lunghezza_data"
            set_variable_javascript(3, 1) = "19"
            If Val(Mid(date_str, 11, 2)) > 12 Then
                ore = Format((Val(Mid(date_str, 11, 2)) - 12), "00")
                minuti = Format(Val(Mid(date_str, 13, 2)), "00")
                am_pm = " pm"
            End If
            If Val(Mid(date_str, 11, 2)) = 12 Then
                ore = Format(Val(Mid(date_str, 11, 2)), "00")
                minuti = Format(Val(Mid(date_str, 13, 2)), "00")
                am_pm = " pm"
            End If
            If Val(Mid(date_str, 11, 2)) < 12 Then 'formato europeo
                ore = Format(Val(Mid(date_str, 11, 2)), "00")
                minuti = Format(Val(Mid(date_str, 13, 2)), "00")
                am_pm = " am"
            End If
        Else
            time_format_24_enable.Checked = True
            set_variable_javascript(1, 0) = "formato_ora"
            set_variable_javascript(1, 1) = """HH:mm"""
            set_variable_javascript(2, 0) = "lunghezza_ora"
            set_variable_javascript(2, 1) = "5"
            set_variable_javascript(3, 0) = "lunghezza_data"
            set_variable_javascript(3, 1) = "16"

            ore = Format(Val(Mid(date_str, 11, 2)), "00")
            minuti = Format(Val(Mid(date_str, 13, 2)), "00")
            am_pm = ""
        End If
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 8)
        java_script_variable.call_function_javascript_onload(Page, "activate_time_picker();")

        'If am_pm = "" Then
        '    clock_1.Text = clock_1.Text + " " + ore + ":" + minuti
        'Else
        '    clock_1.Text = clock_1.Text + " " + ore + ":" + minuti + am_pm
        'End If
    End Sub

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
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=10&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

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
            If time_format_12_enable.Checked Then '12h
                data = Date.ParseExact(clock_12_ggmmaa.Text, "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMM20yy")
                temp_time = data.ToString("HHmm")
                'data = clock_12_ggmmaa.Text.Split("-")
            Else

                'data = Date.Parse(clock_24_ggmmaa.Text)
                data = Date.ParseExact(clock_24_ggmmaa.Text, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMM20yy")
                temp_time = data.ToString("HHmm")
                'data = clock_24_ggmmaa.Text.Split("-")
            End If
            string_connect = temp_data
            string_connect = string_connect & "0"
        End If
        If date_format_mmggaa_enable.Checked Then 'mm-dd-yy
            If time_format_12_enable.Checked Then '12h
                'data = Date.Parse(clock_12_mmggaa.Text)
                data = Date.ParseExact(clock_12_mmggaa.Text, "MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMM20yy")
                temp_time = data.ToString("HHmm")
            Else
                'data = Date.Parse(clock_12_mmggaa.Text)
                data = Date.ParseExact(clock_24_mmggaa.Text, "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMM20yy")
                temp_time = data.ToString("HHmm")
            End If
            string_connect = temp_data
            string_connect = string_connect & "1"
        End If
        If date_format_aammgg_enable.Checked Then 'yy-mm-dd
            If time_format_12_enable.Checked Then '12h
                'data = Date.Parse(clock_12_aammgg.Text)
                data = Date.ParseExact(clock_12_aammgg.Text, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMM20yy")
                temp_time = data.ToString("HHmm")
            Else
                'data = Date.Parse(clock_12_aammgg.Text)
                data = Date.ParseExact(clock_24_aammgg.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
                temp_data = data.ToString("ddMM20yy")
                temp_time = data.ToString("HHmm")
            End If
            string_connect = temp_data
            string_connect = string_connect & "2"
        End If
        'time1 = data(2).Split(" ")
        'time = time1(1).Split(":")
        If time_format_12_enable.Checked Then '12h

            string_connect = string_connect & temp_time
            string_connect = string_connect & "0"
        End If
        If time_format_24_enable.Checked Then '24h
            string_connect = string_connect & temp_time
            string_connect = string_connect & "1"
        End If
        Return id_485_impianto + "b3ph" + string_connect + "end" & Chr(13)

    End Function
End Class