Public Class Portal

    Implements IPortal

    Friend IsAspxEnd As Boolean = False
    Friend IsAshxEnd As Boolean = False

    Friend Url4RegexConfig As Common.ItemConfig(Of Common.Item)

    Public Function Execute() As Boolean Implements IPortal.Execute
        Execute(System.Web.HttpContext.Current)
    End Function

    Public Function Execute(ByVal Context As System.Web.HttpContext) As Boolean Implements IPortal.Execute

        Common.Utility.Current.Trace.Write("Portal.Execute 进行正则式匹配页面并调用相应的方法")

        Dim Path As String = Common.Utility.Current.FilePath

        For Each s As String In Me.Url4RegexConfig.Keys

            Dim t As String = ("^" & s & "$")

            If System.Text.RegularExpressions.Regex.IsMatch(Path, t) = True Then

                Dim r As String = Me.Url4RegexConfig(s).Value

                Common.Utility.Current.Trace.Write("Common.Utility.Current.FilePath " + Common.Utility.Current.FilePath)
                Common.Utility.Current.Trace.Write("System.Web.HttpContext.Current.Request.FilePath " + Context.Request.FilePath)
                Common.Utility.Current.Trace.Write("Common.Utility.Current.Host " + Common.Utility.Current.Host)

                Common.Utility.Current.Trace.Write("Portal.Execute 匹配" + r)

                Dim Regex As New System.Text.RegularExpressions.Regex(t)
                Dim Match As System.Text.RegularExpressions.Match = Regex.Match(Path)

                For i As Integer = 1 To Match.Groups.Count
                    Dim a As String = Match.Groups(i - 1).ToString()
                    r = r.Replace("$" + (i - 1).ToString, a)
                Next

                Common.Utility.Current.Trace.Write("Portal.Execute 执行" + r)

                If r.Contains(".aspx") = True Then
                    Context.Server.Execute(r, True)
                    IsAspxEnd = True
                    Return True
                End If

                If r.Contains(".ashx") = True Then
                    Context.RewritePath(r)
                    IsAshxEnd = True
                    Return True
                End If

            End If

        Next

        Common.Utility.Current.Trace.Write("Portal.PageFilterConfig 未发现匹配的页面规则")

    End Function

    Public Sub New()
        Url4RegexConfig = (New Common.ItemConfig(Of Common.Item)).LoadFile(Common.Utility.Current.MapPath(System.Configuration.ConfigurationManager.AppSettings("Url4RegexConfig_FileName")))
    End Sub
End Class
