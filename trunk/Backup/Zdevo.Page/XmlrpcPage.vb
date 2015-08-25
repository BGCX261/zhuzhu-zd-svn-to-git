Public Class XmlrpcPage

    Inherits Zdevo.Page.BasePage

    Public Overridable Function RespondError(ByVal faultCode As String, ByVal faultString As String) As String

        Dim strXML As String = ""
        Dim strError As String = ""

        strXML = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><fault><value><struct><member><name>faultCode</name><value><int>$1</int></value></member><member><name>faultString</name><value><string>$2</string></value></member></struct></value></fault></methodResponse>"

        strError = strXML

        strError = Replace(strError, "$1", Zdevo.Common.Functions.Current.XmlEncode(faultCode))
        strError = Replace(strError, "$2", Zdevo.Common.Functions.Current.XmlEncode(faultString))

        Return strError

    End Function


    Public Overridable Function blogger_getUsersBlogs(ByVal UserName As String, ByVal PassWord As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><array><data><value><struct><member><name>url</name><value><string>$1</string></value></member><member><name>blogid</name><value><string>$2</string></value></member><member><name>blogName</name><value><string>$3</string></value></member></struct></value></data></array></value></param></params></methodResponse>"

            strXML = Replace(strXML, "$1", Zdevo.Common.Functions.Current.XmlEncode(Container.Sites(User.SiteGUID).Url.ToString))
            strXML = Replace(strXML, "$2", Zdevo.Common.Functions.Current.XmlEncode(Container.Sites(User.SiteGUID).GUID.ToString))
            strXML = Replace(strXML, "$3", Zdevo.Common.Functions.Current.XmlEncode(Container.Sites(User.SiteGUID).Name.ToString))

            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function

    Public Overridable Function metaWeblog_getCategories(ByVal UserName As String, ByVal PassWord As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><array><data><value>$1</value></data></array></value></param></params></methodResponse>"
            Dim strCategoryInfo As String = "<struct><member><name>description</name><value><string>$1</string></value></member><member><name>httpUrl</name><value><string>$2</string></value></member><member><name>rssUrl</name><value><string>$3</string></value></member><member><name>title</name><value><string>$4</string></value></member><member><name>categoryid</name><value><string>$5</string></value></member></struct>"



            Dim strCategories As String = ""
            For Each Category As Zdevo.Core.SQLite.Catalog In Container.Catalogs()
                Dim s As String = strCategoryInfo
                s = Replace(s, "$1", Zdevo.Common.Functions.Current.XmlEncode(Category.Name))
                s = Replace(s, "$2", Zdevo.Common.Functions.Current.XmlEncode(Category.Url))
                s = Replace(s, "$3", Zdevo.Common.Functions.Current.XmlEncode(Category.Url))
                s = Replace(s, "$4", Zdevo.Common.Functions.Current.XmlEncode(Category.Name))
                s = Replace(s, "$5", Zdevo.Common.Functions.Current.XmlEncode(Category.ID.ToString))
                strCategories = strCategories & s
            Next

            strXML = Replace(strXML, "$1", strCategories)

            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function metaWeblog_getRecentPosts(ByVal UserName As String, ByVal PassWord As String, ByVal NumberOfPosts As Integer) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><array><data>$1</data></array></value></param></params></methodResponse>"
            Dim strPost As String = "<value><struct><member><name>title</name><value><string>$1</string></value></member><member><name>description</name><value><string>$2</string></value></member><member><name>dateCreated</name><value><dateTime.iso8601>$3</dateTime.iso8601></value></member>$4<member><name>postid</name><value><string>$5</string></value></member><member><name>userid</name><value><string>$6</string></value></member><member><name>link</name><value><string>$7</string></value></member><member><name>mt_excerpt</name><value><string>$8</string></value></member><member><name>mt_text_more</name><value><string></string></value></member><member><name>mt_allow_comments</name><value><int>$9</int></value></member><member><name>mt_allow_pings</name><value><int></int></value></member><member><name>mt_convert_breaks</name><value><string></string></value></member><member><name>mt_keywords</name><value><string>$10</string></value></member></struct></value>"
            Dim strPostCatalog As String = "<member><name>categories</name><value><array><data><value><string>$1</string></value></data></array></value></member>"
            Dim strPostCatalog_None As String = "<member><name>categories</name><value><array><data></data></array></value></member>"
            Dim strRecentPosts As String = ""


            Dim postlist As Zdevo.Core.SQLite.ArticleList = Container.GetArticleList

            If postlist.List(New String() {"Page", "PageSize", "UrlRegex"}, New Object() {1, IIf(NumberOfPosts > CInt(Container.Config("SITE_BLOG_LIST_COUNT").Value), CInt(Container.Config("SITE_BLOG_LIST_COUNT").Value), NumberOfPosts), Container.ActionConfig("blog_list").Value}) Then

                For Each post As Zdevo.Core.SQLite.Article In postlist.Items
                    Dim s As String = strPost
                    s = Replace(s, "$8", Zdevo.Common.Functions.Current.XmlEncode(post.Intro))
                    s = Replace(s, "$9", Zdevo.Common.Functions.Current.XmlEncode(CInt(Not post.IsClose).ToString))
                    s = Replace(s, "$10", Zdevo.Common.Functions.Current.XmlEncode(post.JoinTags))

                    s = Replace(s, "$1", Zdevo.Common.Functions.Current.XmlEncode(post.Name))
                    s = Replace(s, "$2", Zdevo.Common.Functions.Current.XmlEncode(post.Content))
                    s = Replace(s, "$3", Zdevo.Common.Functions.Current.XmlEncode(post.CreateTime.ToUniversalTime.ToString("yyyyMMddTHH:mm:ss")))
                    If post.CategoryGUID <> Guid.Empty Then
                        strPostCatalog = strPostCatalog.Replace("$1", Zdevo.Common.Functions.Current.XmlEncode(Container.Catalogs(post.CategoryGUID).Name))
                        s = Replace(s, "$4", strPostCatalog)
                    Else
                        s = Replace(s, "$4", strPostCatalog_None)
                    End If
                    s = Replace(s, "$5", Zdevo.Common.Functions.Current.XmlEncode(post.GUID.ToString))
                    s = Replace(s, "$6", Zdevo.Common.Functions.Current.XmlEncode(post.UserGUID.ToString))
                    s = Replace(s, "$7", Zdevo.Common.Functions.Current.XmlEncode(post.Url))

                    strRecentPosts = strRecentPosts & s
                Next
            End If

            strXML = Replace(strXML, "$1", strRecentPosts)

            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function

    Public Overridable Function metaWeblog_newPost(ByVal UserName As String, ByVal PassWord As String, ByVal StructPost As String, ByVal Publish As Boolean) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim objXmlFile As New System.Xml.XmlDocument
            objXmlFile.LoadXml(StructPost)

            Dim post As Zdevo.Core.SQLite.Article = Container.NewArticle

            post.GUID = Guid.NewGuid
            post.UserGUID = User.GUID
            post.SiteGUID = Container.Sites(User.SiteGUID).GUID
            post.Name = objXmlFile.DocumentElement.SelectSingleNode("member[name=""title""]/value/string").InnerText
            post.Content = objXmlFile.DocumentElement.SelectSingleNode("member[name=""description""]/value/string").InnerText
            post.Type = Core.PostType.Article

            'Dim strCategory As String = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_allow_comments""]/value/array/data/value[1]/string").InnerText

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_allow_comments""]/value/int").Count > 0 Then
                post.IsClose = Not CBool(objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_allow_comments""]/value/int").InnerText)
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_excerpt""]/value/string").Count > 0 Then
                post.Intro = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_excerpt""]/value/string").InnerText
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_basename""]/value/string").Count > 0 Then
                post.AliasName = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_basename""]/value/string").InnerText
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""dateCreated""]/value/dateTime.iso8601").Count > 0 Then
                post.CreateTime = System.DateTime.ParseExact(objXmlFile.DocumentElement.SelectSingleNode("member[name=""dateCreated""]/value/dateTime.iso8601").InnerText, "yyyyMMddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AssumeUniversal)
                post.ModifiTime = System.DateTime.ParseExact(objXmlFile.DocumentElement.SelectSingleNode("member[name=""dateCreated""]/value/dateTime.iso8601").InnerText, "yyyyMMddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AssumeUniversal)
            Else
                post.CreateTime = System.DateTime.Now
                post.ModifiTime = System.DateTime.Now
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_keywords""]/value/string").Count > 0 Then
                post.Tags.Clear()
                Dim strTags As String = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_keywords""]/value/string").InnerText
                For Each s As String In strTags.Split(" ".ToCharArray)
                    If s <> String.Empty Then
                        post.Tags.Add(Me.Container.Tags(s).GUID)
                    End If
                Next
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""categories""]/value/array/data/value[1]/string").Count > 0 Then
                Dim strCategory As String = objXmlFile.DocumentElement.SelectSingleNode("member[name=""categories""]/value/array/data/value[1]/string").InnerText
                post.CategoryGUID = Me.Container.Catalogs(strCategory).GUID
            Else
                post.CategoryGUID = Guid.Empty
            End If

            post.IsDraft = Not Publish

            If Container.GetArticleList.Insert(post) = True Then

            End If

            strXML = Replace(strXML, "$1", post.GUID.ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function metaWeblog_getPost(ByVal UserName As String, ByVal PassWord As String, ByVal PostGuid As Guid) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value>$1</value></param></params></methodResponse>"
            Dim strPost As String = "<struct><member><name>title</name><value><string>$1</string></value></member><member><name>description</name><value><string>$2</string></value></member><member><name>dateCreated</name><value><dateTime.iso8601>$3</dateTime.iso8601></value></member>$4<member><name>postid</name><value><string>$5</string></value></member><member><name>userid</name><value><string>$6</string></value></member><member><name>link</name><value><string>$7</string></value></member><member><name>mt_excerpt</name><value><string>$8</string></value></member><member><name>mt_text_more</name><value><string></string></value></member><member><name>mt_allow_comments</name><value><int>$9</int></value></member><member><name>mt_allow_pings</name><value><int></int></value></member><member><name>mt_convert_breaks</name><value><string></string></value></member><member><name>mt_keywords</name><value><string>$10</string></value></member></struct>"
            Dim strPostCatalog As String = "<member><name>categories</name><value><array><data><value><string>$1</string></value></data></array></value></member>"
            Dim strPostCatalog_None As String = "<member><name>categories</name><value><array><data></data></array></value></member>"
            Dim post As Zdevo.Core.SQLite.Article = Container.GetArticleList.Load(PostGuid)

            Dim s As String = strPost

            s = Replace(s, "$8", Zdevo.Common.Functions.Current.XmlEncode(post.Intro))
            s = Replace(s, "$9", Zdevo.Common.Functions.Current.XmlEncode(CInt(Not post.IsClose).ToString))
            s = Replace(s, "$10", Zdevo.Common.Functions.Current.XmlEncode(post.JoinTags))

            s = Replace(s, "$1", Zdevo.Common.Functions.Current.XmlEncode(post.Name))
            s = Replace(s, "$2", Zdevo.Common.Functions.Current.XmlEncode(post.Content))
            s = Replace(s, "$3", Zdevo.Common.Functions.Current.XmlEncode(post.CreateTime.ToUniversalTime.ToString("yyyyMMddTHH:mm:ss")))
            If post.CategoryGUID <> Guid.Empty Then
                strPostCatalog = strPostCatalog.Replace("$1", Zdevo.Common.Functions.Current.XmlEncode(Container.Catalogs(post.CategoryGUID).Name))
                s = Replace(s, "$4", strPostCatalog)
            Else
                s = Replace(s, "$4", strPostCatalog_None)
            End If
            s = Replace(s, "$5", Zdevo.Common.Functions.Current.XmlEncode(post.GUID.ToString))
            s = Replace(s, "$6", Zdevo.Common.Functions.Current.XmlEncode(post.UserGUID.ToString))
            s = Replace(s, "$7", Zdevo.Common.Functions.Current.XmlEncode(post.Url))

            strXML = Replace(strXML, "$1", s)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function metaWeblog_editPost(ByVal UserName As String, ByVal PassWord As String, ByVal PostGuid As Guid, ByVal StructPost As String, ByVal Publish As Boolean) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim objXmlFile As New System.Xml.XmlDocument
            objXmlFile.LoadXml(StructPost)

            Dim post As Zdevo.Core.SQLite.Article = Container.GetArticleList.Load(PostGuid)

            post.Name = objXmlFile.DocumentElement.SelectSingleNode("member[name=""title""]/value/string").InnerText
            post.Content = objXmlFile.DocumentElement.SelectSingleNode("member[name=""description""]/value/string").InnerText


            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_allow_comments""]/value/int").Count > 0 Then
                post.IsClose = Not CBool(objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_allow_comments""]/value/int").InnerText)
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_excerpt""]/value/string").Count > 0 Then
                post.Intro = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_excerpt""]/value/string").InnerText
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_basename""]/value/string").Count > 0 Then
                post.AliasName = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_basename""]/value/string").InnerText
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""dateCreated""]/value/dateTime.iso8601").Count > 0 Then
                post.CreateTime = System.DateTime.ParseExact(objXmlFile.DocumentElement.SelectSingleNode("member[name=""dateCreated""]/value/dateTime.iso8601").InnerText, "yyyyMMddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AssumeUniversal)
                post.ModifiTime = System.DateTime.ParseExact(objXmlFile.DocumentElement.SelectSingleNode("member[name=""dateCreated""]/value/dateTime.iso8601").InnerText, "yyyyMMddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AssumeUniversal)
            Else
                post.ModifiTime = System.DateTime.Now
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""categories""]/value/array/data/value[1]/string").Count > 0 Then
                Dim strCategory As String = objXmlFile.DocumentElement.SelectSingleNode("member[name=""categories""]/value/array/data/value[1]/string").InnerText
                post.CategoryGUID = Me.Container.Catalogs(strCategory).GUID
            Else
                post.CategoryGUID = Guid.Empty
            End If

            If objXmlFile.DocumentElement.SelectNodes("member[name=""mt_keywords""]/value/string").Count > 0 Then
                post.Tags.Clear()
                Dim strTags As String = objXmlFile.DocumentElement.SelectSingleNode("member[name=""mt_keywords""]/value/string").InnerText
                For Each s As String In strTags.Split(" ".ToCharArray)
                    If s <> String.Empty Then
                        post.Tags.Add(Me.Container.Tags(s).GUID)
                    End If
                Next
            End If

            post.IsDraft = Not Publish

            If Container.GetArticleList.Update(post) = True Then

            End If

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function

    Public Overridable Function zdevo_newComment(ByVal UserName As String, ByVal PassWord As String, ByVal Guid As Guid, ByVal Name As String, ByVal Email As String, ByVal Homepage As String, ByVal Content As String, ByVal CommentUrl As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Name = Trim(Name).Replace(" ", "")
        Email = Trim(Email).Replace(" ", "")
        Homepage = Trim(Homepage).Replace(" ", "")
        Content = Trim(Content)

        Content = Zdevo.Common.Functions.Current.XmlEncode(Zdevo.Common.Functions.Current.HtmlRemove(Content))

        If Zdevo.Common.Functions.Current.CheckEmail(Email) = False Then
            Email = ""
        End If

        If Zdevo.Common.Functions.Current.CheckUrl(Homepage) = False Then
            Homepage = ""
        End If

        If Zdevo.Common.Functions.Current.CheckUserName(Name) = False Then
            System.Web.HttpContext.Current.Response.Write(RespondError("3", "Name error."))
            Exit Function
        End If

        If Name = String.Empty Then
            System.Web.HttpContext.Current.Response.Write(RespondError("3", "Name error."))
            Exit Function
        End If

        If Content = String.Empty Then
            System.Web.HttpContext.Current.Response.Write(RespondError("4", "Content error."))
            Exit Function
        End If


        Dim post As Zdevo.Core.SQLite.Article = Container.GetArticleList.Load(Guid)

        If post IsNot Nothing Then
            Dim comment As Zdevo.Core.SQLite.Comment = Container.NewComment

            comment.GUID = System.Guid.NewGuid
            comment.SiteGUID = post.SiteGUID
            comment.PostGUID = post.GUID
            comment.Content = "<p>" + Content.Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>") + "</p>"
            comment.Name = Name
            comment.Email = Email
            comment.HomePage = Homepage
            comment.CreateTime = System.DateTime.Now
            comment.ModifiTime = System.DateTime.Now
            comment.IP = System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")


            If Container.Users(Name) IsNot Nothing Then
                Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)
                If Me.Container.Verify(UserName, PassWord) = True Then
                    comment.Name = User.Name
                    comment.UserGUID = User.GUID
                Else
                    System.Web.HttpContext.Current.Response.Write(RespondError("6", "Login error."))
                    Return False
                End If
            End If

            Container.GetCommentList.Insert(comment)

            Return True

        Else
            System.Web.HttpContext.Current.Response.Write(RespondError("5", "Post no exist."))
            Exit Function
        End If


        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_newAtomy(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Content = Trim(Content)

            If Content = String.Empty Then
                System.Web.HttpContext.Current.Response.Write(RespondError("4", "Content error."))
                Exit Function
            End If

            Dim witter As Zdevo.Core.SQLite.Twitter = Container.NewTwitter

            witter.GUID = Guid.NewGuid
            witter.UserGUID = Container.User.GUID
            witter.SiteGUID = Container.Site.GUID
            witter.Name = Left(Content, 250)
            witter.Content = Content
            witter.CreateTime = System.DateTime.Now
            witter.ModifiTime = System.DateTime.Now
            witter.Source = "Zdevo.Tools"

            witter.CategoryGUID = Guid.Empty

            If Container.GetTwitterList.Insert(witter) = True Then

            End If

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function

    Public Overridable Function zdevo_editGuestBook(ByVal UserName As String, ByVal PassWord As String, ByVal Title As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Title = Trim(Title)
            Content = Trim(Content)

            If Title = String.Empty Then
                System.Web.HttpContext.Current.Response.Write(RespondError("5", "Title error."))
                Exit Function
            End If

            If Content = String.Empty Then
                System.Web.HttpContext.Current.Response.Write(RespondError("4", "Content error."))
                Exit Function
            End If


            Dim guestbooklist As Zdevo.Core.SQLite.GuestbookList = Container.GetGuestbookList
            guestbooklist.List(Nothing)

            If guestbooklist.Items.Count = 0 Then

                Dim guestbook As Zdevo.Core.SQLite.Guestbook = Container.NewGuestbook
                guestbook.GUID = Guid.NewGuid
                guestbook.SiteGUID = Container.Site.GUID
                guestbook.UserGUID = Container.User.GUID
                guestbook.Name = Title
                guestbook.Content = Content
                guestbook.CreateTime = System.DateTime.Now
                guestbook.ModifiTime = System.DateTime.Now
                guestbook.Type = Core.PostType.Guestbook

                guestbooklist.Insert(guestbook)

            Else

                Dim guestbook As Zdevo.Core.SQLite.Guestbook = guestbooklist.Items(0)
                guestbook.Name = Title
                guestbook.Content = Content
                guestbook.ModifiTime = System.DateTime.Now

                guestbooklist.Update(guestbook)

            End If


            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If


    End Function

    Public Overridable Function zdevo_newBookMark(ByVal UserName As String, ByVal PassWord As String, ByVal Title As String, ByVal Url As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Content = Trim(Content)

            If (Content = String.Empty) And (Title = String.Empty) Then
                System.Web.HttpContext.Current.Response.Write(RespondError("7", "Content or title error."))
                Exit Function
            End If

            Dim bookmark As Zdevo.Core.SQLite.Bookmark = Container.NewBookmark

            bookmark.GUID = Guid.NewGuid
            bookmark.UserGUID = Container.User.GUID
            bookmark.SiteGUID = Container.Site.GUID
            If Title = String.Empty Then
                bookmark.Name = Left(Zdevo.Common.Functions.Current.HtmlRemove(Content), 50)
            Else
                bookmark.Name = Left(Title, 50)
            End If
            If Content <> String.Empty Then
                bookmark.Content = "<p>" + Zdevo.Common.Functions.Current.XmlEncode(Content).Replace(vbCrLf, "<br/>") + "</p>"
            End If
            bookmark.CreateTime = System.DateTime.Now
            bookmark.ModifiTime = System.DateTime.Now
            bookmark.Link = Url

            bookmark.CategoryGUID = Guid.Empty

            If Container.GetBookmarkList.Insert(bookmark) = True Then

            End If

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function

    Public Overridable Function zdevo_editPicasa(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Dim nsmgr As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(x.NameTable)
            nsmgr.AddNamespace("atom", "http://www.w3.org/2005/Atom")

            Dim gallerys As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")

                Dim gallery As Zdevo.Core.SQLite.Gallery = Container.NewGallery

                gallery.GUID = Guid.NewGuid
                gallery.SiteGUID = Container.Site.GUID
                gallery.UserGUID = Container.User.GUID
                gallery.Type = Core.PostType.Gallery
                gallery.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                gallery.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("atom:updated", nsmgr).InnerText)

                'Zdevo.Common.Utility.Current.Trace.Write(System.DateTime.Parse(n.SelectSingleNode("atom:updated", nsmgr).InnerText).ToString)

                gallery.PermaLink = n.SelectSingleNode("guid").InnerText
                gallery.Link = n.SelectSingleNode("link").InnerText
                gallery.Name = n.SelectSingleNode("title").InnerText
                gallery.Content = n.SelectSingleNode("description").InnerText.Replace("\""", """")
                gallery.Source = "Picasa"

                gallerys.Add(gallery)

            Next

            Dim gallerysInsert As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            Dim gallerysUpdate As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            Dim gallerysDelete As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)

            Dim postlist As Zdevo.Core.SQLite.GalleryList = Container.GetGalleryList

            postlist.List(New String() {"Source"}, New Object() {"Picasa"})

            For Each g As Zdevo.Core.SQLite.Gallery In gallerys
                Dim bUpd As Boolean = False
                For Each p As Zdevo.Core.SQLite.Gallery In postlist.Items
                    If String.Compare(p.PermaLink, g.PermaLink) = 0 Then
                        bUpd = True
                        g.ID = p.ID
                        g.GUID = p.GUID
                        gallerysUpdate.Add(g)
                        Exit For
                    End If
                Next
                If bUpd = False Then
                    gallerysInsert.Add(g)
                End If
            Next

            'For Each g As Zdevo.Core.SQLite.Gallery In gallerysUpdate
            '    Zdevo.Common.Utility.Current.Trace.Write("gallerysUpdate" + g.Name)
            'Next

            'For Each g As Zdevo.Core.SQLite.Gallery In gallerysInsert
            '    Zdevo.Common.Utility.Current.Trace.Write("gallerysInsert" + g.Name)
            'Next

            Dim gallerylist As Zdevo.Core.SQLite.GalleryList = Container.GetGalleryList

            Container.BeginTransaction()
            For Each g As Zdevo.Core.SQLite.Gallery In gallerysInsert
                gallerylist.Insert(g)
            Next
            For Each g As Zdevo.Core.SQLite.Gallery In gallerysUpdate
                gallerylist.Update(g)
            Next
            Container.EndTransaction()

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_editFanfou(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Zdevo.Common.Utility.Current.Trace.Write(Content.Length.ToString)


            Dim witters As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Twitter)
            Dim wittersNew As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Twitter)
            Dim wittersUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Twitter)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")

                Dim w As Zdevo.Core.SQLite.Twitter = Container.NewTwitter

                w.GUID = Guid.NewGuid
                w.SiteGUID = Container.Site.GUID
                w.UserGUID = Container.User.GUID
                w.Type = Core.PostType.Twitter
                w.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                w.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)

                w.Name = n.SelectSingleNode("title").InnerText
                w.Content = n.SelectSingleNode("description").InnerText.Replace("target=""_blank""", "")
                w.Source = "Fanfou"
                w.Link = n.SelectSingleNode("link").InnerText

                witters.Add(w)

            Next


            Dim Witterlist As Zdevo.Core.SQLite.TwitterList = Me.Container.GetTwitterList

            Witterlist.List(New String() {"Source"}, New Object() {"Fanfou"})

            For Each w As Zdevo.Core.SQLite.Twitter In witters
                Dim n As Boolean = False
                For Each t As Zdevo.Core.SQLite.Twitter In Witterlist.Items
                    If String.Compare(w.Name, t.Name) = 0 Then
                        n = True
                        w.ID = t.ID
                        w.GUID = t.GUID
                    End If
                Next
                If n = False Then
                    wittersNew.Add(w)
                Else
                    wittersUpd.Add(w)
                End If
            Next

            Me.Container.BeginTransaction()
            For Each w As Zdevo.Core.SQLite.Twitter In wittersNew
                Witterlist.Insert(w)
            Next
            For Each w As Zdevo.Core.SQLite.Twitter In wittersUpd
                'Witterlist.Update(w)
            Next
            Me.Container.EndTransaction()

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_editFlickr(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Dim nsmgr As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(x.NameTable)
            nsmgr.AddNamespace("media", "http://search.yahoo.com/mrss/")

            'Dim s As String = ""
            Dim gallerys As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")

                Dim s As String = ""

                Dim gallery As Zdevo.Core.SQLite.Gallery = Me.Container.NewGallery

                Dim name As String = "" ' Zdevo.Common.Functions.Current.XmlEncode(n.SelectSingleNode("title").InnerText)
                Dim src As String = Zdevo.Common.Functions.Current.XmlEncode(n.SelectSingleNode("media:thumbnail", nsmgr).Attributes("url").Value)
                Dim img As String = "<img title=""$1"" alt=""$1""  src=""$2"" height=""75"" width=""75"" />"
                Dim href As String = Zdevo.Common.Functions.Current.XmlEncode(n.SelectSingleNode("link").InnerText)
                Dim a As String = "<span><a href=""$1"">$2</a></span>"

                img = img.Replace("$1", name)
                img = img.Replace("$2", src)
                a = a.Replace("$1", href)
                a = a.Replace("$2", img)
                s = s + a
                s = s.Replace("farm1.", "")
                s = s.Replace("farm2.", "")

                gallery.GUID = Guid.NewGuid
                gallery.SiteGUID = Container.Site.GUID
                gallery.UserGUID = Container.User.GUID
                gallery.Type = Core.PostType.Gallery
                gallery.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                gallery.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)

                'Zdevo.Common.Utility.Current.Trace.Write(System.DateTime.Parse(n.SelectSingleNode("atom:updated", nsmgr).InnerText).ToString)

                gallery.PermaLink = n.SelectSingleNode("guid").InnerText
                gallery.Link = n.SelectSingleNode("link").InnerText
                gallery.Name = n.SelectSingleNode("title").InnerText
                gallery.Content = n.SelectSingleNode("description").InnerText.Replace("farm1.", "").Replace("farm2.", "")

                gallery.Intro = s
                gallery.Source = "Flickr"

                gallerys.Add(gallery)

            Next



            Zdevo.Common.Utility.Current.Trace.Write(gallerys.Count.ToString)

            Dim gallerysUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            Dim gallerysIns As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)

            Dim gallerylist As Zdevo.Core.SQLite.GalleryList = Container.GetGalleryList

            gallerylist.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, 20, "Flickr"})

            For Each g1 As Zdevo.Core.SQLite.Gallery In gallerys
                Dim bUpd As Boolean = False
                For Each g2 As Zdevo.Core.SQLite.Gallery In gallerylist.Items
                    If String.Compare(g2.PermaLink, g1.PermaLink) = 0 Then
                        bUpd = True
                        g1.ID = g2.ID
                        g1.GUID = g2.GUID
                        gallerysUpd.Add(g1)
                        Exit For
                    End If
                Next
                If bUpd = False Then
                    gallerysIns.Add(g1)
                End If
            Next


            Container.BeginTransaction()
            For Each bm As Zdevo.Core.SQLite.Gallery In gallerysIns
                gallerylist.Insert(bm)
            Next
            For Each bm As Zdevo.Core.SQLite.Gallery In gallerysUpd
                gallerylist.Update(bm)
            Next
            Container.EndTransaction()


            'If gallerylist.Items.Count = 0 Then
            '    'gallery = Me.Container.NewGallery
            '    'gallery.GUID = Guid.NewGuid
            '    'gallery.Name = x.DocumentElement.SelectSingleNode("//title").InnerText
            '    'gallery.SiteGUID = Container.Site.GUID
            '    'gallery.UserGUID = Container.User.GUID
            '    'gallery.Type = Core.PostType.Gallery
            '    'gallery.CreateTime = System.DateTime.Parse(x.DocumentElement.SelectSingleNode("//pubDate").InnerText)
            '    'gallery.ModifiTime = gallery.CreateTime
            '    'gallery.Content = String.Copy(s)
            '    'gallery.Source = "Flickr"
            'Else
            '    'gallery = gallerylist.Items(0)
            '    'gallery.Name = x.DocumentElement.SelectSingleNode("//title").InnerText
            '    'gallery.ModifiTime = System.DateTime.Now
            '    'gallery.Content = String.Copy(s)
            'End If

            'If gallery.ID = 0 Then
            '    gallerylist.Insert(gallery)
            'Else
            '    gallerylist.Update(gallery)
            'End If


            'For Each g As Zdevo.Core.SQLite.Gallery In gallerysUpdate
            '    Zdevo.Common.Utility.Current.Trace.Write("gallerysUpdate" + g.Name)
            'Next

            'For Each g As Zdevo.Core.SQLite.Gallery In gallerysInsert
            '    Zdevo.Common.Utility.Current.Trace.Write("gallerysInsert" + g.Name)
            'Next




            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function



    Public Overridable Function zdevo_editYupoo(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Dim nsmgr As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(x.NameTable)
            nsmgr.AddNamespace("media", "http://search.yahoo.com/mrss")

            'Dim s As String = ""
            Dim gallerys As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")

                Dim s As String = ""

                Dim gallery As Zdevo.Core.SQLite.Gallery = Me.Container.NewGallery

                Dim name As String = "" ' Zdevo.Common.Functions.Current.XmlEncode(n.SelectSingleNode("title").InnerText)
                Dim src As String = Zdevo.Common.Functions.Current.XmlEncode(n.SelectSingleNode("media:thumbnail", nsmgr).Attributes("url").Value)
                Dim img As String = "<img title=""$1"" alt=""$1""  src=""$2"" height=""75"" width=""75"" />"
                Dim href As String = Zdevo.Common.Functions.Current.XmlEncode(n.SelectSingleNode("link").InnerText)
                Dim a As String = "<span><a href=""$1"">$2</a></span>"

                img = img.Replace("$1", name)
                img = img.Replace("$2", src)
                a = a.Replace("$1", href)
                a = a.Replace("$2", img)
                s = s + a

                gallery.GUID = Guid.NewGuid
                gallery.SiteGUID = Container.Site.GUID
                gallery.UserGUID = Container.User.GUID
                gallery.Type = Core.PostType.Gallery
                gallery.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText).AddHours(8)
                gallery.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText).AddHours(8)

                'Zdevo.Common.Utility.Current.Trace.Write(System.DateTime.Parse(n.SelectSingleNode("atom:updated", nsmgr).InnerText).ToString)

                gallery.PermaLink = n.SelectSingleNode("guid").InnerText
                gallery.Link = n.SelectSingleNode("link").InnerText
                gallery.Name = n.SelectSingleNode("title").InnerText
                gallery.Content = n.SelectSingleNode("description").InnerText
                gallery.Intro = s
                gallery.Source = "Yupoo"

                gallerys.Add(gallery)

            Next



            Zdevo.Common.Utility.Current.Trace.Write(gallerys.Count.ToString)

            Dim gallerysUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)
            Dim gallerysIns As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Gallery)

            Dim gallerylist As Zdevo.Core.SQLite.GalleryList = Container.GetGalleryList

            gallerylist.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, 20, "Yupoo"})

            For Each g1 As Zdevo.Core.SQLite.Gallery In gallerys
                Dim bUpd As Boolean = False
                For Each g2 As Zdevo.Core.SQLite.Gallery In gallerylist.Items
                    If String.Compare(g2.PermaLink, g1.PermaLink) = 0 Then
                        bUpd = True
                        g1.ID = g2.ID
                        g1.GUID = g2.GUID
                        gallerysUpd.Add(g1)
                        Exit For
                    End If
                Next
                If bUpd = False Then
                    gallerysIns.Add(g1)
                End If
            Next


            Container.BeginTransaction()
            For Each bm As Zdevo.Core.SQLite.Gallery In gallerysIns
                gallerylist.Insert(bm)
            Next
            For Each bm As Zdevo.Core.SQLite.Gallery In gallerysUpd
                gallerylist.Update(bm)
            Next
            Container.EndTransaction()


            'If gallerylist.Items.Count = 0 Then
            '    'gallery = Me.Container.NewGallery
            '    'gallery.GUID = Guid.NewGuid
            '    'gallery.Name = x.DocumentElement.SelectSingleNode("//title").InnerText
            '    'gallery.SiteGUID = Container.Site.GUID
            '    'gallery.UserGUID = Container.User.GUID
            '    'gallery.Type = Core.PostType.Gallery
            '    'gallery.CreateTime = System.DateTime.Parse(x.DocumentElement.SelectSingleNode("//pubDate").InnerText)
            '    'gallery.ModifiTime = gallery.CreateTime
            '    'gallery.Content = String.Copy(s)
            '    'gallery.Source = "Flickr"
            'Else
            '    'gallery = gallerylist.Items(0)
            '    'gallery.Name = x.DocumentElement.SelectSingleNode("//title").InnerText
            '    'gallery.ModifiTime = System.DateTime.Now
            '    'gallery.Content = String.Copy(s)
            'End If

            'If gallery.ID = 0 Then
            '    gallerylist.Insert(gallery)
            'Else
            '    gallerylist.Update(gallery)
            'End If


            'For Each g As Zdevo.Core.SQLite.Gallery In gallerysUpdate
            '    Zdevo.Common.Utility.Current.Trace.Write("gallerysUpdate" + g.Name)
            'Next

            'For Each g As Zdevo.Core.SQLite.Gallery In gallerysInsert
            '    Zdevo.Common.Utility.Current.Trace.Write("gallerysInsert" + g.Name)
            'Next




            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function



    Public Overridable Function zdevo_editDelicious(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Dim nsmgr As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(x.NameTable)
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/")
            nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#")
            nsmgr.AddNamespace("rss", "http://purl.org/rss/1.0/")

            Dim bookmarks As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("/rdf:RDF/rss:item", nsmgr)
                Dim bookmark As Zdevo.Core.SQLite.Bookmark = Me.Container.NewBookmark

                Zdevo.Common.Utility.Current.Trace.Write(n.SelectSingleNode("dc:subject", nsmgr).InnerText)

                Dim Title As String = n.SelectSingleNode("rss:title", nsmgr).InnerText
                Dim Intro As String = n.SelectSingleNode("rss:description", nsmgr).InnerText
                Dim Url As String = n.SelectSingleNode("rss:link", nsmgr).InnerText

                Dim Tags As String = n.SelectSingleNode("dc:subject", nsmgr).InnerText

                For Each s As String In Tags.Split(" ".ToCharArray)
                    If s <> String.Empty Then
                        bookmark.Tags.Add(Me.Container.Tags(s).GUID)
                    End If
                Next

                bookmark.GUID = Guid.NewGuid
                bookmark.UserGUID = Container.User.GUID
                bookmark.SiteGUID = Container.Site.GUID

                bookmark.Name = Title

                If Intro <> String.Empty Then
                    bookmark.Content = "<p>" + Intro.Replace(vbCrLf, "<br/>") + "</p>"
                End If
                bookmark.CreateTime = System.DateTime.Parse(n.SelectSingleNode("dc:date", nsmgr).InnerText)
                bookmark.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("dc:date", nsmgr).InnerText)
                bookmark.Link = Url

                bookmark.CategoryGUID = Guid.Empty

                bookmark.Source = "Delicious"

                bookmarks.Add(bookmark)

            Next

            Dim bookmarksUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)
            Dim bookmarksIns As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)


            Dim bookmarklist As Zdevo.Core.SQLite.BookmarkList = Container.GetBookmarkList

            bookmarklist.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, bookmarks.Count, "Delicious"})

            For Each bm1 As Zdevo.Core.SQLite.Bookmark In bookmarks
                Dim bUpd As Boolean = False
                For Each bm2 As Zdevo.Core.SQLite.Bookmark In bookmarklist.Items
                    If String.Compare(bm2.Link, bm1.Link) = 0 Then
                        bUpd = True
                        bm1.ID = bm2.ID
                        bm1.GUID = bm2.GUID
                        bookmarksUpd.Add(bm1)
                        Exit For
                    End If
                Next
                If bUpd = False Then
                    bookmarksIns.Add(bm1)
                End If
            Next

            Container.BeginTransaction()
            For Each bm As Zdevo.Core.SQLite.Bookmark In bookmarksIns
                bookmarklist.Insert(bm)
            Next
            For Each bm As Zdevo.Core.SQLite.Bookmark In bookmarksUpd
                bookmarklist.Update(bm)
            Next
            Container.EndTransaction()

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_editTwitter(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Zdevo.Common.Utility.Current.Trace.Write(Content.Length.ToString)

            Dim witters As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Twitter)
            Dim wittersNew As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Twitter)
            Dim wittersUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Twitter)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")

                Dim w As Zdevo.Core.SQLite.Twitter = Container.NewTwitter

                w.GUID = Guid.NewGuid
                w.SiteGUID = Container.Site.GUID
                w.UserGUID = Container.User.GUID
                w.Type = Core.PostType.Twitter
                w.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                w.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)

                w.Name = n.SelectSingleNode("title").InnerText
                w.Content = n.SelectSingleNode("description").InnerText
                w.Source = "Twitter"
                w.Link = n.SelectSingleNode("link").InnerText

                witters.Add(w)

            Next


            Dim Witterlist As Zdevo.Core.SQLite.TwitterList = Me.Container.GetTwitterList

            Witterlist.List(New String() {"Source"}, New Object() {"Twitter"})

            For Each w As Zdevo.Core.SQLite.Twitter In witters
                Dim n As Boolean = False
                For Each t As Zdevo.Core.SQLite.Twitter In Witterlist.Items
                    If String.Compare(w.Name, t.Name) = 0 Then
                        n = True
                        w.ID = t.ID
                        w.GUID = t.GUID
                    End If
                Next
                If n = False Then
                    wittersNew.Add(w)
                Else
                    wittersUpd.Add(w)
                End If
            Next

            Me.Container.BeginTransaction()
            For Each w As Zdevo.Core.SQLite.Twitter In wittersNew
                Witterlist.Insert(w)
            Next
            For Each w As Zdevo.Core.SQLite.Twitter In wittersUpd
                'Witterlist.Update(w)
            Next
            Me.Container.EndTransaction()

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_edit365Key(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Dim bookmarks As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")

                Dim bookmark As Zdevo.Core.SQLite.Bookmark = Me.Container.NewBookmark

                Dim Title As String = n.SelectSingleNode("title").InnerText
                Dim Intro As String = n.SelectSingleNode("description").InnerText
                Dim Url As String = n.SelectSingleNode("link").InnerText

                Dim Tags As String = n.SelectSingleNode("category").InnerText

                For Each s As String In Tags.Split("; ".ToCharArray)
                    If s <> String.Empty Then
                        bookmark.Tags.Add(Me.Container.Tags(s).GUID)
                    End If
                Next

                bookmark.GUID = Guid.NewGuid
                bookmark.UserGUID = Container.User.GUID
                bookmark.SiteGUID = Container.Site.GUID

                bookmark.Name = Title

                If Intro <> String.Empty Then
                    bookmark.Content = "<p>" + Intro.Replace(vbCrLf, "<br/>") + "</p>"
                End If
                bookmark.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                bookmark.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                bookmark.Link = Url

                bookmark.CategoryGUID = Guid.Empty

                bookmark.Source = "365Key"

                bookmarks.Add(bookmark)

            Next

            Dim bookmarksUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)
            Dim bookmarksIns As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)


            Dim bookmarklist As Zdevo.Core.SQLite.BookmarkList = Container.GetBookmarkList

            bookmarklist.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, bookmarks.Count, "365Key"})

            For Each bm1 As Zdevo.Core.SQLite.Bookmark In bookmarks
                Dim bUpd As Boolean = False
                For Each bm2 As Zdevo.Core.SQLite.Bookmark In bookmarklist.Items
                    If String.Compare(bm2.Link, bm1.Link) = 0 Then
                        bUpd = True
                        bm1.ID = bm2.ID
                        bm1.GUID = bm2.GUID
                        bookmarksUpd.Add(bm1)
                        Exit For
                    End If
                Next
                If bUpd = False Then
                    bookmarksIns.Add(bm1)
                End If
            Next

            Container.BeginTransaction()
            For Each bm As Zdevo.Core.SQLite.Bookmark In bookmarksIns
                bookmarklist.Insert(bm)
            Next
            For Each bm As Zdevo.Core.SQLite.Bookmark In bookmarksUpd
                bookmarklist.Update(bm)
            Next
            Container.EndTransaction()

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_login(ByVal UserName As String, ByVal PassWord As String) As Boolean


        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"
            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else
            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))
        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_logout(ByVal UserName As String, ByVal PassWord As String) As Boolean


        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"
            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else
            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))
        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_delComments(ByVal UserName As String, ByVal PassWord As String, ByVal Guids As System.Collections.Generic.List(Of Guid)) As Boolean


        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            'Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"
            'strXML = Replace(strXML, "$1", True)
            'System.Web.HttpContext.Current.Response.Write(strXML)

            For Each g As Guid In Guids

                'Dim comment As Zdevo.Core.SQLite.Comment = Me.Container.GetCommentList.Load(g)
                Me.Container.GetCommentList.Del(g)

            Next

            'System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))
            Return True

        Else
            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))
        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


    Public Overridable Function zdevo_editDouban(ByVal UserName As String, ByVal PassWord As String, ByVal Content As String) As Boolean

        Dim b As Boolean
        b = Me.System_Initialize

        Dim User As Zdevo.Core.User = Container.GetUserList.Load(UserName, PassWord)

        If User IsNot Nothing Then

            System.Web.HttpContext.Current.Response.ContentType = "text/xml"

            Dim strXML As String = "<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><string>$1</string></value></param></params></methodResponse>"

            Dim x As New System.Xml.XmlDocument

            x.LoadXml(Content)

            Dim nsmgr As System.Xml.XmlNamespaceManager = New System.Xml.XmlNamespaceManager(x.NameTable)
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/")

            Dim shares As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Share)
            For Each n As System.Xml.XmlNode In x.DocumentElement.SelectNodes("//item")
                Dim bookmark As Zdevo.Core.SQLite.Share = Me.Container.NewShare


                Dim Title As String = n.SelectSingleNode("title").InnerText
                Dim Intro As String = n.SelectSingleNode("description").InnerText
                Dim Url As String = n.SelectSingleNode("guid").InnerText

                bookmark.GUID = Guid.NewGuid
                bookmark.UserGUID = Container.User.GUID
                bookmark.SiteGUID = Container.Site.GUID

                bookmark.Name = Title

                If Intro <> String.Empty Then
                    bookmark.Content = Intro.Replace(vbCrLf, "<br/>")
                End If

                bookmark.CreateTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                bookmark.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("pubDate").InnerText)
                bookmark.Link = Url

                bookmark.CategoryGUID = Guid.Empty

                bookmark.Source = "Douban"

                shares.Add(bookmark)

            Next

            Dim bookmarksUpd As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Share)
            Dim bookmarksIns As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Share)


            Dim bookmarklist As Zdevo.Core.SQLite.ShareList = Container.GetShareList

            bookmarklist.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, shares.Count, "Douban"})

            For Each bm1 As Zdevo.Core.SQLite.Share In shares
                Dim bUpd As Boolean = False
                For Each bm2 As Zdevo.Core.SQLite.Share In bookmarklist.Items
                    If String.Compare(bm2.Link, bm1.Link) = 0 Then
                        bUpd = True
                        bm1.ID = bm2.ID
                        bm1.GUID = bm2.GUID
                        bookmarksUpd.Add(bm1)
                        Exit For
                    End If
                Next
                If bUpd = False Then
                    bookmarksIns.Add(bm1)
                End If
            Next

            Container.BeginTransaction()
            For Each bm As Zdevo.Core.SQLite.Share In bookmarksIns
                bookmarklist.Insert(bm)
            Next
            For Each bm As Zdevo.Core.SQLite.Share In bookmarksUpd
                bookmarklist.Update(bm)
            Next
            Container.EndTransaction()

            strXML = Replace(strXML, "$1", CInt(True).ToString)
            System.Web.HttpContext.Current.Response.Write(strXML)

        Else

            System.Web.HttpContext.Current.Response.Write(RespondError("2", "Login error."))

        End If

        If b = True Then
            Me.System_Terminate()
        End If

    End Function


End Class

