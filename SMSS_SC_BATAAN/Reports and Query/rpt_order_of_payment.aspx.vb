Imports System.Data

Partial Class rpt_order_of_payment
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport

    Private Sub rpt_order_of_payment_Init(sender As Object, e As EventArgs) Handles Me.Init
        loadReport()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub
    Private Sub rpt_order_of_payment_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Protected Sub loadReport()
        If Session("Page") = "ISSP_List" Then
            Me.OrderPaymentReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            CrystalReportSource1.Report.FileName = "rpt_order_of_payment.rpt"
            Me.OrderPaymentReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@SuppName", Session("SuppName"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Amount", CType(Session("op1_Amt"), Decimal))

        ElseIf Session("Page") = "Auction" Then
            Me.OrderPaymentReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            CrystalReportSource1.Report.FileName = "rpt_order_of_payment.rpt"
            Me.OrderPaymentReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@SuppName", Session("SuppName"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Amount", CType(Session("Amount"), Decimal))

        ElseIf Session("Page") = "NOA" Then
            Me.OrderPaymentReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

            CrystalReportSource1.Report.FileName = "rpt_order_of_payment.rpt"
            Me.OrderPaymentReports.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@IsspHdr_ID", Session("IsspHdr_ID"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@SuppName", Session("SuppName"))
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Amount", CType(Session("Amount"), Decimal))

        End If



    End Sub

    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "ISSP_List" Then
            Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_ISSP_List.aspx")

        ElseIf Session("Page") = "Quotation" Then
            Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_Quotation.aspx")

        ElseIf Session("Page") = "NOA" Then
            Me.Page.Response.Redirect("~/Inventory/disposal/Disposal_Notice.aspx")

        End If
    End Sub

End Class
