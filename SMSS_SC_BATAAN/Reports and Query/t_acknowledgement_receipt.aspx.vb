Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control


Partial Class t_acknowledgement_receipt
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private prhdr As New t_purchase_request_hdr
    Private objMREHdr As New MREHdr

#Region "Property"

    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property

    Private Property dtARE() As DataTable
        Get
            Return CType(Session("dtARE"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtARE") = value
        End Set
    End Property

    Private Property popentrans() As DataTable
        Get
            Return CType(Session("popentrans"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popentrans") = value
        End Set
    End Property

    Private Property pFunction() As DataTable
        Get
            Return CType(Session("pFunction"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pFunction") = value
        End Set
    End Property

    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
        End Set
    End Property

    Private Property ListEmployee() As DataTable
        Get
            Return CType(Session("ListEmployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("ListEmployee") = value
        End Set
    End Property

#End Region


    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        LoadRdChoice()
    End Sub

    Protected Sub LoadRdChoice()

        Me.txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
        Me.txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")
        Select Case (RadioButtonList1.SelectedIndex)
            Case 0
                'popen = Nothing
                'gvemployee.DataSource = popen
                'gvemployee.DataBind()
                'popen = Nothing
                'gvopen.DataSource = popen
                'gvopen.DataBind()
                'popen = Nothing
                'gvaredate.DataSource = popen
                'gvaredate.DataBind()
                MultiView1.SetActiveView(View1)

            Case 1
                'popen = Nothing
                'gvemployee.DataSource = popen
                'gvemployee.DataBind()
                'popen = Nothing
                'gvopen.DataSource = popen
                'gvopen.DataBind()
                'popen = Nothing
                'gvaredate.DataSource = popen
                'gvaredate.DataBind()
                MultiView1.SetActiveView(View3)

            Case 2
                'popen = Nothing
                'gvemployee.DataSource = popen
                'gvemployee.DataBind()
                'popen = Nothing

                'gvopen.DataSource = popen
                'gvopen.DataBind()
                'popen = Nothing

                'gvaredate.DataSource = popen
                'gvaredate.DataBind()
                MultiView1.SetActiveView(View4)

            Case Else
                'popen = Nothing
                ''gvemployee.DataSource = popen
                ''gvemployee.DataBind()
                'popen = Nothing
                'gvopen.DataSource = popen
                'gvopen.DataBind()
                'popen = Nothing
                'gvaredate.DataSource = popen
                'gvaredate.DataBind()
                MultiView1.SetActiveView(View1)

        End Select

    End Sub

    Protected Sub btnSearchJEVNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchJEVNumber.Click
        Try
            Dim myview As DataView
            myview = dtARE.DefaultView
            myview.RowFilter = "RC_ID = '" & drpDept.SelectedItem.Value & "' AND Function_ID = '" & drpFunction.SelectedItem.Value & "'"
            grdARE.DataSource = myview
            grdARE.DataBind()

            'MultiView2.SetActiveView(View7)
            ''Dim prhdrID As Long = prhdr.save
            ''Session("PRNo") = objDerived.GetValue("exec [AMS].[prhdrid_ses] '" & Me.txtPRNumber.Text & "'", CommandType.Text)
            ''Me.Session("prhdr_id") = prhdrID
            'popen = objDerived.GetDataTable("exec [AMS].[sp_load_AcknowledgementReceipt_byDept]" & drpDept.SelectedItem.Value & ", " & drpFunction.SelectedItem.Value & "", CommandType.Text)
            'gvopen.DataSource = CType(popen, DataTable)
            'gvopen.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.txtdatefrom.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.txtdateto.Text = Date.Today.ToString("MM/dd/yyyy")

            pRC = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RespCenter_withFunctions] WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
            drpDept.DataSource = CType(pRC, DataTable)
            drpDept.DataTextField = ("RC_Name")
            drpDept.DataValueField = ("RC_ID")
            drpDept.DataBind()

            Session("Page") = "RQ"

            'gvopen.DataSource = Nothing
            'gvopen.DataBind()

            txtsearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnTransType.ClientID & "')")
            txtdatefrom.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")
            txtdateto.Attributes.Add("onkeypress", "return fun1(event,'" & btnByDate.ClientID & "')")

            dtARE = objDerived.GetDataTable("SELECT * FROM AMS.View_AREReports ORDER BY MRE_Date DESC", CommandType.Text)
            grdARE.DataSource = dtARE
            grdARE.DataBind()

        End If

    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Protected Sub btnTransType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTransType.Click
        Try

            Dim myview As DataView
            myview = dtARE.DefaultView
            myview.RowFilter = "FullName like '%" & replaceapostrophe(txtsearch.Text.ToString) & "%'"
            grdARE.DataSource = myview
            grdARE.DataBind()

            'Me.MultiView2.SetActiveView(Me.View2)
            ''=-= 08072015
            'Dim dtName As New DataTable
            'dtName = objDerived.GetDataTable("EXEC [AMS].[sp_load_AcknowledgementReceipt_byemployee] '" & txtsearch.Text & "'", CommandType.Text)
            'gvemployee.DataSource = dtName
            'gvemployee.DataBind()
            '=-= OLD
            'ListEmployee = objDerived.GetDataTable("exec [AMS].[sp_load_AcknowledgementReceipt_byemployee]", CommandType.Text)
            'gvemployee.DataSource = objDerived.Search(ListEmployee, drpemployee.SelectedItem.Value, txtsearch.Text)
            'gvemployee.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnByDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnByDate.Click
        Try

            Dim myview As DataView
            myview = dtARE.DefaultView
            myview.RowFilter = "MRE_Date >= '" & txtdatefrom.Text & "' AND MRE_Date <= '" & txtdateto.Text & "'"
            grdARE.DataSource = myview
            grdARE.DataBind()

            'MultiView2.SetActiveView(View6)
            'popen = objDerived.GetDataTable("Select * from AMS.vw_AREbydate where MRE_Date between '" & Me.txtdatefrom.Text & "' and '" & Me.txtdateto.Text & "' order by MRE_Date", CommandType.Text)
            'gvaredate.DataSource = CType(popen, DataTable)
            'gvaredate.DataBind()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub drpDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpDept.SelectedIndexChanged
        pFunction = Nothing
        'drpFunction.DataSource = pFunction
        'drpFunction.DataBind()
        'pFunction = objDerived.GetDataTable("exec ams.m_function " & drpDept.SelectedItem.Value & "", CommandType.Text)
        'drpFunction.DataSource = pFunction
        'drpFunction.DataTextField = ("Function_Desc")
        'drpFunction.DataValueField = ("Function_ID")
        'drpFunction.DataBind()

        pFunction = objDerived.GetDataTable("SELECT * FROM [dbo].[View_RespCenter_withFunctions] WHERE RC_ID = '" & drpDept.SelectedItem.Value & "'", CommandType.Text)
        drpFunction.DataSource = pFunction
        drpFunction.DataTextField = ("Function_Desc")
        drpFunction.DataValueField = ("Function_ID")
        drpFunction.DataBind()

        drpFunction.Enabled = True
    End Sub



    Protected Sub grdARE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("MREHdr_ID_1") = grdARE.SelectedDataKey("MREHdr_ID")
        Me.Page.Response.Redirect("~/Inventory/t_rpt_acknowledgement_receipt.aspx")
    End Sub

    Protected Sub grdARE_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)

        grdARE.DataSource = dtARE
        grdARE.PageIndex = e.NewPageIndex
        grdARE.DataBind()

    End Sub
End Class
