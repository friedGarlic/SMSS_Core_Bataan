Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports AjaxControlToolkit

Partial Class t_abstract_of_bids
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private hdr As New Disposal_bid_hdr
    Private dtl As New Disposal_bid_dtl
    Dim msg As New MsgeBox
    Private objDerived As New DerivedDal

#Region "property"
    Private Property pnew() As DataTable
        Get
            Return CType(Session("pnew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pnew") = value
        End Set
    End Property

    Private Property dtSupp() As DataTable
        Get
            Return CType(Session("dtSupp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSupp") = value
        End Set
    End Property

    Private Property dtSuppItems() As DataTable
        Get
            Return CType(Session("dtSuppItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtSuppItems") = value
        End Set
    End Property

    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property
    Private Property pgvwinners() As DataTable
        Get
            Return CType(Session("pgvwinners"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pgvwinners") = value
        End Set
    End Property
    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property
    Private Property pSuppliers() As DataTable
        Get
            Return CType(Session("pSuppliers"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pSuppliers") = value
        End Set
    End Property
#End Region
#Region "Procedures"
    Public Sub GvCustomers_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hovermenu As HoverMenuExtender
            hovermenu = e.Row.FindControl("hoverMenu")
            e.Row.ID = e.Row.RowIndex.ToString
            hovermenu.TargetControlID = e.Row.ID
        End If

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                obj.GetAccessRight(Me.Session("@UserName"), Page)
                If obj.HasAccess = False Then
                    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
                End If

                Session("view") = "1"
                txtcanvassdate.Text = Date.Today.ToString("MM/dd/yyyy")

                rbChoice.SelectedItem.Value = 1
                LoadrbChoice()

            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            ddSupplier.Enabled = False

            '=== AMS.Disposal_Bid_hdr
            Dim HdrID As Long
            hdr.quotation_hdr_id = gvnew.SelectedDataKey(0)
            hdr.Disposal_id = gvnew.SelectedDataKey(1)
            hdr.BidDate = txtcanvassdate.Text
            hdr.BidNo = txtcanvass.Text
            hdr.awarddate = "01/01/1900"
            HdrID = hdr.save

            Session("Disposal_ID") = HdrID
            objDerived.GetRecords("Update AMS.Disposal_quotation_hdr set withBID=1 where quotation_hdr_id=" & gvnew.SelectedDataKey(0) & "", CommandType.Text)

            '=== AMS.Disposal_Bid_dtl
            Dim id1 As Long
            id1 = objDerived.GetValue("SELECT quotation_Lot_ID FROM AMS.Disposal_quotation_Lot WHERE quotation_hdr_id = '" & gvnew.SelectedDataKey("quotation_hdr_id") & "'", CommandType.Text)
            If id1 = 0 Then
                '=== PER ITEMS
                'Me.mvQuot.SetActiveView(Me.vwItems)
                For o As Integer = 0 To pSuppliers.Rows.Count - 1
                    pgvwinners = objDerived.GetDataTable("exec AMS.loadAbstractBidsDetailPerSupplier " & gvnew.SelectedDataKey(0) & "," & pSuppliers.Rows(o)("Supplier_Id") & "", CommandType.Text)
                    For i As Integer = 0 To Me.pgvwinners.Rows.Count - 1
                        dtl.Disposal_Bid_hdr_id = HdrID
                        dtl.PropertyNo = pgvwinners.Rows(i)("PropertyNo")
                        dtl.Supplier_ID = pSuppliers.Rows(o)("Supplier_Id")
                        dtl.cost = pgvwinners.Rows(i)("Cost")
                        If ddSupplier.SelectedValue = pSuppliers.Rows(o)("Supplier_Id") Then
                            dtl.Is_Award = True
                        Else
                            dtl.Is_Award = False
                        End If
                        dtl.with_notice = False
                        dtl.save()
                    Next
                Next
                Session("Quotation") = "perItems"

            Else
                ''=== PER LOT
                Me.mvQuot.SetActiveView(Me.vwLot)
                For o As Integer = 0 To pSuppliers.Rows.Count - 1
                    dtl.Disposal_Bid_hdr_id = HdrID
                    dtl.PropertyNo = "Unserviceable Properties / Materials"
                    dtl.Supplier_ID = pSuppliers.Rows(o)("Supplier_Id")
                    dtl.cost = objDerived.GetValue("SELECT TotalAmount FROM [dbo].[View_Quotation_Suppliers] WHERE quotation_hdr_id = '" & gvnew.SelectedDataKey(0) & "' AND Supplier_Id = '" & pSuppliers.Rows(o)("Supplier_Id") & "'", CommandType.Text)
                    If ddSupplier.SelectedValue = pSuppliers.Rows(o)("Supplier_Id") Then
                        dtl.Is_Award = True
                    Else
                        dtl.Is_Award = False
                    End If
                    dtl.with_notice = False
                    dtl.save()
                Next

                Session("Quotation") = "perLOT"
            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanelbids, "Transaction has been successfully saved.")

            Me.btnSave.Enabled = False
            Me.btnPreview.Enabled = True
            txtcanvass.ReadOnly = True

            txtcanvassdate.ReadOnly = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvWinners_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvlist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim gvwin As GridView = TryCast(sender, GridView)
            Dim gvrow As GridViewRow = TryCast(gvwin.NamingContainer, GridViewRow)
            Me.gvWinners.Columns(6).Visible = True
            CType(Me.gvWinners.Rows(gvrow.RowIndex).Cells(4).FindControl("lblprice"), Label).Text = String.Format("{0:N}", gvwin.SelectedDataKey(1))
            CType(Me.gvWinners.Rows(gvrow.RowIndex).Cells(6).FindControl("lblsuppid"), Label).Text = gvwin.SelectedDataKey(2)
            Dim txt As TextBox = CType(Me.gvWinners.Rows(gvrow.RowIndex).Cells(3).FindControl("TextBox1"), TextBox)
            txt.Text = gvwin.SelectedDataKey(0)
            Me.gvWinners.Columns(6).Visible = False
            btnSave.Enabled = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function convertToCurrency(ByVal value As String) As String
        Dim converted As String = ""
        Try
            converted = FormatNumber(CType(value, Decimal), 2)
        Catch ex As Exception

        End Try
        Return converted
    End Function

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")
    End Sub

    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvnew.SelectedIndexChanged
        Try
            pSuppliers = objDerived.GetDataTable("exec ams.BIDSuppliers " & gvnew.SelectedDataKey(0) & "", CommandType.Text)
            Dim obj As Object
            obj = True
            ddSupplier.DataSource = pSuppliers
            ddSupplier.DataTextField = "SuppName"
            ddSupplier.DataValueField = "Supplier_Id"
            ddSupplier.DataBind()


            Dim id1 As Long
            id1 = objDerived.GetValue("SELECT quotation_Lot_ID FROM AMS.Disposal_quotation_Lot WHERE quotation_hdr_id = '" & gvnew.SelectedDataKey("quotation_hdr_id") & "'", CommandType.Text)

            If id1 = 0 Then
                Me.mvQuot.SetActiveView(Me.vwItems)

                pgvwinners = Nothing
                pgvwinners = objDerived.GetDataTable("exec AMS.loadAbstractBidsDetail " & gvnew.SelectedDataKey(0) & "", CommandType.Text)
                gvWinners.DataSource = pgvwinners
                gvWinners.DataBind()

                ddSupplier.SelectedValue = pgvwinners.Rows(0)("Supplier_Id")
                gvWinners.FooterRow.Cells(2).Text = FormatNumber(pgvwinners.Compute("sum(cost)", ""), 2)

            Else
                Me.mvQuot.SetActiveView(Me.vwLot)

                pgvwinners = Nothing
                pgvwinners = objDerived.GetDataTable("EXEC [AMS].[sp_Quotation_LotItems] '" & gvnew.SelectedDataKey(0) & "'", CommandType.Text)
                grdLotItems.DataSource = pgvwinners
                grdLotItems.DataBind()

                Dim dt As New DataTable
                dt = objDerived.GetDataTable("SELECT TOP(1)* FROM [dbo].[View_Quotation_Suppliers] WHERE quotation_hdr_id = '" & gvnew.SelectedDataKey(0) & "' ORDER BY TotalAmount DESC", CommandType.Text)

                txtAmount.Text = FormatNumber(dt.Rows(0)("TotalAmount"), 2) 'FormatNumber(dt.Rows(0)("TotalAmount"), 2)
                ddSupplier.SelectedValue = dt.Rows(0)("Supplier_Id")

            End If

            txtPRno.Text = gvnew.SelectedDataKey(3)
            txtcanvass.ReadOnly = False
            txtcanvass.Text = ""

            btnPreview.Enabled = False
            btnSave.Enabled = True
            ddSupplier.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub gvnew_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvnew.PageIndexChanging
        Me.gvnew.PageIndex = e.NewPageIndex
        Me.gvnew.DataSource = CType(pnew, DataTable)
        Me.gvnew.DataBind()
        gvnew.SelectedIndex = -1

    End Sub

    Protected Sub DDSUPPLIER_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddSupplier.SelectedIndexChanged
        LoadBidders()
    End Sub

    Protected Sub LoadBidders()
        If rbChoice.SelectedItem.Value = 1 Then
            Dim id1 As Long
            id1 = objDerived.GetValue("SELECT quotation_Lot_ID FROM AMS.Disposal_quotation_Lot WHERE quotation_hdr_id = '" & gvnew.SelectedDataKey("quotation_hdr_id") & "'", CommandType.Text)

            If id1 = 0 Then
                Me.mvQuot.SetActiveView(Me.vwItems)

                pgvwinners = objDerived.GetDataTable("exec AMS.loadAbstractBidsDetailPerSupplier " & gvnew.SelectedDataKey(0) & "," & ddSupplier.SelectedValue & "", CommandType.Text)
                gvWinners.DataSource = pgvwinners
                gvWinners.DataBind()

                gvWinners.FooterRow.Cells(2).Text = FormatNumber(pgvwinners.Compute("sum(Cost)", ""), 2)

            Else
                Me.mvQuot.SetActiveView(Me.vwLot)

                pgvwinners = Nothing
                pgvwinners = objDerived.GetDataTable("EXEC [AMS].[sp_Quotation_LotItems] '" & gvnew.SelectedDataKey(0) & "'", CommandType.Text)
                grdLotItems.DataSource = pgvwinners
                grdLotItems.DataBind()

                Dim bidAmount As Decimal
                bidAmount = objDerived.GetValue("SELECT TotalAmount FROM [dbo].[View_Quotation_Suppliers] WHERE Supplier_Id = '" & ddSupplier.SelectedValue & "' AND quotation_hdr_id = '" & gvnew.SelectedDataKey(0) & "'", CommandType.Text)

                txtAmount.Text = FormatNumber(bidAmount, 2)
                Session("TotalBid") = FormatNumber(bidAmount, 2)
            End If

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_USupplies_Items] WHERE IIRUS_ID = '" & grdSupplies.SelectedDataKey("IIRUS_ID") & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
            grdSupply.DataSource = dt
            grdSupply.DataBind()

            grdSupply.FooterRow.Cells(3).Text = FormatNumber(dt.Compute("sum(TotalAmount)", ""), 2)

        End If
    End Sub


    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        txtPRno.Text = ""
        txtcanvass.Text = ""
        ddSupplier.SelectedItem.Text = "Select"

        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwProperty)
            Session("rbChoice") = 1
            'Panel2.GroupingText = "PROPERTY LIST OF TRANSACTION"

            pnew = Nothing
            pnew = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_AbstractBids_Prop]", CommandType.Text)
            gvnew.DataSource = CType(pnew, DataTable)
            gvnew.DataBind()

            gvWinners.DataSource = Nothing
            gvWinners.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwSupply)
            Session("rbChoice") = 2

            dtSupp = Nothing
            'dtSupp = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_AbstractBids_Supp]", CommandType.Text)
            dtSupp = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_AbstractBids_Supp]", CommandType.Text)
            grdSupplies.DataSource = dtSupp
            grdSupplies.DataBind()

            grdSupply.DataSource = Nothing
            grdSupply.DataBind()

        End If
    End Sub


    Protected Sub btnSaveSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        objDerived.GetRecords("UPDATE AMS.Disposal_Supplies_Hdr SET isWinner = 1, Canvass_No = '" & txtcanvass.Text & "' WHERE IIRUS_ID = '" & grdSupplies.SelectedDataKey("IIRUS_ID") & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Disposal_Supplies_Hdr SET isComplete  = 1 WHERE IIRUS_ID = '" & grdSupplies.SelectedDataKey("IIRUS_ID") & "'", CommandType.Text)

            Dim ApprovedBy As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 1 AND division_key = 86", CommandType.Text)
            Dim City_GSO As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 7 AND division_key = 86", CommandType.Text)
            Dim City_Treasurer As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 10 AND division_key = 86", CommandType.Text)
            Dim City_Administrator As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 4 AND division_key = 86", CommandType.Text)
            Dim City_Budget As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 8 AND division_key = 86", CommandType.Text)
            Dim City_Accountant As String = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 9 AND division_key = 86", CommandType.Text)

            objDerived.GetRecords("UPDATE AMS.Disposal_Supplies_Hdr SET ApprovedBy = '" & ApprovedBy & "', City_GSO = '" & City_GSO & "', City_Treasurer = '" & City_Treasurer & "', City_Administrator = '" & City_Administrator & "', City_Budget = '" & City_Budget & "', City_Accountant = '" & City_Accountant & "' WHERE IIRUS_ID = '" & grdSupplies.SelectedDataKey("IIRUS_ID") & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)


        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanelbids, "Transaction has been successfully saved.")
        LoadrbChoice()

        btnPreviewSupp.Enabled = True
    End Sub

    Protected Sub btnPreviewSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_abstract_of_bids.aspx")
    End Sub

    Protected Sub grdSupplies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPRno.Text = grdSupplies.SelectedDataKey("Description")
        txtcanvass.ReadOnly = False
        txtcanvass.Text = ""

        Session("IIRUS_ID") = grdSupplies.SelectedDataKey("IIRUS_ID")

        pSuppliers = objDerived.GetDataTable("SELECT * FROM [dbo].[View_USupplies_Bidder] WHERE IIRUS_ID = '" & grdSupplies.SelectedDataKey("IIRUS_ID") & "' ORDER BY TotalAmount DESC", CommandType.Text)
        ddSupplier.DataSource = pSuppliers
        ddSupplier.DataTextField = "SuppName"
        ddSupplier.DataValueField = "Supplier_Id"
        ddSupplier.DataBind()
        ddSupplier.SelectedIndex = 0

        btnPreview.Enabled = False
        btnSaveSupp.Enabled = True
        ddSupplier.Enabled = True

        LoadBidders()

    End Sub
End Class


