Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Procurement_t_receiving
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] ", CommandType.Text)
            grdReceived.DataBind()

            rbChoice.SelectedItem.Value = 1
            LoadrbChoice()

            txtPONumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnPO.ClientID & "')")
            txtFrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate.ClientID & "')")
            txtTo.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchDate.ClientID & "')")


        End If
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub ddReceivedBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As String = ddReceivedBy.SelectedItem.Text
    End Sub

    Protected Sub LoadrbChoice()

        Select Case (rbChoice.SelectedIndex)
            Case 0
                Me.mvSearch.SetActiveView(Me.vwReceivedBy)

                Dim Rcv As New DataTable
                Rcv = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory where deptid = 7 and division_key = 86 ORDER BY full_name", CommandType.Text)
                ddReceivedBy.DataSource = Rcv
                ddReceivedBy.DataTextField = ("full_name")
                ddReceivedBy.DataValueField = ("Signatory_ID")
                ddReceivedBy.DataBind()
                ddReceivedBy.Items.Insert(0, "Select")

            Case 1
                Me.mvSearch.SetActiveView(Me.vwDate)

                Dim d As Date = Date.Today.ToString("MM/dd/yyyy")
                d = d.AddDays(-1)
                txtFrom.Text = d

                txtTo.Text = Date.Today.ToString("MM/dd/yyyy")

            Case 2
                Me.mvSearch.SetActiveView(Me.vwPO)
                txtPONumber.Text = ""


        End Select

    End Sub

    Protected Sub LoadSearching()
        If rbChoice.SelectedItem.Value = 1 Then
            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] WHERE ReceivedBy_ID = '" & ddReceivedBy.SelectedItem.Value & "'", CommandType.Text)
            grdReceived.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] WHERE Received_Date BETWEEN '" & txtFrom.Text & "' and '" & txtTo.Text & "'", CommandType.Text)
            grdReceived.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 3 Then
            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] WHERE PO_No like '%" & txtPONumber.Text & "%'", CommandType.Text)
            grdReceived.DataBind()

        End If
    End Sub

    Protected Sub btnSearchRB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchRB.Click
        LoadSearching()

    End Sub

    Protected Sub btnSearchDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSearching()

    End Sub

    Protected Sub btnPO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSearching()

    End Sub

    Protected Sub grdReceived_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "RQ"
        Session("Received_ID") = grdReceived.SelectedDataKey("Received_ID")
        Me.Page.Response.Redirect("~/procurement/t_rpt_receiving.aspx")
    End Sub


    Protected Sub grdReceived_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If rbChoice.SelectedItem.Value = 1 Then
            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] WHERE ReceivedBy_ID = '" & ddReceivedBy.SelectedItem.Value & "'", CommandType.Text)
            grdReceived.PageIndex = e.NewPageIndex
            grdReceived.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] WHERE Received_Date BETWEEN '" & txtFrom.Text & "' and '" & txtTo.Text & "'", CommandType.Text)
            grdReceived.PageIndex = e.NewPageIndex
            grdReceived.DataBind()

        ElseIf rbChoice.SelectedItem.Value = 3 Then
            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_Receiving] WHERE PO_No like '%" & txtPONumber.Text & "%'", CommandType.Text)
            grdReceived.PageIndex = e.NewPageIndex
            grdReceived.DataBind()

        End If
    End Sub
End Class

