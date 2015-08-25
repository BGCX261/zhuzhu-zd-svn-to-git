Namespace [Xmlrpc]
    Public Class [Index]
        Inherits Zdevo.Page.XmlrpcPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim s As String = System.Text.Encoding.UTF8.GetString(New IO.MemoryStream(Context.Request.BinaryRead(Context.Request.TotalBytes)).ToArray)
            Zdevo.Common.Utility.Current.Trace.Write(s)


            's = "<?xml version=""1.0"" encoding=""utf-8""?><methodCall><methodName>zdevo.editYupoo</methodName><params><param><value><string>zx.asd</string></value></param><param><value><string>zx119119</string></value></param><param><value><string>H4sIAAAAAAAEAO29B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/Ih7/Hu8WZXqZ101RLT/7aHe881GaL6fVrFhefPbRuj3fPvjo9zj6jZPHddO4ZntoRi8um0eLfFZkn300b9vVo7t3mzyrp/PxdTavqvG0Wtxd0Hum6Wxq263WdTmu6ou7s+ndvMwX+bJt7u6Od+9+RH392OPpPFsu8xK//9jjtmjL/KjOiuWkumqq8/Y///P+qt9nvaqq//LP+cP+yz/8r/wv/+g/8vFdafNjP8YvlMXy7ZF25L02vsZLjNXju9zmN05Saj7Lm2ldrFoamd+LhU6/vHr9Oj3P89nju35j7my1njzN2vzoi2o5Svfup8/ySbq3s3OQ7u48uv/po3sP0092DnZ2Ht81DQXFrGmfrItydrt3w+YM4SJf5nXWVrUZ6dXVlRvh47vue25eLLILefPHHhPtzUvFtPLI4o3+7oMHO/f37+9mu/nDHaIX3pG333c63ms+qPVdg6rg3eaLoOP//O/+2+h//8Wf90f/13/z32c66ncTEOPual61VXP3ssivfo9i9tn5+QGR9WB392B/52A6ub9Dv92n/z/YOX+wt3v/nodNyB2/sGwPV7/woj3EL1k6r/Pzz37hL1pX7eHG0UkTvOd9DxB3M3yY/md/1x/zn/19f9F/9vf8Ef/Z3/UH/ed/318kRPwf/74/h5vY/jZ2/EHjFUgp01LB+lR26KP3YnGRNvU07H5VTIfY6NPd/fv39z7dn+0d3G0WWVmOf3p1oT1eFbN2rpD29nf003leXMxb/Xj3wHycleazPnJp015b3CdVPcvrR+nu6l3aVGUxS398Npsdasu7ZiBC/AiNpxnNdrb8z/+kP+4//+v/iv/6D/qDia9dq64GSL3n6+mCH3ucrds5yem6yevf01Ix3fLIeOfxXW0kb1ysaVRF8zKvF9lz4tXPPjrPyib/6Btif4CXnqQ71vGPptWyJT2dkipwevw9J/6jlCH+mFKsvV7ln33EAn/3p1f5xUfBt8oIHxEPhF8I33xELPPRXaWIoBhTEf43Qdv8XasIzNtF+dGPpPtH0m25hXgjZJb5ejFZZkX5tbj/F62zOhf2Nzz94P5Hho3xa8jG05p+tGld0ag/4um+qLPVPK8/8u2uQVZahwBIuVxU9XXaTOfkXJEjVy8fMaaP2uyi+ejov/yj/+r//E/9gy0EbW4cqLvG6j6+6zyxx3fJlTv6fwAjgQ+EMAoAAA==</string></value></param></params></methodCall>"
            Dim objXmlFile As New System.Xml.XmlDocument
            objXmlFile.Load(New IO.StringReader(s))

            'objXmlFile.Load(New IO.MemoryStream(context.Request.BinaryRead(context.Request.TotalBytes)))

            'context.Server.Execute("~/code/xmlrpc/" + objXmlFile.DocumentElement.SelectSingleNode("methodName").InnerText.Replace(".", "_") + ".aspx")

            Dim methodName As String = objXmlFile.DocumentElement.SelectSingleNode("methodName").InnerText
            Select Case methodName
                Case "blogger.getUsersBlogs"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Me.blogger_getUsersBlogs(UserName, PassWord)
                Case "metaWeblog.getCategories"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Me.metaWeblog_getCategories(UserName, PassWord)
                Case "metaWeblog.getRecentPosts"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim intNumberOfPosts As Integer = CInt(objXmlFile.DocumentElement.SelectSingleNode("params/param[4]/value/int").InnerText)
                    Me.metaWeblog_getRecentPosts(UserName, PassWord, intNumberOfPosts)
                Case "metaWeblog.newPost"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim StructPost As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[4]/value/struct").OuterXml
                    Dim Publish As Boolean = CBool(objXmlFile.DocumentElement.SelectSingleNode("params/param[5]/value/boolean").InnerText)
                    Me.metaWeblog_newPost(UserName, PassWord, StructPost, Publish)
                Case "metaWeblog.getPost"
                    Dim PostGuid As Guid = New Guid(objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText)
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Me.metaWeblog_getPost(UserName, PassWord, PostGuid)
                Case "metaWeblog.editPost"
                    Dim PostGuid As Guid = New Guid(objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText)
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim StructPost As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[4]/value/struct").OuterXml
                    Dim Publish As Boolean = CBool(objXmlFile.DocumentElement.SelectSingleNode("params/param[5]/value/boolean").InnerText)
                    Me.metaWeblog_editPost(UserName, PassWord, PostGuid, StructPost, Publish)
                Case "zdevo.newComment"

                Case "zdevo.newAtomy"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim Content As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Me.zdevo_newAtomy(UserName, PassWord, Content)
                Case "zdevo.editGuestBook"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim Title As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[4]/value/string").InnerText
                    Me.zdevo_editGuestBook(UserName, PassWord, Title, Content)
                Case "zdevo.newBookMark"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim Title As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Url As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[4]/value/string").InnerText
                    Dim Content As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[5]/value/string").InnerText
                    Me.zdevo_newBookMark(UserName, PassWord, Title, Url, Content)
                Case "zdevo.editPicasa"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editPicasa(UserName, PassWord, Content)
                Case "zdevo.editFlickr"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editFlickr(UserName, PassWord, Content)
                Case "zdevo.editYupoo"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editYupoo(UserName, PassWord, Content)
                Case "zdevo.editFanfou"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editFanfou(UserName, PassWord, Content)
                Case "zdevo.editTwitter"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editTwitter(UserName, PassWord, Content)
                Case "zdevo.editDelicious"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editDelicious(UserName, PassWord, Content)
                Case "zdevo.editDouban"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_editDouban(UserName, PassWord, Content)
                Case "zdevo.edit365Key"
                    Dim UserName As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[1]/value/string").InnerText
                    Dim PassWord As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[2]/value/string").InnerText
                    Dim ZipContent As String = objXmlFile.DocumentElement.SelectSingleNode("params/param[3]/value/string").InnerText
                    Dim Content As String = System.Text.Encoding.UTF8.GetString(Zdevo.Common.Functions.Current.DecompressformBase64(ZipContent))
                    Me.zdevo_edit365Key(UserName, PassWord, Content)
                Case Else
                    Me.RespondError("1", "Invalid methodName.")
            End Select

            't.ToString.TrimStart(New Char() {ChrW(&HEF), ChrW(&HBB), ChrW(&HBF)})

            'context.Response.Write("<?xml version=""1.0"" encoding=""UTF-8""?><methodResponse><params><param><value><array><data><value><struct><member><name>url</name><value><string>$1</string></value></member><member><name>blogid</name><value><string>$2</string></value></member><member><name>blogName</name><value><string>$3</string></value></member></struct></value></data></array></value></param></params></methodResponse>")


        End Sub

        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
