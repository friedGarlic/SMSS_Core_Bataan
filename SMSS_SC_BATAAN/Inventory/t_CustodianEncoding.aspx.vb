Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.Page
Imports System.Web.UI
Imports System.Web.UI.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports OnBarcode
Imports System.Drawing

Partial Class Inventory_t_CustodianEncoding
    Inherits System.Web.UI.Page
    Dim dtItems As DataTable
    Dim CYear As String = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))

#Region "BDal"
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private objProperty As New t_property_hdr
    Private propertDtl As New t_property_dtl

    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl

    Dim POhdr As New t_purchase_order_hdr
    Dim POdtl As New t_purchase_order_dtl

    Dim objhdr As New t_inspection_and_acceptance_hdr
    Dim objdtl As New t_inspection_and_acceptance_dtl

    Dim objStockLedger As New t_StockLedger
    Dim objStock As New Supplies_Stock

    Dim objOfficeSup As New SupplieINFO
    Dim objMedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl
    Dim objMedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info
    Dim objNonFood As New ConsolidatedMedicineSaving.TbNonFood
    Dim objFood As New ConsolidatedMedicineSaving.TbFood
    Dim objWater As New ConsolidatedMedicineSaving.TbWater

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            Session("Search") = 0

            ddGA.DataSource = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 2 & "'", CommandType.Text)
            ddGA.DataTextField = ("GA_Title")
            ddGA.DataValueField = ("GA_ID")
            ddGA.DataBind()
            ddGA.Items.Insert(0, "Select")

            dtItems = Nothing
            gvbody.DataSource = dtItems
            gvbody.DataBind()

            Dim dept As New DataTable
            dept = objDerived.GetDataTable("SELECT * FROM AMS.Respcenter order BY RespCenter", CommandType.Text) '("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
            ddDepartment.DataSource = dept
            ddDepartment.DataTextField = ("RespCenter")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            lblPR.ForeColor = Color.DimGray
            lblPO.ForeColor = Color.DimGray
            lblAIR.ForeColor = Color.DimGray

        End If
    End Sub

    Protected Sub ddGA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtSearch.Enabled = True
        btnSearch.Enabled = True

        If ddGA.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select general account.")
            Exit Sub
        End If

        Session("GA_ID") = ddGA.SelectedItem.Value

        If ddGA.SelectedItem.Value = 0 Then
            dtItems = Nothing
            gvbody.DataSource = Nothing
            gvbody.DataBind()
        Else
            dtItems = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Custodian] '" & ddGA.SelectedItem.Value & "', '" & CYear & "'", CommandType.Text)
            gvbody.DataSource = dtItems
            gvbody.DataBind()
        End If

    End Sub
    Protected Sub gvbody_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Session("Search") = 0 Then
            dtItems = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Custodian] '" & ddGA.SelectedItem.Value & "', '" & CYear & "'", CommandType.Text)
            gvbody.PageIndex = e.NewPageIndex
            gvbody.DataSource = dtItems
            gvbody.DataBind()

        ElseIf Session("Search") = 1 Then
            Dim dtSearch As New DataTable
            dtSearch = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Custodian_Search] '" & ddGA.SelectedItem.Value & "', '" & CYear & "','" & txtSearch.Text & "'", CommandType.Text)
            gvbody.PageIndex = e.NewPageIndex
            gvbody.DataSource = dtSearch
            gvbody.DataBind()
        Else
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "!@#$%^&*()-_=+, try again.")
        End If

    End Sub
    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Panel_PR.Enabled = True
        txtPRnumber.Enabled = True
        txtPRdate.Enabled = True
        ddDepartment.Enabled = True

        lblPR.ForeColor = Color.Blue

        txtPRprice.Text = gvbody.SelectedDataKey("Price")
        txtPRprice.Enabled = True

        Session("Item_ID") = gvbody.SelectedDataKey("Item_ID")
        Session("Item_Desc") = gvbody.SelectedDataKey("Item_Desc")

        btnSave.Text = "NEXT - PURCHASED ORDER"

    End Sub
    Protected Sub gvbody_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvbody, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtSearch As New DataTable
        If txtSearch.Text = "" Then
            Session("Search") = 0
            dtSearch = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Custodian] '" & ddGA.SelectedItem.Value & "', '" & CYear & "'", CommandType.Text)
            gvbody.DataSource = dtSearch
            gvbody.DataBind()
        Else
            Session("Search") = 1
            dtSearch = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Custodian_Search] '" & ddGA.SelectedItem.Value & "', '" & CYear & "','" & txtSearch.Text & "'", CommandType.Text)
            gvbody.DataSource = dtSearch
            gvbody.DataBind()
        End If

    End Sub

    Protected Sub txtPRprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPRprice.Text = FormatNumber(CType(txtPRprice.Text, Decimal))
    End Sub

    Protected Sub txtContractprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtContractprice.Text = FormatNumber(CType(txtContractprice.Text, Decimal))
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFucntion.Enabled = True

        Dim funct As New DataTable
        funct = objDerived.GetDataTable("select Office_id as Rc_id,Function_id,Function_desc from ams.vw_functions  where Office_id = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        ddFucntion.DataSource = funct
        ddFucntion.DataTextField = ("Function_Desc")
        ddFucntion.DataValueField = ("Function_ID")
        ddFucntion.DataBind()
        ddFucntion.Items.Insert(0, "Select")

        ddDepartment.Enabled = False
    End Sub

    Protected Sub ddFucntion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim requestedby As New DataTable
        requestedby = objDerived.GetDataTable("SELECT * FROM dbo.view_EmployeeSignatories WHERE dept_id = '" & ddDepartment.SelectedItem.Value & "' AND func_id = '" & ddFucntion.SelectedItem.Value & "'", CommandType.Text)
        ddPRrequestedby.DataSource = requestedby
        ddPRrequestedby.DataTextField = ("full_name")
        ddPRrequestedby.DataValueField = ("empID")
        ddPRrequestedby.DataBind()
        ddPRrequestedby.Items.Insert(0, "Select")

        ddFucntion.Enabled = False
        ddPRrequestedby.Enabled = True

        '=-= ACCEPTED BY GSD HEAD
        Dim accpt As New DataTable
        accpt = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        ddacceptedby.DataSource = accpt
        ddacceptedby.DataTextField = ("full_name")
        ddacceptedby.DataValueField = ("Signatory_ID")
        ddacceptedby.DataBind()
        ddacceptedby.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddPRrequestedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim approvedby As New DataTable

        approvedby = objDerived.GetDataTable("SELECT Distinct * FROM  HRMS.view_signatory WHERE AND deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        ddApprovedby.DataSource = approvedby
        ddApprovedby.DataTextField = ("full_name")
        ddApprovedby.DataValueField = ("empID")
        ddApprovedby.DataBind()
        ddApprovedby.Items.Insert(0, "Select")

        ddPRrequestedby.Enabled = False
        ddApprovedby.Enabled = True
    End Sub

    Protected Sub ddApprovedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPRremarks.Enabled = True
        txtQty.Enabled = True
        btnSave.Enabled = True
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True

        If btnSave.Text = "NEXT - PURCHASED ORDER" Then
            If txtPRnumber.Text = "" Or txtPRprice.Text = "" Or txtPRremarks.Text = "" Or txtPRdate.Text = "" Or txtQty.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                Exit Sub
            ElseIf ddDepartment.SelectedItem.Text = "Select" Or ddFucntion.SelectedItem.Text = "Select" Or ddPRrequestedby.SelectedItem.Text = "Select" Or ddApprovedby.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                Exit Sub
            End If

            Panel_PR.Enabled = False
            Panel_PO.Enabled = True

            txtPOnumber.Text = txtPRnumber.Text

            Dim supp As New DataTable
            supp = objDerived.GetDataTable("Select * from dbo.Supplier order by SuppName", CommandType.Text)
            ddSupplier.DataSource = supp
            ddSupplier.DataTextField = ("SuppName")
            ddSupplier.DataValueField = ("Supplier_Id")
            ddSupplier.DataBind()
            ddSupplier.Items.Insert(0, "Select")

            btnSave.Text = "NEXT - INSPECTION & ACCEPTANCE"
            btnPrev.Enabled = True

            lblPR.ForeColor = Color.DimGray
            lblPO.ForeColor = Color.Blue

        ElseIf btnSave.Text = "NEXT - INSPECTION & ACCEPTANCE" Then
            If ddSupplier.SelectedItem.Text = "Select" Or txtDelivereddate.Text = "" Or txtPOdate.Text = "" Or txtContractprice.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                Exit Sub
            Else
                Panel_PO.Enabled = False
                Panel_IA.Enabled = True

                Dim ins As New DataTable

                Dim Rcv As New DataTable
                Rcv = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 and division_key = 86", CommandType.Text)
                ddReceivedBy.DataSource = Rcv
                ddReceivedBy.DataTextField = ("full_name")
                ddReceivedBy.DataValueField = ("Signatory_ID")
                ddReceivedBy.DataBind()
                ddReceivedBy.Items.Insert(0, "Select")

                ins = objDerived.GetDataTable("Select * from HRMS.view_signatory where position_desc like 'Inspector'", CommandType.Text)
                ddInspectedby.DataSource = ins
                ddInspectedby.DataTextField = ("full_name")
                ddInspectedby.DataValueField = ("Signatory_ID")
                ddInspectedby.DataBind()
                ddInspectedby.Items.Insert(0, "Select")

                btnSave.Text = "SAVE"
                btnPrev.Enabled = True

                lblPO.ForeColor = Color.DimGray
                lblAIR.ForeColor = Color.Blue

            End If

        ElseIf btnSave.Text = "SAVE" Then
            If txtDateAccepted.Text = "" Or txtIAdate.Text = "" Or ddacceptedby.SelectedItem.Text = "Select" Or ddInspectedby.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                Exit Sub
            End If

            Try
                '=-= SAVE PURCHASED REQUEST
                Dim prhdrID As Long
                prhdr.PR_Year = Year(CDate(txtPRdate.Text))
                prhdr.PR_Date = txtPRdate.Text
                prhdr.RC_ID = ddDepartment.SelectedItem.Value
                prhdr.Function_ID = ddFucntion.SelectedItem.Value
                prhdr.remarks = txtPRremarks.Text
                prhdr.Transaction_type = 3
                prhdr.Project_ID = 0
                prhdr.Program_id = 0
                prhdr.ABC = FormatNumber(txtContractprice.Text * txtQty.Text)
                prhdr.Requestedby = ddPRrequestedby.SelectedItem.Value
                prhdr.Approvedby = ddApprovedby.SelectedItem.Value
                prhdr.Date_Submitted = txtPRdate.Text
                prhdr.Date_gso_rcv = txtPRdate.Text
                prhdr.IsCancelled = False
                prhdr.IsApproved = True
                prhdr.isOnBid = True
                prhdr.POHdr_ID = 0
                prhdr.withWinner = True
                prhdr.withOBR = True
                prhdr.withPO = True
                prhdr.declarationDate = "01/01/1900"
                prhdr.rcv_date = "01/01/1900"
                prhdr.mode_of_procurement_id = 2
                prhdr.isPublicInfra = False
                prhdr.isStraight = False
                prhdr.DateApproved_PR_Mayor = txtPRdate.Text
                prhdr.DateReceived_PR_Mayor = txtPRdate.Text
                prhdr.isApproved_PR_Mayor = True
                prhdr.isReceived_PR_Mayor = True
                prhdr.DateDisApprove = "01/01/1900"
                prhdr.isGasoline = False
                prhdr.pr_period_key_id = 0
                prhdr.pr_invoice_hdr_id = 0
                prhdr.isReimbursement = False
                prhdr.isContract = False
                prhdr.isEditable = False
                prhdr.RequestingOfficer = ""
                prhdr.Position = ""
                prhdr.isContinuing = False
                'prhdr.Userid = Me.Session("@UserName").ToString

                prhdr.pr_no = txtPRnumber.Text

                Dim pr_id As New DataTable
                pr_id = objDerived.GetDataTable("Select prhdr_id from ams.pr_hdr where pr_no like '" & txtPRnumber.Text & "'", CommandType.Text)
                If pr_id.Rows.Count = 0 Then
                    prhdrID = prhdr.save
                Else
                    Dim id As Integer
                    id = objDerived.GetValue("Select prhdr_id from ams.pr_hdr where pr_no like '" & txtPRnumber.Text & "'", CommandType.Text)
                    prhdr.prhdr_id = id
                    prhdrID = prhdr.update
                End If

                Session("PRHdr_ID") = prhdrID
                objDerived.GetRecords("UPDATE ams.pr_hdr set Userid ='" & Session("@UserName") & "', isTrustFund = 0 where prhdr_id='" & Session("PRHdr_ID") & "' ", CommandType.Text)


                '=-= PR Details Save
                prdtl.PRHdr_ID = Session("PRHdr_ID")
                prdtl.Item_ID = Session("Item_ID")
                prdtl.Project_title = txtPRremarks.Text
                prdtl.Qty = txtQty.Text
                prdtl.Cost = txtPRprice.Text
                prdtl.ppmp_dtl_id = 0
                prdtl.save()

                '=-= END OF PURCHASED REQUEST


                '--------------------------------------------------------------
                '=-= SAVE OF PURCHASED ORDER
                Dim pohdr_id As Long

                POhdr.PO_No = txtPOnumber.Text
                POhdr.PO_Date = txtPOdate.Text
                POhdr.Supplier_ID = ddSupplier.SelectedItem.Value
                'POhdr.mode_of_procurement_id = ddmodeofprocurement.SelectedItem.Value
                'POhdr.DeliveryTerm = ddDeliveryterm.SelectedItem.Text
                'POhdr.paymentTerm = ddPaymentterm.SelectedItem.Text
                POhdr.DeliveryDate = txtDelivereddate.Text
                POhdr.DeliveryPlace = ""
                POhdr.isDelivered = True
                POhdr.pre_procurement_hdr_id = 0
                POhdr.withdv = False
                'POhdr.ContractPrice = FormatNumber(txtContractprice.Text * txtQty.Text)
                POhdr.isStag = False
                POhdr.isContinueCutOff = False
                POhdr.isStopForCutOff = False
                POhdr.isShoppingA = False
                POhdr.isPublicInfra = False
                POhdr.isStraight = True
                POhdr.isApproved_PO_Mayor = True
                POhdr.isReceived_PO_Mayor = True
                POhdr.DateApproved_PO_Mayor = txtPOdate.Text
                POhdr.DateReceived_PO_Mayor = txtPOdate.Text
                POhdr.DateDisApprove = "01/01/1900"
                POhdr.isGasoline = False
                POhdr.isReimbursement = False
                POhdr.RC_ID = ddDepartment.SelectedItem.Value
                POhdr.Function_ID = ddFucntion.SelectedItem.Value

                Dim po_id As New DataTable
                po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & txtPOnumber.Text & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
                If po_id.Rows.Count = 0 Then
                    POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
                    pohdr_id = POhdr.save()

                Else
                    Dim poid As Integer
                    Dim TAmount As Decimal
                    poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & txtPOnumber.Text & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
                    TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

                    POhdr.ContractPrice = CType(TAmount + CType(txtContractprice.Text, Decimal), Decimal)
                    POhdr.POHdr_ID = poid
                    pohdr_id = POhdr.update()
                End If
                Session("POHdr_ID") = pohdr_id

                '=-= PO Details Save
                POdtl.POHdr_ID = Session("POHdr_ID")
                POdtl.Item_ID = Session("Item_ID")
                POdtl.cost = txtContractprice.Text
                POdtl.qty = txtQty.Text
                POdtl.remarks = ""
                POdtl.save()

                '=-= END OF PURCHASED ORDER

                '--------------------------------------------------------------
                '=-= SAVE OF INSPECTION & ACCEPTANCE
                Dim airhdr_id As Long
                Dim air As String
                air = objDerived.GetValue("select [AMS].[func_GenerateAIR]( '" & txtIAdate.Text & "')", CommandType.Text)

                objhdr.AIR_No = air
                objhdr.AIR_Date = txtIAdate.Text
                objhdr.Date_Inspect = txtIAdate.Text
                objhdr.Date_Received = txtIAdate.Text
                objhdr.Invoice_No = txtInvoice.Text
                objhdr.Invoice_date = txtIAdate.Text
                objhdr.PO_No = txtPOnumber.Text
                objhdr.Signatory1 = ddInspectedby.SelectedItem.Text
                objhdr.Signatory2 = ddReceivedBy.SelectedItem.Text
                objhdr.Signatory3 = ddacceptedby.SelectedItem.Text
                objhdr.isComplete = True
                objhdr.POHdr_ID = Session("POHdr_ID")
                objhdr.remarks = txtIAremarks.Text

                airhdr_id = objhdr.save()

                Session("AIRHDR_ID") = airhdr_id

                '=-= AIR DETAILS
                Dim iaDtl_ID As Integer
                objdtl.Item_ID = Session("Item_ID")
                objdtl.Qty = txtQty.Text
                objdtl.Cost = txtContractprice.Text
                objdtl.AIRHdr_ID = Session("AIRHDR_ID")
                objdtl.GA_ID = Session("GA_ID")
                iaDtl_ID = objdtl.save()

                Session("AIRDtl_ID") = iaDtl_ID

                '=-= END OF INSPECTION & ACCEPTANCE

                '---------------------------------------------------------
                '=-= Stock Save
                With objStock
                    '.StockID = StockID
                    .StockDate = txtDateAccepted.Text
                    .Item_ID = Session("Item_ID")
                    .Qty = txtQty.Text
                    .Balance = txtQty.Text
                    '.Location = txtLocation.Text
                    .Expiration_Date = "1/1/1900"
                    .Cost = txtContractprice.Text
                    .Issuance = 0
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFucntion.SelectedItem.Value
                    .Project_ID = 0
                    .Program_id = 0
                    .F_ID = 4
                    .AIRDtl_ID = Session("AIRDtl_ID")
                    .GA_ID = Session("GA_ID")
                    '.mab = CType(grdOfficeSupp.Rows(i).Cells(2).Text * grdOfficeSupp.Rows(i).Cells(12).Text, Decimal)
                    .save()

                End With
                Dim StockID As Long
                StockID = objStock.GetValue("Select max(StockID) from AMS.Stock ", CommandType.Text)

                '=-= End of Stock Saving


                '---------------------------------------------------------
                '====== save ledger ========
                With objStockLedger
                    '.StockLedger_ID = StockLedger_ID
                    .StockID = StockID
                    .Trans_Type = "Old Inventory"
                    .Ref = air
                    .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
                    .Department = ddDepartment.SelectedItem.Text
                    .Position = ""
                    .AcceptedBy = ddacceptedby.SelectedItem.Text
                    .InspectedBy = ddInspectedby.SelectedItem.Text
                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"
                    .dDate = txtDateAccepted.Text
                    .Item_ID = Session("Item_ID")
                    .DebitQty = txtQty.Text
                    .DebitCost = FormatNumber(txtContractprice.Text * txtQty.Text)
                    .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
                    .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
                    .BalanceQty = 0
                    .BalanceCost = 0
                    .save()
                End With

                '=-= END of Stock Ledger


                '------------------------------------------------------
                '=-= Supplies Save
                If ddGA.SelectedItem.Value = 788 Then
                    'Office Supplies
                    With objOfficeSup
                        '.SuppliesId = SuppliesId
                        .StockID = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .ItemId = Session("Item_ID")
                        .Description = gvbody.SelectedDataKey("Item_Desc")
                        .BrandName = txtBrandname.Text
                        .SupplierId = Session("Supplier_Id")
                        .Size = ""
                        .Color = ""
                        .Category = ""
                        .Length = ""
                        .Width = ""
                        .Height = ""
                        .Weight = ""
                        .DepreciatedValue = 0
                        .DepreciatedRate = 0
                        .Status = "Accepted"
                        .save()
                    End With

                ElseIf ddGA.SelectedItem.Value = 792 Or ddGA.SelectedItem.Value = 793 Then
                    'Medicine and Medical Supplies
                    With objMedInfo
                        '.MedicineId = MedicineId
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = Session("Item_ID")
                        .Description = gvbody.SelectedDataKey("Item_Desc")
                        .DrugName = gvbody.SelectedDataKey("Item_Desc")
                        .BrandName = txtBrandname.Text
                        .SupplierId = Session("Supplier_Id")
                        .Dose = ""
                        .Location = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDelivereddate.Text
                        .Depreciatedrate = 0
                        .Depreciatedvalue = 0
                        .save()
                    End With

                    Dim MedicineId As Long
                    MedicineId = objMedInfo.GetValue("Select max(MedicineId) from AMS.TBMedicine_Info ", CommandType.Text)

                    With objMedDtl
                        '.MedicineDtl = MedicineDtl
                        .MedicineID = MedicineId
                        .StockId = StockID
                        .Item_ID = Session("Item_ID")
                        .Form = ""
                        .OTCRx = ""
                        .Mftgdate = DateTime.Today.AddDays(-30).ToShortDateString()
                        .Alert = "01/01/2000"
                        .Batch = ""
                        .Lot = ""
                        .ActualPrice = 0.0
                        .EpiryDate = DateTime.Today.AddDays(730).ToShortDateString()
                        .save()
                    End With

                ElseIf ddGA.SelectedItem.Value = 791 Then
                    'FOOD
                    With objFood
                        '.Food_ID = Food_ID
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = Session("Item_ID")
                        .ActualPrice = txtContractprice.Text
                        .ItemDesc = gvbody.SelectedDataKey("Item_Desc")
                        .BrandName = txtBrandname.Text
                        .Supplier_Id = Session("Supplier_Id")
                        .Form = ""
                        .OTCRx = ""
                        .Batch = ""
                        .Lot = ""
                        .Storage = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDelivereddate.Text
                        .Mftgdate = "01/01/1900"
                        .EpiryDate = "01/01/1900"
                        .Alert = "01/01/1900"
                        .Depreciationrate = 0.0
                        .Depreciationvalue = 0.0
                        .save()
                    End With

                ElseIf ddGA.SelectedItem.Value = 799 Then
                    'Water
                    With objWater
                        '.Water_ID = Water_ID
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = Session("Item_ID")
                        .ActualPrice = txtContractprice.Text
                        .ItemDesc = gvbody.SelectedDataKey("Item_Desc")
                        .BrandName = txtBrandname.Text
                        .Supplier_Id = Session("Supplier_Id")
                        .Form = ""
                        .OTCRx = ""
                        .Batch = ""
                        .Lot = ""
                        .Storage = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDelivereddate.Text
                        .Mftgdate = "01/01/1900"
                        .EpiryDate = "01/01/1900"
                        .Alert = "01/01/1900"
                        .Depreciationrate = 0.0
                        .Depreciationvalue = 0.0
                        .save()
                    End With

                Else 'NonFood & Others
                    With objNonFood
                        '.NonFood_ID = NonFood_ID
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = Session("Item_ID")
                        .ActualPrice = txtContractprice.Text
                        .ItemDesc = gvbody.SelectedDataKey("Item_Desc")
                        .BrandName = txtBrandname.Text
                        .Supplier_Id = Session("Supplier_Id")
                        .Form = ""
                        .OTCRx = ""
                        .Batch = ""
                        .Lot = ""
                        .Storage = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDelivereddate.Text
                        .Mftgdate = "01/01/1900"
                        .EpiryDate = "01/01/1900"
                        .Alert = "01/01/1900"
                        .Depreciationrate = 0.0
                        .Depreciationvalue = 0.0
                        .save()
                    End With
                End If

            Catch ex As Exception
            End Try

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnPrev.Enabled = False

            Panel_IA.Enabled = False
            btnSave.Enabled = False
            btnPreview.Enabled = True

            gvbody.DataSource = Nothing
            gvbody.DataBind()

        End If


    End Sub

    Protected Sub ddInspectedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim air As String
        air = objDerived.GetValue("select [AMS].[func_GenerateAIR]( '" & Date.Today.ToString("MM/dd/yyyy") & "')", CommandType.Text)

        objhdr.AIR_No = air
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Supplier_Id") = ddSupplier.SelectedItem.Value
    End Sub

 
    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnSave.Text = "NEXT" Then
            btnPrev.Enabled = False
            lblPR.ForeColor = Color.DimGray

        ElseIf btnSave.Text = "NEXT - PURCHASED ORDER" Then
            btnPrev.Enabled = False
            lblPR.ForeColor = Color.Blue
            lblPO.ForeColor = Color.DimGray

        ElseIf btnSave.Text = "NEXT - INSPECTION & ACCEPTANCE" Then
            btnSave.Text = "NEXT - PURCHASED ORDER"
            btnPrev.Enabled = True
            Panel_PR.Enabled = True
            Panel_PO.Enabled = False

            lblPO.ForeColor = Color.DimGray
            lblPR.ForeColor = Color.Blue

            '=-= Refresh PR Panel
            ddDepartment.Enabled = True
            Dim dept As New DataTable
            dept = objDerived.GetDataTable("SELECT * FROM AMS.Respcenter order BY RespCenter", CommandType.Text) '("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
            ddDepartment.DataSource = dept
            ddDepartment.DataTextField = ("RespCenter")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddFucntion.DataSource = Nothing
            ddFucntion.DataBind()
            ddFucntion.Items.Insert(0, "Select")

            ddPRrequestedby.DataSource = Nothing
            ddPRrequestedby.DataBind()
            ddPRrequestedby.Items.Insert(0, "Select")

            ddApprovedby.Enabled = False
            ddApprovedby.DataSource = Nothing
            ddApprovedby.DataBind()
            ddApprovedby.Items.Insert(0, "Select")

        ElseIf btnSave.Text = "SAVE" Then
            btnSave.Text = "NEXT - INSPECTION & ACCEPTANCE"
            btnPrev.Enabled = True
            Panel_PR.Enabled = False
            Panel_PO.Enabled = True
            Panel_IA.Enabled = False

            lblPO.ForeColor = Color.Blue
            lblAIR.ForeColor = Color.DimGray

        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "ICS"
        Me.Page.Response.Redirect("~/Inventory/t_rpt_receiving.aspx")
    End Sub
End Class
