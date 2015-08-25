Public Class BasePage

    Public Container As Zdevo.Core.SQLite.Container

    Private IsRunning As Boolean = False

    Public Overridable Function IsEncodingAccepted(ByVal Encoding As String) As Boolean
        Zdevo.Common.Utility.Current.Trace.Write("Accept-Encoding: " + System.Web.HttpContext.Current.Request.Headers.Get("Accept-Encoding"))
        If System.Web.HttpContext.Current.Request.Headers("Accept-Encoding") IsNot Nothing Then
            If System.Web.HttpContext.Current.Request.Headers("Accept-Encoding").Contains(Encoding) = True Then
                Return True
            End If
        End If
    End Function

    Public Overridable Sub CompressionPage()
        Zdevo.Common.Utility.Current.Trace.Write("¿ªÆôÑ¹Ëõ")
        If IsEncodingAccepted("deflate") = True Then
            System.Web.HttpContext.Current.Response.Filter = New IO.Compression.DeflateStream(System.Web.HttpContext.Current.Response.Filter, IO.Compression.CompressionMode.Compress)
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Encoding", "deflate")
        ElseIf IsEncodingAccepted("gzip") = True Then
            System.Web.HttpContext.Current.Response.Filter = New IO.Compression.GZipStream(System.Web.HttpContext.Current.Response.Filter, IO.Compression.CompressionMode.Compress)
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip")
        End If
    End Sub


    Public Overridable Function System_Initialize() As Boolean
        If IsRunning = False Then
            Container = New Zdevo.Core.SQLite.Container
            Container.Initialize()
            CompressionPage()
            Return True
        Else
            Return False
        End If
    End Function

    Public Overridable Function System_Terminate() As Boolean
        Container.Terminate()
    End Function

End Class
