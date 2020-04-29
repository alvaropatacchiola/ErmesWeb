Public Class eliminaimpianto
    Inherits lingua

   

    Private Sub eliminaimpianto_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        tabella_impianto = Master.tabella_impianto_container
        Dim intestazione As String = ""
        Dim lista_impianti As New List(Of coppia)
        Dim primo As Boolean = True
        Dim index_accordion As Integer = 0
        If Not IsPostBack Then
            Literal2.Text = ""
            For Each dc In tabella_impianto
                Dim split_impianto() As String = dc.nome_impianto.Split(">")
                Dim presente As Boolean = False
                Dim coppia_temp As New coppia
                For Each dc1 In lista_impianti
                    If dc1.indice = split_impianto(0) Then
                        presente = True
                        dc1.valore = dc1.valore + ">" + split_impianto(1)
                        dc1.codice = dc1.codice + ">" + dc.identificativo
                    End If
                Next
                If presente = False Then
                    coppia_temp.indice = split_impianto(0)
                    coppia_temp.valore = split_impianto(1)
                    coppia_temp.codice = dc.identificativo
                    lista_impianti.Add(coppia_temp)
                End If
            Next
            For Each dc1 In lista_impianti
                Dim split_sub_impianto() As String = dc1.valore.Split(">")
                Dim split_sub_codice() As String = dc1.codice.Split(">")
                intestazione = "<div class=""accordion-group"">"
                intestazione = intestazione + "<div class=""accordion-heading"">"
                intestazione = intestazione + "<a class=""accordion-toggle"" data-toggle=""collapse"" data-parent=""#accordion2"" href=""#collapse" + index_accordion.ToString + """>"
                intestazione = intestazione + dc1.indice
                intestazione = intestazione + "</a>"
                intestazione = intestazione + "</div>"
                If primo Then
                    intestazione = intestazione + "<div id=""collapse" + index_accordion.ToString + """ class=""accordion-body collapse in"">"
                    Dim i As Integer = 0
                    For Each dc2 In split_sub_impianto
                        intestazione = intestazione + "<div class=""accordion-inner"">"
                        intestazione = intestazione + "<a href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_impianto('" + dc2 + "','" + split_sub_codice(i) + "')  "" > "
                        intestazione = intestazione + dc2 + " - " + split_sub_codice(i)
                        intestazione = intestazione + "</a>"
                        intestazione = intestazione + "</div>"
                        i = i + 1
                    Next

                    intestazione = intestazione + "</div>"
                Else
                    intestazione = intestazione + "<div id=""collapse" + index_accordion.ToString + """ class=""accordion-body collapse"">"

                    Dim i As Integer = 0
                    For Each dc2 In split_sub_impianto
                        intestazione = intestazione + "<div class=""accordion-inner"">"
                        intestazione = intestazione + "<a href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_impianto('" + dc2 + "','" + split_sub_codice(i) + "')  "" > "
                        intestazione = intestazione + dc2 + " - " + split_sub_codice(i)
                        intestazione = intestazione + "</a>"
                        intestazione = intestazione + "</div>"
                        i = i + 1
                    Next
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