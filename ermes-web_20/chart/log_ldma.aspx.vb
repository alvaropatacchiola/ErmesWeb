Public Class log_ldma
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
            For i = 1 To numero_canali
                Select Case i
                    Case 1
                        ch1_enable.Visible = True
                        level1_val_label.Text = main_function_config.get_name_level1(setpntr_value)
                    Case 2
                        ch2_enable.Visible = True
                        level2_val_label.Text = main_function_config.get_name_level2(setpntr_value)
                    Case 3
                        ch3_enable.Visible = True
                        level3_val_label.Text = main_function_config.get_name_level3(setpntr_value)
                    Case 4
                        ch4_enable.Visible = True
                        level4_val_label.Text = main_function_config.get_name_level4(setpntr_value)
                    Case 5
                        ch5_enable.Visible = True
                        level5_val_label.Text = main_function_config.get_name_level5(setpntr_value)
                End Select

            Next
            function_javascript = function_javascript + "set_name('" + level1_val_label.Text + "','" + level2_val_label.Text + "','" + _
                level3_val_label.Text + "','" + level4_val_label.Text + "','" + level5_val_label.Text + "');"

            function_javascript = function_javascript + "get_data('" + codice_impianto + "'," + id_485_impianto + ");"
            function_javascript = function_javascript + "manage_div();"
            'function_javascript = function_javascript + "upgrate_chart();"


            java_script_function.call_function_javascript_onload(Page, function_javascript)
        End If

    End Sub

End Class