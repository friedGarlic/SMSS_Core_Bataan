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

Partial Class Inventory_t_inventory_encoding
    Inherits System.Web.UI.Page
    Dim rcv As New Receiving.t_receiving
    Dim rcv_dtl As New Receiving.t_receiving_dtl


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

    Dim objPropHdr As New t_property_hdr
    Dim objPropDtl As New t_property_dtl
    Dim objLedger As New t_PropertyLedger

    Dim objEquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Dim objEquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details

    Dim objMachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim objMachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl

    Dim objMotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim objMotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl

    Dim objAmbulanceInfo As New ConsolidatedPropertySaving.TbAmbulance_Info
    Dim objAmbulanceDtl As New ConsolidatedPropertySaving.TbAmbulance_Dtl

    Dim objFurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Dim objFurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl

    Dim objLandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Dim objBldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details

    Dim objPropSerial As New ConsolidatedPropertySaving.PropSerial

#End Region
#Region "Property"

    Private Property pListOBR() As DataTable
        Get
            Return CType(Session("pListOBR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pListOBR") = value
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
    Private Property pPopupitems() As DataTable
        Get
            Return CType(Session("pPopupitems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPopupitems") = value
        End Set
    End Property
    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
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
    Private Property PR() As DataTable
        Get
            Return CType(Session("PR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PR") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        'End If

        If Not Page.IsPostBack Then
            ddAllotment.DataSource = objDerived.GetDataTable("Exec dbo.sp_Accounts_Category '" & 3 & "'", CommandType.Text)
            ddAllotment.DataTextField = ("GA_Title")
            ddAllotment.DataValueField = ("GA_ID")
            ddAllotment.DataBind()
            ddAllotment.Items.Insert(0, "Select")


            Dim dept As New DataTable
            'dept = objDerived.GetDataTable("SELECT * FROM AMS.Respcenter order BY RespCenter", CommandType.Text)
            dept = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataSource = dept
            ddDepartment.DataTextField = ("RC_Name")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddLandDepartment.DataSource = dept
            ddLandDepartment.DataTextField = ("RC_Name")
            ddLandDepartment.DataValueField = ("RC_ID")
            ddLandDepartment.DataBind()
            ddLandDepartment.Items.Insert(0, "Select")

            pItems = Nothing
            gvbody.DataSource = pItems
            gvbody.DataBind()

            lblPR.ForeColor = Color.DimGray
            lblPO.ForeColor = Color.DimGray
            lblAIR.ForeColor = Color.DimGray

            'Dim CYear As String = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))
            Session("CYear") = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchItem.ClientID & "')")
        txtsearchitems.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub
    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddAllotment.SelectedItem.Value = 1060 Or ddAllotment.SelectedItem.Value = 1062 Or ddAllotment.SelectedItem.Value = 1067 Then
            '==== LANDS
            Me.mvEncoding.SetActiveView(Me.vwLand)
            txtAcqDate.Text = Date.Today.ToString("MM/dd/yyyy")
        Else
            '==== EQUIPMENTS
            Me.mvEncoding.SetActiveView(Me.vwEquipments)
            'btnPrev.Visible = True
            'btnSave.Visible = True
            'btnPreview.Visible = True
        End If

        btnadd.Enabled = True

        If ddAllotment.SelectedItem.Value = 0 Then
            pItems = Nothing
            Me.gvitems.Columns(4).Visible = True
            gvitems.DataSource = Nothing
            gvitems.DataBind()
        Else
            pPopupitems = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories] '" & ddAllotment.SelectedItem.Value & "', '" & Session("CYear") & "'", CommandType.Text)
            gvitems.DataSource = pPopupitems
            gvitems.DataBind()

            gvbody.DataSource = pPopupitems
            gvbody.DataBind()
        End If

        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False

    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        btnadd.Enabled = False
        Try
            gvitems.Columns(6).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True

            Dim cb As CheckBox
            Dim tb2, tb3, tb4, tb5 As New TextBox
            Dim dr As DataRow
            Dim dt As New DataTable
            dt.Columns.Add("item_desc")
            dt.Columns.Add("Description")
            dt.Columns.Add("qty")
            dt.Columns.Add("price", GetType(Decimal))
            dt.Columns.Add("total", GetType(Decimal))
            dt.Columns.Add("Item_ID")
            dt.Columns.Add("GA_ID")
            dt.Columns.Add("GA_Code")
            dt.Columns.Add("Item_Code")

            If pItems Is Nothing Then
                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                    If cb.Checked = True Then
                        dr = dt.NewRow
                        dr("item_desc") = gvitems.Rows(i).Cells(2).Text
                        dr("Description") = gvitems.Rows(i).Cells(3).Text
                        dr("qty") = "0"
                        dr("price") = CType(gvitems.Rows(i).FindControl("lblprice"), Label).Text
                        dr("total") = CType("0.00", Decimal)
                        dr("Item_ID") = CType(gvitems.Rows(i).FindControl("lblItem_ID"), Label).Text
                        dr("GA_ID") = CType(gvitems.Rows(i).FindControl("lblGA_ID"), Label).Text
                        dr("GA_code") = CType(gvitems.Rows(i).FindControl("lblGA_code"), Label).Text
                        dr("Item_Code") = gvitems.Rows(i).Cells(1).Text
                        dt.Rows.Add(dr)
                    End If
                Next
                pItems = dt

            Else
                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                    If cb.Checked = True Then
                        dt = pItems
                        dr = dt.NewRow
                        dr("item_desc") = gvitems.Rows(i).Cells(2).Text
                        dr("Description") = gvitems.Rows(i).Cells(3).Text
                        dr("qty") = "0"
                        dr("price") = CType(gvitems.Rows(i).FindControl("lblprice"), Label).Text
                        dr("total") = CType("0.00", Decimal)
                        dr("Item_ID") = CType(gvitems.Rows(i).FindControl("lblItem_ID"), Label).Text
                        dr("GA_ID") = CType(gvitems.Rows(i).FindControl("lblGA_ID"), Label).Text
                        dr("GA_code") = CType(gvitems.Rows(i).FindControl("lblGA_code"), Label).Text
                        dr("Item_Code") = gvitems.Rows(i).Cells(1).Text
                        dt.Rows.Add(dr)
                        pItems = dt
                    End If
                Next
            End If

            gvbody.DataSource = pItems
            gvbody.DataBind()

            Me.Session("search") = False
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Dim qty As TextBox = CType(Me.gvbody.Rows(i).Cells(2).FindControl("txtqty"), TextBox)
                qty.Attributes.Add("onclick", "this.select()")
                qty.Attributes.Add("onFocus", "this.select()")
            Next
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)


        Catch ex As Exception
        End Try
    End Sub
    Protected Sub gvbody_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvbody, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtPRnumber.Text = ""
        Session("Item_ID") = gvbody.SelectedDataKey("Item_ID")
        Session("GA_ID") = gvbody.SelectedDataKey("GA_ID")
        Session("GA_Code") = gvbody.SelectedDataKey("GA_Code")

        lblPR.ForeColor = Color.Blue
        txtPRnumber.Enabled = True
        txtPRdate.Enabled = True
        ddDepartment.Enabled = True
        Panel_PR.Enabled = True
        btnLandSave.Enabled = True

        btnSave.Text = "NEXT - PURCHASED ORDER"
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

        'approvedby = objDerived.GetDataTable("SELECT * FROM dbo.view_CityMayor", CommandType.Text)
        approvedby = objDerived.GetDataTable("SELECT Distinct * FROM  HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
        ddApprovedby.DataSource = approvedby
        ddApprovedby.DataTextField = ("full_name")
        ddApprovedby.DataValueField = ("empID")
        ddApprovedby.DataBind()
        ddApprovedby.Items.Insert(0, "Select")

        ddPRrequestedby.Enabled = False
        ddApprovedby.Enabled = True
    End Sub
    Protected Sub ddApprovedby_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtQty.Enabled = True
        txtPRprice.Enabled = True
        txtPRremarks.Enabled = True
        btnSave.Enabled = True

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.Enabled = True

        If btnSave.Text = "NEXT - PURCHASED ORDER" Then

            If txtPRnumber.Text = "" Or txtPRprice.Text = "" Or txtPRremarks.Text = "" Or txtPRdate.Text = "" Then
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

            Dim mode As New DataTable
            mode = objDerived.GetDataTable("Select * from ams.mode_of_procurement", CommandType.Text)
            ddmodeofprocurement.DataSource = mode
            ddmodeofprocurement.DataTextField = ("mode_description2")
            ddmodeofprocurement.DataValueField = ("mode_of_procurement_id")
            ddmodeofprocurement.DataBind()
            ddmodeofprocurement.Items.Insert(0, "Select")

            btnSave.Text = "NEXT - INSP & ACCPT"
            btnPrev.Enabled = True

            lblPR.ForeColor = Color.DimGray
            lblPO.ForeColor = Color.Blue

        ElseIf btnSave.Text = "NEXT - INSP & ACCPT" Then
            If ddSupplier.SelectedItem.Text = "Select" Or txtPOprice.Text = "" Or ddPaymentterm.SelectedItem.Text = "- Select -" Or ddDeliveryterm.SelectedItem.Text = "Select" Or txtDelivereddate.Text = "" Or txtPOdate.Text = "" Or ddmodeofprocurement.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                Exit Sub
            Else
                Panel_PO.Enabled = False
                Panel_IA.Enabled = True


                Dim Rcv As New DataTable
                Rcv = objDerived.GetDataTable("Select * from HRMS.view_signatory where deptid = 7 and division_key = 86", CommandType.Text)
                ddReceivedBy.DataSource = Rcv
                ddReceivedBy.DataTextField = ("full_name")
                ddReceivedBy.DataValueField = ("Signatory_ID")
                ddReceivedBy.DataBind()
                ddReceivedBy.Items.Insert(0, "Select")

                Dim ins As New DataTable
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

            grdSerial.DataSource = createDatatableBarcode(CType(txtQty.Text, Integer))
            grdSerial.DataBind()

            ModalPopupExtender2.Show()
        End If
    End Sub

    Protected Sub LoadOLDSaving()
        'txtPropnumber.Text = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtIAdate.Text & "', '" & Session("GA_Code") & "')", CommandType.Text)
        'Dim Item_Desc As String
        'Item_Desc = objDerived.GetValue("Select Item_Desc from dbo.m_item where Item_ID ='" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        'Session("Item_Desc") = Item_Desc

        'Try
        '    '=-= SAVE PURCHASED REQUEST
        '    Dim prhdrID As Long
        '    prhdr.PR_Year = Year(CDate(txtPRdate.Text))
        '    prhdr.PR_Date = txtPRdate.Text
        '    prhdr.RC_ID = ddDepartment.SelectedItem.Value
        '    prhdr.Function_ID = ddFucntion.SelectedItem.Value
        '    prhdr.remarks = txtPRremarks.Text
        '    prhdr.Transaction_type = 3
        '    prhdr.Project_ID = 0
        '    prhdr.Program_id = 0
        '    prhdr.ABC = CType(txtABC.Text, Decimal)
        '    prhdr.Requestedby = ddPRrequestedby.SelectedItem.Value
        '    prhdr.Approvedby = ddApprovedby.SelectedItem.Value
        '    prhdr.Date_Submitted = "01/01/1900"
        '    prhdr.Date_gso_rcv = "01/01/1900"
        '    prhdr.IsCancelled = False
        '    prhdr.IsApproved = True
        '    prhdr.isOnBid = True
        '    prhdr.POHdr_ID = 0
        '    prhdr.withWinner = True
        '    prhdr.withOBR = True
        '    prhdr.withPO = True
        '    prhdr.declarationDate = "01/01/1900"
        '    prhdr.rcv_date = "01/01/1900"
        '    prhdr.mode_of_procurement_id = ddmodeofprocurement.SelectedItem.Value
        '    prhdr.isPublicInfra = False
        '    prhdr.isStraight = False
        '    prhdr.DateApproved_PR_Mayor = "01/01/1900"
        '    prhdr.DateReceived_PR_Mayor = "01/01/1900"
        '    prhdr.isApproved_PR_Mayor = True
        '    prhdr.isReceived_PR_Mayor = True
        '    prhdr.DateDisApprove = "01/01/1900"
        '    prhdr.isGasoline = False
        '    prhdr.pr_period_key_id = 0
        '    prhdr.pr_invoice_hdr_id = 0
        '    prhdr.isReimbursement = False
        '    prhdr.isContract = False
        '    prhdr.isEditable = False
        '    prhdr.RequestingOfficer = ""
        '    prhdr.Position = ""
        '    prhdr.isContinuing = False
        '    'prhdr.Userid = Me.Session("@UserName").ToString

        '    prhdr.pr_no = txtPRnumber.Text

        '    Dim pr_id As New DataTable
        '    pr_id = objDerived.GetDataTable("Select prhdr_id from ams.pr_hdr where pr_no like '" & txtPRnumber.Text & "'", CommandType.Text)
        '    If pr_id.Rows.Count = 0 Then
        '        prhdrID = prhdr.save
        '    Else
        '        Dim id As Integer
        '        id = objDerived.GetValue("Select prhdr_id from ams.pr_hdr where pr_no like '" & txtPRnumber.Text & "'", CommandType.Text)
        '        prhdr.prhdr_id = id
        '        prhdrID = prhdr.update
        '    End If
        '    Session("PRHdr_ID") = prhdrID

        '    '=-= PR Details Save
        '    Dim dtPR As New DataTable
        '    dtPR = objDerived.GetDataTable("select PRDtlID from AMS.PR_Dtl where PRHdr_ID =  '" & Session("PRHdr_ID") & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        '    If dtPR.Rows.Count = 0 Then
        '        prdtl.PRHdr_ID = Session("PRHdr_ID")
        '        prdtl.Item_ID = Session("Item_ID")
        '        prdtl.Project_title = txtPRremarks.Text
        '        prdtl.Qty = 1
        '        prdtl.Cost = txtPRprice.Text
        '        prdtl.ppmp_dtl_id = 0
        '        prdtl.save()

        '    Else
        '        Dim dtl_idpr As Integer
        '        dtl_idpr = objDerived.GetValue("select PRDtlID from AMS.PR_Dtl where PRHdr_ID =  '" & Session("PRHdr_ID") & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)

        '        Dim dtqty As Integer
        '        dtqty = objDerived.GetValue("select qty from AMS.PR_Dtl where PRHdr_ID =  '" & Session("PRHdr_ID") & "' and Item_ID = '" & Session("Item_ID") & "' and PRDtlID = '" & dtl_idpr & "'", CommandType.Text)

        '        prdtl.PRDtlID = dtl_idpr
        '        prdtl.PRHdr_ID = Session("PRHdr_ID")
        '        prdtl.Item_ID = Session("Item_ID")
        '        prdtl.Project_title = txtPRremarks.Text
        '        prdtl.ppmp_dtl_id = 0
        '        prdtl.Qty = dtqty + 1
        '        prdtl.Cost = txtPRprice.Text
        '        prdtl.update()

        '    End If

        '    '=-= END OF PURCHASED REQUEST

        '    '--------------------------------------------------------------
        '    '=-= SAVE OF PURCHASED ORDER
        '    Dim pohdr_id As Long

        '    POhdr.PO_No = txtPOnumber.Text
        '    POhdr.PO_Date = txtPOdate.Text
        '    POhdr.Supplier_ID = ddSupplier.SelectedItem.Value
        '    POhdr.mode_of_procurement_id = ddmodeofprocurement.SelectedItem.Value
        '    POhdr.DeliveryTerm = ddDeliveryterm.SelectedItem.Text
        '    POhdr.paymentTerm = ddPaymentterm.SelectedItem.Text
        '    POhdr.DeliveryDate = "01/01/1900"
        '    POhdr.DeliveryPlace = ""
        '    POhdr.isDelivered = True
        '    POhdr.isDelivered = True
        '    POhdr.pre_procurement_hdr_id = 0
        '    POhdr.withdv = False
        '    POhdr.ContractPrice = CType(txtContractprice.Text, Decimal)
        '    POhdr.isStag = False
        '    POhdr.isContinueCutOff = False
        '    POhdr.isStopForCutOff = False
        '    POhdr.isShoppingA = False
        '    POhdr.isPublicInfra = False
        '    POhdr.isStraight = True
        '    POhdr.isApproved_PO_Mayor = True
        '    POhdr.isReceived_PO_Mayor = True
        '    POhdr.DateApproved_PO_Mayor = "01/01/1900"
        '    POhdr.DateReceived_PO_Mayor = "01/01/1900"
        '    POhdr.DateDisApprove = "01/01/1900"
        '    POhdr.isGasoline = False
        '    POhdr.isReimbursement = False

        '    Dim po_id As New DataTable
        '    po_id = objDerived.GetDataTable("Select pohdr_id from ams.po_hdr where po_no like '" & txtPOnumber.Text & "'", CommandType.Text)
        '    If po_id.Rows.Count = 0 Then
        '        pohdr_id = POhdr.save()


        '    Else
        '        Dim poid As Integer
        '        poid = objDerived.GetValue("Select pohdr_id from ams.po_hdr where po_no like '" & txtPOnumber.Text & "'", CommandType.Text)
        '        POhdr.POHdr_ID = poid
        '        pohdr_id = POhdr.update()
        '    End If

        '    objDerived.GetRecords("Update ams.pr_hdr set pohdr_id ='" & pohdr_id & "' where PRHdr_ID = '" & Session("PRHdr_ID") & "'", CommandType.Text)

        '    Session("POHdr_ID") = pohdr_id

        '    '=-= PO Details Save
        '    Dim dtPO As New DataTable
        '    dtPO = objDerived.GetDataTable("select PODtl_ID from AMS.PO_Dtl where POHdr_ID =  '" & Session("POHdr_ID") & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        '    If dtPO.Rows.Count = 0 Then
        '        POdtl.POHdr_ID = Session("POHdr_ID")
        '        POdtl.Item_ID = Session("Item_ID")
        '        POdtl.cost = txtPOprice.Text
        '        POdtl.qty = 1
        '        POdtl.remarks = ""
        '        POdtl.save()
        '    Else
        '        Dim dtl_id As Integer
        '        dtl_id = objDerived.GetValue("select PODtl_ID from AMS.PO_Dtl where POHdr_ID =  '" & Session("POHdr_ID") & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)

        '        Dim po_qty As Integer
        '        po_qty = objDerived.GetValue("Select qty from AMS.PO_Dtl where POHdr_ID =  '" & Session("POHdr_ID") & "' and Item_ID = '" & Session("Item_ID") & "' and PODtl_ID = '" & dtl_id & "'", CommandType.Text)

        '        POdtl.PODtl_ID = dtl_id
        '        POdtl.qty = po_qty + 1
        '        POdtl.POHdr_ID = Session("POHdr_ID")
        '        POdtl.Item_ID = Session("Item_ID")
        '        POdtl.cost = txtPOprice.Text
        '        POdtl.update()

        '    End If


        '    '=-= END OF PURCHASED ORDER

        '    '--------------------------------------------------------------
        '    '=-= SAVE OF INSPECTION & ACCEPTANCE
        '    Dim airhdr_id As Long
        '    Dim air As String
        '    air = objDerived.GetValue("select [AMS].[func_GenerateAIR]( '" & Date.Today.ToString("MM/dd/yyyy") & "')", CommandType.Text)

        '    objhdr.AIR_No = air
        '    objhdr.AIR_Date = txtIAdate.Text
        '    objhdr.Date_Inspect = txtIAdate.Text
        '    objhdr.Date_Received = txtIAdate.Text
        '    objhdr.Invoice_No = txtInvoice.Text
        '    objhdr.Invoice_date = txtIAdate.Text
        '    objhdr.PO_No = txtPOnumber.Text
        '    objhdr.Signatory1 = ddInspectedby.SelectedItem.Text
        '    objhdr.Signatory3 = ddacceptedby.SelectedItem.Text
        '    objhdr.isComplete = True
        '    objhdr.POHdr_ID = Session("POHdr_ID")
        '    objhdr.remarks = txtIAremarks.Text

        '    Dim IA As New DataTable
        '    IA = objDerived.GetDataTable("Select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & Session("POHdr_ID") & "'", CommandType.Text)
        '    If IA.Rows.Count = 0 Then
        '        airhdr_id = objhdr.save()
        '    Else
        '        Dim air_id As Integer
        '        air_id = objhdr.GetValue("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & Session("POHdr_ID") & "'", CommandType.Text)
        '        objhdr.AIRHdr_ID = air_id
        '        airhdr_id = objhdr.update()
        '    End If

        '    Session("AIRHDR_ID") = airhdr_id

        '    '=-= AIR DETAILS
        '    Dim iaDtl_ID As Integer
        '    Dim dtIA As New DataTable
        '    dtIA = objDerived.GetDataTable("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & Session("AIRHDR_ID") & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
        '    If dtIA.Rows.Count = 0 Then
        '        objdtl.Item_ID = Session("Item_ID")
        '        objdtl.Qty = 1
        '        objdtl.Cost = txtPOprice.Text
        '        objdtl.AIRHdr_ID = Session("AIRHDR_ID")
        '        objdtl.GA_ID = Session("GA_ID")
        '        iaDtl_ID = objdtl.save()

        '    Else
        '        Dim dtl_id As Integer
        '        dtl_id = objDerived.GetValue("select AIRDtl_ID from AMS.AIR_Dtl where AIRHdr_ID =  '" & Session("AIRHDR_ID") & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)

        '        Dim ia_qty As Integer
        '        ia_qty = objDerived.GetValue("Select qty from AMS.AIR_Dtl where AIRHdr_ID =  '" & Session("AIRHDR_ID") & "' and Item_ID = '" & Session("Item_ID") & "' and AIRDtl_ID = '" & dtl_id & "'", CommandType.Text)

        '        objdtl.Item_ID = Session("Item_ID")
        '        objdtl.Qty = ia_qty + 1
        '        objdtl.Cost = FormatNumber(CType(txtPOprice.Text, Decimal) * (ia_qty + 1))
        '        objdtl.AIRHdr_ID = Session("AIRHDR_ID")
        '        objdtl.GA_ID = Session("GA_ID")
        '        objdtl.AIRDtl_ID = dtl_id
        '        iaDtl_ID = objdtl.update()

        '    End If
        '    Session("AIRDtl_ID") = iaDtl_ID


        '    '=-= END OF INSPECTION & ACCEPTANCE

        '    '--------------------------------------------------------------
        '    '=-= SAVE OF PROPERTY
        '    With objPropHdr
        '        '.Property_ID = Property_ID
        '        .Property_Date = txtDateAccepted.Text
        '        .Issuance = 0
        '        .Remarks = txtIAremarks.Text
        '        .Emp_ID = 0
        '        .F_ID = 4
        '        .AIRDtl_ID = Session("AIRDtl_ID")
        '        .deptid = ddDepartment.SelectedItem.Value
        '        .isDonated = False
        '        .GA_ID = Session("GA_ID")
        '        .DonationRemarks = ""
        '        .Qty = 1
        '        .Balance = 1
        '        .Cost = CType(txtPOprice.Text, Decimal)
        '        .Item_ID = Session("Item_ID")
        '        .Property_code = Session("GA_Code")
        '        .RC_ID = ddDepartment.SelectedItem.Value
        '        .Function_ID = ddFucntion.SelectedItem.Value
        '        .TD_ID = 0
        '        .Project_ID = 0
        '        .Program_id = 0
        '        .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & Session("Item_ID") & "' ", CommandType.Text)
        '    End With

        '    Dim PropHDR_id As Integer
        '    Dim PropHDR As New DataTable
        '    PropHDR = objDerived.GetDataTable("Select Property_ID from AMS.Property where AIRDtl_ID ='" & Session("AIRDtl_ID") & "'", CommandType.Text)
        '    If PropHDR.Rows.Count = 0 Then
        '        objPropHdr.Property_ID = 0
        '        PropHDR_id = objPropHdr.save()

        '    Else
        '        Dim PropHDRID As Integer
        '        PropHDRID = objDerived.GetValue("Select Property_ID from AMS.Property where AIRDtl_ID ='" & Session("AIRDtl_ID") & "'", CommandType.Text)

        '        Dim PropHDR_qty As Integer
        '        PropHDR_qty = objDerived.GetValue("Select qty from AMS.Property where AIRDtl_ID ='" & Session("AIRDtl_ID") & "' and Property_ID ='" & PropHDRID & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)

        '        Dim bal As Integer
        '        bal = objDerived.GetValue("Select balance from AMS.Property where AIRDtl_ID ='" & Session("AIRDtl_ID") & "' and Property_ID ='" & PropHDRID & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)

        '        Dim propcost As Integer
        '        propcost = objDerived.GetValue("Select Cost from AMS.Property where AIRDtl_ID ='" & Session("AIRDtl_ID") & "' and Property_ID ='" & PropHDRID & "' and Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)

        '        objPropHdr.Property_ID = PropHDRID
        '        objPropHdr.Cost = CType(txtPOprice.Text, Decimal)
        '        objPropHdr.Qty = PropHDR_qty + 1
        '        objPropHdr.Balance = bal + 1
        '        PropHDR_id = objPropHdr.update()
        '    End If
        '    Session("PropHDR_ID") = PropHDR_id

        '    LoadSavePropLEDGER()


        '    '=-= SAVE PROPERTY DETAILS 

        '    With objPropDtl
        '        .PropertyDetai_ID = 0
        '        .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtDateAccepted.Text & "', '" & Session("GA_Code") & "')", CommandType.Text)
        '        .Property_ID = Session("PropHDR_ID")
        '        .Issued = False
        '        .Repair = False
        '        .Dispose = False
        '        .DisposeDate = "1/1/1900"
        '        .IsInspectionForDisposal = False
        '        .InspectionDate = txtIAdate.Text
        '        .F_ID = 4
        '        .SerialNo = txtSerialnumber.Text
        '        .Barcode = txtSerialnumber.Text
        '        .Amount = CType(txtPOprice.Text, Decimal)
        '        .Status = "Accepted"
        '        .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & Session("Item_ID") & "' ", CommandType.Text)
        '        .save()
        '    End With

        '    Dim pdtl_id As Integer
        '    pdtl_id = objDerived.GetValue("Select max(PropertyDetai_ID) from AMS.Property_Dtl", CommandType.Text)
        '    Session("PropDTL_ID") = pdtl_id
        '    '=-= END OF PROPERTY

        '    '--------------------------------------------------------------
        '    '=-= SAVE PROP_SERIAL
        '    With objPropSerial
        '        .POHdr_ID = Session("POHdr_ID")
        '        .Item_ID = Session("Item_ID")
        '        .SerialNo = txtSerialnumber.Text
        '        .DatePurchased = txtPOdate.Text
        '        .Qty = 1
        '        .MarketValue = "0.00"
        '        .Status = "Accepted"
        '        .Property_Dtl_ID = Session("PropDTL_ID")
        '        .save()
        '    End With
        '    '=-= END OF PROP_SERIAL


        '    '--------------------------------------------------------------
        '    '=-= SAVE OF PER PROPERTY


        '    If Session("GA_ID") = 580 Then
        '        'Ambulance
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 7 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        With objAmbulanceInfo
        '            .Ambulance_InfoId = 0
        '            .AIRDtl_ID = Session("AIRDtl_ID")
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .IsAccepted = True
        '            .Location = ""
        '            .Brand = txtBrandname.Text
        '            .Model = txtBrandname.Text
        '            .Area = ""
        '            .PlateNo = txtSerialnumber.Text
        '            .seat = 2
        '            .Color = ""
        '            .Equipments = ""
        '        End With
        '        Dim ambu_info_id As Integer
        '        ambu_info_id = objAmbulanceInfo.save()

        '        With objAmbulanceDtl
        '            .Ambulance_ID = 0
        '            .Ambulance_InfoId = ambu_info_id
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .MarketValue = txtPOprice.Text
        '            .Condition = ""
        '            .Location = ""
        '            .Status = "Accepted"
        '        End With
        '        objAmbulanceDtl.save()

        '    ElseIf Session("GA_ID") = 534 Then
        '        'Furniture and Fixtures
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 6 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        With objFurnitureInfo
        '            .FurnitureInfoId = 0
        '            .AIRDtl_ID = Session("AIRDtl_ID")
        '            .IsAccepted = True
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .SerialNo = txtSerialnumber.Text
        '            .Name = txtBrandname.Text
        '            .Description = Session("Item_Desc")
        '            .DepreciationRate = "0.00"
        '            .Dimension = ""
        '            .AreaCapacity = ""
        '            .Model = txtBrandname.Text
        '            .Warranty = ""
        '            .DepreciationValue = "0.00"
        '            .Specification = ""
        '        End With
        '        Dim furn_info_id As Integer
        '        furn_info_id = objFurnitureInfo.save()

        '        With objFurnitureDtl
        '            .FurnitureId = 0
        '            .FurnitureInfoId = furn_info_id
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .Condition = ""
        '            .MarketValue = txtPOprice.Text
        '            .Location = ""
        '            .Status = "Accepted"
        '        End With
        '        objFurnitureDtl.save()

        '    ElseIf Session("GA_ID") = 537 Then
        '        'Machineries
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 5 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        With objMachineInfo
        '            .MachineryInfoId = 0
        '            .AIRDtl_ID = Session("AIRDtl_ID")
        '            .IsAccepted = True
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .SerialNo = txtSerialnumber.Text
        '            .BrandModel = ""
        '            .MachineDesc = ""
        '            .MachineLocation = ""
        '            .NoPassengers = ""
        '            .ServiceFloors = ""
        '            .MachineUnitNo = ""
        '            .WorkingLoad = ""
        '            .RatedSpeed = ""
        '            .CarDimensions = ""
        '            .DepreciationRate = "0.00"
        '            .DepreciationValue = "0.00"
        '            .MechinePermitNo = ""
        '            .DateOperate = "1/1/1900"
        '            .DateIssued = "1/1/1900"
        '            .DateInspected = txtIAdate.Text
        '            .InspectedBy = ddInspectedby.SelectedItem.Text
        '            .Remarks = txtIAremarks.Text
        '            'objMachineInfo.DateTaken = ""
        '            'objMachineInfo.UploadedBy = ""
        '        End With
        '        Dim mac_info_id As Integer
        '        mac_info_id = objMachineInfo.save()

        '        With objMachineDtl
        '            .MachineryId = 0
        '            .MachineryInfoId = mac_info_id
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .MarketValue = txtPOprice.Text
        '            .Condition = ""
        '            .Location = ""
        '            .Status = "Accepted"
        '        End With
        '        objMachineDtl.save()

        '    ElseIf Session("GA_ID") = 549 Then
        '        'Motor Vehicles
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 4 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        With objMotorInfo
        '            .Motor_InfoId = 0
        '            .AIRDtl_ID = Session("AIRDtl_ID")
        '            .IsAccepted = True
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .Name = Session("Item_Desc")
        '            .PlateNo = txtSerialnumber.Text
        '            .MotorNo = ""
        '            .Model = txtBrandname.Text
        '            .ChasisNo = ""
        '            .VehicleColor = ""
        '            .WheelsCapacity = ""
        '            .GrossWeight = ""
        '            .Seats = ""
        '            .Warranty = ""
        '            .VehicleOwner = ""
        '            .DeclaredName = ""
        '            .BeneficialUser = ""
        '            .VehicleSpecification = ""
        '        End With
        '        Dim motor_info_id As Integer
        '        motor_info_id = objMotorInfo.save()

        '        With objMotorDtl
        '            .MotorID = 0
        '            .Motor_InfoId = motor_info_id
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .MarketValue = txtPOprice.Text
        '            .Condition = ""
        '            .Location = ""
        '            .Status = "Accepted"
        '        End With
        '        objMotorDtl.save()

        '    ElseIf Session("GA_ID") = 520 Then
        '        'Land
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 1 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        With objLandDtl
        '            .LandId = 0
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .LguCode = ""
        '            .SectionNo = ""
        '            .PIN = ""
        '            .TDN = ""
        '            .DistrictCode = ""
        '            .ParcelNo = ""
        '            .ARP = ""
        '            .CityMunCode = ""
        '            .SeriesNo = ""
        '            .RevYear = ""
        '            .BarangayCode = ""
        '            .RPTIN = ""
        '            .DepreciationRate = "0.00"
        '            .DepreciationValue = "0.00"
        '            .LotNo = ""
        '            .BlkNo = ""
        '            .StreetName = ""
        '            .Subdivision = ""
        '            .PhaseNo = ""
        '            .Purok = ""
        '            .Sitio = ""
        '            .Barangay = ""
        '            .District = ""
        '            .CityMunicipal = ""
        '            .Province = ""
        '            .Region = ""
        '            .ZipCode = ""
        '            .Classification = ""
        '            .SubClass = ""
        '            .LandUse = ""
        '            .Area = ""
        '            .AVAmountWords = ""
        '            .MVAmountWords = ""
        '            .AssessmentLevel = ""
        '            .Status_1 = ""
        '            .Status_2 = ""
        '            .Status_AIR = "Accepted"
        '            .AssessedValue = "0.00"
        '            .MarketValue = "0.00"
        '            .UnitValue = "0.00"
        '            .Taxable = ""
        '            .AssessedDate = "1/1/1990"
        '            .MarketDate = "1/1/1990"
        '            .UnitDate = "1/1/1990"

        '        End With
        '        objLandDtl.save()

        '    ElseIf Session("GA_ID") = 525 Then
        '        'Office Buildings
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 2 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        With objBldgInfo
        '            .BuildingId = 0
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .BuildingControlNo = ""
        '            .BuildingCode = ""
        '            .BuildingName = txtBrandname.Text
        '            .Address = ""
        '            .PostalCode = ""
        '            .BuildingDepreciationRate = "0.00"
        '            .BuildingUse = ""
        '            .BuildingOccupancy = ""
        '            .NumberFloors = ""
        '            .AvgAreaFloor = ""
        '            .CostPerArea = ""
        '            .Status_AIR = "Accepted"
        '            .BuildingDepreciationValue = "0.00"
        '            '.DateTaken = ""
        '            '.UploadedBy = ""
        '            '.MarketValue = ""
        '        End With
        '        objBldgInfo.save()

        '    Else 'If Session("GA_ID") = 533 Or Session("GA_ID") = 535 Or Session("GA_ID") = 543 Or Session("GA_ID") = 540 Or Session("GA_ID") = 542 Or Session("GA_ID") = 544 Or Session("GA_ID") = 545 Or Session("GA_ID") = 548 Or Session("GA_ID") = 546 Or Session("GA_ID") = 94 Then
        '        'ALL Equipments
        '        objDerived.GetRecords("Update AMS.Property set TD_ID = 3 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

        '        Dim info_id As Integer
        '        With objEquipInfo
        '            .EquipInfoId = 0
        '            .AIRDtl_ID = Session("AIRDtl_ID")
        '            .IsAccepted = True
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .SerialNo = txtSerialnumber.Text
        '            .Name = txtBrandname.Text
        '            .Description = Session("Item_Desc")
        '            .PowerInput = ""
        '            .Dimension = ""
        '            .AreaCapacity = ""
        '            .Model = ""
        '            .Warranty = ""
        '            .Specification = ""
        '            .DepreciationRate = "0"
        '            .DepreciationValue = "0.00"
        '        End With
        '        info_id = objEquipInfo.save()

        '        With objEquipDtl
        '            .EquipmentId = 0
        '            .EquipInfoId = info_id
        '            .Property_Dtl_ID = Session("PropDTL_ID")
        '            .MarketValue = txtPOprice.Text
        '            .Condition = ""
        '            .Location = ""
        '            .Status = "Accepted"
        '        End With
        '        objEquipDtl.save()

        '    End If

        '    '=-= END OF PER PROPERTY
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property successfully save.")
        '    btnPrev.Enabled = False

        '    btnSave.Text = "SAVE"
        '    btnSave.Enabled = False
        '    Panel_PR.Enabled = False
        '    Panel_PO.Enabled = False
        '    Panel_IA.Enabled = False



        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub LoadSavePropLEDGER()
        With objLedger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtDateAccepted.Text
            .Ref = ""
            .AccountablePerson = ddSupplier.SelectedItem.Text
            .Department = ddDepartment.SelectedItem.Text
            .Position = ""
            .AcceptedBy = ddacceptedby.SelectedItem.Text
            .InspectedBy = ddInspectedby.SelectedItem.Text
            .Item_ID = Session("Item_ID")
            .DebitQty = txtQty.Text
            .DebitCost = CType(txtContractprice.Text, Decimal)
            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & Session("Item_ID") & "'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & Session("Item_ID") & "'", CommandType.Text)

            Dim Eqty As Integer
            Dim Eqbalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                Eqty = 0
                Eqbalance = 0.0
            Else
                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
            End If

            .BalanceQty = Eqty + 1
            .BalanceCost = CType(txtPOprice.Text, Decimal) + CType(Eqbalance, Decimal)

        End With
        objLedger.save()

    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender1.Show()
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CYear As String = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))
        Dim dtSearch As New DataTable
        'dtSearch = objDerived.GetDataTable("Select * from dbo.vw_DonationSearch where Item_Desc like '%" & txtsearchitems.Text & "%'", CommandType.Text)
        dtSearch = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Search] '" & ddAllotment.SelectedItem.Value & "', '" & CYear & "','" & txtsearchitems.Text & "'", CommandType.Text)
        gvitems.DataSource = dtSearch
        gvitems.DataBind()

        ModalPopupExtender1.Show()
    End Sub
    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If txtsearchitems.Text = "" Then
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True

            gvitems.PageIndex = e.NewPageIndex
            gvitems.DataSource = CType(pPopupitems, DataTable)
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False

            CType(gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = True

        Else
            Dim CYear As String = "CY" & Year(Date.Today.ToString("MM/dd/yyyy"))
            Dim dtSearch As New DataTable

            dtSearch = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories_Search] '" & ddAllotment.SelectedItem.Value & "', '" & CYear & "','" & txtsearchitems.Text & "'", CommandType.Text)
            gvitems.PageIndex = e.NewPageIndex
            gvitems.DataSource = dtSearch
            gvitems.DataBind()

            ModalPopupExtender1.Show()
        End If

        ModalPopupExtender1.Show()
    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If

        ModalPopupExtender1.Show()
    End Sub


    Protected Sub txtPRprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRprice.TextChanged
        txtPRprice.Text = FormatNumber(CType(txtPRprice.Text, Decimal))
    End Sub

    Protected Sub txtPOprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOprice.TextChanged
        txtPOprice.Text = FormatNumber(CType(txtPOprice.Text, Decimal))
        txtContractprice.Text = FormatNumber(CType(txtPOprice.Text * txtQty.Text, Decimal))
    End Sub

    Protected Sub txtContractprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtContractprice.Text = FormatNumber(CType(txtContractprice.Text, Decimal))
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnSave.Text = "NEXT" Then
            btnPrev.Enabled = False
            lblPR.ForeColor = Color.DimGray

        ElseIf btnSave.Text = "NEXT - PURCHASED ORDER" Then
            btnPrev.Enabled = False
            lblPR.ForeColor = Color.Blue
            lblPO.ForeColor = Color.DimGray

        ElseIf btnSave.Text = "NEXT - INSP & ACCPT" Then
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
            btnSave.Text = "NEXT - INSP & ACCPT"
            btnPrev.Enabled = True
            Panel_PR.Enabled = False
            Panel_PO.Enabled = True
            Panel_IA.Enabled = False

            lblPO.ForeColor = Color.Blue
            lblAIR.ForeColor = Color.DimGray

        End If
    End Sub

    Protected Sub btnSavePPE_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For count As Integer = 0 To CType(txtQty.Text, Integer) - 1
            Dim x As String = CType(grdSerial.Rows(count).FindControl("txtSerial"), TextBox).Text
            If x = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
                ModalPopupExtender2.Show()
                Exit Sub
            End If
        Next


        Dim Item_Desc As String
        Item_Desc = objDerived.GetValue("Select Item_Desc from dbo.m_item where Item_ID ='" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)
        Session("Item_Desc") = Item_Desc

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
            'prhdr.ABC = CType(txtPRprice.Text * txtQty.Text, Decimal)
            prhdr.Requestedby = ddPRrequestedby.SelectedItem.Value
            prhdr.Approvedby = ddApprovedby.SelectedItem.Value
            prhdr.Date_Submitted = "01/01/1900"
            prhdr.Date_gso_rcv = "01/01/1900"
            prhdr.IsCancelled = False
            prhdr.IsApproved = True
            prhdr.isOnBid = True
            prhdr.POHdr_ID = 0
            prhdr.withWinner = True
            prhdr.withOBR = True
            prhdr.withPO = True
            prhdr.declarationDate = "01/01/1900"
            prhdr.rcv_date = "01/01/1900"
            prhdr.mode_of_procurement_id = ddmodeofprocurement.SelectedItem.Value
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
                prhdr.ABC = CType(txtPRprice.Text * txtQty.Text, Decimal)
                prhdrID = prhdr.save
            Else
                Dim id As Integer
                Dim xABC As Decimal
                id = objDerived.GetValue("Select prhdr_id from ams.pr_hdr where pr_no like '" & txtPRnumber.Text & "'", CommandType.Text)
                xABC = objDerived.GetValue("Select ABC from ams.pr_hdr where prhdr_id = '" & id & "'", CommandType.Text)
                prhdr.ABC = CType(xABC + CType(txtPRprice.Text * txtQty.Text, Decimal), Decimal)
                prhdr.prhdr_id = id
                prhdrID = prhdr.update

            End If
            Session("PRHdr_ID") = prhdrID
            objDerived.GetRecords("UPDATE ams.pr_hdr set Userid ='" & Session("@UserName") & "', isTrustFund = 0, F_ID = 3 ,GA_ID = '" & ddAllotment.SelectedItem.Value & "' where prhdr_id='" & Session("PRHdr_ID") & "' ", CommandType.Text)


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
            POhdr.mode_of_procurement_id = ddmodeofprocurement.SelectedItem.Value
            POhdr.DeliveryTerm = ddDeliveryterm.SelectedItem.Text
            POhdr.paymentTerm = ddPaymentterm.SelectedItem.Text
            POhdr.DeliveryDate = "01/01/1900"
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
            POhdr.DateApproved_PO_Mayor = "01/01/1900"
            POhdr.DateReceived_PO_Mayor = "01/01/1900"
            POhdr.DateDisApprove = "01/01/1900"
            POhdr.isGasoline = False
            POhdr.isReimbursement = False
            POhdr.ApprovedBy = ddApprovedby.SelectedItem.Value

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

            'objDerived.GetRecords("Update ams.pr_hdr set pohdr_id ='" & pohdr_id & "' where PRHdr_ID = '" & Session("PRHdr_ID") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.PO_Hdr SET GA_ID = '" & Session("GA_ID") & "', ProjectName = '" & txtPRremarks.Text & "', RC_ID = '" & ddDepartment.SelectedItem.Value & "', Function_ID = '" & ddFucntion.SelectedItem.Value & "' WHERE POHdr_ID = '" & pohdr_id & "'", CommandType.Text)

            Session("POHdr_ID") = pohdr_id

            '=-= PO Details Save
            POdtl.POHdr_ID = Session("POHdr_ID")
            POdtl.Item_ID = Session("Item_ID")
            POdtl.cost = txtPOprice.Text
            POdtl.qty = txtQty.Text
            POdtl.remarks = ""
            POdtl.save()

            '=-= END OF PURCHASED ORDER

            '--------------------------------------------------------------
            '=-= SAVE AMS.Tb_Receiving
            With rcv
                .Received_Date = txtIAdate.Text
                .ReceivedBY = ddReceivedBy.SelectedItem.Value
                .POHdr_ID = Session("POHdr_ID")
                .PO_No = txtPOnumber.Text
                .Supplier_ID = ddSupplier.SelectedItem.Value
                .GA_ID = Session("GA_ID")
                .isAccepted = False
                .UserID = Session("@UserName")
            End With

            Dim rcvID As Long
            Dim RCV_ID As Long = objDerived.GetValue("SELECT Received_ID FROM AMS.Tb_Receiving WHERE Received_Date = '" & txtIAdate.Text & "' AND POHdr_ID = '" & Session("POHdr_ID") & "' AND Supplier_ID = '" & ddSupplier.SelectedItem.Value & "' ", CommandType.Text)

            If RCV_ID = 0 Then
                rcvID = rcv.save
            Else
                rcvID = RCV_ID
            End If

            Session("Received_ID") = rcvID
            objDerived.GetRecords("UPDATE AMS.Tb_Receiving SET InspectedBy = '" & ddInspectedby.SelectedItem.Value & "' WHERE Received_ID = '" & rcvID & "'", CommandType.Text)

            '=-= SAVE AMS.Tb_Receiving_Dtl
            With rcv_dtl
                .Received_ID = rcvID
                .Item_ID = Session("Item_ID")
                .PO_Qty = txtQty.Text
                .Qty_Received = txtQty.Text
                .Cost = txtPOprice.Text
                .Condition = ""
                .Location = ""
            End With

            Dim RcvDtl_ID As Long = rcv_dtl.save


            '=-= SAVE OF INSPECTION & ACCEPTANCE
            Dim airhdr_id As Long
            Dim air As String
            air = objDerived.GetValue("select [AMS].[func_GenerateAIR]( '" & txtDateAccepted.Text & "')", CommandType.Text)

            objhdr.AIR_Date = txtDateAccepted.Text
            objhdr.Date_Inspect = txtIAdate.Text
            objhdr.Date_Received = txtIAdate.Text
            objhdr.Date_Accepted = txtDateAccepted.Text
            objhdr.Invoice_No = txtInvoice.Text
            objhdr.Invoice_date = txtDateAccepted.Text
            objhdr.PO_No = txtPOnumber.Text
            objhdr.Supplier_ID = ddSupplier.SelectedItem.Value
            objhdr.Signatory1 = ddInspectedby.SelectedItem.Text
            objhdr.Signatory2 = ddReceivedBy.SelectedItem.Text
            objhdr.Signatory3 = ddacceptedby.SelectedItem.Text
            objhdr.isComplete = True
            objhdr.POHdr_ID = Session("POHdr_ID")
            objhdr.remarks = txtIAremarks.Text
            objhdr.RC_ID = ddDepartment.SelectedItem.Value
            objhdr.Function_ID = ddFucntion.SelectedItem.Value
            objhdr.Received_ID = rcvID
            objhdr.UserID = Session("@UserName")

            Dim IA As New DataTable
            IA = objDerived.GetDataTable("Select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & Session("POHdr_ID") & "'", CommandType.Text)
            If IA.Rows.Count = 0 Then
                objhdr.AIR_No = air
                airhdr_id = objhdr.save()

            Else
                Dim air_id As Integer
                Dim air_no As String
                air_id = objhdr.GetValue("select AIRHdr_ID from AMS.AIR_Hdr where POHdr_ID = '" & Session("POHdr_ID") & "'", CommandType.Text)
                air_no = objhdr.GetValue("select AIR_No from AMS.AIR_Hdr where POHdr_ID = '" & Session("POHdr_ID") & "'", CommandType.Text)

                objhdr.AIRHdr_ID = air_id
                objhdr.AIR_No = air_no
                airhdr_id = objhdr.update()
            End If

            Session("AIRHDR_ID") = airhdr_id
            objDerived.GetRecords("UPDATE AMS.AIR_Hdr SET UserID = '" & Session("@UserName") & "', Received_ID = '" & Session("Received_ID") & "' WHERE AIRHdr_ID = '" & Session("AIRHDR_ID") & "'", CommandType.Text)

            '=-= AIR DETAILS
            Dim iaDtl_ID As Integer

            objdtl.Item_ID = Session("Item_ID")
            objdtl.Qty = txtQty.Text
            objdtl.Cost = txtPOprice.Text
            objdtl.AIRHdr_ID = Session("AIRHDR_ID")
            objdtl.GA_ID = Session("GA_ID")
            iaDtl_ID = objdtl.save()

            Session("AIRDtl_ID") = iaDtl_ID

            '=-= END OF INSPECTION & ACCEPTANCE

            '--------------------------------------------------------------
            '=-= SAVE OF PROPERTY
            With objPropHdr
                '.Property_ID = Property_ID
                .Property_Date = txtDateAccepted.Text
                .Issuance = 0
                .Remarks = txtIAremarks.Text
                .Emp_ID = 0
                .F_ID = 1
                .AIRDtl_ID = Session("AIRDtl_ID")
                .deptid = ddDepartment.SelectedItem.Value
                .isDonated = False
                .GA_ID = Session("GA_ID")
                .DonationRemarks = ""
                .Qty = txtQty.Text
                .Balance = txtQty.Text
                .Cost = CType(txtPOprice.Text, Decimal)
                .Item_ID = Session("Item_ID")
                .Property_code = Session("GA_Code")
                .RC_ID = ddDepartment.SelectedItem.Value
                .Function_ID = ddFucntion.SelectedItem.Value
                .TD_ID = 1
                .Project_ID = 0
                .Program_id = 0
                .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & Session("Item_ID") & "' ", CommandType.Text)
            End With

            Dim PropHDR_id As Integer
            objPropHdr.Property_ID = 0

            PropHDR_id = objPropHdr.save()

            Session("PropHDR_ID") = PropHDR_id
            objDerived.GetRecords("UPDATE AMS.Property SET POHdr_ID = '" & Session("POHdr_ID") & "', Received_ID = '" & Session("Received_ID") & "' WHERE Property_ID = '" & PropHDR_id & "'", CommandType.Text)

            LoadSavePropLEDGER()


            For i As Integer = 0 To CType(txtQty.Text, Integer) - 1
                '=-= SAVE PROPERTY DETAILS 
                With objPropDtl
                    .PropertyDetai_ID = 0
                    .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtDateAccepted.Text & "', '" & Session("GA_Code") & "', '" & Session("Item_ID") & "')", CommandType.Text)
                    .Property_ID = Session("PropHDR_ID")
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtIAdate.Text
                    .F_ID = 1
                    .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                    .Barcode = ""
                    .Amount = CType(txtPOprice.Text, Decimal)
                    .Status = "Accepted"
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & Session("Item_ID") & "' ", CommandType.Text)
                    .save()
                End With

                Dim pdtl_id As Integer
                pdtl_id = objDerived.GetValue("Select max(PropertyDetai_ID) from AMS.Property_Dtl", CommandType.Text)
                Session("PropDTL_ID") = pdtl_id
                '=-= END OF PROPERTY

                '--------------------------------------------------------------
                '=-= SAVE PROP_SERIAL
                'With objPropSerial
                '    .POHdr_ID = Session("POHdr_ID")
                '    .Item_ID = Session("Item_ID")
                '    .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                '    .DatePurchased = txtPOdate.Text
                '    .Qty = 1
                '    .MarketValue = "0.00"
                '    .Status = "Accepted"
                '    .Property_Dtl_ID = Session("PropDTL_ID")
                '    .save()
                'End With
                '=-= END OF PROP_SERIAL


                '--------------------------------------------------------------
                '=-= SAVE OF PER PROPERTY

                If Session("GA_ID") = 580 Then '=== Session("GA_ID") = 580 Then
                    'Ambulance
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 7 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    With objAmbulanceInfo
                        .Ambulance_InfoId = 0
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .IsAccepted = True
                        .Location = ""
                        .Brand = txtBrandname.Text
                        .Model = txtBrandname.Text
                        .Area = ""
                        .PlateNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .seat = 2
                        .Color = ""
                        .Equipments = ""
                    End With
                    Dim ambu_info_id As Integer
                    ambu_info_id = objAmbulanceInfo.save()

                    With objAmbulanceDtl
                        .Ambulance_ID = 0
                        .Ambulance_InfoId = ambu_info_id
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .MarketValue = txtPOprice.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objAmbulanceDtl.save()

                ElseIf Session("GA_ID") = 1118 Then '===  Session("GA_ID") = 534 Then
                    'Furniture and Fixtures
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 6 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    With objFurnitureInfo
                        .FurnitureInfoId = 0
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .IsAccepted = True
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .Name = txtBrandname.Text
                        .Description = Session("Item_Desc")
                        .DepreciationRate = "0.00"
                        .Dimension = ""
                        .AreaCapacity = ""
                        .Model = txtBrandname.Text
                        .Warranty = ""
                        .DepreciationValue = "0.00"
                        .Specification = ""
                    End With
                    Dim furn_info_id As Integer
                    furn_info_id = objFurnitureInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET Received_ID = '" & rcvID & "', Received_Dtl_ID = '" & RcvDtl_ID & "' WHERE FurnitureInfoId = '" & furn_info_id & "'", CommandType.Text)


                    With objFurnitureDtl
                        .FurnitureId = 0
                        .FurnitureInfoId = furn_info_id
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .Condition = ""
                        .MarketValue = txtPOprice.Text
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objFurnitureDtl.save()

                ElseIf Session("GA_ID") = 1127 Then '=== Session("GA_ID") = 537 Then
                    'Machineries
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 5 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    With objMachineInfo
                        .MachineryInfoId = 0
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .IsAccepted = True
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .BrandModel = ""
                        .MachineDesc = ""
                        .MachineLocation = ""
                        .NoPassengers = ""
                        .ServiceFloors = ""
                        .MachineUnitNo = ""
                        .WorkingLoad = ""
                        .RatedSpeed = ""
                        .CarDimensions = ""
                        .DepreciationRate = "0.00"
                        .DepreciationValue = "0.00"
                        .MechinePermitNo = ""
                        .DateOperate = "1/1/1900"
                        .DateIssued = "1/1/1900"
                        .DateInspected = txtIAdate.Text
                        .InspectedBy = ddInspectedby.SelectedItem.Text
                        .Remarks = txtIAremarks.Text
                        'objMachineInfo.DateTaken = ""
                        'objMachineInfo.UploadedBy = ""
                    End With
                    Dim mac_info_id As Integer
                    mac_info_id = objMachineInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET Received_ID = '" & rcvID & "', Received_Dtl_ID = '" & RcvDtl_ID & "' WHERE MachineryInfoId = '" & mac_info_id & "'", CommandType.Text)

                    With objMachineDtl
                        .MachineryId = 0
                        .MachineryInfoId = mac_info_id
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .MarketValue = txtPOprice.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objMachineDtl.save()

                ElseIf Session("GA_ID") = 1166 Then '=== Session("GA_ID") = 549 Then
                    'Motor Vehicles
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 4 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    With objMotorInfo
                        .Motor_InfoId = 0
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .IsAccepted = True
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .Name = Session("Item_Desc")
                        .PlateNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .MotorNo = ""
                        .Model = txtBrandname.Text
                        .ChasisNo = ""
                        .VehicleColor = ""
                        .WheelsCapacity = ""
                        .GrossWeight = ""
                        .Seats = ""
                        .Warranty = ""
                        .VehicleOwner = ""
                        .DeclaredName = ""
                        .BeneficialUser = ""
                        .VehicleSpecification = ""
                    End With
                    Dim motor_info_id As Integer
                    motor_info_id = objMotorInfo.save()

                    objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_ID = '" & rcvID & "', Received_Dtl_ID = '" & RcvDtl_ID & "' WHERE Motor_InfoId = '" & motor_info_id & "'", CommandType.Text)


                    With objMotorDtl
                        .MotorID = 0
                        .Motor_InfoId = motor_info_id
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .MarketValue = txtPOprice.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objMotorDtl.save()

                ElseIf Session("GA_ID") = 1060 Or Session("GA_ID") = 1067 Then
                    'Land
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 1 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    With objLandDtl
                        .LandId = 0
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .LguCode = ""
                        .SectionNo = ""
                        .PIN = ""
                        .TDN = ""
                        .DistrictCode = ""
                        .ParcelNo = ""
                        .ARP = ""
                        .CityMunCode = ""
                        .SeriesNo = ""
                        .RevYear = ""
                        .BarangayCode = ""
                        .RPTIN = ""
                        .DepreciationRate = "0.00"
                        .DepreciationValue = "0.00"
                        .LotNo = ""
                        .BlkNo = ""
                        .StreetName = ""
                        .Subdivision = ""
                        .PhaseNo = ""
                        .Purok = ""
                        .Sitio = ""
                        .Barangay = ""
                        .District = ""
                        .CityMunicipal = ""
                        .Province = ""
                        .Region = ""
                        .ZipCode = ""
                        .Classification = ""
                        .SubClass = ""
                        .LandUse = ""
                        .Area = ""
                        .AVAmountWords = ""
                        .MVAmountWords = ""
                        .AssessmentLevel = ""
                        .Status_1 = ""
                        .Status_2 = ""
                        .Status_AIR = "Accepted"
                        .AssessedValue = "0.00"
                        .MarketValue = "0.00"
                        .UnitValue = "0.00"
                        .Taxable = ""
                        .AssessedDate = "1/1/1990"
                        .MarketDate = "1/1/1990"
                        .UnitDate = "1/1/1990"

                    End With
                    objLandDtl.save()

                ElseIf Session("GA_ID") = 1082 Or Session("GA_ID") = 1085 Then
                    'Office Buildings
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 2 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    With objBldgInfo
                        .BuildingId = 0
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .BuildingControlNo = ""
                        .BuildingCode = ""
                        .BuildingName = txtBrandname.Text
                        .Address = ""
                        .PostalCode = ""
                        .BuildingDepreciationRate = "0.00"
                        .BuildingUse = ""
                        .BuildingOccupancy = ""
                        .NumberFloors = ""
                        .AvgAreaFloor = ""
                        .CostPerArea = ""
                        .Status_AIR = "Accepted"
                        .BuildingDepreciationValue = "0.00"
                        '.DateTaken = ""
                        '.UploadedBy = ""
                        '.MarketValue = ""
                    End With
                    objBldgInfo.save()

                Else 'If Session("GA_ID") = 533 Or Session("GA_ID") = 535 Or Session("GA_ID") = 543 Or Session("GA_ID") = 540 Or Session("GA_ID") = 542 Or Session("GA_ID") = 544 Or Session("GA_ID") = 545 Or Session("GA_ID") = 548 Or Session("GA_ID") = 546 Or Session("GA_ID") = 94 Then
                    'ALL Equipments
                    'objDerived.GetRecords("Update AMS.Property set TD_ID = 3 where Property_ID = '" & Session("PropHDR_ID") & "'", CommandType.Text)

                    Dim info_id As Integer
                    With objEquipInfo
                        .EquipInfoId = 0
                        .AIRDtl_ID = Session("AIRDtl_ID")
                        .IsAccepted = True
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .SerialNo = CType(grdSerial.Rows(i).FindControl("txtSerial"), TextBox).Text
                        .Name = txtBrandname.Text
                        .Description = Session("Item_Desc")
                        .PowerInput = ""
                        .Dimension = ""
                        .AreaCapacity = ""
                        .Model = ""
                        .Warranty = ""
                        .Specification = ""
                        .DepreciationRate = "0"
                        .DepreciationValue = "0.00"
                    End With

                    info_id = objEquipInfo.save()
                    objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_ID = '" & rcvID & "', Received_Dtl_ID = '" & RcvDtl_ID & "'  WHERE EquipInfoId = '" & info_id & "'", CommandType.Text)

                    With objEquipDtl
                        .EquipmentId = 0
                        .EquipInfoId = info_id
                        .Property_Dtl_ID = Session("PropDTL_ID")
                        .MarketValue = txtPOprice.Text
                        .Condition = ""
                        .Location = ""
                        .Status = "Accepted"
                    End With
                    objEquipDtl.save()

                End If

                '=-= END OF PER PROPERTY

            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnPrev.Enabled = False

            btnSave.Text = "SAVE"
            btnSave.Enabled = False
            btnPreview.Enabled = True
            Panel_PR.Enabled = False
            Panel_PO.Enabled = False
            Panel_IA.Enabled = False

        Catch ex As Exception
        End Try
    End Sub

    Public Function createDatatableBarcode(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("no", GetType(Integer))
        dt.Columns.Add("barcode")
        For i As Integer = 1 To row
            dr = dt.NewRow
            dr("no") = i
            dr("barcode") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "PPE"
        Me.Page.Response.Redirect("~/procurement/t_rpt_receiving.aspx")
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtLocation.Text = ""
        txtArea.Text = ""
        txtTaxDec.Text = ""
        txtPreviousOwner.Text = ""
        txtAcqDate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtAcqCost.Text = "0.00"
        txtAcqMode.Text = ""
        txtMarketValue.Text = ""
    End Sub

    Protected Sub btnLandSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If txtAcqCost.Text = "0.00" Or txtMarketValue.Text = "0.00" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Acquisition Cost and Market Value should not equal to zero.")
            Else
                '==== SAVE PROPERTY HEADER
                With objPropHdr
                    '.Property_ID = Property_ID
                    .Property_Date = txtAcqDate.Text
                    .Issuance = 0
                    .Remarks = "Manual Encoding of Land Properties"
                    .Emp_ID = 0
                    .F_ID = 1
                    .AIRDtl_ID = 0
                    .deptid = ddLandDepartment.SelectedItem.Value
                    .isDonated = False
                    .GA_ID = Session("GA_ID")
                    .DonationRemarks = ""
                    .Qty = 1
                    .Balance = 1
                    .Cost = CType(txtAcqCost.Text, Decimal)
                    .Item_ID = Session("Item_ID")
                    .Property_code = Session("GA_Code")
                    .RC_ID = ddLandDepartment.SelectedItem.Value
                    .Function_ID = ddLandFunction.SelectedItem.Value
                    .TD_ID = 1
                    .Project_ID = 0
                    .Program_id = 0
                    .Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & Session("Item_ID") & "' ", CommandType.Text)
                End With

                Dim PropHdr_ID As Integer
                PropHdr_ID = objPropHdr.save()

                '==== SAVE PROPERTY DETAILS
                With objPropDtl
                    '.PropertyDetai_ID = 0
                    .PropertyNo = objDerived.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & txtAcqDate.Text & "', '" & Session("GA_Code") & "', '" & Session("Item_ID") & "')", CommandType.Text)
                    .Property_ID = PropHdr_ID
                    .Issued = False
                    .Repair = False
                    .Dispose = False
                    .DisposeDate = "1/1/1900"
                    .IsInspectionForDisposal = False
                    .InspectionDate = txtAcqDate.Text
                    .F_ID = 1
                    .SerialNo = gvbody.SelectedDataKey("Item_Code")
                    .Barcode = gvbody.SelectedDataKey("Item_Code")
                    .Amount = CType(txtAcqCost.Text, Decimal)
                    .Status = "Accepted"
                    .type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID = '" & Session("Item_ID") & "' ", CommandType.Text)
                End With

                Dim PropDtl_ID As Integer
                PropDtl_ID = objPropDtl.save()

                '==== SAVE LAND DETAILS
                With objLandDtl
                    '.LandId = LandId
                    .Property_Dtl_ID = PropDtl_ID
                    '.LguCode = txtLandlgucode.Text
                    '.SectionNo = txtLandSectionno.Text
                    '.PIN = txtLandPIN.Text
                    '.TDN = txtLandTdn.Text
                    '.DistrictCode = txtLanddistrictcode.Text
                    '.ParcelNo = txtLandParcelno.Text
                    '.ARP = txtLandARP.Text
                    '.CityMunCode = txtLandcitymunicipality1.Text
                    '.SeriesNo = txtLandSeriesno.Text
                    '.RevYear = txtLandrevyear.Text
                    .BarangayCode = txtBrgyCode.Text
                    '.RPTIN = txtLandRPTIN.Text
                    '.DepreciationRate = txtLandDepriciationRate.Text
                    '.DepreciationValue = txtLandDepreciatedValue.Text
                    '.LotNo = txtLandlocationLot.Text
                    '.BlkNo = txtLandlocationblkno.Text
                    '.StreetName = txtLandlocationstreetname.Text
                    '.Subdivision = txtLandlocationsubdivisionvillage.Text
                    '.PhaseNo = txtLandlocationphaseno.Text
                    '.Purok = txtLandlocationpurok.Text
                    '.Sitio = txtLandlocationsitio.Text
                    .Barangay = txtLocation.Text
                    '.District = txtLandDistrict.Text
                    '.CityMunicipal = txtLandCitymunicipality.Text
                    .Province = "Cebu"
                    '.Region = txtLandRegion.Text
                    '.ZipCode = txtLandzipcode.Text
                    '.Classification = txtLandClassification.Text
                    '.SubClass = txtLandSubClass.Text
                    '.LandUse = txtLandUse.Text
                    .Area = txtArea.Text
                    '.AVAmountWords = txtLandAssessedAmount.Text
                    '.MVAmountWords = txtMarketValue.Text
                    '.AssessmentLevel = dpLandAssessmentLvl.SelectedValue
                    '.Status_1 = txtLandStatus1.Text
                    '.Status_2 = txtLandStatus2.Text
                    '.AssessedValue = txtLandAssessedValue.Text
                    .MarketValue = txtMarketValue.Text
                    '.UnitValue = txtLandUnitValue.Text
                    '.Taxable = ddwnLandTaxable.SelectedItem.Text
                    .AssessedDate = "01/01/1900"
                    .MarketDate = "01/01/1900"
                    .UnitDate = "01/01/1900"
                    '.Received_ID = rcvID
                    .TaxDeclarationNo = txtTaxDec.Text
                    .AcqMode = txtAcqMode.Text
                End With

                Dim LandDtl_ID As Integer
                LandDtl_ID = objLandDtl.save()

                objDerived.GetRecords("INSERT INTO AMS.TbLand_OwnerHistory (LandId,OwnerName,Year) VALUES ('" & LandDtl_ID & "','" & txtPreviousOwner.Text & "','" & Year(txtAcqDate.Text) & "')", CommandType.Text)

                LoadSavePropLEDGER_land()

                btnLandSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            End If

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub LoadSavePropLEDGER_land()
        With objLedger
            .Ledger_ID = 0
            .PropertyNo = ""
            .SerialNo = ""
            .Trans_Type = "Manual Entry"
            .dDate = txtAcqDate.Text
            .Ref = ""
            .AccountablePerson = "" 'ddSupplier.SelectedItem.Text
            .Department = ddLandDepartment.SelectedItem.Text
            .Position = ""
            .AcceptedBy = "" 'ddacceptedby.SelectedItem.Text
            .InspectedBy = "" 'ddInspectedby.SelectedItem.Text
            .Item_ID = Session("Item_ID")
            .DebitQty = 1
            .DebitCost = CType(txtAcqCost.Text, Decimal)
            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & Session("Item_ID") & "'", CommandType.Text)
            .CreditQty = "0"
            .CreditUnit = "-"
            .CreditCost = "0.00"
            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & Session("Item_ID") & "'", CommandType.Text)

            Dim Eqty As Integer
            Dim Eqbalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                Eqty = 0
                Eqbalance = 0.0
            Else
                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & Session("Item_ID") & "'", CommandType.Text)
            End If

            .BalanceQty = Eqty + 1
            .BalanceCost = CType(txtAcqCost.Text, Decimal) + CType(Eqbalance, Decimal)

        End With
        objLedger.save()

    End Sub

    Protected Sub ddLandDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddLandFunction.DataSource = objDerived.GetDataTable("SELECT Office_id AS Rc_id,Function_id,Function_desc FROM ams.vw_functions WHERE Office_id = '" & ddLandDepartment.SelectedItem.Value & "'", CommandType.Text)
        ddLandFunction.DataTextField = ("Function_Desc")
        ddLandFunction.DataValueField = ("Function_ID")
        ddLandFunction.DataBind()
        ddLandFunction.Items.Insert(0, "Select")

        ddLandFunction.Enabled = True
    End Sub

    Protected Sub txtAcqCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtAcqCost.Text = FormatNumber(txtAcqCost.Text, 2)
    End Sub

    Protected Sub txtMarketValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtMarketValue.Text = FormatNumber(txtMarketValue.Text, 2)
    End Sub

    Protected Sub gvbody_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pPopupitems = objDerived.GetDataTable("exec [AMS].[sp_loadOld_Inventories] '" & ddAllotment.SelectedItem.Value & "', '" & Session("CYear") & "'", CommandType.Text)
        gvbody.DataSource = pPopupitems
        gvbody.PageIndex = e.NewPageIndex
        gvbody.DataBind()
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnSearchItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddAllotment.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select general account first.")
        Else
            Dim myview As DataView
            myview = pPopupitems.DefaultView
            If ddSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "Item_Code like '%" & replaceapostrophe(txtSearch.Text) & "%'"
            Else
                myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearch.Text) & "%'"
            End If
            gvbody.DataSource = myview
            gvbody.DataBind()
        End If
        

    End Sub
End Class
