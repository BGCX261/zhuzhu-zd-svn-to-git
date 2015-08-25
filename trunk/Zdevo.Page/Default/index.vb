Namespace [Default]

    Public Class Index

        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Zdevo.Common.Utility.Current.Trace.Write(Zdevo.Common.Functions.Current.SHA1("degc"))

            Zdevo.Common.Utility.Current.Trace.Write("进入zdevo index处理程序")

            Dim clip As New System.Collections.Generic.SortedList(Of DateTime, Zdevo.Core.Post)
            Dim posts As New System.Collections.Generic.List(Of Zdevo.Core.Post)

            Dim postlist As Zdevo.Core.SQLite.PostList = Container.GetPostList
            Dim postlistpre As Zdevo.Core.SQLite.PostList = Container.GetPostList
            Dim DateBetween As New System.DateTime
            Dim DateAnd As New System.DateTime

            If postlistpre.List(New String() {"Page", "PageSize"}, New Object() {1, Container.Config("SITE_DEFAULT_LIST_COUNT").Value}) Then
                DateAnd = System.DateTime.Parse(postlistpre.Items(0).CreateTime.ToString("yyyy/MM/dd")).AddDays(1)
                DateBetween = System.DateTime.Parse(postlistpre.Items(postlistpre.Items.Count - 1).CreateTime.ToString("yyyy/MM/dd")).AddDays(-1)
            End If

            If postlist.List(New String() {"IsDraft", "DateBetween", "DateAnd"}, New Object() {False, DateBetween, DateAnd}) Then
                For Each post As Zdevo.Core.SQLite.Post In postlist.Items
                    If clip.ContainsKey(post.CreateTime) = False Then
                        Select Case post.Type
                            Case Zdevo.Core.PostType.Article
                                clip.Add(post.CreateTime, Me.Container.GetArticleList.Load(post))
                            Case Zdevo.Core.PostType.Twitter
                                clip.Add(post.CreateTime, Me.Container.GetTwitterList.Load(post))
                            Case Zdevo.Core.PostType.Bookmark
                                clip.Add(post.CreateTime, Me.Container.GetBookmarkList.Load(post))
                            Case Zdevo.Core.PostType.Gallery
                                clip.Add(post.CreateTime, Me.Container.GetGalleryList.Load(post))
                            Case Zdevo.Core.PostType.Share
                                clip.Add(post.CreateTime, Me.Container.GetShareList.Load(post))
                        End Select
                    End If
                Next
            End If

            For i As Integer = clip.Count - 1 To 0 Step -1
                posts.Add(clip.Values.Item(i))
            Next


            'Dim postlist As Zdevo.Core.SQLite.ArticleList = Container.GetArticleList

            'If postlist.List(New String() {"Page", "PageSize", "UrlRegex", "PageBar_PageSize"}, New Object() {context.Request.QueryString("page"), Container.Config("SITE_DEFAULT_LIST_COUNT").Value, Container.ActionConfig("blog_list").Value, Container.Config("SITE_BLOG_LIST_COUNT").Value}) Then
            '    For Each post As Zdevo.Core.SQLite.Article In postlist.Items
            '        clip.Add(post.CreateTime, post)
            '    Next
            'End If

            'Dim witterlist As Zdevo.Core.SQLite.TwitterList = Container.GetTwitterList

            'If witterlist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {1, Container.Config("SITE_DEFAULT_TWITTER_COUNT").Value, Container.ActionConfig("twitter_list").Value}) Then
            '    For Each post As Zdevo.Core.SQLite.Twitter In witterlist.Items
            '        clip.Add(post.CreateTime, post)
            '    Next
            'End If


            'Dim bookmarklist As Zdevo.Core.SQLite.BookmarkList = Container.GetBookmarkList

            'If bookmarklist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {1, Container.Config("SITE_DEFAULT_BOOKMARK_COUNT").Value, Container.ActionConfig("bookmark_list").Value}) Then
            '    For Each post As Zdevo.Core.SQLite.Bookmark In bookmarklist.Items
            '        clip.Add(post.CreateTime, post)
            '    Next
            'End If


            Dim commentlist As Zdevo.Core.SQLite.CommentList = Container.GetCommentList

            If commentlist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {1, Container.Config("SITE_MSG_COUNT").Value, Container.ActionConfig("bookmark_list").Value}) Then

            End If

            HeadTitle = Me.Container.Site.Columns("index").Name

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)


            Zdevo.Common.Utility.Current.Trace.Write(IsNothing(context.Request.Cookies("username")).ToString)

            If IsNothing(context.Request.Cookies("username")) = False And IsNothing(context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(context.Request.Cookies("username").Value, context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            'For Each post As Zdevo.Core.Post In posts
            '    Me.WriteXML.WriteStartElement("posts")
            '    Me.WriteXML.WriteRaw(post.NodeString)
            '    Me.WriteXML.WriteEndElement()
            'Next

            Dim d As DateTime = Nothing
            For i As Integer = 0 To posts.Count - 1
                If i = 0 Then
                    Me.WriteXML.WriteStartElement("posts")
                End If

                If d = Nothing Then
                    d = System.DateTime.Parse(posts(i).CreateTime.ToString("yyyy/MM/dd"))
                End If

                If d <> System.DateTime.Parse(posts(i).CreateTime.ToString("yyyy/MM/dd")) Then
                    Me.WriteXML.WriteEndElement()
                    Me.WriteXML.WriteStartElement("posts")
                End If

                Me.WriteXML.WriteRaw(posts(i).NodeString)

                d = System.DateTime.Parse(posts(i).CreateTime.ToString("yyyy/MM/dd"))

                If i = posts.Count - 1 Then
                    Me.WriteXML.WriteEndElement()
                End If
            Next



            'Me.WriteXML.WriteStartElement("articles")
            'Me.WriteXML.WriteRaw(postlist.PageBar.NodeString)
            'For Each post As Zdevo.Core.SQLite.Article In postlist.Items
            '    Me.WriteXML.WriteRaw(post.NodeString)
            'Next
            'Me.WriteXML.WriteEndElement()

            'Me.WriteXML.WriteStartElement("twitters")
            'For Each witter As Zdevo.Core.SQLite.Twitter In witterlist.Items
            '    Me.WriteXML.WriteRaw(witter.NodeString)
            'Next
            'Me.WriteXML.WriteEndElement()


            'Me.WriteXML.WriteStartElement("bookmarks")
            'For Each bookmark As Zdevo.Core.SQLite.Bookmark In bookmarklist.Items
            '    Me.WriteXML.WriteRaw(bookmark.NodeString)
            'Next
            'Me.WriteXML.WriteEndElement()


            Me.WriteXML.WriteStartElement("comments")
            For Each comment As Zdevo.Core.SQLite.Comment In commentlist.Items
                Me.WriteXML.WriteRaw(comment.NodeString)
            Next
            Me.WriteXML.WriteEndElement()

            Me.EndXML()

            Zdevo.Common.Utility.Current.Trace.Write("直接输出XML")
            'context.Response.Clear()
            'context.Response.Write(Me.GetXML.ToString)

            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\index.xsl"))

            Zdevo.Common.Utility.Current.Trace.Write("转换完成，开始输出")

            context.Response.Clear()
            context.Response.Write(Me.BuildXHTML)

            'context.Response.Write(Me.GetXML)

            'context.Server.Execute("~/abc.aspx")


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
