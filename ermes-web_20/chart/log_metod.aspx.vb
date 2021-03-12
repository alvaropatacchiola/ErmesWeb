Imports System.Globalization
Imports System.IO
Imports System.Web


Public Class log_metod
    Inherits lingua
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_max5(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.logDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0
        Dim data_to As Date
        Dim data_from As Date

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(3) = Replace(parametri(3), """", "")
        parametri(4) = Replace(parametri(4), """", "")
        parametri(0) = Replace(parametri(0), """", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")

        Dim data_from_temp As Date
        Dim data_to_temp As Date
        data_from_temp = Date.Parse(parametri(3), New CultureInfo(culture, False))
        data_to_temp = Date.Parse(parametri(4), New CultureInfo(culture, False))
        'data_from_temp = Date.Parse(parametri(3))
        'data_to_temp = Date.Parse(parametri(4))
        data_to = Now

        'data_from = data_to.AddDays(-30)
        'data_to = DateAdd(DateInterval.Day, 1, data_to)
        data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day, 0, 0, 0)
        data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)

        table_log = query.get_log_max5(parametri(0), id_string, temporaneo_id, data_from, data_to)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            data_str = data_str + "," + Replace(dc.valore1.ToString, ",", ".") + "," + Replace(dc.valore2.ToString, ",", ".") + "," + Replace(dc.valore3.ToString, ",", ".") + "," + Replace(dc.valore4.ToString, ",", ".") + "," + Replace(dc.valore5.ToString, ",", ".") + "," + main_function.get_status_string(dc.Aa1) + "," + main_function.get_status_string(dc.Aa2) + "," + main_function.get_status_string(dc.Aa3) + "," + main_function.get_status_string(dc.Aa4) + "," + main_function.get_status_string(dc.Aa5) _
                + "," + main_function.get_status_string(dc.Ab1) + "," + main_function.get_status_string(dc.Ab2) + "," + main_function.get_status_string(dc.Ab3) + "," + main_function.get_status_string(dc.Ab4) + "," + main_function.get_status_string(dc.Ab5) + "," + main_function.get_status_string(dc.Ad1) + "," + main_function.get_status_string(dc.Ad2) + "," + main_function.get_status_string(dc.Ad3) + "," + main_function.get_status_string(dc.Ad4) + "," + main_function.get_status_string(dc.Ad5) + "," + main_function.get_status_string(dc.Ar1) + "," + main_function.get_status_string(dc.Ar2) + "," + main_function.get_status_string(dc.Ar3) + "," + main_function.get_status_string(dc.Ar4) + "," + main_function.get_status_string(dc.Ar5) _
                + "," + main_function.get_status_stringInverse(dc.Flow) + "," + Replace(dc.temperatura.ToString, ",", ".") + "," + main_function.get_status_string(dc.fml) + "," + Replace(dc.wm.ToString, ",", ".") _
            + "," + main_function.get_status_boolean(dc.da1) + "," + main_function.get_status_boolean(dc.db1) + "," + Replace(dc.pa1.ToString, ",", ".") + "," + Replace(dc.pb1.ToString, ",", ".") + "," + Replace(dc.ma1.ToString, ",", ".") _
            + "," + main_function.get_status_boolean(dc.da2) + "," + main_function.get_status_boolean(dc.db2) + "," + Replace(dc.pa2.ToString, ",", ".") + "," + Replace(dc.pb2.ToString, ",", ".") + "," + Replace(dc.ma2.ToString, ",", ".") _
            + "," + main_function.get_status_boolean(dc.da3) + "," + main_function.get_status_boolean(dc.db3) + "," + Replace(dc.pa3.ToString, ",", ".") + "," + Replace(dc.pb3.ToString, ",", ".") + "," + Replace(dc.ma3.ToString, ",", ".") _
            + "," + main_function.get_status_boolean(dc.da4) + "," + main_function.get_status_boolean(dc.db4) + "," + Replace(dc.pa4.ToString, ",", ".") + "," + Replace(dc.pb4.ToString, ",", ".") + "," + Replace(dc.ma4.ToString, ",", ".") _
            + "," + main_function.get_status_boolean(dc.da5) + "," + main_function.get_status_boolean(dc.db5) + "," + Replace(dc.pa5.ToString, ",", ".") + "," + Replace(dc.pb5.ToString, ",", ".") + "," + Replace(dc.ma5.ToString, ",", ".") + "," + main_function.get_status_boolean(dc.stby)
            array.Add(data_str)
            'contatore += 1
            'If contatore > 2 Then
            '    Exit For
            'End If
        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function get_log_ld(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.ld_logDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0
        Dim data_to As Date
        Dim data_from As Date

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(3) = Replace(parametri(3), """", "")
        parametri(4) = Replace(parametri(4), """", "")
        parametri(0) = Replace(parametri(0), """", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")

        Dim data_from_temp As Date
        Dim data_to_temp As Date
        data_from_temp = Date.Parse(parametri(3), New CultureInfo(culture, False))
        data_to_temp = Date.Parse(parametri(4), New CultureInfo(culture, False))
        'data_from_temp = Date.Parse(parametri(3))
        'data_to_temp = Date.Parse(parametri(4))
        data_to = Now

        'data_from = data_to.AddDays(-30)
        'data_to = DateAdd(DateInterval.Day, 1, data_to)
        data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day, 0, 0, 0)
        data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)

        table_log = query.get_log_ld(parametri(0), id_string, temporaneo_id, data_from, data_to)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            data_str = data_str + "," + Replace(dc.valore1.ToString, ",", ".") + "," + Replace(dc.valore2.ToString, ",", ".") + "," + Replace(dc.valore3.ToString, ",", ".") _
               + "," + main_function.get_status_string(dc.feed_limit_ph) + "," + main_function.get_status_string(dc.feed_limit_cl) + "," + main_function.get_status_string(dc.dos_alarm_ph) + "," + main_function.get_status_string(dc.dos_alarm_cl) _
                + "," + main_function.get_status_string(dc.probe_fail_ph) + "," + main_function.get_status_string(dc.probe_fail_cl) _
                + "," + main_function.get_status_string(dc.livello1) + "," + main_function.get_status_string(dc.livello2) + "," + main_function.get_status_string(dc.livello3) _
                + "," + main_function.get_status_string(dc.flusso) + "," + Replace(dc.temperatura.ToString, ",", ".") + "," + main_function.get_status_boolean(dc.stby) _
                + "," + Replace(dc.m3h.ToString, ",", ".") + "," + Replace(dc.totalizer.ToString, ",", ".") + "," + dc.Stato_pulse1_ch1.ToString + "," + dc.Stato_pulse2_ch1.ToString _
                + "," + dc.Stato_rele_ch1.ToString + "," + dc.Stato_pulse_ch2.ToString + "," + dc.Stato_rele_ch2.ToString + "," + Replace(dc.valore4.ToString, ",", ".") _
                + "," + dc.feed_limit_ch3.ToString + "," + dc.feed_limit_ch4.ToString
            array.Add(data_str)



            'contatore += 1
            'If contatore > 2 Then
            '    Exit For
            'End If
        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function get_log_ltb(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.ltb_logDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0
        Dim data_to As Date
        Dim data_from As Date

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(3) = Replace(parametri(3), """", "")
        parametri(4) = Replace(parametri(4), """", "")
        parametri(0) = Replace(parametri(0), """", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")

        Dim data_from_temp As Date
        Dim data_to_temp As Date
        data_from_temp = Date.Parse(parametri(3), New CultureInfo(culture, False))
        data_to_temp = Date.Parse(parametri(4), New CultureInfo(culture, False))
        'data_from_temp = Date.Parse(parametri(3))
        'data_to_temp = Date.Parse(parametri(4))
        data_to = Now

        'data_from = data_to.AddDays(-30)
        'data_to = DateAdd(DateInterval.Day, 1, data_to)
        data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day, 0, 0, 0)
        data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)

        table_log = query.get_log_ltb(parametri(0), id_string, temporaneo_id, data_from, data_to)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            data_str = data_str + "," + Replace(dc.valore1.ToString, ",", ".") + "," + Replace(dc.valore2.ToString, ",", ".") + "," + Replace(dc.temperatura.ToString, ",", ".") _
               + "," + main_function.get_status_string(dc.flusso) + "," + main_function.get_status_string(dc.lev_hcl) + "," + main_function.get_status_string(dc.lev_naclo2) + "," + main_function.get_status_string(dc.lev_k6) _
                + "," + main_function.get_status_string(dc.temp_max) + "," + main_function.get_status_string(dc._stop) _
                + "," + main_function.get_status_string(dc.lev_errata) + "," + Replace(dc.totAcqua.ToString, ",", ".")
            array.Add(data_str)



            'contatore += 1
            'If contatore > 2 Then
            '    Exit For
            'End If
        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_wd(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.wd_logDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0
        Dim data_to As Date
        Dim data_from As Date

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(3) = Replace(parametri(3), """", "")
        parametri(4) = Replace(parametri(4), """", "")
        parametri(0) = Replace(parametri(0), """", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")

        Dim data_from_temp As Date
        Dim data_to_temp As Date
        data_from_temp = Date.Parse(parametri(3), New CultureInfo(culture, False))
        data_to_temp = Date.Parse(parametri(4), New CultureInfo(culture, False))
        'data_from_temp = Date.Parse(parametri(3))
        'data_to_temp = Date.Parse(parametri(4))
        data_to = Now

        'data_from = data_to.AddDays(-30)
        'data_to = DateAdd(DateInterval.Day, 1, data_to)
        data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day, 0, 0, 0)
        data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)

        table_log = query.get_log_wd(parametri(0), id_string, temporaneo_id, data_from, data_to)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            data_str = data_str + "," + Replace(dc.valore1.ToString, ",", ".") + "," + Replace(dc.valore2.ToString, ",", ".") _
               + "," + main_function.get_status_string(dc.dos_alarm_ph) + "," + main_function.get_status_string(dc.dos_alarm_cl) + "," + main_function.get_status_string(dc.probe_fail_ph) + "," + main_function.get_status_string(dc.probe_fail_cl) _
                + "," + main_function.get_status_string(dc.livello1) + "," + main_function.get_status_string(dc.livello2) _
                + "," + main_function.get_status_string(dc.flusso) + "," + Replace(dc.rele_ch1.ToString, ",", ".") + "," + Replace(dc.rele_ch2.ToString, ",", ".")

            array.Add(data_str)


        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_wh(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.wh_logDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0
        Dim data_to As Date
        Dim data_from As Date

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(3) = Replace(parametri(3), """", "")
        parametri(4) = Replace(parametri(4), """", "")
        parametri(0) = Replace(parametri(0), """", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")

        Dim data_from_temp As Date
        Dim data_to_temp As Date
        data_from_temp = Date.Parse(parametri(3), New CultureInfo(culture, False))
        data_to_temp = Date.Parse(parametri(4), New CultureInfo(culture, False))
        'data_from_temp = Date.Parse(parametri(3))
        'data_to_temp = Date.Parse(parametri(4))
        data_to = Now

        'data_from = data_to.AddDays(-30)
        'data_to = DateAdd(DateInterval.Day, 1, data_to)
        data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day, 0, 0, 0)
        data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)

        table_log = query.get_log_wh(parametri(0), id_string, temporaneo_id, data_from, data_to)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            data_str = data_str + "," + Replace(dc.valore1.ToString, ",", ".") + "," + Replace(dc.valore2.ToString, ",", ".") _
               + "," + main_function.get_status_string(dc.dos_alarm_ph) + "," + main_function.get_status_string(dc.dos_alarm_cl) + "," + main_function.get_status_string(dc.probe_fail_ph) + "," + main_function.get_status_string(dc.probe_fail_cl) _
                + "," + main_function.get_status_string(dc.livello1) + "," + main_function.get_status_string(dc.livello2) _
                + "," + Replace(dc.stato_pulse1_ch1.ToString, ",", ".") + "," + Replace(dc.stato_pulse2_ch1.ToString, ",", ".") _
                + "," + Replace(dc.stato_pulse_ch2.ToString, ",", ".") + "," + main_function.get_status_string(dc.stato_rele_ch1) _
                + "," + main_function.get_status_string(dc.stato_rele_ch2) + "," + main_function.get_status_string(dc.timer_manutenzione) _
                + "," + main_function.get_status_string(dc.timer_pagamento) + "," + main_function.get_status_string(dc.timer_sonda_ph) _
                + "," + main_function.get_status_string(dc.timer_sonda_mv) + "," + main_function.get_status_string(dc.timer_filtro) _
                + "," + main_function.get_status_string(dc.flusso) + "," + main_function.get_status_string(dc.stby)


            array.Add(data_str)


        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_tower(ByVal parametro As String) As List(Of String)
        Dim table_log As ermes_web_20.quey_db.log_towerDataTable
        Dim query As New query
        Dim parametri() As String = parametro.Split(",")
        Dim temporaneo_id As String = ""
        Dim culture As String = "it-IT"
        Dim array As New List(Of String)

        Dim contatore As Integer = 0
        Dim data_to As Date
        Dim data_from As Date

        temporaneo_id = Str(Val(parametri(1)))
        temporaneo_id = temporaneo_id.Replace(" ", "")
        parametri(3) = Replace(parametri(3), """", "")
        parametri(4) = Replace(parametri(4), """", "")
        parametri(0) = Replace(parametri(0), """", "")
        Dim id_string As String = Format(Val(temporaneo_id), "00")

        Dim data_from_temp As Date
        Dim data_to_temp As Date
        data_from_temp = Date.Parse(parametri(3), New CultureInfo(culture, False))
        data_to_temp = Date.Parse(parametri(4), New CultureInfo(culture, False))
        'data_from_temp = Date.Parse(parametri(3))
        'data_to_temp = Date.Parse(parametri(4))
        data_to = Now

        'data_from = data_to.AddDays(-30)
        'data_to = DateAdd(DateInterval.Day, 1, data_to)
        data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day, 0, 0, 0)
        data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)

        table_log = query.get_log_tower(parametri(0), id_string, temporaneo_id, data_from, data_to)
        For Each dc In table_log
            'Dim time As DateTime = DateTime.Parse(dc.data, New CultureInfo(culture, False))
            Dim data_str As String = "" + (dc.data.Year).ToString + "," + (dc.data.Month - 1).ToString + "," + dc.data.Day.ToString + "," + dc.data.Hour.ToString + "," + dc.data.Minute.ToString + ""
            data_str = data_str + "," + Replace(dc.valore1.ToString, ",", ".") + "," + Replace(dc.valore2.ToString, ",", ".") + "," + Replace(dc.valore3.ToString, ",", ".") _
               + "," + main_function.get_status_string(dc.cd_high) + "," + main_function.get_status_string(dc.cd_low) + "," + main_function.get_status_string(dc.bleed_timeout) + "," + main_function.get_status_string(dc.level_inhibitor) _
                + "," + main_function.get_status_string(dc.level_prebiocide1) + "," + main_function.get_status_string(dc.level_prebiocide2) _
                + "," + main_function.get_status_string(dc.level_biocide1) + "," + main_function.get_status_string(dc.level_biocide2) _
                + "," + main_function.get_status_string(dc.ch2_high) + "," + main_function.get_status_string(dc.ch2_low) + "," + main_function.get_status_string(dc.ch2_level) _
                + "," + main_function.get_status_string(dc.ch3_high) + "," + main_function.get_status_string(dc.ch3_low) + "," + main_function.get_status_string(dc.ch3_level) _
                + "," + main_function.get_status_string(dc.flow) _
                + "," + Replace(dc.temperatura.ToString, ",", ".") + "," + Replace(dc.tot_input.ToString, ",", ".") + "," + Replace(dc.tot_bleed.ToString, ",", ".") _
                + "," + main_function.get_status_string(dc.Power_On)


            array.Add(data_str)


        Next
        Return array
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_ld_usb(ByVal parametro As String) As List(Of String)
        Dim array As New List(Of String)

        parametro = parametro.Replace("!", "\")
        parametro = Replace(parametro, """", "")
        Dim sr As New System.IO.StreamReader(parametro)
        Do While sr.Peek() >= 0
            Dim linea() As String
            linea = sr.ReadLine().Split("|")
            Dim data_str As String = linea(0) + ";" + linea(1) + ";" + linea(2) + ";" + linea(3) + ";" + linea(4) + ";" + linea(5) + ";" + linea(6) + ";" + linea(7) + ";" + linea(8) + ";" + linea(9) + ";" + linea(10) + ";" +
                linea(11) + ";" + linea(12) + ";" + linea(13) + ";" + linea(14) + ";" + linea(15) + ";" + linea(16) + ";" + linea(17) + ";" + linea(18) + ";" + linea(19)
            Array.Add(data_str)

        Loop
        sr.Close()

        Return Array
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Function get_log_tower_usb(ByVal parametro As String) As List(Of String)
        Dim array As New List(Of String)

        parametro = parametro.Replace("!", "\")
        parametro = Replace(parametro, """", "")
        Dim sr As New System.IO.StreamReader(parametro)
        Do While sr.Peek() >= 0
            Dim linea() As String
            linea = sr.ReadLine().Split("|")
            Dim data_str As String = linea(0) + ";" + linea(1) + ";" + linea(2) + ";" + linea(3) + ";" + linea(4) + ";" + linea(5) + ";" + linea(6) + ";" + linea(7) + ";" + linea(8) + ";" + linea(9) + ";" + linea(10) + ";" +
                linea(11) + ";" + linea(12) + ";" + linea(13) + ";" + linea(14) + ";" + linea(15) + ";" + linea(16) + ";" + linea(17) + ";" + linea(18) + ";" + linea(19) + ";" + linea(20) + ";" + linea(21) + ";" + linea(22) _
                + ";" + linea(23)
            array.Add(data_str)

        Loop
        sr.Close()
        Return array
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

End Class