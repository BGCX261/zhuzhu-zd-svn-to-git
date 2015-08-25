Module ModuleMain

    Public Host As String
    Public HostUrl As Single
    Public UserName As String
    Public PassWord As String


    Public Sub ShowFormWaitting()

        Dim FormWatting As Form = New FormWatting
        FormWatting.ShowDialog()
        FormWatting.TopMost = True

    End Sub


    Public Sub CloseFormWaitting(ByVal Form As Form)
        FormWatting.Close()
    End Sub


    Public Function SendXmlRpc(ByVal methodName As String, ByVal paramType() As String, ByVal paramValue() As String) As String


        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(My.Settings.Item("Host") + "xmlrpc/default.aspx")

        request.Method = "POST"
        request.ContentType = "text/xml"

        request.Timeout = 10000

        Dim data As Byte() = AddXmlToRequest(methodName, paramType, paramValue)

        request.ContentLength = data.Length
        Dim s As IO.Stream = request.GetRequestStream
        s.Write(data, 0, data.Length)
        s.Close()

        Dim res As System.Net.HttpWebResponse = request.GetResponse()


        'Dim ms As IO.Stream = request.GetResponse().GetResponseStream()
        'Dim sr As IO.StreamReader = New IO.StreamReader(request.GetResponse().GetResponseStream())

        'MsgBox(New IO.StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd)

        Return New IO.StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd

    End Function

    Public Function RequestFile(ByVal FileName As String) As String

        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(FileName)

        Dim res As System.Net.HttpWebResponse = request.GetResponse()

        Return New IO.StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd

    End Function



    Function AddXmlToRequest(ByVal methodName As String, ByVal paramType() As String, ByVal paramValue() As String) As Byte()

        Dim ms As New IO.MemoryStream

        Dim writer As Xml.XmlTextWriter = New Xml.XmlTextWriter(ms, New System.Text.UTF8Encoding(False))
        Using writer
            writer.WriteStartDocument()
            writer.WriteStartElement("methodCall")
            writer.WriteElementString("methodName", methodName)
            writer.WriteStartElement("params")


            writer.WriteStartElement("param")
            writer.WriteStartElement("value")
            writer.WriteElementString("string", My.Settings.Item("UserName"))
            writer.WriteEndElement()
            writer.WriteEndElement()

            writer.WriteStartElement("param")
            writer.WriteStartElement("value")
            writer.WriteElementString("string", My.Settings.Item("PassWord"))
            writer.WriteEndElement()
            writer.WriteEndElement()


            For i As Integer = 0 To paramType.Length - 1

                writer.WriteStartElement("param")
                writer.WriteStartElement("value")
                writer.WriteElementString(paramType(i), paramValue(i))
                writer.WriteEndElement()
                writer.WriteEndElement()

            Next

            writer.WriteEndElement()
            writer.WriteEndElement()

        End Using

        Return ms.ToArray

    End Function


    'Sub AddXmlToRequest2(ByVal request As Net.HttpWebRequest)

    '    Dim stream As IO.Stream = request.GetRequestStream()
    '    Dim writer As XmlTextWriter = New XmlTextWriter(stream, Encoding.ASCII)
    '    Using writer
    '        writer.WriteStartDocument()
    '        writer.WriteStartElement("methodCall")
    '        writer.WriteElementString("methodName", "weblogUpdates.ping")
    '        writer.WriteStartElement("params")
    '        writer.WriteStartElement("param")
    '        writer.WriteElementString("value", "The name of your website")
    '        writer.WriteEndElement()
    '        writer.WriteStartElement("param")

    '        writer.WriteElementString("value", "http://www.example.com")
    '        writer.WriteEndElement()
    '        writer.WriteEndElement()
    '        writer.WriteEndElement()
    '    End Using
    'End Sub


    Public Function zdevo_newAtomy(ByVal Content As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()


        Dim s As String = SendXmlRpc("zdevo.newAtomy", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function

    Public Function zdevo_editGuestBook(ByVal Title As String, ByVal Content As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim s As String = SendXmlRpc("zdevo.editGuestBook", New String() {"string", "string"}, New String() {Title, Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function

    Public Function zdevo_newBookMark(ByVal Title As String, ByVal Url As String, ByVal Content As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim s As String = SendXmlRpc("zdevo.newBookMark", New String() {"string", "string", "string"}, New String() {Title, Url, Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function

    Public Function zdevo_editPicasa(ByVal PicasaUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(PicasaUrl))

        Dim s As String = SendXmlRpc("zdevo.editPicasa", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_editFlickr(ByVal FlickrUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(FlickrUrl))

        Dim s As String = SendXmlRpc("zdevo.editFlickr", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_editYupoo(ByVal YupooUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(YupooUrl))

        Dim s As String = SendXmlRpc("zdevo.editYupoo", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_editFanfou(ByVal FanfouUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(FanfouUrl))

        Dim s As String = SendXmlRpc("zdevo.editFanfou", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_editDelicious(ByVal DeliciousUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(DeliciousUrl))

        Dim s As String = SendXmlRpc("zdevo.editDelicious", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_editDouban(ByVal DeliciousUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(DeliciousUrl))

        Dim s As String = SendXmlRpc("zdevo.editDouban", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_editTwitter(ByVal TwitterUrl As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(TwitterUrl))

        Dim s As String = SendXmlRpc("zdevo.editTwitter", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


    Public Function zdevo_edit365Key(ByVal Key365Url As String) As Boolean

        Dim Thread As New Threading.Thread(New Threading.ThreadStart(AddressOf ShowFormWaitting))
        Thread.Start()

        Dim Content As String = Common.Functions.Current.CompresstoBase64(RequestFile(Key365Url))

        Dim s As String = SendXmlRpc("zdevo.edit365Key", New String() {"string"}, New String() {Content})

        Dim x As New Xml.XmlDocument
        x.LoadXml(s)
        If x.DocumentElement.SelectNodes("fault").Count > 0 Then
            Thread.Abort()
            MsgBox(x.DocumentElement.SelectSingleNode("fault/value/struct/member[2]/value/string").InnerText)
        Else
            Thread.Abort()
        End If

    End Function


End Module
