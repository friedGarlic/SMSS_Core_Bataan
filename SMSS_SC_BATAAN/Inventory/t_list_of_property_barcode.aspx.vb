Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.HtmlControls
Imports System.IO
Partial Class t_list_of_property_barcode
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private dtl As New RISDtl
    Private hdr As New RISHdr
    Private objPropertyDtl As New t_property_dtl
    Private objMREHdr As New MREHdr
    Private objMREDtl As New MREDtl
    Private objMREReturn As New MRE_Return
    Dim msg As New MsgeBox
    Dim image As New Image
    Private objMenuCntrl As New ManageButtons
    ' Dim imageDocument As New BuildingDocuments

    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable

    Dim objStockLedger As New t_StockLedger
    Dim StockLedger_ID As New Integer
    Dim dtStockLedger As New DataTable

#Region "Property"
    Private Property Ppropertylist() As DataTable
        Get
            Return CType(Session("propertylist"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("propertylist") = value
        End Set
    End Property

    Private Property PdepartmentPersonnel() As DataTable
        Get
            Return CType(Session("departmentPersonnel"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("departmentPersonnel") = value
        End Set
    End Property

    Private Property pemployee() As DataTable
        Get
            Return CType(Session("pemployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pemployee") = value
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

    Private Property pbody() As DataTable
        Get
            Return CType(Session("pbody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pbody") = value
        End Set
    End Property
    Private Property pnew() As DataTable
        Get
            Return CType(Session("pnew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pnew") = value
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

    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set
    End Property

    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grListOfProperty.Columns(8).Visible = False
        txtDateReceivedFrom.Text = Date.Today.ToString("MM/dd/yyyy")
        txtDateReceivedBy.Text = Date.Today.ToString("MM/dd/yyyy")

        Me.btnADD.Enabled = False
        If Not Page.IsPostBack Then
            Dim dProperty As New DataTable
            dProperty = objDerived.GetDataTable("SELECT * FROM TbProperty_Type order BY sequence", CommandType.Text)
            ddProperty.DataSource = dProperty
            ddProperty.DataTextField = ("description")
            ddProperty.DataValueField = ("PropertyType_Id")
            ddProperty.DataBind()

            LoadPropertyDropDown()

            If gvDocumentAdded.Rows.Count < 4 Then
                gvDocumentAdded.DataSource = CreatedatatableScannedDoc(4)
                gvDocumentAdded.DataBind()
            End If



            'Requsition adn Issuance / dbo.TbSupply_Type
            Dim dSupply As New DataTable
            dSupply = objDerived.GetDataTable("SELECT * FROM TbSupply_Type", CommandType.Text)
            ddSupplies.DataSource = dSupply
            ddSupplies.DataTextField = ("Description")
            ddSupplies.DataValueField = ("SupplyType_Id")
            ddSupplies.DataBind()


            Dim dtsupp As New DataTable
            dtsupp = objDerived.GetDataTable("Select * From dbo.View_StockIssuance where GA_ID = '" & 792 & "'", CommandType.Text)
            If dtsupp.Rows.Count = 0 Then
                gvSupplyList.DataSource = CreatedatatableSupplist(5)
                gvSupplyList.DataBind()
            Else
                If dtsupp.Rows.Count < 5 Then
                    dtsupp.Merge(CreatedatatableSupplist(9 - dtsupp.Rows.Count))
                    gvSupplyList.DataSource = dtsupp
                    gvSupplyList.DataBind()
                Else
                    gvSupplyList.DataSource = dtsupp
                    gvSupplyList.DataBind()

                End If
            End If
            gvSupplyList.Columns(4).Visible = False




            btnsave.Enabled = False
            ' txtfrom.Text = "ROMULO M. CATINDIG" ''
            ' txtfrom.Text = IIf(IsDBNull(objDerived.GetValue("exec AMS.getsignatories 'Property Officer'", CommandType.Text), 0, objDerived.GetValue("exec AMS.getsignatories 'Property Officer'", CommandType.Text))
            txtfrom.Text = (IIf(IsDBNull(objDerived.GetValue("SELECT  TOP 1  full_name FROM HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes' ", CommandType.Text)), "", objDerived.GetValue("SELECT  TOP 1  full_name FROM HRMS.view_signatory where deptid = 7 AND division_key = 86 AND isDeptHead = 'Yes' ", CommandType.Text)))

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            txtRIS.Text = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtdate.Text & "')", CommandType.Text)
            pbody = Nothing
            gvbody.DataSource = pbody
            gvbody.DataBind()
            pItems = Nothing
            'loadopenAck()
            'Requsition adn Issuance
        End If
        btnIssue.Enabled = False
        btnReturnProperty.Enabled = False
        btnviewProperty.Enabled = False
        txtSearchProperty.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchProperty.ClientID & "')")
    End Sub
    Protected Sub ddProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddProperty.SelectedIndexChanged
        LoadPropertyDropDown()
    End Sub
    Protected Sub LoadPropertyDropDown()
        If ddProperty.SelectedValue = 1 Then
            ' LAND AND LAND IMPROVEMENTS
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '4'", CommandType.Text)

        ElseIf ddProperty.SelectedValue = 2 Then
            ' BUILDINGS
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '5'", CommandType.Text)

        ElseIf ddProperty.SelectedValue = 3 Then
            ' EQUIPMENTS
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '1'", CommandType.Text)

        ElseIf ddProperty.SelectedValue = 4 Then
            ' TRANSPORTATIONS
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '7'", CommandType.Text)

        ElseIf ddProperty.SelectedValue = 5 Then
            ' MACHINERIES
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '3'", CommandType.Text)

        ElseIf ddProperty.SelectedValue = 6 Then
            ' FURNITURE AND FIXTURES
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '6'", CommandType.Text)

        ElseIf ddProperty.SelectedValue = 7 Then
            ' AMBULANCE
            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '2'", CommandType.Text)
        End If

        If Ppropertylist.Rows.Count < 10 Then
            Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()
        Else
            gvsearchProperty.DataSource = Ppropertylist
            gvsearchProperty.DataBind()
        End If
        grListOfProperty.DataSource = CreatedatabalegrListOfProperty(4)
        grListOfProperty.DataBind()
    End Sub
    'ARE
    Protected Sub btnSearchProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Ppropertylist = objDerived.GetDataTable("Select * from ams.vw_ListofProperty where Item_Desc like '%" & txtSearchProperty.Text & "%'", CommandType.Text)
        If Ppropertylist.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No data found.")
            txtSearchProperty.Text = ""
        Else
            If Ppropertylist.Rows.Count < 8 Then
                Ppropertylist.Merge(Createdatabalegvsearch(7 - Ppropertylist.Rows.Count))
                gvsearchProperty.DataSource = Ppropertylist
                gvsearchProperty.DataBind()
                gvsearchProperty.SelectedIndex = 0
            Else
                gvsearchProperty.DataSource = objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList]", CommandType.Text)
                gvsearchProperty.DataBind()
                gvsearchProperty.SelectedIndex = 0
            End If
            LoadwithOutProperty()
        End If
    End Sub
    Protected Sub gvsearchProperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvsearchProperty.PageIndexChanging
        Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList]", CommandType.Text)
        If Ppropertylist.Rows.Count < 10 Then
            Ppropertylist.Merge(Createdatabalegvsearch(9 - Ppropertylist.Rows.Count))
        End If
        gvsearchProperty.PageIndex = e.NewPageIndex
        gvsearchProperty.DataSource = Ppropertylist
        gvsearchProperty.DataBind()
        gvsearchProperty.SelectedIndex = 0

        LoadwithOutProperty()

        'gvsearchProperty.SelectedIndex = 1
        'gvsearchProperty.PageIndex = e.NewPageIndex
        'gvsearchProperty.DataSource = Ppropertylist
        'gvsearchProperty.DataBind()
    End Sub
    Protected Sub gvsearchProperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvsearchProperty.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvsearchProperty, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub gvsearchProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvsearchProperty.SelectedIndexChanged
        btnsavedoc.Enabled = False
        btncancelDoc.Enabled = False
        btnpreviewAreDoc.Enabled = False
        LoadwithOutProperty()
    End Sub
    Public Sub LoadwithOutProperty() '[dbo].[ProtertyToIssue]
        'Ppropertylist = Me.objDerived.GetDataTable("Select * from dbo.View_PropertyToIssue where item_id = '" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)
        Ppropertylist = Me.objDerived.GetDataTable("exec [dbo].[SMSS_ProtertyToIssue] '" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)
        If Ppropertylist.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No property selected.")
        Else
            btnviewProperty.Enabled = True
            Dim ItemId As New Integer
            ItemId = Me.gvsearchProperty.SelectedDataKey("Item_id").ToString
            Session("itemId") = ItemId
            If Ppropertylist.Rows.Count < 5 Then
                Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
                grListOfProperty.DataSource = Ppropertylist
                grListOfProperty.DataBind()
                grListOfProperty.SelectedIndex = 0

            Else
                grListOfProperty.DataSource = Ppropertylist
                grListOfProperty.DataBind()
                grListOfProperty.SelectedIndex = 0
            End If
            LoadPropertyListChangeIndex()
        End If
    End Sub

    Protected Sub grListOfProperty_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grListOfProperty.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffcc' cssclass='text'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White' cssclass='text' ")

            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grListOfProperty, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub grListOfProperty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grListOfProperty.PageIndexChanging
        Ppropertylist = Me.objDerived.GetDataTable("Select * from dbo.View_PropertyToIssue where item_id = '" & gvsearchProperty.SelectedDataKey("Item_id") & "'", CommandType.Text)
        If Ppropertylist.Rows.Count < 5 Then
            Ppropertylist.Merge(CreatedatabalegrListOfProperty(4 - Ppropertylist.Rows.Count))
            grListOfProperty.PageIndex = e.NewPageIndex
            grListOfProperty.DataSource = Ppropertylist
            grListOfProperty.DataBind()
            grListOfProperty.SelectedIndex = 0
        Else
            grListOfProperty.PageIndex = e.NewPageIndex
            grListOfProperty.DataSource = Ppropertylist
            grListOfProperty.DataBind()
            grListOfProperty.SelectedIndex = 0
        End If

        LoadPropertyListChangeIndex()
        LoadAttchDocu()
    End Sub
    Protected Sub grListOfProperty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grListOfProperty.SelectedIndexChanged
        LoadPropertyListChangeIndex()
    End Sub
    Protected Sub LoadPropertyListChangeIndex()
        Me.HiddenField1.Value = grListOfProperty.SelectedDataKey("status").ToString
        If HiddenField1.Value = "Returned" Then 'Or HiddenField1.Value = " - " Then 'HiddenField1.Value = "" Or
            Session("Status") = "Returned"
            Session("MRE_Return") = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            btnIssue.Enabled = True
            btnviewProperty.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = True
            Session("MREID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            btnReturnProperty.Enabled = False
            LoadNoAttchment()

            txtMRE.Text = ""

        ElseIf HiddenField1.Value = "Disposed" Then
            Session("Status") = "Disposed"
            Session("MRE_Return") = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            btnIssue.Enabled = False
            btnviewProperty.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False

        ElseIf HiddenField1.Value = "On Hand" Then
            Session("Status") = "On Hand"
            Session("MRE_Return") = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)

            Dim dtMRE As New DataTable
            dtMRE = objDerived.GetDataTable("Select * from  dbo.view_MRE where PropertyNo = '" & grListOfProperty.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
            If dtMRE.Rows.Count = 0 Then

            Else
                txtMRE.Text = dtMRE.Rows(0).Item("MRENumber").ToString
            End If

            btnIssue.Enabled = False
            btnviewProperty.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = True
            Session("MREID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            btnReturnProperty.Enabled = True
            LoadAttchDocu()

        ElseIf HiddenField1.Value = " - " Then
            btnIssue.Enabled = True
            btnviewProperty.Enabled = True

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False
            Session("MREID") = grListOfProperty.SelectedDataKey("MREHdr_ID")
            txtDateReturn.Text = Date.Today.ToString("MM/dd/yyyy")
            btnReturnProperty.Enabled = False
            LoadNoAttchment()

            txtMRE.Text = ""

        Else
            btnIssue.Enabled = False
            btnviewProperty.Enabled = False

            btnsavedoc.Enabled = False
            btncancelDoc.Enabled = False
            btnpreviewAreDoc.Enabled = False

            txtMRE.Text = ""

        End If

    End Sub

    Protected Sub btnIssue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIssue.Click
        Dim DepartmentHead As New DataTable
        Dim DepartmentPersonnel As New DataTable

        Dim txtMREDate As String
        txtMREDate = Date.Today.ToString("MM/dd/yyyy")
        txtMRE.Text = objDerived.GetValue("select AMS.func_GenerateMRE('" & txtMREDate & "')", CommandType.Text)


        If Me.HiddenField1.Value = " - " Or Me.HiddenField1.Value = "Returned" Then

            ddFromDepartment.Items.Clear()
            ddFromDepartment.Items.Add("Select")
            ddFromDepartment.Items.Add(grListOfProperty.SelectedDataKey("Rc_name").ToString)
            'ddFromDepartment.Items.Add("City General Services Office")

            ddByDepartment.Items.Clear()
            ddByDepartment.Items.Add("Select")
            ddByDepartment.Items.Add(grListOfProperty.SelectedDataKey("Rc_name").ToString)

            ddFromProperty.Items.Clear()
            ddFromProperty.Items.Add("Select")
            ddFromProperty.DataSource = objDerived.GetDataTable("Select * FROM [HRMS].[view_signatory] where isDeptHead='yes' and deptid= '" & grListOfProperty.SelectedDataKey("rc_id") & "'  and division_key = '" & grListOfProperty.SelectedDataKey("function_id") & "' or Office_Name='City General Services Office' and isDeptHead='yes'", CommandType.Text)
            ddFromProperty.DataTextField = ("full_name")
            ddFromProperty.DataValueField = ("empid")
            ddFromProperty.DataBind()

            ddByAcknowledgement.Items.Clear()
            ddByAcknowledgement.Items.Add("Select")
            ddByAcknowledgement.DataSource = objDerived.GetDataTable("Select *    FROM [HRMS].[view_signatory] where deptid=" & grListOfProperty.SelectedDataKey("rc_id").ToString & "  and division_key=" & grListOfProperty.SelectedDataKey("function_id").ToString & " ", CommandType.Text)
            ddByAcknowledgement.DataTextField = ("full_name")
            ddByAcknowledgement.DataValueField = ("empid")
            ddByAcknowledgement.DataBind()

            ddByAcknowledgement.Enabled = True
            ddByDepartment.Enabled = True
            ddFromDepartment.Enabled = True
            ddFromProperty.Enabled = True

            btnIssue.Enabled = False
        Else
            ddFromDepartment.SelectedValue = "Select"
            ddByDepartment.SelectedValue = "Select"
            ddFromProperty.SelectedValue = "Select"
            ddByAcknowledgement.SelectedValue = "Select"
            Me.ddByAcknowledgement.Enabled = True
            Me.ddByDepartment.Enabled = True
            Me.ddByAcknowledgement.Enabled = False
            Me.ddByDepartment.Enabled = False
            Me.ddFromDepartment.Enabled = False
            Me.ddFromProperty.Enabled = False
            'msg.UserMsgBox("This Property Number has been Issued", Me, False)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This property number has been issued.")

        End If
        btnsavedoc.Enabled = True
        btncancelDoc.Enabled = True
        'btnpreviewAreDoc.Enabled = True
    End Sub
    Protected Sub btnviewProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Records") = "Search"
        Session("ItemName") = gvsearchProperty.SelectedDataKey("ItemParticular")
        Session("GL_Account") = gvsearchProperty.SelectedDataKey("GA_ID")
        Me.Page.Response.Redirect("~/Records/PropertyCard_v3.aspx")

        'Dim MREID
        'MREID = Session("MREID")
        'Me.Page.Response.Redirect("~/Inventory/t_rpt_acknowledgement_receipt.aspx")
    End Sub
    Protected Sub btnReturnPro_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtReturnRemarks.Text = "" Or txtDateReturn.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Please fill up all fields.")
            LoadwithOutProperty()
            ModalPopupExtender3.Show()
        Else
            Dim dtReturns As New DataTable
            dtReturns = objDerived.GetDataTable("Select * from AMS.MRE_Returns where MRE_Dtl = '" & grListOfProperty.SelectedDataKey("MREDtl_ID") & "'", CommandType.Text)
            objMREReturn.MRE_Dtl = grListOfProperty.SelectedDataKey("MREDtl_ID")
            objMREReturn.PropertyNo = grListOfProperty.SelectedDataKey("PropertyNo")
            objMREReturn.MRE_Date = txtDateReturn.Text
            objMREReturn.Status = "Returned"
            objMREReturn.Remarks = txtReturnRemarks.Text
            objMREReturn.Dispose = False
            objMREReturn.Repair = False
            objMREReturn.Inspection = True
            objMREReturn.deptid = grListOfProperty.SelectedDataKey("rc_id")

            Dim dtMRet As New DataTable
            dtMRet = objDerived.GetDataTable("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo ='" & grListOfProperty.SelectedDataKey("PropertyNo") & "' ", CommandType.Text)
            If dtMRet.Rows.Count = 0 Then
                objMREReturn.saveMREReturn()
            Else
                objMREReturn.MRE_ReturnID = objDerived.GetValue("Select MRE_ReturnID from AMS.MRE_Returns where PropertyNo ='" & grListOfProperty.SelectedDataKey("PropertyNo") & "' ", CommandType.Text)
                objMREReturn.UpdateMREReturn()
            End If

            Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text))
            Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text))
            Dim Property_ID As Integer = Val(objDerived.GetValue("exec AMS.getProperty_ID '" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text))
            objDerived.GetRecords("Update AMS.Property set Balance='" & balance + 1 & "',Issuance='" & issuance - 1 & "' where  Property_ID='" & grListOfProperty.SelectedDataKey("Property_ID") & "'", CommandType.Text)
            objDerived.GetRecords("UPDATE AMS.Property_Dtl SET Issued ='False' WHERE PropertyNo='" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been successfully saved.")


            '==== Update LEDGER ====
            dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
            With objLedger
                '.Ledger_ID = Ledger_ID
                .PropertyNo = grListOfProperty.SelectedDataKey("PropertyNo")
                .SerialNo = grListOfProperty.SelectedDataKey("SerialNo")
                .dDate = txtDateReceivedFrom.Text
                .Trans_Type = "Returned"
                .Ref = ""
                .AccountablePerson = ""
                .Department = ""
                .Position = ""
                .AcceptedBy = ""
                .InspectedBy = ""
                '.DebitQty = ""
                '.DebitUnit = ""
                '.DebitCost = ""
                .CreditQty = "0"
                .CreditUnit = "-"
                .CreditCost = "0.00"
                '.BalanceQty = ""
                '.BalanceUnit = ""
                '.BalanceCost = ""

                .Item_ID = grListOfProperty.SelectedDataKey("Item_ID")

                .DebitQty = 1
                .DebitUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                .DebitCost = CType(grListOfProperty.SelectedDataKey("Cost"), Decimal)

                .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

                Dim eQty As Integer
                Dim eBalance As Decimal
                Dim dtledger As New DataTable

                dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                If dtledger.Rows.Count = 0 Then
                    eQty = 0
                    eBalance = 0.0
                Else
                    eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grListOfProperty.SelectedDataKey("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                    eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grListOfProperty.SelectedDataKey("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                End If

                .BalanceQty = eQty + 1
                .BalanceCost = CType(eBalance, Decimal) + CType(grListOfProperty.SelectedDataKey("Cost"), Decimal)
            End With

            objLedger.Ledger_ID = 0
            objLedger.save()


            Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3]", CommandType.Text)
            If Ppropertylist.Rows.Count < 8 Then
                Ppropertylist.Merge(Createdatabalegvsearch(7 - Ppropertylist.Rows.Count))
                gvsearchProperty.DataSource = Ppropertylist
                gvsearchProperty.DataBind()
            Else
                gvsearchProperty.DataSource = Ppropertylist
                gvsearchProperty.DataBind()
            End If

            LoadwithOutProperty()
        End If

    End Sub

    Protected Sub btnsavedoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        objMREHdr.MRE_Date = txtDateReceivedFrom.Text
        objMREHdr.MRE_Date_Recieve = txtDateReceivedBy.Text
        objMREHdr.RC_ID = grListOfProperty.SelectedDataKey("rc_id")
        objMREHdr.Func_ID = grListOfProperty.SelectedDataKey("function_id")
        objMREHdr.Received_from = ddFromProperty.SelectedValue.ToString
        objMREHdr.MRto = ddByAcknowledgement.SelectedValue.ToString
        objMREHdr.Cancelled = False
        objMREHdr.MRENumber = txtMRE.Text

        Dim HDR As Long = objMREHdr.saveMREHdr()
        objMREDtl.MREHdr_ID = HDR
        Session("Property_id") = HDR
        objMREDtl.PropertyNo = grListOfProperty.SelectedDataKey("PropertyNo")

        Dim MREDtlID As Long = objMREDtl.saveMREDtl()
        objMREReturn.MRE_Dtl = MREDtlID
        objMREReturn.PropertyNo = grListOfProperty.SelectedDataKey("PropertyNo")
        objMREReturn.MRE_Date = txtDateReceivedBy.Text
        objMREReturn.Status = "On Hand"
        objMREReturn.Remarks = "Issued"
        objMREReturn.Dispose = False
        objMREReturn.Repair = False
        objMREReturn.Inspection = False
        objMREReturn.deptid = grListOfProperty.SelectedDataKey("rc_id")
        objMREReturn.saveMREReturn()

        Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text))
        Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text))
        Dim Property_ID As Integer = Val(objDerived.GetValue("exec AMS.getProperty_ID '" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text))
        objDerived.GetRecords("Update AMS.Property set Balance='" & balance - 1 & "',Issuance='" & issuance + 1 & "' where  Property_ID='" & Property_ID & "'", CommandType.Text)
        objDerived.GetRecords("UPDATE AMS.Property_Dtl SET   Issued ='True' WHERE PropertyNo='" & grListOfProperty.SelectedDataKey("PropertyNo").ToString & "'", CommandType.Text)

        btnsave.Enabled = False
        btnADD.Enabled = False
        btnpreview.Enabled = True
        ddmr.Enabled = False

        '==== Update Ledger ====
        dtPropLedger = objLedger.GetDataTable("Select Ledger_ID from AMS.TbProperty_Ledger", CommandType.Text)
        With objLedger
            '.Ledger_ID = Ledger_ID
            .PropertyNo = grListOfProperty.SelectedDataKey("PropertyNo")
            .SerialNo = grListOfProperty.SelectedDataKey("SerialNo")
            .dDate = txtDateReceivedFrom.Text
            .Trans_Type = "Issuance"
            .Ref = txtMRE.Text
            .AccountablePerson = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory where empid ='" & ddByAcknowledgement.SelectedValue & "'", CommandType.Text)
            .Department = ddByDepartment.SelectedValue.ToString
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

            .Item_ID = grListOfProperty.SelectedDataKey("Item_ID")

            .CreditQty = 1
            .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            .CreditCost = CType(grListOfProperty.SelectedDataKey("Cost"), Decimal)

            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM  AMS.m_Unit INNER JOIN  dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID INNER JOIN AMS.Property ON dbo.m_item.Item_ID = AMS.Property.Item_ID where AMS.Property.Item_ID ='" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            Dim eQty As Integer
            Dim eBalance As Decimal
            Dim dtledger As New DataTable

            dtledger = objDerived.GetDataTable("Select * from AMS.TbProperty_Ledger where Item_ID = '" & grListOfProperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dtledger.Rows.Count = 0 Then
                eQty = 0
                eBalance = 0.0
            Else
                eQty = objDerived.GetValue("Select BalanceQty from AMS.TbProperty_Ledger where Item_ID = '" & grListOfProperty.SelectedDataKey("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
                eBalance = objDerived.GetValue("Select BalanceCost from AMS.TbProperty_Ledger where Item_ID = '" & grListOfProperty.SelectedDataKey("Item_ID") & "' ORDER BY Ledger_ID DESC", CommandType.Text)
            End If

            .BalanceQty = eQty - 1
            .BalanceCost = CType(eBalance, Decimal) - CType(grListOfProperty.SelectedDataKey("Cost"), Decimal)
        End With

        objLedger.Ledger_ID = 0
        objLedger.save()



        'Ppropertylist = Me.objDerived.GetDataTable("Exec [AMS].[InventoryPropertyList_v3] '""'", CommandType.Text)
        'If Ppropertylist.Rows.Count < 8 Then
        '    Ppropertylist.Merge(Createdatabalegvsearch(7 - Ppropertylist.Rows.Count))
        '    gvsearchProperty.DataSource = Ppropertylist
        '    gvsearchProperty.DataBind()
        'Else
        '    gvsearchProperty.DataSource = Ppropertylist
        '    gvsearchProperty.DataBind()
        'End If

        LoadPropertyDropDown()
        LoadwithOutProperty()

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been succesfully saved.")
    End Sub
    Protected Sub btncancelDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/etc/body.aspx")
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
    End Sub
    Protected Sub btnpreviewAreDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_rpt_acknowledgement_receipt.aspx")
    End Sub
    Protected Sub btnAddDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfinspection.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()
        If Me.hdfinspection.Value <> "" Then
            'image.Issuance_ID = Issuance_ID
            image.DocuID = grListOfProperty.SelectedDataKey("PropertyDetai_ID")
            image.Item_ID = grListOfProperty.SelectedDataKey("Item_ID")
            image.Property_ID = grListOfProperty.SelectedDataKey("Property_ID")
            image.ImageFile = bytes
            image.DocumentName = txtdocname.Text
            image.PropertyNo = txtPropertyNo.Text
            image.ValidatedBy = txtValidatedBy.Text
            If txtDatevalidated.Text = "" Then
                image.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                image.DateValidated = txtDatevalidated.Text
            End If
            image.TableName = "Issuance"

            Dim Id As Long = image.SaveImage()
            imgDocPreview.ImageUrl = "~/Handler/ShowImage.ashx?id=" & Id
        End If

        'btnADD.Enabled = False
        'Dim DocumentDta As New DataTable
        'Try
        '    DocumentDta = objDerived.GetDataTable("Select DocumentName,PropertyName,ValidateBy,convert(varchar(20),DateValidated,101) as DateValidated,convert(int , BuildingDocumentID) as BuildingDocumentID from BPAS.BuildingDocument where BldgID=" & Session("itemId") & "  ", CommandType.Text)
        'Catch ex As Exception
        'End Try
        'If DocumentDta.Rows.Count < 4 Then
        '    DocumentDta.Merge(CreatedatatableScannedDoc(4))
        '    gvDocumentAdded.DataSource = DocumentDta
        '    gvDocumentAdded.DataBind()
        'Else
        '    gvDocumentAdded.DataSource = DocumentDta
        '    gvDocumentAdded.DataBind()
        'End If
        LoadAttchDocu()
    End Sub
    Protected Sub btndoccancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
    End Sub
    Protected Sub LoadAttchDocu()
        Dim dtAttchDoc As New DataTable
        dtAttchDoc = objDerived.GetDataTable("Select * from AMS.TbIssuanceAttch where DocuID = '" & grListOfProperty.SelectedDataKey("PropertyDetai_ID") & "' and TableName = 'Issuance'", CommandType.Text)
        Dim rows As New Integer
        rows = dtAttchDoc.Rows.Count
        dtAttchDoc.Merge(CreatedatatableScannedDoc(4 - rows))
        gvDocumentAdded.DataSource = dtAttchDoc
        gvDocumentAdded.DataBind()
        gvDocumentAdded.SelectedIndex = 0
        LoadAttchSelectedIndex()
    End Sub
    Protected Sub LoadNoAttchment()
        gvDocumentAdded.DataSource = CreatedatatableScannedDoc(4)
        gvDocumentAdded.DataBind()

        imgDocPreview.ImageUrl = "~/images/Blankimage.jpg"
    End Sub
    Protected Sub gvDocumentAdded_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadAttchSelectedIndex()
    End Sub
    Protected Sub LoadAttchSelectedIndex()
        Try
            Dim id As New Integer
            id = gvDocumentAdded.SelectedDataKey("DocuID").ToString
            imgDocPreview.ImageUrl = "~/Handler/ShowIssuanceAttchment.ashx?id=" & id
        Catch ex As Exception
            imgDocPreview.ImageUrl = "~/images/Blankimage.jpg"
        End Try
    End Sub
    Protected Sub gvDocumentAdded_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvDocumentAdded, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub


    'RIS
    Protected Sub drpdept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpdept.SelectedIndexChanged
        Try
            drpdept.Enabled = False
            drpFunction.Items.Clear()
            pFunction = Nothing

            drpFunction.DataSource = pFunction
            drpFunction.DataBind()
            pFunction = objDerived.GetDataTable("exec ams.m_function " & drpdept.SelectedItem.Value & "", CommandType.Text)
            drpFunction.DataSource = pFunction
            drpFunction.DataTextField = ("Function_Desc")
            drpFunction.DataValueField = ("Function_ID")
            drpFunction.Items.Add("Select")
            drpFunction.DataBind()
            drpFunction.Enabled = True

            'ddmr.Enabled = True
            'pemployee = Nothing
            'ddmr.DataSource = pemployee
            'ddmr.DataBind()
            'pemployee = objDerived.GetDataTable("exec [AMS].[loadEmployee] " & Me.drpFunction.SelectedItem.Value & "," & drpdept.SelectedItem.Value & "", CommandType.Text)
            'ddmr.DataSource = pemployee
            'ddmr.DataTextField = ("fullname")
            'ddmr.DataValueField = ("id")
            'ddmr.DataBind()

            'loadopenReq()

            'pItems = objDerived.GetDataTable("exec ams.LoadStocklist " & Me.drpdept.SelectedItem.Value & ",'" & Date.Today.ToString("MM/dd/yyyy") & "'," & Me.drpFunction.SelectedItem.Value & "", CommandType.Text)
            'gvitems.Columns(3).Visible = True
            'gvitems.Columns(4).Visible = True
            'gvitems.DataSource = pItems
            'gvitems.DataBind()
            'gvitems.Columns(3).Visible = False
            'gvitems.Columns(4).Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub drpFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpFunction.SelectedIndexChanged
        Try
            drpFunction.Enabled = False

            pemployee = Nothing
            ddmr.DataSource = pemployee
            ddmr.DataBind()
            'pemployee = objDerived.GetDataTable("exec [AMS].[loadEmployee] " & Me.drpFunction.SelectedItem.Value & "," & drpdept.SelectedItem.Value & "", CommandType.Text)
            'ddmr.DataSource = pemployee
            'ddmr.DataTextField = ("fullname")
            'ddmr.DataValueField = ("id")
            'ddmr.DataBind()
            'ddmr.Enabled = True

            pemployee = objDerived.GetDataTable("Select * From dbo.view_signatory1 where division_key = '" & Me.drpFunction.SelectedItem.Value & "' and deptid ='" & drpdept.SelectedItem.Value & "'", CommandType.Text)
            ddmr.DataSource = pemployee
            ddmr.DataTextField = ("full_name")
            ddmr.DataValueField = ("empid")
            ddmr.DataBind()
            ddmr.Enabled = True

            pItems = objDerived.GetDataTable("exec ams.LoadStocklist '" & Me.drpdept.SelectedItem.Value & "','" & Me.drpFunction.SelectedItem.Value & "'", CommandType.Text)
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.DataSource = pItems
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            btnADD.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddmr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddmr.SelectedIndexChanged
        ddmr.Enabled = False

        loadopenReq()
        btnADD.Enabled = True
    End Sub
    Public Sub loadopenReq()

        popen = objDerived.GetDataTable("exec [AMS].[sp_requisitionIssuance_olddata] " & Me.ddmr.SelectedItem.Value & "," & Me.drpdept.SelectedItem.Value & ", " & Me.drpFunction.SelectedItem.Value & "", CommandType.Text)
        gvopen.DataSource = CType(popen, DataTable)
        gvopen.DataBind()
        'Acknowledgement
        'Public Sub loadopenAck()
        '    popen = objDerived.GetDataTable("exec [AMS].[sp_acknowledgement_olddata]" & Me.ddmr.SelectedItem.Value & ", " & Me.drpdept.SelectedItem.Value & ", " & Me.drpFunction.SelectedItem.Value & "", CommandType.Text)
        '    gvopenmre.DataSource = CType(popen, DataTable)
        '    gvopenmre.DataBind()
        'End Sub
        'Requsistion
    End Sub

    Protected Sub btnSearch_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            Me.gvitems.DataSource = objDerived.Search(pItems, "Item_Desc", txtsearchitems.Text)
            Me.gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            ' gridEnable()
            gvitems.SelectedIndex = -1
            gvitems.PageIndex = 0

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

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
        btnADD.Enabled = True
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvitems.PageIndexChanging
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.PageIndex = e.NewPageIndex
        gvitems.DataSource = CType(pItems, DataTable)
        gvitems.DataBind()
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.SelectedIndex = -1

    End Sub
    Protected Sub btnload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnload.Click
        Try
            'btnsave.Enabled = True
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim cb As CheckBox
            dt.Columns.Add("Item_Desc", GetType(String))
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("Item_ID")
            dt.Columns.Add("qty", GetType(Integer))
            dt.Columns.Add("qty2", GetType(Integer))
            dt.Columns.Add("cost", GetType(Decimal))
            dt.Columns.Add("total", GetType(Decimal))
            dt.Columns.Add("stockID")
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    Dim dta As DataTable
                    dta = pItems
                    If pbody Is Nothing Then
                        dr = dt.NewRow()
                        dr("Item_Desc") = gvitems.Rows(i).Cells(1).Text.Trim
                        dr("Description") = gvitems.Rows(i).Cells(2).Text
                        dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
                        dr("qty") = pItems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("balance")
                        dr("qty2") = 0
                        dr("cost") = gvitems.Rows(i).Cells(5).Text
                        dr("total") = "0.00"
                        dr("stockID") = gvitems.Rows(i).Cells(7).Text
                        dt.Rows.Add(dr)
                        pbody = dt
                    Else
                        dt = pbody
                        dr = dt.NewRow()
                        dr("Item_Desc") = gvitems.Rows(i).Cells(1).Text.Trim
                        dr("Description") = gvitems.Rows(i).Cells(2).Text
                        dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
                        dr("qty") = pItems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("balance")
                        dr("qty2") = 0
                        dr("cost") = gvitems.Rows(i).Cells(5).Text
                        dr("total") = "0.00"
                        dr("stockID") = gvitems.Rows(i).Cells(7).Text
                        dt.Rows.Add(dr)
                        pbody = dt
                    End If
                End If
            Next

            Dim data As DataTable
            data = pItems
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    data.Rows(Me.gvitems.Rows(i).Cells(4).Text).Delete()
                End If
            Next

            pItems = data

            gvitems.DataSource = pItems
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False

            gvbody.DataSource = pbody
            gvbody.DataBind()
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Dim qty As TextBox = CType(Me.gvbody.Rows(i).FindControl("txtQty"), TextBox)
                qty.Attributes.Add("onFocus", "this.select()")
                qty.Attributes.Add("onClick", "this.select()")
                If i = 0 Then
                    qty.Focus()
                End If
            Next
            If pbody.Compute("sum(total)", "") = 0 Then
                gvbody.FooterRow.Cells(5).Text = "0.00"
            Else
                gvbody.FooterRow.Cells(5).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
            End If

        Catch ex As Exception
            'btnsave.Enabled = False
        End Try
        btnADD.Enabled = False
        btnsave.Enabled = True
    End Sub




    Public Sub gridEnable()
        Dim cb, cbheader As CheckBox
        Dim itemid As String
        Dim txt As Integer
        Dim gv As New GridView
        gv.DataSource = pbody
        gv.DataBind()
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        Dim countE As Integer = 0
        For i As Integer = 0 To Me.gvitems.Rows.Count - 1

            itemid = Me.gvitems.Rows(i).Cells(3).Text
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            For o As Integer = 0 To gv.Rows.Count - 1
                txt = CType(gv.Rows(o).Cells(2).Text, Integer)

                If txt = CType(itemid.ToString, Integer) Then
                    cb.Checked = False
                    cb.Enabled = False
                    countE = countE + 1
                End If
            Next
        Next

        If countE = 10 Then
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Checked = False
        Else
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Checked = True
        End If
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False

        btnADD.Enabled = True
    End Sub
    Protected Sub txtqty_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim total As Decimal
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If

            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            Dim data As DataTable = pbody
            If CType(gvbody.Rows(gvr.RowIndex).Cells(3).Text, Integer) >= CType(txtqty.Text, Integer) Then
                pbody.Rows(gvr.RowIndex)("qty2") = txtqty.Text
                'pbody.Rows(gvr.RowIndex)("total") = CType(objDerived.GetValue("exec ams.GetCalcMAB " & pbody.Rows(gvr.RowIndex)("StockID") & "," & pbody.Rows(gvr.RowIndex)("qty") & "," & CType(txtqty.Text, Integer) & "", CommandType.Text), Decimal)
                pbody.Rows(gvr.RowIndex)("total") = gvbody.Rows(gvr.RowIndex).Cells(4).Text * txtqty.Text
                gvbody.Rows(gvr.RowIndex).Cells(5).Text = FormatNumber(pbody.Rows(gvr.RowIndex)("total"), 2)
                gvbody.FooterRow.Cells(5).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
                Dim qty As TextBox = CType(Me.gvbody.Rows(gvr.RowIndex + 1).FindControl("txtQty"), TextBox)
                If qty.Text = "0" Then
                    qty.Text = ""
                End If
                qty.Attributes.Add("onFocus", "this.select()")
                qty.Attributes.Add("onClick", "this.select()")
                qty.Focus()

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Quantity must not exceed to the available quantity.")
                txtqty.Text = 0
                pbody.Rows(gvr.RowIndex)("total") = txtqty.Text * CType(pbody.Rows(gvr.RowIndex)("cost"), Decimal)
                gvbody.Rows(gvr.RowIndex).Cells(5).Text = FormatNumber(txtqty.Text * CType(pbody.Rows(gvr.RowIndex)("cost"), Decimal), 2)
                gvbody.FooterRow.Cells(5).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
                txtqty.Attributes.Add("onFocus", "this.select()")
                txtqty.Attributes.Add("onClick", "this.select()")
                txtqty.Focus()
            End If

        Catch ex As Exception

        End Try
        btnADD.Enabled = False
    End Sub
    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click
        pItems = objDerived.GetDataTable("exec ams.LoadStocklist " & Me.drpdept.SelectedItem.Value & ",'" & Date.Today.ToString("MM/dd/yyyy") & "'," & Me.drpFunction.SelectedItem.Value & "", CommandType.Text)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.DataSource = pItems
        gvitems.DataBind()
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        btnADD.Enabled = True
        btnpreview.Enabled = False
        btnsave.Enabled = False
        Dim obj1 As Object
        obj1 = True

        ddmr.DataSource = objDerived.Search(pemployee, "Status", obj1)
        ddmr.DataTextField = ("Fullname")
        ddmr.DataValueField = ("id")
        ddmr.DataBind()
        ddmr.SelectedIndex = 0
        ddmr.Enabled = True
        txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
        txtRIS.Text = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtdate.Text & "')", CommandType.Text)
        txtremarks.ReadOnly = False
        pbody = Nothing
        gvbody.DataSource = pbody
        gvbody.DataBind()
        txtremarks.Text = ""
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If pbody.Compute("sum(qty2)", "") = 0 Then
                'msg.UserMsgBox("Atleast one supply must have a quantity", Me, False)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Atleast one supply must have a quantity.")

            Else
                Me.Session("ris_no") = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtdate.Text & "')", CommandType.Text)
                txtRIS.Text = Me.Session("ris_no")
                hdr.RIS_No = Me.Session("ris_no")
                hdr.RISDate = txtdate.Text
                hdr.RC_ID = Me.drpdept.SelectedItem.Value
                hdr.Func_ID = Me.drpFunction.SelectedItem.Value
                hdr.Purpose = txtremarks.Text
                hdr.Issued_By = txtfrom.Text
                If ddmr.SelectedValue = "Select" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Select acknowledge to signatory.")
                    Exit Sub
                Else
                    hdr.Received_By = ddmr.SelectedItem.Value 'objDerived.GetValue("SELECT empID FROM dbo.view_EmployeeSignatories WHERE dept_id = " & Me.drpdept.SelectedItem.Value & " AND func_id = " & drpFunction.SelectedItem.Value, CommandType.Text) 'Department Head's EmpID''ddmr.SelectedValue.Trim
                End If

                hdr.withICS = False
                Dim hdrid As Long = hdr.saveRISHdr()

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    If pbody.Rows(i)("qty2") <> "0" Then
                        'Dim NewMAB As Decimal = CType(mab.Rows(0)("mab"), Decimal) - CType(pbody.Rows(i)("total"), Decimal)
                        'Dim data As DataTable = objDerived.GetDataTable("exec AMS.updatestock '" & pbody.Rows(i)("item_id") & "'," & Me.drpdept.SelectedItem.Value & "," & Me.drpFunction.SelectedItem.Value & ",'" & pbody.Rows(i)("qty2") & "'", CommandType.Text)

                        Dim mab As DataTable = objDerived.GetDataTable("SELECT mab  FROM AMS.Stock WHERE stockID ='" & pbody.Rows(i)("StockID") & "'", CommandType.Text)
                        Dim NewMAB As Decimal = CType(mab.Rows(0)("mab"), Decimal) + CType(pbody.Rows(i)("total"), Decimal)

                        dtl.RISHdr_ID = hdrid
                        dtl.Item_ID = pbody.Rows(i)("item_id")
                        dtl.AvailableQty = pbody.Rows(i)("qty")
                        dtl.ApprovedQty = pbody.Rows(i)("qty2")
                        dtl.Cost = pbody.Rows(i)("total")
                        dtl.StockID = pbody.Rows(i)("StockID")

                        dtl.saveRISDtl()

                        Dim balance As Integer = objDerived.GetValue("Select Balance from AMS.Stock where stockID ='" & pbody.Rows(i)("StockID") & "'", CommandType.Text)
                        Dim issuance As Integer = objDerived.GetValue("Select Issuance from AMS.Stock where stockID ='" & pbody.Rows(i)("StockID") & "'", CommandType.Text)

                        objDerived.GetRecords("update ams.stock set mab='" & NewMAB & "',Balance='" & balance - pbody.Rows(i)("qty2") & "',Issuance='" & issuance + pbody.Rows(i)("qty2") & "' where stockID =" & pbody.Rows(i)("StockID") & "", CommandType.Text)
                        'objDerived.GetRecords("update ams.stock set mab='" & NewMAB & "' where stockID =" & pbody.Rows(i)("StockID") & "", CommandType.Text)


                        '==== SAVE Stock Ledger ====
                        dtStockLedger = objStockLedger.GetDataTable("Select StockLedger_ID from AMS.TbStock_Ledger", CommandType.Text)
                        With objStockLedger
                            '.StockLedger_ID = StockLedger_ID
                            .StockID = "0" 'objDerived.GetValue("Select StockID FROM AMS.Stock where Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)
                            .Trans_Type = "Issuance"
                            .Ref = txtRIS.Text
                            .AccountablePerson = ddmr.SelectedItem.Text 'objDerived.GetValue("SELECT fullname FROM AMS.employee where id = '" & ddmr.SelectedItem.Text & "'", CommandType.Text) 'ddmr.SelectedItem.Text
                            .Department = drpdept.SelectedItem.Text
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

                            .dDate = txtdate.Text
                            .Item_ID = pbody.Rows(i)("item_id")

                            .CreditQty = pbody.Rows(i)("qty2")
                            .CreditCost = pbody.Rows(i)("total")
                            .CreditUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)

                            .BalanceUnit = objDerived.GetValue("SELECT AMS.m_Unit.Description FROM AMS.m_Unit INNER JOIN dbo.m_item ON AMS.m_Unit.Unit_ID = dbo.m_item.Unit_ID WHERE dbo.m_item.Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)

                            Dim SuppQty As Integer
                            Dim SuppBalance As Decimal
                            Dim dtledger As New DataTable

                            dtledger = objDerived.GetDataTable("Select * from AMS.TbStock_Ledger where Item_ID = '" & pbody.Rows(i)("item_id") & "'", CommandType.Text)
                            If dtledger.Rows.Count = 0 Then
                                SuppQty = 0
                                SuppBalance = 0.0
                            Else
                                SuppQty = objDerived.GetValue("Select BalanceQty from AMS.TbStock_Ledger where Item_ID = '" & pbody.Rows(i)("item_id") & "'  ORDER BY StockLedger_ID desc", CommandType.Text)
                                SuppBalance = objDerived.GetValue("Select BalanceCost from AMS.TbStock_Ledger where Item_ID = '" & pbody.Rows(i)("item_id") & "'  ORDER BY StockLedger_ID desc", CommandType.Text)
                            End If

                            .BalanceQty = SuppQty - CType(pbody.Rows(i)("qty2"), Integer)
                            .BalanceCost = CType(SuppBalance, Decimal) - CType(pbody.Rows(i)("total"), Decimal)
                        End With
                        objStockLedger.StockLedger_ID = 0
                        objStockLedger.save()

                    End If
                Next

                gvbody.DataSource = objDerived.GetRecords("exec AMS.loadRISdetail '" & Me.Session("ris_no") & "','" & drpdept.SelectedItem.Value & "','" & drpFunction.SelectedItem.Value & "'", CommandType.Text)
                gvbody.DataBind()


                For i As Integer = 0 To gvbody.Rows.Count - 1
                    CType(gvbody.Rows(i).Cells(2).FindControl("txtqty"), TextBox).ReadOnly = True
                Next

                btnpreview.Enabled = True
                btnsave.Enabled = False
                btnADD.Enabled = False
                ddmr.Enabled = False
                txtremarks.ReadOnly = True

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Transaction has been successfully saved.")

                Me.drpdept.Enabled = False
                Me.drpFunction.Enabled = False

                loadopenReq()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnsearch2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim obj As Object
            If ddopen.SelectedItem.Value = "RISDATE" Then

                obj = CType(txtsearch2.Text, Date)
            Else
                obj = txtsearch2.Text
            End If
            Me.gvopen.DataSource = objDerived.Search(popen, ddopen.SelectedItem.Value, obj)
            Me.gvopen.DataBind()
            gvopen.SelectedIndex = -1
            gvopen.PageIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gvopen_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvopen.PageIndexChanging

        gvopen.PageIndex = e.NewPageIndex
        gvopen.DataSource = CType(popen, DataTable)
        gvopen.DataBind()
        gvopen.SelectedIndex = -1

    End Sub
    Protected Sub DropDownList11_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub btnload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnload2.Click
        Try
            Me.Session("ris_no") = Me.gvopen.SelectedDataKey(0)
            btnpreview.Enabled = True
            btnsave.Enabled = False
            btnADD.Enabled = False
            btnnew.Enabled = True
            btnopen.Enabled = True
            pbody = objDerived.GetDataTable("exec AMS.loadRISdetail '" & Me.Session("ris_no") & "'", CommandType.Text)
            gvbody.DataSource = pbody
            gvbody.DataBind()

            txtdate.Text = gvopen.SelectedDataKey(1)
            txtRIS.Text = gvopen.SelectedDataKey(0)
            txtremarks.Text = gvopen.SelectedDataKey(6)

            ddmr.DataSource = pemployee
            ddmr.DataTextField = ("Fullname")
            ddmr.DataValueField = ("id")
            ddmr.DataBind()
            ddmr.SelectedIndex = 0


            ddmr.Enabled = False

            ddmr.SelectedItem.Text = gvopen.SelectedDataKey(2)
            txtfrom.Text = gvopen.SelectedDataKey(5)
            txtremarks.ReadOnly = True


            If pbody.Compute("sum(total)", "") = 0 Then
                gvbody.FooterRow.Cells(5).Text = "0.00"
            Else
                gvbody.FooterRow.Cells(5).Text = FormatNumber(pbody.Compute("sum(total)", ""), 2)
            End If


            For i As Integer = 0 To gvbody.Rows.Count - 1
                CType(gvbody.Rows(i).Cells(2).FindControl("txtqty"), TextBox).ReadOnly = True
            Next
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Me.Page.Response.Redirect("~/Inventory/t_rpt_requisition_and_issuance.aspx")
    End Sub
    Protected Sub txtsearchitems_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try


            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            Me.gvitems.DataSource = objDerived.Search(pItems, "Item_Desc", txtsearchitems.Text)
            Me.gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False

            gvitems.SelectedIndex = -1
            gvitems.PageIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtsearch2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim obj As Object
            If ddopen.SelectedItem.Value = "RISDATE" Then

                obj = CType(txtsearch2.Text, Date)
            Else
                obj = txtsearch2.Text
            End If
            Me.gvopen.DataSource = objDerived.Search(popen, ddopen.SelectedItem.Value, obj)
            Me.gvopen.DataBind()
            gvopen.SelectedIndex = -1
            gvopen.PageIndex = 1
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddFromDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub txtDateReceivedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Convert.ToDateTime(Me.txtDateReceivedFrom.Text) > Convert.ToDateTime(Me.txtDateReceivedBy.Text) Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel3, "Date Not be less than the Date Receive")


        'End If
    End Sub
    Protected Sub txtDateReceivedBy_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateReceivedBy.Unload

    End Sub
    Protected Sub btninspectionBrowse_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Public Function Createdatabalegvsearch(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Balance") = DBNull.Value
            dt.Rows.Add(dr)

        Next
        Return dt
    End Function
    Public Function CreatedatabalegrListOfProperty(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("fullname", GetType(String))
        dt.Columns.Add("DateIssued", GetType(Date))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("rc_id", GetType(Integer))
        dt.Columns.Add("function_id", GetType(Integer))
        dt.Columns.Add("MREHdr_ID", GetType(Integer))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("MREDtl_ID", GetType(Integer)) ''MRE_Hdr'
        dt.Columns.Add("MRE_Hdr", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("fullname") = DBNull.Value
            dr("DateIssued") = DBNull.Value
            dr("Status") = DBNull.Value
            dr("rc_id") = DBNull.Value
            dr("function_id") = DBNull.Value
            dr("MREHdr_ID") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("MREDtl_ID") = DBNull.Value
            dr("MRE_Hdr") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function CreatedatatableScannedDoc(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("DocumentName", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("ValidatedBy", GetType(String))
        dt.Columns.Add("DateValidated", GetType(Date))
        dt.Columns.Add("DocuID", GetType(Long))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("DocumentName") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("ValidatedBy") = DBNull.Value
            dr("DateValidated") = DBNull.Value
            dr("DocuID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreatedatatableSupply(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("total", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("id") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("total") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreatedatatableSupplist(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Long))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("Department") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Protected Sub btnReturnProperty_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub ddSupplies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddSupplies.SelectedIndexChanged
        drpdept.Enabled = True
        drpFunction.Enabled = True
        ddmr.Enabled = True

        drpdept.Items.Clear()
        pRC = Nothing
        drpdept.DataSource = pRC
        drpdept.Items.Add("Select")
        drpdept.DataBind()

        drpFunction.Items.Clear()
        pFunction = Nothing
        drpFunction.DataSource = pFunction
        drpFunction.Items.Add("Select")
        drpFunction.DataBind()

        ddmr.Items.Clear()
        pemployee = Nothing
        ddmr.DataSource = pemployee
        ddmr.Items.Add("Select")
        ddmr.DataBind()

        Dim GaId As Integer
        If ddSupplies.SelectedValue = 1 Then
            GaId = 792 ' Drugs and Medicine
        ElseIf ddSupplies.SelectedValue = 2 Then
            GaId = 793 ' Medical Supplies
        ElseIf ddSupplies.SelectedValue = 3 Then
            GaId = 791 'Food
        ElseIf ddSupplies.SelectedValue = 4 Then
            GaId = 799 ' Water
        ElseIf ddSupplies.SelectedValue = 5 Then
            GaId = 798 ' Blood
        ElseIf ddSupplies.SelectedValue = 6 Then
            GaId = 927 ' Non-Food
        ElseIf ddSupplies.SelectedValue = 7 Then
            GaId = 788 ' Office Supplies
        End If

        Dim dtsuppFilter As New DataTable
        dtsuppFilter = objDerived.GetDataTable("Select * From dbo.View_StockIssuance where GA_ID = '" & GaId & "'", CommandType.Text)
        If dtsuppFilter.Rows.Count = 0 Then
            gvSupplyList.DataSource = CreatedatatableSupplist(5)
            gvSupplyList.DataBind()
        Else
            If dtsuppFilter.Rows.Count < 5 Then
                dtsuppFilter.Merge(CreatedatatableSupplist(5 - dtsuppFilter.Rows.Count))
                gvSupplyList.DataSource = dtsuppFilter
                gvSupplyList.DataBind()
            Else
                gvSupplyList.DataSource = dtsuppFilter
                gvSupplyList.DataBind()

            End If
        End If
        gvSupplyList.Columns(4).Visible = False
    End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvitems_SelectedIndexChanged3(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvSupplyList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        drpdept.Enabled = True
        drpdept.Items.Clear()

        drpFunction.Items.Clear()
        pFunction = Nothing
        drpFunction.DataSource = pFunction
        drpFunction.Items.Add("Select")
        drpFunction.DataBind()

        ddmr.Items.Clear()
        pemployee = Nothing
        ddmr.DataSource = pemployee
        ddmr.Items.Add("Select")
        ddmr.DataBind()

        pRC = Nothing
        pRC = objDerived.GetDataTable("select * from dbo.View_RISSuppliesFilter where RC_ID = '" & gvSupplyList.SelectedDataKey("RC_ID") & "'", CommandType.Text)
        drpdept.DataSource = CType(pRC, DataTable)

        drpdept.DataTextField = ("RC_Name")
        drpdept.DataValueField = ("RC_ID")
        drpdept.Items.Add("Select")
        drpdept.DataBind()


    End Sub

    Protected Sub gvSupplyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvSupplyList, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub gvSupplyList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        drpdept.Enabled = True

        Dim GaId As Integer
        If ddSupplies.SelectedValue = 1 Then
            GaId = 792 ' Drugs and Medicine
        ElseIf ddSupplies.SelectedValue = 2 Then
            GaId = 793 ' Medical Supplies
        ElseIf ddSupplies.SelectedValue = 3 Then
            GaId = 791 'Food
        ElseIf ddSupplies.SelectedValue = 4 Then
            GaId = 799 ' Water
        ElseIf ddSupplies.SelectedValue = 5 Then
            GaId = 798 ' Blood
        ElseIf ddSupplies.SelectedValue = 6 Then
            GaId = 927 ' Non-Food
        ElseIf ddSupplies.SelectedValue = 7 Then
            GaId = 788 ' Office Supplies
        End If

        Dim dtsuppFilter As New DataTable
        dtsuppFilter = objDerived.GetDataTable("Select * From dbo.View_StockIssuance where GA_ID = '" & GaId & "'", CommandType.Text)
        If dtsuppFilter.Rows.Count < 5 Then
            dtsuppFilter.Merge(CreatedatatableSupplist(5 - dtsuppFilter.Rows.Count))
            gvSupplyList.PageIndex = e.NewPageIndex
            gvSupplyList.DataSource = dtsuppFilter
            gvSupplyList.DataBind()
        Else
            gvSupplyList.DataSource = dtsuppFilter
            gvSupplyList.DataBind()

        End If
        gvSupplyList.Columns(3).Visible = False
    End Sub

End Class
