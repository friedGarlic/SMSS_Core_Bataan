Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System
Public Class DonationgLguToLgu
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pDonationLGUtoLGU_ID As Integer
    Public Property DonationLGUtoLGU_ID() As Integer
        Get
            Return pDonationLGUtoLGU_ID
        End Get
        Set(ByVal value As Integer)
            pDonationLGUtoLGU_ID = value
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

    Private pItem_Description As String
    Public Property Item_Description() As String
        Get
            Return pItem_Description
        End Get
        Set(ByVal value As String)
            pItem_Description = value
        End Set
    End Property

    Private pLGU_Department As String
    Public Property LGU_Department() As String
        Get
            Return pLGU_Department
        End Get
        Set(ByVal value As String)
            pLGU_Department = value
        End Set
    End Property

    Private pReceivedby As String
    Public Property Receivedby() As String
        Get
            Return pReceivedby
        End Get
        Set(ByVal value As String)
            pReceivedby = value
        End Set
    End Property

    Private pReceivedby_position As String
    Public Property Receivedby_position() As String
        Get
            Return pReceivedby_position
        End Get
        Set(ByVal value As String)
            pReceivedby_position = value
        End Set
    End Property

    Private pDate_Received As String
    Public Property Date_Received() As String
        Get
            Return pDate_Received
        End Get
        Set(ByVal value As String)
            pDate_Received = value
        End Set
    End Property


    Private pReceivedFrom_Dep_ID As Integer
    Public Property ReceivedFrom_Dep_ID() As Integer
        Get
            Return pReceivedFrom_Dep_ID
        End Get
        Set(ByVal value As Integer)
            pReceivedFrom_Dep_ID = value
        End Set
    End Property

    Private pIssuedBy_ID As Integer
    Public Property IssuedBy_ID() As Integer
        Get
            Return pIssuedBy_ID
        End Get
        Set(ByVal value As Integer)
            pIssuedBy_ID = value
        End Set
    End Property

    Private pDate_Issued As String
    Public Property Date_Issued() As String
        Get
            Return pDate_Issued
        End Get
        Set(ByVal value As String)
            pDate_Issued = value
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

    Public Function saveDonation_LGU_TO_LGU() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DonationLGUtoLGU_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Item_Description", Item_Description)
        objDerived.cmd.Parameters.AddWithValue("@LGU_Department", LGU_Department)
        objDerived.cmd.Parameters.AddWithValue("@Receivedby", Receivedby)
        objDerived.cmd.Parameters.AddWithValue("@Receivedby_position", Receivedby_position)
        objDerived.cmd.Parameters.AddWithValue("@Date_Received", Date_Received)
        objDerived.cmd.Parameters.AddWithValue("@ReceivedFrom_Dep_ID", ReceivedFrom_Dep_ID)
        objDerived.cmd.Parameters.AddWithValue("@IssuedBy_ID", IssuedBy_ID)
        objDerived.cmd.Parameters.AddWithValue("@Date_Issued", Date_Issued)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)


        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSaveTbDonationLGUtoLGU", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
