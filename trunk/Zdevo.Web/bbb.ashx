<%@ WebHandler Language="VB" Class="bbb" %>

Imports System
Imports System.Web

Public Class bbb

    Inherits Zdevo.Page.XmlrpcPage
    
    Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'context.Response.Write("ddd")
        'context.Response.Write(System.DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss"))
        'context.Response.Write(System.DateTime.Now.ToString("r", System.Globalization.DateTimeFormatInfo.InvariantInfo))
        'context.Response.Write(System.DateTime.Now.ToUniversalTime.ToString("R"))
        'context.Response.Write(System.DateTime.Parse("Thu, 24 Jan 2008 22:14:02 +1000", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString())
        
        'Dim b As Boolean = Me.System_Initialize
        'context.Response.Write("ddd")
        
        'For i As Integer = 1 To 10000
        '    Dim a As Zdevo.Common.ItemConfig(Of Zdevo.Common.Item)
        '    a = Me.Container.ActionConfig.Clone3
        'Next
        'Dim e As Zdevo.Common.ItemConfig(Of Zdevo.Common.Item) = Me.Container.ActionConfig.Clone3
        'context.Response.Write(e.Serialize())
        'Me.System_Terminate()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class