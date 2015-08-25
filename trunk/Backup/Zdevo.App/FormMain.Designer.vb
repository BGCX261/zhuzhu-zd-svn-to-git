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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 351)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(532, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(393, 359)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(119, 12)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "请访问www.zdevo.com"
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Padding = New System.Windows.Forms.Padding(5, 10, 5, 5)
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(532, 26)
        Me.FlowLayoutPanel6.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "1.先创建SQLite数据库"
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel5.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(0, 26)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(532, 39)
        Me.FlowLayoutPanel5.TabIndex = 17
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(429, 21)
        Me.TextBox1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(443, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "创建"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(0, 65)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(532, 21)
        Me.FlowLayoutPanel4.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "2.选择要导入的XML数据文件"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.TextBox2)
        Me.FlowLayoutPanel3.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(0, 86)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(532, 39)
        Me.FlowLayoutPanel3.TabIndex = 19
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(8, 8)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(429, 21)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "C:\Documents and Settings\Administrator\桌面\backup.xml"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(443, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "选择文件"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 125)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(532, 22)
        Me.FlowLayoutPanel2.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(8, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "3.转换输出记录"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 147)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(532, 204)
        Me.FlowLayoutPanel1.TabIndex = 21
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(8, 8)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(429, 187)
        Me.TextBox3.TabIndex = 14
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(443, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(77, 23)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "转换"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 373)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel3)
        Me.Controls.Add(Me.FlowLayoutPanel4)
        Me.Controls.Add(Me.FlowLayoutPanel5)
        Me.Controls.Add(Me.FlowLayoutPanel6)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "FormMain"
        Me.Text = "Zdevo.Switch-XML数据导入,转换SQLite数据生成器"
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents FlowLayoutPanel6 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel5 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
