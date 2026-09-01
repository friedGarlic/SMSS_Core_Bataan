Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class Bid_information
    Inherits BaseDLL.BaseDAL

#Region "property"

    Private pBid_ID As Long
    Public Property Bid_ID() As Long
        Get
            Return pBid_ID
        End Get
        Set(ByVal value As Long)
            pBid_ID = value
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

    Private pArticle As String
    Public Property Article() As String
        Get
            Return pArticle
        End Get
        Set(ByVal value As String)
            pArticle = value
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

    Private pSupplier_ID As Long
    Public Property Supplier_ID() As Long
        Get
            Return pSupplier_ID
        End Get
        Set(ByVal value As Long)
            pSupplier_ID = value
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


    Private pNOA_Date As Date
    Public Property NOA_Date() As Date
        Get
            Return pNOA_Date
        End Get
        Set(ByVal value As Date)
            pNOA_Date = value
        End Set
    End Property

    Private pNOA_ApprovedBy As String
    Public Property NOA_ApprovedBy() As String
        Get
            Return pNOA_ApprovedBy
        End Get
        Set(ByVal value As String)
            pNOA_ApprovedBy = value
        End Set
    End Property

    Private pNOA_ApprovedBy_Position As String
    Public Property NOA_ApprovedBy_Position() As String
        Get
            Return pNOA_ApprovedBy_Position
        End Get
        Set(ByVal value As String)
            pNOA_ApprovedBy_Position = value
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

    Private pwithNTP As Boolean
    Public Property withNTP() As Boolean
        Get
            Return pwithNTP
        End Get
        Set(ByVal value As Boolean)
            pwithNTP = value
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

    Private pNTP_ApprovedBy As String
    Public Property NTP_ApprovedBy() As String
        Get
            Return pNTP_ApprovedBy
        End Get
        Set(ByVal value As String)
            pNTP_ApprovedBy = value
        End Set
    End Property

    Private pNTP_ApprovedBy_Position As String
    Public Property NTP_ApprovedBy_Position() As String
        Get
            Return pNTP_ApprovedBy_Position
        End Get
        Set(ByVal value As String)
            pNTP_ApprovedBy_Position = value
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

    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set
    End Property



#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Bid_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Article", Article)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)

        If Supplier_ID = 0 Then
            Throw New Exception("Supplier ID is missing. Cannot save.")
        End If


        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@withNOA", withNOA)
        objDerived.cmd.Parameters.AddWithValue("@NOA_Date", NOA_Date)
        objDerived.cmd.Parameters.AddWithValue("@NOA_ApprovedBy", NOA_ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@NOA_ApprovedBy_Position", NOA_ApprovedBy_Position)
        objDerived.cmd.Parameters.AddWithValue("@withPO", withPO)
        objDerived.cmd.Parameters.AddWithValue("@withNTP", withNTP)
        objDerived.cmd.Parameters.AddWithValue("@NTP_Date", NTP_Date)
        objDerived.cmd.Parameters.AddWithValue("@NTP_ApprovedBy", NTP_ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@NTP_ApprovedBy_Position", NTP_ApprovedBy_Position)
        objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[sp_Bid_Information]", CommandType.StoredProcedure, Nothing)
        Return i

    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Bid_ID", Bid_ID)
        objDerived.cmd.Parameters.AddWithValue("@pre_procurement_hdr_id", pre_procurement_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Article", Article)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@withNOA", withNOA)
        objDerived.cmd.Parameters.AddWithValue("@NOA_Date", NOA_Date)
        objDerived.cmd.Parameters.AddWithValue("@NOA_ApprovedBy", NOA_ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@NOA_ApprovedBy_Position", NOA_ApprovedBy_Position)
        objDerived.cmd.Parameters.AddWithValue("@withPO", withPO)
        objDerived.cmd.Parameters.AddWithValue("@withNTP", withNTP)
        objDerived.cmd.Parameters.AddWithValue("@NTP_Date", NTP_Date)
        objDerived.cmd.Parameters.AddWithValue("@NTP_ApprovedBy", NTP_ApprovedBy)
        objDerived.cmd.Parameters.AddWithValue("@NTP_ApprovedBy_Position", NTP_ApprovedBy_Position)
        objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "[AMS].[sp_Bid_Information]", CommandType.StoredProcedure, Nothing)
        Return i

    End Function
End Class
