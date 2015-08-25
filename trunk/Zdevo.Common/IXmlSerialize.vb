''' <summary>
''' 序列化和反序列化接口
''' </summary>
''' <remarks></remarks>
Public Interface IXmlSerialize(Of T)

    Function Serialize() As String
    Function DeSerializee(ByVal s As String) As Object

End Interface
