Imports Microsoft.VisualBasic
Imports System.DateTime
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class AMSStock

    Inherits BaseDLL.BaseDAL

#Region "properties"

    Private pStockID As Integer
    Public Property StockID() As Integer
        Get
            Return pStockID
        End Get
        Set(ByVal value As Integer)
            pStockID = value
        End Set
    End Property

    Private pStockDate As DateTime
    Public Property StockDate() As DateTime
        Get
            Return pStockDate
        End Get
        Set(ByVal value As DateTime)
            pStockDate = value
        End Set
    End Property

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
        End Set
    End Property

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
        End Set
    End Property

    Private pCost As Decimal
    Public Property Cost() As Decimal
        Get
            Return pCost
        End Get
        Set(ByVal value As Decimal)
            pCost = value
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

    Private pRemarks As String
    Public Property Remarks() As String
        Get
            Return pRemarks
        End Get
        Set(ByVal value As String)
            pRemarks = value
        End Set
    End Property

    Private pStockno As Integer
    Public Property Stockno() As Integer
        Get
            Return pStockno
        End Get
        Set(ByVal value As Integer)
            pStockno = value
        End Set
    End Property

#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.StockID = IIf(IsDBNull(rd("StockID")), 0, rd("StockID"))
            Me.StockDate = IIf(IsDBNull(rd("StockDate")), "", rd("StockDate"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.Cost = IIf(IsDBNull(rd("Cost")), 0.0, rd("Cost"))
            Me.RC_ID = IIf(IsDBNull(rd("RC_ID")), 0, rd("RC_ID"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))
            Me.Stockno = IIf(IsDBNull(rd("Stockno")), 0, rd("Stockno"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Sub saveStock()


        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long

        objDerived.cmd.Parameters.AddWithValue("@StockID", 0)
        objDerived.cmd.Parameters.AddWithValue("@StockDate", StockDate)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@Stockno", Stockno)

        i = objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
    End Sub

End Class
