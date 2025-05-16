Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class tbl_integrated_collections_table
    Inherits BaseDLL.BaseDAL

#Region "property"

    Private ptranscollectionID As Long
    Public Property transcollectionID() As Long
        Get
            Return ptranscollectionID
        End Get
        Set(ByVal value As Long)
            ptranscollectionID = value
        End Set
    End Property
    Private PTransaction_ID As Long
    Public Property Transaction_ID() As Long
        Get
            Return PTransaction_ID
        End Get
        Set(ByVal value As Long)
            PTransaction_ID = value
        End Set
    End Property
    Private PSystemDBase As String
    Public Property SystemDBase() As String
        Get
            Return PSystemDBase
        End Get
        Set(ByVal value As String)
            PSystemDBase = value
        End Set
    End Property
    Private pcollectionID As Integer
    Public Property collectionID() As Integer
        Get
            Return pcollectionID
        End Get
        Set(ByVal value As Integer)
            pcollectionID = value
        End Set
    End Property

    Private pGA_Code As Long
    Public Property GA_Code() As Long
        Get
            Return pGA_Code
        End Get
        Set(ByVal value As Long)
            pGA_Code = value
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
#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@transcollectionID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Transaction_ID", Transaction_ID)
        objDerived.cmd.Parameters.AddWithValue("@SystemDBase", SystemDBase)
        objDerived.cmd.Parameters.AddWithValue("@collectionID", collectionID)
        objDerived.cmd.Parameters.AddWithValue("@GA_Code", GA_Code)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "dbo.spSave_tbl_integrated_collections_table", CommandType.StoredProcedure, Nothing)
        Return i

    End Function

End Class
