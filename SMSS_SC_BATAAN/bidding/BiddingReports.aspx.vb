Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Partial Class MainReports_BiddingReports
    Inherits System.Web.UI.Page
    Private objDerived As New connectionreport
    Dim rpt_ITB_withPreBid As New ReportDocument
    Dim rpt_ITB_wOutPreBid As New ReportDocument
    Dim rpt_rpt_OP As New ReportDocument
    Dim rpt_rpt_BidForm As New ReportDocument

    Private Sub MainReports_BiddingReports_Init(sender As Object, e As EventArgs) Handles Me.Init
        LoadReports()

        rbPreProcReports.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    Private Sub MainReports_BiddingReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        'drpSupplier.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
        'drpSupplier.DataTextField = "SuppName"
        'drpSupplier.DataValueField = "Supplier_Id"
        'drpSupplier.DataBind()
        'drpSupplier.Items.Insert(0, "Select")

        'LoadReports()

        'rbPreProcReports.Attributes.Add("onChange", "StartProgressBar();")
    End Sub
    Protected Sub MainReports_BiddingReports_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        ' Code to execute during the Unload event
        rpt_ITB_withPreBid.Close()
        rpt_ITB_withPreBid.Dispose()

        rpt_ITB_wOutPreBid.Close()
        rpt_ITB_wOutPreBid.Dispose()

        rpt_rpt_OP.Close()
        rpt_rpt_OP.Dispose()

        rpt_rpt_BidForm.Close()
        rpt_rpt_BidForm.Dispose()
    End Sub
    Private Sub MainReports_BiddingReports_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Master.FindControl("MasterRowModules").Visible = False
        Master.FindControl("UserRow").Visible = False
        Master.FindControl("Menu1").Visible = False
    End Sub

    Protected Sub LoadReports()
        Me.BiddingReports.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None


        If Session("Page") = "ITB" Then
            rbPreProcReports.Visible = False

            If Session("Report") = "ITB with PreBid" Then

                'Me.BiddingReports.ReportSource = Me.CRS_withPreBid
                'Me.CRS_withPreBid.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CRS_withPreBid.ReportDocument.SetParameterValue("@ITB_Hdr_ID", Session("ITB_Hdr_ID"))

                If Session("ITB") = "Limited" Then
                    rpt_ITB_withPreBid.FileName = Server.MapPath("ITB_withPreBid_v2_Limited.rpt") '===== REPLACE LINE 02/18/2025 =====
                    rpt_ITB_withPreBid.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    rpt_ITB_withPreBid.SetParameterValue(0, Me.Session("ITB_Hdr_ID_Limited"))
                    Me.BiddingReports.ReportSource = rpt_ITB_withPreBid
                Else
                    rpt_ITB_withPreBid.FileName = Server.MapPath("ITB_withPreBid_v2.rpt") '===== REPLACE LINE 02/18/2025 =====
                    rpt_ITB_withPreBid.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    rpt_ITB_withPreBid.SetParameterValue(0, Me.Session("ITB_Hdr_ID"))
                    Me.BiddingReports.ReportSource = rpt_ITB_withPreBid
                End If


            Else
                'Me.BiddingReports.ReportSource = Me.CRS_wOutPreBid
                'Me.CRS_wOutPreBid.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CRS_wOutPreBid.ReportDocument.SetParameterValue("@ITB_Hdr_ID", Session("ITB_Hdr_ID"))

                If Session("ITB") = "Limited" Then
                    rpt_ITB_wOutPreBid.FileName = Server.MapPath("ITB_wOutPreBid_v2_Limited.rpt") '===== REPLACE LINE 02/18/2025 =====
                    rpt_ITB_wOutPreBid.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    rpt_ITB_wOutPreBid.SetParameterValue(0, Me.Session("ITB_Hdr_ID_Limited"))
                    Me.BiddingReports.ReportSource = rpt_ITB_wOutPreBid
                Else
                    rpt_ITB_wOutPreBid.FileName = Server.MapPath("ITB_wOutPreBid_v2.rpt") '===== REPLACE LINE 02/18/2025 =====
                    rpt_ITB_wOutPreBid.SetDatabaseLogon(objDerived.username, objDerived.Password)
                    rpt_ITB_wOutPreBid.SetParameterValue(0, Me.Session("ITB_Hdr_ID"))
                    Me.BiddingReports.ReportSource = rpt_ITB_wOutPreBid
                End If

            End If


        ElseIf Session("Page") = "PreProc" Then
            rbPreProcReports.Visible = True

            If Session("Report") = "OP" Then
                pnlOP.Visible = True

                drpSupplier.DataSource = objDerived.GetDataTable("SELECT Supplier_Id, SuppName FROM DBO.Supplier ORDER BY SuppName", CommandType.Text)
                drpSupplier.DataTextField = "SuppName"
                drpSupplier.DataValueField = "Supplier_Id"
                drpSupplier.DataBind()
                drpSupplier.Items.Insert(0, "Select")


                'Me.BiddingReports.ReportSource = Me.CRS_OP
                'Me.CRS_OP.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CRS_OP.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
                'Me.CRS_OP.ReportDocument.SetParameterValue("@SupplierID", Session("SupplierID"))


                rpt_rpt_OP.FileName = Server.MapPath("rpt_OP.rpt")
                rpt_rpt_OP.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_rpt_OP.SetParameterValue(0, Me.Session("TransID"))
                rpt_rpt_OP.SetParameterValue(1, Me.Session("SupplierID"))
                Me.BiddingReports.ReportSource = rpt_rpt_OP

            ElseIf Session("Report") = "BidForm" Then
                pnlOP.Visible = False

                'Me.BiddingReports.ReportSource = Me.CRS_BidForm
                'Me.CRS_BidForm.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CRS_BidForm.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))

                rpt_rpt_BidForm.FileName = Server.MapPath("rpt_BidForm.rpt")
                rpt_rpt_BidForm.SetDatabaseLogon(objDerived.username, objDerived.Password)
                rpt_rpt_BidForm.SetParameterValue(0, Me.Session("pre_procurement_hdr_id"))
                Me.BiddingReports.ReportSource = rpt_rpt_BidForm
            End If
        End If

    End Sub

    Private Sub rbPreProcReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbPreProcReports.SelectedIndexChanged
        If rbPreProcReports.SelectedItem.Value = 1 Then
            Session("Report") = "OP"
        ElseIf rbPreProcReports.SelectedItem.Value = 2 Then
            Session("Report") = "BidForm"
        End If

        LoadReports()
    End Sub


    Private Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        If Session("Page") = "ITB" Then
            If Session("Back") = "RQ" Then
                Me.Page.Response.Redirect("~/Reports and Query/RQ_ITBReports.aspx")
            Else
                Me.Page.Response.Redirect("~/bidding/Pre_Procurement.aspx")
            End If

        ElseIf Session("Page") = "PreProc" Then
            Me.Page.Response.Redirect("~/bidding/Pre_Procurement.aspx")
        End If

    End Sub

    Private Sub btnPreviewOP_Click(sender As Object, e As EventArgs) Handles btnPreviewOP.Click
        'Me.BiddingReports.ReportSource = Me.CRS_OP
        'Me.CRS_OP.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
        'Me.CRS_OP.ReportDocument.SetParameterValue("@pre_procurement_hdr_id", Session("pre_procurement_hdr_id"))
        'Me.CRS_OP.ReportDocument.SetParameterValue("@SupplierID", drpSupplier.SelectedItem.Value)

        rpt_rpt_OP.FileName = Server.MapPath("rpt_OP.rpt")
        rpt_rpt_OP.SetDatabaseLogon(objDerived.username, objDerived.Password)
        rpt_rpt_OP.SetParameterValue(0, Me.Session("TransID"))
        rpt_rpt_OP.SetParameterValue(1, Me.Session("SupplierID"))
        Me.BiddingReports.ReportSource = rpt_rpt_OP


    End Sub


End Class
