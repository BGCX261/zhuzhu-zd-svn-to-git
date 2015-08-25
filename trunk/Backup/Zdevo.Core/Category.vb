''' <summary>
''' Category
''' </summary>
''' <remarks></remarks>
Public Class Category : Inherits BaseEntry

    Implements ICategory

    Private FAliasName As String
    Public Overridable Property AliasName() As String Implements ICategory.AliasName
        Get
            Return FAliasName
        End Get
        Set(ByVal value As String)
            FAliasName = value
        End Set
    End Property

    Private FContent As String
    Public Overridable Property Content() As String Implements ICategory.Content
        Get
            Return FContent
        End Get
        Set(ByVal value As String)
            FContent = value
        End Set
    End Property

    Private FCreateTime As Date
    Public Overridable Property CreateTime() As Date Implements ICategory.CreateTime
        Get
            Return FCreateTime
        End Get
        Set(ByVal value As Date)
            FCreateTime = value
        End Set
    End Property

    Private FID As Integer
    Public Overridable Property ID() As Integer Implements ICategory.ID
        Get
            Return FID
        End Get
        Set(ByVal value As Integer)
            FID = value
        End Set
    End Property

    Private FIntro As String
    Public Overridable Property Intro() As String Implements ICategory.Intro
        Get
            Return FIntro
        End Get
        Set(ByVal value As String)
            FIntro = value
        End Set
    End Property

    Private FIsDelete As Boolean
    Public Overridable Property IsDelete() As Boolean Implements ICategory.IsDelete
        Get
            Return FIsDelete
        End Get
        Set(ByVal value As Boolean)
            FIsDelete = value
        End Set
    End Property

    Private FIsDisable As Boolean
    Public Overridable Property IsDisable() As Boolean Implements ICategory.IsDisable
        Get
            Return FIsDisable
        End Get
        Set(ByVal value As Boolean)
            FIsDisable = value
        End Set
    End Property

    Private FIsUnaudited As Boolean
    Public Overridable Property IsUnaudited() As Boolean Implements ICategory.IsUnaudited
        Get
            Return FIsUnaudited
        End Get
        Set(ByVal value As Boolean)
            FIsUnaudited = value
        End Set
    End Property

    Private FModifiTime As Date
    Public Overridable Property ModifiTime() As Date Implements ICategory.ModifiTime
        Get
            Return FModifiTime
        End Get
        Set(ByVal value As Date)
            FModifiTime = value
        End Set
    End Property

    Private FName As String
    Public Overridable Property Name() As String Implements ICategory.Name
        Get
            Return FName
        End Get
        Set(ByVal value As String)
            FName = value
        End Set
    End Property

    Private FNote As String
    Public Overridable Property Note() As String Implements ICategory.Note
        Get
            Return FNote
        End Get
        Set(ByVal value As String)
            FNote = value
        End Set
    End Property

    Private FParentGUID As Guid
    Public Overridable Property ParentGUID() As Guid Implements ICategory.ParentGUID
        Get
            Return FParentGUID
        End Get
        Set(ByVal value As Guid)
            FParentGUID = value
        End Set
    End Property

    Private FSiteGUID As Guid
    Public Overridable Property SiteGUID() As Guid Implements ICategory.SiteGUID
        Get
            Return FSiteGUID
        End Get
        Set(ByVal value As Guid)
            FSiteGUID = value
        End Set
    End Property

    Private FUserGUID As Guid
    Public Overridable Property UserGUID() As Guid Implements ICategory.UserGUID
        Get
            Return FUserGUID
        End Get
        Set(ByVal value As Guid)
            FUserGUID = value
        End Set
    End Property

    Private FGUID As System.Guid
    Public Overridable Property GUID() As System.Guid Implements ICategory.GUID
        Get
            Return FGUID
        End Get
        Set(ByVal value As System.Guid)
            FGUID = value
        End Set
    End Property

    'Private FMetaItems As System.Collections.Generic.List(Of Common.Meta)
    'Public Overridable Property MetaItems() As System.Collections.Generic.List(Of Common.Meta) Implements ICategory.MetaItems
    '    Get
    '        Return FMetaItems
    '    End Get
    '    Set(ByVal value As System.Collections.Generic.List(Of Common.Meta))
    '        FMetaItems = value
    '    End Set
    'End Property


    'Private FUrl As String
    'Public Overridable ReadOnly Property Url() As String Implements ICategory.Url
    '    Get
    '        Return FUrl
    '    End Get
    'End Property

    Private FOrder As Integer
    Public Overridable Property Order() As Integer Implements ICategory.Order
        Get
            Return FOrder
        End Get
        Set(ByVal value As Integer)
            FOrder = value
        End Set
    End Property

    Private FPostNums As Integer
    Public Overridable Property PostNums() As Integer Implements ICategory.PostNums
        Get
            Return FPostNums
        End Get
        Set(ByVal value As Integer)
            FPostNums = value
        End Set
    End Property

    Private FType As CategoryType
    Public Overridable Property Type() As CategoryType Implements ICategory.Type
        Get
            Return FType
        End Get
        Set(ByVal value As CategoryType)
            FType = value
        End Set
    End Property

    Private FMeta As New Common.ItemConfig(Of Common.Item)
    Public Overridable Property Meta() As Common.ItemConfig(Of Common.Item) Implements ICategory.Meta
        Get
            Return FMeta
        End Get
        Set(ByVal value As Common.ItemConfig(Of Common.Item))
            FMeta = value
        End Set
    End Property
End Class