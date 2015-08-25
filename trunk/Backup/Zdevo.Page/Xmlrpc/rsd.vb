Namespace [Xmlrpc]
    Public Class [Rsd]
        Inherits Zdevo.Page.XmlrpcPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Context.Response.ContentType = "text/xml"

            Dim b As Boolean
            b = Me.System_Initialize

            Dim ms As New System.IO.MemoryStream
            Dim wr As New System.Xml.XmlTextWriter(ms, New System.Text.UTF8Encoding(False))

            wr.WriteStartDocument(True)
            wr.WriteStartElement("rsd")
            wr.WriteAttributeString("version", "1.0")
            wr.WriteStartElement("service")

            wr.WriteElementString("engineName", Me.Container.Config("APPLICATION_PRODUCT_NAME").Value)
            wr.WriteElementString("engineLink", "http://www.zdevo.com/")
            wr.WriteElementString("homePageLink", Me.Container.Site.Host)

            wr.WriteStartElement("apis")

            wr.WriteStartElement("api")
            wr.WriteAttributeString("name", "MetaWeblog")
            wr.WriteAttributeString("preferred", "true")
            wr.WriteAttributeString("apiLink", Me.Container.Site.XmlRpcUrl)
            wr.WriteAttributeString("blogID", "1")
            wr.WriteEndElement()

            wr.WriteStartElement("api")
            wr.WriteAttributeString("name", "Blogger")
            wr.WriteAttributeString("preferred", "flase")
            wr.WriteAttributeString("apiLink", Me.Container.Site.XmlRpcUrl)
            wr.WriteAttributeString("blogID", "1")
            wr.WriteEndElement()

            wr.WriteEndElement()


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
