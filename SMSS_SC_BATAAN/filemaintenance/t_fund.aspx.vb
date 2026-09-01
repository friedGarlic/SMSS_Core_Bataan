Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class filemaintenance_t_fund
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim obj As New AccessRule

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ddActive.Items.Insert(0, "Select")

            LoadFundList()
            Session("Update_Fund") = "save"

        End If
    End Sub

    Protected Sub LoadFundList()
        Dim dtFund As New DataTable
        dtFund = objDerived.GetDataTable("SELECT * FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Fund ORDER BY Fund_Code", CommandType.Text)
        grdFunds.DataSource = dtFund
        grdFunds.DataBind()
    End Sub

    Protected Sub grdFunds_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Update_Fund") = "update"

        txtFund.Text = grdFunds.SelectedDataKey("Description")
        txtFund_Code.Text = grdFunds.SelectedDataKey("Fund_Code")

        Dim check_name As New DataTable()
        check_name = objDerived.GetDataTable("SELECT Description FROM LnkdSrvrBOSS.GEOBOS.BOS.Funds WHERE Description='" & grdFunds.SelectedDataKey("Description") & "'", CommandType.Text)

        If check_name.Rows.Count <> 0 Then
            ddActive.Enabled = False
        Else
            ddActive.Enabled = True
        End If

        btnSave.Text = "UPDATE FUND"

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If String.IsNullOrEmpty(txtFund.Text) Or String.IsNullOrEmpty(txtFund_Code.Text) Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up necessary fields.")
                Exit Sub
            Else
                If Session("Update_Fund") = "save" Then
                    objDerived.Execute("INSERT INTO [LnkdSrvrBOSS].[GeoBOS].[BOS].[m_Fund] ([Description], [Fund_Code]) VALUES('" &
                                       txtFund.Text & "', '" &
                                       txtFund_Code.Text & "')", CommandType.Text)

                    If ddActive.SelectedItem.Value = 1 Then
                        objDerived.Execute("INSERT INTO [LnkdSrvrBOSS].[GeoBOS].[BOS].[Funds] (Description, FundCode) VALUES('" &
                                           txtFund.Text & "', '" &
                                           txtFund_Code.Text & "')", CommandType.Text)
                    End If

                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                    loadRefresh()

                ElseIf Session("Update_Fund") = "update" Then
                    objDerived.Execute("UPDATE LnkdSrvrBOSS.GeoBOS.BOS.m_Fund SET Description='" &
                                       txtFund.Text & "', Fund_Code='" &
                                       txtFund_Code.Text & "' WHERE F_ID='" &
                                       grdFunds.SelectedDataKey("F_ID") & "'", CommandType.Text)
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully updated.")
                    loadRefresh()

                End If
            End If

            btnSave.Text = "SAVE FUND"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub loadRefresh()
        txtFund.Text = ""
        txtFund_Code.Text = ""
        ddActive.Items.Insert(0, "Select")
        LoadFundList()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Page.Response.Redirect("~/filemaintenance/t_fund.aspx")
    End Sub

    Protected Sub grdFunds_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim dtFund As New DataTable
        dtFund = objDerived.GetDataTable("SELECT * FROM LnkdSrvrBOSS.GEOBOS.BOS.m_Fund ORDER BY Fund_Code", CommandType.Text)
        grdFunds.DataSource = dtFund
        grdFunds.PageIndex = e.NewPageIndex
        grdFunds.DataBind()
    End Sub

End Class
