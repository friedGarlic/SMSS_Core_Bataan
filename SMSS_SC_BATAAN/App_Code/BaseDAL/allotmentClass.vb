Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class allotmentClass
    Inherits BaseDAL
#Region "property"
    Private pAllotmentClass_ID As Integer
    Public Property AllotmentClass_ID() As Integer
        Get
            Return pAllotmentClass_ID
        End Get
        Set(ByVal value As Integer)
            pAllotmentClass_ID = value
        End Set
    End Property

    Private pAllotmentClass_Code As Integer
    Public Property AllotmentClass_Code() As Integer
        Get
            Return pAllotmentClass_Code
        End Get
        Set(ByVal value As Integer)
            pAllotmentClass_Code = value
        End Set
    End Property

    Private pAllotmentClass As String
    Public Property AllotmentClass() As String
        Get
            Return pAllotmentClass
        End Get
        Set(ByVal value As String)
            pAllotmentClass = value
        End Set
    End Property

#End Region
    Public Overrides Sub FillEntity()

        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.AllotmentClass_ID = IIf(IsDBNull(rd("AllotmentClass_ID")), 0, rd("AllotmentClass_ID"))
                Me.AllotmentClass_Code = IIf(IsDBNull(rd("AllotmentClass_Code")), 0, rd("AllotmentClass_Code"))
                Me.AllotmentClass = IIf(IsDBNull(rd("AllotmentClass")), "", rd("AllotmentClass"))
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub


End Class
