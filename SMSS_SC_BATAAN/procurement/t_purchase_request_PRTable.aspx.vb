Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data


Partial Class procurement_t_purchase_request_PRTable
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

#Region "property"

    Private pPRTable As DataTable
    Public Property PRTable() As DataTable
        Get
            Return pPRTable
        End Get
        Set(ByVal value As DataTable)
            pPRTable = value
        End Set
    End Property

    Private dtSupplies As DataTable
    Public Property Supplies() As DataTable
        Get
            Return dtSupplies
        End Get
        Set(ByVal value As DataTable)
            dtSupplies = value
        End Set
    End Property

#End Region

#Region "tables"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("ProjectName", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("Function_Desc", GetType(String))
        dt.Columns.Add("OBR_No", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("PO_No", GetType(String))
        dt.Columns.Add("PO_Amount", GetType(Decimal))
        dt.Columns.Add("GA_ID", GetType(Long))
        dt.Columns.Add("DateApproved_PR_Mayor", GetType(Date))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = 0
            dr("POHdr_ID") = DBNull.Value
            dr("pr_no") = DBNull.Value
            dr("ProjectName") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("Function_Desc") = DBNull.Value
            dr("OBR_No") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("PO_No") = DBNull.Value
            dr("PO_Amount") = DBNull.Value
            dr("GA_ID") = DBNull.Value
            dr("DateApproved_PR_Mayor") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("prhdr_id", GetType(Long))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("PO_Date", GetType(String))
        dt.Columns.Add("UnitCost", GetType(Decimal))
        dt.Columns.Add("POHdr_ID", GetType(Long))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Status", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("prhdr_id") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("Unit") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("PO_Date") = DBNull.Value
            dr("UnitCost") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Status") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Session("Search") = 0

            pPRTable = objDerived.GetDataTable("EXEC [AMS].[sp_PRTableList]", CommandType.Text)
            If pPRTable.Rows.Count < 8 Then
                pPRTable.Merge(CreateTable1(8 - pPRTable.Rows.Count))
            End If
            grdPRTable.DataSource = pPRTable
            grdPRTable.DataBind()

            grdSupplies.DataSource = CreateTable2(8)
            grdSupplies.DataBind()

            '== AS DEFAULT
            Me.mvItems.SetActiveView(Me.vwSupplies)

            txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

        End If

    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If RadioButtonList3.SelectedIndex = 0 Then
            Me.Page.Response.Redirect("~/procurement/t_purchase_request_v2.aspx")
        Else

        End If
    End Sub

    Protected Sub grdPRTable_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdPRTable, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdPRTable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdPRTable.SelectedDataKey("prhdr_id") = 0 Then
            grdSupplies.DataSource = CreateTable2(8)
            grdSupplies.DataBind()

            lblSupplier.Text = ""
            lblPonumber.Text = ""
            lblPodate.Text = ""
            lbldepartment.Text = ""
            lblInvoice.Text = ""
            lblDate.Text = ""
            lblremarks.Text = ""

            Me.mvItems.SetActiveView(Me.vwSupplies)
        Else
            '=== SUPPLIES INFORMATION
            dtSupplies = objDerived.GetDataTable("EXEC [AMS].[sp_PRTable_Supplies] '" & grdPRTable.SelectedDataKey("prhdr_id") & "','" & grdPRTable.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
            If dtSupplies.Rows.Count < 8 Then
                dtSupplies.Merge(CreateTable2(8 - dtSupplies.Rows.Count))
            End If
            grdSupplies.DataSource = dtSupplies
            grdSupplies.DataBind()


            '=== DETAILS 
            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PRTable_Details] WHERE POHdr_ID = '" & grdPRTable.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)

            If dt.Rows.Count = 0 Then
                lblSupplier.Text = ""
                lblPonumber.Text = ""
                lblPodate.Text = ""
                lbldepartment.Text = ""
                lblInvoice.Text = ""
                lblDate.Text = ""
                lblremarks.Text = ""
            Else
                lblSupplier.Text = dt.Rows(0).Item("SuppName")
                lblPonumber.Text = dt.Rows(0).Item("PO_No")
                lblPodate.Text = dt.Rows(0).Item("PO_Date")
                lbldepartment.Text = grdPRTable.SelectedDataKey("RC_Name")
                lblInvoice.Text = dt.Rows(0).Item("Invoice_No")
                lblDate.Text = dt.Rows(0).Item("AIR_Date")
                lblremarks.Text = dt.Rows(0).Item("Remarks")
            End If
           

            Dim AllotmentClass_ID As Integer
            AllotmentClass_ID = objDerived.GetValue("SELECT AllotmentClass_ID FROM AMS.View_AccountList WHERE GA_ID = '" & grdPRTable.SelectedDataKey("GA_ID") & "'", CommandType.Text)

            Session("AllotmentClass_ID") = AllotmentClass_ID

            If AllotmentClass_ID = 2 Then
                If grdPRTable.SelectedDataKey("GA_ID") = 1427 Then
                    '=-= OFFICE SUPPLIES
                    Me.mvItems.SetActiveView(Me.vwSupplies)

                ElseIf grdPRTable.SelectedDataKey("GA_ID") = 1432 Or grdPRTable.SelectedDataKey("GA_ID") = 1433 Then
                    '=-= MEDICINES SUPPLIES AND MEDICAL SUPPLIES
                    Me.mvItems.SetActiveView(Me.vwOtherSupplies)

                Else '=-= OTHER SUPPLIES / MEDICINES SUPPLIES AND MEDICAL SUPPLIES
                    Me.mvItems.SetActiveView(Me.vwOtherSupplies)

                End If

            ElseIf AllotmentClass_ID = 3 Then
                If grdPRTable.SelectedDataKey("GA_ID") = 1060 Or grdPRTable.SelectedDataKey("GA_ID") = 1067 Then
                    '=-= LAND

                ElseIf grdPRTable.SelectedDataKey("GA_ID") = 1082 Or grdPRTable.SelectedDataKey("GA_ID") = 1085 Then
                    '=-= BUILDINGS

                ElseIf grdPRTable.SelectedDataKey("GA_ID") = 1166 Then
                    '=-= TRANSPORTATION
                    Me.mvItems.SetActiveView(Me.vwMotors)

                Else '=-= ALL EQUIPMENTS AND FURNITURE AND FIXTURES AND MACHINIRIES
                    Me.mvItems.SetActiveView(Me.vwEquipments)

                End If
            End If

        End If
    End Sub

    Protected Sub grdSupplies_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdSupplies, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdSupplies_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        '=== SUPPLIES INFORMATION
        dtSupplies = objDerived.GetDataTable("EXEC [AMS].[sp_PRTable_Supplies] '" & grdPRTable.SelectedDataKey("prhdr_id") & "','" & grdPRTable.SelectedDataKey("POHdr_ID") & "'", CommandType.Text)
        If dtSupplies.Rows.Count < 8 Then
            dtSupplies.Merge(CreateTable2(8 - dtSupplies.Rows.Count))
        End If
        grdSupplies.PageIndex = e.NewPageIndex
        grdSupplies.DataSource = dtSupplies
        grdSupplies.DataBind()
    End Sub

    Protected Sub grdSupplies_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dtItems As New DataTable

        If Session("AllotmentClass_ID") = 2 Then
            dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_PRTable_ItemInfo] '" & grdPRTable.SelectedDataKey("GA_ID") & "','" & grdSupplies.SelectedDataKey("POHdr_ID") & "', '" & grdSupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            If dtItems.Rows.Count = 0 Then
                If grdPRTable.SelectedDataKey("GA_ID") = 1427 Then
                    lblItemDesc.Text = ""
                    lblBrandName.Text = ""
                    lblSize.Text = ""
                    lblColor.Text = ""
                    lblCategory.Text = ""
                    lblLength.Text = ""
                    lblWidth.Text = ""
                    lblHeight.Text = ""
                    lblWeight.Text = ""
                    lblDRate.Text = ""
                    lblDValue.Text = ""

                Else
                    lblOS_ItemDesc.Text = ""
                    lblOS_BrandName.Text = ""
                    lblOS_DRate.Text = ""
                    lblOS_DValue.Text = ""
                    lblOS_Remarks.Text = ""
                    lblOS_Form.Text = ""
                    lblOS_OTC.Text = ""
                    lblOS_Batch.Text = ""
                    lblOS_Lot.Text = ""
                    lblOS_MDate.Text = ""
                    lblOS_EDate.Text = ""
                    lblOS_ADate.Text = ""

                End If

                lblReceivedDate.Text = ""
                lblReceivedBy.Text = ""
                lblInspectedBy.Text = ""
                lblAcceptedDate.Text = ""
                lblAcceptedBy.Text = ""


            ElseIf grdPRTable.SelectedDataKey("GA_ID") = 1427 Then
                '=-= OFFICE SUPPLIES
                Me.mvItems.SetActiveView(Me.vwSupplies)
                lblItemDesc.Text = dtItems.Rows(0)("Item_Desc")
                lblBrandName.Text = dtItems.Rows(0)("BrandName")
                lblSize.Text = dtItems.Rows(0)("Size")
                lblColor.Text = dtItems.Rows(0)("Color")
                lblCategory.Text = dtItems.Rows(0)("Category")
                lblLength.Text = dtItems.Rows(0)("Length")
                lblWidth.Text = dtItems.Rows(0)("Width")
                lblHeight.Text = dtItems.Rows(0)("Height")
                lblWeight.Text = dtItems.Rows(0)("Weight")
                lblDRate.Text = dtItems.Rows(0)("DepreciatedRate")
                lblDValue.Text = dtItems.Rows(0)("DepreciatedValue")

                lblReceivedDate.Text = dtItems.Rows(0)("Date_Received")
                lblReceivedBy.Text = dtItems.Rows(0)("ReceivedBy")
                lblInspectedBy.Text = dtItems.Rows(0)("InspectedBy")
                lblAcceptedDate.Text = dtItems.Rows(0)("Date_Accepted")
                lblAcceptedBy.Text = dtItems.Rows(0)("AcceptedBy")

            Else '=-= OTHER SUPPLIES / MEDICINES SUPPLIES AND MEDICAL SUPPLIES
                Me.mvItems.SetActiveView(Me.vwOtherSupplies)

                lblOS_ItemDesc.Text = dtItems.Rows(0)("ItemDesc")
                lblOS_BrandName.Text = dtItems.Rows(0)("BrandName")
                lblOS_DRate.Text = dtItems.Rows(0)("DepreciationRate")
                lblOS_DValue.Text = dtItems.Rows(0)("DepreciationValue")
                lblOS_Remarks.Text = ""
                lblOS_Form.Text = dtItems.Rows(0)("Form")
                lblOS_OTC.Text = dtItems.Rows(0)("OTCRx")
                lblOS_Batch.Text = dtItems.Rows(0)("Batch")
                lblOS_Lot.Text = dtItems.Rows(0)("Lot")
                lblOS_MDate.Text = dtItems.Rows(0)("Mftgdate")
                lblOS_EDate.Text = dtItems.Rows(0)("EpiryDate")
                lblOS_ADate.Text = dtItems.Rows(0)("Alert")

                lblReceivedDate.Text = dtItems.Rows(0)("Date_Received")
                lblReceivedBy.Text = dtItems.Rows(0)("ReceivedBy")
                lblInspectedBy.Text = dtItems.Rows(0)("InspectedBy")
                lblAcceptedDate.Text = dtItems.Rows(0)("Date_Accepted")
                lblAcceptedBy.Text = dtItems.Rows(0)("AcceptedBy")
            End If

        ElseIf Session("AllotmentClass_ID") = 3 Then
            dtItems = objDerived.GetDataTable("EXEC [AMS].[sp_PRTable_COItemInfo] '" & grdPRTable.SelectedDataKey("GA_ID") & "','" & grdSupplies.SelectedDataKey("POHdr_ID") & "', '" & grdSupplies.SelectedDataKey("Item_ID") & "'", CommandType.Text)

            If grdPRTable.SelectedDataKey("GA_ID") = 1060 Or grdPRTable.SelectedDataKey("GA_ID") = 1067 Then
                '=-= LAND

            ElseIf grdPRTable.SelectedDataKey("GA_ID") = 1082 Or grdPRTable.SelectedDataKey("GA_ID") = 1085 Then
                '=-= BUILDINGS

            ElseIf grdPRTable.SelectedDataKey("GA_ID") = 1166 Then
                '=-= TRANSPORTATION
                Me.mvItems.SetActiveView(Me.vwMotors)

                If dtItems.Rows.Count = 0 Then
                    lblMName.Text = ""
                    lblMModel.Text = ""
                    lblMChasis.Text = ""
                    lblMColor.Text = ""
                    lblMDName.Text = ""
                    lblMCapacity.Text = ""
                    lblMWeight.Text = ""
                    lblMSeats.Text = ""
                    lblMWarranty.Text = ""
                    lblMUser.Text = ""
                    lblMSpecs.Text = ""

                    lblReceivedDate.Text = ""
                    lblReceivedBy.Text = ""
                    lblInspectedBy.Text = ""
                    lblAcceptedDate.Text = ""
                    lblAcceptedBy.Text = ""
                Else
                    lblMName.Text = dtItems.Rows(0)("Name")
                    lblMModel.Text = dtItems.Rows(0)("Model")
                    lblMChasis.Text = dtItems.Rows(0)("ChasisNo")
                    lblMColor.Text = dtItems.Rows(0)("VehicleColor")
                    lblMDName.Text = dtItems.Rows(0)("DeclaredName")
                    lblMCapacity.Text = dtItems.Rows(0)("WheelsCapacity")
                    lblMWeight.Text = dtItems.Rows(0)("GrossWeight")
                    lblMSeats.Text = dtItems.Rows(0)("Seats")
                    lblMWarranty.Text = dtItems.Rows(0)("Warranty")
                    lblMUser.Text = dtItems.Rows(0)("BeneficialUser")
                    lblMSpecs.Text = dtItems.Rows(0)("VehicleSpecification")

                    lblReceivedDate.Text = dtItems.Rows(0)("Date_Received")
                    lblReceivedBy.Text = dtItems.Rows(0)("ReceivedBy")
                    lblInspectedBy.Text = dtItems.Rows(0)("InspectedBy")
                    lblAcceptedDate.Text = dtItems.Rows(0)("Date_Accepted")
                    lblAcceptedBy.Text = dtItems.Rows(0)("AcceptedBy")

                End If


            Else '=-= ALL EQUIPMENTS AND FURNITURE AND FIXTURES AND MACHINIRIES
                Me.mvItems.SetActiveView(Me.vwEquipments)

                If dtItems.Rows.Count = 0 Then
                    lblEName.Text = ""
                    lblEDescription.Text = ""
                    lblEPower.Text = ""
                    lblEDimension.Text = ""
                    lblEArea.Text = ""
                    lblEModel.Text = ""
                    lblEWarranty.Text = ""
                    lblESpecs.Text = ""
                    lblEDRate.Text = ""
                    lblEDValue.Text = ""

                    lblReceivedDate.Text = ""
                    lblReceivedBy.Text = ""
                    lblInspectedBy.Text = ""
                    lblAcceptedDate.Text = ""
                    lblAcceptedBy.Text = ""

                Else
                    lblEName.Text = dtItems.Rows(0)("Name")
                    lblEDescription.Text = dtItems.Rows(0)("Description")
                    lblEPower.Text = dtItems.Rows(0)("PowerInput")
                    lblEDimension.Text = dtItems.Rows(0)("Dimension")
                    lblEArea.Text = dtItems.Rows(0)("AreaCapacity")
                    lblEModel.Text = dtItems.Rows(0)("Model")
                    lblEWarranty.Text = dtItems.Rows(0)("Warranty")
                    lblESpecs.Text = dtItems.Rows(0)("Specification")
                    lblEDRate.Text = dtItems.Rows(0)("DepreciationRate")
                    lblEDValue.Text = dtItems.Rows(0)("DepreciationValue")

                    lblReceivedDate.Text = dtItems.Rows(0)("Date_Received")
                    lblReceivedBy.Text = dtItems.Rows(0)("ReceivedBy")
                    lblInspectedBy.Text = dtItems.Rows(0)("InspectedBy")
                    lblAcceptedDate.Text = dtItems.Rows(0)("Date_Accepted")
                    lblAcceptedBy.Text = dtItems.Rows(0)("AcceptedBy")

                    If dtItems.Rows(0)("isComplete") = True Then
                        rbStatus.SelectedIndex = 1
                    Else
                        rbStatus.SelectedIndex = 0
                    End If

                End If

            End If

        Else '=== WITHOUT PO


        End If


    End Sub

    Protected Sub grdPRTable_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        If Session("Search") = 1 Then
            pPRTable = objDerived.GetDataTable("EXEC [AMS].[sp_PRTableList_Search] '" & txtSearch.Text & "'", CommandType.Text)
            If pPRTable.Rows.Count < 8 Then
                pPRTable.Merge(CreateTable1(8 - pPRTable.Rows.Count))
            End If
            grdPRTable.PageIndex = e.NewPageIndex
            grdPRTable.DataSource = pPRTable
            grdPRTable.DataBind()

        ElseIf Session("Search") = 0 Then
            pPRTable = objDerived.GetDataTable("EXEC [AMS].[sp_PRTableList]", CommandType.Text)
            If pPRTable.Rows.Count < 8 Then
                pPRTable.Merge(CreateTable1(8 - pPRTable.Rows.Count))
            End If
            grdPRTable.PageIndex = e.NewPageIndex
            grdPRTable.DataSource = pPRTable
            grdPRTable.DataBind()
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pPRTable = objDerived.GetDataTable("EXEC [AMS].[sp_PRTableList_Search] '" & txtSearch.Text & "'", CommandType.Text)
        If pPRTable.Rows.Count < 8 Then
            pPRTable.Merge(CreateTable1(8 - pPRTable.Rows.Count))
        End If
        grdPRTable.DataSource = pPRTable
        grdPRTable.DataBind()

        Session("Search") = 1

    End Sub
End Class
