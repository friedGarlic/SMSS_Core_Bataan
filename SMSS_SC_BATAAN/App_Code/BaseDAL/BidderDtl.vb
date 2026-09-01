Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class BidderDtl
    Inherits BaseDLL.BaseDAL
#Region "property"


    Private pBidDtl_ID As Integer
    Public Property BidDtl_ID() As Integer
        Get
            Return pBidDtl_ID
        End Get
        Set(ByVal value As Integer)
            pBidDtl_ID = value
        End Set
    End Property

    Private pSupplier_ID As Integer
    Public Property Supplier_ID() As Integer
        Get
            Return pSupplier_ID
        End Get
        Set(ByVal value As Integer)
            pSupplier_ID = value
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

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
        End Set
    End Property

    Private pDiscount As Integer
    Public Property Discount() As Integer
        Get
            Return pDiscount
        End Get
        Set(ByVal value As Integer)
            pDiscount = value
        End Set
    End Property

    Private pBidHdr_ID As Integer
    Public Property BidHdr_ID() As Integer
        Get
            Return pBidHdr_ID
        End Get
        Set(ByVal value As Integer)
            pBidHdr_ID = value
        End Set
    End Property

    Private pIs_Award As Boolean
    Public Property Is_Award() As Boolean
        Get
            Return pIs_Award
        End Get
        Set(ByVal value As Boolean)
            pIs_Award = value
        End Set
    End Property

    Private pWithPO As Boolean
    Public Property WithPO() As Boolean
        Get
            Return pWithPO
        End Get
        Set(ByVal value As Boolean)
            pWithPO = value
        End Set
    End Property

    Private pqty As Integer
    Public Property qty() As Integer
        Get
            Return pqty
        End Get
        Set(ByVal value As Integer)
            pqty = value
        End Set
    End Property

    Private pdeptid As Integer
    Public Property deptid() As Integer
        Get
            Return pdeptid
        End Get
        Set(ByVal value As Integer)
            pdeptid = value
        End Set
    End Property






#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.BidDtl_ID = IIf(IsDBNull(rd("BidDtl_ID")), 0, rd("BidDtl_ID"))
            Me.Supplier_ID = IIf(IsDBNull(rd("Supplier_ID")), 0, rd("Supplier_ID"))
            Me.Cost = IIf(IsDBNull(rd("Cost")), 0.0, rd("Cost"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Discount = IIf(IsDBNull(rd("Discount")), 0, rd("Discount"))
            Me.BidHdr_ID = IIf(IsDBNull(rd("BidHdr_ID")), 0, rd("BidHdr_ID"))
            Me.Is_Award = IIf(IsDBNull(rd("Is_Award")), 0, rd("Is_Award"))
            Me.WithPO = IIf(IsDBNull(rd("WithPO")), 0, rd("WithPO"))
            Me.qty = IIf(IsDBNull(rd("qty")), 0, rd("qty"))
            Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))





        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub saveBidderDtl()
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect
        Dim i As Long

        objDerived.cmd.Parameters.AddWithValue("@BidDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Discount", Discount)
        objDerived.cmd.Parameters.AddWithValue("@BidHdr_ID", BidHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Is_Award", Is_Award)
        objDerived.cmd.Parameters.AddWithValue("@WithPO", WithPO)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Bidder_Dtl", CommandType.StoredProcedure, Nothing)
    End Sub




End Class
