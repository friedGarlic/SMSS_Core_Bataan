Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic


Public Class Property_Land
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pLandID As Integer
    Public Property LandID() As Integer
        Get
            Return pLandID
        End Get
        Set(ByVal value As Integer)
            pLandID = value
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

    Private pLandDetailedId As Integer
    Public Property LandDetailedId() As Integer
        Get
            Return pLandDetailedId
        End Get
        Set(ByVal value As Integer)
            pLandDetailedId = value
        End Set
    End Property

    Private pUnit As String
    Public Property Unit() As String
        Get
            Return pUnit
        End Get
        Set(ByVal value As String)
            pUnit = value
        End Set
    End Property

    Private pUnitValue As Decimal
    Public Property UnitValue() As Decimal
        Get
            Return pUnitValue
        End Get
        Set(ByVal value As Decimal)
            pUnitValue = value
        End Set
    End Property

    Private pBasemarketvalue As Decimal
    Public Property Basemarketvalue() As Decimal
        Get
            Return pBasemarketvalue
        End Get
        Set(ByVal value As Decimal)
            pBasemarketvalue = value
        End Set
    End Property

    Private pTaxable As String
    Public Property Taxable() As String
        Get
            Return pTaxable
        End Get
        Set(ByVal value As String)
            pTaxable = value
        End Set
    End Property

    Private pAdjustment As Decimal
    Public Property Adjustment() As Decimal
        Get
            Return pAdjustment
        End Get
        Set(ByVal value As Decimal)
            pAdjustment = value
        End Set
    End Property

    Private pKind As String
    Public Property Kind() As String
        Get
            Return pKind
        End Get
        Set(ByVal value As String)
            pKind = value
        End Set
    End Property

    Private pSortOrder As Integer
    Public Property SortOrder() As Integer
        Get
            Return pSortOrder
        End Get
        Set(ByVal value As Integer)
            pSortOrder = value
        End Set
    End Property
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@LandID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@LandDetailedId", LandDetailedId)
        objDerived.cmd.Parameters.AddWithValue("@Unit", Unit)
        objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
        objDerived.cmd.Parameters.AddWithValue("@Basemarketvalue", Basemarketvalue)
        objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
        objDerived.cmd.Parameters.AddWithValue("@Adjustment", Adjustment)
        objDerived.cmd.Parameters.AddWithValue("@Kind", Kind)
        objDerived.cmd.Parameters.AddWithValue("@SortOrder", SortOrder)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveLand", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@LandID", LandID)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@LandDetailedId", LandDetailedId)
        objDerived.cmd.Parameters.AddWithValue("@Unit", Unit)
        objDerived.cmd.Parameters.AddWithValue("@UnitValue", UnitValue)
        objDerived.cmd.Parameters.AddWithValue("@Basemarketvalue", Basemarketvalue)
        objDerived.cmd.Parameters.AddWithValue("@Taxable", Taxable)
        objDerived.cmd.Parameters.AddWithValue("@Adjustment", Adjustment)
        objDerived.cmd.Parameters.AddWithValue("@Kind", Kind)
        objDerived.cmd.Parameters.AddWithValue("@SortOrder", SortOrder)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveLand", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class


