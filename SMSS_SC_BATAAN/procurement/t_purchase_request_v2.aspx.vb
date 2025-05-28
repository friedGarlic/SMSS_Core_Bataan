Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.IO
Imports System.Object
Imports System.Web.UI.Control
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebControl
Imports System.Web.UI.WebControls.FileUpload

Partial Class t_purchase_request_v2
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private CAA_hdr As New t_purchase_request_obr_hdr
    Private CAA_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement

    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim image As New Image
    Dim ImageDocument As New ImageDocument
    Dim dtRep As New DataTable
    Dim Doc_ID As Integer
    Dim FName As String

    Public Property IsNonPPMP As Boolean
    Public Property NonPPMPJustification As String





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
        dt.Columns.Add("Return_Remarks", GetType(String))
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
            dr("Return_Remarks") = DBNull.Value
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
        dt.Columns.Add("DocumentID", GetType(Long))
        dt.Columns.Add("DocumentName", GetType(String))
        dt.Columns.Add("AttachedFilename", GetType(String))
        dt.Columns.Add("DocumentNo", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("DocumentID") = DBNull.Value
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


                btnpreview.Enabled = False
                btnSave.Enabled = False
                UploadButton.Enabled = True
                FileUpload1.Enabled = True


                grdDocuments.DataSource = CreateTable_Attachment(4)
                grdDocuments.DataBind()



                Session("Edit") = 0
                Session("edit_pr") = False


                ' Clear existing items
                rbTrustFund.Items.Clear()

                ' Get fund data from database
                Dim dtFunds As DataTable = objDerived.GetDataTable("SELECT [F_ID], [Description] FROM [GeoBOS].[BOS].[m_Fund] ORDER BY [F_ID]", CommandType.Text)

                ' Populate the DropDownList
                For Each row As DataRow In dtFunds.Rows
                    rbTrustFund.Items.Add(New ListItem(row("Description").ToString(), row("F_ID").ToString()))
                Next

                ' Set default selected item if needed
                If rbTrustFund.Items.Count > 0 Then
                    rbTrustFund.SelectedValue = "1" ' Default to first item or specific F_ID
                End If

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
        AddTrace(rbTrustFund.SelectedItem.Value)
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

            'ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND office_name in ('OFFICE OF THE PROVINCIAL GOVERNOR','OFFICE OF THE PROVINCIAL ADMINISTRATOR') ORDER BY deptid", CommandType.Text)
            ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE  division_key = 86 AND isDeptHead = 'yes'AND isActive = 1 and position_desc = 'Vice Governor' or position_desc = 'Governor'", CommandType.Text)


            ddApprovedBy.DataTextField = ("full_name")
            ddApprovedBy.DataValueField = ("empid")
            ddApprovedBy.DataBind()



            'Try
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

                PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_With_OOE " & Me.ddRC.SelectedItem.Value & ",'" & Year(CDate(txtprdate.Text)) & "'," & ddFunction.SelectedItem.Value & ",0," & rbTrustFund.SelectedItem.Value & "", CommandType.Text)
                ddPAPS.DataSource = PAPS
                ddPAPS.DataTextField = ("description")
                ddPAPS.DataValueField = ("Project_ID")
                ddPAPS.DataBind()
                ddPAPS.Items.Insert(0, "Select")


                LoadPRList_PerRC()

            End If

            'Catch ex As Exception
            'End Try

        End If

    End Sub

    Protected Sub LoadPRList_PerRC()
        If RadioButtonList1.SelectedIndex = 0 Then
            AddTrace(rbTrustFund.SelectedValue)
            If rbTrustFund.SelectedValue = 3 Then
                pPRlist = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_ForEditingList] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' AND isContinuing = 0 AND isTrustFund = 1", CommandType.Text)
            Else
                pPRlist = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_ForEditingList] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' AND isContinuing = 0 AND isTrustFund = 0", CommandType.Text)

            End If
        Else

            If rbTrustFund.SelectedValue = 3 Then
                pPRlist = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_ForEditingList] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' AND isContinuing = 1 AND isTrustFund = 1", CommandType.Text)
            Else
                pPRlist = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PR_ForEditingList] WHERE RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_id = '" & ddFunction.SelectedItem.Value & "' AND isContinuing = 1", CommandType.Text)

            End If

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
            Dim query As String = "SELECT * FROM SomeTable WHERE Nature = '" & ddnature.SelectedValue.ToString() &
                      "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value &
                      "' and Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' and Program_id = '" &
                      PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' and CYear = '" & Year(CDate(txtprdate.Text)) & "'"

            AddTrace("Executing SQL Query: " & query)



            If pAccounts.Rows.Count = 0 Then
                ' Display or log message indicating no rows were returned
                pAccounts = objDerived.GetDataTable("SELECT DISTINCT GA_Title, CONVERT(VARCHAR(20),GA_CODE2) AS GA_CODE2,GA_ID  from AMS.vw_Ga_Title where AllotmentClass_ID = '" & ddnature.SelectedValue.ToString & "' and RC_ID = '" & ddRC.SelectedItem.Value & "' and Function_ID = '" & ddFunction.SelectedItem.Value & "' and CYear = '" & Year(CDate(txtprdate.Text)) & "'", CommandType.Text)

            End If

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

        Dim A = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
        Dim B = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
        Dim hasReleased As New Boolean
        If RadioButtonList1.SelectedIndex = 0 Then
            '====== CURRENT RELEASE

            hasReleased = IIf(IsDBNull(objDerived.GetValue("SELECT TOP 1 LBEF_2_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Hdr WHERE Budget_Year = '" & Year(CDate(txtprdate.Text)) & "' AND RC_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' AND Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' ", CommandType.Text)),
                              0, objDerived.GetValue("SELECT TOP 1 LBEF_2_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Hdr WHERE Budget_Year = '" & Year(CDate(txtprdate.Text)) & "' AND RC_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "' AND Project_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "' ", CommandType.Text))

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
                Dim prj As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                Dim prg As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_ID")
                ' Log the values before executing the stored procedure
                AddTrace("Year(CDate(txtprdate.Text)): " & Year(CDate(txtprdate.Text)))
                AddTrace("ddRC.SelectedItem.Value: " & ddRC.SelectedItem.Value)
                AddTrace("ddFunction.SelectedItem.Value: " & ddFunction.SelectedItem.Value)
                AddTrace("PAPS.Rows(ddPAPS.SelectedIndex - 1)(Project_ID): " & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID"))
                AddTrace("PAPS.Rows(ddPAPS.SelectedIndex - 1)(Program_id): " & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id"))
                AddTrace("isGasoline: " & isGasoline)
                AddTrace("GA_ID: " & GA_ID)
                AddTrace("BGA_ID: " & BGA_ID)


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

                chkNonPPMP.Checked = True
                NonPPMPItems()
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The selected account may have no PPMP or saved without goods.")
            Else
                Session("ppmp_hdr_id") = pitems.Rows(0)("ppmp_hdr_id")
                chkNonPPMP.Checked = False
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

            pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
            gvBudgetInfo2.DataSource = pBudgetInfo
            gvBudgetInfo2.DataBind()

            gvbody.DataSource = createdatatable1(19)
            gvbody.DataBind()


            Session("Accounts") = ddAccounts.SelectedValue
        End If

    End Sub

    Public Sub NonPPMPItems()

        'Make several columns visible temporarily for data binding.
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True
        gvitems.Columns(7).Visible = True
        gvitems.Columns(8).Visible = True
        gvitems.Columns(10).Visible = True

        Dim GA_ID As Integer
        Dim BGA_ID As Integer
        'Retrieve GA_ID and BGA_ID based on the selected GA_Code2.
        GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
        BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
        AddTrace("Button5_Click() called in EDIT mode. GAID = " & GA_ID)
        Dim isGasoline As Boolean = False

        If GA_ID = 0 Then
            GA_ID = Session("GA_ID")
            AddTrace("GA_ID = 0, Updated GA_ID = " & GA_ID)

        End If

        If chkNonPPMP.Checked Then
            ' For Non-PPMP Purchase Request:
            ' Call the new stored procedure that returns all items for the given GA_ID and Search term.
            pitems = objDerived.GetDataTable("EXEC [AMS].[sp_supplies_for_pr_NONPPMP_SEARCH] " & GA_ID & ", '" & SearchBut.Text & "'", CommandType.Text)
            LinkButton2.Enabled = True
            lbmeals.Enabled = False
        Else
            'For PPMP-based Purchase Request:
            If ddnature.SelectedIndex = 1 Then
                If Session("Edit") = 1 Then
                    pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2_SEARCH] '" &
                    Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" &
                    datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & 0 & "','" &
                    datahdr.Rows(0)("isContinuing") & "','" & Session("GA_ID") & "','" & SearchBut.Text & "'", CommandType.Text)
                Else
                    pitems = objDerived.GetDataTable("EXEC [AMS].[sp_supplies_for_pr_SEARCH] '" &
                    Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" &
                    PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" &
                    isGasoline & "',0, '" & GA_ID & "','" & BGA_ID & "','" & SearchBut.Text & "'", CommandType.Text)
                End If
            ElseIf ddnature.SelectedIndex = 2 Then
                If Session("Edit") = 1 Then
                    Session("GA_Code2") = objDerived.GetValue("SELECT GA_Code2 FROM AMS.View_AccountList WHERE GA_ID = '" &
                    Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)
                    pitems = objDerived.GetDataTable("EXEC [AMS].[sp_ppe_for_pr_EDIT2_SEARCH]  '" &
                    Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" &
                    datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & Session("GA_Code2") & "','" &
                    datahdr.Rows(0)("isContinuing") & "','" & SearchBut.Text & "'", CommandType.Text)
                Else
                    pitems = objDerived.GetDataTable("EXEC [AMS].[sp_ppe_for_pr_SEARCH] '" &
                    Year(CDate(txtprdate.Text)) & "','" & ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" &
                    PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" &
                    ddAccounts.SelectedValue & "',0,'" & SearchBut.Text & "'", CommandType.Text)
                End If
            End If
        End If

        'Bind the result to gvitems.

        gvitems.DataSource = pitems
        gvitems.DataBind()

        'Reset the visibility of certain columns.
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
        gvitems.Columns(8).Visible = False
        gvitems.Columns(10).Visible = False

    End Sub


    Protected Sub txtpurpose_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtOBRpurpose.Text = txtpurpose.Text
    End Sub
    Protected Sub ddRequestedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtposition.Text = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND empid = '" & ddRequestedBy.SelectedItem.Value & "'", CommandType.Text)
    End Sub
    Protected Sub LinkButton2_Click1(ByVal sender As Object, ByVal e As System.EventArgs)

        If rbTrustFund.SelectedValue = 3 Then
            chkNonPPMP.Enabled = False

        End If
        ModalPopupExtender1.Show()

    End Sub

    Protected Sub chkNonPPMP_CheckedChanged(sender As Object, e As EventArgs)
        pnlNonPPMP.Visible = chkNonPPMP.Checked

        If chkNonPPMP.Checked Then
            pnlNonPPMP.Visible = True
        Else
            pnlNonPPMP.Visible = False
        End If


        Button5_Click(Nothing, Nothing)
    End Sub

    Protected Sub chkPurchasePerLot_CheckedChanged(sender As Object, e As EventArgs)

    End Sub




    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        NonPPMPItems()

        SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & Button5.ClientID & "')")

        'Reopen the modal popup.
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

        'OPTIMIZE CODE
        For Each columnIndex As Integer In {3, 4, 6, 7, 8, 10}
            gvitems.Columns(columnIndex).Visible = False
        Next


        ModalPopupExtender1.Show()

    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb2 As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb2.NamingContainer, GridViewRow)

        ' Assuming Cells(4) contains the Item_ID or a valid identifier for pitems.Rows
        Dim itemID As Integer
        If Integer.TryParse(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text, itemID) Then
            ' Now you can safely index pitems.Rows using itemID
            If cb2.Checked = True Then
                pitems.Rows(itemID)("isChecked") = True
            Else
                pitems.Rows(itemID)("isChecked") = False
            End If
        Else
            ' Handle the case where the conversion fails (empty or invalid data)
            AddTrace("Failed to convert value to Integer: " & Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)
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
    '--- New helper function exclusively for NON-PPMP merging ---
    Private Function MergeNonPPMPItems(ByVal pitems As DataTable, ByVal existingBody As DataTable) As DataTable
        Dim dt As DataTable
        ' For NON-PPMP, we ignore ppmp_dtl_id (set it always to 0)
        If existingBody Is Nothing Then
            dt = createdatatable1(0) ' Use the same structure
            dt.Rows.Clear()
        Else
            dt = existingBody
        End If

        For i As Integer = 0 To pitems.Rows.Count - 1
            Dim isChecked As Boolean = False
            If Not IsDBNull(pitems.Rows(i)("isChecked")) Then
                isChecked = CBool(pitems.Rows(i)("isChecked"))
            End If
            If isChecked Then
                Dim newRow As DataRow = dt.NewRow()
                newRow("id") = 1
                newRow("Item_Desc") = pitems.Rows(i)("Item_Desc")
                newRow("Description") = pitems.Rows(i)("Description")
                newRow("InputQty") = 0
                newRow("qty") = pitems.Rows(i)("qty")
                newRow("cost") = pitems.Rows(i)("cost")
                newRow("total") = CDec(pitems.Rows(i)("cost")) * CDec(pitems.Rows(i)("qty"))
                newRow("Item_ID") = pitems.Rows(i)("Item_ID")
                newRow("isVisible") = True
                newRow("ReadOnly") = False
                newRow("GA_ID") = pitems.Rows(i)("GA_ID")
                newRow("BGA_ID") = pitems.Rows(i)("BGA_ID")
                newRow("GA_Code2") = pitems.Rows(i)("GA_Code2")
                newRow("ppmp_dtl_id") = 0   ' For NON-PPMP, force 0
                dt.Rows.Add(newRow)
                pitems.Rows(i)("isUsed") = True
                pitems.Rows(i)("isChecked") = False
            End If
        Next
        Return dt
    End Function


    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            AddTrace("Button3_Click started.")
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.Columns(10).Visible = True
            AddTrace("gvitems columns 3,4,5,6,7,8,10 set to visible.")

            Dim dt, dt_GA_ID As New DataTable
            Dim dr As DataRow
            Dim cb As CheckBox

            'Dim x As Boolean = Session("edit_pr")
            'AddTrace("Session('edit_pr') = " & x.ToString())
            'If Session("edit_pr") Is Nothing Then
            '    Session("edit_pr") = False
            'End If

            Dim tempEditPR As Object = Session("edit_pr") ' Store the session value before assignment
            Dim x As Boolean = If(tempEditPR IsNot Nothing, CBool(tempEditPR), False)
            AddTrace("Session('edit_pr') before assignment: " & tempEditPR.ToString())
            AddTrace("Variable x assigned: " & x.ToString())




            ' --- Branch: Initialize pBody if Nothing ---
            If pBody Is Nothing Then
                AddTrace("pBody is Nothing. Initializing new DataTable for pBody.")
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
                ' (dt_GA_ID not used here)
                For i As Integer = 0 To Me.pitems.Rows.Count - 1
                    AddTrace("Processing pitems row " & i.ToString())
                    If chkNonPPMP.Checked Then
                        ' For NON-PPMP, use the new merge function.
                        ' (We’ll handle merging in the Else branch below.)
                    Else
                        ' (Existing PPMP branch initialization)
                        If Not IsDBNull(pitems.Rows(i)("isChecked")) AndAlso CBool(pitems.Rows(i)("isChecked")) = True Then
                            AddTrace("Row " & i.ToString() & " is checked. Adding new row with ppmp_dtl_id: " & pitems.Rows(i)("ppmp_dtl_id").ToString())
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
                        Else
                            AddTrace("Row " & i.ToString() & " is not checked.")
                        End If
                    End If
                Next
                ' For NON-PPMP branch, if pBody is Nothing, call MergeNonPPMPItems:
                If chkNonPPMP.Checked Then
                    pBody = MergeNonPPMPItems(pitems, Nothing)
                Else
                    pBody = dt
                End If
                AddTrace("pBody initialized with " & pBody.Rows.Count.ToString() & " rows.")
            Else
                ' --- Branch: pBody is not Nothing; merging new items ---
                AddTrace("pBody is not Nothing. Merging new checked items into existing pBody.")
                If chkNonPPMP.Checked Then
                    ' Use the NON-PPMP merge function exclusively.
                    pBody = MergeNonPPMPItems(pitems, pBody)
                Else
                    Dim dr2 As DataRow
                    dt.Columns.Add("id", GetType(Long))
                    dt = pBody
                    For i As Integer = 0 To Me.pitems.Rows.Count - 1
                        AddTrace("Processing pitems row " & i.ToString() & " in merge branch.")
                        If Not IsDBNull(pitems.Rows(i)("isChecked")) AndAlso CBool(pitems.Rows(i)("isChecked")) = True Then
                            AddTrace("Row " & i.ToString() & " is checked.")
                            Session("x") = 0
                            For a As Integer = 0 To Me.pBody.Rows.Count - 1
                                Dim existingVal As Long = 0
                                Dim newVal As Long = 0
                                If Not IsDBNull(pBody.Rows(a)("ppmp_dtl_id")) Then
                                    existingVal = Convert.ToInt64(pBody.Rows(a)("ppmp_dtl_id"))
                                End If
                                If Not IsDBNull(pitems.Rows(i)("ppmp_dtl_id")) Then
                                    newVal = Convert.ToInt64(pitems.Rows(i)("ppmp_dtl_id"))
                                End If
                                If existingVal = newVal Then
                                    Session("x") = 1
                                    AddTrace("Duplicate found for ppmp_dtl_id: " & newVal.ToString() & " at pBody row " & a.ToString())
                                End If
                            Next
                            If Session("x") = 0 Then
                                AddTrace("No duplicate found for row " & i.ToString() & ". Adding new row with ppmp_dtl_id: " & pitems.Rows(i)("ppmp_dtl_id").ToString())
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
                            Else
                                AddTrace("Skipping row " & i.ToString() & " because it already exists in pBody.")
                            End If
                        Else
                            AddTrace("Row " & i.ToString() & " is not checked.")
                        End If
                    Next
                End If
            End If

            gvbody.DataSource = pBody
            gvbody.DataBind()
            AddTrace("gvbody DataBind complete with " & pBody.Rows.Count.ToString() & " rows.")

            Dim myview As DataView = pitems.DefaultView
            myview.RowFilter = "isUsed = false"
            gvitems.DataSource = myview
            gvitems.DataBind()
            AddTrace("gvitems DataBind complete with filter isUsed = false.")

            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False
            gvitems.Columns(10).Visible = False

            If Session("edit_pr") = False Then
                AddTrace("Entering non-edit_pr branch.")
                If pBody.Compute("sum(total)", "") = "0.00" Then
                    AddTrace("Computed sum(total) is 0.00")
                    CType(gvbody.FooterRow.Cells(6).FindControl("lbltotal"), Label).Text = "0.00"
                Else
                    AddTrace("Computed sum(total) is " & pBody.Compute("sum(total)", "").ToString())
                    CType(gvbody.FooterRow.Cells(6).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                End If

                For i As Integer = 0 To Me.pBody.Rows.Count - 1
                    If pBody.Rows(i)("GA_ID") = 794 Then
                        AddTrace("Row " & i.ToString() & " has GA_ID 794. Enabling cost textbox for update.")
                        CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = False
                    End If
                Next

                'Session("edit_pr") = False
            Else
                AddTrace("Entering edit_pr branch.")
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    Dim Total As Decimal = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text * CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                    CType(gvbody.Rows(i).FindControl("lbltotal"), Label).Text = FormatNumber(Total, 2)
                    AddTrace("Row " & i.ToString() & " recalculated total: " & Total.ToString())
                    If pBody.Rows(i)("GA_ID") = 794 Then
                        AddTrace("Row " & i.ToString() & " has GA_ID 794. Enabling cost textbox for update.")
                        CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = False
                    End If
                Next
                If pBody.Compute("sum(total)", "") = "0.00" Then
                    AddTrace("Computed sum(total) in edit_pr branch is 0.00")
                    CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = "0.00"
                Else
                    AddTrace("Computed sum(total) in edit_pr branch is " & pBody.Compute("sum(total)", "").ToString())
                    CType(gvbody.FooterRow.Cells(7).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                End If
                'Session("edit_pr") = True
                'Session("edit_pr") = False
            End If

            btnSave.Enabled = True
            AddTrace("btnSave enabled.")
        Catch ex As Exception
            AddTrace("Exception in Button3_Click: " & ex.Message)
        End Try

        Me.ModalPopupExtender1.Show()
        LinkButton2.Enabled = True
        AddTrace("ModalPopupExtender1 shown and LinkButton2 enabled.")
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
                    txtcost.Enabled = True
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

                'Session("edit_pr") = True
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

            ' If chkNonPPMP is checked, allow the user to enter any quantity and amount without restriction
            If chkNonPPMP.Checked Then
                AddTrace("chkNonPPMP is checked. Allowing unrestricted quantity entry.")

                ' Calculate total for non-PPMP PR without any restrictions
                CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text = FormatNumber(CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal) * CType(txtqty.Text, Decimal), 2)

                pBody.Rows(gvr.RowIndex)("total") = CType(gvbody.Rows(gvr.RowIndex).FindControl("lbltotal"), Label).Text
                pBody.Rows(gvr.RowIndex)("InPutQty") = CType(txtqty.Text, Decimal)

                CType(gvbody.Rows(gvr.RowIndex).Cells(3).FindControl("lblBalance"), Label).Text = "-"

                CType(gvbody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

            Else
                ' Existing logic for editing or creating PR when chkNonPPMP is not checked
                AddTrace("chkNonPPMP is not checked. Enforcing quantity restrictions.")

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
            End If
        Catch ex As Exception
            AddTrace("Error in txtqty_TextChanged: " & ex.Message)
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
            LoadPRList_PerRC()
        End If
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Private Function SaveNonPPMPHeader() As Long


        If Me.Session("edit_pr") = True Then
            'Edit NON-PPMP PR
            AddTrace("Condition met: Session('edit_pr') = False => Creating new PR...")


            ' Log values before executing the stored procedure
            AddTrace("ddRC.SelectedItem.Value: " & Me.ddRC.SelectedItem.Value)
            AddTrace("ddFunction.SelectedItem.Value: " & ddFunction.SelectedItem.Value)
            AddTrace("ddnature.SelectedItem.Value: " & ddnature.SelectedItem.Value)
            AddTrace("Session(Project_ID): " & Session("Project_ID"))
            AddTrace("Session(program_id): " & Session("program_id"))
            AddTrace("Year(CDate(txtprdate.Text)): " & Year(CDate(txtprdate.Text)))
            AddTrace("Session(isContinuing): " & Session("isContinuing"))

            AddTrace("Session(prhdr_id): " & Session("prhdr_id"))


            ' Retrieve the correct GA_ID and BGA_ID from the database for this PR
            Dim oGA_ID As Integer = objDerived.GetValue("SELECT GA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
            Dim oBGA_ID As Integer = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)

            ' Handle Non-PPMP PR (GA_ID = 0)
            If oGA_ID = 0 Then
                AddTrace("GA_ID is 0, using View_PR_GABGA_NONPPMP to fetch GA_ID.")
                ' Tracing the query execution for the Non-PPMP view
                Dim query As String = "SELECT GA_ID FROM [dbo].[View_PR_GABGA_NONPPMP] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'"
                AddTrace("Executing query: " & query)
                oGA_ID = objDerived.GetValue(query, CommandType.Text)
                oBGA_ID = 0 ' For Non-PPMP, BGA_ID is not needed
                AddTrace("Fetched oGA_ID = " & oGA_ID)



                ' Indicate that this is a Non-PPMP PR
                AddTrace("This PR is a Non-PPMP PR. Proceeding with Non-PPMP logic.")

            End If

            ' If GA_ID/BGA_ID are still zero (meaning no record found in View_PR_GABGA), confirm the nature or handle fallback logic.
            AddTrace("Updated GA_ID from View_PR_GABGA = " & oGA_ID & ", BGA_ID = " & oBGA_ID)
            Session("GA_ID") = oGA_ID
            Session("BGA_ID") = oBGA_ID

            AddTrace("Session Updates = " & oGA_ID & ", BGA_ID = " & oBGA_ID)


            ' Execute the stored procedure and capture the budget value
            ' Build the SQL command string
            Dim sqlQuery As String = "EXEC [AMS].[sp_BudgetCheck_ForEditPR] '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddnature.SelectedItem.Value & "','" & Session("Project_ID") & "','" & Session("program_id") & "','" & Year(CDate(txtprdate.Text)) & "','" & Session("isContinuing") & "','" & oGA_ID & "','" & oBGA_ID & "','" & Session("prhdr_id") & "'"

            ' Log SQL query before execution
            AddTrace("Executing SQL: " & sqlQuery)

            ' Log parameter values individually
            AddTrace("ddRC.SelectedItem.Value: " & Me.ddRC.SelectedItem.Value)
            AddTrace("ddFunction.SelectedItem.Value: " & ddFunction.SelectedItem.Value)
            AddTrace("ddnature.SelectedItem.Value: " & ddnature.SelectedItem.Value)
            AddTrace("Session(Project_ID): " & Session("Project_ID"))
            AddTrace("Session(program_id): " & Session("program_id"))
            AddTrace("Year(txtprdate.Text): " & Year(CDate(txtprdate.Text)))
            AddTrace("Session(isContinuing): " & Session("isContinuing"))
            AddTrace("oGA_ID: " & oGA_ID)
            AddTrace("oBGA_ID: " & oBGA_ID)
            AddTrace("Session(prhdr_id): " & Session("prhdr_id"))

            ' Execute the stored procedure and get the budget value
            Dim budget As Decimal = Val(objDerived.GetValue(sqlQuery, CommandType.Text))

            ' Log the returned budget value
            AddTrace("Returned budget from sp_BudgetCheck_ForEditPR: " & budget)


            ' Compute and log ABC value
            Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)
            AddTrace("ABC (pBody sum of 'total'): " & ABC)

            ' Condition check and logging
            If budget < ABC Then
                AddTrace("Condition met: budget < ABC => Show error & exit.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "EditPR: PR amount exceeds from the available budget.")
                Exit Function
            End If

            'For Update and saving conflict
            Try
                AddTrace("Editing PR_Hdr => Session('prhdr_id') = " & gvListPR.SelectedDataKey(0))
                Session("PRNo") = gvListPR.SelectedDataKey(0)
                Session("prhdr_id") = gvListPR.SelectedDataKey(0)

            Catch ex As Exception
                AddTrace("Error on saving Editing PR_Hdr => Session('prhdr_id')")
            End Try

            Dim CTO As Integer
            AddTrace("Entering edit mode...")

            CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes' AND isActive = 1", CommandType.Text)
            AddTrace("CTO (edit mode) = " & CTO)

            Try
                ' Get the value of isPerLot based on the checkbox
                Dim isPerLotValue As Integer = If(chkPurchasePerLot.Checked, 1, 0)
                AddTrace("Updating AMS.PR_Hdr: isPerLot = " & isPerLotValue)

                ' Construct the update query with isPerLot included
                Dim updateQuery As String = "UPDATE ams.pr_hdr SET ABC = '" & pBody.Compute("sum(total)", "") & "', " &
                                "remarks = '" & replaceapostrophe(txtpurpose.Text) & "', " &
                                "Requestedby = '" & ddRequestedBy.SelectedItem.Value & "', " &
                                "CityTreasurer = '" & CTO & "', " &
                                "isPerLot = '" & isPerLotValue & "' " &
                                "WHERE prhdr_id='" & gvListPR.SelectedDataKey(0) & "'"

                Dim updateQueryBOSS As String = "UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET OBR_Title = '" & replaceapostrophe(txtOBRpurpose.Text) & "' " &
                                "WHERE PRHdr_ID = '" & gvListPR.SelectedDataKey(0) & "'"


                ' Tracing the update query string
                AddTrace("Generated Update Query: " & updateQuery)

                ' Executing the update query
                objDerived.GetRecords(updateQuery, CommandType.Text)
                objDerived.GetRecords(updateQueryBOSS, CommandType.Text)

                ' Tracing successful execution
                AddTrace("Executed: UPDATE ams.pr_hdr in edit mode with isPerLot = " & isPerLotValue)

            Catch ex As Exception
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Server Error, Please try again later.")
            End Try







            '======== PR_Dtl Edit ======== 
            Dim origcount As Integer = Me.Session("row_num_edit")
            AddTrace("origcount (row_num_edit) = " & origcount)

            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                AddTrace("Row index: " & i & " in edit PR mode.")
                Dim qty As Decimal = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text()
                Dim cost As Decimal = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                Dim PRSpecs As String = CType(gvbody.Rows(i).FindControl("txtremarks"), TextBox).Text
                Dim dtPRdtl As New DataTable

                dtPRdtl = objDerived.GetDataTable("Select * from AMS.PR_Dtl where prhdr_id = '" & Session("prhdr_id") & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                AddTrace("dtPRdtl count for item_id=" & pBody.Rows(i)("Item_ID") & " => " & dtPRdtl.Rows.Count)

                If dtPRdtl.Rows.Count = 0 Then
                    AddTrace("No existing record => INSERT into AMS.PR_Dtl")
                    objDerived.Execute("INSERT INTO AMS.PR_Dtl (PRHdr_ID,Item_ID,Project_title,Qty,Cost,ppmp_dtl_id,PR_ItemSpecs) values('" & gvListPR.SelectedDataKey(0) & "','" & pBody.Rows(i)("Item_ID") & "','" & txtpurpose.Text & "','" & qty & "','" & cost & "','" & pBody.Rows(i)("ppmp_dtl_id") & "','" & PRSpecs & "')", CommandType.Text)
                Else
                    AddTrace("Record exists => UPDATE AMS.PR_Dtl")
                    objDerived.GetRecords("Update AMS.PR_Dtl set Qty ='" & qty & "', Project_title = '" & txtpurpose.Text & "', Cost = '" & cost & "', PR_ItemSpecs = '" & PRSpecs & "' where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                End If
            Next

            AddTrace("Finished looping PR_Dtl => OBR editing commented out in code...")

            pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Session("Project_ID") & "','" & Session("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
            gvBudgetInfo2.DataSource = pBudgetInfo
            gvBudgetInfo2.DataBind()

            Session("edit_pr") = False
            AddTrace("Set Session('edit_pr')=False => Done editing.")

            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET IsNonPPMP = '" & chkNonPPMP.Checked & "', NonPPMPJustification = '" & txtNonPPMPJustification.Text.Trim() & "' WHERE prhdr_id = " & gvListPR.SelectedDataKey(0), CommandType.Text)
            AddTrace("Updated AMS.PR_Hdr => IsNonPPMP, NonPPMPJustification in edit mode.")




        Else

            'Saving PR


            AddTrace("Saving Non-PPMP PR Header...")


            AddTrace("Session('edit_pr') value: " & Session("edit_pr"))

            ' Create PR Header for Non-PPMP PR
            Dim prhdr As New t_purchase_request_hdr
            prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
            prhdr.PR_Date = If(CDate(txtprdate.Text) >= #1/1/1753#, txtprdate.Text, "01/01/1900") ' Ensure valid date range
            prhdr.RC_ID = ddRC.SelectedItem.Value
            prhdr.Function_ID = ddFunction.SelectedItem.Value
            prhdr.remarks = txtpurpose.Text
            prhdr.Transaction_type = ddnature.SelectedItem.Value

            If ddPAPS.SelectedIndex > 0 Then
                prhdr.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                prhdr.Program_id = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
            Else
                ' Handle the case where no valid selection is made
                AddTrace("No valid selection made in ddPAPS.")
                ' Optionally, you can set default values or handle the error gracefully
            End If


            prhdr.ABC = FormatNumber(If(IsDBNull(pBody.Compute("sum(total)", "")), 0, pBody.Compute("sum(total)", "")), 2)
            prhdr.Requestedby = ddRequestedBy.SelectedItem.Value
            prhdr.Approvedby = ddApprovedBy.SelectedItem.Value
            prhdr.Date_Submitted = txtprdate.Text
            prhdr.Date_gso_rcv = If(CDate(txtprdate.Text) >= #1/1/1753#, txtprdate.Text, "01/01/1900")
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

            ' Set Non-PPMP specific values
            prhdr.IsNonPPMP = chkNonPPMP.Checked
            prhdr.isPerLot = chkPurchasePerLot.Checked
            prhdr.NonPPMPJustification = If(chkNonPPMP.Checked, txtNonPPMPJustification.Text.Trim(), String.Empty)





            ' Retrieve F_ID, CityTreasurer, and Address values
            Dim F_ID As Integer = rbTrustFund.SelectedItem.Value
            Dim CTO As Integer = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            Dim Address As String = txtaddpeyee.Text

            ' Save PR Header for Non-PPMP PR and return prhdrID
            Dim prhdrID As Long = prhdr.save ' Declare prhdrID here
            AddTrace("Saved Non-PPMP PR Header. prhdrID: " & prhdrID)

            If rbTrustFund.SelectedValue = 3 Then
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = 3, isFinal = 0,CityTreasurer = '" & CTO & "', Userid ='" & Session("@UserName") & "', isTrustFund = 1, GA_ID = '" & Session("GA_ID") & "', comment = '" & replaceapostrophe(txtNote.Text) & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

            Else
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & rbTrustFund.SelectedItem.Value & "', CityTreasurer = '" & CTO & "', comment = '" & replaceapostrophe(txtNote.Text) & "', Address = '" & txtaddpeyee.Text & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)
                AddTrace("Executed: UPDATE AMS.PR_Hdr ... (F_ID, CityTreasurer, comment, Address)")

            End If


            ' Update PR Header with F_ID, CityTreasurer, and Address
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & F_ID & "', CityTreasurer = '" & CTO & "', Address = '" & Address & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

            ' Save prhdrID to session for later use in Submit
            Session("prhdr_id") = prhdrID ' Save prhdrID in session

            ' Save CAA Header (similar to SaveGoods function)
            AddTrace("Saving CAA_Hdr...")
            Dim CAA_hdr As New t_purchase_request_obr_hdr
            CAA_hdr.TempOBR_No = ""
            Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            Dim str As String = If(rbTrustFund.SelectedItem.Value = 1, "100", "200")
            Dim d As Date = CDate(txtprdate.Text)
            'Dim FundSourceID As Integer = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)
            Dim FundSourceID As Integer

            If ddPAPS.SelectedIndex > 0 Then
                ' Proceed with accessing the row in PAPS
                Dim Program_ID As Integer = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")

                ' Now execute the query using the Program_ID
                FundSourceID = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & Program_ID & "'", CommandType.Text)

                AddTrace("FundSourceID: " & FundSourceID)
            Else
                ' Handle the case where no valid selection is made
                AddTrace("No valid selection made in ddPAPS.")
                ' You can set a default value or display an error message, as per your logic
            End If

            CAA_hdr.OBR_No = If(FundSourceID = 14, str & "(18)" & "-" & d.ToString("yy") & "-", str & "-" & d.ToString("yy") & "-")
            CAA_hdr.F_ID_Accntg = rbTrustFund.SelectedItem.Value
            CAA_hdr.Period_key = 0
            CAA_hdr.PRHdr_ID = prhdrID
            CAA_hdr.OBR_Date = d
            CAA_hdr.OBR_Title = txtOBRpurpose.Text
            CAA_hdr.Budget_Year = Year(d)
            CAA_hdr.Supplier_ID = 0
            CAA_hdr.Payee = txtpeyee.Text
            CAA_hdr.Func_per_Office_ID = func_per_office
            CAA_hdr.Address = txtaddpeyee.Text
            CAA_hdr.Remarks = txtOBRpurpose.Text
            CAA_hdr.isApprovedMayor = False
            CAA_hdr.isCancelled = False
            CAA_hdr.DateSigned1 = d
            CAA_hdr.DateSigned2 = d
            CAA_hdr.isPayroll = False
            CAA_hdr.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & ddRC.SelectedItem.Value & "' AND func_id = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 1", CommandType.Text)
            CAA_hdr.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
            CAA_hdr.Status = "Pending"
            CAA_hdr.isAdjusted = False
            CAA_hdr.isAddForDisbursement = False
            CAA_hdr.isPayrollATM = False
            CAA_hdr.isGasoline = False
            CAA_hdr.pr_period_key_id = 0
            CAA_hdr.pr_invoice_hdr_id = 0
            CAA_hdr.DateDisapprovedMayor = #1/1/1900#
            CAA_hdr.DateApprovedMayor = #1/1/1900#
            CAA_hdr.DateReceivedMayor = #1/1/1900#
            CAA_hdr.isReceivedBO = False
            Dim obr_hdr_id As Long = CAA_hdr.save()
            Session("obr_id") = obr_hdr_id
            objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET forContinuing = '" & RadioButtonList1.SelectedValue & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)

            ' Save CAA Dtl (similar to SaveGoods function)
            AddTrace("Saving CAA_dtl...")
            Dim CAA_dtl As New t_purchase_request_obr_dtl
            CAA_dtl.OBR_Hdr_ID = obr_hdr_id
            CAA_dtl.particulars = txtOBRpurpose.Text
            CAA_dtl.BGA_ID = If(Session("BGA_ID") Is DBNull.Value, 0, Session("BGA_ID"))
            CAA_dtl.RC_ID = ddRC.SelectedItem.Value
            CAA_dtl.Function_ID = ddFunction.SelectedItem.Value
            'CAA_dtl.Program_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
            'CAA_dtl.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")

            CAA_dtl.Program_ID = Session("project_ID")
            CAA_dtl.Project_ID = Session("program_id")


            CAA_dtl.GA_ID = If(Session("GA_ID") Is DBNull.Value, 0, Session("GA_ID"))
            CAA_dtl.Amount = FormatNumber(If(pBody.Compute("sum(total)", "GA_ID=" & CAA_dtl.GA_ID & " and BGA_ID=" & CAA_dtl.BGA_ID & "") Is DBNull.Value, 0, pBody.Compute("sum(total)", "GA_ID=" & CAA_dtl.GA_ID & " and BGA_ID=" & CAA_dtl.BGA_ID & "")), 2)
            CAA_dtl.AllotmentClass_ID = ddnature.SelectedItem.Value
            CAA_dtl.save()

            ' Returning the PR Header ID
            Return prhdrID

            Session("edit_pr") = False



        End If


    End Function




    Public Sub SaveGoods()

        'Try
        AddTrace("SaveGoods() called.")

        If ddRequestedBy.SelectedItem.Text = "Select" Or ddApprovedBy.Text = "" Then
            AddTrace("Condition met: ddRequestedBy.SelectedItem.Text = 'Select' OR ddApprovedBy.Text = ''")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "ThenSelect signatories.")
            Exit Sub
        End If

        AddTrace("Session('edit_pr') value: " & Session("edit_pr"))

        If chkNonPPMP.Checked Then
            AddTrace("Non-PPMP PR detected. Saving as Non-PPMP PR...")


            ' Declare prhdrID for Non-PPMP PR as it is required in PR_Dtl
            Dim prhdrID As Long
            prhdrID = SaveNonPPMPHeader()  ' Custom method to save Non-PPMP PR header and return prhdrID

            ' Loop through items in the GridView and save as non-PPMP items
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                AddTrace("Row index: " & i)

                If CType(Me.gvbody.Rows(i).Cells(4).FindControl("lbltotal"), Label).Text <> "0.00" Then
                    AddTrace("Condition met: lbltotal <> 0.00 => Save this non-PPMP item.")
                    AddTrace("Row index: " & i & " - lbltotal = " & CType(Me.gvbody.Rows(i).Cells(4).FindControl("lbltotal"), Label).Text)

                    ' Create new PR_Dtl for non-PPMP items
                    prdtl.PRHdr_ID = prhdrID  ' Now using the correct prhdrID from above
                    prdtl.Item_ID = pBody.Rows(i)("Item_ID") ' Assuming non-PPMP items are handled here
                    prdtl.Project_title = txtpurpose.Text ' For non-PPMP, you can set this directly
                    prdtl.PR_ItemSpecs = CType(gvbody.Rows(i).FindControl("txtremarks"), TextBox).Text
                    prdtl.Qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text
                    prdtl.Cost = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                    prdtl.ppmp_dtl_id = 0 ' Not applicable for non-PPMP, so setting to 0

                    ' Save the non-PPMP PR_Dtl record
                    prdtl.save()
                Else
                    AddTrace("lbltotal = 0.00 => Skipping this non-PPMP row.")
                End If

                CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
            Next




        Else
            ' Continue with original PPMP-based PR saving logic (already working)
            AddTrace("PPMP -BasedPR detected. Proceeding with standard PR saving logic.")

            ' Saving PR
            If Session("edit_pr") = False Then
                AddTrace("Condition met: Session('edit_pr') = False => Creating new PR...")

                'Trace the stored procedure call
                AddTrace("About to call sp_BudgetCheck_ForPR with RC_ID=" & ddRC.SelectedItem.Value & ", Function_ID=" & ddFunction.SelectedItem.Value & ", nature=" & ddnature.SelectedItem.Value & ", Project_ID=" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & ", Program_ID=" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & ", Year=" & Year(CDate(txtprdate.Text)) & ", isContinuing=" & RadioButtonList1.SelectedValue & ", GA_ID=" & Session("GA_ID") & ", BGA_ID=" & Session("BGA_ID"))

                Dim budget As Decimal = objDerived.GetValue("EXEC [AMS].[sp_BudgetCheck_ForPR] '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddnature.SelectedItem.Value & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Year(CDate(txtprdate.Text)) & "','" & RadioButtonList1.SelectedValue & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "'", CommandType.Text)
                AddTrace("Returned budget from sp_BudgetCheck_ForPR: " & budget)

                Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)

                AddTrace("ABC (pBody sum of 'total'): " & ABC)
                AddTrace("pBody.Compute('sum(total)', '') for Non-PPMP: " & pBody.Compute("sum(total)", "").ToString())


                If budget < ABC Then
                    AddTrace("Condition met: budget < ABC => Show error & exit.")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "edit_pr : PR amount exceeds from the available budget.")
                    Exit Sub
                End If

                Dim prhdrID As Long
                AddTrace("Preparing to save PR_Hdr...")

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


                prhdr.IsNonPPMP = chkNonPPMP.Checked
                prhdr.NonPPMPJustification = If(chkNonPPMP.Checked, txtNonPPMPJustification.Text.Trim(), String.Empty)

                'isPerlotValue
                prhdr.isPerLot = chkPurchasePerLot.Checked

                AddTrace("Calling prhdr.save() now...")
                prhdrID = prhdr.save
                AddTrace("Returned prhdrID: " & prhdrID)

                Session("PRNo") = prhdrID
                Session("prhdr_id") = prhdrID

                Dim CTO As Integer
                AddTrace("Retrieving CityTreasurer from HRMS.view_signatory (deptid=10, division_key=86, isDeptHead=Yes)...")
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                AddTrace("CTO = " & CTO)
                If rbTrustFund.SelectedValue = 3 Then
                    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = 3, isFinal = 0,CityTreasurer = '" & CTO & "', Userid ='" & Session("@UserName") & "', isTrustFund = 1, GA_ID = '" & Session("GA_ID") & "', comment = '" & replaceapostrophe(txtNote.Text) & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

                Else
                    objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & rbTrustFund.SelectedItem.Value & "', CityTreasurer = '" & CTO & "', comment = '" & replaceapostrophe(txtNote.Text) & "', Address = '" & txtaddpeyee.Text & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)
                    AddTrace("Executed: UPDATE AMS.PR_Hdr ... (F_ID, CityTreasurer, comment, Address)")


                End If



                '=-= Saving PR_Dtl
                AddTrace("Looping through gvbody rows to save PR_Dtl...")

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    AddTrace("Row index: " & i)

                    If CType(Me.gvbody.Rows(i).Cells(4).FindControl("lbltotal"), Label).Text <> "0.00" Then
                        AddTrace("Condition met: lbltotal <> 0.00 => Save this item.")
                        AddTrace("Row index: " & i & " - lbltotal = " & CType(Me.gvbody.Rows(i).Cells(4).FindControl("lbltotal"), Label).Text)

                        prdtl.PRHdr_ID = prhdrID
                        prdtl.Item_ID = pBody.Rows(i)("Item_ID")
                        If CType(gvbody.Rows(i).FindControl("txtMemo"), TextBox).Text <> "" Then
                            prdtl.Project_title = txtpurpose.Text
                        Else
                            prdtl.Project_title = ""
                        End If

                        prdtl.PR_ItemSpecs = CType(gvbody.Rows(i).FindControl("txtremarks"), TextBox).Text

                        prdtl.Qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text
                        prdtl.Cost = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                        prdtl.ppmp_dtl_id = pBody.Rows(i)("ppmp_dtl_id")

                        'Trace the call that checks if item is already in PR_Dtl
                        AddTrace("Checking existing Qty in AMS.PR_Dtl for prhdr_id=" & prhdrID & ", Item_ID=" & pBody.Rows(i)("Item_ID"))

                        Dim iQty As Decimal
                        iQty = objDerived.GetValue("SELECT AMS.PR_Dtl.Qty FROM AMS.PR_Hdr INNER JOIN AMS.PR_Dtl ON AMS.PR_Hdr.prhdr_id = AMS.PR_Dtl.PRHdr_ID WHERE AMS.PR_Hdr.prhdr_id = '" & prhdrID & "' AND AMS.PR_Dtl.Item_ID = '" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                        AddTrace("Existing iQty returned: " & iQty)

                        If iQty = 0 Then
                            AddTrace("Condition met: iQty = 0 => prdtl.save() new record.")
                            prdtl.save()
                        Else
                            Dim NewQTY As Decimal
                            NewQTY = CType(iQty + CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text, Decimal)
                            AddTrace("Updating existing record. NewQTY = " & NewQTY)

                            Dim PRdtl_ID As Long
                            PRdtl_ID = objDerived.GetValue("SELECT AMS.PR_Dtl.PRDtlID FROM AMS.PR_Hdr INNER JOIN AMS.PR_Dtl ON AMS.PR_Hdr.prhdr_id = AMS.PR_Dtl.PRHdr_ID WHERE AMS.PR_Hdr.prhdr_id = '" & prhdrID & "' AND AMS.PR_Dtl.Item_ID = '" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                            AddTrace("PRdtl_ID to update: " & PRdtl_ID)

                            objDerived.Execute("UPDATE AMS.PR_Dtl SET Qty = '" & NewQTY & "' WHERE PRDtlID = '" & PRdtl_ID & "'", CommandType.Text)
                            AddTrace("Executed: UPDATE AMS.PR_Dtl SET Qty=" & NewQTY & " WHERE PRDtlID=" & PRdtl_ID)
                        End If

                    Else
                        AddTrace("lbltotal = 0.00 => Skipping this row.")
                    End If

                    CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
                Next

                '=-= Saving CAA_Hdr
                AddTrace("Saving CAA_Hdr...")

                CAA_hdr.TempOBR_No = ""
                Dim obj As New BaseClassesint.AccountClassAcounts
                Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = '" & ddRC.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
                AddTrace("func_per_office = " & func_per_office)

                Dim str As String
                If rbTrustFund.SelectedItem.Value = 1 Then
                    str = "100"
                Else
                    str = "200"
                End If
                AddTrace("Determined str for OBR_No = " & str)

                Dim d As Date = txtprdate.Text
                Dim FundSourceID As Integer = objDerived.GetValue("SELECT TOP(1) F_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS m_Program WHERE Program_ID = '" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "'", CommandType.Text)
                AddTrace("FundSourceID = " & FundSourceID)

                If FundSourceID = 14 Then
                    CAA_hdr.OBR_No = str & "(18)" & "-" & d.ToString("yy") & "-"
                Else
                    CAA_hdr.OBR_No = str & "-" & d.ToString("yy") & "-"
                End If
                AddTrace("CAA_hdr.OBR_No = " & CAA_hdr.OBR_No)

                CAA_hdr.F_ID_Accntg = rbTrustFund.SelectedItem.Value
                CAA_hdr.Period_key = 0
                CAA_hdr.PRHdr_ID = prhdrID
                CAA_hdr.OBR_Date = txtprdate.Text
                CAA_hdr.OBR_Title = txtOBRpurpose.Text
                CAA_hdr.Budget_Year = Year(txtprdate.Text)
                CAA_hdr.Supplier_ID = 0
                CAA_hdr.Payee = txtpeyee.Text
                CAA_hdr.Func_per_Office_ID = func_per_office
                CAA_hdr.Address = txtaddpeyee.Text
                CAA_hdr.Remarks = txtOBRpurpose.Text
                CAA_hdr.isPayroll = False
                CAA_hdr.isApprovedMayor = False
                CAA_hdr.isApproved = True
                CAA_hdr.isCancelled = False
                CAA_hdr.DateSigned1 = txtprdate.Text
                CAA_hdr.DateSigned2 = txtprdate.Text
                CAA_hdr.isPayroll = False
                CAA_hdr.Signatory1_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_EmployeeSignatories WHERE dept_id = '" & ddRC.SelectedItem.Value & "' AND func_id = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 1", CommandType.Text)
                CAA_hdr.Signatory2_ID = objDerived.GetValue("SELECT empsig_id FROM LnkdSrvrBOSS.GeoBOS.dbo.view_CityBudgetOfficer", CommandType.Text)
                CAA_hdr.Status = "Pending"
                CAA_hdr.isAdjusted = False
                CAA_hdr.isAddForDisbursement = False
                CAA_hdr.isPayrollATM = False
                CAA_hdr.isGasoline = False
                CAA_hdr.pr_period_key_id = 0
                CAA_hdr.pr_invoice_hdr_id = 0
                CAA_hdr.DateDisapprovedMayor = "01/01/1900"
                CAA_hdr.DateApprovedMayor = "01/01/1900"
                CAA_hdr.DateReceivedMayor = "01/01/1900"
                CAA_hdr.isReceivedBO = False
                CAA_hdr.PayeeOffice = ""

                AddTrace("Calling CAA_hdr.save() now.")
                Dim obr_hdr_id As Long = CAA_hdr.save()
                AddTrace("obr_hdr_id returned from CAA_hdr.save(): " & obr_hdr_id)
                Session("obr_id") = obr_hdr_id

                objDerived.GetRecords("UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET forContinuing = '" & RadioButtonList1.SelectedValue & "' WHERE OBR_Hdr_ID = " & obr_hdr_id, CommandType.Text)
                AddTrace("Executed: UPDATE LnkdSrvrBOSS.GEOBOS.BOS.T_CAA_Hdr SET forContinuing=" & RadioButtonList1.SelectedValue & " WHERE OBR_Hdr_ID=" & obr_hdr_id)

                '=-= Saving CAA_dtl
                AddTrace("Saving CAA_dtl...")

                CAA_dtl.OBR_Hdr_ID = obr_hdr_id
                CAA_dtl.particulars = txtOBRpurpose.Text
                CAA_dtl.BGA_ID = Session("BGA_ID")
                CAA_dtl.RC_ID = ddRC.SelectedItem.Value
                CAA_dtl.Function_ID = ddFunction.SelectedItem.Value
                CAA_dtl.Program_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                CAA_dtl.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                CAA_dtl.GA_ID = Session("GA_ID")
                AddTrace("CAA_dtl.GA_ID = " & Session("GA_ID") & ", BGA_ID = " & Session("BGA_ID"))

                AddTrace("pBody contents for Non-PPMP PR: " & pBody.Rows.Count & " rows.")
                For Each row As DataRow In pBody.Rows
                    AddTrace("Row - Item_ID: " & row("Item_ID") & ", Total: " & row("total"))
                Next

                CAA_dtl.Amount = FormatNumber(pBody.Compute("sum(total)", "GA_ID=" & CAA_dtl.GA_ID & " and BGA_ID=" & CAA_dtl.BGA_ID & ""), 2)
                AddTrace("CAA_dtl.Amount = " & CAA_dtl.Amount)
                CAA_dtl.AllotmentClass_ID = ddnature.SelectedItem.Value
                AddTrace("CAA_dtl.AllotmentClass_ID = " & ddnature.SelectedItem.Value)

                CAA_dtl.save()
                AddTrace("Called CAA_dtl.save()")

                Dim amount As Decimal
                amount = CAA_dtl.Amount
                AddTrace("amount = " & amount)

                AddTrace("Calling sp_AllotmentRelease_PerGA to update Budget Info.")
                pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID") & "','" & PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
                gvBudgetInfo2.DataSource = pBudgetInfo
                gvBudgetInfo2.DataBind()

                Session("edit_pr") = False
                AddTrace("Finished new PR creation. Setting Session('edit_pr')=False.")




            Else
                'PR Updating

                AddTrace("Condition met: Session('edit_pr') = True => Editing existing PR...")


                ' Log values before executing the stored procedure
                AddTrace("ddRC.SelectedItem.Value: " & Me.ddRC.SelectedItem.Value)
                AddTrace("ddFunction.SelectedItem.Value: " & ddFunction.SelectedItem.Value)
                AddTrace("ddnature.SelectedItem.Value: " & ddnature.SelectedItem.Value)
                AddTrace("Session(Project_ID): " & Session("Project_ID"))
                AddTrace("Session(program_id): " & Session("program_id"))
                AddTrace("Year(CDate(txtprdate.Text)): " & Year(CDate(txtprdate.Text)))
                AddTrace("Session(isContinuing): " & Session("isContinuing"))

                AddTrace("Session(prhdr_id): " & Session("prhdr_id"))


                ' Retrieve the correct GA_ID and BGA_ID from the database for this PR
                Dim oGA_ID As Integer = objDerived.GetValue("SELECT GA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
                Dim oBGA_ID As Integer = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)

                ' Handle Non-PPMP PR (GA_ID = 0)
                If oGA_ID = 0 Then
                    AddTrace("GA_ID is 0, using View_PR_GABGA_NONPPMP to fetch GA_ID.")
                    ' Tracing the query execution for the Non-PPMP view
                    Dim query As String = "SELECT GA_ID FROM [dbo].[View_PR_GABGA_NONPPMP] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'"
                    AddTrace("Executing query: " & query)
                    oGA_ID = objDerived.GetValue(query, CommandType.Text)
                    oBGA_ID = 0 ' For Non-PPMP, BGA_ID is not needed
                    AddTrace("Fetched oGA_ID = " & oGA_ID)



                    ' Indicate that this is a Non-PPMP PR
                    AddTrace("This PR is a Non-PPMP PR. Proceeding with Non-PPMP logic.")

                End If

                ' If GA_ID/BGA_ID are still zero (meaning no record found in View_PR_GABGA), confirm the nature or handle fallback logic.
                AddTrace("Updated GA_ID from View_PR_GABGA = " & oGA_ID & ", BGA_ID = " & oBGA_ID)
                Session("GA_ID") = oGA_ID
                Session("BGA_ID") = oBGA_ID

                AddTrace("Session Updates = " & oGA_ID & ", BGA_ID = " & oBGA_ID)


                ' Execute the stored procedure and capture the budget value
                Dim budget As Decimal = Val(objDerived.GetValue("EXEC [AMS].[sp_BudgetCheck_ForEditPR] '" & Me.ddRC.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & ddnature.SelectedItem.Value & "','" & Session("Project_ID") & "','" & Session("program_id") & "','" & Year(CDate(txtprdate.Text)) & "','" & Session("isContinuing") & "','" & oGA_ID & "','" & oBGA_ID & "','" & Session("prhdr_id") & "'", CommandType.Text))

                ' Log the returned budget value
                AddTrace("Returned budget from sp_BudgetCheck_ForEditPR: " & budget)

                ' Compute and log ABC value
                Dim ABC As Decimal = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                AddTrace("ABC (pBody sum of 'total'): " & ABC)

                ' Condition check and logging
                If budget < ABC Then
                    AddTrace("Condition met: budget < ABC => Show error & exit.")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PR amount exceeds from the available budget.")
                    Exit Sub
                End If


                AddTrace("Editing PR_Hdr => Session('prhdr_id') = " & gvListPR.SelectedDataKey(0))
                Session("PRNo") = gvListPR.SelectedDataKey(0)
                Session("prhdr_id") = gvListPR.SelectedDataKey(0)

                Dim CTO As Integer
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes' AND isActive = 1", CommandType.Text)
                AddTrace("CTO (edit mode) = " & CTO)

                Dim isPerLotValue As Integer = If(chkPurchasePerLot.Checked, 1, 0)
                AddTrace("Updating AMS.PR_Hdr: isPerLot = " & isPerLotValue)

                objDerived.GetRecords("UPDATE ams.pr_hdr SET ABC = '" & pBody.Compute("sum(total)", "") & "', " &
                      "remarks = '" & replaceapostrophe(txtpurpose.Text) & "', " &
                      "Requestedby = '" & ddRequestedBy.SelectedItem.Value & "', " &
                      "CityTreasurer = '" & CTO & "', " &
                      "isPerLot = '" & isPerLotValue & "' " &
                      "WHERE prhdr_id='" & gvListPR.SelectedDataKey(0) & "' ", CommandType.Text)

                AddTrace("Executed: UPDATE ams.pr_hdr in edit mode with isPerLot = " & isPerLotValue)



                '======== PR_Dtl Edit ======== 
                Dim origcount As Integer = Me.Session("row_num_edit")
                AddTrace("origcount (row_num_edit) = " & origcount)

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    AddTrace("Row index: " & i & " in edit PR mode.")
                    Dim qty As Decimal = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text()
                    Dim cost As Decimal = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                    Dim PRSpecs As String = CType(gvbody.Rows(i).FindControl("txtremarks"), TextBox).Text
                    Dim dtPRdtl As New DataTable

                    dtPRdtl = objDerived.GetDataTable("Select * from AMS.PR_Dtl where prhdr_id = '" & Session("prhdr_id") & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    AddTrace("dtPRdtl count for item_id=" & pBody.Rows(i)("Item_ID") & " => " & dtPRdtl.Rows.Count)

                    If dtPRdtl.Rows.Count = 0 Then
                        AddTrace("No existing record => INSERT into AMS.PR_Dtl")
                        objDerived.Execute("INSERT INTO AMS.PR_Dtl (PRHdr_ID,Item_ID,Project_title,Qty,Cost,ppmp_dtl_id,PR_ItemSpecs) values('" & gvListPR.SelectedDataKey(0) & "','" & pBody.Rows(i)("Item_ID") & "','" & txtpurpose.Text & "','" & qty & "','" & cost & "','" & pBody.Rows(i)("ppmp_dtl_id") & "','" & PRSpecs & "')", CommandType.Text)
                    Else
                        AddTrace("Record exists => UPDATE AMS.PR_Dtl")
                        objDerived.GetRecords("Update AMS.PR_Dtl set Qty ='" & qty & "', Project_title = '" & txtpurpose.Text & "', Cost = '" & cost & "', PR_ItemSpecs = '" & PRSpecs & "' where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    End If
                Next

                AddTrace("Finished looping PR_Dtl => OBR editing commented out in code...")

                pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Session("Project_ID") & "','" & Session("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
                gvBudgetInfo2.DataSource = pBudgetInfo
                gvBudgetInfo2.DataBind()

                Session("edit_pr") = False
                AddTrace("Set Session('edit_pr')=False => Done editing.")

                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET IsNonPPMP = '" & chkNonPPMP.Checked & "', NonPPMPJustification = '" & txtNonPPMPJustification.Text.Trim() & "' WHERE prhdr_id = " & gvListPR.SelectedDataKey(0), CommandType.Text)
                AddTrace("Updated AMS.PR_Hdr => IsNonPPMP, NonPPMPJustification in edit mode.")
            End If


        End If

        AddTrace("Saving completed => show success message & reset form.")
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

        AddTrace("SaveGoods() completed.")

        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Server Error. Please try again later.")
        'End Try



    End Sub



    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Ensure prhdr_id is available for submission
        Dim prhdrID As Long = Session("prhdr_id")
        If prhdrID = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invalid PR header ID.")
            Exit Sub
        End If

        ' Check the PR status based on whether it's been assigned a pr_no (check if it's already submitted or not)
        Dim CheckPR As String = objDerived.GetValue("SELECT ISNULL([pr_no], '0') FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & prhdrID & "'", CommandType.Text)

        If CheckPR = "0" Then
            ' If no pr_no exists, this means it's still in draft, so we can submit it
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, Date_Submitted = '" & Date.Today.ToString("MM/dd/yyyy") & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)
        Else
            ' If the pr_no is already assigned, it means the PR has been created before, so we mark it as approved
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, [IsApproved] = 1, [isEditable] = 0 WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)
        End If

        ' Provide feedback to the user
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Request has been submitted.")
        btnSubmit.Enabled = False ' Disable submit button after submission
        LoadPRList_PerRC()


    End Sub


    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Dim isPerLot As Boolean = Convert.ToBoolean(objDerived.GetValue("SELECT ISNULL(isPerLot, 0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text))

        If isPerLot Then
            Dim url As String = "/procurement/rpt_purchase_request.aspx?perLot=true"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        Else
            Session("Page") = "PR"
            Session("Report") = "PR"

            Dim isDBM As Boolean = Convert.ToBoolean(objDerived.GetValue("SELECT ISNULL(isDBM, 0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text))
            If Not isDBM Then
                Dim url As String = "/MainReports/Procurement_Reports.aspx"
                Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
            Else
                Me.Page.Response.Redirect("~/procurement/rpt_ARP.aspx")
            End If
        End If
    End Sub






    Protected Sub gvListPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListPR.SelectedIndexChanged
        AddTrace("gvListPR_SelectedIndexChanged called.")

        If IsDBNull(gvListPR.SelectedDataKey(0)) = True Then
            AddTrace("Condition met: gvListPR.SelectedDataKey(0) is DBNull.")
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select purchase request transaction.")
            Exit Sub
        Else
            AddTrace("gvListPR.SelectedDataKey(0) is not DBNull, proceeding with further logic.")

            'Try
            If Lbtn = "PR" Then
                AddTrace("Lbtn is PR. Opening Procurement_Reports.aspx in a new tab.")
                Session("Page") = "PR"
                Session("Report") = "PR"
                Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")

                ' Open PR report in a new tab
                Dim url As String = "/MainReports/Procurement_Reports.aspx"
                Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)

            ElseIf Lbtn = "ObR" Then
                AddTrace("Lbtn is ObR. Opening Procurement_Reports.aspx in a new tab.")
                Session("Page") = "ObR"
                Session("Report") = "ObR"
                Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")

                ' Open ObR report in a new tab
                Dim url As String = "/MainReports/Procurement_Reports.aspx"
                Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"
                ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_OBR_WINDOW", fullURL, True)

            ElseIf Lbtn = "cancel" Then
                AddTrace("Lbtn is cancel. Skipping this block.")


                'Editing function:
            ElseIf Lbtn = "edit" Then

                LoaditemsEdit()
            End If


            ' Fetch and bind attached documents to the purchase request
            grdDocuments.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.Document_PR_Attachment where prhdr_id = '" & gvListPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdDocuments.DataBind()
            UploadButton.Enabled = True
            FileUpload1.Enabled = True

            'Catch ex As Exception
            '    AddTrace("Error in gvListPR_SelectedIndexChanged: " & ex.Message)
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "An error occurred while processing. Please contact the admin.")
            'End Try
        End If
    End Sub



    Public Sub LoaditemsEdit()
        AddTrace("Lbtn is edit. Preparing to edit purchase request.")

        Session("prhdr_id") = gvListPR.SelectedDataKey("prhdr_id")
        Session("isContinuing") = objDerived.GetValue("SELECT isContinuing FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)


        AddTrace("Session('isContinuing') = " & Session("isContinuing"))

        ' Get GA_ID and BGA_ID
        Dim oGA_ID As Integer = objDerived.GetValue("SELECT GA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        Dim oBGA_ID As Integer = objDerived.GetValue("SELECT BGA_ID FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        AddTrace("oGA_ID = " & oGA_ID & ", oBGA_ID = " & oBGA_ID)

        ' Handle Non-PPMP PR (GA_ID = 0)
        If oGA_ID = 0 Then
            AddTrace("GA_ID is 0, using View_PR_GABGA_NONPPMP to fetch GA_ID. This is a NON-PPMP PR.")
            ' Tracing the query execution for the Non-PPMP view
            Dim query As String = "SELECT GA_ID FROM [dbo].[View_PR_GABGA_NONPPMP] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'"
            AddTrace("Executing query: " & query)
            oGA_ID = objDerived.GetValue(query, CommandType.Text)
            oBGA_ID = 0 ' For Non-PPMP, BGA_ID is not needed
            AddTrace("Fetched oGA_ID = " & oGA_ID)

            ' Indicate that this is a Non-PPMP PR
            AddTrace("This PR is a Non-PPMP PR. Proceeding with Non-PPMP logic.")
        End If




        ' If GA_ID/BGA_ID are still zero (meaning no record found in View_PR_GABGA), confirm the nature or handle fallback logic.
        AddTrace("Updated GA_ID from View_PR_GABGA = " & oGA_ID & ", BGA_ID = " & oBGA_ID)
        Session("GA_ID") = oGA_ID
        Session("BGA_ID") = oBGA_ID

        AddTrace("Session Updates = " & oGA_ID & ", BGA_ID = " & oBGA_ID)




        ' Populate account list
        ddAccounts.DataSource = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList", CommandType.Text)
        ddAccounts.DataTextField = "GA_Title"
        ddAccounts.DataValueField = "GA_CODE2"
        ddAccounts.DataBind()

        ' Handle DBNull for GA_Code2
        Dim selectedGA As String = objDerived.GetValue("SELECT TOP(1) GA_Code2 FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)
        AddTrace("Executing query for selected GA_Code2: " & "SELECT TOP(1) GA_Code2 FROM [dbo].[View_PR_GABGA] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'")



        If String.IsNullOrEmpty(selectedGA) OrElse selectedGA = DBNull.Value.ToString() Then
            selectedGA = objDerived.GetValue("SELECT TOP(1) GA_Code2 FROM [dbo].[View_PR_GABGA_NONPPMP] WHERE PRHdr_ID = '" & Session("prhdr_id") & "'", CommandType.Text)

        End If

        ddAccounts.SelectedValue = selectedGA
        AddTrace("ddAccounts.SelectedValue set to " & selectedGA)

        ' Disable some fields for editing
        btnpreview.Enabled = False
        ddPAPS.Enabled = False
        ddnature.Enabled = False
        LinkButton2.Enabled = False
        btnAddlist.Enabled = True


        ddRC.Enabled = False
        ddFunction.Enabled = False
        ddAccounts.Enabled = False

        ' Fetch header data
        datahdr = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_hdr " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
        AddTrace("Executing sp_edit_purchase_request_hdr with PRHdr_ID: " & gvListPR.SelectedDataKey(0))
        AddTrace("Data fetched for purchase request header.")
        ddnature.SelectedValue = datahdr.Rows(0)("Transaction_type")
        txtpurpose.Text = datahdr.Rows(0)("remarks")
        txtNote.Text = datahdr.Rows(0)("Note")
        txtOBRpurpose.Text = datahdr.Rows(0)("OBR_Title")
        txtpeyee.Text = datahdr.Rows(0)("Payee")
        txtaddpeyee.Text = datahdr.Rows(0)("Address")

        ' Here you are trying to access IsNonPPMP
        'If datahdr.Rows(0)("IsNonPPMP") = True Then
        '    AddTrace("This is a Non-PPMP PR. Executing sp_edit_purchase_request_detail_NONPPMP.")
        '    ' Fetch Non-PPMP PR details using the new stored procedure
        '    pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail_NONPPMP " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
        'Else
        '    ' Fetch PPMP-based PR details using the existing logic
        '    pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
        'End If


        txtOBRpurpose.ReadOnly = False
        txtpeyee.Enabled = True
        txtpurpose.Enabled = True
        txtaddpeyee.Enabled = True

        ' Fetch Program/Activity/Project data
        Dim PPAname As DataTable
        PPAname = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_Edit_PR " & Me.ddRC.SelectedItem.Value & ",'" & Year(CDate(txtprdate.Text)) & "'," & ddFunction.SelectedItem.Value & ",0," & datahdr.Rows(0)("Project_ID") & "," & datahdr.Rows(0)("Program_id") & "", CommandType.Text)
        AddTrace("Executing sp_Programs_Activities_Project_Edit_PR with parameters: RC_ID=" & Me.ddRC.SelectedItem.Value & ", Year=" & Year(CDate(txtprdate.Text)) & ", Function_ID=" & ddFunction.SelectedItem.Value)
        AddTrace("PPAname fetched: " & PPAname.Rows.Count & " rows.")

        If PPAname.Rows.Count > 0 Then
            ddPAPS.SelectedItem.Text = PPAname.Rows(0)("description")
        Else
            AddTrace("No results found for PPAname.")
        End If

        ' Check if the PR is NON-PPMP and fetch the correct details
        If datahdr.Rows(0)("IsNonPPMP") = True Then
            AddTrace("This is a Non-PPMP PR. Executing sp_edit_purchase_request_detail_NONPPMP.")
            ' Fetch Non-PPMP PR details using the new stored procedure
            pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail_NONPPMP " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)


        Else
            ' Fetch PPMP-based PR details using the existing logic
            pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
        End If

        If pBody Is Nothing OrElse pBody.Rows.Count = 0 Then
            AddTrace("No data returned from the selected stored procedure.")
            Exit Sub
        End If

        gvbody.DataSource = pBody
        gvbody.DataBind()

        CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

        ' Further processing and control enable/disable logic
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
        Session("project_ID") = datahdr.Rows(0)("project_ID")
        Session("program_id") = datahdr.Rows(0)("program_id")

        pBudgetInfo = objDerived.GetDataTable("EXEC [AMS].[sp_AllotmentRelease_PerGA] " & Year(CDate(txtprdate.Text)) & "," & Me.ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & ",'" & Session("project_ID") & "','" & Session("Program_id") & "','" & Session("GA_ID") & "','" & Session("BGA_ID") & "','" & RadioButtonList1.SelectedValue & "'", CommandType.Text)
        gvBudgetInfo2.DataSource = pBudgetInfo
        gvBudgetInfo2.DataBind()

        Session("Edit") = 1
        If ddnature.SelectedIndex = 1 Then

            If chkNonPPMP.Checked Then
                ' For Non-PPMP Purchase Request:
                ' Call the new stored procedure that returns all items for the given GA_ID and Search term.
                pitems = objDerived.GetDataTable("EXEC [AMS].[sp_supplies_for_pr_NONPPMP_SEARCH_EDIT] " & Session("GA_ID") & ", " & Session("prhdr_id") & ", '" & SearchBut.Text & "'", CommandType.Text)
                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                gvitems.Columns(6).Visible = False
                gvitems.Columns(7).Visible = False
                gvitems.Columns(8).Visible = False
                gvitems.Columns(10).Visible = False


            Else
                pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & 0 & "',0,'" & Session("GA_ID") & "'", CommandType.Text)

            End If

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
            If chkNonPPMP.Checked Then
                ' For Non-PPMP Purchase Request:
                ' Call the new stored procedure that returns all items for the given GA_ID and Search term.
                pitems = objDerived.GetDataTable("EXEC [AMS].[sp_supplies_for_pr_NONPPMP_SEARCH_EDIT] " & Session("GA_ID") & ", " & Session("prhdr_id") & ", '" & SearchBut.Text & "'", CommandType.Text)
                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                gvitems.Columns(6).Visible = False
                gvitems.Columns(7).Visible = False
                gvitems.Columns(8).Visible = False
                gvitems.Columns(10).Visible = False


            Else
                pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & 0 & "',0,'" & Session("GA_ID") & "'", CommandType.Text)

            End If
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
            'commented until needed
            cbReinbursement.Checked = datahdr.Rows(0)("isReimbursement")
        Else
            LinkButton2.Enabled = False
            cbReinbursement.Enabled = False
            cbReinbursement.Checked = False
        End If

        For Each column As DataColumn In pitems.Columns
            AddTrace("Column: " & column.ColumnName)
        Next



        If pitems.Columns.Contains("GA_Code2") Then
            ' Add the filtering code here
            If pBody IsNot Nothing AndAlso pBody.Rows.Count > 0 Then
                Dim existingItemIds As New List(Of String)
                For Each row As DataRow In pBody.Rows
                    existingItemIds.Add(row("Item_ID").ToString())
                Next

                Dim filterExpression As String = String.Format("Item_ID NOT IN ({0})", String.Join(",", existingItemIds))
                Dim filteredView As DataView = pitems.DefaultView
                filteredView.RowFilter = filterExpression
                pitems = filteredView.ToTable()
            End If

            gvitems.DataSource = pitems
            gvitems.DataBind()
        Else
            AddTrace("Error: GA_Code2 field not found in DataTable.")
        End If


        If pitems.Columns.Contains("GA_Code2") Then
            gvitems.DataSource = pitems
            gvitems.DataBind()
        Else
            AddTrace("Error: GA_Code2 field not found in DataTable.")
            ' Handle this error gracefully (e.g., show an alert or log the issue)
        End If


        ' Additional checks for reimbursement fields and visibility
        For i As Integer = 0 To gvbody.Rows.Count - 1
            Dim txt As TextBox = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)
            Dim txtcost As TextBox = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox)
            If cbReinbursement.Checked = True Then
                txtcost.Enabled = True
                txtcost.Attributes.Add("onFocus", "this.select()")
                txtcost.Attributes.Add("onClick", "this.select()")
            ElseIf chkNonPPMP.Checked = True Then
                txtcost.Enabled = True
                txtcost.Attributes.Add("onFocus", "this.select()")
                txtcost.Attributes.Add("onClick", "this.select()")

            Else
                txtcost.Enabled = True
                txtcost.ReadOnly = True
            End If

            txt.ReadOnly = False
            txt.Attributes.Add("onFocus", "this.select()")
            txt.Attributes.Add("onClick", "this.select()")
            pBody.Rows(i)("Qty") = pBody.Rows(i)("Qty")
        Next

        '=== 05172016: Additional checks for specific GA_ID
        For i As Integer = 0 To Me.pBody.Rows.Count - 1
            If pBody.Rows(i)("GA_ID") = 794 Then
                AddTrace("Condition met for GA_ID = 794. Enabling cost field for this item.")
                CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Enabled = True
                CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = False
            End If
        Next

        btnSave.Enabled = True
        btnAddlist.Enabled = True
        Session("edit_pr") = True



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
        'Lbtn = "ObR"
        Lbtn = "PR"
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "edit"

        ' Ensure correct concatenation of query string and session value
        Dim query As String = "SELECT IsNonPPMP FROM [AMS].[PR_Hdr] WHERE PRHdr_ID = " & Session("prhdr_id")
        Dim dt As DataTable = objDerived.GetDataTable(query, CommandType.Text)

        ' Default value of isNonPPMP
        Dim isNonPPMP As Integer = 0 ' Default to 0 (False)

        ' Check if the DataTable contains rows
        If dt.Rows.Count > 0 Then
            ' Get the value from the first row and the IsNonPPMP column
            ' Convert the value to Integer (1 or 0)
            If dt.Rows(0)("IsNonPPMP") IsNot DBNull.Value Then
                isNonPPMP = Convert.ToInt32(dt.Rows(0)("IsNonPPMP"))
            End If
        End If

        ' Set the checkbox based on the value of isNonPPMP (1 or 0)
        If isNonPPMP = 1 Then
            chkNonPPMP.Checked = True
            chkNonPPMP.Visible = True
            chkNonPPMP.Enabled = False
        Else
            chkNonPPMP.Checked = False
            chkNonPPMP.Visible = False

        End If

        ' isPerLot logic
        Dim isPerLotquery As String = "SELECT isPerLot FROM [AMS].[PR_Hdr] WHERE PRHdr_ID = " & Session("prhdr_id")
        Dim dt2 As DataTable = objDerived.GetDataTable(isPerLotquery, CommandType.Text)

        Dim isPerlot As Integer = 0

        ' Check if the DataTable contains rows
        If dt2.Rows.Count > 0 Then
            ' Make sure to reference dt2, not dt
            If dt2.Rows(0)("isPerLot") IsNot DBNull.Value Then
                isPerlot = Convert.ToInt32(dt2.Rows(0)("isPerLot")) ' FIXED: Now referencing dt2 correctly
            End If
        End If

        ' Set checkbox state based on isPerLot value
        If isPerlot = 1 Then
            chkPurchasePerLot.Checked = True

        Else
            chkPurchasePerLot.Checked = False

        End If


        'chkNonPPMP.Enabled = False
        btnSubmit.Enabled = False
    End Sub


    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "cancel"
    End Sub
    Protected Sub btnBuildingBrowse_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.btnAddlist.Enabled = True
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

    Protected Sub grdDocuments_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdDocuments.PageIndex = e.NewPageIndex
        grdDocuments.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.Document_PR_Attachment where prhdr_id = '" & gvListPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdDocuments.DataBind()
    End Sub

    Protected Sub UploadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim fi2 As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
        Dim extension As String = Path.GetExtension(fi2.Name)

        If (FileUpload1.HasFile) Then
            lblNoti.Visible = False
            If extension = ".jpg" Or extension = ".png" Or extension = ".doc" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
                If FileUpload1.PostedFile.ContentLength <= 25000000 Then
                    Dim fi As FileInfo = New FileInfo(Me.FileUpload1.PostedFile.FileName)
                    Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
                    FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

                    objDerived.cmd.Parameters.AddWithValue("@DocumentID", 0)
                    objDerived.cmd.Parameters.AddWithValue("@Stage", "Purchase Request")
                    objDerived.cmd.Parameters.AddWithValue("@prhdr_id", Session("prhdr_id"))
                    objDerived.cmd.Parameters.AddWithValue("@DateUploaded", Date.Today.ToString("MM/dd/yyyy"))
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFilename", fi.Name)
                    objDerived.cmd.Parameters.AddWithValue("@AttachedFile", imageBytes)
                    objDerived.cmd.Parameters.AddWithValue("@DocumentName", txtDocName.Text)
                    objDerived.cmd.Parameters.AddWithValue("@DocumentNo", txtDocNumb.Text)
                    objDerived.cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text)
                    objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
                    objDerived.Execute("@CurrID", "[AMS].[spSave_Tb_Attachment]", CommandType.StoredProcedure, Nothing)

                    msg.UserMsgBox("File has been uploaded.", Me, False)

                Else
                    msg.UserMsgBox("Invalid filesize. Choose another file.", Me, False)
                End If
            Else
                msg.UserMsgBox("Invalid filetype. Choose another file.", Me, False)
            End If

        Else
            lblNoti.Visible = True
        End If
        grdDocuments.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.Document_PR_Attachment where prhdr_id = '" & gvListPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdDocuments.DataBind()
        txtDocName.Text = ""
        txtDocNumb.Text = ""
        txtRemarks.Text = ""
    End Sub

    Public Sub CreateFile(ByVal UniqueID As String, ByVal file_name As String, ByVal cmdstr As String)
        Dim oFileStream As System.IO.FileStream
        Dim connection As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("constr").ToString)
        Dim buffer As Byte()

        Try
            connection.Open()
            Dim command As New SqlCommand(cmdstr, connection)
            command.Parameters.AddWithValue("@param", UniqueID)
            Using reader As SqlDataReader = command.ExecuteReader
                Do While reader.Read
                    buffer = DirectCast(reader.GetValue(0), Byte())
                Loop
            End Using
        Catch ex As Exception

        Finally
            connection.Close()
        End Try

        '
        Dim p As String = file_name
        Dim extension As String = Path.GetExtension(p)


        If System.IO.Directory.Exists(Server.MapPath("..\") & "obj\temp\Downloads\") Then
            'delete the directory including the lates files that the client has downloaded manually.
            Dim s As String
            For Each s In System.IO.Directory.GetFiles(Server.MapPath("..\") & "\obj\temp\Downloads\")
                System.IO.File.Delete(s)
            Next s
        Else
            'create a new directory for the client.
            Directory.CreateDirectory(Server.MapPath("..\") & "obj\temp\Downloads\")
        End If


        'write the file for manual download.
        Dim filepath As String = Server.MapPath("..\") & "obj\temp\Downloads\" & "\" & file_name

        oFileStream = New System.IO.FileStream(filepath, System.IO.FileMode.Create)
        oFileStream.Write(buffer, 0, buffer.Length)
        oFileStream.Close()
        If extension = ".doc" Or extension = ".docx" Or extension = ".rar" Or extension = ".zip" Or extension = ".pdf" Or extension = ".xls" Or extension = ".xlsx" Then
            Page.Response.Redirect("..\obj\temp\Downloads\" & "\" & file_name)
            myFrame.Attributes("src") = "/images/blankImage.jpg"

        Else


            Dim img As System.Web.UI.AttributeCollection = myFrame.Attributes
            img.Add("src", "..\obj\temp\downloads\" & "\" & file_name)
        End If

    End Sub
    Protected Sub LoadDocumentList()
        Try

            CreateFile(Doc_ID, FName, "SELECT AttachedFile FROM AMS.Document_PR_Attachment WHERE DocumentID = @param")
            grdDocuments.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.Document_PR_Attachment where prhdr_id = '" & gvListPR.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
            grdDocuments.DataBind()

        Catch ex As Exception
            msg.UserMsgBox("Please Contact Admin.", Me, False)
        End Try

    End Sub

    Protected Sub grdDocuments_SelectedIndexChanged(sender As Object, e As EventArgs)

        Doc_ID = grdDocuments.SelectedDataKey("DocumentID")
        FName = grdDocuments.SelectedDataKey("AttachedFilename")

        LoadDocumentList()
    End Sub
    Protected Sub btnCancelModal_Click(sender As Object, e As EventArgs) Handles btnCancelModal.Click
        ModalPopupExtender1.Hide()
    End Sub
End Class
