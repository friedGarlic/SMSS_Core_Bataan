Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Inventory_t_encoding_supplies
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim rcv As New Receiving.t_receiving
    Dim rcv_dtl As New Receiving.t_receiving_dtl
    Dim AuditTrail As New Audit_Trail

#Region "BDal"
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

    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set
    End Property

    Private Property pListitem() As DataTable
        Get
            Return CType(Session("pListitem"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pListitem") = value
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
#End Region

#Region "DataTables"
    Public Function temp_dtSupplies(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Code", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Unit_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Code") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("price") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Unit_ID") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function temp_dtInventory(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("price", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("price") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            pAccounts = objDerived.GetDataTable("SELECT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = 2 ORDER BY GA_Title", CommandType.Text)
            ddGA.DataSource = pAccounts
            ddGA.DataTextField = ("GA_Title2")
            ddGA.DataValueField = ("GA_ID")
            ddGA.DataBind()
            ddGA.Items.Insert(0, "Select")

            grdGoods.DataSource = temp_dtSupplies(5)
            grdGoods.DataBind()

            grdItems.DataSource = temp_dtInventory(5)
            grdItems.DataBind()

            Session("Search") = 0

            LoadDept()

            rbChoice.SelectedIndex = 0
            loadrbchoice()

            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")


        End If
    End Sub
    Protected Sub LoadDept()
        Dim dept As New DataTable
        dept = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text) '("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
        ddDepartment.DataSource = dept
        ddDepartment.DataTextField = ("RC_Name")
        ddDepartment.DataValueField = ("RC_ID")
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        txtDeliveredDate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtDateRecieved.Text = Date.Today.ToString("MM/dd/yyyy")
        txtDateInspected.Text = Date.Today.ToString("MM/dd/yyyy")
        txtDateAccepted.Text = Date.Today.ToString("MM/dd/yyyy")
    End Sub


    Protected Sub ddGA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadRefresh()

        Session("GA_ID") = ddGA.SelectedItem.Value
        Session("Year") = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))

        grdGoods.Columns(6).Visible = True
        grdGoods.Columns(5).Visible = True

        ' pListitem = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesList_wPrice] '" & ddGA.SelectedItem.Value & "','" & pAccounts.Rows(ddGA.SelectedIndex - 1)("BGA_ID") & "','" & Session("Year") & "'", CommandType.Text)
        pListitem = objDerived.GetDataTable("EXEC [AMS].[sp_SuppliesList_wPrice] '" & ddGA.SelectedItem.Value & "','" & pAccounts.Rows(ddGA.SelectedIndex - 1)("BGA_ID") & "','" & Session("Year") & "'", CommandType.Text)

        grdGoods.DataSource = pListitem
        grdGoods.DataBind()

        grdItems.DataSource = Nothing
        grdItems.DataBind()

        btnSearch.Enabled = True

        grdGoods.Columns(6).Visible = False
        grdGoods.Columns(5).Visible = False

    End Sub

    Protected Sub grdGoods_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Session("Search") = 0 Then
            'pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_withPrice '" & ddGA.SelectedItem.Value & "','" & pAccounts.Rows(ddGA.SelectedIndex - 1)("BGA_ID") & "','" & Session("Year") & "'", CommandType.Text)
            grdGoods.PageIndex = e.NewPageIndex
            grdGoods.DataSource = pListitem
            grdGoods.DataBind()

        ElseIf Session("Search") = 1 Then
            'Dim myview As DataView
            'myview = pListitem.DefaultView
            'myview.RowFilter = "Item_desc like '%" & txtSearch.Text.ToString & "%' "
            'grdGoods.PageIndex = e.NewPageIndex
            'grdGoods.DataSource = myview
            'grdGoods.DataBind()

            Dim myview As DataView
            myview = pListitem.DefaultView

            If ddSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Item_Code like '%" & txtSearch.Text.ToString & "%' "
            Else
                myview.RowFilter = "Item_desc like '%" & txtSearch.Text.ToString & "%' "
            End If
            grdGoods.PageIndex = e.NewPageIndex
            grdGoods.DataSource = myview
            grdGoods.DataBind()

        End If
       
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pListitem.DefaultView

        If ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "Item_Code like '%" & txtSearch.Text.ToString & "%' "
        Else
            myview.RowFilter = "Item_desc like '%" & txtSearch.Text.ToString & "%' "
        End If

        grdGoods.DataSource = myview
        grdGoods.DataBind()

        Session("Search") = 1
    End Sub

    Protected Sub btnAddGoods_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox
        Dim dt As New DataTable
        Dim dr As DataRow

        Dim dt2 As New DataTable
        Dim dr2 As DataRow

        grdGoods.Columns(6).Visible = True
        grdGoods.Columns(5).Visible = True

        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Unit_ID", GetType(Long))
        dt.Columns.Add("Price", GetType(Decimal))

        If grdItems.Rows.Count = 0 Then
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                cb = CType(Me.grdGoods.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    dr = dt.NewRow
                    dr("Item_ID") = CType(grdGoods.Rows(i).Cells(4).FindControl("lblItem_ID"), Label).Text  'pListitem.Rows(i)("Item_ID")
                    dr("Item_Desc") = CType(grdGoods.Rows(i).Cells(1).FindControl("lblItem_Desc"), Label).Text 'pListitem.Rows(i)("Item_Desc")
                    dr("Unit") = CType(grdGoods.Rows(i).Cells(2).FindControl("lblUnit"), Label).Text
                    dr("Unit_ID") = CType(grdGoods.Rows(i).Cells(5).FindControl("lblUnit_ID"), Label).Text
                    dr("Price") = CType(grdGoods.Rows(i).Cells(3).FindControl("lblPrice"), Label).Text
                    dt.Rows.Add(dr)

                    pItems = dt

                    cb.Checked = False
                End If
            Next

        Else
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                cb = CType(Me.grdGoods.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    dt2 = pItems
                    dr2 = dt2.NewRow
                    dr2("Item_ID") = CType(grdGoods.Rows(i).Cells(4).FindControl("lblItem_ID"), Label).Text
                    dr2("Item_Desc") = CType(grdGoods.Rows(i).Cells(1).FindControl("lblItem_Desc"), Label).Text
                    dr2("Unit") = CType(grdGoods.Rows(i).Cells(2).FindControl("lblUnit"), Label).Text
                    dr2("Unit_ID") = CType(grdGoods.Rows(i).Cells(5).FindControl("lblUnit_ID"), Label).Text
                    dr2("Price") = CType(grdGoods.Rows(i).Cells(3).FindControl("lblPrice"), Label).Text
                    dt2.Rows.Add(dr2)

                    pItems = dt2

                    cb.Checked = False
                End If
            Next
        End If

        grdItems.DataSource = pItems
        grdItems.DataBind()

        grdGoods.Columns(6).Visible = False
        grdGoods.Columns(5).Visible = False

    End Sub

    Protected Sub txtPOPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Decimal
        For i As Integer = 0 To grdItems.Rows.Count - 1
            Dim txtPrice As TextBox = CType(grdItems.Rows(i).FindControl("txtPOPrice"), TextBox)
            Dim txtqty As TextBox = CType(grdItems.Rows(i).FindControl("txtPOQty"), TextBox)

            Dim TCost As Decimal = FormatNumber(txtPrice.Text * txtqty.Text, 2)

            CType(grdItems.Rows(i).FindControl("lblTotal"), Label).Text = FormatNumber(TCost, 2)
            x = x + (txtPrice.Text * txtqty.Text)

            Dim txtPOPrice As TextBox = TryCast(sender, TextBox)
            txtPOPrice.text = FormatNumber(txtPOPrice.text, 2)
        Next

        CType(grdItems.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

    End Sub

    Protected Sub txtPOQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Decimal
        For i As Integer = 0 To grdItems.Rows.Count - 1
            Dim txtPrice As TextBox = CType(grdItems.Rows(i).FindControl("txtPOPrice"), TextBox)
            Dim txtqty As TextBox = CType(grdItems.Rows(i).FindControl("txtPOQty"), TextBox)

            Dim TCost As Decimal = FormatNumber(txtPrice.Text * txtqty.Text, 2)

            CType(grdItems.Rows(i).FindControl("lblTotal"), Label).Text = FormatNumber(TCost, 2)
            x = x + (txtPrice.Text * txtqty.Text)

            Dim txtPOQty As TextBox = TryCast(sender, TextBox)
            txtPOQty.Text = FormatNumber(txtPOQty.Text, 2)
        Next

        CType(grdItems.FooterRow.Cells(5).FindControl("lblTotalAmount"), Label).Text = FormatNumber(x, 2)

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.Enabled = True

        Dim funct As New DataTable
        'funct = objDerived.GetDataTable("select Office_id as Rc_id,Function_id,Function_desc from ams.vw_functions  where Office_id = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        funct = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        ddFunction.DataSource = funct
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim requestedby As New DataTable
        requestedby = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        ddPRrequestedby.DataSource = requestedby
        ddPRrequestedby.DataTextField = ("full_name")
        ddPRrequestedby.DataValueField = ("empID")
        ddPRrequestedby.DataBind()
        ddPRrequestedby.Items.Insert(0, "Select")

        Dim supp As New DataTable
        supp = objDerived.GetDataTable("Select * from dbo.Supplier order by SuppName", CommandType.Text)
        ddSupplier.DataSource = supp
        ddSupplier.DataTextField = ("SuppName")
        ddSupplier.DataValueField = ("Supplier_Id")
        ddSupplier.DataBind()
        ddSupplier.Items.Insert(0, "Select")

        Dim Rcv As New DataTable
        Rcv = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 and division_key = 86", CommandType.Text)
        ddReceivedBy.DataSource = Rcv
        ddReceivedBy.DataTextField = ("full_name")
        ddReceivedBy.DataValueField = ("empID")
        ddReceivedBy.DataBind()
        ddReceivedBy.Items.Insert(0, "Select")

        Dim approvedby As New DataTable
        approvedby = objDerived.GetDataTable("SELECT Distinct * FROM  HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        ddApprovedby.DataSource = approvedby
        ddApprovedby.DataTextField = ("full_name")
        ddApprovedby.DataValueField = ("empID")
        ddApprovedby.DataBind()
        ddApprovedby.Items.Insert(0, "Select")

        Dim ins As New DataTable
        ins = objDerived.GetDataTable("Select * from HRMS.view_signatory where position_desc like '%Inspector%'", CommandType.Text)
        ddInspectedby.DataSource = ins
        ddInspectedby.DataTextField = ("full_name")
        ddInspectedby.DataValueField = ("Signatory_ID")
        ddInspectedby.DataBind()
        ddInspectedby.Items.Insert(0, "Select")

        '=-= ACCEPTED BY GSD HEAD
        Dim accpt As New DataTable
        accpt = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        ddacceptedby.DataSource = accpt
        ddacceptedby.DataTextField = ("full_name")
        ddacceptedby.DataValueField = ("Signatory_ID")
        ddacceptedby.DataBind()
        ddacceptedby.Items.Insert(0, "Select")

        ddacceptedby.Enabled = True
        ddInspectedby.Enabled = True
        ddSupplier.Enabled = True
        ddApprovedby.Enabled = True
        ddReceivedBy.Enabled = True
        ddPRrequestedby.Enabled = True
        ddSupplier.Enabled = True

    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Supplier_ID") = ddSupplier.SelectedItem.Value

    End Sub

    Protected Sub ddReceivedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
     
    End Sub

    Protected Sub ddInspectedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
     
    End Sub

    Protected Sub ddPRrequestedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
   
    End Sub

    Protected Sub ddApprovedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdItems.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No Data Found.")
            Exit Sub

        ElseIf ddDepartment.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select Department.")
            Exit Sub

        ElseIf ddFunction.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select Function.")
            Exit Sub

        ElseIf ddSupplier.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select Supplier.")
            Exit Sub

        ElseIf ddPRrequestedby.SelectedItem.Text = "Select" Or ddApprovedby.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatories.")
            Exit Sub

        ElseIf ddReceivedBy.SelectedItem.Text = "Select" Or ddInspectedby.SelectedItem.Text = "Select" Or ddacceptedby.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatories.")
            Exit Sub

        ElseIf txtPONumber.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Input PO Number.")
            Exit Sub

        End If

        '--------------------------------------------------------------
        '=-= SAVE AMS.Tb_Receiving
        With rcv
            .Received_Date = txtDateRecieved.Text
            .ReceivedBY = ddReceivedBy.SelectedItem.Value
            .POHdr_ID = Session("POHdr_ID")
            .PO_No = txtPONumber.Text
            .Supplier_ID = ddSupplier.SelectedItem.Value
            .GA_ID = Session("GA_ID")
            .isAccepted = False
            .UserID = Session("@UserName")
        End With

        Dim rcvID As Long = rcv.save
        Session("Received_ID") = rcvID
        objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspectedby.SelectedItem.Value & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)

        Dim total As Decimal = 0
        For i As Integer = 0 To pItems.Rows.Count - 1
            Dim txtPrice As TextBox = CType(grdItems.Rows(i).FindControl("txtPOPrice"), TextBox)
            Dim txtqty As TextBox = CType(grdItems.Rows(i).FindControl("txtPOQty"), TextBox)

            '=-= SAVE AMS.Tb_Receiving_Dtl
            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = pItems.Rows(i)("Item_ID")
                .PO_Qty = txtqty.Text
                .Qty_Received = txtqty.Text
                .Cost = txtPrice.Text
                .Condition = ""
                .Location = ""
            End With

            Dim RcvDtl_ID As Long = rcv_dtl.save

            Dim t1 As Decimal
            t1 = txtPrice.Text * txtqty.Text
            total = total + t1

        Next

        Session("ContractPrice") = total

        '=-= SAVE OF PURCHASED ORDER
        Dim pohdr_id As Long

        POhdr.PO_No = txtPONumber.Text
        POhdr.PO_Date = txtDeliveredDate.Text
        POhdr.Supplier_ID = ddSupplier.SelectedItem.Value
        POhdr.mode_of_procurement_id = 2
        POhdr.DeliveryTerm = 0
        POhdr.paymentTerm = 0
        POhdr.DeliveryDate = txtDeliveredDate.Text
        POhdr.DeliveryPlace = ""
        POhdr.isDelivered = True
        POhdr.isDelivered = True
        POhdr.pre_procurement_hdr_id = 0
        POhdr.withdv = False
        'POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
        POhdr.isStag = False
        POhdr.isContinueCutOff = False
        POhdr.isStopForCutOff = False
        POhdr.isShoppingA = False
        POhdr.isPublicInfra = False
        POhdr.isStraight = True
        POhdr.isApproved_PO_Mayor = True
        POhdr.isReceived_PO_Mayor = True
        POhdr.DateApproved_PO_Mayor = txtDeliveredDate.Text
        POhdr.DateReceived_PO_Mayor = txtDeliveredDate.Text
        POhdr.DateDisApprove = "01/01/1900"
        POhdr.isGasoline = False
        POhdr.isReimbursement = False

        Dim po_id As New DataTable
        po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & txtPONumber.Text & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
        If po_id.Rows.Count = 0 Then
            POhdr.ContractPrice = CType(Session("ContractPrice"), Decimal)
            pohdr_id = POhdr.save()
        Else
            Dim poid As Integer
            Dim TAmount As Decimal
            poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & txtPONumber.Text & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
            TAmount = objDerived.GetValue("Select ContractPrice from ams.po_hdr where pohdr_id = '" & poid & "'", CommandType.Text)

            POhdr.ContractPrice = CType(TAmount + CType(Session("ContractPrice"), Decimal), Decimal)
            POhdr.POHdr_ID = poid
            pohdr_id = POhdr.update()
        End If

        objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & Session("GA_ID") & "', ProjectName = 'Manual Encode', RC_ID = '" & ddDepartment.SelectedItem.Value & "', Function_ID = '" & ddFunction.SelectedItem.Value & "' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)
        Session("POHdr_ID") = pohdr_id

        Try
            '=-= SAVE OF INSPECTION & ACCEPTANCE
            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]('" & txtDateAccepted.Text & "')", CommandType.Text)
            With objhdr
                .AIR_No = air
                .AIR_Date = txtDateAccepted.Text
                .Date_Received = txtDateRecieved.Text
                .Date_Inspect = txtDateInspected.Text
                .Date_Accepted = txtDateAccepted.Text
                .Invoice_No = txtInvoice.Text
                .Invoice_date = txtDateAccepted.Text
                .PO_No = txtPONumber.Text
                .Supplier_ID = Session("Supplier_ID")
                .Signatory1 = ddReceivedBy.SelectedItem.Text
                .Signatory2 = ddInspectedby.SelectedItem.Text
                .Signatory3 = ddacceptedby.SelectedItem.Text
                .isComplete = Session("isComplete")
                .POHdr_ID = Session("POHdr_ID")
                'objhdr.remarks = txtIAremarks.Text
                .RC_ID = ddDepartment.SelectedItem.Value
                .Function_ID = ddFunction.SelectedItem.Value
            End With

            airhdr_id = objhdr.save()
            Session("AIRHDR_ID") = airhdr_id
            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)


            For i As Integer = 0 To pItems.Rows.Count - 1
                Dim txtPrice As TextBox = CType(grdItems.Rows(i).FindControl("txtPOPrice"), TextBox)
                Dim txtqty As TextBox = CType(grdItems.Rows(i).FindControl("txtPOQty"), TextBox)

                '=-= PO Details Save
                POdtl.POHdr_ID = Session("POHdr_ID")
                POdtl.Item_ID = pItems.Rows(i)("Item_ID")
                POdtl.cost = txtPrice.Text
                POdtl.qty = txtqty.Text
                POdtl.remarks = "Manual Encode"
                POdtl.save()

                '=-= AIR DETAILS
                objdtl.Item_ID = pItems.Rows(i)("Item_ID")
                objdtl.Qty = txtqty.Text
                objdtl.Cost = CType(txtPrice.Text, Decimal)
                objdtl.AIRHdr_ID = Session("AIRHDR_ID")
                objdtl.GA_ID = Session("GA_ID")
                Dim iaDtl_ID As Integer = objdtl.save()

                Session("AIRDtl_ID") = iaDtl_ID
                '=-= SAVE STOCK
                With objStock
                    '.StockID = StockID
                    .StockDate = txtDateAccepted.Text
                    .Item_ID = pItems.Rows(i)("Item_ID")
                    .Qty = txtqty.Text
                    .Balance = txtqty.Text
                    '.Location = txtLocation.Text
                    .Expiration_Date = "1/1/1900"
                    .Cost = CType(txtPrice.Text, Decimal)
                    .Issuance = 0
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                    .Project_ID = 0
                    .Program_id = 0
                    .F_ID = 4
                    .AIRDtl_ID = Session("AIRDtl_ID")
                    .GA_ID = Session("GA_ID")
                End With

                Dim StockID As Long = objStock.save
                objDerived.GetRecords("UPDATE AMS.Stock SET  Received_ID = '" & rcvID & "' WHERE StockID = '" & StockID & "'", CommandType.Text)

                '=-= End of Stock Saving

                '---------------------------------------------------------
                '====== save ledger ========
                With objStockLedger
                    '.StockLedger_ID = StockLedger_ID
                    .StockID = StockID
                    .Trans_Type = "Manual Entry"
                    .Ref = air
                    .AccountablePerson = objDerived.GetValue("SELECT ContactP FROM  dbo.Supplier where Supplier_Id ='" & Session("Supplier_Id") & "' ", CommandType.Text)
                    .Department = ddDepartment.SelectedItem.Text
                    .Position = ""
                    .AcceptedBy = ddacceptedby.SelectedItem.Text
                    .InspectedBy = ddInspectedby.SelectedItem.Text
                    .ReceivedBy = ddReceivedBy.SelectedItem.Text
                    .CreditQty = "0"
                    .CreditUnit = "-"
                    .CreditCost = "0.00"
                    .dDate = txtDateAccepted.Text
                    .Item_ID = pItems.Rows(i)("Item_ID")
                    .DebitQty = txtqty.Text
                    .DebitCost = FormatNumber(CType(txtPrice.Text, Decimal) * txtqty.Text, 2)
                    .DebitUnit = pItems.Rows(i)("Unit") 'objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
                    .BalanceUnit = pItems.Rows(i)("Unit") 'objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
                    .BalanceQty = 0
                    .BalanceCost = 0
                    .save()
                End With


                '=-= END of Stock Ledger


                '------------------------------------------------------
                '=-= Supplies Save
                If ddGA.SelectedItem.Value = 1427 Then
                    'Office Supplies
                    With objOfficeSup
                        '.SuppliesId = SuppliesId
                        .StockID = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .ItemId = pItems.Rows(i)("Item_ID")
                        .Description = pItems.Rows(i)("Item_Desc")
                        .BrandName = ""
                        .SupplierId = Session("Supplier_ID")
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

                    End With

                    Dim Supp_ID As Long = objOfficeSup.save
                    objDerived.GetRecords("UPDATE AMS.TBSupplies_Info SET Received_ID = '" & rcvID & "' WHERE SuppliesId = '" & Supp_ID & "'", CommandType.Text)

                ElseIf ddGA.SelectedItem.Value = 1432 Or ddGA.SelectedItem.Value = 1433 Then
                    'Medicine and Medical Supplies
                    With objMedInfo
                        '.MedicineId = MedicineId
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = pItems.Rows(i)("Item_ID")
                        .Description = pItems.Rows(i)("Item_Desc")
                        .DrugName = ""
                        .BrandName = ""
                        .SupplierId = Session("Supplier_ID")
                        .Dose = ""
                        .Location = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDeliveredDate.Text
                        .Depreciatedrate = 0
                        .Depreciatedvalue = 0
                    End With

                    Dim MedicineId As Long = objMedInfo.save
                    objDerived.GetRecords("UPDATE AMS.TBMedicine_Info SET Received_ID = '" & rcvID & "' WHERE MedicineId = '" & MedicineId & "'", CommandType.Text)

                    With objMedDtl
                        '.MedicineDtl = MedicineDtl
                        .MedicineID = MedicineId
                        .StockId = StockID
                        .Item_ID = pItems.Rows(i)("Item_ID")
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

                ElseIf ddGA.SelectedItem.Value = 1430 Then
                    'FOOD
                    With objFood
                        '.Food_ID = Food_ID
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = pItems.Rows(i)("Item_ID")
                        .ActualPrice = pItems.Rows(i)("Price")
                        .ItemDesc = pItems.Rows(i)("Item_Desc")
                        .BrandName = ""
                        .Supplier_Id = Session("Supplier_ID")
                        .Form = ""
                        .OTCRx = ""
                        .Batch = ""
                        .Lot = ""
                        .Storage = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDeliveredDate.Text
                        .Mftgdate = "01/01/1900"
                        .EpiryDate = "01/01/1900"
                        .Alert = "01/01/1900"
                        .Depreciationrate = 0.0
                        .Depreciationvalue = 0.0
                    End With

                    Dim FoodID As Long = objFood.save
                    objDerived.GetRecords("UPDATE AMS.TbFood SET Received_ID = '" & rcvID & "' WHERE Food_ID = '" & FoodID & "'", CommandType.Text)


                ElseIf ddGA.SelectedItem.Value = 1441 Then
                    'Water
                    With objWater
                        '.Water_ID = Water_ID
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = pItems.Rows(i)("Item_ID")
                        .ActualPrice = pItems.Rows(i)("Price")
                        .ItemDesc = pItems.Rows(i)("Item_Desc")
                        .BrandName = ""
                        .Supplier_Id = Session("Supplier_ID")
                        .Form = ""
                        .OTCRx = ""
                        .Batch = ""
                        .Lot = ""
                        .Storage = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDeliveredDate.Text
                        .Mftgdate = "01/01/1900"
                        .EpiryDate = "01/01/1900"
                        .Alert = "01/01/1900"
                        .Depreciationrate = 0.0
                        .Depreciationvalue = 0.0
                    End With

                    Dim WaterID As Long = objWater.save
                    objDerived.GetRecords("UPDATE AMS.TbWater SET Received_ID = '" & rcvID & "' WHERE Water_ID = '" & WaterID & "'", CommandType.Text)

                Else 'NonFood & Others
                    With objNonFood
                        '.NonFood_ID = NonFood_ID
                        .StockId = StockID
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Item_ID = pItems.Rows(i)("Item_ID")
                        .ActualPrice = pItems.Rows(i)("Price")
                        .ItemDesc = pItems.Rows(i)("Item_Desc")
                        .BrandName = ""
                        .Supplier_Id = Session("Supplier_ID")
                        .Form = ""
                        .OTCRx = ""
                        .Batch = ""
                        .Lot = ""
                        .Storage = ""
                        .Status = "Accepted"
                        .DeliveryDate = txtDeliveredDate.Text
                        .Mftgdate = "01/01/1900"
                        .EpiryDate = "01/01/1900"
                        .Alert = "01/01/1900"
                        .Depreciationrate = 0.0
                        .Depreciationvalue = 0.0
                    End With

                    Dim NonFoodID As Long = objNonFood.save
                    objDerived.GetRecords("UPDATE AMS.TbNonFood SET Received_ID = '" & rcvID & "' WHERE NonFood_ID = '" & NonFoodID & "'", CommandType.Text)

                End If
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnPreview.Enabled = True
            btnSave.Enabled = False

            LoadRefresh()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "Supplies"
        Me.Page.Response.Redirect("~/procurement/t_rpt_receiving.aspx")
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        loadrbchoice()
    End Sub

    Protected Sub loadrbchoice()
        If rbChoice.SelectedItem.Value = 1 Then
            '=-= Partial Delivery
            Session("isComplete") = False

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            '=-= Complete Delivery
            Session("isComplete") = True

        End If
    End Sub

    Protected Sub LoadRefresh()
        LoadDept()

        ddFunction.ClearSelection()
        ddFunction.ClearSelection()
        ddacceptedby.ClearSelection()
        ddInspectedby.ClearSelection()
        ddSupplier.ClearSelection()
        ddApprovedby.ClearSelection()
        ddReceivedBy.ClearSelection()
        ddPRrequestedby.ClearSelection()
        ddSupplier.ClearSelection()

        ddFunction.Enabled = False
        ddacceptedby.Enabled = False
        ddInspectedby.Enabled = False
        ddSupplier.Enabled = False
        ddApprovedby.Enabled = False
        ddReceivedBy.Enabled = False
        ddPRrequestedby.Enabled = False
        ddSupplier.Enabled = False

        txtInvoice.Text = ""
        txtPONumber.Text = ""
    End Sub
End Class
