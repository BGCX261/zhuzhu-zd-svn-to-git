Namespace [Global]

    Public Class [Global]

        Inherits HttpApplication

        Public schedulerThread As System.Threading.Thread = Nothing

        Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' 在应用程序启动时运行的代码

            Dim scheduler As Scheduler = New Scheduler()
            scheduler.job = New SampleJob
            Dim myThreadStart As System.Threading.ThreadStart = New System.Threading.ThreadStart(AddressOf scheduler.Start)
            Dim schedulerThread As System.Threading.Thread = New System.Threading.Thread(myThreadStart)
            schedulerThread.Start()

        End Sub

        Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
            ' 在应用程序关闭时运行的代码

            If schedulerThread IsNot Nothing Then
                schedulerThread.Abort()
            End If

        End Sub

        Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            ' 在出现未处理的错误时运行的代码
        End Sub

        Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' 在新会话启动时运行的代码
        End Sub

        Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            ' 在会话结束时运行的代码。 
            ' 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            ' InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            ' 或 SQLServer，则不会引发该事件。
        End Sub


        Public Interface ISchedulerJob

            Sub Execute()

        End Interface

        Public Class SampleJob

            Implements ISchedulerJob

            Public Sub Execute() Implements ISchedulerJob.Execute

                Try

                    Dim s As String = CStr(Zdevo.Common.Functions.Current.LoadCache("APPLICATION_HOST"))

                    If s IsNot Nothing Then

                        Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(s + "schedule.aspx")

                        Dim res As System.Net.WebResponse = request.GetResponse()

                        'My.Computer.FileSystem.WriteAllText("d:\a.txt", New IO.StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd, True)

                    End If

                Catch ex As Exception

                End Try

            End Sub

        End Class



        Public Class Scheduler

            Public job As ISchedulerJob

            Public Sub Start()

                While (True)

                    Dim myThreadDelegate As Threading.ThreadStart = New Threading.ThreadStart(AddressOf job.Execute)
                    Dim myThread As Threading.Thread = New Threading.Thread(myThreadDelegate)

                    myThread.Start()

                    Threading.Thread.Sleep(10 * 60 * 1000)

                End While

            End Sub

        End Class

    End Class

End Namespace



