Imports Microsoft.VisualBasic

Imports System
Imports System.Web
Imports System.Security.Principal

Namespace SecurityModules
    Public Class SecurityHttpModule
        Implements IHttpModule

#Region "Properties"
        Public ReadOnly Property IsReusable() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

        Public Sub New()
        End Sub

        ''' <summary>Initializes a module and prepares it to handle requests.</summary>
        ''' <param name="context">An <see cref="T:System.Web.HttpApplication" /> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application </param>
        Public Sub Init(ByVal context As System.Web.HttpApplication) Implements IHttpModule.Init
            AddHandler context.AuthenticateRequest, AddressOf AuthenticateRequest
        End Sub

        ''' <summary>Occurs when a security module has established the identity of the user.</summary>
        Private Sub AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim Application As HttpApplication = CType(sender, HttpApplication)
            Dim Request As HttpRequest = Application.Context.Request
            Dim Response As HttpResponse = Application.Context.Response
            Dim allow As Boolean = False ' Default is not not allow

            '' Exit if we're on login.aspx, not authenticated, or no siteMapNode exists.
            'If Request.Url.AbsolutePath.ToLower() = FormsAuthentication.LoginUrl.ToLower() Then
            '    Return
            'End If
            'If Application.Context.User Is Nothing Then
            '    Response.Redirect(FormsAuthentication.LoginUrl)
            'End If
            'If SiteMap.CurrentNode Is Nothing Then
            '    Return
            'End If

            '' Check if user is in roles
            'If SiteMap.CurrentNode.Roles.Count = 0 Then
            '    allow = True ' No Roles found, so we allow.
            'Else

            '    ' Loop through each role and check to see if user is in it.
            '    For Each role As String In SiteMap.CurrentNode.Roles
            '        If Roles.IsUserInRole(role) Then
            '            allow = True
            '            Exit For
            '        End If
            '    Next role
            'End If

            ' Do we deny?
            If allow = False Then
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If
        End Sub

        ''' <summary>Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule" />.</summary>
        Public Sub Dispose() Implements IHttpModule.Dispose
        End Sub
    End Class

End Namespace
