Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic


Public Class dbmPRDTL
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
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

    Private pdbmHdr As Integer
    Public Property dbmHdr() As Integer
        Get
            Return pdbmHdr
        End Get
        Set(ByVal value As Integer)
            pdbmHdr = value
        End Set
    End Property


#End Region
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.ID = IIf(IsDBNull(rd("ID")), 0, rd("ID"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.Cost = IIf(IsDBNull(rd("Cost")), 0.0, rd("Cost"))
            Me.dbmHdr = IIf(IsDBNull(rd("dbmHdr")), 0, rd("dbmHdr"))



        End While
        If cn.State = System.Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public Function savedbmPRDTL() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@dbmHdr", dbmHdr)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "spSave_dbmPRDTL", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
