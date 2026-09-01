Imports System.Data
Partial Class MainReports_BiddingReports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub MainReports_BiddingReports_Init(sender As Object, e As EventArgs) Handles Me.Init
        LoadReports()

        rbPreProcReports.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    Private Sub MainReports_BiddingReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        'drpSupplier.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
        'drpSupplier.DataTextField = "SuppName"
        'drpSupplier.DataValueField = "Supplier_Id"
        'drpSupplier.DataBind()
        'drpSupplier.Items.Insert(0, "Select")

        'LoadReports()

        'rbPreProcReports.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    Private Sub MainReports_BiddingReports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Protected Sub LoadReports()
        Me.BiddingReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None


        If Session("Page") = "ITB" Then
            rbPreProcReports.Visible = False

            If Session("Report") = "ITB with PreBid" Then
                Me.BiddingReports.ReportSource = Me.CRS_withPreBid
                Me.CRS_withPreBid.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CRS_withPreBid.ReportDocument.SetParameterValue("@ITB_Hdr_ID", Session("ITB_Hdr_ID"))
            Else
                Me.BiddingReports.ReportSource = Me.CRS_wOutPreBid
                Me.CRS_wOutPreBid.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CRS_wOutPreBid.ReportDocument.SetParameterValue("@ITB_Hdr_ID", Session("ITB_Hdr_ID"))
            End If

        ElseIf Session("Page") = "PreProc" Then
            rbPreProcReports.Visible = True

            If Session("Report") = "OP" Then
                pnlOP.Visible = True

                drpSupplier.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
                drpSupplier.DataTextField = "SuppName"
                drpSupplier.DataValueField = "Supplier_Id"
                drpSupplier.DataBind()
                drpSupplier.Items.Insert(0, "Select")


                Me.BiddingReports.ReportSource = Me.CRS_OP
                Me.CRS_OP.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CRS_OP.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
                Me.CRS_OP.ReportDocument.SetParameterValue("@SupplierID", Session("SupplierID"))

            ElseIf Session("Report") = "BidForm" Then
                pnlOP.Visible = False

                Me.BiddingReports.ReportSource = Me.CRS_BidForm
                Me.CRS_BidForm.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                Me.CRS_BidForm.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
            End If
        End If

    End Sub

    Private Sub rbPreProcReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbPreProcReports.SelectedIndexChanged
        If rbPreProcReports.SelectedItem.Value = 1 Then
            Session("Report") = "OP"
        ElseIf rbPreProcReports.SelectedItem.Value = 2 Then
            Session("Report") = "BidForm"
        End If

        LoadReports()
    End Sub


    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "ITB" Then
            If Session("Back") = "RQ" Then
                Me.Page.Response.Redirect("~/Reports and Query/RQ_ITBReports.aspx")
            Else
                Me.Page.Response.Redirect("~/bidding/Pre_Procurement.aspx")
            End If

        ElseIf Session("Page") = "PreProc" Then
            Me.Page.Response.Redirect("~/bidding/Pre_Procurement.aspx")
        End If

    End Sub

    Private Sub btnPreviewOP_Click(sender As Object, e As EventArgs) Handles btnPreviewOP.Click
        Me.BiddingReports.ReportSource = Me.CRS_OP

        Me.CRS_OP.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        Me.CRS_OP.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
        Me.CRS_OP.ReportDocument.SetParameterValue("@SupplierID", drpSupplier.SelectedItem.Value)
    End Sub


End Class
