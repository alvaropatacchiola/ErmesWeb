Public Class main_function_config




    Public Shared Function get_tipo_strumento_wd(ByVal config_valore As String)

        Dim tipo_wd As String = ""

        If Mid(config_valore, 1, 3) = "306" Then
            tipo_wd = "Null"
        Else
            If Mid(config_valore, 1, 3) = "301" Then
                tipo_wd = "EV"
            Else
                If Mid(config_valore, 1, 3) = "302" Then
                    tipo_wd = "S"
                Else
                    If Mid(config_valore, 1, 3) = "303" Then
                        tipo_wd = "PER"
                    End If
                End If
            End If
        End If

        Return tipo_wd

    End Function
    '--------------------------------------------------------------------------------------
    'gestione decodifica configurazione / status generale strumento LOTUS B
    '--------------------------------------------------------------------------------------
    Public Shared Function get_enable_canale_lotusb(ByVal codice_canale As String) As Boolean
        If codice_canale <> "1" Then
            Return True
        Else
            Return False
        End If

    End Function

    '--------------------------------------------------------------------------------------
    'gestione decodifica configurazione / status generale strumento LD - LD doppio - WD
    '--------------------------------------------------------------------------------------
    Public Shared Function get_tipo_strumento_ld_lds_wd(ByVal codice_canale As String, Optional ByRef fattore_divisione As Integer = 1, Optional ByRef full_scale As Integer = 0, Optional ByRef str_terzo_canale As String = "", Optional ByRef label_setpoint As String = "", Optional ByRef label_service As String = "") As String
        Select Case codice_canale
            Case "00"
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "01"
                full_scale = 5
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "02"
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "03"
                full_scale = 200
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "04"
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "05"
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "06"
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "07"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "08"
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "09"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "10"
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Clt"
            Case "110"
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Clt"

            Case "11"
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Clt"
            Case "12"
                full_scale = 200
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "H2O2"
            Case "13"
                full_scale = 2000
                fattore_divisione = 1
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "H2O2"
            Case "14"
                full_scale = 1
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "O3"
            Case "15"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "O3"
            Case "16"
                full_scale = 200
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "PAA"
            Case "17"
                full_scale = 2000
                fattore_divisione = 1
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "PAA"
            Case "18"
                full_scale = 60
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "O2"
            Case "19"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "20"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "21"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Br2"
            Case "22" ' modifica mV
                full_scale = 1000
                fattore_divisione = 1
                str_terzo_canale = "mV"
                label_setpoint = "mV"
                Return "mV"
            Case "23" ' modifica per gestione pH
                full_scale = 14
                fattore_divisione = 100
                str_terzo_canale = "pH"
                label_setpoint = "pH"
                Return "pH"
            Case "24" ' uS
                full_scale = 300
                fattore_divisione = 10
                str_terzo_canale = "µS"
                label_setpoint = "µS"
                Return "µS"
            Case "25" ' uS
                full_scale = 3000
                fattore_divisione = 1
                str_terzo_canale = "µS"
                label_setpoint = "µS"
                Return "µS"
            Case "26" ' mS
                full_scale = 30
                fattore_divisione = 100
                str_terzo_canale = "mS"
                label_setpoint = "mS"
                Return "mS"
            Case "27" ' mS
                full_scale = 300
                fattore_divisione = 10
                str_terzo_canale = "mS"
                Return "mS"
            Case "28" ' LDO x.xxx
                full_scale = 9
                fattore_divisione = 1000
                str_terzo_canale = "LDO"
                label_setpoint = "mg/l"
                Return "LDO"
            Case "29" ' LDO xx.xx
                full_scale = 99
                fattore_divisione = 100
                str_terzo_canale = "LDO"
                label_setpoint = "mg/l"
                Return "LDO"
            Case "30" ' LDO xxx.x
                full_scale = 999
                fattore_divisione = 10
                str_terzo_canale = "LDO"
                label_setpoint = "mg/l"
                Return "LDO"
            Case "31" ' LDO xxxx
                full_scale = 9999
                fattore_divisione = 1
                str_terzo_canale = "LDO"
                label_setpoint = "mg/l"
                Return "LDO"
            Case "32" ' NTU vecchia xx.xx
                full_scale = 30
                fattore_divisione = 100
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"
                Return "NTU"
            Case "33" ' NTU nuova x.xxx
                full_scale = 9
                fattore_divisione = 1000
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"
                Return "NTU"
            Case "34" ' NTU nuova xx.xx
                full_scale = 99
                fattore_divisione = 100
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"
                Return "NTU"
            Case "35" ' NTU nuova xxx.x
                full_scale = 999
                fattore_divisione = 10
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"
                Return "NTU"
            Case "36" ' NTU vecchia xxxx
                full_scale = 9999
                fattore_divisione = 1
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"
                Return "NTU"

            Case "37" '
                full_scale = 5
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "38" '
                full_scale = 999
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "39"
                full_scale = 99
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "40"
                full_scale = 99
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"

            Case "41"
                full_scale = 30
                fattore_divisione = 100
                str_terzo_canale = "µS"
                label_setpoint = "µs"
                Return "µS"
            Case "42"
                full_scale = 9
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "43"
                full_scale = 9
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "44"
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Br2"

            Case "45"
                full_scale = 99
                fattore_divisione = 10
                str_terzo_canale = "°C"
                label_setpoint = "°C"
                Return "°C"

            Case "46"
                full_scale = 200
                fattore_divisione = 1
                str_terzo_canale = "°F"
                label_setpoint = "°F"
                Return "°F"
            Case "47" ' mS
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mS"
                label_setpoint = "mS"
                Return "mS"
            Case "48" ' ppm
                full_scale = 999
                fattore_divisione = 10
                str_terzo_canale = "ppm"
                label_setpoint = "ppm"
                label_service = "mA"
                Return "ppm"
            Case "49" ' ppm
                full_scale = 999
                fattore_divisione = 10
                str_terzo_canale = "ppm"
                label_setpoint = "ppm"
                label_service = "mA"
                Return "ppm"

            Case "50" ' ppm
                full_scale = 9999
                fattore_divisione = 1
                str_terzo_canale = "ppm"
                label_setpoint = "ppm"
                label_service = "mV"
                Return "ppm"

            Case "51"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"

            Case "53"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "54"
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "55"
                full_scale = 3
                fattore_divisione = 100
                str_terzo_canale = "ppm"
                label_setpoint = "ppm"
                Return "F-"

            Case "56" ' modifica mV
                full_scale = 1000
                fattore_divisione = 1
                str_terzo_canale = "mV"
                label_setpoint = "mV"
                Return "mV"
            Case "57" '
                full_scale = 5
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "58" '
                full_scale = 1
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"


            Case "59" '
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2"
            Case "60" '
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "61" '
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "O3"
            Case "62" '
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "O3"
            Case "63" '
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2-"
            Case "64" '
                full_scale = 50
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "PAA"

            Case "65" '
                full_scale = 2
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "66" '
                full_scale = 5
                fattore_divisione = 1000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "67" '
                full_scale = 10
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "68" '
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "69" '
                full_scale = 50
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "70" '
                full_scale = 100
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "71" '
                full_scale = 200
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "72" '
                full_scale = 500
                fattore_divisione = 10
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "73" '
                full_scale = 1000
                fattore_divisione = 1
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "MPY"
            Case "74" '
                full_scale = 50
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "H2O2"
            Case "78"
                full_scale = 1
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl02"
            Case "79"
                full_scale = 20
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "ClO2 Air"
            Case "88"
                full_scale = 5
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "89"
                full_scale = 5
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "90"
                full_scale = 5
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"
            Case "91"
                full_scale = 5
                fattore_divisione = 100
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"
                Return "Cl2"

            Case "92"
                fattore_divisione = 100
                full_scale = 40
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"

                Return "NTU"
            Case "93"
                fattore_divisione = 10
                full_scale = 400
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"

                Return "NTU"
            Case "94"
                fattore_divisione = 1
                full_scale = 4000
                str_terzo_canale = "NTU"
                label_setpoint = "NTU"

                Return "NTU"

            Case "100"
                fattore_divisione = 100
                full_scale = 40
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"

                Return "mg/l"
            Case "101"
                fattore_divisione = 100
                full_scale = 40
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"

                Return "mg/l"

            Case "102"
                fattore_divisione = 10
                full_scale = 400
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"

                Return "mg/l"
            Case "103"
                fattore_divisione = 1
                full_scale = 4000
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"

                Return "mg/l"
            Case "104"
                fattore_divisione = 100
                full_scale = 20
                str_terzo_canale = "Clc"
                label_setpoint = "Clc"

                Return "Clc"

            Case "106"
                fattore_divisione = 100
                full_scale = 3
                str_terzo_canale = "mg/l"
                label_setpoint = "mg/l"

                Return "Cl2"

        End Select
    End Function
    '--------------------------------------------------------------------------------------
    'end gestione decodifica configurazione / status generale strumento LD LD doppio
    '--------------------------------------------------------------------------------------
    '--------------------------------------------------------------------------------------
    'gestione decodifica configurazione / status generale strumento Max 5
    '--------------------------------------------------------------------------------------
    Public Shared Function get_tipo_strumento_max5(ByVal numero_canale As Integer, ByVal output_str As String, ByVal option_str As String, Optional ByRef fattore_divisione As Integer = 1, Optional ByRef full_scale As Integer = 0 _
                                                   , Optional ByRef flow_value As Single = 0, Optional ByVal flow_str As String = "", _
                                                   Optional ByRef fattore_divisione_com As Integer = 1) As String
        Dim code_channel As String = ""
        code_channel = Mid(output_str, 3, 1)
        Select Case code_channel
            Case "0"
                fattore_divisione = 100
                full_scale = 3
                Return " F-"
            Case "1"
                fattore_divisione = 100
                full_scale = 14
                Return " pH"
            Case "2"
                fattore_divisione = 1
                full_scale = 1000
                Return " mV"
            Case "3"
                Dim indice As Integer = InStr(output_str, "E")
                If indice = 0 Then
                    indice = InStr(output_str, "S")
                End If
                full_scale = Val(Mid(output_str, indice - 7, 4))
                fattore_divisione = get_scale(Mid(output_str, indice - 3, 1), full_scale)
                Return get_sonda(Val(Mid(output_str, indice - 2, 2)), fattore_divisione_com)
            Case "4"
                If numero_canale = 1 Then
                    full_scale = Val(Mid(output_str, Len(output_str) - 5, 4))
                    fattore_divisione = get_scale(Mid(output_str, Len(output_str) - 1, 1), full_scale)
                Else
                    full_scale = Val(Mid(output_str, Len(output_str) - 4, 4))
                    fattore_divisione = get_scale(Mid(output_str, Len(output_str), 1), full_scale)
                End If
                Return "NTU"
            Case "5"
                full_scale = Val(Mid(output_str, Len(output_str) - 11, 4))
                fattore_divisione = get_scale(Mid(output_str, Len(output_str) - 7, 1), full_scale)
                Return get_cd(Val(Mid(output_str, 17, 3)))
            Case "6"
                full_scale = 1
                fattore_divisione = 1
                Return ""
            Case "7"
                'set_point_enable.Visible = True
                'set_point_enable.Text = "SetPoint Ch" + Format(numero_canale, "0") + " " + "Clco"
                fattore_divisione = fattore_divisione_com
                Return "Clco"
            Case "8"
                full_scale = Val(Mid(output_str, 4, 4))
                fattore_divisione = get_scale(Mid(output_str, 8, 1), full_scale)
                Return "LDO"
            Case "9" 'dosim acquedotto
                full_scale = Val(Mid(output_str, 12, 4))
                fattore_divisione = get_scale(Mid(output_str, 16, 1), full_scale)
                Return get_sonda(Val(Mid(output_str, 17, 2)))
            Case "Y" 'yagel version
                Select Case get_flow_unit(option_str)
                    Case "0" 'm3/h
                        full_scale = 999.99
                        fattore_divisione = 10
                        flow_value = Val(Mid(flow_str, 13, 4)) / fattore_divisione
                        Return "m3/h"
                    Case "1" 'G/m
                        full_scale = 9999
                        fattore_divisione = 1000
                        flow_value = Val(Mid(flow_str, 13, 6)) / fattore_divisione
                        Return "G/m"
                End Select

        End Select
    End Function
    Public Shared Function get_flow_unit(ByVal output_str As String) As String
        Return Mid(output_str, 3, 1)
    End Function
    Public Shared Function get_ma_enable(ByVal output_str As String) As Boolean
        If (Mid(output_str, Len(output_str), 1) = "1") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function get_flow_yagel_divide(ByVal output_str As String) As Single
        'posizione 19+4 per flow xx_xxx
        'posizione 19+3 per flow xxx_xx
    End Function
    Public Shared Function get_sonda(ByVal indice As Integer, Optional ByRef fattore_divisione_com As Integer = 1) As String
        Select Case indice
            Case 0, 1, 2, 3, 6, 7, 8, 9, 20
                Return "Cl2"
            Case 4, 5, 19
                Return "ClO2"
            Case 10
                fattore_divisione_com = 1000
                Return "Clt"
            Case 11
                fattore_divisione_com = 100
                Return "Clt"
            Case 12, 13
                Return "H2O2"
            Case 14, 15
                Return "O3"
            Case 16, 17
                Return "PAA"
            Case 18
                Return "O2"
            Case 21
                Return "BR2"
            Case 22
                Return "BR2"
            Case 23
                Return "Cl"

        End Select

    End Function
    Public Shared Function get_cd(ByVal indice As Integer) As String
        indice = indice >> 6
        Select Case indice
            Case 0, 1
                Return "µS"
            Case 2, 3
                Return "mS"
            Case 4
                Return "TDS"

        End Select
    End Function
    Public Shared Function get_scale(ByVal value_1 As String, ByRef full_scale As Integer) As Integer
        Select Case value_1
            Case "0", "4"
                full_scale = full_scale
                Return 1
            Case "1"
                full_scale = full_scale / 1000
                Return 1000
            Case "2"
                full_scale = full_scale / 100
                Return 100
            Case "3"
                full_scale = full_scale / 10
                Return 10
        End Select
    End Function
    'funzioni di decodifica infromazioni time/data ora
    Public Shared Function get_time_info(ByVal output_str As String, Optional ByRef data_type As Integer = 0, Optional ByRef time_type As Integer = 0) As String
        Dim result_time As String = ""
        If (Mid(output_str, 9, 1) = "0") Then
            data_type = 0
            result_time = Mid(output_str, 3, 2) & "|" & get_month(Mid(output_str, 5, 2)) & "|" & Mid(output_str, 7, 2)
        End If
        If (Mid(output_str, 9, 1) = "1") Then
            data_type = 1
            result_time = get_month(Mid(output_str, 5, 2)) & "|" & Mid(output_str, 3, 2) & "|" & Mid(output_str, 7, 2)
        End If
        If (Mid(output_str, 9, 1) = "2") Then
            data_type = 2
            result_time = Mid(output_str, 7, 2) & "|" & Mid(output_str, 3, 2) & "|" & get_month(Mid(output_str, 5, 2))
        End If
        If Mid(output_str, 10, 1) = "0" Then
            time_type = 0
            If Val(Mid(output_str, 11, 2)) > 12 Then
                result_time = result_time + "|" + Format((Val(Mid(output_str, 11, 2)) - 12), "00") & ":" & Mid(output_str, 13, 2) + " Pm"
            Else
                If Val(Mid(output_str, 11, 2)) = 12 Then
                    result_time = result_time + "|" + Mid(output_str, 11, 2) & ":" & Mid(output_str, 13, 2) + " Pm"
                Else
                    result_time = result_time + "|" + Mid(output_str, 11, 2) & ":" & Mid(output_str, 13, 2) + " Am"
                End If
            End If
        Else
            time_type = 1
            result_time = result_time + "|" + Mid(output_str, 11, 2) & ":" & Mid(output_str, 13, 2)
        End If
        Return result_time
    End Function
    Private Shared Function get_month(ByVal mese As String) As String
        Select Case mese
            Case "01"
                Return "Jan"
            Case "02"
                Return "Feb"
            Case "03"
                Return "Mar"
            Case "04"
                Return "Apr"
            Case "05"
                Return "May"
            Case "06"
                Return "Jun"
            Case "07"
                Return "Jul"
            Case "08"
                Return "Aug"
            Case "09"
                Return "Sep"
            Case "10"
                Return "Oct"
            Case "11"
                Return "Nov"
            Case "12"
                Return "Dec"
        End Select
        Return mese
    End Function
    'end funzioni di decodifica infromazioni time/data ora
    Public Shared Function get_temperature_info(ByVal output_str As String, Optional ByRef temperature_type As Integer = 0) As String
        If Mid(output_str, 19, 1) = "0" Then
            temperature_type = 0
            Return Mid(output_str, 15, 3) & "." & Mid(output_str, 18, 1)
        Else
            temperature_type = 1
            Return Mid(output_str, 15, 3) & "." & Mid(output_str, 18, 1)
        End If
        Return ""
    End Function
    Public Shared Function get_temperature_infoDoppiaPiscina(ByVal output_str As String, ByRef temperature2 As Single, Optional ByRef temperature_type As Integer = 0) As String
        If Mid(output_str, 23, 1) = "0" Then
            temperature_type = 0
            temperature2 = Val(Mid(output_str, 19, 3) & "." & Mid(output_str, 22, 1))
            Return Mid(output_str, 15, 3) & "." & Mid(output_str, 18, 1)
        Else
            temperature_type = 1
            temperature2 = Val(Mid(output_str, 19, 3) & "." & Mid(output_str, 22, 1))
            Return Mid(output_str, 15, 3) & "." & Mid(output_str, 18, 1)
        End If
        Return ""
    End Function
    '--------------------------------------------------------------------------------------
    'end gestione decodifica configurazione / status generale strumento Max 5
    '--------------------------------------------------------------------------------------
    '--------------------------------------------------------------------------------------
    'gestione decodifica configurazione / status generale strumento Tower
    '--------------------------------------------------------------------------------------
    Public Shared Function get_tipo_strumento_tower(ByVal personalizzazione_aquacare As Integer, valore0 As String, ByVal valore1 As String, ByVal valore2 As String, ByVal valore3 As String, ByVal version_str As String, _
                                                    Optional ByRef fattore_divisione1 As Integer = 1, Optional ByRef fattore_divisione2 As Integer = 1, Optional ByRef fattore_divisione3 As Integer = 1, _
                                                    Optional ByRef full_scale1 As Integer = 0, Optional ByRef full_scale2 As Integer = 0, Optional ByRef full_scale3 As Integer = 0, _
                                                    Optional ByRef str_sonda_1 As String = "", Optional ByRef str_sonda_2 As String = "", Optional ByRef str_sonda_3 As String = "", Optional ByRef etichetta_setpoint_ch2 As String = "", Optional ByRef etichetta_setpoint_ch3 As String = "") As String
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT06") Or InStr(valore1, "M06")) And InStr(valore2, "MT06") And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then ' Cd
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"

            fattore_divisione2 = 1
            fattore_divisione3 = 1
            Return "Cdxxx"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT02") Or InStr(valore1, "M02")) And (InStr(valore2, "MT06") Or InStr(valore2, "M06")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd pH
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 100
            full_scale2 = 14
            str_sonda_2 = "pH"
            etichetta_setpoint_ch2 = "pH"
            etichetta_setpoint_ch3 = ""
            Return "Cd_pH"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT03") Or InStr(valore1, "M03")) And (InStr(valore2, "MT06") Or InStr(valore2, "M06")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd rH
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 1
            full_scale2 = 1000
            str_sonda_2 = "mV"
            etichetta_setpoint_ch2 = "mV"
            etichetta_setpoint_ch3 = ""

            Return "Cd_rH"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT04") Or InStr(valore1, "M04")) And (InStr(valore2, "MT06") Or InStr(valore2, "M06")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"
            etichetta_setpoint_ch3 = ""

            'fattore_divisione2 = get_sonda_tower(Val(Mid(valore1, 13, 2)), full_scale2, str_sonda_2, etichetta_setpoint_ch2)
            fattore_divisione2 = get_sonda_tower(Val(Right(valore1, 2)), full_scale2, str_sonda_2, etichetta_setpoint_ch2)
            Return "Cd_Cl"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT02") Or InStr(valore1, "M02")) And (InStr(valore2, "MT03") Or InStr(valore2, "M03")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd pH rH
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 100
            full_scale2 = 14
            str_sonda_2 = "pH"
            fattore_divisione3 = 1
            full_scale3 = 1000
            str_sonda_3 = "mV"
            etichetta_setpoint_ch2 = "pH"
            etichetta_setpoint_ch3 = "mV"
            Return "Cd_pH_rH"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT02") Or InStr(valore1, "M02")) And (InStr(valore2, "MT04") Or InStr(valore2, "M04")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd pH Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 100
            full_scale2 = 14
            If personalizzazione_aquacare = 1 Then
                If Mid(valore1, 18, 1) = "1" Then
                    str_sonda_2 = "pH"
                    etichetta_setpoint_ch2 = "pH"
                Else
                    str_sonda_2 = "N.C."
                    etichetta_setpoint_ch2 = "pH"
                End If
            Else
                str_sonda_2 = "pH"
                etichetta_setpoint_ch2 = "pH"
            End If
            'fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)
            fattore_divisione3 = get_sonda_tower(Val(Right(valore2, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)

            Return "Cd_pH_Cl"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT03") Or InStr(valore1, "M03")) And (InStr(valore2, "MT04") Or InStr(valore2, "M04")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd rH Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 1
            full_scale2 = 1000

            str_sonda_2 = "mV"
            etichetta_setpoint_ch2 = "MV"

            'fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)
            fattore_divisione3 = get_sonda_tower(Val(Right(valore2, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)

            Return "Cd_rH_Cl"
        End If

        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT07") Or InStr(valore1, "M07")) And (InStr(valore2, "MT04") Or InStr(valore2, "M04")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd trc Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"

            fattore_divisione2 = 10
            full_scale2 = 999
            str_sonda_2 = "ppm"
            etichetta_setpoint_ch2 = "ppm"

            'fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)
            fattore_divisione3 = get_sonda_tower(Val(Right(valore2, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)

            Return "Cd_trc_Cl"
        End If
        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT07") Or InStr(valore1, "M07")) And (InStr(valore2, "MT03") Or InStr(valore2, "M03")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd trc rh
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 9999
                End If
            Else
                full_scale1 = 9999
            End If
            str_sonda_1 = "Cd"

            fattore_divisione2 = 10
            full_scale2 = 999
            str_sonda_2 = "ppm"
            etichetta_setpoint_ch2 = "ppm"

            'fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)
            fattore_divisione3 = 1
            full_scale3 = 1000
            str_sonda_3 = "mV"
            etichetta_setpoint_ch3 = "mV"

            Return "Cd_trc_rH"
        End If
    End Function
    Private Shared Function get_sonda_tower(ByVal tipo_sonda As Integer, ByRef full_scale_temp As Integer, ByRef str_sonda As String, ByRef etichetta_setpoint As String, Optional ByVal tipoCanale As Integer = 0) As Integer
        Select Case tipo_sonda
            Case 0
                str_sonda = "Cl2"
                full_scale_temp = 2
                etichetta_setpoint = "mg/l"
                Return 1000
            Case 1
                'alvaro per log
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 5
                Return 1000
                '      gauge.NumericIndicators(stringa_canale).Value = valuer / 1000
            Case 2
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 20
                Return 100
                '       gauge.NumericIndicators(stringa_canale).Value = valuer / 100
            Case 3
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 200
                Return 10
                '        gauge.NumericIndicators(stringa_canale).Value = valuer / 10
            Case 4
                str_sonda = "Cl2O2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 2
                Return 1000
                '         gauge.NumericIndicators(stringa_canale).Value = valuer / 1000
            Case 5
                str_sonda = "Cl2O2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 20
                Return 100
                '          gauge.NumericIndicators(stringa_canale).Value = valuer / 100
            Case 6
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 2
                Return 1000
                '           gauge.NumericIndicators(stringa_canale).Value = valuer / 1000
            Case 7
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 10
                Return 100
                '            gauge.NumericIndicators(stringa_canale).Value = valuer / 100
            Case 8
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 10
                Return 100
                '             gauge.NumericIndicators(stringa_canale).Value = valuer / 100
            Case 9
                str_sonda = "Cl2O2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 10
                Return 100
                '              gauge.NumericIndicators(stringa_canale).Value = valuer / 100
            Case 10
                str_sonda = "Cl2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 10
                Return 100
                '               gauge.NumericIndicators(stringa_canale).Value = valuer / 100

            Case 11
                str_sonda = "Br"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 10
                Return 100
                '                gauge.NumericIndicators(stringa_canale).Value = valuer / 100
            Case 12
                str_sonda = "H2O2"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 200
                Return 10

                '                gauge.NumericIndicators(stringa_canale).Value = valuer / 10
            Case 13
                'If tipoCanale = 0 Then
                'str_sonda = "N.C."
                'etichetta_setpoint = "Cl"
                'full_scale_temp = 200
                'Return 10
                'Else
                str_sonda = "Br"
                    etichetta_setpoint = "mg/l"
                    full_scale_temp = 10
                    Return 100
            Case 14
                str_sonda = "EPS"
                etichetta_setpoint = "mg/l"
                full_scale_temp = 5
                Return 1000

        End Select
    End Function

    ' gestione della personalizzazione e delle varie versioni del M Tower

    Public Shared Function chek_tower_version(ByVal version_str As String, Optional ByRef result_version As String = "", Optional ByRef personalizzazione_aquacare As Integer = 1, Optional ByRef boiler As Boolean = False) As Boolean
        Dim new_version As Boolean = False

        Dim intVersion As Integer = Val(main_function.get_version(version_str))
        Dim divisione As Integer = intVersion / 100
        boiler = False
        If InStr(version_str, "300") Or InStr(version_str, "301") Or InStr(version_str, "302") Or InStr(version_str, "283") _
            Or InStr(version_str, "305") Or InStr(version_str, "284") Or InStr(version_str, "306") _
            Or InStr(version_str, "303") Or InStr(version_str, "304") Or InStr(version_str, "500") Or InStr(version_str, "501") _
            Or intVersion > 304 Then
            If InStr(version_str, "#Boiler#") <> 0 Then
                boiler = True
            End If
            result_version = "3.0.0"

        Else
            result_version = "2.7.4"
        End If
        'If InStr(version_str, "7") = 1 Or InStr(version_str, "8") = 1 Then
        If divisione = 7 Or divisione = 8 Then
            result_version = "3.0.0"
        End If
        If divisione = 5 Or divisione = 4 Then       'per aquacare comincia per 4 o per 5 
            personalizzazione_aquacare = 1
        Else
            personalizzazione_aquacare = 0
        End If
        If InStr(version_str, "304") Or InStr(version_str, "282") Or InStr(version_str, "283") Or InStr(version_str, "305") _
            Or InStr(version_str, "284") Or InStr(version_str, "306") Then       'utilizzato per distinguere le versioni precedenti alla 3.0.4

            new_version = True
        Else
            new_version = False
        End If
        Return new_version
    End Function
    ' gestione delle impostazioni dello strumento Tower
    Public Shared Function get_tower_unit(ByVal input_str() As String, ByRef unit_tower As String, Optional ByRef measure_unit As String = "")
        If Val(Mid(input_str(0), 3, 1)) Then        'IS
            unit_tower = "IS"
        End If

        If Val(Mid(input_str(0), 4, 1)) Then        'US
            unit_tower = "US"
        End If

        If Val(Mid(input_str(0), 5, 1)) Then        'Siemens
            measure_unit = "uS"
        End If

        If Val(Mid(input_str(0), 6, 1)) Then        'ppm
            measure_unit = "ppm"
        End If
    End Function
    '--------------------------------------------------------------------------------------
    'end gestione decodifica configurazione / status generale strumento Tower
    '--------------------------------------------------------------------------------------

    '--------------------------------------------------------------------------------------
    ' gestione della personalizzazione e delle varie versioni del  LDTower
    '--------------------------------------------------------------------------------------

    Public Shared Function get_tipo_strumento_ldtower(ByVal valore0 As String, ByVal valore1 As String, ByVal valore2 As String, ByVal valore3 As String, ByVal version_str As String,
                                                    Optional ByRef fattore_divisione1 As Integer = 1, Optional ByRef fattore_divisione2 As Integer = 1, Optional ByRef fattore_divisione3 As Integer = 1,
                                                    Optional ByRef full_scale1 As Integer = 0, Optional ByRef full_scale2 As Integer = 0, Optional ByRef full_scale3 As Integer = 0,
                                                    Optional ByRef str_sonda_1 As String = "", Optional ByRef str_sonda_2 As String = "", Optional ByRef str_sonda_3 As String = "", Optional ByRef etichetta_setpoint_ch2 As String = "", Optional ByRef etichetta_setpoint_ch3 As String = "") As String
        If InStr(valore0, "MT01") And InStr(valore1, "MT06") And InStr(valore2, "MT06") And InStr(valore3, "MT05") Then ' Cd

            '   If InStr(version_str, "5.0.5") Then
            If Mid(valore0, valore0.Length, 1) = "1" Then
                fattore_divisione1 = 1
                full_scale1 = 5000
            Else
                fattore_divisione1 = 1
                full_scale1 = 500
            End If
            '   Else
            '         full_scale1 = 500
            '   End If
            str_sonda_1 = "Cd"

            fattore_divisione2 = 1
            fattore_divisione3 = 1
            Return "Cdxxx"
        End If

        'NON UTILIZZATE (EREDITATE DAL TOWER)
        If InStr(valore0, "MT01") And InStr(valore1, "MT02") And InStr(valore2, "MT06") And InStr(valore3, "MT05") Then 'Cd pH
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 100
            full_scale2 = 14
            str_sonda_2 = "pH"
            etichetta_setpoint_ch2 = "pH"
            etichetta_setpoint_ch3 = ""
            Return "Cd_pH"
        End If
        If InStr(valore0, "MT01") And InStr(valore1, "MT03") And InStr(valore2, "MT06") And InStr(valore3, "MT05") Then 'Cd rH
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 1
            full_scale2 = 1000
            str_sonda_2 = "mV"
            etichetta_setpoint_ch2 = "mV"
            etichetta_setpoint_ch3 = ""

            Return "Cd_rH"
        End If
        If InStr(valore0, "MT01") And InStr(valore1, "MT04") And InStr(valore2, "MT06") And InStr(valore3, "MT05") Then 'Cd Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"
            etichetta_setpoint_ch3 = ""

            fattore_divisione2 = get_sonda_tower(Val(Mid(valore1, 13, 2)), full_scale2, str_sonda_2, etichetta_setpoint_ch2)
            Return "Cd_Cl"
        End If
        If InStr(valore0, "MT01") And InStr(valore1, "MT02") And InStr(valore2, "MT03") And InStr(valore3, "MT05") Then 'Cd pH rH
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 100
            full_scale2 = 14
            str_sonda_2 = "pH"
            fattore_divisione3 = 1
            full_scale3 = 1000
            str_sonda_3 = "mV"
            etichetta_setpoint_ch2 = "pH"
            etichetta_setpoint_ch3 = "mV"
            Return "Cd_pH_rH"
        End If
        If InStr(valore0, "MT01") And InStr(valore1, "MT02") And InStr(valore2, "MT04") And InStr(valore3, "MT05") Then 'Cd pH Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 100
            full_scale2 = 14
            'If personalizzazione_aquacare = 1 Then
            'If Mid(valore1, 18, 1) = "1" Then
            'str_sonda_2 = "pH"
            'etichetta_setpoint_ch2 = "pH"
            'Else
            '   str_sonda_2 = "N.C."
            ' etichetta_setpoint_ch2 = "pH"
            'End If
            'Else
            'str_sonda_2 = "pH"
            'etichetta_setpoint_ch2 = "pH"
            'End If
            fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)

            Return "Cd_pH_Cl"
        End If
        If InStr(valore0, "MT01") And InStr(valore1, "MT03") And InStr(valore2, "MT04") And InStr(valore3, "MT05") Then 'Cd rH Cl
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"
            fattore_divisione2 = 1
            full_scale2 = 1000
            'If personalizzazione_aquacare = 1 Then
            'If Mid(valore1, 18, 1) = "1" Then
            'str_sonda_2 = "pH"
            'etichetta_setpoint_ch2 = "pH"
            'Else
            '   str_sonda_2 = "N.C."
            ' etichetta_setpoint_ch2 = "pH"
            'End If
            'Else
            'str_sonda_2 = "pH"
            'etichetta_setpoint_ch2 = "pH"
            'End If
            fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)

            Return "Cd_rH_Cl"
        End If

        If (InStr(valore0, "MT01") Or InStr(valore0, "M01")) And (InStr(valore1, "MT07") Or InStr(valore1, "M07")) And (InStr(valore2, "MT03") Or InStr(valore2, "M03")) And (InStr(valore3, "MT05") Or InStr(valore3, "M05")) Then 'Cd trc rh
            fattore_divisione1 = 1
            If InStr(version_str, "3.0.0") Then
                If Mid(valore0, valore0.Length, 1) = "1" Then
                    full_scale1 = 30000
                Else
                    full_scale1 = 3000
                End If
            Else
                full_scale1 = 3000
            End If
            str_sonda_1 = "Cd"

            fattore_divisione2 = 10
            full_scale2 = 999
            str_sonda_2 = "ppm"
            etichetta_setpoint_ch2 = "ppm"

            'fattore_divisione3 = get_sonda_tower(Val(Mid(valore2, 13, 2)), full_scale3, str_sonda_3, etichetta_setpoint_ch3, 1)
            fattore_divisione3 = 1
            full_scale3 = 1000
            str_sonda_3 = "mV"
            etichetta_setpoint_ch3 = "mV"

            Return "Cd_trc_rH"
        End If
    End Function


    Public Shared Function chek_ldtower_version(ByVal version_str As String, Optional ByRef result_version As String = "") As Boolean
        Dim new_version As Boolean = False

        Dim intVersion As Integer = Val(main_function.get_version(version_str))

        'If InStr(version_str, "510") Then

        'result_version = "5.0.5"

        ' End If

    End Function
    ' gestione delle impostazioni dello strumento Tower
    Public Shared Function get_ldtower_unit(ByVal input_str() As String, ByRef unit_tower As String, Optional ByRef measure_unit As String = "")
        If Val(Mid(input_str(0), 3, 1)) Then        'IS
            unit_tower = "IS"
        End If

        If Val(Mid(input_str(0), 4, 1)) Then        'US
            unit_tower = "US"
        End If

        If Val(Mid(input_str(0), 5, 1)) Then        'Siemens
            measure_unit = "µS"
        End If

        If Val(Mid(input_str(0), 6, 1)) Then        'ppm
            measure_unit = "ppm"
        End If
    End Function
    '--------------------------------------------------------------------------------------
    'end gestione decodifica configurazione / status generale strumento Tower
    '--------------------------------------------------------------------------------------

    '--------------------------------------------------------------------------------------
    'LDLG
    '--------------------------------------------------------------------------------------
    Public Shared Function get_name_pump(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As String
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 1
                risultato_string = setpoint_str((1))
            Case 2
                risultato_string = setpoint_str((5))
            Case 3
                risultato_string = setpoint_str((9))
            Case 4
                risultato_string = setpoint_str((13))
            Case 5
                risultato_string = setpoint_str((17))
        End Select
        Return risultato_string
    End Function
    Public Shared Function get_value_pump(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As Integer
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 1
                Return Val(setpoint_str(2))
            Case 2
                Return Val(setpoint_str(6))
            Case 3
                Return Val(setpoint_str(10))
            Case 4
                Return Val(setpoint_str(14))
            Case 5
                Return Val(setpoint_str(18))
        End Select
        Return 0
    End Function
    Public Shared Function get_enable_pump(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As Integer
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 1
                Return Val(setpoint_str(3))
            Case 2
                Return Val(setpoint_str(7))
            Case 3
                Return Val(setpoint_str(11))
            Case 4
                Return Val(setpoint_str(15))
            Case 5
                Return Val(setpoint_str(19))
        End Select
        Return 0
    End Function
    Public Shared Function get_factor_pump(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As Integer
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 1
                Return Val(setpoint_str(4))
            Case 2
                Return Val(setpoint_str(8))
            Case 3
                Return Val(setpoint_str(12))
            Case 4
                Return Val(setpoint_str(16))
            Case 5
                Return Val(setpoint_str(20))
        End Select
        Return 0
    End Function

    Public Shared Function get_value_wm(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As Integer
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 6
                Return Val(setpoint_str(22))
            Case 7
                Return Val(setpoint_str(26))
            Case 8
                Return Val(setpoint_str(30))
            Case 9
                Return Val(setpoint_str(34))
            Case 10
                Return Val(setpoint_str(38))
        End Select
        Return 0
    End Function
    Public Shared Function get_enable_wm(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As Integer
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 6
                Return Val(setpoint_str(23))
            Case 7
                Return Val(setpoint_str(27))
            Case 8
                Return Val(setpoint_str(31))
            Case 9
                Return Val(setpoint_str(35))
            Case 10
                Return Val(setpoint_str(39))
        End Select
        Return 0
    End Function
    Public Shared Function get_factor_wm(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As Integer
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 6
                Return Val(setpoint_str(24))
            Case 7
                Return Val(setpoint_str(28))
            Case 8
                Return Val(setpoint_str(32))
            Case 9
                Return Val(setpoint_str(36))
            Case 10
                Return Val(setpoint_str(40))
        End Select
        Return 0
    End Function
    Public Shared Function get_name_wm(ByVal setpoint_str() As String, ByVal numer_canale As Integer) As String
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 6
                risultato_string = setpoint_str((21))
            Case 7
                risultato_string = setpoint_str((25))
            Case 8
                risultato_string = setpoint_str((29))
            Case 9
                risultato_string = setpoint_str((33))
            Case 10
                risultato_string = setpoint_str((37))
        End Select
        Return risultato_string
    End Function
    Public Shared Function get_name_differential(ByVal setpoint_str() As String) As String
        Dim risultato_string As String = ""
        risultato_string = setpoint_str((41))
        Return risultato_string

    End Function
    Public Shared Function get_operation1_differential(ByVal setpoint_str() As String) As Integer
        Return Val(setpoint_str(42))

        Return 0
    End Function
    Public Shared Function get_operation_differential(ByVal setpoint_str() As String) As Integer
        Return Val(setpoint_str(44))

        Return 0
    End Function
    Public Shared Function get_operation2_differential(ByVal setpoint_str() As String) As Integer
        Return Val(setpoint_str(43))

        Return 0
    End Function
    Public Shared Function get_enable_differential(ByVal setpoint_str() As String) As Integer
        Return Val(setpoint_str(45))

        Return 0
    End Function

    Public Shared Function get_tipo_strumento_ld_lg(ByVal config_str() As String, ByVal numer_canale As Integer, ByVal setpoint_str() As String, ByRef fattore_divisione As Integer) As String
        If numer_canale > 5 Then
            fattore_divisione = Val(config_str(numer_canale - 5))
        Else
            fattore_divisione = Val(config_str(numer_canale))
        End If

        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 1
                risultato_string = setpoint_str((1))
            Case 2
                risultato_string = setpoint_str((5))
            Case 3
                risultato_string = setpoint_str((9))
            Case 4
                risultato_string = setpoint_str((13))
            Case 5
                risultato_string = setpoint_str((17))
            Case 6
                risultato_string = setpoint_str((21))
            Case 7
                risultato_string = setpoint_str((25))
            Case 8
                risultato_string = setpoint_str((29))
            Case 9
                risultato_string = setpoint_str((33))
            Case 10
                risultato_string = setpoint_str((37))

        End Select
        Return risultato_string
    End Function
    Public Shared Function get_pump1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(1))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_pump2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(2))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_pump3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(3))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_pump4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(4))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_pump5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(5))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_wm1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(6))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_wm2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(7))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_wm3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(8))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_wm4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(9))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_wm5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(10))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function get_tot_pump1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(11))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_pump2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(12))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_pump3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(13))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_pump4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(14))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_pump5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(15))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_wm1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(16))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_wm2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(17))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_wm3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(18))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_wm4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(19))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_tot_wm5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(20))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_differential(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(1))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_percent(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(2))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    '--------------------------------------------------------------------------------------
    'LDMA
    '--------------------------------------------------------------------------------------
    Public Shared Function get_tipo_strumento_ld_ma(ByVal config_str() As String, ByVal numer_canale As Integer, ByVal setpoint_str() As String, ByRef fattore_divisione As Integer) As String
        fattore_divisione = Val(config_str(numer_canale))
        Dim risultato_string As String = ""
        Select Case numer_canale
            Case 1
                risultato_string = setpoint_str((1))
            Case 2
                risultato_string = setpoint_str((6))
            Case 3
                risultato_string = setpoint_str((11))
            Case 4
                risultato_string = setpoint_str((16))
            Case 5
                risultato_string = setpoint_str((21))
        End Select
        Return risultato_string
    End Function
    Public Shared Function get_numero_canali_ld_ma(ByVal input_str() As String) As Integer
        Dim numero_canali As Integer = 0
        If Val(input_str(1)) > 0 Then
            numero_canali = numero_canali + 1
        End If
        If Val(input_str(2)) > 0 Then
            numero_canali = numero_canali + 1
        End If
        If Val(input_str(3)) > 0 Then
            numero_canali = numero_canali + 1
        End If
        If Val(input_str(4)) > 0 Then
            numero_canali = numero_canali + 1
        End If
        If Val(input_str(5)) > 0 Then
            numero_canali = numero_canali + 1
        End If
        Return numero_canali
    End Function
    Public Shared Function get_name_level1(ByVal input_str() As String) As String
        Try
            Return input_str(1)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function get_4ma_level1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(2))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_20ma_level1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(3))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_soglia_level1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(4))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_msg_level1(ByVal input_str() As String) As Boolean
        Try
            If input_str(5) = "1" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function get_name_level2(ByVal input_str() As String) As String
        Try
            Return input_str(6)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function get_4ma_level2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(7))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_20ma_level2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(8))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_soglia_level2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(9))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_msg_level2(ByVal input_str() As String) As Boolean
        Try
            If input_str(10) = "1" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function get_name_level3(ByVal input_str() As String) As String
        Try
            Return input_str(11)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function get_4ma_level3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(12))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_20ma_level3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(13))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_soglia_level3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(14))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_msg_level3(ByVal input_str() As String) As Boolean
        Try
            If input_str(15) = "1" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function get_name_level4(ByVal input_str() As String) As String
        Try
            Return input_str(16)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function get_4ma_level4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(17))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_20ma_level4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(18))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_soglia_level4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(19))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_msg_level4(ByVal input_str() As String) As Boolean
        Try
            If input_str(20) = "1" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function get_name_level5(ByVal input_str() As String) As String
        Try
            Return input_str(21)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function get_4ma_level5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(22))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_20ma_level5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(23))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_soglia_level5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(24))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_msg_level5(ByVal input_str() As String) As Boolean
        Try
            If input_str(25) = "1" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    'valori in tempo reale

    Public Shared Function get_level1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(1))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(2))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(3))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(4))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(5))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_day1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(6))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_day2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(7))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_day3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(8))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_day4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(9))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_day5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(10))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_tot1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(11))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_tot2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(12))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_tot3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(13))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_tot4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(14))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_level_tot5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(15))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'valori ma del service

    Public Shared Function get_sevice_ma1(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(1))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_sevice_ma2(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(2))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_sevice_ma3(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(3))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_sevice_ma4(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(4))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Function get_sevice_ma5(ByVal input_str() As String) As Integer
        Try
            Return Val(input_str(5))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    '--------------------------------------------------------------------------------------
    'end LDMA
    '--------------------------------------------------------------------------------------

End Class
