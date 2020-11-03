Public Class plantInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim serialNumber As String = ""
        Dim jsonCon As New jsonConvertvb
        serialNumber = Page.Request("serial")
        stringaRisposta.Text = jsonCon.jsonInfoCodice(serialNumber)
    End Sub

End Class