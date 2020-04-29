Imports System.Globalization
Imports System.Threading

Public Class log
    Inherits lingua

    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Private Shared canale As String = ""
    Private trd1 As Thread
    Private Shared init_date As String = ""
    Private Shared last_date As String = ""


    Private Sub log_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        init_date = ""
        last_date = ""
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")


        If Not IsPostBack Then
            nome_impianto = Page.Request("nome_impianto")
            nome_impianto = Replace(nome_impianto, "$", " ")
            codice_impianto = Page.Request("codice")
            id_485_impianto = Page.Request("id_485")
            statistica = Page.Request("statistica")
            ' setting cookie
            Try
                If Request.Cookies(codice_impianto + "_" + id_485_impianto + "_log") Is Nothing Then
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Expires = DateTime.Now.AddMonths(12)  ' il cookie dura 1 anno
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Value = set_coockie()

                Else
                    get_coockie(Request.Cookies(codice_impianto + "_" + id_485_impianto + "_log").Value)
                End If
            Catch ex As Exception

            End Try
            '  trd1 = New Thread(AddressOf posiziona_log_th)
            ' trd1.Start()

            posiziona_log_th()

        End If
    End Sub
    Public Sub posiziona_log_th()
        posiziona_log(nome_impianto, codice_impianto, id_485_impianto, "SetPoint", init_date, last_date)

    End Sub
    Public Sub get_coockie(ByVal input As String)
        Dim split_input() As String = input.Split("z")
        ch1_val.Checked = Convert.ToBoolean(split_input(0))
        ch1_da.Checked = Convert.ToBoolean(split_input(1))
        ch1_db.Checked = Convert.ToBoolean(split_input(2))
        ch1_pa.Checked = Convert.ToBoolean(split_input(3))
        ch1_pb.Checked = Convert.ToBoolean(split_input(4))
        ch1_ma.Checked = Convert.ToBoolean(split_input(5))
        ch1_aa.Checked = Convert.ToBoolean(split_input(6))
        ch1_ab.Checked = Convert.ToBoolean(split_input(7))
        ch1_ad.Checked = Convert.ToBoolean(split_input(8))
        ch1_ar.Checked = Convert.ToBoolean(split_input(9))

        ch2_val.Checked = Convert.ToBoolean(split_input(10))
        ch2_da.Checked = Convert.ToBoolean(split_input(11))
        ch2_db.Checked = Convert.ToBoolean(split_input(12))
        ch2_pa.Checked = Convert.ToBoolean(split_input(13))
        ch2_pb.Checked = Convert.ToBoolean(split_input(14))
        ch2_ma.Checked = Convert.ToBoolean(split_input(15))
        ch2_aa.Checked = Convert.ToBoolean(split_input(16))
        ch2_ab.Checked = Convert.ToBoolean(split_input(17))
        ch2_ad.Checked = Convert.ToBoolean(split_input(18))
        ch2_ar.Checked = Convert.ToBoolean(split_input(19))

        ch3_val.Checked = Convert.ToBoolean(split_input(20))
        'ch3_val.Checked = Convert.ToBoolean(split_input(21))
        ch3_da.Checked = Convert.ToBoolean(split_input(21))
        ch3_db.Checked = Convert.ToBoolean(split_input(22))
        ch3_pa.Checked = Convert.ToBoolean(split_input(23))
        ch3_pb.Checked = Convert.ToBoolean(split_input(24))
        ch3_ma.Checked = Convert.ToBoolean(split_input(25))
        ch3_aa.Checked = Convert.ToBoolean(split_input(26))
        ch3_ab.Checked = Convert.ToBoolean(split_input(27))
        ch3_ad.Checked = Convert.ToBoolean(split_input(28))
        ch3_ar.Checked = Convert.ToBoolean(split_input(29))

        ch4_val.Checked = Convert.ToBoolean(split_input(30))
        'ch4_val.Checked = Convert.ToBoolean(split_input(32))
        ch4_da.Checked = Convert.ToBoolean(split_input(31))
        ch4_db.Checked = Convert.ToBoolean(split_input(32))
        ch4_pa.Checked = Convert.ToBoolean(split_input(33))
        ch4_pb.Checked = Convert.ToBoolean(split_input(34))
        ch4_ma.Checked = Convert.ToBoolean(split_input(35))
        ch4_aa.Checked = Convert.ToBoolean(split_input(36))
        ch4_ab.Checked = Convert.ToBoolean(split_input(37))
        ch4_ad.Checked = Convert.ToBoolean(split_input(38))
        ch4_ar.Checked = Convert.ToBoolean(split_input(39))

        ch5_val.Checked = Convert.ToBoolean(split_input(40))
        'ch5_val.Checked = Convert.ToBoolean(split_input(43))
        ch5_da.Checked = Convert.ToBoolean(split_input(41))
        ch5_db.Checked = Convert.ToBoolean(split_input(42))
        ch5_pa.Checked = Convert.ToBoolean(split_input(43))
        ch5_pb.Checked = Convert.ToBoolean(split_input(44))
        ch5_ma.Checked = Convert.ToBoolean(split_input(45))
        ch5_aa.Checked = Convert.ToBoolean(split_input(46))
        ch5_ab.Checked = Convert.ToBoolean(split_input(47))
        ch5_ad.Checked = Convert.ToBoolean(split_input(48))
        ch5_ar.Checked = Convert.ToBoolean(split_input(49))

        temperature_select.Checked = Convert.ToBoolean(split_input(50))
        flow_meter_low.Checked = Convert.ToBoolean(split_input(51))
        flow_meter.Checked = Convert.ToBoolean(split_input(52))
        flow_select.Checked = Convert.ToBoolean(split_input(53))

    End Sub
    Public Function set_coockie() As String
        Dim stringa_risultato As String = ""
        stringa_risultato = stringa_risultato + ch1_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_da.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_db.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_pa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_pb.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_ma.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_aa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_ab.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_ad.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch1_ar.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch2_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_da.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_db.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_pa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_pb.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_ma.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_aa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_ab.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_ad.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch2_ar.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch3_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_da.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_db.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_pa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_pb.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_ma.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_aa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_ab.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_ad.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch3_ar.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch4_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_da.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_db.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_pa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_pb.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_ma.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch4_aa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_ab.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_ad.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch4_ar.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + ch5_val.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_da.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_db.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_pa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_pb.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_ma.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_aa.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_ab.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_ad.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + ch5_ar.Checked.ToString + "z"

        
        stringa_risultato = stringa_risultato + temperature_select.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow_meter_low.Checked.ToString + "z"
        stringa_risultato = stringa_risultato + flow_meter.Checked.ToString + "z"

        stringa_risultato = stringa_risultato + flow_select.Checked.ToString
        Return stringa_risultato
    End Function
    Public Sub posiziona_log(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, _
                                  ByVal setpoint_traduzione As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.logDataTable

        Dim config_value() As String
        Dim option_value() As String
        Dim label_canale_temp As String = ""
        Dim fattore_divisione_temp As Integer
        Dim full_scale_temp As Integer
        Dim lunghezza_tabella As Integer
        Dim function_javascript As String = ""
        Dim set_variable_javascript(59, 1) As String
        Dim java_script_variable As java_script = New java_script
        Dim java_script_function As java_script = New java_script
        Dim query As New query
        Dim name_sp1() As String
        Dim name_sp2() As String
        Dim name_sp3() As String
        Dim name_sp4() As String
        Dim name_sp5() As String
        Dim data_sp1() As String
        Dim data_sp2() As String
        Dim data_sp3() As String
        Dim data_sp4() As String
        Dim data_sp5() As String

        Dim flow_precedent As String = ""

        Dim valore1_prec As Single = 0
        Dim full1 As Integer = 0
        Dim valore2_prec As Single = 0
        Dim full2 As Integer = 0
        Dim valore3_prec As Single = 0
        Dim full3 As Integer = 0
        Dim valore4_prec As Single = 0
        Dim full4 As Integer = 0
        Dim valore5_prec As Single = 0
        Dim full5 As Integer = 0

        Dim prima_volta As Boolean = True
        Dim data_prima As String = ""
        Dim data_seconda As String = ""

        Dim fattore_divisione_combinato As Integer = 1
        Dim mA_enable As Boolean = False

        Dim number_version As Integer = 0
        Dim data_to As Date
        Dim data_from As Date
        If init_date Is Nothing Or last_date Is Nothing Then
            data_to = Now

            data_from = data_to.AddDays(-30)
            data_to = DateAdd(DateInterval.Day, 1, data_to)
        Else
            Dim culture As String = "it-IT"
            Dim data_from_temp As Date
            Dim data_to_temp As Date
            data_from_temp = Date.Parse(init_date, New CultureInfo(culture, False))
            data_to_temp = Date.Parse(last_date, New CultureInfo(culture, False))
            data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day)
            data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)
        End If



        tabella_strumento = (Session("strumento"))

        For Each dc1 In tabella_strumento
            If dc1.codice = codice_impianto And dc1.id_485 = id_485_impianto Then
                riga_strumento = dc1
            End If
        Next

        config_value = main_function.get_split_str(riga_strumento.value1)
        option_value = main_function.get_split_str(riga_strumento.value4)

        number_version = main_function.get_version_integer(riga_strumento.nome)

        If number_version > 29 Then
            name_sp1 = main_function.get_split_str(riga_strumento.value10)
            name_sp2 = main_function.get_split_str(riga_strumento.value11)
            name_sp3 = main_function.get_split_str(riga_strumento.value12)
            name_sp4 = main_function.get_split_str(riga_strumento.value13)
            name_sp5 = main_function.get_split_str(riga_strumento.value14)
        End If
        data_sp1 = main_function.get_split_str(riga_strumento.value5)
        data_sp2 = main_function.get_split_str(riga_strumento.value6)
        data_sp3 = main_function.get_split_str(riga_strumento.value7)
        data_sp4 = main_function.get_split_str(riga_strumento.value8)
        data_sp5 = main_function.get_split_str(riga_strumento.value9)

        ch1_enable.Visible = False
        ch2_enable.Visible = False
        ch3_enable.Visible = False
        ch4_enable.Visible = False
        ch5_enable.Visible = False
        literal_script.Text = "<script>"

        For i = 1 To 5
            'If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "yagel" And i = 5 Then ' personalizzazione yagel
            '    label_canale_temp = main_function_config.get_tipo_strumento_max5("phY", option_value(0), fattore_divisione_temp)
            'Else
            label_canale_temp = main_function_config.get_tipo_strumento_max5(i, config_value(i - 1), option_value(0), fattore_divisione_temp, full_scale_temp, , , fattore_divisione_combinato)
            'End If

            If label_canale_temp <> "" Then
                Select Case i
                    Case 1
                        ch1_enable.Visible = True

                        full1 = full_scale_temp
                        'set_variable_javascript(53 + i, 0) = "label_ch1"
                        'set_variable_javascript(53 + i, 1) = """" + label_canale_temp + """"
                        literal_script.Text = literal_script.Text + "var label_ch1='" + label_canale_temp + "';"
                        ch1_val_label.Text = label_canale_temp

                        If number_version > 29 Then
                            name_sp1(0) = name_sp1(0).Replace("ph", "")
                            For j = 0 To name_sp1.Length - 1
                                name_sp1(j) = name_sp1(j).Replace("-", "")
                            Next
                            If name_sp1(0).Length > 0 Then
                                ch1_da_label.Text = name_sp1(0)
                            End If
                            If name_sp1(2).Length > 0 Then
                                ch1_db_label.Text = name_sp1(2)
                            End If
                            If name_sp1(4).Length > 0 Then
                                ch1_pa_label.Text = name_sp1(4)
                            End If
                            If name_sp1(6).Length > 0 Then
                                ch1_pb_label.Text = name_sp1(6)
                            End If
                            If name_sp1(8).Length > 0 Then
                                ch1_ma_label.Text = name_sp1(8)
                            End If


                            If name_sp1(10).Length > 0 Then
                                ch1_aa_label.Text = name_sp1(10)
                            End If
                            If name_sp1(11).Length > 0 Then
                                ch1_ab_label.Text = name_sp1(11)
                            End If
                            If name_sp1(12).Length > 0 Then
                                ch1_ad_label.Text = name_sp1(12)
                            End If
                            If name_sp1(13).Length > 0 Then
                                ch1_ar_label.Text = name_sp1(13)
                            End If
                        End If
                        ch1_da_enable.Visible = main_function.enable_da(data_sp1(0))
                        ch1_db_enable.Visible = main_function.enable_db(data_sp1(0))
                        ch1_pa_enable.Visible = main_function.enable_pa(data_sp1(0))
                        ch1_pb_enable.Visible = main_function.enable_pb(data_sp1(0))
                        ch1_ma_enable.Visible = main_function.enable_ma(data_sp1(0))
                        ch1_aa_enable.Visible = main_function.enable_aa(data_sp1(0))
                        ch1_ab_enable.Visible = main_function.enable_ab(data_sp1(0))
                        ch1_ad_enable.Visible = main_function.enable_ad(data_sp1(0))
                        ch1_ar_enable.Visible = main_function.enable_ar(data_sp1(0))
                    Case 2
                        ch2_enable.Visible = True
                        full2 = full_scale_temp
                        'set_variable_javascript(53 + i, 0) = "label_ch2"
                        'set_variable_javascript(53 + i, 1) = """" + label_canale_temp + """"
                        literal_script.Text = literal_script.Text + "var label_ch2='" + label_canale_temp + "';"
                        ch2_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp2(0) = name_sp2(0).Replace("ph", "")
                            For j = 0 To name_sp2.Length - 1
                                name_sp2(j) = name_sp2(j).Replace("-", "")
                            Next
                            If name_sp2(0).Length > 0 Then
                                ch2_da_label.Text = name_sp2(0)
                            End If
                            If name_sp2(2).Length > 0 Then
                                ch2_db_label.Text = name_sp2(2)
                            End If
                            If name_sp2(4).Length > 0 Then
                                ch2_pa_label.Text = name_sp2(4)
                            End If
                            If name_sp2(6).Length > 0 Then
                                ch2_pb_label.Text = name_sp2(6)
                            End If
                            If name_sp2(8).Length > 0 Then
                                ch2_ma_label.Text = name_sp2(8)
                            End If
                            If name_sp2(10).Length > 0 Then
                                ch2_aa_label.Text = name_sp2(10)
                            End If
                            If name_sp2(11).Length > 0 Then
                                ch2_ab_label.Text = name_sp2(11)
                            End If
                            If name_sp2(12).Length > 0 Then
                                ch2_ad_label.Text = name_sp2(12)
                            End If
                            If name_sp2(13).Length > 0 Then
                                ch2_ar_label.Text = name_sp2(13)
                            End If

                        End If
                        ch2_da_enable.Visible = main_function.enable_da(data_sp2(0))
                        ch2_db_enable.Visible = main_function.enable_db(data_sp2(0))
                        ch2_pa_enable.Visible = main_function.enable_pa(data_sp2(0))
                        ch2_pb_enable.Visible = main_function.enable_pb(data_sp2(0))
                        ch2_ma_enable.Visible = main_function.enable_ma(data_sp2(0))
                        ch2_aa_enable.Visible = main_function.enable_aa(data_sp2(0))
                        ch2_ab_enable.Visible = main_function.enable_ab(data_sp2(0))
                        ch2_ad_enable.Visible = main_function.enable_ad(data_sp2(0))
                        ch2_ar_enable.Visible = main_function.enable_ar(data_sp2(0))

                    Case 3
                        ch3_enable.Visible = True
                        full3 = full_scale_temp
                        If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" Then
                            label_canale_temp = "HClO"
                            full3 = 5
                        End If
                        'set_variable_javascript(53 + i, 0) = "label_ch3"
                        'set_variable_javascript(53 + i, 1) = """" + label_canale_temp + """"
                        literal_script.Text = literal_script.Text + "var label_ch3='" + label_canale_temp + "';"
                        ch3_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp3(0) = name_sp3(0).Replace("ph", "")
                            For j = 0 To name_sp3.Length - 1
                                name_sp3(j) = name_sp3(j).Replace("-", "")
                            Next
                            If name_sp3(0).Length > 0 Then
                                ch3_da_label.Text = name_sp3(0)
                            End If
                            If name_sp3(2).Length > 0 Then
                                ch3_db_label.Text = name_sp3(2)
                            End If
                            If name_sp3(4).Length > 0 Then
                                ch3_pa_label.Text = name_sp3(4)
                            End If
                            If name_sp3(6).Length > 0 Then
                                ch3_pb_label.Text = name_sp3(6)
                            End If
                            If name_sp3(8).Length > 0 Then
                                ch3_ma_label.Text = name_sp3(8)
                            End If
                            If name_sp3(10).Length > 0 Then
                                ch3_aa_label.Text = name_sp3(10)
                            End If
                            If name_sp3(11).Length > 0 Then
                                ch3_ab_label.Text = name_sp3(11)
                            End If
                            If name_sp3(12).Length > 0 Then
                                ch3_ad_label.Text = name_sp3(12)
                            End If
                            If name_sp3(13).Length > 0 Then
                                ch3_ar_label.Text = name_sp3(13)
                            End If

                        End If
                        ch3_da_enable.Visible = main_function.enable_da(data_sp3(0))
                        ch3_db_enable.Visible = main_function.enable_db(data_sp3(0))
                        ch3_pa_enable.Visible = main_function.enable_pa(data_sp3(0))
                        ch3_pb_enable.Visible = main_function.enable_pb(data_sp3(0))
                        ch3_ma_enable.Visible = main_function.enable_ma(data_sp3(0))
                        ch3_aa_enable.Visible = main_function.enable_aa(data_sp3(0))
                        ch3_ab_enable.Visible = main_function.enable_ab(data_sp3(0))
                        ch3_ad_enable.Visible = main_function.enable_ad(data_sp3(0))
                        ch3_ar_enable.Visible = main_function.enable_ar(data_sp3(0))

                    Case 4
                        ch4_enable.Visible = True
                        full4 = full_scale_temp
                        If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "seiCanali" Then
                            label_canale_temp = "Cl2"
                            full4 = 20
                        End If
                        'set_variable_javascript(53 + i, 0) = "label_ch4"
                        'set_variable_javascript(53 + i, 1) = """" + label_canale_temp + """"
                        literal_script.Text = literal_script.Text + "var label_ch4='" + label_canale_temp + "';"
                        ch4_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp4(0) = name_sp4(0).Replace("ph", "")
                            For j = 0 To name_sp4.Length - 1
                                name_sp4(j) = name_sp4(j).Replace("-", "")
                            Next
                            If name_sp4(0).Length > 0 Then
                                ch4_da_label.Text = name_sp4(0)
                            End If
                            If name_sp4(2).Length > 0 Then
                                ch4_db_label.Text = name_sp4(2)
                            End If
                            If name_sp4(4).Length > 0 Then
                                ch4_pa_label.Text = name_sp4(4)
                            End If
                            If name_sp4(6).Length > 0 Then
                                ch4_pb_label.Text = name_sp4(6)
                            End If
                            If name_sp4(8).Length > 0 Then
                                ch4_ma_label.Text = name_sp4(8)
                            End If
                            If name_sp4(10).Length > 0 Then
                                ch4_aa_label.Text = name_sp4(10)
                            End If
                            If name_sp4(11).Length > 0 Then
                                ch4_ab_label.Text = name_sp4(11)
                            End If
                            If name_sp4(12).Length > 0 Then
                                ch4_ad_label.Text = name_sp4(12)
                            End If
                            If name_sp4(13).Length > 0 Then
                                ch4_ar_label.Text = name_sp4(13)
                            End If

                        End If
                        ch4_da_enable.Visible = main_function.enable_da(data_sp4(0))
                        ch4_db_enable.Visible = main_function.enable_db(data_sp4(0))
                        ch4_pa_enable.Visible = main_function.enable_pa(data_sp4(0))
                        ch4_pb_enable.Visible = main_function.enable_pb(data_sp4(0))
                        ch4_ma_enable.Visible = main_function.enable_ma(data_sp4(0))
                        ch4_aa_enable.Visible = main_function.enable_aa(data_sp4(0))
                        ch4_ab_enable.Visible = main_function.enable_ab(data_sp4(0))
                        ch4_ad_enable.Visible = main_function.enable_ad(data_sp4(0))
                        ch4_ar_enable.Visible = main_function.enable_ar(data_sp4(0))

                    Case 5
                        ch5_enable.Visible = True
                        full5 = full_scale_temp
                        'set_variable_javascript(53 + i, 0) = "label_ch5"
                        'set_variable_javascript(53 + i, 1) = """" + label_canale_temp + """"
                        literal_script.Text = literal_script.Text + "var label_ch5='" + label_canale_temp + "';"
                        ch5_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp5(0) = name_sp2(0).Replace("ph", "")
                            For j = 0 To name_sp5.Length - 1
                                name_sp5(j) = name_sp5(j).Replace("-", "")
                            Next
                            If name_sp5(0).Length > 0 Then
                                ch5_da_label.Text = name_sp5(0)
                            End If
                            If name_sp5(2).Length > 0 Then
                                ch5_db_label.Text = name_sp5(2)
                            End If
                            If name_sp5(4).Length > 0 Then
                                ch5_pa_label.Text = name_sp5(4)
                            End If
                            If name_sp5(6).Length > 0 Then
                                ch5_pb_label.Text = name_sp5(6)
                            End If
                            If name_sp5(8).Length > 0 Then
                                ch5_ma_label.Text = name_sp5(8)
                            End If
                            If name_sp5(10).Length > 0 Then
                                ch5_aa_label.Text = name_sp5(10)
                            End If
                            If name_sp5(11).Length > 0 Then
                                ch5_ab_label.Text = name_sp5(11)
                            End If
                            If name_sp5(12).Length > 0 Then
                                ch5_ad_label.Text = name_sp5(12)
                            End If
                            If name_sp5(13).Length > 0 Then
                                ch5_ar_label.Text = name_sp5(13)
                            End If

                        End If
                        ch5_da_enable.Visible = main_function.enable_da(data_sp5(0))
                        ch5_db_enable.Visible = main_function.enable_db(data_sp5(0))
                        ch5_pa_enable.Visible = main_function.enable_pa(data_sp5(0))
                        ch5_pb_enable.Visible = main_function.enable_pb(data_sp5(0))
                        ch5_ma_enable.Visible = main_function.enable_ma(data_sp5(0))
                        ch5_aa_enable.Visible = main_function.enable_aa(data_sp5(0))
                        ch5_ab_enable.Visible = main_function.enable_ab(data_sp5(0))
                        ch5_ad_enable.Visible = main_function.enable_ad(data_sp5(0))
                        ch5_ar_enable.Visible = main_function.enable_ar(data_sp5(0))

                End Select
            Else

            End If
        Next
        If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "yagel" Then
            'set_variable_javascript(59, 0) = "yagel_personalizzazione"
            'set_variable_javascript(59, 1) = """true"""
            literal_script.Text = literal_script.Text + "var yagel_personalizzazione=true;"
            flow_meter_low_enable.Visible = True

        Else
            'set_variable_javascript(59, 0) = "yagel_personalizzazione"
            'set_variable_javascript(59, 1) = """false"""
            literal_script.Text = literal_script.Text + "var yagel_personalizzazione=false;"
            flow_meter_low_enable.Visible = False
        End If
        If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "doppiaPiscina" Then
            literal_script.Text = literal_script.Text + "var doppiaPiscina=true;"
            label_flow_select.Text = label_flow_select.Text + "1"
            label_flow_select2.Text = label_flow_select2.Text + "2"
            temperature_select_label.Text = temperature_select_label.Text + "1"
            temperature_select_label2.Text = temperature_select_label2.Text + "2"
            temperature2.Visible = True
            flow2Doppia.Visible = True
        Else
            literal_script.Text = literal_script.Text + "var doppiaPiscina=false;"
            temperature2.Visible = False
            flow2Doppia.Visible = False
        End If
        Dim temporaneo_id As String = ""
        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        'table_log = query.get_log_max5(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)
        'Dim index As Integer = 0
        'set_variable_javascript(0, 0) = "array_ch1"
        'set_variable_javascript(0, 1) = "["
        'set_variable_javascript(1, 0) = "array_ch2"
        'set_variable_javascript(1, 1) = "["
        'set_variable_javascript(2, 0) = "array_ch3"
        'set_variable_javascript(2, 1) = "["
        'set_variable_javascript(3, 0) = "array_ch4"
        'set_variable_javascript(3, 1) = "["
        'set_variable_javascript(4, 0) = "array_ch5"
        'set_variable_javascript(4, 1) = "["
        'set_variable_javascript(5, 0) = "array_aa1"
        'set_variable_javascript(5, 1) = "["
        'set_variable_javascript(6, 0) = "array_aa2"
        'set_variable_javascript(6, 1) = "["
        'set_variable_javascript(7, 0) = "array_aa3"
        'set_variable_javascript(7, 1) = "["
        'set_variable_javascript(8, 0) = "array_aa4"
        'set_variable_javascript(8, 1) = "["
        'set_variable_javascript(9, 0) = "array_aa5"
        'set_variable_javascript(9, 1) = "["
        'set_variable_javascript(10, 0) = "array_ab1"
        'set_variable_javascript(10, 1) = "["
        'set_variable_javascript(11, 0) = "array_ab2"
        'set_variable_javascript(11, 1) = "["
        'set_variable_javascript(12, 0) = "array_ab3"
        'set_variable_javascript(12, 1) = "["
        'set_variable_javascript(13, 0) = "array_ab4"
        'set_variable_javascript(13, 1) = "["
        'set_variable_javascript(14, 0) = "array_ab5"
        'set_variable_javascript(14, 1) = "["
        'set_variable_javascript(15, 0) = "array_ad1"
        'set_variable_javascript(15, 1) = "["
        'set_variable_javascript(16, 0) = "array_ad2"
        'set_variable_javascript(16, 1) = "["
        'set_variable_javascript(17, 0) = "array_ad3"
        'set_variable_javascript(17, 1) = "["
        'set_variable_javascript(18, 0) = "array_ad4"
        'set_variable_javascript(18, 1) = "["
        'set_variable_javascript(19, 0) = "array_ad5"
        'set_variable_javascript(19, 1) = "["
        'set_variable_javascript(20, 0) = "array_ar1"
        'set_variable_javascript(20, 1) = "["
        'set_variable_javascript(21, 0) = "array_ar2"
        'set_variable_javascript(21, 1) = "["
        'set_variable_javascript(22, 0) = "array_ar3"
        'set_variable_javascript(22, 1) = "["
        'set_variable_javascript(23, 0) = "array_ar4"
        'set_variable_javascript(23, 1) = "["
        'set_variable_javascript(24, 0) = "array_ar5"
        'set_variable_javascript(24, 1) = "["
        'set_variable_javascript(25, 0) = "array_flow"
        'set_variable_javascript(25, 1) = "["
        'set_variable_javascript(26, 0) = "array_temperatura"
        'set_variable_javascript(26, 1) = "["
        'set_variable_javascript(27, 0) = "array_fml"
        'set_variable_javascript(27, 1) = "["
        'set_variable_javascript(28, 0) = "array_wm"
        'set_variable_javascript(28, 1) = "["

        'set_variable_javascript(29, 0) = "array_da1"
        'set_variable_javascript(29, 1) = "["
        'set_variable_javascript(30, 0) = "array_db1"
        'set_variable_javascript(30, 1) = "["
        'set_variable_javascript(31, 0) = "array_pa1"
        'set_variable_javascript(31, 1) = "["
        'set_variable_javascript(32, 0) = "array_pb1"
        'set_variable_javascript(32, 1) = "["
        'set_variable_javascript(33, 0) = "array_ma1"
        'set_variable_javascript(33, 1) = "["

        'set_variable_javascript(34, 0) = "array_da2"
        'set_variable_javascript(34, 1) = "["
        'set_variable_javascript(35, 0) = "array_db2"
        'set_variable_javascript(35, 1) = "["
        'set_variable_javascript(36, 0) = "array_pa2"
        'set_variable_javascript(36, 1) = "["
        'set_variable_javascript(37, 0) = "array_pb2"
        'set_variable_javascript(37, 1) = "["
        'set_variable_javascript(38, 0) = "array_ma2"
        'set_variable_javascript(38, 1) = "["

        'set_variable_javascript(39, 0) = "array_da3"
        'set_variable_javascript(39, 1) = "["
        'set_variable_javascript(40, 0) = "array_db3"
        'set_variable_javascript(40, 1) = "["
        'set_variable_javascript(41, 0) = "array_pa3"
        'set_variable_javascript(41, 1) = "["
        'set_variable_javascript(42, 0) = "array_pb3"
        'set_variable_javascript(42, 1) = "["
        'set_variable_javascript(43, 0) = "array_ma3"
        'set_variable_javascript(43, 1) = "["

        'set_variable_javascript(44, 0) = "array_da4"
        'set_variable_javascript(44, 1) = "["
        'set_variable_javascript(45, 0) = "array_db4"
        'set_variable_javascript(45, 1) = "["
        'set_variable_javascript(46, 0) = "array_pa4"
        'set_variable_javascript(46, 1) = "["
        'set_variable_javascript(47, 0) = "array_pb4"
        'set_variable_javascript(47, 1) = "["
        'set_variable_javascript(48, 0) = "array_ma4"
        'set_variable_javascript(48, 1) = "["

        'set_variable_javascript(49, 0) = "array_da5"
        'set_variable_javascript(49, 1) = "["
        'set_variable_javascript(50, 0) = "array_db5"
        'set_variable_javascript(50, 1) = "["
        'set_variable_javascript(51, 0) = "array_pa5"
        'set_variable_javascript(51, 1) = "["
        'set_variable_javascript(52, 0) = "array_pb5"
        'set_variable_javascript(52, 1) = "["
        'set_variable_javascript(53, 0) = "array_ma5"
        'set_variable_javascript(53, 1) = "["

        'lunghezza_tabella = table_log.Count
        'If lunghezza_tabella > 600 Then
        '    lunghezza_tabella = 600
        'End If

        'Dim specifier As String

        'literal_script.Text = "<script>"

        'Dim k As Integer
        ''For Each dc_log In table_log
        'For k = lunghezza_tabella - 1 To 0 Step -1
        '    Dim dc_log As ermes_web_20.quey_db.logRow
        '    dc_log = table_log.Item(k)

        '    If prima_volta Then
        '        data_prima = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")
        '    End If
        '    prima_volta = False
        '    data_seconda = Format(dc_log.data.Day, "00") + "/" + Format(dc_log.data.Month, "00") + "/" + Format(dc_log.data.Year Mod 100, "00")

        '    'If dc_log.valore1 > full1 Or (valore1_prec > 0 And dc_log.valore1 > valore1_prec * 10) Then
        '    '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(valore1_prec.ToString(), ",", ".") + "]"
        '    'Else
        '    set_variable_javascript(0, 1) = set_variable_javascript(0, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore1.ToString(), ",", ".") + "]"
        '    valore1_prec = dc_log.valore1
        '    'End If
        '    'If dc_log.valore2 > full2 Or (valore2_prec > 0 And dc_log.valore2 > valore2_prec * 10) Then
        '    'set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(valore2_prec.ToString(), ",", ".") + "]"
        '    'Else
        '    set_variable_javascript(1, 1) = set_variable_javascript(1, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore2.ToString(), ",", ".") + "]"
        '    valore2_prec = dc_log.valore2
        '    'End If

        '    'If dc_log.valore3 > full3 Or (valore3_prec > 0 And dc_log.valore3 > valore3_prec * 10) Then
        '    'set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(valore3_prec.ToString(), ",", ".") + "]"
        '    'Else
        '    set_variable_javascript(2, 1) = set_variable_javascript(2, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore3.ToString(), ",", ".") + "]"
        '    valore3_prec = dc_log.valore3
        '    ' End If

        '    'If dc_log.valore4 > full4 Or (valore4_prec > 0 And dc_log.valore4 > valore4_prec * 10) Then
        '    'set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(valore4_prec.ToString(), ",", ".") + "]"
        '    'Else
        '    set_variable_javascript(3, 1) = set_variable_javascript(3, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore4.ToString(), ",", ".") + "]"
        '    valore4_prec = dc_log.valore4
        '    'End If

        '    'If dc_log.valore5 > full5 Or (valore5_prec > 0 And dc_log.valore5 > valore5_prec * 10) Then
        '    'set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(valore5_prec.ToString(), ",", ".") + "]"
        '    'Else
        '    set_variable_javascript(4, 1) = set_variable_javascript(4, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.valore5.ToString(), ",", ".") + "]"
        '    valore5_prec = dc_log.valore5
        '    'End If

        '    If ch1_aa_enable.Visible Then
        '        set_variable_javascript(5, 1) = set_variable_javascript(5, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Aa1.ToString + "]"
        '    End If
        '    If ch2_aa_enable.Visible Then
        '        set_variable_javascript(6, 1) = set_variable_javascript(6, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Aa2.ToString + "]"
        '    End If
        '    If ch3_aa_enable.Visible Then
        '        set_variable_javascript(7, 1) = set_variable_javascript(7, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Aa3.ToString + "]"
        '    End If
        '    If ch4_aa_enable.Visible Then
        '        set_variable_javascript(8, 1) = set_variable_javascript(8, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Aa4.ToString + "]"
        '    End If
        '    If ch5_aa_enable.Visible Then
        '        set_variable_javascript(9, 1) = set_variable_javascript(9, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Aa5.ToString + "]"
        '    End If

        '    If ch1_ab_enable.Visible Then
        '        set_variable_javascript(10, 1) = set_variable_javascript(10, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ab1.ToString + "]"
        '    End If
        '    If ch2_ab_enable.Visible Then
        '        set_variable_javascript(11, 1) = set_variable_javascript(11, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ab2.ToString + "]"
        '    End If
        '    If ch3_ab_enable.Visible Then
        '        set_variable_javascript(12, 1) = set_variable_javascript(12, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ab3.ToString + "]"
        '    End If
        '    If ch4_ab_enable.Visible Then
        '        set_variable_javascript(13, 1) = set_variable_javascript(13, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ab4.ToString + "]"
        '    End If
        '    If ch5_ab_enable.Visible Then
        '        set_variable_javascript(14, 1) = set_variable_javascript(14, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ab5.ToString + "]"
        '    End If

        '    If ch1_ad_enable.Visible Then
        '        set_variable_javascript(15, 1) = set_variable_javascript(15, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ad1.ToString + "]"
        '    End If
        '    If ch2_ad_enable.Visible Then
        '        set_variable_javascript(16, 1) = set_variable_javascript(16, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ad2.ToString + "]"
        '    End If
        '    If ch3_ad_enable.Visible Then
        '        set_variable_javascript(17, 1) = set_variable_javascript(17, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ad3.ToString + "]"
        '    End If
        '    If ch4_ad_enable.Visible Then
        '        set_variable_javascript(18, 1) = set_variable_javascript(18, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ad4.ToString + "]"
        '    End If
        '    If ch5_ad_enable.Visible Then
        '        set_variable_javascript(19, 1) = set_variable_javascript(19, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ad5.ToString + "]"
        '    End If

        '    If ch1_ar_enable.Visible Then
        '        set_variable_javascript(20, 1) = set_variable_javascript(20, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ar1.ToString + "]"
        '    End If
        '    If ch2_ar_enable.Visible Then
        '        set_variable_javascript(21, 1) = set_variable_javascript(21, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ar2.ToString + "]"
        '    End If
        '    If ch3_ar_enable.Visible Then
        '        set_variable_javascript(22, 1) = set_variable_javascript(22, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ar3.ToString + "]"
        '    End If
        '    If ch4_ar_enable.Visible Then
        '        set_variable_javascript(23, 1) = set_variable_javascript(23, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ar4.ToString + "]"
        '    End If
        '    If ch5_ar_enable.Visible Then
        '        set_variable_javascript(24, 1) = set_variable_javascript(24, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.Ar5.ToString + "]"
        '    End If

        '    If InStr(dc_log.Flow.ToString, "1") <> 0 Then
        '        set_variable_javascript(25, 1) = set_variable_javascript(25, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + "),0]"
        '    Else
        '        set_variable_javascript(25, 1) = set_variable_javascript(25, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + "),1]"
        '    End If



        '    set_variable_javascript(26, 1) = set_variable_javascript(26, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.temperatura.ToString(), ",", ".") + "]"

        '    set_variable_javascript(27, 1) = set_variable_javascript(27, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + dc_log.fml.ToString + "]"
        '    set_variable_javascript(28, 1) = set_variable_javascript(28, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace(dc_log.wm.ToString(), ",", ".") + "]"

        '    If ch1_da_enable.Visible Then
        '        set_variable_javascript(29, 1) = set_variable_javascript(29, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.da1) + "]"
        '    End If
        '    If ch1_db_enable.Visible Then
        '        set_variable_javascript(30, 1) = set_variable_javascript(30, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.db1) + "]"
        '    End If
        '    If ch1_pa_enable.Visible Then
        '        set_variable_javascript(31, 1) = set_variable_javascript(31, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pa1.ToString()) + "]"
        '    End If
        '    If ch1_pb_enable.Visible Then
        '        set_variable_javascript(32, 1) = set_variable_javascript(32, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pb1.ToString()) + "]"
        '    End If
        '    If ch1_ma_enable.Visible Then
        '        set_variable_javascript(33, 1) = set_variable_javascript(33, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace((dc_log.ma1 / 10).ToString(), ",", ".") + "]"
        '    End If


        '    If ch2_da_enable.Visible Then
        '        set_variable_javascript(34, 1) = set_variable_javascript(34, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.da2) + "]"
        '    End If
        '    If ch2_db_enable.Visible Then
        '        set_variable_javascript(35, 1) = set_variable_javascript(35, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.db2) + "]"
        '    End If
        '    If ch2_pa_enable.Visible Then
        '        set_variable_javascript(36, 1) = set_variable_javascript(36, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pa2.ToString()) + "]"
        '    End If
        '    If ch2_pb_enable.Visible Then
        '        set_variable_javascript(37, 1) = set_variable_javascript(37, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pb2.ToString()) + "]"
        '    End If
        '    If ch2_ma_enable.Visible Then
        '        set_variable_javascript(38, 1) = set_variable_javascript(38, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace((dc_log.ma2 / 10).ToString(), ",", ".") + "]"
        '    End If

        '    If ch3_da_enable.Visible Then
        '        set_variable_javascript(39, 1) = set_variable_javascript(39, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.da3) + "]"
        '    End If
        '    If ch3_db_enable.Visible Then
        '        set_variable_javascript(40, 1) = set_variable_javascript(40, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.db3) + "]"
        '    End If
        '    If ch3_pa_enable.Visible Then
        '        set_variable_javascript(41, 1) = set_variable_javascript(41, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pa3.ToString()) + "]"
        '    End If
        '    If ch3_pb_enable.Visible Then
        '        set_variable_javascript(42, 1) = set_variable_javascript(42, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pb3.ToString()) + "]"
        '    End If
        '    If ch3_ma_enable.Visible Then
        '        set_variable_javascript(43, 1) = set_variable_javascript(43, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace((dc_log.ma3 / 10).ToString(), ",", ".") + "]"
        '    End If

        '    If ch4_da_enable.Visible Then
        '        set_variable_javascript(44, 1) = set_variable_javascript(44, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.da4) + "]"
        '    End If
        '    If ch4_db_enable.Visible Then
        '        set_variable_javascript(45, 1) = set_variable_javascript(45, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.db4) + "]"
        '    End If
        '    If ch4_pa_enable.Visible Then
        '        set_variable_javascript(46, 1) = set_variable_javascript(46, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pa4.ToString()) + "]"
        '    End If
        '    If ch4_pb_enable.Visible Then
        '        set_variable_javascript(47, 1) = set_variable_javascript(47, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pb4.ToString()) + "]"
        '    End If
        '    If ch4_ma_enable.Visible Then
        '        set_variable_javascript(48, 1) = set_variable_javascript(48, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace((dc_log.ma4 / 10).ToString(), ",", ".") + "]"
        '    End If

        '    If ch5_da_enable.Visible Then
        '        set_variable_javascript(49, 1) = set_variable_javascript(49, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.da5) + "]"
        '    End If
        '    If ch5_db_enable.Visible Then
        '        set_variable_javascript(50, 1) = set_variable_javascript(50, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + get_status_boolean(dc_log.db5) + "]"
        '    End If
        '    If ch5_pa_enable.Visible Then
        '        set_variable_javascript(51, 1) = set_variable_javascript(51, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pa5.ToString()) + "]"
        '    End If
        '    If ch5_pb_enable.Visible Then
        '        set_variable_javascript(52, 1) = set_variable_javascript(52, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + (dc_log.pb5.ToString()) + "]"
        '    End If
        '    If ch5_ma_enable.Visible Then
        '        set_variable_javascript(53, 1) = set_variable_javascript(53, 1) + "[Date.UTC(" + dc_log.data.Year.ToString + "," + (dc_log.data.Month - 1).ToString + "," + dc_log.data.Day.ToString + "," + dc_log.data.Hour.ToString + "," + dc_log.data.Minute.ToString + ")," + Replace((dc_log.ma5 / 10).ToString(), ",", ".") + "]"
        '    End If

        '    index = index + 1
        '    If index < lunghezza_tabella Then
        '        Dim j As Integer
        '        For j = 0 To 53
        '            set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "," + vbCrLf
        '        Next
        '    End If

        '    'Thread.Sleep(10)

        'Next
        'If index >= lunghezza_tabella Then
        '    Dim j As Integer
        '    For j = 0 To 53
        '        set_variable_javascript(j, 1) = set_variable_javascript(j, 1) + "]" + vbCrLf
        '    Next
        'End If
        Dim data_prima_date As Date
        Dim data_seconda_date As Date
        If data_prima <> "" And data_seconda <> "" Then
            data_prima_date = Date.ParseExact(data_prima, "dd/MM/yy", CultureInfo.InvariantCulture)
            data_seconda_date = Date.ParseExact(data_seconda, "dd/MM/yy", CultureInfo.InvariantCulture)
            data_prima = Format(data_prima_date.Day, "00") + "/" + Format(data_prima_date.Month, "00") + "/" + Format(data_prima_date.Year, "00")
            data_seconda = Format(data_seconda_date.Day, "00") + "/" + Format(data_seconda_date.Month, "00") + "/" + Format(data_seconda_date.Year, "00")
        Else
            data_prima_date = Date.Parse(data_from)
            data_seconda_date = Date.Parse(data_to)
            data_prima = Format(data_prima_date.Day, "00") + "/" + Format(data_prima_date.Month, "00") + "/" + Format(data_prima_date.Year, "00")
            data_seconda = Format(data_seconda_date.Day, "00") + "/" + Format(data_seconda_date.Month, "00") + "/" + Format(data_seconda_date.Year, "00")
        End If
        Select Case Mid(option_value(0), 9, 1)
            Case "0" 'gg-mm-aa
                literal_script.Text = literal_script.Text + "var date_format='0';"
            Case "1" 'mm-gg-aa
                literal_script.Text = literal_script.Text + "var date_format='1';"
            Case "2" 'aa-mm-gg
                literal_script.Text = literal_script.Text + "var date_format='2';"
        End Select
        If Mid(option_value(0), 10, 1) = "0" Then 'formato 12
            literal_script.Text = literal_script.Text + "var time_format='0';"
        Else
            literal_script.Text = literal_script.Text + "var time_format='1';"
        End If
        literal_script.Text = literal_script.Text + "var init_date='" + data_prima + "';"
        literal_script.Text = literal_script.Text + "var last_date='" + data_seconda + "';"
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var graph_log='" + GetGlobalResourceObject("javascript_global", "graph_log") + " " + nome_impianto + "';"

        literal_script.Text = literal_script.Text + "var ch1_aa_label='" + ch1_aa_label.Text + "';" + "var ch2_aa_label='" + ch2_aa_label.Text + "';" + "var ch3_aa_label='" + ch3_aa_label.Text + "';" + "var ch4_aa_label='" + ch4_aa_label.Text + "';" + "var ch5_aa_label='" + ch5_aa_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_ab_label='" + ch1_ab_label.Text + "';" + "var ch2_ab_label='" + ch2_ab_label.Text + "';" + "var ch3_ab_label='" + ch3_ab_label.Text + "';" + "var ch4_ab_label='" + ch4_ab_label.Text + "';" + "var ch5_ab_label='" + ch5_ab_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_ab_label='" + ch1_ad_label.Text + "';" + "var ch2_ad_label='" + ch2_ad_label.Text + "';" + "var ch3_ad_label='" + ch3_ad_label.Text + "';" + "var ch4_ad_label='" + ch4_ad_label.Text + "';" + "var ch5_ad_label='" + ch5_ad_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_ab_label='" + ch1_ar_label.Text + "';" + "var ch2_ar_label='" + ch2_ar_label.Text + "';" + "var ch3_ar_label='" + ch3_ar_label.Text + "';" + "var ch4_ar_label='" + ch4_ar_label.Text + "';" + "var ch5_ar_label='" + ch5_ar_label.Text + "';"

        literal_script.Text = literal_script.Text + "var ch1_da_label='" + ch1_da_label.Text + "';" + "var ch2_da_label='" + ch2_da_label.Text + "';" + "var ch3_da_label='" + ch3_da_label.Text + "';" + "var ch4_da_label='" + ch4_da_label.Text + "';" + "var ch5_da_label='" + ch5_da_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_db_label='" + ch1_db_label.Text + "';" + "var ch2_db_label='" + ch2_db_label.Text + "';" + "var ch3_db_label='" + ch3_db_label.Text + "';" + "var ch4_db_label='" + ch4_db_label.Text + "';" + "var ch5_db_label='" + ch5_db_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_pa_label='" + ch1_pa_label.Text + "';" + "var ch2_pa_label='" + ch2_pa_label.Text + "';" + "var ch3_pa_label='" + ch3_pa_label.Text + "';" + "var ch4_pa_label='" + ch4_pa_label.Text + "';" + "var ch5_pa_label='" + ch5_pa_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_pb_label='" + ch1_pb_label.Text + "';" + "var ch2_pb_label='" + ch2_pb_label.Text + "';" + "var ch3_pb_label='" + ch3_pb_label.Text + "';" + "var ch4_pb_label='" + ch4_pb_label.Text + "';" + "var ch5_pb_label='" + ch5_pb_label.Text + "';"
        literal_script.Text = literal_script.Text + "var ch1_ma_label='" + ch1_ma_label.Text + "';" + "var ch2_ma_label='" + ch2_ma_label.Text + "';" + "var ch3_ma_label='" + ch3_ma_label.Text + "';" + "var ch4_ma_label='" + ch4_ma_label.Text + "';" + "var ch5_ma_label='" + ch5_ma_label.Text + "';"

        literal_script.Text = literal_script.Text + "var temperature_label='" + temperature_select_label.Text + "';"
        literal_script.Text = literal_script.Text + "var temperature_label2='" + temperature_select_label2.Text + "';"
        literal_script.Text = literal_script.Text + "var flow_meter_label='" + flow_meter_label.Text + "';"
        literal_script.Text = literal_script.Text + "var label_flow_select='" + label_flow_select.Text + "';"
        literal_script.Text = literal_script.Text + "var label_flow_select2='" + label_flow_select2.Text + "';"
        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_log" + "';"

        literal_script.Text = literal_script.Text + "</script>"
        Dim stringa1 As String = data_from.ToString
        Dim stringa2 As String = data_to.ToString

        '
        function_javascript = function_javascript + "get_data('" + codice_impianto + "'," + id_485_impianto + "," + temporaneo_id + ",'" + data_prima + "','" + data_seconda + "');"

        function_javascript = function_javascript + "manage_div();"
        'function_javascript = function_javascript + "upgrate_chart();"
        function_javascript = function_javascript + "create_picker();"
        'java_script_variable.set_url_setpoint(Page, set_variable_javascript, 59)
        java_script_function.call_function_javascript_onload(Page, function_javascript)

        '  trd1.Abort()

    End Sub

    Public Function get_status_boolean(ByVal valore_bool As Boolean) As String
        If valore_bool Then
            Return "1"
        Else
            Return "0"
        End If
    End Function


    Protected Sub refresh_log_server_Click(sender As Object, e As EventArgs) Handles refresh_log_server.Click
        Dim init_date As String
        Dim last_date As String
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=16" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class