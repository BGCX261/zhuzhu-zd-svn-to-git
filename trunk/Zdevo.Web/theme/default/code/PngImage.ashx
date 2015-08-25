<%@ WebHandler Language="VB" Class="PngImage" %>

Imports System
Imports System.Web

Public Class PngImage : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "image/png"
        context.Response.ExpiresAbsolute = System.DateTime.Now.AddYears(1)
              
        Dim f As String = context.Request.QueryString("f")
        Dim r As Integer = CInt(context.Request.QueryString("r")) 
        Dim g As Integer = CInt(context.Request.QueryString("g")) 
        Dim b As Integer = CInt(context.Request.QueryString("b"))
        
        'If context.Application.Get(f + r.ToString + g.ToString + b.ToString) IsNot Nothing Then
        '    context.Response.BinaryWrite(context.Application(f + r.ToString + g.ToString + b.ToString))
        '    context.Response.Flush()
        '    Exit Sub
        'End If

        Dim bmp As New System.Drawing.Bitmap(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + f))
        
        Using bmp
            'Dim bmp2 As New System.Drawing.Bitmap(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + f))
            Dim bmp2 As New System.Drawing.Bitmap(bmp.Width, bmp.Height)
            Using bmp2
                
                Dim grp As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmp2)
                Using grp
                    Dim transState As Drawing.Drawing2D.GraphicsState = grp.Save
                    'grp.Clear(Drawing.Color.Transparent)
                    grp.FillRectangle(New Drawing.SolidBrush(Drawing.Color.FromArgb(255, r, g, b)), New Drawing.Rectangle(0, 0, bmp.Width, bmp.Height))
                    grp.DrawImage(bmp, 0, 0)
                    grp.Restore(transState)
                End Using

                Dim ms As New IO.MemoryStream
                Using ms
                    bmp2.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    My.Computer.FileSystem.CreateDirectory(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString))
                    bmp2.Save(Zdevo.Common.Utility.Current.MapPath("~\theme\default\style\image\" + Right("000" + r.ToString, 3).ToString + Right("000" + g.ToString, 3).ToString + Right("000" + b.ToString, 3).ToString + "\" + f))
                    context.Response.BinaryWrite(ms.GetBuffer)
                    
                    'context.Application.Add(f + r.ToString + g.ToString + b.ToString, ms.GetBuffer)
                    
                End Using
            End Using

            context.Response.Flush()
        End Using


    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class