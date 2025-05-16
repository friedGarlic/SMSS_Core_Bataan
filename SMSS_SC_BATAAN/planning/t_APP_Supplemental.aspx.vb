Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class planning_t_APP_Supplemental
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim app As New t_annual_procurement_plan_hdr
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

#Region "Property"
    Private Property dtAPP() As DataTable
        Get
            Return CType(Session("dtAPP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAPP") = value
        End Set
    End Property

    Private Property dtOOE() As DataTable
        Get
            Return CType(Session("dtOOE"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtOOE") = value
        End Set
    End Property

    Private Property dtPPA() As DataTable
        Get
            Return CType(Session("dtPPA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPPA") = value
        End Set
    End Property
#End Region
#Region "Tables"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("AppropriationSource_ID", GetType(Long))
        dt.Columns.Add("AppropriationSource_Desc", GetType(String))
        dt.Columns.Add("AppropriationType_ID", GetType(Long))
        dt.Columns.Add("Budget_Year", GetType(Short))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("AppropriationSource_ID") = DBNull.Value
            dr("AppropriationSource_Desc") = DBNull.Value
            dr("AppropriationType_ID") = DBNull.Value
            dr("Budget_Year") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            dtAPP = objDerived.GetDataTable("EXEC [AMS].[sp_APP_Supplemental] '" & Year(txtDate.Text) & "'", CommandType.Text)
            If dtAPP.Rows.Count < 5 Then
                dtAPP.Merge(createdatatable1(5 - dtAPP.Rows.Count))
            End If
            grdAppSupp.DataSource = dtAPP
            grdAppSupp.DataBind()
        End If

    End Sub

    Protected Sub grdAppSupp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        dtAPP = objDerived.GetDataTable("EXEC [AMS].[sp_APP_Supplemental] '" & Year(txtDate.Text) & "'", CommandType.Text)
        grdAppSupp.PageIndex = e.NewPageIndex
        grdAppSupp.DataSource = dtAPP
        grdAppSupp.DataBind()
    End Sub

    Protected Sub grdAppSupp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        dtOOE = objDerived.GetDataTable("EXEC [AMS].[sp_Supplemental_PPMP_List] '" & grdAppSupp.SelectedDataKey("Budget_Year") & "','" & grdAppSupp.SelectedDataKey("AppropriationSource_ID") & "', 0", CommandType.Text)
        gvppmp.DataSource = dtOOE
        gvppmp.DataBind()

        dtPPA = objDerived.GetDataTable("EXEC [AMS].[sp_Supplemental_PPMP_List] '" & grdAppSupp.SelectedDataKey("Budget_Year") & "','" & grdAppSupp.SelectedDataKey("AppropriationSource_ID") & "', 1", CommandType.Text)
        gvPPA.DataSource = dtPPA
        gvPPA.DataBind()


        'dtOOE = objDerived.GetDataTable("exec AMS.APP_PPMP_List '" & grdAppSupp.SelectedDataKey("Budget_Year") & "', 1", CommandType.Text)
        'gvppmp.DataSource = dtOOE
        'gvppmp.DataBind()

        'dtPPA = objDerived.GetDataTable("exec [AMS].[APP_PPMP_List_PPA] '" & grdAppSupp.SelectedDataKey("Budget_Year") & "', 1", CommandType.Text)
        'gvPPA.DataSource = dtPPA
        'gvPPA.DataBind()
    End Sub
End Class
