Public Class Gallery

    Inherits Core.Post

    Public Overridable Sub GetComments(Optional ByVal Page As Integer = 1)

    End Sub

    Public Overridable Property Link() As String
        Get
            Return Note
        End Get
        Set(ByVal value As String)
            Note = value
        End Set
    End Property


    Private FPermaLink As String = ""
    Public Overridable Property PermaLink() As String
        Get
            Return FPermaLink
        End Get
        Set(ByVal value As String)
            FPermaLink = value
        End Set
    End Property

End Class
