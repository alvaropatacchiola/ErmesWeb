Imports System.Globalization

Public Class clock1
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""


    Private Sub clock1_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_clock_tower(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output")
        End If
    End Sub

    Public Sub posiziona_clock_tower(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                  ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim clock_value() As String
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim data_mese As String
        Dim data_giorno As String
        Dim data_anno As String
        Dim data_ora As String
        Dim data_min As String
        Dim am_pm_js As String
        Dim java_script_international As java_script = New java_script
        Dim set_variable_javascript(4, 1) As String
        Dim java_script_variable As java_script = New java_script
        Dim function_java As String = ""
        ' abilito pulsante modifica
        save_clock_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_clock_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        clock_value = main_function.get_split_str(riga_strumento.value5)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)

        data_ora = Mid(clock_value(0), 9, 2)
        data_min = Mid(clock_value(0), 11, 2)


        If international_unit = "US" Then
            function_java = function_java + "set_format_data_12();"
            data_giorno = Mid(clock_value(0), 5, 2)
            data_mese = Mid(clock_value(0), 3, 2)
            data_anno = (Val(Mid(clock_value(0), 7, 2)) + 2000).ToString

        Else
            function_java = function_java + "set_format_data_24();"
            data_giorno = Mid(clock_value(0), 3, 2)
            data_mese = Mid(clock_value(0), 5, 2)
            data_anno = (Val(Mid(clock_value(0), 7, 2)) + 2000).ToString

        End If
        If Val(Mid(clock_value(0), 13, 1)) Then 'am
            am_pm_js = " am"
        Else
            am_pm_js = " pm"
        End If

        clock_12_ggmmaa.Text = data_mese + "-" + data_giorno + "-" + data_anno + " " + data_ora + ":" + data_min + am_pm_js
        clock_24_ggmmaa.Text = data_giorno + "-" + data_mese + "-" + data_anno + " " + data_ora + ":" + data_min

        set_variable_javascript(1, 0) = "data_ddmmyy"
        set_variable_javascript(1, 1) = """" + data_giorno + "-" + data_mese + "-" + data_anno + """"
        set_variable_javascript(2, 0) = "data_mmddyy"
        set_variable_javascript(2, 1) = """" + data_mese + "-" + data_giorno + "-" + data_anno + """"
        set_variable_javascript(3, 0) = "ore_12h"
        set_variable_javascript(3, 1) = """" + " " + data_ora + ":" + data_min + am_pm_js + """"
        set_variable_javascript(4, 0) = "ore_24h"
        set_variable_javascript(4, 1) = """" + " " + data_ora + ":" + data_min + """"


        function_java = function_java + "activate_time_picker();"

        java_script_international.call_function_javascript_onload(Page, function_java)
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 4)

    End Sub
    Private Function MakeDataClock() As String
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim clock_value() As String
        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim app_data_ora As String
        Dim app_data_min As String

        Dim Risultato As String
        Dim AM As Integer
        Dim PM As Integer

        Dim data As Date
        Dim culture As String = "it-IT"



        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        clock_value = main_function.get_split_str(riga_strumento.value5)
        unit_value = main_function.get_split_str(riga_strumento.value1)
        main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)
        If international_unit = "US" Then
            'data = Date.Parse(clock_12_ggmmaa.Text, New CultureInfo(culture, False))
            data = Date.ParseExact(clock_12_ggmmaa.Text, "MM-dd-yyyy hh:mm tt", CultureInfo.InvariantCulture)
            app_data_ora = data.ToString("hh")
            app_data_min = data.ToString("mm")
            If InStr(clock_12_ggmmaa.Text, "am") <> 0 Then 'am
                AM = 1
                PM = 0
            End If

            If InStr(clock_12_ggmmaa.Text, "pm") <> 0 Then 'pm
                AM = 0
                PM = 1
            End If
        Else
            data = Date.Parse(clock_24_ggmmaa.Text, New CultureInfo(culture, False))
            app_data_ora = data.ToString("HH")
            app_data_min = data.ToString("mm")
            AM = 0
            PM = 0
        End If


        Risultato = data.ToString("dd")              ' Day
        Risultato = Risultato + data.ToString("MM")  ' Month
        Risultato = Risultato + data.ToString("yy")  ' Year

        Risultato = Risultato + app_data_ora  ' Hour
        Risultato = Risultato + app_data_min  ' Minute


        Risultato = Risultato + Format(AM, "0") + Format(PM, "0")

        Return id_485_impianto + "clockwMT" + Risultato + "clockwend" & Chr(13)



    End Function
    Protected Sub save_clock_new_Click(sender As Object, e As EventArgs) Handles save_clock_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeDataClock()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/tower.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=13" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class