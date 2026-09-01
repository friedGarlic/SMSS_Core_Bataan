Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class RISHdr

    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pRISHdr_ID As Integer
    Public Property RISHdr_ID() As Integer
        Get
            Return pRISHdr_ID
        End Get
        Set(ByVal value As Integer)
            pRISHdr_ID = value
        End Set
    End Property

    Private pRIS_No As String
    Public Property RIS_No() As String
        Get
            Return pRIS_No
        End Get
        Set(ByVal value As String)
            pRIS_No = value
        End Set
    End Property

    Private pRISDate As DateTime
    Public Property RISDate() As DateTime
        Get
            Return pRISDate
        End Get
        Set(ByVal value As DateTime)
            pRISDate = value
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

    Private pPurpose As String
    Public Property Purpose() As String
        Get
            Return pPurpose
        End Get
        Set(ByVal value As String)
            pPurpose = value
        End Set
    End Property

    Private pRequested_By As String
    Public Property Requested_By() As String
        Get
            Return pRequested_By
        End Get
        Set(ByVal value As String)
            pRequested_By = value
        End Set
    End Property

    Private pApproved_By As String
    Public Property Approved_By() As String
        Get
            Return pApproved_By
        End Get
        Set(ByVal value As String)
            pApproved_By = value
        End Set
    End Property

    Private pIssued_By As String
    Public Property Issued_By() As String
        Get
            Return pIssued_By
        End Get
        Set(ByVal value As String)
            pIssued_By = value
        End Set
    End Property

    Private pReceived_By As String
    Public Property Received_By() As String
        Get
            Return pReceived_By
        End Get
        Set(ByVal value As String)
            pReceived_By = value
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

    Private pFunc_ID As Long
    Public Property Func_ID() As Long
        Get
            Return pFunc_ID
        End Get
        Set(ByVal value As Long)
            pFunc_ID = value
        End Set
    End Property

    Private pF_ID As Integer
    Public Property F_ID() As Integer
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Integer)
            pF_ID = value
        End Set
    End Property

    Private pwithICS As Boolean
    Public Property withICS() As Boolean
        Get
            Return pwithICS
        End Get
        Set(ByVal value As Boolean)
            pwithICS = value
        End Set
    End Property


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.RISHdr_ID = IIf(IsDBNull(rd("RISHdr_ID")), 0, rd("RISHdr_ID"))
            Me.RIS_No = IIf(IsDBNull(rd("RIS_No")), "", rd("RIS_No"))
            Me.RISDate = IIf(IsDBNull(rd("RISDate")), "", rd("RISDate"))
            Me.SAI_No = IIf(IsDBNull(rd("SAI_No")), "", rd("SAI_No"))
            Me.Purpose = IIf(IsDBNull(rd("Purpose")), "", rd("Purpose"))
            Me.Requested_By = IIf(IsDBNull(rd("Requested_By")), "", rd("Requested_By"))
            Me.Approved_By = IIf(IsDBNull(rd("Approved_By")), "", rd("Approved_By"))
            Me.Issued_By = IIf(IsDBNull(rd("Issued_By")), "", rd("Issued_By"))
            Me.Received_By = IIf(IsDBNull(rd("Received_By")), "", rd("Received_By"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.Func_ID = IIf(IsDBNull(rd("Func_ID")), 0, rd("Func_ID"))
            Me.F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
            Me.withICS = IIf(IsDBNull(rd("withICS")), 0, rd("withICS"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Function saveRISHdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        objDerived.cmd.Parameters.AddWithValue("@RISHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@RIS_No", RIS_No)
        objDerived.cmd.Parameters.AddWithValue("@RISDate", RISDate)
        objDerived.cmd.Parameters.AddWithValue("@SAI_No", SAI_No)
        objDerived.cmd.Parameters.AddWithValue("@Purpose", Purpose)
        objDerived.cmd.Parameters.AddWithValue("@Requested_By", Requested_By)
        objDerived.cmd.Parameters.AddWithValue("@Approved_By", Approved_By)
        objDerived.cmd.Parameters.AddWithValue("@Issued_By", Issued_By)
        objDerived.cmd.Parameters.AddWithValue("@Received_By", Received_By)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Func_ID", Func_ID)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@withICS", withICS)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_RIS_Hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
