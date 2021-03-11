Imports System.Web.SessionState
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Globalization
Imports System.IO
Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'avvio dell'applicazione
        'Dim myScriptResDef As New ScriptResourceDefinition()
        'myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js"
        'myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js"
        'myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js"
        'myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js"
        'ScriptManager.ScriptResourceMapping.AddDefinition("jquery", Nothing, myScriptResDef)

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'avvio della sessione
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato all'inizio di ogni richiesta
       
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al tentativo di autenticare l'utilizzo
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        'Generato quando si verifica un errore

        'Context.ClearError()
        'Response.Write("application_error" + "<br/>")
        'Response.Write("<b>error msg:</b>" + e.ToString + "<br/>" + "<b>end error msg<b/>")
        'Response.Redirect("error.aspx")

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al termine della sessione
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Generato al termine dell'applicazione
    End Sub

End Class