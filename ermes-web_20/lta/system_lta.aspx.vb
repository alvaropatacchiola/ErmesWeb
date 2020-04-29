Imports System.Globalization


Public Class system_lta

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
            posiziona_system_lta(nome_impianto, codice_impianto, id_485_impianto, canale, GetGlobalResourceObject("ld_global", "ma_output"), GetGlobalResourceObject("ld_global", "probe_failure"))
        End If
    End Sub
    Public Sub posiziona_system_lta(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal canale As String, _
                      ByVal setpoint_traduzione As String, ByVal probe_fail_alarm_traduzione As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim parameters_value() As String
        Dim calibrz_value() As String


        ' abilito pulsante modifica
        save_systemlta_new.OnClientClick = String.Format("salva_dati(""{0}""); return false;", _
                    ClientScript.GetPostBackEventReference(save_systemlta_new, ""))

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

        Dim app_pass As Integer


        Dim app_pass_s As String = Mid(parameters_value(2), 1, 1)

        Dim temp_calc As Single = Val(app_pass_s) * 1000
        app_pass = temp_calc

        app_pass_s = Mid(parameters_value(3), 1, 1)
        temp_calc = Val(app_pass_s) * 100
        app_pass = app_pass + temp_calc

        app_pass_s = Mid(parameters_value(4), 1, 1)
        temp_calc = Val(app_pass_s) * 10
        app_pass = app_pass + temp_calc

        app_pass_s = Mid(parameters_value(5), 1, 1)
        temp_calc = Val(app_pass_s) * 1
        app_pass = app_pass + temp_calc

      


        confirm_password.Text = Str(app_pass)
        new_password.Text = Str(app_pass)
        old_password.Text = Str(app_pass)

        app_pass_s = Mid(parameters_value(6), 1, 1)
        temp_calc = Val(app_pass_s) * 1000
        app_pass = temp_calc

        app_pass_s = Mid(parameters_value(7), 1, 1)
        temp_calc = Val(app_pass_s) * 100
        app_pass = app_pass + temp_calc

        app_pass_s = Mid(parameters_value(8), 1, 1)
        temp_calc = Val(app_pass_s) * 10
        app_pass = app_pass + temp_calc

        app_pass_s = Mid(parameters_value(9), 1, 1)
        temp_calc = Val(app_pass_s) * 1
        app_pass = app_pass + temp_calc


        value_dos_check.Text = Mid(parameters_value(1), 1, 2)
        value_user_p.Text = app_pass

        lingua = 0

        lingua = Mid(parameters_value(10), 1, 1)


        If lingua = 0 Then
            english.Checked = True
        End If
        If lingua = 2 Then
            english_usa.Checked = True
        End If
        If lingua = 1 Then
            german.Checked = True
        End If


        vis_mV = Mid(parameters_value(3), 1, 1)
        vis_cl = Mid(parameters_value(4), 1, 1)
        vis_temp = Mid(parameters_value(5), 1, 1)

 




        stby_mod = Mid(parameters_value(7), 1, 1)
        lock_mod = Mid(parameters_value(8), 1, 1)

       


        Dim data_ora As String
        Dim data_min As String
        Dim data_sec As String
        Dim data_ampm As String

        Dim data_mese As String
        Dim data_giorno As String
        Dim data_anno As String
        'Dim data_formato As String
        Dim am_pm_js As String

        Dim data_ora_am_pm As String = ""
        Dim data_ora_24 As String = ""

        data_ora = Mid(parameters_value(14), 1, 2)
        data_min = Mid(parameters_value(15), 1, 2)
        data_sec = 0
        data_ampm = Mid(parameters_value(17), 1, 1)

        data_giorno = Mid(parameters_value(11), 1, 2)
        data_mese = Mid(parameters_value(12), 1, 2)
        data_anno = Mid(parameters_value(13), 1, 2)
        'data_formato = Mid(parameters_value(14), 1, 1)

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

        If lingua = "1" Then
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
            If data_ampm = "1" Then 'pm
                data_ora_24 = Format((Val(data_ora) + 12), "00")
            Else
                data_ora_24 = Format((Val(data_ora)), "00")
            End If

            'clock_12_ggmmaa.Visible = True
            'clock_24_ggmmaa.Visible = False

        End If


        clock_12_ggmmaa.Text = data_giorno + "-" + data_mese + "-" + data_anno
        clock_24_ggmmaa.Text = data_giorno + "-" + data_mese + "-" + data_anno

        If data_ampm = "0" Then
            am_pm_js = " am"
        End If
        If data_ampm = "1" Then
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



        If german.Checked = True Then
            app_lingua = "1"

        End If


        


        Dim app_data_formato As String
        Dim app_data_ora As String
        Dim app_data_min As String
        Dim app_data_sec As String
        Dim app_data_ampm As String

        Dim app_data_mese As String
        Dim app_data_giorno As String
        Dim app_data_anno As String

        Dim app_dos_check As String

        Dim app_new_password As String
        Dim app_value_user_p As String

        Dim data As Date


        app_data_formato = 0

        'app_data_formato = Mid(parameters_value(2), 1, 1)




        If english_usa.Checked = True Then
            app_data_formato = "2" 'usa

            'data = Date.Parse(clock_12_ggmmaa.Text)
            data = Date.ParseExact(clock_12_ggmmaa.Text, "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture)

            If InStr(clock_12_ggmmaa.Text, "am") <> 0 Then 'am
                app_data_ampm = "0"
             
            End If

            If InStr(clock_12_ggmmaa.Text, "pm") <> 0 Then 'pm
              
                app_data_ampm = 1
            End If
            app_data_ora = data.ToString("hh")
            app_data_min = data.ToString("mm")

        Else
            'data = Date.Parse(clock_24_ggmmaa.Text)
            data = Date.ParseExact(clock_24_ggmmaa.Text, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture)
            app_data_formato = "0" 'europe
            app_data_ampm = "1" ' 

            app_data_ora = data.ToString("HH")
            app_data_min = data.ToString("mm")

        End If


        app_data_sec = Format(20, "00")

        app_data_giorno = data.ToString("dd")
        app_data_mese = data.ToString("MM")
        app_data_anno = data.ToString("yy")




        app_dos_check = Format(Val(value_dos_check.Text), "00")

        app_new_password = Format(Val(new_password.Text), "0000")
        app_value_user_p = Format(Val(value_user_p.Text), "0000")




        'Risultato = app_dos_check + new_password.Text + value_user_p.Text + app_lingua + app_data_giorno + app_data_mese + app_data_anno + app_data_ora + app_data_min + app_data_ampm
        Risultato = app_dos_check + app_new_password + app_value_user_p + app_lingua + app_data_giorno + app_data_mese + app_data_anno + app_data_ora + app_data_min + app_data_ampm
        Return id_485_impianto + "paramw" + Risultato + "paramwend" & Chr(13)




    End Function

    Protected Sub save_systemlta_new_Click(sender As Object, e As EventArgs) Handles save_systemlta_new.Click
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

        Response.Redirect("~/lta.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=4" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&" + url_result)

    End Sub
End Class