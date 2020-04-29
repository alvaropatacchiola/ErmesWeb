Public Class java_script
    Public Sub set_url_setpoint(ByVal page_set As System.Web.UI.Page, ByVal variable_array(,) As String, ByVal lunghezza As Integer)
        Dim ss As String = ""
        Dim sb As New StringBuilder
        Dim i As Integer

        For i = 0 To lunghezza
            If (variable_array(i, 0) <> "") Then
                ss = ss + " var " + variable_array(i, 0) + " = " + variable_array(i, 1) + ";"
            End If
        Next
        sb.AppendLine(ss)
        page_set.ClientScript.RegisterStartupScript(Me.GetType, "jsMessages", sb.ToString, True)
    End Sub
    Public Sub call_function_javascript_onload(ByVal page_set As System.Web.UI.Page, ByVal name_function As String)
        Dim ss As String = ""
        Dim sb As New StringBuilder

        sb.AppendLine(ss)
        page_set.ClientScript.RegisterStartupScript(Me.GetType, "onload", name_function, True)

    End Sub
End Class
