Imports System
Imports Microsoft.VisualBasic

Public Class ORHistory

    Inherits BaseDLL.BaseDAL
    Private pORID As Integer
    Public Property ORID() As Integer
        Get
            Return pORID
        End Get
        Set(ByVal value As Integer)
            pORID = value
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

    Private pdateAcquired As DateTime
    Public Property dateAcquired() As DateTime
        Get
            Return pdateAcquired
        End Get
        Set(ByVal value As DateTime)
            pdateAcquired = value
        End Set
    End Property

    Private pstubNo As Integer
    Public Property stubNo() As Integer
        Get
            Return pstubNo
        End Get
        Set(ByVal value As Integer)
            pstubNo = value
        End Set
    End Property

    Private pStartingOR As String
    Public Property StartingOR() As String
        Get
            Return pStartingOR
        End Get
        Set(ByVal value As String)
            pStartingOR = value
        End Set
    End Property

    Private pEndingOR As String
    Public Property EndingOR() As String
        Get
            Return pEndingOR
        End Get
        Set(ByVal value As String)
            pEndingOR = value
        End Set
    End Property

    Private pQuantity As Integer
    Public Property Quantity() As Integer
        Get
            Return pQuantity
        End Get
        Set(ByVal value As Integer)
            pQuantity = value
        End Set
    End Property

    Private pconsumed As Boolean
    Public Property consumed() As Boolean
        Get
            Return pconsumed
        End Get
        Set(ByVal value As Boolean)
            pconsumed = value
        End Set
    End Property

    Private pactive As Boolean
    Public Property active() As Boolean
        Get
            Return pactive
        End Get
        Set(ByVal value As Boolean)
            pactive = value
        End Set
    End Property

    Private pcurrentOR As String
    Public Property currentOR() As String
        Get
            Return pcurrentOR
        End Get
        Set(ByVal value As String)
            pcurrentOR = value
        End Set
    End Property

    Private pFormDescID As Integer
    Public Property FormDescID() As Integer
        Get
            Return pFormDescID
        End Get
        Set(ByVal value As Integer)
            pFormDescID = value
        End Set
    End Property

    Private pMiscFieldFeeID As Integer
    Public Property MiscFieldFeeID() As Integer
        Get
            Return pMiscFieldFeeID
        End Get
        Set(ByVal value As Integer)
            pMiscFieldFeeID = value
        End Set
    End Property

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()


            ORID = IIf(IsDBNull(rd("ORID")), 0, rd("ORID"))
            userID = IIf(IsDBNull(rd("userID")), 0, rd("userID"))
            dateAcquired = IIf(IsDBNull(rd("dateAcquired")), "", rd("dateAcquired"))
            stubNo = IIf(IsDBNull(rd("stubNo")), 0, rd("stubNo"))
            StartingOR = IIf(IsDBNull(rd("StartingOR")), "", rd("StartingOR"))
            EndingOR = IIf(IsDBNull(rd("EndingOR")), "", rd("EndingOR"))
            Quantity = IIf(IsDBNull(rd("Quantity")), 0, rd("Quantity"))
            consumed = IIf(IsDBNull(rd("consumed")), 0, rd("consumed"))
            active = IIf(IsDBNull(rd("active")), 0, rd("active"))

            currentOR = IIf(IsDBNull(rd("currentOR")), "", rd("currentOR"))
            MiscFieldFeeID = IIf(IsDBNull(rd("MiscFieldFeeID")), 0, rd("MiscFieldFeeID"))
            ' FormDescID = IIf(IsDBNull(rd("FormDescID")), 0, rd("FormDescID"))



        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Function spSave_manualCollectionsORHistory()

        'cmd.Parameters.AddWithValue("@ORID", 0)
        cmd.Parameters.AddWithValue("@userID", userID)
        cmd.Parameters.AddWithValue("@dateAcquired", dateAcquired)
        cmd.Parameters.AddWithValue("@stubNo", stubNo)
        cmd.Parameters.AddWithValue("@StartingOR", StartingOR)
        cmd.Parameters.AddWithValue("@EndingOR", EndingOR)
        cmd.Parameters.AddWithValue("@Quantity", Quantity)
        cmd.Parameters.AddWithValue("@consumed", consumed)
        cmd.Parameters.AddWithValue("@active", active)
        ' cmd.Parameters.AddWithValue("@FormDescID", FormDescID)
        cmd.Parameters.AddWithValue("@currentOR", currentOR)
        cmd.Parameters.AddWithValue("@MiscFieldFeeID", MiscFieldFeeID)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Return Execute("@CurrID", "dbo.spSave_manualCollectionsORHistory", Data.CommandType.StoredProcedure)

    End Function



End Class
