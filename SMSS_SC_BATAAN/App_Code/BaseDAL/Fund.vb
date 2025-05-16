Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Fund
    Inherits BaseDAL

#Region "property"
    Private pF_ID As Integer
    Public Property F_ID() As Integer
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Integer)
            pF_ID = value
        End Set
    End Property

    Private pFund_Code As Integer
    Public Property Fund_Code() As Integer
        Get
            Return pFund_Code
        End Get
        Set(ByVal value As Integer)
            pFund_Code = value
        End Set
    End Property

    Private pDescription As String
    Public Property Description() As String
        Get
            Return pDescription
        End Get
        Set(ByVal value As String)
            pDescription = value
        End Set
    End Property
#End Region


    Public Overrides Sub FillEntity()
        Try
            cn.Open()
            rd = cmd.ExecuteReader
            While rd.Read()
                Me.F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
                Me.Fund_Code = IIf(IsDBNull(rd("FundCode")), 0, rd("FundCode"))
                Me.Description = IIf(IsDBNull(rd("Description")), "", rd("Description"))
            End While
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Function save_fund() As Long
        Me.cmd.Parameters.AddWithValue("@F_ID", 0)
        Me.cmd.Parameters.AddWithValue("@Fund_Code", pFund_Code)
        Me.cmd.Parameters.AddWithValue("@Description", pDescription)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("[BOS].[spSave_m_Fund]", CommandType.StoredProcedure)
    End Function

    Public Function update_fund() As Long
        Me.cmd.Parameters.AddWithValue("@F_ID", pF_ID)
        Me.cmd.Parameters.AddWithValue("@Fund_Code", pFund_Code)
        Me.cmd.Parameters.AddWithValue("@Description", pDescription)
        Me.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        Execute("@CurrID", "[BOS].[spSave_m_Fund]", CommandType.StoredProcedure)
    End Function

    Public Function getFundID() As Long
        Me.cmd.Parameters.AddWithValue("@Desc", pDescription)
        Dim x As Long
        x = Me.GetValue("BOS.fund_getID", CommandType.StoredProcedure)
        Return x
    End Function
End Class

