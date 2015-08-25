Public Class Twitter

    Inherits Core.Post

    Private CommentList As CommentList
    Public Overridable Sub GetComments(Optional ByVal Page As Integer = 1)

        Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone

        PathRegexConfig("{%SiteName%}").Value = Me.Container.Sites(Me.SiteGUID).Name
        PathRegexConfig("{%Year%}").Value = Me.CreateTime.Year.ToString
        PathRegexConfig("{%Month%}").Value = Me.CreateTime.Month.ToString
        PathRegexConfig("{%Day%}").Value = Me.CreateTime.Day.ToString
        PathRegexConfig("{%PostID%}").Value = Me.ID.ToString
        PathRegexConfig("{%PostGUID%}").Value = Me.GUID.ToString
        'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

        CommentList = Me.Container.GetCommentList

        CommentList.List(New String() {"Page", "PageSize", "UrlRegex", "PostGUID", "PathRegexConfig"}, New Object() {Page, Me.Container.Config("SITE_MSG_COUNT").Value, Me.Container.ActionConfig("xmlrpc_getcomment").Value, Me.GUID, PathRegexConfig})

    End Sub

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

                wr.WriteStartElement("twitter")

                wr.WriteElementString("id", Xml.XmlConvert.ToString(Me.ID))
                wr.WriteElementString("guid", Xml.XmlConvert.ToString(Me.GUID))
                wr.WriteElementString("url", Me.Url)
                wr.WriteElementString("title", Me.Name)
                wr.WriteElementString("intro", Me.Intro)
                wr.WriteElementString("content", Me.Content)
                'wr.WriteElementString("posttime", Xml.XmlConvert.ToString(Me.CreateTime, Xml.XmlDateTimeSerializationMode.Local))
                wr.WriteElementString("postdatetime", Me.CreateTime.ToString(Me.Container.Config("SITE_DATETIME_FORMAT").Value))
                wr.WriteElementString("postdate", Me.CreateTime.ToString(Me.Container.Config("SITE_DATE_FORMAT").Value))
                wr.WriteElementString("posttime", Me.CreateTime.ToString(Me.Container.Config("SITE_TIME_FORMAT").Value))

                wr.WriteElementString("spandays", System.DateTime.Now.Subtract(Me.CreateTime).Days.ToString)
                wr.WriteElementString("spanhours", System.DateTime.Now.Subtract(Me.CreateTime).Hours.ToString)
                wr.WriteElementString("spanminutes", System.DateTime.Now.Subtract(Me.CreateTime).Minutes.ToString)

                'wr.WriteElementString("year", Me.CreateTime.Year.ToString)
                'wr.WriteElementString("month", Me.CreateTime.Month.ToString)
                'wr.WriteElementString("day", Me.CreateTime.Day.ToString)
                'wr.WriteElementString("hour", Me.CreateTime.Hour.ToString)
                'wr.WriteElementString("minute", Me.CreateTime.Minute.ToString)
                'wr.WriteElementString("second", Me.CreateTime.Second.ToString)

                wr.WriteElementString("source", Me.Source)
                wr.WriteElementString("link", Me.Link)

                wr.WriteElementString("viewnums", Xml.XmlConvert.ToString(Me.ViewNums))
                wr.WriteElementString("commentnums", Xml.XmlConvert.ToString(Me.CommentNums))
                wr.WriteElementString("isclose", Xml.XmlConvert.ToString(Me.IsClose))
                wr.WriteElementString("isprivate", Xml.XmlConvert.ToString(Me.IsPrivate))
                If Me.CategoryGUID <> GUID.Empty Then
                    wr.WriteRaw(Container.Catalogs(Me.CategoryGUID).NodeString)
                End If
                wr.WriteRaw(Container.Users(Me.UserGUID).NodeString)
                wr.WriteElementString("getcommenturl", Me.GetCommentUrl)
                wr.WriteElementString("postcommenturl", Me.PostCommentUrl)
                wr.WriteElementString("delcommenturl", Me.DelCommentUrl)
                wr.WriteStartElement("comments")

                If CommentList IsNot Nothing Then
                    wr.WriteRaw(CommentList.PageBar.NodeString)
                    'For Each Comment As Comment In CommentList.Items
                    '    wr.WriteRaw(Comment.NodeString)
                    'Next
                    For i As Integer = CommentList.Items.Count - 1 To 0 Step -1
                        wr.WriteRaw(CommentList.Items(i).NodeString)
                    Next
                End If

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

            PathRegexConfig("{%SiteName%}").Value = Me.Container.Sites(Me.SiteGUID).Name
            PathRegexConfig("{%Year%}").Value = Me.CreateTime.Year.ToString
            PathRegexConfig("{%Month%}").Value = Me.CreateTime.Month.ToString
            PathRegexConfig("{%Day%}").Value = Me.CreateTime.Day.ToString
            PathRegexConfig("{%PostID%}").Value = Me.ID.ToString
            PathRegexConfig("{%PostGUID%}").Value = Me.GUID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("twitter_single").Value, PathRegexConfig)
        End Get
    End Property

    Public Overridable ReadOnly Property PostCommentUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone

            PathRegexConfig("{%SiteName%}").Value = Me.Container.Sites(Me.SiteGUID).Name
            PathRegexConfig("{%Year%}").Value = Me.CreateTime.Year.ToString
            PathRegexConfig("{%Month%}").Value = Me.CreateTime.Month.ToString
            PathRegexConfig("{%Day%}").Value = Me.CreateTime.Day.ToString
            PathRegexConfig("{%PostID%}").Value = Me.ID.ToString
            PathRegexConfig("{%PostGUID%}").Value = Me.GUID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_postcomment").Value, PathRegexConfig)
        End Get
    End Property

    Public Overridable ReadOnly Property GetCommentUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone

            PathRegexConfig("{%SiteName%}").Value = Me.Container.Sites(Me.SiteGUID).Name
            PathRegexConfig("{%Year%}").Value = Me.CreateTime.Year.ToString
            PathRegexConfig("{%Month%}").Value = Me.CreateTime.Month.ToString
            PathRegexConfig("{%Day%}").Value = Me.CreateTime.Day.ToString
            PathRegexConfig("{%PostID%}").Value = Me.ID.ToString
            PathRegexConfig("{%PostGUID%}").Value = Me.GUID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_getcomment").Value, PathRegexConfig)
        End Get
    End Property


    Public Overridable ReadOnly Property DelCommentUrl() As String
        Get
            Dim PathRegexConfig As Common.ItemConfig(Of Common.Item) = Me.Container.ActionSplitConfig.Clone

            PathRegexConfig("{%SiteName%}").Value = Me.Container.Sites(Me.SiteGUID).Name
            PathRegexConfig("{%Year%}").Value = Me.CreateTime.Year.ToString
            PathRegexConfig("{%Month%}").Value = Me.CreateTime.Month.ToString
            PathRegexConfig("{%Day%}").Value = Me.CreateTime.Day.ToString
            PathRegexConfig("{%PostID%}").Value = Me.ID.ToString
            PathRegexConfig("{%PostGUID%}").Value = Me.GUID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_delcomment").Value, PathRegexConfig)
        End Get
    End Property


    Public Overrides Property Type() As Core.PostType
        Get
            Return Core.PostType.Twitter
        End Get
        Set(ByVal value As Core.PostType)

        End Set
    End Property


    Public Overridable Property Link() As String
        Get
            Return Note
        End Get
        Set(ByVal value As String)
            Note = value
        End Set
    End Property

End Class
