Namespace [Rss]
    Public Class Index
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Context.Response.ContentType = "text/xml"

            Dim b As Boolean
            b = Me.System_Initialize

            Dim rss As New Zdevo.Common.Rss

            Dim channel As New Zdevo.Common.Rss.Channel
            channel.title = Container.Sites.Item(0).Name
            channel.title = Container.Config("SITE_TITLE").Value
            channel.description = Container.Config("SITE_SUBTITLE").Value

            channel.link = Container.Sites.Item(0).Url
            channel.pubDate = System.DateTime.Now.ToString
            rss.AddChannel(channel)

            Zdevo.Common.Utility.Current.Trace.Write("进入rss处理程序")

            Dim postlist As Zdevo.Core.SQLite.PostList = Container.GetPostList
            Dim posts As New System.Collections.Generic.List(Of Zdevo.Core.Post)

            If postlist.List(New String() {"Page", "PageSize", "IsDraft"}, New Object() {1, Container.Config("SITE_RSS_LIST_COUNT").Value, False}) Then

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
                        Case Zdevo.Core.PostType.Share
                            posts.Add(Me.Container.GetShareList.Load(post))
                    End Select

                Next
            End If


            For Each post As Zdevo.Core.Post In posts
                Dim item As New Zdevo.Common.Rss.Item
                item.title = post.Name
                item.link = post.Url
                item.pubDate = post.ModifiTime.ToString
                item.description = post.Content
                item.guid = post.Url
                If item.title = String.Empty Then
                    item.title = post.Content
                End If
                If item.description = String.Empty Then
                    item.description = post.Name
                End If
                Select Case post.Type
                    Case Zdevo.Core.PostType.Article
                        item.title = "(" + Me.Container.Site.Columns("blog").Name + ")" + item.title
                    Case Zdevo.Core.PostType.Twitter
                        item.title = "(" + Me.Container.Site.Columns("twitter").Name + ")" + item.title
                    Case Zdevo.Core.PostType.Bookmark
                        item.title = "(" + Me.Container.Site.Columns("bookmark").Name + ")" + item.title
                    Case Zdevo.Core.PostType.Gallery
                        item.title = "(" + Me.Container.Site.Columns("gallery").Name + ")" + item.title
                    Case Core.PostType.Share
                        item.title = "(" + Me.Container.Site.Columns("share").Name + ")" + item.title
                End Select
                rss.AddItem(item)
            Next


            Context.Response.Write(rss.Xml)

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
