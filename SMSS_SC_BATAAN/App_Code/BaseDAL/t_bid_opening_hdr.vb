Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_bid_opening_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pbid_opening_hdr_id As Long
    Public Property bid_opening_hdr_id() As Long
        Get
            Return pbid_opening_hdr_id
        End Get
        Set(ByVal value As Long)
            pbid_opening_hdr_id = value
        End Set
    End Property

    Private ppre_procurement_hdr_id As Long
    Public Property pre_procurement_hdr_id() As Long
        Get
            Return ppre_procurement_hdr_id
        End Get
        Set(ByVal value As Long)
            ppre_procurement_hdr_id = value
        End Set
    End Property

    Private pSupplier_Id As Long
    Public Property Supplier_Id() As Long
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Long)
            pSupplier_Id = value
        End Set
    End Property

    Private pamount As Decimal
    Public Property amount() As Decimal
        Get
            Return pamount
        End Get
        Set(ByVal value As Decimal)
            pamount = value
        End Set
    End Property

    Private pcalculatedAmount As Decimal
    Public Property calculatedAmount() As Decimal
        Get
            Return pcalculatedAmount
        End Get
        Set(ByVal value As Decimal)
            pcalculatedAmount = value
        End Set
    End Property

    Private pexamination_bid As Boolean
    Public Property examination_bid() As Boolean
        Get
            Return pexamination_bid
        End Get
        Set(ByVal value As Boolean)
            pexamination_bid = value
        End Set
    End Property

    Private pceiling_price As Boolean
    Public Property ceiling_price() As Boolean
        Get
            Return pceiling_price
        End Get
        Set(ByVal value As Boolean)
            pceiling_price = value
        End Set
    End Property

    Private pisPostQualification As Boolean
    Public Property isPostQualification() As Boolean
        Get
            Return pisPostQualification
        End Get
        Set(ByVal value As Boolean)
            pisPostQualification = value
        End Set
    End Property

    Private pisWinner As Boolean
    Public Property isWinner() As Boolean
        Get
            Return pisWinner
        End Get
        Set(ByVal value As Boolean)
            pisWinner = value
        End Set
    End Property

    Private pisCalculated As Boolean
    Public Property isCalculated() As Boolean
        Get
            Return pisCalculated
        End Get
        Set(ByVal value As Boolean)
            pisCalculated = value
        End Set
    End Property

    Private pBidSecurity_id As Long
    Public Property BidSecurity_id() As Long
        Get
            Return pBidSecurity_id
        End Get
        Set(ByVal value As Long)
            pBidSecurity_id = value
        End Set
    End Property

    Private pBankName As String
    Public Property BankName() As String
        Get
            Return pBankName
        End Get
        Set(ByVal value As String)
            pBankName = value
        End Set
    End Property

    Private pNumber As String
    Public Property Number() As String
        Get
            Return pNumber
        End Get
        Set(ByVal value As String)
            pNumber = value
        End Set
    End Property

    Private pValidityPeriod As Integer
    Public Property ValidityPeriod() As Integer
        Get
            Return pValidityPeriod
        End Get
        Set(ByVal value As Integer)
            pValidityPeriod = value
        End Set
    End Property

    Private pBidSecurityAmount As Decimal
    Public Property BidSecurityAmount() As Decimal
        Get
            Return pBidSecurityAmount
        End Get
        Set(ByVal value As Decimal)
            pBidSecurityAmount = value
        End Set
    End Property

    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

    Private pstatus As String
    Public Property status() As String
        Get
            Return pstatus
        End Get
        Set(ByVal value As String)
            pstatus = value
        End Set
    End Property

    Private pwithOR As Boolean
    Public Property withOR() As Boolean
        Get
            Return pwithOR
        End Get
        Set(ByVal value As Boolean)
            pwithOR = value
        End Set
    End Property

    Private pORID As Long
    Public Property ORID() As Long
        Get
            Return pORID
        End Get
        Set(ByVal value As Long)
            pORID = value
        End Set
    End Property









#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@bid_opening_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@calculatedAmount", calculatedAmount)
        objDerived.cmd.Parameters.AddWithValue("@examination_bid", examination_bid)
        objDerived.cmd.Parameters.AddWithValue("@ceiling_price", ceiling_price)
        objDerived.cmd.Parameters.AddWithValue("@isPostQualification", isPostQualification)
        objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
        objDerived.cmd.Parameters.AddWithValue("@isCalculated", isCalculated)
        objDerived.cmd.Parameters.AddWithValue("@BidSecurity_id", BidSecurity_id)
        objDerived.cmd.Parameters.AddWithValue("@BankName", BankName)
        objDerived.cmd.Parameters.AddWithValue("@Number", Number)
        objDerived.cmd.Parameters.AddWithValue("@ValidityPeriod", ValidityPeriod)
        objDerived.cmd.Parameters.AddWithValue("@BidSecurityAmount", BidSecurityAmount)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@withOR", withOR)
        objDerived.cmd.Parameters.AddWithValue("@ORID", ORID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_bid_opening_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function update() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@bid_opening_hdr_id", bid_opening_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@calculatedAmount", calculatedAmount)
        objDerived.cmd.Parameters.AddWithValue("@examination_bid", examination_bid)
        objDerived.cmd.Parameters.AddWithValue("@ceiling_price", ceiling_price)
        objDerived.cmd.Parameters.AddWithValue("@isPostQualification", isPostQualification)
        objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
        objDerived.cmd.Parameters.AddWithValue("@isCalculated", isCalculated)
        objDerived.cmd.Parameters.AddWithValue("@BidSecurity_id", BidSecurity_id)
        objDerived.cmd.Parameters.AddWithValue("@BankName", BankName)
        objDerived.cmd.Parameters.AddWithValue("@Number", Number)
        objDerived.cmd.Parameters.AddWithValue("@ValidityPeriod", ValidityPeriod)
        objDerived.cmd.Parameters.AddWithValue("@BidSecurityAmount", BidSecurityAmount)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@withOR", withOR)
        objDerived.cmd.Parameters.AddWithValue("@ORID", ORID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_bid_opening_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
