Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System
Public Class DonationLguToLgu_Dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pDonationLGUtoLGU_Dtl_ID As Integer
    Public Property DonationLGUtoLGU_Dtl_ID() As Integer
        Get
            Return pDonationLGUtoLGU_Dtl_ID
        End Get
        Set(ByVal value As Integer)
            pDonationLGUtoLGU_Dtl_ID = value
        End Set
    End Property

    Private pDonationLGUtoLGU_ID As Integer
    Public Property DonationLGUtoLGU_ID() As Integer
        Get
            Return pDonationLGUtoLGU_ID
        End Get
        Set(ByVal value As Integer)
            pDonationLGUtoLGU_ID = value
        End Set
    End Property

    Private pItem_Description As String
    Public Property Item_Description() As String
        Get
            Return pItem_Description
        End Get
        Set(ByVal value As String)
            pItem_Description = value
        End Set
    End Property

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
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

    Private pstatus As String
    Public Property status() As String
        Get
            Return pstatus
        End Get
        Set(ByVal value As String)
            pstatus = value
        End Set
    End Property

    Private pProperty_Dtl_ID As Integer
    Public Property Property_Dtl_ID() As Integer
        Get
            Return pProperty_Dtl_ID
        End Get
        Set(ByVal value As Integer)
            pProperty_Dtl_ID = value
        End Set
    End Property

#End Region

    Public Function saveDonation_LGU_TO_LGU_Dtl() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DonationLGUtoLGU_Dtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@DonationLGUtoLGU_ID", DonationLGUtoLGU_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_Description", Item_Description)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@status", status)
        objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", pProperty_Dtl_ID)



        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_TbDonationLGUtoLGU_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
