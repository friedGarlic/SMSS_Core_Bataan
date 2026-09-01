Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class sector
    Inherits BaseDAL
#Region "Property"
    Private pSector_ID As Long
    Public Property Sector_ID() As Long
        Get
            Return pSector_ID
        End Get
        Set(ByVal value As Long)
            pSector_ID = value
        End Set
    End Property

    Private pSector_Desc As String
    Public Property Sector_Desc() As String
        Get
            Return pSector_Desc
        End Get
        Set(ByVal value As String)
            pSector_Desc = value
        End Set
    End Property

    Private pSector_Code As String
    Public Property Sector_Code() As String
        Get
            Return pSector_Code
        End Get
        Set(ByVal value As String)
            pSector_Code = value
        End Set
    End Property
#End Region

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                Me.Sector_Desc = IIf(IsDBNull(rd("Sector_Desc")), "", rd("Sector_Desc"))
                Me.Sector_Code = IIf(IsDBNull(rd("Sector_Code")), "", rd("Sector_Code"))
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Function save_sector() As Long
        Me.cmd.Parameters.AddWithValue("@Sector_ID", 0)
        Me.cmd.Parameters.AddWithValue("@Sector_Desc", pSector_Desc)
        Me.cmd.Parameters.AddWithValue("@Sector_Code", pSector_Code)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_Sector]", CommandType.StoredProcedure)
    End Function

    Public Function update_sector() As Long
        Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
        Me.cmd.Parameters.AddWithValue("@Sector_Desc", pSector_Desc)
        Me.cmd.Parameters.AddWithValue("@Sector_Code", pSector_Code)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_Sector]", CommandType.StoredProcedure)
    End Function
End Class
