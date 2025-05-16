Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class Disposal_frm_waste_materials
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim hdr As New WMR_hdr
    Dim dtl As New WMR_dtl
    Private Property pItems() As DataTable
        Get
            Return CType(Session("pItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pItems") = value
        End Set
    End Property
    Private Property pBody() As DataTable
        Get
            Return CType(Session("pBody"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBody") = value
        End Set
    End Property

    Public Sub gridEnable()
        gvitems.Columns(6).Visible = True
        gvitems.Columns(7).Visible = True
        Dim cb As CheckBox ', cbheader 
        Dim itemid As String
        Dim icsbody As String
        Dim icspopup As String
        Dim txt As String
        Dim gv As New GridView

        gv.DataSource = pBody
        gv.DataBind()
        Dim countE As Integer = 0
        For i As Integer = 0 To Me.gvitems.Rows.Count - 1
            itemid = Me.gvitems.Rows(i).Cells(6).Text.Trim
            icspopup = Me.gvitems.Rows(i).Cells(7).Text.Trim
            cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
            For o As Integer = 0 To gv.Rows.Count - 1
                txt = gv.Rows(o).Cells(0).Text.Trim
                icsbody = gv.Rows(o).Cells(8).Text.Trim
                If txt = itemid And icsbody = icspopup Then
                    cb.Checked = False
                    cb.Enabled = False
                    countE = countE + 1
                End If

            Next
        Next
        If countE = gvitems.Rows.Count - 1 Then
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = False

        Else
            CType(Me.gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = True

        End If
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)

            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If
            txtfrom.Text = objDerived.GetValue("exec AMS.getsignatories 'Property Officer'", CommandType.Text)
            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = False
            btnadd.Enabled = False
            btnpreview.Enabled = False
            txtdate.ReadOnly = True
            txtpurpose.ReadOnly = True
            pItems = Nothing
            pItems = objDerived.GetDataTable("select * from ams.WMRSupplies", CommandType.Text)
            pBody = Nothing
            gvbody.DataSource = pBody
            gvbody.DataBind()
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.DataSource = pItems
            gvitems.DataBind()
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try

            hdr.WM_Date = txtdate.Text
            hdr.Placeofstorage = txtpurpose.Text
            hdr.Certifiedby = txtfrom.Text
            hdr.Approvedby = ""
            hdr.Inspector = ""
            hdr.Witness = ""
            Dim hdrid As Long = hdr.save
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                If pBody.Rows(i)("md") <> 0 Then
                    dtl.WMHdr_ID = hdrid
                    dtl.ICSDt_lID = pBody.Rows(i)("ICSDt_lID")
                    dtl.Item_ID = pBody.Rows(i)("Item_ID")
                    dtl.Qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Text
                    dtl.MD = pBody.Rows(i)("md")
                    dtl.ORNUMEBER = pBody.Rows(i)("OR")
                    dtl.amount = CType(gvbody.Rows(i).FindControl("txtamount"), TextBox).Text
                    dtl.Donee = pBody.Rows(i)("Donee")
                    dtl.save()
                    Dim qty2 As Integer = CType(pBody.Rows(i)("qty2"), Integer)
                    Dim qty As Integer = CType(pBody.Rows(i)("qty"), Integer)
                    Dim balanace As Integer = qty2 - qty
                    objDerived.GetRecords("Update  AMS.ICS_Dtl set Qty2 = '" & balanace & "'  where ICSDt_lID='" & pBody.Rows(i)("ICSDt_lID") & "' and item_id='" & pBody.Rows(i)("Item_ID") & "'", CommandType.Text)
                End If
            Next
            msg.UserMsgBox("Transaction has been succesfully saved", Me, False)
            txtdate.ReadOnly = True
            CalendarExtender2.Enabled = False

            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = False
            btnadd.Enabled = False
            btnpreview.Enabled = True
            txtpurpose.ReadOnly = False
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvitems.PageIndexChanging
        gvitems.Columns(6).Visible = True
        gvitems.Columns(7).Visible = True
        Me.gvitems.DataSource = CType(pItems, DataTable)
        Me.gvitems.DataBind()
        gvitems.SelectedIndex = -1
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
    End Sub

    Protected Sub btnSearch_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        gvitems.Columns(6).Visible = True
        gvitems.Columns(7).Visible = True
        Dim obj As Object
        obj = txtSearch.Text
        Me.gvitems.DataSource = objDerived.Search(pItems, "Item_Desc", obj)
        Me.gvitems.DataBind()
        gvitems.SelectedIndex = -1
        gvitems.PageIndex = 0
        gvitems.Columns(6).Visible = False
        gvitems.Columns(7).Visible = False
    End Sub

    Protected Sub btnload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnload.Click
        Try
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim cb As CheckBox
            '            Dim lblitemdesc, lblunit, lblitemid As String
            dt.Columns.Add("Item_id")
            dt.Columns.Add("Item_desc")
            dt.Columns.Add("Description")
            dt.Columns.Add("qty")
            dt.Columns.Add("qty2")
            dt.Columns.Add("amount", GetType(Decimal))
            dt.Columns.Add("OR")
            dt.Columns.Add("donee")
            dt.Columns.Add("MD")
            dt.Columns.Add("ICSDt_lID")
            If pBody Is Nothing Then


                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                    If cb.Checked = True Then
                        dr = dt.NewRow
                        dr("Item_id") = gvitems.Rows(i).Cells(6).Text
                        dr("Item_desc") = gvitems.Rows(i).Cells(1).Text
                        dr("Description") = gvitems.Rows(i).Cells(2).Text
                        dr("qty") = gvitems.Rows(i).Cells(3).Text
                        dr("qty2") = gvitems.Rows(i).Cells(3).Text
                        dr("amount") = "0.00"
                        dr("OR") = ""
                        dr("donee") = ""
                        dr("MD") = 0
                        dr("ICSDt_lID") = gvitems.Rows(i).Cells(7).Text
                        dt.Rows.Add(dr)
                    End If
                Next
                pBody = dt

            Else
                For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                    cb = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)

                    If cb.Checked = True Then
                        dt = pBody
                        dr = dt.NewRow
                        dr("Item_id") = gvitems.Rows(i).Cells(6).Text
                        dr("Item_desc") = gvitems.Rows(i).Cells(1).Text
                        dr("Description") = gvitems.Rows(i).Cells(2).Text
                        dr("qty") = gvitems.Rows(i).Cells(3).Text
                        dr("qty2") = gvitems.Rows(i).Cells(3).Text
                        dr("amount") = "0.00"
                        dr("OR") = ""
                        dr("donee") = ""
                        dr("MD") = 0
                        dr("ICSDt_lID") = gvitems.Rows(i).Cells(7).Text
                        dt.Rows.Add(dr)
                        pBody = dt
                    End If
                Next
            End If

            gvbody.DataSource = pBody
            gvbody.DataBind()

            gridEnable()


            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                Dim dd As DropDownList = CType(gvbody.Rows(i).FindControl("ddmd"), DropDownList)
                dd.SelectedIndex = pBody.Rows(i)("MD")

                Dim donee As TextBox = CType(gvbody.Rows(i).FindControl("TextBox8"), TextBox)
                Dim ORNUM As TextBox = CType(gvbody.Rows(i).FindControl("TextBox6"), TextBox)
                Dim amount As TextBox = CType(gvbody.Rows(i).FindControl("txtamount"), TextBox)

                If dd.SelectedIndex = 1 Or dd.SelectedIndex = 2 Then
                    donee.Enabled = False
                    ORNUM.Enabled = True
                    amount.Enabled = True
                    donee.Text = ""

                ElseIf dd.SelectedIndex = 3 Then
                    donee.Enabled = False
                    ORNUM.Enabled = False
                    amount.Enabled = False


                    donee.Text = ""
                    ORNUM.Text = ""
                    amount.Text = "0.00"

                ElseIf dd.SelectedIndex = 4 Then
                    donee.Enabled = True
                    ORNUM.Enabled = False
                    amount.Enabled = False

                    ORNUM.Text = ""
                    amount.Text = "0.00"
                Else
                    donee.Enabled = False
                    ORNUM.Enabled = False
                    amount.Enabled = False

                    donee.Text = ""
                    ORNUM.Text = ""
                    amount.Text = "0.00"


                End If

            Next
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            ModalPopupExtender1.Hide()
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
            Dim gvr As GridViewRow = TryCast(txtqty.NamingContainer, GridViewRow)
            If txtqty.Text = "" Then
                txtqty.Text = "0"
            End If










            If CType(txtqty.Text, Decimal) > pBody.Rows(gvr.RowIndex)("Qty") Then
                msg.UserMsgBox("Quantity must not exceed " & pItems.Rows(gvr.RowIndex)("Qty") & "", Me, False)
                '    Dim a As Decimal
                '    Dim b As Decimal

                txtqty.Text = pBody.Rows(gvr.RowIndex)("qty2")
                Dim qty2 As TextBox = CType(gvbody.Rows(gvr.RowIndex).FindControl("txtqty"), TextBox)
                qty2.Attributes.Add("onFocus", "this.select()")
                qty2.Attributes.Add("onClick", "this.select()")
                qty2.Focus()










            Else
                pBody.Rows(gvr.RowIndex)("qty") = txtqty.Text
                'If CType(gvbody.FooterRow.Cells(4).FindControl("lbltotal"), Label).Text = "0.00" Then
                '    btnsave.Enabled = False
                'Else
                '    btnsave.Enabled = True
                'End If
                Dim qty2 As TextBox = CType(gvbody.Rows(gvr.RowIndex + 1).FindControl("txtqty"), TextBox)
                qty2.Attributes.Add("onFocus", "this.select()")
                qty2.Attributes.Add("onClick", "this.select()")
                qty2.Focus()
                btnsave.Enabled = True
            End If




            btnsave.Enabled = True


        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddmd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dd As DropDownList = TryCast(sender, DropDownList)
            Dim gvr As GridViewRow = TryCast(dd.NamingContainer, GridViewRow)

            pBody.Rows(gvr.RowIndex)("MD") = dd.SelectedIndex
            Dim donee As TextBox = CType(gvbody.Rows(gvr.RowIndex).FindControl("TextBox8"), TextBox)
            Dim ORNUM As TextBox = CType(gvbody.Rows(gvr.RowIndex).FindControl("TextBox6"), TextBox)
            Dim amount As TextBox = CType(gvbody.Rows(gvr.RowIndex).FindControl("txtamount"), TextBox)

            If dd.SelectedIndex = 1 Or dd.SelectedIndex = 2 Then
                donee.Enabled = False
                ORNUM.Enabled = True
                amount.Enabled = True
                donee.Text = ""

            ElseIf dd.SelectedIndex = 3 Then
                donee.Enabled = False
                ORNUM.Enabled = False
                amount.Enabled = False


                donee.Text = ""
                ORNUM.Text = ""
                amount.Text = "0.00"

            ElseIf dd.SelectedIndex = 4 Then
                donee.Enabled = True
                ORNUM.Enabled = False
                amount.Enabled = False

                ORNUM.Text = ""
                amount.Text = "0.00"
            Else
                donee.Enabled = False
                ORNUM.Enabled = False
                amount.Enabled = False

                donee.Text = ""
                ORNUM.Text = ""
                amount.Text = "0.00"


            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub TextBox6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtor As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtor.NamingContainer, GridViewRow)
            If txtor.Text = "" Then
                txtor.Text = ""
            End If
            pBody.Rows(gvr.RowIndex)("OR") = txtor.Text
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtamount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtcost As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtcost.NamingContainer, GridViewRow)
            If txtcost.Text = "" Then
                txtcost.Text = "0.00"
            End If
            txtcost.Text = FormatNumber(txtcost.Text, 2)
            pItems.Rows(gvr.RowIndex)("amount") = txtcost.Text
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub TextBox8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtdonee As TextBox = TryCast(sender, TextBox)
            Dim gvr As GridViewRow = TryCast(txtdonee.NamingContainer, GridViewRow)
            If txtdonee.Text = "" Then
                txtdonee.Text = ""
            End If
            pBody.Rows(gvr.RowIndex)("donee") = txtdonee.Text
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            txtfrom.Text = objDerived.GetValue("exec AMS.getsignatories 'Property Officer'", CommandType.Text)
            txtdate.ReadOnly = False
            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = False
            btnadd.Enabled = True
            btnpreview.Enabled = False
            txtdate.ReadOnly = False
            txtpurpose.ReadOnly = False
            pItems = Nothing
            pItems = objDerived.GetDataTable("select * from ams.WMRSupplies", CommandType.Text)
            pBody = Nothing
            gvitems.Columns(6).Visible = True
            gvitems.Columns(7).Visible = True
            gvitems.DataSource = pItems
            gvitems.DataBind()
            gvitems.Columns(6).Visible = False
            gvitems.Columns(7).Visible = False
            txtpurpose.Text = ""
            gvbody.DataSource = pBody
            gvbody.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        msg.UserMsgBox("Need sample Form", Me, False)
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

    End Sub
End Class
