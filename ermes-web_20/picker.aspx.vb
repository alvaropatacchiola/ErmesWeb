Imports System.IO
Public Class picker
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable

        tabella_impianto = Master.tabella_impianto_container

        If Not IsPostBack Then
            For Each dc In tabella_impianto
                color_body.Text = dc.colorBody
                color.Text = dc.colorSide
                color_primary.Text = dc.colorPrimary
                color_links.Text = dc.colorLink

                logoAssents.Text = "<img src=""assets/img/" + dc.logo + """ alt=""Mono"">"
                slide.Text = Replace(dc.aziendaPersonalizzazione, " ", "")
            Next
        End If
    End Sub

    Protected Sub save_modifica_account_new_Click(sender As Object, e As EventArgs) Handles save_modifica_account_new.Click
        Dim function_java As String = ""
        Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
        Dim result_update As Boolean = False
        Dim dcRow As ermes_web_20.quey_db.impianto_newRow
        Dim query As New query

        Dim java_script_impianti As java_script = New java_script
        Dim folderPath As String = Server.MapPath("~/assets/img/")
        Dim extension As String = Path.GetExtension(FileUpload1.FileName)
        Dim colorBody As String = color_body.Text
        Dim colorSide As String = color.Text

        tabella_impianto = Master.tabella_impianto_container
        For Each dc In tabella_impianto
            dcRow = dc
            'result_update = query.update_super_user(Username.Text, password.Text, inputcompany.Text, email_val.Text, dc.id_super)
            Exit For
        Next

        If extension.ToLower = ".jpeg" Or extension.ToLower = ".jpg" Or extension.ToLower = ".png" Then
            'Check whether Directory (Folder) exists.
            If Not Directory.Exists(folderPath) Then
                'If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath)
            End If
            If (FileUpload1.FileBytes.Length <= 2000000) Then

                Dim imgFile As System.Drawing.Image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream)
                If imgFile.PhysicalDimension.Width > 128 Or imgFile.PhysicalDimension.Height > 128 Then
                    function_java = function_java + "invalidFileSize();"
                Else
                    FileUpload1.SaveAs(folderPath + dcRow.id_super.ToString + extension)
                    result_update = query.update_super_userLogo(dcRow.id_super, color_body.Text, color.Text, color_primary.Text, color_links.Text, dcRow.id_super.ToString + extension, slide.Text)
                End If
            Else
                function_java = function_java + "invalidFileSize();"
            End If
            'Save the File to the Directory (Folder).

        Else
            If FileUpload1.FileName <> "" Then
                function_java = function_java + "invalidFileFormat();"
            Else
                result_update = query.update_super_userLogo(dcRow.id_super, color_body.Text, color.Text, color_primary.Text, color_links.Text, dcRow.logo, slide.Text)
            End If
        End If
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