Namespace [Share]
    Public Class [Single]
        Inherits Zdevo.Page.HtmlPage


        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Zdevo.Common.Utility.Current.Trace.Write("进入share singles处理程序")

            Dim b As Boolean
            b = Me.System_Initialize

            Dim postlist As Zdevo.Core.SQLite.ShareList = Container.GetShareList
            Dim post As Zdevo.Core.SQLite.Share = Nothing

            If context.Request.QueryString("id") IsNot Nothing Then
                If postlist.Load(CInt(context.Request.QueryString("id")), post) Then
                    post.GetComments()
                End If
            End If

            If context.Request.QueryString("guid") IsNot Nothing Then
                If postlist.Load(New Guid(context.Request.QueryString("guid")), post) Then
                    post.GetComments()
                End If
            End If

            HeadTitle = post.Name
            ColumnNow = Me.Container.Site.Columns("share").Name

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)

            If IsNothing(context.Request.Cookies("username")) = False And IsNothing(context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(context.Request.Cookies("username").Value, context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            Me.WriteXML.WriteRaw(post.NodeString)
            Me.EndXML()

            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\share_single.xsl"))

            Zdevo.Common.Utility.Current.Trace.Write("转换完成，开始输出")

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
