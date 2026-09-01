Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Public Class APR
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private papr_hdr_id As Integer
    Public Property apr_hdr_id() As Integer
        Get
            Return papr_hdr_id
        End Get
        Set(ByVal value As Integer)
            papr_hdr_id = value
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

    Private pDateprepared As DateTime
    Public Property Dateprepared() As DateTime
        Get
            Return pDateprepared
        End Get
        Set(ByVal value As DateTime)
            pDateprepared = value
        End Set
    End Property

    Private pAPSO As String
    Public Property APSO() As String
        Get
            Return pAPSO
        End Get
        Set(ByVal value As String)
            pAPSO = value
        End Set
    End Property

    Private pACA As String
    Public Property ACA() As String
        Get
            Return pACA
        End Get
        Set(ByVal value As String)
            pACA = value
        End Set
    End Property

    Private pAHS As String
    Public Property AHS() As String
        Get
            Return pAHS
        End Get
        Set(ByVal value As String)
            pAHS = value
        End Set
    End Property

    Private pPS_APR_NO As String
    Public Property PS_APR_NO() As String
        Get
            Return pPS_APR_NO
        End Get
        Set(ByVal value As String)
            pPS_APR_NO = value
        End Set
    End Property

    Private pDBM_ID As Integer
    Public Property DBM_ID() As Integer
        Get
            Return pDBM_ID
        End Get
        Set(ByVal value As Integer)
            pDBM_ID = value
        End Set
    End Property

    Private pwithdv As Boolean
    Public Property withdv() As Boolean
        Get
            Return pwithdv
        End Get
        Set(ByVal value As Boolean)
            pwithdv = value
        End Set
    End Property



#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.apr_hdr_id = IIf(IsDBNull(rd("apr_hdr_id")), 0, rd("apr_hdr_id"))
            Me.PR_No = IIf(IsDBNull(rd("PR_No")), "", rd("PR_No"))
            Me.Dateprepared = IIf(IsDBNull(rd("Dateprepared")), "", rd("Dateprepared"))
            Me.APSO = IIf(IsDBNull(rd("APSO")), "", rd("APSO"))
            Me.ACA = IIf(IsDBNull(rd("ACA")), "", rd("ACA"))
            Me.AHS = IIf(IsDBNull(rd("AHS")), "", rd("AHS"))
            Me.PS_APR_NO = IIf(IsDBNull(rd("PS_APR_NO")), "", rd("PS_APR_NO"))
            Me.DBM_ID = IIf(IsDBNull(rd("DBM_ID")), 0, rd("DBM_ID"))
            Me.withdv = IIf(IsDBNull(rd("withdv")), 0, rd("withdv"))




        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function save_APR_hdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@apr_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@PR_No", PR_No)
        objDerived.cmd.Parameters.AddWithValue("@Dateprepared", Dateprepared)
        objDerived.cmd.Parameters.AddWithValue("@APSO", APSO)
        objDerived.cmd.Parameters.AddWithValue("@ACA", ACA)
        objDerived.cmd.Parameters.AddWithValue("@AHS", AHS)
        objDerived.cmd.Parameters.AddWithValue("@PS_APR_NO", PS_APR_NO)
        objDerived.cmd.Parameters.AddWithValue("@DBM_ID", DBM_ID)
        objDerived.cmd.Parameters.AddWithValue("@withdv", withdv)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_APR_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
