Public Class FormMain

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TextBox1.Text = My.Computer.FileSystem.GetParentPath(My.Application.Info.DirectoryPath) & "\App_Data\abc.db"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Button1.Enabled = False
        Zdevo.Core.SQLite.Container.CreateDataBase(Me.TextBox1.Text)
        Me.Button1.Enabled = True
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Me.TextBox2.Text = Me.OpenFileDialog1.FileName
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Button3.Enabled = False

        Dim doc As New Xml.XmlDocument

        Me.TextBox3.AppendText("加载 XML文件:" + My.Computer.FileSystem.GetFileInfo(Me.TextBox2.Text).Name + vbCrLf)
        doc.Load(Me.TextBox2.Text)

        Me.TextBox3.AppendText("初始化 转换构造器:" + "Zdevo.Core.SQLite.Container" + vbCrLf)

        Dim s1 = My.Computer.FileSystem.GetParentPath(My.Application.Info.DirectoryPath) & "\config\global.config"
        Dim s2 = My.Computer.FileSystem.GetParentPath(My.Application.Info.DirectoryPath) & "\config\site.config"
        Dim s3 = My.Computer.FileSystem.GetParentPath(My.Application.Info.DirectoryPath) & "\config\language.config"
        Dim s4 = My.Computer.FileSystem.GetParentPath(My.Application.Info.DirectoryPath) & "\config\action.config"
        Dim s5 = My.Computer.FileSystem.GetParentPath(My.Application.Info.DirectoryPath) & "\config\actionsplit.config"
        Dim s6 = Me.TextBox1.Text

        Dim f As New Zdevo.Core.SQLite.Container(s1, s2, s3, s4, s5, s6)
        f.Initialize()


        'site
        Dim sl As New Zdevo.Core.SQLite.SiteList(f)
        Dim site As Zdevo.Core.SQLite.Site = f.NewSite
        site.GUID = System.Guid.NewGuid
        site.Name = "myspace"
        site.CreateTime = System.DateTime.Now
        site.ModifiTime = System.DateTime.Now
        site.UserGUID = System.Guid.NewGuid
        sl.Insert(site)

        Me.TextBox3.AppendText("创建 站点:" + site.Name + vbCrLf)


        'User
        Dim ul As New Zdevo.Core.SQLite.UserList(f)
        Dim users As New System.Collections.Generic.SortedList(Of String, Core.SQLite.User)

        Dim dicUser As New System.Collections.Generic.Dictionary(Of String, Xml.XmlNode)
        Dim nodesUser As Xml.XmlNodeList = doc.SelectNodes("//entry/author")

        For Each n As Xml.XmlNode In nodesUser
            Try
                dicUser.Add(n.SelectSingleNode("name").InnerText, n)
            Catch ex As Exception

            End Try
        Next

        For Each n As Xml.XmlNode In dicUser.Values

            If users.Count > 0 Then
                Exit For
            End If

            Me.TextBox3.AppendText("创建 用户:" + n.SelectSingleNode("name").InnerText & vbCrLf)
            Dim user As Core.SQLite.User = f.NewUser

            user.Name = n.SelectSingleNode("name").InnerText
            user.Password = "123456"
            user.GUID = System.Guid.NewGuid
            user.CreateTime = System.DateTime.Now
            user.ModifiTime = System.DateTime.Now
            user.SiteGUID = site.GUID
            users.Add(user.Name, user)
            user = Nothing

        Next

        users.Values.Item(0).GUID = site.UserGUID

        f.BeginTransaction()
        For Each u As Core.SQLite.User In users.Values
            ul.Insert(u)
        Next
        f.EndTransaction()
        Me.TextBox3.AppendText("插入 用户:" + users.Count.ToString + vbCrLf)

        'Cate
        Dim dicCate As New System.Collections.Generic.Dictionary(Of String, String)
        Dim cl As New Zdevo.Core.SQLite.CatalogList(f)
        Dim cates As New System.Collections.Generic.Dictionary(Of String, Core.SQLite.Catalog)

        Dim nodesCate As Xml.XmlNodeList = doc.SelectNodes("//entry/category")
        For Each n As Xml.XmlNode In nodesCate
            Try
                dicCate.Add(n.Attributes.GetNamedItem("label").InnerText, n.OuterXml)
            Catch ex As Exception

            End Try
        Next

        For Each s As String In dicCate.Keys
            Me.TextBox3.AppendText("创建 分类:" + s & vbCrLf)
            Dim c As Zdevo.Core.SQLite.Catalog = f.NewCatalog
            c.GUID = System.Guid.NewGuid
            c.CreateTime = System.DateTime.Now
            c.ModifiTime = System.DateTime.Now
            c.Type = Core.CategoryType.Catalog
            c.Name = s
            c.UserGUID = users.Values.Item(0).GUID
            c.SiteGUID = site.GUID
            cates.Add(c.Name, c)
        Next

        f.BeginTransaction()
        For Each c As Core.SQLite.Catalog In cates.Values
            cl.Insert(c)
        Next
        f.EndTransaction()
        Me.TextBox3.AppendText("插入 分类:" + cates.Count.ToString + vbCrLf)



        'Tags
        Dim dicTags As New System.Collections.Generic.Dictionary(Of String, String)
        Dim tl As New Zdevo.Core.SQLite.TagList(f)
        Dim tags As New System.Collections.Generic.Dictionary(Of String, Core.SQLite.Tag)

        Dim nodesTags As Xml.XmlNodeList = doc.SelectNodes("//tag")
        For Each n As Xml.XmlNode In nodesTags
            Try
                dicTags.Add(n.InnerText, n.OuterXml)
            Catch ex As Exception

            End Try
        Next

        For Each s As String In dicTags.Keys
            Me.TextBox3.AppendText("创建 Tags:" + s & vbCrLf)
            Dim t As Zdevo.Core.SQLite.Tag = f.NewTag
            t.GUID = System.Guid.NewGuid
            t.CreateTime = System.DateTime.Now
            t.ModifiTime = System.DateTime.Now
            t.Type = Core.CategoryType.Tag
            t.Name = s
            t.UserGUID = users.Values.Item(0).GUID
            t.SiteGUID = site.GUID
            tags.Add(t.Name, t)
        Next

        f.BeginTransaction()
        For Each t As Core.SQLite.Tag In tags.Values
            tl.Insert(t)
        Next
        f.EndTransaction()
        Me.TextBox3.AppendText("插入 tags:" + tags.Count.ToString + vbCrLf)



        'Post
        Dim dicPost As New System.Collections.Generic.List(Of Xml.XmlNode)
        Dim pl As New Zdevo.Core.SQLite.ArticleList(f)
        Dim posts As New System.Collections.Generic.List(Of Core.SQLite.Article)

        'Comment
        Dim cml As New Zdevo.Core.SQLite.CommentList(f)
        Dim comments As New System.Collections.Generic.List(Of Core.SQLite.Comment)

        'Trackback
        Dim tbl As New Zdevo.Core.SQLite.CommentList(f)
        Dim trackback As New System.Collections.Generic.List(Of Core.SQLite.Comment)

        Dim nodesPost As Xml.XmlNodeList = doc.SelectNodes("//entry")
        For Each n As Xml.XmlNode In nodesPost
            dicPost.Add(n)

            Me.TextBox3.AppendText("创建 文章:" + n.SelectSingleNode("title").InnerText + vbCrLf)

            Dim p As Zdevo.Core.SQLite.Article = f.NewArticle
            p.Name = n.SelectSingleNode("title").InnerText
            p.GUID = System.Guid.NewGuid
            p.CategoryGUID = cates(n.SelectSingleNode("category").Attributes.GetNamedItem("label").InnerText).GUID
            p.CreateTime = System.DateTime.Parse(n.SelectSingleNode("published").InnerText)
            p.ModifiTime = System.DateTime.Parse(n.SelectSingleNode("updated").InnerText)
            p.Type = Core.PostType.Article
            'p.UserGUID = users(n.SelectSingleNode("author").SelectSingleNode("name").InnerText).GUID
            p.UserGUID = users.Values.Item(0).GUID
            p.SiteGUID = site.GUID
            p.Content = n.SelectSingleNode("content").InnerText
            'p.Meta.Add(New Common.Item("我的", "标题"))
            posts.Add(p)

            Dim dicComment As New System.Collections.Generic.List(Of Xml.XmlNode)

            Dim nodesComment As Xml.XmlNodeList = n.SelectNodes("comment")
            For Each m As Xml.XmlNode In nodesComment
                Try
                    dicComment.Add(m)
                Catch ex As Exception

                End Try
            Next

            For Each m As Xml.XmlNode In dicComment
                Me.TextBox3.AppendText("创建 评论:" + m.SelectSingleNode("author").SelectSingleNode("name").InnerText + vbCrLf)
            Next

            For Each m As Xml.XmlNode In dicComment
                Dim c As Zdevo.Core.SQLite.Comment = f.NewComment
                c.GUID = System.Guid.NewGuid
                c.PostGUID = p.GUID
                c.Name = m.SelectSingleNode("author").SelectSingleNode("name").InnerText

                If m.SelectSingleNode("author").SelectNodes("uri").Count > 0 Then
                    c.HomePage = m.SelectSingleNode("author").SelectSingleNode("uri").InnerText
                End If

                If m.SelectSingleNode("author").SelectNodes("email").Count > 0 Then
                    c.Email = m.SelectSingleNode("author").SelectSingleNode("email").InnerText
                End If

                c.Content = m.SelectSingleNode("content").InnerText.Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>")
                c.CreateTime = System.DateTime.Parse(m.SelectSingleNode("published").InnerText)
                c.ModifiTime = System.DateTime.Parse(m.SelectSingleNode("published").InnerText)
                If users.TryGetValue(m.SelectSingleNode("author").SelectSingleNode("name").InnerText, Nothing) = True Then
                    c.UserGUID = users(m.SelectSingleNode("author").SelectSingleNode("name").InnerText).GUID
                Else
                    c.UserGUID = System.Guid.Empty
                End If
                c.SiteGUID = site.GUID
                comments.Add(c)
            Next

            dicComment = Nothing


            Dim dicTrackback As New System.Collections.Generic.List(Of Xml.XmlNode)

            Dim nodesTrackback As Xml.XmlNodeList = n.SelectNodes("trackback")
            For Each m As Xml.XmlNode In nodesTrackback
                Try
                    dicTrackback.Add(m)
                Catch ex As Exception

                End Try
            Next

            For Each m As Xml.XmlNode In dicTrackback
                Me.TextBox3.AppendText("创建 引用:" + m.SelectSingleNode("title").InnerText + vbCrLf)
            Next

            For Each m As Xml.XmlNode In dicTrackback
                Dim t As Zdevo.Core.SQLite.Comment = f.NewComment
                t.GUID = System.Guid.NewGuid
                t.PostGUID = p.GUID
                t.Name = m.SelectSingleNode("title").InnerText
                t.HomePage = m.SelectSingleNode("link").Attributes("href").Value
                t.Content = m.SelectSingleNode("content").InnerText.Replace(vbCrLf, "<br/>").Replace(vbLf, "<br/>")
                t.CreateTime = System.DateTime.Parse(m.SelectSingleNode("published").InnerText)
                t.ModifiTime = System.DateTime.Parse(m.SelectSingleNode("published").InnerText)
                t.UserGUID = System.Guid.Empty
                t.SiteGUID = site.GUID
                trackback.Add(t)
            Next
            dicTrackback = Nothing

        Next


        f.BeginTransaction()
        For Each p As Core.SQLite.Article In posts
            pl.Insert(p)
        Next
        f.EndTransaction()
        Me.TextBox3.AppendText("插入 文章:" + posts.Count.ToString + vbCrLf)


        f.BeginTransaction()
        For Each c As Core.SQLite.Comment In comments
            cml.Insert(c)
        Next
        f.EndTransaction()
        Me.TextBox3.AppendText("插入 评论:" + comments.Count.ToString + vbCrLf)


        f.BeginTransaction()
        For Each t As Core.SQLite.Comment In trackback
            tbl.Insert(t)
        Next
        f.EndTransaction()
        Me.TextBox3.AppendText("插入 引用:" + trackback.Count.ToString + vbCrLf)

        'MessageBox.Show(a.Count)

        'Dim a As New Data.SQLite.SQLiteConnection("Data Source=" + Me.TextBox1.Text)
        'a.Open()
        'Dim cmd As Data.SQLite.SQLiteCommand

        'cmd = a.CreateCommand()

        'Dim c As System.Data.SQLite.SQLiteTransaction = a.BeginTransaction
        'For i As Integer = 0 To doc.DocumentElement.ChildNodes.Count - 1
        '    'Me.TextBox3.AppendText(doc.DocumentElement.ChildNodes(i).Name & vbCrLf)
        '    'cmd.CommandText = ""
        '    If doc.DocumentElement.ChildNodes(i).Name = "entry" Then

        '        cmd.CommandText = "INSERT INTO [zd_post] (guid) VALUES (@guid)"
        '        Dim param = New SQLiteParameter("@guid", System.Data.DbType.Binary)
        '        param.Value = System.Guid.NewGuid().ToByteArray()
        '        cmd.Parameters.Add(param)
        '        cmd.ExecuteNonQuery()

        '    End If
        'Next
        'c.Commit()

        ''MessageBox.Show(doc.DocumentElement.SelectNodes("//entry").Count)

        'cmd.Dispose()
        'a.Close()


        f.Terminate()
        'f.Dispose()
        f = Nothing

        Me.Button3.Enabled = True

    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer http://www.zdevo.com/")
        'System.Diagnostics.Process.Start("http://www.zdevo.com/")
    End Sub

End Class
