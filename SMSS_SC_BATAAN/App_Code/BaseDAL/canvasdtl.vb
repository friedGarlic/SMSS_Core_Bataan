Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Public Class canvasdtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pcnvasdtl_id As Integer
    Public Property cnvasdtl_id() As Integer
        Get
            Return pcnvasdtl_id
        End Get
        Set(ByVal value As Integer)
            pcnvasdtl_id = value
        End Set
    End Property

    Private pSupplier_Id As Integer
    Public Property Supplier_Id() As Integer
        Get
            Return pSupplier_Id
        End Get
        Set(ByVal value As Integer)
            pSupplier_Id = value
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

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
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

    Private pdatecanvas As DateTime
    Public Property datecanvas() As DateTime
        Get
            Return pdatecanvas
        End Get
        Set(ByVal value As DateTime)
            pdatecanvas = value
        End Set
    End Property

    Private pcnvashdr_id As Integer
    Public Property cnvashdr_id() As Integer
        Get
            Return pcnvashdr_id
        End Get
        Set(ByVal value As Integer)
            pcnvashdr_id = value
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

    Private pCompliance As Boolean
    Public Property Compliance() As Boolean
        Get
            Return pCompliance
        End Get
        Set(ByVal value As Boolean)
            pCompliance = value
        End Set
    End Property



#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.cnvasdtl_id = IIf(IsDBNull(rd("cnvasdtl_id")), 0, rd("cnvasdtl_id"))
            Me.Supplier_Id = IIf(IsDBNull(rd("Supplier_Id")), 0, rd("Supplier_Id"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.Cost = IIf(IsDBNull(rd("Cost")), 0.0, rd("Cost"))
            Me.datecanvas = IIf(IsDBNull(rd("datecanvas")), "", rd("datecanvas"))
            Me.cnvashdr_id = IIf(IsDBNull(rd("cnvashdr_id")), 0, rd("cnvashdr_id"))
            Me.deptid = IIf(IsDBNull(rd("deptid")), 0, rd("deptid"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function saveCanvasDtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@cnvasdtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@datecanvas", datecanvas)
        objDerived.cmd.Parameters.AddWithValue("@cnvashdr_id", cnvashdr_id)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@Compliance", Compliance)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_cnvasdtl_id", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
