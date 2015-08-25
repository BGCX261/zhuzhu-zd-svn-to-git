Namespace [Blog]
    Public Class [Catalog]
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Zdevo.Common.Utility.Current.Trace.Write("进入blog catalog list处理程序")

            Dim postlist As Zdevo.Core.SQLite.ArticleList = Container.GetArticleList

            Dim PathRegexConfig As Zdevo.Common.ItemConfig(Of Zdevo.Common.Item) = Me.Container.ActionSplitConfig.Clone()
            PathRegexConfig("{%CategoryID%}").Value = Context.Request.QueryString("catalog")

            If postlist.List(New String() {"Page", "PageSize", "UrlRegex", "CategoryGUID", "PathRegexConfig", "IsDraft"}, New Object() {Context.Request.QueryString("page"), Container.Config("SITE_BLOG_LIST_COUNT").Value, Container.ActionConfig("blog_catalog_list").Value, Me.Container.Catalogs(CInt(Context.Request.QueryString("catalog"))).GUID, PathRegexConfig, False}) Then

            End If

            Dim cataloglist As Zdevo.Core.SQLite.CatalogList = Container.GetCatalogList
            If cataloglist.List(Nothing) Then

            End If

            HeadTitle = Me.Container.Catalogs(CInt(Context.Request.QueryString("catalog"))).Name
            PageNow = Context.Request.QueryString("page").ToLower

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)

            If IsNothing(Context.Request.Cookies("username")) = False And IsNothing(Context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(Context.Request.Cookies("username").Value, Context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            Me.WriteXML.WriteStartElement("articles")
            Me.WriteXML.WriteRaw(postlist.PageBar.NodeString)
            For Each post As Zdevo.Core.SQLite.Article In postlist.Items
                Me.WriteXML.WriteRaw(post.NodeString)
            Next
            Me.WriteXML.WriteEndElement()

            Me.WriteXML.WriteStartElement("catalogs")
            For Each catalog As Zdevo.Core.SQLite.Catalog In cataloglist.Items
                Me.WriteXML.WriteRaw(catalog.NodeString)
            Next
            Me.WriteXML.WriteEndElement()

            Me.EndXML()


            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\blog_list.xsl"))

            Zdevo.Common.Utility.Current.Trace.Write("转换完成，开始输出")

            Context.Response.Clear()
            Context.Response.Write(Me.BuildXHTML)

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
