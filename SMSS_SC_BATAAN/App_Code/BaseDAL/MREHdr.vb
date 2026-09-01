Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class MREHdr
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pMREHdr_ID As Integer
    Public Property MREHdr_ID() As Integer
        Get
            Return pMREHdr_ID
        End Get
        Set(ByVal value As Integer)
            pMREHdr_ID = value
        End Set
    End Property

    Private pMRE_Date As DateTime
    Public Property MRE_Date() As DateTime
        Get
            Return pMRE_Date
        End Get
        Set(ByVal value As DateTime)
            pMRE_Date = value
        End Set
    End Property

    Private pMRE_Date_Recieve As DateTime
    Public Property MRE_Date_Recieve() As DateTime
        Get
            Return pMRE_Date_Recieve
        End Get
        Set(ByVal value As DateTime)
            pMRE_Date_Recieve = value
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

    Private pReceived_from As Integer
    Public Property Received_from() As Integer
        Get
            Return pReceived_from
        End Get
        Set(ByVal value As Integer)
            pReceived_from = value
        End Set
    End Property

    Private pMRto As Integer
    Public Property MRto() As Integer
        Get
            Return pMRto
        End Get
        Set(ByVal value As Integer)
            pMRto = value
        End Set
    End Property

    Private pCancelled As Boolean
    Public Property Cancelled() As Boolean
        Get
            Return pCancelled
        End Get
        Set(ByVal value As Boolean)
            pCancelled = value
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

    Private pMRENumber As String
    Public Property MRENumber() As String
        Get
            Return pMRENumber
        End Get
        Set(ByVal value As String)
            pMRENumber = value
        End Set
    End Property
#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.MREHdr_ID = IIf(IsDBNull(rd("MREHdr_ID")), 0, rd("MREHdr_ID"))
            Me.MRE_Date = IIf(IsDBNull(rd("MRE_Date")), "", rd("MRE_Date"))
            Me.MRE_Date_Recieve = IIf(IsDBNull(rd("MRE_Date_Recieve")), 0, rd("MRE_Date_Recieve"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.Func_ID = IIf(IsDBNull(rd("Func_ID")), 0, rd("Func_ID"))
            Me.Received_from = IIf(IsDBNull(rd("Received_from")), "", rd("Received_from"))
            Me.MRto = IIf(IsDBNull(rd("MRto")), "", rd("MRto"))
            Me.Cancelled = IIf(IsDBNull(rd("Cancelled")), 0, rd("Cancelled"))
            Me.MRENumber = IIf(IsDBNull(rd("MRENumber")), 0, rd("MRENumber"))
        End While

        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub
    Public Function saveMREHdr() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MREHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Date", MRE_Date)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Date_Recieve", MRE_Date_Recieve)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Func_ID", Func_ID)
        objDerived.cmd.Parameters.AddWithValue("@Received_from", Received_from)
        objDerived.cmd.Parameters.AddWithValue("@MRto", MRto)
        objDerived.cmd.Parameters.AddWithValue("@Cancelled", Cancelled)
        objDerived.cmd.Parameters.AddWithValue("@MRENumber", MRENumber)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_MRE_HDR", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


End Class
