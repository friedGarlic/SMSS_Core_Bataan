Imports CrystalDecisions.CrystalReports.Engine

Partial Class MainReports_Bidding_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt As New ReportDocument

    Private Sub MainReports_Bidding_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Report") = "BACReso" Then
            lblTitle.Text = "BAC RESOLUTION REPORT"

            Dim selectedVersion As String = ddlVersion.SelectedValue

            ' Set the base filename
            Dim baseFilename As String = "Bidding_BACResolution"

            ' Modify the filename based on the selected version
            If selectedVersion = "v1" Then
                If ViewState("rptFlag") = True Then
                    rpt.Close()
                    rpt.Dispose()


                    LoadReport("Bidding_BACResolution.rpt", Me.Session("pre_procurement_hdr_id"),
                               Session("b1"), Session("b2"), Session("b3"), Session("b4"), Session("b5"),
                               Session("bvc"), Session("bc"), Session("bApprove"), Session("txtBox"), 0)
                End If


            ElseIf selectedVersion = "v2" Then
                If ViewState("rptFlag") = True Then
                    rpt.Close()
                    rpt.Dispose()
                    LoadReport("Bidding_BACResolution_v1.rpt", Me.Session("pre_procurement_hdr_id"),
                               Session("b1"), Session("b2"), Session("b3"), Session("b4"), Session("b5"),
                               Session("bvc"), Session("bc"), Session("bApprove"), Session("txtBox"), 0)
                End If
            Else

                If ViewState("rptFlag") = True Then
                    rpt.Close()
                    rpt.Dispose()
                    LoadReport("Bidding_BACResolution.rpt", Me.Session("pre_procurement_hdr_id"),
                               Session("b1"), Session("b2"), Session("b3"), Session("b4"), Session("b5"),
                               Session("bvc"), Session("bc"), Session("bApprove"), Session("txtBox"), 0)

                    Return
                End If

                LoadReport("Bidding_BACResolution.rpt", Me.Session("pre_procurement_hdr_id"),
                               Session("b1"), Session("b2"), Session("b3"), Session("b4"), Session("b5"),
                               Session("bvc"), Session("bc"), Session("bApprove"), Session("txtBox"), 0)

            End If

        ElseIf Session("Report") = "----" Then

        End If
    End Sub

    Public Sub LoadReport(reportFileName As String,
                    parameterValue As Object, BAC1 As Object, BAC2 As Object, BAC3 As Object, BAC4 As Object, BAC5 As Object, BVC As Object, BCC As Object, BAPPROVAL As Object, txtBox As Object, parameterIndex As Integer)

        Dim rpt As New ReportDocument()

        rpt.Load(Server.MapPath(reportFileName))

        rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)

        rpt.SetParameterValue(parameterIndex, parameterValue)
        rpt.SetParameterValue("@BAC1", BAC1)
        rpt.SetParameterValue("@BAC2", BAC2)
        rpt.SetParameterValue("@BAC3", BAC3)
        rpt.SetParameterValue("@BAC4", BAC4)
        rpt.SetParameterValue("@BAC5", BAC5)
        rpt.SetParameterValue("@BVC", BVC)
        rpt.SetParameterValue("@BC", BCC)
        rpt.SetParameterValue("@BApprove", BAPPROVAL)
        rpt.SetParameterValue("@txtBox", txtBox)

        Me.BiddingReports.ReportSource = rpt

        ViewState("rptFlag") = True

    End Sub


    Private Sub MainReports_Bidding_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        If ViewState("rptFlag") = True Then
            rpt.Close()
            rpt.Dispose()
        End If


        If Session("Page") = "RQ" And Session("Report") = "BACReso" Then
            Me.Page.Response.Redirect("~/bidding/RQ_BAC_ResolutionR.aspx")
        End If
    End Sub



End Class
