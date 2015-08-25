Public Class FormWitter

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        zdevo_newAtomy(Me.TextBox1.Text)

        Me.Close()

    End Sub
End Class