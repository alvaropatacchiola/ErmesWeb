'------------------------------------------------------------------------------
' <auto-generated>
'     Il codice è stato generato da uno strumento.
'     Versione runtime:4.0.30319.42000
'
'     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
'     il codice viene rigenerato.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace Resources
    
    'Questa classe è stata generata automaticamente dalla classe StronglyTypedResourceBuilder
    'tramite uno strumento quale ResGen o Visual Studio.
    'Per aggiungere o rimuovere un membro, modificare il file con estensione ResX, quindi eseguire nuovamente ResGen
    'con l'opzione /str oppure ricompilare il progetto Visual Studio.
    '''<summary>
    '''  Classe di risorse fortemente tipizzata per la ricerca di stringhe localizzate e così via.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "14.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class impianto_global
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Restituisce l'istanza di ResourceManager memorizzata nella cache da questa classe.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Resources.impianto_global", Global.System.Reflection.[Assembly].Load("App_GlobalResources"))
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Esegue l'override della proprietà CurrentUICulture del thread corrente per tutte
        '''  le ricerche di risorse eseguite con questa classe di risorse fortemente tipizzata.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Allarmi.
        '''</summary>
        Friend Shared ReadOnly Property allarmi() As String
            Get
                Return ResourceManager.GetString("allarmi", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Codice.
        '''</summary>
        Friend Shared ReadOnly Property codice() As String
            Get
                Return ResourceManager.GetString("codice", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Dati Impianto.
        '''</summary>
        Friend Shared ReadOnly Property dati_impianto() As String
            Get
                Return ResourceManager.GetString("dati_impianto", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Flow Ok.
        '''</summary>
        Friend Shared ReadOnly Property flow_ok() As String
            Get
                Return ResourceManager.GetString("flow_ok", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Gestisci Parametri.
        '''</summary>
        Friend Shared ReadOnly Property gestisci_parametri() As String
            Get
                Return ResourceManager.GetString("gestisci_parametri", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Ultimo Aggiornamento.
        '''</summary>
        Friend Shared ReadOnly Property last_update() As String
            Get
                Return ResourceManager.GetString("last_update", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Mappa.
        '''</summary>
        Friend Shared ReadOnly Property mappa() As String
            Get
                Return ResourceManager.GetString("mappa", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Non Connesso.
        '''</summary>
        Friend Shared ReadOnly Property no_connected() As String
            Get
                Return ResourceManager.GetString("no_connected", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a No Flusso.
        '''</summary>
        Friend Shared ReadOnly Property no_flow() As String
            Get
                Return ResourceManager.GetString("no_flow", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Referente.
        '''</summary>
        Friend Shared ReadOnly Property referente() As String
            Get
                Return ResourceManager.GetString("referente", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Ultimo Aggiornamento.
        '''</summary>
        Friend Shared ReadOnly Property statistica() As String
            Get
                Return ResourceManager.GetString("statistica", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Strumenti Attivi.
        '''</summary>
        Friend Shared ReadOnly Property strumenti_attivi() As String
            Get
                Return ResourceManager.GetString("strumenti_attivi", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a Vai all impianto.
        '''</summary>
        Friend Shared ReadOnly Property vaiImpianto() As String
            Get
                Return ResourceManager.GetString("vaiImpianto", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
