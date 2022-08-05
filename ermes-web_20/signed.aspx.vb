Public Class signed
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result_user As String
        Dim query As New query

        'result_user = Request.Form("result")
        result_user = Page.Request("result")
        If result_user = "1" Or result_user = "2" Then ' utente ok registrabile
            If result_user = "1" Then
                Literal1.Visible = True
                Literal3.Visible = True
                Literal2.Visible = False
                Literal4.Visible = False
            Else ' errore
                Literal2.Visible = True
                Literal4.Visible = True
                Literal3.Visible = False
                Literal1.Visible = False
            End If
        Else ' errore
            Literal2.Visible = True
            Literal4.Visible = True
            Literal3.Visible = False
            Literal1.Visible = False

        End If

    End Sub
    Public Function getIpClient() As String
        Dim IPAddress As String = ""
        'Dim Host As System.Net.IPHostEntry
        'Dim Hostname As String
        'Hostname = My.Computer.Name
        'Host = System.Net.Dns.GetHostEntry(Hostname)
        'For Each IP As System.Net.IPAddress In Host.AddressList
        '    If IP.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
        '        IPAddress = Convert.ToString(IP)
        '    End If
        'Next
        IPAddress = HttpContext.Current.Request.UserHostAddress()
        Return IPAddress
    End Function
End Class