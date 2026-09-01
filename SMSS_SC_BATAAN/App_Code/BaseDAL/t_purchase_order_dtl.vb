Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_purchase_order_dtl
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pPODtl_ID As Long
    Public Property PODtl_ID() As Long
        Get
            Return pPODtl_ID
        End Get
        Set(ByVal value As Long)
            pPODtl_ID = value
        End Set
    End Property

    Private pItem_ID As Long
    Public Property Item_ID() As Long
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Long)
            pItem_ID = value
        End Set
    End Property

    Private pqty As Decimal
    Public Property qty() As Decimal
        Get
            Return pqty
        End Get
        Set(ByVal value As Decimal)
            pqty = value
        End Set
    End Property

    Private pcost As Decimal
    Public Property cost() As Decimal
        Get
            Return pcost
        End Get
        Set(ByVal value As Decimal)
            pcost = value
        End Set
    End Property

    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
        End Set
    End Property
    Private premarks As String
    Public Property remarks() As String
        Get
            Return premarks
        End Get
        Set(ByVal value As String)
            premarks = value
        End Set
    End Property

#End Region
    Public Function save() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PODtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        'objDerived.cmd.Parameters.AddWithValue("@cost", cost)

        Dim costDecimal As Decimal
        If Decimal.TryParse(cost.ToString(), costDecimal) Then
            'objDerived.cmd.Parameters.AddWithValue("@cost", costDecimal)
            ' Ensure that the cost is passed as a Decimal
            objDerived.cmd.Parameters.AddWithValue("@cost", CDec(costDecimal))

        Else
            ' Handle invalid cost value, set a default value or flag an error
            objDerived.cmd.Parameters.AddWithValue("@cost", 0D) ' or handle error
        End If


        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PO_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PODtl_ID", PODtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@qty", qty)
        'objDerived.cmd.Parameters.AddWithValue("@cost", cost)

        Dim costDecimal As Decimal
        If Decimal.TryParse(cost.ToString(), costDecimal) Then
            objDerived.cmd.Parameters.AddWithValue("@cost", CDec(costDecimal))
        Else
            ' Handle invalid cost value, set a default value or flag an error
            objDerived.cmd.Parameters.AddWithValue("@cost", 0D) ' or handle error
        End If


        objDerived.cmd.Parameters.AddWithValue("@remarks", remarks)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PO_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
