Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_rpt_PRS
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            grdPRS.DataSource = Nothing
            grdPRS.DataBind()

            rbChoice.SelectedItem.Value = 1
            LoadrbChoice()

            Session("Page") = "RQ"
        End If
    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadrbChoice()
    End Sub

    Protected Sub LoadrbChoice()
        grdPRS.DataSource = Nothing
        grdPRS.DataBind()


        If rbChoice.SelectedItem.Value = 1 Then
            Me.mvCategory.SetActiveView(Me.vwRC)

            ddDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataTextField = ("RC_Name")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddFunction.DataSource = Nothing
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")

        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Me.mvCategory.SetActiveView(Me.vwEmployee)

        ElseIf rbChoice.SelectedItem.Value = 3 Then
            Me.mvCategory.SetActiveView(Me.vwDate)

            txtFrom.Text = Date.Today.ToString("MM/dd/yyyy")
            txtTo.Text = Date.Today.ToString("MM/dd/yyyy")

        End If
    End Sub

    Protected Sub grdPRS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Returned_ID") = grdPRS.SelectedDataKey("Returned_ID")
        'Me.Page.Response.Redirect("~/Reports and Query/rpt_PRS.aspx")
        Me.Page.Response.Redirect("~/Inventory/t_rpt_return_slip.aspx")
    End Sub

    'Protected Sub btnrc_click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If ddDepartment.SelectedItem.Text = "select" Or ddFunction.SelectedItem.Text = "select" Then
    '        grdPRS.DataSource = Nothing
    '        grdPRS.DataBind()
    '    Else
    '        grdPRS.DataSource = objDerived.GetDataTable("select * from [dbo].[view_prs_list] where rc_id = '" & ddDepartment.SelectedItem.Value & "' and function_id = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)

    '    End If


    '    'added by john



    'End Sub



    'added by john
    Protected Sub btnrc_click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddDepartment.SelectedItem.Text = "Select" Or ddFunction.SelectedItem.Text = "Select" Then
            grdPRS.DataSource = Nothing
            grdPRS.DataBind()
        Else
            grdPRS.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PRS_List] WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "' AND Function_ID = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
            grdPRS.DataBind()
        End If

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddDepartment.SelectedItem.Text = "Select" Then

            ddFunction.DataSource = Nothing
            ddFunction.DataBind()

            ddFunction.Items.Insert(0, "Select")
        Else
            ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_ID = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
            ddFunction.DataTextField = ("Function_Desc")
            ddFunction.DataValueField = ("Function_ID")
            ddFunction.DataBind()
            ddFunction.Items.Insert(0, "Select")
        End If
  
    End Sub

    Protected Sub btnEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtEmployee.Text = "" Then
            grdPRS.DataSource = Nothing
            grdPRS.DataBind()
        Else
            grdPRS.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PRS_List] WHERE ReturnedBy LIKE '%" & txtEmployee.Text & "%'", CommandType.Text)
            grdPRS.DataBind()
        End If

    End Sub

    Protected Sub btnDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        grdPRS.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PRS_List] WHERE Returned_Date BETWEEN '" & txtFrom.Text & "' AND '" & txtTo.Text & "'", CommandType.Text)
        grdPRS.DataBind()
    End Sub
End Class
