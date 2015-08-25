Namespace [Rss]
    Public Class [Sitemap]
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            context.Response.ContentType = "text/xml"

            Dim b As Boolean
            b = Me.System_Initialize

            Me.CompressionPage()

            Dim sitemap As New Zdevo.Common.Sitemap

            Zdevo.Common.Utility.Current.Trace.Write("进入rss处理程序")


            Dim postlist As Zdevo.Core.SQLite.PostList = Container.GetPostList
            Dim posts As New System.Collections.Generic.List(Of Zdevo.Core.Post)

            If postlist.List(New String() {"IsDraft"}, New Object() {False}) Then

                For Each post As Zdevo.Core.SQLite.Post In postlist.Items

                    Select Case post.Type
                        Case Zdevo.Core.PostType.Article
                            posts.Add(Me.Container.GetArticleList.Load(post))
                        Case Zdevo.Core.PostType.Twitter
                            posts.Add(Me.Container.GetTwitterList.Load(post))
                        Case Zdevo.Core.PostType.Bookmark
                            posts.Add(Me.Container.GetBookmarkList.Load(post))
                        Case Zdevo.Core.PostType.Gallery
                            posts.Add(Me.Container.GetGalleryList.Load(post))
                    End Select

                Next
            End If

            For Each post As Zdevo.Core.Post In posts
                Dim item As New Zdevo.Common.Sitemap.Item
                item.loc = post.Url
                item.lastmod = post.CreateTime.ToString
                sitemap.AddItem(item)
            Next

            Context.Response.Write(sitemap.Xml)

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
