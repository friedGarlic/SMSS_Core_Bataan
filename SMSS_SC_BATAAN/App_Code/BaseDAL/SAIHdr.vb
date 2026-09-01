Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class SAIHdr

    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pSAIHdr_ID As Integer
    Public Property SAIHdr_ID() As Integer
        Get
            Return pSAIHdr_ID
        End Get
        Set(ByVal value As Integer)
            pSAIHdr_ID = value
        End Set
    End Property

    Private pSAI_No As String
    Public Property SAI_No() As String
        Get
            Return pSAI_No
        End Get
        Set(ByVal value As String)
            pSAI_No = value
        End Set
    End Property

    Private pSAI_date As DateTime
    Public Property SAI_date() As DateTime
        Get
            Return pSAI_date
        End Get
        Set(ByVal value As DateTime)
            pSAI_date = value
        End Set
    End Property

    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
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

    Private pInquiryby As String
    Public Property Inquiryby() As String
        Get
            Return pInquiryby
        End Get
        Set(ByVal value As String)
            pInquiryby = value
        End Set
    End Property

    Private pProvidedby As String
    Public Property Providedby() As String
        Get
            Return pProvidedby
        End Get
        Set(ByVal value As String)
            pProvidedby = value
        End Set
    End Property

    Private pwRIS As Boolean
    Public Property wRIS() As Boolean
        Get
            Return pwRIS
        End Get
        Set(ByVal value As Boolean)
            pwRIS = value
        End Set
    End Property








#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.SAIHdr_ID = IIf(IsDBNull(rd("SAIHdr_ID")), 0, rd("SAIHdr_ID"))
            Me.SAI_No = IIf(IsDBNull(rd("SAI_No")), "", rd("SAI_No"))
            Me.SAI_date = IIf(IsDBNull(rd("SAI_date")), "", rd("SAI_date"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))
            Me.Inquiryby = IIf(IsDBNull(rd("Inquiryby")), "", rd("Inquiryby"))
            Me.Providedby = IIf(IsDBNull(rd("Providedby")), "", rd("Providedby"))
            Me.wRIS = IIf(IsDBNull(rd("wRIS")), 0, rd("wRIS"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Function saveSAIHdr() As Long


        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long

        objDerived.cmd.Parameters.AddWithValue("@SAIHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@SAI_No", SAI_No)
        objDerived.cmd.Parameters.AddWithValue("@SAI_date", SAI_date)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@Inquiryby", Inquiryby)
        objDerived.cmd.Parameters.AddWithValue("@Providedby", Providedby)
        objDerived.cmd.Parameters.AddWithValue("@wRIS", wRIS)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_SAI_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
