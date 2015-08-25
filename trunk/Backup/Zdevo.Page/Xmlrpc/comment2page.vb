Namespace [Xmlrpc]
    Public Class [Comment2page]
        Inherits Zdevo.Page.BasePage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Dim guid As Guid = New Guid(Context.Request("guid"))

            Dim comment As Zdevo.Core.Comment = Me.Container.GetCommentList.Load(guid)

            Zdevo.Common.Utility.Current.Trace.Write(Me.Container.GetPostList.Load(comment.PostGUID).ToString)

            Dim post As Zdevo.Core.Post = Me.Container.GetPostList.Load(comment.PostGUID)


            Dim postguid As Guid = post.GUID
            Dim posttype As Zdevo.Core.PostType = post.Type

            Dim commentid As String = comment.ID.ToString

            Select Case posttype
                Case Zdevo.Core.PostType.Article
                    Context.Response.Redirect(Me.Container.GetArticleList.Load(postguid).Url + "#cmt" + commentid)
                Case Zdevo.Core.PostType.Bookmark
                    Context.Response.Redirect(Me.Container.GetBookmarkList.Load(postguid).Url + "#cmt" + commentid)
                Case Zdevo.Core.PostType.Gallery
                    Context.Response.Redirect(Me.Container.GetGalleryList.Load(postguid).Url + "#cmt" + commentid)
                Case Zdevo.Core.PostType.Guestbook
                    Context.Response.Redirect(Me.Container.GetGuestbookList.Load(postguid).Url + "#cmt" + commentid)
                Case Zdevo.Core.PostType.Twitter
                    context.Response.Redirect(Me.Container.GetTwitterList.Load(postguid).Url + "#cmt" + commentid)
            End Select

            If b = True Then
                Me.System_Terminate()
            End If


        End Sub

        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
