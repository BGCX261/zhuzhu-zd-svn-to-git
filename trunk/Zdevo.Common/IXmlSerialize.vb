''' <summary>
''' ���л��ͷ����л��ӿ�
''' </summary>
''' <remarks></remarks>
Public Interface IXmlSerialize(Of T)

    Function Serialize() As String
    Function DeSerializee(ByVal s As String) As Object

End Interface
