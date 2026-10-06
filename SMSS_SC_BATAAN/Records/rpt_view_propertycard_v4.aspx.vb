Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Web.UI

Partial Class Inventory_rpt_view_propertycard_v4
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Restore dropdown selections on a ?print=1 GET.  This happens in
        ' Page_Load (not Page_Init) because ViewState/postback values are
        ' available only after the Load stage.
        If Request.QueryString("print") = "1" Then

            If Session("PropertyCard_Report") IsNot Nothing Then
                Try
                    ddReport.SelectedValue = Session("PropertyCard_Report").ToString()
                Catch
                End Try
            End If

            If Session("PropertyCard_Month") IsNot Nothing Then
                Try
                    ddMonth.SelectedValue = Session("PropertyCard_Month").ToString()
                Catch
                End Try
            End If

            If Session("PropertyCard_Year") IsNot Nothing Then
                Try
                    drpYear.SelectedValue = Session("PropertyCard_Year").ToString()
                Catch
                End Try
            End If

            Dim rptPrint As ReportDocument = TryCast(Me.CrystalReportViewer1.ReportSource, ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Records/PropertyCard_v4.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "PropertyCard")

            Me.Page.Response.End()

        End If

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

            ' Persist the current filter selections so the ?print=1 request
            ' can restore them and rebuild the report with the same
            ' parameters.  Only strings are stored -- never the
            ' ReportDocument itself.
            Session("PropertyCard_Report") = ddReport.SelectedItem.Value
            Session("PropertyCard_Month") = ddMonth.SelectedItem.Value
            Session("PropertyCard_Year") = drpYear.SelectedItem.Value

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


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Session("ClassificationID") Is Nothing Then
            Session("ClassificationID") = 0
        End If

        If Session("GA_ID") Is Nothing Then
            Session("GA_ID") = 0
        End If

        ' The CrystalReportViewer needs its ReportSource bound here, on every
        ' request, including the internal callbacks fired by its own toolbar
        ' (Next Page, Previous Page, Drill Down, Export, Zoom).  If ReportSource
        ' is only set in Page_Load, the viewer cannot resolve page navigation
        ' after the first render -- which is why only the first pages show.
        Try

            If Session("ReportDocument") IsNot Nothing Then
                Dim rpt As ReportDocument = CType(Session("ReportDocument"), ReportDocument)
                rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt.SetParameterValue("@ClassificationID", Session("ClassificationID"))
                Me.CrystalReportViewer1.ReportSource = rpt
            Else
                LoadAndStoreReport()
            End If

        Catch ex As Exception
            MsgeBox.MessageBox(Nothing, "Something went wrong, please contact system admin.", Nothing)
        End Try

    End Sub

End Class