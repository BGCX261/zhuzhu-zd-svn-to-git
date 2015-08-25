Namespace [Twitter]
    Public Class List
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Zdevo.Common.Utility.Current.Trace.Write("进入twitter list处理程序")

            Dim postlist As Zdevo.Core.SQLite.TwitterList = Container.GetTwitterList

            If postlist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {context.Request.QueryString("page"), Container.Config("SITE_TWITTER_LIST_COUNT").Value, Container.ActionConfig("twitter_list").Value}) Then

            End If

            HeadTitle = Me.Container.Site.Columns("twitter").Name
            PageNow = context.Request.QueryString("page").ToLower

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)

            If IsNothing(context.Request.Cookies("username")) = False And IsNothing(context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(context.Request.Cookies("username").Value, context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            Me.WriteXML.WriteStartElement("twitters")
            Me.WriteXML.WriteRaw(postlist.PageBar.NodeString)
            For Each post As Zdevo.Core.SQLite.Twitter In postlist.Items
                Me.WriteXML.WriteRaw(post.NodeString)
            Next
            Me.WriteXML.WriteEndElement()
            Me.EndXML()

            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\twitter_list.xsl"))

            Zdevo.Common.Utility.Current.Trace.Write("转换完成，开始输出")

            context.Response.Clear()
            context.Response.Write(Me.BuildXHTML)

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
