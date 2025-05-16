Imports System.Data

Partial Class procurement_rpt_poContractList
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"

    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property

    Private Property dtPurchaseOrder() As DataTable
        Get
            Return CType(Session("dtPurchaseOrder"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPurchaseOrder") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("Page") = "ContractList"

            dtPurchaseOrder = objDerived.GetDataTable("EXEC [AMS].[sp_PurchaseOrderList]", CommandType.Text)
            gvopen.DataSource = dtPurchaseOrder
            gvopen.DataBind()

            RadioButtonList1.SelectedIndex = 0
            LoadSearch()

            txtPONumber0.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchJEVNumber0.ClientID & "')")

        End If
    End Sub

    Protected Sub gvopen_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gvopen.DataSource = dtPurchaseOrder
        gvopen.PageIndex = e.NewPageIndex
        gvopen.DataBind()
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub LoadSearch()
        Dim myview As DataView
        myview = dtPurchaseOrder.DefaultView

        If RadioButtonList1.SelectedIndex = 0 Then
            '==== PO NUMBER
            myview.RowFilter = "PO_No like '%" & replaceapostrophe(txtPONumber0.Text) & "%'"

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            '==== DEPARTMENT
            myview.RowFilter = "PR_No like '%" & replaceapostrophe(txtPRNumber.Text) & "%'"

        Else
            '==== PO DATE
            myview.RowFilter = "SuppName like '%" & replaceapostrophe(txtSupplier.Text) & "%'"
        End If

        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then
            '==== PO NUMBER
            txtPONumber0.Text = ""
            Me.MultiView2.SetActiveView(Me.View5)

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            '==== PO DATE
            Me.txtPRNumber.Text = ""
            Me.MultiView2.SetActiveView(Me.View4)

        Else
            '==== DEPARTMENT
            Me.txtSupplier.Text = ""
            Me.MultiView2.SetActiveView(Me.View2)

        End If
    End Sub
    Protected Sub btnSearchJEVNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchJEVNumber0.Click
        LoadSearch()
    End Sub

    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvopen.SelectedIndexChanged

        Session("POHdr_ID") = gvopen.SelectedDataKey("POHdr_ID")

        Me.Page.Response.Redirect("~/Procurement/rpt_POcontract.aspx")
    End Sub

    Protected Sub btnPRSearch_Click(sender As Object, e As EventArgs) Handles btnPRSearch.Click
        LoadSearch()
    End Sub
    Protected Sub btnSupplierSearch_Click(sender As Object, e As EventArgs) Handles btnSupplierSearch.Click
        LoadSearch()
    End Sub
End Class
