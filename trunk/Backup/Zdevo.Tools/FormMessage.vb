Public Class FormMessage


    Private Sub FormMessage_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Visible = False
        Me.Left = FormMain.Left - 240
        Me.Top = FormMain.Top
        Me.Height = FormMain.Height
        Me.Width = 240
        Me.Visible = True
    End Sub

End Class