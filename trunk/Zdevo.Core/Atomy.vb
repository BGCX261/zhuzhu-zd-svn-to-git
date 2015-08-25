Public Class Atomy

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

End Class
