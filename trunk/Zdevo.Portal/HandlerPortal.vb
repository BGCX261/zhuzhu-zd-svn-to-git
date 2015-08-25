Public Class HandlerPortal

    Implements IHttpHandler

    Friend Portal As Portal

    Public Sub ProcessRequest(ByVal Context As HttpContext) Implements IHttpHandler.ProcessRequest

        'Common.Utility.Current.Trace.Write("ProductName: " & My.Application.Info.ProductName)
        'Common.Utility.Current.Trace.Write("AssemblyName: " & My.Application.Info.AssemblyName)
        'Common.Utility.Current.Trace.Write("Title: " & My.Application.Info.Title)
        'Common.Utility.Current.Trace.Write("WorkingSet: " & My.Application.Info.WorkingSet \ 1024 & "KB")
        'Common.Utility.Current.Trace.Write("WorkingSet: " & System.Diagnostics.Process.GetCurrentProcess.WorkingSet64 \ 1024 & "KB")
        'Common.Utility.Current.Trace.Write("DirectoryPath: " & My.Application.Info.DirectoryPath)
        'Common.Utility.Current.Trace.Write("Culture.DisplayName: " & My.Application.Culture.DisplayName)
        'Common.Utility.Current.Trace.Write("Culture.EnglishName: " & My.Application.Culture.EnglishName)
        'Common.Utility.Current.Trace.Write("Culture.Name: " & My.Application.Culture.Name)
        'Common.Utility.Current.Trace.Write("windir: " & My.Application.GetEnvironmentVariable("windir"))

        'Common.Utility.Current.Trace.Write("PhysicalApplicationPath: " & System.Web.HttpContext.Current.Request.PhysicalApplicationPath)
        'Common.Utility.Current.Trace.Write("PhysicalPath: " & System.Web.HttpContext.Current.Request.PhysicalPath)
        'Common.Utility.Current.Trace.Write("RawUrl: " & System.Web.HttpContext.Current.Request.RawUrl)
        'Common.Utility.Current.Trace.Write("ApplicationPath: " & System.Web.HttpContext.Current.Request.ApplicationPath)
        'Common.Utility.Current.Trace.Write("CurrentExecutionFilePath: " & System.Web.HttpContext.Current.Request.CurrentExecutionFilePath)
        'Common.Utility.Current.Trace.Write("FilePath: " & System.Web.HttpContext.Current.Request.FilePath)
        'Common.Utility.Current.Trace.Write("Url.AbsolutePath: " & System.Web.HttpContext.Current.Request.Url.AbsolutePath)
        'Common.Utility.Current.Trace.Write("Url.AbsoluteUri: " & System.Web.HttpContext.Current.Request.Url.AbsoluteUri)
        'Common.Utility.Current.Trace.Write("Url: " & System.Web.HttpContext.Current.Request.Url.ToString)
        'Common.Utility.Current.Trace.Write("Server.MapPath('~/'): " & System.Web.HttpContext.Current.Server.MapPath("~/"))
        'Common.Utility.Current.Trace.Write("Url.Host: " & System.Web.HttpContext.Current.Request.Url.Host)
        'Common.Utility.Current.Trace.Write("Url.LocalPath: " & System.Web.HttpContext.Current.Request.Url.LocalPath)
        'Common.Utility.Current.Trace.Write("Container.Host: " & Zdevo.Common.Utility.Current.Host)
        'Common.Utility.Current.Trace.Write("Container.FilePath: " & Zdevo.Common.Utility.Current.FilePath)
        'Common.Utility.Current.Trace.Write("AppRelativeCurrentExecutionFilePath: " & System.Web.HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath)

        Common.Utility.Current.Trace.Write("HttpHandler.ProcessRequest 开始计时")
        Common.Utility.Current.StopWatch.Begin()

        'Throw New System.Exception

        Portal = New Portal

        Portal.Execute(Context)

    End Sub



    Public Overloads ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property


    Public Sub New()

        Common.Utility.Current.Trace.Write("HandlerPortal 初始化启动")

        'Container = TryCast(System.Reflection.Assembly.Load(System.Configuration.ConfigurationManager.AppSettings("Container_AssemblyName")).CreateInstance(System.Configuration.ConfigurationManager.AppSettings("Container_TypeName")), Common.IContainer).GetInstance
        'Container = System.Reflection.Assembly.Load(System.Configuration.ConfigurationManager.AppSettings("Container_AssemblyName")).CreateInstance(System.Configuration.ConfigurationManager.AppSettings("Container_TypeName"))

    End Sub


End Class