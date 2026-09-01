Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class t_purchase_request_obr_hdr_OBR
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pOBR_Hdr_ID As Long
    Public Property OBR_Hdr_ID() As Long
        Get
            Return pOBR_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pOBR_Hdr_ID = value
        End Set
    End Property

    Private pTempOBR_No As String
    Public Property TempOBR_No() As String
        Get
            Return pTempOBR_No
        End Get
        Set(ByVal value As String)
            pTempOBR_No = value
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

    Private pF_ID_Accntg As Long
    Public Property F_ID_Accntg() As Long
        Get
            Return pF_ID_Accntg
        End Get
        Set(ByVal value As Long)
            pF_ID_Accntg = value
        End Set
    End Property

    Private pPeriod_key As Long
    Public Property Period_key() As Long
        Get
            Return pPeriod_key
        End Get
        Set(ByVal value As Long)
            pPeriod_key = value
        End Set
    End Property

    Private pPRHdr_ID As Long
    Public Property PRHdr_ID() As Long
        Get
            Return pPRHdr_ID
        End Get
        Set(ByVal value As Long)
            pPRHdr_ID = value
        End Set
    End Property

    Private pOBR_Date As DateTime
    Public Property OBR_Date() As DateTime
        Get
            Return pOBR_Date
        End Get
        Set(ByVal value As DateTime)
            pOBR_Date = value
        End Set
    End Property

    Private pOBR_Title As String
    Public Property OBR_Title() As String
        Get
            Return pOBR_Title
        End Get
        Set(ByVal value As String)
            pOBR_Title = value
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

    Private pPayee As String
    Public Property Payee() As String
        Get
            Return pPayee
        End Get
        Set(ByVal value As String)
            pPayee = value
        End Set
    End Property

    Private pFunc_per_Office_ID As Long
    Public Property Func_per_Office_ID() As Long
        Get
            Return pFunc_per_Office_ID
        End Get
        Set(ByVal value As Long)
            pFunc_per_Office_ID = value
        End Set
    End Property

    Private pAddress As String
    Public Property Address() As String
        Get
            Return pAddress
        End Get
        Set(ByVal value As String)
            pAddress = value
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

    Private pSignatory1_ID As Integer
    Public Property Signatory1_ID() As Integer
        Get
            Return pSignatory1_ID
        End Get
        Set(ByVal value As Integer)
            pSignatory1_ID = value
        End Set
    End Property

    Private pDateSigned1 As DateTime
    Public Property DateSigned1() As DateTime
        Get
            Return pDateSigned1
        End Get
        Set(ByVal value As DateTime)
            pDateSigned1 = value
        End Set
    End Property

    Private pSignatory2_ID As Integer
    Public Property Signatory2_ID() As Integer
        Get
            Return pSignatory2_ID
        End Get
        Set(ByVal value As Integer)
            pSignatory2_ID = value
        End Set
    End Property

    Private pDateSigned2 As DateTime
    Public Property DateSigned2() As DateTime
        Get
            Return pDateSigned2
        End Get
        Set(ByVal value As DateTime)
            pDateSigned2 = value
        End Set
    End Property

    Private pisCancelled As Boolean
    Public Property isCancelled() As Boolean
        Get
            Return pisCancelled
        End Get
        Set(ByVal value As Boolean)
            pisCancelled = value
        End Set
    End Property

    Private pisApproved As Boolean
    Public Property isApproved() As Boolean
        Get
            Return pisApproved
        End Get
        Set(ByVal value As Boolean)
            pisApproved = value
        End Set
    End Property

    Private pisPayroll As Boolean
    Public Property isPayroll() As Boolean
        Get
            Return pisPayroll
        End Get
        Set(ByVal value As Boolean)
            pisPayroll = value
        End Set
    End Property

    Private pisApprovedMayor As Boolean
    Public Property isApprovedMayor() As Boolean
        Get
            Return pisApprovedMayor
        End Get
        Set(ByVal value As Boolean)
            pisApprovedMayor = value
        End Set
    End Property

    Private pStatus As String
    Public Property Status() As String
        Get
            Return pStatus
        End Get
        Set(ByVal value As String)
            pStatus = value
        End Set
    End Property

    Private pisAdjusted As Boolean
    Public Property isAdjusted() As Boolean
        Get
            Return pisAdjusted
        End Get
        Set(ByVal value As Boolean)
            pisAdjusted = value
        End Set
    End Property

    Private pisAddForDisbursement As Boolean
    Public Property isAddForDisbursement() As Boolean
        Get
            Return pisAddForDisbursement
        End Get
        Set(ByVal value As Boolean)
            pisAddForDisbursement = value
        End Set
    End Property

    Private pisPayrollATM As Boolean
    Public Property isPayrollATM() As Boolean
        Get
            Return pisPayrollATM
        End Get
        Set(ByVal value As Boolean)
            pisPayrollATM = value
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

    Private pisReceivedMayor As Boolean
    Public Property isReceivedMayor() As Boolean
        Get
            Return pisReceivedMayor
        End Get
        Set(ByVal value As Boolean)
            pisReceivedMayor = value
        End Set
    End Property

    Private pDateDisapprovedMayor As Date
    Public Property DateDisapprovedMayor() As Date
        Get
            Return pDateDisapprovedMayor
        End Get
        Set(ByVal value As Date)
            pDateDisapprovedMayor = value
        End Set
    End Property

    Private pDateApprovedMayor As Date
    Public Property DateApprovedMayor() As Date
        Get
            Return pDateApprovedMayor
        End Get
        Set(ByVal value As Date)
            pDateApprovedMayor = value
        End Set
    End Property

    Private pDateReceivedMayor As Date
    Public Property DateReceivedMayor() As Date
        Get
            Return pDateReceivedMayor
        End Get
        Set(ByVal value As Date)
            pDateReceivedMayor = value
        End Set
    End Property
    Private pdateCancelled As Date
    Public Property dateCancelled() As Date
        Get
            Return pdateCancelled
        End Get
        Set(ByVal value As Date)
            pdateCancelled = value
        End Set
    End Property

    Private pdateReceived As Date
    Public Property dateReceived() As Date
        Get
            Return pdateReceived
        End Get
        Set(ByVal value As Date)
            pdateReceived = value
        End Set
    End Property

    Private pisReceivedBO As Boolean
    Public Property isReceivedBO() As Boolean
        Get
            Return pisReceivedBO
        End Get
        Set(ByVal value As Boolean)
            pisReceivedBO = value
        End Set
    End Property


    Private pBudget_Year As Integer
    Public Property Budget_Year() As Integer
        Get
            Return pBudget_Year
        End Get
        Set(ByVal value As Integer)
            pBudget_Year = value
        End Set
    End Property

    Private pPayeeOffice As String
    Public Property PayeeOffice() As String
        Get
            Return pPayeeOffice
        End Get
        Set(ByVal value As String)
            pPayeeOffice = value
        End Set
    End Property
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@OBR_Hdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@TempOBR_No", TempOBR_No)
        objDerived.cmd.Parameters.AddWithValue("@OBR_No", OBR_No)
        objDerived.cmd.Parameters.AddWithValue("@F_ID_Accntg", F_ID_Accntg)
        objDerived.cmd.Parameters.AddWithValue("@Period_key", Period_key)
        objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", PRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@OBR_Date", OBR_Date)
        objDerived.cmd.Parameters.AddWithValue("@OBR_Title", OBR_Title)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@Payee", Payee)
        objDerived.cmd.Parameters.AddWithValue("@Func_per_Office_ID", Func_per_Office_ID)
        objDerived.cmd.Parameters.AddWithValue("@Address", Address)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@Signatory1_ID", Signatory1_ID)
        objDerived.cmd.Parameters.AddWithValue("@DateSigned1", DateSigned1)
        objDerived.cmd.Parameters.AddWithValue("@Signatory2_ID", Signatory2_ID)
        objDerived.cmd.Parameters.AddWithValue("@DateSigned2", DateSigned2)
        objDerived.cmd.Parameters.AddWithValue("@isCancelled", isCancelled)
        objDerived.cmd.Parameters.AddWithValue("@isApproved", isApproved)
        objDerived.cmd.Parameters.AddWithValue("@isPayroll", isPayroll)
        objDerived.cmd.Parameters.AddWithValue("@isApprovedMayor", isApprovedMayor)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@isAdjusted", isAdjusted)
        objDerived.cmd.Parameters.AddWithValue("@isAddForDisbursement", isAddForDisbursement)
        objDerived.cmd.Parameters.AddWithValue("@isPayrollATM", isPayrollATM)
        objDerived.cmd.Parameters.AddWithValue("@pr_invoice_hdr_id", pr_invoice_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@pr_period_key_id", pr_period_key_id)
        objDerived.cmd.Parameters.AddWithValue("@isGasoline", isGasoline)
        objDerived.cmd.Parameters.AddWithValue("@isReceivedMayor", isReceivedMayor)
        objDerived.cmd.Parameters.AddWithValue("@DateDisapprovedMayor", DateDisapprovedMayor)
        objDerived.cmd.Parameters.AddWithValue("@DateApprovedMayor", DateApprovedMayor)
        objDerived.cmd.Parameters.AddWithValue("@DateReceivedMayor", DateReceivedMayor)
        objDerived.cmd.Parameters.AddWithValue("@Budget_Year", Budget_Year)
        objDerived.cmd.Parameters.AddWithValue("@PayeeOffice", PayeeOffice)
        'objDerived.cmd.Parameters.AddWithValue("@dateReceived", dateReceived)
        'objDerived.cmd.Parameters.AddWithValue("@isReceivedBO", isReceivedBO)
        'objDerived.cmd.Parameters.AddWithValue("@dateCancelled", dateCancelled)
        'objDerived.cmd.Parameters.AddWithValue("@dateReceived", dateReceived)
        objDerived.cmd.Parameters.AddWithValue("@isReceivedBO", isReceivedBO)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "LnkdSrvrBOSS.GEOBOS.BOS.spSave_T_OBR_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
