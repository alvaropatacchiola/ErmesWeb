Public Class plant
    Inherits lingua

    Public Shared utilizzatoreListTemp As DropDownList = New DropDownList
    Public Shared nuovoImpianto As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub plant_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim serial As String = ""
        Dim codice_impianto As String = ""
        Dim newPlants As String = ""
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim indirizzo() As String
        Dim indirizzo_via() As String
        Dim nome_gruppo() As String
        Dim id_user_select As String = ""
        Dim id_user_modifica_setpoint As String = ""
        Dim lista_user_nuovo As New ListItem
        Dim elenco_sottogruppi_selected() As String
        Dim query As New query

        Dim checkedRadioSetpoimt As String = ""
        Dim checkedRadio As String = ""
        tabella_impianto = Master.tabella_impianto_container
        nuovoImpianto = False

        If Not IsPostBack Then
            serial = Page.Request("serial")
            codice_impianto = Page.Request("codice")
            newPlants = Page.Request("new")
            gruppi.Items.Clear()
            sottogruppi.Items.Clear()
            utilizzatore_list.Items.Clear()
            lista_user_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "empty") + " ..."
            lista_user_nuovo.Value = "0"
            utilizzatore_list.Items.Add(lista_user_nuovo)

            sottogruppi.Items.Clear()
            If codice_impianto IsNot Nothing Or serial IsNot Nothing Then
                If serial IsNot Nothing Then
                    codice_impianto = serial
                    newPlants = "1"
                End If
                inputCodice.Text = codice_impianto

            End If
            Dim lista_gruppi_nuovo As New ListItem
            Dim lista_sottogruppi_nuovo As New ListItem

            If newPlants IsNot Nothing Then
                nuovoImpianto = True
                Literal1.Visible = True
                Literal8.Visible = False
                lista_gruppi_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "new_val") + " .. "
                lista_gruppi_nuovo.Value = "nuovo"
                lista_sottogruppi_nuovo.Text = GetGlobalResourceObject("addimpianto_global", "new_val") + " .. "
                lista_sottogruppi_nuovo.Value = "nuovo"
                gruppi.Items.Add(lista_gruppi_nuovo)
                sottogruppi.Items.Add(lista_sottogruppi_nuovo)
                inputCodice.ReadOnly = False
            Else
                Literal1.Visible = False
                Literal8.Visible = True
            End If

            For Each dc In tabella_impianto
                Dim lista_gruppi_item As New ListItem
                nome_gruppo = dc.nome_impianto.Split(">")
                If gruppi.Items.FindByText(nome_gruppo(0)) Is Nothing Then
                    lista_gruppi_item.Value = nome_gruppo(0) + ">" + nome_gruppo(1)
                    lista_gruppi_item.Text = nome_gruppo(0)
                    gruppi.Items.Add(lista_gruppi_item)
                Else
                    gruppi.Items.FindByText(nome_gruppo(0)).Value = gruppi.Items.FindByText(nome_gruppo(0)).Value + ">" + nome_gruppo(1)
                End If

                If dc.identificativo = codice_impianto Then
                    Try
                        id_user_select = dc.id_user
                        id_user_modifica_setpoint = dc.modifica_setpoint_user1
                    Catch ex As Exception

                    End Try

                    'inputCodice.Text = codice_impianto
                    textDescription.Text = dc.descrizione_impianato
                    If InStr(dc.indirizzo, "-") <> 0 Then
                        indirizzo = dc.indirizzo.Split("-")
                        countries.SelectedValue = indirizzo(0)
                        inputTitle.Text = indirizzo(2) 'citta
                        Text1.Text = indirizzo(3) 'provincia
                        indirizzo_via = indirizzo(4).Split(",")
                        If indirizzo_via.Length > 1 Then
                            Text2.Text = indirizzo_via(0)
                            Text3.Text = indirizzo_via(1)
                        End If
                    End If
                    Text4.Text = dc.referente 'referente nome
                    Text6.Text = dc.telefono_referente 'referente telefono
                    Text7.Text = dc.mail_referente 'referente mail

                    alarmMail.Checked = dc.Expr11

                    textGruppo.Text = nome_gruppo(0) 'gruppo
                    Text11.Text = nome_gruppo(1) 'sottogruppo
                    gruppi.Items.FindByText(nome_gruppo(0)).Selected = True
                End If
            Next

            table_create.Text = "<table id =""main_table"" width = ""100%"" border=""0"" cellspacing=""2"" cellpadding=""6"" style=""padding-bottom:20px;"">"
            table_create.Text = table_create.Text + "<tbody>"

            table_create.Text = table_create.Text + "<tr style = ""text-align:left;border-bottom: 1px solid #e6e6e6;"" >"

            table_create.Text = table_create.Text + "<td>"
            table_create.Text = table_create.Text + "<div style= ""float:left;width:25%"">" + Literal23.Text + "</div>"
            table_create.Text = table_create.Text + "<div style= ""float:left;width:25%;text-align:center;"">" + GetLocalResourceObject("Literal2Resource1.Text") + "</div>"
            table_create.Text = table_create.Text + "<div style= ""float:left;width:25%;text-align:center;"">" + GetLocalResourceObject("modificaparametri.Text") + "</div>"
            table_create.Text = table_create.Text + "<div style= ""float:left;width:25%""></div>"
            table_create.Text = table_create.Text + "</td>"
            table_create.Text = table_create.Text + "</tr>"
            '  <tr style = "    border-bottom: 1px solid #e6e6e6;" >
            ' <td>Alvaro Patacchiola</td>
            '<td> <div Class="radio" id="uniform-undefined"><span class=""><input type="radio" class="radio" name="radio" value="1" style="opacity: 0;"></span></div></td>
            '    <td> <div Class="radio" id="uniform-undefined"><span class=""><input type="radio" class="radio" name="radio" value="1" style="opacity: 0;"></span></div></td>
            '<td Class="center">
            '<span Class="btn btn-block btn-danger btn-icon glyphicons remove"><i></i>Remove</span>
            '   </td>

            ' </tr>
            java_script.Text = "<script>"
            java_script.Text = java_script.Text + "var array_inclusi=[];"
            java_script.Text = java_script.Text + "var array_esclusi=[];"
            java_script.Text = java_script.Text + "var traduzione_elimina ='" + GetGlobalResourceObject("main_master_global", "elimina") + "';"
            Dim id_user_select_array() As String = id_user_select.Split(",")
            Dim id_user_setpoint_array() As String = id_user_modifica_setpoint.Split(",")
            For Each dc1 In query.get_user_to_super(Master.id_super_container)
                Dim lista_user_nuovo_item As New ListItem
                lista_user_nuovo_item.Text = dc1.nome
                lista_user_nuovo_item.Value = dc1.Id_user.ToString + "," + dc1.nome + "," + dc1.username + "," + dc1.password + ",False"
                If checkUserList(id_user_select_array, dc1.Id_user.ToString) = dc1.Id_user.ToString Then
                    java_script.Text = java_script.Text + "array_inclusi.push('" + dc1.Id_user.ToString + "," + dc1.nome + "," + dc1.username + "," + dc1.password + "," + id_user_setpoint_array(checkUserListIndice(id_user_select_array, dc1.Id_user.ToString)) + "');"
                    table_create.Text = table_create.Text + " <tr id =""" + dc1.Id_user.ToString + """ style = ""    border-bottom: 1px solid #e6e6e6;"" >"
                    table_create.Text = table_create.Text + "<td><div class=""widget-body uniformjs"">"
                    If id_user_setpoint_array(checkUserListIndice(id_user_select_array, dc1.Id_user.ToString)) = "True" Then
                        checkedRadioSetpoimt = "checked"
                        checkedRadio = ""
                    Else
                        checkedRadioSetpoimt = ""
                        checkedRadio = "checked"

                    End If
                    table_create.Text = table_create.Text + "<div style= ""float:left;width:25%;"">" + dc1.nome + "</div>"
                    table_create.Text = table_create.Text + "<div style= ""float:left;width:25%;text-align:center;""> <input type=""radio"" " + checkedRadioSetpoimt + " class=""radio"" name=""" + dc1.Id_user.ToString + """ value=""1"" /></div>"

                    table_create.Text = table_create.Text + "<div style= ""float:left;width:25%;text-align:center;""> <input type=""radio"" " + checkedRadio + " class=""radio"" name=""" + dc1.Id_user.ToString + """ value=""0"" /></div>"
                    table_create.Text = table_create.Text + "<div style= ""float:left;width:25%;text-align:center;"">"
                    table_create.Text = table_create.Text + "<span Class=""btn btn-block btn-danger btn-icon glyphicons remove"" style=""min-width:100px;""><i></i>" + GetGlobalResourceObject("main_master_global", "elimina") + "</span>"
                    table_create.Text = table_create.Text + "</div>"
                    table_create.Text = table_create.Text + "</div></td>"
                Else
                    java_script.Text = java_script.Text + "array_esclusi.push('" + dc1.Id_user.ToString + "," + dc1.nome + "," + dc1.username + "," + dc1.password + ",False');"
                    utilizzatore_list.Items.Add(lista_user_nuovo_item)
                End If
                ' If id_user_select = dc1.Id_user Then
                'utilizzatore_list.SelectedValue = dc1.Id_user.ToString + "," + dc1.nome + "," + dc1.username + "," + dc1.password + "," + dc1.setpoint.ToString
                'End If
            Next
            java_script.Text = java_script.Text + "</script>"
            table_create.Text = table_create.Text + "</tbody>"
            table_create.Text = table_create.Text + "</table>"
            elenco_sottogruppi_selected = gruppi.SelectedValue.Split(">")
            Dim primo As Boolean = True
            For Each dc3 In elenco_sottogruppi_selected
                Dim lista_user_nuovo_item As New ListItem
                If primo = False Then
                    lista_user_nuovo_item.Text = dc3
                    lista_user_nuovo_item.Value = dc3
                    sottogruppi.Items.Add(lista_user_nuovo_item)
                    sottogruppi.SelectedValue = Text11.Text
                End If
                primo = False
            Next

        End If
    End Sub
    Private Function checkUserList(ByVal arrayList() As String, ByVal currentIndex As String) As String
        For Each indice As String In arrayList
            If indice = currentIndex Then
                Return currentIndex
            End If
        Next
        Return "null"
    End Function
    Private Function checkUserListIndice(ByVal arrayList() As String, ByVal currentIndex As String) As Integer
        Dim indice_def As Integer = 0
        For Each indice As String In arrayList
            If indice = currentIndex Then
                Return indice_def
            End If
            indice_def = indice_def + 1
        Next
        Return 0
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Sub updateList(ByVal parametro As String)
        parametro = parametro.Replace("""", "")
        Dim parametroArray() As String = parametro.Split("^")
        utilizzatoreListTemp.Items.Clear()

        For Each elemento As String In parametroArray
            Dim lista_user_nuovo_item As New ListItem
            lista_user_nuovo_item.Value = elemento
            utilizzatoreListTemp.Items.Add(lista_user_nuovo_item)
        Next

    End Sub

    Protected Sub save_modifica_impianto_new_Click(sender As Object, e As EventArgs) Handles save_modifica_impianto_new.Click
        If nuovoImpianto Then
            aggiungiImpianto()
        Else
            aggiornaImpianto()
        End If
    End Sub
    Private Sub aggiungiImpianto()
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
        Dim codice_user As String = "00000000-0000-0000-0000-000000000000"
        Dim admin_user As String = "False"

        indirizzo = countries.SelectedValue + "-"
        indirizzo = indirizzo + countries.SelectedItem.Text + "-"
        indirizzo = indirizzo + inputTitle.Text + "-"
        indirizzo = indirizzo + Text1.Text + "-"
        indirizzo = indirizzo + Text2.Text + "," + Text3.Text

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
            For Each valueOption As ListItem In utilizzatoreListTemp.Items
                If valueOption.Text.Length > 10 Then
                    Dim splitValueOption() As String = valueOption.Value.Split(",")
                    codice_user = codice_user + "," + splitValueOption(0)
                    admin_user = admin_user + "," + splitValueOption(4)
                End If
            Next
            For Each dc1 In query.getTypeSerialNumber(inputCodice.Text)
                typeStrumento = dc1.type
                Exit For
            Next
            result_query = query.insert_impianto(Master.id_super_container, codice_user, indirizzo, nome_impianto, textDescription.Text,
                                               inputCodice.Text, Text4.Text, Now, Text6.Text, Text7.Text, admin_user, typeStrumento)

        End If
        If result_query Then
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("dashboardAssets.aspx")
        End If
    End Sub
    Private Sub aggiornaImpianto()
        Dim result_query As Boolean = False
        Dim indirizzo As String = ""
        Dim nome_impianto As String = ""
        Dim query As New query
        Dim codice_user As String = "00000000-0000-0000-0000-000000000000"
        Dim admin_user As String = "False"
        Dim function_java As String = ""
        Dim java_script_impianti As java_script = New java_script

        indirizzo = countries.SelectedValue + "-"
        indirizzo = indirizzo + countries.SelectedItem.Text + "-"
        indirizzo = indirizzo + inputTitle.Text + "-"
        indirizzo = indirizzo + Text1.Text + "-"
        indirizzo = indirizzo + Text2.Text + "," + Text3.Text

        'nome_impianto = gruppi.SelectedItem.Text + ">" + Text11.Text
        nome_impianto = textGruppo.Text + ">" + Text11.Text
        'MsgBox("ciao")
        For Each valueOption As ListItem In utilizzatoreListTemp.Items
            If valueOption.Text.Length > 10 Then
                Dim splitValueOption() As String = valueOption.Value.Split(",")
                codice_user = codice_user + "," + splitValueOption(0)
                admin_user = admin_user + "," + splitValueOption(4)
            End If
        Next
        If (inputCodice.Text = "128718") Or (inputCodice.Text = "912601") Then
            result_query = True
        Else
            result_query = query.update_impianto(codice_user, indirizzo, nome_impianto, textDescription.Text,
                               inputCodice.Text, Text4.Text, Now, Text6.Text, Text7.Text, admin_user, alarmMail.Checked)
        End If


        If result_query Then ' salvataggio avvenuto con successo
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("dashboardAssets.aspx")
        Else
            function_java = function_java + "errorUpdate();"
            java_script_impianti.call_function_javascript_onload(Page, function_java)
        End If

    End Sub
End Class