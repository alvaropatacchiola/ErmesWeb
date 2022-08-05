Imports System.IO
Public Class upload
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim extension As String = Path.GetExtension(uploadFile.FileName)
        If extension.ToLower = ".zip" Then
            Dim imgFile As System.Drawing.Image = System.Drawing.Image.FromStream(uploadFile.PostedFile.InputStream)
            uploadFile.SaveAs(uploadFile.FileName)

        End If

    End Sub

    Protected Sub invia_Click(sender As Object, e As EventArgs) Handles invia.Click
        Dim extension As String = Path.GetExtension(uploadFile.FileName)
        If extension.ToLower = ".zip" Then
            Dim imgFile As System.Drawing.Image = System.Drawing.Image.FromStream(uploadFile.PostedFile.InputStream)
            uploadFile.SaveAs(uploadFile.FileName)

        End If
    End Sub
End Class