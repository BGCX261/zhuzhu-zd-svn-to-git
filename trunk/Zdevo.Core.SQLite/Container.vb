''' <summary>
''' SqlContainer
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class Container : Inherits Core.BaseContainer

    Friend Connection As New System.Data.SQLite.SQLiteConnection
    Friend ConnectionString As String = ""

    Public Config As New Common.ItemConfig(Of Common.Item)
    Public ActionConfig As New Common.ItemConfig(Of Common.Item)
    Public ActionSplitConfig As New Common.ItemConfig(Of Common.Item)
    Public LanguageConfig As New Common.ItemConfig(Of Common.Item)

    Private Transaction As System.Data.SQLite.SQLiteTransaction

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

    'Private AllCatalogs As New System.Collections.Generic.SortedList(Of Guid, Catalog)
    'Private AllSites As New System.Collections.Generic.SortedList(Of Guid, Site)
    'Private AllUsers As New System.Collections.Generic.SortedList(Of Guid, User)


    ''' <summary>
    ''' 初始化函数
    ''' </summary>
    ''' <remarks>加载配置，建立数据库连接，开始计数等</remarks>
    Public Sub Initialize()

        OpenConnection()

        Me.LoadAllSites()

        For Each Site As Site In Me.AllSites
            Me.AllSitesByGUID.Add(Site.GUID, Site)
            Me.AllSitesByID.Add(Site.ID, Site)
            Me.AllSitesByName.Add(Site.Name.ToLower, Site)
        Next


        If AllSites.Count > 0 Then

            Me.Config = Site.Config.Clone

            Me.ActionSplitConfig("{%HostDirectory%}").Value = String.Copy(Me.Config("SITE_HOST").Value)

            Me.ActionSplitConfig("{%BlogDirectory%}").Value = String.Copy(Me.Site.Columns("blog").Url)
            Me.ActionSplitConfig("{%TwitterDirectory%}").Value = String.Copy(Me.Site.Columns("twitter").Url)
            Me.ActionSplitConfig("{%BookmarkDirectory%}").Value = String.Copy(Me.Site.Columns("bookmark").Url)
            Me.ActionSplitConfig("{%GalleryDirectory%}").Value = String.Copy(Me.Site.Columns("gallery").Url)
            Me.ActionSplitConfig("{%GuestBookDirectory%}").Value = String.Copy(Me.Site.Columns("guestbook").Url)

            Zdevo.Common.Functions.Current.SaveCache("APPLICATION_HOST", String.Copy(Me.Config("APPLICATION_HOST").Value))
            Zdevo.Common.Functions.Current.SaveCache("APPLICATION_DIRECTORY", String.Copy(Me.Config("APPLICATION_DIRECTORY").Value))

        End If


        Me.LoadAllUsers()

        For Each User As User In Me.AllUsers
            Me.AllUsersByGUID.Add(User.GUID, User)
            Me.AllUsersByID.Add(User.ID, User)
            Me.AllUsersByName.Add(User.Name.ToLower, User)
        Next


        Me.LoadAllCatalogs()

        For Each Catalog As Catalog In Me.AllCatalogs
            Me.AllCatalogsByGUID.Add(Catalog.GUID, Catalog)
            Me.AllCatalogsByID.Add(Catalog.ID, Catalog)
        Next


        Me.LoadAllTags()

        For Each Tag As Tag In Me.AllTags
            Me.AllTagsByGUID.Add(Tag.GUID, Tag)
            Me.AllTagsByID.Add(Tag.ID, Tag)
        Next


    End Sub


    ''' <summary>
    ''' 终结函数
    ''' </summary>
    ''' <remarks>关闭数据库,调用Dispose</remarks>
    Public Sub Terminate()

        CloseConnection()

        Dispose()

    End Sub

    ''' <summary>
    ''' 打开数据库
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenConnection() As Boolean

        Try

            Dim strConnection As String = ConnectionString

            AppDomain.CurrentDomain.SetData("DataDirectory", Common.Utility.Current.MapPath("~\App_Data\"))

            'Common.Utility.Current.Trace.Write("APPLICATION_CONNECTIONSTRING: " + strConnection)

            OpenConnection(strConnection)

            'Throw New System.Exception
            Return True

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 打开数据库 by ConnectionString
    ''' </summary>
    ''' <param name="s">ConnectionString</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenConnection(ByVal s As String) As Boolean

        Try

            Connection.ConnectionString = s
            Connection.Open()

            Return True

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 关闭数据库
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CloseConnection() As Boolean
        Connection.Close()
    End Function


    Public Sub BeginTransaction()
        Transaction = Connection.BeginTransaction
    End Sub

    Public Sub EndTransaction()
        Transaction.Commit()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        Connection.Dispose()

        MyBase.Dispose(disposing)

    End Sub



    'Public Shared Function CreateDataBase(ByVal s As String) As Boolean

    '    System.Data.SQLite.SQLiteConnection.CreateFile(s)

    '    Dim c As New Data.SQLite.SQLiteConnection("Data Source=" + s)
    '    c.Open()
    '    Dim cmd As Data.SQLite.SQLiteCommand

    '    cmd = c.CreateCommand()

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_post] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_post_ID] ON [zd_post]([ID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_post_GUID] ON [zd_post]([GUID]);"

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_postmeta] ([od] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL,[name] NVARCHAR(255) DEFAULT """" NOT NULL,[value] BLOB);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_postmeta_od] ON [zd_postmeta]([od]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_postmeta_GUID] ON [zd_postmeta]([GUID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_postmeta_name] ON [zd_postmeta]([name]);"



    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_category] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_category_ID] ON [zd_category]([ID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_category_GUID] ON [zd_category]([GUID]);"

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_categorymeta] ([od] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL,[name] NVARCHAR(255) DEFAULT """" NOT NULL,[value] BLOB);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_categorymeta_od] ON [zd_categorymeta]([od]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_categorymeta_GUID] ON [zd_categorymeta]([GUID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_categorymeta_name] ON [zd_categorymeta]([name]);"



    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_comment] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_comment_ID] ON [zd_comment]([ID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_comment_GUID] ON [zd_comment]([GUID]);"

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_commentmeta] ([od] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL,[name] NVARCHAR(255) DEFAULT """" NOT NULL,[value] BLOB);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_commentmeta_od] ON [zd_commentmeta]([od]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_commentmeta_GUID] ON [zd_commentmeta]([GUID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_commentmeta_name] ON [zd_commentmeta]([name]);"



    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_user] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_user_ID] ON [zd_user]([ID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_user_GUID] ON [zd_user]([GUID]);"

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_usermeta] ([od] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL,[name] NVARCHAR(255) DEFAULT """" NOT NULL,[value] BLOB);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_usermeta_od] ON [zd_usermeta]([od]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_usermeta_GUID] ON [zd_usermeta]([GUID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_usermeta_name] ON [zd_usermeta]([name]);"



    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_upload] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_upload_ID] ON [zd_upload]([ID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_upload_GUID] ON [zd_upload]([GUID]);"

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_uploadmeta] ([od] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL,[name] NVARCHAR(255) DEFAULT """" NOT NULL,[value] BLOB);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_uploadmeta_od] ON [zd_uploadmeta]([od]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_uploadmeta_GUID] ON [zd_uploadmeta]([GUID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_uploadmeta_name] ON [zd_uploadmeta]([name]);"



    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_site] ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_site_ID] ON [zd_site]([ID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_site_GUID] ON [zd_site]([GUID]);"

    '    cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_sitemeta] ([od] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[GUID] BLOB(16) NOT NULL,[name] NVARCHAR(255) DEFAULT """" NOT NULL,[value] BLOB);"
    '    cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_sitemeta_od] ON [zd_sitemeta]([od]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_sitemeta_GUID] ON [zd_sitemeta]([GUID]);"
    '    cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_sitemeta_name] ON [zd_sitemeta]([name]);"

    '    cmd.ExecuteNonQuery()

    '    c.Close()
    '    c.Dispose()

    'End Function

    ''' <summary>
    ''' 创建数据库
    ''' </summary>
    ''' <param name="s">数建库全路径名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateDataBase(ByVal s As String) As Boolean

        System.Data.SQLite.SQLiteConnection.CreateFile(s)

        Dim c As New Data.SQLite.SQLiteConnection("Data Source=" + s)
        c.Open()
        Dim cmd As Data.SQLite.SQLiteCommand

        cmd = c.CreateCommand()

        cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_post] ("

        cmd.CommandText = cmd.CommandText + "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" + ","
        cmd.CommandText = cmd.CommandText + "[GUID] BLOB(16) NOT NULL" + ","
        cmd.CommandText = cmd.CommandText + "[IsDisable] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsUnaudited] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDelete] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[Name] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[AliasName] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Intro] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Content] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Note] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[CreateTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ModifiTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ParentGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[SiteGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Meta] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Type] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[CommentNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[ViewNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[IsTop] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDraft] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsPrivate] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsClose] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[CategoryGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Source] NVARCHAR(256) DEFAULT ''" '+ ","
        cmd.CommandText = cmd.CommandText + ");"

        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_post_ID] ON [zd_post]([ID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_post_GUID] ON [zd_post]([GUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsDisable] ON [zd_post]([IsDisable]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsUnaudited] ON [zd_post]([IsUnaudited]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsDelete] ON [zd_post]([IsDelete]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_Name] ON [zd_post]([Name]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_CreateTime] ON [zd_post]([CreateTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_ModifiTime] ON [zd_post]([ModifiTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_Type] ON [zd_post]([Type]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_CategoryGUID] ON [zd_post]([CategoryGUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsTop] ON [zd_post]([IsTop]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsDraft] ON [zd_post]([IsDraft]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsPrivate] ON [zd_post]([IsPrivate]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_IsClose] ON [zd_post]([IsClose]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_post_Source] ON [zd_post]([Source]);"

        cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_category] ("

        cmd.CommandText = cmd.CommandText + "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" + ","
        cmd.CommandText = cmd.CommandText + "[GUID] BLOB(16) NOT NULL" + ","
        cmd.CommandText = cmd.CommandText + "[IsDisable] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsUnaudited] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDelete] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[Name] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[AliasName] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Intro] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Content] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Note] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[CreateTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ModifiTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ParentGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[SiteGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Meta] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Order] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[PostNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[Type] INTEGER DEFAULT 0" '+ ","

        cmd.CommandText = cmd.CommandText + ");"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_category_ID] ON [zd_category]([ID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_category_GUID] ON [zd_category]([GUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_IsDisable] ON [zd_category]([IsDisable]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_IsUnaudited] ON [zd_category]([IsUnaudited]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_IsDelete] ON [zd_category]([IsDelete]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_Name] ON [zd_category]([Name]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_CreateTime] ON [zd_category]([CreateTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_ModifiTime] ON [zd_category]([ModifiTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_category_Type] ON [zd_category]([Type]);"


        cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_comment] ("

        cmd.CommandText = cmd.CommandText + "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" + ","
        cmd.CommandText = cmd.CommandText + "[GUID] BLOB(16) NOT NULL" + ","
        cmd.CommandText = cmd.CommandText + "[IsDisable] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsUnaudited] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDelete] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[Name] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[AliasName] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Intro] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Content] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Note] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[CreateTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ModifiTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ParentGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[SiteGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Meta] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Email] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[HomePage] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[PostGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[IP] NVARCHAR(256) DEFAULT ''" '+ ","

        cmd.CommandText = cmd.CommandText + ");"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_comment_ID] ON [zd_comment]([ID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_comment_GUID] ON [zd_comment]([GUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_IsDisable] ON [zd_comment]([IsDisable]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_IsUnaudited] ON [zd_comment]([IsUnaudited]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_IsDelete] ON [zd_comment]([IsDelete]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_Name] ON [zd_comment]([Name]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_CreateTime] ON [zd_comment]([CreateTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_ModifiTime] ON [zd_comment]([ModifiTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_comment_PostGUID] ON [zd_comment]([PostGUID]);"

        cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_user] ("

        cmd.CommandText = cmd.CommandText + "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" + ","
        cmd.CommandText = cmd.CommandText + "[GUID] BLOB(16) NOT NULL" + ","
        cmd.CommandText = cmd.CommandText + "[IsDisable] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsUnaudited] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDelete] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[Name] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[AliasName] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Intro] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Content] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Note] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[CreateTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ModifiTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ParentGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[SiteGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Meta] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Level] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[Password] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Email] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[HomePage] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[PostNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[CommentNums] INTEGER DEFAULT 0" '+ ","

        cmd.CommandText = cmd.CommandText + ");"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_user_ID] ON [zd_user]([ID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_user_GUID] ON [zd_user]([GUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_user_Name] ON [zd_user]([Name]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_IsDisable] ON [zd_user]([IsDisable]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_IsUnaudited] ON [zd_user]([IsUnaudited]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_IsDelete] ON [zd_user]([IsDelete]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_CreateTime] ON [zd_user]([CreateTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_ModifiTime] ON [zd_user]([ModifiTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_Level] ON [zd_user]([Level]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_user_Password] ON [zd_user]([Password]);"


        cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_upload] ("

        cmd.CommandText = cmd.CommandText + "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" + ","
        cmd.CommandText = cmd.CommandText + "[GUID] BLOB(16) NOT NULL" + ","
        cmd.CommandText = cmd.CommandText + "[IsDisable] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsUnaudited] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDelete] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[Name] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[AliasName] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Intro] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Content] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Note] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[CreateTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ModifiTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ParentGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[SiteGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Meta] TEXT DEFAULT ''" '+ ","

        cmd.CommandText = cmd.CommandText + ");"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_upload_ID] ON [zd_upload]([ID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_upload_GUID] ON [zd_upload]([GUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_upload_IsDisable] ON [zd_upload]([IsDisable]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_upload_IsUnaudited] ON [zd_upload]([IsUnaudited]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_upload_IsDelete] ON [zd_upload]([IsDelete]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_upload_Name] ON [zd_upload]([Name]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_upload_CreateTime] ON [zd_upload]([CreateTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_upload_ModifiTime] ON [zd_upload]([ModifiTime]);"


        cmd.CommandText = cmd.CommandText + "CREATE TABLE [zd_site] ("

        cmd.CommandText = cmd.CommandText + "[ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" + ","
        cmd.CommandText = cmd.CommandText + "[GUID] BLOB(16) NOT NULL" + ","
        cmd.CommandText = cmd.CommandText + "[IsDisable] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsUnaudited] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[IsDelete] BOOLEAN DEFAULT false" + ","
        cmd.CommandText = cmd.CommandText + "[Name] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[AliasName] NVARCHAR(256) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Intro] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Content] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Note] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[CreateTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ModifiTime] TIMESTAMP DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[ParentGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[SiteGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserGUID] BLOB(16) DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[Meta] TEXT DEFAULT ''" + ","
        cmd.CommandText = cmd.CommandText + "[UserNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[CategoryNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[PostNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[CommentNums] INTEGER DEFAULT 0" + ","
        cmd.CommandText = cmd.CommandText + "[ViewNums] INTEGER DEFAULT 0" '+ ","

        cmd.CommandText = cmd.CommandText + ");"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_site_ID] ON [zd_site]([ID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_site_GUID] ON [zd_site]([GUID]);"
        cmd.CommandText = cmd.CommandText + "CREATE UNIQUE INDEX [zd_site_Name] ON [zd_site]([Name]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_site_IsDisable] ON [zd_site]([IsDisable]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_site_IsUnaudited] ON [zd_site]([IsUnaudited]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_site_IsDelete] ON [zd_site]([IsDelete]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_site_CreateTime] ON [zd_site]([CreateTime]);"
        cmd.CommandText = cmd.CommandText + "CREATE INDEX [zd_site_ModifiTime] ON [zd_site]([ModifiTime]);"


        cmd.ExecuteNonQuery()

        c.Close()
        c.Dispose()

    End Function


    ''' <summary>
    ''' 压缩数据库
    ''' </summary>
    ''' <param name="s">数建库全路径名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CompressdataBase(ByVal s As String) As Boolean
        System.Data.SQLite.SQLiteConnection.CompressFile(s)
    End Function


    Public Sub New()

        GlobalConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(Common.Utility.Current.MapPath(System.Configuration.ConfigurationManager.AppSettings("GlobalConfig_FileName")))

        SiteConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(Common.Utility.Current.MapPath(System.Configuration.ConfigurationManager.AppSettings("SiteConfig_FileName")))

        LanguageConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(Common.Utility.Current.MapPath(System.Configuration.ConfigurationManager.AppSettings("LanguageConfig_FileName")))

        ActionConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(Common.Utility.Current.MapPath(System.Configuration.ConfigurationManager.AppSettings("ActionConfig_FileName")))

        ActionSplitConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(Common.Utility.Current.MapPath(System.Configuration.ConfigurationManager.AppSettings("ActionSplitConfig_FileName")))

        ConnectionString = String.Copy(GlobalConfig("APPLICATION_CONNECTIONSTRING").Value)

        GlobalConfig("APPLICATION_HOST").Value = String.Copy(Common.Utility.Current.Host)
        GlobalConfig("APPLICATION_DIRECTORY").Value = String.Copy(Common.Utility.Current.PhysicalApplicationPath)
        GlobalConfig("APPLICATION_PRODUCT_NAME").Value = "Zdevo"
        GlobalConfig("APPLICATION_PRODUCT_VERSION").Value = String.Copy(My.Application.Info.Version.ToString)

        SiteConfig("SITE_HOST").Value = String.Copy(GlobalConfig("APPLICATION_HOST").Value)

        Common.Utility.TraceEnable = CBool(GlobalConfig("APPLICATION_TRACE_ENABLED").Value)
        Common.Utility.TraceFileName = GlobalConfig("APPLICATION_TRACE_FILENAME").Value

    End Sub


    Public Sub New(ByVal GlobalConfig_FileName As String, ByVal SiteConfig_FileName As String, ByVal LanguageConfig_FileName As String, ByVal ActionConfig_FileName As String, ByVal ActionSplitConfig_FileName As String, ByVal ConnectionString_FileName As String)

        GlobalConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(GlobalConfig_FileName)

        SiteConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(SiteConfig_FileName)

        LanguageConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(LanguageConfig_FileName)

        ActionConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(ActionConfig_FileName)

        ActionSplitConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(ActionSplitConfig_FileName)

        ConnectionString = "Data Source=" & ConnectionString_FileName & ";Pooling=True"

        GlobalConfig("APPLICATION_HOST").Value = ""
        GlobalConfig("APPLICATION_PRODUCT_NAME").Value = "Zdevo"

    End Sub

    Public Function GetUserList() As UserList
        Return New UserList(Me)
    End Function

    Public Function GetSiteList() As SiteList
        Return New SiteList(Me)
    End Function

    Public Function GetArticleList() As ArticleList 'Core.IPostList(Of Core.Article)
        Return New ArticleList(Me)
    End Function

    Public Function GetTwitterList() As TwitterList
        Return New TwitterList(Me)
    End Function

    Public Function GetGuestbookList() As GuestbookList
        Return New GuestbookList(Me)
    End Function

    Public Function GetBookmarkList() As BookmarkList
        Return New BookmarkList(Me)
    End Function

    Public Function GetGalleryList() As GalleryList
        Return New GalleryList(Me)
    End Function

    Public Function GetShareList() As ShareList
        Return New ShareList(Me)
    End Function

    Public Function GetPostList() As PostList
        Return New PostList(Me)
    End Function

    Public Function GetCatalogList() As CatalogList
        Return New CatalogList(Me)
    End Function

    Public Function GetTagList() As TagList
        Return New TagList(Me)
    End Function

    Public Function GetCommentList() As CommentList
        Return New CommentList(Me)
    End Function

    Public Function Catalogs(ByVal Guid As Guid) As Catalog
        Return AllCatalogsByGUID(Guid)
    End Function

    Public Function Catalogs(ByVal ID As Integer) As Catalog
        Return AllCatalogsByID(ID)
    End Function

    Public Function Catalogs(ByVal Name As String) As Catalog
        If Name = String.Empty Then
            Return Nothing
        End If
        For Each c As Catalog In Me.AllCatalogs
            If String.Compare(c.Name.ToLower, Name.ToLower) = 0 Then
                Return c
            End If
        Next
        Dim catalog As Catalog = Me.NewCatalog
        catalog.GUID = System.Guid.NewGuid
        catalog.Name = Name
        catalog.SiteGUID = Me.Site.GUID
        catalog.UserGUID = Me.User.GUID
        catalog.CreateTime = System.DateTime.Now
        catalog.ModifiTime = System.DateTime.Now
        catalog.Type = CategoryType.Catalog
        Me.GetCatalogList.Insert(catalog)
        Me.LoadAllCatalogs(True)
        Return catalog
    End Function


    Public Function Tags(ByVal Name As String) As Tag
        If Name = String.Empty Then
            Return Nothing
        End If
        For Each t As Tag In Me.AllTags
            If String.Compare(t.Name.ToLower, Name.ToLower) = 0 Then
                Return t
            End If
        Next
        Dim tag As Tag = Me.NewTag
        tag.GUID = System.Guid.NewGuid
        tag.Name = Name
        tag.SiteGUID = Me.Site.GUID
        tag.UserGUID = Me.User.GUID
        tag.CreateTime = System.DateTime.Now
        tag.ModifiTime = System.DateTime.Now
        tag.Type = CategoryType.Tag
        Me.GetTagList.Insert(tag)
        Me.LoadAllTags(True)
        Return tag
    End Function


    Public Function Tags(ByVal Guid As Guid) As Tag
        Return AllTagsByGUID(Guid)
    End Function

    Public Function Tags(ByVal ID As Integer) As Tag
        Return AllTagsByID(ID)
    End Function

    Public Function Sites(ByVal Guid As Guid) As Site
        Return AllSitesByGUID(Guid)
    End Function

    Public Function Sites(ByVal ID As Integer) As Site
        Return AllSitesByID(ID)
    End Function

    Public Function Sites(ByVal Name As String) As Site
        If AllSitesByName.ContainsKey(Name.ToLower) Then
            Return AllSitesByName(Name)
        Else
            Return Nothing
        End If
    End Function

    Public Function Users(ByVal Guid As Guid) As User
        Return AllUsersByGUID(Guid)
    End Function

    Public Function Users(ByVal ID As Integer) As User
        Return AllUsersByID(ID)
    End Function

    Public Function Users(ByVal Name As String) As User
        If AllUsersByName.ContainsKey(Name.ToLower) Then
            Return AllUsersByName(Name)
        Else
            Return Nothing
        End If
    End Function

    Public Function Catalogs() As System.Collections.Generic.List(Of Catalog)
        Return AllCatalogs
    End Function

    Public Function Sites() As System.Collections.Generic.List(Of Site)
        Return AllSites
    End Function

    Public Function Users() As System.Collections.Generic.List(Of User)
        Return AllUsers
    End Function

    Public Function Tags() As System.Collections.Generic.List(Of Tag)
        Return AllTags
    End Function

    Public ReadOnly Property Site() As Site
        Get
            Return Me.Sites.Item(0)
        End Get
    End Property

    Public ReadOnly Property User() As User
        Get
            Return Me.Users.Item(0)
        End Get
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Public Function NewUser() As User
        Return New User(Me)
    End Function

    Public Function NewSite() As Site
        Return New Site(Me)
    End Function

    Public Function NewArticle() As Article
        Return New Article(Me)
    End Function

    Public Function NewTwitter() As Twitter
        Return New Twitter(Me)
    End Function

    Public Function NewGuestbook() As Guestbook
        Return New Guestbook(Me)
    End Function

    Public Function NewBookmark() As Bookmark
        Return New Bookmark(Me)
    End Function

    Public Function NewGallery() As Gallery
        Return New Gallery(Me)
    End Function

    Public Function NewPost() As Post
        Return New Post(Me)
    End Function

    Public Function NewShare() As Share
        Return New Share(Me)
    End Function

    Public Function NewCatalog() As Catalog
        Return New Catalog(Me)
    End Function

    Public Function NewTag() As Tag
        Return New Tag(Me)
    End Function

    Public Function NewComment() As Comment
        Return New Comment(Me)
    End Function

    Public Function LoadAllSites(Optional ByVal reload As Boolean = False) As Boolean

        Me.AllSites.Clear()

        If reload = True Then

            Dim SiteList As SiteList = Me.GetSiteList
            If SiteList.List(Nothing) = True Then
                For Each Site As Site In SiteList.Items
                    Me.AllSites.Add(Site)
                Next
                Common.Functions.Current.SaveCache("AllSites", Me.AllSites)
            End If

            Return True
        End If

        If Common.Functions.Current.LoadCache("AllSites") IsNot Nothing Then
            Me.AllSites = DirectCast(Common.Functions.Current.LoadCache("AllSites"), System.Collections.Generic.List(Of Site))
        Else
            Dim SiteList As SiteList = Me.GetSiteList
            If SiteList.List(Nothing) = True Then
                For Each Site As Site In SiteList.Items
                    Me.AllSites.Add(Site)
                Next
                Common.Functions.Current.SaveCache("AllSites", Me.AllSites)
            End If
        End If

        Return True

    End Function

    Public Function LoadAllUsers(Optional ByVal reload As Boolean = False) As Boolean

        Me.AllUsers.Clear()

        If reload = True Then
            Dim UserList As UserList = Me.GetUserList
            If UserList.List(Nothing) = True Then
                For Each User As User In UserList.Items
                    Me.AllUsers.Add(User)
                Next
                Common.Functions.Current.SaveCache("AllUsers", Me.AllUsers)
            End If

            Return True
        End If

        If Common.Functions.Current.LoadCache("AllUsers") IsNot Nothing Then
            Me.AllUsers = DirectCast(Common.Functions.Current.LoadCache("AllUsers"), System.Collections.Generic.List(Of User))
        Else
            Dim UserList As UserList = Me.GetUserList
            If UserList.List(Nothing) = True Then
                For Each User As User In UserList.Items
                    Me.AllUsers.Add(User)
                Next
                Common.Functions.Current.SaveCache("AllUsers", Me.AllUsers)
            End If
        End If

        Return True

    End Function

    Public Function LoadAllCatalogs(Optional ByVal reload As Boolean = False) As Boolean

        Me.AllCatalogs.Clear()

        If reload = True Then
            Dim CatalogList As CatalogList = Me.GetCatalogList
            If CatalogList.List(Nothing) = True Then
                For Each Catalog As Catalog In CatalogList.Items
                    Me.AllCatalogs.Add(Catalog)
                Next
            End If
            Common.Functions.Current.SaveCache("AllCatalogs", Me.AllCatalogs)

            Return True
        End If

        If Common.Functions.Current.LoadCache("AllCatalogs") IsNot Nothing Then
            Me.AllCatalogs = DirectCast(Common.Functions.Current.LoadCache("AllCatalogs"), System.Collections.Generic.List(Of Catalog))
        Else
            Dim CatalogList As CatalogList = Me.GetCatalogList

            If CatalogList.List(Nothing) = True Then
                For Each Catalog As Catalog In CatalogList.Items
                    Me.AllCatalogs.Add(Catalog)
                Next
            End If
            Common.Functions.Current.SaveCache("AllCatalogs", Me.AllCatalogs)
        End If

        Return True

    End Function

    Public Function LoadAllTags(Optional ByVal reload As Boolean = False) As Boolean

        Me.AllTags.Clear()

        If reload = True Then

            Dim TagList As TagList = Me.GetTagList
            If TagList.List(Nothing) = True Then
                For Each Tag As Tag In TagList.Items
                    Me.AllTags.Add(Tag)
                Next
            End If
            Common.Functions.Current.SaveCache("AllTags", Me.AllTags)

            Return True
        End If

        If Common.Functions.Current.LoadCache("AllTags") IsNot Nothing Then
            Me.AllTags = DirectCast(Common.Functions.Current.LoadCache("AllTags"), System.Collections.Generic.List(Of Tag))
        Else
            Dim TagList As TagList = Me.GetTagList

            If TagList.List(Nothing) = True Then
                For Each Tag As Tag In TagList.Items
                    Me.AllTags.Add(Tag)
                Next
            End If
            Common.Functions.Current.SaveCache("AllTags", Me.AllTags)
        End If

        Return True

    End Function

    Public Function Verify(ByVal username As String, ByVal password As String) As Boolean
        If username = String.Empty Then
            Return False
        End If
        If password = String.Empty Then
            Return False
        End If

        If AllUsersByName.ContainsKey(username) = True Then
            If String.Compare(Users(username).Password, password) = 0 Then
                Return True
            End If
        End If

    End Function

End Class