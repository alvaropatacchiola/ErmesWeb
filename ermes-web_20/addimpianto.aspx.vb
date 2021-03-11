Public Class addimpianto
    Inherits lingua

  

    Private Sub addimpianto_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim indirizzo As String
        Dim nome_impianto As String
        Dim lista_indirizzi As New ListItemCollection
        Dim function_java As String = ""
        Dim java_script_impianti As java_script = New java_script
        Dim query As New query

        Dim serial As String = ""

        serial = Page.Request("serial")

        save_impianto_new.OnClientClick = String.Format("salva_dati(""{0}""); return false", _
           ClientScript.GetPostBackEventReference(save_impianto_new, ""))

        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        If Not IsPostBack Then
           
            tabella_impianto = Master.tabella_impianto_container
            indirizzi.Items.Clear()
            gruppi.Items.Clear()
            sottogruppi.Items.Clear()
            utilizzatore_list.Items.Clear()
            Dim lista_indirizzi_nuovo As New ListItem
            Dim lista_gruppi_nuovo As New ListItem
            Dim lista_sottogruppi_nuovo As New ListItem
            Dim lista_user_nuovo As New ListItem
            Dim lista_user_nuovo1 As New ListItem
            lista_indirizzi_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "new_val") + " .. "
            lista_indirizzi_nuovo.Value = "nuovo"
            lista_gruppi_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "new_val") + " .. "
            lista_gruppi_nuovo.Value = "nuovo"
            lista_sottogruppi_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "new_val") + " .. "
            lista_sottogruppi_nuovo.Value = "nuovo"
            lista_user_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "empty") + " .. "
            lista_user_nuovo.Value = "0"

            indirizzi.Items.Add(lista_indirizzi_nuovo)
            gruppi.Items.Add(lista_gruppi_nuovo)
            sottogruppi.Items.Add(lista_sottogruppi_nuovo)
            utilizzatore_list.Items.Add(lista_user_nuovo)
            lista_user_nuovo1.Text = GetGlobalResourceObject("addimpianto_global", "new_val") + " .. "
            lista_user_nuovo1.Value = "1"
            utilizzatore_list.Items.Add(lista_user_nuovo1)
            If serial IsNot Nothing Then
                inputCodice.Text = serial
            End If

            For Each dc1 In query.get_user_to_super(Master.id_super_container)
                Dim lista_user_nuovo_item As New ListItem
                lista_user_nuovo_item.Text = dc1.nome
                lista_user_nuovo_item.Value = dc1.Id_user.ToString + "," + dc1.nome + "," + dc1.username + "," + dc1.password + "," + dc1.setpoint.ToString
                utilizzatore_list.Items.Add(lista_user_nuovo_item)
            Next
            For Each dc In tabella_impianto
                Dim lista_indirizzi_item As New ListItem
                Dim lista_gruppi_item As New ListItem
                Dim split_value() As String = dc.indirizzo.Split("-")
                Dim split_impianto() As String = dc.nome_impianto.Split(">")
                Dim first_element As Boolean = True
                If (dc.indirizzo.Length > 5) Then
                    lista_indirizzi_item.Value = dc.indirizzo
                End If

                nome_impianto = dc.nome_impianto

                If gruppi.Items.FindByText(split_impianto(0)) Is Nothing Then
                    lista_gruppi_item.Value = split_impianto(0) + ">" + split_impianto(1)
                    lista_gruppi_item.Text = split_impianto(0)
                    gruppi.Items.Add(lista_gruppi_item)
                Else
                    gruppi.Items.FindByText(split_impianto(0)).Value = gruppi.Items.FindByText(split_impianto(0)).Value + ">" + split_impianto(1)
                End If
                lista_indirizzi_item.Text = ""
                For Each elements In split_value
                    If first_element = False Then
                        If elements <> "" Then
                            lista_indirizzi_item.Text = lista_indirizzi_item.Text + " - " + elements
                        End If
                    End If
                    first_element = False
                Next
                If (dc.indirizzo.Length > 5) Then
                    indirizzi.Items.Add(lista_indirizzi_item)
                End If
            Next
            function_java = function_java + "manage_nuovi_impianti();"
            java_script_impianti.call_function_javascript_onload(Page, function_java)
        End If
    End Sub
    
    Private Sub save_impianto_new_Click(sender As Object, e As EventArgs) Handles save_impianto_new.Click
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable

        Dim tabella_pompe As ermes_web_20.quey_db.typeSerialNumberDataTable

        Dim function_java As String = ""
        Dim java_script_impianti As java_script = New java_script
        Dim query As New query
        Dim indirizzo As String = ""
        Dim nome_impianto As String = ""
        Dim result_query As Boolean = False
        Dim stringa_user As String = ""
        Dim typeStrumento As Integer = 0

        If indirizzi.SelectedValue = "nuovo" Then
            indirizzo = countries.SelectedValue + "-"
            indirizzo = indirizzo + countries.SelectedItem.Text + "-"
            indirizzo = indirizzo + inputTitle.Text + "-"
            indirizzo = indirizzo + Text1.Text + "-"
            indirizzo = indirizzo + Text2.Text + "," + Text3.Text
        Else
            indirizzo = indirizzi.SelectedValue
        End If

        If gruppi.SelectedValue = "nuovo" Then
            nome_impianto = textGruppo.Text + ">" + Text11.Text
        Else
            If sottogruppi.SelectedValue = "nuovo" Then
                nome_impianto = gruppi.SelectedItem.Text + ">" + Text11.Text
            Else
                nome_impianto = gruppi.SelectedItem.Text + ">" + Text11.Text
            End If
        End If
        tabella_impianto = Master.tabella_impianto_container
        If query.check_identificativo(inputCodice.Text) Then ' se true esiste gia questo codice
            function_java = function_java + "identificativo_presente();"
            java_script_impianti.call_function_javascript_onload(Page, function_java)
            Exit Sub
        Else
            If utilizzatore_list.SelectedValue <> "0" Then '  user aggiunto
                If utilizzatore_list.SelectedValue = "1" Then ' nuovo user aggiunto
                    If query.check_user(Text9.Text, Text10.Text) Then ' user ok
                        Dim codice_user As Guid

                        For Each dc1 In query.getTypeSerialNumber(inputCodice.Text)
                            typeStrumento = dc1.type
                            Exit For
                        Next
                        codice_user = Guid.NewGuid()
                        query.insert_user(codice_user, Master.id_super_container, Text9.Text, Text10.Text, check1.Checked, Text12.Text)
                        result_query = query.insert_impianto(Master.id_super_container, codice_user.ToString, indirizzo, nome_impianto, textDescription.Text,
                                                       inputCodice.Text, Text4.Text, Now, Text6.Text, Text7.Text, check1.Checked, typeStrumento)
                    Else
                        function_java = function_java + "user_presente();"
                        java_script_impianti.call_function_javascript_onload(Page, function_java)
                        Exit Sub
                    End If

                Else 'utilizzatore gia presente selezionare
                    Dim split_stringa_user() As String = utilizzatore_list.SelectedValue.Split(",")
                    Dim codice_user As Guid = New Guid(split_stringa_user(0))
                    For Each dc1 In query.getTypeSerialNumber(inputCodice.Text)
                        typeStrumento = dc1.type
                        Exit For
                    Next
                    result_query = query.insert_impianto(Master.id_super_container, codice_user.ToString, indirizzo, nome_impianto, textDescription.Text,
                                                   inputCodice.Text, Text4.Text, Now, Text6.Text, Text7.Text, check1.Checked, typeStrumento)

                End If

            Else ' nessun user aggiunto
                For Each dc1 In query.getTypeSerialNumber(inputCodice.Text)
                    typeStrumento = dc1.type
                    Exit For
                Next
                result_query = query.insert_impianto(Master.id_super_container, "00000000-0000-0000-0000-000000000000", indirizzo, nome_impianto, textDescription.Text,
                                               inputCodice.Text, Text4.Text, Now, Text6.Text, Text7.Text, False, typeStrumento)
            End If
        End If
        If result_query Then
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("dashboardNew.aspx")
        End If
    End Sub

   

    
End Class