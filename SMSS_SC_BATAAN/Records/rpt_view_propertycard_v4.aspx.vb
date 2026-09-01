Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Web.UI

Partial Class Inventory_rpt_view_propertycard_v4
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("ClassificationID") Is Nothing Then
                Session("ClassificationID") = 0
            End If

            If Session("GA_ID") Is Nothing Then
                Session("GA_ID") = 0
            End If

            If Not IsPostBack Then
                LoadAndStoreReport()
            Else
                If Session("ReportDocument") IsNot Nothing Then
                    Dim rpt As ReportDocument = CType(Session("ReportDocument"), ReportDocument)
                    rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    rpt.SetParameterValue("@ClassificationID", Session("ClassificationID"))
                    Me.CrystalReportViewer1.ReportSource = rpt
                Else
                    LoadAndStoreReport()
                End If
            End If

        Catch ex As Exception
            MsgeBox.MessageBox(Nothing, "Something went wrong, please contact system admin.", Nothing)
        End Try
    End Sub

    Private Sub LoadAndStoreReport()
        Dim rpt As New ReportDocument()
        Dim reportPath As String = Server.MapPath("rpt_view_property_card_report.rpt")

        rpt.Load(reportPath)
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue("@ClassificationID", Session("ClassificationID"))

        Session("ReportDocument") = rpt
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

    Protected Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        Try
            If Session("ReportDocument") IsNot Nothing Then
                Dim rpt As ReportDocument = CType(Session("ReportDocument"), ReportDocument)
                rpt.Close()
                rpt.Dispose()
                Session.Remove("ReportDocument")
            End If

            Response.Redirect("~/Records/PropertyCard_v4.aspx", False)
            Context.ApplicationInstance.CompleteRequest()

        Catch ex As Exception
            ' MsgeBox.CreateMessageAlert("Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub ddReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddReport.SelectedIndexChanged
        Try
            If ddReport.SelectedValue = "0" Then
                ddMonth.Enabled = False
                drpYear.Enabled = False
                ddMonth.SelectedValue = "0"
            Else
                ddMonth.Enabled = True
                drpYear.Enabled = True
            End If

        Catch ex As Exception
            'MsgeBox.CreateMessageAlert("Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        Try
            If Session("ReportDocument") IsNot Nothing Then
                Dim oldRpt As ReportDocument = CType(Session("ReportDocument"), ReportDocument)
                oldRpt.Close()
                oldRpt.Dispose()
                Session.Remove("ReportDocument")
            End If

            LoadAndStoreReport()

        Catch ex As Exception
            ' MsgeBox.CreateMessageAlert("Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    End Sub
End Class