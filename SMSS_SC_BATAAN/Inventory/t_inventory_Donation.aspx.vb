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


Partial Class t_inventory_Donation
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private objProperty As New t_property_hdr
    Private propertDtl As New t_property_dtl

    Dim objLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim DonationLedger_ID As New Integer
    Dim dtPropLedger As New DataTable

    Dim objDonation As New ConsolidatedPropertySaving.TbDonations
    Dim Donation_ID As New Integer
    Dim dtDonation As New DataTable

    Dim objDonation_Hdr As New ConsolidatedPropertySaving.TbDonation_Hdr
    Dim DonationHdr_ID As New Integer
    Dim dtDonation_Hdr As New DataTable

    Dim rcv As New Receiving.t_receiving
    Dim rcv_dtl As New Receiving.t_receiving_dtl
    Dim rcvID As Long

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub
#Region "BaseDAL"
    Dim AIR_Hdr As New t_inspection_and_acceptance_hdr
    Dim AIR_Dtl As New t_inspection_and_acceptance_dtl

    '=-= CAPITAL OUTLAY
    Dim Prop_Ledger As New t_PropertyLedger
    Dim Prop_Hdr As New t_property_hdr
    Dim Prop_Dtl As New t_property_dtl

    Dim LandDtl As New ConsolidatedPropertySaving.TBLand_Details
    Dim LandTech As New ConsolidatedPropertySaving.TB_Landdescription
    Dim LandDocument As New ConsolidatedPropertySaving.TbLand_LandDocu
    Dim LandOwner As New ConsolidatedPropertySaving.TbLand_OwnerHistory
    Dim LandValuation As New ConsolidatedPropertySaving.TbLand_Valuation
    Dim LandImprovement As New ConsolidatedPropertySaving.TbLand_Improvements
    Dim LandPropHis As New ConsolidatedPropertySaving.TbLand_PropertyHistory

    Dim BldgInfo As New ConsolidatedPropertySaving.TBBuilding_Details

    Dim EquipInfo As New ConsolidatedPropertySaving.TbEquipment_Info
    Dim EquipDtl As New ConsolidatedPropertySaving.TbEquipment_Details

    Dim FurnitureInfo As New ConsolidatedPropertySaving.TbFurniture_Info
    Dim FurnitureDtl As New ConsolidatedPropertySaving.TbFurniture_Dtl

    Dim MachineInfo As New ConsolidatedPropertySaving.TbMachinery_Information
    Dim MachineDtl As New ConsolidatedPropertySaving.TbMachinery_Dtl

    Dim MotorInfo As New ConsolidatedPropertySaving.TbMotor_Info
    Dim MotorDtl As New ConsolidatedPropertySaving.TbMotor_Dtl

    Dim AmbulanceInfo As New ConsolidatedPropertySaving.TbAmbulance_Info
    Dim AmbulanceDtl As New ConsolidatedPropertySaving.TbAmbulance_Dtl

    Dim PropSerial As New ConsolidatedPropertySaving.PropSerial

    '=-= SUPPLIES
    Dim Stock_Ledger As New t_StockLedger
    Dim Stock As New Supplies_Stock

    Dim OfficeSup As New SupplieINFO

    Dim MedDtl As New ConsolidatedMedicineSaving.TBMedicine_DTl
    Dim MedInfo As New ConsolidatedMedicineSaving.TBMedicine_Info

    Dim Blood As New ConsolidatedMedicineSaving.TbBlood
    Dim NonFood As New ConsolidatedMedicineSaving.TbNonFood
    Dim Food As New ConsolidatedMedicineSaving.TbFood
    Dim Water As New ConsolidatedMedicineSaving.TbWater
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

    Private Property dtDonations() As DataTable
        Get
            Return CType(Session("dtDonations"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDonations") = value
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

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If


        If Not Page.IsPostBack Then
            txtprdate.ReadOnly = False
            txtremarks.ReadOnly = False
            txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")

            gvbody.DataSource = Nothing
            gvbody.DataBind()

            pItems = Nothing
            gvitems.Columns(3).Visible = True
            gvitems.DataSource = Nothing
            gvitems.DataBind()


            Session("Search1") = 0


            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False

            txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")
            btnadd.Enabled = True
            btnSave.Enabled = False

            ddReceivedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = 7 AND division_key = 86", CommandType.Text)
            ddReceivedBy.DataTextField = ("full_name")
            ddReceivedBy.DataValueField = ("Signatory_ID")
            ddReceivedBy.DataBind()
            ddReceivedBy.Items.Insert(0, "Select")

            ddGA.DataSource = objDerived.GetDataTable("SELECT * FROM DBO.view_Accntg_gen_accnt WHERE AllotmentClass_ID  = 3	ORDER BY GA_Title", CommandType.Text)
            ddGA.DataTextField = ("GA_Title")
            ddGA.DataValueField = ("GA_ID")
            ddGA.DataBind()
            ddGA.Items.Insert(0, "Select")
            Session("GA_ID") = 0

            dtDonations = objDerived.GetDataTable("Select * from dbo.view_DonationDtl where Donation_ID = 0 order by Item_Desc", CommandType.Text)
            grdDonationDtl.DataSource = dtDonations
            grdDonationDtl.DataBind()
            Session("Search2") = 0


        End If

        txtSearchREF.Attributes.Add("onkeypress", "return fun1(event,'" & btnRefSearch.ClientID & "')")
        txtsearchitems.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub ddGA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGA.SelectedIndexChanged
        Session("GA_ID") = ddGA.SelectedValue
        AddTrace("GA_ID: " & Session("GA_ID"))


        pPopupitems = objDerived.GetDataTable("exec [AMS].[sp_loadProperty_Donation] '" & Session("GA_ID") & "' ", CommandType.Text)
        gvitems.DataSource = pPopupitems
        gvitems.DataBind()


    End Sub

    Public Sub gridEnable()
        Dim cb As CheckBox
        Dim itemid As Integer
        Dim txt As Integer
        Dim gv As New GridView
        gvitems.Columns(3).Visible = True
        gv.DataSource = pItems
        gv.DataBind()
        Dim countE As Integer = 0
        For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            itemid = CType(gvitems.Rows(i).FindControl("lblItem_ID"), Label).Text
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            For o As Integer = 0 To gv.Rows.Count - 1
                txt = CType(gv.Rows(o).Cells(5).Text, Integer)

                If txt = itemid Then
                    cb.Checked = False
                    cb.Enabled = False
                    countE = countE + 1
                End If

            Next
        Next
        If countE = 8 Then
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = False

        Else
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = True

        End If
        'gvitems.Columns(3).Visible = False
        'gvitems.Columns(4).Visible = False
        'gvitems.Columns(5).Visible = False
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            txtRef.Enabled = True
            txtprdate.Enabled = True
            txtremarks.Enabled = True

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True

            'Dim cb As CheckBox

            'Dim tb2, tb3, tb4, tb5 As New TextBox
            'Dim dr As DataRow ', dr2, dr3
            'Dim dt As New DataTable
            'dt.Columns.Add("item_desc")
            'dt.Columns.Add("Description")
            'dt.Columns.Add("qty")
            'dt.Columns.Add("price", GetType(Decimal))
            'dt.Columns.Add("total", GetType(Decimal))
            'dt.Columns.Add("Item_ID")
            'dt.Columns.Add("GA_ID")
            'dt.Columns.Add("GA_Code")


            'If pItems Is Nothing Then
            '    For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            '        cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

            '        If cb.Checked = True Then
            '            dr = dt.NewRow
            '            dr("item_desc") = gvitems.Rows(i).Cells(1).Text
            '            dr("Description") = gvitems.Rows(i).Cells(2).Text
            '            dr("qty") = "0"
            '            dr("price") = CType(gvitems.Rows(i).FindControl("lblPrice"), Label).Text
            '            dr("total") = CType("0.00", Decimal)
            '            dr("Item_ID") = CType(gvitems.Rows(i).FindControl("lblItem_ID"), Label).Text
            '            dr("GA_ID") = CType(gvitems.Rows(i).FindControl("lblGA_ID"), Label).Text
            '            dr("GA_code") = CType(gvitems.Rows(i).FindControl("lblGA_code"), Label).Text
            '            dt.Rows.Add(dr)
            '        End If
            '    Next
            '    pItems = dt

            'Else
            '    For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            '        cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

            '        If cb.Checked = True Then
            '            dt = pItems
            '            dr = dt.NewRow
            '            dr("item_desc") = gvitems.Rows(i).Cells(1).Text
            '            dr("Description") = gvitems.Rows(i).Cells(2).Text
            '            dr("qty") = "0"
            '            dr("price") = CType(gvitems.Rows(i).FindControl("lblPrice"), Label).Text
            '            dr("total") = CType("0.00", Decimal)
            '            'dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
            '            'dr("GA_ID") = gvitems.Rows(i).Cells(4).Text
            '            'dr("GA_code") = gvitems.Rows(i).Cells(5).Text
            '            dr("Item_ID") = CType(gvitems.Rows(i).FindControl("lblItem_ID"), Label).Text
            '            dr("GA_ID") = CType(gvitems.Rows(i).FindControl("lblGA_ID"), Label).Text
            '            dr("GA_code") = CType(gvitems.Rows(i).FindControl("lblGA_code"), Label).Text
            '            dt.Rows.Add(dr)
            '            pItems = dt
            '        End If
            '    Next
            'End If

            'gvbody.DataSource = pItems
            'gvbody.DataBind()
            'Refactor code
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

            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                If cb.Checked = True Then
                    dr = dt.NewRow
                    dr("item_desc") = gvitems.Rows(i).Cells(1).Text
                    dr("Description") = gvitems.Rows(i).Cells(2).Text
                    dr("qty") = "0"
                    dr("price") = CType(gvitems.Rows(i).FindControl("lblPrice"), Label).Text
                    dr("total") = CType("0.00", Decimal)
                    dr("Item_ID") = CType(gvitems.Rows(i).FindControl("lblItem_ID"), Label).Text
                    dr("GA_ID") = CType(gvitems.Rows(i).FindControl("lblGA_ID"), Label).Text
                    dr("GA_code") = CType(gvitems.Rows(i).FindControl("lblGA_code"), Label).Text
                    dt.Rows.Add(dr)
                End If
            Next

            pItems = dt
            gvbody.DataSource = pItems
            gvbody.DataBind()


            gridEnable()
            Me.Session("search") = False
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Dim qty As TextBox = CType(Me.gvbody.Rows(i).Cells(2).FindControl("txtqty"), TextBox)
                qty.Attributes.Add("onclick", "this.select()")
                qty.Attributes.Add("onFocus", "this.select()")
            Next
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)

            'txtRef.Text = objDonation.GetValue("select [dbo].[func_GeneratePropertyNo]( '" & Date.Today.ToString("MM/dd/yyyy") & "', '" & 878 & "')", CommandType.Text)
            txtRef.Text = objDonation.GetValue("select [AMS].[func_GenerateDonationRef]( '" & Date.Today.ToString("MM/dd/yyyy") & "')", CommandType.Text)

            txtremarks.Text = ""
            txtSearchREF.Text = ""
            grdDonationDtl.DataSource = createdatatable1(8)
            grdDonationDtl.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False

            'ModalPopupExtender1.Show()
        Catch ex As Exception
        End Try
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

    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)

            gvbody.Rows(gvr.RowIndex).Cells(4).Text = FormatNumber(CType(txtqty.Text, Integer) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal), 2)
            pItems.Rows(gvr.RowIndex)("qty") = CType(txtqty.Text, Integer)
            pItems.Rows(gvr.RowIndex)("total") = FormatNumber(CType(txtqty.Text, Integer) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal), 2)
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            If gvbody.FooterRow.Cells(4).Text = "0.00" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If

            Dim txtcost As TextBox = CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox)
            txtcost.Attributes.Add("onFocus", "this.select()")
            txtcost.Attributes.Add("onClick", "this.select()")
            txtcost.Focus()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtcost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            If txtcost.Text = "" Then
                txtcost.Text = "0.00"
            End If
            txtcost.Text = FormatNumber(txtcost.Text, 2)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            gvbody.Rows(gvr.RowIndex).Cells(4).Text = FormatNumber(CType(txtcost.Text, Decimal) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox).Text, Integer))

            pItems.Rows(gvr.RowIndex)("price") = CType(txtcost.Text, Decimal)
            pItems.Rows(gvr.RowIndex)("total") = FormatNumber(CType(txtcost.Text, Decimal) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox).Text, Integer))
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)

            If gvbody.FooterRow.Cells(4).Text = "0.00" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
            Dim txtqty As TextBox = CType(gvbody.Rows(gvr.RowIndex + 1).FindControl("txtqty"), TextBox)
            txtqty.Attributes.Add("onFocus", "this.select()")
            txtqty.Attributes.Add("onClick", "this.select()")
            txtqty.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ddReceivedBy.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")
            Exit Sub
        End If

        Try
            '=-= SAVE AMS.Tb_Receiving
            With rcv
                .Received_Date = txtprdate.Text
                .ReceivedBY = ddReceivedBy.SelectedItem.Value
                .POHdr_ID = 0
                .PO_No = "Donation"
                .Supplier_ID = 0
                .GA_ID = 0
                .isAccepted = False
                .UserID = Session("@UserName")
            End With

            rcvID = rcv.save
            Session("Received_ID") = rcvID


            For i As Integer = 0 To gvbody.Rows.Count - 1
                If gvbody.Rows(i).Cells(4).Text <> "0.00" Then

                    '=-= SAVE AMS.Tb_Receiving_Dtl
                    With rcv_dtl
                        .Received_ID = rcvID
                        .Item_ID = pItems.Rows(i)("Item_ID")
                        .PO_Qty = pItems.Rows(i)("qty")
                        .Qty_Received = pItems.Rows(i)("qty")
                        .Cost = pItems.Rows(i)("price")
                        .Condition = ""
                        .Location = ""
                    End With
                    Dim RcvDtl_ID As Long = rcv_dtl.save

                    Session("Received_Dtl_ID") = RcvDtl_ID

                    objProperty.Property_Date = txtprdate.Text
                    objProperty.Property_code = pItems.Rows(i)("GA_code")
                    objProperty.Item_ID = pItems.Rows(i)("Item_ID")
                    objProperty.Qty = pItems.Rows(i)("qty")
                    objProperty.Balance = pItems.Rows(i)("qty")
                    objProperty.Issuance = "0"
                    objProperty.Cost = pItems.Rows(i)("price")
                    objProperty.RC_ID = objDerived.GetValue("select RC_ID From [dbo].[View_RespCenter_withFunctions] where RC_Name like '%PROVINCIAL GENERAL SERVICES OFFICE%'", CommandType.Text)
                    objProperty.Function_ID = 86
                    objProperty.Remarks = txtremarks.Text
                    objProperty.isDonated = True
                    objProperty.GA_ID = pItems.Rows(i)("GA_ID")
                    objProperty.F_ID = 1 'Me.drpfund.Sele   tedItem.Value 'objDerived.GetValue("SELECT     F_ID FROM ACCNTG.Funds WHERE     FundCode ='" & drpfund.SelectedValue.ToString & "' ", CommandType.Text)
                    objProperty.AIRDtl_ID = 0
                    objProperty.DonationRemarks = txtremarks.Text
                    objProperty.deptid = 1
                    objProperty.Particular = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN  AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID ='" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)

                    Dim Property_ID As Long = objProperty.save()
                    Session("id2") = Property_ID
                    objDerived.GetRecords("UPDATE AMS.Property SET POHdr_ID = 0, Received_ID = '" & Session("Received_ID") & "' WHERE Property_ID = '" & Session("id2") & "'", CommandType.Text)

                    objDonation_Hdr.ReferenceNo = txtRef.Text
                    objDonation_Hdr.Property_ID = Property_ID
                    objDonation_Hdr.AcceptedBy = ddReceivedBy.SelectedItem.Text
                    objDonation_Hdr.Item_ID = pItems.Rows(i)("Item_ID")
                    Dim DonationHdr_ID As Long = objDonation_Hdr.save()


                    Dim Prop As String
                    '===== Property Details ======
                    For cnt As Integer = 0 To CType(CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text, Integer) - 1
                        Prop = objDerived.GetValue("SELECT [dbo].[func_GeneratePropertyNo_BATAAN] ('" & Date.Today.ToString("MM/dd/yyyy") & "','" & pItems.Rows(i)("GA_code") & "','" & 3 & "','" & 86 & "')", CommandType.Text)
                        propertDtl.PropertyNo = Prop
                        propertDtl.Property_ID = Property_ID
                        'propertDtl.RC_ID = 0
                        propertDtl.Status = "Accepted"
                        propertDtl.Issued = False
                        propertDtl.Dispose = False
                        propertDtl.Repair = False
                        propertDtl.DisposeDate = "01/01/1900"
                        propertDtl.IsInspectionForDisposal = False
                        propertDtl.InspectionDate = "01/01/1900"
                        propertDtl.Amount = pItems.Rows(i)("price")
                        propertDtl.type = objDerived.GetValue("SELECT AMS.item_particular.description FROM dbo.m_item INNER JOIN  AMS.item_particular ON dbo.m_item.item_particular_id = AMS.item_particular.item_particular_id where Item_ID ='" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                        Dim ID_Dtl As Long = propertDtl.save()

                        objLedger.GetDataTable("Update AMS.Property_Dtl set Donated=1 where PropertyDetai_ID=" & ID_Dtl & "", CommandType.Text)

                        '===== Ledger ======
                        dtPropLedger = objLedger.GetDataTable("Select DonationLedger_ID from AMS.TbDonation_Ledger", CommandType.Text)
                        With objLedger
                            '.DonationLedger_ID = DonationLedger_ID
                            .PropertyNo = Prop
                            .SerialNo = ""
                            .Trans_Type = "Donation"
                            .Ref = txtRef.Text
                            .AccountablePerson = ""
                            .Department = ""
                            .Position = ""
                            .AcceptedBy = ddReceivedBy.SelectedItem.Text
                            .InspectedBy = ""
                            .Item_ID = pItems.Rows(i)("Item_ID")

                            .DebitQty = 1
                            .DebitCost = CType(pItems.Rows(i)("price"), Decimal)
                            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)

                            .CreditQty = "0"
                            .CreditUnit = "-"
                            .CreditCost = "0.00"

                            .BalanceQty = 1
                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM dbo.m_item INNER JOIN AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID where Item_ID ='" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                            .BalanceCost = CType(pItems.Rows(i)("price"), Decimal)

                            If txtprdate.Text = "" Then
                                .dDate = Date.Today.ToString("MM/dd/yyyy")
                            Else
                                .dDate = txtprdate.Text
                            End If

                        End With

                        objLedger.DonationLedger_ID = 0
                        objLedger.save()


                        Dim Prop_Ledger As New t_PropertyLedger

                        With Prop_Ledger
                            .Ledger_ID = 0
                            .PropertyNo = ""
                            .SerialNo = ""
                            .Trans_Type = "Manual Entry"
                            .dDate = txtprdate.Text
                            .Ref = ""
                            .AccountablePerson = ""
                            .Department = 0
                            .Position = ""
                            .AcceptedBy = ""
                            .InspectedBy = ""
                            .Item_ID = pItems.Rows(i)("Item_ID")
                            .DebitQty = pItems.Rows(i)("qty")
                            .DebitCost = (CType(pItems.Rows(i)("price"), Decimal) * pItems.Rows(i)("qty"))
                            .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                            .CreditQty = "0"
                            .CreditUnit = "-"
                            .CreditCost = "0.00"
                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)

                            Dim Eqty As Integer
                            Dim Eqbalance As Decimal
                            Dim dtledger As New DataTable

                            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                            If dtledger.Rows.Count = 0 Then
                                Eqty = 0
                                Eqbalance = 0.0
                            Else
                                Eqty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                                Eqbalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & pItems.Rows(i)("Item_ID") & "'", CommandType.Text)
                            End If
                            .BalanceQty = Eqty + pItems.Rows(i)("qty")
                            .BalanceCost = (CType(pItems.Rows(i)("price"), Decimal) * pItems.Rows(i)("qty")) + CType(Eqbalance, Decimal)

                        End With
                        Prop_Ledger.save()


                    Next
                End If
            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            btnSave.Enabled = False
            btnadd.Enabled = False
            btnReceiving.Enabled = True
            txtprdate.ReadOnly = True
            txtremarks.ReadOnly = True

            Dim myview As DataView
            myview = pItems.DefaultView

            myview.RowFilter = "total <> 0.00 "
            gvbody.DataSource = myview
            gvbody.DataBind()
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)

            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
                CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = True
            Next

            gvbody.DataSource = Nothing
            gvbody.DataBind()

            Dim dtDonation As New DataTable
            dtDonation = objDerived.GetDataTable("Select * from dbo.view_DonationDtl where ReferenceNo = '" & txtRef.Text & "'", CommandType.Text)
            If dtDonation.Rows.Count < 8 Then
                dtDonation.Merge(createdatatable1(7 - dtDonation.Rows.Count))
                grdDonationDtl.DataSource = dtDonation
                grdDonationDtl.DataBind()
            Else
                grdDonationDtl.DataSource = dtDonation
                grdDonationDtl.DataBind()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = pPopupitems.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtsearchitems.Text.ToString) & "%'"
        gvitems.DataSource = myview
        gvitems.DataBind()
        gvitems.PageIndex = 0


        Session("Search1") = 1
        ModalPopupExtender1.Show()

    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Session("Search1") = 0 Then
            pPopupitems = objDerived.GetDataTable("exec [AMS].[sp_loadProperty_Donation]", CommandType.Text)
            gvitems.PageIndex = e.NewPageIndex
            gvitems.DataSource = pPopupitems
            gvitems.DataBind()

        ElseIf Session("Search1") = 1 Then
            Dim myview As DataView
            myview = pPopupitems.DefaultView
            myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtsearchitems.Text.ToString) & "%'"
            gvitems.PageIndex = e.NewPageIndex
            gvitems.DataSource = myview
            gvitems.DataBind()
        End If

        ModalPopupExtender1.Show()
   
    End Sub
    Protected Sub grdDonationDtl_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdDonationDtl, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grdDonationDtl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        loadDonationDTL()
        
    End Sub
    Protected Sub loadDonationDTL()
        Dim dtSearch As New DataTable
        dtSearch = objDerived.GetDataTable("Select * from dbo.view_DonationDtl where PropertyNo ='" & grdDonationDtl.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtSearch.Rows.Count = 0 Then
            txtRef.Text = ""
            txtremarks.Text = ""

            txtItemDesc.Text = ""
            txtBrandName.Text = ""
            txtSerialNo.Text = ""
            txtStorage.Text = ""
            txtDepRate.Text = ""
            txtDepValue.Text = ""

            txtDonationType.Text = ""
            txtDonorName.Text = ""
            txtAddress.Text = ""
            txtTelephone.Text = ""
            txtEmail.Text = ""

            txtForm.Text = ""
            txtQTCRx.Text = ""
            txtMftg.Text = ""
            txtBatch.Text = ""
            txtLot.Text = ""
            txtExpire.Text = ""
            txtAlert.Text = ""
        Else
            txtRef.Text = dtSearch.Rows(0).Item("ReferenceNo").ToString
            txtremarks.Text = dtSearch.Rows(0).Item("Remarks").ToString

            txtItemDesc.Text = dtSearch.Rows(0).Item("Item_Desc").ToString
            txtBrandName.Text = dtSearch.Rows(0).Item("BrandName").ToString
            txtSerialNo.Text = dtSearch.Rows(0).Item("SerialNo").ToString
            txtStorage.Text = dtSearch.Rows(0).Item("Storage").ToString
            txtDepRate.Text = dtSearch.Rows(0).Item("DepreciationRate").ToString
            txtDepValue.Text = dtSearch.Rows(0).Item("DepreciationValue").ToString

            txtDonationType.Text = dtSearch.Rows(0).Item("DonationType").ToString
            txtDonorName.Text = dtSearch.Rows(0).Item("DonorName").ToString
            txtAddress.Text = dtSearch.Rows(0).Item("Address").ToString
            txtTelephone.Text = dtSearch.Rows(0).Item("TelephoneNo").ToString
            txtEmail.Text = dtSearch.Rows(0).Item("Email").ToString

            txtForm.Text = ""
            txtQTCRx.Text = ""
            txtMftg.Text = ""
            txtBatch.Text = ""
            txtLot.Text = ""
            txtExpire.Text = ""
            txtAlert.Text = ""

            btnSaveDonationDtl.Enabled = True
        End If

        txtForm.ReadOnly = True
        txtQTCRx.ReadOnly = True
        txtMftg.ReadOnly = True
        txtBatch.ReadOnly = True
        txtLot.ReadOnly = True
        txtExpire.ReadOnly = True
        txtAlert.ReadOnly = True

    End Sub

    Protected Sub grdDonationDtl_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Session("Search2") = 0 Then
            dtDonations = objDerived.GetDataTable("Select * from dbo.view_DonationDtl where Donation_ID = 0 order by Item_Desc", CommandType.Text)
            grdDonationDtl.PageIndex = e.NewPageIndex
            grdDonationDtl.DataSource = dtDonations
            grdDonationDtl.DataBind()

        ElseIf Session("Search2") = 1 Then
            Dim myview As DataView
            myview = dtDonations.DefaultView
            myview.RowFilter = "ReferenceNo like '%" & replaceapostrophe(txtSearchREF.Text.ToString) & "%'"
            grdDonationDtl.PageIndex = e.NewPageIndex
            grdDonationDtl.DataSource = myview
            grdDonationDtl.DataBind()

        End If
    End Sub

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Price", GetType(Decimal))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyNo") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Price") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub btnSaveDonationDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        dtDonation = objDonation.GetDataTable("Select Donation_ID from AMS.TbDonations where PropertyNo ='" & grdDonationDtl.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        With objDonation
            .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
            .Item_ID = grdDonationDtl.SelectedDataKey("Item_ID")
            .BrandName = txtBrandName.Text
            .SerialNo = txtSerialNo.Text
            .Storage = txtStorage.Text

            If txtDepRate.Text = "" Then
                .DepreciationRate = "0.00"
            Else
                .DepreciationRate = txtDepRate.Text
            End If

            If txtDepValue.Text = "" Then
                .DepreciationValue = "0.00"
            Else
                .DepreciationValue = txtDepValue.Text
            End If

            .DonationType = txtDonationType.Text
            .DonorName = txtDonorName.Text
            .Address = txtAddress.Text
            .TelephoneNo = txtTelephone.Text
            .Email = txtEmail.Text

            'txtForm.Text
            'txtQTCRx.Text
            'txtMftg.Text
            'txtBatch.Text
            'txtLot.Text
            'txtExpire.Text
            'txtAlert.Text
        End With






        objDerived.GetRecords("Update AMS.Property_Dtl set SerialNo ='" & txtSerialNo.Text & "' where PropertyNo ='" & grdDonationDtl.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        If dtDonation.Rows.Count = 0 Then
            objDonation.Donation_ID = 0
            objDonation.save()
            Donation_ID = objDonation.GetValue("Select max(Donation_ID) from AMS.TbDonations ", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
        Else
            Donation_ID = objDonation.GetValue("Select Donation_ID from AMS.TbDonations where PropertyNo ='" & grdDonationDtl.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            objDonation.Donation_ID = Donation_ID
            objDonation.update()
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")
        End If

        btnSaveDonationDtl.Enabled = False


        Dim AllotmentClass_ID As Integer
        Dim a As Integer = grdDonationDtl.SelectedDataKey("GA_ID")
        AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdDonationDtl.SelectedDataKey("GA_ID") & "' ", CommandType.Text)
        If AllotmentClass_ID = 2 Then '=-= MOOE ITEMS


            If grdDonationDtl.SelectedDataKey("GA_ID") = 1427 Then '=== grdAIR.SelectedDataKey("GA_ID") = 788 Then
                '=-= OFFICE SUPPLIES 
                With OfficeSup
                    .StockID = 0
                    .AIRDtl_ID = 0
                    .ItemId = grdDonationDtl.SelectedDataKey("Item_ID")
                    .Description = txtItemDesc.Text
                    .BrandName = txtBrandName.Text
                    .SupplierId = 0
                    .Size = ""
                    .Color = ""
                    .Category = ""
                    .Length = ""
                    .Width = ""
                    .Height = ""
                    .Weight = ""
                    .DepreciatedRate = 0

                    .DepreciatedValue = 0

                    .Status = "Received"
                    .Received_ID = rcvID
                    .Componentof = ""
                End With
                'here fix
                Dim Supp_ID As Long = OfficeSup.save

            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1432 Or grdDonationDtl.SelectedDataKey("GA_ID") = 1433 Then '=== grdAIR.SelectedDataKey("GA_ID") = 792 Or grdAIR.SelectedDataKey("GA_ID") = 793 Then
                '=-= MEDICINES SUPPLIES AND MEDICAL SUPPLIES
                With MedInfo
                    .StockId = 0
                    .AIRDtl_ID = 0
                    .Item_ID = grdDonationDtl.SelectedDataKey("Item_ID")
                    .DeliveryDate = ""
                    .Description = txtItemDesc.Text
                    .DrugName = ""
                    .BrandName = txtBrandName.Text
                    .SupplierId = 0
                    .Dose = ""
                    .Location = ""
                    .Status = "Received"
                    .Received_ID = rcvID
                    .Depreciatedrate = 0

                    .Depreciatedvalue = 0


                End With

                Dim MedID As Long = MedInfo.save

                With MedDtl
                    .MedicineID = MedID
                    .StockId = 0
                    .Item_ID = grdDonationDtl.SelectedDataKey("Item_ID")
                    .Form = ""
                    .OTCRx = ""
                    .Batch = ""
                    .Lot = ""
                    .Mftgdate = "01/01/1900"
                    .EpiryDate = "01/01/1900"
                    .Alert = "01/01/1900"
                    .save()
                End With


            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1441 Then '=== grdAIR.SelectedDataKey("GA_ID") = 799 Then
                '=-= WATER SUPPLIES
                With Water
                    .StockId = 0
                    .AIRDtl_ID = 0
                    .Item_ID = grdDonationDtl.SelectedDataKey("Item_ID")
                    .DeliveryDate = ""
                    .Form = ""
                    .OTCRx = ""
                    .Batch = ""
                    .Lot = ""
                    .Mftgdate = "01/01/1900"
                    .EpiryDate = "01/01/1900"
                    .Alert = ""
                    .ItemDesc = txtItemDesc.Text
                    .BrandName = txtBrandName.Text
                    .Supplier_Id = 0
                    .Storage = ""
                    .Depreciationrate = 0
                    .Depreciationvalue = 0
                    .Status = "Received"
                    .Received_ID = rcvID
                End With

                Dim WaterID As Long = Water.save

            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1430 Then '=== grdAIR.SelectedDataKey("GA_ID") = 791 Then
                '=-= FOOD SUPPLIES
                With Food
                    .StockId = 0
                    .AIRDtl_ID = 0
                    .Item_ID = grdDonationDtl.SelectedDataKey("Item_ID")
                    .DeliveryDate = ""
                    .Form = ""
                    .OTCRx = ""
                    .Batch = ""
                    .Lot = ""
                    .Mftgdate = "01/01/1900"
                    .EpiryDate = "01/01/1900"
                    .Alert = "01/01/1900"
                    .ItemDesc = txtItemDesc.Text
                    .BrandName = txtBrandName.Text
                    .Supplier_Id = 0
                    .Storage = ""
                    .Depreciationrate = 0

                    .Depreciationvalue = 0

                    .Status = "Received"
                    .Received_ID = rcvID
                End With

                Dim FoodID As Long = Food.save

            Else '=-= OTHER SUPPLIES 
                With NonFood
                    .StockId = 0
                    .AIRDtl_ID = 0
                    .Item_ID = grdDonationDtl.SelectedDataKey("Item_ID")
                    .DeliveryDate = ""
                    .Form = ""
                    .OTCRx = ""
                    .Batch = ""
                    .Lot = ""
                    .Mftgdate = "01/01/1900"
                    .EpiryDate = "01/01/1900"
                    .Alert = "01/01/1900"
                    .ItemDesc = txtItemDesc.Text
                    .BrandName = txtBrandName.Text
                    .Supplier_Id = 0
                    .Storage = ""

                    .Depreciationvalue = 0


                    .Status = "Received"
                    .Received_ID = rcvID
                End With

                Dim NonFoodID As Long = NonFood.save

            End If




        ElseIf AllotmentClass_ID = 3 Then '=-= CAPITAL OUTLAY ITEMS

            If grdDonationDtl.SelectedDataKey("GA_ID") = 1060 Or grdDonationDtl.SelectedDataKey("GA_ID") = 1062 Or grdDonationDtl.SelectedDataKey("GA_ID") = 1067 Then '=== grdAIR.SelectedDataKey("GA_ID") = 520 Or grdAIR.SelectedDataKey("GA_ID") = 521 Then
                '=-= LAND
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")
                With LandDtl
                    '.LandId = LandId
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
                    .DepreciationRate = 0
                    .DepreciationValue = 0
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
                    .AssessedValue = ""
                    .MarketValue = ""
                    .UnitValue = ""
                    .Taxable = ""


                    .AssessedDate = "01/01/1900"



                    .MarketDate = "01/01/1900"



                    .UnitDate = "01/01/1900"

                    .Received_ID = rcvID
                    .save()
                End With

            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1082 Or grdDonationDtl.SelectedDataKey("GA_ID") = 1085 Then '=== grdAIR.SelectedDataKey("GA_ID") = 525 Or grdAIR.SelectedDataKey("GA_ID") = 526 Then
                '=-= BUILDINGS
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Not Available at this Time, Contanct Administrator.")
                With BldgInfo
                    '.BuildingId = BuildingId
                    .BuildingControlNo = ""
                    .BuildingCode = ""
                    .BuildingName = ""
                    .Address = ""
                    .PostalCode = ""


                    .BuildingDepreciationRate = "0.00"

                    .BuildingUse = ""
                    .BuildingOccupancy = ""
                    .NumberFloors = ""
                    .AvgAreaFloor = ""
                    .CostPerArea = ""
                    '.Status_AIR = ""


                    .BuildingDepreciationValue = "0.00"

                    .Received_ID = rcvID
                    .save()

                End With


            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1118 Then '=== grdAIR.SelectedDataKey("GA_ID") = 534 Then
                '=-= FURNITURE AND FIXTURES
                With FurnitureInfo
                    .AIRDtl_ID = 0
                    .IsAccepted = False
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .SerialNo = txtSerialNo.text
                    .Name = txtSerialNo.text
                    .Description = txtItemDesc.Text
                    .Dimension = ""
                    .AreaCapacity = ""
                    .Model = ""
                    .Warranty = ""
                    .Specification = ""
                    .DepreciationRate = 0

                    .DepreciationValue = 0

                    .Received_ID = rcvID
                End With

                Dim FurniID As Long = FurnitureInfo.save
                objDerived.GetRecords("UPDATE AMS.TbFurniture_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE FurnitureInfoId = '" & FurniID & "'", CommandType.Text)

                With FurnitureDtl
                    .FurnitureInfoId = FurniID
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .MarketValue = 0
                    .Condition = ""
                    .Location = ""
                    .Status = "Received"
                    .save()
                End With

            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1127 Then '=== grdAIR.SelectedDataKey("GA_ID") = 537 Then
                '=-= MACHINIRIES
                With MachineInfo
                    .AIRDtl_ID = 0
                    .IsAccepted = False
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .SerialNo = txtSerialNo.text
                    .MachineDesc = txtItemDesc.Text
                    .MachineLocation = ""
                    .BrandModel = ""
                    .DepreciationRate = 0

                    .DepreciationValue = 0

                    .Received_ID = rcvID
                End With

                Dim MachineID As Long = MachineInfo.save
                objDerived.GetRecords("UPDATE AMS.TbMachinery_Information SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE MachineryInfoId = '" & MachineID & "'", CommandType.Text)

                With MachineDtl
                    .MachineryInfoId = MachineID
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .MarketValue = 0
                    .Condition = ""
                    .Location = ""
                    .Status = "Received"
                    .save()
                End With

            ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1166 Then
                '=-= TRANSPORTATION
                With MotorInfo
                    .AIRDtl_ID = 0
                    .IsAccepted = False
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .Name = txtItemDesc.Text
                    .PlateNo = ""
                    .Model = ""
                    .MotorNo = ""
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
                    .Received_ID = rcvID
                End With

                Dim MotorID As Long = MotorInfo.save
                objDerived.GetRecords("UPDATE AMS.TbMotor_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "', CSNo = '" & 0 & "', EngineNo = '" & 0 & "', Displacement = '" & 0 & "' WHERE Motor_InfoId = '" & MotorID & "'", CommandType.Text)

                With MotorDtl
                    .Motor_InfoId = MotorID
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .MarketValue = 0
                    .Condition = ""
                    .Location = ""
                    .Status = "Received"
                    .save()
                End With

            Else '=-= ALL EQUIPMENTS
                With EquipInfo
                    .AIRDtl_ID = 0
                    .IsAccepted = False
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .SerialNo = txtSerialNo.text
                    .Name = txtItemDesc.Text
                    .Description = ""
                    .PowerInput = ""
                    .Dimension = ""
                    .AreaCapacity = ""
                    .Model = ""
                    .Warranty = ""
                    .Specification = ""
                    .DepreciationRate = 0

                    .DepreciationValue = 0

                    .Received_ID = rcvID
                End With

                Dim EuipID As Long = EquipInfo.save
                objDerived.GetRecords("UPDATE AMS.TbEquipment_Info SET Received_Dtl_ID = '" & Session("Received_Dtl_ID") & "' WHERE EquipInfoId = '" & EuipID & "'", CommandType.Text)

                With EquipDtl
                    .EquipInfoId = EuipID
                    .Property_Dtl_ID = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
                    .MarketValue = 0
                    .Condition = ""
                    .Location = ""
                    .Status = "Received"
                    .save()
                End With

            End If


        End If

        dtDonations = objDerived.GetDataTable("Select * from dbo.view_DonationDtl where Donation_ID = 0 order by Item_Desc", CommandType.Text)
        grdDonationDtl.DataSource = dtDonations
        grdDonationDtl.DataBind()
        Session("Search2") = 0

        txtItemDesc.Text = ""
        txtBrandName.Text = ""
        txtSerialNo.Text = ""
        txtStorage.Text = ""
        txtDepRate.Text = ""
        txtDepValue.Text = ""

        txtDonationType.Text = ""
        txtDonorName.Text = ""
        txtAddress.Text = ""
        txtTelephone.Text = ""
        txtEmail.Text = ""








    End Sub

    Protected Sub btnRefSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim myview As DataView
            myview = dtDonations.DefaultView
            myview.RowFilter = "ReferenceNo like '%" & replaceapostrophe(txtSearchREF.Text.ToString) & "%'"
            grdDonationDtl.DataSource = myview
            grdDonationDtl.DataBind()
            grdDonationDtl.PageIndex = 0

            Session("Search2") = 1

            loadDonationDTL()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnReceiving_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "Donation"
        Me.Page.Response.Redirect("~/procurement/t_rpt_receiving.aspx")
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_inventory_Donation.aspx")
    End Sub
End Class
