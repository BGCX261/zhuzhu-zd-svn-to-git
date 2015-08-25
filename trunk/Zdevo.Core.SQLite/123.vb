'Public Class CategoryList : Inherits Core.BaseList(Of Category)

'    Private FContainer As Container
'    Protected Overloads Property Container() As Container
'        Get
'            Return FContainer
'        End Get
'        Set(ByVal value As Container)
'            FContainer = value
'        End Set
'    End Property

'    Public Sub New(ByVal nowContainer As Container)
'        Container = nowContainer
'    End Sub


'    Public Overrides Function Insert(ByVal Entry As Category) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "INSERT INTO [zd_category] ("
'        cmd.CommandText += "[GUID],[IsDisable],[IsUnaudited],[IsDelete],[Name],[AliasName],[Intro],[Content],[Note],[CreateTime],[ModifiTime],[ParentGUID],[SiteGUID],[UserGUID],[Meta],[Order],[PostNums],[Type]"
'        cmd.CommandText += ") VALUES ("
'        cmd.CommandText += "@GUID,@IsDisable,@IsUnaudited,@IsDelete,@Name,@AliasName,@Intro,@Content,@Note,@CreateTime,@ModifiTime,@ParentGUID,@SiteGUID,@UserGUID,@Meta,@Order,@PostNums,@Type"
'        cmd.CommandText += ")"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Order As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Order", System.Data.DbType.Int32)
'        param_Order.Value = Entry.Order
'        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
'        param_PostNums.Value = Entry.PostNums
'        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
'        param_Type.Value = Entry.Type

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Order)
'        cmd.Parameters.Add(param_PostNums)
'        cmd.Parameters.Add(param_Type)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function


'    Public Overrides Function Update(ByVal Entry As Category) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "UPDATE [zd_category] SET "
'        cmd.CommandText += "[GUID]=@GUID,[IsDisable]=@IsDisable,[IsUnaudited]=@IsUnaudited,[IsDelete]=@IsDelete,[Name]=@Name,[AliasName]=@AliasName,[Intro]=@Intro,[Content]=@Content,[Note]=@Note,[CreateTime]=@CreateTime,[ModifiTime]=@ModifiTime,[ParentGUID]=@ParentGUID,[SiteGUID]=@SiteGUID,[UserGUID]=@UserGUID,[Meta]=@Meta,[Order]=@Order,[PostNums]=@PostNums,[Type]=@Type"
'        cmd.CommandText += " WHERE [ID]=@ID"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Order As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Order", System.Data.DbType.Int32)
'        param_Order.Value = Entry.Order
'        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
'        param_PostNums.Value = Entry.PostNums
'        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
'        param_Type.Value = Entry.Type

'        Dim param_ID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ID", System.Data.DbType.Int32)
'        param_ID.Value = Entry.ID
'        cmd.Parameters.Add(param_ID)

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Order)
'        cmd.Parameters.Add(param_PostNums)
'        cmd.Parameters.Add(param_Type)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function List(ByVal Params As Common.MetaConfig(Of Common.Meta)) As Boolean

'        If Params Is Nothing Then
'            Params = New Common.MetaConfig(Of Common.Meta)
'        End If

'        Dim SqlParams As New System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)

'        Dim strWhere As String = " WHERE (1=1) "
'        Dim strOrder As String = " ORDER BY "
'        Dim strPages As String = " LIMIT @PageSize OFFSET @Page"

'        Dim Page As New Integer
'        Dim PageSize As New Integer
'        Dim UrlRegex As String = String.Empty
'        Dim PageBar_PageSize As New Integer

'        Dim IsDisable As Boolean = False
'        Dim IsUnaudited As Boolean = False
'        Dim IsDelete As Boolean = False

'        Dim Type As Core.CategoryType = CategoryType.Unknown

'        Dim PathRegexConfig As Common.Config(Of Common.Item)

'        If Params.ContainsKey("Page") = True Then
'            If IsNumeric(Params("Page").Value) Then
'                Page = CInt(Params("Page").Value)
'            Else
'                Page = 1
'            End If
'        End If

'        If Params.ContainsKey("PageSize") = True Then
'            PageSize = CInt(Params("PageSize").Value)
'        End If

'        If Params.ContainsKey("UrlRegex") = True Then
'            UrlRegex = CStr(Params("UrlRegex").Value)
'        End If

'        If Params.ContainsKey("PageBar_PageSize") = True Then
'            PageBar_PageSize = CInt(Params("PageBar_PageSize").Value)
'        Else
'            PageBar_PageSize = PageSize
'        End If

'        If Params.ContainsKey("IsDisable") = True Then
'            strWhere += "AND ([IsDisable]=@IsDisable)"
'            IsDisable = CBool(Params("IsDisable").Value)
'        End If
'        If Params.ContainsKey("IsUnaudited") = True Then
'            strWhere += "AND ([IsUnaudited]=@IsUnaudited)"
'            IsUnaudited = CBool(Params("IsUnaudited").Value)
'        End If
'        If Params.ContainsKey("IsDelete") = True Then
'            strWhere += "AND ([IsDelete]=@IsDelete)"
'            IsUnaudited = CBool(Params("IsDelete").Value)
'        End If

'        If Params.ContainsKey("Type") = True Then
'            Type = CType(Params("Type").Value, Core.CategoryType)
'        Else
'            Type = CategoryType.Catalog
'        End If
'        strWhere += "AND ([Type]=@Type)"


'        If Page < 1 Then
'            Page = 1
'        End If

'        If PageSize = 0 Then
'            strPages = ""
'        End If

'        If String.Compare(strOrder, " ORDER BY ") = 0 Then
'            strOrder += "[ID] ASC"
'        End If

'        Dim param_PageSize As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PageSize", System.Data.DbType.Int32)
'        param_PageSize.Value = PageSize
'        SqlParams.Add(param_PageSize)

'        Dim param_Page As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Page", System.Data.DbType.Int32)
'        param_Page.Value = (Page - 1) * PageSize
'        SqlParams.Add(param_Page)

'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = IsDisable
'        SqlParams.Add(param_IsDisable)

'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = IsUnaudited
'        SqlParams.Add(param_IsUnaudited)

'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = IsDelete
'        SqlParams.Add(param_IsDelete)

'        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
'        param_Type.Value = Type
'        SqlParams.Add(param_Type)

'        If Params.ContainsKey("PathRegexConfig") = True Then
'            PathRegexConfig = CType(Params("PathRegexConfig").Value, Common.Config(Of Common.Item))
'        Else
'            PathRegexConfig = DirectCast(Me.Container.Action2RegexSplitConfig.Clone, Common.Config(Of Common.Item))
'        End If
'        PathRegexConfig("{%HostDirectory%}").Value = Me.Container.GlobalConfig("APPLICATION_HOST").Value

'        Return Me.List(Page, PageSize, UrlRegex, PathRegexConfig, PageBar_PageSize, strWhere, strOrder, strPages, SqlParams)

'    End Function

'    Public Overloads Function List(ByVal Page As Integer, ByVal PageSize As Integer, ByVal UrlRegex As String, ByVal PathRegexConfig As Common.Config(Of Common.Item), ByVal PageBar_PageSize As Integer, ByVal SqlWhere As String, ByVal SqlOrder As String, ByVal SqlPages As String, ByVal Params As System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)) As Boolean

'        Dim strWhere As String = SqlWhere
'        Dim strOrder As String = SqlOrder
'        Dim strPages As String = SqlPages


'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_category]" + strWhere + strOrder + strPages

'        Dim cmd2 As Data.SQLite.SQLiteCommand
'        cmd2 = Me.Container.Connection.CreateCommand()
'        cmd2.CommandText = "SELECT COUNT([ID]) FROM [zd_category]" + strWhere

'        For Each Param As Data.SQLite.SQLiteParameter In Params
'            cmd.Parameters.Add(Param)
'            cmd2.Parameters.Add(Param)
'        Next

'        Dim DataReader2 As Data.SQLite.SQLiteDataReader = cmd2.ExecuteReader(CommandBehavior.Default)
'        If DataReader2.HasRows = True Then
'            DataReader2.Read()
'            If PageBar_PageSize > 0 Then
'                PageBar.Make(PageBar_PageSize, Page, DataReader2.GetInt32(0), CInt(Container.SiteConfig("SITE_PAGEBAR_COUNT").Value), UrlRegex, PathRegexConfig)
'            End If
'        End If
'        DataReader2.Close()
'        cmd2.Dispose()


'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader.HasRows = False Then
'            Return False
'        End If
'        Do While DataReader.Read
'            MyClass.Items.Add(Load(DataReader.GetGuid(1)))
'        Loop

'        DataReader.Close()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function Load(ByVal GUID As System.Guid) As Category

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_category] WHERE [GUID]=@guid"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
'        param.Value = GUID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer) As Category

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_category] WHERE [ID]=@id"

'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
'        param.Value = ID
'        cmd.Parameters.Add(param)

'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function


'    Public Overloads Function Load(ByVal DataReader As Data.SQLite.SQLiteDataReader) As Category

'        Dim Entry As New Category(Container)
'        Do While DataReader.Read

'            Entry.ID = DataReader.GetInt32(0)
'            Entry.GUID = DataReader.GetGuid(1)

'            Entry.IsDisable = DataReader.GetBoolean(2)
'            Entry.IsUnaudited = DataReader.GetBoolean(3)
'            Entry.IsDelete = DataReader.GetBoolean(4)

'            If DataReader.IsDBNull(5) = False Then Entry.Name = DataReader.GetString(5)
'            If DataReader.IsDBNull(6) = False Then Entry.AliasName = DataReader.GetString(6)
'            If DataReader.IsDBNull(7) = False Then Entry.Intro = DataReader.GetString(7)
'            If DataReader.IsDBNull(8) = False Then Entry.Content = DataReader.GetString(8)
'            If DataReader.IsDBNull(9) = False Then Entry.Note = DataReader.GetString(9)

'            Entry.CreateTime = DataReader.GetDateTime(10)
'            Entry.ModifiTime = DataReader.GetDateTime(11)

'            Entry.ParentGUID = DataReader.GetGuid(12)
'            Entry.SiteGUID = DataReader.GetGuid(13)
'            Entry.UserGUID = DataReader.GetGuid(14)

'            If DataReader.IsDBNull(15) Then
'                'Dim a As New ASCIIEncoding
'                'Dim s As String = a.GetString(CType(DataReader.GetValue(15), Byte()))
'                'Entry.Meta.DeSerialize(s)
'            End If

'            Entry.Order = DataReader.GetInt32(16)
'            Entry.PostNums = DataReader.GetInt32(17)
'            Entry.Type = CType(DataReader.GetInt32(18), Zdevo.Core.CategoryType)

'        Loop

'        Return Entry

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer, ByRef Entry As Category) As Boolean
'        Entry = Load(ID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'    Public Overrides Function Load(ByVal GUID As Guid, ByRef Entry As Category) As Boolean
'        Entry = Load(GUID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'End Class



'Public Class CommentList : Inherits Core.BaseList(Of Comment)

'    Private FContainer As Container
'    Protected Overloads Property Container() As Container
'        Get
'            Return FContainer
'        End Get
'        Set(ByVal value As Container)
'            FContainer = value
'        End Set
'    End Property

'    Public Sub New(ByVal nowContainer As Container)
'        Container = nowContainer
'    End Sub

'    Public Overrides Function Insert(ByVal Entry As Comment) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "INSERT INTO [zd_comment] ("
'        cmd.CommandText += "[GUID],[IsDisable],[IsUnaudited],[IsDelete],[Name],[AliasName],[Intro],[Content],[Note],[CreateTime],[ModifiTime],[ParentGUID],[SiteGUID],[UserGUID],[Meta],[Email],[HomePage],[PostGUID],[IP]"
'        cmd.CommandText += ") VALUES ("
'        cmd.CommandText += "@GUID,@IsDisable,@IsUnaudited,@IsDelete,@Name,@AliasName,@Intro,@Content,@Note,@CreateTime,@ModifiTime,@ParentGUID,@SiteGUID,@UserGUID,@Meta,@Email,@HomePage,@PostGUID,@IP"
'        cmd.CommandText += ")"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Email As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Email", System.Data.DbType.String)
'        param_Email.Value = Entry.Email
'        Dim param_HomePage As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@HomePage", System.Data.DbType.String)
'        param_HomePage.Value = Entry.HomePage
'        Dim param_PostGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostGUID", System.Data.DbType.Guid)
'        param_PostGUID.Value = Entry.PostGUID
'        Dim param_IP As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IP", System.Data.DbType.String)
'        param_IP.Value = Entry.IP

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Email)
'        cmd.Parameters.Add(param_HomePage)
'        cmd.Parameters.Add(param_PostGUID)
'        cmd.Parameters.Add(param_IP)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function


'    Public Overrides Function Update(ByVal Entry As Comment) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "UPDATE [zd_comment] SET "
'        cmd.CommandText += "[GUID]=@GUID,[IsDisable]=@IsDisable,[IsUnaudited]=@IsUnaudited,[IsDelete]=@IsDelete,[Name]=@Name,[AliasName]=@AliasName,[Intro]=@Intro,[Content]=@Content,[Note]=@Note,[CreateTime]=@CreateTime,[ModifiTime]=@ModifiTime,[ParentGUID]=@ParentGUID,[SiteGUID]=@SiteGUID,[Meta]=@Meta,[UserGUID]=@UserGUID,[Email]=@Email,[HomePage]=@HomePage,[PostGUID]=@PostGUID,[IP]=@IP"
'        cmd.CommandText += " WHERE [ID]=@ID"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Email As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Email", System.Data.DbType.String)
'        param_Email.Value = Entry.Email
'        Dim param_HomePage As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@HomePage", System.Data.DbType.String)
'        param_HomePage.Value = Entry.HomePage
'        Dim param_PostGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostGUID", System.Data.DbType.Guid)
'        param_PostGUID.Value = Entry.PostGUID
'        Dim param_IP As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IP", System.Data.DbType.String)
'        param_IP.Value = Entry.IP

'        Dim param_ID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ID", System.Data.DbType.Int32)
'        param_ID.Value = Entry.ID
'        cmd.Parameters.Add(param_ID)

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Email)
'        cmd.Parameters.Add(param_HomePage)
'        cmd.Parameters.Add(param_PostGUID)
'        cmd.Parameters.Add(param_IP)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function


'    Public Overrides Function List(ByVal Params As Common.MetaConfig(Of Common.Meta)) As Boolean

'        If Params Is Nothing Then
'            Params = New Common.MetaConfig(Of Common.Meta)
'        End If

'        Dim SqlParams As New System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)

'        Dim strWhere As String = " WHERE (1=1) "
'        Dim strOrder As String = " ORDER BY "
'        Dim strPages As String = " LIMIT @PageSize OFFSET @Page"

'        Dim Page As New Integer
'        Dim PageSize As New Integer
'        Dim UrlRegex As String = String.Empty
'        Dim PageBar_PageSize As New Integer

'        Dim IsDisable As Boolean = False
'        Dim IsUnaudited As Boolean = False
'        Dim IsDelete As Boolean = False

'        Dim PathRegexConfig As Common.Config(Of Common.Item)

'        Dim PostGUID As Guid = Guid.Empty

'        If Params.ContainsKey("Page") = True Then
'            If IsNumeric(Params("Page").Value) Then
'                Page = CInt(Params("Page").Value)
'            Else
'                Page = 1
'            End If
'        End If

'        If Params.ContainsKey("PageSize") = True Then
'            PageSize = CInt(Params("PageSize").Value)
'        End If

'        If Params.ContainsKey("UrlRegex") = True Then
'            UrlRegex = CStr(Params("UrlRegex").Value)
'        End If

'        If Params.ContainsKey("PageBar_PageSize") = True Then
'            PageBar_PageSize = CInt(Params("PageBar_PageSize").Value)
'        Else
'            PageBar_PageSize = PageSize
'        End If

'        If Params.ContainsKey("IsDisable") = True Then
'            strWhere += "AND ([IsDisable]=@IsDisable)"
'            IsDisable = CBool(Params("IsDisable").Value)
'        End If
'        If Params.ContainsKey("IsUnaudited") = True Then
'            strWhere += "AND ([IsUnaudited]=@IsUnaudited)"
'            IsUnaudited = CBool(Params("IsUnaudited").Value)
'        End If
'        If Params.ContainsKey("IsDelete") = True Then
'            strWhere += "AND ([IsDelete]=@IsDelete)"
'            IsUnaudited = CBool(Params("IsDelete").Value)
'        End If

'        If Params.ContainsKey("PostGUID") = True Then
'            PostGUID = CType(Params("PostGUID").Value, Guid)
'            strWhere += "AND ([PostGUID]=@PostGUID)"
'        End If

'        If Page < 1 Then
'            Page = 1
'        End If

'        If PageSize = 0 Then
'            strPages = ""
'        End If

'        If String.Compare(strOrder, " ORDER BY ") = 0 Then
'            strOrder += "[CreateTime] DESC"
'        End If

'        Dim param_PageSize As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PageSize", System.Data.DbType.Int32)
'        param_PageSize.Value = PageSize
'        SqlParams.Add(param_PageSize)

'        Dim param_Page As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Page", System.Data.DbType.Int32)
'        param_Page.Value = (Page - 1) * PageSize
'        SqlParams.Add(param_Page)

'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = IsDisable
'        SqlParams.Add(param_IsDisable)

'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = IsUnaudited
'        SqlParams.Add(param_IsUnaudited)

'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = IsDelete
'        SqlParams.Add(param_IsDelete)

'        Dim param_PostGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostGUID", System.Data.DbType.Guid)
'        param_PostGUID.Value = PostGUID
'        SqlParams.Add(param_PostGUID)


'        If Params.ContainsKey("PathRegexConfig") = True Then
'            PathRegexConfig = CType(Params("PathRegexConfig").Value, Common.Config(Of Common.Item))
'        Else
'            PathRegexConfig = DirectCast(Me.Container.Action2RegexSplitConfig.Clone, Common.Config(Of Common.Item))
'        End If
'        PathRegexConfig("{%HostDirectory%}").Value = Me.Container.GlobalConfig("APPLICATION_HOST").Value

'        Return Me.List(Page, PageSize, UrlRegex, PathRegexConfig, PageBar_PageSize, strWhere, strOrder, strPages, SqlParams)

'    End Function

'    Public Overloads Function List(ByVal Page As Integer, ByVal PageSize As Integer, ByVal UrlRegex As String, ByVal PathRegexConfig As Common.Config(Of Common.Item), ByVal PageBar_PageSize As Integer, ByVal SqlWhere As String, ByVal SqlOrder As String, ByVal SqlPages As String, ByVal Params As System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)) As Boolean

'        Dim strWhere As String = SqlWhere
'        Dim strOrder As String = SqlOrder
'        Dim strPages As String = SqlPages


'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_comment]" + strWhere + strOrder + strPages

'        Dim cmd2 As Data.SQLite.SQLiteCommand
'        cmd2 = Me.Container.Connection.CreateCommand()
'        cmd2.CommandText = "SELECT COUNT([ID]) FROM [zd_comment]" + strWhere

'        For Each Param As Data.SQLite.SQLiteParameter In Params
'            cmd.Parameters.Add(Param)
'            cmd2.Parameters.Add(Param)
'        Next

'        Dim DataReader2 As Data.SQLite.SQLiteDataReader = cmd2.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader2.HasRows = True Then
'            DataReader2.Read()
'            If PageBar_PageSize > 0 Then
'                PageBar.Make(PageBar_PageSize, Page, DataReader2.GetInt32(0), CInt(Container.SiteConfig("SITE_PAGEBAR_COUNT").Value), UrlRegex, PathRegexConfig)
'            End If
'        End If
'        DataReader2.Close()
'        cmd2.Dispose()


'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader.HasRows = False Then
'            Return False
'        End If
'        Do While DataReader.Read
'            Me.Items.Add(Load(DataReader.GetGuid(1)))
'        Loop

'        DataReader.Close()
'        cmd.Dispose()

'        Return True

'    End Function


'    Public Overrides Function Load(ByVal GUID As System.Guid) As Comment

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_comment] WHERE [GUID]=@guid"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
'        param.Value = GUID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer) As Comment

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_comment] WHERE [ID]=@id"

'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
'        param.Value = ID
'        cmd.Parameters.Add(param)

'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function


'    Public Overloads Function Load(ByVal DataReader As Data.SQLite.SQLiteDataReader) As Comment

'        Dim Entry As New Comment(Container)
'        Do While DataReader.Read

'            Entry.ID = DataReader.GetInt32(0)
'            Entry.GUID = DataReader.GetGuid(1)

'            Entry.IsDisable = DataReader.GetBoolean(2)
'            Entry.IsUnaudited = DataReader.GetBoolean(3)
'            Entry.IsDelete = DataReader.GetBoolean(4)

'            If DataReader.IsDBNull(5) = False Then Entry.Name = DataReader.GetString(5)
'            If DataReader.IsDBNull(6) = False Then Entry.AliasName = DataReader.GetString(6)
'            If DataReader.IsDBNull(7) = False Then Entry.Intro = DataReader.GetString(7)
'            If DataReader.IsDBNull(8) = False Then Entry.Content = DataReader.GetString(8)
'            If DataReader.IsDBNull(9) = False Then Entry.Note = DataReader.GetString(9)

'            Entry.CreateTime = DataReader.GetDateTime(10)
'            Entry.ModifiTime = DataReader.GetDateTime(11)

'            Entry.ParentGUID = DataReader.GetGuid(12)
'            Entry.SiteGUID = DataReader.GetGuid(13)
'            Entry.UserGUID = DataReader.GetGuid(14)

'            If DataReader.IsDBNull(15) Then
'                'Dim a As New ASCIIEncoding
'                'Dim s As String = a.GetString(CType(DataReader.GetValue(15), Byte()))
'                'Entry.Meta.DeSerialize(s)
'            End If

'            If DataReader.IsDBNull(16) = False Then Entry.Email = DataReader.GetString(16)
'            If DataReader.IsDBNull(17) = False Then Entry.HomePage = DataReader.GetString(17)
'            Entry.PostGUID = DataReader.GetGuid(18)
'            If DataReader.IsDBNull(19) = False Then Entry.IP = DataReader.GetString(19)

'        Loop

'        Return Entry

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer, ByRef Entry As Comment) As Boolean
'        Entry = Load(ID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'    Public Overrides Function Load(ByVal GUID As Guid, ByRef Entry As Comment) As Boolean
'        Entry = Load(GUID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'End Class


'Public Class PostList : Inherits Core.BaseList(Of Post)

'    Private FContainer As Container
'    Protected Overloads Property Container() As Container
'        Get
'            Return FContainer
'        End Get
'        Set(ByVal value As Container)
'            FContainer = value
'        End Set
'    End Property

'    Public Sub New(ByVal nowContainer As Container)
'        Container = nowContainer
'    End Sub


'    Public Overrides Function Insert(ByVal Entry As Post) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "INSERT INTO [zd_post] ("
'        cmd.CommandText += "[GUID],[IsDisable],[IsUnaudited],[IsDelete],[Name],[AliasName],[Intro],[Content],[Note],[CreateTime],[ModifiTime],[ParentGUID],[SiteGUID],[UserGUID],[Meta],[Type],[CommentNums],[ViewNums],[IsTop],[IsDraft],[IsPrivate],[IsClose],[CategoryGUID]"
'        cmd.CommandText += ") VALUES ("
'        cmd.CommandText += "@GUID,@IsDisable,@IsUnaudited,@IsDelete,@Name,@AliasName,@Intro,@Content,@Note,@CreateTime,@ModifiTime,@ParentGUID,@SiteGUID,@UserGUID,@Meta,@Type,@CommentNums,@ViewNums,@IsTop,@IsDraft,@IsPrivate,@IsClose,@CategoryGUID"
'        cmd.CommandText += ")"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
'        param_Type.Value = Entry.Type
'        Dim param_CommentNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CommentNums", System.Data.DbType.Int32)
'        param_CommentNums.Value = Entry.CommentNums
'        Dim param_ViewNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ViewNums", System.Data.DbType.Int32)
'        param_ViewNums.Value = Entry.ViewNums
'        Dim param_IsTop As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsTop", System.Data.DbType.Boolean)
'        param_IsTop.Value = Entry.IsTop
'        Dim param_IsDraft As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDraft", System.Data.DbType.Boolean)
'        param_IsDraft.Value = Entry.IsDraft
'        Dim param_IsPrivate As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsPrivate", System.Data.DbType.Boolean)
'        param_IsPrivate.Value = Entry.IsPrivate
'        Dim param_IsClose As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsClose", System.Data.DbType.Boolean)
'        param_IsClose.Value = Entry.IsClose
'        Dim param_CategoryGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CategoryGUID", System.Data.DbType.Guid)
'        param_CategoryGUID.Value = Entry.CategoryGUID

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Type)
'        cmd.Parameters.Add(param_CommentNums)
'        cmd.Parameters.Add(param_ViewNums)
'        cmd.Parameters.Add(param_IsTop)
'        cmd.Parameters.Add(param_IsDraft)
'        cmd.Parameters.Add(param_IsPrivate)
'        cmd.Parameters.Add(param_IsClose)
'        cmd.Parameters.Add(param_CategoryGUID)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function Update(ByVal Entry As Post) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "UPDATE [zd_post] SET "
'        cmd.CommandText += "[GUID]=@GUID,[IsDisable]=@IsDisable,[IsUnaudited]=@IsUnaudited,[IsDelete]=@IsDelete,[Name]=@Name,[AliasName]=@AliasName,[Intro]=@Intro,[Content]=@Content,[Note]=@Note,[CreateTime]=@CreateTime,[ModifiTime]=@ModifiTime,[ParentGUID]=@ParentGUID,[SiteGUID]=@SiteGUID,[UserGUID]=@UserGUID,[Meta]=@Meta,[Type]=@Type,[CommentNums]=@CommentNums,[ViewNums]=@ViewNums,[IsTop]=@IsTop,[IsDraft]=@IsDraft,[IsPrivate]=@IsPrivate,[IsClose]=@IsClose,[CategoryGUID]=@CategoryGUID"
'        cmd.CommandText += " WHERE [ID]=@ID"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
'        param_Type.Value = Entry.Type
'        Dim param_CommentNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CommentNums", System.Data.DbType.Int32)
'        param_CommentNums.Value = Entry.CommentNums
'        Dim param_ViewNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ViewNums", System.Data.DbType.Int32)
'        param_ViewNums.Value = Entry.ViewNums
'        Dim param_IsTop As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsTop", System.Data.DbType.Boolean)
'        param_IsTop.Value = Entry.IsTop
'        Dim param_IsDraft As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDraft", System.Data.DbType.Boolean)
'        param_IsDraft.Value = Entry.IsDraft
'        Dim param_IsPrivate As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsPrivate", System.Data.DbType.Boolean)
'        param_IsPrivate.Value = Entry.IsPrivate
'        Dim param_IsClose As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsClose", System.Data.DbType.Boolean)
'        param_IsClose.Value = Entry.IsClose
'        Dim param_CategoryGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CategoryGUID", System.Data.DbType.Guid)
'        param_CategoryGUID.Value = Entry.CategoryGUID

'        Dim param_ID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ID", System.Data.DbType.Int32)
'        param_ID.Value = Entry.ID
'        cmd.Parameters.Add(param_ID)

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Type)
'        cmd.Parameters.Add(param_CommentNums)
'        cmd.Parameters.Add(param_ViewNums)
'        cmd.Parameters.Add(param_IsTop)
'        cmd.Parameters.Add(param_IsDraft)
'        cmd.Parameters.Add(param_IsPrivate)
'        cmd.Parameters.Add(param_IsClose)
'        cmd.Parameters.Add(param_CategoryGUID)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function List(ByVal Params As Common.MetaConfig(Of Common.Meta)) As Boolean

'        If Params Is Nothing Then
'            Params = New Common.MetaConfig(Of Common.Meta)
'        End If

'        Dim SqlParams As New System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)

'        Dim strWhere As String = " WHERE (1=1) "
'        Dim strOrder As String = " ORDER BY "
'        Dim strPages As String = " LIMIT @PageSize OFFSET @Page"

'        Dim Page As New Integer
'        Dim PageSize As New Integer
'        Dim UrlRegex As String = String.Empty
'        Dim PageBar_PageSize As New Integer

'        Dim IsDisable As Boolean = False
'        Dim IsUnaudited As Boolean = False
'        Dim IsDelete As Boolean = False

'        Dim Type As Core.PostType = PostType.Unknown

'        Dim PathRegexConfig As Common.Config(Of Common.Item)

'        If Params.ContainsKey("Page") = True Then
'            If IsNumeric(Params("Page").Value) Then
'                Page = CInt(Params("Page").Value)
'            Else
'                Page = 1
'            End If
'        End If

'        If Params.ContainsKey("PageSize") = True Then
'            PageSize = CInt(Params("PageSize").Value)
'        End If

'        If Params.ContainsKey("UrlRegex") = True Then
'            UrlRegex = CStr(Params("UrlRegex").Value)
'        End If

'        If Params.ContainsKey("PageBar_PageSize") = True Then
'            PageBar_PageSize = CInt(Params("PageBar_PageSize").Value)
'        Else
'            PageBar_PageSize = PageSize
'        End If

'        If Params.ContainsKey("IsDisable") = True Then
'            strWhere += "AND ([IsDisable]=@IsDisable)"
'            IsDisable = CBool(Params("IsDisable").Value)
'        End If
'        If Params.ContainsKey("IsUnaudited") = True Then
'            strWhere += "AND ([IsUnaudited]=@IsUnaudited)"
'            IsUnaudited = CBool(Params("IsUnaudited").Value)
'        End If
'        If Params.ContainsKey("IsDelete") = True Then
'            strWhere += "AND ([IsDelete]=@IsDelete)"
'            IsUnaudited = CBool(Params("IsDelete").Value)
'        End If

'        If Params.ContainsKey("Type") = True Then
'            Type = CType(Params("Type").Value, Core.PostType)
'        Else
'            Type = PostType.Article
'        End If
'        strWhere += "AND ([Type]=@Type)"


'        If Page < 1 Then
'            Page = 1
'        End If

'        If PageSize = 0 Then
'            strPages = ""
'        End If

'        If String.Compare(strOrder, " ORDER BY ") = 0 Then
'            strOrder += "[CreateTime] DESC"
'        End If

'        Dim param_PageSize As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PageSize", System.Data.DbType.Int32)
'        param_PageSize.Value = PageSize
'        SqlParams.Add(param_PageSize)

'        Dim param_Page As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Page", System.Data.DbType.Int32)
'        param_Page.Value = (Page - 1) * PageSize
'        SqlParams.Add(param_Page)

'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = IsDisable
'        SqlParams.Add(param_IsDisable)

'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = IsUnaudited
'        SqlParams.Add(param_IsUnaudited)

'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = IsDelete
'        SqlParams.Add(param_IsDelete)

'        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
'        param_Type.Value = Type
'        SqlParams.Add(param_Type)


'        If Params.ContainsKey("PathRegexConfig") = True Then
'            PathRegexConfig = CType(Params("PathRegexConfig").Value, Common.Config(Of Common.Item))
'        Else
'            PathRegexConfig = DirectCast(Me.Container.Action2RegexSplitConfig.Clone, Common.Config(Of Common.Item))
'        End If
'        PathRegexConfig("{%HostDirectory%}").Value = Me.Container.GlobalConfig("APPLICATION_HOST").Value

'        Return Me.List(Page, PageSize, UrlRegex, PathRegexConfig, PageBar_PageSize, strWhere, strOrder, strPages, SqlParams)

'    End Function

'    Public Overloads Function List(ByVal Page As Integer, ByVal PageSize As Integer, ByVal UrlRegex As String, ByVal PathRegexConfig As Common.Config(Of Common.Item), ByVal PageBar_PageSize As Integer, ByVal SqlWhere As String, ByVal SqlOrder As String, ByVal SqlPages As String, ByVal Params As System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)) As Boolean

'        Dim strWhere As String = SqlWhere
'        Dim strOrder As String = SqlOrder
'        Dim strPages As String = SqlPages


'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_post]" + strWhere + strOrder + strPages

'        Dim cmd2 As Data.SQLite.SQLiteCommand
'        cmd2 = Me.Container.Connection.CreateCommand()
'        cmd2.CommandText = "SELECT COUNT([ID]) FROM [zd_post]" + strWhere

'        For Each Param As Data.SQLite.SQLiteParameter In Params
'            cmd.Parameters.Add(Param)
'            cmd2.Parameters.Add(Param)
'        Next

'        Dim DataReader2 As Data.SQLite.SQLiteDataReader = cmd2.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader2.HasRows = True Then
'            DataReader2.Read()
'            If PageBar_PageSize > 0 Then
'                PageBar.Make(PageBar_PageSize, Page, DataReader2.GetInt32(0), CInt(Container.SiteConfig("SITE_PAGEBAR_COUNT").Value), UrlRegex, PathRegexConfig)
'            End If
'        End If
'        DataReader2.Close()
'        cmd2.Dispose()


'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader.HasRows = False Then
'            Return False
'        End If
'        Do While DataReader.Read
'            Me.Items.Add(Load(DataReader.GetGuid(1)))
'        Loop

'        DataReader.Close()
'        cmd.Dispose()

'        Return True

'    End Function


'    Public Overrides Function Load(ByVal GUID As System.Guid) As Post

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_post] WHERE [GUID]=@guid"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
'        param.Value = GUID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer) As Post
'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_post] WHERE [ID]=@id"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
'        param.Value = ID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function


'    Public Overloads Function Load(ByVal DataReader As Data.SQLite.SQLiteDataReader) As Post

'        Dim Entry As New Post(Container)
'        Do While DataReader.Read

'            Entry.ID = DataReader.GetInt32(0)
'            Entry.GUID = DataReader.GetGuid(1)

'            Entry.IsDisable = DataReader.GetBoolean(2)
'            Entry.IsUnaudited = DataReader.GetBoolean(3)
'            Entry.IsDelete = DataReader.GetBoolean(4)

'            If DataReader.IsDBNull(5) = False Then Entry.Name = DataReader.GetString(5)
'            If DataReader.IsDBNull(6) = False Then Entry.AliasName = DataReader.GetString(6)
'            If DataReader.IsDBNull(7) = False Then Entry.Intro = DataReader.GetString(7)
'            If DataReader.IsDBNull(8) = False Then Entry.Content = DataReader.GetString(8)
'            If DataReader.IsDBNull(9) = False Then Entry.Note = DataReader.GetString(9)

'            Entry.CreateTime = DataReader.GetDateTime(10)
'            Entry.ModifiTime = DataReader.GetDateTime(11)

'            Entry.ParentGUID = DataReader.GetGuid(12)
'            Entry.SiteGUID = DataReader.GetGuid(13)
'            Entry.UserGUID = DataReader.GetGuid(14)

'            If DataReader.IsDBNull(15) = False Then
'                Entry.Meta = CType(Entry.Meta.DeSerialize(DataReader.GetString(15)), Common.Config(Of Common.Item))
'                'Entry.Meta.Add(New Common.Item("1", "2"))
'            End If

'            Entry.Type = CType(DataReader.GetInt32(16), Core.PostType)

'            Entry.CommentNums = DataReader.GetInt32(17)
'            Entry.ViewNums = DataReader.GetInt32(18)

'            Entry.IsTop = DataReader.GetBoolean(19)
'            Entry.IsDraft = DataReader.GetBoolean(20)
'            Entry.IsPrivate = DataReader.GetBoolean(21)
'            Entry.IsClose = DataReader.GetBoolean(22)

'            Entry.CategoryGUID = DataReader.GetGuid(23)

'        Loop

'        Return Entry

'    End Function


'    Public Overrides Function Load(ByVal ID As Integer, ByRef Entry As Post) As Boolean
'        Entry = Load(ID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'    Public Overrides Function Load(ByVal GUID As Guid, ByRef Entry As Post) As Boolean
'        Entry = Load(GUID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'    'Public Overrides Property NodeString() As String
'    '    Get
'    '        If String.IsNullOrEmpty(MyBase.NodeString) Then

'    '            Dim sb As New Text.StringBuilder
'    '            Dim wr As New Xml.XmlTextWriter(New IO.StringWriter(sb))

'    '            wr.WriteStartElement("articles")

'    '            For Each a As Post In Me.Items
'    '                wr.WriteRaw(a.NodeString)
'    '            Next

'    '            wr.WriteRaw(PageBar.NodeString)

'    '            wr.WriteEndElement()

'    '            wr.Close()

'    '            MyBase.NodeString = sb.ToString

'    '        End If
'    '        Return MyBase.NodeString
'    '    End Get
'    '    Set(ByVal value As String)
'    '        MyBase.NodeString = value
'    '    End Set
'    'End Property

'End Class

'Public Class SiteList : Inherits Core.BaseList(Of Site)

'    Private FContainer As Container
'    Protected Overloads Property Container() As Container
'        Get
'            Return FContainer
'        End Get
'        Set(ByVal value As Container)
'            FContainer = value
'        End Set
'    End Property

'    Public Sub New(ByVal nowContainer As Container)
'        Container = nowContainer
'    End Sub

'    Public Overrides Function Insert(ByVal Entry As Site) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "INSERT INTO [zd_site] ("
'        cmd.CommandText += "[GUID],[IsDisable],[IsUnaudited],[IsDelete],[Name],[AliasName],[Intro],[Content],[Note],[CreateTime],[ModifiTime],[ParentGUID],[SiteGUID],[UserGUID],[Meta],[UserNums],[CategoryNums],[PostNums],[CommentNums],[ViewNums]"
'        cmd.CommandText += ") VALUES ("
'        cmd.CommandText += "@GUID,@IsDisable,@IsUnaudited,@IsDelete,@Name,@AliasName,@Intro,@Content,@Note,@CreateTime,@ModifiTime,@ParentGUID,@SiteGUID,@UserGUID,@Meta,@UserNums,@CategoryNums,@PostNums,@CommentNums,@ViewNums"
'        cmd.CommandText += ")"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_UserNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserNums", System.Data.DbType.Int32)
'        param_UserNums.Value = Entry.UserNums
'        Dim param_CategoryNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CategoryNums", System.Data.DbType.Int32)
'        param_CategoryNums.Value = Entry.CategoryNums
'        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
'        param_PostNums.Value = Entry.PostNums
'        Dim param_CommentNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CommentNums", System.Data.DbType.Int32)
'        param_CommentNums.Value = Entry.CommentNums
'        Dim param_ViewNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ViewNums", System.Data.DbType.Int32)
'        param_ViewNums.Value = Entry.ViewNums

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_UserNums)
'        cmd.Parameters.Add(param_CategoryNums)
'        cmd.Parameters.Add(param_PostNums)
'        cmd.Parameters.Add(param_CommentNums)
'        cmd.Parameters.Add(param_ViewNums)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function Update(ByVal Entry As Site) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "UPDATE [zd_site] SET "
'        cmd.CommandText += "[GUID]=@GUID,[IsDisable]=@IsDisable,[IsUnaudited]=@IsUnaudited,[IsDelete]=@IsDelete,[Name]=@Name,[AliasName]=@AliasName,[Intro]=@Intro,[Content]=@Content,[Note]=@Note,[CreateTime]=@CreateTime,[ModifiTime]=@ModifiTime,[ParentGUID]=@ParentGUID,[SiteGUID]=@SiteGUID,[UserGUID]=@UserGUID,[Meta]=@Meta,[UserNums]=@UserNums,[CategoryNums]=@CategoryNums,[PostNums]=@PostNums,[CommentNums]=@CommentNums,[ViewNums]=@ViewNums"
'        cmd.CommandText += " WHERE [ID]=@ID"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_UserNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserNums", System.Data.DbType.Int32)
'        param_UserNums.Value = Entry.UserNums
'        Dim param_CategoryNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CategoryNums", System.Data.DbType.Int32)
'        param_CategoryNums.Value = Entry.CategoryNums
'        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
'        param_PostNums.Value = Entry.PostNums
'        Dim param_CommentNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CommentNums", System.Data.DbType.Int32)
'        param_CommentNums.Value = Entry.CommentNums
'        Dim param_ViewNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ViewNums", System.Data.DbType.Int32)
'        param_ViewNums.Value = Entry.ViewNums

'        Dim param_ID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ID", System.Data.DbType.Int32)
'        param_ID.Value = Entry.ID
'        cmd.Parameters.Add(param_ID)

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_UserNums)
'        cmd.Parameters.Add(param_CategoryNums)
'        cmd.Parameters.Add(param_PostNums)
'        cmd.Parameters.Add(param_CommentNums)
'        cmd.Parameters.Add(param_ViewNums)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function List(ByVal Params As Common.MetaConfig(Of Common.Meta)) As Boolean

'        If Params Is Nothing Then
'            Params = New Common.MetaConfig(Of Common.Meta)
'        End If

'        Dim SqlParams As New System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)

'        Dim strWhere As String = " WHERE (1=1) "
'        Dim strOrder As String = " ORDER BY "
'        Dim strPages As String = " LIMIT @PageSize OFFSET @Page"

'        Dim Page As New Integer
'        Dim PageSize As New Integer
'        Dim UrlRegex As String = String.Empty
'        Dim PageBar_PageSize As New Integer

'        Dim IsDisable As Boolean = False
'        Dim IsUnaudited As Boolean = False
'        Dim IsDelete As Boolean = False

'        Dim PathRegexConfig As Common.Config(Of Common.Item)

'        If Params.ContainsKey("Page") = True Then
'            If IsNumeric(Params("Page").Value) Then
'                Page = CInt(Params("Page").Value)
'            Else
'                Page = 1
'            End If
'        End If

'        If Params.ContainsKey("PageSize") = True Then
'            PageSize = CInt(Params("PageSize").Value)
'        End If

'        If Params.ContainsKey("UrlRegex") = True Then
'            UrlRegex = CStr(Params("UrlRegex").Value)
'        End If

'        If Params.ContainsKey("PageBar_PageSize") = True Then
'            PageBar_PageSize = CInt(Params("PageBar_PageSize").Value)
'        Else
'            PageBar_PageSize = PageSize
'        End If

'        If Params.ContainsKey("IsDisable") = True Then
'            strWhere += "AND ([IsDisable]=@IsDisable)"
'            IsDisable = CBool(Params("IsDisable").Value)
'        End If
'        If Params.ContainsKey("IsUnaudited") = True Then
'            strWhere += "AND ([IsUnaudited]=@IsUnaudited)"
'            IsUnaudited = CBool(Params("IsUnaudited").Value)
'        End If
'        If Params.ContainsKey("IsDelete") = True Then
'            strWhere += "AND ([IsDelete]=@IsDelete)"
'            IsUnaudited = CBool(Params("IsDelete").Value)
'        End If


'        If Page < 1 Then
'            Page = 1
'        End If

'        If PageSize = 0 Then
'            strPages = ""
'        End If

'        If String.Compare(strOrder, " ORDER BY ") = 0 Then
'            strOrder += "[ID] ASC"
'        End If

'        Dim param_PageSize As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PageSize", System.Data.DbType.Int32)
'        param_PageSize.Value = PageSize
'        SqlParams.Add(param_PageSize)

'        Dim param_Page As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Page", System.Data.DbType.Int32)
'        param_Page.Value = (Page - 1) * PageSize
'        SqlParams.Add(param_Page)

'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = IsDisable
'        SqlParams.Add(param_IsDisable)

'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = IsUnaudited
'        SqlParams.Add(param_IsUnaudited)

'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = IsDelete
'        SqlParams.Add(param_IsDelete)


'        If Params.ContainsKey("PathRegexConfig") = True Then
'            PathRegexConfig = CType(Params("PathRegexConfig").Value, Common.Config(Of Common.Item))
'        Else
'            PathRegexConfig = DirectCast(Me.Container.Action2RegexSplitConfig.Clone, Common.Config(Of Common.Item))
'        End If
'        PathRegexConfig("{%HostDirectory%}").Value = Me.Container.GlobalConfig("APPLICATION_HOST").Value

'        Return Me.List(Page, PageSize, UrlRegex, PathRegexConfig, PageBar_PageSize, strWhere, strOrder, strPages, SqlParams)

'    End Function

'    Public Overloads Function List(ByVal Page As Integer, ByVal PageSize As Integer, ByVal UrlRegex As String, ByVal PathRegexConfig As Common.Config(Of Common.Item), ByVal PageBar_PageSize As Integer, ByVal SqlWhere As String, ByVal SqlOrder As String, ByVal SqlPages As String, ByVal Params As System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)) As Boolean

'        Dim strWhere As String = SqlWhere
'        Dim strOrder As String = SqlOrder
'        Dim strPages As String = SqlPages


'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_site]" + strWhere + strOrder + strPages

'        Dim cmd2 As Data.SQLite.SQLiteCommand
'        cmd2 = Me.Container.Connection.CreateCommand()
'        cmd2.CommandText = "SELECT COUNT([ID]) FROM [zd_site]" + strWhere

'        For Each Param As Data.SQLite.SQLiteParameter In Params
'            cmd.Parameters.Add(Param)
'            cmd2.Parameters.Add(Param)
'        Next

'        Dim DataReader2 As Data.SQLite.SQLiteDataReader = cmd2.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader2.HasRows = True Then
'            DataReader2.Read()
'            If PageBar_PageSize > 0 Then
'                PageBar.Make(PageBar_PageSize, Page, DataReader2.GetInt32(0), CInt(Container.SiteConfig("SITE_PAGEBAR_COUNT").Value), UrlRegex, PathRegexConfig)
'            End If
'        End If
'        DataReader2.Close()
'        cmd2.Dispose()


'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader.HasRows = False Then
'            Return False
'        End If
'        Do While DataReader.Read
'            Me.Items.Add(Load(DataReader.GetGuid(1)))
'        Loop

'        DataReader.Close()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function Load(ByVal GUID As System.Guid) As Site

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_site] WHERE [GUID]=@guid"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
'        param.Value = GUID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer) As Site

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_site] WHERE [ID]=@id"

'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
'        param.Value = ID
'        cmd.Parameters.Add(param)

'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function


'    Public Overloads Function Load(ByVal DataReader As Data.SQLite.SQLiteDataReader) As Site

'        Dim Entry As New Site(Container)
'        Do While DataReader.Read

'            Entry.ID = DataReader.GetInt32(0)
'            Entry.GUID = DataReader.GetGuid(1)

'            Entry.IsDisable = DataReader.GetBoolean(2)
'            Entry.IsUnaudited = DataReader.GetBoolean(3)
'            Entry.IsDelete = DataReader.GetBoolean(4)

'            If DataReader.IsDBNull(5) = False Then Entry.Name = DataReader.GetString(5)
'            If DataReader.IsDBNull(6) = False Then Entry.AliasName = DataReader.GetString(6)
'            If DataReader.IsDBNull(7) = False Then Entry.Intro = DataReader.GetString(7)
'            If DataReader.IsDBNull(8) = False Then Entry.Content = DataReader.GetString(8)
'            If DataReader.IsDBNull(9) = False Then Entry.Note = DataReader.GetString(9)

'            Entry.CreateTime = DataReader.GetDateTime(10)
'            Entry.ModifiTime = DataReader.GetDateTime(11)

'            Entry.ParentGUID = DataReader.GetGuid(12)
'            Entry.SiteGUID = DataReader.GetGuid(13)
'            Entry.UserGUID = DataReader.GetGuid(14)

'            If DataReader.IsDBNull(15) Then
'                'Dim a As New ASCIIEncoding
'                'Dim s As String = a.GetString(CType(DataReader.GetValue(15), Byte()))
'                'Entry.Meta.DeSerialize(s)
'            End If

'            Entry.UserNums = DataReader.GetInt32(16)
'            Entry.CategoryNums = DataReader.GetInt32(17)
'            Entry.PostNums = DataReader.GetInt32(18)
'            Entry.CommentNums = DataReader.GetInt32(19)
'            Entry.ViewNums = DataReader.GetInt32(20)

'        Loop

'        Return Entry

'    End Function

'    Public Overloads Function Load(ByVal MainUser As User) As Site

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_site] WHERE [UserGUID]=@UserGUID"

'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param.Value = MainUser.GUID
'        cmd.Parameters.Add(param)

'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer, ByRef Entry As Site) As Boolean
'        Entry = Load(ID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'    Public Overrides Function Load(ByVal GUID As Guid, ByRef Entry As Site) As Boolean
'        Entry = Load(GUID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'End Class


'Public Class UserList : Inherits Core.BaseList(Of User)

'    Private FContainer As Container
'    Protected Overloads Property Container() As Container
'        Get
'            Return FContainer
'        End Get
'        Set(ByVal value As Container)
'            FContainer = value
'        End Set
'    End Property

'    Public Sub New(ByVal nowContainer As Container)
'        Container = nowContainer
'    End Sub

'    Public Overrides Function Insert(ByVal Entry As User) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "INSERT INTO [zd_user] ("
'        cmd.CommandText += "[GUID],[IsDisable],[IsUnaudited],[IsDelete],[Name],[AliasName],[Intro],[Content],[Note],[CreateTime],[ModifiTime],[ParentGUID],[SiteGUID],[UserGUID],[Meta],[Level],[Password],[Email],[HomePage],[PostNums],[CommentNums]"
'        cmd.CommandText += ") VALUES ("
'        cmd.CommandText += "@GUID,@IsDisable,@IsUnaudited,@IsDelete,@Name,@AliasName,@Intro,@Content,@Note,@CreateTime,@ModifiTime,@ParentGUID,@SiteGUID,@UserGUID,@Meta,@Level,@Password,@Email,@HomePage,@PostNums,@CommentNums"
'        cmd.CommandText += ")"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Level As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Level", System.Data.DbType.Int32)
'        param_Level.Value = Entry.Level
'        Dim param_Password As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Password", System.Data.DbType.String)
'        param_Password.Value = Entry.Password
'        Dim param_Email As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Email", System.Data.DbType.String)
'        param_Email.Value = Entry.Email
'        Dim param_HomePage As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@HomePage", System.Data.DbType.String)
'        param_HomePage.Value = Entry.HomePage
'        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
'        param_PostNums.Value = Entry.PostNums
'        Dim param_CommentNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CommentNums", System.Data.DbType.Int32)
'        param_CommentNums.Value = Entry.CommentNums

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Level)
'        cmd.Parameters.Add(param_Password)
'        cmd.Parameters.Add(param_Email)
'        cmd.Parameters.Add(param_HomePage)
'        cmd.Parameters.Add(param_PostNums)
'        cmd.Parameters.Add(param_CommentNums)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function Update(ByVal Entry As User) As Boolean

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()

'        cmd.CommandText = "UPDATE [zd_user] SET "
'        cmd.CommandText += "[GUID]=@GUID,[IsDisable]=@IsDisable,[IsUnaudited]=@IsUnaudited,[IsDelete]=@IsDelete,[Name]=@Name,[AliasName]=@AliasName,[Intro]=@Intro,[Content]=@Content,[Note]=@Note,[CreateTime]=@CreateTime,[ModifiTime]=@ModifiTime,[ParentGUID]=@ParentGUID,[SiteGUID]=@SiteGUID,[UserGUID]=@UserGUID,[Meta]=@Meta,[Level]=@Level,[Password]=@Password,[Email]=@Email,[HomePage]=@HomePage,[PostNums]=@PostNums,[CommentNums]=@CommentNums"
'        cmd.CommandText += " WHERE [ID]=@ID"

'        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
'        param_GUID.Value = Entry.GUID
'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = Entry.IsDisable
'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = Entry.IsUnaudited
'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = Entry.IsDelete
'        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param_Name.Value = Entry.Name
'        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
'        param_AliasName.Value = Entry.AliasName
'        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
'        param_Intro.Value = Entry.Intro
'        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
'        param_Content.Value = Entry.Content
'        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
'        param_Note.Value = Entry.Note
'        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
'        param_CreateTime.Value = Entry.CreateTime
'        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
'        param_ModifiTime.Value = Entry.ModifiTime
'        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
'        param_ParentGUID.Value = Entry.ParentGUID
'        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
'        param_SiteGUID.Value = Entry.SiteGUID
'        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
'        param_UserGUID.Value = Entry.UserGUID
'        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
'        param_Meta.Value = Entry.Meta.Serialize

'        Dim param_Level As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Level", System.Data.DbType.Int32)
'        param_Level.Value = Entry.Level
'        Dim param_Password As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Password", System.Data.DbType.String)
'        param_Password.Value = Entry.Password
'        Dim param_Email As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Email", System.Data.DbType.String)
'        param_Email.Value = Entry.Email
'        Dim param_HomePage As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@HomePage", System.Data.DbType.String)
'        param_HomePage.Value = Entry.HomePage
'        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
'        param_PostNums.Value = Entry.PostNums
'        Dim param_CommentNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CommentNums", System.Data.DbType.Int32)
'        param_CommentNums.Value = Entry.CommentNums

'        Dim param_ID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ID", System.Data.DbType.Int32)
'        param_ID.Value = Entry.ID
'        cmd.Parameters.Add(param_ID)

'        cmd.Parameters.Add(param_GUID)
'        cmd.Parameters.Add(param_IsDisable)
'        cmd.Parameters.Add(param_IsUnaudited)
'        cmd.Parameters.Add(param_IsDelete)
'        cmd.Parameters.Add(param_Name)
'        cmd.Parameters.Add(param_AliasName)
'        cmd.Parameters.Add(param_Intro)
'        cmd.Parameters.Add(param_Content)
'        cmd.Parameters.Add(param_Note)
'        cmd.Parameters.Add(param_CreateTime)
'        cmd.Parameters.Add(param_ModifiTime)
'        cmd.Parameters.Add(param_ParentGUID)
'        cmd.Parameters.Add(param_SiteGUID)
'        cmd.Parameters.Add(param_UserGUID)
'        cmd.Parameters.Add(param_Meta)

'        cmd.Parameters.Add(param_Level)
'        cmd.Parameters.Add(param_Password)
'        cmd.Parameters.Add(param_Email)
'        cmd.Parameters.Add(param_HomePage)
'        cmd.Parameters.Add(param_PostNums)
'        cmd.Parameters.Add(param_CommentNums)

'        cmd.ExecuteNonQuery()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function List(ByVal Params As Common.MetaConfig(Of Common.Meta)) As Boolean

'        If Params Is Nothing Then
'            Params = New Common.MetaConfig(Of Common.Meta)
'        End If

'        Dim SqlParams As New System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)

'        Dim strWhere As String = " WHERE (1=1) "
'        Dim strOrder As String = " ORDER BY "
'        Dim strPages As String = " LIMIT @PageSize OFFSET @Page"

'        Dim Page As New Integer
'        Dim PageSize As New Integer
'        Dim UrlRegex As String = String.Empty
'        Dim PageBar_PageSize As New Integer

'        Dim IsDisable As Boolean = False
'        Dim IsUnaudited As Boolean = False
'        Dim IsDelete As Boolean = False

'        Dim PathRegexConfig As Common.Config(Of Common.Item)

'        If Params.ContainsKey("Page") = True Then
'            If IsNumeric(Params("Page").Value) Then
'                Page = CInt(Params("Page").Value)
'            Else
'                Page = 1
'            End If
'        End If

'        If Params.ContainsKey("PageSize") = True Then
'            PageSize = CInt(Params("PageSize").Value)
'        End If

'        If Params.ContainsKey("UrlRegex") = True Then
'            UrlRegex = CStr(Params("UrlRegex").Value)
'        End If

'        If Params.ContainsKey("PageBar_PageSize") = True Then
'            PageBar_PageSize = CInt(Params("PageBar_PageSize").Value)
'        Else
'            PageBar_PageSize = PageSize
'        End If

'        If Params.ContainsKey("IsDisable") = True Then
'            strWhere += "AND ([IsDisable]=@IsDisable)"
'            IsDisable = CBool(Params("IsDisable").Value)
'        End If
'        If Params.ContainsKey("IsUnaudited") = True Then
'            strWhere += "AND ([IsUnaudited]=@IsUnaudited)"
'            IsUnaudited = CBool(Params("IsUnaudited").Value)
'        End If
'        If Params.ContainsKey("IsDelete") = True Then
'            strWhere += "AND ([IsDelete]=@IsDelete)"
'            IsUnaudited = CBool(Params("IsDelete").Value)
'        End If


'        If Page < 1 Then
'            Page = 1
'        End If

'        If PageSize = 0 Then
'            strPages = ""
'        End If

'        If String.Compare(strOrder, " ORDER BY ") = 0 Then
'            strOrder += "[ID] ASC"
'        End If

'        Dim param_PageSize As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PageSize", System.Data.DbType.Int32)
'        param_PageSize.Value = PageSize
'        SqlParams.Add(param_PageSize)

'        Dim param_Page As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Page", System.Data.DbType.Int32)
'        param_Page.Value = (Page - 1) * PageSize
'        SqlParams.Add(param_Page)

'        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
'        param_IsDisable.Value = IsDisable
'        SqlParams.Add(param_IsDisable)

'        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
'        param_IsUnaudited.Value = IsUnaudited
'        SqlParams.Add(param_IsUnaudited)

'        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
'        param_IsDelete.Value = IsDelete
'        SqlParams.Add(param_IsDelete)


'        If Params.ContainsKey("PathRegexConfig") = True Then
'            PathRegexConfig = CType(Params("PathRegexConfig").Value, Common.Config(Of Common.Item))
'        Else
'            PathRegexConfig = DirectCast(Me.Container.Action2RegexSplitConfig.Clone, Common.Config(Of Common.Item))
'        End If
'        PathRegexConfig("{%HostDirectory%}").Value = Me.Container.GlobalConfig("APPLICATION_HOST").Value

'        Return Me.List(Page, PageSize, UrlRegex, PathRegexConfig, PageBar_PageSize, strWhere, strOrder, strPages, SqlParams)

'    End Function

'    Public Overloads Function List(ByVal Page As Integer, ByVal PageSize As Integer, ByVal UrlRegex As String, ByVal PathRegexConfig As Common.Config(Of Common.Item), ByVal PageBar_PageSize As Integer, ByVal SqlWhere As String, ByVal SqlOrder As String, ByVal SqlPages As String, ByVal Params As System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)) As Boolean

'        Dim strWhere As String = SqlWhere
'        Dim strOrder As String = SqlOrder
'        Dim strPages As String = SqlPages


'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_user]" + strWhere + strOrder + strPages

'        Dim cmd2 As Data.SQLite.SQLiteCommand
'        cmd2 = Me.Container.Connection.CreateCommand()
'        cmd2.CommandText = "SELECT COUNT([ID]) FROM [zd_user]" + strWhere

'        For Each Param As Data.SQLite.SQLiteParameter In Params
'            cmd.Parameters.Add(Param)
'            cmd2.Parameters.Add(Param)
'        Next

'        Dim DataReader2 As Data.SQLite.SQLiteDataReader = cmd2.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader2.HasRows = True Then
'            DataReader2.Read()
'            If PageBar_PageSize > 0 Then
'                PageBar.Make(PageBar_PageSize, Page, DataReader2.GetInt32(0), CInt(Container.SiteConfig("SITE_PAGEBAR_COUNT").Value), UrlRegex, PathRegexConfig)
'            End If
'        End If
'        DataReader2.Close()
'        cmd2.Dispose()


'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
'        If DataReader.HasRows = False Then
'            Return False
'        End If
'        Do While DataReader.Read
'            Me.Items.Add(Load(DataReader.GetGuid(1)))
'        Loop

'        DataReader.Close()
'        cmd.Dispose()

'        Return True

'    End Function

'    Public Overrides Function Load(ByVal GUID As System.Guid) As User

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_user] WHERE [GUID]=@guid"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
'        param.Value = GUID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer) As User
'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_user] WHERE [ID]=@id"
'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
'        param.Value = ID
'        cmd.Parameters.Add(param)
'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function


'    Public Overloads  Function Load(ByVal DataReader As Data.SQLite.SQLiteDataReader) As User

'        Dim Entry As New User(Container)
'        Do While DataReader.Read

'            Entry.ID = DataReader.GetInt32(0)
'            Entry.GUID = DataReader.GetGuid(1)

'            Entry.IsDisable = DataReader.GetBoolean(2)
'            Entry.IsUnaudited = DataReader.GetBoolean(3)
'            Entry.IsDelete = DataReader.GetBoolean(4)

'            If DataReader.IsDBNull(5) = False Then Entry.Name = DataReader.GetString(5)
'            If DataReader.IsDBNull(6) = False Then Entry.AliasName = DataReader.GetString(6)
'            If DataReader.IsDBNull(7) = False Then Entry.Intro = DataReader.GetString(7)
'            If DataReader.IsDBNull(8) = False Then Entry.Content = DataReader.GetString(8)
'            If DataReader.IsDBNull(9) = False Then Entry.Note = DataReader.GetString(9)

'            Entry.CreateTime = DataReader.GetDateTime(10)
'            Entry.ModifiTime = DataReader.GetDateTime(11)

'            Entry.ParentGUID = DataReader.GetGuid(12)
'            Entry.SiteGUID = DataReader.GetGuid(13)
'            Entry.UserGUID = DataReader.GetGuid(14)

'            If DataReader.IsDBNull(15) Then
'                'Dim a As New ASCIIEncoding
'                'Dim s As String = a.GetString(CType(DataReader.GetValue(15), Byte()))
'                'Entry.Meta.DeSerialize(s)
'            End If

'            Entry.Level = DataReader.GetInt32(16)
'            If DataReader.IsDBNull(17) = False Then Entry.Password = DataReader.GetString(17)
'            If DataReader.IsDBNull(18) = False Then Entry.Email = DataReader.GetString(18)
'            If DataReader.IsDBNull(19) = False Then Entry.HomePage = DataReader.GetString(19)
'            Entry.PostNums = DataReader.GetInt32(20)
'            Entry.CommentNums = DataReader.GetInt32(21)

'        Loop

'        Return Entry

'    End Function

'    Public Overloads Function Load(ByVal UserName As String) As User

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_user] WHERE [Name]=@Name"

'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param.Value = UserName
'        cmd.Parameters.Add(param)

'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overloads Function Load(ByVal UserName As String, ByVal PassWord As String) As User

'        Dim cmd As Data.SQLite.SQLiteCommand
'        cmd = Me.Container.Connection.CreateCommand()
'        cmd.CommandText = "SELECT * FROM [zd_user] WHERE lower([Name])=lower(@Name) AND lower([Password])=lower(@Password)"

'        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
'        param.Value = UserName
'        cmd.Parameters.Add(param)

'        Dim param2 As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Password", System.Data.DbType.String)
'        param2.Value = PassWord
'        cmd.Parameters.Add(param2)

'        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

'        If DataReader.HasRows = True Then
'            Return Load(DataReader)
'        Else
'            Return Nothing
'        End If

'    End Function

'    Public Overrides Function Load(ByVal ID As Integer, ByRef Entry As User) As Boolean
'        Entry = Load(ID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'    Public Overrides Function Load(ByVal GUID As Guid, ByRef Entry As User) As Boolean
'        Entry = Load(GUID)
'        If Entry Is Nothing Then
'            Return False
'        Else
'            Return True
'        End If
'    End Function

'End Class
