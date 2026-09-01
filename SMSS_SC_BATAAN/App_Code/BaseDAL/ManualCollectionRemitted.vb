Imports System
Imports Microsoft.VisualBasic

Public Class ManualCollectionRemitted
    Inherits BaseDLL.BaseDAL

    Private pMCHdr_ID As Integer
    Public Property MCHdr_ID() As Integer
        Get
            Return pMCHdr_ID
        End Get
        Set(ByVal value As Integer)
            pMCHdr_ID = value
        End Set
    End Property

    Private pamountcollected As Decimal
    Public Property amountcollected() As Decimal
        Get
            Return pamountcollected
        End Get
        Set(ByVal value As Decimal)
            pamountcollected = value
        End Set
    End Property

    Private pdateremitted As DateTime
    Public Property dateremitted() As DateTime
        Get
            Return pdateremitted
        End Get
        Set(ByVal value As DateTime)
            pdateremitted = value
        End Set
    End Property

    Private pbeg_OR As String
    Public Property beg_OR() As String
        Get
            Return pbeg_OR
        End Get
        Set(ByVal value As String)
            pbeg_OR = value
        End Set
    End Property

    Private pbeg_endOR As String
    Public Property beg_endOR() As String
        Get
            Return pbeg_endOR
        End Get
        Set(ByVal value As String)
            pbeg_endOR = value
        End Set
    End Property

    Private pbeg_Quantity As Integer
    Public Property beg_Quantity() As Integer
        Get
            Return pbeg_Quantity
        End Get
        Set(ByVal value As Integer)
            pbeg_Quantity = value
        End Set
    End Property

    Private pIssued_StartingOR As String
    Public Property Issued_StartingOR() As String
        Get
            Return pIssued_StartingOR
        End Get
        Set(ByVal value As String)
            pIssued_StartingOR = value
        End Set
    End Property

    Private pIssued_EndingOR As String
    Public Property Issued_EndingOR() As String
        Get
            Return pIssued_EndingOR
        End Get
        Set(ByVal value As String)
            pIssued_EndingOR = value
        End Set
    End Property

    Private pIssued_Qty As Integer
    Public Property Issued_Qty() As Integer
        Get
            Return pIssued_Qty
        End Get
        Set(ByVal value As Integer)
            pIssued_Qty = value
        End Set
    End Property

    Private pEnd_StartingOR As String
    Public Property End_StartingOR() As String
        Get
            Return pEnd_StartingOR
        End Get
        Set(ByVal value As String)
            pEnd_StartingOR = value
        End Set
    End Property

    Private pEnd_EndingOR As String
    Public Property End_EndingOR() As String
        Get
            Return pEnd_EndingOR
        End Get
        Set(ByVal value As String)
            pEnd_EndingOR = value
        End Set
    End Property

    Private pEnd_Qty As Integer
    Public Property End_Qty() As Integer
        Get
            Return pEnd_Qty
        End Get
        Set(ByVal value As Integer)
            pEnd_Qty = value
        End Set
    End Property

    Private pTOS_isremitted As Boolean
    Public Property TOS_isremitted() As Boolean
        Get
            Return pTOS_isremitted
        End Get
        Set(ByVal value As Boolean)
            pTOS_isremitted = value
        End Set
    End Property

    Private pORtypeID As Integer
    Public Property ORtypeID() As Integer
        Get
            Return pORtypeID
        End Get
        Set(ByVal value As Integer)
            pORtypeID = value
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

    Private pUserID As String
    Public Property UserID() As String
        Get
            Return pUserID
        End Get
        Set(ByVal value As String)
            pUserID = value
        End Set



    End Property


    Private pisdeposit As Boolean

    Public Property isDeposit() As Boolean
        Get
            Return pisdeposit
        End Get
        Set(ByVal value As Boolean)
            pisdeposit = value
        End Set



    End Property

    Private pdateDeposited As Date

    Public Property dateDeposited() As Date
        Get
            Return pdateDeposited
        End Get
        Set(ByVal value As Date)
            pdateDeposited = value
        End Set



    End Property

    Private pFid As Integer

    Public Property Fid() As Integer
        Get
            Return pFid
        End Get
        Set(ByVal value As Integer)
            pFid = value
        End Set



    End Property

    Private pAccountId As Integer

    Public Property AccountID() As Integer
        Get
            Return pAccountId
        End Get
        Set(ByVal value As Integer)
            pAccountId = value
        End Set



    End Property





    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
        cn.Open()
        rd = cmd.ExecuteReader
        While rd.Read()

            MCHdr_ID = IIf(IsDBNull(rd("MCHdr_ID")), 0, rd("MCHdr_ID"))
            amountcollected = IIf(IsDBNull(rd("amountcollected")), 0.0, rd("amountcollected"))
            dateremitted = IIf(IsDBNull(rd("dateremitted")), "", rd("dateremitted"))
            beg_OR = IIf(IsDBNull(rd("beg_OR")), "", rd("beg_OR"))
            beg_endOR = IIf(IsDBNull(rd("beg_endOR")), "", rd("beg_endOR"))
            beg_Quantity = IIf(IsDBNull(rd("beg_Quantity")), 0, rd("beg_Quantity"))
            Issued_StartingOR = IIf(IsDBNull(rd("Issued_StartingOR")), "", rd("Issued_StartingOR"))
            Issued_EndingOR = IIf(IsDBNull(rd("Issued_EndingOR")), "", rd("Issued_EndingOR"))
            Issued_Qty = IIf(IsDBNull(rd("Issued_Qty")), 0, rd("Issued_Qty"))
            End_StartingOR = IIf(IsDBNull(rd("End_StartingOR")), "", rd("End_StartingOR"))
            End_EndingOR = IIf(IsDBNull(rd("End_EndingOR")), "", rd("End_EndingOR"))
            End_Qty = IIf(IsDBNull(rd("End_Qty")), 0, rd("End_Qty"))
            TOS_isremitted = IIf(IsDBNull(rd("TOS_isremitted")), 0, rd("TOS_isremitted"))
            ORtypeID = IIf(IsDBNull(rd("ORtypeID")), 0, rd("ORtypeID"))
            RCD = IIf(IsDBNull(rd("RCD")), 0, rd("RCD"))
            UserID = IIf(IsDBNull(rd("UserID")), 0, rd("UserID"))
            isDeposit = IIf(IsDBNull(rd("isDeposit")), 0, rd("isDeposit"))
            dateDeposited = IIf(IsDBNull(rd("datedeposited")), 0, rd("datedeposited"))
            Fid = IIf(IsDBNull(rd("fid")), 0, rd("fid"))
            AccountID = IIf(IsDBNull(rd("accountid")), 0, rd("accountid"))


        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Function spSave_ManualCollectionsRemitted() As Integer

        ' cmd.Parameters.AddWithValue("@MCHdr_ID", 0)
        cmd.Parameters.AddWithValue("@amountcollected", amountcollected)
        cmd.Parameters.AddWithValue("@dateremitted", dateremitted)
        cmd.Parameters.AddWithValue("@beg_OR", beg_OR)
        cmd.Parameters.AddWithValue("@beg_endOR", beg_endOR)
        cmd.Parameters.AddWithValue("@beg_Quantity", beg_Quantity)
        cmd.Parameters.AddWithValue("@Issued_StartingOR", Issued_StartingOR)
        cmd.Parameters.AddWithValue("@Issued_EndingOR", Issued_EndingOR)
        cmd.Parameters.AddWithValue("@Issued_Qty", Issued_Qty)
        cmd.Parameters.AddWithValue("@End_StartingOR", End_StartingOR)
        cmd.Parameters.AddWithValue("@End_EndingOR", End_EndingOR)
        cmd.Parameters.AddWithValue("@End_Qty", End_Qty)
        cmd.Parameters.AddWithValue("@TOS_isremitted", TOS_isremitted)
        cmd.Parameters.AddWithValue("@ORtypeID", ORtypeID)
        cmd.Parameters.AddWithValue("@RCD", RCD)
        cmd.Parameters.AddWithValue("@UserID", UserID)
        cmd.Parameters.AddWithValue("@isdeposit", isDeposit)
        cmd.Parameters.AddWithValue("@datedeposited", dateDeposited)
        cmd.Parameters.AddWithValue("@fid", Fid)
        cmd.Parameters.AddWithValue("@accountid", AccountID)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Return Execute("@CurrID", "dbo.spSave_ManualCollectionsRemitted", Data.CommandType.StoredProcedure)

    End Function


End Class
