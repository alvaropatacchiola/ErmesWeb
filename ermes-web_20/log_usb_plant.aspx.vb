Imports System.Globalization
Imports System.IO
Public Class log_usb_plant
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load





        Dim numero_file_count As Integer
        Dim numero_file As Integer = 0
        Dim carattere As Integer
        numero_file = Val(Page.Request("numero_file"))
        If numero_file > 0 Then
            'For numero_file_count = 0 To numero_file - 1
            Dim files() As String

            'creazione directory con file per i grafici
            Dim savedFileName As String = Server.MapPath(".")
            savedFileName = savedFileName + "\FileCaricati\"
            Dim pippo As String
            pippo = Session("mid_super").ToString
            If Not Directory.Exists(savedFileName + Session("mid_super").ToString) Then
                Directory.CreateDirectory(savedFileName + Session("mid_super").ToString)
            Else
                ' cancellare tutti i file della directory
                files = Directory.GetFileSystemEntries(savedFileName + Session("mid_super").ToString)
                For Each element As String In files
                    If (Not Directory.Exists(element)) Then
                        File.Delete(Path.Combine(savedFileName + Session("mid_super").ToString, Path.GetFileName(element)))
                    End If
                Next

            End If

            savedFileName = Server.MapPath(".")
            'savedFileName = savedFileName + "\FileCaricati\" + Session("mid_super").ToString + Format(numero_file_count, "0") + ".txt"
            savedFileName = savedFileName + "\FileCaricati\" + Session("mid_super").ToString + "_temp"
            Dim files_load() As String
            files_load = Directory.GetFileSystemEntries(savedFileName)
            For Each element As String In files_load
                Dim file_str_list As String
                file_str_list = Path.GetFileName(element)
                If (InStr(file_str_list, ".txt") <> 0 Or InStr(file_str_list, ".TXT") <> 0) Then
                    Dim sr As New System.IO.StreamReader(element)
                    Try
                        Dim log_final As String = ""
                        Dim carattere_char As Char
                        While Not sr.EndOfStream
                            carattere = sr.Read()
                            If carattere >= 2 Then
                                carattere_char = Chr(carattere)
                                log_final = log_final + carattere_char
                                If carattere_char = "?" Then
                                    Chr(sr.Read())
                                    log_final = log_final + "??"

                                    If InStr(log_final, "USB") <> 0 Then
                                        perform_file_log(log_final)
                                    Else
                                        perform_file_log("LOG USB" + log_final)
                                    End If
                                    log_final = ""
                                End If
                            End If

                        End While
                        sr.Close()
                    Catch ex As Exception
                        sr.Close()
                    End Try
                End If
            Next

            'Next
            Response.Redirect("log_usb_list.aspx")
        End If

    End Sub
    Public Sub perform_file_log(ByVal s2 As String)
        Dim data() As String
        Dim data_label() As String
        Dim data_log() As String
        Dim data_codice() As String
        Dim tipo_strumento As String
        Dim codice_strumento As String
        Dim id_485_stringa As String
        Dim label As String
        Dim j As Integer

        data = s2.Split("#")
        For j = 0 To data.Length - 1 'ricerco l'indice dell'array contenete 35
            If InStr(data(j), "35") <> 0 Then
                Exit For
            End If
        Next

        If data.Length < 11 Then

            id_485_stringa = data(j + 2)

            data_label = data(j + 4).Split(" ")
            tipo_strumento = "02"
            label = get_string(data_label) ' determinazione della label

            'log_stringa = data(j + 7)
            data_log = data(j + 7).Split(" ")

            data_codice = data(j + 6).Split(" ")
            codice_strumento = get_string(data_codice) ' determinazione del codice univoco

        Else
            If j > 1 Then
                j = 1
            End If
            id_485_stringa = data(j + 2)

            tipo_strumento = data(j + 4)
            data_label = data(j + 6).Split(" ")
            label = get_string(data_label) ' determinazione della label

            'log_stringa = data1(j + 9)
            'data3 = data1(j + 8).Split(" ")
            Dim k As Integer
            Dim nesString As String = ""

            For k = 1 To data(j + 9).Length - 1
                If Mid(data(j + 9), k, 1) = " " And Mid(data(j + 9), k + 1, 1) = " " And k < data(j + 9).Length - 1 Then
                    k = k + 1
                End If
                nesString = nesString + Mid(data(j + 9), k, 1)
            Next


            data_log = nesString.Split(" ")

            data_codice = data(j + 8).Split(" ")
            codice_strumento = get_string(data_codice) ' determinazione del codice univoco
            'data2 = log_stringa.Split(" ")

        End If
        If Val(tipo_strumento) > 5 Then
            tipo_strumento = "02"
        End If
        Try

            Dim savedFileName As String = Server.MapPath(".")
            savedFileName = savedFileName + "\FileCaricati\" + Session("mid_super").ToString + "\"
            Select Case tipo_strumento
                Case "01" 'ld
                    Dim data1 As String = ""
                    Dim data2 As String = ""
                    Dim data_str As String = ""
                    Dim temperature_format As String = "0"
                    Try
                        Using reader As StreamReader = New StreamReader(savedFileName + "LD_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    Catch ex As Exception
                        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "LD_" + codice_strumento + "_" + id_485_stringa + "_config.txt", True)
                            writer.WriteLine("01/01/2000")
                            writer.WriteLine("01/01/2000")
                            writer.Close()
                        End Using
                    End Try
                    If data1 = "" Then
                        Using reader As StreamReader = New StreamReader(savedFileName + "LD_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    End If

                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "LD_" + codice_strumento + "_" + id_485_stringa + ".txt", True)
                        writer.WriteLine(prepara_log_ld(data_log, data_str, temperature_format))
                        writer.Close()
                    End Using
                    Dim data_prima_date As Date
                    Dim data_seconda_date As Date
                    Dim data_temp As Date

                    'data_prima_date = Date.Parse(data1)
                    data_prima_date = Date.ParseExact(data1, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_seconda_date = Date.Parse(data2)
                    data_seconda_date = Date.ParseExact(data2, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_temp = Date.Parse(data_str)
                    data_temp = Date.ParseExact(data_str, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'MsgBox("entro4")

                    Dim calcolo_date As Integer
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_prima_date)
                    If calcolo_date > 0 Or data1 = "01/01/2000" Then
                        data1 = data_str
                    End If
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_seconda_date)
                    If calcolo_date < 0 Then
                        data2 = data_str
                    End If
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "LD_" + codice_strumento + "_" + id_485_stringa + "_config.txt", False)
                        writer.WriteLine(data1)
                        writer.WriteLine(data2)
                        'writer.WriteLine(temperature_format)
                        writer.WriteLine("0")
                        writer.Close()
                    End Using
                Case "02" 'max5
                    Dim data1 As String = ""
                    Dim data2 As String = ""
                    Dim data_str As String = ""
                    Dim temperature_format As String = "0"
                    Dim data_format As String = "0"
                    Dim clock_format As String = "0"
                    Dim flow_format As String = "0"
                    Try
                        Using reader As StreamReader = New StreamReader(savedFileName + "max5_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    Catch ex As Exception
                        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "max5_" + codice_strumento + "_" + id_485_stringa + "_config.txt", True)
                            writer.WriteLine("01/01/2000")
                            writer.WriteLine("01/01/2000")
                            writer.Close()
                        End Using
                    End Try
                    If data1 = "" Then
                        Using reader As StreamReader = New StreamReader(savedFileName + "max5_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()

                        End Using
                    End If

                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "max5_" + codice_strumento + "_" + id_485_stringa + ".txt", True)
                        writer.WriteLine(prepara_log_max5(data_log, data_str, data_format, clock_format, temperature_format, flow_format, codice_strumento))
                        writer.Close()
                    End Using
                    Dim data_prima_date As Date
                    Dim data_seconda_date As Date
                    Dim data_temp As Date


                    'data_prima_date = Date.Parse(data1)
                    data_prima_date = Date.ParseExact(data1, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_seconda_date = Date.Parse(data2)
                    data_seconda_date = Date.ParseExact(data2, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_temp = Date.Parse(data_str)
                    data_temp = Date.ParseExact(data_str, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'MsgBox("entro4")

                    Dim calcolo_date As Integer
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_prima_date)
                    If calcolo_date > 0 Or data1 = "01/01/2000" Then
                        data1 = data_str
                    End If
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_seconda_date)
                    If calcolo_date < 0 Then
                        data2 = data_str
                    End If
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "max5_" + codice_strumento + "_" + id_485_stringa + "_config.txt", False)
                        writer.WriteLine(data1)
                        writer.WriteLine(data2)
                        writer.WriteLine(temperature_format)
                        writer.WriteLine(data_format)
                        writer.WriteLine(clock_format)
                        writer.WriteLine(flow_format)
                        writer.Close()
                    End Using
                Case "04" 'WD
                    Dim data1 As String = ""
                    Dim data2 As String = ""
                    Dim data_str As String = ""
                    Dim temperature_format As String = "0"
                    Try
                        Using reader As StreamReader = New StreamReader(savedFileName + "WD_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    Catch ex As Exception
                        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "WD_" + codice_strumento + "_" + id_485_stringa + "_config.txt", True)
                            writer.WriteLine("01/01/2000")
                            writer.WriteLine("01/01/2000")
                            writer.Close()
                        End Using
                    End Try
                    If data1 = "" Then
                        Using reader As StreamReader = New StreamReader(savedFileName + "WD_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()

                        End Using
                    End If

                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "WD_" + codice_strumento + "_" + id_485_stringa + ".txt", True)
                        writer.WriteLine(prepara_log_wd(data_log, data_str, temperature_format))
                        writer.Close()
                    End Using
                    Dim data_prima_date As Date
                    Dim data_seconda_date As Date
                    Dim data_temp As Date


                    'data_prima_date = Date.Parse(data1)
                    data_prima_date = Date.ParseExact(data1, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_seconda_date = Date.Parse(data2)
                    data_seconda_date = Date.ParseExact(data2, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_temp = Date.Parse(data_str)
                    data_temp = Date.ParseExact(data_str, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'MsgBox("entro4")

                    Dim calcolo_date As Integer
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_prima_date)
                    If calcolo_date > 0 Or data1 = "01/01/2000" Then
                        data1 = data_str
                    End If
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_seconda_date)
                    If calcolo_date < 0 Then
                        data2 = data_str
                    End If
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "WD_" + codice_strumento + "_" + id_485_stringa + "_config.txt", False)
                        writer.WriteLine(data1)
                        writer.WriteLine(data2)
                        writer.WriteLine(temperature_format)
                        writer.Close()
                    End Using
                Case "05" 'LDtower
                    Dim data1 As String = ""
                    Dim data2 As String = ""
                    Dim data_str As String = ""
                    Dim temperature_format As String = "0"
                    Dim result_log_tower As String = ""
                    Try
                        Using reader As StreamReader = New StreamReader(savedFileName + "LDTower_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    Catch ex As Exception
                        Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "LDTower_" + codice_strumento + "_" + id_485_stringa + "_config.txt", True)
                            writer.WriteLine("01/01/2000")
                            writer.WriteLine("01/01/2000")
                            writer.Close()
                        End Using
                    End Try
                    If data1 = "" Then
                        Using reader As StreamReader = New StreamReader(savedFileName + "LDTower_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    End If
                    Try
                        result_log_tower = prepara_log_tower(data_log, data_str, temperature_format)
                        Dim sr As New System.IO.StreamReader(savedFileName + "LDTower_" + codice_strumento + "_" + id_485_stringa + ".txt")

                        Do While sr.Peek() >= 0
                            Dim linea As String = ""
                            linea = sr.ReadLine()
                            If InStr(result_log_tower, linea) <> 0 Then
                                result_log_tower = ""
                                Exit Do
                            End If
                        Loop
                        sr.Close()
                    Catch ex As Exception

                    End Try
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "LDTower_" + codice_strumento + "_" + id_485_stringa + ".txt", True)

                        If result_log_tower <> "" Then
                            writer.WriteLine(result_log_tower)
                            writer.Close()
                        End If
                    End Using
                    Dim data_prima_date As Date
                    Dim data_seconda_date As Date
                    Dim data_temp As Date

                    'data_prima_date = Date.Parse(data1)
                    data_prima_date = Date.ParseExact(data1, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_seconda_date = Date.Parse(data2)
                    data_seconda_date = Date.ParseExact(data2, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_temp = Date.Parse(data_str)
                    data_temp = Date.ParseExact(data_str, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'MsgBox("entro4")

                    Dim calcolo_date As Integer
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_prima_date)
                    If calcolo_date > 0 Or data1 = "01/01/2000" Then
                        data1 = data_str
                    End If
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_seconda_date)
                    If calcolo_date < 0 Then
                        data2 = data_str
                    End If
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "LDTower_" + codice_strumento + "_" + id_485_stringa + "_config.txt", False)
                        writer.WriteLine(data1)
                        writer.WriteLine(data2)
                        writer.WriteLine(temperature_format)
                        writer.Close()
                    End Using
                Case "03" 'tower
                    Dim data1 As String = ""
                    Dim data2 As String = ""
                    Dim data_str As String = ""
                    Dim temperature_format As String = "0"
                    Dim result_log_tower As String = ""
                    Try
                        Using reader As StreamReader = New StreamReader(savedFileName + "Tower_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    Catch ex As Exception
                        Try
                            Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "Tower_" + codice_strumento + "_" + id_485_stringa + "_config.txt", True)
                                writer.WriteLine("01/01/2000")
                                writer.WriteLine("01/01/2000")
                                writer.Close()
                            End Using

                        Catch ex1 As Exception

                        End Try
                    End Try
                    If data1 = "" Then
                        Using reader As StreamReader = New StreamReader(savedFileName + "Tower_" + codice_strumento + "_" + id_485_stringa + "_config.txt")
                            ' Read one line from file
                            data1 = reader.ReadLine
                            data2 = reader.ReadLine
                            reader.Close()
                        End Using
                    End If
                    Try
                        result_log_tower = prepara_log_tower(data_log, data_str, temperature_format)
                        Dim sr As New System.IO.StreamReader(savedFileName + "Tower_" + codice_strumento + "_" + id_485_stringa + ".txt")

                        Do While sr.Peek() >= 0
                            Dim linea As String = ""
                            linea = sr.ReadLine()
                            If InStr(result_log_tower, linea) <> 0 Then
                                result_log_tower = ""
                                Exit Do
                            End If
                        Loop
                        sr.Close()
                    Catch ex As Exception

                    End Try
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "Tower_" + codice_strumento + "_" + id_485_stringa + ".txt", True)

                        If result_log_tower <> "" Then
                            writer.WriteLine(result_log_tower)
                            writer.Close()
                        End If
                    End Using
                    Dim data_prima_date As Date
                    Dim data_seconda_date As Date
                    Dim data_temp As Date

                    'data_prima_date = Date.Parse(data1)
                    data_prima_date = Date.ParseExact(data1, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_seconda_date = Date.Parse(data2)
                    data_seconda_date = Date.ParseExact(data2, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                    'data_temp = Date.Parse(data_str)
                    data_temp = Date.ParseExact(data_str, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'MsgBox("entro4")

                    Dim calcolo_date As Integer
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_prima_date)
                    If calcolo_date > 0 Or data1 = "01/01/2000" Then
                        data1 = data_str
                    End If
                    calcolo_date = DateDiff(DateInterval.Day, data_temp, data_seconda_date)
                    If calcolo_date < 0 Then
                        data2 = data_str
                    End If
                    Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(savedFileName + "Tower_" + codice_strumento + "_" + id_485_stringa + "_config.txt", False)
                        writer.WriteLine(data1)
                        writer.WriteLine(data2)
                        writer.WriteLine(temperature_format)
                        writer.Close()
                    End Using

            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Function get_string(ByVal dato() As String) As String
        Dim k As Integer = 0
        Dim code As String = ""
        Try
            For k = 0 To dato.Length - 1 ' determinazione del codice univoco
                code = code + Chr(Val(dato(k)))
            Next

        Catch ex As Exception
            Return "null"
        End Try
        Return code
    End Function
    Private Function crea_valore(ByVal valore_string As Integer) As String
        If valore_string < 10 Then
            Return Format(valore_string, "00")
        Else
            Return valore_string.ToString()
        End If
    End Function

    Public Function prepara_log_max5(ByVal data_log() As String, ByRef data_current As String, ByRef data_format As String, ByRef clock_format As String, ByRef temperature_format As String, ByRef flow_format As String, ByVal codice_strumento As String) As String
        Dim matrice(100, 1) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim stringa_finale As String = ""
        Dim data_finale As String = ""

        Dim ch1_val As Boolean = False
        Dim ch2_val As Boolean = False
        Dim ch3_val As Boolean = False
        Dim ch4_val As Boolean = False
        Dim ch5_val As Boolean = False
        Dim temp_val As Boolean = False
        Dim wm_val As Boolean = False
        Dim aa1 As Boolean = False
        Dim aa1_val As String = ""
        Dim aa2 As Boolean = False
        Dim aa2_val As String = ""
        Dim aa3 As Boolean = False
        Dim aa3_val As String = ""
        Dim aa4 As Boolean = False
        Dim aa4_val As String = ""
        Dim aa5 As Boolean = False
        Dim aa5_val As String = ""
        Dim ab1 As Boolean = False
        Dim ab1_val As String = ""
        Dim ab2 As Boolean = False
        Dim ab2_val As String = ""
        Dim ab3 As Boolean = False
        Dim ab3_val As String = ""
        Dim ab4 As Boolean = False
        Dim ab4_val As String = ""
        Dim ab5 As Boolean = False
        Dim ab5_val As String = ""
        Dim ad1 As Boolean = False
        Dim ad1_val As String = ""
        Dim ad2 As Boolean = False
        Dim ad2_val As String = ""
        Dim ad3 As Boolean = False
        Dim ad3_val As String = ""
        Dim ad4 As Boolean = False
        Dim ad4_val As String = ""
        Dim ad5 As Boolean = False
        Dim ad5_val As String = ""
        Dim ar1 As Boolean = False
        Dim ar1_val As String = ""
        Dim ar2 As Boolean = False
        Dim ar2_val As String = ""
        Dim ar3 As Boolean = False
        Dim ar3_val As String = ""
        Dim ar4 As Boolean = False
        Dim ar4_val As String = ""
        Dim ar5 As Boolean = False
        Dim ar5_val As String = ""

        Dim da1 As Boolean = False
        Dim db1 As Boolean = False
        Dim pa1 As Boolean = False
        Dim pa1_val As Integer = 0
        Dim pb1 As Boolean = False
        Dim pb1_val As Integer = 0
        Dim ma1 As Boolean = False
        Dim ma1_val As Integer = 0

        Dim da2 As Boolean = False
        Dim db2 As Boolean = False
        Dim pa2 As Boolean = False
        Dim pa2_val As Integer = 0
        Dim pb2 As Boolean = False
        Dim pb2_val As Integer = 0
        Dim ma2 As Boolean = False
        Dim ma2_val As Integer = 0

        Dim da3 As Boolean = False
        Dim db3 As Boolean = False
        Dim pa3 As Boolean = False
        Dim pa3_val As Integer = 0
        Dim pb3 As Boolean = False
        Dim pb3_val As Integer = 0
        Dim ma3 As Boolean = False
        Dim ma3_val As Integer = 0

        Dim da4 As Boolean = False
        Dim db4 As Boolean = False
        Dim pa4 As Boolean = False
        Dim pa4_val As Integer = 0
        Dim pb4 As Boolean = False
        Dim pb4_val As Integer = 0
        Dim ma4 As Boolean = False
        Dim ma4_val As Integer = 0

        Dim da5 As Boolean = False
        Dim db5 As Boolean = False
        Dim pa5 As Boolean = False
        Dim pa5_val As Integer = 0
        Dim pb5 As Boolean = False
        Dim pb5_val As Integer = 0
        Dim ma5 As Boolean = False
        Dim ma5_val As Integer = 0

        Dim flow_val As Boolean = False
        Dim fml_val As Boolean = False

        Dim valore_ch1 As Single = 0
        Dim valore_ch2 As Single = 0
        Dim valore_ch3 As Single = 0
        Dim valore_ch4 As Single = 0
        Dim valore_ch5 As Single = 0
        Dim valore_temp As Single = 0
        Dim valore_flow As String = ""

        Dim canale1_str As String = ""
        Dim canale2_str As String = ""
        Dim canale3_str As String = ""
        Dim canale4_str As String = ""
        Dim canale5_str As String = ""

        Dim pos_virgola_ch1 As Integer = 0
        Dim pos_virgola_ch2 As Integer = 0
        Dim pos_virgola_ch3 As Integer = 0
        Dim pos_virgola_ch4 As Integer = 0
        Dim pos_virgola_ch5 As Integer = 0

        Dim scala_ch1 As Integer = 0
        Dim scala_ch2 As Integer = 0
        Dim scala_ch3 As Integer = 0
        Dim scala_ch4 As Integer = 0
        Dim scala_ch5 As Integer = 0

        For i = 1 To data_log.Length - 2
            matrice(j, 0) = Val(data_log(i))
            matrice(j, 1) = Val(data_log(i + 1))
            If matrice(j, 0) = "126" Then
                matrice(j, 0) = "13"
            End If
            If matrice(j, 1) = "126" Then
                matrice(j, 1) = "13"
            End If
            If matrice(j, 0) = "127" Then
                matrice(j, 0) = "38"
            End If
            If matrice(j, 1) = "127" Then
                matrice(j, 1) = "38"
            End If

            j = j + 1
            i = i + 1

            If i > data_log.Length - 1 Or j > 99 Then
                Exit For
            End If
        Next
        If matrice(2, 1) = "0" Then
            data_current = "01/01/2000"
            Return ""
        End If
        data_current = crea_valore(matrice(0, 1)) + "/" + crea_valore(matrice(1, 1)) + "/" + (2000 + matrice(2, 1)).ToString
        data_finale = "Date.UTC(" + (2000 + matrice(2, 1)).ToString + "," + (matrice(1, 1) - 1).ToString + "," + matrice(0, 1).ToString + "," + matrice(3, 1).ToString + "," + matrice(4, 1).ToString + ")"
        For i = 5 To 99
            'mese giorno e anno
            Select Case Val(matrice(i, 0))
                Case 6 To 8
                    If ch1_val = False Then
                        valore_ch1 = Val(matrice(i, 1) * 100) + Val(matrice(i + 2, 1))
                        scala_ch1 = Val(matrice(i + 1, 1))
                        i = i + 2
                        ch1_val = True
                    End If
                Case 9 To 11
                    If ch2_val = False Then
                        valore_ch2 = Val(matrice(i, 1) * 100) + Val(matrice(i + 2, 1))
                        scala_ch2 = Val(matrice(i + 1, 1))
                        i = i + 2
                        ch2_val = True
                    End If
                Case 12 To 14
                    If ch3_val = False Then
                        valore_ch3 = Val(matrice(i, 1) * 100) + Val(matrice(i + 2, 1))
                        scala_ch3 = Val(matrice(i + 1, 1))
                        i = i + 2
                        ch3_val = True
                    End If
                Case 15 To 17
                    If ch4_val = False Then
                        valore_ch4 = Val(matrice(i, 1) * 100) + Val(matrice(i + 2, 1))
                        scala_ch4 = Val(matrice(i + 1, 1))
                        i = i + 2
                        ch4_val = True
                    End If
                Case 18 To 20
                    If ch5_val = False Then
                        valore_ch5 = Val(matrice(i, 1) * 100) + Val(matrice(i + 2, 1))
                        scala_ch5 = Val(matrice(i + 1, 1))
                        i = i + 2
                        ch5_val = True
                    End If
                Case 26 'Aa1
                    If Val(matrice(i, 1)) = 1 Then
                        aa1_val = "1"
                    Else
                        aa1_val = "0"
                    End If
                    aa1 = True
                Case 27 'Ab1
                    If Val(matrice(i, 1)) = 1 Then
                        ab1_val = "1"
                    Else
                        ab1_val = "0"
                    End If
                    ab1 = True
                Case 28 'Ad1
                    If Val(matrice(i, 1)) = 1 Then
                        ad1_val = "1"
                    Else
                        ad1_val = "0"
                    End If
                    ad1 = True
                Case 29 'Ar1
                    If Val(matrice(i, 1)) = 1 Then
                        ar1_val = "1"
                    Else
                        ar1_val = "0"
                    End If
                    ar1 = True
                Case 35 'Aa2
                    If Val(matrice(i, 1)) = 1 Then
                        aa2_val = "1"
                    Else
                        aa2_val = "0"
                    End If
                    aa2 = True
                Case 36 'Ab2
                    If Val(matrice(i, 1)) = 1 Then
                        ab2_val = "1"
                    Else
                        ab2_val = "0"
                    End If
                    ab2 = True
                Case 37 'Ad2
                    If Val(matrice(i, 1)) = 1 Then
                        ad2_val = "1"
                    Else
                        ad2_val = "0"
                    End If
                    ad2 = True
                Case 38 'Ar2
                    If Val(matrice(i, 1)) = 1 Then
                        ar2_val = "1"
                    Else
                        ar2_val = "0"
                    End If
                    ar2 = True
                Case 44 'Aa3
                    If Val(matrice(i, 1)) = 1 Then
                        aa3_val = "1"
                    Else
                        aa3_val = "0"
                    End If
                    aa3 = True
                Case 45 'Ab3
                    If Val(matrice(i, 1)) = 1 Then
                        ab3_val = "1"
                    Else
                        ab3_val = "0"
                    End If
                    ab3 = True
                Case 46 'Ad3
                    If Val(matrice(i, 1)) = 1 Then
                        ad3_val = "1"
                    Else
                        ad3_val = "0"
                    End If
                    ad3 = True
                Case 47 'Ar3
                    If Val(matrice(i, 1)) = 1 Then
                        ar3_val = "1"
                    Else
                        ar3_val = "0"
                    End If
                    ar3 = True
                Case 53 'Aa4
                    If Val(matrice(i, 1)) = 1 Then
                        aa4_val = "1"
                    Else
                        aa4_val = "0"
                    End If
                    aa4 = True
                Case 54 'Ab4
                    If Val(matrice(i, 1)) = 1 Then
                        ab4_val = "1"
                    Else
                        ab4_val = "0"
                    End If
                    ab4 = True
                Case 55 'Ad4
                    If Val(matrice(i, 1)) = 1 Then
                        ad4_val = "1"
                    Else
                        ad4_val = "0"
                    End If
                    ad4 = True
                Case 56 'Ar4
                    If Val(matrice(i, 1)) = 1 Then
                        ar4_val = "1"
                    Else
                        ar4_val = "0"
                    End If
                    ar4 = True
                Case 62 'Aa5
                    If Val(matrice(i, 1)) = 1 Then
                        aa5_val = "1"
                    Else
                        aa5_val = "0"
                    End If
                    aa5 = True
                Case 63 'Ab5
                    If Val(matrice(i, 1)) = 1 Then
                        ab5_val = "1"
                    Else
                        ab5_val = "0"
                    End If
                    ab5 = True
                Case 64 'Ad5
                    If Val(matrice(i, 1)) = 1 Then
                        ad5_val = "1"
                    Else
                        ad5_val = "0"
                    End If
                    ad5 = True
                Case 65 'Ar5
                    If Val(matrice(i, 1)) = 1 Then
                        ar5_val = "1"
                    Else
                        ar5_val = "0"
                    End If
                    ar5 = True
                Case 21
                    If Val(matrice(i, 1)) = 1 Then
                        da1 = True
                    Else
                        da1 = False
                    End If
                Case 22
                    If Val(matrice(i, 1)) = 1 Then
                        db1 = True
                    Else
                        db1 = False
                    End If
                Case 23
                    pa1_val = Val(matrice(i, 1))
                    pa1 = True
                Case 24
                    pb1_val = Val(matrice(i, 1))
                    pb1 = True
                Case 25
                    ma1_val = Val(matrice(i, 1))
                    ma1 = True


                Case 30
                    If Val(matrice(i, 1)) = 1 Then
                        da2 = True
                    Else
                        da2 = False
                    End If

                Case 31
                    If Val(matrice(i, 1)) = 1 Then
                        db2 = True
                    Else
                        db2 = False
                    End If
                Case 32
                    pa2_val = Val(matrice(i, 1))
                    pa2 = True
                Case 33
                    ma2_val = Val(matrice(i, 1))
                    ma2 = True
                Case 34
                    ma2_val = Val(matrice(i, 1))
                    ma2 = True


                Case 39
                    If Val(matrice(i, 1)) = 1 Then
                        da3 = True
                    Else
                        da3 = False
                    End If

                Case 40
                    If Val(matrice(i, 1)) = 1 Then
                        db3 = True
                    Else
                        db3 = False
                    End If
                Case 41
                    pa3_val = Val(matrice(i, 1))
                    pa3 = True

                Case 42
                    pb3_val = Val(matrice(i, 1))
                    pb3 = True
                Case 43
                    ma3_val = Val(matrice(i, 1))
                    ma3 = True

                Case 48
                    If Val(matrice(i, 1)) = 1 Then
                        da4 = True
                    Else
                        da4 = False
                    End If
                Case 49
                    If Val(matrice(i, 1)) = 1 Then
                        db4 = True
                    Else
                        db4 = False
                    End If
                Case 50
                    pa4_val = Val(matrice(i, 1))
                    pa4 = True
                Case 51
                    pb4_val = Val(matrice(i, 1))
                    pb4 = True
                Case 52
                    ma4_val = Val(matrice(i, 1))
                    ma4 = True

                Case 57
                    If Val(matrice(i, 1)) = 1 Then
                        da5 = True
                    Else
                        da5 = False
                    End If

                Case 58
                    If Val(matrice(i, 1)) = 1 Then
                        db5 = True
                    Else
                        db5 = False
                    End If
                Case 59
                    pa5_val = Val(matrice(i, 1))
                    pa5 = True
                Case 60
                    pb5_val = Val(matrice(i, 1))
                    pb5 = True
                Case 61
                    ma5_val = Val(matrice(i, 1))
                    ma5 = True
                Case 81 To 82
                    valore_temp = ((matrice(i, 1) * 10) + matrice(i + 1, 1)) / 10
                    i = i + 1
                    temp_val = True
                Case 83 To 84
                    wm_val = True

                Case 76
                    If matrice(i, 1) = 1 Then
                        valore_flow = "0"
                    Else
                        valore_flow = "1"
                    End If
                    flow_val = True
                    'Exit For
                Case 90 'data type
                    data_format = Format(matrice(i, 1), "0")
                Case 91 'clock type
                    clock_format = Format(matrice(i, 1), "0")
                Case 93 ' temperatura
                    temperature_format = Format(matrice(i, 1), "0")
                Case 94 ' fmeter unit
                    flow_format = Format(matrice(i, 1), "0")
                Case 95
                    pos_virgola_ch1 = get_divide(matrice(i, 1), matrice(i + 1, 1), scala_ch1)
                    canale1_str = get_canale(matrice(i, 1), matrice(i + 1, 1), 1, scala_ch1)
                Case 97
                    pos_virgola_ch2 = get_divide(matrice(i, 1), matrice(i + 1, 1), scala_ch2)
                    canale2_str = get_canale(matrice(i, 1), matrice(i + 1, 1), 2, scala_ch2)
                Case 99
                    pos_virgola_ch3 = get_divide(matrice(i, 1), matrice(i + 1, 1), scala_ch3)
                    canale3_str = get_canale(matrice(i, 1), matrice(i + 1, 1), 3, scala_ch3)
                Case 101
                    pos_virgola_ch4 = get_divide(matrice(i, 1), matrice(i + 1, 1), scala_ch4)
                    canale4_str = get_canale(matrice(i, 1), matrice(i + 1, 1), 4, scala_ch4)
                Case 103
                    pos_virgola_ch5 = get_divide(matrice(i, 1), matrice(i + 1, 1), scala_ch5)
                    canale5_str = get_canale(matrice(i, 1), matrice(i + 1, 1), 5, scala_ch5)

            End Select

        Next
        If codice_strumento = "284154" Then
            pos_virgola_ch5 = 1000
            canale5_str = "LDO"

        End If
        stringa_finale = canale1_str + "|" + canale2_str + "|" + canale3_str + "|" + canale4_str + "|" + canale5_str + "|"
        If ch1_val Then
            valore_ch1 = valore_ch1 / pos_virgola_ch1
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch1.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_val Then
            valore_ch2 = valore_ch2 / pos_virgola_ch2
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch2.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch3_val Then
            valore_ch3 = valore_ch3 / pos_virgola_ch3
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch3.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch4_val Then
            valore_ch4 = valore_ch4 / pos_virgola_ch4
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch4.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch5_val Then
            If pos_virgola_ch5 = 0 Then
                pos_virgola_ch5 = 1
            End If
            valore_ch5 = valore_ch5 / pos_virgola_ch5
                stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch5.ToString(), ",", ".") + "|"
            Else
                stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If aa1 Then
            stringa_finale = stringa_finale + data_finale + "," + aa1_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ab1 Then
            stringa_finale = stringa_finale + data_finale + "," + ab1_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ad1 Then
            stringa_finale = stringa_finale + data_finale + "," + ad1_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ar1 Then
            stringa_finale = stringa_finale + data_finale + "," + ar1_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If aa2 Then
            stringa_finale = stringa_finale + data_finale + "," + aa2_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ab2 Then
            stringa_finale = stringa_finale + data_finale + "," + ab2_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ad2 Then
            stringa_finale = stringa_finale + data_finale + "," + ad2_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ar2 Then
            stringa_finale = stringa_finale + data_finale + "," + ar2_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If aa3 Then
            stringa_finale = stringa_finale + data_finale + "," + aa3_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ab3 Then
            stringa_finale = stringa_finale + data_finale + "," + ab3_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ad3 Then
            stringa_finale = stringa_finale + data_finale + "," + ad3_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ar3 Then
            stringa_finale = stringa_finale + data_finale + "," + ar3_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If aa4 Then
            stringa_finale = stringa_finale + data_finale + "," + aa4_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ab4 Then
            stringa_finale = stringa_finale + data_finale + "," + ab4_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ad4 Then
            stringa_finale = stringa_finale + data_finale + "," + ad4_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ar4 Then
            stringa_finale = stringa_finale + data_finale + "," + ar4_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If aa5 Then
            stringa_finale = stringa_finale + data_finale + "," + aa5_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ab5 Then
            stringa_finale = stringa_finale + data_finale + "," + ab5_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ad5 Then
            stringa_finale = stringa_finale + data_finale + "," + ad5_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If ar5 Then
            stringa_finale = stringa_finale + data_finale + "," + ar5_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If flow_val Then
            stringa_finale = stringa_finale + data_finale + "," + valore_flow + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"

        End If

        If temp_val Then

            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_temp.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        Return stringa_finale
    End Function
    Private Function get_divide(ByVal indice As Integer, ByVal indice1 As Integer, ByVal indice2 As Integer) As Integer
        Select Case indice
            Case 1
                Return 100
            Case 2
                Return 1
            Case 3
                indice1 = indice2 / 10
                Select Case indice1
                    Case 0, 1, 4, 6, 10, 14
                        Return 10
                    Case 2, 5, 7, 8, 9, 11, 15, 18, 19, 20, 21
                        Return 100
                    Case 3, 12, 16
                        Return 1000
                    Case 13, 17
                        Return 1
                End Select
            Case 4
                Select Case indice1
                    Case 0
                        Return 1
                    Case 3
                        Return 10
                    Case 1
                        Return 1000
                    Case 2
                        Return 100
                End Select

            Case 5
                indice1 = indice2 / 10
                Select Case indice1
                    Case 0, 3
                        Return 10
                    Case 1
                        Return 1
                    Case 2
                        Return 100
                End Select
            Case 6
                Return 1

            Case Else
                Return 1

        End Select

    End Function
    Private Function get_canale(ByVal indice As Integer, ByVal indice1 As Integer, ByVal canale_s As Integer, ByVal indice2 As Integer) As String
        Select Case indice
            Case 1
                Return "Ch" + Format(canale_s, "0") + " pH"
            Case 2
                Return "Ch" + Format(canale_s, "0") + " mV"
            Case 3
                indice1 = indice2 / 10
                Select Case indice1
                    Case 0, 1, 2, 3, 6, 7, 8, 9, 20
                        Return "Ch" + Format(canale_s, "0") + " Cl2"
                    Case 4, 5, 19
                        Return "Ch" + Format(canale_s, "0") + " ClO2"
                    Case 10, 11
                        Return "Ch" + Format(canale_s, "0") + " Clt"
                    Case 12, 13
                        Return "Ch" + Format(canale_s, "0") + " H2O2"
                    Case 14, 15
                        Return "Ch" + Format(canale_s, "0") + " O3"
                    Case 16, 17
                        Return "Ch" + Format(canale_s, "0") + " PAA"
                    Case 18
                        Return "Ch" + Format(canale_s, "0") + " O2"
                    Case 21
                        Return "Ch" + Format(canale_s, "0") + " Br2"
                End Select
            Case 4
                Return "Ch" + Format(canale_s, "0") + " NTU"
            Case 5
                indice1 = indice2 / 10
                Select Case indice1
                    Case 0, 1
                        Return "Ch" + Format(canale_s, "0") + " uS"
                    Case 2, 3
                        Return "Ch" + Format(canale_s, "0") + " mS"
                End Select
            Case 6
                Return ""
            Case Else
                Return ""
        End Select

    End Function

    Public Function prepara_log_tower(ByVal data_log() As String, ByRef data_current As String, ByRef temperature_format As String) As String
        Dim matrice(100, 1) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim stringa_finale As String = ""

        Dim ch1_val As Boolean = False
        Dim ch2_val As Boolean = False
        Dim ch3_val As Boolean = False
        Dim valore_ch1 As Single = 0
        Dim valore_ch2 As Single = 0
        Dim valore_ch3 As Single = 0
        Dim cd_high As Boolean = False
        Dim cd_low As Boolean = False
        Dim bleed_timeout As Boolean = False
        Dim flow As Boolean = False
        Dim inhib_lev As Boolean = False
        Dim prebio1_lev As Boolean = False
        Dim prebio2_lev As Boolean = False
        Dim bio1_lev As Boolean = False
        Dim bio2_lev As Boolean = False
        Dim ch2_high As Boolean = False
        Dim ch2_low As Boolean = False
        Dim ch2_level As Boolean = False
        Dim ch3_high As Boolean = False
        Dim ch3_level As Boolean = False
        Dim ch3_low As Boolean = False
        Dim tot_input As Boolean = False
        Dim tot_bleed As Boolean = False
        Dim temperatura As Boolean = False
        Dim data_finale As String = ""
        Dim tot_input_val As String = ""
        Dim tot_bleed_val As String = ""
        Dim temperatura_val As Single = 0

        Dim valore1_tower As Integer = 0
        Dim valore2_tower As Integer = 0
        Dim valore3_tower As Integer = 0
        Dim tre_canali As Boolean = False
        Dim tipo_sonda_tre_canali As Integer
        Dim tipo_sonda_due_canali As Integer
        Dim canale1_str As String = ""
        Dim canale2_str As String = ""
        Dim canale3_str As String = ""
        Dim pos_virgola_ch1 As Integer
        Dim pos_virgola_ch2 As Integer
        Dim pos_virgola_ch3 As Integer

        Dim tower_induttiva As Boolean = False


        canale1_str = "CD"
        canale2_str = ""
        canale3_str = ""
        pos_virgola_ch1 = 4


        For i = 1 To data_log.Length - 2
            matrice(j, 0) = Val(data_log(i))
            matrice(j, 1) = Val(data_log(i + 1))
            If matrice(j, 0) = "126" Then
                matrice(j, 0) = "13"
            End If
            If matrice(j, 1) = "126" Then
                matrice(j, 1) = "13"
            End If
            If matrice(j, 0) = "127" Then
                matrice(j, 0) = "38"
            End If
            If matrice(j, 1) = "127" Then
                matrice(j, 1) = "38"
            End If

            j = j + 1
            i = i + 1

            If i > data_log.Length - 1 Or j > 99 Then
                Exit For
            End If
        Next
        If matrice(2, 1) = "0" Then
            data_current = "01/01/2000"
            Return ""
        End If
        data_current = crea_valore(matrice(0, 1)) + "/" + crea_valore(matrice(1, 1)) + "/" + (2000 + matrice(2, 1)).ToString
        data_finale = "" + (2000 + matrice(2, 1)).ToString + "," + (matrice(1, 1) - 1).ToString + "," + matrice(0, 1).ToString + "," + matrice(3, 1).ToString + "," + matrice(4, 1).ToString + ""
        For i = 5 To 99
            Select Case Val(matrice(i, 0))
                Case 49 'data type
                    ch3_low = True
                    valore1_tower = matrice(i, 1)
                Case 50
                    ch3_level = True
                    valore2_tower = matrice(i, 1)
                Case 51
                    valore3_tower = matrice(i, 1)
                    'Case 38 ' è presente il valore del 2 canali
                    '    tipo_sonda_due_canali = matrice(i - 1, 1)
                    'Case 46 ' è presente il valore del 3 canali
                    '    tre_canali = True
                    '    tipo_sonda_tre_canali = matrice(i - 1, 1)
                Case 10 'data type
                    temperature_format = Format(Val(matrice(i, 1)), "0")
                    If temperature_format = "1" Then
                        temperature_format = "0"
                    Else
                        temperature_format = "1"
                    End If
                    ' temperatura = temperature_format
                Case 6 To 7
                    valore_ch1 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    i = i + 1
                    ch1_val = True

                Case 38 To 39
                    tipo_sonda_due_canali = matrice(i - 1, 1)

                    valore_ch2 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    i = i + 1
                    ch2_val = True
                Case 46 To 47
                    tre_canali = True
                    tipo_sonda_tre_canali = matrice(i - 1, 1)

                    valore_ch3 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    i = i + 1
                    ch3_val = True
                Case 11
                    cd_high = True
                Case 12
                    cd_low = True
                Case 13
                    bleed_timeout = True
                Case 14
                    flow = True
                Case 15
                    inhib_lev = True
                Case 16
                    prebio1_lev = True
                Case 17
                    prebio2_lev = True
                Case 18
                    bio1_lev = True
                Case 19
                    bio2_lev = True
                Case 45
                    If Val(matrice(i, 1)) = 1 Then
                        tower_induttiva = True
                    End If

                Case 40
                    'cd_high = True
                    ch2_high = True
                Case 41
                    'cd_low = True
                    ch2_low = True
                Case 42
                    ch2_level = True
                Case 48
                    'cd_high = True
                    ch3_high = True
                    'Case 49
                    '    'cd_low = True
                    '    ch3_low = True
                    'Case 50
                    '    ch3_level = True
                Case 28 To 32
                    If tot_input = False Then
                        tot_input = True
                        tot_input_val = Format(Val(matrice(i, 1)), "00") + Format(Val(matrice(i + 1, 1)), "00") + Format(Val(matrice(i + 2, 1)), "00") + Format(Val(matrice(i + 3, 1)), "00") + Format(Val(matrice(i + 4, 1)), "00")
                        i = i + 4
                    End If
                Case 33 To 37
                    If tot_bleed = False Then
                        tot_bleed = True
                        tot_bleed_val = Format(Val(matrice(i, 1)), "00") + Format(Val(matrice(i + 1, 1)), "00") + Format(Val(matrice(i + 2, 1)), "00") + Format(Val(matrice(i + 3, 1)), "00") + Format(Val(matrice(i + 4, 1)), "00")
                        i = i + 4
                    End If
                Case 8 To 9
                    'If temperatura = "1" Then '°F
                    '    condition_temperatura = condition_temperatura + " And (Temperatura  ='" + Format(matrice(i, 1), "00") + Format(matrice(i + 1, 1), "0") + "')"
                    '    insert_temperatura = insert_temperatura + ",'" + Format(matrice(i, 1), "00") + Format(matrice(i + 1, 1), "0") + "'"
                    'Else '°C
                    temperatura_val = ((matrice(i, 1) * 100) + matrice(i + 1, 1)) / 10
                    'End If
                    i = i + 1
                    temperatura = True
            End Select
        Next

        If tre_canali Then
            canale1_str = "CD"
            pos_virgola_ch1 = 4
            canale2_str = "pH"
            pos_virgola_ch2 = 2
            If tipo_sonda_tre_canali = 0 Then
                canale3_str = "mV"
                pos_virgola_ch3 = 4
            Else
                canale3_str = "Cl"
                pos_virgola_ch3 = get_sonda_tower(tipo_sonda_tre_canali)
            End If
        Else
            If valore1_tower = 0 And valore2_tower = 0 And valore3_tower = 0 Then
            Else
                If valore1_tower = 1 And valore2_tower = 6 And valore3_tower = 6 Then 'cd
                    canale1_str = "CD"
                    pos_virgola_ch1 = 4
                    canale2_str = ""
                    canale3_str = ""
                End If
                If valore1_tower = 1 And valore2_tower = 2 And valore3_tower = 6 Then 'cd ph
                    canale1_str = "CD"
                    pos_virgola_ch1 = 4
                    canale2_str = "pH"
                    pos_virgola_ch2 = 2
                    canale3_str = ""
                End If
                If valore1_tower = 1 And valore2_tower = 3 And valore3_tower = 6 Then 'cd mV
                    canale1_str = "CD"
                    pos_virgola_ch1 = 4
                    canale2_str = "mV"
                    pos_virgola_ch2 = 4
                    canale3_str = ""
                End If
                If valore1_tower = 1 And valore2_tower = 4 And valore3_tower = 6 Then 'cd cl
                    canale1_str = "CD"
                    pos_virgola_ch1 = 4
                    canale2_str = "cl"
                    pos_virgola_ch2 = get_sonda_tower(tipo_sonda_due_canali)
                    canale3_str = ""
                End If
                If valore1_tower = 1 And valore2_tower = 1 And valore3_tower = 6 Then 'cd cd
                    canale1_str = "CD"
                    pos_virgola_ch1 = 4
                    canale2_str = "CD"
                    pos_virgola_ch2 = 4
                    canale3_str = ""
                End If

            End If
        End If
        stringa_finale = canale1_str + "|" + canale2_str + "|" + canale3_str + "|"
        If ch1_val Then
            valore_ch1 = return_lettura(pos_virgola_ch1, valore_ch1)
            If tower_induttiva Then
                valore_ch1 = valore_ch1 * 10
            End If
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch1.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_val Then
            valore_ch2 = return_lettura(pos_virgola_ch2, valore_ch2)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch2.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch3_val Then
            valore_ch3 = return_lettura(pos_virgola_ch3, valore_ch3)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch3.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If cd_high Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If cd_low Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If bleed_timeout Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If flow Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If inhib_lev Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If prebio1_lev Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If prebio2_lev Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If bio1_lev Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If bio2_lev Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_high Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_low Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_level Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch3_high Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch3_low Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch3_level Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If tot_input Then
            stringa_finale = stringa_finale + data_finale + "," + tot_input_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If tot_bleed Then
            stringa_finale = stringa_finale + data_finale + "," + tot_bleed_val + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If temperatura Then
            stringa_finale = stringa_finale + data_finale + "," + Replace(temperatura_val.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        Return stringa_finale

    End Function
    Function get_sonda_tower(ByVal Tipo_Sonda As Integer) As Integer
        Select Case Tipo_Sonda
            Case 0 To 1
                'alvaro per log
                Return 1 'x.xxx
            Case 2
                'alvaro per log
                Return 2 'xx.xx
            Case 3
                'alvaro per log
                Return 3 'xxx.x
            Case 4
                'alvaro per log
                Return 1 'x.xxx
            Case 5
                'alvaro per log
                Return 2 'xx.xx
            Case 6
                'alvaro per log
                Return 1 'x.xxx
            Case 7 To 11
                'alvaro per log
                Return 2 'xx.xx
            Case 12
                'alvaro per log
                Return 3 'xx.xx
            Case 13
                'alvaro per log
                Return 2 'xx.xx
            Case 14
                'alvaro per log
                Return 1 'x.xxx

        End Select
    End Function
    Public Function prepara_log_ld(ByVal data_log() As String, ByRef data_current As String, ByRef temperature_format As String) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim stringa_finale As String = ""

        Dim data_finale As String = ""
        Dim matrice(100, 1) As String
        Dim ch1_val As Boolean = False
        Dim ch2_val As Boolean = False
        Dim ch3_val As Boolean = False
        Dim allarme_d1 As Boolean = False
        Dim allarme_d2 As Boolean = False
        Dim allarme_p1 As Boolean = False
        Dim allarme_p2 As Boolean = False
        Dim allarme_s1 As Boolean = False
        Dim allarme_s2 As Boolean = False
        Dim livello1 As Boolean = False
        Dim livello2 As Boolean = False
        Dim livello3 As Boolean = False
        Dim flow_val As Boolean = False
        Dim stby As Boolean = False
        Dim stby_en As Boolean = False
        Dim m3h As Single = 0
        Dim m3h_bool As Boolean = False
        Dim tot_iput As Single = 0
        Dim tot_input_bool As Boolean = False

        Dim temperatura As Boolean = False
        Dim valore_ch1 As Single = 0
        Dim valore_ch2 As Single = 0
        Dim valore_ch3 As Single = 0
        Dim temperatura_val As Single = 0
        Dim canale1_str As String = ""
        Dim canale2_str As String = ""
        Dim canale3_str As String = ""
        Dim pos_virgola_ch1 As Integer
        Dim pos_virgola_ch2 As Integer
        Dim pos_virgola_ch3 As Integer


        For i = 1 To data_log.Length - 2
            matrice(j, 0) = Val(data_log(i))
            matrice(j, 1) = Val(data_log(i + 1))
            If matrice(j, 0) = "126" Then
                matrice(j, 0) = "13"
            End If
            If matrice(j, 1) = "126" Then
                matrice(j, 1) = "13"
            End If
            If matrice(j, 0) = "127" Then
                matrice(j, 0) = "38"
            End If
            If matrice(j, 1) = "127" Then
                matrice(j, 1) = "38"
            End If

            j = j + 1
            i = i + 1

            If i > data_log.Length - 1 Or j > 99 Then
                Exit For
            End If
        Next
        data_current = crea_valore(matrice(0, 1)) + "/" + crea_valore(matrice(1, 1)) + "/" + (2000 + matrice(2, 1)).ToString
        ' data_finale = "Date.UTC(" + 2000 + matrice(2, 1).ToString + "," + (matrice(1, 1) - 1).ToString + "," + matrice(0, 1).ToString + "," + matrice(3, 1).ToString + "," + matrice(4, 1).ToString + ")"
        data_finale = "" + (2000 + matrice(2, 1)).ToString + "," + (matrice(1, 1) - 1).ToString + "," + matrice(0, 1).ToString + "," + matrice(3, 1).ToString + "," + matrice(4, 1).ToString + ""
        For i = 5 To 99
            Select Case Val(matrice(i, 0))
                Case 12
                    temperature_format = Format(matrice(i, 1), "0")
                Case 13 To 14
                    'valore_ch1 = return_lettura(divide_ch1, Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1)))
                    valore_ch1 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    ch1_val = True
                    i = i + 1
                Case 15 To 16
                    'valore_ch2 = return_lettura(divide_ch2, Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1)))
                    If (Val(matrice(i, 1)) > 240) Then
                        Dim tempInt As Integer = Val(matrice(i, 1)) - 256
                        valore_ch2 = (tempInt * 100) + Val(matrice(i + 1, 1))
                    Else
                        valore_ch2 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    End If

                    i = i + 1
                    ch2_val = True
                Case 41 To 42
                    'valore_ch3 = return_lettura(divide_ch3, Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1)))
                    valore_ch3 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    i = i + 1
                    ch3_val = True
                Case 19 'Allarme d1
                    If Val(matrice(i, 1)) = 1 Then
                        allarme_d1 = True
                    End If
                Case 20 'Allarme d2
                    If Val(matrice(i, 1)) = 1 Then
                        allarme_d2 = True
                    End If
                Case 21 'A probe
                    If Val(matrice(i, 1)) = 1 Then
                        allarme_p1 = True
                    End If
                Case 22 'A probe 2
                    If Val(matrice(i, 1)) = 1 Then
                        allarme_p2 = True
                    End If
                Case 35 'A allarme soglia 1
                    If Val(matrice(i, 1)) = 1 Then
                        allarme_s1 = True
                    End If
                Case 36 'allarme soglia 2
                    If Val(matrice(i, 1)) = 1 Then
                        allarme_s2 = True
                    End If

                Case 8
                    If Val(matrice(i, 1)) = 1 Then
                        flow_val = True
                    End If
                Case 9
                    If Val(matrice(i, 1)) = 1 Then
                        livello1 = True
                    End If
                Case 10
                    If Val(matrice(i, 1)) = 1 Then
                        livello2 = True
                    End If

                Case 11
                    If Val(matrice(i, 1)) = 1 Then
                        livello3 = True
                    End If
                Case 17 To 18
                    'If temperatura = "1" Then '°F
                    '    condition_temperatura = condition_temperatura + " And (Temperatura  ='" + Format(matrice(i, 1), "00") + Format(matrice(i + 1, 1), "0") + "')"
                    '    insert_temperatura = insert_temperatura + ",'" + Format(matrice(i, 1), "00") + Format(matrice(i + 1, 1), "0") + "'"
                    'Else '°C
                    If temperature_format = "1" Then ' formato americano
                        temperatura_val = ((matrice(i, 1) * 10) + matrice(i + 1, 1))
                    Else
                        temperatura_val = ((matrice(i, 1) * 10) + matrice(i + 1, 1)) / 10
                    End If

                    'End If
                    i = i + 1
                    temperatura = True
                Case 43
                    If Val(matrice(i, 1)) = 1 Then
                        stby = True
                    End If
                    stby_en = True
                Case 44 To 48 'm3/h
                    m3h = Val(matrice(i, 1)) * 1000000000
                    m3h = m3h + Val(matrice(i + 1, 1)) * 10000000
                    m3h = m3h + Val(matrice(i + 2, 1)) * 100000
                    m3h = m3h + Val(matrice(i + 3, 1)) * 1000
                    m3h = m3h + Val(matrice(i + 4, 1)) * 10
                    m3h = m3h / 100000
                    m3h_bool = True
                    i = i + 4
                Case 49 To 53 'totalizer
                    tot_iput = Val(matrice(i, 1)) * 1000000000
                    tot_iput = tot_iput + Val(matrice(i + 1, 1)) * 10000000
                    tot_iput = tot_iput + Val(matrice(i + 2, 1)) * 100000
                    tot_iput = tot_iput + Val(matrice(i + 3, 1)) * 1000
                    tot_iput = tot_iput + Val(matrice(i + 4, 1)) * 10
                    tot_input_bool = True
                    i = i + 4
                Case 33 'configurazione canale 1
                    canale1_str = get_canale_ld(matrice(i, 1))
                Case 34 'configurazione canale 2
                    canale2_str = get_canale_ld(matrice(i, 1))
                    If (matrice(i, 1) = 11) Then
                        pos_virgola_ch2 = 3
                    End If

                Case 39
                    canale3_str = get_canale_ld(matrice(i, 1))

                Case 38 'posizione virgola canale 2
                    pos_virgola_ch2 = (matrice(i, 1))
                Case 40 'posizione virgola canale 3
                    pos_virgola_ch3 = (matrice(i, 1))
                Case 37 'posizione virgola canale 1
                    pos_virgola_ch1 = (matrice(i, 1))
            End Select
        Next
        stringa_finale = canale1_str + "|" + canale2_str + "|" + canale3_str + "|"

        If ch1_val Then
            valore_ch1 = return_lettura(pos_virgola_ch1, valore_ch1)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch1.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_val Then
            valore_ch2 = return_lettura(pos_virgola_ch2, valore_ch2)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch2.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch3_val Then
            valore_ch3 = return_lettura(pos_virgola_ch3, valore_ch3)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch3.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_d1 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_d2 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_p1 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_p2 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_s1 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_s2 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If livello1 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If livello2 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If livello3 Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If temperatura Then
            stringa_finale = stringa_finale + data_finale + "," + Replace(temperatura_val.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If flow_val Then
            stringa_finale = stringa_finale + data_finale + "," + "1|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If stby_en Then
            If stby Then
                stringa_finale = stringa_finale + data_finale + "," + "1|"
            Else
                stringa_finale = stringa_finale + data_finale + "," + "0|"
            End If

        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If m3h_bool Then
            stringa_finale = stringa_finale + data_finale + "," + Replace(m3h.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If
        If tot_input_bool Then
            stringa_finale = stringa_finale + data_finale + "," + Replace(tot_iput.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "dis|"
        End If

        Return stringa_finale
    End Function
    Public Function prepara_log_wd(ByVal data_log() As String, ByRef data_current As String, ByRef temperature_format As String) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim stringa_finale As String = ""

        Dim data_finale As String = ""
        Dim matrice(100, 1) As String
        Dim ch1_val As Boolean = False
        Dim ch2_val As Boolean = False

        Dim allarme_d1 As Boolean = False
        Dim allarme_d2 As Boolean = False
        Dim allarme_p1 As Boolean = False
        Dim allarme_p2 As Boolean = False

        Dim allarme_d1_str As String = ""
        Dim allarme_d2_str As String = ""
        Dim allarme_p1_str As String = ""
        Dim allarme_p2_str As String = ""



        Dim livello1 As Boolean = False
        Dim livello2 As Boolean = False
        Dim flow_val As Boolean = False
        Dim livello1_str As String = ""
        Dim livello2_str As String = ""
        Dim flow_val_str As String = ""

        Dim rele_ch1_bool As Boolean = False
        Dim rele_ch2_bool As Boolean = False

        Dim Soglia_ph As Boolean = False
        Dim Soglia_mV As Boolean = False
        Dim Pipe_all As Boolean = False
        Dim Timeout1 As Boolean = False
        Dim Timeout2 As Boolean = False
        Dim SEFL_AC As Boolean = False
        Dim SEFL_CL As Boolean = False
        Dim Pump1 As Boolean = False
        Dim Pump2 As Boolean = False
        Dim WM1 As Boolean = False
        Dim WM2 As Boolean = False
        Dim WM1T As Boolean = False
        Dim WM2T As Boolean = False


        Dim Soglia_ph_str As String = ""
        Dim Soglia_mV_str As String = ""
        Dim Pipe_all_str As String = ""
        Dim Timeout1_str As String = ""
        Dim Timeout2_str As String = ""
        Dim SEFL_AC_str As String = ""
        Dim SEFL_CL_str As String = ""

        Dim Pump1_str As String = ""
        Dim Pump2_str As String = ""
        Dim WM1_str As String = ""
        Dim WM2_str As String = ""
        Dim WM1T_str As String = ""
        Dim WM2T_str As String = ""
        Dim valore_ch1 As Single = 0
        Dim valore_ch2 As Single = 0

        Dim rele_ch1 As Integer
        Dim rele_ch2 As Integer

        Dim canale1_str As String = ""
        Dim canale2_str As String = ""

        Dim pos_virgola_ch1 As Integer
        Dim pos_virgola_ch2 As Integer


        For i = 1 To data_log.Length - 2
            matrice(j, 0) = Val(data_log(i))
            matrice(j, 1) = Val(data_log(i + 1))
            If matrice(j, 0) = "126" Then
                matrice(j, 0) = "13"
            End If
            If matrice(j, 1) = "126" Then
                matrice(j, 1) = "13"
            End If
            If matrice(j, 0) = "127" Then
                matrice(j, 0) = "38"
            End If
            If matrice(j, 1) = "127" Then
                matrice(j, 1) = "38"
            End If

            j = j + 1
            i = i + 1

            If i > data_log.Length - 1 Or j > 99 Then
                Exit For
            End If
        Next
        data_current = crea_valore(matrice(0, 1)) + "/" + crea_valore(matrice(1, 1)) + "/" + (2000 + matrice(2, 1)).ToString
        ' data_finale = "Date.UTC(" + 2000 + matrice(2, 1).ToString + "," + (matrice(1, 1) - 1).ToString + "," + matrice(0, 1).ToString + "," + matrice(3, 1).ToString + "," + matrice(4, 1).ToString + ")"
        data_finale = "Date.UTC(" + (2000 + matrice(2, 1)).ToString + "," + (matrice(1, 1) - 1).ToString + "," + matrice(0, 1).ToString + "," + matrice(3, 1).ToString + "," + matrice(4, 1).ToString + ")"
        For i = 5 To 99
            Select Case Val(matrice(i, 0))
                Case 12
                    temperature_format = Format(matrice(i, 1), "0")
                Case 13 To 14
                    'valore_ch1 = return_lettura(divide_ch1, Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1)))
                    valore_ch1 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    ch1_val = True
                    i = i + 1
                Case 15 To 16
                    'valore_ch2 = return_lettura(divide_ch2, Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1)))
                    valore_ch2 = Val(matrice(i, 1) * 100) + Val(matrice(i + 1, 1))
                    i = i + 1
                    ch2_val = True

                Case 19 'Allarme d1
                    allarme_d1 = True
                    allarme_d1_str = (matrice(i, 1)).ToString

                Case 20 'Allarme d2
                    allarme_d2 = True
                    allarme_d2_str = (matrice(i, 1)).ToString
                Case 21 'A probe
                    allarme_p1 = True
                    allarme_p1_str = (matrice(i, 1)).ToString
                Case 22 'A probe 2
                    allarme_p2 = True
                    allarme_p2_str = (matrice(i, 1)).ToString
                Case 8
                    flow_val = True
                    flow_val_str = (matrice(i, 1)).ToString

                Case 9
                    livello1 = True
                    livello1_str = (matrice(i, 1)).ToString
                Case 10
                    livello2 = True

                    livello2_str = (matrice(i, 1)).ToString
                Case 31
                    rele_ch1_bool = True
                    rele_ch1 = Val(matrice(i, 1))
                Case 32
                    rele_ch2_bool = True
                    rele_ch2 = Val(matrice(i, 1))

                Case 33 'configurazione canale 1
                    canale1_str = get_canale_ld(matrice(i, 1))
                Case 34 'configurazione canale 2
                    canale2_str = get_canale_ld(matrice(i, 1))

                Case 38 'posizione virgola canale 2
                    pos_virgola_ch2 = (matrice(i, 1))
                Case 37 'posizione virgola canale 1
                    pos_virgola_ch1 = (matrice(i, 1))

                Case 44
                    Soglia_ph = True
                    Soglia_ph_str = (matrice(i, 1)).ToString
                Case 45
                    Soglia_mV = True
                    Soglia_mV_str = (matrice(i, 1)).ToString
                Case 46
                    Pipe_all = True
                    Pipe_all_str = (matrice(i, 1)).ToString
                Case 47
                    Timeout1 = True
                    Timeout1_str = (matrice(i, 1)).ToString
                Case 48
                    Timeout2 = True
                    Timeout2_str = (matrice(i, 1)).ToString
                Case 49
                    SEFL_AC = True
                    SEFL_AC_str = (matrice(i, 1)).ToString
                Case 50
                    SEFL_CL = True
                    SEFL_CL_str = (matrice(i, 1)).ToString
                Case 51
                    Dim tempSingle As Single = Val(matrice(i, 1).ToString + matrice(i + 1, 1).ToString + matrice(i + 2, 1).ToString) / 100


                    Pump1 = True
                    Pump1_str = Replace(tempSingle.ToString(), ",", ".")
                    i = i + 2
                Case 54
                    Dim tempSingle As Single = Val(matrice(i, 1).ToString + matrice(i + 1, 1).ToString + matrice(i + 2, 1).ToString) / 100
                    'tempSingle = tempSingle / 10
                    Pump2 = True
                    Pump2_str = Replace(tempSingle.ToString(), ",", ".")
                    i = i + 2
                Case 57
                    Dim tempSingle As Single = Val(matrice(i, 1).ToString + matrice(i + 1, 1).ToString + matrice(i + 2, 1).ToString)
                    'tempSingle = tempSingle / 10
                    WM1 = True
                    WM1_str = Replace(tempSingle.ToString(), ",", ".")
                    i = i + 2

                Case 60
                    WM2 = True
                    Dim tempSingle As Single = Val(matrice(i, 1).ToString + matrice(i + 1, 1).ToString + matrice(i + 2, 1).ToString)

                    WM2_str = Replace(tempSingle.ToString(), ",", ".")
                    i = i + 2

                Case 63
                    WM1T = True
                    Dim tempSingle As Single = Val(matrice(i, 1).ToString + matrice(i + 1, 1).ToString + matrice(i + 2, 1).ToString)


                    WM1T_str = Replace(tempSingle.ToString(), ",", ".")
                    i = i + 2

                Case 66
                    Dim tempSingle As Single = Val(matrice(i, 1).ToString + matrice(i + 1, 1).ToString + matrice(i + 2, 1).ToString)


                    WM2T = True
                    WM2T_str = Replace(tempSingle.ToString(), ",", ".")
                    i = i + 2

            End Select

        Next
        stringa_finale = canale1_str + "|" + canale2_str + "|"

        If ch1_val Then
            valore_ch1 = return_lettura(pos_virgola_ch1, valore_ch1)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch1.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If ch2_val Then
            valore_ch2 = return_lettura(pos_virgola_ch2, valore_ch2)
            stringa_finale = stringa_finale + data_finale + "," + Replace(valore_ch2.ToString(), ",", ".") + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "0|"
        End If
        If allarme_d1 Then
            stringa_finale = stringa_finale + data_finale + "," + allarme_d1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If allarme_d2 Then
            stringa_finale = stringa_finale + data_finale + "," + allarme_d1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If allarme_p1 Then
            stringa_finale = stringa_finale + data_finale + "," + allarme_p1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If allarme_p2 Then
            stringa_finale = stringa_finale + data_finale + "," + allarme_p2_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If livello1 Then
            stringa_finale = stringa_finale + data_finale + "," + livello1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If livello2 Then
            stringa_finale = stringa_finale + data_finale + "," + livello2_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If

        If flow_val Then
            stringa_finale = stringa_finale + data_finale + "," + flow_val_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If rele_ch1_bool Then
            stringa_finale = stringa_finale + data_finale + "," + rele_ch1.ToString + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If rele_ch2_bool Then
            stringa_finale = stringa_finale + data_finale + "," + rele_ch2.ToString + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If

        If Soglia_ph Then
            stringa_finale = stringa_finale + data_finale + "," + Soglia_ph_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If Soglia_mV Then
            stringa_finale = stringa_finale + data_finale + "," + Soglia_mV_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If Pipe_all Then
            stringa_finale = stringa_finale + data_finale + "," + Pipe_all_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If Timeout1 Then
            stringa_finale = stringa_finale + data_finale + "," + Timeout1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If Timeout2 Then
            stringa_finale = stringa_finale + data_finale + "," + Timeout2_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If SEFL_AC Then
            stringa_finale = stringa_finale + data_finale + "," + SEFL_AC_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If SEFL_CL Then
            stringa_finale = stringa_finale + data_finale + "," + SEFL_CL_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If

        If Pump1 Then
            stringa_finale = stringa_finale + data_finale + "," + Pump1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If Pump2 Then
            stringa_finale = stringa_finale + data_finale + "," + Pump2_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If WM1 Then
            stringa_finale = stringa_finale + data_finale + "," + WM1_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If WM2 Then
            stringa_finale = stringa_finale + data_finale + "," + WM2_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If WM1T Then
            stringa_finale = stringa_finale + data_finale + "," + WM1T_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If
        If WM2T Then
            stringa_finale = stringa_finale + data_finale + "," + WM2T_str + "|"
        Else
            stringa_finale = stringa_finale + data_finale + "," + "Dis|"
        End If

        Return stringa_finale
    End Function
    Public Function return_lettura(ByVal divisore As Integer, ByVal value As Double) As Double
        Select Case divisore
            Case 4
                Return value
            Case 1
                'Return Mid(stringa, 1, 1) & "." & Mid(stringa, 2, 3)
                value = value / 1000
                Return value
            Case 2
                'Return Mid(stringa, 1, 2) & "." & Mid(stringa, 3, 2)
                value = value / 100
                Return value
            Case 3
                'Return Mid(stringa, 1, 3) & "." & Mid(stringa, 4, 1)
                value = value / 10
                Return value
        End Select
        Return 0
    End Function

    Private Function get_canale_ld(ByVal indice As Integer) As String
        Select Case indice
            Case 1
                Return "pH"
            Case 2
                Return "Cl"
            Case 3
                Return "NTU"
            Case 4
                Return "mV"
            Case 5
                Return "CD"
            Case 6
                Return ""
            Case 7
                Return "LDO"
            Case 8
                Return "NTU"
            Case 9
                Return "Cl"
            Case 10
                Return "Clc"
            Case 11
                Return "PPM"
            Case 12
                Return "Fl"
            Case 13
                Return "mV"

        End Select
    End Function

End Class