''' <summary>
''' Site
''' </summary>
''' <remarks></remarks>
Public Class Site : Inherits BaseEntry

    Implements ISite

    Structure Column
        Public Id As String
        Public Name As String
        Public Url As String
        Public Order As Integer
        Public RssUrl As String
    End Structure


    Private FAliasName As String
    Public Overridable Property AliasName() As String Implements ISite.AliasName
        Get
            Return FAliasName
        End Get
        Set(ByVal value As String)
            FAliasName = value
        End Set
    End Property

    Private FContent As String
    Public Overridable Property Content() As String Implements ISite.Content
        Get
            Return FContent
        End Get
        Set(ByVal value As String)
            FContent = value
        End Set
    End Property

    Private FCreateTime As Date
    Public Overridable Property CreateTime() As Date Implements ISite.CreateTime
        Get
            Return FCreateTime
        End Get
        Set(ByVal value As Date)
            FCreateTime = value
        End Set
    End Property

    Private FID As Integer
    Public Overridable Property ID() As Integer Implements ISite.ID
        Get
            Return FID
        End Get
        Set(ByVal value As Integer)
            FID = value
        End Set
    End Property

    Private FIntro As String
    Public Overridable Property Intro() As String Implements ISite.Intro
        Get
            Return FIntro
        End Get
        Set(ByVal value As String)
            FIntro = value
        End Set
    End Property

    Private FIsDelete As Boolean
    Public Overridable Property IsDelete() As Boolean Implements ISite.IsDelete
        Get
            Return FIsDelete
        End Get
        Set(ByVal value As Boolean)
            FIsDelete = value
        End Set
    End Property

    Private FIsDisable As Boolean
    Public Overridable Property IsDisable() As Boolean Implements ISite.IsDisable
        Get
            Return FIsDisable
        End Get
        Set(ByVal value As Boolean)
            FIsDisable = value
        End Set
    End Property

    Private FIsUnaudited As Boolean
    Public Overridable Property IsUnaudited() As Boolean Implements ISite.IsUnaudited
        Get
            Return FIsUnaudited
        End Get
        Set(ByVal value As Boolean)
            FIsUnaudited = value
        End Set
    End Property

    Private FModifiTime As Date
    Public Overridable Property ModifiTime() As Date Implements ISite.ModifiTime
        Get
            Return FModifiTime
        End Get
        Set(ByVal value As Date)
            FModifiTime = value
        End Set
    End Property

    Private FName As String
    Public Overridable Property Name() As String Implements ISite.Name
        Get
            Return FName
        End Get
        Set(ByVal value As String)
            FName = value
        End Set
    End Property

    Private FNote As String
    Public Overridable Property Note() As String Implements ISite.Note
        Get
            Return FNote
        End Get
        Set(ByVal value As String)
            FNote = value
        End Set
    End Property

    Private FParentGUID As Guid
    Public Overridable Property ParentGUID() As Guid Implements ISite.ParentGUID
        Get
            Return FParentGUID
        End Get
        Set(ByVal value As Guid)
            FParentGUID = value
        End Set
    End Property

    Private FSiteGUID As Guid
    Public Overridable Property SiteGUID() As Guid Implements ISite.SiteGUID
        Get
            Return FSiteGUID
        End Get
        Set(ByVal value As Guid)
            FSiteGUID = value
        End Set
    End Property

    Private FUserGUID As Guid
    Public Overridable Property UserGUID() As Guid Implements ISite.UserGUID
        Get
            Return FUserGUID
        End Get
        Set(ByVal value As Guid)
            FUserGUID = value
        End Set
    End Property

    Private FGUID As System.Guid
    Public Overridable Property GUID() As System.Guid Implements ISite.GUID
        Get
            Return FGUID
        End Get
        Set(ByVal value As System.Guid)
            FGUID = value
        End Set
    End Property

    'Private FMetaItems As System.Collections.Generic.List(Of Common.Meta)
    'Public Overridable Property MetaItems() As System.Collections.Generic.List(Of Common.Meta) Implements IMeta.MetaItems
    '    Get
    '        Return FMetaItems
    '    End Get
    '    Set(ByVal value As System.Collections.Generic.List(Of Common.Meta))
    '        FMetaItems = value
    '    End Set
    'End Property

    'Private FUrl As String
    'Public Overridable ReadOnly Property Url() As String Implements IUrl.Url
    '    Get
    '        Return FUrl
    '    End Get
    'End Property

    Private FCategoryNums As Integer
    Public Overridable Property CategoryNums() As Integer Implements ISite.CategoryNums
        Get
            Return FCategoryNums
        End Get
        Set(ByVal value As Integer)
            FCategoryNums = value
        End Set
    End Property

    Private FCommentNums As Integer
    Public Overridable Property CommentNums() As Integer Implements ISite.CommentNums
        Get
            Return FCommentNums
        End Get
        Set(ByVal value As Integer)
            FCommentNums = value
        End Set
    End Property

    Private FPostNums As Integer
    Public Overridable Property PostNums() As Integer Implements ISite.PostNums
        Get
            Return FPostNums
        End Get
        Set(ByVal value As Integer)
            FPostNums = value
        End Set
    End Property

    Private FUserNums As Integer
    Public Overridable Property UserNums() As Integer Implements ISite.UserNums
        Get
            Return FUserNums
        End Get
        Set(ByVal value As Integer)
            FUserNums = value
        End Set
    End Property

    'Private FUsersGUID As System.Collections.Generic.List(Of Guid)
    'Public Overridable Property UsersGUID() As System.Collections.Generic.List(Of Guid) Implements ISite.UsersGUID
    '    Get
    '        Return FUsersGUID
    '    End Get
    '    Set(ByVal value As System.Collections.Generic.List(Of Guid))
    '        FUsersGUID = value
    '    End Set
    'End Property

    Private FViewNums As Integer
    Public Overridable Property ViewNums() As Integer Implements ISite.ViewNums
        Get
            Return FViewNums
        End Get
        Set(ByVal value As Integer)
            FViewNums = value
        End Set
    End Property


    Private FMeta As New Common.ItemConfig(Of Common.Item)
    Public Overridable Property Meta() As Common.ItemConfig(Of Common.Item) Implements ISite.Meta
        Get
            Return FMeta
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))
            FMeta = value
        End Set
    End Property

End Class