Public Class Tag

    Inherits Core.Category

    Private FContainer As Container
    Protected Overloads Property Container() As Container
        Get
            Return FContainer
        End Get
        Set(ByVal value As Container)
            FContainer = value
        End Set
    End Property

    Public Sub New(ByVal nowContainer As Container)
        Container = nowContainer
    End Sub

    Public Overrides Property NodeString() As String
        Get
            If String.IsNullOrEmpty(MyBase.NodeString) Then

                Dim sb As New Text.StringBuilder
                Dim wr As New Xml.XmlTextWriter(New IO.StringWriter(sb))

                wr.WriteStartElement("tag")

                wr.WriteElementString("id", Xml.XmlConvert.ToString(Me.ID))
                wr.WriteElementString("guid", Xml.XmlConvert.ToString(Me.GUID))
                wr.WriteElementString("url", Me.Url)
                wr.WriteElementString("name", Me.Name)
                wr.WriteElementString("intro", Me.Intro)
                wr.WriteElementString("articlenums", Xml.XmlConvert.ToString(Me.PostNums))

                wr.WriteEndElement()

                wr.Close()

                MyBase.NodeString = sb.ToString
            End If
            Return MyBase.NodeString
        End Get
        Set(ByVal value As String)
            MyBase.NodeString = value
        End Set
    End Property

End Class
