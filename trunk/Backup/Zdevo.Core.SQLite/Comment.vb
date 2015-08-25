Public Class Comment

    Inherits Core.Comment

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

                wr.WriteStartElement("comment")

                wr.WriteElementString("id", Xml.XmlConvert.ToString(Me.ID))
                wr.WriteElementString("guid", Xml.XmlConvert.ToString(Me.GUID))
                wr.WriteElementString("url", Me.Url)
                wr.WriteElementString("name", Me.Name)
                wr.WriteElementString("content", Me.Content)
                wr.WriteElementString("email", Me.Email)
                wr.WriteElementString("homepage", Me.HomePage)
                'wr.WriteElementString("posttime", Xml.XmlConvert.ToString(Me.CreateTime, Xml.XmlDateTimeSerializationMode.Local))
                wr.WriteElementString("postdatetime", Me.CreateTime.ToString(Me.Container.Config("SITE_DATETIME_FORMAT").Value))
                wr.WriteElementString("postdate", Me.CreateTime.ToString(Me.Container.Config("SITE_DATE_FORMAT").Value))
                wr.WriteElementString("posttime", Me.CreateTime.ToString(Me.Container.Config("SITE_TIME_FORMAT").Value))

                wr.WriteEndElement()

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

            PathRegexConfig("{%CommentGUID%}").Value = Me.GUID.ToString
            'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

            Return Common.Functions.Current.GetUrlbyRegex(Me.Container.ActionConfig("xmlrpc_single_comment2page").Value, PathRegexConfig)
        End Get
    End Property

End Class
