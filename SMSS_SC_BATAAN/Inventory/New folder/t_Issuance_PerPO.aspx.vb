Imports System.Data

Partial Class Inventory_t_Issuance_PerPO
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private dtl As New RISDtl
    Private hdr As New RISHdr
    Private objMREHdr As New MREHdr
    Private objMREDtl As New MREDtl
    Private objMREReturn As New MRE_Return
    Dim objLedger As New t_PropertyLedger
    Dim Ledger_ID As New Integer
    Dim dtPropLedger As New DataTable

    Dim Return_Hdr As New Returned_History.ARE_Returned_History_Hdr
    Dim Return_Dtl As New Returned_History.ARE_Returned_History_Dtl
    Dim objDonationLedger As New ConsolidatedPropertySaving.TbDonation_Ledger
    Dim DonationLedger_ID As New Integer
    Dim dtDonationLedger As New DataTable


#Region "Property"
    Private Property dtPOList() As DataTable
        Get
            Return CType(Session("dtPOList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPOList") = value
        End Set
    End Property


    Public Function Createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim mycolumn As New DataColumn
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("ContractPrice", GetType(Decimal))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("Received_ID", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("POHdr_ID") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("ContractPrice") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("Received_ID") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            PageLoad()
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub PageLoad()
        btnRIS.CssClass = "Initial"
        btnARE.CssClass = "Initial"
        btnPerPO.CssClass = "Clicked"

        dtPOList = objDerived.GetDataTable("[AMS].[sp_POList_Issuance]", CommandType.Text)
        If dtPOList.Rows.Count < 10 Then
            dtPOList.Merge(Createdatatable1(9 - dtPOList.Rows.Count))
        End If
        grdPOList.DataSource = dtPOList
        grdPOList.DataBind()

        'grdPO_Items.DataSource = Nothing
        'grdPO_Items.DataBind()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtPOList.DefaultView
        myview.RowFilter = "PO_No like '%" & txtSearch.Text & "%'"
        grdPOList.DataSource = myview
        grdPOList.DataBind()

    End Sub

    Protected Sub grdPOList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        grdPOList.DataSource = dtPOList
        grdPOList.PageIndex = e.NewPageIndex
        grdPOList.DataBind()

    End Sub

    Protected Sub grdPOList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPOList, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdPOList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdPO_Items.DataSource = objDerived.GetDataTable("[AMS].[sp_Issuance_POItemList] '" & grdPOList.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        grdPO_Items.DataBind()

        CheckBox3.Enabled = True

        ddFromDepartment.Items.Clear()
        ddFromDepartment.DataSource = objDerived.GetDataTable("Select * from dbo.View_RespCenter_withFunctions where RC_ID = 7", CommandType.Text)
        ddFromDepartment.DataTextField = ("RC_Name")
        ddFromDepartment.DataValueField = ("RC_ID")
        ddFromDepartment.DataBind()
        ddFromDepartment.Items.Insert(0, "Select")

        ddFromProperty.Items.Clear()
        ddFromProperty.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE (deptid = 7) AND (isDeptHead = 'Yes')", CommandType.Text)
        ddFromProperty.DataTextField = ("full_name")
        ddFromProperty.DataValueField = ("empid")
        ddFromProperty.DataBind()
        ddFromProperty.Items.Insert(0, "Select")

        ddByDepartment.Items.Clear()
        ddByDepartment.DataSource = objDerived.GetDataTable("Select * from  dbo.View_RespCenter_withFunctions where Function_ID = 86 order by RC_Name", CommandType.Text)
        ddByDepartment.DataTextField = ("RC_Name")
        ddByDepartment.DataValueField = ("RC_Id")
        ddByDepartment.DataBind()
        ddByDepartment.Items.Insert(0, "Select")
    End Sub

    Protected Sub btnsavedoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '=== UPDATE PROPERTY DETAILS AND SAVE ARE INFORMATION ===
            objDerived.GetRecords("[AMS].[sp_Save_ARE_PerPO] '" & grdPOList.SelectedDataKey("Received_ID") & "','" & txtDateReceivedFrom.Text & "','" & ddByDepartment.SelectedItem.Value & "','" & ddFromProperty.SelectedItem.Value & "','" & ddByAcknowledgement.SelectedItem.Value & "','" & txtMRE.Text & "'", CommandType.Text)

            Session("MREHdr_ID") = objDerived.GetValue("SELECT MREHdr_ID FROM AMS.MRE_Hdr WHERE MRENumber = '" & txtMRE.Text & "'", CommandType.Text)

            '=== SAVE RIS INFORMATION ===
            Dim RIS_Series As String
            RIS_Series = objDerived.GetValue("select AMS.func_GenerateRIS('" & txtDateReceivedFrom.Text & "')", CommandType.Text)
            Session("ris_no") = "PPE-" & RIS_Series

            objDerived.GetRecords("[AMS].[sp_Save_RIS_perPO] '" & grdPOList.SelectedDataKey("Received_ID") & "','" & Session("ris_no") & "','" & txtDateReceivedFrom.Text & "','" & ddByAcknowledgement.SelectedItem.Text & "','" & ddFromProperty.SelectedItem.Text & "','" & ddByAcknowledgement.SelectedItem.Text & "','" & ddByDepartment.SelectedItem.Value & "'", CommandType.Text)

            '=== SAVE PROPERTY LEDGER ===
            objDerived.GetDataTable("[AMS].[sp_Save_Issuance_PropertyLedger_PerPO] '" & txtMRE.Text & "','" & txtDateReceivedFrom.Text & "','" & ddByAcknowledgement.SelectedItem.Text & "','" & ddByDepartment.SelectedItem.Text & "','" & grdPOList.SelectedDataKey("Received_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnpreviewAreDoc.Enabled = True
            btnPreviewRIS.Enabled = True

            PageLoad()
            txtMRE.Text = ""
            ddFromDepartment.SelectedIndex = 0
            ddFromProperty.SelectedIndex = 0
            txtDateReceivedFrom.Text = ""
            ddByDepartment.SelectedIndex = 0
            ddByAcknowledgement.SelectedIndex = 0
            txtDateReceivedBy.Text = ""
            btnsavedoc.Enabled = False
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Error occured while saving, contact administrator.")
        End Try
    End Sub

    Protected Sub btncancelDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/Inventory/t_Issuance_PerPO.aspx")
    End Sub

    Protected Sub btnpreviewAreDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnpreviewAreDoc.Text = "PREVIEW PRS" Then
            'Me.Page.Response.Redirect("~/Inventory/t_rpt_return_slip.aspx")

            Dim url As String = "t_rpt_return_slip.aspx?"
            Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        ElseIf btnpreviewAreDoc.Text = "PREVIEW PARE" Then
            ' Me.Page.Response.Redirect("~/Inventory/t_rpt_acknowledgement_receipt.aspx")


            Dim url As String = "t_rpt_acknowledgement_receipt.aspx?"
            Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
        End If
    End Sub

    Protected Sub btnPreviewRIS_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Page.Response.Redirect("~/Inventory/t_rpt_requisition_and_issuance.aspx")
        Session("Page") = "INV"
        Session("Report") = "RIS"
        'Me.Page.Response.Redirect("~/MainReports/Inventory_Reports.aspx")

        Dim url As String = "Inventory_Reports.aspx?"
        Dim fullURL As String = "window.open('" & url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

    Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Session("OLDInventory") = True
        Dim mayor As String = "CITY MAYOR"
        ddPrevMayor.DataSource = objDerived.GetDataTable("SELECT * FROM [HRMS].[view_signatory] WHERE deptid = 1 AND division_key = 86 AND position_desc like '" & mayor & "'", CommandType.Text)
        ddPrevMayor.DataTextField = ("full_name")
        ddPrevMayor.DataValueField = ("empid")
        ddPrevMayor.DataBind()
        ddPrevMayor.Items.Insert(0, "Select")

        If CheckBox3.Checked = True Then

            ModalPopupExtender2.Show()
        End If

        txtMRE.ReadOnly = False
    End Sub

    Protected Sub ddByDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As String = ddByDepartment.SelectedItem.Text
        ddByAcknowledgement.Items.Clear()

        ddByAcknowledgement.DataSource = objDerived.GetDataTable("Exec dbo.sp_Signatories '" & ddByDepartment.SelectedValue & "'", CommandType.Text)
        ddByAcknowledgement.Items.Add("Select")
        ddByAcknowledgement.DataTextField = ("full_name")
        ddByAcknowledgement.DataValueField = ("empid")
        ddByAcknowledgement.DataBind()
    End Sub

    Protected Sub txtDateReceivedFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtMRE.Text = objDerived.GetValue("select AMS.func_GenerateMRE('" & txtDateReceivedFrom.Text & "')", CommandType.Text)
        btnsavedoc.Enabled = True
    End Sub

    Protected Sub txtDateReceivedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ddPrevMayor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("ApprovedBy") = ddPrevMayor.SelectedItem.Text
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub grdPO_Items_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdPO_Items.DataSource = objDerived.GetDataTable("[AMS].[sp_Issuance_POItemList] '" & grdPOList.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        grdPO_Items.PageIndex = e.NewPageIndex
        grdPO_Items.DataBind()
    End Sub

    Protected Sub btnRIS_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("TabSelection") = "RIS"
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
    End Sub

    Protected Sub btnARE_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("TabSelection") = "PARE"
        Me.Page.Response.Redirect("~/Inventory/t_RequisitionAndIssunace.aspx")
    End Sub


End Class
