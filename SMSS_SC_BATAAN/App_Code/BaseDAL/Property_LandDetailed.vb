Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Property_LandDetailed
    Inherits BaseDLL.BaseDAL

#Region "property"

    Private pLandDetailedId As Integer
    Public Property LandDetailedId() As Integer
        Get
            Return pLandDetailedId
        End Get
        Set(ByVal value As Integer)
            pLandDetailedId = value
        End Set
    End Property

    Private pRevYear As Integer
    Public Property RevYear() As Integer
        Get
            Return pRevYear
        End Get
        Set(ByVal value As Integer)
            pRevYear = value
        End Set
    End Property

    Private pStatus As String
    Public Property Status() As String
        Get
            Return pStatus
        End Get
        Set(ByVal value As String)
            pStatus = value
        End Set
    End Property

    Private pDistrictcode As Integer
    Public Property Districtcode() As Integer
        Get
            Return pDistrictcode
        End Get
        Set(ByVal value As Integer)
            pDistrictcode = value
        End Set
    End Property

    Private pTransaction As String
    Public Property Transaction() As String
        Get
            Return pTransaction
        End Get
        Set(ByVal value As String)
            pTransaction = value
        End Set
    End Property
    Private pBrgycode As Integer
    Public Property Brgycode() As Integer
        Get
            Return pBrgycode
        End Get
        Set(ByVal value As Integer)
            pBrgycode = value
        End Set
    End Property

    Private pTransactionCode As String
    Public Property TransactionCode() As String
        Get
            Return pTransactionCode
        End Get
        Set(ByVal value As String)
            pTransactionCode = value
        End Set
    End Property

    Private pPIN As String
    Public Property PIN() As String
        Get
            Return pPIN
        End Get
        Set(ByVal value As String)
            pPIN = value
        End Set
    End Property

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@LandDetailedId", 0)
        objDerived.cmd.Parameters.AddWithValue("@RevYear", RevYear)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Districtcode", Districtcode)
        objDerived.cmd.Parameters.AddWithValue("@Transaction", Transaction)
        objDerived.cmd.Parameters.AddWithValue("@Brgycode", Brgycode)
        objDerived.cmd.Parameters.AddWithValue("@TransactionCode", TransactionCode)
        objDerived.cmd.Parameters.AddWithValue("@PIN", PIN)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveLandDetailed", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@LandDetailedId", LandDetailedId)
        objDerived.cmd.Parameters.AddWithValue("@RevYear", RevYear)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Districtcode", Districtcode)
        objDerived.cmd.Parameters.AddWithValue("@Transaction", Transaction)
        objDerived.cmd.Parameters.AddWithValue("@Brgycode", Brgycode)
        objDerived.cmd.Parameters.AddWithValue("@TransactionCode", TransactionCode)
        objDerived.cmd.Parameters.AddWithValue("@PIN", PIN)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.SaveLandDetailed", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class


