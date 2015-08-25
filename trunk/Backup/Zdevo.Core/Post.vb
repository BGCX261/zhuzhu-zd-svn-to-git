''' <summary>
''' Article
''' </summary>
''' <remarks></remarks>
Public Class Post : Inherits BaseEntry

    Implements IPost

    'Public Overrides Function Clone() As Object
    '    Dim c As New Article()
    '    c.AliasName = String.Copy(Me.AliasName)
    '    c.MainCategoryID = Me.MainCategoryID
    '    c.CategorysID = New System.Collections.Generic.List(Of Integer)
    '    For Each i As Integer In Me.CategorysID
    '        c.CategorysID.Add(i)
    '    Next
    '    c.CommentNums = Me.CommentNums
    '    c.Content = String.Copy(Me.Content)
    '    c.GUID = New System.Guid(Me.GUID.ToString)
    '    c.ID = Me.ID
    '    c.Intro = String.Copy(Me.Intro)
    '    c.IsClose = Me.IsClose
    '    c.IsDelete = Me.IsDelete
    '    c.IsDisable = Me.IsDisable
    '    c.IsDraft = Me.IsDraft
    '    c.IsPrivate = Me.IsPrivate
    '    c.IsTop = Me.IsTop
    '    c.IsUnaudited = Me.IsUnaudited
    '    c.ModifiTime = Me.ModifiTime
    '    c.Name = String.Copy(Me.Name)
    '    c.Note = String.Copy(Me.Note)
    '    c.ParentID = Me.ParentID
    '    c.PostTime = Me.PostTime
    '    c.SiteID = Me.SiteID
    '    c.UserID = Me.UserID
    '    c.ViewNums = Me.ViewNums
    '    Return c
    'End Function

    Private FAliasName As String
    Public Overridable Property AliasName() As String Implements IPost.AliasName
        Get
            Return FAliasName
        End Get
        Set(ByVal value As String)
            FAliasName = value
        End Set
    End Property

    Private FContent As String
    Public Overridable Property Content() As String Implements IPost.Content
        Get
            Return FContent
        End Get
        Set(ByVal value As String)
            FContent = value
        End Set
    End Property

    Private FCreateTime As Date
    Public Overridable Property CreateTime() As Date Implements IPost.CreateTime
        Get
            Return FCreateTime
        End Get
        Set(ByVal value As Date)
            FCreateTime = value
        End Set
    End Property

    Private FID As Integer
    Public Overridable Property ID() As Integer Implements IPost.ID
        Get
            Return FID
        End Get
        Set(ByVal value As Integer)
            FID = value
        End Set
    End Property

    Private FIntro As String
    Public Overridable Property Intro() As String Implements IPost.Intro
        Get
            Return FIntro
        End Get
        Set(ByVal value As String)
            FIntro = value
        End Set
    End Property

    Private FIsDelete As Boolean
    Public Overridable Property IsDelete() As Boolean Implements IPost.IsDelete
        Get
            Return FIsDelete
        End Get
        Set(ByVal value As Boolean)
            FIsDelete = value
        End Set
    End Property

    Private FIsDisable As Boolean
    Public Overridable Property IsDisable() As Boolean Implements IPost.IsDisable
        Get
            Return FIsDisable
        End Get
        Set(ByVal value As Boolean)
            FIsDisable = value
        End Set
    End Property

    Private FIsUnaudited As Boolean
    Public Overridable Property IsUnaudited() As Boolean Implements IPost.IsUnaudited
        Get
            Return FIsUnaudited
        End Get
        Set(ByVal value As Boolean)
            FIsUnaudited = value
        End Set
    End Property

    Private FModifiTime As Date
    Public Overridable Property ModifiTime() As Date Implements IPost.ModifiTime
        Get
            Return FModifiTime
        End Get
        Set(ByVal value As Date)
            FModifiTime = value
        End Set
    End Property

    Private FName As String
    Public Overridable Property Name() As String Implements IPost.Name
        Get
            Return FName
        End Get
        Set(ByVal value As String)
            FName = value
        End Set
    End Property

    Private FNote As String
    Public Overridable Property Note() As String Implements IPost.Note
        Get
            Return FNote
        End Get
        Set(ByVal value As String)
            FNote = value
        End Set
    End Property

    Private FParentGUID As Guid
    Public Overridable Property ParentGUID() As Guid Implements IPost.ParentGUID
        Get
            Return FParentGUID
        End Get
        Set(ByVal value As Guid)
            FParentGUID = value
        End Set
    End Property

    Private FSiteGUID As Guid
    Public Overridable Property SiteGUID() As Guid Implements IPost.SiteGUID
        Get
            Return FSiteGUID
        End Get
        Set(ByVal value As Guid)
            FSiteGUID = value
        End Set
    End Property

    Private FUserGUID As Guid
    Public Overridable Property UserGUID() As Guid Implements IPost.UserGUID
        Get
            Return FUserGUID
        End Get
        Set(ByVal value As Guid)
            FUserGUID = value
        End Set
    End Property

    Private FGUID As System.Guid
    Public Overridable Property GUID() As System.Guid Implements IPost.GUID
        Get
            Return FGUID
        End Get
        Set(ByVal value As System.Guid)
            FGUID = value
        End Set
    End Property

    'Private FMetaItems As System.Collections.Generic.List(Of Common.Meta)
    'Public Overridable Property MetaItems() As System.Collections.Generic.List(Of Common.Meta) Implements IArticle.MetaItems
    '    Get
    '        Return FMetaItems
    '    End Get
    '    Set(ByVal value As System.Collections.Generic.List(Of Common.Meta))
    '        FMetaItems = value
    '    End Set
    'End Property

    'Private FUrl As String
    'Public Overridable ReadOnly Property Url() As String Implements IArticle.Url
    '    Get
    '        Return FUrl
    '    End Get
    'End Property

    'Private FCategorysGUID As System.Collections.Generic.List(Of Guid)
    'Public Overridable Property TagsGUID() As System.Collections.Generic.List(Of Guid) Implements IPost.TagsGUID
    '    Get
    '        Return FCategorysGUID
    '    End Get
    '    Set(ByVal value As System.Collections.Generic.List(Of Guid))
    '        FCategorysGUID = value
    '    End Set
    'End Property

    Private FCommentNums As Integer
    Public Overridable Property CommentNums() As Integer Implements IPost.CommentNums
        Get
            Return FCommentNums
        End Get
        Set(ByVal value As Integer)
            FCommentNums = value
        End Set
    End Property

    Private FIsClose As Boolean
    Public Overridable Property IsClose() As Boolean Implements IPost.IsClose
        Get
            Return FIsClose
        End Get
        Set(ByVal value As Boolean)
            FIsClose = value
        End Set
    End Property

    Private FIsDraft As Boolean
    Public Overridable Property IsDraft() As Boolean Implements IPost.IsDraft
        Get
            Return FIsDraft
        End Get
        Set(ByVal value As Boolean)
            FIsDraft = value
        End Set
    End Property

    Private FIsPrivate As Boolean
    Public Overridable Property IsPrivate() As Boolean Implements IPost.IsPrivate
        Get
            Return FIsPrivate
        End Get
        Set(ByVal value As Boolean)
            FIsPrivate = value
        End Set
    End Property

    Private FIsTop As Boolean
    Public Overridable Property IsTop() As Boolean Implements IPost.IsTop
        Get
            Return FIsTop
        End Get
        Set(ByVal value As Boolean)
            FIsTop = value
        End Set
    End Property

    Private FCategoryGUID As Guid
    Public Overridable Property CategoryGUID() As Guid Implements IPost.CategoryGUID
        Get
            Return FCategoryGUID
        End Get
        Set(ByVal value As Guid)
            FCategoryGUID = value
        End Set
    End Property

    Private FType As PostType
    Public Overridable Property Type() As PostType Implements IPost.Type
        Get
            Return FType
        End Get
        Set(ByVal value As PostType)
            FType = value
        End Set
    End Property

    Private FViewNums As Integer
    Public Overridable Property ViewNums() As Integer Implements IPost.ViewNums
        Get
            Return FViewNums
        End Get
        Set(ByVal value As Integer)
            FViewNums = value
        End Set
    End Property

    Private FMeta As New Common.ItemConfig(Of Common.Item)
    Public Overridable Property Meta() As Common.ItemConfig(Of Common.Item) Implements IPost.Meta
        Get
            Return FMeta
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))
            FMeta = value
        End Set
    End Property

    Private FSource As String
    Public Property Source() As String Implements IPost.Source
        Get
            Return FSource
        End Get
        Set(ByVal value As String)
            FSource = value
        End Set
    End Property

End Class