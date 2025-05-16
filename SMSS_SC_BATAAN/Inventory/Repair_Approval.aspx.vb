Imports System
Imports System.Data

Partial Class Inventory_Repair_Approval
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal


    Private Property dtPrerepairList() As DataTable
        Get
            Return CType(Session("dtPrerepairList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPrerepairList") = value
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
    Public Function dtTemp_PrerepairList(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn


        dt.Columns.Add("repair_hdr_id", GetType(Integer))
        dt.Columns.Add("repair_date", GetType(Date))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("GA_Code2", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("repair_hdr_id") = DBNull.Value
            dr("repair_date") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("GA_Code2") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function dtTemp_PropertyList(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn

        dt.Columns.Add("PropertyDetai_ID", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("previous_scope", GetType(String))
        dt.Columns.Add("nature_scope", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("previous_scope") = DBNull.Value
            dr("nature_scope") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub Inventory_Repair_Approval_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then

            LoadTabs()

        End If

        txtPreRepair_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnPreRepair_Search.ClientID & "')")

    End Sub

    Protected Sub LoadTabs()
        Try
            If btnTab1_PreRepair.CssClass = "TabButton_Active" And btnTab2_RepairCard.CssClass = "TabButton_InActive" Then

                dtPrerepairList = objDerived.GetDataTable("EXEC [AMS].[sp_repair_approval] 'Prerepair'", CommandType.Text)
                If dtPrerepairList.Rows.Count < 5 Then
                    dtPrerepairList.Merge(dtTemp_PrerepairList(4 - dtPrerepairList.Rows.Count))
                End If
                grdPreRepairList.DataSource = dtPrerepairList
                grdPreRepairList.DataBind()
                grdPreRepairList.SelectedIndex = -1

                grdPropertyList.DataSource = dtTemp_PropertyList(4)
                grdPropertyList.DataBind()

                btnApproved_Prerepair.Enabled = False
                btnCancel_Prerepair.Enabled = False


                mvTabs.SetActiveView(Me.vwTab1_PreRepair)

            ElseIf btnTab1_PreRepair.CssClass = "TabButton_InActive" And btnTab2_RepairCard.CssClass = "TabButton_Active" Then
                ' "RepairCard"
                mvTabs.SetActiveView(Me.vwTab2_RepairCard)
            Else


            End If



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub

    Private Sub btnTab1_PreRepair_Click(sender As Object, e As EventArgs) Handles btnTab1_PreRepair.Click
        btnTab1_PreRepair.CssClass = "TabButton_Active"
        btnTab2_RepairCard.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub

    Private Sub btnTab2_RepairCard_Click(sender As Object, e As EventArgs) Handles btnTab2_RepairCard.Click
        btnTab1_PreRepair.CssClass = "TabButton_InActive"
        btnTab2_RepairCard.CssClass = "TabButton_Active"

        LoadTabs()
    End Sub







    '----------------------------------------------------------------------------
    ' --- PRE REPAIR INSPECTION
    '----------------------------------------------------------------------------
    Private Sub btnPreRepair_Search_Click(sender As Object, e As EventArgs) Handles btnPreRepair_Search.Click
        Dim myview As DataView
        myview = dtPrerepairList.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(btnPreRepair_Search.Text) & "%'"
        grdPreRepairList.DataSource = myview
        grdPreRepairList.DataBind()
    End Sub


    Private Sub grdPreRepairList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPreRepairList.PageIndexChanging
        grdPreRepairList.DataSource = dtPrerepairList
        grdPreRepairList.PageIndex = e.NewPageIndex
        grdPreRepairList.DataBind()

    End Sub

    Private Sub grdPreRepairList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPreRepairList.SelectedIndexChanged
        Try
            dtPropertyList = objDerived.GetDataTable("SELECT E.Item_Desc, C.PropertyNo, C.SerialNo, B.previous_scope, B.nature_scope, B.PropertyDetai_ID " &
                                                                  "  FROM AMS.tbl_Repairs_Hdr AS A                                                                   " &
                                                                  "  INNER JOIN AMS.tbl_Repairs_Dtl AS B ON A.repair_hdr_id = B.repair_hdr_id                        " &
                                                                  "  INNER JOIN AMS.Property_Dtl AS C ON B.PropertyDetai_ID = C.PropertyDetai_ID                     " &
                                                                  "  INNER JOIN AMS.Property AS D ON C.Property_ID = D.Property_ID                                   " &
                                                                  "  INNER JOIN AMS.View_ItemList AS E ON D.Item_ID = E.Item_ID                                      " &
                                                                  "  WHERE A.repair_hdr_id = '" & grdPreRepairList.SelectedDataKey("repair_hdr_id") & "'             " &
                                                                  "  ORDER BY E.Item_Desc", CommandType.Text)

            grdPropertyList.DataSource = dtPropertyList
            grdPropertyList.DataBind()

            btnPreview1.Enabled = True
            btnApproved_Prerepair.Enabled = True
            btnCancel_Prerepair.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnApproved_Prerepair_Click(sender As Object, e As EventArgs) Handles btnApproved_Prerepair.Click
        Try
            Dim RepairNo As String = objDerived.GetValue("SELECT [dbo].[func_Generate_RepairNo] ('" & grdPreRepairList.SelectedDataKey("repair_date") & "')", CommandType.Text)
            objDerived.Execute("UPDATE [AMS].[tbl_Repairs_Hdr] SET [repair_card_number] = '" & RepairNo & "' WHERE [repair_hdr_id] = '" & grdPreRepairList.SelectedDataKey("repair_hdr_id") & "'", CommandType.Text)

            objDerived.Execute("UPDATE AMS.tbl_Repairs_Hdr SET isApproved = 1, ApprovedDate = '" & Date.Today.ToShortDateString & "' WHERE repair_hdr_id = '" & grdPreRepairList.SelectedDataKey("repair_hdr_id") & "'", CommandType.Text)

            For i As Integer = 0 To dtPropertyList.Rows.Count - 1
                objDerived.Execute("UPDATE AMS.Property_Dtl SET Repair = 1 WHERE PropertyDetai_ID = '" & dtPropertyList.Rows(i)("PropertyDetai_ID") & "'", CommandType.Text)
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Pre-repair inspection has been successfully approved.")
            LoadTabs()

            txtRepairNo.Text = RepairNo
            ModalPopupExtender1.Show()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnCancel_Prerepair_Click(sender As Object, e As EventArgs) Handles btnCancel_Prerepair.Click
        Try
            objDerived.Execute("UPDATE AMS.tbl_Repairs_Hdr SET isCancelled = 1, CancelledDate = '" & Date.Today.ToShortDateString & "' WHERE repair_hdr_id = '" & grdPreRepairList.SelectedDataKey("repair_hdr_id") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Pre-repair inspection has been successfully cancelled.")
            LoadTabs()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub


    Protected Sub btnPreview1_Click(sender As Object, e As EventArgs) Handles btnPreview1.Click
        Session("Report") = "PreRepair"
        Session("Page") = "PreRepairReportPreview"
        Session("repair_hdr_id") = grdPreRepairList.SelectedDataKey("repair_hdr_id")

        Me.Page.Response.Redirect("~/MainReports/RepairReports.aspx")
    End Sub
End Class
