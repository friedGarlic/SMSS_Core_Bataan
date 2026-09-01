Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class planning_t_initial_ppmp
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim hdr As New t_ppmp_hdr
    Dim dtl As New t_ppmp_dtl

#Region "Property"
    Private Property pIntial_PPMP_detail() As DataTable
        Get
            Return CType(Session("pIntial_PPMP_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pIntial_PPMP_detail") = value
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

    Private Property pYear() As DataTable
        Get
            Return CType(Session("pYear"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pYear") = value
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
    Private Property withApprovedBudget() As Boolean
        Get
            Return CType(Session("withApprovedBudget"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("withApprovedBudget") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            pYear = objDerived.GetDataTable("Select * from ams.vw_app_status", CommandType.Text)
            ddYear.DataSource = pYear
            ddYear.DataTextField = ("year_title")
            ddYear.DataValueField = ("app_id")
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            ddDepartment.Items.Insert(0, "Select")
            ddFunction.Items.Insert(0, "Select")
            ddPPA.Items.Insert(0, "Select")
            ddAccount.Items.Insert(0, "Select")

            grdItems.DataSource = Nothing
            grdItems.DataBind()

            grdItemList.DataSource = Nothing
            grdItemList.DataBind()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name, RC_id FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
        ddDepartment.DataTextField = ("RC_Name")
        ddDepartment.DataValueField = ("RC_id")
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

        ddFunction.ClearSelection()
        ddPPA.ClearSelection()
        ddAccount.ClearSelection()

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RC_ID") = ddDepartment.SelectedItem.Value

        ddFunction.DataSource = objDerived.GetDataTable("SELECT DISTINCT Function_Desc, Function_ID FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & Session("RC_ID") & "' ORDER BY Function_Desc", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

        ddPPA.ClearSelection()
        ddAccount.ClearSelection()

    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Function_ID") = ddFunction.SelectedItem.Value

        dtPPA = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project '" & Session("RC_ID") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "'," & Session("Function_ID") & "," & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
        ddPPA.DataSource = dtPPA
        ddPPA.DataTextField = ("description")
        ddPPA.DataValueField = ("Program_ID")
        ddPPA.DataBind()
        ddPPA.Items.Insert(0, "Select")

        ddAccount.ClearSelection()
        ddAllotment.Enabled = True

    End Sub

    Protected Sub ddPPA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Project_ID") = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
        Session("Program_id") = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_id")

        ddAllotment.SelectedIndex = 0
        ddAccount.ClearSelection()

        Dim dt As New DataTable
        ddAccount.DataSource = dt
        ddAccount.DataBind()
        ddAccount.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "')", CommandType.Text)

        If Me.chkOOE.Checked = True Then
            '===== OFFICE OPERATIONAL EXPENSES
            pAccounts = objDerived.GetDataTable("EXEC AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "','" & withApprovedBudget & "',0,0,'" & ddAllotment.SelectedValue.ToString & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
            hdfppaprojId.Value = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
            hdfppaprogId.Value = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_id")

            ddAccount.DataSource = pAccounts
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_CODE2")
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")

        Else
            '===== PROGRAMS, PROJECTS AND ACTIVITIES
            If ddAllotment.SelectedItem.Value = 2 Then '=== MOOE
                Dim MMOE As Decimal
                MMOE = objDerived.GetValue("SELECT MOOE FROM dbo.view_PPA_Budget WHERE Program_id = '" & Session("Program_id") & "' AND Project_id = '" & Session("Project_ID") & "' AND RC_ID = '" & Session("RC_ID") & "' AND Function_ID = '" & Session("Function_ID") & "' ", CommandType.Text)

                If MMOE = 0 Then
                    Dim dt As New DataTable
                    ddAccount.DataSource = dt
                    ddAccount.DataBind()
                    ddAccount.Items.Insert(0, "Select")
                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA or mark OOE checkbox to proceed with PPMP.")
                Else
                    pAccounts = objDerived.GetDataTable("EXEC AMS.sp_GA_ID_from_LBPF_3_Per_Allotment '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "','" & withApprovedBudget & "','" & Session("Project_ID") & "','" & Session("Program_id") & "','" & ddAllotment.SelectedValue.ToString & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                    ddAccount.DataSource = pAccounts
                    ddAccount.DataTextField = ("GA_Title")
                    ddAccount.DataValueField = ("GA_CODE2")
                    ddAccount.DataBind()
                    ddAccount.Items.Insert(0, "Select")
                    hdfppaprojId.Value = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
                    hdfppaprogId.Value = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_id")
                End If

            ElseIf ddAllotment.SelectedItem.Value = 3 Then '=== Capital Outlay
                Dim CO As Decimal
                CO = objDerived.GetValue("SELECT CO FROM dbo.view_PPA_Budget WHERE Program_id = '" & Session("Program_id") & "' AND Project_ID = '" & Session("Project_ID") & "' and RC_ID = '" & Session("RC_ID") & "' and Function_ID = '" & Session("Function_ID") & "' ", CommandType.Text)

                If CO = 0 Then
                    Dim dt As New DataTable
                    ddAccount.DataSource = dt
                    ddAccount.DataBind()
                    ddAccount.Items.Insert(0, "Select")
                    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please submit first your PPA or mark OOE checkbox to proceed with PPMP.")
                Else

                    pAccounts = objDerived.GetDataTable("EXEC AMS.sp_GA_ID_from_LBPF_3_Per_Allotment '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "','" & withApprovedBudget & "','" & Session("Project_ID") & "','" & Session("Program_id") & "','" & ddAllotment.SelectedValue.ToString & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                    hdfppaprojId.Value = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Project_ID")
                    hdfppaprogId.Value = dtPPA.Rows(ddPPA.SelectedIndex - 1)("Program_id")

                    ddAccount.DataSource = pAccounts
                    ddAccount.DataTextField = ("GA_Title")
                    ddAccount.DataValueField = ("GA_CODE2")
                    ddAccount.DataBind()
                    ddAccount.Items.Insert(0, "Select")
                End If
            End If

           
        End If
    End Sub

    Protected Sub ddAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("year") = pYear.Rows(ddYear.SelectedIndex - 1)("year")
        Dim CYear As String = "CY" & pYear.Rows(ddYear.SelectedIndex - 1)("year")

        Dim ApprovedBudget As Decimal
        ApprovedBudget = objDerived.GetValue("EXEC [AMS].[sp_Total_ApprovedBudget] '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & Session("RC_ID") & "','" & Session("Function_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "','" & Session("Project_ID") & "','" & Session("Program_id") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "'", CommandType.Text)

        ''dtItems = objDerived.GetDataTable("EXEC ams.sp_goods_per_account_withPrice '" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "','" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "','" & CYear & "'", CommandType.Text)

        Dim GA As Integer = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
        Dim BGA As Integer = pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID")

        dtItems = objDerived.GetDataTable("exec ams.sp_goods_per_account_less_existing_data  '" & Me.ddDepartment.SelectedItem.Value.ToString & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedItem.Value & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & hdfppaprojId.Value & "," & hdfppaprogId.Value & "," & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "," & CYear & "", CommandType.Text)
        pIntial_PPMP_detail = dtItems
        txtHiddenReceiveQty.Value = dtItems.Rows.Count
        grdItemList.DataSource = dtItems
        grdItemList.DataBind()

        If ApprovedBudget = 0 Then
            Session("withBudget") = 0
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Selected account has zero budget.")
        Else
            Session("withBudget") = 1
        End If


    End Sub

    Protected Sub grdItemList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        grdItemList.DataSource = dtItems
        grdItemList.PageIndex = e.NewPageIndex
        grdItemList.DataBind()

 
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtItems.DefaultView
        myview.RowFilter = "Item_desc like '%" & replaceapostrophe(txtSearch.Text.ToString) & "%'"
        grdItemList.DataSource = myview
        grdItemList.DataBind()

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function



    Protected Sub chkOOE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Me.chkOOE.Checked = True Then
            Session("Project_ID") = 0
            Session("Program_id") = 0

            '=== CLEAR P/P/A
            dtPPA.Clear()
            ddPPA.DataSource = dtPPA
            ddPPA.DataBind()
            ddPPA.Items.Insert(0, "Select")

            If ddAllotment.SelectedItem.Text = "Select" Then
                ddPPA.SelectedIndex = 0
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select allotment type.")
            Else
                pAccounts = objDerived.GetDataTable("EXEC AMS.sp_GA_ID_from_LBPF_3_Per_Allotment  '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & True & "',0,0,'" & ddAllotment.SelectedValue.ToString & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
                ddAccount.DataSource = pAccounts
                ddAccount.DataTextField = ("GA_Title")
                ddAccount.DataValueField = ("GA_CODE2")
                ddAccount.DataBind()
                ddAccount.Items.Insert(0, "Select")

            End If

        Else
            '=== RELOAD P/P/A
            dtPPA = objDerived.GetDataTable("exec ams.sp_Programs_Activities_Project '" & Session("RC_ID") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "'," & Session("Function_ID") & "," & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "", CommandType.Text)
            ddPPA.DataSource = dtPPA
            ddPPA.DataTextField = ("description")
            ddPPA.DataValueField = ("description")
            ddPPA.DataBind()
            ddPPA.Items.Insert(0, "Select")

            pAccounts.Clear()
            ddAccount.DataSource = pAccounts
            ddAccount.DataBind()
            ddAccount.Items.Insert(0, "Select")

            ddAllotment.SelectedIndex = 0

        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As CheckBox
        'Try
        Session("year") = pYear.Rows(ddYear.SelectedIndex - 1)("year")
        Dim CYear As String = "CY" & pYear.Rows(ddYear.SelectedIndex - 1)("year")

        '=== CHECK IF EXISTING
        Dim dtCheck As New DataTable
        'dtCheck = objDerived.GetDataTable("SELECT * FROM [dbo].[View_InitialPPMP_Items] WHERE CYear = '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "' AND RC_ID = '" & Session("RC_ID") & "' AND  Function_ID = '" & Session("Function_ID") & "' AND GA_ID = '" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "' AND BGA_ID = '" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "' AND Project_ID = '" & Session("Project_ID") & "' AND Program_id = '" & Session("Program_id") & "'", CommandType.Text)
        'dtCheck = objDerived.GetDataTable("exec ams.sp_ppmpsaved " & Me.ddDepartment.SelectedValue & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("year") & "'," & ddFunction.SelectedValue & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "," & ddPPA.SelectedItem.Value & "," & ddPPA.SelectedItem.Value & "," & pYear.Rows(ddyear.SelectedIndex - 1)("isContinuing") & ",'" & pYear.Rows(ddyear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
        'Dim ItmID As Integer = objDerived.GetValue("Select count(*) from dbo.vw_ppmpSaved where Item_id ='" & grdItemList.SelectedDatakey("Item_ID") & "'", CommandType.text)

        'If dtCheck.Rows.Count = 0 Then

        '=== AMS.PPMP_HDR
        With hdr
            .CYear = pYear.Rows(ddYear.SelectedIndex - 1)("year")
            .pDate = Date.Today.ToString("MM/dd/yyyy")
            .PreparedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & Session("RC_ID") & "' AND division_key = '" & Session("Function_ID") & "' AND (isDeptHead = 'Yes')", CommandType.Text)
            .ReviewedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & Session("RC_ID") & "' AND division_key = '" & Session("Function_ID") & "' AND (isDeptHead = 'Yes')", CommandType.Text) 'Department Head's EmpID
            .ApprovedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE (deptid = 1) AND (division_key = 86) AND (isDeptHead = 'Yes')", CommandType.Text)
            .RecommendedBy = objDerived.GetValue("SELECT empid FROM HRMS.view_signatory WHERE deptid = '" & Session("RC_ID") & "' AND division_key = '" & Session("Function_ID") & "' AND (isDeptHead = 'Yes')", CommandType.Text)
            .RC_ID = Session("RC_ID")
            .Function_ID = Session("Function_ID")
            .GA_ID = pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID")
            .BGA_ID = pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID")
            .Project_ID = Session("Project_ID")
            .Program_id = Session("Program_id")
            .isContinuing = pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing")
            .isSupplemental = pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental")
            .mode_of_procurement = 2
            .app_id = pYear.Rows(ddYear.SelectedIndex - 1)("app_id")
            .isforRevision = True
            .Userid = Me.Session("@UserName").ToString
        End With

        Dim hdrid As Long = hdr.save
        Session("hdrid") = hdrid


        For i As Integer = 0 To txtHiddenReceiveQty.Value - 1

            cb = CType(Me.grdItemList.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If cb.Checked = True Then
                Dim Itm As Integer = objDerived.GetValue("Select count(*) from dbo.vw_ppmpSaved where RC_ID ='" & Me.ddDepartment.SelectedValue & "'AND CYEAR='" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "'AND Function_ID ='" & ddFunction.SelectedValue & "'AND GA_ID ='" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "'AND BGA_ID ='" & pAccounts.Rows(ddAccount.SelectedIndex - 1)("BGA_ID") & "'AND Project_ID='" & ddPPA.SelectedItem.Value & "'AND Program_ID='" & ddPPA.SelectedItem.Value & "'AND iSContinuing='" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "'AND Item_Desc='" & pIntial_PPMP_detail.Rows(i)("Item_Desc") & "'", CommandType.Text)
                If Itm = 0 Then
                    '==== AMS.PPMP_DTL
                    With dtl
                        .ppmp_hdr_id = hdrid
                        .Item_ID = pIntial_PPMP_detail.Rows(i)("Item_ID")
                        .UnitPrice = pIntial_PPMP_detail.Rows(i)("Price")
                        .Jan = 1
                        .Feb = 0
                        .Mar = 0
                        .Apr = 0
                        .May = 0
                        .Jun = 0
                        .Jul = 0
                        .Aug = 0
                        .Sep = 0
                        .Oct = 0
                        .Nov = 0
                        .Dec = 0
                        .Userid = Me.Session("@UserName").ToString
                        .save()
                    End With

                    'grdItems.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_InitialPPMP_Items] WHERE ppmp_hdr_id = '" & hdrid & "'", CommandType.Text)
                    grdItems.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_Initial_PPMP] '" & hdrid & "'", CommandType.Text)
                    grdItems.DataBind()


                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "PPMP for this account already exist.")
                End If

            End If
        Next



        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Initial PPMP has been successfully saved.")
        btnSave.Enabled = False




        'Catch ex As Exception
        'End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/planning/t_initial_ppmp.aspx")
    End Sub

    Protected Sub grdItemList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("withBudget") = 1 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If

    End Sub

    Protected Sub grdItemList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdItemList, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
            Dim s As CheckBox = CType(Me.grdItemList.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            If s.Enabled = True Then
                btnSave.Enabled = True
            End If
        Next

    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'HERE
        Dim item As String

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdItemList.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdItemList.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    '' btnActSave.Enabled = True
                    ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = True
                    'pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = True
                    btnSave.Enabled = True

                End If
            Next
        Else
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdItemList.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdItemList.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = False
                ' pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = False
                btnSave.Enabled = False
            Next
        End If


    End Sub
End Class
