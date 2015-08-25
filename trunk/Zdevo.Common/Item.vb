Public Class Item

    Public Name As String
    Public Value As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal newName As String, ByVal newValue As String)
        Name = newName
        Value = newValue
    End Sub

End Class
