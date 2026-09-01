Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_order_of_payment
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"

    Private Property dtPayment() As DataTable
        Get
            Return CType(Session("dtPayment"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPayment") = value
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

    Protected Sub LoadRBChoice()
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                MultiView1.SetActiveView(View1)
                txtRefNumber.Text = ""

            Case 1
                MultiView1.SetActiveView(View4)
                txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
                txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

        End Select
    End Sub

    Protected Sub grdNotice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNotice.SelectedIndexChanged
        Session("Page") = "RQ"
        Session("pre_procurement_hdr_id") = grdNotice.SelectedDataKey("pre_procurement_hdr_id")
        Me.Page.Response.Redirect("~/bidding/rpt_order_of_payment.aspx")
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadRBChoice()
    End Sub

    Protected Sub btnSearchREF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchREF.Click
        LoadSearching()
    End Sub

    Protected Sub btnByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByDate.Click
        LoadSearching()
    End Sub

    Protected Sub LoadSearching()
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                dtPayment = objDerived.GetDataTable("SELECT * FROM AMS.pre_procurement WHERE project_reference_no LIKE '%" & txtRefNumber.Text & "%'", CommandType.Text)

            Case 1
                dtPayment = objDerived.GetDataTable("SELECT * FROM AMS.pre_procurement WHERE opening_date BETWEEN '" & txtdatefrom.Text & "' AND '" & txtdateto.Text & "'", CommandType.Text)

        End Select

        grdNotice.DataSource = dtPayment
        grdNotice.DataBind()
    End Sub
End Class
