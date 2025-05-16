Imports System.Data
Imports System.Data.SqlClient
Partial Class Roles_AccessRules
    Inherits System.Web.UI.Page
    Dim msg As New MsgeBox
    Private Function LoadMenu() As DataTable
        Dim objBase As New BaseGeneral
        objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim applicationIdString As String = getApplicationId(Me.lblRoleName.Text)
        Dim applicationId As System.Guid = New Guid(applicationIdString) '"dbf5bad3-8463-499b-a704-ed5b4d98f35a") 'applicationIdString)
        Dim qry As String = "SELECT * FROM tbl_Module WHERE ApplicationId='" & applicationId.ToString & "'" 'Session("app") 
        Return objBase.GetDataTable(qry, Data.CommandType.Text)
    End Function

    Private Function getApplicationId(ByVal roleName As String) As String
        Dim applicationIdString As String = ""
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString)
            conn.Open()
            Const selectQuery As String = "SELECT ApplicationId FROM aspnet_Roles WHERE RoleName=@roleName"
            Using cmd As New SqlCommand(selectQuery, conn)
                Dim p1 As SqlParameter = cmd.Parameters.Add("@roleName", System.Data.SqlDbType.NVarChar)
                p1.Value = roleName
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
    Private Function LoadSubMenu(ByVal moduleID As Integer) As DataTable
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim qry As String = "SELECT * FROM tbl_SubModule WHERE ModuleId=" & moduleID & " order by SequenceNo"
        dt = objBase.GetDataTable(qry, Data.CommandType.Text)
        Return dt
    End Function
    Private Function LoadComponent(ByVal submoduleID As Integer) As DataTable
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim qry As String = "SELECT * FROM tbl_Component WHERE SubModuleId=" & submoduleID & " order by SequenceNo"
        dt = objBase.GetDataTable(qry, Data.CommandType.Text)
        Return dt
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Page.Request.QueryString("role") = Nothing Then
                Me.lblRoleName.Text = FileClass.b64decode(Page.Request.QueryString("role"))
            End If
            PopulateTreeViewControl()
            ' LoadRoles()
        End If
    End Sub
    'Private Sub LoadRoles()
    '    Me.drpRole.DataSource = Roles.GetAllRoles()
    '    Me.drpRole.DataBind()
    'End Sub
    Private Sub PopulateTreeViewControl()
        Dim dtSub As New DataTable
        Dim dtComp As New DataTable
        Dim dtMenu As New DataTable
        dtMenu = LoadMenu()
        For Each menurow As DataRow In dtMenu.Rows
            Dim node As New TreeNode()
            node.Text = menurow("ModuleName").ToString()
            node.Value = menurow("ModuleID").ToString()
            'node.PopulateOnDemand = True
            node.SelectAction = TreeNodeSelectAction.SelectExpand
            Me.tvMenu.Nodes.Add(node)
            dtSub = LoadSubMenu(menurow("ModuleID"))
            For Each submenurow As DataRow In dtSub.Rows
                Dim nodeSub As New TreeNode()
                nodeSub.Text = submenurow("SubModuleName").ToString()
                nodeSub.Value = submenurow("SubModuleID").ToString()
                'node.PopulateOnDemand = False
                nodeSub.SelectAction = TreeNodeSelectAction.SelectExpand
                node.ChildNodes.Add(nodeSub)
                dtComp = LoadComponent(submenurow("SubModuleID"))
                For Each comprow As DataRow In dtComp.Rows
                    Dim compnode As New TreeNode()
                    compnode.Text = comprow("ComponentName").ToString()
                    compnode.Value = comprow("ComponentID").ToString()
                    'node.PopulateOnDemand = False
                    compnode.SelectAction = TreeNodeSelectAction.SelectExpand
                    nodeSub.ChildNodes.Add(compnode)
                Next comprow
            Next submenurow
            'Parent.ChildNodes.Add(node)
        Next menurow
    End Sub
    Protected Sub tvMenu_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMenu.SelectedNodeChanged
        Dim node As New TreeNode()
        node = tvMenu.SelectedNode
        Me.lblComponent.Text = tvMenu.SelectedNode.Text
        'Session("node") = node
        If node.Depth > 0 Then
            ClearCheckBox()
            'If node.Depth <> 1 Then
            '    EnableCheckBox(False)
            'Else
            'EnableCheckBox(True)
            'End If
            Me.cbAccess.Enabled = True
            btnUpdate.Enabled = True
            Me.gvAccessRule.Visible = True
            Me.Label1.Visible = False
            ' Me.lblCompId.Text = tvMenu.SelectedNode.Value
            'msg.UserMsgBox(tvMenu.SelectedNode.Value.ToString, Me, False)
            Dim dt As New DataTable
            dt = LoadSecurable(Me.tvMenu.SelectedNode.Value, node.Depth)
            If dt.Rows.Count = 0 Then
                BuildNoRecords(Me.gvAccessRule, dt)
            Else
                Me.gvAccessRule.DataSource = dt
                Me.gvAccessRule.DataBind()
            End If
        Else
            Me.Label1.Visible = True
            Me.Label1.Text = "*** Access Rule not Applicable ***"
            Me.gvAccessRule.Visible = False
            ClearCheckBox()
            Me.cbAccess.Enabled = False
            btnUpdate.Enabled = False

        End If
    End Sub
    Private Sub EnableCheckBox(ByVal val As Boolean)
        Me.cbAdd.Enabled = val
        Me.cbEdit.Enabled = val
        Me.cbDelete.Enabled = val
        Me.cbPrint.Enabled = val
        Me.cbOther.Enabled = val
    End Sub

    Private Sub ClearCheckBox()
        Me.cbAccess.Checked = False
        Me.cbAdd.Checked = False
        Me.cbEdit.Checked = False
        Me.cbDelete.Checked = False
        Me.cbPrint.Checked = False
        Me.cbOther.Checked = False

    End Sub
    Private Function LoadSecurable(ByVal componentId As Integer, ByVal level As Integer) As DataTable
        Dim objBase As New BaseGeneral
        Dim dt As New DataTable
        objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
        Dim RoleIdString As String = getRoleId(Me.lblRoleName.Text)
        Dim RoleId As System.Guid = New Guid(RoleIdString)
        Dim qry As String = ""
        If level = 1 Then
            qry = "SELECT * FROM tbl_Securable WHERE ModuleID=" & componentId & " AND RoleId='" & RoleId.ToString & "'"
        ElseIf level = 2 Then
            qry = "SELECT * FROM tbl_Securable WHERE ComponentID=" & componentId & " AND RoleId='" & RoleId.ToString & "'"
        End If
        'Dim qry As String = "SELECT * FROM tbl_Module WHERE ApplicationId='" & applicationId.ToString & "'" 'Session("app")
        dt = objBase.GetDataTable(qry, CommandType.Text)
        Return dt

    End Function
    Private Function getRoleId(ByVal roleName As String) As String
        Dim applicationIdString As String = ""
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString)
            conn.Open()
            Const selectQuery As String = "SELECT RoleId FROM aspnet_Roles WHERE RoleName=@roleName"
            Using cmd As New SqlCommand(selectQuery, conn)
                Dim p1 As SqlParameter = cmd.Parameters.Add("@roleName", System.Data.SqlDbType.NVarChar)
                p1.Value = roleName
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

    Private Sub BuildNoRecords(ByVal gridView As GridView, ByVal dt As DataTable)
        Try
            If dt.Rows.Count = 0 Then
                'Add a blank row to the dataset
                dt.Rows.Add(dt.NewRow())
                'Bind the DataSet to the GridView
                gridView.DataSource = dt
                gridView.DataBind()
                'Get the number of columns to know what the Column Span should be
                Dim columnCount As Integer = gridView.Rows(0).Cells.Count
                'Call the clear method to clear out any controls that you use in the columns.  I use a dropdown list in one of the column so this was necessary.
                gridView.Rows(0).Cells.Clear()
                gridView.Rows(0).Cells.Add(New TableCell)
                gridView.Rows(0).Cells(0).ColumnSpan = columnCount
                gridView.Rows(0).Cells(0).Text = "No Access Rule set for this ROLE."
            End If
        Catch ex As Exception
            'Do your exception handling here
        End Try
    End Sub
    Protected Sub gvAccessRule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAccessRule.SelectedIndexChanged
        'If Session("node") > 0 Then
        'EnableCheckBox(True)
        LoadCheckBox()
        ' End If

    End Sub
    Private Sub LoadCheckBox()
        Dim dt As New DataTable
        Dim node As New TreeNode()
        node = tvMenu.SelectedNode
        dt = LoadSecurable(CInt(tvMenu.SelectedNode.Value), node.Depth)
        Dim dr As DataRow
        dr = dt.Rows(0)
        If dt.Rows.Count > 0 Then
            Me.cbAccess.Checked = IIf(IsDBNull(dr("HasAccess")), False, dr("HasAccess"))
            Me.cbAdd.Checked = IIf(IsDBNull(dr("CanAdd")), False, dr("CanAdd"))
            Me.cbEdit.Checked = IIf(IsDBNull(dr("CanEdit")), False, dr("CanEdit"))
            Me.cbDelete.Checked = IIf(IsDBNull(dr("CanDelete")), False, dr("CanDelete"))
            Me.cbPrint.Checked = IIf(IsDBNull(dr("CanPrint")), False, dr("CanPrint"))
            Me.cbOther.Checked = IIf(IsDBNull(dr("Other")), False, dr("Other"))
        End If
    End Sub


    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try

       
            Dim node As New TreeNode()
            node = tvMenu.SelectedNode 'modified

            Dim objBase As New BaseGeneral

            objBase.conStr = ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString
            Dim RoleIdString As String = getRoleId(lblRoleName.Text)
            Dim RoleId As System.Guid = New Guid(RoleIdString)

            If node.Depth = 1 Then


                Dim delCmd As String = "DELETE FROM tbl_Securable WHERE ModuleID=" & CInt(tvMenu.SelectedNode.Value) & " AND RoleId='" & RoleId.ToString & "'"
                objBase.Execute("", delCmd, CommandType.Text)


                Dim insertCmd As String = "INSERT INTO tbl_Securable(RoleId,HasAccess,CanAdd,CanEdit,CanDelete,CanPrint,Other,ModuleID) " &
                                                          "VALUES(@RoleId,@HasAccess,@CanAdd,@CanEdit,@CanDelete,@CanPrint,@Other,@ModuleID)"

                objBase.cmd.Parameters.Clear()

                objBase.cmd.Parameters.AddWithValue("@RoleId", RoleId)
                objBase.cmd.Parameters.AddWithValue("@HasAccess", Me.cbAccess.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanAdd", Me.cbAdd.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanEdit", Me.cbEdit.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanDelete", Me.cbDelete.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanPrint", Me.cbPrint.Checked)
                objBase.cmd.Parameters.AddWithValue("@Other", Me.cbOther.Checked)
                objBase.cmd.Parameters.AddWithValue("@ModuleID", CInt(tvMenu.SelectedNode.Value))
                objBase.Execute("", insertCmd, CommandType.Text)

            ElseIf node.Depth = 2 Then

                Dim delCmd As String = "DELETE FROM tbl_Securable WHERE ComponentId=" & CInt(tvMenu.SelectedNode.Value) & " AND RoleId='" & RoleId.ToString & "'"
                objBase.Execute("", delCmd, CommandType.Text)




                Dim insertCmd As String = "INSERT INTO tbl_Securable(ComponentId,RoleId,HasAccess,CanAdd,CanEdit,CanDelete,CanPrint,Other) " & _
                                                          "VALUES(@ComponentId,@RoleId,@HasAccess,@CanAdd,@CanEdit,@CanDelete,@CanPrint,@Other)"

                objBase.cmd.Parameters.Clear()
                objBase.cmd.Parameters.AddWithValue("@ComponentId", CInt(tvMenu.SelectedNode.Value))
                objBase.cmd.Parameters.AddWithValue("@RoleId", RoleId)
                objBase.cmd.Parameters.AddWithValue("@HasAccess", Me.cbAccess.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanAdd", Me.cbAdd.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanEdit", Me.cbEdit.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanDelete", Me.cbDelete.Checked)
                objBase.cmd.Parameters.AddWithValue("@CanPrint", Me.cbPrint.Checked)
                objBase.cmd.Parameters.AddWithValue("@Other", Me.cbOther.Checked)

                objBase.Execute("", insertCmd, CommandType.Text)
            End If

            Dim dt As New DataTable
            dt = LoadSecurable(Me.tvMenu.SelectedNode.Value, node.Depth)

            If dt.Rows.Count = 0 Then
                BuildNoRecords(Me.gvAccessRule, dt)
            Else
                Me.gvAccessRule.DataSource = dt
                Me.gvAccessRule.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.message)
        End Try
    End Sub

    Protected Sub lnkBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBack.Click
        Response.Redirect("ManageRoles.aspx")
    End Sub

    
End Class
