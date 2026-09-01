Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_purchase_request_dtl

    Inherits BaseDLL.BaseDAL



#Region "properties"
    Private pPRDtlID As Long
    Public Property PRDtlID() As Long
        Get
            Return pPRDtlID
        End Get
        Set(ByVal value As Long)
            pPRDtlID = value
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

    Private pProject_title As String
    Public Property Project_title() As String
        Get
            Return pProject_title
        End Get
        Set(ByVal value As String)
            pProject_title = value
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

    Private pPRHdr_ID As Long
    Public Property PRHdr_ID() As Long
        Get
            Return pPRHdr_ID
        End Get
        Set(ByVal value As Long)
            pPRHdr_ID = value
        End Set
    End Property

    Private pppmp_dtl_id As Long
    Public Property ppmp_dtl_id() As Long
        Get
            Return pppmp_dtl_id
        End Get
        Set(ByVal value As Long)
            pppmp_dtl_id = value
        End Set
    End Property


    Private pPR_ItemSpecs As String
    Public Property PR_ItemSpecs() As String
        Get
            Return pPR_ItemSpecs
        End Get
        Set(ByVal value As String)
            pPR_ItemSpecs = value
        End Set
    End Property


#End Region




    Public Sub save()

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PRDtlID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        If Project_title <> "" Then
            objDerived.cmd.Parameters.AddWithValue("@Project_title", Project_title)
        End If
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", PRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ppmp_dtl_id", ppmp_dtl_id)
        objDerived.cmd.Parameters.AddWithValue("@PR_ItemSpecs", PR_ItemSpecs)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PR_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub


    Public Sub update()

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PRDtlID", PRDtlID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        If Project_title <> "" Then
            objDerived.cmd.Parameters.AddWithValue("@Project_title", Project_title)
        End If
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", PRHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@ppmp_dtl_id", ppmp_dtl_id)
        objDerived.cmd.Parameters.AddWithValue("@PR_ItemSpecs", PR_ItemSpecs)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_PR_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub


End Class
