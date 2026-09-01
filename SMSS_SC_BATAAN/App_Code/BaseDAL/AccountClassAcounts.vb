Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class AccountClassAcounts
    Inherits BaseDAL

#Region "property"

    Private pAllotmentClassAccount_ID As Long
    Public Property AllotmentClassAccount_ID() As Long
        Get
            Return pAllotmentClassAccount_ID
        End Get
        Set(ByVal value As Long)
            pAllotmentClassAccount_ID = value
        End Set
    End Property

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property

    Private pBGA_ID As Long
    Public Property BGA_ID() As Long
        Get
            Return pBGA_ID
        End Get
        Set(ByVal value As Long)
            pBGA_ID = value
        End Set
    End Property

    Private pAllotmentClass_ID As Long
    Public Property AllotmentClass_ID() As Long
        Get
            Return pAllotmentClass_ID
        End Get
        Set(ByVal value As Long)
            pAllotmentClass_ID = value
        End Set
    End Property

    Private pisReserved As Boolean
    Public Property isReserved() As Boolean
        Get
            Return pisReserved
        End Get
        Set(ByVal value As Boolean)
            pisReserved = value
        End Set
    End Property

    Private pReservedPercentage As Integer
    Public Property ReservedPercentage() As Integer
        Get
            Return pReservedPercentage
        End Get
        Set(ByVal value As Integer)
            pReservedPercentage = value
        End Set
    End Property

    Private pforFullRelease As Boolean
    Public Property forFullRelease() As Boolean
        Get
            Return pforFullRelease
        End Get
        Set(ByVal value As Boolean)
            pforFullRelease = value
        End Set
    End Property

    Private pisContinuing As Boolean
    Public Property isContinuing() As Boolean
        Get
            Return pisContinuing
        End Get
        Set(ByVal value As Boolean)
            pisContinuing = value
        End Set
    End Property
#End Region


    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.AllotmentClassAccount_ID = IIf(IsDBNull(rd("AllotmentClassAccount_ID")), 0, rd("AllotmentClassAccount_ID"))
                Me.GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                Me.BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                Me.AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                Me.isReserved = IIf(IsDBNull(rd("isReserved")), 0, rd("isReserved"))
                Me.ReservedPercentage = IIf(IsDBNull(rd("ReservedPercentage")), 0, rd("ReservedPercentage"))
                Me.forFullRelease = IIf(IsDBNull(rd("forFullRelease")), 0, rd("forFullRelease"))
                Me.isContinuing = IIf(IsDBNull(rd("isContinuing")), 0, rd("isContinuing"))
            End While
        Catch ex As Exception
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Function save_to_AllotmentclassAccount() As Long
        Me.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", 0)
        Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
        Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
        Me.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
        Me.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
        Me.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
        Me.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
        Me.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)

        Execute("[dbo].[spSave_M_AllotmentClassAccount]", Data.CommandType.StoredProcedure)
    End Function

    Public Function update_allotmentclassaccounts() As Long
        Me.cmd.Parameters.AddWithValue("@AllotmentClassAccount_ID", pAllotmentClassAccount_ID)
        Me.cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
        Me.cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
        Me.cmd.Parameters.AddWithValue("@AllotmentClass_ID", pAllotmentClass_ID)
        Me.cmd.Parameters.AddWithValue("@isReserved", pisReserved)
        Me.cmd.Parameters.AddWithValue("@ReservedPercentage", pReservedPercentage)
        Me.cmd.Parameters.AddWithValue("@forFullRelease", pforFullRelease)
        Me.cmd.Parameters.AddWithValue("@isContinuing", pisContinuing)

        Execute("[dbo].[spSave_M_AllotmentClassAccount]", Data.CommandType.StoredProcedure)
    End Function

End Class
