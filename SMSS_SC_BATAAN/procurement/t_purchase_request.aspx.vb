Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Procurement_t_purchase_request
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr

#Region "Property"

    Private Property pPurchaseRequest() As DataTable
        Get
            Return CType(Session("pPurchaseRequest"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchaseRequest") = value
        End Set
    End Property

    Private Property popentrans() As DataTable
        Get
            Return CType(Session("popentrans"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popentrans") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.drpTransType.DataSource = objDerived.GetRecords("SELECT TOP (100) PERCENT transaction_id, Description FROM AMS.Transaction_type ORDER BY Description", CommandType.Text)
            Me.drpTransType.DataTextField = "Description"
            Me.drpTransType.DataValueField = "transaction_id"
            Me.drpTransType.DataBind()


            Me.ddlDepartment.DataSource = objDerived.GetDataTable("SELECT rc_id, rc_name, F_ID FROM dbo.m_Resp_center ORDER BY rc_name", CommandType.Text)
            Me.ddlDepartment.DataTextField = "rc_name"
            Me.ddlDepartment.DataValueField = "rc_id"
            Me.ddlDepartment.DataBind()

            ' Add default "Select Department" option
            ddlDepartment.Items.Insert(0, New ListItem("-- Select Department --", "0"))



            pPurchaseRequest = objDerived.GetDataTable("EXEC [AMS].[sp_RQ_PRSearch]", CommandType.Text)
            gvopen.DataSource = pPurchaseRequest
            gvopen.DataBind()

            Me.txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

            'RadioButtonList1.SelectedIndex = 0
            'LoadrbChoice()

            txtPRNumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchPRNo.ClientID & "')")
            txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            ddlFilterBy_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub




    Protected Sub ddlDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDepartment.SelectedIndexChanged
        ' Automatically filter the GridView when a department is selected
        ' BindDepartmentDropdown()
    End Sub



    Private Sub gvopen_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvopen.PageIndexChanging
        gvopen.DataSource = pPurchaseRequest
        gvopen.PageIndex = e.NewPageIndex
        gvopen.DataBind()

    End Sub

    Protected Sub ddlFilterBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFilterBy.SelectedIndexChanged
        Select Case ddlFilterBy.SelectedValue
            Case "1"
                '======== PR Number ========
                Me.MultiView1.SetActiveView(Me.View1)
                txtPRNumber.Text = ""

            Case "2"
                '======== Date Duration ========
                Me.MultiView1.SetActiveView(Me.View2)
                txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
                txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

            Case "3"
                '======== Allotment Type ========
                Me.MultiView1.SetActiveView(Me.View3)

            Case "4"
                '======== Department Selection ========
                Me.MultiView1.SetActiveView(Me.View4)
                ' BindDepartmentDropdown()
        End Select
    End Sub


    Public Sub BindDepartmentDropdown()
        Try
            ' Ensure a department is selected
            If ddlDepartment.SelectedValue = "0" Then
                AddTrace("No department selected, skipping filter.")
                Exit Sub
            End If

            ' Debugging logs
            AddTrace("BindDepartmentDropdown() called")
            AddTrace("Selected Department ID: " & ddlDepartment.SelectedValue)
            AddTrace("Selected Department Name: " & ddlDepartment.SelectedItem.Text)

            Dim myview As DataView = pPurchaseRequest.DefaultView
            Dim filterCondition As String = ""

            ' Ensure rc_id exists in the DataTable before filtering
            If pPurchaseRequest.Columns.Contains("rc_id") Then
                filterCondition = "rc_id = '" & ddlDepartment.SelectedValue & "'"
                AddTrace("Filtering by rc_id: " & ddlDepartment.SelectedValue)
            ElseIf pPurchaseRequest.Columns.Contains("rc_name") Then
                filterCondition = "rc_name = '" & ddlDepartment.SelectedItem.Text.Replace("'", "''") & "'"
                AddTrace("rc_id not found. Filtering by rc_name instead: " & ddlDepartment.SelectedItem.Text)
            Else
                AddTrace("ERROR: Neither rc_id nor rc_name found in pPurchaseRequest.")
                Exit Sub
            End If

            ' Apply the filter
            myview.RowFilter = filterCondition
            gvopen.DataSource = myview
            gvopen.DataBind()

        Catch ex As Exception
            AddTrace("ERROR in BindDepartmentDropdown(): " & ex.Message)
        End Try
    End Sub


    Protected Sub btnSearchDepartment_CLick(sender As Object, e As EventArgs) Handles btnSearchDepartment.Click
        BindDepartmentDropdown()

    End Sub
    'Public Sub BindDepartmentDropdown()
    '    Try
    '        ' Ensure a department is selected
    '        If ddlDepartment.SelectedValue = "0" Then
    '            AddTrace("No department selected, skipping filter.")
    '            Exit Sub
    '        End If

    '        ' Debugging logs
    '        AddTrace("BindDepartmentDropdown() called")
    '        AddTrace("Selected Department ID: " & ddlDepartment.SelectedValue)
    '        AddTrace("Selected Department Name: " & ddlDepartment.SelectedItem.Text)

    '        ' Ensure rc_name exists in the DataTable
    '        If Not pPurchaseRequest.Columns.Contains("rc_name") Then
    '            AddTrace("ERROR: pPurchaseRequest does not contain column rc_name.")
    '            Exit Sub
    '        End If

    '        ' Apply department filter using rc_name
    '        Dim myview As DataView = pPurchaseRequest.DefaultView
    '        myview.RowFilter = "rc_name = '" & ddlDepartment.SelectedItem.Text.Replace("'", "''") & "'"
    '        gvopen.DataSource = myview
    '        gvopen.DataBind()

    '        AddTrace("Filtered by department name: " & ddlDepartment.SelectedItem.Text)

    '    Catch ex As Exception
    '        AddTrace("ERROR in BindDepartmentDropdown(): " & ex.Message)
    '    End Try
    'End Sub


    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub


    Protected Sub btnSearchPRNo_Click(sender As Object, e As EventArgs) Handles btnSearchPRNo.Click

        Dim myview As DataView
        myview = pPurchaseRequest.DefaultView
        myview.RowFilter = "pr_no like '%" & txtPRNumber.Text & "%'"
        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub
    Protected Sub btnTransType_Click(sender As Object, e As EventArgs) Handles btnTransType.Click
        Dim myview As DataView
        myview = pPurchaseRequest.DefaultView
        myview.RowFilter = "Transaction_type = '" & drpTransType.SelectedItem.Value & "'"
        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub

    Protected Sub btnByDate_Click(sender As Object, e As EventArgs) Handles btnByDate.Click
        Dim myview As DataView
        myview = pPurchaseRequest.DefaultView
        myview.RowFilter = "PR_Date >= '" & (txtdatefrom.Text) & "' AND PR_Date <= '" & (txtdateto.Text) & "'"
        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub

    Protected Sub gvopen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvopen.SelectedIndexChanged
        Session("Page") = "RQ"
        Session("Report") = "PR"
        Session("prhdr_id") = gvopen.SelectedDataKey("prhdr_id")


        'Me.Page.Response.Redirect("~/procurement/rpt_purchase_request.aspx")
        'Me.Page.Response.Redirect("~/MainReports/Procurement_Reports.aspx")


        Dim url As String = "/MainReports/Procurement_Reports.aspx"
        Dim fullURL As String = "var win=window.open('" & url & "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_PR_WINDOW", fullURL, True)

    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)

    End Sub


End Class
