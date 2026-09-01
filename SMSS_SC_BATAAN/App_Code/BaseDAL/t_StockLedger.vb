Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_StockLedger
    Inherits BaseDLL.BaseDAL
#Region "Stock_ledger"

    Private pStockLedger_ID As Long
    Public Property StockLedger_ID() As Long
        Get
            Return pStockLedger_ID
        End Get
        Set(ByVal value As Long)
            pStockLedger_ID = value
        End Set
    End Property

    Private pStockID As Long
    Public Property StockID() As Long
        Get
            Return pStockID
        End Get
        Set(ByVal value As Long)
            pStockID = value
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

    Private pdDate As Date
    Public Property dDate() As Date
        Get
            Return pdDate
        End Get
        Set(ByVal value As Date)
            pdDate = value
        End Set
    End Property

    Private pTrans_Type As String
    Public Property Trans_Type() As String
        Get
            Return pTrans_Type
        End Get
        Set(ByVal value As String)
            pTrans_Type = value
        End Set
    End Property

    Private pRef As String
    Public Property Ref() As String
        Get
            Return pRef
        End Get
        Set(ByVal value As String)
            pRef = value
        End Set
    End Property

    Private pAccountablePerson As String
    Public Property AccountablePerson() As String
        Get
            Return pAccountablePerson
        End Get
        Set(ByVal value As String)
            pAccountablePerson = value
        End Set
    End Property

    Private pDepartment As String
    Public Property Department() As String
        Get
            Return pDepartment
        End Get
        Set(ByVal value As String)
            pDepartment = value
        End Set
    End Property

    Private pPosition As String
    Public Property Position() As String
        Get
            Return pPosition
        End Get
        Set(ByVal value As String)
            pPosition = value
        End Set
    End Property

    Private pAcceptedBy As String
    Public Property AcceptedBy() As String
        Get
            Return pAcceptedBy
        End Get
        Set(ByVal value As String)
            pAcceptedBy = value
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

    Private pReceivedBy As String
    Public Property ReceivedBy() As String
        Get
            Return pReceivedBy
        End Get
        Set(ByVal value As String)
            pReceivedBy = value
        End Set
    End Property

    Private pDebitQty As Decimal
    Public Property DebitQty() As Decimal
        Get
            Return pDebitQty
        End Get
        Set(ByVal value As Decimal)
            pDebitQty = value
        End Set
    End Property

    Private pDebitUnit As String
    Public Property DebitUnit() As String
        Get
            Return pDebitUnit
        End Get
        Set(ByVal value As String)
            pDebitUnit = value
        End Set
    End Property

    Private pDebitCost As Decimal
    Public Property DebitCost() As Decimal
        Get
            Return pDebitCost
        End Get
        Set(ByVal value As Decimal)
            pDebitCost = value
        End Set
    End Property

    Private pCreditQty As Decimal
    Public Property CreditQty() As Decimal
        Get
            Return pCreditQty
        End Get
        Set(ByVal value As Decimal)
            pCreditQty = value
        End Set
    End Property

    Private pCreditUnit As String
    Public Property CreditUnit() As String
        Get
            Return pCreditUnit
        End Get
        Set(ByVal value As String)
            pCreditUnit = value
        End Set
    End Property

    Private pCreditCost As Decimal
    Public Property CreditCost() As Decimal
        Get
            Return pCreditCost
        End Get
        Set(ByVal value As Decimal)
            pCreditCost = value
        End Set
    End Property

    Private pBalanceQty As Decimal
    Public Property BalanceQty() As Decimal
        Get
            Return pBalanceQty
        End Get
        Set(ByVal value As Decimal)
            pBalanceQty = value
        End Set
    End Property

    Private pBalanceUnit As String
    Public Property BalanceUnit() As String
        Get
            Return pBalanceUnit
        End Get
        Set(ByVal value As String)
            pBalanceUnit = value
        End Set
    End Property

    Private pBalanceCost As Decimal
    Public Property BalanceCost() As Decimal
        Get
            Return pBalanceCost
        End Get
        Set(ByVal value As Decimal)
            pBalanceCost = value
        End Set
    End Property

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@StockLedger_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@StockID", StockID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@dDate", dDate)
        objDerived.cmd.Parameters.AddWithValue("@Trans_Type", Trans_Type)
        objDerived.cmd.Parameters.AddWithValue("@Ref", Ref)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
        objDerived.cmd.Parameters.AddWithValue("@Department", Department)
        objDerived.cmd.Parameters.AddWithValue("@Position", Position)
        objDerived.cmd.Parameters.AddWithValue("@AcceptedBy", AcceptedBy)
        objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
        objDerived.cmd.Parameters.AddWithValue("@ReceivedBy", ReceivedBy)
        objDerived.cmd.Parameters.AddWithValue("@DebitQty", DebitQty)
        objDerived.cmd.Parameters.AddWithValue("@DebitUnit", DebitUnit)
        objDerived.cmd.Parameters.AddWithValue("@DebitCost", DebitCost)
        objDerived.cmd.Parameters.AddWithValue("@CreditQty", CreditQty)
        objDerived.cmd.Parameters.AddWithValue("@CreditUnit", CreditUnit)
        objDerived.cmd.Parameters.AddWithValue("@CreditCost", CreditCost)
        objDerived.cmd.Parameters.AddWithValue("@BalanceQty", BalanceQty)
        objDerived.cmd.Parameters.AddWithValue("@BalanceUnit", BalanceUnit)
        objDerived.cmd.Parameters.AddWithValue("@BalanceCost", BalanceCost)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[Save_TbStock_Ledger]", CommandType.StoredProcedure, Nothing)
    End Function
End Class
