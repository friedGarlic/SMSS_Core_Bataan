Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class LBEF_2_Dtl
    Inherits BaseDAL
#Region "property"
    Private pLBEF_2_Dtl_ID As Long
    Public Property LBEF_2_Dtl_ID() As Long
        Get
            Return pLBEF_2_Dtl_ID
        End Get
        Set(ByVal value As Long)
            pLBEF_2_Dtl_ID = value
        End Set
    End Property

    Private pLBEF_2_Hdr_ID As Long
    Public Property LBEF_2_Hdr_ID() As Long
        Get
            Return pLBEF_2_Hdr_ID
        End Get
        Set(ByVal value As Long)
            pLBEF_2_Hdr_ID = value
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

    Private pAllotmentClass_ID As Long
    Public Property AllotmentClass_ID() As Long
        Get
            Return pAllotmentClass_ID
        End Get
        Set(ByVal value As Long)
            pAllotmentClass_ID = value
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
                .LBEF_2_Dtl_ID = IIf(IsDBNull(rd("LBEF_2_Dtl_ID")), 0, rd("LBEF_2_Dtl_ID"))
                .LBEF_2_Hdr_ID = IIf(IsDBNull(rd("LBEF_2_Hdr_ID")), 0, rd("LBEF_2_Hdr_ID"))
                .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                .AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                .Amount = IIf(IsDBNull(rd("Amount")), 0.0, rd("Amount"))
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
            .cmd.Parameters.AddWithValue("@LBEF_2_Dtl_ID", 0)
            .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            .cmd.Parameters.AddWithValue("@Amount", pAmount)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("BOS.spSave_LBEF_2_Dtl", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub update()
        With Me
            .cmd.Parameters.AddWithValue("@LBEF_2_Dtl_ID", pLBEF_2_Dtl_ID)
            .cmd.Parameters.AddWithValue("@LBEF_2_Hdr_ID", pLBEF_2_Hdr_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
            .cmd.Parameters.AddWithValue("@Amount", pAmount)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "BOS.spSave_LBEF_2_Dtl", Data.CommandType.StoredProcedure)
    End Sub
End Class
