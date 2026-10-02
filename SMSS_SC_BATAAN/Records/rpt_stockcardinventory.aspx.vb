Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class rpt_stockcardinventory
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private rptDerived As New connectionreport



    Private Sub rpt_stockcardinventory_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim reportOK As Boolean = False

        Try

            If Not Page.IsPostBack Then
                drpYear.DataSource = objDerived.GetDataTable("SELECT DISTINCT Year FROM AMS.APP WHERE STATUS <> 3 ORDER BY Year DESC", CommandType.Text)
                drpYear.DataTextField = ("Year")
                drpYear.DataValueField = ("Year")
                drpYear.DataBind()

            End If

            ' On a ?print=1 GET the filter dropdowns reset to their defaults.
            ' Restore the user's last-selected values from Session so the
            ' correct report is rebuilt on this same request.
            If Request.QueryString("print") = "1" Then
                If Session("StockCardInventory_Report") IsNot Nothing Then
                    Try
                        ddReport.SelectedValue = Session("StockCardInventory_Report").ToString()
                    Catch
                    End Try
                End If
                If Session("StockCardInventory_Month") IsNot Nothing Then
                    Try
                        ddMonth.SelectedValue = Session("StockCardInventory_Month").ToString()
                    Catch
                    End Try
                End If
                If Session("StockCardInventory_Year") IsNot Nothing Then
                    Try
                        drpYear.SelectedValue = Session("StockCardInventory_Year").ToString()
                    Catch
                    End Try
                End If
            End If

            AddTrace("drpYear: " & drpYear.SelectedValue)
            AddTrace("ddMonth: " & ddMonth.SelectedValue)
            AddTrace("ddReport: " & ddReport.SelectedValue)


            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)

            reportOK = True

        Catch ex As Exception
            MsgeBox.MessageBox(Nothing, "Something went wrong, please contact system admin.", Nothing)


        End Try

        ' PDF export path -- placed OUTSIDE the Try/Catch so the
        ' ThreadAbortException raised by Response.End() is not caught by the
        ' Catch block above.  The report was just built IN THIS SAME REQUEST
        ' by the Try block, so CrystalReportSource1.ReportDocument is live
        ' and can be exported directly.  Nothing crosses a request boundary.
        If Request.QueryString("print") = "1" Then

            If Not reportOK Then
                Me.Page.Response.Redirect("~/Records/t_StockCard_Rev_Main.aspx")
                Return
            End If

            Dim rptPrint As ReportDocument = Me.CrystalReportSource1.ReportDocument

            If rptPrint Is Nothing Then
                Me.Page.Response.Redirect("~/Records/t_StockCard_Rev_Main.aspx")
                Return
            End If

            rptPrint.SetDatabaseLogon(rptDerived.username, rptDerived.Password)

            rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Me.Page.Response, False, "StockCardInventory")

            Me.Page.Response.End()

        End If

    End Sub

    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs)
        Try
            ' Persist the current filter selections so the ?print=1 request can
            ' restore them and rebuild the report with the same parameters.
            Session("StockCardInventory_Report") = ddReport.SelectedItem.Value
            Session("StockCardInventory_Month") = ddMonth.SelectedItem.Value
            Session("StockCardInventory_Year") = drpYear.SelectedItem.Value

            Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None
            Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
            Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(rptDerived.username, rptDerived.Password)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@CY", drpYear.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", ddMonth.SelectedItem.Value)
            Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Report", ddReport.SelectedItem.Value)
        Catch ex As Exception
            MsgeBox.MessageBox(Nothing, "Something went wrong, please contact system admin.", Nothing)
        End Try
    End Sub

    Protected Sub ddReport_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If ddReport.SelectedItem.Value = 0 Then
                ddMonth.Enabled = False
                drpYear.Enabled = False
                ddMonth.SelectedItem.Value = 0

            Else
                ddMonth.Enabled = True
                drpYear.Enabled = True
            End If
        Catch ex As Exception
            MsgeBox.MessageBox(Nothing, "something went wrong, please contact system admin.", Nothing)


        End Try
    End Sub




    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click

        Me.Page.Response.Redirect("~/Records/t_StockCard_Rev_Main.aspx")

    End Sub


    Private Sub AddTrace(ByVal message As String)
        ' On a print request the response is already being aborted by
        ' Response.End(); registering scripts would be a no-op anyway.
        If Request.QueryString("print") = "1" Then Exit Sub

        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

End Class