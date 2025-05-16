Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class ICSDtl
    Inherits BaseDLL.BaseDAL

#Region "Property"
    Private pICSDt_lID As Integer
    Public Property ICSDt_lID() As Integer
        Get
            Return pICSDt_lID
        End Get
        Set(ByVal value As Integer)
            pICSDt_lID = value
        End Set
    End Property

    Private pICSHdr_ID As Integer
    Public Property ICSHdr_ID() As Integer
        Get
            Return pICSHdr_ID
        End Get
        Set(ByVal value As Integer)
            pICSHdr_ID = value
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

    Private pQty As Decimal
    Public Property Qty() As Decimal
        Get
            Return pQty
        End Get
        Set(ByVal value As Decimal)
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


    Private pStatus As String
    Public Property Status() As String
        Get
            Return pStatus
        End Get
        Set(ByVal value As String)
            pStatus = value
        End Set
    End Property

    Private pRemarks As String
    Public Property Remarks() As String
        Get
            Return pRemarks
        End Get
        Set(ByVal value As String)
            pRemarks = value
        End Set
    End Property




#End Region

    Public Function saveICSDtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ICSDt_lID", 0)
        objDerived.cmd.Parameters.AddWithValue("@ICSHdr_ID", ICSHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ICS_Dtl", CommandType.StoredProcedure, Nothing)


        Return i
    End Function

    Public Function updateICSDtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ICSDt_lID", ICSDt_lID)
        objDerived.cmd.Parameters.AddWithValue("@ICSHdr_ID", ICSHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Remakrs", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_ICS_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
