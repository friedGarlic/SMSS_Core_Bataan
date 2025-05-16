Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class t_property_dtl
    Inherits BaseDLL.BaseDAL
#Region "property"
    Private pPropertyDetai_ID As Long
    Public Property PropertyDetai_ID() As Long
        Get
            Return pPropertyDetai_ID
        End Get
        Set(ByVal value As Long)
            pPropertyDetai_ID = value
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

    Private pProperty_ID As Integer
    Public Property Property_ID() As Integer
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Integer)
            pProperty_ID = value
        End Set
    End Property

    Private pBarcode As String
    Public Property Barcode() As String
        Get
            Return pBarcode
        End Get
        Set(ByVal value As String)
            pBarcode = value
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

    Private pIssued As Boolean
    Public Property Issued() As Boolean
        Get
            Return pIssued
        End Get
        Set(ByVal value As Boolean)
            pIssued = value
        End Set
    End Property

    Private pRepair As Boolean
    Public Property Repair() As Boolean
        Get
            Return pRepair
        End Get
        Set(ByVal value As Boolean)
            pRepair = value
        End Set
    End Property

    Private pDetails As String
    Public Property Details() As String
        Get
            Return pDetails
        End Get
        Set(ByVal value As String)
            pDetails = value
        End Set
    End Property

    Private pDispose As Boolean
    Public Property Dispose() As Boolean
        Get
            Return pDispose
        End Get
        Set(ByVal value As Boolean)
            pDispose = value
        End Set
    End Property

    Private pDisposeDate As Date
    Public Property DisposeDate() As Date
        Get
            Return pDisposeDate
        End Get
        Set(ByVal value As Date)
            pDisposeDate = value
        End Set
    End Property

    Private pIsInspectionForDisposal As Boolean
    Public Property IsInspectionForDisposal() As Boolean
        Get
            Return pIsInspectionForDisposal
        End Get
        Set(ByVal value As Boolean)
            pIsInspectionForDisposal = value
        End Set
    End Property

    Private pInspectionDate As Date
    Public Property InspectionDate() As Date
        Get
            Return pInspectionDate
        End Get
        Set(ByVal value As Date)
            pInspectionDate = value
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

    Private pSerialNo As String
    Public Property SerialNo() As String
        Get
            Return pSerialNo
        End Get
        Set(ByVal value As String)
            pSerialNo = value
        End Set
    End Property

    Private pAmount As Integer
    Public Property Amount() As Integer
        Get
            Return pAmount
        End Get
        Set(ByVal value As Integer)
            pAmount = value
        End Set
    End Property

    Private ptype As String
    Public Property type() As String
        Get
            Return ptype
        End Get
        Set(ByVal value As String)
            ptype = value
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

    Private pRC_ID As Integer
    Public Property RC_ID() As Integer
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Integer)
            pRC_ID = value
        End Set
    End Property

    Private pFunction_ID As Integer
    Public Property Function_ID() As Integer
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Integer)
            pFunction_ID = value
        End Set
    End Property

    Private pAccountablePerson As String
    Public Property AccountablePerson() As String
        Get
            Return pAccountablePerson
        End Get
        Set(ByVal value As String)
            pAccountablePerson = value
        End Set
    End Property

#End Region
    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@Barcode", Barcode)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Issued", Issued)
        objDerived.cmd.Parameters.AddWithValue("@Repair", Repair)
        objDerived.cmd.Parameters.AddWithValue("@Details", Details)
        objDerived.cmd.Parameters.AddWithValue("@Dispose", Dispose)
        objDerived.cmd.Parameters.AddWithValue("@DisposeDate", DisposeDate)
        objDerived.cmd.Parameters.AddWithValue("@IsInspectionForDisposal", IsInspectionForDisposal)
        objDerived.cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@type", type)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Property_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function

    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@PropertyDetai_ID", PropertyDetai_ID)
        objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", Property_ID)
        objDerived.cmd.Parameters.AddWithValue("@Barcode", Barcode)
        objDerived.cmd.Parameters.AddWithValue("@Status", Status)
        objDerived.cmd.Parameters.AddWithValue("@Issued", Issued)
        objDerived.cmd.Parameters.AddWithValue("@Repair", Repair)
        objDerived.cmd.Parameters.AddWithValue("@Details", Details)
        objDerived.cmd.Parameters.AddWithValue("@Dispose", Dispose)
        objDerived.cmd.Parameters.AddWithValue("@DisposeDate", DisposeDate)
        objDerived.cmd.Parameters.AddWithValue("@IsInspectionForDisposal", IsInspectionForDisposal)
        objDerived.cmd.Parameters.AddWithValue("@InspectionDate", InspectionDate)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@SerialNo", SerialNo)
        objDerived.cmd.Parameters.AddWithValue("@Amount", Amount)
        objDerived.cmd.Parameters.AddWithValue("@type", type)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@AccountablePerson", AccountablePerson)

        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Property_Dtl", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
