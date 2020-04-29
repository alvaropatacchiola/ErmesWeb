Imports System.Threading
Imports local_debug
Public Class write_setpoint
    Private client As System.Net.Sockets.TcpClient
    Private Const BYTES_TO_READ As Integer = 255
    Private readBuffer(BYTES_TO_READ) As Byte
    Public risposta As String
    Public event_timer As Boolean
    Friend WithEvents Timer1 As System.Timers.Timer

    'WRITESETPOINT;132373;01;016Bph----------------------------------------------------------------------------------------------------------------------------------0---------end
    'WAITSETPOINT;132373;null;null

    Public Function web_setpoint_change(ByVal codice_impianto As String, ByVal id_485_impianto As String, ByVal new_setpoint As String, _
                                        ByRef url_result As String, Optional ByRef errore_primo_invio As Boolean = False) As Boolean
        Dim result_send As Boolean
        Dim result_wait(2) As Boolean
        Dim i As Integer = 0
        Dim j As Integer = 0

        'If result_send Then ' set point inviato al server
        For i = 0 To 3
            result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint)
            result_wait(0) = True
            result_wait(1) = True
            Thread.Sleep(3000) ' attendo 1 secondo per controllare l'attesa
            For j = 0 To 3
                result_wait = wait_response_set_point(codice_impianto)
                If result_wait(0) = True And result_wait(1) = False Then ' operazione in progress

                End If
                If result_wait(0) = False And result_wait(1) = False Then ' strumento occupato
                    If i = 3 Then
                        url_result = "result=2"
                        errore_primo_invio = True
                        Return True
                    End If
                    'url_result = "result=2"
                    'errore_primo_invio = True
                    Exit For
                End If
                If result_wait(0) = False And result_wait(1) = True Then ' strumento con risposta ok
                    Thread.Sleep(1000) ' attendo 1 secondo per controllare l'attesa
                    errore_primo_invio = False
                    url_result = "result=1"
                    Return True
                End If
                Thread.Sleep(2000) ' attendo 1 secondo per controllare
            Next
        Next
        'Else ' strumento busy
        'url_result = "result=2"
        'errore_primo_invio = True
        'End If
        Return True
    End Function
    Public Function web_setpoint_change_biocide(ByVal codice_impianto As String, ByVal id_485_impianto As String, ByVal new_setpoint1 As String, _
                                     ByVal new_setpoint2 As String, ByVal new_setpoint3 As String, ByVal new_setpoint4 As String, ByVal new_setpoint5 As String, _
                                     ByRef url_result As String, Optional ByRef errore_primo_invio As Boolean = False) As Boolean
        Dim result_send As Boolean
        Dim result_wait(2) As Boolean
        Dim i As Integer = 0
        'result_send = write_set_point_biocide1(codice_impianto, id_485_impianto, new_setpoint1, new_setpoint2, new_setpoint3, new_setpoint4, new_setpoint5)
        'If result_send Then ' set point inviato al server
        For j = 1 To 5
            Select Case j
                Case 1
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint1)
                Case 2
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint2)
                Case 3
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint3)
                Case 4
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint4)
                Case 5
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint5)
            End Select
            i = 0
            While i < 6
                Thread.Sleep(1000) ' attendo 1 secondo per controllare l'attesa
                result_wait = wait_response_set_point(codice_impianto)
                If result_wait(0) = True And result_wait(1) = False Then ' operazione in progress

                End If
                If result_wait(0) = False And result_wait(1) = False Then ' strumento occupato
                    url_result = "result=2"
                    errore_primo_invio = True
                    If i > 4 Then
                        Exit For
                    End If
                End If
                If result_wait(0) = False And result_wait(1) = True Then ' strumento con risposta ok
                    If j = 5 Then
                        Thread.Sleep(10000) ' attendo 1 secondo per controllare l'attesa
                    Else
                        Thread.Sleep(1000) ' attendo 1 secondo per controllare l'attesa
                    End If
                    errore_primo_invio = False
                    url_result = "result=1"
                    Exit While
                End If
                i = i + 1
            End While
        Next
        'Else ' strumento busy
        'url_result = "result=2"
        'errore_primo_invio = True
        'End If
        Return True
    End Function
    Public Function web_setpoint_change_biocide_ldtower(ByVal codice_impianto As String, ByVal id_485_impianto As String, ByVal new_setpoint1 As String, _
                                     ByVal new_setpoint2 As String, ByVal new_setpoint3 As String, ByVal new_setpoint4 As String, ByVal new_setpoint5 As String, _
                                      ByVal new_setpoint6 As String, ByVal new_setpoint7 As String, ByVal new_setpoint8 As String, _
                                     ByRef url_result As String, Optional ByRef errore_primo_invio As Boolean = False) As Boolean
        Dim result_send As Boolean
        Dim result_wait(2) As Boolean
        Dim i As Integer = 0
        'result_send = write_set_point_biocide1(codice_impianto, id_485_impianto, new_setpoint1, new_setpoint2, new_setpoint3, new_setpoint4, new_setpoint5)
        'If result_send Then ' set point inviato al server
        For j = 1 To 8
            Select Case j
                Case 1
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint1)
                Case 2
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint2)
                Case 3
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint3)
                Case 4
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint4)
                Case 5
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint5)
                Case 6
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint6)
                Case 7
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint7)
                Case 8
                    result_send = write_set_point(codice_impianto, id_485_impianto, new_setpoint8)
            End Select
            i = 0
            While i < 6
                Thread.Sleep(1000) ' attendo 1 secondo per controllare l'attesa
                result_wait = wait_response_set_point(codice_impianto)
                If result_wait(0) = True And result_wait(1) = False Then ' operazione in progress

                End If
                If result_wait(0) = False And result_wait(1) = False Then ' strumento occupato
                    url_result = "result=2"
                    errore_primo_invio = True
                    If i > 4 Then
                        Exit For
                    End If
                End If
                If result_wait(0) = False And result_wait(1) = True Then ' strumento con risposta ok
                    If j = 8 Then
                        Thread.Sleep(10000) ' attendo 1 secondo per controllare l'attesa
                    Else
                        Thread.Sleep(1000) ' attendo 1 secondo per controllare l'attesa
                    End If
                    errore_primo_invio = False
                    url_result = "result=1"
                    Exit While
                End If
                i = i + 1
            End While
        Next
        'Else ' strumento busy
        'url_result = "result=2"
        'errore_primo_invio = True
        'End If
        Return True
    End Function

    Public Function web_real_time(ByVal codice As String, ByVal id As String) As Boolean
        Dim result_send As Boolean
        Dim result_wait(2) As Boolean

        result_send = write_real_time(codice, id)
        If result_send Then ' set point inviato al server
            Thread.Sleep(18000) ' attendo 1 secondo per controllare l'attesa
            Return True
        End If
        Return False
    End Function
    Public Function write_set_point(ByVal codice As String, ByVal id As String, ByVal new_setpoint As String) As Boolean
        'Dim client As System.Net.Sockets.TcpClient
        Dim risposta_bool As Boolean
        'client = New System.Net.Sockets.TcpClient("localhost", 2019)
        risposta = ""
        ' client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
        SendMessage("LOCALCOMMAND|WRITESETPOINT;" + codice + ";" + id + ";" + new_setpoint + ";null;null;null;null|end")
        risposta_bool = wait_command("LOCALCOMMAND", 6000)
        If risposta_bool Then
            Dim data() As String = risposta.Split("|")
            If data.Length = 3 Then
                Dim data1() As String = data(1).Split(";")
                Dim i As Integer = 0
                For i = 0 To data1.Length - 1
                    If InStr(data1(i), "True") <> 0 Then
                        Return True
                    End If
                Next
            End If
        End If
        Return False
    End Function

    Public Function write_real_time(ByVal codice As String, ByVal id As String) As Boolean
        'Dim client As System.Net.Sockets.TcpClient
        Dim risposta_bool As Boolean
        'client = New System.Net.Sockets.TcpClient("localhost", 2019)
        risposta = ""
        ' client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
        SendMessage("LOCALCOMMAND|REALTIME;" + codice + ";" + id + ";null;null;null;null;null|end")
        risposta_bool = wait_command("LOCALCOMMAND", 6000)
        If risposta_bool Then
            Dim data() As String = risposta.Split("|")
            If data.Length = 3 Then
                Dim data1() As String = data(1).Split(";")
                Dim i As Integer = 0
                For i = 0 To data1.Length - 1
                    If InStr(data1(i), "False") <> 0 Then
                        Return True
                    End If
                Next
            End If
        End If
        Return False
    End Function

    Public Function write_set_point_biocide1(ByVal codice As String, ByVal id As String, ByVal new_setpoint1 As String, ByVal new_setpoint2 As String, ByVal new_setpoint3 As String, ByVal new_setpoint4 As String, ByVal new_setpoint5 As String) As Boolean
        Dim risposta_bool As Boolean
        'client = New System.Net.Sockets.TcpClient("localhost", 2019)
        risposta = ""
        'client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
        SendMessage("LOCALCOMMAND|WRITEBIOCIDE;" + codice + ";" + id + ";" + new_setpoint1 + ";" + new_setpoint2 + ";" + new_setpoint3 + ";" + new_setpoint4 + ";" + new_setpoint5 + "|end")
        risposta_bool = wait_command("LOCALCOMMAND", 6000)
        If risposta_bool Then
            Dim data() As String = risposta.Split("|")
            If data.Length = 3 Then
                Dim data1() As String = data(1).Split(";")
                Dim i As Integer = 0
                For i = 0 To data1.Length - 1
                    If InStr(data1(i), "True") <> 0 Then
                        Return True
                    End If
                Next
            End If
        End If
        Return False

    End Function
    Public Function wait_response_set_point(ByVal codice As String) As Boolean()
        Dim risposta_bool As Boolean
        Dim risposta_coppia(2) As Boolean
        risposta_coppia(0) = False
        risposta_coppia(1) = False
        'client = New System.Net.Sockets.TcpClient("localhost", 2019)
        risposta = ""
        'client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
        SendMessage("LOCALCOMMAND|WAITSETPOINT;" + codice + ";null;null;null;null;null;null|end")
        risposta_bool = wait_command("LOCALCOMMAND", 6000)
        If risposta_bool Then
            Dim data() As String = risposta.Split("|")
            If data.Length = 3 Then
                Dim data1() As String = data(1).Split(";")
                Dim i As Integer = 0
                For i = 0 To data1.Length - 1
                    If InStr(data1(i), "True") <> 0 Then
                        risposta_coppia(i) = True
                    Else
                        risposta_coppia(i) = False
                    End If
                Next
            End If
        End If
        Return risposta_coppia

    End Function
    Public Function client_connect() As Boolean
        Dim risposta_bool As Boolean
        Try
#If LOCAL_MODE Then
            'client = New System.Net.Sockets.TcpClient("localhost", 2019)
#Else

            client = New System.Net.Sockets.TcpClient("localhost", 2019)
            'client = New System.Net.Sockets.TcpClient("192.168.4.200", 2019)
#End If

            client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
            SendMessage("LOCALCOMMAND|" + "CONNECT" + "|end")
            risposta_bool = wait_command("Connected", 6000)
            If risposta_bool Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function client_close() As Boolean
        Try
            SendMessage("LOCALCOMMAND|" + "DISCONNECT" + "|end")
            client.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
        'client.Close()

    End Function
    Private Sub doRead(ByVal ar As System.IAsyncResult)
        Dim totalRead As Integer
        Try
            totalRead = client.GetStream.EndRead(ar) 'Ends the reading and returns the number of bytes read.
        Catch ex As Exception
        End Try

        If totalRead > 0 Then
            Dim receivedString As String = System.Text.Encoding.UTF8.GetString(readBuffer, 0, totalRead)
            messageReceived(receivedString)
        End If
        Try
            client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing) 'Begin the reading again.
        Catch ex As Exception
        End Try
    End Sub

    Private Sub messageReceived(ByVal message As String)
        risposta = message
    End Sub
    Private Sub SendMessage(ByVal msg As String)
        Dim sw As IO.StreamWriter
        Try
            sw = New IO.StreamWriter(client.GetStream)
            sw.Write(msg)
            sw.Flush()
        Catch ex As Exception
            client.Close()
            client_connect()
        End Try
    End Sub
    Private Function wait_command(ByVal string_result As String, ByVal time As Integer) As Boolean
        Timer1 = New System.Timers.Timer
        Timer1.Interval = 6000 ' timer che parte alla ricerca delola configurazione dello strumento
        Timer1.Enabled = True
        event_timer = False
        Timer1.Start()
        While (event_timer = False) And InStr(risposta, string_result) = 0

        End While
        Timer1.Stop()
        Timer1.Enabled = False
        If (InStr(risposta, string_result) <> 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Elapsed
        event_timer = True
    End Sub
End Class
