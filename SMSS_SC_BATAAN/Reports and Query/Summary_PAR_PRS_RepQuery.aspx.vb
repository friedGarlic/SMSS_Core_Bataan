Imports System.Data
Partial Class Reports_and_Query_Summary_PAR_PRS
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private Sub Reports_and_Query_Summary_PAR_PRS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                btnTab1_PAR.CssClass = "TabButton_Active"
                btnTab2_PRS.CssClass = "TabButton_InActive"
                DrpRC_PAR.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
                DrpRC_PAR.DataTextField = "RC_Name"
                DrpRC_PAR.DataValueField = "RC_id"
                DrpRC_PAR.DataBind()
                DrpRC_PAR.Items.Insert(0, "Select")

                drpYear_PAR.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP ORDER BY year DESC", CommandType.Text)
                drpYear_PAR.DataTextField = "year"
                drpYear_PAR.DataValueField = "year"
                drpYear_PAR.DataBind()
                drpYear_PAR.Items.Insert(0, "Select")



                mvTabs.SetActiveView(vwTab1_PAR)

            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            End Try

        End If
    End Sub

    Private Sub btnTab1_PAR_Click(sender As Object, e As EventArgs) Handles btnTab1_PAR.Click
        btnTab1_PAR.CssClass = "TabButton_Active"
        btnTab2_PRS.CssClass = "TabButton_InActive"
        btnTab3_PRI.CssClass = "TabButton_InActive"

        drpYear_PAR.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP ORDER BY year DESC", CommandType.Text)
        drpYear_PAR.DataTextField = "year"
        drpYear_PAR.DataValueField = "year"
        drpYear_PAR.DataBind()
        drpYear_PAR.Items.Insert(0, "Select")

        mvTabs.SetActiveView(vwTab1_PAR)
    End Sub

    Private Sub btnTab2_PRS_Click(sender As Object, e As EventArgs) Handles btnTab2_PRS.Click
        btnTab1_PAR.CssClass = "TabButton_InActive"
        btnTab2_PRS.CssClass = "TabButton_Active"
        btnTab3_PRI.CssClass = "TabButton_InActive"

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


        mvTabs.SetActiveView(vwTab2_PRS)
    End Sub
    Private Sub SelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAll.CheckedChanged
        If SelectAll.Checked = True Then
            DrpRC_PAR.Enabled = False
        Else
            DrpRC_PAR.Enabled = True
        End If
    End Sub

    Private Sub btnPreview_PAR_Click(sender As Object, e As EventArgs) Handles btnPreview_PAR.Click

        Session("Report") = "PAR"
        If SelectAll.Checked = False Then
            If DrpRC_PAR.SelectedItem.Text = "Select" Or drpYear_PAR.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = DrpRC_PAR.SelectedItem.Value
                Session("Month") = DrpMonth_PAR.SelectedItem.Value
                Session("CYear") = drpYear_PAR.SelectedItem.Value
            End If
        Else

            If drpYear_PAR.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = 0
                Session("Month") = DrpMonth_PAR.SelectedItem.Value
                Session("CYear") = drpYear_PAR.SelectedItem.Value
            End If

        End If


        Me.Page.Response.Redirect("~/MainReports/Summary_Reports.aspx")
    End Sub


    Private Sub cbAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked = True Then
            ddDepartment.Enabled = False
        Else
            ddDepartment.Enabled = True
        End If
    End Sub
    Private Sub btnPreview_PRS_Click(sender As Object, e As EventArgs) Handles btnPreview_PRS.Click
        Session("Report") = "PRS"

        If cbAll.Checked = False Then
            If ddDepartment.SelectedItem.Text = "Select" Or ddYear.SelectedItem.Text = "Select" Or ddPreparedBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = ddDepartment.SelectedItem.Value
                Session("Year") = ddYear.SelectedItem.Value
                Session("Month") = ddMonth.SelectedItem.Value
                Session("Status") = ddOption.SelectedItem.Value
                Session("PreparedBy") = ddPreparedBy.SelectedItem.Value

                'Me.Page.Response.Redirect("~/Reports and Query/rpt_ReturnedPPESummay.aspx")
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

            End If
        End If

        Me.Page.Response.Redirect("~/MainReports/Summary_Reports.aspx")
    End Sub


    Protected Sub btnTab3_PRI_Click(sender As Object, e As EventArgs) Handles btnTab3_PRI.Click
        btnTab1_PAR.CssClass = "TabButton_InActive"
        btnTab2_PRS.CssClass = "TabButton_InActive"
        btnTab3_PRI.CssClass = "TabButton_Active"

        DDyear1.DataSource = objDerived.GetDataTable("SELECT year FROM AMS.APP ORDER BY year DESC", CommandType.Text)
        DDyear1.DataTextField = "year"
        DDyear1.DataValueField = "year"
        DDyear1.DataBind()
        DDyear1.Items.Insert(0, "Select")

        DDdept.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
        DDdept.DataTextField = "RC_Name"
        DDdept.DataValueField = "RC_id"
        DDdept.DataBind()
        DDdept.Items.Insert(0, "Select")


        mvTabs.SetActiveView(vwTab3_RPI)
    End Sub
    Protected Sub CBALL1_CheckedChanged(sender As Object, e As EventArgs) Handles CBALL1.CheckedChanged
        If CBALL1.Checked = True Then
            DDdept.Enabled = False
        Else
            DDdept.Enabled = True
        End If
    End Sub
    Protected Sub BtnPreview3_Click(sender As Object, e As EventArgs) Handles BtnPreview3.Click
        Session("PAGE") = "RPRI"

        If CBALL1.Checked = False Then
            If DDdept.SelectedItem.Text = "Select" Or DDyear1.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = DDdept.SelectedItem.Value
                Session("Year") = DDyear1.SelectedItem.Value
                Session("Month") = DDmonth1.SelectedItem.Value

                'Me.Page.Response.Redirect("~/Reports and Query/rpt_ReturnedPPESummay.aspx")
            End If

        Else
            If DDyear1.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Complete all search option.")
            Else
                Session("RC_ID") = 0
                Session("Year") = DDyear1.SelectedItem.Value
                Session("Month") = DDmonth1.SelectedItem.Value

            End If
        End If

        Me.Page.Response.Redirect("~/MainReports/Summary_Reports.aspx")
    End Sub

End Class
