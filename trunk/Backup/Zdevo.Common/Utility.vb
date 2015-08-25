Public Class Utility

    Public Class StopWatchs

        Protected BeginTime As New System.Diagnostics.Stopwatch

        Public Overridable ReadOnly Property RunTime() As String
            Get
                'Dim EndTime As System.Diagnostics.Stopwatch
                'EndTime = DateTime.Now.Ticks()
                Dim s As String = ""
                BeginTime.Stop()
                s = BeginTime.ElapsedMilliseconds.ToString
                BeginTime.Start()
                Return s
            End Get
        End Property

        Public Overridable Sub Begin()
            BeginTime.Reset()
            BeginTime.Start()
        End Sub

    End Class



    Public Class Traces

        ''' <summary>
        ''' 正常消息写入
        ''' </summary>
        ''' <param name="s">消息</param>
        ''' <remarks></remarks>
        Public Overridable Sub Write(ByVal s As String)
            Me.WriteToFile(s)
            If TraceEnable AndAlso System.Web.HttpContext.Current IsNot Nothing Then
                System.Web.HttpContext.Current.Trace.Write(s)
            End If
        End Sub


        ''' <summary>
        ''' 警告消息写入
        ''' </summary>
        ''' <param name="s">消息</param>
        ''' <remarks></remarks>
        Public Overridable Sub Warn(ByVal s As String)
            Me.WriteToFile(s)
            If TraceEnable AndAlso System.Web.HttpContext.Current IsNot Nothing Then
                System.Web.HttpContext.Current.Trace.Write(s)
            End If
        End Sub


        ''' <summary>
        ''' 错语消息写入
        ''' </summary>
        ''' <param name="s">消息</param>
        ''' <remarks></remarks>
        Public Overridable Sub Wrong(ByVal s As String)
            Me.WriteToFile(s)
            If TraceEnable AndAlso System.Web.HttpContext.Current IsNot Nothing Then
                System.Web.HttpContext.Current.Trace.Write(s)
            End If
        End Sub


        ''' <summary>
        ''' 直接写入文件
        ''' </summary>
        ''' <param name="s">消息</param>
        ''' <remarks></remarks>
        Public Overridable Sub WriteToFile(ByVal s As String)
            If TraceEnable AndAlso TraceEnable AndAlso System.Web.HttpContext.Current IsNot Nothing Then
                My.Computer.FileSystem.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("~/" + TraceFileName), "[" + DateTime.Now.ToString + " " + DateTime.Now.Ticks.ToString + "]" + s + vbCrLf, True)
            End If
            'My.Computer.FileSystem.WriteAllText("c:\zdevo.txt", "[" + DateTime.Now.ToString + "]" + s + vbCrLf, True)
        End Sub

    End Class


    Public Shared TraceEnable As Boolean = False
    Public Shared TraceFileName As String = ""

    Public Shared Current As Utility = New Utility

    Public Trace As Traces = New Traces

    Public StopWatch As StopWatchs = New StopWatchs

    ''' <summary>
    ''' 网络地址(不含主机头)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable ReadOnly Property FilePath() As String
        Get
            Dim value As String = ""
            'value = System.Web.HttpContext.Current.Request.FilePath.Substring(1).ToLower

            value = Right(System.Web.HttpContext.Current.Request.FilePath, System.Web.HttpContext.Current.Request.FilePath.Length - System.Web.HttpContext.Current.Request.ApplicationPath.Length).ToLower

            If value(0) = "/" Then
                value = Right(value, value.Length - 1)
            End If
            'value = System.Web.HttpContext.Current.Request.ApplicationPath
            'value = System.Web.HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Substring(2).ToLower

            Return value
        End Get
    End Property


    ''' <summary>
    ''' 主机名和应用程序名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable ReadOnly Property Host() As String
        Get
            Dim value As String = ""

            Dim i As Integer = InStr(Context.Request.Url.AbsoluteUri, Context.Request.Url.AbsolutePath, CompareMethod.Text)

            'value = Left(Context.Request.Url.ToString, Context.Request.Url.AbsoluteUri.Length - Context.Request.Url.AbsolutePath.Length)

            value = Left(Context.Request.Url.AbsoluteUri, i - 1)

            value = value & Context.Request.ApplicationPath
            If Right(value, 1) <> "/" Then
                value = value & "/"
            End If
            Return value
        End Get
    End Property


    ''' <summary>
    ''' 上下文
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable ReadOnly Property Context() As System.Web.HttpContext
        Get
            Context = System.Web.HttpContext.Current
        End Get
    End Property



    ''' <summary>
    ''' 物理路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable ReadOnly Property PhysicalApplicationPath() As String
        Get
            PhysicalApplicationPath = Context.Request.PhysicalApplicationPath
        End Get
    End Property



    ''' <summary>
    ''' 将指定的虚拟路径映射到物理路径
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function MapPath(ByVal virtualPath As String) As String
        Return Context.Request.MapPath(virtualPath)
    End Function

    '''   <summary>   
    '''   从二进制数组反序列化得到对象   
    '''   </summary>   
    '''   <param   name="buf">字节数组</param>   
    '''   <returns>得到的对象</returns> 
    Public Overridable Function DeserializeBinary(ByVal buf As Byte()) As Object
        Dim memStream As New MemoryStream(buf)
        memStream.Position = 0
        Dim newobj As Object = New Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(memStream)

        memStream.Close()
        Return newobj
    End Function


    '''   <summary>   
    '''   序列化为二进制字节数组   
    '''   </summary>   
    '''   <param   name="request">要序列化的对象</param>   
    '''   <returns>字节数组</returns>   
    Public Overridable Function SerializeBinary(ByVal request As Object) As Byte()
        Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim memStream As New MemoryStream
        serializer.Serialize(memStream, request)
        Return memStream.GetBuffer
    End Function

End Class
