Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class Inventory_Property_Acknowledgement_Receipt_Report
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

            grdAcnkReceipt.DataSource = Nothing
            grdAcnkReceipt.DataBind()

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
                MultiView1.SetActiveView(View3)
                ddSupplier.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory ORDER BY Full_Name", CommandType.Text)
                ddSupplier.DataTextField = ("full_name")
                ddSupplier.DataValueField = ("empid")
                ddSupplier.DataBind()
                ddSupplier.Items.Insert(0, "Select")

            Case 2
                MultiView1.SetActiveView(View4)
                txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
                txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

        End Select
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadRBChoice()
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
                dtAbstract = objDerived.GetDataTable("SELECT * FROM [AMS].[View_Property_Acknowledgement_Receipt] WHERE MRENumber LIKE '%" & txtRefNumber.Text & "%'", CommandType.Text)
                grdAcnkReceipt.DataSource = dtAbstract
                grdAcnkReceipt.DataBind()

            Case 1
                dtAbstract = objDerived.GetDataTable("SELECT * FROM [AMS].[View_Property_Acknowledgement_Receipt] WHERE MRto = '" & ddSupplier.SelectedItem.Value & "'", CommandType.Text)
                grdAcnkReceipt.DataSource = dtAbstract
                grdAcnkReceipt.DataBind()

            Case 2
                dtAbstract = objDerived.GetDataTable("SELECT * FROM [AMS].[View_Property_Acknowledgement_Receipt] WHERE MRE_Date_Recieve BETWEEN '" & txtdatefrom.Text & "' AND '" & txtdateto.Text & "'", CommandType.Text)
                grdAcnkReceipt.DataSource = dtAbstract
                grdAcnkReceipt.DataBind()
        End Select
    End Sub
    Protected Sub grdAbstract_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAcnkReceipt.SelectedIndexChanged
        Session("MRENumber") = grdAcnkReceipt.SelectedDataKey("MRENumber")
        Me.Page.Response.Redirect("~/Reports and Query/rpt_Property_Acknowledgement_Receipt_Report.aspx")
    End Sub
End Class
