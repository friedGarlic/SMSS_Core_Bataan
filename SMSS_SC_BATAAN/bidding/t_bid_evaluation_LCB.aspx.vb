Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control

Partial Class bidding_t_bid_evaluation_LCB
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

#Region "Property"
    Private Property pBidEvaluation() As DataTable
        Get
            Return CType(Session("pBidEvaluation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation") = value
        End Set
    End Property
    Private Property pBidEvaluation_Goods() As DataTable
        Get
            Return CType(Session("pBidEvaluation_Goods"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation_Goods") = value
        End Set
    End Property
    Private Property pBidEvaluation_Bidders() As DataTable
        Get
            Return CType(Session("pBidEvaluation_Bidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pBidEvaluation_Bidders") = value
        End Set
    End Property
    Private Property dt() As DataTable
        Get
            Return CType(Session("dt"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dt") = value
        End Set
    End Property
#End Region
#Region "Function"
    Public Function CreateTable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("RefNumber", GetType(String))
        dt.Columns.Add("BidLocation", GetType(String))
        dt.Columns.Add("countSupplier", GetType(Integer))
        dt.Columns.Add("TotalABC", GetType(Decimal))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))
        dt.Columns.Add("obr_evaluation_hdr_id", GetType(Long))
        dt.Columns.Add("isPublicInfra", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("RefNumber") = DBNull.Value
            dr("BidLocation") = DBNull.Value
            dr("countSupplier") = DBNull.Value
            dr("TotalABC") = DBNull.Value
            dr("pre_procurement_hdr_id") = DBNull.Value
            dr("obr_evaluation_hdr_id") = DBNull.Value
            dr("isPublicInfra") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function CreateTable2(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("NoItems", GetType(Integer))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("pre_procurement_hdr_id", GetType(Long))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("SuppName") = DBNull.Value
            dr("NoItems") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("pre_procurement_hdr_id") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
            If pBidEvaluation.Rows.Count < 5 Then
                pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
            End If
            grdBidEvaluation.DataSource = pBidEvaluation
            grdBidEvaluation.DataBind()

            grdGoods.DataSource = Nothing
            grdGoods.DataBind()

            txtDate.Text = Date.Today.ToString("MM/dd/yyyy")

            LoadDropdown()

        End If
    End Sub
    Public Sub LoadBidders()


    End Sub
    Protected Sub drpListOfBidders_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim drp As DropDownList
        For i As Integer = 0 To grdGoods.Rows.Count - 1
            drp = CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList)
            If drpListOfBidders.selecteditem.text = "Select" Then
                drp.SelectedIndex = drpListOfBidders.SelectedIndex

            Else
                drp.SelectedIndex = drpListOfBidders.SelectedIndex
                btnWinner.Enabled = True
            End If
        Next
    End Sub

    Protected Sub grdBidEvaluation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        pBidEvaluation_Goods = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_Goods] '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)

        grdGoods.DataSource = pBidEvaluation_Goods
        grdGoods.DataBind()

        For i As Integer = 0 To pBidEvaluation_Goods.Rows.Count - 1
            dt = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_LCB]  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "','" & pBidEvaluation_Goods.Rows(i)("Item_ID") & "'", CommandType.Text)
            CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).DataSource = dt
            CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).DataTextField = ("BidderName")
            CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).DataValueField = ("Supplier_Id")
            CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).DataBind()
            CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).Items.Insert(0, "Select")
            drpListOfBidders.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_LCB]  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "','" & pBidEvaluation_Goods.Rows(i)("Item_ID") & "'", CommandType.Text)
            drpListOfBidders.DataTextField = ("SuppName")
            drpListOfBidders.DataValueField = ("Supplier_Id")
            drpListOfBidders.DataBind()
            drpListOfBidders.Items.Insert(0, "Select")

        Next

        Dim dtEndUser As New DataTable
        dtEndUser = objDerived.GetDataTable("SELECT * FROM [dbo].[View_PubBidding_EndUser] WHERE pre_procurement_hdr_id = '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "'", CommandType.Text)
        ddEndUser.DataSource = dtEndUser
        ddEndUser.DataTextField = ("full_name")
        ddEndUser.DataValueField = ("empid")
        ddEndUser.DataBind()
        ddEndUser.Items.Insert(0, "Select")

        'If dtEndUser.Rows(0)("RC_ID") = 20 Then
        '    lblBAC_Pos.Text = "BAC Member 4 : "
        'Else
        '    lblBAC_Pos.Text = "BAC Vice Chairman : "
        'End If

        LoadSignatoryEnable()

    End Sub

    Protected Sub grdBidEvaluation_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            e.Row.Attributes.Add("onmouseout", "this.style.cursor='arrow';")
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackEventReference(grdBidEvaluation, "Select$" + e.Row.RowIndex.ToString()))
        End If
    End Sub

    Protected Sub grdBidEvaluation_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation.PageIndex = e.NewPageIndex
        grdBidEvaluation.DataSource = pBidEvaluation
        grdBidEvaluation.DataBind()
    End Sub

    Protected Sub ddBidder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim count As Integer = 0
        Dim dt2 As New DataTable
        Dim dr As DataRow

        For i As Integer = 0 To grdGoods.Rows.Count - 1
            Dim row As Integer
            row = CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedIndex

            If row <> 0 Then
                dt = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_LCB]  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "','" & pBidEvaluation_Goods.Rows(i)("Item_ID") & "'", CommandType.Text)
                Dim BidQty As Integer = dt.Rows(CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedIndex - 1)("BidQty")
                Dim BidPrice As Decimal = dt.Rows(CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedIndex - 1)("BidAmount")
                Dim PRQty As Integer = pBidEvaluation_Goods.Rows(i)("Qty")

                If BidQty > PRQty Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Bid quantity is more than the remaining PR quanity.")
                    Exit Sub
                End If

                Dim Total As Decimal = BidPrice * BidQty
                CType(grdGoods.Rows(i).FindControl("lblTotal"), Label).Text = FormatNumber(Total, 2)

                If Total = 0 Then
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "The selected bidder has no item available, select another bidder.")
                    Exit Sub
                End If

                '=-= IF NOT ALL QTY FOR A SINGLE BIDDER
                If BidQty <> PRQty Then
                    CType(grdGoods.Rows(i).FindControl("lblQty"), Label).Text = BidQty

                    dt2.Columns.Add("Item_Desc", GetType(String))
                    dt2.Columns.Add("Qty", GetType(Integer))
                    dt2.Columns.Add("Unit", GetType(String))
                    dt2.Columns.Add("Cost", GetType(Decimal))
                    dt2.Columns.Add("Total", GetType(Decimal))
                    dt2.Columns.Add("pre_procurement_hdr_id", GetType(Long))
                    dt2.Columns.Add("Item_Id", GetType(Long))

                    dt2 = pBidEvaluation_Goods
                    dr = dt2.NewRow
                    dr("Item_Desc") = pBidEvaluation_Goods.Rows(i)("Item_Desc")
                    dr("Qty") = (PRQty - BidQty)
                    dr("Unit") = pBidEvaluation_Goods.Rows(i)("Unit")
                    dr("Cost") = pBidEvaluation_Goods.Rows(i)("Cost")
                    dr("Total") = ((PRQty - BidQty) * pBidEvaluation_Goods.Rows(i)("Cost"))
                    dr("pre_procurement_hdr_id") = pBidEvaluation_Goods.Rows(i)("pre_procurement_hdr_id")
                    dr("Item_Id") = pBidEvaluation_Goods.Rows(i)("Item_Id")
                    dt2.Rows.Add(dr)

                    pBidEvaluation_Goods.Rows(i)("Qty") = BidQty
                    count = 1
                End If
            End If
        Next

        If count = 1 Then
            pBidEvaluation_Goods = dt2
            grdGoods.DataSource = pBidEvaluation_Goods
            grdGoods.DataBind()

            For rows As Integer = 0 To grdGoods.Rows.Count - 1
                Dim dtb As New DataTable
                dtb = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_LCB]  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "','" & pBidEvaluation_Goods.Rows(rows)("Item_ID") & "'", CommandType.Text)
                CType(grdGoods.Rows(rows).FindControl("ddBidder"), DropDownList).DataSource = dtb
                CType(grdGoods.Rows(rows).FindControl("ddBidder"), DropDownList).DataTextField = ("BidderName")
                CType(grdGoods.Rows(rows).FindControl("ddBidder"), DropDownList).DataValueField = ("Supplier_Id")
                CType(grdGoods.Rows(rows).FindControl("ddBidder"), DropDownList).DataBind()
                CType(grdGoods.Rows(rows).FindControl("ddBidder"), DropDownList).Items.Insert(0, "Select")
                drpListOfBidders.DataSource = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation_LCB]  '" & grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id") & "','" & pBidEvaluation_Goods.Rows(rows)("Item_ID") & "'", CommandType.Text)
                drpListOfBidders.DataTextField = ("SuppName")
                drpListOfBidders.DataValueField = ("Supplier_Id")
                drpListOfBidders.DataBind()
                drpListOfBidders.Items.Insert(0, "Select")
            Next
        End If


        '=-= SUM THE TOTAL AMOUNT
        If grdGoods.Rows.Count <> 0 Then
            Dim x As Decimal = 0
            For i As Integer = 0 To grdGoods.Rows.Count - 1
                If CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedIndex <> 0 Then
                    Dim lblTotal As Label = CType(grdGoods.Rows(i).FindControl("lblTotal"), Label)
                    x = x + lblTotal.Text
                End If
            Next

            CType(grdGoods.FooterRow.Cells(5).FindControl("lblTotalBid"), Label).Text = FormatNumber(x, 2)
        End If


        '=-= ENABLE BTN WINNERS IF ALL ITEMS ARE SET
        Dim En As Integer = 1
        For i As Integer = 0 To grdGoods.Rows.Count - 1
            If CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Text = "Select" Then
                En = 0
            End If
        Next

        If En = 1 Then
            If CType(grdGoods.FooterRow.Cells(5).FindControl("lblTotalBid"), Label).Text > grdBidEvaluation.SelectedDataKey("TotalABC") Then
                btnWinner.Enabled = False
            Else
                btnWinner.Enabled = True
            End If
        Else
            btnWinner.Enabled = False
        End If

    End Sub

    Protected Sub btnWinner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            AddTrace("=== START: btnWinner_Click ===")
            AddTrace("Selected BAC Setup: " & ddBACSetup.SelectedValue)

            ' Validate BAC Members based on selected setup (3 or 5)
            If ddBACSetup.SelectedValue = "5" Then
                If String.IsNullOrEmpty(ddBAC1.SelectedItem.Text) Or
               String.IsNullOrEmpty(ddBAC2.SelectedItem.Text) Or
               String.IsNullOrEmpty(ddBAC3.SelectedItem.Text) Or
               String.IsNullOrEmpty(ddBAC4.SelectedItem.Text) Or
               String.IsNullOrEmpty(ddBAC5.SelectedItem.Text) Then
                    AddTrace("Validation Failed: Not all 5 BAC Members are selected.")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select all required BAC members.")
                    Exit Sub
                End If
            Else
                If String.IsNullOrEmpty(ddBAC1.SelectedItem.Text) Or
               String.IsNullOrEmpty(ddBAC2.SelectedItem.Text) Or
               String.IsNullOrEmpty(ddBAC3.SelectedItem.Text) Then
                    AddTrace("Validation Failed: Not all 3 BAC Members are selected.")
                    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select all required BAC members.")
                    Exit Sub
                End If
            End If

            ' Validate Other Required Fields
            If String.IsNullOrEmpty(ddBACVC.SelectedItem.Text) Or
           String.IsNullOrEmpty(ddBACC.SelectedItem.Text) Or
           String.IsNullOrEmpty(ddBACTWGH.SelectedItem.Text) Then
                AddTrace("Validation Failed: One or more BAC Signatories are not selected.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select all BAC signatories.")
                Exit Sub
            End If

            If ddEndUser.SelectedItem.Text = "Select" Then
                AddTrace("Validation Failed: End User not selected.")
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select the End User.")
                Exit Sub
            End If

        Catch ex As Exception
            AddTrace("Exception Occurred: " & ex.Message)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
            Exit Sub
        End Try

        '===============================================================================

        Dim SuppID As Long
        Dim ItemID As Long
        Dim PreProcurementID As Long = grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id")
        AddTrace("PreProcurementID: " & PreProcurementID)

        ' Update Winning Supplier in bid_opening_dtl
        For i As Integer = 0 To pBidEvaluation_Goods.Rows.Count - 1
            SuppID = CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Value
            ItemID = pBidEvaluation_Goods.Rows(i)("Item_ID")
            AddTrace("Processing Supplier - SuppID: " & SuppID & ", ItemID: " & ItemID)

            Dim hdrID As Long = objDerived.GetValue("SELECT bid_opening_hdr_id FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & PreProcurementID & "' AND Supplier_ID = '" & SuppID & "'", CommandType.Text)
            AddTrace("Retrieved hdrID: " & hdrID)

            objDerived.GetRecords("UPDATE AMS.bid_opening_dtl SET withwinner = 1 WHERE bid_opening_hdr_id = '" & hdrID & "' AND Item_ID = '" & ItemID & "'", CommandType.Text)
            AddTrace("Updated bid_opening_dtl for hdrID: " & hdrID & ", ItemID: " & ItemID)
        Next

        ' Build SQL Update Query for pre_procurement
        Dim sqlQuery As String = "UPDATE AMS.pre_procurement SET " &
                             "EvaluationDate = '" & txtDate.Text & "', " &
                             "withWinner = 1, " &
                             "BACC = '" & ddBACC.SelectedItem.Text & "', " &
                             "BACVC = '" & ddBACVC.SelectedItem.Text & "', " &
                             "BAC1 = '" & ddBAC1.SelectedItem.Text & "', " &
                             "BAC2 = '" & ddBAC2.SelectedItem.Text & "', " &
                             "BAC3 = '" & ddBAC3.SelectedItem.Text & "', " &
                             "BAC4 = " & If(ddBACSetup.SelectedValue = "5", "'" & ddBAC4.SelectedItem.Text & "'", "NULL") & ", " &
                             "BAC5 = " & If(ddBACSetup.SelectedValue = "5", "'" & ddBAC5.SelectedItem.Text & "'", "NULL") & ", " &
                             "ENDUSER = '" & ddEndUser.SelectedItem.Text & "', " &
                             "TWGH = '" & ddBACTWGH.SelectedItem.Text & "', " &
                             "remarks = '" & txtRemarks.Text & "' " &
                             "WHERE pre_procurement_hdr_id = '" & PreProcurementID & "'"

        ' Execute Update Query
        objDerived.GetRecords(sqlQuery, CommandType.Text)
        AddTrace("Executed SQL Query: " & sqlQuery)

        ' Show Success Message
        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

        ' Refresh Grid
        pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
        If pBidEvaluation.Rows.Count < 5 Then
            pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
        End If
        grdBidEvaluation.DataSource = pBidEvaluation
        grdBidEvaluation.DataBind()

        grdGoods.DataSource = Nothing
        grdGoods.DataBind()

        ' Disable Signatories and Button
        LoadSignatoryDisEnable()
        btnWinner.Enabled = False

        AddTrace("=== END: btnWinner_Click ===")

    End Sub

    Private Sub AddTrace(ByVal message As String)
        ' Prevent single quotes in the message from breaking JavaScript
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub



    'Protected Sub btnWinner_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If ddBACSetup.SelectedValue = 5 Then
    '            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Or ddBAC4.SelectedItem.Text = "" Or ddBAC5.SelectedItem.Text = "" Then
    '            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Or ddBACTWGH.SelectedItem.Text = "" Then
    '            ElseIf ddEndUser.SelectedItem.Text = "Select" Then
    '                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
    '                Exit Sub
    '            End If
    '        Else

    '            If ddBAC1.SelectedItem.Text = "" Or ddBAC2.SelectedItem.Text = "" Or ddBAC3.SelectedItem.Text = "" Then
    '            ElseIf ddBACVC.SelectedItem.Text = "" Or ddBACC.SelectedItem.Text = "" Or ddBACTWGH.SelectedItem.Text = "" Then
    '            ElseIf ddEndUser.SelectedItem.Text = "Select" Then
    '                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatory")
    '                Exit Sub
    '            End If
    '        End If


    '    Catch ex As Exception
    '        MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Set default BAC signatories in File Maintenance.")
    '        Exit Sub
    '    End Try

    '    '===============================================================================

    '    Dim SuppID As Long
    '    Dim ItemID As Long
    '    Dim PreProcurementID As Long = grdBidEvaluation.SelectedDataKey("pre_procurement_hdr_id")

    '    Dim dd As New DataTable
    '    dd = pBidEvaluation_Goods

    '    For i As Integer = 0 To pBidEvaluation_Goods.Rows.Count - 1
    '        SuppID = CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedItem.Value
    '        ItemID = pBidEvaluation_Goods.Rows(i)("Item_ID") 'dt.Rows(CType(grdGoods.Rows(i).FindControl("ddBidder"), DropDownList).SelectedIndex - 1)("Item_ID")

    '        Dim hdrID As Long = objDerived.GetValue("SELECT bid_opening_hdr_id FROM AMS.bid_opening_hdr WHERE pre_procurement_hdr_id = '" & PreProcurementID & "' AND Supplier_ID = '" & SuppID & "'", CommandType.Text)
    '        objDerived.GetRecords("UPDATE AMS.bid_opening_dtl SET withwinner = 1 where bid_opening_hdr_id = '" & hdrID & "' AND Item_ID = '" & ItemID & "'", CommandType.Text)

    '    Next

    '    objDerived.GetRecords("UPDATE AMS.pre_procurement SET EvaluationDate = '" & txtDate.Text & "', withWinner = 1,BACC = '" & ddBACC.SelectedItem.Text & "', BACVC = '" & ddBACVC.SelectedItem.Text & "', BAC1 = '" & ddBAC1.SelectedItem.Text & "', BAC2 = '" & ddBAC2.SelectedItem.Text & "', BAC3 = '" & ddBAC3.SelectedItem.Text & "', ENDUSER = '" & ddEndUser.SelectedItem.Text & "',TWGH = '" & ddBACTWGH.SelectedItem.Text & "' " &
    '                        " ,remarks = '" & txtRemarks.Text & "' WHERE pre_procurement_hdr_id = '" & PreProcurementID & "'", CommandType.Text)
    '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

    '    pBidEvaluation = objDerived.GetDataTable("EXEC [AMS].[sp_BidEvaluation]", CommandType.Text)
    '    If pBidEvaluation.Rows.Count < 5 Then
    '        pBidEvaluation.Merge(CreateTable1(5 - pBidEvaluation.Rows.Count))
    '    End If
    '    grdBidEvaluation.DataSource = pBidEvaluation
    '    grdBidEvaluation.DataBind()

    '    grdGoods.DataSource = Nothing
    '    grdGoods.DataBind()

    '    LoadSignatoryDisEnable()
    '    btnWinner.Enabled = False


    'End Sub

    Protected Sub LoadDropdown()
        '=== SIGNATORIES
        ddBAC1.ClearSelection()
        ddBAC2.ClearSelection()
        ddBAC3.ClearSelection()
        ddBACVC.ClearSelection()
        ddBACC.ClearSelection()

        ddBAC1.DataSource = objDerived.GetDataTable("SELECT * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5 OR [BAC_PostionID] = 4 OR [BAC_PostionID] = 3", CommandType.Text)
        ddBAC1.DataTextField = ("Name")
        ddBAC1.DataValueField = ("empsig_id")
        ddBAC1.DataBind()

        ddBAC2.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5 OR [BAC_PostionID] = 4 OR [BAC_PostionID] = 3", CommandType.Text)
        ddBAC2.DataTextField = ("Name")
        ddBAC2.DataValueField = ("empsig_id")
        ddBAC2.DataBind()

        ddBAC3.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5 OR [BAC_PostionID] = 4 OR [BAC_PostionID] = 3", CommandType.Text)
        ddBAC3.DataTextField = ("Name")
        ddBAC3.DataValueField = ("empsig_id")
        ddBAC3.DataBind()


        ddBAC4.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5 OR [BAC_PostionID] = 4 OR [BAC_PostionID] = 3", CommandType.Text)
        ddBAC4.DataTextField = ("Name")
        ddBAC4.DataValueField = ("empsig_id")
        ddBAC4.DataBind()


        ddBAC5.DataSource = objDerived.GetDataTable("SELECT  * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 5 OR [BAC_PostionID] = 4 OR [BAC_PostionID] = 3", CommandType.Text)
        ddBAC5.DataTextField = ("Name")
        ddBAC5.DataValueField = ("empsig_id")
        ddBAC5.DataBind()


        ddBACVC.DataSource = objDerived.GetDataTable("SELECT TOP (1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2 ", CommandType.Text)
        ddBACVC.DataTextField = ("Name")
        ddBACVC.DataValueField = ("empsig_id")
        ddBACVC.DataBind()

        ddBACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
        ddBACC.DataTextField = ("Name")
        ddBACC.DataValueField = ("empsig_id")
        ddBACC.DataBind()

        ddBACTWGH.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 12", CommandType.Text)
        ddBACTWGH.DataTextField = ("Name")
        ddBACTWGH.DataValueField = ("empsig_id")
        ddBACTWGH.DataBind()

    End Sub

    Protected Sub ddBACSetup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddBACSetup.SelectedValue = "3" Then
            trBAC4.Visible = False
            trBAC5.Visible = False
            ddBAC4.Enabled = False
            ddBAC5.Enabled = False
        Else
            trBAC4.Visible = True
            trBAC5.Visible = True
            ddBAC4.Enabled = True
            ddBAC5.Enabled = True
        End If
    End Sub



    Protected Sub LoadSignatoryEnable()
        ddBAC1.Enabled = True
        ddBAC2.Enabled = True
        ddBAC3.Enabled = True
        ddBACVC.Enabled = True
        ddBACC.Enabled = True
        ddEndUser.Enabled = True
        ddBACTWGH.Enabled = True

        'If ddBACSetup.SelectedValue = "5" Then
        '    ddBAC4.Enabled = True
        '    ddBAC5.Enabled = True
        'Else
        '    ddBAC4.Enabled = False
        '    ddBAC5.Enabled = False
        'End If
    End Sub


    Protected Sub LoadSignatoryDisEnable()
        ddBAC1.Enabled = False
        ddBAC2.Enabled = False
        ddBAC3.Enabled = False
        ddBACVC.Enabled = False
        ddBACC.Enabled = False
        ddEndUser.Enabled = False
        ddBACTWGH.Enabled = False
        ddBAC4.Enabled = False
        ddBAC5.Enabled = False
    End Sub

End Class
