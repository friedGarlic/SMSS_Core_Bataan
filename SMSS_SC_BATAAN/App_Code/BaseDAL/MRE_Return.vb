Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class MRE_Return
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pMRE_ReturnID As Integer
    Public Property MRE_ReturnID() As Integer
        Get
            Return pMRE_ReturnID
        End Get
        Set(ByVal value As Integer)
            pMRE_ReturnID = value
        End Set
    End Property

    Private pMRE_Dtl As Integer
    Public Property MRE_Dtl() As Integer
        Get
            Return pMRE_Dtl
        End Get
        Set(ByVal value As Integer)
            pMRE_Dtl = value
        End Set
    End Property

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
        End Set
    End Property

    Private pStatus As String
    Public Property Status() As String
        Get
            Return pStatus
        End Get
        Set(ByVal value As String)
            pStatus = value
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

    Private pMRE_Date As DateTime
    Public Property MRE_Date() As DateTime
        Get
            Return pMRE_Date
        End Get
        Set(ByVal value As DateTime)
            pMRE_Date = value
        End Set
    End Property

    Private pDispose As Boolean
    Public Property Dispose() As Boolean
        Get
            Return pDispose
        End Get
        Set(ByVal value As Boolean)
            pDispose = value
        End Set
    End Property

    Private pRepair As Boolean
    Public Property Repair() As Boolean
        Get
            Return pRepair
        End Get
        Set(ByVal value As Boolean)
            pRepair = value
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

    Private pInspection As String
    Public Property Inspection() As String
        Get
            Return pInspection
        End Get
        Set(ByVal value As String)
            pInspection = value
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

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.MRE_ReturnID = IIf(IsDBNull(rd("MRE_ReturnID")), 0, rd("MRE_ReturnID"))
            Me.MRE_Dtl = IIf(IsDBNull(rd("MRE_Dtl")), 0, rd("MRE_Dtl"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.Status = IIf(IsDBNull(rd("Status")), "", rd("Status"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))
            Me.MRE_Date = IIf(IsDBNull(rd("MRE_Date")), "", rd("MRE_Date"))
            Me.Dispose = IIf(IsDBNull(rd("Dispose")), 0, rd("Dispose"))
            Me.Repair = IIf(IsDBNull(rd("Repair")), 0, rd("Repair"))
            Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))
            Me.Inspection = IIf(IsDBNull(rd("Inspection")), "", rd("Inspection"))
            Me.Inspection = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub saveMREReturn()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MRE_ReturnID", 0)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Dtl", MRE_Dtl)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Date", MRE_Date)
        objDerived.cmd.Parameters.AddWithValue("@Dispose", Dispose)
        objDerived.cmd.Parameters.AddWithValue("@Repair", Repair)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@Inspection", Inspection)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_MRE_Returns", CommandType.StoredProcedure, Nothing)
    End Sub

    Public Sub saveEditMREReturn()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MRE_ReturnID", MRE_ReturnID)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Dtl", MRE_Dtl)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Date", MRE_Date)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_MRE_Returns", CommandType.StoredProcedure, Nothing)
    End Sub

    Public Sub UpdateMREReturn()
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@MRE_ReturnID", MRE_ReturnID)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Dtl", MRE_Dtl)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@MRE_Date", MRE_Date)
        objDerived.cmd.Parameters.AddWithValue("@Dispose", Dispose)
        objDerived.cmd.Parameters.AddWithValue("@Repair", Repair)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@Inspection", Inspection)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_MRE_Returns", CommandType.StoredProcedure, Nothing)
    End Sub

End Class
