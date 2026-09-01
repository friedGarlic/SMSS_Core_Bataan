Imports System.Data
Partial Class bidding_t_repeat_order_approval
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Dim objDerived As New DerivedDal
    Private Property pPurchase_Order_Item() As DataTable
        Get
            Return CType(Session("pPurchase_Order_Item"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_Item") = value
        End Set
    End Property
    Private Property pPurchase_Order() As DataTable
        Get
            Return CType(Session("pPurchase_Order"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order") = value
        End Set
    End Property
    Public Function CreateTable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("pr_no", GetType(String))
        'dt.Columns.Add("ReqDept", GetType(String))
        'dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("ContractPrice", GetType(Decimal))


        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("pr_no") = DBNull.Value
            'dr("ReqDept") = DBNull.Value
            'dr("OBR_No") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("ContractPrice") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("pr_no", GetType(String))
        'dt.Columns.Add("ReqDept", GetType(String))
        'dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("ItemCompleteDesc", GetType(String))
        dt.Columns.Add("qty", GetType(Decimal))
        dt.Columns.Add("cost", GetType(Decimal))


        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("pr_no") = DBNull.Value
            'dr("ReqDept") = DBNull.Value
            'dr("OBR_No") = DBNull.Value
            dr("POHdr_ID") = DBNull.Value
            dr("ItemCompleteDesc") = DBNull.Value
            dr("qty") = DBNull.Value
            dr("cost") = DBNull.Value

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Private Sub bidding_t_repeat_order_approval(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadRO()

        End If
    End Sub
    Protected Sub LoadRO()
        pPurchase_Order = objDerived.GetDataTable("EXEC [AMS].[sp_InspectionAcceptance_List_RO]", CommandType.Text)
        If pPurchase_Order.Rows.Count < 5 Then
            pPurchase_Order.Merge(CreateTable(5 - pPurchase_Order.Rows.Count))
        End If
        grdRO.DataSource = pPurchase_Order
        grdRO.DataBind()
    End Sub
    Protected Sub grdRO_SelectedIndexChanged(sender As Object, e As EventArgs)
        pPurchase_Order_Item = objDerived.GetDataTable("EXEC [AMS].[sp_RO_Items] '" & grdRO.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        txtHiddenReceiveQty.Value = pPurchase_Order_Item.Rows.Count
        If pPurchase_Order_Item.Rows.Count < 5 Then
            pPurchase_Order_Item.Merge(CreateTable1(5 - pPurchase_Order_Item.Rows.Count))
        End If
        grdListofItem.DataSource = pPurchase_Order_Item
        grdListofItem.DataBind()
    End Sub
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'HERE
        Dim item As String

        If CType(sender, CheckBox).Checked = True Then
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdListofItem.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdListofItem.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                If s.Enabled = True Then
                    s.Checked = True
                    ' btnActSave.Enabled = True
                    ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = True
                    'pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = True


                End If
            Next
        Else
            For i As Integer = 0 To Val(txtHiddenReceiveQty.Value) - 1
                item = Me.grdListofItem.Rows(i).Cells(1).Text
                Dim s As CheckBox = CType(Me.grdListofItem.Rows(i).Cells(0).FindControl("cbInspection"), CheckBox)
                s.Checked = False
                ' pListitem.Rows(Me.gvitems.Rows(i).Cells(4).Text)("isUsed") = False
                ' pInspection_detail.Rows(Me.grdInspection.Rows(i).Cells(4).Text)("isChecked") = False
            Next
        End If


    End Sub
End Class
