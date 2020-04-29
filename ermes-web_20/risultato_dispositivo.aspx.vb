Public Class risultato_dispositivo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim codice_impianto As String = ""
        Dim query As query = New query
        Dim setpoint As read_setpoint = New read_setpoint
        Dim tabella_strumento As String
        Dim intestazione As String = ""
        Dim intestazione1 As String = ""
        Dim primo_valore As Boolean = True
        Dim contatore_impianti As Integer = 0

        Dim tipo_strumento As String = ""
        Dim id485_strumento As String = ""
        Dim value1() As String
        Dim value2() As String
        Dim value3() As String
        Dim value4() As String
        Dim time_connected As Long
        Dim check_connected As Boolean = False
        Dim fattore_divisione_temp As Integer = 0
        Dim fattore_divisione_combinato As Integer = 1
        Dim valore_canale_temp As Single = 0
        Dim scala_temp As Integer = 0

        Dim label_canale_temp As String = ""
        codice_impianto = Page.Request("codice")
        'tabella_strumento = query.get_strumenti_codice(codice_impianto)
        tabella_strumento = setpoint.read_setpoint(codice_impianto)
        Dim split_string() As String = tabella_strumento.Split("!")
        intestazione = "<div class=""innerAll"">"
        intestazione = intestazione + "<div class=""box-generic"" > "
        intestazione = intestazione + "<div class=""tabsbar"">"
        intestazione = intestazione + "<ul>"
        intestazione1 = "<div class=""tab-content"">"
        'For Each dc In split_string
        If split_string.Length > 10 Then
            Try
                ' check_connected = main_function.check_is_connected_produzione(split_string(0), time_connected)
                tipo_strumento = split_string(3)
                id485_strumento = split_string(2)
                value1 = main_function.get_split_str(split_string(5))
                value2 = main_function.get_split_str(split_string(6))
                value3 = main_function.get_split_str(split_string(7))
                value4 = main_function.get_split_str(split_string(8))
            Catch ex As Exception

            End Try

            If primo_valore Then
                intestazione = intestazione + "<li class=""active""><a href=""#tab" + Format(contatore_impianti, "00") + "-3"" data-toggle=""tab"">" + tipo_strumento + " " + id485_strumento + "</a></li>"
                intestazione1 = intestazione1 + "<div class=""tab-pane active"" id=""tab" + Format(contatore_impianti, "00") + "-3"" > "
            Else
                intestazione = intestazione + "<li ><a href=""#tab" + Format(contatore_impianti, "00") + "-3"" data-toggle=""tab""> " + tipo_strumento + " " + id485_strumento + "</a></li>"
                intestazione1 = intestazione1 + "<div class=""tab-pane"" id=""tab" + Format(contatore_impianti, "00") + "-3"" > "
            End If
            primo_valore = False
            contatore_impianti = contatore_impianti + 1

            intestazione1 = intestazione1 + "<div class=""row-fluid""><p>Strumento:<b style=""color:red;"">" + split_string(3) + "</b>      Id 485:<b style=""color:red;"">" + split_string(2) + "</b>"
            ' If check_connected Then
            intestazione1 = intestazione1 + " <b style=""color:red;""></b>  Ultimo aggiornamento:<b style=""color:red;"">" + split_string(0) + "</b>"
            'Else
            '   intestazione1 = intestazione1 + " <b style=""color:red;"">" + tabella_strumento + "</b>"
            'End If
            intestazione1 = intestazione1 + " Versione:<b style=""color:red;"">" + main_function.get_version(split_string(4)) + "</b> </div>"

            intestazione1 = intestazione1 + "<div class=""row-fluid"">"
            ' intestazione1 = intestazione1 + "<div class=""span4"">"
            intestazione1 = intestazione1 + "<div >"
            intestazione1 = intestazione1 + "<div class=""widget"">"
            intestazione1 = intestazione1 + "<div class=""widget-body"">"
            intestazione1 = intestazione1 + "<table class=""table table-bordered table-condensed table-striped table-primary table-vertical-center checkboxs"">"
            intestazione1 = intestazione1 + "<tbody>"
            Select Case tipo_strumento
                Case "max5" 'Replace(nome_impanto, " ", "£") 
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try

                        If value1.Length > 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 1 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                        End If

                        For i = 1 To 5
                            label_canale_temp = main_function_config.get_tipo_strumento_max5(value1(i - 1), value4(0), fattore_divisione_temp, scala_temp, , , fattore_divisione_combinato)
                            If label_canale_temp <> "" Then
                                valore_canale_temp = Val(Mid(value2(i - 1), 3, 4)) / fattore_divisione_temp
                                intestazione1 = intestazione1 + "<td class=""center""><h4><b>" + label_canale_temp + ":" + valore_canale_temp.ToString + "</b></h4></td>"
                            End If

                        Next
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                    End Try

                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(6), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 2 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 2 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 2 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(7), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 3 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 3 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 3 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(8), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 4 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 4 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 4 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(9), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 5 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 5 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 5 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(10), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 6 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 6 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 6 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(11), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 7 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 7 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 7 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(12), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 8 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 8 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 8 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(13), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 9 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 9 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 9 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(14), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 10 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 10 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 10 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(15), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 11 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 11 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 11 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(16), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 12 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 12 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 12 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(17), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 13 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 13 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 13 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(18), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 14 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 14 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 14 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(19), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 15 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 15 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 15 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(20), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 16 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 16 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 16 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(21), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 17 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 17 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 17 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                Case "Tower"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(5), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 1 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(6), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 2 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 2 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 2 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(7), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 3 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 3 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 3 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(8), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 4 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 4 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 4 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(9), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 5 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 5 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 5 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(10), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 6 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 6 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 6 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(11), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 7 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 7 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 7 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(12), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 8 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 8 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 8 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(13), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 9 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 9 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 9 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(14), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 10 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 10 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 10 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(15), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 11 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 11 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 11 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                Case "LDS", "LD", "LD4", "LDDT", "LTB", "WD", "WH", "LTA", "LTD", "LTU"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Dim numero_canali As Integer = 0
                    If tipo_strumento = "LDS" Then
                        numero_canali = 1
                    End If
                    If tipo_strumento = "LD4" Then
                        numero_canali = 4
                    End If

                    If tipo_strumento = "LDDT" Then
                        numero_canali = 2
                    End If

                    If tipo_strumento = "LD" Then
                        If Mid(value1(3), 3, 3) <> "306" Then ' terzo canale esistente
                            numero_canali = 3
                        Else
                            numero_canali = 2
                        End If
                    End If
                    If tipo_strumento = "WD" Then
                        numero_canali = 2
                    End If
                    If tipo_strumento = "WH" Then
                        numero_canali = 2
                    End If

                    If tipo_strumento = "LTB" Then
                        numero_canali = 2
                    End If

                    If tipo_strumento = "LTA" Then
                        numero_canali = 2
                    End If

                    If tipo_strumento = "LTD" Then
                        numero_canali = 2
                    End If

                    If tipo_strumento = "LTU" Then
                        numero_canali = 2
                    End If

                    Try

                        If value1.Length > 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 1 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                        End If

                        For i = 1 To numero_canali 'lds solo un canale
                            label_canale_temp = main_function_config.get_tipo_strumento_ld_lds_wd(Mid(value4(i), 1, 2), fattore_divisione_temp)
                            If label_canale_temp <> "" Then
                                valore_canale_temp = Val(Mid(value2(i), 1, 4)) / fattore_divisione_temp
                                intestazione1 = intestazione1 + "<td class=""center""><h4><b>" + label_canale_temp + ":" + valore_canale_temp.ToString + "</b></h4></td>"
                            End If
                        Next

                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                    End Try

                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(5), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 1 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 1 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(6), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 2 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 2 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 2 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(7), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 3 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 3 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 3 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(8), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 4 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 4 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 4 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(9), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 5 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 5 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 5 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(10), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 6 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 6 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 6 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(11), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 7 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 7 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 7 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(12), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 8 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 8 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 8 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(13), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 9 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 9 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 9 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(14), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 10 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 10 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 10 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(15), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 11 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 11 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 11 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    If tipo_strumento <> "LDS" Then
                        intestazione1 = intestazione1 + "<tr class=""selectable"">"
                        Try
                            If InStr(split_string(16), "end") <> 0 Then
                                intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 12 OK</h4></td>"
                            Else
                                intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 12 Non Completa</h4></td>"
                            End If
                        Catch ex As Exception
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 12 Non Completa</h4></td>"
                        End Try
                        intestazione1 = intestazione1 + "</tr>"
                    End If
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(17), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 13 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 13 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 13 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(18), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 14 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 14 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 14 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(19), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 15 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 15 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 15 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"
                    intestazione1 = intestazione1 + "<tr class=""selectable"">"
                    Try
                        If InStr(split_string(20), "end") <> 0 Then
                            intestazione1 = intestazione1 + "<td style=""background-color: green;""><h4  style=""color:white;""> 16 OK</h4></td>"
                        Else
                            intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 16 Non Completa</h4></td>"
                        End If
                    Catch ex As Exception
                        intestazione1 = intestazione1 + "<td style=""background-color: red;""><h4 style=""color:white;""> 16 Non Completa</h4></td>"
                    End Try
                    intestazione1 = intestazione1 + "</tr>"

            End Select
            intestazione1 = intestazione1 + "</tbody>"
            intestazione1 = intestazione1 + "</table>"
            intestazione1 = intestazione1 + "</div>"
            intestazione1 = intestazione1 + "</div>"
            intestazione1 = intestazione1 + "</div>"
            intestazione1 = intestazione1 + "</div>"
            intestazione1 = intestazione1 + "</div>"

        End If
        intestazione1 = intestazione1 + "</div>"

        intestazione = intestazione + "</ul>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        intestazione = intestazione + "</div>"
        Label2.Text = intestazione
        Label1.Text = intestazione1

        '<div class="tab-content">

        '    <div class="tab-pane active" id="tab1-3">
        '    <div><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas convallis porta purus, pulvinar mattis nulla tempus ut. Curabitur quis dui orci. Ut nisi dolor, dignissim a aliquet quis, vulputate id dui. Proin ultrices ultrices ligula, dictum varius turpis faucibus non. Curabitur faucibus ultrices nunc, nec aliquet leo tempor cursus.</p></div>
        '   	<div class="row-fluid">

        '  <div class="span4">

        '       	 	<div class="widget">

        '                <div class="widget-body">

        '     <table class="table table-bordered table-condensed table-striped table-primary table-vertical-center checkboxs">

        '        				<tbody>
        '                      <tr class="selectable">
        '						        <td class="center"><h4>pH</h4></td>
        '              <td class="center"><h4>07.16</h4></td>
        '             </tr>   
        '	                    </tbody>

        '           </table>

        '                </div>

        '            </div>

        '        </div>

        '    </div>

        '</div>
    End Sub

End Class