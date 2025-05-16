Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page

Imports System.Collections.Generic
Imports System

Public Class m_StraightContract_Dtl
    Inherits BaseDAL

#Region "property"

    Private pSCdtl_ID As Long
    Public Property SCdtl_ID() As Long
        Get
            Return pSCdtl_ID
        End Get
        Set(ByVal value As Long)
            pSCdtl_ID = value
        End Set
    End Property
    Private pSC_ID As Long
    Public Property SC_ID() As Long
        Get
            Return pSC_ID
        End Get
        Set(ByVal value As Long)
            pSC_ID = value
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

    Private pallotmentclass_ID As Integer
    Public Property allotmentclass_ID() As Integer
        Get
            Return pallotmentclass_ID
        End Get
        Set(ByVal value As Integer)
            pallotmentclass_ID = value
        End Set
    End Property
    Private pModeOfAcq As String
    Public Property ModeOfAcq() As String
        Get
            Return pModeOfAcq
        End Get
        Set(ByVal value As String)
            pModeOfAcq = value
        End Set
    End Property

    Private pArea As String
    Public Property Area() As String
        Get
            Return pArea
        End Get
        Set(ByVal value As String)
            pArea = value
        End Set
    End Property

    Private pUnit As String
    Public Property Unit() As String
        Get
            Return pUnit
        End Get
        Set(ByVal value As String)
            pUnit = value
        End Set
    End Property

    Private pQuarter1 As Decimal
    Public Property Quarter1() As Decimal
        Get
            Return pQuarter1
        End Get
        Set(ByVal value As Decimal)
            pQuarter1 = value
        End Set
    End Property

    Private pQuarter2 As Decimal
    Public Property Quarter2() As Decimal
        Get
            Return pQuarter2
        End Get
        Set(ByVal value As Decimal)
            pQuarter2 = value
        End Set
    End Property

    Private pQuarter3 As Decimal
    Public Property Quarter3() As Decimal
        Get
            Return pQuarter3
        End Get
        Set(ByVal value As Decimal)
            pQuarter3 = value
        End Set
    End Property
    Private pQuarter4 As Decimal
    Public Property Quarter4() As Decimal
        Get
            Return pQuarter4
        End Get
        Set(ByVal value As Decimal)
            pQuarter4 = value
        End Set
    End Property
    '---
    Private pQuarter1App As Decimal
    Public Property Quarter1App() As Decimal
        Get
            Return pQuarter1App
        End Get
        Set(ByVal value As Decimal)
            pQuarter1App = value
        End Set
    End Property

    Private pQuarter2App As Decimal
    Public Property Quarter2App() As Decimal
        Get
            Return pQuarter2App
        End Get
        Set(ByVal value As Decimal)
            pQuarter2App = value
        End Set
    End Property

    Private pQuarter3App As Decimal
    Public Property Quarter3App() As Decimal
        Get
            Return pQuarter3App
        End Get
        Set(ByVal value As Decimal)
            pQuarter3App = value
        End Set
    End Property
    Private pQuarter4App As Decimal
    Public Property Quarter4App() As Decimal
        Get
            Return pQuarter4App
        End Get
        Set(ByVal value As Decimal)
            pQuarter4App = value
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

    Private pTableName As String
    Public Property TableName() As String
        Get
            Return pTableName
        End Get
        Set(ByVal value As String)
            pTableName = value
        End Set
    End Property
#End Region

    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                With Me
                    .SCdtl_ID = IIf(IsDBNull(rd("SCdtl_ID")), 0, rd("SCdtl_ID"))
                    .SC_ID = IIf(IsDBNull(rd("SC_ID")), 0, rd("SC_ID"))
                    .GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
                    .BGA_ID = IIf(IsDBNull(rd("BGA_ID")), 0, rd("BGA_ID"))
                    .allotmentclass_ID = IIf(IsDBNull(rd("allotmentclass_ID")), 0, rd("allotmentclass_ID"))
                    .ModeOfAcq = IIf(IsDBNull(rd("ModeOfAcq")), "", rd("ModeOfAcq"))
                    .Area = IIf(IsDBNull(rd("Area")), "", rd("Area"))
                    .Unit = IIf(IsDBNull(rd("Unit")), "", rd("Unit"))
                    .Quarter1 = IIf(IsDBNull(rd("Quarter1")), 0.0, rd("Quarter1"))
                    .Quarter2 = IIf(IsDBNull(rd("Quarter2")), 0.0, rd("Quarter2"))
                    .Quarter3 = IIf(IsDBNull(rd("Quarter3")), 0.0, rd("Quarter3"))
                    .Quarter4 = IIf(IsDBNull(rd("Quarter4")), 0.0, rd("Quarter4"))
                    .Quarter1App = IIf(IsDBNull(rd("Quarter1App")), 0.0, rd("Quarter1App"))
                    .Quarter2App = IIf(IsDBNull(rd("Quarter2App")), 0.0, rd("Quarter2App"))
                    .Quarter3App = IIf(IsDBNull(rd("Quarter3App")), 0.0, rd("Quarter3App"))
                    .Quarter4App = IIf(IsDBNull(rd("Quarter4App")), 0.0, rd("Quarter4App"))
                    .UserID = IIf(IsDBNull(rd("UserID")), "", rd("UserID"))
                    .TableName = IIf(IsDBNull(rd("TableName")), "", rd("TableName"))
                End With
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub saveSC_Dtl()
        With Me
            .cmd.Parameters.AddWithValue("SCdtl_ID", 0)
            .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@allotmentclass_ID", pallotmentclass_ID)
            .cmd.Parameters.AddWithValue("@ModeOfAcq", pModeOfAcq)
            .cmd.Parameters.AddWithValue("@Area", pArea)
            .cmd.Parameters.AddWithValue("@Unit", pUnit)
            .cmd.Parameters.AddWithValue("@Quarter1", pQuarter1)
            .cmd.Parameters.AddWithValue("@Quarter2", pQuarter2)
            .cmd.Parameters.AddWithValue("@Quarter3", pQuarter3)
            .cmd.Parameters.AddWithValue("@Quarter4", pQuarter4)
            .cmd.Parameters.AddWithValue("@Quarter1App", pQuarter1App)
            .cmd.Parameters.AddWithValue("@Quarter2App", pQuarter2App)
            .cmd.Parameters.AddWithValue("@Quarter3App", pQuarter3App)
            .cmd.Parameters.AddWithValue("@Quarter4App", pQuarter4App)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("Bos.spSave_m_StraightContract_Dtl", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub updateSC_Dtl()
        With Me
            .cmd.Parameters.AddWithValue("SCdtl_ID", pSCdtl_ID)
            .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@allotmentclass_ID", pallotmentclass_ID)
            .cmd.Parameters.AddWithValue("@ModeOfAcq", pModeOfAcq)
            .cmd.Parameters.AddWithValue("@Area", pArea)
            .cmd.Parameters.AddWithValue("@Unit", pUnit)
            .cmd.Parameters.AddWithValue("@Quarter1", pQuarter1)
            .cmd.Parameters.AddWithValue("@Quarter2", pQuarter2)
            .cmd.Parameters.AddWithValue("@Quarter3", pQuarter3)
            .cmd.Parameters.AddWithValue("@Quarter4", pQuarter4)
            .cmd.Parameters.AddWithValue("@Quarter1App", pQuarter1App)
            .cmd.Parameters.AddWithValue("@Quarter2App", pQuarter2App)
            .cmd.Parameters.AddWithValue("@Quarter3App", pQuarter3App)
            .cmd.Parameters.AddWithValue("@Quarter4App", pQuarter4App)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "Bos.spSave_m_StraightContract_Dtl", Data.CommandType.StoredProcedure)
    End Sub

    Public Sub updateSC_Dtlrevise()
        With Me
            .cmd.Parameters.AddWithValue("SCdtl_ID", pSCdtl_ID)
            .cmd.Parameters.AddWithValue("@SC_ID", pSC_ID)
            .cmd.Parameters.AddWithValue("@GA_ID", pGA_ID)
            .cmd.Parameters.AddWithValue("@BGA_ID", pBGA_ID)
            .cmd.Parameters.AddWithValue("@allotmentclass_ID", pallotmentclass_ID)
            .cmd.Parameters.AddWithValue("@ModeOfAcq", pModeOfAcq)
            .cmd.Parameters.AddWithValue("@Area", pArea)
            .cmd.Parameters.AddWithValue("@Unit", pUnit)
            .cmd.Parameters.AddWithValue("@Quarter1App", pQuarter1App)
            .cmd.Parameters.AddWithValue("@Quarter2App", pQuarter2App)
            .cmd.Parameters.AddWithValue("@Quarter3App", pQuarter3App)
            .cmd.Parameters.AddWithValue("@Quarter4App", pQuarter4App)
            .cmd.Parameters.AddWithValue("@UserID", pUserID)
            .cmd.Parameters.AddWithValue("@TableName", pTableName)
            .cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        End With

        Execute("@CurrID", "Bos.[spSave_m_StraightContract_DtlRevise]", Data.CommandType.StoredProcedure)
    End Sub


End Class
