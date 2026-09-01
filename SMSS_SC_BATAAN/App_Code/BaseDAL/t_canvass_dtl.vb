Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_canvass_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pcanvass_dtl_id As Long
    Public Property canvass_dtl_id() As Long
        Get
            Return pcanvass_dtl_id
        End Get
        Set(ByVal value As Long)
            pcanvass_dtl_id = value
        End Set
    End Property

    Private pcanvass_hdr_id As Long
    Public Property canvass_hdr_id() As Long
        Get
            Return pcanvass_hdr_id
        End Get
        Set(ByVal value As Long)
            pcanvass_hdr_id = value
        End Set
    End Property

    Private pitem_id As Integer
    Public Property item_id() As Integer
        Get
            Return pitem_id
        End Get
        Set(ByVal value As Integer)
            pitem_id = value
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

    Private pCost As Decimal
    Public Property Cost() As Decimal
        Get
            Return pCost
        End Get
        Set(ByVal value As Decimal)
            pCost = value
        End Set
    End Property


#End Region

    Public Function save() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@canvass_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@canvass_hdr_id", canvass_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@item_id", item_id)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_canvass_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
    Public Function update() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@canvass_dtl_id", canvass_dtl_id)
        objDerived.cmd.Parameters.AddWithValue("@canvass_hdr_id", canvass_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@item_id", item_id)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_canvass_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
