Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization

Public Class language
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim canale As String = ""
        canale = Page.Request("lang")
        Dim selectedLanguage As String

        Dim linguaggio_def() As String
        Dim linguaggio As String
        ' Session.Abandon()
        'Session.Clear()

        If canale Is Nothing Or canale = "" Then
            linguaggio = Request.UserLanguages(0)
            linguaggio_def = linguaggio.Split("-")
            Try
                If linguaggio_def.Length > 1 Then
                    selectedLanguage = linguaggio_def(0)
                Else
                    selectedLanguage = linguaggio_def(0)
                    If selectedLanguage <> "en" And selectedLanguage <> "it" And selectedLanguage <> "de" And selectedLanguage <> "fr" And selectedLanguage <> "pl" And selectedLanguage <> "es" Then
                        selectedLanguage = "en"
                    End If

                End If
            Catch ex As Exception
                selectedLanguage = "en"
            End Try
        Else
            selectedLanguage = canale
        End If
        If selectedLanguage <> "en" And selectedLanguage <> "it" And selectedLanguage <> "de" And selectedLanguage <> "fr" And selectedLanguage <> "pl" And selectedLanguage <> "es" Then
            selectedLanguage = "en"
        End If
        Session("selectedLanguage") = selectedLanguage
        UICulture = selectedLanguage
        Culture = selectedLanguage
        Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(selectedLanguage)
        Thread.CurrentThread.CurrentUICulture = New _
            CultureInfo(selectedLanguage)

        MyBase.InitializeCulture()

        Master.create_master_page()
        Master.manage_sidebar_top()

        Response.Redirect("dashboardAssets.aspx")

    End Sub

End Class