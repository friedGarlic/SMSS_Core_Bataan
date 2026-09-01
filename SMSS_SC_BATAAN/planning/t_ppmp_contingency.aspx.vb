Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class planning_t_ppmp_contingency
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim Conti As New t_ppmp_contingency
    Dim withApprovedBudget As Boolean

#Region "property"
    Private Property pDatatable() As DataTable
        Get
            Return CType(Session("pDatatable"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pDatatable") = value
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

    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set
    End Property

    Public Sub CreateTable1()
        Me.pDatatable = New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn

        myDataColumn = New DataColumn()
        pDatatable.Columns.Add("1st")
        pDatatable.Columns.Add("2nd")
        pDatatable.Columns.Add("3rd")
        pDatatable.Columns.Add("4th")
        pDatatable.Columns.Add("Total")

        dr = pDatatable.NewRow
        dr("1st") = "0.00"
        dr("2nd") = "0.00"
        dr("3rd") = "0.00"
        dr("4th") = "0.00"
        dr("Total") = "0.00"
        pDatatable.Rows.Add(dr)


    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LoadMain()
        End If
    End Sub

    Protected Sub LoadMain()
        txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

        pYear = objDerived.GetDataTable("Select * from ams.vw_app_status", CommandType.Text)
        ddYear.DataSource = pYear
        ddYear.DataTextField = ("year_title")
        ddYear.DataValueField = ("app_id")
        ddYear.DataBind()
        ddYear.Items.Insert(0, "Select")

        CreateTable1()
        grdPPMP.DataSource = pDatatable
        grdPPMP.DataBind()

        ddDepartment.Enabled = False
        ddFunction.Enabled = False
        ddAccounts.Enabled = False
        ddPreparedBy.Enabled = False
        rbChoice.Enabled = False
    End Sub

    Protected Sub ddYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Year") = pYear.Rows(ddYear.SelectedIndex - 1)("year")
        Session("isSupplemental") = pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental")

        ddDepartment.Enabled = True

        pRC = objDerived.GetDataTable("exec dbo.sp_respcenter_systemManager '" & Session("RoleName") & "'", CommandType.Text)
        ddDepartment.DataSource = CType(pRC, DataTable)
        ddDepartment.DataTextField = ("rc_name")
        ddDepartment.DataValueField = ("rc_id")
        ddDepartment.DataBind()
        ddDepartment.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.Enabled = True

        pFunction = objDerived.GetDataTable("EXEC [dbo].[sp_function_systemManager] '" & Session("RoleName") & "','" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        ddFunction.DataSource = pFunction
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        rbChoice.Enabled = True
        withApprovedBudget = objDerived.GetValue("select AMS.func_budget_status('" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "')", CommandType.Text)

        txtReviewedBy.Text = objDerived.GetValue("SELECT full_name FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 'Yes'", CommandType.Text)
        Session("ReviewedBy_Pos") = objDerived.GetValue("SELECT position_desc FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "' AND isDeptHead = 'Yes'", CommandType.Text)

        grdContingency.DataSource = objDerived.GetDataTable("SELECT * FROM [AMS].[View_ppmp_contingency] WHERE Year = '" & Session("Year") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        grdContingency.DataBind()

        ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        ddPreparedBy.DataTextField = ("full_name")
        ddPreparedBy.DataValueField = ("position_desc")
        ddPreparedBy.DataBind()
        ddPreparedBy.Items.Insert(0, "Select")

        ddReviewedBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        ddReviewedBy.DataTextField = ("full_name")
        ddReviewedBy.DataValueField = ("position_desc")
        ddReviewedBy.DataBind()
        ddReviewedBy.Items.Insert(0, "Select")

        btnPreview.Enabled = True

    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddAccounts.Enabled = True
        pAccounts = objDerived.GetDataTable("EXEC AMS.sp_GA_ID_from_LBPF_3_Per_Allotment '" & pYear.Rows(ddYear.SelectedIndex - 1)("year") & "','" & ddDepartment.SelectedItem.Value & "','" & ddFunction.SelectedItem.Value & "','" & withApprovedBudget & "',0,0,'" & rbChoice.SelectedItem.Value & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isContinuing") & "','" & pYear.Rows(ddYear.SelectedIndex - 1)("isSupplemental") & "'", CommandType.Text)
        ddAccounts.DataSource = pAccounts
        ddAccounts.DataTextField = ("GA_Title")
        ddAccounts.DataValueField = ("GA_ID")
        ddAccounts.DataBind()
        ddAccounts.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("GA_ID") = ddAccounts.SelectedItem.Value
        Session("BGA_ID") = pAccounts.Rows(ddAccounts.SelectedIndex - 1)("BGA_ID")

        ddPreparedBy.Enabled = True
        ddReviewedBy.Enabled = True

        Dim ApprovedBudget As Decimal
        ApprovedBudget = objDerived.GetValue("SELECT ApprovedFinal FROM [dbo].[View_GetBudget_Approved] WHERE Budget_Year = '" & Session("Year") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "' AND isApprovedSuppl = '" & Session("isSupplemental") & "'", CommandType.Text)
        If withApprovedBudget = True Then
            txtApprovedBudget.Text = FormatNumber(ApprovedBudget, 2)
        Else
            txtApprovedBudget.Text = "0.00"
        End If

    End Sub

    Protected Sub txt1st_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txt1st As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txt1st.NamingContainer, GridViewRow)
        txt1st.Text = FormatNumber(txt1st.Text, 2)

        Dim Amount1 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt1st"), TextBox)
        Dim Amount2 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt2nd"), TextBox)
        Dim Amount3 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt3rd"), TextBox)
        Dim Amount4 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt4th"), TextBox)

        Dim Total As Decimal = CType(Amount1.Text, Decimal) + CType(Amount2.Text, Decimal) + CType(Amount3.Text, Decimal) + CType(Amount4.Text, Decimal)

        CType(grdPPMP.Rows(0).FindControl("lblTotal"), Label).Text = FormatNumber(Total, 2)

    End Sub

    Protected Sub txt2nd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txt2nd As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txt2nd.NamingContainer, GridViewRow)
        txt2nd.Text = FormatNumber(txt2nd.Text, 2)

        Dim Amount1 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt1st"), TextBox)
        Dim Amount2 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt2nd"), TextBox)
        Dim Amount3 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt3rd"), TextBox)
        Dim Amount4 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt4th"), TextBox)

        Dim Total As Decimal = CType(Amount1.Text, Decimal) + CType(Amount2.Text, Decimal) + CType(Amount3.Text, Decimal) + CType(Amount4.Text, Decimal)

        CType(grdPPMP.Rows(0).FindControl("lblTotal"), Label).Text = FormatNumber(Total, 2)
    End Sub

    Protected Sub txt3rd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txt3rd As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txt3rd.NamingContainer, GridViewRow)
        txt3rd.Text = FormatNumber(txt3rd.Text, 2)

        Dim Amount1 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt1st"), TextBox)
        Dim Amount2 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt2nd"), TextBox)
        Dim Amount3 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt3rd"), TextBox)
        Dim Amount4 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt4th"), TextBox)

        Dim Total As Decimal = CType(Amount1.Text, Decimal) + CType(Amount2.Text, Decimal) + CType(Amount3.Text, Decimal) + CType(Amount4.Text, Decimal)

        CType(grdPPMP.Rows(0).FindControl("lblTotal"), Label).Text = FormatNumber(Total, 2)
    End Sub

    Protected Sub txt4th_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txt4th As TextBox = TryCast(sender, TextBox)
        Dim gvr As GridViewRow = TryCast(txt4th.NamingContainer, GridViewRow)
        txt4th.Text = FormatNumber(txt4th.Text, 2)

        Dim Amount1 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt1st"), TextBox)
        Dim Amount2 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt2nd"), TextBox)
        Dim Amount3 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt3rd"), TextBox)
        Dim Amount4 As TextBox = CType(grdPPMP.Rows(0).FindControl("txt4th"), TextBox)

        Dim Total As Decimal = CType(Amount1.Text, Decimal) + CType(Amount2.Text, Decimal) + CType(Amount3.Text, Decimal) + CType(Amount4.Text, Decimal)

        CType(grdPPMP.Rows(0).FindControl("lblTotal"), Label).Text = FormatNumber(Total, 2)
    End Sub

    Protected Sub ddPreparedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("PreparedBy") = ddPreparedBy.SelectedItem.Text
        Session("PreparedBy_Pos") = ddPreparedBy.SelectedItem.Value

        btnSave.Enabled = True
    End Sub

    Protected Sub ddReviewedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("ReviewedBy") = ddReviewedBy.SelectedItem.Text
        Session("ReviewedBy_Pos") = ddReviewedBy.SelectedItem.Value

        btnSave.Enabled = True
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddPreparedBy.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select prepared by.")
            Exit Sub
        End If

        Try
            Dim TAmount As Decimal = CType(grdPPMP.Rows(0).FindControl("lblTotal"), Label).Text
            Dim ApprovedBudget As Decimal
            ApprovedBudget = objDerived.GetValue("SELECT ApprovedFinal FROM [dbo].[View_GetBudget_Approved] WHERE Budget_Year = '" & Session("Year") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "' AND GA_ID = '" & Session("GA_ID") & "' AND BGA_ID = '" & Session("BGA_ID") & "' AND isApprovedSuppl = '" & Session("isSupplemental") & "'", CommandType.Text)

            Dim Amount1 As Decimal = CType(grdPPMP.Rows(0).FindControl("txt1st"), TextBox).Text
            Dim Amount2 As Decimal = CType(grdPPMP.Rows(0).FindControl("txt2nd"), TextBox).Text
            Dim Amount3 As Decimal = CType(grdPPMP.Rows(0).FindControl("txt3rd"), TextBox).Text
            Dim Amount4 As Decimal = CType(grdPPMP.Rows(0).FindControl("txt4th"), TextBox).Text
            Dim Total As Decimal = CType(grdPPMP.Rows(0).FindControl("lblTotal"), Label).Text

            If withApprovedBudget = True Then
                If TAmount > ApprovedBudget Then
                    With Conti
                        .Year = Session("Year")
                        .RC_ID = ddDepartment.SelectedItem.Value
                        .Function_ID = ddFunction.SelectedItem.Value
                        .GA_ID = Session("GA_ID")
                        .BGA_ID = Session("BGA_ID")
                        .TotalAmount = FormatNumber(Total, 2)
                        .FirstQtr = FormatNumber(Amount1, 2)
                        .SecondQtr = FormatNumber(Amount2, 2)
                        .ThirdQtr = FormatNumber(Amount3, 2)
                        .FourthQtr = FormatNumber(Amount4, 2)
                        .PreparedBy = ddPreparedBy.SelectedItem.Text
                        .PreparedBy_Pos = ddPreparedBy.SelectedItem.Value
                        .ReviewedBy = txtReviewedBy.Text
                        .ReviewedBy_Pos = Session("ReviewedBy_Pos")
                        .UserID = Session("@UserName")
                        .save()
                    End With

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                    btnPreview.Enabled = True
                Else
                    btnPreview.Enabled = False
                End If

            ElseIf withApprovedBudget = False Then
                With Conti
                    .Year = Session("Year")
                    .RC_ID = ddDepartment.SelectedItem.Value
                    .Function_ID = ddFunction.SelectedItem.Value
                    .GA_ID = Session("GA_ID")
                    .BGA_ID = Session("BGA_ID")
                    .TotalAmount = FormatNumber(Total, 2)
                    .FirstQtr = FormatNumber(Amount1, 2)
                    .SecondQtr = FormatNumber(Amount2, 2)
                    .ThirdQtr = FormatNumber(Amount3, 2)
                    .FourthQtr = FormatNumber(Amount4, 2)
                    .PreparedBy = ddPreparedBy.SelectedItem.Text
                    .PreparedBy_Pos = ddPreparedBy.SelectedItem.Value
                    .ReviewedBy = txtReviewedBy.Text
                    .ReviewedBy_Pos = Session("ReviewedBy_Pos")
                    .UserID = Session("@UserName")
                    .save()
                End With

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                btnPreview.Enabled = True
            End If

            grdContingency.DataSource = objDerived.GetDataTable("SELECT * FROM [AMS].[View_ppmp_contingency] WHERE Year = '" & Session("Year") & "' AND RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            grdContingency.DataBind()
            LoadMain()

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RC_ID") = ddDepartment.SelectedItem.Value
        Session("Function_ID") = ddFunction.SelectedItem.Value

        Me.Page.Response.Redirect("~/planning/rpt_ppmp_contingency.aspx")
    End Sub
End Class
