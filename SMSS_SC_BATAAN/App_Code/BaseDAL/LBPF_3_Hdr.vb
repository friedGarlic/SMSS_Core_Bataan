Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class LBPF_3_Hdr
    Inherits BaseDAL

#Region "Property"
    Private pLBPF_3_Hdr_ID As Long
    Public Property LBPF_3_Hdr_ID() As Long
        Get
            Return pLBPF_3_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pLBPF_3_Hdr_ID = value
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

    Private pProgram_ID As Long
    Public Property Program_ID() As Long
        Get
            Return pProgram_ID
        End Get
        Set(ByVal value As Long)
            pProgram_ID = value
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

    Private pAppropriationSource_ID As Long
    Public Property AppropriationSource_ID() As Long
        Get
            Return pAppropriationSource_ID
        End Get
        Set(ByVal value As Long)
            pAppropriationSource_ID = value
        End Set
    End Property

    Private pAdjustmentType_ID As Long
    Public Property AdjustmentType_ID() As Long
        Get
            Return pAdjustmentType_ID
        End Get
        Set(ByVal value As Long)
            pAdjustmentType_ID = value
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

    Private pBudget_Year As Integer
    Public Property Budget_Year() As Integer
        Get
            Return pBudget_Year
        End Get
        Set(ByVal value As Integer)
            pBudget_Year = value
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

    Private pisPosted As Boolean
    Public Property isPosted() As Boolean
        Get
            Return pisPosted
        End Get
        Set(ByVal value As Boolean)
            pisPosted = value
        End Set
    End Property

    Private pPreparedBy As Integer
    Public Property PreparedBy() As Integer
        Get
            Return pPreparedBy
        End Get
        Set(ByVal value As Integer)
            pPreparedBy = value
        End Set
    End Property

    Private pDatePrepared As DateTime
    Public Property DatePrepared() As DateTime
        Get
            Return pDatePrepared
        End Get
        Set(ByVal value As DateTime)
            pDatePrepared = value
        End Set
    End Property

    Private pReviewedBy As Integer
    Public Property ReviewedBy() As Integer
        Get
            Return pReviewedBy
        End Get
        Set(ByVal value As Integer)
            pReviewedBy = value
        End Set
    End Property

    Private pDateReviewed As DateTime
    Public Property DateReviewed() As DateTime
        Get
            Return pDateReviewed
        End Get
        Set(ByVal value As DateTime)
            pDateReviewed = value
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

    Private pDateApproved As DateTime
    Public Property DateApproved() As DateTime
        Get
            Return pDateApproved
        End Get
        Set(ByVal value As DateTime)
            pDateApproved = value
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

    Private pApp_id As Integer
    Public Property App_id() As Integer
        Get
            Return pApp_id
        End Get
        Set(ByVal value As Integer)
            pApp_id = value
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

    Private pTableName As String
    Public Property TableName() As String
        Get
            Return pTableName
        End Get
        Set(ByVal value As String)
            pTableName = value
        End Set
    End Property

    Private pisSupplemental As Boolean
    Public Property isSupplemental() As Boolean
        Get
            Return pisSupplemental
        End Get
        Set(ByVal value As Boolean)
            pisSupplemental = value
        End Set
    End Property
#End Region

    Public Overrides Sub FillEntity()
        Try
            'fill entity statements here
            With Me
                .LBPF_3_Hdr_ID = IIf(IsDBNull(rd("LBPF_3_Hdr_ID")), 0, rd("LBPF_3_Hdr_ID"))
                .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                .AppropriationSource_ID = IIf(IsDBNull(rd("AppropriationSource_ID")), 0, rd("AppropriationSource_ID"))
                .AdjustmentType_ID = IIf(IsDBNull(rd("AdjustmentType_ID")), 0, rd("AdjustmentType_ID"))
                .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                .isApproved = IIf(IsDBNull(rd("isApproved")), 0, rd("isApproved"))
                .isPosted = IIf(IsDBNull(rd("isPosted")), 0, rd("isPosted"))
                .PreparedBy = IIf(IsDBNull(rd("PreparedBy")), 0, rd("PreparedBy"))
                .DatePrepared = IIf(IsDBNull(rd("DatePrepared")), "", rd("DatePrepared"))
                .ReviewedBy = IIf(IsDBNull(rd("ReviewedBy")), 0, rd("ReviewedBy"))
                .DateReviewed = IIf(IsDBNull(rd("DateReviewed")), "", rd("DateReviewed"))
                .ApprovedBy = IIf(IsDBNull(rd("ApprovedBy")), 0, rd("ApprovedBy"))
                .DateApproved = IIf(IsDBNull(rd("DateApproved")), "", rd("DateApproved"))
                .isFinal = IIf(IsDBNull(rd("isFinal")), 0, rd("isFinal"))
                .App_id = IIf(IsDBNull(rd("App_id")), 0, rd("App_id"))
                .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                .isSupplemental = IIf(IsDBNull(rd("isSupplemental")), 0, rd("isSupplemental"))
                '  .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName")) 
            End With
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub save()
        With Me
            .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", 0)
            .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            .cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            .cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            .cmd.Parameters.AddWithValue("@isPosted", pisPosted)
            .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
            .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
            .cmd.Parameters.AddWithValue("@ReviewedBy", pReviewedBy)
            .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
            .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
            .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
            .cmd.Parameters.AddWithValue("@isFinal", isFinal)
            .cmd.Parameters.AddWithValue("@App_id", App_id)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
            ' .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("BOS.spSave_LBPF_3_Hdr", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub update()
        With Me
            .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
            .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            .cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            .cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            .cmd.Parameters.AddWithValue("@isPosted", pisPosted)
            .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
            .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
            .cmd.Parameters.AddWithValue("@ReviewedBy", pReviewedBy)
            .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
            .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
            .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
            .cmd.Parameters.AddWithValue("@isFinal", pisFinal)
            .cmd.Parameters.AddWithValue("@App_id", pApp_id)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@isSupplemental", isSupplemental)
            '  .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "BOS.spSave_LBPF_3_Hdr", Data.CommandType.StoredProcedure)
    End Sub
End Class


