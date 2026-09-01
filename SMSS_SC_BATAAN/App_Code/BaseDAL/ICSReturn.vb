Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ICSReturn
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pICSReturn_ID As Integer
    Public Property ICSReturn_ID() As Integer
        Get
            Return pICSReturn_ID
        End Get
        Set(ByVal value As Integer)
            pICSReturn_ID = value
        End Set
    End Property

    Private pICSDtl_ID As Integer
    Public Property ICSDtl_ID() As Integer
        Get
            Return pICSDtl_ID
        End Get
        Set(ByVal value As Integer)
            pICSDtl_ID = value
        End Set
    End Property

    Private pICS_Date As DateTime
    Public Property ICS_Date() As DateTime
        Get
            Return pICS_Date
        End Get
        Set(ByVal value As DateTime)
            pICS_Date = value
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

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
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
            Me.ICSReturn_ID = IIf(IsDBNull(rd("ICSReturn_ID")), 0, rd("ICSReturn_ID"))
            Me.ICSDtl_ID = IIf(IsDBNull(rd("ICSDtl_ID")), 0, rd("ICSDtl_ID"))
            Me.ICS_Date = IIf(IsDBNull(rd("ICS_Date")), "", rd("ICS_Date"))
            Me.Status = IIf(IsDBNull(rd("Status")), "", rd("Status"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))
            Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveICSReturn()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ICSReturn_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@ICSDtl_ID", ICSDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@ICS_Date", ICS_Date)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_ICS_Return", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
