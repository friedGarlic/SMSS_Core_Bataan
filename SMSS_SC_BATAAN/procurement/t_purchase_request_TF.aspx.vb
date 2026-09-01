Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class t_purchase_request_TF
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
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
        dt.Columns.Add("Amount", GetType(Decimal))
        dt.Columns.Add("obligated_amount", GetType(Decimal))
        dt.Columns.Add("ongoing_amount", GetType(Decimal))
        dt.Columns.Add("added", GetType(Decimal))
        dt.Columns.Add("Total_Amount", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ga_code") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("obligated_amount") = DBNull.Value
            dr("ongoing_amount") = DBNull.Value
            dr("added") = DBNull.Value
            dr("Total_Amount") = DBNull.Value
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

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("OBR_Hdr_ID") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("Date_Submitted") = DBNull.Value
            dr("isVisible") = False
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
              
                txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")
                txtprdate.Enabled = True
                lbmeals.Enabled = False

                Session("RoleName") = rolename
                pRoleName = objDerived.GetDataTable("EXEC [dbo].[sp_GetRC_ByRole_systemManager] '" & rolename & "'", CommandType.Text)

                pRC = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
                ddRC.DataSource = CType(pRC, DataTable)
                ddRC.DataTextField = ("rc_name")
                ddRC.DataValueField = ("rc_id")
                ddRC.DataBind()

                gvListPR.DataSource = createdatatable12(4)
                gvListPR.DataBind()

                ddRC.Enabled = True
                lblreq1.Visible = False
                lblreq2.Visible = False
                Session("Edit") = 0

                grdDocuments.DataSource = CreateTable_Attachment(4)
                grdDocuments.DataBind()

            End If

            SearchBut.Attributes.Add("onkeypress", "return fun1(event,'" & Button5.ClientID & "')")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "You dont have a PPMP. Please create your pppmp first before preparing Purchase Request.")
        End Try

    End Sub

    Protected Sub rbTrustFund_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")
    End Sub
    Protected Sub ddRC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRC.SelectedIndexChanged
        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RespCenter_withFunctions] WHERE [RC_id] = '" & ddRC.SelectedItem.Value & "'", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()

        ddFunction.Enabled = True
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

            pRequestedby = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddRC.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            ddRequestedBy.DataSource = pRequestedby
            ddRequestedBy.DataTextField = ("full_name")
            ddRequestedBy.DataValueField = ("empid")
            ddRequestedBy.DataBind()
            ddRequestedBy.Items.Insert(0, "Select")

            ddRequestedBy.Enabled = True

            ddCheckedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id, isActive FROM AMS.BAC_Members WHERE isActive = 1 ORDER BY Name", CommandType.Text)
            ddCheckedBy.DataTextField = ("Name")
            ddCheckedBy.DataValueField = ("empsig_id")
            ddCheckedBy.DataBind()
            ddCheckedBy.Items.Insert(0, "Select")

            ddNotedBy.DataSource = objDerived.GetDataTable("SELECT UPPER(Name) AS Name, empsig_id, isActive FROM AMS.BAC_Members WHERE isActive = 1 ORDER BY Name", CommandType.Text)
            ddNotedBy.DataTextField = ("Name")
            ddNotedBy.DataValueField = ("empsig_id")
            ddNotedBy.DataBind()
            ddNotedBy.Items.Insert(0, "Select")

            ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid IN (1,67) AND division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' ORDER BY deptid", CommandType.Text)
            ddApprovedBy.DataTextField = ("Name")
            ddApprovedBy.DataValueField = ("empid")
            ddApprovedBy.DataBind()


        End If
    End Sub
    Protected Sub ddnature_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddnature.SelectedIndexChanged
        pAccounts = objDerived.GetDataTable("SELECT * FROM [AMS].[View_AccountList] WHERE [AllotmentClass_ID] = '" & ddnature.SelectedItem.Value & "' ORDER BY [GA_Title]", CommandType.Text)
        ddAccounts.DataSource = pAccounts
        ddAccounts.DataTextField = ("GA_Title")
        ddAccounts.DataValueField = ("GA_Code2")
        ddAccounts.DataBind()

    End Sub
    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddAccounts.SelectedIndexChanged
        Dim GA_ID As Integer
        Dim BGA_ID As Integer
        GA_ID = objDerived.GetValue("Select GA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)
        BGA_ID = objDerived.GetValue("Select BGA_ID from AMS.View_AccountList where GA_Code2 ='" & ddAccounts.SelectedValue & "'", CommandType.Text)

        Session("GA_ID") = GA_ID
        Session("BGA_ID") = BGA_ID

        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.Columns(6).Visible = True
        'gvitems.Columns(7).Visible = True

        pitems = objDerived.GetDataTable("EXEC [AMS].[sp_goods_per_account_withPrice] '" & Session("GA_ID") & "','" & Session("BGA_ID") & "', '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
        gvitems.DataSource = pitems
        gvitems.DataBind()

        LinkButton2.Enabled = True

        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False
        gvitems.Columns(6).Visible = False
        ' gvitems.Columns(7).Visible = False

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

        If txtpurpose.Text = "" Or txtOBRpurpose.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")
            lblreq1.Visible = True
            lblreq2.Visible = True
        Else
            SaveGoods()
            btnSubmit.Enabled = True
        End If
    End Sub
    Public Sub SaveGoods()
        Try
            If ddRequestedBy.SelectedItem.Text = "Select" Or ddCheckedBy.SelectedItem.Text = "Select" Or ddNotedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatories.")
                Exit Sub
            End If

            If Me.Session("edit_pr") = False Then
                Dim prhdrID As Long

                '=-= Saving PR_Hdr (Goods)
                prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
                prhdr.PR_Date = "01/01/1900"
                prhdr.RC_ID = ddRC.SelectedItem.Value
                prhdr.Function_ID = ddFunction.SelectedItem.Value
                prhdr.remarks = txtpurpose.Text
                prhdr.Transaction_type = ddnature.SelectedItem.Value
                prhdr.Project_ID = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Project_ID")
                prhdr.Program_id = PAPS.Rows(ddPAPS.SelectedIndex - 1)("Program_id")
                prhdr.ABC = FormatNumber(pBody.Compute("sum(total)", ""), 2)
                prhdr.Requestedby = ddRequestedBy.SelectedItem.Value
                'prhdr.Approvedby = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text) 'Mayor's EmpID
                prhdr.Approvedby = ddApprovedBy.SelectedItem.Value
                prhdr.Date_Submitted = Date.Today.ToString("MM/dd/yyyy")
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
                prhdr.isContinuing = 0
                prhdr.mode_of_procurement_id = 0
                prhdr.isTrustFund = False
                prhdr.GA_ID = Session("GA_ID")
                prhdr.UserID = Session("@UserName")
                prhdr.CheckBy = ddCheckedBy.SelectedItem.Value
                prhdr.NotedBy = ddNotedBy.SelectedItem.Value
                prhdrID = prhdr.save
                Session("PRNo") = prhdrID
                Session("prhdr_id") = prhdrID

                Dim CTO As Integer
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = '" & rbTrustFund.SelectedItem.Value & "', CityTreasurer = '" & CTO & "' WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

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
                        prdtl.Qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text 'CType(gvbody.Rows(i).FindControl("lblBalance"), Label).Text() 
                        prdtl.Cost = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                        prdtl.ppmp_dtl_id = pBody.Rows(i)("ppmp_dtl_id")

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

                Session("edit_pr") = False

            Else
                '======== PR_HDR Edit ========     
                Dim CTO As Integer
                CTO = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = 10 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)

                objDerived.GetRecords("UPDATE ams.pr_hdr SET ABC = '" & pBody.Compute("sum(total)", "") & "', remarks = '" & replaceapostrophe(txtpurpose.Text) & "', " & _
                                " Requestedby = '" & ddRequestedBy.SelectedItem.Value & "', CityTreasurer = '" & CTO & "', " & _
                                " CheckBy = '" & ddCheckedBy.SelectedItem.Value & "', NotedBy = '" & ddNotedBy.SelectedItem.Value & "' WHERE prhdr_id='" & gvListPR.SelectedDataKey(0) & "' ", CommandType.Text)


                Session("PRNo") = gvListPR.SelectedDataKey(0)
                Session("prhdr_id") = gvListPR.SelectedDataKey(0)


                '======== PR_Dtl Edit ======== 
                Session("PRNo") = gvListPR.SelectedDataKey(0)
                Dim origcount As Integer = Me.Session("row_num_edit")
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    Dim Qty As Decimal = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text()
                    Dim Cost As Decimal = CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).Text
                    Dim dtPRdtl As New DataTable

                    dtPRdtl = objDerived.GetDataTable("Select * from AMS.PR_Dtl where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    If dtPRdtl.Rows.Count = 0 Then
                        objDerived.Execute("INSERT INTO AMS.PR_Dtl (PRHdr_ID,Item_ID,Project_title,Qty,Cost,ppmp_dtl_id) values('" & gvListPR.SelectedDataKey(0) & "','" & pBody.Rows(i)("Item_ID") & "','" & txtpurpose.Text & "','" & Qty & "','" & Cost & "','" & pBody.Rows(i)("ppmp_dtl_id") & "')", CommandType.Text)
                    Else
                        objDerived.GetRecords("Update AMS.PR_Dtl set Qty ='" & Qty & "',Project_title = '" & txtpurpose.Text & "', Cost = '" & Cost & "' where prhdr_id='" & gvListPR.SelectedDataKey(0) & "' and Item_ID ='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                    End If
                Next

                Session("edit_pr") = False

            End If

            Dim data As New DataTable
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            UploadButton.Enabled = False

            btnSave.Enabled = False
            txtpurpose.ReadOnly = True
            txtOBRpurpose.ReadOnly = True
            LinkButton2.Enabled = False
            btnpreview.Enabled = True

            gvbody.DataSource = createdatatable1(19)
            gvbody.DataBind()

            ddRC.Enabled = False
            ddFunction.Enabled = False
            ddPAPS.Enabled = False

            Me.txtpurpose.Text = ""
            Me.txtOBRpurpose.Text = ""

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
        End Try
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CheckPR As String = objDerived.GetValue("SELECT ISNULL([pr_no],'0') FROM [AMS].[PR_Hdr] WHERE [prhdr_id] = '" & Session("prhdr_id") & "'", CommandType.Text)
        If CheckPR = "0" Then
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, Date_Submitted = '" & Date.Today.ToString("MM/dd/yyyy") & "' WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        Else
            objDerived.GetRecords("UPDATE AMS.PR_Hdr SET isFinal = 1, [IsApproved] = 1 WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)
        End If

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Purchase Request has been submitted.")
        btnSubmit.Enabled = False

    End Sub
    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Session("Page") = "PR"
        Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")
    End Sub
    Protected Sub gvListPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListPR.SelectedIndexChanged
        If IsDBNull(gvListPR.SelectedDataKey(0)) = True Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select purchase request transaction.")
            Exit Sub

        Else
            Try
                If Lbtn = "PR" Then
                    Session("PRNo") = gvListPR.SelectedDataKey(0)
                    Session("isGasoline") = False
                    Dim url As String = "rpt_purchase_request_pop_up.aspx?"
                    Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

                ElseIf Lbtn = "ObR" Then
                    Session("obr_id") = gvListPR.SelectedDataKey(1)
                    Dim url As String = "rpt_ObR_pop_up.aspx?"
                    Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
                    ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

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
                    Me.Session("edit_pr") = True

                    ddRC.Enabled = False
                    ddFunction.Enabled = False
                    ddAccounts.Enabled = False

                    datahdr = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_hdr " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
                    ddnature.SelectedValue = datahdr.Rows(0)("Transaction_type")

                    txtpurpose.Text = datahdr.Rows(0)("remarks")
                    txtOBRpurpose.Text = datahdr.Rows(0)("OBR_Title")
                    txtOBRpurpose.ReadOnly = False

                    Dim PPAname As DataTable
                    PPAname = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project_Edit_PR " & Me.ddRC.SelectedItem.Value & ",'" & Year(CDate(txtprdate.Text)) & "'," & ddFunction.SelectedItem.Value & ",0," & datahdr.Rows(0)("Project_ID") & "," & datahdr.Rows(0)("Program_id") & "", CommandType.Text)
                    Dim c
                    c = PPAname.Rows(0)("description")

                    Me.ddPAPS.SelectedValue = PPAname.Rows(0)("description")

                    txtpeyee.Text = datahdr.Rows(0)("Payee")
                    txtaddpeyee.Text = datahdr.Rows(0)("Address")
                    porgibody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)

                    pBody = objDerived.GetDataTable("exec ams.sp_edit_purchase_request_detail " & gvListPR.SelectedDataKey(0) & "", CommandType.Text)
                    gvbody.DataSource = pBody
                    gvbody.DataBind()

                    Me.Session("origbody") = pBody
                    Me.Session("row_num_edit") = pBody.Rows.Count - 1

                    Dim AllotmentClass_ID As Integer
                    If ddnature.SelectedIndex <> 3 Then
                        AllotmentClass_ID = ddnature.SelectedItem.Value
                    Else
                        AllotmentClass_ID = 3
                    End If

                    Session("AllotmentClass_ID") = AllotmentClass_ID

                    Dim a1, a2, a3, a4, a5, a6, a7
                    a1 = datahdr.Rows(0)("RC_ID")
                    a2 = datahdr.Rows(0)("Function_ID")
                    a3 = datahdr.Rows(0)("project_ID")
                    a4 = datahdr.Rows(0)("program_id")
                    a5 = Year(CDate(txtprdate.Text))
                    a6 = gvListPR.SelectedDataKey(0)
                    a7 = datahdr.Rows(0)("isContinuing")

                    Session("project_ID") = datahdr.Rows(0)("project_ID")
                    Session("program_id") = datahdr.Rows(0)("program_id")

                    p_GA_ID = objDerived.GetDataTable("SELECT T_OBR_Dtl.GA_ID, T_OBR_Dtl.BGA_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Dtl as T_OBR_Dtl INNER JOIN LnkdSrvrBOSS.GEOBOS.BOS.T_OBR_Hdr as T_OBR_Hdr ON T_OBR_Dtl.OBR_Hdr_ID = T_OBR_Hdr.OBR_Hdr_ID INNER JOIN AMS.PR_Hdr ON T_OBR_Hdr.PRHdr_ID = AMS.PR_Hdr.prhdr_id WHERE     AMS.PR_Hdr.prhdr_id = '" & gvListPR.SelectedDataKey(0) & "'", CommandType.Text)
                    Me.Session("row_ p_GA_ID_edit") = p_GA_ID.Rows.Count - 1

                    Session("Edit") = 1
                    If ddnature.SelectedIndex = 1 Then '[AMS].[sp_supplies_for_pr_EDIT2]
                        pitems = objDerived.GetDataTable("exec [AMS].[sp_supplies_for_pr_EDIT2] '" & Year(CDate(txtprdate.Text)) & "','" & datahdr.Rows(0)("RC_ID") & "','" & datahdr.Rows(0)("function_ID") & "','" & datahdr.Rows(0)("project_id") & "','" & datahdr.Rows(0)("program_id") & "','" & 0 & "',0,'" & Session("GA_ID") & "'", CommandType.Text)

                        LinkButton2.Enabled = True
                        lbmeals.Enabled = False
                        If datahdr.Rows(0)("isReimbursement") = True Then
                            cbReinbursement.Enabled = False
                            RequiredFieldValidator11.Enabled = True
                            RequiredFieldValidator12.Enabled = True
                            txtpeyee.Enabled = True
                            txtaddpeyee.Enabled = True
                        Else
                            cbReinbursement.Enabled = True
                            RequiredFieldValidator11.Enabled = False
                            RequiredFieldValidator12.Enabled = False
                            txtpeyee.Enabled = False
                            txtaddpeyee.Enabled = False

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
                            txtpeyee.Enabled = True
                            txtaddpeyee.Enabled = True
                        Else
                            cbReinbursement.Enabled = True
                            RequiredFieldValidator11.Enabled = False
                            RequiredFieldValidator12.Enabled = False
                            txtpeyee.Enabled = False
                            txtaddpeyee.Enabled = False
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

                    CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pBody.Compute("sum(total)", ""), 2)

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

                    Dim dtDoc As New DataTable
                    dtDoc = objDerived.GetDataTable("SELECT * FROM AMS.DocumentAttachment WHERE TableName = 'PR' AND IdentityNo = '" & Session("prhdr_id") & "'", CommandType.Text)
                    If dtDoc.Rows.Count < 5 Then
                        dtDoc.Merge(createdatatable9(4 - dtDoc.Rows.Count))
                    End If

                    btnSave.Enabled = True

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


    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


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
