Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Web.UI.HtmlControls
Imports System.IO

Partial Class Inventory_Disposal_t_disposal_destruction
    Inherits System.Web.UI.Page

    Dim objDerived As New DerivedDal
    Dim hdr As New Disposal_Donation_hdr
    Dim dtl As New Disposal_Donation_dtl
    Dim msg As New MsgeBox
    Dim obj As New AccessRule

    Private objMREReturn As New MRE_Return

#Region "property"

    Private Property pNew() As DataTable
        Get
            Return CType(Session("pNew"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pNew") = value
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

    Private Property pOPen() As DataTable
        Get
            Return CType(Session("pOPen"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pOPen") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)

        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            pBody = Nothing
            gvbody.DataSource = pBody
            gvbody.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = False
            txtBy.ReadOnly = True
            txtRAO.ReadOnly = True
            txtTo.ReadOnly = True
            btnpreview.Enabled = False

            pNew = objDerived.GetDataTable("select * from ams.donationew", CommandType.Text)
            gvNEW.DataSource = pNew
            gvNEW.DataBind()
            pOPen = objDerived.GetDataTable("SELECT * FROM AMS.Disposal_Donation_hdr ORDER BY Disposal_Donation_hdr_id DESC", CommandType.Text)
            gvopen.DataSource = pOPen
            gvopen.DataBind()
        End If
    End Sub
    Protected Sub gvNEW_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvNEW.SelectedIndexChanged
        Try
            pBody = Nothing
            pBody = objDerived.GetDataTable("exec ams.donation_dtl_report '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
            gvbody.DataSource = pBody
            gvbody.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

            Me.Session("TransID") = gvNEW.SelectedDataKey(0)
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = True
            btnpreview.Enabled = False

            txtBy.ReadOnly = False
            txtRAO.ReadOnly = False
            txtTo.ReadOnly = False
            txtTo.Text = ""
            txtRAO.Text = ""
            txtBy.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            Dim rc As Integer
            For o As Integer = 0 To gvbody.Rows.Count - 1
                If CType(gvbody.Rows(o).FindControl("CheckBox1"), CheckBox).Checked = True Then
                    rc = rc + 1
                End If
            Next

            If rc >= 1 Then
                hdr.Disposa_date = txtdate.Text
                hdr.IIRUPHdr_ID = gvNEW.SelectedDataKey(0)
                hdr.TransTo = txtTo.Text
                hdr.RAO = txtRAO.Text
                hdr.AuthorizedBy = txtBy.Text
                Dim hdrid As Long = hdr.save()

                Me.Session("TransID") = hdrid

                For i As Integer = 0 To pBody.Rows.Count - 1
                    If CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Checked = True Then
                        'Disposal_Donation_dtl
                        dtl.Disposal_Donation_hdr_id = hdrid
                        dtl.PropertyNo = pBody.Rows(i)("PropertyNo")
                        dtl.Property_ID = pBody.Rows(i)("Property_ID")
                        dtl.value = pBody.Rows(i)("val")
                        dtl.Property_Date = pBody.Rows(i)("Property_Date")
                        dtl.save()

                        Dim qty As Integer = Val(objDerived.GetValue("SELECT AMS.Property.qty FROM AMS.Property INNER JOIN AMS.Property_Dtl ON AMS.Property.Property_ID = AMS.Property_Dtl.Property_ID WHERE     AMS.Property_Dtl.PropertyNo ='" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        Dim balance As Integer = Val(objDerived.GetValue("exec AMS.getbalance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        Dim issuance As Integer = Val(objDerived.GetValue("exec AMS.getIssuance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))

                        'Dim a As Boolean = objDerived.GetValue("select Issued from AMS.Property_Dtl where PropertyNo = '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        'If a = True Then
                        '    objDerived.GetRecords("UPDATE AMS.MRE_Returns SET   MRE_Date='" & txtdate.Text & "',Status ='Dispose',Remarks='For Donation'  WHERE PropertyNo='" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text)
                        '    objDerived.GetRecords("Update AMS.Property set Balance='" & balance + 1 & "',Issuance='" & IIf(issuance = 0, 0, issuance - 1) & "' where  Property_ID='" & pBody.Rows(i)("Property_ID") & "'", CommandType.Text)

                        '    Dim mrhdrid As Integer = CType(objDerived.GetValue("exec ams.Disposalgetmrid '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text), Integer)
                        '    Dim cancel As Integer = CType(objDerived.GetValue("exec ams.DisposalMRCancel " & mrhdrid & "", CommandType.Text), Integer)
                        '    If cancel = 0 Then
                        '        objDerived.GetRecords("UPDATE AMS.MRE_Hdr SET Cancelled=1 WHERE MREHdr_ID=" & mrhdrid & "", CommandType.Text)
                        '    End If
                        'End If

                        balance = Val(objDerived.GetValue("exec AMS.getbalance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        issuance = Val(objDerived.GetValue("exec AMS.getIssuance '" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text))
                        objDerived.GetRecords("Update AMS.Property set qty=" & IIf(qty = 0, 0, qty - 1) & ", Balance='" & IIf(balance = 0, 0, balance - 1) & "',Issuance='" & IIf(issuance = 0, 0, issuance - 1) & "',Remarks='Property Donated' where  Property_ID='" & pBody.Rows(i)("Property_ID") & "'", CommandType.Text)
                        objDerived.GetRecords("Update AMS.Property_Dtl SET DisposeDate='" & txtdate.Text & "',Dispose ='True'  WHERE PropertyNo='" & pBody.Rows(i)("PropertyNo") & "'", CommandType.Text)

                        'MRE_Returns
                        objMREReturn.MRE_Dtl = 0
                        objMREReturn.PropertyNo = pBody.Rows(i)("PropertyNo")
                        objMREReturn.MRE_Date = txtdate.Text
                        objMREReturn.Status = "Disposed"
                        objMREReturn.Remarks = "Donated"
                        objMREReturn.Dispose = True
                        objMREReturn.Repair = False
                        objMREReturn.Inspection = False
                        objMREReturn.deptid = 0
                        objMREReturn.saveMREReturn()

                    End If

                    CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Enabled = False
                    CType(gvbody.HeaderRow.FindControl("CheckBox2"), CheckBox).Enabled = False

                Next
                msg.UserMsgBox("Transaction has been succesfully saved", Me, False)

                txtdate.ReadOnly = True
                btnnew.Enabled = True
                btnopen.Enabled = True
                btnsave.Enabled = False
                txtBy.ReadOnly = True
                txtRAO.ReadOnly = True
                txtTo.ReadOnly = True
                btnpreview.Enabled = True

                pNew = objDerived.GetDataTable("select * from ams.donationew", CommandType.Text)
                gvNEW.DataSource = pNew
                gvNEW.DataBind()

                pOPen = objDerived.GetDataTable("SELECT * FROM AMS.Disposal_Donation_hdr ORDER BY Disposal_Donation_hdr_id DESC", CommandType.Text)
                gvopen.DataSource = pOPen
                gvopen.DataBind()
            Else
                msg.UserMsgBox("No records to save", Me, False)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnpreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        Me.Page.Response.Redirect("~/Inventory/Disposal/t_rpt_donation.aspx")
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            pBody = Nothing
            pBody = objDerived.GetDataTable("exec ams.donation_dtl_report '" & gvNEW.SelectedDataKey(0) & "'", CommandType.Text)
            gvbody.DataSource = pBody
            gvbody.DataBind()

            txtdate.Text = Date.Today.ToString("MM/dd/yyyy")

            Me.Session("TransID") = gvNEW.SelectedDataKey(0)
            btnnew.Enabled = True
            btnopen.Enabled = True
            btnsave.Enabled = True
            'btnadd.Enabled = True
            btnpreview.Enabled = False
            'ddInspector.Enabled = True
            'ddappraiser.Enabled = True

            txtBy.ReadOnly = False
            txtRAO.ReadOnly = False
            txtTo.ReadOnly = False
            txtTo.Text = ""
            txtRAO.Text = ""
            txtBy.Text = ""
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim obj As Object

            obj = CType(txtsearch2.Text, Date)
            Me.gvNEW.DataSource = objDerived.Search(pNew, "IIRUP_Date", obj)
            Me.gvNEW.DataBind()
            gvNEW.SelectedIndex = -1
            gvNEW.PageIndex = 0

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Button19_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim obj As Object
            obj = CType(txtsearch.Text, Date)
            Me.gvopen.DataSource = objDerived.Search(pOPen, "IIRUP_Date", obj)
            Me.gvopen.DataBind()
            gvopen.SelectedIndex = -1
            gvopen.PageIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnload2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnload2.Click
        Try
            txtdate.Text = gvopen.SelectedDataKey(1)

            'Session("transactionID") = gvopen.SelectedDataKey(0)
            pBody = objDerived.GetDataTable("exec ams.donation_dtl_report2 '" & gvopen.SelectedDataKey(0) & "'", CommandType.Text)
            gvbody.DataSource = pBody
            gvbody.DataBind()

            For i As Integer = 0 To Me.pBody.Rows.Count - 1
                CType(gvbody.Rows(i).FindControl("CheckBox1"), CheckBox).Enabled = False

            Next
            txtTo.Text = gvopen.SelectedDataKey(2)
            txtRAO.Text = gvopen.SelectedDataKey(3)
            txtBy.Text = gvopen.SelectedDataKey(4)
            txtBy.ReadOnly = True
            txtRAO.ReadOnly = True
            txtTo.ReadOnly = True
            CType(gvbody.HeaderRow.FindControl("CheckBox2"), CheckBox).Enabled = False


            btnsave.Enabled = False
            Me.Session("TransID") = gvopen.SelectedDataKey(0)
            btnpreview.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnopen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnopen.Click

    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                'item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                End If
            Next
        Else
            For i As Integer = 0 To Me.gvbody.Rows.Count - 1
                'item = Me.gvitems.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.gvbody.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                s.Checked = False
            Next
        End If
    End Sub
    Protected Sub gvNEW_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvNEW.PageIndexChanging
        Me.gvNEW.DataSource = CType(pNew, DataTable)
        Me.gvNEW.DataBind()
        gvNEW.SelectedIndex = -1
    End Sub
    Protected Sub gvbody_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvbody.PageIndexChanging

    End Sub
    Protected Sub gvopen_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvopen.PageIndexChanging
        Me.gvopen.DataSource = CType(pOPen, DataTable)
        Me.gvopen.DataBind()
        gvopen.SelectedIndex = -1
    End Sub
    Protected Sub btnnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnew.Click

    End Sub


End Class
