Public Class Functions

    Public Shared Current As Functions = New Functions

    Public Overridable Function RequestFile(ByVal FileName As String) As String

        Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(FileName)

        Dim res As System.Net.WebResponse = request.GetResponse()

        Return New IO.StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd

    End Function

    Public Overridable Function LoadCache(ByVal key As String) As Object
        Return System.Web.HttpRuntime.Cache.Item(key)
    End Function

    Public Overridable Sub SaveCache(ByVal key As String, ByVal value As Object)
        System.Web.HttpRuntime.Cache.Item(key) = value
    End Sub

    Public Overridable Function XmlEncode(ByVal s As String) As String
        s = Replace(s, "&", "&amp;")
        s = Replace(s, "<", "&lt;")
        s = Replace(s, ">", "&gt;")
        s = Replace(s, """", "&quot;")
        s = Replace(s, "'", "&apos;")

        Return s
    End Function

    Public Overridable Function HtmlRemove(ByVal s As String) As String
        Return Regex.Replace(s, "<[^>]+>", "")
    End Function

    ''' <summary>
    ''' SHA-1 by String
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SHA1(ByVal s As String) As String

        Dim bytSHA1 As Byte() = New System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(s))

        Return (BitConverter.ToString(bytSHA1)).Replace("-", "").ToLower

    End Function


    ''' <summary>
    ''' SHA-1 by Stream
    ''' </summary>
    ''' <param name="Stream"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SHA1(ByVal Stream As Stream) As String

        Dim bytSHA1 As Byte() = New System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(Stream)

        Return (BitConverter.ToString(bytSHA1)).Replace("-", "").ToLower

    End Function


    ''' <summary>
    ''' SHA-1 by Bytes
    ''' </summary>
    ''' <param name="Bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SHA1(ByVal Bytes As Byte()) As String

        Dim bytSHA1 As Byte() = New System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(Bytes)

        Return (BitConverter.ToString(bytSHA1)).Replace("-", "").ToLower

    End Function


    ''' <summary>
    ''' MD5 by String
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function MD5(ByVal s As String) As String

        Dim bytMD5 As Byte() = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(s))

        Return (BitConverter.ToString(bytMD5).Replace("-", "").ToLower)

    End Function


    ''' <summary>
    ''' MD5 by Stream
    ''' </summary>
    ''' <param name="Stream"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function MD5(ByVal Stream As Stream) As String

        Dim bytMD5 As Byte() = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(Stream)

        Return (BitConverter.ToString(bytMD5).Replace("-", "").ToLower)

    End Function


    ''' <summary>
    ''' MD5 by Bytes
    ''' </summary>
    ''' <param name="Bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function MD5(ByVal Bytes As Byte()) As String

        Dim bytMD5 As Byte() = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(Bytes)

        Return (BitConverter.ToString(bytMD5).Replace("-", "").ToLower)

    End Function



    ''' <summary>
    ''' 检查正则式
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="pattern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function CheckRegExp(ByVal s As String, ByVal pattern As String) As Boolean

        Select Case pattern.ToLower

            Case "[email]"
                pattern = "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*\.)+[a-zA-Z]*)$"

            Case "[url]"
                pattern = "^[a-zA-z]+://[a-zA-z0-9\-\./]+?/*$"

            Case "[username]"
                pattern = "^[.A-Za-z0-9\u4e00-\u9fa5]+$"

            Case "[password]"
                pattern = "^[a-z0-9]+$"

            Case "[guid]"
                pattern = "^\w{8}\-\w{4}\-\w{4}\-\w{4}\-\w{12}$"

        End Select

        If Regex.IsMatch(s, pattern) Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Overridable Function CheckUserName(ByVal s As String) As Boolean
        Return CheckRegExp(s, "[username]")
    End Function

    Public Overridable Function CheckPassWord(ByVal s As String) As Boolean
        Return CheckRegExp(s, "[password]")
    End Function

    Public Overridable Function CheckEmail(ByVal s As String) As Boolean
        Return CheckRegExp(s, "[email]")
    End Function

    Public Overridable Function CheckUrl(ByVal s As String) As Boolean
        Return CheckRegExp(s, "[url]")
    End Function

    '''' <summary>
    '''' 将未处理的Url正则式转换为正式可使用的正则式
    '''' </summary>
    '''' <param name="s"></param>
    '''' <param name="config"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Overridable Function GetRegexValue(ByVal s As String, ByVal config As Common.Config(Of Common.Item)) As String
    '    Try
    '        Dim Matches As MatchCollection = System.Text.RegularExpressions.Regex.Matches(s, "{%[A-Za-z0-9_]+%}", RegexOptions.Singleline Or RegexOptions.IgnoreCase)

    '        For Each Match As Match In Matches
    '            s = System.Text.RegularExpressions.Regex.Replace(s, Match.Value, config(Match.Value).Value)
    '        Next

    '        Return s
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


    ''' <summary>
    ''' 将Url正则式转化为Url的字符串值
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="config"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetUrlbyRegex(ByVal s As String, ByVal config As Common.ItemConfig(Of Common.Item)) As String
        Try

            For Each t As String In config.Keys
                's = Regex.Replace(s, t, Regex.Unescape(config(t).Value))
                s = Replace(s, t, config(t).Value)
            Next

            's = Regex.Unescape(s)

            Return s
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Overridable Function DecompressformBase64(ByVal s As String) As Byte()

        Dim b() As Byte = System.Convert.FromBase64String(s)
        Dim b2() As Byte

        Dim ms As New MemoryStream(b)

        Dim zipStream As Compression.GZipStream = New Compression.GZipStream(ms, IO.Compression.CompressionMode.Decompress)

        Dim msReader As New MemoryStream()

        Dim buffer(1000) As Byte
        Using ms
            Using zipStream
                Using msReader

                    While (True)

                        Dim read As Integer = zipStream.Read(buffer, 0, buffer.Length)
                        If (read <= 0) Then
                            Exit While
                        End If

                        msReader.Write(buffer, 0, read)

                    End While

                    b2 = msReader.ToArray

                End Using
            End Using
        End Using

        Return b2

    End Function


    Public Overridable Function CompresstoBase64(ByVal s As String) As String

        Dim t As String = ""

        Dim b() As Byte = System.Text.Encoding.UTF8.GetBytes(s)

        t = CompresstoBase64(b)

        Return t

    End Function


    Public Overridable Function CompresstoBase64(ByVal b() As Byte) As String

        Dim t As String = ""

        Dim ms As New MemoryStream()
        Dim zipStream As Stream = New System.IO.Compression.GZipStream(ms, Compression.CompressionMode.Compress, True)

        Using ms
            Using zipStream

                zipStream.Write(b, 0, b.Length)
                zipStream.Close()

                t = System.Convert.ToBase64String(ms.ToArray())

            End Using
        End Using

        Return t

    End Function

End Class
