Public Class pumpService
    Inherits lingua
    <System.Web.Services.WebMethod()>
    Public Shared Function getStatusConnection(ByVal serialNumber As String, ByVal topic As String, ByVal payload As String) As String
        serialNumber = Replace(serialNumber, """", "")
        topic = Replace(topic, """", "")
        payload = Replace(payload, """", "")
        Dim mqttclient As New mqtt
        'AddHandler mqttclient.dataReceived, AddressOf messageReceived

    End Function
    Public Shared Sub messageReceived(ByVal payload() As Byte)

    End Sub
End Class