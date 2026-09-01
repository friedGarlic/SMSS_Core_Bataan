Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control


Partial Class t_purchase_request
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


            dtPurchaseOrder = objDerived.GetDataTable("EXEC [AMS].[sp_PurchaseOrderList]", CommandType.Text)
            gvopen.DataSource = dtPurchaseOrder
            gvopen.DataBind()

            RadioButtonList1.SelectedIndex = 0
            LoadSearch()

            txtPONumber.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearchJEVNumber.ClientID & "')")
            txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")

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
            myview.RowFilter = "PO_No like '%" & replaceapostrophe(txtPONumber.Text) & "%'"

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            '==== PO DATE
            myview.RowFilter = "PO_Date >= '" & txtdatefrom.Text & "' And PO_Date <= '" & txtdateto.Text & "'"
        Else
            '==== DEPARTMENT
            myview.RowFilter = "RC_ID = '" & ddDepartment.SelectedItem.Value & "'"
        End If

        gvopen.DataSource = myview
        gvopen.DataBind()

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedIndex = 0 Then
            '==== PO NUMBER
            txtPONumber.Text = ""
            Me.MultiView1.SetActiveView(Me.View1)

        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            '==== PO DATE
            Me.txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.MultiView1.SetActiveView(Me.View4)

        Else
            '==== DEPARTMENT
            ddDepartment.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RespCenter_withFunctions] WHERE Function_ID = 86 ORDER BY RC_NAME", CommandType.Text)
            ddDepartment.DataTextField = ("RC_Name")
            ddDepartment.DataValueField = ("RC_ID")
            ddDepartment.DataBind()

            Me.MultiView1.SetActiveView(Me.View2)

        End If

    End Sub
    Protected Sub btnSearchJEVNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchJEVNumber.Click
        LoadSearch()
    End Sub

    Protected Sub btnByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByDate.Click
        LoadSearch()
    End Sub

    Protected Sub gvopen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvopen.SelectedIndexChanged
        Session("POHdr_ID") = gvopen.SelectedDataKey("POHdr_ID")
        Session("isGasoline") = False
        Session("Page") = "RQ"

        Me.Page.Response.Redirect("~/Procurement/rpt_purchase_order.aspx")
    End Sub

    Protected Sub btnSearchRC_Click(sender As Object, e As EventArgs) Handles btnSearchRC.Click
        LoadSearch()
    End Sub
End Class
