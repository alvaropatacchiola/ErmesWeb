Public Class modificautilizzatore_form
    Inherits lingua
    Public Shared id_user As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim username As String
        Dim nome_user As String
        Dim password As String
        Dim modifica_sp As String
        If Not IsPostBack Then
            username = Page.Request("username")
            password = Page.Request("password")
            modifica_sp = Page.Request("modifica")
            nome_user = Page.Request("utilizzatore")
            id_user = Page.Request("codice")

            nome_utilizzatore.Text = nome_user
            username_utilizzatore.Text = username
            password_utilizzatore.Text = password
            If nome_user = "True" Then
                modifica_setpoint.Checked = True
            Else
                modifica_setpoint.Checked = False
            End If
            save_aggiungi_utilizzatore_new.OnClientClick = String.Format("salva_dati(""{0}""); return false", _
                        ClientScript.GetPostBackEventReference(save_aggiungi_utilizzatore_new, ""))
        End If


    End Sub

    Protected Sub save_aggiungi_utilizzatore_new_Click(sender As Object, e As EventArgs) Handles save_aggiungi_utilizzatore_new.Click
        Dim query As New query
        Dim codice_user As Guid = New Guid(id_user)

        If query.check_user_update(username_utilizzatore.Text, password_utilizzatore.Text, codice_user) Then ' user ok
            If query.update_user(codice_user, nome_utilizzatore.Text, username_utilizzatore.Text, password_utilizzatore.Text, modifica_setpoint.Checked) Then
                Master.create_master_page()
                Master.manage_sidebar_top()
                Response.Redirect("modifica_utilizzatore.aspx?result=1&niente=0")
            Else
                Response.Redirect("modifica_utilizzatore.aspx?result=2&niente=0")
            End If
        Else
            Response.Redirect("modifica_utilizzatore.aspx?result=2&niente=0")
        End If
    End Sub
End Class