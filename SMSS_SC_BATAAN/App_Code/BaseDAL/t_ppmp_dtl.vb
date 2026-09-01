Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_ppmp_dtl
    Inherits BaseDLL.BaseDAL

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

    Private pUnitPrice As Decimal
    Public Property UnitPrice() As Decimal
        Get
            Return pUnitPrice
        End Get
        Set(ByVal value As Decimal)
            pUnitPrice = value
        End Set
    End Property


    Private iJan As Decimal
    Public Property Jan() As Decimal
        Get
            Return iJan
        End Get
        Set(ByVal value As Decimal)
            iJan = value
        End Set
    End Property
    Private iFeb As Decimal
    Public Property Feb() As Decimal
        Get
            Return iFeb
        End Get
        Set(ByVal value As Decimal)
            iFeb = value
        End Set
    End Property
    Private iMar As Decimal
    Public Property Mar() As Decimal
        Get
            Return iMar
        End Get
        Set(ByVal value As Decimal)
            iMar = value
        End Set
    End Property
    Private iApr As Decimal
    Public Property Apr() As Decimal
        Get
            Return iApr
        End Get
        Set(ByVal value As Decimal)
            iApr = value
        End Set
    End Property
    Private iMay As Decimal
    Public Property May() As Decimal
        Get
            Return iMay
        End Get
        Set(ByVal value As Decimal)
            iMay = value
        End Set
    End Property
    Private iJun As Decimal
    Public Property Jun() As Decimal
        Get
            Return iJun
        End Get
        Set(ByVal value As Decimal)
            iJun = value
        End Set
    End Property
    Private iJul As Decimal
    Public Property Jul() As Decimal
        Get
            Return iJul
        End Get
        Set(ByVal value As Decimal)
            iJul = value
        End Set
    End Property
    Private iAug As Decimal
    Public Property Aug() As Decimal
        Get
            Return iAug
        End Get
        Set(ByVal value As Decimal)
            iAug = value
        End Set
    End Property
    Private iSep As Decimal
    Public Property Sep() As Decimal
        Get
            Return iSep
        End Get
        Set(ByVal value As Decimal)
            iSep = value
        End Set
    End Property
    Private iOct As Decimal
    Public Property Oct() As Decimal
        Get
            Return iOct
        End Get
        Set(ByVal value As Decimal)
            iOct = value
        End Set
    End Property
    Private iNov As Decimal
    Public Property Nov() As Decimal
        Get
            Return iNov
        End Get
        Set(ByVal value As Decimal)
            iNov = value
        End Set
    End Property
    Private iDec As Decimal
    Public Property Dec() As Decimal
        Get
            Return iDec
        End Get
        Set(ByVal value As Decimal)
            iDec = value
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


    Private pFirstQty As Decimal
    Public Property firstqty() As Decimal
        Get
            Return pFirstQty
        End Get
        Set(ByVal value As Decimal)
            pFirstQty = value
        End Set
    End Property

    Private pSecondQty As Decimal
    Public Property secondqty() As Decimal
        Get
            Return pSecondQty
        End Get
        Set(ByVal value As Decimal)
            pSecondQty = value
        End Set
    End Property

    Private pThirdQty As Decimal
    Public Property thirdqty() As Decimal
        Get
            Return pThirdQty
        End Get
        Set(ByVal value As Decimal)
            pThirdQty = value
        End Set
    End Property

    Private pFourthQty As Decimal
    Public Property fourthqty() As Decimal
        Get
            Return pFourthQty
        End Get
        Set(ByVal value As Decimal)
            pFourthQty = value
        End Set
    End Property

    Private pFirstQtyBal As Decimal
    Public Property firstqtybal() As Decimal
        Get
            Return pFirstQtyBal
        End Get
        Set(ByVal value As Decimal)
            pFirstQtyBal = value
        End Set
    End Property

    Private pSecondQtyBal As Decimal
    Public Property secondqtybal() As Decimal
        Get
            Return pSecondQtyBal
        End Get
        Set(ByVal value As Decimal)
            pSecondQtyBal = value
        End Set
    End Property

    Private pThirdQtyBal As Decimal
    Public Property thirdqtybal() As Decimal
        Get
            Return pThirdQtyBal
        End Get
        Set(ByVal value As Decimal)
            pThirdQtyBal = value
        End Set
    End Property

    Private pFourthQtyBal As Decimal
    Public Property fourthqtybal() As Decimal
        Get
            Return pFourthQtyBal
        End Get
        Set(ByVal value As Decimal)
            pFourthQtyBal = value
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

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@ppmp_dtl_id", 0)
        objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", ppmp_hdr_id)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice)
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
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_ppmp_dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


End Class
