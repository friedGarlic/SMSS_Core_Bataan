Imports System
Imports Microsoft.VisualBasic

Public Class ManualCollectionsParticulars

    Inherits BaseDLL.BaseDAL

    Private pParticularsID As Integer

    Public Property ParticularsID() As Integer
        Get
            Return pParticularsID
        End Get
        Set(ByVal value As Integer)

            pParticularsID = value
        End Set
    End Property

    Private pdescription As String

    Public Property description() As String
        Get
            Return pdescription
        End Get
        Set(ByVal value As String)
            pdescription = value
        End Set
    End Property


    Private pORtypeID As String

    Public Property ORtypeID() As String
        Get
            Return pORtypeID
        End Get
        Set(ByVal value As String)
            pORtypeID = value
        End Set
    End Property
    Private pGA_code As Long
    Public Property GA_code() As Long
        Get
            Return pGA_code
        End Get
        Set(ByVal value As Long)
            pGA_code = value
        End Set
    End Property
    Private pF_ID As Integer
    Public Property F_ID() As Integer
        Get
            Return pF_ID
        End Get
        Set(ByVal value As Integer)
            pF_ID = value
        End Set
    End Property

    Private pGA_ID As Long
    Public Property GA_ID() As Long
        Get
            Return pGA_ID
        End Get
        Set(ByVal value As Long)
            pGA_ID = value
        End Set
    End Property
    Private pCollectionType As Long
    Public Property CollectionType() As Long
        Get
            Return pCollectionType
        End Get
        Set(ByVal value As Long)
            pCollectionType = value
        End Set
    End Property

    Private pfeetype As Long
    Public Property feetype() As Long
        Get
            Return pfeetype
        End Get
        Set(ByVal value As Long)
            pfeetype = value
        End Set
    End Property

    Private pFeeID As Long
    Public Property FeeID() As Long
        Get
            Return pFeeID
        End Get
        Set(ByVal value As Long)
            pFeeID = value
        End Set
    End Property

    Private pFeetypeDesc As String
    Public Property FeetypeDesc() As String
        Get
            Return pFeetypeDesc
        End Get
        Set(ByVal value As String)
            pFeetypeDesc = value
        End Set
    End Property
    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()

            ParticularsID = IIf(rd("ParticularsID"), 0, rd("particularsID"))
            description = IIf(rd("description"), 0, rd("description"))
            GA_code = IIf(IsDBNull(rd("GA_code")), 0, rd("GA_code"))
            ORtypeID = IIf(rd("OrtypeID"), 0, rd("OrtypeID"))
            F_ID = IIf(IsDBNull(rd("F_ID")), 0, rd("F_ID"))
            GA_ID = IIf(IsDBNull(rd("GA_ID")), 0, rd("GA_ID"))
            CollectionType = IIf(IsDBNull(rd("CollectionType")), 0, rd("CollectionType"))
            feetype = IIf(IsDBNull(rd("feetype")), 0, rd("feetype"))
            FeeID = IIf(IsDBNull(rd("FeeID")), 0, rd("FeeID"))
            FeetypeDesc = IIf(IsDBNull(rd("FeetypeDesc")), "", rd("FeetypeDesc"))
        End While

        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub


    Public Sub spSave_m_manualcollectionsparticulars()

        cmd.Parameters.AddWithValue("@description", description)
        cmd.Parameters.AddWithValue("@GA_code", GA_code)
        cmd.Parameters.AddWithValue("@ORtypeid", ORtypeID)
        cmd.Parameters.AddWithValue("@F_ID", F_ID)
        cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        cmd.Parameters.AddWithValue("@CollectionType", CollectionType)
        cmd.Parameters.AddWithValue("@feetype", feetype)
        cmd.Parameters.AddWithValue("@FeeID", FeeID)
        cmd.Parameters.AddWithValue("@FeetypeDesc", FeetypeDesc)
        cmd.Parameters.Add("@CurrID", Data.SqlDbType.BigInt).Direction = Data.ParameterDirection.Output
        Execute("@currID", "dbo.spSave_m_manualcollectionsparticulars", Data.CommandType.StoredProcedure)
    End Sub

End Class
