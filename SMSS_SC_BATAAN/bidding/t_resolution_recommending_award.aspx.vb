Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class t_resolution_recommending_award
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Private hdr As New t_bid_opening_hdr
    Private dtl As New t_bid_opening_dtl
#Region "property"

    Private Property pProjectReference() As DataTable
        Get
            Return CType(Session("pProjectReference"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProjectReference") = value
        End Set
    End Property
    Private Property pProject() As DataTable
        Get
            Return CType(Session("pProject"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pProject") = value
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
    Private Property pGoodsPerSupplier(ByVal supplier_id As String) As DataTable
        Get
            Return CType(Session(supplier_id), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session(supplier_id) = value
        End Set
    End Property
    Private Property pSupplier() As DataTable
        Get
            Return CType(Session("pSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pSupplier") = value
        End Set
    End Property
    Private Property pTempSupplier() As DataTable
        Get
            Return CType(Session("pTempSupplier"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pTempSupplier") = value
        End Set
    End Property
    Private Property pPurchase_Order_detail() As DataTable
        Get
            Return CType(Session("pPurchase_Order_detail"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pPurchase_Order_detail") = value
        End Set
    End Property
    Private Property pShopping() As DataTable
        Get
            Return CType(Session("pShopping"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pShopping") = value
        End Set
    End Property
#End Region
#Region "Functions"

    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("mode_of_procurement_id", GetType(Integer))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("mode_description")
        dt.Columns.Add("transaction_date", GetType(Date))
        dt.Columns.Add("resolution_mode_of_procurement")
        dt.Columns.Add("F_ID", GetType(Integer))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("mode_of_procurement_id") = 0
            dr("obr_evaluation_hdr_id") = 0
            dr("isVisible") = False
            dr("mode_description") = ""
            dr("transaction_date") = "01/01/1900"
            dr("resolution_mode_of_procurement") = ""
            dr("F_ID") = 0

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableSuppliers(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName")
        dt.Columns.Add("Supplier_Id", GetType(Long))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("amount", GetType(Decimal))
        dt.Columns.Add("status")
        dt.Columns.Add("isOld", GetType(Boolean))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = ""
            dr("Supplier_Id") = 0
            dr("isVisible") = False
            dr("amount") = "0.00"
            dr("status") = ""
            dr("isOld") = False

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            pShopping = objDerived.GetDataTable("select * from ams.vw_alternative_resolution", CommandType.Text)
            pShopping.Merge(objDerived.GetDataTable("select * from ams.vw_alternative_resolution_NP_DC", CommandType.Text))

            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable(7 - pShopping.Rows.Count))
            End If
            gvIncomingPR.DataSource = pShopping
            gvIncomingPR.DataBind()
            btnsave.Enabled = False
            btnPreview.Enabled = False
            Me.Session("page") = "Abstract of canvass"
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvIncomingPR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvIncomingPR_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Me.cpeEmployeeList.Collapsed = False
            Me.cpeEmployeeList.ClientState = False
            Me.cpeEmployeeDetail.Collapsed = False
            Me.cpeEmployeeDetail.ClientState = False
            Me.Session("1strow") = False
            Me.Session("gvProject1stLoad") = True
            Me.Session("obr_evaluation_hdr_id") = gvIncomingPR.SelectedDataKey(1)
            pProject = objDerived.GetDataTable("exec ams.sp_consol_abstract_of_canvass " & gvIncomingPR.SelectedDataKey(1) & "", CommandType.Text)
            gvProject.DataSource = pProject
            gvProject.DataBind()
            btnsave.Enabled = True
            btnPreview.Enabled = False
            pProjectReference = objDerived.GetDataTable("SELECT    pre_procurement_hdr_id FROM AMS.pre_procurement WHERE     obr_evaluation_hdr_id =" & gvIncomingPR.SelectedDataKey(1) & " ", CommandType.Text)
            ' call_laod_supplier_per_project()
            If gvIncomingPR.SelectedDataKey(2) = "Negotiated Procurement" Then
                btnsave.Text = "SAVE"
            Else
                btnsave.Text = "CREATE RESOLUTION"
            End If
            For i As Integer = 0 To pProject.Rows.Count - 1
                CType(gvProject.Rows(i).FindControl("ddSupplier"), DropDownList).DataSource = objDerived.GetRecords("select SuppName,Supplier_Id from dbo.supplier order by SuppName", CommandType.Text)
                CType(gvProject.Rows(i).FindControl("ddSupplier"), DropDownList).DataTextField = "SuppName"
                CType(gvProject.Rows(i).FindControl("ddSupplier"), DropDownList).DataValueField = "Supplier_Id"
                CType(gvProject.Rows(i).FindControl("ddSupplier"), DropDownList).DataBind()
                If gvIncomingPR.SelectedDataKey(2) <> "Negotiated Procurement" Or gvIncomingPR.SelectedDataKey(2) <> "Direct Contracting" Then
                    CType(gvProject.Rows(i).FindControl("ddSupplier"), DropDownList).SelectedItem.Text = pProject.Rows(i)("SuppName")
                    CType(gvProject.Rows(i).FindControl("ddSupplier"), DropDownList).Enabled = False
                End If

            Next
         
            'ddSupplier.DataSource = objDerived.GetRecords("select SuppName,Supplier_Id from dbo.supplier order by SuppName", CommandType.Text)
            'ddSupplier.DataTextField = "SuppName"
            'ddSupplier.DataValueField = "Supplier_Id"
            'ddSupplier.DataBind()
        Catch ex As Exception
            msg.UserMsgBox(ex.ToString, Me, False)
        End Try
    End Sub

    Protected Function CheckIfTitleExists(ByVal strval As String) As String
        Dim title As String = ViewState("title")
        If title = strval Then
            Me.Session("1strow") = False
            Return String.Empty
        Else
            title = strval
            ViewState("title") = title
            Me.Session("1strow") = True
            If Me.Session("gvProject1stLoad") = True Then
                Return "<b>" & title & "</b><br>"
                ' Me.Session("gvProject1stLoad") = False
            Else
                Return "<br><b>" & title & "</b><br>"
            End If

        End If
    End Function
    Protected Function CheckIfTitleExists2(ByVal strval As String) As String

        If Me.Session("1strow") = True Then
            If Me.Session("gvProject1stLoad") = True Then
                Me.Session("gvProject1stLoad") = False
                Return "<b></b><br>"
            Else
                Return "<br><b></b><br>"
            End If
        Else
            Return String.Empty
        End If
    End Function
    Public Sub call_laod_supplier_per_project()
        'gvProject.DataSource = objDerived.GetRecords("exec ams.sp_consolidation_of_abstract_of_canvass_per_RRMP" & gvIncomingPR.SelectedDataKey(1) & "", CommandType.Text)
        'gvProject.DataBind()
        'gvProject.Rows(0).Visible = False

        'btnPreview.Enabled = True
        'pProjectReference = objDerived.GetDataTable("SELECT     project_reference_no,pre_procurement_hdr_id,ABC,withWinner FROM AMS.pre_procurement WHERE     obr_evaluation_hdr_id =" & gvIncomingPR.SelectedDataKey(1) & " ", CommandType.Text)
        'ddProjectReference.DataSource = pProjectReference
        'ddProjectReference.DataTextField = "project_reference_no"
        'ddProjectReference.DataValueField = "pre_procurement_hdr_id"
        'ddProjectReference.DataBind()
        'ddProjectReference.SelectedIndex = 0
        'pPurchase_Order_detail = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb " & ddProjectReference.SelectedItem.Value & "", CommandType.Text)
        'gvbody.DataSource = pPurchase_Order_detail
        'gvbody.DataBind()
        'txtABC.Text = FormatNumber(pProjectReference.Rows(ddProjectReference.SelectedIndex)("ABC"), 2)
        'Session("pre_procurement_hdr_id") = ddProjectReference.SelectedItem.Value
        'pTempSupplier = Nothing
        'pSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_canvass " & ddProjectReference.SelectedItem.Value & "", CommandType.Text)
        'pTempSupplier = objDerived.GetDataTable("exec ams.sp_supplier_per_canvass " & ddProjectReference.SelectedItem.Value & "", CommandType.Text)
        'If pTempSupplier.Rows.Count < 8 Then
        '    pTempSupplier.Merge(createdatatableSuppliers(7 - pTempSupplier.Rows.Count))
        'End If

        'If pSupplier.Rows.Count >= 1 Then
        '    For i As Integer = 0 To pSupplier.Rows.Count - 1
        '        pGoodsPerSupplier(ddProjectReference.SelectedItem.Value.ToString + pSupplier.Rows(i)("Supplier_Id").ToString) = objDerived.GetDataTable("exec ams.sp_canvass_form_detail_vb_existing " & ddProjectReference.SelectedItem.Value & ", " & pSupplier.Rows(i)("Supplier_Id") & "", CommandType.Text)
        '    Next
        'End If

        'gvsupplier.DataSource = pTempSupplier
        'gvsupplier.DataBind()
        'gvsupplier.SelectedIndex = -1
        ''  btnsave.Enabled = False
        'If pProjectReference.Rows(ddProjectReference.SelectedIndex)("withWinner") = True Then

        '    btnsave.Enabled = False
        '    btnPreviewAbstract.Enabled = True
        '    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "The selected project has a winner.")
        'Else
        '    btnPreviewAbstract.Enabled = False
        '    btnsave.Enabled = True
        'End If

    End Sub





    Protected Sub lbSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Lbtn = "supplier"
    End Sub



    Protected Sub gvsupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        
       
    End Sub

    

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If gvIncomingPR.SelectedDataKey(2) = "Negotiated Procurement" Then

                Try
                    If pProjectReference.Rows.Count = 1 Then
                        Me.Session("isVarious") = False
                    Else
                        Me.Session("isVarious") = True
                    End If
                    Me.Session("resolution_number") = txtResolutionNumber.Text
                    For i As Integer = 0 To pProjectReference.Rows.Count - 1
                        objDerived.GetRecords("Update ams.pre_procurement set withWinner  =  1,withBid =1, resolution_number='" & gvIncomingPR.SelectedDataKey(4) & "',resolution_number_date='" & Date.Today.ToString("MM/dd/yyyy") & "' where pre_procurement_hdr_id=" & pProjectReference.Rows(i)("pre_procurement_hdr_id") & "", CommandType.Text)
                    Next
                    For x As Integer = 0 To gvProject.Rows.Count - 1
                        objDerived.GetRecords("Update ams.canvass_hdr set isWinner  =  1,supplier_id ='" & CType(gvProject.Rows(x).FindControl("ddSupplier"), DropDownList).SelectedItem.Value & "' where canvass_hdr_id=" & pProject.Rows(x)("canvass_hdr_id") & "", CommandType.Text)
                    Next


                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully saved.")
                    pShopping = objDerived.GetDataTable("select * from ams.vw_alternative_resolution", CommandType.Text)
                    pShopping.Merge(objDerived.GetDataTable("select * from ams.vw_alternative_resolution_NP_DC", CommandType.Text))
                    If pShopping.Rows.Count < 8 Then
                        pShopping.Merge(createdatatable(7 - pShopping.Rows.Count))
                    End If

                    gvIncomingPR.DataSource = pShopping
                    gvIncomingPR.DataBind()
                    btnsave.Enabled = False
                    gvProject.DataSource = Nothing
                    gvProject.DataBind()
                    btnPreview.Enabled = True
                    pProjectReference = Nothing

                Catch ex As Exception

                End Try
            Else
                ModalPopupExtender1.Show()
            End If

            'objDerived.GetRecords("Update ams.pre_procurement set withWinner=1,declarationDate='" & Date.Today.ToString("MM/dd/yyyy") & "' where pre_procurement_hdr_id=" & ddProjectReference.SelectedItem.Value & "", CommandType.Text)
            'objDerived.GetRecords("Update ams.bid_opening_hdr set isWinner=1 where pre_procurement_hdr_id=" & ddProjectReference.SelectedItem.Value & " and Supplier_Id=" & gvsupplier.SelectedDataKey(0) & " ", CommandType.Text)
            'MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully closed")
            'call_laod_supplier_per_project()
        Catch ex As Exception

        End Try
        'Try

        '    For i As Integer = 0 To Me.gvsupplier.Rows.Count - 1
        '        If pTempSupplier.Rows(i)("Supplier_ID") <> 0 And pTempSupplier.Rows(i)("isOld") <> True Then
        '            hdr.pre_procurement_hdr_id = ddProjectReference.SelectedItem.Value
        '            hdr.Supplier_Id = gvsupplier.SelectedDataKey(0)
        '            hdr.amount = FormatNumber(pGoodsPerSupplier(ddProjectReference.SelectedItem.Value.ToString + pTempSupplier.Rows(i)("Supplier_ID").ToString).Compute("sum(total)", ""), 2)
        '            hdr.calculatedAmount = FormatNumber(pGoodsPerSupplier(ddProjectReference.SelectedItem.Value.ToString + pTempSupplier.Rows(i)("Supplier_ID").ToString).Compute("sum(total)", ""), 2)
        '            hdr.isWinner = False
        '            Dim hdrID As Long = hdr.save()
        '            For dtlrow As Integer = 0 To gvbody.Rows.Count - 1
        '                dtl.bid_opening_hdr_id = hdrID
        '                dtl.item_id = pGoodsPerSupplier(ddProjectReference.SelectedItem.Value.ToString + pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("item_id")
        '                dtl.qty = pGoodsPerSupplier(ddProjectReference.SelectedItem.Value.ToString + pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("qty")
        '                dtl.Cost = pGoodsPerSupplier(ddProjectReference.SelectedItem.Value.ToString + pTempSupplier.Rows(i)("Supplier_ID").ToString).Rows(dtlrow)("cost")
        '                dtl.save()
        '            Next

        '        Else

        '        End If
        '    Next
        '    objDerived.GetRecords("Update ams.pre_procurement set withBid=1 where pre_procurement_hdr_id=" & ddProjectReference.SelectedItem.Value & "", CommandType.Text)
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.upEmployeeDetail, "Transaction has been succesfully save")
        ' call_laod_supplier_per_project()
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If pProjectReference.Rows.Count = 1 Then
                Me.Session("isVarious") = False
            Else
                Me.Session("isVarious") = True
            End If
            Session("resolution_number") = txtResolutionNumber.Text

            For i As Integer = 0 To pProjectReference.Rows.Count - 1
                objDerived.GetRecords("Update ams.pre_procurement set withNOA =1, resolution_number='" & txtResolutionNumber.Text & "',resolution_number_date='" & Date.Today.ToString("MM/dd/yyyy") & "' where pre_procurement_hdr_id=" & pProjectReference.Rows(i)("pre_procurement_hdr_id") & "", CommandType.Text)
            Next

            pShopping = objDerived.GetDataTable("select * from ams.vw_alternative_resolution", CommandType.Text)
            pShopping.Merge(objDerived.GetDataTable("select * from ams.vw_alternative_resolution_NP_DC", CommandType.Text))
            If pShopping.Rows.Count < 8 Then
                pShopping.Merge(createdatatable(7 - pShopping.Rows.Count))
            End If
            gvIncomingPR.DataSource = pShopping
            gvIncomingPR.DataBind()
            btnsave.Enabled = False
            gvProject.DataSource = Nothing
            gvProject.DataBind()
            btnPreview.Enabled = True
            pProjectReference = Nothing

            System.Threading.Thread.Sleep(1000)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been succesfully saved.")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.Session("isPublicbidding") = False
            Me.Page.Response.Redirect("~/bidding/rpt_resulotion_recommending_award.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtResolutionNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
