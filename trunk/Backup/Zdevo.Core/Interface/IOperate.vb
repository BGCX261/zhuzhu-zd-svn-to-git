Public Interface IOperate(Of T)

    Function Load(ByVal ID As Integer) As T

    Function Load(ByVal ID As Integer, ByRef Entry As T) As Boolean

    Function Del(ByVal _ID As Integer) As Boolean

    Function Load(ByVal GUID As System.Guid) As T

    Function Load(ByVal GUID As System.Guid, ByRef Entry As T) As Boolean

    Function Del(ByVal GUID As System.Guid) As Boolean

    Function Insert(ByVal Entry As T) As Boolean

    Function Update(ByVal Entry As T) As Boolean

    Function List(ByVal Params As System.Collections.Generic.Dictionary(Of String, Object)) As Boolean

    Function List(ByVal ParamName() As String, ByVal ParamValue() As Object) As Boolean

End Interface