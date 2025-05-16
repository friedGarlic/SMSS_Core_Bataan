Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Records_rpt_propertycard
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.PropertyCardReports.ReportSource = Me.CrystalReportSource1
        'Me.PropertyCardReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
        'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Item_ID", Session("Item_ID"))
        'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@status", Session("Donation_to_LGU"))


        rpt.FileName = Server.MapPath("rpt_PropertyCard.rpt")
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue(0, Me.Session("Item_ID"))
        rpt.SetParameterValue(1, Me.Session("Donation_to_LGU"))
        Me.PropertyCardReports.ReportSource = rpt


    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub
    Protected Sub drpListofReport_SelectedIndexChanged(sender As Object, e As EventArgs)
        If drpListofReport.selecteditem.text = "Consolidated" Then
            'Me.PropertyCardReports.ReportSource = Me.CrystalReportSource1
            'Me.PropertyCardReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Item_ID", Session("Item_ID"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@status", Session("Donation_to_LGU"))
            rpt.FileName = Server.MapPath("rpt_PropertyCard.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("Item_ID"))
            rpt.SetParameterValue(1, Me.Session("Donation_to_LGU"))
            Me.PropertyCardReports.ReportSource = rpt
        Else
            'Me.PropertyCardReports.ReportSource = Me.CrystalReportSource2
            'Me.PropertyCardReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Item_ID", Session("Item_ID"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@status", Session("Donation_to_LGU"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@property_no", Session("Propertyno"))
            rpt.FileName = Server.MapPath("rpt_PropertyCard_Per_Item.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue("@Item_ID", Me.Session("Item_ID"))
            rpt.SetParameterValue("@status", Me.Session("Donation_to_LGU"))
            rpt.SetParameterValue("@property_no", Me.Session("Propertyno"))
            Me.PropertyCardReports.ReportSource = rpt
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Records/PropertyCard_v4.aspx")
    End Sub

    Private Sub Records_rpt_propertycard_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
End Class
