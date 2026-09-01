Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class AppropriationSource
    Inherits BaseDAL

#Region "property"
    Private pAppropriationSource_ID As Long
    Public Property AppropriationSource_ID() As Long
        Get
            Return pAppropriationSource_ID
        End Get
        Set(ByVal value As Long)
            pAppropriationSource_ID = value
        End Set
    End Property

    Private pAppropriationSource_Desc As String
    Public Property AppropriationSource_Desc() As String
        Get
            Return pAppropriationSource_Desc
        End Get
        Set(ByVal value As String)
            pAppropriationSource_Desc = value
        End Set
    End Property

    Private pBudget_Year As Integer
    Public Property Budget_Year() As Integer
        Get
            Return pBudget_Year
        End Get
        Set(ByVal value As Integer)
            pBudget_Year = value
        End Set
    End Property

    Private pAppropriationType_ID As Long
    Public Property AppropriationType_ID() As Long
        Get
            Return pAppropriationType_ID
        End Get
        Set(ByVal value As Long)
            pAppropriationType_ID = value
        End Set
    End Property

#End Region

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.AppropriationSource_ID = IIf(IsDBNull(rd("AppropriationSource_ID")), 0, rd("AppropriationSource_ID"))
                Me.AppropriationSource_Desc = IIf(IsDBNull(rd("AppropriationSource_Desc")), "", rd("AppropriationSource_Desc"))
                Me.Budget_Year = IIf(IsDBNull(rd("Budget_Year")), "", rd("Budget_Year"))
                Me.AppropriationType_ID = IIf(IsDBNull(rd("AppropriationType_ID")), 0, rd("AppropriationType_ID"))

            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Function save_app_source() As Long

        Me.cmd.Parameters.AddWithValue("@AppropriationSource_ID", 0)
        Me.cmd.Parameters.AddWithValue("@AppropriationSource_Desc", pAppropriationSource_Desc)
        Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
        Me.cmd.Parameters.AddWithValue("@AppropriationType_ID", pAppropriationType_ID)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_AppropriationSource]", CommandType.StoredProcedure)

    End Function

    Public Function update_app_source() As Long

        Me.cmd.Parameters.AddWithValue("@AppropriationSource_ID", pAppropriationSource_ID)
        Me.cmd.Parameters.AddWithValue("@AppropriationSource_Desc", pAppropriationSource_Desc)
        Me.cmd.Parameters.AddWithValue("@Budget_Year", pBudget_Year)
        Me.cmd.Parameters.AddWithValue("@AppropriationType_ID", pAppropriationType_ID)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_AppropriationSource]", CommandType.StoredProcedure)

    End Function

End Class
