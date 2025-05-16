Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_Bidding_Infra_t_Infra_Reports
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "property"
    Private Property dtInfra() As DataTable
        Get
            Return CType(Session("dtInfra"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtInfra") = value
        End Set
    End Property
#End Region
#Region "DataTable"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_Hdr_ID", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("project_reference_no", GetType(String))
        dt.Columns.Add("project_name", GetType(String))
        dt.Columns.Add("Total_Amount", GetType(Decimal))
        dt.Columns.Add("IsVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_Hdr_ID") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("project_reference_no") = DBNull.Value
            dr("project_name") = DBNull.Value
            dr("Total_Amount") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btnBILL.CssClass = "Clicked"
            btnAbstract.CssClass = "Initial"
            btnResolution.CssClass = "Initial"
            btnNOA.CssClass = "Initial"
            btnNTP.CssClass = "Initial"

            LoadActiveView()
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub LoadActiveView()
        If btnBILL.CssClass = "Clicked" Then
            dtInfra = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Reports] 'BILL'", CommandType.Text)
            grdInfra.Columns(4).Visible = False

        ElseIf btnAbstract.CssClass = "Clicked" Then
            dtInfra = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Reports] 'ABSTRACT'", CommandType.Text)
            grdInfra.Columns(4).Visible = True

        ElseIf btnResolution.CssClass = "Clicked" Then
            dtInfra = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Reports] 'RESOLUTION'", CommandType.Text)
            grdInfra.Columns(4).Visible = True

        ElseIf btnNOA.CssClass = "Clicked" Then
            dtInfra = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Reports] 'NOA'", CommandType.Text)
            grdInfra.Columns(4).Visible = True

        ElseIf btnNTP.CssClass = "Clicked" Then
            dtInfra = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Reports] 'NTP'", CommandType.Text)
            grdInfra.Columns(4).Visible = True

        End If

        If dtInfra.Rows.Count < 10 Then
            dtInfra.Merge(CreateTable1(10 - dtInfra.Rows.Count))
        End If
        grdInfra.DataSource = dtInfra
        grdInfra.DataBind()

    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myview As DataView
        myview = dtInfra.DefaultView

        If ddSearch.SelectedItem.Text = "PR Number" Then
            myview.RowFilter = "pr_no like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        ElseIf ddSearch.SelectedItem.Text = "Project Name" Then
            myview.RowFilter = "project_name like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        ElseIf ddSearch.SelectedItem.Text = "ITB Number" Then
            myview.RowFilter = "ITBNumb like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        End If

        grdInfra.DataSource = myview
        grdInfra.DataBind()
    End Sub

    Protected Sub btnBILL_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnBILL.CssClass = "Clicked"
        btnAbstract.CssClass = "Initial"
        btnResolution.CssClass = "Initial"
        btnNOA.CssClass = "Initial"
        btnNTP.CssClass = "Initial"

        LoadActiveView()

    End Sub

    Protected Sub btnAbstract_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnBILL.CssClass = "Initial"
        btnAbstract.CssClass = "Clicked"
        btnResolution.CssClass = "Initial"
        btnNOA.CssClass = "Initial"
        btnNTP.CssClass = "Initial"

        LoadActiveView()

    End Sub

    Protected Sub btnResolution_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnBILL.CssClass = "Initial"
        btnAbstract.CssClass = "Initial"
        btnResolution.CssClass = "Clicked"
        btnNOA.CssClass = "Initial"
        btnNTP.CssClass = "Initial"

        LoadActiveView()

    End Sub

    Protected Sub btnNOA_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnBILL.CssClass = "Initial"
        btnAbstract.CssClass = "Initial"
        btnResolution.CssClass = "Initial"
        btnNOA.CssClass = "Clicked"
        btnNTP.CssClass = "Initial"

        LoadActiveView()

    End Sub

    Protected Sub btnNTP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnBILL.CssClass = "Initial"
        btnAbstract.CssClass = "Initial"
        btnResolution.CssClass = "Initial"
        btnNOA.CssClass = "Initial"
        btnNTP.CssClass = "Clicked"

        LoadActiveView()

    End Sub

    Protected Sub grdInfra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Infra_Hdr_ID") = grdInfra.SelectedDataKey("Infra_Hdr_ID")

        If btnBILL.CssClass = "Clicked" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Bill_Quantities.aspx")

        ElseIf btnAbstract.CssClass = "Clicked" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Abstract.aspx")

        ElseIf btnResolution.CssClass = "Clicked" Then
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Resolution.aspx")

        ElseIf btnNOA.CssClass = "Clicked" Then
            Session("Notice") = "NOA"
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Notice.aspx")

        ElseIf btnNTP.CssClass = "Clicked" Then
            Session("Notice") = "NTP"
            Me.Page.Response.Redirect("~/bidding/Bidding_Infra/rpt_Infra_Notice.aspx")

        End If

    End Sub
End Class
