Namespace [Xmlrpc]
    Public Class [Wlwmanifest]
        Inherits Zdevo.Page.XmlrpcPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Context.Response.ContentType = "text/xml"

            Dim b As Boolean
            b = Me.System_Initialize

            Dim ms As New System.IO.MemoryStream
            Dim wr As New System.Xml.XmlTextWriter(ms, New System.Text.UTF8Encoding(False))

            wr.WriteStartDocument(True)
            wr.WriteStartElement("manifest")
            wr.WriteAttributeString("xmlns", "http://schemas.microsoft.com/wlw/manifest/weblog")
            wr.WriteStartElement("options")

            wr.WriteElementString("clientType", "Metaweblog")
            wr.WriteElementString("supportsKeywords", "Yes")
            wr.WriteElementString("supportsNewCategories", "Yes")
            wr.WriteElementString("supportsNewCategoriesInline", "Yes")
            wr.WriteElementString("supportsCommentPolicy", "Yes")
            wr.WriteElementString("supportsSlug", "Yes")
            wr.WriteElementString("supportsExcerpt", "Yes")
            wr.WriteElementString("supportsEmbeds", "Yes")
            wr.WriteElementString("supportsScripts", "Yes")
            wr.WriteElementString("supportsEmptyTitles", "No")
            wr.WriteElementString("requiresHtmlTitles", "No")
            wr.WriteElementString("supportsPostAsDraft", "Yes")
            wr.WriteElementString("supportsCustomDate", "Yes")
            wr.WriteElementString("supportsFileUpload", "Yes")
            wr.WriteElementString("supportsCategories", "Yes")
            wr.WriteElementString("supportsMultipleCategories", "No")

            wr.WriteEndElement()
            wr.WriteEndElement()
            wr.Close()

            Context.Response.Write(System.Text.Encoding.UTF8.GetString(ms.ToArray))

            If b = True Then
                System_Terminate()
            End If

        End Sub

        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
