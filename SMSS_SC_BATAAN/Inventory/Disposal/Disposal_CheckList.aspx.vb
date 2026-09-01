Imports System.Data
Partial Class Inventory_Disposal_Disposal_CheckList
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule
    Dim CheckList As New Conso_Disposal.CheckListUnserviceable


    Private Property dtItemList() As DataTable
        Get
            Return CType(Session("dtItemList"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtItemList") = value
        End Set
    End Property
    Public Function tempItemList(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("PropertyDetai_ID", GetType(Integer))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("UnitDesc", GetType(String))
        dt.Columns.Add("Cost", GetType(Decimal))
        dt.Columns.Add("Property_Date", GetType(Date))
        dt.Columns.Add("Returned_Date", GetType(Date))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("MotorNo", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyDetai_ID") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("UnitDesc") = DBNull.Value
            dr("Cost") = DBNull.Value
            dr("Property_Date") = DBNull.Value
            dr("Returned_Date") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("MotorNo") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function

    Private Sub Inventory_Disposal_Disposal_CheckList_Load(sender As Object, e As EventArgs) Handles Me.Load

        'obj.GetAccessRight(Me.Session("@UserName"), Page)
        'If obj.HasAccess = False Then
        '    Me.Page.Response.Redirect("~/etc/UnauthorizedPage.aspx")
        'End If

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today.ToShortDateString

            LoadPage()

        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
        drpDept.Attributes.Add("onChange", "StartProgressBar();")
        drpGenAccount.Attributes.Add("onChange", "StartProgressBar();")
        drpChecklist.Attributes.Add("onChange", "StartProgressBar();")
    End Sub

    Protected Sub LoadPage()

        drpDept.DataSource = objDerived.GetDataTable("SELECT RC_ID, RC_Name FROM DBO.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
        drpDept.DataTextField = "RC_Name"
        drpDept.DataValueField = "RC_ID"
        drpDept.DataBind()
        drpDept.Items.Insert(0, "Select")

        drpFunction.ClearSelection()
        drpFunction.Dispose()
        drpFunction.DataSource = Nothing
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")


        drpGenAccount.DataSource = objDerived.GetDataTable("SELECT GA_ID, BGA_ID, GA_Code2, (GA_Title2 + ' (' + GA_Code2 + ')') AS AccntTitle FROM AMS.View_AccountList WHERE AllotmentClass_ID = 3 ORDER BY GA_Title", CommandType.Text)
        drpGenAccount.DataTextField = "AccntTitle"
        drpGenAccount.DataValueField = "GA_ID"
        drpGenAccount.DataBind()
        drpGenAccount.Items.Insert(0, "Select")

        grdItemsList.DataSource = tempItemList(4)
        grdItemsList.DataBind()

        txtUnitSerialNo.Text = ""
        txtEngineSerialNo.Text = ""
        txtAcqCost.Text = ""
        txtAcqDate.Text = ""
        txtRemarks.Text = ""

        mvCheckList.SetActiveView(Me.vwVehicles)
        lblDetails.Text = "- Vehicles/Heavy Equipments"

    End Sub

    Private Sub drpDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpDept.SelectedIndexChanged
        drpFunction.DataSource = objDerived.GetDataTable("SELECT Function_ID, Function_Desc FROM DBO.View_RespCenter_withFunctions WHERE RC_ID = '" & drpDept.SelectedItem.Value & "' ORDER BY Function_Desc", CommandType.Text)
        drpFunction.DataTextField = "Function_Desc"
        drpFunction.DataValueField = "Function_ID"
        drpFunction.DataBind()
        drpFunction.Items.Insert(0, "Select")
    End Sub
    Private Sub drpGenAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpGenAccount.SelectedIndexChanged

        If drpGenAccount.SelectedItem.Value = 1166 Then
            ' Motor Vehicles
            mvCheckList.SetActiveView(Me.vwVehicles)
            lblDetails.Text = "- Vehicles/Heavy Equipments"
            drpChecklist.Enabled = False

        ElseIf drpGenAccount.SelectedItem.Value = 1145 Or drpGenAccount.SelectedItem.Value = 1142 Then
            ' Disaster Response and Rescue Equipment
            ' Construction and Heavy Equipment
            drpChecklist.Enabled = True

        Else
            ' Other Capital Outlay
            mvCheckList.SetActiveView(Me.vwOffice)
            lblDetails.Text = "- Office Equipments"
            drpChecklist.Enabled = False

        End If

        drpChecklist.SelectedIndex = 0

    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try

            If drpDept.SelectedItem.Text = "Select" Or drpFunction.SelectedItem.Text = "Select" Or drpGenAccount.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select details to view list of properties.")

            Else
                dtItemList = objDerived.GetDataTable("EXEC [AMS].[sp_CheckList_ItemList] '" & rbItems.SelectedItem.Text & "'," & drpGenAccount.SelectedItem.Value & "," & drpDept.SelectedItem.Value & "," & drpFunction.SelectedItem.Value & "", CommandType.Text)
                If dtItemList.Rows.Count < 5 Then
                    dtItemList.Merge(tempItemList(4 - dtItemList.Rows.Count))
                End If

                grdItemsList.DataSource = dtItemList
                grdItemsList.DataBind()

            End If


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub grdItemsList_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdItemsList.PageIndexChanging
        grdItemsList.DataSource = dtItemList
        grdItemsList.PageIndex = e.NewPageIndex
        grdItemsList.DataBind()
    End Sub

    Private Sub grdItemsList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdItemsList.SelectedIndexChanged
        Try

            If drpGenAccount.SelectedItem.Value = 1166 Or drpGenAccount.SelectedItem.Value = 1145 Or drpGenAccount.SelectedItem.Value = 1142 Then
                drpInspectedBy1.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name, position_desc FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY isDeptHead DESC, Full_Name", CommandType.Text)
                drpInspectedBy1.DataTextField = "Full_Name"
                drpInspectedBy1.DataValueField = "EmpID"
                drpInspectedBy1.DataBind()
                drpInspectedBy1.Items.Insert(0, "Select")

                drpInspectedby2.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name, position_desc FROM HRMS.view_signatory WHERE deptid = 7 AND division_Key = 86 ORDER BY isDeptHead DESC, Full_Name", CommandType.Text)
                drpInspectedby2.DataTextField = "Full_Name"
                drpInspectedby2.DataValueField = "EmpID"
                drpInspectedby2.DataBind()
                drpInspectedby2.Items.Insert(0, "Select")

                txtUnitSerialNo.Text = grdItemsList.SelectedDataKey("SerialNo")
                txtEngineSerialNo.Text = grdItemsList.SelectedDataKey("MotorNo")
                txtAcqCost.Text = FormatNumber(grdItemsList.SelectedDataKey("Cost"), 2)
                txtAcqDate.Text = grdItemsList.SelectedDataKey("Property_Date")


                btnSave.Enabled = True

            Else
                txtOE_SerialNo.Text = grdItemsList.SelectedDataKey("SerialNo")
                txtOE_AcquiredDate.Text = grdItemsList.SelectedDataKey("Property_Date")
                txtOE_DateUnserviceable.Text = grdItemsList.SelectedDataKey("Returned_Date")

                txtOE_Inspectedby.Text = ""
                txtOE_InspectedBy_Pos.Text = ""

                btnOE_Save.Enabled = True



            End If





        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If drpInspectedBy1.SelectedItem.Text = "Select" Or drpInspectedBy1.SelectedItem.Text = "Select" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select signatories to proceed.")
            Else

                With CheckList
                    .PropertyDetai_ID = grdItemsList.SelectedDataKey("PropertyDetai_ID")
                    .check_date = txtDate.Text
                    .Remarks = replaceapostrophe(txtRemarks.Text)
                    .Inspectedby1 = drpInspectedBy1.SelectedItem.Value
                    .Inspectedby2 = drpInspectedby2.SelectedItem.Value
                    .Engine_OperatingCondition = drpEngine_OperatingCondition.SelectedItem.Text
                    .Engine_InjectionPump = drpEngine_InjectionPump.SelectedItem.Text
                    .Engine_Nozzle = drpEngine_Nozzle.SelectedItem.Text
                    .Engine_FuelPump = drpEngine_FuelPump.SelectedItem.Text
                    .Engine_CylinderHead = drpEngine_CylinderHead.SelectedItem.Text
                    .Engine_WaterPump = drpEngine_WaterPump.SelectedItem.Text
                    .Engine_Radiator = drpEngine_Radiator.SelectedItem.Text
                    .Engine_AirCleaner = drpEngine_AirCleaner.SelectedItem.Text
                    .Engine_Carburator = drpEngine_Carburator.SelectedItem.Text
                    .Engine_Governor = drpEngine_Governor.SelectedItem.Text
                    .Engine_TurboCharger = drpEngine_Turbo.SelectedItem.Text
                    .Engine_OilCooler = drpEngine_OilCooler.SelectedItem.Text
                    .Engine_NoofCylinders = drpEngine_NoCylinder.SelectedItem.Text
                    .Susp_FrontSpring = drpSusp_FrontSpring.SelectedItem.Text
                    .Susp_RearSpring = drpSusp_RearSpring.SelectedItem.Text
                    .Wheel_TiresFront = drpWheel_TiresFront.SelectedItem.Text
                    .Wheel_TiresRear = drpWheel_TireRear.SelectedItem.Text
                    .Wheel_SpareTire = drpWheel_Spare.SelectedItem.Text
                    .Shaft_Front = drpShaft_Front.SelectedItem.Text
                    .Shaft_Rear = drpShaft_Rear.SelectedItem.Text
                    .Elec_Generator = drpElec_Generator.SelectedItem.Text
                    .Elec_Starter = drpElec_Starter.SelectedItem.Text
                    .Elec_VoltageRegulator = drpElec_VoltageRegulator.SelectedItem.Text
                    .Elec_Solenoid = drpElec_Solenoid.SelectedItem.Text
                    .Elec_IgnitionCoil = drpElec_IgnitionCoil.SelectedItem.Text
                    .Elec_Magneto = drpElec_Magneto.SelectedItem.Text
                    .Elec_Distributor = drpElec_Distributor.SelectedItem.Text
                    .Elec_Wiper = drpElec_Wiper.SelectedItem.Text
                    .Elec_Headlight = drpElec_HeadLight.SelectedItem.Text
                    .Elec_Taillight = drpElec_TailLight.SelectedItem.Text
                    .Elec_DirectionalLight = drpElec_DirectionalLightdrp.SelectedItem.Text
                    .Elec_Battery = drpElec_Battery.SelectedItem.Text
                    .Elec_Clutch = drpElec_Clutch.SelectedItem.Text
                    .Diff_Front = drpDiff_Front.SelectedItem.Text
                    .Diff_Rear = drpDiff_Rear.SelectedItem.Text
                    .Final_Sprocket = drpFinal_Sprocket.SelectedItem.Text
                    .Final_DriveChain = drpFinal_DriveChain.SelectedItem.Text
                    .Carriage_TrackLink = drpCarriage_TrackLink.SelectedItem.Text
                    .Carriage_Idler = drpCarriage_Idler.SelectedItem.Text
                    .Carriage_TrackAdjuster = drpCarriage_TrackAdjuster.SelectedItem.Text
                    .Carriage_TrackRoller = drpCarriage_TrackRoller.SelectedItem.Text
                    .Carriage_CarrierRoller = drpCarriage_CarrierRoller.SelectedItem.Text
                    .Carriage_TorqueConverter = drpCarriage_Torque.SelectedItem.Text
                    .Carriage_Fenders = drpCarriage_Fenders.SelectedItem.Text
                    .Carriage_ChasisFrame = drpCarriage_ChasisFrame.SelectedItem.Text
                    .Carriage_WindShield = drpCarriage_Windshield.SelectedItem.Text
                    .Carriage_FuelTank = drpCarriage_FuelTank.SelectedItem.Text
                    .Cushions_FrontSeat = drpCushions_FrontSeat.SelectedItem.Text
                    .Cushions_RearSeat = drpCushion_RearSeat.SelectedItem.Text
                    .Cushions_OperatorSeat = drpCushion_OperatorSeat.SelectedItem.Text
                    .Cushions_IgnitionCoil = drpCushion_IgnitionCoil.SelectedItem.Text
                    .Gauges_ServiceMeter = drpGauge_ServiceMeter.SelectedItem.Text
                    .Gauges_Speedometer = drpGauge_SpeedoMeter.SelectedItem.Text
                    .Gauges_Tachometer = drpGauge_TachoMeter.SelectedItem.Text
                    .Gauges_Temperature = drpGauge_Temperature.SelectedItem.Text
                    .Gauges_OilPressure = drpGauge_OilPressure.SelectedItem.Text
                    .Gauges_ConverterOilTemp = drpGauge_ConverterOil.SelectedItem.Text
                    .Hydraulic_Pump = drpHydraulic_Pump.SelectedItem.Text
                    .Hydraulic_Motor = drpHydraulic_Motor.SelectedItem.Text
                    .Hydraulic_Hoses = drpHydraulic_Hoses.SelectedItem.Text
                    .Hydraulic_ControlValve = drpHydraulic_ControlValve.SelectedItem.Text
                    .Hydraulic_Cylinders = drpHydraulic_Cylinders.SelectedItem.Text
                    .Hydraulic_Transmission = drpHydraulic_Transmission.SelectedItem.Text
                    .Hydraulic_Transfercase = drpHydraulic_TransferCase.SelectedItem.Text
                    .Hydraulic_Windshield = drpHydraulic_Windshield.SelectedItem.Text
                    .Hydraulic_FuelTank = drpHydraulic_FuelTank.SelectedItem.Text
                    .Brake_MasterCylinder = drpBrake_MasterCylinder.SelectedItem.Text
                    .Steering_Power = drpSteering_Power.SelectedItem.Text
                    .Steering_Clutch = drpSteering_Clutch.SelectedItem.Text
                    .Steering_Disk = drpSteering_DiskPlate.SelectedItem.Text
                    .Acc_DozerBlade = drpAcc_Dozer.SelectedItem.Text
                    .Acc_CuttingEdges = drpAcc_CuttingEdges.SelectedItem.Text
                    .Acc_DraglineBucket = drpAcc_Dragline.SelectedItem.Text
                    .Acc_BackhoeBucket = drpAcc_Backhoe.SelectedItem.Text
                    .Acc_Fairlead = drpAcc_Fairlead.SelectedItem.Text
                    .Acc_Compressor = drpAcc_Compressor.SelectedItem.Text
                    .Acc_Boom = drpAcc_Boom.SelectedItem.Text
                    .Acc_LiftingBlock = drpAcc_LiftingBlock.SelectedItem.Text
                    .Acc_Riper = drpAcc_Riper.SelectedItem.Text
                    .Acc_EndBits = drpAcc_EndBits.SelectedItem.Text
                    .Acc_ClamshellBucket = drpAcc_Clamshell.SelectedItem.Text
                    .Acc_DitchingBucket = drpAcc_Ditching.SelectedItem.Text
                    .Acc_Tagline = drpAcc_Tagline.SelectedItem.Text
                    .Acc_Cables = drpAcc_Cables.SelectedItem.Text
                    .Acc_BoomPulley = drpAcc_BoomPully.SelectedItem.Text
                    .Acc_Others = drpAcc_Others.SelectedItem.Text
                    .Other_Body = txtOthers_Body.Text
                    .Other_Casing = txtOthers_Casing.Text
                    .Other_FrontCover = txtOthers_FrontCover.Text
                    .Other_AirFilterElement = txtOthers_AirFilter.Text

                End With

                Session("checklist_ID") = CheckList.Save()


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnSave.Enabled = False
                btnPreview.Enabled = True

            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Session("Report") = "Checklist"
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub

    Private Sub btnOE_Save_Click(sender As Object, e As EventArgs) Handles btnOE_Save.Click
        Try
            If txtOE_Inspectedby.Text = "" Or txtOE_InspectedBy_Pos.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Encode inspected by.")

            Else
                objDerived.Execute("INSERT INTO [AMS].[tbl_ChecklistUnserviceable_OE] ([PropertyDetai_ID],[date_reported],[check_date],[Inspectedby],[Inspectedby_Pos],[Elec_MotorCompressor],[Elec_RunningCapacitor],[Elec_StartingCapacitor],[Elec_SelectorSwitch],[Elec_MagneticContactor]   " &
                               " ,[Elec_Relay],[Elec_OverloadProtector],[Elec_CondensedFanMotor],[Elec_FanMotor],[Elec_TimeRelaySwitch],[Elec_Wiring],[Elec_Solenoid],[Mecha_Compressor],[Mecha_Thermostat],[Mecha_Condenser],[Mecha_Evaporator],[Mecha_FilterDrier]        " &
                               " ,[Mecha_CapillaryTube],[Mecha_PressureSwitch],[Mecha_ExpansionValve],[Mecha_Strainer],[Mecha_SurgeTank],[Mecha_HeatExchanger],[Mecha_SightGlass],[Other_Body],[Other_Casing],[Other_FrontCover],[Other_AirFilterElement])                  " &
                               " VALUES                                                        " &
                               " ('" & grdItemsList.SelectedDataKey("PropertyDetai_ID") & "'   " &
                               " ,'" & txtOE_DateUnserviceable.Text & "'                       " &
                               " ,'" & txtDate.Text & "'                                       " &
                               " ,'" & replaceapostrophe(txtOE_Inspectedby.Text) & "'          " &
                               " ,'" & replaceapostrophe(txtOE_InspectedBy_Pos.Text) & "'      " &
                               " ,'" & drpOE_MotorCompressor.SelectedItem.Text & "'            " &
                               " ,'" & drpOE_RunningCapacitor.SelectedItem.Text & "'           " &
                               " ,'" & drpOE_StartingCapacitor.SelectedItem.Text & "'          " &
                               " ,'" & drpOE_SelectorSwitch.SelectedItem.Text & "'             " &
                               " ,'" & drpOE_MagneticContactor.SelectedItem.Text & "'          " &
                               " ,'" & drpOE_Relay.SelectedItem.Text & "'                      " &
                               " ,'" & drpOE_OverloadProtector.SelectedItem.Text & "'          " &
                               " ,'" & drpOE_CondensedFanMotor.SelectedItem.Text & "'          " &
                               " ,'" & drpOE_FanMotor.SelectedItem.Text & "'                   " &
                               " ,'" & drpOE_TimeRelaySwitch.SelectedItem.Text & "'            " &
                               " ,'" & drpOE_Wiring.SelectedItem.Text & "'                     " &
                               " ,'" & drpOE_Solenoid.SelectedItem.Text & "'                   " &
                               " ,'" & drpOE_Compressor.SelectedItem.Text & "'                 " &
                               " ,'" & drpOE_Thermostat.SelectedItem.Text & "'                 " &
                               " ,'" & drpOE_Condenser.SelectedItem.Text & "'                  " &
                               " ,'" & drpOE_Evaporator.SelectedItem.Text & "'                 " &
                               " ,'" & drpOE_FilterDrier.SelectedItem.Text & "'                " &
                               " ,'" & drpOE_CapillaryTube.SelectedItem.Text & "'              " &
                               " ,'" & drpOE_PressureSwitch.SelectedItem.Text & "'             " &
                               " ,'" & drpOE_ExpansionValve.SelectedItem.Text & "'             " &
                               " ,'" & drpOE_Strainer.SelectedItem.Text & "'                   " &
                               " ,'" & drpOE_SurgeTank.SelectedItem.Text & "'                  " &
                               " ,'" & drpOE_HeatExchanger.SelectedItem.Text & "'              " &
                               " ,'" & drpOE_SightGlass.SelectedItem.Text & "'                 " &
                               " ,'" & drpOE_Body.SelectedItem.Text & "'                       " &
                               " ,'" & drpOE_Casing.SelectedItem.Text & "'                     " &
                               " ,'" & drpOE_FrontCover.SelectedItem.Text & "'                 " &
                               " ,'" & drpOE_AirFilterElement.SelectedItem.Text & "')", CommandType.Text)

                Session("OE_checklist_ID") = objDerived.GetValue("SELECT TOP(1) [OE_checklist_ID] FROM [AMS].[tbl_ChecklistUnserviceable_OE] ORDER BY [OE_checklist_ID] DESC", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")

                btnOE_Save.Enabled = False
                btnOE_Preview.Enabled = True

            End If



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnOE_Preview_Click(sender As Object, e As EventArgs) Handles btnOE_Preview.Click
        Session("Report") = "Checklist_OE"
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub

    Private Sub drpChecklist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpChecklist.SelectedIndexChanged
        If drpChecklist.SelectedItem.Value = 1 Then
            mvCheckList.SetActiveView(Me.vwVehicles)
            lblDetails.Text = "- Vehicles/Heavy Equipments"

        ElseIf drpChecklist.SelectedItem.Value = 2 Then
            mvCheckList.SetActiveView(Me.vwOffice)
            lblDetails.Text = "- Office Equipments"

        Else

        End If

    End Sub
End Class
