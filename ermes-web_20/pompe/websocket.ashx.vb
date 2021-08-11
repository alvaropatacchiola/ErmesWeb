Imports System.Web
Imports System.Web.Services
Imports System.Web.WebSockets
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks
Public Class websocket
    Implements System.Web.IHttpHandler


    Private Shared clients As New List(Of Net.WebSockets.WebSocket)
    Private Shared Locker As ReaderWriterLockSlim = New ReaderWriterLockSlim()

    'Private Static ReadOnly ReaderWriterLockSlim Locker = New ReaderWriterLockSlim();
    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World!")
        ProcessRequest(New HttpContextWrapper(context))
    End Sub
    Sub ProcessRequest(ByVal context As HttpContextBase)

        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World!")
        If context.IsWebSocketRequest Then
            context.AcceptWebSocketRequest(AddressOf ProcessSocketRequest)
        End If
    End Sub
    Private Async Function ProcessSocketRequest(ByVal context As AspNetWebSocketContext) As Threading.Tasks.Task
        Dim socket As Net.WebSockets.WebSocket = context.WebSocket
        Dim mqttclient As New mqtt
        'Locker.EnterWriteLock()
        Try
            clients.Add(socket)
            mqttclient.socket = socket
            Await mqttclient.mqttConnection()
            'Await mqttclient.mqttSubscribe("topictest")
            AddHandler mqttclient.dataReceived, AddressOf messageReceived
        Catch ex As Exception
            'Locker.ExitWriteLock()
        End Try

        While True
            Dim buffer = New ArraySegment(Of Byte)(New Byte(1023) {})
            'Dim buffer = New ArraySegment(Of Byte)(New Byte() {})

            Dim r As Net.WebSockets.WebSocketReceiveResult = Await socket.ReceiveAsync(New ArraySegment(Of Byte)(buffer.Array), CancellationToken.None)

            'test di invio
            'Dim reqAsBytes = Encoding.UTF8.GetBytes("ciao")
            'Dim ticksRequest = New ArraySegment(Of Byte)(reqAsBytes)
            'Await socket.SendAsync(ticksRequest, Net.WebSockets.WebSocketMessageType.Text, True, CancellationToken.None)

            If socket.State = Net.WebSockets.WebSocketState.Open Then
                'Await socket.SendAsync(buffer, Net.WebSockets.WebSocketMessageType.Text, True, CancellationToken.None)
                Dim vOut As String = System.Text.Encoding.ASCII.GetString(buffer.Array)
                If vOut.IndexOf("PUBLISH") >= 0 Then ' comando di autenticazione
                    vOut = vOut.Replace(vbNullChar, "")
                    Dim reqAsBytes = Encoding.UTF8.GetBytes("PUBLISHOK")
                    Dim ticksRequest = New ArraySegment(Of Byte)(reqAsBytes)
                    Await socket.SendAsync(ticksRequest, Net.WebSockets.WebSocketMessageType.Binary, True, CancellationToken.None)

                    Await mqttclient.mqttSubscribe("/" + vOut.Replace("PUBLISH", "") + "/app", "/" + vOut.Replace("PUBLISH", "") + "/bsyR")
                Else
                    Dim byteCopy(r.Count - 1) As Byte
                    Array.Copy(buffer.Array, byteCopy, r.Count)
                    Await mqttclient.mqttPublish(mqttclient.topicString + "W", byteCopy)
                End If

            Else
                'Locker.EnterWriteLock()
                Try
                    clients.Remove(socket)
                    Await mqttclient.mqttClose
                Catch ex As Exception
                Finally
                    ' Locker.ExitWriteLock()
                End Try
            End If
        End While

    End Function
    Private Async Sub messageReceived(ByVal payload() As Byte, ByVal socketPointer As Net.WebSockets.WebSocket)
        Dim ticksRequest = New ArraySegment(Of Byte)(payload)
        Try
            If socketPointer.State = Net.WebSockets.WebSocketState.Open Then

                Await socketPointer.SendAsync(ticksRequest, Net.WebSockets.WebSocketMessageType.Binary, True, CancellationToken.None)
            Else
                clients.Remove(socketPointer)
            End If
        Catch ex As Exception

        End Try

    End Sub
    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class