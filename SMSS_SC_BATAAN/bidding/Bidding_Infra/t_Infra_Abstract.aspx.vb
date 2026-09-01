Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data

Partial Class bidding_Bidding_Infra_t_Infra_Abstract
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private dtInfra As New DataTable

    Private Infra_Bidder_Hdr As New Bidding_Infra.tb_Infra_Bidder_Hdr
    Private Infra_Bidder_Dtl As New Bidding_Infra.tb_Infra_Bidder_Dtl

#Region "property"
    Private Property dtBidderItems() As DataTable
        Get
            Return CType(Session("dtBidderItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBidderItems") = value
        End Set
    End Property

#End Region
#Region "DataTable"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no")
        dt.Columns.Add("txtDescription")
        dt.Columns.Add("txtUnit")
        dt.Columns.Add("txtQty")

        For i As Integer = 1 To 15
            Dim x As String
            Select Case True
                Case (i = 1)
                    x = "I"
                Case (i = 2)
                    x = "II"
                Case (i = 3)
                    x = "III"
                Case (i = 4)
                    x = "IV"
                Case (i = 5)
                    x = "V"
                Case (i = 6)
                    x = "VI"
                Case (i = 7)
                    x = "VII"
                Case (i = 8)
                    x = "VIII"
                Case (i = 9)
                    x = "IX"
                Case (i = 10)
                    x = "X"
                Case (i = 11)
                    x = "XI"
                Case (i = 12)
                    x = "XII"
                Case (i = 13)
                    x = "XIII"
                Case (i = 14)
                    x = "XIV"
                Case (i = 15)
                    x = "XV"
                Case Else

            End Select

            dr = dt.NewRow
            dr("No") = x
            dr("txtDescription") = ""
            dr("txtUnit") = ""
            dr("txtQty") = ""
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("pre_procurement_dtl_id", GetType(Long))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("project_name", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("mode_of_procurement_id", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("Infra_Hdr_ID", GetType(Long))
        dt.Columns.Add("RC_ID", GetType(Long))
        dt.Columns.Add("Function_ID", GetType(Long))
        dt.Columns.Add("RC_Name", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pre_procurement_hdr_id") = DBNull.Value
            dr("pre_procurement_dtl_id") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("project_name") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("mode_of_procurement_id") = DBNull.Value
            dr("isVisible") = False
            dr("Infra_Hdr_ID") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadInfraList()

        End If
    End Sub

    Protected Sub LoadInfraList()
        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")
        dtInfra = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Abstract]", CommandType.Text)
        If dtInfra.Rows.Count < 5 Then
            dtInfra.Merge(CreateTable2(5 - dtInfra.Rows.Count))
        End If
        grdProjectList.DataSource = dtInfra
        grdProjectList.DataBind()

        grdBidders.DataSource = Nothing
        grdBidders.DataBind()

        drpBidderName.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
        drpBidderName.DataTextField = ("SuppName")
        drpBidderName.DataValueField = ("Supplier_ID")
        drpBidderName.DataBind()
        drpBidderName.Items.Insert(0, "Select")

        grdDetails.DataSource = Nothing
        grdDetails.DataBind()

    End Sub

    Protected Sub grdProjectList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Saving") = "New"
        LoadBidders()

        btnPreview.Enabled = False
    End Sub

    Protected Sub LoadBidders()
        grdBidders.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Bidders] '" & grdProjectList.SelectedDataKey("Infra_Hdr_ID") & "'", CommandType.Text)
        grdBidders.DataBind()

        If grdBidders.Rows.Count <> 0 Then
            '=== SIGNATORIES
            ddBACMember1.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 3", CommandType.Text)
            ddBACMember1.DataTextField = ("Name")
            ddBACMember1.DataValueField = ("empsig_id")
            ddBACMember1.DataBind()

            ddBACMember2.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 4", CommandType.Text)
            ddBACMember2.DataTextField = ("Name")
            ddBACMember2.DataValueField = ("empsig_id")
            ddBACMember2.DataBind()

            ddBACMember3.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5", CommandType.Text)
            ddBACMember3.DataTextField = ("Name")
            ddBACMember3.DataValueField = ("empsig_id")
            ddBACMember3.DataBind()

            ddBACVChair.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
            ddBACVChair.DataTextField = ("Name")
            ddBACVChair.DataValueField = ("empsig_id")
            ddBACVChair.DataBind()

            ddBACChair.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
            ddBACChair.DataTextField = ("Name")
            ddBACChair.DataValueField = ("empsig_id")
            ddBACChair.DataBind()

            ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 12", CommandType.Text)
            ddApprovedBy.DataTextField = ("Name")
            ddApprovedBy.DataValueField = ("empsig_id")
            ddApprovedBy.DataBind()

            ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid = '" & grdProjectList.SelectedDataKey("RC_ID") & "' AND division_key = '" & grdProjectList.SelectedDataKey("Function_ID") & "' ORDER BY full_name", CommandType.Text)
            ddPreparedBy.DataTextField = ("full_name")
            ddPreparedBy.DataValueField = ("empid")
            ddPreparedBy.DataBind()
            ddPreparedBy.Items.Insert(0, "Select")

            PanelSignatory.Visible = True
        End If

        grdDetails.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Abstract_Items] '" & grdProjectList.SelectedDataKey("Infra_Hdr_ID") & "'", CommandType.Text)
        grdDetails.DataBind()

        LoadClearTextFields()
        Session("Saving") = "New"
    End Sub

    Protected Sub txtBidAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtBidAmount As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtBidAmount.NamingContainer, GridViewRow)
            
            If txtBidAmount.Text = "" Then
                txtBidAmount.Text = 0
            End If

            txtBidAmount.Text = FormatNumber(txtBidAmount.Text, 2)

            Dim x As Decimal = 0
            For i As Integer = 0 To grdDetails.Rows.Count - 1
                Dim txtBidAmount1 As TextBox = CType(grdDetails.Rows(i).FindControl("txtBidAmount"), TextBox)
                x = txtBidAmount1.Text + x
            Next

            CType(grdDetails.FooterRow.Cells(4).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If drpBidderName.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select bidder name.")
                Exit Sub

            ElseIf txtTimeDuration.Text = "" Or txtBidSecurityForm.Text = "" Or txtBankCampany.Text = "" Or txtNumber.Text = "" Or txtValidityPeriod.Text = "" Or txtBidSecurityAmt.Text = "" Or txtRequiredBidSec.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                Exit Sub

            Else
                With Infra_Bidder_Hdr
                    .Supplier_ID = drpBidderName.SelectedItem.Value
                    .Total_Amount = CType(grdDetails.FooterRow.Cells(4).FindControl("lblTotalAmount"), Label).Text
                    .TimeDuration = txtTimeDuration.Text
                    .BidSecurity = txtBidSecurityForm.Text
                    .Bank_Campany = txtBankCampany.Text
                    .Number = txtNumber.Text
                    .ValidityPeriod = txtValidityPeriod.Text
                    .BidSecurity_Amount = txtBidSecurityAmt.Text
                    .Required_BidSecurity = txtRequiredBidSec.Text
                    .Sufficient_InSufficient = ddSufficient.SelectedItem.Text
                    .Remarks = txtRemarks.Text
                End With

                Dim Infra_Bidder_Hdr_ID As Long
                If Session("Saving") = "New" Then
                    Infra_Bidder_Hdr_ID = Infra_Bidder_Hdr.save
                ElseIf Session("Saving") = "Update" Then
                    Infra_Bidder_Hdr.Infra_BidderHdr_ID = grdBidders.SelectedDataKey("Infra_BidderHdr_ID")
                    Infra_Bidder_Hdr_ID = Infra_Bidder_Hdr.update
                End If

                grdDetails.Columns(5).Visible = True
                grdDetails.Columns(6).Visible = True
                For i As Integer = 0 To grdDetails.Rows.Count - 1
                    With Infra_Bidder_Dtl
                        .Infra_BidderHdr_ID = Infra_Bidder_Hdr_ID
                        .Infra_Dtl_ID = CType(grdDetails.Rows(i).FindControl("lblInfra_Dtl_ID"), Label).Text
                        .Bid_Price = FormatNumber(CType(grdDetails.Rows(i).FindControl("txtBidAmount"), TextBox).Text, 2)

                        If Session("Saving") = "New" Then
                            .save()
                        ElseIf Session("Saving") = "Update" Then
                            .Infra_BidderDtl_ID = CType(grdDetails.Rows(i).FindControl("lblInfra_BidderDtl_ID"), Label).Text
                            .update()
                        End If

                    End With
                Next
                grdDetails.Columns(5).Visible = False
                grdDetails.Columns(6).Visible = False

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction successfully saved.")

                LoadBidders()
                LoadClearTextFields()

                drpBidderName.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
                drpBidderName.DataTextField = ("SuppName")
                drpBidderName.DataValueField = ("Supplier_ID")
                drpBidderName.DataBind()
                drpBidderName.Items.Insert(0, "Select")

            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdBidders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("Bidder") = "Select" Then
            dtBidderItems = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_AbstractBidder_Items] '" & grdProjectList.SelectedDataKey("Infra_Hdr_ID") & "','" & grdBidders.SelectedDataKey("Supplier_ID") & "'", CommandType.Text)

            grdDetails.DataSource = dtBidderItems
            grdDetails.DataBind()

            CType(grdDetails.FooterRow.Cells(4).FindControl("lblTotalAmount"), Label).Text = FormatNumber(dtBidderItems.Rows(0)("Total_Amount"), 2)

            For i As Integer = 0 To dtBidderItems.Rows.Count - 1
                CType(grdDetails.Rows(i).FindControl("txtBidAmount"), TextBox).Text = FormatNumber(dtBidderItems.Rows(i)("Bid_Price"), 2)
            Next

            txtTimeDuration.Text = dtBidderItems.Rows(1)("TimeDuration")
            txtBidSecurityForm.Text = dtBidderItems.Rows(1)("BidSecurity")
            txtBankCampany.Text = dtBidderItems.Rows(1)("Bank_Campany")
            txtNumber.Text = dtBidderItems.Rows(1)("Number")
            txtValidityPeriod.Text = dtBidderItems.Rows(1)("ValidityPeriod")
            txtBidSecurityAmt.Text = FormatNumber(dtBidderItems.Rows(1)("BidSecurity_Amount"), 2)
            txtRequiredBidSec.Text = FormatNumber(dtBidderItems.Rows(1)("Required_BidSecurity"), 2)
            txtRemarks.Text = dtBidderItems.Rows(1)("Remarks")

            drpBidderName.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
            drpBidderName.DataTextField = ("SuppName")
            drpBidderName.DataValueField = ("Supplier_ID")
            drpBidderName.DataBind()
            drpBidderName.SelectedValue = grdBidders.SelectedDataKey("Supplier_ID")

            Session("Saving") = "Update"

        ElseIf Session("Bidder") = "Winner" Then
            Try
                If ddBACMember1.SelectedItem.Text = "" Or ddBACMember2.SelectedItem.Text = "" Or ddBACMember3.SelectedItem.Text = "" Then
                ElseIf ddBACVChair.SelectedItem.Text = "" Or ddBACChair.SelectedItem.Text = "" Or ddApprovedBy.SelectedItem.Text = "" Then
                ElseIf ddPreparedBy.SelectedItem.Text = "Select" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
                Exit Sub
            End Try

            '===============================================================================
            Try
                objDerived.GetRecords("UPDATE AMS.tb_Infra_Bidder_Hdr SET isWinner = 1, BAC1 = '" & ddBACMember1.SelectedItem.Value & "', BAC2 = '" & ddBACMember2.SelectedItem.Value & "', BAC3 = '" & ddBACMember3.SelectedItem.Value & "', " & _
                                    " BACVC = '" & ddBACVChair.SelectedItem.Value & "', BACC = '" & ddBACChair.SelectedItem.Value & "', " & _
                                    " PreparedBy = '" & ddPreparedBy.SelectedItem.Value & "', ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "' " & _
                                    " WHERE Infra_BidderHdr_ID = '" & grdBidders.SelectedDataKey("Infra_BidderHdr_ID") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.tb_Infra_Hdr SET isClose = 1 WHERE Infra_Hdr_ID = '" & grdProjectList.SelectedDataKey("Infra_Hdr_ID") & "'", CommandType.Text)
                Session("Infra_Hdr_ID") = grdProjectList.SelectedDataKey("Infra_Hdr_ID")

                '===== UPDATE BAC RESOLUTION =====
                Dim Reso As String = objDerived.GetValue("SELECT [AMS].[func_GenerateBAC_Infra] ('" & txtDate.Text & "')", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.pre_procurement SET resolution_number_date = '" & txtDate.Text & "', declarationDate='" & txtDate.Text & "', resolution_number = '" & Reso & "' WHERE pre_procurement_hdr_id = '" & Session("pre_procurement_hdr_id") & "'", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected bidder has been successfully declare as winner.")
                LoadInfraList()

                btnPreview.Enabled = True


            Catch ex As Exception
            End Try
        End If

    End Sub

    Protected Sub LoadClearTextFields()
        txtTimeDuration.Text = ""
        txtBidSecurityForm.Text = ""
        txtBankCampany.Text = ""
        txtNumber.Text = ""
        txtValidityPeriod.Text = ""
        txtBidSecurityAmt.Text = ""
        txtRequiredBidSec.Text = ""
        txtRemarks.Text = ""
    End Sub

    Protected Sub drpBidderName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadBidders()
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Calculated") = 1
        Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Abstract.aspx")
    End Sub

    Protected Sub lnkSelect_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Bidder") = "Select"
    End Sub

    Protected Sub lnkWinner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Bidder") = "Winner"
    End Sub

    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        
    End Sub


End Class
