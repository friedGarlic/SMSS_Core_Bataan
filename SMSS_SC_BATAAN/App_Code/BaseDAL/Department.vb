Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Department
    Inherits BaseDAL

#Region "Property"
    Private pOffice_ID As Long
    Public Property Office_ID() As Long
        Get
            Return pOffice_ID
        End Get
        Set(ByVal value As Long)
            pOffice_ID = value
        End Set
    End Property

    Private pOffice_Name As String
    Public Property Office_Name() As String
        Get
            Return pOffice_Name
        End Get
        Set(ByVal value As String)
            pOffice_Name = value
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
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.Office_ID = IIf(IsDBNull(rd("Office_ID")), 0, rd("Office_ID"))
                Me.Office_Name = IIf(IsDBNull(rd("Office_Name")), "", rd("Office_Name"))
                Me.UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub save_office()
        Me.cmd.Parameters.AddWithValue("@Office_ID", 0)
        Me.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)
        'Me.cmd.Parameters.AddWithValue("@UserID", pUserID)

        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_Office]", CommandType.StoredProcedure)
    End Sub

    Public Sub update_office()
        Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
        Me.cmd.Parameters.AddWithValue("@Office_Name", pOffice_Name)
        'Me.cmd.Parameters.AddWithValue("@UserID", pUserID)

        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_Office]", CommandType.StoredProcedure)
    End Sub

    Public Function getOfficeID() As Long
        Me.cmd.Parameters.AddWithValue("office_name", pOffice_Name)
        Dim x As Long
        x = Me.GetValue("BOS.office_getID", CommandType.StoredProcedure)
        Return x
    End Function
End Class



