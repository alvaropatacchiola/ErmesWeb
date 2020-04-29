Public Class login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user As String = ""
        Dim password As String = ""
        Dim serial As String = ""
        Dim idSuper As String = ""
        Dim count_super As Integer = 0
        Dim query As New query
        Dim table_super As ermes_web_20.quey_db.super_userDataTable
        Dim listResult As New Dictionary(Of String, List(Of String))
        Dim stringaResult As String = "{"
        Dim virgola As String = ""

        user = Page.Request("user")
        password = Page.Request("pass")
        serial = Page.Request("serial")

        If (user.Length > 0) And password.Length > 0 Then
            table_super = query.login_super_user(user, password)
            count_super = table_super.Count
            'stringaRisposta.Text = "<?xml version=""1.0"" encoding=""UTF-8""?>"
            'stringaRisposta.Text = stringaRisposta.Text + "<Input nome = ""sito"" >"
            'stringaRisposta.Text = stringaRisposta.Text + "<valore name=""0"" index=""0"">Empty</valore>"

            If count_super > 0 Then

                If query.check_identificativo(serial) Then ' se true esiste gia questo codice
                    stringaResult = stringaResult + """errore"":""duplicateSerial""}"
                    stringaRisposta.Text = stringaResult
                    Exit Sub
                End If
                For Each dc In table_super
                    idSuper = dc.Id_super.ToString
                    Exit For
                Next
                Dim tabella_impianto As ermes_web_20.quey_db.impianto_newDataTable
                tabella_impianto = query.get_impianto_super(user, password)
                For Each dc In tabella_impianto
                    Dim split_impianto() As String = dc.nome_impianto.Split(">")
                    If listResult.ContainsKey(split_impianto(0)) Then
                        Dim listTemp As New List(Of String)
                        listTemp = listResult.Item(split_impianto(0))
                        listTemp.Add(split_impianto(1))
                        listResult.Item(split_impianto(0)) = listTemp
                    Else
                        Dim listTemp As New List(Of String)
                        listTemp.Add(split_impianto(1))
                        listResult.Add(split_impianto(0), listTemp)
                    End If
                Next
                stringaResult = stringaResult + """errore"":""ok"", ""idSuper"":""" + idSuper + """ , ""sito"":[{""nome"":""Empty"", ""impianto"":[{""nome"":""Empty""}]}"
                virgola = ","
                For Each chiave In listResult
                    stringaResult = stringaResult + virgola + " {""nome"":""" + chiave.Key + """"
                    Dim listTemp As New List(Of String)
                    listTemp = chiave.Value
                    stringaResult = stringaResult + ",""impianto"":[{""nome"":""Empty""}"
                    Dim virgolaTemp As String = ","
                    For Each impianto In listTemp
                        stringaResult = stringaResult + virgolaTemp + " {""nome"":""" + impianto + """}"
                        virgolaTemp = ","
                    Next
                    stringaResult = stringaResult + "]}"
                    virgola = ","
                Next
                stringaResult = stringaResult + "]}"
            Else
                stringaResult = stringaResult + """errore"":""invalidUser""}"
            End If

        End If

        stringaRisposta.Text = stringaResult
    End Sub

End Class