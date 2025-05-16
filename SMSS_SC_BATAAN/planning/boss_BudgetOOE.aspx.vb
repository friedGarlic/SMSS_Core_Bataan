Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_boss_BudgetOOE
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Dim LBPF_3_Hdr As New BOSS.LBPF_3_Hdr
    Dim LBPF_3_Dtl As New BOSS.LBPF_3_Dtl

    Dim LBEF_2_Hdr As New BOSS.LBEF_2_Hdr
    Dim LBEF_2_Dtl As New BOSS.LBEF_2_Dtl

    Private Property dtAccounts() As DataTable
        Get
            Return CType(Session("dtAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAccounts") = value
        End Set
    End Property

    Private Property dtBudgetAccounts() As DataTable
        Get
            Return CType(Session("dtBudgetAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtBudgetAccounts") = value
        End Set
    End Property
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dt.Columns.Add("PR_Amt", GetType(Decimal))
        dt.Columns.Add("GA_ID", GetType(Int64))
        dt.Columns.Add("BGA_ID", GetType(Int64))
        dt.Columns.Add("GA_Code", GetType(String))
        dt.Columns.Add("Budget_Year", GetType(Int64))
        dt.Columns.Add("RC_ID", GetType(Int64))
        dt.Columns.Add("Function_ID", GetType(Int64))
        dt.Columns.Add("Program_ID", GetType(Int64))
        dt.Columns.Add("Project_ID", GetType(Int64))
        dt.Columns.Add("GA_CODE", GetType(Integer))
        dt.Columns.Add("GA_CODE2", GetType(String))
        dt.Columns.Add("FoundSource", GetType(String))
        dt.Columns.Add("GA_Title2", GetType(String))
        dt.Columns.Add("AllotmentClass_ID", GetType(Int64))
        dt.Columns.Add("GA_Title", GetType(String))
        dt.Columns.Add("F_ID", GetType(Int64))
        dt.Columns.Add("ApprovedFinal", GetType(Int64))
        dt.Columns.Add("Balance", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PR_Amt") = 0.0
            dr("GA_ID") = 0
            dr("BGA_ID") = 0
            dr("GA_Code") = ""
            dr("Budget_Year") = 0
            dr("RC_ID") = 0.00
            dr("Function_ID") = 0
            dr("Program_ID") = 0
            dr("Project_ID") = 0
            dr("GA_CODE") = 0
            dr("GA_CODE2") = ""
            dr("FoundSource") = ""
            dr("GA_Title2") = ""
            dr("AllotmentClass_ID") = 0
            dr("GA_Title") = ""
            dr("F_ID") = 0
            dr("ApprovedFinal") = 0
            dr("Balance") = 0
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("Budget_Year", GetType(String))
        dt.Columns.Add("RC_ID", GetType(String))
        dt.Columns.Add("Function_ID", GetType(String))
        dt.Columns.Add("GA_ID", GetType(String))
        dt.Columns.Add("Program_ID", GetType(String))
        dt.Columns.Add("Project_ID", GetType(String))
        dt.Columns.Add("ABC", GetType(String))
        dt.Columns.Add("Particulars", GetType(String))
        dt.Columns.Add("MOP", GetType(String))
        dt.Columns.Add("OBR_DateApproved", GetType(String))
        dt.Columns.Add("PO_Date", GetType(String))
        dt.Columns.Add("PO_DateApproved", GetType(String))
        dt.Columns.Add("Received_Date", GetType(String))
        dt.Columns.Add("AIR_Date", GetType(String))
        dt.Columns.Add("prhdr_id", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("pr_no") = ""
            dr("Budget_Year") = ""
            dr("RC_ID") = ""
            dr("Function_ID") = ""
            dr("GA_ID") = ""
            dr("Program_ID") = ""
            dr("Project_ID") = ""
            dr("ABC") = ""
            dr("Particulars") = ""
            dr("MOP") = ""
            dr("OBR_DateApproved") = ""
            dr("PO_Date") = ""
            dr("PO_DateApproved") = ""
            dr("Received_Date") = ""
            dr("AIR_Date") = ""
            dr("prhdr_id") = ""



            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM AMS.APP WHERE status IN (1,2) ORDER BY Year DESC", CommandType.Text)
            ddYear.DataSource = dt
            ddYear.DataTextField = ("Year")
            ddYear.DataValueField = ("app_id")
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            ddDepartment.Items.Insert(0, "Select")
            ddFunction.Items.Insert(0, "Select")
            ddAllotment.Items.Insert(0, "Select")
            ddAccounts.Items.Insert(0, "Select")

            grdAccounts.DataSource = createdatatable1(4)
            grdAccounts.DataBind()

            grdledger.DataSource = createdatatable2(4)
            grdledger.DataBind()

            Session("isUpdate") = 0


        End If
    End Sub


    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("CYear") = ddYear.SelectedItem.Text

        ddDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name,RC_ID FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        ddDepartment.DataTextField = ("RC_Name")
        ddDepartment.DataValueField = ("RC_ID")
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.DataSource = objDerived.GetDataTable("SELECT DISTINCT Function_Desc,Function_ID FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddAllotment.DataSource = objDerived.GetDataTable("SELECT AllotmentClass_ID,AllotmentClass FROM LnkdSrvrBOSS.GEOBOS.BOS.m_AllotmentClass WHERE AllotmentClass_ID IN (2,3)", CommandType.Text)
        ddAllotment.DataTextField = ("AllotmentClass")
        ddAllotment.DataValueField = ("AllotmentClass_ID")
        ddAllotment.DataBind()
        ddAllotment.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        drpFund.SelectedValue = "0"
    End Sub

    Private Sub drpFund_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpFund.SelectedIndexChanged
        '=== DISPLAY APPROVED BUDGET - ALL ACCOUNT UNDER SELECTED FUND
        dtBudgetAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_LedgerCardBudget] '" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "',0,0,'" & drpFund.SelectedItem.Value & "','" & ddAllotment.SelectedItem.Value & "'", CommandType.Text)
        'If dtBudgetAccounts.Rows.Count < 5 Then
        '    dtBudgetAccounts.Merge(createdatatable1(4 - dtBudgetAccounts.Rows.Count))

        'End If
        grdAccounts.DataSource = dtBudgetAccounts
        grdAccounts.DataBind()



        Session("AllotmentType") = ddAllotment.SelectedItem.Value

        '==== DISPLAY ACCOUNT TO ENCODE NEW BUDGET
        dtAccounts = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & ddAllotment.SelectedItem.Value & "' ORDER BY GA_Title", CommandType.Text)
        ddAccounts.DataSource = dtAccounts
        ddAccounts.DataTextField = ("GA_Title2")
        ddAccounts.DataValueField = ("GA_Code2")
        ddAccounts.DataBind()
        ddAccounts.Items.Insert(0, "Select")

        ddAccounts.Enabled = True

    End Sub

    Protected Sub grdAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Session("GA_ID") = grdAccounts.SelectedDataKey("GA_ID")
            Session("BGA_ID") = grdAccounts.SelectedDataKey("BGA_ID")
            txtApproved.Enabled = True

            '==== GET PROPOSED BUDGET (PPMP)
            Dim ProposedBudget As Decimal
            ProposedBudget = objDerived.GetValue("SELECT ProposedBudget FROM dbo.View_FM_ProposedBudget WHERE CYear = '" & grdAccounts.SelectedDataKey("Budget_Year") & "' AND RC_ID = '" & grdAccounts.SelectedDataKey("RC_ID") & "' AND Function_ID = '" & grdAccounts.SelectedDataKey("Function_ID") & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "' AND Project_ID = '" & grdAccounts.SelectedDataKey("Project_ID") & "' AND Program_id = '" & grdAccounts.SelectedDataKey("Program_id") & "'", CommandType.Text)
            txtProposed.Text = FormatNumber(ProposedBudget, 2)

            txtApproved.Text = FormatNumber(grdAccounts.SelectedDataKey("ApprovedFinal"), 2)

            If txtApproved.Text < txtProposed.Text Then
                lblReminders.Visible = True
            Else
                lblReminders.Visible = False
            End If

            ddAccounts.Items.Clear()
            dtAccounts = objDerived.GetDataTable("SELECT DISTINCT * FROM AMS.View_AccountList WHERE AllotmentClass_ID = '" & ddAllotment.SelectedItem.Value & "' ORDER BY GA_Title", CommandType.Text)
            ddAccounts.DataSource = dtAccounts
            ddAccounts.DataTextField = ("GA_Title2")
            ddAccounts.DataValueField = ("GA_Code2")
            ddAccounts.DataBind()
            ddAccounts.SelectedValue = objDerived.GetValue("SELECT GA_Code2 FROM AMS.View_AccountList WHERE GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)



            dtBudgetAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_LedgerCardPerPPA]'" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','0','0','" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & grdAccounts.SelectedDataKey("GA_CODE") & "'", CommandType.Text)
            If dtBudgetAccounts.Rows.Count < 5 Then
                dtBudgetAccounts.Merge(createdatatable2(4 - dtBudgetAccounts.Rows.Count))
            End If
            grdledger.DataSource = dtBudgetAccounts
            grdledger.DataBind()

            ddAccounts.Enabled = False

            dtBudgetAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_LedgerCardPerPPA]'" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','0','0','" & grdAccounts.SelectedDataKey("GA_ID") & "','" & grdAccounts.SelectedDataKey("BGA_ID") & "','" & grdAccounts.SelectedDataKey("GA_CODE") & "'", CommandType.Text)

            ' Clear any existing total
            ViewState("TotalAmount") = 0

            ' Bind the data
            grdledger.DataSource = dtBudgetAccounts
            grdledger.DataBind() ' Fixed typo from Databind to DataBind

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            'MsgBox(ex.Message)
        End Try


    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtApproved.Text = "" Or txtApproved.Text = "0.00" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up all fields.")
            Exit Sub
        End If

        'Try
        '==== PAOO HEADER LBPF_3_Hdr
        With LBPF_3_Hdr
            .RC_ID = ddDepartment.SelectedItem.Value
            .Function_ID = ddFunction.SelectedItem.Value
            .Program_ID = 0
            .Project_ID = 0
            .AppropriationSource_ID = 0
            .AdjustmentType_ID = 0
            .F_ID = drpFund.SelectedItem.Value
            .Budget_Year = ddYear.SelectedItem.Text
            .isApproved = True
            .isPosted = True
            .PreparedBy = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 'Yes'", CommandType.Text)
            .ReviewedBy = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 13 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            .ApprovedBy = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            .isFinal = True
            .DatePrepared = Date.Today.ToString("MM/dd/yyyy")
            .DateReviewed = Date.Today.ToString("MM/dd/yyyy")
            .DateApproved = Date.Today.ToString("MM/dd/yyyy")
            .UserID = Session("@UserName")
            .TableName = "BOS.LBPF_3_Hdr"
        End With

        Dim LBPF_3_Hdr_ID As Long
        Dim LBPF_ID As Long = objDerived.GetValue("SELECT LBPF_3_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Hdr WHERE Budget_Year = " & Session("CYear") & " AND RC_ID = " & Val(ddDepartment.SelectedItem.Value) & " AND Function_ID = " & Val(ddFunction.SelectedItem.Value) & " AND Program_ID = 0 AND Project_ID = 0 AND F_ID = " & Val(drpFund.SelectedItem.Value) & "", CommandType.Text)
        If LBPF_ID = 0 Then
            LBPF_3_Hdr_ID = LBPF_3_Hdr.save
        Else
            LBPF_3_Hdr_ID = LBPF_ID
            LBPF_3_Hdr.LBPF_3_Hdr_ID = LBPF_ID
            LBPF_3_Hdr.update()
        End If


        '==== RELEASE HEADER LBEF_2_Hdr
        With LBEF_2_Hdr
            .ARO_No = Session("CYear") + " - " + "00"
            .Budget_Year = Session("CYear")
            .AppropriationSource_ID = Session("AppropriationSource_ID")
            .AllotmentType_ID = 5
            .Quarter = 0
            .F_ID = drpFund.SelectedItem.Value
            .RC_ID = ddDepartment.SelectedItem.Value
            .Function_ID = ddFunction.SelectedItem.Value
            .Program_ID = 0
            .Project_ID = 0
            .DateIssued = Date.Today.ToString("MM/dd/yyyy")
            .Purpose = ""
            .Notes = ""
            .Signatory1_ID = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 13 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            .DateSigned = Date.Today.ToString("MM/dd/yyyy")
            .Signatory2_ID = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            .Signatory3_ID = objDerived.GetValue("SELECT empid  FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            .Position3 = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE deptid = 1 AND division_key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            .isApproved = True
            .DateSigned = Date.Today.ToString("MM/dd/yyyy")
            .isContinuing = False
            .isAdjustment = False
            .UserID = Session("@UserName")
        End With

        Dim LBEF_2_Hdr_ID As Long
        Dim LBEF_ID As Long = objDerived.GetValue("SELECT LBEF_2_Hdr_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Hdr WHERE Budget_Year = '" & Session("CYear") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND Program_ID = 0 AND Project_ID = 0 AND F_ID = " & drpFund.SelectedItem.Value & "", CommandType.Text)
        If LBEF_ID = 0 Then
            LBEF_2_Hdr.TotalAmount = txtApproved.Text
            LBEF_2_Hdr_ID = LBEF_2_Hdr.save

        Else
            LBEF_2_Hdr_ID = LBEF_ID
            Dim xTotalAmount As Decimal
            If Session("BGA_ID") = 0 Then
                xTotalAmount = objDerived.GetValue("SELECT SUM(Amount) FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Dtl WHERE LBEF_2_Hdr_ID = '" & LBEF_ID & "' AND GA_ID <> '" & Session("GA_ID") & "' GROUP BY  LBEF_2_Hdr_ID", CommandType.Text)
            Else
                xTotalAmount = objDerived.GetValue("SELECT SUM(Amount) FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Dtl WHERE LBEF_2_Hdr_ID = '" & LBEF_ID & "' AND GA_ID <> '" & Session("GA_ID") & "' AND BGA_ID <> '" & Session("BGA_ID") & "' GROUP BY  LBEF_2_Hdr_ID", CommandType.Text)
            End If
            LBEF_2_Hdr.TotalAmount = txtApproved.Text + xTotalAmount
            LBEF_2_Hdr.LBEF_2_Hdr_ID = LBEF_ID
            LBEF_2_Hdr.update()
        End If


        '=== SAVE PAOO DETAILS BOS.LBPF_3_Dtl
        With LBPF_3_Dtl
            .LBPF_3_Hdr_ID = LBPF_3_Hdr_ID
            .GA_ID = Session("GA_ID")
            .BGA_ID = Session("BGA_ID")
            .PastYear_Amount = 0
            .CurrentYear_Amount = txtApproved.Text
            .ProposedAmount = txtProposed.Text
            .ApprovedAmount = txtApproved.Text
            .ApprovedFinal = txtApproved.Text
            .AllotmentClass_ID = Session("AllotmentType")
            .UserID = Session("@UserName")
            .TableName = "BOS.LBPF_3_Dtl"
        End With

        Dim LBPF_3_Dtl_ID As Long = objDerived.GetValue("SELECT LBPF_3_Dtl_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBPF_3_Dtl WHERE LBPF_3_Hdr_ID = " & Val(LBPF_3_Hdr_ID) & " AND GA_ID = " & Session("GA_ID") & " AND BGA_ID = " & Session("BGA_ID") & "", CommandType.Text)
        If LBPF_3_Dtl_ID = 0 Then
            LBPF_3_Dtl.save()
        Else
            LBPF_3_Dtl.LBPF_3_Dtl_ID = LBPF_3_Dtl_ID
            LBPF_3_Dtl.update()
        End If

        '=== SAVE RELEASE DETAILS BOS.LBEF_2_Dtl
        With LBEF_2_Dtl
            .LBEF_2_Hdr_ID = LBEF_2_Hdr_ID
            .GA_ID = Session("GA_ID")
            .BGA_ID = Session("BGA_ID")
            .AllotmentClass_ID = Session("AllotmentType")
            .Amount = txtApproved.Text
            .UserID = Session("@UserName")
        End With

        Dim LBEF_2_Dtl_ID As Long = objDerived.GetValue("SELECT LBEF_2_Dtl_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.LBEF_2_Dtl WHERE LBEF_2_Hdr_ID = '" & LBEF_2_Hdr_ID & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "'", CommandType.Text)
        If LBEF_2_Dtl_ID = 0 Then
            LBEF_2_Dtl.save()
        Else
            LBEF_2_Dtl.LBEF_2_Dtl_ID = LBEF_2_Dtl_ID
            LBEF_2_Dtl.update()
        End If

        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


        '=== DISPLAY ALL ACCOUNT UNDER SELECTED FUND
        dtBudgetAccounts = objDerived.GetDataTable("EXEC [AMS].[sp_LedgerCardBudget] '" & ddYear.SelectedItem.Text & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "',0,0,'" & drpFund.SelectedItem.Value & "','" & ddAllotment.SelectedItem.Value & "'", CommandType.Text)
        grdAccounts.DataSource = dtBudgetAccounts
        grdAccounts.DataBind()


        txtProposed.Text = ""
        txtApproved.Text = ""

        ddAccounts.Enabled = True

        'Catch ex As Exception
        '    '' MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        '    MsgBox(ex)
        'End Try
    End Sub
    Private Sub grdAccounts_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAccounts.PageIndexChanging
        grdAccounts.DataSource = dtBudgetAccounts
        grdAccounts.PageIndex = e.NewPageIndex
        grdAccounts.DataBind()
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/filemaintenance/boss_BudgetOOE.aspx")
    End Sub

    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("GA_ID") = dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("GA_ID")
        Session("BGA_ID") = dtAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID")

        txtApproved.Enabled = True

        '==== GET PROPOSED BUDGET (PPMP)
        Dim ProposedBudget As Decimal
        ProposedBudget = objDerived.GetValue("SELECT ProposedBudget FROM dbo.View_FM_ProposedBudget WHERE CYear = '" & ddYear.SelectedItem.Text & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "' AND Project_ID = 0 AND Program_id = 0 AND Fund_ID = " & drpFund.SelectedItem.Value & "", CommandType.Text)
        txtProposed.Text = FormatNumber(ProposedBudget, 2)


        '==== GET APPROVED BUDGET
        Dim ApprovedBudget As Decimal
        ApprovedBudget = objDerived.GetValue("SELECT ApprovedFinal FROM [dbo].[View_FM_BudgetPAOO] WHERE Budget_Year = '" & ddYear.SelectedItem.Text & "' AND F_ID = " & drpFund.SelectedItem.Value & " AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "' AND Program_ID = 0 AND Project_ID = 0 ORDER BY GA_Title", CommandType.Text)
        txtApproved.Text = FormatNumber(ApprovedBudget, 2)


    End Sub


    Protected Sub txtApproved_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        txtApproved.Text = FormatNumber(txtApproved.Text, 2)

        If txtApproved.Text < txtProposed.Text Then
            lblReminders.Visible = True
        Else
            lblReminders.Visible = False
        End If
    End Sub
    Protected Sub grdledger_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdledger.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            ' Initialize default total value
            Dim total As Decimal = 0

            ' Check if DataTable exists and has data
            If dtBudgetAccounts IsNot Nothing Then
                If dtBudgetAccounts.Rows.Count > 0 AndAlso dtBudgetAccounts.Columns.Contains("TotalAmount") Then
                    ' Safely parse the total amount
                    Decimal.TryParse(dtBudgetAccounts.Rows(0)("TotalAmount").ToString(), total)
                End If
            End If

            ' Format and display the total
            e.Row.Cells(7).Text = "Total: " & String.Format("{0:N2}", total)
        End If
    End Sub
    Protected Sub grdledger_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("Page") = "OOE"
        Session("Report") = "PR"
        Session("prhdr_id") = grdledger.SelectedDataKey("prhdr_id")

        Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")
    End Sub


End Class