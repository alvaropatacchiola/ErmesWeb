Public Class eliminaController
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim tabella_strumento As ermes_web_20.quey_db.strumentiDataTable
        tabella_impianto = Master.tabella_impianto_container
        tabella_strumento = Session("strumento")
        Dim intestazione As String = ""
        Dim lista_impianti As New List(Of coppia)
        Dim primo As Boolean = True
        Dim index_accordion As Integer = 0
        If Not IsPostBack Then
            For Each dc In tabella_impianto
                Dim split_impianto() As String = dc.nome_impianto.Split(">")
                Dim presente As Boolean = False
                Dim coppia_temp As New coppia
                For Each dc1 In lista_impianti
                    If dc1.indice = split_impianto(0) Then
                        presente = True
                        Dim time_connected As Long
                        For Each dc2 In tabella_strumento
                            If (dc2.codice = dc.identificativo) Then
                                If Not (main_function.check_is_connected(dc2.data_aggiornamento, time_connected)) Then
                                    dc1.valore = dc1.valore + ">" + split_impianto(1)
                                    dc1.codice = dc1.codice + ">" + dc.identificativo
                                    dc1.id485 = dc1.id485 + ">" + dc2.id_485
                                    dc1.tipoStrumento = dc1.tipoStrumento + ">" + dc2.tipo_strumento
                                    dc1.descrizione = dc1.descrizione + ">" + dc2.tipo_strumento + " | RS485 ID:" + dc2.id_485
                                End If
                            End If
                        Next
                    End If
                Next
                If presente = False Then
                    Dim time_connected As Long
                    Dim presenteNotConnected As Boolean = False
                    For Each dc2 In tabella_strumento
                        If (dc2.codice = dc.identificativo) Then
                            If Not (main_function.check_is_connected(dc2.data_aggiornamento, time_connected)) Then
                                If presenteNotConnected Then
                                    'coppia_temp.indice = coppia_temp.indice + ">" + split_impianto(0)
                                    coppia_temp.valore = coppia_temp.valore + ">" + split_impianto(1)
                                    coppia_temp.codice = coppia_temp.codice + ">" + dc.identificativo
                                    coppia_temp.id485 = coppia_temp.id485 + ">" + dc2.id_485
                                    coppia_temp.tipoStrumento = coppia_temp.tipoStrumento + ">" + dc2.tipo_strumento
                                    'Dim coppia_temp As New coppia
                                    coppia_temp.descrizione = coppia_temp.descrizione + ">" + dc2.tipo_strumento + " | RS485 ID:" + dc2.id_485
                                Else
                                    coppia_temp.indice = split_impianto(0)
                                    coppia_temp.valore = split_impianto(1)
                                    coppia_temp.codice = dc.identificativo
                                    coppia_temp.id485 = dc2.id_485
                                    coppia_temp.tipoStrumento = dc2.tipo_strumento
                                    'Dim coppia_temp As New coppia
                                    coppia_temp.descrizione = dc2.tipo_strumento + " | RS485 ID:" + dc2.id_485

                                End If
                                presenteNotConnected = True
                            End If
                        End If
                    Next
                    If presenteNotConnected Then
                        lista_impianti.Add(coppia_temp)
                    End If
                End If
            Next
            For Each dc1 In lista_impianti
                Dim split_sub_impianto() As String = dc1.valore.Split(">")
                Dim split_sub_codice() As String = dc1.codice.Split(">")
                Dim split_sub_strumento() As String = dc1.descrizione.Split(">")
                Dim split_sub_id485() As String = dc1.id485.Split(">")
                Dim split_sub_tipoStrumento() As String = dc1.tipoStrumento.Split(">")
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
                        intestazione = intestazione + "<a href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_controller('" + dc2 + "','" + split_sub_codice(i) + " - " + split_sub_strumento(i) + "','" + split_sub_id485(i) + "','" + split_sub_codice(i) + "','" + split_sub_tipoStrumento(i) + "')  "" > "
                        intestazione = intestazione + dc2 + " - " + split_sub_codice(i) + " - " + split_sub_strumento(i)
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
                        intestazione = intestazione + "<a href=""dashboard.aspx"" data-layout=""center"" data-type=""confirm"" data-toggle=""notyfy"" onclick=""javascript:elimina_controller('" + dc2 + "','" + split_sub_codice(i) + " - " + split_sub_strumento(i) + "','" + split_sub_id485(i) + "','" + split_sub_codice(i) + "','" + split_sub_tipoStrumento(i) + "')  "" > "
                        intestazione = intestazione + dc2 + " - " + split_sub_codice(i) + " - " + split_sub_strumento(i)
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