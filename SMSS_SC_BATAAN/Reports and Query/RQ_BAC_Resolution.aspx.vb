Imports System.Data

Partial Class Reports_and_Query_RQ_BAC_Resolution
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtReso() As DataTable
        Get
            Return CType(Session("dtReso"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtReso") = value
        End Set
    End Property

    Private Property dtAgency() As DataTable
        Get
            Return CType(Session("dtAgency"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAgency") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtReso = objDerived.GetDataTable("EXEC [AMS].[sp_BACResolution_ReportList]", CommandType.Text)
            grdBACReso.DataSource = dtReso
            grdBACReso.DataBind()

            dtAgency = objDerived.GetDataTable("SELECT	AMS.PR_Hdr.prhdr_id, AMS.m_Canvass_Hdr.DateApproved, AMS.m_Canvass_Hdr.Abstract_No AS BACResolution_No, AMS.PR_Hdr.pr_no, AMS.PR_Hdr.remarks  " &
                                                " FROM	AMS.m_Canvass_Hdr INNER JOIN AMS.PR_Hdr ON AMS.m_Canvass_Hdr.PR_Hdr_ID = AMS.PR_Hdr.prhdr_id " &
                                                " WHERE	AMS.m_Canvass_Hdr.isDBM = 1 AND AMS.m_Canvass_Hdr.isApproved = 1 AND AMS.PR_Hdr.IsApproved = 1 AND AMS.PR_Hdr.IsCancelled = 0 " &
                                                " ORDER BY AMS.m_Canvass_Hdr.DateApproved DESC, AMS.PR_Hdr.pr_no DESC", CommandType.Text)
            grdAgency.DataSource = dtAgency
            grdAgency.DataBind()


            '=== DEFAULT TAB ===
            btnTab1.CssClass = "TabButton_Active"
            btnTab2.CssClass = "TabButton_InActive"
            Me.mvTabs.SetActiveView(Me.vwTab1)

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        txtAgencySearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnAgencySearch.ClientID & "')")
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim myview As DataView
            myview = dtReso.DefaultView

            If drpSearch.SelectedItem.Value = 1 Then
                myview.RowFilter = "resolution_number like '%" & txtSearch.Text & "%'"
            ElseIf drpSearch.SelectedItem.Value = 2 Then
                myview.RowFilter = "pr_no like '%" & txtSearch.Text & "%'"
            End If

            grdBACReso.DataSource = myview
            grdBACReso.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdBACReso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBACReso.SelectedIndexChanged
        Session("pre_procurement_hdr_id") = grdBACReso.SelectedDataKey("pre_procurement_hdr_id")


        Dim id As Integer = objDerived.GetValue("SELECT BACResolution_ID FROM AMS.tb_BACResolution WHERE pre_procurement_hdr_id = " & Session("pre_procurement_hdr_id") & "", CommandType.Text)
        If id = 0 Then
            Me.Page.Response.Redirect("~/bidding/BACResolution_Report.aspx")
        Else
            Session("Page") = "RQ"
            Session("Report") = "BACReso"
            Session("ResponsiveBid") = grdBACReso.SelectedDataKey("ResponsiveCount")

            Me.Page.Response.Redirect("~/MainReports/Bidding_Reports.aspx")
        End If



    End Sub

    Protected Sub grdBACReso_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdBACReso.PageIndexChanging
        grdBACReso.PageIndex = e.NewPageIndex
        grdBACReso.DataSource = dtReso
        grdBACReso.DataBind()

    End Sub

    Protected Sub grdAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAgency.SelectedIndexChanged
        Session("prhdr_id") = grdAgency.SelectedDataKey("prhdr_id")
        Session("Page") = "RQ"
        Me.Page.Response.Redirect("~/MainReports/Agency_Reports.aspx")
    End Sub

    Protected Sub grdAgency_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdAgency.PageIndexChanging
        grdAgency.DataSource = dtAgency
        grdAgency.PageIndex = e.NewPageIndex
        grdAgency.DataBind()
    End Sub

    Protected Sub btnAgencySearch_Click(sender As Object, e As EventArgs) Handles btnAgencySearch.Click
        Dim myview As DataView
        myview = dtAgency.DefaultView

        If drpAgencySearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "pr_no like '%" & txtAgencySearch.Text & "%'"
        ElseIf drpAgencySearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "BACResolution_No like '%" & txtAgencySearch.Text & "%'"
        End If

        grdAgency.DataSource = myview
        grdAgency.DataBind()
    End Sub

    Protected Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        btnTab1.CssClass = "TabButton_Active"
        btnTab2.CssClass = "TabButton_InActive"

        Me.mvTabs.SetActiveView(Me.vwTab1)

    End Sub

    Protected Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        btnTab1.CssClass = "TabButton_InActive"
        btnTab2.CssClass = "TabButton_Active"

        Me.mvTabs.SetActiveView(Me.vwTab2)

    End Sub
End Class
