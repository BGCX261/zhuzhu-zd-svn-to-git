Namespace [Schedule]

    Public Class Index

        Inherits Zdevo.Page.XmlrpcPage

        Implements IHttpHandler

        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

            Dim b As Boolean
            b = Me.System_Initialize

            zdevo_editFanfou(Container.User.Name, Container.User.Password, Zdevo.Common.Functions.Current.RequestFile(Container.Config("SITE_FANFOU_FEED").Value))

            If b = True Then
                Me.System_Terminate()
            End If

        End Sub

        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class

End Namespace
