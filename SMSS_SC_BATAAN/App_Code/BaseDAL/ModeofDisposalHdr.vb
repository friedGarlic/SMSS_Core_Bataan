Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ModeofDisposalHdr
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pMDHdr_ID As Integer
    Public Property MDHdr_ID() As Integer
        Get
            Return pMDHdr_ID
        End Get
        Set(ByVal value As Integer)
            pMDHdr_ID = value
        End Set
    End Property

    Private pDisposeDate As DateTime
    Public Property DisposeDate() As DateTime
        Get
            Return pDisposeDate
        End Get
        Set(ByVal value As DateTime)
            pDisposeDate = value
        End Set
    End Property

    Private pDispositionAuthority As Integer
    Public Property DispositionAuthority() As Integer
        Get
            Return pDispositionAuthority
        End Get
        Set(ByVal value As Integer)
            pDispositionAuthority = value
        End Set
    End Property

    Private pdeptid As Integer
    Public Property deptid() As Integer
        Get
            Return pdeptid
        End Get
        Set(ByVal value As Integer)
            pdeptid = value
        End Set
    End Property





#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.MDHdr_ID = IIf(IsDBNull(rd("MDHdr_ID")), 0, rd("MDHdr_ID"))
            Me.DisposeDate = IIf(IsDBNull(rd("DisposeDate")), "", rd("DisposeDate"))
            Me.DispositionAuthority = IIf(IsDBNull(rd("DispositionAuthority")), 0, rd("DispositionAuthority"))
            Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))




        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub


    Public Sub saveMDHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect

        objDerived.cmd.Parameters.AddWithValue("@MDHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@DisposeDate", DisposeDate)
        objDerived.cmd.Parameters.AddWithValue("@DispositionAuthority", DispositionAuthority)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_ModeofDisposal_Hdr", CommandType.StoredProcedure, Nothing)

    End Sub


End Class
