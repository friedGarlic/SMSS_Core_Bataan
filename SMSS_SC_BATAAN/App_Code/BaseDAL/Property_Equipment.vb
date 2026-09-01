Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Property_Equipment
    Inherits BaseDLL.BaseDAL

#Region "property"


    Private pEquipmentId As Integer
    Public Property EquipmentId() As Integer
        Get
            Return pEquipmentId
        End Get
        Set(ByVal value As Integer)
            pEquipmentId = value
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


    Private pName As String
    Public Property Name() As String
        Get
            Return pName
        End Get
        Set(ByVal value As String)
            pName = value
        End Set
    End Property


    Private pDescription As String
    Public Property Description() As String
        Get
            Return pDescription
        End Get
        Set(ByVal value As String)
            pDescription = value
        End Set
    End Property

    Private pPowerInput As String
    Public Property PowerInput() As String
        Get
            Return pPowerInput
        End Get
        Set(ByVal value As String)
            pPowerInput = value
        End Set
    End Property


    Private pDimension As String
    Public Property Dimension() As String
        Get
            Return pDimension
        End Get
        Set(ByVal value As String)
            pDimension = value
        End Set
    End Property


    Private pAreacapacity As String
    Public Property Areacapacity() As String
        Get
            Return pAreacapacity
        End Get
        Set(ByVal value As String)
            pAreacapacity = value
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


    Private pEquipSpeciification As String
    Public Property EquipSpeciification() As String
        Get
            Return pEquipSpeciification
        End Get
        Set(ByVal value As String)
            pEquipSpeciification = value
        End Set
    End Property


    Private pwaranty As String
    Public Property waranty() As String
        Get
            Return pwaranty
        End Get
        Set(ByVal value As String)
            pwaranty = value
        End Set
    End Property
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@EquipmentId", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@Name", Name)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
        objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
        objDerived.cmd.Parameters.AddWithValue("@Areacapacity", Areacapacity)
        objDerived.cmd.Parameters.AddWithValue("@Model", Model)
        objDerived.cmd.Parameters.AddWithValue("@EquipSpeciification", EquipSpeciification)
        objDerived.cmd.Parameters.AddWithValue("@waranty", waranty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveEquipment", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@EquipmentId", EquipmentId)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@Name", Name)
        objDerived.cmd.Parameters.AddWithValue("@Description", Description)
        objDerived.cmd.Parameters.AddWithValue("@PowerInput", PowerInput)
        objDerived.cmd.Parameters.AddWithValue("@Dimension", Dimension)
        objDerived.cmd.Parameters.AddWithValue("@Areacapacity", Areacapacity)
        objDerived.cmd.Parameters.AddWithValue("@Model", Model)
        objDerived.cmd.Parameters.AddWithValue("@EquipSpeciification", EquipSpeciification)
        objDerived.cmd.Parameters.AddWithValue("@waranty", waranty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveEquipment", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class


