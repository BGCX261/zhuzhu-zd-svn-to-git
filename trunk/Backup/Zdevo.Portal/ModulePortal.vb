Public Class ModulePortal

    Implements IHttpModule
    Public HandlerPortal As HandlerPortal

    Public Sub Init(ByVal HttpApplication As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init

        Common.Utility.Current.Trace.Write("HttpModule 挂接 PreRequestHandlerExecute")
        AddHandler HttpApplication.PreRequestHandlerExecute, AddressOf PreRequestHandlerExecute

        Common.Utility.Current.Trace.Write("HttpModule 挂接 PostRequestHandlerExecute")
        AddHandler HttpApplication.PostRequestHandlerExecute, AddressOf PostRequestHandlerExecute

        Common.Utility.Current.Trace.Write("HttpModule 挂接 BeginRequest")
        AddHandler HttpApplication.BeginRequest, AddressOf BeginRequest

        Common.Utility.Current.Trace.Write("HttpModule 挂接 EndRequest")
        AddHandler HttpApplication.EndRequest, AddressOf EndRequest

        Common.Utility.Current.Trace.Write("HttpModule 挂接 Error")
        AddHandler HttpApplication.Error, AddressOf CatchError

    End Sub

    Public Sub Dispose() Implements IHttpModule.Dispose

    End Sub

    'Public Sub ManageError(ByVal Exception As Exception)

    '    If TypeOf (Exception) Is HttpException Then
    '        If DirectCast(Exception, HttpException).GetHttpCode = 404 Then
    '            If CBool(Portal.Container.GlobalConfig.Value("ZC_APPLICATION_PAGENOFOUND_ENABLED")) = True Then
    '                If My.Computer.FileSystem.FileExists(Portal.Container.Context.Request.PhysicalPath) = False Then
    '                    Dim strUrl As String = Portal.Container.FilePath
    '                    If StrComp(strUrl.ToLowerInvariant, Portal.Container.GlobalConfig.Value("ZC_APPLICATION_PAGENOFOUND_FILENAME").ToLowerInvariant) <> 0 Then
    '                        'System.Web.HttpContext.Current.Server.Transfer("~/" & CStr(Portal.Container.GlobalConfig.Value("ZC_APPLICATION_PAGENOFOUND_FILENAME")))
    '                        System.Web.HttpContext.Current.Response.Redirect(Portal.Container.Host & CStr(Portal.Container.GlobalConfig.Value("ZC_APPLICATION_PAGENOFOUND_FILENAME")))
    '                    End If
    '                End If
    '            Else
    '                Throw Exception
    '            End If
    '        End If
    '    Else
    '        If (CBool(Portal.Container.GlobalConfig.Value("ZC_APPLICATION_TURNOFFERROR_ENABLED")) = True) Then
    '            System.Web.HttpContext.Current.Response.Redirect(Portal.Container.Host & CStr(Portal.Container.GlobalConfig.Value("ZC_APPLICATION_TURNOFFERROR_FILENAME")))
    '        Else
    '            Throw Exception
    '        End If
    '    End If

    'End Sub

    Public Sub EndRequest(ByVal s As Object, ByVal e As EventArgs)

        Common.Utility.Current.Trace.Write("输出完毕共用时ms " + Common.Utility.Current.StopWatch.RunTime)

    End Sub


    Public Sub BeginRequest(ByVal s As Object, ByVal e As EventArgs)

        Common.Utility.Current.Trace.Write("++++++++++++++++++++++++++++++++++++++++++++++")
        Common.Utility.Current.Trace.Write("HttpModule 开始HandlerPortal.BeginRequest 处理")
        HandlerPortal.ProcessRequest(TryCast(s, HttpApplication).Context)

    End Sub


    Public Sub CatchError(ByVal s As Object, ByVal e As EventArgs)
        'SyncLock Me.HandlerPortal

        'End SyncLock
        If (DirectCast(System.Web.HttpContext.Current.Server.GetLastError, HttpException).GetHttpCode = 404) Then
            System.Web.HttpContext.Current.Server.ClearError()
        End If
    End Sub


    Public Sub PreRequestHandlerExecute(ByVal s As Object, ByVal e As EventArgs)

        If HandlerPortal.Portal.IsAspxEnd = True Then
            TryCast(s, HttpApplication).Context.Response.End()
        End If

    End Sub


    Public Sub PostRequestHandlerExecute(ByVal s As Object, ByVal e As EventArgs)

        If HandlerPortal.Portal.IsAshxEnd = True Then
            TryCast(s, HttpApplication).Context.Response.End()
        End If

    End Sub


    Public Sub New()
        Common.Utility.Current.Trace.Write("====================================================")
        Common.Utility.Current.Trace.Write("ModulePortal 初始化启动")
        HandlerPortal = New HandlerPortal
    End Sub

End Class