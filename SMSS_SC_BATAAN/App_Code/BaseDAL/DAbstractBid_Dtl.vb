Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class DAbstractBid_Dtl
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pDABDtl_ID As Integer
    Public Property DABDtl_ID() As Integer
        Get
            Return pDABDtl_ID
        End Get
        Set(ByVal value As Integer)
            pDABDtl_ID = value
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

    Private pItem_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Integer)
            pItem_ID = value
        End Set
    End Property

    Private pPrice As Integer
    Public Property Price() As Integer
        Get
            Return pPrice
        End Get
        Set(ByVal value As Integer)
            pPrice = value
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

    Private pBidder_ID As Integer
    Public Property Bidder_ID() As Integer
        Get
            Return pBidder_ID
        End Get
        Set(ByVal value As Integer)
            pBidder_ID = value
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

    Private pDABHdr_ID As Integer
    Public Property DABHdr_ID() As Integer
        Get
            Return pDABHdr_ID
        End Get
        Set(ByVal value As Integer)
            pDABHdr_ID = value
        End Set
    End Property


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.DABDtl_ID = IIf(IsDBNull(rd("DABDtl_ID")), 0, rd("DABDtl_ID"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Price = IIf(IsDBNull(rd("Price")), 0, rd("Price"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.Bidder_ID = IIf(IsDBNull(rd("Bidder_ID")), 0, rd("Bidder_ID"))
            Me.Is_Award = IIf(IsDBNull(rd("Is_Award")), 0, rd("Is_Award"))
            Me.DABHdr_ID = IIf(IsDBNull(rd("DABHdr_ID")), 0, rd("DABHdr_ID"))




        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveDABDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DABDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Price", Price)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Bidder_ID", Bidder_ID)
        objDerived.cmd.Parameters.AddWithValue("@Is_Award", Is_Award)
        objDerived.cmd.Parameters.AddWithValue("@DABHdr_ID", DABHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_DAbstractofBids_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub
End Class
