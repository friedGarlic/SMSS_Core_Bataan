Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class IADtl
    Inherits BaseDLL.BaseDAL


#Region "Property"
    Private pIADtl_ID As Integer
    Public Property IADtl_ID() As Integer
        Get
            Return pIADtl_ID
        End Get
        Set(ByVal value As Integer)
            pIADtl_ID = value
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

    Private pAppraisedValue As Decimal
    Public Property AppraisedValue() As Decimal
        Get
            Return pAppraisedValue
        End Get
        Set(ByVal value As Decimal)
            pAppraisedValue = value
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

    Private pRepair As String
    Public Property Repair() As String
        Get
            Return pRepair
        End Get
        Set(ByVal value As String)
            pRepair = value
        End Set
    End Property

    Private pDispose As String
    Public Property Dispose() As String
        Get
            Return pDispose
        End Get
        Set(ByVal value As String)
            pDispose = value
        End Set
    End Property

    Private pStatus As String
    Public Property Status() As String
        Get
            Return pStatus
        End Get
        Set(ByVal value As String)
            pStatus = value
        End Set
    End Property

    Private pModeofDisposal As String
    Public Property ModeofDisposal() As String
        Get
            Return pModeofDisposal
        End Get
        Set(ByVal value As String)
            pModeofDisposal = value
        End Set
    End Property

    Private pIAHdr_ID As Integer
    Public Property IAHdr_ID() As Integer
        Get
            Return pIAHdr_ID
        End Get
        Set(ByVal value As Integer)
            pIAHdr_ID = value
        End Set
    End Property

    Private pIIRUPDtl_ID As Integer
    Public Property IIRUPDtl_ID() As Integer
        Get
            Return pIIRUPDtl_ID
        End Get
        Set(ByVal value As Integer)
            pIIRUPDtl_ID = value
        End Set
    End Property

    Private pRemarks As String
    Public Property Remarks() As String
        Get
            Return pRemarks
        End Get
        Set(ByVal value As String)
            pRemarks = value
        End Set
    End Property



#End Region

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)

        cn.Open()
        rd = cmd.ExecuteReader

        While rd.Read()
            Me.IADtl_ID = IIf(IsDBNull(rd("IADtl_ID")), 0, rd("IADtl_ID"))
            Me.Qty = IIf(IsDBNull(rd("Qty")), 0, rd("Qty"))
            Me.PropertyNo = IIf(IsDBNull(rd("PropertyNo")), "", rd("PropertyNo"))
            Me.AppraisedValue = IIf(IsDBNull(rd("AppraisedValue")), 0.0, rd("AppraisedValue"))
            Me.Item_ID = IIf(IsDBNull(rd("Item_ID")), 0, rd("Item_ID"))
            Me.Repair = IIf(IsDBNull(rd("Repair")), "", rd("Repair"))
            Me.Dispose = IIf(IsDBNull(rd("Dispose")), "", rd("Dispose"))
            Me.Status = IIf(IsDBNull(rd("Status")), "", rd("Status"))
            Me.ModeofDisposal = IIf(IsDBNull(rd("ModeofDisposal")), "", rd("ModeofDisposal"))
            Me.IAHdr_ID = IIf(IsDBNull(rd("IAHdr_ID")), 0, rd("IAHdr_ID"))
            Me.IIRUPDtl_ID = IIf(IsDBNull(rd("IIRUPDtl_ID")), 0, rd("IIRUPDtl_ID"))
            Me.Remarks = IIf(IsDBNull(rd("Remarks")), "", rd("Remarks"))




        End While
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Public Sub saveIADtl()
        Dim objDerived As New DerivedDal
        Dim i As Long

        conStr = objDerived.DbaseConnect
        objDerived.cmd.Parameters.AddWithValue("@IADtl_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@AppraisedValue", AppraisedValue)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Repair", Repair)
        objDerived.cmd.Parameters.AddWithValue("@Dispose", Dispose)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@ModeofDisposal", ModeofDisposal)
        objDerived.cmd.Parameters.AddWithValue("@IAHdr_ID", IAHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@IIRUPDtl_ID", IIRUPDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output

        i = objDerived.Execute("@CurrID", "AMS.spSave_InspectionAppraisal_Dtl", CommandType.StoredProcedure, Nothing)

    End Sub


End Class
