Public Class log_ldlg
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nome_impianto = Page.Request("nome_impianto")
        nome_impianto = Replace(nome_impianto, "$", " ")
        codice_impianto = Page.Request("codice")
        id_485_impianto = Page.Request("id_485")
        statistica = Page.Request("statistica")

        If Not IsPostBack Then
            Dim java_script_function As java_script = New java_script
            Dim function_javascript As String = ""
            Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
            Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
            Dim config_value() As String
            Dim setpntr_value() As String
            Dim numero_canali As Integer = 0
            Dim i As Integer
            tabella_strumento = (Session("strumento"))

            For Each dc1 In tabella_strumento
                If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                    riga_strumento = dc1
                End If
            Next
            config_value = main_function.get_split_str(riga_strumento.value1)
            setpntr_value = main_function.get_split_str(riga_strumento.value7)
            numero_canali = main_function_config.get_numero_canali_ld_ma(config_value)
            ch1_pump_enable.Visible = False
            ch1_wm_enable.Visible = False
            ch2_pump_enable.Visible = False
            ch2_wm_enable.Visible = False
            ch3_pump_enable.Visible = False
            ch3_wm_enable.Visible = False
            ch4_pump_enable.Visible = False
            ch4_wm_enable.Visible = False
            ch5_pump_enable.Visible = False
            ch5_wm_enable.Visible = False
            For i = 1 To numero_canali
                'If i <= numero_canali Then
                Select Case i
                    Case 1
                        ch1_pump_enable.Visible = True
                        ch1_wm_enable.Visible = True
                        pump1_val_label.Text = main_function_config.get_name_pump(setpntr_value, i)
                        wm1_val_label.Text = main_function_config.get_name_wm(setpntr_value, i + 5)
                    Case 2
                        ch2_pump_enable.Visible = True
                        ch2_wm_enable.Visible = True
                        pump2_val_label.Text = main_function_config.get_name_pump(setpntr_value, i)
                        wm2_val_label.Text = main_function_config.get_name_wm(setpntr_value, i + 5)
                    Case 3
                        ch3_pump_enable.Visible = True
                        ch3_wm_enable.Visible = True
                        pump3_val_label.Text = main_function_config.get_name_pump(setpntr_value, i)
                        wm3_val_label.Text = main_function_config.get_name_wm(setpntr_value, i + 5)
                    Case 4
                        ch4_pump_enable.Visible = True
                        ch4_wm_enable.Visible = True
                        pump4_val_label.Text = main_function_config.get_name_pump(setpntr_value, i)
                        wm4_val_label.Text = main_function_config.get_name_wm(setpntr_value, i + 5)
                    Case 5
                        ch5_pump_enable.Visible = True
                        ch5_wm_enable.Visible = True
                        pump5_val_label.Text = main_function_config.get_name_pump(setpntr_value, i)
                        wm5_val_label.Text = main_function_config.get_name_wm(setpntr_value, i + 5)
                End Select

                'Else
                'Dim indice_temp As Integer = (i + (5 - numero_canali))

                'End If

            Next
            delta_enable.Visible = True
            delta_val_label.Text = main_function_config.get_name_differential(setpntr_value)

            function_javascript = function_javascript + "set_name('" + pump1_val_label.Text + "','" + pump2_val_label.Text + "','" + _
            pump3_val_label.Text + "','" + pump4_val_label.Text + "','" + pump5_val_label.Text + "','" + _
            wm1_val_label.Text + "','" + wm2_val_label.Text + "','" + _
            wm3_val_label.Text + "','" + wm4_val_label.Text + "','" + wm5_val_label.Text + "','" _
            + delta_val_label.Text + "','" + percent_val_label.Text + "');"

            function_javascript = function_javascript + "get_data_new('" + codice_impianto + "'," + id_485_impianto + ");"
            function_javascript = function_javascript + "manage_div();"

            'function_javascript = function_javascript + "upgrate_chart();"


            java_script_function.call_function_javascript_onload(Page, function_javascript)

        End If
    End Sub

End Class