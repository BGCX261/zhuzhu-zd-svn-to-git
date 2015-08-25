Namespace [Gallery]
    Public Class List
        Inherits Zdevo.Page.HtmlPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            Zdevo.Common.Utility.Current.Trace.Write("进入gallerys list处理程序")

            Dim postlist As Zdevo.Core.SQLite.GalleryList = Container.GetGalleryList

            If postlist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {Context.Request.QueryString("page"), Container.Config("SITE_GALLERY_LIST_COUNT").Value, Container.ActionConfig("gallery_list").Value}) Then

            End If

            Dim postlist2 As Zdevo.Core.SQLite.GalleryList = Container.GetGalleryList

            Dim flickr As Zdevo.Core.SQLite.Gallery = Container.NewGallery
            If postlist2.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, Container.Config("SITE_GALLERY_FLICKR_LIST_COUNT").Value, "Flickr"}) Then
                flickr = postlist2.Items(0)
            End If

            HeadTitle = Me.Container.Site.Columns("gallery").Name
            PageNow = Context.Request.QueryString("page").ToLower

            Me.StartXML()
            Me.WriteXML.WriteRaw(Container.Site.NodeString)

            If IsNothing(Context.Request.Cookies("username")) = False And IsNothing(Context.Request.Cookies("password")) = False Then
                If Me.Container.GetUserList.Load(Context.Request.Cookies("username").Value, Context.Request.Cookies("password").Value) IsNot Nothing Then
                    Me.WriteXML.WriteRaw(Container.User.NodeString)
                End If
            End If

            Me.WriteXML.WriteStartElement("gallerys")
            Me.WriteXML.WriteRaw(postlist.PageBar.NodeString)
            For Each post As Zdevo.Core.SQLite.Gallery In postlist.Items
                Me.WriteXML.WriteRaw(post.NodeString)
            Next
            Me.WriteXML.WriteEndElement()

            Me.WriteXML.WriteStartElement("flickr")
            'Me.WriteXML.WriteRaw(flickr.NodeString)
            For Each post As Zdevo.Core.SQLite.Gallery In postlist2.Items
                Me.WriteXML.WriteRaw(post.NodeString)
            Next
            Me.WriteXML.WriteEndElement()

            Me.EndXML()

            Zdevo.Common.Utility.Current.Trace.Write("加载模板，开始转换")

            Me.LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\gallery_list.xsl"))

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
