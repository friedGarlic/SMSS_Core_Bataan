Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class procurement_t_Receiving
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Dim rcv As New Receiving.t_receiving
    Dim rcv_dtl As New Receiving.t_receiving_dtl

    Private Property dtItems() As DataTable
        Get
            Return CType(Session("dtItems"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItems") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        obj.GetAccessRight(Me.Session("@UserName"), Page)
        If obj.HasAccess = False Then
            Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
        End If

        If Not Page.IsPostBack Then
            txtDateReceive.Text = Date.Today.ToString("MM/dd/yyyy")

            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Receiving_PO] ORDER BY PO_Date", CommandType.Text)
            grdReceived.DataBind()

            grdGoods.DataSource = Nothing
            grdGoods.DataBind()

            ddReceiveBy.DataSource = objDerived.GetDataTable("SELECT * FROM HRMS.view_signatory WHERE deptid = 7 and division_key = 86", CommandType.Text)
            ddReceiveBy.DataTextField = ("full_name")
            ddReceiveBy.DataValueField = ("empid")
            ddReceiveBy.DataBind()
            ddReceiveBy.Items.Insert(0, "Select")

            Session("Delivery") = 0
        End If
    End Sub

    Protected Sub grdReceived_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_Receiving] '" & grdReceived.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        grdGoods.DataSource = dtItems
        grdGoods.DataBind()

    End Sub

    Protected Sub grdReceived_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdReceived, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub ddReceiveBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnReceive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '=-= CHECK IF THERE IS SELECTED ITEM
            Dim x As Integer = 0
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                Dim cb As CheckBox = CType(Me.grdGoods.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Enabled = True Then
                    x = 1
                    Exit For
                End If
            Next

            If ddReceiveBy.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory for Receive By.")
                Exit Sub

            ElseIf x = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "No selected item.")
                Exit Sub

            ElseIf Session("Delivery") = 0 Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select if partial or complete delivery.")
                Exit Sub
            End If

            '=-= SAVE RECEIVING HEADER
            With rcv
                '.Received_Date = txtDateReceive.Text
                '.ReceivedBY = ddReceiveBy.SelectedItem.Value
                '.POHdr_ID = grdReceived.SelectedDataKey("POHdr_ID")
                '.PO_No = grdReceived.SelectedDataKey("PO_No")
                '.Supplier_ID = grdReceived.SelectedDataKey("Supplier_ID")
                '.GA_ID = grdReceived.SelectedDataKey("GA_ID")
                '.isComplete = Session("isComplete")
                '.UserID = Session("@UserName")
            End With

            Dim rcv_hdr_id As Long = rcv.save()
            Session("Received_ID") = rcv_hdr_id

            '=-= SAVE RECEIVING DETAILS
            For i As Integer = 0 To dtItems.Rows.Count - 1
                Dim cb As CheckBox = CType(Me.grdGoods.Rows(i).Cells(0).FindControl("CheckBox1"), CheckBox)
                If cb.Checked = True Then
                    Dim RcvQty As Integer = CType(CType(grdGoods.Rows(i).FindControl("txtQty"), TextBox).Text, Integer)

                    With rcv_dtl
                        .Received_ID = rcv_hdr_id
                        .Item_ID = dtItems.Rows(i)("Item_ID")
                        .PO_Qty = dtItems.Rows(i)("PO_Qty")
                        .Qty_Received = RcvQty
                        .Cost = dtItems.Rows(i)("Cost")
                        .save()
                    End With
                End If
            Next

            objDerived.GetDataTable("UPDATE AMS.PO_Hdr SET isComplete = '" & Session("isComplete") & "', isDelivered = 1 WHERE POHdr_ID = '" & grdReceived.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

            grdReceived.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_Receiving_PO] ORDER BY PO_Date", CommandType.Text)
            grdReceived.DataBind()

            grdGoods.DataSource = Nothing
            grdGoods.DataBind()

            btnReceive.Enabled = False
            btnPreview.Enabled = True
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub rbChoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Delivery") = 1
        If rbChoice.SelectedItem.Value = 1 Then
            Session("isComplete") = False
        ElseIf rbChoice.SelectedItem.Value = 2 Then
            Session("isComplete") = True
        End If

    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("Page") = "Rcv"
        Me.Page.Response.Redirect("~/procurement/t_rpt_receiving.aspx")
    End Sub
End Class
