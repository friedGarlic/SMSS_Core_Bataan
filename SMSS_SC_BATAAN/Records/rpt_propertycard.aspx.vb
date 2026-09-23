Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class Records_rpt_propertycard
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("PC_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Records/PropertyCard_Rev.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "PropertyCard")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not IsPostBack Then

            rpt = New ReportDocument()
            rpt.Load(Server.MapPath("rpt_PropertyCard_Rev.rpt"))
            rpt.SetParameterValue("@GA_ID", Me.Session("GA_ID"))
            Session("PC_Report") = rpt

        Else

            rpt = CType(Session("PC_Report"), ReportDocument)

            If rpt Is Nothing Then

                rpt = New ReportDocument()
                rpt.Load(Server.MapPath("rpt_PropertyCard_Rev.rpt"))
                rpt.SetParameterValue("@GA_ID", Me.Session("GA_ID"))
                Session("PC_Report") = rpt

            End If

        End If

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        Me.PropertyCardReports.ReportSource = rpt

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

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