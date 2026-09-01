Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control


Partial Class Inventory_t_Donation
    Inherits System.Web.UI.Page

    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private objProperty As New t_property_hdr
    Private propertDtl As New t_property_dtl
    'Private objPropertyAdjust As New PropertyAdjust
    Dim msg As New MsgeBox

#Region "Property"

    Private Property pListOBR() As DataTable
        Get
            Return CType(Session("pListOBR"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pListOBR") = value
        End Set
    End Property
    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property
    Private Property pPopupitems() As DataTable
        Get
            Return CType(Session("pPopupitems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPopupitems") = value
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
    Private Property popen() As DataTable
        Get
            Return CType(Session("popen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("popen") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'obj.GetAccessRight(Me.Session("@UserName"), Page)

            'If obj.HasAccess = False Then
            '    Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            'End If
            'drpfund.DataSource = Nothing
            'drpfund.DataBind()
            objDerived.loadDrpDwnList(Me.drpfund, "F_ID", "Description", "ACCNTG.Funds")
            Me.txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")
            gvbody.DataSource = Nothing
            gvbody.DataBind()


            pItems = Nothing
            Me.gvitems.Columns(3).Visible = True
            gvitems.DataSource = Nothing
            gvitems.DataBind()
            pPopupitems = objDerived.GetDataTable("exec [AMS].[sp_loadProperty_Donation]", CommandType.Text)
            gvitems.DataSource = pPopupitems
            gvitems.DataBind()
            Me.gvitems.Columns(3).Visible = False
            Me.txtprdate.Text = Date.Today.ToString("MM/dd/yyyy")
            Me.btnadd.Enabled = True
            Me.btnSave.Enabled = False
            btnpreview.Enabled = False
            gvbody.DataSource = Nothing
            gvbody.DataBind()
            ' drpfund.Enabled = True

            'popen = objDerived.GetDataTable("exec ams.CapitalOutlayManualOpen", CommandType.Text)
            'gvopen.DataSource = popen
            'gvopen.DataBind()
        End If
    End Sub

    Public Sub gridEnable()
        Dim cb As CheckBox ', cbheader
        Dim itemid As Integer
        Dim txt As Integer
        Dim gv As New GridView
        gvitems.Columns(3).Visible = True
        gv.DataSource = pItems
        gv.DataBind()
        Dim countE As Integer = 0
        For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            itemid = CType(Me.gvitems.Rows(i).Cells(3).Text, Integer)
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            For o As Integer = 0 To gv.Rows.Count - 1
                txt = CType(gv.Rows(o).Cells(5).Text, Integer)

                If txt = itemid Then
                    cb.Checked = False
                    cb.Enabled = False
                    countE = countE + 1
                End If

            Next
        Next
        If countE = 8 Then
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = False

        Else
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = True

        End If
        gvitems.Columns(3).Visible = False
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim cb As CheckBox
            '      Dim lblitemdesc, lblunit, lblitemid As String
            Dim tb2, tb3, tb4, tb5 As New TextBox
            Dim dr As DataRow 'dr2, dr3
            Dim dt As New DataTable
            dt.Columns.Add("item_desc")
            dt.Columns.Add("Description")
            dt.Columns.Add("qty")
            dt.Columns.Add("price", GetType(Decimal))
            dt.Columns.Add("total", GetType(Decimal))
            dt.Columns.Add("Item_ID")
            dt.Columns.Add("code")

            If pItems Is Nothing Then
                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)



                    If cb.Checked = True Then
                        dr = dt.NewRow
                        dr("item_desc") = gvitems.Rows(i).Cells(1).Text
                        dr("Description") = gvitems.Rows(i).Cells(2).Text
                        dr("qty") = "0"
                        dr("price") = CType("0.00", Decimal)
                        dr("total") = CType("0.00", Decimal)
                        dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
                        dr("code") = pPopupitems.Rows(i)("GA_ID")
                        dt.Rows.Add(dr)
                    End If
                Next
                pItems = dt

            Else
                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                    If cb.Checked = True Then
                        dt = pItems
                        dr = dt.NewRow
                        dr("item_desc") = gvitems.Rows(i).Cells(1).Text
                        dr("Description") = gvitems.Rows(i).Cells(2).Text
                        dr("qty") = "0"
                        dr("price") = CType("0.00", Decimal)
                        dr("total") = CType("0.00", Decimal)
                        dr("Item_ID") = gvitems.Rows(i).Cells(3).Text
                        dr("code") = pPopupitems.Rows(i)("GA_ID")
                        dt.Rows.Add(dr)
                        pItems = dt
                    End If
                Next
            End If
            gvbody.DataSource = pItems
            gvbody.DataBind()
            gridEnable()
            Me.Session("search") = False
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Dim qty As TextBox = CType(Me.gvbody.Rows(i).Cells(2).FindControl("txtqty"), TextBox)
                qty.Attributes.Add("onclick", "this.select()")
                qty.Attributes.Add("onFocus", "this.select()")
            Next
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'If pItems.Compute("sum(total)", "") = 0 Then
            '    CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = "0.00"
            'Else
            '    CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'End If
        Catch ex As Exception

        End Try
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

    Protected Sub txtqty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtqty As TextBox = TryCast(sender, TextBox)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)



            gvbody.Rows(gvr.RowIndex).Cells(4).Text = FormatNumber(CType(txtqty.Text, Integer) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal), 2)
            pItems.Rows(gvr.RowIndex)("qty") = CType(txtqty.Text, Integer)
            pItems.Rows(gvr.RowIndex)("total") = FormatNumber(CType(txtqty.Text, Integer) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox).Text, Decimal), 2)
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            If gvbody.FooterRow.Cells(4).Text = "0.00" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If

            Dim txtcost As TextBox = CType(gvbody.Rows(gvr.RowIndex).FindControl("txtcost"), TextBox)
            txtcost.Attributes.Add("onFocus", "this.select()")
            txtcost.Attributes.Add("onClick", "this.select()")
            txtcost.Focus()



        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtcost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            If txtcost.Text = "" Then
                txtcost.Text = "0.00"
            End If
            txtcost.Text = FormatNumber(txtcost.Text, 2)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            gvbody.Rows(gvr.RowIndex).Cells(4).Text = FormatNumber(CType(txtcost.Text, Decimal) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox).Text, Integer))

            pItems.Rows(gvr.RowIndex)("price") = CType(txtcost.Text, Decimal)
            pItems.Rows(gvr.RowIndex)("total") = FormatNumber(CType(txtcost.Text, Decimal) * CType(CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox).Text, Integer))
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)

            If gvbody.FooterRow.Cells(4).Text = "0.00" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
            Dim txtqty As TextBox = CType(gvbody.Rows(gvr.RowIndex + 1).FindControl("txtqty"), TextBox)
            txtqty.Attributes.Add("onFocus", "this.select()")
            txtqty.Attributes.Add("onClick", "this.select()")
            txtqty.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim transactionID As Integer = objDerived.GetValue("select top 1 AIRDtl_ID from AMS.property order by AIRDtl_ID desc", CommandType.Text)
            Session("transactionID") = transactionID + 1
            For i As Integer = 0 To gvbody.Rows.Count - 1
                If gvbody.Rows(i).Cells(4).Text <> "0.00" Then
                    objProperty.Property_Date = txtprdate.Text
                    objProperty.Property_code = pItems.Rows(i)("code")
                    objProperty.Item_ID = pItems.Rows(i)("Item_ID")
                    objProperty.Qty = pItems.Rows(i)("qty")
                    objProperty.Balance = pItems.Rows(i)("qty")
                    objProperty.Issuance = "0"
                    objProperty.Cost = pItems.Rows(i)("price")
                    objProperty.RC_ID = 0
                    objProperty.Remarks = "0"
                    objProperty.isDonated = True
                    objProperty.GA_ID = pPopupitems.Rows(i)("GA_ID")
                    objProperty.F_ID = Me.drpfund.SelectedItem.Value 'objDerived.GetValue("SELECT     F_ID FROM ACCNTG.Funds WHERE     FundCode ='" & drpfund.SelectedValue.ToString & "' ", CommandType.Text)
                    objProperty.AIRDtl_ID = IIf(transactionID = 0, 1, transactionID + 1)
                    objProperty.DonationRemarks = txtremarks.Text
                    Dim Property_ID As Long = objProperty.save()
                    Me.Session("id2") = Property_ID
                    'objPropertyAdjust.AdjQty = ("0")
                    'objPropertyAdjust.Property_ID = Property_ID
                    'objPropertyAdjust.Remarks = ("None")
                    'If i = 0 Then
                    '    Me.Session("id1") = Property_ID

                    'End If
                    'objPropertyAdjust.saveAdjustProperty()

                    For cnt As Integer = 0 To CType(CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text, Integer) - 1
                        propertDtl.PropertyNo = objDerived.GetValue("select dbo.func_GeneratePropertyNo('" & Date.Today.ToString("MM/dd/yyyy") & "','" & pItems.Rows(i)("code") & "')", CommandType.Text)
                        propertDtl.Property_ID = Property_ID
                        ' propertDtl.RC_ID = 0
                        propertDtl.Status = True
                        propertDtl.Issued = False
                        propertDtl.Dispose = False
                        propertDtl.Repair = False
                        propertDtl.DisposeDate = "01/01/1900"
                        propertDtl.IsInspectionForDisposal = False
                        propertDtl.InspectionDate = "01/01/1900"
                        'propertDtl.Details = ""
                        propertDtl.save()

                    Next
                End If
            Next

            Me.btnSave.Enabled = False
            Me.btnadd.Enabled = False
            btnpreview.Enabled = True
            drpfund.Enabled = False

            Dim myview As DataView
            myview = pItems.DefaultView

            myview.RowFilter = "total <> 0.00 "
            gvbody.DataSource = myview
            gvbody.DataBind()
            gvbody.FooterRow.Cells(4).Text = FormatNumber(pItems.Compute("sum(total)", ""), 2)
            'popen = objDerived.GetDataTable("exec ams.CapitalOutlayManualOpen", CommandType.Text)
            'gvopen.DataSource = popen
            'gvopen.DataBind()
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).ReadOnly = True
                CType(gvbody.Rows(i).FindControl("txtcost"), TextBox).ReadOnly = True
            Next
            msg.UserMsgBox("Transaction succesfully saved.", Me, False)
        Catch ex As Exception

        End Try
    End Sub
End Class
