Imports System.Data

Partial Class Inventory_RepairCard
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim obj As New AccessRule
    Private Property dtApprovedRepair() As DataTable
        Get
            Return CType(Session("dtApprovedRepair"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtApprovedRepair") = value
        End Set
    End Property
    Private Property dtProeprtyList() As DataTable
        Get
            Return CType(Session("dtProeprtyList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtProeprtyList") = value
        End Set
    End Property
    Public Function dtTemp_ApprovedRepair(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn


        dt.Columns.Add("repair_hdr_id", GetType(Integer))
        dt.Columns.Add("repair_date", GetType(Date))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("GA_Code2", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("repair_hdr_id") = DBNull.Value
            dr("repair_date") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("GA_Code2") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function dtTemp_PropertyList(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn
        dt.Columns.Add("repair_hdr_id", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("PropertyDetai_ID", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("previous_scope", GetType(String))
        dt.Columns.Add("nature_scope", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("repair_hdr_id") = DBNull.Value
            dr("isVisible") = False
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

    Public Function tempItemList(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("prerepair_dtl_id", GetType(Integer))
        dt.Columns.Add("prerepair_hdr_id", GetType(Integer))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("ItemDesc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("prerepair_date", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("nature_scope", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("PropertyDetai_ID") = DBNull.Value
            dr("prerepair_dtl_id") = DBNull.Value
            dr("prerepair_hdr_id") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("ItemDesc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("prerepair_date") = DBNull.Value
            dr("isVisible") = False
            dr("nature_scope") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_RepairCard_Load(sender As Object, e As EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then

            LoadPage()

        End If

        'txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        'drpDept.Attributes.Add("onChange", "StartProgressBar();")


    End Sub

    Protected Sub LoadPage()

        dtApprovedRepair = objDerived.GetDataTable("EXEC [AMS].[sp_repair_approval] 'RepairCard'", CommandType.Text)
        If dtApprovedRepair.Rows.Count < 5 Then
            dtApprovedRepair.Merge(dtTemp_ApprovedRepair(4 - dtApprovedRepair.Rows.Count))
        End If
        grdApprovedRepair.DataSource = dtApprovedRepair
        grdApprovedRepair.DataBind()
        grdApprovedRepair.SelectedIndex = -1

        grdPropertyList.DataSource = dtTemp_PropertyList(4)
        grdPropertyList.DataBind()

        LoadSearchBy()

        txtDate.Text = ""

        txtRepairCost.Text = "0.00"

    End Sub
    Private Sub drpSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpSearchBy.SelectedIndexChanged
        LoadSearchBy()
    End Sub
    Private Sub LoadSearchBy()
        If drpSearchBy.SelectedItem.Value = 1 Then
            drpSearch.DataSource = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM DBO.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpSearch.DataTextField = "RC_Name"
            drpSearch.DataValueField = "RC_ID"
            drpSearch.DataBind()
            drpSearch.Items.Insert(0, "Select")
        Else
            drpSearch.DataSource = objDerived.GetDataTable("SELECT GA_Title, GA_Code2 FROM AMS.View_AccountList WHERE AllotmentClass_ID = 3 AND BGA_ID = 0 ORDER BY GA_Title", CommandType.Text)
            drpSearch.DataTextField = "GA_Title"
            drpSearch.DataValueField = "GA_Code2"
            drpSearch.DataBind()
            drpSearch.Items.Insert(0, "Select")
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtApprovedRepair.DefaultView

        If drpSearchBy.SelectedItem.Value = 1 Then
            myview.RowFilter = "RC_ID = '" & drpSearch.SelectedItem.Value & "'"
        Else
            myview.RowFilter = "GA_Code2  = '" & drpSearch.SelectedItem.Value & "'"
        End If

        grdApprovedRepair.DataSource = myview
        grdApprovedRepair.DataBind()
    End Sub


    Private Sub txtRepairCost_TextChanged(sender As Object, e As EventArgs) Handles txtRepairCost.TextChanged
        txtRepairCost.Text = FormatNumber(txtRepairCost.Text)
    End Sub


    Private Sub grdApprovedRepair_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApprovedRepair.PageIndexChanging
        grdApprovedRepair.DataSource = dtApprovedRepair
        grdApprovedRepair.PageIndex = e.NewPageIndex
        grdApprovedRepair.DataBind()
    End Sub

    Private Sub grdApprovedRepair_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApprovedRepair.SelectedIndexChanged
        Try

            dtProeprtyList = objDerived.GetDataTable("SELECT a.repair_hdr_id,E.Item_Desc, C.PropertyNo, C.SerialNo, B.previous_scope, B.nature_scope, B.PropertyDetai_ID, CONVERT(BIT,1) AS isVisible " &
                                                                  "  FROM AMS.tbl_Repairs_Hdr AS A                                                                   " &
                                                                  "  INNER JOIN AMS.tbl_Repairs_Dtl AS B ON A.repair_hdr_id = B.repair_hdr_id                        " &
                                                                  "  INNER JOIN AMS.Property_Dtl AS C ON B.PropertyDetai_ID = C.PropertyDetai_ID                     " &
                                                                  "  INNER JOIN AMS.Property AS D ON C.Property_ID = D.Property_ID                                   " &
                                                                  "  INNER JOIN AMS.View_ItemList AS E ON D.Item_ID = E.Item_ID                                      " &
                                                                  "  WHERE A.repair_hdr_id = '" & grdApprovedRepair.SelectedDataKey("repair_hdr_id") & "' and isnull(b.repair_card_date,0) = 0           " &
                                                                  "  ORDER BY E.Item_Desc", CommandType.Text)
            grdPropertyList.DataSource = dtProeprtyList
            grdPropertyList.DataBind()


            txtDate.Text = Date.Today.ToShortDateString
            'txtRepairNo.Text = CType(Year(Date.Today.ToShortDateString), String) & "-"

            btnSave.Enabled = False
            btnPreview.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            Dim a2 = objDerived.GetValue("SELECT count(B.PropertyDetai_ID) " &
                  "  FROM AMS.tbl_Repairs_Hdr AS A                                                                   " &
                  "  INNER JOIN AMS.tbl_Repairs_Dtl AS B ON A.repair_hdr_id = B.repair_hdr_id                        " &
                  "  INNER JOIN AMS.Property_Dtl AS C ON B.PropertyDetai_ID = C.PropertyDetai_ID                     " &
                  "  INNER JOIN AMS.Property AS D ON C.Property_ID = D.Property_ID                                   " &
                  "  INNER JOIN AMS.View_ItemList AS E ON D.Item_ID = E.Item_ID                                      " &
                  "  WHERE A.repair_hdr_id = '" & grdApprovedRepair.SelectedDataKey("repair_hdr_id") & "' and isnull(b.repair_card_date,0) = 0 ", CommandType.Text)


            If txtRepairCost.Text = "" Or txtRepairCost.Text = "0.00" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Input datails For required fields.")
                Exit Sub
            End If

            If a2 = 1 Then
                objDerived.Execute("UPDATE [AMS].[tbl_Repairs_Hdr] Set [isRepairApproved] = 1 WHERE [repair_hdr_id] = '" & grdApprovedRepair.SelectedDataKey("repair_hdr_id") & "'", CommandType.Text)


                objDerived.Execute("UPDATE [AMS].[tbl_Repairs_Dtl] SET [repair_card_date] = '" & txtDate.Text & "', repair_cost = '" & CType(txtRepairCost.Text, Decimal) & "'  WHERE PropertyDetai_ID = '" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "' and repair_hdr_id = '" & grdPropertyList.SelectedDataKey("repair_hdr_id") & "'", CommandType.Text)
                objDerived.Execute("UPDATE [AMS].[Property_Dtl] SET Repair = 0 WHERE PropertyDetai_ID = '" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            Else
                objDerived.Execute("UPDATE [AMS].[tbl_Repairs_Dtl] SET [repair_card_date] = '" & txtDate.Text & "'  , repair_cost = '" & CType(txtRepairCost.Text, Decimal) & "'  WHERE PropertyDetai_ID = '" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "'and repair_hdr_id = '" & grdPropertyList.SelectedDataKey("repair_hdr_id") & "'", CommandType.Text)
                objDerived.Execute("UPDATE [AMS].[Property_Dtl] SET Repair = 0 WHERE PropertyDetai_ID = '" & grdPropertyList.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


            End If
            btnSave.Enabled = False
            btnPreview.Enabled = True
            LoadPage()





        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Page") = "RepairCard"
        Session("Report") = "RepairCard"
        Me.Page.Response.Redirect("~/MainReports/RepairReports.aspx")
    End Sub

    Protected Sub btnSelect_Click(sender As Object, e As EventArgs)
        Session("Action") = "Select"
    End Sub
    Protected Sub btnPreview2_Click(sender As Object, e As EventArgs)
        Session("Action") = "Preview2"
    End Sub
    Protected Sub grdPropertyList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPropertyList.SelectedIndexChanged
        If Session("Action") = "Select" Then
            txtDate.Enabled = True
            txtRepairCost.Enabled = True
            btnSave.Enabled = True
        End If


        If Session("Action") = "Preview2" Then

            Session("Page") = "RepairCard"
            Session("Report") = "RepairCard"
            Session("PropertyDetai_ID") = grdPropertyList.SelectedDataKey("PropertyDetai_ID")
            Me.Page.Response.Redirect("~/MainReports/RepairReports.aspx")
        End If



    End Sub

End Class
