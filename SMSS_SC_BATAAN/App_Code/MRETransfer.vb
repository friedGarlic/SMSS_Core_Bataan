Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class MRETransfer

    Inherits BaseDLL.BaseDAL

#Region "Transfer Property"

    Private pMRE_Transfer_ID As Integer
    Public Property MRE_Transfer_ID() As Integer
        Get
            Return pMRE_Transfer_ID
        End Get
        Set(ByVal value As Integer)
            pMRE_Transfer_ID = value
        End Set
    End Property

    Private pItem_ID As Nullable(Of Integer)
    Public Property Item_ID() As Nullable(Of Integer)
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            pItem_ID = value
        End Set
    End Property

    Private pMREHdr_ID As Nullable(Of Integer)
    Public Property MREHdr_ID() As Nullable(Of Integer)
        Get
            Return pMREHdr_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            pMREHdr_ID = value
        End Set
    End Property

    Private pMREDtl_ID As Nullable(Of Integer)
    Public Property MREDtl_ID() As Nullable(Of Integer)
        Get
            Return pMREDtl_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            pMREDtl_ID = value
        End Set
    End Property


    Private pIsApproved As Nullable(Of Boolean)
    Public Property IsApproved() As Nullable(Of Boolean)
        Get
            Return pIsApproved
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            pIsApproved = value
        End Set
    End Property

    Private pTransferedDate As String
    Public Property TransferedDate() As String
        Get
            Return pTransferedDate
        End Get
        Set(ByVal value As String)
            pTransferedDate = value
        End Set
    End Property

    Private pIsDisapproved As Nullable(Of Boolean)
    Public Property IsDisapproved() As Nullable(Of Boolean)
        Get
            Return pIsDisapproved
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            pIsDisapproved = value
        End Set
    End Property

    Private pTransferTo As String
    Public Property TransferTo() As String
        Get
            Return pTransferTo
        End Get
        Set(ByVal value As String)
            pTransferTo = value
        End Set
    End Property

    Private pDepartmentID As Nullable(Of Integer)
    Public Property DepartmentID() As Nullable(Of Integer)
        Get
            Return pDepartmentID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            pDepartmentID = value
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

    Public Sub saveMRETransfer()

        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect

        objDerived.cmd.Parameters.AddWithValue("@MRE_Transfer_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@MREHdr_ID", MREHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@MREDtl_ID", MREDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@IsApproved", IsApproved)
        objDerived.cmd.Parameters.AddWithValue("@TransferedDate", TransferedDate)
        objDerived.cmd.Parameters.AddWithValue("@IsDisapproved", IsDisapproved)
        objDerived.cmd.Parameters.AddWithValue("@TransferTo", TransferTo)
        objDerived.cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute(
            "@CurrID",
            "AMS.sp_Save_MRE_Transfer",
            CommandType.StoredProcedure,
            Nothing
        )

    End Sub

    Public Sub UpdateMRETransfer()

        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect

        objDerived.cmd.Parameters.AddWithValue("@MRE_Transfer_ID", MRE_Transfer_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@MREHdr_ID", MREHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@MREDtl_ID", MREDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@IsApproved", IsApproved)
        objDerived.cmd.Parameters.AddWithValue("@TransferedDate", TransferedDate)
        objDerived.cmd.Parameters.AddWithValue("@IsDisapproved", IsDisapproved)
        objDerived.cmd.Parameters.AddWithValue("@TransferTo", TransferTo)
        objDerived.cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute(
            "@CurrID",
            "AMS.sp_Save_MRE_Transfer",
            CommandType.StoredProcedure,
            Nothing
        )

    End Sub

End Class