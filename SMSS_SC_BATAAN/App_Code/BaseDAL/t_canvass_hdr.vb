Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports System

Public Class t_canvass_hdr
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pcanvass_hdr_id As Long
    Public Property canvass_hdr_id() As Long
        Get
            Return pcanvass_hdr_id
        End Get
        Set(ByVal value As Long)
            pcanvass_hdr_id = value
        End Set
    End Property

    Private pprhdr_id As Long
    Public Property prhdr_id() As Long
        Get
            Return pprhdr_id
        End Get
        Set(ByVal value As Long)
            pprhdr_id = value
        End Set
    End Property

    Private pSupplier_Id As Long
    Public Property Supplier_Id() As Long
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Long)
            pSupplier_Id = value
        End Set
    End Property

    Private pdateT As DateTime
    Public Property dateT() As DateTime
        Get
            Return pdateT
        End Get
        Set(ByVal value As DateTime)
            pdateT = value
        End Set
    End Property

    Private pamount As Decimal
    Public Property amount() As Decimal
        Get
            Return pamount
        End Get
        Set(ByVal value As Decimal)
            pamount = value
        End Set
    End Property

    Private pisWinner As Boolean
    Public Property isWinner() As Boolean
        Get
            Return pisWinner
        End Get
        Set(ByVal value As Boolean)
            pisWinner = value
        End Set
    End Property




#End Region

    Public Function save() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@canvass_hdr_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@prhdr_id", prhdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@date", dateT)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_canvass_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@canvass_hdr_id", canvass_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@prhdr_id", prhdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@date", dateT)
        objDerived.cmd.Parameters.AddWithValue("@amount", amount)
        objDerived.cmd.Parameters.AddWithValue("@isWinner", isWinner)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_canvass_hdr", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
