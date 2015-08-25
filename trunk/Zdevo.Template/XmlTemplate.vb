''' <summary>
''' XmlPage
''' </summary>
''' <remarks></remarks>
Public Class XmlTemplate : Inherits BaseTemplate



    Private XsltFile As Xml.Xsl.XslCompiledTransform


    Private FHtml As String
    Public Overrides ReadOnly Property Html() As String
        Get

            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8

            'If InStr(System.Web.HttpContext.Current.Request.ServerVariables("HTTP_ACCEPT"), "application/xhtml+xml") > 0 Then
            'System.Web.HttpContext.Current.Response.ContentType = "application/xhtml+xml"
            'End If

            FHtml = "<?xml version=""1.0"" encoding=""UTF-8""?>" + vbCrLf + "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">" + vbCrLf + FHtml

            Html = FHtml

        End Get
    End Property


    Public Overridable ReadOnly Property HtmlSegment() As String
        Get

            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8

            If InStr(System.Web.HttpContext.Current.Request.ServerVariables("HTTP_ACCEPT"), "application/xhtml+xml") > 0 Then
                System.Web.HttpContext.Current.Response.ContentType = "application/xhtml+xml"
            End If

            'FHtml = FHtml.Replace("xmlns=""""", "")
            'FHtml = FHtml.Replace("<?xml version=""1.0"" encoding=""utf-16""?>", "")

            HtmlSegment = FHtml

        End Get
    End Property

    Public Overrides Function Parse(ByVal Content As String) As Boolean

        'Dim objXslt As New Xml.Xsl.XslCompiledTransform

        'objXslt.Load(New Xml.XmlTextReader(New System.IO.StringReader("")))

        'Dim sbHtml As System.Text.StringBuilder = New System.Text.StringBuilder()

        Dim ms As New IO.MemoryStream
        Dim wr As New System.Xml.XmlTextWriter(ms, New System.Text.UTF8Encoding(False))
        wr.Formatting = Xml.Formatting.Indented

        'wr.WriteStartDocument()
        'wr.WriteDocType("html", "-//W3C//DTD XHTML 1.1//EN", "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd", Nothing)

        XsltFile.Transform(New Xml.XPath.XPathDocument(New System.IO.StringReader(Content)), wr)

        'objXslt.Transform(New Xml.XmlTextReader(New System.IO.StringReader(Content)), wr)
        'objXslt.Transform(New Xml.XmlTextReader(New System.IO.StringReader(Content)), Nothing, New System.IO.StringWriter(sbHtml))

        FHtml = System.Text.Encoding.UTF8.GetString(ms.ToArray)

        Return True

    End Function

    'Public Overloads Function Parse(ByVal XmlDocument As Xml.XmlDocument) As Boolean


    '    Dim objXslt As New Xml.Xsl.XslCompiledTransform
    '    objXslt.Load(Template)

    '    Dim sbHtml As System.Text.StringBuilder = New System.Text.StringBuilder()
    '    objXslt.Transform(XmlDocument, Nothing, New System.IO.StringWriter(sbHtml))

    '    FHtml = sbHtml.ToString

    '    Return True

    'End Function

    Private FTemplate As String
    Public Overrides Property Template() As String
        Get
            Template = FTemplate
        End Get
        Set(ByVal value As String)
            FTemplate = value

            XsltFile.Load(FTemplate)

        End Set
    End Property


    Private FTemplateString As String
    Public Overridable Property TemplateString() As String
        Get
            TemplateString = FTemplateString
        End Get
        Set(ByVal value As String)
            FTemplateString = value

            XsltFile.Load(New Xml.XmlTextReader(New IO.StringReader(FTemplateString)))

        End Set
    End Property


    Public Sub New()
        XsltFile = New Xml.Xsl.XslCompiledTransform
    End Sub
End Class