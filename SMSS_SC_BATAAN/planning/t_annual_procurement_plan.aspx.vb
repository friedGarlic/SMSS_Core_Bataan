Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls

Partial Class PLANNING_t_annual_procurement_plan
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim app As New t_annual_procurement_plan_hdr
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
#Region "property"
    Private Property withApprovedBudget() As Boolean
        Get
            Return CType(Session("withApprovedBudget"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Session("withApprovedBudget") = value
        End Set
    End Property

    Private Property pgvheader() As DataTable
        Get
            Return CType(Session("pgvheader"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pgvheader") = value
        End Set
    End Property


    Private Property pgvppmp() As DataTable
        Get
            Return CType(Session("pgvppmp"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pgvppmp") = value
        End Set
    End Property
    Private Property pgvPPA() As DataTable
        Get
            Return CType(Session("pgvPPA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pgvPPA") = value
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
#End Region
#Region "Functions"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("app_id", GetType(Long))
        dt.Columns.Add("title")
        dt.Columns.Add("year", GetType(Integer))
        dt.Columns.Add("isPosted", GetType(Boolean))
        dt.Columns.Add("isApproved", GetType(Boolean))
        dt.Columns.Add("isforRevision", GetType(Boolean))
        dt.Columns.Add("status", GetType(Integer))
        dt.Columns.Add("isContinuing", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("app_id") = 0
            dr("title") = ""
            dr("year") = "0"
            dr("isPosted") = False
            dr("isApproved") = False
            dr("isforRevision") = False
            dr("status") = 0
            dr("isContinuing") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Request.UserAgent.IndexOf("AppleWebKit") > 0) Then
        '    Request.Browser.Adapters.Clear()
        'End If

        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
            If pgvheader.Rows.Count < 5 Then
                pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
            End If
            gvheader.DataSource = pgvheader
            gvheader.DataBind()


            Dim CYear As New DataTable

            '' MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, Year(Date.Today))

            CYear = objDerived.GetDataTable("Select * from AMS.APP order by year desc", CommandType.Text)

            If CYear.Rows.Count = 0 Then
                btnSupplemental.Enabled = False
            Else
                btnSupplemental.Enabled = True
            End If

            Dim Supp As String = objDerived.GetValue("select [AMS].[func_GenerateSupplemental]('" & Year(Date.Today) & "')", CommandType.Text)
            btnSupplemental.Text = "Create " + Supp

            Dim status As String
            status = objDerived.GetValue("select year from AMS.APP where year = (" & CType(Year(Date.Today) + 1, Integer) & ")", CommandType.Text)
            If status = "" Then
                btncreate.Enabled = True
                btncreate.Text = "CREATE APP (" + CType(Year(Date.Today) + 1, String) + ")"

            Else
                btncreate.Enabled = False
                btncreate.Text = "CREATE APP NEW"
            End If

            LoadDropdown()
            drpYear.DataSource = CYear
            drpYear.DataTextField = "year"
            drpYear.DataValueField = "year"
            drpYear.DataBind()
            drpYear.Items.Insert(0, "Select")

            drpDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpDepartment.DataTextField = "RC_Name"
            drpDepartment.DataValueField = "RC_id"
            drpDepartment.DataBind()
            drpDepartment.Items.Insert(0, "Select")


        End If
    End Sub
    Private Sub drpDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDepartment.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & drpDepartment.SelectedItem.Value & "'", CommandType.Text)
        drpFunction.DataTextField = "Function_Desc"
        drpFunction.DataValueField = "Function_ID"
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")
    End Sub
    Private Sub drpFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpFunction.SelectedIndexChanged
        'Try
        btnPreview_APPDepartment.Enabled = True

        dtPPA = objDerived.GetDataTable("SELECT DISTINCT B.Project_Name, A.Program_ID, B.Project_ID FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Program AS A         " &
                                            " INNER JOIN LnkdSrvrBOSS.GEOBOS.BOS.m_project AS B ON A.Program_ID = B.Program_ID                              " &
                                            " WHERE B.isActivity = 1 AND A.Budget_Year = '" & drpYear.SelectedItem.Value & "' AND  A.RC_ID = '" & drpDepartment.SelectedItem.Value & "' AND A.Function_ID =  '" & drpFunction.SelectedItem.Value & "' ORDER BY B.Project_Name", CommandType.Text)
        drpPPA.DataSource = dtPPA
        drpPPA.DataTextField = "Project_Name"
        drpPPA.DataValueField = "Project_ID"
        drpPPA.DataBind()
        drpPPA.Items.Insert(0, "All")
        drpPPA.Items.Insert(1, "Office Operational Expense")


        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")

        'End Try
    End Sub
    Protected Sub LoadDropdown()
        '=== SIGNATORIES
        ddBAC1.ClearSelection()
        ddBAC2.ClearSelection()
        ddBAC3.ClearSelection()
        ddBAC4.ClearSelection() '=== ADD THIS LINE === 02/12/2025
        ddBAC5.ClearSelection() '=== ADD THIS LINE === 02/12/2025
        ddBACVC.ClearSelection()
        ddBACC.ClearSelection()
        ddPreparedBy.ClearSelection()
        ddApprovedBy.ClearSelection()

        ddBAC1.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND ([BAC_PostionID] = 3 or [BAC_PostionID] = 4 or [BAC_PostionID] = 5)", CommandType.Text)
        ddBAC1.DataTextField = ("Name")
        ddBAC1.DataValueField = ("empsig_id")
        ddBAC1.DataBind()
        ddBAC1.Items.Insert(0, "Select")

        ddBAC2.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND ([BAC_PostionID] = 3 or [BAC_PostionID] = 4 or [BAC_PostionID] = 5)", CommandType.Text)
        ddBAC2.DataTextField = ("Name")
        ddBAC2.DataValueField = ("empsig_id")
        ddBAC2.DataBind()
        ddBAC2.Items.Insert(0, "Select")

        ddBAC3.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND ([BAC_PostionID] = 3 or [BAC_PostionID] = 4 or [BAC_PostionID] = 5)", CommandType.Text)
        ddBAC3.DataTextField = ("Name")
        ddBAC3.DataValueField = ("empsig_id")
        ddBAC3.DataBind()
        ddBAC3.Items.Insert(0, "Select")

        '===== COPY THIS CODE ===== 02/12/2025
        ddBAC4.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [Position_desc] = 'BAC Member'", CommandType.Text)
        ddBAC4.DataTextField = ("Name")
        ddBAC4.DataValueField = ("empsig_id")
        ddBAC4.DataBind()
        ddBAC4.Items.Insert(0, "Select")

        '===== COPY THIS CODE ===== 02/12/2025
        ddBAC5.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [Position_desc] = 'BAC Member'", CommandType.Text)
        ddBAC5.DataTextField = ("Name")
        ddBAC5.DataValueField = ("empsig_id")
        ddBAC5.DataBind()
        ddBAC5.Items.Insert(0, "Select")

        ddBACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
        ddBACVC.DataTextField = ("Name")
        ddBACVC.DataValueField = ("empsig_id")
        ddBACVC.DataBind()

        ddBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
        ddBACC.DataTextField = ("Name")
        ddBACC.DataValueField = ("empsig_id")
        ddBACC.DataBind()

        ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 ORDER BY [BAC_PostionID], [Name]", CommandType.Text)
        ddPreparedBy.DataTextField = ("Name")
        ddPreparedBy.DataValueField = ("empsig_id")
        ddPreparedBy.DataBind()
        ddPreparedBy.Items.Insert(0, "Select")

        ddApprovedBy.DataSource = objDerived.GetDataTable("SELECT empid, UPPER(full_name) AS full_name FROM HRMS.view_signatory WHERE deptid IN (1,2,3,8,13,104) AND division_key = 86 AND isDeptHead = 'Yes' ORDER BY full_name", CommandType.Text)
        ddApprovedBy.DataTextField = ("full_name")
        ddApprovedBy.DataValueField = ("empid")
        ddApprovedBy.DataBind()
        ddApprovedBy.Items.Insert(0, "Select")
    End Sub

    Protected Sub gvheader_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvheader.SelectedIndexChanged
        'Try
        Session("year") = gvheader.SelectedDataKey(0)
        Session("isContinuing") = gvheader.SelectedDataKey(5)
        Session("isSupplemental") = gvheader.SelectedDataKey("isSupplemental")
        pgvPPA = objDerived.GetDataTable("exec [AMS].[APP_PPMP_List_PPA] " & gvheader.SelectedDataKey(0) & ",'" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
        pgvppmp = objDerived.GetDataTable("execute [AMS].[APP_PPMP_List] " & gvheader.SelectedDataKey(0) & ",'" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
        If pgvppmp.Rows.Count = 0 And pgvPPA.Rows.Count = 0 Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Empty Data.")
        Else
            'Dim NoPPMP = objDerived.GetValue("Select count(Office_ID) as PPMP from dbo.view_checkNoPPMP where PPMP_hdr_id is NULL", CommandType.text)
            'If NoPPMP > 0 Then
            '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please complete the PPMP for all department.")
            'Else
            btnPreview.Enabled = True
            '    Session("year") = gvheader.SelectedDataKey(0)
            '    Session("isContinuing") = gvheader.SelectedDataKey(5)
            '    Session("isSupplemental") = gvheader.SelectedDataKey("isSupplemental")

            pgvppmp = objDerived.GetDataTable("execute [AMS].[APP_PPMP_List]" & gvheader.SelectedDataKey(0) & ",'" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
                If pgvppmp.Rows.Count < 8 Then
                        pgvppmp.Merge(createdatatable2(7 - pgvppmp.Rows.Count))
                    End If
                    gvppmp.DataSource = pgvppmp
                    gvppmp.DataBind()

                    pgvPPA = objDerived.GetDataTable("exec [AMS].[APP_PPMP_List_PPA] " & gvheader.SelectedDataKey(0) & ",'" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
                    If pgvPPA.Rows.Count < 8 Then
                        pgvPPA.Merge(createdatatable3(7 - pgvPPA.Rows.Count))
                    End If
                    gvPPA.DataSource = pgvPPA
                    gvPPA.DataBind()

                    Dim isPosted As Boolean = objDerived.GetValue("Select isPosted from AMS.APP where year='" & gvheader.SelectedDataKey(0) & "' and app_id ='" & gvheader.SelectedDataKey("app_id") & "' ", CommandType.Text)
                    Dim isApproved As Boolean = objDerived.GetValue("Select isApproved from AMS.APP where year='" & gvheader.SelectedDataKey(0) & "' and app_id ='" & gvheader.SelectedDataKey("app_id") & "' ", CommandType.Text)
                    Dim isforRevision As Boolean = objDerived.GetValue("Select isforRevision from AMS.APP where year='" & gvheader.SelectedDataKey(0) & "' and app_id ='" & gvheader.SelectedDataKey("app_id") & "' ", CommandType.Text)
                    Dim Execute As Integer = objDerived.GetValue("Select Status from AMS.APP where year='" & gvheader.SelectedDataKey(0) & "' and app_id ='" & gvheader.SelectedDataKey("app_id") & "' ", CommandType.Text)

                    If isPosted = False Then
                        btnPosted.Enabled = True
                        btnApproved.Enabled = False

                    ElseIf isPosted = True Then
                        btnPosted.Enabled = False

                        If isApproved = False Then
                            btnApproved.Enabled = True
                        ElseIf isApproved = True Then
                            btnApproved.Enabled = False

                            If Execute = 2 Then
                                btnExe.Enabled = False
                                btnClose.Enabled = True
                            ElseIf Execute = 3 Then
                                btnExe.Enabled = False
                                btnClose.Enabled = False
                            Else
                                btnExe.Enabled = True
                            End If
                        End If
                    End If
                End If
        'End If

        If pgvppmp.Rows.Count >= 1 Then
            pgvppmp = objDerived.GetDataTable("exec AMS.APP_PPMP_List '" & gvheader.SelectedDataKey(0) & "','" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
            If pgvppmp.Rows.Count = 0 Then
                'btnPreview.Enabled = False
                'LoadSignatoryDisEnable()
                'New Code
                'LoadSignatoryEnable()
            Else
                'btnPreview.Enabled = True
                'LoadSignatoryEnable()

                'ddBAC1.Enabled = True
            End If
        Else
            btnPreview.Enabled = False
            LoadSignatoryDisEnable()
        End If
        'btnpreview.enabled = True

        'Catch ex As Exception
        '    msg.UserMsgBox(ex.ToString, Me, False)
        'End Try
    End Sub
    Protected Sub btnPosted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPosted.Click
        'Try
        If pgvppmp.Rows.Count = 0 And pgvPPA.Rows.Count = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Empty Data.")
            Else
                Dim NoPPMP = objDerived.GetValue("Select count(Office_ID) as PPMP from dbo.view_checkNoPPMP where PPMP_hdr_id is NULL", CommandType.text)
                If NoPPMP > 0 Or NoPPMP Is Nothing Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please complete the PPMP for all department.")
                Else

                    objDerived.GetRecords("Update AMS.APP set isPosted=1 where year='" & gvheader.SelectedDataKey(0) & "' and app_id ='" & gvheader.SelectedDataKey("app_id") & "'", CommandType.Text)
                    pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
                    If pgvheader.Rows.Count < 5 Then
                        pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
                    End If
                    gvheader.DataSource = pgvheader
                    gvheader.DataBind()

                    btnPosted.Enabled = False
                    btnApproved.Enabled = True

                    btnRevise.Enabled = True
                    If gvheader.SelectedDataKey(2) = False Then
                        btnExe.Enabled = False
                    Else
                        btnExe.Enabled = True
                    End If
                    btnClose.Enabled = False

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "APP has been successfully posted.")
                End If
            End If
        'Catch ex As Exception
        '    msg.UserMsgBox(ex.ToString, Me, False)
        'End Try
    End Sub
    Protected Sub btnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        Try
            Dim status As Integer
            Dim Count As Integer
            Dim BalanceCount As Integer
            Dim BalanceCountPPA As Integer
            Dim x As Decimal
            x = 0.0

            '=== OOE
            Dim dtOOE As DataTable
            dtOOE = objDerived.GetDataTable("EXEC [AMS].[APP_PPMP_BudgetCheck] '" & Session("year") & "','" & Session("isSupplemental") & "'", CommandType.Text)
            BalanceCount = 0
            For i As Integer = 0 To dtOOE.Rows.Count - 1
                If dtOOE.Rows(i)("balance") = 1 Then
                    BalanceCount = BalanceCount + 1
                End If
            Next

            '=== PPA 
            Dim dtPPA As DataTable
            dtPPA = objDerived.GetDataTable("EXEC [AMS].[APP_PPMP_BudgetCheck_PPA] '" & Session("year") & "','" & Session("isSupplemental") & "'", CommandType.Text)
            BalanceCountPPA = 0
            For i As Integer = 0 To dtPPA.Rows.Count - 1
                If dtPPA.Rows(i)("balance") = 1 Then
                    BalanceCountPPA = BalanceCountPPA + 1
                End If
            Next

            Count = BalanceCount + BalanceCountPPA

            If Count = 0 Then
                If gvheader.SelectedDataKey(4) = 1 Or gvheader.SelectedDataKey(4) = 4 Then
                    status = 1
                ElseIf gvheader.SelectedDataKey(4) = 2 Or gvheader.SelectedDataKey(4) = 5 Then
                    status = 2
                End If

                objDerived.GetRecords("Update AMS.APP set isforRevision=0,isApproved=1,status=" & status & " where year='" & gvheader.SelectedDataKey(0) & "'  and app_id ='" & gvheader.SelectedDataKey("app_id") & "'", CommandType.Text)
                pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
                If pgvheader.Rows.Count < 5 Then
                    pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
                End If
                gvheader.DataSource = pgvheader
                gvheader.DataBind()

                btnApproved.Enabled = False
                btnExe.Enabled = True
                btnRevise.Enabled = True

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "APP has been successfully approved.")
            Else

                Dim dtPPMP1 As New DataTable
                Dim dtPPMP2 As New DataTable
                Dim NoApproved As Integer
                Dim wApproved As Integer

                dtPPMP1 = objDerived.GetDataTable("EXEC [AMS].[APP_PPMP_BudgetCheck_Approved] '" & Session("year") & "', 'FALSE', 0", CommandType.Text)
                NoApproved = dtPPMP1.Rows.Count

                dtPPMP2 = objDerived.GetDataTable("EXEC [AMS].[APP_PPMP_BudgetCheck_Approved] '" & Session("year") & "', 'FALSE', 1", CommandType.Text)
                wApproved = dtPPMP2.Rows.Count

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "" & wApproved & " PPMP(s) has exceeded its allocated budget and " & NoApproved & " PPMP(s) without approved budget. Kindly verify and adjust to continue transaction.")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvppmp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvppmp.PageIndexChanging
        Me.TabContainer1.ActiveTabIndex = 0

        Me.gvppmp.PageIndex = e.NewPageIndex
        'pgvppmp = objDerived.GetDataTable("exec ams.APP_PPMP_Status " & gvheader.SelectedDataKey(0) & ",'" & withApprovedBudget & "','" & gvheader.SelectedDataKey(5) & "'", CommandType.Text)
        pgvppmp = objDerived.GetDataTable("exec AMS.APP_PPMP_List " & gvheader.SelectedDataKey(0) & ",'" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
        pgvppmp.Merge(createdatatable2(9))
        gvppmp.DataSource = pgvppmp
        gvppmp.DataBind()
        gvppmp.SelectedIndex = -1
    End Sub

    Protected Sub gvppmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvppmp.SelectedIndexChanged
        Me.TabContainer1.ActiveTabIndex = 0
    End Sub

    Protected Sub btnRevise_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevise.Click
        Dim status As Integer
        If gvheader.SelectedDataKey(4) = 1 Then
            status = 4
        ElseIf gvheader.SelectedDataKey(4) = 2 Then
            status = 5
        End If

        objDerived.GetRecords("Update AMS.APP set isforRevision=1,status=" & status & " where year=" & gvheader.SelectedDataKey(0) & "", CommandType.Text)
        pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
        If pgvheader.Rows.Count < 5 Then
            pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
        End If
        gvheader.DataSource = pgvheader
        gvheader.DataBind()
        btnExe.Enabled = True
        btnRevise.Enabled = False
        btnClose.Enabled = False


        Dim negative As Boolean

        For i As Integer = 0 To gvppmp.Rows.Count - 1
            If gvppmp.Rows(i).Cells(4).Text < "0.00" Then
                negative = True
                Exit For
            End If
        Next

        If gvheader.SelectedDataKey(2) = False Then
            If withApprovedBudget = False Then
                btnApproved.Enabled = False
                btnExe.Enabled = False
            Else
                btnApproved.Enabled = True
                btnExe.Enabled = False
            End If


        Else
            If withApprovedBudget = False Then
                btnExe.Enabled = False
            Else
                btnExe.Enabled = True
            End If
            btnApproved.Enabled = False

        End If
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "APP is ready for revision.")

    End Sub

    Protected Sub btnExe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExe.Click
        Dim status As Integer
        status = pgvheader.Compute("count(status)", "(year<>" & gvheader.SelectedDataKey(0) & ") and (status=2 or status=5)")

        If gvheader.SelectedDataKey(0) = Year(Date.Today) Then
            If status = 0 Then
                objDerived.GetRecords("Update AMS.APP set isforRevision=0,status=2 where year='" & gvheader.SelectedDataKey(0) & "'  and app_id ='" & gvheader.SelectedDataKey("app_id") & "'", CommandType.Text)
                pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
                If pgvheader.Rows.Count < 5 Then
                    pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
                End If
                gvheader.DataSource = pgvheader
                gvheader.DataBind()
                btnRevise.Enabled = True
                btnExe.Enabled = False
                btnClose.Enabled = True

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "APP is now ready to use for procurement.")

            Else
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Close the current APP before proceeding this transaction.")
            End If
        Else

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "This APP is not allowed to be used this year.")

        End If
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        objDerived.GetRecords("Update AMS.APP set isforRevision=0,status=3 where year=" & gvheader.SelectedDataKey(0) & "", CommandType.Text)
        pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
        If pgvheader.Rows.Count < 5 Then
            pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
        End If
        gvheader.DataSource = pgvheader
        gvheader.DataBind()


        Dim status As Integer
        status = pgvheader.Compute("count(status)", "status=2 or status=5")
        If status = 0 Then ''
            btnExe.Enabled = True
        Else
            btnExe.Enabled = False
        End If
        btnPosted.Enabled = False
        btnApproved.Enabled = False
        btnRevise.Enabled = False
        ' btnExe.Enabled = Falses
        btnClose.Enabled = False
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Then
            ElseIf ddBAC4.SelectedItem.Text = "" Or ddBAC5.SelectedItem.Text = "" Then 'ADD THIS LINE 02/12/2025
            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Then
            ElseIf ddApprovedBy.SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
                Exit Sub
            End If
        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
            pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
            If pgvheader.Rows.Count < 5 Then
                pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
            End If
            gvheader.DataSource = pgvheader
            gvheader.DataBind()

            Exit Sub
        End Try

        '===============================================================================
        Try
            Session("year") = gvheader.SelectedDataKey(0)
            Session("isContinuing") = False 'gvheader.SelectedDataKey(5)
            Session("isSupplemental") = False 'gvheader.SelectedDataKey("isSupplemental")
            Session("Page") = "Planning"

            LoadSignatories()

            If ddSearchOption.SelectedItem.Value = 1 Then
                Session("BAC Members") = "seven"
            ElseIf ddSearchOption.SelectedItem.Value = 2 Then
                Session("BAC Members") = "five"
            End If

            'Me.Page.Response.Redirect("~/PLANNING/rpt_app.aspx")

            Dim url As String = "/PLANNING/rpt_app.aspx"
            Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)


        Catch ex As Exception
        End Try

    End Sub
    Protected Sub btncreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncreate.Click
        Try
            btncreate.Enabled = False
            app.title = "Annual Procurement Plan for " + CType(Year(Date.Today) + 1, String) + "."
            app.year = Year(Date.Today) + 1
            app.isPosted = False
            app.isApproved = False
            app.isforRevision = False
            app.status = 1
            app.cerifiedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityBudgetOfficer", CommandType.Text) 'Budget Officer's EmpID
            app.approvedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityMayor", CommandType.Text) 'Mayor's EmpID
            app.preparedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityGeneralServicesOfficer", CommandType.Text)
            app.isContinuing = False
            app.isSupplemental = False
            app.save()



            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")


            pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
            If pgvheader.Rows.Count < 5 Then
                pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))

            End If
            gvheader.DataSource = pgvheader
            gvheader.DataBind()

            ' Call the stored procedure to add the CY2025 column
            Dim result As String = objDerived.GetValue("EXEC dbo.sp_Add_NewCY", CommandType.Text)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSupplemental_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'app.title = "Supplemental APP for " + CType(Year(Date.Today ), String) + "."

            Dim title As String = objDerived.GetValue("select [AMS].[func_GenerateSupplemental]('" & Year(Date.Today) & "')", CommandType.Text)

            app.title = title
            app.year = Year(Date.Today)
            app.isPosted = False
            app.isApproved = False
            app.isforRevision = False
            app.status = 1
            app.cerifiedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityBudgetOfficer", CommandType.Text) 'Budget Officer's EmpID
            app.approvedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityMayor", CommandType.Text) 'Mayor's EmpID
            app.preparedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityGeneralServicesOfficer", CommandType.Text)
            app.isContinuing = False
            app.isSupplemental = True
            app.save()

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            pgvheader = objDerived.GetDataTable("select * from ams.vw_app order by year desc", CommandType.Text)
            If pgvheader.Rows.Count < 5 Then
                pgvheader.Merge(createdatatable1(4 - pgvheader.Rows.Count))
            End If
            gvheader.DataSource = pgvheader
            gvheader.DataBind()

            btnSupplemental.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvPPA_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvPPA.PageIndexChanging
        Me.TabContainer1.ActiveTabIndex = 1
        Me.gvPPA.PageIndex = e.NewPageIndex
        'pgvPPA = objDerived.GetDataTable("exec ams.APP_PPMP_Status_PPA " & gvheader.SelectedDataKey(0) & ",'" & withApprovedBudget & "','" & gvheader.SelectedDataKey(5) & "'", CommandType.Text)
        pgvPPA = objDerived.GetDataTable("exec [AMS].[APP_PPMP_List_PPA] " & gvheader.SelectedDataKey(0) & ",'" & gvheader.SelectedDataKey("isSupplemental") & "'", CommandType.Text)
        pgvPPA.Merge(createdatatable3(9))
        gvPPA.DataSource = pgvPPA
        gvPPA.DataBind()
        gvPPA.SelectedIndex = -1
    End Sub

    '===== ADD THIS SUB 02/12/2025 =====
    Protected Sub ddSearchOption_SelectedIndexChanging(ByVal sender As Object, ByVal e As EventArgs) Handles ddSearchOption.SelectedIndexChanged
        If ddSearchOption.SelectedItem.Value = 0 Then
            LoadSignatoryDisEnable()
        End If
        If ddSearchOption.SelectedItem.Value = 1 Then
            Session("BAC Members") = "seven"
            LoadSignatoryEnable()
            ddBAC4.Enabled = True
            ddBAC5.Enabled = True
        ElseIf ddSearchOption.SelectedItem.Value = 2 Then
            Session("BAC Members") = "five"
            LoadSignatoryEnable()
            ddBAC4.Enabled = False
            ddBAC5.Enabled = False
        End If

    End Sub

    Protected Sub gvPPA_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPPA.SelectedIndexChanged
        Me.TabContainer1.ActiveTabIndex = 1
    End Sub
    Public Function createdatatable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("CYEAR", GetType(Integer))
        dt.Columns.Add("RC_Id", GetType(Integer))
        dt.Columns.Add("Function_Id", GetType(Integer))
        dt.Columns.Add("Project_ID", GetType(Integer))
        dt.Columns.Add("Program_Id", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("Ga_Code", GetType(Integer))
        dt.Columns.Add("isApproved", GetType(Boolean))
        dt.Columns.Add("Ga_Code2", GetType(Integer))
        dt.Columns.Add("GA_title", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("CYEAR") = DBNull.Value
            dr("RC_Id") = DBNull.Value
            dr("Function_Id") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_Id") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("amount") = DBNull.Value
            dr("Ga_Code") = DBNull.Value
            dr("isApproved") = True
            dr("Ga_Code2") = DBNull.Value
            dr("GA_title") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatable3(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("CYEAR", GetType(Integer))
        dt.Columns.Add("RC_Id", GetType(Integer))
        dt.Columns.Add("Function_Id", GetType(Integer))
        dt.Columns.Add("Project_ID", GetType(Integer))
        dt.Columns.Add("Program_Id", GetType(Integer))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        dt.Columns.Add("rc_name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("Ga_Code", GetType(Integer))
        dt.Columns.Add("isApproved", GetType(Boolean))
        dt.Columns.Add("Ga_Code2", GetType(Integer))
        dt.Columns.Add("GA_title", GetType(String))
        dt.Columns.Add("PPA", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("CYEAR") = DBNull.Value
            dr("RC_Id") = DBNull.Value
            dr("Function_Id") = DBNull.Value
            dr("Project_ID") = DBNull.Value
            dr("Program_Id") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("BGA_ID") = DBNull.Value
            dr("rc_name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("amount") = DBNull.Value
            dr("Ga_Code") = DBNull.Value
            dr("isApproved") = True
            dr("Ga_Code2") = DBNull.Value
            dr("GA_title") = DBNull.Value
            dr("PPA") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub LoadSignatoryEnable()
        'ddBAC1.Enabled = True
        'ddBAC2.Enabled = True
        'ddBAC3.Enabled = True
        'ddBACVC.Enabled = True
        'ddBACC.Enabled = True
        'ddPreparedBy.Enabled = True
        'ddApprovedBy.Enabled = 
        Dim controls As List(Of Control) = New List(Of Control) From {
        ddBAC1, ddBAC2, ddBAC3, ddBAC4, ddBAC5, ddBACVC, ddBACC, ddPreparedBy, ddApprovedBy
    } 'ddBAC4 AND ddBAC5 were added 02/12/2025

        For Each control As Control In controls
            If TypeOf control Is WebControl Then
                CType(control, WebControl).Enabled = True
            End If
        Next
    End Sub

    Protected Sub LoadSignatoryDisEnable()
        'ddBAC1.Enabled = False
        'ddBAC2.Enabled = False
        'ddBAC3.Enabled = False
        'ddBACVC.Enabled = False
        'ddBACC.Enabled = False
        'ddPreparedBy.Enabled = False
        'ddApprovedBy.Enabled = False
        Dim controls As List(Of Control) = New List(Of Control) From {
        ddBAC1, ddBAC2, ddBAC3, ddBAC4, ddBAC5, ddBACVC, ddBACC, ddPreparedBy, ddApprovedBy
    } 'ddBAC4 AND ddBAC5 were added 02/12/2025

        For Each control As Control In controls
            If TypeOf control Is WebControl Then
                CType(control, WebControl).Enabled = False
            End If
        Next
    End Sub

    Protected Sub LoadSignatories()

        Dim Prep As String
        Prep = objDerived.GetValue("SELECT UPPER(Position_desc) as Position_desc FROM dbo.View_BAC WHERE empsig_id = '" & ddPreparedBy.SelectedItem.Value & "'", CommandType.Text)


        objDerived.GetRecords("UPDATE dbo.Temp_BACSignatories SET BAC1 = '" & ddBAC1.SelectedItem.Value & "', BAC2 = '" & ddBAC2.SelectedItem.Value & "', BAC3 = '" & ddBAC3.SelectedItem.Value & "', BACVC = '" & ddBACVC.SelectedItem.Value & "', BACC = '" & ddBACC.SelectedItem.Value & "'", CommandType.Text)

        '===== ADD THIS CODE 02/12/2025 =====
        If ddSearchOption.SelectedItem.Value = 1 Then
            objDerived.GetRecords("UPDATE dbo.Temp_BACSignatories SET BAC4 = '" & ddBAC4.SelectedItem.Value & "', BAC5 = '" & ddBAC5.SelectedItem.Value & "'", CommandType.Text)
        End If

        objDerived.GetRecords("UPDATE dbo.Temp_BACSignatories SET ApprovedBy = '" & ddApprovedBy.SelectedItem.Value & "', PreparedBy = '" & ddPreparedBy.SelectedItem.Text & "', PreparedBy_Pos = '" & Prep & "', DateSet = '" & Date.Today & "', UserName = '" & Session("@UserName") & "'", CommandType.Text)


    End Sub


    'Protected Sub ddBAC1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddBAC1.Enabled = False
    '    ddBAC2.Enabled = True
    '    ddBAC3.Enabled = False
    '    ddBACVC.Enabled = False
    '    ddBACC.Enabled = False
    '    ddApprovedBy.Enabled = False
    '    ddPreparedBy.Enabled = False
    'End Sub

    'Protected Sub ddBAC2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddBAC2.Enabled = False
    '    ddBAC3.Enabled = True
    '    ddBACVC.Enabled = False
    '    ddBACC.Enabled = False
    '    ddApprovedBy.Enabled = False
    '    ddPreparedBy.Enabled = False
    'End Sub

    'Protected Sub ddBAC3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddBAC3.Enabled = False
    '    ddBACVC.Enabled = True
    '    ddBACC.Enabled = False
    '    ddApprovedBy.Enabled = False
    '    ddPreparedBy.Enabled = False
    'End Sub

    'Protected Sub ddBACVC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddBACVC.Enabled = False
    '    ddBACC.Enabled = True
    '    ddApprovedBy.Enabled = False
    '    ddPreparedBy.Enabled = False
    'End Sub

    'Protected Sub ddBACC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddBACC.Enabled = False
    '    ddApprovedBy.Enabled = True
    '    ddPreparedBy.Enabled = False
    'End Sub

    'Protected Sub ddApprovedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddApprovedBy.Enabled = False
    '    ddPreparedBy.Enabled = True
    'End Sub

    'Protected Sub ddPreparedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    'End Sub

    Protected Sub lnkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnPreview_APPDepartment_Click(sender As Object, e As EventArgs) Handles btnPreview_APPDepartment.Click
        'Try

        Session("DeptYear") = drpYear.SelectedItem.Value
        Session("Department_ID") = drpDepartment.SelectedItem.Value
        Session("Dept_Function_ID") = drpFunction.SelectedItem.Value

        Session("PPA") = drpPPA.SelectedItem.Text
        If Session("PPA") = "All" Or Session("PPA") = "Office Operational Expense" Then
            Session("Program_ID") = 0
            Session("Project_ID") = 0
        Else
            Session("Program_ID") = dtPPA.Rows(drpPPA.SelectedIndex - 2)("Program_ID")
            Session("Project_ID") = dtPPA.Rows(drpPPA.SelectedIndex - 2)("Project_ID")
        End If





        If drpAPPReport.SelectedItem.Value = 1 Then
            Session("Format") = "MOOE"
            Session("AllotmentClass_ID") = 2

        ElseIf drpAPPReport.SelectedItem.Value = 3 Then
            Session("Format") = "SUPPLIES"
            Session("AllotmentClass_ID") = 2

        ElseIf drpAPPReport.SelectedItem.Value = 2 Then
            Session("Format") = "CO"
            Session("AllotmentClass_ID") = 3
        ElseIf drpAPPReport.SelectedItem.Value = 4 Then
            Session("Format") = "All"

        End If

        'Me.Page.Response.Redirect("~/MainReports/Planning_APP.aspx")
        Dim url As String = "/MainReports/Planning_APP.aspx"
        Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"

        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)
        'Catch ex As Exception
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        'End Try

    End Sub
End Class
