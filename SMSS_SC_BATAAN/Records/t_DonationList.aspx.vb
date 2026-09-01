
Imports System
Imports System.Data

Partial Class Records_t_DonationList
    Inherits System.Web.UI.Page
    Dim objDerived As New DerivedDal
    Dim image As New Image
    Dim obj As New BaseClasses.Items

    Private Property dtDonation() As DataTable
        Get
            Return CType(Session("dtDonation"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDonation") = value
        End Set
    End Property

    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LoadPage()
            Me.mvDonation.SetActiveView(Me.vwDonationToLGU)
            btnDTL.CssClass = "Clicked"
            btnLTL.CssClass = "Initial"
        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")

    End Sub

    Protected Sub LoadPage()
        'dtDonation = objDerived.GetDataTable("SELECT * FROM [dbo].[view_Donation_Records] ORDER BY ReferenceNo DESC, Item_Desc, PropertyNo", CommandType.Text)

        'dtDonation = objDerived.GetDataTable("SELECT A.ReferenceNo, C.PropertyNo, D.Item_Desc, D.UnitDesc, B.Cost, CASE WHEN C.Status = 'Accepted' THEN ' - ' ELSE C.Status END AS Prop_Status  " &
        '                                  "      , A.DonatedBy, CASE WHEN A.from_private = 1 THEN 'Private' ELSE 'Government' END AS Donation_Type                                              " &
        '                                  "      , D.GA_ID, D.BGA_ID, C.PropertyDetai_ID, B.Item_ID, B.Property_ID, CONVERT(BIT, 1) AS isVisible                                                                                       " &
        '                                  "  FROM AMS.TbDonation_Hdr AS A                                                                                                                       " &
        '                                  "  INNER JOIN AMS.Property AS B ON A.Property_ID = B.Property_ID                                                                                      " &
        '                                  "  INNER JOIN AMS.Property_Dtl AS C ON B.Property_ID = C.Property_ID                                                                                  " &
        '                                  "  INNER JOIN AMS.View_ItemList AS D ON B.Item_ID = D.Item_ID                                                                                         " &
        '                                  "  ORDER BY A.ReferenceNo DESC, C.PropertyNo, D.Item_Desc", CommandType.Text)

        'dtDonation = objDerived.GetDataTable("SELECT A.ReferenceNo, C.PropertyNo, D.Item_Desc, D.UnitDesc, B.Cost, CASE WHEN C.Status = 'Accepted' THEN ' - ' ELSE C.Status END AS Prop_Status, A.DonatedBy, " &
        '                    " CASE WHEN A.from_private = 1 THEN 'Private' ELSE 'Government' END AS Donation_Type, D.GA_ID, D.BGA_ID, C.PropertyDetai_ID, B.Item_ID, B.Property_ID, CONVERT(BIT, 1) AS isVisible, AMS.TbDonations.DonorName,  " &
        '                    " AMS.TbDonations.Address " &
        '                    " FROM AMS.TbDonation_Hdr AS A INNER JOIN " &
        '                    " AMS.Property AS B ON A.Property_ID = B.Property_ID INNER JOIN " &
        '                    " AMS.Property_Dtl AS C ON B.Property_ID = C.Property_ID INNER JOIN " &
        '                    " AMS.View_ItemList AS D ON B.Item_ID = D.Item_ID INNER JOIN " &
        '                    " AMS.TbDonations ON C.PropertyDetai_ID = AMS.TbDonations.Property_Dtl_ID " &
        '                    " ORDER BY A.ReferenceNo DESC, C.PropertyNo, D.Item_Desc", CommandType.Text)

        dtDonation = objDerived.GetDataTable("SELECT A.ReferenceNo, C.PropertyNo, D.Item_Desc, D.UnitDesc, B.Cost,  C.Status AS Prop_Status, A.DonatedBy, " &
                            " CASE WHEN A.from_private = 1 THEN 'Private' ELSE 'Government' END AS Donation_Type, D.GA_ID, D.BGA_ID, C.PropertyDetai_ID, B.Item_ID, B.Property_ID, CONVERT(BIT, 1) AS isVisible, AMS.TbDonations.DonorName,  " &
                            " AMS.TbDonations.Address " &
                            " FROM AMS.TbDonation_Hdr AS A INNER JOIN " &
                            " AMS.Property AS B ON A.Property_ID = B.Property_ID INNER JOIN " &
                            " AMS.Property_Dtl AS C ON B.Property_ID = C.Property_ID INNER JOIN " &
                            " AMS.View_ItemList AS D ON B.Item_ID = D.Item_ID INNER JOIN " &
                            " AMS.TbDonations ON C.PropertyDetai_ID = AMS.TbDonations.Property_Dtl_ID " &
                            " ORDER BY A.ReferenceNo DESC, C.PropertyNo, D.Item_Desc", CommandType.Text)


        If dtDonation.Rows.Count < 8 Then
            dtDonation.Merge(createdatatable1(7 - dtDonation.Rows.Count))
        End If
        grdDonationDtl.DataSource = dtDonation
        grdDonationDtl.DataBind()

        grdLedger.DataSource = dtTemp_Ledger(4)
        grdLedger.DataBind()


    End Sub
    Protected Sub LoadPage_LGU_TO_LGU()
        'dtDonation = objDerived.GetDataTable("SELECT * FROM [dbo].[view_Donation_Records] ORDER BY ReferenceNo DESC, Item_Desc, PropertyNo", CommandType.Text)

        Dim dtLGU As New DataTable
        'dtLGU = objDerived.GetDataTable("SELECT AMS.TbDonationLGUtoLGU.DonationLGUtoLGU_ID, CONVERT(varchar, AMS.TbDonationLGUtoLGU.Date_Issued, 101) AS Date_Issued, AMS.TbDonationLGUtoLGU.LGU_Department, AMS.TbDonationLGUtoLGU.Remarks, " &
        '                " AMS.TbDonationLGUtoLGU.Item_Description, AMS.m_Unit.Description, 1 AS Qty,  FORMAT(SUM(AMS.TbDonationLGUtoLGU_Dtl.Cost), 'n2') AS Cost " &
        '                "  FROM dbo.m_item INNER JOIN " &
        '                "  AMS.m_Unit ON dbo.m_item.Unit_ID = AMS.m_Unit.Unit_ID INNER JOIN " &
        '                "  AMS.TbDonationLGUtoLGU ON dbo.m_item.Item_ID = AMS.TbDonationLGUtoLGU.Item_ID INNER JOIN " &
        '                "  AMS.TbDonationLGUtoLGU_Dtl ON AMS.TbDonationLGUtoLGU.DonationLGUtoLGU_ID = AMS.TbDonationLGUtoLGU_Dtl.DonationLGUtoLGU_ID " &
        '                "  GROUP BY AMS.TbDonationLGUtoLGU.DonationLGUtoLGU_ID, AMS.TbDonationLGUtoLGU.Date_Issued, AMS.TbDonationLGUtoLGU.LGU_Department, AMS.TbDonationLGUtoLGU.Remarks, AMS.TbDonationLGUtoLGU.Item_Description, " &
        '                "  AMS.m_Unit.Description, AMS.TbDonationLGUtoLGU_Dtl.Cost", CommandType.Text)



        dtLGU = objDerived.GetDataTable("SELECT D.DonationLGUtoLGU_ID, " &
                                              " CONVERT(varchar, D.Date_Issued, 101) AS Date_Issued, " &
                                              " D.LGU_Department, " &
                                              " D.Remarks, " &
                                              " D.Item_Description, " &
                                              " U.Description AS Unit_Desc, " &
                                              " 1 AS Qty, " &
                                              " FORMAT(SUM(DD.Cost), 'n2') AS Cost " &
                                        " FROM   AMS.TbDonationLGUtoLGU AS D " &
                                              " INNER JOIN AMS.TbDonationLGUtoLGU_Dtl AS DD " &
                                              " ON D.DonationLGUtoLGU_ID = DD.DonationLGUtoLGU_ID " &
                                              " INNER JOIN dbo.m_item AS I " &
                                              " ON D.Item_ID = I.Item_ID " &
                                              " INNER JOIN AMS.m_Unit AS U " &
                                              " ON I.Unit_ID = U.Unit_ID  " &
                                       " GROUP BY D.DonationLGUtoLGU_ID, " &
                                                " D.Date_Issued, " &
                                                " D.LGU_Department, " &
                                                " D.Remarks, " &
                                                " D.Item_Description, " &
                                                " U.Description", CommandType.Text)




        If dtLGU.Rows.Count < 8 Then
            dtLGU.Merge(createdatatableLGU(7 - dtLGU.Rows.Count))
        End If
        grLGUToLGU.DataSource = dtLGU
        grLGUToLGU.DataBind()




    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtDonation.DefaultView

        If ddSearch.SelectedItem.Value = 1 Then
            myview.RowFilter = "ReferenceNo LIKE '%" & replaceapostrophe(txtSearch.Text) & "%'"

        ElseIf ddSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "PropertyNo LIKE '%" & replaceapostrophe(txtSearch.Text) & "%'"

        ElseIf ddSearch.SelectedItem.Value = 3 Then
            myview.RowFilter = "Item_Desc LIKE '%" & replaceapostrophe(txtSearch.Text) & "%'"

        ElseIf ddSearch.SelectedItem.Value = 4 Then
            myview.RowFilter = "DonorName LIKE '%" & replaceapostrophe(txtSearch.Text) & "%'"

        End If

        grdDonationDtl.DataSource = myview
        grdDonationDtl.DataBind()

    End Sub
    Private Sub grdDonationDtl_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDonationDtl.PageIndexChanging
        grdDonationDtl.DataSource = dtDonation
        grdDonationDtl.PageIndex = e.NewPageIndex
        grdDonationDtl.DataBind()
    End Sub

    Private Sub grdDonationDtl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDonationDtl.SelectedIndexChanged
        'Try

        '    Session("PropertyDetai_ID") = grdDonationDtl.SelectedDataKey("PropertyDetai_ID")
        '    Session("Item_ID") = grdDonationDtl.SelectedDataKey("Item_ID")

        '    LoadPPE_Details()
        '    LoadDisable_PPEDetails()


        '    If grdDonationDtl.SelectedDataKey("GA_ID") = 1166 Then
        '        '1-07-06-010 Motor Vehicles
        '        mvPPE_Details.SetActiveView(Me.vwMotorVechicle)

        '    ElseIf grdDonationDtl.SelectedDataKey("GA_ID") = 1127 Or grdDonationDtl.SelectedDataKey("GA_ID") = 1160 Then
        '        '1-07-05-010 Machinery
        '        '1-07-05-990 Other Machinery and Equipment
        '        mvPPE_Details.SetActiveView(Me.vwMachinery)

        '    Else
        '        mvPPE_Details.Dispose()
        '    End If

        '    btnEdit_PPEDetails.Enabled = True
        '    btnSave_PPEDetails.Enabled = False


        '    loadDonationLedger()



        'Catch ex As Exception
        '    'MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        '    MsgBox(ex.Message)
        'End Try

        Dim a As String = grdDonationDtl.SelectedDataKey("Item_ID")
        Session("Item_ID") = grdDonationDtl.SelectedDataKey("Item_ID")
        Session("Donation_to_LGU") = "Donation to LGU"

        'If Session("PropertyDetai_ID") = 0 Then
        '    MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Please select from the list of item to preview Property Card Report.")
        'Else
        Me.Page.Response.Redirect("~/Records/rpt_propertycard.aspx")
        'End If

    End Sub

    Protected Sub LoadPPE_Details()

        'Dim dt As New DataTable
        'dt = objDerived.GetDataTable("SELECT A.Property_Date, A.Cost, B.PropertyNo, C.Item_Desc, ISNULL(D.SerialNo, B.SerialNo) AS SerialNo, ISNULL(D.BrandName,'') AS BrandName, ISNULL(D.Model,'') AS Model                       " &
        '              "  , ISNULL(D.Warranty,'') AS Warranty, ISNULL(D.Depreciation_Rate,'0.00') AS Depreciation_Rate, ISNULL(D.Salvage_Value,'0.00') AS Salvage_Value                              " &
        '              "  , ISNULL(D.eq_Powerinput,'') AS eq_Powerinput, ISNULL(D.Specifications,'') AS Specifications, ISNULL(D.mv_PlateNo,B.SerialNo) AS mv_PlateNo                                " &
        '              "  , ISNULL(D.mv_ChasisNo,'') AS mv_ChasisNo, ISNULL(D.mv_EngineNo,'') AS mv_EngineNo, ISNULL(D.mv_MVFileNo,'') AS mv_MVFileNo                                                " &
        '              "  , ISNULL(D.mv_ConductionSticker,'') AS mv_ConductionSticker, ISNULL(D.mv_RegistrationDate,A.Property_Date) AS mv_RegistrationDate, ISNULL(D.mv_Color,'') AS mv_Color       " &
        '              "  , ISNULL(D.ma_EnginNo,'') AS ma_EnginNo, ISNULL(D.ma_PermitNo,'') AS ma_PermitNo, ISNULL(D.ma_WorkingLoad,'') AS ma_WorkingLoad                         " &
        '              "  , ISNULL(D.ma_ServiceFloor,'') AS ma_ServiceFloor, ISNULL(D.ma_Location,'') AS ma_Location, ISNULL(D.ma_Dimension,'') AS ma_Dimension                   " &
        '              "  FROM AMS.Property AS A INNER Join AMS.Property_Dtl AS B ON A.Property_ID = B.Property_ID INNER Join AMS.View_ItemList AS C ON A.Item_ID = C.Item_ID     " &
        '              "  LEFT OUTER JOIN AMS.tbl_PPE_Details AS D ON B.PropertyDetai_ID = D.PropertyDetai_ID                                                                     " &
        '              "  WHERE B.PropertyDetai_ID = '" & Session("PropertyDetai_ID") & "'", CommandType.Text)

        'txtPPE_BrandName.Text = dt.Rows(0)("BrandName")
        'txtPPE_Model.Text = dt.Rows(0)("Model")
        'txtPPE_SerialNo.Text = dt.Rows(0)("SerialNo")
        'txtPPE_Powerinput.Text = dt.Rows(0)("eq_Powerinput")
        'txtPPE_Warranty.Text = dt.Rows(0)("Warranty")
        'txtPPE_SalvageValue.Text = dt.Rows(0)("Salvage_Value")
        'txtPPE_DepRate.Text = dt.Rows(0)("Depreciation_Rate")
        'txtPPE_DepValue.Text = "0.00"

        'txtPPE_Specifications.Text = dt.Rows(0)("Specifications")

        'txtMA_EngineNo.Text = dt.Rows(0)("ma_EnginNo")
        'txtMA_PermitNo.Text = dt.Rows(0)("ma_PermitNo")
        'txtMA_WorkingLoad.Text = dt.Rows(0)("ma_WorkingLoad")
        'txtMA_ServiceFloor.Text = dt.Rows(0)("ma_ServiceFloor")
        'txtMA_Dimension.Text = dt.Rows(0)("ma_Dimension")
        'txtMA_Location.Text = dt.Rows(0)("ma_Location")

        'txtMV_PlateNo.Text = dt.Rows(0)("mv_PlateNo")
        'txtMV_ChasisNo.Text = dt.Rows(0)("mv_ChasisNo")
        'txtMV_EngineNo.Text = dt.Rows(0)("mv_EngineNo")
        'txtMV_FileNo.Text = dt.Rows(0)("mv_MVFileNo")
        'txtMV_ConductionSticker.Text = dt.Rows(0)("mv_ConductionSticker")
        'txtMV_RegistrationDate.Text = dt.Rows(0)("mv_RegistrationDate")
        'txtMV_Color.Text = dt.Rows(0)("mv_Color")


        'Dim dtDonations_Info As New DataTable
        'dtDonations_Info = objDerived.GetDataTable("SELECT DonatedBy , CASE WHEN from_private = 1 THEN 'Private' ELSE 'Government' END AS Donation_Type FROM AMS.TbDonation_Hdr WHERE Property_ID = '" & grdDonationDtl.SelectedDataKey("Property_ID") & "'", CommandType.Text)

        'txtDonationType.Text = dtDonations_Info.Rows(0)("Donation_Type")
        'txtDonatedBy.Text = dtDonations_Info.Rows(0)("DonatedBy")

    End Sub

    Private Sub btnEdit_PPEDetails_Click(sender As Object, e As EventArgs) Handles btnEdit_PPEDetails.Click
        txtPPE_BrandName.Enabled = True
        txtPPE_Model.Enabled = True
        txtPPE_SerialNo.Enabled = True
        txtPPE_Powerinput.Enabled = True
        txtPPE_Warranty.Enabled = True
        txtPPE_SalvageValue.Enabled = True
        txtPPE_DepRate.Enabled = True
        txtPPE_DepValue.Enabled = True

        txtPPE_Specifications.Enabled = True

        txtMA_EngineNo.Enabled = True
        txtMA_PermitNo.Enabled = True
        txtMA_WorkingLoad.Enabled = True
        txtMA_ServiceFloor.Enabled = True
        txtMA_Dimension.Enabled = True
        txtMA_Location.Enabled = True

        txtMV_PlateNo.Enabled = True
        txtMV_ChasisNo.Enabled = True
        txtMV_EngineNo.Enabled = True
        txtMV_FileNo.Enabled = True
        txtMV_ConductionSticker.Enabled = True
        txtMV_RegistrationDate.Enabled = True
        txtMV_Color.Enabled = True

        btnSave_PPEDetails.Enabled = True
    End Sub

    Private Sub btnSave_PPEDetails_Click(sender As Object, e As EventArgs) Handles btnSave_PPEDetails.Click
        Try


            Dim ID As Integer = objDerived.GetValue("SELECT [ppe_details_id] FROM [AMS].[tbl_PPE_Details] WHERE PropertyDetai_ID = '" & Session("PropertyDetai_ID") & "'", CommandType.Text)
            If ID = 0 Then
                objDerived.Execute("INSERT INTO [AMS].[tbl_PPE_Details] ([PropertyDetai_ID],[Item_ID],[BrandName],[SerialNo],[Model],[Warranty],[Depreciation_Rate],[Salvage_Value],[Specifications],[eq_Powerinput]                            " &
                              "  ,[mv_PlateNo],[mv_ChasisNo],[mv_EngineNo],[mv_MVFileNo],[mv_ConductionSticker],[mv_RegistrationDate],[mv_Color],[ma_EnginNo],[ma_PermitNo],[ma_WorkingLoad],[ma_ServiceFloor],[ma_Location],[ma_Dimension])    " &
                              "  VALUES                                                         " &
                              "  ('" & Session("PropertyDetai_ID") & "'                         " &
                              "  ,'" & Session("Item_ID") & "'       " &
                              "  ,'" & txtPPE_BrandName.Text & "'                               " &
                              "  ,'" & txtPPE_SerialNo.Text & "'                                " &
                              "  ,'" & txtPPE_Model.Text & "'                                   " &
                              "  ,'" & txtPPE_Warranty.Text & "'                                " &
                              "  ,'" & CType(txtPPE_DepRate.Text, Decimal) & "'                  " &
                              "  ,'" & CType(txtPPE_SalvageValue.Text, Decimal) & "'             " &
                              "  ,'" & replaceapostrophe(txtPPE_Specifications.Text) & "'        " &
                              "  ,'" & txtPPE_Powerinput.Text & "'                               " &
                              "  ,'" & txtMV_PlateNo.Text & "'                                   " &
                              "  ,'" & txtMV_ChasisNo.Text & "'                                  " &
                              "  ,'" & txtMV_EngineNo.Text & "'                                  " &
                              "  ,'" & txtMV_FileNo.Text & "'                                    " &
                              "  ,'" & txtMV_ConductionSticker.Text & "'                         " &
                              "  ,'" & CType(txtMV_RegistrationDate.Text, Date) & "'             " &
                              "  ,'" & txtMV_Color.Text & "'                                     " &
                              "  ,'" & txtMA_EngineNo.Text & "'                                  " &
                              "  ,'" & txtMA_PermitNo.Text & "'                                  " &
                              "  ,'" & txtMA_WorkingLoad.Text & "'                               " &
                              "  ,'" & txtMA_ServiceFloor.Text & "'                              " &
                              "  ,'" & txtMA_Location.Text & "'                                  " &
                              "  ,'" & txtMA_Dimension.Text & "')", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property information has been successfully saved.")

            Else
                objDerived.Execute("UPDATE [AMS].[tbl_PPE_Details]                                                  " &
                                  "  SET [BrandName] = '" & txtPPE_BrandName.Text & "'                              " &
                                  "  ,[SerialNo] = '" & txtPPE_SerialNo.Text & "'                                   " &
                                  "  ,[Model] = '" & txtPPE_Model.Text & "'                                         " &
                                  "  ,[Warranty] = '" & txtPPE_Warranty.Text & "'                                   " &
                                  "  ,[Depreciation_Rate] = '" & CType(txtPPE_DepRate.Text, Decimal) & "'           " &
                                  "  ,[Salvage_Value] = '" & CType(txtPPE_SalvageValue.Text, Decimal) & "'          " &
                                  "  ,[Specifications] = '" & replaceapostrophe(txtPPE_Specifications.Text) & "'    " &
                                  "  ,[eq_Powerinput] = '" & txtPPE_Powerinput.Text & "'                            " &
                                  "  ,[mv_PlateNo] = '" & txtMV_PlateNo.Text & "'                                   " &
                                  "  ,[mv_ChasisNo] = '" & txtMV_ChasisNo.Text & "'                                 " &
                                  "  ,[mv_EngineNo] = '" & txtMV_EngineNo.Text & "'                                 " &
                                  "  ,[mv_MVFileNo] = '" & txtMV_FileNo.Text & "'                                   " &
                                  "  ,[mv_ConductionSticker] = '" & txtMV_ConductionSticker.Text & "'               " &
                                  "  ,[mv_RegistrationDate] = '" & CType(txtMV_RegistrationDate.Text, Date) & "'    " &
                                  "  ,[mv_Color] = '" & txtMV_Color.Text & "'                                       " &
                                  "  ,[ma_EnginNo] = '" & txtMA_EngineNo.Text & "'                                  " &
                                  "  ,[ma_PermitNo] = '" & txtMA_PermitNo.Text & "'                                 " &
                                  "  ,[ma_WorkingLoad] = '" & txtMA_WorkingLoad.Text & "'                           " &
                                  "  ,[ma_ServiceFloor] = '" & txtMA_ServiceFloor.Text & "'                         " &
                                  "  ,[ma_Location] = '" & txtMA_Location.Text & "'                                 " &
                                  "  ,[ma_Dimension] = '" & txtMA_Dimension.Text & "'                               " &
                                  "  WHERE [ppe_details_id] = '" & ID & "'", CommandType.Text)

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Property information has been successfully updated.")

            End If

            objDerived.Execute("UPDATE AMS.Property_Dtl SET SerialNo = '" & txtPPE_SerialNo.Text & "' WHERE PropertyDetai_ID = '" & Session("PropertyDetai_ID") & "'", CommandType.Text)

            btnEdit_PPEDetails.Enabled = False
            btnSave_PPEDetails.Enabled = False

            LoadDisable_PPEDetails()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Protected Sub LoadClear_PPEDetails()
        txtPPE_BrandName.Text = ""
        txtPPE_Model.Text = ""
        txtPPE_SerialNo.Text = ""
        txtPPE_Powerinput.Text = ""
        txtPPE_Warranty.Text = ""
        txtPPE_SalvageValue.Text = "0.00"
        txtPPE_DepRate.Text = "0.00"
        txtPPE_DepValue.Text = "0.00"

        txtPPE_Specifications.Text = ""

        txtMA_EngineNo.Text = ""
        txtMA_PermitNo.Text = ""
        txtMA_WorkingLoad.Text = ""
        txtMA_ServiceFloor.Text = ""
        txtMA_Dimension.Text = ""
        txtMA_Location.Text = ""

        txtMV_PlateNo.Text = ""
        txtMV_ChasisNo.Text = ""
        txtMV_EngineNo.Text = ""
        txtMV_FileNo.Text = ""
        txtMV_ConductionSticker.Text = ""
        txtMV_RegistrationDate.Text = ""
        txtMV_Color.Text = ""

    End Sub
    Protected Sub LoadDisable_PPEDetails()
        txtPPE_BrandName.Enabled = False
        txtPPE_Model.Enabled = False
        txtPPE_SerialNo.Enabled = False
        txtPPE_Powerinput.Enabled = False
        txtPPE_Warranty.Enabled = False
        txtPPE_SalvageValue.Enabled = False
        txtPPE_DepRate.Enabled = False
        txtPPE_DepValue.Enabled = False

        txtPPE_Specifications.Enabled = False

        txtMA_EngineNo.Enabled = False
        txtMA_PermitNo.Enabled = False
        txtMA_WorkingLoad.Enabled = False
        txtMA_ServiceFloor.Enabled = False
        txtMA_Dimension.Enabled = False
        txtMA_Location.Enabled = False

        txtMV_PlateNo.Enabled = False
        txtMV_ChasisNo.Enabled = False
        txtMV_EngineNo.Enabled = False
        txtMV_FileNo.Enabled = False
        txtMV_ConductionSticker.Enabled = False
        txtMV_RegistrationDate.Enabled = False
        txtMV_Color.Enabled = False

    End Sub
    Protected Sub loadDonationLedger()
        ''Dim dtledger As New DataTable
        ''dtledger = objDerived.GetDataTable("Select * from AMS.TbDonation_Ledger where PropertyNo ='" & grdDonationDtl.SelectedDataKey("PropertyNo") & "'", CommandType.Text)
        ''If dtledger.Rows.Count < 10 Then
        ''    dtledger.Merge(createdatatableledger(9 - dtledger.Rows.Count))
        ''End If

        ''grdDonationLedger.DataSource = dtledger
        ''grdDonationLedger.DataBind()


        'Dim dtledger As New DataTable
        'dtledger = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & grdDonationDtl.SelectedDataKey("Item_ID") & "','" & grdDonationDtl.SelectedDataKey("PropertyDetai_ID") & "'", CommandType.Text)
        'If dtledger.Rows.Count < 5 Then
        '    dtledger.Merge(dtTemp_Ledger(4 - dtledger.Rows.Count))
        'End If

        'grdLedger.DataSource = dtledger
        'grdLedger.DataBind()


    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        'Me.Page.Response.Redirect("~/Records/rpt_VSummaryOfDonationToLGU.aspx")

        Dim url As String = "rpt_VSummaryOfDonationToLGU.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub

#Region "Table"
    Public Function createdatatable1(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("ReferenceNo", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Item_ID", GetType(Long))
        dt.Columns.Add("Property_ID", GetType(Long))
        dt.Columns.Add("PropertyDetai_ID", GetType(Long))
        dt.Columns.Add("Prop_Status", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))
        dt.Columns.Add("DonorName", GetType(String))
        dt.Columns.Add("Address", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("ReferenceNo") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Item_ID") = DBNull.Value
            dr("Property_ID") = DBNull.Value
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Prop_Status") = DBNull.Value
            dr("isVisible") = False
            dr("DonorName") = DBNull.Value
            dr("Address") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function createdatatableLGU(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Preview", GetType(String))
        dt.Columns.Add("Date_Issued", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("Remarks", GetType(String))
        dt.Columns.Add("Item_Description", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        dt.Columns.Add("Cost", GetType(String))


        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Preview") = DBNull.Value
            dr("Date_Issued") = DBNull.Value
            dr("Department") = DBNull.Value
            dr("Remarks") = DBNull.Value
            dr("Item_Description") = DBNull.Value
            dr("Description") = DBNull.Value
            dr("Qty") = DBNull.Value
            dr("Cost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function dtTemp_Ledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("Trans_Date", GetType(Date))
        dt.Columns.Add("Prop_Transaction", GetType(String))
        dt.Columns.Add("Trans_Reference", GetType(String))
        dt.Columns.Add("Accountable_Person", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        'dt.Columns.Add("position", GetType(String))
        'dt.Columns.Add("Accountable_Person", GetType(String))
        'dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Debit", GetType(Integer))
        dt.Columns.Add("DebitAmt", GetType(Decimal))
        dt.Columns.Add("Credit", GetType(Integer))
        dt.Columns.Add("CreditAmt", GetType(Decimal))
        dt.Columns.Add("Balance", GetType(Integer))
        dt.Columns.Add("BalanceAmt", GetType(Decimal))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Trans_Date") = DBNull.Value
            dr("Prop_Transaction") = DBNull.Value
            dr("Trans_Reference") = DBNull.Value
            dr("Accountable_Person") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            'dr("position") = DBNull.Value
            'dr("Accountable_Person") = DBNull.Value
            'dr("inspectedby") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("Debit") = DBNull.Value
            dr("DebitAmt") = DBNull.Value
            dr("Credit") = DBNull.Value
            dr("CreditAmt") = DBNull.Value
            dr("Balance") = DBNull.Value
            dr("BalanceAmt") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region


    Protected Sub btnDTL_Click(sender As Object, e As EventArgs) Handles btnDTL.Click
        Me.mvDonation.SetActiveView(Me.vwDonationToLGU)
        btnDTL.CssClass = "Clicked"
        btnLTL.CssClass = "Initial"
    End Sub
    Protected Sub btnLTL_Click(sender As Object, e As EventArgs) Handles btnLTL.Click
        Me.mvDonation.SetActiveView(Me.vwLGUToLGU)
        btnDTL.CssClass = "Initial"
        btnLTL.CssClass = "Clicked"
        LoadPage_LGU_TO_LGU()

    End Sub
    Protected Sub grLGUToLGU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grLGUToLGU.SelectedIndexChanged
        Session("LGUToLGU_HRD_ID") = grLGUToLGU.SelectedDataKey("DonationLGUtoLGU_ID")

        Dim url As String = "r_Donation_LGUToLGU.aspx"
        Dim options As String = "status=0,screenX=0,resizable=1,scrollbars=1,width=850,height=700,left=250,top=100"
        Dim fullURL As String = String.Format("window.open('{0}', '_blank', '{1}');", url, options)
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
    Protected Sub lnkPreview_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnPreviewAllLGUToLGU_Click(sender As Object, e As EventArgs) Handles btnPreviewAllLGUToLGU.Click
        ''Me.Page.Response.Redirect("~/Records/rpt_vSummaryDonationLGUtoLGU.aspx")

        Dim url As String = "rpt_vSummaryDonationLGUtoLGU.aspx?"
        Dim fullURL As String = "var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub
End Class
