Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class m_StraightContract
    Inherits BaseDAL

#Region "property"
    Private pSC_ID As Long
    Public Property SC_ID() As Long
        Get
            Return pSC_ID
        End Get
        Set(ByVal value As Long)
            pSC_ID = value
        End Set
    End Property
    Private pproject_id As Long
    Public Property project_id() As Long
        Get
            Return pproject_id
        End Get
        Set(ByVal value As Long)
            pproject_id = value
        End Set
    End Property

    Private pPreparedBy As String
    Public Property PreparedBy() As String
        Get
            Return pPreparedBy
        End Get
        Set(ByVal value As String)
            pPreparedBy = value
        End Set
    End Property

    Private pRecommendedBy As String
    Public Property RecommendedBy() As String
        Get
            Return pRecommendedBy
        End Get
        Set(ByVal value As String)
            pRecommendedBy = value
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

    Private pisfinal As Boolean
    Public Property isfinal() As Boolean
        Get
            Return pisfinal
        End Get
        Set(ByVal value As Boolean)
            pisfinal = value
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
#End Region

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                With Me
                    .SC_ID = IIf(IsDBNull(rd("SC_ID")), 0, rd("SC_ID"))
                    .project_id = IIf(IsDBNull(rd("project_id")), 0, rd("project_id"))
                    .PreparedBy = IIf(IsDBNull(rd("PreparedBy")), "", rd("PreparedBy"))
                    .RecommendedBy = IIf(IsDBNull(rd("RecommendedBy")), "", rd("RecommendedBy"))
                    .ApprovedBy = IIf(IsDBNull(rd("ApprovedBy")), "", rd("ApprovedBy"))
                    '.issubmit = IIf(IsDBNull(rd("issubmit")), 0, rd("issubmit"))
                    .isfinal = IIf(IsDBNull(rd("isfinal")), 0, rd("isfinal"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                    .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                End With
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub saveSC()
        With Me
            .cmd.Parameters.AddWithValue("@SC_ID", 0)
            .cmd.Parameters.AddWithValue("@project_id", pproject_id)
            .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
            .cmd.Parameters.AddWithValue("@RecommendedBy", pRecommendedBy)
            .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
            '.cmd.Parameters.AddWithValue("@issubmit", pisSubmit)
            .cmd.Parameters.AddWithValue("@isfinal", pisfinal)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("Bos.spSave_m_StraightContract", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub updateSC()
        With Me
            .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
            .cmd.Parameters.AddWithValue("@project_id", pproject_id)
            .cmd.Parameters.AddWithValue("@PreparedBy", pPreparedBy)
            .cmd.Parameters.AddWithValue("@RecommendedBy", pRecommendedBy)
            .cmd.Parameters.AddWithValue("@ApprovedBy", pApprovedBy)
            '.cmd.Parameters.AddWithValue("@issubmit", pisSubmit)
            .cmd.Parameters.AddWithValue("@isfinal", pisfinal)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "Bos.spSave_m_StraightContract", Data.CommandType.StoredProcedure)
    End Sub
End Class
