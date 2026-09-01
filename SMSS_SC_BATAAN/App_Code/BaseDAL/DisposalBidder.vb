Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class DisposalBidder
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pBidder_ID As Integer
    Public Property Bidder_ID() As Integer
        Get
            Return pBidder_ID
        End Get
        Set(ByVal value As Integer)
            pBidder_ID = value
        End Set
    End Property

    Private pBidder_Fname As String
    Public Property Bidder_Fname() As String
        Get
            Return pBidder_Fname
        End Get
        Set(ByVal value As String)
            pBidder_Fname = value
        End Set
    End Property

    Private pBidder_Mname As String
    Public Property Bidder_Mname() As String
        Get
            Return pBidder_Mname
        End Get
        Set(ByVal value As String)
            pBidder_Mname = value
        End Set
    End Property

    Private pBidder_Lname As String
    Public Property Bidder_Lname() As String
        Get
            Return pBidder_Lname
        End Get
        Set(ByVal value As String)
            pBidder_Lname = value
        End Set
    End Property

    Private pBidder_FullName As String
    Public Property Bidder_FullName() As String
        Get
            Return pBidder_FullName
        End Get
        Set(ByVal value As String)
            pBidder_FullName = value
        End Set
    End Property

    Private pAddress As String
    Public Property Address() As String
        Get
            Return pAddress
        End Get
        Set(ByVal value As String)
            pAddress = value
        End Set
    End Property

    Private pContact_Number As String
    Public Property Contact_Number() As String
        Get
            Return pContact_Number
        End Get
        Set(ByVal value As String)
            pContact_Number = value
        End Set
    End Property



#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.Bidder_ID = IIf(IsDBNull(rd("Bidder_ID")), 0, rd("Bidder_ID"))
            Me.Bidder_Fname = IIf(IsDBNull(rd("Bidder_Fname")), "", rd("Bidder_Fname"))
            Me.Bidder_Mname = IIf(IsDBNull(rd("Bidder_Mname")), "", rd("Bidder_Mname"))
            Me.Bidder_Lname = IIf(IsDBNull(rd("Bidder_Lname")), "", rd("Bidder_Lname"))
            Me.Bidder_FullName = IIf(IsDBNull(rd("Bidder_FullName")), "", rd("Bidder_FullName"))
            Me.Address = IIf(IsDBNull(rd("Address")), "", rd("Address"))
            Me.Contact_Number = IIf(IsDBNull(rd("Contact_Number")), "", rd("Contact_Number"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveDisposalBidder()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@Bidder_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Bidder_Fname", Bidder_Fname)
        objDerived.cmd.Parameters.AddWithValue("@Bidder_Mname", Bidder_Mname)
        objDerived.cmd.Parameters.AddWithValue("@Bidder_Lname", Bidder_Lname)
        objDerived.cmd.Parameters.AddWithValue("@Bidder_FullName", Bidder_FullName)
        objDerived.cmd.Parameters.AddWithValue("@Address", Address)
        objDerived.cmd.Parameters.AddWithValue("@Contact_Number", Contact_Number)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_DisposalBidder", CommandType.StoredProcedure, Nothing)

    End Sub
End Class
