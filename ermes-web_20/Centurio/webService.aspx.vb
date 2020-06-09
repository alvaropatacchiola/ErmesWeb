Public Class webService
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim serialNumber As String = "ppppppppppppppppp"
        'Dim listaInput As String = "ch7tempR,ch8tempR,ch9tempR"
        'Dim listLog As Dictionary(Of String, String) = New Dictionary(Of String, String)
        'serialNumber = Replace(serialNumber, """", "")
        'listaInput = Replace(listaInput, """", "")
        'Dim listaInputList() As String = listaInput.Split(",")
        'listaInput = "data," + listaInput
        'queryDB.connectToDb(True)
        'For Each element As String In listaInputList
        '    listLog.Add(element + "day", "")
        '    listLog.Add(element + "month", "")
        '    listLog.Add(element + "year", "")
        'Next
        'Dim version As String = queryDB.selectQueryMainLDLOG("Select DISTINCT  " + listaInput + " from M" + serialNumber + " order by data DESC", listLog)


        Dim serialNumber As String = ""
        Dim type As String = ""
        Dim user As String = ""
        Dim password As String = ""
        Dim id_485_impianto As String = ""
        Dim jsonCon As New jsonConvertvb
        serialNumber = Page.Request("serial")
        type = Page.Request("type")
        user = Page.Request("user")
        password = Page.Request("pwd")
        id_485_impianto = Page.Request("id485")

        stringaRisposta.Text = jsonCon.jsonResultGlobal(serialNumber, type, user, password, id_485_impianto)

    End Sub

End Class