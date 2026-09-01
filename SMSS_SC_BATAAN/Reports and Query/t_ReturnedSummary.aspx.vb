Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_ReturnedSummary
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private objDerived2 As New connectionreport


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            ddDepartment.DataTextField = "RC_Name"
            ddDepartment.DataValueField = "RC_id"
            ddDepartment.DataBind()
            ddDepartment.Items.Insert(0, "Select")

            ddYear.DataSource = objDerived.GetDataTable("SELECT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)
            ddYear.DataTextField = "year"
            ddYear.DataValueField = "year"
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

            ddPreparedBy.DataSource = objDerived.GetDataTable("SELECT EmpID, Upper(Full_Name) AS Full_Name  FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
            ddPreparedBy.DataTextField = "Full_Name"
            ddPreparedBy.DataValueField = "EmpID"
            ddPreparedBy.DataBind()
            ddPreparedBy.Items.Insert(0, "Select")

        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cbAll.Checked = False Then
            If ddDepartment.SelectedItem.Text = "Select" Or ddYear.SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = ddDepartment.SelectedItem.Value
                Session("Year") = ddYear.SelectedItem.Value
                Session("Month") = ddMonth.SelectedItem.Value
                Session("Status") = ddOption.SelectedItem.Value
                Session("PreparedBy") = ddPreparedBy.SelectedItem.Value

                Me.Page.Response.Redirect("~/Reports and Query/rpt_ReturnedPPESummay.aspx")
            End If

        Else
            If ddYear.SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = 0
                Session("Year") = ddYear.SelectedItem.Value
                Session("Month") = ddMonth.SelectedItem.Value
                Session("Status") = ddOption.SelectedItem.Value
                Session("PreparedBy") = ddPreparedBy.SelectedItem.Value

                Me.Page.Response.Redirect("~/Reports and Query/rpt_ReturnedPPESummay.aspx")
            End If
        End If
    End Sub

    Protected Sub cbAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If cbAll.Checked = True Then
            ddDepartment.Enabled = False
        Else
            ddDepartment.Enabled = True
        End If
    End Sub

End Class
