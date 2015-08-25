Public MustInherit Class BaseEntry

    Implements ICloneable

    Public Overridable Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

    'Private FXmlDocument As Xml.XmlDocument
    'Protected Overridable Property XmlDocument() As Xml.XmlDocument
    '    Get
    '        Return Container.XmlDocument
    '    End Get
    '    Set(ByVal value As Xml.XmlDocument)
    '        Container.XmlDocument = value
    '    End Set
    'End Property

    Private FContainer As BaseContainer = Nothing
    Protected Overridable Property Container() As BaseContainer
        Get
            Return FContainer
        End Get
        Set(ByVal value As BaseContainer)
            FContainer = value
        End Set
    End Property


    Private FNodeString As String = ""
    Public Overridable Property NodeString() As String
        Get
            Return FNodeString
        End Get
        Set(ByVal value As String)
            FNodeString = value
        End Set
    End Property


    Private FUrl As String = ""
    Public Overridable ReadOnly Property Url() As String
        Get
            Return FUrl
        End Get
    End Property

    'Private FMeta As New Common.Config(Of Common.Item)
    'Public Overridable Property Meta() As Common.Config(Of Common.Item)
    '    Get
    '        Return FMeta
    '    End Get
    '    Set(ByVal value As Common.Config(Of Common.Item))
    '        FMeta = value
    '    End Set
    'End Property

End Class