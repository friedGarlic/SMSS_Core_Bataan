Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Records_rpt_propertycard
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    ' Page_Load is now intentionally empty.
    ' The report binding happens in Page_Init so the CrystalReportViewer
    ' can process pagination postbacks (Next Page, Previous Page, Print,
    ' Export) against the SAME report instance it is navigating with.
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Intentionally left blank.

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' On the very first request, build the report and stash it in Session.
        ' On every subsequent request (including pagination postbacks),
        ' pull the SAME instance from Session — this preserves page state.
        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_PropertyCard_Rev.rpt"))
            rpt.SetParameterValue("@GA_ID", Me.Session("GA_ID"))
            Session("PC_Report") = rpt

        Else

            rpt = CType(Session("PC_Report"), ReportDocument)

            ' Session may have expired or been lost — rebuild as fallback.
            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_PropertyCard_Rev.rpt"))
                rpt.SetParameterValue("@GA_ID", Me.Session("GA_ID"))
                Session("PC_Report") = rpt

            End If

        End If

        ' Re-apply database credentials on EVERY request.
        ' Crystal Reports drops the runtime logon across postbacks;
        ' re-applying here ensures no login prompt appears.
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        ' Bind BEFORE the viewer processes its view state.
        Me.PropertyCardReports.ReportSource = rpt

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        ' Intentionally left blank.
        ' The ReportDocument lives in Session and must NOT be disposed
        ' while the viewer still needs it for pagination.
    End Sub

    Protected Sub drpListofReport_SelectedIndexChanged(sender As Object, e As EventArgs)
        If drpListofReport.SelectedItem.Text = "Consolidated" Then
            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_PropertyCard.rpt"))
            rpt.SetParameterValue(0, Me.Session("Item_ID"))
            rpt.SetParameterValue(1, Me.Session("Donation_to_LGU"))
            Session("PC_Report") = rpt
        Else
            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_PropertyCard_Per_Item.rpt"))
            rpt.SetParameterValue("@Item_ID", Me.Session("Item_ID"))
            rpt.SetParameterValue("@status", Me.Session("Donation_to_LGU"))
            rpt.SetParameterValue("@property_no", Me.Session("Propertyno"))
            Session("PC_Report") = rpt
        End If

        ' Re-apply logon before binding (same reason as in Page_Load)
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.PropertyCardReports.ReportSource = rpt
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect("~/Records/PropertyCard_Rev.aspx")
    End Sub

    Private Sub Records_rpt_propertycard_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False

    End Sub
End Class
