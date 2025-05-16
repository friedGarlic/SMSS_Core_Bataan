Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Globalization


Partial Class procurement_t_purchase_request_gasoline
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Private prhdr As New t_purchase_request_hdr
    Private prdtl As New t_purchase_request_dtl
    Private pr_obr As New PR_OBR
    Private obr_hdr As New t_purchase_request_obr_hdr
    Private obr_dtl As New t_purchase_request_obr_dtl
    Private obr_Adjsutment_hdr As New t_purchase_request_obr_adjustment_hdr
    Private obr_Adjsutment_dtl As New t_purchase_request_obr_adjustment_dtl
    Private disbursement As New t_Purchase_request_disbursement
    Private pr_period_key As New t_pr_period_key
    Private invoice_hdr As New t_pr_invoice_hdr
    Private invoice_dtl As New t_pr_invoice_dtl
    Dim budget_data As DataTable

    'Private app As New AppHdr
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

    Private getprofile As New ProfileCommon

#Region "property"

    Private Property p_dataTotal() As DataTable
        Get
            Return CType(Session("p_dataTotal"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_dataTotal") = value
        End Set
    End Property

    Private Property p_datasummary() As DataTable
        Get
            Return CType(Session("p_datasummary"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_datasummary") = value
        End Set
    End Property
    Private Property p_SOA() As DataTable
        Get
            Return CType(Session("p_SOA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_SOA") = value
        End Set
    End Property



    Private Property p_pr_period_key() As DataTable
        Get
            Return CType(Session("p_pr_period_key"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_pr_period_key") = value
        End Set
    End Property


    Private Property p_GA_ID() As DataTable
        Get
            Return CType(Session("p_GA_ID"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_GA_ID") = value
        End Set
    End Property

    Private Property pGasolineGoods() As DataTable
        Get
            Return CType(Session("pGasolineGoods"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pGasolineGoods") = value
        End Set
    End Property

    Private Property pInvoice() As DataTable
        Get
            Return CType(Session("pInvoice"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pInvoice") = value
        End Set
    End Property

    Private Property pPeriod() As DataTable
        Get
            Return CType(Session("pPeriod"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPeriod") = value
        End Set
    End Property

    Private Property pOffice() As DataTable
        Get
            Return CType(Session("pOffice"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOffice") = value
        End Set
    End Property

    Private Property pOffice2() As DataTable
        Get
            Return CType(Session("pOffice2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOffice2") = value
        End Set
    End Property

    Private Property pEditInvoice() As DataTable
        Get
            Return CType(Session("pEditInvoice"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pEditInvoice") = value
        End Set
    End Property
    Private Property Lbtn() As String
        Get
            Return CType(Session("pLbtn"), String)
        End Get
        Set(ByVal value As String)
            Session("pLbtn") = value
        End Set
    End Property
    Private Property rc_ID() As String
        Get
            Return CType(Session("prc_ID"), String)
        End Get
        Set(ByVal value As String)
            Session("prc_ID") = value
        End Set
    End Property
    Private Property Function_ID() As String
        Get
            Return CType(Session("Function_ID"), String)
        End Get
        Set(ByVal value As String)
            Session("Function_ID") = value
        End Set
    End Property
    Private Property p_dataTotal1() As DataTable
        Get
            Return CType(Session("p_dataTotal1"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_dataTotal1") = value
        End Set
    End Property

    Private Property p_dataTotal2() As DataTable
        Get
            Return CType(Session("p_dataTotal2"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("p_dataTotal2") = value
        End Set
    End Property


    Private Property cbtbl() As DataTable
        Get
            Return CType(Session("cbtbl"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("cbtbl") = value
        End Set
    End Property
#End Region
#Region "functions"
    Public Function createDataTable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("rows_id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("qty", GetType(Decimal))
        dt.Columns.Add("cost", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("ReadOnly", GetType(Boolean))
        dt.Columns.Add("GA_ID", GetType(Integer))
        dt.Columns.Add("BGA_ID", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("rows_id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dr("qty") = "0.00"
            dr("cost") = "0.00"
            dr("Item_ID") = 0
            dr("isVisible") = False
            dr("ReadOnly") = True
            dr("GA_ID") = 0
            dr("BGA_ID") = 0
            dt.Rows.Add(dr)

          
        Next
        Return dt

    End Function
    Public Sub callEnableButton()

        If gvInvoice.FooterRow.Cells(2).Text = FormatNumber(pInvoice.Compute("sum(cost)", ""), 2) = "0.00" Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not Page.IsPostBack Then

                pInvoice = Nothing
                gvInvoice.DataSource = createDataTable(9)
                gvInvoice.DataBind()
                'RangeValidator1.MinimumValue = DateTime.Today.AddYears(-15).ToShortDateString()
                'RangeValidator1.MaximumValue = DateTime.Today.ToShortDateString()

                'RangeValidator2.MinimumValue = DateTime.Today.AddYears(-15).ToShortDateString()
                RangeValidator2.MaximumValue = DateTime.Today.ToShortDateString()
                'pGasolineGoods = objDerived.GetDataTable("[dbo].[getItem_gasoline_peritem]", CommandType.Text)
                pGasolineGoods = objDerived.GetDataTable("EXEC [AMS].[sp_GasolineItems]", CommandType.Text)
                pPeriod = objDerived.GetDataTable("Select * from AMS.pr_period_key where isClosed = 0", CommandType.text)
                DdPeriod.DataSource = pPeriod
                DdPeriod.DataTextField = "pr_period_key_desc"
                DdPeriod.DataValueField = "pr_period_key_id"
                DdPeriod.DataBind()
                gvitems.Columns(3).Visible = True
                gvitems.Columns(4).Visible = True
                gvitems.Columns(5).Visible = True
                gvitems.Columns(6).Visible = True
                gvitems.Columns(7).Visible = True
                gvitems.Columns(8).Visible = True

                gvitems.DataSource = pGasolineGoods
                gvitems.DataBind()

                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                gvitems.Columns(5).Visible = False
                gvitems.Columns(6).Visible = False
                gvitems.Columns(7).Visible = False
                gvitems.Columns(8).Visible = False

                pOffice = objDerived.GetDataTable("select * from dbo.view_pr_gas_office", CommandType.Text)
                pOffice2 = objDerived.GetDataTable("[ams].[gettop_rcvarious]", CommandType.Text)

                TabContainer1.ActiveTabIndex = 0
                GVoffices.DataSource = pOffice
                GVoffices.DataBind()

                GVvarious.DataSource = pOffice2
                GVvarious.DataBind()

                '======================================     
                p_pr_period_key = objDerived.GetDataTable("SELECT pr_period_key_id, pr_period_key_desc,date_to  FROM AMS.pr_period_key  WHERE isClosed = 0", CommandType.Text)
                'gvitems.Enabled = False

                If p_pr_period_key.Rows.Count >= 1 Then
                    DdPeriod.SelectedItem.Text = p_pr_period_key.Rows(0)("pr_period_key_desc")

                    Session("pr_period_key_id") = p_pr_period_key.Rows(0)("pr_period_key_id")
                    p_datasummary = objDerived.GetDataTable("select rc_name,total from ams.vw_pr_gasoline_summary_v2  where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)
                    gvSummary.DataSource = p_datasummary
                    gvSummary.DataBind()
                    p_SOA = objDerived.GetDataTable("Select SOA_No,amount from ams.SOA where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)
                    gvSOA.DataSource = p_SOA
                    gvSOA.DataBind()

                    p_dataTotal = objDerived.GetDataTable("select Invoice_No,rc_name,total,rc_id,function_id,pr_invoice_hdr_id,SOA_No from ams.vw_pr_gasoline_summary_invoice_dtl  where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "' order by pr_invoice_hdr_id", CommandType.Text)
                    If p_dataTotal.Rows.Count = 0 Then
                        Session("withOffices") = 0
                    Else
                        Session("withOffices") = 1
                    End If
                    gvTotal.DataSource = p_dataTotal
                    gvTotal.DataBind()

                    If p_dataTotal.Rows.Count >= 1 Then
                        gvTotal.FooterRow.Cells(5).Text = FormatNumber(p_dataTotal.Compute("sum(total)", ""), 2)
                    End If
                    lbPeriod.Enabled = True
                    btnCreatePR.Enabled = True
                    btnCreate.Enabled = True
                    If p_datasummary.Rows.Count >= 1 Then
                        gvSummary.FooterRow.Cells(1).Text = FormatNumber(p_datasummary.Compute("sum(total)", ""), 2)
                        gvSOA.FooterRow.Cells(1).Text = FormatNumber(p_SOA.Compute("sum(amount)", ""), 2)

                        btnCreatePR.Enabled = True
                    End If

                    txtInvoiceNumber.Text = objDerived.GetValue("SELECT TOP (1) Invoice_No  FROM  AMS.pr_invoice_hdr  ORDER BY pr_invoice_hdr_id DESC ", CommandType.Text) + 1
                    txtSOA.Text = objDerived.GetValue("SELECT TOP (1) SOA_No  FROM  AMS.pr_invoice_hdr  ORDER BY pr_invoice_hdr_id DESC ", CommandType.Text) + 1

                    Dim date_to As DateTime
                    date_to = p_pr_period_key.Rows(0)("date_to")
                    txtTo.Text = date_to.AddDays(1).ToShortDateString
                    txtFrom.Text = DateTime.Now.ToShortDateString

                    RangeValidator1.MinimumValue = "09/09/1900" 'date_to.ToShortDateString 'p_pr_period_key.Rows(0)("date_to").ToShortDateString
                    RangeValidator1.MaximumValue = "12/31/2099"  'Year(Date.Today.ToString("MM/dd/yyyy")) & "" 'DateTime.Now.ToShortDateString
                    RangeValidator2.MinimumValue = "09/09/1900"  'date_to.ToShortDateString
                    RangeValidator2.MaximumValue = "12/31/2099" '& Year(Date.Today.ToString("MM/dd/yyyy")) & "" 'DateTime.Now.ToShortDateString

                Else '===IF NO RECORDS
                    lbPeriod.Enabled = True
                    p_datasummary = Nothing
                    gvSummary.DataSource = p_datasummary
                    gvSummary.DataBind()

                    p_SOA = Nothing
                    gvSOA.DataSource = p_SOA
                    gvSOA.DataBind()

                    p_dataTotal = Nothing
                    gvTotal.DataSource = p_dataTotal
                    gvTotal.DataBind()
                    btnCreatePR.Enabled = False
                    btnCreate.Enabled = False


                    Dim date_to As DateTime
                    p_pr_period_key = objDerived.GetDataTable("Select TOP (1) pr_period_key_id, pr_period_key_desc, date_to FROM AMS.pr_period_key ORDER BY pr_period_key_id DESC", CommandType.Text)
                    If p_pr_period_key.Rows.Count = 0 Then
                        date_to = Date.Today.ToString("MM/dd/yyyy")
                        txtFrom.Text = date_to
                        txtTo.Text = date_to.AddDays(1).ToShortDateString
                    Else
                        date_to = p_pr_period_key.Rows(0)("date_to")
                        txtFrom.Text = date_to.AddDays(1).ToShortDateString 'DateTime.Now.ToShortDateString
                        txtTo.Text = date_to.AddDays(2).ToShortDateString
                    End If

                    txtInvoiceNumber.Text = objDerived.GetValue("Select TOP (1) Invoice_No  FROM  AMS.pr_invoice_hdr  ORDER BY pr_invoice_hdr_id DESC ", CommandType.Text) + 1
                    txtSOA.Text = objDerived.GetValue("Select TOP (1) SOA_No  FROM  AMS.pr_invoice_hdr  ORDER BY pr_invoice_hdr_id DESC ", CommandType.Text) + 1


                    RangeValidator1.MinimumValue = date_to
                    RangeValidator1.MaximumValue = "12/31/2099"

                    RangeValidator2.MinimumValue = date_to.AddDays(1).ToShortDateString
                    RangeValidator2.MaximumValue = "12/31/2099"

                End If

                If Me.TabContainer1.TabIndex = 0 Then
                    pOffice = objDerived.GetDataTable("Select * from dbo.view_pr_gas_office", CommandType.Text)

                Else
                    pOffice = objDerived.GetDataTable("Select * from ams.pr_gas_office_various", CommandType.Text)

                End If

                Me.GVoffices.DataSource = pOffice
                Me.GVoffices.DataBind()

                btnSave.Enabled = False
                cbVarious.Enabled = False
                ddOffice.Enabled = False
                btnPreview.Enabled = False
                p_dataTotal1 = Nothing

                '==== to search ====
                Drpyear.DataSource = objDerived.GetRecords("[ams].[getinvoice_date_year]", Data.CommandType.Text)
                Drpyear.DataTextField = "date_to"
                Drpyear.DataValueField = "date_to"
                Drpyear.DataBind()

                Drpmonth.Text = Month(Date.Today.ToString("MM/dd/yyyy"))
                gvListPR.DataSource = objDerived.GetRecords("[ams].[Get_date_from_gasoline] '" & Me.Drpmonth.Text & "','" & Me.Drpyear.Text & "'", CommandType.Text)
                gvListPR.DataBind()
            Else
                If Me.PopUP5.Visible = False Then
                    p_dataTotal1 = Nothing

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, False)
        End Try

    End Sub
    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'gvitems.Columns(3).Visible = True
        'gvitems.Columns(4).Visible = True
        'gvitems.Columns(5).Visible = True
        'gvitems.Columns(6).Visible = True
        'gvitems.Columns(7).Visible = True
        'gvitems.Columns(8).Visible = True
        For i As Integer = 3 To 8
            gvitems.Columns(i).Visible = True
        Next
        Me.gvitems.PageIndex = e.NewPageIndex
        Me.gvitems.DataSource = CType(pGasolineGoods, DataTable)
        Me.gvitems.DataBind()
        'gvitems.Columns(3).Visible = False
        'gvitems.Columns(4).Visible = False
        'gvitems.Columns(5).Visible = False
        'gvitems.Columns(6).Visible = False
        'gvitems.Columns(7).Visible = False
        'gvitems.Columns(8).Visible = False
        For i As Integer = 3 To 8
            gvitems.Columns(i).Visible = False
        Next

        ' ModalPopupExtender1.Show()
    End Sub



    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub

    'Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Try
    '        Dim sumObject As Integer
    '        gvitems.Columns(3).Visible = True
    '        gvitems.Columns(4).Visible = True
    '        gvitems.Columns(5).Visible = True
    '        gvitems.Columns(6).Visible = True
    '        gvitems.Columns(7).Visible = True
    '        gvitems.Columns(8).Visible = True
    '        Dim dt, dt_GA_ID As New DataTable
    '        Dim dr, dr_GA_ID As DataRow
    '        Dim cb As CheckBox





    '        If pInvoice Is Nothing Then
    '            dt.Columns.Add("id", GetType(Integer))
    '            dt.Columns.Add("Item_Desc", GetType(String))
    '            dt.Columns.Add("Description", GetType(String))
    '            dt.Columns.Add("qty")
    '            dt.Columns.Add("cost", GetType(Decimal))
    '            dt.Columns.Add("Item_ID", GetType(Integer))
    '            dt.Columns.Add("isVisible", GetType(Boolean))
    '            dt.Columns.Add("ReadOnly", GetType(Boolean))
    '            dt.Columns.Add("GA_ID", GetType(Integer))
    '            dt.Columns.Add("BGA_ID", GetType(Integer))

    '            dt_GA_ID.Columns.Add("GA_ID", GetType(Integer))
    '            dt_GA_ID.Columns.Add("BGA_ID", GetType(Integer))
    '            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
    '                cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
    '                If cb.Checked = True Then
    '                    dr = dt.NewRow
    '                    dr("id") = 1
    '                    dr("Item_Desc") = gvitems.Rows(i).Cells(1).Text
    '                    dr("Description") = gvitems.Rows(i).Cells(2).Text
    '                    dr("qty") = 0
    '                    dr("cost") = gvitems.Rows(i).Cells(5).Text ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
    '                    dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
    '                    dr("isVisible") = True
    '                    dr("ReadOnly") = False
    '                    dr("GA_ID") = gvitems.Rows(i).Cells(7).Text
    '                    dr("BGA_ID") = gvitems.Rows(i).Cells(8).Text

    '                    dt.Rows.Add(dr)




    '                    If p_GA_ID Is Nothing Then
    '                        dr_GA_ID = dt_GA_ID.NewRow
    '                        dr_GA_ID("GA_ID") = gvitems.Rows(i).Cells(7).Text
    '                        dr_GA_ID("BGA_ID") = gvitems.Rows(i).Cells(8).Text
    '                        dt_GA_ID.Rows.Add(dr_GA_ID)
    '                        p_GA_ID = dt_GA_ID
    '                    Else
    '                        Dim ds As New DataSet
    '                        Dim myview As DataView
    '                        myview = p_GA_ID.DefaultView
    '                        myview.RowFilter = " GA_ID = '" & (gvitems.Rows(i).Cells(7).Text) & "' and BGA_ID = '" & (gvitems.Rows(i).Cells(8).Text) & "'"
    '                        If myview.Count() = 0 Then
    '                            dt_GA_ID = p_GA_ID
    '                            dr_GA_ID = dt_GA_ID.NewRow
    '                            dr_GA_ID("GA_ID") = gvitems.Rows(i).Cells(7).Text
    '                            dr_GA_ID("BGA_ID") = gvitems.Rows(i).Cells(8).Text
    '                            dt_GA_ID.Rows.Add(dr_GA_ID)
    '                            p_GA_ID = dt_GA_ID
    '                        End If
    '                    End If

    '                End If
    '            Next
    '            pInvoice = dt
    '            sumObject = pInvoice.Compute("count(id)", "id=1")
    '            If sumObject <= 9 Then
    '                pInvoice.Merge(createDataTable(9 - sumObject))
    '            End If
    '            Me.Session("CurrentRowCount") = sumObject
    '        Else
    '            sumObject = pInvoice.Compute("count(id)", "id=1")
    '            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
    '                cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
    '                If cb.Checked = True Then
    '                    dt = pInvoice
    '                    dr = dt.NewRow
    '                    dr("id") = 1
    '                    dr("Item_Desc") = gvitems.Rows(i).Cells(1).Text
    '                    dr("Description") = gvitems.Rows(i).Cells(2).Text
    '                    dr("qty") = 0
    '                    dr("cost") = gvitems.Rows(i).Cells(5).Text ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
    '                    dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
    '                    dr("isVisible") = True
    '                    dr("ReadOnly") = False
    '                    dr("GA_ID") = gvitems.Rows(i).Cells(7).Text
    '                    dr("BGA_ID") = gvitems.Rows(i).Cells(8).Text
    '                    dt.Rows.Add(dr)
    '                    pInvoice = dt

    '                    '  dt_GA_ID.Columns.Add("GA_ID")
    '                    '  dt_GA_ID.Columns.Add("BGA_ID")
    '                    Dim ds As New DataSet
    '                    Dim myview As DataView
    '                    myview = p_GA_ID.DefaultView
    '                    myview.RowFilter = " GA_ID = '" & (gvitems.Rows(i).Cells(7).Text) & "' and BGA_ID = '" & (gvitems.Rows(i).Cells(8).Text) & "'"
    '                    If myview.Count() = 0 Then
    '                        dt_GA_ID = p_GA_ID
    '                        dr_GA_ID = dt_GA_ID.NewRow
    '                        dr_GA_ID("GA_ID") = gvitems.Rows(i).Cells(7).Text
    '                        dr_GA_ID("BGA_ID") = gvitems.Rows(i).Cells(8).Text
    '                        dt_GA_ID.Rows.Add(dr_GA_ID)
    '                        p_GA_ID = dt_GA_ID
    '                    End If
    '                End If
    '            Next
    '            If sumObject <= 9 Then
    '                For i As Integer = 0 To 10
    '                    If sumObject + i < 10 Then
    '                        pInvoice.Rows(9 - i).Delete()
    '                    Else
    '                        Exit For
    '                    End If
    '                Next
    '                'sumObject = 0
    '                sumObject = pInvoice.Compute("count(id)", "id=1")
    '                Me.Session("CurrentRowCount") = sumObject
    '                pInvoice.Merge(createDataTable(9 - sumObject))
    '            End If
    '        End If
    '        gvInvoice.DataSource = pInvoice
    '        gvInvoice.DataBind()
    '        Dim data As DataTable
    '        data = pGasolineGoods
    '        For i As Integer = 0 To Me.gvitems.Rows.Count - 1
    '            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
    '            If cb.Checked = True Then
    '                data.Rows(Me.gvitems.Rows(i).Cells(4).Text).Delete()
    '            End If
    '        Next
    '        pGasolineGoods = data
    '        gvitems.DataSource = pGasolineGoods
    '        gvitems.DataBind()
    '        gvitems.Columns(3).Visible = False
    '        gvitems.Columns(4).Visible = False
    '        gvitems.Columns(5).Visible = False
    '        gvitems.Columns(6).Visible = False
    '        gvitems.Columns(7).Visible = False
    '        gvitems.Columns(8).Visible = False

    '        '' ''If pInvoice.Compute("sum(total)", "") = "0.00" Then
    '        '' ''    CType(gvInvoice.FooterRow.Cells(3).FindControl("lblTotal"), Label).Text = "0.00"
    '        '' ''Else
    '        '' ''    CType(gvInvoice.FooterRow.Cells(3).FindControl("lblTotal"), Label).Text = FormatNumber(pInvoice.Compute("sum(total)", ""), 2)
    '        '' ''End If
    '        'msg.UserMsgBox(sumObject.ToString, Me, False)
    '        For i As Integer = 0 To pInvoice.Rows.Count - 1
    '            If i < sumObject Then
    '                Dim txtQty As TextBox = CType(gvInvoice.Rows(i).FindControl("txtqty"), TextBox)
    '                Dim txtPrice As TextBox = CType(gvInvoice.Rows(i).FindControl("txtprice"), TextBox)
    '                txtQty.ReadOnly = False
    '                txtQty.Attributes.Add("onFocus", "this.select()")
    '                txtQty.Attributes.Add("onClick", "this.select()")
    '                txtPrice.ReadOnly = False
    '                txtPrice.Attributes.Add("onFocus", "this.select()")
    '                txtPrice.Attributes.Add("onClick", "this.select()")

    '                'Else
    '                'CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
    '                'CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text = 0
    '            End If

    '        Next
    '        gvInvoice.FooterRow.Cells(2).Text = FormatNumber(pInvoice.Compute("sum(cost)", ""), 2)
    '        If gvInvoice.FooterRow.Cells(2).Text = "0.00" Then
    '            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvInvoice.Rows(0).Cells(1).FindControl("txtqty"), TextBox))
    '        Else
    '            ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvInvoice.Rows(sumObject - 1).Cells(1).FindControl("txtqty"), TextBox))
    '        End If
    '        cbVarious.Enabled = False
    '        ddOffice.Enabled = False
    '    Catch ex As Exception
    '        '   msg.UserMsgBox(ex.ToString, Me, False)
    '    End Try
    'End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPeriod.Click
        ddSupplier.DataSource = objDerived.GetRecords("select SuppName,Supplier_Id from dbo.supplier order by SuppName", CommandType.Text)
        ddSupplier.DataTextField = "SuppName"
        ddSupplier.DataValueField = "Supplier_Id"
        ddSupplier.DataBind()
        ModalPopupExtender4.Show()
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim prdStr As String
        Dim dtPeriod As Date
        Dim dtPeriod2 As New DataTable

        dtPeriod2 = objDerived.GetDataTable("Select * from AMS.pr_period_key", CommandType.Text)
        If dtPeriod2.Rows.Count = 0 Then
            If CType(txtFrom.Text, Date) > CType(txtTo.Text, Date) Then
                Button6.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Please check and adjust the date from.")
                ModalPopupExtender4.Show()
            End If
        Else
            dtPeriod = objDerived.GetValue("SELECT TOP (1) date_to FROM AMS.pr_period_key ORDER BY pr_period_key_id DESC", CommandType.Text)
            If txtFrom.Text >= txtTo.Text Then

                'Button6.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Please check and adjust the date from.")
                ModalPopupExtender4.Show()

                Exit Sub
            Else
            End If
        End If

        'If CType(txtFrom.Text, Date).Year = CType(txtTo.Text, Date).Year Then
        '    prdStr = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(CType(txtFrom.Text, Date).Month.ToString) & " " & CType(txtFrom.Text, Date).Day.ToString _
        '    & "-" & CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(CType(txtTo.Text, Date).Month.ToString) & " " & CType(txtTo.Text, Date).Day.ToString & "," & CType(txtTo.Text, Date).Year.ToString
        'Else
        '    prdStr = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(CType(txtFrom.Text, Date).Month.ToString) & " " & CType(txtFrom.Text, Date).Day.ToString & "," & CType(txtFrom.Text, Date).Year.ToString _
        '   & "-" & CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(CType(txtTo.Text, Date).Month.ToString) & " " & CType(txtTo.Text, Date).Day.ToString & "," & CType(txtTo.Text, Date).Year.ToString

        'End If
        'OPTIMIZE
        Dim fromDate As Date = Date.Parse(txtFrom.Text)
        Dim toDate As Date = Date.Parse(txtTo.Text)

        Dim fromStr As String = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(fromDate.Month) & " " & fromDate.Day.ToString & "," & fromDate.Year.ToString
        Dim toStr As String = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(toDate.Month) & " " & toDate.Day.ToString & "," & toDate.Year.ToString

        ' Dim prdStr As String

        If fromDate.Year = toDate.Year Then
            prdStr = String.Format("{0}-{1}", fromStr, toStr)
        Else
            prdStr = String.Format("{0}-{1}", fromStr, toStr)
        End If


        pr_period_key.pr_period_key_desc = prdStr
        pr_period_key.date_from = txtFrom.Text
        pr_period_key.date_to = txtTo.Text
        pr_period_key.isClosed = False
        pr_period_key.Supplier_Id = ddSupplier.SelectedItem.Value
        pr_period_key.save()
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Period date successfully saved.")
        p_pr_period_key = objDerived.GetDataTable("SELECT pr_period_key_id, pr_period_key_desc FROM AMS.pr_period_key WHERE isClosed = 0", CommandType.Text)
        DdPeriod.DataSource = p_pr_period_key
        DdPeriod.DataTextField = "pr_period_key_desc"
        DdPeriod.DataValueField = "pr_period_key_id"
        DdPeriod.DataBind()


        DdPeriod.SelectedItem.Text = p_pr_period_key.Rows(0)("pr_period_key_desc")
        Me.Session("pr_period_key_id") = p_pr_period_key.Rows(0)("pr_period_key_id")

        btnCreate.Enabled = True
        lbPeriod.Enabled = True

        Dim mx = objDerived.GetValue("Select Max(pr_period_key_id) as pr_period_key_id from AMS.pr_period_key where isClosed = 0", CommandType.Text)
        pPeriod = objDerived.GetDataTable("Select * from AMS.pr_period_key where isClosed = 0 and pr_period_key_id ='" & mx & "'", CommandType.Text)
        DdPeriod.DataSource = pPeriod
        DdPeriod.DataTextField = "pr_period_key_desc"
        DdPeriod.DataValueField = "pr_period_key_id"
        DdPeriod.DataBind()
    End Sub

    'Protected Sub cbVarious_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVarious.CheckedChanged
    '    If cbVarious.Checked = False Then
    '        pOffice = objDerived.GetDataTable("select * from ams.pr_gas_office", CommandType.Text)

    '    Else
    '        pOffice = objDerived.GetDataTable("select * from ams.pr_gas_office_various", CommandType.Text)
    '    End If
    '    ddOffice.Items.Clear()
    '    ddOffice.Items.Add("Select")
    '    ddOffice.DataSource = pOffice
    '    ddOffice.DataTextField = ("rc_name")
    '    ddOffice.DataValueField = ("rc_name")
    '    ddOffice.DataBind()
    'End Sub




    Protected Sub txtFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreatePR.Click
        Try

            If iswith_budget() = False Then
                Dim count As Integer
                count = budget_data.Rows.Count
                'msg.UserMsgBox(count.ToString + " Office/s don't have enough budget for this transaction. Please advice them to request for advance release.", Me, False)
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, count.ToString + " Office/s don't have enough budget for this transaction. Please advice them to request for advance release.")

                GridView1.DataSource = budget_data
                GridView1.DataBind()
                ModalPopupExtender1.Show()
                Exit Sub

            End If
            Me.Session("pr_period_key_id") = p_pr_period_key.Rows(0)("pr_period_key_id")
            Dim pr_hdr_data As DataTable = objDerived.GetDataTable("select * from ams.vw_pr_gasoline_hdr where pr_period_key_id=" & p_pr_period_key.Rows(0)("pr_period_key_id") & "", CommandType.Text)


            For i As Integer = 0 To pr_hdr_data.Rows.Count - 1
                Dim pr_invoice As DataTable = objDerived.GetDataTable("Select * from dbo.View_Invoice_PR where pr_period_key_id='" & Session("pr_period_key_id") & "' and rc_id='" & pr_hdr_data.Rows(i)("RC_ID") & "' and function_id='" & pr_hdr_data.Rows(i)("Function_ID") & "'", CommandType.Text)
                Session("pr_invoice_hdr_id") = pr_invoice.Rows(0)("pr_invoice_hdr_id")

                ''--------saving for pr hdr
                prhdr.PR_Year = Year(Date.Today.ToString("MM/dd/yyyy"))
                prhdr.PR_Date = "01/01/1900"
                prhdr.RC_ID = pr_hdr_data.Rows(i)("RC_ID")
                prhdr.Function_ID = pr_hdr_data.Rows(i)("Function_ID")
                prhdr.remarks = "Purchase of Gasoline for the period of " & Me.DdPeriod.SelectedItem.Text
                prhdr.Transaction_type = 2
                prhdr.Project_ID = 0
                prhdr.Program_id = 0
                prhdr.ABC = FormatNumber(pr_hdr_data.Rows(i)("total"), 2)
                prhdr.Requestedby = objDerived.GetValue("SELECT empID FROM dbo.view_EmployeeSignatories WHERE dept_id = " & pr_hdr_data.Rows(i)("RC_ID") & " AND isDeptHead = 1 AND func_id = " & pr_hdr_data.Rows(i)("Function_ID"), CommandType.Text) 'Department Head's EmpID
                prhdr.Approvedby = objDerived.GetValue("SELECT empID FROM dbo.view_CityMayor", CommandType.Text) ''objDerived.GetValue("SELECT empID FROM [GeoBOS].dbo.view_EmployeeSignatories WHERE dept_id = " & pr_hdr_data.Rows(i)("RC_ID") & " AND func_id = " & pr_hdr_data.Rows(i)("Function_ID"), CommandType.Text) 'Department Head's EmpID'objDerived.GetValue("SELECT empID FROM [GeoBOS].dbo.view_CityMayor", CommandType.Text) 'Mayor's EmpID
                prhdr.Date_Submitted = DateTime.Now
                prhdr.Date_gso_rcv = "01/01/1900"
                prhdr.IsCancelled = False
                prhdr.IsApproved = False
                prhdr.isOnBid = False
                prhdr.POHdr_ID = 0
                'prhdr.withOBR = False
                prhdr.withWinner = False
                prhdr.withPO = False
                prhdr.declarationDate = "01/01/1900"
                prhdr.rcv_date = "01/01/1900"
                prhdr.mode_of_procurement_id = 0
                prhdr.isPublicInfra = False
                prhdr.isStraight = False
                prhdr.DateApproved_PR_Mayor = "01/01/1900"
                prhdr.DateReceived_PR_Mayor = "01/01/1900"
                prhdr.isApproved_PR_Mayor = False
                prhdr.isReceived_PR_Mayor = False
                prhdr.DateDisApprove = "01/01/1900"
                prhdr.isGasoline = True
                prhdr.pr_period_key_id = Me.Session("pr_period_key_id")
                prhdr.pr_invoice_hdr_id = Session("pr_invoice_hdr_id")
                prhdr.isReimbursement = False
                prhdr.isContract = False
                prhdr.isEditable = False
                prhdr.isTrustFund = False
                prhdr.GA_ID = 794
                prhdr.UserID = Session("@UserName")

                Dim prhdrID As Long = prhdr.save
                Session("PRNo") = prhdrID

                objDerived.GetRecords("UPDATE AMS.PR_Hdr SET F_ID = 1 WHERE prhdr_id = '" & prhdrID & "'", CommandType.Text)

                '===== PR detail saving ====== NO Need na daw
                'Dim dtPR_dtl As New DataTable
                'dtPR_dtl = objDerived.GetDataTable("Select * from dbo.View_Invoice_PR where pr_invoice_hdr_id='" & Session("pr_invoice_hdr_id") & "' and rc_id='" & pr_hdr_data.Rows(i)("RC_ID") & "' and function_id='" & pr_hdr_data.Rows(i)("Function_ID") & "'", CommandType.Text)
                'For x As Integer = 0 To dtPR_dtl.Rows.Count - 1
                '    prdtl.PRHdr_ID = prhdrID
                '    prdtl.Item_ID = dtPR_dtl.Rows(x)("item_id")
                '    prdtl.Project_title = ""
                '    prdtl.Qty = dtPR_dtl.Rows(x)("qty")
                '    prdtl.Cost = dtPR_dtl.Rows(x)("price")
                '    prdtl.ppmp_dtl_id = 0
                '    'prdtl.Userid = Me.Session("@UserName").ToString
                '    prdtl.save()
                'Next


                Me.Session("pr_period_key_id") = p_pr_period_key.Rows(0)("pr_period_key_id")

                ''--------saving for obr hdr           
                Dim value As DataTable
                value = objDerived.GetDataTable("select F_ID_Accntg from dbo.View_RC_BOS where Office_ID=" & pr_hdr_data.Rows(i)("RC_ID") & " and Function_ID=" & pr_hdr_data.Rows(i)("Function_ID") & "", CommandType.Text)

                obr_hdr.TempOBR_No = ""
                Dim func_per_office As String = objDerived.GetValue("SELECT Func_per_Office_ID FROM  LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office WHERE Office_ID = " & pr_hdr_data.Rows(i)("RC_ID") & " AND Function_ID = " & pr_hdr_data.Rows(i)("Function_ID"), CommandType.Text)
                Dim str As String = objDerived.GetValue("SELECT  m_Fund.Fund_Code FROM  LnkdSrvrBOSS.GEOBOS.BOS.m_Fund as m_Fund INNER JOIN  LnkdSrvrBOSS.GEOBOS.BOS.m_Function_per_Office as m_Function_per_Office ON  m_Fund.F_ID =  m_Function_per_Office.F_ID WHERE ( m_Function_per_Office.Func_per_Office_ID = " & func_per_office & ")", CommandType.Text)

                str = str & "-" & CType(Date.Today.ToString("MM/dd/yyyy"), Date).Year & "-"
                obr_hdr.OBR_No = ""
                obr_hdr.F_ID_Accntg = value.Rows(0)("F_ID_Accntg")
                obr_hdr.Period_key = Session("pr_period_key_id")
                obr_hdr.PRHdr_ID = prhdrID
                obr_hdr.OBR_Date = Date.Today.ToString("MM/dd/yyyy")
                obr_hdr.OBR_Title = "Purchase of Gasoline for the period of " & Me.DdPeriod.SelectedItem.Text
                obr_hdr.Supplier_ID = 0
                obr_hdr.Payee = ""
                obr_hdr.Func_per_Office_ID = func_per_office
                'obr_hdr.Func_per_Office_ID = 0
                obr_hdr.Address = ""
                obr_hdr.Remarks = "Purchase of Gasoline for the period of " & Me.DdPeriod.SelectedItem.Text
                obr_hdr.Signatory1_ID = objDerived.GetValue("SELECT empID FROM dbo.view_EmployeeSignatories WHERE dept_id = " & pr_hdr_data.Rows(i)("RC_ID") & " AND isDeptHead = 1 AND func_id = " & pr_hdr_data.Rows(i)("Function_ID"), CommandType.Text) 'Department Head's EmpIDobjDerived.GetValue("SELECT empID FROM [GeoBOS].dbo.view_EmployeeSignatories WHERE dept_id = " & pr_hdr_data.Rows(i)("RC_ID") & " AND func_id = " & pr_hdr_data.Rows(i)("Function_ID"), CommandType.Text)
                obr_hdr.DateSigned1 = Date.Today.ToString("MM/dd/yyyy")
                obr_hdr.Signatory2_ID = objDerived.GetValue("SELECT empID FROM dbo.view_CityBudgetOfficer", CommandType.Text) 'Budget Officer's EmpID
                obr_hdr.DateSigned2 = Date.Today.ToString("MM/dd/yyyy")
                obr_hdr.isCancelled = False
                obr_hdr.isApproved = False
                obr_hdr.isPayroll = False
                obr_hdr.isApprovedMayor = False
                obr_hdr.Status = "Pending"
                obr_hdr.isAdjusted = False
                obr_hdr.isAddForDisbursement = False
                obr_hdr.isPayrollATM = False
                obr_hdr.pr_invoice_hdr_id = 0 'p_dataTotal.Rows(i)("pr_invoice_hdr_id")
                obr_hdr.pr_period_key_id = Me.Session("pr_period_key_id")
                obr_hdr.isGasoline = True
                obr_hdr.isReceivedMayor = False
                obr_hdr.DateDisapprovedMayor = "01/01/1900"
                obr_hdr.DateApprovedMayor = "01/01/1900"
                obr_hdr.DateReceivedMayor = "01/01/1900"
                obr_hdr.dateCancelled = "1/01/1900"
                obr_hdr.dateReceived = "01/01/1900"
                obr_hdr.isReceivedBO = False
                Dim obr_hdr_id As Long = obr_hdr.save()
                Session("obr_id") = obr_hdr_id

                ''------saving for obr adjustment hdr
                obr_Adjsutment_hdr.OBR_Hdr_ID = obr_hdr_id
                obr_Adjsutment_hdr.POHdr_ID = 0
                obr_Adjsutment_hdr.prhdr_id = prhdrID
                obr_Adjsutment_hdr.isforAdjustment = False
                Dim obr_Adjustment_hdr_id As Long = obr_Adjsutment_hdr.save()

                ''-------saving for disbursement transaction hdr
                disbursement.OBR_Hdr_ID = obr_hdr_id
                disbursement.ID = 5
                disbursement.save()

                ''------- saving for obr dtl 
                ' For x As Integer = 0 To p_GA_ID.Rows.Count - 1
                obr_dtl.OBR_Hdr_ID = obr_hdr_id
                obr_dtl.particulars = "Purchase of Gasoline for the period of " & Me.DdPeriod.SelectedItem.Text
                obr_dtl.BGA_ID = 0
                obr_dtl.RC_ID = pr_hdr_data.Rows(i)("RC_ID")
                obr_dtl.Function_ID = pr_hdr_data.Rows(i)("Function_ID")
                obr_dtl.Program_ID = 0
                obr_dtl.Project_ID = 0
                obr_dtl.GA_ID = 794
                obr_dtl.Amount = pr_hdr_data.Rows(i)("total") 'pBody.Compute("sum(total)", "GA_ID=" & p_GA_ID.Rows(x)("GA_ID") & "")
                obr_dtl.AllotmentClass_ID = 2
                obr_dtl.save()

                ''-------saving for obr adjustment dtl
                obr_Adjsutment_dtl.obr_adjustment_hdr_id = obr_Adjustment_hdr_id
                obr_Adjsutment_dtl.GA_ID = 794
                obr_Adjsutment_dtl.BGA_ID = 0
                obr_Adjsutment_dtl.Amount = pr_hdr_data.Rows(i)("total") 'pBody.Compute("sum(total)", "GA_ID=" & p_GA_ID.Rows(x)("GA_ID") & " and BGA_ID=" & p_GA_ID.Rows(x)("BGA_ID") & "")
                obr_Adjsutment_dtl.new_amount = "0.00"
                obr_Adjsutment_dtl.save()

                ' ''------saving for pr dtl
                'Dim data_invoice As DataTable
                'data_invoice = objDerived.GetDataTable("exec ams.sp_pr_gasoline_invoice_dtl '" & pr_hdr_data.Rows(i)("pr_period_key_id") & "','" & pr_hdr_data.Rows(i)("rc_id") & "','" & pr_hdr_data.Rows(i)("function_id") & "'", CommandType.Text)

            Next

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Transaction has been successfully saved.")

            objDerived.GetRecords("Update ams.pr_period_key set isClosed='true' where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)

            p_pr_period_key = objDerived.GetDataTable("SELECT     TOP (1) pr_period_key_id, pr_period_key_desc, date_to FROM         AMS.pr_period_key ORDER BY pr_period_key_id DESC", CommandType.Text)
            lbPeriod.Enabled = True

            Dim date_to As DateTime
            date_to = p_pr_period_key.Rows(0)("date_to")
            txtTo.Text = date_to.AddDays(1).ToShortDateString
            txtFrom.Text = DateTime.Now.ToShortDateString
            RangeValidator1.MinimumValue = date_to.AddDays(1).ToShortDateString 'p_pr_period_key.Rows(0)("date_to").ToShortDateString
            RangeValidator1.MaximumValue = "12/31/2099" 'DateTime.Now.ToShortDateString

            RangeValidator2.MinimumValue = CType(txtFrom.Text, DateTime).ToShortDateString
            RangeValidator2.MaximumValue = "12/31/2099" 'DateTime.Now.ToShortDateString


            btnCreate.Enabled = False
            btnCreatePR.Enabled = False
            'btnAdd.Enabled = False
            btnSave.Enabled = False
            cbVarious.Enabled = False
            ddOffice.Enabled = False
            btnPreview.Enabled = True

            'txtPeriod.Text = ""

            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()

            pGasolineGoods = objDerived.GetDataTable("[dbo].[getItem_gasoline_peritem]", CommandType.Text)

            Me.gvitems.Enabled = False
            Me.gvTotal.SelectedIndex = -1
            Me.GVoffices.SelectedIndex = -1
            Me.GVvarious.SelectedIndex = -1


            Me.GVoffices.Enabled = True
            Me.GVvarious.Enabled = True

            '---
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.DataSource = pGasolineGoods
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False

            pOffice = objDerived.GetDataTable("select * from dbo.view_pr_gas_office", CommandType.Text)
            ddOffice.Items.Clear()
            ddOffice.Items.Add("Select")
            ddOffice.DataSource = pOffice
            ddOffice.DataTextField = ("rc_name")
            ddOffice.DataValueField = ("office_id")
            ddOffice.DataBind()

            p_datasummary = Nothing
            gvSummary.DataSource = p_datasummary
            gvSummary.DataBind()

            p_SOA = Nothing
            gvSOA.DataSource = p_SOA
            gvSOA.DataBind()

            p_dataTotal = Nothing
            gvTotal.DataSource = p_dataTotal
            gvTotal.DataBind()

            gvListPR.DataSource = objDerived.GetRecords("select * from  ams.vw_pr_gasoline_history", CommandType.Text)
            gvListPR.DataBind()

        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        If btnCreate.Text = "CREATE INVOICE" Then

            txtInvoiceNumber.Text = objDerived.GetValue("SELECT TOP (1) Invoice_No  FROM  AMS.pr_invoice_hdr  ORDER BY pr_invoice_hdr_id DESC ", CommandType.Text) + 1
            'pnlInvoice.GroupingText = "Invoice #: " & txtInvoiceNumber.Text & ""

            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()
            txtInvoiceNumber.Enabled = True
            ScriptManager.GetCurrent(Me.Page).SetFocus(txtInvoiceNumber)

            txtInvoiceNumber.Focus()
            cbVarious.Enabled = True
            ddOffice.Enabled = True

            Me.gvitems.SelectedIndex = -1

            pGasolineGoods = objDerived.GetDataTable("[dbo].[getItem_gasoline_peritem]", CommandType.Text)
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.DataSource = pGasolineGoods
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False
            '---




        Else

        End If
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If isValid_Invoice() = True Then
                'pnlInvoice.GroupingText = "Invoice #: " & txtInvoiceNumber.Text & ""
                btnCreate.Enabled = True

                btnSave.Enabled = False
                btnCreate.Text = "CANCEL"
                cbVarious.Enabled = True
                ddOffice.Enabled = True
            Else

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invoice Number is already existing.")
            End If
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try

    End Sub

    Protected Sub txtInvoiceNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvoiceNumber.TextChanged
        Try

            If isValid_Invoice() = True Then
                'pnlInvoice.GroupingText = "Invoice #: " & txtInvoiceNumber.Text & ""
                btnCreate.Enabled = True
                If ddOffice.SelectedIndex <> 0 Then
                    ' btnAdd.Enabled = True
                Else
                    'btnAdd.Enabled = False
                End If

                btnSave.Enabled = False
                'btnCreate.Text = "CANCEL"
                cbVarious.Enabled = True
                ddOffice.Enabled = True
                If pInvoice.Rows.Count >= 1 Then
                    btnSave.Enabled = True
                End If

            Else
                ' MsgeBox.CreateMessageAlertInUpdatePanel(Me.upCollapse, ex.ToString)
                If Me.gvTotal.SelectedIndex <> -1 Then
                    Dim invoice As String
                    invoice = Me.gvTotal.SelectedDataKey.Item("Invoice_No")
                    If Me.txtInvoiceNumber.Text = invoice Then

                    Else
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invoice Number is already existing.")
                    End If
                Else
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invoice Number is already existing.")
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Function isValid_Invoice() As Boolean
        Dim valid_data As DataTable
        Dim result As Boolean
        valid_data = objDerived.GetDataTable("select Invoice_No from ams.vw_pr_invoice_list where Invoice_No='" & txtInvoiceNumber.Text & "'", CommandType.Text)
        If valid_data.Rows.Count >= 1 Then
            result = False
        Else
            result = True
        End If
        Return result
    End Function
    Function iswith_budget() As Boolean

        Dim result As Boolean
        budget_data = objDerived.GetDataTable("exec ams.sp_budget_release_gasoline_Status '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
        If budget_data.Rows.Count >= 1 Then
            result = False
        Else
            result = True
        End If
        Return result
    End Function

    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtQty As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtQty.NamingContainer, GridViewRow)
            If txtQty.Text = "" Then
                txtQty.Text = "0"
            End If
            Me.Session("rowindex") = gvr.RowIndex
            Dim txtPrice As TextBox = CType(Me.gvInvoice.Rows(gvr.RowIndex).Cells(2).FindControl("txtprice"), TextBox)
            pInvoice.Rows(gvr.RowIndex)("qty") = txtQty.Text

            callEnableButton()
            'ScriptManager.GetCurrent(Me.Page).SetFocus(txtPrice)

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtprice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtPrice As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtPrice.NamingContainer, GridViewRow)
            If txtPrice.Text = "" Then
                txtPrice.Text = "0.00"
            End If
            txtPrice.Text = FormatNumber(txtPrice.Text, 2)
            Me.Session("rowindex") = gvr.RowIndex

            Dim txtQty As TextBox = CType(Me.gvInvoice.Rows(gvr.RowIndex + 1).Cells(1).FindControl("txtqty"), TextBox)
            pInvoice.Rows(gvr.RowIndex)("cost") = txtPrice.Text
            gvInvoice.FooterRow.Cells(2).Text = FormatNumber(pInvoice.Compute("sum(cost)", ""), 2)


            If CType(gvInvoice.FooterRow.Cells(2).Text, Integer) > CType(txtReleaseAmount.Text.Replace(",", ""), Integer) Then
                btnSave.Enabled = False
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Notice: Total amount exceed from the release amount.")
            Else
                callEnableButton()
            End If

            'ScriptManager.GetCurrent(Me.Page).SetFocus(txtQty)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Me.btnSave.Text = "SAVE INVOICE" Then
                If isValid_Invoice() = False Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invoice Number is already existing. Please change the invoice number.")
                    Exit Sub
                End If

                Dim officeID, Function_ID As Long

                If Me.GVoffices.SelectedIndex = -1 Then
                    officeID = Me.GVvarious.SelectedDataKey.Item(0)
                    Function_ID = Me.GVvarious.SelectedDataKey.Item(1)
                Else
                    officeID = Me.GVoffices.SelectedDataKey.Item(0)
                    Function_ID = Me.GVoffices.SelectedDataKey.Item(1)
                End If

                invoice_hdr.pr_period_key_id = p_pr_period_key.Rows(0)("pr_period_key_id")
                invoice_hdr.rc_id = officeID
                invoice_hdr.function_id = Function_ID

                invoice_hdr.Invoice_No = txtInvoiceNumber.Text
                invoice_hdr.Invoice_Date = "01/01/1900"
                invoice_hdr.SOA_No = txtSOA.Text
                Dim invoiceID As Long = invoice_hdr.save()

                Session("pr_invoice_hdr_id") = invoiceID

                For i As Integer = 0 To pInvoice.Rows.Count - 1
                    If pInvoice.Rows(i)("cost") <> "0.00" Then
                        invoice_dtl.pr_invoice_hdr_id = invoiceID
                        invoice_dtl.item_id = pInvoice.Rows(i)("item_id")
                        invoice_dtl.qty = pInvoice.Rows(i)("qty")
                        invoice_dtl.price = pInvoice.Rows(i)("cost")
                        invoice_dtl.save()
                    End If
                Next

                '== DEPARTMENTS ==
                GVoffices.Enabled = True
                GVvarious.Enabled = True



            Else
                If Me.txtInvoiceNumber.Text = Me.gvTotal.SelectedDataKey.Item("Invoice_No") Then

                Else
                    If isValid_Invoice() = False Then
                        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invoice Number is already existing. Please change the invoice number.")
                        Exit Sub
                    End If
                End If

                Dim origcount As Integer = Me.Session("row_num_edit")
                objDerived.GetRecords("Update AMS.pr_invoice_hdr set Invoice_no='" & txtInvoiceNumber.Text & "',SOA_No='" & txtSOA.Text & "' where pr_invoice_hdr_id='" & gvTotal.SelectedDataKey(0) & "'", CommandType.Text)

                For i As Integer = 0 To pInvoice.Rows.Count - 1
                    If pInvoice.Rows(i)("cost") = "0.00" Or pInvoice.Rows(i)("qty") = "0" Or pInvoice.Rows(i)("qty") = "0.00" Then
                        Me.objDerived.Execute("[ams].[getdelete_invoice_dtl_item]" & Me.gvTotal.SelectedDataKey.Item(0) & ", " & pInvoice.Rows(i)("item_id"), Data.CommandType.Text)

                    Else
                        If pInvoice.Rows(i)("cost") <> "0.00" Or pInvoice.Rows(i)("qty") <> "0" Or pInvoice.Rows(i)("qty") <> "0.00" Then

                            Dim count As Integer
                            count = Me.objDerived.GetValue("[dbo].[get_item_count_gasoline]" & Me.gvTotal.SelectedDataKey.Item(0) & ", " & pInvoice.Rows(i)("item_id"), Data.CommandType.Text)
                            If count = 1 Then
                                Me.objDerived.Execute("[dbo].[get_update_gasoline_per_item]" & Me.gvTotal.SelectedDataKey.Item(0) & "," & pInvoice.Rows(i)("item_id") & ",'" & pInvoice.Rows(i)("qty") & "','" & pInvoice.Rows(i)("cost") & "'", Data.CommandType.Text)

                            Else
                                invoice_dtl.pr_invoice_hdr_id = Me.gvTotal.SelectedDataKey.Item(0)
                                invoice_dtl.item_id = pInvoice.Rows(i)("item_id")
                                invoice_dtl.qty = pInvoice.Rows(i)("qty")
                                invoice_dtl.price = pInvoice.Rows(i)("cost")
                                invoice_dtl.save()
                            End If
                        Else

                        End If
                    End If

                Next

                '== DEPARTMENTS ==
                GVoffices.Enabled = True
                GVvarious.Enabled = True

                gvitems.Enabled = False
                txtDepartment.Text = ""
                gvTotal.SelectedIndex = -1
                GVoffices.SelectedIndex = -1
                GVvarious.SelectedIndex = -1


                Me.btnSave.Text = "SAVE INVOICE"
            End If

            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()
            Dim functionID, RCID As Long

            If Me.GVoffices.SelectedIndex <> -1 Then
                functionID = GVoffices.SelectedDataKey.Item("Function_ID")
                RCID = GVoffices.SelectedDataKey.Item("Office_ID")

            ElseIf Me.GVvarious.SelectedIndex <> -1 Then

                functionID = Me.GVvarious.SelectedDataKey.Item("Function_ID")
                RCID = GVvarious.SelectedDataKey.Item("Office_ID")

            ElseIf Me.gvTotal.SelectedIndex <> -1 Then
                functionID = Me.gvTotal.SelectedDataKey.Item("Function_ID")
                RCID = Me.gvTotal.SelectedDataKey.Item("RC_ID")
            Else
                functionID = 0
                RCID = 0
            End If


            pGasolineGoods = objDerived.GetDataTable("[ams].[getgasolinelist_per_department]" & functionID & "," & RCID & " ," & 0, CommandType.Text)
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.DataSource = pGasolineGoods
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False
            gvitems.SelectedIndex = 0

            p_pr_period_key = objDerived.GetDataTable("SELECT     pr_period_key_id, pr_period_key_desc,date_to  FROM AMS.pr_period_key  WHERE     isClosed = 0", CommandType.Text)
            DdPeriod.SelectedItem.Text = p_pr_period_key.Rows(0)("pr_period_key_desc")
            cbVarious.Checked = False

            p_datasummary = objDerived.GetDataTable("select rc_name,total from ams.vw_pr_gasoline_summary_v2  where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)
            gvSummary.DataSource = p_datasummary
            gvSummary.DataBind()

            p_SOA = objDerived.GetDataTable("Select SOA_No,amount from ams.SOA where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)
            gvSOA.DataSource = p_SOA
            gvSOA.DataBind()

            If p_datasummary.Rows.Count >= 1 Then
                gvSummary.FooterRow.Cells(1).Text = FormatNumber(p_datasummary.Compute("sum(total)", ""), 2)
                gvSOA.FooterRow.Cells(1).Text = FormatNumber(p_SOA.Compute("sum(amount)", ""), 2)
            End If

            ' Dim dataTotal As DataTable
            p_dataTotal = objDerived.GetDataTable("select Invoice_No,rc_name,total,rc_id,function_id,pr_invoice_hdr_id,SOA_No from ams.vw_pr_gasoline_summary_invoice_dtl  where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "' order by pr_invoice_hdr_id", CommandType.Text)
            If p_dataTotal.Rows.Count = 0 Then
                Session("withOffices") = 0
            Else
                Session("withOffices") = 1
            End If
            gvTotal.DataSource = p_dataTotal
            gvTotal.DataBind()

            If p_dataTotal.Rows.Count >= 1 Then
                gvTotal.FooterRow.Cells(5).Text = FormatNumber(p_dataTotal.Compute("sum(total)", ""), 2)
            End If
            lbPeriod.Enabled = False

            btnCreate.Text = "CREATE INVOICE"
            btnCreate.Enabled = True
            ' btnAdd.Enabled = False
            btnSave.Enabled = False
            'cbVarious.Enabled = False
            ddOffice.Enabled = False
            btnCreatePR.Enabled = True
            'pnlInvoice.GroupingText = "Invoice"

            'txtInvoiceNumber.Text = ""
            ''--------------end refresh
            txtInvoiceNumber.Text = txtInvoiceNumber.Text + 1
            'pnlInvoice.GroupingText = "Invoice #: " & txtInvoiceNumber.Text & ""
            btnCreate.Enabled = True
            ' btnAdd.Enabled = True
            btnSave.Enabled = False
            btnCreate.Text = "CREATE INVOICE"
            cbVarious.Enabled = True
            ddOffice.Enabled = True
            Me.Session("edit") = False
            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()
            ScriptManager.GetCurrent(Me.Page).SetFocus(txtInvoiceNumber)


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.updatepanel1, "something went wrong, please contact system admin.")

        End Try
    End Sub

    Protected Sub ddOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddOffice.SelectedIndexChanged
        If ddOffice.SelectedIndex <> 0 Then
            'btnAdd.Enabled = True
            Me.gvitems.Enabled = True

        Else
            'btnAdd.Enabled = False
        End If
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Me.Page.Response.Redirect("~/procurement/rpt_purchase_request_gasoline.aspx")
    End Sub



    Protected Sub gvTotal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvTotal.SelectedIndexChanged
        '------------------------------macky'
        Me.GVoffices.SelectedIndex = -1
        Me.GVvarious.SelectedIndex = -1

        rc_ID = Me.gvTotal.SelectedDataKey.Item(1)
        Function_ID = Me.gvTotal.SelectedDataKey.Item("Function_ID")

        'pGasolineGoods = objDerived.GetDataTable("[ams].[getgasolinelist_per_department]" & Function_ID & "," & rc_ID & " ," & 0, CommandType.Text)

        If Lbtn = "edit" Then
            Dim pr_hdr_ID As Long
            Dim invoiceno As String

            pr_hdr_ID = Me.gvTotal.SelectedDataKey.Item(0)
            pEditInvoice = Me.objDerived.GetDataTable("EXEC [dbo].[getinvoice_dtl] '" & pr_hdr_ID & "'", CommandType.Text)
            invoiceno = Me.objDerived.GetValue("Select Invoice_No FROM AMS.pr_invoice_hdr where pr_invoice_hdr_id = " & pr_hdr_ID, Data.CommandType.Text)

            txtSOA.Text = gvTotal.SelectedDataKey(5)
            Me.txtDepartment.Text = Me.gvTotal.SelectedDataKey.Item("rc_name")

            Me.txtInvoiceNumber.Text = invoiceno
            'pnlInvoice.GroupingText = "Invoice #: " & txtInvoiceNumber.Text & ""
            Me.txtInvoiceNumber.Enabled = True
            Me.btnCreate.Enabled = True

            Dim sumObject As Integer
            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            Dim dt, dt_GA_ID As New DataTable
            Dim dr, dr_GA_ID As DataRow
            Dim cb As CheckBox

            pInvoice = Nothing

            For i As Integer = 0 To pEditInvoice.Rows.Count - 1

                If pInvoice Is Nothing Then
                    dt.Columns.Add("id", GetType(Integer))
                    dt.Columns.Add("Item_Desc", GetType(String))
                    dt.Columns.Add("Description", GetType(String))
                    dt.Columns.Add("qty", GetType(Decimal))
                    dt.Columns.Add("cost", GetType(Decimal))
                    dt.Columns.Add("Item_ID", GetType(Integer))
                    dt.Columns.Add("isVisible", GetType(Boolean))
                    dt.Columns.Add("ReadOnly", GetType(Boolean))
                    dt.Columns.Add("GA_ID", GetType(Integer))
                    dt.Columns.Add("BGA_ID", GetType(Integer))

                    dt_GA_ID.Columns.Add("GA_ID", GetType(Integer))
                    dt_GA_ID.Columns.Add("BGA_ID", GetType(Integer))
                    ' For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    ' cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                    ' If cb.Checked = True Then
                    dr = dt.NewRow
                    dr("id") = 1
                    dr("Item_Desc") = pEditInvoice.Rows(i)("Item_Desc")
                    dr("Description") = pEditInvoice.Rows(i)("Description")
                    dr("qty") = pEditInvoice.Rows(i)("qty")
                    dr("cost") = pEditInvoice.Rows(i)("cost") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                    dr("Item_ID") = pEditInvoice.Rows(i)("Item_ID")
                    dr("isVisible") = True
                    dr("ReadOnly") = False
                    dr("GA_ID") = pEditInvoice.Rows(i)("GA_ID")
                    dr("BGA_ID") = pEditInvoice.Rows(i)("BGA_ID")

                    dt.Rows.Add(dr)




                    If p_GA_ID Is Nothing Then
                        dr_GA_ID = dt_GA_ID.NewRow
                        dr_GA_ID("GA_ID") = pEditInvoice.Rows(i)("GA_ID")
                        dr_GA_ID("BGA_ID") = pEditInvoice.Rows(i)("BGA_ID")
                        dt_GA_ID.Rows.Add(dr_GA_ID)
                        p_GA_ID = dt_GA_ID
                    Else
                        Dim ds As New DataSet
                        Dim myview As DataView
                        myview = p_GA_ID.DefaultView
                        myview.RowFilter = " GA_ID = '" & (pEditInvoice.Rows(i)("GA_ID")) & "' and BGA_ID = '" & (pEditInvoice.Rows(i)("BGA_ID")) & "'"
                        If myview.Count() = 0 Then
                            dt_GA_ID = p_GA_ID
                            dr_GA_ID = dt_GA_ID.NewRow
                            dr_GA_ID("GA_ID") = pEditInvoice.Rows(i)("GA_ID")
                            dr_GA_ID("BGA_ID") = pEditInvoice.Rows(i)("BGA_ID")
                            dt_GA_ID.Rows.Add(dr_GA_ID)
                            p_GA_ID = dt_GA_ID
                        End If
                    End If

                    'End If
                    ' Next
                    pInvoice = dt
                    sumObject = pInvoice.Compute("count(id)", "id=1")
                    If sumObject <= 9 Then
                        pInvoice.Merge(createDataTable(9 - sumObject))
                    End If
                    Me.Session("CurrentRowCount") = sumObject
                Else
                    sumObject = pInvoice.Compute("count(id)", "id=1")
                    ' For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    ' cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    ' If cb.Checked = True Then
                    dt = pInvoice
                    dr = dt.NewRow
                    dr("id") = 1
                    dr("Item_Desc") = pEditInvoice.Rows(i)("Item_Desc")
                    dr("Description") = pEditInvoice.Rows(i)("Description")
                    dr("qty") = pEditInvoice.Rows(i)("qty")
                    dr("cost") = pEditInvoice.Rows(i)("cost") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                    dr("Item_ID") = pEditInvoice.Rows(i)("Item_ID")
                    dr("isVisible") = True
                    dr("ReadOnly") = False
                    dr("GA_ID") = pEditInvoice.Rows(i)("GA_ID")
                    dr("BGA_ID") = pEditInvoice.Rows(i)("BGA_ID")
                    dt.Rows.Add(dr)
                    pInvoice = dt

                    '  dt_GA_ID.Columns.Add("GA_ID")
                    '  dt_GA_ID.Columns.Add("BGA_ID")
                    Dim ds As New DataSet
                    Dim myview As DataView
                    myview = p_GA_ID.DefaultView
                    myview.RowFilter = " GA_ID = '" & (pEditInvoice.Rows(i)("GA_ID")) & "' and BGA_ID = '" & (pEditInvoice.Rows(i)("BGA_ID")) & "'"
                    If myview.Count() = 0 Then
                        dt_GA_ID = p_GA_ID
                        dr_GA_ID = dt_GA_ID.NewRow
                        dr_GA_ID("GA_ID") = pEditInvoice.Rows(i)("GA_ID")
                        dr_GA_ID("BGA_ID") = pEditInvoice.Rows(i)("BGA_ID")
                        dt_GA_ID.Rows.Add(dr_GA_ID)
                        p_GA_ID = dt_GA_ID
                    End If
                    'End If
                    ' Next
                    If sumObject <= 9 Then
                        For l As Integer = 0 To 10
                            If sumObject + l < 10 Then
                                pInvoice.Rows(9 - l).Delete()
                            Else
                                Exit For
                            End If
                        Next
                        'sumObject = 0
                        sumObject = pInvoice.Compute("count(id)", "id=1")
                        Me.Session("CurrentRowCount") = sumObject
                        pInvoice.Merge(createDataTable(9 - sumObject))
                    End If
                End If
                Me.gvInvoice.DataSource = pInvoice
                gvInvoice.DataBind()

                Me.Session("row_num_edit") = pInvoice.Rows.Count - 1

                'gvInvoice.DataSource = pEditInvoice
                'gvInvoice.DataBind()

                pGasolineGoods = Nothing
                Dim functionID, RCID As Long

                If Me.GVoffices.SelectedIndex <> -1 Then
                    functionID = GVoffices.SelectedDataKey.Item("Function_ID")
                    RCID = GVoffices.SelectedDataKey.Item("Office_ID")

                ElseIf Me.GVvarious.SelectedIndex <> -1 Then

                    functionID = Me.GVvarious.SelectedDataKey.Item("Function_ID")
                    RCID = GVvarious.SelectedDataKey.Item("Office_ID")

                ElseIf Me.gvTotal.SelectedIndex <> -1 Then
                    functionID = Me.gvTotal.SelectedDataKey.Item("Function_ID")
                    RCID = Me.gvTotal.SelectedDataKey.Item(1)
                Else
                    functionID = 0
                    RCID = 0
                End If


                Dim id As Integer
                id = pEditInvoice.Rows(i)("Item_ID")

                'pGasolineGoods = objDerived.GetDataTable("[ams].[getgasolinelist_per_department]" & functionID & "," & RCID & "," & id, CommandType.Text)
                pGasolineGoods = objDerived.GetDataTable("[AMS].[sp_GasolineItems_Edit]", CommandType.Text)
                Dim data As DataTable
                data = pGasolineGoods
                'For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                'cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                ' If cb.Checked = True Then

                'If Me.gvitems.SelectedDataKey(4) = Me.gvitems.Rows(i).Cells(4).Text Then
                'data.Rows(pEditInvoice.Rows(i)("ID")).Delete()
                ' End If
                ' Next
                pGasolineGoods = data
                gvitems.DataSource = pGasolineGoods
                gvitems.DataBind()
                gvitems.Columns(3).Visible = False
                gvitems.Columns(4).Visible = False
                gvitems.Columns(5).Visible = False
                gvitems.Columns(6).Visible = False
                gvitems.Columns(7).Visible = False
                gvitems.Columns(8).Visible = False

            Next

            Me.gvitems.Enabled = True
            Me.btnSave.Enabled = True
            Me.btnCreate.Enabled = False

            Me.btnSave.Text = "UPDATE INVOICE"



            'Dim count_rc As Integer

            'count_rc = Me.objDerived.GetValue("[dbo].[get_rc_identity]" & pr_hdr_ID, Data.CommandType.Text)


            Me.txtInvoiceNumber.Text = objDerived.GetValue("[dbo].[get_invoice_number]" & pr_hdr_ID, Data.CommandType.Text)


            Me.gvitems.Enabled = True

            gvInvoice.FooterRow.Cells(2).Text = FormatNumber(pInvoice.Compute("sum(cost)", ""), 2)
        Else

            Dim pr_hdr_ID As Long

            pr_hdr_ID = Me.gvTotal.SelectedDataKey.Item(0)


            Me.objDerived.Execute("[ams].[get_delete_invoice]" & pr_hdr_ID, Data.CommandType.Text)


            '  pEditInvoice = Me.objDerived.GetDataTable("[dbo].[getinvoice_dtl]" & pr_hdr_ID, CommandType.Text)
            p_dataTotal = objDerived.GetDataTable("select Invoice_No,rc_name,total,rc_id,function_id,pr_invoice_hdr_id,SOA_No from ams.vw_pr_gasoline_summary_invoice_dtl  where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "' order by pr_invoice_hdr_id", CommandType.Text)
            gvTotal.DataSource = p_dataTotal
            gvTotal.DataBind()

            p_pr_period_key = objDerived.GetDataTable("SELECT     pr_period_key_id, pr_period_key_desc,date_to  FROM AMS.pr_period_key  WHERE     isClosed = 0", CommandType.Text)
            'txtPeriod.Text = p_pr_period_key.Rows(0)("pr_period_key_desc")

            p_datasummary = objDerived.GetDataTable("select rc_name,total from ams.vw_pr_gasoline_summary  where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)
            gvSummary.DataSource = p_datasummary
            gvSummary.DataBind()
            p_SOA = objDerived.GetDataTable("Select SOA_No,amount from ams.SOA where pr_period_key_id='" & p_pr_period_key.Rows(0)("pr_period_key_id") & "'", CommandType.Text)
            gvSOA.DataSource = p_SOA
            gvSOA.DataBind()

            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()

            Me.txtDepartment.Text = ""

            pGasolineGoods = objDerived.GetDataTable("[dbo].[getItem_gasoline_peritem]", CommandType.Text)
            Me.gvitems.Enabled = False

            Me.gvTotal.SelectedIndex = -1
            Me.GVoffices.SelectedIndex = -1
            Me.GVvarious.SelectedIndex = -1
            Me.btnSave.Enabled = False
        End If

        'Me.Session("edit") = True
        'pInvoice = objDerived.GetDataTable("exec ams.sp_load_invoice_dtl '" & gvTotal.SelectedDataKey(0) & "'", CommandType.Text)
        'Me.Session("row_num_edit") = pInvoice.Rows.Count - 1
        'Dim sumObject As Integer
        'sumObject = pInvoice.Compute("count(id)", "id=1")
        'If sumObject <= 9 Then
        '    pInvoice.Merge(createDataTable(9 - sumObject))
        'End If
        'gvInvoice.DataSource = pInvoice
        'gvInvoice.DataBind()
        'For i As Integer = 0 To pInvoice.Rows.Count - 1
        '    If i < sumObject Then
        '        Dim txtQty As TextBox = CType(gvInvoice.Rows(i).FindControl("txtqty"), TextBox)
        '        Dim txtPrice As TextBox = CType(gvInvoice.Rows(i).FindControl("txtprice"), TextBox)
        '        txtQty.ReadOnly = False
        '        txtQty.Attributes.Add("onFocus", "this.select()")
        '        txtQty.Attributes.Add("onClick", "this.select()")
        '        txtPrice.ReadOnly = False
        '        txtPrice.Attributes.Add("onFocus", "this.select()")
        '        txtPrice.Attributes.Add("onClick", "this.select()")

        '        'Else
        '        'CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
        '        'CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text = 0
        '    End If

        'Next
        'gvInvoice.FooterRow.Cells(2).Text = FormatNumber(pInvoice.Compute("sum(cost)", ""), 2)
        'If gvInvoice.FooterRow.Cells(2).Text = "0.00" Then
        '    ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvInvoice.Rows(0).Cells(1).FindControl("txtqty"), TextBox))
        'Else
        '    ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvInvoice.Rows(sumObject - 1).Cells(1).FindControl("txtqty"), TextBox))
        'End If
    End Sub

    Protected Sub gvSummary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSummary.SelectedIndexChanged

    End Sub

    Protected Sub gvListPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListPR.SelectedIndexChanged
        Me.Session("pr_period_key_id") = gvListPR.SelectedDataKey(0)

        Me.Page.Response.Redirect("~/procurement/rpt_purchase_request_gasoline.aspx")

    End Sub

    Protected Sub GVoffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVoffices.SelectedIndexChanged
        'gvitems.Enabled = True
        Me.GVvarious.SelectedIndex = -1
        Me.gvTotal.SelectedIndex = -1

        If Me.DdPeriod.SelectedItem.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Please create new period.")
        Else
            Me.txtDepartment.Text = Me.GVoffices.SelectedDataKey.Item("RC_Name")
            Me.GVvarious.SelectedIndex = -1

            '=====FILTER Department with Release Budget=======Office_ID Function_ID
            Dim dtGas As New DataTable
            dtGas = objDerived.GetDataTable("Select * from dbo.View_GasolineOffices where RC_ID ='" & GVoffices.SelectedDataKey("Office_ID") & "' and Function_ID ='" & GVoffices.SelectedDataKey("Function_ID") & "'", CommandType.Text)
            If dtGas.Rows.Count = 0 Then
                gvitems.Enabled = False
                txtReleaseAmount.Text = "0.00"
            Else
                Dim dtPR As New DataTable
                dtPR = objDerived.GetDataTable("Select * from dbo.View_Gasoline_withPR_v2 where RC_ID ='" & GVoffices.SelectedDataKey("Office_ID") & "' and Function_ID ='" & GVoffices.SelectedDataKey("Function_ID") & "'", CommandType.Text)
                If dtPR.Rows.Count = 0 Then '===Filter if had already PR===
                    gvitems.Enabled = True
                    Dim A As Double
                    A = FormatNumber(CType(dtGas.Rows(0)("Amount"), Decimal), 2)
                    txtReleaseAmount.Text = A.ToString("N2")
                Else
                    gvitems.Enabled = True
                    Dim A As Double
                    A = FormatNumber(CType(dtPR.Rows(0)("total"), Decimal), 2)
                    txtReleaseAmount.Text = A.ToString("N2")
                End If

            End If

            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()

            Dim functionID, RCID As Long
            functionID = GVoffices.SelectedDataKey.Item("Function_ID")
            RCID = GVoffices.SelectedDataKey.Item("Office_ID")

            'pGasolineGoods = objDerived.GetDataTable("[ams].[getgasolinelist_per_department]" & functionID & "," & RCID & "," & 0, CommandType.Text)
            pGasolineGoods = objDerived.GetDataTable("EXEC [AMS].[sp_GasolineItems]", CommandType.Text)

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.DataSource = pGasolineGoods
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False
            Me.btnSave.Text = "SAVE INVOICE"
            Me.btnSave.Enabled = False
        End If
    End Sub

    Protected Sub GVvarious_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvarious.SelectedIndexChanged
        Me.GVoffices.SelectedIndex = -1
        Me.gvTotal.SelectedIndex = -1
        gvitems.Enabled = True
        If Me.DdPeriod.SelectedItem.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel11, "Please create new period.")
        Else
            txtDepartment.Text = Me.GVvarious.SelectedDataKey.Item("RC_Name")
            GVoffices.SelectedIndex = -1

            '=====FILTER Department with Release Budget=======
            Dim dtGas As New DataTable
            dtGas = objDerived.GetDataTable("Select * from dbo.View_GasolineOffices where RC_ID ='" & GVvarious.SelectedDataKey("Office_ID") & "' and Function_ID ='" & GVvarious.SelectedDataKey("Function_ID") & "' and Budget_Year = '" & Year(Date.Today.ToString("MM/dd/yyyy")) & "'", CommandType.Text)
            If dtGas.Rows.Count = 0 Then
                gvitems.Enabled = False
                txtReleaseAmount.Text = "0.00"
            Else
                Dim dtPR As New DataTable
                dtPR = objDerived.GetDataTable("Select * from dbo.View_Gasoline_withPR_v2 where RC_ID ='" & GVvarious.SelectedDataKey("Office_ID") & "' and Function_ID ='" & GVvarious.SelectedDataKey("Function_ID") & "'", CommandType.Text)
                If dtPR.Rows.Count = 0 Then '===Filter if had already PR===
                    gvitems.Enabled = True
                    Dim A As Double
                    A = CType(dtGas.Rows(0)("Amount"), Decimal)
                    txtReleaseAmount.Text = A.ToString("N2")
                Else
                    gvitems.Enabled = False
                    Dim A As Double
                    A = CType(dtPR.Rows(0)("total"), Decimal)
                    txtReleaseAmount.Text = A.ToString("N2")
                End If

            End If


            pInvoice = Nothing
            gvInvoice.DataSource = createDataTable(9)
            gvInvoice.DataBind()

            Dim functionID, RCID As Long
            functionID = Me.GVvarious.SelectedDataKey.Item("Function_ID")
            RCID = GVvarious.SelectedDataKey.Item("Office_ID")

            'pGasolineGoods = objDerived.GetDataTable("[ams].[getgasolinelist_per_department]" & functionID & "," & RCID & "," & 0, CommandType.Text)
            pGasolineGoods = objDerived.GetDataTable("EXEC [AMS].[sp_GasolineItems]", CommandType.Text)

            gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            gvitems.Columns(5).Visible = True
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.Columns(8).Visible = True
            gvitems.DataSource = pGasolineGoods
            gvitems.DataBind()
            gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.Columns(5).Visible = False
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            gvitems.Columns(8).Visible = False

            If Session("withOffices") = 0 Then
                gvitems.Enabled = False
            ElseIf Session("withOffices") = 1 Then
                gvitems.Enabled = True
            End If

            Me.btnSave.Text = "SAVE INVOICE"

            Me.btnSave.Enabled = False
        End If

    End Sub

    Protected Sub LinkButton1_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "Cancel"
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Invoice has been successfully cancelled.")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "edit"
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        gvListPR.DataSource = objDerived.GetRecords("Exec [ams].[Get_date_from_gasoline]" & Me.Drpmonth.Text & "," & Me.Drpyear.Text, CommandType.Text)
        gvListPR.DataBind()
    End Sub

    Protected Sub TextBox6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try


            Dim txtPrice2 As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtPrice2.NamingContainer, GridViewRow)

            If txtPrice2.Text = "" Then
                txtPrice2.Text = "0.00"
            End If
            txtPrice2.Text = FormatNumber(txtPrice2.Text, 2)
            Me.Session("rowindex") = gvr.RowIndex
            ' Dim txtQty As TextBox = CType(Me.gvTotal1.Rows(gvr.RowIndex + 1).Cells(1).FindControl("txtqnty2"), TextBox)
            p_dataTotal1.Rows(gvr.RowIndex)("price") = txtPrice2.Text

         

            gvTotal1.FooterRow.Cells(4).Text = FormatNumber(p_dataTotal1.Compute("sum(price)", ""), 2)

            Me.objDerived.Execute("[dbo].[get_update_price]'" & p_dataTotal1.Rows(gvr.RowIndex)("price") & "'," & Me.gvTotal1.DataKeys.Item(gvr.RowIndex).Item("pr_invoice_dtl_id"), Data.CommandType.Text)


            'get_update_price()


            ' callEnableButton()
            'ScriptManager.GetCurrent(Me.Page).SetFocus(txtQty)

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        Dim dt, dt2 As New DataTable
        Dim dr, dr2 As DataRow

        Dim invdtl As New DataTable
        Dim isexist As Boolean


        If Me.txtinvfrom.Text = "" Or Me.txtinvto.Text = "" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please input invoice number.")
            ModalPopupExtender2.Show()

        ElseIf CType(Me.txtinvfrom.Text, Long) > CType(Me.txtinvto.Text, Long) Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please check the invoice number.")
            ModalPopupExtender2.Show()
        Else
            invdtl = Me.objDerived.GetDataTable("[AMS].[get_detail_per_invoice]'" & Me.txtinvfrom.Text & "','" & Me.txtinvto.Text & "'", Data.CommandType.Text)

            '-----identifying invoice existance 
            If p_dataTotal1 Is Nothing Then



                For i As Integer = 0 To invdtl.Rows.Count - 1

                    If p_dataTotal1 Is Nothing Then

                        dt.Columns.Add("pr_invoice_hdr_id", GetType(Long))
                        dt.Columns.Add("pr_period_key_id", GetType(Long))
                        dt.Columns.Add("pr_invoice_dtl_id", GetType(Long))
                        dt.Columns.Add("Item_ID", GetType(Long))
                        dt.Columns.Add("Item_Desc", GetType(String))
                        dt.Columns.Add("qty", GetType(Decimal))
                        dt.Columns.Add("price", GetType(Decimal))
                        dt.Columns.Add("rc_id", GetType(Long))
                        dt.Columns.Add("function_id", GetType(Long))
                        dt.Columns.Add("Invoice_No", GetType(Long))

                        dr = dt.NewRow
                        dr("pr_invoice_hdr_id") = invdtl.Rows(i).Item("pr_invoice_hdr_id")
                        dr("pr_period_key_id") = invdtl.Rows(i).Item("pr_period_key_id")
                        dr("pr_invoice_dtl_id") = invdtl.Rows(i).Item("pr_invoice_dtl_id")
                        dr("Item_ID") = invdtl.Rows(i).Item("Item_ID")
                        dr("Item_Desc") = invdtl.Rows(i).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                        dr("qty") = invdtl.Rows(i).Item("qty")
                        dr("price") = invdtl.Rows(i).Item("price")
                        dr("rc_id") = invdtl.Rows(i).Item("rc_id")
                        dr("function_id") = invdtl.Rows(i).Item("function_id")
                        dr("Invoice_No") = invdtl.Rows(i).Item("Invoice_No")

                        dt.Rows.Add(dr)

                        p_dataTotal1 = dt



                    Else

                        dt = p_dataTotal1
                        dr = dt.NewRow
                        dr("pr_invoice_hdr_id") = invdtl.Rows(i).Item("pr_invoice_hdr_id")
                        dr("pr_period_key_id") = invdtl.Rows(i).Item("pr_period_key_id")
                        dr("pr_invoice_dtl_id") = invdtl.Rows(i).Item("pr_invoice_dtl_id")
                        dr("Item_ID") = invdtl.Rows(i).Item("Item_ID")
                        dr("Item_Desc") = invdtl.Rows(i).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                        dr("qty") = invdtl.Rows(i).Item("qty")
                        dr("price") = invdtl.Rows(i).Item("price")
                        dr("rc_id") = invdtl.Rows(i).Item("rc_id")
                        dr("function_id") = invdtl.Rows(i).Item("function_id")
                        dr("Invoice_No") = invdtl.Rows(i).Item("Invoice_No")

                        dt.Rows.Add(dr)
                        p_dataTotal1 = dt

                    End If



                Next


            Else





                For x As Integer = 0 To invdtl.Rows.Count - 1


                    For x2 As Integer = 0 To p_dataTotal1.Rows.Count - 1

                        If invdtl.Rows(x).Item("Invoice_no") = p_dataTotal1.Rows(x2).Item("Invoice_no") Then
                            isexist = True
                        Else
                            isexist = False
                        End If

                    Next


                    If isexist = True Then

                    Else


                        If p_dataTotal2 Is Nothing Then

                            dt2.Columns.Add("pr_invoice_hdr_id", GetType(Long))
                            dt2.Columns.Add("pr_period_key_id", GetType(Long))
                            dt2.Columns.Add("pr_invoice_dtl_id", GetType(Long))
                            dt2.Columns.Add("Item_ID", GetType(Long))
                            dt2.Columns.Add("Item_Desc", GetType(String))
                            dt2.Columns.Add("qty", GetType(Decimal))
                            dt2.Columns.Add("price", GetType(Decimal))
                            dt2.Columns.Add("rc_id", GetType(Long))
                            dt2.Columns.Add("function_id", GetType(Long))
                            dt2.Columns.Add("Invoice_No", GetType(Long))

                            dr2 = dt2.NewRow
                            dr2("pr_invoice_hdr_id") = invdtl.Rows(x).Item("pr_invoice_hdr_id")
                            dr2("pr_period_key_id") = invdtl.Rows(x).Item("pr_period_key_id")
                            dr2("pr_invoice_dtl_id") = invdtl.Rows(x).Item("pr_invoice_dtl_id")
                            dr2("Item_ID") = invdtl.Rows(x).Item("Item_ID")
                            dr2("Item_Desc") = invdtl.Rows(x).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                            dr2("qty") = invdtl.Rows(x).Item("qty")
                            dr2("price") = invdtl.Rows(x).Item("price")
                            dr2("rc_id") = invdtl.Rows(x).Item("rc_id")
                            dr2("function_id") = invdtl.Rows(x).Item("function_id")
                            dr2("Invoice_No") = invdtl.Rows(x).Item("Invoice_No")

                            dt2.Rows.Add(dr2)

                            p_dataTotal2 = dt2

                        Else

                            dt2 = p_dataTotal2
                            dr2 = dt2.NewRow
                            dr2("pr_invoice_hdr_id") = invdtl.Rows(x).Item("pr_invoice_hdr_id")
                            dr2("pr_period_key_id") = invdtl.Rows(x).Item("pr_period_key_id")
                            dr2("pr_invoice_dtl_id") = invdtl.Rows(x).Item("pr_invoice_dtl_id")
                            dr2("Item_ID") = invdtl.Rows(x).Item("Item_ID")
                            dr2("Item_Desc") = invdtl.Rows(x).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                            dr2("qty") = invdtl.Rows(x).Item("qty")
                            dr2("price") = invdtl.Rows(x).Item("price")
                            dr2("rc_id") = invdtl.Rows(x).Item("rc_id")
                            dr2("function_id") = invdtl.Rows(x).Item("function_id")
                            dr2("Invoice_No") = invdtl.Rows(x).Item("Invoice_No")

                            dt2.Rows.Add(dr2)
                            p_dataTotal2 = dt2

                        End If


                    End If

                Next

                '------------  end here



                If p_dataTotal2 Is Nothing Then

                Else



                    For i As Integer = 0 To p_dataTotal2.Rows.Count - 1

                        If p_dataTotal1 Is Nothing Then

                            dt.Columns.Add("pr_invoice_hdr_id", GetType(Long))
                            dt.Columns.Add("pr_period_key_id", GetType(Long))
                            dt.Columns.Add("pr_invoice_dtl_id", GetType(Long))
                            dt.Columns.Add("Item_ID", GetType(Long))
                            dt.Columns.Add("Item_Desc", GetType(String))
                            dt.Columns.Add("qty", GetType(Decimal))
                            dt.Columns.Add("price", GetType(Decimal))
                            dt.Columns.Add("rc_id", GetType(Long))
                            dt.Columns.Add("function_id", GetType(Long))
                            dt.Columns.Add("Invoice_No", GetType(Long))

                            dr = dt.NewRow
                            dr("pr_invoice_hdr_id") = p_dataTotal2.Rows(i).Item("pr_invoice_hdr_id")
                            dr("pr_period_key_id") = p_dataTotal2.Rows(i).Item("pr_period_key_id")
                            dr("pr_invoice_dtl_id") = p_dataTotal2.Rows(i).Item("pr_invoice_dtl_id")
                            dr("Item_ID") = p_dataTotal2.Rows(i).Item("Item_ID")
                            dr("Item_Desc") = p_dataTotal2.Rows(i).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                            dr("qty") = p_dataTotal2.Rows(i).Item("qty")
                            dr("price") = p_dataTotal2.Rows(i).Item("price")
                            dr("rc_id") = p_dataTotal2.Rows(i).Item("rc_id")
                            dr("function_id") = p_dataTotal2.Rows(i).Item("function_id")
                            dr("Invoice_No") = p_dataTotal2.Rows(i).Item("Invoice_No")

                            dt.Rows.Add(dr)

                            p_dataTotal1 = dt



                        Else

                            dt = p_dataTotal1
                            dr = dt.NewRow
                            dr("pr_invoice_hdr_id") = p_dataTotal2.Rows(i).Item("pr_invoice_hdr_id")
                            dr("pr_period_key_id") = p_dataTotal2.Rows(i).Item("pr_period_key_id")
                            dr("pr_invoice_dtl_id") = p_dataTotal2.Rows(i).Item("pr_invoice_dtl_id")
                            dr("Item_ID") = p_dataTotal2.Rows(i).Item("Item_ID")
                            dr("Item_Desc") = p_dataTotal2.Rows(i).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                            dr("qty") = p_dataTotal2.Rows(i).Item("qty")
                            dr("price") = p_dataTotal2.Rows(i).Item("price")
                            dr("rc_id") = p_dataTotal2.Rows(i).Item("rc_id")
                            dr("function_id") = p_dataTotal2.Rows(i).Item("function_id")
                            dr("Invoice_No") = p_dataTotal2.Rows(i).Item("Invoice_No")

                            dt.Rows.Add(dr)
                            p_dataTotal1 = dt

                        End If



                    Next
                    p_dataTotal2 = Nothing
                End If
            End If
            gvTotal1.DataSource = p_dataTotal1
            gvTotal1.DataBind()

            If p_dataTotal1 Is Nothing Then

                ' gvTotal1.FooterRow.Cells(4).Text = FormatNumber(0, 2)

            Else
                For x As Integer = 0 To p_dataTotal1.Rows.Count - 1


                    Dim txtprice2 As TextBox = CType(Me.gvTotal1.Rows(x).Cells(0).FindControl("txtprice2"), TextBox)
                    txtprice2.Text = FormatNumber(txtprice2.Text, 2)
                Next
                gvTotal1.FooterRow.Cells(4).Text = FormatNumber(p_dataTotal1.Compute("sum(price)", ""), 2)
            End If

   



        End If
        'p_dataTotal2 = Nothing
        Me.txtinvfrom.Text = ""
        Me.txtinvto.Text = ""

    End Sub

    Protected Sub btncheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncheck.Click
    Try
            Me.Session("pr_period_key_id") = p_pr_period_key.Rows(0)("pr_period_key_id")
            Dim url As String = "rpt_purchase_request_gasoline_summaryrpt_pop_up.aspx"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"

            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Catch ex As Exception

        End Try
        

        '---------- code n macky

        'rpt_purchase_request_gasoline_summaryrpt_pop_up.aspx
        'Me.ModalPopupExtender2.Show()
        'p_dataTotal1 = Nothing
        'gvTotal1.DataSource = p_dataTotal1
        'gvTotal1.DataBind()
        'gvTotal.SelectedIndex = -1
        'pGasolineGoods = objDerived.GetDataTable("[dbo].[getItem_gasoline_peritem]", CommandType.Text)
        ''-------------------
        'gvitems.Columns(3).Visible = True
        'gvitems.Columns(4).Visible = True
        'gvitems.Columns(5).Visible = True
        'gvitems.Columns(6).Visible = True
        'gvitems.Columns(7).Visible = True
        'gvitems.Columns(8).Visible = True
        'gvitems.DataSource = pGasolineGoods
        'gvitems.DataBind()
        'gvitems.Columns(3).Visible = False
        'gvitems.Columns(4).Visible = False
        'gvitems.Columns(5).Visible = False
        'gvitems.Columns(6).Visible = False
        'gvitems.Columns(7).Visible = False
        'gvitems.Columns(8).Visible = False
        'pOffice = objDerived.GetDataTable("select * from ams.pr_gas_office", CommandType.Text)
        'pOffice2 = objDerived.GetDataTable("[ams].[gettop_rcvarious]", CommandType.Text)
        'Me.GVoffices.DataSource = pOffice
        'Me.GVoffices.DataBind()
        'Me.GVvarious.DataSource = pOffice
        'Me.GVvarious.DataBind()
        'Me.txtDepartment.Text = ""
        'txtInvoiceNumber.Text = objDerived.GetValue("SELECT TOP (1) Invoice_No  FROM  AMS.pr_invoice_hdr  ORDER BY pr_invoice_hdr_id DESC ", CommandType.Text) + 1
        'Me.gvitems.Enabled = False
        'pInvoice = Nothing
        'gvInvoice.DataSource = createDataTable(9)
        'gvInvoice.DataBind()
        'btnSave.Enabled = False
        '-------------------------------------------------------
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        p_dataTotal1 = Nothing
    End Sub

    'Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click

    'End Sub

    Protected Sub txtqnty2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

        
            Dim txtqty2 As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtqty2.NamingContainer, GridViewRow)
            Dim txtPrice2 As TextBox = TryCast(sender, TextBox)
            Dim gvr2 As GridViewRow = TryCast(txtPrice2.NamingContainer, GridViewRow)

            If txtqty2.Text = "" Then
                txtqty2.Text = "0.00"
            End If
            txtqty2.Text = FormatNumber(txtqty2.Text, 2)
            Me.Session("rowindex") = gvr.RowIndex
            ' Dim txtQty As TextBox = CType(Me.gvTotal1.Rows(gvr.RowIndex + 1).Cells(1).FindControl("txtqnty2"), TextBox)
            p_dataTotal1.Rows(gvr.RowIndex)("qty") = txtqty2.Text

            txtPrice2.Text = FormatNumber(txtPrice2.Text, 2)


            ' gvTotal1.FooterRow.Cells(4).Text = FormatNumber(p_dataTotal1.Compute("sum(price)", ""), 2)

            Me.objDerived.Execute("[dbo].[get_update_qty2]'" & p_dataTotal1.Rows(gvr.RowIndex)("qty") & "'," & Me.gvTotal1.DataKeys.Item(gvr.RowIndex).Item("pr_invoice_dtl_id"), Data.CommandType.Text)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CB1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim dt, dt2 As New DataTable
        Dim dr As DataRow


        'Dim cb1 As CheckBox = TryCast(sender, CheckBox)
        'Dim gvr As GridViewRow = TryCast(cb1.NamingContainer, GridViewRow)



        ''cb1.Enabled = FormatNumber(cb1.Text, 2)
        'Me.Session("rowindex") = gvr.RowIndex
        '' Dim txtQty As TextBox = CType(Me.gvTotal1.Rows(gvr.RowIndex + 1).Cells(1).FindControl("txtqnty2"), TextBox)
        'p_dataTotal1.Rows(gvr.RowIndex)("qty") = cb1.Text



        For i As Integer = 0 To p_dataTotal1.Rows.Count - 1

            If cbtbl Is Nothing Then

                dt.Columns.Add("pr_invoice_hdr_id", GetType(Long))
                dt.Columns.Add("pr_period_key_id", GetType(Long))
                dt.Columns.Add("pr_invoice_dtl_id", GetType(Long))
                dt.Columns.Add("Item_ID", GetType(Long))
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("qty", GetType(Decimal))
                dt.Columns.Add("price", GetType(Decimal))
                dt.Columns.Add("rc_id", GetType(Long))
                dt.Columns.Add("function_id", GetType(Long))
                dt.Columns.Add("Invoice_No", GetType(Long))
                dt.Columns.Add("ishide", GetType(String))


                dr = dt.NewRow
                dr("pr_invoice_hdr_id") = p_dataTotal1.Rows(i).Item("pr_invoice_hdr_id")
                dr("pr_period_key_id") = p_dataTotal1.Rows(i).Item("pr_period_key_id")
                dr("pr_invoice_dtl_id") = p_dataTotal1.Rows(i).Item("pr_invoice_dtl_id")
                dr("Item_ID") = p_dataTotal1.Rows(i).Item("Item_ID")
                dr("Item_Desc") = p_dataTotal1.Rows(i).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                dr("qty") = p_dataTotal1.Rows(i).Item("qty")
                dr("price") = p_dataTotal1.Rows(i).Item("price")
                dr("rc_id") = p_dataTotal1.Rows(i).Item("rc_id")
                dr("function_id") = p_dataTotal1.Rows(i).Item("function_id")
                dr("Invoice_No") = p_dataTotal1.Rows(i).Item("Invoice_No")



                Dim cb As CheckBox = CType(Me.gvTotal1.Rows(i).Cells(0).FindControl("Cb1"), CheckBox)
                Dim a As Integer
                If cb.Checked = False Then
                    a = 1
                Else
                    a = 2
                End If
                dr("ishide") = a

                ' FindControl("CheckBox1")

                dt.Rows.Add(dr)

                cbtbl = dt



            Else

                dt = cbtbl
                dr = dt.NewRow
                dr("pr_invoice_hdr_id") = p_dataTotal1.Rows(i).Item("pr_invoice_hdr_id")
                dr("pr_period_key_id") = p_dataTotal1.Rows(i).Item("pr_period_key_id")
                dr("pr_invoice_dtl_id") = p_dataTotal1.Rows(i).Item("pr_invoice_dtl_id")
                dr("Item_ID") = p_dataTotal1.Rows(i).Item("Item_ID")
                dr("Item_Desc") = p_dataTotal1.Rows(i).Item("Item_Desc") ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                dr("qty") = p_dataTotal1.Rows(i).Item("qty")
                dr("price") = p_dataTotal1.Rows(i).Item("price")
                dr("rc_id") = p_dataTotal1.Rows(i).Item("rc_id")
                dr("function_id") = p_dataTotal1.Rows(i).Item("function_id")
                dr("Invoice_No") = p_dataTotal1.Rows(i).Item("Invoice_No")

                Dim cb As CheckBox = CType(Me.gvTotal1.Rows(i).Cells(0).FindControl("Cb1"), CheckBox)
                Dim a As Integer
                If cb.Checked = False Then
                    a = 1
                Else
                    a = 2
                End If

                dr("ishide") = a
                dt.Rows.Add(dr)
                cbtbl = dt

            End If





        Next
        Dim totalamount, amount As Decimal
        For x As Integer = 0 To cbtbl.Rows.Count - 1
            Dim txtprice3 As TextBox = CType(Me.gvTotal1.Rows(x).Cells(0).FindControl("txtprice2"), TextBox)
            Dim txtqty As TextBox = CType(Me.gvTotal1.Rows(x).Cells(0).FindControl("txtqnty2"), TextBox)



            If cbtbl.Rows(x).Item("ishide") = 1 Then


                amount = cbtbl.Rows(x).Item("price")
                totalamount = totalamount + amount


                txtprice3.Enabled = True
                txtqty.Enabled = True
            Else

               
                txtprice3.Enabled = False
                txtqty.Enabled = False
            End If

            Dim txtprice2 As TextBox = CType(Me.gvTotal1.Rows(x).Cells(0).FindControl("txtprice2"), TextBox)
            txtprice2.Text = FormatNumber(txtprice2.Text, 2)
        Next

        gvTotal1.FooterRow.Cells(4).Text = FormatNumber(totalamount, 2)
        cbtbl = Nothing


    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Me.Session("pr_period_key_id") = p_pr_period_key.Rows(0)("pr_period_key_id")
            Dim url As String = "rpt_purchase_request_gasoline_detailed_pop_up.aspx"
            Dim fullURL As String = " var win= window.open('" + url + "', '_blank', 'status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=600,left=250,top=100');"
            ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSOA.SelectedIndexChanged

    End Sub

    Protected Sub gvitems_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        'optimize code
        For i As Integer = 3 To 8
            gvitems.Columns(i).Visible = True
        Next


        'gvitems.Columns(3).Visible = True
        'gvitems.Columns(4).Visible = True
        'gvitems.Columns(5).Visible = True
        'gvitems.Columns(6).Visible = True
        'gvitems.Columns(7).Visible = True
        'gvitems.Columns(8).Visible = True
        gvitems.DataSource = pGasolineGoods
        gvitems.PageIndex = e.NewPageIndex
        gvitems.DataBind()

        'optimize code
        For i As Integer = 3 To 8
            gvitems.Columns(i).Visible = False
        Next

        'gvitems.Columns(3).Visible = False
        'gvitems.Columns(4).Visible = False
        'gvitems.Columns(5).Visible = False
        'gvitems.Columns(6).Visible = False
        'gvitems.Columns(7).Visible = False
        'gvitems.Columns(8).Visible = False
    End Sub

    Protected Sub gvitems_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            Dim sumObject As Integer


            'refactor code
            For i As Integer = 3 To 8
                gvitems.Columns(i).Visible = True
            Next
            'gvitems.Columns(3).Visible = True
            'gvitems.Columns(4).Visible = True
            'gvitems.Columns(5).Visible = True
            'gvitems.Columns(6).Visible = True

            'gvitems.Columns(7).Visible = True
            'gvitems.Columns(8).Visible = True
            Dim dt, dt_GA_ID As New DataTable
            Dim dr, dr_GA_ID As DataRow
            Dim cb As CheckBox

            If pInvoice Is Nothing Then
                dt.Columns.Add("id", GetType(Integer))
                dt.Columns.Add("rows_id", GetType(Integer))
                dt.Columns.Add("Item_Desc", GetType(String))
                dt.Columns.Add("Description", GetType(String))
                dt.Columns.Add("qty", GetType(Decimal))
                dt.Columns.Add("cost", GetType(Decimal))
                dt.Columns.Add("Item_ID", GetType(Integer))
                dt.Columns.Add("isVisible", GetType(Boolean))
                dt.Columns.Add("ReadOnly", GetType(Boolean))
                dt.Columns.Add("GA_ID", GetType(Integer))
                dt.Columns.Add("BGA_ID", GetType(Integer))

                dt_GA_ID.Columns.Add("GA_ID", GetType(Integer))
                dt_GA_ID.Columns.Add("BGA_ID", GetType(Integer))
                ' For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                ' cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                ' If cb.Checked = True Then
                dr = dt.NewRow
                dr("id") = 1
                dr("rows_id") = gvitems.SelectedDataKey(4)
                dr("Item_Desc") = gvitems.SelectedDataKey(1)
                dr("Description") = gvitems.SelectedDataKey(2)
                dr("qty") = "0.00"
                dr("cost") = gvitems.SelectedDataKey(5) ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                dr("Item_ID") = gvitems.SelectedDataKey(3)
                dr("isVisible") = True
                dr("ReadOnly") = False
                dr("GA_ID") = gvitems.SelectedDataKey(7)
                dr("BGA_ID") = gvitems.SelectedDataKey(8)
                dt.Rows.Add(dr)

                If p_GA_ID Is Nothing Then
                    dr_GA_ID = dt_GA_ID.NewRow
                    dr_GA_ID("GA_ID") = gvitems.SelectedDataKey(7)
                    dr_GA_ID("BGA_ID") = gvitems.SelectedDataKey(8)
                    dt_GA_ID.Rows.Add(dr_GA_ID)
                    p_GA_ID = dt_GA_ID
                Else
                    Dim ds As New DataSet
                    Dim myview As DataView
                    myview = p_GA_ID.DefaultView
                    myview.RowFilter = " GA_ID = '" & (gvitems.SelectedDataKey(7)) & "' and BGA_ID = '" & (gvitems.SelectedDataKey(8)) & "'"
                    If myview.Count() = 0 Then
                        dt_GA_ID = p_GA_ID
                        dr_GA_ID = dt_GA_ID.NewRow
                        dr_GA_ID("GA_ID") = gvitems.SelectedDataKey(7)
                        dr_GA_ID("BGA_ID") = gvitems.SelectedDataKey(8)
                        dt_GA_ID.Rows.Add(dr_GA_ID)
                        p_GA_ID = dt_GA_ID
                    End If
                End If

                'End If
                ' Next
                pInvoice = dt
                gvInvoice.DataSource = pInvoice
                gvInvoice.DataBind()

                sumObject = pInvoice.Compute("count(id)", "id=1")
                If sumObject <= 9 Then
                    pInvoice.Merge(createDataTable(9 - sumObject))
                End If
                Me.Session("CurrentRowCount") = sumObject
            Else
                sumObject = pInvoice.Compute("count(id)", "id=1")
                ' For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                ' cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                ' If cb.Checked = True Then

                dt = pInvoice
                dr = dt.NewRow
                dr("id") = 1
                dr("rows_id") = gvitems.SelectedDataKey(4)
                dr("Item_Desc") = gvitems.SelectedDataKey(1)
                dr("Description") = gvitems.SelectedDataKey(2)
                dr("qty") = "0.00"
                dr("cost") = gvitems.SelectedDataKey(5) ''FormatNumber(objDerived.GetValue("exec AMS.itemprice '" & gvitems.Rows(i).Cells(3).Text & "'", CommandType.Text), 2)
                dr("Item_ID") = gvitems.SelectedDataKey(3)
                dr("isVisible") = True
                dr("ReadOnly") = False
                dr("GA_ID") = gvitems.SelectedDataKey(7)
                dr("BGA_ID") = gvitems.SelectedDataKey(8)
                dt.Rows.Add(dr)
                pInvoice = dt

                '  dt_GA_ID.Columns.Add("GA_ID")
                '  dt_GA_ID.Columns.Add("BGA_ID")
                Dim ds As New DataSet
                Dim myview As DataView
                myview = p_GA_ID.DefaultView
                myview.RowFilter = " GA_ID = '" & (gvitems.SelectedDataKey(7)) & "' and BGA_ID = '" & (gvitems.SelectedDataKey(8)) & "'"
                If myview.Count() = 0 Then
                    dt_GA_ID = p_GA_ID
                    dr_GA_ID = dt_GA_ID.NewRow
                    dr_GA_ID("GA_ID") = gvitems.SelectedDataKey(7)
                    dr_GA_ID("BGA_ID") = gvitems.SelectedDataKey(8)
                    dt_GA_ID.Rows.Add(dr_GA_ID)
                    p_GA_ID = dt_GA_ID
                End If


                If sumObject <= 9 Then
                    For i As Integer = 0 To 10
                        If sumObject + i < 10 Then
                            pInvoice.Rows(9 - i).Delete()
                        Else
                            Exit For
                        End If
                    Next

                    sumObject = pInvoice.Compute("count(id)", "id=1")
                    Me.Session("CurrentRowCount") = sumObject
                    pInvoice.Merge(createDataTable(9 - sumObject))
                End If
            End If
            gvInvoice.DataSource = pInvoice
            gvInvoice.DataBind()


            Dim id As Integer
            id = Me.gvitems.SelectedDataKey(4)
            Dim a1 As Integer = Me.gvitems.SelectedDataKey(4)


            Dim data As DataTable
            data = pGasolineGoods

            'data.Rows(Me.gvitems.SelectedDataKey(4)).Delete()
            data.Rows.RemoveAt(Me.gvitems.SelectedIndex)
            pGasolineGoods = data
            gvitems.DataSource = pGasolineGoods
            gvitems.DataBind()

            'gvitems.Columns(3).Visible = False
            'gvitems.Columns(4).Visible = False
            'gvitems.Columns(5).Visible = False
            'gvitems.Columns(6).Visible = False
            'gvitems.Columns(7).Visible = False
            'gvitems.Columns(8).Visible = False
            'optimize code
            For i As Integer = 3 To 8
                gvitems.Columns(i).Visible = False
            Next

            For i As Integer = 0 To pInvoice.Rows.Count - 1
                If i < sumObject Then
                    Dim txtQty As TextBox = CType(gvInvoice.Rows(i).FindControl("txtqty"), TextBox)
                    Dim txtPrice As TextBox = CType(gvInvoice.Rows(i).FindControl("txtprice"), TextBox)
                    txtQty.ReadOnly = False
                    txtQty.Attributes.Add("onFocus", "this.select()")
                    txtQty.Attributes.Add("onClick", "this.select()")
                    txtPrice.ReadOnly = False
                    txtPrice.Attributes.Add("onFocus", "this.select()")
                    txtPrice.Attributes.Add("onClick", "this.select()")

                End If

            Next
            'gvInvoice.FooterRow.Cells(2).Text = FormatNumber(pInvoice.Compute("sum(cost)", ""), 2)
            'If gvInvoice.FooterRow.Cells(2).Text = "0.00" Then
            '    ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvInvoice.Rows(0).Cells(1).FindControl("txtqty"), TextBox))
            'Else
            '    ScriptManager.GetCurrent(Me.Page).SetFocus(CType(Me.gvInvoice.Rows(sumObject - 1).Cells(1).FindControl("txtqty"), TextBox))
            'End If
            cbVarious.Enabled = False
            ddOffice.Enabled = False
            Me.GVoffices.Enabled = True
            Me.GVvarious.Enabled = True


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Protected Sub lnkReturnGF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim data As DataTable
        'data = pInvoice
        'data.Rows(Me.gvInvoice.SelectedValue).Delete()
    End Sub
    Protected Sub OnRowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub
    Protected Sub gvInvoice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvInvoice.SelectedIndexChanged
        Dim dt As New DataTable
        Dim dr As DataRow
        dt = pGasolineGoods
        dr = pGasolineGoods.NewRow
        dr("id") = gvInvoice.SelectedDataKey("rows_id")
        dr("Item_Desc") = gvInvoice.SelectedDataKey("Item_Desc")
        dr("Description") = gvInvoice.SelectedDataKey("Description")
        dr("Qty") = "0"
        dr("Item_ID") = gvInvoice.SelectedDataKey("Item_ID")
        dr("cost") = gvInvoice.SelectedDataKey("cost")
        dr("GA_ID") = gvInvoice.SelectedDataKey("GA_ID")
        dr("BGA_ID") = gvInvoice.SelectedDataKey("BGA_ID")
        dr("AllotmentClass_ID") = 2
        pGasolineGoods.Rows.InsertAt(dr, gvInvoice.SelectedDataKey("rows_id"))
        pGasolineGoods = dt
        gvitems.DataSource = pGasolineGoods
        gvitems.DataBind()


        Dim data As DataTable
        Dim a As String = Me.gvInvoice.SelectedIndex
        data = pInvoice
        data.Rows(a).Delete()
        pInvoice = data

        If pInvoice.Rows.Count > 9 Then
        Else
            pInvoice.Merge(createDataTable(0))
        End If
        gvInvoice.DataSource = pInvoice
        gvInvoice.DataBind()
    End Sub

End Class