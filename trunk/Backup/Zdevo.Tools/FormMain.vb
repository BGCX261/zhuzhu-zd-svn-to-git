Public Class FormMain

    'Private osShutDown As Boolean = False

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Select Case m.Msg
    '        Case &H11
    '            osShutDown = True
    '    End Select
    '    MyBase.WndProc(m)
    'End Sub


    Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If osShutDown = True Then
        '    e.Cancel = True
        '    Me.Hide()
        'End If

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If

    End Sub

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer = 0
        For Each c As Control In Me.FlowLayoutPanel.Controls
            If TypeOf c Is ImageControl Then
                If c.Visible = True Then
                    i += 1
                End If
            End If
        Next

        Me.Width = 74
        Me.Height = i * (48 + 10) + 30

        Me.MinimumSize = New System.Drawing.Size(Me.Width, Me.Height)
        Me.MaximumSize = New System.Drawing.Size(Me.Width, Me.Height)

        Me.Left = My.Computer.Screen.WorkingArea.Width - Me.Width
        Me.Top = My.Computer.Screen.WorkingArea.Height - Me.Height

    End Sub

    Private Sub btnNewArticle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewArticle.Click
        FormEdit.Show()
    End Sub

    Private Sub btnNewWitter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewWitter.Click
        FormWitter.Show()
    End Sub


    Private Sub btnVisitSite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisitSite.Click
        System.Diagnostics.Process.Start(My.Settings.Item("Host"))
    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Visible = True
        Me.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub ContextMenuNotifyIcon_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuNotifyIcon.Opening
        If Me.Visible = False Then
            ShowToolStripMenuItem.Text = "Show"
        Else
            ShowToolStripMenuItem.Text = "Hide"
        End If
        HelloToolStripMenuItem.Text = "Hello " + My.Settings.Item("UserName")
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        If Me.Visible = False Then
            Me.Visible = True
            Me.TopMost = True
            Me.TopMost = False
        Else
            Me.Visible = False
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.ShowDialog()
    End Sub

    Private Sub OptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionToolStripMenuItem.Click
        FormOption.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
        'Environment.Exit(0)
    End Sub


    Private Sub btnOpenMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenMessage.Click
        FormMessage.Show()
    End Sub

    Private Sub btnEditAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditAbout.Click
        FormGuestBook.Show()
    End Sub

    Private Sub ImageControl2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageControl2.Click
        FormBookMark.Show()
    End Sub

    Private Sub btnUploadFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadFile.Click
        FormRefresh.Show()
    End Sub

End Class
