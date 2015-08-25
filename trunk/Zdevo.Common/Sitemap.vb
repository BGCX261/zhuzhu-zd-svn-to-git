Public Class Sitemap

    Structure Item
        Public loc As String
        Public lastmod As String
    End Structure

    Private Items As New System.Collections.Generic.List(Of Item)

    Private XmlDocument As Xml.XmlDocument


    Public Sub New()
        XmlDocument = New Xml.XmlDocument
    End Sub

    Public Function AddItem(ByVal it As Item) As Boolean
        If it.lastmod <> String.Empty Then
            it.lastmod = System.DateTime.Parse(it.lastmod).ToString("yyyy-MM-ddTHH:mm:sszzz")
        End If
        Items.Add(it)
    End Function

    Private FXml As String
    Public Property Xml() As String
        Get

            Dim ms As New MemoryStream
            Dim wr As New System.Xml.XmlTextWriter(ms, New System.Text.UTF8Encoding(False))

            wr.WriteStartDocument(True)
            wr.WriteStartElement("urlset")
            wr.WriteAttributeString("xmlns", "http://www.google.com/schemas/sitemap/0.84")
            For Each it As Item In Items
                wr.WriteStartElement("url")
                For Each f As System.Reflection.FieldInfo In it.GetType.GetFields()
                    Dim s As String = CStr(f.GetValue(it))
                    If s <> String.Empty Then
                        wr.WriteElementString(f.Name, s)
                    End If
                Next
                wr.WriteEndElement()
            Next
            wr.WriteEndElement()
            wr.Close()


            FXml = System.Text.Encoding.UTF8.GetString(ms.ToArray)
            Return FXml
        End Get
        Set(ByVal value As String)
            FXml = value
        End Set
    End Property

End Class
