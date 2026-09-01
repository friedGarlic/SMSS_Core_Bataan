Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class Supplies_Stock
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pStockID As Long
    Public Property StockID() As Long
        Get
            Return pStockID
        End Get
        Set(ByVal value As Long)
            pStockID = value
        End Set
    End Property

    Private pStockDate As Date
    Public Property StockDate() As Date
        Get
            Return pStockDate
        End Get
        Set(ByVal value As Date)
            pStockDate = value
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

    Private pQty As Decimal
    Public Property Qty() As Decimal
        Get
            Return pQty
        End Get
        Set(ByVal value As Decimal)
            pQty = value
        End Set
    End Property

    Private pBalance As Decimal
    Public Property Balance() As Decimal
        Get
            Return pBalance
        End Get
        Set(ByVal value As Decimal)
            pBalance = value
        End Set
    End Property

    Private pIssuance As Decimal
    Public Property Issuance() As Decimal
        Get
            Return pIssuance
        End Get
        Set(ByVal value As Decimal)
            pIssuance = value
        End Set
    End Property

    Private pCost As Decimal
    Public Property Cost() As Decimal
        Get
            Return pCost
        End Get
        Set(ByVal value As Decimal)
            pCost = value
        End Set
    End Property

    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property

    Private pFunction_ID As Long
    Public Property Function_ID() As Long
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Long)
            pFunction_ID = value
        End Set
    End Property

    Private pProject_ID As Long
    Public Property Project_ID() As Long
        Get
            Return pProject_ID
        End Get
        Set(ByVal value As Long)
            pProject_ID = value
        End Set
    End Property

    Private pProgram_id As Long
    Public Property Program_id() As Long
        Get
            Return pProgram_id
        End Get
        Set(ByVal value As Long)
            pProgram_id = value
        End Set
    End Property

    Private pF_ID As Integer
    Public Property F_ID() As Integer
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Integer)
            pF_ID = value
        End Set
    End Property

    Private pAIRDtl_ID As Long
    Public Property AIRDtl_ID() As Long
        Get
            Return pAIRDtl_ID
        End Get
        Set(ByVal value As Long)
            pAIRDtl_ID = value
        End Set
    End Property

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property

    Private pBatch As String
    Public Property Batch() As String
        Get
            Return pBatch
        End Get
        Set(ByVal value As String)
            pBatch = value
        End Set
    End Property

    Private pExpiration_Date As Date
    Public Property Expiration_Date() As Date
        Get
            Return pExpiration_Date
        End Get
        Set(ByVal value As Date)
            pExpiration_Date = value
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

    Private pmab As Decimal
    Public Property mab() As Decimal
        Get
            Return pmab
        End Get
        Set(ByVal value As Decimal)
            pmab = value
        End Set
    End Property

    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
        End Set
    End Property

    Private pReceived_ID As Long
    Public Property Received_ID() As Long
        Get
            Return pReceived_ID
        End Get
        Set(ByVal value As Long)
            pReceived_ID = value
        End Set
    End Property

    Private pWarehouseid As Long
    Public Property Warehouseid() As Long
        Get
            Return pWarehouseid
        End Get
        Set(ByVal value As Long)
            pWarehouseid = value
        End Set
    End Property

    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property

    Private pReorderPt As Long
    Public Property ReorderPt() As Long
        Get
            Return pReorderPt
        End Get
        Set(ByVal value As Long)
            pReorderPt = value
        End Set
    End Property
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@StockID", 0)
        objDerived.cmd.Parameters.AddWithValue("@StockDate", StockDate)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Balance", Balance)
        objDerived.cmd.Parameters.AddWithValue("@Issuance", Issuance)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
        objDerived.cmd.Parameters.AddWithValue("@Expiration_Date", Expiration_Date)
        objDerived.cmd.Parameters.AddWithValue("@Location", Location)
        objDerived.cmd.Parameters.AddWithValue("@mab", mab)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@warehouse_id", Warehouseid)
        objDerived.cmd.Parameters.AddWithValue("@ReorderPt", ReorderPt)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Stock", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@StockID", StockID)
        objDerived.cmd.Parameters.AddWithValue("@StockDate", StockDate)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Balance", Balance)
        objDerived.cmd.Parameters.AddWithValue("@Issuance", Issuance)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
        objDerived.cmd.Parameters.AddWithValue("@Expiration_Date", Expiration_Date)
        objDerived.cmd.Parameters.AddWithValue("@Location", Location)
        objDerived.cmd.Parameters.AddWithValue("@mab", mab)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Stock", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
