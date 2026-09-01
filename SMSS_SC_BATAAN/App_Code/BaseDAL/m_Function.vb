Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class m_Function
    Inherits BaseDAL



#Region "property"
    Private pFunction_ID As Integer
    Public Property Function_ID() As Integer
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Integer)
            pFunction_ID = value
        End Set
    End Property

    Private pFunction_Name As String
    Public Property Function_Name() As String
        Get
            Return pFunction_Desc
        End Get
        Set(ByVal value As String)
            pFunction_Name = value
        End Set
    End Property


    Private pFunction_Desc As String
    Public Property Function_Desc() As String
        Get
            Return pFunction_Desc
        End Get
        Set(ByVal value As String)
            pFunction_Desc = value
        End Set
    End Property


#End Region

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                Me.Function_Desc = IIf(IsDBNull(rd("Function_Desc")), "", rd("Function_Desc"))
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Function save_to_function() As Long
        Me.cmd.Parameters.AddWithValue("@Function_ID", 0)
        Me.cmd.Parameters.AddWithValue("@Function_Desc", pFunction_Desc)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[dbo].[spSave_m_Function]", CommandType.StoredProcedure)
    End Function

    Public Function update_function() As Long
        Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
        Me.cmd.Parameters.AddWithValue("@Function_Desc", pFunction_Desc)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[dbo].[spSave_m_Function]", CommandType.StoredProcedure)
    End Function
End Class
