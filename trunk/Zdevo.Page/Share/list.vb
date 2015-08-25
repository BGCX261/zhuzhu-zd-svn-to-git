Namespace [Share]
    Public Class List
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Container = New Zdevo.Core.SQLite.Container
            Container.Initialize()

            Zdevo.Common.Utility.Current.Trace.Write("进入share list处理程序")

            Dim postlist As Zdevo.Core.SQLite.ShareList = Container.GetShareList

            If postlist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {context.Request.QueryString("page"), Container.Config("SITE_BOOKMARK_LIST_COUNT").Value, Container.ActionConfig("share_list").Value}) Then

            End If

            HeadTitle = Me.Container.Site.Columns("share").Name
            PageNow = context.Request.QueryString("page").ToLower

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)

            If IsNothing(context.Request.Cookies("username")) = False And IsNothing(context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(context.Request.Cookies("username").Value, context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            Me.WriteXML.WriteStartElement("shares")
            Me.WriteXML.WriteRaw(postlist.PageBar.NodeString)
            For Each post As Zdevo.Core.SQLite.Share In postlist.Items
                Me.WriteXML.WriteRaw(post.NodeString)
            Next
            Me.WriteXML.WriteEndElement()
            Me.EndXML()

            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\share_list.xsl"))

            Zdevo.Common.Utility.Current.Trace.Write("转换完成，开始输出")

            context.Response.Clear()
            context.Response.Write(Me.BuildXHTML)

            Container.Terminate()

        End Sub

        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
