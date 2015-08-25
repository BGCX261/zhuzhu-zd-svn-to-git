Public MustInherit Class ICategoryList(Of T As ICategory)

    Inherits Core.ICategoryList(Of T)

    Private FContainer As Container
    Protected Overloads Property Container() As Container
        Get
            Return FContainer
        End Get
        Set(ByVal value As Container)
            FContainer = value
        End Set
    End Property

    Public Sub New(ByVal nowContainer As Container)
        Container = nowContainer
    End Sub


    Public Overrides Function Insert(ByVal Entry As T) As Boolean

        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Container.Connection.CreateCommand()

        cmd.CommandText = "INSERT INTO [zd_category] ("
        cmd.CommandText += "[GUID],[IsDisable],[IsUnaudited],[IsDelete],[Name],[AliasName],[Intro],[Content],[Note],[CreateTime],[ModifiTime],[ParentGUID],[SiteGUID],[UserGUID],[Meta],[Order],[PostNums],[Type]"
        cmd.CommandText += ") VALUES ("
        cmd.CommandText += "@GUID,@IsDisable,@IsUnaudited,@IsDelete,@Name,@AliasName,@Intro,@Content,@Note,@CreateTime,@ModifiTime,@ParentGUID,@SiteGUID,@UserGUID,@Meta,@Order,@PostNums,@Type"
        cmd.CommandText += ")"

        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
        param_GUID.Value = Entry.GUID
        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
        param_IsDisable.Value = Entry.IsDisable
        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
        param_IsUnaudited.Value = Entry.IsUnaudited
        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
        param_IsDelete.Value = Entry.IsDelete
        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
        param_Name.Value = Entry.Name
        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
        param_AliasName.Value = Entry.AliasName
        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
        param_Intro.Value = Entry.Intro
        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
        param_Content.Value = Entry.Content
        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
        param_Note.Value = Entry.Note
        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
        param_CreateTime.Value = Entry.CreateTime
        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
        param_ModifiTime.Value = Entry.ModifiTime
        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
        param_ParentGUID.Value = Entry.ParentGUID
        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
        param_SiteGUID.Value = Entry.SiteGUID
        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
        param_UserGUID.Value = Entry.UserGUID
        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
        param_Meta.Value = Entry.Meta.Serialize

        Dim param_Order As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Order", System.Data.DbType.Int32)
        param_Order.Value = Entry.Order
        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
        param_PostNums.Value = Entry.PostNums
        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
        param_Type.Value = Entry.Type

        cmd.Parameters.Add(param_GUID)
        cmd.Parameters.Add(param_IsDisable)
        cmd.Parameters.Add(param_IsUnaudited)
        cmd.Parameters.Add(param_IsDelete)
        cmd.Parameters.Add(param_Name)
        cmd.Parameters.Add(param_AliasName)
        cmd.Parameters.Add(param_Intro)
        cmd.Parameters.Add(param_Content)
        cmd.Parameters.Add(param_Note)
        cmd.Parameters.Add(param_CreateTime)
        cmd.Parameters.Add(param_ModifiTime)
        cmd.Parameters.Add(param_ParentGUID)
        cmd.Parameters.Add(param_SiteGUID)
        cmd.Parameters.Add(param_UserGUID)
        cmd.Parameters.Add(param_Meta)

        cmd.Parameters.Add(param_Order)
        cmd.Parameters.Add(param_PostNums)
        cmd.Parameters.Add(param_Type)

        cmd.ExecuteNonQuery()
        cmd.Dispose()

        Return True

    End Function


    Public Overrides Function Update(ByVal Entry As T) As Boolean

        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Container.Connection.CreateCommand()

        cmd.CommandText = "UPDATE [zd_category] SET "
        cmd.CommandText += "[GUID]=@GUID,[IsDisable]=@IsDisable,[IsUnaudited]=@IsUnaudited,[IsDelete]=@IsDelete,[Name]=@Name,[AliasName]=@AliasName,[Intro]=@Intro,[Content]=@Content,[Note]=@Note,[CreateTime]=@CreateTime,[ModifiTime]=@ModifiTime,[ParentGUID]=@ParentGUID,[SiteGUID]=@SiteGUID,[UserGUID]=@UserGUID,[Meta]=@Meta,[Order]=@Order,[PostNums]=@PostNums,[Type]=@Type"
        cmd.CommandText += " WHERE [ID]=@ID"

        Dim param_GUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@GUID", System.Data.DbType.Guid)
        param_GUID.Value = Entry.GUID
        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
        param_IsDisable.Value = Entry.IsDisable
        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
        param_IsUnaudited.Value = Entry.IsUnaudited
        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
        param_IsDelete.Value = Entry.IsDelete
        Dim param_Name As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Name", System.Data.DbType.String)
        param_Name.Value = Entry.Name
        Dim param_AliasName As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@AliasName", System.Data.DbType.String)
        param_AliasName.Value = Entry.AliasName
        Dim param_Intro As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Intro", System.Data.DbType.String)
        param_Intro.Value = Entry.Intro
        Dim param_Content As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Content", System.Data.DbType.String)
        param_Content.Value = Entry.Content
        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
        param_Note.Value = Entry.Note
        Dim param_CreateTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@CreateTime", System.Data.DbType.Time)
        param_CreateTime.Value = Entry.CreateTime
        Dim param_ModifiTime As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ModifiTime", System.Data.DbType.Time)
        param_ModifiTime.Value = Entry.ModifiTime
        Dim param_ParentGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ParentGUID", System.Data.DbType.Guid)
        param_ParentGUID.Value = Entry.ParentGUID
        Dim param_SiteGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@SiteGUID", System.Data.DbType.Guid)
        param_SiteGUID.Value = Entry.SiteGUID
        Dim param_UserGUID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@UserGUID", System.Data.DbType.Guid)
        param_UserGUID.Value = Entry.UserGUID
        Dim param_Meta As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Meta", System.Data.DbType.String)
        param_Meta.Value = Entry.Meta.Serialize

        Dim param_Order As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Order", System.Data.DbType.Int32)
        param_Order.Value = Entry.Order
        Dim param_PostNums As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PostNums", System.Data.DbType.Int32)
        param_PostNums.Value = Entry.PostNums
        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
        param_Type.Value = Entry.Type

        Dim param_ID As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@ID", System.Data.DbType.Int32)
        param_ID.Value = Entry.ID
        cmd.Parameters.Add(param_ID)

        cmd.Parameters.Add(param_GUID)
        cmd.Parameters.Add(param_IsDisable)
        cmd.Parameters.Add(param_IsUnaudited)
        cmd.Parameters.Add(param_IsDelete)
        cmd.Parameters.Add(param_Name)
        cmd.Parameters.Add(param_AliasName)
        cmd.Parameters.Add(param_Intro)
        cmd.Parameters.Add(param_Content)
        cmd.Parameters.Add(param_Note)
        cmd.Parameters.Add(param_CreateTime)
        cmd.Parameters.Add(param_ModifiTime)
        cmd.Parameters.Add(param_ParentGUID)
        cmd.Parameters.Add(param_SiteGUID)
        cmd.Parameters.Add(param_UserGUID)
        cmd.Parameters.Add(param_Meta)

        cmd.Parameters.Add(param_Order)
        cmd.Parameters.Add(param_PostNums)
        cmd.Parameters.Add(param_Type)

        cmd.ExecuteNonQuery()
        cmd.Dispose()

        Return True

    End Function

    Public Overrides Function List(ByVal Params As System.Collections.Generic.Dictionary(Of String, Object)) As Boolean

        If Params Is Nothing Then
            Params = New System.Collections.Generic.Dictionary(Of String, Object)
        End If

        Dim SqlParams As New System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)

        Dim strWhere As String = " WHERE (1=1) "
        Dim strOrder As String = " ORDER BY "
        Dim strPages As String = " LIMIT @PageSize OFFSET @Page"

        Dim Page As New Integer
        Dim PageSize As New Integer
        Dim UrlRegex As String = String.Empty
        Dim PageBar_PageSize As New Integer

        Dim IsDisable As Boolean = False
        Dim IsUnaudited As Boolean = False
        Dim IsDelete As Boolean = False

        Dim Type As Core.CategoryType = CategoryType.Unknown

        Dim Note As String = ""

        Dim PathRegexConfig As Common.ItemConfig(Of Common.Item)

        If Params.ContainsKey("Page") = True Then
            If IsNumeric(Params("Page")) Then
                Page = CInt(Params("Page"))
            Else
                Page = 1
            End If
        End If

        If Params.ContainsKey("PageSize") = True Then
            PageSize = CInt(Params("PageSize"))
        End If

        If Params.ContainsKey("UrlRegex") = True Then
            UrlRegex = CStr(Params("UrlRegex"))
        End If

        If Params.ContainsKey("PageBar_PageSize") = True Then
            PageBar_PageSize = CInt(Params("PageBar_PageSize"))
        Else
            PageBar_PageSize = PageSize
        End If

        If Params.ContainsKey("IsDisable") = True Then
            strWhere += "AND ([IsDisable]=@IsDisable)"
            IsDisable = CBool(Params("IsDisable"))
        End If
        If Params.ContainsKey("IsUnaudited") = True Then
            strWhere += "AND ([IsUnaudited]=@IsUnaudited)"
            IsUnaudited = CBool(Params("IsUnaudited"))
        End If
        If Params.ContainsKey("IsDelete") = True Then
            strWhere += "AND ([IsDelete]=@IsDelete)"
            IsUnaudited = CBool(Params("IsDelete"))
        End If

        If Params.ContainsKey("Type") = True Then
            Type = CType(Params("Type"), Core.CategoryType)
            strWhere += "AND ([Type]=@Type)"
        End If

        If Params.ContainsKey("Note") = True Then
            Note = CStr(Params("Note"))
            strWhere += "AND ([Note]=@Note)"
        End If


        If Page < 1 Then
            Page = 1
        End If

        If PageSize = 0 Then
            strPages = ""
        End If

        If String.Compare(strOrder, " ORDER BY ") = 0 Then
            strOrder += "[ID] ASC"
        End If

        Dim param_PageSize As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@PageSize", System.Data.DbType.Int32)
        param_PageSize.Value = PageSize
        SqlParams.Add(param_PageSize)

        Dim param_Page As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Page", System.Data.DbType.Int32)
        param_Page.Value = (Page - 1) * PageSize
        SqlParams.Add(param_Page)

        Dim param_IsDisable As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDisable", System.Data.DbType.Boolean)
        param_IsDisable.Value = IsDisable
        SqlParams.Add(param_IsDisable)

        Dim param_IsUnaudited As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsUnaudited", System.Data.DbType.Boolean)
        param_IsUnaudited.Value = IsUnaudited
        SqlParams.Add(param_IsUnaudited)

        Dim param_IsDelete As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@IsDelete", System.Data.DbType.Boolean)
        param_IsDelete.Value = IsDelete
        SqlParams.Add(param_IsDelete)

        Dim param_Type As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Type", System.Data.DbType.Int32)
        param_Type.Value = Type
        SqlParams.Add(param_Type)

        Dim param_Note As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@Note", System.Data.DbType.String)
        param_Note.Value = Note
        SqlParams.Add(param_Note)

        If Params.ContainsKey("PathRegexConfig") = True Then
            PathRegexConfig = CType(Params("PathRegexConfig"), Common.ItemConfig(Of Common.Item))
        Else
            PathRegexConfig = Me.Container.ActionSplitConfig.Clone
        End If
        'PathRegexConfig("{%HostDirectory%}").Value = Me.Container.Config("SITE_HOST").Value

        Return List(Page, PageSize, UrlRegex, PathRegexConfig, PageBar_PageSize, strWhere, strOrder, strPages, SqlParams)

    End Function

    Public Overloads Function List(ByVal Page As Integer, ByVal PageSize As Integer, ByVal UrlRegex As String, ByVal PathRegexConfig As Common.ItemConfig(Of Common.Item), ByVal PageBar_PageSize As Integer, ByVal SqlWhere As String, ByVal SqlOrder As String, ByVal SqlPages As String, ByVal Params As System.Collections.Generic.List(Of System.Data.SQLite.SQLiteParameter)) As Boolean

        Dim strWhere As String = SqlWhere
        Dim strOrder As String = SqlOrder
        Dim strPages As String = SqlPages


        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Container.Connection.CreateCommand()
        cmd.CommandText = "SELECT * FROM [zd_category]" + strWhere + strOrder + strPages

        Dim cmd2 As Data.SQLite.SQLiteCommand
        cmd2 = Container.Connection.CreateCommand()
        cmd2.CommandText = "SELECT COUNT([ID]) FROM [zd_category]" + strWhere

        For Each Param As Data.SQLite.SQLiteParameter In Params
            cmd.Parameters.Add(Param)
            cmd2.Parameters.Add(Param)
        Next

        Dim DataReader2 As Data.SQLite.SQLiteDataReader = cmd2.ExecuteReader(CommandBehavior.Default)
        If DataReader2.HasRows = True Then
            DataReader2.Read()
            If PageBar_PageSize > 0 Then
                PageBar.Make(PageBar_PageSize, Page, DataReader2.GetInt32(0), CInt(Me.Container.Config("SITE_PAGEBAR_COUNT").Value), UrlRegex, PathRegexConfig)
            End If
        End If
        DataReader2.Close()
        cmd2.Dispose()


        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
        If DataReader.HasRows = False Then
            Return False
        End If
        Do While DataReader.Read
            MyClass.Items.Add(Load(DataReader.GetGuid(1)))
        Loop

        DataReader.Close()
        cmd.Dispose()

        Return True

    End Function

    Public Overrides Function Load(ByVal GUID As System.Guid) As T

        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Container.Connection.CreateCommand()
        cmd.CommandText = "SELECT * FROM [zd_category] WHERE [GUID]=@guid"
        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
        param.Value = GUID
        cmd.Parameters.Add(param)
        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

        If DataReader.HasRows = True Then
            Return Load(DataReader)
        Else
            Return Nothing
        End If

    End Function

    Public Overrides Function Load(ByVal ID As Integer) As T

        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Container.Connection.CreateCommand()
        cmd.CommandText = "SELECT * FROM [zd_category] WHERE [ID]=@id"

        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
        param.Value = ID
        cmd.Parameters.Add(param)

        Dim DataReader As Data.SQLite.SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)

        If DataReader.HasRows = True Then
            Return Load(DataReader)
        Else
            Return Nothing
        End If

    End Function


    Public Overloads Function Load(ByVal DataReader As Data.SQLite.SQLiteDataReader) As T


        Dim Entry As T = CType(System.Activator.CreateInstance(GetType(T), Container), T)

        Do While DataReader.Read

            Entry.ID = DataReader.GetInt32(0)
            Entry.GUID = DataReader.GetGuid(1)

            Entry.IsDisable = DataReader.GetBoolean(2)
            Entry.IsUnaudited = DataReader.GetBoolean(3)
            Entry.IsDelete = DataReader.GetBoolean(4)

            If DataReader.IsDBNull(5) = False Then Entry.Name = DataReader.GetString(5)
            If DataReader.IsDBNull(6) = False Then Entry.AliasName = DataReader.GetString(6)
            If DataReader.IsDBNull(7) = False Then Entry.Intro = DataReader.GetString(7)
            If DataReader.IsDBNull(8) = False Then Entry.Content = DataReader.GetString(8)
            If DataReader.IsDBNull(9) = False Then Entry.Note = DataReader.GetString(9)

            Entry.CreateTime = DataReader.GetDateTime(10)
            Entry.ModifiTime = DataReader.GetDateTime(11)

            Entry.ParentGUID = DataReader.GetGuid(12)
            Entry.SiteGUID = DataReader.GetGuid(13)
            Entry.UserGUID = DataReader.GetGuid(14)

            If DataReader.IsDBNull(15) Then
                Dim s As String = DataReader.GetString(15)
                Entry.Meta = (New Common.ItemConfig(Of Common.Item)).LoadString(s)
            End If

            Entry.Order = DataReader.GetInt32(16)
            Entry.PostNums = DataReader.GetInt32(17)
            Entry.Type = CType(DataReader.GetInt32(18), Zdevo.Core.CategoryType)

        Loop

        Return Entry

    End Function

    Public Overrides Function Load(ByVal ID As Integer, ByRef Entry As T) As Boolean
        Entry = Load(ID)
        If Entry Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Overrides Function Load(ByVal GUID As Guid, ByRef Entry As T) As Boolean
        Entry = Load(GUID)
        If Entry Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Overrides Function Del(ByVal ID As Integer) As Boolean

        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Me.Container.Connection.CreateCommand()
        cmd.CommandText = "DELETE FROM [zd_category] WHERE [ID]=@id"
        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@id", System.Data.DbType.Int32)
        param.Value = ID
        cmd.Parameters.Add(param)

        If cmd.ExecuteNonQuery() > 0 Then
            Return True
        End If


    End Function

    Public Overrides Function Del(ByVal GUID As Guid) As Boolean

        Dim cmd As Data.SQLite.SQLiteCommand
        cmd = Me.Container.Connection.CreateCommand()
        cmd.CommandText = "DELETE FROM [zd_category] WHERE [GUID]=@guid"
        Dim param As Data.SQLite.SQLiteParameter = New Data.SQLite.SQLiteParameter("@guid", System.Data.DbType.Guid)
        param.Value = GUID
        cmd.Parameters.Add(param)

        If cmd.ExecuteNonQuery() > 0 Then
            Return True
        End If

    End Function

End Class
