Public Interface ITemplate

    'Function Parse(ByVal XmlDocument As Xml.XmlDocument) As Boolean

    Function Parse(ByVal Content As String) As Boolean

    ReadOnly Property Html() As String

    Property Template() As String


End Interface
