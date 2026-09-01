Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class t_supplies_hdr
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

    Private pStockDate As DateTime
    Public Property StockDate() As DateTime
        Get
            Return pStockDate
        End Get
        Set(ByVal value As DateTime)
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

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
        End Set
    End Property

    Private pBalance As Integer
    Public Property Balance() As Integer
        Get
            Return pBalance
        End Get
        Set(ByVal value As Integer)
            pBalance = value
        End Set
    End Property

    Private pIssuance As Integer
    Public Property Issuance() As Integer
        Get
            Return pIssuance
        End Get
        Set(ByVal value As Integer)
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

    Private pmab As Decimal
    Public Property mab() As Decimal
        Get
            Return pmab
        End Get
        Set(ByVal value As Decimal)
            pmab = value
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
        objDerived.cmd.Parameters.AddWithValue("@mab", mab)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Stock", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@StockID", pStockID)
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
        objDerived.cmd.Parameters.AddWithValue("@mab", mab)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Stock", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
