''' <summary>
''' ͨ��ҳ����
''' </summary>
''' <remarks></remarks>
Public MustInherit Class BaseContainer

    Implements IDisposable

    Private disposedValue As Boolean = False        ' �������ĵ���
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: ��ʽ����ʱ�ͷŷ��й���Դ
            End If

            ' TODO: �ͷŹ���ķ��й���Դ
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' Visual Basic ��Ӵ˴�����Ϊ����ȷʵ�ֿɴ���ģʽ��
    Public Sub Dispose() Implements IDisposable.Dispose
        ' ��Ҫ���Ĵ˴��롣�뽫��������������� Dispose(ByVal disposing As Boolean) �С�
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class