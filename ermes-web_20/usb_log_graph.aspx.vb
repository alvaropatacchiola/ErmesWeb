Imports System.IO

Public Class usb_log_graph
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codice As String = ""

        codice = Page.Request("codice")
        If InStr(codice, "Tower") <> 0 Then
            tower_enable.Visible = True
            ld_enable.Visible = False
            wd_enable.Visible = False
            max5_enable.Visible = False
            crea_tower_grafico(codice)
        End If
        If InStr(codice, "LD") <> 0 Then
            tower_enable.Visible = False
            ld_enable.Visible = True
            wd_enable.Visible = False
            max5_enable.Visible = False
            crea_ld_grafico(codice)
        End If
        If InStr(codice, "WD") <> 0 Then
            tower_enable.Visible = False
            ld_enable.Visible = False
            max5_enable.Visible = False
            wd_enable.Visible = True
            crea_wd_grafico(codice)
        End If
        If InStr(codice, "WH") <> 0 Then
            tower_enable.Visible = False
            ld_enable.Visible = False
            max5_enable.Visible = False
            wd_enable.Visible = True
            crea_wd_grafico(codice)
        End If
        If InStr(codice, "max5") <> 0 Then
            tower_enable.Visible = False
            ld_enable.Visible = False
            max5_enable.Visible = True
            wd_enable.Visible = false
            crea_max5_grafico(codice)
        End If

    End Sub
    Private Sub crea_max5_grafico(ByVal codice As String)
        Dim function_javascript As String = ""
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim set_variable_javascript(26, 1) As String

        Dim savedFileName_final As String = Server.MapPath(".")
        savedFileName_final = savedFileName_final + "\FileCaricati\" + Session("mid_super").ToString + "\" + codice
        Dim sr As New System.IO.StreamReader(savedFileName_final)
        Dim index As Integer = 0

        set_variable_javascript(0, 0) = "array_ch1"
        set_variable_javascript(0, 1) = "["
        set_variable_javascript(1, 0) = "array_ch2"
        set_variable_javascript(1, 1) = "["
        set_variable_javascript(2, 0) = "array_ch3"
        set_variable_javascript(2, 1) = "["
        set_variable_javascript(3, 0) = "array_ch4"
        set_variable_javascript(3, 1) = "["
        set_variable_javascript(4, 0) = "array_ch5"
        set_variable_javascript(4, 1) = "["
        set_variable_javascript(5, 0) = "array_aa1"
        set_variable_javascript(5, 1) = "["
        set_variable_javascript(6, 0) = "array_aa2"
        set_variable_javascript(6, 1) = "["
        set_variable_javascript(7, 0) = "array_aa3"
        set_variable_javascript(7, 1) = "["
        set_variable_javascript(8, 0) = "array_aa4"
        set_variable_javascript(8, 1) = "["
        set_variable_javascript(9, 0) = "array_aa5"
        set_variable_javascript(9, 1) = "["
        set_variable_javascript(10, 0) = "array_ab1"
        set_variable_javascript(10, 1) = "["
        set_variable_javascript(11, 0) = "array_ab2"
        set_variable_javascript(11, 1) = "["
        set_variable_javascript(12, 0) = "array_ab3"
        set_variable_javascript(12, 1) = "["
        set_variable_javascript(13, 0) = "array_ab4"
        set_variable_javascript(13, 1) = "["
        set_variable_javascript(14, 0) = "array_ab5"
        set_variable_javascript(14, 1) = "["
        set_variable_javascript(15, 0) = "array_ad1"
        set_variable_javascript(15, 1) = "["
        set_variable_javascript(16, 0) = "array_ad2"
        set_variable_javascript(16, 1) = "["
        set_variable_javascript(17, 0) = "array_ad3"
        set_variable_javascript(17, 1) = "["
        set_variable_javascript(18, 0) = "array_ad4"
        set_variable_javascript(18, 1) = "["
        set_variable_javascript(19, 0) = "array_ad5"
        set_variable_javascript(19, 1) = "["
        set_variable_javascript(20, 0) = "array_ar1"
        set_variable_javascript(20, 1) = "["
        set_variable_javascript(21, 0) = "array_ar2"
        set_variable_javascript(21, 1) = "["
        set_variable_javascript(22, 0) = "array_ar3"
        set_variable_javascript(22, 1) = "["
        set_variable_javascript(23, 0) = "array_ar4"
        set_variable_javascript(23, 1) = "["
        set_variable_javascript(24, 0) = "array_ar5"
        set_variable_javascript(24, 1) = "["
        set_variable_javascript(25, 0) = "array_flow"
        set_variable_javascript(25, 1) = "["
        set_variable_javascript(26, 0) = "array_temperatura"
        set_variable_javascript(26, 1) = "["

        Do While sr.Peek() >= 0
            Dim linea() As String
            linea = sr.ReadLine().Split("|")
            If linea(0) <> "" Then
                ch1_enable_max5.Visible = True
                ch1_val_label_max5.Text = linea(0)
            Else
                ch1_enable_max5.Visible = False
            End If
            If linea(1) <> "" Then
                ch2_enable_max5.Visible = True
                ch2_val_label_max5.Text = linea(1)
            Else
                ch2_enable_max5.Visible = False
            End If
            If linea(2) <> "" Then
                ch3_enable_max5.Visible = True
                ch3_val_label_max5.Text = linea(2)
            Else
                ch3_enable_max5.Visible = False
            End If
            If linea(3) <> "" Then
                ch4_enable_max5.Visible = True
                ch4_val_label_max5.Text = linea(3)
            Else
                ch4_enable_max5.Visible = False
            End If
            If linea(4) <> "" Then
                ch5_enable_max5.Visible = True
                ch5_val_label_max5.Text = linea(4)
            Else
                ch5_enable_max5.Visible = False
            End If


            set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[" + linea(5) + "]"
            set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[" + linea(6) + "]"
            set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[" + linea(7) + "]"
            set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[" + linea(8) + "]"
            set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[" + linea(9) + "]"
            If (InStr(linea(10), "dis") = 0) Then
                set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[" + linea(10) + "]"
            Else
                ch1_aa_enable.Visible = False
            End If
            If (InStr(linea(11), "dis") = 0) Then
                set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[" + linea(11) + "]"
            Else
                ch2_aa_enable.Visible = False
            End If

            If (InStr(linea(12), "dis") = 0) Then
                set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[" + linea(12) + "]"
            Else
                ch3_aa_enable.Visible = False
            End If

            If (InStr(linea(13), "dis") = 0) Then
                set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[" + linea(13) + "]"
            Else
                ch4_aa_enable.Visible = False
            End If

            If (InStr(linea(14), "dis") = 0) Then
                set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[" + linea(14) + "]"
            Else
                ch5_aa_enable.Visible = False
            End If

            If (InStr(linea(15), "dis") = 0) Then
                set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[" + linea(15) + "]"
            Else
                ch1_ab_enable.Visible = False
            End If

            If (InStr(linea(16), "dis") = 0) Then
                set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[" + linea(16) + "]"
            Else
                ch2_ab_enable.Visible = False
            End If

            If (InStr(linea(17), "dis") = 0) Then
                set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[" + linea(17) + "]"
            Else
                ch3_ab_enable.Visible = False
            End If

            If (InStr(linea(18), "dis") = 0) Then
                set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[" + linea(18) + "]"
            Else
                ch4_ab_enable.Visible = False
            End If

            If (InStr(linea(19), "dis") = 0) Then
                set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[" + linea(19) + "]"
            Else
                ch5_ab_enable.Visible = False
            End If
            If (InStr(linea(20), "dis") = 0) Then
                set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[" + linea(20) + "]"
            Else
                ch1_ad_enable.Visible = False
            End If

            If (InStr(linea(21), "dis") = 0) Then
                set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[" + linea(21) + "]"
            Else
                ch2_ad_enable.Visible = False
            End If

            If (InStr(linea(22), "dis") = 0) Then
                set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[" + linea(22) + "]"
            Else
                ch3_ad_enable.Visible = False
            End If

            If (InStr(linea(23), "dis") = 0) Then
                set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[" + linea(23) + "]"
            Else
                ch4_ad_enable.Visible = False
            End If

            If (InStr(linea(24), "dis") = 0) Then
                set_variable_javascript(19, 1) = set_variable_javascript(19, 1) + "[" + linea(24) + "]"
            Else
                ch5_ad_enable.Visible = False
            End If

            If (InStr(linea(25), "dis") = 0) Then
                set_variable_javascript(20, 1) = set_variable_javascript(20, 1) + "[" + linea(25) + "]"
            Else
                ch1_ar_enable.Visible = False
            End If

            If (InStr(linea(26), "dis") = 0) Then
                set_variable_javascript(21, 1) = set_variable_javascript(21, 1) + "[" + linea(26) + "]"
            Else
                ch2_ar_enable.Visible = False
            End If

            If (InStr(linea(27), "dis") = 0) Then
                set_variable_javascript(22, 1) = set_variable_javascript(22, 1) + "[" + linea(27) + "]"
            Else
                ch3_ar_enable.Visible = False
            End If
            If (InStr(linea(28), "dis") = 0) Then
                set_variable_javascript(23, 1) = set_variable_javascript(23, 1) + "[" + linea(28) + "]"
            Else
                ch4_ar_enable.Visible = False
            End If
            If (InStr(linea(29), "dis") = 0) Then
                set_variable_javascript(24, 1) = set_variable_javascript(24, 1) + "[" + linea(29) + "]"
            Else
                ch5_ar_enable.Visible = False
            End If
            If (InStr(linea(30), "dis") = 0) Then
                set_variable_javascript(25, 1) = set_variable_javascript(25, 1) + "[" + linea(30) + "]"
            Else
                temperature_max5.Visible = False
            End If

            If (InStr(linea(31), "dis") = 0) Then
                set_variable_javascript(26, 1) = set_variable_javascript(26, 1) + "[" + linea(31) + "]"
            Else
                flow_meter_max5.Visible = False
            End If

            If sr.Peek() >= 0 Then
                Dim j As Integer
                For j = 0 To 26
                    set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
                Next
            End If
        Loop
        Dim k As Integer
        For k = 0 To 26
            set_variable_javascript(k, 1) = set_variable_javascript(k, 1) + "]" + vbCrLf
        Next
        sr.Close()

        literal_script_max5.Text = "<script>"
        Using reader As StreamReader = New StreamReader(Replace(savedFileName_final, ".txt", "_config.txt"))
            ' Read one line from file
            literal_script_max5.Text = literal_script_max5.Text + "var init_date='" + reader.ReadLine + "';"
            literal_script_max5.Text = literal_script_max5.Text + "var last_date='" + reader.ReadLine + "';"
            literal_script_max5.Text = literal_script_max5.Text + "var formato_temperatura='" + reader.ReadLine + "';"
            literal_script_max5.Text = literal_script_max5.Text + "var formato_data='" + reader.ReadLine + "';"
            literal_script_max5.Text = literal_script_max5.Text + "var formato_time='" + reader.ReadLine + "';"
            literal_script_max5.Text = literal_script_max5.Text + "var formato_flusso='" + reader.ReadLine + "';"
        End Using
        literal_script_max5.Text = literal_script_max5.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + "';"


        literal_script_max5.Text = literal_script_max5.Text + "var label_ch1='" + ch1_val_label_max5.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var label_ch2='" + ch2_val_label_max5.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var label_ch3='" + ch3_val_label_max5.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var label_ch4='" + ch4_val_label_max5.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var label_ch5='" + ch5_val_label_max5.Text + "';"


        literal_script_max5.Text = literal_script_max5.Text + "var ch1_aa_label='" + ch1_aa_label.Text + "';" + "var ch2_aa_label='" + ch2_aa_label.Text + "';" + "var ch3_aa_label='" + ch3_aa_label.Text + "';" + "var ch4_aa_label='" + ch4_aa_label.Text + "';" + "var ch5_aa_label='" + ch5_aa_label.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var ch1_ab_label='" + ch1_ab_label.Text + "';" + "var ch2_ab_label='" + ch2_ab_label.Text + "';" + "var ch3_ab_label='" + ch3_ab_label.Text + "';" + "var ch4_ab_label='" + ch4_ab_label.Text + "';" + "var ch5_ab_label='" + ch5_ab_label.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var ch1_ab_label='" + ch1_ad_label.Text + "';" + "var ch2_ad_label='" + ch2_ad_label.Text + "';" + "var ch3_ad_label='" + ch3_ad_label.Text + "';" + "var ch4_ad_label='" + ch4_ad_label.Text + "';" + "var ch5_ad_label='" + ch5_ad_label.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var ch1_ab_label='" + ch1_ar_label.Text + "';" + "var ch2_ar_label='" + ch2_ar_label.Text + "';" + "var ch3_ar_label='" + ch3_ar_label.Text + "';" + "var ch4_ar_label='" + ch4_ar_label.Text + "';" + "var ch5_ar_label='" + ch5_ar_label.Text + "';"


        literal_script_max5.Text = literal_script_max5.Text + "var temperature_label='" + temperature_select_label.Text + "';"
        literal_script_max5.Text = literal_script_max5.Text + "var label_flow_select='" + flow_meter_label_max5.Text + "';"


        literal_script_max5.Text = literal_script_max5.Text + "</script>"
        function_javascript = function_javascript + "sort_array();"

        function_javascript = function_javascript + "manage_div();"
        function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"


        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 26)
        java_script_function.call_function_javascript_onload(Page, function_javascript)


    End Sub
    Private Sub crea_wd_grafico(ByVal codice As String)
        Dim function_javascript As String = ""
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        Dim set_variable_javascript(34, 1) As String

        Dim savedFileName_final As String = Server.MapPath(".")
        savedFileName_final = savedFileName_final + "\FileCaricati\" + Session("mid_super").ToString + "\" + codice
        Dim sr As New System.IO.StreamReader(savedFileName_final)
        Dim index As Integer = 0

        set_variable_javascript(0, 0) = "array_ch1"
        set_variable_javascript(0, 1) = "["
        set_variable_javascript(1, 0) = "array_ch2"
        set_variable_javascript(1, 1) = "["


        set_variable_javascript(2, 0) = "array_dos1"
        set_variable_javascript(2, 1) = "["
        set_variable_javascript(3, 0) = "array_dos2"
        set_variable_javascript(3, 1) = "["

        set_variable_javascript(4, 0) = "array_probe1"
        set_variable_javascript(4, 1) = "["
        set_variable_javascript(5, 0) = "array_probe2"
        set_variable_javascript(5, 1) = "["

        set_variable_javascript(6, 0) = "array_level1"
        set_variable_javascript(6, 1) = "["
        set_variable_javascript(7, 0) = "array_level2"
        set_variable_javascript(7, 1) = "["


        set_variable_javascript(8, 0) = "array_flow"
        set_variable_javascript(8, 1) = "["

        set_variable_javascript(9, 0) = "array_rele_ch1"
        set_variable_javascript(9, 1) = "["
        set_variable_javascript(10, 0) = "array_rele_ch2"
        set_variable_javascript(10, 1) = "["

        set_variable_javascript(11, 0) = "array_soglia_ph"
        set_variable_javascript(11, 1) = "["
        set_variable_javascript(12, 0) = "array_soglia_mv"
        set_variable_javascript(12, 1) = "["
        set_variable_javascript(13, 0) = "array_pipe_all"
        set_variable_javascript(13, 1) = "["
        set_variable_javascript(14, 0) = "array_timeout1"
        set_variable_javascript(14, 1) = "["
        set_variable_javascript(15, 0) = "array_timeout2"
        set_variable_javascript(15, 1) = "["

        set_variable_javascript(16, 0) = "array_sefl_ac"
        set_variable_javascript(16, 1) = "["
        set_variable_javascript(17, 0) = "array_sefl_cl"
        set_variable_javascript(17, 1) = "["
        set_variable_javascript(18, 0) = "array_pump1"
        set_variable_javascript(18, 1) = "["
        set_variable_javascript(19, 0) = "array_pump2"
        set_variable_javascript(19, 1) = "["
        set_variable_javascript(20, 0) = "array_wm1"
        set_variable_javascript(20, 1) = "["
        set_variable_javascript(21, 0) = "array_wm2"
        set_variable_javascript(21, 1) = "["
        set_variable_javascript(22, 0) = "array_wm1T"
        set_variable_javascript(22, 1) = "["
        set_variable_javascript(23, 0) = "array_wm2T"
        set_variable_javascript(23, 1) = "["

        Do While sr.Peek() >= 0
            Dim linea() As String
            linea = sr.ReadLine().Split("|")
            If linea(0) <> "" Then
                ch1_enable_wd.Visible = True
                ch1_val_label_wd.Text = linea(0)
            Else
                ch1_enable_wd.Visible = False
            End If
            If linea(1) <> "" Then
                ch2_enable_wd.Visible = True
                ch2_val_label_wd.Text = linea(1)
            Else
                ch2_enable_wd.Visible = False
            End If
            ch3_enable_wd.Visible = False

            set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[" + linea(2) + "]"
            set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[" + linea(3) + "]"
            If (InStr(linea(4), "Dis") = 0) Then
                set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[" + linea(4) + "]"
            Else
                ch1_dos_enable_wd.Visible = False
            End If

            If (InStr(linea(5), "Dis") = 0) Then
                set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[" + linea(5) + "]"
            Else
                ch2_dos_enable_wd.Visible = False
            End If


            If (InStr(linea(6), "Dis") = 0) Then
                set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[" + linea(6) + "]"
            Else
                ch1_probe_enable_wd.Visible = False
            End If


            If (InStr(linea(7), "Dis") = 0) Then
                set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[" + linea(7) + "]"
            Else
                ch2_probe_enable_wd.Visible = False
            End If

            If (InStr(linea(8), "Dis") = 0) Then
                set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[" + linea(8) + "]"
            Else
                ch1_livello1_enable_wd.Visible = False
            End If
            If (InStr(linea(9), "Dis") = 0) Then
                set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[" + linea(9) + "]"
            Else
                ch2_level1_enable_wd.Visible = False
            End If
            If (InStr(linea(10), "Dis") = 0) Then
                set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[" + linea(10) + "]"
            Else
                flow_select_enable_wd.Visible = False
            End If
            If (InStr(linea(11), "Dis") = 0) Then
                set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[" + linea(11) + "]"
            Else
                ch1_rele_enable_wd.Visible = False
            End If

            If (InStr(linea(12), "Dis") = 0) Then
                set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[" + linea(12) + "]"
            Else
                ch2_rele_enable_wd.Visible = False
            End If

            If (InStr(linea(13), "Dis") = 0) Then
                set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[" + linea(13) + "]"
            Else
                soglia_ph_enable_wd.Visible = False
            End If
            If (InStr(linea(14), "Dis") = 0) Then
                set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[" + linea(14) + "]"
            Else
                soglia_mv_enable_wd.Visible = False
            End If
            If (InStr(linea(15), "Dis") = 0) Then
                set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[" + linea(15) + "]"
            Else
                pipe_all_enable_wd.Visible = False
            End If
            If (InStr(linea(16), "Dis") = 0) Then
                set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[" + linea(16) + "]"
            Else
                timeout1_enable_wd.Visible = False
            End If
            If (InStr(linea(17), "Dis") = 0) Then
                set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[" + linea(17) + "]"
            Else
                timeout2_enable_wd.Visible = False
            End If
            If (InStr(linea(18), "Dis") = 0) Then
                set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[" + linea(18) + "]"
            Else
                sefl_ac_enable_wd.Visible = False
            End If
            If (InStr(linea(19), "Dis") = 0) Then
                set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[" + linea(19) + "]"
            Else
                sefl_cl_enable_wd.Visible = False
            End If
            If (InStr(linea(20), "Dis") = 0) Then
                set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[" + linea(20) + "]"
            Else
                pump1_enable_wd.Visible = False
            End If
            If (InStr(linea(21), "Dis") = 0) Then
                set_variable_javascript(19, 1) = set_variable_javascript(19, 1) + "[" + linea(21) + "]"
            Else
                pump2_enable_wd.Visible = False
            End If
            If (InStr(linea(22), "Dis") = 0) Then
                set_variable_javascript(20, 1) = set_variable_javascript(20, 1) + "[" + linea(22) + "]"
            Else
                wm1_enable_wd.Visible = False
            End If
            If (InStr(linea(23), "Dis") = 0) Then
                set_variable_javascript(21, 1) = set_variable_javascript(21, 1) + "[" + linea(23) + "]"
            Else
                wm2_enable_wd.Visible = False
            End If
            If (InStr(linea(24), "Dis") = 0) Then
                set_variable_javascript(22, 1) = set_variable_javascript(22, 1) + "[" + linea(24) + "]"
            Else
                wm1t_enable_wd.Visible = False
            End If
            If (InStr(linea(25), "Dis") = 0) Then
                set_variable_javascript(23, 1) = set_variable_javascript(23, 1) + "[" + linea(25) + "]"
            Else
                wm2t_enable_wd.Visible = False
            End If

            If sr.Peek() >= 0 Then
                Dim j As Integer
                For j = 0 To 23
                    set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
                Next
            End If
        Loop
        Dim k As Integer
        For k = 0 To 23
            set_variable_javascript(k, 1) = set_variable_javascript(k, 1) + "]" + vbCrLf
        Next
        sr.Close()
        literal_script_wd.Text = "<script>"
        Using reader As StreamReader = New StreamReader(Replace(savedFileName_final, ".txt", "_config.txt"))
            ' Read one line from file
            literal_script_wd.Text = literal_script_wd.Text + "var init_date='" + reader.ReadLine + "';"
            literal_script_wd.Text = literal_script_wd.Text + "var last_date='" + reader.ReadLine + "';"
            literal_script_wd.Text = literal_script_wd.Text + "var formato_data='" + reader.ReadLine + "';"
        End Using
        literal_script_wd.Text = literal_script_wd.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + "';"


        literal_script_wd.Text = literal_script_wd.Text + "var label_ch1='" + ch1_val_label_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_ch2='" + ch2_val_label_wd.Text + "';"


        literal_script_wd.Text = literal_script_wd.Text + "var ch1_dos_label='" + ch1_dos_label_wd.Text + "';" + "var ch1_probe_label='" + ch1_probe_label_wd.Text + "';" + "var ch1_livello1_label='" + ch1_livello1_label_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var ch2_dos_label='" + ch2_dos_label_wd.Text + "';" + "var ch2_probe_label='" + ch2_probe_label_wd.Text + "';" + "var ch2_level2_label='" + ch2_level2_label_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_flow_select='" + label_flow_select_wd.Text + "';"

        literal_script_wd.Text = literal_script_wd.Text + "var label_soglia_ph_wd='" + label_soglia_ph_wd.Text + "';"

        literal_script_wd.Text = literal_script_wd.Text + "var label_soglia_mv_wd='" + label_soglia_mv_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_pipe_all_wd='" + label_pipe_all_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_timeout1_wd='" + label_timeout1_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_timeout2_wd='" + label_timeout2_wd.Text + "';"

        literal_script_wd.Text = literal_script_wd.Text + "var label_sefl_ac_wd='" + label_sefl_ac_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_sefl_cl_wd='" + label_sefl_cl_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_pump1_wd='" + label_pump1_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_pump2_wd='" + label_pump2_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_wm1_wd='" + label_wm1_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_wm2_wd='" + label_wm2_wd.Text + "';"

        literal_script_wd.Text = literal_script_wd.Text + "var label_wm1t_wd='" + label_wm1t_wd.Text + "';"
        literal_script_wd.Text = literal_script_wd.Text + "var label_wm2t_wd='" + label_wm2t_wd.Text + "';"

        literal_script_wd.Text = literal_script_wd.Text + "</script>"
        function_javascript = function_javascript + "sort_array();"

        function_javascript = function_javascript + "manage_div();"
        function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"


        java_script_variable.set_url_setpoint(Page, set_variable_javascript, 34)
        java_script_function.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Private Sub crea_ld_grafico(ByVal codice As String)
        Dim function_javascript As String = ""
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        ' Dim set_variable_javascript(21, 1) As String

        Dim savedFileName_final As String = Server.MapPath(".")

        savedFileName_final = savedFileName_final + "\FileCaricati\" + Session("mid_super").ToString + "\" + codice

        'Dim sr As New System.IO.StreamReader(savedFileName_final)

        Dim index As Integer = 0

        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["
        'set_variable_javascript(2, 0) = "array_ch3"
        'set_variable_javascript(2, 1) = "["

        'set_variable_javascript(3, 0) = "array_feed1"
        'set_variable_javascript(3, 1) = "["
        'set_variable_javascript(4, 0) = "array_feed2"
        'set_variable_javascript(4, 1) = "["

        'set_variable_javascript(5, 0) = "array_dos1"
        'set_variable_javascript(5, 1) = "["
        'set_variable_javascript(6, 0) = "array_dos2"
        'set_variable_javascript(6, 1) = "["

        'set_variable_javascript(7, 0) = "array_probe1"
        'set_variable_javascript(7, 1) = "["
        'set_variable_javascript(8, 0) = "array_probe2"
        'set_variable_javascript(8, 1) = "["

        'set_variable_javascript(9, 0) = "array_level1"
        'set_variable_javascript(9, 1) = "["
        'set_variable_javascript(10, 0) = "array_level2"
        'set_variable_javascript(10, 1) = "["
        'set_variable_javascript(11, 0) = "array_level3"
        'set_variable_javascript(11, 1) = "["


        'set_variable_javascript(12, 0) = "array_flow"
        'set_variable_javascript(12, 1) = "["
        'set_variable_javascript(13, 0) = "array_temperatura"
        'set_variable_javascript(13, 1) = "["
        'set_variable_javascript(14, 0) = "array_stby"
        'set_variable_javascript(14, 1) = "["
        'set_variable_javascript(15, 0) = "array_m3h"
        'set_variable_javascript(15, 1) = "["
        'set_variable_javascript(16, 0) = "array_totalizer"
        'set_variable_javascript(16, 1) = "["

        'Do While sr.Peek() >= 0
        '    Dim linea() As String
        '    linea = sr.ReadLine().Split("|")
        '    If linea(0) <> "" Then
        '        ch1_enable_ld.Visible = True
        '        ch1_val_label_ld.Text = linea(0)
        '    Else
        '        ch1_enable_ld.Visible = False
        '    End If
        '    If linea(1) <> "" Then
        '        If ch1_enable_ld.Visible = False Then
        '            ch2_val_ld.Checked = True
        '        End If
        '        ch2_enable_ld.Visible = True
        '        ch2_val_label_ld.Text = linea(1)
        '    Else
        '        ch2_enable_ld.Visible = False
        '    End If
        '    If linea(2) <> "" Then
        '        ch3_enable_ld.Visible = True
        '        ch3_val_label_ld.Text = linea(2)
        '    Else
        '        ch3_enable_ld.Visible = False
        '    End If
        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[" + linea(3) + "]"
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[" + linea(4) + "]"
        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[" + linea(5) + "]"
        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[" + linea(10) + "]"
        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[" + linea(11) + "]"
        '    set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[" + linea(6) + "]"
        '    set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[" + linea(7) + "]"
        '    set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[" + linea(8) + "]"
        '    set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[" + linea(9) + "]"
        '    set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[" + linea(12) + "]"
        '    set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[" + linea(13) + "]"
        '    set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[" + linea(14) + "]"
        '    set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[" + linea(16) + "]"
        '    set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[" + linea(15) + "]"
        '    If (InStr(linea(17), "dis") <> 0) Then
        '        stby_enable.Visible = False
        '    Else
        '        set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[" + linea(16) + "]"
        '    End If
        '    If (InStr(linea(18), "dis") <> 0) Then
        '        flow_meter_enable.Visible = False
        '    Else
        '        set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[" + linea(17) + "]"
        '    End If
        '    If (InStr(linea(19), "dis") <> 0) Then
        '        flow_meter_enable.Visible = False
        '    Else
        '        set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[" + linea(18) + "]"
        '    End If

        '    If sr.Peek() >= 0 Then
        '        Dim j As Integer
        '        For j = 0 To 16
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If
        'Loop
        'Dim k As Integer
        'For k = 0 To 16
        '    set_variable_javascript(k, 1) = set_variable_javascript(k, 1) + "]" + vbCrLf
        'Next
        'sr.Close()
        literal_script_ld.Text = "<script>"
        Using reader As StreamReader = New StreamReader(Replace(savedFileName_final, ".txt", "_config.txt"))
            ' Read one line from file
            literal_script_ld.Text = literal_script_ld.Text + "var init_date='" + reader.ReadLine + "';"
            literal_script_ld.Text = literal_script_ld.Text + "var last_date='" + reader.ReadLine + "';"
            literal_script_ld.Text = literal_script_ld.Text + "var formato_data='" + reader.ReadLine + "';"
        End Using
        literal_script_ld.Text = literal_script_ld.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + "';"


        literal_script_ld.Text = literal_script_ld.Text + "var label_ch1='" + ch1_val_label_ld.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_ch2='" + ch2_val_label_ld.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_ch3='" + ch3_val_label_ld.Text + "';"

        literal_script_ld.Text = literal_script_ld.Text + "var ch1_feed_label='" + ch1_feed_label.Text + "';" + "var ch1_dos_label='" + ch1_dos_label.Text + "';" + "var ch1_probe_label='" + ch1_probe_label.Text + "';" + "var ch1_livello1_label='" + ch1_livello1_label.Text + "';" + "var ch1_livello2_label='" + ch1_livello2_label.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var ch2_feed_label='" + ch2_feed_label.Text + "';" + "var ch2_dos_label='" + ch2_dos_label.Text + "';" + "var ch2_probe_label='" + ch2_probe_label.Text + "';" + "var ch2_level2_label='" + ch2_level2_label.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_flow_select='" + label_flow_select_ld.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_temperature_select='" + label_temperature_select_ld.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_stby='" + stby_label_ld.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_m3h='" + m3h_label_ld.Text + "';"
        literal_script_ld.Text = literal_script_ld.Text + "var label_totalizer='" + totalizer_label_ld.Text + " (Litre)';"


        literal_script_ld.Text = literal_script_ld.Text + "</script>"

        ' function_javascript = function_javascript + "sort_array();"

        function_javascript = function_javascript + "manage_div();"
        savedFileName_final = savedFileName_final.Replace("\", "!")
        function_javascript = function_javascript + "get_data('" + savedFileName_final + "');"


        ' function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"


        ' java_script_variable.set_url_setpoint(Page, set_variable_javascript, 21)
        java_script_function.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Private Sub crea_tower_grafico(ByVal codice As String)
        Dim function_javascript As String = ""
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script

        'Dim set_variable_javascript(21, 1) As String

        Dim savedFileName_final As String = Server.MapPath(".")
        savedFileName_final = savedFileName_final + "\FileCaricati\" + Session("mid_super").ToString + "\" + codice
        Dim sr As New System.IO.StreamReader(savedFileName_final)
        Dim index As Integer = 0
        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["
        'set_variable_javascript(2, 0) = "array_ch3"
        'set_variable_javascript(2, 1) = "["

        'set_variable_javascript(3, 0) = "array_ch1_high"
        'set_variable_javascript(3, 1) = "["
        'set_variable_javascript(4, 0) = "array_ch1_low"
        'set_variable_javascript(4, 1) = "["
        'set_variable_javascript(5, 0) = "array_ch1_bleed"
        'set_variable_javascript(5, 1) = "["

        'set_variable_javascript(6, 0) = "array_flow"
        'set_variable_javascript(6, 1) = "["


        'set_variable_javascript(7, 0) = "array_ch1_inhibitor"
        'set_variable_javascript(7, 1) = "["

        'set_variable_javascript(8, 0) = "array_ch1_prebiocide1"
        'set_variable_javascript(8, 1) = "["
        'set_variable_javascript(9, 0) = "array_ch1_prebiocide2"
        'set_variable_javascript(9, 1) = "["

        'set_variable_javascript(10, 0) = "array_ch1_biocide1"
        'set_variable_javascript(10, 1) = "["
        'set_variable_javascript(11, 0) = "array_ch1_biocide2"
        'set_variable_javascript(11, 1) = "["
        'set_variable_javascript(12, 0) = "array_ch2_high"
        'set_variable_javascript(12, 1) = "["


        'set_variable_javascript(13, 0) = "array_ch2_low"
        'set_variable_javascript(13, 1) = "["
        'set_variable_javascript(14, 0) = "array_ch2_livello"
        'set_variable_javascript(14, 1) = "["

        'set_variable_javascript(15, 0) = "array_ch3_high"
        'set_variable_javascript(15, 1) = "["


        'set_variable_javascript(16, 0) = "array_ch3_low"
        'set_variable_javascript(16, 1) = "["
        'set_variable_javascript(17, 0) = "array_ch3_livello"
        'set_variable_javascript(17, 1) = "["

        'set_variable_javascript(18, 0) = "array_temperatura"
        'set_variable_javascript(18, 1) = "["
        'Do While sr.Peek() >= 0
        '    Dim linea() As String
        '    linea = sr.ReadLine().Split("|")
        '    If linea(0) <> "" Then
        '        ch1_enable.Visible = True
        '        ch1_val_label.Text = linea(0)
        '    Else
        '        ch1_enable.Visible = False
        '    End If
        '    If linea(1) <> "" Then
        '        ch2_enable.Visible = True
        '        ch2_val_label.Text = linea(1)
        '    Else
        '        ch2_enable.Visible = False
        '    End If
        '    If linea(2) <> "" Then
        '        ch3_enable.Visible = True
        '        ch3_val_label.Text = linea(2)
        '    Else
        '        ch3_enable.Visible = False
        '    End If
        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[" + linea(3) + "]"
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[" + linea(4) + "]"
        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[" + linea(5) + "]"
        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[" + linea(6) + "]"
        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[" + linea(7) + "]"
        '    set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[" + linea(8) + "]"
        '    set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[" + linea(9) + "]"
        '    set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[" + linea(10) + "]"
        '    set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[" + linea(11) + "]"
        '    set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[" + linea(12) + "]"
        '    set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[" + linea(13) + "]"
        '    set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[" + linea(14) + "]"
        '    set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[" + linea(15) + "]"
        '    set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[" + linea(16) + "]"
        '    set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[" + linea(17) + "]"
        '    set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[" + linea(18) + "]"
        '    set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[" + linea(19) + "]"
        '    set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[" + linea(20) + "]"
        '    set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[" + linea(23) + "]"
        '    If sr.Peek() >= 0 Then
        '        Dim j As Integer
        '        For j = 0 To 18
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If
        'Loop
        'Dim k As Integer
        'For k = 0 To 18
        '    set_variable_javascript(k, 1) = set_variable_javascript(k, 1) + "]" + vbCrLf
        'Next
        'sr.Close()
        literal_script.Text = "<script>"
        Using reader As StreamReader = New StreamReader(Replace(savedFileName_final, ".txt", "_config.txt"))
            ' Read one line from file
            literal_script.Text = literal_script.Text + "var init_date='" + reader.ReadLine + "';"
            literal_script.Text = literal_script.Text + "var last_date='" + reader.ReadLine + "';"
            literal_script.Text = literal_script.Text + "var formato_data='" + reader.ReadLine + "';"
        End Using
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + "';"
        literal_script.Text = literal_script.Text + "var ch1_high_label='" + ch1_high_label.Text + "';"

        literal_script.Text = literal_script.Text + "var label_ch1='" + ch1_val_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_ch2='" + ch2_val_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_ch3='" + ch3_val_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch1_low_label='" + ch1_low_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_bleed_label='" + ch1_bleed_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_inhibitor_label='" + ch1_livello_inhibitor_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_prebiocide1_label='" + ch1_livello_prebiocide1_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_prebiocide2_label='" + ch1_livello_prebiocide2_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_livello_biocide1_label='" + ch1_livello_biocide1_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch1_livello_biocide2_label='" + ch1_livello_biocide2_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_high_label='" + ch2_high_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_low_label='" + ch2_low_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch2_livello_label='" + ch2_livello_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch3_high_label='" + ch3_high_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch3_low_label='" + ch3_low_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch3_livello_label='" + ch3_livello_label.Text + "';"

        literal_script.Text = literal_script.Text + "var label_flow_select='" + label_flow_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_temperature_select='" + label_temperature_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_wmi_select='" + label_wmi_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_wmb_select='" + label_wmb_select.Text + "';"


        literal_script.Text = literal_script.Text + "</script>"
        'function_javascript = function_javascript + "sort_array();"

        'function_javascript = function_javascript + "manage_div();"
        'function_javascript = function_javascript + "upgrate_chart();"
        'function_javascript = function_javascript + "create_picker();"
        function_javascript = function_javascript + "manage_div();"
        savedFileName_final = savedFileName_final.Replace("\", "!")
        function_javascript = function_javascript + "get_data('" + savedFileName_final + "');"


        ' function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"


        'java_script_variable.set_url_setpoint(Page, set_variable_javascript, 21)
        java_script_function.call_function_javascript_onload(Page, function_javascript)
    End Sub

End Class