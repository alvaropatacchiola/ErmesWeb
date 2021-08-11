Imports System.IO
Public Class settings
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable

        tabella_impianto = Master.tabella_impianto_container



        If Not IsPostBack Then

            For Each dc In tabella_impianto
                inputcompany.Text = dc.azienda_persona
                Username.Text = Session("username")
                password.Text = Session("password")
                password.Attributes("value") = Session("password")

                confirm_password.Text = Session("password")
                confirm_password.Attributes("value") = Session("password")

                email_val.Text = dc.mail
                Exit Sub
            Next

        End If
    End Sub

    Protected Sub save_modifica_account_new_Click(sender As Object, e As EventArgs) Handles save_modifica_account_new.Click
        Dim result_update As Boolean = False
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim dcRow As ermes_web_20.quey_db.impianto_newRow
        Dim query As New query
        Dim function_java As String = ""
        Dim java_script_impianti As java_script = New java_script


        tabella_impianto = Master.tabella_impianto_container
        For Each dc In tabella_impianto
            dcRow = dc
            'result_update = query.update_super_user(Username.Text, password.Text, inputcompany.Text, email_val.Text, dc.id_super)
            Exit For
        Next

        result_update = query.update_super_user(Username.Text, password.Text, inputcompany.Text, email_val.Text, dcRow.id_super, dcRow.colorBody, dcRow.colorSide, dcRow.colorPrimary, dcRow.colorLink)

        'Display the success message.
        'lblMessage.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded."


        'salvataggio file

        If result_update Then ' aggiornamento avvenuto con successo
            Master.create_master_page()
            Master.manage_sidebar_top()
            Response.Redirect("dashboardAssets.aspx")
            'Response.Redirect("modifica_utente.aspx?result=1&niente=0")
        Else
            function_java = function_java + "errorUpdate();"
            java_script_impianti.call_function_javascript_onload(Page, function_java)
            'Response.Redirect("modifica_utente.aspx?result=2&niente=0")
        End If
    End Sub
End Class