''' <summary>
''' BASE 
''' </summary>
''' <remarks></remarks>
Public MustInherit Class BaseTemplate

    Implements ITemplate

    Public MustOverride ReadOnly Property Html() As String Implements ITemplate.Html

    Public MustOverride Function Parse(ByVal Content As String) As Boolean Implements ITemplate.Parse

    Public MustOverride Property Template() As String Implements ITemplate.Template

    'Public MustOverride Function Parse(ByVal XmlDocument As System.Xml.XmlDocument) As Boolean Implements ITemplate.Parse

End Class
