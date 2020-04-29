Public Class modifica_utente
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable

        tabella_impianto = Master.tabella_impianto_container
        ' abilito pulsante modifica
        save_modifica_account_new.OnClientClick = String.Format("salva_dati(""{0}""); return false", _
                    ClientScript.GetPostBackEventReference(save_modifica_account_new, ""))


        If Not IsPostBack Then

            For Each dc In tabella_impianto
                inputcompany.Text = dc.azienda_persona
                Username.Text = Session("username")
                password.Text = Session("password")
                confirm_password.Text = Session("password")
                email_val.Text = dc.mail
                Exit Sub
            Next

        End If
    End Sub

    Protected Sub save_modifica_account_new_Click(sender As Object, e As EventArgs) Handles save_modifica_account_new.Click
        Dim result_update As Boolean = False
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim query As New query

        tabella_impianto = Master.tabella_impianto_container
        For Each dc In tabella_impianto
            result_update = query.update_super_user(Username.Text, password.Text, inputcompany.Text, email_val.Text, dc.id_super)
            Exit For
        Next
        If result_update Then ' aggiornamento avvenuto con successo
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("modifica_utente.aspx?result=1&niente=0")
        Else
            Response.Redirect("modifica_utente.aspx?result=2&niente=0")
        End If
    End Sub
End Class