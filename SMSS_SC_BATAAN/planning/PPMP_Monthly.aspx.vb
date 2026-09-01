Imports System.Data
'Imports System


Partial Class planning_PPMP_Monthly
    Inherits System.Web.UI.Page
    Dim AuditTrail As New Audit_Trail
    Dim objDerived As New DerivedDal
    Dim ppmp_hdr As New PPMP_Monthly.t_ppmp_hdr
    Dim ppmp_dtl As New PPMP_Monthly.t_ppmp_dtl
    Dim ppmp_revision As New PPMP_Monthly.t_ppmp_revision
    Dim hdr As New t_ppmp_hdr_monthly
    Dim dtl As New t_ppmp_dtl_monthly
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim AvailableBuget As Decimal
    Dim TotalQty As Decimal



#Region "Variable"
    Private Property withApprovedBudget() As Boolean
        Get
            Return CType(Session("withApprovedBudget"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("withApprovedBudget") = value
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

    Private Property dtYear() As DataTable
        Get
            Return CType(Session("dtYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtYear") = value
        End Set
    End Property

    Private Property dtPreparedBy() As DataTable
        Get
            Return CType(Session("dtPreparedBy"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPreparedBy") = value
        End Set
    End Property

    Private Property dtDepartments() As DataTable
        Get
            Return CType(Session("dtDepartments"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDepartments") = value
        End Set
    End Property

    Private Property dtPPA() As DataTable
        Get
            Return CType(Session("dtPPA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPPA") = value
        End Set
    End Property
    Private Property dtAccounts() As DataTable
        Get
            Return CType(Session("dtAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAccounts") = value
        End Set
    End Property
    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property

    Private Property dtItemLoaded() As DataTable
        Get
            Return CType(Session("dtItemLoaded"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemLoaded") = value
        End Set
    End Property

    Private Property dtMonthly() As DataTable
        Get
            Return CType(Session("dtMonthly"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtMonthly") = value
        End Set
    End Property

    Private Property dtMonthlyAmt() As DataTable
        Get
            Return CType(Session("dtMonthlyAmt"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtMonthlyAmt") = value
        End Set
    End Property

    Private Property strAction() As String
        Get
            Return CType(Session("strAction"), String)
        End Get
        Set(ByVal value As String)
            Session("strAction") = value
        End Set
    End Property

    Private Property TotallQty_Postback() As String
        Get
            Return CType(Session("TotallQty_Postback"), String)
        End Get
        Set(ByVal value As String)
            Session("TotallQty_Postback") = value
        End Set
    End Property

    Private Property str_PPA() As String
        Get
            Return CType(Session("str_PPA"), String)
        End Get
        Set(ByVal value As String)
            Session("str_PPA") = value
        End Set
    End Property

    Private Property str_OOE() As String
        Get
            Return CType(Session("str_OOE"), String)
        End Get
        Set(ByVal value As String)
            Session("str_OOE") = value
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
    Private Property pYear() As DataTable
        Get
            Return CType(Session("pYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pYear") = value
        End Set
    End Property
    Private Property PPMPSaved() As Decimal
        Get
            Return CType(Session("PPMPSaved"), Decimal)
        End Get
        Set(ByVal value As Decimal)
            Session("PPMPSaved") = value

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
#End Region
#Region "Datatables"
    Public Sub CreateDataTableQty()
        Me.dtMonthly = New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dtMonthly.Columns.Add("Jan")
        dtMonthly.Columns.Add("JanAmt")
        dtMonthly.Columns.Add("Feb")
        dtMonthly.Columns.Add("FebAmt")
        dtMonthly.Columns.Add("Mar")
        dtMonthly.Columns.Add("MarAmt")
        dtMonthly.Columns.Add("Apr")
        dtMonthly.Columns.Add("AprAmt")
        dtMonthly.Columns.Add("May")
        dtMonthly.Columns.Add("MayAmt")
        dtMonthly.Columns.Add("Jun")
        dtMonthly.Columns.Add("JunAmt")
        dtMonthly.Columns.Add("Jul")
        dtMonthly.Columns.Add("JulAmt")
        dtMonthly.Columns.Add("Aug")
        dtMonthly.Columns.Add("AugAmt")
        dtMonthly.Columns.Add("Sep")
        dtMonthly.Columns.Add("SepAmt")
        dtMonthly.Columns.Add("Oct")
        dtMonthly.Columns.Add("OctAmt")
        dtMonthly.Columns.Add("Nov")
        dtMonthly.Columns.Add("NovAmt")
        dtMonthly.Columns.Add("Dec")
        dtMonthly.Columns.Add("DecAmt")
        dtMonthly.Columns.Add("RQty")
        dtMonthly.Columns.Add("RQtyAmt")

        dr = dtMonthly.NewRow
        dr("Jan") = 0
        dr("JanAmt") = "0.00"
        dr("Feb") = 0
        dr("FebAmt") = "0.00"
        dr("Mar") = 0
        dr("MarAmt") = "0.00"
        dr("Apr") = 0
        dr("AprAmt") = "0.00"
        dr("May") = 0
        dr("MayAmt") = "0.00"
        dr("Jun") = 0
        dr("JunAmt") = "0.00"
        dr("Jul") = 0
        dr("JulAmt") = "0.00"
        dr("Aug") = 0
        dr("AugAmt") = "0.00"
        dr("Sep") = 0
        dr("SepAmt") = "0.00"
        dr("Oct") = 0
        dr("OctAmt") = "0.00"
        dr("Nov") = 0
        dr("NovAmt") = "0.00"
        dr("Dec") = 0
        dr("DecAmt") = "0.00"
        dr("RQty") = 0
        dr("RQtyAmt") = "0.00"
        dtMonthly.Rows.Add(dr)


    End Sub

    Public Sub CreateDataTableAmt()
        Me.dtMonthly = New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dtMonthly.Columns.Add("JanAmt")
        dtMonthly.Columns.Add("FebAmt")
        dtMonthly.Columns.Add("MarAmt")
        dtMonthly.Columns.Add("AprAmt")
        dtMonthly.Columns.Add("MayAmt")
        dtMonthly.Columns.Add("JunAmt")
        dtMonthly.Columns.Add("JulAmt")
        dtMonthly.Columns.Add("AugAmt")
        dtMonthly.Columns.Add("SepAmt")
        dtMonthly.Columns.Add("OctAmt")
        dtMonthly.Columns.Add("NovAmt")
        dtMonthly.Columns.Add("DecAmt")
        dtMonthly.Columns.Add("RQtyAmt")

        dr = dtMonthly.NewRow
        dr("JanAmt") = "0.00"
        dr("FebAmt") = "0.00"
        dr("MarAmt") = "0.00"
        dr("AprAmt") = "0.00"
        dr("MayAmt") = "0.00"
        dr("JunAmt") = "0.00"
        dr("JulAmt") = "0.00"
        dr("AugAmt") = "0.00"
        dr("SepAmt") = "0.00"
        dr("OctAmt") = "0.00"
        dr("NovAmt") = "0.00"
        dr("DecAmt") = "0.00"
        dr("RQtyAmt") = "0.00"
        dtMonthly.Rows.Add(dr)

    End Sub

    Public Function DataTableBody(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Decimal))
        dt.Columns.Add("UnitPrice", GetType(Decimal))
        dt.Columns.Add("TotalAmt", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("ppmp_monthly_dtl_ID", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ID") = 0
            dr("Item_Desc") = ""
            dr("Unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("UnitPrice") = DBNull.Value
            dr("TotalAmt") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("ppmp_monthly_dtl_ID") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region



    Private Sub planning_PPMP_Monthly_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True

        If Not Page.IsPostBack Then

            obj.GetAccessRight(Me.Session("@username"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
            End If

            Dim usr As MembershipUser = Membership.GetUser(Me.Session("@UserName").ToString)
            Dim role() As String = Roles.GetRolesForUser(usr.UserName)
            rolename = role(0)
            Session("RoleName") = rolename

            strAction = ""
            Session("Update") = False
            Session("PPMP_Amt") = 0

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtYear = objDerived.GetDataTable("SELECT * FROM [AMS].[vw_app_status] WHERE status <> 3 ORDER BY year DESC", CommandType.Text)
            ddyear.DataSource = dtYear
            ddyear.DataTextField = ("year")
            ddyear.DataValueField = ("app_id")
            ddyear.DataBind()
            ddyear.Items.Insert(0, "Select")
            pYear = objDerived.GetDataTable("Select * from ams.vw_app_status", CommandType.Text)
            ddyear.DataSource = pYear

            '=== DEFAULT VIEW (WITH GOODS) ===
            CreateDataTableQty()
            grdQty.DataSource = dtMonthly
            grdQty.DataBind()

            Me.mvSchedule.SetActiveView(Me.vwWithGoods)

            grdBody.DataSource = DataTableBody(5)
            grdBody.DataBind()

            gvppmp.DataSource = Nothing
            gvppmp.DataBind()

            gvPPA.DataSource = Nothing
            gvPPA.DataBind()

            gvConsolidated.DataSource = Nothing
            gvConsolidated.DataBind()

            dtItemLoaded = Nothing

            drpProcurement.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.mode_of_procurement ORDER BY mode_of_procurement_id", CommandType.Text)
            drpProcurement.DataTextField = ("mode_description")
            drpProcurement.DataValueField = ("mode_of_procurement_id")
            drpProcurement.DataBind()
            drpProcurement.Items.Insert(0, "Select")

            drpApprovedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_All_Signatory] WHERE isActive = 1 AND deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpApprovedBy.DataTextField = ("Full_Name")
            drpApprovedBy.DataValueField = ("EmpID")
            drpApprovedBy.DataBind()
            'drpApprovedBy.Items.Insert(0, "Select")

            drpCheckedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_All_Signatory] WHERE isActive = 1 AND deptid = 8 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpCheckedBy.DataTextField = ("Full_Name")
            drpCheckedBy.DataValueField = ("EmpID")
            drpCheckedBy.DataBind()
            'drpCheckedBy.Items.Insert(0, "Select")

            drpNotedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_All_Signatory] WHERE isActive = 1 AND deptid = 7 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpNotedBy.DataTextField = ("Full_Name")
            drpNotedBy.DataValueField = ("EmpID")
            drpNotedBy.DataBind()
            'drpNotedBy.Items.Insert(0, "Select")

        End If

        ddRC.Attributes.Add("onChange", "StartProgressBar();")
        ddFunction.Attributes.Add("onChange", "StartProgressBar();")
        ddAllotmentType.Attributes.Add("onChange", "StartProgressBar();")
        ddGenAccount.Attributes.Add("onChange", "StartProgressBar();")

        txtTotalAmt.Attributes.Add("onChange", "StartProgressBar();")
        ddFunction.Attributes.Add("onChange", "StartProgressBar();")
        txtTotalQty.Attributes.Add("onChange", "StartProgressBar();")
        txtTotalAmt.Attributes.Add("onChange", "StartProgressBar();")

        txtSearchItem.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchItem.ClientID & "')")
        txtTotalQty.Attributes.Add("onclick", "HighlightAll(this);")
        txtTotalAmt.Attributes.Add("onclick", "HighlightAll(this);")

        CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")
        CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox).Attributes.Add("onclick", "HighlightAll(this);")



    End Sub
    Private Sub ddyear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddyear.SelectedIndexChanged

        Try

            Session("CYear") = ddyear.SelectedItem.Text
            Session("app_id") = dtYear.Rows(ddyear.SelectedIndex - 1)("app_id")
            Session("APP_Status") = dtYear.Rows(ddyear.SelectedIndex - 1)("status")
            Session("isContinuing") = False

            ' Dim RP_ID As Integer = objDerived.GetValue("SELECT TOP(1) Reserved_ID FROM AMS.ReservedPercentage WHERE CYear = '" & Session("CYear") & "'", CommandType.Text)
            ' If RP_ID = 0 Then

            'ddyear.SelectedIndex = 0

            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set reserved percentage for the selected year first before encoding a PPMP.")

            '  Else
            dtDepartments = objDerived.GetDataTable("EXEC [dbo].[sp_respcenter_systemManager] '" & Session("RoleName") & "'", CommandType.Text)
            ddRC.DataSource = dtDepartments
            ddRC.DataTextField = ("rc_name")
            ddRC.DataValueField = ("rc_id")
            ddRC.DataBind()
            ddRC.Items.Insert(0, "Select")
            ddRC.Enabled = True

            lblappstatus.Text = dtYear.Rows(ddyear.SelectedIndex - 1)("description")

            If Session("APP_Status") = 2 Then
                lnkView.Enabled = False
                btnSave.Enabled = False
            End If

            '  End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub ddRC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddRC.SelectedIndexChanged
        Session("RC_ID") = ddRC.SelectedItem.Value
        ddFunction.Enabled = True

        ddFunction.DataSource = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & Session("RC_ID") & "'", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

        ddFunction.DataSource = Nothing
        ddFunction.DataBind()

        ddPPA.DataSource = Nothing
        ddPPA.DataBind()

        ddGenAccount.DataSource = Nothing
        ddGenAccount.DataBind()

        ddAllotmentType.SelectedIndex = 0

        chkOOE.Checked = False
        cbWOGoods.Checked = False


    End Sub
    Private Sub ddFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddFunction.SelectedIndexChanged
        Try
            Dim a As Integer = pYear.Rows(ddyear.SelectedIndex - 1)("year")
            PAPS = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project " & Me.ddRC.SelectedItem.Value & ",'" & Session("CYear") & "'," & ddFunction.SelectedItem.Value & "," & 0 & "", CommandType.Text)

            Session("Update") = False
            Session("Function_ID") = ddFunction.SelectedItem.Value
            ddPPA.Enabled = True
            chkOOE.Enabled = True
            cbWOGoods.Enabled = True

            dtPPA = objDerived.GetDataTable("EXEC [AMS].[sp_PPA_Monthly] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "", CommandType.Text)
            ddPPA.DataSource = dtPPA
            ddPPA.DataTextField = ("description")
            ddPPA.DataValueField = ("Project_ID")
            ddPPA.DataBind()
            ddPPA.Items.Insert(0, "Select")


            dtPreparedBy = objDerived.GetDataTable("SELECT * FROM [dbo].[View_All_Signatory] WHERE isActive = 1 AND deptid = " & Session("RC_ID") & " AND division_Key = " & Session("Function_ID") & "", CommandType.Text)
            drpPreparedBy.DataSource = dtPreparedBy
            drpPreparedBy.DataTextField = ("Full_Name")
            drpPreparedBy.DataValueField = ("EmpID")
            drpPreparedBy.DataBind()
            drpPreparedBy.Items.Insert(0, "Select")

            LoadPPMPList_PerTab()

            If dtPreparedBy.Rows.Count = 0 Then
                btnSave.Enabled = False
                btnPreview.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected department has no signatory.")
            Else
                btnSave.Enabled = True
                btnPreview.Enabled = True

            End If

            btnPreview.Enabled = False


            '---------------------------------------------------
            ' CHECK BUDGET CEILING
            '---------------------------------------------------
            'Dim dt As New DataTable
            'dt = objDerived.GetDataTable("SELECT TOP(1) * FROM LnkdSrvrBOSS.GEOBOS.BOS.BudgetCeiling WHERE BudgetYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' ORDER BY BudgetCeiling_ID DESC", CommandType.Text)
            'If dt.Rows.Count < 1 Then

            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Budget ceiling is required to create ppmp, contact budget office.")

            '    txtBudgetCeiling.Text = "0.00"
            '    ddGenAccount.Enabled = False

            'Else
            '    Dim PPMP_Amnt As Decimal = objDerived.GetValue("EXEC [AMS].[sp_PPMPTotalAmnt] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "' ", CommandType.Text)

            '    txtBudgetCeiling.Text = FormatNumber(dt.Rows(0)("TotalBUdgetCeilingAmount"), 2)
            '    txtAvailableAmt.Text = FormatNumber(dt.Rows(0)("TotalBUdgetCeilingAmount") - PPMP_Amnt, 2)

            '    If txtAvailableAmt.Text < 1 Then
            '        lblAvailableAmt.Visible = True
            '    Else
            '        lblAvailableAmt.Visible = False
            '    End If

            'End If

            '--- ENABLE INFRA CHECKBOX TO FILTER ALL PPA TAG AS INFRA
            cbInfra.Enabled = True

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub


    Protected Sub LoadPPMPList_PerTab()

        gvppmp.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPList_Monthly_PerTab] 'OOE'," & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("app_id") & "", CommandType.Text)
        gvppmp.DataBind()

        gvPPA.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPList_Monthly_PerTab] 'PPA'," & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("app_id") & "", CommandType.Text)
        gvPPA.DataBind()

        gvConsolidated.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPList_Monthly_PerTab] 'CONSO'," & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("app_id") & "", CommandType.Text)
        gvConsolidated.DataBind()

    End Sub
    Protected Sub gvPPA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPPA.PageIndexChanging
        gvPPA.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPList_Monthly_PerTab] 'PPA'," & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("app_id") & "", CommandType.Text)
        gvPPA.PageIndex = e.NewPageIndex
        gvPPA.DataBind()
    End Sub
    Protected Sub gvppmp_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvppmp.PageIndexChanging
        gvppmp.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPList_Monthly_PerTab] 'OOE'," & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("app_id") & "", CommandType.Text)
        gvppmp.PageIndex = e.NewPageIndex
        gvppmp.DataBind()
    End Sub
    Protected Sub gvConsolidated_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvConsolidated.PageIndexChanging
        gvConsolidated.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_PPMPList_Monthly_PerTab] 'CONSO'," & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("app_id") & "", CommandType.Text)
        gvConsolidated.PageIndex = e.NewPageIndex
        gvConsolidated.DataBind()
    End Sub

    Protected Sub chkOOE_load()
        ddAllotmentType.Enabled = True

        Session("Program_ID") = 0
        Session("Project_ID") = 0

        If chkOOE.Checked = False Then
            ddPPA.Enabled = True
        Else
            ddPPA.Enabled = False
        End If

        ddAllotmentType.SelectedValue = 0
        ddGenAccount.Enabled = False
        ddGenAccount.SelectedItem.Text = "Select"

        'txtbudget.Text = "0.00"
        ' txtAvailableBudget.Text = "0.00"

        grdBody.DataSource = DataTableBody(5)
        grdBody.DataBind()
    End Sub
    Private Sub chkOOE_CheckedChanged(sender As Object, e As EventArgs) Handles chkOOE.CheckedChanged
        chkOOE_load()


    End Sub
    Private Sub ddPPA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPPA.SelectedIndexChanged

        If ddPPA.SelectedItem.Text = "Select" Then
            chkOOE.Enabled = True
            ddAllotmentType.Enabled = False

            Session("Program_ID") = 0
            Session("Project_ID") = 0

        Else
            chkOOE.Enabled = True
            ddAllotmentType.Enabled = True

            Session("Program_ID") = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_ID")
            Session("Project_ID") = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID")

        End If

        ddAllotmentType.SelectedValue = 0
        ddGenAccount.Enabled = True
        ddGenAccount.SelectedItem.Text = "Select"

        txtbudget.Text = "0.00"
        txtAvailableBudget.Text = "0.00"

        grdBody.DataSource = DataTableBody(5)
        grdBody.DataBind()


    End Sub
    Private Sub ddAllotmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddAllotmentType.SelectedIndexChanged
        Try


            If Me.chkOOE.Checked = True Then
                pAccounts = objDerived.GetDataTable("exec  AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & withApprovedBudget & ",0,0," & Me.ddAllotmentType.SelectedValue.ToString & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                hdfppaprojId.Value = 0
                hdfppaprogId.Value = 0
                'ddAccount.Enabled = True

            Else '=-= PPA

                If ddAllotmentType.SelectedItem.Value = 2 Then 'MOOE
                    Dim MMOE As Decimal
                    Dim A As Integer = PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id")
                    Dim B As Integer = PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_id")
                    MMOE = objDerived.GetValue("Select MOOE from  dbo.view_PPA_Budget where Program_id ='" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "' and Project_id ='" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "' and RC_ID ='" & ddRC.SelectedItem.Value & "' and Function_ID ='" & ddFunction.SelectedItem.Value & "' ", CommandType.Text)
                    If MMOE = 0 Then
                        'ddAccount.Enabled = False
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA to proceed with your PPMP.")
                    Else
                        pAccounts = objDerived.GetDataTable("exec  AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "," & ddRC.SelectedItem.Value & "," & ddFunction.SelectedItem.Value & "," & withApprovedBudget & "," & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "," & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_ID") & "," & Me.ddAllotmentType.SelectedValue.ToString & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                        Dim c As Integer = ddPPA.SelectedIndex
                        hdfppaprojId.Value = PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
                        hdfppaprogId.Value = PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id")
                        ddGenAccount.Enabled = True

                        txtbudget.Text = FormatNumber(CType(MMOE.ToString, Decimal), 2)
                        txtAvailableBudget.Text = FormatNumber(txtbudget.Text - PPMPSaved, 2)
                    End If

                ElseIf ddAllotmentType.SelectedItem.Value = 3 Then 'Capital Outlay
                    Dim CO As Decimal
                    CO = objDerived.GetValue("Select CO from  dbo.view_PPA_Budget where Program_id ='" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id") & "' and Project_ID ='" & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "' and RC_ID ='" & ddRC.SelectedItem.Value & "' and Function_ID ='" & ddFunction.SelectedItem.Value & "' ", CommandType.Text)
                    If CO = 0 Then
                        'ddAccount.Enabled = False
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA to proceed with your PPMP.")
                    Else
                        pAccounts = objDerived.GetDataTable("exec AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  " _
                                                            & pYear.Rows(ddyear.SelectedIndex - 1)("year") _
                                                            & "," & ddRC.SelectedItem.Value _
                                                            & "," & ddFunction.SelectedItem.Value _
                                                            & "," & withApprovedBudget & "," _
                                                            & PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID") & "," _
                                                            & PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_ID") & "," _
                                                            & Me.ddAllotmentType.SelectedValue.ToString & "," _
                                                            & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" _
                                                            & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                        Dim c As Integer = ddPPA.SelectedIndex
                        hdfppaprojId.Value = PAPS.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
                        hdfppaprogId.Value = PAPS.Rows(ddPPA.SelectedIndex - 1)("Program_id")
                        ddGenAccount.Enabled = True

                        txtbudget.Text = FormatNumber(CType(CO.ToString, Decimal), 2)
                        txtAvailableBudget.Text = FormatNumber(txtbudget.Text - PPMPSaved, 2)
                    End If
                End If
            End If


            Session("AllotmentType") = ddAllotmentType.SelectedItem.Value

            dtAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_PPMP_GenAccountList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("AllotmentType") & "", CommandType.Text)
            ddGenAccount.DataSource = dtAccounts
            ddGenAccount.DataTextField = ("GA_Title2")
            ddGenAccount.DataValueField = ("GA_Code2")
            ddGenAccount.DataBind()
            ddGenAccount.Items.Insert(0, "Select")

            ddGenAccount.Enabled = True
            If lblappstatus.Text = "Executing" Then

                lnkView.Enabled = False
            Else
                lnkView.Enabled = True
            End If
        Catch ex As Exception
            ''MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            'MsgBox(ex.Message)
        End Try



    End Sub


    Protected Sub LoadSavedPPMP()
        If cbWOGoods.Checked = True Then
            '======= WITH OUT GOODS =======
            lblTotalQtyAmt.Text = "Total Available Amount :"

            dtMonthlyAmt = objDerived.GetDataTable("EXEC [AMS].[sp_LoadItem_PerMonthAmt] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("GA_ID") & "," & Session("BGA_ID") & "," & Session("app_id") & ",'" & Session("ppmp_monthly_dtl_ID") & "'", CommandType.Text)
            grdAmounts.DataSource = dtMonthlyAmt
            grdAmounts.DataBind()

            If dtMonthlyAmt.Rows.Count = 0 Then
                Session("Update") = False
                txtTotalQtyAmt.Text = "0.00"
                txtTotalQty.Text = "0.00"
                txtTotalAmt.Text = "0.00"
                'txtReservedPercentage.Text = "0.00"
                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal), 2)

                txtGenDesc.Text = ""

                CreateDataTableAmt()
                grdAmounts.DataSource = dtMonthly
                grdAmounts.DataBind()

            Else
                Session("Update") = True
                txtTotalQtyAmt.Text = FormatNumber(CType(dtMonthlyAmt.Rows(0)("Total"), Decimal) - CType(dtMonthlyAmt.Rows(0)("TotalComputedAmt"), Decimal), 2)
                txtTotalQty.Text = "0.00"

                txtTotalAmt.Text = FormatNumber(CType(dtMonthlyAmt.Rows(0)("Total"), Decimal), 2)
                Session("orig_totalAmt") = txtTotalAmt.Text
                Session("PPMP_Amt") = txtTotalAmt.Text
                txtTotalAmt.Enabled = True

                txtReservedPercentage.Text = FormatNumber(dtMonthlyAmt.Rows(0)("ReservedPercentage"), 2)
                txtAvailableBudget.Text = FormatNumber(CType(dtMonthlyAmt.Rows(0)("Total"), Decimal) - CType(dtMonthlyAmt.Rows(0)("TotalComputedAmt"), Decimal), 2)

                txtGenDesc.Text = dtMonthlyAmt.Rows(0)("GenDescription")
                txtGenDesc.Enabled = True

                CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox).Text, 2)
                CType(grdAmounts.Rows(0).Cells(11).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(CType(grdAmounts.Rows(0).Cells(11).FindControl("txtRQtyAmt"), TextBox).Text, 2)

            End If

            grdBody.DataSource = DataTableBody(5)
            grdBody.DataBind()

            Me.mvSchedule.SetActiveView(Me.vwWithOutGoods)

        Else
            '======= WITH GOODS =======
            lblTotalQtyAmt.Text = "Total Available Qty :"
            txtTotalAmt.Text = "0.00"
            txtGenDesc.Text = ""
            txtGenDesc.Enabled = False

            dtItemLoaded = objDerived.GetDataTable("EXEC [AMS].[sp_LoadPPMPSaved_Monthly] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("GA_ID") & "," & Session("BGA_ID") & "," & Session("app_id") & " ", CommandType.Text)
            If dtItemLoaded.Rows.Count = 0 Then
                Session("Update") = False
                grdBody.DataSource = DataTableBody(5)
                grdBody.DataBind()

            Else
                Session("Update") = True
                grdBody.DataSource = dtItemLoaded
                grdBody.DataBind()


                Dim totalAmtSum As Decimal = 0
                For Each row As DataRow In dtItemLoaded.Rows
                    If Not row.IsNull("TotalAmt") Then
                        totalAmtSum += Convert.ToDecimal(row("TotalAmt"))
                    End If
                Next

                'CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)
                'Session("PPMP_Amt") = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

                CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = totalAmtSum.ToString("N2")
                Session("PPMP_Amt") = totalAmtSum.ToString("N2")

                For i As Integer = 0 To dtItemLoaded.Rows.Count - 1
                    Dim ID As String = IIf(IsDBNull(dtItemLoaded.Rows(i)("Item_ID")), 0, dtItemLoaded.Rows(i)("Item_ID"))
                    Session(ID) = objDerived.GetDataTable("EXEC [AMS].[sp_LoadItem_PerMonthQty] " & dtItemLoaded.Rows(i)("ppmp_monthly_dtl_ID") & "", CommandType.Text)
                Next

                'txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - CType(dtItemLoaded.Compute("sum(TotalAmt)", ""), Decimal), 2)
                txtAvailableBudget.Text = FormatNumber(CType(txtbudget.Text, Decimal) - totalAmtSum, 2)
                'txtReservedPercentage.Text = dtItemLoaded.Rows(0)("ReservedPercentage")
                txtTotalQtyAmt.Text = "0.00"

                If Session("APP_Status") = 1 Then
                    lnkView.Enabled = True
                    btnSave.Enabled = True
                Else
                    If dtItemLoaded.Rows(0)("forRevision") = True Then
                        lnkView.Enabled = True
                        btnSave.Enabled = True
                    Else
                        lnkView.Enabled = False
                        btnSave.Enabled = False
                    End If
                End If

            End If

            Me.mvSchedule.SetActiveView(Me.vwWithGoods)

            If txtbudget.Text = "0.00" Then
                txtAvailableBudget.Text = "0.00"
            End If


        End If

    End Sub
    Private Sub lnkView_Click(sender As Object, e As EventArgs) Handles lnkView.Click
        Session("GA_ID") = dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("GA_ID")
        Session("BGA_ID") = dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("BGA_ID")

        If Session("APP_Status") = 1 Then
            lnkView.Enabled = True
        Else
            lnkView.Enabled = False
        End If

        txtbudget.Text = FormatNumber(dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("ApprovedFinal"), 2)

        Dim RP As Decimal = objDerived.GetValue("SELECT ReservedPercentage FROM AMS.ReservedPercentage WHERE CYear = '" & Session("CYear") & "' AND GA_ID = '" & Session("GA_ID") & "'", CommandType.Text)
        txtReservedPercentage.Text = Format(RP, "0.##")

        If cbWOGoods.Checked = False Then
            txtTotalQty.Enabled = True
        Else
            txtTotalAmt.Enabled = True
        End If


        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_ToCreate_PPMP_ItemList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("GA_ID") & "," & Session("BGA_ID") & "," & Session("app_id") & "", CommandType.Text)
        grdItems.DataSource = dtItems
        grdItems.DataBind()

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False


        LoadSavedPPMP()
        ModalPopupExtender_Items.Show()
    End Sub
    Private Sub cbWOGoods_CheckedChanged(sender As Object, e As EventArgs) Handles cbWOGoods.CheckedChanged
        Try
            If cbWOGoods.Checked = True Then
                lblTotalQtyAmt.Text = "Total Available Amount :"
                txtGenDesc.Enabled = True

                CreateDataTableAmt()
                grdAmounts.DataSource = dtMonthly
                grdAmounts.DataBind()

                txtTotalAmt.Enabled = True
                txtTotalQty.Enabled = False
                txtTotalQty.Text = "0.00"
                'txtTotalAmt.Text = FormatNumber(txtbudget.Text, 2)

                grdBody.DataSource = DataTableBody(5)
                grdBody.DataBind()

                CreateDataTableQty()
                grdQty.DataSource = dtMonthly
                grdQty.DataBind()

                lnkView.Enabled = False

                Me.mvSchedule.SetActiveView(Me.vwWithOutGoods)

            Else
                lblTotalQtyAmt.Text = "Total Available Quantity :"
                txtGenDesc.Enabled = False

                txtTotalAmt.Enabled = False
                txtTotalAmt.Text = "0.00"
                txtTotalQty.Enabled = True

                CreateDataTableQty()
                grdAmounts.DataSource = dtMonthly
                grdAmounts.DataBind()

                lnkView.Enabled = True
                Me.mvSchedule.SetActiveView(Me.vwWithGoods)

            End If

            txtTotalQtyAmt.Text = "0.00"

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try


    End Sub
    Private Sub cbInfra_CheckedChanged(sender As Object, e As EventArgs) Handles cbInfra.CheckedChanged
        Try
            If cbInfra.Checked = True Then
                lblTotalQtyAmt.Text = "Total Amount :"
                txtGenDesc.Enabled = True

                CreateDataTableAmt()
                grdAmounts.DataSource = dtMonthly
                grdAmounts.DataBind()

                txtTotalAmt.Enabled = True
                txtTotalQty.Enabled = False
                txtTotalQty.Text = "0.00"
                txtTotalAmt.Text = FormatNumber(txtbudget.Text, 2)

                grdBody.DataSource = DataTableBody(5)
                grdBody.DataBind()

                CreateDataTableQty()
                grdQty.DataSource = dtMonthly
                grdQty.DataBind()

                lnkView.Enabled = False
                chkOOE.Enabled = False
                cbWOGoods.Checked = True
                cbWOGoods.Enabled = False


                Dim myview As DataView
                myview = dtPPA.DefaultView
                myview.RowFilter = "isInfraActivity = 1"
                ddPPA.DataSource = myview
                ddPPA.DataTextField = ("description")
                ddPPA.DataValueField = ("Project_ID")
                ddPPA.DataBind()
                ddPPA.Items.Insert(0, "Select")


                Me.mvSchedule.SetActiveView(Me.vwWithOutGoods)

            Else
                lblTotalQtyAmt.Text = "Total Available Quantity :"
                txtGenDesc.Enabled = False

                txtTotalAmt.Enabled = False
                txtTotalAmt.Text = "0.00"
                txtTotalQty.Enabled = True

                CreateDataTableQty()
                grdAmounts.DataSource = dtMonthly
                grdAmounts.DataBind()

                lnkView.Enabled = True
                chkOOE.Enabled = True
                cbWOGoods.Checked = False
                cbWOGoods.Enabled = True

                dtPPA = objDerived.GetDataTable("EXEC [AMS].[sp_PPA_Monthly] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "", CommandType.Text)
                ddPPA.DataSource = dtPPA
                ddPPA.DataTextField = ("description")
                ddPPA.DataValueField = ("Project_ID")
                ddPPA.DataBind()
                ddPPA.Items.Insert(0, "Select")

                Me.mvSchedule.SetActiveView(Me.vwWithGoods)

            End If

            txtTotalQtyAmt.Text = "0.00"
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub cbAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.grdItems.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdItems.Rows(i).Cells(0).FindControl("cbItem"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    dtItems.Rows(grdItems.Rows(i).Cells(5).Text)("isChecked") = True
                End If
            Next

        Else
            For i As Integer = 0 To Me.grdItems.Rows.Count - 1
                Dim s As CheckBox = CType(Me.grdItems.Rows(i).Cells(0).FindControl("cbItem"), CheckBox)
                s.Checked = False
                dtItems.Rows(grdItems.Rows(i).Cells(5).Text)("isChecked") = False
            Next
        End If

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False


        ModalPopupExtender_Items.Show()
    End Sub



    Protected Sub cbItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox = TryCast(sender, CheckBox)
        Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        If cb.Checked = True Then
            dtItems.Rows(grdItems.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = True
        Else
            dtItems.Rows(grdItems.Rows(gvr.RowIndex).Cells(5).Text)("isChecked") = False
        End If

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False

        ModalPopupExtender_Items.Show()
    End Sub
    Private Sub btnSearchItem_Click(sender As Object, e As EventArgs) Handles btnSearchItem.Click
        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        Dim myview As DataView

        myview = dtItems.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearchItem.Text) & "%' and isUsed = false"
        grdItems.DataSource = myview
        grdItems.DataBind()

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False

        ModalPopupExtender_Items.Show()
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Protected Sub grdItems_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdItems.PageIndexChanging
        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        grdItems.DataSource = dtItems
        grdItems.PageIndex = e.NewPageIndex
        grdItems.DataBind()

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False

        ModalPopupExtender_Items.Show()
    End Sub
    Protected Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        'Try
        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        '=== CREATE TEMP TABLE FOR QUANITIES ===
        Dim drQ As DataRow
        Dim dtQ As New DataTable
        dtQ.Columns.Add("Jan")
        dtQ.Columns.Add("JanAmt")
        dtQ.Columns.Add("Feb")
        dtQ.Columns.Add("FebAmt")
        dtQ.Columns.Add("Mar")
        dtQ.Columns.Add("MarAmt")
        dtQ.Columns.Add("Apr")
        dtQ.Columns.Add("AprAmt")
        dtQ.Columns.Add("May")
        dtQ.Columns.Add("MayAmt")
        dtQ.Columns.Add("Jun")
        dtQ.Columns.Add("JunAmt")
        dtQ.Columns.Add("Jul")
        dtQ.Columns.Add("JulAmt")
        dtQ.Columns.Add("Aug")
        dtQ.Columns.Add("AugAmt")
        dtQ.Columns.Add("Sep")
        dtQ.Columns.Add("SepAmt")
        dtQ.Columns.Add("Oct")
        dtQ.Columns.Add("OctAmt")
        dtQ.Columns.Add("Nov")
        dtQ.Columns.Add("NovAmt")
        dtQ.Columns.Add("Dec")
        dtQ.Columns.Add("DecAmt")
        dtQ.Columns.Add("RQty")
        dtQ.Columns.Add("RQtyAmt")
        dtQ.Columns.Add("TotalQuantity")
        dtQ.Columns.Add("RsrvPerctge")
        drQ = dtQ.NewRow

        drQ.Item(0) = "0"
        drQ.Item(1) = "0.00"
        drQ.Item(2) = "0"
        drQ.Item(3) = "0.00"
        drQ.Item(4) = "0"
        drQ.Item(5) = "0.00"
        drQ.Item(6) = "0"
        drQ.Item(7) = "0.00"
        drQ.Item(8) = "0"
        drQ.Item(9) = "0.00"
        drQ.Item(10) = "0"
        drQ.Item(11) = "0.00"
        drQ.Item(12) = "0"
        drQ.Item(13) = "0.00"
        drQ.Item(14) = "0"
        drQ.Item(15) = "0.00"
        drQ.Item(16) = "0"
        drQ.Item(17) = "0.00"
        drQ.Item(18) = "0"
        drQ.Item(19) = "0.00"
        drQ.Item(20) = "0"
        drQ.Item(21) = "0.00"
        drQ.Item(22) = "0"
        drQ.Item(23) = "0.00"
        drQ.Item(24) = "0"
        drQ.Item(25) = "0.00"
        drQ.Item(26) = "0"
        drQ.Item(27) = "0.00"
        dtQ.Rows.Add(drQ)


        Dim dt As New DataTable
        Dim dr As DataRow

        If dtItemLoaded.Rows.Count = Nothing Or dtItemLoaded.Rows.Count <= 0 Then
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Item_Desc", GetType(String))
            dt.Columns.Add("Unit", GetType(String))
            dt.Columns.Add("Qty", GetType(Decimal))
            dt.Columns.Add("UnitPrice", GetType(Decimal))
            dt.Columns.Add("TotalAmt", GetType(Decimal))
            dt.Columns.Add("Item_ID", GetType(Integer))
            dt.Columns.Add("ppmp_monthly_dtl_ID", GetType(Long))
            dt.Columns.Add("isVisible", GetType(Boolean))

            For i As Integer = 0 To dtItems.Rows.Count - 1
                Dim dtItemLoaded2 As New DataTable
                dtItemLoaded2 = dtItemLoaded

                If dtItems.Rows(i)("isChecked") = True Then
                    dr = dt.NewRow
                    dr("ID") = 1
                    dr("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                    dr("Unit") = dtItems.Rows(i)("Unit")
                    dr("Qty") = 0
                    dr("UnitPrice") = dtItems.Rows(i)("UnitPrice")
                    dr("TotalAmt") = "0.00"
                    dr("Item_ID") = dtItems.Rows(i)("Item_ID")
                    dr("ppmp_monthly_dtl_ID") = 0
                    dr("isVisible") = True
                    dt.Rows.Add(dr)
                    dtItems.Rows(i)("isUsed") = True
                    dtItems.Rows(i)("isChecked") = False
                    Me.Session(CType(dtItems.Rows(i)("Item_ID"), String)) = dtQ
                End If
            Next

            dtItemLoaded = dt

        Else

            For i As Integer = 0 To dtItems.Rows.Count - 1
                If dtItems.Rows(i)("isChecked") = True Then
                    dt = dtItemLoaded
                    dr = dt.NewRow
                    dr("ID") = 1
                    dr("Item_Desc") = dtItems.Rows(i)("Item_Desc")
                    dr("Unit") = dtItems.Rows(i)("Unit")
                    dr("Qty") = 0
                    dr("UnitPrice") = dtItems.Rows(i)("UnitPrice")
                    dr("TotalAmt") = "0.00"
                    dr("Item_ID") = dtItems.Rows(i)("Item_ID")
                    dr("ppmp_monthly_dtl_ID") = 0
                    dr("isVisible") = True
                    dt.Rows.Add(dr)
                    dtItemLoaded = dt

                    dtItems.Rows(i)("isUsed") = True
                    dtItems.Rows(i)("isChecked") = False

                    Me.Session(CType(dtItems.Rows(i)("Item_ID"), String)) = dtQ
                End If
            Next
        End If

        grdBody.DataSource = dtItemLoaded
        grdBody.DataBind()

        Dim data As DataTable
        data = dtItems

        Dim myview As DataView
        myview = dtItems.DefaultView
        myview.RowFilter = "isUsed = false"
        grdItems.DataSource = myview
        grdItems.DataBind()

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False

        If dtItemLoaded.Compute("sum(TotalAmt)", "") = "0.00" Then
            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = "0.00"
        Else
            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)
        End If

        grdQty.DataSource = dtQ
        grdQty.DataBind()

        grdBody.SelectedIndex = -1
        ModalPopupExtender_Items.Show()


        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        'End Try
    End Sub

    'Protected Sub imgDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    strAction = "Delete"
    'End Sub

    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        strAction = "Select"

    End Sub
    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        strAction = "Delete"


    End Sub
    Private Sub grdBody_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBody.SelectedIndexChanged
        Try
            If strAction = "Select" Then
                Dim qty As Decimal = CType(txtTotalQtyAmt.Text, Decimal)

                If qty <> "0.00" Or qty <> 0 Then
                    grdBody.SelectedIndex = grdBody.SelectedIndex - 1
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Distribute All Quantity To Proceed to the next Item.")

                Else
                    Dim dt As New DataTable
                    dt = CType(Me.Session(CType(grdBody.SelectedDataKey("Item_ID"), String)), DataTable)
                    grdQty.DataSource = dt
                    grdQty.DataBind()

                    Dim Jan As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
                    Dim Feb As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
                    Dim Mar As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
                    Dim Apr As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
                    Dim May As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
                    Dim Jun As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
                    Dim Jul As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
                    Dim Aug As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
                    Dim Sep As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
                    Dim Oct As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
                    Dim Nov As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
                    Dim Dec As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
                    Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

                    Dim TotalValue As Decimal = FormatNumber(CType(Val(Jan.Text) + Val(Feb.Text) + Val(Mar.Text) + Val(Apr.Text) + Val(May.Text) + Val(Jun.Text) + Val(Jul.Text) + Val(Aug.Text) + Val(Sep.Text) + Val(Oct.Text) + Val(Nov.Text) + Val(Dec.Text), Decimal), 2)

                    txtTotalQty.Text = Format(TotalValue + CType(Val(RQty.Text), Decimal), "0.##") 'dt.Rows(0)("TotalQuantity")

                    txtTotalQty.Enabled = True

                    'txtTotalQtyAmt.Text = FormatNumber(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), 2)
                    txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(Val(RQty.Text), Decimal) + TotalValue), "0.##")
                    lblItemsDesc.Text = objDerived.GetValue("SELECT CASE WHEN LEN(Item_Desc) > 80 THEN  SUBSTRING(Item_Desc,0,80) + ' . . . ' ELSE Item_Desc  END AS ItemDesc FROM dbo.m_item WHERE Item_ID = " & grdBody.SelectedDataKey("Item_ID") & "", CommandType.Text)



                    ' onclick="HighlightAll(this);"
                    'txtTotalQty.Focus()

                    TotallQty_Postback = "1st Load"

                End If


            ElseIf strAction = "Delete" Then
                If lblappstatus.Text = "Executing" Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Cannot remove the item, APP is already executed")
                Else

                    For i As Integer = 0 To Me.dtItemLoaded.Rows.Count - 1
                        If dtItemLoaded.Rows(i).Item("Item_ID") = 0 Then

                        ElseIf dtItemLoaded.Rows(i).Item("Item_ID") = grdBody.SelectedDataKey("Item_ID") Then
                            dtItemLoaded.Rows.Remove(dtItemLoaded.Rows(i))
                            Exit For
                        End If
                    Next

                    If grdBody.SelectedDataKey("ppmp_monthly_dtl_ID") = 0 Then
                        '=== IF ITEM IS NOT YET SAVED IN PPMP

                    Else
                        '=== IF ITEM IS ALREADY SAVED IN PPMP BUT NOT YET PR
                        objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_dtl_ID = " & grdBody.SelectedDataKey("ppmp_monthly_dtl_ID") & "", CommandType.Text)

                    End If

                    Dim dt As New DataTable
                    dt = dtItemLoaded

                    grdBody.DataSource = dt
                    grdBody.DataBind()

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected item has been successfully removed.")


                End If
            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")

        End Try
    End Sub



    Protected Sub LoadAvailableBudget()

        If txtbudget.Text = "0.00" Then
            '====== BUDGET CEILING ======
            Dim dt As New DataTable
            'dt = objDerived.GetDataTable("SELECT * FROM LnkdSrvrBOSS.GEOBOS.BOS.BudgetCeiling WHERE BudgetYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "'", CommandType.Text)
            dt = objDerived.GetDataTable("SELECT TOP(1) * FROM LnkdSrvrBOSS.GEOBOS.BOS.BudgetCeiling WHERE BudgetYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' ORDER BY BudgetCeiling_ID DESC", CommandType.Text)

            'Dim PPMP As Decimal = objDerived.GetValue("EXEC [AMS].[sp_PPMPTotalAmnt_PerAllotment] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("AllotmentType") & "' ", CommandType.Text)
            Dim PPMP As Decimal = objDerived.GetValue("EXEC [AMS].[sp_PPMPTotalAmnt] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "' ", CommandType.Text)

            If cbWOGoods.Checked = False Then
                Dim Ongoing As Decimal = CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text
                Dim PPMP_Amnt As Decimal

                If Session("Update") = True Then
                    PPMP_Amnt = (PPMP - CType(Session("PPMP_Amt"), Decimal)) + Ongoing
                Else
                    PPMP_Amnt = PPMP + Ongoing
                End If

                txtBudgetCeiling.Text = FormatNumber(dt.Rows(0)("TotalBUdgetCeilingAmount"), 2)
                txtAvailableAmt.Text = FormatNumber(dt.Rows(0)("TotalBUdgetCeilingAmount") - PPMP_Amnt, 2)

            End If


            If CType(txtAvailableAmt.Text, Decimal) < 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total PPMP amount already exceeded the budget ceiling, adjust your PPMP.")
                lblAvailableAmt.Visible = True
                btnSave.Enabled = False

            Else
                lblAvailableAmt.Visible = False
                btnSave.Enabled = True
            End If

        Else
            '======= APPROVED PAOO =======
            If cbWOGoods.Checked = True Then

            Else
                txtAvailableBudget.Text = FormatNumber(txtbudget.Text - (CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text), 2)
                If txtbudget.Text = "0.00" Then
                    txtAvailableBudget.Text = "0.00"
                End If

            End If

            If CType(txtAvailableBudget.Text, Decimal) < 0 Then
                lblAvailableBudget.Visible = True
                btnSave.Enabled = False
            Else
                lblAvailableBudget.Visible = False
                btnSave.Enabled = True
            End If

        End If




    End Sub
    Protected Sub txtJan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim JanQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(JanQty.NamingContainer, GridViewRow)

            If JanQty.Text = "" Then
                JanQty.Text = "0"
            End If



            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblJan"), Label).Text = FormatNumber(UnitCost * CType(JanQty.Text, Decimal), 2)

            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)


            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(JanQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                JanQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblJan"), Label).Text = "0.00"


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Ecoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If

            'Dim qty As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text) + Val(RQty.Text), Decimal), 2)
            'dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = FormatNumber(qty, 2)
            'txtTotalQty.Text = FormatNumber(qty, 2)

            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow


            dr.Item(0) = CType(CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            'System.Web.UI.ScriptManager.GetCurrent(Me).SetFocus(FebQty)

            FebQty.Focus()
            FebQty.Attributes.Add("onclick", "this.select()")
            FebQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtFeb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim FebQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(FebQty.NamingContainer, GridViewRow)

            If FebQty.Text = "" Then
                FebQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblFeb"), Label).Text = FormatNumber(UnitCost * CType(FebQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)

            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(FebQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                FebQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblFeb"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()



            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox).Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            MarQty.Focus()
            MarQty.Attributes.Add("onclick", "this.select()")
            MarQty.Attributes.Add("onFocus", "this.select()")

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtMar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim MarQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(MarQty.NamingContainer, GridViewRow)

            If MarQty.Text = "" Then
                MarQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblMar"), Label).Text = FormatNumber(UnitCost * CType(MarQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)

            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(MarQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                MarQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblMar"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text

            dr.Item(4) = CType(CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox).Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text

            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()


            AprQty.Focus()
            AprQty.Attributes.Add("onclick", "this.select()")
            AprQty.Attributes.Add("onFocus", "this.select()")

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtApr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim AprQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(AprQty.NamingContainer, GridViewRow)

            If AprQty.Text = "" Then
                AprQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblApr"), Label).Text = FormatNumber(UnitCost * CType(AprQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)

            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(AprQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                AprQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblApr"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text

            dr.Item(6) = CType(CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox).Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text

            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            MayQty.Focus()
            MayQty.Attributes.Add("onclick", "this.select()")
            MayQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try

    End Sub
    Protected Sub txtMay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim MayQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(MayQty.NamingContainer, GridViewRow)

            If MayQty.Text = "" Then
                MayQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblMay"), Label).Text = FormatNumber(UnitCost * CType(MayQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)

            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(MayQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                MayQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblMay"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text

            dr.Item(8) = CType(CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox).Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text

            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            JunQty.Focus()
            JunQty.Attributes.Add("onclick", "this.select()")
            JunQty.Attributes.Add("onFocus", "this.select()")

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtJun_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim JunQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(JunQty.NamingContainer, GridViewRow)

            If JunQty.Text = "" Then
                JunQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblJun"), Label).Text = FormatNumber(UnitCost * CType(JunQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)

            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)


            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(JunQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                JunQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblJun"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text

            dr.Item(10) = CType(CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox).Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text

            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            JulQty.Focus()
            JulQty.Attributes.Add("onclick", "this.select()")
            JulQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtJul_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim JulQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(JulQty.NamingContainer, GridViewRow)

            If JulQty.Text = "" Then
                JulQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblJul"), Label).Text = FormatNumber(UnitCost * CType(JulQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)

            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)


            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(JulQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                JulQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblJul"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text

            dr.Item(12) = CType(CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox).Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text

            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            AugQty.Focus()
            AugQty.Attributes.Add("onclick", "this.select()")
            AugQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtAug_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim AugQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(AugQty.NamingContainer, GridViewRow)

            If AugQty.Text = "" Then
                AugQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblAug"), Label).Text = FormatNumber(UnitCost * CType(AugQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)

            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(AugQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                AugQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblAug"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If

            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text

            dr.Item(14) = CType(CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox).Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text

            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            SepQty.Focus()
            SepQty.Attributes.Add("onclick", "this.select()")
            SepQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtSep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim SepQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(SepQty.NamingContainer, GridViewRow)

            If SepQty.Text = "" Then
                SepQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblSep"), Label).Text = FormatNumber(UnitCost * CType(SepQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)

            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(SepQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                SepQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblSep"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text

            dr.Item(16) = CType(CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox).Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text

            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            OctQty.Focus()
            OctQty.Attributes.Add("onclick", "this.select()")
            OctQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtOct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim OctQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(OctQty.NamingContainer, GridViewRow)

            If OctQty.Text = "" Then
                OctQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblOct"), Label).Text = FormatNumber(UnitCost * CType(OctQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)

            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(OctQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                OctQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblOct"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If

            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text

            dr.Item(18) = CType(CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox).Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text

            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            NovQty.Focus()
            NovQty.Attributes.Add("onclick", "this.select()")
            NovQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtNov_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim NovQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(NovQty.NamingContainer, GridViewRow)

            If NovQty.Text = "" Then
                NovQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblNov"), Label).Text = FormatNumber(UnitCost * CType(NovQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)

            Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)
            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)


            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(NovQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                NovQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblNov"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If


            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text

            dr.Item(20) = CType(CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox).Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text

            dr.Item(22) = CType(DecQty.Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()

            DecQty.Focus()
            DecQty.Attributes.Add("onclick", "this.select()")
            DecQty.Attributes.Add("onFocus", "this.select()")


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtDec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim DecQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(DecQty.NamingContainer, GridViewRow)

            If DecQty.Text = "" Then
                DecQty.Text = "0"
            End If

            Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
            CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblDec"), Label).Text = FormatNumber(UnitCost * CType(DecQty.Text, Decimal), 2)

            Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
            Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
            Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)
            Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
            Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
            Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)
            Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
            Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
            Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)
            Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
            Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)

            Dim RQty As TextBox = CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox)

            Dim TotalValue As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

            If CType(txtTotalQty.Text, Decimal) < (CType(TotalValue, Decimal) + CType(RQty.Text, Decimal)) Then

                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue - CType(DecQty.Text, Decimal)), "0.##") 'FormatNumber(TotalValue - CType(JanQty.Text, Decimal), 2)
                DecQty.Text = 0
                CType(grdQty.Rows(gvr.RowIndex).Cells(0).FindControl("lblDec"), Label).Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded quantity exceed from the available quantity.")

            Else
                txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (CType(RQty.Text, Decimal) + TotalValue), "0.##")
                dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = Format(CType(txtTotalQty.Text, Decimal) - CType(txtTotalQtyAmt.Text, Decimal), "0.##")
            End If

            dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
            grdBody.DataSource = dtItemLoaded
            grdBody.DataBind()

            CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)

            '==== SAVE QTY INFO ===
            Dim ID As String = grdBody.SelectedDataKey("Item_ID")
            Dim dr As DataRow
            Dim dt As New DataTable

            dt.Columns.Add("Jan")
            dt.Columns.Add("JanAmt")
            dt.Columns.Add("Feb")
            dt.Columns.Add("FebAmt")
            dt.Columns.Add("Mar")
            dt.Columns.Add("MarAmt")
            dt.Columns.Add("Apr")
            dt.Columns.Add("AprAmt")
            dt.Columns.Add("May")
            dt.Columns.Add("MayAmt")
            dt.Columns.Add("Jun")
            dt.Columns.Add("JunAmt")
            dt.Columns.Add("Jul")
            dt.Columns.Add("JulAmt")
            dt.Columns.Add("Aug")
            dt.Columns.Add("AugAmt")
            dt.Columns.Add("Sep")
            dt.Columns.Add("SepAmt")
            dt.Columns.Add("Oct")
            dt.Columns.Add("OctAmt")
            dt.Columns.Add("Nov")
            dt.Columns.Add("NovAmt")
            dt.Columns.Add("Dec")
            dt.Columns.Add("DecAmt")
            dt.Columns.Add("RQty")
            dt.Columns.Add("RQtyAmt")
            dt.Columns.Add("TotalQuantity")
            dt.Columns.Add("RsrvPerctge")
            dr = dt.NewRow

            dr.Item(0) = CType(JanQty.Text, Decimal)
            dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
            dr.Item(2) = CType(FebQty.Text, Decimal)
            dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
            dr.Item(4) = CType(MarQty.Text, Decimal)
            dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
            dr.Item(6) = CType(AprQty.Text, Decimal)
            dr.Item(7) = CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text
            dr.Item(8) = CType(MayQty.Text, Decimal)
            dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
            dr.Item(10) = CType(JunQty.Text, Decimal)
            dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
            dr.Item(12) = CType(JulQty.Text, Decimal)
            dr.Item(13) = CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text
            dr.Item(14) = CType(AugQty.Text, Decimal)
            dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
            dr.Item(16) = CType(SepQty.Text, Decimal)
            dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
            dr.Item(18) = CType(OctQty.Text, Decimal)
            dr.Item(19) = CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text
            dr.Item(20) = CType(NovQty.Text, Decimal)
            dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
            dr.Item(22) = CType(CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox).Text, Decimal)
            dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text
            dr.Item(24) = CType(RQty.Text, Decimal)
            dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
            dr.Item(26) = CType(txtTotalQty.Text, Decimal)
            dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
            dt.Rows.Add(dr)

            Session(ID) = dt

            LoadAvailableBudget()
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub


    Protected Sub txtReservedPercentage_TextChanged(sender As Object, e As EventArgs) Handles txtReservedPercentage.TextChanged
        If cbWOGoods.Checked = False Then
            If strAction = "" Then
                txtReservedPercentage.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select an item first.")
            Else
                txtReservedPercentage.Text = FormatNumber(txtReservedPercentage.Text, 2)

                LoadAutoReserved()
                txtTotalQty.Enabled = True
                txtReservedPercentage.Enabled = False

            End If
        Else
            txtReservedPercentage.Text = FormatNumber(txtReservedPercentage.Text, 2)
            LoadAutoResrvedAmount()
            txtTotalAmt.Enabled = True

        End If


    End Sub

    Protected Sub txtTotalQty_TextChanged(sender As Object, e As EventArgs)
        Try

            If grdBody.SelectedDataKey("Item_ID") <> 0 Then
                txtTotalQty.Text = Format(txtTotalQty.Text, "{0:#,###,##0.##}")

                Dim prQTY As Integer = 0
                prQTY = Val(objDerived.GetValue("EXEC [AMS].[sp_GetPPMPQuantity] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "','" & Session("GA_ID") & "','" & Session("Project_ID") & "','" & Session("Program_ID") & "','" & Session("BGA_ID") & "','" & grdBody.SelectedDataKey("Item_ID") & "' ", CommandType.Text))


                If Val(txtTotalQty.Text) < prQTY Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Edited quantity should not be less than the PR quantity!!!")
                    Exit Sub

                Else

                End If


                LoadAutoReserved()

                LoadAvailableBudget()



            End If

            'If TotallQty_Postback = "1st Load" Then
            '    If grdBody.SelectedDataKey("Item_ID") <> 0 Then
            '        txtTotalQty.Text = Format(txtTotalQty.Text, "{0:#,###,##0.##}")
            '        LoadAutoReserved()
            '        LoadAvailableBudget()

            '        TotallQty_Postback = "2st Load"
            '    End If
            'End If

        Catch ex As Exception
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select an item.")
            'MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub LoadAutoReserved()
        Dim qtyValue As String = ""
        For Each row As GridViewRow In grdBody.Rows
            If row.RowIndex = grdBody.SelectedIndex Then
                Dim lblQty As Label = CType(row.FindControl("lblqty"), Label)
                qtyValue = Val(lblQty.Text)
                Exit For ' Exit the loop once the selected row is found
            End If
        Next

        Dim ID_1 As Long = objDerived.GetValue("SELECT [ppmp_monthly_hdr_ID] FROM AMS.PPMP_Monthly_Hdr WHERE [CYear] = " & Session("CYear") & " And [RC_ID] = " & Session("RC_ID") & " AND [Function_ID] = " & Session("Function_ID") & " AND isGoods = '" & IIf((cbWOGoods.Checked = True), False, (True)) & "' " &
                                                            " And [Program_ID] = " & Session("Program_ID") & " AND [Project_ID] = " & Session("Project_ID") & " And [GA_ID] = " & Session("GA_ID") & " AND [BGA_ID] = " & Session("BGA_ID") & " And [app_id] = " & Session("app_id") & "", CommandType.Text)




        'Dim ID_PR As Long = objDerived.GetValue("select count(*) from AMS.PR_Hdr WHERE [Program_ID] = " & Session("Program_ID") & " AND [Project_ID] = " & Session("Project_ID") & "", CommandType.text)

        'If ID_PR > 0 Then
        '    If Val(txtTotalQty.text) < qtyValue Then
        '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Quantity should not be deducted if the item already have a PR")
        '        Return
        '    End If

        'Else

        'End If







        Dim UnitCost As Decimal = CType(grdBody.SelectedRow.Cells(4).FindControl("lblamount"), Label).Text
        Dim RsrvQty1 As Double = CType(txtTotalQty.Text, Decimal) * CType((txtReservedPercentage.Text / 100), Decimal)
        Dim RsrvQty As Double = Math.Round(RsrvQty1, 0, MidpointRounding.AwayFromZero)
        Dim qty As Decimal



        If txtTotalQty.Text = 1 Then
            RsrvQty = 0

            CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox).Text = 0
            CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text = FormatNumber(RsrvQty * UnitCost, 2)

            qty = CType(txtTotalQty.Text, Decimal)

            CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Text = Format(qty, "0.##")
            CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox).Text = Format(0, "0.##")
            CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox).Text = Format(0, "0.##")
            CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox).Text = Format(0, "0.##")


        Else

            'RsrvQty = CType(txtTotalQty.Text, Decimal) * CType((txtReservedPercentage.Text / 100), Decimal)

            CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox).Text = RsrvQty
            CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text = FormatNumber(RsrvQty * UnitCost, 2)

            qty = Math.Truncate((CType(txtTotalQty.Text, Decimal) - RsrvQty) / 4)

            CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Text = qty
            CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox).Text = qty
            CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox).Text = qty
            CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox).Text = qty

            'CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Text = Format(qty / 4, "#,###,##0.##")
            'CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox).Text = Format(qty / 4, "#,###,##0.##")
            'CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox).Text = Format(qty / 4, "#,###,##0.##")
            'CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox).Text = Format(qty / 4, "#,###,##0.##")

        End If




        Dim JanQty As TextBox = CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox)
        Dim FebQty As TextBox = CType(grdQty.Rows(0).Cells(1).FindControl("txtFeb"), TextBox)
        Dim MarQty As TextBox = CType(grdQty.Rows(0).Cells(2).FindControl("txtMar"), TextBox)

        Dim AprQty As TextBox = CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox)
        Dim MayQty As TextBox = CType(grdQty.Rows(0).Cells(4).FindControl("txtMay"), TextBox)
        Dim JunQty As TextBox = CType(grdQty.Rows(0).Cells(5).FindControl("txtJun"), TextBox)

        Dim JulQty As TextBox = CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox)
        Dim AugQty As TextBox = CType(grdQty.Rows(0).Cells(7).FindControl("txtAug"), TextBox)
        Dim SepQty As TextBox = CType(grdQty.Rows(0).Cells(8).FindControl("txtSep"), TextBox)

        Dim OctQty As TextBox = CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox)
        Dim NovQty As TextBox = CType(grdQty.Rows(0).Cells(10).FindControl("txtNov"), TextBox)
        Dim DecQty As TextBox = CType(grdQty.Rows(0).Cells(11).FindControl("txtDec"), TextBox)


        CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text = FormatNumber(UnitCost * CType(CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Text, Decimal), 2)
        CType(grdQty.Rows(0).Cells(3).FindControl("lblApr"), Label).Text = FormatNumber(UnitCost * CType(CType(grdQty.Rows(0).Cells(3).FindControl("txtApr"), TextBox).Text, Decimal), 2)
        CType(grdQty.Rows(0).Cells(6).FindControl("lblJul"), Label).Text = FormatNumber(UnitCost * CType(CType(grdQty.Rows(0).Cells(6).FindControl("txtJul"), TextBox).Text, Decimal), 2)
        CType(grdQty.Rows(0).Cells(9).FindControl("lblOct"), Label).Text = FormatNumber(UnitCost * CType(CType(grdQty.Rows(0).Cells(9).FindControl("txtOct"), TextBox).Text, Decimal), 2)

        Dim TQty As Decimal = FormatNumber(CType(Val(JanQty.Text) + Val(FebQty.Text) + Val(MarQty.Text) + Val(AprQty.Text) + Val(MayQty.Text) + Val(JunQty.Text) + Val(JulQty.Text) + Val(AugQty.Text) + Val(SepQty.Text) + Val(OctQty.Text) + Val(NovQty.Text) + Val(DecQty.Text), Decimal), 2)

        txtTotalQtyAmt.Text = Format(CType(txtTotalQty.Text, Decimal) - (RsrvQty + TQty), "0.##")

        dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") = CType(txtTotalQty.Text, Decimal)

        dtItemLoaded.Rows(grdBody.SelectedIndex)("TotalAmt") = FormatNumber(CType(dtItemLoaded.Rows(grdBody.SelectedIndex)("Qty") * UnitCost, Decimal), 2)
        grdBody.DataSource = dtItemLoaded
        grdBody.DataBind()

        CType(grdBody.FooterRow.Cells(5).FindControl("lbltotal"), Label).Text = FormatNumber(dtItemLoaded.Compute("sum(TotalAmt)", ""), 2)


        '==== SAVE QTY INFO ===
        Dim ID As String = grdBody.SelectedDataKey("Item_ID")
        Dim dr As DataRow
        Dim dt As New DataTable

        dt.Columns.Add("Jan")
        dt.Columns.Add("JanAmt")
        dt.Columns.Add("Feb")
        dt.Columns.Add("FebAmt")
        dt.Columns.Add("Mar")
        dt.Columns.Add("MarAmt")
        dt.Columns.Add("Apr")
        dt.Columns.Add("AprAmt")
        dt.Columns.Add("May")
        dt.Columns.Add("MayAmt")
        dt.Columns.Add("Jun")
        dt.Columns.Add("JunAmt")
        dt.Columns.Add("Jul")
        dt.Columns.Add("JulAmt")
        dt.Columns.Add("Aug")
        dt.Columns.Add("AugAmt")
        dt.Columns.Add("Sep")
        dt.Columns.Add("SepAmt")
        dt.Columns.Add("Oct")
        dt.Columns.Add("OctAmt")
        dt.Columns.Add("Nov")
        dt.Columns.Add("NovAmt")
        dt.Columns.Add("Dec")
        dt.Columns.Add("DecAmt")
        dt.Columns.Add("RQty")
        dt.Columns.Add("RQtyAmt")
        dt.Columns.Add("TotalQuantity")
        dt.Columns.Add("RsrvPerctge")
        dr = dt.NewRow


        dr.Item(0) = CType(CType(grdQty.Rows(0).Cells(0).FindControl("txtJan"), TextBox).Text, Decimal)
        dr.Item(1) = CType(grdQty.Rows(0).Cells(0).FindControl("lblJan"), Label).Text
        dr.Item(2) = CType(FebQty.Text, Decimal)
        dr.Item(3) = CType(grdQty.Rows(0).Cells(1).FindControl("lblFeb"), Label).Text
        dr.Item(4) = CType(MarQty.Text, Decimal)
        dr.Item(5) = CType(grdQty.Rows(0).Cells(2).FindControl("lblMar"), Label).Text
        dr.Item(6) = CType(AprQty.Text, Decimal)
        dr.Item(7) = CType(CType(grdQty.Rows(0).Cells(0).FindControl("txtApr"), TextBox).Text, Decimal)
        dr.Item(8) = CType(MayQty.Text, Decimal)
        dr.Item(9) = CType(grdQty.Rows(0).Cells(4).FindControl("lblMay"), Label).Text
        dr.Item(10) = CType(JunQty.Text, Decimal)
        dr.Item(11) = CType(grdQty.Rows(0).Cells(5).FindControl("lblJun"), Label).Text
        dr.Item(12) = CType(JulQty.Text, Decimal)
        dr.Item(13) = CType(CType(grdQty.Rows(0).Cells(0).FindControl("txtJul"), TextBox).Text, Decimal)
        dr.Item(14) = CType(AugQty.Text, Decimal)
        dr.Item(15) = CType(grdQty.Rows(0).Cells(7).FindControl("lblAug"), Label).Text
        dr.Item(16) = CType(SepQty.Text, Decimal)
        dr.Item(17) = CType(grdQty.Rows(0).Cells(8).FindControl("lblSep"), Label).Text
        dr.Item(18) = CType(OctQty.Text, Decimal)
        dr.Item(19) = CType(CType(grdQty.Rows(0).Cells(0).FindControl("txtOct"), TextBox).Text, Decimal)
        dr.Item(20) = CType(NovQty.Text, Decimal)
        dr.Item(21) = CType(grdQty.Rows(0).Cells(10).FindControl("lblNov"), Label).Text
        dr.Item(22) = CType(DecQty.Text, Decimal)
        dr.Item(23) = CType(grdQty.Rows(0).Cells(11).FindControl("lblDec"), Label).Text

        dr.Item(24) = CType(CType(grdQty.Rows(0).Cells(12).FindControl("txtRQty"), TextBox).Text, Decimal)
        dr.Item(25) = CType(grdQty.Rows(0).Cells(12).FindControl("lblRQty"), Label).Text
        dr.Item(26) = CType(txtTotalQty.Text, Decimal)
        dr.Item(27) = CType(txtReservedPercentage.Text, Decimal)
        dt.Rows.Add(dr)

        Session(ID) = dt


    End Sub
    Protected Sub LoadAutoResrvedAmount()
        Try

            If lblAvailableAmt.Visible = True And btnSave.Enabled = False Then
                txtTotalQtyAmt.Text = "0.00"
                txtAvailableBudget.Text = "0.00"
            Else
                Dim RsrvAmt As Decimal = 0

                Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
                Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
                Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
                Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
                Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
                Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
                Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
                Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
                Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
                Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
                Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
                Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
                Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)


                'If cbInfra.Checked = False Then
                '    RsrvAmt = CType(txtTotalAmt.Text, Decimal) * CType((txtReservedPercentage.Text / 100), Decimal)
                '    CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(RsrvAmt, 2)

                'Else
                '    RsrvAmt = 0
                '    CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(RsrvAmt, 2)

                'End If


                RsrvAmt = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text

                Dim TAmt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)

                txtAvailableBudget.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)
                txtTotalQtyAmt.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub


    'Protected Sub txtTotalAmt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAmt.TextChanged
    '    If Session("postback") = False Or Session("postback") = Nothing Then
    '        txtTotalAmt.Text = FormatNumber(txtTotalAmt.Text, 2)

    '        Dim dt As New DataTable
    '        dt = objDerived.GetDataTable("SELECT * FROM LnkdSrvrBOSS.GEOBOS.BOS.BudgetCeiling WHERE BudgetYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' ORDER BY BudgetCeiling_ID DESC", CommandType.Text)

    '        Dim PPMP As Decimal = objDerived.GetValue("EXEC [AMS].[sp_PPMPTotalAmnt] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "' ", CommandType.Text)
    '        Dim PPMP_Amnt As Decimal = 0

    '        If Session("Update") = True Then
    '            PPMP_Amnt = PPMP + (txtTotalAmt.Text - Session("orig_totalAmt"))
    '        Else
    '            PPMP_Amnt = PPMP + txtTotalAmt.Text
    '        End If

    '        ' Check if DataTable has rows before accessing them
    '        If dt.Rows.Count > 0 Then
    '            Dim budgetCeilingAmount As Decimal = dt.Rows(0)("TotalBUdgetCeilingAmount")

    '            If Session("AllotmentType") = 2 Then
    '                txtBudgetCeiling.Text = FormatNumber(budgetCeilingAmount, 2)
    '                txtAvailableAmt.Text = FormatNumber(budgetCeilingAmount - PPMP_Amnt, 2)
    '            Else
    '                txtBudgetCeiling.Text = FormatNumber(budgetCeilingAmount, 2)
    '                txtAvailableAmt.Text = FormatNumber(budgetCeilingAmount - PPMP_Amnt, 2)
    '            End If
    '        Else
    '            ' Handle case when no budget ceiling data is found
    '            txtBudgetCeiling.Text = "0.00"
    '            txtAvailableAmt.Text = "0.00"
    '            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No budget ceiling data found for the current year, RC, and function.")
    '        End If

    '        If CType(txtAvailableAmt.Text, Decimal) < 0 Then
    '            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total PPMP amount already exceeded the budget ceiling, adjust your PPMP.")
    '            lblAvailableAmt.Visible = True
    '            btnSave.Enabled = False
    '        Else
    '            lblAvailableAmt.Visible = False
    '            btnSave.Enabled = True

    '            'LoadAutoResrvedAmount()


    '            If lblAvailableAmt.Visible = True And btnSave.Enabled = False Then
    '                txtTotalQtyAmt.Text = "0.00"
    '                txtAvailableBudget.Text = "0.00"
    '            Else
    '                Dim RsrvAmt As Decimal = 0

    '                Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
    '                Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
    '                Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
    '                Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
    '                Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
    '                Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
    '                Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
    '                Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
    '                Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
    '                Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
    '                Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
    '                Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
    '                Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)


    '                If cbInfra.Checked = False Then
    '                    RsrvAmt = CType(txtTotalAmt.Text, Decimal) * CType((txtReservedPercentage.Text / 100), Decimal)
    '                    CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(RsrvAmt, 2)

    '                Else
    '                    RsrvAmt = 0
    '                    CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(RsrvAmt, 2)

    '                End If


    '                Dim PerMonth As Decimal = ((txtTotalAmt.Text - RsrvAmt) / 12)
    '                CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox).Text = FormatNumber(PerMonth, 2)
    '                CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox).Text = FormatNumber(PerMonth, 2)


    '                Dim TAmt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
    '                txtTotalQtyAmt.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)
    '                txtAvailableBudget.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)

    '                'If Session("Update") = True Then
    '                '    txtAvailableBudget.Text = FormatNumber(txtBudgetCeiling.Text - (txtAvailableBudget.Text + txtTotalAmt.Text), 2)
    '                'Else
    '                '    txtAvailableBudget.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)
    '                'End If
    '            End If



    '        End If

    '        Session("postback") = True
    '    Else
    '        Session("postback") = False
    '    End If

    'End Sub


    Protected Sub txtTotalAmt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAmt.TextChanged
        If Session("postback") = False Or Session("postback") = Nothing Then
            txtTotalAmt.Text = FormatNumber(txtTotalAmt.Text, 2)

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM LnkdSrvrBOSS.GEOBOS.BOS.BudgetCeiling WHERE BudgetYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' ORDER BY BudgetCeiling_ID DESC", CommandType.Text)

            Dim PPMP As Decimal = objDerived.GetValue("EXEC [AMS].[sp_PPMPTotalAmnt] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "' ", CommandType.Text)
            Dim PPMP_Amnt As Decimal = 0

            If Session("Update") = True Then
                PPMP_Amnt = PPMP + (txtTotalAmt.Text - Session("orig_totalAmt"))
            Else
                PPMP_Amnt = PPMP + txtTotalAmt.Text
            End If

            ' Check if DataTable has rows before accessing them
            If dt.Rows.Count > 0 Then
                Dim budgetCeilingAmount As Decimal = dt.Rows(0)("TotalBUdgetCeilingAmount")

                If Session("AllotmentType") = 2 Then
                    txtBudgetCeiling.Text = FormatNumber(budgetCeilingAmount, 2)
                    txtAvailableAmt.Text = FormatNumber(budgetCeilingAmount - PPMP_Amnt, 2)
                Else
                    txtBudgetCeiling.Text = FormatNumber(budgetCeilingAmount, 2)
                    txtAvailableAmt.Text = FormatNumber(budgetCeilingAmount - PPMP_Amnt, 2)
                End If
            Else
                ' Handle case when no budget ceiling data is found
                txtBudgetCeiling.Text = "0.00"
                txtAvailableAmt.Text = "0.00"
                'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No budget ceiling data found for the current year, RC, and function.")
            End If

            If CType(txtAvailableAmt.Text, Decimal) < 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Total PPMP amount already exceeded the budget ceiling, adjust your PPMP.")
                lblAvailableAmt.Visible = True
                btnSave.Enabled = False
            Else
                lblAvailableAmt.Visible = False
                btnSave.Enabled = True

                'LoadAutoResrvedAmount()

                If lblAvailableAmt.Visible = True And btnSave.Enabled = False Then
                    txtTotalQtyAmt.Text = "0.00"
                    txtAvailableBudget.Text = "0.00"
                Else
                    Dim RsrvAmt As Decimal = 0

                    Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
                    Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
                    Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
                    Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
                    Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
                    Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
                    Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
                    Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
                    Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
                    Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
                    Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
                    Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
                    Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

                    If cbInfra.Checked = False Then
                        RsrvAmt = CType(txtTotalAmt.Text, Decimal) * CType((txtReservedPercentage.Text / 100), Decimal)
                        CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(RsrvAmt, 2)
                    Else
                        RsrvAmt = 0
                        CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text = FormatNumber(RsrvAmt, 2)
                    End If

                    ' Calculate quarterly distribution (divide by 4 for each quarter)
                    Dim PerQuarter As Decimal = ((txtTotalAmt.Text - RsrvAmt) / 4)

                    ' Set quarterly amounts (Q1: Jan, Q2: Apr, Q3: Jul, Q4: Oct)
                    CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox).Text = FormatNumber(PerQuarter, 2)  ' Q1
                    CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox).Text = FormatNumber(PerQuarter, 2)  ' Q2
                    CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox).Text = FormatNumber(PerQuarter, 2)  ' Q3
                    CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox).Text = FormatNumber(PerQuarter, 2)  ' Q4

                    ' Set other months to 0.00
                    CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox).Text = "0.00"
                    CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox).Text = "0.00"

                    Dim TAmt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(OctAmt.Text, Decimal), 2)
                    txtTotalQtyAmt.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)
                    txtAvailableBudget.Text = FormatNumber(CType(txtTotalAmt.Text, Decimal) - (RsrvAmt + TAmt), 2)
                End If
            End If

            Session("postback") = True
        Else
            Session("postback") = False
        End If
    End Sub


    Protected Sub txtJanAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim JanAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(JanAmt.NamingContainer, GridViewRow)

            If JanAmt.Text = "" Then
                JanAmt.Text = "0.00"
            End If

            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                JanAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            JanAmt.Text = FormatNumber(JanAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtFebAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim FebAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(FebAmt.NamingContainer, GridViewRow)

            If FebAmt.Text = "" Then
                FebAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)

            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                FebAmt.Text = "0.00"
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            FebAmt.Text = FormatNumber(FebAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtMarAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim MarAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(MarAmt.NamingContainer, GridViewRow)

            If MarAmt.Text = "" Then
                MarAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)

            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                MarAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            MarAmt.Text = FormatNumber(MarAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtAprAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim AprAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(AprAmt.NamingContainer, GridViewRow)

            If AprAmt.Text = "" Then
                AprAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)

            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)
            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                AprAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            AprAmt.Text = FormatNumber(AprAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtMayAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim MayAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(MayAmt.NamingContainer, GridViewRow)

            If MayAmt.Text = "" Then
                MayAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)

            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                MayAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            MayAmt.Text = FormatNumber(MayAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtJunAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim JunAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(JunAmt.NamingContainer, GridViewRow)

            If JunAmt.Text = "" Then
                JunAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)

            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                JunAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            JunAmt.Text = FormatNumber(JunAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtJulAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim JulAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(JulAmt.NamingContainer, GridViewRow)

            If JulAmt.Text = "" Then
                JulAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)

            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                JulAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            JulAmt.Text = FormatNumber(JulAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtAugAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim AugAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(AugAmt.NamingContainer, GridViewRow)

            If AugAmt.Text = "" Then
                AugAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)

            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                AugAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            AugAmt.Text = FormatNumber(AugAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtSepAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim SepAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(SepAmt.NamingContainer, GridViewRow)

            If SepAmt.Text = "" Then
                SepAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)

            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                SepAmt.Text = "0.00"
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            SepAmt.Text = FormatNumber(SepAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtOctAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim OctAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(OctAmt.NamingContainer, GridViewRow)

            If OctAmt.Text = "" Then
                OctAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)

            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                OctAmt.Text = "0.00"
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            OctAmt.Text = FormatNumber(OctAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub
    Protected Sub txtNovAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim NovAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(NovAmt.NamingContainer, GridViewRow)

            If NovAmt.Text = "" Then
                NovAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)

            Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)
            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                NovAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            NovAmt.Text = FormatNumber(NovAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)

        End Try
    End Sub
    Protected Sub txtDecAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim DecAmt As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(DecAmt.NamingContainer, GridViewRow)

            If DecAmt.Text = "" Then
                DecAmt.Text = "0.00"
            End If

            Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
            Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
            Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
            Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
            Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
            Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
            Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
            Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
            Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
            Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
            Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)

            Dim RQtyAmt As TextBox = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox)

            'txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
            'txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            Dim Amt As Decimal = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

            If CType(txtTotalAmt.Text, Decimal) < Amt Then
                DecAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encoded amount exceed from the available amount.")
            End If

            DecAmt.Text = FormatNumber(DecAmt.Text, 2)

            LoadAutoResrvedAmount()
            LoadAvailableBudget()


        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub

    'Protected Sub txtRQtyAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim RQtyAmt As TextBox = TryCast(sender, TextBox)
    '        Dim gvr As GridViewRow = TryCast(RQtyAmt.NamingContainer, GridViewRow)

    '        If RQtyAmt.Text = "" Then
    '            RQtyAmt.Text = "0.00"
    '        End If

    '        Dim JanAmt As TextBox = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox)
    '        Dim FebAmt As TextBox = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox)
    '        Dim MarAmt As TextBox = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox)
    '        Dim AprAmt As TextBox = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox)
    '        Dim MayAmt As TextBox = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox)
    '        Dim JunAmt As TextBox = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox)
    '        Dim JulAmt As TextBox = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox)
    '        Dim AugAmt As TextBox = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox)
    '        Dim SepAmt As TextBox = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox)
    '        Dim OctAmt As TextBox = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox)
    '        Dim NovAmt As TextBox = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox)
    '        Dim DecAmt As TextBox = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox)

    '        txtTotalQtyAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal), 2)
    '        txtTotalAmt.Text = FormatNumber(CType(JanAmt.Text, Decimal) + CType(FebAmt.Text, Decimal) + CType(MarAmt.Text, Decimal) + CType(AprAmt.Text, Decimal) + CType(MayAmt.Text, Decimal) + CType(JunAmt.Text, Decimal) + CType(JulAmt.Text, Decimal) + CType(AugAmt.Text, Decimal) + CType(SepAmt.Text, Decimal) + CType(OctAmt.Text, Decimal) + CType(NovAmt.Text, Decimal) + CType(DecAmt.Text, Decimal) + CType(RQtyAmt.Text, Decimal), 2)

    '        RQtyAmt.Text = FormatNumber(RQtyAmt.Text, 2)

    '        LoadAvailableBudget()

    '    Catch ex As Exception
    '        msg.UserMsgBox(ex.ToString, Me, False)
    '    End Try
    'End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        Try

            'If drpProcurement.SelectedItem.Text = "Select" Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select Procurement Method.")
            'Else

            If drpPreparedBy.SelectedItem.Text = "Select" Or drpApprovedBy.SelectedItem.Text = "Select" Or drpCheckedBy.SelectedItem.Text = "Select" Or drpNotedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select signatories.")

            ElseIf txtAvailableBudget.Text < 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please adjust your PPMP.")

            ElseIf txtTotalQtyAmt.Text < 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please adjust your per month.")

            Else
                Try
                    If dtItemLoaded.Rows.Count > 0 Then
                        For i As Integer = 0 To dtItemLoaded.Rows.Count - 1
                            Dim lblQty As Label = CType(grdBody.Rows(i).Cells(0).FindControl("lblqty"), Label)
                            If lblQty IsNot Nothing AndAlso lblQty.Text = "0" Then
                                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please encode quantity on all added items.")
                                Exit Sub
                            End If
                        Next
                    End If
                Catch ex As Exception
                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact the admin.")
                End Try
                'CType(grdBody.Rows(0).Cells(0).FindControl("lblqty"), label)

                '-- CHECK IF PAOO IS ALREADY SUBMITTED
                'Dim isSubmitted As Integer = objDerived.GetValue("SELECT CASE WHEN A.isPosted = 1 THEN 1 ELSE 0 END AS isPosted FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Hdr AS A WHERE A.Budget_Year = " & Session("CYear") & " AND A.RC_ID = " & Session("RC_ID") & " AND A.Function_ID = " & Session("Function_ID") & " AND A.Program_ID = " & Session("Program_ID") & " AND A.Project_ID = " & Session("Project_ID") & "", CommandType.Text)
                'If isSubmitted = 1 Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Cannot update the PPMP, please return the PAOO to LBPF 2 first before updating the PPMP.")
                '    Exit Sub
                'End If

                '12202023
                '==== CHECK IF FOR REVISION ===
                If Session("APP_Status") = 2 Then
                    Dim forRevision As Boolean = objDerived.GetValue("SELECT ISNULL((SELECT [forRevision] FROM AMS.PPMP_Monthly_Hdr WHERE [CYear] = " & Session("CYear") & " And [RC_ID] = " & Session("RC_ID") & " AND [Function_ID] = " & Session("Function_ID") & " And [Program_ID] = " & Session("Program_ID") & " AND [Project_ID] = " & Session("Project_ID") & " And [GA_ID] = " & Session("GA_ID") & " AND [BGA_ID] = " & Session("BGA_ID") & " And [app_id] = " & Session("app_id") & "),0)", CommandType.Text)

                    If forRevision = 0 Or forRevision = False Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Your PPMP is already lock, or APP is in executing Status")
                        Exit Sub
                    End If
                End If

                '==== SAVE PPMP HEADER PER MONTH === 
                With ppmp_hdr
                    .CYear = Session("CYear")
                    .RC_ID = Session("RC_ID")
                    .Function_ID = Session("Function_ID")
                    .Program_ID = Session("Program_ID")
                    .Project_ID = Session("Project_ID")
                    .GA_ID = Session("GA_ID")
                    .BGA_ID = Session("BGA_ID")
                    .ReservedPercentage = CType(txtReservedPercentage.Text, Decimal)
                    .ReservedAmt = 0
                    .ProcurementMethod = IIf((drpProcurement.SelectedItem.Text = "Select"), 0, (drpProcurement.SelectedItem.Value))
                    .PreparedBy = drpPreparedBy.SelectedItem.Value
                    .ReviewdBy = 0
                    .ApprovedBy = IIf((drpApprovedBy.SelectedItem.Text = "Select"), 0, (drpApprovedBy.SelectedItem.Value))
                    .CheckedBy = IIf((drpCheckedBy.SelectedItem.Text = "Select"), 0, (drpCheckedBy.SelectedItem.Value))
                    .NotedBy = IIf((drpNotedBy.SelectedItem.Text = "Select"), 0, (drpNotedBy.SelectedItem.Value))
                    .app_id = Session("app_id")
                    .isGoods = IIf((cbWOGoods.Checked = True), False, (True))
                    .isFinal = False
                    .isSupplemental = False
                    .UserID = Session("@UserName")
                    .isInfra = cbInfra.Checked
                End With

                Dim ID As Long = objDerived.GetValue("SELECT [ppmp_monthly_hdr_ID] FROM AMS.PPMP_Monthly_Hdr WHERE [CYear] = " & Session("CYear") & " And [RC_ID] = " & Session("RC_ID") & " AND [Function_ID] = " & Session("Function_ID") & " AND isGoods = '" & IIf((cbWOGoods.Checked = True), False, (True)) & "' And [Program_ID] = " & Session("Program_ID") & " AND [Project_ID] = " & Session("Project_ID") & " And [GA_ID] = " & Session("GA_ID") & " AND [BGA_ID] = " & Session("BGA_ID") & " And [app_id] = " & Session("app_id") & "", CommandType.Text)

                If ID = 0 Then
                    ppmp_hdr.forRevision = False
                    Session("ppmp_monthly_hdr_ID") = ppmp_hdr.Save
                Else
                    ppmp_hdr.forRevision = objDerived.GetValue("SELECT forRevision FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & ID & "'", CommandType.Text)
                    ppmp_hdr.ppmp_monthly_hdr_ID = ID
                    Session("ppmp_monthly_hdr_ID") = ppmp_hdr.Update
                End If

                objDerived.Execute("UPDATE AMS.PPMP_Monthly_Hdr SET PreparedBy = '" & drpPreparedBy.SelectedItem.Value & "' WHERE  CYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "'", CommandType.Text)

                If cbWOGoods.Checked = True Then
                    Dim Dtl As Long = objDerived.GetValue("SELECT TOP(1) [ppmp_monthly_dtl_ID] FROM [AMS].[PPMP_Monthly_Dtl] WHERE [ppmp_monthly_hdr_ID] = " & ID & "", CommandType.Text)
                    With ppmp_dtl
                        .ppmp_monthly_hdr_ID = Session("ppmp_monthly_hdr_ID")
                        .Item_ID = 0
                        .UnitPrice = 0
                        .ActualPrice = 0
                        .GenDescription = replaceapostrophe(txtGenDesc.Text)
                        .Jan = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox).Text
                        .Feb = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox).Text
                        .Mar = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox).Text
                        .Apr = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox).Text
                        .May = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox).Text
                        .Jun = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox).Text
                        .Jul = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox).Text
                        .Aug = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox).Text
                        .Sep = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox).Text
                        .Oct = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox).Text
                        .Nov = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox).Text
                        .Dec = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox).Text
                        .Total = txtTotalAmt.Text 'CType(...) ...
                        .ReservedQty = 0
                        .ReservedAmt = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text
                        .UserID = Session("@UserName")

                        If Session("Update") = True Then
                            .ppmp_monthly_dtl_ID = Session("ppmp_monthly_dtl_ID")
                            .Update()
                        Else
                            .Save()
                        End If
                    End With

                    Dim forRevision As Boolean = objDerived.GetValue("SELECT forRevision FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & Session("ppmp_monthly_hdr_ID") & "'", CommandType.Text)
                    If forRevision = 0 Then
                        '====== SAVE PPMP DETAIL HISTORY =====
                        With ppmp_revision
                            .ppmp_monthly_hdr_ID = Session("ppmp_monthly_hdr_ID")
                            .Revision_No = 0
                            .Item_ID = 0
                            .UnitPrice = 0
                            .GenDescription = txtGenDesc.Text
                            .Jan = CType(grdAmounts.Rows(0).Cells(0).FindControl("txtJanAmt"), TextBox).Text
                            .Feb = CType(grdAmounts.Rows(0).Cells(1).FindControl("txtFebAmt"), TextBox).Text
                            .Mar = CType(grdAmounts.Rows(0).Cells(2).FindControl("txtMarAmt"), TextBox).Text
                            .Apr = CType(grdAmounts.Rows(0).Cells(3).FindControl("txtAprAmt"), TextBox).Text
                            .May = CType(grdAmounts.Rows(0).Cells(4).FindControl("txtMayAmt"), TextBox).Text
                            .Jun = CType(grdAmounts.Rows(0).Cells(5).FindControl("txtJunAmt"), TextBox).Text
                            .Jul = CType(grdAmounts.Rows(0).Cells(6).FindControl("txtJulAmt"), TextBox).Text
                            .Aug = CType(grdAmounts.Rows(0).Cells(7).FindControl("txtAugAmt"), TextBox).Text
                            .Sep = CType(grdAmounts.Rows(0).Cells(8).FindControl("txtSepAmt"), TextBox).Text
                            .Oct = CType(grdAmounts.Rows(0).Cells(9).FindControl("txtOctAmt"), TextBox).Text
                            .Nov = CType(grdAmounts.Rows(0).Cells(10).FindControl("txtNovAmt"), TextBox).Text
                            .Dec = CType(grdAmounts.Rows(0).Cells(11).FindControl("txtDecAmt"), TextBox).Text
                            .Total = txtTotalAmt.Text
                            .ReservedQty = 0
                            .ReservedAmt = CType(grdAmounts.Rows(0).Cells(12).FindControl("txtRQtyAmt"), TextBox).Text
                            .UserID = Session("@UserName")

                            If Dtl = 0 Then
                                .Save()
                            Else
                                .ppmp_monthly_Revision_ID = objDerived.GetValue("SELECT ppmp_monthly_Revision_ID FROM AMS.PPMP_Monthly_Revision WHERE ppmp_monthly_hdr_ID = '" & Session("ppmp_monthly_hdr_ID") & "'", CommandType.Text)
                                .Update()
                            End If
                        End With
                    End If

                Else
                    '==== SAVE PPMP HEADER PER QUARTER === 
                    With hdr
                        .pDate = txtDate.Text
                        .CYear = Session("CYear")
                        .RC_ID = Session("RC_ID")
                        .Function_ID = Session("Function_ID")
                        .Program_id = Session("Program_ID")
                        .Project_ID = Session("Project_ID")
                        .GA_ID = Session("GA_ID")
                        .BGA_ID = Session("BGA_ID")
                        .PreparedBy = drpPreparedBy.SelectedItem.Value
                        .ReviewedBy = 0
                        .ApprovedBy = 0
                        .RecommendedBy = 0
                        .firstqtr = False
                        .secondqrt = False
                        .thirdqtr = False
                        .fourthqrt = False
                        .isfinal = False
                        .isContinuing = False
                        .isSupplemental = False
                        .mode_of_procurement = IIf((drpProcurement.SelectedItem.Text = "Select"), 0, (drpProcurement.SelectedItem.Value))
                        .app_id = Session("app_id")
                        .Userid = Session("@UserName")
                    End With

                    Dim PQID As Long = objDerived.GetValue("SELECT [ppmp_hdr_id] FROM [AMS].[ppmp_hdr] WHERE [CYear] = " & Session("CYear") & " And [RC_ID] = " & Session("RC_ID") & " AND [Function_ID] = " & Session("Function_ID") & "  And [Program_ID] = " & Session("Program_ID") & " AND [Project_ID] = " & Session("Project_ID") & " And [GA_ID] = " & Session("GA_ID") & " AND [BGA_ID] = " & Session("BGA_ID") & " And [app_id] = " & Session("app_id") & "", CommandType.Text)

                    If PQID = 0 Then
                        hdr.isforRevision = False
                        Session("ppmp_hdr_id") = hdr.save
                    Else
                        hdr.ppmp_hdr_id = PQID
                        Session("ppmp_hdr_id") = hdr.Update
                    End If

                    For i As Integer = 0 To dtItemLoaded.Rows.Count - 1
                        Dim dtGrd As New GridView
                        Dim x As Integer = dtItemLoaded.Rows(i)("Item_ID")
                        dtGrd.DataSource = CType(Me.Session(dtItemLoaded.Rows(i)("Item_ID").ToString), DataTable)
                        dtGrd.DataBind()

                        '=== PPMP DETAILS PER MONTH ===
                        With ppmp_dtl
                            .ppmp_monthly_hdr_ID = Session("ppmp_monthly_hdr_ID")
                            .Item_ID = dtItemLoaded.Rows(i)("Item_ID")
                            .UnitPrice = dtItemLoaded.Rows(i)("UnitPrice")
                            .ActualPrice = 0
                            .GenDescription = ""
                            .Jan = dtGrd.Rows(0).Cells(0).Text
                            .Feb = dtGrd.Rows(0).Cells(2).Text
                            .Mar = dtGrd.Rows(0).Cells(4).Text
                            .Apr = dtGrd.Rows(0).Cells(6).Text
                            .May = dtGrd.Rows(0).Cells(8).Text
                            .Jun = dtGrd.Rows(0).Cells(10).Text
                            .Jul = dtGrd.Rows(0).Cells(12).Text
                            .Aug = dtGrd.Rows(0).Cells(14).Text
                            .Sep = dtGrd.Rows(0).Cells(16).Text
                            .Oct = dtGrd.Rows(0).Cells(18).Text
                            .Nov = dtGrd.Rows(0).Cells(20).Text
                            .Dec = dtGrd.Rows(0).Cells(22).Text
                            .Total = (CType(dtGrd.Rows(0).Cells(0).Text, Decimal) + CType(dtGrd.Rows(0).Cells(2).Text, Decimal) + CType(dtGrd.Rows(0).Cells(4).Text, Decimal) + CType(dtGrd.Rows(0).Cells(6).Text, Decimal) + CType(dtGrd.Rows(0).Cells(8).Text, Decimal) + CType(dtGrd.Rows(0).Cells(10).Text, Decimal) + CType(dtGrd.Rows(0).Cells(12).Text, Decimal) + CType(dtGrd.Rows(0).Cells(14).Text, Decimal) + CType(dtGrd.Rows(0).Cells(16).Text, Decimal) + CType(dtGrd.Rows(0).Cells(18).Text, Decimal) + CType(dtGrd.Rows(0).Cells(20).Text, Decimal) + CType(dtGrd.Rows(0).Cells(22).Text, Decimal))
                            .ReservedQty = dtGrd.Rows(0).Cells(24).Text
                            .ReservedAmt = CType(dtGrd.Rows(0).Cells(24).Text * dtItemLoaded.Rows(i)("UnitPrice"), Decimal)
                            .UserID = Session("@UserName")

                            If dtItemLoaded.Rows(i)("ppmp_monthly_dtl_ID") = 0 Then
                                .Save()
                            Else
                                .ppmp_monthly_dtl_ID = dtItemLoaded.Rows(i)("ppmp_monthly_dtl_ID")
                                .Update()
                            End If
                        End With

                        Dim forRevision As Boolean = objDerived.GetValue("SELECT forRevision FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & Session("ppmp_monthly_hdr_ID") & "'", CommandType.Text)
                        If forRevision = 0 Then
                            '=== PPMP REVISION DETAILS PER MONTH ===
                            With ppmp_revision
                                .ppmp_monthly_hdr_ID = Session("ppmp_monthly_hdr_ID")
                                .Revision_No = 0
                                .Item_ID = dtItemLoaded.Rows(i)("Item_ID")
                                .UnitPrice = dtItemLoaded.Rows(i)("UnitPrice")
                                .ActualPrice = 0
                                .GenDescription = ""
                                .Jan = dtGrd.Rows(0).Cells(0).Text
                                .Feb = dtGrd.Rows(0).Cells(2).Text
                                .Mar = dtGrd.Rows(0).Cells(4).Text
                                .Apr = dtGrd.Rows(0).Cells(6).Text
                                .May = dtGrd.Rows(0).Cells(8).Text
                                .Jun = dtGrd.Rows(0).Cells(10).Text
                                .Jul = dtGrd.Rows(0).Cells(12).Text
                                .Aug = dtGrd.Rows(0).Cells(14).Text
                                .Sep = dtGrd.Rows(0).Cells(16).Text
                                .Oct = dtGrd.Rows(0).Cells(18).Text
                                .Nov = dtGrd.Rows(0).Cells(20).Text
                                .Dec = dtGrd.Rows(0).Cells(22).Text
                                .Total = (CType(dtGrd.Rows(0).Cells(0).Text, Decimal) + CType(dtGrd.Rows(0).Cells(2).Text, Decimal) + CType(dtGrd.Rows(0).Cells(4).Text, Decimal) + CType(dtGrd.Rows(0).Cells(6).Text, Decimal) + CType(dtGrd.Rows(0).Cells(8).Text, Decimal) + CType(dtGrd.Rows(0).Cells(10).Text, Decimal) + CType(dtGrd.Rows(0).Cells(12).Text, Decimal) + CType(dtGrd.Rows(0).Cells(14).Text, Decimal) + CType(dtGrd.Rows(0).Cells(16).Text, Decimal) + CType(dtGrd.Rows(0).Cells(18).Text, Decimal) + CType(dtGrd.Rows(0).Cells(20).Text, Decimal) + CType(dtGrd.Rows(0).Cells(22).Text, Decimal))
                                .ReservedQty = dtGrd.Rows(0).Cells(24).Text
                                .ReservedAmt = CType(dtGrd.Rows(0).Cells(24).Text * dtItemLoaded.Rows(i)("UnitPrice"), Decimal)
                                .UserID = Session("@UserName")

                                If dtItemLoaded.Rows(i)("ppmp_monthly_dtl_ID") = 0 Then
                                    .Save()
                                Else
                                    .ppmp_monthly_Revision_ID = objDerived.GetValue("SELECT ppmp_monthly_Revision_ID FROM AMS.PPMP_Monthly_Revision WHERE ppmp_monthly_hdr_ID = '" & Session("ppmp_monthly_hdr_ID") & "' AND Item_ID = '" & dtItemLoaded.Rows(i)("Item_ID") & "'", CommandType.Text)
                                    .Update()
                                End If
                            End With
                        End If

                        '=== PPMP PER QUARTER DETAILS ===
                        With dtl
                            .ppmp_hdr_id = Session("ppmp_hdr_id")
                            .Item_ID = dtItemLoaded.Rows(i)("Item_ID")
                            .Cost = dtItemLoaded.Rows(i)("UnitPrice")
                            .firstqty = CType(dtGrd.Rows(0).Cells(0).Text, Decimal) + CType(dtGrd.Rows(0).Cells(2).Text, Decimal) + CType(dtGrd.Rows(0).Cells(4).Text, Decimal)
                            .secondqty = CType(dtGrd.Rows(0).Cells(6).Text, Decimal) + CType(dtGrd.Rows(0).Cells(8).Text, Decimal) + CType(dtGrd.Rows(0).Cells(10).Text, Decimal)
                            .thirdqty = CType(dtGrd.Rows(0).Cells(12).Text, Decimal) + CType(dtGrd.Rows(0).Cells(14).Text, Decimal) + CType(dtGrd.Rows(0).Cells(16).Text, Decimal)
                            .fourthqty = CType(dtGrd.Rows(0).Cells(18).Text, Decimal) + CType(dtGrd.Rows(0).Cells(20).Text, Decimal) + CType(dtGrd.Rows(0).Cells(22).Text, Decimal)
                            .firstqtybal = CType(dtGrd.Rows(0).Cells(0).Text, Decimal) + CType(dtGrd.Rows(0).Cells(2).Text, Decimal) + CType(dtGrd.Rows(0).Cells(4).Text, Decimal)
                            .secondqtybal = CType(dtGrd.Rows(0).Cells(6).Text, Decimal) + CType(dtGrd.Rows(0).Cells(8).Text, Decimal) + CType(dtGrd.Rows(0).Cells(10).Text, Decimal)
                            .thirdqtybal = CType(dtGrd.Rows(0).Cells(12).Text, Decimal) + CType(dtGrd.Rows(0).Cells(14).Text, Decimal) + CType(dtGrd.Rows(0).Cells(16).Text, Decimal)
                            .fourthqtybal = CType(dtGrd.Rows(0).Cells(18).Text, Decimal) + CType(dtGrd.Rows(0).Cells(20).Text, Decimal) + CType(dtGrd.Rows(0).Cells(22).Text, Decimal)
                            .Userid = Session("@UserName")
                        End With

                        Dim DtlQID As Long = objDerived.GetValue("SELECT [ppmp_dtl_id] FROM [AMS].[ppmp_dtl] WHERE [ppmp_hdr_id] = " & Session("ppmp_hdr_id") & " AND [Item_ID] = " & dtItemLoaded.Rows(i)("Item_ID") & "", CommandType.Text)

                        If DtlQID = 0 Then
                            dtl.save()
                        Else
                            dtl.ppmp_dtl_id = DtlQID
                            dtl.Update()
                        End If
                    Next
                End If

                lnkView.Enabled = False
                btnSave.Enabled = False
                btnSubmit.Enabled = True
                btnPreview.Enabled = True

                CreateDataTableAmt()
                grdAmounts.DataSource = dtMonthly
                grdAmounts.DataBind()

                CreateDataTableQty()
                grdQty.DataSource = dtMonthly
                grdQty.DataBind()

                grdBody.DataSource = DataTableBody(5)
                grdBody.DataBind()

                txtTotalQty.Text = "0.00"
                txtTotalAmt.Text = "0.00"
                txtReservedPercentage.Text = "0.00"
                txtTotalQtyAmt.Text = "0.00"

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                '---------------------------------------------------
                ' CHECK BUDGET CEILING
                '---------------------------------------------------
                'Dim dt As New DataTable
                'dt = objDerived.GetDataTable("SELECT TOP(1) * FROM LnkdSrvrBOSS.GEOBOS.BOS.BudgetCeiling WHERE BudgetYear = '" & Session("CYear") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' ORDER BY BudgetCeiling_ID DESC", CommandType.Text)
                'If dt.Rows.Count < 1 Then
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Budget ceiling is required to create ppmp, contact budget office.")
                '    txtBudgetCeiling.Text = "0.00"
                '    ddGenAccount.Enabled = False
                'Else
                '    Dim PPMP_Amnt As Decimal = objDerived.GetValue("EXEC [AMS].[sp_PPMPTotalAmnt] '" & Session("CYear") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "' ", CommandType.Text)
                '    txtBudgetCeiling.Text = FormatNumber(dt.Rows(0)("TotalBUdgetCeilingAmount"), 2)
                '    txtAvailableAmt.Text = FormatNumber(dt.Rows(0)("TotalBUdgetCeilingAmount") - PPMP_Amnt, 2)
                '    If txtAvailableAmt.Text < 1 Then
                '        lblAvailableAmt.Visible = True
                '    Else
                '        lblAvailableAmt.Visible = False
                '    End If
                'End If

                LoadPPMPList_PerTab()
                LoadRefreshDetails()

                'LoadDisabledAll()
            End If
            ''For i As Integer = 0 To grdBody.Rows.Count - 1
            ''    objDerived.Execute("Update dbo.m_item set withPPMP = true where item_id='" & grdBody)
            ''Next

            If cbWOGoods.Checked = True Then
                Session("isGoods") = True
            Else
                Session("isGoods") = False
            End If



            'End If
        Catch ex As Exception
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong during the process, pls contact system admin.")
            'MsgBox(ex.Message)
        End Try
    End Sub









    Protected Sub LoadRefreshDetails()
        dtAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_PPMP_GenAccountList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("AllotmentType") & "", CommandType.Text)
        ddGenAccount.DataSource = dtAccounts
        ddGenAccount.DataTextField = ("GA_Title2")
        ddGenAccount.DataValueField = ("GA_Code2")
        ddGenAccount.DataBind()
        ddGenAccount.Items.Insert(0, "Select")

        txtGenDesc.Text = ""

    End Sub

    Protected Sub LoadDisabledAll()
        'dtYear = objDerived.GetDataTable("SELECT * FROM [AMS].[vw_app_status] WHERE status <> 3 ORDER BY year DESC", CommandType.Text)
        'ddyear.DataSource = dtYear
        'ddyear.DataTextField = ("year")
        'ddyear.DataValueField = ("app_id")
        'ddyear.DataBind()
        'ddyear.Items.Insert(0, "Select")

        'dtDepartments = objDerived.GetDataTable("EXEC [dbo].[sp_respcenter_systemManager] '" & Session("RoleName") & "'", CommandType.Text)
        'ddRC.DataSource = dtDepartments
        'ddRC.DataTextField = ("rc_name")
        'ddRC.DataValueField = ("rc_id")
        'ddRC.DataBind()
        'ddRC.Items.Insert(0, "Select")

        ddyear.Enabled = True
        ddRC.Enabled = True
        ddFunction.Enabled = False
        ddPPA.Enabled = False
        ddAllotmentType.Enabled = False
        chkOOE.Enabled = False
        cbWOGoods.Enabled = False
        ddGenAccount.Enabled = False
        lnkView.Enabled = False

        btnSave.Enabled = False
    End Sub
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            objDerived.Execute("UPDATE [AMS].[PPMP_Monthly_Hdr] SET [isFinal] = 1 WHERE [ppmp_monthly_hdr_ID] = " & Session("ppmp_monthly_hdr_ID") & "", CommandType.Text)

            If cbWOGoods.Checked = False Then
                objDerived.Execute("UPDATE [AMS].[ppmp_hdr] SET [Isfinal] = 1 WHERE [ppmp_hdr_id] = " & Session("ppmp_hdr_id") & "", CommandType.Text)
            End If

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PPMP has been successfully submitted.")

            btnSubmit.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Page") = "Planning_PPMP"
        Session("isInfra") = cbInfra.Checked
        'Me.Page.Response.Redirect("~/MainReports/Report_Planning.aspx")


        Dim url As String = "../MainReports/Report_Planning.aspx"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)



    End Sub

    Protected Sub lnkOOESelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        str_OOE = "Select"
    End Sub
    Protected Sub lnkOOEDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        str_OOE = "Delete"
    End Sub
    Private Sub gvppmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvppmp.SelectedIndexChanged
        Try
            Session("Update") = True
            Session("Program_ID") = 0
            Session("Project_ID") = 0
            Session("GA_ID") = gvppmp.SelectedDataKey("GA_ID")
            Session("BGA_ID") = gvppmp.SelectedDataKey("BGA_ID")
            Session("AllotmentType") = gvppmp.SelectedDataKey("AllotmentClass_ID")
            Session("PPMP_Amt") = gvppmp.SelectedDataKey("TotalAmt")
            Session("ppmp_monthly_dtl_ID") = gvppmp.SelectedDataKey("ppmp_monthly_dtl_ID")

            If str_OOE = "Select" Then
                ddyear.Enabled = False
                ddRC.Enabled = False

                ddPPA.Enabled = False
                chkOOE.Enabled = False
                chkOOE.Checked = True
                cbWOGoods.Checked = IIf((gvppmp.SelectedDataKey("isGoods") = True), False, True)
                cbWOGoods.Enabled = False
                cbInfra.Checked = gvppmp.SelectedDataKey("isInfra")
                cbInfra.Enabled = False
                ddAllotmentType.SelectedValue = gvppmp.SelectedDataKey("AllotmentClass_ID")

                dtAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_PPMP_GenAccountList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & ",'" & gvppmp.SelectedDataKey("AllotmentClass_ID") & "'", CommandType.Text)
                ddGenAccount.DataSource = dtAccounts
                ddGenAccount.DataTextField = ("GA_Title2")
                ddGenAccount.DataValueField = ("GA_Code2")
                ddGenAccount.DataBind()
                ddGenAccount.Items.Insert(0, "Select")

                ddGenAccount.SelectedValue = gvppmp.SelectedDataKey("GA_Code2")

                txtbudget.Text = FormatNumber(dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("ApprovedFinal"), 2)
                txtReservedPercentage.Text = FormatNumber(gvppmp.SelectedDataKey("ReservedPercentage"), 2)

                grdItems.Columns(4).Visible = True
                grdItems.Columns(5).Visible = True

                dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_ToCreate_PPMP_ItemList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("GA_ID") & "," & Session("BGA_ID") & "," & Session("app_id") & "", CommandType.Text)
                grdItems.DataSource = dtItems
                grdItems.DataBind()

                grdItems.Columns(4).Visible = False
                grdItems.Columns(5).Visible = False

                LoadSavedPPMP()

            ElseIf str_OOE = "Delete" Then

                'Dim PAOO_Id As Integer = objDerived.GetValue("SELECT A.LBPF_3_Hdr_ID FROM GeoBOS.BOS.LBPF_3_Hdr AS A INNER JOIN GeoBOS.BOS.LBPF_3_Dtl AS B ON A.LBPF_3_Hdr_ID = B.LBPF_3_Hdr_ID " &
                '                                         "  WHERE A.isPosted = 1 AND A.Budget_Year = " & Session("CYear") & " AND A.RC_ID = " & Session("RC_ID") & " AND A.Function_ID = " & Session("Function_ID") & "      " &
                '                                         "  AND A.Program_ID = " & Session("Program_ID") & " AND A.Project_ID = " & Session("Project_ID") & "                          " &
                '                                         "  AND B.GA_ID = " & Session("GA_ID") & " AND B.BGA_ID = " & Session("BGA_ID") & "", CommandType.Text)

                'Dim PAOO_Id As Integer = objDerived.GetValue("select * from ams.PR_Hdr where PR_Hdr = '" & Session("Project_ID") & "'", CommandType.Text)



                'If PAOO_Id = 0 Then
                Dim hdr_id As Integer = objDerived.GetValue("SELECT ppmp_monthly_hdr_ID FROM AMS.PPMP_Monthly_Hdr WHERE CYear = " & Session("CYear") & " And RC_ID = " & Session("RC_ID") & " And Function_ID = " & Session("Function_ID") & " And Program_ID = " & Session("Program_ID") & " And Project_ID = " & Session("Project_ID") & " And GA_ID = " & Session("GA_ID") & " And BGA_ID = " & Session("BGA_ID") & " And isGoods = '" & gvppmp.SelectedDataKey("isGoods") & "'", CommandType.Text)

                If gvppmp.SelectedDataKey("isGoods") = False Then

                    objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_dtl_ID = '" & gvppmp.SelectedDataKey("ppmp_monthly_dtl_ID") & "'", CommandType.Text)

                    Dim dtl_id As Integer = objDerived.GetValue("SELECT TOP(1) ppmp_monthly_dtl_ID FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)
                    If dtl_id = 0 Then
                        objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)

                    End If
                Else
                    Dim hdrQtr_id As Integer = objDerived.GetValue("SELECT ppmp_hdr_id FROM AMS.ppmp_hdr WHERE CYear = " & Session("CYear") & " AND RC_ID = " & Session("RC_ID") & " AND Function_ID = " & Session("Function_ID") & " AND Program_ID = " & Session("Program_ID") & " AND Project_ID = " & Session("Project_ID") & " AND GA_ID = " & Session("GA_ID") & " AND BGA_ID = " & Session("BGA_ID") & "", CommandType.Text)

                    objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)
                    objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)

                    objDerived.Execute("DELETE FROM AMS.ppmp_dtl WHERE ppmp_hdr_id = '" & hdrQtr_id & "'", CommandType.Text)
                    objDerived.Execute("DELETE FROM AMS.ppmp_hdr WHERE ppmp_hdr_id = '" & hdrQtr_id & "'", CommandType.Text)

                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected PPMP has been successfully deleted.")
                LoadPPMPList_PerTab()

                'Else
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unable to remove the PPMP due to PAOO has already been submitted to Budget Office. Note: Request to Budget Office to Return the PAOO before removing the PPMP.")
                'End If


            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Request time out. Refresh the page.")
            End If




        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try


    End Sub
    Protected Sub lnkPPASelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        str_PPA = "Select"
    End Sub
    Protected Sub lnkPPADelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        str_PPA = "Delete"
    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)

    End Sub




    Private Sub gvPPA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvPPA.SelectedIndexChanged
        Try

            Session("Update") = True
            AddTrace("Session('Update') = True")

            Session("Program_ID") = gvPPA.SelectedDataKey("Program_ID")
            AddTrace("Session('Program_ID') = " & gvPPA.SelectedDataKey("Program_ID").ToString())

            Session("Project_ID") = gvPPA.SelectedDataKey("Project_ID")
            AddTrace("Session('Project_ID') = " & gvPPA.SelectedDataKey("Project_ID").ToString())

            Session("GA_ID") = gvPPA.SelectedDataKey("GA_ID")
            AddTrace("Session('GA_ID') = " & gvPPA.SelectedDataKey("GA_ID").ToString())

            Session("BGA_ID") = gvPPA.SelectedDataKey("BGA_ID")
            AddTrace("Session('BGA_ID') = " & gvPPA.SelectedDataKey("BGA_ID").ToString())

            Session("AllotmentType") = gvPPA.SelectedDataKey("AllotmentClass_ID")
            AddTrace("Session('AllotmentType') = " & gvPPA.SelectedDataKey("AllotmentClass_ID").ToString())

            Session("PPMP_Amt") = gvPPA.SelectedDataKey("TotalAmt")
            AddTrace("Session('PPMP_Amt') = " & gvPPA.SelectedDataKey("TotalAmt").ToString())

            Session("ppmp_monthly_dtl_ID") = gvPPA.SelectedDataKey("ppmp_monthly_dtl_ID")
            AddTrace("Session('ppmp_monthly_dtl_ID') = " & gvPPA.SelectedDataKey("ppmp_monthly_dtl_ID").ToString())



            If str_PPA = "Select" Then
                ddyear.Enabled = False
                ddRC.Enabled = False

                ddPPA.Enabled = False
                chkOOE.Enabled = False
                chkOOE.Checked = False
                cbWOGoods.Checked = IIf((gvPPA.SelectedDataKey("isGoods") = True), False, True)
                cbWOGoods.Enabled = False
                cbInfra.Checked = gvPPA.SelectedDataKey("isInfra")
                cbInfra.Enabled = False
                ddAllotmentType.SelectedValue = gvPPA.SelectedDataKey("AllotmentClass_ID")

                dtAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_PPMP_GenAccountList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & ",'" & gvPPA.SelectedDataKey("AllotmentClass_ID") & "'", CommandType.Text)
                'dtAccounts = objDerived.GetDataTable("SELECT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & gvPPA.SelectedDataKey("AllotmentClass_ID") & "' ORDER BY GA_Title ", CommandType.Text)
                ddGenAccount.DataSource = dtAccounts
                ddGenAccount.DataTextField = ("GA_Title2")
                ddGenAccount.DataValueField = ("GA_Code2")
                ddGenAccount.DataBind()
                ddGenAccount.Items.Insert(0, "Select")


                ddGenAccount.SelectedValue = gvPPA.SelectedDataKey("GA_Code2")
                ddPPA.SelectedItem.Text = gvPPA.SelectedDataKey("PPA")

                If Session("APP_Status") = 1 Then
                    lnkView.Enabled = True
                Else
                    lnkView.Enabled = False
                End If

                txtbudget.Text = FormatNumber(dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("ApprovedFinal"), 2)
                txtReservedPercentage.Text = FormatNumber(gvPPA.SelectedDataKey("ReservedPercentage"), 2)

                grdItems.Columns(4).Visible = True
                grdItems.Columns(5).Visible = True

                dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_ToCreate_PPMP_ItemList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("GA_ID") & "," & Session("BGA_ID") & "," & Session("app_id") & "", CommandType.Text)
                grdItems.DataSource = dtItems
                grdItems.DataBind()

                grdItems.Columns(4).Visible = False
                grdItems.Columns(5).Visible = False

                LoadSavedPPMP()

            ElseIf str_PPA = "Delete" Then

                'Dim PAOO_Id As Integer = objDerived.GetValue("SELECT A.LBPF_3_Hdr_ID FROM GeoBOS.BOS.LBPF_3_Hdr AS A INNER JOIN GeoBOS.BOS.LBPF_3_Dtl AS B ON A.LBPF_3_Hdr_ID = B.LBPF_3_Hdr_ID " &
                '                                          "  WHERE A.isPosted = 1 AND A.Budget_Year = " & Session("CYear") & " AND A.RC_ID = " & Session("RC_ID") & " AND A.Function_ID = " & Session("Function_ID") & "      " &
                '                                          "  AND A.Program_ID = " & Session("Program_ID") & " AND A.Project_ID = " & Session("Project_ID") & "                          " &
                '                                          "  AND B.GA_ID = " & Session("GA_ID") & " AND B.BGA_ID = " & Session("BGA_ID") & "", CommandType.Text)


                'If PAOO_Id = 0 Then
                Dim hdr_id As Integer = objDerived.GetValue("SELECT ppmp_monthly_hdr_ID FROM AMS.PPMP_Monthly_Hdr WHERE CYear = " & Session("CYear") & " AND RC_ID = " & Session("RC_ID") & " AND Function_ID = " & Session("Function_ID") & " AND Program_ID = " & Session("Program_ID") & " AND Project_ID = " & Session("Project_ID") & " AND GA_ID = " & Session("GA_ID") & " AND BGA_ID = " & Session("BGA_ID") & " AND isGoods = '" & gvPPA.SelectedDataKey("isGoods") & "'", CommandType.Text)

                If gvPPA.SelectedDataKey("isGoods") = False Then

                    objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_dtl_ID = '" & gvPPA.SelectedDataKey("ppmp_monthly_dtl_ID") & "'", CommandType.Text)

                    Dim dtl_id As Integer = objDerived.GetValue("SELECT TOP(1) ppmp_monthly_dtl_ID FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)
                    If dtl_id = 0 Then
                        objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)

                    End If
                Else
                    Dim hdrQtr_id As Integer = objDerived.GetValue("SELECT ppmp_hdr_id FROM AMS.ppmp_hdr WHERE CYear = " & Session("CYear") & " AND RC_ID = " & Session("RC_ID") & " AND Function_ID = " & Session("Function_ID") & " AND Program_ID = " & Session("Program_ID") & " AND Project_ID = " & Session("Project_ID") & " AND GA_ID = " & Session("GA_ID") & " AND BGA_ID = " & Session("BGA_ID") & "", CommandType.Text)

                    objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Dtl WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)
                    objDerived.Execute("DELETE FROM AMS.PPMP_Monthly_Hdr WHERE ppmp_monthly_hdr_ID = '" & hdr_id & "'", CommandType.Text)

                    objDerived.Execute("DELETE FROM AMS.ppmp_dtl WHERE ppmp_hdr_id = '" & hdrQtr_id & "'", CommandType.Text)
                    objDerived.Execute("DELETE FROM AMS.ppmp_hdr WHERE ppmp_hdr_id = '" & hdrQtr_id & "'", CommandType.Text)

                End If

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected PPMP has been successfully deleted.")
                LoadPPMPList_PerTab()

                'Else
                '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Unable to remove the PPMP due to PAOO has already been submitted to Budget Office. Note: Request to Budget Office to Return the PAOO before removing the PPMP.")
                'End If


            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Request time out. Refresh the page.")
            End If




        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Dim RsrvPrctge As Integer = objDerived.GetValue("SELECT TOP(1) Reserved_ID FROM AMS.ReservedPercentage WHERE CYear = '" & Session("CYear") & "' AND GA_ID = '" & Session("GA_ID") & "'", CommandType.Text)
        'If RsrvPrctge = 0 Then

        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Cannot proceed, reserved percentage not yet set in file maintenance.")
        'End If
    End Sub



    Protected Sub ddGenAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddGenAccount.SelectedIndexChanged
        'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "x")
        Session("GA_ID") = dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("GA_ID")
        Session("BGA_ID") = dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("BGA_ID")

        'If Session("APP_Status") = 1 Then
        '    lnkView.Enabled = True
        'Else
        '    lnkView.Enabled = False
        'End If

        txtbudget.Text = FormatNumber(dtAccounts.Rows(ddGenAccount.SelectedIndex - 1)("ApprovedFinal"), 2)

        Dim RP As Decimal = objDerived.GetValue("SELECT ReservedPercentage FROM AMS.ReservedPercentage WHERE CYear = '" & Session("CYear") & "' AND GA_ID = '" & Session("GA_ID") & "'", CommandType.Text)
        txtReservedPercentage.Text = Format(RP, "0.##")

        If cbWOGoods.Checked = False Then
            txtTotalQty.Enabled = True
        Else
            txtTotalAmt.Enabled = True
        End If


        grdItems.Columns(4).Visible = True
        grdItems.Columns(5).Visible = True

        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_ToCreate_PPMP_ItemList] " & Session("CYear") & "," & Session("RC_ID") & "," & Session("Function_ID") & "," & Session("Program_ID") & "," & Session("Project_ID") & "," & Session("GA_ID") & "," & Session("BGA_ID") & "," & Session("app_id") & "", CommandType.Text)
        grdItems.DataSource = dtItems
        grdItems.DataBind()

        grdItems.Columns(4).Visible = False
        grdItems.Columns(5).Visible = False


        LoadSavedPPMP()

    End Sub

End Class


