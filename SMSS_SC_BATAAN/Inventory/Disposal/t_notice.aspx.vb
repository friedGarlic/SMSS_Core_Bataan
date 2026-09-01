Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports AjaxControlToolkit


Partial Class t_notice_of_award
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule

    Private hdr As New Disposal_bid_hdr
    Private dtl As New Disposal_bid_dtl
    Dim msg As New MsgeBox

    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable
    Private objMREReturn As New MRE_Return

    Private objDerived As New DerivedDal
    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim DonationLedger_ID As New Integer
    Dim dtDonationLedger As New DataTable

    Dim objStockLedger As New t_StockLedger
    Dim StockLedger_ID As New Integer
    Dim dtStockLedger As New DataTable

    Dim NOA_DSupp As New Disposal_NOA_Supp

#Region "property"
    Private Property pnew() As DataTable
        Get
            Return CType(Session("pnew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pnew") = value
        End Set
    End Property

    Private Property dtNOA_Supp() As DataTable
        Get
            Return CType(Session("dtNOA_Supp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNOA_Supp") = value
        End Set
    End Property

    Private Property dtNOA_SuppItems() As DataTable
        Get
            Return CType(Session("dtNOA_SuppItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNOA_SuppItems") = value
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
                'obj.GetAccessRight(Me.Session("@UserName"), Page)

                'If obj.HasAccess = False Then
                '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
                'End If

                Session("view") = "1"
                loadAward()

                rbChoice.SelectedItem.Value = 1
                LoadrbChoice()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Session("Notice") = "Award" Then
            ' Try
            objDerived.GetRecords("Update ams.Disposal_Bid_hdr set awarddate = '" & txtcanvassdate.Text & "'  where  Disposal_Bid_hdr_id=" & gvnew.SelectedDataKey(0) & "", CommandType.Text)
                objDerived.GetRecords("Update ams.Disposal_Bid_dtl set with_notice = 1  where  Disposal_Bid_hdr_id=" & gvnew.SelectedDataKey(0) & " and Supplier_ID=" & gvnew.SelectedDataKey(6) & "", CommandType.Text)

                If Session("Quotation") = "perItems" Then
                    For i As Integer = 0 To Me.pgvwinners.Rows.Count - 1
                        Dim a As Boolean = objDerived.GetValue("select Issued from AMS.Property_Dtl where PropertyNo='" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        objDerived.GetRecords("Update AMS.Property_Dtl set Dispose = 1, Issued = 0, DisposeDate='" & txtcanvassdate.Text & "' where  PropertyNo='" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        Dim qty As Integer = Val(objDerived.GetValue("SELECT AMS.Property.qty FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID WHERE     AMS.Property_Dtl.PropertyNo ='" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text))

                        balance = Val(objDerived.GetValue("exec AMS.getbalance '" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        issuance = Val(objDerived.GetValue("exec AMS.getIssuance '" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text))

                        objDerived.GetRecords("Update AMS.Property set qty=" & IIf(qty = 0, 0, qty - 1) & ", Balance='" & IIf(balance = 0, 0, balance - 1) & "' where  Property_ID='" & pgvwinners.Rows(i)("Property_ID") & "'", CommandType.Text)

                        'MRE_Returns
                        objMREReturn.MRE_Dtl = 0
                        objMREReturn.PropertyNo = pgvwinners.Rows(i)("PropertyNo")
                        objMREReturn.MRE_Date = txtcanvassdate.Text
                        objMREReturn.Status = "Disposed"
                        objMREReturn.Remarks = "Quotation"
                        objMREReturn.Dispose = True
                        objMREReturn.Repair = False
                        objMREReturn.Inspection = False
                        objMREReturn.deptid = 0
                        objMREReturn.UpdateMREReturn()

                        Dim isDon As New DataTable
                        isDon = objDerived.GetDataTable("SELECT * from dbo.View_Donation_Disposal where PropertyNo like '" & pgvwinners.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        If isDon.Rows(0).Item("isDonated").ToString = "True" Then
                            '===== Ledger ======
                            dtDonationLedger = objDonationLedger.GetDataTable("Select DonationLedger_ID from AMS.TbDonation_Ledger", CommandType.Text)
                            With objDonationLedger
                                '.DonationLedger_ID = DonationLedger_ID
                                .PropertyNo = pgvwinners.Rows(i)("PropertyNo")
                                .dDate = txtcanvassdate.Text
                                .SerialNo = IIf(IsDBNull(pgvwinners.Rows(i)("Barcode").ToString), 0, (pgvwinners.Rows(i)("Barcode").ToString))
                                .Trans_Type = "Disposed as" + " " + txtPRno.Text
                                .Ref = ""
                                .AccountablePerson = txtsupplier.Text
                                .Department = ""
                                .Position = ""
                                .AcceptedBy = ""
                                .InspectedBy = ""
                                .DebitQty = "0"
                                .DebitUnit = "-"
                                .DebitCost = "0.00"

                                .Item_ID = pgvwinners.Rows(i)("Item_ID")

                                .CreditQty = 1
                                .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & pgvwinners.Rows(i)("Item_ID") & "'", CommandType.Text)
                                .CreditCost = CType(pgvwinners.Rows(i)("Amount"), Decimal)

                                .BalanceQty = 0
                                .BalanceUnit = "-"
                                .BalanceCost = CType(0, Decimal)

                            End With
                            objDonationLedger.DonationLedger_ID = 0
                            objDonationLedger.save()


                        Else
                            '==== Update Ledger ====
                            dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
                            With objLedger
                                '.Ledger_ID = Ledger_ID
                                .PropertyNo = pgvwinners.Rows(i)("PropertyNo")
                                .SerialNo = pgvwinners.Rows(i)("Barcode")
                                .dDate = txtcanvassdate.Text
                                .Trans_Type = "Disposed as" + " " + txtPRno.Text
                                .Ref = ""
                                .AccountablePerson = txtsupplier.Text
                                .Department = ""
                                .Position = ""
                                .AcceptedBy = ""
                                .InspectedBy = ""
                                .DebitQty = "0"
                                .DebitUnit = "-"
                                .DebitCost = "0.00"
                                '.CreditQty = ""
                                '.CreditUnit = ""
                                '.CreditCost = ""
                                '.BalanceQty = ""
                                '.BalanceUnit = ""
                                '.BalanceCost = ""

                                .Item_ID = pgvwinners.Rows(i)("Item_ID")

                                .CreditQty = 1
                                .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pgvwinners.Rows(i)("Item_ID") & "'", CommandType.Text)
                                .CreditCost = CType(pgvwinners.Rows(i)("Amount"), Decimal)

                                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pgvwinners.Rows(i)("Item_ID") & "'", CommandType.Text)

                                Dim eQty As Integer
                                Dim eBalance As Decimal
                                Dim dtledger As New DataTable

                                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & pgvwinners.Rows(i)("Item_ID") & "'", CommandType.Text)
                                If dtledger.Rows.Count = 0 Then
                                    eQty = 0
                                    eBalance = 0.0
                                Else
                                    eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & pgvwinners.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                                    eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & pgvwinners.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                                End If

                                .BalanceQty = eQty - 1
                                .BalanceCost = CType(eBalance, Decimal) - CType(pgvwinners.Rows(i)("Amount"), Decimal)
                            End With

                            objLedger.Ledger_ID = 0
                            objLedger.save()
                        End If
                    Next

                Else
                    '=== DISPOSED AS PER LOT
                    Dim dtLOT As New DataTable
                    dtLOT = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_NoticeAward_Items] WHERE quotation_hdr_id = '" & gvnew.SelectedDataKey("quotation_hdr_id") & "' ORDER BY PropertyNo", CommandType.Text)

                    For i As Integer = 0 To dtLOT.Rows.Count - 1
                        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET Dispose = 1, Issued = 0, DisposeDate = '" & txtcanvassdate.Text & "' WHERE PropertyNo = '" & dtLOT.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        Dim qty As Integer = Val(objDerived.GetValue("SELECT AMS.Property.qty FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID WHERE AMS.Property_Dtl.PropertyNo = '" & dtLOT.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & dtLOT.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & dtLOT.Rows(i)("PropertyNo") & "'", CommandType.Text))

                        objDerived.GetRecords("UPDATE AMS.Property SET qty = '" & IIf(qty = 0, 0, qty - 1) & "', Balance = '" & IIf(balance = 0, 0, balance - 1) & "' WHERE Property_ID='" & dtLOT.Rows(i)("Property_ID") & "'", CommandType.Text)

                        'MRE_Returns
                        With objMREReturn
                            .MRE_Dtl = 0
                            .PropertyNo = dtLOT.Rows(i)("PropertyNo")
                            .MRE_Date = txtcanvassdate.Text
                            .Status = "Disposed"
                            .Remarks = "Quotation"
                            .Dispose = True
                            .Repair = False
                            .Inspection = False
                            .deptid = 0
                            .UpdateMREReturn()
                        End With

                        If dtLOT.Rows(i)("isDonated") = True Then
                            '===== Ledger ======
                            With objDonationLedger
                                '.DonationLedger_ID = DonationLedger_ID
                                .PropertyNo = dtLOT.Rows(i)("PropertyNo")
                                .dDate = txtcanvassdate.Text
                                .SerialNo = IIf(IsDBNull(dtLOT.Rows(i)("SerialNo").ToString), 0, (dtLOT.Rows(i)("SerialNo").ToString))
                                .Trans_Type = "Disposed as" + " " + txtPRno.Text
                                .Ref = ""
                                .AccountablePerson = txtsupplier.Text
                                .Department = ""
                                .Position = ""
                                .AcceptedBy = ""
                                .InspectedBy = ""
                                .DebitQty = "0"
                                .DebitUnit = "-"
                                .DebitCost = "0.00"
                                .Item_ID = dtLOT.Rows(i)("Item_ID")
                                .CreditQty = 1
                                .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & dtLOT.Rows(i)("Item_ID") & "'", CommandType.Text)
                                .CreditCost = CType(dtLOT.Rows(i)("Cost"), Decimal)
                                .BalanceQty = 0
                                .BalanceUnit = "-"
                                .BalanceCost = CType(0, Decimal)
                            End With
                            objDonationLedger.DonationLedger_ID = 0
                            objDonationLedger.save()


                        Else
                            '==== Update Ledger ====
                            With objLedger
                                '.Ledger_ID = Ledger_ID
                                .PropertyNo = dtLOT.Rows(i)("PropertyNo")
                                .SerialNo = dtLOT.Rows(i)("SerialNo")
                                .dDate = txtcanvassdate.Text
                                .Trans_Type = "Disposed as" + " " + txtPRno.Text
                                .Ref = ""
                                .AccountablePerson = txtsupplier.Text
                                .Department = ""
                                .Position = ""
                                .AcceptedBy = ""
                                .InspectedBy = ""
                                .DebitQty = "0"
                                .DebitUnit = "-"
                                .DebitCost = "0.00"

                                .Item_ID = dtLOT.Rows(i)("Item_ID")

                                .CreditQty = 1
                                .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtLOT.Rows(i)("Item_ID") & "'", CommandType.Text)
                                .CreditCost = CType(dtLOT.Rows(i)("Cost"), Decimal)

                                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & dtLOT.Rows(i)("Item_ID") & "'", CommandType.Text)

                                Dim eQty As Integer
                                Dim eBalance As Decimal
                                Dim dtledger As New DataTable

                                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & dtLOT.Rows(i)("Item_ID") & "'", CommandType.Text)
                                If dtledger.Rows.Count = 0 Then
                                    eQty = 0
                                    eBalance = 0.0
                                Else
                                    eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & dtLOT.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                                    eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & dtLOT.Rows(i)("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                                End If

                                .BalanceQty = eQty - 1
                                .BalanceCost = CType(eBalance, Decimal) - CType(dtLOT.Rows(i)("Cost"), Decimal)
                            End With
                            objLedger.Ledger_ID = 0
                            objLedger.save()

                        End If

                    Next

                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel21, "Transaction has been successfully saved.")

                btnSave.Enabled = False
                btnPreview.Enabled = True
            'Catch ex As Exception

            'End Try
            loadProceed()


        Else
            objDerived.GetRecords("Update ams.Disposal_Bid_hdr set proceeddate = '" & txtcanvassdate.Text & "'  where  Disposal_Bid_hdr_id=" & gvnew.SelectedDataKey(0) & "", CommandType.Text)
            objDerived.GetRecords("Update ams.Disposal_Bid_dtl set with_NTP = 1  where  Disposal_Bid_hdr_id=" & gvnew.SelectedDataKey(0) & " and Supplier_ID=" & gvnew.SelectedDataKey(6) & "", CommandType.Text)
            loadAward()


        End If
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
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_notice_of_award.aspx")
    End Sub

    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvnew.SelectedIndexChanged
        If rbChoice.SelectedItem.Value = 1 Then
            Session("Disposal_Bid_hdr_id") = gvnew.SelectedDataKey("Disposal_Bid_hdr_id")

            Dim perItems As Boolean
            perItems = objDerived.GetValue("SELECT perItems FROM [dbo].[View_Disposal_NoticeAward_Quotation] WHERE Disposal_Bid_hdr_id = '" & Session("Disposal_Bid_hdr_id") & "'", CommandType.Text)

            If perItems = True Then
                Me.mvQuotation.SetActiveView(Me.vwPerItems)

                pgvwinners = objDerived.GetDataTable("exec AMS.loadAbstractBidsDetailPerSupplier " & gvnew.SelectedDataKey(5) & "," & gvnew.SelectedDataKey(6) & "", CommandType.Text)
                gvWinners.DataSource = pgvwinners
                gvWinners.DataBind()

                gvWinners.FooterRow.Cells(2).Text = FormatNumber(pgvwinners.Compute("sum(Cost)", ""), 2)

                Session("Quotation") = "perItems"
            Else
                Me.mvQuotation.SetActiveView(Me.vwPerLot)

                grdPerLot.DataSource = objDerived.GetDataTable("SELECT *, 'Lot' AS Unit FROM AMS.Disposal_Bid_dtl WHERE Is_Award = 1 AND Disposal_Bid_hdr_id = '" & Session("Disposal_Bid_hdr_id") & "'", CommandType.Text)
                grdPerLot.DataBind()

                Session("Quotation") = "perLot"
            End If

            btnSave.Enabled = True
        ElseIf rbChoice.SelectedItem.Value = 2 Then
            pgvwinners = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_NoticeAward_Supplier] WHERE Disposal_Bid_hdr_id = '" & gvnew.SelectedDataKey("Disposal_Bid_hdr_id") & "' AND Supplier_ID = '" & gvnew.SelectedDataKey("Supplier_Id") & "'", CommandType.Text)
            grdSupply.DataSource = pgvwinners
            grdSupply.DataBind()

            grdSupply.FooterRow.Cells(2).Text = FormatNumber(pgvwinners.Compute("sum(Cost)", ""), 2)
            btnAwardSupp.Enabled = True

        End If

        txtPRno.Text = gvnew.SelectedDataKey(3)
        txtSupplyPRno.Text = gvnew.SelectedDataKey(3)

        txtcanvass.Text = gvnew.SelectedDataKey(4)
        txtSupplycanvass.Text = gvnew.SelectedDataKey(4)

        txtcanvassdate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtSupplycanvassdate.Text = Date.Today.ToString("MM/dd/yyyy")

        txtsupplier.Text = gvnew.SelectedDataKey(2)
        txtSupplysupplier.Text = gvnew.SelectedDataKey(2)


    End Sub

    Protected Sub gvnew_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvnew.PageIndexChanging
        Me.gvnew.PageIndex = e.NewPageIndex
        Me.gvnew.DataSource = CType(pnew, DataTable)
        Me.gvnew.DataBind()
        gvnew.SelectedIndex = -1

    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwProperty)
            If Session("Notice") = "Award" Then
                pnew = objDerived.GetDataTable("EXEC [AMS].[sp_Disposal_NoticeAward] '" & 1 & "'", CommandType.Text)
            Else
                pnew = objDerived.GetDataTable("EXEC [AMS].[sp_Disposal_NoticetoProceed] '" & 1 & "'", CommandType.Text)

            End If

            gvnew.DataSource = CType(pnew, DataTable)
            gvnew.DataBind()

            gvWinners.DataSource = Nothing
            gvWinners.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwSupply)
            If Session("Notice") = "Award" Then
                dtNOA_Supp = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_NOASupplies]", CommandType.Text)
                btnAwardSupp.text = "AWARD"
            Else
                dtNOA_Supp = objDerived.GetDataTable("SELECT * FROM [AMS].[View_Disposal_NOASupplies_V1_05062022] where with_notice = 1 and Is_Award = 1 and (with_NTP is null or with_NTP = 0)", CommandType.Text)
                btnAwardSupp.text = "PROCEED"
            End If
            grdNOA_Supp.DataSource = dtNOA_Supp
            grdNOA_Supp.DataBind()

            grdSupply.DataSource = Nothing
            grdSupply.DataBind()
        End If

    End Sub

    Protected Sub btnAwardSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnAwardSupp.text = "AWARD" Then
            With NOA_DSupp
                .NOA_SuppDate = txtcanvassdate.Text
                .DSupplies_Hdr_ID = grdNOA_Supp.SelectedDataKey("DSupplies_Hdr_ID")
                .ApprovedBy = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 1 AND division_key = 86", CommandType.Text)
                .UserID = Session("@UserName")
                .save()
            End With


            objDerived.GetRecords("UPDATE AMS.Disposal_Supplies_Hdr SET awarddate = '" & txtSupplycanvassdate.Text & "'  WHERE  DSupplies_Hdr_ID='" & grdNOA_Supp.SelectedDataKey(0) & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Disposal_Supplies_dtl SET with_notice = 1 ,is_Award = 1 WHERE  DSupplies_Hdr_ID ='" & grdNOA_Supp.SelectedDataKey(0) & "'", CommandType.Text)

            '=-= UPDATE SUPPLY LEDGER
            For i As Integer = 0 To dtNOA_SuppItems.Rows.Count - 1
                With objStockLedger
                    .StockID = 0
                    .Trans_Type = "Disposed as" + " " + txtPRno.Text
                    .Ref = ""
                    .AccountablePerson = txtsupplier.Text
                    .Department = ""
                    .Position = ""
                    .AcceptedBy = ""
                    .InspectedBy = ""
                    .dDate = txtcanvassdate.Text
                    .Item_ID = dtNOA_SuppItems.Rows(i)("Item_ID")

                    .DebitQty = "0"
                    .DebitUnit = "-"
                    .DebitCost = "0.00"
                    .CreditQty = dtNOA_SuppItems.Rows(i)("Qty")
                    .CreditCost = dtNOA_SuppItems.Rows(i)("TotalAmount")
                    .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & dtNOA_SuppItems.Rows(i)("Item_ID") & "'", CommandType.Text)

                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & dtNOA_SuppItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                    .BalanceQty = 0
                    .BalanceCost = 0
                    .save()
                End With
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel21, "Transaction has been successfully saved.")


            dtNOA_Supp = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Disposal_NOASupplies] ", CommandType.Text)
            grdNOA_Supp.DataSource = dtNOA_Supp
            grdNOA_Supp.DataBind()

            grdSupply.DataSource = Nothing
            grdSupply.DataBind()

            btnPreviewSupp.Enabled = True
            btnAwardSupp.Enabled = False

        Else
            objDerived.GetRecords("Update ams.Disposal_Supplies_Hdr set proceeddate = '" & txtSupplycanvassdate.Text & "'   WHERE  DSupplies_Hdr_ID='" & grdNOA_Supp.SelectedDataKey(0) & "'", CommandType.Text)
            objDerived.GetRecords("Update ams.Disposal_Supplies_dtl set with_NTP = 1  WHERE  DSupplies_Hdr_ID ='" & grdNOA_Supp.SelectedDataKey(0) & "'", CommandType.Text)

        End If


    End Sub

    Protected Sub btnPreviewSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_notice_of_award.aspx")
    End Sub

    Protected Sub grdNOA_Supp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPRno.Text = grdNOA_Supp.SelectedDataKey("Description")
        txtSupplyPRno.Text = grdNOA_Supp.SelectedDataKey("Description")

        txtcanvass.Text = grdNOA_Supp.SelectedDataKey("Canvass_No")
        txtSupplycanvass.Text = grdNOA_Supp.SelectedDataKey("Canvass_No")

        txtcanvassdate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtSupplycanvassdate.Text = Date.Today.ToString("MM/dd/yyyy")

        txtsupplier.Text = grdNOA_Supp.SelectedDataKey("SuppName")
        txtSupplysupplier.Text = grdNOA_Supp.SelectedDataKey("SuppName")


        dtNOA_SuppItems = objDerived.GetDataTable("SELECT * FROM dbo.View_USupplies_Items WHERE Supplier_ID = '" & grdNOA_Supp.SelectedDataKey("Supplier_ID") & "' AND IIRUS_ID = '" & grdNOA_Supp.SelectedDataKey("IIRUS_ID") & "'", CommandType.Text)
        grdSupply.DataSource = dtNOA_SuppItems
        grdSupply.DataBind()

        grdSupply.FooterRow.Cells(3).Text = FormatNumber(dtNOA_SuppItems.Compute("sum(TotalAmount)", ""), 2)
        btnAwardSupp.Enabled = True
    End Sub


    Protected Sub btnNoticeofAward_Click(sender As Object, e As EventArgs)
        loadAward()
    End Sub
    Public Sub loadAward()
        btnNoticeofAward.CssClass = "Clicked"
        btnNoticetoProceed.CssClass = "Initial"
        Session("Notice") = "Award"
        LoadrbChoice()

    End Sub
    Public Sub loadProceed()
        btnNoticeofAward.CssClass = "Initial"
        btnNoticetoProceed.CssClass = "Clicked"
        Session("Notice") = "Proceed"
        LoadrbChoice()
    End Sub
    Protected Sub btnNoticetoProceed_Click(sender As Object, e As EventArgs)

        loadProceed()
    End Sub


End Class


