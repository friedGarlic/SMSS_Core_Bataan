Imports System.Data
Imports System
Partial Class Inventory_Disposal_prerepair_inspection
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)

    End Sub

    Private Property dtGenAccounts() As DataTable
        Get
            Return CType(Session("dtGenAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtGenAccounts") = value
        End Set
    End Property

    Private Property dtPropertyList() As DataTable
        Get
            Return CType(Session("dtPropertyList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPropertyList") = value
        End Set
    End Property

    Private Property dtForRepair() As DataTable
        Get
            Return CType(Session("dtForRepair"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtForRepair") = value
        End Set
    End Property

    Public Function dtTemp_PropertyList(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn


        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("ItemDesc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("Property_Date", GetType(Date))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("prerepair_date", GetType(String))
        dt.Columns.Add("nature_scope", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("Item_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("ItemDesc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("Property_Date") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("isVisible") = False
            dr("prerepair_date") = DBNull.Value
            dr("nature_scope") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_Disposal_prerepair_inspection_Load(sender As Object, e As EventArgs) Handles Me.Load

        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            LoadPage()

        End If

        drpDepartment.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    Protected Sub LoadPage()
        drpDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM DBO.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
        drpDepartment.DataTextField = ("RC_Name")
        drpDepartment.DataValueField = ("RC_ID")
        drpDepartment.DataBind()
        drpDepartment.Items.Insert(0, "Select")

        drpFunction.DataSource = Nothing
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")

        drpGenAccount.DataSource = objDerived.GetDataTable("SELECT GA_ID, BGA_ID, (GA_Title + ' (' + GA_Code + ')') as GA_Title FROM AMS.View_AccountList WHERE AllotmentClass_ID = 3 AND BGA_ID = 0 ORDER BY GA_Title", CommandType.Text)
        drpGenAccount.DataTextField = ("GA_Title")
        drpGenAccount.DataValueField = ("GA_ID")
        drpGenAccount.DataBind()
        drpGenAccount.Items.Insert(0, "Select")

        grdPropertyList.DataSource = dtTemp_PropertyList(4)
        grdPropertyList.DataBind()

        grdPreRepair.DataSource = Nothing
        grdPreRepair.DataBind()

        txtDate.Text = Date.Today.ToShortDateString

        drpRequestedby.DataSource = Nothing
        drpRequestedby.DataBind()
        drpRequestedby.Items.Insert(0, "Select")

        drpInspectedby.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid IN (27,70) AND division_Key = 86 AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
        drpInspectedby.DataTextField = ("Full_Name")
        drpInspectedby.DataValueField = ("EmpID")
        drpInspectedby.DataBind()
        drpInspectedby.Items.Insert(0, "Select")

        drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid IN (27,70) AND division_Key = 86 AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
        drpApprovedBy.DataTextField = ("Full_Name")
        drpApprovedBy.DataValueField = ("EmpID")
        drpApprovedBy.DataBind()
        drpApprovedBy.Items.Insert(0, "Select")

        drpApprovedBy_GSO.DataSource = objDerived.GetDataTable("SELECT Full_Name,EmpID FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY Full_Name", CommandType.Text)
        drpApprovedBy_GSO.DataTextField = ("Full_Name")
        drpApprovedBy_GSO.DataValueField = ("EmpID")
        drpApprovedBy_GSO.DataBind()
        drpApprovedBy_GSO.Items.Insert(0, "Select")

    End Sub
    Private Sub drpDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDepartment.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT * FROM DBO.View_RespCenter_withFunctions WHERE RC_ID = " & drpDepartment.SelectedItem.Value & " ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = ("Function_Desc")
        drpFunction.DataValueField = ("Function_ID")
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")

    End Sub
    Private Sub drpFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpFunction.SelectedIndexChanged
        drpRequestedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = '" & drpDepartment.SelectedItem.Value & "' and division_Key = '" & drpFunction.SelectedItem.Value & "' AND isDeptHead = 'Yes' ORDER BY Full_Name", CommandType.Text)
        drpRequestedby.DataTextField = ("Full_Name")
        drpRequestedby.DataValueField = ("EmpID")
        drpRequestedby.DataBind()

    End Sub
    Private Sub Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try


            If drpDepartment.SelectedItem.Text = "Select" Or drpFunction.SelectedItem.Text = "Select" Or drpGenAccount.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select all required fields to preview the list of properties.")
            Else
                AddTrace("drpDepartment: " & drpDepartment.SelectedItem.Value)
                AddTrace("drpFunction: " & drpFunction.SelectedItem.Value)
                AddTrace("drpGenAccount: " & drpGenAccount.SelectedItem.Value)

                dtPropertyList = objDerived.GetDataTable("EXEC [AMS].[sp_prerepair_itemlist] '" & drpDepartment.SelectedItem.Value & "','" & drpFunction.SelectedItem.Value & "','" & drpGenAccount.SelectedItem.Value & "'", CommandType.Text)
                If dtPropertyList.Rows.Count < 5 Then
                    dtPropertyList.Merge(dtTemp_PropertyList(4 - dtPropertyList.Rows.Count))
                End If
                grdPropertyList.DataSource = dtPropertyList
                grdPropertyList.DataBind()

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, pls contact system admin.")
        End Try
    End Sub

    Private Sub grdPropertyList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPropertyList.PageIndexChanging
        grdPropertyList.DataSource = dtPropertyList
        grdPropertyList.PageIndex = e.NewPageIndex
        grdPropertyList.DataBind()
    End Sub
    Private Sub grdPropertyList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPropertyList.SelectedIndexChanged
        Try

            Dim dt As New DataTable
            Dim dr As DataRow


            If grdPreRepair.Rows.Count = Nothing Or grdPreRepair.Rows.Count <= 0 Then
                dt.Columns.Add("PropertyDetai_ID", GetType(Integer))
                dt.Columns.Add("Item_ID", GetType(Integer))
                dt.Columns.Add("prerepair_date", GetType(String))
                dt.Columns.Add("nature_scope", GetType(String))
                dt.Columns.Add("ItemDesc", GetType(String))
                dt.Columns.Add("PropertyNo", GetType(String))
                dt.Columns.Add("SerialNo", GetType(String))

                dr = dt.NewRow
                dr("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
                dr("Item_ID") = grdPropertyList.SelectedDataKey("Item_ID")
                dr("prerepair_date") = grdPropertyList.SelectedDataKey("prerepair_date")
                dr("nature_scope") = IIf(grdPropertyList.SelectedDataKey("nature_scope") = "", "First Repair per Record", (grdPropertyList.SelectedDataKey("nature_scope") & IIf(grdPropertyList.SelectedDataKey("prerepair_date") = "", "", ", ") & grdPropertyList.SelectedDataKey("prerepair_date")))
                dr("ItemDesc") = grdPropertyList.SelectedDataKey("ItemDesc")
                dr("PropertyNo") = grdPropertyList.SelectedDataKey("PropertyNo")
                dr("SerialNo") = grdPropertyList.SelectedDataKey("SerialNo")
                dt.Rows.Add(dr)

                dtForRepair = dt

            Else
                dt = dtForRepair
                dr = dt.NewRow
                dr("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
                dr("Item_ID") = grdPropertyList.SelectedDataKey("Item_ID")
                dr("prerepair_date") = grdPropertyList.SelectedDataKey("prerepair_date")
                dr("nature_scope") = IIf(grdPropertyList.SelectedDataKey("nature_scope") = "", "First Repair per Record", (grdPropertyList.SelectedDataKey("nature_scope") & IIf(grdPropertyList.SelectedDataKey("prerepair_date") = "", "", ", ") & grdPropertyList.SelectedDataKey("prerepair_date")))
                dr("ItemDesc") = grdPropertyList.SelectedDataKey("ItemDesc")
                dr("PropertyNo") = grdPropertyList.SelectedDataKey("PropertyNo")
                dr("SerialNo") = grdPropertyList.SelectedDataKey("SerialNo")
                dt.Rows.Add(dr)

                dtForRepair = dt
            End If


            grdPreRepair.DataSource = dtForRepair
            grdPreRepair.DataBind()

            Dim row As DataRow = dtPropertyList.[Select]("PropertyDetai_ID='" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "'").FirstOrDefault()
            row("isUsed") = True

            Dim myview1 As DataView
            myview1 = dtPropertyList.DefaultView
            myview1.RowFilter = "isUsed = 0"
            grdPropertyList.DataSource = myview1
            grdPropertyList.DataBind()
            grdPropertyList.SelectedIndex = -1

            txtGSOInspector.Text = ""
            txtGSOInspector.Enabled = True

            drpRequestedby.Enabled = True
            drpInspectedby.Enabled = True
            drpApprovedBy.Enabled = True
            drpApprovedBy_GSO.Enabled = True

            btnSave.Enabled = True
            btnPreview.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub grdPreRepair_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPreRepair.SelectedIndexChanged
        Try

            Dim row As DataRow = dtPropertyList.[Select]("PropertyDetai_ID='" & grdPreRepair.SelectedDataKey("PropertyDetai_ID") & "'").FirstOrDefault()
            row("isUsed") = False

            Dim myview1 As DataView
            myview1 = dtPropertyList.DefaultView
            myview1.RowFilter = "isUsed = 0"
            grdPropertyList.DataSource = myview1
            grdPropertyList.DataBind()
            grdPropertyList.SelectedIndex = -1

            For i As Integer = 0 To dtForRepair.Rows.Count - 1
                If grdPreRepair.SelectedDataKey("PropertyDetai_ID") = dtForRepair.Rows(i)("PropertyDetai_ID") Then
                    dtForRepair.Rows.Remove(dtForRepair.Rows(i))
                    Exit For
                End If
            Next
            grdPreRepair.DataSource = dtForRepair
            grdPreRepair.DataBind()
            grdPreRepair.SelectedIndex = -1

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            For i As Integer = 0 To grdPreRepair.Rows.Count - 1
                If CType(grdPreRepair.Rows(i).FindControl("txtNatureScope"), TextBox).Text = "" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Nature and scope of work to be done is required.")
                    Exit Sub
                End If
            Next

            If drpApprovedBy.SelectedItem.Text = "Select" Or drpApprovedBy_GSO.SelectedItem.Text = "Select" Or drpInspectedby.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select all signatories to proceed.")

            Else
                objDerived.Execute("INSERT INTO [AMS].[tbl_Repairs_Hdr] ([repair_date],[RC_ID],[Function_ID],[GA_ID],[BGA_ID],[gso_inspection],[requestedby],[inspectedby],[approvedby],[gso_approvedby]) " &
                                  "  VALUES                                                     " &
                                  "  ('" & CType(txtDate.Text, Date) & "'                       " &
                                  "  ,'" & drpDepartment.SelectedItem.Value & "'               " &
                                  "  ,'" & drpFunction.SelectedItem.Value & "'                 " &
                                  "  ,'" & drpGenAccount.SelectedItem.Value & "'                " &
                                  "  ,0                                                         " &
                                  "  ,'" & replaceapostrophe(txtGSOInspector.Text) & "'         " &
                                  "  ,'" & drpRequestedby.SelectedItem.Value & "'               " &
                                  "  ,'" & drpInspectedby.SelectedItem.Value & "'               " &
                                  "  ,'" & drpApprovedBy.SelectedItem.Value & "'                " &
                                  "  ,'" & drpApprovedBy_GSO.SelectedItem.Value & "')", CommandType.Text)

                Session("repair_hdr_id") = objDerived.GetValue("SELECT TOP(1) [repair_hdr_id] FROM [AMS].[tbl_Repairs_Hdr] ORDER BY [repair_hdr_id] DESC", CommandType.Text)


                For i As Integer = 0 To dtForRepair.Rows.Count - 1
                    objDerived.Execute("INSERT INTO [AMS].[tbl_Repairs_Dtl] ([repair_hdr_id],[PropertyDetai_ID],[nature_scope],[previous_scope],[repair_cost]) " &
                                       " VALUES                             " &
                                       " ('" & Session("repair_hdr_id") & "'             " &
                                       " ,'" & dtForRepair.Rows(i)("PropertyDetai_ID") & "'         " &
                                       " ,'" & replaceapostrophe(CType(grdPreRepair.Rows(i).FindControl("txtNatureScope"), TextBox).Text) & "'    " &
                                       " ,'" & replaceapostrophe(CType(grdPreRepair.Rows(i).FindControl("txtPreviousScope"), TextBox).Text) & "'   " &
                                       " ,0)", CommandType.Text)
                Next


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                txtGSOInspector.Text = ""
                txtGSOInspector.Enabled = False

                drpRequestedby.Enabled = False
                drpInspectedby.Enabled = False
                drpApprovedBy.Enabled = False
                drpApprovedBy_GSO.Enabled = False

                btnSave.Enabled = False
                btnPreview.Enabled = True

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Report") = "PreRepair"
        Session("Page") = "PreRepair"

        Me.Page.Response.Redirect("~/MainReports/RepairReports.aspx")
    End Sub


End Class
