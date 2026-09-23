Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class t_rpt_donation

    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Dim rpt As New ReportDocument


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Request.QueryString("print") = "1" Then


            Dim rptPrint As ReportDocument = CType(Session("Donation_Report"), ReportDocument)


            If rptPrint Is Nothing Then

                Me.Page.Response.Redirect("~/Inventory/Disposal/t_disposal_donation.aspx")

                Return

            End If


            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)


            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat,
                                          Me.Page.Response,
                                          False,
                                          "Donation")


            Me.Page.Response.End()


        End If


    End Sub



    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        If Not IsPostBack Then


            rpt = New ReportDocument()

            rpt.Load(Server.MapPath("rpt_Donation.rpt"))


            rpt.SetParameterValue(0, Me.Session("Disposal_Donation_hdr_id"))


            Session("Donation_Report") = rpt


        Else


            rpt = CType(Session("Donation_Report"), ReportDocument)


            If rpt Is Nothing Then


                rpt = New ReportDocument()

                rpt.Load(Server.MapPath("rpt_Donation.rpt"))


                rpt.SetParameterValue(0, Me.Session("Disposal_Donation_hdr_id"))


                Session("Donation_Report") = rpt


            End If


        End If



        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)


        Me.CrystalReportViewer1.ReportSource = rpt


    End Sub



    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click


        Me.Page.Response.Redirect("~/Inventory/Disposal/t_disposal_donation.aspx")


    End Sub



End Class