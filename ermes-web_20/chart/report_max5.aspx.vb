Imports System.Globalization
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class report
    Inherits lingua
    Private Shared nome_impianto As String = ""
    Private Shared codice_impianto As String = ""
    Private Shared id_485_impianto As String = ""
    Private Shared statistica As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim init_date As String = ""
        Dim last_date As String = ""
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
                If Request.Cookies(codice_impianto + "_" + id_485_impianto + "_report") Is Nothing Then
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_report").Expires = DateTime.Now.AddMonths(12)  ' il cookie dura 1 anno
                    Response.Cookies(codice_impianto + "_" + id_485_impianto + "_report").Value = set_coockie()

                Else
                    get_coockie(Request.Cookies(codice_impianto + "_" + id_485_impianto + "_report").Value)
                End If
            Catch ex As Exception

            End Try
            posiziona_report(nome_impianto, codice_impianto, id_485_impianto, init_date, last_date)

        End If

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
        ch3_val.Checked = Convert.ToBoolean(split_input(21))
        ch3_da.Checked = Convert.ToBoolean(split_input(22))
        ch3_db.Checked = Convert.ToBoolean(split_input(23))
        ch3_pa.Checked = Convert.ToBoolean(split_input(24))
        ch3_pb.Checked = Convert.ToBoolean(split_input(25))
        ch3_ma.Checked = Convert.ToBoolean(split_input(26))
        ch3_aa.Checked = Convert.ToBoolean(split_input(27))
        ch3_ab.Checked = Convert.ToBoolean(split_input(28))
        ch3_ad.Checked = Convert.ToBoolean(split_input(29))
        ch3_ar.Checked = Convert.ToBoolean(split_input(30))

        ch4_val.Checked = Convert.ToBoolean(split_input(31))
        ch4_val.Checked = Convert.ToBoolean(split_input(32))
        ch4_da.Checked = Convert.ToBoolean(split_input(33))
        ch4_db.Checked = Convert.ToBoolean(split_input(34))
        ch4_pa.Checked = Convert.ToBoolean(split_input(35))
        ch4_pb.Checked = Convert.ToBoolean(split_input(36))
        ch4_ma.Checked = Convert.ToBoolean(split_input(37))
        ch4_aa.Checked = Convert.ToBoolean(split_input(38))
        ch4_ab.Checked = Convert.ToBoolean(split_input(39))
        ch4_ad.Checked = Convert.ToBoolean(split_input(40))
        ch4_ar.Checked = Convert.ToBoolean(split_input(41))

        ch5_val.Checked = Convert.ToBoolean(split_input(42))
        ch5_val.Checked = Convert.ToBoolean(split_input(43))
        ch5_da.Checked = Convert.ToBoolean(split_input(44))
        ch5_db.Checked = Convert.ToBoolean(split_input(45))
        ch5_pa.Checked = Convert.ToBoolean(split_input(46))
        ch5_pb.Checked = Convert.ToBoolean(split_input(47))
        ch5_ma.Checked = Convert.ToBoolean(split_input(48))
        ch5_aa.Checked = Convert.ToBoolean(split_input(49))
        ch5_ab.Checked = Convert.ToBoolean(split_input(50))
        ch5_ad.Checked = Convert.ToBoolean(split_input(51))
        ch5_ar.Checked = Convert.ToBoolean(split_input(52))

        temperature_select.Checked = Convert.ToBoolean(split_input(53))
        flow_meter_low.Checked = Convert.ToBoolean(split_input(54))
        flow_meter.Checked = Convert.ToBoolean(split_input(55))
        flow_select.Checked = Convert.ToBoolean(split_input(56))

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
    Public Sub posiziona_report(ByVal nome_impianto As String, codice_impianto As String, id_485_impianto As String, ByVal init_date As String, ByVal last_date As String)
        Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim table_log As ermes_web_20.quey_db.logDataTable
        Dim label_canale_temp As String = ""
        Dim config_value() As String
        Dim option_value() As String

        Dim java_script_function As java_script = New java_script
        Dim function_javascript As String = ""
        Dim query As New query
        Dim prima_volta As Boolean = True
        Dim data_prima As String = ""
        Dim data_seconda As String = ""


        Dim fattore_divisione_temp As Integer
        Dim fattore_divisione_combinato As Integer = 1
        'Dim set_variable_javascript(32, 1) As String
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

        Dim number_version As Integer = 0


        Dim data_to As Date
        Dim data_from As Date

        If init_date Is Nothing Or last_date Is Nothing Then
            data_to = Now

            data_from = data_to.AddDays(-15)
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
        For i = 1 To 5
            'If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "yagel" And i = 5 Then ' personalizzazione yagel
            '    label_canale_temp = main_function_config.get_tipo_strumento_max5("phY", option_value(0), fattore_divisione_temp)
            'Else
            label_canale_temp = main_function_config.get_tipo_strumento_max5(config_value(i - 1), option_value(0), fattore_divisione_temp, , , , fattore_divisione_combinato)
            'End If

            If label_canale_temp <> "" Then
                Select Case i
                    Case 1
                        ch1_enable.Visible = True
                        'set_variable_javascript(i, 0) = "label_ch1"
                        'set_variable_javascript(i, 1) = """" + label_canale_temp + """"
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

                            ch1_da_enable.Visible = main_function.enable_da(data_sp1(0))
                            ch1_db_enable.Visible = main_function.enable_db(data_sp1(0))
                            ch1_pa_enable.Visible = main_function.enable_pa(data_sp1(0))
                            ch1_pb_enable.Visible = main_function.enable_pb(data_sp1(0))
                            ch1_ma_enable.Visible = main_function.enable_ma(data_sp1(0))
                            ch1_aa_enable.Visible = main_function.enable_aa(data_sp1(0))
                            ch1_ab_enable.Visible = main_function.enable_ab(data_sp1(0))
                            ch1_ad_enable.Visible = main_function.enable_ad(data_sp1(0))
                            ch1_ar_enable.Visible = main_function.enable_ar(data_sp1(0))

                        End If
                    Case 2
                        ch2_enable.Visible = True
                        'set_variable_javascript(i, 0) = "label_ch2"
                        'set_variable_javascript(i, 1) = """" + label_canale_temp + """"
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
                            ch2_da_enable.Visible = main_function.enable_da(data_sp2(0))
                            ch2_db_enable.Visible = main_function.enable_db(data_sp2(0))
                            ch2_pa_enable.Visible = main_function.enable_pa(data_sp2(0))
                            ch2_pb_enable.Visible = main_function.enable_pb(data_sp2(0))
                            ch2_ma_enable.Visible = main_function.enable_ma(data_sp2(0))
                            ch2_aa_enable.Visible = main_function.enable_aa(data_sp2(0))
                            ch2_ab_enable.Visible = main_function.enable_ab(data_sp2(0))
                            ch2_ad_enable.Visible = main_function.enable_ad(data_sp2(0))
                            ch2_ar_enable.Visible = main_function.enable_ar(data_sp2(0))

                        End If
                    Case 3
                        ch3_enable.Visible = True
                        'set_variable_javascript(i, 0) = "label_ch3"
                        'set_variable_javascript(i, 1) = """" + label_canale_temp + """"
                        ch3_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp3(0) = name_sp3(0).Replace("ph", "")
                            For j = 0 To name_sp3.Length - 1
                                name_sp3(j) = name_sp3(j).Replace("-", "")
                            Next
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
                            ch3_da_enable.Visible = main_function.enable_da(data_sp3(0))
                            ch3_db_enable.Visible = main_function.enable_db(data_sp3(0))
                            ch3_pa_enable.Visible = main_function.enable_pa(data_sp3(0))
                            ch3_pb_enable.Visible = main_function.enable_pb(data_sp3(0))
                            ch3_ma_enable.Visible = main_function.enable_ma(data_sp3(0))
                            ch3_aa_enable.Visible = main_function.enable_aa(data_sp3(0))
                            ch3_ab_enable.Visible = main_function.enable_ab(data_sp3(0))
                            ch3_ad_enable.Visible = main_function.enable_ad(data_sp3(0))
                            ch3_ar_enable.Visible = main_function.enable_ar(data_sp3(0))

                        End If
                    Case 4
                        ch4_enable.Visible = True
                        'set_variable_javascript(i, 0) = "label_ch4"
                        'set_variable_javascript(i, 1) = """" + label_canale_temp + """"
                        ch4_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp4(0) = name_sp4(0).Replace("ph", "")
                            For j = 0 To name_sp4.Length - 1
                                name_sp4(j) = name_sp4(j).Replace("-", "")
                            Next
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
                            ch4_da_enable.Visible = main_function.enable_da(data_sp4(0))
                            ch4_db_enable.Visible = main_function.enable_db(data_sp4(0))
                            ch4_pa_enable.Visible = main_function.enable_pa(data_sp4(0))
                            ch4_pb_enable.Visible = main_function.enable_pb(data_sp4(0))
                            ch4_ma_enable.Visible = main_function.enable_ma(data_sp4(0))
                            ch4_aa_enable.Visible = main_function.enable_aa(data_sp4(0))
                            ch4_ab_enable.Visible = main_function.enable_ab(data_sp4(0))
                            ch4_ad_enable.Visible = main_function.enable_ad(data_sp4(0))
                            ch4_ar_enable.Visible = main_function.enable_ar(data_sp4(0))
                        End If

                    Case 5
                        ch5_enable.Visible = True
                        'set_variable_javascript(i, 0) = "label_ch5"
                        'set_variable_javascript(i, 1) = """" + label_canale_temp + """"
                        ch5_val_label.Text = label_canale_temp
                        If number_version > 29 Then
                            name_sp5(0) = name_sp2(0).Replace("ph", "")
                            For j = 0 To name_sp5.Length - 1
                                name_sp5(j) = name_sp5(j).Replace("-", "")
                            Next
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
                            ch5_da_enable.Visible = main_function.enable_da(data_sp5(0))
                            ch5_db_enable.Visible = main_function.enable_db(data_sp5(0))
                            ch5_pa_enable.Visible = main_function.enable_pa(data_sp5(0))
                            ch5_pb_enable.Visible = main_function.enable_pb(data_sp5(0))
                            ch5_ma_enable.Visible = main_function.enable_ma(data_sp5(0))
                            ch5_aa_enable.Visible = main_function.enable_aa(data_sp5(0))
                            ch5_ab_enable.Visible = main_function.enable_ab(data_sp5(0))
                            ch5_ad_enable.Visible = main_function.enable_ad(data_sp5(0))
                            ch5_ar_enable.Visible = main_function.enable_ar(data_sp5(0))
                        End If
                End Select
            Else

            End If
        Next
        If main_function.get_tipo_personalizzazione(riga_strumento.nome) = "yagel" Then
            flow_meter_low_enable.Visible = True

        Else
            flow_meter_low_enable.Visible = False
        End If

        Dim temporaneo_id As String = ""
        temporaneo_id = Str(Val(id_485_impianto))
        temporaneo_id = temporaneo_id.Replace(" ", "")

        table_log = query.get_log_max5(codice_impianto, id_485_impianto, temporaneo_id, data_from, data_to)
        report_head.Text = "<thead>"
        report_head.Text = report_head.Text + "<tr class=""gradeA""> "
        report_head.Text = report_head.Text + "<th>Data</th>"
        report_head.Text = report_head.Text + "<th class=""" + ch1_val.ID + """>" + ch1_val_label.Text + "</th>"



        If ch1_da_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_da.ID + """>" + ch1_da_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_db_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_db.ID + """>" + ch1_db_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_pa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_pa.ID + """>" + ch1_pa_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_pb_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_pb.ID + """>" + ch1_pb_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_ma_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_ma.ID + """>" + ch1_ma_label.Text + ch1_val_label.Text + "</th>"
        End If


        If ch1_aa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_aa.ID + """>" + ch1_aa_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_ab_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_ab.ID + """>" + ch1_ab_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_ad_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_ad.ID + """>" + ch1_ad_label.Text + ch1_val_label.Text + "</th>"
        End If
        If ch1_ar_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch1_ar.ID + """>" + ch1_ar_label.Text + ch1_val_label.Text + "</th>"
        End If

        report_head.Text = report_head.Text + "<th class=""" + ch2_val.ID + """>" + ch2_val_label.Text + "</th>"
        If ch2_da_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_da.ID + """>" + ch2_da_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_db_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_db.ID + """>" + ch2_db_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_pa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_pa.ID + """>" + ch2_pa_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_pb_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_pb.ID + """>" + ch2_pb_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_ma_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_ma.ID + """>" + ch2_ma_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_aa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_aa.ID + """>" + ch2_aa_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_ab_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_ab.ID + """>" + ch2_ab_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_ad_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_ad.ID + """>" + ch2_ad_label.Text + ch2_val_label.Text + "</th>"
        End If
        If ch2_ar_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch2_ar.ID + """>" + ch2_ar_label.Text + ch2_val_label.Text + "</th>"
        End If

        report_head.Text = report_head.Text + "<th class=""" + ch3_val.ID + """>" + ch3_val_label.Text + "</th>"
        If ch3_da_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_da.ID + """>" + ch3_da_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_db_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_db.ID + """>" + ch3_db_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_pa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_pa.ID + """>" + ch3_pa_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_pb_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_pb.ID + """>" + ch3_pb_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_ma_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_ma.ID + """>" + ch3_ma_label.Text + ch3_val_label.Text + "</th>"
        End If

        If ch3_aa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_aa.ID + """>" + ch3_aa_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_ab_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_ab.ID + """>" + ch3_ab_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_ad_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_ad.ID + """>" + ch3_ad_label.Text + ch3_val_label.Text + "</th>"
        End If
        If ch3_ar_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch3_ar.ID + """>" + ch3_ar_label.Text + ch3_val_label.Text + "</th>"
        End If

        report_head.Text = report_head.Text + "<th class=""" + ch4_val.ID + """>" + ch4_val_label.Text + "</th>"
        If ch4_da_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_da.ID + """>" + ch4_da_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_db_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_db.ID + """>" + ch4_db_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_pa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_pa.ID + """>" + ch4_pa_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_pb_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_pb.ID + """>" + ch4_pb_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_ma_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_ma.ID + """>" + ch4_ma_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_aa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_aa.ID + """>" + ch4_aa_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_ab_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_ab.ID + """>" + ch4_ab_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_ad_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_ad.ID + """>" + ch4_ad_label.Text + ch4_val_label.Text + "</th>"
        End If
        If ch4_ar_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch4_ar.ID + """>" + ch4_ar_label.Text + ch4_val_label.Text + "</th>"
        End If

        report_head.Text = report_head.Text + "<th class=""" + ch5_val.ID + """>" + ch5_val_label.Text + "</th>"
        If ch5_da_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_da.ID + """>" + ch5_da_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_db_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_db.ID + """>" + ch5_db_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_pa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_pa.ID + """>" + ch5_pa_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_pb_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_pb.ID + """>" + ch5_pb_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_ma_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_ma.ID + """>" + ch5_ma_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_aa_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_aa.ID + """>" + ch5_aa_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_ab_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_ab.ID + """>" + ch5_ab_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_ad_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_ad.ID + """>" + ch5_ad_label.Text + ch5_val_label.Text + "</th>"
        End If
        If ch5_ar_enable.Visible Then
            report_head.Text = report_head.Text + "<th class=""" + ch5_ar.ID + """>" + ch5_ar_label.Text + ch5_val_label.Text + "</th>"
        End If

        report_head.Text = report_head.Text + "<th class=""" + flow_select.ID + """>" + label_flow_select.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + temperature_select.ID + """>" + temperature_select_label.Text + "</th>"

        report_head.Text = report_head.Text + "<th class=""" + flow_meter_low.ID + """>" + flow_meter_low_label.Text + "</th>"
        report_head.Text = report_head.Text + "<th class=""" + flow_meter.ID + """>" + flow_meter_label.Text + "</th>"

        report_head.Text = report_head.Text + "</tr> "
        report_head.Text = report_head.Text + "</thead>"

        report_body.Text = "<tbody>"
        Dim data As Date
        Dim data_str As String = ""
        For Each dc In table_log

            Dim crea_body As String = ""

            If prima_volta Then
                data_prima = dc.data.ToString
            End If
            prima_volta = False
            data_seconda = dc.data.ToString

            crea_body = crea_body + "<tr class=""gradeX"">"
            crea_body = crea_body + "<td>"
            data = dc.data.ToString
            Select Case Mid(option_value(0), 9, 1)
                Case "0" 'gg-mm-aa
                    data_str = data.ToString("dd/MM/yy")
                Case "1" 'mm-gg-aa
                    data_str = data.ToString("MM/dd/yy")
                Case "2" 'aa-mm-gg
                    data_str = data.ToString("yy/MM/dd")
            End Select
            If Mid(option_value(0), 10, 1) = "0" Then 'formato 12

                data_str = data_str + " " + data.ToString("hh:mm tt", CultureInfo.InvariantCulture)

            Else
                data_str = data_str + " " + data.ToString("HH:mm", CultureInfo.InvariantCulture)
            End If
            crea_body = crea_body + data_str

            crea_body = crea_body + "<td class=""" + ch1_val.ID + """>" + dc.valore1.ToString + "</td>"

            If ch1_da_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_da.ID + """>" + get_status_boolean(dc.da1) + "</td>"
            End If
            If ch1_db_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_db.ID + """>" + get_status_boolean(dc.db1) + "</td>"
            End If
            If ch1_pa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_pa.ID + """>" + dc.pa1.ToString + "</td>"
            End If
            If ch1_pb_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_pb.ID + """>" + dc.pb1.ToString + "</td>"
            End If
            If ch1_ma_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_ma.ID + """>" + (dc.ma1 / 10).ToString + "</td>"
            End If

            If ch1_aa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_aa.ID + """>" + decode_on_off(dc.Aa1.ToString) + "</td>"
            End If
            If ch1_ab_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_ab.ID + """>" + decode_on_off(dc.Ab1.ToString) + "</td>"
            End If
            If ch1_ad_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_ad.ID + """>" + decode_on_off(dc.Ad1.ToString) + "</td>"
            End If
            If ch1_ar_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch1_ar.ID + """>" + decode_on_off(dc.Ar1.ToString) + "</td>"
            End If

            crea_body = crea_body + "<td class=""" + ch2_val.ID + """>" + dc.valore2.ToString + "</td>"
            If ch2_da_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_da.ID + """>" + get_status_boolean(dc.da2) + "</td>"
            End If
            If ch2_db_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_db.ID + """>" + get_status_boolean(dc.db2) + "</td>"
            End If
            If ch2_pa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_pa.ID + """>" + dc.pa2.ToString + "</td>"
            End If
            If ch2_pb_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_pb.ID + """>" + dc.pb2.ToString + "</td>"
            End If
            If ch2_ma_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_ma.ID + """>" + (dc.ma2 / 10).ToString + "</td>"
            End If
            If ch2_aa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_aa.ID + """>" + decode_on_off(dc.Aa2.ToString) + "</td>"
            End If
            If ch2_ab_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_ab.ID + """>" + decode_on_off(dc.Ab2.ToString) + "</td>"
            End If
            If ch2_ad_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_ad.ID + """>" + decode_on_off(dc.Ad2.ToString) + "</td>"
            End If
            If ch2_ar_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch2_ar.ID + """>" + decode_on_off(dc.Ar2.ToString) + "</td>"
            End If

            crea_body = crea_body + "<td class=""" + ch3_val.ID + """>" + dc.valore3.ToString + "</td>"
            If ch3_da_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_da.ID + """>" + get_status_boolean(dc.da3) + "</td>"
            End If
            If ch3_db_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_db.ID + """>" + get_status_boolean(dc.db3) + "</td>"
            End If
            If ch3_pa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_pa.ID + """>" + dc.pa3.ToString + "</td>"
            End If
            If ch3_pb_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_pb.ID + """>" + dc.pb3.ToString + "</td>"
            End If
            If ch3_ma_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_ma.ID + """>" + (dc.ma3 / 10).ToString + "</td>"
            End If
            If ch3_aa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_aa.ID + """>" + decode_on_off(dc.Aa3.ToString) + "</td>"
            End If
            If ch3_ab_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_ab.ID + """>" + decode_on_off(dc.Ab3.ToString) + "</td>"
            End If
            If ch3_ad_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_ad.ID + """>" + decode_on_off(dc.Ad3.ToString) + "</td>"
            End If
            If ch3_ar_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch3_ar.ID + """>" + decode_on_off(dc.Ar3.ToString) + "</td>"
            End If

            crea_body = crea_body + "<td class=""" + ch4_val.ID + """>" + dc.valore4.ToString + "</td>"
            If ch4_da_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_da.ID + """>" + get_status_boolean(dc.da4) + "</td>"
            End If
            If ch4_db_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_db.ID + """>" + get_status_boolean(dc.db4) + "</td>"
            End If
            If ch4_pa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_pa.ID + """>" + dc.pa4.ToString + "</td>"
            End If
            If ch4_pb_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_pb.ID + """>" + dc.pb4.ToString + "</td>"
            End If
            If ch4_ma_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_ma.ID + """>" + (dc.ma4 / 10).ToString + "</td>"
            End If
            If ch4_aa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_aa.ID + """>" + decode_on_off(dc.Aa4.ToString) + "</td>"
            End If
            If ch4_ab_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_ab.ID + """>" + decode_on_off(dc.Ab4.ToString) + "</td>"
            End If
            If ch4_ad_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_ad.ID + """>" + decode_on_off(dc.Ad4.ToString) + "</td>"
            End If
            If ch4_ar_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch4_ar.ID + """>" + decode_on_off(dc.Ar4.ToString) + "</td>"
            End If

            crea_body = crea_body + "<td class=""" + ch5_val.ID + """>" + dc.valore5.ToString + "</td>"
            If ch5_da_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_da.ID + """>" + get_status_boolean(dc.da5) + "</td>"
            End If
            If ch5_db_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_db.ID + """>" + get_status_boolean(dc.db5) + "</td>"
            End If
            If ch5_pa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_pa.ID + """>" + dc.pa5.ToString + "</td>"
            End If
            If ch5_pb_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_pb.ID + """>" + dc.pb5.ToString + "</td>"
            End If
            If ch5_ma_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_ma.ID + """>" + (dc.ma5 / 10).ToString + "</td>"
            End If
            If ch5_aa_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_aa.ID + """>" + decode_on_off(dc.Aa5.ToString) + "</td>"
            End If
            If ch5_ab_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_ab.ID + """>" + decode_on_off(dc.Ab5.ToString) + "</td>"
            End If
            If ch5_ad_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_ad.ID + """>" + decode_on_off(dc.Ad5.ToString) + "</td>"
            End If
            If ch5_ar_enable.Visible Then
                crea_body = crea_body + "<td class=""" + ch5_ar.ID + """>" + decode_on_off(dc.Ar5.ToString) + "</td>"
            End If

            crea_body = crea_body + "<td class=""" + flow_select.ID + """>" + decode_on_off_flow(dc.Flow.ToString) + "</td>"
            crea_body = crea_body + "<td class=""" + temperature_select.ID + """>" + dc.temperatura.ToString + "</td>"

            crea_body = crea_body + "<td class=""" + flow_meter_low.ID + """>" + decode_on_off(dc.fml.ToString) + "</td>"
            crea_body = crea_body + "<td class=""" + flow_meter.ID + """>" + dc.wm.ToString + "</td>"


            crea_body = crea_body + "</td>"
            crea_body = crea_body + "</tr>"
            If report_body.Text.Length < 50000 Then
                report_body.Text = report_body.Text + crea_body
            Else
                If report_body1.Text.Length < 50000 Then
                    report_body1.Text = report_body1.Text + crea_body
                Else
                    If report_body2.Text.Length < 50000 Then
                        report_body2.Text = report_body2.Text + crea_body
                    Else
                        If report_body3.Text.Length < 50000 Then
                            report_body3.Text = report_body3.Text + crea_body
                        Else
                            If report_body4.Text.Length < 50000 Then
                                report_body4.Text = report_body4.Text + crea_body
                            Else
                                If report_body5.Text.Length < 50000 Then
                                    report_body5.Text = report_body5.Text + crea_body
                                Else
                                    If report_body6.Text.Length < 50000 Then
                                        report_body6.Text = report_body6.Text + crea_body
                                    Else
                                        If report_body7.Text.Length < 50000 Then
                                            report_body7.Text = report_body7.Text + crea_body
                                        Else
                                            If report_body8.Text.Length < 50000 Then
                                                report_body8.Text = report_body8.Text + crea_body
                                            Else
                                                If report_body9.Text.Length < 50000 Then
                                                    report_body9.Text = report_body9.Text + crea_body
                                                Else
                                                    If report_body10.Text.Length < 50000 Then
                                                        report_body10.Text = report_body10.Text + crea_body
                                                    Else
                                                        If report_body11.Text.Length < 50000 Then
                                                            report_body11.Text = report_body11.Text + crea_body
                                                        Else
                                                            If report_body12.Text.Length < 50000 Then
                                                                report_body12.Text = report_body12.Text + crea_body
                                                            Else
                                                                If report_body13.Text.Length < 50000 Then
                                                                    report_body13.Text = report_body13.Text + crea_body
                                                                Else
                                                                    If report_body14.Text.Length < 50000 Then
                                                                        report_body14.Text = report_body14.Text + crea_body
                                                                    Else
                                                                        If report_body15.Text.Length < 50000 Then
                                                                            report_body15.Text = report_body15.Text + crea_body
                                                                        Else
                                                                            If report_body16.Text.Length < 50000 Then
                                                                                report_body16.Text = report_body16.Text + crea_body
                                                                            Else
                                                                                If report_body17.Text.Length < 50000 Then
                                                                                    report_body17.Text = report_body17.Text + crea_body
                                                                                Else
                                                                                    If report_body18.Text.Length < 50000 Then
                                                                                        report_body18.Text = report_body18.Text + crea_body
                                                                                    Else
                                                                                        If report_body19.Text.Length < 50000 Then
                                                                                            report_body19.Text = report_body19.Text + crea_body
                                                                                        Else
                                                                                            If report_body20.Text.Length < 50000 Then
                                                                                                report_body20.Text = report_body20.Text + crea_body
                                                                                            Else
                                                                                                If report_body21.Text.Length < 50000 Then
                                                                                                    report_body21.Text = report_body21.Text + crea_body
                                                                                                Else
                                                                                                    If report_body22.Text.Length < 50000 Then
                                                                                                        report_body22.Text = report_body22.Text + crea_body
                                                                                                    Else
                                                                                                        If report_body23.Text.Length < 50000 Then
                                                                                                            report_body23.Text = report_body23.Text + crea_body
                                                                                                        Else
                                                                                                            If report_body24.Text.Length < 50000 Then
                                                                                                                report_body24.Text = report_body24.Text + crea_body
                                                                                                            Else
                                                                                                                If report_body25.Text.Length < 50000 Then
                                                                                                                    report_body25.Text = report_body25.Text + crea_body
                                                                                                                Else
                                                                                                                    report_body25.Text = report_body25.Text + crea_body
                                                                                                                End If

                                                                                                            End If

                                                                                                        End If

                                                                                                    End If

                                                                                                End If

                                                                                            End If

                                                                                        End If

                                                                                    End If

                                                                                End If

                                                                            End If

                                                                        End If

                                                                    End If

                                                                End If

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Next
        'report_body.Text = report_body.Text + "<tbody>"
        report_body25.Text = report_body25.Text + "<tbody>"

        Dim data_prima_date As Date
        Dim data_seconda_date As Date
        If data_prima <> "" And data_seconda <> "" Then
            data_prima_date = Date.Parse(data_prima)
            data_seconda_date = Date.Parse(data_seconda)
            data_prima = data_prima_date.ToString("dd/MM/yy")
            data_seconda = data_seconda_date.ToString("dd/MM/yy")
        End If

        literal_script.Text = "<script>"
        literal_script.Text = literal_script.Text + "var init_date='" + data_prima + "';"
        literal_script.Text = literal_script.Text + "var last_date='" + data_seconda + "';"
        literal_script.Text = literal_script.Text + "var intervallo_log='" + GetGlobalResourceObject("javascript_global", "intervallo_log") + "';"
        literal_script.Text = literal_script.Text + "var name_coockie='" + codice_impianto + "_" + id_485_impianto + "_report" + "';"
        literal_script.Text = literal_script.Text + "</script>"

        function_javascript = function_javascript + "manage_div();"
        function_javascript = function_javascript + "manage_report();"
        function_javascript = function_javascript + "create_picker();"
        java_script_function.call_function_javascript_onload(Page, function_javascript)
    End Sub
    Public Function get_status_boolean(ByVal valore_bool As Boolean) As String
        If valore_bool Then
            Return "ON"
        Else
            Return "OFF"
        End If
    End Function

    Private Function decode_on_off(ByVal input As String) As String
        If InStr(input, "1") <> 0 Then
            Return "On"
        Else
            Return "Off"
        End If
    End Function
    Private Function decode_on_off_flow(ByVal input As String) As String
        If InStr(input, "1") <> 0 Then
            Return "Off"
        Else
            Return "On"
        End If
    End Function

    Protected Sub btnExport_Click(sender As Object, e As EventArgs)
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=" + codice_impianto + "_" + id_485_impianto + ".pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        pnlPerson.RenderControl(hw)
        'Regex.Replace(hw., "", "")

        Dim local As String = sw.ToString()
        local = create_custom_export(local)


        Dim sr As New StringReader(local)
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)

        Dim htmlparser As HTMLWorker = New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()
    End Sub

    Protected Sub excel_id_Click(sender As Object, e As EventArgs) Handles excel_id.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=" + codice_impianto + "_" + id_485_impianto + ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            pnlPerson.RenderControl(hw)
            Dim local As String = sw.ToString()
            local = create_custom_export(local)


            Response.Output.Write(local)
            Response.Flush()
            Response.End()
        End Using
    End Sub
    Protected Function create_custom_export(ByVal local As String) As String
        If Not ch1_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_val.ID + """>.*?</th>", "")
        End If

        If Not ch1_aa.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_aa.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_aa.ID + """>.*?</th>", "")
        End If
        If Not ch1_ab.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_ab.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_ab.ID + """>.*?</th>", "")
        End If
        If Not ch1_ad.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_ad.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_ad.ID + """>.*?</th>", "")
        End If
        If Not ch1_ar.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch1_ar.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch1_ar.ID + """>.*?</th>", "")
        End If

        If Not ch2_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_val.ID + """>.*?</th>", "")
        End If

        If Not ch2_aa.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_aa.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_aa.ID + """>.*?</th>", "")
        End If
        If Not ch2_ab.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_ab.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_ab.ID + """>.*?</th>", "")
        End If
        If Not ch2_ad.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_ad.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_ad.ID + """>.*?</th>", "")
        End If
        If Not ch2_ar.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch2_ar.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch2_ar.ID + """>.*?</th>", "")
        End If

        If Not ch3_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_val.ID + """>.*?</th>", "")
        End If

        If Not ch3_aa.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_aa.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_aa.ID + """>.*?</th>", "")
        End If
        If Not ch3_ab.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_ab.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_ab.ID + """>.*?</th>", "")
        End If
        If Not ch3_ad.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_ad.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_ad.ID + """>.*?</th>", "")
        End If
        If Not ch3_ar.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch3_ar.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch3_ar.ID + """>.*?</th>", "")
        End If

        If Not ch4_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch4_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch4_val.ID + """>.*?</th>", "")
        End If

        If Not ch4_aa.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch4_aa.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch4_aa.ID + """>.*?</th>", "")
        End If
        If Not ch4_ab.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch4_ab.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch4_ab.ID + """>.*?</th>", "")
        End If
        If Not ch4_ad.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch4_ad.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch4_ad.ID + """>.*?</th>", "")
        End If
        If Not ch4_ar.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch4_ar.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch4_ar.ID + """>.*?</th>", "")
        End If

        If Not ch5_val.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch5_val.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch5_val.ID + """>.*?</th>", "")
        End If

        If Not ch5_aa.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch5_aa.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch5_aa.ID + """>.*?</th>", "")
        End If
        If Not ch5_ab.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch5_ab.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch5_ab.ID + """>.*?</th>", "")
        End If
        If Not ch5_ad.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch5_ad.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch5_ad.ID + """>.*?</th>", "")
        End If
        If Not ch5_ar.Checked Then
            local = Regex.Replace(local, "<td class=""" + ch5_ar.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + ch5_ar.ID + """>.*?</th>", "")
        End If

        If Not flow_select.Checked Then
            local = Regex.Replace(local, "<td class=""" + flow_select.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + flow_select.ID + """>.*?</th>", "")
        End If
        If Not temperature_select.Checked Then
            local = Regex.Replace(local, "<td class=""" + temperature_select.ID + """>.*?</td>", "")
            local = Regex.Replace(local, "<th class=""" + temperature_select.ID + """>.*?</th>", "")
        End If

        Return local
    End Function

    Protected Sub refresh_log_server_Click(sender As Object, e As EventArgs) Handles refresh_log_server.Click
        Dim init_date As String
        Dim last_date As String
        init_date = Page.Request("init_date")
        last_date = Page.Request("last_date")
        Response.Redirect("~/max5.aspx?codice=" + codice_impianto + "&id_485=" + id_485_impianto + "&pagina=17" + "&nome_impianto=" + nome_impianto + "&statistica=" + statistica + "&init_date=" + init_date + "&last_date=" + last_date)

    End Sub
End Class