Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Bidding_t_notice_to_proceed
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"

    Private Property dtNotice() As DataTable
        Get
            Return CType(Session("dtNotice"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNotice") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadRBChoice()

            grdNotice.DataSource = Nothing
            grdNotice.DataBind()

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
                dtNotice = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_NoticeProceed] WHERE project_reference_no LIKE '%" & txtRefNumber.Text & "%'", CommandType.Text)

            Case 1
                dtNotice = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_NoticeProceed] WHERE Supplier_ID = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)

            Case 2
                dtNotice = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_NoticeProceed] WHERE NTP_Date BETWEEN '" & txtdatefrom.Text & "' AND '" & txtdateto.Text & "'", CommandType.Text)

        End Select

        grdNotice.DataSource = dtNotice
        grdNotice.DataBind()
    End Sub

    Protected Sub grdNotice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNotice.SelectedIndexChanged
        Session("Page") = "RQ"
        Session("Bid_ID") = grdNotice.SelectedDataKey("Bid_ID")
        Me.Page.Response.Redirect("~/bidding/rpt_notice_to_proceed.aspx")

    End Sub
End Class
