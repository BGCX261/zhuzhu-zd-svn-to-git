Public Class Rss

    Structure Item
        Public title As String
        Public link As String
        Public description As String
        Public author As String
        Public category As String
        Public comments As String
        Public enclosure As String
        Public guid As String
        Public pubDate As String
        Public source As String
    End Structure

    Structure Channel
        Public title As String
        Public link As String
        Public description As String
        Public generator As String
        Public language As String
        Public copyright As String
        Public pubDate As String
    End Structure

    Private Items As New System.Collections.Generic.List(Of Item)
    Private Chan As New Channel

    Private XmlDocument As Xml.XmlDocument


    Public Sub New()
        XmlDocument = New Xml.XmlDocument
    End Sub

    Public Function AddItem(ByVal it As Item) As Boolean
        If it.pubDate <> String.Empty Then
            it.pubDate = System.DateTime.Parse(it.pubDate).ToUniversalTime.ToString("r", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'it.pubDate = Rss.ParseDateForRFC822(CType(it.pubDate, DateTime))
        End If
        Items.Add(it)
    End Function

    Public Function AddChannel(ByVal channel As Channel) As Boolean
        If channel.pubDate <> String.Empty Then
            channel.pubDate = System.DateTime.Parse(channel.pubDate).ToUniversalTime.ToString("r", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'channel.pubDate = Rss.ParseDateForRFC822(CType(channel.pubDate, DateTime))
        End If
        Chan = channel
    End Function

    'Public Shared Function ParseDateForRFC822(ByVal dt As DateTime) As String

    '    Dim dtmDate As DateTime = dt.ToUniversalTime

    '    Dim dtmDay As String = ""
    '    Dim dtmWeekDay As String = ""
    '    Dim dtmMonth As String = ""
    '    Dim dtmYear As String = ""
    '    Dim dtmHours As String = ""
    '    Dim dtmMinutes As String = ""
    '    Dim dtmSeconds As String = ""

    '    Select Case Weekday(dtmDate)
    '        Case 1 : dtmWeekDay = "Sun"
    '        Case 2 : dtmWeekDay = "Mon"
    '        Case 3 : dtmWeekDay = "Tue"
    '        Case 4 : dtmWeekDay = "Wed"
    '        Case 5 : dtmWeekDay = "Thu"
    '        Case 6 : dtmWeekDay = "Fri"
    '        Case 7 : dtmWeekDay = "Sat"
    '    End Select

    '    Select Case Month(dtmDate)
    '        Case 1 : dtmMonth = "Jan"
    '        Case 2 : dtmMonth = "Feb"
    '        Case 3 : dtmMonth = "Mar"
    '        Case 4 : dtmMonth = "Apr"
    '        Case 5 : dtmMonth = "May"
    '        Case 6 : dtmMonth = "Jun"
    '        Case 7 : dtmMonth = "Jul"
    '        Case 8 : dtmMonth = "Aug"
    '        Case 9 : dtmMonth = "Sep"
    '        Case 10 : dtmMonth = "Oct"
    '        Case 11 : dtmMonth = "Nov"
    '        Case 12 : dtmMonth = "Dec"
    '    End Select

    '    dtmYear = Year(dtmDate).ToString
    '    dtmDay = Right("00" & Day(dtmDate), 2)

    '    dtmHours = Right("00" & Hour(dtmDate), 2)
    '    dtmMinutes = Right("00" & Minute(dtmDate), 2)
    '    dtmSeconds = Right("00" & Second(dtmDate), 2)

    '    ParseDateForRFC822 = dtmWeekDay & ", " & dtmDay & " " & dtmMonth & " " & dtmYear & " " & dtmHours & ":" & dtmMinutes & ":" & dtmSeconds & " " & "GMT"

    'End Function

    Private FXml As String
    Public Property Xml() As String
        Get

            Dim ms As New MemoryStream
            Dim wr As New System.Xml.XmlTextWriter(ms, New System.Text.UTF8Encoding(False))

            wr.WriteStartDocument(True)
            wr.WriteStartElement("rss")
            wr.WriteAttributeString("version", "2.0")
            wr.WriteStartElement("channel")
            For Each f As System.Reflection.FieldInfo In Chan.GetType.GetFields()
                Dim s As String = CStr(f.GetValue(Chan))
                If s <> String.Empty Then
                    wr.WriteElementString(f.Name, s)
                End If
            Next
            For Each it As Item In Items
                wr.WriteStartElement("item")
                For Each f As System.Reflection.FieldInfo In it.GetType.GetFields()
                    Dim s As String = CStr(f.GetValue(it))
                    If s <> String.Empty Then
                        wr.WriteElementString(f.Name, s)
                    End If
                Next
                wr.WriteEndElement()
            Next
            wr.WriteEndElement()
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
