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
    Friend Class communication_g
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Resources.communication_g", Global.System.Reflection.[Assembly].Load("App_GlobalResources"))
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
        '''  Cerca una stringa localizzata simile a &lt;h4&gt;06/04/2017 ERMES è sempre più user-friendly&lt;/h4&gt;&lt;p&gt;Da lunedì 10 aprile è infatti disponibile la nuova dashboard ERMES, per avere una lettura ancora più immediata di tutti i parametri e le informazioni che riguardano i tuoi impianti gestiti a distanza. Anche da mobile, grazie alla nuova interfaccia, il controllo remoto sui tuoi impianti non è mai stato così semplice e immediato.&lt;/p&gt;&lt;h4&gt;17/05/2016 Aggiornamento di sistema!&lt;/h4&gt;&lt;h4&gt;19/01/2017 Manutenzione sistema ERMES!&lt;/h4&gt;&lt;p&gt;Nella giornata di giovedì 19- [stringa troncata]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property globali() As String
            Get
                Return ResourceManager.GetString("globali", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a 06/04/2017|ERMES è sempre più user-friendly|Da lunedì 10 aprile è infatti disponibile la nuova dashboard ERMES, per avere una lettura ancora più immediata di tutti i parametri e le informazioni che riguardano i tuoi impianti gestiti a distanza. Anche da mobile, grazie alla nuova interfaccia, il controllo remoto sui tuoi impianti non è mai stato così semplice e immediato.|&amp;17/05/2016|Aggiornamento di sistema!||&amp;19/01/2017| Manutenzione sistema ERMES!|Nella giornata di giovedì 19-01-2017 il sistema ermes non  [stringa troncata]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property globaliNew() As String
            Get
                Return ResourceManager.GetString("globaliNew", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a &lt;h4&gt;17/05/2016 Aggiornamento di sistema!&lt;/h4&gt;&lt;p&gt;Ogni account può contenere un numero illimitato di utenti che possono modificare i parametri dell impianto&lt;/p&gt;.
        '''</summary>
        Friend Shared ReadOnly Property ultime() As String
            Get
                Return ResourceManager.GetString("ultime", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Cerca una stringa localizzata simile a 17/05/2016|Aggiornamento di sistema!|Ogni account può contenere un numero illimitato di utenti che possono modificare i parametri dell impianto|.
        '''</summary>
        Friend Shared ReadOnly Property ultimeNew() As String
            Get
                Return ResourceManager.GetString("ultimeNew", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
