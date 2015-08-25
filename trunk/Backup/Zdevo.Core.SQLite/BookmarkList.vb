Public Class BookmarkList

    Inherits IPostList(Of Bookmark)

    Public Sub New(ByVal nowContainer As Container)
        MyBase.New(nowContainer)
    End Sub

    Public Overrides Function List(ByVal Params As System.Collections.Generic.Dictionary(Of String, Object)) As Boolean

        If Params Is Nothing Then
            Params = New System.Collections.Generic.Dictionary(Of String, Object)
        End If

        If Params.ContainsKey("Type") = False Then
            Params.Add("Type", PostType.Bookmark)
        End If

        If Params.ContainsKey("Link") = True Then
            If Params.ContainsKey("Note") = False Then
                Params.Add("Note", Params("Link"))
            Else
                Params("Note") = Params("Link")
            End If
        End If

        Return MyBase.List(Params)

    End Function

End Class
