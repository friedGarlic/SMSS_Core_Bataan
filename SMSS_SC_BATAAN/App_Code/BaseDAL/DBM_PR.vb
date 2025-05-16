Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace DBM_PR

#Region "DBM_PR"

    Public Class DBM_PR
        Inherits BaseDLL.BaseDAL

        Private pDBM_ID As Long
        Public Property DBM_ID() As Long
            Get
                Return pDBM_ID
            End Get
            Set(ByVal value As Long)
                pDBM_ID = value
            End Set
        End Property

        Private pPRDBM_Date As Date
        Public Property PRDBM_Date() As Date
            Get
                Return pPRDBM_Date
            End Get
            Set(ByVal value As Date)
                pPRDBM_Date = value
            End Set
        End Property

        Private pYear As Integer
        Public Property Year() As Integer
            Get
                Return pYear
            End Get
            Set(ByVal value As Integer)
                pYear = value
            End Set
        End Property

        Private pQuarter As Integer
        Public Property Quarter() As Integer
            Get
                Return pQuarter
            End Get
            Set(ByVal value As Integer)
                pQuarter = value
            End Set
        End Property


        Private pTotalAmount As Decimal
        Public Property TotalAmount() As Decimal
            Get
                Return pTotalAmount
            End Get
            Set(ByVal value As Decimal)
                pTotalAmount = value
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

        Private pApprovedBy As String
        Public Property ApprovedBy() As String
            Get
                Return pApprovedBy
            End Get
            Set(ByVal value As String)
                pApprovedBy = value
            End Set
        End Property

        Private pRequestedBy As String
        Public Property RequestedBy() As String
            Get
                Return pRequestedBy
            End Get
            Set(ByVal value As String)
                pRequestedBy = value
            End Set
        End Property

        Private pBAC_Secretariat As String
        Public Property BAC_Secretariat() As String
            Get
                Return pBAC_Secretariat
            End Get
            Set(ByVal value As String)
                pBAC_Secretariat = value
            End Set
        End Property

        Private pBAC_HeadSecretariat As String
        Public Property BAC_HeadSecretariat() As String
            Get
                Return pBAC_HeadSecretariat
            End Get
            Set(ByVal value As String)
                pBAC_HeadSecretariat = value
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


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DBM_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@PRDBM_Date", PRDBM_Date)
            objDerived.cmd.Parameters.AddWithValue("@Year", Year)
            objDerived.cmd.Parameters.AddWithValue("@Quarter", Quarter)
            objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
            objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
            objDerived.cmd.Parameters.AddWithValue("@RequestedBy", RequestedBy)
            objDerived.cmd.Parameters.AddWithValue("@BAC_HeadSecretariat", BAC_HeadSecretariat)
            objDerived.cmd.Parameters.AddWithValue("@BAC_Secretariat", BAC_Secretariat)
            objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", PRHdr_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_DBM_PR]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DBM_ID", DBM_ID)
            objDerived.cmd.Parameters.AddWithValue("@PRDBM_Date", PRDBM_Date)
            objDerived.cmd.Parameters.AddWithValue("@Year", Year)
            objDerived.cmd.Parameters.AddWithValue("@Quarter", Quarter)
            objDerived.cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount)
            objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
            objDerived.cmd.Parameters.AddWithValue("@ApprovedBy", ApprovedBy)
            objDerived.cmd.Parameters.AddWithValue("@RequestedBy", RequestedBy)
            objDerived.cmd.Parameters.AddWithValue("@BAC_HeadSecretariat", BAC_HeadSecretariat)
            objDerived.cmd.Parameters.AddWithValue("@BAC_Secretariat", BAC_Secretariat)
            objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", PRHdr_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_DBM_PR]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

#Region "DBM_PR_Dtl"

    Public Class DBM_PR_Dtl
        Inherits BaseDLL.BaseDAL

        Private pDBM_Dtl_ID As Long
        Public Property DBM_Dtl_ID() As Long
            Get
                Return pDBM_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pDBM_Dtl_ID = value
            End Set
        End Property

        Private pDBM_ID As Long
        Public Property DBM_ID() As Long
            Get
                Return pDBM_ID
            End Get
            Set(ByVal value As Long)
                pDBM_ID = value
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


        Private pItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return pItem_ID
            End Get
            Set(ByVal value As Long)
                pItem_ID = value
            End Set
        End Property

        Private pQty As Integer
        Public Property Qty() As Integer
            Get
                Return pQty
            End Get
            Set(ByVal value As Integer)
                pQty = value
            End Set
        End Property


        Private pCost As Decimal
        Public Property Cost() As Decimal
            Get
                Return pCost
            End Get
            Set(ByVal value As Decimal)
                pCost = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DBM_Dtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@DBM_ID", DBM_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_DBM_PR_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@DBM_Dtl_ID", DBM_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@DBM_ID", DBM_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_DBM_PR_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region

End Namespace


