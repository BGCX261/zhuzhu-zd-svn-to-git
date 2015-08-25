''' <summary>
''' SqlContainer
''' </summary>
''' <remarks></remarks>
Public MustInherit Class Container : Inherits Core.BaseContainer

    Public Config As New Common.ItemConfig(Of Common.Item)
    Public ActionConfig As New Common.ItemConfig(Of Common.Item)
    Public ActionSplitConfig As New Common.ItemConfig(Of Common.Item)
    Public LanguageConfig As New Common.ItemConfig(Of Common.Item)

    Friend GlobalConfig As New Common.ItemConfig(Of Common.Item)
    Friend SiteConfig As New Common.ItemConfig(Of Common.Item)

    Private AllCatalogsByID As New System.Collections.Generic.Dictionary(Of Integer, Catalog)
    Private AllCatalogsByGUID As New System.Collections.Generic.Dictionary(Of Guid, Catalog)

    Private AllTagsByID As New System.Collections.Generic.Dictionary(Of Integer, Tag)
    Private AllTagsByGUID As New System.Collections.Generic.Dictionary(Of Guid, Tag)

    Private AllSitesByName As New System.Collections.Generic.Dictionary(Of String, Site)
    Private AllSitesByID As New System.Collections.Generic.Dictionary(Of Integer, Site)
    Private AllSitesByGUID As New System.Collections.Generic.Dictionary(Of Guid, Site)

    Private AllUsersByName As New System.Collections.Generic.Dictionary(Of String, User)
    Private AllUsersByID As New System.Collections.Generic.Dictionary(Of Integer, User)
    Private AllUsersByGUID As New System.Collections.Generic.Dictionary(Of Guid, User)

    Private AllCatalogs As New System.Collections.Generic.List(Of Catalog)
    Private AllSites As New System.Collections.Generic.List(Of Site)
    Private AllUsers As New System.Collections.Generic.List(Of User)
    Private AllTags As New System.Collections.Generic.List(Of Tag)

    ''' <summary>
    ''' 初始化函数
    ''' </summary>
    ''' <remarks>加载配置，建立数据库连接，开始计数等</remarks>
    Public MustOverride Sub Initialize()



    ''' <summary>
    ''' 终结函数
    ''' </summary>
    ''' <remarks>关闭数据库,调用Dispose</remarks>
    Public MustOverride Sub Terminate()



    Public MustOverride Sub BeginTransaction()


    Public MustOverride Sub EndTransaction()


    Protected MustOverride Overrides Sub Dispose(ByVal disposing As Boolean)



    Public MustOverride Function GetUserList() As IUserList(Of User)


    Public MustOverride Function GetSiteList() As ISiteList(Of Site)

    Public MustOverride Function GetArticleList() As IPostList(Of Article)


    Public MustOverride Function GetAtomyList() As IPostList(Of Atomy)

    Public MustOverride Function GetGuestbookList() As IPostList(Of Guestbook)

    Public MustOverride Function GetBookmarkList() As IPostList(Of Bookmark)


    Public MustOverride Function GetGalleryList() As IPostList(Of Gallery)

    Public MustOverride Function GetPostList() As IPostList(Of Post)


    Public MustOverride Function GetCatalogList() As ICategoryList(Of Catalog)

    Public MustOverride Function GetTagList() As ICategoryList(Of Tag)


    Public MustOverride Function GetCommentList() As ICommentList(Of Comment)

    Public MustOverride Function Catalogs(ByVal Guid As Guid) As Catalog


    Public MustOverride Function Catalogs(ByVal ID As Integer) As Catalog

    Public MustOverride Function Catalogs(ByVal Name As String) As Catalog

    Public MustOverride Function Tags(ByVal Name As String) As Tag

    Public MustOverride Function Tags(ByVal Guid As Guid) As Tag

    Public MustOverride Function Tags(ByVal ID As Integer) As Tag


    Public MustOverride Function Sites(ByVal Guid As Guid) As Site

    Public MustOverride Function Sites(ByVal ID As Integer) As Site

    Public MustOverride Function Sites(ByVal Name As String) As Site


    Public MustOverride Function Users(ByVal Guid As Guid) As User

    Public MustOverride Function Users(ByVal ID As Integer) As User


    Public MustOverride Function Users(ByVal Name As String) As User

    Public MustOverride Function Catalogs() As System.Collections.Generic.List(Of Catalog)


    Public MustOverride Function Sites() As System.Collections.Generic.List(Of Site)

    Public MustOverride Function Users() As System.Collections.Generic.List(Of User)


    Public MustOverride Function Tags() As System.Collections.Generic.List(Of Tag)


    Public MustOverride ReadOnly Property Site() As Site


    Public MustOverride ReadOnly Property User() As User


    Protected MustOverride Overrides Sub Finalize()


    Public MustOverride Function NewUser() As User


    Public MustOverride Function NewSite() As Site


    Public MustOverride Function NewArticle() As Article


    Public MustOverride Function NewAtomy() As Atomy


    Public MustOverride Function NewGuestbook() As Guestbook


    Public MustOverride Function NewBookmark() As Bookmark


    Public MustOverride Function NewGallery() As Gallery


    Public MustOverride Function NewPost() As Post


    Public MustOverride Function NewCatalog() As Catalog


    Public MustOverride Function NewTag() As Tag


    Public MustOverride Function NewComment() As Comment


    Public MustOverride Function LoadAllSites(Optional ByVal reload As Boolean = False) As Boolean


    Public MustOverride Function LoadAllUsers(Optional ByVal reload As Boolean = False) As Boolean


    Public MustOverride Function LoadAllCatalogs(Optional ByVal reload As Boolean = False) As Boolean


    Public MustOverride Function LoadAllTags(Optional ByVal reload As Boolean = False) As Boolean


    Public MustOverride Function Verify(ByVal username As String, ByVal password As String) As Boolean


End Class