Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class RepairandMaintenanceDtl
    Inherits BaseDLL.BaseDAL

#Region "Property"

    Private pRMDtl_ID As Integer
    Public Property RMDtl_ID() As Integer
        Get
            Return pRMDtl_ID
        End Get
        Set(ByVal value As Integer)
            pRMDtl_ID = value
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

    Private pPropertyNo As String
    Public Property PropertyNo() As String
        Get
            Return pPropertyNo
        End Get
        Set(ByVal value As String)
            pPropertyNo = value
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

    Private pRepairedDate As DateTime
    Public Property RepairedDate() As DateTime
        Get
            Return pRepairedDate
        End Get
        Set(ByVal value As DateTime)
            pRepairedDate = value
        End Set
    End Property

    Private pCostofRepair As Decimal
    Public Property CostofRepair() As Decimal
        Get
            Return pCostofRepair
        End Get
        Set(ByVal value As Decimal)
            pCostofRepair = value
        End Set
    End Property

    Private pNatureofRepair As String
    Public Property NatureofRepair() As String
        Get
            Return pNatureofRepair
        End Get
        Set(ByVal value As String)
            pNatureofRepair = value
        End Set
    End Property

    Private pRMHdr_ID As Integer
    Public Property RMHdr_ID() As Integer
        Get
            Return pRMHdr_ID
        End Get
        Set(ByVal value As Integer)
            pRMHdr_ID = value
        End Set
    End Property

    Private pMaterialneeded As Integer
    Public Property Materialneeded() As Integer
        Get
            Return pMaterialneeded
        End Get
        Set(ByVal value As Integer)
            pMaterialneeded = value
        End Set
    End Property

    Private pDefects As String
    Public Property Defects() As String
        Get
            Return pDefects
        End Get
        Set(ByVal value As String)
            pDefects = value
        End Set
    End Property


#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.RMDtl_ID = IIf(IsDBNull(rd("RMDtl_ID")), 0, rd("RMDtl_ID"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.RepairedDate = IIf(IsDBNull(rd("RepairedDate")), "", rd("RepairedDate"))
            Me.CostofRepair = IIf(IsDBNull(rd("CostofRepair")), 0.0, rd("CostofRepair"))
            Me.NatureofRepair = IIf(IsDBNull(rd("NatureofRepair")), "", rd("NatureofRepair"))
            Me.RMHdr_ID = IIf(IsDBNull(rd("RMHdr_ID")), 0, rd("RMHdr_ID"))
            Me.Materialneeded = IIf(IsDBNull(rd("Materialneeded")), 0, rd("Materialneeded"))
            Me.Defects = IIf(IsDBNull(rd("Defects")), "", rd("Defects"))







        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveRMDtl()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@RMDtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@RepairedDate", RepairedDate)
        objDerived.cmd.Parameters.AddWithValue("@CostofRepair", CostofRepair)
        objDerived.cmd.Parameters.AddWithValue("@NatureofRepair", NatureofRepair)
        objDerived.cmd.Parameters.AddWithValue("@RMHdr_ID", RMHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Materialneeded", Materialneeded)
        objDerived.cmd.Parameters.AddWithValue("@Defects", "")
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_RepairMaintenance_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub

End Class
