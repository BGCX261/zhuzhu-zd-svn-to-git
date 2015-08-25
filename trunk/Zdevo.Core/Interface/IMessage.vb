Public Interface IMessage

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

    Property ParentGUID() As System.Guid
    Property SiteGUID() As System.Guid
    Property UserGUID() As System.Guid


    Property Email() As String
    Property HomePage() As String

    Property PostGUID() As System.Guid

    Property IP() As String

    Property Meta() As Common.ItemConfig(Of Common.Item)

End Interface