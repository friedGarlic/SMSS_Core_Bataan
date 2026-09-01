Imports System.Data
Imports System.Web.UI.WebControls

Partial Class Records_t_StockCard_Rev_Main
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

            UpdateActiveView()
        End If
    End Sub

    Private Sub LoadClassification()
        Dim sql As String =
            "Select * from dbo.tbl_Classification where AllotmentClass_id = 2 order by seqno "

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

        Dim sql As String = "Exec dbo.sp_Accounts_Category_v1_02152022 '2','" &
            Session("ClassificationID") & "',' " & Session("SubClassificationID") & " '"

        AddTrace("Executing SQL: " & sql)

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

    Protected Sub drpClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("ClassificationID") = drpClassification.SelectedValue
        AddTrace("ClassificationID: " & Session("ClassificationID"))

        Session("SubClassificationID") = 0
        Session("GA_ID") = 0

        LoadGeneralAccounts()
        LoadSubClassification()

        UpdateActiveView()
    End Sub

    Protected Sub ddGlAccount_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("GA_ID") = ddGlAccount.SelectedValue
        AddTrace("GA_ID: " & Session("GA_ID"))

        UpdateActiveView()
    End Sub

    Protected Sub drpSubClassification_SelectedIndexChanged(sender As Object, e As EventArgs)
        Session("SubClassificationID") = drpSubClassification.SelectedValue
        AddTrace("SubClassificationID: " & Session("SubClassificationID"))

        LoadGeneralAccounts()
        UpdateActiveView()
    End Sub

    Private Sub UpdateActiveView()
        Dim classificationText As String = String.Empty

        If drpClassification.SelectedItem IsNot Nothing Then
            classificationText = drpClassification.SelectedItem.Text.ToLower().Trim()
        End If

        ' --- MRO: specific buckets first ---
        If classificationText.Contains("mro consumables") Then
            mwStockCard.SetActiveView(vwMROConsumables)

            Dim ctrl As Records_t_StockCard_Rev_Main_MRO_Consumables =
            CType(vwMROConsumables.FindControl("MROConsumablesStockCard1"), Records_t_StockCard_Rev_Main_MRO_Consumables)
            ' Only call refresh if your UC implements it
            If ctrl IsNot Nothing Then
                ctrl.RefreshGridData()
            End If

        ElseIf classificationText.Contains("mro equipment") Then
            mwStockCard.SetActiveView(vwMROEquipment)

            Dim ctrl As Records_t_StockCard_Rev_Main_MRO_Equipment =
            CType(vwMROEquipment.FindControl("MROEquipmentStockCard1"), Records_t_StockCard_Rev_Main_MRO_Equipment)
            If ctrl IsNot Nothing Then
                ctrl.RefreshGridData()
            End If

        ElseIf classificationText.Contains("mro supplies") Then
            mwStockCard.SetActiveView(vwMROSupplies)

            Dim ctrl As Records_t_StockCard_Rev_Main_MRO_Supplies =
            CType(vwMROSupplies.FindControl("MROStockCard1"), Records_t_StockCard_Rev_Main_MRO_Supplies)
            If ctrl IsNot Nothing Then
                ctrl.RefreshGridData()
            End If

            ' --- Non-MRO buckets ---
        ElseIf classificationText.Contains("medicine") Then
            mwStockCard.SetActiveView(vwMedicine)

            Dim ctrl As Records_t_StockCard_Rev_Main_Medicine =
            CType(vwMedicine.FindControl("MedicineStockCard1"), Records_t_StockCard_Rev_Main_Medicine)
            'If ctrl IsNot Nothing Then ctrl.RefreshGridData()
            If ctrl IsNot Nothing Then
                ctrl.RefreshGridData()
            End If

        ElseIf classificationText.Contains("food") Then
            mwStockCard.SetActiveView(vwFood)

            Dim ctrl As Records_t_StockCard_Rev_Main_Food =
            CType(vwFood.FindControl("FoodStockCard1"), Records_t_StockCard_Rev_Main_Food)
            If ctrl IsNot Nothing Then
                ctrl.RefreshGridData()
            End If

            ' --- Generic supplies fallback ---
        ElseIf classificationText.Contains("supplies") Then
            mwStockCard.SetActiveView(vwSupplies)

            Dim ctrl As Records_t_StockCard_Rev_Main_Supplies =
            CType(vwSupplies.FindControl("SuppliesStockCard1"), Records_t_StockCard_Rev_Main_Supplies)
            If ctrl IsNot Nothing Then
                ctrl.RefreshGridData()
            End If

        Else
            mwStockCard.SetActiveView(vwEmpty)
        End If
    End Sub



    Protected Sub btnPreview_Click(sender As Object, e As EventArgs)
        ' First, find the active user control to access its selected item
        Dim activeView As View = CType(mwStockCard.GetActiveView(), View)

        If activeView Is Nothing Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('No active view found.');", True)
            Exit Sub
        End If

        Dim itemId As Object = Nothing
        Dim grdStockList As GridView = Nothing

        ' Determine which user control is active and get its GridView
        If activeView.ID = "vwMROSupplies" Then
            Dim ctrl As Records_t_StockCard_Rev_Main_MRO_Supplies = CType(vwMROSupplies.FindControl("MROStockCard1"), Records_t_StockCard_Rev_Main_MRO_Supplies)
            If ctrl IsNot Nothing Then
                grdStockList = CType(ctrl.FindControl("grdMROStockList"), GridView)
            End If

        ElseIf activeView.ID = "vwMROConsumables" Then
            Dim ctrl As Records_t_StockCard_Rev_Main_MRO_Consumables = CType(vwMROConsumables.FindControl("MROConsumablesStockCard1"), Records_t_StockCard_Rev_Main_MRO_Consumables)
            If ctrl IsNot Nothing Then
                grdStockList = CType(ctrl.FindControl("grdMROConsumablesStockList"), GridView)
            End If

        ElseIf activeView.ID = "vwMROEquipment" Then
            Dim ctrl As Records_t_StockCard_Rev_Main_MRO_Equipment = CType(vwMROEquipment.FindControl("MROEquipmentStockCard1"), Records_t_StockCard_Rev_Main_MRO_Equipment)
            If ctrl IsNot Nothing Then
                grdStockList = CType(ctrl.FindControl("grdMROEquipmentStockList"), GridView)
            End If

        ElseIf activeView.ID = "vwMedicine" Then
            Dim ctrl As Records_t_StockCard_Rev_Main_Medicine = CType(vwMedicine.FindControl("MedicineStockCard1"), Records_t_StockCard_Rev_Main_Medicine)
            If ctrl IsNot Nothing Then
                grdStockList = CType(ctrl.FindControl("grdMedicineStockList"), GridView)
            End If

        ElseIf activeView.ID = "vwFood" Then
            Dim ctrl As Records_t_StockCard_Rev_Main_Food = CType(vwFood.FindControl("FoodStockCard1"), Records_t_StockCard_Rev_Main_Food)
            If ctrl IsNot Nothing Then
                grdStockList = CType(ctrl.FindControl("grdFoodStockList"), GridView)
            End If

        ElseIf activeView.ID = "vwSupplies" Then
            Dim ctrl As Records_t_StockCard_Rev_Main_Supplies = CType(vwSupplies.FindControl("SuppliesStockCard1"), Records_t_StockCard_Rev_Main_Supplies)
            If ctrl IsNot Nothing Then
                grdStockList = CType(ctrl.FindControl("grdStockList"), GridView)
            End If
        End If

        ' Check if we have a selected item in the grid
        If grdStockList IsNot Nothing AndAlso grdStockList.SelectedDataKey IsNot Nothing Then
            ' Get the Item_ID from the selected data key
            If grdStockList.SelectedDataKey.Values("Item_ID") IsNot Nothing Then
                itemId = grdStockList.SelectedDataKey.Values("Item_ID")

                ' Store in session
                Session("Item_ID") = itemId

                AddTrace("Setting Session('Item_ID') = " & itemId.ToString())

                ' Open the report in a new tab
                Dim script As String = "window.open('../MainReports/rpt_StockCard_Rev.aspx', '_blank');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenReport", script, True)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Item_ID not found in selected row.');", True)
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Please select an item from the list first.');", True)
        End If
    End Sub

End Class
