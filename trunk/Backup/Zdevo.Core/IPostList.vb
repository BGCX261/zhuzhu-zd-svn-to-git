Public MustInherit Class IPostList(Of T As IPost)

    Inherits Core.BaseList(Of T)

    Public MustOverride Overloads Function Load(ByVal Post As Core.Post) As T

End Class
