Namespace [Xmlrpc]
    Public Class [Delcomment]
        Inherits Zdevo.Page.XmlrpcPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Dim UserName As String = Context.Request.Form("username")
            Dim PassWord As String = Context.Request.Form("password")
            Dim Guid As String = Context.Request.Form("guid")
            Dim CommentUrl As String = Context.Request.Form("url")

            Dim Guids As New System.Collections.Generic.List(Of Guid)

            For Each s As String In Guid.Split(" ".ToCharArray)
                Dim g As New Guid(s)
                Guids.Add(g)
            Next

            If Me.zdevo_delComments(UserName, PassWord, Guids) = True Then
                'context.Response.Write((New Zdevo.Page.TemplatePage).zdevo_GetComment(Guid, 1, CInt(Container.Config("SITE_MSG_COUNT").Value)))
                Context.Response.Write(Zdevo.Common.Functions.Current.RequestFile(CommentUrl))
            End If

            'System.Web.HttpContext.Current.Response.Write(Zdevo.Common.Functions.Current.RequestFile(CommentUrl))    

            If b = True Then
                System_Terminate()
            End If

        End Sub

        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
