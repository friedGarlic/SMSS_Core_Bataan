Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Property_Machinery
    Inherits BaseDLL.BaseDAL

#Region "property"


    Private pMachineryId As Integer
    Public Property MachineryId() As Integer
        Get
            Return pMachineryId
        End Get
        Set(ByVal value As Integer)
            pMachineryId = value
        End Set
    End Property

    Private pProperty_ID As Integer
    Public Property Property_ID() As Integer
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Integer)
            pProperty_ID = value
        End Set
    End Property


    Private pBrandModel As String
    Public Property BrandModel() As String
        Get
            Return pBrandModel
        End Get
        Set(ByVal value As String)
            pBrandModel = value
        End Set
    End Property


    Private pType As String
    Public Property Type() As String
        Get
            Return pType
        End Get
        Set(ByVal value As String)
            pType = value
        End Set
    End Property

    Private pLocation As String
    Public Property Location() As String
        Get
            Return pLocation
        End Get
        Set(ByVal value As String)
            pLocation = value
        End Set
    End Property


    Private pNoofPassenger As String
    Public Property NoofPassenger() As String
        Get
            Return pNoofPassenger
        End Get
        Set(ByVal value As String)
            pNoofPassenger = value
        End Set
    End Property


    Private pServiceFloors As String
    Public Property ServiceFloors() As String
        Get
            Return pServiceFloors
        End Get
        Set(ByVal value As String)
            pServiceFloors = value
        End Set
    End Property


    Private pUnitNo As String
    Public Property UnitNo() As String
        Get
            Return pUnitNo
        End Get
        Set(ByVal value As String)
            pUnitNo = value
        End Set
    End Property


    Private pWorkingLoad As String
    Public Property WorkingLoad() As String
        Get
            Return pWorkingLoad
        End Get
        Set(ByVal value As String)
            pWorkingLoad = value
        End Set
    End Property


    Private pRatedSpeed As String
    Public Property RatedSpeed() As String
        Get
            Return pRatedSpeed
        End Get
        Set(ByVal value As String)
            pRatedSpeed = value
        End Set
    End Property

    Private pCarDimension As String
    Public Property CarDimension() As String
        Get
            Return pCarDimension
        End Get
        Set(ByVal value As String)
            pCarDimension = value
        End Set
    End Property


    Private pMechPermitNo As String
    Public Property MechPermitNo() As String
        Get
            Return pMechPermitNo
        End Get
        Set(ByVal value As String)
            pMechPermitNo = value
        End Set
    End Property


    Private pDateToOperate As Date
    Public Property DateToOperate() As Date
        Get
            Return pDateToOperate
        End Get
        Set(ByVal value As Date)
            pDateToOperate = value
        End Set
    End Property

    Private pDateIssued As Date
    Public Property DateIssued() As Date
        Get
            Return pDateIssued
        End Get
        Set(ByVal value As Date)
            pDateIssued = value
        End Set
    End Property


    Private pDateInspected As Date
    Public Property DateInspected() As Date
        Get
            Return pDateInspected
        End Get
        Set(ByVal value As Date)
            pDateInspected = value
        End Set
    End Property


    Private pInspectedBy As String
    Public Property InspectedBy() As String
        Get
            Return pInspectedBy
        End Get
        Set(ByVal value As String)
            pInspectedBy = value
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

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MachineryId", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@BrandModel", BrandModel)
        objDerived.cmd.Parameters.AddWithValue("@Type", Type)
        objDerived.cmd.Parameters.AddWithValue("@Location", Location)
        objDerived.cmd.Parameters.AddWithValue("@NoofPassenger", NoofPassenger)
        objDerived.cmd.Parameters.AddWithValue("@ServiceFloors", ServiceFloors)
        objDerived.cmd.Parameters.AddWithValue("@UnitNo", UnitNo)
        objDerived.cmd.Parameters.AddWithValue("@WorkingLoad", WorkingLoad)
        objDerived.cmd.Parameters.AddWithValue("@RatedSpeed", RatedSpeed)
        objDerived.cmd.Parameters.AddWithValue("@CarDimension", CarDimension)
        objDerived.cmd.Parameters.AddWithValue("@MechPermitNo", MechPermitNo)
        objDerived.cmd.Parameters.AddWithValue("@DateToOperate", DateToOperate)
        objDerived.cmd.Parameters.AddWithValue("@DateIssued", DateIssued)
        objDerived.cmd.Parameters.AddWithValue("@DateInspected", DateInspected)
        objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveMachinery", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MachineryId", MachineryId)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@BrandModel", BrandModel)
        objDerived.cmd.Parameters.AddWithValue("@Type", Type)
        objDerived.cmd.Parameters.AddWithValue("@Location", Location)
        objDerived.cmd.Parameters.AddWithValue("@NoofPassenger", NoofPassenger)
        objDerived.cmd.Parameters.AddWithValue("@ServiceFloors", ServiceFloors)
        objDerived.cmd.Parameters.AddWithValue("@UnitNo", UnitNo)
        objDerived.cmd.Parameters.AddWithValue("@WorkingLoad", WorkingLoad)
        objDerived.cmd.Parameters.AddWithValue("@RatedSpeed", RatedSpeed)
        objDerived.cmd.Parameters.AddWithValue("@CarDimension", CarDimension)
        objDerived.cmd.Parameters.AddWithValue("@MechPermitNo", MechPermitNo)
        objDerived.cmd.Parameters.AddWithValue("@DateToOperate", DateToOperate)
        objDerived.cmd.Parameters.AddWithValue("@DateIssued", DateIssued)
        objDerived.cmd.Parameters.AddWithValue("@DateInspected", DateInspected)
        objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveMachinery", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class

