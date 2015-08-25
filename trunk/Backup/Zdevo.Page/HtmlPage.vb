Public Class HtmlPage

    Inherits Zdevo.Page.BasePage

    Public HeadTitle As String = ""
    Public ColumnNow As String = ""
    Public PageNow As String = ""

    Private XmlString As System.Text.StringBuilder
    Private XmlWriter As System.Xml.XmlTextWriter
    Private XmlPage As Zdevo.Template.XmlTemplate


    Public Overridable Sub StartXML()
        XmlString = New System.Text.StringBuilder
        XmlWriter = New System.Xml.XmlTextWriter(New System.IO.StringWriter(XmlString))

        XmlWriter.WriteStartElement("zdevo")
        XmlWriter.WriteStartElement("data")
    End Sub

    Public Overridable Sub EndXML()

        XmlWriter.WriteElementString("headtitle", Me.HeadTitle)
        XmlWriter.WriteElementString("columnnow", Me.ColumnNow)
        XmlWriter.WriteElementString("pagenow", Me.PageNow)

        XmlWriter.WriteEndElement()
        XmlWriter.WriteEndElement()

        XmlWriter.Close()
    End Sub

    Public Overridable Function WriteXML() As System.Xml.XmlTextWriter
        Return Me.XmlWriter
    End Function


    Public Overridable Function GetXML() As System.Text.StringBuilder
        Return Me.XmlString
    End Function

    Public Overridable Function LoadXSLT(ByVal FileName As String) As Boolean

        XmlPage = New Zdevo.Template.XmlTemplate()
        XmlPage.Template = FileName

    End Function

    Public Overridable Function BuildXHTML() As String

        'My.Computer.FileSystem.WriteAllText("c:\a.xml", XmlString.ToString, False)

        XmlPage.Parse(XmlString.ToString)
        Return XmlPage.Html

    End Function

    Public Overridable Function BuildXHTMLSegment() As String

        XmlPage.Parse(XmlString.ToString)
        Return XmlPage.HtmlSegment

    End Function



    'Public Overridable Function zdevo_GetComment(ByVal Guid As Guid, ByVal Page As Integer, ByVal PageSize As Integer) As String

    '    Dim b As Boolean
    '    b = System_Initialize()

    '    Dim s As String = ""

    '    Dim commentlist As Zdevo.Core.SQLite.CommentList = Container.GetCommentList

    '    If commentlist.List(New String() {"Page", "PageSize", "PostGUID"}, New Object() {Page, PageSize, Guid}) = True Then

    '        StartXML()

    '        'For Each comment As Zdevo.Core.SQLite.Comment In commentlist.Items
    '        '   wr.WriteRaw(comment.NodeString)
    '        'Next

    '        For i As Integer = commentlist.Items.Count - 1 To 0 Step -1
    '            WriteXML.WriteRaw(commentlist.Items(i).NodeString)
    '        Next

    '        EndXML()

    '        LoadXSLT(Zdevo.Common.Utility.Current.MapPath("~\theme\default\template\comments.xsl"))

    '        s = Me.BuildXHTMLSegment

    '    End If

    '    Return s

    '    If b = True Then
    '        System_Terminate()
    '    End If

    'End Function


End Class

