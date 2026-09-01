Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Class Reports_and_Query_t_rpt_receiving
    Inherits System.Web.UI.Page

    Private objDerived As New connectionreport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Moved report binding outside IsPostBack to handle zoom postbacks
        If Session("Received_ID") IsNot Nothing Then
            Try
                Dim rptDoc = CrystalReportSource1.ReportDocument
                rptDoc.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rptDoc.SetParameterValue("@Received_ID", Session("Received_ID"))

                CrystalReportViewer1.ReportSource = CrystalReportSource1
                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None

                ' Optional: Add trace for debugging (only on initial load to avoid too many logs)
                If Not IsPostBack Then
                    AddTrace(Session("Received_ID"))
                End If
            Catch ex As Exception
                Response.Write("Error loading report: " & ex.Message)
            End Try
        Else
            ' Only show error on initial load, not during zoom postbacks
            If Not IsPostBack Then
                Response.Write("Missing parameter: Received_ID.")
            End If
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        Select Case Convert.ToString(Session("Page"))
            Case "Rcv"
                Response.Redirect("~/procurement/t_Inspection_Acceptance.aspx")
            Case "PPE"
                Response.Redirect("~/Inventory/t_inventory_encoding.aspx")
            Case "Supplies"
                Response.Redirect("~/Inventory/t_encoding_supplies.aspx")
            Case "RQ"
                Response.Redirect("~/Procurement/t_receivingR.aspx")
            Case "Donation"
                Response.Redirect("~/Inventory/t_inventory_Donation.aspx")
        End Select
    End Sub

    Private Sub Reports_and_Query_t_rpt_receiving_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
            "TraceKey" & Guid.NewGuid().ToString("N"),
            "console.log('" & safeMessage & "');",
            True)
    End Sub

End Class