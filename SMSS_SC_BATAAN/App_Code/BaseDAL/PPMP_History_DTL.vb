Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class PPMP_History_DTL
    Inherits BaseDLL.BaseDAL
#Region "Property"
    Private pPPMP_HIST_DTl As Long
    Public Property PPMP_HIST_DTl() As Long
        Get
            Return pPPMP_HIST_DTl
        End Get
        Set(ByVal value As Long)
            pPPMP_HIST_DTl = value
        End Set
    End Property

    Private pPPMP_HIST_HDR As Long
    Public Property PPMP_HIST_HDR() As Long
        Get
            Return pPPMP_HIST_HDR
        End Get
        Set(ByVal value As Long)
            pPPMP_HIST_HDR = value
        End Set
    End Property


    Private pItemcode As Integer
    Public Property Itemcode() As Integer
        Get
            Return pItemcode
        End Get
        Set(ByVal value As Integer)
            pItemcode = value
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

    Private pFirstQTY As Integer
    Public Property FirstQTY() As Integer
        Get
            Return pFirstQTY
        End Get
        Set(ByVal value As Integer)
            pFirstQTY = value
        End Set
    End Property

    Private pSecondQTY As Integer
    Public Property SecondQTY() As Integer
        Get
            Return pSecondQTY
        End Get
        Set(ByVal value As Integer)
            pSecondQTY = value
        End Set
    End Property


    Private pThirdQTY As Integer
    Public Property ThirdQTY() As Integer
        Get
            Return pThirdQTY
        End Get
        Set(ByVal value As Integer)
            pThirdQTY = value
        End Set
    End Property


    Private pFourthQTY As Integer
    Public Property FourthQTY() As Integer
        Get
            Return pFourthQTY
        End Get
        Set(ByVal value As Integer)
            pFourthQTY = value
        End Set
    End Property


#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@PPMP_HIST_DTl", 0)
        objDerived.cmd.Parameters.AddWithValue("@PPMP_HIST_HDR", PPMP_HIST_HDR)
        objDerived.cmd.Parameters.AddWithValue("@Itemcode", Itemcode)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@FirstQTY", FirstQTY)
        objDerived.cmd.Parameters.AddWithValue("@SecondQTY", SecondQTY)
        objDerived.cmd.Parameters.AddWithValue("@ThirdQTY", ThirdQTY)
        objDerived.cmd.Parameters.AddWithValue("@FourthQTY", FourthQTY)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "ams.spSave_PPMP_history_DTL", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

End Class
