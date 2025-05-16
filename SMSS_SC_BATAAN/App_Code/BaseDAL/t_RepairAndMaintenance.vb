Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Public Class t_RepairAndMaintenance

#Region "TbRepairMaintenance"

    Public Class TbRepairMaintenance
        Inherits BaseDLL.BaseDAL

        Private pRepairMaintenanceId As Long
        Public Property RepairMaintenanceId() As Long
            Get
                Return pRepairMaintenanceId
            End Get
            Set(ByVal value As Long)
                pRepairMaintenanceId = value
            End Set
        End Property

        Private pProperty_Dtl_ID As Long
        Public Property Property_Dtl_ID() As Long
            Get
                Return pProperty_Dtl_ID
            End Get
            Set(ByVal value As Long)
                pProperty_Dtl_ID = value
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

        Private pdDate As Date
        Public Property dDate() As Date
            Get
                Return pdDate
            End Get
            Set(ByVal value As Date)
                pdDate = value
            End Set
        End Property

        Private pServiceProvider As String
        Public Property ServiceProvider() As String
            Get
                Return pServiceProvider
            End Get
            Set(ByVal value As String)
                pServiceProvider = value
            End Set
        End Property

        Private pNatureRepair As String
        Public Property NatureRepair() As String
            Get
                Return pNatureRepair
            End Get
            Set(ByVal value As String)
                pNatureRepair = value
            End Set
        End Property

        Private pInvoiceNo As String
        Public Property InvoiceNo() As String
            Get
                Return pInvoiceNo
            End Get
            Set(ByVal value As String)
                pInvoiceNo = value
            End Set
        End Property

        'Private pAmount As Decimal
        'Public Property Amount() As Decimal
        '    Get
        '        Return pAmount
        '    End Get
        '    Set(ByVal value As Decimal)
        '        pAmount = value
        '    End Set
        'End Property


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

        Private pGA_Code2 As Integer
        Public Property GA_Code2() As Integer
            Get
                Return pGA_Code2
            End Get
            Set(ByVal value As Integer)
                pGA_Code2 = value
            End Set
        End Property

        Private pProgram_ID As Long
        Public Property Program_ID() As Long
            Get
                Return pProgram_ID
            End Get
            Set(ByVal value As Long)
                pProgram_ID = value
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

        Private pItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return pItem_ID
            End Get
            Set(ByVal value As Long)
                pItem_ID = value
            End Set
        End Property

        Private pppmp_hdr_id As Long
        Public Property ppmp_hdr_id() As Long
            Get
                Return pppmp_hdr_id
            End Get
            Set(ByVal value As Long)
                pppmp_hdr_id = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@RepairMaintenanceId", 0)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@dDate", dDate)
            objDerived.cmd.Parameters.AddWithValue("@ServiceProvider", ServiceProvider)
            objDerived.cmd.Parameters.AddWithValue("@NatureRepair", NatureRepair)
            objDerived.cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_Code2", GA_Code2)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", Program_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", ppmp_hdr_id)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_TbRepairMaintenance", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@RepairMaintenanceId", RepairMaintenanceId)
            objDerived.cmd.Parameters.AddWithValue("@Property_Dtl_ID", Property_Dtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo)
            objDerived.cmd.Parameters.AddWithValue("@dDate", dDate)
            objDerived.cmd.Parameters.AddWithValue("@ServiceProvider", ServiceProvider)
            objDerived.cmd.Parameters.AddWithValue("@NatureRepair", NatureRepair)
            objDerived.cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo)
            objDerived.cmd.Parameters.AddWithValue("@RC_ID", RC_ID)
            objDerived.cmd.Parameters.AddWithValue("@Function_ID", Function_ID)
            objDerived.cmd.Parameters.AddWithValue("@GA_Code2", GA_Code2)
            objDerived.cmd.Parameters.AddWithValue("@Program_ID", Program_ID)
            objDerived.cmd.Parameters.AddWithValue("@Project_ID", Project_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@ppmp_hdr_id", ppmp_hdr_id)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.spSave_TbRepairMaintenance", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
#Region "TbRepair_Dtl"

    Public Class TbRepair_Dtl
        Inherits BaseDLL.BaseDAL

        Private pRepairDtl_ID As Long
        Public Property RepairDtl_ID() As Long
            Get
                Return pRepairDtl_ID
            End Get
            Set(ByVal value As Long)
                pRepairDtl_ID = value
            End Set
        End Property

        Private pRepairMaintenanceId As Long
        Public Property RepairMaintenanceId() As Long
            Get
                Return pRepairMaintenanceId
            End Get
            Set(ByVal value As Long)
                pRepairMaintenanceId = value
            End Set
        End Property


        Private pItem_ID As Long
        Public Property Item_ID() As Long
            Get
                Return pItem_ID
            End Get
            Set(ByVal value As Long)
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


        Private pPrice As Decimal
        Public Property Price() As Decimal
            Get
                Return pPrice
            End Get
            Set(ByVal value As Decimal)
                pPrice = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@RepairDtl_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@RepairMaintenanceId", RepairMaintenanceId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@Price", Price)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_TbRepair_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@RepairDtl_ID", RepairDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@RepairMaintenanceId", RepairMaintenanceId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Qty", Qty)
            objDerived.cmd.Parameters.AddWithValue("@Price", Price)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "[AMS].[spSave_TbRepair_Dtl]", CommandType.StoredProcedure, Nothing)
            Return i
        End Function
    End Class
#End Region
End Class
