Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Server

Public Class queryDB
    Public Shared con As New SqlConnection
    Public Shared cmd As New SqlCommand

    Public Shared Sub connectToDb(ByVal local As Boolean)
        Dim connectionString As String = ""
        If con.State = ConnectionState.Open Then
            Exit Sub
        End If

        If local Then
            con.ConnectionString = "Data Source=192.168.4.200;Initial Catalog=max_5;Integrated Security=True"
        Else
            con.ConnectionString = "Data Source=localhost;Database=max_5;User ID=max55;Password=max55"
        End If


        'con.ConnectionString = "Data Source=localhost;Database=max_5;User ID=max55;Password=max55"

        Try
            'Using cmd As New SqlConnection()
            '    Using cmd As New SqlCommand
            '        With cmd
            '            .Connection = con
            '            .Connection.Open()
            '        End With
            '    End Using
            'End Using
            con.Open()
            cmd.Connection = con

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function selectQuery(ByVal querySTR As String) As String
        Dim resultQuery As Integer = 0
        If querySTR = "" Then
            Return True
        End If
        cmd.CommandText = querySTR
        Dim sqlDataRead As SqlDataReader = cmd.ExecuteReader()
        While sqlDataRead.Read
            Return sqlDataRead(0)
        End While
        Return ""
    End Function
    Public Shared Function selectQueryMainLDLOG(ByVal querySTR As String, ByRef listLogRiempire As Dictionary(Of String, String)) As String
        Dim resultQuery As Integer = 0
        Dim indiceData As Integer = 0
        Dim indiceType As Integer = 0

        'Dim valueMeseTemp As Single = 0
        'Dim valueAnnoTemp As Single = 0

        Dim baseDate As DateTime = New Date(1970, 1, 1)
        Dim listaOggetti As List(Of tipoOggetti) = New List(Of tipoOggetti)
        If querySTR = "" Then
            Return True
        End If
        cmd.CommandText = querySTR
        Dim sqlDataRead As SqlDataReader = cmd.ExecuteReader()
        'While sqlDataRead.Read
        '    ReadSingleRow(CType(sqlDataRead, IDataRecord))
        'End While
        ' Do While sqlDataRead.HasRows
        'Dim dateTimeReading As DateTime
        ' Dim dateTimeReadingPrecedent As DateTime
        For i = 0 To sqlDataRead.FieldCount - 1
            ' cerco la data
            If (sqlDataRead.GetName(i) = "data") Then
                indiceData = i
            End If
            Dim oggetto As tipoOggetti = New tipoOggetti()
            oggetto.indice = i
            listaOggetti.Add(oggetto)

            'If (sqlDataRead.GetName(i) = "data") Then
            '    indiceData = i
            '    'Exit For
            'End If

        Next

        Do While sqlDataRead.Read()


            For i = 0 To sqlDataRead.FieldCount - 1
                'And (sqlDataRead.GetName(i) <> "typeLog") 
                If (sqlDataRead.GetName(i) <> "data") Then
                    listaOggetti.Item(i).dateTimeReading = sqlDataRead(indiceData)

                    'listaOggetti.Item(i).dateTimeReading
                    'dataDifferenza.
                    'dataDifferenza.Minute = 0


                    If IsDBNull(sqlDataRead(i)) Then
                        Dim dataDifferenzaDay As New Date(listaOggetti.Item(i).dateTimeReading.Year, listaOggetti.Item(i).dateTimeReading.Month, listaOggetti.Item(i).dateTimeReading.Day, 0, 0, 0)
                        Dim diffDay As TimeSpan = dataDifferenzaDay - baseDate
                        listLogRiempire(sqlDataRead.GetName(i) + "day") = listLogRiempire(sqlDataRead.GetName(i) + "day") + listaOggetti.Item(i).virgolaDay + "{""data"":""" + diffDay.TotalMilliseconds.ToString() + """,""valoreP"":""0""}"

                        Dim dataDifferenzaMonth As New Date(listaOggetti.Item(i).dateTimeReading.Year, listaOggetti.Item(i).dateTimeReading.Month, 1, 0, 0, 0)
                        Dim diffMonth As TimeSpan = dataDifferenzaMonth - baseDate
                        listLogRiempire(sqlDataRead.GetName(i) + "month") = listLogRiempire(sqlDataRead.GetName(i) + "month") + listaOggetti.Item(i).virgolaDay + "{""data"":""" + diffMonth.TotalMilliseconds.ToString() + """,""valoreP"":""0""}"

                        Dim dataDifferenzaYear As New Date(listaOggetti.Item(i).dateTimeReading.Year, 1, 1, 0, 0, 0)
                        Dim diffYear As TimeSpan = dataDifferenzaYear - baseDate
                        listLogRiempire(sqlDataRead.GetName(i) + "year") = listLogRiempire(sqlDataRead.GetName(i) + "year") + listaOggetti.Item(i).virgolaDay + "{""data"":""" + diffYear.TotalMilliseconds.ToString() + """,""valoreP"":""0""}"
                    Else
                        If listaOggetti.Item(i).dateTimeReading.Day <> listaOggetti.Item(i).dateTimeReadingPrecedent.Day Then
                            If listaOggetti.Item(i).dateTimeReading.Month <> listaOggetti.Item(i).dateTimeReadingPrecedent.Month And (listaOggetti.Item(i).firstdata) Then
                                Dim dataDifferenzaMonth As New Date(listaOggetti.Item(i).dateTimeReadingPrecedent.Year, listaOggetti.Item(i).dateTimeReadingPrecedent.Month, 1, 0, 0, 0)
                                Dim diffMonth As TimeSpan = dataDifferenzaMonth - baseDate
                                listLogRiempire(sqlDataRead.GetName(i) + "month") = listLogRiempire(sqlDataRead.GetName(i) + "month") + listaOggetti.Item(i).virgolaMonth + "{""data"":""" + diffMonth.TotalMilliseconds.ToString() + """,""valoreP"":""" + (listaOggetti.Item(i).valueMeseTemp.ToString).Replace(",", ".") + """}"
                                listaOggetti.Item(i).virgolaMonth = ","
                                listaOggetti.Item(i).valueMeseTemp = 0
                            End If
                            listaOggetti.Item(i).valueMeseTemp = listaOggetti.Item(i).valueMeseTemp + sqlDataRead(i)
                            If listaOggetti.Item(i).dateTimeReading.Year <> listaOggetti.Item(i).dateTimeReadingPrecedent.Year And (listaOggetti.Item(i).firstdata) Then
                                Dim dataDifferenzaYear As New Date(listaOggetti.Item(i).dateTimeReadingPrecedent.Year, 1, 1, 0, 0, 0)
                                Dim diffYear As TimeSpan = dataDifferenzaYear - baseDate
                                listLogRiempire(sqlDataRead.GetName(i) + "year") = listLogRiempire(sqlDataRead.GetName(i) + "year") + listaOggetti.Item(i).virgolaYear + "{""data"":""" + diffYear.TotalMilliseconds.ToString() + """,""valoreP"":""" + (listaOggetti.Item(i).valueAnnoTemp.ToString).Replace(",", ".") + """}"
                                listaOggetti.Item(i).valueAnnoTemp = 0
                                listaOggetti.Item(i).virgolaYear = ","
                            End If
                            listaOggetti.Item(i).valueAnnoTemp = listaOggetti.Item(i).valueAnnoTemp + sqlDataRead(i)

                            Dim dataDifferenzaDay As New Date(listaOggetti.Item(i).dateTimeReading.Year, listaOggetti.Item(i).dateTimeReading.Month, listaOggetti.Item(i).dateTimeReading.Day, 0, 0, 0)
                            Dim diffDay As TimeSpan = dataDifferenzaDay - baseDate

                            listLogRiempire(sqlDataRead.GetName(i) + "day") = listLogRiempire(sqlDataRead.GetName(i) + "day") + listaOggetti.Item(i).virgolaDay + "{""data"":""" + diffDay.TotalMilliseconds.ToString() + """,""valoreP"":""" + (sqlDataRead(i).ToString).Replace(",", ".") + """}"
                            listaOggetti.Item(i).virgolaDay = ","
                        End If


                    End If
                    listaOggetti.Item(i).firstdata = True
                    listaOggetti.Item(i).dateTimeReadingPrecedent = listaOggetti.Item(i).dateTimeReading
                End If
            Next
            'For i = 0 To sqlDataRead.FieldCount - 1
            '    listaOggetti.Item(i).virgola = ","
            'Next

        Loop
        For i = 0 To sqlDataRead.FieldCount - 1
            ' Dim diff As TimeSpan = listaOggetti.Item(i).dateTimeReading - baseDate
            If (listaOggetti.Item(i).valueAnnoTemp <> 0) Then
                Dim dataDifferenzaYear As New Date(listaOggetti.Item(i).dateTimeReading.Year, 1, 1, 0, 0, 0)
                Dim diffYear As TimeSpan = dataDifferenzaYear - baseDate

                listLogRiempire(sqlDataRead.GetName(i) + "year") = listLogRiempire(sqlDataRead.GetName(i) + "year") + listaOggetti.Item(i).virgolaYear + "{""data"":""" + diffYear.TotalMilliseconds.ToString() + """,""valoreP"":""" + (listaOggetti.Item(i).valueAnnoTemp.ToString).Replace(",", ".") + """}"
            End If
            If (listaOggetti.Item(i).valueMeseTemp <> 0) Then
                Dim dataDifferenzaMonth As New Date(listaOggetti.Item(i).dateTimeReading.Year, listaOggetti.Item(i).dateTimeReading.Month, 1, 0, 0, 0)
                Dim diffMonth As TimeSpan = dataDifferenzaMonth - baseDate

                listLogRiempire(sqlDataRead.GetName(i) + "month") = listLogRiempire(sqlDataRead.GetName(i) + "month") + listaOggetti.Item(i).virgolaMonth + "{""data"":""" + diffMonth.TotalMilliseconds.ToString() + """,""valoreP"":""" + (listaOggetti.Item(i).valueMeseTemp.ToString).Replace(",", ".") + """}"
            End If

        Next
        '    sqlDataRead.NextResult()
        'Loop
        Return ""
    End Function

    Public Shared Function selectQueryMain(ByVal querySTR As String, ByRef listLogRiempire As Dictionary(Of String, String)) As String
        Dim resultQuery As Integer = 0
        Dim indiceData As Integer = 0
        Dim indiceType As Integer = 0
        Dim virgola As String = ""
        Dim baseDate As DateTime = New DateTime(1970, 1, 1)
        If querySTR = "" Then
            Return True
        End If
        cmd.CommandText = querySTR
        Dim sqlDataRead As SqlDataReader = cmd.ExecuteReader()
        'While sqlDataRead.Read
        '    ReadSingleRow(CType(sqlDataRead, IDataRecord))
        'End While
        ' Do While sqlDataRead.HasRows

        Do While sqlDataRead.Read()

            For i = 0 To sqlDataRead.FieldCount - 1
                ' cerco la data
                If (sqlDataRead.GetName(i) = "data") Then
                    indiceData = i
                    Exit For
                End If
                'If (sqlDataRead.GetName(i) = "data") Then
                '    indiceData = i
                '    'Exit For
                'End If

            Next
            For i = 0 To sqlDataRead.FieldCount - 1
                'And (sqlDataRead.GetName(i) <> "typeLog") 
                If (sqlDataRead.GetName(i) <> "data") Then
                    Dim dateTimeReading As DateTime = sqlDataRead(indiceData)
                    Dim diff As TimeSpan = dateTimeReading - baseDate
                    If IsDBNull(sqlDataRead(i)) Then
                        listLogRiempire(sqlDataRead.GetName(i)) = listLogRiempire(sqlDataRead.GetName(i)) + virgola + "{""data"":""" + diff.TotalMilliseconds.ToString() + """,""valoreP"":""0""}"
                    Else
                        If (sqlDataRead.GetName(i).IndexOf("tempR") > 0) Then ' cado della temperatura devo dividere per 100
                            listLogRiempire(sqlDataRead.GetName(i)) = listLogRiempire(sqlDataRead.GetName(i)) + virgola + "{""data"":""" + diff.TotalMilliseconds.ToString() + """,""valoreP"":""" + ((sqlDataRead(i) / 100).ToString).Replace(",", ".") + """}"
                        Else
                            listLogRiempire(sqlDataRead.GetName(i)) = listLogRiempire(sqlDataRead.GetName(i)) + virgola + "{""data"":""" + diff.TotalMilliseconds.ToString() + """,""valoreP"":""" + (sqlDataRead(i).ToString).Replace(",", ".") + """}"
                        End If

                    End If


                End If

            Next
            virgola = ","
        Loop
        '    sqlDataRead.NextResult()
        'Loop
        Return ""
    End Function

    Public Shared Function sendQuery(ByVal querySTR As String) As Boolean
        Dim resultQuery As Integer = 0
        If querySTR = "" Then
            Return True
        End If
        cmd.CommandText = querySTR
        resultQuery = cmd.ExecuteNonQuery()
        If resultQuery > 0 Then
            Return True
        Else
            Return False

        End If
    End Function


    Public Shared Sub disConnectToDb()

        con.Close()
        con.Dispose()
    End Sub
    Public Class tipoOggetti
        Public dateTimeReading As Date
        Public virgolaDay As String = ""
        Public virgolaMonth As String = ""
        Public virgolaYear As String = ""
        Public firstdata As Boolean = False
        Public dateTimeReadingPrecedent As Date
        Public valueMeseTemp As Single = 0
        Public valueAnnoTemp As Single = 0
        Public indice As Integer = 0
    End Class
End Class
