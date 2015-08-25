''' <summary>
''' PageBar
''' </summary>
''' <remarks></remarks>
Public Class PageBar : Inherits BaseEntry

    Public PageAll As Integer
    Public PageNow As Integer
    Public PageFrist As Integer
    Public PageLast As Integer
    Public PagePrevious As Integer
    Public PageNext As Integer
    Public PageLength As Integer
    Public PageBegin As Integer
    Public PageEnd As Integer


    Public Overridable Function Make(ByVal intPageCount As Integer, ByVal intPage As Integer, ByVal intCountAll As Integer, ByVal intPageBarLength As Integer, ByVal RegexAlias As String, ByVal PathRegexConfig As Common.ItemConfig(Of Common.Item)) As Boolean
        PageLength = intPageBarLength
        PageAll = CInt(IIf(intCountAll Mod intPageCount > 0, intCountAll \ intPageCount + 1, intCountAll \ intPageCount))
        PageNow = intPage

        PageFrist = 1
        PageLast = PageAll

        PagePrevious = CInt(IIf(PageNow - 1 < 1, 1, PageNow - 1))
        PageNext = CInt(IIf(PageNow + 1 > PageAll, PageAll, PageNow + 1))

        PageBegin = PageNow
        PageEnd = PageBegin + PageLength - 1
        If PageEnd > PageAll Then
            PageEnd = PageAll
            PageBegin = PageAll - PageLength + 1
            If PageBegin < 1 Then
                PageBegin = 1
            End If
        End If

        Dim strUrl As String = ""

        Dim sb As New StringBuilder
        Dim wr As New XmlTextWriter(New StringWriter(sb))

        wr.WriteStartElement("pagebar")

        wr.WriteStartElement("pagenow")
        PathRegexConfig("{%Page%}").Value = CStr(IIf(PageNow = 1, "default", PageNow))
        strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
        wr.WriteElementString("url", strUrl)
        wr.WriteElementString("number", XmlConvert.ToString(PageNow))
        wr.WriteEndElement()

        wr.WriteStartElement("pagefrist")
        PathRegexConfig("{%Page%}").Value = CStr(IIf(PageFrist = 1, "default", PageFrist))
        strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
        wr.WriteElementString("url", strUrl)
        wr.WriteElementString("number", XmlConvert.ToString(PageFrist))
        wr.WriteEndElement()

        wr.WriteStartElement("pagelast")
        PathRegexConfig("{%Page%}").Value = CStr(IIf(PageLast = 1, "default", PageLast))
        strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
        wr.WriteElementString("url", strUrl)
        wr.WriteElementString("number", XmlConvert.ToString(PageLast))
        wr.WriteEndElement()

        wr.WriteStartElement("pageprevious")
        PathRegexConfig("{%Page%}").Value = CStr(IIf(PagePrevious = 1, "default", PagePrevious))
        strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
        wr.WriteElementString("url", strUrl)
        wr.WriteElementString("number", XmlConvert.ToString(PagePrevious))
        wr.WriteEndElement()

        wr.WriteStartElement("pagenext")
        PathRegexConfig("{%Page%}").Value = CStr(IIf(PageNext = 1, "default", PageNext))
        strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
        wr.WriteElementString("url", strUrl)
        wr.WriteElementString("number", XmlConvert.ToString(PageNext))
        wr.WriteEndElement()


        For i As Integer = PageBegin To PageEnd
            wr.WriteStartElement("page")
            PathRegexConfig("{%Page%}").Value = CStr(IIf(i = 1, "default", i))
            strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
            wr.WriteElementString("url", strUrl)
            wr.WriteElementString("number", XmlConvert.ToString(i))
            wr.WriteEndElement()
        Next

        For i As Integer = PageFrist To PageLast
            wr.WriteStartElement("pageall")
            PathRegexConfig("{%Page%}").Value = CStr(IIf(i = 1, "default", i))
            strUrl = Common.Functions.Current.GetUrlbyRegex(RegexAlias, PathRegexConfig)
            wr.WriteElementString("url", strUrl)
            wr.WriteElementString("number", XmlConvert.ToString(i))
            wr.WriteEndElement()
        Next

        wr.WriteEndElement()
        NodeString = sb.ToString


    End Function

    Public Overrides Property NodeString() As String
        Get
            Return MyBase.NodeString
        End Get
        Set(ByVal value As String)
            MyBase.NodeString = value
        End Set
    End Property

End Class