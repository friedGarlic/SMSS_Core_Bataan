Imports System.Data

Partial Class Inventory_TransferApproval
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Initialize page controls
            txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy")
            ' Default empty rows for gridviews
            SetDefaultEmptyRows()
            ' Bind dropdowns
            BindDepartmentDropdown()

        End If
    End Sub

    ' ========================================
    ' HELPER METHODS
    ' ========================================

    Private Sub SetDefaultEmptyRows()
        ' ========================================
        ' Set 4 default empty rows for grdPendingPRS
        ' ========================================
        Dim dtPending As DataTable = New DataTable()
        dtPending.Columns.Add("DateTransfer", GetType(String))
        dtPending.Columns.Add("DepartmentFrom", GetType(String))
        dtPending.Columns.Add("DepartmentTo", GetType(String))
        dtPending.Columns.Add("ReturnedBy", GetType(String))
        dtPending.Columns.Add("Purpose", GetType(String))
        dtPending.Columns.Add("Remarks", GetType(String))
        ' Add DataKeyNames columns
        dtPending.Columns.Add("MRE_Transfer_ID", GetType(String))
        dtPending.Columns.Add("MREHdr_ID", GetType(String))
        dtPending.Columns.Add("Returned_ID", GetType(String))
        dtPending.Columns.Add("TransferTo", GetType(String))
        dtPending.Columns.Add("DepartmentFromID", GetType(String))

        For i As Integer = 0 To 3
            Dim row As DataRow = dtPending.NewRow()
            row("DateTransfer") = String.Empty
            row("DepartmentFrom") = String.Empty
            row("DepartmentTo") = String.Empty
            row("ReturnedBy") = String.Empty
            row("Purpose") = String.Empty
            row("Remarks") = String.Empty
            row("MRE_Transfer_ID") = String.Empty
            row("MREHdr_ID") = String.Empty
            row("Returned_ID") = String.Empty
            row("TransferTo") = String.Empty
            row("DepartmentFromID") = String.Empty
            dtPending.Rows.Add(row)

        Next
        grdPendingPRS.DataSource = dtPending
        grdPendingPRS.DataBind()

        ' ========================================
        ' Set 4 default empty rows for grListOfProperty
        ' ========================================
        Dim dtProperty As DataTable = New DataTable()
        ' Display columns
        dtProperty.Columns.Add("Item_Desc", GetType(String))
        dtProperty.Columns.Add("PropertyNo", GetType(String))
        dtProperty.Columns.Add("AcquiredDate", GetType(String))
        dtProperty.Columns.Add("Cost", GetType(String))
        dtProperty.Columns.Add("fullname", GetType(String))
        dtProperty.Columns.Add("DateIssued", GetType(String))
        dtProperty.Columns.Add("Status", GetType(String))
        ' Hidden columns (if any)
        dtProperty.Columns.Add("MREHdr_ID", GetType(String))
        dtProperty.Columns.Add("MRE_Transfer_ID", GetType(String))
        ' Add any additional DataKeyNames if defined in GridView
        ' dtProperty.Columns.Add("PropertyDetai_ID", GetType(String))
        ' dtProperty.Columns.Add("Property_ID", GetType(String))

        For i As Integer = 0 To 3
            Dim row As DataRow = dtProperty.NewRow()
            row("Item_Desc") = String.Empty
            row("PropertyNo") = String.Empty
            row("AcquiredDate") = String.Empty
            row("Cost") = String.Empty
            row("fullname") = String.Empty
            row("DateIssued") = String.Empty
            row("Status") = String.Empty
            row("MREHdr_ID") = String.Empty
            row("MRE_Transfer_ID") = String.Empty
            dtProperty.Rows.Add(row)
        Next
        grListOfProperty.DataSource = dtProperty
        grListOfProperty.DataBind()
    End Sub

    Private Sub BindDepartmentDropdown()
        Try
            Dim dtDepartment As DataTable = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM dbo.View_RespCenter_withFunctions WHERE RC_ID IS NOT NULL AND ISNULL(RC_Name, '') <> '' ORDER BY RC_Name", CommandType.Text)
            drpDepartment.DataSource = dtDepartment
            drpDepartment.DataTextField = "RC_Name"
            drpDepartment.DataValueField = "RC_ID"
            drpDepartment.DataBind()
            drpDepartment.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
            drpDepartment.Items.Clear()
            drpDepartment.Items.Insert(0, New ListItem("-- Error Loading Departments --", "0"))
        End Try
    End Sub

    Private Sub BindApprovedByDropdown()
        Try
            Dim dtApprovers As DataTable = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE isActive = 1 AND ISNULL(Full_Name, '') <> '' AND deptid = '" & grdPendingPRS.SelectedDataKey("DepartmentFromID") & "' AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
            drpApprovedBy.DataSource = dtApprovers
            drpApprovedBy.DataTextField = "Full_Name"
            drpApprovedBy.DataValueField = "EmpID"
            drpApprovedBy.DataBind()
            drpApprovedBy.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
            drpApprovedBy.Items.Clear()
            drpApprovedBy.Items.Insert(0, New ListItem("-- Error Loading Approvers --", "0"))
        End Try
    End Sub

    Private Sub LoadTransferApprovalList(ByVal searchType As Integer, ByVal searchValue As String)
        AddTrace("searchType: " & searchType)
        AddTrace("searchValue:" & searchValue)
        Try
            Dim dtTransferList As DataTable = objDerived.GetDataTable("EXEC AMS.sp_GetTransferApprovalList @SearchType = " & searchType & ", @SearchValue = '" & searchValue & "'", CommandType.Text)
            If dtTransferList.Rows.Count > 0 Then
                grdPendingPRS.DataSource = dtTransferList
                grdPendingPRS.DataBind()


            Else
                SetDefaultEmptyRows()
            End If
        Catch ex As Exception
            SetDefaultEmptyRows()
        End Try


        grdPendingPRS.SelectedIndex = -1

        grListOfProperty.SelectedIndex = -1
        grListOfProperty.DataSource = Nothing
        grListOfProperty.DataBind()


    End Sub

    Private Sub LoadPropertyList(ByVal transferID As String)

        Try

            Dim dtProperty As DataTable =
            objDerived.GetDataTable(
                "EXEC AMS.sp_GetTransferApprovalPropertyList " &
                "@MRE_Transfer_ID = " & transferID,
                CommandType.Text
            )


            If dtProperty.Rows.Count > 0 Then

                grListOfProperty.DataSource = dtProperty
                grListOfProperty.DataBind()

            Else

                SetDefaultEmptyRows()

            End If


        Catch ex As Exception

            SetDefaultEmptyRows()

        End Try

    End Sub

    ' ========================================
    ' SEARCH EVENTS
    ' ========================================

    Protected Sub drpSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drpSearch.SelectedIndexChanged
        ' Switch between Department and Date search views
        If drpSearch.SelectedValue = "0" Then
            mvSearch.ActiveViewIndex = 0 ' Department view
        ElseIf drpSearch.SelectedValue = "1" Then
            mvSearch.ActiveViewIndex = 1 ' Date view
        End If
    End Sub

    Protected Sub drpDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drpDepartment.SelectedIndexChanged
        If drpDepartment.SelectedIndex > 0 Then
            Dim searchValue As String = drpDepartment.SelectedValue
            LoadTransferApprovalList(0, searchValue)
            btnApprove.Enabled = False
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim searchType As Integer = CInt(drpSearch.SelectedValue)
        Dim searchValue As String = String.Empty

        If searchType = 0 Then
            ' Department search
            If drpDepartment.SelectedIndex > 0 Then
                searchValue = drpDepartment.SelectedValue
            Else
                ' Load all if no department selected
                searchValue = String.Empty
            End If
        ElseIf searchType = 1 Then
            ' Date range search
            If Not String.IsNullOrEmpty(txtDateFrom.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtDateto.Text.Trim()) Then
                searchValue = String.Format("{0}|{1}", txtDateFrom.Text.Trim(), txtDateto.Text.Trim())
            Else
                ' Load all if date range incomplete
                searchValue = String.Empty
            End If
        End If

        ' Call load function
        LoadTransferApprovalList(searchType, searchValue)
        btnApprove.Enabled = False
    End Sub


    ' ========================================
    ' GRIDVIEW EVENTS
    ' ========================================

    Protected Sub grdPendingPRS_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdPendingPRS.SelectedIndexChanged
        Dim row As GridViewRow = grdPendingPRS.SelectedRow
        If row IsNot Nothing Then
            Dim transferID As String = grdPendingPRS.DataKeys(row.RowIndex)("MRE_Transfer_ID").ToString()
            If Not String.IsNullOrEmpty(transferID) Then
                LoadPropertyList(transferID)

                BindApprovedByDropdown()
            End If
        End If

        grListOfProperty.SelectedIndex = -1
        drpApprovedBy.SelectedIndex -= 1
    End Sub

    Protected Sub grListOfProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grListOfProperty.SelectedIndexChanged
        ' TODO: Handle property selection
        ' Get selected property details
        Dim row As GridViewRow = grListOfProperty.SelectedRow
        If row IsNot Nothing Then
            ' Get property details from DataKeys
            ' Perform any required action when a property is selected
        End If
        btnApprove.Enabled = True
        btnDisApprove.Enabled = True

    End Sub

    ' ========================================
    ' BUTTON EVENTS (BLANK FOR FUTURE USE)
    ' ========================================

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApprove.Click
        Try
            ' Validate that a transfer is selected
            If grdPendingPRS.SelectedIndex < 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a transfer record.")
                Exit Sub
            End If

            ' Validate that a signatory is selected
            If drpApprovedBy.SelectedIndex = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a signatory.")
                Exit Sub
            End If

            Dim MRE_Transfer_ID As String = grdPendingPRS.SelectedDataKey("MRE_Transfer_ID").ToString()

            objDerived.GetDataTable("EXEC AMS.sp_ApproveTransfer @MRE_Transfer_ID = " & MRE_Transfer_ID, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transfer successfully approved.")


            Dim searchType As Integer = CInt(drpSearch.SelectedValue)
            Dim searchValue As String = String.Empty

            If searchType = 0 Then

                If drpDepartment.SelectedIndex > 0 Then
                    searchValue = drpDepartment.SelectedValue
                End If

            ElseIf searchType = 1 Then

                If Not String.IsNullOrEmpty(txtDateFrom.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtDateto.Text.Trim()) Then
                    searchValue = String.Format("{0}|{1}", txtDateFrom.Text.Trim(), txtDateto.Text.Trim())
                End If

            End If

            LoadTransferApprovalList(searchType, searchValue)

            btnApprove.Enabled = False


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error approving transfer.")
        End Try
    End Sub

    Protected Sub btnDisApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDisApprove.Click
        Try
            ' Validate that a transfer is selected
            If grdPendingPRS.SelectedIndex < 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a transfer record.")
                Exit Sub
            End If

            ' Validate that a signatory is selected
            If drpApprovedBy.SelectedIndex = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select a signatory.")
                Exit Sub
            End If

            Dim MRE_Transfer_ID As String = grdPendingPRS.SelectedDataKey("MRE_Transfer_ID").ToString()

            objDerived.GetDataTable("EXEC AMS.sp_DisapproveTransfer @MRE_Transfer_ID = " & MRE_Transfer_ID, CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transfer successfully disapproved.")


            Dim searchType As Integer = CInt(drpSearch.SelectedValue)
            Dim searchValue As String = String.Empty

            If searchType = 0 Then

                If drpDepartment.SelectedIndex > 0 Then
                    searchValue = drpDepartment.SelectedValue
                End If

            ElseIf searchType = 1 Then

                If Not String.IsNullOrEmpty(txtDateFrom.Text.Trim()) AndAlso Not String.IsNullOrEmpty(txtDateto.Text.Trim()) Then
                    searchValue = String.Format("{0}|{1}", txtDateFrom.Text.Trim(), txtDateto.Text.Trim())
                End If

            End If

            LoadTransferApprovalList(searchType, searchValue)

            btnApprove.Enabled = False


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error disapproving transfer.")
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPreview.Click
        ' TODO: Implement preview logic
        ' This function will be implemented in future
    End Sub

End Class