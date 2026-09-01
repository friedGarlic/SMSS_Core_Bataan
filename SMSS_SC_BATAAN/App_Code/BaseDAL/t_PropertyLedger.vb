Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_PropertyLedger
    Inherits BaseDLL.BaseDAL
#Region "property_ledger"

    Private pLedger_ID As Long
    Public Property Ledger_ID() As Long
        Get
            Return pLedger_ID
        End Get
        Set(ByVal value As Long)
            pLedger_ID = value
        End Set
    End Property

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
        End Set
    End Property

    Private pSerialNo As String
    Public Property SerialNo() As String
        Get
            Return pSerialNo
        End Get
        Set(ByVal value As String)
            pSerialNo = value
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

    Private pDebitQty As Integer
    Public Property DebitQty() As Integer
        Get
            Return pDebitQty
        End Get
        Set(ByVal value As Integer)
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

    Private pCreditQty As Integer
    Public Property CreditQty() As Integer
        Get
            Return pCreditQty
        End Get
        Set(ByVal value As Integer)
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

    Private pBalanceQty As Integer
    Public Property BalanceQty() As Integer
        Get
            Return pBalanceQty
        End Get
        Set(ByVal value As Integer)
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

    Private pProperty_ID As Long
    Public Property Property_ID() As Long
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Long)
            pProperty_ID = value
        End Set
    End Property




#End Region


    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Ledger_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@dDate", dDate)
        objDerived.cmd.Parameters.AddWithValue("@Trans_Type", Trans_Type)
        objDerived.cmd.Parameters.AddWithValue("@Ref", Ref)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
        objDerived.cmd.Parameters.AddWithValue("@Department", Department)
        objDerived.cmd.Parameters.AddWithValue("@Position", Position)
        objDerived.cmd.Parameters.AddWithValue("@AcceptedBy", AcceptedBy)
        objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
        objDerived.cmd.Parameters.AddWithValue("@DebitQty", DebitQty)
        objDerived.cmd.Parameters.AddWithValue("@DebitUnit", DebitUnit)
        objDerived.cmd.Parameters.AddWithValue("@DebitCost", DebitCost)
        objDerived.cmd.Parameters.AddWithValue("@CreditQty", CreditQty)
        objDerived.cmd.Parameters.AddWithValue("@CreditUnit", CreditUnit)
        objDerived.cmd.Parameters.AddWithValue("@CreditCost", CreditCost)
        objDerived.cmd.Parameters.AddWithValue("@BalanceQty", BalanceQty)
        objDerived.cmd.Parameters.AddWithValue("@BalanceUnit", BalanceUnit)
        objDerived.cmd.Parameters.AddWithValue("@BalanceCost", BalanceCost)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[Save_TbProperty_Ledger]", CommandType.StoredProcedure, Nothing)
    End Function
    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Ledger_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@dDate", dDate)
        objDerived.cmd.Parameters.AddWithValue("@Trans_Type", Trans_Type)
        objDerived.cmd.Parameters.AddWithValue("@Ref", Ref)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)
        objDerived.cmd.Parameters.AddWithValue("@Department", Department)
        objDerived.cmd.Parameters.AddWithValue("@Position", Position)
        objDerived.cmd.Parameters.AddWithValue("@AcceptedBy", AcceptedBy)
        objDerived.cmd.Parameters.AddWithValue("@InspectedBy", InspectedBy)
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
        i = objDerived.Execute("@CurrID", "[AMS].[Save_TbProperty_Ledger]", CommandType.StoredProcedure, Nothing)
    End Function
End Class
