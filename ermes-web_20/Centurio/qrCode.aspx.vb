Imports System.IO
Public Class qrCode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim stringaResult As String = "{"
        Dim serial As String = ""
        Dim query As New query

        serial = Page.Request("serial")
        If query.check_identificativo(serial) Then ' se true esiste gia questo codice
            stringaResult = stringaResult + """errore"":""duplicateSerial""}"
        Else
            stringaResult = stringaResult + """errore"":""ok""}"
            My.Computer.Network.DownloadFile _
                    (address:="https://chart.googleapis.com/chart?chs=400x400&cht=qr&chl=http://www.ermes-server.com/login.aspx%3Fqr=1%26serial=" + serial + "&choe=UTF-8",
                    destinationFileName:="C:\inetpub\wwwroot\ermes\Centurio\" + serial + ".png",
                    userName:=String.Empty, password:=String.Empty,
                    showUI:=False, connectionTimeout:=100000,
                    overwrite:=True)

        End If

        ' My.Computer.Network.DownloadFile("https://chart.googleapis.com/chart?chs=150x150&cht=qr&chl=Hello%20world&choe=UTF-8", "C:\inetpub\wwwroot\Centurio\pippo.png", True)

        'stringaResult = " <img src=""pippo.png""  height=""150"" width=""150""> "

        stringaRisposta.Text = stringaResult

    End Sub

End Class