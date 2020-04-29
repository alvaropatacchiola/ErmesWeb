Imports System.Globalization
Public Class WebForm8
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""

    Private Sub international_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_international_wd(nome_impianto, codice_impianto, id_485_impianto, canale, "mA Output")
        End If
    End Sub
    Public Sub posiziona_international_wd(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                  ByVal setpoint_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim clock_value() As String

        Dim function_java As String = ""
        Dim java_script_international As java_script = New java_script
        Dim set_variable_javascript(3, 1) As String
        Dim java_script_variable As java_script = New java_script

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        clock_value = main_function.get_split_str(riga_strumento.value13)

        Dim data_ora As String
        Dim data_min As String
        Dim data_sec As String
        Dim data_am As String
        Dim data_pm As String
        Dim data_mese As String
        Dim data_giorno As String
        Dim data_anno As String
        Dim data_formato As String
        Dim am_pm_js As String

        Dim data_ora_am_pm As String = ""
        Dim data_ora_24 As String = ""

        data_ora = Mid(clock_value(1), 1, 2)
        data_min = Mid(clock_value(2), 1, 2)
        data_sec = Mid(clock_value(3), 1, 2)
        data_am = Mid(clock_value(4), 1, 1)
        data_pm = Mid(clock_value(5), 1, 1)
        data_giorno = Mid(clock_value(6), 1, 2)
        data_mese = Mid(clock_value(7), 1, 2)
        data_anno = Mid(clock_value(8), 1, 2)
        data_formato = Mid(clock_value(9), 1, 1)

        data_anno = Format(Val(data_anno) + 2000, "0000")

        'abilito pulsante modifica
        save_international_wd_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_international_wd_new, ""))


        If data_formato = "0" Then ' europeo
            time_format_24_enable.Checked = True
            data_ora_24 = data_ora
            If (Val(data_ora)) > 12 Then
                data_ora_am_pm = Format((Val(data_ora) - 12), "00")
            Else
                data_ora_am_pm = data_ora
            End If

        End If

        If data_formato = "1" Then ' americano
            time_format_12_enable.Checked = True
            data_ora_am_pm = data_ora
            If data_am = "0" And data_pm = "1" Then 'pm
                data_ora_24 = Format((Val(data_ora) + 12), "00")
            Else
                data_ora_24 = Format((Val(data_ora)), "00")

            End If
        End If


        clock_12_ggmmaa.Text = data_giorno + "-" + data_mese + "-" + data_anno
        clock_24_ggmmaa.Text = data_giorno + "-" + data_mese + "-" + data_anno

        If data_am = "1" And data_pm = "0" Then
            am_pm_js = " am"
        End If
        If data_am = "0" And data_pm = "1" Then
            am_pm_js = " pm"
        End If
        clock_12_ggmmaa.Text = clock_12_ggmmaa.Text + " " + data_ora_am_pm + ":" + data_min + am_pm_js
        clock_24_ggmmaa.Text = clock_24_ggmmaa.Text + " " + data_ora_24 + ":" + data_min

        set_variable_javascript(1, 0) = "data_ddmmyy"
        set_variable_javascript(1, 1) = """" + data_giorno + "-" + data_mese + "-" + data_anno + """"
        set_variable_javascript(2, 0) = "ore_12h"
        set_variable_javascript(2, 1) = """" + " " + data_ora_am_pm + ":" + data_min + am_pm_js + """"
        set_variable_javascript(3, 0) = "ore_24h"
        set_variable_javascript(3, 1) = """" + " " + data_ora_24 + ":" + data_min + """"


        function_java = function_java + "activate_time_picker();"
        java_script_international.call_function_javascript_onload(Page, function_java)
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 3)
    End Sub
    Private Function MakeClockString() As String


        Dim app_data_formato As String
        Dim app_data_ora As String
        Dim app_data_min As String
        Dim app_data_sec As String
        Dim app_data_am As String
        Dim app_data_pm As String
        Dim app_data_mese As String
        Dim app_data_giorno As String
        Dim app_data_anno As String
        Dim Risultato As String
        Dim data As Date

        If time_format_12_enable.Checked = True Then
            app_data_formato = "1" 'usa

            'data = Date.Parse(clock_12_ggmmaa.Text)
            data = Date.ParseExact(clock_12_ggmmaa.Text, "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture)
            If InStr(clock_12_ggmmaa.Text, "am") <> 0 Then 'am
                app_data_am = "1"
                app_data_pm = "0"
            End If

            If InStr(clock_12_ggmmaa.Text, "pm") <> 0 Then 'pm
                app_data_am = "0"
                app_data_pm = "1"
            End If
            app_data_ora = data.ToString("hh")
            app_data_min = data.ToString("mm")

        Else
            'data = Date.Parse(clock_24_ggmmaa.Text)
            data = Date.ParseExact(clock_24_ggmmaa.Text, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
            app_data_formato = "0" 'europe
            app_data_am = "1" ' invio sempre am in caso di europeo
            app_data_pm = "0"
            app_data_ora = data.ToString("HH")
            app_data_min = data.ToString("mm")

        End If


        app_data_sec = Format(20, "00")

        app_data_giorno = data.ToString("dd")
        app_data_mese = data.ToString("MM")
        app_data_anno = data.ToString("yy")


        Risultato = id_485_impianto + "clockw" + app_data_ora + app_data_min + app_data_sec + app_data_am + app_data_pm + app_data_giorno + app_data_mese + app_data_anno + app_data_formato + "clockwend" & Chr(13)



        Return Risultato


    End Function

    Protected Sub save_international_wd_new_Click(sender As Object, e As EventArgs) Handles save_international_wd_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeClockString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/wd.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=6" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class