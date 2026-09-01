Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace Bidding_Infra

    '=-= AMS.tb_Infra_Hdr
#Region "tb_Infra_Hdr"

    Public Class tb_Infra_Hdr
        Inherits BaseDLL.BaseDAL

        Private pInfra_Hdr_ID As Long
        Public Property Infra_Hdr_ID() As Long
            Get
                Return pInfra_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pInfra_Hdr_ID = value
            End Set
        End Property

        Private pInfraDate As Date
        Public Property InfraDate() As Date
            Get
                Return pInfraDate
            End Get
            Set(ByVal value As Date)
                pInfraDate = value
            End Set
        End Property

        Private pOBR_Hdr_ID As Long
        Public Property OBR_Hdr_ID() As Long
            Get
                Return pOBR_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pOBR_Hdr_ID = value
            End Set
        End Property


        Private pOBR_No As String
        Public Property OBR_No() As String
            Get
                Return pOBR_No
            End Get
            Set(ByVal value As String)
                pOBR_No = value
            End Set
        End Property


        Private pApprovedBudget As Decimal
        Public Property ApprovedBudget() As Decimal
            Get
                Return pApprovedBudget
            End Get
            Set(ByVal value As Decimal)
                pApprovedBudget = value
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


        Private pFunction_ID As Integer
        Public Property Function_ID() As Integer
            Get
                Return pFunction_ID
            End Get
            Set(ByVal value As Integer)
                pFunction_ID = value
            End Set
        End Property


        Private pProgram_ID As Integer
        Public Property Program_ID() As Integer
            Get
                Return pProgram_ID
            End Get
            Set(ByVal value As Integer)
                pProgram_ID = value
            End Set
        End Property


        Private pProject_ID As Integer
        Public Property Project_ID() As Integer
            Get
                Return pProject_ID
            End Get
            Set(ByVal value As Integer)
                pProject_ID = value
            End Set
        End Property


        Private pProjectName As String
        Public Property ProjectName() As String
            Get
                Return pProjectName
            End Get
            Set(ByVal value As String)
                pProjectName = value
            End Set
        End Property


        Private pProjectLocation As String
        Public Property ProjectLocation() As String
            Get
                Return pProjectLocation
            End Get
            Set(ByVal value As String)
                pProjectLocation = value
            End Set
        End Property

        Private pBidPlace As String
        Public Property BidPlace() As String
            Get
                Return pBidPlace
            End Get
            Set(ByVal value As String)
                pBidPlace = value
            End Set
        End Property

        Private pBidTime As String
        Public Property BidTime() As String
            Get
                Return pBidTime
            End Get
            Set(ByVal value As String)
                pBidTime = value
            End Set
        End Property

        Private pResolutionNo As String
        Public Property ResolutionNo() As String
            Get
                Return pResolutionNo
            End Get
            Set(ByVal value As String)
                pResolutionNo = value
            End Set
        End Property

        Private pisFinal As Boolean
        Public Property isFinal() As Boolean
            Get
                Return pisFinal
            End Get
            Set(ByVal value As Boolean)
                pisFinal = value
            End Set
        End Property


        Private pwithNOA As Boolean
        Public Property withNOA() As Boolean
            Get
                Return pwithNOA
            End Get
            Set(ByVal value As Boolean)
                pwithNOA = value
            End Set
        End Property

        Private pwithNTP As Boolean
        Public Property withNTP() As Boolean
            Get
                Return pwithNTP
            End Get
            Set(ByVal value As Boolean)
                pwithNTP = value
            End Set
        End Property

        Private pReso_PreparedBy As Integer
        Public Property Reso_PreparedBy() As Integer
            Get
                Return pReso_PreparedBy
            End Get
            Set(ByVal value As Integer)
                pReso_PreparedBy = value
            End Set
        End Property

        Private pNOA_ApprovedBy As Integer
        Public Property NOA_ApprovedBy() As Integer
            Get
                Return pNOA_ApprovedBy
            End Get
            Set(ByVal value As Integer)
                pNOA_ApprovedBy = value
            End Set
        End Property

        Private pNOA_Date As Date
        Public Property NOA_Date() As Date
            Get
                Return pNOA_Date
            End Get
            Set(ByVal value As Date)
                pNOA_Date = value
            End Set
        End Property

        Private pNTP_ApprovedBy As Integer
        Public Property NTP_ApprovedBy() As Integer
            Get
                Return pNTP_ApprovedBy
            End Get
            Set(ByVal value As Integer)
                pNTP_ApprovedBy = value
            End Set
        End Property

        Private pNTP_Date As Date
        Public Property NTP_Date() As Date
            Get
                Return pNTP_Date
            End Get
            Set(ByVal value As Date)
                pNTP_Date = value
            End Set
        End Property

        Private pBACC As Integer
        Public Property BACC() As Integer
            Get
                Return pBACC
            End Get
            Set(ByVal value As Integer)
                pBACC = value
            End Set
        End Property

        Private pBACVC As Integer
        Public Property BACVC() As Integer
            Get
                Return pBACVC
            End Get
            Set(ByVal value As Integer)
                pBACVC = value
            End Set
        End Property

        Private pBAC1 As Integer
        Public Property BAC1() As Integer
            Get
                Return pBAC1
            End Get
            Set(ByVal value As Integer)
                pBAC1 = value
            End Set
        End Property

        Private pBAC2 As Integer
        Public Property BAC2() As Integer
            Get
                Return pBAC2
            End Get
            Set(ByVal value As Integer)
                pBAC2 = value
            End Set
        End Property

        Private pBAC3 As Integer
        Public Property BAC3() As Integer
            Get
                Return pBAC3
            End Get
            Set(ByVal value As Integer)
                pBAC3 = value
            End Set
        End Property

        Private pBAC4 As Integer
        Public Property BAC4() As Integer
            Get
                Return pBAC4
            End Get
            Set(ByVal value As Integer)
                pBAC4 = value
            End Set
        End Property

        Private pBAC_TWG As Integer
        Public Property BAC_TWG() As Integer
            Get
                Return pBAC_TWG
            End Get
            Set(ByVal value As Integer)
                pBAC_TWG = value
            End Set
        End Property

        Private pEndUser As Integer
        Public Property EndUser() As Integer
            Get
                Return pEndUser
            End Get
            Set(ByVal value As Integer)
                pEndUser = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_Hdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@InfraDate", InfraDate)
            objDerived.cmd.Parameters.AddWithValue("@OBR_Hdr_ID",	OBR_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@OBR_No", OBR_No)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBudget", ApprovedBudget)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID",	RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID",	Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID",	Program_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID",	Project_ID)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@ProjectLocation", ProjectLocation)
            objDerived.cmd.Parameters.AddWithValue("@BidPlace", BidPlace)
            objDerived.cmd.Parameters.AddWithValue("@BidTime", BidTime)
            objDerived.cmd.Parameters.AddWithValue("@ResolutionNo",	ResolutionNo)
            objDerived.cmd.Parameters.AddWithValue("@isFinal",	isFinal)
            objDerived.cmd.Parameters.AddWithValue("@withNOA",	withNOA)
            objDerived.cmd.Parameters.AddWithValue("@withNTP",	withNTP)
            objDerived.cmd.Parameters.AddWithValue("@Reso_PreparedBy",	Reso_PreparedBy)
            objDerived.cmd.Parameters.AddWithValue("@NOA_ApprovedBy",	NOA_ApprovedBy)
            ' objDerived.cmd.Parameters.AddWithValue("@NOA_Date",	NOA_Date)
            objDerived.cmd.Parameters.AddWithValue("@NTP_ApprovedBy",	NTP_ApprovedBy)
            'objDerived.cmd.Parameters.AddWithValue("@NTP_Date",	NTP_Date) 
            objDerived.cmd.Parameters.AddWithValue("@BACC",	BACC)
            objDerived.cmd.Parameters.AddWithValue("@BACVC",	BACVC)
            objDerived.cmd.Parameters.AddWithValue("@BAC1",	BAC1)
            objDerived.cmd.Parameters.AddWithValue("@BAC2",	BAC2)
            objDerived.cmd.Parameters.AddWithValue("@BAC3",	BAC3)
            objDerived.cmd.Parameters.AddWithValue("@BAC4",	BAC4)
            objDerived.cmd.Parameters.AddWithValue("@BAC_TWG",	BAC_TWG)
            objDerived.cmd.Parameters.AddWithValue("@EndUser", EndUser)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_Hdr_ID", Infra_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@InfraDate", InfraDate)
            objDerived.cmd.Parameters.AddWithValue("@OBR_Hdr_ID", OBR_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@OBR_No", OBR_No)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBudget", ApprovedBudget)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", Program_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
            objDerived.cmd.Parameters.AddWithValue("@ProjectName", ProjectName)
            objDerived.cmd.Parameters.AddWithValue("@ProjectLocation", ProjectLocation)
            objDerived.cmd.Parameters.AddWithValue("@BidPlace", BidPlace)
            objDerived.cmd.Parameters.AddWithValue("@BidTime", BidTime)
            objDerived.cmd.Parameters.AddWithValue("@ResolutionNo", ResolutionNo)
            objDerived.cmd.Parameters.AddWithValue("@isFinal", isFinal)
            objDerived.cmd.Parameters.AddWithValue("@withNOA", withNOA)
            objDerived.cmd.Parameters.AddWithValue("@withNTP", withNTP)
            objDerived.cmd.Parameters.AddWithValue("@Reso_PreparedBy", Reso_PreparedBy)
            objDerived.cmd.Parameters.AddWithValue("@NOA_ApprovedBy", NOA_ApprovedBy)
            'objDerived.cmd.Parameters.AddWithValue("@NOA_Date", NOA_Date)
            objDerived.cmd.Parameters.AddWithValue("@NTP_ApprovedBy", NTP_ApprovedBy)
            'objDerived.cmd.Parameters.AddWithValue("@NTP_Date", NTP_Date)
            objDerived.cmd.Parameters.AddWithValue("@BACC", BACC)
            objDerived.cmd.Parameters.AddWithValue("@BACVC", BACVC)
            objDerived.cmd.Parameters.AddWithValue("@BAC1", BAC1)
            objDerived.cmd.Parameters.AddWithValue("@BAC2", BAC2)
            objDerived.cmd.Parameters.AddWithValue("@BAC3", BAC3)
            objDerived.cmd.Parameters.AddWithValue("@BAC4", BAC4)
            objDerived.cmd.Parameters.AddWithValue("@BAC_TWG", BAC_TWG)
            objDerived.cmd.Parameters.AddWithValue("@EndUser", EndUser)


            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
    End Class
#End Region
    '=-= AMS.tb_Infra_Dtl
#Region "tb_Infra_Dtl"

    Public Class tb_Infra_Dtl
        Inherits BaseDLL.BaseDAL

        Private pInfra_Dtl_ID As Long
        Public Property Infra_Dtl_ID() As Long
            Get
                Return pInfra_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pInfra_Dtl_ID = value
            End Set
        End Property

        Private pInfra_Hdr_ID As Long
        Public Property Infra_Hdr_ID() As Long
            Get
                Return pInfra_Hdr_ID
            End Get
            Set(ByVal value As Long)
                pInfra_Hdr_ID = value
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

        Private pSupplier_ID As Integer
        Public Property Supplier_ID() As Integer
            Get
                Return pSupplier_ID
            End Get
            Set(ByVal value As Integer)
                pSupplier_ID = value
            End Set
        End Property

        Private pBidAmount As Decimal
        Public Property BidAmount() As Decimal
            Get
                Return pBidAmount
            End Get
            Set(ByVal value As Decimal)
                pBidAmount = value
            End Set
        End Property

        Private pTimeDuration As String
        Public Property TimeDuration() As String
            Get
                Return pTimeDuration
            End Get
            Set(ByVal value As String)
                pTimeDuration = value
            End Set
        End Property

        Private pBidSecurity As String
        Public Property BidSecurity() As String
            Get
                Return pBidSecurity
            End Get
            Set(ByVal value As String)
                pBidSecurity = value
            End Set
        End Property

        Private pBank_Campany As String
        Public Property Bank_Campany() As String
            Get
                Return pBank_Campany
            End Get
            Set(ByVal value As String)
                pBank_Campany = value
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

        Private pValidityPeriod As String
        Public Property ValidityPeriod() As String
            Get
                Return pValidityPeriod
            End Get
            Set(ByVal value As String)
                pValidityPeriod = value
            End Set
        End Property

        Private pBidSecurity_Amount As Decimal
        Public Property BidSecurity_Amount() As Decimal
            Get
                Return pBidSecurity_Amount
            End Get
            Set(ByVal value As Decimal)
                pBidSecurity_Amount = value
            End Set
        End Property


        Private pRequired_BidSecurity As Decimal
        Public Property Required_BidSecurity() As Decimal
            Get
                Return pRequired_BidSecurity
            End Get
            Set(ByVal value As Decimal)
                pRequired_BidSecurity = value
            End Set
        End Property


        Private pSufficient_InSufficient As String
        Public Property Sufficient_InSufficient() As String
            Get
                Return pSufficient_InSufficient
            End Get
            Set(ByVal value As String)
                pSufficient_InSufficient = value
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




        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Infra_Hdr_ID", Infra_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@isWinner ", isWinner)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@BidAmount ", BidAmount)
            objDerived.cmd.Parameters.AddWithValue("@TimeDuration", TimeDuration)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity", BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Bank_Campany", Bank_Campany)
            objDerived.cmd.Parameters.AddWithValue("@Number ", Number)
            objDerived.cmd.Parameters.AddWithValue("@ValidityPeriod ", ValidityPeriod)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity_Amount ", BidSecurity_Amount)
            objDerived.cmd.Parameters.AddWithValue("@Required_BidSecurity ", Required_BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Sufficient_InSufficient ", Sufficient_InSufficient)
            objDerived.cmd.Parameters.AddWithValue("@Remarks ", Remarks)


            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_Dtl_ID", Infra_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Infra_Hdr_ID", Infra_Hdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@isWinner ", isWinner)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@BidAmount ", BidAmount)
            objDerived.cmd.Parameters.AddWithValue("@TimeDuration", TimeDuration)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity", BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Bank_Campany", Bank_Campany)
            objDerived.cmd.Parameters.AddWithValue("@Number ", Number)
            objDerived.cmd.Parameters.AddWithValue("@ValidityPeriod ", ValidityPeriod)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity_Amount ", BidSecurity_Amount)
            objDerived.cmd.Parameters.AddWithValue("@Required_BidSecurity ", Required_BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Sufficient_InSufficient ", Sufficient_InSufficient)
            objDerived.cmd.Parameters.AddWithValue("@Remarks ", Remarks)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
    End Class
#End Region



    '=-= AMS.tb_Infra_Bidder_Hdr
#Region "tb_Infra_Bidder_Hdr"

    Public Class tb_Infra_Bidder_Hdr
        Inherits BaseDLL.BaseDAL

        Private pInfra_BidderHdr_ID As Long
        Public Property Infra_BidderHdr_ID() As Long
            Get
                Return pInfra_BidderHdr_ID
            End Get
            Set(ByVal value As Long)
                pInfra_BidderHdr_ID = value
            End Set
        End Property

        Private pSupplier_ID As Long
        Public Property Supplier_ID() As Long
            Get
                Return pSupplier_ID
            End Get
            Set(ByVal value As Long)
                pSupplier_ID = value
            End Set
        End Property

        Private pTotal_Amount As Decimal
        Public Property Total_Amount() As Decimal
            Get
                Return pTotal_Amount
            End Get
            Set(ByVal value As Decimal)
                pTotal_Amount = value
            End Set
        End Property

        Private pTimeDuration As String
        Public Property TimeDuration() As String
            Get
                Return pTimeDuration
            End Get
            Set(ByVal value As String)
                pTimeDuration = value
            End Set
        End Property

        Private pBidSecurity As String
        Public Property BidSecurity() As String
            Get
                Return pBidSecurity
            End Get
            Set(ByVal value As String)
                pBidSecurity = value
            End Set
        End Property

        Private pBank_Campany As String
        Public Property Bank_Campany() As String
            Get
                Return pBank_Campany
            End Get
            Set(ByVal value As String)
                pBank_Campany = value
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

        Private pValidityPeriod As String
        Public Property ValidityPeriod() As String
            Get
                Return pValidityPeriod
            End Get
            Set(ByVal value As String)
                pValidityPeriod = value
            End Set
        End Property

        Private pBidSecurity_Amount As Decimal
        Public Property BidSecurity_Amount() As Decimal
            Get
                Return pBidSecurity_Amount
            End Get
            Set(ByVal value As Decimal)
                pBidSecurity_Amount = value
            End Set
        End Property

        Private pRequired_BidSecurity As Decimal
        Public Property Required_BidSecurity() As Decimal
            Get
                Return pBidSecurity_Amount
            End Get
            Set(ByVal value As Decimal)
                pBidSecurity_Amount = value
            End Set
        End Property

        Private pSufficient_InSufficient As String
        Public Property Sufficient_InSufficient() As String
            Get
                Return pSufficient_InSufficient
            End Get
            Set(ByVal value As String)
                pSufficient_InSufficient = value
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

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_BidderHdr_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@Total_Amount", Total_Amount)
            objDerived.cmd.Parameters.AddWithValue("@TimeDuration", TimeDuration)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity", BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Bank_Campany", Bank_Campany)
            objDerived.cmd.Parameters.AddWithValue("@Number", Number)
            objDerived.cmd.Parameters.AddWithValue("@ValidityPeriod", ValidityPeriod)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity_Amount", BidSecurity_Amount)
            objDerived.cmd.Parameters.AddWithValue("@Required_BidSecurity", Required_BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Sufficient_InSufficient", Sufficient_InSufficient)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Bidder_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_BidderHdr_ID", Infra_BidderHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
            objDerived.cmd.Parameters.AddWithValue("@Total_Amount", Total_Amount)
            objDerived.cmd.Parameters.AddWithValue("@TimeDuration", TimeDuration)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity", BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Bank_Campany", Bank_Campany)
            objDerived.cmd.Parameters.AddWithValue("@Number", Number)
            objDerived.cmd.Parameters.AddWithValue("@ValidityPeriod", ValidityPeriod)
            objDerived.cmd.Parameters.AddWithValue("@BidSecurity_Amount", BidSecurity_Amount)
            objDerived.cmd.Parameters.AddWithValue("@Required_BidSecurity", Required_BidSecurity)
            objDerived.cmd.Parameters.AddWithValue("@Sufficient_InSufficient", Sufficient_InSufficient)
            objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Bidder_Hdr]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
    End Class
#End Region

    '=-= AMS.tb_Infra_Bidder_Dtl
#Region "tb_Infra_Bidder_Dtl"

    Public Class tb_Infra_Bidder_Dtl
        Inherits BaseDLL.BaseDAL

        Private pInfra_BidderDtl_ID As Long
        Public Property Infra_BidderDtl_ID() As Long
            Get
                Return pInfra_BidderDtl_ID
            End Get
            Set(ByVal value As Long)
                pInfra_BidderDtl_ID = value
            End Set
        End Property

        Private pInfra_BidderHdr_ID As Long
        Public Property Infra_BidderHdr_ID() As Long
            Get
                Return pInfra_BidderHdr_ID
            End Get
            Set(ByVal value As Long)
                pInfra_BidderHdr_ID = value
            End Set
        End Property

        Private pInfra_Dtl_ID As Long
        Public Property Infra_Dtl_ID() As Long
            Get
                Return pInfra_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pInfra_Dtl_ID = value
            End Set
        End Property

        Private pBid_Price As Decimal
        Public Property Bid_Price() As Decimal
            Get
                Return pBid_Price
            End Get
            Set(ByVal value As Decimal)
                pBid_Price = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_BidderDtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@Infra_BidderHdr_ID", Infra_BidderHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Infra_Dtl_ID", Infra_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Bid_Price", Bid_Price)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Bidder_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()

            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Infra_BidderDtl_ID", Infra_BidderDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Infra_BidderHdr_ID", Infra_BidderHdr_ID)
            objDerived.cmd.Parameters.AddWithValue("@Infra_Dtl_ID", Infra_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Bid_Price", Bid_Price)

            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_tb_Infra_Bidder_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i

        End Function
    End Class
#End Region

End Namespace

