Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class BidderHdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pBidHdr_ID As Integer
    Public Property BidHdr_ID() As Integer
        Get
            Return pBidHdr_ID
        End Get
        Set(ByVal value As Integer)
            pBidHdr_ID = value
        End Set
    End Property

    Private pPR_No As String
    Public Property PR_No() As String
        Get
            Return pPR_No
        End Get
        Set(ByVal value As String)
            pPR_No = value
        End Set
    End Property

    Private pSignatory1 As String
    Public Property Signatory1() As String
        Get
            Return pSignatory1
        End Get
        Set(ByVal value As String)
            pSignatory1 = value
        End Set
    End Property

    Private pSignatory2 As String
    Public Property Signatory2() As String
        Get
            Return pSignatory2
        End Get
        Set(ByVal value As String)
            pSignatory2 = value
        End Set
    End Property

    Private pBid_Opening As DateTime
    Public Property Bid_Opening() As DateTime
        Get
            Return pBid_Opening
        End Get
        Set(ByVal value As DateTime)
            pBid_Opening = value
        End Set
    End Property

    Private pBidNo As String
    Public Property BidNo() As String
        Get
            Return pBidNo
        End Get
        Set(ByVal value As String)
            pBidNo = value
        End Set
    End Property

    Private pwithpo As Boolean
    Public Property withpo() As Boolean
        Get
            Return pwithpo
        End Get
        Set(ByVal value As Boolean)
            pwithpo = value
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

    Private pF_ID As Integer
    Public Property F_ID() As Integer
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Integer)
            pF_ID = value
        End Set
    End Property

    Private pBACC As String
    Public Property BACC() As String
        Get
            Return pBACC
        End Get
        Set(ByVal value As String)
            pBACC = value
        End Set
    End Property

    Private pBACVC As String
    Public Property BACVC() As String
        Get
            Return pBACVC
        End Get
        Set(ByVal value As String)
            pBACVC = value
        End Set
    End Property

    Private pBACM1 As String
    Public Property BACM1() As String
        Get
            Return pBACM1
        End Get
        Set(ByVal value As String)
            pBACM1 = value
        End Set
    End Property

    Private pBACM2 As String
    Public Property BACM2() As String
        Get
            Return pBACM2
        End Get
        Set(ByVal value As String)
            pBACM2 = value
        End Set
    End Property

    Private pBACM3 As String
    Public Property BACM3() As String
        Get
            Return pBACM3
        End Get
        Set(ByVal value As String)
            pBACM3 = value
        End Set
    End Property

    Private pBACM4 As String
    Public Property BACM4() As String
        Get
            Return pBACM4
        End Get
        Set(ByVal value As String)
            pBACM4 = value
        End Set
    End Property

    Private pBACCstatus As String
    Public Property BACCstatus() As String
        Get
            Return pBACCstatus
        End Get
        Set(ByVal value As String)
            pBACCstatus = value
        End Set
    End Property

    Private pBACVCstatus As String
    Public Property BACVCstatus() As String
        Get
            Return pBACVCstatus
        End Get
        Set(ByVal value As String)
            pBACVCstatus = value
        End Set
    End Property

    Private pBACM1status As String
    Public Property BACM1status() As String
        Get
            Return pBACM1status
        End Get
        Set(ByVal value As String)
            pBACM1status = value
        End Set
    End Property

    Private pBACM2status As String
    Public Property BACM2status() As String
        Get
            Return pBACM2status
        End Get
        Set(ByVal value As String)
            pBACM2status = value
        End Set
    End Property

    Private pBACM3status As String
    Public Property BACM3status() As String
        Get
            Return pBACM3status
        End Get
        Set(ByVal value As String)
            pBACM3status = value
        End Set
    End Property

    Private pBACM4status As String
    Public Property BACM4status() As String
        Get
            Return pBACM4status
        End Get
        Set(ByVal value As String)
            pBACM4status = value
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

    Private pABC As Decimal
    Public Property ABC() As Decimal
        Get
            Return pABC
        End Get
        Set(ByVal value As Decimal)
            pABC = value
        End Set
    End Property

    Private presolution As String
    Public Property resolution() As String
        Get
            Return presolution
        End Get
        Set(ByVal value As String)
            presolution = value
        End Set
    End Property

    Private pEndUser As String
    Public Property EndUser() As String
        Get
            Return pEndUser
        End Get
        Set(ByVal value As String)
            pEndUser = value
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








#End Region


    Public Function saveBidderHdr() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@BidHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
        objDerived.cmd.Parameters.AddWithValue("@Signatory1", Signatory1)
        objDerived.cmd.Parameters.AddWithValue("@Signatory2", Signatory2)
        objDerived.cmd.Parameters.AddWithValue("@Bid_Opening", Bid_Opening)
        objDerived.cmd.Parameters.AddWithValue("@BidNo", BidNo)
        objDerived.cmd.Parameters.AddWithValue("@withpo", withpo)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@BACC", BACC)
        objDerived.cmd.Parameters.AddWithValue("@BACVC", BACVC)
        objDerived.cmd.Parameters.AddWithValue("@BACM1", BACM1)
        objDerived.cmd.Parameters.AddWithValue("@BACM2", BACM2)
        objDerived.cmd.Parameters.AddWithValue("@BACM3", BACM3)
        objDerived.cmd.Parameters.AddWithValue("@BACM4", BACM4)
        objDerived.cmd.Parameters.AddWithValue("@BACCstatus", BACCstatus)
        objDerived.cmd.Parameters.AddWithValue("@BACVCstatus", BACVCstatus)
        objDerived.cmd.Parameters.AddWithValue("@BACM1status", BACM1status)
        objDerived.cmd.Parameters.AddWithValue("@BACM2status", BACM2status)
        objDerived.cmd.Parameters.AddWithValue("@BACM3status", BACM3status)
        objDerived.cmd.Parameters.AddWithValue("@BACM4status", BACM4status)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@ABC", ABC)
        objDerived.cmd.Parameters.AddWithValue("@resolution", resolution)
        objDerived.cmd.Parameters.AddWithValue("@EndUser", EndUser)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Bidder_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

   

   
End Class
