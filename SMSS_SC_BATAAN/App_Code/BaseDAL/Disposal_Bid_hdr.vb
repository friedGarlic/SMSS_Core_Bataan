Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class Disposal_bid_hdr
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pDisposal_Bid_hdr_id As Integer
    Public Property Disposal_Bid_hdr_id() As Integer
        Get
            Return pDisposal_Bid_hdr_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_Bid_hdr_id = value
        End Set
    End Property

    Private pquotation_hdr_id As Integer
    Public Property quotation_hdr_id() As Integer
        Get
            Return pquotation_hdr_id
        End Get
        Set(ByVal value As Integer)
            pquotation_hdr_id = value
        End Set
    End Property

    Private pDisposal_id As Integer
    Public Property Disposal_id() As Integer
        Get
            Return pDisposal_id
        End Get
        Set(ByVal value As Integer)
            pDisposal_id = value
        End Set
    End Property

    Private pBidDate As DateTime
    Public Property BidDate() As DateTime
        Get
            Return pBidDate
        End Get
        Set(ByVal value As DateTime)
            pBidDate = value
        End Set
    End Property

    Private pBidNo As String
    Public Property BidNo() As String
        Get
            Return pBidNo
        End Get
        Set(ByVal value As String)
            pBidNo = value
        End Set
    End Property

    Private pawarddate As DateTime
    Public Property awarddate() As DateTime
        Get
            Return pawarddate
        End Get
        Set(ByVal value As DateTime)
            pawarddate = value
        End Set
    End Property



#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Disposal_Bid_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@quotation_hdr_id", quotation_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Disposal_id", Disposal_id)
        objDerived.cmd.Parameters.AddWithValue("@BidDate", BidDate)
        objDerived.cmd.Parameters.AddWithValue("@BidNo", BidNo)
        objDerived.cmd.Parameters.AddWithValue("@awarddate", awarddate)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_Disposal_Bid_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
