Imports System.Data
Imports System.Data.SqlClient
Partial Class logaudit_ManageLogTable
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadDatabase()
            LoadTables()
            LoadLogTables()
        End If
    End Sub
    Private Sub CheckDefaultTable()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim con As New SqlConnection(conStr)
        con.Open()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("SELECT isnull(object_id,0) from sys.tables where name='tbl_PrimaryFields'")
    End Sub
    Private Sub LoadLogTables()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim con As New SqlConnection(conStr)
        con.Open()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("IF EXISTS(SELECT object_id from sys.tables where name='tbl_PrimaryFields') " & _
                                "SELECT *,b.ApplicationName FROM tbl_PrimaryFields a INNER JOIN aspnet_Applications b on a.applicationid=b.applicationid", con)
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        Try
            da.Fill(dt)
        Catch ae As SqlException
            Throw New Exception(ae.Message)
        Finally
            con.Close()
        End Try

        If dt.Rows.Count > 0 Then
            Me.dgLogTables.DataSource = dt
            Me.dgLogTables.DataBind()
        Else
            Me.Label1.Text = "No audit configurations has been set yet!!!"
        End If

    End Sub
    Private Sub LoadDatabase()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        Dim con As New SqlConnection(conStr)
        con.Open()
        Dim dt As DataTable = con.GetSchema(SqlClientMetaDataCollectionNames.Databases)
        Dim dv As DataView = New DataView(dt)
        dv.Sort = "database_name"
        con.Close()

        Me.ddlSystemDB.DataSource = dv
        Me.ddlSystemDB.DataTextField = "database_name"
        Me.ddlSystemDB.DataValueField = "database_name"
        Me.ddlSystemDB.DataBind()

        Me.ddlSystemDB.Items.Add("--SELECT--")
        Me.ddlSystemDB.Items(Me.ddlSystemDB.Items.Count - 1).Value = 0
        Me.ddlSystemDB.Items(Me.ddlSystemDB.Items.Count - 1).Selected = True

        Me.ddlSysMngrDB.DataSource = dv
        Me.ddlSysMngrDB.DataTextField = "database_name"
        Me.ddlSysMngrDB.DataValueField = "database_name"
        Me.ddlSysMngrDB.DataBind()

        Me.ddlSysMngrDB.Items.Add("--SELECT--")
        Me.ddlSysMngrDB.Items(Me.ddlSysMngrDB.Items.Count - 1).Value = 0
        Me.ddlSysMngrDB.Items(Me.ddlSysMngrDB.Items.Count - 1).Selected = True
    End Sub
    Private Sub LoadTables()
        Me.ddlTables.Items.Clear()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        '= "Data Source=" & Me.cboServer.Text & ";uid=sa;pwd=P@ssw0rd;Initial Catalog=" & Me.cboDatabase.Text & ";Integrated Security=false"
        Dim con As New SqlConnection(conStr)
        con.Open()

        Dim qryStr As String = "select b.name +'.' + a.name as table_name ,object_id from sys.tables a inner join  sys.schemas b on a.schema_id = b.schema_id"

        Dim cmd As SqlCommand = New SqlCommand(qryStr, con)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        da.SelectCommand = cmd
        da.Fill(dt)
        'dt = con.GetSchema(SqlClientMetaDataCollectionNames.Tables, New String() {Nothing, Nothing, Nothing, "BASE TABLE"})

        'dt.DefaultView.Sort = "table_name"
        Dim dv As DataView = New DataView(dt)
        dv.Sort = "table_name"

        con.Close()

        'For Each r As DataRowView In dv
        '    Me.cboTables.Items.Add(r("table_name").ToString())
        'Next

        Me.ddlTables.DataSource = dv
        Me.ddlTables.DataTextField = "table_name"
        Me.ddlTables.DataValueField = "object_id"
        Me.ddlTables.DataBind()

        Me.ddlTables.Items.Add("--SELECT--")
        Me.ddlTables.Items(Me.ddlTables.Items.Count - 1).Value = 0
        Me.ddlTables.Items(Me.ddlTables.Items.Count - 1).Selected = True
    End Sub
    Private Sub LoadFields(ByVal tableID As Long)

        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        Dim con As New SqlConnection(conStr)
        con.Open()


        Dim qryStr As String = "select column_name,table_catalog,table_schema,ordinal_position,object_id " & _
                                 "from information_schema.columns a inner join  sys.tables b on b.name=a.table_name " & _
                                    " WHERE object_id=" & tableID & " ORDER BY ordinal_position"

        Dim cmd As SqlCommand = New SqlCommand(qryStr, con)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        da.SelectCommand = cmd
        da.Fill(dt)
        con.Close()

        Me.ddlFields.DataSource = dt
        Me.ddlFields.DataTextField = "column_name"
        Me.ddlFields.DataValueField = "column_name"
        Me.ddlFields.DataBind()

        Me.ddlFields.Items.Add("--SELECT--")
        Me.ddlFields.Items(Me.ddlFields.Items.Count - 1).Value = 0
        Me.ddlFields.Items(Me.ddlFields.Items.Count - 1).Selected = True
    End Sub

    Protected Sub ddlTables_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTables.SelectedIndexChanged
        'Me.txtTableID.Text = Me.ddlTables.SelectedValue
        LoadFields(Me.ddlTables.SelectedValue)
    End Sub
    Protected Sub btnEnable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnable.Click
        If Me.cbEnable.Checked = True Then
            CreateTables()
            CreateViews(Me.ddlSysMngrDB.SelectedItem.Text)
        End If
        subSaveLogTables()
        CreateTriggers(Me.ddlTables.SelectedValue, Me.ddlTables.SelectedItem.Text)
        LoadLogTables()
        Me.Label1.Text = "Audit Trail for " & Me.ddlTables.SelectedItem.Text & " has been successfully configured."
    End Sub

    Private Sub ExecuteSQLStmt(ByVal sql As String, ByVal conStr As String)
        ' Open the connection
        'Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim conn As New SqlConnection(conStr)
        Dim cmd As SqlCommand
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ae As SqlException
            Throw New Exception(ae.Message)
        Finally
            conn.Close()
        End Try
    End Sub 'ExecuteSQLStmt 
    Private Sub subSaveLogTables()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim conn As New SqlConnection(conStr)
        Dim cmd As SqlCommand
        conn.Open()

        cmd = New SqlCommand("spEnable_TableAudit", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@sysmngrdb", Me.ddlSysMngrDB.SelectedValue)
        cmd.Parameters.AddWithValue("@localdb", Me.ddlSystemDB.SelectedValue)
        cmd.Parameters.AddWithValue("@tablename", Me.ddlTables.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@tableid", Me.ddlTables.SelectedValue)
        cmd.Parameters.AddWithValue("@primaryfield", Me.ddlFields.SelectedValue)
        cmd.Parameters.AddWithValue("@applicationID", getApplicationId)
        Try
            cmd.ExecuteNonQuery()
        Catch ae As SqlException
            Throw New Exception(ae.Message)
        Finally
            conn.Close()
        End Try

        conn.Close()
    End Sub

    Private Sub CreateTriggers(ByVal tableid As Long, ByVal tablename As String)
        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        'Dim conn As New SqlConnection(conStr)
        'Dim cmd As New SqlCommand("select * from sys.tables where obejct_id=" & tableid, conn)

        Dim Sql As String

        Sql = "create trigger Audit_" & tableid.ToString & " on " & tablename & " for insert, update, delete AS " & _
                "external name [AuditCommon].[AuditCommon.Triggers].AuditCommon"

        ExecuteSQLStmt(Sql, conStr)

    End Sub
    Private Sub CreateTables()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim Sql As String
        Sql = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tbl_PrimaryFields' AND TABLE_SCHEMA = 'dbo') DROP TABLE [dbo].[tbl_PrimaryFields]"
        ExecuteSQLStmt(Sql, conStr)

        Sql = "CREATE TABLE [dbo].[tbl_PrimaryFields]([TableName] [varchar](150)," & _
                "[PrimaryField] [varchar](150),[TableId] [int] NULL,[ApplicationId] [uniqueidentifier] NULL) ON [PRIMARY]"
        ExecuteSQLStmt(Sql, conStr)

        Sql = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tbl_AuditTrail' AND TABLE_SCHEMA = 'dbo') DROP TABLE [dbo].[tbl_AuditTrail]"
        ExecuteSQLStmt(Sql, conStr)

        Sql = "CREATE TABLE [dbo].[tbl_AuditTrail](	[AuditId] [bigint] IDENTITY(1,1) NOT NULL,[TableName] [varchar](50) NOT NULL, " & _
                "[RowId] [bigint] NOT NULL,[Operation] [varchar](10) NOT NULL,[OccurredAt] [datetime] NOT NULL,[TimeCaptured] [datetime] NULL, " & _
                "[PerformedBy] [varchar](50) NOT NULL,[FieldName] [varchar](50)  NULL,[OldValue] [varchar](1000)  NULL,[NewValue] [varchar](1000) NULL,) ON [PRIMARY]"

        ExecuteSQLStmt(Sql, conStr)
    End Sub
    Private Sub CreateViews(ByVal dbName As String)
        Dim conStr As String = ConfigurationManager.ConnectionStrings("constr").ToString
        Dim Sql As String

        Sql = "IF OBJECT_ID ('dbo.vw_AuditTrail', 'V') IS NOT NULL DROP VIEW [dbo].[vw_AuditTrail]"
        ExecuteSQLStmt(Sql, conStr)

        Sql = "CREATE VIEW [dbo].[vw_AuditTrail] AS " & _
                                "SELECT AuditId,TableName,RowId,Operation,OccurredAt,PerformedBy,FieldName,OldValue,NewValue FROM " & _
                                    dbName & ".dbo.tbl_AuditTrail"
        ExecuteSQLStmt(Sql, conStr)

        Sql = "IF OBJECT_ID ('dbo.vw_GetTableName', 'V') IS NOT NULL DROP VIEW [dbo].[vw_GetTableName]"
        ExecuteSQLStmt(Sql, conStr)

        Sql = "CREATE VIEW [dbo].[vw_GetTableName] AS " & _
                "SELECT TableName, PrimaryField, TableId FROM " & dbName & ".dbo.tbl_PrimaryFields"
        ExecuteSQLStmt(Sql, conStr)

    End Sub
    Private Function getApplicationId() As String
        Dim conStr As String = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim applicationIdString As String = ""

        Using conn As New SqlConnection(conStr)
            conn.Open()
            Const selectQuery As String = "SELECT ApplicationId FROM aspnet_Applications WHERE ApplicationName=@appName"

            Using cmd As New SqlCommand(selectQuery, conn)
                cmd.Parameters.AddWithValue("@appName", Membership.ApplicationName)
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.Read() Then
                    applicationIdString = dr(0).ToString()
                End If
            End Using

            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Using

        Return applicationIdString
    End Function
End Class
