Imports System.Net

Public Class JwebService
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()>
    Public Shared Function getRealTime(ByVal serialNumber As String, ByVal type As String, ByVal user As String, ByVal password As String, ByVal id485 As String) As String
        Dim jsonCon As New jsonConvertvb
        'Return  jsonCon.jsonResultGlobal(serialNumber, type, user, password, id_485_impianto)
        serialNumber = Replace(serialNumber, """", "")
        user = Replace(user, """", "")
        password = Replace(password, """", "")
        id485 = Replace(id485, """", "")
        type = Replace(type, """", "")
        Return jsonCon.jsonResultGlobal(serialNumber, type, user, password, id485)
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function listConnected(ByVal serialNumber As String) As String
        Dim jsonCon As New jsonConvertvb
        serialNumber = Replace(serialNumber, """", "")
        Return jsonCon.jsonStrumentiConnessi(serialNumber)

    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function jsonInfoCodice(ByVal serialNumber As String) As String
        Dim jsonCon As New jsonConvertvb
        serialNumber = Replace(serialNumber, """", "")
        Return jsonCon.jsonInfoCodice(serialNumber)

    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function jsonIPApi() As String

        Dim client As New WebClient()
        Dim bytes() As Byte = client.DownloadData("http://ip-api.com/json")
        client.Dispose()
        Return ""
        ' Return jsonCon.jsonInfoCodice(serialNumber)

    End Function
End Class