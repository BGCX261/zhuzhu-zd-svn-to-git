''' <summary>
''' 通用页面类
''' </summary>
''' <remarks></remarks>
Public MustInherit Class BaseContainer

    Implements IDisposable

    Private disposedValue As Boolean = False        ' 检测冗余的调用
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 显式调用时释放非托管资源
            End If

            ' TODO: 释放共享的非托管资源
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' Visual Basic 添加此代码是为了正确实现可处置模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 不要更改此代码。请将清理代码放入上面的 Dispose(ByVal disposing As Boolean) 中。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class