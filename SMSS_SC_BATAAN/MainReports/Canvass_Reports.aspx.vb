Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Partial Class MainReports_Canvass_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim obj As New AccessRule
    Dim rpt As New ReportDocument
    Private Sub MainReports_Canvass_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("Report") = "AOQ" Then
            lblTitle.Text = "ABSTRACT OF QUOTATION REPORT"

            divAOQ.Visible = True
            divCanvass.Visible = False

            'Me.ReportSource_AOQ.Report.FileName = "Canvass_AOQ.rpt"
            'Me.AOQReports.ReportSource = Me.ReportSource_AOQ
            'Me.ReportSource_AOQ.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.ReportSource_AOQ.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
            'Me.ReportSource_AOQ.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))


            Dim dbTotalBid As Double = objDerived.GetValue("Select min(total) As total from dbo.view_bid_amount where Hdr_ID = '" & Session("Hdr_ID_1") & "'", CommandType.Text)
            If dbTotalBid > 50001 Then
                Me.Session("Position") = objDerived.GetValue("SELECT TOP 1  UPPER(position_desc) FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND  position_desc = 'Governor' ORDER BY EmpID DESC", CommandType.Text)
                Me.Session("Approval") = objDerived.GetValue("SELECT TOP 1  Full_Name FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND  position_desc = 'Governor' ORDER BY EmpID DESC", CommandType.Text)
            Else
                Me.Session("Position") = objDerived.GetValue("SELECT TOP 1 UPPER(position_desc) FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND office_name in ('OFFICE OF THE PROVINCIAL GOVERNOR','OFFICE OF THE PROVINCIAL ADMINISTRATOR') ORDER BY EmpID DESC", CommandType.Text)
                Me.Session("Approval") = objDerived.GetValue("SELECT TOP 1 Full_Name FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND office_name in ('OFFICE OF THE PROVINCIAL GOVERNOR','OFFICE OF THE PROVINCIAL ADMINISTRATOR') ORDER BY EmpID DESC", CommandType.Text)
            End If



            rpt.FileName = Server.MapPath("Canvass_AOQ_Cagayan.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("prhdr_id"))
            rpt.SetParameterValue(1, Me.Session("Hdr_ID"))
            'rpt.SetParameterValue(2, Me.Session("Position"))
            'rpt.SetParameterValue(3, Me.Session("Approval"))


            Me.AOQReports.ReportSource = rpt



        ElseIf Session("Report") = "PRE_AOQ" Then
            lblTitle.Text = "ABSTRACT OF QUOTATION REPORT"

            divAOQ.Visible = True
            divCanvass.Visible = False

            'Me.ReportSource_AOQ.Report.FileName = "Canvass_AOQ.rpt"
            'Me.AOQReports.ReportSource = Me.ReportSource_AOQ
            'Me.ReportSource_AOQ.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.ReportSource_AOQ.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
            'Me.ReportSource_AOQ.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))


            Dim dbTotalBid As Double = objDerived.GetValue("Select min(total) As total from dbo.view_bid_amount where Hdr_ID = '" & Session("Hdr_ID_1") & "'", CommandType.Text)
            If dbTotalBid > 50001 Then
                Me.Session("Position") = objDerived.GetValue("SELECT TOP 1  UPPER(position_desc) FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND  position_desc = 'Governor' ORDER BY EmpID DESC", CommandType.Text)
                Me.Session("Approval") = objDerived.GetValue("SELECT TOP 1  Full_Name FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND  position_desc = 'Governor' ORDER BY EmpID DESC", CommandType.Text)
            Else
                Me.Session("Position") = objDerived.GetValue("SELECT TOP 1 UPPER(position_desc) FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND office_name in ('OFFICE OF THE PROVINCIAL GOVERNOR','OFFICE OF THE PROVINCIAL ADMINISTRATOR') ORDER BY EmpID DESC", CommandType.Text)
                Me.Session("Approval") = objDerived.GetValue("SELECT TOP 1 Full_Name FROM HRMS.view_signatory WHERE  division_key = 86 AND isActive = 1 AND isDeptHead = 'yes' AND office_name in ('OFFICE OF THE PROVINCIAL GOVERNOR','OFFICE OF THE PROVINCIAL ADMINISTRATOR') ORDER BY EmpID DESC", CommandType.Text)
            End If



            rpt.FileName = Server.MapPath("Canvass_PRE_AOQ_Cagayan.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("prhdr_id"))
            rpt.SetParameterValue(1, Me.Session("Hdr_ID"))
            'rpt.SetParameterValue(2, Me.Session("Position"))
            'rpt.SetParameterValue(3, Me.Session("Approval"))


            Me.AOQReports.ReportSource = rpt


        ElseIf Session("Report") = "RFQ" Then
            lblTitle.Text = "REQUEST FOR QUOTATION REPORT"

            divAOQ.Visible = False
            divCanvass.Visible = True

            'Me.CrystalReportSource1.Report.FileName = "RFQ.rpt"
            'Me.CanvassReport.ReportSource = Me.CrystalReportSource1
            'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))
            'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@isRecanvass", Session("isRecanvass"))


            rpt.FileName = Server.MapPath("RFQ.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("prhdr_id"))
            rpt.SetParameterValue(1, Me.Session("isRecanvass"))
            Me.CanvassReport.ReportSource = rpt

        ElseIf Session("Report") = "ROA" Then
            lblTitle.Text = "RESOLUTION OF AWARD REPORT"

            divAOQ.Visible = False
            divCanvass.Visible = True


            'Me.CrystalReportSource2.Report.FileName = "Canvass_Resolution.rpt"
            'Me.CanvassReport.ReportSource = Me.CrystalReportSource2
            'Me.CrystalReportSource2.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@Hdr_ID", Session("Hdr_ID"))
            'Me.CrystalReportSource2.ReportDocument.SetParameterValue("@prhdr_id", Session("prhdr_id"))


            rpt.FileName = Server.MapPath("Canvass_Resolution.rpt")
            rpt.SetDatabaseLogon(objDerived.username, objDerived.Password)
            rpt.SetParameterValue(0, Me.Session("Hdr_ID"))
            rpt.SetParameterValue(1, Me.Session("prhdr_id"))
            Me.CanvassReport.ReportSource = rpt
        Else

        End If
    End Sub
    Protected Sub MainReports_Canvass_Reports_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        rpt.Close()
        rpt.Dispose()
    End Sub
    Private Sub MainReports_Canvass_Reports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Private Sub LnkPrevious_Click(sender As Object, e As EventArgs) Handles LnkPrevious.Click
        If Session("Page") = "RQ" Then
            If Session("Report") = "AOQ" Then
                Me.Page.Response.Redirect("~/bidding/Abstract_CanvassR.aspx")
            ElseIf Session("Report") = "RFQ" Then
                Me.Page.Response.Redirect("~/bidding/RFQR.aspx")
            ElseIf Session("Report") = "ROA" Then
                Me.Page.Response.Redirect("~/bidding/RQ_CanvassAwardsR.aspx")
            End If
        ElseIf Session("Page") = "BID" Then
            If Session("Report") = "ROA" Then
                Me.Page.Response.Redirect("~/bidding/t_CanvassAwards.aspx")
            ElseIf Session("Report") = "AOQ" Then
                Me.Page.Response.Redirect("~/bidding/t_abstract_of_canvass.aspx")
            End If


        End If

    End Sub
End Class
