Namespace [Xmlrpc]
    Public Class [Comment]
        Inherits Zdevo.Page.XmlrpcPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Dim UserName As String = Context.Request.Form("username")
            Dim PassWord As String = Context.Request.Form("password")
            Dim Guid As Guid = New Guid(Context.Request.Form("guid"))
            Dim Name As String = Context.Request.Form("name")
            Dim Email As String = Context.Request.Form("email")
            Dim Homepage As String = Context.Request.Form("homepage")
            Dim Content As String = Context.Request.Form("content")
            Dim CommentUrl As String = Context.Request.Form("url")

            If Me.zdevo_newComment(UserName, PassWord, Guid, Name, Email, Homepage, Content, CommentUrl) = True Then
                'context.Response.Write((New Zdevo.Page.TemplatePage).zdevo_GetComment(Guid, 1, CInt(Container.Config("SITE_MSG_COUNT").Value)))
                Context.Response.Write(Zdevo.Common.Functions.Current.RequestFile(CommentUrl))
            End If

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
