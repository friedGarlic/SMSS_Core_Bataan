Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Stock
    Inherits BaseDLL.BaseDAL

#Region "property"

    Private pStockId As Integer
    Public Property StockId() As Integer
        Get
            Return pStockId
        End Get
        Set(ByVal value As Integer)
            pStockId = value
        End Set
    End Property

    Private pItemPackageId As Integer
    Public Property ItemPackageId() As Integer
        Get
            Return pItemPackageId
        End Get
        Set(ByVal value As Integer)
            pItemPackageId = value
        End Set
    End Property

    Private pBatchNo As String
    Public Property BatchNo() As String
        Get
            Return pBatchNo
        End Get
        Set(ByVal value As String)
            pBatchNo = value
        End Set
    End Property

    Private pLotNo As String
    Public Property LotNo() As String
        Get
            Return pLotNo
        End Get
        Set(ByVal value As String)
            pLotNo = value
        End Set
    End Property

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
        End Set
    End Property


    Private pDispensed As Integer
    Public Property Dispensed() As Integer
        Get
            Return pDispensed
        End Get
        Set(ByVal value As Integer)
            pDispensed = value
        End Set
    End Property

    Private pReturned As Integer
    Public Property Returned() As Integer
        Get
            Return pReturned
        End Get
        Set(ByVal value As Integer)
            pReturned = value
        End Set
    End Property

    Private pDisposed As Integer
    Public Property Disposed() As Integer
        Get
            Return pDisposed
        End Get
        Set(ByVal value As Integer)
            pDisposed = value
        End Set
    End Property

    Private pEOQ As Integer
    Public Property EOQ() As Integer
        Get
            Return pEOQ
        End Get
        Set(ByVal value As Integer)
            pEOQ = value
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
        objDerived.cmd.Parameters.AddWithValue("@StockId", 0)
        objDerived.cmd.Parameters.AddWithValue("@ItemPackageId", ItemPackageId)
        objDerived.cmd.Parameters.AddWithValue("@BatchNo", BatchNo)
        objDerived.cmd.Parameters.AddWithValue("@LotNo", LotNo)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Dispensed", Dispensed)
        'objDerived.cmd.Parameters.AddWithValue("@Returned", Returned)
        'objDerived.cmd.Parameters.AddWithValue("@Disposed", Disposed)
        objDerived.cmd.Parameters.AddWithValue("@EOQ", EOQ)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaveStock", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
        objDerived.cmd.Parameters.AddWithValue("@ItemPackageId", ItemPackageId)
        objDerived.cmd.Parameters.AddWithValue("@BatchNo", BatchNo)
        objDerived.cmd.Parameters.AddWithValue("@LotNo", LotNo)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Dispensed", Dispensed)
        'objDerived.cmd.Parameters.AddWithValue("@Returned", Returned)
        'objDerived.cmd.Parameters.AddWithValue("@Disposed", Disposed)
        objDerived.cmd.Parameters.AddWithValue("@EOQ", EOQ)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaveStock", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
