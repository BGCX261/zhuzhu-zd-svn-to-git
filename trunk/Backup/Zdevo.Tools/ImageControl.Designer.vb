<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageControl
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
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
        Me.PictureBox = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'ImageControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PictureBox)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ImageControl"
        Me.Size = New System.Drawing.Size(60, 60)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox

End Class
