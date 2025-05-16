Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class DBM_APR
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pAPR_ID As Long
    Public Property APR_ID() As Long
        Get
            Return pAPR_ID
        End Get
        Set(ByVal value As Long)
            pAPR_ID = value
        End Set
    End Property

    Private pAPR_Date As Date
    Public Property APR_Date() As Date
        Get
            Return pAPR_Date
        End Get
        Set(ByVal value As Date)
            pAPR_Date = value
        End Set
    End Property

    Private pAPR_Year As Integer
    Public Property APR_Year() As Integer
        Get
            Return pAPR_Year
        End Get
        Set(ByVal value As Integer)
            pAPR_Year = value
        End Set
    End Property

    Private pAPR_Quarter As Integer
    Public Property APR_Quarter() As Integer
        Get
            Return pAPR_Quarter
        End Get
        Set(ByVal value As Integer)
            pAPR_Quarter = value
        End Set
    End Property

    Private pItem_ID As Long
    Public Property Item_ID() As Long
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Long)
            pItem_ID = value
        End Set
    End Property

    Private pQuantity As Integer
    Public Property Quantity() As Integer
        Get
            Return pQuantity
        End Get
        Set(ByVal value As Integer)
            pQuantity = value
        End Set
    End Property

    Private pUnitPrice As Decimal
    Public Property UnitPrice() As Decimal
        Get
            Return pUnitPrice
        End Get
        Set(ByVal value As Decimal)
            pUnitPrice = value
        End Set
    End Property

    Private pMayor As Long
    Public Property Mayor() As Long
        Get
            Return pMayor
        End Get
        Set(ByVal value As Long)
            pMayor = value
        End Set
    End Property

    Private pAccountant As Long
    Public Property Accountant() As Long
        Get
            Return pAccountant
        End Get
        Set(ByVal value As Long)
            pAccountant = value
        End Set
    End Property

    Private pPropertyOfficer As Long
    Public Property PropertyOfficer() As Long
        Get
            Return pPropertyOfficer
        End Get
        Set(ByVal value As Long)
            pPropertyOfficer = value
        End Set
    End Property

    Private pDBM_ID As Long
    Public Property DBM_ID() As Long
        Get
            Return pDBM_ID
        End Get
        Set(ByVal value As Long)
            pDBM_ID = value
        End Set
    End Property
#End Region

    Public Function save() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@APR_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@APR_Date", APR_Date)
        objDerived.cmd.Parameters.AddWithValue("@APR_Year", APR_Year)
        objDerived.cmd.Parameters.AddWithValue("@APR_Quarter", APR_Quarter)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)
        objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
        objDerived.cmd.Parameters.AddWithValue("@Mayor", Mayor)
        objDerived.cmd.Parameters.AddWithValue("@Accountant", Accountant)
        objDerived.cmd.Parameters.AddWithValue("@PropertyOfficer", PropertyOfficer)
        objDerived.cmd.Parameters.AddWithValue("@DBM_ID", DBM_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[sp_Save_DBM_APR]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@APR_ID", APR_ID)
        objDerived.cmd.Parameters.AddWithValue("@APR_Date", APR_Date)
        objDerived.cmd.Parameters.AddWithValue("@APR_Year", APR_Year)
        objDerived.cmd.Parameters.AddWithValue("@APR_Quarter", APR_Quarter)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Quantity", Quantity)
        objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
        objDerived.cmd.Parameters.AddWithValue("@Mayor", Mayor)
        objDerived.cmd.Parameters.AddWithValue("@Accountant", Accountant)
        objDerived.cmd.Parameters.AddWithValue("@PropertyOfficer", PropertyOfficer)
        objDerived.cmd.Parameters.AddWithValue("@DBM_ID", DBM_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[sp_Save_DBM_APR]", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
