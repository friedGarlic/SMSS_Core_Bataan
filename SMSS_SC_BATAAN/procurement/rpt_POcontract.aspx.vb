Imports CrystalDecisions.CrystalReports.Engine

Partial Class procurement_rpt_POcontract
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Ensure Session variables are not null

        If Session("POHdr_ID") Is Nothing OrElse String.IsNullOrEmpty(Session("POHdr_ID").ToString()) Then
            Response.Write("Error: POHdr_ID is missing.")
            Exit Sub
        End If


        rpt.FileName = Server.MapPath("rpt_POcontract.rpt")
        Me.CrystalReportViewer1.ReportSource = rpt
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue("@pohdr_id", Session("POHdr_ID"))
        ' Load the report



    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("Page") = "ContractList" Then
            Me.Page.Response.Redirect("~/Procurement/rpt_poContractList.aspx")
        End If
        If Session("Page") = "PO" Then
                Me.Page.Response.Redirect("~/Procurement/t_Purchase_Order.aspx")
            Else
                Me.Page.Response.Redirect("~/Procurement/t_List_of_Approved_PO.aspx")
        End If


    End Sub
End Class
