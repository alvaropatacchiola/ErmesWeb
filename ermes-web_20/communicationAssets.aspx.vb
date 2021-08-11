Public Class communicationAssets
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim comunicazioni_array() As String
        Dim comunicazioni_array_line() As String
        Dim comunicazioni_string As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        communicationList.Text = ""
        comunicazioni_string = GetGlobalResourceObject("communication_g", "globali")
        comunicazioni_array = comunicazioni_string.Split(New String() {"<h4>"}, StringSplitOptions.None)
        For i = 0 To comunicazioni_array.Length - 1
            comunicazioni_array(i) = comunicazioni_array(i).Replace("</h4>", "")
            If InStr(comunicazioni_array(i), "<p>") <> 0 Then
                communicationList.Text = communicationList.Text + "<div class=""media media-chat"">"
                communicationList.Text = communicationList.Text + "<img src = ""assets/img/user/user-sm-01.jpg"" Class=""rounded-circle"" alt=""Avata Image"">"

                communicationList.Text = communicationList.Text + "<div class=""media-body"">"
                communicationList.Text = communicationList.Text + "<div class=""text-content"">"
                comunicazioni_array_line = comunicazioni_array(i).Split(New String() {"<p>"}, StringSplitOptions.None)
                communicationList.Text = communicationList.Text + "<span class=""message"">" + comunicazioni_array_line(0) + "</span>"
                communicationList.Text = communicationList.Text + "<time class=""time"">" + comunicazioni_array_line(1) + "</time>"
                communicationList.Text = communicationList.Text + "</div>"
                communicationList.Text = communicationList.Text + "</div>"
                communicationList.Text = communicationList.Text + "</div>"
            End If
        Next
    End Sub

End Class