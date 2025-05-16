Imports System.Data
Imports System.IO

Partial Class t_purchase_request_v2_RepQueries
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private obr_hdr As New t_purchase_request_obr_hdr
    Private obr_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement

    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim image As New Image
    Dim ImageDocument As New ImageDocument
    Dim dtRep As New DataTable

    Dim objRep_Dtl As New t_RepairAndMaintenance.TbRepair_Dtl
    Private getprofile As New ProfileCommon

#Region "property"

    Private pPRTable As DataTable
    Public Property PRTable() As DataTable
        Get
            Return pPRTable
        End Get
        Set(ByVal value As DataTable)
            pPRTable = value
        End Set
    End Property

    Private Property porgibody() As DataTable
        Get
            Return CType(Session("porgibody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("porgibody") = value
        End Set
    End Property

    Private Property rolename() As String
        Get
            Return CType(Session("rolename"), String)
        End Get
        Set(ByVal value As String)
            Session("rolename") = value
        End Set
    End Property
    Private Property datahdr() As DataTable
        Get
            Return CType(Session("datahdr"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("datahdr") = value
        End Set
    End Property
    Private Property pPRlist() As DataTable
        Get
            Return CType(Session("pPRlist"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPRlist") = value
        End Set
    End Property
    Private Property pBudgetInfo() As DataTable
        Get
            Return CType(Session("pBudgetInfo"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBudgetInfo") = value
        End Set
    End Property
    Private Property PAPS() As DataTable
        Get
            Return CType(Session("PAPS"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("PAPS") = value
        End Set
    End Property
    Private Property pRoleName() As DataTable
        Get
            Return CType(Session("pRoleName"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRoleName") = value
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

    Private Property pApprovedPR() As DataTable
        Get
            Return CType(Session("pApprovedPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pApprovedPR") = value
        End Set
    End Property
    Private Property pIncomingPR() As DataTable
        Get
            Return CType(Session("pIncomingPR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pIncomingPR") = value
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
    Private Property pOnloadData() As DataTable
        Get
            Return CType(Session("pOnloadData"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOnloadData") = value
        End Set
    End Property

    Private Property pitems() As DataTable
        Get
            Return CType(Session("pitems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pitems") = value
        End Set
    End Property

    Private Property p_GA_ID() As DataTable
        Get
            Return CType(Session("p_GA_ID"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_GA_ID") = value
        End Set
    End Property
    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property

    Private Property pRequestedby() As DataTable
        Get
            Return CType(Session("pRequestedby"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRequestedby") = value
        End Set

    End Property


    Private Property oGA_ID() As Integer
        Get
            Return CType(Session("oGA_ID"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("oGA_ID") = value
        End Set
    End Property

    Private Property oBGA_ID() As Integer
        Get
            Return CType(Session("oBGA_ID"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("oBGA_ID") = value
        End Set
    End Property

    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property

    'Private pBody1 As DataTable
    'Public Property pBody() As DataTable
    '    Get
    '        Return  pBody1
    '    End Get
    '    Set(ByVal value As DataTable)
    '         pBody1 = value
    '    End Set
    'End Property


#End Region
#Region "function"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("InputQty", GetType(Integer))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("total", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("ReadOnly", GetType(Boolean))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("GA_Code2", GetType(String))
        dt.Columns.Add("Project_title", GetType(String))
        dt.Columns.Add("PR_ItemSpecs", GetType(String))
        dt.Columns.Add("ppmp_dtl_id", GetType(Long))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("InputQty") = 0
            dr("qty") = 0
            dr("cost") = "0.00"
            dr("total") = "0.00"
            dr("Item_ID") = 0
            dr("isVisible") = False
            dr("ReadOnly") = True
            dr("GA_ID") = 0
            dr("BGA_ID") = 0
            dr("GA_Code2") = ""
            dr("Project_title") = ""
            dr("PR_ItemSpecs") = ""
            dr("ppmp_dtl_id") = 0
            dt.Rows.Add(dr)

        Next
        Return dt

    End Function


    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("rc_name")
        dt.Columns.Add("Function_Desc")
        dt.Columns.Add("Date_Submitted", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("pr_no")
        dt.Columns.Add("PR_Date", GetType(Date))
        dt.Columns.Add("status")
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("rc_name") = ""
            dr("Function_Desc") = ""
            dr("Date_Submitted") = CType("01/01/1900", Date)
            dr("isVisible") = False
            dr("pr_no") = ""
            dr("PR_Date") = CType("01/01/1900", Date)
            dr("status") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable8(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ga_code", GetType(String))
        dt.Columns.Add("Allotment", GetType(Decimal))
        dt.Columns.Add("Obligated", GetType(Decimal))
        dt.Columns.Add("ongoing", GetType(Decimal))
        dt.Columns.Add("PR_Amt", GetType(Decimal))
        dt.Columns.Add("Available_Budget", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ga_code") = DBNull.Value
            dr("Allotment") = DBNull.Value
            dr("Obligated") = DBNull.Value
            dr("ongoing") = DBNull.Value
            dr("PR_Amt") = DBNull.Value
            dr("Available_Budget") = DBNull.Value
            dt.Rows.Add(dr)

        Next
        Return dt

    End Function
    Public Function createdatatable9(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("DocuId", GetType(Long))
        dt.Columns.Add("IdentityNo", GetType(Long))
        dt.Columns.Add("documentname", GetType(String))
        dt.Columns.Add("documentno", GetType(String))
        dt.Columns.Add("validatedby", GetType(String))
        dt.Columns.Add("datevalidated", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("DocuId") = DBNull.Value
            dr("IdentityNo") = DBNull.Value
            dr("documentname") = DBNull.Value
            dr("documentno") = DBNull.Value
            dr("validatedby") = DBNull.Value
            dr("datevalidated") = DBNull.Value
            dr("remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable10(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prno", GetType(String))
        dt.Columns.Add("requestingdept", GetType(String))
        dt.Columns.Add("obrno", GetType(String))
        dt.Columns.Add("supplier", GetType(String))
        dt.Columns.Add("projectname", GetType(String))
        dt.Columns.Add("pono", GetType(String))
        dt.Columns.Add("podate", GetType(String))
        dt.Columns.Add("poamount", GetType(Decimal))
        dt.Columns.Add("dvno", GetType(String))
        dt.Columns.Add("checkno", GetType(String))
        dt.Columns.Add("amountpaid", GetType(Decimal))
        dt.Columns.Add("jevno", GetType(String))
        dt.Columns.Add("m_SpecialAccount_Dtl_ID", GetType(Long))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("ppmp_hdr_id", GetType(Integer))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prno") = DBNull.Value
            dr("requestingdept") = DBNull.Value
            dr("obrno") = DBNull.Value
            dr("supplier") = DBNull.Value
            dr("projectname") = DBNull.Value
            dr("pono") = DBNull.Value
            dr("podate") = DBNull.Value
            dr("poamount") = DBNull.Value
            dr("dvno") = DBNull.Value
            dr("checkno") = DBNull.Value
            dr("amountpaid") = DBNull.Value
            dr("jevno") = DBNull.Value
            dr("m_SpecialAccount_Dtl_ID") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("ppmp_hdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable11(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("typeofservice", GetType(String))
        dt.Columns.Add("plateno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("condition", GetType(String))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("typeofservice") = DBNull.Value
            dr("plateno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("condition") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable4A(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("serialno", GetType(String))
        dt.Columns.Add("datepurchased", GetType(String))
        dt.Columns.Add("acquisitioncost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        dt.Columns.Add("Condition", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        dt.Columns.Add("Barcode", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Type") = DBNull.Value
            dr("serialno") = DBNull.Value
            dr("datepurchased") = DBNull.Value
            dr("acquisitioncost") = DBNull.Value
            dr("MarketValue") = DBNull.Value
            dr("Condition") = DBNull.Value
            dr("Location") = DBNull.Value
            dr("status") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
            dr("Barcode") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable12(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        'prhdr_id,OBR_Hdr_ID,pr_no,Remarks,ABC,Date_Submitted
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("OBR_Hdr_ID", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("Date_Submitted", GetType(Date))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("isApproved", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("OBR_Hdr_ID") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("Date_Submitted") = DBNull.Value
            dr("isVisible") = False
            dr("isApproved") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function createdatatable1Repair(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("NatureRepair", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("NatureRepair") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableSupply(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("QtyPerBox", GetType(Long))
        dt.Columns.Add("totalpcs", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("serialno", GetType(String))
        dt.Columns.Add("PO_Date", GetType(Date))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("marketvalue", GetType(Decimal))
        dt.Columns.Add("location", GetType(String))
        dt.Columns.Add("status", GetType(String))
        dt.Columns.Add("RespCenter", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("price", GetType(Decimal))
        dt.Columns.Add("item_id", GetType(Long))
        dt.Columns.Add("PODtl_ID", GetType(Long))
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("DatePurchased", GetType(Date))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("QtyPerBox") = DBNull.Value
            dr("totalpcs") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("serialno") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("AcquisitionCost") = DBNull.Value
            dr("marketvalue") = DBNull.Value
            dr("location") = DBNull.Value
            dr("status") = DBNull.Value
            dr("RespCenter") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("price") = DBNull.Value
            dr("item_id") = DBNull.Value
            dr("PODtl_ID") = DBNull.Value
            dr("Supplier_Id") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("DatePurchased") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("batch", GetType(String))
        dt.Columns.Add("lot", GetType(String))
        dt.Columns.Add("qty", GetType(Integer))
        dt.Columns.Add("qtybox", GetType(String))
        dt.Columns.Add("TotalPcs", GetType(Long))
        dt.Columns.Add("actualprice", GetType(Decimal))
        dt.Columns.Add("deliverydate", GetType(String))
        dt.Columns.Add("epirydate", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PO_No") = DBNull.Value
            dr("batch") = DBNull.Value
            dr("lot") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("qtybox") = DBNull.Value
            dr("TotalPcs") = DBNull.Value
            dr("actualprice") = DBNull.Value
            dr("deliverydate") = DBNull.Value
            dr("epirydate") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function CreateTable_Attachment(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Attch_ID", GetType(Long))
        dt.Columns.Add("ID", GetType(Long))
        dt.Columns.Add("DocumentName", GetType(String))
        dt.Columns.Add("AttachedFilename", GetType(String))
        dt.Columns.Add("DocumentNo", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Attch_ID") = DBNull.Value
            dr("ID") = DBNull.Value
            dr("DocumentName") = DBNull.Value
            dr("AttachedFilename") = DBNull.Value
            dr("DocumentNo") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                obj.GetAccessRight(Me.Session("@UserName"), Page)
                Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
                Dim role() As String = Roles.GetRolesForUser(usr.UserName)
                Dim rolename As String = role(0)

                rbTrustFund.SelectedItem.Value = 1

                gvBudgetInfo2.DataSource = Nothing
                gvBudgetInfo2.DataBind()

                grdocumentdetails.DataSource = createdatatable9(4)
                grdocumentdetails.DataBind()

                Dim Month1 As Integer
                Month1 = Month(Date.Today.ToString("MM/dd/yyyy"))
                txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")
                txtprdate.Enabled = True

                If Month1 >= 1 And Month1 <= 3 Then
                    objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
                    objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=1", CommandType.Text)
                ElseIf Month1 >= 4 And Month1 <= 6 Then
                    objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
                    objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=2", CommandType.Text)
                ElseIf Month1 >= 7 And Month1 <= 9 Then
                    objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
                    objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=3", CommandType.Text)
                ElseIf Month1 >= 10 And Month1 <= 12 Then
                    objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
                    objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=4", CommandType.Text)

                End If

                lbmeals.Enabled = False
                Session("RoleName") = rolename
                pRoleName = objDerived.GetDataTable("EXEC [dbo].[sp_GetRC_ByRole_systemManager] '" & rolename & "'", CommandType.Text)
                pRC = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
                ddRC.DataSource = CType(pRC, DataTable)
                ddRC.DataTextField = ("rc_name")
                ddRC.DataValueField = ("rc_id")
                ddRC.DataBind()

                btnAddlist.Enabled = False
                pBody = Nothing
                gvbody.Columns(0).Visible = False

                gvbody.DataSource = Nothing
                gvbody.DataBind()

                gvListPR.DataSource = createdatatable12(4)
                gvListPR.DataBind()

                rbTrustFund.SelectedItem.Value = 1
                RadioButtonList1.SelectedIndex = 0

                ddRC.Enabled = True
                lblreq1.Visible = False
                lblreq2.Visible = False
                Session("Edit") = 0
                btnpreview.Enabled = False

                grdDocuments.DataSource = CreateTable_Attachment(4)
                grdDocuments.DataBind()

            End If

            SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & Button5.ClientID & "')")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "You dont have a PPMP. Please create your pppmp first before preparing Purchase Request.")
        End Try

    End Sub
    Protected Sub txtprdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprdate.TextChanged

        Dim Month As Integer
        Month = CDate(txtprdate.Text).Month

        If Month >= 1 And Month <= 3 Then
            objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
            objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=1", CommandType.Text)

        ElseIf Month >= 4 And Month <= 6 Then
            objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
            objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=2", CommandType.Text)
        ElseIf Month >= 7 And Month <= 9 Then
            objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
            objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=3", CommandType.Text)
        ElseIf Month >= 10 And Month <= 12 Then
            objDerived.GetDataTable("Update ams.quarter set isUsed=0 ", CommandType.Text)
            objDerived.GetDataTable("Update ams.quarter set isUsed=1 where quarter_id=4", CommandType.Text)

        End If
    End Sub
    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.RadioButtonList3.SelectedIndex = 0 Then
        Else
            Me.Page.Response.Redirect("~/procurement/t_purchase_request_PRTable.aspx")
        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        ddRC.Enabled = True
    End Sub
    Protected Sub rbTrustFund_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbTrustFund.SelectedItem.Value = 3 Then
            Me.Page.Response.Redirect("~/procurement/t_purchased_request_trustfund.aspx")
        End If
    End Sub
    Protected Sub ddRC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRC.SelectedIndexChanged
        Try
            ddFunction.Items.Clear()
            If ddRC.SelectedItem.Text = "Select" Then
                pFunction = Nothing
                ddFunction.DataSource = pFunction
                ddFunction.DataBind()
                ddFunction.Items.Add("Select")

            Else
                pFunction = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & ddRC.SelectedItem.Value & "'", CommandType.Text)
                ddFunction.Items.Add("Select")
                ddFunction.DataSource = pFunction
                ddFunction.DataTextField = ("Function_Desc")
                ddFunction.DataValueField = ("Function_ID")
                ddFunction.DataBind()

                ddFunction.Enabled = True

            End If

            PAPS = Nothing
            ddPAPS.DataSource = PAPS
            ddPAPS.DataBind()
            ddPAPS.Items.Add("Select")
            ddPAPS.SelectedIndex = -1
            ddnature.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFunction.SelectedIndexChanged
        Dim app As Integer
        app = objDerived.GetValue("Select Status from AMS.APP where year = '" & Year(CDate(txtprdate.Text)) & "'", CommandType.Text)
        If app = 1 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Execute your APP first.")
        Else

            Dim dtDeptHead As New DataTable
            dtDeptHead = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_Key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            If dtDeptHead.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Assign department head first. Contact GSD personnel.")
                Exit Sub
            End If

            '=== ADDED 04182016, REQUESTED BY PER DEPARTMENT
            pRequestedby = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            ddRequestedBy.DataSource = pRequestedby
            ddRequestedBy.DataTextField = ("full_name")
            ddRequestedBy.DataValueField = ("empid")
            ddRequestedBy.DataBind()
            ddRequestedBy.Items.Insert(0, "Select")

            ddRequestedBy.Enabled = True

            '--- REQUESTED: REMOVE CHECKED BY AND NOTED BY 12-27-2019 ---
            'ddCheckedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id, isActive FROM AMS.BAC_Members WHERE isActive = 1 ORDER BY Name", CommandType.Text)
            'ddCheckedBy.DataTextField = ("Name")
            'ddCheckedBy.DataValueField = ("empsig_id")
            'ddCheckedBy.DataBind()
            'ddCheckedBy.Items.Insert(0, "Select")

            'ddNotedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id, isActive FROM AMS.BAC_Members WHERE isActive = 1 ORDER BY Name", CommandType.Text)
            'ddNotedBy.DataTextField = ("Name")
            'ddNotedBy.DataValueField = ("empsig_id")
            'ddNotedBy.DataBind()
            'ddNotedBy.Items.Insert(0, "Select")

            ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid IN (1,67) AND division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' ORDER BY deptid", CommandType.Text)
            ddApprovedBy.DataTextField = ("full_name")
            ddApprovedBy.DataValueField = ("empid")
            ddApprovedBy.DataBind()



            Try
                ddPAPS.Items.Clear()
                If ddFunction.SelectedItem.Text = "Select" Then
                    PAPS = Nothing
                    ddPAPS.DataSource = PAPS
                    ddPAPS.DataBind()
                    ddPAPS.Items.Add("Select")
                Else
                    Dim isforRevision As Boolean
                    isforRevision = IIf(IsDBNull(objDerived.GetValue("select isforRevision from ams.vw_manage_ppmp where rc_id=" & Me.ddRC.SelectedItem.Value & " and function_id=" & ddFunction.SelectedItem.Value & " and cyear=" & Year(CDate(txtprdate.Text)) & "", CommandType.Text)), 0, objDerived.GetValue("select isforRevision from ams.vw_manage_ppmp where rc_id=" & Me.ddRC.SelectedItem.Value & " and function_id=" & ddFunction.SelectedItem.Value & " and cyear=" & Year(CDate(txtprdate.Text)) & "", CommandType.Text))
                    ddnature.Enabled = False
                    ddPAPS.Enabled = True

                    PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_With_OOE " & Me.ddRC.SelectedItem.Value & ",'" & Year(CDate(txtprdate.Text)) & "'," & ddFunction.SelectedItem.Value & ",0", CommandType.Text)
                    ddPAPS.DataSource = PAPS
                    ddPAPS.DataTextField = ("description")
                    ddPAPS.DataValueField = ("Project_ID")
                    ddPAPS.DataBind()
                    ddPAPS.Items.Insert(0, "Select")


                    LoadPRList_PerRC()

                End If

            Catch ex As Exception
            End Try

        End If

    End Sub

    Protected Sub LoadPRList_PerRC()
        If RadioButtonList1.SelectedIndex = 0 Then
            pPRlist = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_ForEditingList] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' and Year(Date_Submitted)= '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "' AND isContinuing = 0", CommandType.Text)
        Else
            pPRlist = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_ForEditingList] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' and Year(Date_Submitted)= '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "' AND isContinuing = 1", CommandType.Text)
        End If

        Dim i As New Integer
        i = pPRlist.Rows.Count
        pPRlist.Merge(createdatatable12(4 - 1))
        gvListPR.DataSource = pPRlist
        gvListPR.DataBind()
    End Sub
    Protected Sub ddPAPS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddPAPS.SelectedIndexChanged
        ddnature.Enabled = True

        If ddPAPS.SelectedItem.Text = "Office Operational Expense" Then
            txtpurpose.Text = "Office Use"
            txtOBRpurpose.Text = "Office Use"
        Else
            txtpurpose.Text = ddPAPS.SelectedItem.Text
            txtOBRpurpose.Text = ddPAPS.SelectedItem.Text
        End If

    End Sub
    Protected Sub ddnature_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddnature.SelectedIndexChanged
        Dim Iscontinuing As New Boolean
        Try
            If RadioButtonList1.SelectedIndex = 0 Then
                Iscontinuing = False
            Else
                Iscontinuing = True
            End If
        Catch ex As Exception
        End Try

        If Me.ddnature.SelectedValue.ToString <> "Select" Then
            ddAccounts.Items.Clear()

            pAccounts = objDerived.GetDataTable("SELECT DISTINCT GA_Title, CONVERT(VARCHAR(20),GA_CODE2) AS GA_CODE2,GA_ID  from AMS.vw_Ga_Title where AllotmentClass_ID = '" & ddnature.SelectedValue.ToString & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' and Program_id = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and CYear = '" & Year(CDate(txtprdate.Text)) & "'", CommandType.Text)
            ddAccounts.DataSource = pAccounts
            ddAccounts.DataTextField = ("GA_Title")
            ddAccounts.DataValueField = ("GA_CODE2")
            ddAccounts.DataBind()
            ddAccounts.Items.Insert(0, "Select")

            ddAccounts.Enabled = True
        Else
            ddAccounts.Enabled = False
        End If

    End Sub
    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddAccounts.SelectedIndexChanged

        Dim hasReleased As New Boolean
        If RadioButtonList1.SelectedIndex = 0 Then
            '====== CURRENT RELEASE
            hasReleased = IIf(IsDBNull(objDerived.GetValue("SELECT TOP 1 LBEF_2_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Hdr WHERE Budget_Year = '" & Year(CDate(txtprdate.Text)) & "' AND RC_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' AND Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' ", CommandType.Text)), 0, objDerived.GetValue("SELECT TOP 1 LBEF_2_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Hdr WHERE Budget_Year = '" & Year(CDate(txtprdate.Text)) & "' AND RC_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' AND Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' ", CommandType.Text))

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            '====== CONTINUING RELEASE
            hasReleased = IIf(IsDBNull(objDerived.GetValue("SELECT TOP 1 LBPF_3_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Hdr WHERE Budget_Year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and  Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' AND isContinuing = 1", CommandType.Text)), 0, objDerived.GetValue("SELECT TOP 1 LBPF_3_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Hdr WHERE Budget_Year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and  Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' AND isContinuing = 1 ", CommandType.Text))

        End If

        Dim GA_ID As Integer
        Dim BGA_ID As Integer
        GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
        BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)

        If hasReleased = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No allotment has been released.")

        Else
            If ddnature.SelectedIndex = 1 Then
                Dim isGasoline As Boolean
                isGasoline = False

                pitems = objDerived.GetDataTable("exec ams.sp_supplies_for_pr '" & Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & isGasoline & "',0, '" & GA_ID & "','" & BGA_ID & "'", CommandType.Text)
                LinkButton2.Enabled = True
                lbmeals.Enabled = False

            ElseIf ddnature.SelectedIndex = 2 Then
                pitems = objDerived.GetDataTable("exec ams.sp_ppe_for_pr '" & Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & ddAccounts.SelectedValue & "',0", CommandType.Text)
                LinkButton2.Enabled = True

            Else
                GA_ID = 0
                LinkButton2.Enabled = False
                cbReinbursement.Enabled = False
                cbReinbursement.Checked = False
            End If

            Session("GA_ID") = GA_ID
            Session("BGA_ID") = BGA_ID

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.Columns(10).Visible = True

            gvitems.DataSource = pitems
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False
            gvitems.Columns(10).Visible = False

            If pitems.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No PPMP found or Account has already PR.")
            Else
                Session("ppmp_hdr_id") = pitems.Rows(0)("ppmp_hdr_id")
            End If


            ddnature.Enabled = False
            'txtOBRpurpose.ReadOnly = False
            'txtpurpose.ReadOnly = False

            Dim AllotmentClass_ID As Integer
            If ddnature.SelectedIndex <> 3 Then
                AllotmentClass_ID = ddnature.SelectedItem.Value
            Else
                AllotmentClass_ID = 3
            End If

            Try
                Session("ppmp_hdr_id") = objDerived.GetValue("Select top 1 ppmp_hdr_id from AMS.ppmp_hdr where RC_ID=" & Me.ddRC.SelectedItem.Value & " and Function_ID=" & ddFunction.SelectedItem.Value & " and Project_ID =" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "  and Program_id =" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & " and CYear=" & Year(CDate(txtprdate.Text)) & " ", CommandType.Text)

                Dim AttachDocument As New DataTable
                AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & Session("ppmp_hdr_id") & " ", CommandType.Text)

                Dim i As New Integer
                i = AttachDocument.Rows.Count - 1
                AttachDocument.Merge(createdatatable9(4 - i))
                grdocumentdetails.DataSource = AttachDocument
                grdocumentdetails.DataBind()

            Catch ex As Exception
            End Try

            ddAccounts.Enabled = True

            'pBudgetInfo = objDerived.GetDataTable("exec ams.sp_budget_release_complete  '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & AllotmentClass_ID & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Year(CDate(txtprdate.Text)) & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
            pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
            gvBudgetInfo2.DataSource = pBudgetInfo
            gvBudgetInfo2.DataBind()

            gvbody.DataSource = createdatatable1(19)
            gvbody.DataBind()


            Session("Accounts") = ddAccounts.SelectedValue
        End If

    End Sub
    Protected Sub txtpurpose_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtOBRpurpose.Text = txtpurpose.Text
    End Sub
    Protected Sub ddRequestedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtposition.Text = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND empid = '" & ddRequestedBy.SelectedItem.Value & "'", CommandType.Text)
    End Sub
    Protected Sub LinkButton2_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender1.Show()
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True
        gvitems.Columns(7).Visible = True
        gvitems.Columns(8).Visible = True
        gvitems.Columns(10).Visible = True

        If ddnature.SelectedIndex = 1 Then
            Dim GA_ID As Integer
            Dim BGA_ID As Integer
            GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
            BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)

            Dim isGasoline As Boolean
            isGasoline = False

            If Session("Edit") = 1 Then
                pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2_SEARCH] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & 0 & "','" & datahdr.Rows(0)("isContinuing") & "','" & Session("GA_ID") & "','" & SearchBut.Text & "'", CommandType.Text)
            Else
                pitems = objDerived.GetDataTable("EXEC [AMS].[sp_supplies_for_pr_SEARCH] '" & Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & isGasoline & "',0, '" & GA_ID & "','" & BGA_ID & "','" & SearchBut.Text & "'", CommandType.Text)
            End If

        ElseIf ddnature.SelectedIndex = 2 Then
            Dim GA_ID As Integer
            Dim BGA_ID As Integer
            GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
            BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)

            If Session("Edit") = 1 Then
                Session("GA_Code2") = objDerived.GetValue("SELECT GA_Code2 FROM AMS.View_AccountList WHERE GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)
                pitems = objDerived.GetDataTable("EXEC [AMS].[sp_ppe_for_pr_EDIT2_SEARCH]  '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & Session("GA_Code2") & "','" & datahdr.Rows(0)("isContinuing") & "','" & SearchBut.Text & "'", CommandType.Text)
            Else
                pitems = objDerived.GetDataTable("EXEC [AMS].[sp_ppe_for_pr_SEARCH] '" & Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & ddAccounts.SelectedValue & "',0,'" & SearchBut.Text & "'", CommandType.Text)
            End If

        End If

        gvitems.DataSource = pitems
        gvitems.DataBind()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False
        gvitems.Columns(10).Visible = False

        SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & Button5.ClientID & "')")

        Me.ModalPopupExtender1.Show()

    End Sub
    Protected Sub gvBudgetInfo2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvitems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvitems.PageIndexChanging
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True
        gvitems.Columns(7).Visible = True
        gvitems.Columns(8).Visible = True
        'gvitems.Columns(9).Visible = True
        gvitems.Columns(10).Visible = True

        Me.gvitems.PageIndex = e.NewPageIndex
        Me.gvitems.DataSource = CType(pitems, DataTable)
        Me.gvitems.DataBind()

        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        'gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False
        gvitems.Columns(10).Visible = False
        'gvitems.Columns(9).Visible = False

        ModalPopupExtender1.Show()

    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb2 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb2.NamingContainer, GridViewRow)

        If cb2.Checked = True Then
            pitems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = True
        Else
            pitems.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = False
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
                    pitems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                pitems.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If

        ModalPopupExtender1.Show()
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim sumObject As Integer
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.Columns(10).Visible = True

            Dim dt, dt_GA_ID As New DataTable
            Dim dr As DataRow
            Dim cb As CheckBox

            Dim x As Boolean = Session("edit_pr")

            If pBody Is Nothing Then
                'If gvbody.Rows.Count = 0 Then
                dt.Columns.Add("id", GetType(Integer))
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("Description", GetType(String))
                dt.Columns.Add("InputQty", GetType(Integer))
                dt.Columns.Add("qty", GetType(Decimal))
                dt.Columns.Add("cost", GetType(Decimal))
                dt.Columns.Add("total", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Integer))
                dt.Columns.Add("isVisible", GetType(Boolean))
                dt.Columns.Add("ReadOnly", GetType(Boolean))
                dt.Columns.Add("GA_ID", GetType(Integer))
                dt.Columns.Add("BGA_ID", GetType(Integer))
                dt.Columns.Add("GA_Code2", GetType(String))
                dt.Columns.Add("Project_title", GetType(String))
                dt.Columns.Add("PR_ItemSpecs", GetType(String))
                dt.Columns.Add("ppmp_dtl_id", GetType(Long))
                dt_GA_ID.Columns.Add("GA_ID", GetType(Integer))
                dt_GA_ID.Columns.Add("BGA_ID", GetType(Integer))

                For i As Integer = 0 To Me.pitems.Rows.Count - 1
                    If pitems.Rows(i)("isChecked") = True Then
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = pitems.Rows(i)("Item_Desc")
                        dr("Description") = pitems.Rows(i)("Description")
                        dr("InputQty") = 0
                        dr("qty") = pitems.Rows(i)("qty")
                        dr("cost") = pitems.Rows(i)("cost")
                        dr("total") = CType(pitems.Rows(i)("cost") * pitems.Rows(i)("qty"), Decimal)
                        dr("Item_ID") = pitems.Rows(i)("Item_ID")
                        dr("isVisible") = True
                        dr("ReadOnly") = False
                        dr("GA_ID") = pitems.Rows(i)("GA_ID")
                        dr("BGA_ID") = pitems.Rows(i)("BGA_ID")
                        dr("GA_Code2") = pitems.Rows(i)("GA_Code2")
                        dr("ppmp_dtl_id") = pitems.Rows(i)("ppmp_dtl_id")
                        dt.Rows.Add(dr)

                        pitems.Rows(i)("isUsed") = True
                        pitems.Rows(i)("isChecked") = False
                    End If
                Next

                pBody = dt

            Else

                Dim dr2 As DataRow
                dt.Columns.Add("id", GetType(Long))
                dt = pBody

                For i As Integer = 0 To Me.pitems.Rows.Count - 1
                    If pitems.Rows(i)("isChecked") = True Then
                        Session("x") = 0
                        For a As Integer = 0 To Me.pBody.Rows.Count - 1
                            If pBody.Rows(a)("ppmp_dtl_id") = pitems.Rows(i)("ppmp_dtl_id") Then
                                Session("x") = 1
                            End If
                        Next

                        If Session("x") = 0 Then
                            dr2 = dt.NewRow
                            dr2("id") = 1
                            dr2("Item_Desc") = pitems.Rows(i)("Item_Desc")
                            dr2("Description") = pitems.Rows(i)("Description")
                            dr2("InputQty") = 0
                            dr2("qty") = pitems.Rows(i)("qty")
                            dr2("cost") = pitems.Rows(i)("cost")
                            dr2("total") = CType(pitems.Rows(i)("cost") * pitems.Rows(i)("qty"), Decimal)
                            dr2("Item_ID") = pitems.Rows(i)("Item_ID")
                            dr2("isVisible") = True
                            dr2("ReadOnly") = False
                            dr2("GA_ID") = pitems.Rows(i)("GA_ID")
                            dr2("BGA_ID") = pitems.Rows(i)("BGA_ID")
                            dr2("GA_Code2") = pitems.Rows(i)("GA_Code2")
                            dr2("ppmp_dtl_id") = pitems.Rows(i)("ppmp_dtl_id")
                            dt.Rows.Add(dr2)
                            pBody = dt
                            pitems.Rows(i)("isUsed") = True
                            pitems.Rows(i)("isChecked") = False
                        End If
                    End If
                Next

            End If

            gvbody.DataSource = pBody
            gvbody.DataBind()

            Dim myview As DataView
            myview = pitems.DefaultView
            myview.RowFilter = "isUsed = false"
            gvitems.DataSource = myview
            gvitems.DataBind()

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            'gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False
            gvitems.Columns(10).Visible = False
            'gvitems.Columns(9).Visible = False


            If Session("edit_pr") = False Then
                If pBody.Compute("sum(total)", "") = "0.00" Then
                    CType(gvbody.FooterRow.Cells(6).FindControl("lbltotal"), Label).Text = "0.00"
                Else
                    CType(gvbody.FooterRow.Cells(6).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                End If

                '=== 05162016 CHECK IF GASOLINE - ENABLE PRICE TO UPDATE
                For i As Integer = 0 To Me.pBody.Rows.Count - 1
                    If pBody.Rows(i)("GA_ID") = 794 Then
                        CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = False
                    End If
                Next


            Else
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    Dim Total As Decimal = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text * CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                    CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = FormatNumber(Total, 2)

                    '=== 05162016 CHECK IF GASOLINE - ENABLE PRICE TO UPDATE
                    If pBody.Rows(i)("GA_ID") = 794 Then
                        CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = False
                    End If
                Next

                If pBody.Compute("sum(total)", "") = "0.00" Then
                    CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = "0.00"
                Else
                    CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                End If
            End If

            btnSave.Enabled = True
        Catch ex As Exception
        End Try

        Me.ModalPopupExtender1.Show()
        LinkButton2.Enabled = True
    End Sub
    Protected Sub gvbody_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvbody.SelectedIndexChanged
        If Lbtn = "detail" Then

        ElseIf Lbtn = "Delete" Then

        ElseIf Lbtn = "DEL" Then
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT PRHdr_ID, Item_ID FROM AMS.PR_Dtl WHERE prhdr_id = '" & Session("prhdr_id") & "' AND Item_ID = '" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)
            If dt.Rows.Count = 0 Then
                For i As Integer = 0 To pBody.Rows.Count - 1
                    If pBody.Rows(i).Item("Item_ID") = gvbody.SelectedDataKey("Item_ID") Then
                        '=============== DELETE ITEMS TO THE GRIDVIEW
                        pBody.Rows(i).Delete()

                        '============== ITEM BACK TO THE LIST
                        For cn As Integer = 0 To pitems.Rows.Count - 1
                            If pitems.Rows(cn)("Item_ID") = gvbody.SelectedDataKey("Item_ID") Then
                                pitems.Rows(cn)("isUsed") = False
                                pitems.Rows(cn)("isChecked") = False
                            End If
                        Next

                        Exit For
                    End If
                Next

                gvbody.DataSource = pBody
                gvbody.DataBind()
                gvbody.SelectedIndex = -1

                CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                gvitems.Columns(3).Visible = True
                gvitems.Columns(4).Visible = True
                gvitems.Columns(5).Visible = True
                gvitems.Columns(6).Visible = True
                gvitems.Columns(7).Visible = True
                gvitems.Columns(8).Visible = True
                gvitems.Columns(10).Visible = True

                Dim myview As DataView
                myview = pitems.DefaultView
                myview.RowFilter = "isUsed = 'false'"
                gvitems.DataSource = myview
                gvitems.DataBind()
                gvitems.PageIndex = 0

                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                gvitems.Columns(6).Visible = False
                gvitems.Columns(7).Visible = False
                gvitems.Columns(8).Visible = False
                gvitems.Columns(10).Visible = False

            Else

                Dim ppmp As Integer = gvbody.SelectedDataKey("ppmp_dtl_id")
                Dim itemid As Integer = gvbody.SelectedDataKey("Item_ID")

                objDerived.Execute("DELETE AMS.PR_dtl where ppmp_dtl_id='" & gvbody.SelectedDataKey("ppmp_dtl_id") & "' and Item_ID ='" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)
                pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
                gvbody.DataSource = pBody
                gvbody.DataBind()
                gvbody.SelectedIndex = -1

                Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET ABC = '" & ABC & "' WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
                For i As Integer = 0 To gvbody.Rows.Count - 1
                    Dim txtcost As TextBox = CType(gvbody.Rows(i).Cells(5).FindControl("txtcost"), TextBox)
                    txtcost.Enabled = False
                Next

                CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                Dim OBR_DTL_ID As Long = objDerived.GetValue("SELECT OBR_Dtl_ID FROM [dbo].[View_GetOBR_Dtl_ID] WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Dtl set amount='" & ABC & "' where OBR_Dtl_ID = '" & OBR_DTL_ID & "' ", CommandType.Text)

                If Session("AllotmentClass_ID") = 2 Then
                    pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "', '" & 0 & "','" & datahdr.Rows(0)("isContinuing") & "','" & Session("GA_ID") & "'", CommandType.Text)
                ElseIf Session("AllotmentClass_ID") = 3 Then
                    pitems = objDerived.GetDataTable("EXEC [AMS].[sp_ppe_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & Session("GA_Code2") & "','" & datahdr.Rows(0)("isContinuing") & "'", CommandType.Text)
                Else
                    Exit Sub
                End If

                gvitems.Columns(3).Visible = True
                gvitems.Columns(4).Visible = True
                gvitems.Columns(5).Visible = True
                gvitems.Columns(6).Visible = True
                gvitems.Columns(7).Visible = True
                gvitems.Columns(8).Visible = True
                gvitems.Columns(10).Visible = True

                gvitems.DataSource = pitems
                gvitems.DataBind()

                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                gvitems.Columns(6).Visible = False
                gvitems.Columns(7).Visible = False
                gvitems.Columns(8).Visible = False
                gvitems.Columns(10).Visible = False

                Session("edit_pr") = True
            End If
        End If
    End Sub
    Protected Sub gvbody_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Lbtn = "Delete"

        Dim ppmp As Integer = gvbody.SelectedDataKey("ppmp_dtl_id")
        Dim itemid As Integer = gvbody.SelectedDataKey("Item_ID")

        objDerived.Execute("DELETE AMS.PR_dtl where ppmp_dtl_id='" & gvbody.SelectedDataKey("ppmp_dtl_id") & "' and Item_ID ='" & gvbody.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
        gvbody.DataSource = pBody
        gvbody.DataBind()
    End Sub
    Protected Sub gvbody_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvbody.RowDataBound

    End Sub
    Protected Sub gvbody_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvbody.DataBound

    End Sub
    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Delete"
    End Sub
    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Lbtn = "DEL"
    End Sub
    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If

            'If MultiView2.ActiveViewIndex = 1 Then
            '    ModalPopupExtender1.TargetControlID = "LinkButton3"
            '    ModalPopupExtender1.PopupControlID = "popup"
            '    ModalPopupExtender1.CancelControlID = "ImageButton3"
            '    ModalPopupExtender1.BackgroundCssClass = "modalBackground"
            'End If


            If Session("edit_pr") = True Then '=== EDIT PURCHASE REQUEST
                Dim TotalQty As Decimal = CType(pBody.Rows(gvr.RowIndex)("Qty") + pBody.Rows(gvr.RowIndex)("InPutQty"), Decimal)
                Dim InputQty As Decimal = CType(txtqty.Text, Decimal)
                Dim AvailableQty As Decimal = TotalQty - InputQty

                If AvailableQty < 0 Then
                    txtqty.Text = pBody.Rows(gvr.RowIndex)("Qty")
                    CType(gvbody.Rows(gvr.RowIndex).FindControl("lblBalance"), Label).Text = pBody.Rows(gvr.RowIndex)("InPutQty")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not exceed " & TotalQty & "")
                    Exit Sub

                Else
                    CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal) * CType(txtqty.Text, Decimal), 2)

                    'pBody.Rows(gvr.RowIndex)("txtqty") = InputQty
                    'pBody.Rows(gvr.RowIndex)("InPutQty") = AvailableQty
                    pBody.Rows(gvr.RowIndex)("total") = CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
                    CType(gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("lblBalance"), Label).Text = AvailableQty
                    CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                    LinkButton2.Enabled = False
                End If

            Else '=== CREATE NEW PURCHASE REQUEST
                If pBody.Rows(gvr.RowIndex)("Qty") >= CType(txtqty.Text, Decimal) Then

                    CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal) * CType(txtqty.Text, Decimal), 2)

                    pBody.Rows(gvr.RowIndex)("total") = CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
                    pBody.Rows(gvr.RowIndex)("InPutQty") = CType(txtqty.Text, Decimal)

                    CType(gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("lblBalance"), Label).Text = pBody.Rows(gvr.RowIndex)("Qty") - CType(txtqty.Text, Decimal)
                    CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                Else
                    If CType(gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("lblBalance"), Label).Text = 0 Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not exceed " & pBody.Rows(gvr.RowIndex)("Qty") & "")
                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity must not exceed " & pBody.Rows(gvr.RowIndex)("Qty") & "")
                    End If

                    Dim a As Decimal
                    Dim b As Decimal
                    a = pBody.Rows(gvr.RowIndex)("total")
                    b = pBody.Rows(gvr.RowIndex)("cost")

                    txtqty.Text = pBody.Rows(gvr.RowIndex)("total") / pBody.Rows(gvr.RowIndex)("cost")
                    CType(gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("lblBalance"), Label).Text = pBody.Rows(gvr.RowIndex)("Qty") - CType(txtqty.Text, Decimal)
                    txtqty.Focus()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub txtcost_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            If txtcost.Text = "" Or txtcost.Text = "0" Then
                txtcost.Text = "0.00"
            End If
            txtcost.Text = FormatNumber(txtcost.Text, 2)

            '==== NEW CODE 05172016
            If CType(txtcost.Text, Decimal) = 0 Then
                Dim cost As Decimal
                cost = pBody.Rows(gvr.RowIndex)("cost")
                txtcost.Text = cost

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Zero is not allowed.")
            Else
                CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox).Text, Integer) * CType(txtcost.Text, Decimal), 2)
                pBody.Rows(gvr.RowIndex)("total") = CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                If CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = "0.00" Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "detail"
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim GA_ID As Integer = objDerived.GetValue("Select GA_ID from AMS.vw_Ga_Title where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
        Session("GA_ID") = GA_ID

        If txtpurpose.Text = "" Or txtOBRpurpose.Text = "" Or ddRequestedBy.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")
            Exit Sub
        Else
            SaveGoods()

        End If
    End Sub
    Public Sub SaveGoods()
        Try
            If ddRequestedBy.SelectedItem.Text = "Select" Or ddApprovedBy.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "ThenSelect signatories.")
                Exit Sub
            End If

            If Me.Session("edit_pr") = False Then

                'Dim budget As Decimal = objDerived.GetValue("EXEC [AMS].[sp_BudgetCheck_ForPR] '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddnature.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Year(CDate(txtprdate.Text)) & "',0,'" & Session("GA_ID") & "'", CommandType.Text)
                Dim budget As Decimal = objDerived.GetValue("EXEC [AMS].[sp_BudgetCheck_ForPR] '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddnature.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Year(CDate(txtprdate.Text)) & "','" & RadioButtonList1.SelectedValue & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "'", CommandType.Text)
                Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                If budget < ABC Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR amount exceeds from the available budget.")
                    Exit Sub
                End If

                Dim prhdrID As Long

                '=-= Saving PR_Hdr (Goods)
                prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy")) 'Year(CDate(txtprdate.Text)) 
                prhdr.PR_Date = "01/01/1900"
                prhdr.RC_ID = ddRC.SelectedItem.Value
                prhdr.Function_ID = ddFunction.SelectedItem.Value
                prhdr.remarks = txtpurpose.Text
                prhdr.Transaction_type = ddnature.SelectedItem.Value
                prhdr.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                prhdr.Program_id = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                prhdr.ABC = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                prhdr.Requestedby = ddRequestedBy.SelectedItem.Value
                prhdr.Approvedby = ddApprovedBy.SelectedItem.Value
                prhdr.Date_Submitted = txtprdate.Text
                prhdr.Date_gso_rcv = "01/01/1900"
                prhdr.IsCancelled = False
                prhdr.IsApproved = False
                prhdr.isOnBid = False
                prhdr.POHdr_ID = 0
                prhdr.withWinner = False
                prhdr.withPO = False
                prhdr.declarationDate = "01/01/1900"
                prhdr.rcv_date = "01/01/1900"
                prhdr.isPublicInfra = False
                prhdr.isStraight = False
                prhdr.DateApproved_PR_Mayor = "01/01/1900"
                prhdr.DateReceived_PR_Mayor = "01/01/1900"
                prhdr.isApproved_PR_Mayor = False
                prhdr.isReceived_PR_Mayor = False
                prhdr.DateDisApprove = "01/01/1900"
                prhdr.isGasoline = False
                prhdr.pr_period_key_id = 0
                prhdr.pr_invoice_hdr_id = 0
                prhdr.isReimbursement = cbReinbursement.Checked
                prhdr.isContract = False
                prhdr.isEditable = True
                prhdr.RequestingOfficer = Me.txtrequestingperson.Text
                prhdr.Position = Me.txtposition.Text
                prhdr.isContinuing = RadioButtonList1.SelectedValue
                prhdr.mode_of_procurement_id = 0
                prhdr.isTrustFund = False
                prhdr.CheckBy = 0
                prhdr.NotedBy = 0
                prhdr.GA_ID = Session("GA_ID")
                prhdr.UserID = Session("@UserName")
                prhdrID = prhdr.save

                Session("PRNo") = prhdrID
                Session("prhdr_id") = prhdrID

                Dim CTO As Integer
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & rbTrustFund.SelectedItem.Value & "', CityTreasurer = '" & CTO & "', comment = '" & replaceapostrophe(txtNote.Text) & "', Address = '" & txtaddpeyee.Text & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

                '=-= Saving PR_Dtl
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    If CType(Me.gvbody.Rows(i).Cells(4).FindControl("lbltotal"), Label).Text <> "0.00" Then
                        prdtl.PRHdr_ID = prhdrID
                        prdtl.Item_ID = pBody.Rows(i)("Item_ID")
                        If CType(gvbody.Rows(i).FindControl("txtMemo"), TextBox).Text <> "" Then
                            prdtl.Project_title = txtpurpose.Text
                        Else
                            prdtl.Project_title = ""
                        End If

                        prdtl.PR_ItemSpecs = CType(gvbody.Rows(i).FindControl("txtremarks"), TextBox).Text

                        prdtl.Qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text 'CType(gvbody.Rows(i).FindControl("lblBalance"), Label).Text() 
                        prdtl.Cost = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                        prdtl.ppmp_dtl_id = pBody.Rows(i)("ppmp_dtl_id")
                        'prdtl.Userid = Me.Session("@UserName").ToString 

                        Dim iQty As Decimal
                        iQty = objDerived.GetValue("SELECT AMS.PR_Dtl.Qty FROM AMS.PR_Hdr INNER JOIN AMS.PR_Dtl ON AMS.PR_Hdr.prhdr_id = AMS.PR_Dtl.PRHdr_ID WHERE AMS.PR_Hdr.prhdr_id = '" & prhdrID & "' AND AMS.PR_Dtl.Item_ID = '" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                        If iQty = 0 Then
                            prdtl.save()
                        Else
                            Dim NewQTY As Decimal
                            NewQTY = CType(iQty + CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text, Decimal)

                            Dim PRdtl_ID As Long
                            PRdtl_ID = objDerived.GetValue("SELECT AMS.PR_Dtl.PRDtlID FROM AMS.PR_Hdr INNER JOIN AMS.PR_Dtl ON AMS.PR_Hdr.prhdr_id = AMS.PR_Dtl.PRHdr_ID WHERE AMS.PR_Hdr.prhdr_id = '" & prhdrID & "' AND AMS.PR_Dtl.Item_ID = '" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)

                            objDerived.Execute("UPDATE AMS.PR_Dtl SET Qty = '" & NewQTY & "' WHERE PRDtlID = '" & PRdtl_ID & "'", CommandType.Text)
                        End If

                    End If
                    CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
                Next


                '=-= Saving OBR_Hdr
                obr_hdr.TempOBR_No = ""
                Dim obj As New BaseClassesint.AccountClassAcounts
                Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)

                Dim str As String
                If rbTrustFund.SelectedItem.Value = 1 Then
                    str = "100"
                Else
                    str = "200"
                End If

                Dim d As Date = txtprdate.Text
                Dim FundSourceID As Integer = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)

                If FundSourceID = 14 Then
                    obr_hdr.OBR_No = str & "(18)" & "-" & d.ToString("yy") & "-"
                Else
                    obr_hdr.OBR_No = str & "-" & d.ToString("yy") & "-"
                End If

                obr_hdr.F_ID_Accntg = rbTrustFund.SelectedItem.Value
                obr_hdr.Period_key = 0
                obr_hdr.PRHdr_ID = prhdrID
                obr_hdr.OBR_Date = txtprdate.Text
                obr_hdr.OBR_Title = txtOBRpurpose.Text
                obr_hdr.Budget_Year = Year(txtprdate.Text)
                obr_hdr.Supplier_ID = 0
                obr_hdr.Payee = txtpeyee.Text
                obr_hdr.Func_per_Office_ID = func_per_office
                obr_hdr.Address = txtaddpeyee.Text
                obr_hdr.Remarks = txtOBRpurpose.Text
                obr_hdr.isPayroll = False
                obr_hdr.isApprovedMayor = False
                obr_hdr.isApproved = False
                obr_hdr.isCancelled = False
                obr_hdr.DateSigned1 = txtprdate.Text
                obr_hdr.DateSigned2 = txtprdate.Text
                obr_hdr.isPayroll = False
                obr_hdr.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & ddRC.SelectedItem.Value & "' AND func_id = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 1", CommandType.Text)
                obr_hdr.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
                obr_hdr.Status = "Pending"
                obr_hdr.isAdjusted = False
                obr_hdr.isAddForDisbursement = False
                obr_hdr.isPayrollATM = False
                obr_hdr.isGasoline = False
                obr_hdr.pr_period_key_id = 0
                obr_hdr.pr_invoice_hdr_id = 0
                obr_hdr.DateDisapprovedMayor = "01/01/1900"
                obr_hdr.DateApprovedMayor = "01/01/1900"
                obr_hdr.DateReceivedMayor = "01/01/1900"
                obr_hdr.isReceivedBO = False
                obr_hdr.PayeeOffice = ""

                Dim obr_hdr_id As Long = obr_hdr.save()
                Session("obr_id") = obr_hdr_id

                objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET forContinuing = '" & RadioButtonList1.SelectedValue & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)


                '=-= Saving OBR_Dtl 
                obr_dtl.OBR_Hdr_ID = obr_hdr_id
                obr_dtl.particulars = txtOBRpurpose.Text
                obr_dtl.BGA_ID = Session("BGA_ID")
                obr_dtl.RC_ID = ddRC.SelectedItem.Value
                obr_dtl.Function_ID = ddFunction.SelectedItem.Value
                obr_dtl.Program_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                obr_dtl.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                obr_dtl.GA_ID = Session("GA_ID")
                obr_dtl.Amount = FormatNumber(pBody.Compute("sum(total)", "GA_ID=" & obr_dtl.GA_ID & " and BGA_ID=" & obr_dtl.BGA_ID & ""), 2)
                obr_dtl.AllotmentClass_ID = ddnature.SelectedItem.Value
                obr_dtl.save()

                Dim amount As Decimal
                amount = obr_dtl.Amount

                'pBudgetInfo = objDerived.GetDataTable("exec ams.sp_budget_release_complete  " & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & ddnature.SelectedItem.Value & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "," & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & ",'" & Year(CDate(txtprdate.Text)) & "',0", CommandType.Text)
                pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
                gvBudgetInfo2.DataSource = pBudgetInfo
                gvBudgetInfo2.DataBind()


                Session("edit_pr") = False

            Else

                Dim budget As Decimal = objDerived.GetValue("EXEC [AMS].[sp_BudgetCheck_ForEditPR] '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddnature.SelectedItem.Value & "','" & Session("Project_ID") & "','" & Session("program_id") & "','" & Year(CDate(txtprdate.Text)) & "','" & Session("isContinuing") & "','" & oGA_ID & "','" & oBGA_ID & "','" & Session("prhdr_id") & "'", CommandType.Text)
                Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                If budget < ABC Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR amount exceeds from the available budget.")
                    Exit Sub
                End If

                '======== PR_HDR Edit ======== 
                Session("PRNo") = gvListPR.SelectedDataKey(0)
                Session("prhdr_id") = gvListPR.SelectedDataKey(0)

                Dim CTO As Integer
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes' AND isActive = 1", CommandType.Text)

                objDerived.GetRecords("UPDATE ams.pr_hdr SET ABC = '" & pBody.Compute("sum(total)", "") & "', remarks = '" & replaceapostrophe(txtpurpose.Text) & "', " &
                                " Requestedby = '" & ddRequestedBy.SelectedItem.Value & "', CityTreasurer = '" & CTO & "' " &
                                " WHERE prhdr_id='" & gvListPR.SelectedDataKey(0) & "' ", CommandType.Text)


                '======== PR_Dtl Edit ======== 
                Dim origcount As Integer = Me.Session("row_num_edit")
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    Dim qty As Decimal = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text()
                    Dim cost As Decimal = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                    Dim PRSpecs As String = CType(gvbody.Rows(i).FindControl("txtremarks"), TextBox).Text
                    Dim dtPRdtl As New DataTable

                    dtPRdtl = objDerived.GetDataTable("Select * from AMS.PR_Dtl where prhdr_id = '" & Session("prhdr_id") & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    If dtPRdtl.Rows.Count = 0 Then
                        objDerived.Execute("INSERT INTO AMS.PR_Dtl (PRHdr_ID,Item_ID,Project_title,Qty,Cost,ppmp_dtl_id,PR_ItemSpecs) values('" & gvListPR.SelectedDataKey(0) & "','" & pBody.Rows(i)("Item_ID") & "','" & txtpurpose.Text & "','" & qty & "','" & cost & "','" & pBody.Rows(i)("ppmp_dtl_id") & "','" & PRSpecs & "')", CommandType.Text)
                    Else
                        objDerived.GetRecords("Update AMS.PR_Dtl set Qty ='" & qty & "', Project_title = '" & txtpurpose.Text & "', Cost = '" & cost & "', PR_ItemSpecs = '" & PRSpecs & "' where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    End If
                Next


                '======== OBR_HDR Edit ======== 
                Dim OBR_HDR_ID As Integer = objDerived.GetValue("SELECT OBR_Hdr_ID FROM GeoBOS.BOS.T_OBR_Hdr AS A WHERE A.PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
                objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr SET Remarks='" & replaceapostrophe(txtOBRpurpose.Text) & "', OBR_Title = '" & replaceapostrophe(txtOBRpurpose.Text) & "', Payee='" & txtpeyee.Text & "', Address='" & txtaddpeyee.Text & "' WHERE OBR_Hdr_ID = " & OBR_HDR_ID & "", CommandType.Text)

                '======== OBR_Dtl Edit ========
                objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Dtl SET amount = '" & pBody.Compute("sum(total)", "") & "', Particulars='" & replaceapostrophe(txtpurpose.Text) & "' WHERE OBR_Hdr_ID= " & OBR_HDR_ID & " ", CommandType.Text)


                'pBudgetInfo = objDerived.GetDataTable("exec ams.sp_budget_release_complete  " & datahdr.Rows(0)("RC_ID") & "," & datahdr.Rows(0)("Function_ID") & "," & Session("AllotmentClass_ID") & "," & datahdr.Rows(0)("project_ID") & "," & datahdr.Rows(0)("program_id") & ",'" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("isContinuing") & "'", CommandType.Text)
                pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Session("Project_ID") & "','" & Session("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
                gvBudgetInfo2.DataSource = pBudgetInfo
                gvBudgetInfo2.DataBind()


                Session("edit_pr") = False
            End If

            Dim data As New DataTable
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            UploadButton.Enabled = False
            LoadPRList_PerRC()

            btnSave.Enabled = False
            txtpurpose.ReadOnly = True
            txtOBRpurpose.ReadOnly = True
            LinkButton2.Enabled = False
            btnpreview.Enabled = True

            gvbody.DataSource = createdatatable1(5)
            gvbody.DataBind()

            ddRC.Enabled = False
            ddFunction.Enabled = False
            ddPAPS.Enabled = False

            Me.txtpurpose.Text = ""
            Me.txtOBRpurpose.Text = ""
            lblreq1.Visible = True
            lblreq2.Visible = True
            btnBuildingBrowse.Disabled = False
            btnAddlist.Enabled = True
            btnSubmit.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "An Error occurred please inform the admin.")

        End Try
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CheckPR As String = objDerived.GetValue("SELECT ISNULL([pr_no],'0') FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & Session("prhdr_id") & "'", CommandType.Text)
        If CheckPR = "0" Then
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, Date_Submitted = '" & Date.Today.ToString("MM/dd/yyyy") & "' WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        Else
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, [IsApproved] = 1, [isEditable] = 0 WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        End If

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Request has been submitted.")
        btnSubmit.Enabled = False

    End Sub
    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Session("Page") = "PR"
        Session("Report") = "PR"

        Dim isDBM As Boolean = objDerived.GetValue("SELECT ISNULL(isDBM,0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        If isDBM = False Then
            ' Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")
            Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")
        Else
            Me.Page.Response.Redirect("~/procurement/rpt_ARP.aspx")
        End If

    End Sub

    Protected Sub gvListPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListPR.SelectedIndexChanged


        If IsDBNull(gvListPR.SelectedDataKey(0)) = True Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select purchase request transaction.")
            Exit Sub

        Else
            Try
                If Lbtn = "PR" Then
                    Session("Page") = "PR"
                    Session("Report") = "PR"

                    Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")
                    Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")


                ElseIf Lbtn = "ObR" Then
                    Session("Page") = "PR"
                    Session("Report") = "PR"

                    Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")
                    Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")

                ElseIf Lbtn = "cancel" Then

                ElseIf Lbtn = "edit" Then

                    Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")
                    Session("isContinuing") = objDerived.GetValue("SELECT isContinuing FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)

                    oGA_ID = objDerived.GetValue("SELECT GA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
                    oBGA_ID = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)

                    Session("GA_ID") = oGA_ID
                    Session("BGA_ID") = oBGA_ID

                    ddAccounts.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList", CommandType.Text)
                    ddAccounts.DataTextField = ("GA_Title")
                    ddAccounts.DataValueField = ("GA_CODE2")
                    ddAccounts.DataBind()
                    ddAccounts.SelectedValue = objDerived.GetValue("SELECT TOP(1) GA_Code2 FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)

                    btnpreview.Enabled = False
                    ddPAPS.Enabled = False
                    ddnature.Enabled = False
                    LinkButton2.Enabled = False
                    btnAddlist.Enabled = True
                    Me.Session("edit_pr") = True

                    ddRC.Enabled = False
                    ddFunction.Enabled = False
                    ddAccounts.Enabled = False

                    datahdr = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_hdr " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
                    ddnature.SelectedValue = datahdr.Rows(0)("Transaction_type")

                    txtpurpose.Text = datahdr.Rows(0)("remarks")
                    txtNote.Text = datahdr.Rows(0)("Note")

                    txtOBRpurpose.Text = datahdr.Rows(0)("OBR_Title")
                    txtpeyee.Text = datahdr.Rows(0)("Payee")
                    txtaddpeyee.Text = datahdr.Rows(0)("Address")


                    txtOBRpurpose.ReadOnly = False
                    txtpeyee.Enabled = True
                    txtaddpeyee.Enabled = True

                    Dim PPAname As DataTable
                    PPAname = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_Edit_PR " & Me.ddRC.SelectedItem.Value & ",'" & Year(CDate(txtprdate.Text)) & "'," & ddFunction.SelectedItem.Value & ",0," & datahdr.Rows(0)("Project_ID") & "," & datahdr.Rows(0)("Program_id") & "", CommandType.Text)
                    Dim c As String
                    c = PPAname.Rows(0)("description")

                    ddPAPS.SelectedItem.Text = PPAname.Rows(0)("description")


                    porgibody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)


                    pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
                    gvbody.DataSource = pBody
                    gvbody.DataBind()
                    CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                    If gvListPR.SelectedDataKey("IsApproved") = True Then
                        For i As Integer = 0 To gvbody.Rows.Count - 1
                            CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Enabled = False
                            CType(gvbody.Rows(i).FindControl("ImageButton4"), ImageButton).Enabled = False
                        Next

                    End If

                    Me.Session("origbody") = pBody
                    Me.Session("row_num_edit") = pBody.Rows.Count - 1

                    Dim AllotmentClass_ID As Integer
                    If ddnature.SelectedIndex <> 3 Then
                        AllotmentClass_ID = ddnature.SelectedItem.Value
                    Else
                        AllotmentClass_ID = 3
                    End If

                    Session("AllotmentClass_ID") = AllotmentClass_ID

                    'Dim a1, a2, a3, a4, a5, a6, a7
                    'a1 = datahdr.Rows(0)("RC_ID")
                    'a2 = datahdr.Rows(0)("Function_ID")
                    'a3 = datahdr.Rows(0)("project_ID")
                    'a4 = datahdr.Rows(0)("program_id")
                    'a5 = Year(CDate(txtprdate.Text))
                    'a6 = gvListPR.SelectedDataKey(0)
                    'a7 = datahdr.Rows(0)("isContinuing")

                    Session("project_ID") = datahdr.Rows(0)("project_ID")
                    Session("program_id") = datahdr.Rows(0)("program_id")

                    'pBudgetInfo = objDerived.GetDataTable("exec ams.sp_budget_release_complete  " & datahdr.Rows(0)("RC_ID") & "," & datahdr.Rows(0)("Function_ID") & "," & AllotmentClass_ID & "," & datahdr.Rows(0)("project_ID") & "," & datahdr.Rows(0)("program_id") & ",'" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("isContinuing") & "'", CommandType.Text)
                    pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Session("project_ID") & "','" & Session("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
                    gvBudgetInfo2.DataSource = pBudgetInfo
                    gvBudgetInfo2.DataBind()


                    p_GA_ID = objDerived.GetDataTable("SELECT T_OBR_Dtl.GA_ID, T_OBR_Dtl.BGA_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Dtl as T_OBR_Dtl INNER JOIN LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr as T_OBR_Hdr ON T_OBR_Dtl.OBR_Hdr_ID = T_OBR_Hdr.OBR_Hdr_ID INNER JOIN AMS.PR_Hdr ON T_OBR_Hdr.PRHdr_ID = AMS.PR_Hdr.prhdr_id WHERE     AMS.PR_Hdr.prhdr_id = '" & gvListPR.SelectedDataKey(0) & "'", CommandType.Text)
                    Me.Session("row_ p_GA_ID_edit") = p_GA_ID.Rows.Count - 1

                    Session("Edit") = 1
                    If ddnature.SelectedIndex = 1 Then
                        pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & 0 & "',0,'" & Session("GA_ID") & "'", CommandType.Text)

                        LinkButton2.Enabled = True
                        lbmeals.Enabled = False
                        If datahdr.Rows(0)("isReimbursement") = True Then
                            cbReinbursement.Enabled = False
                            RequiredFieldValidator11.Enabled = True
                            RequiredFieldValidator12.Enabled = True

                        Else
                            cbReinbursement.Enabled = True
                            RequiredFieldValidator11.Enabled = False
                            RequiredFieldValidator12.Enabled = False

                        End If

                        cbReinbursement.Checked = datahdr.Rows(0)("isReimbursement")

                    ElseIf ddnature.SelectedIndex = 2 Then
                        'pitems = objDerived.GetDataTable("exec ams.sp_ppe_for_pr_edit " & Year(CDate(txtprdate.Text)) & "," & datahdr.Rows(0)("RC_ID") & "," & datahdr.Rows(0)("function_ID") & "," & datahdr.Rows(0)("project_id") & "," & datahdr.Rows(0)("program_id") & ", '" & gvListPR.SelectedDataKey(0) & "','" & datahdr.Rows(0)("isContinuing") & "'", CommandType.Text)
                        Session("GA_Code2") = objDerived.GetValue("SELECT GA_Code2 FROM AMS.View_AccountList WHERE GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)

                        pitems = objDerived.GetDataTable("EXEC [AMS].[sp_ppe_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & Session("GA_Code2") & "',0", CommandType.Text)

                        LinkButton2.Enabled = True
                        If datahdr.Rows(0)("isReimbursement") = True Then
                            cbReinbursement.Enabled = False
                            RequiredFieldValidator11.Enabled = True
                            RequiredFieldValidator12.Enabled = True

                        Else
                            cbReinbursement.Enabled = True
                            RequiredFieldValidator11.Enabled = False
                            RequiredFieldValidator12.Enabled = False

                        End If
                        cbReinbursement.Checked = datahdr.Rows(0)("isReimbursement")
                    Else
                        LinkButton2.Enabled = False
                        cbReinbursement.Enabled = False
                        cbReinbursement.Checked = False
                    End If

                    gvitems.Columns(3).Visible = True
                    gvitems.Columns(4).Visible = True
                    gvitems.Columns(5).Visible = True
                    gvitems.Columns(6).Visible = True
                    gvitems.Columns(7).Visible = True
                    gvitems.Columns(8).Visible = True
                    gvitems.Columns(10).Visible = True

                    gvitems.DataSource = pitems
                    gvitems.DataBind()

                    gvitems.Columns(3).Visible = False
                    gvitems.Columns(4).Visible = False
                    gvitems.Columns(6).Visible = False
                    gvitems.Columns(7).Visible = False
                    gvitems.Columns(8).Visible = False
                    gvitems.Columns(10).Visible = False



                    For i As Integer = 0 To gvbody.Rows.Count - 1
                        Dim txt As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)
                        Dim txtcost As TextBox = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox)
                        If cbReinbursement.Checked = True Then
                            txtcost.Enabled = True
                            txtcost.Attributes.Add("onFocus", "this.select()")
                            txtcost.Attributes.Add("onClick", "this.select()")
                        Else
                            txtcost.Enabled = False
                        End If

                        txt.ReadOnly = False
                        txt.Attributes.Add("onFocus", "this.select()")
                        txt.Attributes.Add("onClick", "this.select()")
                        pBody.Rows(i)("Qty") = pBody.Rows(i)("Qty")
                    Next

                    '=== 05172016
                    For i As Integer = 0 To Me.pBody.Rows.Count - 1
                        If pBody.Rows(i)("GA_ID") = 794 Then
                            CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Enabled = True
                            CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = False
                        End If
                    Next

                    'Dim dtDoc As New DataTable
                    'dtDoc = objDerived.GetDataTable("SELECT * FROM AMS.DocumentAttachment WHERE TableName = 'PR' AND IdentityNo = '" & Session("prhdr_id") & "'", CommandType.Text)
                    'If dtDoc.Rows.Count < 5 Then
                    '    dtDoc.Merge(createdatatable9(4 - dtDoc.Rows.Count))
                    'End If
                    'grdocumentdetails.DataSource = dtDoc
                    'grdocumentdetails.DataBind()



                    btnSave.Enabled = True
                    btnAddlist.Enabled = True
                End If
            Catch ex As Exception
                msg.UserMsgBox(ex.ToString, Me, False)
            End Try
        End If
    End Sub
    Protected Sub gvListPR_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvListPR.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(gvListPR, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub LinkButton1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "PR"
    End Sub
    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "ObR"
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "edit"
    End Sub
    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "cancel"
    End Sub
    Protected Sub btnBuildingBrowse_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.btnAddlist.Enabled = True
    End Sub
    Protected Sub btnAddlist_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim filePath As String = hdfbuilding.Value
        Dim filename As String = Path.GetFileName(filePath)
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
        br.Close()
        fs.Close()

        If Me.hdfbuilding.Value <> "" Then
            ImageDocument.IdentityNo = Session("prhdr_id") 'Session("ppmp_hdr_id")
            ImageDocument.Imagefile = bytes
            ImageDocument.DocumentName = txtDocumentname.Text
            ImageDocument.DocumentNo = txtdocumentno.Text
            ImageDocument.ValidatedBy = txtvalidatedby.Text

            If txtdatevalidated.Text = "" Then
                ImageDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
            Else
                ImageDocument.DateValidated = txtdatevalidated.Text
            End If
            ImageDocument.Remarks = txtdocremarks.Text
            ImageDocument.TableName = "PR"
            Dim Id As Long = ImageDocument.SaveImage()
            imgPRAttachDoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & Id
            ' imgbuilding.ImageUrl = "~/Handler/ShowImage.ashx?id=" & ID

        End If

        txtDocumentname.Text = ""
        txtdocumentno.Text = ""
        txtdatevalidated.Text = ""
        txtdocremarks.Text = ""
        txtvalidatedby.Text = ""

        Dim AttachDocument As New DataTable
        AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = '" & Session("prhdr_id") & "' and TableName like 'PR'", CommandType.Text)

        Dim rows As New Integer
        rows = AttachDocument.Rows.Count
        AttachDocument.Merge(createdatatable9(4 - rows))
        grdocumentdetails.DataSource = AttachDocument
        grdocumentdetails.DataBind()
        grdocumentdetails.SelectedIndex = 0

    End Sub
    Protected Sub grdocumentdetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim ImageId As New Integer
            ImageId = grdocumentdetails.SelectedDataKey(1).ToString
            imgPRAttachDoc.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & ImageId
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub grdocumentdetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdocumentdetails.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdocumentdetails, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

#Region "REMOVED"

    '    Protected Sub txtcost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Try
    '            Dim txtcost As TextBox = TryCast(sender, TextBox)
    '            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
    '            If txtcost.Text = "" Then
    '                txtcost.Text = "0.00"
    '            End If
    '            txtcost.Text = FormatNumber(txtcost.Text, 2)
    '            pitems.Rows(gvr.RowIndex)("price") = txtcost.Text
    '            CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox).Text, Decimal) * CType(txtcost.Text, Decimal), 2)
    '            pitems.Rows(gvr.RowIndex)("total") = CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
    '            'pitems.Rows(gvr.RowIndex)("Qty") = CType(txtqty.Text, Decimal)
    '            CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pitems.Compute("sum(total)", ""), 2)
    '            If CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = "0.00" Then
    '                btnSave.Enabled = False
    '            Else
    '                btnSave.Enabled = True
    '            End If
    '            Dim txtqty As TextBox = CType(gvbody.Rows(gvr.RowIndex + 1).FindControl("txtqty"), TextBox)
    '            txtqty.Attributes.Add("onFocus", "this.select()")
    '            txtqty.Attributes.Add("onClick", "this.select()")
    '            txtqty.Focus()
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Protected Sub lnkview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Lbtn = "print"
    '    End Sub
    '    Protected Sub lnkview2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Lbtn = "print"
    '    End Sub
    '    Protected Sub SearchBut_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        gvitems.Columns(3).Visible = True
    '        gvitems.Columns(4).Visible = True
    '        gvitems.Columns(5).Visible = True
    '        gvitems.Columns(6).Visible = True
    '        gvitems.Columns(7).Visible = True
    '        gvitems.Columns(8).Visible = True
    '        gvitems.Columns(10).Visible = True
    '        'gvitems.Columns(9).Visible = True
    '        gvitems.DataSource = objDerived.Search(pitems, "item_desc", SearchBut.Text)
    '        gvitems.DataBind()
    '        gvitems.Columns(3).Visible = False
    '        gvitems.Columns(4).Visible = False
    '        'gvitems.Columns(5).Visible = False
    '        gvitems.Columns(6).Visible = False
    '        gvitems.Columns(7).Visible = False
    '        gvitems.Columns(8).Visible = False
    '        gvitems.Columns(10).Visible = False
    '        'gvitems.Columns(9).Visible = False
    '        gvitems.PageIndex = 0
    '    End Sub
    '    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Lbtn = "Approve"
    '    End Sub
    '    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Lbtn = "DisApprove"
    '    End Sub
    '    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click

    '    End Sub
    '    Protected Sub ddrc2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddrc2.SelectedIndexChanged
    '        ddFunction2.Items.Clear()

    '        If ddrc2.SelectedItem.Text = "Select" Then
    '            pFunction = Nothing
    '            ddFunction2.DataSource = pFunction
    '            ddFunction2.DataBind()
    '            ddFunction2.Items.Add("Select")
    '        Else
    '            pFunction = objDerived.GetDataTable("exec FMIS_SM.dbo.sp_get_rc_by_role1 '" & Session("RoleName") & "','" & ddrc2.SelectedItem.Value & "'", CommandType.Text)

    '            ddFunction2.Items.Add("Select")

    '            ddFunction2.DataSource = pFunction
    '            ddFunction2.DataTextField = ("Function_Desc")
    '            ddFunction2.DataValueField = ("Function_ID")
    '            ddFunction2.DataBind()
    '            ddFunction2.Enabled = True
    '            ddrc2.Enabled = False

    '        End If


    '        PAPS = Nothing
    '        ddPAPS2.DataSource = PAPS
    '        ddPAPS2.DataBind()
    '        ddPAPS2.Items.Add("Select")
    '        ddPAPS2.SelectedIndex = -1
    '    End Sub
    '    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '        If pRoleName.Rows(0)("RC_ID") = 18 And pRoleName.Rows(0)("Function_ID") = 86 Then '' infra
    '            Dim ppmpstatus As Boolean
    '            ppmpstatus = CType(objDerived.GetValue("select top 1 fromPPMP from ams.ppmp_status", CommandType.Text), Boolean)
    '            ''Remove 01/07/2014
    '            'If ppmpstatus = True Then
    '            '    cbPPMP.Checked = True
    '            '    cbPPMP.Visible = False
    '            '    lblppmp.Visible = False
    '            'Else
    '            '    cbPPMP.Checked = False
    '            '    cbPPMP.Visible = False
    '            '    lblppmp.Visible = False

    '            'End If
    '            ''Remove 01/07/2014
    '            ' MultiView1.SetActiveView(ViewForDepartment)

    '            MultiView2.SetActiveView(viewPublicInfra)
    '            txtprdate2.Text = Year(CDate(txtprdate.Text))
    '            pRC = objDerived.GetDataTable("exec FMIS_SM.dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
    '            ddrc2.DataSource = CType(pRC, DataTable)
    '            ddrc2.DataTextField = ("rc_name")
    '            ddrc2.DataValueField = ("rc_id")
    '            ddrc2.DataBind()
    '            pBody = Nothing
    '            p_GA_ID = Nothing
    '            gvbody.DataSource = createdatatable1(19)
    '            gvbody.DataBind()
    '            'btnsave.ValidationGroup = "saveInfra"
    '            ddrc2.Enabled = True
    '            btnpreview.Enabled = False
    '            btnSave.Enabled = False
    '            ddPAPS2.Enabled = False
    '            If rbTrans.SelectedIndex = 0 Then
    '                cbReinbursement.Checked = False
    '                RequiredFieldValidator13.Enabled = False
    '                RequiredFieldValidator14.Enabled = False
    '                txtpeyee2.Enabled = False
    '                txtaddpeyee2.Enabled = False
    '            Else
    '                RequiredFieldValidator13.Enabled = True
    '                RequiredFieldValidator14.Enabled = True
    '                txtpeyee2.Enabled = True
    '                txtaddpeyee2.Enabled = True
    '                cbReinbursement.Checked = True
    '                ' ModalPopupExtender6.Show()
    '            End If
    '        ElseIf pRoleName.Rows(0)("RC_ID") = 1 And pRoleName.Rows(0)("Function_ID") = 22 Then '' DF
    '            Dim ppmpstatus As Boolean
    '            ppmpstatus = CType(objDerived.GetValue("select top 1 fromPPMP from ams.ppmp_status", CommandType.Text), Boolean)
    '            ''Remove 01/07/2014
    '            'If ppmpstatus = True Then
    '            '    cbPPMP.Checked = True
    '            '    cbPPMP.Visible = False
    '            '    lblppmp.Visible = False
    '            'Else
    '            '    cbPPMP.Checked = False
    '            '    cbPPMP.Visible = False
    '            '    lblppmp.Visible = False

    '            'End If
    '            ''Remove 01/07/2014
    '            ' MultiView1.SetActiveView(ViewForDepartment)
    '            MultiView2.SetActiveView(viewPublicInfra)
    '            txtprdate2.Text = Year(CDate(txtprdate.Text))
    '            pRC = objDerived.GetDataTable("exec FMIS_SM.dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
    '            ddrc2.DataSource = CType(pRC, DataTable)
    '            ddrc2.DataTextField = ("rc_name")
    '            ddrc2.DataValueField = ("rc_id")
    '            ddrc2.DataBind()
    '            pBody = Nothing
    '            p_GA_ID = Nothing
    '            gvbody.DataSource = createdatatable1(19)
    '            gvbody.DataBind()
    '            'btnsave.ValidationGroup = "saveInfra"
    '            ddrc2.Enabled = True
    '            btnpreview.Enabled = False
    '            btnSave.Enabled = False
    '            ddPAPS2.Enabled = False
    '            If rbTrans.SelectedIndex = 0 Then
    '                cbReinbursement.Checked = False
    '                RequiredFieldValidator13.Enabled = False
    '                RequiredFieldValidator14.Enabled = False
    '                txtpeyee2.Enabled = False
    '                txtaddpeyee2.Enabled = False
    '            Else
    '                RequiredFieldValidator13.Enabled = True
    '                RequiredFieldValidator14.Enabled = True
    '                txtpeyee2.Enabled = True
    '                txtaddpeyee2.Enabled = True
    '                cbReinbursement.Checked = True
    '                'ModalPopupExtender6.Show()
    '            End If
    '        Else '' normal office
    '            Dim ppmpstatus As Boolean
    '            ppmpstatus = CType(objDerived.GetValue("select top 1 fromPPMP from ams.ppmp_status", CommandType.Text), Boolean)
    '            ''Remove 01/07/2014
    '            'If ppmpstatus = True Then
    '            '    cbPPMP.Checked = True
    '            '    cbPPMP.Visible = False
    '            '    lblppmp.Visible = False
    '            'Else
    '            '    cbPPMP.Checked = False
    '            '    cbPPMP.Visible = False
    '            '    lblppmp.Visible = False

    '            'End If
    '            ''Remove 01/07/2014
    '            ' MultiView1.SetActiveView(ViewForDepartment)
    '            MultiView2.SetActiveView(viewGoods)
    '            '  txtprdate1.Text = Date.Today.ToString("MM/dd/yyyy")
    '            pRC = objDerived.GetDataTable("exec FMIS_SM.dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
    '            ddRC.DataSource = CType(pRC, DataTable)
    '            ddRC.DataTextField = ("rc_name")
    '            ddRC.DataValueField = ("rc_id")
    '            ddRC.DataBind()
    '            ddFunction.Enabled = False
    '            ddPAPS.Enabled = False
    '            pBody = Nothing
    '            p_GA_ID = Nothing
    '            gvbody.DataSource = createdatatable1(19)
    '            gvbody.DataBind()
    '            'btnsave.ValidationGroup = "save"
    '            cbReinbursement.Enabled = False
    '            cbReinbursement.Checked = False
    '            LinkButton2.Enabled = False
    '            ddRC.Enabled = True
    '            ' ddFunction.Enabled = False
    '            btnpreview.Enabled = False
    '            btnSave.Enabled = False
    '            ddnature.Enabled = False
    '            If rbTrans.SelectedIndex = 0 Then
    '                cbReinbursement.Checked = False
    '                RequiredFieldValidator11.Enabled = False
    '                RequiredFieldValidator12.Enabled = False
    '                txtpeyee.Enabled = False
    '                txtaddpeyee.Enabled = False
    '            Else
    '                cbReinbursement.Checked = True
    '                RequiredFieldValidator11.Enabled = True
    '                RequiredFieldValidator12.Enabled = True
    '                txtpeyee.Enabled = True
    '                txtaddpeyee.Enabled = True
    '            End If
    '        End If
    '    End Sub
    '    Protected Sub ddTransactionType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddTransactionType.SelectedIndexChanged

    '    End Sub
    '    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

    '    End Sub
    '    Protected Sub ddAccounttitle2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddAccounttitle2.SelectedIndexChanged
    '    End Sub

    '    Protected Sub grdPrTablelist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '        Session("ppmp_hdr_id") = grdPrTablelist.SelectedDataKey(2)
    '        Dim dtPRtable As New DataTable

    '        If grdPrTablelist.SelectedDataKey("GA_ID") = 1060 Or grdPrTablelist.SelectedDataKey("GA_ID") = 1067 Then
    '            'LAND
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwland)

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 1082 Or grdPrTablelist.SelectedDataKey("GA_ID") = 1085 Then
    '            'BUILDING
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwBuilding)

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 533 Or grdPrTablelist.SelectedDataKey("GA_ID") = 535 Or grdPrTablelist.SelectedDataKey("GA_ID") = 540 Or grdPrTablelist.SelectedDataKey("GA_ID") = 543 Then
    '            'EQUIPMENTS
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwEquipment)

    '            grdlistofEuipment.DataSource = createdatatable4A(4)
    '            grdlistofEuipment.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 534 Then
    '            'FURNITURE AND FIXTURES
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwfurnitureandfixtures)

    '            grdfurnitureandfixtures.DataSource = createdatatable4A(4)
    '            grdfurnitureandfixtures.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 537 Then
    '            'MACHINERIES
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwmachiniries)

    '            grdpropertyListofmachinery.DataSource = createdatatable4A(4)
    '            grdpropertyListofmachinery.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 549 Then
    '            'MOTORS
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwMotorVehicle)

    '            grdlistofMotors.DataSource = createdatatable4A(4)
    '            grdlistofMotors.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 580 Then
    '            'Ambulance
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwAmbulance)

    '            grdListAmbulance.DataSource = createdatatable4A(4)
    '            grdListAmbulance.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 788 Or grdPrTablelist.SelectedDataKey("GA_ID") = 790 Or grdPrTablelist.SelectedDataKey("GA_ID") = 795 Or grdPrTablelist.SelectedDataKey("GA_ID") = 797 Then
    '            ' OFFICE SUPPLIES
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwofficesupplies)
    '            'dtPRtable = objDerived.GetDataTable("Exec dbo.sp_PRTable '" & grdPrTablelist.SelectedDataKey("GA_ID") & "','" & grdPrTablelist.SelectedDataKey("ppmp_hdr_id") & "'", CommandType.Text)
    '            'If dtPRtable.Rows.Count = 0 Then
    '            '    grdSupply.DataSource = createdatatableSupply(5)
    '            '    grdSupply.DataBind()
    '            'Else
    '            '    If dtPRtable.Rows.Count < 5 Then
    '            '        dtPRtable.Merge(createdatatableSupply(4 - dtPRtable.Rows.Count))
    '            '        grdSupply.DataSource = dtPRtable
    '            '        grdSupply.DataBind()
    '            '    Else
    '            '        grdSupply.DataSource = dtPRtable
    '            '        grdSupply.DataBind()
    '            '    End If
    '            'End If

    '            grdSupply.DataSource = createdatatableSupply(5)
    '            grdSupply.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 793 Or grdPrTablelist.SelectedDataKey("GA_ID") = 792 Then
    '            ' MEDICINES
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwSupply)

    '            grdSupply.DataSource = createdatatableSupply(5)
    '            grdSupply.DataBind()

    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 791 Or grdPrTablelist.SelectedDataKey("GA_ID") = 799 Or grdPrTablelist.SelectedDataKey("GA_ID") = 798 Or grdPrTablelist.SelectedDataKey("GA_ID") = 927 Then
    '            'Supplies
    '            Me.mvPurchasedetailedInfo.SetActiveView(Me.vwSupply)

    '            grdSupply.DataSource = createdatatableSupply(5)
    '            grdSupply.DataBind()

    '            If grdPrTablelist.SelectedDataKey("GA_ID") = 798 Then
    '                lblSuppB.Text = "Blood Type:"
    '                lblDetails.Text = "Blood Details"
    '            Else
    '                lblSuppB.Text = "Brand Name:"
    '                lblDetails.Text = "Supply Details"
    '            End If


    '        ElseIf grdPrTablelist.SelectedDataKey("GA_ID") = 0 Then
    '            ' NONE


    '        End If


    '        'If grdPrTablelist.SelectedDataKey(0) = 14 Then
    '        '    If grdPrTablelist.SelectedDataKey(1) = 793 Then
    '        '        mvPurchasedetailedInfo.SetActiveView(vwMedicalSupplies) ' MEDICAL SUPPLIES
    '        '    Else
    '        '        mvPurchasedetailedInfo.SetActiveView(vwofficesupplies) 'OFFICE
    '        '    End If
    '        'ElseIf grdPrTablelist.SelectedDataKey(0) = 34 Then  '' LAND
    '        '    mvPurchasedetailedInfo.SetActiveView(vwland)
    '        'ElseIf grdPrTablelist.SelectedDataKey(0) = 35 Then '' BUILDING
    '        '    mvPurchasedetailedInfo.SetActiveView(vwBuilding)
    '        'ElseIf grdPrTablelist.SelectedDataKey(0) = 36 Then ''UNKNOWN
    '        '    '
    '        'ElseIf grdPrTablelist.SelectedDataKey(0) = 37 Then ''EQUIPMENT
    '        '    If grdPrTablelist.SelectedDataKey(1) = 534 Then
    '        '        grdfurnitureandfixtures.DataSource = createdatatable4A(4)
    '        '        grdfurnitureandfixtures.DataBind()
    '        '        mvPurchasedetailedInfo.SetActiveView(vwfurnitureandfixtures)
    '        '    Else
    '        '        ''EQUIPMENT 
    '        '        grdlistofEuipment.DataSource = createdatatable4A(3)
    '        '        grdlistofEuipment.DataBind()
    '        '        mvPurchasedetailedInfo.SetActiveView(vwEquipment)
    '        '    End If
    '        'ElseIf grdPrTablelist.SelectedDataKey(0) = 38 Then 'Machineries
    '        '    grdpropertyListofmachinery.DataSource = createdatatable4A(4)
    '        '    grdpropertyListofmachinery.DataBind()
    '        '    mvPurchasedetailedInfo.SetActiveView(vwmachiniries)
    '        'ElseIf grdPrTablelist.SelectedDataKey(0) = 39 Then ''Transportation
    '        '    'grdSearchwithpropertyno.DataSource = createdatatable11(4)
    '        '    'grdSearchwithpropertyno.DataBind()
    '        '    mvPurchasedetailedInfo.SetActiveView(vwMotorVehicle)
    '        'End If
    '        'Dim AttachDocument As New DataTable
    '        'AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & grdPrTablelist.SelectedDataKey(2) & " and TableName='PR'", CommandType.Text)
    '        'Dim rows As New Integer
    '        'rows = AttachDocument.Rows.Count
    '        'AttachDocument.Merge(createdatatable9(4 - rows))
    '        'grdPrTable.DataSource = AttachDocument
    '        'grdPrTable.DataBind()
    '        'imgattach.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & AttachDocument.Rows(0)("DocuID")

    '    End Sub
    '    Protected Sub grdPrTablelist_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdPrTablelist.PageIndexChanging
    '        'PRTable = objDerived.GetDataTable("Select * from AMS.vwTablePRPO where Cyear ='" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'order by prno", CommandType.Text)

    '        'If PRTable.Rows.Count < 5 Then
    '        '    PRTable.Merge(createdatatable10(5 - PRTable.Rows.Count))
    '        'End If
    '        'grdPrTablelist.PageIndex = e.NewPageIndex
    '        'grdPrTablelist.DataSource = PRTable
    '        'grdPrTablelist.DataBind()


    '        'grdPrTablelist.SelectedIndex = 1

    '        PRTable = objDerived.GetDataTable("Select * from AMS.vwTablePRPO where Cyear ='" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'order by prno", CommandType.Text)
    '        Dim rows As New Integer
    '        rows = PRTable.Rows.Count
    '        PRTable.Merge(createdatatable10(5 - rows))
    '        grdPrTablelist.PageIndex = e.NewPageIndex
    '        grdPrTablelist.DataSource = PRTable
    '        grdPrTablelist.DataBind()

    '        MvPurchaseRequest.SetActiveView(vwPrTable)
    '        mvPurchasedetailedInfo.SetActiveView(vwofficesupplies)
    '        Me.grdPrTable.DataSource = createdatatable9(4)
    '        grdPrTable.DataBind()

    '    End Sub
    '    Protected Sub grdPrTablelist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPrTablelist.RowDataBound
    '        If (e.Row.RowType = DataControlRowType.DataRow) Then
    '            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
    '            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
    '            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPrTablelist, "Select$" + e.Row.RowIndex.ToString()))
    '        End If

    '    End Sub
    '    Protected Sub grdPrTable_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPrTable.RowDataBound
    '        If (e.Row.RowType = DataControlRowType.DataRow) Then
    '            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPrTable, "Select$" + e.Row.RowIndex.ToString()))
    '        End If
    '    End Sub
    '    Protected Sub grdPrTable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPrTable.SelectedIndexChanged
    '        Try
    '            Dim ImageId As New Integer
    '            ImageId = grdPrTable.SelectedDataKey(1).ToString

    '            imgattach.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & ImageId
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Protected Sub btnAttachdoc2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        ' Check if the Account is MOOE or Capital outlay
    '        Dim filePath As String = hdfAttachDoc2.Value
    '        Dim filename As String = Path.GetFileName(filePath)
    '        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
    '        Dim br As BinaryReader = New BinaryReader(fs)
    '        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
    '        br.Close()
    '        fs.Close()


    '        If Me.hdfAttachDoc2.Value <> "" Then

    '            ImageDocument.IdentityNo = Session("ppmp_hdr_id")
    '            ImageDocument.Imagefile = bytes
    '            ImageDocument.DocumentName = txtattachdocumentname.Text
    '            ImageDocument.DocumentNo = txtattachDocumentNo.Text
    '            ImageDocument.ValidatedBy = txtattachvalidatedby.Text

    '            If txtdatevalidated.Text = "" Then
    '                ImageDocument.DateValidated = Date.Today.ToString("MM/dd/yyyy")
    '            Else
    '                ImageDocument.DateValidated = txtattachdatevaidated.Text
    '            End If
    '            ImageDocument.Remarks = txtattachremarks.Text
    '            ImageDocument.TableName = "PR"
    '            Dim Id As Long = ImageDocument.SaveImage()
    '            imgattach.ImageUrl = "~/Handler/ShowDocumentImage.ashx?id=" & Id
    '            ' imgbuilding.ImageUrl = "~/Handler/ShowImage.ashx?id=" & ID
    '        End If
    '        '' Clear TextBox
    '        txtattachdocumentname.Text = ""
    '        txtattachDocumentNo.Text = ""
    '        txtattachvalidatedby.Text = ""
    '        txtattachdatevaidated.Text = ""
    '        txtattachremarks.Text = ""
    '        '' Clear TextBox
    '        Dim AttachDocument As New DataTable
    '        AttachDocument = objDerived.GetDataTable("Select * from AMS.DocumentAttachment where IdentityNo = " & Session("ppmp_hdr_id") & "and TableName='PR'", CommandType.Text)
    '        Dim rows As New Integer
    '        rows = AttachDocument.Rows.Count
    '        AttachDocument.Merge(createdatatable9(4 - rows))
    '        Me.grdPrTable.DataSource = AttachDocument
    '        grdPrTable.DataBind()
    '    End Sub
    '    Protected Sub btnOKRep_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Try
    '            For i As Integer = 0 To Me.grdPRRepair.Rows.Count - 1
    '                Dim dtl As New DataTable

    '                'objRep_Dtl.RepairDtl_ID = ""
    '                objRep_Dtl.RepairMaintenanceId = grdPRRepair.DataKeys(i).Item("RepairMaintenanceId")
    '                objRep_Dtl.Item_ID = Session("Item_ID")
    '                objRep_Dtl.Qty = CType(CType(grdPRRepair.Rows(i).FindControl("txtRepQty"), TextBox).Text, Integer) 'CType(txtRepQty.Text, Integer)
    '                objRep_Dtl.Price = Session("cost")

    '                dtl = objDerived.GetDataTable("select RepairDtl_ID from AMS.TbRepair_Dtl where RepairMaintenanceId ='" & grdPRRepair.DataKeys(i).Item("RepairMaintenanceId") & "' and Item_ID ='" & Session("Item_ID") & "'", CommandType.Text)

    '                If dtl.Rows.Count = 0 Then
    '                    objRep_Dtl.save()
    '                Else
    '                    objRep_Dtl.RepairDtl_ID = dtl.Rows(0)("RepairDtl_ID")
    '                    objRep_Dtl.update()
    '                End If
    '            Next
    '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Transaction has been successfully saved.")
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Protected Sub txtRepQty_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim txtRepQty As TextBox = TryCast(sender, TextBox)

    '        If txtRepQty.Text = "" Then
    '            txtRepQty.Text = 0
    '        End If

    '        If CType(txtRepQty.Text, Integer) > CType(lblqq.Text, Integer) Then
    '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Exceed for the available quantity.")
    '            btnOKRep.Enabled = False
    '        Else
    '            Dim x As Integer
    '            If CType(txtRepQty.Text, Integer) > CType(lblQty.Text, Integer) Then
    '                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel2, "Exceed for the available quantity.")
    '                btnOKRep.Enabled = False
    '            Else
    '                x = CType(lblQty.Text, Integer) - CType(txtRepQty.Text, Integer)
    '                lblQty.Text = x

    '                If lblQty.Text <> 0 Then
    '                    btnOKRep.Enabled = False
    '                Else
    '                    btnOKRep.Enabled = True
    '                End If
    '            End If
    '        End If

    '        ModalPopupExtender6.Show()
    '    End Sub
    '    Protected Sub grdPRRepair_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    End Sub
#End Region

    Protected Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (FileUpload1.HasFile) Then
            lblNoti.Visible = False
            If FileUpload1.FileName.ToLower.Contains(".jpg") Or FileUpload1.FileName.ToLower.Contains(".png") Or FileUpload1.FileName.ToLower.Contains(".doc") Or FileUpload1.FileName.ToLower.Contains(".rar") Or FileUpload1.FileName.ToLower.Contains(".zip") Or FileUpload1.FileName.ToLower.Contains(".pdf") Or FileUpload1.FileName.ToLower.Contains(".xls") Or FileUpload1.FileName.ToLower.Contains(".xlsx") Then
                If FileUpload1.PostedFile.ContentLength <= 25000000 Then
                    Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                    Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                    FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

                    objDerived.cmd.Parameters.AddWithValue("@Attch_ID", 0)
                    objDerived.cmd.Parameters.AddWithValue("@Stage", "Purchase Request")
                    objDerived.cmd.Parameters.AddWithValue("@ID", Session("prhdr_id"))
                    objDerived.cmd.Parameters.AddWithValue("@DateUploaded", Date.Today.ToString("MM/dd/yyyy"))
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFilename", fi.Name)
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFile", imageBytes)
                    objDerived.cmd.Parameters.AddWithValue("@DocumentName", txtDocName.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DocumentNo", txtDocNumb.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)
                    objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
                    objDerived.Execute("@CurrID", "[AMS].[spSave_Tb_Attachment]", CommandType.StoredProcedure, Nothing)

                    msg.UserMsgBox("File has been uploaded.", Me, False)
                    'LoadDocumentList()
                Else
                    msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                End If
            Else
                msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
            End If
        Else
            lblNoti.Visible = True
        End If
    End Sub
End Class
