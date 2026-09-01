Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class LBEF_2_Hdr
    Inherits BaseDAL
#Region "propertry"
    Private pLBEF_2_Hdr_ID As Long
    Public Property LBEF_2_Hdr_ID() As Long
        Get
            Return pLBEF_2_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pLBEF_2_Hdr_ID = value
        End Set
    End Property

    Private pARO_No As String
    Public Property ARO_No() As String
        Get
            Return pARO_No
        End Get
        Set(ByVal value As String)
            pARO_No = value
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

    Private pAppropriationSource_ID As Long
    Public Property AppropriationSource_ID() As Long
        Get
            Return pAppropriationSource_ID
        End Get
        Set(ByVal value As Long)
            pAppropriationSource_ID = value
        End Set
    End Property

    Private pAllotmentType_ID As Long
    Public Property AllotmentType_ID() As Long
        Get
            Return pAllotmentType_ID
        End Get
        Set(ByVal value As Long)
            pAllotmentType_ID = value
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

    Private pF_ID As Long
    Public Property F_ID() As Long
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Long)
            pF_ID = value
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

    Private pDateIssued As DateTime
    Public Property DateIssued() As DateTime
        Get
            Return pDateIssued
        End Get
        Set(ByVal value As DateTime)
            pDateIssued = value
        End Set
    End Property

    Private pPurpose As String
    Public Property Purpose() As String
        Get
            Return pPurpose
        End Get
        Set(ByVal value As String)
            pPurpose = value
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

    Private pAmountInWords As String
    Public Property AmountInWords() As String
        Get
            Return pAmountInWords
        End Get
        Set(ByVal value As String)
            pAmountInWords = value
        End Set
    End Property

    Private pNotes As String
    Public Property Notes() As String
        Get
            Return pNotes
        End Get
        Set(ByVal value As String)
            pNotes = value
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

    Private pDateSigned As DateTime
    Public Property DateSigned() As DateTime
        Get
            Return pDateSigned
        End Get
        Set(ByVal value As DateTime)
            pDateSigned = value
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

    Private pSignatory2_ID As Integer
    Public Property Signatory2_ID() As Integer
        Get
            Return pSignatory2_ID
        End Get
        Set(ByVal value As Integer)
            pSignatory2_ID = value
        End Set
    End Property

    Private pSignatory3_ID As Integer
    Public Property Signatory3_ID() As Integer
        Get
            Return pSignatory3_ID
        End Get
        Set(ByVal value As Integer)
            pSignatory3_ID = value
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

    Private pisAdjustment As Boolean
    Public Property isAdjustment() As Boolean
        Get
            Return pisAdjustment
        End Get
        Set(ByVal value As Boolean)
            pisAdjustment = value
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
                .LBEF_2_Hdr_ID = IIf(IsDBNull(rd("LBEF_2_Hdr_ID")), 0, rd("LBEF_2_Hdr_ID"))
                .ARO_No = IIf(IsDBNull(rd("ARO_No")), "", rd("ARO_No"))
                .Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                .AppropriationSource_ID = IIf(IsDBNull(rd("AppropriationSource_ID")), 0, rd("AppropriationSource_ID"))
                .AllotmentType_ID = IIf(IsDBNull(rd("AllotmentType_ID")), 0, rd("AllotmentType_ID"))
                .Quarter = IIf(IsDBNull(rd("Quarter")), 0, rd("Quarter"))
                .F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                .RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
                .Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                .Program_ID = IIf(IsDBNull(rd("Program_ID")), 0, rd("Program_ID"))
                .Project_ID = IIf(IsDBNull(rd("Project_ID")), 0, rd("Project_ID"))
                .DateIssued = IIf(IsDBNull(rd("DateIssued")), "", rd("DateIssued"))
                .Purpose = IIf(IsDBNull(rd("Purpose")), "", rd("Purpose"))
                .TotalAmount = IIf(IsDBNull(rd("TotalAmount")), 0.0, rd("TotalAmount"))
                .AmountInWords = IIf(IsDBNull(rd("AmountInWords")), "", rd("AmountInWords"))
                .Notes = IIf(IsDBNull(rd("Notes")), "", rd("Notes"))
                .Signatory1_ID = IIf(IsDBNull(rd("Signatory1_ID")), 0, rd("Signatory1_ID"))
                .DateSigned = IIf(IsDBNull(rd("DateSigned")), "", rd("DateSigned"))
                .isApproved = IIf(IsDBNull(rd("isApproved")), 0, rd("isApproved"))
                .Signatory2_ID = IIf(IsDBNull(rd("Signatory2_ID")), 0, rd("Signatory2_ID"))
                .Signatory3_ID = IIf(IsDBNull(rd("Signatory3_ID")), 0, rd("Signatory3_ID"))
                .isContinuing = IIf(IsDBNull(rd("isContinuing")), 0, rd("isContinuing"))
                .isAdjustment = IIf(IsDBNull(rd("isAdjustment")), 0, rd("isAdjustment"))
                .AdjustmentType_ID = IIf(IsDBNull(rd("AdjustmentType_ID")), 0, rd("AdjustmentType_ID"))
                .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                '   .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))

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
            .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", 0)
            .cmd.Parameters.AddWithValue("@ARO_No", pARO_No)
            .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            .cmd.Parameters.AddWithValue("@AllotmentType_ID", pAllotmentType_ID)
            .cmd.Parameters.AddWithValue("@Quarter", pQuarter)
            .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            .cmd.Parameters.AddWithValue("@DateIssued", pDateIssued)
            .cmd.Parameters.AddWithValue("@Purpose", pPurpose)
            .cmd.Parameters.AddWithValue("@TotalAmount", pTotalAmount)
            .cmd.Parameters.AddWithValue("@AmountInWords", pAmountInWords)
            .cmd.Parameters.AddWithValue("@Notes", pNotes)
            .cmd.Parameters.AddWithValue("@Signatory1_ID", pSignatory1_ID)
            .cmd.Parameters.AddWithValue("@DateSigned", pDateSigned)
            .cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            .cmd.Parameters.AddWithValue("@Signatory2_ID", pSignatory2_ID)
            .cmd.Parameters.AddWithValue("@Signatory3_ID", pSignatory3_ID)
            .cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            .cmd.Parameters.AddWithValue("@isAdjustment", pisAdjustment)
            .cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With
        Execute("BOS.spSave_LBEF_2_Hdr", Data.CommandType.StoredProcedure)
    End Sub
    Public Sub update()
        With Me
            .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
            .cmd.Parameters.AddWithValue("@ARO_No", pARO_No)
            .cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
            .cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
            .cmd.Parameters.AddWithValue("@AllotmentType_ID", pAllotmentType_ID)
            .cmd.Parameters.AddWithValue("@Quarter", pQuarter)
            .cmd.Parameters.AddWithValue("@F_ID", pF_ID)
            .cmd.Parameters.AddWithValue("@RC_ID", pRC_ID)
            .cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
            .cmd.Parameters.AddWithValue("@Program_ID", pProgram_ID)
            .cmd.Parameters.AddWithValue("@Project_ID", pProject_ID)
            .cmd.Parameters.AddWithValue("@DateIssued", pDateIssued)
            .cmd.Parameters.AddWithValue("@Purpose", pPurpose)
            .cmd.Parameters.AddWithValue("@TotalAmount", pTotalAmount)
            .cmd.Parameters.AddWithValue("@AmountInWords", pAmountInWords)
            .cmd.Parameters.AddWithValue("@Notes", pNotes)
            .cmd.Parameters.AddWithValue("@Signatory1_ID", pSignatory1_ID)
            .cmd.Parameters.AddWithValue("@DateSigned", pDateSigned)
            .cmd.Parameters.AddWithValue("@isApproved", pisApproved)
            .cmd.Parameters.AddWithValue("@Signatory2_ID", pSignatory2_ID)
            .cmd.Parameters.AddWithValue("@Signatory3_ID", pSignatory3_ID)
            .cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)
            .cmd.Parameters.AddWithValue("@isAdjustment", pisAdjustment)
            .cmd.Parameters.AddWithValue("@AdjustmentType_ID", pAdjustmentType_ID)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With
        Execute("@CurrID", "BOS.spSave_LBEF_2_Hdr", Data.CommandType.StoredProcedure)
    End Sub
End Class


