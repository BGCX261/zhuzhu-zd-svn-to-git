Namespace [Rss]
    Public Class [Blog]
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

            Dim postlist As Zdevo.Core.SQLite.ArticleList = Container.GetArticleList

            If postlist.List(New String() {"Page", "PageSize", "UrlRegex", "IsDraft"}, New Object() {Context.Request.QueryString("page"), Container.Config("SITE_RSS_LIST_COUNT").Value, Container.ActionConfig("blog_list").Value, False}) Then

                For Each post As Zdevo.Core.SQLite.Article In postlist.Items
                    Dim item As New Zdevo.Common.Rss.Item
                    item.title = post.Name
                    item.link = post.Url
                    item.pubDate = post.CreateTime.ToString
                    item.description = post.Content
                    item.guid = item.link
                    rss.AddItem(item)
                Next
            End If

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
