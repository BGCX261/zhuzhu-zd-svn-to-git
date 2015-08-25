Public Class PostList

    Inherits IPostList(Of Post)

    Public Sub New(ByVal nowContainer As Container)
        MyBase.New(nowContainer)
    End Sub

End Class
