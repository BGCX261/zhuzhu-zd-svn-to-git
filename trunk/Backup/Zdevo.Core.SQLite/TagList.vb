Public Class TagList

    Inherits ICategoryList(Of Tag)

    Public Sub New(ByVal nowContainer As Container)
        MyBase.New(nowContainer)
    End Sub


    Public Overrides Function List(ByVal Params As System.Collections.Generic.Dictionary(Of String, Object)) As Boolean

        If Params Is Nothing Then
            Params = New System.Collections.Generic.Dictionary(Of String, Object)
        End If

        If Params.ContainsKey("Type") = False Then
            Params.Add("Type", CategoryType.Tag)
        End If

        Return MyBase.List(Params)

    End Function

End Class
