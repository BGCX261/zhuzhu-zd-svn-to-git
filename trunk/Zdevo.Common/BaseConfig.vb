Public MustInherit Class BaseConfig(Of T)

    Implements Collections.Generic.ICollection(Of T)
    Implements System.ICloneable

    Protected SortedList As New System.Collections.Generic.List(Of T)

    Public Overridable Sub Add(ByVal item As T) Implements System.Collections.Generic.ICollection(Of T).Add
        Me.SortedList.Add(item)
    End Sub

    Public Overridable Sub Clear() Implements System.Collections.Generic.ICollection(Of T).Clear
        Me.SortedList.Clear()
    End Sub

    Public Overridable Function Contains(ByVal item As T) As Boolean Implements System.Collections.Generic.ICollection(Of T).Contains
        Return SortedList.Contains(item)
    End Function

    Public Overridable Sub CopyTo(ByVal array() As T, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of T).CopyTo
        Me.SortedList.CopyTo(array, arrayIndex)
    End Sub

    Public Overridable ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of T).Count
        Get
            Return Me.SortedList.Count
        End Get
    End Property

    Public Overridable ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of T).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Overridable Function Remove(ByVal item As T) As Boolean Implements System.Collections.Generic.ICollection(Of T).Remove
        Me.SortedList.Remove(item)
    End Function

    Public Overridable Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of T) Implements System.Collections.Generic.IEnumerable(Of T).GetEnumerator
        Return Me.SortedList.GetEnumerator
    End Function

    Private Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me.SortedList.GetEnumerator
    End Function


    'Public Overridable Function DeSerialize(ByVal s As String) As Object Implements IXmlSerialize(Of BaseConfig(Of T)).DeSerializee
    '    Dim XmlFormatter As New XmlFormatter(Of BaseConfig(Of T)) '(Me)
    '    Return XmlFormatter.DeSerialize(s, Me)
    'End Function

    Public MustOverride Function DeSerialize(ByVal s As String) As Object

    Public MustOverride Function Serialize() As String

    'Public Overridable Function Serialize() As String
    '    Dim XmlFormatter As New XmlSerialize(Of BaseConfig(Of T)) '(Me)
    '    Return XmlFormatter.Serialize(Me)
    'End Function

    Public Overridable Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.DeSerialize(Me.Serialize)
    End Function

    Public Overridable Function LoadFile(ByVal newFileName As String) As Object
        Dim objStreamRed As New StreamReader(newFileName, System.Text.Encoding.UTF8)
        Using objStreamRed
            Return Me.DeSerialize(objStreamRed.ReadToEnd)
        End Using
    End Function

    Public Overridable Function LoadString(ByVal s As String) As Object
        Return Me.DeSerialize(s)
    End Function

    Public Overridable Function SaveFile(ByVal newFileName As String) As Boolean
        Dim objStreamWri As StreamWriter = New StreamWriter(newFileName, False, System.Text.Encoding.UTF8)

        Using objStreamWri
            objStreamWri.Write(Me.Serialize)
            Return True
        End Using
    End Function

    Default Public Overridable Property Item(ByVal index As Integer) As T
        Get
            Return Me.SortedList.Item(index)
        End Get
        Set(ByVal value As T)
            Me.SortedList.Item(index) = value
        End Set
    End Property

End Class
