Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev_Construction
    Inherits System.Web.UI.UserControl

    Private objDerived As New DerivedDal

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindConstructionGrid()
            BindConstructionEquipmentsGrid()
            BindConstructionLedgerGrid()

            Session("GA_ID") = 0
            Session("SubClassificationID") = 0
        Else
            BindConstructionGrid()
            BindConstructionEquipmentsGrid()
        End If
    End Sub

    ' ============================
    ' REFRESH METHOD (same pattern)
    ' ============================
    Public Sub RefreshGridData()
        ' Store the current selected values before rebinding
        Dim selectedItemParticularId As String = Nothing
        Dim selectedItemId As String = Nothing

        If gvConstructionLocationList.SelectedIndex >= 0 AndAlso gvConstructionLocationList.DataKeys.Count > gvConstructionLocationList.SelectedIndex Then
            selectedItemParticularId = gvConstructionLocationList.DataKeys(gvConstructionLocationList.SelectedIndex).Values("item_particular_id").ToString()
            selectedItemId = gvConstructionLocationList.DataKeys(gvConstructionLocationList.SelectedIndex).Values("Item_ID").ToString()
        End If

        ' Decide which MultiView to show based on SubClassification
        DecideSubClassView()

        BindConstructionGrid()

        ' Try to restore the selection
        If Not String.IsNullOrEmpty(selectedItemParticularId) Then
            For i As Integer = 0 To gvConstructionLocationList.Rows.Count - 1
                Dim dataKey = gvConstructionLocationList.DataKeys(i)
                If dataKey IsNot Nothing AndAlso dataKey.Values("item_particular_id").ToString() = selectedItemParticularId Then
                    gvConstructionLocationList.SelectedIndex = i
                    Exit For
                End If
            Next
        End If

        If gvConstructionLocationList.SelectedIndex >= 0 Then
            BindConstructionEquipmentsGrid()
        Else
            BindEmptyConstructionEquipmentsGrid()
        End If

        BindConstructionLedgerGrid()
    End Sub
    ' ============================
    ' LOCATION GRIDVIEW FUNCTIONS
    ' ============================
    Private Sub BindConstructionGrid()
        Dim subClass As String = If(Session("SubClassificationID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim dt As DataTable = GetConstructionLocationData(subClass, gaId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvConstructionLocationList.DataSource = dt
            gvConstructionLocationList.DataBind()
        Else
            BindEmptyConstructionGrid()
        End If
    End Sub

    Private Function GetConstructionLocationData(ByVal subClassId As String, ByVal gaId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("subClassId: " & subClassId)
            AddTrace("gaId: " & gaId)

            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Construction_ListOfLocation] '" & subClassId & "', '" & gaId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading construction locations: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyConstructionGrid()
        Dim dt As DataTable = CreateConstructionLocationSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        gvConstructionLocationList.DataSource = dt
        gvConstructionLocationList.DataBind()
    End Sub

    Private Function CreateConstructionLocationSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("item_particular_id", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("DeclaredOwner", GetType(String))
        dt.Columns.Add("Barangay", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("Area", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))
        Return dt
    End Function

    ' LOCATION EVENTS
    Protected Sub gvConstructionLocationList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvConstructionLocationList.PageIndex = e.NewPageIndex
        BindConstructionGrid()
    End Sub

    Protected Sub gvConstructionLocationList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If gvConstructionLocationList.SelectedIndex >= 0 Then
            Dim selectedItemId As String = gvConstructionLocationList.SelectedDataKey("Item_ID")
            Session("Item_ID") = selectedItemId
            BindConstructionEquipmentsGrid()


            Dim dt As DataTable = GetConstructionLedgerData(Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                FormatConstructionLedgerTransType(dt)

                grdConstructionLedger.DataSource = dt
                grdConstructionLedger.DataBind()
            Else
                BindEmptyConstructionLedgerGrid()
            End If

        End If
    End Sub

    Protected Sub gvConstructionLocationList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvConstructionLocationList, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    ' ============================
    ' EQUIPMENTS LIST GRIDVIEW
    ' ============================
    Protected Sub btnConstructionPropSearch_Click(sender As Object, e As EventArgs)
        Dim searchText As String = txtConstructionPropSearch.Text.Trim()

        ' If no search value → show full list using existing logic
        If String.IsNullOrEmpty(searchText) Then
            AddTrace("Construction Search: empty, loading full list.")
            BindConstructionEquipmentsGrid()
            Exit Sub
        End If

        ' Replicate the same parameter logic used in BindConstructionEquipmentsGrid
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""

        If gvConstructionLocationList.SelectedIndex >= 0 AndAlso gvConstructionLocationList.DataKeys.Count > gvConstructionLocationList.SelectedIndex Then
            Dim dataKey = gvConstructionLocationList.DataKeys(gvConstructionLocationList.SelectedIndex)
            If dataKey IsNot Nothing Then
                itemParticularId = dataKey.Values("item_particular_id").ToString()
                itemId = dataKey.Values("Item_ID").ToString()
                declaredOwner = dataKey.Values("DeclaredOwner").ToString()
                barangay = dataKey.Values("Barangay").ToString()
            End If
        Else
            ' If no row is selected, show a message and exit
            AddTrace("Please select a location first")
            BindEmptyConstructionEquipmentsGrid()
            Exit Sub
        End If

        AddTrace("Construction Search: " & searchText &
             " | itemParticularId=" & itemParticularId &
             " | itemId=" & itemId &
             " | gaId=" & gaId &
             " | declaredOwner=" & declaredOwner &
             " | barangay=" & barangay)

        ' Get the same dataset that BindConstructionEquipmentsGrid would bind
        Dim dt As DataTable = GetConstructionEquipmentsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BindEmptyConstructionEquipmentsGrid()
            Exit Sub
        End If

        ' Filter by PropertyNo LIKE '%txtConstructionPropSearch%'
        Dim dv As New DataView(dt)

        ' Escape special characters for RowFilter
        Dim safeSearch As String = searchText.Replace("'", "''").Replace("[", "[[]").Replace("]", "]]")

        dv.RowFilter = "PropertyNo LIKE '%" & safeSearch & "%'"

        If dv.Count > 0 Then
            grdListOfConstructionEquipments.DataSource = dv
            grdListOfConstructionEquipments.DataBind()
        Else
            BindEmptyConstructionEquipmentsGrid()
        End If
    End Sub


    Private Sub BindConstructionEquipmentsGrid()
        Dim itemId As String = If(Session("Item_ID"), "0")
        Dim gaId As String = If(Session("GA_ID"), "0")

        Dim itemParticularId As String = "0"
        Dim declaredOwner As String = ""
        Dim barangay As String = ""
        Try

            If gvConstructionLocationList.SelectedIndex >= 0 AndAlso gvConstructionLocationList.DataKeys.Count > gvConstructionLocationList.SelectedIndex Then
                Dim dataKey = gvConstructionLocationList.DataKeys(gvConstructionLocationList.SelectedIndex)
                If dataKey IsNot Nothing Then
                    itemParticularId = dataKey.Values("item_particular_id").ToString()
                    itemId = dataKey.Values("Item_ID").ToString()
                    declaredOwner = dataKey.Values("DeclaredOwner").ToString()
                    barangay = dataKey.Values("Barangay").ToString()
                End If
            End If

            AddTrace("itemParticularId: " & itemParticularId)
            AddTrace("itemId: " & itemId)
            AddTrace("gaId: " & gaId)
            AddTrace("declaredOwner: " & declaredOwner)
            AddTrace("barangay: " & barangay)

            Dim dt As DataTable = GetConstructionEquipmentsData(itemParticularId, itemId, gaId, declaredOwner, barangay)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                grdListOfConstructionEquipments.DataSource = dt
                grdListOfConstructionEquipments.DataBind()
            Else
                BindEmptyConstructionEquipmentsGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetConstructionEquipmentsData(ByVal itemParticularId As String, ByVal itemId As String, ByVal gaId As String, ByVal declaredOwner As String, ByVal barangay As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Construction_ListOfEquipments] '" & itemParticularId & "', '" & itemId & "', '" & gaId & "', '" & declaredOwner & "', '" & barangay & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading construction equipments: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyConstructionEquipmentsGrid()
        Dim dt As DataTable = CreateConstructionEquipmentsSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdListOfConstructionEquipments.DataSource = dt
        grdListOfConstructionEquipments.DataBind()
    End Sub

    Private Function CreateConstructionEquipmentsSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Property_code", GetType(String))
        dt.Columns.Add("ItemDescription", GetType(String))
        dt.Columns.Add("Title", GetType(String))
        dt.Columns.Add("Author", GetType(String))
        dt.Columns.Add("Unit", GetType(String))
        dt.Columns.Add("AcqDate", GetType(String))
        dt.Columns.Add("AcqCost", GetType(Decimal))
        dt.Columns.Add("MarketValue", GetType(Decimal))

        dt.Columns.Add("Property_ID", GetType(String))
        dt.Columns.Add("PropertyDetai_ID", GetType(String))
        dt.Columns.Add("Item_ID", GetType(String))
        dt.Columns.Add("Received_ID", GetType(String))
        dt.Columns.Add("AcquisitionCost", GetType(Decimal))
        dt.Columns.Add("Received_Date", GetType(DateTime))
        dt.Columns.Add("Date_Accepted", GetType(DateTime))
        dt.Columns.Add("useful_life", GetType(String))
        dt.Columns.Add("Received_Dtl_ID", GetType(String))

        Return dt
    End Function

    ' EQUIPMENTS EVENTS
    Protected Sub grdListOfConstructionEquipments_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grdListOfConstructionEquipments.PageIndex = e.NewPageIndex
        BindConstructionEquipmentsGrid()
    End Sub

    Protected Sub grdListOfConstructionEquipments_SelectedIndexChanged(sender As Object, e As EventArgs)
        If grdListOfConstructionEquipments.SelectedIndex >= 0 Then

            Dim selectedPropertyId As String = grdListOfConstructionEquipments.SelectedDataKey("Property_ID")
            Session("Property_ID") = selectedPropertyId

            Dim propertyDtlId As String = grdListOfConstructionEquipments.DataKeys(grdListOfConstructionEquipments.SelectedIndex).Values("PropertyDetai_ID").ToString()
            PopulateConstructionInformation(propertyDtlId)

            RefreshGridData()
        End If
    End Sub


    Private Sub FormatConstructionLedgerTransType(ByVal dt As DataTable)

        If dt Is Nothing Then
            Exit Sub
        End If

        If Not dt.Columns.Contains("Trans_Type") Then
            Exit Sub
        End If

        For Each row As DataRow In dt.Rows

            If row.IsNull("Trans_Type") Then
                Continue For
            End If

            Dim transType As String = row("Trans_Type").ToString().Trim()

            If String.IsNullOrEmpty(transType) Then
                Continue For
            End If

            ' Normalize all line-break formats first.
            transType = transType.Replace(vbCrLf, vbLf)
            transType = transType.Replace(vbCr, vbLf)

            ' Print "Originally issued to" on the next line with a dash.
            transType = Regex.Replace(
                transType,
                "\s*-?\s*(Originally issued to)",
                vbLf & "- $1",
                RegexOptions.IgnoreCase
            )

            ' Print "Transferred from" on the next line with a dash.
            transType = Regex.Replace(
                transType,
                "\s*-?\s*(Transferred from)",
                vbLf & "- $1",
                RegexOptions.IgnoreCase
            )

            ' Remove accidental blank lines.
            Do While transType.Contains(vbLf & vbLf)
                transType = transType.Replace(vbLf & vbLf, vbLf)
            Loop

            row("Trans_Type") = transType.Trim()

        Next

    End Sub

    Protected Sub grdListOfConstructionEquipments_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(grdListOfConstructionEquipments, "Select$" & e.Row.RowIndex)
            e.Row.Style("cursor") = "pointer"
        End If
    End Sub

    Protected Sub grdListOfConstructionEquipments_OnDataBound(sender As Object, e As EventArgs)
        ' reserved for future binding logic
    End Sub

    ' ============================
    ' ITEM INFORMATION
    ' ============================
    Private Function GetConstructionInformationData(ByVal propertyDtlId As String) As DataTable
        Dim dt As New DataTable()
        Try
            AddTrace("propertyDtlId: " & propertyDtlId)
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Construction_GetInformation] '" & propertyDtlId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading construction information: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function
    Private Sub PopulateConstructionInformation(ByVal propertyDtlId As String)
        Dim dt As DataTable = GetConstructionInformationData(propertyDtlId)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearConstructionInformationForm()
            Return
        End If

        Dim r As DataRow = dt.Rows(0)

        ' Decide ROAD vs BRIDGE based on SubClassificationName
        Dim name As String = GetSubClassificationName()
        Dim n As String = name.ToUpperInvariant()

        Dim roadKeys As String() = {
        "ROAD", "ROAD AND DRAINAGE", "ROAD/SLOPE",
        "PAVEMENT",
        "WALKWAYS",
        "PARKING AREA",
        "DRAINAGE", "DRAINAGE/CULVERT", "BOX CULVERT",
        "RETAINING WALL",
        "SLOPE PROTECTION"
    }

        Dim bridgeKeys As String() = {
        "BRIDGE",
        "BUILDING",
        "CARPENTRY SHOP",
        "SEWAGE TREATMENT",
        "SEPTIC TANK",
        "WATER SYSTEM",
        "FENCE", "FENCING", "FENCE AND RAILING",
        "FITNESS ROOM",
        "GUARD HOUSE",
        "ILLUMINATION",
        "POOL & BLEACHERS",
        "SCOUR PROTECTION"
    }

        Dim isRoad As Boolean = Array.Exists(roadKeys, Function(k) n.Contains(k))
        Dim isBridge As Boolean = Array.Exists(bridgeKeys, Function(k) n.Contains(k))

        If isBridge Then
            mvSubClass.SetActiveView(Me.vwBridge)
        Else
            mvSubClass.SetActiveView(Me.vwRoad)
            isRoad = True
        End If

        ' =======================
        ' ROAD VIEW POPULATION
        ' =======================
        If isRoad Then
            ' General info
            If dt.Columns.Contains("ProjectName") Then txtRoadProjectName.Text = r("ProjectName").ToString()
            If dt.Columns.Contains("RoadOrBridgeID") Then txtRoadID.Text = r("RoadOrBridgeID").ToString()

            If dt.Columns.Contains("InfrastructureName") Then
                txtRoadName.Text = r("InfrastructureName").ToString()
            ElseIf dt.Columns.Contains("Name") Then
                txtRoadName.Text = r("Name").ToString()
            End If

            If dt.Columns.Contains("InfrastructureClassification") Then txtRoadClassification.Text = r("InfrastructureClassification").ToString()
            If dt.Columns.Contains("RoadOrBridgeType") Then txtRoadType.Text = r("RoadOrBridgeType").ToString()

            If dt.Columns.Contains("InfrastructureLocation") Then txtRoadLocation.Text = r("InfrastructureLocation").ToString()
            If dt.Columns.Contains("InfrastructureLength") Then txtRoadLength.Text = r("InfrastructureLength").ToString()
            If dt.Columns.Contains("InfrastructureNoofLanes") Then txtNoofLane.Text = r("InfrastructureNoofLanes").ToString()
            If dt.Columns.Contains("InfrastructureWidth") Then txtRoadWidth.Text = r("InfrastructureWidth").ToString()
            If dt.Columns.Contains("InfrastructureLaneLength") Then txtRoadLaneLength.Text = r("InfrastructureLaneLength").ToString()
            If dt.Columns.Contains("InfrastructureLaneWidth") Then txtRoadLaneWidth.Text = r("InfrastructureLaneWidth").ToString()

            If dt.Columns.Contains("InfrastructureTrafficVolume") Then txtRoadTrafficVolume.Text = r("InfrastructureTrafficVolume").ToString()
            If dt.Columns.Contains("InfrastructureTrafficDirection") Then txtRoadTrafficDirection.Text = r("InfrastructureTrafficDirection").ToString()
            If dt.Columns.Contains("InfrastructureTrafficDate") AndAlso Not String.IsNullOrEmpty(r("InfrastructureTrafficDate").ToString()) Then
                txtTrafficDate.Text = Convert.ToDateTime(r("InfrastructureTrafficDate")).ToString("MM/dd/yyyy")
            End If

            If dt.Columns.Contains("InfrastructureSpeedLimit") Then txtRoadSpeedLimit.Text = r("InfrastructureSpeedLimit").ToString()
            If dt.Columns.Contains("InfrastructureElevation") Then txtRoadElevation.Text = r("InfrastructureElevation").ToString()
            If dt.Columns.Contains("InfrastructureSurfaceType") Then txtRoadSurfaceType.Text = r("InfrastructureSurfaceType").ToString()
            If dt.Columns.Contains("InfrastructureSurfaceCondition") Then txtRoadSurfaceCondition.Text = r("InfrastructureSurfaceCondition").ToString()

            If dt.Columns.Contains("InfrastructureFromStreet") Then txtRoadFromStreet.Text = r("InfrastructureFromStreet").ToString()
            If dt.Columns.Contains("InfrastructureToStreet") Then txtRoadtoStreet.Text = r("InfrastructureToStreet").ToString()
            If dt.Columns.Contains("InfrastructureSegmentLock") Then txtRoadSegmentLock.Text = r("InfrastructureSegmentLock").ToString()

            ' Left / Right
            If dt.Columns.Contains("LeftLfromAddress") Then txtRoadLfromAddress.Text = r("LeftLfromAddress").ToString()
            If dt.Columns.Contains("LeftLtoAddress") Then txtRoadLtoAddress.Text = r("LeftLtoAddress").ToString()
            If dt.Columns.Contains("LeftNWshldrWidth") Then txtRoadNorthWestWidth.Text = r("LeftNWshldrWidth").ToString()
            If dt.Columns.Contains("RightRfromAddress") Then txtRoadRfromAddress.Text = r("RightRfromAddress").ToString()
            If dt.Columns.Contains("RightRtoAddress") Then txtRoadRtoAddress.Text = r("RightRtoAddress").ToString()
            If dt.Columns.Contains("RightSEshldrWidth") Then txtRoadSouthEastWidth.Text = r("RightSEshldrWidth").ToString()

            ' Description / Remarks
            If dt.Columns.Contains("Description") Then txtDescriptionRoads.Text = r("Description").ToString()
            If dt.Columns.Contains("Remarks") Then txtRemarksRoads.Text = r("Remarks").ToString()

            ' Contractor
            If dt.Columns.Contains("Contractor") Then txtRoadContractor.Text = r("Contractor").ToString()
            If dt.Columns.Contains("ContactPerson") Then txtRoadContactPerson.Text = r("ContactPerson").ToString()
            If dt.Columns.Contains("ContactNo") Then txtRoadCellphoneNo.Text = r("ContactNo").ToString()

            ' Acquisition / Depreciation
            If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
                txtRoadAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
            ElseIf dt.Columns.Contains("dDate") AndAlso Not String.IsNullOrEmpty(r("dDate").ToString()) Then
                txtRoadAcqDate.Text = Convert.ToDateTime(r("dDate")).ToString("MM/dd/yyyy")
            End If

            If dt.Columns.Contains("MarketValue") Then
                txtRoadMarketValue.Text = FormatNumber(r("MarketValue"), 2)
            End If

            If dt.Columns.Contains("AcquisitionCost") Then
                txtRoadAcqCost.Text = FormatNumber(r("AcquisitionCost"), 2)
            ElseIf dt.Columns.Contains("DebitCost") Then
                txtRoadAcqCost.Text = FormatNumber(r("DebitCost"), 2)
            End If

            If dt.Columns.Contains("NoYears") Then txtRoadNoYears.Text = r("NoYears").ToString()

            If dt.Columns.Contains("DepreciationRate") Then
                txtRoadequipmentdepreciatedRate.Text = FormatNumber(r("DepreciationRate"), 2)
            End If

            If dt.Columns.Contains("UsefulLife") Then txtRoadUsefulLife.Text = r("UsefulLife").ToString()

            If dt.Columns.Contains("DepreciationValue") Then
                txtDepreciationRoad.Text = FormatNumber(r("DepreciationValue"), 2)
            End If

            If dt.Columns.Contains("SalvageValue") Then
                txtRoadSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
            End If

            If dt.Columns.Contains("DepreciatedValue") Then
                txtRoadequipmentdepreciatedvalue.Text = FormatNumber(r("DepreciatedValue"), 2)
            End If
        End If

        ' =========================
        ' BRIDGE VIEW POPULATION
        ' =========================
        If isBridge Then
            ' General info
            If dt.Columns.Contains("ProjectName") Then txtBridgeProjectName.Text = r("ProjectName").ToString()
            If dt.Columns.Contains("RoadOrBridgeID") Then txtBridgeID.Text = r("RoadOrBridgeID").ToString()

            If dt.Columns.Contains("InfrastructureName") Then
                txtBridgeName.Text = r("InfrastructureName").ToString()
            ElseIf dt.Columns.Contains("Name") Then
                txtBridgeName.Text = r("Name").ToString()
            End If

            If dt.Columns.Contains("InfrastructureLocation") Then txtBridgeLocation.Text = r("InfrastructureLocation").ToString()
            If dt.Columns.Contains("InfrastructureNameofRiver") Then txtBridgeNameofRiver.Text = r("InfrastructureNameofRiver").ToString()

            If dt.Columns.Contains("InfrastructureRouteNo") Then txtBridgeRouteNo.Text = r("InfrastructureRouteNo").ToString()
            If dt.Columns.Contains("InfrastructureReferencePost") Then txtBridgeReferencePost.Text = r("InfrastructureReferencePost").ToString()
            If dt.Columns.Contains("InfrastructureFeaturedIntersection") Then txtBridgeFeaturedIntersected.Text = r("InfrastructureFeaturedIntersection").ToString()
            If dt.Columns.Contains("InfrastructureEndReferencePost") Then txtBridgeEndReferencePost.Text = r("InfrastructureEndReferencePost").ToString()

            If dt.Columns.Contains("RoadOrBridgeType") Then txtBridgeType.Text = r("RoadOrBridgeType").ToString()
            If dt.Columns.Contains("InfrastructureMilePoint") Then txtBridgeMilePoint.Text = r("InfrastructureMilePoint").ToString()
            If dt.Columns.Contains("InfrastructureStartPosition") Then txtBridgeStartPosition.Text = r("InfrastructureStartPosition").ToString()
            If dt.Columns.Contains("InfrastructureCurrentPosition") Then txtBridgeCurrentStation.Text = r("InfrastructureCurrentPosition").ToString()

            If dt.Columns.Contains("InfrastructureBorderStructNo") Then txtBridgeBorderStructNo.Text = r("InfrastructureBorderStructNo").ToString()
            If dt.Columns.Contains("InfrastructureRoadNo") Then txtBridgeRoadNo.Text = r("InfrastructureRoadNo").ToString()
            If dt.Columns.Contains("InfrastructureRoutseSignPrefix") Then txtBridgeRouteSignPrefix.Text = r("InfrastructureRoutseSignPrefix").ToString()

            ' Left / Right
            If dt.Columns.Contains("LeftLfromAddress") Then txtBridgeLfromAddress.Text = r("LeftLfromAddress").ToString()
            If dt.Columns.Contains("LeftLtoAddress") Then txtBridgeLtoAddress.Text = r("LeftLtoAddress").ToString()
            If dt.Columns.Contains("LeftNWshldrWidth") Then txtBridgeNorthWestWidth.Text = r("LeftNWshldrWidth").ToString()
            If dt.Columns.Contains("RightRfromAddress") Then txtBridgeRfromAddress.Text = r("RightRfromAddress").ToString()
            If dt.Columns.Contains("RightRtoAddress") Then txtBridgeRtoAddress.Text = r("RightRtoAddress").ToString()
            If dt.Columns.Contains("RightSEshldrWidth") Then txtBridgeSouthEastWidth.Text = r("RightSEshldrWidth").ToString()

            ' Description / Remarks
            If dt.Columns.Contains("Description") Then txtDescription.Text = r("Description").ToString()
            If dt.Columns.Contains("Remarks") Then txtRemarks.Text = r("Remarks").ToString()

            ' Contractor
            If dt.Columns.Contains("Contractor") Then txtBridgeContractor.Text = r("Contractor").ToString()
            If dt.Columns.Contains("ContactPerson") Then txtBridgeContactPerson.Text = r("ContactPerson").ToString()
            If dt.Columns.Contains("ContactNo") Then txtBridgeCellphoneNo.Text = r("ContactNo").ToString()

            ' Acquisition / Depreciation
            If dt.Columns.Contains("AcquisitionDate") AndAlso Not String.IsNullOrEmpty(r("AcquisitionDate").ToString()) Then
                txtBridgeAcqDate.Text = Convert.ToDateTime(r("AcquisitionDate")).ToString("MM/dd/yyyy")
            ElseIf dt.Columns.Contains("dDate") AndAlso Not String.IsNullOrEmpty(r("dDate").ToString()) Then
                txtBridgeAcqDate.Text = Convert.ToDateTime(r("dDate")).ToString("MM/dd/yyyy")
            End If

            If dt.Columns.Contains("MarketValue") Then
                txtBridgeMarketValue.Text = FormatNumber(r("MarketValue"), 2)
            End If

            If dt.Columns.Contains("AcquisitionCost") Then
                txtBridgeAcqCost.Text = FormatNumber(r("AcquisitionCost"), 2)
            ElseIf dt.Columns.Contains("DebitCost") Then
                txtBridgeAcqCost.Text = FormatNumber(r("DebitCost"), 2)
            End If

            If dt.Columns.Contains("NoYears") Then txtBridgeNoYears.Text = r("NoYears").ToString()

            If dt.Columns.Contains("DepreciationRate") Then
                txtBridgeDepRate.Text = FormatNumber(r("DepreciationRate"), 2)
            End If

            If dt.Columns.Contains("UsefulLife") Then txtBridgeUsefulLife.Text = r("UsefulLife").ToString()

            If dt.Columns.Contains("DepreciationValue") Then
                txtDepreciationValue.Text = FormatNumber(r("DepreciationValue"), 2)
            End If

            If dt.Columns.Contains("SalvageValue") Then
                txtBridgeSalvageValue.Text = FormatNumber(r("SalvageValue"), 2)
            End If

            If dt.Columns.Contains("DepreciatedValue") Then
                txtBridgeDepValue.Text = FormatNumber(r("DepreciatedValue"), 2)
            End If
        End If

        If dt.Columns.Contains("useful_life") Then
            Session("useful_life") = r("useful_life").ToString()
        End If
    End Sub

    Private Sub ClearConstructionInformationForm()
        ' ROAD fields
        txtRoadProjectName.Text = ""
        txtRoadLocation.Text = ""
        txtRoadTrafficVolume.Text = ""
        txtRoadID.Text = ""
        txtRoadLength.Text = ""
        txtTrafficDate.Text = ""
        txtRoadName.Text = ""
        txtNoofLane.Text = ""
        txtRoadSpeedLimit.Text = ""
        txtRoadClassification.Text = ""
        txtRoadWidth.Text = ""
        txtRoadElevation.Text = ""
        txtRoadType.Text = ""
        txtRoadLaneLength.Text = ""
        txtRoadSurfaceType.Text = ""
        txtRoadFromStreet.Text = ""
        txtRoadLaneWidth.Text = ""
        txtRoadSurfaceCondition.Text = ""
        txtRoadtoStreet.Text = ""
        txtRoadTrafficDirection.Text = ""
        txtRemarksRoads.Text = ""
        txtDescriptionRoads.Text = ""
        txtRoadSegmentLock.Text = ""
        txtRoadLfromAddress.Text = ""
        txtRoadLtoAddress.Text = ""
        txtRoadNorthWestWidth.Text = ""
        txtRoadRfromAddress.Text = ""
        txtRoadRtoAddress.Text = ""
        txtRoadSouthEastWidth.Text = ""

        txtRoadAcqDate.Text = ""
        txtRoadMarketValue.Text = ""
        txtRoadAcqCost.Text = ""
        txtRoadNoYears.Text = ""
        txtRoadequipmentdepreciatedRate.Text = ""
        txtRoadUsefulLife.Text = ""
        txtRoadequipmentdepreciatedvalue.Text = ""
        txtRoadSalvageValue.Text = ""
        txtDepreciationRoad.Text = ""

        txtRoadContractor.Text = ""
        txtRoadContactPerson.Text = ""
        txtRoadCellphoneNo.Text = ""

        ' BRIDGE fields
        txtBridgeProjectName.Text = ""
        txtBridgeLocation.Text = ""
        txtBridgeNameofRiver.Text = ""
        txtBridgeID.Text = ""
        txtBridgeRouteNo.Text = ""
        txtBridgeReferencePost.Text = ""
        txtBridgeName.Text = ""
        txtBridgeFeaturedIntersected.Text = ""
        txtBridgeEndReferencePost.Text = ""
        txtBridgeType.Text = ""
        txtBridgeMilePoint.Text = ""
        txtBridgeStartPosition.Text = ""
        txtBridgeStructureNo.Text = ""
        txtBridgeBorderStructNo.Text = ""
        txtBridgeCurrentStation.Text = ""
        txtBridgeRouteSignPrefix.Text = ""
        txtBridgeRoadNo.Text = ""
        txtRemarks.Text = ""
        txtDescription.Text = ""

        txtBridgeLfromAddress.Text = ""
        txtBridgeLtoAddress.Text = ""
        txtBridgeNorthWestWidth.Text = ""
        txtBridgeRfromAddress.Text = ""
        txtBridgeRtoAddress.Text = ""
        txtBridgeSouthEastWidth.Text = ""

        txtBridgeAcqDate.Text = ""
        txtBridgeMarketValue.Text = ""
        txtBridgeAcqCost.Text = ""
        txtBridgeNoYears.Text = ""
        txtBridgeDepRate.Text = ""
        txtBridgeUsefulLife.Text = ""
        txtBridgeDepValue.Text = ""
        txtBridgeSalvageValue.Text = ""
        txtDepreciationValue.Text = ""

        txtBridgeContractor.Text = ""
        txtBridgeContactPerson.Text = ""
        txtBridgeCellphoneNo.Text = ""

        Session("useful_life") = Nothing
    End Sub

    'Loading of Unit
    Private Function GetSubClassificationName() As String
        Dim subClassId As String = If(Session("SubClassificationID"), "0")

        If String.IsNullOrEmpty(subClassId) OrElse subClassId = "0" Then
            Return String.Empty
        End If

        Dim dt As DataTable = Nothing

        Try
            Dim sql As String = "SELECT SubClassificationName FROM dbo.tbl_SubClassification WHERE SubClassificationID = '" & subClassId & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            AddTrace("Error loading SubClassificationName: " & ex.Message)
            Return String.Empty
        End Try

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Return dt.Rows(0)("SubClassificationName").ToString()
        End If

        Return String.Empty
    End Function


    Private Sub DecideSubClassView()
        ' get subclass name from DB based on Session("SubClassificationID")
        Dim name As String = GetSubClassificationName()
        Dim n As String = name.ToUpperInvariant()

        ' --- ROAD-style subclasses (vwRoad) ---
        Dim roadKeys As String() = {
        "ROAD", "ROAD AND DRAINAGE", "ROAD/SLOPE",
        "PAVEMENT",
        "WALKWAYS",
        "PARKING AREA",
        "DRAINAGE", "DRAINAGE/CULVERT", "BOX CULVERT",
        "RETAINING WALL",
        "SLOPE PROTECTION"
    }

        ' --- BRIDGE/BUILDING/UTILITY-style subclasses (vwBridge) ---
        Dim bridgeKeys As String() = {
        "BRIDGE",
        "BUILDING",
        "CARPENTRY SHOP",
        "SEWAGE TREATMENT",
        "SEPTIC TANK",
        "WATER SYSTEM",
        "FENCE", "FENCING", "FENCE AND RAILING",
        "FITNESS ROOM",
        "GUARD HOUSE",
        "ILLUMINATION",
        "POOL & BLEACHERS",
        "SCOUR PROTECTION"
    }

        ' Decide which view to show
        Dim isRoad As Boolean = Array.Exists(roadKeys, Function(k) n.Contains(k))
        Dim isBridge As Boolean = Array.Exists(bridgeKeys, Function(k) n.Contains(k))

        If isBridge Then
            mvSubClass.SetActiveView(Me.vwBridge)
        ElseIf isRoad Then
            mvSubClass.SetActiveView(Me.vwRoad)
        Else
            ' Default to road-style layout if nothing matched
            mvSubClass.SetActiveView(Me.vwRoad)
        End If
    End Sub




    ' ============================
    ' LEDGER GRIDVIEW
    ' ============================
    Private Sub BindConstructionLedgerGrid()
        Dim classificationId As String = If(Session("ClassificationID"), "0")

        Dim dt As DataTable = GetConstructionLedgerData(classificationId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            grdConstructionLedger.DataSource = dt
            grdConstructionLedger.DataBind()
        Else
            BindEmptyConstructionLedgerGrid()
        End If
    End Sub

    Private Function GetConstructionLedgerData(ByVal classificationId As String) As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "Exec [AMS].[PropertyCard_Rev_Ledger_v2] '" & Session("Item_ID") & "'"
            dt = objDerived.GetDataTable(sql, CommandType.Text)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error loading construction ledger: " & ex.Message)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Sub BindEmptyConstructionLedgerGrid()
        Dim dt As DataTable = CreateConstructionLedgerSchema()

        For i As Integer = 1 To 4
            dt.Rows.Add(dt.NewRow())
        Next

        grdConstructionLedger.DataSource = dt
        grdConstructionLedger.DataBind()
    End Sub

    Private Function CreateConstructionLedgerSchema() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("dDate", GetType(DateTime))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Decimal))
        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Decimal))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Decimal))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))
        Return dt
    End Function

    ' LEDGER EVENTS
    Protected Sub OnConstructionLedgerDataBound(sender As Object, e As EventArgs)
        ' reserved
    End Sub

    Protected Sub btnConstructionPreview_Click(sender As Object, e As EventArgs)
        ' reserved
    End Sub

End Class
