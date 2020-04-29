Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization

Public Class lingua
    Inherits Page
    Protected Overrides Sub InitializeCulture()
        Try
            Dim selectedLanguage As String = Session("selectedLanguage")
            UICulture = selectedLanguage
            Culture = selectedLanguage
            Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture(selectedLanguage)
            Thread.CurrentThread.CurrentUICulture = New _
                CultureInfo(selectedLanguage)

            MyBase.InitializeCulture()
        Catch ex As Exception
            Dim linguaggio_def() As String
            Dim linguaggio As String
            Dim canale As String = ""
            Dim selectedLanguage As String

            linguaggio = Request.UserLanguages(0)
            linguaggio_def = linguaggio.Split("-")
            If linguaggio_def.Length > 1 Then
                selectedLanguage = linguaggio_def(0)
            Else
                selectedLanguage = "en"
            End If
            Session("selectedLanguage") = selectedLanguage
            UICulture = selectedLanguage
            Culture = selectedLanguage
            Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(selectedLanguage)
            Thread.CurrentThread.CurrentUICulture = New _
            CultureInfo(selectedLanguage)
        End Try

    End Sub

End Class
