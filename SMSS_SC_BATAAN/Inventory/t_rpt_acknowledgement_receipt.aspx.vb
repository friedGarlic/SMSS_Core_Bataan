Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data

Partial Class t_rpt_acknowledgement_receipt
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Private rpt_PARE As New ReportDocument ' Declare ReportDocument Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("PARE_ReportType") = "Short" ' Default selection
        End If
        LoadReport() ' Ensure the report loads on every request
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
                    reportFileName = Server.MapPath("~/Inventory/PARE_Short.rpt")
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
            If rpt_PARE IsNot Nothing Then
                rpt_PARE.Close()
                rpt_PARE.Dispose()
            End If
        Catch ex As Exception
            ' Prevent any runtime exceptions from breaking the unload process
        End Try
    End Sub


End Class