''' <summary>
''' Comment
''' </summary>
''' <remarks></remarks>
Public Class Comment : Inherits BaseEntry

    Implements IMessage

    Private FAliasName As String
    Public Overridable Property AliasName() As String Implements IMessage.AliasName
        Get
            Return FAliasName
        End Get
        Set(ByVal value As String)
            FAliasName = value
        End Set
    End Property

    Private FContent As String
    Public Overridable Property Content() As String Implements IMessage.Content
        Get
            Return FContent
        End Get
        Set(ByVal value As String)
            FContent = value
        End Set
    End Property

    Private FCreateTime As Date
    Public Overridable Property CreateTime() As Date Implements IMessage.CreateTime
        Get
            Return FCreateTime
        End Get
        Set(ByVal value As Date)
            FCreateTime = value
        End Set
    End Property

    Private FID As Integer
    Public Overridable Property ID() As Integer Implements IMessage.ID
        Get
            Return FID
        End Get
        Set(ByVal value As Integer)
            FID = value
        End Set
    End Property

    Private FIntro As String
    Public Overridable Property Intro() As String Implements IMessage.Intro
        Get
            Return FIntro
        End Get
        Set(ByVal value As String)
            FIntro = value
        End Set
    End Property

    Private FIsDelete As Boolean
    Public Overridable Property IsDelete() As Boolean Implements IMessage.IsDelete
        Get
            Return FIsDelete
        End Get
        Set(ByVal value As Boolean)
            FIsDelete = value
        End Set
    End Property

    Private FIsDisable As Boolean
    Public Overridable Property IsDisable() As Boolean Implements IMessage.IsDisable
        Get
            Return FIsDisable
        End Get
        Set(ByVal value As Boolean)
            FIsDisable = value
        End Set
    End Property

    Private FIsUnaudited As Boolean
    Public Overridable Property IsUnaudited() As Boolean Implements IMessage.IsUnaudited
        Get
            Return FIsUnaudited
        End Get
        Set(ByVal value As Boolean)
            FIsUnaudited = value
        End Set
    End Property

    Private FModifiTime As Date
    Public Overridable Property ModifiTime() As Date Implements IMessage.ModifiTime
        Get
            Return FModifiTime
        End Get
        Set(ByVal value As Date)
            FModifiTime = value
        End Set
    End Property

    Private FName As String
    Public Overridable Property Name() As String Implements IMessage.Name
        Get
            Return FName
        End Get
        Set(ByVal value As String)
            FName = value
        End Set
    End Property

    Private FNote As String
    Public Overridable Property Note() As String Implements IMessage.Note
        Get
            Return FNote
        End Get
        Set(ByVal value As String)
            FNote = value
        End Set
    End Property

    Private FParentID As System.Guid
    Public Overridable Property ParentGUID() As System.Guid Implements IMessage.ParentGUID
        Get
            Return FParentID
        End Get
        Set(ByVal value As System.Guid)
            FParentID = value
        End Set
    End Property

    Private FSiteID As System.Guid
    Public Overridable Property SiteGUID() As System.Guid Implements IMessage.SiteGUID
        Get
            Return FSiteID
        End Get
        Set(ByVal value As System.Guid)
            FSiteID = value
        End Set
    End Property

    Private FUserID As System.Guid
    Public Overridable Property UserGUID() As System.Guid Implements IMessage.UserGUID
        Get
            Return FUserID
        End Get
        Set(ByVal value As System.Guid)
            FUserID = value
        End Set
    End Property

    Private FGUID As System.Guid
    Public Overridable Property GUID() As System.Guid Implements IMessage.GUID
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

    Private FEmail As String
    Public Overridable Property Email() As String Implements IMessage.Email
        Get
            Return FEmail
        End Get
        Set(ByVal value As String)
            FEmail = value
        End Set
    End Property

    Private FHomePage As String
    Public Overridable Property HomePage() As String Implements IMessage.HomePage
        Get
            Return FHomePage
        End Get
        Set(ByVal value As String)
            FHomePage = value
        End Set
    End Property

    Private FIP As String
    Public Overridable Property IP() As String Implements IMessage.IP
        Get
            Return FIP
        End Get
        Set(ByVal value As String)
            FIP = value
        End Set
    End Property

    Private FPostGUID As System.Guid
    Public Overridable Property PostGUID() As System.Guid Implements IMessage.PostGUID
        Get
            Return FPostGUID
        End Get
        Set(ByVal value As System.Guid)
            FPostGUID = value
        End Set
    End Property

    Private FMeta As New Common.ItemConfig(Of Common.Item)
    Public Overridable Property Meta() As Common.ItemConfig(Of Common.Item) Implements IMessage.Meta
        Get
            Return FMeta
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))
            FMeta = value
        End Set
    End Property
End Class