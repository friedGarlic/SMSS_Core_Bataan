Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Web.UI

Partial Class Inventory_rpt_view_propertycard_v4
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Restore dropdown selections on a ?print=1 GET.  (These dropdowns
        ' do not currently affect the report build -- see notes -- but the
        ' persistence is preserved for future use.)
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

            ' Build the report FRESH in this same request via BuildReport().
            ' Do NOT try to read the object back from the viewer's ReportSource
            ' property -- with AutoDataBind="True" and a CrystalReportSource
            ' present, the getter does not return the ReportDocument we set,
            ' so TryCast(ReportSource, ReportDocument) yields Nothing and the
            ' branch would redirect instead of exporting.  BuildReport()
            ' returns a live document created in this request, so nothing
            ' crosses a request boundary.
            Dim rptPrint As ReportDocument = BuildReport()

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Records/PropertyCard_Rev.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "PropertyCard")

            Me.Page.Response.End()

        End If

    End Sub

    Private Function BuildReport() As ReportDocument
        Dim rpt As New ReportDocument()
        Dim reportPath As String = Server.MapPath("rpt_view_property_card_report.rpt")

        rpt.Load(reportPath)
        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt.SetParameterValue("@ClassificationID", Session("ClassificationID"))

        Return rpt
    End Function

    Private Sub LoadAndStoreReport()
        Dim rpt As ReportDocument = BuildReport()

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

            Response.Redirect("~/Records/PropertyCard_Rev.aspx", False)
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
            ' can restore them.  Only strings are stored -- never the
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

        ' On ?print=1, Page_Load builds the report fresh in-request via
        ' BuildReport() and exports it.  We must NOT bind the viewer from
        ' Session on a print request -- that would let a Session-sourced
        ' ReportDocument cross into the export path.
        If Request.QueryString("print") = "1" Then Exit Sub

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