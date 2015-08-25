<%@ WebHandler Language="VB" Class="Handler" %>

Imports System
Imports System.Web

Public Class Handler
    
    Inherits Zdevo.Page.XmlrpcPage
    Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        Dim c As New Zdevo.Core.SQLite.Container
        c.Initialize()
        
        'Zdevo.Common.Utility.Current.Trace.Write("Accept-Encoding: " + System.Web.HttpContext.Current.Request.Headers.Get("Accept-Encoding"))
        
        'context.Response.Write(System.Convert.ToBase64CharArray(System.Guid.NewGuid.ToByteArray))
        
        
        Dim bookmarklist As Zdevo.Core.SQLite.ShareList = c.GetShareList

        bookmarklist.List(New String() {"Source"}, New Object() {"Douban"})

        For Each bm1 As Zdevo.Core.SQLite.Share In bookmarklist.Items
            bookmarklist.Del(bm1.ID)
        Next
        
        'c.BeginTransaction()
        'Dim a As Zdevo.Core.SQLite.AtomyList = c.GetAtomyList
        'If a.List(Nothing) = True Then
        '    For Each b As Zdevo.Core.SQLite.Atomy In a.Items
        '        'If b.Name = String.Empty Then
        '        'b.Name = Left(b.Content, 250)
        '        'a.Update(b)
        '        If b.Link = "http://fanfou.com/statuses/vI2sIVFQUO4" Then
        '            a.Del(b.ID)
        '        End If
        '        If b.Link = "http://fanfou.com/statuses/mlK9clUWKtU" Then
        '            a.Del(b.ID)
        '        End If
        '        'If b.Link = "http://fanfou.com/statuses/xbqfjItCC6U" Then
        '        'a.Del(b.ID)
        '        'End If
                
        '        context.Response.Write(b.Link + "<br/>")
        '        'End If
        '    Next
        'End If
        'c.EndTransaction()
        
        
        
        
        'c.BeginTransaction()
        'Dim a As Zdevo.Core.SQLite.BookmarkList = c.GetBookmarkList
        'If a.List(New String() {"DateBetween", "DateAnd"}, New Object() {DateTime.Parse("2004-01-01"), DateTime.Parse("2008-01-23")}) Then
        '    For Each b As Zdevo.Core.SQLite.Bookmark In a.Items
        '        context.Response.Write(b.Name + "<br/>")
        '        b.Source = "365Key"
        '        a.Update(b)
        '    Next
        'End If
        'c.EndTransaction()
        
        'Dim postlist2 As Zdevo.Core.SQLite.AtomyList = c.GetAtomyList
        
        'c.BeginTransaction()
        'If postlist2.List(Nothing) Then
        '    For Each post As Zdevo.Core.SQLite.Atomy In postlist2.Items
              
        '        If post.Source <> String.Empty Then
        '            'post.Source = String.Copy(post.Note)
        '            'post.Note = String.Empty
        '            'c.GetAtomyList.Update(post)
        '        Else
        '            'post.Note = "Zdevo.Tools"
        '            'c.GetAtomyList.Update(post)
        '            context.Response.Write(post.GUID.ToString + "<br/>")
        '        End If
        '    Next
        'End If
        'c.EndTransaction()
        
        'c.BeginTransaction()
        'Dim postlist2 As Zdevo.Core.SQLite.GalleryList = c.GetGalleryList
        
        'If postlist2.List(Nothing) Then
        '    For Each post As Zdevo.Core.SQLite.Gallery In postlist2.Items
        '        post.Source = String.Copy(post.Note)
        '        post.Note = String.Empty
        '        c.GetGalleryList.Update(post)
        '    Next
        'End If
        'c.EndTransaction()
        
        'Dim postlist2 As Zdevo.Core.SQLite.GalleryList = c.GetGalleryList

        'Dim flickr As Zdevo.Core.SQLite.Gallery = c.NewGallery
        'If postlist2.List(New String() {"Page", "PageSize", "Source"}, New Object() {1, c.Config("SITE_GALLERY_FLICKR_LIST_COUNT").Value, "Flickr"}) Then
        '    flickr = postlist2.Items(0)
        '    postlist2.Del(flickr.ID)
        'End If
        
        'c.BeginTransaction()
        'Dim d As Zdevo.Core.SQLite.WitterList = c.GetWitterList
        'If d.List(Nothing) Then
        '    For Each b As Zdevo.Core.SQLite.Witter In d.Items
        '        b.UserGUID = c.User.GUID
        '        d.Update(b)
        '    Next
        'End If
        'c.EndTransaction()
        
        
        'Dim gallerylist As Zdevo.Core.SQLite.GalleryList = c.GetGalleryList
        
        'gallerylist.List(Nothing)
        'c.BeginTransaction()
        'For Each g As Zdevo.Core.SQLite.Gallery In gallerylist.Items
        '    gallerylist.Del(g.GUID)
        'Next
        'c.EndTransaction()
               
        
        'c.BeginTransaction()
        'Dim a As Zdevo.Core.SQLite.BookmarkList = c.GetBookmarkList
        'If a.List(Nothing) Then
        '    Dim b As Zdevo.Core.SQLite.Bookmark = a.Items(0)
        '    b.UserGUID = c.User.GUID
        '    a.Update(b)
        'End If
        'c.EndTransaction()
        
        'c.BeginTransaction()
        'Dim d As Zdevo.Core.SQLite.WitterList = c.GetWitterList
        'If d.List(Nothing) Then
        '    Dim b As Zdevo.Core.SQLite.Witter = d.Items(0)
        '    b.UserGUID = c.User.GUID
        '    d.Update(b)
        'End If
        'c.EndTransaction()
        
        'c.BeginTransaction()
        'Dim e As Zdevo.Core.SQLite.ArticleList = c.GetArticleList
        'If e.List(Nothing) Then
        '    Dim b As Zdevo.Core.SQLite.Article = e.Items(0)
        '    b.UserGUID = c.User.GUID
        '    e.Update(b)
        'End If
        'c.EndTransaction()
        
        
        'c.BeginTransaction()
        'Dim f As Zdevo.Core.SQLite.CommentList = c.GetCommentList
        'If f.List(Nothing) Then
        '    Dim b As Zdevo.Core.SQLite.Comment = f.Items(0)
        '    If b.UserGUID = c.GetUsers(2).GUID Then
        '        b.UserGUID = c.User.GUID
        '    End If
        '    f.Update(b)
        'End If
        'c.EndTransaction()
        
        
        'c.Terminate()
        
        'Dim s As Zdevo.Core.SQLite.Site = c.Site
        's.UserGUID = c.User.GUID
        'c.GetSiteList.Update(s)
        
        'Dim u2 As Zdevo.Core.SQLite.User = c.GetUsers(2)
        'u2.Name = "zx.asd2"
        'c.GetUserList.Update(u2)
        
        
        'Dim u1 As Zdevo.Core.SQLite.User = c.GetUsers(1)
        'u1.Name = "zx.asd"
        'c.GetUserList.Update(u1)
        
                      
        'Dim c As New Zdevo.Core.SQLite.Container
        'c.Initialize()
        
        'Dim x As New Xml.XmlDocument
        
        'x.Load("E:\Zdevo\Zdevo.Web\ddddddd.xml")
        
        ''context.Response.Write(x.ChildNodes.Count)
        
        ''context.Response.Write(x.DocumentElement.SelectNodes("//H3").Count)
        
        'Dim s As New System.Collections.Generic.Dictionary(Of String, DateTime)
        
        'For Each n As Xml.XmlNode In x.DocumentElement.SelectNodes("//A")
            
        '    'context.Response.Write(n.ParentNode.PreviousSibling.InnerText + "<br/>")
            
        '    Dim i As Long = CLng(n.ParentNode.PreviousSibling.Attributes("ADD_DATE").Value)
        '    'Dim i As Long = CLng(n.Attributes("ADD_DATE").Value)
        '    'i = i
            
        '    Dim j As Date = System.DateTime.Parse("1970-01-01 00:00:00").AddSeconds(i)
            
        '    'context.Response.Write(j.ToString + "<br/>")
            
            
        '    Dim a As String = n.ParentNode.PreviousSibling.InnerText
            
        '    If s.ContainsKey(a) = False Then
        '        s.Add(a, j)
        '    End If           
            
        'Next
        
        'Dim tags As New System.Collections.Generic.SortedDictionary(Of String, Zdevo.Core.SQLite.Tag)
        'For Each ss As String In s.Keys
        '    'context.Response.Write(ss)
        '    Dim t As New Zdevo.Core.SQLite.Tag(c)
        '    t.Name = ss
        '    t.GUID = Guid.NewGuid
        '    t.Type = Zdevo.Core.CategoryType.Tag
        '    t.SiteGUID = c.GetSites.Item(0).GUID
        '    t.UserGUID = c.GetUsers.Item(0).GUID
        '    t.CreateTime = s(ss)
        '    t.ModifiTime = System.DateTime.Now
            
        '    tags.Add(ss, t)
        'Next
        
        'Dim tl As Zdevo.Core.SQLite.TagList = c.GetTagList
        'c.BeginTransaction()
        'For Each tag As Zdevo.Core.SQLite.Tag In tags.Values
        '    context.Response.Write(tag.Name + "加入<br/>")
        '    tl.Insert(tag)
        'Next
        'c.EndTransaction()
        

        'Dim bms As New System.Collections.Generic.List(Of Zdevo.Core.SQLite.Bookmark)
        
        'For Each n As Xml.XmlNode In x.DocumentElement.SelectNodes("//A")
            
        '    Dim i As Long = CLng(n.Attributes("ADD_DATE").Value)
        '    Dim j As Date = System.DateTime.Parse("1970-01-01 00:00:00").AddSeconds(i)
            
        '    Dim b As New Zdevo.Core.SQLite.Bookmark(c)
            
        '    b.GUID = Guid.NewGuid
        '    b.Name = n.InnerText
        '    b.Note = n.Attributes("HREF").Value
        '    b.SiteGUID = c.GetSites.Item(0).GUID
        '    b.UserGUID = c.GetUsers.Item(0).GUID
        '    b.CreateTime = j
        '    b.ModifiTime = System.DateTime.Now
        '    b.Type = Zdevo.Core.PostType.Bookmark
        '    b.Tags.Add(tags(n.ParentNode.PreviousSibling.InnerText).GUID)
            
        '    bms.Add(b)
            
        'Next
        
        'Dim bl As Zdevo.Core.SQLite.BookmarkList = c.GetBookmarkList
        
        'c.BeginTransaction()
        'For Each bm As Zdevo.Core.SQLite.Bookmark In bms
        '    context.Response.Write(bm.Name + "加入<br/>")
        '    bl.Insert(bm)
        'Next
        'c.EndTransaction()
        
        'c.Terminate()
        
        
        
        
        
        
        'context.Response.ContentType = "text/plain"
        ''context.Response.Write("Hello World")
        
        'Dim c As New Zdevo.Core.SQLite.Container
        'c.Initialize()
        
        'Dim cl As Zdevo.Core.SQLite.ArticleList = c.GetArticleList
        
        'If cl.List(Nothing) Then
        '    context.Response.Write(cl.Items.Count)
        'End If
        'c.BeginTransaction()
        'For Each cm As Zdevo.Core.SQLite.Article In cl.Items
        '    cm.UserGUID = c.GetUsers("zx.asd").GUID
        '    cl.Update(cm)
        'Next
        'c.EndTransaction()
        
        'c.Terminate()
        
        ' Start the timer with the given interval
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class