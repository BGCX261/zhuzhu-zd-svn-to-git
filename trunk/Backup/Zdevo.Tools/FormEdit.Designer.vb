<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEdit
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10, 5, 10, 0)
        Me.Panel1.Size = New System.Drawing.Size(492, 348)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(10, 114)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(472, 190)
        Me.Panel5.TabIndex = 6
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel7.Size = New System.Drawing.Size(472, 190)
        Me.Panel7.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel8.Controls.Add(Me.WebBrowser1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(5, 5)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(462, 180)
        Me.Panel8.TabIndex = 0
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(458, 176)
        Me.WebBrowser1.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(10, 304)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(472, 44)
        Me.Panel6.TabIndex = 5
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(10, 5, 10, 10)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(472, 44)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(374, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "提交"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.SplitContainer1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(10, 72)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel4.Size = New System.Drawing.Size(472, 42)
        Me.Panel4.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(5, 17)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.LinkLabel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(462, 20)
        Me.SplitContainer1.SplitterDistance = 379
        Me.SplitContainer1.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(0, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(379, 20)
        Me.ComboBox1.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 4)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 12)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "刷新分类"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "分类"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(10, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel3.Size = New System.Drawing.Size(472, 45)
        Me.Panel3.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(5, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "标题"
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.Location = New System.Drawing.Point(5, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(462, 21)
        Me.TextBox1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 22)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "编辑文章"
        '
        'FormEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 348)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormEdit"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
