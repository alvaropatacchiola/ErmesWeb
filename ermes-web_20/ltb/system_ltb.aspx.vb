Imports System.Globalization


Public Class system_ltb

    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private Sub system_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim result As String = ""
        result = Page.Request("result")
        If Not IsPostBack Or result = "1" Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            posiziona_system_ltb(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "probe_failure"))
        End If
    End Sub
    Public Sub posiziona_system_ltb(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal probe_fail_alarm_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim parameters_value() As String
        Dim calibrz_value() As String


        ' abilito pulsante modifica
        save_systemltb_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_systemltb_new, ""))

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next
        parameters_value = main_function.get_split_str(riga_strumento.value8)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)


        Dim New_Pass As String
        'Dim Current_Pass As String
        Dim lingua As String
        Dim vis_mV As String
        Dim vis_cl As String
        Dim vis_temp As String

        Dim stby_mod As String
        Dim lock_mod As String



        'Dim java_script_variable As java_script = New java_script
        'Dim set_variable_javascript(1, 1) As String
        Dim function_java As String = ""
        Dim java_script_international As java_script = New java_script
        Dim set_variable_javascript(3, 1) As String
        Dim java_script_variable As java_script = New java_script
        set_variable_javascript(0, 0) = "password_c"
        set_variable_javascript(0, 1) = """" + Mid(parameters_value(1), 1, 4) + """"
        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 1)



        confirm_password.Text = Mid(parameters_value(1), 1, 4)
        new_password.Text = Mid(parameters_value(1), 1, 4)
        old_password.Text = Mid(parameters_value(1), 1, 4)

        lingua = 0

        lingua = Mid(parameters_value(2), 1, 1)


        If lingua = 0 Then
            english.Checked = True
        End If
        If lingua = 2 Then
            english_usa.Checked = True
        End If
        If lingua = 3 Then
            italiano.Checked = True
        End If


        vis_mV = Mid(parameters_value(3), 1, 1)
        vis_cl = Mid(parameters_value(4), 1, 1)
        vis_temp = Mid(parameters_value(5), 1, 1)

        If vis_mV = 0 Then
            view_mv.Checked = True
        End If
        If vis_mV = 1 Then
            view_mv_no.Checked = True
        End If

        If vis_cl = 0 Then
            view_cl.Checked = True
        End If
        If vis_cl = 1 Then
            view_cl_no.Checked = True
        End If

        If vis_temp = 0 Then
            view_temp.Checked = True
        End If
        If vis_temp = 1 Then
            view_temp_no.Checked = True
        End If




        stby_mod = Mid(parameters_value(7), 1, 1)
        lock_mod = Mid(parameters_value(8), 1, 1)

        If stby_mod = 0 Then
            dis_stand.Checked = True
        End If
        If stby_mod = 1 Then
            nc_stand.Checked = True
        End If
        If stby_mod = 2 Then
            no_stand.Checked = True
        End If


        If lock_mod = 0 Then
            Lock_all.Checked = True
        End If
        If lock_mod = 1 Then
            Dos_only.Checked = True
        End If


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

        data_ora = Mid(parameters_value(12), 1, 2)
        data_min = Mid(parameters_value(13), 1, 2)
        data_sec = 0
        data_am = Mid(parameters_value(4), 1, 1)
        data_pm = Mid(parameters_value(5), 1, 1)
        data_giorno = Mid(parameters_value(9), 1, 2)
        data_mese = Mid(parameters_value(10), 1, 2)
        data_anno = Mid(parameters_value(11), 1, 2)
        data_formato = Mid(parameters_value(14), 1, 1)

        data_anno = Format(Val(data_anno) + 2000, "0000")


        ' If data_formato = "0" Then ' europeo  lingua
        If lingua = "0" Then
            '   time_format_24_enable.Checked = True
            data_ora_24 = data_ora
            If (Val(data_ora)) > 12 Then
                data_ora_am_pm = Format((Val(data_ora) - 12), "00")
            Else
                data_ora_am_pm = data_ora
            End If
            'clock_12_ggmmaa.Visible = False
            'clock_24_ggmmaa.Visible = True
        End If

        If lingua = "3" Then
            '   time_format_24_enable.Checked = True
            data_ora_24 = data_ora
            If (Val(data_ora)) > 12 Then
                data_ora_am_pm = Format((Val(data_ora) - 12), "00")
            Else
                data_ora_am_pm = data_ora
            End If
            'clock_12_ggmmaa.Visible = False
            'clock_24_ggmmaa.Visible = True
        End If


        'If data_formato = "1" Then ' americano
        If lingua = "2" Then ' americano    
            '   time_format_12_enable.Checked = True
            data_ora_am_pm = data_ora
            If data_am = "0" And data_pm = "1" Then 'pm
                data_ora_24 = Format((Val(data_ora) + 12), "00")
            Else
                data_ora_24 = Format((Val(data_ora)), "00")
            End If

            'clock_12_ggmmaa.Visible = True
            'clock_24_ggmmaa.Visible = False

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
    Private Function MakeParamString() As String

        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable

        Dim calibrz_value() As String

        Dim Risultato As String
        Dim app As String
        Dim app_lingua As String
        Dim app_view_mv As String
        Dim app_view_cl As String
        Dim app_view_temp As String
        Dim app_stby As String
        Dim app_stby_lock As String

        tabella_strumento = (Session("strumento"))
        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        calibrz_value = main_function.get_split_str(riga_strumento.value4)

        app_lingua = "0"
        If english.Checked = True Then

            app_lingua = "0"
        End If

        If english_usa.Checked = True Then
            app_lingua = "2"

        End If

        If italiano.Checked = True Then
            app_lingua = "3"

        End If


        If view_mv.Checked = True Then

            app_view_mv = "0"
        End If

        If view_mv_no.Checked = True Then
            app_view_mv = "1"

        End If

        If view_cl.Checked = True Then

            app_view_cl = "0"
        End If

        If view_cl_no.Checked = True Then
            app_view_cl = "1"

        End If

        If view_temp.Checked = True Then

            app_view_temp = "0"
        End If

        If view_temp_no.Checked = True Then
            app_view_temp = "1"

        End If


        If dis_stand.Checked = True Then

            app_stby = "0"
        End If

        If nc_stand.Checked = True Then
            app_stby = "1"

        End If

        If no_stand.Checked = True Then
            app_stby = "2"

        End If

        If Lock_all.Checked = True Then

            app_stby_lock = "0"
        End If

        If Dos_only.Checked = True Then
            app_stby_lock = "1"

        End If


        Dim app_data_formato As String
        Dim app_data_ora As String
        Dim app_data_min As String
        Dim app_data_sec As String
        Dim app_data_am As String
        Dim app_data_pm As String
        Dim app_data_mese As String
        Dim app_data_giorno As String
        Dim app_data_anno As String
        Dim app_data_ampm As String

        Dim data As Date


        app_data_formato = 0

        'app_data_formato = Mid(parameters_value(2), 1, 1)




        If english_usa.Checked = True Then
            app_data_formato = "2" 'usa

            'data = Date.Parse(clock_12_ggmmaa.Text)
            data = Date.ParseExact(clock_12_ggmmaa.Text, "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture)

            If InStr(clock_12_ggmmaa.Text, "am") <> 0 Then 'am
                app_data_am = "1"
                app_data_pm = "0"
                app_data_ampm = 0
            End If

            If InStr(clock_12_ggmmaa.Text, "pm") <> 0 Then 'pm
                app_data_am = "0"
                app_data_pm = "1"
                app_data_ampm = 1
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





        Risultato = new_password.Text + app_lingua + app_view_mv + app_view_cl + app_view_temp + "0" + app_stby + app_stby_lock + app_data_giorno + app_data_mese + app_data_anno + app_data_ora + app_data_min + app_data_sec + app_data_ampm
        Return id_485_impianto + "paramw" + Risultato + "paramwend" & Chr(13)




    End Function

    Protected Sub save_systemltb_new_Click(sender As Object, e As EventArgs) Handles save_systemltb_new.Click
        Dim local_connection As Boolean
        Dim new_setpoint As String = ""
        Dim write_setpoint_new As write_setpoint = New write_setpoint
        local_connection = write_setpoint_new.client_connect()
        Dim url_result As String = ""
        new_setpoint = MakeParamString()

        If local_connection Then ' connessione OK

            write_setpoint_new.web_setpoint_change(codice_impianto, id_485_impianto, new_setpoint, url_result)
        Else ' server busy riprovare
            url_result = "result=3"
        End If
        If url_result = "" Then
            url_result = "result=3"
        End If
        write_setpoint_new.client_close()

        Response.Redirect("~/ltb.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=4" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class