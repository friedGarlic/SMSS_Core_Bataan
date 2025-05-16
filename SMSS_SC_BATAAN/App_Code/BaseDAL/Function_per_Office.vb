Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Function_per_Office
    Inherits BaseDAL
#Region "Property"


    Private pFunc_per_Office_ID As Long
    Public Property Func_per_Office_ID() As Long
        Get
            Return pFunc_per_Office_ID
        End Get
        Set(ByVal value As Long)
            pFunc_per_Office_ID = value
        End Set
    End Property

    Private pOffice_ID As Long
    Public Property Office_ID() As Long
        Get
            Return pOffice_ID
        End Get
        Set(ByVal value As Long)
            pOffice_ID = value
        End Set
    End Property

    Private pFunction_ID As Long
    Public Property Function_ID() As Long
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Long)
            pFunction_ID = value
        End Set
    End Property

    Private pOffice_Code As String
    Public Property Office_Code() As String
        Get
            Return pOffice_Code
        End Get
        Set(ByVal value As String)
            pOffice_Code = value
        End Set
    End Property

    Private pSector_ID As Long
    Public Property Sector_ID() As Long
        Get
            Return pSector_ID
        End Get
        Set(ByVal value As Long)
            pSector_ID = value
        End Set
    End Property

    Private pSubSector_ID As Long
    Public Property SubSector_ID() As Long
        Get
            Return pSubSector_ID
        End Get
        Set(ByVal value As Long)
            pSubSector_ID = value
        End Set
    End Property

    Private pF_ID As Long
    Public Property F_ID() As Long
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Long)
            pF_ID = value
        End Set
    End Property

    Private pisBR As Boolean
    Public Property isBR() As Long
        Get
            Return pisBR
        End Get
        Set(ByVal value As Long)
            pisBR = value
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
                Me.Func_per_Office_ID = IIf(IsDBNull(rd("Func_per_Office_ID")), 0, rd("Func_per_Office_ID"))
                Me.Office_ID = IIf(IsDBNull(rd("Office_ID")), 0, rd("Office_ID"))
                Me.Function_ID = IIf(IsDBNull(rd("Function_ID")), 0, rd("Function_ID"))
                Me.Office_Code = IIf(IsDBNull(rd("Office_Code")), "", rd("Office_Code"))
                Me.Sector_ID = IIf(IsDBNull(rd("Sector_ID")), 0, rd("Sector_ID"))
                Me.SubSector_ID = IIf(IsDBNull(rd("SubSector_ID")), 0, rd("SubSector_ID"))
                Me.F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                Me.isBR = IIf(IsDBNull(rd("isBR")), 0, rd("isBR"))
                Me.UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Function save_to_function_per_office() As Long
        Me.cmd.Parameters.AddWithValue("@Func_per_Office_ID", 0)
        Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
        Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
        Me.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
        Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
        Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
        Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
        Me.cmd.Parameters.AddWithValue("@isBR", pisBR)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Dim br As Integer
        If pisBR = False Then
            br = 0
        Else
            br = 1
        End If

        Execute("BOS.spSave_m_Function_per_Office", Data.CommandType.StoredProcedure)
    End Function

    Public Function update_function_per_office() As Long
        Me.cmd.Parameters.AddWithValue("@Func_per_Office_ID", pFunc_per_Office_ID)
        Me.cmd.Parameters.AddWithValue("@Office_ID", pOffice_ID)
        Me.cmd.Parameters.AddWithValue("@Function_ID", pFunction_ID)
        Me.cmd.Parameters.AddWithValue("@Office_Code", pOffice_Code)
        Me.cmd.Parameters.AddWithValue("@Sector_ID", pSector_ID)
        Me.cmd.Parameters.AddWithValue("@SubSector_ID", pSubSector_ID)
        Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
        Me.cmd.Parameters.AddWithValue("@isBR", pisBR)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Dim br As Integer
        If pisBR = False Then
            br = 0
        Else
            br = 1
        End If


        Execute("@CurrID", "BOS.spSave_m_Function_per_Office", Data.CommandType.StoredProcedure)
    End Function
End Class



