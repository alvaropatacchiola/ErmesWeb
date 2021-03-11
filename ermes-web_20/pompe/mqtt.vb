
Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options
Imports System.Threading.Tasks
'comandi utili
'$SYS/broker/clients/active  in questo topic ci restituisce i client attivi.. da provare
'vedi link https://github.com/mqtt/mqtt.org/wiki/SYS-Topics
'$SYS/clients/[client-id]/ip da provare
'$SYS/clients/[client-id]/connectedtime da provare
Public Class mqtt
    Private Const BYTES_TO_READ As Integer = 512
    Public factory As MqttFactory
    Public mqttClient As IMqttClient
    Public Options As MqttClientOptionsBuilder
    Public topicString As String = ""
    Public socket As Net.WebSockets.WebSocket
    Public Event dataReceived(ByVal message() As Byte, ByVal socketPointer As Net.WebSockets.WebSocket)
    Private Class Payload
        Public number As String
        Public message As String

        Sub New(ByVal num As String, ByVal msg As String)
            number = num
            message = msg
        End Sub
    End Class

    Public Async Function mqttSubscribe(ByVal topic As String, ByVal topicSub As String) As Task(Of Boolean)
        Try
            mqttClient.UseApplicationMessageReceivedHandler(AddressOf HandleApllicationMessageReceived)
            topicString = topic
            Dim thisTopicFilter As MqttTopicFilter = New MqttTopicFilterBuilder().WithTopic(topic + "W").Build()
            Await mqttClient.SubscribeAsync(thisTopicFilter)
            Dim thisTopicFilter1 As MqttTopicFilter = New MqttTopicFilterBuilder().WithTopic(topic + "R").Build()
            Await mqttClient.SubscribeAsync(thisTopicFilter1)

            Dim thisTopicFilter2 As MqttTopicFilter = New MqttTopicFilterBuilder().WithTopic(topicSub).Build()
            Await mqttClient.SubscribeAsync(thisTopicFilter2)


            Return True
        Catch ex As Exception

        End Try

        Return False
    End Function
    Public Async Function mqttConnection() As Task(Of Boolean)
        factory = New MqttFactory()
        mqttClient = factory.CreateMqttClient()
        Options = New MqttClientOptionsBuilder()
        Dim clientId As String = Guid.NewGuid().ToString()
        With Options
            .WithTcpServer("srvmqtt", 1883)
            .WithClientId(clientId)
            '.WithClientId("01")
            .WithCredentials("emecsrl", "emecsrl")
        End With
        Try
            Await mqttClient.ConnectAsync(Options.Build())
            Return True
        Catch ex As Exception

        End Try
        Return False

    End Function
    Public Async Function mqttClose() As Task(Of Boolean)
        Try
            Await mqttClient.DisconnectAsync
        Catch ex As Exception

        End Try
    End Function
    Public Async Function mqttPublish(ByVal topic As String, ByVal payload() As Byte) As Task(Of Boolean)
        Try
            If Not mqttClient.IsConnected Then
                Await mqttClient.ConnectAsync(Options.Build())
            End If
            Await mqttClient.PublishAsync(topic, payload)

        Catch ex As Exception

        End Try
        Return True

    End Function
    Private Sub HandleApllicationMessageReceived(ByVal args As MqttApplicationMessageReceivedEventArgs)
        Dim readBuffer(BYTES_TO_READ) As Byte
        Dim indiceStart As Integer = 0
        If args.ApplicationMessage.Topic.IndexOf("R") > 0 Then '' rerinoltro i messaggi al client solo se R
            If args.ApplicationMessage.Topic.IndexOf("bsyR") >= 0 Then
                Dim reqAsBytes = Encoding.UTF8.GetBytes("bsyR" + System.Text.Encoding.UTF8.GetString(args.ApplicationMessage.Payload))
                RaiseEvent dataReceived(reqAsBytes, socket)
            Else
                RaiseEvent dataReceived(args.ApplicationMessage.Payload, socket)
            End If

        End If


        'If args.ApplicationMessage.Payload(indiceStart) = 1 Then ' messaggio mail
        '    Dim indirizzomail As String = ""
        '    Dim messaggioMail As String = ""
        '    indiceStart = indiceStart + 1
        '    While args.ApplicationMessage.Payload(indiceStart) <> 0 And indiceStart < BYTES_TO_READ
        '        indirizzomail = indirizzomail + Chr(args.ApplicationMessage.Payload(indiceStart))
        '        indiceStart = indiceStart + 1
        '    End While
        '    indiceStart = indiceStart + 1
        '    While args.ApplicationMessage.Payload(indiceStart) <> 0 And indiceStart < BYTES_TO_READ
        '        messaggioMail = messaggioMail + Chr(args.ApplicationMessage.Payload(indiceStart))
        '        indiceStart = indiceStart + 1

        '    End While
        '    stack_messaggiMail.Enqueue(indirizzomail + "$" + messaggioMail)
        'End If
        'If args.ApplicationMessage.Payload(indiceStart) = 2 Then ' messaggio telegram
        '    Dim indirizzomail As String = ""
        '    Dim messaggioMail As String = ""
        '    indiceStart = indiceStart + 1
        '    While args.ApplicationMessage.Payload(indiceStart) <> 0 And indiceStart < BYTES_TO_READ
        '        indirizzomail = indirizzomail + Chr(args.ApplicationMessage.Payload(indiceStart))
        '        indiceStart = indiceStart + 1
        '    End While
        '    indiceStart = indiceStart + 1
        '    While args.ApplicationMessage.Payload(indiceStart) <> 0 And indiceStart < BYTES_TO_READ
        '        messaggioMail = messaggioMail + Chr(args.ApplicationMessage.Payload(indiceStart))
        '        indiceStart = indiceStart + 1

        '    End While
        '    stack_messagiTelegram.Enqueue(indirizzomail + "$" + messaggioMail)

        'End If

        'MQTTmessage = (Encoding.UTF8.GetString(args.ApplicationMessage.Payload, 0, args.ApplicationMessage.Payload.Length))
    End Sub
End Class
