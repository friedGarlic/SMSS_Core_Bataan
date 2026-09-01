Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Public Class t_ppmp_dtl_monthly
    Inherits BaseDLL.BaseDAL
    ' Existing properties

    ' Monthly properties
    Public Property Jan As Decimal
    Public Property Feb As Decimal
    Public Property Mar As Decimal
    Public Property Apr As Decimal
    Public Property May As Decimal
    Public Property Jun As Decimal
    Public Property Jul As Decimal
    Public Property Aug As Decimal
    Public Property Sep As Decimal
    Public Property Oct As Decimal
    Public Property Nov As Decimal
    Public Property Dec As Decimal

    ' Constructor (optional)
    Public Sub New()
        Jan = 0
        Feb = 0
        Mar = 0
        Apr = 0
        May = 0
        Jun = 0
        Jul = 0
        Aug = 0
        Sep = 0
        Oct = 0
        Nov = 0
        Dec = 0
    End Sub

#Region "property"
    Private pppmp_dtl_id As Long
    Public Property ppmp_dtl_id() As Long
        Get
            Return pppmp_dtl_id
        End Get
        Set(ByVal value As Long)
            pppmp_dtl_id = value
        End Set
    End Property

    Private pppmp_hdr_id As Integer
    Public Property ppmp_hdr_id() As Integer
        Get
            Return pppmp_hdr_id
        End Get
        Set(ByVal value As Integer)
            pppmp_hdr_id = value
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

    Private pCost As Decimal
    Public Property Cost() As Decimal
        Get
            Return pCost
        End Get
        Set(ByVal value As Decimal)
            pCost = value
        End Set
    End Property

    Private pfirstqty As Decimal
    Public Property firstqty() As Decimal
        Get
            Return pfirstqty
        End Get
        Set(ByVal value As Decimal)
            pfirstqty = value
        End Set
    End Property

    Private psecondqty As Decimal
    Public Property secondqty() As Decimal
        Get
            Return psecondqty
        End Get
        Set(ByVal value As Decimal)
            psecondqty = value
        End Set
    End Property

    Private pthirdqty As Decimal
    Public Property thirdqty() As Decimal
        Get
            Return pthirdqty
        End Get
        Set(ByVal value As Decimal)
            pthirdqty = value
        End Set
    End Property

    Private pfourthqty As Decimal
    Public Property fourthqty() As Decimal
        Get
            Return pfourthqty
        End Get
        Set(ByVal value As Decimal)
            pfourthqty = value
        End Set
    End Property

    Private pfirstqtybal As Decimal
    Public Property firstqtybal() As Decimal
        Get
            Return pfirstqtybal
        End Get
        Set(ByVal value As Decimal)
            pfirstqtybal = value
        End Set
    End Property

    Private psecondqtybal As Decimal
    Public Property secondqtybal() As Decimal
        Get
            Return psecondqtybal
        End Get
        Set(ByVal value As Decimal)
            psecondqtybal = value
        End Set
    End Property

    Private pthirdqtybal As Decimal
    Public Property thirdqtybal() As Decimal
        Get
            Return pthirdqtybal
        End Get
        Set(ByVal value As Decimal)
            pthirdqtybal = value
        End Set
    End Property

    Private pfourthqtybal As Decimal
    Public Property fourthqtybal() As Decimal
        Get
            Return pfourthqtybal
        End Get
        Set(ByVal value As Decimal)
            pfourthqtybal = value
        End Set
    End Property

    Private pUserid As String
    Public Property Userid() As String
        Get
            Return pUserid
        End Get
        Set(ByVal value As String)
            pUserid = value
        End Set
    End Property



#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ppmp_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", ppmp_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@firstqty", firstqty)
        objDerived.cmd.Parameters.AddWithValue("@secondqty", secondqty)
        objDerived.cmd.Parameters.AddWithValue("@thirdqty", thirdqty)
        objDerived.cmd.Parameters.AddWithValue("@fourthqty", fourthqty)
        objDerived.cmd.Parameters.AddWithValue("@firstqtybal", firstqtybal)
        objDerived.cmd.Parameters.AddWithValue("@secondqtybal", secondqtybal)
        objDerived.cmd.Parameters.AddWithValue("@thirdqtybal", thirdqtybal)
        objDerived.cmd.Parameters.AddWithValue("@fourthqtybal", fourthqtybal)
        objDerived.cmd.Parameters.AddWithValue("@Userid", Userid)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ppmp_dtl_New", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function Update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect

        ' Pass monthly values as parameters
        objDerived.cmd.Parameters.AddWithValue("@ppmp_dtl_id", ppmp_dtl_id)
        objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", ppmp_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@Jan", Jan)
        objDerived.cmd.Parameters.AddWithValue("@Feb", Feb)
        objDerived.cmd.Parameters.AddWithValue("@Mar", Mar)
        objDerived.cmd.Parameters.AddWithValue("@Apr", Apr)
        objDerived.cmd.Parameters.AddWithValue("@May", May)
        objDerived.cmd.Parameters.AddWithValue("@Jun", Jun)
        objDerived.cmd.Parameters.AddWithValue("@Jul", Jul)
        objDerived.cmd.Parameters.AddWithValue("@Aug", Aug)
        objDerived.cmd.Parameters.AddWithValue("@Sep", Sep)
        objDerived.cmd.Parameters.AddWithValue("@Oct", Oct)
        objDerived.cmd.Parameters.AddWithValue("@Nov", Nov)
        objDerived.cmd.Parameters.AddWithValue("@Dec", Dec)
        objDerived.cmd.Parameters.AddWithValue("@Userid", Userid)

        ' Output parameter for the current ID
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ppmp_dtl", CommandType.StoredProcedure, Nothing)

        Return i
    End Function




End Class
