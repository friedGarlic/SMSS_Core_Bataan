Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Property_MotorVehicle
    Inherits BaseDLL.BaseDAL

#Region "property"


    Private pMotorId As Integer
    Public Property MotorId() As Integer
        Get
            Return pMotorId
        End Get
        Set(ByVal value As Integer)
            pMotorId = value
        End Set
    End Property

    Private pProperty_id As Integer
    Public Property Property_id() As Integer
        Get
            Return pProperty_id
        End Get
        Set(ByVal value As Integer)
            pProperty_id = value
        End Set
    End Property


    Private pName As String
    Public Property Name() As String
        Get
            Return pName
        End Get
        Set(ByVal value As String)
            pName = value
        End Set
    End Property

    Private pPlateNo As String
    Public Property PlateNo() As String
        Get
            Return pPlateNo
        End Get
        Set(ByVal value As String)
            pPlateNo = value
        End Set
    End Property


    Private pMotorNo As String
    Public Property MotorNo() As String
        Get
            Return pMotorNo
        End Get
        Set(ByVal value As String)
            pMotorNo = value
        End Set
    End Property


    Private pModel As String
    Public Property Model() As String
        Get
            Return pModel
        End Get
        Set(ByVal value As String)
            pModel = value
        End Set
    End Property


    Private pChasisNo As String
    Public Property ChasisNo() As String
        Get
            Return pChasisNo
        End Get
        Set(ByVal value As String)
            pChasisNo = value
        End Set
    End Property

    Private pVehicleColor As String
    Public Property VehilceColor() As String
        Get
            Return pVehicleColor
        End Get
        Set(ByVal value As String)
            pVehicleColor = value
        End Set
    End Property

    Private pWheelsQty As String
    Public Property WheelsQty() As String
        Get
            Return pWheelsQty
        End Get
        Set(ByVal value As String)
            pWheelsQty = value
        End Set
    End Property

    Private pGrossWeight As String
    Public Property GrossWeight() As String
        Get
            Return pGrossWeight
        End Get
        Set(ByVal value As String)
            pGrossWeight = value
        End Set
    End Property

    Private pSeats As String
    Public Property Seats() As String
        Get
            Return pSeats
        End Get
        Set(ByVal value As String)
            pSeats = value
        End Set
    End Property

    Private pVehicleOwner As String
    Public Property Vehicleowner() As String
        Get
            Return pVehicleOwner
        End Get
        Set(ByVal value As String)
            pVehicleOwner = value
        End Set
    End Property

    Private pDeclaredName As String
    Public Property DeclaredName() As String
        Get
            Return pDeclaredName
        End Get
        Set(ByVal value As String)
            pDeclaredName = value
        End Set
    End Property

    Private pBeneficialUser As String
    Public Property BeneficialUser() As String
        Get
            Return pBeneficialUser
        End Get
        Set(ByVal value As String)
            pBeneficialUser = value
        End Set
    End Property
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MotorId", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_id)
        objDerived.cmd.Parameters.AddWithValue("@Name", Name)
        objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
        objDerived.cmd.Parameters.AddWithValue("@MotorNo", MotorNo)
        objDerived.cmd.Parameters.AddWithValue("@Model", Model)
        objDerived.cmd.Parameters.AddWithValue("@ChasisNo", ChasisNo)
        objDerived.cmd.Parameters.AddWithValue("@VehicleColor", VehilceColor)
        objDerived.cmd.Parameters.AddWithValue("@WheelsQty", WheelsQty)
        objDerived.cmd.Parameters.AddWithValue("@Grossweigth", GrossWeight)
        objDerived.cmd.Parameters.AddWithValue("@Seats", Seats)
        objDerived.cmd.Parameters.AddWithValue("@Vehicleowner", Vehicleowner)
        objDerived.cmd.Parameters.AddWithValue("@Declaredname", DeclaredName)
        objDerived.cmd.Parameters.AddWithValue("@BeneficialUser", BeneficialUser)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveMotorVehicle", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MotorId", MotorId)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_id)
        objDerived.cmd.Parameters.AddWithValue("@Name", Name)
        objDerived.cmd.Parameters.AddWithValue("@PlateNo", PlateNo)
        objDerived.cmd.Parameters.AddWithValue("@MotorNo", MotorNo)
        objDerived.cmd.Parameters.AddWithValue("@Model", Model)
        objDerived.cmd.Parameters.AddWithValue("@ChasisNo", ChasisNo)
        objDerived.cmd.Parameters.AddWithValue("@VehicleColor", VehilceColor)
        objDerived.cmd.Parameters.AddWithValue("@WheelsQty", WheelsQty)
        objDerived.cmd.Parameters.AddWithValue("@Grossweigth", GrossWeight)
        objDerived.cmd.Parameters.AddWithValue("@Seats", Seats)
        objDerived.cmd.Parameters.AddWithValue("@Vehicleowner", Vehicleowner)
        objDerived.cmd.Parameters.AddWithValue("@Declaredname", DeclaredName)
        objDerived.cmd.Parameters.AddWithValue("@BeneficialUser", BeneficialUser)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveMotorVehicle", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class

