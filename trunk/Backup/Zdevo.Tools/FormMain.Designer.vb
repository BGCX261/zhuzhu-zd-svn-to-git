<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HelloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel
        Me.btnNewWitter = New Zdevo.Tools.ImageControl
        Me.btnOpenMessage = New Zdevo.Tools.ImageControl
        Me.btnNewArticle = New Zdevo.Tools.ImageControl
        Me.ImageControl2 = New Zdevo.Tools.ImageControl
        Me.ImageControl1 = New Zdevo.Tools.ImageControl
        Me.btnUploadFile = New Zdevo.Tools.ImageControl
        Me.btnAddUsers = New Zdevo.Tools.ImageControl
        Me.btnSetSite = New Zdevo.Tools.ImageControl
        Me.btnEditAbout = New Zdevo.Tools.ImageControl
        Me.btnVisitSite = New Zdevo.Tools.ImageControl
        Me.ContextMenuNotifyIcon.SuspendLayout()
        Me.FlowLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.ContextMenuNotifyIcon
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Visible = True
        '
        'ContextMenuNotifyIcon
        '
        Me.ContextMenuNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelloToolStripMenuItem, Me.OptionToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ShowToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuNotifyIcon.Name = "ContextMenu"
        Me.ContextMenuNotifyIcon.Size = New System.Drawing.Size(107, 114)
        '
        'HelloToolStripMenuItem
        '
        Me.HelloToolStripMenuItem.Name = "HelloToolStripMenuItem"
        Me.HelloToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.HelloToolStripMenuItem.Text = "Login"
        '
        'OptionToolStripMenuItem
        '
        Me.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem"
        Me.OptionToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.OptionToolStripMenuItem.Text = "Option"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'FlowLayoutPanel
        '
        Me.FlowLayoutPanel.Controls.Add(Me.btnNewWitter)
        Me.FlowLayoutPanel.Controls.Add(Me.btnOpenMessage)
        Me.FlowLayoutPanel.Controls.Add(Me.btnNewArticle)
        Me.FlowLayoutPanel.Controls.Add(Me.ImageControl2)
        Me.FlowLayoutPanel.Controls.Add(Me.ImageControl1)
        Me.FlowLayoutPanel.Controls.Add(Me.btnUploadFile)
        Me.FlowLayoutPanel.Controls.Add(Me.btnAddUsers)
        Me.FlowLayoutPanel.Controls.Add(Me.btnSetSite)
        Me.FlowLayoutPanel.Controls.Add(Me.btnEditAbout)
        Me.FlowLayoutPanel.Controls.Add(Me.btnVisitSite)
        Me.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
        Me.FlowLayoutPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel.Size = New System.Drawing.Size(300, 128)
        Me.FlowLayoutPanel.TabIndex = 20
        '
        'btnNewWitter
        '
        Me.btnNewWitter.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.chat
        Me.btnNewWitter.Location = New System.Drawing.Point(10, 10)
        Me.btnNewWitter.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNewWitter.Name = "btnNewWitter"
        Me.btnNewWitter.Size = New System.Drawing.Size(48, 48)
        Me.btnNewWitter.TabIndex = 1
        '
        'btnOpenMessage
        '
        Me.btnOpenMessage.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.show_info
        Me.btnOpenMessage.Location = New System.Drawing.Point(68, 10)
        Me.btnOpenMessage.Margin = New System.Windows.Forms.Padding(5)
        Me.btnOpenMessage.Name = "btnOpenMessage"
        Me.btnOpenMessage.Size = New System.Drawing.Size(48, 48)
        Me.btnOpenMessage.TabIndex = 3
        '
        'btnNewArticle
        '
        Me.btnNewArticle.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.edit
        Me.btnNewArticle.Location = New System.Drawing.Point(126, 10)
        Me.btnNewArticle.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNewArticle.Name = "btnNewArticle"
        Me.btnNewArticle.Size = New System.Drawing.Size(48, 48)
        Me.btnNewArticle.TabIndex = 2
        '
        'ImageControl2
        '
        Me.ImageControl2.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.favorites_add
        Me.ImageControl2.Location = New System.Drawing.Point(184, 10)
        Me.ImageControl2.Margin = New System.Windows.Forms.Padding(5)
        Me.ImageControl2.Name = "ImageControl2"
        Me.ImageControl2.Size = New System.Drawing.Size(48, 48)
        Me.ImageControl2.TabIndex = 10
        '
        'ImageControl1
        '
        Me.ImageControl1.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.folder
        Me.ImageControl1.Location = New System.Drawing.Point(242, 10)
        Me.ImageControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.ImageControl1.Name = "ImageControl1"
        Me.ImageControl1.Size = New System.Drawing.Size(48, 48)
        Me.ImageControl1.TabIndex = 9
        '
        'btnUploadFile
        '
        Me.btnUploadFile.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.refresh
        Me.btnUploadFile.Location = New System.Drawing.Point(10, 68)
        Me.btnUploadFile.Margin = New System.Windows.Forms.Padding(5)
        Me.btnUploadFile.Name = "btnUploadFile"
        Me.btnUploadFile.Size = New System.Drawing.Size(48, 48)
        Me.btnUploadFile.TabIndex = 8
        '
        'btnAddUsers
        '
        Me.btnAddUsers.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.users
        Me.btnAddUsers.Location = New System.Drawing.Point(68, 68)
        Me.btnAddUsers.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAddUsers.Name = "btnAddUsers"
        Me.btnAddUsers.Size = New System.Drawing.Size(48, 48)
        Me.btnAddUsers.TabIndex = 4
        '
        'btnSetSite
        '
        Me.btnSetSite.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.applications
        Me.btnSetSite.Location = New System.Drawing.Point(126, 68)
        Me.btnSetSite.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSetSite.Name = "btnSetSite"
        Me.btnSetSite.Size = New System.Drawing.Size(48, 48)
        Me.btnSetSite.TabIndex = 6
        '
        'btnEditAbout
        '
        Me.btnEditAbout.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.about
        Me.btnEditAbout.Location = New System.Drawing.Point(184, 68)
        Me.btnEditAbout.Margin = New System.Windows.Forms.Padding(5)
        Me.btnEditAbout.Name = "btnEditAbout"
        Me.btnEditAbout.Size = New System.Drawing.Size(48, 48)
        Me.btnEditAbout.TabIndex = 11
        '
        'btnVisitSite
        '
        Me.btnVisitSite.BackgroundImage = Global.Zdevo.Tools.My.Resources.Resources.home
        Me.btnVisitSite.Location = New System.Drawing.Point(242, 68)
        Me.btnVisitSite.Margin = New System.Windows.Forms.Padding(5)
        Me.btnVisitSite.Name = "btnVisitSite"
        Me.btnVisitSite.Size = New System.Drawing.Size(48, 48)
        Me.btnVisitSite.TabIndex = 7
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 128)
        Me.Controls.Add(Me.FlowLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Zdevo"
        Me.ContextMenuNotifyIcon.ResumeLayout(False)
        Me.FlowLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNewArticle As Zdevo.Tools.ImageControl
    Friend WithEvents btnNewWitter As Zdevo.Tools.ImageControl
    Friend WithEvents btnOpenMessage As Zdevo.Tools.ImageControl
    Friend WithEvents btnAddUsers As Zdevo.Tools.ImageControl
    Friend WithEvents btnSetSite As Zdevo.Tools.ImageControl
    Friend WithEvents btnVisitSite As Zdevo.Tools.ImageControl
    Friend WithEvents btnUploadFile As Zdevo.Tools.ImageControl
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuNotifyIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ImageControl1 As Zdevo.Tools.ImageControl
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageControl2 As Zdevo.Tools.ImageControl
    Friend WithEvents HelloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEditAbout As Zdevo.Tools.ImageControl

End Class
