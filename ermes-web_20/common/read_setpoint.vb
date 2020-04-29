Imports System.Threading

Public Class read_setpoint
    Private client As System.Net.Sockets.TcpClient
    Private Const BYTES_TO_READ As Integer = 1500
    Private readBuffer(BYTES_TO_READ) As Byte
    Public risposta As String

    Public Function read_setpoint(ByVal codice As String) As String
        Dim risultato As String = ""
        client = New System.Net.Sockets.TcpClient("localhost", 2019)
        client.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)

        SendMessage("LOCALCOMMAND|" + "CONNECT" + "|end")
        Thread.Sleep(500)
        risposta = ""
        SendMessage("LOCALCOMMAND|READSETPOINT;" + codice + ";01;null;null;null;null;null|end")
        Thread.Sleep(2000)
        risultato = risposta
        risposta = ""
        SendMessage("LOCALCOMMAND|" + "DISCONNECT" + "|end")
        Thread.Sleep(500)
        client.Close()
        Dim risultato_split() As String = risultato.Split("|")
        If risultato_split.Length > 1 Then
            Return risultato_split(1)
        Else
            Return ""
        End If
    End Function
    Private Sub messageReceived(ByVal message As String)
        risposta = risposta + message
    End Sub

    Private Sub SendMessage(ByVal msg As String)
        Dim sw As IO.StreamWriter
        Try
            sw = New IO.StreamWriter(client.GetStream)
            sw.Write(msg)
            sw.Flush()
        Catch ex As Exception
            client.Close()

        End Try
    End Sub

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
End Class

