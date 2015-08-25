''' <summary>
''' User
''' </summary>
''' <remarks></remarks>
Public Class User : Inherits BaseEntry

    Implements IUser

    Private FAliasName As String
    Public Overridable Property AliasName() As String Implements IUser.AliasName
        Get
            Return FAliasName
        End Get
        Set(ByVal value As String)
            FAliasName = value
        End Set
    End Property

    Private FContent As String
    Public Overridable Property Content() As String Implements IUser.Content
        Get
            Return FContent
        End Get
        Set(ByVal value As String)
            FContent = value
        End Set
    End Property

    Private FCreateTime As Date
    Public Overridable Property CreateTime() As Date Implements IUser.CreateTime
        Get
            Return FCreateTime
        End Get
        Set(ByVal value As Date)
            FCreateTime = value
        End Set
    End Property

    Private FID As Integer
    Public Overridable Property ID() As Integer Implements IUser.ID
        Get
            Return FID
        End Get
        Set(ByVal value As Integer)
            FID = value
        End Set
    End Property

    Private FIntro As String
    Public Overridable Property Intro() As String Implements IUser.Intro
        Get
            Return FIntro
        End Get
        Set(ByVal value As String)
            FIntro = value
        End Set
    End Property

    Private FIsDelete As Boolean
    Public Overridable Property IsDelete() As Boolean Implements IUser.IsDelete
        Get
            Return FIsDelete
        End Get
        Set(ByVal value As Boolean)
            FIsDelete = value
        End Set
    End Property

    Private FIsDisable As Boolean
    Public Overridable Property IsDisable() As Boolean Implements IUser.IsDisable
        Get
            Return FIsDisable
        End Get
        Set(ByVal value As Boolean)
            FIsDisable = value
        End Set
    End Property

    Private FIsUnaudited As Boolean
    Public Overridable Property IsUnaudited() As Boolean Implements IUser.IsUnaudited
        Get
            Return FIsUnaudited
        End Get
        Set(ByVal value As Boolean)
            FIsUnaudited = value
        End Set
    End Property

    Private FModifiTime As Date
    Public Overridable Property ModifiTime() As Date Implements IUser.ModifiTime
        Get
            Return FModifiTime
        End Get
        Set(ByVal value As Date)
            FModifiTime = value
        End Set
    End Property

    Private FName As String
    Public Overridable Property Name() As String Implements IUser.Name
        Get
            Return FName
        End Get
        Set(ByVal value As String)
            FName = value
        End Set
    End Property

    Private FNote As String
    Public Overridable Property Note() As String Implements IUser.Note
        Get
            Return FNote
        End Get
        Set(ByVal value As String)
            FNote = value
        End Set
    End Property

    Private FParentGUID As Guid
    Public Overridable Property ParentGUID() As Guid Implements IUser.ParentGUID
        Get
            Return FParentGUID
        End Get
        Set(ByVal value As Guid)
            FParentGUID = value
        End Set
    End Property

    Private FSiteGUID As Guid
    Public Overridable Property SiteGUID() As Guid Implements IUser.SiteGUID
        Get
            Return FSiteGUID
        End Get
        Set(ByVal value As Guid)
            FSiteGUID = value
        End Set
    End Property

    Private FUserGUID As Guid
    Public Overridable Property UserGUID() As Guid Implements IUser.UserGUID
        Get
            Return FUserGUID
        End Get
        Set(ByVal value As Guid)
            FUserGUID = value
        End Set
    End Property

    Private FGUID As System.Guid
    Public Overridable Property GUID() As System.Guid Implements IUser.GUID
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

    Private FCommentNums As Integer
    Public Overridable Property CommentNums() As Integer Implements IUser.CommentNums
        Get
            Return FCommentNums
        End Get
        Set(ByVal value As Integer)
            FCommentNums = value
        End Set
    End Property

    Private FEmail As String
    Public Overridable Property Email() As String Implements IUser.Email
        Get
            Return FEmail
        End Get
        Set(ByVal value As String)
            FEmail = value
        End Set
    End Property

    Private FHomePage As String
    Public Overridable Property HomePage() As String Implements IUser.HomePage
        Get
            Return FHomePage
        End Get
        Set(ByVal value As String)
            FHomePage = value
        End Set
    End Property

    Private FLevel As Integer
    Public Overridable Property Level() As Integer Implements IUser.Level
        Get
            Return FLevel
        End Get
        Set(ByVal value As Integer)
            FLevel = value
        End Set
    End Property

    Private FPassword As String
    Public Overridable Property Password() As String Implements IUser.Password
        Get
            Return FPassword
        End Get
        Set(ByVal value As String)
            FPassword = value
        End Set
    End Property

    Private FPostNums As Integer
    Public Overridable Property PostNums() As Integer Implements IUser.PostNums
        Get
            Return FPostNums
        End Get
        Set(ByVal value As Integer)
            FPostNums = value
        End Set
    End Property

    Private FMeta As New Common.ItemConfig(Of Common.Item)
    Public Overridable Property Meta() As Common.ItemConfig(Of Common.Item) Implements IUser.Meta
        Get
            Return FMeta
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))
            FMeta = value
        End Set
    End Property

End Class