Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic

Namespace ConsolidatedMedicineSaving

#Region "TBMedicine_DTl"

    Public Class TBMedicine_DTl
        Inherits BaseDLL.BaseDAL

        Private pMedicineDtl As Long
        Public Property MedicineDtl() As Long
            Get
                Return pMedicineDtl
            End Get
            Set(ByVal value As Long)
                pMedicineDtl = value
            End Set
        End Property

        Private pMedicineID As Long
        Public Property MedicineID() As Long
            Get
                Return pMedicineID
            End Get
            Set(ByVal value As Long)
                pMedicineID = value
            End Set
        End Property

        Private pStockId As Long
        Public Property StockId() As Long
            Get
                Return pStockId
            End Get
            Set(ByVal value As Long)
                pStockId = value
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

        Private pForm As String
        Public Property Form() As String
            Get
                Return pForm
            End Get
            Set(ByVal value As String)
                pForm = value
            End Set
        End Property

        Private pOTCRx As String
        Public Property OTCRx() As String
            Get
                Return pOTCRx
            End Get
            Set(ByVal value As String)
                pOTCRx = value
            End Set
        End Property

        Private pMftgdate As String
        Public Property Mftgdate() As String
            Get
                Return pMftgdate
            End Get
            Set(ByVal value As String)
                pMftgdate = value
            End Set
        End Property

        Private pBatch As String
        Public Property Batch() As String
            Get
                Return pBatch
            End Get
            Set(ByVal value As String)
                pBatch = value
            End Set
        End Property

        Private pLot As String
        Public Property Lot() As String
            Get
                Return pLot
            End Get
            Set(ByVal value As String)
                pLot = value
            End Set
        End Property

        Private pActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return pActualPrice
            End Get
            Set(ByVal value As Decimal)
                pActualPrice = value
            End Set
        End Property

        Private pSellingPrice As Decimal
        Public Property SellingPrice() As Decimal
            Get
                Return pSellingPrice
            End Get
            Set(ByVal value As Decimal)
                pSellingPrice = value
            End Set
        End Property

        Private pEpiryDate As Date
        Public Property EpiryDate() As Date
            Get
                Return pEpiryDate
            End Get
            Set(ByVal value As Date)
                pEpiryDate = value
            End Set
        End Property

        Private pAlert As Date
        Public Property Alert() As Date
            Get
                Return pAlert
            End Get
            Set(ByVal value As Date)
                pAlert = value
            End Set
        End Property

        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MedicineDtl", 0)
            objDerived.cmd.Parameters.AddWithValue("@MedicineID", MedicineID)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TBMedicine_DTl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MedicineDtl", MedicineDtl)
            objDerived.cmd.Parameters.AddWithValue("@MedicineID", MedicineID)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TBMedicine_DTl", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "TBMedicine_Info"

    Public Class TBMedicine_Info
        Inherits BaseDLL.BaseDAL

        Private pMedicineId As Long
        Public Property MedicineId() As Long
            Get
                Return pMedicineId
            End Get
            Set(ByVal value As Long)
                pMedicineId = value
            End Set
        End Property

        Private pAIRDtl_ID As Long
        Public Property AIRDtl_ID() As Long
            Get
                Return pAIRDtl_ID
            End Get
            Set(ByVal value As Long)
                pAIRDtl_ID = value
            End Set
        End Property

        Private pStockId As Long
        Public Property StockId() As Long
            Get
                Return pStockId
            End Get
            Set(ByVal value As Long)
                pStockId = value
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

        Private pDescription As String
        Public Property Description() As String
            Get
                Return pDescription
            End Get
            Set(ByVal value As String)
                pDescription = value
            End Set
        End Property

        Private pDrugName As String
        Public Property DrugName() As String
            Get
                Return pDrugName
            End Get
            Set(ByVal value As String)
                pDrugName = value
            End Set
        End Property

        Private pBrandName As String
        Public Property BrandName() As String
            Get
                Return pBrandName
            End Get
            Set(ByVal value As String)
                pBrandName = value
            End Set
        End Property

        Private pSupplierId As Long
        Public Property SupplierId() As Long
            Get
                Return pSupplierId
            End Get
            Set(ByVal value As Long)
                pSupplierId = value
            End Set
        End Property

        Private pDose As String
        Public Property Dose() As String
            Get
                Return pDose
            End Get
            Set(ByVal value As String)
                pDose = value
            End Set
        End Property

        Private pDeliveryDate As Date
        Public Property DeliveryDate() As Date
            Get
                Return pDeliveryDate
            End Get
            Set(ByVal value As Date)
                pDeliveryDate = value
            End Set
        End Property

        Private pDepreciatedrate As String
        Public Property Depreciatedrate() As String
            Get
                Return pDepreciatedrate
            End Get
            Set(ByVal value As String)
                pDepreciatedrate = value
            End Set
        End Property

        Private pDepreciatedvalue As Decimal
        Public Property Depreciatedvalue() As Decimal
            Get
                Return pDepreciatedvalue
            End Get
            Set(ByVal value As Decimal)
                pDepreciatedvalue = value
            End Set
        End Property

        Private pLocation As String
        Public Property Location() As String
            Get
                Return pLocation
            End Get
            Set(ByVal value As String)
                pLocation = value
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

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MedicineId", 0)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@Drugname", DrugName)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@SupplierId", SupplierId)
            objDerived.cmd.Parameters.AddWithValue("@Dose", Dose)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciatedrate", Depreciatedrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciatedvalue", Depreciatedvalue)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TBMedicine_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@MedicineId", MedicineId)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@Description", Description)
            objDerived.cmd.Parameters.AddWithValue("@Drugname", DrugName)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@SupplierId", SupplierId)
            objDerived.cmd.Parameters.AddWithValue("@Dose", Dose)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciatedrate", Depreciatedrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciatedvalue", Depreciatedvalue)
            objDerived.cmd.Parameters.AddWithValue("@Location", Location)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.Save_TBMedicine_Info", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class


#End Region


#Region "TbBlood"

    Public Class TbBlood
        Inherits BaseDLL.BaseDAL

        Private pBlood_ID As Long
        Public Property Blood_ID() As Long
            Get
                Return pBlood_ID
            End Get
            Set(ByVal value As Long)
                pBlood_ID = value
            End Set
        End Property

        Private pStockId As Long
        Public Property StockId() As Long
            Get
                Return pStockId
            End Get
            Set(ByVal value As Long)
                pStockId = value
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

        Private pAIRDtl_ID As Long
        Public Property AIRDtl_ID() As Long
            Get
                Return pAIRDtl_ID
            End Get
            Set(ByVal value As Long)
                pAIRDtl_ID = value
            End Set
        End Property

        Private pForm As String
        Public Property Form() As String
            Get
                Return pForm
            End Get
            Set(ByVal value As String)
                pForm = value
            End Set
        End Property

        Private pOTCRx As String
        Public Property OTCRx() As String
            Get
                Return pOTCRx
            End Get
            Set(ByVal value As String)
                pOTCRx = value
            End Set
        End Property

        Private pMftgdate As String
        Public Property Mftgdate() As String
            Get
                Return pMftgdate
            End Get
            Set(ByVal value As String)
                pMftgdate = value
            End Set
        End Property

        Private pBatch As String
        Public Property Batch() As String
            Get
                Return pBatch
            End Get
            Set(ByVal value As String)
                pBatch = value
            End Set
        End Property

        Private pLot As String
        Public Property Lot() As String
            Get
                Return pLot
            End Get
            Set(ByVal value As String)
                pLot = value
            End Set
        End Property

        Private pActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return pActualPrice
            End Get
            Set(ByVal value As Decimal)
                pActualPrice = value
            End Set
        End Property

        Private pEpiryDate As Date
        Public Property EpiryDate() As Date
            Get
                Return pEpiryDate
            End Get
            Set(ByVal value As Date)
                pEpiryDate = value
            End Set
        End Property

        Private pAlert As Date
        Public Property Alert() As Date
            Get
                Return pAlert
            End Get
            Set(ByVal value As Date)
                pAlert = value
            End Set
        End Property

        Private pItemDesc As String
        Public Property ItemDesc() As String
            Get
                Return pItemDesc
            End Get
            Set(ByVal value As String)
                pItemDesc = value
            End Set
        End Property

        Private pBloodType As String
        Public Property BloodType() As String
            Get
                Return pBloodType
            End Get
            Set(ByVal value As String)
                pBloodType = value
            End Set
        End Property

        Private pSupplier_Id As Long
        Public Property Supplier_Id() As Long
            Get
                Return pSupplier_Id
            End Get
            Set(ByVal value As Long)
                pSupplier_Id = value
            End Set
        End Property

        Private pDeliveryDate As Date
        Public Property DeliveryDate() As Date
            Get
                Return pDeliveryDate
            End Get
            Set(ByVal value As Date)
                pDeliveryDate = value
            End Set
        End Property

        Private pStorage As String
        Public Property Storage() As String
            Get
                Return pStorage
            End Get
            Set(ByVal value As String)
                pStorage = value
            End Set
        End Property

        Private pDepreciationrate As Decimal
        Public Property Depreciationrate() As Decimal
            Get
                Return pDepreciationrate
            End Get
            Set(ByVal value As Decimal)
                pDepreciationrate = value
            End Set
        End Property

        Private pDepreciationvalue As Decimal
        Public Property Depreciationvalue() As Decimal
            Get
                Return pDepreciationvalue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationvalue = value
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



        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Blood_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BloodType", BloodType)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbBlood", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Blood_ID", Blood_ID)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BloodType", BloodType)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbBlood", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "TbNonFood"

    Public Class TbNonFood
        Inherits BaseDLL.BaseDAL

        Private pNonFood_ID As Long
        Public Property NonFood_ID() As Long
            Get
                Return pNonFood_ID
            End Get
            Set(ByVal value As Long)
                pNonFood_ID = value
            End Set
        End Property

        Private pStockId As Long
        Public Property StockId() As Long
            Get
                Return pStockId
            End Get
            Set(ByVal value As Long)
                pStockId = value
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

        Private pAIRDtl_ID As Long
        Public Property AIRDtl_ID() As Long
            Get
                Return pAIRDtl_ID
            End Get
            Set(ByVal value As Long)
                pAIRDtl_ID = value
            End Set
        End Property

        Private pForm As String
        Public Property Form() As String
            Get
                Return pForm
            End Get
            Set(ByVal value As String)
                pForm = value
            End Set
        End Property

        Private pOTCRx As String
        Public Property OTCRx() As String
            Get
                Return pOTCRx
            End Get
            Set(ByVal value As String)
                pOTCRx = value
            End Set
        End Property

        Private pMftgdate As String
        Public Property Mftgdate() As String
            Get
                Return pMftgdate
            End Get
            Set(ByVal value As String)
                pMftgdate = value
            End Set
        End Property

        Private pBatch As String
        Public Property Batch() As String
            Get
                Return pBatch
            End Get
            Set(ByVal value As String)
                pBatch = value
            End Set
        End Property

        Private pLot As String
        Public Property Lot() As String
            Get
                Return pLot
            End Get
            Set(ByVal value As String)
                pLot = value
            End Set
        End Property

        Private pActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return pActualPrice
            End Get
            Set(ByVal value As Decimal)
                pActualPrice = value
            End Set
        End Property

        Private pEpiryDate As Date
        Public Property EpiryDate() As Date
            Get
                Return pEpiryDate
            End Get
            Set(ByVal value As Date)
                pEpiryDate = value
            End Set
        End Property

        Private pAlert As Date
        Public Property Alert() As Date
            Get
                Return pAlert
            End Get
            Set(ByVal value As Date)
                pAlert = value
            End Set
        End Property

        Private pItemDesc As String
        Public Property ItemDesc() As String
            Get
                Return pItemDesc
            End Get
            Set(ByVal value As String)
                pItemDesc = value
            End Set
        End Property

        Private pBrandName As String
        Public Property BrandName() As String
            Get
                Return pBrandName
            End Get
            Set(ByVal value As String)
                pBrandName = value
            End Set
        End Property

        Private pSupplier_Id As Long
        Public Property Supplier_Id() As Long
            Get
                Return pSupplier_Id
            End Get
            Set(ByVal value As Long)
                pSupplier_Id = value
            End Set
        End Property

        Private pDeliveryDate As Date
        Public Property DeliveryDate() As Date
            Get
                Return pDeliveryDate
            End Get
            Set(ByVal value As Date)
                pDeliveryDate = value
            End Set
        End Property

        Private pStorage As String
        Public Property Storage() As String
            Get
                Return pStorage
            End Get
            Set(ByVal value As String)
                pStorage = value
            End Set
        End Property

        Private pDepreciationrate As String
        Public Property Depreciationrate() As String
            Get
                Return pDepreciationrate
            End Get
            Set(ByVal value As String)
                pDepreciationrate = value
            End Set
        End Property

        Private pDepreciationvalue As Decimal
        Public Property Depreciationvalue() As Decimal
            Get
                Return pDepreciationvalue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationvalue = value
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

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@NonFood_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbNonFood", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@NonFood_ID", NonFood_ID)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbNonFood", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "TbFood"

    Public Class TbFood
        Inherits BaseDLL.BaseDAL

        Private pFood_ID As Long
        Public Property Food_ID() As Long
            Get
                Return pFood_ID
            End Get
            Set(ByVal value As Long)
                pFood_ID = value
            End Set
        End Property

        Private pStockId As Long
        Public Property StockId() As Long
            Get
                Return pStockId
            End Get
            Set(ByVal value As Long)
                pStockId = value
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

        Private pAIRDtl_ID As Long
        Public Property AIRDtl_ID() As Long
            Get
                Return pAIRDtl_ID
            End Get
            Set(ByVal value As Long)
                pAIRDtl_ID = value
            End Set
        End Property

        Private pForm As String
        Public Property Form() As String
            Get
                Return pForm
            End Get
            Set(ByVal value As String)
                pForm = value
            End Set
        End Property

        Private pOTCRx As String
        Public Property OTCRx() As String
            Get
                Return pOTCRx
            End Get
            Set(ByVal value As String)
                pOTCRx = value
            End Set
        End Property

        Private pMftgdate As String
        Public Property Mftgdate() As String
            Get
                Return pMftgdate
            End Get
            Set(ByVal value As String)
                pMftgdate = value
            End Set
        End Property

        Private pBatch As String
        Public Property Batch() As String
            Get
                Return pBatch
            End Get
            Set(ByVal value As String)
                pBatch = value
            End Set
        End Property

        Private pLot As String
        Public Property Lot() As String
            Get
                Return pLot
            End Get
            Set(ByVal value As String)
                pLot = value
            End Set
        End Property

        Private pActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return pActualPrice
            End Get
            Set(ByVal value As Decimal)
                pActualPrice = value
            End Set
        End Property

        Private pEpiryDate As Date
        Public Property EpiryDate() As Date
            Get
                Return pEpiryDate
            End Get
            Set(ByVal value As Date)
                pEpiryDate = value
            End Set
        End Property

        Private pAlert As Date
        Public Property Alert() As Date
            Get
                Return pAlert
            End Get
            Set(ByVal value As Date)
                pAlert = value
            End Set
        End Property

        Private pItemDesc As String
        Public Property ItemDesc() As String
            Get
                Return pItemDesc
            End Get
            Set(ByVal value As String)
                pItemDesc = value
            End Set
        End Property

        Private pBrandName As String
        Public Property BrandName() As String
            Get
                Return pBrandName
            End Get
            Set(ByVal value As String)
                pBrandName = value
            End Set
        End Property

        Private pSupplier_Id As Long
        Public Property Supplier_Id() As Long
            Get
                Return pSupplier_Id
            End Get
            Set(ByVal value As Long)
                pSupplier_Id = value
            End Set
        End Property

        Private pDeliveryDate As Date
        Public Property DeliveryDate() As Date
            Get
                Return pDeliveryDate
            End Get
            Set(ByVal value As Date)
                pDeliveryDate = value
            End Set
        End Property

        Private pStorage As String
        Public Property Storage() As String
            Get
                Return pStorage
            End Get
            Set(ByVal value As String)
                pStorage = value
            End Set
        End Property

        Private pDepreciationrate As String
        Public Property Depreciationrate() As String
            Get
                Return pDepreciationrate
            End Get
            Set(ByVal value As String)
                pDepreciationrate = value
            End Set
        End Property

        Private pDepreciationvalue As Decimal
        Public Property Depreciationvalue() As Decimal
            Get
                Return pDepreciationvalue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationvalue = value
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

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Food_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbFood", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Food_ID", Food_ID)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbFood", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region
#Region "TbWater"

    Public Class TbWater
        Inherits BaseDLL.BaseDAL

        Private pWater_ID As Long
        Public Property Water_ID() As Long
            Get
                Return pWater_ID
            End Get
            Set(ByVal value As Long)
                pWater_ID = value
            End Set
        End Property

        Private pStockId As Long
        Public Property StockId() As Long
            Get
                Return pStockId
            End Get
            Set(ByVal value As Long)
                pStockId = value
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

        Private pAIRDtl_ID As Long
        Public Property AIRDtl_ID() As Long
            Get
                Return pAIRDtl_ID
            End Get
            Set(ByVal value As Long)
                pAIRDtl_ID = value
            End Set
        End Property

        Private pForm As String
        Public Property Form() As String
            Get
                Return pForm
            End Get
            Set(ByVal value As String)
                pForm = value
            End Set
        End Property

        Private pOTCRx As String
        Public Property OTCRx() As String
            Get
                Return pOTCRx
            End Get
            Set(ByVal value As String)
                pOTCRx = value
            End Set
        End Property

        Private pMftgdate As String
        Public Property Mftgdate() As String
            Get
                Return pMftgdate
            End Get
            Set(ByVal value As String)
                pMftgdate = value
            End Set
        End Property

        Private pBatch As String
        Public Property Batch() As String
            Get
                Return pBatch
            End Get
            Set(ByVal value As String)
                pBatch = value
            End Set
        End Property

        Private pLot As String
        Public Property Lot() As String
            Get
                Return pLot
            End Get
            Set(ByVal value As String)
                pLot = value
            End Set
        End Property

        Private pActualPrice As Decimal
        Public Property ActualPrice() As Decimal
            Get
                Return pActualPrice
            End Get
            Set(ByVal value As Decimal)
                pActualPrice = value
            End Set
        End Property

        Private pEpiryDate As Date
        Public Property EpiryDate() As Date
            Get
                Return pEpiryDate
            End Get
            Set(ByVal value As Date)
                pEpiryDate = value
            End Set
        End Property

        Private pAlert As Date
        Public Property Alert() As Date
            Get
                Return pAlert
            End Get
            Set(ByVal value As Date)
                pAlert = value
            End Set
        End Property

        Private pItemDesc As String
        Public Property ItemDesc() As String
            Get
                Return pItemDesc
            End Get
            Set(ByVal value As String)
                pItemDesc = value
            End Set
        End Property

        Private pBrandName As String
        Public Property BrandName() As String
            Get
                Return pBrandName
            End Get
            Set(ByVal value As String)
                pBrandName = value
            End Set
        End Property

        Private pSupplier_Id As Long
        Public Property Supplier_Id() As Long
            Get
                Return pSupplier_Id
            End Get
            Set(ByVal value As Long)
                pSupplier_Id = value
            End Set
        End Property

        Private pDeliveryDate As Date
        Public Property DeliveryDate() As Date
            Get
                Return pDeliveryDate
            End Get
            Set(ByVal value As Date)
                pDeliveryDate = value
            End Set
        End Property

        Private pStorage As String
        Public Property Storage() As String
            Get
                Return pStorage
            End Get
            Set(ByVal value As String)
                pStorage = value
            End Set
        End Property

        Private pDepreciationrate As String
        Public Property Depreciationrate() As String
            Get
                Return pDepreciationrate
            End Get
            Set(ByVal value As String)
                pDepreciationrate = value
            End Set
        End Property

        Private pDepreciationvalue As Decimal
        Public Property Depreciationvalue() As Decimal
            Get
                Return pDepreciationvalue
            End Get
            Set(ByVal value As Decimal)
                pDepreciationvalue = value
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

        Private pReceived_ID As Long
        Public Property Received_ID() As Long
            Get
                Return pReceived_ID
            End Get
            Set(ByVal value As Long)
                pReceived_ID = value
            End Set
        End Property


        Public Function save() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Water_ID", 0)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbWater", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

        Public Function update() As Long
            Dim objDerived As New DerivedDal
            objDerived.conStr = objDerived.DbaseConnect()
            Dim i As Long
            objDerived.cmd.Parameters.AddWithValue("@Water_ID", Water_ID)
            objDerived.cmd.Parameters.AddWithValue("@StockId", StockId)
            objDerived.cmd.Parameters.AddWithValue("@Item_ID", Item_ID)
            objDerived.cmd.Parameters.AddWithValue("@AIRDtl_ID", AIRDtl_ID)
            objDerived.cmd.Parameters.AddWithValue("@Form", Form)
            objDerived.cmd.Parameters.AddWithValue("@OTCRx", OTCRx)
            objDerived.cmd.Parameters.AddWithValue("@Mftgdate", Mftgdate)
            objDerived.cmd.Parameters.AddWithValue("@Batch", Batch)
            objDerived.cmd.Parameters.AddWithValue("@Lot", Lot)
            objDerived.cmd.Parameters.AddWithValue("@ActualPrice", ActualPrice)
            objDerived.cmd.Parameters.AddWithValue("@EpiryDate", EpiryDate)
            objDerived.cmd.Parameters.AddWithValue("@Alert", Alert)
            objDerived.cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc)
            objDerived.cmd.Parameters.AddWithValue("@BrandName", BrandName)
            objDerived.cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id)
            objDerived.cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate)
            objDerived.cmd.Parameters.AddWithValue("@Storage", Storage)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationrate", Depreciationrate)
            objDerived.cmd.Parameters.AddWithValue("@Depreciationvalue", Depreciationvalue)
            objDerived.cmd.Parameters.AddWithValue("@Status", Status)
            objDerived.cmd.Parameters.AddWithValue("@Received_ID", Received_ID)
            objDerived.cmd.Parameters.Add("@CurrID", SqlDbType.BigInt).Direction = ParameterDirection.Output
            i = objDerived.Execute("@CurrID", "AMS.sp_Save_TbWater", CommandType.StoredProcedure, Nothing)
            Return i
        End Function

    End Class
#End Region

End Namespace
