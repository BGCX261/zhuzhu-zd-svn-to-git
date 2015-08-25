Public Class Article

    Inherits Core.Post

    Public Overridable Sub GetComments(Optional ByVal Page As Integer = 1)

    End Sub

    Private FTags As New System.Collections.Generic.List(Of Guid)
    Public Overridable Property Tags() As System.Collections.Generic.List(Of Guid)
        Get
            Return FTags
        End Get
        Set(ByVal value As System.Collections.Generic.List(Of Guid))
            FTags = value
        End Set
    End Property

    Public Overridable Function JoinTags(Optional ByVal Delimiter As String = " ") As String
        Return Nothing
    End Function

End Class
