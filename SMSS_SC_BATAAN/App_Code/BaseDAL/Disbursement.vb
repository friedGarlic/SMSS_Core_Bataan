Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class Disbursement
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pDisbursementID As Integer
    Public Property DisbursementID() As Integer
        Get
            Return pDisbursementID
        End Get
        Set(ByVal value As Integer)
            pDisbursementID = value
        End Set
    End Property

    Private pPO_No As String
    Public Property PO_No() As String
        Get
            Return pPO_No
        End Get
        Set(ByVal value As String)
            pPO_No = value
        End Set
    End Property

    Private pSupplier_Id As Integer
    Public Property Supplier_Id() As Integer
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Integer)
            pSupplier_Id = value
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

    Private pDisbursementNo As String
    Public Property DisbursementNo() As String
        Get
            Return pDisbursementNo
        End Get
        Set(ByVal value As String)
            pDisbursementNo = value
        End Set
    End Property

    Private pModePayment As String
    Public Property ModePayment() As String
        Get
            Return pModePayment
        End Get
        Set(ByVal value As String)
            pModePayment = value
        End Set
    End Property

    Private pContractPrice As Decimal
    Public Property ContractPrice() As Decimal
        Get
            Return pContractPrice
        End Get
        Set(ByVal value As Decimal)
            pContractPrice = value
        End Set
    End Property

    Private pTaxtype As String
    Public Property Taxtype() As String
        Get
            Return pTaxtype
        End Get
        Set(ByVal value As String)
            pTaxtype = value
        End Set
    End Property

    Private pIncomeTax As Decimal
    Public Property IncomeTax() As Decimal
        Get
            Return pIncomeTax
        End Get
        Set(ByVal value As Decimal)
            pIncomeTax = value
        End Set
    End Property

    Private ptax As Decimal
    Public Property tax() As Decimal
        Get
            Return ptax
        End Get
        Set(ByVal value As Decimal)
            ptax = value
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

    Private pCertifiedAccountant As Boolean
    Public Property CertifiedAccountant() As Boolean
        Get
            Return pCertifiedAccountant
        End Get
        Set(ByVal value As Boolean)
            pCertifiedAccountant = value
        End Set
    End Property

    Private pAlobs As Boolean
    Public Property Alobs() As Boolean
        Get
            Return pAlobs
        End Get
        Set(ByVal value As Boolean)
            pAlobs = value
        End Set
    End Property

    Private pSupDoc As Boolean
    Public Property SupDoc() As Boolean
        Get
            Return pSupDoc
        End Get
        Set(ByVal value As Boolean)
            pSupDoc = value
        End Set
    End Property

    Private pCertifiedFund As Boolean
    Public Property CertifiedFund() As Boolean
        Get
            Return pCertifiedFund
        End Get
        Set(ByVal value As Boolean)
            pCertifiedFund = value
        End Set
    End Property

    Private pCityAccountant As String
    Public Property CityAccountant() As String
        Get
            Return pCityAccountant
        End Get
        Set(ByVal value As String)
            pCityAccountant = value
        End Set
    End Property

    Private pCityTreasurer As String
    Public Property CityTreasurer() As String
        Get
            Return pCityTreasurer
        End Get
        Set(ByVal value As String)
            pCityTreasurer = value
        End Set
    End Property

    Private pAgencyHead As String
    Public Property AgencyHead() As String
        Get
            Return pAgencyHead
        End Get
        Set(ByVal value As String)
            pAgencyHead = value
        End Set
    End Property

    Private pNameReceived As String
    Public Property NameReceived() As String
        Get
            Return pNameReceived
        End Get
        Set(ByVal value As String)
            pNameReceived = value
        End Set
    End Property

    Private pApprovedPayment As Boolean
    Public Property ApprovedPayment() As Boolean
        Get
            Return pApprovedPayment
        End Get
        Set(ByVal value As Boolean)
            pApprovedPayment = value
        End Set
    End Property

    Private pCertifiedPayment As Boolean
    Public Property CertifiedPayment() As Boolean
        Get
            Return pCertifiedPayment
        End Get
        Set(ByVal value As Boolean)
            pCertifiedPayment = value
        End Set
    End Property

    Private pDate As DateTime
    Public Property aDate() As DateTime
        Get
            Return pDate
        End Get
        Set(ByVal value As DateTime)
            pDate = value
        End Set
    End Property

    Private pdeptid As Integer
    Public Property deptid() As Integer
        Get
            Return pdeptid
        End Get
        Set(ByVal value As Integer)
            pdeptid = value
        End Set
    End Property

    Private poffice As String
    Public Property office() As String
        Get
            Return poffice
        End Get
        Set(ByVal value As String)
            poffice = value
        End Set
    End Property










#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.DisbursementID = IIf(IsDBNull(rd("DisbursementID")), 0, rd("DisbursementID"))
            Me.PO_No = IIf(IsDBNull(rd("PO_No")), "", rd("PO_No"))
            Me.Supplier_Id = IIf(IsDBNull(rd("Supplier_Id")), 0, rd("Supplier_Id"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.DisbursementNo = IIf(IsDBNull(rd("DisbursementNo")), "", rd("DisbursementNo"))
            Me.ModePayment = IIf(IsDBNull(rd("ModePayment")), "", rd("ModePayment"))
            Me.ContractPrice = IIf(IsDBNull(rd("ContractPrice")), 0.0, rd("ContractPrice"))
            Me.Taxtype = IIf(IsDBNull(rd("Taxtype")), "", rd("Taxtype"))
            Me.IncomeTax = IIf(IsDBNull(rd("IncomeTax")), 0.0, rd("IncomeTax"))
            Me.tax = IIf(IsDBNull(rd("tax")), 0.0, rd("tax"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))
            Me.CertifiedAccountant = IIf(IsDBNull(rd("CertifiedAccountant")), 0, rd("CertifiedAccountant"))
            Me.Alobs = IIf(IsDBNull(rd("Alobs")), 0, rd("Alobs"))
            Me.SupDoc = IIf(IsDBNull(rd("SupDoc")), 0, rd("SupDoc"))
            Me.CertifiedFund = IIf(IsDBNull(rd("CertifiedFund")), 0, rd("CertifiedFund"))
            Me.CityAccountant = IIf(IsDBNull(rd("CityAccountant")), "", rd("CityAccountant"))
            Me.CityTreasurer = IIf(IsDBNull(rd("CityTreasurer")), "", rd("CityTreasurer"))
            Me.AgencyHead = IIf(IsDBNull(rd("AgencyHead")), "", rd("AgencyHead"))
            Me.NameReceived = IIf(IsDBNull(rd("NameReceived")), "", rd("NameReceived"))
            Me.ApprovedPayment = IIf(IsDBNull(rd("ApprovedPayment")), 0, rd("ApprovedPayment"))
            Me.CertifiedPayment = IIf(IsDBNull(rd("CertifiedPayment")), 0, rd("CertifiedPayment"))
            Me.aDate = IIf(IsDBNull(rd("Date")), "", rd("Date"))
            Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))
            Me.office = IIf(IsDBNull(rd("office")), "", rd("office"))





        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function saveDisbursement() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DisbursementID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@DisbursementNo", DisbursementNo)
        objDerived.cmd.Parameters.AddWithValue("@ModePayment", ModePayment)
        objDerived.cmd.Parameters.AddWithValue("@ContractPrice", ContractPrice)
        objDerived.cmd.Parameters.AddWithValue("@Taxtype", Taxtype)
        objDerived.cmd.Parameters.AddWithValue("@IncomeTax", IncomeTax)
        objDerived.cmd.Parameters.AddWithValue("@tax", tax)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@CertifiedAccountant", CertifiedAccountant)
        objDerived.cmd.Parameters.AddWithValue("@Alobs", Alobs)
        objDerived.cmd.Parameters.AddWithValue("@SupDoc", SupDoc)
        objDerived.cmd.Parameters.AddWithValue("@CertifiedFund", CertifiedFund)
        objDerived.cmd.Parameters.AddWithValue("@CityAccountant", CityAccountant)
        objDerived.cmd.Parameters.AddWithValue("@CityTreasurer", CityTreasurer)
        objDerived.cmd.Parameters.AddWithValue("@AgencyHead", AgencyHead)
        objDerived.cmd.Parameters.AddWithValue("@NameReceived", NameReceived)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedPayment", ApprovedPayment)
        objDerived.cmd.Parameters.AddWithValue("@Date", aDate)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@office", office)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Disbursement", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Sub saveEditDisbursement()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DisbursementID", DisbursementID)
        objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@DisbursementNo", DisbursementNo)
        objDerived.cmd.Parameters.AddWithValue("@ModePayment", ModePayment)
        objDerived.cmd.Parameters.AddWithValue("@ContractPrice", ContractPrice)
        objDerived.cmd.Parameters.AddWithValue("@Taxtype", Taxtype)
        objDerived.cmd.Parameters.AddWithValue("@IncomeTax", IncomeTax)
        objDerived.cmd.Parameters.AddWithValue("@tax", tax)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@CertifiedAccountant", CertifiedAccountant)
        objDerived.cmd.Parameters.AddWithValue("@Alobs", Alobs)
        objDerived.cmd.Parameters.AddWithValue("@SupDoc", SupDoc)
        objDerived.cmd.Parameters.AddWithValue("@CertifiedFund", CertifiedFund)
        objDerived.cmd.Parameters.AddWithValue("@CityAccountant", CityAccountant)
        objDerived.cmd.Parameters.AddWithValue("@CityTreasurer", CityTreasurer)
        objDerived.cmd.Parameters.AddWithValue("@AgencyHead", AgencyHead)
        objDerived.cmd.Parameters.AddWithValue("@NameReceived", NameReceived)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedPayment", ApprovedPayment)
        objDerived.cmd.Parameters.AddWithValue("@CertifiedPayment", CertifiedPayment)
        objDerived.cmd.Parameters.AddWithValue("@Date", aDate)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_Disbursement", CommandType.StoredProcedure, Nothing)
    End Sub
End Class
