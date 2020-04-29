Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Web

Public Class centurioReal
    Inherits lingua
    'metodo per leggere in tempo reale i valori esclusi i setpoint
    <System.Web.Services.WebMethod()>
    Public Shared Function getRealTime(ByVal serialNumber As String) As String
        Dim resultPipe As String = ""
        serialNumber = Replace(serialNumber, """", "")
        Dim pipeClient As New centurioRealTime
        Dim stringJson As String = "{"
        resultPipe = pipeClient.Main(serialNumber, "")
        If resultPipe <> "null" And resultPipe <> "" Then
            Dim pipeSplit() As String = resultPipe.Split("$")

            stringJson = stringJson + """errore"":""ok"",""variable"":["
            '{""chiave"":""Empty"", ""valore"":}"
            Dim virgola As String = ""
            For Each pipeValue In pipeSplit
                If pipeValue.IndexOf(":") > 0 Then
                    Dim pipeValueSplit() As String = pipeValue.Split(":")
                    If pipeValueSplit(0).IndexOf(">") < 0 Then
                        stringJson = stringJson + virgola + "{""chiave"":""" + pipeValueSplit(0) + """, ""valore"":""" + pipeValueSplit(1) + """}"
                        virgola = ","
                    End If
                End If
            Next
            stringJson = stringJson + "]}"
        Else
            stringJson = stringJson + """errore"":""invalidSerial""}"
        End If
        Return stringJson

    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function getAllData(ByVal serialNumber As String) As String
        Dim resultPipe As String = ""
        Dim stringChange As String = ""
        serialNumber = Replace(serialNumber, """", "")
        Dim pipeClient As New centurioRealTime
        Dim stringJson As String = "{"
        resultPipe = pipeClient.Main(serialNumber, "")
        If resultPipe <> "null" And resultPipe <> "" Then
            Dim pipeSplit() As String = resultPipe.Split("$")

            stringJson = stringJson + """errore"":""ok"",changejs""variable"":["
            '{""chiave"":""Empty"", ""valore"":}"
            Dim virgola As String = ""
            For Each pipeValue In pipeSplit
                If pipeValue.IndexOf(":") > 0 Then
                    Dim pipeValueSplit() As String = pipeValue.Split(":")
                    'If pipeValueSplit(0).IndexOf(">") < 0 Then
                    stringJson = stringJson + virgola + "{""chiave"":""" + pipeValueSplit(0).Replace(">", "_") + """, ""valore"":""" + pipeValueSplit(1) + """}"
                    If (pipeValueSplit(0) = "change") Then
                        stringChange = """change"":""" + pipeValueSplit(1) + ""","
                    End If
                    virgola = ","
                    'End If
                End If
            Next
            stringJson = stringJson + "]}"
        Else
            Dim query As New query
            Dim resultPipeData As String = ""

            resultPipeData = getConfigFromFile(serialNumber)
            If (resultPipeData = "") Then
                Dim strinxXML As String = query.getConfigGlobal(1)
                resultPipeData = mainFunctionCenturio.getFileInfoXML(serialNumber, strinxXML, 4)
            End If
            If resultPipeData <> "" Then
                stringJson = stringJson + """errore"":""disconnected"", ""change"":""0"" ,""variable"":["
                stringJson = stringJson + resultPipeData + "]}"
            Else
                stringJson = stringJson + """errore"":""invalidSerial""}"
                End If



            End If
            stringJson = stringJson.Replace("changejs", stringChange)
        Return stringJson
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function saveSetpoint(ByVal serialNumber As String, ByVal setpoint As String) As String
        serialNumber = Replace(serialNumber, """", "")
        setpoint = Replace(setpoint, """", "")
        Dim resultPipe As String = ""
        Dim indiceCount As Integer = 0
        Dim stringJson As String = "{"
        Dim pipeClient As New centurioRealTime

        resultPipe = pipeClient.Main(serialNumber, "writeSetpoint^$" + setpoint)
        If (resultPipe = "ok") Then
            For indiceCount = 0 To 80
                Thread.Sleep(400)
                resultPipe = pipeClient.Main(serialNumber, "waitSetpoint")
                If Val(resultPipe) > 0 Then
                    stringJson = stringJson + """errore"":""ok"",""count"":""" + resultPipe + """"
                    Exit For
                End If
            Next
            If Val(resultPipe) <= 0 Then
                stringJson = stringJson + """errore"":""error"",""count"":""0"""
            End If
        Else
            stringJson = stringJson + """errore"":""error"",""count"":""0"""
        End If



        stringJson = stringJson + "}"
        Return stringJson
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function saveSetpointAction(ByVal serialNumber As String, ByVal setpoint As String) As String
        serialNumber = Replace(serialNumber, """", "")
        setpoint = Replace(setpoint, """", "")
        Dim resultPipe As String = ""
        Dim indiceCount As Integer = 0
        Dim stringJson As String = "{"
        Dim pipeClient As New centurioRealTime

        resultPipe = pipeClient.Main(serialNumber, "writeSetpointAction^$" + setpoint)
        If (resultPipe = "ok") Then
            For indiceCount = 0 To 80
                Thread.Sleep(400)
                resultPipe = pipeClient.Main(serialNumber, "waitSetpoint")
                If Val(resultPipe) > 0 Then
                    stringJson = stringJson + """errore"":""ok"",""count"":""" + resultPipe + """"
                    Exit For
                End If
            Next
            If Val(resultPipe) <= 0 Then
                stringJson = stringJson + """errore"":""error"",""count"":""0"""
            End If
        Else
            stringJson = stringJson + """errore"":""error"",""count"":""0"""
        End If



        stringJson = stringJson + "}"
        Return stringJson
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function readLog(ByVal serialNumber As String, ByVal dateFrom As String, ByVal dateTo As String) As String
        serialNumber = Replace(serialNumber, """", "")
        dateFrom = Replace(dateFrom, """", "")
        dateTo = Replace(dateTo, """", "")
        Dim stringJson As String = "{"
        Dim queryDB As New queryDB
        Dim listLog As Dictionary(Of String, String) = New Dictionary(Of String, String)

        'Dim data_from_temp As Date
        'Dim data_to_temp As Date
        'Dim data_to As Date
        'Dim data_from As Date

        'data_from_temp = Date.Parse(dateFrom)
        'data_to_temp = Date.Parse(dateTo)
        'data_from = New Date(data_from_temp.Year, data_from_temp.Month, data_from_temp.Day + 1, 0, 0, 0)
        'data_to = New Date(data_to_temp.Year, data_to_temp.Month, data_to_temp.Day, 23, 59, 0)



        queryDB.connectToDb(False) 'da inserire nella versione server
        'queryDB.connectToDb(True)

        Dim restrictions = {Nothing, Nothing, "M" + serialNumber, Nothing}

        Dim dbTbl As DataTable = queryDB.con.GetSchema("Tables", restrictions)


        If dbTbl.Rows.Count = 0 Then
            '    '' tabella inesistente
            stringJson = stringJson + """errore"":""errore"""
        Else
            '    'Table exists
            dbTbl = queryDB.con.GetSchema("Columns", restrictions)
            For Each myRow In dbTbl.Rows
                Dim chiave As String = ""
                If (myRow.Item("COLUMN_NAME") <> "data") Then
                    listLog.Add(myRow.Item("COLUMN_NAME"), "")
                End If
            Next
            'stringJson = "ciccio"
            'Return dateFrom + "," + dateTo

            Dim version As String = queryDB.selectQueryMain("select DISTINCT  * from M" + serialNumber + " where  (data BETWEEN '" + dateFrom + "'  AND '" + dateTo + "') order by data DESC", listLog)



            stringJson = stringJson + """errore"":""ok"""

            For Each chiave In listLog.Keys
                stringJson = stringJson + ",""" + chiave + """:[" + listLog.Item(chiave) + "]"
            Next
            'stringJson = stringJson + "]"
        End If


        stringJson = stringJson + "}"
        Return stringJson

    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function leggiDatiGraficoLDLOG(ByVal serialNumber As String, ByVal listaInput As String) As String
        ' Dim serialNumber As String = ""
        ' Dim listaInput As String = ""
        Dim listLog As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim stringJson As String = "{"
        serialNumber = Replace(serialNumber, """", "")
        listaInput = Replace(listaInput, """", "")
        'listaInput = "ch7tempR,ch8tempR,ch9tempR"
        Dim listaInputList() As String = listaInput.Split(",")
        listaInput = "data," + listaInput
        'queryDB.connectToDb(True)
        queryDB.connectToDb(False)

        For Each element As String In listaInputList
            listLog.Add(element + "day", "")
            listLog.Add(element + "month", "")
            listLog.Add(element + "year", "")
        Next
        Dim version As String = queryDB.selectQueryMainLDLOG("Select DISTINCT  " + listaInput + " from M" + serialNumber + " order by data DESC", listLog)



        stringJson = stringJson + """errore"":""ok"""

        For Each chiave In listLog.Keys
            stringJson = stringJson + ",""" + chiave + """:[" + listLog.Item(chiave) + "]"
        Next
        stringJson = stringJson + "}"

        Return stringJson

    End Function


    Private Shared Function getConfigFromFile(ByVal serialReference As String) As String
        Dim virgola As String = ""
        Dim stringJson As String = ""

        If File.Exists("c:\centurio\" + serialReference + "_data.txt") Then
            Using r As StreamReader = New StreamReader("c:\centurio\" + serialReference + "_data.txt")
                Dim line As String
                Dim lineSplit As String()
                line = r.ReadLine
                Do While (Not line Is Nothing)
                    lineSplit = line.Split(":")
                    If lineSplit.Length > 1 Then
                        stringJson = stringJson + virgola + "{""chiave"":""" + lineSplit(0).Replace(">", "_") + """, ""valore"":""" + lineSplit(1) + """}"
                        virgola = ","
                    End If
                    line = r.ReadLine
                Loop
            End Using
        End If
        Return stringJson
    End Function
End Class