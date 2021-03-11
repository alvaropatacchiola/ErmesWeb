Public Class memSerial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim serialNumber As String = ""
        Dim type As String = ""
        Dim query As New query
        Dim stringJson As String = "{"
        serialNumber = Page.Request("serial")
        type = Page.Request("type")

        If (query.insertNewSerialPump(serialNumber, type)) Then
            stringJson = stringJson + """status"":""ok""}"
        Else
            stringJson = stringJson + """status"":""error""}"
        End If
        stringaRisposta.Text = stringJson
    End Sub

End Class