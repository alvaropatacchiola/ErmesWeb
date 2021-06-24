Public Class utilizzatore
    Inherits lingua
    Public Shared id_user As String
    Public Shared newPlants As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub utilizzatore_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim username As String
        Dim nome_user As String
        Dim password As String



        If Not IsPostBack Then
            newPlants = Nothing
            username = Page.Request("username")
            password = Page.Request("password")
            nome_user = Page.Request("utilizzatore")
            id_user = Page.Request("codice")
            newPlants = Page.Request("new")

            If newPlants Is Nothing Then
                nome_utilizzatore.Text = nome_user
                username_utilizzatore.Text = username
                password_utilizzatore.Text = password
            End If
        End If
    End Sub

    Protected Sub save_aggiungi_utilizzatore_new_Click(sender As Object, e As EventArgs) Handles save_aggiungi_utilizzatore_new.Click
        Dim function_java As String = ""
        Dim java_script_impianti As java_script = New java_script

        If newPlants Is Nothing Then
            Dim query As New query
            Dim codice_user As Guid = New Guid(id_user)

            If query.check_user_update(username_utilizzatore.Text, password_utilizzatore.Text, codice_user) Then ' user ok
                If query.update_user(codice_user, nome_utilizzatore.Text, username_utilizzatore.Text, password_utilizzatore.Text, False) Then
                    Master.create_master_page()
                    Master.manage_sidebar_top()
                    function_java = function_java + "utilizzatoreOK();"
                    java_script_impianti.call_function_javascript_onload(Page, function_java)
                Else
                    function_java = function_java + "utilizzatoreDuplicato();"
                    java_script_impianti.call_function_javascript_onload(Page, function_java)
                End If
            Else
                function_java = function_java + "utilizzatoreDuplicato();"
                java_script_impianti.call_function_javascript_onload(Page, function_java)
            End If
        Else
            Dim query As New query
            If query.check_user(username_utilizzatore.Text, password_utilizzatore.Text) Then ' user ok
                Dim codice_user As Guid
                codice_user = Guid.NewGuid()
                query.insert_user(codice_user, Master.id_super_container, username_utilizzatore.Text, password_utilizzatore.Text, False, nome_utilizzatore.Text)

                Master.create_master_page()
                Master.manage_sidebar_top()
                function_java = function_java + "utilizzatoreOK();"
                java_script_impianti.call_function_javascript_onload(Page, function_java)
            Else
                function_java = function_java + "utilizzatoreDuplicato();"
                java_script_impianti.call_function_javascript_onload(Page, function_java)

            End If
        End If
    End Sub
End Class