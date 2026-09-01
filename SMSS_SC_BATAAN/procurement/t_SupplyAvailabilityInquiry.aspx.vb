Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.WebControls.Label
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class procurement_t_SupplyAvailabilityInquiry
    Inherits System.Web.UI.Page

    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim hdr As New t_SAI.TbSai_Hdr
    Dim dtl As New t_SAI.TbSai_Dtl


#Region "property"
    Private Property pRC() As DataTable
        Get
            Return CType(Session("pRC"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pRC") = value
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

    Private Property pAccounts() As DataTable
        Get
            Return CType(Session("pAccounts"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAccounts") = value
        End Set

    End Property
    Private Property pListitem() As DataTable
        Get
            Return CType(Session("pListitem"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pListitem") = value
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
    Private Property pemployee() As DataTable
        Get
            Return CType(Session("pemployee"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pemployee") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Try
                ddDepartment.DataSource = Nothing
                ddFunction.DataSource = Nothing
                ddAccount.DataSource = Nothing

                txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

                pRC = objDerived.GetDataTable("select * from [AMS].[Respcenter] where Function_ID = 86 and rc_id <> 48 and rc_id <> 49 order by rc_id ", CommandType.Text)
                ddDepartment.DataSource = CType(pRC, DataTable)
                ddDepartment.DataTextField = ("RespCenter")
                ddDepartment.DataValueField = ("rc_id")
                ddDepartment.DataBind()

                gvbody.DataSource = Nothing
                gvbody.DataBind()


                txtSAINumb.Text = objDerived.GetValue("select AMS.func_GenerateSAI('" & txtDate.Text & "')", CommandType.Text)


            Catch ex As Exception
            End Try
        End If

    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ddDepartment.Enabled = False
            ddFunction.Enabled = True

            pFunction = objDerived.GetDataTable("select Office_id as Rc_id , Function_id,Function_desc from ams.vw_functions  where Office_id = " & ddDepartment.SelectedItem.Value & "", CommandType.Text)
            ddFunction.DataSource = pFunction
            ddFunction.DataTextField = ("Function_Desc")
            ddFunction.DataValueField = ("Function_ID")
            ddFunction.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddFunction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ddFunction.Enabled = False
            ddAllotment.Enabled = True

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddAllotment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ddAllotment.Enabled = False
            ddAccount.Enabled = True

            pAccounts = objDerived.GetDataTable("exec dbo.sp_SAI_Accounts '" & ddAllotment.SelectedIndex & "'", CommandType.Text)
            ddAccount.DataSource = pAccounts
            ddAccount.DataTextField = ("GA_Title")
            ddAccount.DataValueField = ("GA_Code")
            ddAccount.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        lnkView.Enabled = True
        ddInquireBy.Enabled = True
        txtRemarks.Enabled = True

        pListitem = objDerived.GetDataTable("exec ams.sp_goods_per_account_withPrice " & pAccounts.Rows(ddAccount.SelectedIndex - 1)("GA_ID") & "," & 0 & "," & Year(Date.Today.ToString("MM/dd/yyyy")) & "", CommandType.Text)
        gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        gvitems.Columns(5).Visible = True
        gvitems.DataSource = pListitem
        gvitems.DataBind()
        gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        gvitems.Columns(5).Visible = False

        pemployee = objDerived.GetDataTable("Select * From dbo.view_signatory1 where division_key = '" & Me.ddFunction.SelectedItem.Value & "' and deptid ='" & ddDepartment.SelectedItem.Value & "' and isDeptHead ='Yes' ", CommandType.Text)
        ddInquireBy.DataSource = pemployee
        ddInquireBy.DataTextField = ("full_name")
        ddInquireBy.DataValueField = ("empid")
        ddInquireBy.DataBind()

    End Sub

    Protected Sub gvitems_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        Dim cbheader As CheckBox
        Me.gvitems.Columns(3).Visible = True
        gvitems.Columns(4).Visible = True
        Me.gvitems.PageIndex = e.NewPageIndex
        Me.gvitems.DataSource = CType(pListitem, DataTable)
        Me.gvitems.DataBind()
        Me.gvitems.Columns(3).Visible = False
        gvitems.Columns(4).Visible = False
        CType(gvitems.HeaderRow.Cells(0).FindControl("CheckBox2"), CheckBox).Enabled = True

        ModalPopupExtendepopup.Show()
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As String
        gvitems.Columns(4).Visible = True
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = True

                End If
            Next
        Else
            For i As Integer = 0 To Me.gvitems.Rows.Count - 1
                item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvitems.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
                pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If

        gvitems.Columns(4).Visible = False
        ModalPopupExtendepopup.Show()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            gvitems.Columns(4).Visible = True
            Dim cb As CheckBox = TryCast(sender, CheckBox)
            Dim gvr As GridViewRow = TryCast(cb.NamingContainer, GridViewRow)

            If cb.Checked = True Then
                pListitem.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = True
            Else
                pListitem.Rows(Me.gvitems.Rows(gvr.RowIndex).Cells(4).Text)("isChecked") = False
            End If

            gvitems.Columns(4).Visible = False
            ModalPopupExtendepopup.Show()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim sumObject As Integer
            Dim dt As New DataTable
            Dim dr As DataRow

            dt.Columns.Add("id", GetType(Integer))
            dt.Columns.Add("Item_Desc", GetType(String))
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("Item_ID", GetType(Long))


            If gvbody.Rows.Count <= 0 Then
                For i As Integer = 0 To Me.pListitem.Rows.Count - 1

                    Dim pListitem2 As New DataTable
                    pListitem2 = pListitem

                    If pListitem.Rows(i)("isChecked") = True Then
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = pListitem.Rows(i)("Item_Desc")
                        dr("Description") = pListitem.Rows(i)("Description")
                        dr("Item_ID") = pListitem.Rows(i)("Item_id")
                        dt.Rows.Add(dr)
                        pListitem.Rows(i)("isUsed") = True
                        pListitem.Rows(i)("isChecked") = False

                    End If
                Next
                pItems = dt

            Else
                sumObject = pItems.Compute("count(id)", "id=1")
                For i As Integer = 0 To Me.pListitem.Rows.Count - 1
                    If pListitem.Rows(i)("isChecked") = True Then
                        dt = pItems
                        dr = dt.NewRow
                        dr("id") = 1
                        dr("Item_Desc") = pListitem.Rows(i)("Item_Desc")
                        dr("Description") = pListitem.Rows(i)("Description")
                        dr("Item_ID") = pListitem.Rows(i)("Item_id")
                        dt.Rows.Add(dr)

                        pItems = dt
                        pListitem.Rows(i)("isUsed") = True
                        pListitem.Rows(i)("isChecked") = False
                    End If
                Next
            End If

            gvbody.DataSource = pItems
            gvbody.DataBind()

            btnSave.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddInquireBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ddInquireBy.Enabled = False
    End Sub

    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Description", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("id") = 0
            dr("Item_Desc") = ""
            dr("Description") = ""
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        btnSave.OnClientClick = "StartProgressBar();"

        Try
            If ddInquireBy.SelectedIndex = 0 Then
                lblreq1.Visible = True
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Fill up required fields.")
            Else
                lblreq1.Visible = False
                btnPreview.Enabled = True

                '=== Save HDR ===
                hdr.Sai_Date = txtDate.Text
                hdr.Sai_No = txtSAINumb.Text
                hdr.RC_ID = ddDepartment.SelectedItem.Value
                hdr.Function_ID = ddFunction.SelectedItem.Value
                hdr.GA_Code = ddAccount.SelectedItem.Value
                hdr.PurposeRemarks = txtRemarks.Text
                hdr.Inquiryby = ddInquireBy.SelectedItem.Text
                hdr.isConfirm = False
                'hdr.Providedby = ""
                'hdr.Date_Provided = "1/1/1900"
                'hdr.position1 = ""
                'hdr.position2 = ""
                Dim hdrid As Integer = hdr.save()

                Session("sai_hdr_id") = hdrid

                '=== Save DTL ===
                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    dtl.Sai_Hdr_ID = hdrid
                    dtl.Item_ID = pItems.Rows(i)("Item_id")
                    dtl.Unit = pItems.Rows(i)("Description")

                    Dim qty As TextBox
                    qty = CType(gvbody.Rows(i).FindControl("txtqty"), TextBox)

                    dtl.InquireQty = CType(qty.Text, Integer)
                    'dtl.AvailbleQty = 0
                    dtl.save()
                Next

                ddAccount.Enabled = False
                lnkView.Enabled = False
                ddInquireBy.Enabled = False
                txtRemarks.Enabled = False
                btnSave.Enabled = False

                btnPreview.Enabled = True

                For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                    CType(gvbody.Rows(i).FindControl("txtqty"), TextBox).Enabled = False
                Next


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("SAI") = "Preparation"
        Me.Page.Response.Redirect("~/Procurement/rpt_SAI_report.aspx")
    End Sub

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.gvitems.Columns(3).Visible = True
            gvitems.Columns(4).Visible = True
            If SearchBut.Text = "" Then
                SearchBut.Text = ""
            End If
            Dim myview As DataView
            myview = pListitem.DefaultView
            myview.RowFilter = "Item_desc like '%" & replaceapostrophe(SearchBut.Text.ToString) & "%' and isUsed = false"
            gvitems.DataSource = myview

            Me.gvitems.DataBind()
            Me.gvitems.Columns(3).Visible = False
            gvitems.Columns(4).Visible = False
            gvitems.SelectedIndex = -1
            gvitems.PageIndex = 0

            ModalPopupExtendepopup.Show()
        Catch ex As Exception

        End Try
    End Sub

End Class
