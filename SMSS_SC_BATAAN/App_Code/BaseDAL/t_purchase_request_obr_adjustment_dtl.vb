Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_purchase_request_obr_adjustment_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pobr_adjustment_dtl_id As Long
    Public Property obr_adjustment_dtl_id() As Long
        Get
            Return pobr_adjustment_dtl_id
        End Get
        Set(ByVal value As Long)
            pobr_adjustment_dtl_id = value
        End Set
    End Property

    Private pobr_adjustment_hdr_id As Long
    Public Property obr_adjustment_hdr_id() As Long
        Get
            Return pobr_adjustment_hdr_id
        End Get
        Set(ByVal value As Long)
            pobr_adjustment_hdr_id = value
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

    Private pAmount As Decimal
    Public Property Amount() As Decimal
        Get
            Return pAmount
        End Get
        Set(ByVal value As Decimal)
            pAmount = value
        End Set
    End Property

    Private pnew_amount As Decimal
    Public Property new_amount() As Decimal
        Get
            Return pnew_amount
        End Get
        Set(ByVal value As Decimal)
            pnew_amount = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@obr_adjustment_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@obr_adjustment_hdr_id", obr_adjustment_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@BGA_ID", BGA_ID)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@new_amount", new_amount)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_obr_adjustment_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
