Imports System
Imports System.IO
Imports System.IO.Pipes
Imports System.Text
Imports System.Security.Principal
Imports System.Diagnostics
Imports System.Threading

Public Class centurioRealTime
    Private Shared numClients As Integer = 4



    Public Function Main(ByVal serialNumber As String, Optional ByVal command As String = "") As String
        'While True
        Dim risultatoPipe As String = ""
        Dim pipeClient As New NamedPipeClientStream(
                ".", "testpipe",
                PipeDirection.InOut, PipeOptions.None,
                TokenImpersonationLevel.Impersonation)

        Console.WriteLine("Connecting to server..." + vbNewLine)

        Try

            pipeClient.Connect(500)
            'pipeClient.wa

            Dim ss As New StreamString(pipeClient)
            ' Validate the server's signature string
            If ss.ReadString() = "I am the one true server!" Then
                ' The client security token is sent with the first write.
                ' Send the name of the file whose contents are returned
                ' by the server.
                ss.WriteString(serialNumber + "^" + command)

                ' Print the file to the screen.
                risultatoPipe = ss.ReadString()
                'Console.WriteLine(ss.ReadString())
                'Console.Write(ss.ReadString())
            Else
                risultatoPipe = "null"
            End If
            pipeClient.Close()
            ' Give the client process some time to display results before exiting.
            'Thread.Sleep(500)
            ' End While
            Return risultatoPipe
        Catch ex As Exception

        End Try
        Return "null"
    End Function

    ' Helper function to create pipe client processes
    Private Shared Sub StartClients()
        Dim i As Integer
        Dim currentProcessName As String = Environment.CommandLine
        Dim plist(numClients) As Process

        Console.WriteLine("Spawning client processes..." + vbNewLine)

        If (currentProcessName.Contains(Environment.CurrentDirectory)) Then
            currentProcessName = currentProcessName.Replace(Environment.CurrentDirectory, String.Empty)
        End If

        ' Remove extra characters when launched from Visual Studio
        currentProcessName = currentProcessName.Replace("\", String.Empty)
        currentProcessName = currentProcessName.Replace("""", String.Empty)

        For i = 0 To numClients - 1
            ' Start 'this' program but spawn a named pipe client.
            plist(i) = Process.Start(currentProcessName, "spawnclient")
        Next i
        While i > 0
            For j As Integer = 0 To numClients - 1
                If Not (plist(j) Is Nothing) Then
                    If plist(j).HasExited Then
                        Console.WriteLine("Client process[{0}] has exited.",
                                plist(j).Id)
                        plist(j) = Nothing
                        i -= 1    ' decrement the process watch count
                    Else
                        Thread.Sleep(250)
                    End If
                End If
            Next j
        End While
        Console.WriteLine(vbNewLine + "Client processes finished, exiting.")
    End Sub

End Class
Public Class StreamString
    Private ioStream As Stream
    Private streamEncoding As UnicodeEncoding

    Public Sub New(ioStream As Stream)
        Me.ioStream = ioStream
        streamEncoding = New UnicodeEncoding(False, False)
    End Sub

    Public Function ReadString() As String
        Dim len As Integer = 0
        Try
            len = CType(ioStream.ReadByte(), Integer) * 1024
            len += CType(ioStream.ReadByte(), Integer)
            Dim inBuffer As Array = Array.CreateInstance(GetType(Byte), len)
            ioStream.Read(inBuffer, 0, len)

            Return streamEncoding.GetString(inBuffer)

        Catch ex As Exception

        End Try
        Return ""
    End Function

    Public Function WriteString(outString As String) As Integer
        Dim outBuffer() As Byte = streamEncoding.GetBytes(outString)
        Dim len As Integer = outBuffer.Length
        If len > UInt16.MaxValue Then
            len = CType(UInt16.MaxValue, Integer)
        End If
        ioStream.WriteByte(CType(len \ 256, Byte))
        ioStream.WriteByte(CType(len And 255, Byte))
        ioStream.Write(outBuffer, 0, outBuffer.Length)
        ioStream.Flush()

        Return outBuffer.Length + 2
    End Function
End Class
