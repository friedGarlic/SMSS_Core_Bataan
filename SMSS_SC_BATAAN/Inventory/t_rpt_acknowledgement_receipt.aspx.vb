Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Partial Class t_rpt_acknowledgement_receipt
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt_PARE As New ReportDocument ' Declare ReportDocument Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' When the page is opened with ?print=1, export the report that is
        ' already in Session to PDF and stream it straight to the browser.
        ' This replaces the normal HTML output so the report opens in the
        ' browser's PDF viewer, ready to print, with all pages included.
        If Request.QueryString("print") = "1" Then

            Dim rptPrint As ReportDocument = CType(Session("PARE_Report"), ReportDocument)

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect(GetBackUrl())
                Return
            End If

            rptPrint.SetDatabaseLogon(objDerived.username, objDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "AcknowledgementReceipt")

            Me.Page.Response.End()

        End If

        If Not IsPostBack Then
            Session("PARE_ReportType") = "Short" ' Default selection
        End If
        LoadReport() ' Ensure the report loads on every request
    End Sub

    Private Function GetBackUrl() As String
        If Request.UrlReferrer IsNot Nothing Then
            Return Request.UrlReferrer.ToString()
        End If
        Return "~/Default.aspx"
    End Function

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Me.Page.Response.Redirect(GetBackUrl())
    End Sub

    Protected Sub drpPaperSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpPaperSize.SelectedIndexChanged
        Session("PARE_ReportType") = drpPaperSize.SelectedValue ' Store selection in session
        LoadReport()
    End Sub

    Protected Sub LoadReport()
        Try
            AddTrace("LoadReport triggered.")

            ' Check if session contains MREHdr_ID
            If Session("MREHdr_ID_1") IsNot Nothing Then
                Dim MREHdr_ID As String = Session("MREHdr_ID_1").ToString()
                AddTrace("MREHdr_ID retrieved from Session: " & MREHdr_ID)

                ' Ensure Paper Size Selection Exists
                If drpPaperSize.SelectedItem IsNot Nothing Then
                    AddTrace("Selected Paper Size: " & drpPaperSize.SelectedItem.Text)
                Else
                    AddTrace("Warning: drpPaperSize.SelectedItem is NULL.")
                End If

                ' Load the appropriate Crystal Report
                Dim reportFileName As String

                ' Correct the file path based on the actual directory structure
                If drpPaperSize.SelectedItem.Text = "Short" Then
                    'reportFileName = Server.MapPath("~/Inventory/PARE_Short.rpt")
                    reportFileName = Server.MapPath("~/Inventory/rpt_PAR_v1.rpt")
                Else
                    reportFileName = Server.MapPath("~/Inventory/PARE_Long.rpt")
                End If

                ' Load the report
                rpt_PARE.Load(reportFileName)

                ' Apply Database Credentials
                rpt_PARE.SetDatabaseLogon(objDerived.username, objDerived.Password)

                ' Set the parameter value for the report
                rpt_PARE.SetParameterValue(0, MREHdr_ID) ' Use index-based parameter binding

                ' Assign the report to the viewer
                PARE_Reports.ReportSource = rpt_PARE
                PARE_Reports.DataBind()

                ' Store in Session so the ?print=1 request can export it.
                Session("PARE_Report") = rpt_PARE

                ' Log the resolved file path for debugging
                AddTrace("Resolved Report Path: " & reportFileName)

                ' Check if the file exists before attempting to load it
                If Not System.IO.File.Exists(reportFileName) Then
                    Throw New FileNotFoundException("Report file not found: " & reportFileName)
                End If

                AddTrace("Report successfully loaded and refreshed.")
            Else
                ' Log error if MREHdr_ID is missing
                AddTrace("Error: No MREHdr_ID provided in Session.")
                Response.Write("<script>alert('Error: No MREHdr_ID provided. Please try again.');</script>")
            End If
        Catch fileEx As FileNotFoundException
            ' Specific catch for file not found
            Dim errorMessage As String = "Report file not found: " & fileEx.Message
            AddTrace(errorMessage)
            ScriptManager.RegisterStartupScript(Me, GetType(String), "FILE_NOT_FOUND", "alert('" & errorMessage & "');", True)
        Catch ex As Exception
            ' Log the error details
            Dim errorMessage As String = "Error in LoadReport: " & ex.Message
            AddTrace(errorMessage)
            ScriptManager.RegisterStartupScript(Me, GetType(String), "LOAD_REPORT_ERROR", "alert('" & errorMessage & "');", True)
        End Try
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

    Private Sub t_rpt_acknowledgement_receipt_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            ' Keep the report alive in Session so the ?print=1 request can
            ' export it to PDF. Only dispose if it was never stored.
            If Session("PARE_Report") Is Nothing AndAlso rpt_PARE IsNot Nothing Then
                rpt_PARE.Close()
                rpt_PARE.Dispose()
            End If
        Catch ex As Exception
            ' Prevent any runtime exceptions from breaking the unload process
        End Try
    End Sub

End Class