Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class RISDtl

    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pRISDtl_ID As Integer
    Public Property RISDtl_ID() As Integer
        Get
            Return pRISDtl_ID
        End Get
        Set(ByVal value As Integer)
            pRISDtl_ID = value
        End Set
    End Property

    Private pInquiredQty As Decimal
    Public Property InquiredQty() As Decimal
        Get
            Return pInquiredQty
        End Get
        Set(ByVal value As Decimal)
            pInquiredQty = value
        End Set
    End Property

    Private pAvailableQty As Decimal
    Public Property AvailableQty() As Decimal
        Get
            Return pAvailableQty
        End Get
        Set(ByVal value As Decimal)
            pAvailableQty = value
        End Set
    End Property

    Private pApprovedQty As Integer
    Public Property ApprovedQty() As Integer
        Get
            Return pApprovedQty
        End Get
        Set(ByVal value As Integer)
            pApprovedQty = value
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

    Private pRISHdr_ID As Integer
    Public Property RISHdr_ID() As Integer
        Get
            Return pRISHdr_ID
        End Get
        Set(ByVal value As Integer)
            pRISHdr_ID = value
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

    Private pStockID As Long
    Public Property StockID() As Long
        Get
            Return pStockID
        End Get
        Set(ByVal value As Long)
            pStockID = value
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


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.RISDtl_ID = IIf(IsDBNull(rd("RISDtl_ID")), 0, rd("RISDtl_ID"))
            Me.InquiredQty = IIf(IsDBNull(rd("InquiredQty")), 0, rd("InquiredQty"))
            Me.AvailableQty = IIf(IsDBNull(rd("AvailableQty")), 0, rd("AvailableQty"))
            Me.ApprovedQty = IIf(IsDBNull(rd("ApprovedQty")), 0, rd("ApprovedQty"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.RISHdr_ID = IIf(IsDBNull(rd("RISHdr_ID")), 0, rd("RISHdr_ID"))
            Me.Cost = IIf(IsDBNull(rd("Cost")), 0.0, rd("Cost"))
            Me.StockID = IIf(IsDBNull(rd("StockID")), 0, rd("StockID"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), 0, rd("Remarks"))

        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveRISDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@RISDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@InquiredQty", InquiredQty)
        objDerived.cmd.Parameters.AddWithValue("@AvailableQty", AvailableQty)
        objDerived.cmd.Parameters.AddWithValue("@ApprovedQty", ApprovedQty)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@RISHdr_ID", RISHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@StockID", StockID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_RIS_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
