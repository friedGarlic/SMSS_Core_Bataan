Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class t_rpt_clearance
    Inherits System.Web.UI.Page
    Dim DBPassUsernname As New connectionreport
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name, RC_id FROM dbo.View_RespCenter_withFunctions ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataTextField = ("RC_Name")
            ddDepartment.DataValueField = ("RC_id")
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddFunction.Items.Insert(0, "Select")
            ddEmployee.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddFunction.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE RC_id = '" & ddDepartment.SelectedItem.Value & "'", CommandType.Text)
        ddFunction.DataTextField = ("Function_Desc")
        ddFunction.DataValueField = ("Function_ID")
        ddFunction.DataBind()
        ddFunction.Items.Insert(0, "Select")
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddEmployee.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = '" & ddDepartment.SelectedItem.Value & "' AND division_key = '" & ddFunction.SelectedItem.Value & "'", CommandType.Text)
        ddEmployee.DataTextField = ("full_name")
        ddEmployee.DataValueField = ("empid")
        ddEmployee.DataBind()
        ddEmployee.Items.Insert(0, "Select")

    End Sub

    Protected Sub ddEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Emp_ID") = ddEmployee.SelectedItem.Value

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If ddDepartment.SelectedItem.Text = "Select" Or ddFunction.SelectedItem.Text = "Select" Or ddEmployee.SelectedItem.Text = "Select" Then
        Else
            Me.Page.Response.Redirect("~/Reports and Query/rpt_Clearance.aspx")
            Session("EMP") = ddEmployee.SelectedItem.text
        End If
    End Sub


End Class
