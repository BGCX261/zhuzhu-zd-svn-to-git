Public Interface IUser

    Property ID() As Integer
    Property GUID() As System.Guid
    'Property MetaItems() As System.Collections.Generic.List(Of Common.Meta)
    'Property Url() As String

    Property IsDisable() As Boolean
    Property IsUnaudited() As Boolean
    Property IsDelete() As Boolean

    Property Name() As String
    Property AliasName() As String
    Property Intro() As String
    Property Content() As String
    Property Note() As String

    Property CreateTime() As DateTime
    Property ModifiTime() As DateTime

    Property ParentGUID() As Guid
    Property SiteGUID() As Guid
    Property UserGUID() As Guid


    Property Level() As Integer
    Property Password() As String

    Property Email() As String
    Property HomePage() As String

    Property PostNums() As Integer
    Property CommentNums() As Integer

    Property Meta() As Common.ItemConfig(Of Common.Item)

End Interface