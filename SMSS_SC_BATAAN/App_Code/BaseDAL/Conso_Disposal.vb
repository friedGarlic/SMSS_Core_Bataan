Imports System
Imports System.Data


Namespace Conso_Disposal

#Region "CheckList"

    Public Class CheckListUnserviceable
        Inherits BaseDLL.BaseDAL

        Private pchecklist_ID As Integer
        Public Property checklist_ID() As Integer
            Get
                Return pchecklist_ID
            End Get
            Set(ByVal value As Integer)
                pchecklist_ID = value
            End Set
        End Property

        Private pPropertyDetai_ID As Integer
        Public Property PropertyDetai_ID() As Integer
            Get
                Return pPropertyDetai_ID
            End Get
            Set(ByVal value As Integer)
                pPropertyDetai_ID = value
            End Set
        End Property

        Private pcheck_date As DateTime
        Public Property check_date() As DateTime
            Get
                Return pcheck_date
            End Get
            Set(ByVal value As DateTime)
                pcheck_date = value
            End Set
        End Property

        Private pRemarks As String
        Public Property Remarks() As String
            Get
                Return pRemarks
            End Get
            Set(ByVal value As String)
                pRemarks = value
            End Set
        End Property

        Private pInspectedby1 As Integer
        Public Property Inspectedby1() As Integer
            Get
                Return pInspectedby1
            End Get
            Set(ByVal value As Integer)
                pInspectedby1 = value
            End Set
        End Property

        Private pInspectedby2 As Integer
        Public Property Inspectedby2() As Integer
            Get
                Return pInspectedby2
            End Get
            Set(ByVal value As Integer)
                pInspectedby2 = value
            End Set
        End Property

        Private pEngine_OperatingCondition As String
        Public Property Engine_OperatingCondition() As String
            Get
                Return pEngine_OperatingCondition
            End Get
            Set(ByVal value As String)
                pEngine_OperatingCondition = value
            End Set
        End Property

        Private pEngine_InjectionPump As String
        Public Property Engine_InjectionPump() As String
            Get
                Return pEngine_InjectionPump
            End Get
            Set(ByVal value As String)
                pEngine_InjectionPump = value
            End Set
        End Property

        Private pEngine_Nozzle As String
        Public Property Engine_Nozzle() As String
            Get
                Return pEngine_Nozzle
            End Get
            Set(ByVal value As String)
                pEngine_Nozzle = value
            End Set
        End Property

        Private pEngine_FuelPump As String
        Public Property Engine_FuelPump() As String
            Get
                Return pEngine_FuelPump
            End Get
            Set(ByVal value As String)
                pEngine_FuelPump = value
            End Set
        End Property

        Private pEngine_CylinderHead As String
        Public Property Engine_CylinderHead() As String
            Get
                Return pEngine_CylinderHead
            End Get
            Set(ByVal value As String)
                pEngine_CylinderHead = value
            End Set
        End Property

        Private pEngine_WaterPump As String
        Public Property Engine_WaterPump() As String
            Get
                Return pEngine_WaterPump
            End Get
            Set(ByVal value As String)
                pEngine_WaterPump = value
            End Set
        End Property

        Private pEngine_Radiator As String
        Public Property Engine_Radiator() As String
            Get
                Return pEngine_Radiator
            End Get
            Set(ByVal value As String)
                pEngine_Radiator = value
            End Set
        End Property

        Private pEngine_AirCleaner As String
        Public Property Engine_AirCleaner() As String
            Get
                Return pEngine_AirCleaner
            End Get
            Set(ByVal value As String)
                pEngine_AirCleaner = value
            End Set
        End Property

        Private pEngine_Carburator As String
        Public Property Engine_Carburator() As String
            Get
                Return pEngine_Carburator
            End Get
            Set(ByVal value As String)
                pEngine_Carburator = value
            End Set
        End Property

        Private pEngine_Governor As String
        Public Property Engine_Governor() As String
            Get
                Return pEngine_Governor
            End Get
            Set(ByVal value As String)
                pEngine_Governor = value
            End Set
        End Property

        Private pEngine_TurboCharger As String
        Public Property Engine_TurboCharger() As String
            Get
                Return pEngine_TurboCharger
            End Get
            Set(ByVal value As String)
                pEngine_TurboCharger = value
            End Set
        End Property

        Private pEngine_OilCooler As String
        Public Property Engine_OilCooler() As String
            Get
                Return pEngine_OilCooler
            End Get
            Set(ByVal value As String)
                pEngine_OilCooler = value
            End Set
        End Property

        Private pEngine_NoofCylinders As String
        Public Property Engine_NoofCylinders() As String
            Get
                Return pEngine_NoofCylinders
            End Get
            Set(ByVal value As String)
                pEngine_NoofCylinders = value
            End Set
        End Property

        Private pSusp_FrontSpring As String
        Public Property Susp_FrontSpring() As String
            Get
                Return pSusp_FrontSpring
            End Get
            Set(ByVal value As String)
                pSusp_FrontSpring = value
            End Set
        End Property

        Private pSusp_RearSpring As String
        Public Property Susp_RearSpring() As String
            Get
                Return pSusp_RearSpring
            End Get
            Set(ByVal value As String)
                pSusp_RearSpring = value
            End Set
        End Property

        Private pWheel_TiresFront As String
        Public Property Wheel_TiresFront() As String
            Get
                Return pWheel_TiresFront
            End Get
            Set(ByVal value As String)
                pWheel_TiresFront = value
            End Set
        End Property

        Private pWheel_TiresRear As String
        Public Property Wheel_TiresRear() As String
            Get
                Return pWheel_TiresRear
            End Get
            Set(ByVal value As String)
                pWheel_TiresRear = value
            End Set
        End Property

        Private pWheel_SpareTire As String
        Public Property Wheel_SpareTire() As String
            Get
                Return pWheel_SpareTire
            End Get
            Set(ByVal value As String)
                pWheel_SpareTire = value
            End Set
        End Property

        Private pShaft_Front As String
        Public Property Shaft_Front() As String
            Get
                Return pShaft_Front
            End Get
            Set(ByVal value As String)
                pShaft_Front = value
            End Set
        End Property

        Private pShaft_Rear As String
        Public Property Shaft_Rear() As String
            Get
                Return pShaft_Rear
            End Get
            Set(ByVal value As String)
                pShaft_Rear = value
            End Set
        End Property

        Private pElec_Generator As String
        Public Property Elec_Generator() As String
            Get
                Return pElec_Generator
            End Get
            Set(ByVal value As String)
                pElec_Generator = value
            End Set
        End Property

        Private pElec_Starter As String
        Public Property Elec_Starter() As String
            Get
                Return pElec_Starter
            End Get
            Set(ByVal value As String)
                pElec_Starter = value
            End Set
        End Property

        Private pElec_VoltageRegulator As String
        Public Property Elec_VoltageRegulator() As String
            Get
                Return pElec_VoltageRegulator
            End Get
            Set(ByVal value As String)
                pElec_VoltageRegulator = value
            End Set
        End Property

        Private pElec_Solenoid As String
        Public Property Elec_Solenoid() As String
            Get
                Return pElec_Solenoid
            End Get
            Set(ByVal value As String)
                pElec_Solenoid = value
            End Set
        End Property

        Private pElec_IgnitionCoil As String
        Public Property Elec_IgnitionCoil() As String
            Get
                Return pElec_IgnitionCoil
            End Get
            Set(ByVal value As String)
                pElec_IgnitionCoil = value
            End Set
        End Property

        Private pElec_Magneto As String
        Public Property Elec_Magneto() As String
            Get
                Return pElec_Magneto
            End Get
            Set(ByVal value As String)
                pElec_Magneto = value
            End Set
        End Property

        Private pElec_Distributor As String
        Public Property Elec_Distributor() As String
            Get
                Return pElec_Distributor
            End Get
            Set(ByVal value As String)
                pElec_Distributor = value
            End Set
        End Property

        Private pElec_Wiper As String
        Public Property Elec_Wiper() As String
            Get
                Return pElec_Wiper
            End Get
            Set(ByVal value As String)
                pElec_Wiper = value
            End Set
        End Property

        Private pElec_Headlight As String
        Public Property Elec_Headlight() As String
            Get
                Return pElec_Headlight
            End Get
            Set(ByVal value As String)
                pElec_Headlight = value
            End Set
        End Property

        Private pElec_Taillight As String
        Public Property Elec_Taillight() As String
            Get
                Return pElec_Taillight
            End Get
            Set(ByVal value As String)
                pElec_Taillight = value
            End Set
        End Property

        Private pElec_DirectionalLight As String
        Public Property Elec_DirectionalLight() As String
            Get
                Return pElec_DirectionalLight
            End Get
            Set(ByVal value As String)
                pElec_DirectionalLight = value
            End Set
        End Property

        Private pElec_Battery As String
        Public Property Elec_Battery() As String
            Get
                Return pElec_Battery
            End Get
            Set(ByVal value As String)
                pElec_Battery = value
            End Set
        End Property

        Private pElec_Clutch As String
        Public Property Elec_Clutch() As String
            Get
                Return pElec_Clutch
            End Get
            Set(ByVal value As String)
                pElec_Clutch = value
            End Set
        End Property

        Private pDiff_Front As String
        Public Property Diff_Front() As String
            Get
                Return pDiff_Front
            End Get
            Set(ByVal value As String)
                pDiff_Front = value
            End Set
        End Property

        Private pDiff_Rear As String
        Public Property Diff_Rear() As String
            Get
                Return pDiff_Rear
            End Get
            Set(ByVal value As String)
                pDiff_Rear = value
            End Set
        End Property

        Private pFinal_Sprocket As String
        Public Property Final_Sprocket() As String
            Get
                Return pFinal_Sprocket
            End Get
            Set(ByVal value As String)
                pFinal_Sprocket = value
            End Set
        End Property

        Private pFinal_DriveChain As String
        Public Property Final_DriveChain() As String
            Get
                Return pFinal_DriveChain
            End Get
            Set(ByVal value As String)
                pFinal_DriveChain = value
            End Set
        End Property

        Private pCarriage_TrackLink As String
        Public Property Carriage_TrackLink() As String
            Get
                Return pCarriage_TrackLink
            End Get
            Set(ByVal value As String)
                pCarriage_TrackLink = value
            End Set
        End Property

        Private pCarriage_Idler As String
        Public Property Carriage_Idler() As String
            Get
                Return pCarriage_Idler
            End Get
            Set(ByVal value As String)
                pCarriage_Idler = value
            End Set
        End Property

        Private pCarriage_TrackAdjuster As String
        Public Property Carriage_TrackAdjuster() As String
            Get
                Return pCarriage_TrackAdjuster
            End Get
            Set(ByVal value As String)
                pCarriage_TrackAdjuster = value
            End Set
        End Property

        Private pCarriage_TrackRoller As String
        Public Property Carriage_TrackRoller() As String
            Get
                Return pCarriage_TrackRoller
            End Get
            Set(ByVal value As String)
                pCarriage_TrackRoller = value
            End Set
        End Property

        Private pCarriage_CarrierRoller As String
        Public Property Carriage_CarrierRoller() As String
            Get
                Return pCarriage_CarrierRoller
            End Get
            Set(ByVal value As String)
                pCarriage_CarrierRoller = value
            End Set
        End Property

        Private pCarriage_TorqueConverter As String
        Public Property Carriage_TorqueConverter() As String
            Get
                Return pCarriage_TorqueConverter
            End Get
            Set(ByVal value As String)
                pCarriage_TorqueConverter = value
            End Set
        End Property

        Private pCarriage_Fenders As String
        Public Property Carriage_Fenders() As String
            Get
                Return pCarriage_Fenders
            End Get
            Set(ByVal value As String)
                pCarriage_Fenders = value
            End Set
        End Property

        Private pCarriage_ChasisFrame As String
        Public Property Carriage_ChasisFrame() As String
            Get
                Return pCarriage_ChasisFrame
            End Get
            Set(ByVal value As String)
                pCarriage_ChasisFrame = value
            End Set
        End Property

        Private pCarriage_WindShield As String
        Public Property Carriage_WindShield() As String
            Get
                Return pCarriage_WindShield
            End Get
            Set(ByVal value As String)
                pCarriage_WindShield = value
            End Set
        End Property

        Private pCarriage_FuelTank As String
        Public Property Carriage_FuelTank() As String
            Get
                Return pCarriage_FuelTank
            End Get
            Set(ByVal value As String)
                pCarriage_FuelTank = value
            End Set
        End Property

        Private pCushions_FrontSeat As String
        Public Property Cushions_FrontSeat() As String
            Get
                Return pCushions_FrontSeat
            End Get
            Set(ByVal value As String)
                pCushions_FrontSeat = value
            End Set
        End Property

        Private pCushions_RearSeat As String
        Public Property Cushions_RearSeat() As String
            Get
                Return pCushions_RearSeat
            End Get
            Set(ByVal value As String)
                pCushions_RearSeat = value
            End Set
        End Property

        Private pCushions_OperatorSeat As String
        Public Property Cushions_OperatorSeat() As String
            Get
                Return pCushions_OperatorSeat
            End Get
            Set(ByVal value As String)
                pCushions_OperatorSeat = value
            End Set
        End Property

        Private pCushions_IgnitionCoil As String
        Public Property Cushions_IgnitionCoil() As String
            Get
                Return pCushions_IgnitionCoil
            End Get
            Set(ByVal value As String)
                pCushions_IgnitionCoil = value
            End Set
        End Property

        Private pGauges_ServiceMeter As String
        Public Property Gauges_ServiceMeter() As String
            Get
                Return pGauges_ServiceMeter
            End Get
            Set(ByVal value As String)
                pGauges_ServiceMeter = value
            End Set
        End Property

        Private pGauges_Speedometer As String
        Public Property Gauges_Speedometer() As String
            Get
                Return pGauges_Speedometer
            End Get
            Set(ByVal value As String)
                pGauges_Speedometer = value
            End Set
        End Property

        Private pGauges_Tachometer As String
        Public Property Gauges_Tachometer() As String
            Get
                Return pGauges_Tachometer
            End Get
            Set(ByVal value As String)
                pGauges_Tachometer = value
            End Set
        End Property

        Private pGauges_Temperature As String
        Public Property Gauges_Temperature() As String
            Get
                Return pGauges_Temperature
            End Get
            Set(ByVal value As String)
                pGauges_Temperature = value
            End Set
        End Property

        Private pGauges_OilPressure As String
        Public Property Gauges_OilPressure() As String
            Get
                Return pGauges_OilPressure
            End Get
            Set(ByVal value As String)
                pGauges_OilPressure = value
            End Set
        End Property

        Private pGauges_ConverterOilTemp As String
        Public Property Gauges_ConverterOilTemp() As String
            Get
                Return pGauges_ConverterOilTemp
            End Get
            Set(ByVal value As String)
                pGauges_ConverterOilTemp = value
            End Set
        End Property

        Private pHydraulic_Pump As String
        Public Property Hydraulic_Pump() As String
            Get
                Return pHydraulic_Pump
            End Get
            Set(ByVal value As String)
                pHydraulic_Pump = value
            End Set
        End Property

        Private pHydraulic_Motor As String
        Public Property Hydraulic_Motor() As String
            Get
                Return pHydraulic_Motor
            End Get
            Set(ByVal value As String)
                pHydraulic_Motor = value
            End Set
        End Property

        Private pHydraulic_Hoses As String
        Public Property Hydraulic_Hoses() As String
            Get
                Return pHydraulic_Hoses
            End Get
            Set(ByVal value As String)
                pHydraulic_Hoses = value
            End Set
        End Property

        Private pHydraulic_ControlValve As String
        Public Property Hydraulic_ControlValve() As String
            Get
                Return pHydraulic_ControlValve
            End Get
            Set(ByVal value As String)
                pHydraulic_ControlValve = value
            End Set
        End Property

        Private pHydraulic_Cylinders As String
        Public Property Hydraulic_Cylinders() As String
            Get
                Return pHydraulic_Cylinders
            End Get
            Set(ByVal value As String)
                pHydraulic_Cylinders = value
            End Set
        End Property

        Private pHydraulic_Transmission As String
        Public Property Hydraulic_Transmission() As String
            Get
                Return pHydraulic_Transmission
            End Get
            Set(ByVal value As String)
                pHydraulic_Transmission = value
            End Set
        End Property

        Private pHydraulic_Transfercase As String
        Public Property Hydraulic_Transfercase() As String
            Get
                Return pHydraulic_Transfercase
            End Get
            Set(ByVal value As String)
                pHydraulic_Transfercase = value
            End Set
        End Property

        Private pHydraulic_Windshield As String
        Public Property Hydraulic_Windshield() As String
            Get
                Return pHydraulic_Windshield
            End Get
            Set(ByVal value As String)
                pHydraulic_Windshield = value
            End Set
        End Property

        Private pHydraulic_FuelTank As String
        Public Property Hydraulic_FuelTank() As String
            Get
                Return pHydraulic_FuelTank
            End Get
            Set(ByVal value As String)
                pHydraulic_FuelTank = value
            End Set
        End Property

        Private pBrake_MasterCylinder As String
        Public Property Brake_MasterCylinder() As String
            Get
                Return pBrake_MasterCylinder
            End Get
            Set(ByVal value As String)
                pBrake_MasterCylinder = value
            End Set
        End Property

        Private pSteering_Power As String
        Public Property Steering_Power() As String
            Get
                Return pSteering_Power
            End Get
            Set(ByVal value As String)
                pSteering_Power = value
            End Set
        End Property

        Private pSteering_Clutch As String
        Public Property Steering_Clutch() As String
            Get
                Return pSteering_Clutch
            End Get
            Set(ByVal value As String)
                pSteering_Clutch = value
            End Set
        End Property

        Private pSteering_Disk As String
        Public Property Steering_Disk() As String
            Get
                Return pSteering_Disk
            End Get
            Set(ByVal value As String)
                pSteering_Disk = value
            End Set
        End Property

        Private pAcc_DozerBlade As String
        Public Property Acc_DozerBlade() As String
            Get
                Return pAcc_DozerBlade
            End Get
            Set(ByVal value As String)
                pAcc_DozerBlade = value
            End Set
        End Property

        Private pAcc_CuttingEdges As String
        Public Property Acc_CuttingEdges() As String
            Get
                Return pAcc_CuttingEdges
            End Get
            Set(ByVal value As String)
                pAcc_CuttingEdges = value
            End Set
        End Property

        Private pAcc_DraglineBucket As String
        Public Property Acc_DraglineBucket() As String
            Get
                Return pAcc_DraglineBucket
            End Get
            Set(ByVal value As String)
                pAcc_DraglineBucket = value
            End Set
        End Property

        Private pAcc_BackhoeBucket As String
        Public Property Acc_BackhoeBucket() As String
            Get
                Return pAcc_BackhoeBucket
            End Get
            Set(ByVal value As String)
                pAcc_BackhoeBucket = value
            End Set
        End Property

        Private pAcc_Fairlead As String
        Public Property Acc_Fairlead() As String
            Get
                Return pAcc_Fairlead
            End Get
            Set(ByVal value As String)
                pAcc_Fairlead = value
            End Set
        End Property

        Private pAcc_Compressor As String
        Public Property Acc_Compressor() As String
            Get
                Return pAcc_Compressor
            End Get
            Set(ByVal value As String)
                pAcc_Compressor = value
            End Set
        End Property

        Private pAcc_Boom As String
        Public Property Acc_Boom() As String
            Get
                Return pAcc_Boom
            End Get
            Set(ByVal value As String)
                pAcc_Boom = value
            End Set
        End Property

        Private pAcc_LiftingBlock As String
        Public Property Acc_LiftingBlock() As String
            Get
                Return pAcc_LiftingBlock
            End Get
            Set(ByVal value As String)
                pAcc_LiftingBlock = value
            End Set
        End Property

        Private pAcc_Riper As String
        Public Property Acc_Riper() As String
            Get
                Return pAcc_Riper
            End Get
            Set(ByVal value As String)
                pAcc_Riper = value
            End Set
        End Property

        Private pAcc_EndBits As String
        Public Property Acc_EndBits() As String
            Get
                Return pAcc_EndBits
            End Get
            Set(ByVal value As String)
                pAcc_EndBits = value
            End Set
        End Property

        Private pAcc_ClamshellBucket As String
        Public Property Acc_ClamshellBucket() As String
            Get
                Return pAcc_ClamshellBucket
            End Get
            Set(ByVal value As String)
                pAcc_ClamshellBucket = value
            End Set
        End Property

        Private pAcc_DitchingBucket As String
        Public Property Acc_DitchingBucket() As String
            Get
                Return pAcc_DitchingBucket
            End Get
            Set(ByVal value As String)
                pAcc_DitchingBucket = value
            End Set
        End Property

        Private pAcc_Tagline As String
        Public Property Acc_Tagline() As String
            Get
                Return pAcc_Tagline
            End Get
            Set(ByVal value As String)
                pAcc_Tagline = value
            End Set
        End Property

        Private pAcc_Cables As String
        Public Property Acc_Cables() As String
            Get
                Return pAcc_Cables
            End Get
            Set(ByVal value As String)
                pAcc_Cables = value
            End Set
        End Property

        Private pAcc_BoomPulley As String
        Public Property Acc_BoomPulley() As String
            Get
                Return pAcc_BoomPulley
            End Get
            Set(ByVal value As String)
                pAcc_BoomPulley = value
            End Set
        End Property

        Private pAcc_Others As String
        Public Property Acc_Others() As String
            Get
                Return pAcc_Others
            End Get
            Set(ByVal value As String)
                pAcc_Others = value
            End Set
        End Property

        Private pOther_Body As String
        Public Property Other_Body() As String
            Get
                Return pOther_Body
            End Get
            Set(ByVal value As String)
                pOther_Body = value
            End Set
        End Property

        Private pOther_Casing As String
        Public Property Other_Casing() As String
            Get
                Return pOther_Casing
            End Get
            Set(ByVal value As String)
                pOther_Casing = value
            End Set
        End Property

        Private pOther_FrontCover As String
        Public Property Other_FrontCover() As String
            Get
                Return pOther_FrontCover
            End Get
            Set(ByVal value As String)
                pOther_FrontCover = value
            End Set
        End Property

        Private pOther_AirFilterElement As String
        Public Property Other_AirFilterElement() As String
            Get
                Return pOther_AirFilterElement
            End Get
            Set(ByVal value As String)
                pOther_AirFilterElement = value
            End Set
        End Property

        Public Function Save() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@checklist_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", PropertyDetai_ID)
            objDerived.cmd.Parameters.AddWithValue("@check_date", check_date)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@Inspectedby1", Inspectedby1)
            objDerived.cmd.Parameters.AddWithValue("@Inspectedby2", Inspectedby2)
            objDerived.cmd.Parameters.AddWithValue("@Engine_OperatingCondition", Engine_OperatingCondition)
            objDerived.cmd.Parameters.AddWithValue("@Engine_InjectionPump", Engine_InjectionPump)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Nozzle", Engine_Nozzle)
            objDerived.cmd.Parameters.AddWithValue("@Engine_FuelPump", Engine_FuelPump)
            objDerived.cmd.Parameters.AddWithValue("@Engine_CylinderHead", Engine_CylinderHead)
            objDerived.cmd.Parameters.AddWithValue("@Engine_WaterPump", Engine_WaterPump)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Radiator", Engine_Radiator)
            objDerived.cmd.Parameters.AddWithValue("@Engine_AirCleaner", Engine_AirCleaner)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Carburator", Engine_Carburator)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Governor", Engine_Governor)
            objDerived.cmd.Parameters.AddWithValue("@Engine_TurboCharger", Engine_TurboCharger)
            objDerived.cmd.Parameters.AddWithValue("@Engine_OilCooler", Engine_OilCooler)
            objDerived.cmd.Parameters.AddWithValue("@Engine_NoofCylinders", Engine_NoofCylinders)
            objDerived.cmd.Parameters.AddWithValue("@Susp_FrontSpring", Susp_FrontSpring)
            objDerived.cmd.Parameters.AddWithValue("@Susp_RearSpring", Susp_RearSpring)
            objDerived.cmd.Parameters.AddWithValue("@Wheel_TiresFront", Wheel_TiresFront)
            objDerived.cmd.Parameters.AddWithValue("@Wheel_TiresRear", Wheel_TiresRear)
            objDerived.cmd.Parameters.AddWithValue("@Wheel_SpareTire", Wheel_SpareTire)
            objDerived.cmd.Parameters.AddWithValue("@Shaft_Front", Shaft_Front)
            objDerived.cmd.Parameters.AddWithValue("@Shaft_Rear", Shaft_Rear)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Generator", Elec_Generator)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Starter", Elec_Starter)
            objDerived.cmd.Parameters.AddWithValue("@Elec_VoltageRegulator", Elec_VoltageRegulator)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Solenoid", Elec_Solenoid)
            objDerived.cmd.Parameters.AddWithValue("@Elec_IgnitionCoil", Elec_IgnitionCoil)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Magneto", Elec_Magneto)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Distributor", Elec_Distributor)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Wiper", Elec_Wiper)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Headlight", Elec_Headlight)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Taillight", Elec_Taillight)
            objDerived.cmd.Parameters.AddWithValue("@Elec_DirectionalLight", Elec_DirectionalLight)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Battery", Elec_Battery)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Clutch", Elec_Clutch)
            objDerived.cmd.Parameters.AddWithValue("@Diff_Front", Diff_Front)
            objDerived.cmd.Parameters.AddWithValue("@Diff_Rear", Diff_Rear)
            objDerived.cmd.Parameters.AddWithValue("@Final_Sprocket", Final_Sprocket)
            objDerived.cmd.Parameters.AddWithValue("@Final_DriveChain", Final_DriveChain)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TrackLink", Carriage_TrackLink)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_Idler", Carriage_Idler)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TrackAdjuster", Carriage_TrackAdjuster)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TrackRoller", Carriage_TrackRoller)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_CarrierRoller", Carriage_CarrierRoller)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TorqueConverter", Carriage_TorqueConverter)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_Fenders", Carriage_Fenders)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_ChasisFrame", Carriage_ChasisFrame)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_WindShield", Carriage_WindShield)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_FuelTank", Carriage_FuelTank)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_FrontSeat", Cushions_FrontSeat)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_RearSeat", Cushions_RearSeat)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_OperatorSeat", Cushions_OperatorSeat)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_IgnitionCoil", Cushions_IgnitionCoil)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_ServiceMeter", Gauges_ServiceMeter)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_Speedometer", Gauges_Speedometer)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_Tachometer", Gauges_Tachometer)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_Temperature", Gauges_Temperature)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_OilPressure", Gauges_OilPressure)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_ConverterOilTemp", Gauges_ConverterOilTemp)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Pump", Hydraulic_Pump)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Motor", Hydraulic_Motor)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Hoses", Hydraulic_Hoses)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_ControlValve", Hydraulic_ControlValve)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Cylinders", Hydraulic_Cylinders)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Transmission", Hydraulic_Transmission)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Transfercase", Hydraulic_Transfercase)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Windshield", Hydraulic_Windshield)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_FuelTank", Hydraulic_FuelTank)
            objDerived.cmd.Parameters.AddWithValue("@Brake_MasterCylinder", Brake_MasterCylinder)
            objDerived.cmd.Parameters.AddWithValue("@Steering_Power", Steering_Power)
            objDerived.cmd.Parameters.AddWithValue("@Steering_Clutch", Steering_Clutch)
            objDerived.cmd.Parameters.AddWithValue("@Steering_Disk", Steering_Disk)
            objDerived.cmd.Parameters.AddWithValue("@Acc_DozerBlade", Acc_DozerBlade)
            objDerived.cmd.Parameters.AddWithValue("@Acc_CuttingEdges", Acc_CuttingEdges)
            objDerived.cmd.Parameters.AddWithValue("@Acc_DraglineBucket", Acc_DraglineBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_BackhoeBucket", Acc_BackhoeBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Fairlead", Acc_Fairlead)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Compressor", Acc_Compressor)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Boom", Acc_Boom)
            objDerived.cmd.Parameters.AddWithValue("@Acc_LiftingBlock", Acc_LiftingBlock)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Riper", Acc_Riper)
            objDerived.cmd.Parameters.AddWithValue("@Acc_EndBits", Acc_EndBits)
            objDerived.cmd.Parameters.AddWithValue("@Acc_ClamshellBucket", Acc_ClamshellBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_DitchingBucket", Acc_DitchingBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Tagline", Acc_Tagline)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Cables", Acc_Cables)
            objDerived.cmd.Parameters.AddWithValue("@Acc_BoomPulley", Acc_BoomPulley)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Others", Acc_Others)
            objDerived.cmd.Parameters.AddWithValue("@Other_Body", Other_Body)
            objDerived.cmd.Parameters.AddWithValue("@Other_Casing", Other_Casing)
            objDerived.cmd.Parameters.AddWithValue("@Other_FrontCover", Other_FrontCover)
            objDerived.cmd.Parameters.AddWithValue("@Other_AirFilterElement", Other_AirFilterElement)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[sp_Save_tbl_ChecklistUnserviceableProp]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function Update() As Long
            Dim objDerived As New DerivedDal
            Dim i As Long
            conStr = objDerived.DbaseConnect
            objDerived.cmd.Parameters.AddWithValue("@checklist_ID", checklist_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", PropertyDetai_ID)
            objDerived.cmd.Parameters.AddWithValue("@check_date", check_date)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
            objDerived.cmd.Parameters.AddWithValue("@Inspectedby1", Inspectedby1)
            objDerived.cmd.Parameters.AddWithValue("@Inspectedby2", Inspectedby2)
            objDerived.cmd.Parameters.AddWithValue("@Engine_OperatingCondition", Engine_OperatingCondition)
            objDerived.cmd.Parameters.AddWithValue("@Engine_InjectionPump", Engine_InjectionPump)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Nozzle", Engine_Nozzle)
            objDerived.cmd.Parameters.AddWithValue("@Engine_FuelPump", Engine_FuelPump)
            objDerived.cmd.Parameters.AddWithValue("@Engine_CylinderHead", Engine_CylinderHead)
            objDerived.cmd.Parameters.AddWithValue("@Engine_WaterPump", Engine_WaterPump)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Radiator", Engine_Radiator)
            objDerived.cmd.Parameters.AddWithValue("@Engine_AirCleaner", Engine_AirCleaner)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Carburator", Engine_Carburator)
            objDerived.cmd.Parameters.AddWithValue("@Engine_Governor", Engine_Governor)
            objDerived.cmd.Parameters.AddWithValue("@Engine_TurboCharger", Engine_TurboCharger)
            objDerived.cmd.Parameters.AddWithValue("@Engine_OilCooler", Engine_OilCooler)
            objDerived.cmd.Parameters.AddWithValue("@Engine_NoofCylinders", Engine_NoofCylinders)
            objDerived.cmd.Parameters.AddWithValue("@Susp_FrontSpring", Susp_FrontSpring)
            objDerived.cmd.Parameters.AddWithValue("@Susp_RearSpring", Susp_RearSpring)
            objDerived.cmd.Parameters.AddWithValue("@Wheel_TiresFront", Wheel_TiresFront)
            objDerived.cmd.Parameters.AddWithValue("@Wheel_TiresRear", Wheel_TiresRear)
            objDerived.cmd.Parameters.AddWithValue("@Wheel_SpareTire", Wheel_SpareTire)
            objDerived.cmd.Parameters.AddWithValue("@Shaft_Front", Shaft_Front)
            objDerived.cmd.Parameters.AddWithValue("@Shaft_Rear", Shaft_Rear)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Generator", Elec_Generator)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Starter", Elec_Starter)
            objDerived.cmd.Parameters.AddWithValue("@Elec_VoltageRegulator", Elec_VoltageRegulator)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Solenoid", Elec_Solenoid)
            objDerived.cmd.Parameters.AddWithValue("@Elec_IgnitionCoil", Elec_IgnitionCoil)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Magneto", Elec_Magneto)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Distributor", Elec_Distributor)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Wiper", Elec_Wiper)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Headlight", Elec_Headlight)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Taillight", Elec_Taillight)
            objDerived.cmd.Parameters.AddWithValue("@Elec_DirectionalLight", Elec_DirectionalLight)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Battery", Elec_Battery)
            objDerived.cmd.Parameters.AddWithValue("@Elec_Clutch", Elec_Clutch)
            objDerived.cmd.Parameters.AddWithValue("@Diff_Front", Diff_Front)
            objDerived.cmd.Parameters.AddWithValue("@Diff_Rear", Diff_Rear)
            objDerived.cmd.Parameters.AddWithValue("@Final_Sprocket", Final_Sprocket)
            objDerived.cmd.Parameters.AddWithValue("@Final_DriveChain", Final_DriveChain)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TrackLink", Carriage_TrackLink)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_Idler", Carriage_Idler)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TrackAdjuster", Carriage_TrackAdjuster)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TrackRoller", Carriage_TrackRoller)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_CarrierRoller", Carriage_CarrierRoller)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_TorqueConverter", Carriage_TorqueConverter)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_Fenders", Carriage_Fenders)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_ChasisFrame", Carriage_ChasisFrame)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_WindShield", Carriage_WindShield)
            objDerived.cmd.Parameters.AddWithValue("@Carriage_FuelTank", Carriage_FuelTank)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_FrontSeat", Cushions_FrontSeat)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_RearSeat", Cushions_RearSeat)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_OperatorSeat", Cushions_OperatorSeat)
            objDerived.cmd.Parameters.AddWithValue("@Cushions_IgnitionCoil", Cushions_IgnitionCoil)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_ServiceMeter", Gauges_ServiceMeter)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_Speedometer", Gauges_Speedometer)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_Tachometer", Gauges_Tachometer)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_Temperature", Gauges_Temperature)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_OilPressure", Gauges_OilPressure)
            objDerived.cmd.Parameters.AddWithValue("@Gauges_ConverterOilTemp", Gauges_ConverterOilTemp)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Pump", Hydraulic_Pump)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Motor", Hydraulic_Motor)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Hoses", Hydraulic_Hoses)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_ControlValve", Hydraulic_ControlValve)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Cylinders", Hydraulic_Cylinders)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Transmission", Hydraulic_Transmission)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Transfercase", Hydraulic_Transfercase)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_Windshield", Hydraulic_Windshield)
            objDerived.cmd.Parameters.AddWithValue("@Hydraulic_FuelTank", Hydraulic_FuelTank)
            objDerived.cmd.Parameters.AddWithValue("@Brake_MasterCylinder", Brake_MasterCylinder)
            objDerived.cmd.Parameters.AddWithValue("@Steering_Power", Steering_Power)
            objDerived.cmd.Parameters.AddWithValue("@Steering_Clutch", Steering_Clutch)
            objDerived.cmd.Parameters.AddWithValue("@Steering_Disk", Steering_Disk)
            objDerived.cmd.Parameters.AddWithValue("@Acc_DozerBlade", Acc_DozerBlade)
            objDerived.cmd.Parameters.AddWithValue("@Acc_CuttingEdges", Acc_CuttingEdges)
            objDerived.cmd.Parameters.AddWithValue("@Acc_DraglineBucket", Acc_DraglineBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_BackhoeBucket", Acc_BackhoeBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Fairlead", Acc_Fairlead)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Compressor", Acc_Compressor)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Boom", Acc_Boom)
            objDerived.cmd.Parameters.AddWithValue("@Acc_LiftingBlock", Acc_LiftingBlock)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Riper", Acc_Riper)
            objDerived.cmd.Parameters.AddWithValue("@Acc_EndBits", Acc_EndBits)
            objDerived.cmd.Parameters.AddWithValue("@Acc_ClamshellBucket", Acc_ClamshellBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_DitchingBucket", Acc_DitchingBucket)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Tagline", Acc_Tagline)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Cables", Acc_Cables)
            objDerived.cmd.Parameters.AddWithValue("@Acc_BoomPulley", Acc_BoomPulley)
            objDerived.cmd.Parameters.AddWithValue("@Acc_Others", Acc_Others)
            objDerived.cmd.Parameters.AddWithValue("@Other_Body", Other_Body)
            objDerived.cmd.Parameters.AddWithValue("@Other_Casing", Other_Casing)
            objDerived.cmd.Parameters.AddWithValue("@Other_FrontCover", Other_FrontCover)
            objDerived.cmd.Parameters.AddWithValue("@Other_AirFilterElement", Other_AirFilterElement)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[sp_Save_tbl_ChecklistUnserviceableProp]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region



End Namespace