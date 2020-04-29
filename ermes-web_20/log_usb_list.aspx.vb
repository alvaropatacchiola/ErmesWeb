Imports System.IO
Public Class log_usb_list
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim savedFileName_final As String = Server.MapPath(".")
        savedFileName_final = savedFileName_final + "\FileCaricati\"
        Dim files_final() As String
        Dim intestazione As String = ""
        files_final = Directory.GetFileSystemEntries(savedFileName_final + Session("mid_super").ToString)

        Dim lista_file As List(Of String) = New List(Of String)
        Dim lista_file_link As List(Of String) = New List(Of String)

        For Each element As String In files_final
            If InStr(element, "_config") <> 0 Then
            Else
                Dim elemento() As String = Path.GetFileName(element).Split("_")
                Dim indice As Integer
                Dim presente As Boolean = False
                Dim indice_lista As Integer = 0
                For Each stringa As String In lista_file
                    If InStr(stringa, elemento(1)) <> 0 Then
                        presente = True
                        stringa = stringa + "," + elemento(0) + " ID" + elemento(2)
                        lista_file(indice_lista) = stringa

                        Exit For
                    End If
                    indice_lista = indice_lista + 1
                Next
                If presente = False Then
                    lista_file.Add(elemento(1) + ":" + elemento(0) + " ID" + elemento(2))
                End If
            End If
        Next

        Dim primo As Boolean = True
        For Each element As String In lista_file
            Dim elemento() As String = element.Split(":")
            intestazione = "<div class=""widget"">"
            intestazione = intestazione + "<div class=""widget-head"">"
            intestazione = intestazione + "<h4 class=""heading glyphicons show_thumbnails_with_lines""><i></i>" + elemento(0) + "</h4>"
            intestazione = intestazione + "</div>"

            'If primo Then
            '    intestazione = intestazione + "<div id=""collapse" + elemento(0) + """ class=""accordion-body collapse in"">"
            '    Dim elemento_sub() As String = elemento(1).Split(",")
            '    Dim i As Integer = 0
            '    For i = 0 To elemento_sub.Length - 1
            '        intestazione = intestazione + "<div class=""accordion-inner"">"
            '        intestazione = intestazione + "<a href=""usb_log_graph.aspx?codice=" + Replace(elemento_sub(i), " ID", "_" + elemento(0) + "_") + """ > "
            '        intestazione = intestazione + Replace(elemento_sub(i), ".txt", "")
            '        intestazione = intestazione + "</a>"
            '        intestazione = intestazione + "</div>"
            '    Next
            '    intestazione = intestazione + "</div>"
            'Else
            intestazione = intestazione + "<div class=""widget-body list"">"
            intestazione = intestazione + "<ul>"
            Dim i As Integer = 0
            Dim elemento_sub() As String = elemento(1).Split(",")

            For i = 0 To elemento_sub.Length - 1
                intestazione = intestazione + "<li>"
                intestazione = intestazione + "<span>" + "<a href=""usb_log_graph.aspx?codice=" + Replace(elemento_sub(i), " ID", "_" + elemento(0) + "_") + """ >" + Replace(elemento_sub(i), ".txt", "") + "</a></span>"
                intestazione = intestazione + "</li>"
                'intestazione = intestazione + "<div class=""accordion-inner"">"
                'intestazione = intestazione + "<a href=""usb_log_graph.aspx?codice=" + Replace(elemento_sub(i), " ID", "_" + elemento(0) + "_") + """ > "
                'intestazione = intestazione + Replace(elemento_sub(i), ".txt", "")
                'intestazione = intestazione + "</a>"
                'intestazione = intestazione + "</div>"
            Next

            intestazione = intestazione + "</ul>"

            intestazione = intestazione + "</div>"
            'End If
            intestazione = intestazione + "</div>"
            primo = False
            Literal2.Text = Literal2.Text + intestazione

        Next


    End Sub

End Class