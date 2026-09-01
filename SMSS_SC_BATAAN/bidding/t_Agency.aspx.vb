Imports System.Data


Partial Class bidding_t_Agency
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private hdr As New t_canvass_hdr
    Private dtl As New t_canvass_dtl
    Dim hdr2 As New t_obr_evaluation_hdr
    Dim dtl2 As New t_obr_evaluation_dtl

    Private cnvss_hdr As New Consolidated_Canvass.m_Canvass_Hdr
    Private cnvss_dtl1 As New Consolidated_Canvass.m_Canvass_Dtl1
    Private cnvss_dtl2 As New Consolidated_Canvass.m_Canvass_Dtl2
    Private cnvss_PR1 As New Consolidated_Canvass.m_Canvass_Dtl_PR1
    Private cnvss_PR2 As New Consolidated_Canvass.m_Canvass_Dtl_PR2

#Region "property"
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property
    Private Property pProjectReference() As DataTable
        Get
            Return CType(Session("pProjectReference"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProjectReference") = value
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
    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property
    Private Property pSupplier() As DataTable
        Get
            Return CType(Session("pSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pSupplier") = value
        End Set
    End Property
    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property
    Private Property pPurchase_Order_detail() As DataTable
        Get
            Return CType(Session("pPurchase_Order_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_detail") = value
        End Set
    End Property
    Private Property dtAgency() As DataTable
        Get
            Return CType(Session("dtAgency"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAgency") = value
        End Set
    End Property
#End Region
#Region "Functions"

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("DateApproved", GetType(Date))
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("ABC") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("DateApproved") = DBNull.Value
            dr("prhdr_id") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt


    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtAgency = objDerived.GetDataTable("EXEC [AMS].[sp_AgencyProcurement]", CommandType.Text)
            If dtAgency.Rows.Count < 8 Then
                dtAgency.Merge(createdatatable1(7 - dtAgency.Rows.Count))
            End If
            grdAgency.DataSource = dtAgency
            grdAgency.DataBind()

            grdAgencyItems.DataSource = Nothing
            grdAgencyItems.DataBind()

            Me.MultiView1.SetActiveView(Me.View1)
            Session("SearchDC") = "PRNumber"
            Session("page") = "canvass"


            txtPRNo.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPRNumb.ClientID & "')")
            txtOBR.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchOBR.ClientID & "')")
        End If
    End Sub


    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnviewAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub grdAgency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        dtItems = objDerived.GetDataTable("SELECT * FROM [dbo].[View_DC_ItemList] WHERE prhdr_id = '" & grdAgency.SelectedDataKey("prhdr_id") & "'", CommandType.Text)
        grdAgencyItems.DataSource = dtItems
        grdAgencyItems.DataBind()

        Dim cb As CheckBox
        For i As Long = 0 To Me.grdAgencyItems.Rows.Count - 1
            cb = CType(Me.grdAgencyItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            cb.Checked = True
        Next

        LoadtxtCostItems()

        ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier WHERE Supplier_ID = 30517", CommandType.Text)
        ddSupplier.DataTextField = ("SuppName")
        ddSupplier.DataValueField = ("Supplier_Id")
        ddSupplier.DataBind()

        btnsupplier.Enabled = True
    End Sub

    Protected Sub txtCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtCost As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txtCost.NamingContainer, GridViewRow)
        If txtCost.Text = "" Then
            txtCost.Text = 0
        End If
        txtCost.Text = FormatNumber(txtCost.Text, 2)

        LoadtxtCostItems()
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnsupplier.Enabled = True
    End Sub


    Protected Sub btnSaveBACReso_Click(sender As Object, e As EventArgs) Handles btnSaveBACReso.Click
        Try
            If txtBACResoNo.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "BAC resolution is required.")

            Else
                Dim cb As CheckBox
                '=-= SAVE HEADER "AMS.m_Canvass_Hdr"
                With cnvss_hdr
                    .Hdr_ID = 0
                    .Canvass_Date = txtDate.Text
                    .PR_Hdr_ID = grdAgency.SelectedDataKey("prhdr_id")
                    .withWinner = True
                    .isDBM = True
                End With

                Dim Hdr_ID As Long
                Hdr_ID = objDerived.GetValue("SELECT Hdr_ID FROM AMS.m_Canvass_Hdr WHERE PR_Hdr_ID = '" & grdAgency.SelectedDataKey("prhdr_id") & "' AND isDBM = 0", CommandType.Text)

                If Hdr_ID = 0 Then
                    Session("Hdr_ID") = cnvss_hdr.save()
                Else
                    Session("Hdr_ID") = Hdr_ID
                End If

                Dim BAC1 As Long = objDerived.GetValue("SELECT empsig_id FROM dbo.View_BAC WHERE isDefault = 1 AND isActive = 1 AND BAC_PostionID = 3", CommandType.Text)
                Dim BAC2 As Long = objDerived.GetValue("SELECT empsig_id FROM dbo.View_BAC WHERE isDefault = 1 AND isActive = 1 AND BAC_PostionID = 4", CommandType.Text)
                Dim BAC3 As Long = objDerived.GetValue("SELECT empsig_id FROM dbo.View_BAC WHERE isDefault = 1 AND isActive = 1 AND BAC_PostionID = 5", CommandType.Text)
                Dim BACC As Long = objDerived.GetValue("SELECT empsig_id FROM dbo.View_BAC WHERE isDefault = 1 AND isActive = 1 AND BAC_PostionID = 1", CommandType.Text)
                Dim BACVC As Long = objDerived.GetValue("SELECT empsig_id FROM dbo.View_BAC WHERE isDefault = 1 AND isActive = 1 AND BAC_PostionID = 2", CommandType.Text)
                Dim ApprovedBy As Long = objDerived.GetValue("SELECT empsig_id FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes' AND isActive = 1", CommandType.Text)

                objDerived.Execute("UPDATE AMS.m_Canvass_Hdr SET isApproved = 1, DateApproved = '" & txtDate.Text & "' " &
                                " , BAC1 = '" & BAC1 & "', BAC2 = '" & BAC2 & "', BAC3 = '" & BAC3 & "', BACVC = '" & BACVC & "', BACC = '" & BACC & "', ApprovedBy = '" & ApprovedBy & "' " &
                                " , Abstract_No = '" & txtBACResoNo.Text & "' WHERE Hdr_ID = '" & Session("Hdr_ID") & "'", CommandType.Text)


                '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR1" 
                With cnvss_PR1
                    .Dtl_ID_PR1 = 0
                    .Hdr_ID = Session("Hdr_ID")
                    .Supplier_ID = ddSupplier.SelectedItem.Value
                    .isWinner = True
                End With

                Dim Dtl_ID_PR1 As Long = cnvss_PR1.save()
                Session("Dtl_ID_PR1") = Dtl_ID_PR1
                objDerived.GetRecords("UPDATE AMS.m_Canvass_Dtl_PR1 SET withPO = 0 WHERE Dtl_ID_PR1 = '" & Session("Dtl_ID_PR1") & "'", CommandType.Text)

                '=-= SAVE DETAIL "AMS.m_Canvass_Dtl_PR2" 
                For i As Integer = 0 To grdAgencyItems.Rows.Count - 1
                    cb = CType(Me.grdAgencyItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        Dim CanvassPrice As Decimal = CType(CType(grdAgencyItems.Rows(i).FindControl("txtCost"), TextBox).Text, Decimal)
                        Dim CanvassQty As Decimal = CType(CType(grdAgencyItems.Rows(i).FindControl("lblqty"), Label).Text, Decimal)

                        With cnvss_PR2
                            .Dtl_ID_PR2 = 0
                            .Dtl_ID_PR1 = Session("Dtl_ID_PR1")
                            .Item_ID = dtItems.Rows(i)("Item_ID")
                            .UnitPrice = CanvassPrice
                            .Quantity = CanvassQty
                            .save()
                        End With
                    End If
                Next

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been successfully saved.")

                Session("prhdr_id") = grdAgency.SelectedDataKey("prhdr_id")
                Session("Report") = "BACResolution"
                txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

                dtAgency = objDerived.GetDataTable("EXEC [AMS].[sp_AgencyProcurement]", CommandType.Text)
                If dtAgency.Rows.Count < 8 Then
                    dtAgency.Merge(createdatatable1(7 - dtAgency.Rows.Count))
                End If
                grdAgency.DataSource = dtAgency
                grdAgency.DataBind()

                grdAgencyItems.DataSource = Nothing
                grdAgencyItems.DataBind()

                btnsupplier.Enabled = False
                btnPreview.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ModalPopupExtender2.Show()
    End Sub

    Protected Sub cbALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadtxtCostItems()
    End Sub
    Protected Sub LoadtxtCostItems()
        Dim x As Decimal
        Dim cb As CheckBox

        For i As Integer = 0 To grdAgencyItems.Rows.Count - 1
            cb = CType(Me.grdAgencyItems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim txtCost As TextBox = CType(grdAgencyItems.Rows(i).FindControl("txtcost"), TextBox)
                Dim lblqty As Label = CType(grdAgencyItems.Rows(i).FindControl("lblqty"), Label)

                Dim Tcost As Decimal = FormatNumber(txtCost.Text * lblqty.Text, 2)

                CType(grdAgencyItems.Rows(i).FindControl("lbltotalx"), Label).Text = Tcost
                x = x + (txtCost.Text * lblqty.Text)
            Else
                CType(grdAgencyItems.Rows(i).FindControl("lbltotalx"), Label).Text = "0.00"
            End If
        Next

        CType(grdAgencyItems.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(x, 2)

    End Sub

    Protected Sub ddSearchDC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddSearchDC.SelectedItem.Value = 1 Then
            Me.MultiView1.SetActiveView(Me.View1)
            Session("SearchDC") = "PRNumber"

        ElseIf ddSearchDC.SelectedItem.Value = 2 Then
            Me.MultiView1.SetActiveView(Me.View2)
            Session("SearchDC") = "Department"

            ddDept.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name, RC_ID FROM [dbo].[View_RespCenter_withFunctions] ORDER BY RC_Name", CommandType.Text) '("SELECT * FROM HRMS.vw_m_department order BY deptdesc", CommandType.Text)
            ddDept.DataTextField = ("RC_Name")
            ddDept.DataValueField = ("RC_ID")
            ddDept.DataBind()
            ddDept.Items.Insert(0, "Select")

        ElseIf ddSearchDC.SelectedItem.Value = 3 Then
            Me.MultiView1.SetActiveView(Me.View3)
            Session("SearchDC") = "OBRNumber"

        End If

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub btnSearchPRNumb_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtAgency.DefaultView
        myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtPRNo.Text.ToString) & "%'"
        grdAgency.DataSource = myview
        grdAgency.DataBind()
        grdAgency.PageIndex = 0

        grdAgencyItems.DataSource = Nothing
        grdAgencyItems.DataBind()
    End Sub

    Protected Sub btnSearchDept_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtAgency.DefaultView
        myview.RowFilter = "RC_ID =  '" & ddDept.SelectedItem.Value & "'"
        grdAgency.DataSource = myview
        grdAgency.DataBind()
        grdAgency.PageIndex = 0

        grdAgencyItems.DataSource = Nothing
        grdAgencyItems.DataBind()
    End Sub

    Protected Sub btnSearchOBR_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtAgency.DefaultView
        myview.RowFilter = "OBR_No like '%" & replaceapostrophe(txtOBR.Text.ToString) & "%'"
        grdAgency.DataSource = myview
        grdAgency.DataBind()
        grdAgency.PageIndex = 0

        grdAgencyItems.DataSource = Nothing
        grdAgencyItems.DataBind()
    End Sub

    Protected Sub grdAgency_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdAgency.DataSource = dtAgency
        grdAgency.PageIndex = e.NewPageIndex
        grdAgency.DataBind()

        grdAgencyItems.DataSource = Nothing
        grdAgencyItems.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Action") = "PRNumber"
    End Sub

    Protected Sub lbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session("Action") = "Cancel"
    End Sub

    Protected Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'Me.Page.Response.Redirect("~/bidding/rpt_AlternativeMode.aspx")
        Session("Page") = "Agency"
        Me.Page.Response.Redirect("~/MainReports/Agency_Reports.aspx")

    End Sub
End Class
