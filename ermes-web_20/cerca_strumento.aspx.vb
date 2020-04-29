Public Class cerca_strumento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub save_aggiungi_utilizzatore_new_Click(sender As Object, e As EventArgs) Handles save_aggiungi_utilizzatore_new.Click
        Response.Redirect("risultato_dispositivo.aspx?codice=" + codice_dispositivo.Text)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("username") = "produzione"
        Session("password") = "produzione"
        Session("mid_super") = "11111111111111111111111"
        Response.Redirect("drag_usb_log.aspx")
    End Sub
End Class