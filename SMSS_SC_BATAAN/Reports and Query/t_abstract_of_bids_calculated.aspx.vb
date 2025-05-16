Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_abstract_of_bids_calculated
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"

    Private Property dtAbstract() As DataTable
        Get
            Return CType(Session("dtAbstract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtAbstract") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            RadioButtonList1.SelectedItem.Value = 1
            LoadRBChoice()

            grdAbstract.DataSource = Nothing
            grdAbstract.DataBind()

            txtRefNumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchREF.ClientID & "')")
            txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadRBChoice()
    End Sub

    Protected Sub LoadRBChoice()
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                MultiView1.SetActiveView(View1)
                txtRefNumber.Text = ""

            Case 1
                MultiView1.SetActiveView(View3)
                ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM dbo.Supplier ORDER BY SuppName", CommandType.Text)
                ddSupplier.DataTextField = ("SuppName")
                ddSupplier.DataValueField = ("Supplier_Id")
                ddSupplier.DataBind()
                ddSupplier.Items.Insert(0, "Select")

            Case 2
                MultiView1.SetActiveView(View4)
                txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
                txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

        End Select
    End Sub

    Protected Sub btnSearchREF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchREF.Click
        LoadSearching()
    End Sub

    Protected Sub btnSearchSupp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchSupp.Click
        LoadSearching()
    End Sub

    Protected Sub btnByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByDate.Click
        LoadSearching()
    End Sub

    Protected Sub LoadSearching()
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                dtAbstract = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_BidsAbstract] WHERE project_reference_no LIKE '%" & txtRefNumber.Text & "%'", CommandType.Text)
                grdAbstract.DataSource = dtAbstract
                grdAbstract.DataBind()

            Case 1
                dtAbstract = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_BidsAbstract] WHERE Supplier_Id = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
                grdAbstract.DataSource = dtAbstract
                grdAbstract.DataBind()

            Case 2
                dtAbstract = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_BidsAbstract] WHERE opening_date BETWEEN '" & txtdatefrom.Text & "' AND '" & txtdateto.Text & "'", CommandType.Text)
                grdAbstract.DataSource = dtAbstract
                grdAbstract.DataBind()

        End Select
    End Sub

    Protected Sub ddSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddSupplier.SelectedIndexChanged

    End Sub

    Protected Sub grdAbstract_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAbstract.SelectedIndexChanged
        Session("isCalculated") = True
        Session("pre_procurement_hdr_id") = grdAbstract.SelectedDataKey("pre_procurement_hdr_id")
        'Me.Page.Response.Redirect("~/bidding/rpt_abstract_of_bids_calculated.aspx")


        Dim url As String = "rpt_abstract_of_bids_calculated.aspx"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
End Class
