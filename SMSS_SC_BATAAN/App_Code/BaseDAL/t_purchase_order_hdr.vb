Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_purchase_order_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
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

    Private pPO_Date As String
    Public Property PO_Date() As String
        Get
            Return pPO_Date
        End Get
        Set(ByVal value As String)
            pPO_Date = value
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

    Private pmode_of_procurement_id As Integer
    Public Property mode_of_procurement_id() As Integer
        Get
            Return pmode_of_procurement_id
        End Get
        Set(ByVal value As Integer)
            pmode_of_procurement_id = value
        End Set
    End Property


    Private pDeliveryTerm As String
    Public Property DeliveryTerm() As String
        Get
            Return pDeliveryTerm
        End Get
        Set(ByVal value As String)
            pDeliveryTerm = value
        End Set
    End Property

    Private ppaymentTerm As String
    Public Property paymentTerm() As String
        Get
            Return ppaymentTerm
        End Get
        Set(ByVal value As String)
            ppaymentTerm = value
        End Set
    End Property

    Private pDeliveryDate As String
    Public Property DeliveryDate() As String
        Get
            Return pDeliveryDate
        End Get
        Set(ByVal value As String)
            pDeliveryDate = value
        End Set
    End Property

    Private pDeliveryPlace As String
    Public Property DeliveryPlace() As String
        Get
            Return pDeliveryPlace
        End Get
        Set(ByVal value As String)
            pDeliveryPlace = value
        End Set
    End Property

    Private pisDelivered As Boolean
    Public Property isDelivered() As Boolean
        Get
            Return pisDelivered
        End Get
        Set(ByVal value As Boolean)
            pisDelivered = value
        End Set
    End Property

    Private pisComplete As Boolean
    Public Property isComplete() As Boolean
        Get
            Return pisComplete
        End Get
        Set(ByVal value As Boolean)
            pisComplete = value
        End Set
    End Property

    Private pwithdv As Boolean
    Public Property withdv() As Boolean
        Get
            Return pwithdv
        End Get
        Set(ByVal value As Boolean)
            pwithdv = value
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

    Private pSinatories As String
    Public Property Sinatories() As String
        Get
            Return pSinatories
        End Get
        Set(ByVal value As String)
            pSinatories = value
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



    Private pisStag As Boolean
    Public Property isStag() As Boolean
        Get
            Return pisStag
        End Get
        Set(ByVal value As Boolean)
            pisStag = value
        End Set
    End Property


    Private pisStopForCutOff As Boolean
    Public Property isStopForCutOff() As Boolean
        Get
            Return pisStopForCutOff
        End Get
        Set(ByVal value As Boolean)
            pisStopForCutOff = value
        End Set
    End Property

    Private pisContinueCutOff As Boolean
    Public Property isContinueCutOff() As Boolean
        Get
            Return pisContinueCutOff
        End Get
        Set(ByVal value As Boolean)
            pisContinueCutOff = value
        End Set
    End Property

    Private pisShoppingA As Boolean
    Public Property isShoppingA() As Boolean
        Get
            Return pisShoppingA
        End Get
        Set(ByVal value As Boolean)
            pisShoppingA = value
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
    Private pisReceived_PO_Mayor As Boolean
    Public Property isReceived_PO_Mayor() As Boolean
        Get
            Return pisReceived_PO_Mayor
        End Get
        Set(ByVal value As Boolean)
            pisReceived_PO_Mayor = value
        End Set
    End Property

    Private pDateReceived_PO_Mayor As Date
    Public Property DateReceived_PO_Mayor() As Date
        Get
            Return pDateReceived_PO_Mayor
        End Get
        Set(ByVal value As Date)
            pDateReceived_PO_Mayor = value
        End Set
    End Property

    Private pisApproved_PO_Mayor As Boolean
    Public Property isApproved_PO_Mayor() As Boolean
        Get
            Return pisApproved_PO_Mayor
        End Get
        Set(ByVal value As Boolean)
            pisApproved_PO_Mayor = value
        End Set
    End Property

    Private pDateApproved_PO_Mayor As Date
    Public Property DateApproved_PO_Mayor() As Date
        Get
            Return pDateApproved_PO_Mayor
        End Get
        Set(ByVal value As Date)
            pDateApproved_PO_Mayor = value
        End Set
    End Property

    Private pDateDisApprove As Date
    Public Property DateDisApprove() As Date
        Get
            Return pDateDisApprove
        End Get
        Set(ByVal value As Date)
            pDateDisApprove = value
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
    Private pisReimbursement As Boolean
    Public Property isReimbursement() As Boolean
        Get
            Return pisReimbursement
        End Get
        Set(ByVal value As Boolean)
            pisReimbursement = value
        End Set
    End Property

    Private pRC_ID As Long
    Public Property RC_ID() As Long
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Long)
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

    Private pApprovedBy As Integer
    Public Property ApprovedBy() As Integer
        Get
            Return pApprovedBy
        End Get
        Set(ByVal value As Integer)
            pApprovedBy = value
        End Set
    End Property

#End Region
    Public Function save() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
        objDerived.cmd.Parameters.AddWithValue("@PO_Date", PO_Date)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryTerm", DeliveryTerm)
        objDerived.cmd.Parameters.AddWithValue("@paymentTerm", paymentTerm)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryPlace", DeliveryPlace)
        objDerived.cmd.Parameters.AddWithValue("@isDelivered", isDelivered)
        objDerived.cmd.Parameters.AddWithValue("@isComplete", isComplete)
        objDerived.cmd.Parameters.AddWithValue("@withdv", withdv)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Sinatories", Sinatories)
        objDerived.cmd.Parameters.AddWithValue("@ContractPrice", ContractPrice)
        objDerived.cmd.Parameters.AddWithValue("@isStag", isStag)
        objDerived.cmd.Parameters.AddWithValue("@isStopForCutOff", isStopForCutOff)
        objDerived.cmd.Parameters.AddWithValue("@isContinueCutOff", isContinueCutOff)
        objDerived.cmd.Parameters.AddWithValue("@isShoppingA", isShoppingA)
        objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.AddWithValue("@isReceived_PO_Mayor", isReceived_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateReceived_PO_Mayor", DateReceived_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@isApproved_PO_Mayor", isApproved_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateApproved_PO_Mayor", DateApproved_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateDisApprove", DateDisApprove)
        objDerived.cmd.Parameters.AddWithValue("@isGasoline", isGasoline)
        objDerived.cmd.Parameters.AddWithValue("@isReimbursement", isReimbursement)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PO_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long

        Dim objDerived As New DerivedDal
        'objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", pPOHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
        objDerived.cmd.Parameters.AddWithValue("@PO_Date", PO_Date)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@mode_of_procurement_id", mode_of_procurement_id)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryTerm", DeliveryTerm)
        objDerived.cmd.Parameters.AddWithValue("@paymentTerm", paymentTerm)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
        objDerived.cmd.Parameters.AddWithValue("@DeliveryPlace", DeliveryPlace)
        objDerived.cmd.Parameters.AddWithValue("@isDelivered", isDelivered)
        objDerived.cmd.Parameters.AddWithValue("@isComplete", isComplete)
        objDerived.cmd.Parameters.AddWithValue("@withdv", withdv)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Sinatories", Sinatories)
        objDerived.cmd.Parameters.AddWithValue("@ContractPrice", ContractPrice)
        objDerived.cmd.Parameters.AddWithValue("@isStag", isStag)
        objDerived.cmd.Parameters.AddWithValue("@isStopForCutOff", isStopForCutOff)
        objDerived.cmd.Parameters.AddWithValue("@isContinueCutOff", isContinueCutOff)
        objDerived.cmd.Parameters.AddWithValue("@isShoppingA", isShoppingA)
        objDerived.cmd.Parameters.AddWithValue("@isPublicInfra", isPublicInfra)
        objDerived.cmd.Parameters.AddWithValue("@isStraight", isStraight)
        objDerived.cmd.Parameters.AddWithValue("@isReceived_PO_Mayor", isReceived_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateReceived_PO_Mayor", DateReceived_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@isApproved_PO_Mayor", isApproved_PO_Mayor)
        objDerived.cmd.Parameters.AddWithValue("@DateApproved_PO_Mayor", DateApproved_PO_Mayor)
        'objDerived.cmd.Parameters.AddWithValue("@DateDisApprove", DateDisApprove)
        objDerived.cmd.Parameters.AddWithValue("@isGasoline", isGasoline)
        objDerived.cmd.Parameters.AddWithValue("@isReimbursement", isReimbursement)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PO_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
