Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_purchase_request_hdr

    Inherits BaseDLL.BaseDAL

    Public Property IsNonPPMP As Boolean
    Public Property NonPPMPJustification As String

    'Adding isPerLot column
    Public Property isPerLot As Boolean

#Region "properties"
    Private pprhdr_id As Long
    Public Property prhdr_id() As Long
        Get
            Return pprhdr_id
        End Get
        Set(ByVal value As Long)
            pprhdr_id = value
        End Set
    End Property

    Private ppr_no As String
    Public Property pr_no() As String
        Get
            Return ppr_no
        End Get
        Set(ByVal value As String)
            ppr_no = value
        End Set
    End Property

    Private pPR_Year As Integer
    Public Property PR_Year() As Integer
        Get
            Return pPR_Year
        End Get
        Set(ByVal value As Integer)
            pPR_Year = value
        End Set
    End Property

    Private pPR_Date As DateTime
    Public Property PR_Date() As DateTime
        Get
            Return pPR_Date
        End Get
        Set(ByVal value As DateTime)
            pPR_Date = value
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

    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

    Private pTransaction_type As Integer
    Public Property Transaction_type() As Integer
        Get
            Return pTransaction_type
        End Get
        Set(ByVal value As Integer)
            pTransaction_type = value
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

    Private pABC As Decimal
    Public Property ABC() As Decimal
        Get
            Return pABC
        End Get
        Set(ByVal value As Decimal)
            pABC = value
        End Set
    End Property

    Private pRequestedby As String
    Public Property Requestedby() As String
        Get
            Return pRequestedby
        End Get
        Set(ByVal value As String)
            pRequestedby = value
        End Set
    End Property

    Private pApprovedby As String
    Public Property Approvedby() As String
        Get
            Return pApprovedby
        End Get
        Set(ByVal value As String)
            pApprovedby = value
        End Set
    End Property

    Private pDate_Submitted As DateTime
    Public Property Date_Submitted() As DateTime
        Get
            Return pDate_Submitted
        End Get
        Set(ByVal value As DateTime)
            pDate_Submitted = value
        End Set
    End Property

    Private pDate_gso_rcv As DateTime
    Public Property Date_gso_rcv() As DateTime
        Get
            Return pDate_gso_rcv
        End Get
        Set(ByVal value As DateTime)
            pDate_gso_rcv = value
        End Set
    End Property

    Private pIsCancelled As Boolean
    Public Property IsCancelled() As Boolean
        Get
            Return pIsCancelled
        End Get
        Set(ByVal value As Boolean)
            pIsCancelled = value
        End Set
    End Property
    Private pIsDBM As Boolean
    Public Property IsDBM() As Boolean
        Get
            Return pIsDBM
        End Get
        Set(ByVal value As Boolean)
            pIsDBM = value
        End Set
    End Property

    Private pIsApproved As Boolean
    Public Property IsApproved() As Boolean
        Get
            Return pIsApproved
        End Get
        Set(ByVal value As Boolean)
            pIsApproved = value
        End Set
    End Property

    Private pwithOBR As Boolean
    Public Property withOBR() As Boolean
        Get
            Return pwithOBR
        End Get
        Set(ByVal value As Boolean)
            pwithOBR = value
        End Set
    End Property

    Private pisOnBid As Boolean
    Public Property isOnBid() As Boolean
        Get
            Return pisOnBid
        End Get
        Set(ByVal value As Boolean)
            pisOnBid = value
        End Set
    End Property

    Private pcomment As String
    Public Property comment() As String
        Get
            Return pcomment
        End Get
        Set(ByVal value As String)
            pcomment = value
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

    Private prcv_date As DateTime
    Public Property rcv_date() As DateTime
        Get
            Return prcv_date
        End Get
        Set(ByVal value As DateTime)
            prcv_date = value
        End Set
    End Property

    Private pwithWinner As Boolean
    Public Property withWinner() As Boolean
        Get
            Return pwithWinner
        End Get
        Set(ByVal value As Boolean)
            pwithWinner = value
        End Set
    End Property

    Private pdeclarationDate As DateTime
    Public Property declarationDate() As DateTime
        Get
            Return pdeclarationDate
        End Get
        Set(ByVal value As DateTime)
            pdeclarationDate = value
        End Set
    End Property

    Private pwithPO As Boolean
    Public Property withPO() As Boolean
        Get
            Return pwithPO
        End Get
        Set(ByVal value As Boolean)
            pwithPO = value
        End Set
    End Property

    Private pmode_of_procurement_id As Integer
    Public Property mode_of_procurement_id() As Integer
        Get
            Return pmode_of_procurement_id
        End Get
        Set(ByVal value As Integer)
            pmode_of_procurement_id = value
        End Set
    End Property

    Private pisPublicInfra As Boolean
    Public Property isPublicInfra() As Boolean
        Get
            Return pisPublicInfra
        End Get
        Set(ByVal value As Boolean)
            pisPublicInfra = value
        End Set
    End Property

    Private pisStraight As Boolean
    Public Property isStraight() As Boolean
        Get
            Return pisStraight
        End Get
        Set(ByVal value As Boolean)
            pisStraight = value
        End Set
    End Property

    Private pisReceived_PR_Mayor As Boolean
    Public Property isReceived_PR_Mayor() As Boolean
        Get
            Return pisReceived_PR_Mayor
        End Get
        Set(ByVal value As Boolean)
            pisReceived_PR_Mayor = value
        End Set
    End Property

    Private pDateReceived_PR_Mayor As DateTime
    Public Property DateReceived_PR_Mayor() As DateTime
        Get
            Return pDateReceived_PR_Mayor
        End Get
        Set(ByVal value As DateTime)
            pDateReceived_PR_Mayor = value
        End Set
    End Property

    Private pisApproved_PR_Mayor As Boolean
    Public Property isApproved_PR_Mayor() As Boolean
        Get
            Return pisApproved_PR_Mayor
        End Get
        Set(ByVal value As Boolean)
            pisApproved_PR_Mayor = value
        End Set
    End Property

    Private pDateApproved_PR_Mayor As DateTime
    Public Property DateApproved_PR_Mayor() As DateTime
        Get
            Return pDateApproved_PR_Mayor
        End Get
        Set(ByVal value As DateTime)
            pDateApproved_PR_Mayor = value
        End Set
    End Property

    Private pDateDisApprove As DateTime
    Public Property DateDisApprove() As DateTime
        Get
            Return pDateDisApprove
        End Get
        Set(ByVal value As DateTime)
            pDateDisApprove = value
        End Set
    End Property

    Private ppr_period_key_id As Long
    Public Property pr_period_key_id() As Long
        Get
            Return ppr_period_key_id
        End Get
        Set(ByVal value As Long)
            ppr_period_key_id = value
        End Set
    End Property

    Private pisGasoline As Boolean
    Public Property isGasoline() As Boolean
        Get
            Return pisGasoline
        End Get
        Set(ByVal value As Boolean)
            pisGasoline = value
        End Set
    End Property

    Private ppr_invoice_hdr_id As Long
    Public Property pr_invoice_hdr_id() As Long
        Get
            Return ppr_invoice_hdr_id
        End Get
        Set(ByVal value As Long)
            ppr_invoice_hdr_id = value
        End Set
    End Property
    Private pisReimbursement As Boolean
    Public Property isReimbursement() As Boolean
        Get
            Return pisReimbursement
        End Get
        Set(ByVal value As Boolean)
            pisReimbursement = value
        End Set
    End Property
    Private pisContract As Boolean
    Public Property isContract() As Boolean
        Get
            Return pisContract
        End Get
        Set(ByVal value As Boolean)
            pisContract = value
        End Set
    End Property
    Private pisEditable As Boolean
    Public Property isEditable() As Boolean
        Get
            Return pisEditable
        End Get
        Set(ByVal value As Boolean)
            pisEditable = value
        End Set
    End Property

    Private pRequestingOfficer As String
    Public Property RequestingOfficer() As String
        Get
            Return pRequestingOfficer
        End Get
        Set(ByVal value As String)
            pRequestingOfficer = value
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


    Private pisContinuing As Boolean
    Public Property isContinuing() As Boolean
        Get
            Return pisContinuing
        End Get
        Set(ByVal value As Boolean)
            pisContinuing = value
        End Set
    End Property

    Private pisTrustFund As Boolean
    Public Property isTrustFund() As Boolean
        Get
            Return pisTrustFund
        End Get
        Set(ByVal value As Boolean)
            pisTrustFund = value
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


    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property


    Private pCheckBy As Integer
    Public Property CheckBy() As Integer
        Get
            Return pCheckBy
        End Get
        Set(ByVal value As Integer)
            pCheckBy = value
        End Set
    End Property

    Private pNotedBy As Integer
    Public Property NotedBy() As Integer
        Get
            Return pNotedBy
        End Get
        Set(ByVal value As Integer)
            pNotedBy = value
        End Set
    End Property

#End Region




    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@prhdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@pr_no", pr_no)
        objDerived.cmd.Parameters.AddWithValue("@PR_Year", PR_Year)
        objDerived.cmd.Parameters.AddWithValue("@PR_Date", PR_Date)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@Transaction_type", Transaction_type)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@ABC", ABC)
        objDerived.cmd.Parameters.AddWithValue("@Requestedby", Requestedby)
        objDerived.cmd.Parameters.AddWithValue("@Approvedby", Approvedby)
        objDerived.cmd.Parameters.AddWithValue("@Date_Submitted", Date_Submitted)
        objDerived.cmd.Parameters.AddWithValue("@Date_gso_rcv", Date_gso_rcv)
        objDerived.cmd.Parameters.AddWithValue("@IsCancelled", IsCancelled)
        objDerived.cmd.Parameters.AddWithValue("@IsApproved", IsApproved)
        objDerived.cmd.Parameters.AddWithValue("@withOBR", withOBR)
        objDerived.cmd.Parameters.AddWithValue("@isOnBid", isOnBid)
        objDerived.cmd.Parameters.AddWithValue("@comment", comment)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@rcv_date", rcv_date)
        objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
        objDerived.cmd.Parameters.AddWithValue("@declarationDate", declarationDate)
        objDerived.cmd.Parameters.AddWithValue("@withPO", withPO)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.AddWithValue("@isReceived_PR_Mayor", isReceived_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateReceived_PR_Mayor", DateReceived_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@isApproved_PR_Mayor", isApproved_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateApproved_PR_Mayor", DateApproved_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateDisApprove", DateDisApprove)
        objDerived.cmd.Parameters.AddWithValue("@pr_period_key_id", pr_period_key_id)
        objDerived.cmd.Parameters.AddWithValue("@isGasoline", isGasoline)
        objDerived.cmd.Parameters.AddWithValue("@pr_invoice_hdr_id", pr_invoice_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@isReimbursement", isReimbursement)
        objDerived.cmd.Parameters.AddWithValue("@isContract", isContract)
        objDerived.cmd.Parameters.AddWithValue("@isEditable", isEditable)
        objDerived.cmd.Parameters.AddWithValue("@RequestingOfficer", RequestingOfficer)
        objDerived.cmd.Parameters.AddWithValue("@Position", Position)
        objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
        objDerived.cmd.Parameters.AddWithValue("@isTrustFund", isTrustFund)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.AddWithValue("@CheckBy", CheckBy)
        objDerived.cmd.Parameters.AddWithValue("@NotedBy", NotedBy)
        objDerived.cmd.Parameters.AddWithValue("@isDBM", IsDBM)

        objDerived.cmd.Parameters.AddWithValue("@IsNonPPMP", IsNonPPMP)
        objDerived.cmd.Parameters.AddWithValue("@NonPPMPJustification", NonPPMPJustification)

        objDerived.cmd.Parameters.AddWithValue("@isPerlot", isPerLot)




        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PR_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@prhdr_id", prhdr_id)
        objDerived.cmd.Parameters.AddWithValue("@pr_no", pr_no)
        objDerived.cmd.Parameters.AddWithValue("@PR_Year", PR_Year)
        objDerived.cmd.Parameters.AddWithValue("@PR_Date", PR_Date)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@Transaction_type", Transaction_type)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@ABC", ABC)
        objDerived.cmd.Parameters.AddWithValue("@Requestedby", Requestedby)
        objDerived.cmd.Parameters.AddWithValue("@Approvedby", Approvedby)
        objDerived.cmd.Parameters.AddWithValue("@Date_Submitted", Date_Submitted)
        objDerived.cmd.Parameters.AddWithValue("@Date_gso_rcv", Date_gso_rcv)
        objDerived.cmd.Parameters.AddWithValue("@IsCancelled", IsCancelled)
        objDerived.cmd.Parameters.AddWithValue("@IsApproved", IsApproved)
        objDerived.cmd.Parameters.AddWithValue("@withOBR", withOBR)
        objDerived.cmd.Parameters.AddWithValue("@isOnBid", isOnBid)
        objDerived.cmd.Parameters.AddWithValue("@comment", comment)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@rcv_date", rcv_date)
        objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
        objDerived.cmd.Parameters.AddWithValue("@declarationDate", declarationDate)
        objDerived.cmd.Parameters.AddWithValue("@withPO", withPO)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.AddWithValue("@isReceived_PR_Mayor", isReceived_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateReceived_PR_Mayor", DateReceived_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@isApproved_PR_Mayor", isApproved_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateApproved_PR_Mayor", DateApproved_PR_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateDisApprove", DateDisApprove)
        objDerived.cmd.Parameters.AddWithValue("@pr_period_key_id", pr_period_key_id)
        objDerived.cmd.Parameters.AddWithValue("@isGasoline", isGasoline)
        objDerived.cmd.Parameters.AddWithValue("@pr_invoice_hdr_id", pr_invoice_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@isReimbursement", isReimbursement)
        objDerived.cmd.Parameters.AddWithValue("@isContract", isContract)
        objDerived.cmd.Parameters.AddWithValue("@RequestingOfficer", RequestingOfficer)
        objDerived.cmd.Parameters.AddWithValue("@Position", Position)
        objDerived.cmd.Parameters.AddWithValue("@isEditable", isEditable)
        objDerived.cmd.Parameters.AddWithValue("@isContinuing", isContinuing)
        objDerived.cmd.Parameters.AddWithValue("@isTrustFund", isTrustFund)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.AddWithValue("@CheckBy", CheckBy)
        objDerived.cmd.Parameters.AddWithValue("@NotedBy", NotedBy)
        objDerived.cmd.Parameters.AddWithValue("@isDBM", IsDBM)
        'objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)

        objDerived.cmd.Parameters.AddWithValue("@IsNonPPMP", IsNonPPMP)
        objDerived.cmd.Parameters.AddWithValue("@NonPPMPJustification", NonPPMPJustification)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PR_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function




End Class
