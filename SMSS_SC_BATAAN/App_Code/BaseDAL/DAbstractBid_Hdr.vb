Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class DAbstractBid_Hdr
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pDABHdr_ID As Integer
    Public Property DABHdr_ID() As Integer
        Get
            Return pDABHdr_ID
        End Get
        Set(ByVal value As Integer)
            pDABHdr_ID = value
        End Set
    End Property

    Private pOpening_Bid As DateTime
    Public Property Opening_Bid() As DateTime
        Get
            Return pOpening_Bid
        End Get
        Set(ByVal value As DateTime)
            pOpening_Bid = value
        End Set
    End Property

    Private pAbstractNo As String
    Public Property AbstractNo() As String
        Get
            Return pAbstractNo
        End Get
        Set(ByVal value As String)
            pAbstractNo = value
        End Set
    End Property

    Private pAChairman As String
    Public Property AChairman() As String
        Get
            Return pAChairman
        End Get
        Set(ByVal value As String)
            pAChairman = value
        End Set
    End Property

    Private pAMember1 As String
    Public Property AMember1() As String
        Get
            Return pAMember1
        End Get
        Set(ByVal value As String)
            pAMember1 = value
        End Set
    End Property

    Private pAMember2 As String
    Public Property AMember2() As String
        Get
            Return pAMember2
        End Get
        Set(ByVal value As String)
            pAMember2 = value
        End Set
    End Property

    Private pAMember3 As String
    Public Property AMember3() As String
        Get
            Return pAMember3
        End Get
        Set(ByVal value As String)
            pAMember3 = value
        End Set
    End Property


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.DABHdr_ID = IIf(IsDBNull(rd("DABHdr_ID")), 0, rd("DABHdr_ID"))
            Me.Opening_Bid = IIf(IsDBNull(rd("Opening_Bid")), "", rd("Opening_Bid"))
            Me.AbstractNo = IIf(IsDBNull(rd("AbstractNo")), "", rd("AbstractNo"))
            Me.AChairman = IIf(IsDBNull(rd("AChairman")), "", rd("AChairman"))
            Me.AMember1 = IIf(IsDBNull(rd("AMember1")), "", rd("AMember1"))
            Me.AMember2 = IIf(IsDBNull(rd("AMember2")), "", rd("AMember2"))
            Me.AMember3 = IIf(IsDBNull(rd("AMember3")), "", rd("AMember3"))



        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveDABHdr()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@DABHdr_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Opening_Bid", Opening_Bid)
        objDerived.cmd.Parameters.AddWithValue("@AbstractNo", AbstractNo)
        objDerived.cmd.Parameters.AddWithValue("@AChairman", AChairman)
        objDerived.cmd.Parameters.AddWithValue("@AMember1", AMember1)
        objDerived.cmd.Parameters.AddWithValue("@AMember2", AMember2)
        objDerived.cmd.Parameters.AddWithValue("@AMember3", AMember3)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_DAbstractofBids_Hdr", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
