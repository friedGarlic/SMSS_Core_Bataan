Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_PR_Canvass
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pPR_Canvass_ID As Long
    Public Property PR_Canvass_ID() As Long
        Get
            Return pPR_Canvass_ID
        End Get
        Set(ByVal value As Long)
            pPR_Canvass_ID = value
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

    Private pItem_ID As Long
    Public Property Item_ID() As Long
        Get
            Return pItem_ID
        End Get
        Set(ByVal value As Long)
            pItem_ID = value
        End Set
    End Property

    Private pwithWinner As Boolean
    Public Property withWinner() As Boolean
        Get
            Return pwithWinner
        End Get
        Set(ByVal value As Boolean)
            pwithWinner = value
        End Set
    End Property

    Private pcanvass_hdr_id As Long
    Public Property canvass_hdr_id() As Long
        Get
            Return pcanvass_hdr_id
        End Get
        Set(ByVal value As Long)
            pcanvass_hdr_id = value
        End Set
    End Property



#End Region

    Public Function save() As Long

        Dim objDerived As New DerivedDal
        objDerived.conStr = objDerived.DbaseConnect()

        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PR_Canvass_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PRHdr_ID", prhdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@withWinner", withWinner)
        objDerived.cmd.Parameters.AddWithValue("@canvass_hdr_id", canvass_hdr_id)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_pr_canvass", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
