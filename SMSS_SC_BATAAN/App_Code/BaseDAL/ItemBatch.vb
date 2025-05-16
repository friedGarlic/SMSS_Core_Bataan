Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ItemBatch

    Inherits BaseDLL.BaseDAL
#Region "property"

    Private pItemBatchId As Integer
    Public Property ItemBatchId() As Integer
        Get
            Return pItemBatchId
        End Get
        Set(ByVal value As Integer)
            pItemBatchId = value
        End Set
    End Property

    Private pStockId As Integer
    Public Property StockId() As Integer
        Get
            Return pStockId
        End Get
        Set(ByVal value As Integer)
            pStockId = value
        End Set
    End Property
    Private pDeliveryDate As DateTime
    Public Property DeliveryDate() As DateTime
        Get
            Return pDeliveryDate
        End Get
        Set(ByVal value As DateTime)
            pDeliveryDate = value
        End Set
    End Property
    Private pSellingPrice As Decimal
    Public Property SellingPrice() As Decimal
        Get
            Return pSellingPrice
        End Get
        Set(ByVal value As Decimal)
            pSellingPrice = value
        End Set
    End Property

    Private pActualPrice As Decimal
    Public Property ActualPrice() As Decimal
        Get
            Return pActualPrice
        End Get
        Set(ByVal value As Decimal)
            pActualPrice = value
        End Set
    End Property
    Private pExpirationDate As DateTime
    Public Property ExpirationDate() As DateTime
        Get
            Return pExpirationDate
        End Get
        Set(ByVal value As DateTime)
            pExpirationDate = value
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

#End Region


    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            ItemBatchId = IIf(IsDBNull(rd("ItemBatchId")), 0, rd("ItemBatchId"))
            StockId = IIf(IsDBNull(rd("StockId")), 0, rd("StockId"))
            DeliveryDate = IIf(IsDBNull(rd("DeliveryDate")), "", rd("DeliveryDate"))
            SellingPrice = IIf(IsDBNull(rd("SellingPrice")), 0, rd("SellingPrice"))
            ActualPrice = IIf(IsDBNull(rd("ActualPrice")), 0, rd("ActualPrice"))
            ExpirationDate = IIf(IsDBNull(rd("ExpirationDate")), "", rd("ExpirationDate"))
            Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function Save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ItemBatchId", 0)
        objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
        objDerived.cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice)
        objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
        objDerived.cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaveItemBatch", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ItemBatchId", ItemBatchId)
        objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
        objDerived.cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice)
        objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
        objDerived.cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "MED.SaveItemBatch", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
