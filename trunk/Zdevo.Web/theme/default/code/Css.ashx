<%@ WebHandler Language="VB" Class="Css" %>

Imports System
Imports System.Web

Public Class Css : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/css"
        Dim s As String = My.Computer.FileSystem.ReadAllText(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\default.css"))
        
        Dim c As New System.Drawing.Color
        
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer
        
        
        If IsNothing(context.Request.QueryString("color")) = False Then
            c = System.Drawing.Color.FromName(context.Request.QueryString("color"))
            r = c.R
            g = c.G
            b = c.B
        Else
            r = CInt(IIf(IsNothing(context.Request.QueryString("r")) = True, &HDC, context.Request.QueryString("r")))
            g = CInt(IIf(IsNothing(context.Request.QueryString("g")) = True, &H14, context.Request.QueryString("g")))
            b = CInt(IIf(IsNothing(context.Request.QueryString("b")) = True, &H3C, context.Request.QueryString("b")))
        End If


        
        Dim color1 As System.Drawing.Color = System.Drawing.Color.FromArgb(r, g, b)
        Dim color2 As System.Drawing.Color = Zdevo.Common.RGBHSL.AntiColor(color1)
        Dim color3 As New System.Drawing.Color
        Dim color4 As New System.Drawing.Color
        
        color3 = Zdevo.Common.RGBHSL.ModifyBrightness(color1, 0.1)
        color4 = Zdevo.Common.RGBHSL.ModifyBrightness(color1, 1.7)
        color1 = Zdevo.Common.RGBHSL.ModifyBrightness(color1, 0.8)
        color2 = Zdevo.Common.RGBHSL.ModifyBrightness(color2, 1.1)

        s = s.Replace("#666", "#" + Right("00" + Hex(color1.R), 2) + Right("00" + Hex(color1.G), 2) + Right("00" + Hex(color1.B), 2))
        s = s.Replace("#999", "#" + Right("00" + Hex(color2.R), 2) + Right("00" + Hex(color2.B), 2) + Right("00" + Hex(color2.B), 2))
        s = s.Replace("#000", "#" + Right("00" + Hex(color3.R), 2) + Right("00" + Hex(color3.B), 2) + Right("00" + Hex(color3.B), 2))
        s = s.Replace("#DDD", "#" + Right("00" + Hex(color4.R), 2) + Right("00" + Hex(color4.B), 2) + Right("00" + Hex(color4.B), 2))
        
        s = s.Replace("image/", Zdevo.Common.Utility.Current.Host + "theme/default/style/image/")
        
        If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/1.png") = True Then
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/1.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/1.png')")
        Else
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/1.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=1.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        End If
        If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/2.png") = True Then
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/2.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/2.png')")
        Else
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/2.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=2.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        End If
        If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/3.png") = True Then
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/3.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/3.png')")
        Else
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/3.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=3.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        End If
        If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/4.png") = True Then
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/4.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/4.png')")
        Else
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/4.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=4.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        End If
        If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/7.png") = True Then
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/7.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/7.png')")
        Else
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/7.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=7.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        End If
        If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/logo.png") = True Then
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/logo.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/logo.png')")
        Else
            s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/logo.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=logo.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        End If
        'If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/8.png") = True Then
        '    s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/8.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/8.png')")
        'Else
        '    s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/8.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=8.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        'End If
        'If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/9.png") = True Then
        '    s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/9.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/9.png')")
        'Else
        '    s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/9.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=9.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        'End If
        'If My.Computer.FileSystem.FileExists(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString) + "/10.png") = True Then
        '    s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/10.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "/10.png')")
        'Else
        '    s = s.Replace("url('" + Zdevo.Common.Utility.Current.Host + "theme/default/style/image/10.png')", "url('" + Zdevo.Common.Utility.Current.Host + "theme/default/code/PngImage.ashx?f=10.png&r=" + r.ToString + "&g=" + g.ToString + "&b=" + b.ToString + "')")
        'End If


        
        context.Response.Write(s)
        context.Response.Flush()
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class