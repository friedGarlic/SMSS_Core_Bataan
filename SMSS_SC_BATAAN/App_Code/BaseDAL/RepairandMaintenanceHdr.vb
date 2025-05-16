Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class RepairandMaintenanceHdr
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pRMHdr_ID As Integer
    Public Property RMHdr_ID() As Integer
        Get
            Return pRMHdr_ID
        End Get
        Set(ByVal value As Integer)
            pRMHdr_ID = value
        End Set
    End Property

    Private pRM_No As String
    Public Property RM_No() As String
        Get
            Return pRM_No
        End Get
        Set(ByVal value As String)
            pRM_No = value
        End Set
    End Property

    Private pRM_Date As DateTime
    Public Property RM_Date() As DateTime
        Get
            Return pRM_Date
        End Get
        Set(ByVal value As DateTime)
            pRM_Date = value
        End Set
    End Property

    Private pRequestedby As Integer
    Public Property Requestedby() As Integer
        Get
            Return pRequestedby
        End Get
        Set(ByVal value As Integer)
            pRequestedby = value
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

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
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

    Private pwpr As Boolean
    Public Property wpr() As Boolean
        Get
            Return pwpr
        End Get
        Set(ByVal value As Boolean)
            pwpr = value
        End Set
    End Property




#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.RMHdr_ID = IIf(IsDBNull(rd("RMHdr_ID")), 0, rd("RMHdr_ID"))
            Me.RM_No = IIf(IsDBNull(rd("RM_No")), "", rd("RM_No"))
            Me.RM_Date = IIf(IsDBNull(rd("RM_Date")), "", rd("RM_Date"))
            Me.Requestedby = IIf(IsDBNull(rd("Requestedby")), 0, rd("Requestedby"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.wpr = IIf(IsDBNull(rd("wpr")), 0, rd("wpr"))





        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveRMHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@RMHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@RM_No", RM_No)
        objDerived.cmd.Parameters.AddWithValue("@RM_Date", RM_Date)
        objDerived.cmd.Parameters.AddWithValue("@Requestedby", Requestedby)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@wpr", wpr)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_RepairMaintenance_Hdr", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
