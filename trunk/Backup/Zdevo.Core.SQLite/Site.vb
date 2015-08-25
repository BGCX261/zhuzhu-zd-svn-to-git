Public Class Site : Inherits Core.Site

    Public Title As String = ""
    Public SubTitle As String = ""
    Public Host As String = ""
    Public Template As String = ""


    Public Columns As New System.Collections.Generic.Dictionary(Of String, Column)

    Private FContainer As Container
    Protected Overloads Property Container() As Container
        Get
            Return FContainer
        End Get
        Set(ByVal value As Container)
            FContainer = value
        End Set
    End Property

    Public Sub New(ByVal nowContainer As Container)

        Container = nowContainer

    End Sub

    Public Overrides Property NodeString() As String
        Get
            If String.IsNullOrEmpty(MyBase.NodeString) Then

                Dim sb As New Text.StringBuilder
                Dim wr As New Xml.XmlTextWriter(New IO.StringWriter(sb))

                wr.WriteStartElement("site")

                wr.WriteElementString("id", Xml.XmlConvert.ToString(Me.ID))
                wr.WriteElementString("guid", Xml.XmlConvert.ToString(Me.GUID))
                wr.WriteElementString("url", Me.Url)
                wr.WriteElementString("name", Me.Name)
                wr.WriteElementString("intro", Me.Intro)
                wr.WriteElementString("articlenums", Xml.XmlConvert.ToString(Me.PostNums))
                wr.WriteElementString("categorynums", Xml.XmlConvert.ToString(Me.CategoryNums))
                wr.WriteElementString("usernums", Xml.XmlConvert.ToString(Me.UserNums))
                wr.WriteElementString("commentnums", Xml.XmlConvert.ToString(Me.CommentNums))

                wr.WriteElementString("title", Me.Title)
                wr.WriteElementString("subtitle", Me.SubTitle)
                wr.WriteElementString("template", Me.Template)
                wr.WriteElementString("host", Me.Host)

                wr.WriteElementString("xmlrpcurl", Me.XmlRpcUrl)
                wr.WriteElementString("rsdurl", Me.RsdUrl)
                wr.WriteElementString("loginurl", Me.LoginUrl)
                wr.WriteElementString("logouturl", Me.LogoutUrl)
                wr.WriteElementString("wlwmanifesturl", Me.WlwmanifestUrl)

                Dim OrderColumns As New System.Collections.Generic.SortedList(Of Integer, Column)
                For Each c As Column In Columns.Values
                    OrderColumns.Add(c.Order, c)
                Next

                For Each c As Column In OrderColumns.Values
                    wr.WriteStartElement("column")
                    wr.WriteAttributeString("id", c.Id)
                    wr.WriteElementString("name", c.Name)
                    wr.WriteElementString("url", c.Url)
                    wr.WriteElementString("rss", c.RssUrl)
                    wr.WriteEndElement()
                Next

                wr.WriteStartElement("config")
                For Each s As String In Me.Config.Keys
                    wr.WriteStartElement("variable")
                    wr.WriteAttributeString("name", s)
                    wr.WriteValue(Me.Config(s).Value)
                    wr.WriteEndElement()
                Next
                wr.WriteEndElement()

                wr.WriteEndElement()

                wr.Close()

                MyBase.NodeString = sb.ToString
            End If
            Return MyBase.NodeString
        End Get
        Set(ByVal value As String)
            MyBase.NodeString = value
        End Set
    End Property


    Public Overrides ReadOnly Property Url() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            PathRegexConfig("{%SiteName%}").Value = Me.Name
            PathRegexConfig("{%SiteID%}").Value = Me.ID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("site_default").Value, PathRegexConfig)
        End Get
    End Property



    Public Overridable ReadOnly Property RsdUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            'PathRegexConfig("{%SiteName%}").Value = Me.Name
            'PathRegexConfig("{%SiteID%}").Value = Me.ID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value
            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_rsd").Value, PathRegexConfig)
        End Get
    End Property


    Public Overridable ReadOnly Property WlwmanifestUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            'PathRegexConfig("{%SiteName%}").Value = Me.Name
            'PathRegexConfig("{%SiteID%}").Value = Me.ID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value
            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_wlwmanifest").Value, PathRegexConfig)
        End Get
    End Property



    Public Overridable ReadOnly Property XmlRpcUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            'PathRegexConfig("{%SiteName%}").Value = Me.Name
            'PathRegexConfig("{%SiteID%}").Value = Me.ID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value
            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_index").Value, PathRegexConfig)
        End Get
    End Property

    Public Overridable ReadOnly Property LoginUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            'PathRegexConfig("{%SiteName%}").Value = Me.Name
            'PathRegexConfig("{%SiteID%}").Value = Me.ID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value
            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_login").Value, PathRegexConfig)
        End Get
    End Property


    Public Overridable ReadOnly Property LogoutUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            'PathRegexConfig("{%SiteName%}").Value = Me.Name
            'PathRegexConfig("{%SiteID%}").Value = Me.ID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value
            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_logout").Value, PathRegexConfig)
        End Get
    End Property


    Private FStorageConfig As New Common.ItemConfig(Of Common.Item)
    Public Overridable Property StorageConfig() As Common.ItemConfig(Of Common.Item)
        Get
            Return FStorageConfig
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))
            FStorageConfig = value
        End Set
    End Property


    Public Overrides Property Meta() As Common.ItemConfig(Of Common.Item)
        Get
            MyBase.Meta = New Common.ItemConfig(Of Common.Item)

            If FStorageConfig.Count > 0 Then
                Dim xf As New Common.XmlSerialize(Of Common.ItemConfig(Of Common.Item))
                Dim s As String = xf.Serialize(FStorageConfig)
                MyBase.Meta.Add(New Common.Item("storageconfig", s))
            End If

            Return MyBase.Meta
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))

            MyBase.Meta = value
            If MyBase.Meta.ContainsKey("storageconfig") = True Then
                Dim xf As New Common.XmlSerialize(Of Common.ItemConfig(Of Common.Item))
                FStorageConfig = xf.DeSerialize(MyBase.Meta("storageconfig").Value)
            End If

        End Set
    End Property


    Private FConfig As New Common.ItemConfig(Of Common.Item)
    Public Overridable ReadOnly Property Config() As Common.ItemConfig(Of Common.Item)
        Get

            For Each c As Common.Item In Me.Container.GlobalConfig.Values
                If FConfig.ContainsKey(c.Name) = False Then
                    FConfig.Add(New Common.Item(String.Copy(c.Name), String.Copy(c.Value)))
                Else
                    FConfig(c.Name).Value = String.Copy(c.Value)
                End If
            Next

            For Each c As Common.Item In Me.Container.SiteConfig.Values
                If FConfig.ContainsKey(c.Name) = False Then
                    FConfig.Add(New Common.Item(String.Copy(c.Name), String.Copy(c.Value)))
                Else
                    FConfig(c.Name).Value = String.Copy(c.Value)
                End If
            Next

            For Each c As Common.Item In Me.StorageConfig.Values
                If FConfig.ContainsKey(c.Name) = False Then
                    FConfig.Add(New Common.Item(String.Copy(c.Name), String.Copy(c.Value)))
                Else
                    FConfig(c.Name).Value = String.Copy(c.Value)
                End If
            Next

            FConfig("SITE_HOST").Value = String.Copy(FConfig("APPLICATION_HOST").Value)

            Dim ColumnIndex As New Column
            Dim ColumnBlog As New Column
            Dim ColumnAtomy As New Column
            Dim ColumnBookmark As New Column
            Dim ColumnGallery As New Column
            Dim ColumnGuestBook As New Column
            Dim ColumnShare As New Column

            ColumnIndex.Order = CInt("0" + Me.FConfig("SITE_COLUMN_INDEX_ORDER").Value)
            ColumnIndex.Id = "index"
            ColumnIndex.Name = Me.FConfig("SITE_COLUMN_INDEX_NAME").Value
            ColumnIndex.Url = Me.FConfig("SITE_COLUMN_INDEX_URL").Value
            ColumnIndex.Url = ColumnIndex.Url '+ "/"

            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone
            PathRegexConfig("{%HostDirectory%}").Value = FConfig("SITE_HOST").Value
            ColumnIndex.RssUrl = Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("feed_rss_index").Value, PathRegexConfig)

            ColumnBlog.Order = CInt("0" + Me.FConfig("SITE_COLUMN_BLOG_ORDER").Value)
            ColumnBlog.Id = "blog"
            ColumnBlog.Name = Me.FConfig("SITE_COLUMN_BLOG_NAME").Value
            ColumnBlog.Url = Me.FConfig("SITE_COLUMN_BLOG_URL").Value
            ColumnBlog.Url = ColumnBlog.Url '+ "/"

            ColumnAtomy.Order = CInt("0" + Me.FConfig("SITE_COLUMN_TWITTER_ORDER").Value)
            ColumnAtomy.Id = "twitter"
            ColumnAtomy.Name = Me.FConfig("SITE_COLUMN_TWITTER_NAME").Value
            ColumnAtomy.Url = Me.FConfig("SITE_COLUMN_TWITTER_URL").Value
            ColumnAtomy.Url = ColumnAtomy.Url '+ "/"

            ColumnBookmark.Order = CInt("0" + Me.FConfig("SITE_COLUMN_BOOKMARK_ORDER").Value)
            ColumnBookmark.Id = "bookmark"
            ColumnBookmark.Name = Me.FConfig("SITE_COLUMN_BOOKMARK_NAME").Value
            ColumnBookmark.Url = Me.FConfig("SITE_COLUMN_BOOKMARK_URL").Value
            ColumnBookmark.Url = ColumnBookmark.Url '+ "/"

            ColumnGallery.Order = CInt("0" + Me.FConfig("SITE_COLUMN_GALLERY_ORDER").Value)
            ColumnGallery.Id = "gallery"
            ColumnGallery.Name = Me.FConfig("SITE_COLUMN_GALLERY_NAME").Value
            ColumnGallery.Url = Me.FConfig("SITE_COLUMN_GALLERY_URL").Value
            ColumnGallery.Url = ColumnGallery.Url '+ "/"

            ColumnGuestBook.Order = CInt("0" + Me.FConfig("SITE_COLUMN_GUESTBOOK_ORDER").Value)
            ColumnGuestBook.Id = "guestbook"
            ColumnGuestBook.Name = Me.FConfig("SITE_COLUMN_GUESTBOOK_NAME").Value
            ColumnGuestBook.Url = Me.FConfig("SITE_COLUMN_GUESTBOOK_URL").Value
            ColumnGuestBook.Url = ColumnGuestBook.Url '+ "/"

            ColumnShare.Order = CInt("0" + Me.FConfig("SITE_COLUMN_SHARE_ORDER").Value)
            ColumnShare.Id = "share"
            ColumnShare.Name = Me.FConfig("SITE_COLUMN_SHARE_NAME").Value
            ColumnShare.Url = Me.FConfig("SITE_COLUMN_SHARE_URL").Value
            ColumnShare.Url = ColumnShare.Url '+ "/"


            Columns = New System.Collections.Generic.Dictionary(Of String, Column)

            Columns.Add(ColumnIndex.Id, ColumnIndex)
            Columns.Add(ColumnBlog.Id, ColumnBlog)
            Columns.Add(ColumnAtomy.Id, ColumnAtomy)
            Columns.Add(ColumnBookmark.Id, ColumnBookmark)
            Columns.Add(ColumnGallery.Id, ColumnGallery)
            Columns.Add(ColumnShare.Id, ColumnShare)
            Columns.Add(ColumnGuestBook.Id, ColumnGuestBook)

            Title = Me.FConfig("SITE_TITLE").Value
            SubTitle = Me.FConfig("SITE_SUBTITLE").Value
            Host = Me.FConfig("SITE_HOST").Value
            Template = Me.FConfig("SITE_TEMPLATE").Value

            Return FConfig

        End Get
    End Property


End Class
