Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Partial Class procurement_rpt_purchase_request_pop_up
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private objDer As New DerivedDal
    Dim rpt_PR As New ReportDocument
    Dim rpt_AIR As New ReportDocument

    Dim rpt_PerLot As New ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim isPerLot As Boolean = Convert.ToBoolean(objDer.GetValue("SELECT ISNULL(isPerLot, 0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text))

        Dim isDBM As Boolean = objDer.GetValue("SELECT ISNULL(isDBM,0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text)

        If isPerLot Then


            rpt_PR.FileName = Server.MapPath("~/MainReports/Procurement_PR_PerLot.rpt")
            rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt_PR.SetParameterValue(0, Me.Session("prhdr_id"))
            Me.CrystalReportViewer2.ReportSource = rpt_PR

            rdPRFormat.Visible = True

        Else

            If isDBM = False Then
                'Me.CrystalReportSource2.Report.FileName = "rpt_purchase_request_Short.rpt"
                'Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource2
                'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

                rpt_PR.FileName = Server.MapPath("rpt_purchase_request_Short_v1.rpt")
                rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_PR.SetParameterValue(0, Me.Session("prhdr_id"))
                Me.CrystalReportViewer2.ReportSource = rpt_PR


                rdPRFormat.Visible = True
            Else
                'Me.CrystalReportSource1.Report.FileName = "rpt_APR.rpt"
                'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))

                rpt_AIR.FileName = Server.MapPath("rpt_APR.rpt")
                rpt_AIR.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_AIR.SetParameterValue(0, Me.Session("prhdr_id"))
                Me.CrystalReportViewer1.ReportSource = rpt_PR


                rdPRFormat.Visible = False
            End If
        End If


    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt_PR.Close()
        rpt_PR.Dispose()

        rpt_AIR.Close()
        rpt_AIR.Dispose()

    End Sub

    Protected Sub rdPRFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdPRFormat.SelectedIndexChanged

        Dim isPerLot As Boolean = Convert.ToBoolean(objDer.GetValue("SELECT ISNULL(isPerLot, 0) FROM AMS.PR_Hdr WHERE prhdr_id = '" & Session("prhdr_id") & "'", CommandType.Text))

        If rdPRFormat.SelectedItem.Value = 1 Then
            'LONG BOND PAPER
            'CrystalReportSource1.Report.FileName = "rpt_purchase_request.rpt"
            'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("prhdr_id"))
            If isPerLot Then

                rpt_PR.FileName = Server.MapPath("~/MainReports/Procurement_PR_PerLot.rpt")
                rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_PR.SetParameterValue(0, Me.Session("prhdr_id"))
                Me.CrystalReportViewer2.ReportSource = rpt_PR

            Else
                rpt_PR.FileName = Server.MapPath("rpt_purchase_request_v2.rpt")
                rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_PR.SetParameterValue(0, Me.Session("prhdr_id"))
                Me.CrystalReportViewer2.ReportSource = rpt_PR

            End If


        ElseIf rdPRFormat.SelectedItem.Value = 2 Then
            'SHORT BOND PAPER
            'CrystalReportSource2.Report.FileName = "rpt_purchase_request_Short.rpt"
            'Me.CrystalReportViewer2.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue(0, Session("prhdr_id"))

            If isPerLot Then
                rpt_PR.FileName = Server.MapPath("~/MainReports/Procurement_PR_PerLot.rpt")
                rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_PR.SetParameterValue(0, Me.Session("prhdr_id"))
                Me.CrystalReportViewer2.ReportSource = rpt_PR
            Else
                rpt_PR.FileName = Server.MapPath("rpt_purchase_request_Short_v1.rpt")
                rpt_PR.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_PR.SetParameterValue(0, Me.Session("prhdr_id"))
                Me.CrystalReportViewer2.ReportSource = rpt_PR
            End If



        End If
    End Sub

End Class
