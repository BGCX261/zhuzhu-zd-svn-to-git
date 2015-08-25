Public Class XmlSerialize(Of T)

    'Private Item As T

    Public Overridable Function DeSerialize(ByVal s As String) As T
        'Try
        Dim objXmlSer As New System.Xml.Serialization.XmlSerializer(GetType(T))
        Dim XmlReader As Xml.XmlTextReader = New XmlTextReader(New StringReader(s))
        Using XmlReader
            Return CType(objXmlSer.Deserialize(XmlReader), T)
        End Using

        'Dim objXmlSer As New System.Xml.Serialization.XmlSerializer(Item.GetType)
        'Dim XmlReader As Xml.XmlTextReader = New XmlTextReader(New StringReader(s))
        'Using XmlReader
        '    Return CType(objXmlSer.Deserialize(XmlReader), T)
        'End Using
        'Catch ex As Exception
        '    Throw ex
        'Finally

        'End Try
        'Return Nothing
    End Function


    Public Overridable Function Serialize(ByVal Item As T) As String
        'Try
        Dim objXmlSer As New System.Xml.Serialization.XmlSerializer(Item.GetType)
        Dim sb As New StringBuilder
        Dim XmlWrite As New Xml.XmlTextWriter(New StringWriter(sb))
        Using XmlWrite
            objXmlSer.Serialize(XmlWrite, Item)
        End Using
        Return sb.ToString
        'Catch ex As Exception
        '    Throw ex
        'Finally

        'End Try
    End Function

    'Public Sub New(ByVal newItem As T)
    '    Item = newItem
    'End Sub

End Class
