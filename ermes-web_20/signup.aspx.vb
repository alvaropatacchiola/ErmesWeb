Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization

Public Class signup
    Inherits lingua

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        literal_stefano.Text = Session("personalizzazioneStefano")

        java_script_local.Text = "<script>"
        java_script_local.Text = java_script_local.Text + "var username='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "username") + "';"
        java_script_local.Text = java_script_local.Text + "var username_6='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "username_6") + "';"
        java_script_local.Text = java_script_local.Text + "var password='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "password") + "';"
        java_script_local.Text = java_script_local.Text + "var password_6='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "password_6") + "';"
        java_script_local.Text = java_script_local.Text + "var password_uguale='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "password_uguale") + "';"
        java_script_local.Text = java_script_local.Text + "var email='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "email") + "';"
        java_script_local.Text = java_script_local.Text + "var policy='"
        java_script_local.Text = java_script_local.Text + GetGlobalResourceObject("javascript_global", "policy") + "';"

        java_script_local.Text = java_script_local.Text + "</script>"
        Try
            Literal1.Text = "<a href='login.aspx?lang=" + Session("selectedLanguage") + "'>" + GetGlobalResourceObject("signup_global", "sign_in") + "</a>"
        Catch ex As Exception
            Literal1.Text = "<a href='login.aspx'>" + GetGlobalResourceObject("signup_global", "sign_in") + "</a>"
        End Try
        literal_theme.Text = Session("stile")

    End Sub

    

End Class