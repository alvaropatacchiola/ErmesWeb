Public Class communication
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim comunicazioni_array() As String
        Dim comunicazioni_array_line() As String
        Dim comunicazioni_string As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        Literal2.Text = ""
        comunicazioni_string = GetGlobalResourceObject("communication_g", "globali")
        comunicazioni_array = comunicazioni_string.Split(New String() {"<h4>"}, StringSplitOptions.None)
        For i = 0 To comunicazioni_array.Length - 1
            comunicazioni_array(i) = comunicazioni_array(i).Replace("</h4>", "")
            If InStr(comunicazioni_array(i), "<p>") <> 0 Then
                Literal2.Text = Literal2.Text + "<div class=""media"">"
                Literal2.Text = Literal2.Text + "<div class=""media-body"">"
                Literal2.Text = Literal2.Text + "<blockquote>"
                comunicazioni_array_line = comunicazioni_array(i).Split(New String() {"<p>"}, StringSplitOptions.None)
                Literal2.Text = Literal2.Text + "<small><cite>" + comunicazioni_array_line(0) + "</cite></small>"
                Literal2.Text = Literal2.Text + "<p>" + comunicazioni_array_line(1)
                Literal2.Text = Literal2.Text + "</blockquote>"
                Literal2.Text = Literal2.Text + "</div>"
                Literal2.Text = Literal2.Text + "</div>"
            End If
        Next
        '   <!-- Media item -->
        '<div class="media">
        '	<div class="media-object pull-left thumb"><img src="http://dummyimage.com/51x51/232323/ffffff&amp;text=photo" alt=""></div>
        '	<div class="media-body">
        '		<blockquote>
        '			<small><a href="#" title="" class="strong">Martin</a> <cite>just now</cite></small>
        '			<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin vitae accumsan mauris. Donec vitae nibh felis, facilisis bibendum sapien.</p>
        '		</blockquote>
        '	</div>
        '</div>
        '<!-- // Media item END -->

    End Sub

End Class