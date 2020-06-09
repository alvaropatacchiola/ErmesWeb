Public Class jsonConvertvb
    Public Function jsonStrumentiConnessi(ByVal serialNumber As String) As String
        Dim stringJson As String = "{"
        If (serialNumber.Length >= 17) Then
            stringJson = stringJson + """count"":""1"""
        Else
            Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
            Dim query As New query
            Dim countConnected As Integer = 0
            tabella_strumento = query.get_strumenti_codice_list(serialNumber)
            For Each dc1 In tabella_strumento
                Dim check_connected As Boolean = False
                check_connected = main_function.check_is_connected(dc1.data_aggiornamento)
                If check_connected Then
                    countConnected = countConnected + 1
                End If
            Next
            stringJson = stringJson + """count"":""" + countConnected.ToString + """"
        End If
        stringJson = stringJson + "}"
        Return stringJson

    End Function

    Public Function jsonResultGlobal(ByVal serialNumber As String, ByVal type As String, ByVal user As String, ByVal password As String, ByVal id_485_impianto As String) As String
        Dim query As New query
        Dim stringJson As String = "{"
        Dim labelList As String = ""
        If query.getJSONEnable(user, password, serialNumber, labelList) Then

            If (serialNumber.Length >= 17) Then
                If type = "real" Then ' letture e stato
                    Dim pipeClient As New centurioRealTime
                    Dim resultPipe As String = ""

                    resultPipe = pipeClient.Main(serialNumber, "")
                    If resultPipe <> "null" And resultPipe <> "" Then
                        Dim pipeSplit() As String = resultPipe.Split("$")

                        stringJson = stringJson + """error"":""ok"",""variable"":["
                        '{""chiave"":""Empty"", ""valore"":}"
                        Dim virgola As String = ""
                        For Each pipeValue In pipeSplit
                            If pipeValue.IndexOf(":") > 0 Then
                                Dim pipeValueSplit() As String = pipeValue.Split(":")
                                If pipeValueSplit(0).IndexOf(">") < 0 Then
                                    stringJson = stringJson + virgola + "{""chiave"":""" + pipeValueSplit(0) + """, ""valore"":""" + pipeValueSplit(1) + """}"
                                    virgola = ","
                                End If
                            End If
                        Next
                        stringJson = stringJson + "],""labelAlarm"":""" + labelList + """}"
                    Else
                        stringJson = stringJson + """error"":""invalidSerial""}"
                    End If
                End If
                If type = "all" Then ' letture e stato
                    Dim resultPipe As String = ""
                    Dim stringChange As String = ""
                    Dim pipeClient As New centurioRealTime
                    resultPipe = pipeClient.Main(serialNumber, "")
                    If resultPipe <> "null" And resultPipe <> "" Then
                        Dim pipeSplit() As String = resultPipe.Split("$")

                        stringJson = stringJson + """error"":""ok"",changejs""variable"":["
                        '{""chiave"":""Empty"", ""valore"":}"
                        Dim virgola As String = ""
                        For Each pipeValue In pipeSplit
                            If pipeValue.IndexOf(":") > 0 Then
                                Dim pipeValueSplit() As String = pipeValue.Split(":")
                                'If pipeValueSplit(0).IndexOf(">") < 0 Then
                                stringJson = stringJson + virgola + "{""chiave"":""" + pipeValueSplit(0).Replace(">", "_") + """, ""valore"":""" + pipeValueSplit(1) + """}"
                                If (pipeValueSplit(0) = "change") Then
                                    stringChange = """change"":""" + pipeValueSplit(1) + ""","
                                End If
                                virgola = ","
                                'End If
                            End If
                        Next
                        stringJson = stringJson + "],""labelAlarm"":""" + labelList + """}"
                    Else

                        Dim resultPipeData As String = ""

                        Dim strinxXML As String = query.getConfigGlobal(1)
                        resultPipeData = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 4)
                        If resultPipeData <> "" Then
                            stringJson = stringJson + """error"":""disconnected"", ""change"":""0"" ,""variable"":["
                            stringJson = stringJson + resultPipeData + "],""labelAlarm"":""" + labelList + """}"
                        Else
                            stringJson = stringJson + """error"":""invalidSerial""}"
                        End If



                    End If
                    stringJson = stringJson.Replace("changejs", stringChange)
                End If

            Else
                'stringJson = stringJson + """errore"":""invalidSerial""}"
                Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
                stringJson = stringJson + getJsonLD(serialNumber, id_485_impianto, riga_strumento)
                If type = "real" Then ' letture e stato
                Else
                    stringJson = stringJson + getJsonLDSettings(serialNumber, riga_strumento)
                End If
                stringJson = stringJson + "],""labelAlarm"":""" + labelList + """}"
            End If
        Else
            stringJson = stringJson + """error"":""invalid""}"
        End If

        Return stringJson
    End Function
    Public Function getJsonLDSettings(ByVal codice As String, ByVal riga_strumento As ermes_web_20.quey_db.strumentiRow) As String
        Dim data_sp() As String
        Dim calibrz_value() As String

        data_sp = main_function.get_split_str(riga_strumento.value7)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        Dim ch1_pulse1_mode As String = Mid(data_sp(6), 1, 1) ' 0-> on/off 1-> prop 2-> OFF
        Dim ch1_relay_mode As String = Mid(data_sp(11), 1, 1) ' 0-> prop PWM  1-> on/off 2-> Fixed PWM 3-> OFF
        Dim ch1_pulse2_mode As String = Mid(data_sp(17), 1, 1) ' 0-> on/off 1-> prop 2-> OFF
        Dim ch2_pulse_mode As String = Mid(data_sp(23), 1, 1) ' 0-> on/off 1-> prop 2-> OFF
        Dim ch2_relay_mode As String = Mid(data_sp(28), 1, 1) ' 0-> prop PWM 
        Dim stringJson As String = ""
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_temp2 As Integer = 0
        Dim etichetta_setpoint As String = ""
        Dim etichetta_setpoint2 As String = ""
        Dim minmax_value() As String




        Select Case ch1_pulse1_mode
            Case "2" 'off
                stringJson = stringJson + ",{""key"":""ch1Pulse1Mode"", ""value"":""DIS""}"
            Case "0" 'on/off
                stringJson = stringJson + ",{""key"":""ch1Pulse1Mode"", ""value"":""ON/OFF""}"
            Case "1" 'proportianal
                stringJson = stringJson + ",{""key"":""ch1Pulse1Mode"", ""value"":""Proportional""}"
        End Select

        Select Case ch1_pulse2_mode
            Case "2" 'off
                stringJson = stringJson + ",{""key"":""ch1Pulse2Mode"", ""value"":""DIS""}"
            Case "0" 'on/off
                stringJson = stringJson + ",{""key"":""ch1Pulse2Mode"", ""value"":""ON/OFF""}"
            Case "1" 'proportianal
                stringJson = stringJson + ",{""key"":""ch1Pulse2Mode"", ""value"":""Proportional""}"
        End Select
        Select Case ch2_pulse_mode
            Case "2" 'off
                stringJson = stringJson + ",{""key"":""ch2Pulse1Mode"", ""value"":""Dis""}"
            Case "0" 'on/off
                stringJson = stringJson + ",{""key"":""ch2Pulse1Mode"", ""value"":""ON/OFF""}"
            Case "1" 'proportianal
                stringJson = stringJson + ",{""key"":""ch2Pulse1Mode"", ""value"":""Proportional""}"
        End Select
        Select Case ch1_relay_mode
            Case "3" 'off
                stringJson = stringJson + ",{""key"":""ch1RelayMode"", ""value"":""DIS""}"
            Case "0" 'proportional pwm
                stringJson = stringJson + ",{""key"":""ch1RelayMode"", ""value"":""PWM""}"
            Case "1" 'on/off
                stringJson = stringJson + ",{""key"":""ch1RelayMode"", ""value"":""ON/OFF""}"
            Case "2" 'fixedf
                stringJson = stringJson + ",{""key"":""ch1RelayMode"", ""value"":""Fixed""}"
        End Select
        Select Case ch2_relay_mode
            Case "3" 'off
                stringJson = stringJson + ",{""key"":""ch2RelayMode"", ""value"":""DIS""}"
            Case "0" 'proportional pwm
                stringJson = stringJson + ",{""key"":""ch2RelayMode"", ""value"":""PWM""}"
            Case "1" 'on/off
                stringJson = stringJson + ",{""key"":""ch2RelayMode"", ""value"":""ON/OFF""}"
            Case "2" 'fixed
                stringJson = stringJson + ",{""key"":""ch2RelayMode"", ""value"":""Fixed""}"
        End Select

        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, , , etichetta_setpoint)
        main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp2, , , etichetta_setpoint2)

        Dim temp_calc As Single = Val(Mid(data_sp(1), 1, 4)) / fattore_divisione_temp 'on
        stringJson = stringJson + ",{""key"":""ch1Pulse1Val1"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"


        temp_calc = Val(Mid(data_sp(2), 1, 4)) / fattore_divisione_temp 'on
        stringJson = stringJson + ",{""key"":""ch1Pulse1Val2"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"


        temp_calc = Val(Mid(data_sp(12), 1, 4)) / fattore_divisione_temp 'on
        stringJson = stringJson + ",{""key"":""ch1Pulse2Val1"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

        temp_calc = Val(Mid(data_sp(13), 1, 4)) / fattore_divisione_temp 'on
        stringJson = stringJson + ",{""key"":""ch1Pulse2Val2"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

        temp_calc = Val(Mid(data_sp(7), 1, 4)) / fattore_divisione_temp 'on
        stringJson = stringJson + ",{""key"":""ch1RelayVal1"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"
        temp_calc = Val(Mid(data_sp(8), 1, 4)) / fattore_divisione_temp 'on
        stringJson = stringJson + ",{""key"":""ch1RelayVal2"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

        temp_calc = Val(Mid(data_sp(18), 1, 4)) / fattore_divisione_temp2 'on
        stringJson = stringJson + ",{""key"":""ch2Pulse1Val1"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

        temp_calc = Val(Mid(data_sp(19), 1, 4)) / fattore_divisione_temp2 'on
        stringJson = stringJson + ",{""key"":""ch2Pulse1Val2"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

        temp_calc = Val(Mid(data_sp(24), 1, 4)) / fattore_divisione_temp2 'on
        stringJson = stringJson + ",{""key"":""ch2RelayVal1"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"
        temp_calc = Val(Mid(data_sp(25), 1, 4)) / fattore_divisione_temp2 'on
        stringJson = stringJson + ",{""key"":""ch2RelayVal2"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"


        stringJson = stringJson + ",{""key"":""ch1Pulse1Val1Pulse"", ""value"":""" + Format(Val(Mid(data_sp(3), 1, 3)), "000") + """}"
        stringJson = stringJson + ",{""key"":""ch1Pulse1Val2Pulse"", ""value"":""" + Format(Val(Mid(data_sp(4), 1, 3)), "000") + """}"

        stringJson = stringJson + ",{""key"":""ch1Pulse2Val1Pulse"", ""value"":""" + Format(Val(Mid(data_sp(14), 1, 3)), "000") + """}"
        stringJson = stringJson + ",{""key"":""ch1Pulse2Val2Pulse"", ""value"":""" + Format(Val(Mid(data_sp(15), 1, 3)), "000") + """}"

        stringJson = stringJson + ",{""key"":""ch1RelayVal1Pulse"", ""value"":""" + Format(Val(Mid(data_sp(9), 1, 3)), "000") + """}"
        stringJson = stringJson + ",{""key"":""ch1RelayVal2Pulse"", ""value"":""" + Format(Val(Mid(data_sp(10), 1, 3)), "000") + """}"

        stringJson = stringJson + ",{""key"":""ch2Pulse1Val1Pulse"", ""value"":""" + Format(Val(Mid(data_sp(20), 1, 3)), "000") + """}"
        stringJson = stringJson + ",{""key"":""ch2Pulse1Val2Pulse"", ""value"":""" + Format(Val(Mid(data_sp(21), 1, 3)), "000") + """}"

        stringJson = stringJson + ",{""key"":""ch2RelayVal1Pulse"", ""value"":""" + Format(Val(Mid(data_sp(26), 1, 3)), "000") + """}"
        stringJson = stringJson + ",{""key"":""ch2RelayVal2Pulse"", ""value"":""" + Format(Val(Mid(data_sp(27), 1, 3)), "000") + """}"
        Dim mode_ch1_H As String
        Dim mode_ch1_L As String

        Dim mode_ch2_H As String
        Dim mode_ch2_L As String

        Dim value_ch1_H As String
        Dim value_ch1_L As String

        Dim value_ch2_H As String
        Dim value_ch2_L As String
        Dim dose_stop_ch1 As String
        Dim dose_stop_ch2 As String

        Dim time_ch1 As String
        Dim time_ch2 As String

        Try

            minmax_value = main_function.get_split_str(riga_strumento.value16)
            mode_ch1_H = Mid(minmax_value(1), 1, 1)
            mode_ch1_L = Mid(minmax_value(3), 1, 1)
            mode_ch2_H = Mid(minmax_value(7), 1, 1)
            mode_ch2_L = Mid(minmax_value(9), 1, 1)
            If mode_ch1_H = "0" Then ' dis
                stringJson = stringJson + ",{""key"":""ch1AlarmHigh"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch1AlarmHigh"", ""value"":""EN""}"
            End If
            If mode_ch1_L = "0" Then 'dis
                stringJson = stringJson + ",{""key"":""ch1AlarmLow"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch1AlarmLow"", ""value"":""EN""}"
            End If


            If mode_ch2_H = "0" Then 'dis
                stringJson = stringJson + ",{""key"":""ch2AlarmHigh"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch2AlarmHigh"", ""value"":""EN""}"
            End If
            If mode_ch2_L = "0" Then 'dis
                stringJson = stringJson + ",{""key"":""ch2AlarmLow"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch2AlarmLow"", ""value"":""EN""}"
            End If


            value_ch1_H = Mid(minmax_value(2), 1, 4)
            value_ch1_L = Mid(minmax_value(4), 1, 4)
            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(1), 1, 2), fattore_divisione_temp, , , etichetta_setpoint)
            temp_calc = Val(value_ch1_H) / fattore_divisione_temp 'on
            stringJson = stringJson + ",{""key"":""ch1AlarmHighValue"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

            temp_calc = Val(value_ch1_L) / fattore_divisione_temp 'on
            stringJson = stringJson + ",{""key"":""ch1AlarmLowValue"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"

            main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(2), 1, 2), fattore_divisione_temp, , , etichetta_setpoint)
            value_ch2_H = Mid(minmax_value(8), 1, 4)
            value_ch2_L = Mid(minmax_value(10), 1, 4)
            temp_calc = Val(value_ch2_H) / fattore_divisione_temp 'on
            stringJson = stringJson + ",{""key"":""ch2AlarmHighValue"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"
            temp_calc = Val(value_ch2_L) / fattore_divisione_temp 'on
            stringJson = stringJson + ",{""key"":""ch2AlarmLowValue"", ""value"":""" + Replace(temp_calc.ToString(), ",", ".") + """}"
        Catch ex As Exception

        End Try

        'dose_stop_ch1 = Mid(minmax_value(5), 1, 1)
        'dose_stop_ch2 = Mid(minmax_value(11), 1, 1)
        'time_ch1 = Mid(minmax_value(6), 1, 2)
        'time_ch2 = Mid(minmax_value(12), 1, 2)
        'stringJson = stringJson + ",{""key"":""ch1AlarmDoseTime"", ""value"":""" + Val(time_ch1).ToString + """}"
        'stringJson = stringJson + ",{""key"":""ch2AlarmDoseTime"", ""value"":""" + Val(time_ch2).ToString + """}"
        Try

            Dim probefail_value() As String

            probefail_value = main_function.get_split_str(riga_strumento.value10)
            Dim probe_modeph As String
            Dim probe_modecl As String
            Dim probe_timeph As String
            Dim probe_timecl As String

            probe_modeph = Mid(probefail_value(1), 1, 1)
            probe_timeph = Mid(probefail_value(2), 1, 3)
            probe_modecl = Mid(probefail_value(3), 1, 1)
            probe_timecl = Mid(probefail_value(4), 1, 3)

            stringJson = stringJson + ",{""key"":""ch1AlarmProbeTime"", ""value"":""" + Val(probe_timeph).ToString + """}"
            stringJson = stringJson + ",{""key"":""ch2AlarmProbeTime"", ""value"":""" + Val(probe_timecl).ToString + """}"


            If probe_timeph = "000" Then ' vuol dire OFF
                stringJson = stringJson + ",{""key"":""ch1AlarmProbe"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch1AlarmProbe"", ""value"":""EN""}"
            End If



            If probe_timecl = "000" Then ' vuol dire OFF" Then
                stringJson = stringJson + ",{""key"":""ch2AlarmProbe"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch2AlarmProbe"", ""value"":""EN""}"
            End If
        Catch ex As Exception

        End Try

        Try
            Dim dosing_value() As String
            dosing_value = main_function.get_split_str(riga_strumento.value9)
            Dim dosing_modeph As String
            Dim dosing_modecl As String
            Dim dosing_timeph As String
            Dim dosing_timecl As String


            dosing_modeph = Mid(dosing_value(1), 1, 1)
            dosing_timeph = Mid(dosing_value(2), 1, 3)
            dosing_modecl = Mid(dosing_value(3), 1, 1)
            dosing_timecl = Mid(dosing_value(4), 1, 3)

            stringJson = stringJson + ",{""key"":""ch1AlarmDosingTime"", ""value"":""" + Val(dosing_timeph).ToString + """}"
            stringJson = stringJson + ",{""key"":""ch2AlarmDosingTime"", ""value"":""" + Val(dosing_timecl).ToString + """}"


            If dosing_timeph = "000" Then ' vuol dire OFF
                stringJson = stringJson + ",{""key"":""ch1AlarmDosing"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch1AlarmDosing"", ""value"":""EN""}"
            End If
            If dosing_timecl = "000" Then ' vuol dire OFF" Then
                stringJson = stringJson + ",{""key"":""ch2AlarmDosing"", ""value"":""DIS""}"
            Else
                stringJson = stringJson + ",{""key"":""ch2AlarmDosing"", ""value"":""EN""}"
            End If

        Catch ex As Exception

        End Try

        Try
            Dim log_value() As String
            log_value = main_function.get_split_str(riga_strumento.value15)

            Dim enable As String
            Dim time_h As String
            Dim time_m As String
            Dim time_am As String
            Dim time_pm As String
            Dim every_h As String
            Dim every_m As String


            enable = Mid(log_value(1), 1, 1)
            time_h = Mid(log_value(2), 1, 2)
            time_m = Mid(log_value(3), 1, 2)
            time_am = Mid(log_value(6), 1, 1)
            time_pm = Mid(log_value(7), 1, 1)
            every_h = Mid(log_value(4), 1, 2)
            every_m = Mid(log_value(5), 1, 2)

            If enable = "0" Then 'disable
                stringJson = stringJson + ",{""key"":""log"", ""value"":""DIS""}"
            End If
            If enable = "1" Then 'enable
                stringJson = stringJson + ",{""key"":""log"", ""value"":""EN""}"
            End If
            stringJson = stringJson + ",{""key"":""logTime24"", ""value"":""" + time_h + ":" + time_m + """}"

            If time_am = "1" And time_pm = "0" Then
                stringJson = stringJson + ",{""key"":""logTime12"", ""value"":""" + time_h + ":" + time_m + " am" + """}"

            End If
            If time_am = "0" And time_pm = "1" Then
                stringJson = stringJson + ",{""key"":""logTime12"", ""value"":""" + time_h + ":" + time_m + " pm" + """}"
            End If

            stringJson = stringJson + ",{""key"":""logTimeEveryHours"", ""value"":""" + every_h + """}"
            stringJson = stringJson + ",{""key"":""logTimeEveryMinutesr"", ""value"":""" + every_m + """}"

            Dim flow_value() As String
            flow_value = main_function.get_split_str(riga_strumento.value11)
            Dim mode_flow As String
            Dim time_flow As String

            mode_flow = Mid(flow_value(1), 1, 1)
            time_flow = Mid(flow_value(2), 1, 2)


            If mode_flow = "0" Then 'disable
                stringJson = stringJson + ",{""key"":""flow"", ""value"":""DIS""}"
            End If
            If mode_flow = "1" Then 'reverse
                stringJson = stringJson + ",{""key"":""flow"", ""value"":""Reverse""}"

            End If
            If mode_flow = "2" Then 'direct
                stringJson = stringJson + ",{""key"":""flow"", ""value"":""Deirect""}"
            End If

            stringJson = stringJson + ",{""key"":""flowDelay"", ""value"":""" + Val(time_flow).ToString + """}"
        Catch ex As Exception

        End Try

        Return stringJson
    End Function

    Public Function getJsonLD(ByVal codice As String, ByVal id_485_impianto As String, ByRef riga_strumento As ermes_web_20.quey_db.strumentiRow) As String
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        Dim query As New query
        ' Dim riga_strumento As ermes_web_20.quey_db.strumentiRow
        Dim calibrz_value() As String
        Dim valuer_value() As String
        Dim config_value() As String
        Dim allrmr_value() As String
        Dim outputr_value() As String
        Dim clockr_value() As String
        Dim check_connected As Boolean = False
        Dim time_connected As Long
        Dim stringJson As String = ""
        Dim nome_strumento() As String
        Dim numero_canali As Integer = 0
        Dim contatore_canale As Integer = 0
        Dim fattore_divisione_temp As Integer = 0
        Dim label_canale_temp As String = ""
        Dim valore_canale_temp As Single = 0
        Dim formato_d As String
        Dim temperature_value As Single = 0
        Dim numero_strumento As Integer = 0

        Dim unit_value() As String
        Dim international_unit As String = ""
        Dim measure_unit As String = ""
        Dim personalizzazione_aquacare As Integer
        Dim version_str As String = ""
        Dim MTower_Type As String = ""
        Dim scala_temp As Integer = 0

        If id_485_impianto IsNot Nothing Then
            tabella_strumento = query.get_strumenti_codice(codice, id_485_impianto)
        Else
            tabella_strumento = query.get_strumenti_codice(codice)
        End If

        For Each dc1 In tabella_strumento
            If dc1.codice = codice Then
                riga_strumento = dc1
            End If
        Next

        check_connected = main_function.check_is_connected(riga_strumento.data_aggiornamento, time_connected)

        config_value = main_function.get_split_str(riga_strumento.value1)
        calibrz_value = main_function.get_split_str(riga_strumento.value4)
        valuer_value = main_function.get_split_str(riga_strumento.value2)
        allrmr_value = main_function.get_split_str(riga_strumento.value3)
        outputr_value = main_function.get_split_str(riga_strumento.value5)
        clockr_value = main_function.get_split_str(riga_strumento.value6)
        nome_strumento = main_function.get_split_str(riga_strumento.nome)

        If (check_connected) Then
            stringJson = stringJson + """error"":""ok"", ""status"":""connected"" , ""lastUpdateMin"":""" + time_connected.ToString + """"
        Else
            stringJson = stringJson + """error"":""ok"", ""status"":""notconnected"" , ""lastUpdateMin"":""0"""
        End If

        stringJson = stringJson + ",""variable"":["
        Select Case riga_strumento.tipo_strumento
            Case "WD"
                numero_canali = 2
                formato_d = Mid(valuer_value(4), 1, 1)

            Case "LD"
                If Mid(config_value(3), 3, 3) <> "306" Then ' terzo canale esistente
                    numero_canali = 3
                Else
                    numero_canali = 2
                End If

                If InStr(nome_strumento(2), "LDDT") <> 0 Then
                    numero_canali = 2
                    numero_strumento = 1
                End If
                formato_d = Mid(valuer_value(4), 1, 1)


            Case "LDS"
                numero_canali = 1
                formato_d = Mid(valuer_value(3), 1, 1)
            Case "LD4"
                numero_canali = 4
                formato_d = Mid(valuer_value(6), 1, 1)
            Case "LDDT"
                formato_d = Mid(valuer_value(4), 1, 1)
                numero_canali = 2
            Case "Tower"
                unit_value = main_function.get_split_str(riga_strumento.value1)
                main_function_config.get_tower_unit(unit_value, international_unit, measure_unit)
                config_value = main_function.get_split_str(riga_strumento.value4)
                MTower_Type = main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str)

        End Select
        If (riga_strumento.tipo_strumento = "LD") Or (riga_strumento.tipo_strumento = "LDS") Or (riga_strumento.tipo_strumento = "WD") Or (riga_strumento.tipo_strumento = "LD4") Or (riga_strumento.tipo_strumento = "LDDT") Then
            For i = 1 To numero_canali 'ld può essere duo o tre canali
                contatore_canale = contatore_canale + 1
                If calibrz_value(i).Length > 2 Then
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 3), fattore_divisione_temp)
                Else
                    label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(calibrz_value(i), 1, 2), fattore_divisione_temp)
                End If

                If i = 3 And numero_canali = 3 Then
                    valore_canale_temp = Val(Mid(valuer_value(5), 1, 4)) / fattore_divisione_temp
                Else
                    valore_canale_temp = Val(Mid(valuer_value(i), 1, 4)) / fattore_divisione_temp
                End If
                stringJson = stringJson + crea_canale(contatore_canale, label_canale_temp, valore_canale_temp.ToString, allrmr_value,
                                                          riga_strumento.tipo_strumento, outputr_value)

            Next
            Dim ora As String
            Dim app_am As Integer

            ora = Mid(clockr_value(4), 1, 2) + ":" + Mid(clockr_value(5), 1, 2)
            If formato_d = "1" Then ' americano
                app_am = Val(Mid(clockr_value(6), 1, 1))

                If app_am = 1 Then
                    ora = ora + " am"
                Else
                    app_am = Val(Mid(clockr_value(7), 1, 1))
                    If app_am = 1 Then
                        ora = ora + " pm"

                    End If
                End If

            End If
            Dim num_versione As Integer = Val(main_function.get_version(riga_strumento.nome))
            stringJson = stringJson + ",{""key"":""dateTime"", ""value"":""" + Mid(clockr_value(1), 1, 2) + "-" + Mid(clockr_value(2), 1, 2) + "-" + Mid(clockr_value(3), 1, 2) + " " + ora + """}"
            If formato_d = "0" Then ' europeo
                Select Case riga_strumento.tipo_strumento
                    Case "LD"
                        temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                    Case "LDDT"
                        temperature_value = (Val(Mid(valuer_value(3), 1, 3)) / 10)
                    Case "LDS"
                        temperature_value = (Val(Mid(valuer_value(2), 1, 3)) / 10)
                    Case "LD4"
                        temperature_value = (Val(Mid(valuer_value(5), 1, 3)) / 10)
                End Select
                stringJson = stringJson + ",{""key"":""temperature"", ""value"":""" + temperature_value.ToString + "°C""}"
            End If
            If formato_d = "1" Then ' americano
                Select Case riga_strumento.tipo_strumento
                    Case "LD"
                        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
                    Case "LDDT"
                        temperature_value = (Val(Mid(valuer_value(3), 1, 3)))
                    Case "LDS"
                        temperature_value = (Val(Mid(valuer_value(2), 1, 3)))
                    Case "LD4"
                        temperature_value = (Val(Mid(valuer_value(5), 1, 3)))
                End Select
                stringJson = stringJson + ",{""key"":""temperature"", ""value"":""" + temperature_value.ToString + "°F""}"
            End If
            Select Case riga_strumento.tipo_strumento
                Case "LD4"
                    Dim m3h_valore As Single = 0
                    m3h_valore = Val(valuer_value(7)) / 100
                    If formato_d = "1" Then ' americano
                        stringJson = stringJson + ",{""key"":""flowMeter"", ""value"":""" + (m3h_valore / 10).ToString + "G/h""}"
                    Else
                        stringJson = stringJson + ",{""key"":""flowMeter"", ""value"":""" + (m3h_valore / 10).ToString + "m3/h""}"
                    End If
                    stringJson = stringJson + ",{""key"":""totalizer"", ""value"":""" + valuer_value(8) + """}"
                Case "WD"
                    If main_function.alarm_wd_flusso(allrmr_value) Then
                        stringJson = stringJson + ",{""key"":""flowAlarm"", ""value"":""ON""}"
                    Else
                        stringJson = stringJson + ",{""key"":""flowAlarm"", ""value"":""OFF""}"
                    End If

                Case "LD"
                    'Dim m3h_valore As Single = 0
                    'm3h_valore = Val(valuer_value(5)) / 100
                    If num_versione < 800 Then
                    Else
                        If formato_d = "1" Then ' americano
                            stringJson = stringJson + ",{""key"":""flowMeter"", ""value"":""" + valuer_value(6).ToString + "G/h""}"
                        Else
                            stringJson = stringJson + ",{""key"":""flowMeter"", ""value"":""" + valuer_value(6).ToString + "m3/h""}"
                        End If
                        stringJson = stringJson + ",{""key"":""totalizer"", ""value"":""" + valuer_value(7) + """}"
                    End If
                    If main_function.alarm_ld_flusso(allrmr_value) Then
                        stringJson = stringJson + ",{""key"":""flowAlarm"", ""value"":""ON""}"
                    Else
                        stringJson = stringJson + ",{""key"":""flowAlarm"", ""value"":""OFF""}"
                    End If

                Case "LDS"
                    If num_versione < 430 Then
                        If formato_d = "1" Then ' americano
                            stringJson = stringJson + ",{""key"":""flowMeter"", ""value"":""" + valuer_value(5).ToString + "G/h""}"
                        Else
                            stringJson = stringJson + ",{""key"":""flowMeter"", ""value"":""" + valuer_value(5).ToString + "m3/h""}"
                        End If
                        stringJson = stringJson + ",{""key"":""totalizer"", ""value"":""" + valuer_value(6) + """}"
                        If main_function.alarm_lds_flusso(allrmr_value) Then
                            stringJson = stringJson + ",{""key"":""flowAlarm"", ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""flowAlarm"", ""value"":""OFF""}"
                        End If
                    Else
                    End If


            End Select
        End If
        If (riga_strumento.tipo_strumento = "Tower") Then
            numero_canali = MTower_Type.Split("_").Length
            valuer_value = main_function.get_split_str(riga_strumento.value2)
            clockr_value = main_function.get_split_str(riga_strumento.value5)

            For i = 1 To numero_canali 'Tower può essere uno, due o tre canali
                Select Case i
                    Case 1 'controllo canale 1
                        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, fattore_divisione_temp,
                                                                  , , scala_temp, , , label_canale_temp)
                        If scala_temp = 3000 Then
                            valore_canale_temp = Val(Mid(valuer_value(0), 3, 4)) / fattore_divisione_temp
                        Else
                            valore_canale_temp = (Val(Mid(valuer_value(0), 3, 4)) * 10) / fattore_divisione_temp
                        End If
                        stringJson = stringJson + "{""key"":""probeLabel" + i.ToString + """, ""value"":""" + label_canale_temp + """}"
                        stringJson = stringJson + ",{""key"":""probeValuel" + i.ToString + """, ""value"":""" + valore_canale_temp.ToString + """}"
                    Case 2 'controllo canale 2
                        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , fattore_divisione_temp _
                                                                  , , , scala_temp, , , label_canale_temp)
                        valore_canale_temp = Val(Mid(valuer_value(0), 11, 4)) / fattore_divisione_temp
                        stringJson = stringJson + ",{""key"":""probeLabel" + i.ToString + """, ""value"":""" + label_canale_temp + """}"
                        stringJson = stringJson + ",{""key"":""probeValuel" + i.ToString + """, ""value"":""" + valore_canale_temp.ToString + """}"
                    Case 3 'controllo canale 3
                        main_function_config.get_tipo_strumento_tower(personalizzazione_aquacare, config_value(0), config_value(1), config_value(2), config_value(3), version_str, , ,
                                                                  fattore_divisione_temp, , , scala_temp, , , label_canale_temp)
                        valore_canale_temp = Val(Mid(valuer_value(0), 15, 4)) / fattore_divisione_temp
                        stringJson = stringJson + ",{""key"":""probeLabel" + i.ToString + """, ""value"":""" + label_canale_temp + """}"
                        stringJson = stringJson + ",{""key"":""probeValuel" + i.ToString + """, ""value"":""" + valore_canale_temp.ToString + """}"
                End Select
            Next
            Dim ora As String = ""
            If international_unit = "IS" Then
                ora = Mid(clockr_value(0), 9, 2) + ":" + Mid(clockr_value(0), 11, 2)
            Else

                If Val(Mid(clockr_value(0), 13, 1)) Then
                    ora = Mid(clockr_value(0), 9, 2) + ":" + Mid(clockr_value(0), 11, 2) + "  am"
                End If

                If Val(Mid(clockr_value(0), 14, 1)) Then
                    ora = Mid(clockr_value(0), 9, 2) + ":" + Mid(clockr_value(0), 11, 2) + "  pm"
                End If
            End If

            stringJson = stringJson + ",{""key"":""dateTime"", ""value"":""" + Mid(clockr_value(0), 3, 2) + "-" + Mid(clockr_value(0), 5, 2) + "-" + Mid(clockr_value(0), 7, 2) + " " + ora + """}"

            temperature_value = (Val(Mid(valuer_value(0), 7, 4)))
            temperature_value = temperature_value / 10
            If international_unit = "IS" Then
                stringJson = stringJson + ",{""key"":""temperature"", ""value"":""" + temperature_value.ToString + "°C""}"
            Else
                stringJson = stringJson + ",{""key"":""temperature"", ""value"":""" + temperature_value.ToString + "°F""}"
            End If

        End If
        Return stringJson
    End Function
    Private Function crea_canale(ByVal numero_canale As Integer, ByVal label_canale As String,
                            ByVal value_canale As String, ByVal alarm_canale() As String, ByVal tipo_strumento As String,
                            ByVal output_canale() As String) As String
        Dim stringJson As String = ""
        If numero_canale = 1 Then
            stringJson = stringJson + "{""key"":""probeLabel" + numero_canale.ToString + """, ""value"":""" + label_canale + """}"
        Else
            stringJson = stringJson + ",{""key"":""probeLabel" + numero_canale.ToString + """, ""value"":""" + label_canale + """}"
        End If
        stringJson = stringJson + ",{""key"":""probeValuel" + numero_canale.ToString + """, ""value"":""" + value_canale + """}"
        Select Case tipo_strumento
            Case "LD"
                Select Case numero_canale
                    Case 1 ' canale 1 
                        If main_function.alarm_ld_feedlimit_ph(alarm_canale) Then '' feed limit ph
                            stringJson = stringJson + ",{""key"":""minMax" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""minMax" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_dosalarm_ph(alarm_canale) Then '' dos alarm ph
                            stringJson = stringJson + ",{""key"":""dosAlarm" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""dosAlarm" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_probefail_ph(alarm_canale) Then '' probe fail ph
                            stringJson = stringJson + ",{""key"":""probeFail" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""probeFail" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_livello1_ph(alarm_canale) Then '' level 1 ph
                            stringJson = stringJson + ",{""key"":""firstLevel" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""firstLevel" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_livello2_ph(alarm_canale) Then '' level 2 ph
                            stringJson = stringJson + ",{""key"":""secondLevel" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""secondLevel" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        Select Case Mid(output_canale(1), 1, 1) 'ph pulse 1
                            Case "2" ' off
                                stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""DIS""}"
                            Case "0" ' on/off
                                If Mid(output_canale(6), 1, 3) = "001" Then ' on 
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                        stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If

                            Case "3" ' proportional+wm
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                End If

                            Case "4" ' PID
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                End If

                            Case "5" ' LINE
                                If Mid(output_canale(6), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                End If

                        End Select
                        Select Case Mid(output_canale(2), 1, 1) 'ph pulse 2
                            Case "2" ' off
                                stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""DIS""}"
                            Case "0" ' on/off
                                If Mid(output_canale(7), 1, 3) = "001" Then ' on 
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                        stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If

                            Case "3" ' proportional+wm
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If
                            Case "4" ' PID
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If
                            Case "5" ' LINE
                                If Mid(output_canale(7), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out2Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If
                        End Select
                        If Mid(output_canale(4), 1, 1) <> "3" Then ' ph relay
                            If Mid(output_canale(9), 1, 1) = "1" Then
                                stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""ON""}"
                            Else
                                If Mid(output_canale(9), 1, 1) = "2" Then
                                    stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If
                                stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                            End If

                        Else
                            stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                    Case 2 ' canale 2
                        If main_function.alarm_ld_feedlimit_cl(alarm_canale) Then '' feed limit cl
                            stringJson = stringJson + ",{""key"":""minMax" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""minMax" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_dosalarm_cl(alarm_canale) Then '' dos alarm cl
                            stringJson = stringJson + ",{""key"":""dosAlarm" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""dosAlarm" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_probefail_cl(alarm_canale) Then '' probe fail cl
                            stringJson = stringJson + ",{""key"":""probeFail" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""probeFail" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        If main_function.alarm_ld_livello1_cl(alarm_canale) Then '' level 2 ph
                            stringJson = stringJson + ",{""key"":""firstLevel" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            stringJson = stringJson + ",{""key"":""firstLevel" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If

                        Select Case Mid(output_canale(3), 1, 1) 'cl pulse 1
                            Case "2" ' off
                                stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""DIS""}"
                            Case "0" ' on/off
                                If Mid(output_canale(8), 1, 3) = "001" Then ' on 
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                        stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                    End If
                                End If
                            Case "1" ' proportional
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If

                            Case "3" ' proportional+wm
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If

                            Case "4" ' PID
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If

                            Case "5" ' LINE
                                If Mid(output_canale(8), 1, 3) = "000" Then ' off
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                                Else
                                    stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If
                        End Select
                        If Mid(output_canale(5), 1, 1) <> "3" Then ' cl releya
                            If Mid(output_canale(10), 1, 1) = "1" Then
                                stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""ON""}"
                            Else
                                If Mid(output_canale(10), 1, 1) = "2" Then
                                    stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                                End If
                                stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                            End If

                        Else
                            stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If

                End Select
            Case "LDS" 'caso ld singolo
                If main_function.alarm_lds_feedlimit(alarm_canale) Then '' feed limit 
                    stringJson = stringJson + ",{""key"":""minMax" + numero_canale.ToString + """, ""value"":""ON""}"
                Else
                    stringJson = stringJson + ",{""key"":""minMax" + numero_canale.ToString + """, ""value"":""OFF""}"
                End If
                If main_function.alarm_lds_dosalarm(alarm_canale) Then '' dos alarm 
                    stringJson = stringJson + ",{""key"":""dosAlarm" + numero_canale.ToString + """, ""value"":""ON""}"
                Else
                    stringJson = stringJson + ",{""key"":""dosAlarm" + numero_canale.ToString + """, ""value"":""OFF""}"
                End If
                If main_function.alarm_lds_probefail(alarm_canale) Then '' probe fail 
                    stringJson = stringJson + ",{""key"":""probeFail" + numero_canale.ToString + """, ""value"":""ON""}"
                Else
                    stringJson = stringJson + ",{""key"":""probeFail" + numero_canale.ToString + """, ""value"":""OFF""}"
                End If

                If main_function.alarm_lds_livello(alarm_canale) Then '' level 1 
                    stringJson = stringJson + ",{""key"":""firstLevel" + numero_canale.ToString + """, ""value"":""ON""}"
                Else
                    stringJson = stringJson + ",{""key"":""firstLevel" + numero_canale.ToString + """, ""value"":""OFF""}"
                End If

                Select Case Mid(output_canale(1), 1, 1) ' pulse 1
                    Case "2" ' off
                        stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""DIS""}"
                    Case "0" ' on/off
                        If Mid(output_canale(5), 1, 3) = "001" Then ' on 
                            stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                        Else
                            If Mid(output_canale(5), 1, 3) = "000" Then ' off
                                stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                            End If
                        End If
                    Case "1" ' proportional
                        If Mid(output_canale(5), 1, 3) = "000" Then ' off
                            stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""OFF""}"
                        Else
                            stringJson = stringJson + ",{""key"":""out1Ch" + numero_canale.ToString + """, ""value"":""ON""}"
                        End If

                End Select
                If Mid(output_canale(2), 1, 1) <> "3" Then ' ph releya
                    If Mid(output_canale(4), 1, 1) = "1" Then
                        stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""ON""}"
                    Else
                        If Mid(output_canale(4), 1, 1) = "2" Then
                            stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                        End If
                        stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                    End If

                Else
                    stringJson = stringJson + ",{""key"":""outRCh" + numero_canale.ToString + """, ""value"":""OFF""}"
                End If
        End Select



        Return stringJson
    End Function
End Class
