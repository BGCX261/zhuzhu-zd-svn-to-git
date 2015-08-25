Public Class UserList

    Inherits IUserList(Of User)

    Public Sub New(ByVal nowContainer As Container)
        MyBase.New(nowContainer)
    End Sub

End Class
