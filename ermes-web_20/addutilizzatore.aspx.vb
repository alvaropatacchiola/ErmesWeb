Public Class addutilizzatore
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' abilito pulsante modifica
        save_aggiungi_utilizzatore_new.OnClientClick = String.Format("salva_dati(""{0}""); return false", _
                    ClientScript.GetPostBackEventReference(save_aggiungi_utilizzatore_new, ""))
    End Sub

    Protected Sub save_aggiungi_utilizzatore_new_Click(sender As Object, e As EventArgs) Handles save_aggiungi_utilizzatore_new.Click
        Dim query As New query

        If query.check_user(username_utilizzatore.Text, password_utilizzatore.Text) Then ' user ok
            Dim codice_user As Guid
            codice_user = Guid.NewGuid()
            query.insert_user(codice_user, Master.id_super_container, username_utilizzatore.Text, password_utilizzatore.Text, modifica_setpoint.Checked, nome_utilizzatore.Text)

            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("addutilizzatore.aspx?result=1&niente=0")
        Else
            Response.Redirect("addutilizzatore.aspx?result=2&niente=0")
        End If
    End Sub
End Class