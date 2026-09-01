Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_PropertyCard_Rev
    Inherits System.Web.UI.Page

    Private objDerived As New DerivedDal
    Private objItems As New BaseClasses.Items

    Private Sub AddTrace(ByVal message As String)
        Dim safeMessage As String = message.Replace("'", "\'")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(),
        "TraceKey" & Guid.NewGuid().ToString("N"),
        "console.log('" & safeMessage & "');",
        True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then
            Session("SubClassificationID") = 0
            Session("GA_ID") = 0

            LoadClassification()
            LoadGeneralAccounts()
            LoadSubClassification()

            ' Default view
            UpdateActiveView()

        End If
    End Sub

    '========================
    ' DROPDOWN LOADERS
    '========================
    Private Sub LoadClassification()
        Dim sql As String =
        "SELECT a.ClassificationId, ClassificationName " &
        "FROM dbo.tbl_Classification as a " &
        "INNER JOIN dbo.tblclassmatrix as c on a.ClassificationId = c.classificationid " &
        "INNER JOIN geobos.[dbo].[view_allotmentclassaccounts] as b on c.ga_id = b.GA_ID " &
        "WHERE b.AllotmentClass_ID = 3 AND a.isenable = 1 " &
        "GROUP BY a.ClassificationId, ClassificationName, seqno " &
        "ORDER BY ClassificationName"

        Dim dt As DataTable = objDerived.GetDataTable(sql, CommandType.Text)

        drpClassification.DataSource = dt
        drpClassification.DataTextField = "ClassificationName"
        drpClassification.DataValueField = "ClassificationId"
        drpClassification.DataBind()

        Session("ClassificationID") = drpClassification.SelectedValue
    End Sub

    Private Sub LoadGeneralAccounts()
        If drpClassification.SelectedValue Is Nothing OrElse drpClassification.SelectedValue = "0" Then
            ddGlAccount.Items.Clear()
            ddGlAccount.Items.Insert(0, New ListItem("Select", "0"))
            Return
        End If

        ' Build SQL EXEC statement
        Dim sql As String = "EXEC dbo.sp_Accounts_Category_v1_02152022 " &
                    Session("AllotmentClassID") & ", " &
                    Session("ClassificationID") & ", " &
                    Session("SubClassificationID")

        ' Add trace to show EXACT execution line
        AddTrace("Executing SQL: " & sql)


        sql = "Exec dbo.sp_Accounts_Category_v1_02152022 '3','" &
            Session("ClassificationID") & "',' " & Session("SubClassificationID") & " '"

        Dim dt As DataTable = objDerived.GetDataTable(sql, CommandType.Text)

        ddGlAccount.DataSource = dt
        ddGlAccount.DataTextField = "GA_Title"
        ddGlAccount.DataValueField = "GA_ID"
        ddGlAccount.DataBind()

        ddGlAccount.Items.Insert(0, New ListItem("Select", "0"))
        ddGlAccount.SelectedIndex = 0
        Session("GA_ID") = 0

        UpdateActiveView()

    End Sub

    Private Sub LoadSubClassification()
        If drpClassification.SelectedValue Is Nothing OrElse drpClassification.SelectedValue = "0" Then
            drpSubClassification.Items.Clear()
            drpSubClassification.Items.Insert(0, New ListItem("Select", "0"))
            Return
        End If

        Dim sql As String =
            "SELECT SubClassificationID, SubClassificationName " &
            "FROM dbo.tbl_SubClassification " &
            "WHERE ClassificationID = " & drpClassification.SelectedValue & " " &
            "ORDER BY SubClassificationName;"

        Dim dt As DataTable = objItems.GetDataTable(sql, CommandType.Text)

        drpSubClassification.DataSource = dt
        drpSubClassification.DataTextField = "SubClassificationName"
        drpSubClassification.DataValueField = "SubClassificationID"
        drpSubClassification.DataBind()

        drpSubClassification.Items.Insert(0, New ListItem("Select", "0"))
        drpSubClassification.SelectedIndex = 0
        Session("SubClassificationID") = 0
    End Sub

    '========================
    ' EVENT HANDLERS
    '========================
    Protected Sub drpClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("ClassificationID") = drpClassification.SelectedValue
        AddTrace("ClassificationID: " & Session("ClassificationID"))
        Session("SubClassificationID") = 0
        Session("GA_ID") = 0

        LoadGeneralAccounts()
        LoadSubClassification()

        ' Update which view is active based on new ClassificationID
        UpdateActiveView()

        ' Refresh the ACTIVE user control grid (same pattern as other handlers)
        If mwProperty.GetActiveView() Is vwMachineryLocationList Then
            Dim machineryControl As Records_PropertyCard_Rev_Machinery =
            CType(vwMachineryLocationList.FindControl("MachineryLocationList1"), Records_PropertyCard_Rev_Machinery)
            If machineryControl IsNot Nothing Then
                machineryControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwBooksLocationList Then
            Dim booksControl As Records_PropertyCard_Rev_Books =
            CType(vwBooksLocationList.FindControl("BooksLocationList1"), Records_PropertyCard_Rev_Books)
            If booksControl IsNot Nothing Then
                booksControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwLandLocationList Then
            Dim landControl As Records_PropertyCard_Rev_Land =
            CType(vwLandLocationList.FindControl("LandLocationList1"), Records_PropertyCard_Rev_Land)
            If landControl IsNot Nothing Then
                landControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwBuildingLocationList Then
            Dim buildingControl As Records_PropertyCard_Rev_Building =
            CType(vwBuildingLocationList.FindControl("BuildingLocationList1"), Records_PropertyCard_Rev_Building)
            If buildingControl IsNot Nothing Then
                buildingControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwConstructionLocationList Then
            Dim constructionControl As Records_PropertyCard_Rev_Construction =
            CType(vwConstructionLocationList.FindControl("ConstructionLocationList1"), Records_PropertyCard_Rev_Construction)
            If constructionControl IsNot Nothing Then
                constructionControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwEquipmentLocationList Then
            Dim equipmentControl As Records_PropertyCard_Rev_Equipment =
            CType(vwEquipmentLocationList.FindControl("EquipmentLocationList1"), Records_PropertyCard_Rev_Equipment)
            If equipmentControl IsNot Nothing Then
                equipmentControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwFurnitureLocationList Then
            Dim furnitureControl As Records_PropertyCard_Rev_Furnitures =
            CType(vwFurnitureLocationList.FindControl("FurnitureLocationList1"), Records_PropertyCard_Rev_Furnitures)
            If furnitureControl IsNot Nothing Then
                furnitureControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwIntangibleLocationList Then
            Dim intangibleControl As Records_PropertyCard_Rev_Intangible =
            CType(vwIntangibleLocationList.FindControl("IntangibleLocationList1"), Records_PropertyCard_Rev_Intangible)
            If intangibleControl IsNot Nothing Then
                intangibleControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwOfficeEquipmentLocationList Then
            Dim officeEqControl As Records_PropertyCard_Rev_Office_Equipment =
            CType(vwOfficeEquipmentLocationList.FindControl("OfficeEquipmentLocationList1"), Records_PropertyCard_Rev_Office_Equipment)
            If officeEqControl IsNot Nothing Then
                officeEqControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwOthersLocationList Then
            Dim othersControl As Records_PropertyCard_Rev_Others =
            CType(vwOthersLocationList.FindControl("OthersLocationList1"), Records_PropertyCard_Rev_Others)
            If othersControl IsNot Nothing Then
                othersControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwVehicleLocationList Then
            Dim vehicleControl As Records_PropertyCard_Rev_Vehicle =
            CType(vwVehicleLocationList.FindControl("VehicleLocationList1"), Records_PropertyCard_Rev_Vehicle)
            If vehicleControl IsNot Nothing Then
                vehicleControl.RefreshGridData()
            End If
        End If
    End Sub


    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("GA_ID") = ddGlAccount.SelectedValue
        AddTrace("GA_ID: " & Session("GA_ID"))

        ' Refresh the active user control grid
        If mwProperty.GetActiveView() Is vwMachineryLocationList Then
            Dim machineryControl As Records_PropertyCard_Rev_Machinery =
        CType(vwMachineryLocationList.FindControl("MachineryLocationList1"), Records_PropertyCard_Rev_Machinery)
            If machineryControl IsNot Nothing Then
                machineryControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwBooksLocationList Then
            Dim booksControl As Records_PropertyCard_Rev_Books =
        CType(vwBooksLocationList.FindControl("BooksLocationList1"), Records_PropertyCard_Rev_Books)
            If booksControl IsNot Nothing Then
                booksControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwLandLocationList Then
            Dim landControl As Records_PropertyCard_Rev_Land =
        CType(vwLandLocationList.FindControl("LandLocationList1"), Records_PropertyCard_Rev_Land)
            If landControl IsNot Nothing Then
                landControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwBuildingLocationList Then
            Dim buildingControl As Records_PropertyCard_Rev_Building =
        CType(vwBuildingLocationList.FindControl("BuildingLocationList1"), Records_PropertyCard_Rev_Building)
            If buildingControl IsNot Nothing Then
                buildingControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwConstructionLocationList Then
            Dim constructionControl As Records_PropertyCard_Rev_Construction =
        CType(vwConstructionLocationList.FindControl("ConstructionLocationList1"), Records_PropertyCard_Rev_Construction)
            If constructionControl IsNot Nothing Then
                constructionControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwEquipmentLocationList Then
            Dim equipmentControl As Records_PropertyCard_Rev_Equipment =
        CType(vwEquipmentLocationList.FindControl("EquipmentLocationList1"), Records_PropertyCard_Rev_Equipment)
            If equipmentControl IsNot Nothing Then
                equipmentControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwFurnitureLocationList Then
            Dim furnitureControl As Records_PropertyCard_Rev_Furnitures =
        CType(vwFurnitureLocationList.FindControl("FurnitureLocationList1"), Records_PropertyCard_Rev_Furnitures)
            If furnitureControl IsNot Nothing Then
                furnitureControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwIntangibleLocationList Then
            Dim intangibleControl As Records_PropertyCard_Rev_Intangible =
        CType(vwIntangibleLocationList.FindControl("IntangibleLocationList1"), Records_PropertyCard_Rev_Intangible)
            If intangibleControl IsNot Nothing Then
                intangibleControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwOfficeEquipmentLocationList Then
            Dim officeEqControl As Records_PropertyCard_Rev_Office_Equipment =
        CType(vwOfficeEquipmentLocationList.FindControl("OfficeEquipmentLocationList1"), Records_PropertyCard_Rev_Office_Equipment)
            If officeEqControl IsNot Nothing Then
                officeEqControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwOthersLocationList Then
            Dim othersControl As Records_PropertyCard_Rev_Others =
        CType(vwOthersLocationList.FindControl("OthersLocationList1"), Records_PropertyCard_Rev_Others)
            If othersControl IsNot Nothing Then
                othersControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwVehicleLocationList Then
            Dim vehicleControl As Records_PropertyCard_Rev_Vehicle =
        CType(vwVehicleLocationList.FindControl("VehicleLocationList1"), Records_PropertyCard_Rev_Vehicle)
            If vehicleControl IsNot Nothing Then
                vehicleControl.RefreshGridData()
            End If
        End If

        UpdateActiveView()
    End Sub


    Protected Sub drpSubClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("SubClassificationID") = drpSubClassification.SelectedValue
        AddTrace("SubClassificationID: " & Session("SubClassificationID"))

        ' Refresh the active user control grid
        If mwProperty.GetActiveView() Is vwMachineryLocationList Then
            Dim machineryControl As Records_PropertyCard_Rev_Machinery =
        CType(vwMachineryLocationList.FindControl("MachineryLocationList1"), Records_PropertyCard_Rev_Machinery)
            If machineryControl IsNot Nothing Then
                machineryControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwBooksLocationList Then
            Dim booksControl As Records_PropertyCard_Rev_Books =
        CType(vwBooksLocationList.FindControl("BooksLocationList1"), Records_PropertyCard_Rev_Books)
            If booksControl IsNot Nothing Then
                booksControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwLandLocationList Then
            Dim landControl As Records_PropertyCard_Rev_Land =
        CType(vwLandLocationList.FindControl("LandLocationList1"), Records_PropertyCard_Rev_Land)
            If landControl IsNot Nothing Then
                landControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwBuildingLocationList Then
            Dim buildingControl As Records_PropertyCard_Rev_Building =
        CType(vwBuildingLocationList.FindControl("BuildingLocationList1"), Records_PropertyCard_Rev_Building)
            If buildingControl IsNot Nothing Then
                buildingControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwConstructionLocationList Then
            Dim constructionControl As Records_PropertyCard_Rev_Construction =
        CType(vwConstructionLocationList.FindControl("ConstructionLocationList1"), Records_PropertyCard_Rev_Construction)
            If constructionControl IsNot Nothing Then
                constructionControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwEquipmentLocationList Then
            Dim equipmentControl As Records_PropertyCard_Rev_Equipment =
        CType(vwEquipmentLocationList.FindControl("EquipmentLocationList1"), Records_PropertyCard_Rev_Equipment)
            If equipmentControl IsNot Nothing Then
                equipmentControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwFurnitureLocationList Then
            Dim furnitureControl As Records_PropertyCard_Rev_Furnitures =
        CType(vwFurnitureLocationList.FindControl("FurnitureLocationList1"), Records_PropertyCard_Rev_Furnitures)
            If furnitureControl IsNot Nothing Then
                furnitureControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwIntangibleLocationList Then
            Dim intangibleControl As Records_PropertyCard_Rev_Intangible =
        CType(vwIntangibleLocationList.FindControl("IntangibleLocationList1"), Records_PropertyCard_Rev_Intangible)
            If intangibleControl IsNot Nothing Then
                intangibleControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwOfficeEquipmentLocationList Then
            Dim officeEqControl As Records_PropertyCard_Rev_Office_Equipment =
        CType(vwOfficeEquipmentLocationList.FindControl("OfficeEquipmentLocationList1"), Records_PropertyCard_Rev_Office_Equipment)
            If officeEqControl IsNot Nothing Then
                officeEqControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwOthersLocationList Then
            Dim othersControl As Records_PropertyCard_Rev_Others =
        CType(vwOthersLocationList.FindControl("OthersLocationList1"), Records_PropertyCard_Rev_Others)
            If othersControl IsNot Nothing Then
                othersControl.RefreshGridData()
            End If

        ElseIf mwProperty.GetActiveView() Is vwVehicleLocationList Then
            Dim vehicleControl As Records_PropertyCard_Rev_Vehicle =
        CType(vwVehicleLocationList.FindControl("VehicleLocationList1"), Records_PropertyCard_Rev_Vehicle)
            If vehicleControl IsNot Nothing Then
                vehicleControl.RefreshGridData()
            End If
        End If

        LoadGeneralAccounts()
    End Sub




    Protected Sub ItemSearch_Click(sender As Object, e As EventArgs)
        ' No real search yet, just keep UI working and grids visible.
        UpdateActiveView()


    End Sub



    '========================
    ' MULTIVIEW LOGIC
    '========================
    Private Sub UpdateActiveView()
        Dim classificationText As String = String.Empty

        If drpClassification.SelectedItem IsNot Nothing Then
            classificationText = drpClassification.SelectedItem.Text.ToLower().Trim()
        End If

        If classificationText.Contains("book") Then
            mwProperty.SetActiveView(vwBooksLocationList)

        ElseIf classificationText.Contains("land") Then
            mwProperty.SetActiveView(vwLandLocationList)

        ElseIf classificationText.Contains("building") Then
            mwProperty.SetActiveView(vwBuildingLocationList)

        ElseIf classificationText.Contains("construction") Then
            mwProperty.SetActiveView(vwConstructionLocationList)

        ElseIf classificationText.Contains("equipment") AndAlso Not classificationText.Contains("office") Then
            ' General equipment (non-office)
            mwProperty.SetActiveView(vwEquipmentLocationList)

        ElseIf classificationText.Contains("furniture") OrElse classificationText.Contains("fixture") Then
            mwProperty.SetActiveView(vwFurnitureLocationList)

        ElseIf classificationText.Contains("intangible") Then
            mwProperty.SetActiveView(vwIntangibleLocationList)

        ElseIf classificationText.Contains("machinery") OrElse classificationText.Contains("machine") Then
            mwProperty.SetActiveView(vwMachineryLocationList)

        ElseIf classificationText.Contains("office") Then
            ' Office equipment classification
            mwProperty.SetActiveView(vwOfficeEquipmentLocationList)

        ElseIf classificationText.Contains("other") Then
            mwProperty.SetActiveView(vwOthersLocationList)

        ElseIf classificationText.Contains("vehicle") OrElse classificationText.Contains("motor") Then
            mwProperty.SetActiveView(vwVehicleLocationList)

        Else
            ' Fallback
            mwProperty.SetActiveView(vwLandLocationList)
        End If
    End Sub




    'Preview button
    Protected Sub btnPreview_Click(sender As Object, e As EventArgs)
        Session("ClassificationID") = drpClassification.SelectedValue

        Dim url As String = ResolveUrl("~/Records/rpt_propertycard.aspx")
        Dim script As String = "window.open('" & url & "', '_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "OpenPropertyCard", script, True)
    End Sub


End Class
