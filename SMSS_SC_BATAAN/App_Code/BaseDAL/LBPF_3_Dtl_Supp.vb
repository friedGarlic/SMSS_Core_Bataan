Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class LBPF_3_Dtl_Supp
    Inherits BaseDAL

    Private pLBPF_3_Dtl_ID As Long
    Public Property LBPF_3_Dtl_ID() As Long
        Get
            Return pLBPF_3_Dtl_ID
        End Get
        Set(ByVal value As Long)
            pLBPF_3_Dtl_ID = value
        End Set
    End Property

    Private pLBPF_3_Hdr_ID As Long
    Public Property LBPF_3_Hdr_ID() As Long
        Get
            Return pLBPF_3_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pLBPF_3_Hdr_ID = value
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

    Private pBGA_ID As Long
    Public Property BGA_ID() As Long
        Get
            Return pBGA_ID
        End Get
        Set(ByVal value As Long)
            pBGA_ID = value
        End Set
    End Property

    Private pPastYear_Amount As Decimal
    Public Property PastYear_Amount() As Decimal
        Get
            Return pPastYear_Amount
        End Get
        Set(ByVal value As Decimal)
            pPastYear_Amount = value
        End Set
    End Property

    Private pCurrentYear_Amount As Decimal
    Public Property CurrentYear_Amount() As Decimal
        Get
            Return pCurrentYear_Amount
        End Get
        Set(ByVal value As Decimal)
            pCurrentYear_Amount = value
        End Set
    End Property

    Private pProposedAmount As Decimal
    Public Property ProposedAmount() As Decimal
        Get
            Return pProposedAmount
        End Get
        Set(ByVal value As Decimal)
            pProposedAmount = value
        End Set
    End Property

    Private pApprovedAmount As Decimal
    Public Property ApprovedAmount() As Decimal
        Get
            Return pApprovedAmount
        End Get
        Set(ByVal value As Decimal)
            pApprovedAmount = value
        End Set
    End Property

    Private pApprovedFinal As Decimal
    Public Property ApprovedFinal() As Decimal
        Get
            Return pApprovedFinal
        End Get
        Set(ByVal value As Decimal)
            pApprovedFinal = value
        End Set
    End Property

    Private pAllotmentClass_ID As Long
    Public Property AllotmentClass_ID() As Long
        Get
            Return pAllotmentClass_ID
        End Get
        Set(ByVal value As Long)
            pAllotmentClass_ID = value
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

    Public Overrides Sub FillEntity()
        Try
            'fill entity statements here
            With Me
                .LBPF_3_Dtl_ID = IIf(IsDBNull(rd("LBPF_3_Dtl_ID")), 0, rd("LBPF_3_Dtl_ID"))
                .LBPF_3_Hdr_ID = IIf(IsDBNull(rd("LBPF_3_Hdr_ID")), 0, rd("LBPF_3_Hdr_ID"))
                .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                .PastYear_Amount = IIf(IsDBNull(rd("PastYear_Amount")), 0.0, rd("PastYear_Amount"))
                .CurrentYear_Amount = IIf(IsDBNull(rd("CurrentYear_Amount")), 0.0, rd("CurrentYear_Amount"))
                .ProposedAmount = IIf(IsDBNull(rd("ProposedAmount")), 0.0, rd("ProposedAmount"))
                .ApprovedAmount = IIf(IsDBNull(rd("ApprovedAmount")), 0.0, rd("ApprovedAmount"))
                .ApprovedFinal = IIf(IsDBNull(rd("ApprovedFinal")), 0.0, rd("ApprovedFinal"))
                .AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
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
            .cmd.Parameters.AddWithValue("@LBPF_3_Dtl_ID", 0)
            .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@PastYear_Amount", pPastYear_Amount)
            .cmd.Parameters.AddWithValue("@CurrentYear_Amount", pCurrentYear_Amount)
            .cmd.Parameters.AddWithValue("@ProposedAmount", pProposedAmount)
            .cmd.Parameters.AddWithValue("@ApprovedAmount", pApprovedAmount)
            .cmd.Parameters.AddWithValue("@ApprovedFinal", pApprovedFinal)
            .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("BOS.spSave_LBPF_3_Dtl_Supplemental", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub update()
        With Me
            .cmd.Parameters.AddWithValue("@LBPF_3_Dtl_ID", pLBPF_3_Dtl_ID)
            .cmd.Parameters.AddWithValue("@LBPF_3_Hdr_ID", pLBPF_3_Hdr_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@PastYear_Amount", pPastYear_Amount)
            .cmd.Parameters.AddWithValue("@CurrentYear_Amount", pCurrentYear_Amount)
            .cmd.Parameters.AddWithValue("@ProposedAmount", pProposedAmount)
            .cmd.Parameters.AddWithValue("@ApprovedAmount", pApprovedAmount)
            .cmd.Parameters.AddWithValue("@ApprovedFinal", pApprovedFinal)
            .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "BOS.spSave_LBPF_3_Dtl_Supplemental", Data.CommandType.StoredProcedure)
    End Sub
End Class



