Namespace [Blog]
    Public Class [Single]
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Zdevo.Common.Utility.Current.Trace.Write("进入blog singles处理程序")

            Dim b As Boolean
            b = Me.System_Initialize

            Dim postlist As Zdevo.Core.SQLite.ArticleList = Container.GetArticleList
            Dim post As Zdevo.Core.SQLite.Article = Nothing

            If Context.Request.QueryString("id") IsNot Nothing Then
                If postlist.Load(CInt(Context.Request.QueryString("id")), post) Then
                    post.GetComments()
                End If
            End If

            If Context.Request.QueryString("guid") IsNot Nothing Then
                If postlist.Load(New Guid(Context.Request.QueryString("guid")), post) Then
                    post.GetComments()
                End If
            End If

            HeadTitle = post.Name
            ColumnNow = Me.Container.Site.Columns("blog").Name

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)

            If IsNothing(Context.Request.Cookies("username")) = False And IsNothing(Context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(Context.Request.Cookies("username").Value, Context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            Me.WriteXML.WriteRaw(post.NodeString)
            Me.EndXML()

            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\blog_single.xsl"))

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
