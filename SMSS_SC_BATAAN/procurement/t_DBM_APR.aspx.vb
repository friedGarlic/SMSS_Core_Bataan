Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class procurement_t_DBM_APR
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim SaveAPR As New DBM_APR

#Region "property"
    Private dtAPR As DataTable
    Public Property APR() As DataTable
        Get
            Return dtAPR
        End Get
        Set(ByVal value As DataTable)
            dtAPR = value
        End Set
    End Property

    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property


    Private Property dtAPRItems() As DataTable
        Get
            Return CType(Session("dtAPRItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAPRItems") = value
        End Set
    End Property

    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property

    Private Property APR_ReportList() As DataTable
        Get
            Return CType(Session("APR_ReportList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("APR_ReportList") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            Dim rolename As String = role(0)

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtAPR = objDerived.GetDataTable("SELECT *, Convert(bit,1) AS isVisible FROM AMS.DBM_PR WHERE Year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
            If dtAPR.Rows.Count < 4 Then
                dtAPR.Merge(Createdatatable1(3 - dtAPR.Rows.Count))
            End If
            grdAPR.DataSource = dtAPR
            grdAPR.DataBind()

            grdItems.DataSource = Nothing
            grdItems.DataBind()

            dtAPRItems = Nothing
            grdAPRItems.DataSource = Createdatatable2(5)
            grdAPRItems.DataBind()

            APR_ReportList = objDerived.GetDataTable("SELECT * FROM [dbo].[View_APR_ReportList] WHERE Year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
            grdAPRList.DataSource = APR_ReportList
            grdAPRList.DataBind()

        End If
    End Sub

    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "View"

    End Sub

    Protected Sub grdAPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Lbtn = "View" Then
            '=== CHECK IF APR IS ALREADY CREATED
            Dim dt1 As New DataTable
            dt1 = objDerived.GetDataTable("SELECT * FROM [dbo].[View_APR_ReportList] WHERE Year = '" & grdAPR.SelectedDataKey("Year") & "' AND Quarter = '" & grdAPR.SelectedDataKey("Quarter") & "'", CommandType.Text)
            Dim QTR As String
            If grdAPR.SelectedDataKey("Quarter") = 1 Then
                QTR = "1ST"
            ElseIf grdAPR.SelectedDataKey("Quarter") = 2 Then
                QTR = "2ND"
            ElseIf grdAPR.SelectedDataKey("Quarter") = 3 Then
                QTR = "3RD"
            ElseIf grdAPR.SelectedDataKey("Quarter") = 4 Then
                QTR = "4TH"
            End If
            If dt1.Rows.Count <> 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Year " & grdAPR.SelectedDataKey("Year") & " APR for " & QTR & " quarter already exist.")
                Exit Sub
            End If

            grdItems.Columns(5).Visible = True

            dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_DBM_ItemList] '" & grdAPR.SelectedDataKey("DBM_ID") & "'", CommandType.Text)
            grdItems.DataSource = dtItems
            grdItems.DataBind()

            grdItems.Columns(5).Visible = False
            ModalPopupExtender2.Show()
        End If

    End Sub

    Protected Sub grdItems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdItems.Columns(5).Visible = True

        Me.grdItems.PageIndex = e.NewPageIndex
        Me.grdItems.DataSource = CType(dtItems, DataTable)
        Me.grdItems.DataBind()

        grdItems.Columns(5).Visible = False
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdItems.Columns(5).Visible = True

        Dim cb2 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb2.NamingContainer, GridViewRow)

        Dim dt As New DataTable
        dt = dtItems

        If cb2.Checked = True Then
            dtItems.Rows(Me.grdItems.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = True

        Else
            dtItems.Rows(Me.grdItems.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = False

        End If

        grdItems.Columns(5).Visible = False
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            grdItems.Columns(5).Visible = True

            Dim dt, dt_GA_ID As New DataTable
            Dim dr As DataRow
            'Dim cb As CheckBox

            If dtAPRItems Is Nothing Then
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("Unit", GetType(String))
                dt.Columns.Add("UnitPrice", GetType(Decimal))
                dt.Columns.Add("Qty", GetType(Integer))
                dt.Columns.Add("TotalCost", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Long))
                dt.Columns.Add("isVisible", GetType(Boolean))
                dt.Columns.Add("ID", GetType(Integer))

                For i As Integer = 0 To Me.dtItems.Rows.Count - 1
                    If dtItems.Rows(i)("isChecked") = True Then
                        dr = dt.NewRow
                        dr("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                        dr("Unit") = dtItems.Rows(i)("Unit")
                        dr("UnitPrice") = dtItems.Rows(i)("UnitPrice")
                        dr("Qty") = dtItems.Rows(i)("Qty")
                        dr("TotalCost") = dtItems.Rows(i)("TotalCost")
                        dr("Item_ID") = dtItems.Rows(i)("Item_ID")
                        dr("isVisible") = True
                        dr("ID") = 1
                        dt.Rows.Add(dr)

                        dtItems.Rows(i)("isUsed") = True
                        dtItems.Rows(i)("isChecked") = False
                    End If
                Next

                dtAPRItems = dt

            Else
                Dim dt2 As New DataTable
                Dim dr2 As DataRow

                dt.Columns.Add("id", GetType(Long))

                dt = dtAPRItems

                For i As Integer = 0 To Me.dtItems.Rows.Count - 1
                    If dtItems.Rows(i)("isChecked") = True Then
                        dr2 = dt.NewRow
                        dr2("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                        dr2("Unit") = dtItems.Rows(i)("Unit")
                        dr2("UnitPrice") = dtItems.Rows(i)("UnitPrice")
                        dr2("Qty") = dtItems.Rows(i)("Qty")
                        dr2("TotalCost") = dtItems.Rows(i)("TotalCost")
                        dr2("Item_ID") = dtItems.Rows(i)("Item_ID")
                        dr2("isVisible") = True
                        dr2("ID") = 1
                        dt.Rows.Add(dr2)
                        dtAPRItems = dt

                        dtItems.Rows(i)("isUsed") = True
                        dtItems.Rows(i)("isChecked") = False
                    End If
                Next

            End If

            grdAPRItems.DataSource = dtAPRItems
            grdAPRItems.DataBind()

            Dim myview As DataView
            myview = dtItems.DefaultView
            myview.RowFilter = "isUsed = false"
            grdItems.DataSource = myview
            grdItems.DataBind()

            '=== SUM ALL COST FOR GRIDVIEW FOOTER
            CType(grdAPRItems.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(dtAPRItems.Compute("sum(TotalCost)", ""), 2)

            grdItems.Columns(5).Visible = False

            btnSave.Enabled = True


            '=== DISPLAY SIGNATORIES
            txtGSO.Text = objDerived.GetValue("SELECT UPPER(full_name) FROM HRMS.view_signatory WHERE deptid = 7 AND division_key = 86 AND isDeptHead = 'YES'", CommandType.Text)
            txtAccounting.Text = objDerived.GetValue("SELECT UPPER(full_name) FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'YES'", CommandType.Text)
            txtMayor.Text = objDerived.GetValue("SELECT UPPER(full_name) FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'YES'", CommandType.Text)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtAvailableQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Decimal
        For i As Integer = 0 To grdAPRItems.Rows.Count - 1
            Dim txtUnitPrice As TextBox = CType(grdAPRItems.Rows(i).FindControl("txtUnitPrice"), TextBox)
            Dim txtAvailableQty As TextBox = CType(grdAPRItems.Rows(i).FindControl("txtAvailableQty"), TextBox)

            CType(grdAPRItems.Rows(i).FindControl("lblTotalCost"), Label).Text = FormatNumber(txtUnitPrice.Text * txtAvailableQty.Text, 2)
            x = x + (txtUnitPrice.Text * txtAvailableQty.Text)
        Next

        CType(grdAPRItems.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

    End Sub

    Protected Sub txtUnitPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtUnitPrice As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtUnitPrice.NamingContainer, GridViewRow)
        txtUnitPrice.Text = FormatNumber(txtUnitPrice.Text, 2)

        Dim x As Decimal
        For i As Integer = 0 To grdAPRItems.Rows.Count - 1
            txtUnitPrice = CType(grdAPRItems.Rows(i).FindControl("txtUnitPrice"), TextBox)
            Dim txtAvailableQty As TextBox = CType(grdAPRItems.Rows(i).FindControl("txtAvailableQty"), TextBox)

            CType(grdAPRItems.Rows(i).FindControl("lblTotalCost"), Label).Text = FormatNumber(txtUnitPrice.Text * txtAvailableQty.Text, 2)
            x = x + (txtUnitPrice.Text * txtAvailableQty.Text)

        Next

        CType(grdAPRItems.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            For i As Integer = 0 To grdAPRItems.Rows.Count - 1
                With SaveAPR
                    .APR_Date = txtDate.Text
                    .APR_Year = Year(CDate(txtDate.Text))
                    .APR_Quarter = grdAPR.SelectedDataKey("Quarter")
                    .Item_ID = dtAPRItems.Rows(i)("Item_ID")
                    .Quantity = CType(grdAPRItems.Rows(i).FindControl("txtAvailableQty"), TextBox).Text
                    .UnitPrice = CType(grdAPRItems.Rows(i).FindControl("txtUnitPrice"), TextBox).Text
                    .Mayor = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'YES'", CommandType.Text)
                    .Accountant = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'YES'", CommandType.Text)
                    .PropertyOfficer = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 7 AND division_key = 86 AND isDeptHead = 'YES'", CommandType.Text)
                    .DBM_ID = grdAPR.SelectedDataKey("DBM_ID")
                    .save()
                End With
            Next

            Session("DBM_ID") = grdAPR.SelectedDataKey("DBM_ID")
            Session("Year") = grdAPR.SelectedDataKey("Year")
            Session("Quarter") = grdAPR.SelectedDataKey("Quarter")

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            btnSave.Enabled = False
            btnPreview.Enabled = True

            grdAPRList.DataSource = Nothing 'objDerived.GetDataTable("", CommandType.Text)
            grdAPRList.DataBind()

            '=== CLEAR DATA AFTER SAVING
            grdAPRItems.DataSource = Createdatatable2(5)
            grdAPRItems.DataBind()

            txtGSO.Text = ""
            txtAccounting.Text = ""
            txtMayor.Text = ""

            APR_ReportList = objDerived.GetDataTable("SELECT * FROM [dbo].[View_APR_ReportList] WHERE Year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
            grdAPRList.DataSource = APR_ReportList
            grdAPRList.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/procurement/rpt_ARP.aspx")
    End Sub

    Public Function Createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Year", GetType(Integer))
        dt.Columns.Add("Quarter", GetType(Integer))
        dt.Columns.Add("TotalAmount", GetType(Decimal))
        dt.Columns.Add("DBM_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Year") = DBNull.Value
            dr("Quarter") = DBNull.Value
            dr("TotalAmount") = DBNull.Value
            dr("DBM_ID") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function Createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("UnitPrice", GetType(Decimal))
        dt.Columns.Add("TotalCost", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("UnitPrice") = DBNull.Value
            dr("TotalCost") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub lnkView_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Preview"
    End Sub

    Protected Sub grdAPRList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("DBM_ID") = grdAPRList.SelectedDataKey("DBM_ID")
        Session("Year") = grdAPRList.SelectedDataKey("Year")
        Session("Quarter") = grdAPRList.SelectedDataKey("Quarter")

        If Lbtn = "Preview" Then
            Me.Page.Response.Redirect("~/procurement/rpt_ARP.aspx")
        End If
    End Sub
End Class
