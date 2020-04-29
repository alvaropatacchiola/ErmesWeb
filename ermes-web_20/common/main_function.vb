Imports System.Globalization
Public Class main_function

    Public Shared Function main_path() As String
        Return "http://localhost:10154/"
    End Function

    Public Shared Function get_tipo_strumento(ByVal db_tipo_strumento) As String
        Select Case db_tipo_strumento
            Case "max5"
                Return "Max 5"
            Case "Tower"
                Return "Tower"
            Case "LDtower"
                Return "CoolTrol"

            Case "LD"
                Return "LD"
            Case "LDDT"
                Return "LDDT"
            Case "LDS"
                Return "LDS"
            Case "LD4"
                Return "LD4"
            Case "WD"
                Return "WD"
            Case "WH"
                Return "WH"
            Case "LTB"
                Return "LTB"
            Case "LDMA"
                Return "LDmA"
            Case "LDLG"
                Return "LDlG"

            Case "LTA"
                Return "LTA"
            Case "LTD"
                Return "LTD"
            Case "LTU"
                Return "LTU"
        End Select
    End Function
    Public Shared Function get_status_boolean(ByVal valore_bool As Boolean) As String
        If valore_bool Then
            Return "1"
        Else
            Return "0"
        End If
    End Function
    Public Shared Function get_status_string(ByVal valore_string As String) As String
        If InStr(valore_string, "1") <> 0 Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata al calcolo del numero di cifre dopo la virgola, necessaria per java scrip
    '---------------------------------------------------------------------------------------------------------

    Public Shared Function set_fullscale(ByVal range As Single) As Integer
        If range >= 0 And range <= 9.9990000000000006 Then
            Return 3
        End If
        If range >= 10 And range <= 99.989999999999995 Then
            Return 2
        End If
        If range >= 100 And range <= 999.89999999999998 Then
            Return 1
        End If
        If range >= 1000 And range <= 9999 Then
            Return 0
        End If
    End Function
    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata al calcolo delle ore e dei minuti di assenza flusso a partire da i minuti
    '---------------------------------------------------------------------------------------------------------
    Public Shared Sub calcola_ore_minuti(ByVal minuti_tot As Long, ByRef ore_flow As Integer, ByRef minuti_flow As Integer)
        Dim temp As Long = 0
        temp = minuti_tot / 60
        ore_flow = temp
        minuti_flow = minuti_tot - (ore_flow * 60)

    End Sub
    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata alla ricerca del tipo di personalizzazione presente nella versione dello strumento
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function get_tipo_personalizzazione(ByVal version_current As String) As String
        Dim string_temporanea As String = ""
        string_temporanea = get_version(version_current)
        If InStr(string_temporanea, "Y") <> 0 Then ' versione Yagel
            Return "yagel"
        End If
        If InStr(string_temporanea, "D") <> 0 Then ' versione doppia piscina
            Return "doppiaPiscina"
        End If
        If InStr(string_temporanea, "P") <> 0 Then ' versione doppia piscina
            Return "seiCanali"
        End If
    End Function
    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata alla ricerca dell'identificativo all'interno del protocollo
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function get_str_id(ByVal input As String) As String
        Dim id_value() As String = input.Split("&")
        Dim id_name() As String = id_value(0).Split("d")
        Dim id_name_str As String = ""
        If id_name.Count = 1 Then
            id_name_str = id_name(0)
        End If
        If id_name.Count > 1 Then
            id_name_str = id_name(1)
        End If
        Return id_name_str
    End Function
    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata alla ricerca della label RS485 all'interno del protocollo
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function get_lebel_485(ByVal db_label) As String
        Dim id_value() As String = db_label.Split("&")
        If id_value.Length > 1 Then
            Dim id_name() As String = id_value(1).Split("#")
            If id_name.Length > 1 Then
                id_name(1) = id_name(1).Replace("<", "&lt;")
                id_name(1) = id_name(1).Replace(">", "&gt;")
                Return id_name(1)
            End If
        End If
        Return ""
    End Function
    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata alla ricerca della versione dello strumento all'interno del protocollo in formato stringa
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function get_version(ByVal db_version) As String
        Dim id_value() As String = db_version.Split("&")
        If id_value.Length > 1 Then
            Dim id_name() As String = id_value(1).Split("#")
            If id_name.Length > 1 Then
                Try
                    Return id_name(3)
                Catch ex As Exception
                    Return ""
                End Try
            End If
        End If
        Return ""
    End Function
    '------------------------------------------------------------------------------------------------------------
    'Procedura di gestione legata alla ricerca della versione dello strumento all'interno del protocollo, in formato intero
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function get_version_integer(ByVal db_version As String, Optional ByRef version_complete As Integer = 0) As Integer
        Dim id_value() As String = db_version.Split("&")
        If id_value.Length > 1 Then
            Dim id_name() As String = id_value(1).Split("#")
            If id_name.Length > 1 Then
                Try
                    Dim str_version_split() As String = id_name(3).Split(".")
                    Dim number_version As Integer
                    Try
                        number_version = Val(str_version_split(0) + str_version_split(1))
                        version_complete = Val(str_version_split(0) + str_version_split(1) + str_version_split(2))
                    Catch ex As Exception
                        number_version = 0
                    End Try

                    Return number_version
                Catch ex As Exception
                    Return ""
                End Try
            End If
        End If
        Return 0
    End Function

    '------------------------------------------------------------------------------------------------------------
    'Procedura di separazione delle stringhe all'interno del protocollo dai marker & e #
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function get_split_str(ByVal output_str) As String()
        Dim data() As String = output_str.Split("&"c)
        Dim data1() As String
        If data.Length() > 0 Then
            data1 = data(1).Split("#")
            Return data1
        End If
        Return Nothing
    End Function
    '------------------------------------------------------------------------------------------------------------
    'Procedura di controllo se uno strumento è connesso o meno
    '---------------------------------------------------------------------------------------------------------
    Public Shared Function check_is_connected_produzione(ByVal date_value1 As String, Optional ByRef differenza_minuti As Long = 0) As Boolean
        Dim differenza_minuti_temp As Long = 0
        Dim culture As String = "it-IT"
        Dim date_value As Date = Date.Parse(date_value1, New CultureInfo(culture, False))
        differenza_minuti_temp = DateDiff(DateInterval.Minute, date_value, Now)
        differenza_minuti = differenza_minuti_temp
        If differenza_minuti_temp < 60 Then ' se non fa aggiornamento per oltre una ora lo considero disconnesso
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function check_is_connected(ByVal date_value As Date, Optional ByRef differenza_minuti As Long = 0) As Boolean
        Dim differenza_minuti_temp As Long = 0
        differenza_minuti_temp = DateDiff(DateInterval.Minute, date_value, Now)
        differenza_minuti = differenza_minuti_temp
        If differenza_minuti_temp < 60 Then ' se non fa aggiornamento per oltre una ora lo considero disconnesso
            Return True
        Else
            Return False
        End If
    End Function

    'gestione allarmi max 5
    '
    Public Shared Function check_max5_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else

            For i = 0 To 4
                If alarm_max5_aa(data(5 + i)) Or alarm_max5_ab(data(5 + i)) Or alarm_max5_ad(data(5 + i)) Or alarm_max5_ar(data(5 + i)) _
                    Or alarm_max5_levda(data(5 + i)) Or alarm_max5_levdb(data(5 + i)) Or alarm_max5_levpa(data(5 + i)) Or alarm_max5_levpb(data(5 + i)) _
                    Or alarm_max5_levma(data(5 + i)) Then
                    alarm_ckeck_temp = True
                End If
            Next
            Dim integer_item As Integer = 0
            integer_item = alarm_max5_flow(data(10)) 'flusso
            If integer_item > 0 Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If data.Length > 15 Then ' allarme di flusso 2 per doppio flusso
                integer_item = alarm_max5_flow2(data(14)) 'flusso
                If integer_item > 0 Then
                    contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                    alarm_ckeck_temp = True
                End If
            End If

            integer_item = alarm_max5_stby(data(10)) 'stby
            If integer_item > 0 Then
                alarm_ckeck_temp = True
            End If
            If data.Length > 12 Then ' allarme di temperatura
                If (alarm_max5_temperature(data(12))) Then
                    alarm_ckeck_temp = True
                End If
                If data.Length > 15 Then ' allarme di flusso 2 per doppio flusso
                    If (alarm_max5_temperature(data(13))) Then
                        alarm_ckeck_temp = True ' temperatura 2
                    End If
                End If
            End If
        End If
        Return alarm_ckeck_temp
    End Function
    Public Shared Function getDaDb(ByVal indiceRiga As Integer, ByVal rigastrumento As String, ByRef enableSP As Integer, ByRef valueMin As Integer, ByRef valueMax As Integer)
        Dim data_sp() As String
        Dim pointEnable As String
        Dim valueDA As String
        Dim controlloEnable As String = ""

        data_sp = get_split_str(rigastrumento)
        valueDA = data_sp(indiceRiga)
        pointEnable = data_sp(0)
        Select Case indiceRiga
            Case 1
                controlloEnable = Mid(pointEnable, 3, 1)
            Case 2
                controlloEnable = Mid(pointEnable, 4, 1)
        End Select



        If controlloEnable <> "0" Then ' da
            enableSP = 1
            valueMin = Val(Mid(valueDA, 4, 4))
            valueMax = Val(Mid(valueDA, 8, 4))
        Else
            enableSP = 0
            valueMin = 0
            valueMax = 0
        End If
        If (valueMin > valueMax) Then
            Dim temp As Integer = valueMin
            valueMin = valueMax
            valueMax = temp
        End If
    End Function
    Public Shared Function getPaPb(ByVal indiceRiga As Integer, ByVal rigastrumento As String, ByRef enableSP As Integer, ByRef valueMin As Integer, ByRef valueMax As Integer)
        Dim data_sp() As String
        Dim pointEnable As String
        Dim valueDA As String
        Dim controlloEnable As String = ""

        data_sp = get_split_str(rigastrumento)
        valueDA = data_sp(indiceRiga)
        pointEnable = data_sp(0)
        Select Case indiceRiga
            Case 3
                controlloEnable = Mid(pointEnable, 5, 1)
            Case 4
                controlloEnable = Mid(pointEnable, 6, 1)
            Case 5
        End Select




        If controlloEnable <> "0" Then ' pa
            enableSP = 1
            valueMin = Val(Mid(valueDA, 3, 4))
            valueMax = Val(Mid(valueDA, 7, 4))
        Else
            enableSP = 0
            valueMin = 0
            valueMax = 0
        End If
        If (valueMin > valueMax) Then
            Dim temp As Integer = valueMin
            valueMin = valueMax
            valueMax = temp
        End If
    End Function
    Public Shared Function getDb(ByVal rigastrumento As String, ByRef enableSP As Boolean, ByRef valueMin As Integer, ByRef valueMax As Integer)
        Dim data_sp() As String
        Dim pointEnable As String
        Dim valueDA As String

        data_sp = get_split_str(rigastrumento)
        valueDA = data_sp(1)
        pointEnable = data_sp(0)

        If Mid(pointEnable, 3, 1) <> "0" Then ' da
            enableSP = True
            valueMin = Val(Mid(valueDA, 4, 4))
            valueMax = Val(Mid(valueDA, 8, 4))
        Else
            enableSP = False
        End If
        If (valueMin > valueMax) Then
            Dim temp As Integer = valueMin
            valueMin = valueMax
            valueMax = valueMax
        End If
    End Function

    Public Shared Function getMinAlarm(ByVal rigastrumento As String, ByRef valueMin As Integer, ByRef valueMax As Integer)
        Dim data_sp() As String
        Dim pointEnable As String
        Dim alarmA As String
        Dim alarmB As String
        data_sp = get_split_str(rigastrumento)
        alarmA = data_sp(6)
        alarmB = data_sp(7)
        pointEnable = data_sp(0)
        If Mid(pointEnable, 8, 1) <> "0" Then ' alarm A
            Dim temp_calc As Single = Val(Mid(alarmA, 5, 4))

            If Mid(alarmA, 3, 1) = "1" Then ' alarm on - off
                If Mid(alarmA, 4, 1) = "1" Then '>
                    valueMax = temp_calc
                Else
                    valueMin = valueMin
                End If
                'on
            Else
                If Mid(alarmA, 4, 1) = "1" Then '>
                    valueMin = temp_calc
                Else
                    valueMax = valueMin
                End If
                'off
                'ASPxComboBox19.Text = "Rele Off"
            End If
        Else
            valueMin = 0
            valueMax = 0
        End If
        If Mid(pointEnable, 9, 1) <> "0" Then ' alarm B
            Dim temp_calc As Single = Val(Mid(alarmB, 5, 4))

            If Mid(alarmB, 3, 1) = "1" Then ' alarm on - off
                If Mid(alarmB, 4, 1) = "1" Then '>
                    valueMax = temp_calc
                Else
                    valueMin = valueMin
                End If
                'on
            Else
                If Mid(alarmB, 4, 1) = "1" Then '>
                    valueMin = temp_calc
                Else
                    valueMax = valueMin
                End If
                'off
                'ASPxComboBox19.Text = "Rele Off"
            End If
        Else
            valueMin = 0
            valueMax = 0
        End If
    End Function
    Public Shared Function alarm_max5_aa(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 3, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 3, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_aa_str(ByVal output_str As String) As String
        Return Mid(output_str, 3, 1)
    End Function
    Public Shared Function alarm_max5_aa_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Aa"
        Else
            If output_str(10).Length > 0 Then
                Return output_str(10)
            Else
                Return "Aa"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_ab(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 4, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 4, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_ab_str(ByVal output_str As String) As String
        Return Mid(output_str, 4, 1)
    End Function
    Public Shared Function alarm_max5_ab_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Ab"
        Else
            If output_str(11).Length > 0 Then
                Return output_str(11)
            Else
                Return "Ab"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_ad(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 5, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 5, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_ad_str(ByVal output_str As String) As String
        Return Mid(output_str, 5, 1)
    End Function
    Public Shared Function alarm_max5_ad_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Ad"
        Else
            If output_str(12).Length > 0 Then
                Return output_str(12)
            Else
                Return "Ad"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_ar(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 6, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 6, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_ar_str(ByVal output_str As String) As String
        Return Mid(output_str, 6, 1)
    End Function
    Public Shared Function alarm_max5_ar_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Ar"
        Else
            If output_str(13).Length > 0 Then
                Return output_str(13)
            Else
                Return "Ar"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_levda(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 7, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 7, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_levda_str(ByVal output_str As String) As String
        Return Mid(output_str, 7, 1)
    End Function
    Public Shared Function alarm_max5_levda_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "In1"
        Else
            If output_str(1).Length > 0 Then
                Return output_str(1)
            Else
                Return "In1"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_levdb(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 8, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 8, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_levdb_str(ByVal output_str As String) As String
        Return Mid(output_str, 8, 1)
    End Function
    Public Shared Function alarm_max5_levdb_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "In2"
        Else
            If output_str(3).Length > 0 Then
                Return output_str(3)
            Else
                Return "In2"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_levpa(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 9, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 9, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_levpa_str(ByVal output_str As String) As String
        Return Mid(output_str, 9, 1)
    End Function
    Public Shared Function alarm_max5_levpa_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "In3"
        Else
            If output_str(5).Length > 0 Then
                Return output_str(5)
            Else
                Return "In3"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_levpb(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 10, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 10, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_levpb_str(ByVal output_str As String) As String
        Return Mid(output_str, 10, 1)
    End Function
    Public Shared Function alarm_max5_levpb_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "In4"
        Else
            If output_str(7).Length > 0 Then
                Return output_str(7)
            Else
                Return "In4"
            End If
        End If
    End Function

    Public Shared Function alarm_max5_levma(ByVal output_str As String) As Boolean
        Try
            If Mid(output_str, 11, 1) = "1" Then
                Return True
            End If
            If Mid(output_str, 11, 1) = "0" Then
                Return False
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_max5_levma_str(ByVal output_str As String) As String
        Return Mid(output_str, 11, 1)
    End Function
    Public Shared Function alarm_max5_levma_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "In5"
        Else
            If output_str(9).Length > 0 Then
                Return output_str(9)
            Else
                Return "In5"
            End If
        End If
    End Function
    Public Shared Function enable_da(ByVal output_str As String) As Boolean
        If Mid(output_str, 3, 1) <> "0" Then ' da
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_db(ByVal output_str As String) As Boolean
        If Mid(output_str, 4, 1) <> "0" Then ' db
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_pa(ByVal output_str As String) As Boolean
        If Mid(output_str, 5, 1) <> "0" Then ' pa
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_pb(ByVal output_str As String) As Boolean
        If Mid(output_str, 6, 1) <> "0" Then ' pb
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_ma(ByVal output_str As String) As Boolean
        If Mid(output_str, 7, 1) <> "0" Then ' ma
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_aa(ByVal output_str As String) As Boolean
        If Mid(output_str, 8, 1) <> "0" Then ' aa
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_ab(ByVal output_str As String) As Boolean
        If Mid(output_str, 9, 1) <> "0" Then ' ab
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_ad(ByVal output_str As String) As Boolean
        If Mid(output_str, 10, 1) <> "0" Then ' ad
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function enable_ar(ByVal output_str As String) As Boolean
        If Mid(output_str, 11, 1) <> "0" Then ' ar
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function alarm_max5_flow(ByVal output_str As String) As Integer
        Return Val(Mid(output_str, 3, 2))
    End Function
    Public Shared Function alarm_max5_flow2(ByVal output_str As String) As Integer
        Try
            Return Val(Mid(output_str, 1, 2))
        Catch ex As Exception
            Return 0
        End Try
        Return 0
    End Function
    Public Shared Function alarm_max5_stby(ByVal output_str As String) As Integer
        Return Val(Mid(output_str, 5, 2))
    End Function
    Public Shared Function alarm_max5_probe_clean(ByVal output_str As String) As Integer
        Return Val(Mid(output_str, 9, 2))
    End Function
    Public Shared Function alarm_max5_yagel_flowmeterlow(ByVal output_str As String) As Integer
        Return Val(Mid(output_str, 22, 1))
    End Function

    Public Shared Function alarm_max5_temperature(ByVal output_str As String) As Boolean
        If output_str = "1" Then
            Return True
        End If
        Return False
    End Function
    Public Shared Function alarm_max5_manual(ByVal output_str As String) As Boolean
        If output_str = "1" Then
            Return True
        End If
        Return False
    End Function

    '---------------------------------------------------
    '------end gestione allarmi max 5
    '---------------------------------------------------
    '---------------------------------------------------
    '------gestione timer max 5
    '---------------------------------------------------
    Public Shared Function timer_max5_1(ByVal output_str As String) As String
        If output_str.Length > 10 Then
            Return Mid(output_str, 3, 1) + "|" + Mid(output_str, 4, 2) + "|" + Mid(output_str, 6, 3) + "|" + Mid(output_str, 9, 2) + "|" + Mid(output_str, 11, 2)
        Else
            Return ""
        End If
        'timer attivo oppure no|uscita pompa|numero impulsi se opto|ore al termine|minuti al termine
    End Function
    Public Shared Function timer_max5_2(ByVal output_str As String) As String
        If output_str.Length > 10 Then
            Return Mid(output_str, 13, 1) + "|" + Mid(output_str, 14, 2) + "|" + Mid(output_str, 16, 3) + "|" + Mid(output_str, 19, 2) + "|" + Mid(output_str, 21, 2)
        Else
            Return ""
        End If
        'timer attivo oppure no|uscita pompa|numero impulsi se opto|ore al termine|minuti al termine
    End Function
    Public Shared Function timer_max5_3(ByVal output_str As String) As String
        If output_str.Length > 10 Then
            Return Mid(output_str, 3, 1) + "|" + Mid(output_str, 4, 2) + "|" + Mid(output_str, 6, 3) + "|" + Mid(output_str, 9, 2) + "|" + Mid(output_str, 11, 2)
        Else
            Return ""
        End If
        'timer attivo oppure no|uscita pompa|numero impulsi se opto|ore al termine|minuti al termine
    End Function
    Public Shared Function timer_max5_4(ByVal output_str As String) As String
        If output_str.Length > 10 Then
            Return Mid(output_str, 13, 1) + "|" + Mid(output_str, 14, 2) + "|" + Mid(output_str, 16, 3) + "|" + Mid(output_str, 19, 2) + "|" + Mid(output_str, 21, 2)
        Else
            Return ""
        End If
        'timer attivo oppure no|uscita pompa|numero impulsi se opto|ore al termine|minuti al termine
    End Function
    Public Shared Function timer_max5_5(ByVal output_str As String) As String
        If output_str.Length > 10 Then
            Return Mid(output_str, 23, 1) + "|" + Mid(output_str, 24, 2) + "|" + Mid(output_str, 26, 3) + "|" + Mid(output_str, 29, 2) + "|" + Mid(output_str, 31, 2)
        Else
            Return ""
        End If
        'timer attivo oppure no|uscita pompa|numero impulsi se opto|ore al termine|minuti al termine
    End Function

    '---------------------------------------------------
    '------end gestione timer max 5
    '---------------------------------------------------

    '---------------------------------------------------
    '------gestione uscite max 5
    '---------------------------------------------------
    Public Shared Function out_max5_da_str(ByVal output_str As String) As String
        Return Mid(output_str, 7, 1)
    End Function
    Public Shared Function out_max5_da_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Da"
        Else
            If output_str(0).Length > 0 Then
                Return output_str(0)
            Else
                Return "Da"
            End If
        End If

    End Function

    Public Shared Function out_max5_da_channel(ByVal output_str As String) As Integer
        Return Val(Mid(output_str, 8, 1))
    End Function

    Public Shared Function out_max5_db_str(ByVal output_str As String) As String
        Return Mid(output_str, 9, 1)
    End Function
    Public Shared Function out_max5_db_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Db"
        Else
            If output_str(2).Length > 0 Then
                Return output_str(2)
            Else
                Return "Db"
            End If
        End If

    End Function

    Public Shared Function out_max5_db_channel(ByVal output_str As String) As Integer
        Return Val(Mid(output_str, 10, 1))
    End Function

    Public Shared Function out_max5_pa_str(ByVal output_str As String) As Integer
        Dim str_temp As String = Mid(output_str, 11, 3)
        Return Val(str_temp)
    End Function
    Public Shared Function out_max5_pa_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Pa"
        Else
            If output_str(4).Length > 0 Then
                Return output_str(4)
            Else
                Return "Pa"
            End If
        End If

    End Function

    Public Shared Function out_max5_pa_channel(ByVal output_str As String) As Integer
        Dim str_temp As String = Mid(output_str, 14, 1)
        Return Val(str_temp)
    End Function

    Public Shared Function out_max5_pb_str(ByVal output_str As String) As Integer
        Dim str_temp As String = Mid(output_str, 15, 3)
        Return Val(str_temp)
    End Function
    Public Shared Function out_max5_pb_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "Pb"
        Else
            If output_str(6).Length > 0 Then
                Return output_str(6)
            Else
                Return "Pb"
            End If
        End If

    End Function

    Public Shared Function out_max5_pb_channel(ByVal output_str As String) As Integer
        Dim str_temp As String = Mid(output_str, 18, 1)
        Return Val(str_temp)
    End Function

    Public Shared Function out_max5_ma_str(ByVal output_str As String) As Integer
        Dim str_temp As String = Mid(output_str, 19, 2) + "." + Mid(output_str, 21, 1)
        Return Val(str_temp)
    End Function
    Public Shared Function out_max5_ma_name(ByVal output_str() As String) As String
        If output_str Is Nothing Then
            Return "mA"
        Else
            If output_str(8).Length > 0 Then
                Return output_str(8)
            Else
                Return "mA"
            End If
        End If

    End Function

    Public Shared Function out_max5_ma_channel(ByVal output_str As String) As Integer
        Dim str_temp As String = Mid(output_str, 22, 1)
        Return Val(str_temp)
    End Function

    '---------------------------------------------------
    '------end gestione uscite max 5
    '---------------------------------------------------
    '---------------------------------------------------
    'gestione allarmi LD LOG mA doppio
    '---------------------------------------------------
    Public Shared Function check_ldma_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_ld_ma_livello1(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_ma_livello2(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_ma_livello3(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_ma_livello4(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_ma_livello5(data) Then
                alarm_ckeck_temp = True
            End If
        End If
        Return alarm_ckeck_temp
    End Function
    Public Shared Function alarm_ld_ma_livello1(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_ma_livello2(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello2
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_ma_livello3(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' livello3
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_ma_livello4(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' livello4
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_ma_livello5(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' livello5
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    '---------------------------------------------------
    'end gestione allarmi LD LOG mA doppio
    '---------------------------------------------------

    '---------------------------------------------------
    'gestione allarmi LD doppio
    '---------------------------------------------------
    Public Shared Function check_ld_doppio_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_ld_livello1_ph(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_livello2_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_livello1_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_flusso(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_ld_feedlimit_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_feedlimit_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_dosalarm_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_dosalarm_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_probefail_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld_probefail_cl(data) Then
                alarm_ckeck_temp = True
            End If
        End If
        Return alarm_ckeck_temp
    End Function

    Public Shared Function alarm_ld_livello1_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_livello2_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_livello1_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' livello1 cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_flusso(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_feedlimit_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' feed limit ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_feedlimit_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' feed limit cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_dosalarm_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) = "0" And Mid(output_str(8), 1, 1) = "0" Then ' dosing alarm cl
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_dosalarm_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(9), 1, 1) = "0" And Mid(output_str(10), 1, 1) = "0" And Mid(output_str(11), 1, 1) = "0" Then ' dosing alarm ph
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_probefail_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(12), 1, 1) <> "0" Then ' probe fail ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld_probefail_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(13), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    '---------------------------------------------------
    'end gestione allarmi LD doppio
    '---------------------------------------------------
    '---------------------------------------------------
    'gestione allarmi LDDT doppio
    '---------------------------------------------------
    Public Shared Function check_lddt_doppio_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_lddt_livello1_ph(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_livello2_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_livello1_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_flusso(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_feedlimit_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_feedlimit_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_dosalarm_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_dosalarm_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_probefail_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lddt_probefail_cl(data) Then
                alarm_ckeck_temp = True
            End If
        End If
        Return alarm_ckeck_temp
    End Function

    Public Shared Function alarm_lddt_livello1_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_livello2_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_livello1_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' livello1 cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_flusso(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_feedlimit_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' feed limit ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_feedlimit_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' feed limit cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_dosalarm_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) = "0" And Mid(output_str(8), 1, 1) = "0" Then ' dosing alarm cl
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_dosalarm_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(9), 1, 1) = "0" And Mid(output_str(10), 1, 1) = "0" And Mid(output_str(11), 1, 1) = "0" Then ' dosing alarm ph
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_probefail_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(12), 1, 1) <> "0" Then ' probe fail ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lddt_probefail_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(13), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    '---------------------------------------------------
    'end gestione allarmi LDDT doppio
    '---------------------------------------------------
    '---------------------------------------------------
    'gestione allarmi LDS singolo
    '---------------------------------------------------
    Public Shared Function check_lds_singolo_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_lds_livello(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lds_flusso(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_lds_feedlimit(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lds_dosalarm(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lds_probefail(data) Then
                alarm_ckeck_temp = True
            End If
        End If
        Return alarm_ckeck_temp
    End Function

    Public Shared Function alarm_lds_livello(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lds_flusso(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lds_feedlimit(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' feed limit
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lds_dosalarm(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) = "0" And Mid(output_str(5), 1, 1) = "0" And Mid(output_str(11), 1, 1) = "0" Then ' dosing alarm
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lds_probefail(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' probe fail
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lds_level2(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) <> "0" Then ' probe fail
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    '---------------------------------------------------
    'end gestione allarmi LDS singolo
    '---------------------------------------------------


    '---------------------------------------------------
    'gestione allarmi LD4 
    '---------------------------------------------------
    Public Shared Function check_ld4_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_ld4_livello_ph(data)) Then
                alarm_ckeck_temp = True
            End If

            If alarm_ld4_livello_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_flusso(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_feedlimit_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_feedlimit_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_feedlimit_mV(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_feedlimit_ntu(data) Then
                alarm_ckeck_temp = True
            End If

            If alarm_ld4_dosalarm_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_dosalarm_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_probefail_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ld4_probefail_cl(data) Then
                alarm_ckeck_temp = True
            End If
        End If
        Return alarm_ckeck_temp
    End Function

    Public Shared Function alarm_ld4_livello_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld4_livello_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ld4_flusso(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld4_feedlimit_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' feed limit ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld4_feedlimit_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' feed limit cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ld4_feedlimit_mV(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' feed limit cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function alarm_ld4_feedlimit_ntu(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) = "0" Then ' dosing alarm cl
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld4_dosalarm_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(8), 1, 1) = "0" And Mid(output_str(10), 1, 1) = "0" And Mid(output_str(11), 1, 1) = "0" Then ' dosing alarm ph
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ld4_dosalarm_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(9), 1, 1) = "0" And Mid(output_str(10), 1, 1) = "0" And Mid(output_str(11), 1, 1) = "0" Then ' dosing alarm ph
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function alarm_ld4_probefail_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(10), 1, 1) <> "0" Then ' probe fail ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ld4_probefail_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(11), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    '---------------------------------------------------
    'end gestione allarmi LD4 
    '---------------------------------------------------



    '---------------------------------------------------
    'gestione allarmi WD 
    '---------------------------------------------------
    Public Shared Function check_wd_alarm(ByVal output_str As String, ByVal wd_or_wh As Boolean, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_wd_livello1_ph(data)) Then
                alarm_ckeck_temp = True
            End If
            If (alarm_wd_livello1_cl(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_wd_flusso(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_wd_dosalarm_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_wd_dosalarm_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_wd_probefail_ph(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_wd_probefail_cl(data) Then
                alarm_ckeck_temp = True
            End If
            If wd_or_wh Then
                If alarm_wh_filtro(data) Then
                    alarm_ckeck_temp = True
                End If

                If alarm_wh_sonde(data) Then
                    alarm_ckeck_temp = True
                End If

                If alarm_wh_manutenzione(data) Then
                    alarm_ckeck_temp = True
                End If

                If alarm_wh_assistenza(data) Then
                    alarm_ckeck_temp = True
                End If
            End If




        End If
        Return alarm_ckeck_temp
    End Function

    Public Shared Function alarm_wd_livello1_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_wd_livello1_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello1 cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_wd_flusso(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_wd_dosalarm_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' dos alarm ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_wd_dosalarm_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' dos alarm cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_wd_probefail_ph(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' probefail ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_wd_probefail_cl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function




    Public Shared Function alarm_wh_filtro(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(9), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_wh_sonde(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(10), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_wh_manutenzione(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(11), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_wh_assistenza(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(12), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function





    '---------------------------------------------------
    'end gestione allarmi WD
    '---------------------------------------------------


    '---------------------------------------------------
    'gestione allarmi LTB
    '---------------------------------------------------
    Public Shared Function check_ltb_alarm(ByVal output_str As String, ByVal release As Integer, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_ltb_tempo1(data)) Then
                alarm_ckeck_temp = True
            End If
            If (alarm_ltb_tempo2(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ltb_tempo3(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ltb_tempo4(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ltb_tempo5(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ltb_tempo6(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ltb_lev_hcl(data) Then
                alarm_ckeck_temp = True
            End If

            If alarm_ltb_lev_naclo2(data) Then
                alarm_ckeck_temp = True
            End If

            If alarm_ltb_lev_k6(data) Then
                alarm_ckeck_temp = True

            End If

            If release >= 125 Then
                If alarm_ltb_lev_diox(data) Then
                    alarm_ckeck_temp = True
                End If
            Else
                alarm_ckeck_temp = False

            End If


            If alarm_ltb_flow(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If






        End If
        Return alarm_ckeck_temp
    End Function

    Public Shared Function alarm_ltb_tempo1(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ltb_tempo2(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello1 cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ltb_tempo3(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ltb_tempo4(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' dos alarm ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ltb_tempo5(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' dos alarm cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ltb_tempo6(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' probefail ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ltb_lev_hcl(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function




    Public Shared Function alarm_ltb_lev_naclo2(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(8), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ltb_lev_k6(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(9), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ltb_lev_diox(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(13), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function alarm_ltb_flow(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(10), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function






    '---------------------------------------------------
    'end gestione allarmi LTB
    '---------------------------------------------------


    '---------------------------------------------------
    'gestione allarmi LTD LTU LTA
    '---------------------------------------------------


    '   1°	Flag.Lev_Acid,
    '2°	Flag.Lev_Full,
    '3°	Flag.Lev_Chlorite,
    '4°	Flag.Flow_Self_Water,	
    '5°	Flag.Lev_Water,
    '6°	Flag.Flow_Acid,
    '7°	Flag.Flow_Chlorite,
    '8°	Flag.Lev_Switch,
    '9°	Flag.Overflow,
    '10°	Flag.Flow_Self_Water2,
    '11°	Flag.Dioxide
    '12°	Flag.Bypass
    '13°	Alflow


    Public Shared Function check_lta_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0) As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_lta_lev_acido(data)) Then
                alarm_ckeck_temp = True
            End If
            If (alarm_lta_lev_full(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lta_lev_cloro(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lta_sefl_water(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lta_flow_acid(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lta_flow_cloro(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_lta_lev_switch(data) Then
                alarm_ckeck_temp = True
            End If

            If alarm_lta_lev_oveflow(data) Then
                alarm_ckeck_temp = True
            End If

            If alarm_lta_sefl_water2(data) Then
                alarm_ckeck_temp = True
            End If

            If alarm_lta_dioxide(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If

            If alarm_lta_bypass(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If

            If alarm_lta_alflow(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If

            If alarm_lta_soglia(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If

            If alarm_lta_generico(data) Then
                alarm_ckeck_temp = True
            End If

        End If
        Return alarm_ckeck_temp
    End Function






    Public Shared Function alarm_lta_lev_acido(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(1), 1, 1) <> "0" Then ' livello1 ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_lev_full(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(2), 1, 1) <> "0" Then ' livello1 cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function






    Public Shared Function alarm_lta_lev_cloro(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(3), 1, 1) <> "0" Then ' flusso
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_sefl_water(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(4), 1, 1) <> "0" Then ' dos alarm ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lta_flow_acid(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(5), 1, 1) <> "0" Then ' dos alarm cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function






    Public Shared Function alarm_lta_flow_cloro(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(6), 1, 1) <> "0" Then ' probefail ph
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_lta_lev_switch(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(7), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function




    Public Shared Function alarm_lta_lev_oveflow(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(8), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_sefl_water2(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(9), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_dioxide(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(10), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_bypass(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(11), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function alarm_lta_alflow(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(12), 1, 1) <> "0" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_soglia(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(14), 1, 1) = "1" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_lta_generico(ByVal output_str() As String) As Boolean
        Try
            If Mid(output_str(15), 1, 1) = "1" Then ' probe fail cl
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    '---------------------------------------------------
    'end gestione allarmi LTD LTA LTU
    '---------------------------------------------------



    '---------------------------------------------------
    'gestione allarmi TOWER
    '---------------------------------------------------
    Public Shared Function check_tower_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0, Optional ByVal configurazione_canali As String = "") As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_tower_bleed_timeout(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_flow(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_tower_high_conductivity(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_low_conductivity(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_level_prebiocide1(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_level_biocide1(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_level_prebiocide2(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_level_biocide2(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_level_inhibitor(data) Then
                alarm_ckeck_temp = True
            End If
            'nuova versione
            If alarm_tower_wmi(data, configurazione_canali, True) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_wmb(data, configurazione_canali, True) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_cf(data, configurazione_canali, True) Then
                alarm_ckeck_temp = True
            End If
            'end nuova versione
            'canale 2
            If alarm_tower_level_ch2(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_ch2_low(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_ch2_high(data) Then
                alarm_ckeck_temp = True
            End If
            'canale 3
            If alarm_tower_level_ch3(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_ch3_low(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_tower_ch3_high(data) Then
                alarm_ckeck_temp = True
            End If

        End If
        Return alarm_ckeck_temp
    End Function
    Public Shared Function alarm_tower_bleed_timeout(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 3, 1))) Then ' Bleed Timeout
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_flow(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 4, 1))) Then ' flow
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_high_conductivity(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 5, 1))) Then ' High Conductivity
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_low_conductivity(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 6, 1))) Then ' Low Conductivity
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_level_prebiocide1(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 7, 1))) Then ' Level prebiocide 1
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_level_biocide1(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 8, 1))) Then ' Level biocide 1
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_level_prebiocide2(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 9, 1))) Then ' Level prebiocide 2
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_level_biocide2(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 10, 1))) Then ' Level biocide 2
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_level_inhibitor(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 11, 1))) Then ' Level inhibitor
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_tower_level_ch2(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 12, 1))) Then ' Level ch2
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_ch2_low(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 13, 1))) Then 'CH2 low
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_ch2_high(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 14, 1))) Then 'CH2 High
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_level_ch3(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 15, 1))) Then ' Level ch3
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_ch3_low(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 16, 1))) Then 'CH3 low
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_ch3_high(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 17, 1))) Then 'CH3 High
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_wmi(ByVal output_str() As String, ByVal tower_type As String, ByVal new_version As Boolean) As Boolean
        Try
            If (tower_type = "Cdxxx") Then
                If new_version = True Then

                    If (Val(Mid(output_str(0), 12, 1))) Then  ' WMI
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
            If (tower_type = "Cd_pH") Or (tower_type = "Cd_rH") Or (tower_type = "Cd_Cl") Then
                If new_version = True Then
                    If (Val(Mid(output_str(0), 15, 1))) Then  ' WMI
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_wmb(ByVal output_str() As String, ByVal tower_type As String, ByVal new_version As Boolean) As Boolean
        Try
            If (tower_type = "Cdxxx") Then
                If new_version = True Then

                    If (Val(Mid(output_str(0), 13, 1))) Then  ' WMB
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
            If (tower_type = "Cd_pH") Or (tower_type = "Cd_rH") Or (tower_type = "Cd_Cl") Then
                If new_version = True Then
                    If (Val(Mid(output_str(0), 16, 1))) Then  ' WMB
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_tower_cf(ByVal output_str() As String, ByVal tower_type As String, ByVal new_version As Boolean) As Boolean
        Try
            If (tower_type = "Cdxxx") Then
                If new_version = True Then

                    If (Val(Mid(output_str(0), 14, 1))) Then  ' CF
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
            If (tower_type = "Cd_pH") Or (tower_type = "Cd_rH") Or (tower_type = "Cd_Cl") Then
                If new_version = True Then
                    If (Val(Mid(output_str(0), 17, 1))) Then  ' CF
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function tower_week_day(ByVal output_str() As String, ByVal tower_type As String, ByVal one_of_traduzione As String, _
                                          ByVal two_of_traduzione As String, ByVal three_of_traduzione As String, ByVal four_of_traduzione As String, _
                                          ByVal lunedi As String, ByVal martedi As String, ByVal mercoledi As String, ByVal giovedi As String, ByVal venerdi As String, _
                                          ByVal sabato As String, ByVal domenica As String, ByRef status_biocide As String) As String
        If (tower_type = "Cdxxx") Or (tower_type = "Cd_pH") Or (tower_type = "Cd_rH") Or (tower_type = "Cd_Cl") Then

            Select Case Val(Mid(output_str(0), 3, 2))
                Case 34 'Week One
                    status_biocide = one_of_traduzione + " " + Mid(output_str(0), 36, 2)
                Case 35 ' Week Two
                    status_biocide = two_of_traduzione + " " + Mid(output_str(0), 36, 2)
                Case 36 ' Week Three
                    status_biocide = three_of_traduzione + " " + Mid(output_str(0), 36, 2)
                Case 37 ' Week Four
                    status_biocide = four_of_traduzione + " " + Mid(output_str(0), 36, 2)
            End Select
        End If
        If (tower_type = "Cd_pH_rH") Or (tower_type = "Cd_pH_Cl") Or (tower_type = "Cd_trc_Cl") Or (tower_type = "Cd_trc_rH") Then

            Select Case Val(Mid(output_str(0), 3, 2))
                Case 34 'Week One
                    status_biocide = one_of_traduzione + " " + Mid(output_str(0), 44, 2)
                Case 35 ' Week Two
                    status_biocide = two_of_traduzione + " " + Mid(output_str(0), 44, 2)
                Case 36 ' Week Three
                    status_biocide = three_of_traduzione + " " + Mid(output_str(0), 44, 2)
                Case 37 ' Week Four
                    status_biocide = four_of_traduzione + " " + Mid(output_str(0), 44, 2)
            End Select

        End If
        Select Case Val(Mid(output_str(0), 5, 2))
            Case 38 ' Monday
                Return lunedi
            Case 39 ' Tuesday
                Return martedi
            Case 40 ' Wednesday
                Return mercoledi
            Case 41 'Thursday
                Return giovedi
            Case 42 ' Friday
                Return venerdi
            Case 43 ' Saturday
                Return sabato
            Case 44 ' Sunday
                Return domenica
        End Select
    End Function

    '---------------------------------------------------
    'end gestione allarmi TOWER
    '---------------------------------------------------




    '---------------------------------------------------
    'gestione allarmi LDTOWER
    '---------------------------------------------------
    Public Shared Function check_ldtower_alarm(ByVal output_str As String, Optional ByRef contatore_strumenti_flusso As Integer = 0, Optional ByVal configurazione_canali As String = "") As Boolean
        Dim data() As String = get_split_str(output_str)
        Dim alarm_ckeck_temp As Boolean = False
        If data Is Nothing Then
        Else
            If (alarm_tower_bleed_timeout(data)) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ldtower_flow(data) Then
                contatore_strumenti_flusso = contatore_strumenti_flusso + 1
                alarm_ckeck_temp = True
            End If
            If alarm_ldtower_high_conductivity(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ldtower_low_conductivity(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ldtower_level_biocide1(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ldtower_level_biocide2(data) Then
                alarm_ckeck_temp = True
            End If
            If alarm_ldtower_level_inhibitor(data) Then
                alarm_ckeck_temp = True
            End If
           
        End If
        Return alarm_ckeck_temp
    End Function
    Public Shared Function alarm_ldtower_bleed_timeout(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 3, 1))) Then ' Bleed Timeout
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ldtower_flow(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 4, 1))) Then ' flow
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ldtower_high_conductivity(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 5, 1))) Then ' High Conductivity
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ldtower_low_conductivity(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 6, 1))) Then ' Low Conductivity
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function alarm_ldtower_level_biocide1(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 7, 1))) Then ' Level biocide 1
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
 
    Public Shared Function alarm_ldtower_level_biocide2(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 8, 1))) Then ' Level biocide 2
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function alarm_ldtower_level_inhibitor(ByVal output_str() As String) As Boolean
        Try
            If (Val(Mid(output_str(0), 9, 1))) Then ' Level inhibitor
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

 
    
    Public Shared Function ldtower_week_day(ByVal biocide_stat() As String, ByVal lunedi As String, ByVal martedi As String, ByVal mercoledi As String, ByVal giovedi As String, _
                                            ByVal venerdi As String, ByVal sabato As String, ByVal domenica As String) As String

        Dim variabile As String

        variabile = Mid(biocide_stat(0), 3, 2)


        Select Case Val(Mid(biocide_stat(0), 3, 2))
            Case 38 ' Monday
                Return lunedi
            Case 39 ' Tuesday
                Return martedi
            Case 40 ' Wednesday
                Return mercoledi
            Case 41 'Thursday
                Return giovedi
            Case 42 ' Friday
                Return venerdi
            Case 43 ' Saturday
                Return sabato
            Case 44 ' Sunday
                Return domenica
        End Select
    End Function

    '---------------------------------------------------
    'end gestione allarmi LDTOWER
    '---------------------------------------------------



    '---------------------------------------------------
    'SEND Mail
    '---------------------------------------------------
    Public Shared Function send_mail(ByVal send_to As String, ByVal email_oggetto As String,
                                     ByVal email_body As String, ByVal send_webmaster As Boolean, Optional ByVal oggetto_web_master As String = "",
                                     Optional ByVal body_web_master As String = "")
        Dim client As New System.Net.Mail.SmtpClient("smtp-mail.outlook.com")
        Dim temp_str As String = ""
        Dim oMessage As New System.Net.Mail.MailMessage()
        client.UseDefaultCredentials = False
        client.Credentials = New Net.NetworkCredential("ermes@ermes-server.com", "Erm,2019-1")
        oMessage.From = New System.Net.Mail.MailAddress("ermes@ermes-server.com")


        oMessage.To.Add(New System.Net.Mail.MailAddress(send_to))
        oMessage.Subject = email_oggetto
        oMessage.Body = email_body

        client.EnableSsl = True

        client.Send(oMessage)
        If send_webmaster Then
            Dim oMessage1 As New System.Net.Mail.MailMessage()
            oMessage1.From = New System.Net.Mail.MailAddress("ermes@ermes-server.com")
            oMessage1.To.Add(New System.Net.Mail.MailAddress("alvaro.patacchiola@emec.it"))
            oMessage1.CC.Add(New System.Net.Mail.MailAddress("andrea.manetta@emec.it"))
            oMessage1.CC.Add(New System.Net.Mail.MailAddress("gianluca.pasquali@emec.it"))
            oMessage1.CC.Add(New System.Net.Mail.MailAddress("alessandro.rinaldi@emec.it"))
            oMessage1.CC.Add(New System.Net.Mail.MailAddress("daniele.leonetti@emec.it"))
            oMessage1.Subject = oggetto_web_master
            oMessage1.Body = body_web_master
            client.EnableSsl = True
            client.Send(oMessage1)
        End If





    End Function
    Public Shared Function checkUserAdmin(ByVal idUserList As String, ByVal idUser As String, ByVal idCheckList As String) As Boolean
        Dim idUserListSplit() As String = idUserList.Split(",")
        Dim indice As Integer = 0
        For Each idUserTemp As String In idUserListSplit

            If InStr(idUserTemp, idUser) > 0 Then
                Exit For
            End If
            indice = indice + 1
        Next
        Dim idCheckListSplit() As String = idCheckList.Split(",")

        If (idCheckListSplit(indice)) = "True" Then
            Return True
        End If
        Return False
    End Function
End Class
