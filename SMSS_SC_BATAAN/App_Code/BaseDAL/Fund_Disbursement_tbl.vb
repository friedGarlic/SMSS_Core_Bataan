Imports System
Imports Microsoft.VisualBasic

Public Class Fund_Disbursement_tbl
    Inherits BaseDLL.BaseDAL
    Private pFD_ID As Integer
    Public Property FD_ID() As Integer
        Get
            Return pFD_ID
        End Get
        Set(ByVal value As Integer)
            pFD_ID = value
        End Set
    End Property

    Private pAccountID As Integer
    Public Property AccountID() As Integer
        Get
            Return pAccountID
        End Get
        Set(ByVal value As Integer)
            pAccountID = value
        End Set
    End Property

    Private pRegionID As Integer
    Public Property RegionID() As Integer
        Get
            Return pRegionID
        End Get
        Set(ByVal value As Integer)
            pRegionID = value
        End Set
    End Property

    Private pDate As DateTime
    Public Property sDate() As DateTime
        Get
            Return pDate
        End Get
        Set(ByVal value As DateTime)
            pDate = value
        End Set
    End Property

    Private pParticulars As String
    Public Property Particulars() As String
        Get
            Return pParticulars
        End Get
        Set(ByVal value As String)
            pParticulars = value
        End Set
    End Property

    Private pisDisbursement As Boolean
    Public Property isDisbursement() As Boolean
        Get
            Return pisDisbursement
        End Get
        Set(ByVal value As Boolean)
            pisDisbursement = value
        End Set
    End Property

    Private pAmount As Decimal
    Public Property Amount() As Decimal
        Get
            Return pAmount
        End Get
        Set(ByVal value As Decimal)
            pAmount = value
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

    Private pReference As String
    Public Property Reference() As String
        Get
            Return pReference
        End Get
        Set(ByVal value As String)
            pReference = value
        End Set
    End Property

    Private pDisbursementID As String
    Public Property DisbursementID() As String
        Get
            Return pDisbursementID
        End Get
        Set(ByVal value As String)
            pDisbursementID = value
        End Set
    End Property
    Private pDDate As DateTime
    Public Property DDate() As DateTime
        Get
            Return pDDate
        End Get
        Set(ByVal value As DateTime)
            pDDate = value
        End Set
    End Property
    Private pSuppName As String
    Public Property SuppName() As String
        Get
            Return pSuppName
        End Get
        Set(ByVal value As String)
            pSuppName = value
        End Set
    End Property
    Private pOfficeID As Integer
    Public Property OfficeID() As Integer
        Get
            Return pOfficeID
        End Get
        Set(ByVal value As Integer)
            pOfficeID = value
        End Set
    End Property

    Private pProvID As Integer
    Public Property ProvID() As Integer
        Get
            Return pProvID
        End Get
        Set(ByVal value As Integer)
            pProvID = value
        End Set
    End Property
    Private pDeptDesc As String
    Public Property DeptDesc() As String
        Get
            Return pDeptDesc
        End Get
        Set(ByVal value As String)
            pDeptDesc = value
        End Set
    End Property
    Private pCheckno As String
    Public Property Checkno() As String
        Get
            Return pCheckno
        End Get
        Set(ByVal value As String)
            pCheckno = value
        End Set
    End Property


    Private pisCash As Boolean
    Public Property isCash() As Boolean
        Get
            Return pisCash
        End Get
        Set(ByVal value As Boolean)
            pisCash = value
        End Set
    End Property
    Private pisfunddisbursement As Boolean
    Public Property isfunddisbursement() As Boolean
        Get
            Return pisfunddisbursement
        End Get
        Set(ByVal value As Boolean)
            pisfunddisbursement = value
        End Set
    End Property
    Private pisdone As Boolean
    Public Property isdone() As Boolean
        Get
            Return pisdone
        End Get
        Set(ByVal value As Boolean)
            pisdone = value
        End Set
    End Property
    Private pRO As String
    Public Property RO() As String
        Get
            Return pRO
        End Get
        Set(ByVal value As String)
            pRO = value
        End Set
    End Property

    Private pNPay As String
    Public Property NPay() As String
        Get
            Return pNPay
        End Get
        Set(ByVal value As String)
            pNPay = value
        End Set
    End Property

    Private pBIR As Decimal
    Public Property BIR() As Decimal
        Get
            Return pBIR
        End Get
        Set(ByVal value As Decimal)
            pBIR = value
        End Set
    End Property
    Private pPerCentIraShare As String
    Public Property PerCentIraShare() As String
        Get
            Return pPerCentIraShare
        End Get
        Set(ByVal value As String)
            pPerCentIraShare = value
        End Set
    End Property

    'Private piscancelled As Boolean
    'Public Property iscancelled() As Boolean
    '    Get
    '        Return piscancelled
    '    End Get
    '    Set(ByVal value As Boolean)
    '        piscancelled = value
    '    End Set
    'End Property

    Private pRSiD As Long
    Public Property RSiD() As Long
        Get
            Return pRSiD
        End Get
        Set(ByVal value As Long)
            pRSiD = value
        End Set
    End Property

    Private pF_ID As Long
    Public Property F_ID() As Long
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Long)
            pF_ID = value
        End Set
    End Property

    Private pTD_ID As Long
    Public Property TD_ID() As Long
        Get
            Return pTD_ID
        End Get
        Set(ByVal value As Long)
            pTD_ID = value
        End Set
    End Property

    Private piscollected As Boolean
    Public Property iscollected() As Boolean
        Get
            Return piscollected
        End Get
        Set(ByVal value As Boolean)
            piscollected = value
        End Set
    End Property

    Private pMCHdr_ID As Integer
    Public Property MCHdr_ID() As Integer
        Get
            Return pMCHdr_ID
        End Get
        Set(ByVal value As Integer)
            pMCHdr_ID = value
        End Set
    End Property

    Private pDepositMaster_HdrID As Integer
    Public Property DepositMaster_HdrID() As Integer
        Get
            Return pDepositMaster_HdrID
        End Get
        Set(ByVal value As Integer)
            pDepositMaster_HdrID = value
        End Set
    End Property

    Private pMemoID As Long
    Public Property MemoID() As Long
        Get
            Return pMemoID
        End Get
        Set(ByVal value As Long)
            pMemoID = value
        End Set
    End Property

    Private pSystemUserId As String
    Public Property SystemUserId() As String
        Get
            Return pSystemUserId
        End Get
        Set(ByVal value As String)
            pSystemUserId = value
        End Set
    End Property

    Private pTableId As Integer
    Public Property TableId() As Integer
        Get
            Return pTableId
        End Get
        Set(ByVal value As Integer)
            pTableId = value
        End Set
    End Property


    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()
            FD_ID = IIf(IsDBNull(rd("FD_ID")), 0, rd("FD_ID"))
            AccountID = IIf(IsDBNull(rd("AccountID")), 0, rd("AccountID"))
            RegionID = IIf(IsDBNull(rd("RegionID")), 0, rd("RegionID"))
            sDate = IIf(IsDBNull(rd("sDate")), "", rd("sDate"))
            Particulars = IIf(IsDBNull(rd("Particulars")), "", rd("Particulars"))
            isDisbursement = IIf(IsDBNull(rd("isDisbursement")), 0, rd("isDisbursement"))
            Amount = IIf(IsDBNull(rd("Amount")), 0.0, rd("Amount"))
            Balance = IIf(IsDBNull(rd("Balance")), 0.0, rd("Balance"))
            Reference = IIf(IsDBNull(rd("Reference")), "", rd("Reference"))
            DisbursementID = IIf(IsDBNull(rd("DisbursementID")), 0, rd("DisbursementID"))
            DDate = IIf(IsDBNull(rd("DDate")), 0, rd("DDate"))
            ProvID = IIf(IsDBNull(rd("ProvID")), 0, rd("ProvID"))
            OfficeID = IIf(IsDBNull(rd("OfficeID")), 0, rd("OfficeID"))
            DeptDesc = IIf(IsDBNull(rd("DeptDesc")), 0, rd("DeptDesc"))
            Checkno = IIf(IsDBNull(rd("Checkno")), 0, rd("Checkno"))
            isCash = IIf(IsDBNull(rd("isCash")), 0, rd("isCash"))
            isfunddisbursement = IIf(IsDBNull(rd("isfunddisbursement")), 0, rd("isfunddisbursement"))
            isdone = IIf(IsDBNull(rd("isdone")), 0, rd("isdone"))
            RO = IIf(IsDBNull(rd("RO")), "", rd("RO"))
            NPay = IIf(IsDBNull(rd("NPay")), "", rd("NPay"))
            BIR = IIf(IsDBNull(rd("BIR")), 0.0, rd("BIR"))
            PerCentIraShare = IIf(IsDBNull(rd("PerCentIraShare")), "", rd("PerCentIraShare"))
            'iscancelled = IIf(IsDBNull(rd("iscancelled")), 0, rd("iscancelled"))
            RSiD = IIf(IsDBNull(rd("RSiD")), 0, rd("RSiD"))
            F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
            TD_ID = IIf(IsDBNull(rd("TD_ID")), 0, rd("TD_ID"))
            iscollected = IIf(IsDBNull(rd("iscollected")), 0, rd("iscollected"))
            MCHdr_ID = IIf(IsDBNull(rd("MCHdr_ID")), 0, rd("MCHdr_ID"))
            DepositMaster_HdrID = IIf(IsDBNull(rd("DepositMaster_HdrID")), 0, rd("DepositMaster_HdrID"))
            MemoID = IIf(IsDBNull(rd("MemoID")), 0, rd("MemoID"))
            SystemUserId = IIf(IsDBNull(rd("UserId")), 0, rd("UserId"))
            ' TableId = IIf(IsDBNull(rd("TableId")), 0, rd("TableId"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub SaveFund_Disbursement_tbl()
        'cmd.Parameters.AddWithValue("@FD_ID", FD_ID)
        cmd.Parameters.AddWithValue("@AccountID", AccountID)
        cmd.Parameters.AddWithValue("@RegionID", RegionID)
        cmd.Parameters.AddWithValue("@FDDate", sDate)
        cmd.Parameters.AddWithValue("@Particulars", Particulars)
        cmd.Parameters.AddWithValue("@isDisbursement", isDisbursement)
        cmd.Parameters.AddWithValue("@Amount", Amount)
        cmd.Parameters.AddWithValue("@Balance", Balance)
        cmd.Parameters.AddWithValue("@Reference", Reference)
        cmd.Parameters.AddWithValue("@DisbursementID", DisbursementID)
        cmd.Parameters.AddWithValue("@DDate", DDate)
        cmd.Parameters.AddWithValue("@ProvID", ProvID)
        cmd.Parameters.AddWithValue("@OfficeID", OfficeID)
        cmd.Parameters.AddWithValue("@DeptDesc", DeptDesc)
        cmd.Parameters.AddWithValue("@Checkno", Checkno)
        cmd.Parameters.AddWithValue("@isCash", isCash)
        cmd.Parameters.AddWithValue("@isfunddisbursement", isfunddisbursement)
        cmd.Parameters.AddWithValue("@isdone", isdone)
        cmd.Parameters.AddWithValue("@RO", RO)
        cmd.Parameters.AddWithValue("@NPay", NPay)
        cmd.Parameters.AddWithValue("@BIR", BIR)
        cmd.Parameters.AddWithValue("@PerCentIraShare", PerCentIraShare)
        ' cmd.Parameters.AddWithValue("@iscancelled", iscancelled)
        cmd.Parameters.AddWithValue("@RSiD", RSiD)
        cmd.Parameters.AddWithValue("@F_ID", F_ID)
        cmd.Parameters.AddWithValue("@TD_ID", TD_ID)
        cmd.Parameters.AddWithValue("@iscollected", iscollected)
        cmd.Parameters.AddWithValue("@MCHdr_ID", MCHdr_ID)
        cmd.Parameters.AddWithValue("@DepositMaster_HdrID", DepositMaster_HdrID)
        cmd.Parameters.AddWithValue("@MemoID", MemoID)
        cmd.Parameters.AddWithValue("@UserId", SystemUserId)
        'cmd.Parameters.AddWithValue("@TableId", TableId)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Execute("[dbo].[spSave_Fund_Disbursement_tbl1]", Data.CommandType.StoredProcedure)
    End Sub
End Class
