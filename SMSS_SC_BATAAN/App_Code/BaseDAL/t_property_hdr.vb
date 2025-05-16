Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System

Public Class t_property_hdr
    Inherits BaseDLL.BaseDAL

#Region "property"
    Private pProperty_ID As Integer
    Public Property Property_ID() As Long
        Get
            Return pProperty_ID
        End Get
        Set(ByVal value As Long)
            pProperty_ID = value
        End Set
    End Property

    Private pProperty_Date As DateTime
    Public Property Property_Date() As DateTime
        Get
            Return pProperty_Date
        End Get
        Set(ByVal value As DateTime)
            pProperty_Date = value
        End Set
    End Property

    Private pProperty_code As String
    Public Property Property_code() As String
        Get
            Return pProperty_code
        End Get
        Set(ByVal value As String)
            pProperty_code = value
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

    Private pQty As Integer
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(ByVal value As Integer)
            pQty = value
        End Set
    End Property

    Private pBalance As Integer
    Public Property Balance() As Integer
        Get
            Return pBalance
        End Get
        Set(ByVal value As Integer)
            pBalance = value
        End Set
    End Property

    Private pIssuance As Integer
    Public Property Issuance() As Integer
        Get
            Return pIssuance
        End Get
        Set(ByVal value As Integer)
            pIssuance = value
        End Set
    End Property

    Private pCost As Decimal
    Public Property Cost() As Decimal
        Get
            Return pCost
        End Get
        Set(ByVal value As Decimal)
            pCost = value
        End Set
    End Property

    Private pRC_ID As Long
    Public Property RC_ID() As Long
        Get
            Return pRC_ID
        End Get
        Set(ByVal value As Long)
            pRC_ID = value
        End Set
    End Property

    Private pFunction_ID As Long
    Public Property Function_ID() As Long
        Get
            Return pFunction_ID
        End Get
        Set(ByVal value As Long)
            pFunction_ID = value
        End Set
    End Property

    Private pProject_ID As Long
    Public Property Project_ID() As Long
        Get
            Return pProject_ID
        End Get
        Set(ByVal value As Long)
            pProject_ID = value
        End Set
    End Property

    Private pProgram_id As Long
    Public Property Program_id() As Long
        Get
            Return pProgram_id
        End Get
        Set(ByVal value As Long)
            pProgram_id = value
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

    Private pEmp_ID As Integer
    Public Property Emp_ID() As Integer
        Get
            Return pEmp_ID
        End Get
        Set(ByVal value As Integer)
            pEmp_ID = value
        End Set
    End Property

    Private pTD_ID As Long
    Public Property TD_ID() As Long
        Get
            Return pTD_ID
        End Get
        Set(ByVal value As Long)
            pTD_ID = value
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

    Private pAIRDtl_ID As Integer
    Public Property AIRDtl_ID() As Integer
        Get
            Return pAIRDtl_ID
        End Get
        Set(ByVal value As Integer)
            pAIRDtl_ID = value
        End Set
    End Property

    Private pdeptid As Integer
    Public Property deptid() As Integer
        Get
            Return pdeptid
        End Get
        Set(ByVal value As Integer)
            pdeptid = value
        End Set
    End Property
    Private pisDonated As Boolean
    Public Property isDonated() As Boolean
        Get
            Return pisDonated
        End Get
        Set(ByVal value As Boolean)
            pisDonated = value
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

    Private pDonationRemarks As String
    Public Property DonationRemarks() As String
        Get
            Return pDonationRemarks
        End Get
        Set(ByVal value As String)
            pDonationRemarks = value
        End Set
    End Property

    Private pParticular As String
    Public Property Particular() As String
        Get
            Return pParticular
        End Get
        Set(ByVal value As String)
            pParticular = value
        End Set
    End Property

    Private pPOHdr_ID As Long
    Public Property POHdr_ID() As Long
        Get
            Return pPOHdr_ID
        End Get
        Set(ByVal value As Long)
            pPOHdr_ID = value
        End Set
    End Property

    Private pReceived_ID As Long
    Public Property Received_ID() As Long
        Get
            Return pReceived_ID
        End Get
        Set(ByVal value As Long)
            pReceived_ID = value
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

#End Region

    Public Function save() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", 0)
        objDerived.cmd.Parameters.AddWithValue("@Property_Date", Property_Date)
        objDerived.cmd.Parameters.AddWithValue("@Property_code", Property_code)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Balance", Balance)
        objDerived.cmd.Parameters.AddWithValue("@Issuance", Issuance)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@Emp_ID", Emp_ID)
        objDerived.cmd.Parameters.AddWithValue("@TD_ID", TD_ID)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@isDonated", isDonated)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@DonationRemarks", DonationRemarks)
        objDerived.cmd.Parameters.AddWithValue("@Particular", Particular)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Property", CommandType.StoredProcedure, Nothing)
        Return i
    End Function


    Public Function update() As Long
        Dim objDerived As New DerivedDal
        Dim i As Long
        objDerived.cmd.Parameters.AddWithValue("@Property_ID", pProperty_ID)
        objDerived.cmd.Parameters.AddWithValue("@Property_Date", Property_Date)
        objDerived.cmd.Parameters.AddWithValue("@Property_code", Property_code)
        objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
        objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
        objDerived.cmd.Parameters.AddWithValue("@Balance", Balance)
        objDerived.cmd.Parameters.AddWithValue("@Issuance", Issuance)
        objDerived.cmd.Parameters.AddWithValue("@Cost", Cost)
        objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
        objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
        objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
        objDerived.cmd.Parameters.AddWithValue("@Program_id", Program_id)
        objDerived.cmd.Parameters.AddWithValue("@Remarks", Remarks)
        objDerived.cmd.Parameters.AddWithValue("@Emp_ID", Emp_ID)
        objDerived.cmd.Parameters.AddWithValue("@TD_ID", TD_ID)
        objDerived.cmd.Parameters.AddWithValue("@F_ID", F_ID)
        objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
        objDerived.cmd.Parameters.AddWithValue("@deptid", deptid)
        objDerived.cmd.Parameters.AddWithValue("@isDonated", isDonated)
        objDerived.cmd.Parameters.AddWithValue("@GA_ID", GA_ID)
        objDerived.cmd.Parameters.AddWithValue("@DonationRemarks", DonationRemarks)
        objDerived.cmd.Parameters.AddWithValue("@Particular", Particular)
        objDerived.cmd.Parameters.AddWithValue("@POHdr_ID", POHdr_ID)
        objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
        objDerived.cmd.Parameters.AddWithValue("@UserID", UserID)
        objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
        i = objDerived.Execute("@CurrID", "AMS.spSave_Property", CommandType.StoredProcedure, Nothing)
        Return i
    End Function
End Class
