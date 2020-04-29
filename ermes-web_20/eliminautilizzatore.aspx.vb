Public Class eliminautilizzatore
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim table_user As ermes_web_20.quey_db.userDataTable = New ermes_web_20.quey_db.userDataTable
            Dim query As New query
            Dim index_accordion As Integer = 0
            Dim primo As Boolean = True
            Literal2.Text = ""
            Dim intestazione As String = ""
            table_user = query.get_user_to_super(Master.id_super_container)
            For Each dc In table_user
                intestazione = "<div class=""accordion-group"">"
                intestazione = intestazione + "<div class=""accordion-heading"">"
                intestazione = intestazione + "<a class=""accordion-toggle"" data-toggle=""collapse"" data-parent=""#accordion2"" href=""#collapse" + index_accordion.ToString + """>"
                intestazione = intestazione + dc.nome + " - " + dc.username
                intestazione = intestazione + "</a>"
                intestazione = intestazione + "</div>"
                If primo Then
                    intestazione = intestazione + "<div id=""collapse" + index_accordion.ToString + """ class=""accordion-body collapse in"">"
                    Dim i As Integer = 0
                    Dim lista_impianti_user As ermes_web_20.quey_db.impianto_newDataTable = New ermes_web_20.quey_db.impianto_newDataTable
                    lista_impianti_user = query.get_lista_impianti_user(dc.Id_user.ToString)
                    For Each dc2 In lista_impianti_user
                        intestazione = intestazione + "<div class=""accordion-inner"">"
                        'href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_impianto('" + dc2 + "','" + split_sub_codice(i) + "')  ""
                        intestazione = intestazione + "<p > "
                        intestazione = intestazione + dc2.nome_impianto
                        intestazione = intestazione + "</p>"
                        intestazione = intestazione + "</div>"
                        i = i + 1
                    Next
                    intestazione = intestazione + "<a href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_user('" + dc.Id_user.ToString + "','" + dc.nome + "')""><span class=""btn btn-primary btn-warning"">" + GetGlobalResourceObject("utilizzatore_global", "elimina_user") + "</span></a>"
                    intestazione = intestazione + "<div>"
                    intestazione = intestazione + "&nbsp"
                    intestazione = intestazione + "</div>"

                    intestazione = intestazione + "</div>"
                Else
                    intestazione = intestazione + "<div id=""collapse" + index_accordion.ToString + """ class=""accordion-body collapse"">"

                    Dim i As Integer = 0
                    Dim lista_impianti_user As ermes_web_20.quey_db.impianto_newDataTable = New ermes_web_20.quey_db.impianto_newDataTable
                    lista_impianti_user = query.get_lista_impianti_user(dc.Id_user.ToString)

                    For Each dc2 In lista_impianti_user
                        intestazione = intestazione + "<div class=""accordion-inner"">"
                        'href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_impianto('" + dc2 + "','" + split_sub_codice(i) + "')  ""
                        intestazione = intestazione + "<p > "
                        intestazione = intestazione + dc2.nome_impianto
                        intestazione = intestazione + "</p>"
                        intestazione = intestazione + "</div>"
                        i = i + 1
                    Next
                    intestazione = intestazione + "<a href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_user('" + dc.Id_user.ToString + "','" + dc.nome + "')""><span class=""btn btn-primary btn-warning"">" + GetGlobalResourceObject("utilizzatore_global", "elimina_user") + "</span></a>"
                    intestazione = intestazione + "<div>"
                    intestazione = intestazione + "&nbsp"
                    intestazione = intestazione + "</div>"

                    intestazione = intestazione + "</div>"
                End If
                intestazione = intestazione + "</div>"
                primo = False
                index_accordion = index_accordion + 1
                Literal2.Text = Literal2.Text + intestazione
            Next

        End If
    End Sub

End Class