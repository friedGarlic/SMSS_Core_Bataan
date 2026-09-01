Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class Reports_and_Query_t_BACResolution
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private pdtBAC As DataTable
    Public Property dtBAC() As DataTable
        Get
            Return pdtBAC
        End Get
        Set(ByVal value As DataTable)
            pdtBAC = value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadSearchOption()
            grdBAC.DataSource = Nothing
            grdBAC.DataBind()

        End If
    End Sub

    Protected Sub LoadSearchOption()
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                MultiView1.SetActiveView(View3)
                txtBACResolution.Text = ""

            Case 1
                MultiView1.SetActiveView(View1)
                txtRefNumber.Text = ""


            Case 2
                MultiView1.SetActiveView(View4)
                txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
                txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

        End Select
        
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadSearchOption()

        grdBAC.DataSource = Nothing
        grdBAC.DataBind()
    End Sub

    Protected Sub btnByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pdtBAC = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_BACResolution] WHERE NOA_Date BETWEEN '" & txtdatefrom.Text & "' AND '" & txtdateto.Text & "'", CommandType.Text)
        grdBAC.DataSource = pdtBAC
        grdBAC.DataBind()

    End Sub

    Protected Sub btnSearchBAC_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pdtBAC = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_BACResolution] WHERE resolution_number LIKE '%" & txtBACResolution.Text & "%'", CommandType.Text)
        grdBAC.DataSource = pdtBAC
        grdBAC.DataBind()

    End Sub

    Protected Sub btnSearchREF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pdtBAC = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RQ_BACResolution] WHERE ITB_No LIKE '%" & txtRefNumber.Text & "%'", CommandType.Text)
        grdBAC.DataSource = pdtBAC
        grdBAC.DataBind()

    End Sub

    Protected Sub grdBAC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("pre_procurement_hdr_id") = grdBAC.SelectedDataKey("pre_procurement_hdr_id")
        Session("Supplier_ID") = grdBAC.SelectedDataKey("Supplier_ID")
        Session("TotalBidAmount") = grdBAC.SelectedDataKey("Amount")

        'Dim url As String = "~/bidding/rpt_BACResolution.aspx?"
        'Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100');"
        'ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Me.Page.Response.Redirect("~/bidding/t_rpt_BACResolution.aspx")
    End Sub
End Class
