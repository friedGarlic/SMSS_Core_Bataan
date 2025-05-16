Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class NoticeAuctionDtl
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pNADtl_ID As Integer
    Public Property NADtl_ID() As Integer
        Get
            Return pNADtl_ID
        End Get
        Set(ByVal value As Integer)
            pNADtl_ID = value
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

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
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

    Private pBidPrice As Decimal
    Public Property BidPrice() As Decimal
        Get
            Return pBidPrice
        End Get
        Set(ByVal value As Decimal)
            pBidPrice = value
        End Set
    End Property

    Private pBidder_ID As Integer
    Public Property Bidder_ID() As Integer
        Get
            Return pBidder_ID
        End Get
        Set(ByVal value As Integer)
            pBidder_ID = value
        End Set
    End Property

    Private pNAHdr_ID As Integer
    Public Property NAHdr_ID() As Integer
        Get
            Return pNAHdr_ID
        End Get
        Set(ByVal value As Integer)
            pNAHdr_ID = value
        End Set
    End Property

    Private pNADate As DateTime
    Public Property NADate() As DateTime
        Get
            Return pNADate
        End Get
        Set(ByVal value As DateTime)
            pNADate = value
        End Set
    End Property

    Private pwithBID As Boolean
    Public Property withBID() As Boolean
        Get
            Return pwithBID
        End Get
        Set(ByVal value As Boolean)
            pwithBID = value
        End Set
    End Property



#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.NADtl_ID = IIf(IsDBNull(rd("NADtl_ID")), 0, rd("NADtl_ID"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.qty = IIf(IsDBNull(rd("qty")), 0, rd("qty"))
            Me.BidPrice = IIf(IsDBNull(rd("BidPrice")), 0.0, rd("BidPrice"))
            Me.Bidder_ID = IIf(IsDBNull(rd("Bidder_ID")), 0, rd("Bidder_ID"))
            Me.NAHdr_ID = IIf(IsDBNull(rd("NAHdr_ID")), 0, rd("NAHdr_ID"))
            Me.NADate = IIf(IsDBNull(rd("NADate")), "", rd("NADate"))
            Me.withBID = IIf(IsDBNull(rd("withBID")), 0, rd("withBID"))





        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveNADtl()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@NADtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        objDerived.cmd.Parameters.AddWithValue("@BidPrice", BidPrice)
        objDerived.cmd.Parameters.AddWithValue("@Bidder_ID", Bidder_ID)
        objDerived.cmd.Parameters.AddWithValue("@NAHdr_ID", NAHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@NADate", NADate)
        objDerived.cmd.Parameters.AddWithValue("@withBID", withBID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_NoticeAuction_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub


End Class
