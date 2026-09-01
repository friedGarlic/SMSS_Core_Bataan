Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_inspection_and_acceptance_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pAIRHdr_ID As Long
    Public Property AIRHdr_ID() As Long
        Get
            Return pAIRHdr_ID
        End Get
        Set(ByVal value As Long)
            pAIRHdr_ID = value
        End Set
    End Property

    Private pAIR_No As String
    Public Property AIR_No() As String
        Get
            Return pAIR_No
        End Get
        Set(ByVal value As String)
            pAIR_No = value
        End Set
    End Property

    Private pAIR_Date As Date
    Public Property AIR_Date() As Date
        Get
            Return pAIR_Date
        End Get
        Set(ByVal value As Date)
            pAIR_Date = value
        End Set
    End Property

    Private pInvoice_No As String
    Public Property Invoice_No() As String
        Get
            Return pInvoice_No
        End Get
        Set(ByVal value As String)
            pInvoice_No = value
        End Set
    End Property

    Private pInvoice_date As Date
    Public Property Invoice_date() As Date
        Get
            Return pInvoice_date
        End Get
        Set(ByVal value As Date)
            pInvoice_date = value
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

    Private pSupplier_ID As Long
    Public Property Supplier_ID() As Long
        Get
            Return pSupplier_ID
        End Get
        Set(ByVal value As Long)
            pSupplier_ID = value
        End Set
    End Property


    Private pDate_Received As Date
    Public Property Date_Received() As Date
        Get
            Return pDate_Received
        End Get
        Set(ByVal value As Date)
            pDate_Received = value
        End Set
    End Property

    Private pDate_Inspect As Date
    Public Property Date_Inspect() As Date
        Get
            Return pDate_Inspect
        End Get
        Set(ByVal value As Date)
            pDate_Inspect = value
        End Set
    End Property

    Private pDate_Accepted As Date
    Public Property Date_Accepted() As Date
        Get
            Return pDate_Accepted
        End Get
        Set(ByVal value As Date)
            pDate_Accepted = value
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

    Private pSignatory3 As String
    Public Property Signatory3() As String
        Get
            Return pSignatory3
        End Get
        Set(ByVal value As String)
            pSignatory3 = value
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
    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
        End Set
    End Property

    Private pTrans_ID As Long
    Public Property Trans_ID() As Long
        Get
            Return pTrans_ID
        End Get
        Set(ByVal value As Long)
            pTrans_ID = value
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

    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

    Private pReceived_ID As Long
    Public Property Received_ID() As Long
        Get
            Return pReceived_ID
        End Get
        Set(ByVal value As Long)
            pReceived_ID = value
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


    Private pIsPartial As Boolean
    Public Property IsPartial() As Boolean
        Get
            Return pIsPartial
        End Get
        Set(ByVal value As Boolean)
            pIsPartial = value
        End Set
    End Property


    Private pIsInspected As Boolean
    Public Property IsInspected() As Boolean
        Get
            Return pIsInspected
        End Get
        Set(ByVal value As Boolean)
            pIsInspected = value
        End Set
    End Property


    Private pInspectedPersonPos As String
    Public Property InspectedPersonPos() As String
        Get
            Return pInspectedPersonPos
        End Get
        Set(ByVal value As String)
            pInspectedPersonPos = value
        End Set
    End Property


    Private pInspectedPersonPos2 As String
    Public Property InspectedPersonPos2() As String
        Get
            Return pInspectedPersonPos2
        End Get
        Set(ByVal value As String)
            pInspectedPersonPos2 = value
        End Set
    End Property


    Private pAcceptedPersonPos As String
    Public Property AcceptedPersonPos() As String
        Get
            Return pAcceptedPersonPos
        End Get
        Set(ByVal value As String)
            pAcceptedPersonPos = value
        End Set
    End Property

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@AIRHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@AIR_No", AIR_No)
        objDerived.cmd.Parameters.AddWithValue("@AIR_Date", AIR_Date)
        objDerived.cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No)
        objDerived.cmd.Parameters.AddWithValue("@Invoice_date", Invoice_date)
        objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@Date_Received", Date_Received)
        objDerived.cmd.Parameters.AddWithValue("@Date_Inspect", Date_Inspect)
        objDerived.cmd.Parameters.AddWithValue("@Date_Accepted", Date_Accepted)
        objDerived.cmd.Parameters.AddWithValue("@Signatory1", Signatory1)
        objDerived.cmd.Parameters.AddWithValue("@Signatory2", Signatory2)
        objDerived.cmd.Parameters.AddWithValue("@Signatory3", Signatory3)
        objDerived.cmd.Parameters.AddWithValue("@isComplete", isComplete)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Trans_ID", Trans_ID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)

        objDerived.cmd.Parameters.AddWithValue("@isPartial", IsPartial)
        objDerived.cmd.Parameters.AddWithValue("@isInspected", IsInspected)
        objDerived.cmd.Parameters.AddWithValue("@InspectedPersonPos", InspectedPersonPos)
        objDerived.cmd.Parameters.AddWithValue("@InspectedPersonPos2", InspectedPersonPos2)
        objDerived.cmd.Parameters.AddWithValue("@AcceptedPersonPos", AcceptedPersonPos)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_AIR_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@AIRHdr_ID", AIRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@AIR_No", AIR_No)
        objDerived.cmd.Parameters.AddWithValue("@AIR_Date", AIR_Date)
        objDerived.cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No)
        objDerived.cmd.Parameters.AddWithValue("@Invoice_date", Invoice_date)
        objDerived.cmd.Parameters.AddWithValue("@PO_No", PO_No)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@Date_Received", Date_Received)
        objDerived.cmd.Parameters.AddWithValue("@Date_Inspect", Date_Inspect)
        objDerived.cmd.Parameters.AddWithValue("@Date_Accepted", Date_Accepted)
        objDerived.cmd.Parameters.AddWithValue("@Signatory1", Signatory1)
        objDerived.cmd.Parameters.AddWithValue("@Signatory2", Signatory2)
        objDerived.cmd.Parameters.AddWithValue("@Signatory3", Signatory3)
        objDerived.cmd.Parameters.AddWithValue("@isComplete", isComplete)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Trans_ID", Trans_ID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)

        objDerived.cmd.Parameters.AddWithValue("@isPartial", IsPartial)
        objDerived.cmd.Parameters.AddWithValue("@isInspected", IsInspected)
        objDerived.cmd.Parameters.AddWithValue("@InspectedPersonPos", InspectedPersonPos)
        objDerived.cmd.Parameters.AddWithValue("@InspectedPersonPos2", InspectedPersonPos2)
        objDerived.cmd.Parameters.AddWithValue("@AcceptedPersonPos", AcceptedPersonPos)


        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_AIR_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
