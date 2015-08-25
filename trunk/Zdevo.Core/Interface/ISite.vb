Public Interface ISite

    Property ID() As Integer
    Property GUID() As System.Guid

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

    Property UserNums() As Integer
    Property CategoryNums() As Integer
    Property PostNums() As Integer
    Property CommentNums() As Integer
    Property ViewNums() As Integer

    Property Meta() As Common.ItemConfig(Of Common.Item)

End Interface