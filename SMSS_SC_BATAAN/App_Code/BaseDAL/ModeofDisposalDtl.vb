Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class ModeofDisposalDtl
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pMDDtl_ID As Integer
    Public Property MDDtl_ID() As Integer
        Get
            Return pMDDtl_ID
        End Get
        Set(ByVal value As Integer)
            pMDDtl_ID = value
        End Set
    End Property

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
        End Set
    End Property

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
        End Set
    End Property

    Private pPrice As Decimal
    Public Property Price() As Decimal
        Get
            Return pPrice
        End Get
        Set(ByVal value As Decimal)
            pPrice = value
        End Set
    End Property

    Private pModeosdisposal As String
    Public Property Modeosdisposal() As String
        Get
            Return pModeosdisposal
        End Get
        Set(ByVal value As String)
            pModeosdisposal = value
        End Set
    End Property

    Private pMDHdr_ID As Integer
    Public Property MDHdr_ID() As Integer
        Get
            Return pMDHdr_ID
        End Get
        Set(ByVal value As Integer)
            pMDHdr_ID = value
        End Set
    End Property





#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.MDDtl_ID = IIf(IsDBNull(rd("MDDtl_ID")), 0, rd("MDDtl_ID"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.Price = IIf(IsDBNull(rd("Price")), 0.0, rd("Price"))
            Me.Modeosdisposal = IIf(IsDBNull(rd("Modeosdisposal")), "", rd("Modeosdisposal"))
            Me.MDHdr_ID = IIf(IsDBNull(rd("MDHdr_ID")), 0, rd("MDHdr_ID"))




        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub


    Public Sub saveMDDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect

        objDerived.cmd.Parameters.AddWithValue("@MDDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Price", Price)
        objDerived.cmd.Parameters.AddWithValue("@Modeosdisposal", Modeosdisposal)
        objDerived.cmd.Parameters.AddWithValue("@MDHdr_ID", MDHdr_ID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_ModeofDisposal_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub


End Class
