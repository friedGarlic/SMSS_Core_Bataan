Imports System
Imports Microsoft.VisualBasic

Public Class ManualCollections
    Inherits BaseDLL.BaseDAL

    Private pcollectionID As Integer
    Public Property collectionID() As Integer
        Get
            Return pcollectionID
        End Get
        Set(ByVal value As Integer)
            pcollectionID = value
        End Set
    End Property

    Private pparticulars As String
    Public Property particulars() As String
        Get
            Return pparticulars
        End Get
        Set(ByVal value As String)
            pparticulars = value
        End Set
    End Property

    Private pamount As Decimal
    Public Property amount() As Decimal
        Get
            Return pamount
        End Get
        Set(ByVal value As Decimal)
            pamount = value
        End Set
    End Property

    Private pORno As String
    Public Property ORno() As String
        Get
            Return pORno
        End Get
        Set(ByVal value As String)
            pORno = value
        End Set
    End Property

    Private puserID As String
    Public Property userID() As String
        Get
            Return puserID
        End Get
        Set(ByVal value As String)
            puserID = value
        End Set
    End Property

    Private pdateremitted As Date
    Public Property dateremitted() As Date
        Get
            Return pdateremitted
        End Get
        Set(ByVal value As Date)
            pdateremitted = value
        End Set
    End Property

    Private pischeck As Boolean
    Public Property ischeck() As Boolean
        Get
            Return pischeck
        End Get
        Set(ByVal value As Boolean)
            pischeck = value
        End Set
    End Property

    Private pcheckno As String
    Public Property checkno() As String
        Get
            Return pcheckno
        End Get
        Set(ByVal value As String)
            pcheckno = value
        End Set
    End Property

    Private ppayee As String
    Public Property payee() As String
        Get
            Return ppayee
        End Get
        Set(ByVal value As String)
            ppayee = value
        End Set
    End Property

    Private pisremitted As Boolean
    Public Property isremitted() As Boolean
        Get
            Return pisremitted
        End Get
        Set(ByVal value As Boolean)
            pisremitted = value
        End Set
    End Property

    Private pRCD As String
    Public Property RCD() As String
        Get
            Return pRCD
        End Get
        Set(ByVal value As String)
            pRCD = value
        End Set
    End Property

    Private pisTreasWarrant As Boolean
    Public Property isTreasWarrant() As Boolean
        Get
            Return pisTreasWarrant
        End Get
        Set(ByVal value As Boolean)
            pisTreasWarrant = value
        End Set
    End Property

    Private pTreasWarrantChecknum As String
    Public Property TreasWarrantChecknum() As String
        Get
            Return pTreasWarrantChecknum
        End Get
        Set(ByVal value As String)
            pTreasWarrantChecknum = value
        End Set
    End Property

    Private pisMoneyOrder As Boolean
    Public Property isMoneyOrder() As Boolean
        Get
            Return pisMoneyOrder
        End Get
        Set(ByVal value As Boolean)
            pisMoneyOrder = value
        End Set
    End Property

    Private pORID As Integer
    Public Property ORID() As Integer
        Get
            Return pORID
        End Get
        Set(ByVal value As Integer)
            pORID = value
        End Set
    End Property

    Private pTD_ID As Integer
    Public Property TD_ID() As Integer
        Get
            Return pTD_ID
        End Get
        Set(ByVal value As Integer)
            pTD_ID = value
        End Set
    End Property

    Private pORTypeID As Integer
    Public Property ORTypeID() As Integer
        Get
            Return pORTypeID
        End Get
        Set(ByVal value As Integer)
            pORTypeID = value
        End Set
    End Property

    Private pparticularsdesc As String
    Public Property particularsdesc() As String
        Get
            Return pparticularsdesc
        End Get
        Set(ByVal value As String)
            pparticularsdesc = value
        End Set
    End Property

    Private pFD_ID As Integer
    Public Property FD_ID() As Integer
        Get
            Return pFD_ID
        End Get
        Set(ByVal value As Integer)
            pFD_ID = value
        End Set
    End Property

    Private pbankname As String
    Public Property bankname() As String
        Get
            Return pbankname
        End Get
        Set(ByVal value As String)
            pbankname = value
        End Set
    End Property

    Private pcheckdate As String
    Public Property checkdate() As String
        Get
            Return pcheckdate
        End Get
        Set(ByVal value As String)
            pcheckdate = value
        End Set
    End Property

    Private piscancelled As Boolean
    Public Property iscancelled() As Boolean
        Get
            Return piscancelled
        End Get
        Set(ByVal value As Boolean)
            piscancelled = value
        End Set
    End Property

    Private pendingOR As String
    Public Property endingOR() As String
        Get
            Return pendingOR
        End Get
        Set(ByVal value As String)
            pendingOR = value
        End Set
    End Property


    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()

            collectionID = IIf(IsDBNull(rd("collectionID")), 0, rd("collectionID"))
            particulars = IIf(IsDBNull(rd("particulars")), "", rd("particulars"))
            amount = IIf(IsDBNull(rd("amount")), 0.0, rd("amount"))
            ORno = IIf(IsDBNull(rd("ORno")), "", rd("ORno"))
            userID = IIf(IsDBNull(rd("userID")), 0, rd("userID"))
            dateremitted = IIf(IsDBNull(rd("dateremitted")), "", rd("dateremitted"))
            ischeck = IIf(IsDBNull(rd("ischeck")), 0, rd("ischeck"))
            checkno = IIf(IsDBNull(rd("checkno")), "", rd("checkno"))
            payee = IIf(IsDBNull(rd("payee")), "", rd("payee"))
            isremitted = IIf(IsDBNull(rd("isremitted")), 0, rd("isremitted"))
            'RCD = IIf(IsDBNull(rd("RCD")), "", rd("RCD"))
            isTreasWarrant = IIf(IsDBNull(rd("isTreasWarrant")), 0, rd("isTreasWarrant"))
            TreasWarrantChecknum = IIf(IsDBNull(rd("TreasWarrantChecknum")), "", rd("TreasWarrantChecknum"))
            isMoneyOrder = IIf(IsDBNull(rd("isMoneyOrder")), 0, rd("isMoneyOrder"))
            ORID = IIf(IsDBNull(rd("ORID")), 0, rd("ORID"))
            ORTypeID = IIf(IsDBNull(rd("ORTypeID")), 0, rd("ORTypeID"))
            particularsdesc = IIf(IsDBNull(rd("particularsdesc")), "", rd("particularsdesc"))
            FD_ID = IIf(IsDBNull(rd("FD_ID")), 0, rd("FD_ID"))
            bankname = IIf(IsDBNull(rd("bankname")), "", rd("bankname"))
            checkdate = IIf(IsDBNull(rd("checkdate")), "", rd("checkdate"))
            iscancelled = IIf(IsDBNull(rd("iscancelled")), "", rd("iscancelled"))

            endingOR = IIf(IsDBNull(rd("endingOR")), "", rd("endingOR"))
        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Function spSave_ManualCollections() As Integer
        'cmd.parameters.addwithvalue("@collectionID", 0)
        cmd.Parameters.AddWithValue("@particulars", particulars)
        cmd.Parameters.AddWithValue("@amount", amount)
        cmd.Parameters.AddWithValue("@ORno", ORno)
        cmd.Parameters.AddWithValue("@userID", userID)
        cmd.Parameters.AddWithValue("@dateremitted", dateremitted)
        cmd.Parameters.AddWithValue("@ischeck", ischeck)
        cmd.Parameters.AddWithValue("@checkno", checkno)
        cmd.Parameters.AddWithValue("@payee", payee)
        cmd.Parameters.AddWithValue("@isremitted", isremitted)
        cmd.Parameters.AddWithValue("@isTreasWarrant", isTreasWarrant)
        cmd.Parameters.AddWithValue("@TreasWarrantChecknum", TreasWarrantChecknum)
        cmd.Parameters.AddWithValue("@isMoneyOrder", isMoneyOrder)
        cmd.Parameters.AddWithValue("@ORID", ORID)
        cmd.Parameters.AddWithValue("@ORTypeID", ORTypeID)
        cmd.Parameters.AddWithValue("@particularsdesc", particularsdesc)
        cmd.Parameters.AddWithValue("@FD_ID", FD_ID)
        cmd.Parameters.AddWithValue("@bankname", bankname)
        cmd.Parameters.AddWithValue("@checkdate", checkdate)
        cmd.Parameters.AddWithValue("@iscancelled", iscancelled)
        cmd.Parameters.AddWithValue("@endingOR", endingOR)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Return Execute("@CurrID", "dbo.spSave_ManualCollections", Data.CommandType.StoredProcedure)

    End Function




End Class
