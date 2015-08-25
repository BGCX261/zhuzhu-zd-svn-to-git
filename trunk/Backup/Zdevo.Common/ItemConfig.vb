Public Class ItemConfig(Of T As Item)

    Inherits BaseConfig(Of T)

    Private Value As New System.Collections.Generic.Dictionary(Of String, T)

    Public Overrides ReadOnly Property Count() As Integer
        Get
            Return Me.Value.Count
        End Get
    End Property

    Public Overrides Sub Add(ByVal item As T)
        Value.Add(item.Name, item)
        MyBase.Add(item)
    End Sub

    Public Overrides Function Remove(ByVal item As T) As Boolean
        Value.Remove(item.Name)
        Return MyBase.Remove(item)
    End Function

    Public Overrides Sub Clear()
        Value.Clear()
        MyBase.Clear()
    End Sub

    Default Public Overridable Overloads Property Item(ByVal key As String) As T
        Get
            Return Value(key)
        End Get
        Set(ByVal value As T)
            Add(value)
        End Set
    End Property

    Public ReadOnly Property Keys() As System.Collections.Generic.Dictionary(Of String, T).KeyCollection
        Get
            Return Me.Value.Keys
        End Get
    End Property

    Public ReadOnly Property Values() As System.Collections.Generic.Dictionary(Of String, T).ValueCollection
        Get
            Return Me.Value.Values
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Overridable Function ContainsKey(ByVal key As String) As Boolean
        Return Me.Value.ContainsKey(key)
    End Function


    Public Overridable Function ContainsValue(ByVal value As T) As Boolean
        Return Me.Value.ContainsValue(value)
    End Function

    Public Sub New(ByVal ParamArray Param() As T)

        For Each p As T In Param
            Me.Add(p)
        Next

    End Sub


    Public Overloads Function Clone() As ItemConfig(Of T)
        'Return DirectCast(MyBase.Clone(), ItemConfig(Of T))

        Dim newItemConfig As New ItemConfig(Of T)
        For Each i As T In Me.Values
            newItemConfig.Add(DirectCast(New Item(String.Copy(i.Name), String.Copy(i.Value)), T))
        Next
        Return newItemConfig

    End Function


    Public Overloads Function LoadFile(ByVal newFileName As String) As ItemConfig(Of T)
        Return DirectCast(MyBase.LoadFile(newFileName), ItemConfig(Of T))
    End Function

    Public Overloads Function LoadString(ByVal s As String) As ItemConfig(Of T)
        Return DirectCast(Me.DeSerialize(s), ItemConfig(Of T))
    End Function

    Public Overrides Function DeSerialize(ByVal s As String) As Object
        Dim XmlFormatter As New XmlSerialize(Of ItemConfig(Of T))
        Return XmlFormatter.DeSerialize(s)
    End Function

    Public Overrides Function Serialize() As String
        Dim XmlFormatter As New XmlSerialize(Of ItemConfig(Of T))
        Return XmlFormatter.Serialize(Me)
    End Function

End Class

