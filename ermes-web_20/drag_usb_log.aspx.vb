Imports System.IO
Imports System.Threading

Public Class drag_usb_log
    Inherits lingua

    Protected File1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim function_java As String = ""
        Dim file_impianto As String
        Dim numero_file As Integer = 0
        Dim entrato As Boolean = False

        file_impianto = ""
        numero_file = 0
        entrato = False

        file_impianto = Page.Request("file")
        If file_impianto = "1" Then
            Dim stringa As String
            stringa = Request.FilePath
            Dim savedFileName As String = Server.MapPath(".")
            For Each s In Request.Files
                Dim file_response As HttpPostedFile = Request.Files(s)
                Dim fileName As String = Request.Headers("X-File-Name")
                Dim fileExtension As String = Path.GetExtension(fileName)
               

                savedFileName = savedFileName + "\FileCaricati\" + Session("mid_super").ToString + "_temp\" + fileName + "" + ".txt"
                If fileExtension = ".txt" Or fileExtension = ".TXT" Then
                    file_response.SaveAs(savedFileName)
                    entrato = True
                    numero_file = numero_file + 1
                End If
            Next
'Literal1.Text = crea_codice_log()
            ' Response.Redirect("log_usb_plant.aspx?numero_file=" + numero_file.ToString)

        Else
            Dim savedFileName As String = Server.MapPath(".")
            savedFileName = savedFileName + "\FileCaricati\"
            Dim files() As String
            If Not Directory.Exists(savedFileName + Session("mid_super").ToString + "_temp") Then
                Directory.CreateDirectory(savedFileName + Session("mid_super").ToString + "_temp")
            Else
                files = Directory.GetFileSystemEntries(savedFileName + Session("mid_super").ToString + "_temp")
                For Each element As String In files
                    If (Not Directory.Exists(element)) Then
                        File.Delete(Path.Combine(savedFileName + Session("mid_super").ToString + "_temp", Path.GetFileName(element)))
                    End If
                Next
            End If
            Dim java_script_impianti As java_script = New java_script

            function_java = function_java + "remove_form();"
            java_script_impianti.call_function_javascript_onload(Page, function_java)
            Literal1.Text = crea_codice_drag()

        End If


    End Sub

    Public Function crea_codice_drag() As String
        Dim intestazione As String = ""
        intestazione = "<h3 class='heading-mosaic'>Log USB Manager</h3>"
        intestazione = intestazione + "<div class='innerLR'>"
        intestazione = intestazione + "<div class='widget'>"
        intestazione = intestazione + "<div class='widget-head'>"
        intestazione = intestazione + "<h4 class='heading glyphicons file_import'><i></i>Log Uploader</h4>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class='widget-body'>"
        intestazione = intestazione + "<div id='dropzone'>"
        intestazione = intestazione + "<form action='drag_usb_log.aspx?file=1' class='dropzone clickable' id='demo-upload'>"
        intestazione = intestazione + "<div class='default message'><span>Drop files here to upload</span></div>"
        intestazione = intestazione + "</form>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "<div class='separator bottom'></div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        Return intestazione
    End Function
    Public Function crea_codice_log() As String
        Dim intestazione As String = ""
        intestazione = "<h3 class='heading-mosaic'>Impianti</h3>"
        intestazione = intestazione + "<div class='innerLR'>"
        intestazione = intestazione + "<h5 > Seleziona Impianto da Graficare.</h5>"
        intestazione = intestazione + "<div class='accordion' id='accordion2'>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
    End Function
    Private Sub drag_usb_log_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Response.Redirect("log_usb_plant.aspx?numero_file=" + numero_file.ToString)
        'If file_impianto = "1" And entrato Then
        '    Thread.Sleep(2000)
        '    Response.Redirect("log_usb_plant.aspx?numero_file=" + numero_file.ToString)
        '    Exit Sub
        'End If
    End Sub
End Class