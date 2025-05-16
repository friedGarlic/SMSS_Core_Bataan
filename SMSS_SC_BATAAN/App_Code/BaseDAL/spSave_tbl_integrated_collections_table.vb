Imports System
Imports Microsoft.VisualBasic

Public Class spSave_tbl_integrated_collections_table
    Inherits BaseDLL.BaseDAL
    Private ptranscollectionID As Long
    Public Property transcollectionID() As Long
        Get
            Return ptranscollectionID
        End Get
        Set(ByVal value As Long)
            ptranscollectionID = value
        End Set
    End Property

    Private pTransaction_ID As Long
    Public Property Transaction_ID() As Long
        Get
            Return pTransaction_ID
        End Get
        Set(ByVal value As Long)
            pTransaction_ID = value
        End Set
    End Property

    Private pSystemDBase As String
    Public Property SystemDBase() As String
        Get
            Return pSystemDBase
        End Get
        Set(ByVal value As String)
            pSystemDBase = value
        End Set
    End Property

    Private pcollectionID As Long
    Public Property collectionID() As Long
        Get
            Return pcollectionID
        End Get
        Set(ByVal value As Long)
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

    Private pSupplier_ID As Long
    Public Property Supplier_ID() As Long
        Get
            Return pSupplier_ID
        End Get
        Set(ByVal value As Long)
            pSupplier_ID = value
        End Set
    End Property

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()
            Me.transcollectionID = IIf(IsDBNull(rd("transcollectionID")), 0, rd("transcollectionID"))
            Me.Transaction_ID = IIf(IsDBNull(rd("Transaction_ID")), 0, rd("Transaction_ID"))
            Me.SystemDBase = IIf(IsDBNull(rd("SystemDBase")), "", rd("SystemDBase"))
            Me.collectionID = IIf(IsDBNull(rd("collectionID")), 0, rd("collectionID"))
            Me.GA_Code = IIf(IsDBNull(rd("GA_Code")), 0, rd("GA_Code"))
            Me.Supplier_ID = IIf(IsDBNull(rd("Supplier_ID")), 0, rd("Supplier_ID"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Sub spSave_tbl_integrated_collections_table()
        ' cmd.Parameters.AddWithValue("@OfficeID", 0)
        'Me.cmd.Parameters.AddWithValue("@transcollectionID", 0)
        Me.cmd.Parameters.AddWithValue("@Transaction_ID", Transaction_ID)
        Me.cmd.Parameters.AddWithValue("@SystemDBase", SystemDBase)
        Me.cmd.Parameters.AddWithValue("@collectionID", collectionID)
        Me.cmd.Parameters.AddWithValue("@GA_Code", GA_Code)
        Me.cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Execute("dbo.spSave_tbl_integrated_collections_table", Data.CommandType.StoredProcedure)
    End Sub
End Class
