Public MustInherit Class BaseList(Of T) : Inherits BaseEntry

    Implements IOperate(Of T)

    Public PageBar As New PageBar

    Private FItems As New List(Of T)
    Public Overridable Property Items() As List(Of T)
        Get
            Return FItems
        End Get
        Set(ByVal value As List(Of T))
            FItems = value
        End Set
    End Property

    Public MustOverride Function Del(ByVal ID As Integer) As Boolean Implements IOperate(Of T).Del

    Public MustOverride Function Del(ByVal GUID As System.Guid) As Boolean Implements IOperate(Of T).Del

    Public MustOverride Function Insert(ByVal Entry As T) As Boolean Implements IOperate(Of T).Insert

    Public MustOverride Function Load(ByVal ID As Integer) As T Implements IOperate(Of T).Load

    Public MustOverride Function Load(ByVal GUID As System.Guid) As T Implements IOperate(Of T).Load

    Public MustOverride Function List(ByVal Params As System.Collections.Generic.Dictionary(Of String, Object)) As Boolean Implements IOperate(Of T).List

    Public MustOverride Function Update(ByVal Entry As T) As Boolean Implements IOperate(Of T).Update

    Public MustOverride Function Load(ByVal ID As Integer, ByRef Entry As T) As Boolean Implements IOperate(Of T).Load

    Public MustOverride Function Load(ByVal GUID As System.Guid, ByRef Entry As T) As Boolean Implements IOperate(Of T).Load

    Public Overridable Function List(ByVal ParamName() As String, ByVal ParamValue() As Object) As Boolean Implements IOperate(Of T).List
        Dim Params As New System.Collections.Generic.Dictionary(Of String, Object)
        For i As Integer = 0 To ParamName.Length - 1
            Params.Add(ParamName(i), ParamValue(i))
        Next
        Return List(Params)
    End Function

End Class
