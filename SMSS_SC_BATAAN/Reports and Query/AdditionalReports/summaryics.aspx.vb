Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reports_and_Query_AdditionalReports_summaryics
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private obj As New connectionreport
    Dim rpt As New ReportDocument

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        ' On postback, if the user already pressed Preview, re-bind the
        ' cached report so the viewer keeps displaying it.  On a first-time
        ' visit the viewer stays empty until Preview is clicked.
        If IsPostBack Then

            rpt = CType(Session("SummaryICS_Report"), ReportDocument)

            If Not rpt Is Nothing Then

                rpt.SetDatabaseLogon(obj.username, obj.Password)

                Me.SummaryReports.ReportSource = rpt

            End If

        End If

    End Sub

    Private Sub Reports_and_Query_AdditionalReports_summaryics_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("SummaryICS_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Records/PropertyCard_Rev.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(obj.username, obj.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "SummaryICS")

            Me.Page.Response.End()

        End If

        If Not Page.IsPostBack Then
            drpYear.DataSource = objDerived.GetDataTable("SELECT * FROM AMS.APP WHERE status <> 3 ORDER BY YEAR DESC", CommandType.Text)
            drpYear.DataTextField = "year"
            drpYear.DataValueField = "year"
            drpYear.DataBind()

            drpPreparedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
            drpPreparedby.DataTextField = "Full_Name"
            drpPreparedby.DataValueField = "EmpID"
            drpPreparedby.DataBind()

            drpNotedby.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 7 ORDER BY Full_Name", CommandType.Text)
            drpNotedby.DataTextField = "Full_Name"
            drpNotedby.DataValueField = "EmpID"
            drpNotedby.DataBind()

        Else
            'LoadReportPreview()

        End If

    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        LoadReportPreview()
    End Sub

    Protected Sub LoadReportPreview()

        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("rpt_summaryics.rpt"))
        rpt.SetParameterValue("@Year", drpYear.SelectedItem.Value)
        rpt.SetParameterValue("@Month", drpMonths.SelectedItem.Value)
        rpt.SetParameterValue("@PreparedBy", drpPreparedby.SelectedItem.Value)
        rpt.SetParameterValue("@NotedBy", drpNotedby.SelectedItem.Value)
        rpt.SetDatabaseLogon(obj.username, obj.Password)
        Session("SummaryICS_Report") = rpt

        Me.SummaryReports.ReportSource = rpt

    End Sub
End Class