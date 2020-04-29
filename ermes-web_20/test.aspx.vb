Public Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim url As String = "http://www.ermes-server.com/Centurio/webService.aspx?serial=911717&type=real&user=vivo&pwd=^}8MG87@7pM6F32B;cp4JYeWkqCadqpo"
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)
    End Sub

    Protected Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles UpdateTimer.Tick

        Dim siteContent As String

        Dim url As String = "http://www.ermes-server.com/Centurio/webService.aspx?serial=911717&type=real&user=vivo&pwd=^}8MG87@7pM6F32B;cp4JYeWkqCadqpo"
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)




    End Sub

End Class