Public Class ImageControl

    Dim bitmap1 As Bitmap
    Dim bitmap2 As Bitmap
    Dim bitmap3 As Bitmap
    Dim bitmap4 As Bitmap

    Sub ChangePicture(ByRef bitmap As Bitmap, ByVal c As Double)

        Dim b As Bitmap = bitmap1
        Dim g As Graphics = Graphics.FromImage(bitmap)
        Dim i As Double = c

        Using g

            g.Clear(color.Transparent)

            ' Initialize the color matrix.
            ' Note the value 0.8 in row 4, column 4.
            Dim matrixItems As Single()() = { _
               New Single() {1, 0, 0, 0, 0}, _
               New Single() {0, 1, 0, 0, 0}, _
               New Single() {0, 0, 1, 0, 0}, _
               New Single() {0, 0, 0, 1, 0}, _
               New Single() {i, i, i, 0, 1}}

            Dim colorMatrix As New Imaging.ColorMatrix(matrixItems)



            'Dim degrees As Single = 60.0F
            'Dim r As Double = degrees * System.Math.PI / 180 ' degrees to radians
            'Dim colorMatrixElements As Single()() = { _
            '   New Single() {CSng(System.Math.Cos(r)), CSng(System.Math.Sin(r)), 0, 0, 0}, _
            '   New Single() {0, CSng(System.Math.Cos(r)), CSng(System.Math.Sin(r)), 0, 0}, _
            '   New Single() {0, 0, CSng(System.Math.Cos(r)), CSng(System.Math.Sin(r)), 0}, _
            '   New Single() {0, 0, 0, 1, 0}, _
            '   New Single() {0, 0, 0, 0, 1}}

            'Dim colorMatrix As New Imaging.ColorMatrix(colorMatrixElements)



            ' Create an ImageAttributes object and set its color matrix.
            Dim imageAtt As New Imaging.ImageAttributes()
            imageAtt.SetColorMatrix(colorMatrix, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)


            g.DrawImage(b, New Rectangle(0, 0, b.Width, b.Height), 0.0F, 0.0F, b.Width, b.Height, GraphicsUnit.Pixel, imageAtt)

            g.Save()

        End Using

    End Sub

    Private Sub ImageControl_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackgroundImageChanged

        If Me.BackgroundImage IsNot Nothing Then
            Me.PictureBox.Image = Me.BackgroundImage
            bitmap1 = New Bitmap(Me.BackgroundImage.Width, Me.BackgroundImage.Height)
            bitmap2 = New Bitmap(Me.BackgroundImage.Width, Me.BackgroundImage.Height)
            bitmap3 = New Bitmap(Me.BackgroundImage.Width, Me.BackgroundImage.Height)
            bitmap4 = New Bitmap(Me.BackgroundImage.Width, Me.BackgroundImage.Height)

            Dim g As Graphics = System.Drawing.Graphics.FromImage(Me.bitmap1)
            Using g
                g.DrawImage(Me.BackgroundImage, 0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height)
                g.Save()
            End Using
        End If
        Me.Width = Me.BackgroundImage.Width
        Me.PictureBox.Width = Me.BackgroundImage.Width
        Me.Height = Me.BackgroundImage.Height
        Me.PictureBox.Height = Me.BackgroundImage.Height

    End Sub

    Private Sub PictureBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox.Click
        Me.OnClick(e)
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseDown
        Me.ChangePicture(PictureBox.Image, 0.2)
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox.MouseEnter
        Me.ChangePicture(PictureBox.Image, 0.1)
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox.MouseLeave
        Me.ChangePicture(PictureBox.Image, 0)
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox.MouseUp
        Me.ChangePicture(PictureBox.Image, 0.1)
    End Sub

    Private Sub ImageControl_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.ChangePicture(PictureBox.Image, 0.1)
    End Sub


    Private Sub ImageControl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.ChangePicture(PictureBox.Image, 0)
    End Sub

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        bitmap1 = New Bitmap(60, 60)
        bitmap2 = New Bitmap(60, 60)
        bitmap3 = New Bitmap(60, 60)
        bitmap4 = New Bitmap(60, 60)

    End Sub

    Protected Overrides Sub Finalize()

        bitmap1.Dispose()
        bitmap2.Dispose()
        bitmap3.Dispose()
        bitmap4.Dispose()

        MyBase.Finalize()
    End Sub

    Private Sub ImageControl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Me.OnClick(e)
    End Sub
End Class
