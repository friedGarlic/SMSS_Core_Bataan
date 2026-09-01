Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class IAHdr
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pIAHdr_ID As Integer
    Public Property IAHdr_ID() As Integer
        Get
            Return pIAHdr_ID
        End Get
        Set(ByVal value As Integer)
            pIAHdr_ID = value
        End Set
    End Property

    Private pIA_Date As String
    Public Property IA_Date() As String
        Get
            Return pIA_Date
        End Get
        Set(ByVal value As String)
            pIA_Date = value
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

    Private pInspectedby As Integer
    Public Property Inspectedby() As Integer
        Get
            Return pInspectedby
        End Get
        Set(ByVal value As Integer)
            pInspectedby = value
        End Set
    End Property

#End Region


    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.IAHdr_ID = IIf(IsDBNull(rd("IAHdr_ID")), 0, rd("IAHdr_ID"))
            Me.IA_Date = IIf(IsDBNull(rd("IA_Date")), "", rd("IA_Date"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.Inspectedby = IIf(IsDBNull(rd("Inspectedby")), 0, rd("Inspectedby"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveIAHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@IAHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@IA_Date", IA_Date)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Inspectedby", Inspectedby)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_InspectionAppraisal_Hdr", CommandType.StoredProcedure, Nothing)

    End Sub
End Class
