Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class AIP_Records
    Inherits BaseDAL

#Region "Property"
    Private pAIP_ID As Long
    Public Property AIP_ID() As Long
        Get
            Return pAIP_ID
        End Get
        Set(ByVal value As Long)
            pAIP_ID = value
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

    Private pisFinal As Boolean
    Public Property isFinal() As Boolean
        Get
            Return pisFinal
        End Get
        Set(ByVal value As Boolean)
            pisFinal = value
        End Set
    End Property

    Private pPreparedByID As Long
    Public Property PreparedByID() As Long
        Get
            Return pPreparedByID
        End Get
        Set(ByVal value As Long)
            pPreparedByID = value
        End Set
    End Property

    Private pReviewedByID As Long
    Public Property ReviewedByID() As Long
        Get
            Return pReviewedByID
        End Get
        Set(ByVal value As Long)
            pReviewedByID = value
        End Set
    End Property

    Private pApprovedByID As Long
    Public Property ApprovedByID() As Long
        Get
            Return pApprovedByID
        End Get
        Set(ByVal value As Long)
            pApprovedByID = value
        End Set
    End Property

    Private pDatePrepared As Date
    Public Property DatePrepared() As Date
        Get
            Return pDatePrepared
        End Get
        Set(ByVal value As Date)
            pDatePrepared = value
        End Set
    End Property

    Private pDateReviewed As Date
    Public Property DateReviewed() As Date
        Get
            Return pDateReviewed
        End Get
        Set(ByVal value As Date)
            pDateReviewed = value
        End Set
    End Property

    Private pDateApproved As Date
    Public Property DateApproved() As Date
        Get
            Return pDateApproved
        End Get
        Set(ByVal value As Date)
            pDateApproved = value
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


    Public Overrides Sub FillEntity()
        Try
            'fill entity statements here
            With Me
                .AIP_ID = IIf(IsDBNull(rd("AIP_ID")), 0, rd("AIP_ID"))
                .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), 0, rd("Budget_Year"))
                .isFinal = IIf(IsDBNull(rd("isFinal")), 0, rd("isFinal"))
                .PreparedByID = IIf(IsDBNull(rd("PreparedByID")), 0, rd("PreparedByID"))
                .ReviewedByID = IIf(IsDBNull(rd("ReviewedByID")), 0, rd("ReviewedByID"))
                .ApprovedByID = IIf(IsDBNull(rd("ApprovedByID")), 0, rd("ApprovedByID"))
                .DatePrepared = IIf(IsDBNull(rd("DatePrepared")), "", rd("DatePrepared"))
                .DateReviewed = IIf(IsDBNull(rd("DateReviewed")), "", rd("DateReviewed"))
                .DateApproved = IIf(IsDBNull(rd("DateApproved")), "", rd("DateApproved"))
                .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
            End With
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub saveAIPRecords()
        With Me
            .cmd.Parameters.AddWithValue("@AIP_ID", 0)
            .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            .cmd.Parameters.AddWithValue("@isFinal", pisFinal)
            .cmd.Parameters.AddWithValue("@PreparedByID", pPreparedByID)
            .cmd.Parameters.AddWithValue("@ReviewedByID", pReviewedByID)
            .cmd.Parameters.AddWithValue("@ApprovedByID", pApprovedByID)
            .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
            .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
            .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("dbo.spSave_AIP_Records", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub updateAIPRecords()
        With Me
            .cmd.Parameters.AddWithValue("@AIP_ID", pAIP_ID)
            .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            .cmd.Parameters.AddWithValue("@isFinal", pisFinal)
            .cmd.Parameters.AddWithValue("@PreparedByID", pPreparedByID)
            .cmd.Parameters.AddWithValue("@ReviewedByID", pReviewedByID)
            .cmd.Parameters.AddWithValue("@ApprovedByID", pApprovedByID)
            .cmd.Parameters.AddWithValue("@DatePrepared", pDatePrepared)
            .cmd.Parameters.AddWithValue("@DateReviewed", pDateReviewed)
            .cmd.Parameters.AddWithValue("@DateApproved", pDateApproved)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "dbo.spSave_AIP_Records", Data.CommandType.StoredProcedure)
    End Sub

End Class
